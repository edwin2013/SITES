//
//  @ Project : 
//  @ File Name : Parametro.cs
//  @ Date : 14/02/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public enum TiposParametro : byte
    {
        Integer = 0,
        Smallint = 1,
        Tinyint = 2,
        Varchar = 3,
        Date = 4
    }

    public class Parametro : ObjetoIndexado
    {

        #region Atributos Privados

        public byte ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private TiposParametro _tipo;

        public TiposParametro Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _parametro_procedimiento;

        public string Parametro_procedimiento
        {
            get { return _parametro_procedimiento; }
            set { _parametro_procedimiento = value; }
        }

        private string _procedimiento;

        public string Procedimiento
        {
            get { return _procedimiento; }
            set { _procedimiento = value; }
        }

        private string _columna_texto;

        public string Columna_texto
        {
            get { return _columna_texto; }
            set { _columna_texto = value; }
        }

        private string _columna_valor;

        public string Columna_valor
        {
            get { return _columna_valor; }
            set { _columna_valor = value; }
        }

        private object _valor;

        public object Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Parametro(TiposParametro tipo,
                         string nombre,
                         string parametro_procedimiento,
                         string procedimiento,
                         string columna_texto,
                         string columna_valor,
                         byte id = 0)
        {
            this.DB_ID = id;

            _tipo = tipo;
            _nombre = nombre;
            _parametro_procedimiento = parametro_procedimiento;
            _procedimiento = procedimiento;
            _columna_texto = columna_texto;
            _columna_valor = columna_valor;
         }

        public Parametro() { }

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
