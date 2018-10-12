//
//  @ Project : 
//  @ File Name : TipoErrorCierre.cs
//  @ Date : 05/03/2012
//  @ Author : Erick Chavarría 
//

namespace CommonObjects
{

    public class TipoErrorCierre
    {

        #region Atributos Privados

        private byte _id;

        public byte Id
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

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TipoErrorCierre(byte id, string nombre, string descripcion)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
        }

        public TipoErrorCierre(string nombre, string descripcion)
        {
            _nombre = nombre;
            _descripcion = descripcion;
        }

        public TipoErrorCierre(byte id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        public TipoErrorCierre() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

         #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            TipoErrorCierre tipo = (TipoErrorCierre)obj;

            if (_id != tipo.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
