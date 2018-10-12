//
//  @ Project : 
//  @ File Name : Opcion.cs
//  @ Date : 12/09/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class Opcion : ObjetoIndexado
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

        protected string _boton;

        public string Boton
        {
            get { return _boton; }
            set { _boton = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Opcion(byte id,
                      string nombre,
                       string boton)
        {
            this.DB_ID = id;

            _nombre = nombre;
            _boton = boton;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        #endregion Overrides

    }

}
