//
//  @ Project : 
//  @ File Name : CargasATMsDL.cs
//  @ Date : 16/05/2012
//  @ Author : César Mendoza
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

    public class CargasATMsDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CargasATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CargasATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CargasATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CargasATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Obtener datos de portavalor asignado a una carga ATM
        /// </summary>
        /// <param name="c">Carga asignada al portavalor</param>
        /// <returns>Datos del portavalor</returns>
        public void listarPotavalorPorCargaATM(ref CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPortavalorAsignadoCargaATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@ruta", c.Ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha_asignada, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@carga", c.DB_ID, SqlDbType.Int);

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

                    c.ColaboradorRecibidoBoveda = new Colaborador(id, nombre: nombre, primer_apellido: primer_apellido,
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
        /// Registrar en el sistema la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga/param>
        public void agregarCargaATM(ref CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCargaATM");

            _manejador.agregarParametro(comando, "@atm", c.ATM, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@emergencia", c.Emergencia, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tipo", c.Tipo, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha_asignada", c.Fecha_asignada, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@externa", c.Externa, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@atm_full", c.ATM_full, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@cartucho_rechazo", c.Cartucho_rechazo, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@ena", c.ENA, SqlDbType.Bit);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATM(CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATM");

            _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@manifiesto_full", c.Manifiesto_full, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora_inicio", c.Hora_inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_finalizacion", c.Hora_finalizacion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.VarChar);
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
        /// Finalizar una solicitud de codigo de cajeros automaticos
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarFinalizarCodigoCargaATM(CargaATM c)
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
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }


        /// <summary>
        /// Actualizar los datos de los codigos de cajeros automaticos
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCodigosCajerosCargaATM(CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMCodigosCajerosAutomaticos");

            _manejador.agregarParametro(comando, "@codigoapertura", c.CodigoApertura, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@codigocierre", c.CodigoCierre, SqlDbType.NVarChar);
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
        /// Ligar o desligar la carga de un ATM del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMCierreATMs(CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMCierreATMs");

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
        /// Asignar la carga de un ATM a un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMCajero(CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMCajero");

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
        /// Asignar la carga de un ATM como parte de una carga de emergencia.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMCargaEmergenciaATM(CargaATM c, CargaEmergenciaATM ce)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMCargaEmergenciaATM");

            _manejador.agregarParametro(comando, "@carga_emergencia", ce, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
            comando.CommandTimeout = 6000;

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
        public void actualizarCargaATMRuta(CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMRuta");

            _manejador.agregarParametro(comando, "@ruta", c.Ruta, SqlDbType.TinyInt);
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
        /// Asignar la ruta y la hora de llegada a la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMRutaHora(ref CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMRutaHora");

            _manejador.agregarParametro(comando, "@ruta", c.Ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora", c.Hora_Llegada, SqlDbType.DateTime);

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
        public void actualizarCargaATMRutaHoraImportacion(ref CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMRutaHora");

            _manejador.agregarParametro(comando, "@ruta", c.Ruta, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga", c.DB_ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora", c.Hora_Llegada, SqlDbType.DateTime);

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
        public void actualizarCargaATMOrdenRuta(CargaATM c)
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
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMDatosVerificacion(CargaATM c)
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
        /// Eliminar los datos de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void eliminarCargaATM(CargaATM c, Colaborador col)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCargaATM");

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", col, SqlDbType.Int);


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
        /// Obtener las cargas del cierre de un cajero de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre del cajero de ATM's</param>
        public void obtenerCargasATMsCierreATMs(ref CierreATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsCierreATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = false;
                    if (datareader["ENA"] != DBNull.Value)
                    {
                        ena = (bool)datareader["ENA"];
                    }

                    string observaciones = (string)datareader["Observaciones"];

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Nombre"];
                        Provincias provincia = (Provincias)datareader["Provincia_Sucursal"];

                        sucursal = new Sucursal(nombre, id: id_sucursal, provincia: provincia);
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

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];
                        string oficinas = (string)datareader["Oficinas"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas, sucursal: sucursal,
                                      ubicacion: ubicacion);
                    }

                    CargaATM carga = new CargaATM(atm: atm, emergencia: emergencia, id: id_carga, cierre: c,
                                                  fecha_asignada: fecha_asignada, tipo: tipo, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena,
                                                  observaciones: observaciones);

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
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta de las cargas que se listarán</param>
        public BindingList<CargaATM> listarCargasATMs(Colaborador c, ATM a, DateTime f, byte? r)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsMonitoreo");
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
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    byte? ruta = datareader["Ruta"] as byte?;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    string observaciones = (string)datareader["Observaciones"];
                    // DateTime hora_llegada = (DateTime)datareader["Hora_Llegada"];

                    Colaborador cajero = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        cajero = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    Colaborador coordinador = null;

                    if (datareader["ID_Coordinador"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Coordinador"];
                        string nombre = (string)datareader["Nombre_Coordinador"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Coordinador"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Coordinador"];

                        coordinador = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    CierreATMs cierre = null;

                    if (datareader["ID_Cierre"] != DBNull.Value)
                    {
                        int id_cierre = (int)datareader["ID_cierre"];
                        DateTime fecha = (DateTime)datareader["Fecha"];

                        Camara camara = null;

                        if (datareader["ID_Camara"] != DBNull.Value)
                        {
                            byte id_camara = (byte)datareader["ID_Camara"];
                            string identificador = (string)datareader["Identificador"];

                            camara = new Camara(identificador, id: id_camara);
                        }


                        cierre = new CierreATMs(cajero, id: id_cierre, coordinador: coordinador, fecha: fecha, camara: camara);
                    }

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo);
                    }

                    EmpresaTransporte empresa = new EmpresaTransporte();
                    empresa.Nombre = "";
                    if (datareader["Transportadora"] != DBNull.Value)
                    {
                        empresa.Nombre = (string)datareader["Transportadora"];
                    }


                    TipoVisitas visita = TipoVisitas.Carga_Descarga;
                    if (datareader["TipoViaje"] != DBNull.Value)
                    {
                        visita = (TipoVisitas)datareader["TipoViaje"];
                    }

                    CargaATM carga = new CargaATM(atm: atm, emergencia: emergencia, id: id_carga, cajero: cajero,
                                                  cierre: cierre, fecha_asignada: f, tipo: tipo, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena, ruta: ruta,
                                                  orden_ruta: orden_ruta, observaciones: observaciones, transportadora: empresa);

                    carga.TipoVisita = visita;

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
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta de las cargas que se listarán</param>
        public BindingList<CargaATM> listarCodigosCajeroCargasATMs(Colaborador c, ATM a, DateTime f, byte? r)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasCodigosATMsMonitoreo");
            SqlDataReader datareader = null;
            comando.CommandTimeout = 300000;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    byte? ruta = datareader["Ruta"] as byte?;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    string observaciones = (string)datareader["Observaciones"];
                    // DateTime hora_llegada = (DateTime)datareader["Hora_Llegada"];

                    Colaborador cajero = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        cajero = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    Colaborador coordinador = null;

                    if (datareader["ID_Coordinador"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Coordinador"];
                        string nombre = (string)datareader["Nombre_Coordinador"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Coordinador"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Coordinador"];

                        coordinador = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    CierreATMs cierre = null;

                    if (datareader["ID_Cierre"] != DBNull.Value)
                    {
                        int id_cierre = (int)datareader["ID_cierre"];
                        DateTime fecha = (DateTime)datareader["Fecha"];

                        Camara camara = null;

                        if (datareader["ID_Camara"] != DBNull.Value)
                        {
                            byte id_camara = (byte)datareader["ID_Camara"];
                            string identificador = (string)datareader["Identificador"];

                            camara = new Camara(identificador, id: id_camara);
                        }


                        cierre = new CierreATMs(cajero, id: id_cierre, coordinador: coordinador, fecha: fecha, camara: camara);
                    }

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo);
                    }


                    string codigoapertura = "";
                    if (datareader["Codigo_Apertura"] != DBNull.Value)
                    {
                        codigoapertura = (string)datareader["Codigo_Apertura"];
                    }

                    string codigocierre = "";
                    if (datareader["Codigo_Cierre"] != DBNull.Value)
                    {
                        codigocierre = (string)datareader["Codigo_Cierre"];
                    }

                    bool confirmado = false;
                    if (datareader["Confirmado"] != DBNull.Value)
                    {
                        confirmado = (bool)datareader["Confirmado"];
                    }

                    bool solicitado = false;
                    if (datareader["Solicitada"] != DBNull.Value)
                    {
                        solicitado = (bool)datareader["Solicitada"];
                    }


                    string numerollave = "";
                    if (datareader["NumeroLlave"] != DBNull.Value)
                    {
                        numerollave = (string)datareader["NumeroLlave"];
                    }

                    CargaATM carga = new CargaATM(atm: atm, emergencia: emergencia, id: id_carga, cajero: cajero,
                                                  cierre: cierre, fecha_asignada: f, tipo: tipo, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena, ruta: ruta,
                                                  orden_ruta: orden_ruta, observaciones: observaciones, codigo_apertura: codigoapertura, codigo_cierre: codigocierre
                                                  , solicitado: solicitado, confirmado: confirmado, numerollave: numerollave);

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
        /// Revisar si existen Cargas de Apertura Pendientes por Revisar
        /// </summary>
        /// <param name="f">Objeto Fecha con la fecha de Consulta</param>
        /// <returns></returns>
        public BindingList<int> listarCodigosSolicitudApertura(DateTime f)
        {
            BindingList<int> cargas = new BindingList<int>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectVerificacionAperturasPendientes");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["pk_ID"];

                    cargas.Add(id_carga);
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
        /// Revisar si existen Cargas de Apertura Pendientes por Revisar
        /// </summary>
        /// <param name="f">Objeto Fecha con la fecha de Consulta</param>
        /// <returns></returns>
        public BindingList<int> listarCodigosSolicitudCierre(DateTime f)
        {
            BindingList<int> cargas = new BindingList<int>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectVerificacionCierresPendientes");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["pk_ID"];

                    cargas.Add(id_carga);
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
        /// Lista las CargasATM que tengan un marchamo adicional igual
        /// </summary>
        /// <param name="marchamo">marchamo adicional a bucar</param>
        /// <returns>Lista de Objetos CargaATM con los datos de las cargas</returns>
        public BindingList<CargaATM> listarCargasATMporMarchamoAdicional(string marchamo)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsporMarchamoAdicional");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", marchamo, SqlDbType.VarChar);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    byte? ruta = datareader["Ruta"] as byte?;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    string observaciones = (string)datareader["Observaciones"];
                    // DateTime hora_llegada = (DateTime)datareader["Hora_Llegada"];

                    Colaborador cajero = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        cajero = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    Colaborador coordinador = null;

                    if (datareader["ID_Coordinador"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Coordinador"];
                        string nombre = (string)datareader["Nombre_Coordinador"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Coordinador"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Coordinador"];

                        coordinador = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    CierreATMs cierre = null;

                    if (datareader["ID_Cierre"] != DBNull.Value)
                    {
                        int id_cierre = (int)datareader["ID_cierre"];
                        DateTime fecha = (DateTime)datareader["Fecha"];

                        Camara camara = null;

                        if (datareader["ID_Camara"] != DBNull.Value)
                        {
                            byte id_camara = (byte)datareader["ID_Camara"];
                            string identificador = (string)datareader["Identificador"];

                            camara = new Camara(identificador, id: id_camara);
                        }


                        cierre = new CierreATMs(cajero, id: id_cierre, coordinador: coordinador, fecha: fecha, camara: camara);
                    }

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo);
                    }

                    CargaATM carga = new CargaATM(atm: atm, emergencia: emergencia, id: id_carga, cajero: cajero,
                                                  cierre: cierre, fecha_asignada: DateTime.Now, tipo: tipo, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena, ruta: ruta,
                                                  orden_ruta: orden_ruta, observaciones: observaciones);

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
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta de las cargas que se listarán</param>
        public BindingList<CargaATM> listarCargasATMsEspeciales(Colaborador c, ATM a, DateTime f, byte? r, EmpresaTransporte e)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsMonitoreoExterna");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@transporte", e, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    byte? ruta = datareader["Ruta"] as byte?;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    string observaciones = (string)datareader["Observaciones"];
                    double distancia = 0;
                    int segundos = 0;
                    DateTime horaprogramada = DateTime.Today;

                    DateTime horasalida = DateTime.Today;
                    DateTime horaentrada = DateTime.Today;


                    if (datareader["Distancia"] != DBNull.Value)
                    {
                        distancia = (double)datareader["Distancia"];
                    }

                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                    {
                        segundos = (int)datareader["Tiempo_Viaje"];
                    }

                    if (datareader["Hora_Programada"] != DBNull.Value)
                    {
                        horaprogramada = (DateTime)datareader["Hora_Programada"];
                    }

                    if (datareader["Hora_Entrada"] != DBNull.Value)
                    {
                        horaentrada = (DateTime)datareader["Hora_Entrada"];
                    }

                    if (datareader["Hora_Salida"] != DBNull.Value)
                    {
                        horasalida = (DateTime)datareader["Hora_Salida"];
                    }



                    DateTime hora_llegada = (DateTime)datareader["Hora_Llegada"];

                    Colaborador cajero = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        cajero = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    Colaborador coordinador = null;

                    if (datareader["ID_Coordinador"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Coordinador"];
                        string nombre = (string)datareader["Nombre_Coordinador"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Coordinador"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Coordinador"];

                        coordinador = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    CierreATMs cierre = null;

                    if (datareader["ID_Cierre"] != DBNull.Value)
                    {
                        int id_cierre = (int)datareader["ID_cierre"];
                        DateTime fecha = (DateTime)datareader["Fecha"];

                        Camara camara = null;

                        if (datareader["ID_Camara"] != DBNull.Value)
                        {
                            byte id_camara = (byte)datareader["ID_Camara"];
                            string identificador = (string)datareader["Identificador"];

                            camara = new Camara(identificador, id: id_camara);
                        }


                        cierre = new CierreATMs(cajero, id: id_cierre, coordinador: coordinador, fecha: fecha, camara: camara);
                    }

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo);
                    }

                    EmpresaTransporte empresa = new EmpresaTransporte();
                    empresa.Nombre = "";
                    if (datareader["Transportadora"] != DBNull.Value)
                    {
                        empresa.Nombre = (string)datareader["Transportadora"];
                    }

                    TipoVisitas tipo_viaje = TipoVisitas.Carga_Descarga;

                    if (datareader["TipoViaje"] != DBNull.Value)
                    {
                        tipo_viaje = (TipoVisitas)datareader["TipoViaje"];
                    }
                    CargaATM carga = new CargaATM(atm: atm, emergencia: emergencia, id: id_carga, cajero: cajero,
                                                  cierre: cierre, fecha_asignada: f, hora_llegada: hora_llegada, tipo: tipo, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena, ruta: ruta,
                                                  orden_ruta: orden_ruta, observaciones: observaciones, transportadora: empresa);
                    carga.TipoVisita = tipo_viaje;


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
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta de las cargas que se listarán</param>
        public BindingList<CargaATM> listarCargasATMsEspecialesExportacionRoadnet(Colaborador c, ATM a, DateTime f, byte? r, EmpresaTransporte e)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsMonitoreoExternaRutasRoadnet");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@transporte", e, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    byte? ruta = datareader["Ruta"] as byte?;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    string observaciones = (string)datareader["Observaciones"];
                    double distancia = 0;
                    int segundos = 0;
                    DateTime horaprogramada = DateTime.Today;

                    DateTime horasalida = DateTime.Today;
                    DateTime horaentrada = DateTime.Today;


                    if (datareader["Distancia"] != DBNull.Value)
                    {
                        distancia = (double)datareader["Distancia"];
                    }

                    if (datareader["Tiempo_Viaje"] != DBNull.Value)
                    {
                        segundos = (int)datareader["Tiempo_Viaje"];
                    }

                    if (datareader["Hora_Programada"] != DBNull.Value)
                    {
                        horaprogramada = (DateTime)datareader["Hora_Programada"];
                    }

                    if (datareader["Hora_Entrada"] != DBNull.Value)
                    {
                        horaentrada = (DateTime)datareader["Hora_Entrada"];
                    }

                    if (datareader["Hora_Salida"] != DBNull.Value)
                    {
                        horasalida = (DateTime)datareader["Hora_Salida"];
                    }



                    DateTime hora_llegada = (DateTime)datareader["Hora_Llegada"];

                    Colaborador cajero = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        cajero = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    Colaborador coordinador = null;

                    if (datareader["ID_Coordinador"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Coordinador"];
                        string nombre = (string)datareader["Nombre_Coordinador"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Coordinador"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido_Coordinador"];

                        coordinador = new Colaborador(id_cajero, nombre, primer_apellido, segundo_apellido);
                    }

                    CierreATMs cierre = null;

                    if (datareader["ID_Cierre"] != DBNull.Value)
                    {
                        int id_cierre = (int)datareader["ID_cierre"];
                        DateTime fecha = (DateTime)datareader["Fecha"];

                        Camara camara = null;

                        if (datareader["ID_Camara"] != DBNull.Value)
                        {
                            byte id_camara = (byte)datareader["ID_Camara"];
                            string identificador = (string)datareader["Identificador"];

                            camara = new Camara(identificador, id: id_camara);
                        }


                        cierre = new CierreATMs(cajero, id: id_cierre, coordinador: coordinador, fecha: fecha, camara: camara);
                    }

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo);
                    }

                    EmpresaTransporte empresa = new EmpresaTransporte();
                    empresa.Nombre = "";
                    if (datareader["Transportadora"] != DBNull.Value)
                    {
                        empresa.Nombre = (string)datareader["Transportadora"];
                    }

                    CargaATM carga = new CargaATM(atm: atm, emergencia: emergencia, id: id_carga, cajero: cajero,
                                                  cierre: cierre, fecha_asignada: f, hora_llegada: hora_llegada, tipo: tipo, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena, ruta: ruta,
                                                  orden_ruta: orden_ruta, observaciones: observaciones, transportadora: empresa);



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
        /// Obtener una lista de las cargas de ATM's no asignadas en una fecha dada.
        /// </summary>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas no asignadas</returns>
        public BindingList<CargaATM> listarCargasATMs(DateTime f)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    byte ruta = (byte)datareader["Ruta"];

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Nombre"];
                        Provincias provincia = (Provincias)datareader["Provincia_Sucursal"];

                        sucursal = new Sucursal(nombre, id: id_sucursal, provincia: provincia);
                    }

                    Ubicacion ubicacion = null;

                    if (datareader["ID_Ubicacion"] != DBNull.Value)
                    {
                        short id_ubicacion = (short)datareader["ID_Ubicacion"];
                        string oficina = (string)datareader["Oficina"];
                        string direccion = (string)datareader["Direccion_Ubicacion"];
                        Provincias provincia = (Provincias)datareader["Provincia_Ubicacion"];

                        ubicacion = new Ubicacion(oficina, direccion, id: id_ubicacion, provincia: provincia);
                    }

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo, sucursal: sucursal,
                                      ubicacion: ubicacion);
                    }

                    CargaATM carga = new CargaATM(atm: atm, emergencia: emergencia, id: id_carga,
                                                  fecha_asignada: fecha_asignada, tipo: tipo, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena, ruta: ruta);


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
        /// Listar las cargas asignadas un cajero de ATM's.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's</param>
        public BindingList<CargaATM> listarCargasATMsPorCajero(Colaborador c)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsCajero");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    byte? emergencia = datareader["Emergencia"] as byte?;
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    bool atm_full = (bool)datareader["ATM_Full"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    bool ena = (bool)datareader["ENA"];
                    byte? ruta = datareader["Ruta"] as byte?;
                    string observaciones = (string)datareader["Observaciones"];

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Nombre"];
                        Provincias provincia = (Provincias)datareader["Provincia_Sucursal"];

                        sucursal = new Sucursal(nombre, id: id_sucursal, provincia: provincia);
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

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];
                        string oficinas = (string)datareader["Oficinas"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas,
                                      sucursal: sucursal, ubicacion: ubicacion);
                    }


                    TipoVisitas tipo_viaje = TipoVisitas.Carga_Descarga;

                    if (datareader["Tipo_Viaje"] != DBNull.Value)
                    {
                        tipo_viaje = (TipoVisitas)datareader["Tipo_Viaje"];
                    }

                    CargaATM carga = new CargaATM(atm: atm, emergencia: emergencia, id: id_carga, cajero: c,
                                                  fecha_asignada: fecha_asignada, tipo: tipo, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena, ruta: ruta,
                                                  observaciones: observaciones);
                    carga.TipoVisita = tipo_viaje;
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
        public BindingList<CargaATM> listarCargasATMsPorATMMarchamo(ATM a, string m)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
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

                    CargaATM carga = new CargaATM(atm, id: id_carga, cajero: cajero, fecha_asignada: fecha_asignada,
                                                  tipo: tipo, atm_full: atm_full, cartucho_rechazo: cartucho_rechazo,
                                                  ena: ena, ruta: ruta, observaciones: observaciones);

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
        /// Obtener una lista de las cargas asignadas a una ruta en una fecha determinada.
        /// </summary>
        /// <param name="r">Número de ruta</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cargas que cumplen con los parámetros</returns>
        public BindingList<CargaATM> listarCargasATMsPorRuta(byte r, DateTime f)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
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

                    CargaATM carga = new CargaATM(atm: atm, id: id_carga, tipo: tipo,
                                                  atm_full: atm_full, cartucho_rechazo: cartucho_rechazo,
                                                  ena: ena, orden_ruta: orden_ruta);

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
        /// Obtener una lista de las cargas de emergencia no utilizadas en una fecha específica.
        /// </summary>
        /// <param name="fecha">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cargas de emergencia no utilizadas</returns>
        public BindingList<CargaATM> listarCargasATMsEmergenciasNoUtilizadas(DateTime f)
        {
            BindingList<CargaATM> cargas = new BindingList<CargaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsEmergenciasNoUtilizadas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["pk_ID"];
                    byte emergencia = (byte)datareader["Emergencia"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];

                    CargaATM carga = new CargaATM(id: id_carga, emergencia: emergencia, fecha_asignada: f, tipo: tipo);

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
        /// Obtener una lista de las cargas del cierre de un cajero de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre del cajero de ATM's</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasATMsPorCierreATMs(CierreATMs c)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectListaCargasATMsCierreATMs");
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
        /// Obtener los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM que representa la carga para la cual se obtienen los datos</param>
        public void obtenerDatosCargaATM(ref CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaATMDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    DateTime hora_inicio = datareader["Hora_Inicio"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Inicio"];
                    DateTime hora_finalizacion = datareader["Hora_Finalizacion"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Finalizacion"];


                    DateTime hora_inicio_punto = datareader["Hora_Inicio_Punto"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Inicio_Punto"];
                    DateTime hora_finalizacion_punto = datareader["Hora_Finalizacion_Punto"] == DBNull.Value ?
                        DateTime.Today : (DateTime)datareader["Hora_Finalizacion_Punto"];


                    byte? ruta = datareader["Ruta"] as byte?;
                    byte? orden_ruta = datareader["Orden_Ruta"] as byte?;
                    string observaciones = (string)datareader["Observaciones"];

                    ManifiestoATMCarga manifiesto = null;

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id = (int)datareader["ID_Manifiesto"];
                        string codigo = (string)datareader["Codigo_Manifiesto"];
                        string marchamo = (string)datareader["Marchamo_Manifiesto"];
                        string marchamo_adicional = (string)datareader["Marchamo_Adicional"];
                        string bolsa_rechazo = datareader["Bolsa_Rechazo"] as string;
                        DateTime fecha = (DateTime)datareader["Fecha_Manifiesto"];

                        manifiesto = new ManifiestoATMCarga(codigo, marchamo, fecha, bolsa_rechazo, marchamo_adicional, id: id);
                    }

                    ManifiestoATMFull manifiesto_full = null;

                    if (datareader["ID_Manifiesto_Full"] != DBNull.Value)
                    {
                        int id = (int)datareader["ID_Manifiesto_Full"];
                        string codigo = (string)datareader["Codigo_Manifiesto_Full"];
                        string marchamo = (string)datareader["Marchamo_Manifiesto_Full"];
                        string marchamo_adicional_ena = datareader["Marchamo_Adicional_ENA"] as string;
                        string marchamo_ena_a = datareader["Marchamo_ENA_A"] as string;
                        string marchamo_ena_b = datareader["Marchamo_ENA_B"] as string;
                        string bolsa_rechazo_full = "";
                        if (datareader["Bolsa_Rechazo_ATM_Full"] != DBNull.Value)
                        {
                            bolsa_rechazo_full = datareader["Bolsa_Rechazo_ATM_Full"] as string;
                        }

                        DateTime fecha = (DateTime)datareader["Fecha_Manifiesto_Full"];

                        manifiesto_full = new ManifiestoATMFull(codigo, marchamo, fecha, marchamo_adicional_ena, marchamo_ena_a,
                                                                marchamo_ena_b, bolsa_rechazo_full, id: id);
                    }

                    c.Hora_inicio = hora_inicio;
                    c.Hora_finalizacion = hora_finalizacion;
                    c.HoraEntregaoBoveda = hora_inicio_punto;
                    c.HoraRecibidoBoveda = hora_finalizacion_punto;
                    c.Ruta = ruta;
                    c.Orden_ruta = orden_ruta;
                    c.Observaciones = observaciones;
                    c.Manifiesto = manifiesto;
                    c.Manifiesto_full = manifiesto_full;
                    Tripulacion tripulacion = new Tripulacion();

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
                        int id_dispositivo = (int)datareader["ID_Dispositivo"];
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

                    int id_receptor = 0;
                    Colaborador receptor = new Colaborador();
                    if (datareader["ID_Receptor"] != DBNull.Value)
                    {
                        id_receptor = (int)datareader["ID_Receptor"];
                        string nombre_receptor = (string)datareader["Nombre_Receptor"];
                        string primer_apellido = (string)datareader["PrimerApellido_Receptor"];
                        string segundo_apellido = (string)datareader["SegundoApellido_Receptor"];

                        receptor.Nombre = nombre_receptor;
                        receptor.Primer_apellido = primer_apellido;
                        receptor.Segundo_apellido = segundo_apellido;
                    }

                    receptor.ID = id_receptor;
                    c.Tripulacion = tripulacion;
                    c.ColaboradorRecibidoBoveda = receptor;
                    c.ReceptorTulas = receptor;

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
        /// Obtener una lista de las cargas para el libro mayor de una determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasATMsLibroMayor(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMsLibroMayor");
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
        /// Obtener una lista de las cargas para el libro mayor de una determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasATMsLibroMayorReporte(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasLibroMayor");
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


        public DataTable listarDescargasATMsLibroMayorReporte(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargasLibroMayor");
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
        /// Obtener los datos de la verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaATM que representa la carga para la cual se obtienen los datos de verificación</param>
        public void obtenerDatosVerificacionCarga(ref CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargaATMDatosVerificacion");
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


        public void actualizarCargaATMDatosRoadnet(DateTime f)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMsDesdeRoadnet");

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            comando.CommandTimeout = 600;


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
        /// Lista de todos los tipos de Cargas registradas en el sistema 
        /// </summary>
        /// <returns>Un DataTable con las Cargas obtenidos</returns>
        public BindingList<Carga> listarCargasTotales(ATM a, DateTime f, byte? ruta)
        {
            BindingList<Carga> cargas = new BindingList<Carga>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasTotales");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    int emergencias = (int)datareader["Emergencia"];
                    bool emergencia = false;
                    if (emergencias == 0)
                        emergencia = false;
                    else
                        emergencia = true;


                    int tipo_pedido = (int)datareader["Pedido"];

                    DateTime? hora_llegada = null;

                    if (datareader["Hora_Vehiculo_Inicial"] != DBNull.Value)
                        hora_llegada = (DateTime)datareader["Hora_Vehiculo_Inicial"];


                    DateTime? hora_salida = null;

                    if (datareader["Hora_Vehiculo_Final"] != DBNull.Value)
                        hora_salida = (DateTime)datareader["Hora_Vehiculo_Final"];

                    DateTime? hora_inicio_punto = null;

                    if (datareader["Hora_Punto_Inicial"] != DBNull.Value)
                        hora_inicio_punto = (DateTime)datareader["Hora_Punto_Inicial"];


                    DateTime? hora_final_punto = null;

                    if (datareader["Hora_Punto_Final"] != DBNull.Value)
                        hora_final_punto = (DateTime)datareader["Hora_Punto_Final"];


                    DateTime hora_programadas = (DateTime)datareader["Hora_Programada"];




                    byte? rutas = datareader["Ruta"] as byte?;
                    int rutita = Convert.ToInt32(rutas);

                    int orden_rutas = (int)datareader["Orden_Ruta"];
                    int orden_ruta = Convert.ToInt32(orden_rutas);
                    TipoCargas tipo_carga = (TipoCargas)datareader["Tipo_Carga"];

                    short id_canal = 0;
                    if (datareader["ID_Canal"] != DBNull.Value)
                    {
                        id_canal = (short)datareader["ID_Canal"];
                    }

                    short numero_canal = 0;
                    if (datareader["Numero_Canal"] != DBNull.Value)
                    {
                        numero_canal = (short)datareader["Numero_Canal"];
                    }

                    string observaciones = "";
                    if (datareader["ObservacionesRuta"] != DBNull.Value)
                    {
                        observaciones = (string)datareader["ObservacionesRuta"];
                    }

                    string canal_nombre = "";
                    if (datareader["Canal_Nombre"] != DBNull.Value)
                    {
                        canal_nombre = (string)datareader["Canal_Nombre"];
                    }

                    Decimal monto = 0;
                    if (datareader["Monto Total Colones"] != DBNull.Value)
                    {
                        monto = (Decimal)datareader["Monto Total Colones"];
                    }


                    bool handheld = false;
                    bool manual = false;

                    if (datareader["HandHeld"] != DBNull.Value)
                    {
                        handheld = (bool)datareader["HandHeld"];
                    }

                    if (datareader["Manual"] != DBNull.Value)
                    {
                        manual = (bool)datareader["Manual"];
                    }
                    Carga carga = new Carga(id: id_carga, hora_ent_boveda: hora_llegada, hora_rec_boveda: hora_salida, ruta: rutita, orden_ruta: orden_ruta, tipoc: tipo_carga, nombre: canal_nombre, observaciones: observaciones, emergencia: emergencia, idcanal: id_canal, monto: monto, numero_punto: numero_canal, hora_programada: hora_programadas, hora_inicio_punto: hora_inicio_punto, hora_final_punto: hora_final_punto, tipo_ped: Convert.ToBoolean(tipo_pedido), hand_held: handheld, manual: manual);


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
        /// Lista de todos los tipos de Cargas registradas en el sistema 
        /// </summary>
        /// <returns>Un DataTable con las Cargas obtenidos</returns>
        public BindingList<Carga> listarCargasTotalesControlRuta(ATM a, DateTime f, byte? ruta)
        {
            BindingList<Carga> cargas = new BindingList<Carga>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasTotalesControlRuta");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    int emergencias = (int)datareader["Emergencia"];
                    bool emergencia = false;
                    if (emergencias == 0)
                        emergencia = false;
                    else
                        emergencia = true;


                    int tipo_pedido = (int)datareader["Pedido"];

                    DateTime? hora_llegada = null;

                    if (datareader["Hora_Vehiculo_Inicial"] != DBNull.Value)
                        hora_llegada = (DateTime)datareader["Hora_Vehiculo_Inicial"];


                    DateTime? hora_salida = null;

                    if (datareader["Hora_Vehiculo_Final"] != DBNull.Value)
                        hora_salida = (DateTime)datareader["Hora_Vehiculo_Final"];

                    DateTime? hora_inicio_punto = null;

                    if (datareader["Hora_Punto_Inicial"] != DBNull.Value)
                        hora_inicio_punto = (DateTime)datareader["Hora_Punto_Inicial"];


                    DateTime? hora_final_punto = null;

                    if (datareader["Hora_Punto_Final"] != DBNull.Value)
                        hora_final_punto = (DateTime)datareader["Hora_Punto_Final"];


                    DateTime hora_programadas = (DateTime)datareader["Hora_Programada"];




                    byte? rutas = datareader["Ruta"] as byte?;
                    int rutita = Convert.ToInt32(rutas);

                    int orden_rutas = (int)datareader["Orden_Ruta"];
                    int orden_ruta = Convert.ToInt32(orden_rutas);
                    TipoCargas tipo_carga = (TipoCargas)datareader["Tipo_Carga"];

                    short id_canal = 0;
                    if (datareader["ID_Canal"] != DBNull.Value)
                    {
                        id_canal = (short)datareader["ID_Canal"];
                    }

                    short numero_canal = 0;
                    if (datareader["Numero_Canal"] != DBNull.Value)
                    {
                        numero_canal = (short)datareader["Numero_Canal"];
                    }

                    string observaciones = "";
                    if (datareader["ObservacionesRuta"] != DBNull.Value)
                    {
                        observaciones = (string)datareader["ObservacionesRuta"];
                    }

                    string canal_nombre = "";
                    if (datareader["Canal_Nombre"] != DBNull.Value)
                    {
                        canal_nombre = (string)datareader["Canal_Nombre"];
                    }

                    Decimal monto = 0;
                    if (datareader["Monto Total Colones"] != DBNull.Value)
                    {
                        monto = (Decimal)datareader["Monto Total Colones"];
                    }
                    Carga carga = new Carga(id: id_carga, hora_ent_boveda: hora_llegada, hora_rec_boveda: hora_salida, ruta: rutita, orden_ruta: orden_ruta, tipoc: tipo_carga, nombre: canal_nombre, observaciones: observaciones, emergencia: emergencia, idcanal: id_canal, monto: monto, numero_punto: numero_canal, hora_programada: hora_programadas, hora_inicio_punto: hora_inicio_punto, hora_final_punto: hora_final_punto, tipo_ped: Convert.ToBoolean(tipo_pedido));


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
        /// Actualizar los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto Carga con los datos de la carga</param>
        public void actualizarCargaATMHorasHojaRuta(Carga c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMHorasHojaRuta");

            _manejador.agregarParametro(comando, "@horasalidahangar", c.HoraEntregaBoveda, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@horaregresohangar", c.HoraRecibidoBoveda, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_inicio_punto", c.HoraInicioAtencionPunto, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_finalizacion_punto", c.HoraFinalAtencionPunto, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@hand_held", c.HandHeld, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@manual", c.Manual, SqlDbType.VarChar);
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
        /// Actualiza el orden de la ruta
        /// </summary>
        /// <param name="c"></param>
        public void actualizarCargasTotalesOrdenRuta(Carga c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateOrdenRutaCargasTotales");

            _manejador.agregarParametro(comando, "@orden", c.Orden_ruta, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo", c.TipoCargas, SqlDbType.Int);

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

        #endregion Métodos Públicos

        #region Recepcion de Tulas


        /// <summary>
        /// Registrar en el sistema la recepcion de la carga de un ATM
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void agregarRecepcionTulaCargaATM(ref CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMRecepcionBlindados");

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
                throw new Excepcion("ErrorCargaATMRegistro");
            }

        }


        /// <summary>
        /// Registrar en el sistema la recepcion de la carga de un ATM
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        //public void agregarEntregaTulaCargaATM(ref CargaATM c)
        //{
        //    SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMEntregaBlindados");

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
        //        throw new Excepcion("ErrorCargaATMRegistro");
        //    }

        //}


        /// <summary>
        /// Lista las cargas que se van a recibir para enviar a boveda
        /// </summary>
        /// <param name="marchamo">numero de marchamo a buscar</param>
        /// <returns></returns>
        public BindingList<Carga> listarCargas(String marchamo, EstadosPedidoBanco estadobanco, EntregaRecibo estadosucursal,
                                                EstadoDescargadaATM estadoAtm, byte? rutita, DateTime Fecha, int estado)
        {
            BindingList<Carga> cargas = new BindingList<Carga>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasTotalesReciboEntrega");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@estadobanco", estadobanco, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estadosucursal", estadosucursal, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estadoAtm", estadoAtm, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@ruta", rutita, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@descargafull", estado, SqlDbType.Bit);


            comando.CommandTimeout = 10000;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];

                    int id_bolsa = (int)datareader["Id_Bolsa"];

                    DateTime fecha_asignada = DateTime.UtcNow;

                    if (datareader["Hora"] != DBNull.Value)
                    {
                        fecha_asignada = (DateTime)datareader["Hora"];
                    }
                    String nombre = datareader["Nombre"] as string;
                    byte ruta = (byte)datareader["Ruta"];
                    byte order_ruta = (byte)datareader["Orden_Ruta"];
                    TipoCargas tipo = (TipoCargas)datareader["Tipo"];
                    DateTime fecha_pedido = (DateTime)datareader["Fecha"];
                    string dato = datareader["Dato"] as string;

                    Colaborador colaborador = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre_cajero = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segudo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        colaborador = new Colaborador(id: id_cajero, nombre: nombre_cajero, primer_apellido: primer_apellido, segundo_apellido: segudo_apellido);
                    }



                    Carga carga = new Carga(id: id_carga, cajero: colaborador, ruta: ruta, orden_ruta: order_ruta, hora_rec_boveda: fecha_pedido, tipoen: TipoEntregas.Recibido, nombre: nombre, dato: dato, tipoc: tipo, id_bolsa: id_bolsa);
                    carga.HoraRecibidoBoveda = fecha_asignada;

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
        /// Lista las cargas que se van a recibir para enviar a boveda
        /// </summary>
        /// <param name="marchamo">numero de marchamo a buscar</param>
        /// <returns></returns>
        public BindingList<Carga> listarDescargas(String marchamo, EstadosPedidoBanco estadobanco, EntregaRecibo estadosucursal,
                                                EstadoDescargadaATM estadoAtm, byte? rutita, DateTime Fecha, int estado)
        {
            BindingList<Carga> cargas = new BindingList<Carga>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargasTotalesReciboEntrega");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@estadobanco", estadobanco, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estadosucursal", estadosucursal, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estadoAtm", estadoAtm, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@ruta", rutita, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@descargafull", estado, SqlDbType.Bit);


            comando.CommandTimeout = 10000;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];

                    int id_bolsa = (int)datareader["Id_Bolsa"];

                    DateTime fecha_asignada = DateTime.UtcNow;

                    if (datareader["Hora"] != DBNull.Value)
                    {
                        fecha_asignada = (DateTime)datareader["Hora"];
                    }
                    String nombre = datareader["Nombre"] as string;
                    byte ruta = (byte)datareader["Ruta"];
                    byte order_ruta = (byte)datareader["Orden_Ruta"];
                    TipoCargas tipo = (TipoCargas)datareader["Tipo"];
                    DateTime fecha_pedido = (DateTime)datareader["Fecha"];
                    string dato = datareader["Dato"] as string;

                    Colaborador colaborador = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre_cajero = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segudo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        colaborador = new Colaborador(id: id_cajero, nombre: nombre_cajero, primer_apellido: primer_apellido, segundo_apellido: segudo_apellido);
                    }



                    Carga carga = new Carga(id: id_carga, cajero: colaborador, ruta: ruta, orden_ruta: order_ruta, hora_rec_boveda: fecha_pedido, tipoen: TipoEntregas.Recibido, nombre: nombre, dato: dato, tipoc: tipo, id_bolsa: id_bolsa);
                    carga.HoraRecibidoBoveda = fecha_asignada;

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






        #endregion Recepcion de Tulas

        #region Entrega de Tulas

        /// <summary>
        /// Registrar en el sistema la entrega de la carga de un ATM
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void agregarEntregaTulaCargaATM(ref CargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaATMEntregaBlindados");

            _manejador.agregarParametro(comando, "@carga", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@usuario", c.ColaboradorRecibidoBoveda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora_recibido", c.HoraRecibidoBoveda, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@entrega", c.TipoEntregas, SqlDbType.Bit);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMRegistro");
            }

        }



        public BindingList<Carga> listarCargasEntrega(String marchamo)
        {
            BindingList<Carga> cargas = new BindingList<Carga>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasTotalesRecepcion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@marchamo", marchamo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];

                    DateTime fecha_asignada = DateTime.UtcNow;

                    if (datareader["Hora_Recibido"] != DBNull.Value)
                    {
                        fecha_asignada = (DateTime)datareader["Hora_Recibido"];
                    }
                    String nombre = datareader["Nombre"] as string;
                    byte ruta = (byte)datareader["Ruta"];
                    byte order_ruta = (byte)datareader["Orden_Ruta"];
                    TipoCargas tipo = (TipoCargas)datareader["Tipo"];
                    DateTime fecha_pedido = (DateTime)datareader["Fecha"];
                    string dato = datareader["Dato"] as string;

                    Colaborador colaborador = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre_cajero = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Cajero"];
                        string segudo_apellido = (string)datareader["Segundo_Apellido_Cajero"];

                        colaborador = new Colaborador(id: id_cajero, nombre: nombre, primer_apellido: primer_apellido, segundo_apellido: segudo_apellido);
                    }



                    Carga carga = new Carga(id: id_carga, cajero: colaborador, ruta: ruta, orden_ruta: order_ruta, hora_rec_boveda: fecha_asignada, tipoen: TipoEntregas.Recibido, nombre: nombre, dato: dato, tipoc: tipo);


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

        #endregion Entrega de Tulas

        #region Visita sólo Descarga y Papel


        /// <summary>
        /// Actualiza los datos de las descargas del ENA y rutas con papel. 
        /// </summary>
        /// <param name="formulas">Cantidad de fórmulas</param>
        public void actualizarVisitasDescargaPapel(int formulas)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateVisitasDescargasPapel");

            _manejador.agregarParametro(comando, "@formulas", formulas, SqlDbType.Int);

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


        #endregion Visitas sólo Descarga y Papel 

        #region DatosCierre

        public DataTable listarDatosCierreCargas(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosCierreCargas");
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


        public DataTable listarDatosCierreDescargas(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosCierreDescargas");
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

        #endregion DatosCierre

        #region ATM Full Libro
        public DataTable listarDescargasATMsFullLibroMayorReporte(DateTime f)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDescargasLibroMayorFull");
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

        #endregion ATM Full Libro
    }

}
