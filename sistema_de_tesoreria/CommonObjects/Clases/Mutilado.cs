using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public enum EstadoEfectivoMutilado : byte
    {
        Libre = 0,
        Asignada = 1,
        Terminada = 2,
        Entrega_Boveda = 3
    }

    public class Mutilado : MovimientoMutilado

    {
        #region Atributos Privados
        
        private DateTime _fecha_asignada;

        public DateTime Fecha_Asignada
        {
            get { return _fecha_asignada; }
            set { _fecha_asignada = value; }
        }

        protected DateTime _fecha_verificacion;

        public DateTime Fecha_Verificacion
        {
            get { return _fecha_verificacion; }
            set { _fecha_verificacion = value; }
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


        protected EstadosCargasSucursales _estado;

        public EstadosCargasSucursales Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        protected EmpresaTransporte _transportadora;

        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }

        private Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        
        protected Colaborador _colaborador_verificador;

        public Colaborador Colaborador_Verificador
        {
            get { return _colaborador_verificador; }
            set { _colaborador_verificador = value; }
        }



        protected Colaborador _colaborador_registro;

        public Colaborador Colaborador_Registro
        {
            get { return _colaborador_registro; }
            set { _colaborador_registro = value; }
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

        private Sucursal _sucursal;

        public Sucursal Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }

        private string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        public int Cantidad_denominaciones
        {
            get { return _cartuchos_denominaciones.Keys.Count; }
        }

        private decimal _monto_asignado_colones;

        public decimal Monto_Asignado_Colones
        {
            get { return _monto_asignado_colones; }
            set { _monto_asignado_colones = value; }
        }

        private decimal _monto_asignado_dolares;

        public decimal Monto_Asignado_Dolares
        {
            get { return _monto_asignado_dolares; }
            set { _monto_asignado_dolares = value; }
        }

        private decimal _monto_asignado_euros;

        public decimal Monto_Asingnado_Euros
        {
            get { return _monto_asignado_euros; }
            set { _monto_asignado_euros = value; }
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


        protected decimal _monto_pedido_euros;

        public decimal Monto_pedido_euros
        {
            get { return _monto_pedido_euros; }
            set { _monto_pedido_euros = value; }
        }

         private Dictionary<Denominacion, List<CartuchoMutilado>> _cartuchos_denominaciones =
            new Dictionary<Denominacion, List<CartuchoMutilado>>();

        protected BindingList<CartuchoMutilado> _cartuchos = new BindingList<CartuchoMutilado>();

        protected double _cantidad_asignada_colones;

        public double Cantidad_Asignada_colones
        {
            get { return _cantidad_asignada_colones; }
        }

        protected double _cantidad_asignada_dolares;

        public double Cantidad_Asignada_Dolares
        {
            get { return _cantidad_asignada_dolares; }
        }

        protected double _cantidad_asignada_euros;

        public double Cantidad_Asignada_Euros
        {
            get { return _cantidad_asignada_euros; }
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

        protected TipoEntregas _tipo_entrega;
        public TipoEntregas TipoEntregas
        {
            set { _tipo_entrega = value; }
            get { return _tipo_entrega; }
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
        
        protected string _codigo_ruta;
        
        public string Codigo_Ruta
        {

            get { return Fecha_Asignada.Day.ToString("00") + Fecha_Asignada.Month.ToString("00") + Fecha_Asignada.Year.ToString() + Ruta.ToString(); }

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
            get { return _colaborador_verificador != null; }
        }


        public string Codigo
        {
            get { return _sucursal == null ? string.Empty : _sucursal.Nombre; }
        }

        protected ManifiestoSucursalCarga _manifiesto;

        public ManifiestoSucursalCarga Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected string _numero_cuenta;
        public string Numero_Cuenta
        {
            set { _numero_cuenta = value; }
            get { return _numero_cuenta; }
        }

        public string Dato
        {
            get { return Manifiesto.Serie_Tula; }
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

        protected decimal _monto_carga_euros;
        private DateTime fecha_asignada;
        private EstadoEfectivoMutilado estado;

        public decimal Monto_carga_euros
        {
            get { return _monto_carga_euros; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Mutilado(int id = 0,
                        decimal monto_asingado_colones = 0,
                        decimal monto_asingado_dolares = 0,
                        decimal monto_asingado_euros = 0,
                        string observaciones = "",
                        Sucursal sucursal = null,
                        Colaborador cajero = null,
                        Colaborador verificador = null,
                        Colaborador registrador = null,
                        ManifiestoSucursalCarga manifiesto = null,
                        EmpresaTransporte transportadora = null,
                        DateTime? fecha_asignada = null,
                        DateTime? fecha_verificacion = null,
                        DateTime? hora_inicio = null,
                        DateTime? hora_finalizacion = null,
                        DateTime? hora_programada = null,
                        DateTime? hora_entrada = null,
                        DateTime? hora_salida = null,
                        DateTime? hora_roadnet = null,
                        double distancia = 0,
                        int tiempoviaje = 0,
                        int tipocarga = 5,
                        byte? ruta =null,
                        byte? orden_ruta = null,
                        string numero_cuenta = "",
                        decimal monto_pedido_colones = 0,
                        decimal monto_pedido_dolares = 0,
                        decimal monto_pedido_euros =0,
                        EstadosCargasSucursales estado = 0,
                        MovimientoSucursal movimiento = null)
           
        {
          this.DB_ID = id;
          this.Cajero = cajero;
          this.Colaborador_Registro = registrador;
          this.Colaborador_Verificador = verificador;
          this.Numero_Cuenta = _numero_cuenta;
          this.Hora_inicio = hora_inicio ?? DateTime.Now;
          this.Hora_finalizacion = hora_finalizacion ?? DateTime.Now;
          
            _fecha_asignada = fecha_asignada ?? DateTime.Now;
           _cajero = cajero;
           
           _observaciones = observaciones;
           _sucursal = sucursal;
           _transportadora = transportadora;
           _manifiesto = manifiesto;

            _monto_asignado_colones = monto_asingado_colones;
           _monto_asignado_dolares = monto_asingado_dolares;
           _monto_asignado_euros = monto_asingado_euros;
           _monto_pedido_colones = monto_pedido_colones;
           _monto_pedido_dolares = monto_pedido_dolares;
           _monto_pedido_euros = monto_pedido_euros;
           _estado = estado;
          
           _ruta = ruta ?? 0;
           _orden_ruta = orden_ruta;
           _hora_programada_roadnet = hora_roadnet ?? DateTime.Now;
           _distancia = distancia;
           _tiempo_viaje = tiempoviaje;
           _hora_entrada = hora_entrada ?? DateTime.Now;
           _hora_salida = hora_salida ?? DateTime.Now;
           
            

            
           
         }


        public Mutilado()
        {
            // TODO: Complete member initialization
        }

        public Mutilado(CommonObjects.Sucursal sucursal, EmpresaTransporte transportadora, DateTime fecha_asignada, Colaborador cajero, ManifiestoSucursalCarga manifiesto, EstadoEfectivoMutilado estado)
        {
            // TODO: Complete member initialization
            this.Sucursal = sucursal;
            this.Transportadora = transportadora;
            this.fecha_asignada = fecha_asignada;
            this.Cajero = cajero;
            this.Manifiesto = manifiesto;
            this.estado = estado;
        }

        #endregion Constructor de Clase


        #region Métodos Públicos

        /// <summary>
        /// Validar si una carga está lista.
        /// </summary>
        private bool estaLista()
        {

            foreach (CartuchoMutilado cartucho in _cartuchos)
                if (cartucho.estaPendiente()) return false;

            return true;
        }

        /// <summary>
        /// Validar si una carga fue modificada.
        /// </summary>
        private bool fueModificada()
        {

            foreach (CartuchoMutilado cartucho in _cartuchos)
                if (cartucho.Cantidad_Asignada != cartucho.Cantidad_carga)
                    return true;

            return false;
        }


        /// <summary>
        /// Agregar un cartucho a la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a agregar</param>
        public void agregarCartucho(CartuchoMutilado cartucho)
        {
            _cartuchos.Add(cartucho);

            switch (cartucho.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _cantidad_asignada_colones += cartucho.Cantidad_Asignada;
                    _monto_asignado_colones += cartucho.Monto_asignado;
                    _monto_carga_colones += cartucho.Monto_carga;
                    break;
                case Monedas.Dolares:
                    _cantidad_asignada_dolares += cartucho.Cantidad_Asignada;
                    _monto_asignado_dolares += cartucho.Monto_asignado;
                    _monto_carga_dolares += cartucho.Monto_carga;
                    break;
                case Monedas.Euros:
                    _cantidad_asignada_euros += cartucho.Cantidad_Asignada;
                    _monto_asignado_euros += cartucho.Monto_asignado;
                    _monto_carga_euros += cartucho.Monto_carga;
                    break;
            }

            this.asignaCartuchoDenominacion(cartucho);
        }

        /// <summary>
        /// Quitar un cartucho de la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a quitar</param>
        public void quitarCartucho(CartuchoMutilado cartucho)
        {
            _cartuchos.Remove(cartucho);

            switch (cartucho.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _cartuchos_colones.Remove(cartucho);
                    _cantidad_asignada_colones -= cartucho.Cantidad_Asignada;
                    _monto_asignado_colones -= cartucho.Monto_asignado;
                    break;
                case Monedas.Dolares:
                    _cartuchos_dolares.Remove(cartucho);
                    _monto_asignado_dolares -= cartucho.Monto_asignado;
                    _cantidad_asignada_dolares -= cartucho.Cantidad_Asignada;
                    break;
                case Monedas.Euros:
                    _cartuchos_euros.Remove(cartucho);
                    _monto_asignado_euros -= cartucho.Monto_asignado;
                    _cantidad_asignada_euros -= cartucho.Cantidad_Asignada;
                    break;
            }

            _cartuchos_denominaciones[cartucho.Denominacion].Remove(cartucho);
        }

        #endregion Métodos Públicos


        #region Métodos Privados

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

            _cantidad_asignada_euros = 0;
            _monto_asignado_euros = 0;
            _monto_carga_euros = 0;

            foreach (CartuchoMutilado cartucho in _cartuchos)
            {

                switch (cartucho.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _cantidad_asignada_colones += cartucho.Cantidad_Asignada;
                        _monto_asignado_colones += cartucho.Monto_asignado;
                        _monto_carga_colones += cartucho.Monto_carga;
                        break;
                    case Monedas.Dolares:
                        _cantidad_asignada_dolares += cartucho.Cantidad_Asignada;
                        _monto_asignado_dolares += cartucho.Monto_asignado;
                        _monto_carga_dolares += cartucho.Monto_carga;
                        break;
                    case Monedas.Euros:
                        _cantidad_asignada_euros += cartucho.Cantidad_Asignada;
                        _monto_asignado_euros += cartucho.Monto_asignado;
                        _monto_carga_euros += cartucho.Monto_carga;
                        break;
                }
            }

        }

        /// <summary>
        /// Agregar un cartucho a las lista de cartuchos de su misma denominacion.
        /// </summary>
        /// <param name="cartucho">Cartucho que se agregará</param>
        private void asignaCartuchoDenominacion(CartuchoMutilado cartucho)
        {
            Denominacion denominacion = cartucho.Denominacion;

            if (_cartuchos_denominaciones.ContainsKey(denominacion))
            {
                _cartuchos_denominaciones[denominacion].Add(cartucho);
            }
            else
            {
                List<CartuchoMutilado> cartuchos = new List<CartuchoMutilado>();

                cartuchos.Add(cartucho);

                _cartuchos_denominaciones.Add(denominacion, cartuchos);
            }

        }

        #endregion Métodos Privados

        #region Overrides

        public override string ToString()
        {
            return _sucursal.ID.ToString();
        }
        

        #endregion Overrides

    }


}
    

