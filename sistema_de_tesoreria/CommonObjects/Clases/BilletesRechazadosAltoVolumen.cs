using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class BilletesRechazadosAltoVolumen : ObjetoIndexado
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

        protected int _c1000CRC;

        public int C1000CRC
        {
            get { return _c1000CRC; }
            set { _c1000CRC = value; }
        }

        protected decimal _m2000CRC;

        public decimal M2000CRC
        {
            get { return _m2000CRC; }
            set { _m2000CRC = value; }
        }

        protected int _c2000CRC;

        public int C2000CRC
        {
            get { return _c2000CRC; }
            set { _c2000CRC = value; }
        }

        protected decimal _m5000CRC;

        public decimal M5000CRC
        {
            get { return _m5000CRC; }
            set { _m5000CRC = value; }
        }

        protected int _c5000CRC;

        public int C5000CRC
        {
            get { return _c5000CRC; }
            set { _c5000CRC = value; }
        }

        protected decimal _m10000CRC;

        public decimal M10000CRC
        {
            get { return _m10000CRC; }
            set { _m10000CRC = value; }
        }

        protected int _c10000CRC;

        public int C10000CRC
        {
            get { return _c10000CRC; }
            set { _c10000CRC = value; }
        }

        protected decimal _m20000CRC;

        public decimal M20000CRC
        {
            get { return _m20000CRC; }
            set { _m20000CRC = value; }
        }

        protected int _c20000CRC;

        public int C20000CRC
        {
            get { return _c20000CRC; }
            set { _c20000CRC = value; }
        }

        protected decimal _m50000CRC;

        public decimal M50000CRC
        {
            get { return _m50000CRC; }
            set { _m50000CRC = value; }
        }

        protected int _c50000CRC;

        public int C50000CRC
        {
            get { return _c50000CRC; }
            set { _c50000CRC = value; }
        }

        protected decimal _m1USD;

        public decimal M1USD
        {
            get { return _m1USD; }
            set { _m1USD = value; }
        }

        protected int _c1USD;

        public int C1USD
        {
            get { return _c1USD; }
            set { _c1USD = value; }
        }

        protected decimal _m5USD;

        public decimal M5USD
        {
            get { return _m5USD; }
            set { _m5USD = value; }
        }

        protected int _c5USD;

        public int C5USD
        {
            get { return _c5USD; }
            set { _c5USD = value; }
        }

        protected decimal _m10USD;

        public decimal M10USD
        {
            get { return _m10USD; }
            set { _m10USD = value; }
        }

        protected int _c10USD;

        public int C10USD
        {
            get { return _c10USD; }
            set { _c10USD = value; }
        }

        protected decimal _m20USD;

        public decimal M20USD
        {
            get { return _m20USD; }
            set { _m20USD = value; }
        }

        protected int _c20USD;

        public int C20USD
        {
            get { return _c20USD; }
            set { _c20USD = value; }
        }

        protected decimal _m50USD;

        public decimal M50USD
        {
            get { return _m50USD; }
            set { _m50USD = value; }
        }

        protected int _c50USD;

        public int C50USD
        {
            get { return _c50USD; }
            set { _c50USD = value; }
        }

        protected decimal _m100USD;

        public decimal M100USD
        {
            get { return _m100USD; }
            set { _m100USD = value; }
        }

        protected int _c100USD;

        public int C100USD
        {
            get { return _c100USD; }
            set { _c100USD = value; }
        }

        protected decimal _m5EUR;

        public decimal M5EUR
        {
            get { return _m5EUR; }
            set { _m5EUR = value; }
        }

        protected int _c5EUR;

        public int C5EUR
        {
            get { return _c5EUR; }
            set { _c5EUR = value; }
        }

        protected decimal _m10EUR;

        public decimal M10EUR
        {
            get { return _m10EUR; }
            set { _m10EUR = value; }
        }

        protected int _c10EUR;

        public int C10EUR
        {
            get { return _c10EUR; }
            set { _c10EUR = value; }
        }

        protected decimal _m20EUR;

        public decimal M20EUR
        {
            get { return _m20EUR; }
            set { _m20EUR = value; }
        }

        protected int _c20EUR;

        public int C20EUR
        {
            get { return _c20EUR; }
            set { _c20EUR = value; }
        }

        protected decimal _m50EUR;

        public decimal M50EUR
        {
            get { return _m50EUR; }
            set { _m50EUR = value; }
        }

        protected int _c50EUR;

        public int C50EUR
        {
            get { return _c50EUR; }
            set { _c50EUR = value; }
        }

        protected decimal _m100EUR;

        public decimal M100EUR
        {
            get { return _m100EUR; }
            set { _m100EUR = value; }
        }

        protected int _c100EUR;

        public int C100EUR
        {
            get { return _c100EUR; }
            set { _c100EUR = value; }
        }

        protected decimal _m200EUR;

        public decimal M200EUR
        {
            get { return _m200EUR; }
            set { _m200EUR = value; }
        }

        protected int _c200EUR;

        public int C200EUR
        {
            get { return _c200EUR; }
            set { _c200EUR = value; }
        }

        protected decimal _m500EUR;

        public decimal M500EUR
        {
            get { return _m500EUR; }
            set { _m500EUR = value; }
        }

        protected int _c500EUR;

        public int C500EUR
        {
            get { return _c500EUR; }
            set { _c500EUR = value; }
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

        public BilletesRechazadosAltoVolumen(int id = 0, DateTime? fecha = null, Monedas moneda = Monedas.Colones, decimal m1000CRC = 0, int f1000CRC = 0, decimal m2000CRC = 0, int f2000CRC = 0,
            decimal m5000CRC = 0, int f5000CRC = 0, decimal m10000CRC = 0, int f10000CRC = 0, decimal m20000CRC = 0, int f20000CRC = 0, decimal m50000CRC = 0, int f50000CRC = 0, 
            decimal m1USD = 0, int f1USD = 0, decimal m5USD = 0, int f5USD = 0, decimal m10USD = 0, int f10USD = 0, decimal m20USD = 0, int f20USD = 0, decimal m50USD = 0, int f50USD = 0,
            decimal m100USD = 0, int f100USD = 0, decimal m5EUR = 0, int f5EUR = 0, decimal m10EUR = 0, int f10EUR = 0, decimal m20EUR = 0, int f20EUR = 0, decimal m50EUR = 0, int f50EUR = 0,
            decimal m100EUR = 0, int f100EUR = 0, decimal m200EUR = 0, int f200EUR = 0, decimal m500EUR = 0, int f500EUR = 0, decimal total = 0)
        {
            this.DB_ID = id;            
            _fecha = fecha ?? DateTime.MinValue;
            _moneda = moneda;
            _c10000CRC = f10000CRC;
            _c1000CRC = f1000CRC;
            _c100EUR = f100EUR;
            _c100USD = f100USD;
            _c10EUR = f10EUR;
            _c10USD = f10USD;
            _c1USD = f1USD;
            _c20000CRC = f20000CRC;
            _c2000CRC = f2000CRC;
            _c200EUR = f200EUR;
            _c20EUR = f20EUR;
            _c20USD = f20USD;
            _c50000CRC = f50000CRC;
            _c5000CRC = f5000CRC;
            _c500EUR = f500EUR;
            _c50EUR = f50EUR;
            _c50USD = f50USD;
            _c5EUR = f5EUR;
            _c5USD = f5USD;
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
        
        public BilletesRechazadosAltoVolumen() { }               

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
