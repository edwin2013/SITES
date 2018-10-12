//
//  @ Project : 
//  @ File Name : SobresDL.cs
//  @ Date : 23/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los sobres.
    /// </summary>
    public class SobresDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static SobresDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static SobresDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SobresDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public SobresDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un sobre y ligarlo con una inconsistencia.
        /// </summary>
        /// <param name="s">Objeto Sobre con los datos del sobre</param>
        /// <param name="i">Inconsistencia en un deposito a la cual se ligará el sobre</param>
        public void agregarSobre(ref Sobre s, InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertSobre");

            _manejador.agregarParametro(comando, "@numero", s.Numero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_reportado", s.Monto_reportado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_real", s.Monto_real, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", s.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                s.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSobreRegistro");
            }

        }

        /// <summary>
        /// Eliminar los datos de un sobre.
        /// </summary>
        /// <param name="s">Objeto Sobre con los datos del sobre a eliminar</param>
        public void eliminaSobre(Sobre s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteSobre");

            _manejador.agregarParametro(comando, "@sobre", s.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSobreEliminacion");
            }

        }

        /// <summary>
        /// Obtener todos los sobres que pertenecen a una inconsistencia en un deposito.
        /// </summary>
        /// <param name="i">Inconsistencia en un deposito para la cual se obtiene la lista de sobre</param>
        public void obtenerSobresInconsistencia(ref InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciaDepositoSobres");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    int numero = (int)datareader["Numero"];
                    decimal monto_reportado = (decimal)datareader["Monto_Reportado"];
                    decimal monto_real = (decimal)datareader["Monto_Real"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    Sobre sobre = new Sobre(id, numero, monto_reportado, monto_real, moneda);
                    i.agregarSobre(sobre);
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
