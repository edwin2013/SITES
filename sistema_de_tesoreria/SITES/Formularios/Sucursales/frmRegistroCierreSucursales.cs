using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using LibreriaReportesOffice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Sucursales
{
    public partial class frmRegistroCierreSucursales : Form
    {
                #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private Colaborador _usuario = null;
        private CierreATMs _cierre = null;
        private CargaATM _carga = null;
        private DescargaATM _descarga = null;
        private DescargaATMFull _descarga_full = null;
        private DescargaATM _descarga_completa = null;
        private DescargaATMFull _descarga_full_completa = null;

        private bool _carga_mostrada = false;
        private bool _descarga_mostrada = false;
        private bool _descarga_completa_mostrada = false;
        private bool _descarga_full_mostrada = false;
        private bool _descarga_completa_full_mostrada = false;
        private bool _coordinador = false;
        private bool _pendiente = false;

        private Color[] _colores = {Color.DarkOrchid,
                                    Color.LightBlue,
                                    Color.Gold,
                                    Color.LightGreen,
                                    Color.Orange,
                                    Color.Indigo,
                                    Color.DarkGray};



        private enum TiposFila : byte
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

        private enum TiposDiferencia : byte
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

        public frmRegistroCierreSucursales(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            try
            {
                dgvListaCargasCierre.AutoGenerateColumns = false;

                dgvCargas.AutoGenerateColumns = false;
                dgvMontosCarga.AutoGenerateColumns = false;
                

                //Descargas
                dgvDescargas.AutoGenerateColumns = false;
                dgvMontosDescarga.AutoGenerateColumns = false;
                dgvContadoresDescarga.AutoGenerateColumns = false;
                dgvDiferenciasRemanentesDescarga.AutoGenerateColumns = false;
                dgvDiferenciasContadoresDescarga.AutoGenerateColumns = false;
                dgvMontosMesaDescargas.AutoGenerateColumns = false;
                dgvMontosColaDescargas.AutoGenerateColumns = false;



             

                //Descargas Full
                dgvDescargasFull.AutoGenerateColumns = false;
                dgvMontosDescargaFull.AutoGenerateColumns = false;
                dgvContadoresDescargaFull.AutoGenerateColumns = false;
                dgvDiferenciasDescargaFull.AutoGenerateColumns = false;
                dgvMontosMesaDescargasFull.AutoGenerateColumns = false;
                dgvMontosColaDescargasFull.AutoGenerateColumns = false;

                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.ATMs, Puestos.CajeroA,  Puestos.CajeroB);
                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.ATMs, Puestos.Coordinador);
                //cboCamaraCierre.ListaMostrada = _mantenimiento.listarCamaras();
                cboCamaraCierre.ListaMostrada = _mantenimiento.listarCamarasPorArea(Areas.ATMs);
                _coordinador = _usuario.Puestos.Contains(Puestos.Coordinador) || _usuario.Puestos.Contains(Puestos.Supervisor);

                ((Control)tpCargas).Enabled = false;
                ((Control)tpDescargas).Enabled = false;
                ((Control)tpDescargasFull).Enabled = false;
                ((Control)tpCierre).Enabled = false;



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

                _cierre = new CierreATMs(cajero, fecha: fecha);

                _coordinacion.agregarCierreATMs(ref _cierre);

                dgvCargas.DataSource = _cierre.Cargas;
                dgvDescargas.DataSource = _cierre.Descargas;
                dgvMontosMesaDescargas.DataSource = _cierre.Montos_mesa_descargas;
                dgvMontosColaDescargas.DataSource = _cierre.Montos_cola_descargas;

                this.mostrarConceptosTotalesDescargas();
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
                    _coordinacion.actualizarCierreATMsTerminar(_cierre);

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

                _coordinacion.actualizarCierreATMs(_cierre);

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

        /// <summary>
        /// Se agrega un descarga a la lista de descargas del cierre.
        /// </summary>
        private void dgvListaDescargasCierre_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                int posicion = e.RowIndex + contador;
                DataGridViewRow fila = dgvListaDescargasCierre.Rows[posicion];

                fila.Cells[NumeroDescargaListaDescargas.Index].Value = posicion + 1;
            }

        }

        #endregion Cierre

        #region Cargas

        /// <summary>
        /// Clic en el botón de seleccionar cargas asignadas pendientes.
        /// </summary>
        private void btnCargasPendientes_Click(object sender, EventArgs e)
        {

            try
            {
                frmCargasPendientes formulario = new frmCargasPendientes(_cierre);

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
                    CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;

                    carga.Cierre = null;

                    _coordinacion.actualizarCargaATMCierreATMs(carga);

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
            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;

            frmIngresoManifiestoATMs formulario = new frmIngresoManifiestoATMs(carga);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de verificar carga.
        /// </summary>
        private void btnRevisionCarga_Click(object sender, EventArgs e)
        {
            frmVerificacionCarga formulario = new frmVerificacionCarga(_carga);

            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
                this.validarOpcionesCarga();

                btnCargasPendientes.Enabled = _cierre.Cargas_listas;
            }

        }

        /// <summary>
        /// Clic en el botón de imprimir carga.
        /// </summary>
        private void btnImprimirCarga_Click(object sender, EventArgs e)
        {
            this.imprimirHojaCarga();
        }

        /// <summary>
        /// Se selecciona otra carga en la lista de cargas.
        /// </summary
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                _carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
                this.mostrarDatosCargaATM();
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
                CargaATM carga = (CargaATM)fila.DataBoundItem;

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
      
                CartuchoCargaATM cartucho = (CartuchoCargaATM)celda.OwningRow.DataBoundItem;
                CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
                Denominacion denominacion = cartucho.Denominacion;
                ImageList lista = null;

                switch (carga.Tipo)
                {
                    case TiposCartucho.Opteva:
                        lista = imlConfiguracionOpteva;
                        break;
                    case TiposCartucho.Diebold:
                        lista = imlConfiguracionDiebold;
                        break;
                }

               // celda.Style.SelectionBackColor = _colores[(byte)denominacion.Id_imagen];
                //dgvMontosCarga.Rows[celda.RowIndex].DefaultCellStyle.BackColor = _colores[(byte)denominacion.Id_imagen];
                pbConfiguracion.Image = lista.Images[(byte)denominacion.Id_imagen];
                pbDenominacion.Image = imlBilletes.Images[(byte)denominacion.Id_imagen];
                dgvMontosCarga.Refresh();
                
            }
            else
            {
                pbDenominacion.Image = null;
                pbConfiguracion.Image = null;

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

                    CartuchoCargaATM cartucho_carga = (CartuchoCargaATM)fila.DataBoundItem;

                    cartucho_carga.Cartucho.Transportadora = new EmpresaTransporte(id: 5);
                    _coordinacion.actualizarCartuchoCargaATM(cartucho_carga, _usuario);

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

            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
            CartuchoCargaATM cartucho_carga = (CartuchoCargaATM)fila.DataBoundItem;

            if (e.Value == null || e.Value.Equals(string.Empty))
                return;

            if (e.ColumnIndex == NumeroMarchamoCarga.Index)
                return;

            try
            {
                string numero_cartucho = e.Value.ToString();
                TiposCartucho tipo_cartucho = carga.Tipo;
                Denominacion denominacion_cartucho = cartucho_carga.Denominacion;

                Cartucho cartucho = new Cartucho(numero_cartucho);

                if (_mantenimiento.verificarCartucho(ref cartucho))
                {

                    if (cartucho.Tipo != tipo_cartucho)
                    {

                        if (Mensaje.mostrarMensajeConfirmacion("MensajeCartuchoTipoCarga") == DialogResult.Yes)
                            cartucho.Tipo = tipo_cartucho;

                    }

                    if (!cartucho.Denominacion.Equals(denominacion_cartucho))
                    {

                        if (Mensaje.mostrarMensajeConfirmacion("MensajeCartuchoDenominacionCarga") == DialogResult.Yes)
                            cartucho.Denominacion = denominacion_cartucho;

                    }


                    if (cartucho.Estado == EstadosCartuchos.Malo || cartucho.Estado == EstadosCartuchos.EntregadoTaller)
                    {

                        if (Mensaje.mostrarMensajeConfirmacion("MensajeCartuchoEstadoCarga") == DialogResult.Yes)
                            cartucho.Estado = EstadosCartuchos.Bueno;

                    }

                }
                else
                {
                    cartucho.Tipo = tipo_cartucho;
                    cartucho.Denominacion = denominacion_cartucho;
                }

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

            if (e.ColumnIndex != NumeroCartuchoCarga.Index || e.FormattedValue.Equals(string.Empty))
                return;

            short valor;

            if (!short.TryParse(e.FormattedValue.ToString(), out valor))
                e.Cancel = true;

        }

        /// <summary>
        /// La lista de cartuchos de una carga obtiene el foco.
        /// </summary>
        private void dgvMontosCarga_Enter(object sender, EventArgs e)
        {

            if (dgvMontosCarga.RowCount > 0)
                dgvMontosCarga[NumeroCartuchoCarga.Index, 0].Selected = true;

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
        /// Clic en el boton de Finalizar Carga
        /// </summary>
        private void btnFinalizarCarga_Click(object sender, EventArgs e)
        {
            dtpHoraFinCarga.Value = DateTime.Now;
        }



        /// <summary>
        /// Cambia el color dependiendo de la denominación
        /// </summary>
        private void dgvMontosCarga_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            foreach (DataGridViewRow r in dgvMontosCarga.Rows)
            {
                CartuchoCargaATM cartucho = (CartuchoCargaATM)r.DataBoundItem;

                r.DefaultCellStyle.BackColor = _colores[(byte)cartucho.Denominacion.Id_imagen];

                dgvMontosCarga.Refresh();
            }
           
            

        }

        #endregion Cargas

        #region Descargas

        /// <summary>
        /// Clic en el botón de seleccionar las descargas pendientes.
        /// </summary>
        private void btnDescargasPendientes_Click(object sender, EventArgs e)
        {

            try
            {
                frmDescargasPendientes formulario = new frmDescargasPendientes(_cierre);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de devolver una descarga.
        /// </summary>
        private void btnDevolverDescarga_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeDescargaATMDevolucion") == DialogResult.Yes)
                {
                    DescargaATM descarga = (DescargaATM)dgvDescargas.SelectedRows[0].DataBoundItem;

                    _coordinacion.eliminarDescargaATM(descarga);

                    dgvDescargas.Rows.Remove(dgvDescargas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeDescargaATMConfirmacionDevolucion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de imprimir una descarga.
        /// </summary>
        private void btnImprimirDescarga_Click(object sender, EventArgs e)
        {
            this.imprimirDescarga();
        }

        /// <summary>
        /// Se presiona el botón de finalizar descarga.
        /// </summary>
        private void btnMarcarFinDescarga_Click(object sender, EventArgs e)
        {
            dtpHoraFinDescarga.Value = DateTime.Now;
        }

        /// <summary>
        /// Clic en el botón de imprimir las descargas.
        /// </summary>
        private void btnImprimirDescargas_Click(object sender, EventArgs e)
        {
            this.imprimirDescargas();
        }

        /// <summary>
        /// Clic en el botón de seleccionar el manifiesto de una descarga.
        /// </summary>
        private void btnSeleccionarManifiestoDescarga_Click(object sender, EventArgs e)
        {
            DescargaATM descarga = (DescargaATM)dgvDescargas.SelectedRows[0].DataBoundItem;

            frmSeleccionManifiestoDescargaATM formulario = new frmSeleccionManifiestoDescargaATM(descarga);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de imprimir las diferencias de una descarga.
        /// </summary>
        private void btnImprimirDiferenciasDescarga_Click(object sender, EventArgs e)
        {
            this.imprimirDiferenciasDescarga();
        }

        /// <summary>
        /// Se selecciona otra descarga en la lista de descargas.
        /// </summary
        private void dgvDescargas_SelectionChanged(object sender, EventArgs e)
        {
            

            if (dgvDescargas.SelectedRows.Count > 0)
            {
                _descarga = (DescargaATM)dgvDescargas.SelectedRows[0].DataBoundItem;
                this.mostrarDatosDescargaATM();
            }
            else
            {
                _descarga = null;
                this.limpiarDatosDescarga();
            }

        }

        /// <summary>
        /// Se cambia la cantidad de fórmulas descargadas de un cartucho de una descarga.
        /// </summary
        private void dgvMontosDescarga_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosDescarga.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontosDescarga.Rows[e.RowIndex];
                    TiposFila tipo = (TiposFila)fila.Cells[TipoFilaDescarga.Index].Value;
                    short cantidad = (short)fila.Cells[CantidadCartuchoDescarga.Index].Value;

                    switch (tipo)
                    {
                        case TiposFila.Cartucho:
                            CartuchoCargaATM cartucho = (CartuchoCargaATM)fila.Cells[ObjetoDescarga.Index].Value;

                            cartucho.Cantidad_descarga = cantidad;

                            _coordinacion.actualizarCartuchoCargaATMCantidadDescarga(cartucho);

                            fila.Cells[MontoCartuchoDescarga.Index].Value = cartucho.Monto_descarga;

                            break;
                        case TiposFila.Rechazo:
                            RechazoDescargaATM rechazo = (RechazoDescargaATM)fila.Cells[ObjetoDescarga.Index].Value;

                            rechazo.Cantidad_descarga = cantidad;

                            _coordinacion.actualizarRechazoDescargaATM(rechazo);

                            fila.Cells[MontoCartuchoDescarga.Index].Value = rechazo.Monto_descarga;

                            break;
                    }

                    this.actualizarTotalesMontosDescarga();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se valida la cantidad descargada de un cartucho.
        /// </summary
        private void dgvMontosDescarga_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            short cantidad = 0;

            string valor_cantidad = e.Value.ToString();

            valor_cantidad = valor_cantidad.Replace(",", string.Empty);
            valor_cantidad = valor_cantidad.Replace(".", string.Empty);

            short.TryParse(valor_cantidad, out cantidad);

            e.Value = cantidad;
            e.ParsingApplied = true;
        }

        /// <summary>
        /// Validar la asignación de la cantidad de fórmulas descargadas de un cartucho.
        /// </summary
        private void dgvMontosDescarga_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex != CantidadCartuchoDescarga.Index || e.FormattedValue.Equals(string.Empty))
                return;

            short valor;

            string valor_formato = e.FormattedValue.ToString();

            valor_formato = valor_formato.Replace(",", string.Empty);
            valor_formato = valor_formato.Replace(".", string.Empty);

            if (!short.TryParse(valor_formato, out valor))
                e.Cancel = true;

        }

        /// <summary>
        /// Se cambia la cantidad del contador de una descarga.
        /// </summary
        private void dgvContadoresDescarga_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvContadoresDescarga.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvContadoresDescarga.Rows[e.RowIndex];
                    ContadorDescargaATM contador = (ContadorDescargaATM)fila.DataBoundItem;

                    _coordinacion.actualizarContadorDescargaATM(contador);

                    this.actualizarTotalesMontosDescarga();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se valida las cantidades de los contadores de una descarga.
        /// </summary
        private void dgvContadoresDescarga_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            short cantidad = 0;

            string valor_cantidad = e.Value.ToString();

            valor_cantidad = valor_cantidad.Replace(",", string.Empty);
            valor_cantidad = valor_cantidad.Replace(".", string.Empty);

            short.TryParse(valor_cantidad, out cantidad);

            e.Value = cantidad;
            e.ParsingApplied = true;
        }

        /// <summary>
        /// La lista de cartuchos de una descarga obtiene el foco.
        /// </summary>
        private void dgvMontosDescarga_Enter(object sender, EventArgs e)
        {

            if (dgvMontosDescarga.RowCount > 0)
                dgvMontosDescarga[MontoCartuchoDescarga.Index, 0].Selected = true;

        }

        /// <summary>
        /// Se selecciona otra fecha para una descarga.
        /// </summary
        private void dtpFechaDescarga_ValueChanged(object sender, EventArgs e)
        {
            this.guardarDescarga();
        }

        /// <summary>
        /// Se selecciona otra hora de inicio para una descarga.
        /// </summary
        private void dtpHoraInicioDescarga_ValueChanged(object sender, EventArgs e)
        {
            this.guardarDescarga();
        }

        /// <summary>
        /// Se selecciona otra hora de finalización para una descarga.
        /// </summary
        private void dtpHoraFinDescarga_ValueChanged(object sender, EventArgs e)
        {
            this.guardarDescarga();
        }

        /// <summary>
        /// Se selecciona otra hora para una diferencia.
        /// </summary
        private void dtpHoraDiferenciaDescarga_ValueChanged(object sender, EventArgs e)
        {
            this.guardarDescarga();
        }

        /// <summary>
        /// El cuadro de texto del comentario de una descarga pierde el foco.
        /// </summary
        private void txtObservacionesDescarga_Leave(object sender, EventArgs e)
        {
            this.guardarDescarga();
        }

        #region Descargas

        #endregion Descargas Full

        /// <summary>
        /// Clic en el botón de devolver una descarga full.
        /// </summary>
        private void btnDevolverDescargaFull_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeDescargaATMFullDevolucion") == DialogResult.Yes)
                {
                    DescargaATMFull descarga = (DescargaATMFull)dgvDescargasFull.SelectedRows[0].DataBoundItem;

                    _coordinacion.eliminarDescargaATMFull(descarga);

                    dgvDescargasFull.Rows.Remove(dgvDescargasFull.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeDescargaATMFullConfirmacionDevolucion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de imprimir una descarga full.
        /// </summary>
        private void btnImprimirDescargaFull_Click(object sender, EventArgs e)
        {
            this.imprimirDescargaFull();
        }

        /// <summary>
        /// Se presiona el botón de finalizar descarga full.
        /// </summary>
        private void btnMarcarFinDescargaFull_Click(object sender, EventArgs e)
        {
            dtpHoraFinDescargaFull.Value = DateTime.Now;
        }

        /// <summary>
        /// Clic en el botón de imprimir las descargas full.
        /// </summary>
        private void btnImprimirDescargasFull_Click(object sender, EventArgs e)
        {
            this.imprimirDescargasFull();
        }

        /// <summary>
        /// Clic en el botón de seleccionar el manifiesto de una descarga full.
        /// </summary>
        private void btnSeleccionarManifiestoDescargaFull_Click(object sender, EventArgs e)
        {
            DescargaATMFull descarga = (DescargaATMFull)dgvDescargasFull.SelectedRows[0].DataBoundItem;
            frmSeleccionManifiestoDescargaATMFull formulario = new frmSeleccionManifiestoDescargaATMFull(descarga);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de imprimir las diferencias de una descarga full.
        /// </summary>
        private void btnImprimirDiferenciasDescargaFull_Click(object sender, EventArgs e)
        {
            this.imprimirDiferenciasDescargaFull();
        }

        /// <summary>
        /// Se selecciona otra descarga en la lista de descargas full.
        /// </summary
        private void dgvDescargasFull_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDescargasFull.SelectedRows.Count > 0)
            {
                _descarga_full = (DescargaATMFull)dgvDescargasFull.SelectedRows[0].DataBoundItem;
                this.mostrarDatosDescargaATMFull();
            }
            else
            {
                _descarga_full = null;
                this.limpiarDatosDescargaFull();
            }

        }

        /// <summary>
        /// Se cambia la cantidad de fórmulas descargadas de un BNA full.
        /// </summary
        private void dgvMontosDescargaFull_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosDescargaFull.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontosDescargaFull.Rows[e.RowIndex];
                    TiposFila tipo = (TiposFila)fila.Cells[TipoFilaDescargaFull.Index].Value;
                    short cantidad = (short)fila.Cells[CantidadDescargaFull.Index].Value;
                    MontoDescargaATMFull monto = (MontoDescargaATMFull)fila.Cells[ObjetoDescargaFull.Index].Value;

                    monto.Cantidad = cantidad;

                    _coordinacion.actualizarMontoDescargaATMFull(monto);

                    fila.Cells[MontoCartuchoDescarga.Index].Value = monto.Monto_descarga;
                    
                    this.actualizarTotalesMontosDescargaFull();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se valida la cantidad descargada de un BNA.
        /// </summary
        private void dgvMontosDescargaFull_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            short cantidad = 0;

            string valor_cantidad = e.Value.ToString();

            valor_cantidad = valor_cantidad.Replace(",", string.Empty);
            valor_cantidad = valor_cantidad.Replace(".", string.Empty);

            short.TryParse(valor_cantidad, out cantidad);

            e.Value = cantidad;
            e.ParsingApplied = true;
        }

        /// <summary>
        /// Validar la asignación de la cantidad de fórmulas descargadas de un BNA.
        /// </summary
        private void dgvMontosDescargaFull_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex != CantidadDescargaFull.Index || e.FormattedValue.Equals(string.Empty))
                return;

            short valor;

            string valor_formato = e.FormattedValue.ToString();

            valor_formato = valor_formato.Replace(",", string.Empty);
            valor_formato = valor_formato.Replace(".", string.Empty);

            if (!short.TryParse(valor_formato, out valor))
                e.Cancel = true;

        }

        /// <summary>
        /// Se cambia la cantidad del contador de una descarga full.
        /// </summary
        private void dgvContadoresDescargaFull_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvContadoresDescargaFull.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvContadoresDescargaFull.Rows[e.RowIndex];
                    ContadorDescargaATMFull contador = (ContadorDescargaATMFull)fila.DataBoundItem;

                    _coordinacion.actualizarContadorDescargaATMFull(contador);

                    this.actualizarTotalesMontosDescargaFull();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }
        
        /// <summary>
        /// Se valida las cantidades de los contadores de una descarga full.
        /// </summary
        private void dgvContadoresDescargaFull_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            short cantidad = 0;

            string valor_cantidad = e.Value.ToString();

            valor_cantidad = valor_cantidad.Replace(",", string.Empty);
            valor_cantidad = valor_cantidad.Replace(".", string.Empty);

            short.TryParse(valor_cantidad, out cantidad);

            e.Value = cantidad;
            e.ParsingApplied = true;
        }

        /// <summary>
        /// La lista de montos de una descarga full obtiene el foco.
        /// </summary>
        private void dgvMontosDescargaFull_Enter(object sender, EventArgs e)
        {

            if (dgvMontosDescargaFull.RowCount > 0)
                dgvMontosDescargaFull[MontoCartuchoDescarga.Index, 0].Selected = true;

        }

        /// <summary>
        /// Clic en el botón de seleccionar las descargas full pendientes.
        /// </summary>
        private void btnDescargasFullPendientes_Click(object sender, EventArgs e)
        {

            try
            {
                frmDescargasFullPendientes formulario = new frmDescargasFullPendientes(_cierre);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se selecciona otra fecha para una descarga full.
        /// </summary
        private void dtpFechaDescargaFull_ValueChanged(object sender, EventArgs e)
        {
            this.guardarDescargaFull();
        }

        /// <summary>
        /// Se selecciona otra hora de inicio para una descarga full.
        /// </summary
        private void dtpHoraInicioDescargaFull_ValueChanged(object sender, EventArgs e)
        {
            this.guardarDescargaFull();
        }

        /// <summary>
        /// Se selecciona otra hora de finalización para una descarga full.
        /// </summary
        private void dtpHoraFinDescargaFull_ValueChanged(object sender, EventArgs e)
        {
            this.guardarDescargaFull();
        }

        /// <summary>
        /// Se selecciona otra hora para una diferencia de una descarga full.
        /// </summary
        private void dtpHoraDiferenciaDescargaFull_ValueChanged(object sender, EventArgs e)
        {
            this.guardarDescargaFull();
        }

        /// <summary>
        /// El cuadro de texto del comentario de una descarga full pierde el foco.
        /// </summary
        private void txtObservacionesDescargaFull_Leave(object sender, EventArgs e)
        {
            this.guardarDescargaFull();
        }

        #endregion Descargas Full


        #region Montos de Cierre

        /// <summary>
        /// Mostrar los montos descargados por denominación.
        /// </summary
        private void btnMontosDescargas_Click(object sender, EventArgs e)
        {
            frmMontosDenominacionDescargas formulario = new frmMontosDenominacionDescargas(_cierre.Descargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Mostrar los montos de las descargas full por denominación.
        /// </summary
        private void button1_Click(object sender, EventArgs e)
        {
            frmMontosDenominacionDescargas formulario = new frmMontosDenominacionDescargas(_cierre.Descargas_full);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Validar la asignación de la cantidad de fórmulas del monto en mesa de descargas de un cierre de ATM's.
        /// </summary
        private void dgvMontosMesaDescargas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex != CantidadMontoMesaDescargas.Index || e.FormattedValue.Equals(string.Empty))
                return;

            int valor;

            string valor_formato = e.FormattedValue.ToString();

            valor_formato = valor_formato.Replace(",", string.Empty);
            valor_formato = valor_formato.Replace(".", string.Empty);

            if (!int.TryParse(valor_formato, out valor))
                e.Cancel = true;

        }

        /// <summary>
        /// Validar la asignación de la cantidad de fórmulas del monto en mesa de descargas full de un cierre de ATM's.
        /// </summary
        private void dgvMontosMesaDescargasFull_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex != CantidadMontoMesaDescargasFull.Index || e.FormattedValue.Equals(string.Empty))
                return;

            int valor;

            string valor_formato = e.FormattedValue.ToString();

            valor_formato = valor_formato.Replace(",", string.Empty);
            valor_formato = valor_formato.Replace(".", string.Empty);

            if (!int.TryParse(valor_formato, out valor))
                e.Cancel = true;

        }

        /// <summary>
        /// Se cambia la cantidad de un monto en mesa de descargas de un cierre de ATM's.
        /// </summary
        private void dgvMontosMesaDescargas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosMesaDescargas.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontosMesaDescargas.Rows[e.RowIndex];
                    DataGridViewCell celda = fila.Cells[e.ColumnIndex];

                    MontoCierreATMs monto = (MontoCierreATMs)fila.DataBoundItem;

                    _coordinacion.actualizarMontoCierreATMs(monto);

                    this.actualizarTotalesMontosCierre();

                    dgvMontosMesaDescargas.Refresh();
                    dgvMontosMesaDescargas.AutoResizeColumns();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se cambia la cantidad de un monto en mesa de descargas full de un cierre de ATM's.
        /// </summary
        private void dgvMontosMesaDescargasFull_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosMesaDescargasFull.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontosMesaDescargasFull.Rows[e.RowIndex];
                    DataGridViewCell celda = fila.Cells[e.ColumnIndex];

                    MontoCierreATMs monto = (MontoCierreATMs)fila.DataBoundItem;

                    _coordinacion.actualizarMontoCierreATMs(monto);

                    this.actualizarTotalesMontosCierre();

                    dgvMontosMesaDescargasFull.Refresh();
                    dgvMontosMesaDescargasFull.AutoResizeColumns();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se valida las cantidades de los montos en mesa de descargas de un cierre de ATM's.
        /// </summary
        private void dgvMontosMesaDescargas_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            int cantidad = 0;

            string valor_cantidad = e.Value.ToString();

            valor_cantidad = valor_cantidad.Replace(",", string.Empty);
            valor_cantidad = valor_cantidad.Replace(".", string.Empty);

            int.TryParse(valor_cantidad, out cantidad);

            e.Value = cantidad;
            e.ParsingApplied = true;
        }

        /// <summary>
        /// Se valida las cantidades de los montos en mesa de descargas full de un cierre de ATM's.
        /// </summary
        private void dgvMontosMesaDescargasFull_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            int cantidad = 0;

            string valor_cantidad = e.Value.ToString();

            valor_cantidad = valor_cantidad.Replace(",", string.Empty);
            valor_cantidad = valor_cantidad.Replace(".", string.Empty);

            int.TryParse(valor_cantidad, out cantidad);

            e.Value = cantidad;
            e.ParsingApplied = true;
        }

        /// <summary>
        /// Validar la asignación de la cantidad de fórmulas del monto en cola de descargas de un cierre de ATM's.
        /// </summary
        private void dgvMontosColaDescargas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex != CantidadMontoColaDescargas.Index || e.FormattedValue.Equals(string.Empty))
                return;

            short valor;

            string valor_formato = e.FormattedValue.ToString();

            valor_formato = valor_formato.Replace(",", string.Empty);
            valor_formato = valor_formato.Replace(".", string.Empty);

            if (!short.TryParse(e.FormattedValue.ToString(), out valor))
                e.Cancel = true;

        }

        /// <summary>
        /// Validar la asignación de la cantidad de fórmulas del monto en cola de descargas full de un cierre de ATM's.
        /// </summary
        private void dgvMontosColaDescargasFull_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex != CantidadMontoColaDescargasFull.Index || e.FormattedValue.Equals(string.Empty))
                return;

            short valor;

            string valor_formato = e.FormattedValue.ToString();

            valor_formato = valor_formato.Replace(",", string.Empty);
            valor_formato = valor_formato.Replace(".", string.Empty);

            if (!short.TryParse(e.FormattedValue.ToString(), out valor))
                e.Cancel = true;

        }

        /// <summary>
        /// Se cambia la cantidad de un monto en cola de descargas de un cierre de ATM's.
        /// </summary
        private void dgvMontosColaDescargas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosColaDescargas.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontosColaDescargas.Rows[e.RowIndex];
                    DataGridViewCell celda = fila.Cells[e.ColumnIndex];

                    MontoCierreATMs monto = (MontoCierreATMs)fila.DataBoundItem;

                    _coordinacion.actualizarMontoCierreATMs(monto);

                    this.actualizarTotalesMontosCierre();

                    dgvMontosColaDescargas.Refresh();
                    dgvMontosColaDescargas.AutoResizeColumns();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se cambia la cantidad de un monto en cola de descargas full de un cierre de ATM's.
        /// </summary
        private void dgvMontosColaDescargasFull_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosColaDescargasFull.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontosColaDescargasFull.Rows[e.RowIndex];
                    DataGridViewCell celda = fila.Cells[e.ColumnIndex];

                    MontoCierreATMs monto = (MontoCierreATMs)fila.DataBoundItem;

                    _coordinacion.actualizarMontoCierreATMs(monto);

                    this.actualizarTotalesMontosCierre();

                    dgvMontosColaDescargasFull.Refresh();
                    dgvMontosColaDescargasFull.AutoResizeColumns();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se valida las cantidades de los montos en cola de descargas de un cierre de ATM's.
        /// </summary
        private void dgvMontosColaDescargas_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            short cantidad = 0;

            string valor_cantidad = e.Value.ToString();

            valor_cantidad = valor_cantidad.Replace(",", string.Empty);
            valor_cantidad = valor_cantidad.Replace(".", string.Empty);

            short.TryParse(valor_cantidad, out cantidad);

            e.Value = cantidad;
            e.ParsingApplied = true;
        }

        /// <summary>
        /// Se valida las cantidades de los montos en cola de descargas full de un cierre de ATM's.
        /// </summary
        private void dgvMontosColaDescargasFull_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            short cantidad = 0;

            string valor_cantidad = e.Value.ToString();

            valor_cantidad = valor_cantidad.Replace(",", string.Empty);
            valor_cantidad = valor_cantidad.Replace(".", string.Empty);

            short.TryParse(valor_cantidad, out cantidad);

            e.Value = cantidad;
            e.ParsingApplied = true;
        }

        #endregion Montos de Cierre

        #region Otros

        /// <summary>
        /// Clic en el botón de marcar un cartucho dañado.
        /// </summary>
        private void btnMarcarCartuchoDanado_Click(object sender, EventArgs e)
        {
            frmMarcacionCartuchosDanados formulario = new frmMarcacionCartuchosDanados(_usuario);

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otra pestaña de la ventana de cierre.
        /// </summary>
        private void tcDatos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tcDatos.SelectedTab == tpCierre)
                this.actualizarTotalesMontosCierre();

            if (tcDatos.SelectedTab == tpCargas)
                btnMarcarCartuchoDanado.Enabled = false;
            else
                btnMarcarCartuchoDanado.Enabled = true;


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
            NumeroCartuchoCarga.DefaultCellStyle.Font = fuente;
            NumeroMarchamoCarga.DefaultCellStyle.Font = fuente;

            DenominacionCartuchoDescarga.DefaultCellStyle.Font = fuente;
            CantidadCartuchoDescarga.DefaultCellStyle.Font = fuente;
            MontoCartuchoDescarga.DefaultCellStyle.Font = fuente;
            NumeroCartuchoDescarga.DefaultCellStyle.Font = fuente;
            NumeroMarchamoDescarga.DefaultCellStyle.Font = fuente;

            dgvContadoresDescarga.DefaultCellStyle.Font = fuente;
            dgvDiferenciasContadoresDescarga.DefaultCellStyle.Font = fuente;
            dgvDiferenciasRemanentesDescarga.DefaultCellStyle.Font = fuente;
            dgvMontosColaDescargas.DefaultCellStyle.Font = fuente;
            dgvMontosMesaDescargas.DefaultCellStyle.Font = fuente;
            dgvTotalesDescargas.DefaultCellStyle.Font = fuente;
           

            DenominacionDescargaFull.DefaultCellStyle.Font = fuente;
            CantidadDescargaFull.DefaultCellStyle.Font = fuente;
            MontoDescargaFull.DefaultCellStyle.Font = fuente;

            dgvContadoresDescargaFull.DefaultCellStyle.Font = fuente;
            dgvDiferenciasDescargaFull.DefaultCellStyle.Font = fuente;
            dgvMontosColaDescargasFull.DefaultCellStyle.Font = fuente;
            dgvMontosMesaDescargasFull.DefaultCellStyle.Font = fuente;
            dgvTotalesDescargasFull.DefaultCellStyle.Font = fuente;

        }

        #endregion Otros

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Imprimir las diferencias de una descarga.
        /// </summary>
        private void imprimirDiferenciasDescarga()
        {

            try
            {
                BindingList<DetalleDescargaATM> faltantes_colones_remanente = new BindingList<DetalleDescargaATM>();
                BindingList<DetalleDescargaATM> faltantes_dolares_remanente = new BindingList<DetalleDescargaATM>();
                BindingList<DetalleDescargaATM> sobrante_colones_remanente = new BindingList<DetalleDescargaATM>();
                BindingList<DetalleDescargaATM> sobrante_dolares_remanente = new BindingList<DetalleDescargaATM>();

                BindingList<DetalleDescargaATM> faltantes_colones_contadores = new BindingList<DetalleDescargaATM>();
                BindingList<DetalleDescargaATM> faltantes_dolares_contadores = new BindingList<DetalleDescargaATM>();
                BindingList<DetalleDescargaATM> sobrante_colones_contadores = new BindingList<DetalleDescargaATM>();
                BindingList<DetalleDescargaATM> sobrante_dolares_contadores = new BindingList<DetalleDescargaATM>();

                foreach (DetalleDescargaATM detalle in _descarga.Detalles_Colones)
                {

                    if (detalle.Cantidad_diferencia_remanente > 0)
                        sobrante_colones_remanente.Add(detalle);
                    else if (detalle.Cantidad_diferencia_remanente < 0)
                        faltantes_colones_remanente.Add(detalle);

                    if (detalle.Cantidad_diferencia_contador > 0)
                        sobrante_colones_contadores.Add(detalle);
                    else if (detalle.Cantidad_diferencia_contador < 0)
                        faltantes_colones_contadores.Add(detalle);

                }

                foreach (DetalleDescargaATM detalle in _descarga.Detalles_Dolares)
                {

                    if (detalle.Cantidad_diferencia_remanente > 0)
                        sobrante_dolares_remanente.Add(detalle);
                    else if (detalle.Cantidad_diferencia_remanente < 0)
                        faltantes_dolares_remanente.Add(detalle);

                    if (detalle.Cantidad_diferencia_contador > 0)
                        sobrante_dolares_contadores.Add(detalle);
                    else if (detalle.Cantidad_diferencia_contador < 0)
                        faltantes_dolares_contadores.Add(detalle);

                }

                this.imprimirDiferenciaDescarga(Monedas.Colones, TiposDiferencia.FaltanteRemanente, faltantes_colones_remanente);
                this.imprimirDiferenciaDescarga(Monedas.Colones, TiposDiferencia.SobranteRemanente, sobrante_colones_remanente);
                this.imprimirDiferenciaDescarga(Monedas.Colones, TiposDiferencia.FaltanteContadores, faltantes_colones_contadores);
                this.imprimirDiferenciaDescarga(Monedas.Colones, TiposDiferencia.SobranteContadores, sobrante_colones_contadores);

                this.imprimirDiferenciaDescarga(Monedas.Dolares, TiposDiferencia.FaltanteRemanente, faltantes_dolares_remanente);
                this.imprimirDiferenciaDescarga(Monedas.Dolares, TiposDiferencia.SobranteRemanente, sobrante_dolares_remanente);
                this.imprimirDiferenciaDescarga(Monedas.Dolares, TiposDiferencia.FaltanteContadores, faltantes_dolares_contadores);
                this.imprimirDiferenciaDescarga(Monedas.Dolares, TiposDiferencia.SobranteContadores, sobrante_dolares_contadores);
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Imprimir la hoja la hoja de una diferencia de una descarga.
        /// </summary>
        private void imprimirDiferenciaDescarga(Monedas moneda, TiposDiferencia tipo_diferencia, BindingList<DetalleDescargaATM> detalles)
        {
            if (detalles.Count == 0) return;

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla diferencia.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("E16");
                documento.actualizarValorCelda(_descarga.ATM.Numero);

                documento.seleccionarCelda("M20");
                documento.actualizarValorCelda(dtpHoraDiferenciaDescarga.Value.ToString("HH:mm"));

                documento.seleccionarCelda("J20");
                documento.actualizarValorCelda(_cierre.Camara.Identificador);

                documento.seleccionarCelda("F18");
                documento.actualizarValorCelda(_descarga.Codigo_manifiesto);

                documento.seleccionarCelda("L18");
                documento.actualizarValorCelda(_descarga.Codigo_marchamo);

                switch(tipo_diferencia)
                {
                    case TiposDiferencia.FaltanteRemanente: case TiposDiferencia.FaltanteContadores:
                        documento.seleccionarCelda("D10");
                        documento.actualizarValorCelda("X");
                        break;
                    case TiposDiferencia.SobranteRemanente: case TiposDiferencia.SobranteContadores:
                        documento.seleccionarCelda("I10");
                        documento.actualizarValorCelda("X");
                        break;
                }

                switch(moneda)
                {
                    case Monedas.Colones:
                        documento.seleccionarCelda("D12");
                        documento.actualizarValorCelda("X");
                        break;
                    case Monedas.Dolares:
                        documento.seleccionarCelda("I12");
                        documento.actualizarValorCelda("X");
                        break;
                }

                // Imprimir el monto y las diferencias por denominación

                decimal monto = 0;
                string formulas = string.Empty;

                foreach (DetalleDescargaATM detalle in detalles)
                {

                    switch(tipo_diferencia)
                    {
                        case TiposDiferencia.FaltanteContadores:
                        case TiposDiferencia.SobranteContadores:
                            monto += detalle.Monto_diferencia_contador;
                            formulas += detalle.Cantidad_diferencia_contador + " Fórmulas de " + detalle.Denominacion.ToString();
                            break;
                        case TiposDiferencia.FaltanteRemanente:
                        case TiposDiferencia.SobranteRemanente:
                            monto += detalle.Monto_diferencia_remanente;
                            formulas += detalle.Cantidad_diferencia_remanente + " Fórmulas de " + detalle.Denominacion.ToString();
                            break;
                    }

                }


                //switch (moneda)
                //{
                //    case Monedas.Colones:
                //        documento.seleccionarCelda("D12");
                //        documento.actualizarValorCelda("X");
                //        break;
                //    case Monedas.Dolares:
                //        documento.seleccionarCelda("I12");
                //        documento.actualizarValorCelda("X");
                //        break;
                //}
                documento.seleccionarCelda("G34");
                documento.actualizarValorCelda(monto.ToString("N2"));

                documento.seleccionarCelda("C37");
                documento.actualizarValorCelda(formulas.Trim());

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Imprimir las diferencias de una descarga full.
        /// </summary>
        private void imprimirDiferenciasDescargaFull()
        {

            try
            {
                BindingList<DetalleDescargaATMFull> faltantes_colones = new BindingList<DetalleDescargaATMFull>();
                BindingList<DetalleDescargaATMFull> faltantes_dolares = new BindingList<DetalleDescargaATMFull>();
                BindingList<DetalleDescargaATMFull> sobrante_colones = new BindingList<DetalleDescargaATMFull>();
                BindingList<DetalleDescargaATMFull> sobrante_dolares = new BindingList<DetalleDescargaATMFull>();

                foreach (DetalleDescargaATMFull detalle in _descarga_full.Detalles_Colones)
                {

                    if (detalle.Cantidad_diferencia > 0)
                        sobrante_colones.Add(detalle);
                    else if (detalle.Cantidad_diferencia < 0)
                        faltantes_colones.Add(detalle);

                }

                foreach (DetalleDescargaATMFull detalle in _descarga_full.Detalles_Dolares)
                {

                    if (detalle.Cantidad_diferencia > 0)
                        sobrante_dolares.Add(detalle);
                    else if (detalle.Cantidad_diferencia < 0)
                        faltantes_dolares.Add(detalle);

                }

                this.imprimirDiferenciaDescargaFull(Monedas.Colones, TiposDiferencia.FaltanteDepositos, faltantes_colones);
                this.imprimirDiferenciaDescargaFull(Monedas.Colones, TiposDiferencia.SobranteDepositos, sobrante_colones);
                this.imprimirDiferenciaDescargaFull(Monedas.Dolares, TiposDiferencia.FaltanteDepositos, faltantes_dolares);
                this.imprimirDiferenciaDescargaFull(Monedas.Dolares, TiposDiferencia.SobranteDepositos, sobrante_dolares);
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Imprimir la hoja la hoja de una diferencia de una descarga full.
        /// </summary>
        private void imprimirDiferenciaDescargaFull(Monedas moneda, TiposDiferencia tipo_diferencia, BindingList<DetalleDescargaATMFull> detalles)
        {
            if (detalles.Count == 0) return;

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla diferencia.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("E16");
                documento.actualizarValorCelda(_descarga_full.ATM.Numero);

                documento.seleccionarCelda("M20");
                documento.actualizarValorCelda(dtpHoraDiferenciaDescargaFull.Value.ToString("HH:mm"));

                documento.seleccionarCelda("J20");
                documento.actualizarValorCelda(_cierre.Camara.Identificador);

                documento.seleccionarCelda("F18");
                documento.actualizarValorCelda(_descarga_full.Codigo_manifiesto);

                documento.seleccionarCelda("L18");
                documento.actualizarValorCelda(_descarga_full.Codigo_marchamo);

                switch (tipo_diferencia)
                {
                    case TiposDiferencia.FaltanteDepositos:
                        documento.seleccionarCelda("D10");
                        documento.actualizarValorCelda("X");
                        break;
                    case TiposDiferencia.SobranteDepositos:
                        documento.seleccionarCelda("I10");
                        documento.actualizarValorCelda("X");
                        break;
                }

                switch (moneda)
                {
                    case Monedas.Colones:
                        documento.seleccionarCelda("D12");
                        documento.actualizarValorCelda("X");
                        break;
                    case Monedas.Dolares:
                        documento.seleccionarCelda("I12");
                        documento.actualizarValorCelda("X");
                        break;
                }

                // Imprimir el monto y las diferencias por denominación

                decimal monto = 0;
                string formulas = string.Empty;

                foreach (DetalleDescargaATMFull detalle in detalles)
                {
                    monto += detalle.Monto_diferencia;
                    formulas += detalle.Cantidad_diferencia + " Fórmulas de " + detalle.Denominacion.ToString();
                }



                switch (moneda)
                {
                    case Monedas.Colones:
                         documento.seleccionarCelda("G34");
                         documento.actualizarValorCelda(monto.ToString("N2"));

                         documento.seleccionarCelda("C37");
                         documento.actualizarValorCelda(formulas.Trim());
                        break;
                    case Monedas.Dolares:
                         documento.seleccionarCelda("G34");
                         documento.actualizarValorCelda("$"+monto.ToString("N2"));

                         documento.seleccionarCelda("C37");
                         documento.actualizarValorCelda(formulas.Trim());
                break;
                }

               

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Imprimir los datos de la hoja de la carga seleccionada.
        /// </summary>
        private void imprimirHojaCarga()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla carga.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("C7");
                documento.actualizarValorCelda(_carga.Hora_inicio.ToShortDateString());

                documento.seleccionarCelda("C9"); 
                documento.actualizarValorCelda(_carga.Hora_inicio.ToShortTimeString());

                documento.seleccionarCelda("C11");
                documento.actualizarValorCelda(Enum.GetName(typeof(TiposCartucho), _carga.Tipo));

                documento.seleccionarCelda("C13");
                documento.actualizarValorCelda(_carga.ATM_full ? "Sí" : "No");

                documento.seleccionarCelda("C15");
                documento.actualizarValorCelda(_carga.Cierre.Camara.ToString());

                documento.seleccionarCelda("H7");
                documento.actualizarValorCelda(_carga.ToString());

                documento.seleccionarCelda("H9");
                documento.actualizarValorCelda(_carga.Codigo);

                documento.seleccionarCelda("H13");
                documento.actualizarValorCelda(_carga.Ruta.ToString());

                documento.seleccionarCelda("H15");
                documento.actualizarValorCelda(_carga.Cartucho_rechazo ? "Sí" : "No");

                documento.seleccionarCelda("A47");
                documento.actualizarValorCelda(_cierre.Cajero.ToString() + " " + _carga.Fecha_asignada.ToShortDateString());

                documento.seleccionarCelda("F47");
                documento.actualizarValorCelda(_cierre.Coordinador.ToString() + " " + _carga.Fecha_asignada.ToShortDateString());

                // Mostrar los datos de los manifiestos

                documento.seleccionarCelda("C37");
                documento.actualizarValorCelda(_carga.Manifiesto.Codigo);

                documento.seleccionarCelda("C39");
                documento.actualizarValorCelda(_carga.Manifiesto.Marchamo);

                documento.seleccionarCelda("H39");
                documento.actualizarValorCelda(_carga.Manifiesto.Marchamo_adicional);

                //if (_carga.Bolsa_Rechazo)
                //{
                    documento.seleccionarCelda("H41");
                    documento.actualizarValorCelda(_carga.Manifiesto.Bolsa_rechazo);
               // }

                if (_carga.ATM_full)
                {
                    documento.seleccionarCelda("C41");
                    documento.actualizarValorCelda(_carga.Manifiesto_full.Marchamo);

                    documento.seleccionarCelda("H37");
                    documento.actualizarValorCelda(_carga.Manifiesto_full.Codigo);

                    //if (_carga.ENA)
                    //{

                        documento.seleccionarCelda("C43");
                        documento.actualizarValorCelda(_carga.Manifiesto_full.Marchamo_ena_a);

                        documento.seleccionarCelda("C45");
                        documento.actualizarValorCelda(_carga.Manifiesto_full.Marchamo_ena_b);

                        documento.seleccionarCelda("H43");
                        documento.actualizarValorCelda(_carga.Manifiesto_full.Marchamo_adicional_ena);
                    //}

                }

                // Imprimir los montos

                int fila_colones = 0;
                int fila_dolares = 0;

                foreach (CartuchoCargaATM cartucho in _carga.Cartuchos)
                {

                    switch (cartucho.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            documento.seleccionarCelda(19 + fila_colones, 1);
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 4);
                            documento.actualizarValorCelda(cartucho.Denominacion.Codigo);

                            documento.seleccionarCelda(19 + fila_colones, 5);
                            documento.actualizarValorCelda(cartucho.Cantidad_carga.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 6);
                            documento.actualizarValorCelda(cartucho.Cartucho.Numero.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 7);
                            documento.actualizarValorCelda(cartucho.Marchamo);

                            fila_colones++;
                            break;
                        case Monedas.Dolares:
                            documento.seleccionarCelda(33 + fila_dolares, 1);
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor.ToString());

                            documento.seleccionarCelda(33 + fila_dolares, 4);
                            documento.actualizarValorCelda(cartucho.Denominacion.Codigo);

                            documento.seleccionarCelda(33 + fila_dolares, 5);
                            documento.actualizarValorCelda(cartucho.Cantidad_carga.ToString());

                            documento.seleccionarCelda(33 + fila_dolares, 6);
                            documento.actualizarValorCelda(cartucho.Cartucho.Numero.ToString());

                            documento.seleccionarCelda(33 + fila_dolares, 7);
                            documento.actualizarValorCelda(cartucho.Marchamo);

                            fila_dolares++;
                            break;
                    }

                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Imprimir los datos de una descarga.
        /// </summary>
        private void imprimirDescarga()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla descarga.xlt", true);
                DescargaATM descarga = (DescargaATM)dgvDescargas.SelectedRows[0].DataBoundItem;

                // Escribir los valores generales

                documento.seleccionarHoja(1);

                string fecha = _cierre.Fecha.ToShortDateString();

                documento.seleccionarCelda("B8");
                documento.actualizarValorCelda(fecha);

                documento.seleccionarCelda("D8");
                documento.actualizarValorCelda(_cierre.Camara.Identificador);

                documento.seleccionarCelda("A45");
                documento.actualizarValorCelda(_cierre.Cajero.ToString() + " " + fecha);

                documento.seleccionarCelda("E45");
                documento.actualizarValorCelda(_cierre.Coordinador.ToString() + " " + fecha);

                // Escribir los valores de la descarga

                this.escribirHojaDescarga(documento, descarga, 1);

                // Mostrar el archivo

                documento.mostrar();
                documento.mostrarDialogoImpresion();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Imprimir los datos de las descargas.
        /// </summary>
        private void imprimirDescargas()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla descargas.xlt", true);

                // Escribir los valores generales

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("D6");
                documento.actualizarValorCelda(_cierre.Cajero.ToString());

                documento.seleccionarCelda("D7");
                documento.actualizarValorCelda(_cierre.Coordinador.ToString());

                documento.seleccionarCelda("D8");
                documento.actualizarValorCelda(_cierre.Fecha.ToShortDateString());

                documento.seleccionarCelda("D9");
                documento.actualizarValorCelda(_cierre.Camara.Identificador);

                // Escribir los datos para cada descarga

                int hoja_descarga = 8;

                foreach (DataGridViewRow fila in dgvDescargas.Rows)
                {
                    DescargaATM descarga = (DescargaATM)fila.DataBoundItem;

                    this.escribirHojaDescarga(documento, descarga, hoja_descarga);
                    
                    hoja_descarga++;
                }

                // Escribir los datos de cierre

                documento.seleccionarHoja(3);

                int monto_cola_colones = 14;
                int monto_cola_dolares = 20;

                foreach (MontoCierreATMs detalle in _cierre.Montos_cola_descargas)
                {

                    switch (detalle.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            documento.seleccionarCelda(monto_cola_colones, 4);
                            documento.actualizarValorCelda(detalle.Cantidad);

                            documento.seleccionarCelda(monto_cola_colones, 2);
                            documento.actualizarValorCelda(detalle.Denominacion.Valor);

                            monto_cola_colones++;
                            break;
                        case Monedas.Dolares:
                            documento.seleccionarCelda(monto_cola_dolares, 4);
                            documento.actualizarValorCelda(detalle.Cantidad);

                            documento.seleccionarCelda(monto_cola_dolares, 2);
                            documento.actualizarValorCelda(detalle.Denominacion.Valor);

                            monto_cola_dolares++;
                            break;
                    }

                }

                int monto_mesa_colones = 3;
                int monto_mesa_dolares = 9;

                foreach (MontoCierreATMs detalle in _cierre.Montos_mesa_descargas)
                {

                    switch (detalle.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            documento.seleccionarCelda(monto_mesa_colones, 4);
                            documento.actualizarValorCelda(detalle.Cantidad);

                            documento.seleccionarCelda(monto_mesa_colones, 2);
                            documento.actualizarValorCelda(detalle.Denominacion.Valor);

                            monto_mesa_colones++;
                            break;
                        case Monedas.Dolares:
                            documento.seleccionarCelda(monto_mesa_dolares, 4);
                            documento.actualizarValorCelda(detalle.Cantidad);

                            documento.seleccionarCelda(monto_mesa_dolares, 2);
                            documento.actualizarValorCelda(detalle.Denominacion.Valor);

                            monto_mesa_dolares++;
                            break;
                    }

                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Escribir los datos de una descarga.
        /// </summary>
        private void escribirHojaDescarga(DocumentoExcel documento, DescargaATM descarga, int numero_hoja)
        {
            documento.seleccionarHoja(numero_hoja);

            // Escribir los datos

            documento.seleccionarCelda("B9");
            documento.actualizarValorCelda(descarga.Hora_inicio.ToShortTimeString());

            documento.seleccionarCelda("D9");
            documento.actualizarValorCelda(descarga.Hora_finalizacion.ToShortTimeString());

            documento.seleccionarCelda("B10");
            documento.actualizarValorCelda(descarga.ATM.Numero);

            documento.seleccionarCelda("D10");
            documento.actualizarValorCelda(descarga.ATM.Codigo);

            documento.seleccionarCelda("B11");
            documento.actualizarValorCelda(Enum.GetName(typeof(TiposCartucho), descarga.Tipo));

            documento.seleccionarCelda("A42");
            documento.actualizarValorCelda(descarga.Observaciones);

            // Mostrar los datos del manifiesto

            documento.seleccionarCelda("F37");
            documento.actualizarValorCelda(descarga.Codigo_manifiesto);

            documento.seleccionarCelda("F39");
            documento.actualizarValorCelda(descarga.Codigo_marchamo);

            // Imprimir los montos descargados

            this.escribirCartuchosDescargaImpresion(documento, descarga.Cartuchos_Colones, 15);
            this.escribirCartuchosDescargaImpresion(documento, descarga.Cartuchos_Dolares, 34);

            // Imprimir los montos de los rechazos

            this.escribirRechazosDescargaImpresion(documento, descarga.Rechazos_Colones, 23);
            this.escribirRechazosDescargaImpresion(documento, descarga.Rechazos_Dolares, 35);

            // Imprimir los montos de los contadores

            this.escribirContadoresDescargaImpresion(documento, descarga.Contadores_Colones, 55);
            this.escribirContadoresDescargaImpresion(documento, descarga.Contadores_Dolares, 66);

            // Imprimir los montos de carga

            this.escribirMontosCargaDescargaImpresion(documento, descarga.Cartuchos_Colones, 96);
            this.escribirMontosCargaDescargaImpresion(documento, descarga.Cartuchos_Dolares, 111);

            // Imprimir las denominaciones de las diferencias

            this.escribirDiferenciasDescargaImpresion(documento, descarga.Detalles_Colones, 77);
            this.escribirDiferenciasDescargaImpresion(documento, descarga.Detalles_Dolares, 89);
            this.escribirDiferenciasDescargaImpresion(documento, descarga.Detalles_Colones, 121);
            this.escribirDiferenciasDescargaImpresion(documento, descarga.Detalles_Dolares, 133);
        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de los cartuchos de una descarga.
        /// </summary>
        private void escribirCartuchosDescargaImpresion(DocumentoExcel documento, BindingList<CartuchoCargaATM> cartuchos, int fila)
        {

            foreach (CartuchoCargaATM cartucho in cartuchos)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(cartucho.Denominacion.Valor);

                documento.seleccionarCelda(fila, 3);
                documento.actualizarValorCelda(cartucho.Cantidad_descarga);

                documento.seleccionarCelda(fila, 5);
                documento.actualizarValorCelda(cartucho.Cartucho.Numero);

                documento.seleccionarCelda(fila, 6);
                documento.actualizarValorCelda(cartucho.Marchamo);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de los rechazos de una descarga.
        /// </summary>
        private void escribirRechazosDescargaImpresion(DocumentoExcel documento, BindingList<RechazoDescargaATM> rechazos, int fila)
        {

            foreach (RechazoDescargaATM rechazo in rechazos)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(rechazo.Denominacion.Valor);

                documento.seleccionarCelda(fila, 3);
                documento.actualizarValorCelda(rechazo.Cantidad_descarga);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de los contadores de una descarga.
        /// </summary>
        private void escribirContadoresDescargaImpresion(DocumentoExcel documento, BindingList<ContadorDescargaATM> contadores, int fila)
        {

            foreach (ContadorDescargaATM contador in contadores)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(contador.Denominacion.Valor);

                documento.seleccionarCelda(fila, 2);
                documento.actualizarValorCelda(contador.Denominacion.Codigo);

                // Cantidades dispensadas y remanentes

                documento.seleccionarCelda(fila, 8);
                documento.actualizarValorCelda(contador.Cantidad_dispensada_a);

                documento.seleccionarCelda(fila, 10);
                documento.actualizarValorCelda(contador.Cantidad_remanente_a);

                documento.seleccionarCelda(fila, 11);
                documento.actualizarValorCelda(contador.Cantidad_dispensada_b);

                documento.seleccionarCelda(fila, 12);
                documento.actualizarValorCelda(contador.Cantidad_remanente_b);

                documento.seleccionarCelda(fila, 13);
                documento.actualizarValorCelda(contador.Cantidad_dispensada_c);

                documento.seleccionarCelda(fila, 14);
                documento.actualizarValorCelda(contador.Cantidad_remanente_c);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de los montos de carga de una descarga.
        /// </summary>
        private void escribirMontosCargaDescargaImpresion(DocumentoExcel documento, BindingList<CartuchoCargaATM> cartuchos, int fila)
        {

            foreach (CartuchoCargaATM cartucho in cartuchos)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(cartucho.Denominacion.Valor);

                documento.seleccionarCelda(fila, 3);
                documento.actualizarValorCelda(cartucho.Cantidad_carga);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de las diferencias.
        /// </summary>
        private void escribirDiferenciasDescargaImpresion(DocumentoExcel documento, BindingList<DetalleDescargaATM> detalles, int fila)
        {

            foreach (DetalleDescargaATM detalle in detalles)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(detalle.Denominacion.Valor);

                fila++;
            }

        }

        /// <summary>
        /// Imprimir los datos de una descarga full.
        /// </summary>
        private void imprimirDescargaFull()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla descarga full.xlt", true);
                DescargaATMFull descarga = (DescargaATMFull)dgvDescargasFull.SelectedRows[0].DataBoundItem;

                // Escribir los valores generales

                documento.seleccionarHoja(1);

                string fecha = _cierre.Fecha.ToShortDateString();

                documento.seleccionarCelda("C7");
                documento.actualizarValorCelda(fecha);

                documento.seleccionarCelda("C10");
                documento.actualizarValorCelda(_cierre.Camara.Identificador);

                documento.seleccionarCelda("B44");
                documento.actualizarValorCelda(_cierre.Cajero.ToString() + " " + fecha);

                documento.seleccionarCelda("E44");
                documento.actualizarValorCelda(_cierre.Coordinador.ToString() + " " + fecha);

                // Escribir los valores de la descarga

                this.escribirHojaDescargaFull(documento, descarga, 1);

                // Mostrar el archivo

                documento.mostrar();
                documento.mostrarDialogoImpresion();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Imprimir los datos de las descargas full.
        /// </summary>
        private void imprimirDescargasFull()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla descargas full.xlt", true);

                // Escribir los valores generales

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("D6");
                documento.actualizarValorCelda(_cierre.Cajero.ToString());

                documento.seleccionarCelda("D7");
                documento.actualizarValorCelda(_cierre.Coordinador.ToString());

                documento.seleccionarCelda("D8");
                documento.actualizarValorCelda(_cierre.Fecha.ToShortDateString());

                documento.seleccionarCelda("D9");
                documento.actualizarValorCelda(_cierre.Camara.Identificador);

                // Escribir los datos para cada descarga

                int hoja_descarga = 6;

                foreach (DataGridViewRow fila in dgvDescargasFull.Rows)
                {
                    DescargaATMFull descarga = (DescargaATMFull)fila.DataBoundItem;

                    this.escribirHojaDescargaFull(documento, descarga, hoja_descarga);

                    hoja_descarga++;
                }

                // Escribir los datos de cierre

                documento.seleccionarHoja(2);

                int monto_cola_colones = 19;
                int monto_cola_dolares = 25;

                foreach (MontoCierreATMs detalle in _cierre.Montos_cola_descargas_full)
                {

                    switch (detalle.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            documento.seleccionarCelda(monto_cola_colones, 4);
                            documento.actualizarValorCelda(detalle.Cantidad);

                            documento.seleccionarCelda(monto_cola_colones, 2);
                            documento.actualizarValorCelda(detalle.Denominacion.Valor);

                            monto_cola_colones++;
                            break;
                        case Monedas.Dolares:
                            documento.seleccionarCelda(monto_cola_dolares, 4);
                            documento.actualizarValorCelda(detalle.Cantidad);

                            documento.seleccionarCelda(monto_cola_dolares, 2);
                            documento.actualizarValorCelda(detalle.Denominacion.Valor);

                            monto_cola_dolares++;
                            break;
                    }

                }

                int monto_mesa_colones = 3;
                int monto_mesa_dolares = 9;

                foreach (MontoCierreATMs detalle in _cierre.Montos_mesa_descargas_full)
                {

                    switch (detalle.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            documento.seleccionarCelda(monto_mesa_colones, 4);
                            documento.actualizarValorCelda(detalle.Cantidad);

                            documento.seleccionarCelda(monto_mesa_colones, 2);
                            documento.actualizarValorCelda(detalle.Denominacion.Valor);

                            monto_mesa_colones++;
                            break;
                        case Monedas.Dolares:
                            documento.seleccionarCelda(monto_mesa_dolares, 4);
                            documento.actualizarValorCelda(detalle.Cantidad);

                            documento.seleccionarCelda(monto_mesa_dolares, 2);
                            documento.actualizarValorCelda(detalle.Denominacion.Valor);

                            monto_mesa_dolares++;
                            break;
                    }

                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Escribir los datos de una descarga full.
        /// </summary>
        private void escribirHojaDescargaFull(DocumentoExcel documento, DescargaATMFull descarga, int numero_hoja)
        {
            documento.seleccionarHoja(numero_hoja);

            // Escribir los datos

            documento.seleccionarCelda("C8");
            documento.actualizarValorCelda(descarga.Hora_inicio.ToShortTimeString());

            documento.seleccionarCelda("C9");
            documento.actualizarValorCelda(descarga.Hora_finalizacion.ToShortTimeString());

            documento.seleccionarCelda("C11");
            documento.actualizarValorCelda(descarga.ATM.Numero);

            documento.seleccionarCelda("B41");
            documento.actualizarValorCelda(descarga.Observaciones);

            // Mostrar los datos del manifiesto

            documento.seleccionarCelda("C12");
            documento.actualizarValorCelda(descarga.Codigo_manifiesto);

            documento.seleccionarCelda("C13");
            documento.actualizarValorCelda(descarga.Codigo_marchamo);

            // Imprimir los montos de la descarga

            this.escribirMontosFullImpresion(documento, descarga.Montos_colones, 17);
            this.escribirMontosFullImpresion(documento, descarga.Montos_dolares, 29);

            // Imprimir los montos de los contadores

            this.escribirContadoresFullImpresion(documento, descarga.Contadores_Colones, 54);
            this.escribirContadoresFullImpresion(documento, descarga.Contadores_Dolares, 64);

            // Imprimir las denominaciones de las diferencias

            this.escribirDiferenciasFullImpresion(documento, descarga.Detalles_Colones, 80);
            this.escribirDiferenciasFullImpresion(documento, descarga.Detalles_Dolares, 92);
        }

        /// <summary>
        /// Escribir en un documento de impresión los montos de una descarga full.
        /// </summary>
        private void escribirMontosFullImpresion(DocumentoExcel documento, BindingList<MontoDescargaATMFull> montos, int fila)
        {

            foreach (MontoDescargaATMFull monto in montos)
            {
                documento.seleccionarCelda(fila, 2);
                documento.actualizarValorCelda(monto.Denominacion.Valor);

                documento.seleccionarCelda(fila, 4);
                documento.actualizarValorCelda(monto.Cantidad);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de los contadores de una descarga full.
        /// </summary>
        private void escribirContadoresFullImpresion(DocumentoExcel documento, BindingList<ContadorDescargaATMFull> contadores, int fila)
        {

            foreach (ContadorDescargaATMFull contador in contadores)
            {
                documento.seleccionarCelda(fila, 2);
                documento.actualizarValorCelda(contador.Denominacion.Valor);

                // Cantidades dispensadas y remanentes

                documento.seleccionarCelda(fila, 4);
                documento.actualizarValorCelda(contador.Cantidad_depositada);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de las diferencias de una descarga full.
        /// </summary>
        private void escribirDiferenciasFullImpresion(DocumentoExcel documento, BindingList<DetalleDescargaATMFull> detalles, int fila)
        {

            foreach (DetalleDescargaATMFull detalle in detalles)
            {
                documento.seleccionarCelda(fila, 2);
                documento.actualizarValorCelda(detalle.Denominacion.Valor);

                fila++;
            }

        }

        /// <summary>
        /// Verificar si un usuario tiene un cierre pendiente de finalizar o no.
        /// </summary>
        private void verificarCierre()
        {

            try
            {
                DateTime fecha = dtpFechaCierre.Value;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                CierreATMs cierre = new CierreATMs(cajero, fecha: fecha);

                if (_coordinacion.verificarCierreATMs(ref cierre))
                {
                    _cierre = cierre;
                    _pendiente = false;
                    this.mostrarDatosCierre();
                }
                else if (_coordinacion.verificarCierreATMsPendiente(ref cierre))
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
            dgvDescargas.DataSource = _cierre.Descargas;
            dgvDescargasFull.DataSource = _cierre.Descargas_full;
            

            btnCargasPendientes.Enabled = _cierre.Cargas_listas;

            // Montrar los montos de cierre

            dgvMontosMesaDescargas.DataSource = _cierre.Montos_mesa_descargas;
            dgvMontosColaDescargas.DataSource = _cierre.Montos_cola_descargas;

            dgvMontosMesaDescargasFull.DataSource = _cierre.Montos_mesa_descargas_full;
            dgvMontosColaDescargasFull.DataSource = _cierre.Montos_cola_descargas_full;

            this.mostrarConceptosTotalesDescargas();
            this.mostrarConceptosTotalesDescargasFull();

            // Actualizar la lista de cargas y descargas

            this.actualizarListasCierre();

            btnActualizarListasCierre.Enabled = true;
        }

        /// <summary>
        /// Mostrar los conceptos de los totales de las descargas.
        /// </summary
        private void mostrarConceptosTotalesDescargas()
        {
            dgvTotalesDescargas.Rows.Clear();

            dgvTotalesDescargas.Rows.Add("T. Mesa", _cierre.Monto_mesa_descargas_colones, _cierre.Monto_mesa_descargas_dolares);
            dgvTotalesDescargas.Rows.Add("T. Cola", _cierre.Monto_cola_descargas_colones, _cierre.Monto_cola_descargas_dolares);
            dgvTotalesDescargas.Rows.Add("T. Descargas", _cierre.Monto_colones_descargas, _cierre.Monto_dolares_descargas);
            dgvTotalesDescargas.Rows.Add("Diferencia", _cierre.Diferencia_colones_descargas, _cierre.Diferencia_dolares_descargas);
        }

        /// <summary>
        /// Mostrar los conceptos de los totales de las descargas full.
        /// </summary
        private void mostrarConceptosTotalesDescargasFull()
        {
            dgvTotalesDescargasFull.Rows.Clear();

            dgvTotalesDescargasFull.Rows.Add("T. Mesa", _cierre.Monto_mesa_descargas_full_colones, _cierre.Monto_mesa_descargas_full_dolares);
            dgvTotalesDescargasFull.Rows.Add("T. Cola", _cierre.Monto_cola_descargas_full_colones, _cierre.Monto_cola_descargas_full_dolares);
            dgvTotalesDescargasFull.Rows.Add("T. Descargas", _cierre.Monto_colones_descargas_full, _cierre.Monto_dolares_descargas_full);
            dgvTotalesDescargasFull.Rows.Add("Diferencia", _cierre.Diferencia_colones_descargas_full, _cierre.Diferencia_dolares_descargas_full);
        }

        /// <summary>
        /// Mostrar los datos de la carga de ATM.
        /// </summary
        private void mostrarDatosCargaATM()
        {
            _carga_mostrada = false;

            dgvMontosCarga.DataSource = _carga.Cartuchos;

            dtpHoraInicioCarga.Value = _carga.Hora_inicio;
            dtpHoraFinCarga.Value = _carga.Hora_finalizacion;
            txtObservacionesCarga.Text = _carga.Observaciones;

            // Mostrar el manifiesto

            if (_carga.Manifiesto == null)
            {
                txtManifiestoCarga.Text = string.Empty;
                txtMarchamoCarga.Text = string.Empty;
            }
            else
            {
                txtManifiestoCarga.Text = _carga.Manifiesto.Codigo;
                txtMarchamoCarga.Text = _carga.Manifiesto.Marchamo;
            }

            // Mostrar el manifiesto full

            if (_carga.Manifiesto_full == null)
            {
                txtManifiestoFullCarga.Text = string.Empty;
                txtMarchamoFullCarga.Text = string.Empty;
            }
            else
            {
                txtManifiestoFullCarga.Text = _carga.Manifiesto_full.Codigo;
                txtMarchamoFullCarga.Text = _carga.Manifiesto_full.Marchamo;
            }

            _carga_mostrada = true;

            this.validarOpcionesCarga();
        }

        /// <summary>
        /// Mostrar los datos de la descarga de ATM.
        /// </summary
        private void mostrarDatosDescargaATM()
        {
            _descarga_mostrada = false;

            if (_descarga.Hora_inicio.DayOfWeek == DayOfWeek.Sunday)
            {
                dtpFechaDescarga.Value = _descarga.Hora_inicio.AddDays(-1);
            }
            else
            {
                dtpFechaDescarga.Value = _descarga.Hora_inicio;
            }
            dtpHoraInicioDescarga.Value = _descarga.Hora_inicio;
            dtpHoraFinDescarga.Value = _descarga.Hora_finalizacion;
            dtpHoraDiferenciaDescarga.Value = _descarga.Hora_diferencia;
            txtObservacionesDescarga.Text = _descarga.Observaciones;

            // Mostrar el manifiesto

            if (_descarga.Manifiesto == null)
            {
                txtManifiestoDescarga.Text = string.Empty;
                txtMarchamoDescarga.Text = string.Empty;
            }
            else
            {
                txtManifiestoDescarga.Text = _descarga.Codigo_manifiesto;
                txtMarchamoDescarga.Text = _descarga.Codigo_marchamo;
            }

            // Mostrar los datos de los contadores y el detalle de los montos por denominación

            dgvContadoresDescarga.DataSource = _descarga.Contadores;
            dgvDiferenciasRemanentesDescarga.DataSource = _descarga.Detalles;
            dgvDiferenciasContadoresDescarga.DataSource = _descarga.Detalles;

            // Mostrar los datos de los cartuchos y los rechazos

            dgvMontosDescarga.Rows.Clear();

            // Colones

            foreach (CartuchoCargaATM cartucho in _descarga.Cartuchos_Colones)
                this.agregarFilaCartuchoDescargaATM(cartucho);

            foreach (RechazoDescargaATM rechazo in _descarga.Rechazos_Colones)
                this.agregarFilaRechazoDescargaATM(rechazo);

            dgvMontosDescarga.Rows.Add("T. Descarga", _descarga.Monto_descarga_colones, null, null, null, TiposFila.TotalDescargaColones);
            dgvMontosDescarga.Rows.Add("T. Dispensado", _descarga.Monto_dispensado_colones, null, null, null, TiposFila.TotalDispensadoColones);
            dgvMontosDescarga.Rows.Add("T. Llenado", _descarga.Monto_carga_colones, null, null, null, TiposFila.TotalCargaColones);
            dgvMontosDescarga.Rows.Add("Diferencia", _descarga.Diferencia_colones, null, null, null, TiposFila.TotalDiferenciaColones);

            // Dolares

            foreach (CartuchoCargaATM cartucho in _descarga.Cartuchos_Dolares)
                this.agregarFilaCartuchoDescargaATM(cartucho);

            foreach (RechazoDescargaATM rechazo in _descarga.Rechazos_Dolares)
                this.agregarFilaRechazoDescargaATM(rechazo);

            dgvMontosDescarga.Rows.Add("T. Descarga", _descarga.Monto_descarga_dolares, null, null, null, TiposFila.TotalDescargaDolares);
            dgvMontosDescarga.Rows.Add("T. Dispensado", _descarga.Monto_dispensado_dolares, null, null, null, TiposFila.TotalDispensadoDolares);
            dgvMontosDescarga.Rows.Add("T. Llenado", _descarga.Monto_carga_dolares, null, null, null, TiposFila.TotalCargaDolares);
            dgvMontosDescarga.Rows.Add("Diferencia", _descarga.Diferencia_dolares, null, null, null, TiposFila.TotalDiferenciaDolares);

            // Dar formato a las celdas totales

            foreach (DataGridViewRow fila in dgvMontosDescarga.Rows)
            {
                TiposFila tipo = (TiposFila)fila.Cells[TipoFilaDescarga.Index].Value;

                switch (tipo)
                {
                    case TiposFila.TotalDescargaColones:
                    case TiposFila.TotalDispensadoColones:
                    case TiposFila.TotalCargaColones:
                    case TiposFila.TotalDescargaDolares:
                    case TiposFila.TotalDispensadoDolares:
                    case TiposFila.TotalCargaDolares:
                        fila.DefaultCellStyle.BackColor = Color.LightBlue;
                        fila.ReadOnly = true;
                        break;
                    case TiposFila.TotalDiferenciaColones:
                    case TiposFila.TotalDiferenciaDolares:
                        fila.DefaultCellStyle.BackColor = Color.Coral;
                        fila.ReadOnly = true;
                        break;
                }

            }

            pbDiferenciaDescarga.BackColor = _descarga.Cuadrada ? Color.Green : Color.Red;

            _descarga_mostrada = true;
        }

        /// <summary>
        /// Agregar una fila de un cartucho a los montos de una descarga.
        /// </summary
        private void agregarFilaCartuchoDescargaATM(CartuchoCargaATM cartucho)
        {
            dgvMontosDescarga.Rows.Add(cartucho.Denominacion, cartucho.Monto_descarga, cartucho.Cantidad_descarga,
                                       cartucho.Cartucho, cartucho.Marchamo, TiposFila.Cartucho, cartucho);
        }

        /// <summary>
        /// Agregar la fila de un rechazo a los montos de una descarga.
        /// </summary
        private void agregarFilaRechazoDescargaATM(RechazoDescargaATM rechazo)
        {
            dgvMontosDescarga.Rows.Add(rechazo, rechazo.Monto_descarga, rechazo.Cantidad_descarga,
                                       null, null, TiposFila.Rechazo, rechazo);
        }





        ///////////////////////////////////////////////////////////////// DESCARGAS FULL ////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Mostrar los datos de la descarga de ATM Full.
        /// </summary
        private void mostrarDatosDescargaATMFull()
        {
            _descarga_full_mostrada = false;

            dtpFechaDescargaFull.Value = _descarga_full.Fecha;
            dtpHoraInicioDescargaFull.Value = _descarga_full.Hora_inicio;
            dtpHoraFinDescargaFull.Value = _descarga_full.Hora_finalizacion;
            dtpHoraDiferenciaDescargaFull.Value = _descarga_full.Hora_diferencia;
            txtObservacionesDescargaFull.Text = _descarga_full.Observaciones;

            // Mostrar el manifiesto

            txtManifiestoDescargaFull.Text = _descarga_full.Codigo_manifiesto;
            txtMarchamoDescargaFull.Text = _descarga_full.Codigo_marchamo;

            // Mostrar los datos de los contadores y el detalle de los montos por denominación

            dgvContadoresDescargaFull.DataSource = _descarga_full.Contadores;
            dgvDiferenciasDescargaFull.DataSource = _descarga_full.Detalles;

            // Mostrar los datos de los montos

            dgvMontosDescargaFull.Rows.Clear();

            // Colones

            foreach (MontoDescargaATMFull monto in _descarga_full.Montos_colones)
                this.agregarFilaMontoDescargaATMFull(monto);

            dgvMontosDescargaFull.Rows.Add("T. Descarga", _descarga_full.Monto_descarga_colones, null, TiposFila.TotalDescargaColones);
            dgvMontosDescargaFull.Rows.Add("T. Contadores", _descarga_full.Monto_depositado_colones, null, TiposFila.TotalDepositadoColones);
            dgvMontosDescargaFull.Rows.Add("Diferencia", _descarga_full.Diferencia_colones, null, TiposFila.TotalDiferenciaColones);

            // Dolares

            foreach (MontoDescargaATMFull monto in _descarga_full.Montos_dolares)
                this.agregarFilaMontoDescargaATMFull(monto);

            dgvMontosDescargaFull.Rows.Add("T. Descarga", _descarga_full.Monto_descarga_dolares, null, TiposFila.TotalDescargaDolares);
            dgvMontosDescargaFull.Rows.Add("T. Contadores", _descarga_full.Monto_depositado_dolares, null, TiposFila.TotalDepositadoDolares);
            dgvMontosDescargaFull.Rows.Add("Diferencia", _descarga_full.Diferencia_dolares, null, TiposFila.TotalDiferenciaDolares);

            // Dar formato a las celdas totales

            foreach (DataGridViewRow fila in dgvMontosDescargaFull.Rows)
            {
                TiposFila tipo = (TiposFila)fila.Cells[TipoFilaDescargaFull.Index].Value;

                switch (tipo)
                {
                    case TiposFila.TotalDescargaColones:
                    case TiposFila.TotalDepositadoColones:
                    case TiposFila.TotalDescargaDolares:
                    case TiposFila.TotalDepositadoDolares:
                        fila.DefaultCellStyle.BackColor = Color.LightBlue;
                        fila.ReadOnly = true;
                        break;
                    case TiposFila.TotalDiferenciaColones:
                    case TiposFila.TotalDiferenciaDolares:
                        fila.DefaultCellStyle.BackColor = Color.Coral;
                        fila.ReadOnly = true;
                        break;
                }

            }

            pbDiferenciaDescargaFull.BackColor = _descarga_full.Cuadrada ? Color.Green : Color.Red;

            _descarga_full_mostrada = true;
        }

        /// <summary>
        /// Agregar una fila de un monto de una descarga full.
        /// </summary
        private void agregarFilaMontoDescargaATMFull(MontoDescargaATMFull monto)
        {
            dgvMontosDescargaFull.Rows.Add(monto.Denominacion, monto.Monto_descarga, monto.Cantidad, TiposFila.MontoFull, monto);
        }

        /// <summary>
        /// Actualizar los montos totales de una descarga.
        /// </summary
        private void actualizarTotalesMontosDescarga()
        {
            _descarga.recalcularMontosDescarga();
            _descarga.recalcularDetalles();

            foreach (DataGridViewRow fila in dgvMontosDescarga.Rows)
            {
                TiposFila tipo = (TiposFila)fila.Cells[TipoFilaDescarga.Index].Value;
                DataGridViewCell celda = fila.Cells[MontoCartuchoDescarga.Index];

                switch (tipo)
                {
                    case TiposFila.TotalDescargaColones: celda.Value = _descarga.Monto_descarga_colones; break;
                    case TiposFila.TotalDispensadoColones: celda.Value = _descarga.Monto_dispensado_colones; break;
                    case TiposFila.TotalCargaColones: celda.Value = _descarga.Monto_carga_colones; break;
                    case TiposFila.TotalDiferenciaColones: celda.Value = _descarga.Diferencia_colones; break;
                    case TiposFila.TotalDescargaDolares: celda.Value = _descarga.Monto_descarga_dolares; break;
                    case TiposFila.TotalDispensadoDolares: celda.Value = _descarga.Monto_dispensado_dolares; break;
                    case TiposFila.TotalCargaDolares: celda.Value = _descarga.Monto_carga_dolares; break;
                    case TiposFila.TotalDiferenciaDolares: celda.Value = _descarga.Diferencia_dolares; break;
                }

            }

            dgvDiferenciasRemanentesDescarga.Refresh();
            dgvDiferenciasContadoresDescarga.Refresh();
            dgvMontosDescarga.Refresh();

            pbDiferenciaDescarga.BackColor = _descarga.Cuadrada ? Color.Green : Color.Red;
        }

        /// <summary>
        /// Actualizar los montos totales de una descarga full.
        /// </summary
        private void actualizarTotalesMontosDescargaFull()
        {
            _descarga_full.recalcularMontosDescarga();
            _descarga_full.recalcularDetalles();

            foreach (DataGridViewRow fila in dgvMontosDescargaFull.Rows)
            {
                TiposFila tipo = (TiposFila)fila.Cells[TipoFilaDescargaFull.Index].Value;
                DataGridViewCell celda = fila.Cells[MontoDescargaFull.Index];

                switch (tipo)
                {
                    case TiposFila.TotalDescargaColones: celda.Value = _descarga_full.Monto_descarga_colones; break;
                    case TiposFila.TotalDepositadoColones: celda.Value = _descarga_full.Monto_depositado_colones; break;
                    case TiposFila.TotalDiferenciaColones: celda.Value = _descarga_full.Diferencia_colones; break;
                    case TiposFila.TotalDescargaDolares: celda.Value = _descarga_full.Monto_descarga_dolares; break;
                    case TiposFila.TotalDepositadoDolares: celda.Value = _descarga_full.Monto_depositado_dolares; break;
                    case TiposFila.TotalDiferenciaDolares: celda.Value = _descarga_full.Diferencia_dolares; break;
                }

            }

            dgvDiferenciasDescargaFull.Refresh();
            dgvMontosDescargaFull.Refresh();

            pbDiferenciaDescargaFull.BackColor = _descarga_full.Cuadrada ? Color.Green : Color.Red;
        }

        /// <summary>
        /// Actualizar los montos totales del cierre.
        /// </summary
        private void actualizarTotalesMontosCierre()
        {
            if (_cierre == null) return;

            _cierre.recalcularMontosCierre();

            dgvTotalesDescargas[ColonesCierreDescargas.Index, 0].Value = _cierre.Monto_mesa_descargas_colones;
            dgvTotalesDescargas[DolaresCierreDescargas.Index, 0].Value = _cierre.Monto_mesa_descargas_dolares;
            dgvTotalesDescargas[ColonesCierreDescargas.Index, 1].Value = _cierre.Monto_cola_descargas_colones;
            dgvTotalesDescargas[DolaresCierreDescargas.Index, 1].Value = _cierre.Monto_cola_descargas_dolares;
            dgvTotalesDescargas[ColonesCierreDescargas.Index, 2].Value = _cierre.Monto_colones_descargas;
            dgvTotalesDescargas[DolaresCierreDescargas.Index, 2].Value = _cierre.Monto_dolares_descargas;
            dgvTotalesDescargas[ColonesCierreDescargas.Index, 3].Value = _cierre.Diferencia_colones_descargas;
            dgvTotalesDescargas[DolaresCierreDescargas.Index, 3].Value = _cierre.Diferencia_dolares_descargas;
            
            dgvTotalesDescargas.Refresh();
            dgvTotalesDescargas.AutoResizeColumns();

            dgvTotalesDescargasFull[ColonesCierreDescargasFull.Index, 0].Value = _cierre.Monto_mesa_descargas_full_colones;
            dgvTotalesDescargasFull[DolaresCierreDescargasFull.Index, 0].Value = _cierre.Monto_mesa_descargas_full_dolares;
            dgvTotalesDescargasFull[ColonesCierreDescargasFull.Index, 1].Value = _cierre.Monto_cola_descargas_full_colones;
            dgvTotalesDescargasFull[DolaresCierreDescargasFull.Index, 1].Value = _cierre.Monto_cola_descargas_full_dolares;
            dgvTotalesDescargasFull[ColonesCierreDescargasFull.Index, 2].Value = _cierre.Monto_colones_descargas_full;
            dgvTotalesDescargasFull[DolaresCierreDescargasFull.Index, 2].Value = _cierre.Monto_dolares_descargas_full;
            dgvTotalesDescargasFull[ColonesCierreDescargasFull.Index, 3].Value = _cierre.Diferencia_colones_descargas_full;
            dgvTotalesDescargasFull[DolaresCierreDescargasFull.Index, 3].Value = _cierre.Diferencia_dolares_descargas_full;

            dgvTotalesDescargasFull.Refresh();
            dgvTotalesDescargasFull.AutoResizeColumns();
        }

        /// <summary>
        /// Validar si se pueden modificar o no los datos de un cierre.
        /// </summary
        private void validarOpcionesCierre()
        {

            if (_cierre == null)
            {
                btnIniciar.Enabled = !_pendiente;
                btnTerminar.Enabled = false;
                btnCargasPendientes.Enabled = false;
                btnDescargasPendientes.Enabled = false;
                btnDescargasFullPendientes.Enabled = false;

                pnlOpcionesCarga.Enabled = false;
                pnlOpcionesDescargas.Enabled = false;
                pnlOpcionesDescargasFull.Enabled = false;
                pnlOpcionesCierre.Enabled = false;
            }
            else if (_cierre.Terminado)
            {
                btnIniciar.Enabled = false;
                btnTerminar.Enabled = false;

                if (_coordinador)
                {
                    btnDescargasPendientes.Enabled = true;
                    btnDescargasFullPendientes.Enabled = true;
                    btnCargasPendientes.Enabled = true;

                    pnlOpcionesCarga.Enabled = true;
                    pnlOpcionesDescargas.Enabled = true;
                    pnlOpcionesDescargasFull.Enabled = true;
                    pnlOpcionesCierre.Enabled = true;
                }
                else
                {
                    btnDescargasPendientes.Enabled = false;
                    btnDescargasFullPendientes.Enabled = false;
                    btnCargasPendientes.Enabled = _cierre.Cargas_listas;

                    pnlOpcionesCarga.Enabled = false;
                    pnlOpcionesDescargas.Enabled = false;
                    pnlOpcionesDescargasFull.Enabled = false;
                    pnlOpcionesCierre.Enabled = false;
                }

            }
            else
            {
                btnIniciar.Enabled = false;
                btnTerminar.Enabled = true;
                btnCargasPendientes.Enabled = _cierre.Cargas_listas;
                btnDescargasPendientes.Enabled = true;
                btnDescargasFullPendientes.Enabled = true;

                pnlOpcionesDescargas.Enabled = true;
                pnlOpcionesDescargasFull.Enabled = true;
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
                ((Control)tpDescargas).Enabled = false;
                ((Control)tpDescargasFull).Enabled = false;
                ((Control)tpCierre).Enabled = false;
            }
            else
            {
                ((Control)tpCargas).Enabled = true;
                ((Control)tpDescargas).Enabled = true;
                ((Control)tpDescargasFull).Enabled = true;
                ((Control)tpCierre).Enabled = true;
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
                pnlOpcionesRevision.Enabled = false;
                btnImprimirCarga.Enabled = false;
                btnDevolverCarga.Enabled = false;
                this.habilitarModificacionCartuchosCarga(false);
            }
            else if (_coordinador || _cierre.Activo) 
            {

                if (_carga.Verificada)
                {
                    pnlDatosCarga.Enabled = true;
                    pnlOpcionesRevision.Enabled = false;
                    btnImprimirCarga.Enabled = true;
                    btnDevolverCarga.Enabled = false;
                    this.habilitarModificacionCartuchosCarga(_coordinador);
                }
                else if (_carga.Lista)
                {
                    pnlDatosCarga.Enabled = true;
                    pnlOpcionesRevision.Enabled = true;
                    btnImprimirCarga.Enabled = false;
                    btnDevolverCarga.Enabled = true;
                    this.habilitarModificacionCartuchosCarga(true);
                }
                else
                {
                    pnlDatosCarga.Enabled = true;
                    pnlOpcionesRevision.Enabled = false;
                    btnImprimirCarga.Enabled = false;
                    btnDevolverCarga.Enabled = true;
                    this.habilitarModificacionCartuchosCarga(true);
                }

            }
            else
            {
                pnlDatosCarga.Enabled = false;
                pnlOpcionesRevision.Enabled = false;
                btnImprimirCarga.Enabled = false;
                btnDevolverCarga.Enabled = false;
                this.habilitarModificacionCartuchosCarga(false);
            }

        }

        /// <summary>
        /// Validar si se pueden modificar o no los datos de una descarga.
        /// </summary
        private void validarOpcionesDescarga()
        {

            if (_descarga == null)
            {
                pnlDatosDescarga.Enabled = false;
                pnlOpcionesDescargas.Enabled = false;
                this.habilitarModificacionCartuchosDescarga(false);
            }
            else if (_coordinador || _cierre.Activo)
            {
                pnlDatosDescarga.Enabled = true;
                pnlOpcionesDescargas.Enabled = true;
                this.habilitarModificacionCartuchosDescarga(true);
            }
            else
            {
                pnlDatosDescarga.Enabled = false;
                pnlOpcionesDescargas.Enabled = false;
                this.habilitarModificacionCartuchosDescarga(false);
            }

        }

        /// <summary>
        /// Validar si se pueden modificar o no los datos de una descarga full.
        /// </summary
        private void validarOpcionesDescargaFull()
        {

            if (_descarga_full == null)
            {
                pnlDatosDescargaFull.Enabled = false;
                pnlOpcionesDescargasFull.Enabled = false;
                this.habilitarModificacionMontoDescargaFull(false);
            }
            else if (_coordinador || _cierre.Activo)
            {
                pnlDatosDescargaFull.Enabled = true;
                pnlOpcionesDescargasFull.Enabled = true;
                this.habilitarModificacionMontoDescargaFull(true);
            }
            else
            {
                pnlDatosDescargaFull.Enabled = false;
                pnlOpcionesDescargasFull.Enabled = false;
                this.habilitarModificacionMontoDescargaFull(false);
            }

        }




       

       

        /// <summary>
        /// Habilitar o deshabilitar la opción de modificar los datos de un cartucho de carga.
        /// </summary>
        private void habilitarModificacionCartuchosCarga(bool estado)
        {

            if (estado)
            {
                NumeroCartuchoCarga.ReadOnly = false;
                NumeroMarchamoCarga.ReadOnly = false;
            }
            else
            {
                NumeroCartuchoCarga.ReadOnly = true;
                NumeroMarchamoCarga.ReadOnly = true;
            }

        }

        /// <summary>
        /// Habilitar o deshabilitar la opción de modificar los datos de un cartucho de descarga.
        /// </summary>
        private void habilitarModificacionCartuchosDescarga(bool estado)
        {
            CantidadCartuchoDescarga.ReadOnly = !estado;
        }

        /// <summary>
        /// Habilitar o deshabilitar la opción de modificar los datos de un monto de descarga full.
        /// </summary>
        private void habilitarModificacionMontoDescargaFull(bool estado)
        {
            CantidadDescargaFull.ReadOnly = !estado;
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
            txtManifiestoCarga.Text = string.Empty;
            txtMarchamoCarga.Text = string.Empty;

            dgvMontosCarga.DataSource = null;

            _carga_mostrada = true;
        }

        /// <summary>
        /// Limpiar los datos de la descarga seleccionada.
        /// </summary>
        private void limpiarDatosDescarga()
        {
            _descarga_mostrada = false;

            dtpHoraInicioDescarga.Value = DateTime.Now;
            dtpHoraFinDescarga.Value = DateTime.Now;

            txtObservacionesDescarga.Text = string.Empty;
            txtManifiestoDescarga.Text = string.Empty;
            txtMarchamoDescarga.Text = string.Empty;

            dgvMontosDescarga.DataSource = null;
            dgvContadoresDescarga.DataSource = null;
            dgvDiferenciasContadoresDescarga.DataSource = null;
            dgvDiferenciasRemanentesDescarga.DataSource = null;

            _descarga_mostrada = true;
        }

        /// <summary>
        /// Limpiar los datos de la descarga full seleccionada.
        /// </summary>
        private void limpiarDatosDescargaFull()
        {
            _descarga_full_mostrada = false;

            dtpHoraInicioDescargaFull.Value = DateTime.Now;
            dtpHoraFinDescargaFull.Value = DateTime.Now;

            txtObservacionesDescargaFull.Text = string.Empty;
            txtManifiestoDescargaFull.Text = string.Empty;
            txtMarchamoDescargaFull.Text = string.Empty;

            dgvMontosDescargaFull.DataSource = null;
            dgvContadoresDescargaFull.DataSource = null;
            dgvDiferenciasDescargaFull.DataSource = null;

            _descarga_full_mostrada = true;
        }





     

        /// <summary>
        /// Limpiar los datos del cierre.
        /// </summary>
        private void limpiarDatosCierre()
        {
            cboCoordinador.Text = string.Empty;
            cboCamaraCierre.Text = string.Empty;

            dgvListaCargasCierre.DataSource = null;
            dgvListaDescargasCierre.DataSource = null;

            dgvCargas.DataSource = null;
            dgvDescargas.DataSource = null;
            dgvDescargasFull.DataSource = null;


            dgvMontosMesaDescargas.DataSource = null;
            dgvMontosColaDescargas.DataSource = null;
            dgvTotalesDescargas.DataSource = null;

            dgvMontosMesaDescargasFull.DataSource = null;
            dgvMontosColaDescargasFull.DataSource = null;
            dgvTotalesDescargasFull.DataSource = null;
        }

        /// <summary>
        /// Actualizar la lista de cargas y descargas del cierre.
        /// </summary>
        private void actualizarListasCierre()
        {

            try
            {
                dgvListaCargasCierre.DataSource = _coordinacion.listarCargasATMsPorCierreATMs(_cierre);
                dgvListaDescargasCierre.DataSource = _coordinacion.listarDescargasATMsPorCierreATMs(_cierre);
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

                    _coordinacion.actualizarCargaATM(_carga);

                    this.validarOpcionesCarga();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Guardar los datos de una descarga.
        /// </summary>
        private void guardarDescarga()
        {

            if (_descarga_mostrada)
            {

                try
                {
                    _descarga.Fecha = dtpFechaDescarga.Value;
                    _descarga.Hora_inicio = dtpHoraInicioDescarga.Value;
                    _descarga.Hora_finalizacion = dtpHoraFinDescarga.Value;
                    _descarga.Hora_diferencia = dtpHoraDiferenciaDescarga.Value;
                    _descarga.Observaciones = txtObservacionesDescarga.Text;

                    _coordinacion.actualizarDescargaATM(_descarga);
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Guardar los datos de una descarga full.
        /// </summary>
        private void guardarDescargaFull()
        {

            if (_descarga_full_mostrada)
            {

                try
                {
                    _descarga_full.Fecha = dtpFechaDescargaFull.Value;
                    _descarga_full.Hora_inicio = dtpHoraInicioDescargaFull.Value;
                    _descarga_full.Hora_finalizacion = dtpHoraFinDescargaFull.Value;
                    _descarga_full.Hora_diferencia = dtpHoraDiferenciaDescargaFull.Value;
                    _descarga_full.Observaciones = txtObservacionesDescargaFull.Text;

                    _coordinacion.actualizarDescargaATMFull(_descarga_full);
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
        public void seleccionarManifiestosCarga(ManifiestoATMCarga manifiesto, ManifiestoATMFull manifiesto_full)
        {

            try
            {
                _carga.Manifiesto = manifiesto;
                _carga.Manifiesto_full = manifiesto_full;

                _coordinacion.actualizarCargaATM(_carga);

                if (manifiesto != null)
                {
                    txtManifiestoCarga.Text = manifiesto.Codigo;
                    txtMarchamoCarga.Text = manifiesto.Marchamo;
                }

                if (manifiesto_full != null)
                {
                    txtManifiestoFullCarga.Text = manifiesto_full.Codigo;
                    txtMarchamoFullCarga.Text = manifiesto_full.Marchamo;
                }

                this.validarOpcionesCarga();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// Mostrar los datos del manifiesto full seleccionado para una carga.
        /// </summary>
        public void seleccionarManifiestoFull(ManifiestoATMFull manifiesto)
        {

            try
            {
                _carga.Manifiesto_full = manifiesto;

                _coordinacion.actualizarCargaATM(_carga);

                txtManifiestoCarga.Text = manifiesto.Codigo;
                txtMarchamoCarga.Text = manifiesto.Marchamo;

                this.validarOpcionesCarga();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Mostrar los datos del manifiesto seleccionado para una descarga.
        /// </summary>
        public void seleccionarManifiestoDescarga(ManifiestoATMCarga manifiesto)
        {

            try
            {
                _descarga.Manifiesto = manifiesto;

                _coordinacion.actualizarDescargaATM(_descarga);

                dtpFechaDescarga.Value = manifiesto.Fecha;

                txtManifiestoDescarga.Text = manifiesto.Codigo;
                txtMarchamoDescarga.Text = manifiesto.Marchamo_adicional;


                this.validarOpcionesDescarga();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Mostrar los datos del manifiesto seleccionado para una descarga full.
        /// </summary>
        public void seleccionarManifiestoDescargaFull(ManifiestoATMFull manifiesto)
        {

            try
            {
                _descarga_full.Manifiesto = manifiesto;

                _coordinacion.actualizarDescargaATMFull(_descarga_full);

                dtpFechaDescargaFull.Value = manifiesto.Fecha;

                txtManifiestoDescargaFull.Text = _descarga_full.Codigo_manifiesto;
                txtMarchamoDescargaFull.Text = _descarga_full.Codigo_marchamo;

                this.validarOpcionesDescargaFull();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Agregar una carga a la lista de cargas.
        /// </summary>
        public void agregarCarga(CargaATM carga)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargas.DataSource;

            carga.Hora_inicio = DateTime.Now;
            carga.Hora_finalizacion = DateTime.Now;

            cargas.Add(carga);
            dgvCargas.AutoResizeColumns();

            btnCargasPendientes.Enabled = false;
        }

        /// <summary>
        /// Agregar una descarga a la lista de descargas.
        /// </summary>
        public void agregarDescarga(DescargaATM descarga)
        {
            BindingList<DescargaATM> descargas = (BindingList<DescargaATM>)dgvDescargas.DataSource;


            descargas.Add(descarga);
            dgvDescargas.AutoResizeColumns();
        }



        

        /// <summary>
        /// Agregar una descarga full a la lista de descargas full.
        /// </summary>
        public void agregarDescargaFull(DescargaATMFull descarga)
        {
            BindingList<DescargaATMFull> descargas = (BindingList<DescargaATMFull>)dgvDescargasFull.DataSource;

            descargas.Add(descarga);
            dgvDescargasFull.AutoResizeColumns();
        }


        

        public void mostrarManifiestosDigital()
        {
            
        }

        #endregion Métodos Públicos

        #region Metodos Estaticos
        
        static DateTime GetYesterday(DateTime fecha)
        {
            // Add -1 to now
            return fecha.AddDays(-1);
        }

        #endregion Metodos Estaticos

        private void frmRegistroCierreATMs_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Muestra el manifiesto digital
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        
        private void btnManifiestoDigital_Click(object sender, EventArgs e)
        {
            try
            {
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                _carga.Cajero = cajero;

               
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



       

       

       
    }
}
