using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class BilletesContadosVolumenAlto : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected decimal _m1000CRC;

        public decimal M1000CRC
        {
            get { return _m1000CRC; }
            set { _m1000CRC = value; }
        }

        protected decimal _m2000CRC;

        public decimal M2000CRC
        {
            get { return _m2000CRC; }
            set { _m2000CRC = value; }
        }   

        protected decimal _m5000CRC;

        public decimal M5000CRC
        {
            get { return _m5000CRC; }
            set { _m5000CRC = value; }
        }
   
        protected decimal _m10000CRC;

        public decimal M10000CRC
        {
            get { return _m10000CRC; }
            set { _m10000CRC = value; }
        }

        protected decimal _m20000CRC;

        public decimal M20000CRC
        {
            get { return _m20000CRC; }
            set { _m20000CRC = value; }
        }

        protected decimal _m50000CRC;

        public decimal M50000CRC
        {
            get { return _m50000CRC; }
            set { _m50000CRC = value; }
        }

        protected decimal _m1USD;

        public decimal M1USD
        {
            get { return _m1USD; }
            set { _m1USD = value; }
        }

        protected decimal _m5USD;

        public decimal M5USD
        {
            get { return _m5USD; }
            set { _m5USD = value; }
        }

        protected decimal _m10USD;

        public decimal M10USD
        {
            get { return _m10USD; }
            set { _m10USD = value; }
        }

        protected decimal _m20USD;

        public decimal M20USD
        {
            get { return _m20USD; }
            set { _m20USD = value; }
        }

        protected decimal _m50USD;

        public decimal M50USD
        {
            get { return _m50USD; }
            set { _m50USD = value; }
        }

        protected decimal _m100USD;

        public decimal M100USD
        {
            get { return _m100USD; }
            set { _m100USD = value; }
        }

        protected decimal _m5EUR;

        public decimal M5EUR
        {
            get { return _m5EUR; }
            set { _m5EUR = value; }
        }

        protected decimal _m10EUR;

        public decimal M10EUR
        {
            get { return _m10EUR; }
            set { _m10EUR = value; }
        }

        protected decimal _m20EUR;

        public decimal M20EUR
        {
            get { return _m20EUR; }
            set { _m20EUR = value; }
        }

        protected decimal _m50EUR;

        public decimal M50EUR
        {
            get { return _m50EUR; }
            set { _m50EUR = value; }
        }

        protected decimal _m100EUR;

        public decimal M100EUR
        {
            get { return _m100EUR; }
            set { _m100EUR = value; }
        }

        protected decimal _m200EUR;

        public decimal M200EUR
        {
            get { return _m200EUR; }
            set { _m200EUR = value; }
        }

        protected decimal _m500EUR;

        public decimal M500EUR
        {
            get { return _m500EUR; }
            set { _m500EUR = value; }
        }

        protected Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        protected decimal _montototal;

        public decimal MontoTotal
        {
            get { return _montototal; }
            set { _montototal = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public BilletesContadosVolumenAlto (int id = 0, DateTime? fecha = null, Monedas moneda = Monedas.Colones, decimal m1000CRC = 0, decimal m2000CRC = 0, decimal m5000CRC = 0, 
            decimal m10000CRC = 0, decimal m20000CRC = 0, decimal m50000CRC = 0, decimal m1USD = 0, decimal m5USD = 0, decimal m10USD = 0, decimal m20USD = 0, decimal m50USD = 0, 
            decimal m100USD = 0, decimal m5EUR = 0, decimal m10EUR = 0, decimal m20EUR = 0, decimal m50EUR = 0, decimal m100EUR = 0, decimal m200EUR = 0, decimal m500EUR = 0, decimal total = 0)
        {
            this.DB_ID = id;            
            _fecha = fecha ?? DateTime.MinValue;
            _moneda = moneda;           
            _m10000CRC = m10000CRC;
            _m1000CRC = m1000CRC;
            _m100EUR = m100EUR;
            _m100USD = m100USD;
            _m10EUR = m10EUR;
            _m10USD = m10USD;
            _m1USD = m1USD;
            _m20000CRC = m20000CRC;
            _m2000CRC = m2000CRC;
            _m200EUR = m200EUR;
            _m20EUR = m20EUR;
            _m20USD = m20USD;
            _m50000CRC = m50000CRC;
            _m5000CRC = m5000CRC;
            _m500EUR = m500EUR;
            _m50EUR = m50EUR;
            _m50USD = m50USD;
            _m5EUR = m5EUR;
            _m5USD = m5USD;
            _montototal = total;
        }

        public BilletesContadosVolumenAlto() { }               

        #endregion Constructor de Clase

        #region Métodos Públicos        

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return ID.ToString();
        }

        #endregion Overrides
    }
}
