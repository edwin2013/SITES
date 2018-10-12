//
//  @ Project : 
//  @ File Name : RechazosDescargasATMsDL.cs
//  @ Date : 11/12/2012
//  @ Author : Erick Chavarría 
//  

using System;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    public class RechazosDescargasATMsDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RechazosDescargasATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RechazosDescargasATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RechazosDescargasATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RechazosDescargasATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el rechazo de una descarga.
        /// </summary>
        /// <param name="r">Objeto RechazoDescargaATM con los datos del rechazo</param>
        /// <param name="d">Descarga a la que pertenece el contador</param>
        public void agregarRechazoDescargaATM(ref RechazoDescargaATM r, DescargaATM d, bool bolsa)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDescargaATMRechazo");

            _manejador.agregarParametro(comando, "@denominacion", r.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@bolsa", bolsa, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                r.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRechazoDescargaATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas descargadas de un rechazo de una descarga.
        /// </summary>
        /// <param name="r">Objeto RechazoDescargaATM con los datos del rechazo</param>
        public void actualizarRechazoDescargaATM(RechazoDescargaATM r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDescargaATMRechazo");

            _manejador.agregarParametro(comando, "@cantidad_descarga", r.Cantidad_descarga, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@rechazo", r, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRechazoDescargaATMActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un rechazo de una descarga de un ATM.
        /// </summary>
        /// <param name="r">Objeto RechazoDescargaATM con los datos del rechazo</param>
        public void eliminarRechazoDescargaATM(RechazoDescargaATM r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteDescargaATMRechazo");

            _manejador.agregarParametro(comando, "@rechazo", r, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRechazoDescargaATMEliminacion");
            }

        }

        /// <summary>
        /// Obtener los rechazos de una descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos de la descarga</param>
        public void obtenerRechazosDescargaATM(ref DescargaATM d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRechazosDescargaATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {

                    int id_rechazo_descarga = (int)datareader["ID_Rechazo_Descarga"];
                    short cantidad_descarga = (short)datareader["Cantidad_Descarga"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    string codigo = (string)datareader["Codigo"];
                    bool bolsa = false;

                    if(datareader["Bolsa"]!=DBNull.Value)
                    {
                        bolsa = (bool)datareader["Bolsa"];
                    }

                    
                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda, codigo: codigo);

                    RechazoDescargaATM rechazo = new RechazoDescargaATM(denominacion, id: id_rechazo_descarga, cantidad_descarga: cantidad_descarga, bolsa: bolsa);

                    d.agregarRechazo(rechazo);
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
