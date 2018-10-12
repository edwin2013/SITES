//
//  @ Project : 
//  @ File Name : TiposErrorCierreCajeroDL.cs
//  @ Date : 05/03/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los tipos de erro para los cierres de los cajeros.
    /// </summary>
    public class TiposErrorCierreCajeroDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TiposErrorCierreCajeroDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TiposErrorCierreCajeroDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TiposErrorCierreCajeroDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TiposErrorCierreCajeroDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo tipo de error para los cierres.
        /// </summary>
        /// <param name="t">Objeto TipoErrorCierre con los datos del nuevo tipo de error</param>
        public void agregarTipoError(ref TipoErrorCierre t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTipoErrorCierre");

            _manejador.agregarParametro(comando, "@nombre", t.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@descripcion", t.Descripcion, SqlDbType.VarChar);

            try
            {
                t.Id = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoErrorCierreRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un tipo de error para los cierres.
        /// </summary>
        /// <param name="t">Objeto TipoErrorCierre con los datos del tipo de error a actualizar</param>
        public void actualizarTipoError(TipoErrorCierre t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTipoErrorCierre");

            _manejador.agregarParametro(comando, "@nombre", t.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@descripcion", t.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipo_error", t.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoErrorCierreActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un tipo de error para los cierres.
        /// </summary>
        /// <param name="t">Objeto TipoErrorCierre con los datos del tipo de error a eliminar</param>
        public void eliminarTipoError(TipoErrorCierre t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTipoErrorCierre");

            _manejador.agregarParametro(comando, "@tipo_error", t.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoErrorCierreEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los tipos de errores para cierres registrados.
        /// </summary>
        /// <returns>Lista de los tipos de errores para cierres registrados en el sistema</returns>
        public BindingList<TipoErrorCierre> listarTiposErrores()
        {
            BindingList<TipoErrorCierre> tipos = new BindingList<TipoErrorCierre>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTiposErrorCierre");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string descripcion = (string)datareader["Descripcion"];

                    TipoErrorCierre tipo = new TipoErrorCierre(id, nombre, descripcion);

                    tipos.Add(tipo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tipos;
        }
       
        #endregion Métodos Públicos

    }

}
