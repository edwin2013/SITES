using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ConteoNiquel: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private Decimal _conteo100;

        public Decimal conteo100
        {
            get { return _conteo100; }
            set { _conteo100 = value; }
        }

        private Decimal _conteo50;

        public Decimal conteo50
        {
            get { return _conteo50; }
            set { _conteo50 = value; }
        }

        private Decimal _conteo25;

        public Decimal conteo25
        {
            get { return _conteo25; }
            set { _conteo25 = value; }
        }

        private Decimal _conteo500;

        public Decimal conteo500
        {
            get { return _conteo500; }
            set { _conteo500 = value; }
        }

        private Decimal _conteo10;

        public Decimal conteo10
        {
            get { return _conteo10; }
            set { _conteo10 = value; }
        }

        private Decimal _conteo5;

        public Decimal conteo5
        {
            get { return _conteo5; }
            set { _conteo5 = value; }
        }

        private Decimal _conteototal;

        public Decimal conteototal
        {
            get { return _conteototal; }
            set { _conteototal = value; }
        }

        #endregion Atributos Privados     
   
        #region Constructor de Clase

        public ConteoNiquel(int id=0, decimal c500=0, decimal c100= 0, decimal c50= 0, decimal c25 = 0, decimal c10 = 0, decimal c5 = 0)
        {
            this.ID = id;
            _conteo500 = c500;
            _conteo100 = c100;
            _conteo50 = c50;
            _conteo25 = c25;
            _conteo10 = c10;
            _conteo5 = c5;
            _conteototal = _conteo500 + _conteo100 + _conteo50 + _conteo25 + _conteo10 + _conteo5;
        }      

        #endregion Constructor de Clase        

        #region Overrides

        public override string ToString()
        {
            return _conteototal.ToString();
        }        

        #endregion Overrides
    }
}
