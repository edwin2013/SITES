using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;


namespace CommonObjects.Clases
{
    public class CartuchoMutilado : ObjetoIndexado
    {
        
        #region Atributos Privados
        
        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Mutilado _mutilado;

        public Mutilado Mutilado
        {
            get { return _mutilado; }
            set { _mutilado = value; }
        }

        protected MovimientoMutilado _movimiento;

        public MovimientoMutilado Movimiento
        {
            get { return _movimiento; }
            set { _movimiento = value; }
        }
        protected string _marchamo;

        public string Marchamo
        {
            get { return _marchamo; }
            set { _marchamo = value; }
        }
        
        protected double _monto_asignado;

        public double Monto_Asignado
        {
            get { return _monto_asignado; }
            set { _monto_asignado = value; }
        }

        public decimal Monto_carga
        {
            get { return _cantidad_carga * _denominacion.Valor; }
        }

        protected double _cantidad_asignada;

        public double Cantidad_Asignada
        {
            get { return _cantidad_asignada; }
            set { _cantidad_asignada = value; }
        }

        protected short _cantidad_carga;

        public short Cantidad_carga
        {
            get { return _cantidad_carga; }
            set { _cantidad_carga = value; }
        }

        public decimal Monto_asignado
        {
            get { return Convert.ToDecimal(_cantidad_asignada) * _denominacion.Valor; }
        }

        protected Denominacion _denominacion;
        private MovimientoMutilado movimiento;
        private double cantidad_asignada;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        public CartuchoMutilado(Denominacion denominacion = null,
                                Mutilado mutilado = null,
                                MovimientoMutilado movimiento = null,
                                int id = 0,
                                string marchamo = "",
                                double cantidad_asignada = 0,
                                short cantidad_carga = 0,
                                double monto_asignado = 0)

           {
            this.DB_ID = id;
            this.Cantidad_Asignada = cantidad_asignada;
            
            _mutilado = mutilado;
            _movimiento = movimiento;
            _marchamo = marchamo;
            _cantidad_asignada = cantidad_asignada;
            _cantidad_carga = cantidad_carga;
            _monto_asignado = monto_asignado;
            _denominacion = denominacion;
            
        }

        public CartuchoMutilado(MovimientoMutilado movimiento, double cantidad_asignada, CommonObjects.Denominacion denominacion)
        {
            // TODO: Complete member initialization
            this.movimiento = movimiento;
            this.cantidad_asignada = cantidad_asignada;
            this.Denominacion = denominacion;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        public bool estaPendiente()
        {
            return _marchamo == null;

        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _marchamo.ToString();
        }

        #endregion Overrides
    
    
    }
}
