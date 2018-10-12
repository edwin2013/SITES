using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class GarantiaCartucho: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private int _dias;

        public int dias
        {
            get { return _dias; }
            set { _dias = value; }
        }

        private Colaborador _usuario;

        public Colaborador usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        #endregion Atributos Privados

         #region Constructor de Clase

        public GarantiaCartucho(int id = 0,
                      int dias = 0,
                      DateTime? fecha = null,
                      Colaborador usuario = null)
        {
            this.DB_ID = id;
            _dias = dias;
            _usuario = usuario;
            _fecha = fecha ?? DateTime.Now;  
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return usuario.Nombre;
        }

        #endregion Overrides
    }
}
