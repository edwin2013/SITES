using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmAdministracionDispositivos : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionDispositivos()
        {
            InitializeComponent();

            try
            {
                dgvDispositivos.AutoGenerateColumns = false;
                dgvDispositivos.DataSource = _mantenimiento.listarDispositivos();
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
                frmMantenimientoDispositivos formulario = new frmMantenimientoDispositivos();

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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeDispositivoEliminacion") == DialogResult.Yes)
                {
                    Dispositivo canal = (Dispositivo)dgvDispositivos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarDispositivo(canal);

                    dgvDispositivos.Rows.Remove(dgvDispositivos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeDispositivoConfirmacionEliminacion");
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
        private void dgvDispositivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro canal de la lista.
        /// </summary>
        private void dgvDispositivos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDispositivos.RowCount > 0)
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

                if (dgvDispositivos.SelectedRows.Count > 0)
                {
                    Dispositivo canal = (Dispositivo)dgvDispositivos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoDispositivos formulario = new frmMantenimientoDispositivos(canal);

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
            dgvDispositivos.Refresh();
            dgvDispositivos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un canal a la lista.
        /// </summary>
        public void agregarDispositivo(Dispositivo canal)
        {
            BindingList<Dispositivo> canales = (BindingList<Dispositivo>)dgvDispositivos.DataSource;

            canales.Add(canal);
        }

        #endregion Métodos Públicos
    }
}
