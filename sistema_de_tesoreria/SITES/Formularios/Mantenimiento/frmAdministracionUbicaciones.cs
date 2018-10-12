//
//  @ Project : 
//  @ File Name : frmAdministracionUbicaciones.cs
//  @ Date : 30/04/2011
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

    public partial class frmAdministracionUbicaciones : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionUbicaciones()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de ubicaciones

                dgvUbicaciones.AutoGenerateColumns = false;
                dgvUbicaciones.DataSource = _mantenimiento.listarUbicaciones();
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
        /// Clic en el botón de agregar ubicación.
        /// </summary>
        private void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoUbicaciones formulario = new frmMantenimientoUbicaciones();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar ubicación.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar ubicación.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeUbicacionEliminacion") == DialogResult.Yes)
                {
                    Ubicacion ubicacion = (Ubicacion)dgvUbicaciones.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarUbicacion(ubicacion);

                    dgvUbicaciones.Rows.Remove(dgvUbicaciones.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeUbicacionConfirmacionEliminacion");
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
        /// Doble clic en la lista de ubicaciones.
        /// </summary>
        private void dgvUbicaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otra ubicación de la lista de ubicaciones.
        /// </summary>
        private void dgvUbicaciones_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvUbicaciones.SelectedRows.Count > 0)
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
                if (dgvUbicaciones.SelectedRows.Count > 0)
                {
                    Ubicacion ubicacion = (Ubicacion)dgvUbicaciones.SelectedRows[0].DataBoundItem;
                    frmMantenimientoUbicaciones formulario = new frmMantenimientoUbicaciones(ubicacion);

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
        /// Actualizar las lista de ubicaciones.
        /// </summary>
        public void actualizarLista()
        {
            dgvUbicaciones.Refresh();
            dgvUbicaciones.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una ubicación a la lista.
        /// </summary>
        public void agregarUbicacion(Ubicacion ubicacion)
        {
            BindingList<Ubicacion> ubicaciones = (BindingList<Ubicacion>)dgvUbicaciones.DataSource;

            ubicaciones.Add(ubicacion);
        }

        #endregion Métodos Públicos

    }

}
