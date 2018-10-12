using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class BoletaMesaNiquel : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private int _cajero;

        public int Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        private byte _estado;

        public byte Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private int _procesobajovolumendeposito;

        public int Procesobajovolumendeposito
        {
            get { return _procesobajovolumendeposito; }
            set { _procesobajovolumendeposito = value; }
        }

        private String _codigoentrega;

        public String CodigoEntrega
        {
            get { return _codigoentrega; }
            set { _codigoentrega = value; }
        }


        private Decimal _monto_niquel;
        public Decimal MontoNiquel
        {
            set { _monto_niquel = value; }
            get { return _monto_niquel; }
        }

        #endregion Atributos Privados


        #region Constructor de Clase

        public BoletaMesaNiquel(int id = 0, int cajero = 0, DateTime? fecha = null, string codigoentrega = "",
                     Decimal montoniquel = 0, int procesobajovolumendeposito = 0, byte estado = 0)  
        {
            this.DB_ID = id;

            _fecha = fecha ?? DateTime.Now;
            _cajero = cajero;            
            _codigoentrega = codigoentrega;            
            _monto_niquel = montoniquel;
            _procesobajovolumendeposito = procesobajovolumendeposito;
            _estado = estado;
        }
              

        #endregion Constructor de Clase


        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Bolsa bolsa = (Bolsa)obj;

            if (ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides

    }
}
