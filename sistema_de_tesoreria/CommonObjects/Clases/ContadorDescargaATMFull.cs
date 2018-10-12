//
//  @ Project : 
//  @ File Name : ContadorDescargaATMFull.cs
//  @ Date : 23/01/2013
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class ContadorDescargaATMFull : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected short _cantidad_depositada;

        public short Cantidad_depositada
        {
            get { return _cantidad_depositada; }
            set { _cantidad_depositada = value; }
        }

        private Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        public decimal Monto_depositado
        {
            get { return _cantidad_depositada * _denominacion.Valor; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ContadorDescargaATMFull(Denominacion denominacion,
                                       short cantidad_depositada = 0,
                                       int id = 0)
        {
            this.DB_ID = id;

            _denominacion = denominacion;
            _cantidad_depositada = cantidad_depositada;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
