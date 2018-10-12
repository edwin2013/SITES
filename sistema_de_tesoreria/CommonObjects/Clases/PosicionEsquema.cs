//
//  @ Project : 
//  @ File Name : PosicionEsquema.cs
//  @ Date : 03/07/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class PosicionEsquema : ObjetoIndexado
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

        private decimal _posicion_x;

        public decimal Posicion_x
        {
            get { return _posicion_x; }
            set { _posicion_x = value; }
        }

        private decimal _posicion_y;

        public decimal Posicion_y
        {
            get { return _posicion_y; }
            set { _posicion_y = value; }
        }

        private decimal _desplazamiento_vertical;

        public decimal Desplazamiento_vertical
        {
            get { return _desplazamiento_vertical; }
            set { _desplazamiento_vertical = value; }
        }

        private decimal _desplazamiento_horizontal;

        public decimal Desplazamiento_horizontal
        {
            get { return _desplazamiento_horizontal; }
            set { _desplazamiento_horizontal = value; }
        }

        private decimal _alto;

        public decimal Alto
        {
            get { return _alto; }
            set { _alto = value; }
        }

        private decimal _ancho;

        public decimal Ancho
        {
            get { return _ancho; }
            set { _ancho = value; }
        }

        private byte _id_impresion;

        public byte Id_impresion
        {
            get { return _id_impresion; }
            set { _id_impresion = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public PosicionEsquema(string descripcion,
                               short id = 0,
                               decimal posicion_x = 0,
                               decimal posicion_y = 0,
                               decimal desplazamiento_vertical = 0,
                               decimal desplazamiento_horizontal = 0,
                               decimal alto = 0,
                               decimal ancho = 0,
                               byte id_impresion = 0)
        {
            this.DB_ID = id;

            _descripcion = descripcion;
            _posicion_x = posicion_x;
            _posicion_y = posicion_y;
            _desplazamiento_vertical = desplazamiento_vertical;
            _desplazamiento_horizontal = desplazamiento_horizontal;
            _id_impresion = id_impresion;
        }

        public PosicionEsquema() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
