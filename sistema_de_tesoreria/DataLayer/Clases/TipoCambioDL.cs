//
//  @ Project : 
//  @ File Name : TipoCambioDL.cs
//  @ Date : 05/08/2011
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
    /// Clase de la capa de datos que maneja los tipos de cambio.
    /// </summary>
    public class TipoCambioDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TipoCambioDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TipoCambioDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TipoCambioDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TipoCambioDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un tipo de cambio.
        /// </summary>
        /// <param name="u">Objeto TipoCambio con los datos del tipo de cambio</param>
        public void agregarTipoCambio(ref TipoCambio t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTipoCambio");

            _manejador.agregarParametro(comando, "@fecha", t.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@compra", t.Compra, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@venta", t.Venta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@compra_euros", t.CompraEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@venta_euros", t.VentaEuros, SqlDbType.Money);

            try
            {
                t.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoCambioRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos del tipo de cambio de una fecha determinada.
        /// </summary>
        /// <param name="u">Objeto TipoCambio con los datos del tipo de cambio</param>
        public void actualizarTipoCambio(TipoCambio t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTipoCambio");

            _manejador.agregarParametro(comando, "@compra", t.Compra, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@venta", t.Venta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@compra_euros", t.CompraEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@venta_euros", t.VentaEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@tipo_cambio", t.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoCambioActualizacion");
            }

        }

        /// <summary>
        /// Obtener el tipo de cambio de una fecha específica.
        /// </summary>
        /// <param name="f">Fecha para la cual se obtendrá el tipo de cambio</param>
        /// <returns>Objeto TipoCambio con los datos del tipo de cambio de la fecha especificada</returns>
        public TipoCambio obtenerTipoCambio(DateTime f)
        {
            TipoCambio tipo_cambio = null;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTipoCambio");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {

                    short id = (short)datareader["pk_ID"];
                    decimal venta = (decimal)datareader["Venta"];
                    decimal compra = (decimal)datareader["Compra"];
                    decimal venta_euros = 1;
                    if (datareader["Venta_Euros"] != DBNull.Value)
                    {
                        venta_euros = (decimal)datareader["Venta_Euros"];
                    }
                        
                    decimal compra_euros = 1;

                    if (datareader["Compra_Euros"] != DBNull.Value)
                    {
                        compra_euros = (decimal)datareader["Compra_Euros"];
                    }

                    tipo_cambio = new TipoCambio(id, f, venta, compra, venta_euros, compra_euros);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tipo_cambio;
        }

        /// <summary>
        /// Verificar si ya se registró el tipo de cambio para una fecha determinada.
        /// </summary>
        /// <param name="t">Objeto TipoCambio con los datos del tipo de cambio</param>
        /// <returns>Valor booleano que indica si el tipo de cmabio ya fue registrado</returns>
        public bool verificarTipoCambio(TipoCambio t)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTipoCambio");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", t.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id_encontrado = (short)datareader["pk_ID"];

                    existe = id_encontrado != t.Id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTipoCambio");
            }

            return existe;
        }

        #endregion Métodos Públicos

    }

}
