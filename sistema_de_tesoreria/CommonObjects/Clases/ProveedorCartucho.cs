using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
   public class ProveedorCartucho : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ProveedorCartucho(int id = 0,
                      string nombre = "")
        {
            this.DB_ID = id;
            _nombre = nombre;
            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        #endregion Overrides
    }
}
