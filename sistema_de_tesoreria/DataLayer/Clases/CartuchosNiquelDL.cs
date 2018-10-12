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
    public class CartuchosNiquelDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CartuchosNiquelDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CartuchosNiquelDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CartuchosNiquelDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

         #region Constructor

        public CartuchosNiquelDL() { }

        #endregion Constructor

         #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto CartuchosNiqueles con los datos del cartucho</param>
        public void agregarCartuchosNiqueles(ref CartuchosNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCartuchosNiquel");

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
                throw new Excepcion("ErrorCartuchosNiquelRegistro");
            }

        }
        
        /// <summary>
        /// Actualizar los datos del cartucho de una carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CartuchosNiquel con los datos del cartucho</param>
        public void actualizarCartuchosNiquel(ref CartuchosNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoPedidoNiquel");
            
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);
            if(c.Monto_carga != 0)
                _manejador.agregarParametro(comando, "@cantidad", c.Monto_carga / c.Denominacion.Valor, SqlDbType.Int);
            else
                _manejador.agregarParametro(comando, "@cantidad", c.Monto_asignado / c.Denominacion.Valor, SqlDbType.Int);
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
        /// Actualizar la cantidad de formulas cargadas del cartucho de una carga de una Sucrusal.
        /// </summary>
        /// <param name="c">Objeto CartuchosNiquel con los datos del cartucho</param>
        public void actualizarCartuchosNiquelCantidad(CartuchosNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchosNiquelCantidad");

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
                throw new Excepcion("ErrorCartuchosNiquelesActualizacion");
            }

        }

       
        /// <summary>
        /// Eliminar los datos de un cartucho de una carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto CartuchosNiquel con los datos del cartucho</param>
        public void eliminarCartuchoCargaATM(CartuchosNiquel c)
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
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void obtenerCartuchosPedidoNiquel(ref PedidoNiquel c, bool a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCartuchosNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@anulado", a, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["ID_Cartucho_Carga"];

                    decimal cantidad_asignadan = (decimal)datareader["Cantidad_Asignada"];


                    double cantidad_asignada = (double)cantidad_asignadan;
                    bool anulado = (bool)datareader["Anulado"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    bool es_moneda = (bool)datareader["EsMoneda"];
                  

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda, esmoneda:es_moneda);


                    CartuchosNiquel bolsa_carga = new CartuchosNiquel(denominacion, id: id_cartucho_carga,
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
