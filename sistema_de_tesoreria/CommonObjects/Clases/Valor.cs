//
//  @ Project : 
//  @ File Name : Valor.cs
//  @ Date : 17/09/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public enum TipoValor : byte
    {
        BilleteFalso = 0,
        ChequeInvalido = 1,
        OtroValor = 2
    }

    public class Valor
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private TipoValor _tipo;

        public TipoValor Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _identificador;

        public string Identificador
        {
            get { return _identificador; }
            set { _identificador = value; }
        }

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Valor(int id, TipoValor tipo, string identificador, string comentario)
        {
            _id = id;
            _tipo = tipo;
            _identificador = identificador;
            _comentario = comentario;
        }

        public Valor(TipoValor tipo, string identificador, string comentario)
        {
            _tipo = tipo;
            _identificador = identificador;
            _comentario = comentario;
        }

        public Valor() { }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _identificador;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Valor valor = (Valor)obj;

            if (_id != valor.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
