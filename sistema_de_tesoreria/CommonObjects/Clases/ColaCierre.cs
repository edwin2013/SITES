//
//  @ Project : 
//  @ File Name : ColaCierre.cs
//  @ Date : 26/09/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class ColaCierre
    {

        #region Atributos Privados

        private Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        private decimal _saldo_colones;

        public decimal Saldo_colones
        {
            get { return _saldo_colones; }
            set { _saldo_colones = value; }
        }

        private decimal _saldo_dolares;

        public decimal Saldo_dolares
        {
            get { return _saldo_dolares; }
            set { _saldo_dolares = value; }
        }
        
        #endregion Atributos Privados

        #region Constructor de Clase

        public ColaCierre(Colaborador cajero, decimal saldo_colones, decimal saldo_dolares)
        {
            _cajero = cajero;
            _saldo_colones = saldo_colones;
            _saldo_dolares = saldo_dolares;
        }

        public ColaCierre() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
