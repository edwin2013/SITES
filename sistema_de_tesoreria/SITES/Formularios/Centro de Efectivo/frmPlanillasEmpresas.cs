using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmPlanillasEmpresas : Form
    {

        #region Atributos
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private BindingList<Planilla> _planillas = new BindingList<Planilla>();
        private BindingList<Planilla> _planillascorrectas = new BindingList<Planilla>();
        private BindingList<Planilla> _planillas_manifiesto = new BindingList<Planilla>();
        private BindingList<Planilla> _planillascorrectas_manifiesto = new BindingList<Planilla>();
        private BindingList<Planilla> _planillaprocesados = new BindingList<Planilla>();
        private InconsistenciaPlanilla _modificacion = new InconsistenciaPlanilla();

        private Colaborador _coordinador = null;

        private string _archivo = string.Empty;


        #endregion Atributos

        #region Constructor
        public frmPlanillasEmpresas(Colaborador coordinador)
        {
            InitializeComponent();
            _coordinador = coordinador;
            dgvPlanillas.AutoGenerateColumns = false;
            dgvValidacion.AutoGenerateColumns = false;
            dgvIncorrectas.AutoGenerateColumns = false;
            dgvInconsistencias.AutoGenerateColumns = false;
            dgvPlanillasProcesadas.AutoGenerateColumns = false;
            dgvInconsistenciasProcesamiento.AutoGenerateColumns = false;
            cbEmpresas.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            cboTransportadoraExterna.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            
        }
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el boton de abrir
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdPlanillas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdPlanillas.FileName;

                    this.generarPlanillas();

                    btnAceptar.Enabled = (_planillas.Count > 0 || _planillaprocesados.Count > 0); //&& _filas_incorrectas.Count == 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _planillas.Clear();

                    btnAceptar.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorCargasGeneracionFormatoArchivo");
            }

            txtArchivo.Text = _archivo;
        }


        /// <summary>
        /// Clic en el boton de aceptar
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dgvValidacion.DataSource = null;
            dgvIncorrectas.DataSource = null;
            try
            {
                _coordinacion.importarPlanillas(_planillas, _coordinador);


                //_coordinacion.importarPlanillasProcesadas(_planillaprocesados, _coordinador);

                Mensaje.mostrarMensaje("MensajeImportacionPlanillas");

                btnAceptar.Enabled = false;

                tcManejoPlanillas.SelectedTab = tpValidaciónPlanilla;

                dgvValidacion.DataSource = _coordinacion.ValidarPlanillas(_planillas, _coordinador);
                if (dgvValidacion.Rows.Count > 0)
                {
                    dgvIncorrectas.DataSource = _coordinacion.ListarInconsistencias(_planillas, _coordinador);
                }
                else
                {
                    Mensaje.mostrarMensaje("MensajeInconsistenciaCrucePlanillas");
                }





                //dgvValidacion.DataSource = 
                _coordinacion.ValidarPlanillasProcesamiento(_planillaprocesados, _coordinador);
                //if (dgvValidacion.Rows.Count > 0)
                //{
                   // dgvIncorrectas.DataSource =
                        _coordinacion.ListarInconsistenciasProcesamiento(_planillaprocesados, _coordinador);
                //}
                //else
                //{
                //    Mensaje.mostrarMensaje("MensajeInconsistenciaCrucePlanillas");
                //}

                //dgvPlanillas.DataSource = null;

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Lee el archivo a importar y genera las cargas
        /// </summary>
        private void generarPlanillas()
        {
            DocumentoExcel archivo = null;

            try
            {
                _planillas.Clear();
                
                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_Fecha = archivo.seleccionarCelda(mtbCeldaFecha.Text);
                Celda celda_Manifiesto = archivo.seleccionarCelda(mtbManifiestoCelda.Text);
                Celda celda_Transportadora = archivo.seleccionarCelda(mtbTransportadoraPlanillaCelda.Text);
                Celda celda_Tula = archivo.seleccionarCelda(mtbTulaCelda.Text);
                Celda celda_Monto_Tula = archivo.seleccionarCelda(mtbMonto_tula.Text);
                Celda celda_Monto_Planilla = archivo.seleccionarCelda(mtbMonto_Planilla.Text);
                Celda celda_ID_Punto_Venta = archivo.seleccionarCelda(mtbID_PDV.Text);
                Celda celda_Punto_Venta = archivo.seleccionarCelda(mtbPDV.Text);
                Celda celda_Tarifa = archivo.seleccionarCelda(mtbCeldaTarifa.Text);
                Celda celda_Recargo = archivo.seleccionarCelda(mtbCeldaRecargo.Text);
                Celda celda_Total = archivo.seleccionarCelda(mtbCeldaTotal.Text);

                this.generarPlanillasDatos(archivo, celda_Fecha, celda_Manifiesto, celda_Transportadora, celda_Tula,celda_Monto_Tula,celda_Monto_Planilla,celda_ID_Punto_Venta,celda_Punto_Venta, celda_Tarifa, celda_Recargo, celda_Total);


                dgvPlanillas.DataSource = _planillas;
                dgvPlanillasProcesadas.DataSource = _planillaprocesados;

                //archivo.mostrar();
                archivo.cerrar();

                // Dar formato a las cargas

                //foreach (DataGridViewRow fila in dgvPlanillas.Rows)
                //    this.validarCarga(fila);
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }

        /// <summary>
        /// Genera las cargas de las inconsistencias
        /// </summary>
        /// <param name="archivo">Archivo Excel a importar</param>
        /// <param name="celda_Fecha">Fecha de la importacion</param>
        /// <param name="celda_Manifiesto">Numero de manifiesto de la importacion</param>
        /// <param name="celda_Transportadora">Transportadora a la que pertenece el archivo</param>
        /// <param name="celda_Tula">Numero de tula a importar</param>
        private void generarPlanillasDatos(DocumentoExcel archivo, Celda celda_Fecha, Celda celda_Manifiesto, Celda celda_Transportadora, Celda celda_Tula, Celda celda_Monto_Tula, Celda celda_Monto_Planilla, Celda celda_ID_Punto_Venta, Celda celda_Punto_Venta, Celda celda_Tarifa, Celda celda_Recargo, Celda celda_Total)
        {
            // Leer las denominaciones

            try
            {

                while (!celda_Tula.Valor.Equals(string.Empty))
                {

                    Planilla planilla = null;
                    string mani = celda_Manifiesto.Valor;
                    string tula = celda_Tula.Valor;
                    decimal montoplanilla;
                    decimal montotula;
                    decimal tarifa;
                    decimal recargo;
                    decimal total;
                    int id_pdv;
                    PuntoVenta p = new PuntoVenta();

                    DateTime fecha = DateTime.Parse(celda_Fecha.Texto);
                    byte numero_transportadora = byte.Parse(celda_Transportadora.Valor);
                    EmpresaTransporte transp = new EmpresaTransporte(id: numero_transportadora);
                    transp = _mantenimiento.obtenerDatosEmpresa(ref transp);

                    if (celda_Monto_Planilla.Valor == "" || celda_Monto_Planilla.Valor == "-")
                    { montoplanilla = 0; }
                    else
                    { montoplanilla = decimal.Parse(celda_Monto_Planilla.Valor); }

                    if (celda_Monto_Tula.Valor == "" || celda_Monto_Tula.Valor == "-")
                    { montotula = 0; }
                    else
                    { montotula = decimal.Parse(celda_Monto_Tula.Valor); }

                    if (celda_ID_Punto_Venta.Valor == "" || celda_ID_Punto_Venta.Valor == "-")
                    { id_pdv = 0; }
                    else
                    { id_pdv = int.Parse(celda_ID_Punto_Venta.Valor); }

                    if (celda_Tarifa.Valor == "" || celda_Tarifa.Valor == "-" || celda_Tarifa.Valor == "0")
                    { tarifa = 0; }
                    else
                    { tarifa = decimal.Parse(celda_Tarifa.Valor); }

                    if (celda_Recargo.Valor == "" || celda_Recargo.Valor == "-" || celda_Recargo.Valor == "0")
                    { recargo = 0; }
                    else
                    { recargo = decimal.Parse(celda_Recargo.Valor); }

                    if (celda_Total.Valor == "" || celda_Total.Valor == "-" || celda_Total.Valor == "0")
                    { total = 0; }
                    else
                    { total = decimal.Parse(celda_Total.Valor); }

                    string pdventa = celda_Punto_Venta.Valor;

                    CommonObjects.Clases.PuntoAtencion Punto = new CommonObjects.Clases.PuntoAtencion();
                    if (pdventa == "SUCURSAL" || pdventa == "CE")
                    {
                        Punto.TipoPuntodeAtencion = CommonObjects.Clases.TipoPuntoAtencion.Sucursal;

                    }
                    if (pdventa == "CLIENTE" || pdventa == "PROVAL")
                    {

                        Punto.TipoPuntodeAtencion = CommonObjects.Clases.TipoPuntoAtencion.Cliente;

                        p = new PuntoVenta(id: (short)id_pdv);

                        _mantenimiento.obtenerDatosPuntoVenta(ref p);
                    }
                    if (pdventa == "0" || pdventa == "" || pdventa == "-")
                    {
                        Punto.TipoPuntodeAtencion = 0;
                    }

                 

                    planilla = new Planilla(tula: tula, transporte: transp, Fecha: fecha, manifiesto: mani, Monto_Planilla: montoplanilla, Monto_Tula: montotula, id_Pdv: id_pdv, PA: Punto, Tarifa: tarifa, Recargo: recargo, Total: total);

                    
                    if (p.Procesado == false)
                        _planillas.Add(planilla);
                    else
                        _planillaprocesados.Add(planilla);


                    celda_Fecha = archivo.seleccionarCelda(celda_Fecha.Fila + 1, celda_Fecha.Columna);
                    celda_Manifiesto = archivo.seleccionarCelda(celda_Manifiesto.Fila + 1, celda_Manifiesto.Columna);
                    celda_Transportadora = archivo.seleccionarCelda(celda_Transportadora.Fila, celda_Transportadora.Columna);
                    celda_Tula = archivo.seleccionarCelda(celda_Tula.Fila + 1, celda_Tula.Columna);
                    celda_Monto_Tula = archivo.seleccionarCelda(celda_Monto_Tula.Fila + 1, celda_Monto_Tula.Columna);
                    celda_Monto_Planilla = archivo.seleccionarCelda(celda_Monto_Planilla.Fila + 1, celda_Monto_Planilla.Columna);
                    celda_ID_Punto_Venta = archivo.seleccionarCelda(celda_ID_Punto_Venta.Fila + 1, celda_ID_Punto_Venta.Columna);
                    celda_Punto_Venta = archivo.seleccionarCelda(celda_Punto_Venta.Fila + 1, celda_Punto_Venta.Columna);
                    celda_Tarifa = archivo.seleccionarCelda(celda_Tarifa.Fila + 1, celda_Tarifa.Columna);
                    celda_Recargo = archivo.seleccionarCelda(celda_Recargo.Fila + 1, celda_Recargo.Columna);
                    celda_Total = archivo.seleccionarCelda(celda_Total.Fila + 1, celda_Total.Columna);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtgIncorrectas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          //  MessageBox.Show("Error happened " + e.Context.ToString());

            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        /// <summary>
        /// Cambio de Estado en el data Grid
        /// </summary>
        private void dgvPlanillas_SelectionChanged(object sender, EventArgs e)
        {
            btnValidar.Enabled = dgvPlanillas.Rows.Count > 0;
        }

        /// <summary>
        /// Cambio en el dataGrid de datos de validcion
        /// </summary>
        private void dgvValidacion_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                btnValidar.Enabled = dgvValidacion.Rows.Count > 0;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Cambia el color de las filas cuando se agregan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvValidacion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvValidacion.Rows[e.RowIndex + contador];

                fila.DefaultCellStyle.BackColor = Color.Green;

            }
        }


        /// <summary>
        /// Se agrega una fila al datagridview de inconsistencias
        /// </summary>
        private void dgvIncorrectas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvIncorrectas.Rows[e.RowIndex + contador];

                fila.DefaultCellStyle.BackColor = Color.Red;

            }
        }


        /// <summary>
        /// Valida las inconsistencias
        /// </summary>
        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (dgvValidacion.Rows.Count > 0)
            {
                btnAceptar.Enabled = false;
                tcManejoPlanillas.SelectedTab = tcInconsistencias;
                Planilla incon = (Planilla)dgvValidacion.Rows[0].DataBoundItem;
                cbEmpresas.SelectedItem = incon.Empresa;
                EmpresaTransporte nueva = (EmpresaTransporte)cbEmpresas.SelectedItem;
                dtpFechaInconsistencia.Value = Convert.ToDateTime(dgvValidacion.Rows[0].Cells["FechaT"].Value);
                cbEstado.SelectedIndex = (byte)Estado.Pendiente;
                ListarInconsistencias();




                /// Inconsistencias Procesamiento
                /// 
                //btnAceptar.Enabled = false;
  
                //Planilla inconproc = (Planilla)dgvValidacion.Rows[0].DataBoundItem;
                //cbEmpresas.SelectedItem = incon.Empresa;
                //EmpresaTransporte nueva = (EmpresaTransporte)cbEmpresas.SelectedItem;
                //dtpFechaInconsistencia.Value = Convert.ToDateTime(dgvValidacion.Rows[0].Cells["FechaT"].Value);
                //cbEstado.SelectedIndex = (byte)Estado.Pendiente;
                ListarInconsistenciasProcesamiento();
       
            }
        }




        /// <summary>
        /// Clic en el boton buscar
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarInconsistencias();
        }


        /// <summary>
        /// Lista las inconsistencias en la base de datos
        /// </summary>
        private void ListarInconsistencias()
        {
            // Leer las denominaciones
            try
            {

                Estado estado = new Estado();
                estado = (Estado)cbEstado.SelectedIndex;
                if (estado == Estado.Pendiente)
                {
                    dgvInconsistencias.Columns["FechaResolucion"].Visible = false;
                }
                else
                {
                    dgvInconsistencias.Columns["FechaResolucion"].Visible = true;
                }

                EmpresaTransporte emp = (EmpresaTransporte)cbEmpresas.SelectedItem;
                BindingList<InconsistenciaPlanilla> nueva_lista = Inconsistencias(estado, dtpFechaInconsistencia.Value, emp);
                dgvInconsistencias.DataSource = nueva_lista;
                              
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
       }






        /// <summary>
        /// Lista las inconsistencias en la base de datos
        /// </summary>
        private void ListarInconsistenciasProcesamiento()
        {
            // Leer las denominaciones
            try
            {

                Estado estado = new Estado();
                estado = (Estado)cboInconsistenciaExterna.SelectedIndex;
                if (estado == Estado.Pendiente)
                {
                    dgvInconsistenciasProcesamiento.Columns["FechaResolucionProcesamiento"].Visible = false;
                }
                else
                {
                    dgvInconsistenciasProcesamiento.Columns["FechaResolucionProcesamiento"].Visible = true;
                }

                EmpresaTransporte emp = (EmpresaTransporte)cboTransportadoraExterna.SelectedItem;
                BindingList<InconsistenciaPlanilla> nueva_lista = InconsistenciasProcesamiento(estado, dtpFechaImportacionProcesamiento.Value, emp);
                dgvInconsistenciasProcesamiento.DataSource = nueva_lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// Lista las inconsistencias de una empresa en planilla
        /// </summary>
        /// <param name="estado">Estado de la inconsistencia</param>
        /// <param name="fecha">Fecha de importacion</param>
        /// <param name="emp">Empresa a la que pertenece la inconsistencia</param>
        /// <returns></returns>
        private BindingList<InconsistenciaPlanilla> Inconsistencias(Estado estado, DateTime fecha, EmpresaTransporte emp)
        {
            BindingList<InconsistenciaPlanilla> incon = new BindingList<InconsistenciaPlanilla>();
            try
            {
                
              incon = _coordinacion.ExportarInconsistencias(estado, fecha, emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return incon; ;
        }





        /// <summary>
        /// Lista las inconsistencias de una empresa en planilla
        /// </summary>
        /// <param name="estado">Estado de la inconsistencia</param>
        /// <param name="fecha">Fecha de importacion</param>
        /// <param name="emp">Empresa a la que pertenece la inconsistencia</param>
        /// <returns></returns>
        private BindingList<InconsistenciaPlanilla> InconsistenciasProcesamiento(Estado estado, DateTime fecha, EmpresaTransporte emp)
        {
            BindingList<InconsistenciaPlanilla> incon = new BindingList<InconsistenciaPlanilla>();
            try
            {

                incon = _coordinacion.ExportarInconsistenciasProcesamiento(estado, fecha, emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return incon; ;
        }

        /// <summary>
        /// Error en la tabla de inconsistencias
        /// </summary>
        private void dgvInconsistencias_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        private void dgvPlanillas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dgvInconsistencias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow fila = dgvInconsistencias.Rows[e.RowIndex];
            //InconsistenciaPlanilla incon = (InconsistenciaPlanilla)fila.DataBoundItem;
            //try
            //{
            //    _mantenimiento.actualizarInconsistencia(incon);
               
            //}
            //catch (Excepcion ex)
            //{
            //    ex.mostrarMensaje();
            //}
        }


        /// <summary>
        /// Clic en el datagridview de inconsistencias
        /// </summary>
        private void dgvInconsistencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _modificacion = (InconsistenciaPlanilla)dgvInconsistencias.Rows[e.RowIndex].DataBoundItem;
                if (_modificacion.Tula.Trim() == "")
                {
                    txtTulaSites.Enabled = false;
                    txtTulaEmpresa.Enabled = true;
                }
                if (_modificacion.TulaPl.Trim() == "")
                {
                   
                    txtTulaEmpresa.Enabled = false;
                    txtTulaSites.Enabled = true;
                    
                }
                txtTulaEmpresa.Text = _modificacion.TulaPl;
                txtTulaSites.Text = _modificacion.Tula;
                txtComentario.Text = _modificacion.Comentario;
                cbOrigen.SelectedIndex = (byte)_modificacion.Origen;
                cbTipoInconsistencia.SelectedIndex = (byte)_modificacion.Tipo;
            }

        }

      
        /// <summary>
        /// clic en el boton de corregir
        /// </summary>
        private void btnCorregir_Click(object sender, EventArgs e)
        {
            //InconsistenciaPlanilla incon = (InconsistenciaPlanilla)dgvInconsistencias.SelectedRows[0].DataBoundItem;
            try
            {
                if (txtTulaEmpresa.Text.Length > 1 || txtTulaSites.Text.Length > 1)
                {
                    _modificacion.Origen = (Origen)cbOrigen.SelectedIndex;
                    _modificacion.Tipo = (Tipo)cbTipoInconsistencia.SelectedIndex;
                    _modificacion.Tula = txtTulaSites.Text;
                    _modificacion.TulaPl = txtTulaEmpresa.Text;
                    _modificacion.Comentario = txtComentario.Text;
                    _mantenimiento.actualizarInconsistencia(_modificacion, _coordinador);
                    dgvInconsistencias.DataSource = null;
                    dgvInconsistencias.DataSource = Inconsistencias((Estado)Estado.Pendiente, dtpFechaInconsistencia.Value, (EmpresaTransporte)cbEmpresas.SelectedItem);
                    txtComentario.Text = "";
                    txtTulaEmpresa.Text = "";
                    txtTulaSites.Text = "";
                    cbOrigen.Text = "";
                    cbTipoInconsistencia.Text = "";
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Cambio en la tabla de inconsistencias
        /// </summary>
        private void dgvInconsistencias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                btnCorregir.Enabled = dgvInconsistencias.Columns.Count > 0;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Cambio en el combo de estado
        /// </summary>
        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.SelectedIndex == 1)
            {
                txtComentario.Enabled = false;
                txtTulaEmpresa.Enabled = false;
                txtTulaSites.Enabled = false;
                cbOrigen.Enabled = false;
                cbTipoInconsistencia.Enabled = false;
                txtComentario.Text = "";
                txtTulaEmpresa.Text = "";
                txtTulaSites.Text = "";
                cbOrigen.Text = "";
                cbTipoInconsistencia.Text = "";
            }
            else
            {
                txtComentario.Enabled = true;
                txtTulaEmpresa.Enabled = true;
                txtTulaSites.Enabled = true;
                cbOrigen.Enabled = true;
                cbTipoInconsistencia.Enabled = true;
                txtComentario.Text = "";
                txtTulaEmpresa.Text = "";
                txtTulaSites.Text = "";
                cbOrigen.Text = "";
                cbTipoInconsistencia.Text = "";
            }
        }

        /// <summary>
        /// Exporta el reporte a la plantilla de Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.imprimirReporte();
        }
        #endregion Eventos


        #region Metodos Privados

        /// <summary>
        /// Imprimir los datos de la plantilla de reporte
        /// </summary>
        private void imprimirReporte()
        {

            try
            {
                EmpresaTransporte empresa = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                BindingList<InconsistenciaPlanilla> _planillas = _coordinacion.reportePlanillas(dtpFechaReporte.Value, empresa, dtpFechaReporteFin.Value);
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla validacion planillas.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("E3");
                documento.actualizarValorCelda(dtpFechaReporte.Value);

                documento.seleccionarCelda("E6");
                documento.actualizarValorCelda(dtpFechaReporteFin.Value);

                Colaborador c = new Colaborador();
               
                // Imprimir las inconsistencias

                int fila = 11;
                int columna = 1;

                foreach (InconsistenciaPlanilla inconsistencia in _planillas)
                {

                            //Tula SITES
                            documento.seleccionarCelda(fila, 1);
                            documento.actualizarValorCelda(inconsistencia.Tula);
                            //Tula Planilla
                            documento.seleccionarCelda(fila, 2);
                            documento.actualizarValorCelda(inconsistencia.TulaPl);
                            // Manifiesto
                            documento.seleccionarCelda(fila, 3);
                            documento.actualizarValorCelda(inconsistencia.manifiesto);
                            // Transportadora
                            documento.seleccionarCelda(fila, 4);
                            documento.actualizarValorCelda(inconsistencia.Empresa.ToString());
                            // Fecha
                            documento.seleccionarCelda(fila, 5);
                            documento.actualizarValorCelda(inconsistencia.Fecha.ToShortDateString());
                            // Grupo
                            documento.seleccionarCelda(fila, 6);
                            documento.actualizarValorCelda(inconsistencia.Grupo.ToString());
                            // Comentarios
                            documento.seleccionarCelda(fila, 7);
                            documento.actualizarValorCelda(inconsistencia.Comentario);
                            // Origen de la Inconsistencia
                            documento.seleccionarCelda(fila, 8);
                            if (inconsistencia.Origen == Origen.Sites)
                                documento.actualizarValorCelda("SITES");
                            else
                                documento.actualizarValorCelda("Archivo de Transportadora");
                            //Tipo Inconsistencia
                            documento.seleccionarCelda(fila, 9);
                            if(inconsistencia.Tipo == Tipo.Error_de_digitación_por_parte_de_la_transportadora)
                                documento.actualizarValorCelda("Error de Digitación Por Parte de la Transportadora");
                            if (inconsistencia.Tipo == Tipo.Error_de_digitación_por_parte_del_receptor_BAC)
                                documento.actualizarValorCelda("Error de Digitación Por Parte del Receptor BAC");
                            if (inconsistencia.Tipo == Tipo.No_se_recibio_tula_reportada_por_la_transportadora)
                                documento.actualizarValorCelda("No recibido de Tula Reportada por la Transportadora");
                            if (inconsistencia.Tipo == Tipo.Se_recibio_tula_no_reportada_por_la_transportadora)
                                documento.actualizarValorCelda("Tula no reportada por la transportadora");

                            //Estado
                            documento.seleccionarCelda(fila, 10);
                            if (inconsistencia.Estado == Estado.Resuelta)
                                documento.actualizarValorCelda("Resuelta");
                            else
                                documento.actualizarValorCelda("Pendiente");
                           
                           
                            fila++;


                            c = inconsistencia.Colaborador;

                }


                documento.seleccionarCelda("G3");
                documento.actualizarValorCelda(c.ToString());
                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }





        private void imprimirReporteProcesamiento()
        {

            try
            {
                EmpresaTransporte empresa = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                BindingList<InconsistenciaPlanilla> _planillas = _coordinacion.reportePlanillasProcesamiento(dtpFechaReporte.Value, empresa, dtpFechaReporteFin.Value);
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla validacion planillas.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("E3");
                documento.actualizarValorCelda(dtpFechaReporte.Value);

                documento.seleccionarCelda("E6");
                documento.actualizarValorCelda(dtpFechaReporteFin.Value);

                Colaborador c = new Colaborador();

                // Imprimir las inconsistencias

                int fila = 11;
                int columna = 1;

                foreach (InconsistenciaPlanilla inconsistencia in _planillas)
                {

                    //Tula SITES
                    documento.seleccionarCelda(fila, 1);
                    documento.actualizarValorCelda(inconsistencia.Tula);
                    //Tula Planilla
                    documento.seleccionarCelda(fila, 2);
                    documento.actualizarValorCelda(inconsistencia.TulaPl);
                    // Manifiesto
                    documento.seleccionarCelda(fila, 3);
                    documento.actualizarValorCelda(inconsistencia.manifiesto);
                    // Transportadora
                    documento.seleccionarCelda(fila, 4);
                    documento.actualizarValorCelda(inconsistencia.Empresa.ToString());
                    // Fecha
                    documento.seleccionarCelda(fila, 5);
                    documento.actualizarValorCelda(inconsistencia.Fecha.ToShortDateString());
                    // Grupo
                    documento.seleccionarCelda(fila, 6);
                    documento.actualizarValorCelda(inconsistencia.Grupo.ToString());
                    // Comentarios
                    documento.seleccionarCelda(fila, 7);
                    documento.actualizarValorCelda(inconsistencia.Comentario);
                    // Origen de la Inconsistencia
                    documento.seleccionarCelda(fila, 8);
                    if (inconsistencia.Origen == Origen.Sites)
                        documento.actualizarValorCelda("SITES");
                    else
                        documento.actualizarValorCelda("Archivo de Transportadora");
                    //Tipo Inconsistencia
                    documento.seleccionarCelda(fila, 9);
                    if (inconsistencia.Tipo == Tipo.Error_de_digitación_por_parte_de_la_transportadora)
                        documento.actualizarValorCelda("Error de Digitación Por Parte de la Transportadora");
                    if (inconsistencia.Tipo == Tipo.Error_de_digitación_por_parte_del_receptor_BAC)
                        documento.actualizarValorCelda("Error de Digitación Por Parte del Receptor BAC");
                    if (inconsistencia.Tipo == Tipo.No_se_recibio_tula_reportada_por_la_transportadora)
                        documento.actualizarValorCelda("No recibido de Tula Reportada por la Transportadora");
                    if (inconsistencia.Tipo == Tipo.Se_recibio_tula_no_reportada_por_la_transportadora)
                        documento.actualizarValorCelda("Tula no reportada por la transportadora");

                    //Estado
                    documento.seleccionarCelda(fila, 10);
                    if (inconsistencia.Estado == Estado.Resuelta)
                        documento.actualizarValorCelda("Resuelta");
                    else
                        documento.actualizarValorCelda("Pendiente");


                    fila++;


                    c = inconsistencia.Colaborador;

                }


                documento.seleccionarCelda("G3");
                documento.actualizarValorCelda(c.ToString());
                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }
        #endregion Metodos Privados


        /// <summary>
        /// Clic en el boton buscar de 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportarExterna_Click(object sender, EventArgs e)
        {
            ListarInconsistenciasProcesamiento();
        }

        private void dgvInconsistenciasProcesamiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvInconsistenciasProcesamiento_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                btnModificarIncosistenciasP.Enabled = dgvInconsistenciasProcesamiento.Columns.Count > 0;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void dgvInconsistenciasProcesamiento_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        private void dgvInconsistenciasProcesamiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _modificacion = (InconsistenciaPlanilla)dgvInconsistenciasProcesamiento.Rows[e.RowIndex].DataBoundItem;
                if (_modificacion.Tula.Trim() == "")
                {
                    txtManifiestoSITES.Enabled = false;
                    txtManifiestoEmpresa.Enabled = true;
                }
                if (_modificacion.TulaPl.Trim() == "")
                {

                    txtManifiestoEmpresa.Enabled = false;
                    txtManifiestoSITES.Enabled = true;

                }
                txtManifiestoEmpresa.Text = _modificacion.TulaPl;
                txtManifiestoSITES.Text = _modificacion.Tula;
                txtComentariosP.Text = _modificacion.Comentario;
                cboOrigenInconsistenciaP.SelectedIndex = (byte)_modificacion.Origen;
                cboTipoInconsistenciaP.SelectedIndex = (byte)_modificacion.Tipo;
            }
        }

        private void dgvInconsistenciasProcesamiento_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                btnModificarIncosistenciasP.Enabled = dgvInconsistenciasProcesamiento.Columns.Count > 0;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void dgvInconsistenciasProcesamiento_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        private void dgvInconsistenciasProcesamiento_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _modificacion = (InconsistenciaPlanilla)dgvInconsistenciasProcesamiento.Rows[e.RowIndex].DataBoundItem;
                if (_modificacion.manifiesto.Trim() == "")
                {
                    txtManifiestoSITES.Enabled = false;
                    txtManifiestoEmpresa.Enabled = true;
                }
                if (_modificacion.TulaPl.Trim() == "")
                {

                    txtTulaEmpresa.Enabled = false;
                    txtTulaSites.Enabled = true;

                }
                txtManifiestoEmpresa.Text = _modificacion.TulaPl;
                txtManifiestoSITES.Text = _modificacion.Tula;
                txtComentariosP.Text = _modificacion.Comentario;
                cboOrigenInconsistenciaP.SelectedIndex = (byte)_modificacion.Origen;
                cboTipoInconsistenciaP.SelectedIndex = (byte)_modificacion.Tipo;
            }
        }

        private void btnModificarIncosistenciasP_Click(object sender, EventArgs e)
        {
            //InconsistenciaPlanilla incon = (InconsistenciaPlanilla)dgvInconsistencias.SelectedRows[0].DataBoundItem;
            try
            {
                if (txtManifiestoEmpresa.Text.Length > 1 || txtManifiestoSITES.Text.Length > 1)
                {
                    _modificacion.Origen = (Origen)cboOrigenInconsistenciaP.SelectedIndex;
                    _modificacion.Tipo = (Tipo)cboTipoInconsistenciaP.SelectedIndex;
                    _modificacion.Tula = txtManifiestoSITES.Text;
                    _modificacion.TulaPl = txtManifiestoEmpresa.Text;
                    _modificacion.Comentario = txtComentariosP.Text;
                    _mantenimiento.actualizarInconsistenciaProcesamiento(_modificacion, _coordinador);
                    dgvInconsistenciasProcesamiento.DataSource = null;
                    dgvInconsistenciasProcesamiento.DataSource = Inconsistencias((Estado)Estado.Pendiente, dtpFechaInconsistencia.Value, (EmpresaTransporte)cbEmpresas.SelectedItem);
                    txtComentariosP.Text = "";
                    txtManifiestoEmpresa.Text = "";
                    txtManifiestoEmpresa.Text = "";
                    cboOrigenInconsistenciaP.Text = "";
                    cboTipoInconsistenciaP.Text = "";
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void dgvPlanillasProcesadas_SelectionChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = (dgvPlanillasProcesadas.Rows.Count > 0 || dgvPlanillas.Rows.Count > 0);
        }


        /// <summary>
        /// Clic en el botón de imprimir reporte procesamiento
        /// </summary>
        private void btnReporteProcesamiento_Click(object sender, EventArgs e)
        {
            this.imprimirReporteProcesamiento();
        }


    }
}
