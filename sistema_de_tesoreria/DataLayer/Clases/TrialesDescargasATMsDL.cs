//
//  @ Project : 
//  @ File Name : TrialesDescargasATMsDL.cs
//  @ Date : 15/02/2013
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

    /// <summary>
    /// Clase de la capa de datos que maneja los triales de las descargas de los ATM's.
    /// </summary>
    public class TrialesDescargasATMsDL
    {
        
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TrialesDescargasATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TrialesDescargasATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TrialesDescargasATMsDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TrialesDescargasATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar el trial de una descarga de un ATM en el sistema.
        /// </summary>
        /// <param name="t">Objeto TrialDescargaATM con los datos del trial</param>
        public void agregarTrialDescargaATM(ref TrialDescargaATM t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTrialDescargaATM");

            _manejador.agregarParametro(comando, "@atm", t.ATM, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", t.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@full", t.Full, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@monto_colones", t.Monto_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_dolares", t.Monto_dolares, SqlDbType.Money);

            try
            {
                t.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTrialDescargaATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar el trial de una descarga de un ATM en el sistema.
        /// </summary>
        /// <param name="t">Objeto TrialDescargaATM con los datos del trial</param>
        public void actualizarTrialDescargaATM(TrialDescargaATM t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTrialDescargaATM");

            _manejador.agregarParametro(comando, "@monto_colones", t.Monto_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_dolares", t.Monto_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@trial", t, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTrialDescargaATMActualizacion");
            }

        }

        /// <summary>
        /// Obtener una lista de los triales de descargas para una fecha específica.
        /// </summary>
        /// <param name="fe">Fecha para la cual se genera la lista</param>
        /// <param name="fu">Valor que indica si se listarán los triales de las descargas full</param>
        /// <returns>Lista de triales de la fecha especificada</returns>
        public BindingList<TrialDescargaATM> listarTrialesDescargasATMs(DateTime fe, bool fu)
        {
            BindingList<TrialDescargaATM> triales = new BindingList<TrialDescargaATM>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTrialesDescargasATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fe, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@full", fu, SqlDbType.Bit);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_trial = (int)datareader["ID_Trial"];
                    decimal monto_colones = (decimal)datareader["Monto_Colones"];
                    decimal monto_dolares = (decimal)datareader["Monto_Dolares"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo);

                    TrialDescargaATM trial = new TrialDescargaATM(atm, fe, monto_colones, monto_dolares, fu, id: id_trial);

                    triales.Add(trial);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return triales;
        }

        /// <summary>
        /// Verificar si ya se registro el trial de un ATM.
        /// </summary>
        /// <param name="t">Objeto TrialDescargaATM con los datos del trial</param>
        /// <returns>Valor que indica si el trial ya fue registrado</returns>
        public bool verificarTrialDescargaATM(ref TrialDescargaATM t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTrialDescargaATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@atm", t.ATM, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", t.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@full", t.Full, SqlDbType.Bit);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != t.ID;

                    t.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTrialDescargaATM");
            }

            return existe;
        }
        
        #endregion Métodos Públicos
        
    }

}
