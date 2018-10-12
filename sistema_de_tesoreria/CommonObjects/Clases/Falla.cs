using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public enum TipoFalla : byte
    {
        Vehiculos = 1,
        ATMs = 2,
    }

    public class Falla: ObjetoIndexado
    {


        #region Atributos Privados

        public short ID
        {
            get { return (short)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        protected TipoFallasBlindados _tipo_falla;

        public TipoFallasBlindados Tipo_Falla
        {
            get { return _tipo_falla; }
            set { _tipo_falla = value; }
        }


        private BindingList<DetalleFalla> _detalle_falla = new BindingList<DetalleFalla>();

        public BindingList<DetalleFalla> Detalle_falla
        {
            get { return _detalle_falla; }
            set { _detalle_falla = value; }
        }


        #endregion Atributos Privados

        #region Constructor de Clase

        public Falla(short id = 0,
                   string descripcion = "",
                   TipoFallasBlindados tipo = null)
        {
            this.DB_ID = id;
            _descripcion = descripcion;
            _tipo_falla = tipo;
           
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un detalle de falla.
        /// </summary>
        /// <param name="punto">Nuevo detalle de falla a agregar</param>
        public void agregarDetalleFalla(DetalleFalla punto)
        {
            _detalle_falla.Add(punto);
        }

        /// <summary>
        /// Quitar un detalle de una falla.
        /// </summary>
        /// <param name="punto">Detalle de falla a quitar</param>
        public void quitarDetalleFalla(DetalleFalla punto)
        {
            _detalle_falla.Remove(punto);
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return _descripcion;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Falla cliente = (Falla)obj;

            if (_db_id != cliente.ID) return false;

            return true;
        }
        #endregion Overrides
    }
}
