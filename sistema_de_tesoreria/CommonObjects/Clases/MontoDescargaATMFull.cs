//
//  @ Project : 
//  @ File Name : MontoDescargaATMFull.cs
//  @ Date : 09/05/2012
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class MontoDescargaATMFull : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private short _cantidad;

        public short Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        public decimal Monto_descarga
        {
            get { return _cantidad * _denominacion.Valor; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public MontoDescargaATMFull(Denominacion denominacion,
                                    short cantidad = 0,
                                    int id = 0)
        {
            this.DB_ID = id;

            _denominacion = denominacion;
            _cantidad = cantidad;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
