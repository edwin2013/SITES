//
//  @ Project : 
//  @ File Name :RechazoDescargaATM.cs
//  @ Date : 26/11/2012
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class RechazoDescargaATM : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected short _cantidad_descarga;

        public short Cantidad_descarga
        {
            get { return _cantidad_descarga; }
            set { _cantidad_descarga = value; }
        }

        public decimal Monto_descarga
        {
            get { return _cantidad_descarga * _denominacion.Valor; }
        }

        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        public bool _bolsa_rechazo;

        public bool BolsaRechazo
        {
            get { return _bolsa_rechazo; }
            set { _bolsa_rechazo = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RechazoDescargaATM(Denominacion denominacion,
                                  short cantidad_descarga = 0,
                                  int id = 0, bool bolsa = false)
        {
            this.DB_ID = id;

            _denominacion = denominacion;
            _cantidad_descarga = cantidad_descarga;
            _bolsa_rechazo = bolsa;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            if(_bolsa_rechazo)
                return "Bolsa Rechazo " + _denominacion.ToString();
            else
                return "Cartucho Rechazo " + _denominacion.ToString();
        }

        #endregion Overrides

    }

}
