//
//  @ Project : 
//  @ File Name : MontosDescargasATMsDL.cs
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

    public class MontosDescargasATMsFullDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static MontosDescargasATMsFullDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static MontosDescargasATMsFullDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MontosDescargasATMsFullDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public MontosDescargasATMsFullDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el monto de una descarga full.
        /// </summary>
        /// <param name="m">Objeto MontoDescargaATMFull con los datos del monto</param>
        /// <param name="d">Descarga a la que pertenece el monto</param>
        public void agregarMontoDescargaATMFull(ref MontoDescargaATMFull m, DescargaATMFull d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDescargaATMFullMonto");

            _manejador.agregarParametro(comando, "@denominacion", m.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoDescargaATMFullRegistro");
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas de un monto de una descarga full.
        /// </summary>
        /// <param name="m">Objeto MontoDescargaATMFull con los datos del monto</param>
        public void actualizarMontoDescargaATMFull(MontoDescargaATMFull m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDescargaATMFullMonto");

            _manejador.agregarParametro(comando, "@cantidad", m.Cantidad, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@monto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoDescargaATMFullActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un monto de una descarga full.
        /// </summary>
        /// <param name="m">Objeto MontoDescargaATMFull con los datos del monto</param>
        public void eliminarMontoDescargaATMFull(MontoDescargaATMFull m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteMontoDescargaATMFull");

            _manejador.agregarParametro(comando, "@monto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontoDescargaATMFullEliminacion");
            }

        }

        /// <summary>
        /// Obtener los montos de una descarga full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull con los datos de la descarga</param>
        public void obtenerMontosDescargaATMFull(ref DescargaATMFull d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectMontosDescargaATMFull");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_contador_descarga = (int)datareader["ID_Monto_Descarga"];
                    short cantidad = (short)datareader["Cantidad"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);

                    if (denominacion.Moneda != Monedas.Euros)
                    {

                        if (denominacion.Moneda == Monedas.Colones)
                        {
                            if (denominacion.Valor > 500)
                            {
                                MontoDescargaATMFull monto = new MontoDescargaATMFull(denominacion, id: id_contador_descarga, cantidad: cantidad);
                                d.agregarMonto(monto);
                            }
                        }
                        else
                        {
                            MontoDescargaATMFull monto = new MontoDescargaATMFull(denominacion, id: id_contador_descarga, cantidad: cantidad);
                            d.agregarMonto(monto);
                        }
                    }
                    
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
