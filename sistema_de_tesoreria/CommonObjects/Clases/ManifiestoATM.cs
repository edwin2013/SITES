﻿//
//  @ Project : 
//  @ File Name : ManifiestoATM.cs
//  @ Date : 26/02/2013
//  @ Author : Erick Chavarría 
//

using System;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public abstract class ManifiestoATM : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _marchamo;

        public string Marchamo
        {
            get { return _marchamo; }
            set { _marchamo = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        
        #endregion Atributos Privados

        #region Constructor de Clase

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _codigo;
        }

        #endregion Overrides

    }

}
