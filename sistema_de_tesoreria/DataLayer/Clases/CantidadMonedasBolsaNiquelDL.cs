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
    public class CantidadMonedasBolsaNiquelDL: ObjetoIndexado
    {
         #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CantidadMonedasBolsaNiquelDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CantidadMonedasBolsaNiquelDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CantidadMonedasBolsaNiquelDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

         #region Constructor

        public CantidadMonedasBolsaNiquelDL() { }

        #endregion Constructor

         #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBlanco con los datos del cartucho</param>
        public void agregarCantidadMonedasBolsaNiquels(ref CantidadMonedasBolsaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCantidadMonedasBolsaNiquel");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad", c.CantidadPiezas, SqlDbType.Int);
 

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
        /// <param name="c">Objeto CantidadMonedasBolsaNiquel con los datos de la bolsa</param>
        public void actualizarCantidadMonedasBolsaNiquel(ref CantidadMonedasBolsaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCantidadMonedasBolsaNiquel");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad", c.CantidadPiezas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@id", c.ID, SqlDbType.Int);

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
        public void eliminarCantidadMonedasBolsaNiquel(CantidadMonedasBolsaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCantidadMonedasBolsaNiquel");

            _manejador.agregarParametro(comando, "@id", c, SqlDbType.Int);

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
        public BindingList<CantidadMonedasBolsaNiquel> obtenerCantidadMonedasBolsaNiquel()
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCantidadMonedasBolsaNiquel");
            SqlDataReader datareader = null;
            BindingList<CantidadMonedasBolsaNiquel> _cantidades = new BindingList<CantidadMonedasBolsaNiquel>();

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["pk_ID"];
                    int cantidad = (int)datareader["Cantidad"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);


                    CantidadMonedasBolsaNiquel bolsa_carga = new CantidadMonedasBolsaNiquel(d: denominacion, id: id_cartucho_carga, cantidad:cantidad);

                    _cantidades.Add(bolsa_carga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }


            return _cantidades;

        }
                
        #endregion Métodos Públicos
    }
}
