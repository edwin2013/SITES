//
//  @ Project : 
//  @ File Name : Deposito.cs
//  @ Date : 27/07/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.ComponentModel;

namespace CommonObjects
{

    public enum Monedas : byte
    {
        Colones = 0,
        Dolares = 1,
        Euros = 2
    }

    public class Deposito : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private long _referencia;

        public long Referencia
        {
            get { return _referencia; }
            set { _referencia = value; }
        }

        private decimal _monto;

        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        private Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        private long _cuenta;

        public long Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        private BindingList<BilleteFalso> _billetesfalsos;

        public BindingList<BilleteFalso> BilletesFalsos
        {
            get { return _billetesfalsos; }
            set { _billetesfalsos = value; }
        }

        private BindingList<ChequeDeposito> _chequedeposito;

        public BindingList<ChequeDeposito> ChequeDeposito
        {
            get { return _chequedeposito; }
            set { _chequedeposito = value; }
        }

        private CompraVenta _compraventa;

        public CompraVenta CompraVenta
        {
            get { return _compraventa; }
            set { _compraventa = value; }
        }

        private BindingList<MontoDeposito> _montodeposito;

        public BindingList<MontoDeposito> MontoDeposito
        {
            get { return _montodeposito; }
            set { _montodeposito = value; }
        }

        private string _codigoVD;
        public string CodigoVD
        {
            get { return _codigoVD; }
            set { _codigoVD = value; }
        }

        private string _codigotransaccion;
        public string CodigoTransaccion
        {
            get { return _codigotransaccion; }
            set { _codigotransaccion = value; }
        }

        private string _cuentareferencia;
        public string CuentaReferencia
        {
            get { return _cuentareferencia; }
            set { _cuentareferencia = value; }
        }

        private string _cedula;
        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        private int _tipomesaniquel;
        public int TipomesaNiquel
        {
            get { return _tipomesaniquel; }
            set { _tipomesaniquel = value; }
        }

        private decimal _montoniquel;

        public decimal MontoNiquel
        {
            get { return _montoniquel; }
            set { _montoniquel = value; }
        }

        private decimal _montodeclarado;

        public decimal MontoDeclarado
        {
            get { return _montodeclarado; }
            set { _montodeclarado = value; }
        }

        private decimal _montodiferencia;

        public decimal MontoDiferencia
        {
            get { return _montodiferencia; }
            set { _montodiferencia = value; }
        }

        private string _numerodeposito;
        public string NumeroDeposito
        {
            get { return _numerodeposito; }
            set { _numerodeposito = value; }
        }

        //cambios GZH 24/04/2017 añade propiedad depositante

        private string _depositante;
        public string Depositante
        {
            get { return _depositante; }
            set { _depositante = value; }
        }


        #endregion Atributos Privados

        #region Constructor de Clase
        
        public Deposito(long referencia,
            int id = 0,
            decimal monto = 0,
             long cuenta = 0,
            Monedas moneda = Monedas.Colones, string CodigoVD = "", string codigotransaccion = "", string cuentareferencia = "", 
            string cedula = "", int tipomesaniquel = -1, decimal montoniquel = 0, decimal montodeclarado = 0, decimal diferencia = 0, string numerodeposito = "", 
            string depositante = "") //cambio GZH agrega parámetro depositante 24/04/2017     
        {
            this.DB_ID = id;

            _referencia = referencia;
            _monto = monto;
            _cuenta = cuenta;
            _moneda = moneda;
            _codigoVD = CodigoVD;
            _codigotransaccion = codigotransaccion;
            _cuentareferencia = cuentareferencia;
            _cedula = cedula;
            _tipomesaniquel = tipomesaniquel;
            _montoniquel = montoniquel;
            _montodeclarado = montodeclarado;
            _montodiferencia = diferencia;
            _numerodeposito = numerodeposito;
            _depositante = depositante; //cambio GZH agrega depositante 24/04/2017
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Este método permite agregar billetes falsos
        /// </summary>
        /// <param name="billete">Objeto Billete Falso (BilleteFalso)</param>
        public void agregarBilleteFalso(BilleteFalso billete)
        {
            _billetesfalsos.Add(billete);
        }

        /// <summary>
        /// Este método permite borrar billetes falsos
        /// </summary>
        /// <param name="billete">Objeto Billete Falso (BilleteFalso)</param>
        public void borrarBilleteFalso(BilleteFalso billete)
        {
            _billetesfalsos.Remove(billete);
        }
        /// <summary>
        /// Este método permite agregar cheques al listado de cheques en un depósito
        /// </summary>
        /// <param name="cheque">Objeto ChequeDeposito</param>
        public void agregarChequeDeposito(ChequeDeposito cheque)
        {
            _chequedeposito.Add(cheque);
        }

        /// <summary>
        /// Este método permite borrar cheques al listado de cheques en un depósito
        /// </summary>
        /// <param name="cheque">Objeto ChequeDeposito</param>
        public void borrarChequeDeposito(ChequeDeposito cheque)
        {
            _chequedeposito.Remove(cheque);
        }

        /// <summary>
        /// Este método permite agregar montos a un listado de montos de un depósito
        /// </summary>
        /// <param name="montodeposito">Objeto MontoDeposito</param>
        public void agregarMontoDeposito(MontoDeposito montodeposito)
        {
            _montodeposito.Add(montodeposito);
        }

        /// <summary>
        /// Este método permite borrar montos a un listado de montos de un depósito
        /// </summary>
        /// <param name="montodeposito">Objeto MontoDeposito</param>
        public void borrarMontoDeposito(MontoDeposito montodeposito)
        {
            _montodeposito.Remove(montodeposito);
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _referencia.ToString();
        }

        #endregion Overrides

    }

}
