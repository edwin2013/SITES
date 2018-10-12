using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class RecepcionCartucho
    {

        #region Atributos Privados

        private TiposCartucho _tipo;
        public TiposCartucho Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _transportadora;
        public string Transportadora
        {
            get { return _cartucho.Transportadora.Nombre; }
            set { _cartucho.Transportadora.Nombre = value; }
        }

        private string _proveedor;
        public string Proveedor
        {
            get { return _cartucho.Proveedor.Nombre; }
            set { _cartucho.Proveedor.Nombre = value; }
        }

        private Cartucho _cartucho;
        public Cartucho Cartucho
        {
            get { return _cartucho; }
            set { _cartucho = value; }
        }

        private FallaCartucho _falla;
        public FallaCartucho Falla
        {
            get { return _falla; }
            set { _falla = value; }
        }

        private int _dias;
        public int Dias {
            get { return _dias; }
            set { _dias = value; }
        }

        public string NombreCart
        {
            get { return Cartucho.Numero; }
        }

        public string NombreFalla
        {
            get { return Falla.Nombre; }
        }

        public DateTime Fecha
        {
            get { return Falla.Fecha; }
        }

        public string Usuario
        {
            get { return Falla.Usuario.Nombre; }
        }

        public string empresa
        {
            get { return Cartucho.Transportadora.ToString(); }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RecepcionCartucho() { }

       
        public RecepcionCartucho( Cartucho cartucho = null,FallaCartucho falla = null,int dias = 0, TiposCartucho tipo = TiposCartucho.ENA)
        {
            _cartucho = cartucho;
            _tipo = Tipo;
            _falla = falla;
            _dias = dias;
        }

        #endregion Constructor de Clase
    }
}
