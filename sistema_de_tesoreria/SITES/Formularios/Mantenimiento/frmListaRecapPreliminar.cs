using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmListaRecapPreliminar : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmListaRecapPreliminar()
        {
            InitializeComponent();


            try
            {
                dgvRecaps.AutoGenerateColumns = false;
                dgvRecaps.DataSource = _mantenimiento.listarCamaras();
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
                frmMantenimientoCamaras formulario = new frmMantenimientoCamaras();
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

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCamaraEliminacion") == DialogResult.Yes)
                {
                    Camara camara = (Camara)dgvRecaps.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarCamara(camara);
                    dgvRecaps.Rows.Remove(dgvRecaps.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCamaraConfirmacionEliminacion");
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
        private void dgvCamaras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvCamaras_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        /// <summary>
        /// Se elimina una fila en la lista.
        /// </summary>
        private void dgvCamaras_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (dgvRecaps.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }

        /// <summary>
        /// Se da formato a las celdas de la lista de cámaras.
        /// </summary>
        private void dgvCamaras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == Area.Index)
            {
                DataGridViewRow fila = dgvRecaps.Rows[e.RowIndex];
                Camara camara = (Camara)fila.DataBoundItem;

                fila.Cells[Area.Index].Value = Enum.GetName(typeof(Areas), camara.Area);
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
                    Camara camara = (Camara)dgvRecaps.SelectedRows[0].DataBoundItem;
                    frmMantenimientoCamaras formulario = new frmMantenimientoCamaras(camara);
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
        public void agregarCamara(Camara camara)
        {
            BindingList<Camara> camaras = (BindingList<Camara>)dgvRecaps.DataSource;
            camaras.Add(camara);
        }

        #endregion Métodos Públicos
    }
}
