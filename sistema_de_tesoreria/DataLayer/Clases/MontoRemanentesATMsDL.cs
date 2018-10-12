using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;


namespace DataLayer
{
    public class MontoRemanentesATMsDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static MontoRemanentesATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static MontoRemanentesATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MontoRemanentesATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador_sql = ManejadorBD.Instancia;
        private ManejadorAS400 _manejador_as400 = ManejadorAS400.Instancia;

        #endregion Atributos

        #region Constructor

        public MontoRemanentesATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Guardar en el sistema el registro de remanentes de un ATM.
        /// </summary>
        /// <param name="r">Objeto RegistroRemanentesATM con los datos del registro</param>
        public void agregarRegistroRemanentesATMCompletos(ref MontoRemanenteATM r)
        {
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("InsertRegistroATMsCompletos");

            _manejador_sql.agregarParametro(comando, "@fk_ID_ATM", r.ID, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@Fecha_Actual", r.FechaActual, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@Fecha_Ultima_Transaccion", r.FechaUltimaTransaccion, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@Localizacion", r.Localizacion, SqlDbType.NVarChar);
            _manejador_sql.agregarParametro(comando, "@Den_Gav1", r.Denominacion1, SqlDbType.Int);
            _manejador_sql.agregarParametro(comando, "@Monto_Gav1", r.Montog1, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@Den_Gav2", r.Denominacion2, SqlDbType.Int);
            _manejador_sql.agregarParametro(comando, "@Monto_Gav2", r.Montog2, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@Den_Gav3", r.Denominacion3, SqlDbType.Int);
            _manejador_sql.agregarParametro(comando, "@Monto_Gav3", r.Montog3, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@Den_Gav4", r.Denominacion4, SqlDbType.Int);
            _manejador_sql.agregarParametro(comando, "@Monto_Gav4", r.Montog4, SqlDbType.Decimal);

            try
            {
                _manejador_sql.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroRemantentesCompletos");
            }

        }


        /// <summary>
        /// Registra el registro de las cargas de emergencia
        /// </summary>
        /// <param name="r">Monto Remantente con cargas de Emergencia a guardar</param>

        public void agregarRegistroCargasdeEmergencia(ref MontoRemanenteATM r)
        {
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("InsertRegistroCargasEmergencia");

            _manejador_sql.agregarParametro(comando, "@fk_ID_ATM", r.ID, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@FechaActual", r.FechaActual, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@FechaUltimaTransaccion", r.FechaUltimaTransaccion, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@Localizacion", r.Localizacion, SqlDbType.VarChar);            
            _manejador_sql.agregarParametro(comando, "@DiasdeInventario", r.DiasInventario, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@CargadeEmergencia", r.CargaEmergencia, SqlDbType.NChar);
            _manejador_sql.agregarParametro(comando, "@montoTotalColones",r.MontoTotalColones,SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@DiasInventarioRequerido", r.DiasInventarioRequerido, SqlDbType.Decimal);

            try
            {
                _manejador_sql.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroRemantentesCompletos");
            }

        }


        /// <summary>
        /// Actualizar en el sistema el registro de remanentes de un ATM.
        /// </summary>
        /// <param name="r">Objeto MontosATM con los datos del registro a actualizar</param>
        public void actualizarRegistroRemanentesATMCompleto(MontoRemanenteATM r)
        {
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("UpdateRegistroATMsCompletos");

            _manejador_sql.agregarParametro(comando, "@fk_ID_ATM", r.ID, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@Fecha_Actual", r.FechaActual, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@Fecha_Ultima_Transaccion", r.FechaUltimaTransaccion, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@Localizacion", r.Localizacion, SqlDbType.NVarChar);
            _manejador_sql.agregarParametro(comando, "@Den_Gav1", r.Denominacion1, SqlDbType.Int);
            _manejador_sql.agregarParametro(comando, "@Monto_Gav1", r.Montog1, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@Den_Gav2", r.Denominacion2, SqlDbType.Int);
            _manejador_sql.agregarParametro(comando, "@Monto_Gav2", r.Montog2, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@Den_Gav3", r.Denominacion3, SqlDbType.Int);
            _manejador_sql.agregarParametro(comando, "@Monto_Gav3", r.Montog3, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@Den_Gav4", r.Denominacion4, SqlDbType.Int);
            _manejador_sql.agregarParametro(comando, "@Monto_Gav4", r.Montog4, SqlDbType.Decimal);

            try
            {
                _manejador_sql.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroRemantentesCompletos");
            }

        }



        /// <summary>
        /// Actualizar una carga de emergencia ya existente en el registro existente
        /// </summary>
        /// <param name="r">Monto Remanente con los datos</param>
        public void actualizarRegistroCargasEmergencia(MontoRemanenteATM r)
        {
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("[UpdateRegistroCargaEmergencia]");

            _manejador_sql.agregarParametro(comando, "@fk_ID_ATM", r.ID, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@FechaActual", r.FechaActual, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@FechaUltimaTransaccion", r.FechaUltimaTransaccion, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@Localizacion", r.Localizacion, SqlDbType.VarChar);
            _manejador_sql.agregarParametro(comando, "@DiasdeInventario", r.DiasInventario, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@CargadeEmergencia", r.CargaEmergencia, SqlDbType.NChar);
            _manejador_sql.agregarParametro(comando, "@montoTotalColones", r.MontoTotalColones, SqlDbType.Decimal);
            _manejador_sql.agregarParametro(comando, "@DiasInventarioRequerido", r.DiasInventarioRequerido, SqlDbType.Decimal);

            try
            {
                _manejador_sql.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroRemantentesCompletos");
            }

        }

      

        /// <summary>
        /// Verificar si existe un registro de montos remanentes para una ATM en un día específico.
        /// </summary>
        /// <param name="r">Objeto MontoRemanentesATM con los datos del monto a verificar</param>
        /// <returns>Valor que indica si el registro existe</returns>
        public bool verificarRegistroRemanentesATMCompletos(ref MontoRemanenteATM r)
        {
            bool existe = false;

            SqlCommand comando = _manejador_sql.obtenerProcedimiento("SelectRegistroRemanentesATMCompletos");
            SqlDataReader datareader = null;

            _manejador_sql.agregarParametro(comando, "@atm", r.ID, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@fecha", r.FechaActual, SqlDbType.Date);

            try
            {
                datareader = _manejador_sql.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    existe = true;

                    //int id = (int)datareader["fk_ID_ATM"];
                    //// bool cargado = (bool)datareader["Cargado"];

                    //r.ID = id;
                    //// r.Cargado = cargado;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return existe;
        }







        /// <summary>
        /// Verificar si existe una carga de emergencia
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool verificarRegistroCargasEmergencia(ref MontoRemanenteATM r, DateTime f)
        {
            bool existe = false;

            SqlCommand comando = _manejador_sql.obtenerProcedimiento("SelectRegistroCargasEmergencia");
            SqlDataReader datareader = null;

            _manejador_sql.agregarParametro(comando, "@atm", r.ID, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador_sql.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    existe = true;

                    //int id = (int)datareader["fk_ID_ATM"];
                    //// bool cargado = (bool)datareader["Cargado"];

                    //r.ID = id;
                    //// r.Cargado = cargado;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return existe;
        }



        /// <summary>
        /// Registrar en el sistema un monto remanente de un ATM.
        /// </summary>
        /// <param name="m">Objeto MontoRemanenteATM con los datos del monto</param>
        /// <param name="r">Objeto RegistroRemanentesATM con los datos del registro de remanentes del ATM</param>
        public void agregarMontoRemanenteATM(MontoRemanenteATM m, RegistroRemanentesATM r)
        {
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("InsertMontoRemanenteATM");

            _manejador_sql.agregarParametro(comando, "@denominacion", m.Denominacion, SqlDbType.TinyInt);
            _manejador_sql.agregarParametro(comando, "@cantidad", m.Cantidad, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@posicion", m.Posicion, SqlDbType.TinyInt);
            _manejador_sql.agregarParametro(comando, "@registro", r, SqlDbType.Int);

            try
            {
                m.ID = (int)_manejador_sql.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoRemanenteATMActualizacion");
            }

        }

        /// <summary>
        /// Actualizar el monto remanente de un ATM.
        /// </summary>
        /// <param name="m">Objeto MontoRemanenteATM con los datos del monto a actualizar</param>
        public void actualizarMontoRemanenteATM(MontoRemanenteATM m)
        {
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("UpdateMontoRemanenteATM");

            _manejador_sql.agregarParametro(comando, "@cantidad", m.Cantidad, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@monto", m.ID, SqlDbType.Int);

            try
            {
                _manejador_sql.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoRemanenteATMActualizacion");
            }

        }

        /// <summary>
        /// Eliminar el monto remanente de un ATM.
        /// </summary>
        /// <param name="m">Objeto MontoRemanenteATM con los datos del monto a eliminar</param>
        public void eliminarMontoRemanenteATM(MontoRemanenteATM m)
        {
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("DeleteMontoRemanenteATM");

            _manejador_sql.agregarParametro(comando, "@monto", m.ID, SqlDbType.Int);

            try
            {
                _manejador_sql.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoRemanenteATMActualizacion");
            }

        }

        /// <summary>
        /// Obtener los montos remanentes para un registro de montos remanentes.
        /// </summary>
        /// <param name="r">Objeto RegistroRemanentesATM con los datos del registro</param>
        public void obtenerMontosRegistroRemanentesATM(ref RegistroRemanentesATM r)
        {
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("SelectRegistroRemanentesATMMontos");
            SqlDataReader datareader = null;

            _manejador_sql.agregarParametro(comando, "@registro", r, SqlDbType.Int);

            try
            {
                datareader = _manejador_sql.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_monto = (int)datareader["ID_Monto"];
                    short cantidad = (short)datareader["Cantidad"];
                    byte posicion = (byte)datareader["Posicion"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    decimal valor = (decimal)datareader["Valor"];

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);

                    MontoRemanenteATM monto = new MontoRemanenteATM(denominacion, cantidad, posicion, id: id_monto);

                    r.agregarMonto(monto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener una lista de los montos remanentes por denominacion de uno o varios ATM's en una fecha.
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los remanentes</param>
        /// <param name="f">Fecha para la generación de la lista</param>
        /// <param name="t">Transportadora encargada de los ATM's</param>
        /// <param name="c">Valor que indica si solo se listarán los ATM's que tienen una carga programada</param>
        /// <param name="c">Valor que indica si solo se listarán los ATM's que ya fueron cargados</param>
        /// <returns>Lista con los montos remanentes por denominación de los ATM's en las fecha especificada</returns>
        public DataTable listarRegistrosRemanentesATMsPorDenominacion(ATM a, DateTime f, EmpresaTransporte t, bool p, bool c)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("SelectRegistrosRemanentesATMsPorDenominacionPRUEBAERICK");
            SqlDataReader datareader = null;

            _manejador_sql.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador_sql.agregarParametro(comando, "@transportadora", t, SqlDbType.TinyInt);
            _manejador_sql.agregarParametro(comando, "@programados", p, SqlDbType.Bit);
            _manejador_sql.agregarParametro(comando, "@cargados", c, SqlDbType.Bit);

            try
            {
                datareader = _manejador_sql.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }


        /// <summary>
        /// Importación  de Datos del la biblioteca AZ400LIB, remanetes ATM's e inclusión en la base del SITES
        /// </summary>
        /// <param name="a"></param>
        /// <param name="f"></param>
        /// <param name="t"></param>
        /// <param name="p"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public DataTable listarRegistrosRemanentesATMsCompletos()
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("SP_OBTENER_REMANENTES_ATMS");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador_sql.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        /// <summary>
        /// Obtener una lista de los montos remanentes de uno o varios ATM's entre dos fechas.
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los remanentes</param>
        /// <param name="i">Fecha inicial para la generación de la lista</param>
        /// <param name="f">Fecha final para la generación de la lista</param>
        /// <returns>Lista con los montos remanentes de los ATM's entre las fechas especificadas</returns>
        public DataTable listarRegistrosRemanentesATMs(ATM a, DateTime i, DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador_sql.obtenerProcedimiento("SelectRegistrosRemanentesATMs");
            SqlDataReader datareader = null;

            _manejador_sql.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador_sql.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador_sql.agregarParametro(comando, "@fecha_fin", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador_sql.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }



        /// <summary>
        /// Obtener una lista de los montos remanentes desde el AS400.
        /// </summary>
        /// <returns>Tabla con la lista de montos remanentes</returns>
        public DataTable listarRemanentesAS400()
        {
            DataTable salida = new DataTable();

            string consulta = "SELECT CAJLNO, CAJLOC, CAJCFT, CAJESR, CAJPFA, CAJCDI, CAJCB1, CAJCB2, CAJCB3, CAJCB4, " +
                               "CAJCNE, CAJCNC, CAJCDO, CAJCFG, CAJHUT, CAJFUT, CAJFIL  FROM AZ400LIB.ADCAJ " +
                               "WHERE CAJCFT = (01)";

            OdbcCommand comando = _manejador_as400.obtenerConsulta(consulta);
            OdbcDataReader datareader = null;

            try
            {
                datareader = _manejador_as400.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        #endregion Métodos Públicos
    }
}
