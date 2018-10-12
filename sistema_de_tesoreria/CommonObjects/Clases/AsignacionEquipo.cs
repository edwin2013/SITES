using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class AsignacionEquipo : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Colaborador _colaborador_asignado;

        public Colaborador ColaboradorAsignado
        {
            get { return _colaborador_asignado; }
            set { _colaborador_asignado = value; }
        }

        protected Colaborador _colaborador_registro;

        public Colaborador ColaboradorRegistro
        {
            get { return _colaborador_registro; }
            set { _colaborador_registro = value; }
        }

        protected Tripulacion _tripulacion;

        public Tripulacion Tripulacion
        {
            get { return _tripulacion; }
            set { _tripulacion = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected bool _terminado = false;

        public bool Terminado
        {
            get { return _terminado; }
            set { _terminado = value; }
        }

        public bool Activo
        {
            get { return !_terminado; }
        }

       

        protected BindingList<Equipo> _equipos = new BindingList<Equipo>();

        public BindingList<Equipo> Equipos
        {
            get { return _equipos; }
            set { _equipos = value; }
        }


        #endregion Atributos Privados

        #region Constructor de Clase

        public AsignacionEquipo(Colaborador usuarioasignado = null,
                          int id = 0,
                          Colaborador usuarioregistro = null,
                          Tripulacion tripulacion = null,
                          DateTime? fecha = null, 
                          bool terminado = false)
        {
            this.DB_ID = id;

            _colaborador_asignado = usuarioasignado;
            _colaborador_registro = usuarioregistro;
            _tripulacion = tripulacion;
            _fecha = fecha ?? DateTime.Now;
            _terminado = terminado;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar una equipo al cierre.
        /// </summary>
        /// <param name="equipo">Equipo a agregar</param>
        public void agregarEquipo(Equipo equipo)
        {
            _equipos.Add(equipo);
        }

        /// <summary>
        /// Quitar una equipo del cierre.
        /// </summary>
        /// <param name="equipo">Equipo a quitar</param>
        public void quitarEquipo(Equipo equipo)
        {
            _equipos.Remove(equipo);
        }


        #endregion Métodos Públicos

        #region Metodos Privados

       
        #endregion Metodos Privados

        #region Overrides

        public override string ToString()
        {
            if (_colaborador_asignado != null)
                return _colaborador_asignado.ToString();
            else
                return "";
        }

        #endregion Overrides
    }
}
