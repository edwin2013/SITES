//
//  @ Project : 
//  @ File Name : ContadoresDescargasATMsFullDL.cs
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

    public class ContadoresDescargasATMsFullDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ContadoresDescargasATMsFullDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ContadoresDescargasATMsFullDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ContadoresDescargasATMsFullDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ContadoresDescargasATMsFullDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el contador de una descarga full.
        /// </summary>
        /// <param name="c">Objeto ContadorDescargaATMFull con los datos del contador</param>
        /// <param name="d">Descarga a la que pertenece el contador</param>
        public void agregarContadorDescargaATMFull(ref ContadorDescargaATMFull c, DescargaATMFull d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDescargaATMFullContador");

            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorContadorDescargaATMFullRegistro");
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas depositadas de un contador de una descarga full.
        /// </summary>
        /// <param name="c">Objeto ContadorDescargaATMFull con los datos del contador</param>
        public void actualizarContadorDescargaATMFull(ContadorDescargaATMFull c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDescargaATMFullContador");

            _manejador.agregarParametro(comando, "@cantidad_depositada", c.Cantidad_depositada, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@contador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorContadorDescargaATMFullActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un contador de una descarga de un ATM Full.
        /// </summary>
        /// <param name="c">Objeto ContadorDescargaATMFull con los datos del contador</param>
        public void eliminarContadorDescargaATMFull(ContadorDescargaATMFull c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteContadorDescargaATMFull");

            _manejador.agregarParametro(comando, "@contador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorContadorDescargaATMFullEliminacion");
            }

        }

        /// <summary>
        /// Obtener los contadores de una descarga de un ATM Full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull con los datos de la descarga</param>
        public void obtenerContadoresDescargaATMFull(ref DescargaATMFull d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectContadoresDescargaATMFull");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descarga", d, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_contador_descarga = (int)datareader["ID_Contador_Descarga"];
                    short cantidad_depositada = (short)datareader["Cantidad_Depositada"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);

                    ContadorDescargaATMFull contador = new ContadorDescargaATMFull(denominacion, id: id_contador_descarga,
                                                                                   cantidad_depositada: cantidad_depositada);
                    if (contador.Denominacion.Moneda != Monedas.Euros)
                    {
                        if (contador.Denominacion.Moneda == Monedas.Colones)
                        {
                            if (contador.Denominacion.Valor > 500)
                                d.agregarContador(contador);
                        }
                        else
                            d.agregarContador(contador);
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
