//
//  @ Project : 
//  @ File Name : DescargaATM.cs
//  @ Date : 16/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace CommonObjects
{

    public class DescargaATM : MovimientoATM
    {

        #region Atributos Privados

        protected CargaATM _carga;

        public CargaATM Carga
        {
            get { return _carga; }
            set { _carga = value; }
        }

        protected CargaEmergenciaATM _carga_emergencia;

        public CargaEmergenciaATM Carga_emergencia
        {
            get { return _carga_emergencia; }
            set { _carga_emergencia = value; }
        }

        protected ManifiestoATMCarga _manifiesto;

        public ManifiestoATMCarga Manifiesto
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

        protected BindingList<RechazoDescargaATM> _rechazos = new BindingList<RechazoDescargaATM>();

        public BindingList<RechazoDescargaATM> Rechazos
        {
            get { return _rechazos; }
            set { _rechazos = value; }
        }

        protected BindingList<RechazoDescargaATM> _rechazos_colones = new BindingList<RechazoDescargaATM>();

        public BindingList<RechazoDescargaATM> Rechazos_Colones
        {
            get { return _rechazos_colones; }
        }

        protected BindingList<RechazoDescargaATM> _rechazos_dolares = new BindingList<RechazoDescargaATM>();

        public BindingList<RechazoDescargaATM> Rechazos_Dolares
        {
            get { return _rechazos_dolares; }
        }

        protected BindingList<ContadorDescargaATM> _contadores = new BindingList<ContadorDescargaATM>();

        public BindingList<ContadorDescargaATM> Contadores
        {
            get { return _contadores; }
            set { _contadores = value; }
        }

        protected BindingList<ContadorDescargaATM> _contadores_colones = new BindingList<ContadorDescargaATM>();

        public BindingList<ContadorDescargaATM> Contadores_Colones
        {
            get { return _contadores_colones; }
        }

        protected BindingList<ContadorDescargaATM> _contadores_dolares = new BindingList<ContadorDescargaATM>();

        public BindingList<ContadorDescargaATM> Contadores_Dolares
        {
            get { return _contadores_dolares; }
        }

        protected decimal _monto_descarga_colones;

        public decimal Monto_descarga_colones
        {
            get { return _monto_descarga_colones + _monto_rechazo_colones; }
        }

        protected decimal _monto_descarga_dolares;

        public decimal Monto_descarga_dolares
        {
            get { return _monto_descarga_dolares + _monto_rechazo_dolares; }
        }

        public ATM ATM
        {
            get { return _carga == null ? _carga_emergencia.ATM : _carga.ATM; }
        }

        public bool Emergencia
        {
            get { return _carga_emergencia != null; }
        }

        public TiposCartucho Tipo
        {
            get { return _carga == null ? _carga_emergencia.Tipo : _carga.Tipo; }
        }

        public DateTime Fecha_carga
        {
            get { return _carga == null ? _carga_emergencia.Fecha : _carga.Fecha_asignada; }
        }

        public string Codigo_manifiesto
        {
            get { return _manifiesto == null ? string.Empty :_manifiesto.Codigo; }
        }

        public string Codigo_marchamo
        {
            get { return _manifiesto == null ? string.Empty : _manifiesto.Marchamo_adicional; }
        }

        protected bool _completa;
        public bool Completa
        {
            get { return _completa; }
            set { _completa = value;  }
        }



        #region Montos de carga

        public decimal Monto_carga_colones
        {
            get { return _carga == null ? _carga_emergencia.Monto_carga_colones : _carga.Monto_carga_colones; }
        }

        public decimal Monto_carga_dolares
        {
            get { return _carga == null ? _carga_emergencia.Monto_carga_dolares : _carga.Monto_carga_dolares; }
        }

        #endregion Montos de carga

        #region Rechazo

        protected decimal _monto_rechazo_colones;

        public decimal Monto_rechazo_colones
        {
            get { return _monto_rechazo_colones; }
        }

        protected decimal _monto_rechazo_dolares;

        public decimal Monto_rechazo_dolares
        {
            get { return _monto_rechazo_dolares; }
        }

        #endregion Rechazo

        #region Dispensado

        protected decimal _monto_dispensado_colones;

        public decimal Monto_dispensado_colones
        {
            get { return _monto_dispensado_colones; }
        }

        protected decimal _monto_dispensado_dolares;

        public decimal Monto_dispensado_dolares
        {
            get { return _monto_dispensado_dolares; }
        }

        #endregion Dispensado

        #region Remanente

        protected decimal _monto_remanente_colones;

        public decimal Monto_remanente_colones
        {
            get { return _monto_remanente_colones; }
        }

        protected decimal _monto_remanente_dolares;

        public decimal Monto_remanente_dolares
        {
            get { return _monto_remanente_dolares; }
        }

        public decimal Monto_carga_contadores_colones
        {
            get { return _monto_dispensado_colones + _monto_remanente_colones; }
        }

        public decimal Monto_carga_contadores_dolares
        {
            get { return _monto_dispensado_dolares + _monto_remanente_dolares; }
        }

        #endregion Remanente

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
                return (this.Monto_carga_contadores_colones) == 0 ?
                this.Monto_descarga_colones :
                this.Monto_descarga_colones + _monto_dispensado_colones - 
                (_carga == null ? _carga_emergencia.Monto_carga_colones : _carga.Monto_carga_colones);
            }
        }

        public decimal Diferencia_dolares
        {
            get
            {
                return (this.Monto_carga_contadores_dolares) == 0 ?
                this.Monto_descarga_dolares :
                this.Monto_descarga_dolares + _monto_dispensado_dolares -
                (_carga == null ? _carga_emergencia.Monto_carga_dolares : _carga.Monto_carga_dolares);
            }
        }

        private Dictionary<Denominacion, DetalleDescargaATM> _detalles_denominacion = new Dictionary<Denominacion, DetalleDescargaATM>();

        protected BindingList<DetalleDescargaATM> _detalles = new BindingList<DetalleDescargaATM>();

        public BindingList<DetalleDescargaATM> Detalles
        {
            get { return _detalles; }
        }

        protected BindingList<DetalleDescargaATM> _detalles_colones = new BindingList<DetalleDescargaATM>();

        public BindingList<DetalleDescargaATM> Detalles_Colones
        {
            get { return _detalles_colones; }
        }

        protected BindingList<DetalleDescargaATM> _detalles_dolares = new BindingList<DetalleDescargaATM>();

        public BindingList<DetalleDescargaATM> Detalles_Dolares
        {
            get { return _detalles_dolares; }
        }

        #endregion Diferencias

        #endregion Atributos Privados

        #region Constructor de Clase

        public DescargaATM(int id = 0,
                           CierreATMs cierre = null,
                           ManifiestoATMCarga manifiesto = null,
                           CargaATM carga = null,
                           CargaEmergenciaATM carga_emergencia = null,
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
        /// Reasignar la carga de la descarga.
        /// </summary>
        public void reasignarCarga()
        {

            foreach (CartuchoCargaATM cartucho in _carga.Cartuchos)
                this.agregarCartucho(cartucho);

        }

        /// <summary>
        /// Reasignar la carga de emergencia de la descarga.
        /// </summary>
        public void reasignarCargaEmergencia()
        {

            foreach (CartuchoCargaATM cartucho in _carga_emergencia.Cartuchos)
                this.agregarCartucho(cartucho);

        }

        /// <summary>
        /// Agregar un cartucho a la descarga.
        /// </summary>
        /// <param name="cartucho">Cartucho a agregar</param>
        public void agregarCartucho(CartuchoCargaATM cartucho)
        {
            _cartuchos.Add(cartucho);

            switch (cartucho.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _cartuchos_colones.Add(cartucho);
                    _monto_descarga_colones += cartucho.Monto_descarga;
                    break;
                case Monedas.Dolares:
                    _cartuchos_dolares.Add(cartucho);
                    _monto_descarga_dolares += cartucho.Monto_descarga;
                    break;
            }

        }

        /// <summary>
        /// Quitar un cartucho de la descarga.
        /// </summary>
        /// <param name="cartucho">Cartucho a quitar</param>
        public void quitarCartucho(CartuchoCargaATM cartucho)
        {
            _cartuchos.Remove(cartucho);

            switch (cartucho.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _cartuchos_colones.Remove(cartucho);
                    _monto_descarga_colones -= cartucho.Monto_descarga;
                    break;
                case Monedas.Dolares:
                    _cartuchos_dolares.Remove(cartucho);
                    _monto_descarga_dolares -= cartucho.Monto_descarga;
                    break;
            }

        }

        /// <summary>
        /// Crear los rechazos con base en una lista de denominaciones.
        /// </summary>
        /// <param name="denominaciones">Lista de denominaciones para las cuales se crearán los rechazos</param>
        public void crearRechazos(BindingList<Denominacion> denominaciones)
        {

            foreach (Denominacion denominacion in denominaciones)
            {
                RechazoDescargaATM rechazo = new RechazoDescargaATM(denominacion);

                this.agregarRechazo(rechazo);

                //RechazoDescargaATM rechazobolsa = new RechazoDescargaATM(denominacion,0,0,true);

                //this.agregarRechazo(rechazo);
            }

        }

        /// <summary>
        /// Agregar un rechazo a la descarga.
        /// </summary>
        /// <param name="rechazo">Rechazo a agregar</param>
        public void agregarRechazo(RechazoDescargaATM rechazo)
        {
            _rechazos.Add(rechazo);

            switch (rechazo.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _rechazos_colones.Add(rechazo);
                    _monto_rechazo_colones += rechazo.Monto_descarga;
                    break;
                case Monedas.Dolares:
                    _rechazos_dolares.Add(rechazo);
                    _monto_rechazo_dolares += rechazo.Monto_descarga;
                    break;
            }

        }

        /// <summary>
        /// Quitar un rechazo de la descarga.
        /// </summary>
        /// <param name="rechazo">Rechazo a quitar</param>
        public void quitarRechazo(RechazoDescargaATM rechazo)
        {
            _rechazos.Remove(rechazo);

            switch (rechazo.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _rechazos_colones.Remove(rechazo);
                    _monto_rechazo_colones -= rechazo.Monto_descarga;
                    break;
                case Monedas.Dolares:
                    _rechazos_dolares.Remove(rechazo);
                    _monto_rechazo_dolares -= rechazo.Monto_descarga;
                    break;
            }

        }

        /// <summary>
        /// Obtener los rechazos de la descarga.
        /// </summary>
        public BindingList<RechazoDescargaATM> obtenerRechazos()
        {
            BindingList<RechazoDescargaATM> rechazos = new BindingList<RechazoDescargaATM>();

            foreach (RechazoDescargaATM rechazo in _rechazos) 
                rechazos.Add(rechazo);

            return rechazos;
        }

        /// <summary>
        /// Crear los contadores con base en una lista de denominaciones.
        /// </summary>
        /// <param name="denominaciones">Lista de denominaciones para las cuales se crearán los contadores</param>
        public void crearContadores(BindingList<Denominacion> denominaciones)
        {

            foreach (Denominacion denominacion in denominaciones)
            {
                ContadorDescargaATM contador = new ContadorDescargaATM(denominacion);

                this.agregarContador(contador);
            }

        }

        /// <summary>
        /// Agregar un contador a la descarga.
        /// </summary>
        /// <param name="contador">Contador a agregar</param>
        public void agregarContador(ContadorDescargaATM contador)
        {
            _contadores.Add(contador);

            switch (contador.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _contadores_colones.Add(contador);
                    _monto_dispensado_colones += contador.Monto_dispensado;
                    _monto_remanente_colones += contador.Monto_remanente;
                    break;
                case Monedas.Dolares:
                    _contadores_dolares.Add(contador);
                    _monto_dispensado_dolares += contador.Monto_dispensado;
                    _monto_remanente_dolares += contador.Monto_remanente;
                    break;
            }

        }

        /// <summary>
        /// Quitar un contador de la descarga.
        /// </summary>
        /// <param name="contador">Contador a quitar</param>
        public void quitarContador(ContadorDescargaATM contador)
        {
            _contadores.Remove(contador);

            switch (contador.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _contadores_colones.Remove(contador);
                    _monto_dispensado_colones -= contador.Monto_dispensado;
                    _monto_remanente_colones -= contador.Monto_remanente;
                    break;
                case Monedas.Dolares:
                    _contadores_dolares.Remove(contador);
                    _monto_dispensado_dolares -= contador.Monto_dispensado;
                    _monto_remanente_dolares -= contador.Monto_remanente;
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

            _monto_rechazo_colones = 0;
            _monto_rechazo_dolares = 0;

            _monto_dispensado_colones = 0;
            _monto_remanente_colones = 0;
            _monto_dispensado_dolares = 0;
            _monto_remanente_dolares = 0;

            // Montos descargados de los cartuchos

            foreach (CartuchoCargaATM cartucho in _cartuchos)
            {

                switch (cartucho.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_descarga_colones += cartucho.Monto_descarga;
                        break;
                    case Monedas.Dolares:
                        _monto_descarga_dolares += cartucho.Monto_descarga;
                        break;
                }

            }

            // Montos descargados de los rechazos

            foreach (RechazoDescargaATM rechazo in _rechazos)
            {

                switch (rechazo.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_rechazo_colones += rechazo.Monto_descarga;
                        break;
                    case Monedas.Dolares:
                        _monto_rechazo_dolares += rechazo.Monto_descarga;
                        break;
                }

            }

            // Contadores

            foreach (ContadorDescargaATM contador in _contadores)
            {

                switch (contador.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_dispensado_colones += contador.Monto_dispensado;
                        _monto_remanente_colones += contador.Monto_remanente;
                        break;
                    case Monedas.Dolares:
                        _monto_dispensado_dolares += contador.Monto_dispensado;
                        _monto_remanente_dolares += contador.Monto_remanente;
                        break;
                }

            }

        }

        /// <summary>
        /// Recalcular los detalles por denominación de la descarga.
        /// </summary>
        public void recalcularDetalles()
        {

            foreach (DetalleDescargaATM detalle in _detalles_denominacion.Values)
            {
                detalle.Cantidad_descargada = 0;
                detalle.Cantidad_cargada = 0;
                detalle.Cantidad_remanente = 0;
                detalle.Cantidad_dispensada = 0;
                detalle.Cantidad_dispensada_cartucho = 0;
                detalle.Cantidad_remanente_cartucho = 0;
                detalle.Cantidad_dispensada_bolsa = 0;
                detalle.Cantidad_remanente_bolsa = 0;
            }

            foreach (CartuchoCargaATM cartucho in _cartuchos)
            {
                DetalleDescargaATM detalle = this.obtenerDetalle(cartucho.Denominacion);

                detalle.Cantidad_descargada += cartucho.Cantidad_descarga;
                detalle.Cantidad_cargada += cartucho.Cantidad_carga;
            }

            foreach (RechazoDescargaATM rechazo in _rechazos)
            {
                DetalleDescargaATM detalle = this.obtenerDetalle(rechazo.Denominacion);

                if (rechazo._bolsa_rechazo)
                    detalle.Cantidad_dispensada_bolsa += rechazo.Cantidad_descarga;
                else
                    detalle.Cantidad_dispensada_cartucho += rechazo.Cantidad_descarga;
                    
            }

           

            foreach (ContadorDescargaATM contador in _contadores)
            {
                DetalleDescargaATM detalle = this.obtenerDetalle(contador.Denominacion);

                detalle.Cantidad_remanente += contador.Cantidad_remanente;
                detalle.Cantidad_dispensada += contador.Cantidad_dispensada;
                detalle.Cantidad_remanente_cartucho += contador.Cantidad_remanente_cartucho_rechazo;
                detalle.Cantidad_remanente_bolsa += contador.Cantidad_remanente_bolsa_rechazo;
            }

            _detalles_colones.Clear();
            _detalles_dolares.Clear();
            _detalles.Clear();

            _cuadrada = true;

            foreach (DetalleDescargaATM detalle in _detalles_denominacion.Values)
            {

                switch (detalle.Denominacion.Moneda)
                {
                    case Monedas.Colones: _detalles_colones.Add(detalle); break;
                    case Monedas.Dolares: _detalles_dolares.Add(detalle); break;
                }

               detalle.Cantidad_descargada += detalle.Cantidad_dispensada_cartucho;

                if (detalle.Cantidad_diferencia_contador != 0 ||
                    detalle.Cantidad_diferencia_remanente != 0)
                    _cuadrada = false;

                _detalles.Add(detalle);
            }

        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Obtener el detalle por denominación de una denominación.
        /// </summary>
        private DetalleDescargaATM obtenerDetalle(Denominacion denominacion)
        {

            if (_detalles_denominacion.ContainsKey(denominacion))
            {
                return _detalles_denominacion[denominacion];
            }
            else
            {
                DetalleDescargaATM detalle = new DetalleDescargaATM(denominacion);

                _detalles_denominacion.Add(denominacion, detalle);

                return detalle;
            }

        }

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides

    }

}
