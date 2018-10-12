using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class BilleteFalso : ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }


        protected string _serie_billete;
        public string SerieBillete
        {
            set { _serie_billete = value; }
            get { return _serie_billete; }
        }

        protected decimal _monto; 

        public decimal Monto
        {
            set { _monto = value; }
            get { return _monto; }
        }

        protected Monedas _moneda;
        public Monedas Moneda
        {
            set { _moneda = value; }
            get { return _moneda; }
        }

        protected Denominacion _denominacion;
        public Denominacion denominacion
        {
            set { _denominacion = value; }
            get { return _denominacion; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public BilleteFalso(int id = 0, string serie_billete = "", decimal monto = 0, Monedas moneda = Monedas.Colones)
        {
            this.DB_ID = id;
            this._serie_billete = serie_billete;
            this._monto = monto;
            this._moneda = moneda;
        }

        public BilleteFalso(int id = 0, string serie_billete = "", decimal monto = 0, Monedas moneda = Monedas.Colones, Denominacion denominacion = null)
        {
            this.DB_ID = id;
            this._serie_billete = serie_billete;
            this._monto = monto;
            this._moneda = moneda;
            this._denominacion = denominacion;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides
    }
}
