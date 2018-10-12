using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class ResumenFacturacionCliente : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        protected EmpresaTransporte _empresa_encargada;

        public EmpresaTransporte Empresa_encargada
        {
            get { return _empresa_encargada; }
            set { _empresa_encargada = value; }
        }

        protected PuntoVenta _punto_venta;

        public PuntoVenta PuntoVenta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }

        protected Decimal _monto_planilla;

        public Decimal MontoPlanilla
        {
            get { return _monto_planilla; }
            set { _monto_planilla = value; }
        }


        protected Decimal _tarifa_base;

        public Decimal TarifaBase
        {
            get { return _tarifa_base; }
            set { _tarifa_base = value; }
        }


        protected Decimal _tope;

        public Decimal Tope
        {
            get { return _tope; }
            set { _tope = value; }
        }


        protected Decimal _suma_recargo;

        public Decimal SumaRecargo
        {
            get { return _suma_recargo; }
            set { _suma_recargo = value; }
        }

        protected Decimal _recargo;

        public Decimal Recargo
        {
            get { return _recargo; }
            set { _recargo = value; }
        }


        protected Decimal _total;

        public Decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }


        protected DateTime _fecha;
        public DateTime  Fecha
        {
            set { _fecha = value; }
            get { return _fecha; }
        }

        protected string _planilla;
        public string Planilla
        {
            get { return _planilla; }
            set { _planilla = value; }
        }

        protected Monedas _moneda;
        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        
        #endregion Atributos Privados

        #region Constructor de Clase

        public ResumenFacturacionCliente(int id = 0,
                   Cliente cliente = null, 
                   PuntoVenta punto = null,
                   Decimal monto_planilla = 0,
                   Decimal tarifa = 0,
                   Decimal tope = 0,
                   Decimal recargo = 0,
                   Decimal total = 0,
                   DateTime ? fecha = null)
        {
            this.DB_ID = id;

            _cliente = cliente;
            _punto_venta = punto;
            _monto_planilla = monto_planilla;
            _tarifa_base = tarifa;
            _tope = tope;
            _recargo = recargo;
            _total = total;
            _fecha = fecha ?? DateTime.Now;
            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

      

        #endregion Métodos Públicos

        #region Overrides

        //public override string ToString()
        //{
            
        //    //if (_codigo == null || _codigo.Equals(string.Empty))
        //    //    return "#" + _cliente.ToString();
        //    //else
        //    //    return "#" + _cliente.ToString() + " - " + _codigo;

        //}

        #endregion Overrides
    }
}
