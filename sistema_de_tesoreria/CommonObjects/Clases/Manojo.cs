using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class Manojo : ObjetoIndexado
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
      
        private String _descripcion;
        
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Manojo(int id,  string descripcion)  
        {
            this.DB_ID = id;

            _descripcion = descripcion;

        }


        public Manojo(string descripcion)
        {
           
            _descripcion = descripcion;

        }

        public Manojo()
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

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;

        //    if (this.GetType() != obj.GetType()) return false;

        //    Bolsa bolsa = (Bolsa)obj;

        //    if ( ID != bolsa.DB_ID) return false;

        //    return true;
        //}

        #endregion Overrides
    }
}
