//
//  @ Project : 
//  @ File Name : Ubicacion.cs
//  @ Date : 30/04/2012
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class Ubicacion : ObjetoIndexado
    {

        #region Atributos Privados

        public short ID
        {
            get { return (short)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _oficina;

        public string Oficina
        {
            get { return _oficina; }
            set { _oficina = value; }
        }

        protected string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        protected string _direccion_exacta;

        public string Direccion_exacta
        {
            get { return _direccion_exacta; }
            set { _direccion_exacta = value; }
        }

        protected Provincias _provincia;

        public Provincias Provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Ubicacion(string oficina,
                         string direccion,
                         int id = 0,
                         string direccion_exacta = "",
                         Provincias provincia = Provincias.Alajuela)
        {
            this.DB_ID = id;

            _oficina = oficina;
            _direccion = direccion;
            _direccion_exacta = direccion_exacta;
            _provincia = provincia;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _oficina + " " + _direccion;
        }

        #endregion Overrides

    }

}
