//
//  @ Project : 
//  @ File Name : NombreJuridico.cs
//  @ Date : 30/08/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Text;

namespace CommonObjects
{

    public class NombreJuridico
    {

        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _cif;

        public int CIF
        {
            get { return _cif; }
            set { _cif = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private BindingList<Cuenta> _cuentas = new BindingList<Cuenta>();

        public BindingList<Cuenta> Cuentas
        {
            get { return _cuentas; }
            set { _cuentas = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public NombreJuridico(short id = 0,
                              int cif = 0,
                              string nombre = "")
        {
            _id = id;
            _cif = cif;
            _nombre = nombre;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar una cuenta al nombre jurídico.
        /// </summary>
        /// <param name="cuenta">Nueva cuenta a agregar</param>
        public void agregarCuenta(Cuenta cuenta)
        {
            _cuentas.Add(cuenta);
        }

        /// <summary>
        /// Quitar una cuenta del nombre jurídico.
        /// </summary>
        /// <param name="cuenta">Cuenta a quitar</param>
        public void quitarCuenta(Cuenta cuenta)
        {
            _cuentas.Remove(cuenta);
        }

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

            NombreJuridico nombre = (NombreJuridico)obj;

            if (_id != nombre.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
