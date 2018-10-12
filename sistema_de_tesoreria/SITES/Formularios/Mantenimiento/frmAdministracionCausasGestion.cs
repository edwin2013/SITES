//
//  @ Project : 
//  @ File Name : frmAdministracionCausasGestion.cs
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

    public partial class frmAdministracionCausasGestion : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionCausasGestion()
        {
            InitializeComponent();

            try
            {
                dgvCausasGestion.AutoGenerateColumns = false;
                dgvCausasGestion.DataSource = _mantenimiento.listarCausasGestion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de nueva causa de gestión.
        /// </summary>
        private void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoCausasGestion formulario = new frmMantenimientoCausasGestion();
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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeCausaGestionEliminacion") == DialogResult.Yes)
                {
                    CausaGestion causa = (CausaGestion)dgvCausasGestion.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarCausaGestion(causa);
                    dgvCausasGestion.Rows.Remove(dgvCausasGestion.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCausaGestionConfirmacionEliminacion");
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
        /// Doble clic en la lista de causas de gestiones.
        /// </summary>
        private void dgvCausasGestion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvCausasGestion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        /// <summary>
        /// Se elimina una fila en la lista.
        /// </summary>
        private void dgvCausasGestion_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (dgvCausasGestion.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }

        /// <summary>
        /// Se da formato a las celdas de la lista de causas.
        /// </summary>
        private void dgvCausasGestion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == Causante.Index)
            {
                DataGridViewRow fila = dgvCausasGestion.Rows[e.RowIndex];
                CausaGestion causa = (CausaGestion)fila.DataBoundItem;

                fila.Cells[Causante.Index].Value = Enum.GetName(typeof(Causantes), causa.Causante);
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

                if (dgvCausasGestion.SelectedRows.Count > 0)
                {
                    CausaGestion causa = (CausaGestion)dgvCausasGestion.SelectedRows[0].DataBoundItem;

                    frmMantenimientoCausasGestion formulario = new frmMantenimientoCausasGestion(causa);
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
        /// Actualizar las lista de causas de las gestiones.
        /// </summary>
        public void actualizarLista()
        {
            dgvCausasGestion.Refresh();
            dgvCausasGestion.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un causa de gestión a la lista.
        /// </summary>
        public void agregarCausaGestion(CausaGestion causa)
        {
            BindingList<CausaGestion> causas = (BindingList<CausaGestion>)dgvCausasGestion.DataSource;
            causas.Add(causa);
            dgvCausasGestion.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
