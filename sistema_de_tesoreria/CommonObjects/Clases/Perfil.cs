//
//  @ Project : 
//  @ File Name : Perfil.cs
//  @ Date : 12/09/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class Perfil : ObjetoIndexado
    {

        #region Atributos Privados

        public byte ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        protected List<Opcion> _opciones = new List<Opcion>();

        public List<Opcion> Opciones
        {
            get { return _opciones; }
            set { _opciones = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Perfil(int id = 0,
                      string nombre = "")
        {
            this.DB_ID = id;

            _nombre = nombre;
        }

        public Perfil() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar una opción al perfil.
        /// </summary>
        /// <param name="opcion">Nueva opción a agregar</param>
        public void agregarOpcion(Opcion opcion)
        {
            _opciones.Add(opcion);
        }

        /// <summary>
        /// Quitar una opción del perfil.
        /// </summary>
        /// <param name="opcion">Opción a quitar</param>
        public void quitarOpcion(Opcion opcion)
        {
            _opciones.Remove(opcion);
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        #endregion Overrides

    }

}
