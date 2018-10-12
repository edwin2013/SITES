using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

using CommonObjects;
using LibreriaMensajes;
using CommonObjects.Clases;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace DataLayer.Clases
{
    /// <summary>
    /// Clase de la capa de datos que maneja los estados.
    /// </summary>
   public class EstadoCartuchoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static EstadoCartuchoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static EstadoCartuchoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EstadoCartuchoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public EstadoCartuchoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo estado.
        /// </summary>
        /// <param name="g">Objeto EstadoCartucho con los datos del nuevo estado</param>
        public void agregarEstadoCartucho(ref EstadoCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertEstado");

            //_manejador.agregarParametro(comando, "@tipo", g.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estado", g.Estado, SqlDbType.NVarChar);
            try
            {
                g.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEstadoCartuchoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una estado.
        /// </summary>
        /// <param name="g">Objeto EstadoCartucho con los datos del estado a actualizar</param>
        public void actualizarEstadoCartucho(ref EstadoCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEstadosCartuchos");

            _manejador.agregarParametro(comando, "@id", g.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estado", g.Estado, SqlDbType.NVarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEstadoCartuchoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una estado.
        /// </summary>
        /// <param name="t">Objeto EstadoCartucho con los datos de la estado a eliminar</param>
        public void eliminarEstadoCartucho(EstadoCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteEstado");

            _manejador.agregarParametro(comando, "@estado", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErroroEstadoCartuchoEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las EstadoCartuchoes registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las EstadoCartuchoes registradas en el sistema</returns>
        public BindingList<EstadoCartucho> listarEstadosCartucho(string nombre)
        {
            BindingList<EstadoCartucho> EstadosCartucho = new BindingList<EstadoCartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEstadosCartuchos");

            _manejador.agregarParametro(comando, "@estado", nombre, SqlDbType.NVarChar);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_EstadoCartucho = (int)datareader["pk_ID"];
                    string nom = (string)datareader["Estado"];

                    EstadoCartucho EstadoCartucho = new EstadoCartucho(id: id_EstadoCartucho, estado: nom);

                    EstadosCartucho.Add(EstadoCartucho);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return EstadosCartucho;
        }

        #endregion Métodos Públicos
    }
}
