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

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmAdministracionNivelServicio : Form
    {
         #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionNivelServicio(Colaborador  colaborador)
        {
            InitializeComponent();


            try
            {
                dgvNivelServicio.DataSource = new BindingList<NivelServicio>();
                dgvNivelServicio.AutoGenerateColumns = false;
                
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
                frmMantenimientoNivelServicio formulario = new frmMantenimientoNivelServicio();
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
                    NivelServicio tipo_penalidad = (NivelServicio)dgvNivelServicio.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarNivelServicio(tipo_penalidad);
                    dgvNivelServicio.Rows.Remove(dgvNivelServicio.SelectedRows[0]);
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

            if (dgvNivelServicio.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }


        /// <summary>
        /// Actualizar la lista de niveles de Servicio
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvNivelServicio.DataSource = _mantenimiento.listarNivelesServicio(dtpFechaInicio.Value, dtpFechaFin.Value);
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

                if (dgvNivelServicio.SelectedRows.Count > 0)
                {
                    NivelServicio tipo_penalidad = (NivelServicio)dgvNivelServicio.SelectedRows[0].DataBoundItem;
                    frmMantenimientoNivelServicio formulario = new frmMantenimientoNivelServicio(tipo_penalidad);
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
            dgvNivelServicio.Refresh();
            dgvNivelServicio.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una cámara a la lista.
        /// </summary>
        public void agregarNivelServicio(NivelServicio tipo_penalidad)
        {
            BindingList<NivelServicio> tipo_penalidads = (BindingList<NivelServicio>)dgvNivelServicio.DataSource;
            tipo_penalidads.Add(tipo_penalidad);
        }

        #endregion Métodos Públicos

        
    }
}
