//
//  @ Project : 
//  @ File Name : DescargaATMFull.cs
//  @ Date : 09/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace CommonObjects
{

    public class DescargaATMFull : MovimientoATM
    {

        #region Atributos Privados

        protected CargaATM _carga;

        public CargaATM Carga
        {
            get { return _carga; }
            set { _carga = value; }
        }

        protected CargaEmergenciaATMFull _carga_emergencia;

        public CargaEmergenciaATMFull Carga_emergencia
        {
            get { return _carga_emergencia; }
            set { _carga_emergencia = value; }
        }

        protected ManifiestoATMFull _manifiesto;

        public ManifiestoATMFull Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected DateTime _hora_diferencia;

        public DateTime Hora_diferencia
        {
            get { return _hora_diferencia; }
            set { _hora_diferencia = value; }
        }

        protected BindingList<MontoDescargaATMFull> _montos = new BindingList<MontoDescargaATMFull>();

        public BindingList<MontoDescargaATMFull> Montos
        {
            get { return _montos; }
            set { _montos = value; }
        }

        protected BindingList<MontoDescargaATMFull> _montos_colones = new BindingList<MontoDescargaATMFull>();

        public BindingList<MontoDescargaATMFull> Montos_colones
        {
            get { return _montos_colones; }
        }

        protected BindingList<MontoDescargaATMFull> _montos_dolares = new BindingList<MontoDescargaATMFull>();

        public BindingList<MontoDescargaATMFull> Montos_dolares
        {
            get { return _montos_dolares; }
        }

        protected BindingList<ContadorDescargaATMFull> _contadores = new BindingList<ContadorDescargaATMFull>();

        public BindingList<ContadorDescargaATMFull> Contadores
        {
            get { return _contadores; }
            set { _contadores = value; }
        }

        protected BindingList<ContadorDescargaATMFull> _contadores_colones = new BindingList<ContadorDescargaATMFull>();

        public BindingList<ContadorDescargaATMFull> Contadores_Colones
        {
            get { return _contadores_colones; }
        }

        protected BindingList<ContadorDescargaATMFull> _contadores_dolares = new BindingList<ContadorDescargaATMFull>();

        public BindingList<ContadorDescargaATMFull> Contadores_Dolares
        {
            get { return _contadores_dolares; }
        }

        protected decimal _monto_descarga_colones;

        public decimal Monto_descarga_colones
        {
            get { return _monto_descarga_colones; }
        }

        protected decimal _monto_descarga_dolares;

        public decimal Monto_descarga_dolares
        {
            get { return _monto_descarga_dolares; }
        }

        public ATM ATM
        {
            get { return _carga == null ? _carga_emergencia.ATM : _carga.ATM; }
        }

        public bool ENA
        {
            get { return _carga == null ? _carga_emergencia.ENA : _carga.ENA; }
        }

        public bool Emergencia
        {
            get { return _carga_emergencia != null; }
        }

        public DateTime Fecha_carga
        {
            get { return _carga == null ? (DateTime)_carga_emergencia.Fecha_carga : _carga.Fecha_asignada; }
        }

        public string Codigo_manifiesto
        {
            get { return _manifiesto == null ? string.Empty :_manifiesto.Codigo; }
        }

        public string Codigo_marchamo
        {
            get
            {
                ManifiestoATMFull manifiesto = _carga == null ?
                    _carga_emergencia.Manifiesto : _carga.Manifiesto_full;

                if (this.ENA)
                    return manifiesto == null ? string.Empty : manifiesto.Marchamo_adicional_ena;
                else
                    return manifiesto.Marchamo;

            }

        }
        
        #region Depositado

        protected decimal _monto_depositado_colones;

        public decimal Monto_depositado_colones
        {
            get { return _monto_depositado_colones; }
        }

        protected decimal _monto_depositado_dolares;

        public decimal Monto_depositado_dolares
        {
            get { return _monto_depositado_dolares; }
        }

        #endregion Depositado

        #region Diferencias

        protected bool _cuadrada;

        public bool Cuadrada
        {
            get { return _cuadrada; }
        }

        public decimal Diferencia_colones
        {
            get
            {
                return (this.Monto_descarga_colones - this.Monto_depositado_colones);
            }
        }

        public decimal Diferencia_dolares
        {
            get
            {
                return (this.Monto_descarga_dolares - this.Monto_depositado_dolares);
            }
        }

        #endregion Diferencias

        private Dictionary<Denominacion, DetalleDescargaATMFull> _detalles_denominacion = new Dictionary<Denominacion, DetalleDescargaATMFull>();

        protected BindingList<DetalleDescargaATMFull> _detalles = new BindingList<DetalleDescargaATMFull>();

        public BindingList<DetalleDescargaATMFull> Detalles
        {
            get { return _detalles; }
        }

        protected BindingList<DetalleDescargaATMFull> _detalles_colones = new BindingList<DetalleDescargaATMFull>();

        public BindingList<DetalleDescargaATMFull> Detalles_Colones
        {
            get { return _detalles_colones; }
        }

        protected BindingList<DetalleDescargaATMFull> _detalles_dolares = new BindingList<DetalleDescargaATMFull>();

        public BindingList<DetalleDescargaATMFull> Detalles_Dolares
        {
            get { return _detalles_dolares; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public DescargaATMFull(int id = 0,
                           CierreATMs cierre = null,

                           CargaATM carga = null,
                           CargaEmergenciaATMFull carga_emergencia = null,
                           ManifiestoATMFull manifiesto = null,
                           DateTime? fecha = null,
                           DateTime? hora_inicio = null,
                           DateTime? hora_finalizacion = null,
                           DateTime? hora_diferencia = null,
                           string observaciones = "")
        {
            this.DB_ID = id;
            this.Cierre = cierre;
           
            this.Hora_inicio = hora_inicio ?? DateTime.Now;
            this.Hora_finalizacion = hora_finalizacion ?? DateTime.Now;
            this.Hora_diferencia = hora_diferencia ?? DateTime.Now;
            this.Observaciones = observaciones;

            _carga = carga;
            _carga_emergencia = carga_emergencia;
            _manifiesto = manifiesto;
            _fecha = fecha ?? DateTime.Now;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Crear los montos con base en una lista de denominaciones.
        /// </summary>
        /// <param name="denominaciones">Lista de denominaciones para las cuales se crearán los montos</param>
        public void crearMontos(BindingList<Denominacion> denominaciones)
        {

            foreach (Denominacion denominacion in denominaciones)
            {
                MontoDescargaATMFull monto = new MontoDescargaATMFull(denominacion);

                this.agregarMonto(monto);
            }

        }

        /// <summary>
        /// Agregar un monto para la descarga.
        /// </summary>
        /// <param name="monto">Monto a agregar</param>
        public void agregarMonto(MontoDescargaATMFull monto)
        {
            _montos.Add(monto);

            switch (monto.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _montos_colones.Add(monto);
                    _monto_descarga_colones += monto.Monto_descarga;
                    break;
                case Monedas.Dolares:
                    _montos_dolares.Add(monto);
                    _monto_descarga_dolares += monto.Monto_descarga;
                    break;
            }

        }

        /// <summary>
        /// Quitar un monto de la descarga.
        /// </summary>
        /// <param name="monto">Monto a quitar</param>
        public void quitarMonto(MontoDescargaATMFull monto)
        {
            _montos.Remove(monto);

            switch (monto.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _montos_colones.Remove(monto);
                    _monto_descarga_colones -= monto.Monto_descarga;
                    break;
                case Monedas.Dolares:
                    _montos_dolares.Remove(monto);
                    _monto_descarga_dolares -= monto.Monto_descarga;
                    break;
            }

        }

        /// <summary>
        /// Crear los contadores con base en una lista de denominaciones.
        /// </summary>
        /// <param name="denominaciones">Lista de denominaciones para las cuales se crearán los contadores</param>
        public void crearContadores(BindingList<Denominacion> denominaciones)
        {

            foreach (Denominacion denominacion in denominaciones)
            {
                ContadorDescargaATMFull contador = new ContadorDescargaATMFull(denominacion);

                this.agregarContador(contador);
            }

        }

        /// <summary>
        /// Agregar un contador a la descarga full.
        /// </summary>
        /// <param name="contador">Contador a agregar</param>
        public void agregarContador(ContadorDescargaATMFull contador)
        {
            _contadores.Add(contador);

            switch (contador.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _contadores_colones.Add(contador);
                    _monto_depositado_colones += contador.Monto_depositado;
                    break;
                case Monedas.Dolares:
                    _contadores_dolares.Add(contador);
                    _monto_depositado_dolares += contador.Monto_depositado;
                    break;
            }

        }

        /// <summary>
        /// Quitar un contador de la descarga full.
        /// </summary>
        /// <param name="contador">Contador a quitar</param>
        public void quitarContador(ContadorDescargaATMFull contador)
        {
            _contadores.Remove(contador);

            switch (contador.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _contadores_colones.Remove(contador);
                    _monto_depositado_colones -= contador.Monto_depositado;
                    break;
                case Monedas.Dolares:
                    _contadores_dolares.Remove(contador);
                    _monto_depositado_dolares -= contador.Monto_depositado;
                    break;
            }

        }

        /// <summary>
        /// Recalcular los montos de una descarga.
        /// </summary>
        public void recalcularMontosDescarga()
        {
            _monto_descarga_colones = 0;
            _monto_descarga_dolares = 0;

            _monto_depositado_colones = 0;
            _monto_depositado_dolares = 0;

            // Montos descargados

            foreach (MontoDescargaATMFull monto in _montos)
            {

                switch (monto.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_descarga_colones += monto.Monto_descarga;
                        break;
                    case Monedas.Dolares:
                        _monto_descarga_dolares += monto.Monto_descarga;
                        break;
                }

            }

            // Contadores

            foreach (ContadorDescargaATMFull contador in _contadores)
            {

                switch (contador.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_depositado_colones += contador.Monto_depositado;
                        break;
                    case Monedas.Dolares:
                        _monto_depositado_dolares += contador.Monto_depositado;
                        break;
                }

            }

        }

        /// <summary>
        /// Recalcular los detalles por denominación de la descarga.
        /// </summary>
        public void recalcularDetalles()
        {

            foreach (DetalleDescargaATMFull detalle in _detalles_denominacion.Values)
            {
                detalle.Cantidad_descargada = 0;
                detalle.Cantidad_depositada = 0;
            }

            foreach (MontoDescargaATMFull monto in _montos)
            {
                DetalleDescargaATMFull detalle = this.obtenerDetalle(monto.Denominacion);

                detalle.Cantidad_descargada += monto.Cantidad;
            }

            foreach (ContadorDescargaATMFull contador in _contadores)
            {
                DetalleDescargaATMFull detalle = this.obtenerDetalle(contador.Denominacion);

                detalle.Cantidad_depositada += contador.Cantidad_depositada;
            }

            _detalles_colones.Clear();
            _detalles_dolares.Clear();
            _detalles.Clear();

            _cuadrada = true;

            foreach (DetalleDescargaATMFull detalle in _detalles_denominacion.Values)
            {

                switch (detalle.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _detalles_colones.Add(detalle);
                        break;
                    case Monedas.Dolares:
                        _detalles_dolares.Add(detalle);
                        break;
                }

                if (detalle.Cantidad_diferencia != 0)
                    _cuadrada = false;

                _detalles.Add(detalle);
            }

        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Obtener el detalle por denominación de una denominación.
        /// </summary>
        private DetalleDescargaATMFull obtenerDetalle(Denominacion denominacion)
        {

            if (_detalles_denominacion.ContainsKey(denominacion))
            {
                return _detalles_denominacion[denominacion];
            }
            else
            {
                DetalleDescargaATMFull detalle = new DetalleDescargaATMFull(denominacion);

                _detalles_denominacion.Add(denominacion, detalle);

                return detalle;
            }

        }

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides

    }

}
