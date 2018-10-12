using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System.Data.SqlClient;
using System.Data;
using CommonObjects.Clases;
using System.ComponentModel;
using CommonObjects;

namespace DataLayer.Clases
{
    public class PedidoBancoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PedidoBancoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PedidoBancoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PedidoBancoDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PedidoBancoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Obtener datos de portavalor asignado a un Pedido de Banco
        /// </summary>
        /// <param name="c">Carga asignada al portavalor</param>
        /// <returns>Datos del portavalor</returns>
        public void listarPotavalorPedidoBanco(ref PedidoBancos p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPortavalorAsignadoCargaATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@ruta", p.Ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", p.Fecha_asignada, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@carga", p.DB_ID, SqlDbType.Int);

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

                    p.ColaboradorRecibidoBoveda = new Colaborador(id, nombre: nombre, primer_apellido: primer_apellido,
                                                                 segundo_apellido: segundo_apellido, identificacion: identificacion);

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
        /// Registrar en el sistema la carga de un Banco.
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void agregarPedidoBanco(ref PedidoBancos c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPedidoBanco");

            _manejador.agregarParametro(comando, "@banco", Convert.ToInt16(c.Canal.Id), SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha_asignada", c.Fecha_asignada, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_pedido", c.Fecha_pedido, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@registrador", c.Colaborador_Registro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@montoganancia", c.MontoGanancia, SqlDbType.Decimal);

 
            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPedidoBancoRegistro");
            }

        }




        /// <summary>
        /// Listar las cargas por fecha, cajero, Canal y ruta.
        /// </summary>
        /// <param name="t">Objeto Tripulacion con los datos del Canal para el cual se genera la lista</param>
        /// <param name="c">Objeto Canal con los datos del Canal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta de las cargas que se listarán</param>
        public BindingList<PedidoBancos> listarPedidoBancoss(Tripulacion t, Canal c, DateTime f, byte? r)
        {
            BindingList<PedidoBancos> pedidos = new BindingList<PedidoBancos>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosBancoMonitoreo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tripulacion", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@canal", c, SqlDbType.SmallInt);
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
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = "";
                    DateTime hora_programada = DateTime.Now;
                    DateTime hora_entrada = DateTime.Now;
                    DateTime hora_salida = DateTime.Now;
                    float distancia = 0;
                    int tiempo_viaje = 0;

