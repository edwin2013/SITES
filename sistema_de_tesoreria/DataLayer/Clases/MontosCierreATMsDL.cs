//
//  @ Project : 
//  @ File Name : MontosCierreATMsDL.cs
//  @ Date : 18/12/2012
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

    public class MontosCierreATMsDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static MontosCierreATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static MontosCierreATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MontosCierreATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public MontosCierreATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el monto por denominación de un cierre de ATM's.
        /// </summary>
        /// <param name="m">Objeto MontoCierreATMs con los datos del monto por denominación</param>
        public void agregarMontoCierreATMs(ref MontoCierreATMs m, CierreATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCierreATMsMonto");

            _manejador.agregarParametro(comando, "@denominacion", m.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad", m.Cantidad, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo", m.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoCierreATMsRegistro");
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas de un monto por denominación de un cierre.
        /// </summary>
        /// <param name="m">Objeto MontoCierreATMs con los datos del monto por denominacion</param>
        public void actualizarMontoCierreATMs(MontoCierreATMs m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateMontoCierreATMs");

            _manejador.agregarParametro(comando, "@cantidad", m.Cantidad, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoCierreATMsActualizacion");
            }

        }

        /// <summary>
        /// Eliminar un monto por denominación de un cierre.
        /// </summary>
        /// <param name="m">Objeto MontoCierreATMs con los datos del monto</param>
        public void eliminarMontoCierreATMs(MontoCierreATMs m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteMontoCierreATMs");

            _manejador.agregarParametro(comando, "@monto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoCierreATMsEliminacion");
            }

        }

        /// <summary>
        /// Obtener los montos por denominación de un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        public void obtenerMontosCierreATMs(ref CierreATMs c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreATMsMontosCierreATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_monto = (int)datareader["ID_Monto"];
                    int cantidad = (int)datareader["Cantidad"];
                    TiposMontoCierre tipo = (TiposMontoCierre)datareader["Tipo"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    string codigo = datareader["Codigo"] as string;

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda, codigo: codigo);

                    MontoCierreATMs monto = new MontoCierreATMs(denominacion, id: id_monto, cantidad: cantidad, tipo: tipo);

                    c.agregarMontoCierre(monto);
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
