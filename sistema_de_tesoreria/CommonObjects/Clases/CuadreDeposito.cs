using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class CuadreDeposito : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _deposito;

        public string Deposito
        {
            get { return _deposito; }
            set { _deposito = value; }
        }

        protected PuntoVenta _punto;

        public PuntoVenta Punto_Venta
        {
            get { return _punto; }
            set { _punto = value; }
        }

        protected string _cuenta;

        public string Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        protected Decimal _monto_fisico;

        public Decimal MontoFisico
        {
            get { return _monto_fisico; }
            set { _monto_fisico = value; }
        }

        protected Decimal _monto_macro;

        public Decimal MontoMacro
        {
            get { return _monto_macro; }
            set { _monto_macro = value; }
        }

        protected Decimal _monto_ibs;

        public Decimal MontoIBS
        {
            get { return _monto_ibs; }
            set { _monto_ibs = value; }
        }

        protected DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }


        protected Monedas _moneda;
        public Monedas Moneda
        {
            set { _moneda = value; }
            get { return _moneda; }
        }

        public Decimal Diferencia
        {
            get
            {
                if (_monto_ibs > _monto_fisico)
                    return (_monto_ibs - _monto_fisico);
                else
                    return _monto_fisico - _monto_ibs;
                }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public CuadreDeposito(int id = 0,
                   PuntoVenta p = null,
                   string cuenta = "",
                   string deposito = "",
                   Decimal monto_fisico = 0,
                   Decimal monto_macro = 0,
                   Decimal monto_ibs = 0, 
                   DateTime ? f = null,
                   Monedas m = Monedas.Colones)
        {
            this.DB_ID = id;
            _punto = p;
            _cuenta = cuenta;
            _deposito = deposito;
            _monto_fisico = monto_fisico;
            _monto_macro = monto_macro;
            _monto_ibs = monto_ibs;
            _fecha = f ?? DateTime.Now;
            _moneda = m;

            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

       

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {

            return _cuenta;

        }

        #endregion Overrides
    }
}
