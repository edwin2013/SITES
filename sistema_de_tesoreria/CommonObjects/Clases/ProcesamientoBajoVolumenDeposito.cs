using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ProcesamientoBajoVolumenDeposito: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }        

        protected Decimal _montoNiquel;

        public Decimal MontoNiquel
        {
            get { return _montoNiquel; }
            set { _montoNiquel = value; }
        }

        protected Decimal _montoDeclarado;

        public Decimal MontoDeclarado
        {
            get { return _montoDeclarado; }
            set { _montoDeclarado = value; }
        }


        protected Decimal _montoContado;

        public Decimal MontoContado
        {
            get { return _montoContado; }
            set { _montoContado = value; }
        }

        protected Decimal _diferencia;

        public Decimal Diferencia
        {
            get { return _diferencia; }
            set { _diferencia = value; }
        }

        protected ProcesamientoBajoVolumen _procesamientobajovolumen;

        public ProcesamientoBajoVolumen ProcesamientoBajoVolumen
        {
            get { return _procesamientobajovolumen; }
            set { _procesamientobajovolumen = value; }
        }

        protected DateTime _fecha_procesamiento;
        public DateTime Fecha_Procesamiento
        {
            set { _fecha_procesamiento = value; }
            get { return _fecha_procesamiento; }
        }        

        protected ProcesamientoBajoVolumenManifiesto _manifiesto;

        public ProcesamientoBajoVolumenManifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }        

        protected Tula _tula;

        public Tula Tula
        {
            get { return _tula; }
            set { _tula = value; }
        }

        protected string _numero_deposito;

        public string NumeroDeposito
        {
            get { return _numero_deposito; }
            set { _numero_deposito = value; }
        }

        protected string _codigoVD;

        public string CodigoVD
        {
            get { return _codigoVD; }
            set { _codigoVD = value; }
        }

        protected string _codigotransaccion;

        public string CodigoTransaccion
        {
            get { return _codigotransaccion; }
            set { _codigotransaccion = value; }
        }

        protected string _cuenta;

        public string Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        protected string _cedula;

        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        protected int _tipomesa;

        public int TipoMesa
        {
            get { return _tipomesa; }
            set { _tipomesa = value; }
        }

        protected Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        protected string _depositante;

        public string Depositante
        {
            get { return _depositante; }
            set { _depositante = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ProcesamientoBajoVolumenDeposito(int ID = 0, ProcesamientoBajoVolumen procesamientobajovolumen = null, ProcesamientoBajoVolumenManifiesto manifiesto = null, Tula tula = null, DateTime? fecha_procesamiento = null, string numero_deposito = "", 
            string codigo_VD="", string codigo_transaccion="", string cuenta="", string cedula="", Monedas moneda = Monedas.Colones, int tipomesa = 0, Decimal MontoNiquel = 0, Decimal MontoDeclarado =0,            
            Decimal MontoContado = 0, Decimal Diferencia = 0, string Depositante = "")
        {
            this.DB_ID = ID;            
            _procesamientobajovolumen = procesamientobajovolumen;
            _manifiesto = manifiesto;
            _tula = tula;
            _montoNiquel = MontoNiquel;
            _montoContado = MontoContado;
            _montoDeclarado = MontoDeclarado;
            _diferencia = Diferencia;
            _moneda = moneda;
            _fecha_procesamiento = fecha_procesamiento ?? DateTime.Now;
            _codigoVD = codigo_VD;
            _codigotransaccion = codigo_transaccion;
            _cuenta = cuenta;
            _cedula = cedula;
            _numero_deposito = numero_deposito;
            _depositante = Depositante;
        }
        

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        /*public override string ToString()
        {
            return _numero_cuenta.ToString();
        }*/

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            ProcesamientoBajoVolumenDeposito procesamientobajovolumendeposito = (ProcesamientoBajoVolumenDeposito)obj;

            if (ID != procesamientobajovolumendeposito.DB_ID) return false;

            return true;
        }

        #endregion Overrides
    }
}
