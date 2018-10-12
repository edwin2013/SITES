using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using GUILayer.Formularios.Mantenimiento;
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
    public partial class frmPromedioDescargasATM : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmPromedioDescargasATM(Colaborador colaborador)
        {
            InitializeComponent();


            try
            {
                dgvPromedioDescargas.AutoGenerateColumns = false; 
                dgvPromedioDescargas.DataSource = new BindingList<PromedioDescargaATM>();
                

                dgvPromedioDescargas.DataSource = _mantenimiento.listarPromedioDescargaATM();

                //dgvPromedioDescargas.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de nueva promedio.
        /// </summary>
        private void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoPromedioDescargasATM formulario = new frmMantenimientoPromedioDescargasATM();
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
                    PromedioDescargaATM promedio = (PromedioDescargaATM)dgvPromedioDescargas.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarPromedioDescargaATM(promedio);
                    dgvPromedioDescargas.Rows.Remove(dgvPromedioDescargas.SelectedRows[0]);
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
        /// Doble clic en la lista de promedios.
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

            if (dgvPromedioDescargas.Rows.Count == 0)
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

                if (dgvPromedioDescargas.SelectedRows.Count > 0)
                {
                    PromedioDescargaATM promedio = (PromedioDescargaATM)dgvPromedioDescargas.SelectedRows[0].DataBoundItem;
                    frmMantenimientoPromedioDescargasATM formulario = new frmMantenimientoPromedioDescargasATM(promedio);
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
        /// Actualizar las lista de promedios.
        /// </summary>
        public void actualizarLista()
        {
            dgvPromedioDescargas.Refresh();
            dgvPromedioDescargas.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una promedio a la lista.
        /// </summary>
        public void agregarPromedioDescargaATM(PromedioDescargaATM promedio)
        {
            BindingList<PromedioDescargaATM> promedios = (BindingList<PromedioDescargaATM>)dgvPromedioDescargas.DataSource;
            promedios.Add(promedio);
        }

        #endregion Métodos Públicos
    }
}
