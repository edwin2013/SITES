//
//  @ Project : 
//  @ File Name : CargaEmergenciaATM.cs
//  @ Date : 04/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class CargaEmergenciaATM : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected ATM _atm;

        public ATM ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected bool _descargada;

        public bool Descargada
        {
            get { return _descargada; }
            set { _descargada = value; }
        }

        protected BindingList<CargaATM> _emergencias = new BindingList<CargaATM>();

        public BindingList<CargaATM> Emergencias
        {
            get { return _emergencias; }
            set { _emergencias = value; }
        }

        protected BindingList<CartuchoCargaATM> _cartuchos = new BindingList<CartuchoCargaATM>();

        public BindingList<CartuchoCargaATM> Cartuchos
        {
            get { return _cartuchos; }
            set { _cartuchos = value; }
        }

        protected BindingList<CartuchoCargaATM> _cartuchos_colones = new BindingList<CartuchoCargaATM>();

        public BindingList<CartuchoCargaATM> Cartuchos_Colones
        {
            get { return _cartuchos_colones; }
        }

        protected BindingList<CartuchoCargaATM> _cartuchos_dolares = new BindingList<CartuchoCargaATM>();

        public BindingList<CartuchoCargaATM> Cartuchos_Dolares
        {
            get { return _cartuchos_dolares; }
        }

        protected decimal _monto_carga_colones;

        public decimal Monto_carga_colones
        {
            get { return _monto_carga_colones; }
        }

        protected decimal _monto_carga_dolares;

        public decimal Monto_carga_dolares
        {
            get { return _monto_carga_dolares; }
        }

        protected int _numero_emergencia; 

        public int NumeroEmergencia
        {
            set { _numero_emergencia = value; }
            get { return _numero_emergencia; }
        }

        public TiposCartucho Tipo
        {
            get { return _cartuchos.Count > 0 ? _cartuchos[0].Cartucho.Tipo : TiposCartucho.Indefinido; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public CargaEmergenciaATM(int id = 0, 
                                  ATM atm = null,
                                  DateTime? fecha = null,
                                  bool descargada = false,
                                  int numero_emergencia = 0)
        {
            this.DB_ID = id;

            _atm = atm;
            _fecha = fecha ?? DateTime.Now;
            _descargada = descargada;
            _numero_emergencia = numero_emergencia;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar una emergencia a la carga.
        /// </summary>
        /// <param name="emergencia">CargaATM de emergencia a agregar</param>
        public void agregarEmergencia(CargaATM emergencia)
        {
            _emergencias.Add(emergencia);
        }

        /// <summary>
        /// Quitar una emergencia de la carga.
        /// </summary>
        /// <param name="emergencia">CargaATM de emergencia a quitar</param>
        public void quitarEmergencia(CargaATM emergencia)
        {
            _emergencias.Remove(emergencia);
        }

        /// <summary>
        /// Reasignar la emergencias de la descarga.
        /// </summary>
        public void reasignarEmergencias()
        {
            _monto_carga_colones = 0;
            _monto_carga_dolares = 0;

            _cartuchos.Clear();
            _cartuchos_colones.Clear();
            _cartuchos_dolares.Clear();

            foreach (CargaATM emergencia in _emergencias)
            {

                foreach (CartuchoCargaATM cartucho in emergencia.Cartuchos)
                {
                    _cartuchos.Add(cartucho);

                    switch (cartucho.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            _cartuchos_colones.Add(cartucho);
                            break;
                        case Monedas.Dolares:
                            _cartuchos_dolares.Add(cartucho);
                            break;
                    }

                }

                _monto_carga_colones += emergencia.Monto_carga_colones;
                _monto_carga_dolares += emergencia.Monto_carga_dolares;
            }

        }

        #endregion Métodos Públicos

        #region Métodos Privados

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides

    }

}
