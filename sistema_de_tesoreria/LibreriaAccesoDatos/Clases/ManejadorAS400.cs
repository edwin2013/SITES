//
//  @ Project : 
//  @ File Name : ManejadorAS400.cs
//  @ Date : 10/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.Data.Odbc;
using System.Data;

namespace LibreriaAccesoDatos
{

    public class ManejadorAS400
    {

        #region Constantes

        #endregion Constantes

        #region Constructor

        private ManejadorAS400() { }

        #endregion Constructor

        #region Atributos

        /// <summary>
        /// Especifica el usuario de la base.
        /// </summary>
        private string _usuario = string.Empty;

        /// <summary>
        /// Especifica el password de  usuario de la base de datos.
        /// </summary>
        private string _pass = string.Empty;

        /// <summary>
        /// Conexión a la base de datos.
        /// </summary>
        private OdbcConnection _conexion = null;

        /// <summary>
        /// Obtener la conexión a la base de datos.
        /// </summary>
        private OdbcConnection Conexion
        {
            get
            {
                return this._conexion;
            }
        }

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManejadorAS400 _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManejadorAS400 Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManejadorAS400();
                return _instancia;
            }
        }

        #endregion Atributos

        #region Métodos

        /// <summary>
        /// Crear una nueva conexion a la base de datos.
        /// </summary>
        /// <param name="servidor">Nombre del servidor</param>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="pass">Password del usuario</param>
        public void conectarse(string servidor,
                               string usuario,
                               string pass)
        {

            try
            {
                string conexion = "Driver={Client Access ODBC Driver (32-bit)};System=" + servidor + ";UID=" + usuario + ";PWD=" + pass + ";DBQ=";

                _conexion = new OdbcConnection(conexion);
                _conexion.Open();
                _conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Cerrar la conexión
        /// </summary>
        public void desconectarse()
        {
            _conexion.Close();
            _conexion = null;
        }

        /// <summary>
        /// Obtener un comando para utilizar en la base de datos a partir de una consulta.
        /// </summary>
        /// <param name="consulta">Consulta que será ejecutada</param>
        /// <returns>Un comando SQL que ejecuta una consulta</returns>
        public OdbcCommand obtenerConsulta(string consulta)
        {
            OdbcConnection conexion = _conexion;
            OdbcCommand comando = new OdbcCommand(consulta, conexion);

            comando.CommandType = CommandType.Text;

            return comando;
        }
        
        /// <summary>
        /// Ejecutar un comando que devuelve datos.
        /// Este método no cierra la conexión a la base de datos.
        /// </summary>
        /// <param name="comando">Comando que va a ejecutarse</param>
        /// <returns>Dataset generado por el comando</returns>
        public DataSet ejecutarConsultaDataset(OdbcCommand comando)
        {
            OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
            DataSet datos = new DataSet();

            comando.Connection.Open();
            adaptador.Fill(datos);

            return datos;
        }

        /// <summary>
        /// Ejecutar un comando que devuelve datos.
        /// Este método no cierra la conexión a la base de datos.
        /// </summary>
        /// <param name="comando">Comando que va a ejecutarse</param>
        /// <returns>Datareader que contiene los datos devueltos por la consulta</returns>
        public OdbcDataReader ejecutarConsultaDatos(OdbcCommand comando)
        {
            comando.Connection.Open();

            OdbcDataReader datos = comando.ExecuteReader();


            return datos;
        }

        #endregion Métodos

    }

}
