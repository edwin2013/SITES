//
//  @ Project : 
//  @ File Name : CartuchosCargasATMsDL.cs
//  @ Date : 22/05/2012
//  @ Author : Erick Chavarría 
//  

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    public class CartuchosCargasATMsDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CartuchosCargasATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CartuchosCargasATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CartuchosCargasATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CartuchosCargasATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void agregarCartuchoCargaATM(ref CartuchoCargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCartuchoCargaATM");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad_asignada", c.Cantidad_asignada, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@carga", c.Movimiento, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos del cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void actualizarCartuchoCargaATM(CartuchoCargaATM c)
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
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void actualizarCartuchoCargaATMCantidadDescarga(CartuchoCargaATM c)
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
        /// Actualizar la cantidad de formulas cargadas del cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void actualizarCartuchoCargaATMCantidad(CartuchoCargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoCargaATMCantidad");

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
        /// Actualizar el cartucho asignado al cartucho de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho de la carga del ATM</param>
        public void actualizarCartuchoCargaATMCartucho(CartuchoCargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoCartuchoCargaATM");

            _manejador.agregarParametro(comando, "@cartucho_carga", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cartucho", c.Cartucho, SqlDbType.Int);

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
        /// Eliminar los datos de un cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void eliminarCartuchoCargaATM(CartuchoCargaATM c)
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
        /// Obtener los cartuchos de una carga de un ATM.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void obtenerCartuchosCargaATM(ref CargaATM c, bool a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCartuchosCargaATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@anulado", a, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["ID_Cartucho_Carga"];
                    short cantidad_asignada = (short)datareader["Cantidad_Asignada"];
                    short cantidad_carga = (short)datareader["Cantidad_Carga"];
                    short cantidad_descarga = (short)datareader["Cantidad_Descarga"];
                    string marchamo = datareader["Marchamo"] as string;
                    bool anulado = (bool)datareader["Anulado"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    string codigo = (string)datareader["Codigo"];
                    string configuracion_diebold = (string)datareader["Configuracion_Diebold"];
                    string configuracion_opteva = (string)datareader["Configuracion_Opteva"];
                    byte? id_imagen = datareader["ID_Imagen"] as byte?;

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda, codigo: codigo,
                                                                 id_imagen: id_imagen, configuracion_diebold: configuracion_diebold,
                                                                 configuracion_opteva: configuracion_opteva);

                    Cartucho cartucho = null;

                    if (datareader["ID_Cartucho"] != DBNull.Value)
                    {
                        int id_cartucho = (int)datareader["ID_Cartucho"];
                        string numero = (string)datareader["Numero"];
                        TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];

                        cartucho = new Cartucho(numero, id: id_cartucho, denominacion: denominacion, tipo: tipo);
                    }

                    CartuchoCargaATM cartucho_carga = new CartuchoCargaATM(denominacion, id: id_cartucho_carga, marchamo: marchamo,
                                                                           movimiento: c, cantidad_descarga: cantidad_descarga, 
                                                                           cantidad_carga: cantidad_carga, cantidad_asignada: cantidad_asignada, 
                                                                           cartucho: cartucho, anulado: anulado);

                    c.agregarCartucho(cartucho_carga);
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
