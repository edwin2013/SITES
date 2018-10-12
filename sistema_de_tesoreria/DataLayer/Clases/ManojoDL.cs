using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using CommonObjects.Clases;
using LibreriaMensajes;

namespace DataLayer.Clases
{
    public class ManojoDL: ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManojoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManojoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManojoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManojoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo deposito.
        /// </summary>
        /// <param name="d">Objeto Manojo con los datos del deposito</param>
        public void agregarManojo(ref Manojo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertManojo");

            _manejador.agregarParametro(comando, "@descripcion", d.Descripcion, SqlDbType.NVarChar);

            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManojoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Manojo con los datos del deposito a actualizar</param>
        public void actualizarManojo(Manojo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManojo");

            _manejador.agregarParametro(comando, "@descripcion", d.Descripcion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@manojo", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManojoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Manojo con los datos del deposito a eliminar</param>
        public void eliminarManojo(Manojo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManojo");

            _manejador.agregarParametro(comando, "@manojo", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManojoEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un deposito ya está registrado en el sistema.
        /// </summary>
        /// <param name="d">Objeto Manojo con los datos del deposito</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarManojo(Manojo d)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManojo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descripcion", d.Descripcion, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != d.ID;

                    d.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManojo");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los depositos que tienen un determinado número de referencia o parte del mismo.
        /// </summary>
        /// <param name="r">Referencia o parte de la misma de los depositos que se listarán</param>
        /// <returns>Lista de depositos que cumplen con el criterio de búsqueda</returns>
        public BindingList<Manojo> listarManojos(string r)
        {
            BindingList<Manojo> depositos = new BindingList<Manojo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManojos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descripcion", r, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Manojo"];
                    string referencia = (string)datareader["Descripcion"];

                    Manojo deposito = new Manojo(id: id, descripcion: referencia);

                    depositos.Add(deposito);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return depositos;
        }

        #endregion Métodos Públicos
    }
}
