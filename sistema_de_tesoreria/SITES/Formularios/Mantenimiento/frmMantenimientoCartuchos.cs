//
//  @ Project : 
//  @ File Name : frmMantenimientoCartuchos.cs
//  @ Date : 31/07/2012
//  @ Author : César Mendoza
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace GUILayer
{

    public partial class frmMantenimientoCartuchos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Cartucho _cartucho = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoCartuchos()
        {
            InitializeComponent();

            try
            {
                cboDenominacion.ListaMostrada = _mantenimiento.listarDenominaciones();
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
                cboProveedor.ListaMostrada = _mantenimiento.listarProveedorCartucho(string.Empty);
                cboEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        public frmMantenimientoCartuchos(Cartucho cartucho)
        {
            InitializeComponent();

            _cartucho = cartucho;

            txtNumero.Text = _cartucho.Numero;
            cboTipo.SelectedIndex = (byte)_cartucho.Tipo;
            //cboEstado.SelectedItem = (EstadosCartuchos)_cartucho.Estado;
            cboEstado.SelectedIndex = (int)_cartucho.Estado;
            cboTransportadora.SelectedItem = (EmpresaTransporte)_cartucho.Transportadora;
            cboProveedor.SelectedItem = (ProveedorCartucho)_cartucho.Proveedor;

            try
            {
                cboProveedor.ListaMostrada = _mantenimiento.listarProveedorCartucho(string.Empty);
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

                cboProveedor.Text = _cartucho.Proveedor.ToString();
                cboTransportadora.Text = _cartucho.Transportadora.ToString();
            }
            catch (Exception ex)
            {
                this.Close();
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

            //if (cboDenominacion.SelectedItem == null || cboTipo.SelectedItem == null ||
            if (cboTransportadora.SelectedItem == null || cboTipo.SelectedItem == null ||
                txtNumero.Text.Equals(string.Empty)||cboProveedor.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorCartuchoDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionCartuchos padre = (frmAdministracionCartuchos)this.Owner;

                string numero = txtNumero.Text;
                TiposCartucho tipo = (TiposCartucho)cboTipo.SelectedIndex+2;
                ProveedorCartucho provedor = (ProveedorCartucho)cboProveedor.SelectedItem;
                EmpresaTransporte empresa = (EmpresaTransporte)cboTransportadora.SelectedItem;
                EstadosCartuchos estado = (EstadosCartuchos)cboEstado.SelectedIndex;

                // Verificar si el cartucho ya está registrado

                if (_cartucho == null)
                {
                    // Agregar los datos del cartucho

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeCartuchoRegistro") == DialogResult.Yes)
                    {
                        Cartucho nuevo = new Cartucho(numero, tipo: tipo, transportadora: empresa, estado: estado, provedor:provedor);

                        _mantenimiento.agregarCartucho(ref nuevo);

                        padre.agregarCartucho(nuevo);
                        Mensaje.mostrarMensaje("MensajeCartuchoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del cartucho

                    Cartucho copia = new Cartucho(numero, id: _cartucho.ID, tipo: tipo, transportadora: empresa, estado: estado, provedor:provedor);

                    _mantenimiento.actualizarCartucho(copia);

                    _cartucho.Numero = numero;
                    _cartucho.Tipo = tipo;
                    _cartucho.Estado = estado;
                    _cartucho.Transportadora = empresa;
                    _cartucho.Proveedor = provedor;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeCartuchoConfirmacionActualizacion");
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

        #endregion Eventos


    }

}
