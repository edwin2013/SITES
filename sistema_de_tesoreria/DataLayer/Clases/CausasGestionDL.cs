//
//  @ Project : 
//  @ File Name : CausasGestionDL.cs
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
    /// Clase de la capa de datos que maneja las causas de las gestiones.
    /// </summary>
    public class CausasGestionDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CausasGestionDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CausasGestionDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CausasGestionDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CausasGestionDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva causa para las gestiones.
        /// </summary>
        /// <param name="c">Objeto CausaGestion con los datos de la nueva causa</param>
        public void agregarCausaGestion(ref CausaGestion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCausaGestion");

            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@causante", c.Causante, SqlDbType.TinyInt);

            try
            {
                c.Id = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCausaGestionRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una causa de gestiones.
        /// </summary>
        /// <param name="c">Objeto CausaGestion con los datos de la causa a actualizar</param>
        public void actualizarCausaGestion(CausaGestion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCausaGestion");

            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@causante", c.Causante, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@causa", c.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCausaGestionActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una causa de gestiones.
        /// </summary>
        /// <param name="c">Objeto CausaGestion con los datos de la causa a eliminar</param>
        public void eliminarCausaGestion(CausaGestion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCausaGestion");

            _manejador.agregarParametro(comando, "@causa", c.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCausaGestionEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las causas de gestiones.
        /// </summary>
        /// <returns>Lista de causas de gestiones registradas en el sistema</returns>
        public BindingList<CausaGestion> listarCausasGestion()
        {
            BindingList<CausaGestion> causas = new BindingList<CausaGestion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCausasGestion");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string descripcion = (string)datareader["Descripcion"];
                    Causantes causante = (Causantes)datareader["Causante"];

                    CausaGestion causa = new CausaGestion(id, descripcion, causante);
                    causas.Add(causa);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return causas;
        }
       
        #endregion Métodos Públicos

    }

}
