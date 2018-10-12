using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmRegistroCierreNiquel : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private Colaborador _usuario = null;
        private CierreNiquel _cierre = null;
        private CierreCargaBanco _cierre_banco = null;
        private PedidoNiquel _carga = null;
        private PedidoBancos _carga_bancos = null;

        private BolsaNiquel _bolsa = null;
        private BindingList<BolsaNiquel> _bolsas = null;

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

        public frmRegistroCierreNiquel(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            try
            {
               
                dgvListaCargasCierre.AutoGenerateColumns = false;
               

                dgvCargas.AutoGenerateColumns = false;


                dgvMontosCarga.AutoGenerateColumns = false;
     


                BindingList<ManifiestoNiquelPedido> manifiestos = null;




                BindingList<ManifiestoNiquelPedido> manifiestos_suc = null;

                dgvManifiestosSucursales.AutoGenerateColumns = false;
                dgvManifiestosSucursales.DataSource = manifiestos_suc;

     
                pnlDatosCarga.Enabled = true;


                gbCargasAsignadas.Enabled = true;
         
                
                tlpControl.Enabled = true;
  
                
                
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA,  Puestos.CajeroB);
                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.Coordinador);
                cboCamaraCierre.ListaMostrada = _mantenimiento.listarCamarasPorArea(Areas.Boveda);



               

                _coordinador = _usuario.Puestos.Contains(Puestos.Coordinador) || _usuario.Puestos.Contains(Puestos.Supervisor);

                _formula = _mantenimiento.obtenerFormula();

                //((Control)tpCargas).Enabled = true;
                //((Control)tpCierre).Enabled = true;

                if (_coordinador)
                {
                    cboCajero.Enabled = true;
         
                   
                }
                else
                {
                    cboCajero.Text = _usuario.ToString();
                    this.verificarCierre();

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

                _cierre = new CierreNiquel(cajero, fecha: fecha);

                _coordinacion.agregarCierreNiquel(ref _cierre);

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
                    _coordinacion.actualizarCierrePedidoNiquelTerminar(_cierre);

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

                _coordinacion.actualizarCierrePedidoNiquel(_cierre);
                
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
                //_carga.Cajero = (Colaborador)cboCajero.SelectedItem;

                //frmManifiestoGeneral formulario = new frmManifiestoGeneral(_carga);
                //formulario.ShowDialog();
                //formulario.mostrarDatosCargaSucursal();
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
                frmCargasPendientesNiquel formulario = new frmCargasPendientesNiquel(_cierre);

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
                    PedidoNiquel carga = (PedidoNiquel)dgvCargas.SelectedRows[0].DataBoundItem;

                    carga.Cierre = null;

                    _coordinacion.actualizarPedidoNiquelCierreNiquel(carga);

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
            PedidoNiquel carga = (PedidoNiquel)dgvCargas.SelectedRows[0].DataBoundItem;

            carga.Cajero = (Colaborador)cboCajero.SelectedItem;

            frmIngresoManifiestoNiquel formulario = new frmIngresoManifiestoNiquel(ref carga);
            
            formulario.limpiarDatosManifiesto();

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de verificar carga.
        /// </summary>
        private void btnRevisionCarga_Click(object sender, EventArgs e)
        {
            frmVerificacionPedidoNiquel formulario = new frmVerificacionPedidoNiquel(_carga);

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
                _carga = (PedidoNiquel)dgvCargas.SelectedRows[0].DataBoundItem;
                
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
                PedidoNiquel carga = (PedidoNiquel)fila.DataBoundItem;

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
                CartuchosNiquel cartucho = (CartuchosNiquel)celda.OwningRow.DataBoundItem;
                PedidoNiquel carga = (PedidoNiquel)dgvCargas.SelectedRows[0].DataBoundItem;
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

                    CartuchosNiquel cartucho_carga = (CartuchosNiquel)fila.DataBoundItem;

                    _coordinacion.actualizarCartuchoPedidoNiquel(cartucho_carga);

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

            PedidoNiquel carga = (PedidoNiquel)dgvCargas.SelectedRows[0].DataBoundItem;
            CartuchosNiquel cartucho_carga = (CartuchosNiquel)fila.DataBoundItem;

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

                ManifiestoNiquelPedido nuevo = null;

                BindingList<ManifiestoNiquelPedido> manifiestos = new BindingList<ManifiestoNiquelPedido>();
                manifiestos = (BindingList<ManifiestoNiquelPedido>)dgvManifiestosSucursales.DataSource;
                int contador = manifiestos.Count;


                //if (dgvManifiestoBancos.Rows.IndexOf(dgvManifiestoBancos.SelectedRows[0]) < dgvManifiestoBancos.Rows.Count)
                //{
                nuevo = (ManifiestoNiquelPedido)dgvManifiestosSucursales.SelectedRows[0].DataBoundItem;

                if (nuevo.ListaBolsas == null)
                    nuevo.ListaBolsas = new BindingList<BolsaNiquel>();

                foreach (BolsaNiquel b in nuevo.ListaBolsas)
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
            //frmBusquedaManifiestoSucursal formulario = new frmBusquedaManifiestoSucursal(_usuario);

            //formulario.ShowDialog(this);

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
                CierreNiquel cierre = new CierreNiquel(cajero, fecha: fecha);

                if (_coordinacion.verificarCierreNiquel(ref cierre))
                {
                    _cierre = cierre;
                    _pendiente = false;
                    this.mostrarDatosCierre();
                }
                else if (_coordinacion.verificarCierreNiquelPendiente(ref cierre))
                {
                    _cierre = null;
                    _pendiente = true;
                    this.limpiarDatosCierre();
                }
                else
                {
                    _cierre = null;
                    _pendiente = false;
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
               
                //foreach (BolsaNiquel bolsa in _bolsas)
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
                btnIniciar.Enabled = true;
                btnTerminar.Enabled = false;
                btnCargasPendientes.Enabled = false;
     

                pnlOpcionesCarga.Enabled = true;
              
                pnlOpcionesCierre.Enabled = true;
            }
            else if (_cierre.Terminado)
            {
                btnIniciar.Enabled = false;
                btnTerminar.Enabled = false;

                if (_coordinador)
                {
                   
                    btnCargasPendientes.Enabled = true;

          

                    pnlOpcionesCarga.Enabled = true;
                  
                    pnlOpcionesCierre.Enabled = true;
                }
                else
                {

                    btnCargasPendientes.Enabled = true;//_cierre.Cargas_listas;

                    //pnlOpcionesCarga.Enabled = false;

                    //pnlOpcionesCierre.Enabled = false;
                }

            }
            else
            {
                btnIniciar.Enabled = false;
                btnTerminar.Enabled = true;
                //btnCargasPendientes.Enabled = true;//_cierre.Cargas_listas;
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
               // ((Control)tpCargas).Enabled = false;

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
                //pnlDatosCarga.Enabled = false;
             

                btnDevolverCarga.Enabled = false;
                btnRevisionCarga.Enabled = false;
                btnMarcarFinDescarga.Enabled = false;
                this.habilitarModificacionCartuchosCarga(false);
            }
            else if (_coordinador || _cierre.Activo) 
            {

                if (_carga.Verificada)
                {
                    //pnlDatosCarga.Enabled = false;
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

                dgvListaCargasCierre.DataSource = _coordinacion.listarPedidosNiquelPorCierreNiquel(_cierre);

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

                    _coordinacion.actualizarPedidoNiquel(_carga);

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
        public void seleccionarManifiestosCarga(ManifiestoNiquelPedido manifiesto,BindingList<BolsaNiquel> bolsas)
        {

            try
            {
                //_carga.Manifiesto = manifiesto;
                //_carga.Manifiesto.ListaBolsas = bolsas;
          
                _coordinacion.actualizarPedidoNiquel(_carga);

                if (manifiesto != null)
                {
                    //txtManifiestoCarga.Text = manifiesto.ID.ToString();

                     cklbSeriesTulas.Items.Clear();
                    
                    foreach (BolsaNiquel bolsa in bolsas)
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
        public void agregarCarga(PedidoNiquel carga)
        {
            BindingList<PedidoNiquel> cargas = (BindingList<PedidoNiquel>)dgvCargas.DataSource;
            _carga = carga;
            dtpHoraInicioCarga.Value = DateTime.Now;
           // carga.Hora_finalizacion = DateTime.Now;
      
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
    }
}
