//
//  @ Project : 
//  @ File Name : TipoGestion.cs
//  @ Date : 17/08/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public class TipoGestion
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

        private short _tiempo_esperado;

        public short Tiempo_esperado
        {
            get { return _tiempo_esperado; }
            set { _tiempo_esperado = value; }
        }

        private short _tiempo_aviso;

        public short Tiempo_aviso
        {
            get { return _tiempo_aviso; }
            set { _tiempo_aviso = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TipoGestion(byte id, string nombre, short tiempo_esperado, short tiempo_aviso)
        {
            _id = id;
            _nombre = nombre;
            _tiempo_esperado = tiempo_esperado;
            _tiempo_aviso = tiempo_aviso;
        }

        public TipoGestion(byte id, string nombre, short tiempo_esperado)
        {
            _id = id;
            _nombre = nombre;
            _tiempo_esperado = tiempo_esperado;
        }

        public TipoGestion(string nombre, short tiempo_esperado, short tiempo_aviso)
        {
            _nombre = nombre;
            _tiempo_esperado = tiempo_esperado;
            _tiempo_aviso = tiempo_aviso;
        }

        public TipoGestion(byte id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        public TipoGestion() { }

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

            TipoGestion tipo = (TipoGestion)obj;

            if (_id != tipo.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
