//
//  @ Project : 
//  @ File Name : TipoCambio.cs
//  @ Date : 04/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class TipoCambio
    {

        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private decimal _venta;

        public decimal Venta
        {
            get { return _venta; }
            set { _venta = value; }
        }

        private decimal _compra_euros;

        public decimal CompraEuros
        {
            get { return _compra_euros; }
            set { _compra_euros = value; }
        }



        private decimal _venta_euros;

        public decimal VentaEuros
        {
            get { return _venta_euros; }
            set { _venta_euros = value; }
        }

        private decimal _compra;

        public decimal Compra
        {
            get { return _compra; }
            set { _compra = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TipoCambio(short id, DateTime fecha, decimal venta, decimal compra, decimal venta_euros, decimal compra_euros)
        {
            _id = id;
            _fecha = fecha;
            _venta = venta;
            _compra = compra;
            _compra_euros = compra_euros;
            _venta_euros = venta_euros;
        }

        public TipoCambio(DateTime fecha, decimal venta, decimal compra, decimal compra_euros, decimal venta_euros)
        {
            _fecha = fecha;
            _venta = venta;
            _compra = compra;
            _compra_euros = compra_euros;
            _venta_euros = venta_euros;
        }

        public TipoCambio(short id, decimal venta, decimal compra, decimal venta_euros, decimal compra_euros)
        {
            _id = id;
            _venta = venta;
            _compra = compra;
            _venta_euros = venta_euros;
            _compra_euros = compra_euros;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _id.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            TipoCambio tipo = (TipoCambio)obj;

            if (_id != tipo.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
