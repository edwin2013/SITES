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
    public class ResumenFacturacionClientesDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ResumenFacturacionClientesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ResumenFacturacionClientesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ResumenFacturacionClientesDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ResumenFacturacionClientesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Obtener datos de portavalor asignado a una carga ATM
        /// </summary>
        /// <param name="c">Carga asignada al portavalor</param>
        /// <returns>Datos del portavalor</returns>
        public void listarPotavalorPorResumenFacturacionCliente(ref ResumenFacturacionCliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPortavalorAsignadoResumenFacturacionCliente");
            SqlDataReader datareader = null;


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    string identificacion = (string)datareader["Identificacion"];

                
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
        /// Registrar en el sistema la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto ResumenFacturacionCliente con los datos de la carga/param>
        public void agregarResumenFacturacionCliente(ref ResumenFacturacionCliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertResumenFacturacionCliente");

            //_manejador.agregarParametro(comando, "@atm", c.ATM, SqlDbType.SmallInt);
            //_manejador.agregarParametro(comando, "@emergencia", c.Emergencia, SqlDbType.TinyInt);
            //_manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);
            //_manejador.agregarParametro(comando, "@tipo", c.Tipo, SqlDbType.SmallInt);
            //_manejador.agregarParametro(comando, "@fecha_asignada", c.Fecha_asignada, SqlDbType.Date);
            //_manejador.agregarParametro(comando, "@externa", c.Externa, SqlDbType.Bit);
            //_manejador.agregarParametro(comando, "@atm_full", c.ATM_full, SqlDbType.Bit);
            //_manejador.agregarParametro(comando, "@cartucho_rechazo", c.Cartucho_rechazo, SqlDbType.Bit);
            //_manejador.agregarParametro(comando, "@ena", c.ENA, SqlDbType.Bit);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorResumenFacturacionClienteRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto ResumenFacturacionCliente con los datos de la carga</param>
        public void actualizarResumenFacturacionCliente(ResumenFacturacionCliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateResumenFacturacionCliente");

            //_manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@manifiesto_full", c.Manifiesto_full, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@hora_inicio", c.Hora_inicio, SqlDbType.DateTime);
            //_manejador.agregarParametro(comando, "@hora_finalizacion", c.Hora_finalizacion, SqlDbType.DateTime);
            //_manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.VarChar);
            //_manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorResumenFacturacionClienteActualizacion");
            }

        }




        /// <summary>
        /// Finalizar una solicitud de codigo de cajeros automaticos
        /// </summary>
        /// <param name="c">Objeto ResumenFacturacionCliente con los datos de la carga</param>
        public void actualizarFinalizarCodigoResumenFacturacionCliente(ResumenFacturacionCliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFinalizarCodigoATM");

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
            

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorResumenFacturacionClienteActualizacion");
            }

        }     

        /// <summary>
        /// Actualizar el orden en la ruta de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto ResumenFacturacionCliente con los datos de la carga</param>
        public void actualizarResumenFacturacionClienteOrdenRuta(ResumenFacturacionCliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateResumenFacturacionClienteOrdenRuta");

            //_manejador.agregarParametro(comando, "@orden", c.Orden_ruta, SqlDbType.TinyInt);
            //_manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorResumenFacturacionClienteActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto ResumenFacturacionCliente con los datos de la carga</param>
        public void actualizarResumenFacturacionClienteDatosVerificacion(ResumenFacturacionCliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateResumenFacturacionClienteDatosVerificacion");

            //_manejador.agregarParametro(comando, "@colaborador", c.Colaborador_verificador, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorResumenFacturacionClienteActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto ResumenFacturacionCliente con los datos de la carga</param>
        public void eliminarResumenFacturacionCliente(ResumenFacturacionCliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteResumenFacturacionCliente");

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
          
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorResumenFacturacionClienteEliminacion");
            }

        }



        /// <summary>
        /// Lista los datos de la tarifa a cobrar a los clientes
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del Cliente</param>
        /// <param name="t">Objeto Empresa Transporte con los datos de la Transportadora</param>
        /// <param name="fechai">Fecha Inicio de la Facturación</param>
        /// <param name="fechaf">Fecha Fin de la Facturación</param>
        /// <returns></returns>
        public BindingList<ResumenFacturacionCliente> listarResumenFacturacionCliente(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
            BindingList<ResumenFacturacionCliente> lista = new BindingList<ResumenFacturacionCliente>();


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectResumenFacturacionCliente");
            SqlDataReader datareader = null;

            if(c == null)
                _manejador.agregarParametro(comando, "@cliente", c, SqlDbType.SmallInt);
            if(c != null)
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicial", fechai, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_final", fechaf, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    //int id = (byte)datareader["pk_ID"];
                    //string nombre = (string)datareader["Nombre"];

                    DateTime fecha = (DateTime)datareader["Fecha"];
                    string Manifiesto = (string)datareader["Manifiesto"];

                    short id_punto = (short)datareader["ID_Punto"];
                    string nomrbre_punto = (string)datareader["Nombre_Punto"];

                    PuntoVenta p = new PuntoVenta(id: id_punto, nombre: nomrbre_punto);


                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    Cliente cliente = new Cliente(id: id_cliente, nombre: nombre_cliente);

                    Monedas mon;
                    if (datareader["Moneda"] != DBNull.Value)
                    {
                        mon = (Monedas)datareader["Moneda"];
                    }
                    else
                        mon = Monedas.Colones;
                    p.Cliente = cliente;
                    

                    decimal monto_planilla = (decimal)datareader["MontoPlanilla"];
                    decimal tarifa = 0;

                    if (datareader["Tarifa"] != DBNull.Value)
                    {
                        tarifa = (decimal)datareader["Tarifa"];
                    }

                    decimal tope = 0;
                    if (datareader["Tope"] != DBNull.Value)
                    {
                        tope = (decimal)datareader["Tope"];
                    }

                    decimal recargo = 0;
                    if (datareader["Recargo"] != DBNull.Value)
                    {
                        recargo = (decimal)datareader["Recargo"];
                    }

                    decimal total = 0;
                    if (datareader["Calculo Recargo"] != DBNull.Value)
                    {
                        total = (decimal)datareader["Calculo Recargo"];
                    }

                    decimal sumarecargo = 0;

                    if (datareader["SumaTarifaRecargo"] != DBNull.Value)
                    {
                        sumarecargo = (decimal)datareader["SumaTarifaRecargo"];
                    }

                    string manifiesto = "";

                    if (datareader["Manifiesto"] != DBNull.Value)
                    {
                        manifiesto = (string)datareader["Manifiesto"];
                    }



                    ResumenFacturacionCliente resumen = new ResumenFacturacionCliente(cliente: cliente, punto: p, monto_planilla: monto_planilla, tarifa: tarifa, tope: tope, recargo: recargo, total: total, fecha: fecha);
                    resumen.SumaRecargo = sumarecargo;
                    resumen.Planilla = manifiesto;
                    resumen.Moneda = mon;
                    lista.Add(resumen);
                    
                    
                    
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return lista;
        }








        /// <summary>
        /// Lista los datos de la tarifa a cobrar a los clientes
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del Cliente</param>
        /// <param name="t">Objeto Empresa Transporte con los datos de la Transportadora</param>
        /// <param name="fechai">Fecha Inicio de la Facturación</param>
        /// <param name="fechaf">Fecha Fin de la Facturación</param>
        /// <returns></returns>
        public BindingList<ResumenFacturacionCliente> listarResumenFacturacionClienteEnvios(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
            BindingList<ResumenFacturacionCliente> lista = new BindingList<ResumenFacturacionCliente>();


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectResumenFacturacionClienteEnvios");
            SqlDataReader datareader = null;

            if (c == null)
                _manejador.agregarParametro(comando, "@cliente", c, SqlDbType.SmallInt);
            if (c != null)
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicial", fechai, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_final", fechaf, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    //int id = (byte)datareader["pk_ID"];
                    //string nombre = (string)datareader["Nombre"];

                    DateTime fecha = (DateTime)datareader["Fecha"];
                    string Manifiesto = (string)datareader["Manifiesto"];

                    short id_punto = (short)datareader["ID_Punto"];
                    string nomrbre_punto = (string)datareader["Nombre_Punto"];

                    PuntoVenta p = new PuntoVenta(id: id_punto, nombre: nomrbre_punto);


                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    Cliente cliente = new Cliente(id: id_cliente, nombre: nombre_cliente);

                    Monedas mon;
                    if (datareader["Moneda"] != DBNull.Value)
                    {
                        mon = (Monedas)datareader["Moneda"];
                    }
                    else
                        mon = Monedas.Colones;
                    p.Cliente = cliente;


                    decimal monto_planilla = (decimal)datareader["Monton_Transportado"];
                    decimal tarifa = 0;

                    if (datareader["Tarifa"] != DBNull.Value)
                    {
                        tarifa = (decimal)datareader["Tarifa"];
                    }

                    decimal tope = 0;
                    if (datareader["Tope"] != DBNull.Value)
                    {
                        tope = (decimal)datareader["Tope"];
                    }

                    decimal recargo = 0;
                    if (datareader["Recargo"] != DBNull.Value)
                    {
                        recargo = (decimal)datareader["Recargo"];
                    }

                    decimal total = 0;
                    if (datareader["Calculo Recargo"] != DBNull.Value)
                    {
                        total = (decimal)datareader["Calculo Recargo"];
                    }

                    decimal sumarecargo = 0;

                    if (datareader["SumaTarifaRecargo"] != DBNull.Value)
                    {
                        sumarecargo = (decimal)datareader["SumaTarifaRecargo"];
                    }

                    string manifiesto = "";

                    if (datareader["Manifiesto"] != DBNull.Value)
                    {
                        manifiesto = (string)datareader["Manifiesto"];
                    }



                    ResumenFacturacionCliente resumen = new ResumenFacturacionCliente(cliente: cliente, punto: p, monto_planilla: monto_planilla, tarifa: tarifa, tope: tope, recargo: recargo, total: total, fecha: fecha);
                    resumen.SumaRecargo = sumarecargo;
                    resumen.Planilla = manifiesto;
                    resumen.Moneda = mon;
                    lista.Add(resumen);



                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return lista;
        }





        #region Procesamiento


        /// <summary>
        /// Lista los datos de la tarifa a cobrar a los clientes
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del Cliente</param>
        /// <param name="t">Objeto Empresa Transporte con los datos de la Transportadora</param>
        /// <param name="fechai">Fecha Inicio de la Facturación</param>
        /// <param name="fechaf">Fecha Fin de la Facturación</param>
        /// <returns></returns>
        public BindingList<FacturacionProcesamiento> listarResumenFacturacionClienteProcesamiento(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
            BindingList<FacturacionProcesamiento> lista = new BindingList<FacturacionProcesamiento>();


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectResumenFacturacionProcesamientoProa");
            SqlDataReader datareader = null;

            if (c == null)
                _manejador.agregarParametro(comando, "@cliente", c, SqlDbType.SmallInt);
            if (c != null)
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicial", fechai, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_final", fechaf, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    //int id = (byte)datareader["pk_ID"];
                    //string nombre = (string)datareader["Nombre"];

                    DateTime fecha = (DateTime)datareader["Fecha"];


                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Cliente"];

                    Cliente cliente = new Cliente(id: id_cliente, nombre: nombre_cliente);

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    //string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                    EmpresaTransporte empresa = new EmpresaTransporte(id: id_transportadora);


                    decimal monto_colones = 0;
                    decimal monto_dolares = 0;
                    decimal monto_niquel = 0;
                    decimal tarifa_colones = 0;
                    decimal tarifa_dolares = 0;
                    decimal tarifa_niquel = 0;


                    if (datareader["MontoTotalColones"] != DBNull.Value)
                    {
                        monto_colones = (decimal)datareader["MontoTotalColones"];
                    }


                    if (datareader["MontoTotalDolares"] != DBNull.Value)
                    {
                        monto_dolares = (decimal)datareader["MontoTotalDolares"];
                    }


                    if (datareader["MontoTotalNiquel"] != DBNull.Value)
                    {
                        monto_niquel = (decimal)datareader["MontoTotalNiquel"];
                    }

                    if (datareader["TarifaColones"] != DBNull.Value)
                    {
                        tarifa_colones = (decimal)datareader["TarifaColones"];
                    }


                    if (datareader["TarifaDolares"] != DBNull.Value)
                    {
                        tarifa_dolares = (decimal)datareader["TarifaDolares"];
                    }


                    if (datareader["TarifaNiquel"] != DBNull.Value)
                    {
                        tarifa_niquel = (decimal)datareader["TarifaNiquel"];
                    }



                    FacturacionProcesamiento resumen = new FacturacionProcesamiento(cliente: cliente, fecha: fecha, transportadora: empresa, monto_colones: monto_colones, monto_dolares: monto_dolares, monto_niquel: monto_niquel,
                        tarifa_colones: tarifa_colones, tarifa_dolares: tarifa_dolares, tarifa_niquel: tarifa_niquel);

                    lista.Add(resumen);



                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
            return lista;
        }


        #endregion Procesamiento




        #endregion Métodos Públicos
    }
}
