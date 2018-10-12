using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class TipoEquipo: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _descripcion;
        private int id;
        private bool _obligatorio;

        public bool Obligatorio
        {
            get{return _obligatorio;}
            set{ _obligatorio = value;}
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TipoEquipo(string descripcion,
                                 int id = 0, bool obligatorio=false)
        {
            this.DB_ID = id;
            this._obligatorio = obligatorio;
            _descripcion = descripcion;
        }

        public TipoEquipo(byte id = 0)
        {
            this.DB_ID = id;
        }


        public TipoEquipo()
        {
           
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
