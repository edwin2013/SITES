//
//  @ Project : 
//  @ File Name : CausaGestion.cs
//  @ Date : 17/08/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public enum Causantes : byte
    {
        Cliente = 0,
        Transportadora = 1,
        Cajero = 2,
        Digitador = 3,
        Coordinador = 4,
        Receptor = 5,
        Otro = 6,
    }

    public class CausaGestion
    {

        #region Atributos Privados

        private byte _id;

        public byte Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private Causantes _causante;

        public Causantes Causante
        {
            get { return _causante; }
            set { _causante = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public CausaGestion(byte id, string descripcion, Causantes causante)
        {
            _id = id;
            _descripcion = descripcion;
            _causante = causante;
        }

        public CausaGestion(string descripcion, Causantes causante)
        {
            _descripcion = descripcion;
            _causante = causante;
        }

        public CausaGestion(byte id, string descripcion)
        {
            _id = id;
            _descripcion = descripcion;
        }
        public CausaGestion() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _descripcion;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            CausaGestion causa = (CausaGestion)obj;

            if (_id != causa.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
