using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class Penalidad : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       
        private String _descripcion;
        
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }


        protected TipoPenalidad _tipo_penalidad;

        public TipoPenalidad TipoPenalidad
        {
            get{return _tipo_penalidad;}
            set { _tipo_penalidad = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Penalidad(int id = 0,  string descripcion = "", TipoPenalidad tipopenalidad = null)  
        {
            this.DB_ID = id;

            _descripcion = descripcion;
            _tipo_penalidad = tipopenalidad;

        }


        public Penalidad()
        {
            // TODO: Complete member initialization
        }

  
        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return Descripcion.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Penalidad bolsa = (Penalidad)obj;

            if (ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides
    }
}
