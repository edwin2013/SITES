//
//  @ Project : 
//  @ File Name : CargasEmergenciaATMsDL.cs
//  @ Date : 04/01/2013
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

    public class CargasEmergenciaATMsDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CargasEmergenciaATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CargasEmergenciaATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CargasEmergenciaATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CargasEmergenciaATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema la carga de emergencia de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga de emergencia/param>
        public void agregarCargaEmergenciaATM(ref CargaEmergenciaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCargaEmergenciaATM");

            _manejador.agregarParametro(comando, "@atm", c.ATM, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaEmergenciaATMRegistro");
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de emergencia de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga</param>
        public void eliminarCargaEmergenciaATM(CargaEmergenciaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCargaEmergenciaATM");

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaEmergenciaATMEliminacion");
            }

        }
        
        /// <summary>
        /// Listar las cargas de emergencia por fecha.
        /// </summary>
        /// <param name="f">Fecha de las cargas que se listarán</param>
        public BindingList<CargaEmergenciaATM> listarCargasEmergenciaATMs(DateTime f)
        {
            BindingList<CargaEmergenciaATM> cargas = new BindingList<CargaEmergenciaATM>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasEmergenciaATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    bool descargada = (bool)datareader["Descargada"];
                    int numero_emergencia = (int)(byte)datareader["Numero_Emergencia"];

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo);
                    }

                    CargaEmergenciaATM carga = new CargaEmergenciaATM(id: id_carga, atm: atm, fecha: f, descargada: descargada, numero_emergencia: numero_emergencia);

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
        /// Obtener las emergencias ligadas a la carga de emergenciade un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga de emergencia</param>
        public void obtenerEmergenciasCargaEmergenciaATM(ref CargaEmergenciaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasATMCargaEmergenciaATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["pk_ID"];
                    byte emergencia = (byte)datareader["Emergencia"];
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Asignada"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];

                    CargaATM carga = new CargaATM(id: id_carga, emergencia: emergencia, fecha_asignada: fecha_asignada, tipo: tipo);

                    c.agregarEmergencia(carga);
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
