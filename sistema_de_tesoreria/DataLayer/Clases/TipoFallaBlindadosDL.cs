using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class TipoFallaBlindadosDL : ObjetoIndexado
    {
         #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TipoFallaBlindadosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TipoFallaBlindadosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TipoFallaBlindadosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TipoFallaBlindadosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto TipoFallasBlindados con los datos de la nueva cámara</param>
        public void agregarTipoFallasBlindados(ref TipoFallasBlindados c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTipoFallasBlindados");

            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.NVarChar);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoFallasBlindadosRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto TipoFallasBlindados con los datos de la cámara a actualizar</param>
        public void actualizarTipoFallasBlindados(TipoFallasBlindados c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTipoFallasBlindados");

            _manejador.agregarParametro(comando, "@descipcion", c.Descripcion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoFallasBlindadosActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto TipoFallasBlindados con los datos de la cámara a eliminar</param>
        public void eliminarTipoFallasBlindados(TipoFallasBlindados c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTipoFallasBlindados");

            _manejador.agregarParametro(comando, "@tipo", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoFallasBlindadosEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las cámaras registradas.
        /// </summary>
        /// <returns>Lista de cámaras registradas en el sistema</returns>
        public BindingList<TipoFallasBlindados> listarTipoFallasBlindadoss()
        {
            BindingList<TipoFallasBlindados> TipoFallasBlindadoss = new BindingList<TipoFallasBlindados>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTipoFallasBlindadoss");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];


                    string descripcion = "";
                    
                    if(datareader["Descripcion"]!=DBNull.Value)
                        descripcion = (string)datareader["Descripcion"];

                    TipoFallasBlindados TipoFallasBlindados = new TipoFallasBlindados(id: id, descripcion: descripcion);

                    TipoFallasBlindadoss.Add(TipoFallasBlindados);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return TipoFallasBlindadoss;
        }

       
       
        #endregion Métodos Públicos

    }
}
