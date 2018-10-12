//
//  @ Project : 
//  @ File Name : Denominacion.cs
//  @ Date : 01/07/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using LibreriaAccesoDatos;

namespace CommonObjects
{
   
    public class Denominacion : ObjetoIndexado
    {


        #region Atributos Privados

        public byte Id
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected decimal _valor;

        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        protected Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        protected string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        protected string _configuracion_diebold;

        public string Configuracion_diebold
        {
            get { return _configuracion_diebold; }
            set { _configuracion_diebold = value; }
        }

        protected string _configuracion_opteva;

        public string Configuracion_opteva
        {
            get { return _configuracion_opteva; }
            set { _configuracion_opteva = value; }
        }

        protected short? _formulas_maximas;

        public short? Formulas_maximas
        {
            get { return _formulas_maximas; }
            set { _formulas_maximas = value; }
        }

        protected short? _formulas_minimas;

        public short? Formulas_minimas
        {
            get { return _formulas_minimas; }
            set { _formulas_minimas = value; }
        }

        protected byte? _id_imagen;

        public byte? Id_imagen
        {
            get { return _id_imagen; }
            set { _id_imagen = value; }
        }

        protected bool _carga_atm;

        public bool Carga_atm
        {
            get { return _carga_atm; }
            set { _carga_atm = value; }
        }

        protected bool _es_moneda;
        public bool EsMoneda
        {
            get { return _es_moneda; }
            set { _es_moneda = value; }
        }  

        #endregion Atributos Privados

        #region Constructor de Clase

        public Denominacion(byte id = 0,
                            decimal valor = 0,
                            Monedas moneda = Monedas.Colones,
                            string codigo = "",
                            string configuracion_diebold = "",
                            string configuracion_opteva = "",
                            short? formulas_maximas = 0,
                            short? formulas_minimas = 0,
                            byte? id_imagen = null,
                            bool carga_atm = false,
                            bool esmoneda = false)
        {
            this.DB_ID = id;

            _valor = valor;
            _moneda = moneda;
            _codigo = codigo;
            _configuracion_diebold = configuracion_diebold;
            _configuracion_opteva = configuracion_opteva;
            _formulas_maximas = formulas_maximas;
            _formulas_minimas = formulas_minimas;
            _id_imagen = id_imagen;
            _carga_atm = carga_atm;
            _es_moneda = esmoneda;
            
        }
        
        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {

            switch (_moneda)
            {
                case Monedas.Dolares:
                    return _valor.ToString("N0") + " Dólares";
                default:
                    return _valor.ToString("N0") + " " + Enum.GetName(typeof(Monedas), _moneda);
            }
            
        }

        public override int GetHashCode()
        {
            return _moneda.GetHashCode() ^ _valor.GetHashCode();
        }

        #endregion Overrides

    }

}
