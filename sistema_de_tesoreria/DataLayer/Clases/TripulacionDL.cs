using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using CommonObjects;
using LibreriaMensajes;
using System.Data;
using System.ComponentModel;
using CommonObjects.Clases;

namespace DataLayer
{
    public class TripulacionDL
    {
        
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TripulacionDL _instancia;
        private static ColaboradoresDL _colaboradores;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TripulacionDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TripulacionDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TripulacionDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una Tripulacion
        /// </summary>
        /// <param name="t">Objeto Tripulacion con los datos de la Tripulacion</param>
        public void agregarTripulacion(ref Tripulacion t, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTripulacion");

            _manejador.agregarParametro(comando, "@descripcion", t.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@ruta", t.Ruta, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@chofer", t.Chofer, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@custodio", t.Custodio, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@portavalor", t.Portavalor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@observaciones", t.Observaciones, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@usuario", t.Usuario, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@vehiculo", t.Vehiculo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ordensalida", t.OrdenSalida, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@dispositivo", t.Dispostivo, SqlDbType.Int);
            
            try
            {
                t.ID= (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTripulacionRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una Tripulacion en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tripulacion con los datos del Vehiculo</param>
        public void actualizarTripulacion(ref Tripulacion t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTripulacion");

            _manejador.agregarParametro(comando, "@descripcion", t.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@ruta", t.Ruta, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@chofer", t.Chofer.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@custodio", t.Custodio.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@portavalor", t.Portavalor.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tripulacion", t, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@observaciones", t.Observaciones, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@usuario", t.Usuario, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@vehiculo", t.Vehiculo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ordensalida", t.OrdenSalida, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@dispositivo", t.Dispostivo, SqlDbType.Int);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorActualizarTripulacion");
            }

        }




        /// <summary>
        /// Actualizar los datos de una Tripulacion en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tripulacion con los datos del Vehiculo</param>
        public void actualizarDatosSincronizacionHH(ref Tripulacion t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateReinicioValoresHH");

            _manejador.agregarParametro(comando, "@tripulacion", t, SqlDbType.SmallInt);
 


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorActualizarTripulacion");
            }

        }
        
        /// <summary>
        /// Eliminar los datos de una Tripulacion.
        /// </summary>
        /// <param name="t">Objeto Tripulacion con los datos de la Tripulacion a eliminar</param>
        public void eliminarTripulacion(ref Tripulacion t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTripulacion");

            _manejador.agregarParametro(comando, "@tripulacion", t, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTripulacionEliminacion");
            }

        }

        /// <summary>
        /// Listar las Tripulaciones registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las Tripulaciones registradas en el sistema</returns>
        public BindingList<Tripulacion> listarTripulaciones(string b, DateTime f)
        {
            BindingList<Tripulacion> tripulaciones = new BindingList<Tripulacion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTripulaciones");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@filtro", b, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_tripulacion = (short)datareader["ID_Tripulacion"];
                    int ruta = (int)datareader["Ruta"];
                    string descripcion = (string)datareader["Descripcion"];
                    string observaciones = (string)datareader["Observaciones"];



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
                    Dispositivo dispositivo = new Dispositivo(nombre: serial, id: id_dispositivo,descripcion:descripcion_dispositivo);

                    AsignacionEquipo asignacion = null;

                    if (datareader["ID_Asignacion"] != DBNull.Value)
                    {
                        int idasignacion = (int)datareader["ID_Asignacion"];

                        asignacion = new AsignacionEquipo(id: idasignacion);
                    }


                    Tripulacion tripulacion = new Tripulacion(nombre: descripcion, ruta: ruta, chofer: chofer, custodio: custodio, portavalor: portavalor, id: id_tripulacion,usuario:usuario,observaciones:observaciones,v:vehiculo, ordenSalida:ordensalida,disp:dispositivo);
                    tripulacion.Asignaciones = asignacion;
                    tripulaciones.Add(tripulacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tripulaciones;
        }





        /// <summary>
        /// Listar las Tripulaciones registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las Tripulaciones registradas en el sistema</returns>
        public Tripulacion listarTripulacionRuta(int b, DateTime f)
        {
            Tripulacion tripulaciones = new Tripulacion();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTripulacionesRuta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@ruta", b, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_tripulacion = (short)datareader["ID_Tripulacion"];
                    int ruta = (int)datareader["Ruta"];
                    string descripcion = (string)datareader["Descripcion"];
                    string observaciones = (string)datareader["Observaciones"];



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


                    Tripulacion tripulacion = new Tripulacion(nombre: descripcion, ruta: ruta, chofer: chofer, custodio: custodio, portavalor: portavalor, id: id_tripulacion, usuario: usuario, observaciones: observaciones, v: vehiculo, ordenSalida: ordensalida, disp: dispositivo);
                    tripulacion.Asignaciones = asignacion;

                    tripulaciones = tripulacion;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tripulaciones;
        }





        /// <summary>
        /// Obtener los datos de un colaborador especifico
        /// </summary>
        /// <param name="c">Objeto colaborador con los datos del colaborador</param>
        /// <returns>Retorna un colaborador con los datos del colaborador </returns>
        public Colaborador obtenerDatosColaboradorCompleto(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaborador");
            comando.Connection.Close();
            //comando.Connection.Open();
            comando = _manejador.obtenerProcedimiento("SelectColaborador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.VarChar);

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
                    Areas area = (Areas)datareader["Area"];
                    bool administrador_general = (bool)datareader["Administrador_General"];

                    c.Nombre = nombre;
                    c.Primer_apellido = primer_apellido;
                    c.Segundo_apellido = segundo_apellido;
                    c.Identificacion = identificacion;
                    c.Area = area;
                    c.Administrador_general = administrador_general;
                }

               // comando.Connection.Close();
                return c;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

      

        /// <summary>
        /// Verificar si existe una Tripulacion.
        /// </summary>
        /// <param name="t">Objeto Tripulacion con los datos de la Tripulacion a verificar</param>
        /// <returns>Valor que indica si la Tripulacion existe</returns>
        public bool verificarTripulacion(ref Tripulacion t,DateTime f)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTripulacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tripulacion", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id == t.ID;

                    t.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTripulacionDuplicada");
            }

            return existe;
        }

        /// <summary>
        /// Obtener los datos de una Tripulacion.
        /// </summary>
        /// <param name="t"Tripulacion para la cual se obtienen los datos</param>
        /// <returns>Valor que indica si la tripulacion existe</returns>
        public Tripulacion obtenerDatosTripulacion(ref Tripulacion t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTripulacionDatos");
            SqlDataReader datareader = null;
            Colaborador chofer = new Colaborador();
            Colaborador custodio = new Colaborador();
            Colaborador portavalor = new Colaborador();
            Tripulacion tripulacion = new Tripulacion();
            Colaborador usuario = new Colaborador();

            _manejador.agregarParametro(comando, "@tripulacion", t, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_tripulacion = (int)datareader["ID_Tripulacion"];
                    string descripcion = (string)datareader["Descripción"];
                    int id_chofer = (int)datareader["fk_ID_Chofer"];
                    int id_custodio = (int)datareader["fk_ID_Custodio"];
                    int id_portavalor = (int)datareader["fk_ID_Portavalor"];
                    int id_ruta = (int)datareader["Ruta"];
                    string observaciones = (string)datareader["Observaciones"];
                    int id_usuario = (int)datareader["fk_ID_Usuario"];
                    int ordenSalida = (int)datareader["OrdenSalida"];
                    

                    chofer.ID = id_chofer;
                    custodio.ID = id_custodio;
                    portavalor.ID = id_portavalor;
                    usuario.ID = id_usuario;

                    chofer = _colaboradores.obtenerDatosColaboradorCompleto(ref chofer);
                    custodio = _colaboradores.obtenerDatosColaboradorCompleto(ref custodio);
                    portavalor = _colaboradores.obtenerDatosColaboradorCompleto(ref portavalor);
                    usuario = _colaboradores.obtenerDatosColaboradorCompleto(ref usuario);

                    tripulacion  = new Tripulacion(nombre: descripcion, ruta: id_ruta, chofer: chofer, custodio: custodio, portavalor: portavalor, id: id_tripulacion,usuario:usuario,observaciones:observaciones);
                    

                }

                comando.Connection.Close();
                
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tripulacion;
        }



       /// <summary>
       /// Actualiza el orde de salida de una tripulacion
       /// </summary>
       /// <param name="c">Objeto Tripulacion con los datos de la Tripulacion</param>
        public void actualizarTripulacionOrdenSalida(Tripulacion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTripulacionOrdenSalida");

            _manejador.agregarParametro(comando, "@orden", c.OrdenSalida, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorActualizarTripulacion");
            }

        }





       /// <summary>
       /// Obtiene los datos de los equipos asignados a un colaborador
       /// </summary>
       /// <param name="asignado">Objeto Colaborador con los datos del colaborador a buscar</param>
       /// <param name="asignacion">ID de la asignacion de equipos para esa tripulacion y ese dia</param>
        public void listarEquiposColaborador(ref Colaborador asignado, int asignacion)
        {
            BindingList<Equipo> equipos = new BindingList<Equipo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradorEquipos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@asignaciones", asignacion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", asignado, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string serie = (string)datareader["Serie"];
                    string codigobarras = (string)datareader["Codigo_Barras"];
                    string idasignacion = (string)datareader["Codigo_Asignado"];

                    ATM atm = null;


                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                        byte cartuchos = (byte)datareader["Cartuchos"];
                        bool externo = (bool)datareader["Externo"];
                        bool full = (bool)datareader["ATM_Full"];
                        bool ena = (bool)datareader["ENA"];
                        bool vip = (bool)datareader["VIP"];
                        bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                        string codigo = (string)datareader["Codigo"];
                        string oficinas = (string)datareader["Oficinas"];
                        byte? periodo_carga = datareader["Periodo_Carga"] as byte?;

                        EmpresaTransporte empresa_encargada = null;

                        if (datareader["ID_Transportadora"] != DBNull.Value)
                        {
                            byte id_empresa_encargada = (byte)datareader["ID_Transportadora"];
                            string nombre = (string)datareader["Nombre_Transportadora"];

                            empresa_encargada = new EmpresaTransporte(nombre, id: id_empresa_encargada);
                        }

                        Sucursal sucursal = null;



                        Ubicacion ubicacion = null;

                        if (datareader["ID_Ubicacion"] != DBNull.Value)
                        {
                            short id_ubicacion = (short)datareader["ID_Ubicacion"];
                            string oficina = (string)datareader["Oficina"];
                            string direccion = (string)datareader["Direccion"];

                            ubicacion = new Ubicacion(oficina, direccion, id: id_ubicacion);
                        }

                        atm = new ATM(id: id_atm, numero: numero, empresa_encargada: empresa_encargada, tipo: tipo,
                                         cartuchos: cartuchos, externo: externo, full: full, ena: ena,
                                         vip: vip, cartucho_rechazo: cartucho_rechazo, codigo: codigo,
                                         oficinas: oficinas, periodo_carga: periodo_carga, sucursal: sucursal,
                                         ubicacion: ubicacion);
                    }




                    Colaborador colaborador = null;

                    if (datareader["Colaborador"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];
                        string identificacion = (string)datareader["Identificacion"];
                        string cuenta = datareader["Cuenta"] as string;


                        colaborador = new Colaborador(id: id, nombre: nombre, primer_apellido: primer_apellido,
                                                                  segundo_apellido: segundo_apellido, identificacion: identificacion,
                                                                  cuenta: cuenta);
                    }



                    Manojo manojo = null;

                    if (datareader["Manojo"] != DBNull.Value)
                    {
                        int id_manojo = (int)datareader["ID_Manojo"];
                        string descripcion_manojo = (string)datareader["Descripcion_Manojo"];

                        manojo = new Manojo(id: id_manojo, descripcion: descripcion_manojo);
                    }

                    TipoEquipo tipoequipo = null;

                    if (datareader["TipoEquipo"] != DBNull.Value)
                    {
                        int tipoequipoid = (int)datareader["TipoEquipo"];
                        string tipoequipo_descripcion = (string)datareader["TipoEquipoDescripcion"];
                        bool obligatorio = (bool)datareader["TipoEquipoObligatorio"];

                        tipoequipo = new TipoEquipo(id: tipoequipoid, descripcion: tipoequipo_descripcion, obligatorio: obligatorio);

                    }

                    int id_asignacion_equipo = 0;

                    if (datareader["ID_Asignacion_Equipo"] != DBNull.Value)
                    {
                        id_asignacion_equipo = (int)datareader["ID_Asignacion_Equipo"];
                    }

                    Equipo equipo = new Equipo(id: id, serie: serie, idasignacion: idasignacion, atm: atm, col: colaborador, man: manojo, codigobarras: codigobarras, tipoequipo: tipoequipo,idasignacionequipo:id_asignacion_equipo);

                    equipos.Add(equipo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            asignado.Equipos = equipos;
        }


        /// <summary>
        /// Lista los equipos ya previamente asignados a los colaboradores
        /// </summary>
        /// <param name="asignado">Colaborador del cual traer los equipos</param>
        public void listarEquiposColaboradorYaAsignados(ref Colaborador asignado)
        {
            BindingList<Equipo> equipos = new BindingList<Equipo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradorEquiposYaAsignados");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", asignado, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string serie = (string)datareader["Serie"];
                    string codigobarras = (string)datareader["Codigo_Barras"];
                    string idasignacion = (string)datareader["Codigo_Asignado"];

                   

                    Colaborador colaborador = null;

                    if (datareader["Colaborador"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];
                        string identificacion = (string)datareader["Identificacion"];
                        string cuenta = datareader["Cuenta"] as string;


                        colaborador = new Colaborador(id: id, nombre: nombre, primer_apellido: primer_apellido,
                                                                  segundo_apellido: segundo_apellido, identificacion: identificacion,
                                                                  cuenta: cuenta);
                    }



                   

                    TipoEquipo tipoequipo = null;

                    if (datareader["TipoEquipo"] != DBNull.Value)
                    {
                        int tipoequipoid = (int)datareader["TipoEquipo"];
                        string tipoequipo_descripcion = (string)datareader["TipoEquipoDescripcion"];
                        bool obligatorio = (bool)datareader["TipoEquipoObligatorio"];

                        tipoequipo = new TipoEquipo(id: tipoequipoid, descripcion: tipoequipo_descripcion, obligatorio: obligatorio);

                    }

                    

                    Equipo equipo = new Equipo(id: id, serie: serie, idasignacion: idasignacion,  col: colaborador,  codigobarras: codigobarras, tipoequipo: tipoequipo);

                   // equipos.Add(equipo);

                    asignado.Equipos.Add(equipo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

           // asignado.Equipos = equipos;
        }





        /// <summary>
        /// Lista los equipos ya previamente asignados a los colaboradores
        /// </summary>
        /// <param name="asignado">Colaborador del cual traer los equipos</param>
        public void listarEquiposColaboradorYaAsignadosPorPuesto(ref Colaborador asignado, Puestos p)
        {
            BindingList<Equipo> equipos = new BindingList<Equipo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradorEquiposYaAsignadosPorPuesto");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string serie = (string)datareader["Serie"];
                    string codigobarras = (string)datareader["Codigo_Barras"];
                    string idasignacion = (string)datareader["Codigo_Asignado"];



                    

                    TipoEquipo tipoequipo = null;

                    if (datareader["TipoEquipo"] != DBNull.Value)
                    {
                        int tipoequipoid = (int)datareader["TipoEquipo"];
                        string tipoequipo_descripcion = (string)datareader["TipoEquipoDescripcion"];
                        bool obligatorio = (bool)datareader["TipoEquipoObligatorio"];

                        tipoequipo = new TipoEquipo(id: tipoequipoid, descripcion: tipoequipo_descripcion, obligatorio: obligatorio);

                    }



                    Equipo equipo = new Equipo(id: id, serie: serie, idasignacion: idasignacion, codigobarras: codigobarras, tipoequipo: tipoequipo);

                    // equipos.Add(equipo);

                    asignado.Equipos.Add(equipo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            // asignado.Equipos = equipos;
        }


        #endregion Metodos Publicos

    }
}
