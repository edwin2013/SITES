//
//  @ Project : 
//  @ File Name : frmAdministracionTiposGestion.cs
//  @ Date : 18/08/2011
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

    public partial class frmAdministracionTiposGestion : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionTiposGestion()
        {
            InitializeComponent();

            try
            {
                dgvTiposGestion.AutoGenerateColumns = false;
                dgvTiposGestion.DataSource = _mantenimiento.listarTiposGestion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de nuevo tipo de gestión.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoTiposGestion formulario = new frmMantenimientoTiposGestion();
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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoGestionEliminacion") == DialogResult.Yes)
                {
                    TipoGestion tipo = (TipoGestion)dgvTiposGestion.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarTipoGestion(tipo);
                    dgvTiposGestion.Rows.Remove(dgvTiposGestion.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeTipoGestionConfirmacionEliminacion");
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
        /// Doble clic en la lista de tipos de gestión.
        /// </summary>
        private void dgvTiposGestion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvTiposGestion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        /// <summary>
        /// Se elimina una fila en la lista.
        /// </summary>
        private void dgvTiposGestion_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (dgvTiposGestion.Rows.Count == 0)
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

                if (dgvTiposGestion.SelectedRows.Count > 0)
                {
                    TipoGestion tipo = (TipoGestion)dgvTiposGestion.SelectedRows[0].DataBoundItem;

                    frmMantenimientoTiposGestion formulario = new frmMantenimientoTiposGestion(tipo);
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
        /// Actualizar las lista de tipos de gestión.
        /// </summary>
        public void actualizarLista()
        {
            dgvTiposGestion.Refresh();
            dgvTiposGestion.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un tipo de gestión a la lista.
        /// </summary>
        public void agregarTipoGestion(TipoGestion tipo)
        {
            BindingList<TipoGestion> tipos = (BindingList<TipoGestion>)dgvTiposGestion.DataSource;
            tipos.Add(tipo);
        }

        #endregion Métodos Públicos

    }

}
