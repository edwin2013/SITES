//
//  @ Project : 
//  @ File Name : MontoCierreATMs.cs
//  @ Date : 17/12/2012
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public enum TiposMontoCierre : byte
    {
        MesaDescarga = 0,
        ColaDescarga = 1,
        MesaDescargaFull = 2,
        ColaDescargaFull = 3
    }

    public class MontoCierreATMs : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        protected TiposMontoCierre _tipo;

        public TiposMontoCierre Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        public decimal Monto
        {
            get { return _cantidad * _denominacion.Valor; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public MontoCierreATMs(Denominacion denominacion,
                               TiposMontoCierre tipo,
                               int id = 0,
                               int cantidad = 0)
        {
            this.DB_ID = id;

            _denominacion = denominacion;
            _tipo = tipo;
            _cantidad = cantidad;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
