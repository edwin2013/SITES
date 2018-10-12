//
//  @ Project : 
//  @ File Name : frmMantenimientoATMs.cs
//  @ Date : 08/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoATMs : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private ATM _atm = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoATMs()
        {
            InitializeComponent();

            try
            {
                this.cargarDatos();

                cboTipoUbicacion.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        public frmMantenimientoATMs(ATM atm)
        {
            InitializeComponent();

            _atm = atm;

            mtbNumero.Enabled = false;

            mtbNumero.Text = _atm.Numero.ToString();
            cboTipo.SelectedIndex = (byte)atm.Tipo;
            nudCartuchos.Value = _atm.Cartuchos;
            txtCodigo.Text = _atm.Codigo;
            txtOficinas.Text = _atm.Oficinas;
            chkExterno.Checked = _atm.Externo;
            chkFull.Checked = _atm.Full;
            chkENA.Checked = _atm.ENA;
            chkVIP.Checked = _atm.VIP;
            chkCartuchoRechazo.Checked = _atm.Cartucho_rechazo;

            try
            {
                this.cargarDatos();

                cboTransportadora.Text = _atm.Empresa_encargada.Nombre;

                if (_atm.Sucursal != null)
                {
                    cboTipoUbicacion.SelectedIndex = 0;
                    cboSucursal.Text = _atm.Sucursal.ToString();

                    pnlSucursal.Visible = true;
                    pnlUbicacion.Visible = false;
                }
                else if (_atm.Ubicacion != null)
                {
                    cboTipoUbicacion.SelectedIndex = 1;
                    cboUbicacion.Text = _atm.Ubicacion.ToString();

                    pnlSucursal.Visible = false;
                    pnlUbicacion.Visible = true;
                }
                else
                {
                    cboTipoUbicacion.SelectedIndex = 0;

                    pnlSucursal.Visible = true;
                    pnlUbicacion.Visible = false;
                }

                // Marcar los días de carga del ATM o mostrar el periodo de carga

                if (_atm.Periodo_carga == null)
                {
                    rbCargaDiasFijos.Checked = true;
   
                    foreach (Dias dia in _atm.Dias_carga)
                        clbDiasCarga.SetItemChecked((byte)dia - 1, true);
                }
                else
                {
                    rbCargaPeriodica.Checked = true;
                    nudPeriodoCarga.Value = (byte)_atm.Periodo_carga;
                }

            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        /// <summary>
        /// Cargar los datos de las listas.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
                cboSucursal.ListaMostrada = _mantenimiento.listarSucursales();
                cboUbicacion.ListaMostrada = _mantenimiento.listarUbicaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if ((cboTipoUbicacion.SelectedIndex == 0 && cboSucursal.SelectedItem == null) ||
                (cboTipoUbicacion.SelectedIndex == 1 && cboUbicacion.SelectedItem == null) ||
                cboTipo.SelectedItem == null || cboTransportadora.SelectedItem == null ||
                mtbNumero.Text.Equals(string.Empty) || txtCodigo.Text.Equals(string.Empty) ||
                txtOficinas.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorATMDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionATMs padre = (frmAdministracionATMs)this.Owner;

                short numero = short.Parse(mtbNumero.Text);
                EmpresaTransporte empresa_encargada = (EmpresaTransporte)cboTransportadora.SelectedItem;
                TiposCartucho tipo = (TiposCartucho)cboTipo.SelectedIndex;
                byte cartuchos = (byte)nudCartuchos.Value;
                string codigo = txtCodigo.Text;
                string oficinas = txtOficinas.Text;
                bool externo = chkExterno.Checked;
                bool full = chkFull.Checked;
                bool ena = full && chkENA.Checked;
                bool vip = chkVIP.Checked;
                bool cartucho_rechazo = chkCartuchoRechazo.Checked;

                byte? periodo_carga = rbCargaPeriodica.Checked ?
                    (byte?)nudPeriodoCarga.Value : null;

                Sucursal sucursal = cboTipoUbicacion.SelectedIndex == 0 ?
                    (Sucursal)cboSucursal.SelectedItem : null;

                Ubicacion ubicacion = cboTipoUbicacion.SelectedIndex == 1 ?
                    (Ubicacion)cboUbicacion.SelectedItem : null;

                // Verificar si el ATM ya está registrado

                if (_atm == null)
                {
                    // Agregar los datos del ATM

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeATMRegistro") == DialogResult.Yes)
                    {
                        ATM nuevo = new ATM(numero: numero, tipo: tipo, empresa_encargada: empresa_encargada, cartuchos: cartuchos,
                                            externo: externo, full: full, ena: ena, vip: vip, cartucho_rechazo: cartucho_rechazo,
                                            codigo: codigo, oficinas: oficinas, periodo_carga: periodo_carga, sucursal: sucursal,
                                            ubicacion: ubicacion);

                        foreach (int dia in clbDiasCarga.CheckedIndices)
                            nuevo.agregarDiaCarga((Dias)dia + 1);

                        _mantenimiento.agregarATM(ref nuevo);

                        padre.agregarATM(nuevo);
                        Mensaje.mostrarMensaje("MensajeATMConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del ATM

                    ATM copia = new ATM(id: _atm.ID, numero: numero, empresa_encargada: empresa_encargada, tipo: tipo,
                                        cartuchos: cartuchos, externo: externo, full: full, ena: ena, vip: vip,
                                        cartucho_rechazo: cartucho_rechazo, codigo: codigo, oficinas: oficinas,
                                        periodo_carga: periodo_carga,sucursal: sucursal,
                                        ubicacion: ubicacion);

                    foreach (int dia in clbDiasCarga.CheckedIndices)
                        copia.agregarDiaCarga((Dias)dia + 1);

                    _mantenimiento.actualizarATM(copia);

                    _atm.Numero = numero;
                    _atm.Empresa_encargada = empresa_encargada;
                    _atm.Tipo = tipo;
                    _atm.Cartuchos = cartuchos;
                    _atm.Externo = externo;
                    _atm.Full = full;
                    _atm.ENA = ena;
                    _atm.VIP = vip;
                    _atm.Cartucho_rechazo = cartucho_rechazo;
                    _atm.Codigo = codigo;
                    _atm.Oficinas = oficinas;
                    _atm.Periodo_carga = periodo_carga;
                    _atm.Sucursal = sucursal;
                    _atm.Ubicacion = ubicacion;
                    _atm.Dias_carga = copia.Dias_carga;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeATMConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otro tipo de ubicación.
        /// </summary>
        private void cboTipoUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboTipoUbicacion.SelectedIndex == 0)
            {
                pnlSucursal.Visible = true;
                pnlUbicacion.Visible = false;
            }
            else
            {
                pnlSucursal.Visible = false;
                pnlUbicacion.Visible = true;
            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de asignar el ATM como full.
        /// </summary>
        private void chkFull_CheckedChanged(object sender, EventArgs e)
        {
            chkENA.Enabled = chkFull.Checked;
        }

        /// <summary>
        /// Se marca o desmarca la opción de asignar una carga periodica al ATM.
        /// </summary>
        private void rbCargaPeriodica_CheckedChanged(object sender, EventArgs e)
        {
            nudPeriodoCarga.Enabled = rbCargaPeriodica.Checked;
        }

        /// <summary>
        /// Se marca o desmarca la opción de asignar una carga en días fijos al ATM.
        /// </summary>
        private void rbCargaDiasFijos_CheckedChanged(object sender, EventArgs e)
        {
            clbDiasCarga.Enabled = rbCargaDiasFijos.Checked;
        }

        #endregion Eventos

    }

}
