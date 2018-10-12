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
    public partial class frmAdministracionTipoEquipo : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionTipoEquipo()
        {
            InitializeComponent();

            try
            {
                dgvTipoEquipos.AutoGenerateColumns = false;
                dgvTipoEquipos.DataSource = _mantenimiento.listarTipoEquipo();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de nuevo canal.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoTipoEquipo formulario = new frmMantenimientoTipoEquipo();

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
            this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoEquipoEliminacion") == DialogResult.Yes)
                {
                    TipoEquipo canal = (TipoEquipo)dgvTipoEquipos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarTipoEquipo(canal);

                    dgvTipoEquipos.Rows.Remove(dgvTipoEquipos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeTipoEquipoConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje(); ;
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
        /// Doble clic en la lista de canales.
        /// </summary>
        private void dgvTipoEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro canal de la lista.
        /// </summary>
        private void dgvTipoEquipos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvTipoEquipos.RowCount > 0)
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
        public void mostrarVentanaModificacion()
        {

            try
            {

                if (dgvTipoEquipos.SelectedRows.Count > 0)
                {
                    TipoEquipo canal = (TipoEquipo)dgvTipoEquipos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoTipoEquipo formulario = new frmMantenimientoTipoEquipo(canal);

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
        /// Actualizar la lista de canales.
        /// </summary>
        public void actualizarLista()
        {
            dgvTipoEquipos.Refresh();
            dgvTipoEquipos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un canal a la lista.
        /// </summary>
        public void agregarTipoEquipo(TipoEquipo canal)
        {
            BindingList<TipoEquipo> canales = (BindingList<TipoEquipo>)dgvTipoEquipos.DataSource;

            canales.Add(canal);
        }

        #endregion Métodos Públicos
    }
}
