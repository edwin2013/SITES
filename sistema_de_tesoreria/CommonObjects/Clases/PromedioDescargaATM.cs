using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class PromedioDescargaATM : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected ATM _atm;

        public ATM ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }

        protected Decimal _monto;

        public Decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public PromedioDescargaATM(int id = 0, Decimal monto = 0, ATM atm = null)
        {
            this.DB_ID = id;

            _atm = atm;
            _monto = monto;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _atm.ToString();
        }

        #endregion Overrides
    }
}
