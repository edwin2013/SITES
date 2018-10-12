//
//  @ Project : 
//  @ File Name : CargasEmergenciaATMsFullDL.cs
//  @ Date : 04/03/2013
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

    public class CargasEmergenciaATMsFullDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CargasEmergenciaATMsFullDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CargasEmergenciaATMsFullDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CargasEmergenciaATMsFullDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CargasEmergenciaATMsFullDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema la carga de emergencia de un ATM Full.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATMFull con los datos de la carga de emergencia</param>
        public void agregarCargaEmergenciaATMFull(ref CargaEmergenciaATMFull c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCargaEmergenciaATMFull");

            _manejador.agregarParametro(comando, "@fecha_envio", c.Fecha_envio, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ena", c.ENA, SqlDbType.Bit);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaEmergenciaATMFullRegistro");
            }

        }

        /// <summary>
        /// Actualizar en el sistema la carga de emergencia de un ATM Full.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATMFull con los datos de la carga de emergencia</param>
        public void actualizarCargaEmergenciaATMFull(CargaEmergenciaATMFull c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCargaEmergenciaATMFull");

            _manejador.agregarParametro(comando, "@fecha_envio", c.Fecha_envio, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_carga", c.Fecha_carga, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@atm", c.ATM, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@ena", c.ENA, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaEmergenciaATMFullActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de emergencia de un ATM Full.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATMFull con los datos de la carga</param>
        public void eliminarCargaEmergenciaATM(CargaEmergenciaATMFull c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCargaEmergenciaATMFull");

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaEmergenciaATMFullEliminacion");
            }

        }
        
        /// <summary>
        /// Listar las cargas de emergencia  de ATM's Full por fecha.
        /// </summary>
        /// <param name="f">Fecha de las cargas que se listarán</param>
        public BindingList<CargaEmergenciaATMFull> listarCargasEmergenciaATMsFull(DateTime f)
        {
            BindingList<CargaEmergenciaATMFull> cargas = new BindingList<CargaEmergenciaATMFull>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasEmergenciaATMsFull");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    DateTime fecha_envio = (DateTime)datareader["Fecha_Envio"];
                    DateTime? fecha_carga = datareader["Fecha_Carga"] as DateTime?;
                    bool ena = (bool)datareader["ENA"];
                    bool descargada = (bool)datareader["Descargada"];

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
                                                                         marchamo_ena_a, marchamo_ena_b, bolsa_rechazo, id: id_manifiesto);

                    ATM atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string codigo = (string)datareader["Codigo"];
                        string oficinas = (string)datareader["Oficinas"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo, oficinas: oficinas);
                    }

                    CargaEmergenciaATMFull carga = new CargaEmergenciaATMFull(fecha_envio, manifiesto, ena, id: id_carga, atm: atm,
                                                                              fecha_carga: fecha_carga, descargada: descargada);

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

        #endregion Métodos Públicos

    }

}
