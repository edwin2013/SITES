//
//  @ Project : 
//  @ File Name : GraficoBarra.cs
//  @ Date : 13/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects.Graficos
{

    public class GraficoBarra : Grafico
    {

        #region Atributos Privados


        private string _campo_x;

        public string Campo_x
        {
            get { return _campo_x; }
            set { _campo_x = value; }
        }
        private string _campo_y;

        public string Campo_y
        {
            get { return _campo_y; }
            set { _campo_y = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public GraficoBarra(short id, string nombre, string descripcion, string procedimiento,
                                 string campo_x, string campo_y, string nombre_serie)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _procedimiento = procedimiento;
            _campo_x = campo_x;
            _campo_y = campo_y;
            _nombre_serie = nombre_serie;
        }

        public GraficoBarra() { }

        #endregion Constructor de Clase

    }

}
