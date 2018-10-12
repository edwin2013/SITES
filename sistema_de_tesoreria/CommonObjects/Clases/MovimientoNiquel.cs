﻿//
//  @ Project : 
//  @ File Name : MovimientoNiquel.cs
//  @ Date : 22/08/2011
//  @ Author : Erick Chavarría 

using CommonObjects.Clases;
using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CommonObjects
{

    public abstract class MovimientoNiquel : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected CierreNiquel _cierre;

        public CierreNiquel Cierre
        {
            get { return _cierre; }
            set { _cierre = value; }
        }

        protected DateTime _hora_inicio = DateTime.Now;

        public DateTime Hora_inicio
        {
            get { return _hora_inicio; }
            set { _hora_inicio = value; }
        }

        protected DateTime _hora_finalizacion = DateTime.Now;

        public DateTime Hora_finalizacion
        {
            get { return _hora_finalizacion; }
            set { _hora_finalizacion = value; }
        }

        protected string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        protected BindingList<CartuchosNiquel> _cartuchos = new BindingList<CartuchosNiquel>();

        public BindingList<CartuchosNiquel> Cartuchos
        {
            get { return _cartuchos; }
            set { _cartuchos = value; }
        }

        protected BindingList<CartuchosNiquel> _cartuchos_colones = new BindingList<CartuchosNiquel>();

        public BindingList<CartuchosNiquel> Cartuchos_Colones
        {
            get { return _cartuchos_colones; }
        }

        protected BindingList<CartuchosNiquel> _cartuchos_dolares = new BindingList<CartuchosNiquel>();

        public BindingList<CartuchosNiquel> Cartuchos_Dolares
        {
            get { return _cartuchos_dolares; }
        }

        protected BindingList<CartuchosNiquel> _cartuchos_euros = new BindingList<CartuchosNiquel>();

        public BindingList<CartuchosNiquel> Cartuchos_Euros
        {
            get { return _cartuchos_euros; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Métodos Privados

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides

    }

}
