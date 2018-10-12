using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects.Clases;
using CommonObjects;
using GUILayer.Formularios.Blindados;
using BussinessLayer;
using GUILayer.Formularios.Bancos;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmAsignacionCargasSucursales : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmAsignacionCargasSucursales(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                dgvCargas.AutoGenerateColumns = false;
                dgvCargasAsignadas.AutoGenerateColumns = false;
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA, Puestos.CajeroB);

                this.actualizarlista();

                dgvCargasBancoPendientes.AutoGenerateColumns = false;
                dgvCargasAsignadasBancos.AutoGenerateColumns = false;
                cboTransportadorasBanco.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
                cboCajeroBanco.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda,Puestos.CajeroB, Puestos.CajeroA);

                dgvCargasAsignadasBancos.DataSource = new BindingList<PedidoBancos>();

                this.actualizarlistaBancos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Sucursales

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
            this.mostrarVentanaModificacionBancos(dgvCargasAsignadas);
        }

        /// <summary>
        /// Clic en el botón de asignar carga.
        /// </summary>
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            BindingList<CargaSucursal> cargas_pendientes = (BindingList<CargaSucursal>)dgvCargas.DataSource;
            BindingList<CargaSucursal> cargas_asignadas = (BindingList<CargaSucursal>)dgvCargasAsignadas.DataSource;

            CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
            Colaborador cajero = (Colaborador)cboCajero.SelectedItem;

            carga.Cajero = cajero;

            _coordinacion.actualizarCargaSucursalColaborador(carga);

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
            BindingList<CargaSucursal> cargas = (BindingList<CargaSucursal>)dgvCargasAsignadas.DataSource;
            frmMontosCajeroCargasSucursales formulario = new frmMontosCajeroCargasSucursales(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar la cantidad de cartuchos por denominación.
        /// </summary>
        private void btnCartuchos_Click(object sender, EventArgs e)
        {
            BindingList<CargaSucursal> cargas = (BindingList<CargaSucursal>)dgvCargasAsignadas.DataSource;
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
                frmAutoAsignacionCargasBoveda formulario = new frmAutoAsignacionCargasBoveda();

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
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

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
                CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
                cboTransportadora.SelectedItem = (EmpresaTransporte)carga.Transportadora;

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
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

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
   
            }
            else
            {
                btnDesasignar.Enabled = false;
                btnDesasignarTodas.Enabled = false;
                btnModificarCargaAsignada.Enabled = false;
                btnMontos.Enabled = false;

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

                    dgvCargasAsignadas.DataSource = _coordinacion.listarCargasSucursalesPorColaborador(cajero, true);

                    pnlBotones.Enabled = true;
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }


        /// <summary>
        /// Asigna a una carga la transportadora seleccionada en ese momento. 
        /// </summary>
        private void cboTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpresaTransporte empresita = (EmpresaTransporte)cboTransportadora.SelectedItem;
            CargaSucursal carguita = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;

            carguita.Transportadora = empresita;

            _coordinacion.actualizarCargaSucursal(carguita);

        }


        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Desasignar la carga de un colaborador.
        /// </summary>
        private void desasignarCarga(DataGridViewRow fila)
        {
            BindingList<CargaSucursal> cargas_pendientes = (BindingList<CargaSucursal>)dgvCargas.DataSource;
            BindingList<CargaSucursal> cargas_asignadas = (BindingList<CargaSucursal>)dgvCargasAsignadas.DataSource;

            CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

            carga.Cajero = null;

            _coordinacion.actualizarCargaSucursalColaborador(carga);

            cargas_asignadas.Remove(carga);
            cargas_pendientes.Add(carga);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion(DataGridView tabla)
        {
            CargaSucursal carga = (CargaSucursal)tabla.SelectedRows[0].DataBoundItem;
            frmModificacionCargaSucursal formulario = new frmModificacionCargaSucursal(carga, _coordinador, false);

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
            decimal monto_euros = 0;

            foreach (DataGridViewRow fila in dgvCargasAsignadas.Rows)
            {
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;
                
                monto_colones += carga.Monto_carga_colones;
                monto_dolares += carga.Monto_carga_dolares;
                monto_euros += carga.Monto_carga_euros;
            }

            
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

                dgvCargas.DataSource = _coordinacion.listarCargasSucursalesSinAsignarCajero(null,null,fecha,null);
  
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void actualizarDatosCargaSucursal(DataGridView tabla)
        {
            CargaSucursal carga = (CargaSucursal)tabla.SelectedRows[0].DataBoundItem;

            carga.Transportadora = (EmpresaTransporte)cboTransportadora.SelectedItem;
            _coordinacion.actualizarCargaSucursal(carga);

            tabla.Refresh();
        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Autoasignar las cargas.
        /// </summary>
        public void autoasignarCargas(Dictionary<Colaborador, List<CargaSucursal>> cargas_asignadas)
        {

            try
            {

                foreach (Colaborador cajero in cargas_asignadas.Keys)
                {
                    List<CargaSucursal> cargas = cargas_asignadas[cajero];

                    foreach (CargaSucursal carga in cargas)
                    {
                        carga.Cajero = cajero;

                        _coordinacion.actualizarCargaSucursalColaborador(carga);
                    }

                }

                cboCajero.Text = string.Empty;

                dgvCargas.DataSource = new BindingList<CargaSucursal>();
                dgvCargasAsignadas.DataSource = null;
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Públicos


        #endregion Sucursales
        
        #region Bancos

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizarBancos_Click(object sender, EventArgs e)
        {

            try
            {
                this.actualizarlistaBancos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar carga.
        /// </summary>
        private void btnModificarBancos_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacionBancos(dgvCargasBancoPendientes);
        }

        /// <summary>
        /// Clic en el botón de modificar una carga asignada.
        /// </summary>
        private void btnModificarCargaAsignadaBancos_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacionBancos(dgvCargasAsignadasBancos);
        }

        /// <summary>
        /// Clic en el botón de asignar carga.
        /// </summary>
        private void btnAsignarBancos_Click(object sender, EventArgs e)
        {
            BindingList<PedidoBancos> cargas_pendientes = (BindingList<PedidoBancos>)dgvCargasBancoPendientes.DataSource;
            BindingList<PedidoBancos> cargas_asignadas = (BindingList<PedidoBancos>)dgvCargasAsignadasBancos.DataSource;

            PedidoBancos carga = (PedidoBancos)dgvCargasBancoPendientes.SelectedRows[0].DataBoundItem;
            Colaborador cajero = (Colaborador)cboCajeroBanco.SelectedItem;

            carga.Cajero = cajero;

            _coordinacion.actualizarPedidoBancoColaborador(carga);

            cargas_pendientes.Remove(carga);
            cargas_asignadas.Add(carga);
        }

        /// <summary>
        /// Clic en el botón de desasignar todas las cargas de un cajero.
        /// </summary>
        private void btnDesasignarTodasBancos_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow fila in dgvCargasAsignadasBancos.Rows)
                this.desasignarCargaBancos(fila);

        }

        /// <summary>
        /// Clic en el botón de desasignar carga.
        /// </summary>
        private void btnDesasignarBancos_Click(object sender, EventArgs e)
        {
            this.desasignarCargaBancos(dgvCargasAsignadasBancos.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación.
        /// </summary>
        private void btnMontosBancos_Click(object sender, EventArgs e)
        {
            BindingList<PedidoBancos> cargas = (BindingList<PedidoBancos>)dgvCargasAsignadas.DataSource;
            frmMontosCajerosPedidoBancos formulario = new frmMontosCajerosPedidoBancos(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar la cantidad de cartuchos por denominación.
        /// </summary>
        private void btnCartuchosBancos_Click(object sender, EventArgs e)
        {
            BindingList<PedidoBancos> cargas = (BindingList<PedidoBancos>)dgvCargasAsignadas.DataSource;
            frmCartuchosCarga formulario = new frmCartuchosCarga(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de autoasignar cargas.
        /// </summary>
        private void btnAutoAsignacionBancos_Click(object sender, EventArgs e)
        {
            try
            {
                frmAutoAsignacionCargasBoveda formulario = new frmAutoAsignacionCargasBoveda();

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
        private void btnSalirBancos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se agregan cargas a las lista de cargas no asignadas.
        /// </summary>
        private void dgvCargasBancos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();
            }

        }

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargasBancos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacionBancos(dgvCargas);
        }

        /// <summary>
        /// Se selecciona una carga de la lista de cargas pendientes.
        /// </summary>
        private void dgvCargasBancos_SelectionChanged(object sender, EventArgs e)
        {
            //btnAsignarBancos.Enabled = dgvCargasBancoPendientes.SelectedRows.Count > 0;

            if (dgvCargasBancoPendientes.Rows.Count > 0)
            {
                if (dgvCargasBancoPendientes.SelectedRows.Count > 0)
                {
                    PedidoBancos carga = (PedidoBancos)dgvCargasBancoPendientes.SelectedRows[0].DataBoundItem;
                    cboTransportadorasBanco.SelectedItem = (EmpresaTransporte)carga.Transportadora;

                    if (carga.Estado != EstadosPedidoBanco.Importacion & carga.Estado != EstadosPedidoBanco.Entrega_a_Boveda)
                    {
                        btnAsignarBancos.Enabled = true;
                    }
                    else
                    {
                        btnAsignarBancos.Enabled = false;
                    }

                    btnModificarCargaBanco.Enabled = true;
                }
            }
            else
            {
                btnAsignarBancos.Enabled = false;
                btnModificarCargaBanco.Enabled = false;
            }

        }


        /// <summary>
        /// Doble clic en la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadasBancos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacionBancos(dgvCargasAsignadasBancos);
        }

        /// <summary>
        /// Se agregan cargas a la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadasBancos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.calcularMontosCargasCajeroBancos();

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargasAsignadasBancos.Rows[e.RowIndex + contador];
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                fila.Cells[ATMCargaAsignada.Index].Value = carga.ToString();
            }

        }

        /// <summary>
        /// Se quitan cargas de la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadasBancos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.calcularMontosCargasCajeroBancos();
        }

        /// <summary>
        /// Se selecciona una carga de la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadasBancos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargasAsignadasBancos.SelectedRows.Count > 0)
            {
                btnDesasignarBancos.Enabled = true;
                btnDesasignarTodasBancos.Enabled = true;
                btnModificarCargaBancoAsignadas.Enabled = true;
                btnMontosBancos.Enabled = true;

            }
            else
            {
                btnDesasignarBancos.Enabled = false;
                btnDesasignarTodasBancos.Enabled = false;
                btnModificarCargaBancoAsignadas.Enabled = false;
                btnMontosBancos.Enabled = false;

            }

        }

        /// <summary>
        /// Se selecciona otro cajero de la lista de cajeros.
        /// </summary>
        private void cboCajeroBancos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCajeroBanco.SelectedItem == null)
            {
                pnlBotonesBancos.Enabled = false;
                dgvCargasAsignadasBancos.DataSource = false;
            }
            else
            {

                try
                {
                    Colaborador cajero = (Colaborador)cboCajeroBanco.SelectedItem;

                    dgvCargasAsignadasBancos.DataSource = _coordinacion.listarPedidoBancoPorColaborador(cajero, true);

                    pnlBotonesBancos.Enabled = true;
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }


        /// <summary>
        /// Asigna a una carga la transportadora seleccionada en ese momento. 
        /// </summary>
        private void cboTransportadoraBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpresaTransporte empresita = (EmpresaTransporte)cboTransportadorasBanco.SelectedItem;
            PedidoBancos carguita = (PedidoBancos)dgvCargasBancoPendientes.SelectedRows[0].DataBoundItem;

            carguita.Transportadora = empresita;

            _coordinacion.actualizarPedidoBanco(carguita);

        }


        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Desasignar la carga de un colaborador.
        /// </summary>
        private void desasignarCargaBancos(DataGridViewRow fila)
        {
            BindingList<PedidoBancos> cargas_pendientes = (BindingList<PedidoBancos>)dgvCargasBancoPendientes.DataSource;
            BindingList<PedidoBancos> cargas_asignadas = (BindingList<PedidoBancos>)dgvCargasAsignadasBancos.DataSource;

            PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

            carga.Cajero = null;

            _coordinacion.actualizarPedidoBancoColaborador(carga);

            cargas_asignadas.Remove(carga);
            cargas_pendientes.Add(carga);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacionBancos(DataGridView tabla)
        {
            PedidoBancos carga = (PedidoBancos)tabla.SelectedRows[0].DataBoundItem;
            frmModificacionPedidoBancos formulario = new frmModificacionPedidoBancos(carga, _coordinador, false);

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            tabla.Refresh();
        }

        /// <summary>
        /// Calcular los montos de las cargas asignadas a un cajero.
        /// </summary>
        private void calcularMontosCargasCajeroBancos()
        {
            decimal monto_colones = 0;
            decimal monto_dolares = 0;
            decimal monto_euros = 0;

            foreach (DataGridViewRow fila in dgvCargasAsignadas.Rows)
            {
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                monto_colones += carga.Monto_carga_colones;
                monto_dolares += carga.Monto_carga_dolares;
                monto_euros += carga.Monto_carga_euros;
            }


            txtMontoDolares.Text = monto_dolares.ToString("N2");

        }

        /// <summary>
        /// Actualizar la lista de cargas.
        /// </summary>
        private void actualizarlistaBancos()
        {

            try
            {
                DateTime fecha = dtpFecha.Value;

                dgvCargasBancoPendientes.DataSource = _coordinacion.listarPedidosBancoSinAsignarCajero(null, null, fecha, null);
              

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void actualizarDatosPedidoBancos(DataGridView tabla)
        {
            PedidoBancos carga = (PedidoBancos)tabla.SelectedRows[0].DataBoundItem;

            carga.Transportadora = (EmpresaTransporte)cboTransportadora.SelectedItem;
            _coordinacion.actualizarPedidoBanco(carga);

            tabla.Refresh();
        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Autoasignar las cargas.
        /// </summary>
        public void autoasignarCargasBancos(Dictionary<Colaborador, List<PedidoBancos>> cargas_asignadas)
        {

            try
            {

                foreach (Colaborador cajero in cargas_asignadas.Keys)
                {
                    List<PedidoBancos> cargas = cargas_asignadas[cajero];

                    foreach (PedidoBancos carga in cargas)
                    {
                        carga.Cajero = cajero;

                        _coordinacion.actualizarPedidoBancoColaborador(carga);
                    }

                }

                cboCajero.Text = string.Empty;

                dgvCargas.DataSource = new BindingList<CargaSucursal>();
                dgvCargasAsignadas.DataSource = null;
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Públicos


        #endregion Bancos



    }
}
