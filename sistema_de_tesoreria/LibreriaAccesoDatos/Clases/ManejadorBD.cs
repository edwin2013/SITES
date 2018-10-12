//
//  @ Project : 
//  @ File Name : ManejadorBD.cs
//  @ Date : 19/01/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Data.SqlClient;
using System.Data;

namespace LibreriaAccesoDatos
{
    /// <summary>
    /// Clase de acceso a la base de datos.
    /// </summary>
    public class ManejadorBD
    {

        #region Constantes

        #endregion Constantes

        #region Constructor

        private ManejadorBD() { }

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
        private SqlConnection _conexion = null;

        /// <summary>
        /// Obtener la conexión a la base de datos.
        /// </summary>
        private SqlConnection Conexion
        {
            get
            {
                return this._conexion;
            }
        }

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManejadorBD _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManejadorBD Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManejadorBD();
                return _instancia;
            }
        }

        #endregion Atributos

        #region Métodos

        /// <summary>
        /// Crear una nueva conexion a la base de datos.
        /// </summary>
        /// <param name="servidor">Nombre del servidor</param>
        /// <param name="base_datos">Nombre de la base de datos</param>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="pass">Password del usuario</param>
        public void conectarse(string servidor,
                               string base_datos,
                               string usuario,
                               string pass)
        {

            try
            {
                string conexion = "Data Source=" + servidor + ";Initial Catalog=" + base_datos + ";User ID=" + usuario + "; Password=" + pass;

                _conexion = new SqlConnection(conexion);
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
        /// Obtener un comando para utilizar en la base de datos.
        /// </summary>
        /// <param name="consulta">Procedimiento almacenado que será ejecutado</param>
        /// <returns>Un comando SQL que ejecuta una consulta SQL</returns>
        public SqlCommand obtenerProcedimiento(string consulta)
        {
            SqlConnection conexion  = _conexion;
            SqlCommand comando = new SqlCommand(consulta, conexion);

            comando.CommandType = CommandType.StoredProcedure;

            return comando;
        }

        /// <summary>
        /// Obtener un comando para utilizar en la base de datos a partir de una consulta.
        /// </summary>
        /// <param name="consulta">Consulta que será ejecutada</param>
        /// <returns>Un comando SQL que ejecuta una consulta SQL</returns>
        public SqlCommand obtenerConsulta(string consulta)
        {
            SqlConnection conexion = _conexion;
            SqlCommand comando = new SqlCommand(consulta, conexion);

            comando.CommandType = CommandType.Text;

            return comando;
        }

        /// <summary>
        /// Agregar un parámetro a un comando.
        /// </summary>
        /// <param name="comando">El comando al que se le agregará el parámeto</param>
        /// <param name="parametro">Nombre del parametro sin @</param>
        /// <param name="valor">Valor del parámetro</param>
        /// <param name="tipo">Tipo del parámetro</param>
        /// <returns>Parámetro agregado</returns>
        public SqlParameter agregarParametro(SqlCommand comando,
                                             string parametro,
                                             object valor,
                                             SqlDbType tipo)
        {
            SqlParameter parametro_sql = new SqlParameter(parametro, tipo);

            if (valor == null)
                parametro_sql.Value =  DBNull.Value;
            else if (valor is ObjetoIndexado)
                parametro_sql.Value =  ((ObjetoIndexado)valor).DB_ID;
            else
                parametro_sql.Value = valor;

            comando.Parameters.Add(parametro_sql);

            return parametro_sql;
        }

        /// <summary>
        /// Ejecutar un comando que devuelve datos.
        /// Este método no cierra la conexión a la base de datos.
        /// </summary>
        /// <param name="comando">Comando que va a ejecutarse</param>
        /// <returns>Dataset generado por el comando</returns>
        public DataSet ejecutarConsultaDataset(SqlCommand comando)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
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
        public SqlDataReader ejecutarConsultaDatos(SqlCommand comando)
        {
            comando.Connection.Open();

            SqlDataReader datos = comando.ExecuteReader();

            return datos;
        }

        /// <summary>
        /// Ejecutar un comando que no devuelve datos.
        /// </summary>
        /// <param name="comando">Comando que se ejecutará</param>
        public void ejecutarConsultaActualizacion(SqlCommand comando)
        {
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }

        /// <summary>
        /// Ejecutar un escalar.
        /// </summary>
        /// <param name="comando">Comando que va a ejecutarse</param>
        /// <returns>Un objeto con el valor devuelto por la consulta</returns>
        public Object ejecutarEscalar(SqlCommand comando)
        {
            Object valor = null;

            comando.Connection.Open();
            valor = comando.ExecuteScalar();
            comando.Connection.Close();

            return valor;
        }

        public SqlConnection DBConexion
        {
            get
            {
                return _conexion;
            }

            set
            {
                _conexion = value;
            }
        }


        #endregion Métodos

    }

}
