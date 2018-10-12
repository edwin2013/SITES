using BussinessLayer;
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

namespace GUILayer.Formularios.Níquel
{
    public partial class frmAdministracionCantidadTulas : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionCantidadTulas()
        {
            InitializeComponent();


            try
            {
                dgvCantidades.AutoGenerateColumns = false;
                dgvCantidades.DataSource = _mantenimiento.obtenerCantidades();
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
                frmMantenimientoCantidadTulas formulario = new frmMantenimientoCantidadTulas();
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

                if (Mensaje.mostrarMensajeConfirmacion("MensajeMaximasCantidadesEliminacion") == DialogResult.Yes)
                {
                    MaximasCantidades MaximasCantidades = (MaximasCantidades)dgvCantidades.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarCantidadTulas(MaximasCantidades);
                    dgvCantidades.Rows.Remove(dgvCantidades.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeMaximasCantidadesConfirmacionEliminacion");
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
        private void dgvMaximasCantidadess_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvMaximasCantidadess_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        /// <summary>
        /// Se elimina una fila en la lista.
        /// </summary>
        private void dgvMaximasCantidadess_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (dgvCantidades.Rows.Count == 0)
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

                if (dgvCantidades.SelectedRows.Count > 0)
                {
                    MaximasCantidades MaximasCantidades = (MaximasCantidades)dgvCantidades.SelectedRows[0].DataBoundItem;
                    frmMantenimientoCantidadTulas formulario = new frmMantenimientoCantidadTulas(MaximasCantidades);
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
            dgvCantidades.Refresh();
            dgvCantidades.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una cámara a la lista.
        /// </summary>
        public void agregarMaximasCantidades(MaximasCantidades MaximasCantidades)
        {
            BindingList<MaximasCantidades> MaximasCantidadess = (BindingList<MaximasCantidades>)dgvCantidades.DataSource;
            MaximasCantidadess.Add(MaximasCantidades);
        }

        #endregion Métodos Públicos
    }
}
