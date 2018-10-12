//
//  @ Project : 
//  @ File Name : DiaFeriado.cs
//  @ Date : 14/09/2012
//  @ Author : Erick Chavarría 
//

using System;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class DiaFeriado : ObjetoIndexado
    {

        #region Atributos Privados

        public short ID
        {
            get { return (short)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public DiaFeriado(int id, string descripcion, DateTime fecha)
        {
            this.DB_ID = id;

            _descripcion = descripcion;
            _fecha = fecha;
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
