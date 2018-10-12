//
//  @ Project : 
//  @ File Name : ReportesDL.cs
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

    public class ReportesDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ReportesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ReportesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ReportesDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ReportesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Obtener los datos de la consulta.
        /// </summary>
        /// <param name="i">Fecha incial para la cual se desea delimitar el reporte</param>
        /// <param name="f">Fecha final para la cual se desea delimitar el reporte</param>
        /// <param name="a">Área para la cual se genera el reporte</param>
        /// <param name="r">Reporte para el cual se generá la consulta</param>
        /// <returns>Tabla con los datos devueltos por la consulta</returns>
        public DataTable obtenerDatosReporte(DateTime i, DateTime f, Areas a, Reporte r)
        {
            try
            {
                return this.obtenerDatosConsulta(i, f, a, r, null);
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorGeneracionReporte");
            }

        }

        /// <summary>
        /// Obtener los datos de una consulta para la generación de un gráfico asociado a un reporte.
        /// </summary>
        /// <param name="i">Fecha incial para la cual se desea delimitar la consulta asociada al gráfico</param>
        /// <param name="f">Fecha final para la cual se desea delimitar la consulta asociada al gráfico</param>
        /// <param name="a">Área para la cual se genera el gráfico</param>
        /// <param name="g">Gráfico para el cual se ejecuta la consulta</param>
        /// <param name="r">Reporte al cual está asociado el gráfico</param>
        /// <returns>Tabla con los datos devueltos por la consulta</returns>
        public DataTable obtenerDatosGrafico(DateTime i, DateTime f, Areas a, Grafico g, Reporte r)
        {

            try
            {
                return this.obtenerDatosConsulta( i, f, a, r, g);
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorGeneracionGrafico");
            }

        }

        /// <summary>
        /// Obtener los datos de una consulta.
        /// <param name="i">Fecha incial para la cual se desea delimitar la consulta</param>
        /// <param name="f">Fecha final para la cual se desea delimitar la consulta</param>
        /// <param name="a">Área para la cual se genera el gráfico</param>
        /// <param name="r">Reporte que contiene los parámetros de la consulta</param>
        /// <param name="g">Gráfico para el cual se desea generar la consulta si la misma esta ligada a un gráfico</param>
        /// <returns>Tabla con los datos devueltos por la consulta</returns>
        private DataTable obtenerDatosConsulta(DateTime i, DateTime f, Areas a, Reporte r, Grafico g)
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento(g == null ? r.Procedimiento : g.Procedimiento);

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", f, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@area", a, SqlDbType.TinyInt);

            // Agregar los parámetros

            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.SmallInt, SqlDbType .TinyInt};

            foreach (Parametro parametro in r.Parametros)
            {
                object valor = parametro.Valor;
                SqlDbType tipo = tipos[(byte)parametro.Tipo];
                string procedimiento = parametro.Parametro_procedimiento;
                DbType bd_type = DbType.Int32;
                

                if (valor != null)
                    _manejador.agregarParametro(comando, procedimiento, valor, tipo);

            }

            //Ejecutar la consulta

            try
            {
                comando.CommandTimeout = 100000;
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
              
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw ex;
            }

            return salida;
        }

        #region Parámetros

        /// <summary>
        /// Asignar un parámetro a un reporte.
        /// </summary>
        /// <param name="p">Objeto Parametro con los datos del parametro</param>
        /// <param name="r">Objeto Reporte con los datos del reporte</param>
        public void agregarParametroReporte(Parametro p, Reporte r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertReporteParametro");

            _manejador.agregarParametro(comando, "@reporte", r, SqlDbType.Int);
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
        /// Desligar un parámetro de un reporte.
        /// </summary>
        /// <param name="p">Objeto Parametro con los datos del parametro</param>
        /// <param name="r">Objeto Reporte con los datos del reporte del que se desligará el parámetro</param>
        public void eliminarParametroReporte(Parametro p, Reporte r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteReporteParametro");

            _manejador.agregarParametro(comando, "@reporte", r, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@parametro", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorColaboradorActualizacion");
            }

        }

        /// <summary>
        /// Obtener los parametros de un reporte.
        /// </summary>
        /// <param name="r">Reporte para el cual se busca obtener sus parámetros</param>
        public void obtenerParametrosReporte(ref Reporte r)
        {
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectParametrosReporte");

            _manejador.agregarParametro(comando, "@reporte", r.ID, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    TiposParametro tipo = (TiposParametro)datareader["Tipo"];
                    string nombre = (string)datareader["Nombre"];
                    string parametro_procedimiento = (string)datareader["Parametro_Procedimiento"];
                    string procedimiento = (string)datareader["Procedimiento"];
                    string columna_valor = (string)datareader["Columna_Valor"];
                    string columna_texto = (string)datareader["Columna_Texto"];

                    Parametro parametro = new Parametro(tipo, nombre, parametro_procedimiento, procedimiento, columna_texto, columna_valor, id: id);

                    r.agregarParametro(parametro);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Parámetros

        #region Gráficos

        /// <summary>
        /// Obtener los gráficos de tipo BoxPlot ligados a un reporte.
        /// </summary>
        /// <param name="r">Reporte para el cual se busca obtener los gráficos ligados al mismo</param>
        public void obtenerGraficosBoxplot(ref Reporte r)
        {
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGraficosBoxPlot");

            _manejador.agregarParametro(comando, "@reporte", r.ID, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string descripcion = (string)datareader["Descripcion"];
                    string procedimiento = (string)datareader["Procedimiento"];
                    string campo_x = (string)datareader["Campo_X"];
                    string campo_y = (string)datareader["Campo_Y"];
                    string serie = (string)datareader["Serie"];

                    GraficoBoxPlot grafico = new GraficoBoxPlot(id, nombre, descripcion, procedimiento, campo_x, campo_y, serie);
                    r.agregarGrafico(grafico);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener los gráficos de tipo Historigrama ligados a un reporte.
        /// </summary>
        /// <param name="r">Reporte para el cual se busca obtener los gráficos ligados al mismo</param>
        public void obtenerGraficosHistograma(ref Reporte r)
        {
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGraficosHistograma");

            _manejador.agregarParametro(comando, "@reporte", r.ID, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string descripcion = (string)datareader["Descripcion"];
                    string procedimiento = (string)datareader["Procedimiento"];
                    string campo_y = (string)datareader["Campo_Y"];
                    string serie = (string)datareader["Serie"];

                    GraficoHistograma grafico = new GraficoHistograma(id, nombre, descripcion, procedimiento, campo_y, serie);
                    r.agregarGrafico(grafico);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener los gráficos de barras ligados a un reporte.
        /// </summary>
        /// <param name="r">Reporte para el cual se busca obtener los gráficos ligados al mismo</param>
        public void obtenerGraficosBarra(ref Reporte r)
        {
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGraficosBarras");

            _manejador.agregarParametro(comando, "@reporte", r.ID, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string descripcion = (string)datareader["Descripcion"];
                    string procedimiento = (string)datareader["Procedimiento"];
                    string campo_x = (string)datareader["Campo_X"];
                    string campo_y = (string)datareader["Campo_Y"];
                    string serie = (string)datareader["Serie"];

                    GraficoBarra grafico = new GraficoBarra(id, nombre, descripcion, procedimiento, campo_x, campo_y, serie);
                    r.agregarGrafico(grafico);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener los gráficos de barras y lineas ligados a un reporte.
        /// </summary>
        /// <param name="r">Reporte para el cual se busca obtener los gráficos ligados al mismo</param>
        public void obtenerGraficosBarraLinea(ref Reporte r)
        {
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGraficosBarrasLineas");

            _manejador.agregarParametro(comando, "@reporte", r.ID, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string descripcion = (string)datareader["Descripcion"];
                    string procedimiento = (string)datareader["Procedimiento"];
                    string campo_x = (string)datareader["Campo_X"];
                    string campo_y_barras = (string)datareader["Campo_Y_Barras"];
                    string campo_y_lineas = (string)datareader["Campo_Y_Lineas"];
                    string serie_barras = (string)datareader["Serie_Barras"];
                    string serie_lineas = (string)datareader["Serie_Lineas"];

                    GraficoBarraLinea grafico =
                        new GraficoBarraLinea(id, nombre, descripcion, procedimiento, campo_x, campo_y_barras, campo_y_lineas, serie_barras, serie_lineas);
                    r.agregarGrafico(grafico);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener los gráficos de tipo Pie ligados a un reporte.
        /// </summary>
        /// <param name="r">Reporte para el cual se busca obtener los gráficos ligados al mismo</param>
        public void obtenerGraficosPie(ref Reporte r)
        {
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGraficosPie");

            _manejador.agregarParametro(comando, "@reporte", r.ID, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string descripcion = (string)datareader["Descripcion"];
                    string procedimiento = (string)datareader["Procedimiento"];
                    string campo_x = (string)datareader["Campo_X"];
                    string campo_y = (string)datareader["Campo_Y"];
                    string serie = (string)datareader["Serie"];

                    GraficoPie grafico = new GraficoPie(id, nombre, descripcion, procedimiento, campo_x, campo_y, serie);
                    r.agregarGrafico(grafico);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Gráficos

        #endregion Métodos Públicos

    }

}
