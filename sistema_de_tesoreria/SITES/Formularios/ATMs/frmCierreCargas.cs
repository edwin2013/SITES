using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
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

namespace GUILayer.Formularios.ATMs
{
    public partial class frmCierreCargas : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CierreCargasATMs _cierre_cargas = null;
        private Colaborador _usuario = null;


        private decimal _libros_colones = 0;
        private decimal _libros_dolares = 0;
        private decimal _saldo_anterior_colones = 0;
        private decimal _saldo_anterior_dolares = 0;
        private decimal _pedido_boveda_colones = 0;
        private decimal _pedido_boveda_dolares = 0;
        private decimal _descarga_atm_colones = 0;
        private decimal _descarga_atm_dolares = 0;
        private decimal _pedido_boveda_adicional_colones = 0;
        private decimal _pedido_boveda_adicional_dolares = 0;
        private decimal _descarga_completa_colones = 0;
        private decimal _devolucion_atms_colones = 0;
        private decimal _descarga_completa_dolares = 0;
        private decimal _devolucion_atms_dolares = 0;
        private decimal _devolucion_emergencias_colones = 0;
        private decimal _devolucion_emergencias_dolares = 0;
        private decimal _entrega_boveda_colones = 0;
        private decimal _entrega_boveda_dolares = 0;
        private decimal _cargas_emergencia_colones = 0;
        private decimal _cargas_emergencia_dolares = 0;
        private decimal _cargas_atm_colones = 0;
        private decimal _cargas_atm_dolares = 0;
        private decimal _saldo_colones = 0;
        private decimal _saldo_dolares = 0;
        private decimal _saldo_cola_colones = 0;
        private decimal _saldo_cola_dolares = 0;
        private decimal _saldo_cartucho_colones = 0;
        private decimal _saldo_cartucho_dolares = 0;
        private decimal _saldo_20000 = 0;
        private decimal _saldo_10000 = 0;
        private decimal _saldo_5000 = 0;
        private decimal _saldo_2000 = 0;
        private decimal _saldo_1000 = 0;
        private decimal _saldo_100 = 0;
        private decimal _saldo_50 = 0;
        private decimal _saldo_20 = 0;
        private decimal _saldo_10 = 0;
        private decimal _saldo_5 = 0;
        private decimal _saldo_1 = 0;
        private decimal _saldo_efectivo_colones = 0;
        private decimal _saldo_efectivo_dolares = 0;
        private decimal _diferencias_colones = 0;
        private decimal _diferencias_dolares = 0;

       
        #endregion Atributos

        #region Constructor

        public frmCierreCargas()
        {
            InitializeComponent();

        }

        public frmCierreCargas(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;
            txtUsuario.Text = usuario.ToString();
            _cierre_cargas = new CierreCargasATMs();
            crearTabla(dgvCargas);
   
        }

        #endregion Constructor
        
        #region Eventos
        /// <summary>
        /// Actualiza los datos del formulario
        /// </summary>
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            _cierre_cargas = _coordinacion.obtenerCierreCargaATM(dtpFecha.Value);

