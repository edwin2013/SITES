//
//  @ Project : 
//  @ File Name : CoordinacionCEFDL.cs
//  @ Date : 24/01/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    public class CoordinacionDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CoordinacionDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CoordinacionDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CoordinacionDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CoordinacionDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Agregar un registro a la bitácora de monitoreo de manifiestos.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del coordinador que realizó el monitoreo</param>
        public void agregarRegistroBitacoraMonitoreo(Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRegistroBitacoraMonitoreo");

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroBitacoraMonitoreoRegistro");
            }

        }

        /// <summary>
        /// Actualizar el comentario de un registro de la bitácora de monitoreo de manifiestos.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del coordinador que realizó el monitoreo</param>
        /// <param name="co">Comentario que se asignará al registro</param>
        public void actualizarRegistroBitacoraMonitoreo(Colaborador c, string co)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRegistroBitacoraMonitoreo");

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", co, SqlDbType.VarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroBitacoraMonitoreoActualizacion");
            }

        }

        /// <summary>
        /// Obtener los datos del monitoreo de manifiestos no procesados.
        /// </summary>
        /// <param name="i">Fecha incial para la cual se desea delimitar la consulta</param>
        /// <param name="g">Grupo para el cual se desean obtener los manifiestos pendientes de procesar</param>
        /// <returns>Tabla con la lista de los manifiestos pendientes de procesar</returns>
        public DataTable obtenerDatosMonitoreoManifiestos(DateTime i, Grupo g)
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosMonitoreo");

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@grupo", g.Id, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
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
        /// Obtener los datos del monitoreo de ATM's.
        /// </summary>
        /// <returns>Tabla con los datos del monitoreo de ATM's</returns>
        public DataTable obtenerDatosMonitoreoATMs()
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectMonitoreoATMs");

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
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
        /// Obtener los datos del monitoreo de cargas y descargas ATM's para una fecha específica.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la consulta</param>
        /// <returns>Tabla con los datos del monitoreo de las cargas y descargas</returns>
        public DataTable obtenerDatosMonitoreoCargasDescargas(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectMonitoreoCargasATMsDescargsATMs");

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
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
        /// Obtener la fecha del servidor.
        /// </summary>
        /// <returns>Hora y Fecha actual del servidor</returns>
        public DateTime obtenerFechaHora()
        {
            DateTime fecha_hora = DateTime.Now;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectFechaHora");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                datareader.Read();

                fecha_hora = (DateTime)datareader["Fecha_Hora"];

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return fecha_hora;
        }


        //// <summary>
        /// Obtener los datos del monitoreo de manifiestos procesados.
        /// </summary>
        /// <param name="i">Fecha incial para la cual se desea delimitar la consulta</param>
        /// <param name="t">Transportadora para el cual se desean obtener los manifiestos procesados</param>
        /// <returns>Tabla con la lista de los manifiestos pendientes de procesados</returns>
        public DataTable obtenerDatosManifiestosFacturacion(DateTime i, EmpresaTransporte t)
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosFacturacion");

            _manejador.agregarParametro(comando, "@fecha_inicia", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
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
