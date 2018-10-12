using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public enum TipoTransaccion : int
    {
        Compra = 0,
        Venta = 1,
        CompraEuros = 2, //Cambio GZH 07/12/2017
        VentaEuros = 3 //Cambio GZH 07/12/2017
    }

    public class CompraVenta : ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }


        protected TipoTransaccion _tipo_transaccion;
        public TipoTransaccion TipoTransaccion
        {
            set { _tipo_transaccion = value; }
            get { return _tipo_transaccion; }
        }


        protected TipoCambio _tipo_cambio; 
        public TipoCambio TipoCambio
        {
            set { _tipo_cambio = value; }
            get { return _tipo_cambio; }
        }

        protected decimal _monto_transaccion; 
        public decimal MontoTransaccion
        {
            set { _monto_transaccion = value; }
            get { return _monto_transaccion; }
        }

        protected decimal _monto_cambio;
        public decimal MontoCambio
        {
            set { _monto_cambio = value; }
            get { return _monto_cambio; }
        }

        protected decimal _monto_billete;
        public decimal MontoBillete
        {
            set { _monto_billete = value; }
            get { return _monto_billete; }
        }

        protected decimal _monto_niquel;
        public decimal MontoNiquel
        {
            set { _monto_niquel = value; }
            get { return _monto_niquel; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        //public CompraVenta(int id = 0, TipoTransaccion transaccion = TipoTransaccion.Compra, TipoCambio tipocambio = null, decimal monto_transaccion = 0, decimal monto_cambio = 0)
        //{
        //    this.DB_ID = id;
        //    this._tipo_transaccion = transaccion;
        //    this._tipo_cambio = tipocambio;
        //    this._monto_cambio = monto_cambio;
        //    this._monto_transaccion = monto_transaccion;
        //}

        public CompraVenta(int id = 0, TipoTransaccion transaccion = TipoTransaccion.Compra, TipoCambio tipocambio = null, decimal monto_transaccion = 0, decimal monto_billete = 0, decimal monto_niquel = 0,
            decimal monto_cambio = 0)
        {
            this.DB_ID = id;
            this._tipo_transaccion = transaccion;
            this._tipo_cambio = tipocambio;
            this._monto_cambio = monto_cambio;
            this._monto_transaccion = monto_transaccion;
            this.MontoBillete = monto_billete;
            this.MontoNiquel = monto_niquel;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

    }
}
