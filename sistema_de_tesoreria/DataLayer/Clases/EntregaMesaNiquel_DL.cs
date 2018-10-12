using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using System.Data;
using CommonObjects;
using LibreriaMensajes;
using CommonObjects.Clases;
using System.ComponentModel;
using CommonObjects.Clases.Reportes;

namespace DataLayer.Clases
{
    public class EntregaMesaNiquel_DL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static EntregaMesaNiquel_DL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static EntregaMesaNiquel_DL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EntregaMesaNiquel_DL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;
        SucursalesDL _sucursales = SucursalesDL.Instancia;

        #endregion Atributos

        #region Constructor

        public EntregaMesaNiquel_DL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void updateProcesamientoBajoVolumen(decimal AltaDenom, decimal BajaDenom, decimal Euro, decimal Dolar, int id_PBV)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcesamientoBajoVolumenConsulta");
            _manejador.agregarParametro(comando, "@idDeposito", id_PBV, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@altaDenom", AltaDenom, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@bajaDenom", BajaDenom, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@euro", Euro, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolar", Dolar, SqlDbType.Money);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarDepositoProcesoBajoVolumen");
            }
        }
        public DataTable obtieneExcelRecapBPS(int id, int moneda, DateTime fecha)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRecapsBPS");
            _manejador.agregarParametro(comando, "@id_contador", id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@moneda", moneda, SqlDbType.Int);
            try
            {
                var da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                comando.Connection.Close();
                return null;
            }

            return dt;
        }


        public void actualizarManifiesto(int idUsuario, int iDManifiesto, int idCliente, int idPV, decimal colones, decimal dolares, decimal euros)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManfiestoValues");
            _manejador.agregarParametro(comando, "@idPBVM", iDManifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idcliente", idCliente, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@idpuntoventa", idPV, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@monto_declarado_colones", colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_declarado_dolares", dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_declarado_euros", euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@idColaborador", idUsuario, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
        }
        public BoletaCajeroNiquel ObtenerBoletaEntregaMesaNiquel(ref Colaborador c, DateTime i, DateTime f)
        {
            BoletaCajeroNiquel boleta = new BoletaCajeroNiquel();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInfoFormularioBoletaNiquelEntregaMesaNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", f, SqlDbType.DateTime);            

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string cajero = (string)datareader["Cajero"];
                    string tula = (string)datareader["Tula"];
                    string manifiesto = (string)datareader["Manifiesto"];                    
                    string Numero_deposito = (string)datareader["Numero_deposito"];                    
                    decimal Monto_Niquel = (decimal)datareader["Monto_Niquel"];
                    decimal Monto_Deposito = (decimal)datareader["Monto_Deposito"];
                    DateTime Fecha_Generacion = (DateTime)datareader["Fecha_Generacion"];                    

                    //c.ColaboradorRecibidoBoveda = new Colaborador(id, nombre: nombre, primer_apellido: primer_apellido,
                     //                                            segundo_apellido: segundo_apellido, identificacion: identificacion);                    
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                return null;
                throw new Excepcion("ErrorDatosConexion");
            }
            return null;
        }

        public void agregarBoletaEntregaMesaNiquel(ref BoletaMesaEntregaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInfoFormularioBoletaNiquelEntregaMesaNiquel");

            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", c.Procesobajovolumendeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Manifiesto", c.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Tula", c.Tula, SqlDbType.Int);            
            _manejador.agregarParametro(comando, "@deposito", c.Numero_Deposito, SqlDbType.VarChar);            
            _manejador.agregarParametro(comando, "@Monto_Niquel", c.MontoNiquel, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Monto_Deposito", c.MontoDeposito, SqlDbType.Money);            

            try
            {
                c.ID = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }

        }


        //Procesamiento externo
        public Boolean insertMontosProcExternos(int colabID, short clienteID, byte empresaTID, decimal montoBilleteCRC, decimal montoBilleteUSD, decimal montoNiquel, decimal quinientos, decimal cien, decimal cincuenta, decimal veinticinco, decimal diez, decimal cinco, string montoPagUSD, string montoPagCRC)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertMontoProcesoExterno");
            _manejador.agregarParametro(comando, "@fk_Colaborador", colabID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_Cliente", clienteID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fk_Transportadora", empresaTID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@montoBilleteCol", montoBilleteCRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@montoBilleteUSD", montoBilleteUSD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@montoNiquel ", montoNiquel, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@quinientosCol ", quinientos, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cienCol ", cien, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cincuentaCol ", cincuenta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@veinticincoCol ", veinticinco, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@diezCol ", diez, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cincoCol ", cinco, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@montoPagarUSD ", montoPagUSD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@montoPagarCol", montoPagCRC, SqlDbType.Money);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                return true;
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                return false;
                throw new Exception(ex.Message);

            }
        }

        #region manifiestos pendientes
        //manifiestos pendientes
        public DataTable manifiestosPendientes(DateTime fechaInicio, DateTime fechafin)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosPendientes");
            _manejador.agregarParametro(comando, "@fechaInicio", fechaInicio, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fechaFin", fechafin, SqlDbType.Date);
            comando.CommandTimeout = 8000;
            try
            {
                var da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            catch
            {
                comando.Connection.Close();
                return dt;
                throw new Excepcion("Procedure Error: SelectManifiestosPendientes ");
            }

            return dt;
        }

        public void insertaMontoManifiestoPendiente(int manifiesto, Colaborador c, decimal colones, decimal dolares, decimal euros)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertMontoManifiestoPendiente");
            _manejador.agregarParametro(comando, "@pk_Manifiesto", manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colones", colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares", dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@euros", euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@coordinador", c.ID, SqlDbType.Money);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Procedure error: InsertMontoManifiestoPendiente");
            }
        }
        #endregion
       
        #region consulta formularios centro efectivo
        public DataTable obtieneCntrlDiarioCierreCajero(int cajero, DateTime desde, DateTime hasta)
        {
            return obtieneReporteGenerico(cajero, desde, hasta, "SelectFormCntrDiarioCierreCajero");
        }
        public DataTable obtieneDetalleInconsistenciasTesoreria(int cajero, DateTime desde, DateTime hasta)
        {
            return obtieneReporteGenerico(cajero, desde, hasta, "SelectFormDetalleInconsistenciasTesoreria");
        }
        public DataTable obtieneCntrlDiarioCierreCajeroNikel(int cajero, DateTime desde, DateTime hasta)
        {
            return obtieneReporteGenerico(cajero, desde, hasta, "SelectFormCntrlDiarioCierreCajeroNikel");
        }
        public DataTable obtieneBoletaNikelEntregaCajero(int cajero, DateTime desde, DateTime hasta)
        {
            return obtieneReporteGenerico(cajero, desde, hasta, "SelectFormBoletaNikelEntregaCajero");
        }
        public DataTable obtieneBoletaNikelEntregaCola(int cajero, DateTime desde, DateTime hasta)
        {
            return obtieneReporteGenerico(cajero, desde, hasta, "SelectFormBoletaNikelEntregaCola");
        }
        public DataTable obtieneInconsistenciasManifiesto(int cajero, DateTime desde, DateTime hasta)
        {
            return obtieneReporteGenerico(cajero, desde, hasta, "SelectFormInconsistenciasManifiesto");
        }
       
        private DataTable obtieneReporteGenerico(int cajero, DateTime desde, DateTime hasta, string procedureName)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento(procedureName);
            _manejador.agregarParametro(comando, "@cajero", cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@desde", desde, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hasta", hasta, SqlDbType.DateTime);
            try
            {
                var da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            catch
            {
                comando.Connection.Close();
                return dt;
                throw new Excepcion("Procedure Error: " + procedureName);
            }
            return dt;
        }

        private DataTable obtieneReporteIdGenerico(int id, string procedure)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento(procedure);
            _manejador.agregarParametro(comando, "@id", id, SqlDbType.Int);
            try
            {
                var da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            catch
            {
                comando.Connection.Close();
                return null;
            }

            return dt;
        }
        public DataTable obtieneBoletaNikelEntregaCajeroExcel(int id)
        {
            return obtieneReporteIdGenerico(id, "SelectBoletaNikelEntregaCajero");
        }
        public DataTable obtenerExcelCntrDiarioCierreCajeroNikel(int id)
        {
            return obtieneReporteIdGenerico(id, "SelectCntrDiarioCierreCajeroNikel");
        }
        public DataTable obtieneExcelBoletaNikelEntregaCola(int id)
        {
            return obtieneReporteIdGenerico(id, "SelectBoletaNikelEntregaCola");
        }
        public DataTable obtieneExcelDetalleInconsistenciasTesoreria(int id)
        {
            return obtieneReporteIdGenerico(id, "SelectDetalleInconsistenciasTesoreria");
        }
        public DataTable obtieneExcelCntrlDiarioCierreCajero(int id)
        {
            return obtieneReporteIdGenerico(id, "SelectCntrlDiarioCierreCajero");
        }
        public DataTable obtieneExcelInconsistenciasManififesto(int id)
        {
            return obtieneReporteIdGenerico(id, "SelectInconsistenciasManififesto");
        }
        #endregion

        #region consulta manifiesto
        //consulta manifiesto
        public int selectManifiestoId(string codigo)
        {
            int id = 0;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestoId");
            _manejador.agregarParametro(comando, "@codigo", codigo, SqlDbType.NVarChar);
            IDataReader datareader = null;
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                while (datareader.Read())
                {
                    id = (int)datareader["pk_ID"];
                    comando.Connection.Close();
                    return id;
                }
            }
            catch
            {
                comando.Connection.Close();
                return 0;
            }
            return id;
        }

        public ProcesamientoBajoVolumenManifiesto obtnProcesamientoBajoVolumenManifiesto(int idManifiesto)
        {
            ProcesamientoBajoVolumenManifiesto man = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("selectProcesamientoBajoVolumenManifiestoID");
            _manejador.agregarParametro(comando, "@id", idManifiesto, SqlDbType.Int);
            SqlDataReader datareader = null;

            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                if (datareader != null)
                {
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            int idproceso = (int)datareader["pk_ID"];
                            int idman = idManifiesto;
                            byte idcamara = (byte)datareader["fk_ID_Camara"];
                            Camara cam = new Camara("");
                            cam.ID = idcamara;
                            short idpuntoventa = (short)datareader["fk_ID_PuntoVenta"];
                            PuntoVenta pv = new PuntoVenta();
                            pv.Id = idpuntoventa;
                            short idcliente = (short)datareader["fk_ID_Cliente"];
                            Colaborador col = new Colaborador();
                            col.ID = (int)datareader["fk_ID_Cajero"];
                            col.Nombre = (string)datareader["Colaborador"];
                            Cliente cli = new Cliente();
                            cli.Id = idcliente;
                            cli.Nombre = (string)datareader["Cliente"];
                            Decimal montocolones = Convert.ToDecimal(datareader["MontoColones"]);
                            Decimal montodolares = Convert.ToDecimal(datareader["MontoDolares"]);
                            Decimal montoeuros = Convert.ToDecimal(datareader["MontoEuros"]);
                            man = new ProcesamientoBajoVolumenManifiesto();
                            man.Monto_Colones = montocolones;
                            man.Monto_Dolares = montodolares;
                            man.Monto_Euros = montoeuros;
                            man.Cliente = cli;
                            man.PuntoVenta = pv;
                            man.Cajero = col;
                            man.Camara = cam;
                            man.ID = idproceso;
                            man.IDManifiesto = idman;
                            //  man.Fecha_Procesamiento = Convert.ToDateTime(datareader["FECHA_Procesamiento"]);
                        }
                    }
                }
                comando.Connection.Close();
                return man;
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarDepositoProcesoBajoVolumen " + ex.Message);
            }
        }

        public DataTable obtieneRecapBPS(int cajero, DateTime desde, DateTime hasta)
        {
            return obtieneReporteGenerico(cajero, desde, hasta, "SelectFormRecapBPS");
        }

        public void eliminarTula(int tulaId, int idColaborador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTulaDeposito");
            _manejador.agregarParametro(comando, "@tula", tulaId, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idColaborador", idColaborador, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEliminarTula");
            }
        }


        public void eliminarDepostio(int depId, int colaborador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteProcBVDeposito");
            _manejador.agregarParametro(comando, "@idDep", depId, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idColaborador", colaborador, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEliminarDepósito");
            }
        }

        public void modificarCodigoTula(string codigo, int tulaId, Colaborador coordinador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTulaProa");

            _manejador.agregarParametro(comando, "@tula", tulaId, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigo", codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@coordinador", coordinador.ID, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaActualizacion");
            }
        }

        public Deposito obtieneDeposito(int codigoDeposito)
        {
            Deposito deposito = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDeposito");
            _manejador.agregarParametro(comando, "@id", codigoDeposito, SqlDbType.Int);
            SqlDataReader reader = null;
            try
            {
                reader = _manejador.ejecutarConsultaDatos(comando);
                while (reader.Read())
                {
                    string CodigoVD = (string)reader["Codigo_VD"];
                    string numeroDeposito = (string)reader["Numero_deposito"];
                    string cuentaReferencia = (string)reader["Cuenta_Referencia"];
                    Monedas moneda = (Monedas)reader["Moneda"];
                    int tipoMesa = (int)reader["TipoMesa_Niquel"];
                    string cedula = (string)reader["Cedula"];
                    decimal montoDeclarado = (decimal)reader["Monto_Declarado"];
                    decimal montoNiqul = (decimal)reader["Monto_Niquel"];
                    string codigoTransaccion = (string)reader["Codigo_Transaccion"];
                    decimal monto = (decimal)reader["Monto_Contado"];
                    decimal diferencia = (decimal)reader["Diferencia"];
                    deposito = new Deposito(0, id: codigoDeposito, monto: monto, moneda: moneda, CodigoVD: CodigoVD, codigotransaccion: codigoTransaccion, cuentareferencia: cuentaReferencia, cedula: cedula, tipomesaniquel: tipoMesa, montoniquel: montoNiqul, montodeclarado: montoDeclarado, diferencia: diferencia, numerodeposito: numeroDeposito);
                }
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error de acceso a la tabla de depositos");
            }
            return deposito;
        }
        public ConteoBillete selectConteoBillete(int idDeposito)
        {
            ConteoBillete cb = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInfoConteoBilleteBajoVolumen");
            _manejador.agregarParametro(comando, "@id", idDeposito, SqlDbType.Int);
            SqlDataReader dataReader = null;
            try
            {
                dataReader = _manejador.ejecutarConsultaDatos(comando);
                while (dataReader.Read())
                {
                    int pk_ID = (int)dataReader["pk_ID"];
                    Monedas moneda = (Monedas)dataReader["Moneda"];
                    decimal c1000 = (decimal)dataReader["1000CRC"];
                    decimal c2000 = (decimal)dataReader["2000CRC"];
                    decimal c5000 = (decimal)dataReader["5000CRC"];
                    decimal c10000 = (decimal)dataReader["10000CRC"];
                    decimal c20000 = (decimal)dataReader["20000CRC"];
                    decimal c50000 = (decimal)dataReader["50000CRC"];
                    decimal u1 = (decimal)dataReader["1USD"];
                    decimal u5 = (decimal)dataReader["5USD"];
                    decimal u10 = (decimal)dataReader["10USD"];
                    decimal u20 = (decimal)dataReader["20USD"];
                    decimal u50 = (decimal)dataReader["50USD"];
                    decimal u100 = (decimal)dataReader["100USD"];
                    decimal e5 = (decimal)dataReader["5EUR"];
                    decimal e10 = (decimal)dataReader["10EUR"];
                    decimal e20 = (decimal)dataReader["20EUR"];
                    decimal e50 = (decimal)dataReader["50EUR"];
                    decimal e100 = (decimal)dataReader["100EUR"];
                    decimal e200 = (decimal)dataReader["200EUR"];
                    decimal e500 = (decimal)dataReader["500EUR"];
                    cb = new ConteoBillete(id: pk_ID, c50000: c50000, c20000: c20000, c10000: c10000, c5000: c5000, c2000: c2000, c1000: c1000, u100: u100, u50: u50, u20: u20, u10: u10, u5: u5, u1: u1, e500: e500, e200: e200, e100: e100, e50: e50, e20: e20, e10: e10, e5: e5, moneda: moneda, idpbv: idDeposito);
                }
                comando.Connection.Close();

            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error de acceso a la tabla de conteo billetes");
            }
            return cb;
}
        public BindingList<BilleteFalso> selectBilletesFalsos(int codigoDeposito)
        {
            BindingList<BilleteFalso> bf = new BindingList<BilleteFalso>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectBilleteFalsoDeposito");
            _manejador.agregarParametro(comando, "@IDDEPOSITO", codigoDeposito, SqlDbType.Int);
            SqlDataReader datareader = null;
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                while (datareader.Read())
                {
                    int ID = (int)datareader["pk_ID"];
                    string serie = (string)datareader["Serie"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    Decimal valorDen = (Decimal)datareader["Denominacion"];
                    Denominacion denominacion = new Denominacion(valor: valorDen, moneda: moneda);
                    BilleteFalso billete = new BilleteFalso(id: ID, serie_billete: serie, denominacion: denominacion, moneda: moneda);
                    bf.Add(billete);
                }
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error al obtener datos de la tabla billetes falsos");
            }

            return bf;
        }


        public BindingList<ChequeDeposito> SelectChequesDeposito(int codigoDeposito)
        {
            BindingList<ChequeDeposito> cheques = new BindingList<ChequeDeposito>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectChequesDeposito");
            _manejador.agregarParametro(comando, "@IDDEPOSITIO", codigoDeposito, SqlDbType.Int);
            SqlDataReader datareader = null;
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    TipoChequeDeposito tipoCheque = (TipoChequeDeposito)datareader["Tipo_Cheque"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    decimal monto = (decimal)datareader["Monto"];
                    ChequeDeposito cd = new ChequeDeposito(id: id, tipoc: tipoCheque, monto: monto, moneda: moneda);
                    cheques.Add(cd);
                }
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error de acceso A cheques deposito");
            }
            return cheques;
        }

        public CompraVenta selctIngresoCompraVenta(int idDeposito)
        {
            CompraVenta cv = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCompraVentaDeposito");
            _manejador.agregarParametro(comando, "@IDDEPOSITIO", idDeposito, SqlDbType.Int);
            SqlDataReader datareader = null;
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                while (datareader.Read())
                {
                    int ID = (int)datareader["pk_ID"];
                    TipoTransaccion tipoTransaccion = (TipoTransaccion)datareader["Tipo_Transaccion"];
                    decimal montoTransaccion = (decimal)datareader["MontoTransaccion"];
                    decimal tipoCambio = (decimal)datareader["TipoCambio"];
                    decimal montoCambio = (decimal)datareader["MontoCambio"];
                    cv = new CompraVenta(id: ID, transaccion: tipoTransaccion, monto_transaccion: montoTransaccion, monto_cambio: montoCambio);
                }
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error de acceso a venta deposito");
            }

            return cv;
        }

        public ConteoNiquel selectConteoNiquel(int p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectConteoNiquel");
            _manejador.agregarParametro(comando, "@depositoId", p, SqlDbType.Int);
            ConteoNiquel conteoNiquel = null;
            SqlDataReader dt = null;
            try
            {
                dt = _manejador.ejecutarConsultaDatos(comando);
                if (dt.HasRows)
                {
                    dt.Read();
                    decimal d500 = (decimal)dt["D500"];
                    decimal d100 = (decimal)dt["D100"];
                    decimal d50 = (decimal)dt["D50"];
                    decimal d25 = (decimal)dt["D25"];
                    decimal d10 = (decimal)dt["D10"];
                    decimal d5 = (decimal)dt["D5"];
                    int id = (int)dt["pk_ID"];
                    conteoNiquel = new ConteoNiquel(id: id, c500: d500, c50: d50, c25: d25, c10: d10, c100: d100, c5: d5);
                }
                comando.Connection.Close();

            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
            return conteoNiquel;
        }


        public void UpdtBitacoraCambiosProBVDpsito(int idDeposito, int coordinadorId, string columnName, string tableName, string datoAnterior, string datoNuevo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBitProceBVDepsito");
            _manejador.agregarParametro(comando, "@id", idDeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinadorId", coordinadorId, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@nombreColumna", columnName, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@datoAnterior", datoAnterior, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@datoNuevo", datoNuevo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@nombreTabla", tableName, SqlDbType.NVarChar);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
        }
        public void UpdtProBVDpsito(int idDeposito, string columnName, string datoNuevo)//procesamiento bajo volumen
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcBajoVolDepositov2");
            _manejador.agregarParametro(comando, "@idDeposito", idDeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@columnName", columnName, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@valor", datoNuevo, SqlDbType.NVarChar);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
        }

        public void insertBitacoraConteoBillete(int idCoordinador, ConteoBillete cb)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBitacoraConteoBilleteCambio");
            _manejador.agregarParametro(comando, "@idpbv", cb.id_PBV, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idCoordinador", idCoordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@CRC1000", cb.CRC1000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC2000", cb.CRC2000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC5000", cb.CRC5000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC10000", cb.CRC10000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC20000", cb.CRC20000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC50000", cb.CRC50000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD1", cb.USD1, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD5", cb.USD5, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD10", cb.USD10, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD20", cb.USD20, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD50", cb.USD50, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD100", cb.USD100, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR5", cb.EUR5, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR10", cb.EUR10, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR20", cb.EUR20, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR50", cb.EUR50, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR100", cb.EUR100, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR200", cb.EUR200, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR500", cb.EUR500, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@totalBillete", cb.conteototal, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", cb.Moneda, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
        }

        public void updateDepositoMontos(int idCoordinador, ConteoBillete cb)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcBajoVolDepositoMontos");
            _manejador.agregarParametro(comando, "@idDeposito", cb.id_PBV, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@CRC1000", cb.CRC1000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC2000", cb.CRC2000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC5000", cb.CRC5000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC10000", cb.CRC10000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC20000", cb.CRC20000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@CRC50000", cb.CRC50000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD1", cb.USD1, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD5", cb.USD5, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD10", cb.USD10, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD20", cb.USD20, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD50", cb.USD50, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@USD100", cb.USD100, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR5", cb.EUR5, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR10", cb.EUR10, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR20", cb.EUR20, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR50", cb.EUR50, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR100", cb.EUR100, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR200", cb.EUR200, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EUR500", cb.EUR500, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", cb.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@conteoTotal", cb.conteototal, SqlDbType.Money);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error al actualizar los montos del deposito");
            }
        }

        public void insertBilleteFalsoDepostito(int p, BilleteFalso bf)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBilleteFalsoDeposito");
            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", p, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@serie", bf.SerieBillete, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@Moneda", bf.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Denominacion", bf.denominacion.Valor, SqlDbType.Money);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error al insertar en la lista de cheques ");
            }
        }

        public void updateBilleteFalsoDeposito(BilleteFalso bf)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcBajoVolDepositoBilleteF");
            _manejador.agregarParametro(comando, "@id", bf.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@serie", bf.SerieBillete, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@moneda", bf.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@denominacion", bf.denominacion.Valor, SqlDbType.Decimal);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error al actualizar la lista de billetes falsos");
            }

        }

        public void updateBitacoraBilleteFalsoDeposito(int idDeposito, BilleteFalso bf, int idCoordinador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBitacoraBilleteFalsoDeposito");
            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", idDeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@serie", bf.SerieBillete, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@Moneda", bf.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@Denominacion", bf.denominacion, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@idCoordinador", idCoordinador, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error al insertar en la lista de cheques ");
            }
        }
        public void eliminarBilleteFalsoDeposito(int idBillete)
        {
            SqlCommand COMANDO = _manejador.obtenerProcedimiento("DeleteBilleteFalsoDeposito");
            _manejador.agregarParametro(COMANDO, "@id", idBillete, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(COMANDO);
                COMANDO.Connection.Close();
            }
            catch
            {
                COMANDO.Connection.Close();
                throw new Exception("Error al eliminar el billete");
            }
        }

        public void insertChequeDeposito(int idDeposito, ChequeDeposito cd)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertChequeDeposito");
            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", idDeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipocheque", cd.TipoCheque, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Moneda", cd.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Monto", cd.Monto, SqlDbType.Decimal);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error al insertar en la lista de cheques ");
            }

        }

        public void updateChequesDeposito(ChequeDeposito cd)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcBajoVolDepositoCheque");
            _manejador.agregarParametro(comando, "@id", cd.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo", cd.TipoCheque, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@moneda", cd.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", cd.Monto, SqlDbType.Decimal);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error al actualizar la lista de cheques ");
            }


        }

        public void updateBitacoraChequesDeposito(int idDeposito, ChequeDeposito cd, int idCoordinador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBitacoraChequeDeposito");
            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", idDeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipocheque", cd.TipoCheque, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Moneda", cd.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Monto", cd.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@coordinador", idCoordinador, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Excepcion("Error al insertar en la lista de cheques ");
            }
        }

        public void eliminarChequeDeposito(int idCheque)
        {
            SqlCommand COMANDO = _manejador.obtenerProcedimiento("DeleteChequeDeposito");
            _manejador.agregarParametro(COMANDO, "@id", idCheque, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(COMANDO);
                COMANDO.Connection.Close();
            }
            catch
            {
                COMANDO.Connection.Close();
                throw new Exception("Error al eliminar el Cheque");
            }
        }
        public void updateConteoNiquel(int id, string columnName, decimal datoNuevo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInfoConteoMontoNiquel");
            _manejador.agregarParametro(comando, "@id", id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@columnName", columnName, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@valor", datoNuevo, SqlDbType.NVarChar);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
        }

        #endregion

        //public DataTable selectTulas(int idManifiesto)
        //{
        //    DataTable dt = new DataTable();
        //    SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasdeManifiesto");
        //    _manejador.agregarParametro(comando, "@idManifiesto", idManifiesto, SqlDbType.Int);
        //    try
        //    {
        //        var da = new SqlDataAdapter(comando);
        //        da.Fill(dt);
        //    }
        //    catch
        //    {
        //        comando.Connection.Close();
        //        throw new Exception("Error cargando las tulas");
        //    }
        //    return dt;
        //}

        public DataTable selectTulas(int idManifiesto)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasdeManifiesto");
            _manejador.agregarParametro(comando, "@idManifiesto", idManifiesto, SqlDbType.Int);
            try
            {
                var da = new SqlDataAdapter(comando);
                da.Fill(dt);
                comando.Connection.Close();
            }
            catch
            {
                comando.Connection.Close();
                throw new Exception("Error cargando las tulas");
            }
            return dt;
        }

        public DataTable selecteDepositos(int tulaId)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDepositosporTula");
            _manejador.agregarParametro(comando, "@codigo", tulaId, SqlDbType.NVarChar);
            try
            {
                var da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            catch
            {
                comando.Connection.Close();
                throw new Exception("Error cargando los depósitos");
            }
            return dt;
        }

        #endregion Métodos Públicos        
    }

}
