using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace DataLayer.Clases
{
    public class DetalleFallaDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static DetalleFallaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static DetalleFallaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new DetalleFallaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public DetalleFallaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto DetalleFalla con los datos del punto de venta</param>
        public void agregarDetalleFalla(ref DetalleFalla p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDetalleFalla");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@falla", p.Falla.ID, SqlDbType.Int);

            try
            {
                p.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDetalleFallaActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto DetalleFalla con los datos del punto de venta</param>
        public void actualizarDetalleFalla(DetalleFalla p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDetalleFalla");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@detalle_falla", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDetalleFallaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un detalle de una falla.
        /// </summary>
        /// <param name="s">Objeto DetalleFalla con los datos del punto de venta a eliminar</param>
        public void eliminarDetalleFalla(DetalleFalla p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteDetalleFalla");

            _manejador.agregarParametro(comando, "@punto_venta", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDetalleFallaActualizacion");
            }

        }

        /// <summary>
        /// Obtener los detalle de una falla .
        /// </summary>
        /// <param name="c">Falla para el cual se obtiene la lista de detalles de falla</param>
        public void obtenerDetalleFallaFalla(ref Falla c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDetalleFallaFallas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@falla", c.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Descripcion"];

                    DetalleFalla punto = new DetalleFalla(id, nombre, c);

                    c.agregarDetalleFalla(punto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }
       
        #endregion Métodos Públicos
    }
}
