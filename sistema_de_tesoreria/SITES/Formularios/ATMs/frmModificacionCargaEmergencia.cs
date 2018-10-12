//
//  @ Project : 
//  @ File Name : frmModificacionCargaEmergencia.cs
//  @ Date : 07/01/2013
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

    public partial class frmModificacionCargaEmergencia : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CargaEmergenciaATM _carga = null;

        #endregion Atributos

        #region Constructor

        public frmModificacionCargaEmergencia()
        {
            InitializeComponent();

            try
            {
                this.cargarDatos();

                dgvEmergenciasAsignadas.DataSource = new BindingList<CargaATM>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public frmModificacionCargaEmergencia(CargaEmergenciaATM carga)
        {
            InitializeComponent();

            _carga = carga;

            try
            {
                this.cargarDatos();

                dgvEmergenciasAsignadas.DataSource = carga.Emergencias;

                dtpFechaCarga.Value = carga.Fecha;
                dtpFechaCarga.Enabled = false;

                cboATM.Text = carga.ATM.ToString();
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

                cboATM.ListaMostrada = _mantenimiento.listarATMs();

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
                Excepcion.mostrarMensaje("ErrorCargaEmergenciaATMDatosRegistro");
                return;
            }

            try
            {
                frmListaCargasEmergencia padre = (frmListaCargasEmergencia)this.Owner;

                ATM atm = (ATM)cboATM.SelectedItem;
                DateTime fecha = dtpFechaCarga.Value;

                BindingList<CargaATM> emergencias = (BindingList<CargaATM>)dgvEmergenciasAsignadas.DataSource;

                // Verificar si la carga de emergencia ya está registrada

                if (_carga == null)
                {
                    // Agregar los datos de la carga de emergencia

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaEmergenciaATMRegistro") == DialogResult.Yes)
                    {
                        CargaEmergenciaATM nueva = new CargaEmergenciaATM(atm: atm, fecha: fecha);

                        nueva.Emergencias = emergencias;

                        _coordinacion.agregarCargaEmergenciaATM(ref nueva);

                        nueva.reasignarEmergencias();

                        padre.agregarCargaEmergenciaATM(nueva);

                        foreach (CargaATM c in nueva.Emergencias)
                        {
                            c.ATM = atm;
                            c.Transportadora =  new EmpresaTransporte(id: 5, nombre: "BAC");
                        }
                       
                        _coordinacion.guardarDatosATMINFO(nueva.Emergencias, "I");
                        
                        
                        Mensaje.mostrarMensaje("MensajeCargaEmergenciaATMConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la carga de emergencia

                    CargaEmergenciaATM copia = new CargaEmergenciaATM(id: _carga.ID, atm: atm, fecha: fecha);

                    copia.Emergencias = emergencias;

                    _coordinacion.actualizarCargaEmergenciaATM(copia);

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
            BindingList<CargaATM> emergencias_pendientes = (BindingList<CargaATM>)dgvEmergenciasPendientes.DataSource;
            BindingList<CargaATM> emergencias_asignadas = (BindingList<CargaATM>)dgvEmergenciasAsignadas.DataSource;

            CargaATM emergencia = (CargaATM)fila.DataBoundItem;

            emergencias_asignadas.Remove(emergencia);
            emergencias_pendientes.Add(emergencia);
        }

        /// <summary>
        /// Asignar una emergencia a la carga.
        /// </summary>
        private void asignarEmergencia(DataGridViewRow fila)
        {
            BindingList<CargaATM> emergencias_pendientes = (BindingList<CargaATM>)dgvEmergenciasPendientes.DataSource;
            BindingList<CargaATM> emergencias_asignadas = (BindingList<CargaATM>)dgvEmergenciasAsignadas.DataSource;

            CargaATM emergencia = (CargaATM)fila.DataBoundItem;

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

                dgvEmergenciasPendientes.DataSource = _coordinacion.listarCargasATMsEmergenciasNoUtilizadas(fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

    }

}
