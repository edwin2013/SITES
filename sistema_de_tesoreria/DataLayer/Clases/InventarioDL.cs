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
using CommonObjects;

namespace DataLayer
{
    public class InventarioDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static InventarioDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static InventarioDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new InventarioDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public InventarioDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void agregarInventario(Inventario g, Colaborador usuario)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInventarioCartuchos");

            _manejador.agregarParametro(comando, "@inicial", g.Inicial, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ingreso", g.Ingreso, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@total", g.Total, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@pedido", g.Pedido, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@reorden", g.Reorden, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@stock", g.Stock, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cantatm", g.CantATM, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cantcartuchos", g.CantCartuchos, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@periodomaximo", g.PeriodoMaximo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@periodoentrega", g.PeriodoEntrega, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@demanda", g.Demanda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@usuario", usuario, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tipo", g.Tipo, SqlDbType.TinyInt);

           try
            {
                g.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInventarioCartuchoRegistro");
            }

        }

        public void actualizarInventario(ref Inventario g, Colaborador usuario)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInventarioCartuchos");

            _manejador.agregarParametro(comando, "@id", g.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@inicial", g.Inicial, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ingreso", g.Ingreso, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@total", g.Total, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@pedido", g.Pedido, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@reorden", g.Reorden, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@stock", g.Stock, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cantatm", g.CantATM, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cantcartuchos", g.CantCartuchos, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@periodomaximo", g.PeriodoMaximo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@periodoentrega", g.PeriodoEntrega, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@demanda", g.Demanda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@usuario", usuario, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tipo", g.Tipo, SqlDbType.TinyInt);



            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFallaCartuchoActualizacion");
            }

        }

        public BindingList<Inventario> listarInventarioCartuchos()
        {
            BindingList<Inventario> inventarios = new BindingList<Inventario>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInventarioCartuchos");

            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    int inicial = (int)datareader["InventarioInicial"];
                    int ingreso = 0;// (int)datareader["InventarioIngreso"];
                    int total = (int)datareader["InventarioTotal"];
                    int pedido = (int)datareader["CantPedido"];
                    int reorden =(int)datareader["PuntoReorden"];
                    int stock = (int)datareader["Stock de Seguridad"];
                    int cantATMs = (int)datareader["CantidadATMs"];
                    int cantcart = (int)datareader["CantidadCartuchos"];
                    int permaximo = (int)datareader["PeriodoMaximo"];
                    int perentrega= (int)datareader["PeriodoEntrega"];
                    int demanda = (int)datareader["Demanda"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    
                    Inventario inventario = new Inventario(id: id, inicial: inicial,ingreso:ingreso, total:total,
                        pedido:pedido, reorden:reorden, stock:stock, cantATMs:cantATMs, cantcart:cantcart, permaximo:permaximo,
                        perentrega:perentrega, demanda:demanda, tipo:tipo);

                    inventarios.Add(inventario);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inventarios;
        }

        public bool verificarInventario(Inventario c)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteInventarioCartucho");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@id", c, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];
                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarFalla");
            }

             return existe;
        }

        public int seleccionarAlertasInventario(TiposCartucho c)
        {
            int pedido = 0;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInventarioCartuchosAlertas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tipo", c, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int cantidad = (int)datareader["Pedido"];
                    pedido = cantidad;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarFalla");
            }

             return pedido;
        }

       
        #endregion Métodos Públicos
    }
}
