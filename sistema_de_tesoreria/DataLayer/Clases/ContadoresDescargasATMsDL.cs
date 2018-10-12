//
//  @ Project : 
//  @ File Name : ContadoresDescargasATMsDL.cs
//  @ Date : 11/12/2012
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

    public class ContadoresDescargasATMsDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ContadoresDescargasATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ContadoresDescargasATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ContadoresDescargasATMsDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ContadoresDescargasATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el contador de una descarga.
        /// </summary>
        /// <param name="c">Objeto ContadorDescargaATM con los datos del contador</param>
        /// <param name="d">Descarga a la que pertenece el contador</param>
        public void agregarContadorDescargaATM(ref ContadorDescargaATM c, DescargaATM d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDescargaATMContador");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            // Para Contadores Automaticos agregar los atributos de dispensado y remanente por contador. 

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorContadorDescargaATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas dipensadas y remanentes de un contador de una descarga.
        /// </summary>
        /// <param name="c">Objeto ContadorDescargaATM con los datos del contador</param>
        public void actualizarContadorDescargaATM(ContadorDescargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDescargaATMContador");

            _manejador.agregarParametro(comando, "@cantidad_dispensada_a", c.Cantidad_dispensada_a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_remanente_a", c.Cantidad_remanente_a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_dispensada_b", c.Cantidad_dispensada_b, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_remanente_b", c.Cantidad_remanente_b, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_dispensada_c", c.Cantidad_dispensada_c, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_remanente_c", c.Cantidad_remanente_c, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_dispensada_cartucho_rechazo", c.Cantidad_cartucho_rechazo, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_remanente_cartucho_rechazo", c.Cantidad_remanente_cartucho_rechazo, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_dispensada_bolsa_rechazo", c.Cantidad_bolsa_rechazo, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cantidad_remanente_bolsa_rechazo", c.Cantidad_remanente_c, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@contador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorContadorDescargaATMActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un contador de una descarga de un ATM.
        /// </summary>
        /// <param name="c">Objeto ContadorDescargaATM con los datos del contador</param>
        public void eliminarContadorDescargaATM(ContadorDescargaATM c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteContadorDescargaATM");

            _manejador.agregarParametro(comando, "@contador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorContadorDescargaATMEliminacion");
            }

        }

        /// <summary>
        /// Obtener los contadores de una descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos de la descarga</param>
        public void obtenerContadoresDescargaATM(ref DescargaATM d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectContadoresDescargaATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_contador_descarga = (int)datareader["ID_Contador_Descarga"];
                    short cantidad_dispensada_a = (short)datareader["Cantidad_Dispensada_A"];
                    short cantidad_remanente_a = (short)datareader["Cantidad_Remanente_A"];
                    short cantidad_dispensada_b = (short)datareader["Cantidad_Dispensada_B"];
                    short cantidad_remanente_b = (short)datareader["Cantidad_Remanente_B"];
                    short cantidad_dispensada_c = (short)datareader["Cantidad_Dispensada_C"];
                    short cantidad_remanente_c = (short)datareader["Cantidad_Remanente_C"];

                    short cantidad_remanente_bolsa = 0;
                    short cantidad_dispensado_bolsa = 0;
                    short cantidad_remanente_cartucho = 0;
                    short cantidad_dispensado_cartucho = 0;

                    if (datareader["Cantidad_Dispensada_CartuchoRechazo"] != DBNull.Value)
                    {
                        cantidad_dispensado_cartucho = (short)datareader["Cantidad_Dispensada_CartuchoRechazo"];
                    }

                    if (datareader["Cantidad_Dispensanda_Bolsa_Rechazo"] != DBNull.Value)
                    {
                        cantidad_dispensado_bolsa = (short)datareader["Cantidad_Dispensanda_Bolsa_Rechazo"];
                    }


                    if (datareader["Cantidad_Remanente_CartuchoRechazo"] != DBNull.Value)
                    {
                        cantidad_remanente_cartucho = (short)datareader["Cantidad_Remanente_CartuchoRechazo"];
                    }

                    if (datareader["Cantidad_Remanente_BolsaRechazo"] != DBNull.Value)
                    {
                        cantidad_remanente_bolsa = (short)datareader["Cantidad_Remanente_BolsaRechazo"];
                    }

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    string codigo = (string)datareader["Codigo"];

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda, codigo: codigo);

                    ContadorDescargaATM contador = new ContadorDescargaATM(denominacion, id: id_contador_descarga,
                                                                           cantidad_dispensada_a: cantidad_dispensada_a,
                                                                           cantidad_remanente_a: cantidad_remanente_a,
                                                                           cantidad_dispensada_b: cantidad_dispensada_b,
                                                                           cantidad_remanente_b: cantidad_remanente_b,
                                                                           cantidad_dispensada_c: cantidad_dispensada_c,
                                                                           cantidad_remanente_c: cantidad_remanente_c,
                                                                           cantidad_dispensada_cartucho_rechazo: cantidad_dispensado_cartucho,
                                                                           cantidad_dispensada_bolsa_rechazo: cantidad_dispensado_bolsa,
                                                                           cantidad_remanente_cartucho_rechazo: cantidad_remanente_cartucho,
                                                                           cantidad_remanente_bolsa_rechazo:cantidad_remanente_bolsa);

                    d.agregarContador(contador);
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
