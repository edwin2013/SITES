using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class Comision: ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       
      
        private PuntoVenta _punto_atencion;
        
        public PuntoVenta Nombre
        {
            get { return _punto_atencion; }
            set { _punto_atencion = value; }
        }

        private Colaborador _colaborador;
        
        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }


       

        private Decimal _monto_comision;
        public Decimal MComision
        {
            set { _monto_comision = value; }
            get { return _monto_comision; }
        }

        

        #endregion Atributos Privados

        #region Constructor de Clase

        public Comision(int id = 0, PuntoVenta p = null, Decimal monto_comision = 0)  
        {
            this.DB_ID = id;

            _punto_atencion = p;
            _monto_comision = monto_comision;           


        }

      
 

        

        #endregion Constructor de Clase

        #region Métodos Públicos

       

      

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _punto_atencion.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Comision bolsa = (Comision)obj;

            if ( ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides
    }
}
