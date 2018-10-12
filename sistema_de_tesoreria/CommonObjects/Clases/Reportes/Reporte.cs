//
//  @ Project : 
//  @ File Name : Reporte.cs
//  @ Date : 20/01/2011
//  @ Author : Erick Chavarría 
//

using System.Collections.Generic;

using LibreriaAccesoDatos;
using CommonObjects.Graficos;

namespace CommonObjects
{

    public class Reporte : ObjetoIndexado
    {

        #region Atributos Privados

        public byte ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        protected string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        protected string _procedimiento;

        public string Procedimiento
        {
            get { return _procedimiento; }
            set { _procedimiento = value; }
        }

        protected bool _filtro_fechas;

        public bool Filtro_fechas
        {
            get { return _filtro_fechas; }
            set { _filtro_fechas = value; }
        }

        protected List<Parametro> _parametros = new List<Parametro>();

        public List<Parametro> Parametros
        {
            get { return _parametros; }
            set { _parametros = value; }
        }

        protected List<Grafico> _graficos = new List<Grafico>();

        public List<Grafico> Graficos
        {
            get { return _graficos; }
            set { _graficos = value; }
        }

        protected List<ColumnaReporte> _columnas = new List<ColumnaReporte>();

        public List<ColumnaReporte> Columnas
        {
            get { return _columnas; }
            set { _columnas = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Reporte(byte id, string nombre, string descripcion, string procedimiento, bool filtro_fechas)
        {
            this.DB_ID = id;

            _nombre = nombre;
            _descripcion = descripcion;
            _procedimiento = procedimiento;
            _filtro_fechas = filtro_fechas;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un parámetro al reporte.
        /// </summary>
        /// <param name="parametro">Parámetro que se agregará</param>
        public void agregarParametro(Parametro parametro)
        {
            _parametros.Add(parametro);
        }

        /// <summary>
        /// Agregar un gráfico al reporte.
        /// </summary>
        /// <param name="grafico">Gráfico que se agregará</param>
        public void agregarGrafico(Grafico grafico)
        {
            _graficos.Add(grafico);
        }

        /// <summary>
        /// Agregar una columna al reporte.
        /// </summary>
        /// <param name="columna">Columna que se agregará</param>
        public void agregarGrafico(ColumnaReporte columna)
        {
            _columnas.Add(columna);
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        #endregion Overrides

    }

}
