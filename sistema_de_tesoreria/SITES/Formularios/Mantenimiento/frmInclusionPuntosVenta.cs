//
//  @ Project : 
//  @ File Name : frmInclusionPuntosVenta.cs
//  @ Date : 26/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmInclusionPuntosVenta : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Cliente _cliente = null;

        #endregion Atributos

        #region Constructor

        public frmInclusionPuntosVenta(ref Cliente cliente)
        {
            InitializeComponent();

            _cliente = cliente;

            txtCliente.Text = _cliente.Nombre;

            try
            {
                _cliente.Puntos_venta.Clear();

                _mantenimiento.obtenerPuntosVentaCliente(ref _cliente);

                dgvPuntosVenta.AutoGenerateColumns = false;
                dgvPuntosVenta.DataSource = _cliente.Puntos_venta;
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

                if (Mensaje.mostrarMensajeConfirmacion("MensajePuntoVentaRegistro") == DialogResult.Yes)
                {
                    string nombre = txtSucursal.Text;

                    PuntoVenta punto_venta = new PuntoVenta(nombre, _cliente);

                    _mantenimiento.agregarPuntoVenta(ref punto_venta);

                    BindingList<PuntoVenta> puntos_venta = (BindingList<PuntoVenta>)dgvPuntosVenta.DataSource;

                    puntos_venta.Add(punto_venta);

                    dgvPuntosVenta.Refresh();

                    Mensaje.mostrarMensaje("MensajePuntoVentaConfirmacionRegistro");
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
