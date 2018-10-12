//
//  @ Project : 
//  @ File Name : Telefono.cs
//  @ Date : 28/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class Telefono
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Telefono(int id, string numero)
        {
            _id = id;
            _numero = numero;
        }

        public Telefono(string numero)
        {
            _numero = numero;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _numero;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Telefono telefono = (Telefono)obj;

            if (_id != telefono.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
