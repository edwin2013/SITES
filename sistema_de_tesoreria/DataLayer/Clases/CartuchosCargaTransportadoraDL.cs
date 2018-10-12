using CommonObjects;
using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class CartuchosCargaTransportadoraDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CartuchosCargaTransportadoraDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CartuchosCargaTransportadoraDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CartuchosCargaTransportadoraDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

         #region Constructor

        public CartuchosCargaTransportadoraDL() { }

        #endregion Constructor

         #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaTransportadoraes con los datos del cartucho</param>
        public void agregarCartuchoCargaTransportadoraes(ref CartuchoCargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCartuchoCargaTransportadora");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad_asignada", c.Cantidad_asignada, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@carga", c.Movimiento , SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c.Comentario, SqlDbType.NVarChar);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaTransportadoraRegistro");
            }

        }
        
        /// <summary>
        /// Actualizar los datos del cartucho de una carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaTransportadora con los datos del cartucho</param>
        public void actualizarCartuchoCargaTransportadora(ref CartuchoCargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoCargaTransportadora");
            
            _manejador.agregarParametro(comando, "@marchamo", c.Marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c.Comentario, SqlDbType.NVarChar);
  

            try
            {
                _manejador.ejecutarEscalar(comando);
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
        /// <param name="c">Objeto CartuchoCargaTransportadora con los datos del cartucho</param>
        public void actualizarCartuchoCargaTransportadoraCantidadDescarga(CartuchoCargaTransportadora c)
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
        /// Actualizar la cantidad de formulas cargadas del cartucho de una carga de una Sucrusal.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaTransportadora con los datos del cartucho</param>
        public void actualizarCartuchoCargaTransportadoraCantidad(CartuchoCargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoCargaTrasportadoraCantidad");

            _manejador.agregarParametro(comando, "@anulado", c.Anulado, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@cantidad_carga", c.Cantidad_carga, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c.Comentario, SqlDbType.NVarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaTransportadoraesActualizacion");
            }

        }

        /// <summary>
        /// Actualizar el cartucho asignado al cartucho de la carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaTransportadora con los datos del cartucho de la carga del ATM</param>
        public void actualizarCartuchoCargaTransportadoraCartucho(CartuchoCargaTransportadora c)
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
        /// <param name="c">Objeto CartuchoCargaTransportadora con los datos del cartucho</param>
        public void eliminarCartuchoCargaATM(CartuchoCargaTransportadora c)
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
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void obtenerCartuchosCargaTransportadora(ref CargaTransportadora c, bool a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCartuchoCargaTransportadora");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@anulado", a, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["ID_Cartucho_Carga"];
                    double cantidad_asignada = (double)datareader["Cantidad_Asignada"];
                    string marchamo = datareader["Marchamo"] as string;
                    bool anulado = (bool)datareader["Anulado"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                  

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);


                    CartuchoCargaTransportadora bolsa_carga = new CartuchoCargaTransportadora(denominacion, id: id_cartucho_carga, marchamo: marchamo,
                                                                           movimiento: c,
                                                                            cantidad_asignada: cantidad_asignada,
                                                                            anulado: anulado);

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
