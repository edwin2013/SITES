using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmListaRecapPreliminar : Form
    {
       #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = null; 

        #endregion Atributos

        #region Constructor

        public frmListaRecapPreliminar(Colaborador usuario)
        {
            InitializeComponent();
            _usuario = usuario; 


            try
            {
                dgvRecaps.AutoGenerateColumns = false;
               // dgvRecaps.DataSource = _mantenimiento.listarRecaptPreliminars();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de nueva cámara.
        /// </summary>
        private void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                frmGenerarRecaptPreliminar formulario = new frmGenerarRecaptPreliminar(_usuario);
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

                if (Mensaje.mostrarMensajeConfirmacion("MensajeRecaptPreliminarEliminacion") == DialogResult.Yes)
                {
                    RecaptPreliminar RecaptPreliminar = (RecaptPreliminar)dgvRecaps.SelectedRows[0].DataBoundItem;

                   // _mantenimiento.eliminarRecaptPreliminar(RecaptPreliminar);
                    dgvRecaps.Rows.Remove(dgvRecaps.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeRecaptPreliminarConfirmacionEliminacion");
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
        /// Doble clic en la lista de cámaras.
        /// </summary>
        private void dgvRecaps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvRecaps_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        /// <summary>
        /// Se elimina una fila en la lista.
        /// </summary>
        private void dgvRecaps_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (dgvRecaps.Rows.Count == 0)
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

                if (dgvRecaps.SelectedRows.Count > 0)
                {
                    RecaptPreliminar RecaptPreliminar = (RecaptPreliminar)dgvRecaps.SelectedRows[0].DataBoundItem;
                    frmGenerarRecaptPreliminar formulario = new frmGenerarRecaptPreliminar(_usuario, RecaptPreliminar);
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
        /// Actualizar las lista de cámaras.
        /// </summary>
        public void actualizarLista()
        {
            dgvRecaps.Refresh();
            dgvRecaps.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una cámara a la lista.
        /// </summary>
        public void agregarRecaptPreliminar(RecaptPreliminar RecaptPreliminar)
        {
            BindingList<RecaptPreliminar> RecaptPreliminars = (BindingList<RecaptPreliminar>)dgvRecaps.DataSource;
            RecaptPreliminars.Add(RecaptPreliminar);
        }

        #endregion Métodos Públicos

        private void btnModificar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
