//
//  @ Project : 
//  @ File Name : frmInclusionSucursales.cs
//  @ Date : 26/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace ImpresionManifiestos
{

    public partial class frmInclusionSucursales : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Cliente _cliente = null;

        #endregion Atributos

        #region Constructor

        public frmInclusionSucursales(ref Cliente cliente)
        {
            InitializeComponent();

            _cliente = cliente;

            txtCliente.Text = _cliente.Nombre;

            try
            {
                //_cliente.Sucursales.Clear();

                //_mantenimiento.obtenerSucursalesCliente(ref _cliente);

                //dgvSucursales.AutoGenerateColumns = false;
                //dgvSucursales.DataSource = _cliente.Sucursales;
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de agregar sucursal.
        /// </summary>
        private void btnAgregarSucursal_Click(object sender, EventArgs e)
        {
            if (txtSucursal.Text.Equals(string.Empty)) return;

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeClienteSucursalRegistro") == DialogResult.Yes)
                {
                    string nombre = txtSucursal.Text;

                  //  Sucursal sucursal = new Sucursal(nombre, _cliente);

                    //_mantenimiento.agregarSucursal(ref sucursal);

                    //BindingList<Sucursal> sucursales = (BindingList<Sucursal>)dgvSucursales.DataSource;

                    //sucursales.Add(sucursal);

                    //dgvSucursales.Refresh();

                    Mensaje.mostrarMensaje("MensajeClienteSucursalConfirmacionRegistro");
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
