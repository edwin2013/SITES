using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
   public class FallaCartucho : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private Colaborador _usuario;
        public Colaborador Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private bool _noRecuperable;
        public bool NoRecuperable {
            get { return _noRecuperable; }
            set { _noRecuperable = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public FallaCartucho() { }

       //constructor de falla por cartucho
        public FallaCartucho(int id = 0, 
            string nombre = "",
            Colaborador us = null,
            DateTime? fecha = null,
            int cantidad = 0, 
            bool? NRecuperable = null)
        {
            this.DB_ID = id;
            _nombre = nombre;
            _usuario = us;
            _fecha = fecha ?? DateTime.Now;
            _noRecuperable = NRecuperable ?? false;
            
        }

       // constructor de la falla general
        public FallaCartucho(int id = 0,
                       string nombre = "",
                       int cantidad = 0,
                       bool? NRecuperable = null)
        {
            this.DB_ID = id;
            _nombre = nombre;
            _noRecuperable = NRecuperable ?? false;
            _cantidad = cantidad;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        #endregion Overrides
    }
}
