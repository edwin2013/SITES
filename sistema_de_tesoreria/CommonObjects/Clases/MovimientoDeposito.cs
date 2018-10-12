using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public abstract class MovimientoDeposito : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected CierreCargaSucursal _cierre;

        public CierreCargaSucursal Cierre
        {
            get { return _cierre; }
            set { _cierre = value; }
        }

        protected DateTime _hora_inicio = DateTime.Now;

        public DateTime Hora_inicio
        {
            get { return _hora_inicio; }
            set { _hora_inicio = value; }
        }

        protected DateTime _hora_finalizacion = DateTime.Now;

        public DateTime Hora_finalizacion
        {
            get { return _hora_finalizacion; }
            set { _hora_finalizacion = value; }
        }

        protected string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        protected BindingList<MontoDeposito> _montos = new BindingList<MontoDeposito>();

        public BindingList<MontoDeposito> Montos
        {
            get { return _montos; }
            set { _montos = value; }
        }

        protected BindingList<MontoDeposito> _montos_colones = new BindingList<MontoDeposito>();

        public BindingList<MontoDeposito> Montos_Colones
        {
            get { return _montos_colones; }
        }

        protected BindingList<MontoDeposito> _montos_dolares = new BindingList<MontoDeposito>();

        public BindingList<MontoDeposito> Montos_Dolares
        {
            get { return _montos_dolares; }
        }


        protected BindingList<MontoDeposito> _montos_euros = new BindingList<MontoDeposito>();

        public BindingList<MontoDeposito> Montos_Euros
        {
            get { return _montos_euros; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Métodos Privados

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides
    }
}
