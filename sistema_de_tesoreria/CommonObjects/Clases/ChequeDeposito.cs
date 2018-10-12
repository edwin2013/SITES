using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public enum TipoChequeDeposito : int
    {
        Cheques_Locales = 0,
        Cheques_Compensados = 1,
        Cheques_Extranjero = 2
    }
    public class ChequeDeposito: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }


        protected TipoChequeDeposito _tipo_cheque;
        public TipoChequeDeposito TipoCheque
        {
            set { _tipo_cheque = value; }
            get { return _tipo_cheque; }
        }

        protected decimal _monto; 

        public decimal Monto
        {
            set { _monto = value; }
            get { return _monto; }
        }

        protected Monedas _moneda;
        public Monedas Moneda
        {
            set { _moneda = value; }
            get { return _moneda; }
        }


        #endregion Atributos Privados

        #region Constructor de Clase

        public ChequeDeposito(int id = 0,TipoChequeDeposito tipoc = Clases.TipoChequeDeposito.Cheques_Compensados, bool rechazo = false, decimal monto = 0, Monedas moneda = Monedas.Colones)
        {
            this.DB_ID = id;
            this._tipo_cheque = tipoc;
            this._monto = monto;
            this._moneda = moneda;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides
    }
}
