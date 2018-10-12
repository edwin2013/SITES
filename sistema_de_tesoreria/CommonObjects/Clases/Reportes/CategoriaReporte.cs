//
//  @ Project : 
//  @ File Name : CategoriaReporte.cs
//  @ Date : 13/05/2011
//  @ Author : Erick Chavarría 
//

using System.Collections.Generic;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class CategoriaReporte : ObjetoIndexado
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

        protected List<Reporte> _reportes = new List<Reporte>();

        public List<Reporte> Reportes
        {
            get { return _reportes; }
            set { _reportes = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public CategoriaReporte(byte id, string nombre)
        {
            this.DB_ID = id;

            _nombre = nombre;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un reporte a la categoría.
        /// </summary>
        /// <param name="reporte">Operación a agregar</param>
        public void agregarReporte(Reporte reporte)
        {
            _reportes.Add(reporte);
        }

        /// <summary>
        /// Quitar un reporte a la categoría.
        /// </summary>
        /// <param name="reporte">Operación a quitar</param>
        public void quitarReporte(Reporte reporte)
        {
            _reportes.Remove(reporte);
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
