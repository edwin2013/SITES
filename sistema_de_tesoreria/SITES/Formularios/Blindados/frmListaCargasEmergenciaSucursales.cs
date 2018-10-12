using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using BussinessLayer;
using CommonObjects.Clases;
using CommonObjects;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmListaCargasEmergenciaSucursales : Form
    {
         #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private Colaborador _colaborador = null;

        #endregion Atributos

        #region Constructor

        public frmListaCargasEmergenciaSucursales(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

            try
            {
                dgvCargasEmergencia.AutoGenerateColumns = false;

                this.listarCargas();
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
                frmModificionCargasEmergenciaSucursales formulario = new frmModificionCargasEmergenciaSucursales();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar una carga de emergencia.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar una carga de emergencia.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaEmergenciaATMEliminacion") == DialogResult.Yes)
                {
                    CargaEmergenciaSucursal carga = (CargaEmergenciaSucursal)dgvCargasEmergencia.SelectedRows[0].DataBoundItem;

                    _coordinacion.eliminarCargaEmergenciaSucursal(carga);

                    dgvCargasEmergencia.Rows.Remove(dgvCargasEmergencia.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCargaEmergenciaATMConfirmacionEliminacion");
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
        private void dgvCargasEmergencia_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargasEmergencia.SelectedRows.Count > 0)
            {
                CargaEmergenciaSucursal carga = (CargaEmergenciaSucursal)dgvCargasEmergencia.SelectedRows[0].DataBoundItem;

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
        /// Doble clic en la lista de cargas de emergencia.
        /// </summary>
        private void dgvCargasEmergencia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación de la carga de emergencia.
        /// </summary>
        private void mostrarVentanaModificacion()
        {

            try
            {
                CargaEmergenciaSucursal carga = (CargaEmergenciaSucursal)dgvCargasEmergencia.SelectedRows[0].DataBoundItem;

                if (carga.Descargada) return;

                frmModificionCargasEmergenciaSucursales formulario = new frmModificionCargasEmergenciaSucursales(carga);

                formulario.ShowDialog(this);

                dgvCargasEmergencia.Refresh();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Actualizar la lista de cargas de emergencia.
        /// </summary>
        private void listarCargas()
        {

            try
            {
                DateTime fecha = dtpFecha.Value;

                dgvCargasEmergencia.DataSource = _coordinacion.listarCargasEmergenciaSucursales(fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar las lista de cargas de emergencia.
        /// </summary>
        public void actualizarLista()
        {
            dgvCargasEmergencia.Refresh();
            dgvCargasEmergencia.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una carga de emergencia a la lista.
        /// </summary>
        public void agregarCargaEmergenciaATM(CargaEmergenciaSucursal carga)
        {
            BindingList<CargaEmergenciaSucursal> cargas = (BindingList<CargaEmergenciaSucursal>)dgvCargasEmergencia.DataSource;

            cargas.Add(carga);
        }

        #endregion Métodos Privados
    }
}
