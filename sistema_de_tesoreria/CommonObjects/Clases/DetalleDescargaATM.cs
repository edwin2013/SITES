//
//  @ Project : 
//  @ File Name : DetalleDescargaATM.cs
//  @ Date : 13/12/2012
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class DetalleDescargaATM
    {

        #region Atributos Privados

        #region Cantidades

        protected short _cantidad_dispensada;

        public short Cantidad_dispensada
        {
            get { return _cantidad_dispensada; }
            set { _cantidad_dispensada = value; }
        }

        protected short _cantidad_remanente;

        public short Cantidad_remanente
        {
            get { return _cantidad_remanente; }
            set { _cantidad_remanente = value; }
        }

        public short Cantidad_contadores
        {
            get { return (short)(_cantidad_remanente + _cantidad_dispensada); }
        }

        protected short _cantidad_cargada;

        public short Cantidad_cargada
        {
            get { return _cantidad_cargada; }
            set { _cantidad_cargada = value; }
        }

        protected short _cantidad_descargada;

        public short Cantidad_descargada
        {
            get { return _cantidad_descargada; }
            set { _cantidad_descargada = value; }
        }

        protected short _cantidad_dispensada_cartucho;

        public short Cantidad_dispensada_cartucho
        {
            get { return _cantidad_dispensada_cartucho; }
            set { _cantidad_dispensada_cartucho = value; }
        }

        protected short _cantidad_remanente_cartucho;

        public short Cantidad_remanente_cartucho
        {
            get { return _cantidad_remanente_cartucho; }
            set { _cantidad_remanente_cartucho = value; }
        }




        protected short _cantidad_dispensada_bolsa;

        public short Cantidad_dispensada_bolsa
        {
            get { return _cantidad_dispensada_bolsa; }
            set { _cantidad_dispensada_bolsa = value; }
        }

        protected short _cantidad_remanente_bolsa;

        public short Cantidad_remanente_bolsa
        {
            get { return _cantidad_remanente_bolsa; }
            set { _cantidad_remanente_bolsa = value; }
        }


        #endregion Cantidades

        #region Diferencias

        public short Cantidad_diferencia_remanente
        {
            // get { return (short)(_cantidad_descargada + _cantidad_dispensada_cartucho - _cantidad_remanente); }
            get { return (short)(_cantidad_descargada  - _cantidad_remanente); }
        }

        public short Cantidad_diferencia_contador
        {
            get { return (short)(this.Cantidad_contadores  - _cantidad_cargada); }
        }


        //public short Cantidad_diferencia_cartucho_rechazo
        //{
        //    get { return (short)(this.Cantidad_dispensada_cartucho - _cantidad_remanente_cartucho); }
        //}

        //public short Cantidad_diferencia_bolsa_rechazo
        //{
        //    get { return (short)(this.Cantidad_dispensada_bolsa - _cantidad_remanente_bolsa); }
        //}

        #endregion Diferencias

        #region Montos

        public decimal Monto_dispensado
        {
            get { return _cantidad_dispensada * _denominacion.Valor; }
        }

        public decimal Monto_remanente
        {
            get { return _cantidad_remanente * _denominacion.Valor; }
        }

        public decimal Monto_cargado
        {
            get { return _cantidad_cargada * _denominacion.Valor; }
        }

        public decimal Monto_descargado
        {
            get { return _cantidad_descargada * _denominacion.Valor; }
        }

        public decimal Monto_diferencia_remanente
        {
            get { return this.Cantidad_diferencia_remanente * _denominacion.Valor; }
        }

        public decimal Monto_diferencia_contador
        {
            get { return this.Cantidad_diferencia_contador * _denominacion.Valor; }
        }



        public decimal Monto_diferencia_cartucho
        {
            get { return this.Cantidad_diferencia_contador * _denominacion.Valor; }
        }


        public decimal Monto_diferencia_bolsas
        {
            get { return this.Cantidad_diferencia_contador * _denominacion.Valor; }
        }

        #endregion Montos

        private Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public DetalleDescargaATM(Denominacion denominacion)
        {
            _denominacion = denominacion;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
