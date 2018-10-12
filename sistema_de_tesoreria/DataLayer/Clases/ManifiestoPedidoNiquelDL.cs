using CommonObjects;
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
    public class ManifiestoPedidoNiquelDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManifiestoPedidoNiquelDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManifiestoPedidoNiquelDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManifiestoPedidoNiquelDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManifiestoPedidoNiquelDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo manifiesto de carga de un Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoNiquelPedido con los datos del nuevo manifiesto</param>
        public void agregarManifiestoPedidoNiquel(ref ManifiestoNiquelPedido m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertManifiestoPedidoNiquel");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@colaborador", m.Colaborador, SqlDbType.VarChar);


            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoPedidoNiquelRegistro");
            }

        }


       
        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoNiquelPedido con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoPedidoNiquel(ref ManifiestoNiquelPedido m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoPedidoNiquel");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", m.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", m.Pedido, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoPedidoNiquelActualizacion");
            }

        }

        /// <summary> - 
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado colaborador.
        /// </summary>
        /// <param name=" fecha">fecha de los manifiestos que se listarán</param>
        /// <param name=" colaborador">colaborador encargargado de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoNiquelPedido> listarManifiestosPedidoNiquelPorColaborador(DateTime fecha, Colaborador colaborador)
        {
            BindingList<ManifiestoNiquelPedido> manifiestos = new BindingList<ManifiestoNiquelPedido>();

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

                    ManifiestoNiquelPedido manifiesto = new ManifiestoNiquelPedido(id: id);

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
        /// <param name="m">Objeto ManifiestoNiquelPedido con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoPedidoNiquel(ManifiestoNiquelPedido m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiestoPedidoNiquel");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoPedidoNiquelEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un manifiesto de carga de una Sucursal ya fue registrado.
        /// </summary>
        /// <param name="m">Objeto ManifiestoNiquelPedido con los datos del manifiesto</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarManifiestoPedidoNiquel(ref ManifiestoNiquelPedido m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiestoNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);

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
                throw new Excepcion("ErrorVerificarManifiestoPedidoNiquelDuplicado");
            }

            return existe;
        }



        /// <summary> - 
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoNiquelPedido> listarManifiestosPedidoNiquelPorCodigo(string c)
        {
            BindingList<ManifiestoNiquelPedido> manifiestos = new BindingList<ManifiestoNiquelPedido>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosPedidoNiquelPorCodigo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string codigo = (string)datareader["Codigo"];
                    //BindingList<CommonObjects.Bolsa> bolsas = (BindingList<CommonObjects.Bolsa>)datareader["Serie_Tula"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    ManifiestoNiquelPedido manifiesto = new ManifiestoNiquelPedido(fecha, id, codigo);

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


        #region Cantidad Maxima Tulas y Bolsas

        /// <summary>
        /// Registrar un nueva maxima cantidad de 
        /// </summary>
        /// <param name="m">Objeto Maximas Cantidades con los datos de las cantidades</param>
        public void agregarMaximaCantidadTulas(ref MaximasCantidades m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertMaximasCantidades");

            _manejador.agregarParametro(comando, "@tulas", m.Tulas, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@bolsas", m.BolsasCompletas, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@empresa", m.EmpresaTransportadora, SqlDbType.TinyInt);


            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoPedidoNiquelRegistro");
            }

        }



        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoNiquelPedido con los datos del manifiesto a actualizar</param>
        public void actualizarMaximaCantidadTulas(ref MaximasCantidades m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateMaximasCantidades");

            _manejador.agregarParametro(comando, "@tulas", m.Tulas, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@bolsas", m.BolsasCompletas, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@empresa", m.EmpresaTransportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad", m.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoPedidoNiquelActualizacion");
            }

        }



        /// <summary>
        /// Elimina los datos de un manifiesto de carga de una Sucursal.
        /// </summary>
        /// <param name="m">Objeto ManifiestoNiquelPedido con los datos del manifiesto a actualizar</param>
        public void eliminarMaximaCantidadTulas(ref MaximasCantidades m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteMaximasCantidades");

            _manejador.agregarParametro(comando, "@cantidad", m.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoPedidoNiquelActualizacion");
            }

        }

        /// <summary> - 
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado colaborador.
        /// </summary>
        /// <param name=" fecha">fecha de los manifiestos que se listarán</param>
        /// <param name=" colaborador">colaborador encargargado de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<MaximasCantidades> listarMaximaCantidadTulas()
        {
            BindingList<MaximasCantidades> cantidades = new BindingList<MaximasCantidades>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectMaximasCantidades");
            SqlDataReader datareader = null;


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    int tulas = (int)datareader["Tulas"];
                    int bolsas = (int)datareader["Bolsas"];


                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre = (string)datareader["Nombre"];

                  
                    EmpresaTransporte empresa = new EmpresaTransporte(nombre, id: id_transportadora);

                    

                    MaximasCantidades cantidad = new MaximasCantidades(id: id, tulas: tulas, bolsas: bolsas, emp: empresa);

                    cantidades.Add(cantidad);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cantidades;
        }







        /// <summary> - 
        /// Obtener una lista de los manifiestos de cargas de Sucursales que tienen un determinado colaborador.
        /// </summary>
        /// <param name=" fecha">fecha de los manifiestos que se listarán</param>
        /// <param name=" colaborador">colaborador encargargado de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public MaximasCantidades obtenerMaximasCantidadTransportaodra(EmpresaTransporte empresa)
        {
           MaximasCantidades cantidades = new MaximasCantidades();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectMaximasCantidadesTransportadora");
            SqlDataReader datareader = null;


            try
            {
                _manejador.agregarParametro(comando, "transportadora", empresa.ID, SqlDbType.TinyInt);
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    int tulas = (int)datareader["Tulas"];
                    int bolsas = (int)datareader["Bolsas"];


                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre = (string)datareader["Nombre"];


                    EmpresaTransporte empresas = new EmpresaTransporte(nombre, id: id_transportadora);



                    cantidades = new MaximasCantidades(id: id, tulas: tulas, bolsas: bolsas, emp: empresas);

  
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cantidades;
        }

        #endregion Cantidad Maxima Tulas y Bolsas

        
        
        #endregion Métodos Públicos
    }
}
