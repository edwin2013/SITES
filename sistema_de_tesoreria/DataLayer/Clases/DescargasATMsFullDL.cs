//
//  @ Project : 
//  @ File Name : DescargasATMsFullDL.cs
//  @ Date : 08/02/2013
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

    public class DescargasATMsFullDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static DescargasATMsFullDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static DescargasATMsFullDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new DescargasATMsFullDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public DescargasATMsFullDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema la descarga de un ATM Full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull con los datos de la descarga</param>
        public void agregarDescargaATMFull(ref DescargaATMFull d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDescargaATMFull");

            _manejador.agregarParametro(comando, "@carga", d.Carga, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga_emergencia", d.Carga_emergencia, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@manifiesto", d.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cierre", d.Cierre, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", d.Hora_inicio, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@hora_inicio", d.Hora_inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_finalizacion", d.Hora_finalizacion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_diferencia", d.Hora_diferencia, SqlDbType.DateTime);

            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDescargaATMFullRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de la descarga de un ATM Full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull con los datos de la descarga</param>
        public void actualizarDescargaATMFull(DescargaATMFull d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDescargaATMFull");

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
                throw new Excepcion("ErrorDescargaATMFullActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una descarga de un ATM Full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull con los datos de la descarga</param>
        public void eliminarDescargaATMFull(DescargaATMFull d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteDescargaATMFull");

            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDescargaATMFullEliminacion");
            }

        }

        /// <summary>
        /// Obtener las descargas full del cierre de un cajero de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMegcs con los datos del cierre del cajero de ATM's</param>
        public void obtenerDescargasATMsFullCierreATMs(ref CierreATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargasATMsFullCierreATMs");
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

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    DateTime fecha_manifiesto = (DateTime)datareader["Fecha_manifiesto"];
                    string marchamo_adicional_ena = datareader["Marchamo_Adicional_ENA"] as string;
                    string marchamo_ena_a = datareader["Marchamo_ENA_A"] as string;
                    string marchamo_ena_b = datareader["Marchamo_ENA_B"] as string;
                    string bolsa_rechazo = "";
                    if (datareader["Bolsa_Rechazo"] != DBNull.Value)
                        bolsa_rechazo = (string)datareader["Bolsa_Rechazo"];


                    ManifiestoATMFull manifiesto = new ManifiestoATMFull(codigo_manifiesto, marchamo, fecha_manifiesto, marchamo_adicional_ena,
                                                                         marchamo_ena_a, bolsa_rechazo, marchamo_ena_b);

                    CargaATM carga = null;

                    if (datareader["ID_Carga"] != DBNull.Value)
                    {
                        int id_carga = (int)datareader["ID_Carga"];
                        DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];

                        carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, manifiesto_full: manifiesto);
                    }

                    CargaEmergenciaATMFull carga_emergencia = null;

                    if (datareader["ID_Carga_Emergencia"] != DBNull.Value)
                    {
                        int id_carga = (int)datareader["ID_Carga_Emergencia"];
                        DateTime fecha_envio = (DateTime)datareader["Fecha_Envio"];
                        DateTime? fecha_carga = datareader["Fecha_Carga"] as DateTime?;
                        bool ena = (bool)datareader["ENA"];

                        carga_emergencia = new CargaEmergenciaATMFull(fecha_envio, manifiesto, ena, id: id_carga, atm: atm, fecha_carga: fecha_carga);
                    }

                    DescargaATMFull descarga = new DescargaATMFull(id: id_descarga, fecha: fecha, cierre: c, carga: carga,
                                                                   observaciones: observaciones);

                    c.agregarDescargaFull(descarga);
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
        /// Listar las descargas full por fecha, cajero y ATM.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de procesamiento de las descargas que se listarán</param>
        /// <returns>Lista de descargas full que cumplen con los parámetros</returns>
        public BindingList<DescargaATMFull> listarDescargasATMsFull(Colaborador c, ATM a, DateTime f)
        {
            BindingList<DescargaATMFull> descargas = new BindingList<DescargaATMFull>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargasATMsFullMonitoreo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_descarga = (int)datareader["ID_Descarga"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo_atm = (string)datareader["Codigo_ATM"];
                    string oficinas = (string)datareader["Oficinas"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo_atm);

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    DateTime fecha_manifiesto = (DateTime)datareader["Fecha_Manifiesto"];
                    string marchamo_adicional_ena = datareader["Marchamo_Adicional_ENA"] as string;
                    string marchamo_ena_a = datareader["Marchamo_ENA_A"] as string;
                    string marchamo_ena_b = datareader["Marchamo_ENA_B"] as string;
                    string bolsa_rechazo = "";
                    if (datareader["Bolsa_Rechazo"] != DBNull.Value)
                        bolsa_rechazo = (string)datareader["Bolsa_Rechazo"];

                    ManifiestoATMFull manifiesto = new ManifiestoATMFull(codigo_manifiesto, marchamo, fecha_manifiesto, marchamo_adicional_ena,
                                                                         marchamo_ena_a, bolsa_rechazo, marchamo_ena_b);

                    CargaATM carga = null;

                    if (datareader["ID_Carga"] != DBNull.Value)
                    {
                        int id_carga = (int)datareader["ID_Carga"];
                        DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];

                        carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, manifiesto_full: manifiesto);
                    }

                    CargaEmergenciaATMFull carga_emergencia = null;

                    if (datareader["ID_Carga_Emergencia"] != DBNull.Value)
                    {
                        int id_carga = (int)datareader["ID_Carga_Emergencia"];
                        DateTime fecha_envio = (DateTime)datareader["Fecha_Envio"];
                        DateTime? fecha_carga = datareader["Fecha_Carga"] as DateTime?;
                        bool ena = (bool)datareader["ENA"];

                        carga_emergencia = new CargaEmergenciaATMFull(fecha_envio, manifiesto, ena, id: id_carga, atm: atm, fecha_carga: fecha_carga);
                    }

                    int id_cajero = (int)datareader["ID_Cajero_Descarga"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero_Descarga"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero_Descarga"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero_Descarga"];

                    Colaborador cajero_descarga = new Colaborador(id_cajero, nombre_cajero, primer_apellido_cajero,
                                                                  segundo_apellido_cajero);

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador, primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);

                    byte id_camara = (byte)datareader["ID_Camara"];
                    string identificador = (string)datareader["Identificador"];

                    Camara camara = new Camara(identificador, id: id_camara);

                    int id_cierre = (int)datareader["ID_cierre"];
                    DateTime fecha = (DateTime)datareader["Fecha_Cierre"];

                    CierreATMs cierre = new CierreATMs(cajero_descarga, id: id_cierre, coordinador: coordinador, fecha: fecha, camara: camara);

                    DescargaATMFull descarga = new DescargaATMFull(id: id_descarga, cierre: cierre, carga: carga, carga_emergencia: carga_emergencia,
                                                                   fecha: f);

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
        /// Obtener una lista de las descargas full pendientes.
        /// </summary>
        /// <returns>Lista de descargas full no descargadas</returns>
        public BindingList<DescargaATMFull> listarDescargasATMsFullPendientes()
        {
            BindingList<DescargaATMFull> descargas = new BindingList<DescargaATMFull>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsFullNoDescargadas");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    bool ena = (bool)datareader["ENA"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo_atm = (string)datareader["Codigo_ATM"];
                    string oficinas = (string)datareader["Oficinas"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    string marchamo_adicional_ena = datareader["Marchamo_Adicional_ENA"] as string;
                    string marchamo_ena_a = datareader["Marchamo_ENA_A"] as string;
                    string marchamo_ena_b = datareader["Marchamo_ENA_B"] as string;
                    DateTime fecha = (DateTime)datareader["Fecha_Manifiesto"];

                    string bolsa_rechazo = "";
                    if (datareader["Bolsa_Rechazo"] != DBNull.Value)
                        bolsa_rechazo = (string)datareader["Bolsa_Rechazo"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo_atm, oficinas: oficinas);
                    ManifiestoATMFull manifiesto = new ManifiestoATMFull(codigo_manifiesto, marchamo, fecha, marchamo_adicional_ena,
                                                                         marchamo_ena_a, marchamo_ena_b,bolsa_rechazo, id: id_manifiesto);
                    CargaATM carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, manifiesto_full: manifiesto, ena: ena);

                    DescargaATMFull descarga = new DescargaATMFull(carga: carga);

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
        /// Obtener una lista de las descargas full pendientes con determinado marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista de descargas full pendientes</returns>
        public BindingList<DescargaATMFull> listarDescargasATMsFullPendientesPorMarchamo(string m)
        {
            BindingList<DescargaATMFull> descargas = new BindingList<DescargaATMFull>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsFullNoDescargadasPorMarchamos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    bool ena = (bool)datareader["ENA"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo_atm = (string)datareader["Codigo_ATM"];
                    string oficinas = (string)datareader["Oficinas"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    string marchamo_adicional_ena = datareader["Marchamo_Adicional_ENA"] as string;
                    string marchamo_ena_a = datareader["Marchamo_ENA_A"] as string;
                    string marchamo_ena_b = datareader["Marchamo_ENA_B"] as string;
                    DateTime fecha = (DateTime)datareader["Fecha_Manifiesto"];

                    string bolsa_rechazo = "";
                    if (datareader["Bolsa_Rechazo"] != DBNull.Value)
                        bolsa_rechazo = (string)datareader["Bolsa_Rechazo"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo_atm, oficinas: oficinas);
                    ManifiestoATMFull manifiesto = new ManifiestoATMFull(codigo_manifiesto, marchamo, fecha, marchamo_adicional_ena,
                                                                         marchamo_ena_a, marchamo_ena_b, bolsa_rechazo, id: id_manifiesto);
                    CargaATM carga = new CargaATM(atm, id: id_carga, fecha_asignada: fecha_asignada, manifiesto_full: manifiesto, ena: ena);

                    DescargaATMFull descarga = new DescargaATMFull(carga: carga);

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
        /// Obtener una lista de las descargas de cargas de emergencia de ATM's Full pendientes.
        /// </summary>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATMFull> listarDescargasATMsFullEmergenciaPendientes()
        {
            BindingList<DescargaATMFull> descargas = new BindingList<DescargaATMFull>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasEmergenciaATMsFullNoDescargadas");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha_envio = (DateTime)datareader["Fecha_Envio"];
                    DateTime fecha_carga = (DateTime)datareader["Fecha_Carga"];
                    bool ena = (bool)datareader["ENA"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo_atm = (string)datareader["Codigo_ATM"];
                    string oficinas = (string)datareader["Oficinas"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
                    string marchamo = (string)datareader["Marchamo"];
                    string marchamo_adicional_ena = datareader["Marchamo_Adicional_ENA"] as string;
                    string marchamo_ena_a = datareader["Marchamo_ENA_A"] as string;
                    string marchamo_ena_b = datareader["Marchamo_ENA_B"] as string;
                    DateTime fecha_manifiesto = (DateTime)datareader["Fecha_Manifiesto"];

                    string bolsa_rechazo = "";
                    if (datareader["Bolsa_Rechazo"] != DBNull.Value)
                        bolsa_rechazo = (string)datareader["Bolsa_Rechazo"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo_atm, oficinas: oficinas);
                    ManifiestoATMFull manifiesto = new ManifiestoATMFull(codigo_manifiesto, marchamo, fecha_manifiesto, marchamo_adicional_ena,
                                                                         marchamo_ena_a, marchamo_ena_b, bolsa_rechazo, id: id_manifiesto);
                    CargaEmergenciaATMFull carga = new CargaEmergenciaATMFull(fecha_envio, manifiesto, ena, id: id_carga, atm: atm,
                                                                              fecha_carga: fecha_carga);

                    DescargaATMFull descarga = new DescargaATMFull(carga_emergencia: carga);

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
        /// Obtener una lista de las descargas de cargas de emergencia de ATM's Full pendientes por número de marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsFullEmergenciaPendientesPorMarchamo(string m)
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
        /// <summary>
        /// Obtener los datos de la descarga de un ATM Full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull que representa la descarga para la cual se obtienen los datos</param>
        public void obtenerDatosDescargaATMFull(ref DescargaATMFull d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargaATMFullDatos");
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

                    ManifiestoATMFull manifiesto = null;

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id = (int)datareader["ID_Manifiesto"];
                        string codigo = (string)datareader["Codigo"];
                        string marchamo = (string)datareader["Marchamo"];
                        string marchamo_adicional_ena = datareader["Marchamo_Adicional_ENA"] as string;
                        string marchamo_ena_a = datareader["Marchamo_ENA_A"] as string;
                        string marchamo_ena_b = datareader["Marchamo_ENA_B"] as string;

                        string bolsa_rechazo = "";
                        if (datareader["Bolsa_Rechazo"] != DBNull.Value)
                            bolsa_rechazo = (string)datareader["Bolsa_Rechazo"];

                        DateTime fecha = (DateTime)datareader["Fecha"];

                        manifiesto = new ManifiestoATMFull(codigo, marchamo, fecha, marchamo_adicional_ena, marchamo_ena_a,
                                                           marchamo_ena_b, bolsa_rechazo, id: id);
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
        
        #endregion Métodos Públicos

    }

}
