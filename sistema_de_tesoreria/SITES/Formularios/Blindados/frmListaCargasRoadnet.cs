//
//  @ Project : 
//  @ File Name : frmListaCargas.cs
//  @ Date : 13/06/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;
using GUILayer.Formularios.Blindados;
using System.Data;
using System.Collections.Generic;

namespace GUILayer
{

    public partial class frmListaCargasRoadnet : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private BindingList<CargaATM> _cargas = new BindingList<CargaATM>();
        private Colaborador _colaborador = null;
        private string _archivo = string.Empty;
        private bool _coordinador = false;

        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Constructor

        public frmListaCargasRoadnet() {

            InitializeComponent();        
        }

        public frmListaCargasRoadnet(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor);

            dgvCargas.AutoGenerateColumns = false;
            dgvCargaATM.AutoGenerateColumns = false;
            dgvCargasSucursales.AutoGenerateColumns = false;

            if (_coordinador)
            {
               
                btnActualizar.Enabled = true;
                //pnlOpcionesCoordinacion.Enabled = _coordinador;
                //pnlOpcionesCoordinacion.Enabled = _analista;
            }
           
            

            try
            {
                dgvCargasSucursales.AutoGenerateColumns = false;
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
                DateTime fecha = dtpFecha.Value;
                Colaborador cajero = null;
                ATM atm = null;
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                EmpresaTransporte empresa = new EmpresaTransporte();
                empresa.DB_ID = 5;
  
                dgvCargaATM.DataSource = _coordinacion.listarCargasATMsEspecialesRoadnetExportacion(cajero,atm,fecha,ruta,empresa);
                dgvCargasSucursales.DataSource = _coordinacion.listarCargasSucursalesRoadnet(null,null,fecha,ruta, CommonObjects.Clases.EstadoAprobacionCargas.Aprobada);
                dgvCargas.DataSource = _coordinacion.listarPedidosBancosRoadnet(null, null, fecha, ruta);
          
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de asignar ruta.
        /// </summary>
        private void btnAsignarRuta_Click(object sender, EventArgs e)
        {

            try
            {
                BindingList<CargaATM> cargas = new BindingList<CargaATM>();

                foreach (DataGridViewRow fila in dgvCargasSucursales.SelectedRows)
                    cargas.Add((CargaATM)fila.DataBoundItem);

                frmAsignarRuta formulario = new frmAsignarRuta(cargas);

                formulario.ShowDialog(this);

                dgvCargasSucursales.Refresh();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

      
        /// <summary>
        /// Clic en el botón de eliminar carga.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaATMEliminacion") == DialogResult.Yes)
                {

                    foreach (DataGridViewRow fila in dgvCargasSucursales.SelectedRows)
                    {
                        CargaATM carga = (CargaATM)fila.DataBoundItem;

                        _coordinacion.eliminarCargaATM(carga, _colaborador);

                        dgvCargasSucursales.Rows.Remove(fila);
                    }

                    Mensaje.mostrarMensaje("MensajeCargaATMConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de revisar los cartuchos por denominación y tipo.
        /// </summary>
        private void btnCartuchos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargasSucursales.DataSource;
            frmCartuchosCarga formulario = new frmCartuchosCarga(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de todas las cargas.
        /// </summary>
        private void btnMontos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargasSucursales.DataSource;
            frmMontosCajeroCargas formulario = new frmMontosCajeroCargas(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de ordenar ruta.
        /// </summary>
        private void btnOrdenRutas_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;

            frmOrdenRuta formulario = new frmOrdenRuta(fecha);

            formulario.ShowDialog();
        }


        /// <summary>
        /// Clic en el boton de Actualizar para coordinadores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizarEspecial_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFecha.Value;
                Colaborador cajero = null;
                ATM atm = null;
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;
                EmpresaTransporte transportadora = null;

                dgvCargasSucursales.DataSource = _coordinacion.listarCargasATMsEspeciales(cajero, atm, fecha, ruta,transportadora);
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
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargasSucursales.Rows[e.RowIndex + contador];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();

                if (carga.Colaborador_verificador != null)
                {

                    if (carga.Modificada)
                        fila.DefaultCellStyle.BackColor = Color.Green;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else if (carga.Cierre != null)
                {
                    fila.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (carga.Cajero != null)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }

            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargaATM.SelectedRows.Count > 0 || dgvCargasSucursales.SelectedRows.Count > 0 || dgvCargas.SelectedRows.Count > 0)
            {
                //DataGridViewRow fila = dgvCargaATM.SelectedRows[0];
                //CargaATM carga = (CargaATM)fila.DataBoundItem;

                btnAsignarRuta.Enabled = true;
                btnExportarExcel.Enabled = true;

            }
            else
            {
    
                btnAsignarRuta.Enabled = false;
                btnExportarExcel.Enabled = false;
              
            }

        }


        /// <summary>
        /// Clic en el boton de exportar en Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.exportar();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }
        }

        /// <summary>
        /// Se marca o desmarca la opción de filtrar por ruta.
        /// </summary>
        private void chkRuta_CheckedChanged(object sender, EventArgs e)
        {
            nudRuta.Enabled = chkRuta.Checked;
        }

        
        /// <summary>
        /// Clic en el boton Abrir
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;

                    this.generarRutas();

                    btnAceptar.Enabled = _cargas.Count > 0 && _filas_incorrectas.Count == 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _cargas.Clear();

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
            try
            {
                _coordinacion.importarRutasCargasATMs(_cargas);

                Mensaje.mostrarMensaje("MensajeCargasATMsConfirmacionGeneracion");

                dgvCargasSucursales.DataSource = null;

                btnAceptar.Enabled = false;
          
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        #endregion Eventos
     
        #region Métodos Privados



        /// <summary>
        /// Leer las rutas del archivo y generar las cargas.
        /// </summary>
        private void generarRutas()
        {
            DocumentoExcel archivo = null;

            try
            {
                _filas_incorrectas.Clear();

               _cargas.Clear();
                //_denominaciones.Clear();

                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

           
                Celda celda_a = archivo.seleccionarCelda(mtbPrimeraCelda.Text);
                Celda celda_atm = archivo.seleccionarCelda(mtbatmcelda.Text);
                Celda celda_ruta = archivo.seleccionarCelda(mtbRutaCelda.Text);
                Celda celda_hora = archivo.seleccionarCelda(mtbHoraCelda.Text);
                DateTime fecha = dtpFecha.Value;

                this.generarCargasATMs(archivo, fecha, celda_a, celda_atm,celda_ruta,celda_hora);
                

                dgvCargasSucursales.DataSource = _cargas;

                archivo.mostrar();
                archivo.cerrar();

                // Dar formato a las cargas

                foreach (DataGridViewRow fila in dgvCargasSucursales.Rows) { }
                    //this.validarCarga(fila);
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }


        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasATMs(DocumentoExcel archivo, DateTime fecha,
                                         Celda celda_a, Celda celda_atm, Celda celda_ruta, Celda celda_hora)
        {
            // Leer las denominaciones

           

            while (!celda_a.Valor.Equals(string.Empty))
            {
                short id_carga = short.Parse(celda_a.Valor);
                byte id_ruta = byte.Parse(celda_ruta.Valor);
                short numero_atm = short.Parse(celda_atm.Valor);
                DateTime hora = DateTime.FromOADate(Convert.ToDouble(celda_hora.Valor));
                //hora.ToString("hh:ss");
                ATM atm = new ATM(numero: numero_atm);

                _mantenimiento.obtenerDatosATM(ref atm);

                CargaATM carga = this.buscarCarga(atm, fecha, id_ruta,hora, id_carga);

                
                celda_a = archivo.seleccionarCelda(celda_a.Fila + 1, celda_a.Columna);
                celda_atm = archivo.seleccionarCelda(celda_atm.Fila + 1, celda_atm.Columna);
                celda_ruta = archivo.seleccionarCelda(celda_ruta.Fila + 1, celda_ruta.Columna);
                celda_hora = archivo.seleccionarCelda(celda_hora.Fila + 1, celda_hora.Columna);


            }

        }


        /// <summary>
        /// Buscar Guardar las cargas de los ATMs
        /// </summary>
        private CargaATM buscarCarga(ATM atm, DateTime fecha, byte ruta, DateTime hora, int id_carga)
        {

            CargaATM nueva = new CargaATM(atm, transportadora: atm.Empresa_encargada, fecha_asignada: fecha,
                                          tipo: atm.Tipo, externa: atm.Externo, atm_full: atm.Full,
                                          cartucho_rechazo: atm.Cartucho_rechazo, ena: atm.ENA,ruta:ruta,hora_llegada:hora,id:id_carga);

            _cargas.Add(nueva);

            return nueva;
        }

        /// <summary>
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {
            DocumentoExcel documento = new DocumentoExcel();
            try
            {

                DateTime fecha = dtpFecha.Value;
                if (dgvCargaATM.RowCount > 0)
                {
                    
                    DataTable datos = _coordinacion.listarCargasATMsExportar(fecha);
                    documento.seleccionarHoja(1);
                    
                   

                    int fila = 2;

                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B3");
                    documento.actualizarValorCelda("CARGAS ATM");

                    // Copiar los valores

                    int filas = datos.Rows.Count;

                    foreach (DataColumn columna in datos.Columns)
                    {
                        int numero_columna = columna.Ordinal +2;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.ColumnName);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filas, numero_columna);
                        documento.autoajustarTamanoColumnas();
                    }

                    documento.seleccionarCelda(fila + 1, 2);
                    documento.actualizarValoresTabla(datos);

                    documento.seleccionarCelda(fila, 2);
                    documento.seleccionarSegundaCelda(fila + filas, datos.Columns.Count + 1);
                    documento.formatoTabla(false);

                    // Mostrar el libro y cerrarlo

                }


                if (dgvCargasSucursales.RowCount > 0)
                {
                    DataTable datos = _coordinacion.listarCargasSucursalesExportar(fecha);
                    documento.seleccionarHoja(2);
                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B3");
                    documento.actualizarValorCelda("CARGAS SUCURSALES");

                    int fila = 2;

                    // Dar formato al encabezado del reporte


                    // Copiar los valores

                    int filas = datos.Rows.Count;

                    foreach (DataColumn columna in datos.Columns)
                    {
                        int numero_columna = columna.Ordinal + 2;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.ColumnName);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filas, numero_columna);
                        documento.autoajustarTamanoColumnas();
                    }

                    documento.seleccionarCelda(fila + 1, 2);
                    documento.actualizarValoresTabla(datos);
                    documento.autoajustarTamanoColumnas();
                    documento.seleccionarCelda(fila, 2);
                    documento.seleccionarSegundaCelda(fila + filas, datos.Columns.Count + 1);
                    documento.formatoTabla(false);

                }



                if (dgvCargas.RowCount > 0)
                {
                    DataTable datos = _coordinacion.listarCargasBancoExportar(fecha);
                    documento.seleccionarHoja(3);
                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B3");
                    documento.actualizarValorCelda("CARGAS BANCOS");

                    int fila = 2;

                    // Dar formato al encabezado del reporte


                    // Copiar los valores

                    int filas = datos.Rows.Count;

                    foreach (DataColumn columna in datos.Columns)
                    {
                        int numero_columna = columna.Ordinal + 2;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.ColumnName);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filas, numero_columna);
                        documento.autoajustarTamanoColumnas();
                    }

                    documento.seleccionarCelda(fila + 1, 2);
                    documento.actualizarValoresTabla(datos);

                    documento.seleccionarCelda(fila, 2);
                    documento.seleccionarSegundaCelda(fila + filas, datos.Columns.Count + 1);
                    documento.formatoTabla(false);

                }



                // Cerrar el libro y mostrarlo 
                documento.mostrar();
                documento.cerrar();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



     

        #endregion Métodos Privados

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }

        private void cboTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboATM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvCargas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       

       

    }

}
