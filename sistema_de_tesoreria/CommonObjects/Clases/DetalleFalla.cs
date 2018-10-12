using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class DetalleFalla
    {
        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private Falla _falla;

        public Falla Falla
        {
            get { return _falla; }
            set { _falla = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public DetalleFalla(short id, string nombre, Falla falla)
        {
            _id = id;
            _nombre = nombre;
            _falla = falla;
        }

        public DetalleFalla(string nombre, Falla falla)
        {
            _nombre = nombre;
            _falla = falla;
        }

        public DetalleFalla(string nombre)
        {
            _nombre = nombre;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            DetalleFalla punto = (DetalleFalla)obj;

            if (_id != punto.Id) return false;

            return true;
        }

        #endregion Overrides
    }
}
