//
//  @ Project : 
//  @ File Name : frmAdministracionClientes.cs
//  @ Date : 01/06/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using GUILayer.Formularios.Mantenimiento;

namespace GUILayer
{
    public partial class frmAdministracionSucursales : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionSucursales()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de sucursales

                dgvSucursales.AutoGenerateColumns = false;
                dgvSucursales.DataSource = _mantenimiento.listarSucursales();
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
        /// Clic en el botón de agregar sucursal.
        /// </summary>
        private void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoSucursales formulario = new frmMantenimientoSucursales();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar sucursal.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar sucursal.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeSucursalEliminacion") == DialogResult.Yes)
                {
                    Sucursal sucursal = (Sucursal)dgvSucursales.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarSucursal(sucursal);

                    dgvSucursales.Rows.Remove(dgvSucursales.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeSucursalConfirmacionEliminacion");
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
        /// Doble clic en la lista de sucursales.
        /// </summary>
        private void dgvSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otra sucursal de la lista de sucursales.
        /// </summary>
        private void dgvSucursales_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvSucursales.SelectedRows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }

        /// <summary>
        /// Clic en el boton de Importar sucursales
        /// </summary>
        private void btnImportarSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                frmImportarSucursales formulario = new frmImportarSucursales();
                formulario.ShowDialog();

            }
            catch (Excepcion ex)
            { 
                ex.mostrarMensaje(); 
            }
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                if (dgvSucursales.SelectedRows.Count > 0)
                {
                    Sucursal sucursal = (Sucursal)dgvSucursales.SelectedRows[0].DataBoundItem;
                    frmMantenimientoSucursales formulario = new frmMantenimientoSucursales(sucursal);

                    formulario.ShowDialog(this);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar las lista de sucursales.
        /// </summary>
        public void actualizarLista()
        {
            dgvSucursales.Refresh();
            dgvSucursales.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una sucursal a la lista.
        /// </summary>
        public void agregarSucursal(Sucursal sucursal)
        {
            BindingList<Sucursal> sucursales = (BindingList<Sucursal>)dgvSucursales.DataSource;

            sucursales.Add(sucursal);
        }

        #endregion Métodos Públicos

        

        
     

    }

}
