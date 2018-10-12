//
//  @ Project : 
//  @ File Name : ContadorDescargaATM.cs
//  @ Date : 26/11/2012
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class ContadorDescargaATM : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected short _cantidad_dispensada_a;

        public short Cantidad_dispensada_a
        {
            get { return _cantidad_dispensada_a; }
            set { _cantidad_dispensada_a = value; }
        }

        protected short _cantidad_remanente_a;

        public short Cantidad_remanente_a
        {
            get { return _cantidad_remanente_a; }
            set { _cantidad_remanente_a = value; }
        }

        protected short _cantidad_dispensada_b;

        public short Cantidad_dispensada_b
        {
            get { return _cantidad_dispensada_b; }
            set { _cantidad_dispensada_b = value; }
        }

        protected short _cantidad_remanente_b;

        public short Cantidad_remanente_b
        {
            get { return _cantidad_remanente_b; }
            set { _cantidad_remanente_b = value; }
        }

        protected short _cantidad_dispensada_c;

        public short Cantidad_dispensada_c
        {
            get { return _cantidad_dispensada_c; }
            set { _cantidad_dispensada_c = value; }
        }

        protected short _cantidad_remanente_c;

        public short Cantidad_remanente_c
        {
            get { return _cantidad_remanente_c; }
            set { _cantidad_remanente_c = value; }
        }

        private Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }


        protected short _cantidad_cartucho_rechazo;
        public short Cantidad_cartucho_rechazo
        {
            get { return _cantidad_cartucho_rechazo; }
            set { _cantidad_cartucho_rechazo = value; }
        }

        protected short _cantidad_remanente_cartucho_rechazo;

        public short Cantidad_remanente_cartucho_rechazo
        {
            get { return _cantidad_remanente_cartucho_rechazo; }
            set { _cantidad_remanente_cartucho_rechazo = value; }
        }



        protected short _cantidad_bolsa_rechazo;
        public short Cantidad_bolsa_rechazo
        {
            get { return _cantidad_bolsa_rechazo; }
            set { _cantidad_bolsa_rechazo = value; }
        }

        protected short _cantidad_remanente_bolsa_rechazo;

        public short Cantidad_remanente_bolsa_rechazo
        {
            get { return _cantidad_remanente_bolsa_rechazo; }
            set { _cantidad_remanente_bolsa_rechazo = value; }
        }


        public decimal Monto_dispensado_a
        {
            get { return _cantidad_dispensada_a * _denominacion.Valor; }
        }

        public decimal Monto_remanente_a
        {
            get { return _cantidad_remanente_a * _denominacion.Valor; }
        }

        public decimal Monto_dispensado_b
        {
            get { return _cantidad_dispensada_b * _denominacion.Valor; }
        }

        public decimal Monto_remanente_b
        {
            get { return _cantidad_remanente_b * _denominacion.Valor; }
        }

        public decimal Monto_dispensado_c
        {
            get { return _cantidad_dispensada_c * _denominacion.Valor; }
        }

        public decimal Monto_remanente_c
        {
            get { return _cantidad_remanente_c * _denominacion.Valor; }
        }

        public short Cantidad_dispensada
        {
            get { return (short)(_cantidad_dispensada_a + _cantidad_dispensada_b + _cantidad_dispensada_c); }
        }
        
        public short Cantidad_remanente
        {
            get { return (short)(_cantidad_remanente_a + _cantidad_remanente_b + _cantidad_remanente_c); }
        }

        public decimal Monto_dispensado
        {
            get { return this.Cantidad_dispensada * _denominacion.Valor; }
        }

        public decimal Monto_remanente
        {
            get { return this.Cantidad_remanente * _denominacion.Valor; }
        }


        public decimal Total
        {
            get { return (Cantidad_remanente_a + Cantidad_remanente_b + Cantidad_remanente_c - Cantidad_remanente_cartucho_rechazo - _cantidad_remanente_bolsa_rechazo); }
        }
        public decimal Monto_dispensado_cartucho_rechazo
        {
            get { return _cantidad_cartucho_rechazo * _denominacion.Valor; }
        }

        public decimal Monto_remanente_cartucho_rechazo
        {
            get { return _cantidad_remanente_cartucho_rechazo * _denominacion.Valor; }
        }


        public decimal Monto_dispensado_bolsa_rechazo
        {
            get { return _cantidad_bolsa_rechazo * _denominacion.Valor; }
        }

        public decimal Monto_remanente_bolsa_rechazo
        {
            get { return _cantidad_remanente_bolsa_rechazo * _denominacion.Valor; }
        }


        public string Codigo
        {
            get { return _denominacion.Codigo; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ContadorDescargaATM(Denominacion denominacion,
                                   short cantidad_dispensada_a = 0,
                                   short cantidad_remanente_a = 0,
                                   short cantidad_dispensada_b = 0,
                                   short cantidad_remanente_b = 0,
                                    short cantidad_dispensada_c = 0,
                                   short cantidad_remanente_c = 0,
                                    short cantidad_dispensada_cartucho_rechazo = 0,
                                    short cantidad_remanente_cartucho_rechazo = 0,
                                    short cantidad_dispensada_bolsa_rechazo = 0,
                                    short cantidad_remanente_bolsa_rechazo = 0,
                                   int id = 0)
        {
            this.DB_ID = id;

            _denominacion = denominacion;
            _cantidad_dispensada_a = cantidad_dispensada_a;
            _cantidad_remanente_a = cantidad_remanente_a;
            _cantidad_dispensada_b = cantidad_dispensada_b;
            _cantidad_remanente_b = cantidad_remanente_b;
            _cantidad_dispensada_c = cantidad_dispensada_c;
            _cantidad_remanente_c = cantidad_remanente_c;
            _cantidad_cartucho_rechazo = cantidad_dispensada_cartucho_rechazo;
            _cantidad_remanente_cartucho_rechazo = cantidad_remanente_cartucho_rechazo;
            _cantidad_bolsa_rechazo = cantidad_dispensada_bolsa_rechazo;
            _cantidad_remanente_bolsa_rechazo = cantidad_remanente_bolsa_rechazo;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
