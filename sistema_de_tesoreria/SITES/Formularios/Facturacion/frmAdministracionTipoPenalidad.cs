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

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmAdministracionTipoPenalidad : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionTipoPenalidad()
        {
            InitializeComponent();


            try
            {
                dgvTipoPenalidades.AutoGenerateColumns = false;
                dgvTipoPenalidades.DataSource = _mantenimiento.listarTipoPenalidades(string.Empty);
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
                frmMantenimientoTipoPenalidades formulario = new frmMantenimientoTipoPenalidades();
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

                if (Mensaje.mostrarMensajeConfirmacion("MensajeInconsistenciaFacturacionEliminacion") == DialogResult.Yes)
                {
                    TipoPenalidad tipo_penalidad = (TipoPenalidad)dgvTipoPenalidades.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarTipoPenalidad(tipo_penalidad);
                    dgvTipoPenalidades.Rows.Remove(dgvTipoPenalidades.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeInconsistenciaFacturacionConfirmacionEliminacion");
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
        private void dgvInconsistenciaFacturacions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvInconsistenciaFacturacions_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        /// <summary>
        /// Se elimina una fila en la lista.
        /// </summary>
        private void dgvInconsistenciaFacturacions_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (dgvTipoPenalidades.Rows.Count == 0)
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

                if (dgvTipoPenalidades.SelectedRows.Count > 0)
                {
                    TipoPenalidad tipo_penalidad = (TipoPenalidad)dgvTipoPenalidades.SelectedRows[0].DataBoundItem;
                    frmMantenimientoTipoPenalidades formulario = new frmMantenimientoTipoPenalidades(tipo_penalidad);
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
            dgvTipoPenalidades.Refresh();
            dgvTipoPenalidades.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una cámara a la lista.
        /// </summary>
        public void agregarTipoPenalidad(TipoPenalidad tipo_penalidad)
        {
            BindingList<TipoPenalidad> tipo_penalidads = (BindingList<TipoPenalidad>)dgvTipoPenalidades.DataSource;
            tipo_penalidads.Add(tipo_penalidad);
        }

        #endregion Métodos Públicos
    }
}
