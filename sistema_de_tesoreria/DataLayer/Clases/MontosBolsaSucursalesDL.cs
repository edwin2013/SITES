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
    public class MontosBolsaSucursalesDL
    {

         #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static MontosBolsaSucursalesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static MontosBolsaSucursalesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MontosBolsaSucursalesDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

         #region Constructor

        public MontosBolsaSucursalesDL() { }

        #endregion Constructor

         #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaMontosSucursales con los datos del cartucho</param>
        public void agregarBolsaMontosSucursales(ref BolsaMontosSucursales c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBolsaMontosSucursales");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad_asignada", c.Cantidad_asignada, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@bolsa", c.ID_Bolsa , SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorBolsaMontosSucursalesRegistro");
            }

        }
        
        /// <summary>
        /// Actualizar los datos del cartucho de una carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto BolsaMontosSucursales con los datos del cartucho</param>
        public void actualizarBolsaMontosSucursales(ref BolsaMontosSucursales c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaMontosSucursales");
            
            _manejador.agregarParametro(comando, "@monto", c.Cantidad_asignada, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

  

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
        /// Eliminar los datos de un cartucho de una carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto BolsaMontosSucursales con los datos del cartucho</param>
        public void eliminarBolsaMontoSucursal(BolsaMontosSucursales c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteMontoBolsaSucursal");

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
        public void obtenerBolsaMontoSucursales(ref Bolsa c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectBolsaMontosSucursales");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@bolsa", c.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["ID_Cartucho_Carga"];
                    Decimal cantidad_asignada = (Decimal)datareader["Monto_Asignado"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                  

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);


                    BolsaMontosSucursales bolsa_carga = new BolsaMontosSucursales(denominacion, id: id_cartucho_carga,
                                                                            cantidad_asignada: cantidad_asignada);

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
