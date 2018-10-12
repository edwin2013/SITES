using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class TipoPenalidad : ObjetoIndexado
    {
        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descripcion;

        public string Nombre
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        

        protected BindingList<NivelTipoPenalidad> _niveles = new BindingList<NivelTipoPenalidad>();

        public BindingList<NivelTipoPenalidad> Niveles
        {
            get { return _niveles; }
            set { _niveles = value; }
        }


        #endregion Atributos Privados

        #region Constructor de Clase

        public TipoPenalidad(short id = 0, string nombre = "")
        {
            _id = id;
            this.Id = id;
            _descripcion = nombre;
        }

       

     
        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Permite agregar un nivel a la lista de niveles del tipo penalidad
        /// </summary>
        /// <param name="tarifa">Objeto NivelTipoPenalidad</param>
        public void agregarNivel(NivelTipoPenalidad tarifa)
        {
            this._niveles.Add(tarifa);
        }

        /// <summary>
        /// Permite quitar un nivel de la lista de niveles del tipo de penalidad
        /// </summary>
        /// <param name="tarifa">Objeto NivelTipoPenalidad</param>
        public void quitarNivel(NivelTipoPenalidad tarifa)
        {
            this._niveles.Remove(tarifa);
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return this._descripcion;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            TipoPenalidad punto = (TipoPenalidad)obj;

            if (_id != punto.Id) return false;

            return true;
        }

        #endregion Overrides
    }
}