            if (_cierre_cargas == null)
                _cierre_cargas = new CierreCargasATMs();
            this.actualizarDatos();
            dgvCargas.Refresh();
        }


        /// <summary>
        /// Clic en el botón de guardar
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;
            string observaciones = txtObservaciones.Text;

            CierreCargasATMs cierre = new CierreCargasATMs(libros_colones: _libros_colones, libros_dolares: _libros_dolares, saldo_anterior_colones: _saldo_anterior_colones, saldo_anterior_dolares: _saldo_anterior_dolares, pedido_boveda_colones: _pedido_boveda_colones,
                pedido_boveda_dolares: _pedido_boveda_dolares, descarga_atm_colones: _descarga_atm_colones, descarga_atm_dolares: _descarga_atm_dolares, pedido_boveda_adicional_colones: _pedido_boveda_adicional_colones, pedido_boveda_adicional_dolares: _pedido_boveda_adicional_dolares,
                descarga_completa_colones: _descarga_completa_colones, descarga_completa_dolares: _descarga_completa_dolares, devolucion_atm_colones: _devolucion_atms_colones, devolucion_atm_dolares: _devolucion_atms_dolares,
                devolucion_emergencia_colones: _devolucion_emergencias_colones, devolucion_emergencia_dolares: _devolucion_emergencias_dolares, entrega_boveda_colones: _entrega_boveda_colones, entrega_boveda_dolares: _entrega_boveda_dolares,
                cargas_emergencia_colones: _cargas_emergencia_colones, cargas_emergencia_dolares: _cargas_emergencia_dolares, cargas_atm_colones: _cargas_atm_colones, cargas_atm_dolares: _cargas_atm_dolares, saldo_cola20000: _saldo_20000,
                saldo_cola10000: _saldo_10000, saldo_cola5000: _saldo_5000, saldo_cola2000: _saldo_2000, saldo_cola1000: _saldo_1000, saldo_libros_colones: _libros_colones, saldo_libros_dolares: _libros_dolares, saldo_cartucho_colones: _saldo_cartucho_colones, saldo_cartucho_dolares: _saldo_cartucho_dolares,
                saldo_cola100: _saldo_100, saldo_cola50: _saldo_50, saldo_cola20: _saldo_20, saldo_cola10: _saldo_10, saldo_cola5: _saldo_5, saldo_cola1: _saldo_1, saldo_efectivo_colones: _saldo_efectivo_colones, saldo_efectivo_dolares: _saldo_efectivo_dolares,
                diferencia_colones: _diferencias_colones, diferencia_dolares: _diferencias_dolares, saldo_cola_colones: _saldo_cola_colones, saldo_cola_dolares: _saldo_cola_dolares, fecha_asignada: fecha, observaciones: observaciones,
                colaborador: _usuario
                );



            if (cierre.ID == 0)
            {
                _coordinacion.agregarCierreCargaATMs(ref cierre);
            }
            else
            {
                _coordinacion.actualizarCierreCargaATMs(cierre);
            }
        }


        /// <summary>
        /// Cambio en el valor de las celdas
        /// </summary>
        private void dgvCargas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCargas.RowCount > 0)
            {
                DataGridViewCell celda = dgvCargas[e.ColumnIndex, e.RowIndex];



                _cierre_cargas.LibrosColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 0].Value);
                _cierre_cargas.Saldo_AnteriorColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 1].Value);
                _cierre_cargas.PedidoBovedaColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 2].Value);
                _cierre_cargas.DescargaATMsColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 3].Value);
                _cierre_cargas.PedidoBovedaAdicionalColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 4].Value);
                _cierre_cargas.DescargaCompletaColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 5].Value);
                _cierre_cargas.DevolucionATMsColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 6].Value);
                _cierre_cargas.DevolucionEmergenciasColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 7].Value);
                _cierre_cargas.EntregaBovedaColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 8].Value);
                _cierre_cargas.CargasEmergenciaColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 9].Value);
                _cierre_cargas.CargasATMsColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 10].Value);
                //_saldo_colones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 11].Value);
                _cierre_cargas.SaldoColaColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 13].Value);
                _cierre_cargas.SaldoCartuchosColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 14].Value);
                _cierre_cargas.SaldoCola20000 = Convert.ToDecimal(dgvCargas[MontoColones.Index, 15].Value);
                _cierre_cargas.SaldoCola10000 = Convert.ToDecimal(dgvCargas[MontoColones.Index, 16].Value);
                _cierre_cargas.SaldoCola5000 = Convert.ToDecimal(dgvCargas[MontoColones.Index, 17].Value);
                _cierre_cargas.SaldoCola2000 = Convert.ToDecimal(dgvCargas[MontoColones.Index, 18].Value);
                _cierre_cargas.SaldoCola1000 = Convert.ToDecimal(dgvCargas[MontoColones.Index, 19].Value);
                //_cierre_cargas.SaldoEfectivoColones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 20].Value);
                //_diferencias_colones = Convert.ToDecimal(dgvCargas[MontoColones.Index, 21].Value);



                _cierre_cargas.LibrosDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 0].Value);
                _cierre_cargas.Saldo_AnteriorDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 1].Value);
                _cierre_cargas.PedidoBovedaDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 2].Value);
                _cierre_cargas.DescargaATMsDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 3].Value);
                _cierre_cargas.PedidoBovedaAdicionalDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 4].Value);
                _cierre_cargas.DescargaCompletaDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 5].Value);
                _cierre_cargas.DevolucionATMsDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 6].Value);
                _cierre_cargas.DevolucionEmergenciasDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 7].Value);
                _cierre_cargas.EntregaBovedaDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 8].Value);
                _cierre_cargas.CargasEmergenciaDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 9].Value);
                _cierre_cargas.CargasATMsDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 10].Value);
                //_saldo_Dolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 11].Value);
                _cierre_cargas.SaldoColaDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 13].Value);
                _cierre_cargas.SaldoCartuchosDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 14].Value);
                _cierre_cargas.SaldoCola20000 = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 15].Value);
                _cierre_cargas.SaldoCola10000 = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 16].Value);
                _cierre_cargas.SaldoCola5000 = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 17].Value);
                _cierre_cargas.SaldoCola2000 = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 18].Value);
                _cierre_cargas.SaldoCola1000 = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 19].Value);
                //_cierre_cargas.SaldoEfectivoDolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 20].Value);
                //_diferencias_Dolares = Convert.ToDecimal(dgvCargas[MontoDolares.Index, 21].Value);

                actualizarDatos();

            }



        }


        /// <summary>
        /// Imprime el formulario del cierre de ATMs
        /// </summary>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.imprimirHojaCarga();
        }

        /// <summary>
        /// Clic en el botón actualizar datos
        /// </summary>
        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
           _coordinacion.obtenerCierreCargaATMDatos(dtpFecha.Value, ref _cierre_cargas);

           dgvCargas.Refresh();


        }


      
        #endregion Eventos

        #region Metodos Privados


        /// <summary>
        /// Crear las filas de los DataGridView's.
        /// </summary>
        private void crearTabla(DataGridView tabla)
        {

            tabla.Rows.Add("Libros", 0, 0);
            tabla.Rows.Add("Saldo Anterior", 0, 0);
            tabla.Rows.Add("Pedido Bóveda", 0, 0);
            tabla.Rows.Add("Descarga de ATMs", 0, 0);
            tabla.Rows.Add("Pedido a Boveda Adicional", 0, 0);
            tabla.Rows.Add("Descarga Completa", 0, 0);
            tabla.Rows.Add("Devolución de ATMs", 0, 0);
            tabla.Rows.Add("Devolución de Emergencias", 0, 0);
            tabla.Rows.Add("Entrega a Bóveda", 0, 0);
            tabla.Rows.Add("Cargas de Emergencia", 0, 0);
            tabla.Rows.Add("Cargas de ATM", 0, 0);
            tabla.Rows.Add("Saldo Colones", 0, 0);
            tabla.Rows.Add(string.Empty, string.Empty, string.Empty);
            tabla.Rows.Add("Saldo ATMs-Cola", 0, 0);
            tabla.Rows.Add("Saldo en Cartuchos", 0, 0);
            tabla.Rows.Add("₡20.000 / $100", 0, 0);
            tabla.Rows.Add("₡10.000 / $50", 0, 0);
            tabla.Rows.Add("₡5.000 / $25", 0, 0);
            tabla.Rows.Add("₡2.000 / $10", 0, 0);
            tabla.Rows.Add("₡1.000 / $5", 0, 0);
            tabla.Rows.Add("$1", 0, 0);
            tabla.Rows.Add("Saldo Efectivo", 0, 0);
            tabla.Rows.Add("Diferencia", 0, 0);


            this.protegerCeldas(tabla);
        }




        /// <summary>
        /// Proteger las celdas para evitar su edición.
        /// </summary>
        private void protegerCeldas(DataGridView tabla)
        {

            //this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 0, 1, 2, 3, 4, 5, 6);


            this.formatoCeldaSeparador(tabla, 12);


            //this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 30);
            //this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 31);

            this.formatoCeldaFormato(tabla, MontoColones.Index, "N0", 0, 1, 2, 3, 4, 5, 6);



            this.formatoCeldaSoloLecturaColumna(tabla, 1, 0);
            this.formatoCeldaSoloLecturaColumna(tabla, 2, 0);
            this.formatoCeldaSoloLecturaColumna(tabla, 1, 20);
            this.formatoCeldaSoloLecturaColumna(tabla, 1, 11);
            this.formatoCeldaSoloLecturaColumna(tabla, 2, 11);
            this.formatoCeldaSoloLecturaColumna(tabla, 1, 21);
            this.formatoCeldaSoloLecturaColumna(tabla, 2, 21);
            this.formatoCeldaSoloLecturaColumna(tabla, 1, 22);
            this.formatoCeldaSoloLecturaColumna(tabla, 2, 22);
        }

        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLectura(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
              //  tabla.Rows[fila].DefaultCellStyle.BackColor = clmDescripcion.DefaultCellStyle.BackColor;
            }

        }



        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLecturaColumna(DataGridView tabla, int columna, int fila)
        {

           
                tabla[columna, fila].ReadOnly = true;
                tabla[columna, fila].Style.BackColor = Color.LightBlue;


                
                //  tabla.Rows[fila].DefaultCellStyle.BackColor = clmDescripcion.DefaultCellStyle.BackColor;
        }





        /// <summary>
        /// Dar formato  de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLecturaColumna(DataGridView tabla, int columna, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla[columna, fila].ReadOnly = true;
               // tabla[columna, fila].Style.BackColor = clmDescripcion.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato a las celdas que lo requieran.
        /// </summary>
        private void formatoCeldaFormato(DataGridView tabla, int columna, string formato, params int[] filas)
        {

            foreach (int fila in filas) tabla[columna, fila].Style.Format = "N0";

        }

        /// <summary>
        /// Dar formato a las celdas que son separadoras.
        /// </summary>
        private void formatoCeldaSeparador(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = tabla.GridColor;
            }

        }




        /// <summary>
        /// Metodo que valida que no se digiten numeros
        /// </summary>
        private void txtNumeroA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44) || e.KeyChar > 57)
            {
                MessageBox.Show("Sólo se permiten Números");
                e.Handled = true;
            }
        }



        /// <summary>
        /// Actualiza los datos de 
        /// </summary>
        private void actualizarDatos()
        {
 
            dgvCargas[MontoColones.Index, 1].Value = _cierre_cargas.Saldo_AnteriorColones;
            dgvCargas[MontoColones.Index, 2].Value = _cierre_cargas.PedidoBovedaColones;
            dgvCargas[MontoColones.Index, 3].Value = _cierre_cargas.DescargaATMsColones;
            dgvCargas[MontoColones.Index, 4].Value = _cierre_cargas.PedidoBovedaAdicionalColones;
            dgvCargas[MontoColones.Index, 5].Value = _cierre_cargas.DescargaCompletaColones;
            dgvCargas[MontoColones.Index, 6].Value = _cierre_cargas.DevolucionATMsColones;
            dgvCargas[MontoColones.Index, 7].Value = _cierre_cargas.DevolucionEmergenciasColones;
            dgvCargas[MontoColones.Index, 8].Value = _cierre_cargas.EntregaBovedaColones;
            dgvCargas[MontoColones.Index, 9].Value = _cierre_cargas.CargasEmergenciaColones;
            dgvCargas[MontoColones.Index, 10].Value = _cierre_cargas.CargasATMsColones;
            dgvCargas[MontoColones.Index, 11].Value = _cierre_cargas.SaldoLibroColones;
            dgvCargas[MontoColones.Index, 13].Value = _cierre_cargas.SaldoColaColones;
            dgvCargas[MontoColones.Index, 14].Value = _cierre_cargas.SaldoCartuchosColones;
            dgvCargas[MontoColones.Index, 15].Value = _cierre_cargas.SaldoCola20000;
            dgvCargas[MontoColones.Index, 16].Value = _cierre_cargas.SaldoCola10000;
            dgvCargas[MontoColones.Index, 17].Value = _cierre_cargas.SaldoCola5000;
            dgvCargas[MontoColones.Index, 18].Value = _cierre_cargas.SaldoCola2000;
            dgvCargas[MontoColones.Index, 19].Value = _cierre_cargas.SaldoCola1000;
            dgvCargas[MontoColones.Index, 20].Value = _cierre_cargas.SaldoEfectivoColones;
            dgvCargas[MontoColones.Index, 21].Value = _cierre_cargas.DiferenciaColones;





            dgvCargas[MontoDolares.Index, 1].Value = _cierre_cargas.Saldo_AnteriorDolares;
            dgvCargas[MontoDolares.Index, 2].Value = _cierre_cargas.PedidoBovedaDolares;
            dgvCargas[MontoDolares.Index, 3].Value = _cierre_cargas.DescargaATMsDolares;
            dgvCargas[MontoDolares.Index, 4].Value = _cierre_cargas.PedidoBovedaAdicionalDolares;
            dgvCargas[MontoDolares.Index, 5].Value = _cierre_cargas.DescargaCompletaDolares;
            dgvCargas[MontoDolares.Index, 6].Value = _cierre_cargas.DevolucionATMsDolares;
            dgvCargas[MontoDolares.Index, 7].Value = _cierre_cargas.DevolucionEmergenciasDolares;
            dgvCargas[MontoDolares.Index, 8].Value = _cierre_cargas.EntregaBovedaDolares;
            dgvCargas[MontoDolares.Index, 9].Value = _cierre_cargas.CargasEmergenciaDolares;
            dgvCargas[MontoDolares.Index, 10].Value = _cierre_cargas.CargasATMsDolares;
            dgvCargas[MontoDolares.Index, 11].Value = _cierre_cargas.SaldoLibroDolares;
            dgvCargas[MontoDolares.Index, 13].Value = _cierre_cargas.SaldoColaDolares;
            dgvCargas[MontoDolares.Index, 14].Value = _cierre_cargas.SaldoCartuchosDolares;
            dgvCargas[MontoDolares.Index, 15].Value = _cierre_cargas.SaldoCola20000;
            dgvCargas[MontoDolares.Index, 16].Value = _cierre_cargas.SaldoCola10000;
            dgvCargas[MontoDolares.Index, 17].Value = _cierre_cargas.SaldoCola5000;
            dgvCargas[MontoDolares.Index, 18].Value = _cierre_cargas.SaldoCola2000;
            dgvCargas[MontoDolares.Index, 19].Value = _cierre_cargas.SaldoCola1000;
            dgvCargas[MontoDolares.Index, 20].Value = _cierre_cargas.SaldoEfectivoDolares;
            dgvCargas[MontoDolares.Index, 21].Value = _cierre_cargas.DiferenciaDolares;



        }


        /// <summary>
        /// Imprimir los datos de la hoja de la carga seleccionada.
        /// </summary>
        private void imprimirHojaCarga()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla cierre carga atms.xltx", true);

                DateTime fecha = dtpFecha.Value;
                string observaciones = txtObservaciones.Text;

                CierreCargasATMs cierre = new CierreCargasATMs(libros_colones: _libros_colones, libros_dolares: _libros_dolares, saldo_anterior_colones: _saldo_anterior_colones, saldo_anterior_dolares: _saldo_anterior_dolares, pedido_boveda_colones: _pedido_boveda_colones,
                    pedido_boveda_dolares: _pedido_boveda_dolares, descarga_atm_colones: _descarga_atm_colones, descarga_atm_dolares: _descarga_atm_dolares, pedido_boveda_adicional_colones: _pedido_boveda_adicional_colones, pedido_boveda_adicional_dolares: _pedido_boveda_adicional_dolares,
                    descarga_completa_colones: _descarga_completa_colones, descarga_completa_dolares: _descarga_completa_dolares, devolucion_atm_colones: _devolucion_atms_colones, devolucion_atm_dolares: _devolucion_atms_dolares,
                    devolucion_emergencia_colones: _devolucion_emergencias_colones, devolucion_emergencia_dolares: _devolucion_emergencias_dolares, entrega_boveda_colones: _entrega_boveda_colones, entrega_boveda_dolares: _entrega_boveda_dolares,
                    cargas_emergencia_colones: _cargas_emergencia_colones, cargas_emergencia_dolares: _cargas_emergencia_dolares, cargas_atm_colones: _cargas_atm_colones, cargas_atm_dolares: _cargas_atm_dolares, saldo_cola20000: _saldo_20000,
                    saldo_cola10000: _saldo_10000, saldo_cola5000: _saldo_5000, saldo_cola2000: _saldo_2000, saldo_cola1000: _saldo_1000, saldo_libros_colones: _libros_colones, saldo_libros_dolares: _libros_dolares, saldo_cartucho_colones: _saldo_cartucho_colones, saldo_cartucho_dolares: _saldo_cartucho_dolares,
                    saldo_cola100: _saldo_100, saldo_cola50: _saldo_50, saldo_cola20: _saldo_20, saldo_cola10: _saldo_10, saldo_cola5: _saldo_5, saldo_cola1: _saldo_1, saldo_efectivo_colones: _saldo_efectivo_colones, saldo_efectivo_dolares: _saldo_efectivo_dolares,
                    diferencia_colones: _diferencias_colones, diferencia_dolares: _diferencias_dolares, saldo_cola_colones: _saldo_cola_colones, saldo_cola_dolares: _saldo_cola_dolares, fecha_asignada: fecha, observaciones: observaciones,
                    colaborador: _usuario
                    );



                documento.seleccionarHoja(1);



                documento.seleccionarCelda("C5");
                documento.actualizarValorCelda(_saldo_anterior_colones.ToString());

                documento.seleccionarCelda("G5");
                documento.actualizarValorCelda(_saldo_anterior_dolares.ToString());

                documento.seleccionarCelda("C6");
                documento.actualizarValorCelda(_pedido_boveda_colones.ToString());

                documento.seleccionarCelda("G6");
                documento.actualizarValorCelda(_pedido_boveda_dolares.ToString());

                documento.seleccionarCelda("C7");
                documento.actualizarValorCelda(_descarga_atm_colones.ToString());

                documento.seleccionarCelda("G7");
                documento.actualizarValorCelda(_descarga_atm_dolares.ToString());

                documento.seleccionarCelda("C8");
                documento.actualizarValorCelda(_pedido_boveda_adicional_colones.ToString());

                documento.seleccionarCelda("G8");
                documento.actualizarValorCelda(_pedido_boveda_adicional_dolares.ToString());

                documento.seleccionarCelda("C9");
                documento.actualizarValorCelda(_descarga_completa_colones.ToString());

                documento.seleccionarCelda("G9");
                documento.actualizarValorCelda(_descarga_completa_dolares.ToString());

                documento.seleccionarCelda("C10");
                documento.actualizarValorCelda(_devolucion_atms_colones.ToString());

                documento.seleccionarCelda("G10");
                documento.actualizarValorCelda(_devolucion_atms_dolares.ToString());

                documento.seleccionarCelda("C11");
                documento.actualizarValorCelda(_devolucion_emergencias_colones.ToString());

                documento.seleccionarCelda("G11");
                documento.actualizarValorCelda(_devolucion_emergencias_dolares.ToString());

                documento.seleccionarCelda("D12");
                documento.actualizarValorCelda(_entrega_boveda_colones.ToString());

                documento.seleccionarCelda("H12");
                documento.actualizarValorCelda(_entrega_boveda_dolares.ToString());

                documento.seleccionarCelda("D13");
                documento.actualizarValorCelda(_cargas_emergencia_colones.ToString());

                documento.seleccionarCelda("H13");
                documento.actualizarValorCelda(_cargas_emergencia_dolares.ToString());

                documento.seleccionarCelda("D14");
                documento.actualizarValorCelda(_cargas_atm_colones.ToString());

                documento.seleccionarCelda("H14");
                documento.actualizarValorCelda(_cargas_atm_dolares.ToString());

               

                documento.seleccionarCelda("D18");
                documento.actualizarValorCelda(_saldo_cartucho_colones.ToString());

                documento.seleccionarCelda("D19");
                documento.actualizarValorCelda(_saldo_20000.ToString());

                documento.seleccionarCelda("D20");
                documento.actualizarValorCelda(_saldo_10000.ToString());

                documento.seleccionarCelda("D21");
                documento.actualizarValorCelda(_saldo_5000.ToString());

                documento.seleccionarCelda("D22");
                documento.actualizarValorCelda(_saldo_2000.ToString());

                documento.seleccionarCelda("D23");
                documento.actualizarValorCelda(_saldo_1000.ToString());

                documento.seleccionarCelda("H18");
                documento.actualizarValorCelda(_saldo_cartucho_dolares.ToString());

                documento.seleccionarCelda("H19");
                documento.actualizarValorCelda(_saldo_100.ToString());

                documento.seleccionarCelda("H20");
                documento.actualizarValorCelda(_saldo_50.ToString());

                documento.seleccionarCelda("H21");
                documento.actualizarValorCelda(_saldo_20.ToString());

                documento.seleccionarCelda("H22");
                documento.actualizarValorCelda(_saldo_10.ToString());

                documento.seleccionarCelda("H23");
                documento.actualizarValorCelda(_saldo_5.ToString());

                documento.seleccionarCelda("H24");
                documento.actualizarValorCelda(_saldo_1.ToString());

                documento.seleccionarCelda("C30");
                documento.actualizarValorCelda(txtObservaciones.Text);

                documento.seleccionarCelda("C30");
                documento.actualizarValorCelda(txtObservaciones.Text);

                documento.seleccionarCelda("A29");
                documento.actualizarValorCelda(_usuario.ToString());

               

             
                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }


     

        #endregion Metodos Privados


       
    }
}
