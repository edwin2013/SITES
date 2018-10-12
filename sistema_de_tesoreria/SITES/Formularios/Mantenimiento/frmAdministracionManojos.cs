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
using CommonObjects.Clases;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmAdministracionManojos : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionManojos()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de clientes

                dgvManojos.AutoGenerateColumns = false;
                dgvManojos.DataSource = _mantenimiento.listarManojo(String.Empty);
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
                    dgvManojos.DataSource = _mantenimiento.listarManojo(buscado);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de nuevo usuario.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoManojo formulario = new frmMantenimientoManojo();

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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeManojoEliminacion") == DialogResult.Yes)
                {
                    Manojo monojo = (Manojo)dgvManojos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarManojo(monojo);

                    dgvManojos.Rows.Remove(dgvManojos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeManojoConfirmacionEliminacion");
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
        private void dgvManojos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro cliente de la lista de clientes.
        /// </summary>
        private void dgvManojos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManojos.SelectedRows.Count > 0)
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
                if (dgvManojos.SelectedRows.Count > 0)
                {
                    Manojo monojo = (Manojo)dgvManojos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoManojo formulario = new frmMantenimientoManojo(monojo);

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
            dgvManojos.Refresh();
            dgvManojos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un cliente a la lista.
        /// </summary>
        public void agregarManojo(Manojo monojo)
        {
            BindingList<Manojo> clientes = (BindingList<Manojo>)dgvManojos.DataSource;

            clientes.Add(monojo);
        }

        #endregion Métodos Públicos
    }
}
