//
//  @ Project : 
//  @ File Name : Cuenta.cs
//  @ Date : 07/01/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class Cuenta
    {

        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private long _numero_cuenta;

        public long Numero_cuenta
        {
            get { return _numero_cuenta; }
            set { _numero_cuenta = value; }
        }

        private Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }


        private PuntoVenta _punto;
        public PuntoVenta PuntoVenta
        {
            get { return _punto; }
            set { _punto = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Cuenta(short id, long cuenta, Monedas moneda)
        {
            _id = id;
            _numero_cuenta = cuenta;
            _moneda = moneda;
        }

        public Cuenta(long cuenta, Monedas moneda)
        {
            _numero_cuenta = cuenta;
            _moneda = moneda;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _numero_cuenta.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Cuenta cuenta = (Cuenta)obj;

            if (_id != cuenta.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
