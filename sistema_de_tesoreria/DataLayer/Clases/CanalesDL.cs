//
//  @ Project : 
//  @ File Name : CanalesDL.cs
//  @ Date : 07/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los canales.
    /// </summary>
    public class CanalesDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CanalesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CanalesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CanalesDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CanalesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo canal.
        /// </summary>
        /// <param name="c">Objeto Canal con los datos del nuevo canal</param>
        public void agregarCanal(ref Canal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCanal");

            _manejador.agregarParametro(comando, "@nombre", c.Nombre, SqlDbType.VarChar);

            try
            {
                c.Id = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCanalRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un canal.
        /// </summary>
        /// <param name="c">Objeto Canal con los datos del canal a actualizar</param>
        public void actualizarCanal(Canal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCanal");

            _manejador.agregarParametro(comando, "@nombre", c.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@canal", c.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCanalActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un canal.
        /// </summary>
        /// <param name="c">Objeto Canal con los datos del canal a eliminar</param>
        public void eliminarCanal(Canal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCanal");

            _manejador.agregarParametro(comando, "@canal", c.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCanalEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los canales registrados.
        /// </summary>
        /// <returns>Lista de canales registrados en el sistema</returns>
        public BindingList<Canal> listarCanales()
        {
            BindingList<Canal> canales = new BindingList<Canal>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCanales");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    Canal canal = new Canal(id, nombre);
                    canales.Add(canal);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return canales;
        }
       
        #endregion Métodos Públicos

    }

}
