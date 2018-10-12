//
//  @ Project : 
//  @ File Name : Canal.cs
//  @ Date : 07/08/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class Canal
    {

        #region Atributos Privados

        private int _id;

        public int Id
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


        private EmpresaTransporte _empresa;
        private short id;

        public EmpresaTransporte Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Canal(int id, string nombre, EmpresaTransporte empresa = null)
        {
            _id = id;
            _nombre = nombre;
            _empresa = empresa;
        }

        public Canal(string nombre)
        {
            _nombre = nombre;
        }

        public Canal() { }

        public Canal(short id, string nombre)
        {
            // TODO: Complete member initialization
            _id = id;
            this.Nombre = nombre;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Canal canal = (Canal)obj;

            if (_id != canal.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
