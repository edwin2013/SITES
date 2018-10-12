//
//  @ Project : 
//  @ File Name : RegistroRemanentesATM.cs
//  @ Date : 24/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class RegistroRemanentesATM : ObjetoIndexado
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

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private bool _cargado;

        public bool Cargado
        {
            get { return _cargado; }
            set { _cargado = value; }
        }

        protected decimal _monto_remanente_colones;

        public decimal Monto_remanente_colones
        {
            get { return _monto_remanente_colones; }
        }

        protected decimal _monto_remanente_dolares;

        public decimal Monto_remanente_dolares
        {
            get { return _monto_remanente_dolares; }
        }

        protected BindingList<MontoRemanenteATM> _montos = new BindingList<MontoRemanenteATM>();

        public BindingList<MontoRemanenteATM> Montos
        {
            get { return _montos; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RegistroRemanentesATM(int id = 0,
                                     ATM atm = null,
                                     DateTime? fecha = null)
        {
            this.DB_ID = id;

            _atm = atm;
            _fecha = fecha ?? DateTime.Now;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un monto remanente al registro.
        /// </summary>
        /// <param name="monto">Monto a agregar</param>
        public void agregarMonto(MontoRemanenteATM monto)
        {
            _montos.Add(monto);

            switch (monto.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _monto_remanente_colones += monto.Monto;
                    break;
                case Monedas.Dolares:
                    _monto_remanente_dolares += monto.Monto;
                    break;
            }

        }

        /// <summary>
        /// Obtener el monto remanente de una posición específica.
        /// </summary>
        /// <param name="posicion">Posición del monto</param>
        public MontoRemanenteATM obtenerMontoPosicion(byte posicion)
        {

            foreach (MontoRemanenteATM monto in _montos)
                if (monto.Posicion == posicion)
                    return monto;

            return null;
        }

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
