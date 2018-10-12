using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class DenominacionArqueo : ObjetoIndexado
    {
        #region Atributos Privados

        protected decimal _montoTotal;

        public decimal MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }

        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        #endregion Atributos Privados

         #region Constructor de Clase

        public DenominacionArqueo(Denominacion denominacion = null,
                                 decimal monto_total = 0)
        {
            _montoTotal = monto_total;
            _denominacion = denominacion;
        }

        #endregion Constructor de Clase

         #region Métodos Públicos

     
        #endregion Métodos Públicos

         #region Overrides

         #endregion Overrides
    }
}
