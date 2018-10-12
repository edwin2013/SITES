//
//  @ Project : 
//  @ File Name : GraficoHistograma.cs
//  @ Date : 27/05/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects.Graficos
{

    public class GraficoHistograma : Grafico
    {

        #region Atributos Privados

        private string _campo_y;

        public string Campo_y
        {
            get { return _campo_y; }
            set { _campo_y = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public GraficoHistograma(short id, string nombre, string descripcion, string procedimiento,
                                 string campo_y, string nombre_serie)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _procedimiento = procedimiento;
            _campo_y = campo_y;
            _nombre_serie = nombre_serie;
        }

        public GraficoHistograma() { }

        #endregion Constructor de Clase

    }

}
