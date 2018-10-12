using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects;

namespace DataLayer.Clases
{
   public class ManifiestoSucursalCargaDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManifiestoSucursalCargaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManifiestoSucursalCargaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManifiestoSucursalCargaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManifiestoSucursalCargaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo manifiesto de carga de un Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoSucursalCarga con los datos del nuevo manifiesto</param>
        public void agregarManifiestoSucursalCarga(ref ManifiestoSucursalCarga m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertManifiestoSucursal");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_adicional", m.Serie_Tula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@colaborador", m.Colaborador, SqlDbType.VarChar);


            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                m.Codigo = m.ID.ToString();
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoSucursalCargaRegistro");
            }

        }


       
        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoSucursalCarga con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoSucursalCarga(ref ManifiestoSucursalCarga m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoSucursal");

            _manejador.agregarParametro(comando, "@codigo", m.ID.ToString(), SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", m.Pedido, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoSucursalCargaActualizacion");
            }

        }

        /// <summary> - 
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado colaborador.
        /// </summary>
        /// <param name=" fecha">fecha de los manifiestos que se listarán</param>
        /// <param name=" colaborador">colaborador encargargado de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoSucursalCarga> listarManifiestosSucursalesCargasPorColaborador(DateTime fecha, Colaborador colaborador)
        {
            BindingList<ManifiestoSucursalCarga> manifiestos = new BindingList<ManifiestoSucursalCarga>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestoSucursalColaborador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", colaborador, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    ManifiestoSucursalCarga manifiesto = new ManifiestoSucursalCarga(id: id);

                    manifiestos.Add(manifiesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return manifiestos;
        }


        /// <summary>
        /// Eliminar los datos de un manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoSucursalCarga con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoSucursalCarga(ManifiestoSucursalCarga m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiestoCargaSucursal2");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoSucursalCargaEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un manifiesto de carga de una Sucursal ya fue registrado.
        /// </summary>
        /// <param name="m">Objeto ManifiestoSucursalCarga con los datos del manifiesto</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarManifiestoSucursalCarga(ref ManifiestoSucursalCarga m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiestSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", m.Serie_Tula, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    existe = id_encontrado != m.ID;

                    m.ID = id_encontrado;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManifiestoSucursalCargaDuplicado");
            }

            return existe;
        }



        /// <summary> - 
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoSucursalCarga> listarManifiestosSucursalesCargasPorCodigo(string c)
        {
            BindingList<ManifiestoSucursalCarga> manifiestos = new BindingList<ManifiestoSucursalCarga>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosSucursalesPorCodigo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    //string codigo = (string)datareader["Codigo"];
                    //BindingList<CommonObjects.Bolsa> bolsas = (BindingList<CommonObjects.Bolsa>)datareader["Serie_Tula"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    ManifiestoSucursalCarga manifiesto = new ManifiestoSucursalCarga(fecha, id: id);

                    manifiestos.Add(manifiesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return manifiestos;
        }





        #endregion Métodos Públicos

    }
}
