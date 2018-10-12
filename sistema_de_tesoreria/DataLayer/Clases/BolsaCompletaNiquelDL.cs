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
    public class BolsaCompletaNiquelDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static BolsaCompletaNiquelDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static BolsaCompletaNiquelDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new BolsaCompletaNiquelDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public BolsaCompletaNiquelDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaCompletaNiquel con los datos del cartucho</param>
        public void agregarBolsaCompletaNiquel(ref BolsaCompletaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBolsaCompletaNiquel");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad_asignada", c.CantidadBolsas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_bolsa", c.TotalPiezas, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tipo", c.TipoBolsa , SqlDbType.Int);
            _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorBolsaCompletaNiquelRegistro");
            }

        }
        
        /// <summary>
        /// Actualizar los datos del cartucho de una carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto BolsaCompletaNiquel con los datos del cartucho</param>
        public void actualizarBolsaCompletaNiquel(ref BolsaCompletaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaCompletaNiquel");
            
            _manejador.agregarParametro(comando, "@cantidad_bolsas", c.CantidadBolsas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_total", c.TotalPiezas, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tipo_bolsas", c.TipoBolsa, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@bolsa", c.ID , SqlDbType.Int);


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
        /// <param name="c">Objeto BolsaCompletaNiquel con los datos del cartucho</param>
        public void eliminarBolsaMontoNiquel(BolsaCompletaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteMontoBolsaPedidoNiquel");

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
        public void obtenerBolsaMontoNiquel(ref ManifiestoNiquelPedido c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectBolsaCompletaNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", c.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["ID_Bolsa_Completa"];
                    int monto_total = Convert.ToInt32((decimal)datareader["Monto_Asignado"]);
                    int cantidad_asignada = (int)datareader["Cantidad_Bolsas"];
                    int tipo_bolsa = (int)datareader["Tipo_Bolsa"];
                    

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                  
                    
                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);


                    BolsaCompletaNiquel bolsa_carga = new BolsaCompletaNiquel(denominacion, id: id_cartucho_carga,
                                                                            cantidad_bolsas: cantidad_asignada, tipo_bolsa:tipo_bolsa,cantidad_piezas:monto_total);

                    c.agregarBolsaCompleta(bolsa_carga);
                }

                comando.Connection.Close();
            
            }
            catch (Exception){
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }





        /// <summary>
        /// Obtener los cartuchos de una carga de una Sucursal.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public BindingList<BolsaNiquel> listaBolsasNiquelEntrega(DateTime fecha, EmpresaTransporte transportadora)
        {

            BindingList<BolsaNiquel> c = new BindingList<BolsaNiquel>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEntregaBolsasNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@transportadora", transportadora, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_bolsa = (int)datareader["ID_Bolsa"];
                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];
                    string tula = (string)datareader["Serie_Bolsa"];

                    Cliente cliente = new Cliente();
                    cliente.Nombre = nombre_cliente;
                 

                    PuntoVenta punto = new PuntoVenta(nombre: nombre_punto_venta,id:id_punto_venta);
                    BolsaNiquel bolsa = new BolsaNiquel(serie: tula, id: id_bolsa);
                    bolsa.PuntoVenta = punto;
                    punto.Cliente = cliente;

                    
                    c.Add(bolsa);
                }

                
                comando.Connection.Close();
                return c;

            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }



        /// <summary>
        /// Lista las bolsas completas de un determinado día
        /// </summary>
        /// <param name="fecha">Fecha del pedido</param>
        /// <param name="transportadora">Transportadora por la cual se enviarán las bolsas</param>
        /// <returns>Una lista de bolsas de monedas</returns>
        public BindingList<BolsaCompletaNiquel> listarBolsasCompletasNiquelEntrega(DateTime fecha, EmpresaTransporte transportadora)
        {
            BindingList<BolsaCompletaNiquel> _bolsas = new BindingList<BolsaCompletaNiquel>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEntregaBolsasCompletasNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@transportadora", transportadora, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["ID_Bolsa_Completa"];
                    int monto_total = Convert.ToInt32((decimal)datareader["Monto_Asignado"]);
                    int cantidad_asignada = (int)datareader["Cantidad_Bolsas"];
                    int tipo_bolsa = (int)datareader["Tipo_Bolsa"];

                    short id_puntoventa = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_PuntoVenta"];

                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    PuntoVenta punto = new PuntoVenta(id: id_puntoventa, nombre: nombre_punto_venta);
                    Cliente cliente = new Cliente();
                    cliente.Nombre = nombre_cliente;

                    punto.Cliente = cliente;
                    
                                                                                                                                                                                                                                                                                                                   
                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];


                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);


                    BolsaCompletaNiquel bolsa_carga = new BolsaCompletaNiquel(denominacion, id: id_cartucho_carga,
                                                                            cantidad_bolsas: cantidad_asignada, tipo_bolsa: tipo_bolsa, cantidad_piezas: monto_total);

                    bolsa_carga.PuntoVenta = punto;

                     

                    _bolsas.Add(bolsa_carga);
                }

               
                comando.Connection.Close();

                return _bolsas;
                    
                   

            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

  
        }


        /// <summary>
        /// Actualiza los datos de entrega de tulas 
        /// </summary>
        /// <param name="b">Objeto BolsaNiquel con los datos de la bolsa</param>
        public void actualizarBolsaNiquelEntregas(BolsaNiquel b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaNiquelEntrega");

            _manejador.agregarParametro(comando, "@usuario", b.ColaboradorEntrega, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_entrega", b.FechaEntrega, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@bolsa", b.ID, SqlDbType.Int);


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
        /// Actualiza los datos de entrega de tulas 
        /// </summary>
        /// <param name="b">Objeto BolsaNiquel con los datos de la bolsa</param>
        public void actualizarBolsasCompletasNiquelEntrega(BolsaCompletaNiquel b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaCompletaNiquelEntrega");

            _manejador.agregarParametro(comando, "@usuario", b.Receptor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_entrega", b.FechaEntrega, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@bolsa", b.ID, SqlDbType.Int);


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
                
        #endregion Métodos Públicos
    }
}
