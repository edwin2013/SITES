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

namespace GUILayer.Formularios.Blindados
{
    public partial class frmAdministracionTipoFallas : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionTipoFallas(Colaborador c)
        {
            InitializeComponent();


            try
            {
                dgvTipoFallas.AutoGenerateColumns = false;
                dgvTipoFallas.DataSource = _mantenimiento.listarTipoFallasBlindadoss();
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
                frmMantenimientoTipoFallas formulario = new frmMantenimientoTipoFallas();
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

                if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoFallasBlindadosEliminacion") == DialogResult.Yes)
                {
                    TipoFallasBlindados TipoFallasBlindados = (TipoFallasBlindados)dgvTipoFallas.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarTipoFallasBlindados(TipoFallasBlindados);
                    dgvTipoFallas.Rows.Remove(dgvTipoFallas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeTipoFallasBlindadosConfirmacionEliminacion");
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
        private void dgvTipoFallas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvTipoFallas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        /// <summary>
        /// Se elimina una fila en la lista.
        /// </summary>
        private void dgvTipoFallas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (dgvTipoFallas.Rows.Count == 0)
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

                if (dgvTipoFallas.SelectedRows.Count > 0)
                {
                    TipoFallasBlindados TipoFallasBlindados = (TipoFallasBlindados)dgvTipoFallas.SelectedRows[0].DataBoundItem;
                    frmMantenimientoTipoFallas formulario = new frmMantenimientoTipoFallas(TipoFallasBlindados);
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
            dgvTipoFallas.Refresh();
            dgvTipoFallas.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una cámara a la lista.
        /// </summary>
        public void agregarTipoFallasBlindados(TipoFallasBlindados TipoFallasBlindados)
        {
            BindingList<TipoFallasBlindados> TipoFallasBlindadoss = (BindingList<TipoFallasBlindados>)dgvTipoFallas.DataSource;
            TipoFallasBlindadoss.Add(TipoFallasBlindados);
        }

        #endregion Métodos Públicos
    }
}
