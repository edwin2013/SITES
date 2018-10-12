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
    public class ManifiestoBancoPedidoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManifiestoBancoPedidoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManifiestoBancoPedidoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManifiestoBancoPedidoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManifiestoBancoPedidoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo manifiesto de carga de un Banco
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del nuevo manifiesto</param>
        public void agregarManifiestoBancoPedido(ref ManifiestoPedidoBanco m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertManifiestoBanco");

            //_manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            //_manejador.agregarParametro(comando, "@marchamo_adicional", m.Serie_Tula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha, SqlDbType.Date);


            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoSucursalCargaRegistro");
            }

        }
       
        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de un Banco.
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoBancoPedido(ManifiestoPedidoBanco m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoBanco");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_adicional", m.Serie_Tula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

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

        /// <summary>
        /// Eliminar los datos de un manifiesto de carga de un Banco.
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoBancoPedido(ManifiestoPedidoBanco m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiestoBanco");

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
        /// Verificar si un manifiesto de carga de un Banco ya fue registrado.
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del manifiesto</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarManifiestoBancoPedido(ref BolsaBanco m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiestoBanco");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", m.SerieBolsa, SqlDbType.VarChar);

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

        /// <summary>
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoPedidoBanco> listarManifiestosBancoPedidoPorCodigo(string c)
        {
            BindingList<ManifiestoPedidoBanco> manifiestos = new BindingList<ManifiestoPedidoBanco>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosBancosPorCodigo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    //string codigo = (string)datareader["Codigo"];
                    //string marchamo_adicional = (string)datareader["Serie_Tula"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    ManifiestoPedidoBanco manifiesto = new ManifiestoPedidoBanco(fecha:fecha,id:id);

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
        /// Actualizar los datos de un manifiesto de carga de un Banco.
        /// </summary>
        /// <param name="m">Objeto ManifiestoPedidoBanco con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoBancoPedidoPedido(ref  ManifiestoPedidoBanco manifiesto)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoBancoPedido");

            _manejador.agregarParametro(comando, "@manifiesto", manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", manifiesto.Pedido, SqlDbType.Int);


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

        #endregion Métodos Públicos
    }
}
