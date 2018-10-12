using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ValidacionAltoVolumen : ObjetoIndexado
    {
        #region Atributos Privados

        //Inicia Cambio GZH 13092017

        protected Camara _camara;

        public Camara Camara
        {
            get { return _camara; }
            set { _camara = value; }
        }

        //Finaliza Cambio GZH 13092017
        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        protected decimal _montocontado;

        public decimal MontoContado
        {
            get { return _montocontado; }
            set { _montocontado = value; }
        }

        protected decimal _montodeclarado;

        public decimal MontoDeclarado
        {
            get { return _montodeclarado; }
            set { _montodeclarado = value; }
        }

        protected decimal _montodiferencia;

        public decimal MontoDiferencia
        {
            get { return _montodiferencia; }
            set { _montodiferencia = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected byte _tipoconteo; //0 cajero, 1 cliente

        public byte TipoConteo
        {
            get { return _tipoconteo; }
            set { _tipoconteo = value; }
        }

        protected byte _tipovalidacion; //0 Magner, 1 BPS

        public byte TipoValidacion
        {
            get { return _tipovalidacion; }
            set { _tipovalidacion = value; }
        }

        protected Colaborador _validador;

        public Colaborador Validador
        {
            get { return _validador; }
            set { _validador = value; }
        }

        protected ProcesamientoAltoVolumen _proceso;

        public ProcesamientoAltoVolumen Proceso
        {
            get { return _proceso; }
            set { _proceso = value; }
        }

        protected BilletesContadosVolumenAlto _billetecontado;

        public BilletesContadosVolumenAlto BilleteContado
        {
            get { return _billetecontado; }
            set { _billetecontado = value; }
        }

        protected BilletesRechazadosAltoVolumen _billeterechazado;

        public BilletesRechazadosAltoVolumen BilleteRechazado
        {
            get { return _billeterechazado; }
            set { _billeterechazado = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ValidacionAltoVolumen(int id = 0, DateTime? fecha = null, Monedas moneda = Monedas.Colones, decimal montocontado = 0, decimal montodeclarado = 0, decimal montodiferencia = 0,
            byte tipoconteo = 0, byte tipovalidacion = 0, Colaborador validador = null, ProcesamientoAltoVolumen proceso = null, BilletesContadosVolumenAlto billetecontado = null,
            BilletesRechazadosAltoVolumen billeterechazado = null, Camara cam = null)
        {
            this.DB_ID = id;
            _fecha = fecha ?? DateTime.MinValue;
            _moneda = moneda;
            _montocontado = montocontado;
            _montodeclarado = montodeclarado;
            _montodiferencia = montodiferencia;
            _tipoconteo = tipoconteo;
            _tipovalidacion = tipovalidacion;
            _validador = validador;
            _proceso = proceso;
            _billetecontado = billetecontado;
            _billeterechazado = billeterechazado;
            _camara = cam;

        }

        public ValidacionAltoVolumen() { }           

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
