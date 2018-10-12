using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using System.Data;
using CommonObjects.Clases;
using LibreriaMensajes;
using System.ComponentModel;

namespace DataLayer.Clases
{
    public class TipoEquipoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TipoEquipoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TipoEquipoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TipoEquipoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TipoEquipoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo tipo de equpio.
        /// </summary>
        /// <param name="d">Objeto TipoEquipo con los datos del deposito</param>
        public void agregarTipoEquipo(ref TipoEquipo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTipoEquipo");

            _manejador.agregarParametro(comando, "@descripcion", d.Descripcion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@obligatorio", d.Obligatorio, SqlDbType.Bit);

            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoEquipoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto TipoEquipo con los datos del deposito a actualizar</param>
        public void actualizarTipoEquipo(TipoEquipo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTipoEquipo");

            _manejador.agregarParametro(comando, "@descripcion", d.Descripcion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@obligatorio", d.Obligatorio, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@tipoequipo", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoEquipoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto TipoEquipo con los datos del deposito a eliminar</param>
        public void eliminarTipoEquipo(TipoEquipo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTipoEquipo");

            _manejador.agregarParametro(comando, "@tipoequipo", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoEquipoEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un deposito ya está registrado en el sistema.
        /// </summary>
        /// <param name="d">Objeto TipoEquipo con los datos del deposito</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarTipoEquipo(TipoEquipo d)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTipoEquipo");
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
                throw new Excepcion("ErrorVerificarTipoEquipo");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los depositos que tienen un determinado número de referencia o parte del mismo.
        /// </summary>
        /// <param name="r">Referencia o parte de la misma de los depositos que se listarán</param>
        /// <returns>Lista de depositos que cumplen con el criterio de búsqueda</returns>
        public BindingList<TipoEquipo> listarTipoEquipos(string r)
        {
            BindingList<TipoEquipo> depositos = new BindingList<TipoEquipo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTipoEquipos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descripcion", r, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string referencia = (string)datareader["Descripcion"];
                    bool obligatorio = (bool)datareader["Obligatorio"];


                    TipoEquipo deposito = new TipoEquipo(id: id, descripcion: referencia, obligatorio: obligatorio);

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
