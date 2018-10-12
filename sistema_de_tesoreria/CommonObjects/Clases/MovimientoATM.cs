//
//  @ Project : 
//  @ File Name : MovimientoATM.cs
//  @ Date : 16/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public abstract class MovimientoATM : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected CierreATMs _cierre;

        public CierreATMs Cierre
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

        protected BindingList<CartuchoCargaATM> _cartuchos = new BindingList<CartuchoCargaATM>();

        public BindingList<CartuchoCargaATM> Cartuchos
        {
            get { return _cartuchos; }
            set { _cartuchos = value; }
        }

        protected BindingList<CartuchoCargaATM> _cartuchos_colones = new BindingList<CartuchoCargaATM>();

        public BindingList<CartuchoCargaATM> Cartuchos_Colones
        {
            get { return _cartuchos_colones; }
        }

        protected BindingList<CartuchoCargaATM> _cartuchos_dolares = new BindingList<CartuchoCargaATM>();

        public BindingList<CartuchoCargaATM> Cartuchos_Dolares
        {
            get { return _cartuchos_dolares; }
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
