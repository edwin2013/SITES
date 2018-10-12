using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ConteoBillete: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }


        private Decimal _crc50000;

        public Decimal CRC50000
        {
            get { return _crc50000; }
            set { _crc50000 = value; }
        }

        private Decimal _crc20000;

        public Decimal CRC20000
        {
            get { return _crc20000; }
            set { _crc20000 = value; }
        }

        private Decimal _crc10000;

        public Decimal CRC10000
        {
            get { return _crc10000; }
            set { _crc10000 = value; }
        }

        private Decimal _crc5000;

        public Decimal CRC5000
        {
            get { return _crc5000; }
            set { _crc5000 = value; }
        }

        private Decimal _crc2000;

        public Decimal CRC2000
        {
            get { return _crc2000; }
            set { _crc2000 = value; }
        }

        private Decimal _crc1000;

        public Decimal CRC1000
        {
            get { return _crc1000; }
            set { _crc1000 = value; }
        }


        private Decimal _eur500;

        public Decimal EUR500
        {
            get { return _eur500; }
            set { _eur500 = value; }
        }

        private Decimal _eur200;

        public Decimal EUR200
        {
            get { return _eur200; }
            set { _eur200 = value; }
        }

        private Decimal _eur100;

        public Decimal EUR100
        {
            get { return _eur100; }
            set { _eur200 = value; }
        }

        private Decimal _eur50;

        public Decimal EUR50
        {
            get { return _eur50; }
            set { _eur50 = value; }
        }

        private Decimal _eur20;

        public Decimal EUR20
        {
            get { return _eur20; }
            set { _eur20 = value; }
        }

        private Decimal _eur10;

        public Decimal EUR10
        {
            get { return _eur10; }
            set { _eur10 = value; }
        }

        private Decimal _eur5;

        public Decimal EUR5
        {
            get { return _eur5; }
            set { _eur5 = value; }
        }

        private Decimal _usd100;

        public Decimal USD100
        {
            get { return _usd100; }
            set { _usd100 = value; }
        }

        private Decimal _usd50;

        public Decimal USD50
        {
            get { return _usd50; }
            set { _usd50 = value; }
        }

        private Decimal _usd20;

        public Decimal USD20
        {
            get { return _usd20; }
            set { _usd20 = value; }
        }

        private Decimal _usd10;

        public Decimal USD10
        {
            get { return _usd10; }
            set { _usd10 = value; }
        }

        private Decimal _usd5;

        public Decimal USD5
        {
            get { return _usd5; }
            set { _usd5 = value; }
        }

        private Decimal _usd1;

        public Decimal USD1
        {
            get { return _usd1; }
            set { _usd1 = value; }
        }

        private Decimal _conteototal;

        public Decimal conteototal
        {
            get { return _conteototal; }
            set { _conteototal = value; }
        }

        protected Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        protected int _id_pbv;

        public int id_PBV
        {
            get { return _id_pbv; }
            set { _id_pbv = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        #endregion Atributos Privados     
   
        #region Constructor de Clase

        public ConteoBillete(int id = 0, decimal c50000 = 0, decimal c20000 = 0, decimal c10000 = 0, decimal c5000 = 0, decimal c2000 = 0, decimal c1000 = 0, decimal u100 = 0, decimal u50 = 0, decimal u20 = 0,
            decimal u10 = 0, decimal u5 = 0, decimal u1 = 0, decimal e500 = 0, decimal e200 = 0, decimal e100 = 0, decimal e50 = 0, decimal e20 = 0, decimal e10 = 0, decimal e5 = 0, 
            Monedas moneda = Monedas.Colones, int idpbv = 0)
        {
            this.ID = id;
            _crc1000 = c1000;
            _crc10000 = c10000;
            _crc2000 = c2000;
            _crc5000 = c5000;
            _crc50000 = c50000;
            _crc20000 = c20000;
            _usd1 = u1;
            _usd10 = u10;
            _usd100 = u100;
            _usd20 = u20;
            _usd5 = u5;
            _usd50 = u50;
            _eur10 = e10;
            _eur100 = e100;
            _eur20 = e20;
            _eur200 = e200;
            _eur5 = e5;
            _eur50 = e50;
            _eur500 = e500;
            _moneda = moneda;
            _id_pbv = idpbv;
            switch (_moneda) {
                case Monedas.Colones:
                    _conteototal = _crc1000 + _crc10000 + _crc2000 + _crc20000 + _crc5000 + _crc50000;
                    break;
                case Monedas.Dolares:
                    _conteototal = _usd1 + _usd10 + _usd100 + _usd20 + _usd5 + _usd50;
                    break;
                case Monedas.Euros:
                    _conteototal = _eur10 + _eur100 + _eur20 + _eur200 + _eur5 + _eur50 + _eur500;
                    break;
            }
        }      

        #endregion Constructor de Clase        

        #region Overrides

        public override string ToString()
        {
            return _conteototal.ToString();
        }        

        #endregion Overrides
    }
}
