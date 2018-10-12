//
//  @ Project : 
//  @ File Name : frmCargasPendientes.cs
//  @ Date : 22/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmAsignacionCargas : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmAsignacionCargas(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                dgvCargas.AutoGenerateColumns = false;
                dgvCargasAsignadas.AutoGenerateColumns = false;

                cboCajero.ListaMostrada = _seguridad.listarColaboradores(string.Empty);

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
        /// Clic en el botón de actualizar.
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
        /// Clic en el botón de modificar carga.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion(dgvCargas);
        }

        /// <summary>
        /// Clic en el botón de modificar una carga asignada.
        /// </summary>
        private void btnModificarCargaAsignada_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion(dgvCargasAsignadas);
        }

        /// <summary>
        /// Clic en el botón de asignar carga.
        /// </summary>
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas_pendientes = (BindingList<CargaATM>)dgvCargas.DataSource;
            BindingList<CargaATM> cargas_asignadas = (BindingList<CargaATM>)dgvCargasAsignadas.DataSource;

            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
            Colaborador cajero = (Colaborador)cboCajero.SelectedItem;

            carga.Cajero = cajero;

            _coordinacion.actualizarCargaATMCajero(carga);

            cargas_pendientes.Remove(carga);
            cargas_asignadas.Add(carga);
        }

        /// <summary>
        /// Clic en el botón de desasignar todas las cargas de un cajero.
        /// </summary>
        private void btnDesasignarTodas_Click(object sender, EventArgs e)
        {

            foreach(DataGridViewRow fila in dgvCargasAsignadas.Rows)
                this.desasignarCarga(fila);

        }

        /// <summary>
        /// Clic en el botón de desasignar carga.
        /// </summary>
        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            this.desasignarCarga(dgvCargasAsignadas.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación.
        /// </summary>
        private void btnMontos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargasAsignadas.DataSource;
            frmMontosCajeroCargas formulario = new frmMontosCajeroCargas(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar la cantidad de cartuchos por denominación.
        /// </summary>
        private void btnCartuchos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargasAsignadas.DataSource;
            frmCartuchosCarga formulario = new frmCartuchosCarga(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de autoasignar cargas.
        /// </summary>
        private void btnAutoAsignacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmAutoAsignacionCargas formulario = new frmAutoAsignacionCargas();

                formulario.ShowDialog(this);
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
        /// Se agregan cargas a las lista de cargas no asignadas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();
            }

        }

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion(dgvCargas);
        }

        /// <summary>
        /// Se selecciona una carga de la lista de cargas pendientes.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                btnAsignar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnAsignar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }

        /// <summary>
        /// Doble clic en la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion(dgvCargasAsignadas);
        }

        /// <summary>
        /// Se agregan cargas a la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.calcularMontosCargasCajero();

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargasAsignadas.Rows[e.RowIndex + contador];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                fila.Cells[ATMCargaAsignada.Index].Value = carga.ToString();
            }

        }

        /// <summary>
        /// Se quitan cargas de la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.calcularMontosCargasCajero();
        }

        /// <summary>
        /// Se selecciona una carga de la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargasAsignadas.SelectedRows.Count > 0)
            {
                btnDesasignar.Enabled = true;
                btnDesasignarTodas.Enabled = true;
                btnModificarCargaAsignada.Enabled = true;
                btnMontos.Enabled = true;
                btnCartuchos.Enabled = true;
            }
            else
            {
                btnDesasignar.Enabled = false;
                btnDesasignarTodas.Enabled = false;
                btnModificarCargaAsignada.Enabled = false;
                btnMontos.Enabled = false;
                btnCartuchos.Enabled = false;
            }

        }

        /// <summary>
        /// Se selecciona otro cajero de la lista de cajeros.
        /// </summary>
        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCajero.SelectedItem == null)
            {
                pnlBotones.Enabled = false;
                dgvCargasAsignadas.DataSource = false;
            }
            else
            {

                try
                {
                    Colaborador cajero = (Colaborador)cboCajero.SelectedItem;

                    dgvCargasAsignadas.DataSource = _coordinacion.listarCargasATMsPorCajero(cajero, true);

                    pnlBotones.Enabled = true;
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Desasignar la carga de un colaborador.
        /// </summary>
        private void desasignarCarga(DataGridViewRow fila)
        {
            BindingList<CargaATM> cargas_pendientes = (BindingList<CargaATM>)dgvCargas.DataSource;
            BindingList<CargaATM> cargas_asignadas = (BindingList<CargaATM>)dgvCargasAsignadas.DataSource;

            CargaATM carga = (CargaATM)fila.DataBoundItem;

            carga.Cajero = null;

            _coordinacion.actualizarCargaATMCajero(carga);

            cargas_asignadas.Remove(carga);
            cargas_pendientes.Add(carga);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion(DataGridView tabla)
        {
            CargaATM carga = (CargaATM)tabla.SelectedRows[0].DataBoundItem;
            frmModificacionCarga formulario = new frmModificacionCarga(carga, _coordinador, false);

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            tabla.Refresh();
        }

        /// <summary>
        /// Calcular los montos de las cargas asignadas a un cajero.
        /// </summary>
        private void calcularMontosCargasCajero()
        {
            decimal monto_colones = 0;
            decimal monto_dolares = 0;

            foreach (DataGridViewRow fila in dgvCargasAsignadas.Rows)
            {
                CargaATM carga = (CargaATM)fila.DataBoundItem;
                
                monto_colones += carga.Monto_carga_colones;
                monto_dolares += carga.Monto_carga_dolares;
            }

            txtMontoColones.Text = monto_colones.ToString("N2");
            txtMontoDolares.Text = monto_dolares.ToString("N2");
        }

        /// <summary>
        /// Actualizar la lista de cargas.
        /// </summary>
        private void actualizarlista()
        {

            try
            {
                DateTime fecha = dtpFecha.Value;

                dgvCargas.DataSource = _coordinacion.listarCargasATMs(fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Autoasignar las cargas.
        /// </summary>
        public void autoasignarCargas(Dictionary<Colaborador, List<CargaATM>> cargas_asignadas)
        {

            try
            {

                foreach (Colaborador cajero in cargas_asignadas.Keys)
                {
                    List<CargaATM> cargas = cargas_asignadas[cajero];

                    foreach (CargaATM carga in cargas)
                    {
                        carga.Cajero = cajero;

                        _coordinacion.actualizarCargaATMCajero(carga);
                    }

                }

                cboCajero.Text = string.Empty;

                dgvCargas.DataSource = new BindingList<CargaATM>();
                dgvCargasAsignadas.DataSource = null;
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Públicos

    }

}
