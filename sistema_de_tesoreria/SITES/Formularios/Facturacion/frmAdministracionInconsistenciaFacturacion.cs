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
    public partial class frmAdministracionInconsistenciaFacturacion : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionInconsistenciaFacturacion()
        {
            InitializeComponent();


            try
            {
                dgvInconsistencias.AutoGenerateColumns = false;
                dgvInconsistencias.DataSource = _mantenimiento.listarInconsistenciaFacturacion();
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
                frmMantenimientoInconsistenciaFacturacion formulario = new frmMantenimientoInconsistenciaFacturacion();
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
                    InconsistenciaFacturacion camara = (InconsistenciaFacturacion)dgvInconsistencias.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarInconsistenciaFacturacion(camara);
                    dgvInconsistencias.Rows.Remove(dgvInconsistencias.SelectedRows[0]);
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

            if (dgvInconsistencias.Rows.Count == 0)
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

                if (dgvInconsistencias.SelectedRows.Count > 0)
                {
                    InconsistenciaFacturacion camara = (InconsistenciaFacturacion)dgvInconsistencias.SelectedRows[0].DataBoundItem;
                    frmMantenimientoInconsistenciaFacturacion formulario = new frmMantenimientoInconsistenciaFacturacion(camara);
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
            dgvInconsistencias.Refresh();
            dgvInconsistencias.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una cámara a la lista.
        /// </summary>
        public void agregarInconsistenciaFacturacion(InconsistenciaFacturacion camara)
        {
            BindingList<InconsistenciaFacturacion> camaras = (BindingList<InconsistenciaFacturacion>)dgvInconsistencias.DataSource;
            camaras.Add(camara);
        }

        #endregion Métodos Públicos

        
    }
}
