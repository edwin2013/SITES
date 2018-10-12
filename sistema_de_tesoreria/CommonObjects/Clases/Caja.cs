using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class Caja : ObjetoIndexado
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
      
        private String _descripcion;
        
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion  = value; }
        }

        private Colaborador _usuario;
        
        public Colaborador Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

  
        private Decimal _numero;
        public Decimal Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

       #endregion Atributos Privados

        #region Constructor de Clase

        public Caja(int id, string descripcion, DateTime fecha_ingreso, Colaborador colaborador, decimal numero)
        {
            this.ID = id;
            this.Descripcion = descripcion;
            this.Fecha = fecha_ingreso;
            this.Usuario = colaborador;
            this.Numero = numero;
        }

        public Caja()
        {
            // TODO: Complete member initialization
        }
     
        #endregion Constructor de Clase

        #region Métodos Públicos
    
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return Numero.ToString();
        }

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
