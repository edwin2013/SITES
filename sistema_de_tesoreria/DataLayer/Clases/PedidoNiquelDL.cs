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
    public class PedidoNiquelDL : ObjetoIndexado
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PedidoNiquelDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PedidoNiquelDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PedidoNiquelDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;
        SucursalesDL _sucursales = SucursalesDL.Instancia;

        #endregion Atributos

        #region Constructor

        public PedidoNiquelDL() { }

        #endregion Constructor

        #region Métodos Públicos




        /// <summary>
        /// Registrar en el sistema la carga de un PuntoVenta.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga/param>
        public void agregarPedidoNiquel(ref PedidoNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPedidoNiquel");

            _manejador.agregarParametro(comando, "@cliente", c.PuntoVenta.Id, SqlDbType.SmallInt);

            _manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha_asignada, SqlDbType.DateTime);
            //_manejador.agregarParametro(comando, "@entregaaboveda", c.EntregaBovedaSucursal , SqlDbType.Bit);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPedidoNiquelRegistro");
            }


        }

        /// <summary>
        /// Actualizar los datos de la carga de un PuntoVenta.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void actualizarPedidoNiquel(PedidoNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoNiquel");

            _manejador.agregarParametro(comando, "@cliente", c.PuntoVenta.Id, SqlDbType.Int);
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
        /// Asignar la carga de un PuntoVenta a un cajero.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void actualizarPedidoNiquelColaborador(PedidoNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoNiquelCajero");

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);

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
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void actualizarPedidoNiquelDatosVerificacion(PedidoNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoNiquelDatosVerificacion");

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
        /// Eliminar los datos de una carga de un PuntoVenta.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void eliminarPedidoNiquel(PedidoNiquel c, Colaborador col)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePedidoNiquel");

            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);
           // _manejador.agregarParametro(comando, "@comentario", c.Comentario_Eliminacion, SqlDbType.NVarChar);

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
        /// Ligar o desligar la carga de una PuntoVenta del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void actualizarPedidoNiquelCierreNiquel(PedidoNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePedidoNiquelCierreNiquel");

            _manejador.agregarParametro(comando, "@cierre", c.Cierre, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);

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
        /// <param name="c">Objeto CierreNiquel con los datos del cierre del cajero de ATM's</param>
        public void obtenerPedidoNiquelCierreNiquel(ref CierreNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosNiquelCierreNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    string observaciones = "";
                   
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    
                    
                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    PuntoVenta sucursal = null;

                    if (datareader["ID_PuntoVenta"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_PuntoVenta"];
                        string nombre = (string)datareader["PuntoVenta_Nombre"];

                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Cliente_Nombre"];

                        Cliente cliente = new Cliente(id_cliente, nombre_cliente);

                        sucursal = new PuntoVenta(id: id, nombre: nombre, cliente: cliente);
                        //_sucursales.obtenerDiasPedidoNiquel(ref sucursal);

                    }

                    DateTime fecha_asignada = Convert.ToDateTime(datareader["Fecha_Asignada"]);

                    PedidoNiquel carga = new PedidoNiquel(sucursal: sucursal, id: id_carga, transportadora: empresa, fecha_asignada: fecha_asignada);
                   
                
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
       /// Lista todas las cargas a sucursales de una fecha especifica
       /// </summary>
       /// <param name="s">Objeto PuntoVenta con los datos de la sucursal a filtrar</param>
       /// <param name="f">Fecha a filtrar</param>
       /// <param name="r">Ruta a filtrar</param>
       /// <returns>Una lista con los datos de las cargas a las sucursales</returns>
        public BindingList<PedidoNiquel> listarPedidosNiquel(PuntoVenta s, DateTime f, Cliente cl, EmpresaTransporte emp)
        {
            BindingList<PedidoNiquel> cargas = new BindingList<PedidoNiquel>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidoNiquelMonitoreo");
            SqlDataReader datareader = null;


         if (s != null)
            _manejador.agregarParametro(comando, "@canal", s.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
        if (cl != null)
            _manejador.agregarParametro(comando, "@cliente", cl.Id , SqlDbType.SmallInt);
        if (emp != null) 
            _manejador.agregarParametro(comando, "@empresa", emp.ID, SqlDbType.SmallInt);

    

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                   
                    string observaciones = "";
                   
                    DateTime fecha_asignada = DateTime.Now;
 
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";
                    
                   
                    if (datareader["Fecha_Asignada"] != DBNull.Value)
                        fecha_asignada = (DateTime)datareader["Fecha_Asignada"];

                 
                    
                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    PuntoVenta sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Sucursal_Nombre"];

                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Cliente_Nombre"];

                        Cliente cliente = new Cliente(id_cliente, nombre_cliente);

                        sucursal = new PuntoVenta(id: id, nombre: nombre, cliente: cliente);
                        


                    }


                    Colaborador cajero = null;

                    if (datareader["ID_Colaborador"] != DBNull.Value)
                    {
                        int id_col = (int)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Cajero_Nombre"];
                        string primerapellido = (string)datareader["Cajero_PrimerApellido"];
                        string segudoapellido = (string)datareader["Cajero_SegundoApellido"];




                        cajero = new Colaborador(id: id_col, nombre: nombre, primer_apellido: primerapellido, segundo_apellido: segudoapellido);
                    }


                    PedidoNiquel carga = new PedidoNiquel(sucursal: sucursal, id: id_carga, transportadora: empresa, 
                                                            fecha_asignada: fecha_asignada, cajero:cajero);

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
        /// Encuentra las cargas de Sucursales por Manifiestos
        /// </summary>
        /// <param name="c">Colaborador del Registro</param>
        /// <param name="s">PuntoVenta a buscar</param>
        /// <param name="f">Fecha de los pedidos</param>
        /// <param name="r">Ruta</param>
        /// <param name="est">Estado del pedido</param>
        /// <returns></returns>
        public BindingList<PedidoNiquel> listarPedidoNiquelManifiesto(Colaborador c, PuntoVenta s, DateTime f, byte? r, EstadoAprobacionCargas est)
        {
            BindingList<PedidoNiquel> cargas = new BindingList<PedidoNiquel>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidoNiquelManifiesto");
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
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    byte? ruta = datareader["Ruta"] as byte?;
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

                    PuntoVenta sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Sucursal_Nombre"];

                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Cliente_Nombre"];

                        Cliente cliente = new Cliente(id_cliente, nombre_cliente);

                        sucursal = new PuntoVenta(id: id, nombre: nombre, cliente: cliente);
                        

                        //_sucursales.obtenerDiasPedidoNiquel(ref sucursal);

                    }

                    PedidoNiquel carga = new PedidoNiquel(sucursal: sucursal, emergencia: emergencia, id: id_carga, transportadora: empresa, ruta: ruta, orden_ruta: orden_ruta, distancia: distancia, hora_programada: hora_programada, tiempoviaje: tiempo_viaje);

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
        /// Obtener los datos de los colaboradores de la carga de un PuntoVenta.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel que representa la carga para la cual se obtienen los datos</param>
        public void obtenerColaboradoresPedidoNiquel(ref PedidoNiquel c)
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
        public bool verificarExisteCargaVerificada(PedidoNiquel c)
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
        /// Lista todas las cargas a sucursales de una fecha especifica
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos de la sucursal a filtrar</param>
        /// <param name="f">Fecha a filtrar</param>
        /// <param name="r">Ruta a filtrar</param>
        /// <returns>Una lista con los datos de las cargas a las sucursales</returns>
        public BindingList<PedidoNiquel> listarPedidosNiquelSinAsignarCajero(PuntoVenta s, DateTime f)
        {
            BindingList<PedidoNiquel> cargas = new BindingList<PedidoNiquel>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidoNiquelSinAsignar");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@canal", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
 

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];

                    
                  
                    string observaciones = "";
                   

                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    PuntoVenta sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Sucursal_Nombre"];

                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Cliente_Nombre"];

                        Cliente cliente = new Cliente(id_cliente, nombre_cliente);

                        sucursal = new PuntoVenta(id: id, nombre: nombre, cliente: cliente);
                        

                        //_sucursales.obtenerDiasPedidoNiquel(ref sucursal);

                    }

                    PedidoNiquel carga = new PedidoNiquel(sucursal: sucursal,  id: id_carga, transportadora: empresa);

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
        public BindingList<PedidoNiquel> listarPedidosNiquelPorCajero(Colaborador c)
        {
            BindingList<PedidoNiquel> cargas = new BindingList<PedidoNiquel>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosNiquelCajero");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];



                    string observaciones = "";


                    EmpresaTransporte empresa = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Transportadora_Nombre"];

                        empresa = new EmpresaTransporte(nombre: nombre, id: Convert.ToByte(id_empresa));
                    }

                    PuntoVenta sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Sucursal_Nombre"];

                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Cliente_Nombre"];

                        Cliente cliente = new Cliente(id_cliente, nombre_cliente);

                        sucursal = new PuntoVenta(id: id, nombre: nombre, cliente: cliente);


                        //_sucursales.obtenerDiasPedidoNiquel(ref sucursal);

                    }

                    PedidoNiquel carga = new PedidoNiquel(sucursal: sucursal, id: id_carga, transportadora: empresa);

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
        /// Obtener una lista de las cargas del cierre de un cajero de Sucursales.
        /// </summary>
        /// <param name="c">Objeto CierreNiquel con los datos del cierre del cajero de PuntoVenta</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarPedidoNiquelPorCierreNiquel(CierreNiquel c)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectListaPedidoNiquelCierreNiquel");
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
        /// Obtener los datos de la carga de un PuntoVenta.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel que representa la carga para la cual se obtienen los datos</param>
        public void obtenerDatosPedidoNiquel(ref PedidoNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidoNiquelDatos");
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
                  

                    string observaciones = "";
                    if (datareader["Observaciones"] != DBNull.Value)
                        observaciones = (string)datareader["Observaciones"] ?? "";


                   
                  
                   
                    c.Hora_inicio = hora_inicio;
                    c.Hora_finalizacion = hora_finalizacion;
                    c.Observaciones = observaciones;
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
        /// <param name="c">Objeto PedidoNiquel que representa la carga para la cual se obtienen los datos de verificación</param>
        public void obtenerDatosVerificacionCarga(ref PedidoNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosNiquelDatosVerificacion");
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
        /// Lista las cargas que se van a recibir para enviar a boveda
        /// </summary>
        /// <param name="marchamo">numero de marchamo a buscar</param>
        /// <returns></returns>
        public BindingList<PedidoNiquel> listarCargasSucursal(String marchamo,  Colaborador coordinador, EntregaRecibo entrega, DateTime fecha, byte?rut)
        {
            BindingList<PedidoNiquel> cargas = new BindingList<PedidoNiquel>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@sucursal", coordinador, SqlDbType.Int);
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


                    PedidoNiquel carga = new PedidoNiquel(id: id_carga, cajero: colaborador, ruta: ruta, orden_ruta: order_ruta,
                                                             nombre: nombre, dato: dato);
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
        /// <param name="p">Objeto PedidoNiquel que representa el pedido para la cual se obtienen los datos</param>
        public void obtenerManifiestosPedidoNiquel(ref PedidoNiquel p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosPedidoNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", p, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {


                    ManifiestoNiquelPedido manifiesto = null;

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id = (int)datareader["ID_Manifiesto"];
                        string codigo = (string)datareader["Codigo"];

                        manifiesto = new ManifiestoNiquelPedido(id: id, codigo: codigo);
                    }


                   p.agregarManifiesto(manifiesto);


                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        /// <summary>
        /// Obtener una lista de las cargas del cierre de un cajero de Sucursales.
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cierre del cajero de Sucursal</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarPedidosNiquelPorCierreNiquel(CierreCargaSucursal c)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectListaPedidosNiquelCierreNiquel");
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
        /// Obtiene los datos de una bolsa completa
        /// </summary>
        /// <param name="b"></param>
        public void obtenerDatosBolsasCompletas(ref BolsaCompletaNiquel b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosBolsaCompleta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@denominacion", b.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto_venta", b.PuntoVenta, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    
                    int cantidad_piezas = 0;
                    int tipo = 0;

         

                    if (datareader["Cantidad"] != DBNull.Value)
                    {
                        cantidad_piezas = Convert.ToInt32((decimal)datareader["Cantidad"]);
                    }

                    if (datareader["tipo"] != DBNull.Value)
                    {
                        tipo = (int)datareader["tipo"];
                    }

                    b.CantidadPiezasBolsa = cantidad_piezas;
                    b.TipoBolsa = tipo;



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
