//
//  @ Project : 
//  @ File Name : frmAdministracionCanales.cs
//  @ Date : 07/08/2011
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

    public partial class frmAdministracionCanales : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionCanales()
        {
            InitializeComponent();

            try
            {
                dgvCanales.AutoGenerateColumns = false;
                dgvCanales.DataSource = _mantenimiento.listarCanales();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de nuevo canal.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoCanales formulario = new frmMantenimientoCanales();

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
            this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeCanalEliminacion") == DialogResult.Yes)
                {
                    Canal canal = (Canal)dgvCanales.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarCanal(canal);

                    dgvCanales.Rows.Remove(dgvCanales.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCanalConfirmacionEliminacion");
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
        /// Doble clic en la lista de canales.
        /// </summary>
        private void dgvCanales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro canal de la lista.
        /// </summary>
        private void dgvCanales_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCanales.RowCount > 0)
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
        public void mostrarVentanaModificacion()
        {

            try
            {

                if (dgvCanales.SelectedRows.Count > 0)
                {
                    Canal canal = (Canal)dgvCanales.SelectedRows[0].DataBoundItem;
                    frmMantenimientoCanales formulario = new frmMantenimientoCanales(canal);

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
        /// Actualizar la lista de canales.
        /// </summary>
        public void actualizarLista()
        {
            dgvCanales.Refresh();
            dgvCanales.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un canal a la lista.
        /// </summary>
        public void agregarCanal(Canal canal)
        {
            BindingList<Canal> canales = (BindingList<Canal>)dgvCanales.DataSource;

            canales.Add(canal);
        }

        #endregion Métodos Públicos

    }

}
