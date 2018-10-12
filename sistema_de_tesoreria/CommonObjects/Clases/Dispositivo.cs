using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class Dispositivo : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _serial;
        private int id;

        public string Serial
        {
            get { return _serial; }
            set { _serial = value; }
        }


        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public Dispositivo(string nombre,string descripcion = "",
                                 int id = 0)
        {
            this.DB_ID = id;

            _serial = nombre;
            _descripcion = descripcion;
        }

        public Dispositivo(byte id = 0)
        {
            this.DB_ID = id;
        }


        public Dispositivo()
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
