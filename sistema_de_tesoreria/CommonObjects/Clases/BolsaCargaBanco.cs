using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class BolsaCargaBanco:ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _marchamo;

        public string Marchamo
        {
            get { return _marchamo; }
            set { _marchamo = value; }
        }

        protected CalidadBilletes _calidad;

        public CalidadBilletes Calidad
        {
            get { return _calidad; }
            set { _calidad = value; }
        }

        protected MovimientoBanco _movimiento;

        public MovimientoBanco Movimiento
        {
            get { return _movimiento; }
            set { _movimiento = value; }
        }

        protected double _cantidad_asignada;

        public double Cantidad_asignada
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

        protected short _cantidad_descarga;

        public short Cantidad_descarga
        {
            get { return _cantidad_descarga; }
            set { _cantidad_descarga = value; }
        }

        protected bool _anulado;

        public bool Anulado
        {
            get { return _anulado; }
            set { _anulado = value; }
        }

        public decimal Monto_asignado
        {
            get { return Convert.ToDecimal(_cantidad_asignada) * _denominacion.Valor; }
        }

        public decimal Monto_carga
        {
            get { return _cantidad_carga * _denominacion.Valor; }
        }

        public decimal Monto_descarga
        {
            get { return _cantidad_descarga * _denominacion.Valor; }
        }


        public double CantidadNueva
        {
            set { _cantidad_asignada = Convert.ToDouble(Monto_asignado / _denominacion.Valor);}
            get { return _cantidad_asignada; }
        }
        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }


        public double Bolsa
        {
            get { return Cantidad_asignada / 10000; }
        }


        private string _comentario;
        public string Comentario
        {
            set { _comentario = value; }
            get { return _comentario; }
        }


        public string CalidadBillete
        {
            get { return _calidad.ToString(); }
        }
        #endregion Atributos Privados

         #region Constructor de Clase

        public BolsaCargaBanco(Denominacion denominacion = null,
                                int id = 0,
                                MovimientoBanco movimiento = null,
                                string marchamo = "",
                                short cantidad_carga = 0,
                                double cantidad_asignada = 0,
                                short cantidad_descarga = 0,
                                bool anulado = false, 
                                CalidadBilletes calidad = null)
        {
            this.DB_ID = id;

            _marchamo = marchamo;
            _movimiento = movimiento;
            _cantidad_carga = cantidad_carga;
            _cantidad_asignada = cantidad_asignada;
            _cantidad_descarga = cantidad_descarga;
            _denominacion = denominacion;
            _anulado = anulado;
            _calidad = calidad;
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
