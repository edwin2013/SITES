using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class PromedioRemanenteATM : ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Decimal _monto_quincena;

        public Decimal MontoQuincena
        {
            get { return _monto_quincena; }
            set { _monto_quincena = value; }
        }

        protected Decimal _monto;

        public Decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }


        protected Decimal _monto_quincena_dolares;

        public Decimal MontoQuincenaDolares
        {
            get { return _monto_quincena_dolares; }
            set { _monto_quincena_dolares = value; }
        }

        protected Decimal _monto_dolares;

        public Decimal MontoDolares
        {
            get { return _monto_dolares; }
            set { _monto_dolares = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public PromedioRemanenteATM(int id = 0, Decimal monto = 0, Decimal montoquincena = 0, Decimal montodolares = 0, Decimal montodolaresq = 0)
        {
            this.DB_ID = id;

            _monto_quincena = montoquincena;
            _monto = monto;
            _monto_dolares = montodolares;
            _monto_quincena_dolares = montodolaresq;
        }

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
