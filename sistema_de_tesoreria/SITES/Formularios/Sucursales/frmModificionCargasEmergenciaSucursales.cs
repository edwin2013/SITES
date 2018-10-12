using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using LibreriaMensajes;
using BussinessLayer;
using CommonObjects;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmModificionCargasEmergenciaSucursales : Form
    {
         #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CargaEmergenciaSucursal _carga = null;

        #endregion Atributos

        #region Constructor

        public frmModificionCargasEmergenciaSucursales()
        {
            InitializeComponent();

            try
            {
                this.cargarDatos();

                dgvEmergenciasAsignadas.DataSource = new BindingList<CargaSucursal>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public frmModificionCargasEmergenciaSucursales(CargaEmergenciaSucursal carga)
        {
            InitializeComponent();

            _carga = carga;

            try
            {
                this.cargarDatos();

                dgvEmergenciasAsignadas.DataSource = carga.Emergencias;

                dtpFechaCarga.Value = carga.Fecha;
                dtpFechaCarga.Enabled = false;

                cboATM.Text = carga.Sucursal.ToString();
                cboATM.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Cargar los datos de las listas.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                dgvEmergenciasPendientes.AutoGenerateColumns = false;
                dgvEmergenciasAsignadas.AutoGenerateColumns = false;

                cboATM.ListaMostrada = _mantenimiento.listarSucursalesRecientes();

                this.actualizarlista();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar la lista de emergenciar pendientes.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                this.actualizarlista();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de desasignar todas las emergencias.
        /// </summary>
        private void btnDesasignarTodas_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow fila in dgvEmergenciasAsignadas.Rows)
                this.desasignarEmergencia(fila);

        }

        /// <summary>
        /// Clic en el botón de desasignar una emergencia.
        /// </summary>
        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            this.desasignarEmergencia(dgvEmergenciasAsignadas.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de asignar una emergencia.
        /// </summary>
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            this.asignarEmergencia(dgvEmergenciasPendientes.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboATM.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorCargaEmergenciaSucursalDatosRegistro");
                return;
            }

            try
            {
                frmListaCargasEmergenciaSucursales padre = (frmListaCargasEmergenciaSucursales)this.Owner;

                Sucursal atm = (Sucursal)cboATM.SelectedItem;
                DateTime fecha = dtpFechaCarga.Value;
               

                BindingList<CargaSucursal> emergencias = (BindingList<CargaSucursal>)dgvEmergenciasAsignadas.DataSource;



                // Verificar si la carga de emergencia ya está registrada

                if (_carga == null)
                {
                    // Agregar los datos de la carga de emergencia

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaEmergenciaATMRegistro") == DialogResult.Yes)
                    {
                        CargaEmergenciaSucursal nueva = new CargaEmergenciaSucursal(sucursal: atm, fecha: fecha);

                        nueva.Emergencias = emergencias;

                        _coordinacion.agregarCargaEmergenciaSucursal(ref nueva);

                        nueva.reasignarEmergencias();

                        padre.agregarCargaEmergenciaATM(nueva);
                        Mensaje.mostrarMensaje("MensajeCargaEmergenciaATMConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la carga de emergencia

                    CargaEmergenciaSucursal copia = new CargaEmergenciaSucursal(id: _carga.ID, sucursal: atm, fecha: fecha);

                    copia.Emergencias = emergencias;

                    _coordinacion.actualizarCargaEmergenciaSucursal(copia);

                    _carga.Emergencias = emergencias;

                    _carga.reasignarEmergencias();

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeCargaEmergenciaATMConfirmacionActualizacion");
                    this.Close();
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
        /// Doble clic en la lista de emergencias pendientes.
        /// </summary>
        private void dgvEmergenciasPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.asignarEmergencia(dgvEmergenciasPendientes.SelectedRows[0]);
        }

        /// <summary>
        /// Se selecciona una emergencia de la lista de emergencias pendientes.
        /// </summary>
        private void dgvEmergenciasPendientes_SelectionChanged(object sender, EventArgs e)
        {
            btnAsignar.Enabled = dgvEmergenciasPendientes.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Doble clic en la lista de emergencias asignadas.
        /// </summary>
        private void dgvEmergenciasAsignadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.desasignarEmergencia(dgvEmergenciasAsignadas.SelectedRows[0]);
        }

        /// <summary>
        /// Se selecciona una emergencia de la lista de emergencias asignadas.
        /// </summary>
        private void dgvEmergenciasAsignadas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvEmergenciasAsignadas.SelectedRows.Count > 0)
            {
                btnDesasignar.Enabled = true;
                btnDesasignarTodas.Enabled = true;
            }
            else
            {
                btnDesasignar.Enabled = false;
                btnDesasignarTodas.Enabled = false;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Desasignar una emergencia de la carga.
        /// </summary>
        private void desasignarEmergencia(DataGridViewRow fila)
        {
            BindingList<CargaSucursal> emergencias_pendientes = (BindingList<CargaSucursal>)dgvEmergenciasPendientes.DataSource;
            BindingList<CargaSucursal> emergencias_asignadas = (BindingList<CargaSucursal>)dgvEmergenciasAsignadas.DataSource;

            CargaSucursal emergencia = (CargaSucursal)fila.DataBoundItem;

            emergencias_asignadas.Remove(emergencia);
            emergencias_pendientes.Add(emergencia);
        }

        /// <summary>
        /// Asignar una emergencia a la carga.
        /// </summary>
        private void asignarEmergencia(DataGridViewRow fila)
        {
            BindingList<CargaSucursal> emergencias_pendientes = (BindingList<CargaSucursal>)dgvEmergenciasPendientes.DataSource;
            BindingList<CargaSucursal> emergencias_asignadas = (BindingList<CargaSucursal>)dgvEmergenciasAsignadas.DataSource;

            CargaSucursal emergencia = (CargaSucursal)fila.DataBoundItem;

            emergencias_pendientes.Remove(emergencia);
            emergencias_asignadas.Add(emergencia);
        }

        /// <summary>
        /// Actualizar la lista de emergencias pendientes.
        /// </summary>
        private void actualizarlista()
        {

            try
            {
                DateTime fecha = dtpFechaEmergenciasPendientes.Value;

                dgvEmergenciasPendientes.DataSource = _coordinacion.listarCargasSucursalesEmergenciasNoUtilizadas(fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados
    }
}
