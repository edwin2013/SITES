using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class EquipoTesoreria : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }
        
        private int id;

        private string _serie;

        public string Serie
        {
            get { return _serie; }
            set { _serie = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        protected Areas _area;

        public Areas Area
        {
            get { return _area; }
            set { _area = value; }
        }

        private string _numActivo;

        public string NumActivo
        {
            get { return _numActivo; }
            set { _numActivo = value; }
        }

        private ProveedorEquipo _proveedor;

        public ProveedorEquipo Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }
        
        #endregion Atributos Privados

        #region Constructor de Clase

        public EquipoTesoreria(
            int id = 0,
            string serie = "",
            string activonum = "",
            string nom = "",
            ProveedorEquipo provedor = null,
            Areas area = Areas.Tesoreria)
        {
            this.DB_ID = id;

            _serie = serie;
            _numActivo = activonum;
            _proveedor = provedor;
            _nombre = nom;
            _area = area;
        }

        public EquipoTesoreria(byte id = 0)
        {
            this.DB_ID = id;
        }


        public EquipoTesoreria()
        {

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
