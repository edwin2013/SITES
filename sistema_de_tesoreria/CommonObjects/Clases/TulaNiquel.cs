using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class TulaNiquel: ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       private DateTime _fecha_ingreso;

        public DateTime Fecha_ingreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }
      
        private int _cantidad_bolsa;
        
        public int CantidadBolsa
        {
            get { return _cantidad_bolsa; }
            set { _cantidad_bolsa = value; }
        }

       private Denominacion _denominacion;
        public Denominacion Denominacion 
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TulaNiquel(int id=0,  Denominacion den = null, int cantidad = 0)  
        {
            this.DB_ID = id;

            _denominacion = den;

            _cantidad_bolsa = cantidad;
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

            if ( ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides
    }
}
