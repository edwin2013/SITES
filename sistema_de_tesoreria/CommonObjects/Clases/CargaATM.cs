//
//  @ Project : 
//  @ File Name : CargaATM.cs
//  @ Date : 16/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;

namespace CommonObjects
{

    public enum EstadoDescargadaATM : byte
    {
        Pendiente = 0,
        Descargada = 1
    }


    public enum TipoEntregas : byte
    {
        Recibido = 1,
        Entregado = 2
    }

    public enum EstadosCargas : byte
    {
        Libre = 0,
        Asignada = 1,
        Terminada = 2
    }

    public enum TipoVisitas : int
    {
        Carga_Descarga = 1,
        Descarga = 2,
        Papel = 3,
        Carga_Descarga_Papel = 4,
        Descarga_Papel = 5
    }

    public class CargaATM : MovimientoATM
    {

        #region Atributos Privados

        protected ATM _atm;

        public ATM ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }

        protected byte? _emergencia;

        public byte? Emergencia
        {
            get { return _emergencia; }
            set { _emergencia = value; }
        }

        protected TiposCartucho _tipo;

        public TiposCartucho Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }


        protected Colaborador _receptor_tulas;
        public Colaborador ReceptorTulas
        {
            get { return _receptor_tulas; }
            set { _receptor_tulas = value; }
        }

        protected ManifiestoATMCarga _manifiesto;

        public ManifiestoATMCarga Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected ManifiestoATMFull _manifiesto_full;

        public ManifiestoATMFull Manifiesto_full
        {
            get { return _manifiesto_full; }
            set { _manifiesto_full = value; }
        }

        protected EmpresaTransporte _transportadora;

        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }

        protected DateTime _fecha_asignada;

        public DateTime Fecha_asignada
        {
            get { return _fecha_asignada; }
            set { _fecha_asignada = value; }
        }

        protected byte? _ruta;

        public byte? Ruta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }

        protected byte? _orden_ruta;

        public byte? Orden_ruta
        {
            get { return _orden_ruta; }
            set { _orden_ruta = value; }
        }

        protected bool _externa;

        public bool Externa
        {
            get { return _externa; }
            set { _externa = value; }
        }

        protected bool _atm_full;

        public bool ATM_full
        {
            get { return _atm_full; }
            set { _atm_full = value; }
        }

        protected bool _cartucho_rechazo;

        public bool Cartucho_rechazo
        {
            get { return _cartucho_rechazo; }
            set { _cartucho_rechazo = value; }
        }

        protected bool _ena;

        public bool ENA
        {
            get { return _ena; }
            set { _ena = value; }
        }

        protected Colaborador _colaborador_verificador;

        public Colaborador Colaborador_verificador
        {
            get { return _colaborador_verificador; }
            set { _colaborador_verificador = value; }
        }

        protected DateTime _fecha_verificacion;

        public DateTime Fecha_verificacion
        {
            get { return _fecha_verificacion; }
            set { _fecha_verificacion = value; }
        }

        public int Cantidad_denominaciones
        {
            get { return _cartuchos_denominaciones.Keys.Count; }
        }

        public bool Modificada
        {
            get { return this.fueModificada(); }
        }

        public bool Lista
        {
            get { return this.estaLista(); }
        }

        public bool Verificada
        {
            get { return _colaborador_verificador != null;; }
        }

        public bool Tiene_atm
        {
            get { return _atm != null; }
        }

        public bool Es_Emergencia
        {
            get { return _atm == null; }
        }

        public bool Bolsa_Rechazo
        {
            get { return !_cartucho_rechazo; }
        }

        public string Codigo
        {
            get
            {


                return (Es_Emergencia ? "E" + Emergencia.ToString() : _atm.Numero.ToString());
                
            }

            
        }
        

        public string Unico
        {
            get { return "A" + ID.ToString(); }
        }

        protected short _cantidad_asignada_colones;

        public short Cantidad_asignada_colones
        {
            get { return _cantidad_asignada_colones; }
        }

        protected short _cantidad_asignada_dolares;

        public short Cantidad_asignada_dolares
        {
            get { return _cantidad_asignada_dolares; }
        }

        protected decimal _monto_pedido_colones;

        public decimal Monto_pedido_colones
        {
            get { return _monto_pedido_colones; }
            set { _monto_pedido_colones = value; }
        }

        protected decimal _monto_pedido_dolares;

        public decimal Monto_pedido_dolares
        {
            get { return _monto_pedido_dolares; }
            set { _monto_pedido_dolares = value; }
        }

        protected decimal _monto_asignado_colones;

        public decimal Monto_asignado_colones
        {
            get { return _monto_asignado_colones; }
        }



        protected decimal _monto_asignado_dolares;

        public decimal Monto_asignado_dolares
        {
            get { return _monto_asignado_dolares; }
        }


        protected decimal _monto_asignado_euros = 0;

        public decimal Monto_asignado_euros
        {
            get { return _monto_asignado_euros; }
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

        protected DateTime _hora_llegada;
        public DateTime Hora_Llegada
        {
            get { return _hora_llegada; }
            set { _hora_llegada = value; }
        }

        public string Hora_Programada
        {
            get { return _hora_inicio.TimeOfDay.ToString(); }
        }


        protected string _codigo_ruta;
        public string Codigo_Ruta
        {

            get { return Fecha_asignada.Day.ToString("00") + Fecha_asignada.Month.ToString("00") + Fecha_asignada.Year.ToString() + Ruta.ToString(); }

        }


        protected int _tipocarga;
        public int Tipo_Carga
        {
            set { _tipocarga = value; }
            get { return _tipocarga; }
        }

        protected int _tiempo_viaje;
        public int Tiempo_Viaje
        {
            set { _tiempo_viaje = value; }
            get { return _tiempo_viaje; }
        }

        protected double _distancia;
        public double Distancia
        {
            set { _distancia = value; }
            get { return _distancia; }
        }



        protected DateTime _hora_entrada;
        public DateTime Hora_Entrada
        {
            set { _hora_entrada = value; }
            get { return _hora_entrada; }
        }

        protected DateTime _hora_salida;
        public DateTime Hora_Salida
        {
            set { _hora_salida = value; }
            get { return _hora_salida; }
        }

        protected DateTime _hora_programada_roadnet;
        public DateTime Hora_Programada_Roadnet
        {
            set { _hora_programada_roadnet = value; }
            get { return _hora_programada_roadnet; }
        }

        protected DateTime _hora_recibido_boveda;
        public DateTime HoraRecibidoBoveda
        {
            set { _hora_recibido_boveda = value; }
            get { return _hora_recibido_boveda; }
        }

        protected DateTime _hora_entrega_boveda;
        public DateTime HoraEntregaoBoveda
        {
            set { _hora_entrega_boveda = value; }
            get { return _hora_entrega_boveda; }
        }


        protected Colaborador _colaborador_recibido_boveda;
        public Colaborador ColaboradorRecibidoBoveda
        {
            set { _colaborador_recibido_boveda = value; }
            get { return _colaborador_recibido_boveda; }
        }


        protected Colaborador _colaborador_entregado_boveda;
        public Colaborador ColaboradorEntregadoBoveda
        {
            set { _colaborador_entregado_boveda = value; }
            get { return _colaborador_entregado_boveda; }
        }


        protected TipoEntregas _tipo_entrega;
        public TipoEntregas TipoEntregas
        {
            set { _tipo_entrega = value; }
            get { return _tipo_entrega; }
        }

        public string Dato
        {
            get { return Manifiesto.Marchamo_adicional; }
        }

        protected String _codigo_apertura;

        public String CodigoApertura
        {
            set { _codigo_apertura = value; }
            get { return _codigo_apertura; }
        }


        protected String _codigo_cierre;

        public String CodigoCierre
        {
            set { _codigo_cierre = value; }
            get { return _codigo_cierre; }
        }

        public String NombreATM
        {
            get { return _atm == null ? string.Empty : _atm.Codigo; }
        }

        protected bool _confirmadacodigos;
        public bool ConfirmacionCodigos
        {
            set { _confirmadacodigos = value; }
            get { return _confirmadacodigos; }
        }


        protected bool _solicitudcodigos;
        public bool SolicitudCodigos
        {
            set { _solicitudcodigos = value; }
            get { return _solicitudcodigos; }
        }


        protected string _numerollave;

        public string NumeroLlave
        {
            set { _numerollave = value; }
            get { return _numerollave; }
        }
        private Dictionary<Denominacion, List<CartuchoCargaATM>> _cartuchos_denominaciones =
            new Dictionary<Denominacion, List<CartuchoCargaATM>>();

        private Tripulacion _tripulacion;
        public Tripulacion Tripulacion
        {
            get { return _tripulacion; }
            set { _tripulacion = value; }
        }


        protected TipoVisitas _tipo_visita;

        public TipoVisitas TipoVisita
        {
            get { return _tipo_visita; }
            set { _tipo_visita = value; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public CargaATM(ATM atm = null,
                        byte? emergencia = null,
                        int id = 0,
                        CierreATMs cierre = null,
                        Colaborador cajero = null,
                        ManifiestoATMCarga manifiesto = null,
                        ManifiestoATMFull manifiesto_full = null,
                        TiposCartucho tipo = TiposCartucho.Indefinido,
                        EmpresaTransporte transportadora = null,
                        DateTime? fecha_asignada = null,
                        DateTime? hora_inicio = null,
                        DateTime? hora_finalizacion = null,
                        DateTime? hora_llegada = null,
                        DateTime? hora_entrada = null,
                        DateTime? hora_salida = null,
                        DateTime? hora_roadnet = null,    
                        double distancia = 0,
                        int tiempoviaje = 0,
                        int tipocarga = 1,
                        byte? ruta =null,
                        byte? orden_ruta = null,
                        bool externa = false,
                        bool atm_full = false,
                        bool cartucho_rechazo = false,
                        bool ena = false,
                        string observaciones = "",
                        decimal monto_pedido_colones = 0,
                        decimal monto_pedido_dolares = 0,
                        string codigo_apertura = "",
                        string codigo_cierre = "",
                        bool confirmado = false,
                        bool solicitado = true,
                        string numerollave = "",
                        Tripulacion trip = null)
        {
            this.DB_ID = id;
            this.Cierre = cierre;
            this.Cajero = cajero;
            this.Hora_inicio = hora_inicio ?? DateTime.Now;
            this.Hora_finalizacion = hora_finalizacion ?? DateTime.Now;
            this.Hora_Llegada = hora_llegada ?? DateTime.Now;
            this.Observaciones = observaciones;

            _atm = atm;
            _emergencia = emergencia;
            _manifiesto = manifiesto;
            _manifiesto_full = manifiesto_full;
            _tipo = tipo;
            _transportadora = transportadora;
            _fecha_asignada = fecha_asignada ?? DateTime.Now;
          
            _ruta = ruta ?? 0;
            _orden_ruta = orden_ruta;
            _externa = externa;
            _atm_full = atm_full;
            _cartucho_rechazo = cartucho_rechazo;
            _ena = ena;
            _monto_pedido_colones = monto_pedido_colones;
            _monto_pedido_dolares = monto_pedido_dolares;

            _hora_programada_roadnet = hora_roadnet ?? DateTime.Now;
            _distancia = distancia;
            _tiempo_viaje = tiempoviaje;
            _hora_entrada = hora_entrada ?? DateTime.Now;
            _hora_salida = hora_salida ?? DateTime.Now;
            _tipocarga = tipocarga;

            _codigo_apertura = codigo_apertura;
            _codigo_cierre = codigo_cierre;

            _confirmadacodigos = confirmado;
            _solicitudcodigos = solicitado;

            _numerollave = numerollave;

            _tripulacion = trip;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un cartucho a la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a agregar</param>
        public void agregarCartucho(CartuchoCargaATM cartucho)
        {
            _cartuchos.Add(cartucho);

            switch (cartucho.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _cartuchos_colones.Add(cartucho);
                    _cantidad_asignada_colones += cartucho.Cantidad_asignada;
                    _monto_asignado_colones += cartucho.Monto_asignado;
                    _monto_carga_colones += cartucho.Monto_carga;
                    break;
                case Monedas.Dolares:
                    _cartuchos_dolares.Add(cartucho);
                    _cantidad_asignada_dolares += cartucho.Cantidad_asignada;
                    _monto_asignado_dolares += cartucho.Monto_asignado;
                    _monto_carga_dolares += cartucho.Monto_carga;
                    break;
            }

            this.asignaCartuchoDenominacion(cartucho);
        }

        /// <summary>
        /// Quitar un cartucho de la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a quitar</param>
        public void quitarCartucho(CartuchoCargaATM cartucho)
        {
            _cartuchos.Remove(cartucho);

            switch (cartucho.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _cartuchos_colones.Remove(cartucho);
                    _cantidad_asignada_colones -= cartucho.Cantidad_asignada;
                    _monto_asignado_colones -= cartucho.Monto_asignado;
                    _monto_carga_colones -= cartucho.Monto_carga;
                    break;
                case Monedas.Dolares:
                    _cartuchos_dolares.Remove(cartucho);
                    _monto_asignado_dolares -= cartucho.Monto_asignado;
                    _cantidad_asignada_dolares -= cartucho.Cantidad_asignada;
                    _monto_carga_dolares -= cartucho.Monto_carga;
                    break;
            }

            _cartuchos_denominaciones[cartucho.Denominacion].Remove(cartucho);
        }

        /// <summary>
        /// Recalcular los montos de una carga.
        /// </summary>
        public void recalcularMontosCarga()
        {
            _cantidad_asignada_colones = 0;
            _monto_asignado_colones = 0;
            _monto_carga_colones = 0;

            _cantidad_asignada_dolares = 0;
            _monto_asignado_dolares = 0;
            _monto_carga_dolares = 0;

            foreach (CartuchoCargaATM cartucho in _cartuchos)
            {

                switch (cartucho.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _cantidad_asignada_colones += cartucho.Cantidad_asignada;
                        _monto_asignado_colones += cartucho.Monto_asignado;
                        _monto_carga_colones += cartucho.Monto_carga;
                        break;
                    case Monedas.Dolares:
                        _cantidad_asignada_dolares += cartucho.Cantidad_asignada;
                        _monto_asignado_dolares += cartucho.Monto_asignado;
                        _monto_carga_dolares += cartucho.Monto_carga;
                        break;
                }

            }

        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Validar si una carga está lista.
        /// </summary>
        private bool estaLista()
        {

            foreach (CartuchoCargaATM cartucho in _cartuchos)
                if (cartucho.estaPendiente()) return false;

            if ((_atm_full && _manifiesto_full == null) ||
                (_manifiesto == null))
                return false;

            return true;
        }

        /// <summary>
        /// Validar si una carga fue modificada.
        /// </summary>
        private bool fueModificada()
        {

            foreach (CartuchoCargaATM cartucho in _cartuchos)
                if (cartucho.Cantidad_asignada != cartucho.Cantidad_carga)
                    return true;

            return false;
        }

        /// <summary>
        /// Agregar un cartucho a las lista de cartuchos de su misma denominacion.
        /// </summary>
        /// <param name="cartucho">Cartucho que se agregará</param>
        private void asignaCartuchoDenominacion(CartuchoCargaATM cartucho)
        {
            Denominacion denominacion = cartucho.Denominacion;

            if (_cartuchos_denominaciones.ContainsKey(denominacion))
            {
                _cartuchos_denominaciones[denominacion].Add(cartucho);
            }
            else
            {
                List<CartuchoCargaATM> cartuchos = new List<CartuchoCargaATM>();

                cartuchos.Add(cartucho);

                _cartuchos_denominaciones.Add(denominacion, cartuchos);
            }

        }

        #endregion Métodos Privados

        #region Overrides

        public override string ToString()
        {
            if (_atm == null)
                return "E" + _emergencia;
            else
                return _atm.Numero.ToString();
        }

        #endregion Overrides

    }

}
