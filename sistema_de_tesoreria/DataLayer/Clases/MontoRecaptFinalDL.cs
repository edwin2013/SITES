using CommonObjects;
using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class MontoRecaptFinalDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static MontoRecaptFinalDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static MontoRecaptFinalDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MontoRecaptFinalDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public MontoRecaptFinalDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto MontosRecaptFinal con los datos del cartucho</param>
        public void agregarMontosRecaptFinal(ref MontosRecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertMontoRecapAdicional");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad_asignada", c.Cantidad_asignada, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@carga", c.Recapt, SqlDbType.Int);


            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontosRecaptFinalRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos del cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto MontosRecaptFinal con los datos del cartucho</param>
        public void actualizarMontosRecaptFinal(MontosRecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateMontosRecapAdicional");

            //_manejador.agregarParametro(comando, "@marchamo", c.Marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontosRecaptFinalActualizacion");
            }

        }

        

        /// <summary>
        /// Actualizar la cantidad de formulas cargadas del cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto MontosRecaptFinal con los datos del cartucho</param>
        public void actualizarMontosRecaptFinalCantidad(MontosRecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateMontosRecaptFinalCantidad");

            //_manejador.agregarParametro(comando, "@anulado", c.Anulado, SqlDbType.Bit);
            //_manejador.agregarParametro(comando, "@cantidad_carga", c.Cantidad_carga, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontosRecaptFinalActualizacion");
            }

        }

        /// <summary>
        /// Actualizar el cartucho asignado al cartucho de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto MontosRecaptFinal con los datos del cartucho de la carga del ATM</param>
        public void actualizarMontosRecaptFinalCartucho(MontosRecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoMontosRecaptFinal");

            _manejador.agregarParametro(comando, "@cartucho_carga", c, SqlDbType.Int);
           // _manejador.agregarParametro(comando, "@cartucho", c.Cartucho, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontosRecaptFinalActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto MontosRecaptFinal con los datos del cartucho</param>
        public void eliminarMontosRecaptFinal(MontosRecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteMontosRecaptFinal");

            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontosRecaptFinalEliminacion");
            }

        }

        /// <summary>
        /// Obtener los cartuchos de una carga de un ATM.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void obtenerMontosRecapAdicional(ref RecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectMontosRecapAdicional");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho_carga = (int)datareader["ID_Cartucho_Carga"];
                    decimal cantidad_asignada = (decimal)datareader["Cantidad_Asignada"];


                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    string codigo = (string)datareader["Codigo"];
                    string configuracion_diebold = (string)datareader["Configuracion_Diebold"];
                    string configuracion_opteva = (string)datareader["Configuracion_Opteva"];
                    byte? id_imagen = datareader["ID_Imagen"] as byte?;

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda, codigo: codigo,
                                                                 id_imagen: id_imagen, configuracion_diebold: configuracion_diebold,
                                                                 configuracion_opteva: configuracion_opteva);



                    MontosRecaptFinal cartucho_carga = new MontosRecaptFinal(denominacion, id: id_cartucho_carga, 
                                                                            cantidad_asignada: cantidad_asignada
                                                                          );

                    c.agregarCartucho(cartucho_carga);
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
