//
//  @ Project : 
//  @ File Name : Grafico.cs
//  @ Date : 27/05/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects.Graficos
{

    public abstract class Grafico
    {

        #region Atributos Privados

        protected short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
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

        protected string _nombre_serie;

        public string Nombre_serie
        {
            get { return _nombre_serie; }
            set { _nombre_serie = value; }
        }

        #endregion Atributos Privados

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        #endregion Overrides

    }

}
