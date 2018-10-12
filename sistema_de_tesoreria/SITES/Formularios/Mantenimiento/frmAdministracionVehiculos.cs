using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using LibreriaMensajes;
using GUILayer.Formularios.Mantenimiento;
using CommonObjects;

namespace GUILayer
{
    public partial class frmAdministracionVehiculos : Form
    {
        

          #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        
        #endregion Atributos

        #region Constructor

        public frmAdministracionVehiculos()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de clientes

                dgvVehiculos.AutoGenerateColumns = false;
                dgvVehiculos.DataSource = _mantenimiento.listarVehiculo(string.Empty);
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
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                string buscado = txtBuscar.Text;

                dgvVehiculos.DataSource = _mantenimiento.listarVehiculo(buscado);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de nuevo Vehiculo.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoVehiculo formulario = new frmMantenimientoVehiculo();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();      
        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeVehiculoEliminacion") == DialogResult.Yes)
                {
                    Vehiculo vehiculo = (Vehiculo)dgvVehiculos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarVehiculo(vehiculo);

                    dgvVehiculos.Rows.Remove(dgvVehiculos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeVehiculoConfirmacionEliminacion");
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
        /// Doble clic en la lista de clientes.
        /// </summary>
        private void dgvVehiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro cliente de la lista de clientes.
        /// </summary>
        private void dgvVehiculos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvVehiculos.SelectedRows.Count > 0)
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

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                if (dgvVehiculos.SelectedRows.Count > 0)
                {
                    Vehiculo vehiculo = (Vehiculo)dgvVehiculos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoVehiculo formulario = new frmMantenimientoVehiculo(vehiculo);

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
        /// Actualizar las lista de clientes.
        /// </summary>
        public void actualizarLista()
        {
            dgvVehiculos.Refresh();
            dgvVehiculos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un cliente a la lista.
        /// </summary>
        public void agregarCliente(Cliente cliente)
        {
            BindingList<Cliente> clientes = (BindingList<Cliente>)dgvVehiculos.DataSource;

            clientes.Add(cliente);
        }

        #endregion Métodos Públicos
    }
}
