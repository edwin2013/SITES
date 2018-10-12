//
//  @ Project : 
//  @ File Name : DetalleDescargaATMFull.cs
//  @ Date : 23/01/2013
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class DetalleDescargaATMFull
    {

        #region Atributos Privados

        #region Cantidades

        protected short _cantidad_depositada;

        public short Cantidad_depositada
        {
            get { return _cantidad_depositada; }
            set { _cantidad_depositada = value; }
        }

        protected short _cantidad_descargada;

        public short Cantidad_descargada
        {
            get { return _cantidad_descargada; }
            set { _cantidad_descargada = value; }
        }

        #endregion Cantidades

        #region Diferencias

        public short Cantidad_diferencia
        {
            get { return (short)(_cantidad_descargada - _cantidad_depositada); }
        }

        #endregion Diferencias

        #region Montos

        public decimal Monto_depositado
        {
            get { return _cantidad_depositada * _denominacion.Valor; }
        }

        public decimal Monto_descargado
        {
            get { return _cantidad_descargada * _denominacion.Valor; }
        }

        public decimal Monto_diferencia
        {
            get { return this.Cantidad_diferencia * _denominacion.Valor; }
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

        public DetalleDescargaATMFull(Denominacion denominacion)
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
