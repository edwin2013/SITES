using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public abstract class MovimientoBanco: ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }


        protected DateTime _hora_inicio = DateTime.Now;

        public DateTime Hora_inicio
        {
            get { return _hora_inicio; }
            set { _hora_inicio = value; }
        }

        protected DateTime _hora_finalizacion = DateTime.Now;

        public DateTime Hora_finalizacion
        {
            get { return _hora_finalizacion; }
            set { _hora_finalizacion = value; }
        }

        protected string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        protected BindingList<BolsaCargaBanco> _bolsas = new BindingList<BolsaCargaBanco>();

        public BindingList<BolsaCargaBanco> Bolsas
        {
            get { return _bolsas; }
            set { _bolsas = value; }
        }

        protected BindingList<BolsaCargaBanco> _bolsas_colones = new BindingList<BolsaCargaBanco>();

        public BindingList<BolsaCargaBanco> Bolsa_Colones
        {
            get { return _bolsas_colones; }
        }

        protected BindingList<BolsaCargaBanco> _bolsas_dolares = new BindingList<BolsaCargaBanco>();

        public BindingList<BolsaCargaBanco> Bolsas_Dolares
        {
            get { return _bolsas_dolares; }
        }


        protected BindingList<BolsaCargaBanco> _bolsas_euros = new BindingList<BolsaCargaBanco>();

        public BindingList<BolsaCargaBanco> Bolsas_Euros
        {
            get { return _bolsas_euros; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Métodos Privados

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides
    }
}
