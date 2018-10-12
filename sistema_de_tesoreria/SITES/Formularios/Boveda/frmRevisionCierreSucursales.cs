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
using BussinessLayer;
using CommonObjects;
using GUILayer.Formularios.Blindados;
using LibreriaReportesOffice;
using GUILayer.Formularios.Bancos;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmRevisionCierreSucursales : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private Colaborador _usuario = null;
        private CierreCargaSucursal _cierre = null;
        private CierreCargaBanco _cierre_banco = null;
        private CargaSucursal _carga = null;
        private PedidoBancos _carga_bancos = null;

        private Bolsa _bolsa = null;
        private BindingList<Bolsa> _bolsas = null;

        private bool _carga_mostrada = false;
        private bool _carga_mostrada_banco = false;

        private bool _coordinador = false;
        private bool _pendiente = false;
        private bool _pendiente_banco = false;

        private Formula _formula = null;

        private Color[] _colores = {Color.DarkOrchid,
                                    Color.DarkBlue,
                                    Color.Gold,
                                    Color.DarkGreen,
                                    Color.Orange,
                                    Color.Indigo,
                                    Color.DarkGray};
         
        private enum TiposFilaSucursal : byte
        {
            Cartucho = 0,
            MontoFull = 1,
            Rechazo = 2,
            TotalDescargaColones = 3,
            TotalDepositadoColones = 4,
            TotalDispensadoColones = 5,
            TotalCargaColones = 6,
            TotalDiferenciaColones = 7,
            TotalDescargaDolares = 8,
            TotalDepositadoDolares = 9,
            TotalDispensadoDolares = 10,
            TotalCargaDolares = 11,
            TotalDiferenciaDolares = 12
        }

        private enum TiposDiferenciaSucursal : byte
        {
            FaltanteRemanente = 0,
            SobranteRemanente = 1,
            FaltanteContadores = 2,
            SobranteContadores = 3,
            FaltanteDepositos = 4,
            SobranteDepositos = 5
        }

        #endregion Atributos

        #region Constructor

        public frmRevisionCierreSucursales(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            try
            {
               
                dgvListaCargasCierre.AutoGenerateColumns = false;
                dgvListaCargasBancos.AutoGenerateColumns = false;

                dgvCargas.AutoGenerateColumns = false;
                dgvCargasBanco.AutoGenerateColumns = false;

                dgvMontosCarga.AutoGenerateColumns = false;
                dgvMontosCargaBanco.AutoGenerateColumns = false;


                BindingList<ManifiestoPedidoBanco> manifiestos = null;

                dgvManifiestoBancos.AutoGenerateColumns = false;
                dgvManifiestoBancos.DataSource = manifiestos;



                BindingList<ManifiestoSucursalCarga> manifiestos_suc = null;

                dgvManifiestosSucursales.AutoGenerateColumns = false;
                dgvManifiestosSucursales.DataSource = manifiestos_suc;

     
                pnlDatosCarga.Enabled = true;
                pnlDatosCargaBanco.Enabled = true;


                gbCargasAsignadas.Enabled = true;
                gbDatosPedidoBancoAsignados.Enabled = true;
                
                tlpControl.Enabled = true;
                tlpControlBancos.Enabled = true;
                
                
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA,  Puestos.CajeroB);
                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.Coordinador);
                cboCamaraCierre.ListaMostrada = _mantenimiento.listarCamarasPorArea(Areas.Boveda);



                cboCajerosBancos.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA, Puestos.CajeroC);
                cboCoordinadorBancos.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.Coordinador);
                cboCamaraBancos.ListaMostrada = _mantenimiento.listarCamarasPorArea(Areas.Boveda);

                _coordinador = _usuario.Puestos.Contains(Puestos.Coordinador) || _usuario.Puestos.Contains(Puestos.Supervisor);

                _formula = _mantenimiento.obtenerFormula();

                //((Control)tpCargas).Enabled = true;
                //((Control)tpCierre).Enabled = true;

                if (_coordinador)
                {
                    cboCajero.Enabled = true;
                    cboCajerosBancos.Enabled = true;
                   
                }
                else
                {
                    cboCajero.Text = _usuario.ToString();
                    cboCajerosBancos.Text = _usuario.ToString();
                    this.verificarCierre();
                    this.verificarCierreBancos();
                }

            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor
        
        #region Sucursales

        #region Eventos

        #region Cierre

        /// <summary>
        /// Clic en el botón de iniciar cierre.
        /// </summary>
        private void btnIniciar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFechaCierre.Value;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;

                _cierre = new CierreCargaSucursal(cajero, fecha: fecha);

                _coordinacion.agregarCierreSucursal(ref _cierre);

                dgvCargas.DataSource = _cierre.Cargas;

                this.validarOpcionesCierre();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de terminar cierre.
        /// </summary>
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            frmValidacionCoordinador formulario = new frmValidacionCoordinador();

            if (formulario.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    _coordinacion.actualizarCierreSucursalTerminar(_cierre);

                    _cierre.Terminado = true;

                    this.validarOpcionesCierre();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Clic en el botón de actualizar la lista de cargas y descargas del cierre.
        /// </summary>
        private void btnActualizarListasCierre_Click(object sender, EventArgs e)
        {
            this.actualizarListasCierre();
        }

        /// <summary>
        /// Clic en el botón de guardar los datos del cierre.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Colaborador coordinador = cboCoordinador.SelectedItem == null ?
                    null : (Colaborador)cboCoordinador.SelectedItem;

                Camara camara = cboCamaraCierre.SelectedItem == null ?
                    null : (Camara)cboCamaraCierre.SelectedItem;

                _cierre.Coordinador = coordinador;
                _cierre.Camara = camara;

                _coordinacion.actualizarCierreSucursal(_cierre);
                
                this.validarDatosCierre();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se selecciona otro cajero para el cierre.
        /// </summary>
        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                this.verificarCierre();

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se selecciona otra fecha para el cierre.
        /// </summary>
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                this.verificarCierre();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

      

        #endregion Cierre

        #region Cargas


        /// <summary>
        /// Clic en el boton de mostrar manifiesto
        /// </summary>
        private void btnManifiesto_Click(object sender, EventArgs e)
        {
            try
            {
                _carga.Cajero = (Colaborador)cboCajero.SelectedItem;

                frmManifiestoGeneral formulario = new frmManifiestoGeneral(_carga);
                formulario.ShowDialog();
                formulario.mostrarDatosCargaSucursal();
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Clic en el botón de seleccionar cargas asignadas pendientes.
        /// </summary>
        private void btnCargasPendientes_Click(object sender, EventArgs e)
        {

            try
            {
                frmCargasPendientesSucursales formulario = new frmCargasPendientesSucursales(_cierre);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de devolver carga.
        /// </summary>
        private void btnDevolverCarga_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaATMDevolucion") == DialogResult.Yes)
                {
                    CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;

                    carga.Cierre = null;

                    _coordinacion.actualizarCargaSucursalCierreSucursal(carga);

                    dgvCargas.Rows.Remove(dgvCargas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCargaATMConfirmacionDevolucion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de seleccionar los manifiestos de una carga.
        /// </summary>
        private void btnSeleccionarManifiestosCarga_Click(object sender, EventArgs e)
        {
            CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;

            carga.Cajero = (Colaborador)cboCajero.SelectedItem;
            
             frmIngresoManifiestoSucursal formulario = new frmIngresoManifiestoSucursal(ref carga);
            
            formulario.limpiarDatosManifiesto();

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de verificar carga.
        /// </summary>
        private void btnRevisionCarga_Click(object sender, EventArgs e)
        {
            _carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;

            frmVerificacionPedidoSucursal formulario = new frmVerificacionPedidoSucursal(_carga);

            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
                this.validarOpcionesCarga();

                btnCargasPendientes.Enabled = _cierre.Cargas_listas;
            }

        }

       

        /// <summary>
        /// Se selecciona otra carga en la lista de cargas.
        /// </summary
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {
            cklbSeriesTulas.Items.Clear();
            if (dgvCargas.SelectedRows.Count > 0)
            {
                _carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
                
                this.mostrarDatosCargaSucursales();

            }
            else
            {
                _carga = null;
                this.limpiarDatosCarga();
            }

            this.validarOpcionesCarga();
        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary
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
        /// Se selecciona otro cartucho de la lista de cartuchos.
        /// </summary
        private void dgvMontosCarga_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvMontosCarga.SelectedCells.Count > 0)
            {
                DataGridViewCell celda = dgvMontosCarga.SelectedCells[0];
                CartuchoCargaSucursal cartucho = (CartuchoCargaSucursal)celda.OwningRow.DataBoundItem;
                CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
                Denominacion denominacion = cartucho.Denominacion;

                celda.Style.SelectionBackColor = _colores[(byte)denominacion.Id_imagen];
            
            }
           

        }

        /// <summary>
        /// Se cambia el número de cartucho de un cartucho.
        /// </summary
        private void dgvMontosCarga_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosCarga.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontosCarga.Rows[e.RowIndex];
                    DataGridViewCell celda = fila.Cells[e.ColumnIndex];

                    CartuchoCargaSucursal cartucho_carga = (CartuchoCargaSucursal)fila.DataBoundItem;

                    _coordinacion.actualizarCartuchoCargaSucursal(cartucho_carga);

                    this.validarOpcionesCarga();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se valida la selección del cartucho.
        /// </summary
        private void dgvMontosCarga_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

            DataGridViewRow fila = dgvMontosCarga.Rows[e.RowIndex];
            DataGridViewCell celda = fila.Cells[e.ColumnIndex];

            CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
            CartuchoCargaSucursal cartucho_carga = (CartuchoCargaSucursal)fila.DataBoundItem;

            if (e.Value == null || e.Value.Equals(string.Empty))
                return;

            if (e.ColumnIndex == NumeroMarchamoCarga.Index)
                return;

            try
            {
                string numero_cartucho = e.Value.ToString();
                
                Denominacion denominacion_cartucho = cartucho_carga.Denominacion;

                Cartucho cartucho = new Cartucho(numero_cartucho);

                
               
                    cartucho.Denominacion = denominacion_cartucho;
                

                e.Value = cartucho;
                e.ParsingApplied = true;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Validar la asignación del número de un cartucho.
        /// </summary
        private void dgvMontosCarga_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

           

            short valor;

            if (!short.TryParse(e.FormattedValue.ToString(), out valor))
                e.Cancel = true;

        }

       

        /// <summary>
        /// Validar la selección de la siguiente celda de las lista de cartuchos.
        /// </summary>
        private void dgvMontosCarga_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == DenominacionCartuchoCarga.Index ||
                e.ColumnIndex == MontoCartuchoCarga.Index ||
                e.ColumnIndex == CantidadCartuchoCarga.Index)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se selecciona otra hora de inicio para una carga.
        /// </summary
        private void dtpHoraInicioCarga_ValueChanged(object sender, EventArgs e)
        {
            this.guardarCarga();
        }

        /// <summary>
        /// Se selecciona otra hora de finalización para una carga.
        /// </summary
        private void dtpHoraFinalizacionCarga_ValueChanged(object sender, EventArgs e)
        {
            this.guardarCarga();
        }

        /// <summary>
        /// El cuadro de texto del comentario de una carga pierde el foco.
        /// </summary
        private void txtObservacionesCarga_Leave(object sender, EventArgs e)
        {
            this.guardarCarga();
        }

        /// <summary>
        /// Clic en el finalizar la hora de la carga del pedido
        /// </summary>
        private void btnMarcarFinDescarga_Click(object sender, EventArgs e)
        {
            _carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
            _carga.Hora_finalizacion = DateTime.Now;
            dtpHoraFinCarga.Value = DateTime.Now;
            this.guardarCarga();
        }


        /// <summary>
        /// Cambio en el estado del datagridview de manifiestos de sucursales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvManifiestosSucursales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManifiestosSucursales.SelectedRows.Count > 0)
            {
                cklbSeriesTulas.Items.Clear();

                ManifiestoSucursalCarga nuevo = null;

                BindingList<ManifiestoSucursalCarga> manifiestos = new BindingList<ManifiestoSucursalCarga>();
                manifiestos = (BindingList<ManifiestoSucursalCarga>)dgvManifiestosSucursales.DataSource;
                int contador = manifiestos.Count;


                //if (dgvManifiestoBancos.Rows.IndexOf(dgvManifiestoBancos.SelectedRows[0]) < dgvManifiestoBancos.Rows.Count)
                //{
                nuevo = (ManifiestoSucursalCarga)dgvManifiestosSucursales.SelectedRows[0].DataBoundItem;

                foreach (Bolsa b in nuevo.ListaBolsas)
                {
                    cklbSeriesTulas.Items.Add(b);
                }
                //}
            }
        }
        #endregion Cargas

        #region Otros

               private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBusquedaManifiestoSucursal formulario = new frmBusquedaManifiestoSucursal(_usuario);

            formulario.ShowDialog(this);

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        /// <summary>
        /// Se cambia el valor del selector del tamaño de las fuentes.
        /// </summary
        private void tbTamanoFuente_Scroll(object sender, EventArgs e)
        {
            Font fuente = new Font("Microsoft Sans Serif", 8f);

            switch (tbTamanoFuente.Value)
            {
                case 2: fuente = new Font("Microsoft Sans Serif", 12f); break;
                case 3: fuente = new Font("Microsoft Sans Serif", 14f); break;
                case 4: fuente = new Font("Microsoft Sans Serif", 20f); break;
            }

            DenominacionCartuchoCarga.DefaultCellStyle.Font = fuente;
            CantidadCartuchoCarga.DefaultCellStyle.Font = fuente;
            MontoCartuchoCarga.DefaultCellStyle.Font = fuente;
            NumeroMarchamoCarga.DefaultCellStyle.Font = fuente;


           
        }

        #endregion Otros

        #endregion Eventos

        #region Métodos Privados

       

       

        /// <summary>
        /// Verificar si un usuario tiene un cierre pendiente de finalizar o no.
        /// </summary>
        private void verificarCierre()
        {

            try
            {
                DateTime fecha = dtpFechaCierre.Value;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                CierreCargaSucursal cierre = new CierreCargaSucursal(cajero, fecha: fecha);

                if (_coordinacion.verificarCierreSucursal(ref cierre))
                {
                    _cierre = cierre;
                    _pendiente = false;
                    this.mostrarDatosCierre();
                }
                else if (_coordinacion.verificarCierreSucursalPendiente(ref cierre))
                {
                    _cierre = null;
                    _pendiente = true;
                    this.limpiarDatosCierre();
                }
                else
                {
                    _cierre = null;
                    _pendiente = true;
                    this.limpiarDatosCierre();
                }

                this.validarDatosCierre();
                this.validarOpcionesCierre();
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
            
        }
        
        /// <summary>
        /// Mostrar los datos del cierre del cajero.
        /// </summary>
        private void mostrarDatosCierre()
        {
            cboCoordinador.Text = _cierre.Coordinador == null ?
                string.Empty : _cierre.Coordinador.ToString();
            cboCamaraCierre.Text = _cierre.Camara == null ?
                string.Empty : _cierre.Camara.Identificador;

            // Mostrar las cargas y descargas del cierre

            dgvCargas.DataSource = _cierre.Cargas;
          

            btnCargasPendientes.Enabled = _cierre.Cargas_listas;

            // Montrar los montos de cierre

        
            // Actualizar la lista de cargas y descargas

            this.actualizarListasCierre();

            btnActualizarListasCierre.Enabled = true;
        }

  

      

        /// <summary>
        /// Mostrar los datos de la carga de Sucursales.
        /// </summary
        private void mostrarDatosCargaSucursales()
        {
            _carga_mostrada = false;

            dgvMontosCarga.DataSource = _carga.Cartuchos;

            
            dtpHoraInicioCarga.Value = _carga.Hora_inicio;
            dtpHoraFinCarga.Value = _carga.Hora_finalizacion;
            txtObservacionesCarga.Text = _carga.Observaciones;

            // Mostrar el manifiesto

            if (_carga.Manifiesto != null)
            {
                dgvManifiestosSucursales.DataSource = _carga.Manifiesto;
              
            }
            else
            {
                //txtManifiestoCarga.Text = _carga.Manifiesto.ID.ToString();

                //_bolsas = _carga.Manifiesto.ListaBolsas;
               
                //foreach (Bolsa bolsa in _bolsas)
                //{
                //    cklbSeriesTulas.Items.Add(bolsa.SerieBolsa);   /// para select rows y que aparezcan las tulas
                //}


            }

           
            _carga_mostrada = true;

            this.validarOpcionesCarga();
        }

       


        /// <summary>
        /// Validar si se pueden modificar o no los datos de un cierre.
        /// </summary
        private void validarOpcionesCierre()
        {

            if (_cierre == null)
            {
                btnIniciar.Enabled = _pendiente;
                btnTerminar.Enabled = false;
                btnCargasPendientes.Enabled = false;
                btnBuscar.Enabled = false;

                pnlOpcionesCarga.Enabled = true;
              
               // pnlOpcionesCierre.Enabled = true;
            }
            else if (_cierre.Terminado)
            {
                btnIniciar.Enabled = false;
                btnTerminar.Enabled = false;

                if (_coordinador)
                {
                   
                    btnCargasPendientes.Enabled = true;

                    btnBuscar.Enabled = true;

                    pnlOpcionesCarga.Enabled = true;
                  
                    pnlOpcionesCierre.Enabled = true;
                }
                else
                {

                    btnCargasPendientes.Enabled = true;//_cierre.Cargas_listas;

                    pnlOpcionesCarga.Enabled = false;
                    
                    pnlOpcionesCierre.Enabled = false;
                }

            }
            else
            {
                btnIniciar.Enabled = false;
                btnTerminar.Enabled = true;
                //btnCargasPendientes.Enabled = true;//_cierre.Cargas_listas;

                btnBuscar.Enabled = true;
                btnCargasPendientes.Enabled = true;
               
                pnlOpcionesCarga.Enabled = true;
                pnlOpcionesCierre.Enabled = true;
            }

        }

        /// <summary>
        /// Validar si el usuario ya selecciono la cámara y el coordinador de su cierre.
        /// </summary
        private void validarDatosCierre()
        {

            if (_cierre == null || _cierre.Cajero == null ||
                _cierre.Coordinador == null || _cierre.Camara == null)
            {
                ((Control)tpCargas).Enabled = false;

            }
            else
            {
                ((Control)tpCargas).Enabled = true;

            }

        }

        /// <summary>
        /// Validar si se pueden modificar o no los datos de una carga.
        /// </summary
        private void validarOpcionesCarga()
        {

            if (_carga == null)
            {
                pnlDatosCarga.Enabled = false;
             

                btnDevolverCarga.Enabled = false;
                btnRevisionCarga.Enabled = false;
                btnMarcarFinDescarga.Enabled = false;
                this.habilitarModificacionCartuchosCarga(false);
            }
            else if (_coordinador || _cierre.Activo) 
            {

                if (_carga.Verificada)
                {
                    pnlDatosCarga.Enabled = false;
                    btnMarcarFinDescarga.Enabled = false;
                    btnDevolverCarga.Enabled = false;
                    btnRevisionCarga.Enabled = false;
                    this.habilitarModificacionCartuchosCarga(_coordinador);
                }
                else if (_carga.Lista)
                {
                    pnlDatosCarga.Enabled = true;

                    btnMarcarFinDescarga.Enabled = true;
                    btnDevolverCarga.Enabled = true;
                    btnRevisionCarga.Enabled = true;
                    this.habilitarModificacionCartuchosCarga(true);
                }
                else
                {
                    pnlDatosCarga.Enabled = true;
                    btnMarcarFinDescarga.Enabled = true;
                    btnRevisionCarga.Enabled = true;
                    btnDevolverCarga.Enabled = true;
                    this.habilitarModificacionCartuchosCarga(true);
                }

            }
            else
            {
                pnlDatosCarga.Enabled = false;
                btnRevisionCarga.Enabled = false;
                btnDevolverCarga.Enabled = false;
                btnMarcarFinDescarga.Enabled = false;
                this.habilitarModificacionCartuchosCarga(false);
            }

        }

    

        /// <summary>
        /// Habilitar o deshabilitar la opción de modificar los datos de un cartucho de carga.
        /// </summary>
        private void habilitarModificacionCartuchosCarga(bool estado)
        {

            if (estado)
            {
   
                NumeroMarchamoCarga.ReadOnly = false;
            }
            else
            {

                NumeroMarchamoCarga.ReadOnly = true;
            }

        }

     

        /// <summary>
        /// Limpiar los datos de la carga seleccionada.
        /// </summary>
        private void limpiarDatosCarga()
        {
            _carga_mostrada = false;

            dtpHoraInicioCarga.Value = DateTime.Now;
            dtpHoraFinCarga.Value = DateTime.Now;

            txtObservacionesCarga.Text = string.Empty;
            //txtManifiestoCarga.Text = string.Empty;
            cklbSeriesTulas.Items.Clear();

            dgvMontosCarga.DataSource = null;

            _carga_mostrada = true;
        }

       

        /// <summary>
        /// Limpiar los datos del cierre.
        /// </summary>
        private void limpiarDatosCierre()
        {
            cboCoordinador.Text = string.Empty;
            cboCamaraCierre.Text = string.Empty;

            dgvListaCargasCierre.DataSource = null;
            

            dgvCargas.DataSource = null;


         
        }

        /// <summary>
        /// Actualizar la lista de cargas y descargas del cierre.
        /// </summary>
        private void actualizarListasCierre()
        {

            try
            {

                dgvListaCargasCierre.DataSource = _coordinacion.listarCargasSucursalesPorCierreSucursales(_cierre);

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Guardar los datos de una carga.
        /// </summary>
        private void guardarCarga()
        {

            if (_carga_mostrada)
            {

                try
                {
                    _carga.Hora_inicio = dtpHoraInicioCarga.Value;
                    _carga.Hora_finalizacion = dtpHoraFinCarga.Value;
                    _carga.Observaciones = txtObservacionesCarga.Text;

                    _coordinacion.actualizarCargaSucursal(_carga);

                    this.validarOpcionesCarga();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }


        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Mostrar los datos de los manifiestos seleccionados para una carga.
        /// </summary>
        public void seleccionarManifiestosCarga(ManifiestoSucursalCarga manifiesto,BindingList<Bolsa> bolsas)
        {

            try
            {
                //_carga.Manifiesto = manifiesto;
                //_carga.Manifiesto.ListaBolsas = bolsas;
          
                _coordinacion.actualizarCargaSucursal(_carga);

                if (manifiesto != null)
                {
                    //txtManifiestoCarga.Text = manifiesto.ID.ToString();

                     cklbSeriesTulas.Items.Clear();
                    
                    foreach (Bolsa bolsa in bolsas)
                    {
                        cklbSeriesTulas.Items.Add(bolsa.SerieBolsa);   /// para select rows y que aparezcan las tulas
                    }
                    
    
                     
                }
  
                
                this.validarOpcionesCarga();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Agregar una carga a la lista de cargas.
        /// </summary>
        public void agregarCarga(CargaSucursal carga)
        {
            BindingList<CargaSucursal> cargas = (BindingList<CargaSucursal>)dgvCargas.DataSource;

            dtpHoraInicioCarga.Value = DateTime.Now;
           // carga.Hora_finalizacion = DateTime.Now;
            _carga = carga;
            cargas.Add(carga);
            dgvCargas.AutoResizeColumns();
            this.guardarCarga();
            btnCargasPendientes.Enabled = true;
        }

        

        #endregion Métodos Públicos

        #region Metodos Estaticos
        
        static DateTime GetYesterday(DateTime fecha)
        {
            // Add -1 to now
            return fecha.AddDays(-1);
        }

        #endregion Metodos Estaticos

        #endregion Sucursales

        #region Bancos

        #region Eventos

        #region Cierre

        /// <summary>
        /// Clic en el botón de iniciar cierre.
        /// </summary>
        private void btnIniciarBancos_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFechaBancos.Value;
                Colaborador cajero = (Colaborador)cboCajerosBancos.SelectedItem;

                _cierre_banco = new CierreCargaBanco(cajero, fecha: fecha);

                _coordinacion.agregarCierreBanco(ref _cierre_banco);

                dgvListaCargasBancos.DataSource = _cierre_banco.Cargas;

                this.validarOpcionesCierreBancos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de terminar cierre.
        /// </summary>
        private void btnTerminarBancos_Click(object sender, EventArgs e)
        {
            frmValidacionCoordinador formulario = new frmValidacionCoordinador();

            if (formulario.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    _coordinacion.actualizarCierreBancoTerminar(_cierre_banco);

                    _cierre_banco.Terminado = true;

                    this.validarOpcionesCierreBancos();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Clic en el botón de actualizar la lista de cargas y descargas del cierre.
        /// </summary>
        private void btnActualizarListasCierreBancos_Click(object sender, EventArgs e)
        {
            this.actualizarListasCierreBancos();
        }

        /// <summary>
        /// Clic en el botón de guardar los datos del cierre.
        /// </summary>
        private void btnGuardarBancos_Click(object sender, EventArgs e)
        {

            try
            {
                Colaborador coordinador = cboCoordinadorBancos.SelectedItem == null ?
                    null : (Colaborador)cboCoordinadorBancos.SelectedItem;

                Camara camara = cboCamaraBancos.SelectedItem == null ?
                    null : (Camara)cboCamaraBancos.SelectedItem;

                _cierre_banco.Coordinador = coordinador;
                _cierre_banco.Camara = camara;

                _coordinacion.actualizarCierreBancos(_cierre_banco);

                this.validarDatosCierreBancos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se selecciona otro cajero para el cierre.
        /// </summary>
        private void cboCajeroBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.verificarCierreBancos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Se selecciona otra fecha para el cierre.
        /// </summary>
        private void dtpFechaBancos_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                this.verificarCierreBancos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        #endregion Cierre

        #region Cargas


        /// <summary>
        /// Clic en el boton de mostrar manifiesto
        /// </summary>
        private void btnManifiestoBancos_Click(object sender, EventArgs e)
        {
            try
            {
                _carga_bancos.Cajero = (Colaborador)cboCajerosBancos.SelectedItem;

                frmManifiestoGeneral formulario = new frmManifiestoGeneral(_carga_bancos);
                formulario.ShowDialog();
                formulario.mostrarDatosCargaSucursal();
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Clic en el botón de seleccionar cargas asignadas pendientes.
        /// </summary>
        private void btnCargasPendientesBancos_Click(object sender, EventArgs e)
        {

            try
            {
                frmCargasPendientesBancos formulario = new frmCargasPendientesBancos(_cierre_banco);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de devolver carga.
        /// </summary>
        private void btnDevolverCargaBancos_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaATMDevolucion") == DialogResult.Yes)
                {
                    PedidoBancos carga = (PedidoBancos)dgvCargasBanco.SelectedRows[0].DataBoundItem;

                    carga.Cierre = null;

                    _coordinacion.actualizarPedidoBancoCierreBanco(carga);

                    _carga_bancos = carga;

                    dgvCargasBanco.Rows.Remove(dgvCargasBanco.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCargaATMConfirmacionDevolucion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de seleccionar los manifiestos de una carga.
        /// </summary>
        private void btnSeleccionarManifiestosCargaBancos_Click(object sender, EventArgs e)
        {
            PedidoBancos carga = (PedidoBancos)dgvCargasBanco.SelectedRows[0].DataBoundItem;

            carga.Cajero = (Colaborador)cboCajero.SelectedItem;

            frmIngresoManifiestoBancos formulario = new frmIngresoManifiestoBancos(carga);

            formulario.limpiarDatosManifiesto();

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de verificar carga.
        /// </summary>
        private void btnRevisionCargaBancos_Click(object sender, EventArgs e)
        {
            frmVerificacionPedidoBancos formulario = new frmVerificacionPedidoBancos(_carga_bancos);

            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
                this.validarOpcionesCarga();

                btnCargasPendientes.Enabled = _cierre_banco.Cargas_listas;
            }

        }



        /// <summary>
        /// Se selecciona otra carga en la lista de cargas.
        /// </summary
        private void dgvCargasBancos_SelectionChanged(object sender, EventArgs e)
        {
            chkTulasBancos.Items.Clear();
            if (dgvCargasBanco.SelectedRows.Count > 0)
            {
                _carga_bancos = (PedidoBancos)dgvCargasBanco.SelectedRows[0].DataBoundItem;

                this.mostrarDatosCargaBancos();

            }
            else
            {
                _carga_bancos = null;
                this.limpiarDatosCargaBancos();
            }

            this.validarOpcionesCargaBancos();
        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary
        private void dgvCargasBancos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargasBanco.Rows[e.RowIndex + contador];
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();
            }

        }

        /// <summary>
        /// Se selecciona otro cartucho de la lista de cartuchos.
        /// </summary
        private void dgvMontosCargaBancos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvMontosCargaBanco.SelectedCells.Count > 0)
            {
                DataGridViewCell celda = dgvMontosCargaBanco.SelectedCells[0];
                BolsaCargaBanco cartucho = (BolsaCargaBanco)celda.OwningRow.DataBoundItem;
                PedidoBancos carga = (PedidoBancos)dgvCargasBanco.SelectedRows[0].DataBoundItem;
                Denominacion denominacion = cartucho.Denominacion;

                celda.Style.SelectionBackColor = _colores[(byte)denominacion.Id_imagen];

            }


        }

        /// <summary>
        /// Se cambia el número de cartucho de un cartucho.
        /// </summary
        private void dgvMontosCargaBancos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosCarga.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontosCarga.Rows[e.RowIndex];
                    DataGridViewCell celda = fila.Cells[e.ColumnIndex];

                    BolsaCargaBanco cartucho_carga = (BolsaCargaBanco)fila.DataBoundItem;

                    _coordinacion.actualizarBolsaCargaBanco(cartucho_carga);

                    this.validarOpcionesCarga();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se valida la selección del cartucho.
        /// </summary
        private void dgvMontosCargaBancos_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

            DataGridViewRow fila = dgvMontosCarga.Rows[e.RowIndex];
            DataGridViewCell celda = fila.Cells[e.ColumnIndex];

            PedidoBancos carga = (PedidoBancos)dgvCargasBanco.SelectedRows[0].DataBoundItem;
            BolsaCargaBanco cartucho_carga = (BolsaCargaBanco)fila.DataBoundItem;

            if (e.Value == null || e.Value.Equals(string.Empty))
                return;

            if (e.ColumnIndex == NumeroMarchamoCarga.Index)
                return;

            try
            {
                short numero_cartucho = short.Parse(e.Value.ToString());

                Denominacion denominacion_cartucho = cartucho_carga.Denominacion;



                e.ParsingApplied = true;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Validar la asignación del número de un cartucho.
        /// </summary
        private void dgvMontosCargaBancos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {



            short valor;

            if (!short.TryParse(e.FormattedValue.ToString(), out valor))
                e.Cancel = true;

        }



        /// <summary>
        /// Validar la selección de la siguiente celda de las lista de cartuchos.
        /// </summary>
        private void dgvMontosCargaBancos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == DenominacionCartuchoCarga.Index ||
                e.ColumnIndex == MontoCartuchoCarga.Index ||
                e.ColumnIndex == CantidadCartuchoCarga.Index)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se selecciona otra hora de inicio para una carga.
        /// </summary
        private void dtpHoraInicioCargaBancos_ValueChanged(object sender, EventArgs e)
        {
            this.guardarCargaBancos();
        }

        /// <summary>
        /// Se selecciona otra hora de finalización para una carga.
        /// </summary
        private void dtpHoraFinalizacionCargaBancos_ValueChanged(object sender, EventArgs e)
        {
            this.guardarCargaBancos();
        }

        /// <summary>
        /// El cuadro de texto del comentario de una carga pierde el foco.
        /// </summary
        private void txtObservacionesCargaBancos_Leave(object sender, EventArgs e)
        {
            this.guardarCargaBancos();
        }

        /// <summary>
        /// Clic en el finalizar la hora de la carga del pedido
        /// </summary>
        private void btnMarcarFinDescargaBancos_Click(object sender, EventArgs e)
        {
            _carga_bancos.Hora_finalizacion = DateTime.Now;
            dtpHoraFinBancos.Value = DateTime.Now;
            this.guardarCargaBancos();
        }



        /// <summary>
        /// Cambio en el datagrid de Manifiestos
        /// </summary>
        private void dgvManifiestoBancos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvManifiestoBancos.SelectedRows.Count > 0)
                {
                    chkTulasBancos.Items.Clear();
      
                    ManifiestoPedidoBanco nuevo = null;

                    BindingList<ManifiestoPedidoBanco> manifiestos = new BindingList<ManifiestoPedidoBanco>();
                    manifiestos = (BindingList<ManifiestoPedidoBanco>)dgvManifiestoBancos.DataSource;
                    int contador = manifiestos.Count;


                    //if (dgvManifiestoBancos.Rows.IndexOf(dgvManifiestoBancos.SelectedRows[0]) < dgvManifiestoBancos.Rows.Count)
                    //{
                        nuevo = (ManifiestoPedidoBanco)dgvManifiestoBancos.SelectedRows[0].DataBoundItem;

                        foreach (BolsaBanco b in nuevo.Serie_Tula)
                        {
                            chkTulasBancos.Items.Add(b);
                        }
                    //}
                }
            }
            catch (Excepcion ex)
            {

            }
        }


        /// <summary>
        /// Agrega las columnas al datagridview
        /// </summary>
        private void dgvManifiestoBancos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvManifiestoBancos.Rows[e.RowIndex + contador];
                ManifiestoPedidoBanco carga = (ManifiestoPedidoBanco)fila.DataBoundItem;

                fila.Cells[clmNumeroMan.Index].Value = carga.ID.ToString();
            }
        }



        
        
        #endregion Cargas

        #region Otros

        private void btnBuscarBancos_Click(object sender, EventArgs e)
        {
            frmBusquedaManifiestoSucursal formulario = new frmBusquedaManifiestoSucursal(_usuario);

            formulario.ShowDialog(this);

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalirBancos_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Se cambia el valor del selector del tamaño de las fuentes.
        /// </summary
        private void tbTamanoFuenteBancos_Scroll(object sender, EventArgs e)
        {
            Font fuente = new Font("Microsoft Sans Serif", 8f);

            switch (tbTamanoFuente.Value)
            {
                case 2: fuente = new Font("Microsoft Sans Serif", 12f); break;
                case 3: fuente = new Font("Microsoft Sans Serif", 14f); break;
                case 4: fuente = new Font("Microsoft Sans Serif", 20f); break;
            }

            DenominacionCartuchoCarga.DefaultCellStyle.Font = fuente;
            CantidadCartuchoCarga.DefaultCellStyle.Font = fuente;
            MontoCartuchoCarga.DefaultCellStyle.Font = fuente;
            NumeroMarchamoCarga.DefaultCellStyle.Font = fuente;



        }

        #endregion Otros

        #endregion Eventos

        #region Métodos Privados


        /// <summary>
        /// Verificar si un usuario tiene un cierre pendiente de finalizar o no.
        /// </summary>
        private void verificarCierreBancos()
        {

            try
            {
                DateTime fecha = dtpFechaCierre.Value;
                Colaborador cajero = (Colaborador)cboCajerosBancos.SelectedItem;
                CierreCargaBanco cierre = new CierreCargaBanco(cajero, fecha: fecha);

                if (_coordinacion.verificarCierreBanco(ref cierre))
                {
                    _cierre_banco = cierre;
                    _pendiente_banco = false;
                    this.mostrarDatosCierreBancos();
                }
                else if (_coordinacion.verificarCierreBancoPendiente(ref cierre))
                {
                    _cierre_banco = cierre;
                    _pendiente_banco = true;
                    this.mostrarDatosCierreBancos();
                    //this.limpiarDatosCierreBancos();
                }
                else
                {
                    _cierre_banco = null;
                    _pendiente_banco = true;
                    this.limpiarDatosCierreBancos();
                }

                this.validarDatosCierreBancos();
                this.validarOpcionesCierreBancos();
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Mostrar los datos del cierre del cajero.
        /// </summary>
        private void mostrarDatosCierreBancos()
        {
            cboCoordinadorBancos.Text = _cierre_banco.Coordinador == null ?
                string.Empty : _cierre_banco.Coordinador.ToString();
            cboCamaraBancos.Text = _cierre_banco.Camara == null ?
                string.Empty : _cierre_banco.Camara.Identificador;

            // Mostrar las cargas y descargas del cierre

            dgvCargasBanco.DataSource = _cierre_banco.Cargas;


            btnCargasPendientes.Enabled = _cierre_banco.Cargas_listas;

            // Montrar los montos de cierre


            // Actualizar la lista de cargas y descargas

            this.actualizarListasCierreBancos();

            btnActualizarListasCierre.Enabled = true;
        }





        /// <summary>
        /// Mostrar los datos de la carga de Sucursales.
        /// </summary
        private void mostrarDatosCargaBancos()
        {
            _carga_mostrada_banco = false;

            dgvMontosCargaBanco.DataSource = _carga_bancos.Bolsas;


            dtpHoraInicioBanco.Value = _carga_bancos.Hora_inicio;
            dtpHoraFinBancos.Value = _carga_bancos.Hora_finalizacion;
            txtObservacionesBanco.Text = _carga_bancos.Observaciones;

            // Mostrar el manifiesto

            if (_carga_bancos.Manifiesto == null)
            {
                //txtManifiestoCarga.Text = string.Empty;

            }
            else
            {
                dgvManifiestoBancos.DataSource = _carga_bancos.Manifiesto;

                if (_carga_bancos != null)
                {
                    double cantidad_paquetones = 0;
                    double cantidad_bolsas = 0;
                    foreach (BolsaCargaBanco b in _carga_bancos.Bolsas)
                    {
                        cantidad_paquetones = cantidad_paquetones + b.Cantidad_asignada / _formula.Paquete;
                        cantidad_bolsas = cantidad_bolsas + b.Cantidad_asignada / _formula.Bolsa;
                    }
                    lblCantidaddePaquetones.Text = cantidad_paquetones.ToString();
                    lblCantidadBolsas.Text = cantidad_bolsas.ToString();

                }
            }


            _carga_mostrada = true;

            this.validarOpcionesCargaBancos();
        }




        /// <summary>
        /// Validar si se pueden modificar o no los datos de un cierre.
        /// </summary
        private void validarOpcionesCierreBancos()
        {

            if (_cierre_banco == null)
            {
                btnIniciarBanco.Enabled = _pendiente_banco;
                btnTerminarBancos.Enabled = false;
                btnPendientesBancos.Enabled = false;
               // btnbuscarbancos.Enabled = false;

                pnlOpcionesCargaBanco.Enabled = true;

                pnlOpcionesCierreBancos.Enabled = true;
            }
            else if (_cierre_banco.Terminado)
            {
                btnIniciarBanco.Enabled = false;
                btnTerminarBancos.Enabled = false;

                if (_coordinador)
                {

                    btnPendientesBancos.Enabled = true;

                    //btnBuscar.Enabled = true;

                    pnlOpcionesCargaBanco.Enabled = true;

                    pnlOpcionesCierreBancos.Enabled = true;
                }
                else
                {

                    btnPendientesBancos.Enabled = _cierre_banco.Cargas_listas;

                    pnlOpcionesCargaBanco.Enabled = false;

                    pnlOpcionesCierreBancos.Enabled = false;
                }

            }
            else
            {
                btnIniciarBanco.Enabled = false;
                btnTerminarBancos.Enabled = true;
                //btnCargasPendientes.Enabled = true;//_cierre.Cargas_listas;

               // btnBuscar.Enabled = true;
                btnPendientesBancos.Enabled = true;

                pnlOpcionesCargaBanco.Enabled = true;
                pnlOpcionesCierreBancos.Enabled = true;
            }

        }

        /// <summary>
        /// Validar si el usuario ya selecciono la cámara y el coordinador de su cierre.
        /// </summary
        private void validarDatosCierreBancos()
        {

            if (_cierre_banco == null || _cierre_banco.Cajero == null ||
                _cierre_banco.Coordinador == null || _cierre_banco.Camara == null)
            {
                ((Control)tpCargasBanco).Enabled = false;

            }
            else
            {
                ((Control)tpCargasBanco).Enabled = true;

            }

        }

        /// <summary>
        /// Validar si se pueden modificar o no los datos de una carga.
        /// </summary
        private void validarOpcionesCargaBancos()
        {

            if (_carga_bancos == null)
            {
                pnlDatosCargaBanco.Enabled = false;


                btnDevolverPedidoBanco.Enabled = false;
                btnRevisarPedidoBanco.Enabled = false;
                btnFinalizarPedidoBanco.Enabled = false;
                this.habilitarModificacionCartuchosCargaBancos(false);
            }
            else if (_coordinador || _cierre_banco.Activo)
            {

                if (_carga_bancos.Verificada)
                {
                    pnlDatosCargaBanco.Enabled = false;
                    btnFinalizarPedidoBanco.Enabled = false;
                    btnDevolverPedidoBanco.Enabled = false;
                    btnRevisarPedidoBanco.Enabled = false;
                    this.habilitarModificacionCartuchosCargaBancos(_coordinador);
                }
                else if (_carga_bancos.Lista)
                {
                    pnlDatosCargaBanco.Enabled = true;

                    btnFinalizarPedidoBanco.Enabled = true;
                    btnDevolverPedidoBanco.Enabled = true;
                    btnRevisarPedidoBanco.Enabled = true;
                    this.habilitarModificacionCartuchosCargaBancos(true);
                }
                else
                {
                    pnlDatosCargaBanco.Enabled = true;
                    btnFinalizarPedidoBanco.Enabled = true;
                    btnRevisarPedidoBanco.Enabled = true;
                    btnDevolverPedidoBanco.Enabled = true;
                    this.habilitarModificacionCartuchosCargaBancos(true);
                }

            }
            else
            {
                pnlDatosCargaBanco.Enabled = false;
                btnRevisarPedidoBanco.Enabled = false;
                btnDevolverPedidoBanco.Enabled = false;
                btnFinalizarPedidoBanco.Enabled = false;
                this.habilitarModificacionCartuchosCargaBancos(false);
            }

        }



        /// <summary>
        /// Habilitar o deshabilitar la opción de modificar los datos de un cartucho de carga.
        /// </summary>
        private void habilitarModificacionCartuchosCargaBancos(bool estado)
        {

            if (estado)
            {

                NumeroMarchamoCarga.ReadOnly = false;
            }
            else
            {

                NumeroMarchamoCarga.ReadOnly = true;
            }

        }



        /// <summary>
        /// Limpiar los datos de la carga seleccionada.
        /// </summary>
        private void limpiarDatosCargaBancos()
        {
            _carga_mostrada_banco = false;

            //dtpHoraInicioBanco.Value = DateTime.Now;
            //dtpHoraFinBancos.Value = DateTime.Now;

            txtObservacionesBanco.Text = string.Empty;
            chkTulasBancos.Items.Clear();

            dgvMontosCargaBanco.DataSource = null;

            _carga_mostrada_banco = true;
        }



        /// <summary>
        /// Limpiar los datos del cierre.
        /// </summary>
        private void limpiarDatosCierreBancos()
        {
            cboCoordinadorBancos.Text = string.Empty;
            cboCamaraBancos.Text = string.Empty;

            dgvListaCargasBancos.DataSource = null;


            dgvCargasBanco.DataSource = null;



        }

        /// <summary>
        /// Actualizar la lista de cargas y descargas del cierre.
        /// </summary>
        private void actualizarListasCierreBancos()
        {

            try
            {

                dgvListaCargasBancos.DataSource = _coordinacion.listarCargasBancosPorCierreBancoss(_cierre_banco);

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Guardar los datos de una carga.
        /// </summary>
        private void guardarCargaBancos()
        {

            if (_carga_mostrada)
            {

                try
                {
                    _carga_bancos.Hora_inicio = dtpHoraInicioBanco.Value;
                    _carga_bancos.Hora_finalizacion = dtpHoraFinBancos.Value;
                    _carga_bancos.Observaciones = txtObservacionesBanco.Text;

                    _coordinacion.actualizarPedidoBanco(_carga_bancos);

                    this.validarOpcionesCarga();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }


        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Mostrar los datos de los manifiestos seleccionados para una carga.
        /// </summary>
        public void seleccionarManifiestosCargaBancos(BindingList<ManifiestoPedidoBanco> manifiesto, BindingList<BolsaBanco> bolsas)
        {

            try
            {
                _carga_bancos.Manifiesto = manifiesto;

                foreach (ManifiestoPedidoBanco m in _carga_bancos.Manifiesto)
                {
                    ManifiestoPedidoBanco copia = m;
                     _atencion.listarBolsasBancoPorManifiesto(ref copia);
                }

                _coordinacion.actualizarCargaSucursal(_carga);

                if (manifiesto != null)
                {
                    dgvManifiestoBancos.DataSource = manifiesto;
                  
                }


                this.validarOpcionesCarga();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Agregar una carga a la lista de cargas.
        /// </summary>
        public void agregarCargaBancos(PedidoBancos carga)
        {

            BindingList<PedidoBancos> cargas = new BindingList<PedidoBancos>();
            if (dgvCargasBanco.DataSource == null)
            {
                dgvCargasBanco.DataSource = new BindingList<PedidoBancos>();
            }
            cargas = (BindingList<PedidoBancos>)dgvCargasBanco.DataSource;

            dtpHoraInicioBanco.Value = DateTime.Now;
            // carga.Hora_finalizacion = DateTime.Now;
            if (cargas != null)
            {
                cargas.Add(carga);
                dgvCargasBanco.AutoResizeColumns();
                this.guardarCargaBancos();
                dgvCargasBanco.Refresh();
                btnPendientesBancos.Enabled = true;
            }
            
        }



        #endregion Métodos Públicos

        #region Metodos Estaticos

        static DateTime GetYesterdayBancos(DateTime fecha)
        {
            // Add -1 to now
            return fecha.AddDays(-1);
        }

        #endregion Metodos Estaticos


        



        #endregion Bancos

    }
}
