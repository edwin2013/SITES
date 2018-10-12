using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class CierreCargaBanco : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        protected Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }

        protected Camara _camara;

        public Camara Camara
        {
            get { return _camara; }
            set { _camara = value; }
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

        public bool Cargas_listas
        {
            get { return this.cargasListas(); }
        }

        protected BindingList<PedidoBancos> _cargas = new BindingList<PedidoBancos>();

        public BindingList<PedidoBancos> Cargas
        {
            get { return _cargas; }
            set { _cargas = value; }
        }



        #endregion Atributos Privados

        #region Constructor de Clase

        public CierreCargaBanco(Colaborador cajero,
                          int id = 0,
                          Colaborador coordinador = null,
                          Camara camara = null,
                          DateTime? fecha = null, 
                          bool terminado = false)
        {
            this.DB_ID = id;

            _cajero = cajero;
            _coordinador = coordinador;
            _camara = camara;
            _fecha = fecha ?? DateTime.Now;
            _terminado = terminado;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar una carga al cierre.
        /// </summary>
        /// <param name="carga">Carga a agregar</param>
        public void agregarCarga(PedidoBancos carga)
        {
            _cargas.Add(carga);
        }

        /// <summary>
        /// Quitar una carga del cierre.
        /// </summary>
        /// <param name="carga">Carga a quitar</param>
        public void quitarCarga(PedidoBancos carga)
        {
            _cargas.Remove(carga);
        }

       

        #endregion Métodos Públicos

        #region Metodos Privados

        /// <summary>
        /// Verificar si una carga está lista.
        /// </summary>
        /// <returns>Valor que indica si las cargas están listas</returns>
        private bool cargasListas()
        {

            foreach (PedidoBancos carga in _cargas)
                if (carga.Colaborador_verificador == null)
                    return false;

            return true;
        }

        #endregion Metodos Privados

        #region Overrides

        public override string ToString()
        {
            return _cajero.ToString();
        }

        #endregion Overrides
    }
}
