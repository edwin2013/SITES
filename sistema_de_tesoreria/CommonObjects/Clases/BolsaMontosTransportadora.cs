using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class BolsaMontosTransportadora : ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Decimal _cantidad_asignada;

        public Decimal Cantidad_asignada
        {
            get { return _cantidad_asignada; }
            set { _cantidad_asignada = value; }
        }

        private int _id_bolsa;
        public int ID_Bolsa
        {
            set { _id_bolsa = value; }
            get { return _id_bolsa; }
        }

       
        public decimal Monto_asignado
        {
            get { return Convert.ToDecimal(_cantidad_asignada) * _denominacion.Valor; }
        }

        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }


        protected String _comentario;

        public String Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }


        #endregion Atributos Privados

        #region Constructor de Clase

        public BolsaMontosTransportadora(Denominacion denominacion = null,
                                int id = 0,
                                Decimal cantidad_asignada = 0)
        {
            this.DB_ID = id;

            

            _cantidad_asignada = cantidad_asignada;

            _denominacion = denominacion;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos


        #endregion Métodos Públicos

        #region Overrides

  

        #endregion Overrides
    }
}
