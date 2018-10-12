using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class TipoFallasBlindados: ObjetoIndexado
    {
         #region Atributos Privados

    
        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TipoFallasBlindados(int id = 0, string descripcion = "")
        {
            this.DB_ID = id;

            _descripcion = descripcion;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _descripcion;
        }

        #endregion Overrides
    }
}
