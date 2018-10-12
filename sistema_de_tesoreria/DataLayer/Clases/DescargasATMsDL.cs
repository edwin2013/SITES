//
//  @ Project : 
//  @ File Name : DescargasATMsDL.cs
//  @ Date : 04/12/2012
//  @ Author : Erick Chavarría 
//  

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    public class DescargasATMsDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static DescargasATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static DescargasATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new DescargasATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public DescargasATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema la descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos de la descarga</param>
        public void agregarDescargaATM(ref DescargaATM d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDescargaATM");

            _manejador.agregarParametro(comando, "@carga", d.Carga, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga_emergencia", d.Carga_emergencia, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@manifiesto", d.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cierre", d.Cierre, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", d.Hora_inicio, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@hora_inicio", d.Hora_inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_finalizacion", d.Hora_finalizacion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_diferencia", d.Hora_diferencia, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@completa", d.Completa, SqlDbType.Bit);

            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDescargaATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de la descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos de la descarga</param>
        public void actualizarDescargaATM(DescargaATM d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDescargaATM");

            _manejador.agregarParametro(comando, "@manifiesto", d.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", d.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@hora_inicio", d.Hora_inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_finalizacion", d.Hora_finalizacion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_diferencia", d.Hora_diferencia, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@observaciones", d.Observaciones, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDescargaATMActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos de la descarga</param>
        public void eliminarDescargaATM(DescargaATM d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteDescargaATM");

            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDescargaATMEliminacion");
            }

        }

        /// <summary>
        /// Obtener las descargas del cierre de un cajero de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre del cajero de ATM's</param>
        public void obtenerDescargasATMsCierreATMs(ref CierreATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargasATMsCierreATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_descarga = (int)datareader["ID_Descarga"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    string observaciones = (string)datareader["Observaciones"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas);

                    CargaATM carga = null;

                    if (datareader["ID_Carga"] != DBNull.Value)
                    {
                        int id_carga = (int)datareader["ID_Carga"];
                        DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                        TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];

                        carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, tipo: tipo);
                    }

                    CargaEmergenciaATM carga_emergencia = null;

                    if (datareader["ID_Carga_Emergencia"] != DBNull.Value)
                    {
                        int id_carga_emergencia = (int)datareader["ID_Carga_Emergencia"];
                        DateTime fecha_carga = (DateTime)datareader["Fecha"];

                        carga_emergencia = new CargaEmergenciaATM(id: id_carga_emergencia, atm: atm, fecha: fecha_carga);
                    }

                    DescargaATM descarga = new DescargaATM(id: id_descarga, fecha: fecha, cierre: c, carga: carga,
                                                           carga_emergencia: carga_emergencia, observaciones: observaciones);

                    c.agregarDescarga(descarga);
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
        /// Listar las descargas por fecha, cajero, ruta y ATM.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="r">Ruta de las descargas que se listarán</param>
        /// <param name="f">Fecha de procesamiento de las descargas que se listarán</param>
        /// <returns>Lista de descargas que cumplen con los parámetros</returns>
        public BindingList<DescargaATM> listarDescargasATMs(Colaborador c, ATM a, DateTime f, byte? r)
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargasATMsMonitoreo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_descarga = (int)datareader["ID_Descarga"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas:oficinas);

                    int id_cajero = (int)datareader["ID_Cajero_Descarga"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero_Descarga"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero_Descarga"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero_Descarga"];

                    Colaborador cajero_descarga = new Colaborador(id_cajero, nombre_cajero, primer_apellido_cajero,
                                                                  segundo_apellido_cajero);

                    int id_coordinador = (int)datareader["ID_Cajero_Descarga"];
                    string nombre_coordinador = (string)datareader["Nombre_Cajero_Descarga"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Cajero_Descarga"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Cajero_Descarga"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador, primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);



                    byte id_camara = 0;
                    string identificador = "";

                    if (datareader["ID_Camara"] != DBNull.Value)
                    {
                        id_camara = (byte)datareader["ID_Camara"];
                        identificador = (string)datareader["Identificador"];
                    }
                    
                    

                    Camara camara = new Camara(identificador, id: id_camara);

                    int id_cierre = (int)datareader["ID_cierre"];
                    DateTime fecha = (DateTime)datareader["Fecha_Cierre"];

                    CierreATMs cierre = new CierreATMs(cajero_descarga, id: id_cierre, coordinador: coordinador,  fecha: fecha, camara: camara);

                    Colaborador cajero_carga = null;

                    if (datareader["ID_Cajero_Carga"] != DBNull.Value)
                    {
                        int id_cajero_carga = (int)datareader["ID_Cajero_Carga"];
                        string nombre_cajero_carga = (string)datareader["Nombre_Cajero_Carga"];
                        string primer_apellido_cajero_carga = (string)datareader["Primer_Apellido_Cajero_Carga"];
                        string segundo_apellido_cajero_carga = (string)datareader["Segundo_Apellido_Cajero_Carga"];

                        cajero_carga = new Colaborador(id_cajero_carga, nombre_cajero_carga, primer_apellido_cajero_carga,
                                                        segundo_apellido_cajero_carga);
                    }



                    Tripulacion tripulacion = null;

                    if (datareader["ID_Tripulacion"] != DBNull.Value)
                    {
                        short id_tripulacion = (short)datareader["ID_Tripulacion"];
                        string descripcion = (string)datareader["Descripcion_Tripulacion"];



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


                        Colaborador chofer = new Colaborador(id_chofer, nombre_chofer, primer_apellido_chofer, segundo_apellido_chofer, identificacion_chofer);
                        Colaborador custodio = new Colaborador(id_custodio, nombre_custodio, primer_apellido_custodio, segundo_apellido_custodio, identificacion_custodio);
                        Colaborador portavalor = new Colaborador(id_portavalor, nombre_portavalor, primer_apellido_portavalor, segundo_apellido_portavalor, identificacion_portavalor);
                        
                        short id_vehiculo = (short)datareader["ID_Vehiculo"];
                        string modelo = (string)datareader["Modelo"];
                        string placa = (string)datareader["Placa"];
                        int numeroasoc = (Int32)datareader["NumeroAsociado"];
                        int ordensalida = (Int32)datareader["OrdenSalida"];
                        Vehiculo vehiculo = new Vehiculo(placa: placa, modelo: modelo, numeroasociado: numeroasoc, id: id_vehiculo);





                        tripulacion = new Tripulacion(nombre: descripcion, chofer: chofer, custodio: custodio, portavalor: portavalor, id: id_tripulacion, v: vehiculo, ordenSalida: ordensalida);


                    }

                    CargaATM carga = null;

                    if (datareader["ID_Carga"] != DBNull.Value)
                    {
                        int id_carga = (int)datareader["ID_Carga"];
                        DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                        TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];

                        byte? ruta = datareader["Ruta"] as byte?;
                        byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                        bool atm_full = (bool)datareader["ATM_Full"];
                        bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                        bool ena = (bool)datareader["ENA"];
                        string observaciones = (string)datareader["Observaciones"];

                        carga = new CargaATM(atm, id: id_carga, cajero: cajero_carga, fecha_asignada: fecha_asignada, tipo: tipo, ruta:ruta,
                            orden_ruta:orden_ruta,atm_full:atm_full,cartucho_rechazo:cartucho_rechazo,ena:ena,observaciones:observaciones,trip:tripulacion);


                    }

                    CargaEmergenciaATM carga_emergencia = null;

                    if (datareader["ID_Carga_Emergencia"] != DBNull.Value)
                    {
                        int id_carga_emergencia = (int)datareader["ID_Carga_Emergencia"];
                        DateTime fecha_carga_emergencia = (DateTime)datareader["Fecha_Carga_Emergencia"];

                        carga_emergencia = new CargaEmergenciaATM(id: id_carga_emergencia, atm: atm, fecha: fecha_carga_emergencia);
                    }

                    DescargaATM descarga = new DescargaATM(id: id_descarga, cierre: cierre, carga: carga, fecha: f, carga_emergencia: carga_emergencia);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }

        /// <summary>
        /// Obtener una lista de las descargas pendientes.
        /// </summary>
        /// <returns>Lista de descargas no descargadas</returns>
        public BindingList<DescargaATM> listarDescargasATMsPendientes()
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsNoDescargadas");
            SqlDataReader datareader = null;

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

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo_atm = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo_atm, oficinas: oficinas);
                    CargaATM carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, tipo: tipo,
                                                  atm_full: atm_full, cartucho_rechazo: cartucho_rechazo, ena: ena);

                    DescargaATM descarga = new DescargaATM(carga: carga);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }

        /// <summary>
        /// Obtener una lista de las descargas pendientes con determinado marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsPendientesPorMarchamo(string m)
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsNoDescargadasPorMarchamos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    int id_carga = (int)datareader["ID_Carga"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo_atm = (string)datareader["Codigo_ATM"];
                    string oficinas = (string)datareader["Oficinas"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    string marchamo_adicional = (string)datareader["Marchamo_Adicional"];
                    string bolsa_rechazo = datareader["Bolsa_Rechazo"] as string;
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo_atm, oficinas: oficinas);
                    ManifiestoATMCarga manifiesto = new ManifiestoATMCarga(codigo_manifiesto, marchamo, fecha, bolsa_rechazo, marchamo_adicional,
                                                                           id: id_manifiesto);
                    CargaATM carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, tipo: tipo,
                                                  atm_full: atm_full, cartucho_rechazo: cartucho_rechazo, ena: ena);

                    DescargaATM descarga = new DescargaATM(manifiesto: manifiesto, carga: carga);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas emergencia pendientes.
        /// </summary>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsEmergenciaPendientes()
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasEmergenciaATMsNoDescargadas");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas);
                    CargaEmergenciaATM carga = new CargaEmergenciaATM(id: id_carga, atm: atm, fecha: fecha);

                    DescargaATM descarga = new DescargaATM(carga_emergencia: carga);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas de emergencia pendientes por número de marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsEmergenciaPendientesPorMarchamo(string m)
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasEmergenciaATMsNoDescargadasPorMarchamos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha_carga = (DateTime)datareader["Fecha_Carga"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo_ATM"];
                    string oficinas = (string)datareader["Oficinas"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    string marchamo_adicional = (string)datareader["Marchamo_Adicional"];
                    string bolsa_rechazo = datareader["Bolsa_Rechazo"] as string;
                    DateTime fecha_manifiesto = (DateTime)datareader["Fecha_Manifiesto"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas);
                    ManifiestoATMCarga manifiesto = new ManifiestoATMCarga(codigo_manifiesto, marchamo, fecha_manifiesto, bolsa_rechazo, marchamo_adicional,
                                                                           id: id_manifiesto);
                    CargaEmergenciaATM carga = new CargaEmergenciaATM(id: id_carga, atm: atm, fecha: fecha_carga);

                    DescargaATM descarga = new DescargaATM(manifiesto: manifiesto, carga_emergencia: carga);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }


        ///////////////////////////////////////////////DESCARGAS COMPLETAS /////////////////////////////////////////////////////////

        /// <summary>
        /// Obtener una lista de las descargas pendientes.
        /// </summary>
        /// <returns>Lista de descargas no descargadas</returns>
        public BindingList<DescargaATM> listarDescargasATMsPendientesCompletas()
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsNoDescargadasCompletas");
            SqlDataReader datareader = null;

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

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo_atm = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo_atm, oficinas: oficinas);
                    CargaATM carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, tipo: tipo,
                                                  atm_full: atm_full, cartucho_rechazo: cartucho_rechazo, ena: ena);

                    DescargaATM descarga = new DescargaATM(carga: carga);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }

        /// <summary>
        /// Obtener una lista de las descargas pendientes con determinado marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsPendientesPorMarchamoCompletas(string m)
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsNoDescargadasPorMarchamosCompletas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {

                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    int id_carga = (int)datareader["ID_Carga"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo_atm = (string)datareader["Codigo_ATM"];
                    string oficinas = (string)datareader["Oficinas"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    string marchamo_adicional = (string)datareader["Marchamo_Adicional"];
                    string bolsa_rechazo = datareader["Bolsa_Rechazo"] as string;
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo_atm, oficinas: oficinas);
                    ManifiestoATMCarga manifiesto = new ManifiestoATMCarga(codigo_manifiesto, marchamo, fecha, bolsa_rechazo, marchamo_adicional,
                                                                           id: id_manifiesto);
                    CargaATM carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, tipo: tipo,
                                                  atm_full: atm_full, cartucho_rechazo: cartucho_rechazo, ena: ena);

                    DescargaATM descarga = new DescargaATM(manifiesto: manifiesto, carga: carga);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas emergencia pendientes.
        /// </summary>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsEmergenciaPendientesCompletas()
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasEmergenciaATMsNoDescargadasCompletas");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas);
                    CargaEmergenciaATM carga = new CargaEmergenciaATM(id: id_carga, atm: atm, fecha: fecha);

                    DescargaATM descarga = new DescargaATM(carga_emergencia: carga);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas de emergencia pendientes por número de marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsEmergenciaPendientesPorMarchamoCompletas(string m)
        {
            BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasEmergenciaATMsNoDescargadasPorMarchamosCompletas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha_carga = (DateTime)datareader["Fecha_Carga"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo_ATM"];
                    string oficinas = (string)datareader["Oficinas"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    string marchamo_adicional = (string)datareader["Marchamo_Adicional"];
                    string bolsa_rechazo = datareader["Bolsa_Rechazo"] as string;
                    DateTime fecha_manifiesto = (DateTime)datareader["Fecha_Manifiesto"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas);
                    ManifiestoATMCarga manifiesto = new ManifiestoATMCarga(codigo_manifiesto, marchamo, fecha_manifiesto, bolsa_rechazo, marchamo_adicional,
                                                                           id: id_manifiesto);
                    CargaEmergenciaATM carga = new CargaEmergenciaATM(id: id_carga, atm: atm, fecha: fecha_carga);

                    DescargaATM descarga = new DescargaATM(manifiesto: manifiesto, carga_emergencia: carga);

                    descargas.Add(descarga);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return descargas;
        }






        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        /// <summary>
        /// Obtener una lista de las descargas del cierre de un cajero de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre del cajero de ATM's</param>
        /// <returns>Tabla con la lista de descargas</returns>
        public DataTable listarDescargasATMsPorCierreATMs(CierreATMs c)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectListaDescargasATMsCierreATMs");
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
        /// Obtener una lista de las descargas para el libro mayor de una determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Tabla con la lista de descargas</returns>
        public DataTable listarDescargasATMsLibroMayor(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargasATMsLibroMayor");
            SqlDataReader datareader = null;

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
        /// Obtener los datos de la descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM que representa la descarga para la cual se obtienen los datos</param>
        public void obtenerDatosDescargaATM(ref DescargaATM d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargaATMDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    DateTime hora_inicio = datareader["Hora_Inicio"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Inicio"];
                    DateTime hora_finalizacion = datareader["Hora_Finalizacion"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Finalizacion"];
                    DateTime hora_diferencia = datareader["Hora_Diferencia"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Diferencia"];
                    string observaciones = (string)datareader["Observaciones"];

                    ManifiestoATMCarga manifiesto = null;

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id = (int)datareader["ID_Manifiesto"];
                        string codigo = (string)datareader["Codigo"];
                        string marchamo = (string)datareader["Marchamo"];
                        string marchamo_adicional = (string)datareader["Marchamo_Adicional"];
                        string bolsa_rechazo = datareader["Bolsa_Rechazo"] as string;
                        DateTime fecha = (DateTime)datareader["Fecha"];

                        manifiesto = new ManifiestoATMCarga(codigo, marchamo, fecha, bolsa_rechazo, marchamo_adicional, id: id);
                    }

                    d.Hora_inicio = hora_inicio;
                    d.Hora_finalizacion = hora_finalizacion;
                    d.Hora_diferencia = hora_diferencia;
                    d.Observaciones = observaciones;
                    d.Manifiesto = manifiesto;
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
        /// Devuelve una Carga de ATM
        /// </summary>
        /// <param name="d">Objeto DescargaATM que contiene la CargaATM</param>
        public void actualizarDevoluciones(ref DescargaATM d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMDevolucion");

            _manejador.agregarParametro(comando, "@carga", d.Carga.ID, SqlDbType.Int);
           
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDescargaATMActualizacion");
            }
        }
        
        #endregion Métodos Públicos

    }

}
