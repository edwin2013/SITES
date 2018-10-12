using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class CantidadMonedasBolsaNiquel: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

      

        private Colaborador _colaborador;
        
        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        protected int _cantidad_piezas;
        public int CantidadPiezas
        {
            get { return _cantidad_piezas; }
            set { _cantidad_piezas = value; }
        }

        public Decimal Monto
        {
            get { return _denominacion.Valor * _cantidad_piezas; }
        }
     

        #endregion Atributos Privados

        #region Constructor de Clase

        public CantidadMonedasBolsaNiquel(int id=0,  Denominacion d = null, int cantidad = 0)  
        {
            this.DB_ID = id;
            _denominacion = d;
            _cantidad_piezas = cantidad;
          
        }

        

        #endregion Constructor de Clase

        #region Métodos Públicos

        


        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _denominacion.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            CantidadMonedasBolsaNiquel bolsa = (CantidadMonedasBolsaNiquel)obj;

            if ( ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides

    }
}
