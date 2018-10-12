using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class EstadoCartucho : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public EstadoCartucho(int id = 0,
                      string estado = "")
        {
            this.DB_ID = id;
            _estado = estado;
            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _estado;
        }

        #endregion Overrides
    }
}
