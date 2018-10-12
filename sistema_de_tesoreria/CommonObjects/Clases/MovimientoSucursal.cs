using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
   public abstract class MovimientoSucursal : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected CierreCargaSucursal _cierre;

        public CierreCargaSucursal Cierre
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

        protected BindingList<CartuchoCargaSucursal> _cartuchos = new BindingList<CartuchoCargaSucursal>();

        public BindingList<CartuchoCargaSucursal> Cartuchos
        {
            get { return _cartuchos; }
            set { _cartuchos = value; }
        }

        protected BindingList<CartuchoCargaSucursal> _cartuchos_colones = new BindingList<CartuchoCargaSucursal>();

        public BindingList<CartuchoCargaSucursal> Cartuchos_Colones
        {
            get { return _cartuchos_colones; }
        }

        protected BindingList<CartuchoCargaSucursal> _cartuchos_dolares = new BindingList<CartuchoCargaSucursal>();

        public BindingList<CartuchoCargaSucursal> Cartuchos_Dolares
        {
            get { return _cartuchos_dolares; }
        }


        protected BindingList<CartuchoCargaSucursal> _cartuchos_euros = new BindingList<CartuchoCargaSucursal>();

        public BindingList<CartuchoCargaSucursal> Cartuchos_Euros
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
