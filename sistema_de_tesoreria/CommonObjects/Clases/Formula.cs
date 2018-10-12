using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class Formula : ObjetoIndexado
    {
        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private int _paquete;

        public int Paquete
        {
            get { return _paquete; }
            set { _paquete = value; }
        }

        private int _bolsa;

        public int Bolsa
        {
            get { return _bolsa; }
            set { _bolsa = value; }
        }

        private Colaborador _colaborador;

        public Colaborador Colaborador
        {
            set { _colaborador = value; }
            get { return _colaborador; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Formula(short id = 0, DateTime? fecha = null, int paqueton = 0, int bolsa = 0, Colaborador c = null)
        {
            _id = id;
            _fecha = fecha ?? DateTime.Now;
            _paquete = paqueton;
            _bolsa = bolsa;
            _colaborador = c;
        }

       

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _id.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            TipoCambio tipo = (TipoCambio)obj;

            if (_id != tipo.Id) return false;

            return true;
        }

        #endregion Overrides
    }
}
