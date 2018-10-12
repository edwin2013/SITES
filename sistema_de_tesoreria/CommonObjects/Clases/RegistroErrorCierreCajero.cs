//
//  @ Project : 
//  @ File Name : RegistroErroresCierre.cs
//  @ Date : 05/02/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;

namespace CommonObjects
{

    public class RegistroErroresCierre
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Colaborador _colaborador;

        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        private Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private bool _sin_errores;

        public bool Sin_errores
        {
            get { return _sin_errores; }
            set { _sin_errores = value; }
        }

        private List<TipoErrorCierre> _errores = new List<TipoErrorCierre>();

        public List<TipoErrorCierre> Errores
        {
            get { return _errores; }
            set { _errores = value; }
        }

        private string _otros_errores;

        public string Otros_errores
        {
            get { return _otros_errores; }
            set { _otros_errores = value; }
        }

        private string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RegistroErroresCierre(int id, Colaborador colaborador, Colaborador coordinador, DateTime fecha,
                                     bool sin_errores, string otros_errores, string observaciones)
        {
            _id = id;
            _colaborador = colaborador;
            _coordinador = coordinador;
            _fecha = fecha;
            _sin_errores = sin_errores;
            _otros_errores = otros_errores;
            _observaciones = observaciones;
        }

        public RegistroErroresCierre(Colaborador colaborador, Colaborador coordinador, DateTime fecha,
                                     bool sin_errores, string otros_errores, string observaciones)
        {
            _colaborador = colaborador;
            _coordinador = coordinador;
            _fecha = fecha;
            _sin_errores = sin_errores;
            _otros_errores = otros_errores;
            _observaciones = observaciones;
        }

        public RegistroErroresCierre(int id)
        {
            _id = id;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un tipo de error para el registro.
        /// </summary>
        /// <param name="error">Tipo de error a agregar</param>
        public void agregarError(TipoErrorCierre error)
        {
            _errores.Add(error);
        }

        /// <summary>
        /// Quitar un tipo de error del registro.
        /// </summary>
        /// <param name="error">Tipo de error a quitar</param>
        public void quitarError(TipoErrorCierre error)
        {
            _errores.Remove(error);
        }
        
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _colaborador.Nombre + " " + _colaborador.Primer_apellido;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            RegistroErroresCierre registro = (RegistroErroresCierre)obj;

            if (_id != registro.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
