using CommonObjects;
using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class CierreCargasATMsDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CierreCargasATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CierreCargasATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CierreCargasATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CierreCargasATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        #region Cierre Cargas
        /// <summary>
        /// Registrar un cierre de ATM's en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCargasATMs con los datos del cierre</param>
        public void agregarCierreCargasATMs(ref CierreCargasATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCierreCargaATM");

            _manejador.agregarParametro(comando, "@saldo_anterior_colones", c.Saldo_AnteriorColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_anterior_dolares", c.Saldo_AnteriorDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_colones", c.PedidoBovedaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_dolares", c.PedidoBovedaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_atms_colones", c.DescargaATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_atms_dolares", c.DescargaATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_adicional_colones", c.PedidoBovedaAdicionalColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_adicional_dolares", c.PedidoBovedaAdicionalDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_completa_colones", c.DescargaCompletaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_completa_dolares", c.DescargaCompletaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_atm_colones", c.DevolucionATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_atm_dolares", c.DevolucionATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_emergencia_colones", c.DevolucionEmergenciasColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_emergencia_dolares", c.DevolucionEmergenciasDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entrega_boveda_colones", c.EntregaBovedaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entrega_boveda_dolares", c.EntregaBovedaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_emergencia_colones", c.CargasEmergenciaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_emergencia_dolares", c.CargasEmergenciaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_atm_colones", c.CargasATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_atm_dolares", c.CargasATMsDolares, SqlDbType.Decimal);

            _manejador.agregarParametro(comando, "@saldo_libros_colones", c.SaldoLibroColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_libros_dolares", c.SaldoLibroDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cola_colones", c.SaldoColaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cola_dolares", c.SaldoColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cartucho_colones", c.SaldoCartuchosColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cartucho_dolares", c.SaldoCartuchosDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_20000", c.SaldoCola20000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_10000", c.SaldoCola10000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_5000", c.SaldoCola5000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_2000", c.SaldoCola2000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_1000", c.SaldoCola1000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_100", c.SaldoCola100, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_50", c.SaldoCola50, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_20", c.SaldoCola20, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_10", c.SaldoCola10, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_5", c.SaldoCola5, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_1", c.SaldoCola1, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_efectivo_colones", c.SaldoEfectivoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_efectivo_dolares", c.SaldoEfectivoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@diferencia_colones", c.DiferenciaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@diferencia_dolares", c.DiferenciaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@comentarios", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@colaborador", c.ColaboradoRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreCargasATMs con los datos del cierre</param>
        public void actualizarCierreCargasATMs(CierreCargasATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCierreCargasATMs");

            _manejador.agregarParametro(comando, "@saldo_anterior_colones", c.Saldo_AnteriorColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_anterior_dolares", c.Saldo_AnteriorDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_colones", c.PedidoBovedaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_dolares", c.PedidoBovedaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_atms_colones", c.DescargaATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_atms_dolares", c.DescargaATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_adicional_colones", c.PedidoBovedaAdicionalColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_adicional_dolares", c.PedidoBovedaAdicionalDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_completa_colones", c.DescargaCompletaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_completa_dolares", c.DescargaCompletaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_atm_colones", c.DevolucionATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_atm_dolares", c.DevolucionATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_emergencia_colones", c.DevolucionEmergenciasColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_emergencia_dolares", c.DevolucionEmergenciasDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entrega_boveda_colones", c.EntregaBovedaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entrega_boveda_dolares", c.EntregaBovedaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_emergencia_colones", c.CargasEmergenciaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_emergencia_dolares", c.CargasEmergenciaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_atm_colones", c.CargasATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_atm_dolares", c.CargasATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_libros_colones", c.SaldoLibroColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_libros_dolares", c.SaldoLibroDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cola_colones", c.SaldoColaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cola_dolares", c.SaldoColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cartucho_colones", c.SaldoCartuchosColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cartucho_dolares", c.SaldoCartuchosDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_20000", c.SaldoCola20000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_10000", c.SaldoCola10000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_5000", c.SaldoCola5000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_2000", c.SaldoCola2000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_1000", c.SaldoCola1000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_100", c.SaldoCola100, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_50", c.SaldoCola50, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_20", c.SaldoCola20, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_10", c.SaldoCola10, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_5", c.SaldoCola5, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_1", c.SaldoCola1, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_efectivo_colones", c.SaldoEfectivoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_efectivo_dolares", c.SaldoEfectivoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@diferencia_colones", c.DiferenciaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@diferencia_dolares", c.DiferenciaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@comentarios", c.Observaciones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@colaborador", c.ColaboradoRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@cierre", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreActualizacion");
            }

        }

      

      

        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreCargasATMs con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public CierreCargasATMs obtenerCierreCargasATMs(DateTime fecha)
        {

            CierreCargasATMs cierre = null;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCargasATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
   

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cierre= (int)datareader["pk_ID"];
                    decimal saldo_anterior_colones = (decimal)datareader["Saldo_Anterior_Colones"];
                    decimal saldo_anterior_dolares = (decimal)datareader["Saldo_Anterior_Dolares"];
                    decimal pedido_boveda_colones = (decimal)datareader["Pedido_Boveda_Colones"];
                    decimal pedido_boveda_dolares = (decimal)datareader["Pedido_Boveda_Dolares"];
                    decimal descarga_atms_colones = (decimal)datareader["Descarga_ATMs_Colones"];
                    decimal descarga_atms_dolares = (decimal)datareader["Descarga_ATMs_Dolares"];
                    decimal pedido_boveda_adicional_colones = (decimal)datareader["Pedido_Boveda_Adicional_Colones"];
                    decimal pedido_boveda_adicional_dolares = (decimal)datareader["Pedido_Boveda_Adicional_Dolares"];
                    decimal descarga_completa_colones = (decimal)datareader["Descarga_Completa_Colones"];
                    decimal descarga_completa_dolares = (decimal)datareader["Descarga_Completa_Dolares"];
                    decimal devolucion_atms_colones = (decimal)datareader["Devolucion_ATMs_Colones"];
                    decimal devolucion_atms_dolares = (decimal)datareader["Devolucion_ATMs_Dolares"];
                    decimal devolucion_emergencia_colones = (decimal)datareader["Devolucion_Emergencia_Colones"];
                    decimal devolucion_emergencia_dolares = (decimal)datareader["Devolucion_Emergencia_Dolares"];
                    decimal entrega_boveda_colones = (decimal)datareader["Entrega_Boveda_Colones"];
                    decimal entrega_boveda_dolares = (decimal)datareader["Entrega_Boveda_Dolares"];
                    decimal cargas_emergencia_colones = (decimal)datareader["Cargas_Emergencia_Colones"];
                    decimal cargas_emergencia_dolares = (decimal)datareader["Cargas_Emergencia_Dolares"];
                    decimal cargas_atm_colones = (decimal)datareader["Cargas_ATM_Colones"];
                    decimal cargas_atm_dolares = (decimal)datareader["Cargas_ATM_Dolares"];
                    decimal saldo_cola_colones = (decimal)datareader["Saldo_Cola_Colones"];
                    decimal saldo_cola_dolares = (decimal)datareader["Saldo_Cola_Dolares"];
                    decimal saldo_cartucho_colones = (decimal)datareader["Saldo_Cartucho_Colones"];
                    decimal saldo_cartucho_dolares = (decimal)datareader["Saldo_Cartucho_Dolares"];
                    decimal saldo_20000 = (decimal)datareader["Saldo_20000"];
                    decimal saldo_10000 = (decimal)datareader["Saldo_10000"];
                    decimal saldo_5000 = (decimal)datareader["Saldo_5000"];
                    decimal saldo_2000 = (decimal)datareader["Saldo_2000"];
                    decimal saldo_1000 = (decimal)datareader["Saldo_1000"];
                    decimal saldo_100 = (decimal)datareader["Saldo_100"];
                    decimal saldo_50 = (decimal)datareader["Saldo_50"];
                    decimal saldo_20 = (decimal)datareader["Saldo_20"];
                    decimal saldo_10 = (decimal)datareader["Saldo_10"];
                    decimal saldo_5 = (decimal)datareader["Saldo_5"];
                    decimal saldo_1 = (decimal)datareader["Saldo_1"];

                    string comentarios =  (string)datareader["Comentarios"];

                    Colaborador usuario = null;

                    int id_colaborador = (int)datareader["fk_ID_Colaborador"];
                    string nombre_colaborador = (string)datareader["Nombre_Colaborador"];
                    string  primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    usuario = new Colaborador(id:id_colaborador,nombre:nombre_colaborador, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);


                    cierre = new CierreCargasATMs(id: id_cierre, saldo_anterior_colones: saldo_anterior_colones, saldo_anterior_dolares: saldo_anterior_dolares, pedido_boveda_colones: pedido_boveda_colones, pedido_boveda_dolares: pedido_boveda_dolares,
                        descarga_atm_colones: descarga_atms_colones, descarga_atm_dolares: descarga_atms_dolares, pedido_boveda_adicional_colones: pedido_boveda_adicional_colones, pedido_boveda_adicional_dolares: pedido_boveda_adicional_dolares,
                        descarga_completa_colones: descarga_completa_colones, descarga_completa_dolares: descarga_completa_dolares, devolucion_atm_colones: devolucion_atms_colones, devolucion_atm_dolares: devolucion_atms_dolares,
                        devolucion_emergencia_colones: devolucion_emergencia_colones, devolucion_emergencia_dolares: devolucion_emergencia_dolares, entrega_boveda_colones: entrega_boveda_colones, entrega_boveda_dolares: entrega_boveda_dolares,
                        cargas_emergencia_colones: cargas_emergencia_colones, cargas_emergencia_dolares: cargas_emergencia_dolares, cargas_atm_colones: cargas_atm_colones, cargas_atm_dolares: cargas_atm_dolares,
                        saldo_cola20000: saldo_20000, saldo_cola10000: saldo_10000, saldo_cola5000: saldo_5000, saldo_cola2000: saldo_2000, saldo_cola1000: saldo_1000, saldo_cartucho_colones: saldo_cartucho_colones, saldo_cartucho_dolares: saldo_cartucho_dolares,
                        saldo_cola100: saldo_100, saldo_cola50: saldo_50, saldo_cola20: saldo_20, saldo_cola10: saldo_10, saldo_cola5: saldo_5, saldo_cola1: saldo_1, saldo_cola_colones: saldo_cola_colones, saldo_cola_dolares: saldo_cola_dolares,
                        colaborador: usuario, observaciones: comentarios);
                
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cierre;
        }








        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreCargasATMs con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public void obtenerCierreCargasATMsDatos(DateTime fecha, ref CierreCargasATMs cierre)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosCierreCargasATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {


                    decimal saldo_anterior_colones = 0;
                    decimal saldo_anterior_dolares = 0;
                    decimal descarga_colones = 0;
                    decimal descarga_dolares = 0;
                    decimal carga_colones = 0;
                    decimal carga_dolares = 0;
                    decimal carga_emergencia_colones = 0;
                    decimal carga_emergencia_dolares = 0;
                    decimal saldo_libros_colones = 0;
                    decimal saldo_libros_dolares = 0;

                    string titulo = (string)datareader["Titulo"];

                    switch (titulo){

                        case "Saldo Anterior Colones":
                            saldo_anterior_colones = (decimal)datareader["Monto"];

                        break;
                        case "Saldo Anterior Dolares":
                        saldo_anterior_dolares = (decimal)datareader["Monto"];

                        break;
                        case "Descargas Colones":
                        descarga_colones = (decimal)datareader["Monto"];

                        break;
                        case "Descargas Dolares":
                        descarga_dolares = (decimal)datareader["Monto"];

                        break;
                        case "Cargas Colones":
                        carga_colones = (decimal)datareader["Monto"];

                        break;
                        case "Cargas Dolares":
                        carga_dolares = (decimal)datareader["Monto"];
                        break;
                        case "Emergencias Colones":
                        carga_emergencia_colones = (decimal)datareader["Monto"];
                        break;
                        case "Emergencias Dolares":
                        carga_emergencia_dolares = (decimal)datareader["Monto"];
                        break;
                        case "Saldo Libros Colones":
                        saldo_libros_colones = (decimal)datareader["Monto"];
                        break;
                        case "Saldo Libros Dolares":
                        saldo_libros_dolares = (decimal)datareader["Monto"];
                        break;

                    }
                        
                            


                    cierre.Saldo_AnteriorColones = saldo_anterior_colones;
                    cierre.Saldo_AnteriorDolares = saldo_anterior_dolares;
                    cierre.DescargaATMsColones = descarga_colones;
                    cierre.DescargaATMsDolares = descarga_dolares;
                    cierre.CargasATMsColones = carga_colones;
                    cierre.CargasATMsDolares = carga_dolares;
                    cierre.CargasEmergenciaColones = carga_emergencia_colones;
                    cierre.CargasEmergenciaDolares = carga_emergencia_dolares;
                    //cierre.SaldoLibroColones = saldo_libros_colones;
                    //cierre.SaldoLibroDolares = saldo_libros_dolares;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }


        }



        #endregion Cierre Cargas


        #region Cierre Descargas
        /// <summary>
        /// Registrar un cierre de ATM's en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCargasATMs con los datos del cierre</param>
        public void agregarCierreDescargasATMs(ref CierreCargasATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCierreDescargaATM");

            _manejador.agregarParametro(comando, "@saldo_anterior_colones", c.Saldo_AnteriorColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_anterior_dolares", c.Saldo_AnteriorDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_colones", c.PedidoBovedaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_dolares", c.PedidoBovedaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_atms_colones", c.DescargaATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_atms_dolares", c.DescargaATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_adicional_colones", c.PedidoBovedaAdicionalColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_adicional_dolares", c.PedidoBovedaAdicionalDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_completa_colones", c.DescargaCompletaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_completa_dolares", c.DescargaCompletaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_atm_colones", c.DevolucionATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_atm_dolares", c.DevolucionATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_emergencia_colones", c.DevolucionEmergenciasColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_emergencia_dolares", c.DevolucionEmergenciasDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entrega_boveda_colones", c.EntregaBovedaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entrega_boveda_dolares", c.EntregaBovedaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_emergencia_colones", c.CargasEmergenciaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_emergencia_dolares", c.CargasEmergenciaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_atm_colones", c.CargasATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_atm_dolares", c.CargasATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_libros_colones", c.SaldoLibroColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_libros_dolares", c.SaldoLibroDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cola_colones", c.SaldoColaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cola_dolares", c.SaldoColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cartucho_colones", c.SaldoCartuchosColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cartucho_dolares", c.SaldoCartuchosDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_20000", c.SaldoCola20000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_10000", c.SaldoCola10000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_5000", c.SaldoCola5000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_2000", c.SaldoCola2000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_1000", c.SaldoCola1000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_100", c.SaldoCola100, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_50", c.SaldoCola50, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_20", c.SaldoCola20, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_10", c.SaldoCola10, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_5", c.SaldoCola5, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_1", c.SaldoCola1, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_efectivo_colones", c.SaldoEfectivoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_efectivo_dolares", c.SaldoEfectivoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@diferencia_colones", c.DiferenciaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@diferencia_dolares", c.DiferenciaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@comentarios", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@colaborador", c.ColaboradoRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreCargasATMs con los datos del cierre</param>
        public void actualizarCierreDescargasATMs(CierreCargasATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCierreCargasATMs");

            _manejador.agregarParametro(comando, "@saldo_anterior_colones", c.Saldo_AnteriorColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_anterior_dolares", c.Saldo_AnteriorDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_colones", c.PedidoBovedaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_dolares", c.PedidoBovedaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_atms_colones", c.DescargaATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_atms_dolares", c.DescargaATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_adicional_colones", c.PedidoBovedaAdicionalColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@pedido_boveda_adicional_dolares", c.PedidoBovedaAdicionalDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_completa_colones", c.DescargaCompletaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descarga_completa_dolares", c.DescargaCompletaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_atm_colones", c.DevolucionATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_atm_dolares", c.DevolucionATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_emergencia_colones", c.DevolucionEmergenciasColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@devolucion_emergencia_dolares", c.DevolucionEmergenciasDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entrega_boveda_colones", c.EntregaBovedaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entrega_boveda_dolares", c.EntregaBovedaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_emergencia_colones", c.CargasEmergenciaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_emergencia_dolares", c.CargasEmergenciaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_atm_colones", c.CargasATMsColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga_atm_dolares", c.CargasATMsDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_libros_colones", c.SaldoLibroColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_libros_dolares", c.SaldoLibroDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cola_colones", c.SaldoColaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cola_dolares", c.SaldoColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cartucho_colones", c.SaldoCartuchosColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_cartucho_dolares", c.SaldoCartuchosDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_20000", c.SaldoCola20000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_10000", c.SaldoCola10000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_5000", c.SaldoCola5000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_2000", c.SaldoCola2000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_1000", c.SaldoCola1000, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_100", c.SaldoCola100, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_50", c.SaldoCola50, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_20", c.SaldoCola20, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_10", c.SaldoCola10, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_5", c.SaldoCola5, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_1", c.SaldoCola1, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_efectivo_colones", c.SaldoEfectivoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo_efectivo_dolares", c.SaldoEfectivoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@diferencia_colones", c.DiferenciaColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@diferencia_dolares", c.DiferenciaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@comentarios", c.Observaciones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@colaborador", c.ColaboradoRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@cierre", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreActualizacion");
            }

        }





        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreCargasATMs con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public CierreCargasATMs obtenerCierreDescargasATMs(DateTime fecha)
        {

            CierreCargasATMs cierre = null;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCargasATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cierre = (int)datareader["pk_ID"];
                    decimal saldo_anterior_colones = (decimal)datareader["Saldo_Anterior_Colones"];
                    decimal saldo_anterior_dolares = (decimal)datareader["Saldo_Anterior_Dolares"];
                    decimal pedido_boveda_colones = (decimal)datareader["Pedido_Boveda_Colones"];
                    decimal pedido_boveda_dolares = (decimal)datareader["Pedido_Boveda_Dolares"];
                    decimal descarga_atms_colones = (decimal)datareader["Descarga_ATMs_Colones"];
                    decimal descarga_atms_dolares = (decimal)datareader["Descarga_ATMs_Dolares"];
                    decimal pedido_boveda_adicional_colones = (decimal)datareader["Pedido_Boveda_Adicional_Colones"];
                    decimal pedido_boveda_adicional_dolares = (decimal)datareader["Pedido_Boveda_Adicional_Dolares"];
                    decimal descarga_completa_colones = (decimal)datareader["Descarga_Completa_Colones"];
                    decimal descarga_completa_dolares = (decimal)datareader["Descarga_Completa_Dolares"];
                    decimal devolucion_atms_colones = (decimal)datareader["Devolucion_ATMs_Colones"];
                    decimal devolucion_atms_dolares = (decimal)datareader["Devolucion_ATMs_Dolares"];
                    decimal devolucion_emergencia_colones = (decimal)datareader["Devolucion_Emergencia_Colones"];
                    decimal devolucion_emergencia_dolares = (decimal)datareader["Devolucion_Emergencia_Dolares"];
                    decimal entrega_boveda_colones = (decimal)datareader["Entrega_Boveda_Colones"];
                    decimal entrega_boveda_dolares = (decimal)datareader["Entrega_Boveda_Dolares"];
                    decimal cargas_emergencia_colones = (decimal)datareader["Cargas_Emergencia_Colones"];
                    decimal cargas_emergencia_dolares = (decimal)datareader["Cargas_Emergencia_Dolares"];
                    decimal cargas_atm_colones = (decimal)datareader["Cargas_ATM_Colones"];
                    decimal cargas_atm_dolares = (decimal)datareader["Cargas_ATM_Dolares"];
                    decimal saldo_cola_colones = (decimal)datareader["Saldo_Cola_Colones"];
                    decimal saldo_cola_dolares = (decimal)datareader["Saldo_Cola_Dolares"];
                    decimal saldo_cartucho_colones = (decimal)datareader["Saldo_Cartucho_Colones"];
                    decimal saldo_cartucho_dolares = (decimal)datareader["Saldo_Cartucho_Dolares"];
                    decimal saldo_20000 = (decimal)datareader["Saldo_20000"];
                    decimal saldo_10000 = (decimal)datareader["Saldo_10000"];
                    decimal saldo_5000 = (decimal)datareader["Saldo_5000"];
                    decimal saldo_2000 = (decimal)datareader["Saldo_2000"];
                    decimal saldo_1000 = (decimal)datareader["Saldo_1000"];
                    decimal saldo_100 = (decimal)datareader["Saldo_100"];
                    decimal saldo_50 = (decimal)datareader["Saldo_50"];
                    decimal saldo_20 = (decimal)datareader["Saldo_20"];
                    decimal saldo_10 = (decimal)datareader["Saldo_10"];
                    decimal saldo_5 = (decimal)datareader["Saldo_5"];
                    decimal saldo_1 = (decimal)datareader["Saldo_1"];

                    string comentarios = (string)datareader["Comentarios"];

                    Colaborador usuario = null;

                    int id_colaborador = (int)datareader["fk_ID_Colaborador"];
                    string nombre_colaborador = (string)datareader["Nombre_Colaborador"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    usuario = new Colaborador(id: id_colaborador, nombre: nombre_colaborador, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);


                    cierre = new CierreCargasATMs(id: id_cierre, saldo_anterior_colones: saldo_anterior_colones, saldo_anterior_dolares: saldo_anterior_dolares, pedido_boveda_colones: pedido_boveda_colones, pedido_boveda_dolares: pedido_boveda_dolares,
                        descarga_atm_colones: descarga_atms_colones, descarga_atm_dolares: descarga_atms_dolares, pedido_boveda_adicional_colones: pedido_boveda_adicional_colones, pedido_boveda_adicional_dolares: pedido_boveda_adicional_dolares,
                        descarga_completa_colones: descarga_completa_colones, descarga_completa_dolares: descarga_completa_dolares, devolucion_atm_colones: devolucion_atms_colones, devolucion_atm_dolares: devolucion_atms_dolares,
                        devolucion_emergencia_colones: devolucion_emergencia_colones, devolucion_emergencia_dolares: devolucion_emergencia_dolares, entrega_boveda_colones: entrega_boveda_colones, entrega_boveda_dolares: entrega_boveda_dolares,
                        cargas_emergencia_colones: cargas_emergencia_colones, cargas_emergencia_dolares: cargas_emergencia_dolares, cargas_atm_colones: cargas_atm_colones, cargas_atm_dolares: cargas_atm_dolares,
                        saldo_cola20000: saldo_20000, saldo_cola10000: saldo_10000, saldo_cola5000: saldo_5000, saldo_cola2000: saldo_2000, saldo_cola1000: saldo_1000, saldo_cartucho_colones: saldo_cartucho_colones, saldo_cartucho_dolares: saldo_cartucho_dolares,
                        saldo_cola100: saldo_100, saldo_cola50: saldo_50, saldo_cola20: saldo_20, saldo_cola10: saldo_10, saldo_cola5: saldo_5, saldo_cola1: saldo_1, saldo_cola_colones: saldo_cola_colones, saldo_cola_dolares: saldo_cola_dolares,
                        colaborador: usuario, observaciones: comentarios);

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cierre;
        }








        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreCargasATMs con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public void obtenerCierreDescargasATMsDatos(DateTime fecha, ref CierreCargasATMs cierre)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosCierreDescargasATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {


                    decimal pedido_boveda_colones = 0;
                    decimal pedido_boveda_dolares = 0;
                    decimal pedido_adicional_colones = 0;
                    decimal pedido_adicional_dolares = 0;
                    decimal devoluciones_colones = 0;
                    decimal devoluciones_dolares = 0;
                    decimal devoluciones_emergencia_colones = 0;
                    decimal devoluciones_emergencia_dolares = 0;
                    decimal saldo_libros_colones = 0;
                    decimal saldo_libros_dolares = 0;


                    string titulo = (string)datareader["Titulo"];

                    switch (titulo)
                    {

                        case "Saldo Libros Colones":
                            saldo_libros_colones = (decimal)datareader["Monto"];

                            break;
                        case "Saldo Libros Dolares":
                            saldo_libros_dolares = (decimal)datareader["Monto"];

                            break;
                        case "Pedido Boveda Colones":
                            pedido_boveda_colones = (decimal)datareader["Monto"];

                            break;
                        case "Pedido Boveda Dolares":
                            pedido_boveda_dolares = (decimal)datareader["Monto"];

                            break;
                        case "Pedido Adicional Colones":
                            pedido_adicional_colones = (decimal)datareader["Monto"];

                            break;
                        case "Pedido Adicional Dolares":
                            pedido_adicional_dolares = (decimal)datareader["Monto"];
                            break;
                        case "Devoluciones Colones":
                            devoluciones_colones = (decimal)datareader["Monto"];
                            break;
                        case "Devoluciones Dolares":
                            devoluciones_dolares = (decimal)datareader["Monto"];
                            break;
                        case "Devoluciones Emergencia Colones":
                            devoluciones_emergencia_colones = (decimal)datareader["Monto"];
                            break;
                        case "Devoluciones Emergencia Dolares":
                            devoluciones_emergencia_dolares = (decimal)datareader["Monto"];
                            break;

                    }




                    //cierre.SaldoLibroColones = saldo_libros_colones;
                    //cierre.SaldoLibroDolares = saldo_libros_dolares;
                    cierre.PedidoBovedaColones = pedido_boveda_colones;
                    cierre.PedidoBovedaDolares = pedido_boveda_dolares;
                    cierre.PedidoBovedaAdicionalColones = pedido_adicional_colones;
                    cierre.PedidoBovedaAdicionalDolares = pedido_adicional_dolares;
                    cierre.DevolucionATMsColones = devoluciones_colones;
                    cierre.DevolucionATMsDolares = devoluciones_dolares;
                    cierre.DevolucionEmergenciasColones = devoluciones_emergencia_colones;
                    cierre.DevolucionEmergenciasDolares = devoluciones_emergencia_dolares;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }


        }



        #endregion Cierre Descargas



       

       

        #endregion Métodos Públicos

    }
}