                    if (datareader["Observaciones"] != DBNull.Value)
                         observaciones = (string)datareader["Observaciones"] ?? "";

                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Salida"];
                    
                   

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];
 
                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    Canal canal = null;

                    if (datareader["ID_Canal"] != DBNull.Value)
                    {
                        byte id_canal = (byte)datareader["ID_Canal"];
                        string nombre = (string)datareader["Canal_Nombre"];

                        canal = new Canal(Convert.ToByte(id_canal), nombre, empresa);
                    }

                    Tripulacion tripulacion = null;

                    if (datareader["ID_Tripulacion"] != DBNull.Value)
                    {
                        short id_tripulacion = (short)datareader["ID_Tripulacion"];
                      

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

                        short id_vehiculo = (short)datareader["ID_Vehiculo"];
                        string placa = (string)datareader["Placa"];
                        int numero_asociado = (int)datareader["Numero_Asociado"];
                        string modelo = (string)datareader["Modelo"];


                       


                        Colaborador chofer = new Colaborador(id_chofer, nombre_chofer, primer_apellido_chofer, segundo_apellido_chofer, identificacion_chofer);
                        Colaborador custodio = new Colaborador(id_custodio, nombre_custodio, primer_apellido_custodio, segundo_apellido_custodio, identificacion_custodio);
                        Colaborador portavalor = new Colaborador(id_portavalor, nombre_portavalor, primer_apellido_portavalor, segundo_apellido_portavalor, identificacion_portavalor);
                        Colaborador usuario = new Colaborador(id_usuario, nombre_usuario, primer_apellido_usuario, segundo_apellido_usuario, identificacion_usuario);

                        Vehiculo vehiculo = new Vehiculo(id: id_vehiculo, placa: placa,modelo:modelo, numeroasociado: numero_asociado);
                        tripulacion = new Tripulacion(chofer: chofer, custodio: custodio, portavalor: portavalor, id: id_tripulacion, usuario: usuario,v:vehiculo);
                        
                    }

                    Colaborador cajero = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre_cajero = (string)datareader["Nombre_Cajero"];
                        string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                        string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                        cajero = new Colaborador(id: id_cajero, nombre: nombre_cajero, primer_apellido: primer_apellido_cajero, segundo_apellido: segundo_apellido_cajero);

                    }

                    PedidoBancos pedido = new PedidoBancos(canal: canal, emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta,tripulacion:tripulacion, cajero: cajero);

                    pedidos.Add(pedido);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return pedidos;
        }





        /// <summary>
        /// Listar las cargas por fecha, cajero, Canal y ruta.
        /// </summary>
        /// <param name="t">Objeto Tripulacion con los datos del Canal para el cual se genera la lista</param>
        /// <param name="c">Objeto Canal con los datos del Canal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta de las cargas que se listarán</param>
        public BindingList<PedidoBancos> listarPedidoBancossRoadnet(Tripulacion t, Canal c, DateTime f, byte? r)
        {
            BindingList<PedidoBancos> pedidos = new BindingList<PedidoBancos>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosBancoMonitoreoRoadnet");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tripulacion", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@canal", c, SqlDbType.SmallInt);
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
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = "";
                    DateTime hora_programada = DateTime.Now;
                    DateTime hora_entrada = DateTime.Now;
                    DateTime hora_salida = DateTime.Now;
                    float distancia = 0;
                    int tiempo_viaje = 0;

                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";

                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Salida"];



                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    Canal canal = null;

                    if (datareader["ID_Canal"] != DBNull.Value)
                    {
                        byte id_canal = (byte)datareader["ID_Canal"];
                        string nombre = (string)datareader["Canal_Nombre"];

                        canal = new Canal(Convert.ToByte(id_canal), nombre, empresa);
                    }

                    Tripulacion tripulacion = null;

                    if (datareader["ID_Tripulacion"] != DBNull.Value)
                    {
                        short id_tripulacion = (short)datareader["ID_Tripulacion"];


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


                        //int id_usuario = (int)datareader["ID_Usuario"];
                        //string nombre_usuario = (string)datareader["Nombre_Usuario"];
                        //string primer_apellido_usuario = (string)datareader["PrimerApellido_Usuario"];
                        //string segundo_apellido_usuario = (string)datareader["SegundoApellido_Usuario"];
                        //string identificacion_usuario = (string)datareader["Identificacion_Usuario"];

                        short id_vehiculo = (short)datareader["ID_Vehiculo"];
                        string placa = (string)datareader["Placa"];
                        int numero_asociado = (int)datareader["Numero_Asociado"];
                        string modelo = (string)datareader["Modelo"];





                        Colaborador chofer = new Colaborador(id_chofer, nombre_chofer, primer_apellido_chofer, segundo_apellido_chofer, identificacion_chofer);
                        Colaborador custodio = new Colaborador(id_custodio, nombre_custodio, primer_apellido_custodio, segundo_apellido_custodio, identificacion_custodio);
                        Colaborador portavalor = new Colaborador(id_portavalor, nombre_portavalor, primer_apellido_portavalor, segundo_apellido_portavalor, identificacion_portavalor);
                        Colaborador usuario = new Colaborador();

                        Vehiculo vehiculo = new Vehiculo(id: id_vehiculo, placa: placa, modelo: modelo, numeroasociado: numero_asociado);
                        tripulacion = new Tripulacion(chofer: chofer, custodio: custodio, portavalor: portavalor, id: id_tripulacion, usuario: usuario, v: vehiculo);

                    }


                    PedidoBancos pedido = new PedidoBancos(canal: canal, emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, tripulacion: tripulacion);

                    pedidos.Add(pedido);
                }

                comando.Connection.Close();
            }
             catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return pedidos;
        }




        /// <summary>
        /// Actualizar los datos de la carga de un Banco.
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBanco(PedidoBancos c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoBanco");

            _manejador.agregarParametro(comando, "@hora_inicio", c.Hora_inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_finalizacion", c.Hora_finalizacion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@banco", c.Canal.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@empresa", c.Transportadora.ID, SqlDbType.TinyInt);
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
        /// Asignar la carga de un banco a un cajero
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBancoscajero(PedidoBancos c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoBancoCajero");

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
        /// Actualiza los datos de rutas y tiempo desde el roadnet
        /// </summary>
        /// <param name="f"></param>
        public void actualizarCargaBancoDatosRoadnet(DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoBancoDesdeRoadnet");

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

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
        public void actualizarCargaATMRuta(CargaSucursal c)
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
        /// Asignar la ruta y la hora de llegada a la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMRutaHora(ref CargaSucursal c)
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
        public void actualizarCargaATMRutaHoraImportacion(ref CargaSucursal c)
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
        /// <param name="p">Objeto CargaATM con los datos de la carga</param>
        public void actualizarPedidoBancoOrdenRuta(PedidoBancos p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoBancoOrdenRuta");

            _manejador.agregarParametro(comando, "@orden", p.Orden_ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga", p, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPedidoBancoActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMDatosVerificacion(CargaSucursal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMDatosVerificacion");

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
        /// Eliminar los datos de un pedido de un banco.
        /// </summary>
        /// <param name="c">Objeto PedidoBanco con los datos del pedido</param>
        public void eliminarPedidoBanco(PedidoBancos c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePedidoBanco");

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPedidoBancoEliminacion");
            }

        }



        /// <summary>
        /// Lista todas las cargas a sucursales de una fecha especifica
        /// </summary>
        /// <param name="s">Objeto Canal con los datos del canal a filtrar</param>
        /// <param name="f">Fecha a filtrar</param>
        /// <param name="r">Ruta a filtrar</param>
        /// <returns>Una lista con los datos de las cargas a los bancos</returns>
        public BindingList<PedidoBancos> listarPedidosBancosSinAsignarCajero(Canal s, DateTime f, byte? r)
        {
            BindingList<PedidoBancos> cargas = new BindingList<PedidoBancos>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidoBancoSinAsignar");
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
                    //bool variable = (bool)datareader["Entrega"];
                    //int opcion = 0;
                    //if (variable)
                    //{
                    //    opcion = 1;
                    //}

                    //EntregaRecibo entregarecibo = (EntregaRecibo)opcion;
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

                    Canal canal = null;

                    if (datareader["ID_Canal"] != DBNull.Value)
                    {
                        byte id_canal = (byte)datareader["ID_Canal"];
                        string nombre = (string)datareader["Canal_Nombre"];

                        canal = new Canal(Convert.ToByte(id_canal), nombre, empresa);





                        //_sucursales.obtenerDiasCargaSucursal(ref sucursal);

                    }

                    PedidoBancos carga = new PedidoBancos(canal: canal, emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, distancia: distancia, hora_roadnet: hora_programada, tiempoviaje: tiempo_viaje,estado: estado);
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
        /// Listar las cargas asignadas un cajero de Sucursales.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales</param>
        public BindingList<PedidoBancos> listarPedidosBancoPorCajero(Colaborador c)
        {
            BindingList<PedidoBancos> cargas = new BindingList<PedidoBancos>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidoBancosCajero");
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
                    //bool variable = (bool)datareader["Entrega"];
                    //int opcion = 0;
                    //if (variable)
                    //{
                    //    opcion = 1;
                    //}

                    //EntregaRecibo entregarecibo = (EntregaRecibo)opcion;
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

                    Canal canal = null;

                    if (datareader["ID_Canal"] != DBNull.Value)
                    {
                        byte id_canal = (byte)datareader["ID_Canal"];
                        string nombre = (string)datareader["Canal_Nombre"];

                        canal = new Canal(Convert.ToByte(id_canal), nombre, empresa);





                        //_sucursales.obtenerDiasCargaSucursal(ref sucursal);

                    }

                    PedidoBancos carga = new PedidoBancos(canal: canal, emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, distancia: distancia, hora_roadnet: hora_programada, tiempoviaje: tiempo_viaje);
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
        /// Lista de Cargas que se encuentran registrados en el sistema
        /// </summary>
        /// <returns>Un DataTable con las Cargas obtenidos</returns>
        public DataTable listarCargasATMsExportacion(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsMonitoreoExportar");
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
        /// Obtener los datos del pedido de un Banco
        /// </summary>
        /// <param name="p">Objeto PedidoBancos que representa el pedido para la cual se obtienen los datos</param>
        public void obtenerDatosPedidoBanco(ref PedidoBancos p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidoBancoDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@pedido", p, SqlDbType.Int);

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

                    //ManifiestoPedidoBanco manifiesto = null;

                    //if (datareader["ID_Manifiesto"] != DBNull.Value)
                    //{
                    //    int id = (int)datareader["ID_Manifiesto"];
                    //    string codigo = (string)datareader["Codigo_Manifiesto"];
                    //    string marchamo = (string)datareader["Marchamo_Manifiesto"];
                    //    string marchamo_adicional = (string)datareader["Marchamo_Adicional"];
                    //    DateTime fecha = (DateTime)datareader["Fecha_Manifiesto"];

                    //    manifiesto = new ManifiestoPedidoBanco(fecha,  marchamo_adicional,marchamo, id: id);
                    //}

                   
                    p.Hora_inicio = hora_inicio;
                    p.Hora_finalizacion = hora_finalizacion;
                    p.Ruta = ruta;
                    p.Orden_ruta = orden_ruta;
                    p.Observaciones = observaciones;
                   // p.Manifiesto = manifiesto;


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
        /// Obtener los manifiestos del pedido de un Banco
        /// </summary>
        /// <param name="p">Objeto PedidoBancos que representa el pedido para la cual se obtienen los datos</param>
        public void obtenerManifiestosPedidoBanco(ref PedidoBancos p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosPedidoBancos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", p, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {


                    ManifiestoPedidoBanco manifiesto = null;

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id = (int)datareader["ID_Manifiesto"];

                        manifiesto = new ManifiestoPedidoBanco(id: id);
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



        /// <summary>
        /// Lista de Cargas que se encuentran registrados en el sistema
        /// </summary>
        /// <returns>Un DataTable con las Cargas obtenidos</returns>
        public DataTable listarCargasBancosExportacion(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosBancoMonitoreoExportar");
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
        /// Obtener las cargas del cierre de un cajero de Boveda
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cierre del cajero de ATM's</param>
        public void obtenerCargasBancoCierreBanco(ref CierreCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasBancosCierreBancos");
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

                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    if (datareader["Distancia"] != DBNull.Value)
                        distancia = (float)Convert.ToDouble(datareader["Distancia"]);
                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                        tiempo_viaje = (int)datareader["Tiempo_Viaje"];
                    if (datareader["Hora_Programada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Programada"];
                    if (datareader["Hora_Entrada"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Entrada"];
                    if (datareader["Hora_Salida"] != DBNull.Value)
                        hora_programada = (DateTime)datareader["Hora_Salida"];



                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    Canal canal = null;

                    if (datareader["ID_Canal"] != DBNull.Value)
                    {
                        byte id_canal = (byte)datareader["ID_Canal"];
                        string nombre = (string)datareader["Canal_Nombre"];

                        canal = new Canal(Convert.ToByte(id_canal), nombre, empresa);
                    }

                    Tripulacion tripulacion = null;

                    if (datareader["ID_Tripulacion"] != DBNull.Value)
                    {
                        short id_tripulacion = (short)datareader["ID_Tripulacion"];


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

                        short id_vehiculo = (short)datareader["ID_Vehiculo"];
                        string placa = (string)datareader["Placa"];
                        int numero_asociado = (int)datareader["Numero_Asociado"];
                        string modelo = (string)datareader["Modelo"];





                        Colaborador chofer = new Colaborador(id_chofer, nombre_chofer, primer_apellido_chofer, segundo_apellido_chofer, identificacion_chofer);
                        Colaborador custodio = new Colaborador(id_custodio, nombre_custodio, primer_apellido_custodio, segundo_apellido_custodio, identificacion_custodio);
                        Colaborador portavalor = new Colaborador(id_portavalor, nombre_portavalor, primer_apellido_portavalor, segundo_apellido_portavalor, identificacion_portavalor);
                        Colaborador usuario = new Colaborador(id_usuario, nombre_usuario, primer_apellido_usuario, segundo_apellido_usuario, identificacion_usuario);

                        Vehiculo vehiculo = new Vehiculo(id: id_vehiculo, placa: placa, modelo: modelo, numeroasociado: numero_asociado);
                        tripulacion = new Tripulacion(chofer: chofer, custodio: custodio, portavalor: portavalor, id: id_tripulacion, usuario: usuario, v: vehiculo);

                    }


                    PedidoBancos pedido = new PedidoBancos(canal: canal, emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, tripulacion: tripulacion);

                    c.agregarCarga(pedido);
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
        /// Ligar o desligar la carga de un Banco del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBancoCierreBanco(PedidoBancos c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoBancoCierreBancos");

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
        /// Obtener los datos de la verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto PedidoBanco que representa la carga para la cual se obtienen los datos de verificación</param>
        public void obtenerDatosVerificacionCarga(ref PedidoBancos c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaBancoDatosVerificacion");
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
        /// Obtener una lista de las cargas del cierre de un cajero de Banco.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre del cajero de Banco</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasBancosPorCierreBancos(CierreCargaBanco c)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectListaCargasBancosCierreBancos");
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
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBancoDatosVerificacion(PedidoBancos c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoBancoDatosVerificacion");

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


        #region Recepcion de Tulas

        /// <summary>
        /// Registrar en el sistema la recepcion de la carga de un banco
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void agregarRecepcionTulaPedidoBanco(ref PedidoBancos c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoBancoRecepcionBlindados");

            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@usuario", c.ColaboradorRecibidoBoveda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora_recibido", c.HoraRecibidoBoveda, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@recibido", c.TipoEntregas, SqlDbType.Bit);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaSucursalRegistro");
            }

        }


        #endregion Recepcion de Tulas

        #endregion Métodos Públicos



        
    }
}
