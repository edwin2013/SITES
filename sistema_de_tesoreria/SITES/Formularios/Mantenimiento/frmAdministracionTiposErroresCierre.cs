//
//  @ Project : 
//  @ File Name : frmAdministracionTiposErroresCierre.cs
//  @ Date : 05/02/2012
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

    public partial class frmAdministracionTiposErroresCierre : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionTiposErroresCierre()
        {
            InitializeComponent();

            try
            {
                dgvTiposError.AutoGenerateColumns = false;
                dgvTiposError.DataSource = _mantenimiento.listarTiposErrores();
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
                frmMantenimientoTiposErroresCierre formulario = new frmMantenimientoTiposErroresCierre();

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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoErrorCierreEliminacion") == DialogResult.Yes)
                {
                    TipoErrorCierre tipo = (TipoErrorCierre)dgvTiposError.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarTipoError(tipo);

                    dgvTiposError.Rows.Remove(dgvTiposError.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeTipoErrorCierreConfirmacionEliminacion");
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
        /// Se selecciona una fila en la lista.
        /// </summary>
        private void dgvTiposError_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvTiposError.SelectedRows.Count > 0)
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
        public void mostarVentanaModificacion()
        {

            try
            {

                if (dgvTiposError.SelectedRows.Count > 0)
                {
                    TipoErrorCierre tipo = (TipoErrorCierre)dgvTiposError.SelectedRows[0].DataBoundItem;
                    frmMantenimientoTiposErroresCierre formulario = new frmMantenimientoTiposErroresCierre(tipo);

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
        /// Actualizar las lista de tipos de error.
        /// </summary>
        public void actualizarLista()
        {
            dgvTiposError.Refresh();
            dgvTiposError.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un tipo de error a la lista.
        /// </summary>
        public void agregarTipoError(TipoErrorCierre tipo)
        {
            BindingList<TipoErrorCierre> tipos = (BindingList<TipoErrorCierre>)dgvTiposError.DataSource;

            tipos.Add(tipo);
        }

        #endregion Métodos Públicos

    }

}
