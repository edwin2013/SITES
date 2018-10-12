using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using CommonObjects;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;

namespace DataLayer.Clases
{
    public class BolsaPedidoBancoDL
    {
          #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static BolsaPedidoBancoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static BolsaPedidoBancoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new BolsaPedidoBancoDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

         #region Constructor

        public BolsaPedidoBancoDL() { }

        #endregion Constructor

         #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBlanco con los datos del cartucho</param>
        public void agregarBolsaCargaBancos(ref BolsaCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBolsaPedidoBanco");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad_asignada", c.Cantidad_asignada, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@carga", c.Movimiento, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@calidad", c.Calidad.ID, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorBolsaPedidoBancosRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de la bolsa de una carga de un Banco
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos de la bolsa</param>
        public void actualizarBolsaPedidoBancos(ref BolsaCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoCargaATM");

            _manejador.agregarParametro(comando, "@marchamo", c.Marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaATMActualizacion");
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas descargadas de un cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaPedidoBancos con los datos del cartucho</param>
        public void actualizarBolsaPedidoBancosCantidadDescarga(BolsaCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoCargaATMCantidadDescarga");

            _manejador.agregarParametro(comando, "@cantidad_descarga", c.Cantidad_descarga, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaATMActualizacion");
            }

        }

        /// <summary>
        /// Actualizar la cantidad de formulas cargadas del cartucho de una carga de un Banco.
        /// </summary>
        /// <param name="c">Objeto BolsaPedidoBancos con los datos del cartucho</param>
        public void actualizarBolsaPedidoBancosCantidad(BolsaCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaPedidoBancoCantidad");

            _manejador.agregarParametro(comando, "@anulado", c.Anulado, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@cantidad_carga", c.Cantidad_carga, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaATMActualizacion");
            }

        }

        /// <summary>
        /// Actualizar el cartucho asignado al cartucho de la carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto BolsaPedidoBancos con los datos del cartucho de la carga del ATM</param>
        public void actualizarBolsaPedidoBancosCartucho(BolsaCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoCartuchoCargaATM");

            _manejador.agregarParametro(comando, "@cartucho_carga", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cartucho", c.ID, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaATMActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un cartucho de una carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto BolsaPedidoBancos con los datos del cartucho</param>
        public void eliminarCartuchoCargaATM(BolsaCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCartuchoCargaATM");

            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaATMEliminacion");
            }

        }

        /// <summary>
        /// Obtener los cartuchos de una carga de una Sucursal.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void obtenerBolsaPedidoBanco(ref PedidoBancos c, bool a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectBolsasPedidoBanco");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@anulado", a, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["ID_Cartucho_Carga"];
                    double cantidad_asignada = (double)datareader["Cantidad_Asignada"];
                   // short cantidad_descarga = (short)datareader["Cantidad_Descarga"];
                    string marchamo = datareader["Marchamo"] as string;
                    bool anulado = (bool)datareader["Anulado"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    CalidadBilletes calidad = new CalidadBilletes();
                    
                    if (datareader["Calidad"] != DBNull.Value)
                    {
                       calidad.DB_ID = (int)datareader["Calidad"];
                       calidad.Nombre = (string)datareader["CalidadNombre"]; 
                    }


                    //string codigo = (string)datareader["Codigo"];
                    //string configuracion_diebold = (string)datareader["Configuracion_Diebold"];
                    //string configuracion_opteva = (string)datareader["Configuracion_Opteva"];
                    //byte? id_imagen = datareader["ID_Imagen"] as byte?;

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);


                    BolsaCargaBanco bolsa_carga = new BolsaCargaBanco(denominacion, id: id_cartucho_carga, marchamo: marchamo,
                                                                           movimiento: c,
                                                                            cantidad_asignada: cantidad_asignada,
                                                                            anulado: anulado,calidad:calidad);

                    c.agregarCartucho(bolsa_carga);
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
