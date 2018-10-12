//
//  @ Project : 
//  @ File Name : CierresBovedaDL.cs
//  @ Date : 01/05/2012
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

    public class CierresBovedaDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CierresBovedaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CierresBovedaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CierresBovedaDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CierresBovedaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un cierre para un cajero de bóveda el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreBovedaCajero con los datos del cierre</param>
        public void agregarCierre(ref CierreBovedaCajero c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCierreBovedaCajero");

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@hora_inicio", c.Hora_inicio, SqlDbType.Time);
            _manejador.agregarParametro(comando, "@hora_cierre", c.Hora_cierre, SqlDbType.Time);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos del cierre de un cajero de bóveda.
        /// </summary>
        /// <param name="c">Objeto CierreBovedaCajero con los datos del cierre</param>
        public void actualizarCierre(CierreBovedaCajero c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCierreBovedaCajero");

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@hora_inicio", c.Hora_inicio, SqlDbType.Time);
            _manejador.agregarParametro(comando, "@hora_cierre", c.Hora_cierre, SqlDbType.Time);
            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreActualizacion");
            }

        }
        /// <summary>
        /// Eliminar los datos del cierre de un cajero de bóveda.
        /// </summary>
        /// <param name="c">Objeto CierreBovedaCajero con los datos del cierre a eliminar</param>
        public void eliminarCierre(CierreBovedaCajero c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCierreBovedaCajero");

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreEliminacion");
            }

        }

        /// <summary>
        /// Obtener los datos del cierre de un cajero de bóveda.
        /// </summary>
        /// <param name="c">Objeto CierreBovedaCajero con los datos del cierre</param>
        public void obtenerDatosCierre(ref CierreBovedaCajero c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreBovedaCajero");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Hora_inicio = (DateTime)datareader["Hora_Inicio"];
                    c.Hora_cierre = (DateTime)datareader["Hora_Cierre"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador,
                                                              primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);

                    c.Coordinador = coordinador;
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
        /// Obtener las inconsistencias ligadas al cierre de un cajero y un digitador del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen las inconsistencias</param>
        public BindingList<InconsistenciaDeposito> obtenerInconsistenciasCierre(CierreCEF c)
        {
            BindingList<InconsistenciaDeposito> inconsistencias = new BindingList<InconsistenciaDeposito>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFInconsistencias");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    decimal diferencia_colones = (decimal)datareader["Diferencia_Colones"];
                    decimal diferencia_dolares = (decimal)datareader["Diferencia_Dolares"];

                    decimal diferencia_euros = 0;
                    
                    if(datareader["Diferencia_Euros"]!=DBNull.Value)
                        diferencia_euros= (decimal)datareader["Diferencia_Euros"];

                    InconsistenciaDeposito inconsistencia =
                        new InconsistenciaDeposito(id, diferencia_colones, diferencia_dolares, diferencia_euros);

                    inconsistencias.Add(inconsistencia);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }
        
        /// <summary>
        /// Verificar si existe un cierre para un cajero  y un digitador dados.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre a verificar</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public bool verificarCierre(ref CierreCEF c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteCierre");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != c.ID;

                    c.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarCierreDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los cierres registrados en determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cierres registrados en la fecha dada</returns>
        public BindingList<CierreCEF> listarCierres(DateTime f)
        {
            BindingList<CierreCEF> cierres = new BindingList<CierreCEF>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierres");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero,
                                                         primer_apellido_cajero,
                                                         segundo_apellido_cajero);
                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador,
                                                            primer_apellido_digitador,
                                                            segundo_apellido_digitador);
                    CierreCEF cierre = new CierreCEF(fecha: f, cajero: cajero, digitador: digitador);

                    cierres.Add(cierre);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cierres;
        }

        /// <summary>
        /// Obtener una lista de los cajeros con un cierre registrado por un coordinador.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <returns>Lista de cajeros con un cierre registrado en la fecha dada por el coordinador</returns>
        public BindingList<CierreCEF> listarCierresCajerosCoordinador(DateTime f, Colaborador c)
        {
            BindingList<CierreCEF> cierres = new BindingList<CierreCEF>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresCajerosCoordinador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero,
                                                         primer_apellido_cajero,
                                                         segundo_apellido_cajero);

                    CierreCEF cierre = new CierreCEF(fecha: f, cajero: cajero, coordinador: c);

                    cierres.Add(cierre);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cierres;
        }

        /// <summary>
        /// Obtener los manifiestos actualizados por un coordinador.
        /// </summary>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de manifiestos del coordinador</returns>
        public DataTable listarManifiestosCoordinador(Colaborador c, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosCoordinador");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);
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
        /// Obtener los montos por cliente para el cierre de un coordinador.
        /// </summary>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesCoordinadorCierre(Colaborador c, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreMontosClientesCoordinador");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);
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

        #endregion Métodos Públicos

    }

}
