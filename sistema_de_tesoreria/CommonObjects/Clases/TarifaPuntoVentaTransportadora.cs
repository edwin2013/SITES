using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class TarifaPuntoVentaTransportadora : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

       

        protected EmpresaTransporte _empresa_transporte;

        public EmpresaTransporte EmpresaTransporte
        {
            get { return _empresa_transporte; }
            set { _empresa_transporte = value; }
        }

        protected PuntoVenta _punto_venta;

        public PuntoVenta PuntoVenta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }


        protected Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        protected Sucursal _sucursal;
        public Sucursal Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }

        protected Decimal _tarifa_regular;

        public Decimal TarifaRegular
        {
            get { return _tarifa_regular; }
            set { _tarifa_regular = value; }
        }

        protected Monedas _moneda_tarifa_regular;
        public Monedas MonedaTarifaRegular
        {
            get { return _moneda_tarifa_regular; }
            set { _moneda_tarifa_regular = value; }
        }

        protected Decimal _tarifa_feriados;

        public Decimal TarifaFeriados
        {
            get { return _tarifa_feriados; }
            set { _tarifa_feriados = value; }
        }

        protected Monedas _moneda_tarifa_feriados;
        public Monedas MonedaTarifaFeriado
        {
            get { return _moneda_tarifa_feriados; }
            set { _moneda_tarifa_feriados = value; }
        }

        protected Decimal _tarifa_niquel;

        public Decimal TarifaNiquel
        {
            get { return _tarifa_niquel; }
            set { _tarifa_niquel = value; }
        }

        protected Monedas _moneda_tarifa_niquel;
        public Monedas MonedaTarifaNiquel
        {
            get { return _moneda_tarifa_niquel; }
            set { _moneda_tarifa_niquel = value; }
        }

        protected Decimal _tope;

        public Decimal Tope
        {
            get { return _tope; }
            set { _tope = value; }
        }


        protected Monedas _moneda_tope;
        public Monedas MonedaTope
        {
            get { return _moneda_tope; }
            set { _moneda_tope = value; }
        }

        protected Decimal _recargo;

        public Decimal Recargo
        {
            get { return _recargo; }
            set { _recargo = value; }
        }

        protected Monedas _moneda_recargo;
        public Monedas MonedaRecargo
        {
            get { return _moneda_recargo; }
            set { _moneda_recargo = value; }
        }


        protected Decimal _tarifa_feriado_domingos_menudo;
        public Decimal TarifaFeriadoDomingosMenudo
        {
            set { _tarifa_feriado_domingos_menudo = value; }
            get { return _tarifa_feriado_domingos_menudo; }
        }

        protected Monedas _moneda_feriados_domingos_menudo;
        public Monedas MonedaFeriadosDomingosMenudo
        {
            get { return _moneda_feriados_domingos_menudo; }
            set { _moneda_feriados_domingos_menudo = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TarifaPuntoVentaTransportadora(int id = 0, EmpresaTransporte transportadora = null, PuntoVenta punto = null, 
            Decimal tarifaregular = 0, Decimal tarifaferiados = 0, Decimal tarifaniquel= 0, Decimal tope = 0, Decimal recargo = 0, Monedas moneda_regular = Monedas.Colones, Monedas moneda_feriado = Monedas.Colones,
            Monedas moneda_tope = Monedas.Colones, Monedas moneda_recargo = Monedas.Colones, Monedas moneda_niquel = Monedas.Colones, Sucursal sucursal = null, Decimal tarifaferiadomenudo = 0, Monedas monedaferiadomenudo = Monedas.Colones)
        {
             this.DB_ID = id;
            _empresa_transporte = transportadora;
            _punto_venta = punto;
            _tarifa_regular = tarifaregular;
            _tarifa_feriados = tarifaferiados;
            _tarifa_niquel = tarifaniquel;
            _tope = tope;
            _recargo = recargo;
            _moneda_recargo = moneda_recargo;
            _moneda_tarifa_feriados = moneda_feriado;
            _moneda_tarifa_niquel = moneda_niquel;
            _moneda_tarifa_regular = moneda_regular;
            _moneda_tope = moneda_tope;
            _sucursal = sucursal;
            _moneda_feriados_domingos_menudo = monedaferiadomenudo;
            _tarifa_feriado_domingos_menudo = tarifaferiadomenudo;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return DB_ID.ToString();
        }

        #endregion Overrides
    }
}
