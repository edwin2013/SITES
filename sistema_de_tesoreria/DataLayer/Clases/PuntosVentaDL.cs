//
//  @ Project : 
//  @ File Name : PuntosVentaDL.cs
//  @ Date : 02/09/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los puntos de venta de los clientes.
    /// </summary>
    public class PuntosVentaDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PuntosVentaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PuntosVentaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PuntosVentaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PuntosVentaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public DataTable obtenerPuntosVentaClienteDT(string idCliente)
        {
            DataTable dt = new DataTable();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPuntosVentaCliente");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@cliente", idCliente, SqlDbType.Int);
            try
            {
                comando.Connection.Open();
                datareader = comando.ExecuteReader();
                dt.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void agregarPuntoVenta(ref PuntoVenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPuntoVenta");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cliente", p.Cliente.Id, SqlDbType.Int);

            try
            {
                p.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void actualizarPuntoVenta(PuntoVenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePuntoVenta");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@entrega_niquel", p.EntregaNiquel, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_regular", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_feriado", p.TarifaFeriado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@moneda_regular", p.MonedaTarifaRegular, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_recargo", p.MonedaRecargo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tope", p.MonedaTope, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_entrega_niquel", p.MonedaEntregaNiquel, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_feriado", p.MonedaTarifaFeriados ,SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tope", p.Tope, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@centro_costos", p.CentroCostos, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@procesamiento", p.Procesado, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@comision", p.MComision, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@punto_venta", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta a eliminar</param>
        public void eliminarPuntoVenta(PuntoVenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePuntoVenta");

            _manejador.agregarParametro(comando, "@punto_venta", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }

        /// <summary>
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public void obtenerPuntosVentaCliente(ref Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPuntosVentaCliente");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    decimal comision = 0;
                    decimal tarifaregular = 0;
                    if(datareader["TarifaRegular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["TarifaRegular"];

                    decimal tarifaferiado = 0;

                    if (datareader["TarifaFeriado"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["TarifaFeriado"];


                    decimal tope = 0;

                    if (datareader["Tope"] != DBNull.Value)
                        tope = (decimal)datareader["Tope"];


                    decimal recargo = 0;

                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Recargo"];


                    decimal entrega_niquel = 0;

                    if (datareader["EntregaNiquel"] != DBNull.Value)
                        entrega_niquel = (decimal)datareader["EntregaNiquel"];



                    string centrocosto = "";

                    if (datareader["CentroCostos"] != DBNull.Value)
                        centrocosto = (string)datareader["CentroCostos"];


                    Monedas moneda = Monedas.Colones;

                    if (datareader["MonedaTarifa"] != DBNull.Value)
                        moneda = (Monedas)datareader["MonedaTarifa"];

                    Monedas moneda_feriado = Monedas.Colones;

                    if (datareader["MonedaFeriado"] != DBNull.Value)
                        moneda_feriado = (Monedas)datareader["MonedaTarifa"];


                    Monedas moneda_entrega_niquel = Monedas.Colones;

                    if (datareader["MonedaEntregaNiquel"] != DBNull.Value)
                        moneda_entrega_niquel = (Monedas)datareader["MonedaEntregaNiquel"];

                    Monedas moneda_tope = Monedas.Colones;

                    if (datareader["MonedaTope"] != DBNull.Value)
                        moneda_tope = (Monedas)datareader["MonedaTope"];

                    Monedas moneda_recargo = Monedas.Colones;

                    if (datareader["MonedaRecargo"] != DBNull.Value)
                        moneda_recargo = (Monedas)datareader["MonedaRecargo"];


                    bool procesamiento = false;

                    if (datareader["Procesamiento"] != DBNull.Value)
                        procesamiento = (bool)datareader["Procesamiento"];

                    if (datareader["ComisionNiquel"] != DBNull.Value)
                        comision = (decimal)datareader["ComisionNiquel"];

                    PuntoVenta punto = new PuntoVenta(id, nombre, c);
                    punto.MonedaTarifaFeriados = moneda_feriado;
                    punto.MonedaTarifaRegular = moneda;
                    punto.CentroCostos = centrocosto;
                    punto.TarifaFeriado = tarifaferiado;
                    punto.TarifaRegular = tarifaregular;
                    punto.Tope = tope;
                    punto.Recargo = recargo;
                    punto.EntregaNiquel = entrega_niquel;
                    punto.MonedaEntregaNiquel = moneda_entrega_niquel;
                    punto.MonedaRecargo = moneda_recargo;
                    punto.MonedaTope = moneda_tope;
                    punto.Procesado = procesamiento;
                    punto.MComision = comision;

                    c.agregarPuntoVenta(punto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        /// <summary>
        /// Obtiene los datos del punto de venta
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos del punto de venta</param>
        public void obtenerDatosPuntoVenta(ref PuntoVenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosPuntoVenta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@punto_venta", p.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    decimal tarifaregular = 0;
                    if (datareader["TarifaRegular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["TarifaRegular"];

                    decimal tarifaferiado = 0;

                    if (datareader["TarifaFeriado"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["TarifaFeriado"];


                    decimal tope = 0;

                    if (datareader["Tope"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["Tope"];


                    decimal recargo = 0;

                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Recargo"];


                    decimal entrega_niquel = 0;

                    if (datareader["EntregaNiquel"] != DBNull.Value)
                        entrega_niquel = (decimal)datareader["EntregaNiquel"];



                    string centrocosto = "";

                    if (datareader["CentroCostos"] != DBNull.Value)
                        centrocosto = (string)datareader["CentroCostos"];


                    Monedas moneda = Monedas.Colones;

                    if (datareader["MonedaTarifa"] != DBNull.Value)
                        moneda = (Monedas)datareader["MonedaTarifa"];

                    Monedas moneda_feriado = Monedas.Colones;

                    if (datareader["MonedaFeriado"] != DBNull.Value)
                        moneda_feriado = (Monedas)datareader["MonedaTarifa"];

                    bool procesamiento = false;

                    if (datareader["Procesamiento"] != DBNull.Value)
                        procesamiento = (bool)datareader["Procesamiento"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];
                    string contacto = (string)datareader["Contacto"];
                    Contratos_Transporte contrato_transporte = (Contratos_Transporte)datareader["Contrato_Transporte"];
                    bool solicitud_remesas = (bool)datareader["Solicitud_Remesas"];

                    Cliente cliente = new Cliente(id_cliente, nombre_cliente, contrato_transporte, solicitud_remesas, contacto);



                    p.Nombre = nombre;
                    p.MonedaTarifaFeriados = moneda_feriado;
                    p.MonedaTarifaRegular = moneda;
                    p.CentroCostos = centrocosto;
                    p.TarifaFeriado = tarifaferiado;
                    p.TarifaRegular = tarifaregular;
                    p.Tope = tope;
                    p.Recargo = recargo;
                    p.EntregaNiquel = entrega_niquel;
                    p.Cliente = cliente;
                    p.Procesado = procesamiento;
                    


                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
        }


        #region Tarifas Transportadora

        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void agregarTarifaTransportadora(ref TarifaPuntoVentaTransportadora p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTarifaTransportadora");

            _manejador.agregarParametro(comando, "@entrega_niquel", p.TarifaNiquel, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_regular", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_feriado", p.TarifaFeriados, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tope", p.Tope, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@punto_venta", p.PuntoVenta.Id, SqlDbType.SmallInt);
            //_manejador.agregarParametro(comando, "@cliente", p.Cliente.Id , SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", p.EmpresaTransporte.ID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@moneda_tarifa_regular", p.MonedaTarifaRegular, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tarifa_feriado", p.MonedaTarifaFeriado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tope", p.MonedaTope, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_recargo", p.MonedaRecargo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_entrega_niquel", p.MonedaTarifaNiquel, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tarifa_feriado_menudo", p.TarifaFeriadoDomingosMenudo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@moneda_feriado_menudo", p.MonedaFeriadosDomingosMenudo, SqlDbType.TinyInt);

            try
            {
                p.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }


        /// <summary>
        /// Valida si una tarifa de un punto existe
        /// </summary>
        /// <param name="t">Objeto TarifaPuntoVentaTransportadora con los datos de la tarifa</param>
        /// <returns></returns>
        public bool verificarTarifaTransportadora(ref TarifaPuntoVentaTransportadora t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTarifaTransportadora");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@transportadora", t.EmpresaTransporte.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto", t.PuntoVenta.Id, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != t.ID;

                    t.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarATMDuplicado");
            }

            return existe;
 
        }





       

        /// <summary>
        /// Actualizar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void actualizarTarifaTransportadora(TarifaPuntoVentaTransportadora p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTarifaTransportadora");

            _manejador.agregarParametro(comando, "@entrega_niquel", p.TarifaNiquel, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_regular", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_feriado", p.TarifaFeriados, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tope", p.Tope, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@punto_venta", p.PuntoVenta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", p.EmpresaTransporte.ID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@moneda_tarifa_regular", p.MonedaTarifaRegular, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tarifa_feriado", p.MonedaTarifaFeriado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tope", p.MonedaTope, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_recargo", p.MonedaRecargo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_entrega_niquel", p.MonedaTarifaNiquel, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tarifa_feriado_menudo", p.TarifaFeriadoDomingosMenudo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@moneda_feriado_menudo", p.MonedaFeriadosDomingosMenudo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@id", p.ID, SqlDbType.Int);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta a eliminar</param>
        public void eliminarTarifaTransportadora(TarifaPuntoVentaTransportadora p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTarifaTransportadora");

            _manejador.agregarParametro(comando, "@tarifa", p.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorActualizacionTarifasTransportadoras");
            }

        }

        /// <summary>
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public void obtenerTarifaTransportadoraCliente(ref Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTarifaTransportadoraCliente");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_tarifa = (int)datareader["ID_Tarifa"];

                    short id = (short)datareader["ID_Punto"];
                    string nombre = (string)datareader["Nombre_Punto"];


                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                    decimal tarifaregular = 0;
                    if (datareader["TarifaRegular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["TarifaRegular"];

                    decimal tarifaferiado = 0;

                    if (datareader["Tarifa_Feriados"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["Tarifa_Feriados"];


                    decimal tope = 0;

                    if (datareader["Tope"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["Tope"];


                    decimal recargo = 0;

                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Recargo"];


                    decimal entrega_niquel = 0;

                    if (datareader["EntregaNiquel"] != DBNull.Value)
                        entrega_niquel = (decimal)datareader["EntregaNiquel"];






                    Monedas moneda_regular = Monedas.Colones;

                    if (datareader["Moneda_Tarifa_Regular"] != DBNull.Value)
                        moneda_regular = (Monedas)datareader["Moneda_Tarifa_Regular"];


                    Monedas moneda_feriados = Monedas.Colones;

                    if (datareader["Moneda_Tarifa_Feriado"] != DBNull.Value)
                        moneda_feriados = (Monedas)datareader["Moneda_Tarifa_Feriado"];



                    Monedas moneda_niquel = Monedas.Colones;

                    if (datareader["Moneda_Entrega_Niquel"] != DBNull.Value)
                        moneda_niquel = (Monedas)datareader["Moneda_Entrega_Niquel"];


                    Monedas moneda_tope = Monedas.Colones;

                    if (datareader["Moneda_Tope"] != DBNull.Value)
                        moneda_tope = (Monedas)datareader["Moneda_Tope"];


                    Monedas moneda_recargo = Monedas.Colones;

                    if (datareader["Moneda_Recargo"] != DBNull.Value)
                        moneda_recargo = (Monedas)datareader["Moneda_Recargo"];


                    Monedas moneda_feriado_menudo = Monedas.Colones;

                    if (datareader["Moneda_Feriados_Menudo"] != DBNull.Value)
                        moneda_feriado_menudo = (Monedas)datareader["Moneda_Feriados_Menudo"];



                    decimal tarifa_feriado_menudo = 0;

                    if (datareader["Tarifa_Feriados_Menudo"] != DBNull.Value)
                        tarifa_feriado_menudo = (decimal)datareader["Tarifa_Feriados_Menudo"];






                    PuntoVenta punto = new PuntoVenta(id, nombre, c);

                    TarifaPuntoVentaTransportadora tarifa = new TarifaPuntoVentaTransportadora(id: id_tarifa, punto: punto, tarifaregular: tarifaregular, tarifaferiados: tarifaferiado, tarifaniquel: entrega_niquel, tope: tope, recargo: recargo, tarifaferiadomenudo: tarifa_feriado_menudo, monedaferiadomenudo: moneda_feriado_menudo);

                    c.agregarTarifaTransportadora(tarifa);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public void obtenerTarifaTransportadoraPuntoVenta(ref PuntoVenta c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTarifaTransportadoraPuntoVenta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@punto_venta", c.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_tarifa = (int)datareader["ID_Tarifa"];

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                    EmpresaTransporte transportadora = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);

                    decimal tarifaregular = 0;
                    if (datareader["Tarifa_Regular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["Tarifa_Regular"];

                    decimal tarifaferiado = 0;

                    if (datareader["Tarifa_Feriados"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["Tarifa_Feriados"];


                    decimal tope = 0;

                    if (datareader["Tope"] != DBNull.Value)
                        tope = (decimal)datareader["Tope"];


                    decimal recargo = 0;

                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Recargo"];


                    decimal entrega_niquel = 0;

                    if (datareader["Tarifa_Niquel"] != DBNull.Value)
                        entrega_niquel = (decimal)datareader["Tarifa_Niquel"];


                    Monedas moneda_feriado_menudo = Monedas.Colones;

                    if (datareader["Moneda_Feriados_Menudo"] != DBNull.Value)
                        moneda_feriado_menudo = (Monedas)datareader["Moneda_Feriados_Menudo"];



                    decimal tarifa_feriado_menudo = 0;

                    if (datareader["Tarifa_Feriados_Menudo"] != DBNull.Value)
                        tarifa_feriado_menudo = (decimal)datareader["Tarifa_Feriados_Menudo"];


                    TarifaPuntoVentaTransportadora tarifa = new TarifaPuntoVentaTransportadora(id: id_tarifa, tarifaregular: tarifaregular, tarifaferiados: tarifaferiado, tarifaniquel: entrega_niquel, tope: tope, recargo: recargo, transportadora: transportadora, punto: c, tarifaferiadomenudo: tarifa_feriado_menudo, monedaferiadomenudo: moneda_feriado_menudo);


                    c.agregarTarifa(tarifa);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        /// <summary>
        /// Obtiene los datos del punto de venta
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos del punto de venta</param>
        public void obtenerDatosTarifaTransportadora(ref PuntoVenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosPuntoVenta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@punto_venta", p.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    decimal tarifaregular = 0;
                    if (datareader["TarifaRegular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["TarifaRegular"];

                    decimal tarifaferiado = 0;

                    if (datareader["TarifaFeriado"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["TarifaFeriado"];


                    decimal tope = 0;

                    if (datareader["Tope"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["Tope"];


                    decimal recargo = 0;

                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Recargo"];


                    decimal entrega_niquel = 0;

                    if (datareader["EntregaNiquel"] != DBNull.Value)
                        entrega_niquel = (int)datareader["EntregaNiquel"];



                    string centrocosto = "";

                    if (datareader["CentroCostos"] != DBNull.Value)
                        centrocosto = (string)datareader["CentroCostos"];


                    Monedas moneda = Monedas.Colones;

                    if (datareader["MonedaTarifa"] != DBNull.Value)
                        moneda = (Monedas)datareader["MonedaTarifa"];

                    Monedas moneda_feriado = Monedas.Colones;

                    if (datareader["MonedaFeriado"] != DBNull.Value)
                        moneda_feriado = (Monedas)datareader["MonedaTarifa"];


                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];
                    string contacto = (string)datareader["Contacto"];
                    Contratos_Transporte contrato_transporte = (Contratos_Transporte)datareader["Contrato_Transporte"];
                    bool solicitud_remesas = (bool)datareader["Solicitud_Remesas"];

                    Cliente cliente = new Cliente(id_cliente, nombre_cliente, contrato_transporte, solicitud_remesas, contacto);



                    p.Nombre = nombre;
                    p.MonedaTarifaFeriados = moneda_feriado;
                    p.MonedaTarifaRegular = moneda;
                    p.CentroCostos = centrocosto;
                    p.TarifaFeriado = tarifaferiado;
                    p.TarifaRegular = tarifaregular;
                    p.Tope = tope;
                    p.Recargo = recargo;
                    p.EntregaNiquel = entrega_niquel;
                    p.Cliente = cliente;



                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
        }
        #endregion Tarifas Transportadora
        
        #region Cuentas

        /// <summary>
        /// Registrar una cuenta para un punto de venta
        /// </summary>
        /// <param name="c">Objeto Cuenta con los datos de la cuenta</param>
        /// <param name="n">Nombre jurídico al cual pertenece la cuenta</param>
        public void agregarCuentaNombreJuridicoCliente(ref Cuenta c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPuntoVentaCuenta");

            _manejador.agregarParametro(comando, "@cuenta", c.Numero_cuenta, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@moneda", c.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto", c.PuntoVenta, SqlDbType.SmallInt);

            try
            {
                c.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCuentaNombreJuridicoClienteActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de la cuenta de un punto de venta.
        /// </summary>
        /// <param name="c">Objeto Cuenta con los datos de la cuenta a eliminar</param>
        public void eliminarCuentaNombreJuridicoCliente(Cuenta c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePuntoVentaCuenta");

            _manejador.agregarParametro(comando, "@cuenta", c.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCuentaNombreJuridicoClienteActualizacion");
            }

        }

        /// <summary>
        /// Obtener las cuentas de un cliente para un nombre jurídico específico.
        /// </summary>
        /// <param name="n">Nombre jurídico para el cual se obtiene la lista de cuentas</param>
        public void obtenerCuentasPuntoVenta(ref PuntoVenta n)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPuntoVentaCuentas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@punto_venta", n.Id, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    long numero = (long)datareader["Cuenta"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    Cuenta cuenta = new Cuenta(id, numero, moneda);

                    n.agregarCuenta(cuenta);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }




        /// <summary>
        /// Verifica si existe una cuenta a un punto de venta especifico.
        /// </summary>
        /// <param name="t">Objeto Cuenta con los datos de la cuenta</param>
        /// <returns></returns>
        public bool verificarCuentaPuntoVenta(ref Cuenta t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteCuentaPuntoVenta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@punto", t.PuntoVenta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cuenta", t.Numero_cuenta, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@moneda", t.Moneda, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id != t.Id;

                    t.Id = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarATMDuplicado");
            }

            return existe;

        }




        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void agregarCuentaPuntoVenta(ref Cuenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPuntoVentaCuenta");

            _manejador.agregarParametro(comando, "@cuenta", p.Numero_cuenta, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@moneda", p.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@puntoventa", p.PuntoVenta.Id, SqlDbType.SmallInt);
            

            try
            {
                p.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }




        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void actualizarCuentaPuntoVenta(ref Cuenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePuntoVentaCuenta");

            _manejador.agregarParametro(comando, "@numcuenta", p.Numero_cuenta, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@moneda", p.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto", p.PuntoVenta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cuenta", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }





        /// <summary>
        /// Eliminar una cuenta de un punto de venta
        /// </summary>
        /// <param name="s">Objeto Cuenta con los datos de las cuentas</param>
        public void quitarCuentaPuntoVenta(Cuenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePuntoVentaCuenta");

            _manejador.agregarParametro(comando, "@cuenta", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }
        #endregion Cuentas



        #region Paquetes

        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void agregarPaquetes(ref PuntoVenta p, Denominacion d, int tipo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDenominacionPuntoVenta");

            _manejador.agregarParametro(comando, "@punto_venta", p.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@denominacion", d, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tipo", tipo, SqlDbType.Int);
           

            try
            {
               _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }


        /// <summary>
        /// Valida si una tarifa de un punto existe
        /// </summary>
        /// <param name="t">Objeto TarifaPuntoVentaTransportadora con los datos de la tarifa</param>
        /// <returns></returns>
        public bool verificarDenominacionPuntoVenta(ref PuntoVenta p, Denominacion d, int tipo)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteDenominacionPuntoVenta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@denominacion", d, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto", p.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@tipo",tipo, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != 0;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarATMDuplicado");
            }

            return existe;

        }







        /// <summary>
        /// Actualizar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void actualizarDenominacionPuntoVenta(ref PuntoVenta p, Denominacion d, int tipo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDenominacionPuntoVenta");

            _manejador.agregarParametro(comando, "@denominacion", d, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto", p.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@tipo", tipo, SqlDbType.Int);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta a eliminar</param>
        public void eliminarDenominacionPuntoVenta(ref PuntoVenta p, Denominacion d, int tipo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteDenominacionPuntoVenta");

            _manejador.agregarParametro(comando, "@denominacion", d, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto", p.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@tipo", tipo, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }

        /// <summary>
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public void obtenerDenominacionPuntoVenta(ref PuntoVenta p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionPuntoVenta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@punto_venta", p.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    int tipo = (int)datareader["tipo"];
                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);

                    if (tipo == 1)
                        p.agregarDenominacionPaqueteEnsobrado(denominacion);
                    if (tipo == 2)
                        p.agregarDenominacionPaqueteChorreado(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


       
        #endregion Paquetes
        #endregion Métodos Públicos

    }

}
