//
//  @ Project : 
//  @ File Name : Correo.cs
//  @ Date : 28/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class Correo
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Correo(int id, string direccion)
        {
            _id = id;
            _direccion = direccion;
        }

        public Correo(string direccion)
        {
            _direccion = direccion;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _direccion;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Correo correo = (Correo)obj;

            if (_id != correo.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
