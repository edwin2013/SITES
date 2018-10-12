//
//  @ Project : 
//  @ File Name : GraficoBarraLinea.cs
//  @ Date : 18/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects.Graficos
{

    public class GraficoBarraLinea : Grafico
    {

        #region Atributos Privados

        private string _campo_x;

        public string Campo_x
        {
            get { return _campo_x; }
            set { _campo_x = value; }
        }

        private string _campo_y_barra;

        public string Campo_y_barra
        {
            get { return _campo_y_barra; }
            set { _campo_y_barra = value; }
        }

        private string _campo_y_linea;

        public string Campo_y_linea
        {
            get { return _campo_y_linea; }
            set { _campo_y_linea = value; }
        }

        private string _serie_linea;

        public string Serie_linea
        {
            get { return _serie_linea; }
            set { _serie_linea = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public GraficoBarraLinea(short id, string nombre, string descripcion, string procedimiento,
                                 string campo_x, string campo_y_barra, string campo_y_linea,
                                 string serie_barra, string serie_linea)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _procedimiento = procedimiento;
            _campo_x = campo_x;
            _campo_y_barra = campo_y_barra;
            _campo_y_linea = campo_y_linea;
            _nombre_serie = serie_barra;
            _serie_linea = serie_linea;
        }

        public GraficoBarraLinea() { }

        #endregion Constructor de Clase

    }

}
