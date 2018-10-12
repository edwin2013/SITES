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
    public class InconsistenciaFacturacionDL : ObjetoIndexado
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static InconsistenciaFacturacionDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static InconsistenciaFacturacionDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new InconsistenciaFacturacionDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public InconsistenciaFacturacionDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto InconsistenciaFacturacion con los datos de la nueva cámara</param>
        public void agregarInconsistenciaFacturacion(ref InconsistenciaFacturacion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInconsistenciaFacturacion");

            _manejador.agregarParametro(comando, "@identificador", c.Identificador, SqlDbType.NVarChar);
 

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaFacturacionRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto InconsistenciaFacturacion con los datos de la cámara a actualizar</param>
        public void actualizarInconsistenciaFacturacion(InconsistenciaFacturacion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInconsistenciaFacturacion");

            _manejador.agregarParametro(comando, "@identificador", c.Identificador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@inconsistencia", c, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaFacturacionActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto InconsistenciaFacturacion con los datos de la cámara a eliminar</param>
        public void eliminarInconsistenciaFacturacion(InconsistenciaFacturacion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteInconsistenciaFacturacion");

            _manejador.agregarParametro(comando, "@inconsistencia", c, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaFacturacionEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las cámaras registradas.
        /// </summary>
        /// <returns>Lista de cámaras registradas en el sistema</returns>
        public BindingList<InconsistenciaFacturacion> listarInconsistenciaFacturacions()
        {
            BindingList<InconsistenciaFacturacion> camaras = new BindingList<InconsistenciaFacturacion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciaFacturacion");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string identificador = (string)datareader["Descripcion"];
          

                    InconsistenciaFacturacion camara = new InconsistenciaFacturacion(identificador, id: id);

                    camaras.Add(camara);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return camaras;
        }

       
       
        #endregion Métodos Públicos
    }
}
