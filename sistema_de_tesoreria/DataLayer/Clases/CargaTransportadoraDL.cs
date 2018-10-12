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
   
    public class CargaTransportadoraDL
    {
        
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CargaTransportadoraDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CargaTransportadoraDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CargaTransportadoraDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CargaTransportadoraDL() { }

        #endregion Constructor

        #region Métodos Públicos



        /// <summary>
        /// Registrar en el sistema la carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga/param>
        public void agregarCargaTransportadora(ref CargaTransportadora c, Colaborador col)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCargaTransportadora");

            _manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@registrador", col, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estadoaprobacion", c.EstadoAprobadas, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha_asignada, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@colaboradorrevisiontransportadora", c.ColaboradorVerificadorTransportadora, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaTransportadoraRegistro");
            }


        }

        /// <summary>
        /// Actualizar los datos de la carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadora(CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadora");


            _manejador.agregarParametro(comando, "@hora_inicio", c.Hora_inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_finalizacion", c.Hora_finalizacion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@empresa", c.Transportadora, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }

        

        /// <summary>
        /// Asignar la carga de un ATM como parte de una carga de emergencia.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaTransportadoraCargaEmergenciaSucursal(CargaTransportadora c, CargaEmergenciaSucursal ce)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraCargaEmergenciaSucursal");

            _manejador.agregarParametro(comando, "@carga_emergencia", ce, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@sucursal", ce.Sucursal, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@ruta", c.Ruta, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }

        /// <summary>
        /// Asignar la ruta a la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMRuta(CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMRuta");

            _manejador.agregarParametro(comando, "@ruta", c.Ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }



        /// <summary>
        /// Asignar la carga de un Sucursal a un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraColaborador(CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraCajero");

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }

        /// <summary>
        /// Asignar la ruta y la hora de llegada a la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMRutaHora(ref CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMRutaHora");

            _manejador.agregarParametro(comando, "@ruta", c.Ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@hora", c.Hora_Llegada, SqlDbType.DateTime);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }


        /// <summary>
        /// Asignar la ruta y la hora de llegada a la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMRutaHoraImportacion(ref CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMRutaHora");

            _manejador.agregarParametro(comando, "@ruta", c.Ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga", c.DB_ID, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@hora", c.Hora_Llegada, SqlDbType.DateTime);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }

        /// <summary>
        /// Actualizar el orden en la ruta de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMOrdenRuta(CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMOrdenRuta");

            _manejador.agregarParametro(comando, "@orden", c.Orden_ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }


        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraAprobacoinGerente(CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraDatosAprobacionGerente");

            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador_verificador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }


        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraDatosVerificacion(CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraDatosVerificacion");

            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador_verificador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }

        

        public DataTable listarEnvioRemesasTransportadoras(DateTime i, DateTime f, Sucursal s, Colaborador asignador, Colaborador aprobador, Colaborador portavalor, int tipocarga)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectReporteEnvioPedidoTransportadoras");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", f, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@asignador", asignador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@aprobador", aprobador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@sucursal", s, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@portavalor", portavalor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipopedido", tipocarga, SqlDbType.Int);

            //Ejecutar la consulta

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw ex;
            }

            return salida;
        }


        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraAprobacoinGerente(CargaTransportadora c, EstadoAprobacionCargas est)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraDatosAprobacionGerente");

            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador_Registro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", est, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c.Comentacio_Rechazo, SqlDbType.NVarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }




        /// <summary>
        /// Eliminar los datos de una carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void eliminarCargaTransportadora(CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCargaTransportadora");

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c.Comentario_Eliminacion, SqlDbType.NVarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMEliminacion");
            }

        }



        /// <summary>
        /// Ligar o desligar la carga de una Sucursal del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraCierreSucursal(CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraCierreTransportadoras");

            _manejador.agregarParametro(comando, "@cierre", c.Cierre, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }

        /// <summary>
        /// Obtener las cargas del cierre de un cajero de Boveda
        /// </summary>
        /// <param name="c">Objeto CierreCargaTransportadora con los datos del cierre del cajero de ATM's</param>
        public void obtenerCargasSucursalCierreSucursal(ref CierreCargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasTransportadorasCierreTransportadoras");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    byte? ruta = datareader["Ruta"] as byte?;
                    EstadosPedidoBanco estado = (EstadosPedidoBanco)datareader["Estado"];
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = "";
                    DateTime hora_programada = DateTime.Now;
                    DateTime hora_entrada = DateTime.Now;
                    DateTime hora_salida = DateTime.Now;
                    float distancia = 0;
                    int tiempo_viaje = 0;
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_entrada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_salida = (DateTime)datareader["Hora_Salida"];
                    
                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                   

                    CargaTransportadora carga = new CargaTransportadora(emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta,distancia:distancia,hora_programada:hora_programada,tiempoviaje:tiempo_viaje);
                   
                
                    c.agregarCarga(carga);
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
        /// Actualizar los datos con respecto al ROADNET
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraDatosRoadnet(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraesDesdeRoadnet");

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
   

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }


        /// <summary>
        /// Lista todas las cargas a Transportadoras de una fecha especifica
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a filtrar</param>
        /// <param name="f">Fecha a filtrar</param>
        /// <param name="r">Ruta a filtrar</param>
        /// <returns>Una lista con los datos de las cargas a las Transportadoras</returns>
        public BindingList<CargaTransportadora> listarCargasTransportadorasPorAprobar(Sucursal s, DateTime f, byte? r)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraPorAprobar");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@canal", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    
                    byte? ruta = datareader["Ruta"] as byte?;
                    EstadosPedidoBanco estado = (EstadosPedidoBanco)datareader["Estado"];
                    bool nuevo = (bool)datareader["Entrega"];
                    int opcion = 0;
                    if (nuevo)
                    {
                        opcion = 1;
                    }

                    EntregaRecibo entregarecibo = (EntregaRecibo)opcion;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = "";
                    DateTime hora_programada = DateTime.Now;
                    DateTime hora_entrada = DateTime.Now;
                    DateTime hora_salida = DateTime.Now;
                    float distancia = 0;
                    int tiempo_viaje = 0;
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_entrada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_salida = (DateTime)datareader["Hora_Salida"];

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Sucursal_Nombre"];
                        string direccion = (string)datareader["Sucursal_Direccion"];
                        Provincias provincia = (Provincias)datareader["Sucursal_Provincia"];
                        bool externa = (bool)datareader["Sucursal_Externa"];
                        short codigo = (short)datareader["Sucursal_Numero"];

                        TipoSucursal tiposucursal = (TipoSucursal)datareader["Sucursal_Tipo"];


                        sucursal = new Sucursal(nombre, id: id, direccion: direccion, provincia: provincia, sucursal: tiposucursal, externo: externa, codigo: codigo, transporte: empresa);

                        //_Transportadoras.obtenerDiasCargaTransportadora(ref sucursal);

                    }

                    CargaTransportadora carga = new CargaTransportadora(emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, distancia: distancia, hora_programada: hora_programada, tiempoviaje: tiempo_viaje);
                    carga.EntregaBovedaSucursal = entregarecibo;
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
       /// Lista todas las cargas a Transportadoras de una fecha especifica
       /// </summary>
       /// <param name="s">Objeto Sucursal con los datos de la sucursal a filtrar</param>
       /// <param name="f">Fecha a filtrar</param>
       /// <param name="r">Ruta a filtrar</param>
       /// <returns>Una lista con los datos de las cargas a las Transportadoras</returns>
        public BindingList<CargaTransportadora> listarCargasTransportadoras(Colaborador c,EmpresaTransporte s, DateTime f, EstadoAprobacionCargas est)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraMonitoreo");
            SqlDataReader datareader = null;


         
            _manejador.agregarParametro(comando, "@canal", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@estadoaprobacion", est, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    EstadosPedidoBanco estado = (EstadosPedidoBanco)datareader["Estado"];
                    string observaciones = "";
                    DateTime fecha_asignada = DateTime.Now;
                    if (datareader["Observaciones"] != DBNull.Value) observaciones = (string)datareader["Observaciones"];
                    if (datareader["Fecha_Asignada"] != DBNull.Value)
                        fecha_asignada = (DateTime)datareader["Fecha_Asignada"];

                    String comentarioRechazo = "";
                    if (datareader["Comentario_Rechazo_Carga"] != DBNull.Value)
                        comentarioRechazo = (string)datareader["Comentario_Rechazo_Carga"];
                    
                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    


                    Colaborador cajero = null;

                    // if (datareader["Cajero_Nombre"] != DBNull.Value)
                    //{
                        
                    //    string nombre_cajero = (string)datareader["Cajero_Nombre"];
                    //    string primerapellido = (string)datareader["Cajero_PrimerApellido"];
                    //    string segudoapellido = (string)datareader["Cajero_SegundoApellido"];
                    //    int id_col = (int)datareader["ID_Colaborador"];



                    //    cajero = new Colaborador(id: id_col, nombre: nombre_cajero, primer_apellido: primerapellido, segundo_apellido: segudoapellido);

                    //    //_Transportadoras.obtenerDiasCargaTransportadora(ref sucursal);

                    //}


                    CargaTransportadora carga = new CargaTransportadora(id: id_carga, transportadora: empresa, 
                                                              fecha_asignada: fecha_asignada, cajero:cajero);
                    carga.Comentacio_Rechazo = comentarioRechazo;
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
        /// Lista todas las cargas a Transportadoras de una fecha especifica
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a filtrar</param>
        /// <param name="f">Fecha a filtrar</param>
        /// <param name="r">Ruta a filtrar</param>
        /// <returns>Una lista con los datos de las cargas a las Transportadoras</returns>
        public BindingList<CargaTransportadora> listarCargasTransportadorasRoadnet(Colaborador c, Sucursal s, DateTime f, byte? r, EstadoAprobacionCargas est)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraMonitoreoRoadnet");
            SqlDataReader datareader = null;



            _manejador.agregarParametro(comando, "@canal", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estadoaprobacion", est, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    bool mutilado = (bool)datareader["Mutilado"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    byte? ruta = datareader["Ruta"] as byte?;
                    EstadosPedidoBanco estado = (EstadosPedidoBanco)datareader["Estado"];
                    bool nuevo = (bool)datareader["Entrega"];
                    int opcion = 0;
                    if (nuevo)
                    {
                        opcion = 1;
                    }

                    EntregaRecibo entregarecibo = (EntregaRecibo)opcion;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = "";
                    DateTime hora_programada = DateTime.Now;
                    DateTime hora_entrada = DateTime.Now;
                    DateTime hora_salida = DateTime.Now;
                    float distancia = 0;
                    int tiempo_viaje = 0;
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_entrada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_salida = (DateTime)datareader["Hora_Salida"];


                    String comentarioRechazo = "";
                    if (datareader["Comentario_Rechazo_Carga"] != DBNull.Value)
                        comentarioRechazo = (string)datareader["Comentario_Rechazo_Carga"];

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Sucursal_Nombre"];
                        string direccion = (string)datareader["Sucursal_Direccion"];
                        Provincias provincia = (Provincias)datareader["Sucursal_Provincia"];
                        bool externa = (bool)datareader["Sucursal_Externa"];
                        short codigo = (short)datareader["Sucursal_Numero"];

                        TipoSucursal tiposucursal = (TipoSucursal)datareader["Sucursal_Tipo"];


                        sucursal = new Sucursal(nombre, id: id, direccion: direccion, provincia: provincia, sucursal: tiposucursal, externo: externa, codigo: codigo, transporte: empresa);

                        //_Transportadoras.obtenerDiasCargaTransportadora(ref sucursal);

                    }


                    CargaTransportadora carga = new CargaTransportadora(sucursal: sucursal, emergencia: emergencia, id: id_carga, transportadora: empresa,
                                                            ruta: ruta, orden_ruta: orden_ruta, distancia: distancia, hora_programada: hora_programada,
                                                            tiempoviaje: tiempo_viaje, mutilado: mutilado);
                    carga.Comentacio_Rechazo = comentarioRechazo;
                    carga.EntregaBovedaSucursal = entregarecibo;
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
        /// Lista todas las cargas a Transportadoras de una fecha especifica
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a filtrar</param>
        /// <param name="f">Fecha a filtrar</param>
        /// <param name="r">Ruta a filtrar</param>
        /// <returns>Una lista con los datos de las cargas a las Transportadoras</returns>
        public BindingList<CargaTransportadora> listarCargasTransportadorasPorAprobar(Colaborador c, EmpresaTransporte s, DateTime f, EstadoAprobacionCargas est)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraMonitoreoporAprobar");
            SqlDataReader datareader = null;



            _manejador.agregarParametro(comando, "@transportadora", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@estadoaprobacion", est, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                   // EstadoAprobacionCargas estado = (EstadoAprobacionCargas)datareader["Estado"];
                   
                    string observaciones = "";

                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                   
                    String comentarioRechazo = "";
                    if (datareader["Comentario_Rechazo_Carga"] != DBNull.Value)
                        comentarioRechazo = (string)datareader["Comentario_Rechazo_Carga"];

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                   

                    CargaTransportadora carga = new CargaTransportadora( id: id_carga, transportadora: empresa
                                                             );
                    carga.Comentacio_Rechazo = comentarioRechazo;
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
        /// Lista todas las cargas a Transportadoras de una fecha especifica
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a filtrar</param>
        /// <param name="f">Fecha a filtrar</param>
        /// <param name="r">Ruta a filtrar</param>
        /// <returns>Una lista con los datos de las cargas a las Transportadoras</returns>
        public BindingList<CargaTransportadora> listarCargasTransportadorasAprobacionCorreccion(Colaborador c, EmpresaTransporte s, DateTime f, EstadoAprobacionCargas est)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraMonitoreoporAprobar");
            SqlDataReader datareader = null;



            _manejador.agregarParametro(comando, "@transportadora", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@estadoaprobacion", est, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    // EstadoAprobacionCargas estado = (EstadoAprobacionCargas)datareader["Estado"];

                    string observaciones = "";

                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";

                    String comentarioRechazo = "";
                    if (datareader["Comentario_Rechazo_Carga"] != DBNull.Value)
                        comentarioRechazo = (string)datareader["Comentario_Rechazo_Carga"];

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }



                    CargaTransportadora carga = new CargaTransportadora(id: id_carga, transportadora: empresa
                                                             );
                    carga.Comentacio_Rechazo = comentarioRechazo;
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
        /// Encuentra las cargas de Transportadoras por Manifiestos
        /// </summary>
        /// <param name="c">Colaborador del Registro</param>
        /// <param name="s">Sucursal a buscar</param>
        /// <param name="f">Fecha de los pedidos</param>
        /// <param name="r">Ruta</param>
        /// <param name="est">Estado del pedido</param>
        /// <returns></returns>
        public BindingList<CargaTransportadora> listarCargasTransportadorasManifiesto(Colaborador c, EmpresaTransporte s, DateTime f, EstadoAprobacionCargas est)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraManifiesto");
            SqlDataReader datareader = null;



            _manejador.agregarParametro(comando, "@canal", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@estadoaprobacion", est, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    byte? ruta = datareader["Ruta"] as byte?;
                    EstadosCargasSucursales estado = (EstadosCargasSucursales)datareader["Estado"];
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    bool nuevo = (bool)datareader["Entrega"];
                    int opcion = 0;
                    if (nuevo)
                    {
                        opcion = 1;
                    }

                    EntregaRecibo entregarecibo = (EntregaRecibo)opcion;
                    string observaciones = "";
                    DateTime hora_programada = DateTime.Now;
                    DateTime hora_entrada = DateTime.Now;
                    DateTime hora_salida = DateTime.Now;
                    float distancia = 0;
                    int tiempo_viaje = 0;
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_entrada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_salida = (DateTime)datareader["Hora_Salida"];

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Sucursal_Nombre"];
                        string direccion = (string)datareader["Sucursal_Direccion"];
                        Provincias provincia = (Provincias)datareader["Sucursal_Provincia"];
                        bool externa = (bool)datareader["Sucursal_Externa"];
                        short codigo = (short)datareader["Sucursal_Numero"];

                        TipoSucursal tiposucursal = (TipoSucursal)datareader["Sucursal_Tipo"];


                        sucursal = new Sucursal(nombre, id: id, direccion: direccion, provincia: provincia, sucursal: tiposucursal, externo: externa, codigo: codigo, transporte: empresa);

                        //_Transportadoras.obtenerDiasCargaTransportadora(ref sucursal);

                    }

                    CargaTransportadora carga = new CargaTransportadora(emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, distancia: distancia, hora_programada: hora_programada, tiempoviaje: tiempo_viaje);
                    carga.Estado = estado;
                    carga.EntregaBovedaSucursal = entregarecibo;
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





        // <summary>
        /// Obtener los datos de los colaboradores de la carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora que representa la carga para la cual se obtienen los datos</param>
        public void obtenerColaboradoresCargaTransportadora(ref CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradoresCargas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    Colaborador encargado = null;
                    Colaborador verificador = null;
                    Colaborador registrador = null;

                    if (datareader["ID_Encargado"] != DBNull.Value)
                    {
                        int id_encargado = (int)datareader["ID_Encargado"];
                        string nombre_encargado = (string)datareader["Nombre_Encargado"];
                        string primer_apellido_encargado = (string)datareader["Primer_Apellido_Encargado"];
                        string segundo_apellido_encargado = (string)datareader["Segundo_Apellido_Encargado"];

                        encargado = new Colaborador(id: id_encargado, nombre: nombre_encargado, primer_apellido: primer_apellido_encargado,
                                                    segundo_apellido: segundo_apellido_encargado);
                    }

                    if (datareader["ID_Verificador"] != DBNull.Value)
                    {
                        int id_verificador = (int)datareader["ID_Verificador"];
                        string nombre_verificador = (string)datareader["Nombre_Verificador"];
                        string primer_apellido_verificador = (string)datareader["Primer_Apellido_Verificador"];
                        string segundo_apellido_verificador = (string)datareader["Segundo_Apellido_Verificador"];

                        verificador = new Colaborador(id: id_verificador, nombre: nombre_verificador, primer_apellido: primer_apellido_verificador,
                                                    segundo_apellido: segundo_apellido_verificador);
                    }

                    if (datareader["ID_Registrador"] != DBNull.Value)
                    {
                        int id_verificador = (int)datareader["ID_Registrador"];
                        string nombre_verificador = (string)datareader["Nombre_Registrador"];
                        string primer_apellido_verificador = (string)datareader["Primer_Apellido_Registrador"];
                        string segundo_apellido_verificador = (string)datareader["Segundo_Apellido_Registrador"];

                        verificador = new Colaborador(id: id_verificador, nombre: nombre_verificador, primer_apellido: primer_apellido_verificador,
                                                    segundo_apellido: segundo_apellido_verificador);
                    }

                    c.Colaborador_Registro = registrador;
                    c.Colaborador_verificador = verificador;
                    c.Cajero = encargado;

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
        /// Verificar si una Carga ya está aprobado por gerente y verificada.
        /// </summary>
        /// <param name="c">Objeto Carga con los datos del carga</param>
        /// <returns>Valor que indica si el carga existe</returns>
        public bool verificarExisteCargaVerificada(CargaTransportadora c)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteVerificacionAprobacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id == c.ID;

                    c.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarEquipo");
            }

            return existe;
        }






        /// <summary>
        /// Lista todas las cargas a Transportadoras de una fecha especifica
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a filtrar</param>
        /// <param name="f">Fecha a filtrar</param>
        /// <param name="r">Ruta a filtrar</param>
        /// <returns>Una lista con los datos de las cargas a las Transportadoras</returns>
        public BindingList<CargaTransportadora> listarCargasTransportadorasSinAsignarCajero(EmpresaTransporte s, DateTime f)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraSinAsignar");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@canal", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    byte? ruta = datareader["Ruta"] as byte?;
                    EstadosPedidoBanco estado = (EstadosPedidoBanco)datareader["Estado"];
                    bool variable = (bool)datareader["Entrega"];
                    int opcion = 0;
                    if (variable)
                    {
                        opcion = 1;
                    }

                    EntregaRecibo entregarecibo = (EntregaRecibo)opcion;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = "";
                    DateTime hora_programada = DateTime.Now;
                    DateTime hora_entrada = DateTime.Now;
                    DateTime hora_salida = DateTime.Now;
                    float distancia = 0;
                    int tiempo_viaje = 0;
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_entrada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_salida = (DateTime)datareader["Hora_Salida"];

                    EstadosCargasSucursales nuevo = (EstadosCargasSucursales)datareader["Estado_Carga"];

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Sucursal_Nombre"];
                        string direccion = (string)datareader["Sucursal_Direccion"];
                        Provincias provincia = (Provincias)datareader["Sucursal_Provincia"];
                        bool externa = (bool)datareader["Sucursal_Externa"];
                        short codigo = (short)datareader["Sucursal_Numero"];

                        TipoSucursal tiposucursal = (TipoSucursal)datareader["Sucursal_Tipo"];


                        sucursal = new Sucursal(nombre, id: id, direccion: direccion, provincia: provincia, sucursal: tiposucursal, externo: externa, codigo: codigo, transporte: empresa);

                        //_Transportadoras.obtenerDiasCargaTransportadora(ref sucursal);

                    }

                    CargaTransportadora carga = new CargaTransportadora(emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, distancia: distancia, hora_programada: hora_programada, tiempoviaje: tiempo_viaje);
                    carga.Estado = nuevo;
                    carga.EntregaBovedaSucursal = entregarecibo;
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
        /// Listar las cargas asignadas un cajero de Transportadoras.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Transportadoras</param>
        public BindingList<CargaTransportadora> listarCargasTransportadorasPorCajero(Colaborador c)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasTransportadorasCajero");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    byte? ruta = datareader["Ruta"] as byte?;
                    EstadosPedidoBanco estado = (EstadosPedidoBanco)datareader["Estado"];
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = "";
                    DateTime hora_programada = DateTime.Now;
                    DateTime hora_entrada = DateTime.Now;
                    DateTime hora_salida = DateTime.Now;
                    float distancia = 0;
                    int tiempo_viaje = 0;
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_entrada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_salida = (DateTime)datareader["Hora_Salida"];

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                  

                    CargaTransportadora carga = new CargaTransportadora(emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, distancia: distancia, hora_programada: hora_programada, tiempoviaje: tiempo_viaje);
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
        /// Obtener una lista de las cargas de un determinado ATM con determinados marchamos.
        /// </summary>
        /// <param name="a">ATM para el cual se genera la lista</param>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista de cargas que cumplen con los parámetros</returns>
        public BindingList<CargaTransportadora> listarCargasATMsPorATMMarchamo(ATM a, string m)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsPorMarchamos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@marchamo", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    byte? ruta = datareader["Ruta"] as byte?;
                    string observaciones = (string)datareader["Observaciones"];

                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre_sucursal = (string)datareader["Nombre_Sucursal"];
                        Provincias provincia = (Provincias)datareader["Provincia_Sucursal"];

                        sucursal = new Sucursal(nombre_sucursal, id: id_sucursal, provincia: provincia);
                    }

                    Ubicacion ubicacion = null;

                    if (datareader["ID_Ubicacion"] != DBNull.Value)
                    {
                        short id_ubicacion = (short)datareader["ID_Ubicacion"];
                        string oficina = (string)datareader["Oficina"];
                        string direccion = (string)datareader["Direccion"];
                        Provincias provincia = (Provincias)datareader["Provincia_Ubicacion"];

                        ubicacion = new Ubicacion(oficina, direccion, id: id_ubicacion, provincia: provincia);
                    }

                    Colaborador cajero = new Colaborador(id: id_cajero, nombre: nombre_cajero, primer_apellido: primer_apellido,
                                                         segundo_apellido: segundo_apellido);
                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas, sucursal: sucursal,
                                      ubicacion: ubicacion);

                    //CargaTransportadora carga = new CargaTransportadora(atm, id: id_carga, cajero: cajero, fecha_asignada: fecha_asignada,
                    //                              tipo: tipo, atm_full: atm_full, cartucho_rechazo: cartucho_rechazo,
                    //                              ena: ena, ruta: ruta, observaciones: observaciones);

                    //cargas.Add(carga);
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
        /// Obtener una lista de las cargas asignadas a una ruta en una fecha determinada.
        /// </summary>
        /// <param name="r">Número de ruta</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cargas que cumplen con los parámetros</returns>
        public BindingList<CargaTransportadora> listarCargasATMsPorRuta(byte r, DateTime f)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsPorRuta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre_sucursal = (string)datareader["Nombre"];
                        Provincias provincia = (Provincias)datareader["Provincia_Sucursal"];

                        sucursal = new Sucursal(nombre_sucursal, id: id_sucursal, provincia: provincia);
                    }

                    Ubicacion ubicacion = null;

                    if (datareader["ID_Ubicacion"] != DBNull.Value)
                    {
                        short id_ubicacion = (short)datareader["ID_Ubicacion"];
                        string oficina = (string)datareader["Oficina"];
                        string direccion = (string)datareader["Direccion"];
                        Provincias provincia = (Provincias)datareader["Provincia_Ubicacion"];

                        ubicacion = new Ubicacion(oficina, direccion, id: id_ubicacion, provincia: provincia);
                    }

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas, sucursal: sucursal,
                                    ubicacion: ubicacion);

                    //CargaTransportadora carga = new CargaTransportadora(atm: atm, id: id_carga, tipo: tipo,
                    //                              atm_full: atm_full, cartucho_rechazo: cartucho_rechazo,
                    //                              ena: ena, orden_ruta: orden_ruta);

                    //cargas.Add(carga);
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
        /// Obtener una lista de las cargas de emergencia no utilizadas en una fecha específica.
        /// </summary>
        /// <param name="fecha">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cargas de emergencia no utilizadas</returns>
        public BindingList<CargaTransportadora> listarCargasTransportadorasEmergenciasNoUtilizadas(DateTime f)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasTransportadorasEmergenciasNoUtilizadas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["pk_ID"];
                    byte emergencia = (byte)datareader["Emergencia"];
                  
                    CargaTransportadora carga = new CargaTransportadora(id: id_carga, emergencia: emergencia, fecha_asignada: f);

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
        /// Obtener una lista de las cargas del cierre de un cajero de Transportadoras.
        /// </summary>
        /// <param name="c">Objeto CierreCargaTransportadora con los datos del cierre del cajero de Sucursal</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasTransportadorasPorCierreTransportadoras(CierreCargaTransportadora c)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectListaCargasTransportadorasCierreTransportadoras");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

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
        
        /// <summary>
        /// Obtener una lista de las cargas con montos consolidados para su impresión.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="r">Número de ruta de las cargas que se listarán</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasATMsImpresionConsolidado(Colaborador c, byte? r, DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsImpresionConsolidado");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

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

        /// <summary>
        /// Obtener una lista de las cargas con montos por denominación para su impresión.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="r">Número de ruta de las cargas que se listarán</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasATMsImpresionDetallado(Colaborador c, byte? r, DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsImpresionDetallado");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

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

        /// <summary>
        /// Obtener una lista de las cargas generadas o importadas en una fecha.
        /// </summary>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="e">Transportadora encargada de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasATMsImpresionGeneradasImportadas(DateTime f, EmpresaTransporte e)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsImpresionGeneracionImportacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@transportadora", e, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

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

        /// <summary>
        /// Obtener una lista de las cargas con los datos de la hoja de ruta.
        /// </summary>
        /// <param name="r">Número de ruta de las cargas que se listarán</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasATMsImpresionHojaRuta(byte r, DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsImpresionHojaRuta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

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

        /// <summary>
        /// Obtener los datos de la carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora que representa la carga para la cual se obtienen los datos</param>
        public void obtenerDatosCargaTransportadora(ref CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@pedido", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    DateTime hora_inicio = datareader["Hora_Inicio"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Inicio"];
                    DateTime hora_finalizacion = datareader["Hora_Finalizacion"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Finalizacion"];
                    byte? ruta = datareader["Ruta"] as byte?;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = "";
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    Colaborador registrador = null;

                    if (datareader["Colaborador_Registro"] != DBNull.Value)
                    {
                        int id_registrador = (int)datareader["Colaborador_Registro"];
                        string nombre_registrador = (string)datareader["Nombre_Registrador"];
                        string primer_apellido_registrador = (string)datareader["Primer_Apellido_Registrador"];
                        string segundo_apellido_registrador = (string)datareader["Segundo_Apellido_Registrador"];

                        registrador = new Colaborador(id: id_registrador, nombre: nombre_registrador, primer_apellido: primer_apellido_registrador, segundo_apellido: segundo_apellido_registrador);
 
                    }


                    Tripulacion tripulacion = null;
                    if (datareader["ID_Tripulacion"] != DBNull.Value)
                    {

                        int id_tripulacion = (short)datareader["ID_Tripulacion"];
                        int ruta_trip = (int)datareader["Ruta_Trip"];
                        string descripcion = (string)datareader["Descripcion"];
                        string observaciones_trip = (string)datareader["Observaciones_Trip"];



                        int id_chofer = (int)datareader["ID_Chofer"];
                        string nombre_chofer = (string)datareader["Nombre_Chofer"];
                        string primer_apellido_chofer = (string)datareader["PrimerApellido_Chofer"];
                        string segundo_apellido_chofer = (string)datareader["SegundoApellido_Chofer"];
                        string identificacion_chofer = (string)datareader["Identificacion_Chofer"];

                        int id_custodio = (int)datareader["ID_Custodio"];
                        string nombre_custodio = (string)datareader["Nombre_Custodio"];
                        string primer_apellido_custodio = (string)datareader["PrimerApellido_Custodio"];
                        string segundo_apellido_custodio = (string)datareader["SegundoApellido_Custodio"];
                        string identificacion_custodio = (string)datareader["Identificacion_Custodio"];

                        int id_portavalor = (int)datareader["ID_Portavalor"];
                        string nombre_portavalor = (string)datareader["Nombre_Portavalor"];
                        string primer_apellido_portavalor = (string)datareader["PrimerApellido_Portavalor"];
                        string segundo_apellido_portavalor = (string)datareader["SegundoApellido_Portavalor"];
                        string identificacion_portavalor = (string)datareader["Identificacion_Portavalor"];


                        int id_usuario = (int)datareader["ID_Usuario"];
                        string nombre_usuario = (string)datareader["Nombre_Usuario"];
                        string primer_apellido_usuario = (string)datareader["PrimerApellido_Usuario"];
                        string segundo_apellido_usuario = (string)datareader["SegundoApellido_Usuario"];
                        string identificacion_usuario = (string)datareader["Identificacion_Usuario"];


                        Colaborador chofer = new Colaborador(id_chofer, nombre_chofer, primer_apellido_chofer, segundo_apellido_chofer, identificacion_chofer);
                        Colaborador custodio = new Colaborador(id_custodio, nombre_custodio, primer_apellido_custodio, segundo_apellido_custodio, identificacion_custodio);
                        Colaborador portavalor = new Colaborador(id_portavalor, nombre_portavalor, primer_apellido_portavalor, segundo_apellido_portavalor, identificacion_portavalor);
                        Colaborador usuario = new Colaborador(id_usuario, nombre_usuario, primer_apellido_usuario, segundo_apellido_usuario, identificacion_usuario);


                        short id_atm = (short)datareader["ID_Vehiculo"];
                        string modelo = (string)datareader["Modelo"];
                        string placa = (string)datareader["Placa"];
                        int numeroasoc = (Int32)datareader["NumeroAsociado"];
                        int ordensalida = (Int32)datareader["OrdenSalida"];
                        int id_dispositivo = (Int32)datareader["ID_Dispositivo"];
                        string serial = (string)datareader["Serial"];
                        string descripcion_dispositivo = (string)datareader["Descripcion_Dispositivo"];
                        Vehiculo vehiculo = new Vehiculo(placa: placa, modelo: modelo, numeroasociado: numeroasoc, id: id_atm);
                        Dispositivo dispositivo = new Dispositivo(nombre: serial, id: id_dispositivo, descripcion: descripcion_dispositivo);

                        AsignacionEquipo asignacion = null;

                        if (datareader["ID_Asignacion"] != DBNull.Value)
                        {
                            int idasignacion = (int)datareader["ID_Asignacion"];

                            asignacion = new AsignacionEquipo(id: idasignacion);
                        }


                        tripulacion = new Tripulacion(nombre: descripcion, ruta: ruta_trip, chofer: chofer, custodio: custodio, portavalor: portavalor, id: (short)id_tripulacion, usuario: usuario, observaciones: observaciones_trip, v: vehiculo, ordenSalida: ordensalida, disp: dispositivo);
                        tripulacion.Asignaciones = asignacion;
                    }

                    c.Tripulacion = tripulacion;

                  
                   
                    c.Hora_inicio = hora_inicio;
                    c.Hora_finalizacion = hora_finalizacion;
                    c.Ruta = ruta;
                    c.Orden_ruta = orden_ruta;
                    c.Observaciones = observaciones;
                    c.Colaborador_Registro = registrador;
                   // c.Manifiesto = manifiesto;
                    
               
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
        /// Obtener los datos de la verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora que representa la carga para la cual se obtienen los datos de verificación</param>
        public void obtenerDatosVerificacionCarga(ref CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaTransportadoraDatosVerificacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    DateTime fecha_verificacion = (DateTime)datareader["Fecha_Verificacion"];

                    int id_colaborador = (int)datareader["ID_Colaborador"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    Colaborador colaborador = new Colaborador(id: id_colaborador, nombre: nombre, primer_apellido: primer_apellido,
                                                              segundo_apellido: segundo_apellido);

                    c.Colaborador_verificador = colaborador;
                    c.Fecha_verificacion = fecha_verificacion;
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
        /// Lista de Cargas que se encuentran registrados en el sistema
        /// </summary>
        /// <returns>Un DataTable con las Cargas obtenidos</returns>
        public DataTable listarCargasTransportadorasExportacion(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("[SelectCargaTransportadoraMonitoreoExportar]");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.DateTime);

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




        /// <summary>
        /// Lista las cargas que se van a recibir para enviar a boveda
        /// </summary>
        /// <param name="marchamo">numero de marchamo a buscar</param>
        /// <returns></returns>
        public BindingList<CargaTransportadora> listarCargasSucursal(String marchamo, EstadosCargasSucursales estado, Colaborador coordinador, EntregaRecibo entrega, DateTime fecha, byte?rut)
        {
            BindingList<CargaTransportadora> cargas = new BindingList<CargaTransportadora>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasTransportadoras");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@estado", estado, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@sucursal", coordinador.Sucursal.DB_ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@entrega", entrega, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@ruta", rut, SqlDbType.TinyInt);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];

                    DateTime hora = DateTime.UtcNow;

                    if (datareader["Hora"] != DBNull.Value)
                    {
                        hora = (DateTime)datareader["Hora"];
                    }

                    String nombre = datareader["Nombre"] as string;
                    byte ruta = (byte)datareader["Ruta"];
                    byte order_ruta = (byte)datareader["Orden_Ruta"];
                    EstadosCargasSucursales estad = (EstadosCargasSucursales)datareader["Estado"];
                    DateTime fecha_pedido = (DateTime)datareader["Fecha"];
                    String dato = datareader["Dato"] as string;
                    int id_bolsa = (int)datareader["ID_Bolsa"];
                    Colaborador colaborador = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre_cajero = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segudo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        colaborador = new Colaborador(id: id_cajero, nombre: nombre_cajero, primer_apellido: primer_apellido, segundo_apellido: segudo_apellido);
                    }


                    CargaTransportadora carga = new CargaTransportadora(id: id_carga, cajero: colaborador, ruta: ruta, orden_ruta: order_ruta, fecha_verificacion: hora,
                                                            estado: estad, nombre: nombre, dato: dato);
                    carga.IdBolsa = id_bolsa;
                    ////********* hora fecha asignada

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
        /// Obtener los manifiestos del pedido de un Banco
        /// </summary>
        /// <param name="p">Objeto CargaTransportadora que representa el pedido para la cual se obtienen los datos</param>
        public void obtenerManifiestosCargaTransportadora(ref CargaTransportadora p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosCargaTransportadora");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", p, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {


                    ManfiestoTransportadoraCarga manifiesto = null;

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id = (int)datareader["ID_Manifiesto"];

                        manifiesto = new ManfiestoTransportadoraCarga(id: id);
                    }


                    p.agregarManifiesto(manifiesto);


                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        #region Recepcion de Tulas

        /// <summary>
        /// Registrar en el sistema la recepcion de la carga de una Sucursal
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void agregarRecepcionTulaCargaTransportadora(ref CargaTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraRecepcionBlindados");
            TipoEntregas entregado = 0;
            TipoEntregas recibido = 0;
            _manejador.agregarParametro(comando, "@carga", c.IdBolsa, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@pedido", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@usuario", c.ColaboradorRecibidoBoveda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora_recibido", c.HoraRecibidoBoveda, SqlDbType.DateTime);
            if (c.TipoEntregas == TipoEntregas.Recibido)
            {
                _manejador.agregarParametro(comando, "@recibido", c.TipoEntregas, SqlDbType.Bit);
                _manejador.agregarParametro(comando, "@entregado", entregado, SqlDbType.Bit);

            }
            else
            {
                if (c.TipoEntregas == TipoEntregas.Entregado)
                {
                    _manejador.agregarParametro(comando, "@recibido", recibido, SqlDbType.Bit);
                    _manejador.agregarParametro(comando, "@entregado", c.TipoEntregas, SqlDbType.Bit);

                }
            }



            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaTransportadoraRegistro");
            }

        }





        ///// <summary>
        ///// Registrar en el sistema la recepcion de la carga de una Sucursal
        ///// </summary>
        ///// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        //public void agregarRecepcionTulaCargaTransportadora(ref CargaTransportadora c)
        //{
        //    SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaTransportadoraRecepcionBlindados");

        //    _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);
        //    _manejador.agregarParametro(comando, "@usuario", c.ColaboradorRecibidoBoveda, SqlDbType.Int);
        //    _manejador.agregarParametro(comando, "@hora_recibido", c.HoraRecibidoBoveda, SqlDbType.DateTime);
        //    _manejador.agregarParametro(comando, "@recibido", c.TipoEntregas, SqlDbType.Bit);


        //    try
        //    {
        //        _manejador.ejecutarConsultaActualizacion(comando);
        //        comando.Connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        comando.Connection.Close();
        //        throw new Excepcion("ErrorCargaTransportadoraRegistro");
        //    }

        //}


        #endregion Recepcion de Tulas
        #endregion Métodos Públicos

    }
}
