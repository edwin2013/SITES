//
//  @ Project : 
//  @ File Name : RecapsExternosDL.cs
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

    /// <summary>
    /// Clase de la capa de datos que maneja los recaps.
    /// </summary>
    public class RecapsExternosDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RecapsExternosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RecapsExternosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RecapsExternosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RecapsExternosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito</param>
        public void agregarDeposito(ref Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDeposito");

            _manejador.agregarParametro(comando, "@referencia", d.Referencia, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", d.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", d.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cuenta", d.Cuenta, SqlDbType.BigInt);

            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito a actualizar</param>
        public void actualizarDeposito(Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDeposito");

            _manejador.agregarParametro(comando, "@referencia", d.Referencia, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", d.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", d.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cuenta", d.Cuenta, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@deposito", d.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito a eliminar</param>
        public void eliminarDeposito(Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteDeposito");

            _manejador.agregarParametro(comando, "@deposito", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un deposito ya está registrado en el sistema.
        /// </summary>
        /// <param name="d">Objeto Deposito con los datos del deposito</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarDeposito(Deposito d)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteDeposito");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@referencia", d.Referencia, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != d.ID;

                    d.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarDeposito");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los depositos que tienen un determinado número de referencia o parte del mismo.
        /// </summary>
        /// <param name="r">Referencia o parte de la misma de los depositos que se listarán</param>
        /// <returns>Lista de depositos que cumplen con el criterio de búsqueda</returns>
        public BindingList<Deposito> listarDepositosPorReferencia(int r)
        {
            BindingList<Deposito> depositos = new BindingList<Deposito>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDepositosReferencia");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@referencia", r, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Deposito"];
                    int referencia = (int)datareader["Referencia"];
                    decimal monto = (decimal)datareader["Monto"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    long cuenta = (long)datareader["Cuenta"];

                    Deposito deposito = new Deposito(referencia, id: id, monto: monto, moneda: moneda, cuenta: cuenta);

                    depositos.Add(deposito);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return depositos;
        }

        #endregion Métodos Públicos

    }

}
