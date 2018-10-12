//
//  @ Project : 
//  @ File Name : TiposGestionDL.cs
//  @ Date : 18/08/2011
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
    /// Clase de la capa de datos que maneja los tipos de gestión.
    /// </summary>
    public class TiposGestionDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TiposGestionDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TiposGestionDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TiposGestionDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TiposGestionDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo tipo de gestión.
        /// </summary>
        /// <param name="t">Objeto TipoGestion con los datos del nuevo tipo de gestión</param>
        public void agregarTipoGestion(ref TipoGestion t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTipoGestion");

            _manejador.agregarParametro(comando, "@nombre", t.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tiempo", t.Tiempo_esperado, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@tiempo_aviso", t.Tiempo_aviso, SqlDbType.SmallInt);

            try
            {
                t.Id = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoGestionRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un tipo de gestión.
        /// </summary>
        /// <param name="t">Objeto TipoGestion con los datos del tipo de gestión a actualizar</param>
        public void actualizarTipoGestion(TipoGestion t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTipoGestion");

            _manejador.agregarParametro(comando, "@nombre", t.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tiempo", t.Tiempo_esperado, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@tiempo_aviso", t.Tiempo_aviso, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@tipo_gestion", t.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoGestionActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un tipo de gestión.
        /// </summary>
        /// <param name="t">Objeto TipoGestion con los datos del tipo de gestión a eliminar</param>
        public void eliminarTipoGestion(TipoGestion t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTipoGestion");

            _manejador.agregarParametro(comando, "@tipo_gestion", t.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoGestionEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los tipos de gestión registrados.
        /// </summary>
        /// <returns>Lista de los tipos de gestión registrados en el sistema</returns>
        public BindingList<TipoGestion> listarTiposGestion()
        {
            BindingList<TipoGestion> tipos = new BindingList<TipoGestion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTiposGestion");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    short tiempo = (short)datareader["Tiempo"];
                    short tiempo_aviso = (short)datareader["Tiempo_Aviso"];

                    TipoGestion tipo = new TipoGestion(id, nombre, tiempo, tiempo_aviso);
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
