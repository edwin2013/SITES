using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class PuestoColaborador : ObjetoIndexado
    {
        #region Atributos Privados

        public byte ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        protected BindingList<Perfil> _perfiles;

        public BindingList<Perfil> Perfiles
        {
            get { return _perfiles; }
            set { _perfiles = value; }
        }



        #endregion Atributos Privados

        #region Constructor de Clase

        public PuestoColaborador(int id = 0,
                      string nombre = "")
        {
            this.DB_ID = id;

            _nombre = nombre;
        }

        public PuestoColaborador() { }

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
