//
//  @ Project : 
//  @ File Name : frmListaCargasEmergenciaFull.cs
//  @ Date : 01/03/2013
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

    public partial class frmListaCargasEmergenciaFull : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmListaCargasEmergenciaFull()
        {
            InitializeComponent();

            dgvCargasEmergenciaFull.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                this.listarCargas();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar una nueva carga de emergencia.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                frmModificacionCargaEmergenciaFull formulario = new frmModificacionCargaEmergenciaFull();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar una carga de emergencia de un ATM Full.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar una carga de emergencia de un ATM Full.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaEmergenciaATMFullEliminacion") == DialogResult.Yes)
                {
                    CargaEmergenciaATMFull carga = (CargaEmergenciaATMFull)dgvCargasEmergenciaFull.SelectedRows[0].DataBoundItem;

                    //_coordinacion.eliminarCargaEmergenciaATM(carga);

                    dgvCargasEmergenciaFull.Rows.Remove(dgvCargasEmergenciaFull.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCargaEmergenciaATMFullConfirmacionEliminacion");
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
        /// Se selecciona otra carga de emergencia de la lista de cargas.
        /// </summary>
        private void dgvCargasEmergenciaFull_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargasEmergenciaFull.SelectedRows.Count > 0)
            {
                CargaEmergenciaATMFull carga = (CargaEmergenciaATMFull)dgvCargasEmergenciaFull.SelectedRows[0].DataBoundItem;

                if (carga.Descargada)
                {
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }

            }
            else
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }

        }

        /// <summary>
        /// Doble clic en la lista de cargas de emergencia de ATM's Full.
        /// </summary>
        private void dgvCargasEmergenciaFull_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación de la carga de emergencia de un ATM Full.
        /// </summary>
        private void mostrarVentanaModificacion()
        {

            try
            {
                CargaEmergenciaATMFull carga = (CargaEmergenciaATMFull)dgvCargasEmergenciaFull.SelectedRows[0].DataBoundItem;

                if (carga.Descargada) return;

                frmModificacionCargaEmergenciaFull formulario = new frmModificacionCargaEmergenciaFull(carga);

                formulario.ShowDialog(this);

                dgvCargasEmergenciaFull.Refresh();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Actualizar la lista de cargas de emergencia de ATM's Full.
        /// </summary>
        private void listarCargas()
        {

            try
            {
                DateTime fecha = dtpFecha.Value;

                dgvCargasEmergenciaFull.DataSource = _coordinacion.listarCargasEmergenciaATMsFull(fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar las lista de cargas de emergencia de ATM's Full.
        /// </summary>
        public void actualizarLista()
        {
            dgvCargasEmergenciaFull.Refresh();
            dgvCargasEmergenciaFull.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una carga de emergencia de un ATM Full a la lista.
        /// </summary>
        public void agregarCargaEmergenciaATM(CargaEmergenciaATMFull carga)
        {
            BindingList<CargaEmergenciaATMFull> cargas = (BindingList<CargaEmergenciaATMFull>)dgvCargasEmergenciaFull.DataSource;

            cargas.Add(carga);
        }

        #endregion Métodos Privados

    }

}
