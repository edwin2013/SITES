using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public enum EstadoEmergenciaSucursales : byte
    {
        Pendiente = 1,
        DesAsignado = 2,
        Asignada = 3,
        
    }

    public class CargaEmergenciaSucursal : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Sucursal _sucursal;

        public Sucursal Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
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

        public EstadoEmergenciaSucursales _estado;
        private EstadoEmergenciaSucursales EstadoEmergencia
        {
            get { return _estado; }
            set { _estado = value; }
        }

        protected BindingList<CargaSucursal> _emergencias = new BindingList<CargaSucursal>();

        public BindingList<CargaSucursal> Emergencias
        {
            get { return _emergencias; }
            set { _emergencias = value; }
        }

        protected BindingList<CartuchoCargaSucursal> _cartuchos = new BindingList<CartuchoCargaSucursal>();

        public BindingList<CartuchoCargaSucursal> Cartuchos
        {
            get { return _cartuchos; }
            set { _cartuchos = value; }
        }

        protected BindingList<CartuchoCargaSucursal> _cartuchos_colones = new BindingList<CartuchoCargaSucursal>();

        public BindingList<CartuchoCargaSucursal> Cartuchos_Colones
        {
            get { return _cartuchos_colones; }
        }

        protected BindingList<CartuchoCargaSucursal> _cartuchos_dolares = new BindingList<CartuchoCargaSucursal>();

        public BindingList<CartuchoCargaSucursal> Cartuchos_Dolares
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
       

        #endregion Atributos Privados

        #region Constructor de Clase

        public CargaEmergenciaSucursal(int id = 0, 
                                  Sucursal sucursal = null,
                                  DateTime? fecha = null,
                                  bool entregada = false,
                                  int numero_emergencia = 0)
        {
            this.DB_ID = id;

            _sucursal = sucursal;
            _fecha = fecha ?? DateTime.Now;
            _descargada = entregada;
            _numero_emergencia = numero_emergencia;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar una emergencia a la carga.
        /// </summary>
        /// <param name="emergencia">CargaSucursal de emergencia a agregar</param>
        public void agregarEmergencia(CargaSucursal emergencia)
        {
            _emergencias.Add(emergencia);
        }

        /// <summary>
        /// Quitar una emergencia de la carga.
        /// </summary>
        /// <param name="emergencia">CargaSucursal de emergencia a quitar</param>
        public void quitarEmergencia(CargaSucursal emergencia)
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

            foreach (CargaSucursal emergencia in _emergencias)
            {

                foreach (CartuchoCargaSucursal cartucho in emergencia.Cartuchos)
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

                _monto_carga_colones += emergencia.Monto_asignado_colones;
                _monto_carga_dolares += emergencia.Monto_asignado_dolares;
            }

        }

        #endregion Métodos Públicos

        #region Métodos Privados

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides
    }
}
