//
//  @ Project : 
//  @ File Name : ColumnaReporte.cs
//  @ Date : 07/11/2012
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public enum TiposColumna : byte
    {
        ShortDate = 0,
        LongDate = 1,
        ShortTime = 2,
        LongTime = 3,
        DateTime = 4,
        CRCurrency = 5,
        USCurrency = 6,
        Int = 6,
        String = 7
    }

    public class ColumnaReporte : ObjetoIndexado
    {

        #region Atributos Privados

        public short ID
        {
            get { return (short)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private TiposColumna _tipo;

        public TiposColumna Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private byte _numero_columna;

        public byte Numero_Columna
        {
            get { return _numero_columna; }
            set { _numero_columna = value; }
        }
        
        #endregion Atributos Privados

        #region Constructor de Clase

        public ColumnaReporte(TiposColumna tipo,
                              byte numero_columna,
                              byte id = 0)
        {
            this.DB_ID = id;


            _tipo = tipo;
            _numero_columna = numero_columna;
         }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
