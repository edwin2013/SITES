//
//  @ Project : 
//  @ File Name : ParametrosDL.cs
//  @ Date : 18/02/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using CommonObjects.Graficos;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    public class ParametrosDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ParametrosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ParametrosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ParametrosDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ParametrosDL() { }

        #endregion Constructor

        #region Métodos Públicos
        
        #region Parámetros

        /// <summary>
        /// Registrar un parámetro de reporte en el sistema.
        /// </summary>
        /// <param name="p">Objeto Parametro con los datos del parametro</param>
        public void agregarParametro(ref Parametro p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertParametro");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@parametro_procedimiento", p.Parametro_procedimiento, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@procedimiento", p.Procedimiento, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@columna_texto", p.Columna_texto, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@columna_valor", p.Columna_valor, SqlDbType.VarChar);

            try
            {
                p.ID = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorParametroRegistro");
            }

        }

        /// <summary>
        /// Actualizar un parámetro de reporte en el sistema.
        /// </summary>
        /// <param name="r">Objeto Reporte con los datos del reporte</param>
        public void agregarParametroReporte(Parametro p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateParametro");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@parametro_procedimiento", p.Parametro_procedimiento, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@procedimiento", p.Procedimiento, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@columna_texto", p.Columna_texto, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@columna_valor", p.Columna_valor, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@parametro", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorParametroActualizacion");
            }

        }

        /// <summary>
        /// Listar todos los parámetros de reportes del sistema.
        /// </summary>
        /// <param name="c">Colaborador para el cuals e genera la lista</param>
        /// <returns>Una lista de todas las categorías de reportes</returns>
        public BindingList<Parametro> listarParametros()
        {
            BindingList<Parametro> parametros = new BindingList<Parametro>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectParametros");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    TiposParametro tipo = (TiposParametro)datareader["Tipo"];
                    string parametro_procedimiento = (string)datareader["Parametro_Procedimiento"];
                    string procedimiento = (string)datareader["Procedimiento"];
                    string columna_texto = (string)datareader["Columna_Texto"];
                    string columna_valor = (string)datareader["Columna_Valor"];

                    Parametro parametro = new Parametro(tipo, nombre, parametro_procedimiento, procedimiento,
                                                        columna_texto, columna_valor, id: id);

                    parametros.Add(parametro);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return parametros;
        }

        /// <summary>
        /// Obtener la lista de elementos de la tabla de un parametro.
        /// </summary>
        /// <param name="p">Parametro para el cual se busca obtener la lista de valores</param>
        public DataTable obtenerListaParametro(Parametro p)
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento(p.Procedimiento);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        #endregion Parámetros

        #endregion Métodos Públicos

    }

}
