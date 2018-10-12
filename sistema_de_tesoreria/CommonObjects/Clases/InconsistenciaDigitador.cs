//
//  @ Project : 
//  @ File Name : InconsistenciaDigitador.cs
//  @ Date : 27/08/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class InconsistenciaDigitador
    {

        #region Atributos Privados

        protected int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        protected Deposito _deposito;

        public Deposito Deposito
        {
            get { return _deposito; }
            set { _deposito = value; }
        }

        protected Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }

        protected Colaborador _digitador;

        public Colaborador Digitador
        {
            get { return _digitador; }
            set { _digitador = value; }
        }

        protected PuntoVenta _punto_venta;

        public PuntoVenta Punto_venta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected byte _t;

        public byte T
        {
            get { return _t; }
            set { _t = value; }
        }

        protected int? _referencia_erronea;

        public int? Referencia_erronea
        {
            get { return _referencia_erronea; }
            set { _referencia_erronea = value; }
        }

        protected decimal? _monto_erroneo;

        public decimal? Monto_erroneo
        {
            get { return _monto_erroneo; }
            set { _monto_erroneo = value; }
        }

        protected int? _cuenta_erronea;

        public int? Cuenta_erronea
        {
            get { return _cuenta_erronea; }
            set { _cuenta_erronea = value; }
        }

        protected Monedas? _moneda_erronea;

        public Monedas? Moneda_erronea
        {
            get { return _moneda_erronea; }
            set { _moneda_erronea = value; }
        }

        #region Errores de ROE's

        private bool _roe_cedula_incorrecta;

        public bool ROE_cedula_incorrecta
        {
            get { return _roe_cedula_incorrecta; }
            set { _roe_cedula_incorrecta = value; }
        }

        private bool _roe_origen_incorrecto;

        public bool ROE_origen_incorrecto
        {
            get { return _roe_origen_incorrecto; }
            set { _roe_origen_incorrecto = value; }
        }

        private bool _roe_cuenta_incorrecta;

        public bool ROE_cuenta_incorrecta
        {
            get { return _roe_cuenta_incorrecta; }
            set { _roe_cuenta_incorrecta = value; }
        }

        private bool _roe_reimpresion;

        public bool ROE_reimpresion
        {
            get { return _roe_reimpresion; }
            set { _roe_reimpresion = value; }
        }

        private bool _roe_firma;

        public bool ROE_firma
        {
            get { return _roe_firma; }
            set { _roe_firma = value; }
        }

        private bool _roe_sello;

        public bool ROE_sello
        {
            get { return _roe_sello; }
            set { _roe_sello = value; }
        }

        #endregion Errores de ROE's

        #endregion Atributos Privados

        #region Constructor de Clase

        public InconsistenciaDigitador(int id = 0,
                                       Deposito deposito = null,
                                       Colaborador coordinador = null,
                                       Colaborador digitador = null,
                                       DateTime? fecha = null,
                                       PuntoVenta punto_venta = null,
                                       int? referencia_erronea = 0,
                                       int? cuenta_erronea = 0,
                                       decimal? monto_erroneo = 0,
                                       Monedas? moneda_erronea = 0,
                                       bool roe_cedula_incorrecta = false,
                                       bool roe_origen_incorrecto = false,
                                       bool roe_cuenta_incorrecta = false,
                                       bool roe_reimpresion = false,
                                       bool roe_firma = false,
                                       bool roe_sello = false,
                                       byte t = 0)
        {
            _id = id;
            _deposito = deposito;
            _coordinador = coordinador;
            _digitador = digitador;
            _fecha = fecha ?? DateTime.Now;
            _punto_venta = punto_venta;
            _referencia_erronea = referencia_erronea;
            _cuenta_erronea = cuenta_erronea;
            _monto_erroneo = monto_erroneo;
            _moneda_erronea = moneda_erronea;
            _roe_cedula_incorrecta = roe_cedula_incorrecta;
            _roe_origen_incorrecto = roe_origen_incorrecto;
            _roe_cuenta_incorrecta = roe_cuenta_incorrecta;
            _roe_reimpresion = roe_reimpresion;
            _roe_firma = roe_firma;
            _roe_sello = roe_sello;
            _t = t;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _deposito.Referencia.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            InconsistenciaDigitador inconsistencia = (InconsistenciaDigitador)obj;

            if (_id != inconsistencia.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
