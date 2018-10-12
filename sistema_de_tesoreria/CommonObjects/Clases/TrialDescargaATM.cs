//
//  @ Project : 
//  @ File Name : TrialDescargaATM.cs
//  @ Date : 15/02/2013
//  @ Author : Erick Chavarría 
//

using System;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class TrialDescargaATM : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private ATM _atm;

        public ATM ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected decimal _monto_colones;

        public decimal Monto_colones
        {
            get { return _monto_colones; }
            set { _monto_colones = value; }
        }

        protected decimal _monto_dolares;

        public decimal Monto_dolares
        {
            get { return _monto_dolares; }
            set { _monto_dolares = value; }
        }

        protected bool _full;

        public bool Full
        {
            get { return _full; }
            set { _full = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TrialDescargaATM(ATM atm,
                                DateTime fecha,
                                decimal monto_colones,
                                decimal monto_dolares,
                                bool full,
                                int id = 0)
        {
            this.DB_ID = id;

            _atm = atm;
            _fecha = fecha;
            _monto_colones = monto_colones;
            _monto_dolares = monto_dolares;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
