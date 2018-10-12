using CommonObjects.Clases;
using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects
{
    public class MontoDeposito: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }


        protected MovimientoDeposito _movimiento;

        public MovimientoDeposito Movimiento
        {
            get { return _movimiento; }
            set { _movimiento = value; }
        }

        protected decimal _cantidad_asignada;

        public decimal Cantidad_asignada
        {
            get { return _cantidad_asignada; }
            set { _cantidad_asignada = value; }
        }


    

        //public decimal Monto_asignado
        //{
        //    get { return Convert.ToDecimal(_cantidad_asignada) * _denominacion.Valor; }
        //}

        

        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }


       
        #endregion Atributos Privados

        #region Constructor de Clase

        public MontoDeposito(Denominacion denominacion = null,
                                int id = 0,
                                MovimientoDeposito movimiento = null,
                                decimal cantidad_asignada = 0)
        {
            this.DB_ID = id;

            _movimiento = movimiento;
            _cantidad_asignada = cantidad_asignada;
            _denominacion = denominacion;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides
    }
}
