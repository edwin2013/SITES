//
//  @ Project : 
//  @ File Name : frmAsignacionMontosBoveda.cs
//  @ Date : 27/03/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmAsignacionMontosBoveda : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private ManifiestoBoveda _manifiesto = null;
        private Colaborador _cajero = null;

        private DateTime _fecha_actual;
        private bool _coordinador;

        #endregion Atributos

        #region Constructor

        public frmAsignacionMontosBoveda(Colaborador cajero)
        {
            InitializeComponent();

            _cajero = cajero;

            try
            {
                dgvManifiestos.AutoGenerateColumns = false;
                dgvRecaps.AutoGenerateColumns = false;

                dgvRecaps.DataSource = new BindingList<RecapExterno>();

                // Obtener la fecha del servidor

                _fecha_actual = _coordinacion.obtenerFechaHora().Date;

                // Cargar las listas

                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA, Puestos.CajeroB);
                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
                cboSucursal.ListaMostrada = _mantenimiento.listarSucursales();

                cboCajero.Text = _cajero.ToString();

                // Validar si el colaborador tiene permisos de coordinador

                _coordinador = _cajero.Puestos.Contains(Puestos.Coordinador);

                cboCajero.Enabled = _coordinador;
                dtpFecha.Enabled = _coordinador;
            }
            catch (Excepcion ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoBuscado.Text;

                if (codigo == string.Empty && codigo.Length < 4) return;

                dgvManifiestos.DataSource = _atencion.listarManifiestosBovedaRecientes(codigo);

                txtCodigoBuscado.Text = string.Empty;

                if (dgvManifiestos.RowCount > 0 && gbDatosManifiesto.Enabled) cboCliente.Focus();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar recap.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;
            frmRegistroModificacionRecap formulario = new frmRegistroModificacionRecap(manifiesto);

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if ((rbCliente.Checked && cboPuntoVenta.SelectedItem == null) ||
                (rbSucursal.Checked && cboSucursal.SelectedItem == null) ||
                cboCajero.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorManifiestoDatosActualizacionBoveda");
                return;
            }

            try
            {
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                
                Sucursal sucursal = null;
                PuntoVenta punto_venta = null;

                if (rbCliente.Checked)
                    punto_venta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                else
                    sucursal = (Sucursal)cboSucursal.SelectedItem;

                decimal monto_colones = nudMontoColones.Value;
                decimal monto_dolares = nudMontoDolares.Value;

                DateTime fecha_procesamiento = dtpFecha.Value;

                ManifiestoBoveda copia = new ManifiestoBoveda(_manifiesto.ID, cajero: cajero, punto_venta: punto_venta, sucursal: sucursal,
                                                              monto_colones: monto_colones, monto_dolares: monto_dolares, 
                                                              fecha_procesamiento: fecha_procesamiento);

                _atencion.actualizarManifiesto(copia);

                _manifiesto.Cajero = cajero;
                _manifiesto.Punto_venta = punto_venta;
                _manifiesto.Sucursal = sucursal;
                _manifiesto.Fecha_procesamiento = fecha_procesamiento;
                _manifiesto.Monto_colones = monto_colones;
                _manifiesto.Monto_dolares = monto_dolares;

                txtCajero.Text = _manifiesto.Cajero.ToString();
               
                if (rbCliente.Checked)
                {
                    txtCliente.Text = _manifiesto.Punto_venta.Cliente.Nombre;
                    txtPuntoVenta.Text = _manifiesto.Punto_venta.Nombre;
                    txtSucursal.Text = string.Empty;
                }
                else
                {
                    txtCliente.Text = string.Empty;
                    txtPuntoVenta.Text = string.Empty;
                    txtSucursal.Text = _manifiesto.Sucursal.Nombre;
                }

                txtFechaProcesamiento.Text = ((DateTime)_manifiesto.Fecha_procesamiento).ToShortDateString();

                txtCodigoBuscado.Focus();

                Mensaje.mostrarMensaje("MensajeManifiestoConfirmacionActualizacion");

                // Actualizar el manifiesto en la lista de manifiestos

                dgvManifiestos.SelectedRows[0].Tag = _manifiesto;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de reiniciar.
        /// </summary>
        private void btnReiniciar_Click(object sender, EventArgs e)
        {

            try
            {
                _atencion.actualizarManifiestoReiniciar(_manifiesto);

                _manifiesto.Cajero = null;
                _manifiesto.Monto_colones = 0;
                _manifiesto.Monto_dolares = 0;
                _manifiesto.Punto_venta = null;
                _manifiesto.Sucursal = null;

                this.borrarDatos();
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
        /// Se selecciona un manifiesto de la lista de manifiestos.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                ManifiestoBoveda manifiesto = (ManifiestoBoveda)dgvManifiestos.SelectedRows[0].DataBoundItem;

                txtCodigoManifiesto.Text = manifiesto.Codigo;

                dgvRecaps.DataSource = manifiesto.Recaps;
                gbRecaps.Enabled = true;

                this.mostrarDatos(manifiesto);
            }
            else
            {
                this.deshabilitarOpciones();
            }

        }

        /// <summary>
        /// Se selecciona otro recap de la lista de recaps.
        /// </summary>
        private void dgvRecaps_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitar.Enabled = dgvRecaps.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Se selecciona otro cliente.
        /// </summary>
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCliente.SelectedItem != null)
            {
                Cliente cliente = (Cliente)cboCliente.SelectedItem;

                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
            }

        }

        /// <summary>
        /// Se escribe en el texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtCodigoBuscado.Text.Length >= 4;
        }

        /// <summary>
        /// Se selecciona el cuadro de texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscar;
        }

        /// <summary>
        /// Se selecciona la lista de sucursales.
        /// </summary>
        private void cboSucursal_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnGuardar;
        }

        /// <summary>
        /// Se selecciona la lista de clientes.
        /// </summary>
        private void cboCliente_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnGuardar;
        }

        /// <summary>
        /// Se selecciona el cuadro númerico del monto en colones.
        /// </summary>
        private void nudMontoColones_Enter(object sender, EventArgs e)
        {
            nudMontoColones.ResetText();
            this.AcceptButton = this.btnGuardar;
        }

        /// <summary>
        /// Se selecciona el cuadro númerico del monto en dolares.
        /// </summary>
        private void nudMontoDolares_Enter(object sender, EventArgs e)
        {
            nudMontoDolares.ResetText();
            this.AcceptButton = this.btnGuardar;
        }

        /// <summary>
        /// Se marca la opción de agregar una sucursal al manifiesto.
        /// </summary>
        private void rbSucursal_CheckedChanged(object sender, EventArgs e)
        {
            gbSucursal.Enabled = rbSucursal.Checked;
        }

        /// <summary>
        /// Se marca la opción de agregar un cliente al manifiesto.
        /// </summary>
        private void rbCliente_CheckedChanged(object sender, EventArgs e)
        {
            gbCliente.Enabled = rbCliente.Checked;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar los datos de un manifiesto.
        /// </summary>
        private void mostrarDatos(ManifiestoBoveda manifiesto)
        {
            _manifiesto = manifiesto;

            this.borrarDatos();

            bool estado = true;

            if (_manifiesto.Cajero != null)
            {
                bool cajero_valido = _manifiesto.Cajero.Equals(_cajero);
                bool dia_valido = _manifiesto.Fecha_procesamiento.Date == _fecha_actual;

                estado = _coordinador || (cajero_valido && dia_valido);

                txtCajero.Text = _manifiesto.Cajero.ToString();
                txtFechaProcesamiento.Text = ((DateTime)_manifiesto.Fecha_procesamiento).ToShortDateString();

                nudMontoColones.Value = _manifiesto.Monto_colones;
                nudMontoDolares.Value = _manifiesto.Monto_dolares;

                if (_manifiesto.Punto_venta != null)
                {
                    txtCliente.Text = _manifiesto.Punto_venta.Cliente.Nombre;
                    txtPuntoVenta.Text = _manifiesto.Punto_venta.Nombre;
                }
                else
                {
                    txtCliente.Text = string.Empty;
                    txtPuntoVenta.Text = string.Empty;
                }

                if (_manifiesto.Sucursal != null)
                    txtSucursal.Text = _manifiesto.Sucursal.Nombre;
                else
                    txtSucursal.Text = string.Empty;

            }

            // Validar si el coordinador puede modificar el manifiesto

            gbDatosManifiesto.Enabled = estado;
            btnGuardar.Enabled = estado;
            btnReiniciar.Enabled = estado;
        }

        /// <summary>
        /// Borrar los datos.
        /// </summary>
        private void borrarDatos()
        {
            nudMontoColones.Value = 0;
            nudMontoDolares.Value = 0;

            txtCajero.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtPuntoVenta.Text = string.Empty;
            txtSucursal.Text = string.Empty;
            txtFechaProcesamiento.Text = string.Empty;
        }

        /// <summary>
        /// Deshabilitar las ocpiones de guardado y reinicio.
        /// </summary>
        private void deshabilitarOpciones()
        {
            this.borrarDatos();

            dgvRecaps.DataSource = null;
            gbRecaps.Enabled = false;

            gbDatosManifiesto.Enabled = false;
            btnReiniciar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        #endregion Métodos Privados

        private void cboSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPuntoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}
