//
//  @ Project : 
//  @ File Name : DepositosDL.cs
//  @ Date : 07/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los depositos.
    /// </summary>
    public class DepositosDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static DepositosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static DepositosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new DepositosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public DepositosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito</param>
        public void agregarDeposito(ref Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDeposito");

            _manejador.agregarParametro(comando, "@referencia", d.Referencia, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@monto", d.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", d.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cuenta", d.Cuenta, SqlDbType.BigInt);

            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito a actualizar</param>
        public void actualizarDeposito(Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDeposito");

            _manejador.agregarParametro(comando, "@referencia", d.Referencia, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@monto", d.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", d.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cuenta", d.Cuenta, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@deposito", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito a eliminar</param>
        public void eliminarDeposito(Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteDeposito");

            _manejador.agregarParametro(comando, "@deposito", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un deposito ya está registrado en el sistema.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarDeposito(Deposito d)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteDeposito");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@referencia", d.Referencia, SqlDbType.BigInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != d.ID;

                    d.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarDeposito");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los depositos que tienen un determinado número de referencia o parte del mismo.
        /// </summary>
        /// <param name="r">Referencia o parte de la misma de los depositos que se listarán</param>
        /// <returns>Lista de depositos que cumplen con el criterio de búsqueda</returns>
        public BindingList<Deposito> listarDepositosPorReferencia(int r)
        {
            BindingList<Deposito> depositos = new BindingList<Deposito>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDepositosReferencia");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@referencia", r, SqlDbType.BigInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Deposito"];
                    long referencia = (long)datareader["Referencia"];
                    decimal monto = (decimal)datareader["Monto"];
                    long cuenta = (long)datareader["Cuenta"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    Deposito deposito = new Deposito(referencia, id: id, monto: monto, moneda: moneda, cuenta: cuenta);

                    depositos.Add(deposito);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return depositos;
        }


        #region Cuarde Depósitos

        /// <summary>
        /// Permite consultar el cuadre de depósitos de un día
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del Cliente</param>
        /// <param name="p">Objeto PuntoVenta con los datos del punto de venta</param>
        /// <param name="f">Fecha del cuadre</param>
        /// <returns>Una lista de cuadres por cuenta de la fecha seleccionada</returns>
        public BindingList<CuadreDeposito> listarCuadreDepositos(Cliente c, PuntoVenta p, DateTime f)
        {
            BindingList<CuadreDeposito> cargas = new BindingList<CuadreDeposito>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCuadreAcreditacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    //int id_carga = (int)datareader["pk_ID"];
                    string cuenta = (string)datareader["Cuenta"];
                    //string deposito = (string)datareader["Deposito"];
                    PuntoVenta punto_venta = null;
                    int moneda = (int)datareader["Moneda"];
                    Monedas moneda_moneda = (Monedas)moneda;
                    //if (datareader["ID_PuntoVenta"] != DBNull.Value)
                    //{
                    //    short id_punto_venta = (short)datareader["ID_PuntoVenta"];
                    //    string nombre = (string)datareader["Nombre_PuntoVenta"];


                    //    punto_venta = new PuntoVenta(id: id_punto_venta, nombre:nombre);
                    //}

                    
                    Decimal monto_fisico = 0;
                    Decimal monto_ibs = 0;
                    if(datareader["Monto_Fisico"] != DBNull.Value)
                        monto_fisico = (Decimal)datareader["Monto_Fisico"];

                    if(datareader["Monto_IBS"] != DBNull.Value)
                        monto_ibs = (Decimal)datareader["Monto_IBS"];
                    //Decimal monto_macro = (Decimal)datareader["Monto_Macro"];



                    CuadreDeposito carga = new CuadreDeposito(cuenta: cuenta, monto_fisico: monto_fisico, monto_ibs: monto_ibs, f: f, m: moneda_moneda);



                    cargas.Add(carga);
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cargas;
        }



        /// <summary>
        /// Permite consultar el cuadre de depósitos de un día
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del Cliente</param>
        /// <param name="p">Objeto PuntoVenta con los datos del punto de venta</param>
        /// <param name="f">Fecha del cuadre</param>
        /// <returns>Una lista de cuadres por cuenta de la fecha seleccionada</returns>
        public BindingList<CuadreDeposito> listarCuadreDepositosBD(Cliente c, PuntoVenta p, DateTime f)
        {
            BindingList<CuadreDeposito> cargas = new BindingList<CuadreDeposito>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCuadreAcreditacionBD");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    //int id_carga = (int)datareader["pk_ID"];
                    string cuenta = (string)datareader["Cuenta"];
                    //string deposito = (string)datareader["Deposito"];
                    PuntoVenta punto_venta = null;

                    Monedas moneda_moneda = (Monedas)datareader["Moneda"]; 
                    //if (datareader["ID_PuntoVenta"] != DBNull.Value)
                    //{
                    //    short id_punto_venta = (short)datareader["ID_PuntoVenta"];
                    //    string nombre = (string)datareader["Nombre_PuntoVenta"];


                    //    punto_venta = new PuntoVenta(id: id_punto_venta, nombre:nombre);
                    //}

                    Decimal monto_fisico = (Decimal)datareader["Monto_Fisico"];
                    Decimal monto_ibs = (Decimal)datareader["Monto_IBS"];
                    //Decimal monto_macro = (Decimal)datareader["Monto_Macro"];



                    CuadreDeposito carga = new CuadreDeposito(cuenta: cuenta, monto_fisico: monto_fisico, monto_ibs: monto_ibs, f: f, m:moneda_moneda);



                    cargas.Add(carga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cargas;
        }


        /// <summary>
        /// Inserta o actualiza un cuadre de depósito
        /// </summary>
        /// <param name="d">Objeto CuadreDeposito con los datos del cuadre</param>
        public void agregarCuadreDeposito(ref CuadreDeposito d, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCuadreDeposito");

            _manejador.agregarParametro(comando, "@cuenta", d.Cuenta, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@moneda", d.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@monto_fisico", d.MontoFisico, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_macro", d.MontoMacro, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_ibs", d.MontoIBS, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@fecha", d.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoRegistro");
            }

        }


        #endregion Cuadre Depósitos


        #endregion Métodos Públicos

    }

}
