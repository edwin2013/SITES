//
//  @ Project : 
//  @ File Name : Sobre.cs
//  @ Date : 23/11/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class Sobre
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _numero;

        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private decimal _monto_reportado;

        public decimal Monto_reportado
        {
            get { return _monto_reportado; }
            set { _monto_reportado = value; }
        }

        private decimal _monto_real;

        public decimal Monto_real
        {
            get { return _monto_real; }
            set { _monto_real = value; }
        }

        private Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Sobre(int id, int numero, decimal monto_reportado, decimal monto_real, Monedas moneda)
        {
            _id = id;
            _numero = numero;
            _monto_reportado = monto_reportado;
            _monto_real = monto_real;
            _moneda = moneda;
        }

        public Sobre(int numero, decimal monto_reportado, decimal monto_real, Monedas moneda)
        {
            _numero = numero;
            _monto_reportado = monto_reportado;
            _monto_real = monto_real;
            _moneda = moneda;
        }

        public Sobre() { }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _numero.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Sobre sobre = (Sobre)obj;

            if (_id != sobre.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
