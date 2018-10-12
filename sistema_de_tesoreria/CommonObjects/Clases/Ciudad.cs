//
//  @ Project : 
//  @ File Name : Ciudad.cs
//  @ Date : 06/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public enum Provincias : byte
    {
        Alajuela = 0,
        Cartago = 1,
        Guanacaste = 2,
        Heredia = 3,
        Limon = 4,
        Puntarenas = 5,
        SanJose = 6
    }

    public class Ciudad
    {

        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private Provincias _provincia;

        public Provincias Provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Ciudad(short id, string nombre, Provincias provincia)
        {
            _id = id;
            _nombre = nombre;
            _provincia = provincia;
        }

        public Ciudad(string nombre, Provincias provincia)
        {
            _nombre = nombre;
            _provincia = provincia;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Ciudad ciudad = (Ciudad)obj;

            if (_id != ciudad.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
