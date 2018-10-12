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
    public class PuntoAtencionDL:ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PuntoAtencionDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PuntoAtencionDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PuntoAtencionDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PuntoAtencionDL() { }

        #endregion Constructor

        #region Métodos Públicos


        #region Envios 
        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoAtencion con los datos del punto de venta</param>
        public void agregarPuntoAtencion(ref PuntoAtencion p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertValidacionPuntoAtencion");

            _manejador.agregarParametro(comando, "@id_punto_venta", p.IDSites, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", p.FechaPlanilla, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", p.Manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@monto_planilla", p.MontoPlanilla, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@total", p.TotalCobrar, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tula", p.Tula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@transportadora", p.Transportadora.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tipo_punto", p.TipoPuntodeAtencion, SqlDbType.TinyInt);
            try
            {

                p.Id = (int)_manejador.ejecutarEscalar(comando);
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
        /// <param name="s">Objeto PuntoAtencion con los datos del punto de venta</param>
        public void actualizarPuntoAtencion(ref PuntoAtencion p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateValidacionPuntoAtencion");

            _manejador.agregarParametro(comando, "@id_punto_venta", p.IDSites, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@tipo_punto", p.TipoPuntodeAtencion, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", p.FechaPlanilla, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", p.Manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@monto_planilla", p.MontoPlanilla, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@total", p.TotalCobrar, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tula", p.Tula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@transportadora", p.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@id_registro", p.Id, SqlDbType.Int);
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
        /// <param name="s">Objeto PuntoAtencion con los datos del punto de venta a eliminar</param>
        public void eliminarPuntoAtencion(PuntoAtencion p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePuntoAtencion");

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
        /// <param name="c">Sucursal para el cual se obtiene la lista de puntos de venta</param>
        public void obtenerPuntosAtencionSucursales(ref PuntoAtencion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPuntosAtencionSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cliente", c.IDSites, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["ID_Punto"];
                    string punto = (string)datareader["Punto"];
                    string nombrepunto = punto;
                    int numero = (int)datareader["Numero"];

                    c.IDSites = id;
                    c.Nombre = nombrepunto;
                    c.Numero = numero;

                   

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
        public void obtenerPuntosAtencionCliente(ref PuntoAtencion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPuntosAtencionCliente");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cliente", c.IDSites, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["ID_Punto"];
                    string nombre = (string)datareader["Cliente"];
                    string punto = (string)datareader["Punto"];
                    string nombrepunto = nombre + "-" + punto;
                    int numero = (short)datareader["Numero"];

                    c.IDSites = id;
                    c.Nombre = nombrepunto;
                    c.Numero = numero;



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
        public bool validarPuntosAtencionCliente(ref PuntoAtencion c)
        {

            bool nuevo = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistePuntosAtencionCliente");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@punto", c.IDSites, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tula", c.Tula, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@fecha", c.FechaPlanilla, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    

                    if (datareader["pk_ID"] != DBNull.Value)
                    {
                        c.Id = (int)datareader["pk_ID"];

                        nuevo = true;
                    }


                    

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return nuevo;

        }






        /// <summary>
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public BindingList<PuntoAtencion> listarPuntosAtencionInconsistencias(DateTime f, DateTime fin, EmpresaTransporte c, InconsistenciaFacturacion inc)
        {
            BindingList<PuntoAtencion> puntos = new BindingList<PuntoAtencion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciasPuntoFacturacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha",f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_fin", fin, SqlDbType.Date);

            if (c != null)
            _manejador.agregarParametro(comando, "@transportadora", c.ID, SqlDbType.TinyInt);
       

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Validacion"];
                    string manifiesto = (string)datareader["Manifiesto"];
                    string tula = (string)datareader["Tula"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    Decimal montoplanilla = Convert.ToDecimal(datareader["MontoPlanilla"]);
                    Decimal tarifa_regular = 0;
                    if(datareader["Tarifa Regular"] != DBNull.Value)
                     tarifa_regular = Convert.ToDecimal(datareader["Tarifa Regular"]);
                     Decimal tarifa_feriado = 0;
                    if(datareader["Tarifa Feriado"]!=DBNull.Value)
                      tarifa_feriado = Convert.ToDecimal(datareader["Tarifa Feriado"]);

                    Decimal tarifa_reporte = 0;
                    if (datareader["Tarifa_Regular_Reporte"] != DBNull.Value)
                        tarifa_reporte = Convert.ToDecimal(datareader["Tarifa_Regular_Reporte"]);

                    
                    Cliente client = null;

                    if (datareader["ID_Cliente"] != DBNull.Value)
                    {
                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Nombre_Cliente"];
                        client = new Cliente(id: id_cliente, nombre: nombre_cliente);
                    }

                    PuntoVenta P = null;
                    if (datareader["ID_Punto"] != DBNull.Value)
                    {
                        short idpunto = (short)datareader["ID_Punto"];
                        string nombre_punto = (string)datareader["Nombre_Punto"];

                        P = new PuntoVenta(id: idpunto, nombre: nombre_punto, cliente: client);
                    }

                    EmpresaTransporte emp = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                        emp = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);
                    }

                    PuntoAtencion puntoatencion = new PuntoAtencion();

                    puntoatencion.Id = id;
                    puntoatencion.FechaPlanilla = fecha;
                    puntoatencion.Transportadora = emp;
                    puntoatencion.Manifiesto = manifiesto;
                    puntoatencion.Tula = tula;
                    puntoatencion.MontoPlanilla = montoplanilla;
                    puntoatencion.Nombre = P.Nombre;
                    puntoatencion.TarifaRegular = tarifa_regular;
                    puntoatencion.TarifaFeriado = tarifa_feriado;
                    puntoatencion.Tarifa_Reporte = tarifa_reporte;

                    puntos.Add(puntoatencion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return puntos;

        }


        /// <summary>
        /// Obtener una lista de las cargas generadas o importadas en una fecha.
        /// </summary>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="e">Transportadora encargada de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarPuntosFacturacionPedidosExportacion(DateTime f, DateTime ff, EmpresaTransporte e, int tipo)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectValidacionTarifasFacturacionPedidos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@transportadora", e, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha_inicio", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_fin", ff, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@tipo", tipo, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        #endregion Envíos 

        #region Pedidos

        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoAtencion con los datos del punto de venta</param>
        public void agregarPuntoAtencionPedido(ref PuntoAtencion p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertValidacionPuntoAtencionPedidos");

            
            _manejador.agregarParametro(comando, "@fecha", p.FechaPlanilla, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@id_punto", p.IDSites, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@id_pedido", p.IDPedido, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo_cliente", p.TipoPuntodeAtencion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo_servicio", p.EntregaRecibo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@planilla", p.Manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@monto", p.MontoPlanilla, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_excedente", p.MontoExcedente, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tipo_cambio", p.TipoCambio, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@total", p.TotalCobrar, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@visita_compartida", p.VisitaCompartida, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@visita_nocturna", p.VisitaNocturna, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@transportadora", p.Transportadora.ID, SqlDbType.TinyInt);
  
            try
            {

                p.Id = (int)_manejador.ejecutarEscalar(comando);
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
        /// <param name="s">Objeto PuntoAtencion con los datos del punto de venta</param>
        public void actualizarPuntoAtencionPedido(ref PuntoAtencion p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateValidacionPuntoAtencionPedido");

            _manejador.agregarParametro(comando, "@fecha", p.FechaPlanilla, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@id_punto", p.IDSites, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@id_pedido", p.IDPedido, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo_cliente", p.TipoPuntodeAtencion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo_servicio", p.EntregaRecibo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@planilla", p.Manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@monto", p.MontoPlanilla, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_excedente", p.MontoExcedente, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tipo_cambio", p.TipoCambio, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@total", p.TotalCobrar, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@visita_compartida", p.VisitaCompartida, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@visita_nocturna", p.VisitaNocturna, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@transportadora", p.Transportadora.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@id_registro", p.Id, SqlDbType.Int);
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
        /// <param name="s">Objeto PuntoAtencion con los datos del punto de venta a eliminar</param>
        public void eliminarPuntoAtencionPedido(PuntoAtencion p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePuntoAtencionPedido");

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
        public bool validarPuntosAtencionClientePedio(ref PuntoAtencion c)
        {

            bool nuevo = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistePuntosAtencionClientePedido");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@punto", c.IDSites, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@pedido", c.IDPedido, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.FechaPlanilla, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@tipo_cliente", c.TipoPuntodeAtencion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {


                    if (datareader["pk_ID"] != DBNull.Value)
                    {
                        c.Id = (int)datareader["pk_ID"];

                        nuevo = true;
                    }




                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return nuevo;

        }






        /// <summary>
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public BindingList<PuntoAtencion> listarPuntosAtencionInconsistenciasPedido(DateTime f, DateTime fin, EmpresaTransporte c, InconsistenciaFacturacion inc)
        {
            BindingList<PuntoAtencion> puntos = new BindingList<PuntoAtencion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciasPuntoFacturacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_fin", fin, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@transportadora", c.ID, SqlDbType.TinyInt);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Validacion"];
                    string manifiesto = (string)datareader["Manifiesto"];
                    string tula = (string)datareader["Tula"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    Decimal montoplanilla = Convert.ToDecimal(datareader["MontoPlanilla"]);
                    Decimal tarifa_regular = 0;
                    if (datareader["Tarifa Regular"] != DBNull.Value)
                        tarifa_regular = Convert.ToDecimal(datareader["Tarifa Regular"]);
                    Decimal tarifa_feriado = 0;
                    if (datareader["Tarifa Feriado"] != DBNull.Value)
                        tarifa_feriado = Convert.ToDecimal(datareader["Tarifa Feriado"]);

                    Decimal tarifa_reporte = 0;
                    if (datareader["Tarifa_Regular_Reporte"] != DBNull.Value)
                        tarifa_reporte = Convert.ToDecimal(datareader["Tarifa_Regular_Reporte"]);


                    Cliente client = null;

                    if (datareader["ID_Cliente"] != DBNull.Value)
                    {
                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Nombre_Cliente"];
                        client = new Cliente(id: id_cliente, nombre: nombre_cliente);
                    }

                    PuntoVenta P = null;
                    if (datareader["ID_Punto"] != DBNull.Value)
                    {
                        short idpunto = (short)datareader["ID_Punto"];
                        string nombre_punto = (string)datareader["Nombre_Punto"];

                        P = new PuntoVenta(id: idpunto, nombre: nombre_punto, cliente: client);
                    }

                    EmpresaTransporte emp = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                        emp = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);
                    }

                    PuntoAtencion puntoatencion = new PuntoAtencion();

                    puntoatencion.Id = id;
                    puntoatencion.FechaPlanilla = fecha;
                    puntoatencion.Transportadora = emp;
                    puntoatencion.Manifiesto = manifiesto;
                    puntoatencion.Tula = tula;
                    puntoatencion.MontoPlanilla = montoplanilla;
                    puntoatencion.Nombre = P.Nombre;
                    puntoatencion.TarifaRegular = tarifa_regular;
                    puntoatencion.TarifaFeriado = tarifa_feriado;
                    puntoatencion.Tarifa_Reporte = tarifa_reporte;

                    puntos.Add(puntoatencion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return puntos;

        }


        

        #endregion Pedidos
        #endregion Métodos Públicos

        #region Inconsistencias


        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoAtencion con los datos del punto de venta</param>
        public void agregarRegistroInconsistenciaFacturacion(ref RegistroInconsistenciaFacturacion p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInconsistenciaRegistroFacturacion");

            _manejador.agregarParametro(comando, "@punto", p.Punto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@inconsistencia", p.InconsistenciaFacturacion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@usuario", p.ColaboradorRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@observaciones", p.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@estado", p.Estado, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@id", p.Punto.Id, SqlDbType.Int);
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


        #endregion Inconsistencias
    }
}
