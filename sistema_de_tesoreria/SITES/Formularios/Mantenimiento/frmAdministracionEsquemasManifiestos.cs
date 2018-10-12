//
//  @ Project : 
//  @ File Name : frmAdministracionEsquemasManifiestos.cs
//  @ Date : 03/07/2012
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

    public partial class frmAdministracionEsquemasManifiestos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionEsquemasManifiestos()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de esquemas

                dgvEsquemas.AutoGenerateColumns = false;
                dgvEsquemas.DataSource = _mantenimiento.listarEsquemasManifiestos();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de agregar esquema.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoEsquemasManifiestos formulario = new frmMantenimientoEsquemasManifiestos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar esquema.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar esquema.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeEsquemaManifiestoEliminacion") == DialogResult.Yes)
                {
                    EsquemaManifiesto esquema = (EsquemaManifiesto)dgvEsquemas.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarEsquemaManifiesto(esquema);

                    dgvEsquemas.Rows.Remove(dgvEsquemas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeEsquemaManifiestoConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
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
        /// Doble clic en la lista de esquemas.
        /// </summary>
        private void dgvEsquemas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro esquema.
        /// </summary>
        private void dgvEsquemas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvEsquemas.SelectedRows.Count > 0)
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
                EsquemaManifiesto esquema = (EsquemaManifiesto)dgvEsquemas.SelectedRows[0].DataBoundItem;
                frmMantenimientoEsquemasManifiestos formulario = new frmMantenimientoEsquemasManifiestos(esquema);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar los esquemas de la lista.
        /// </summary>
        public void actualizarLista()
        {
            dgvEsquemas.Refresh();
            dgvEsquemas.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un esquema a la lista.
        /// </summary>
        public void agregarEsquema(EsquemaManifiesto esquema)
        {
            BindingList<EsquemaManifiesto> esquemas = (BindingList<EsquemaManifiesto>)dgvEsquemas.DataSource;

            esquemas.Add(esquema);
            dgvEsquemas.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
