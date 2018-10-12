using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public enum TipoArqueo : int
    {
        General = 0,
        Boveda = 1
    }

    public enum MonedaArqueo : int
    {
        ColonesMonedas = 0,
        ColonesBilletes = 1,
        Dolares = 2, 
        Euros = 3
    }

    public class Arqueo : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
      
        private Colaborador _usuario;
        
        public Colaborador Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private TipoArqueo _tipo;

        public TipoArqueo Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private MonedaArqueo _moneda;

        public MonedaArqueo Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        private decimal _cuentaContable;

        public decimal CuentaContable
        {
            get { return _cuentaContable; }
            set { _cuentaContable = value; }
        }

        private string _codigoCajero;

        public string CodigoCajero
        {
            get { return _codigoCajero; }
            set { _codigoCajero = value; }
        }

        private decimal _saldoContable;

        public decimal SaldoContable
        {
            get { return _saldoContable; }
            set { _saldoContable = value; }
        }

        private decimal _saldoArqueo;

        public decimal SaldoArqueo
        {
            get { return _saldoArqueo; }
            set { _saldoArqueo = value; }
        }

        private decimal _sobrante;

        public decimal Sobrante
        {
            get { return _sobrante; }
            set { _sobrante = value; }
        }

        private decimal _faltante;

        public decimal Faltante
        {
            get { return _faltante; }
            set { _faltante = value; }
        }

        private DateTime _inicio;

        public DateTime Inicio
        {
            get { return _inicio; }
            set { _inicio = value; }
        }
        private DateTime _fin;

        public DateTime Fin
        {
            get { return _fin; }
            set { _fin = value; }
        }

        private BindingList<DenominacionArqueo> _denominaciones = new BindingList<DenominacionArqueo>();
        public BindingList<DenominacionArqueo> Denominaciones
        {
            get { return _denominaciones; }
            set { _denominaciones = value; }
        }

        private decimal _colas;

        public decimal Colas
        {
            get { return _colas; }
            set { _colas = value; }
        }

        private decimal _mutilado;

        public decimal Mutilado
        {
            get { return _mutilado; }
            set { _mutilado = value; }
        }
       #endregion Atributos Privados

        #region Constructor de Clase

        public Arqueo(int id, DateTime fecha_ingreso, Colaborador colaborador, string comentario, DateTime inicio, DateTime fin, decimal faltante, decimal sobrante,
            decimal saldocontable, decimal saldoarqueo, string codigocajero, decimal cuentacontable, //TipoArqueo tipo, MonedaArqueo moneda,
            decimal colas, decimal mutilado)
        {
            this.ID = id;
            this.Fecha = fecha_ingreso;
            this.Usuario = colaborador;
            _comentario = comentario;
            _inicio = inicio;
            _fin = fin;
            _faltante = faltante;
            _sobrante = sobrante;
            _saldoContable = saldocontable;
            _saldoArqueo = saldoarqueo;
            _codigoCajero = codigocajero;
            _cuentaContable = cuentacontable;
            //_tipo = tipo;
            //_moneda = moneda;

            _colas = colas;
            _mutilado = mutilado;
            
        }

        public Arqueo()
        {
            // TODO: Complete member initialization
        }
     
        #endregion Constructor de Clase

        #region Métodos Públicos

        public void agregarDenominacion(DenominacionArqueo denominacion)
        {
            _denominaciones.Add(denominacion);
        }

        #endregion Métodos Públicos

        #region Overrides
              
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Arqueo arqueo = (Arqueo)obj;

            if ( ID != arqueo.DB_ID) return false;

            return true;
        }

        #endregion Overrides
    }
}
