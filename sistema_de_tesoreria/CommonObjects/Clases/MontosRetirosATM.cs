//
//  @ Project : 
//  @ File Name : MontosRetirosATM.cs
//  @ Date : 30/01/2013
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class MontosRetirosATM : ObjetoIndexado
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

        private Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        #region Montos de Retiro

        protected decimal _retiro_lunes;

        public decimal Retiro_lunes
        {
            get { return _retiro_lunes; }
            set { _retiro_lunes = value; }
        }

        protected decimal _retiro_martes;

        public decimal Retiro_martes
        {
            get { return _retiro_martes; }
            set { _retiro_martes = value; }
        }

        protected decimal _retiro_miercoles;

        public decimal Retiro_miercoles
        {
            get { return _retiro_miercoles; }
            set { _retiro_miercoles = value; }
        }

        protected decimal _retiro_jueves;

        public decimal Retiro_jueves
        {
            get { return _retiro_jueves; }
            set { _retiro_jueves = value; }
        }

        protected decimal _retiro_viernes;

        public decimal Retiro_viernes
        {
            get { return _retiro_viernes; }
            set { _retiro_viernes = value; }
        }

        protected decimal _retiro_sabado;

        public decimal Retiro_sabado
        {
            get { return _retiro_sabado; }
            set { _retiro_sabado = value; }
        }

        protected decimal _retiro_domingo;

        public decimal Retiro_domingo
        {
            get { return _retiro_domingo; }
            set { _retiro_domingo = value; }
        }

        protected decimal _retiro_lunes_quincena;

        public decimal Retiro_lunes_quincena
        {
            get { return _retiro_lunes_quincena; }
            set { _retiro_lunes_quincena = value; }
        }

        protected decimal _retiro_martes_quincena;

        public decimal Retiro_martes_quincena
        {
            get { return _retiro_martes_quincena; }
            set { _retiro_martes_quincena = value; }
        }

        protected decimal _retiro_miercoles_quincena;

        public decimal Retiro_miercoles_quincena
        {
            get { return _retiro_miercoles_quincena; }
            set { _retiro_miercoles_quincena = value; }
        }

        protected decimal _retiro_jueves_quincena;

        public decimal Retiro_jueves_quincena
        {
            get { return _retiro_jueves_quincena; }
            set { _retiro_jueves_quincena = value; }
        }

        protected decimal _retiro_viernes_quincena;

        public decimal Retiro_viernes_quincena
        {
            get { return _retiro_viernes_quincena; }
            set { _retiro_viernes_quincena = value; }
        }

        protected decimal _retiro_sabado_quincena;

        public decimal Retiro_sabado_quincena
        {
            get { return _retiro_sabado_quincena; }
            set { _retiro_sabado_quincena = value; }
        }

        protected decimal _retiro_domingo_quincena;

        public decimal Retiro_domingo_quincena
        {
            get { return _retiro_domingo_quincena; }
            set { _retiro_domingo_quincena = value; }
        }

        #endregion Montos de Retiro

        #endregion Atributos Privados

        #region Constructor de Clase

        public MontosRetirosATM(ATM atm,
                                Monedas moneda,
                                short id = 0,
                                decimal retiro_lunes = 0,
                                decimal retiro_martes = 0,
                                decimal retiro_miercoles = 0,
                                decimal retiro_jueves = 0,
                                decimal retiro_viernes = 0,
                                decimal retiro_sabado = 0,
                                decimal retiro_domingo = 0,
                                decimal retiro_lunes_quincena = 0,
                                decimal retiro_martes_quincena = 0,
                                decimal retiro_miercoles_quincena = 0,
                                decimal retiro_jueves_quincena = 0,
                                decimal retiro_viernes_quincena = 0,
                                decimal retiro_sabado_quincena = 0,
                                decimal retiro_domingo_quincena = 0)
        {
            this.DB_ID = id;

            _atm = atm;
            _moneda = moneda;
            _retiro_lunes = retiro_lunes;
            _retiro_martes = retiro_martes;
            _retiro_miercoles = retiro_miercoles;
            _retiro_jueves = retiro_jueves;
            _retiro_viernes = retiro_viernes;
            _retiro_sabado = retiro_sabado;
            _retiro_domingo = retiro_domingo;
            _retiro_lunes_quincena = retiro_lunes_quincena;
            _retiro_martes_quincena = retiro_martes_quincena;
            _retiro_miercoles_quincena = retiro_miercoles_quincena;
            _retiro_jueves_quincena = retiro_jueves_quincena;
            _retiro_viernes_quincena = retiro_viernes_quincena;
            _retiro_sabado_quincena = retiro_sabado_quincena;
            _retiro_domingo_quincena = retiro_domingo_quincena;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
