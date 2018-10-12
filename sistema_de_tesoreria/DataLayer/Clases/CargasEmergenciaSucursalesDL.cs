using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects;

namespace DataLayer.Clases
{
    public class CargasEmergenciaSucursalesDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CargasEmergenciaSucursalesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CargasEmergenciaSucursalesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CargasEmergenciaSucursalesDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CargasEmergenciaSucursalesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema la carga de emergencia de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaSucursal con los datos de la carga de emergencia/param>
        public void agregarCargaEmergenciaSucursal(ref CargaEmergenciaSucursal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCargaEmergenciaSucursal");

            _manejador.agregarParametro(comando, "@sucursal", c.Sucursal, SqlDbType.SmallInt);
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
        /// Eliminar los datos de una carga de emergencia de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaSucursal con los datos de la carga</param>
        public void eliminarCargaEmergenciaSucursal(CargaEmergenciaSucursal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCargaEmergenciaSucursal");

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
        public BindingList<CargaEmergenciaSucursal> listarCargasEmergenciaSucursales(DateTime f)
        {
            BindingList<CargaEmergenciaSucursal> cargas = new BindingList<CargaEmergenciaSucursal>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasEmergenciaSucursales");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["ID_Carga"];
                    int numero_emergencia = (int)(byte)datareader["Numero_Emergencia"];

                    Sucursal atm = null;

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        string nombre = (string)datareader["Nombre"];

                        atm = new Sucursal(id: id_atm, codigo: numero,nombre:nombre);
                    }

                    CargaEmergenciaSucursal carga = new CargaEmergenciaSucursal(id: id_carga, sucursal: atm, fecha: f);

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
        public void obtenerEmergenciasCargaEmergenciaSucursal(ref CargaEmergenciaSucursal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCargasSucursalCargaEmergenciaSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_carga = (int)datareader["pk_ID"];
                    byte emergencia = (byte)datareader["Emergencia"];
                    DateTime fecha_asignada = (DateTime)datareader["Fecha_Pedido"];


                    CargaSucursal carga = new CargaSucursal(id: id_carga, emergencia: emergencia, fecha_asignada: fecha_asignada);

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
