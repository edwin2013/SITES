using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public enum EstadosPedidoBanco : byte
    {
        Libre = 0,
        Asignada = 1,
        Terminada = 2,
        Pedido_Boveda = 3,
        Entrega_a_Boveda = 4,
        Importacion = 5,
        Exportacion = 6
    }
    
    public class PedidoBancos: MovimientoBanco
    {

        #region Atributos Privados

        protected Canal _canal;

        public Canal Canal
        {
            get { return _canal; }
            set { _canal = value; }
        }



        public string NombreCanal
        {
            get { return _canal.Nombre; }
        }
        protected byte? _emergencia;

        public byte? Emergencia
        {
            get { return _emergencia; }
            set { _emergencia = value; }
        }


        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        protected BindingList<ManifiestoPedidoBanco> _manifiesto;

        public BindingList<ManifiestoPedidoBanco> Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }


        protected EstadosPedidoBanco _estado;

        public EstadosPedidoBanco Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string EstadoBanco
        {
             get{
                 switch (Estado)
                 {
                     case EstadosPedidoBanco.Pedido_Boveda:
                         return "Venta";
                     case EstadosPedidoBanco.Entrega_a_Boveda:
                         return "Compra";
                     case EstadosPedidoBanco.Importacion:
                         return "Importación";
                     case EstadosPedidoBanco.Exportacion:
                         return "Exportación";
                     default:
                         return "nada";
                 }
             }
        }

        protected Tripulacion _tripulacion;

        public Tripulacion Tripulacion
        {
            set { _tripulacion = value; }
            get { return _tripulacion; }
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



        protected DateTime _fecha_pedido;

        public DateTime Fecha_pedido
        {
            get { return _fecha_pedido; }
            set { _fecha_pedido = value; }
        }



        protected DateTime _fecha_verificacion;

        public DateTime Fecha_verificacion
        {
            get { return _fecha_verificacion; }
            set { _fecha_verificacion = value; }
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

        protected Colaborador _colaborador_registro;

        public Colaborador Colaborador_Registro
        {
            get { return _colaborador_registro; }
            set { _colaborador_registro = value; }
        }

   
        public int Cantidad_denominaciones
        {
            get { return _bolsa_denominaciones.Keys.Count; }
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
            get { return _canal == null ? string.Empty : _canal.Nombre; }
        }

        protected double _cantidad_asignada_colones;

        public double Cantidad_asignada_colones
        {
            get { return _cantidad_asignada_colones; }
        }

        protected double _cantidad_asignada_dolares;

        public double Cantidad_asignada_dolares
        {
            get { return _cantidad_asignada_dolares; }
        }


        protected double _cantidad_asignada_euros;

        public double Cantidad_asignada_euros
        {
            get { return _cantidad_asignada_euros; }
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


        protected decimal _monto_asignado_euros;

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

        protected decimal _monto_carga_euros;

        public decimal Monto_carga_euros
        {
            get { return _monto_carga_euros; }
        }

        private Dictionary<Denominacion, List<BolsaCargaBanco>> _bolsa_denominaciones =
            new Dictionary<Denominacion, List<BolsaCargaBanco>>();


        protected string _numero_cuenta;
        public string Numero_Cuenta
        {
            set { _numero_cuenta = value; }
            get { return _numero_cuenta; }
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
            get { return ""; } //Manifiesto.Serie_Tula; }
        }

        protected Colaborador _colaborador_verificador;

        public Colaborador Colaborador_verificador
        {
            get { return _colaborador_verificador; }
            set { _colaborador_verificador = value; }
        }

        protected Decimal _monto_ganancia;
        public Decimal MontoGanancia
        {
            set { _monto_ganancia = value; }
            get { return _monto_ganancia; }
        }

        protected Decimal _monto_ganancia_Dolares;
        public Decimal MontoGananciaDolares
        {
            set { _monto_ganancia_Dolares = value; }
            get { return _monto_ganancia_Dolares; }
        }

        protected Decimal _monto_ganancia_Euros;
        public Decimal MontoGananciaEuros
        {
            set { _monto_ganancia_Euros = value; }
            get { return _monto_ganancia_Euros; }
        }

        protected BindingList<Tripulacion> _lista = new BindingList<Tripulacion>();
        public BindingList<Tripulacion> ListaTripulacion
        {

           
            set {
                _lista.Clear();
                _lista.Add(_tripulacion);
            }
            get
            {
               // _lista.Clear();
                _lista.Add(_tripulacion);
                return _lista;
            }
        }



        public String Unico
        {
            get { return "B" + ID.ToString(); }
        }

        protected CierreCargaBanco _cierre;
        public CierreCargaBanco Cierre
        {
            get { return _cierre; }
            set { _cierre = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public PedidoBancos(Canal canal = null,
                        byte? emergencia = null,
                        int id = 0,
                        Colaborador cajero = null,
                        Colaborador registrador = null,
                        Tripulacion tripulacion = null,
                        BindingList<ManifiestoPedidoBanco> manifiesto = null,
                        EmpresaTransporte transportadora = null,
                        DateTime? fecha_asignada = null,
                        DateTime? hora_inicio = null,
                        DateTime? hora_finalizacion = null,
                        DateTime? hora_entrada = null,
                        DateTime? hora_salida = null,
                        DateTime? hora_roadnet = null,
                        double distancia = 0,
                        int tiempoviaje = 0,
                        int tipocarga = 3,
                        DateTime? fecha_pedido = null,
                        DateTime? fecha_verificacion = null,
                        byte? ruta =null,
                        byte? orden_ruta = null,
                        string observaciones = "",
                        string numero_cuenta = "",
                        decimal monto_pedido_colones = 0,
                        decimal monto_pedido_dolares = 0,
                        decimal monto_pedido_euros =0,
                        EstadosPedidoBanco estado = 0,
                        decimal ganancia = 0,
                        decimal gananciaDolares = 0,
                        decimal gananciaEuros = 0)
        {
            this.DB_ID = id;
            this.Cajero = cajero;
            this.Colaborador_Registro = registrador;
            this.Hora_inicio = hora_inicio ?? DateTime.Now;
            this.Hora_finalizacion = hora_finalizacion ?? DateTime.Now;
            this.Observaciones = observaciones;
            this.Numero_Cuenta = _numero_cuenta;
            this.Fecha_pedido = fecha_pedido ?? DateTime.Now;
            this.Fecha_verificacion = fecha_verificacion ?? DateTime.Now;
            _canal = canal;
            _emergencia = emergencia;
            _manifiesto = manifiesto;
            _transportadora = transportadora;
            _fecha_asignada = fecha_asignada ?? DateTime.Now;
            _ruta = ruta ?? 0;
            _orden_ruta = orden_ruta;
            _monto_pedido_colones = monto_pedido_colones;
            _monto_pedido_dolares = monto_pedido_dolares;
            _monto_pedido_euros = monto_pedido_euros;
            _estado = estado;
            _tripulacion = tripulacion;
            _monto_ganancia = ganancia;
            _monto_ganancia_Dolares = gananciaDolares;
            _monto_ganancia_Euros = gananciaEuros;

            _hora_programada_roadnet = hora_roadnet ?? DateTime.Now;
            _distancia = distancia;
            _tiempo_viaje = tiempoviaje;
            _hora_entrada = hora_entrada ?? DateTime.Now;
            _hora_salida = hora_salida ?? DateTime.Now;
            _tipocarga = tipocarga;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un cartucho a la carga.
        /// </summary>
        /// <param name="bolsa">Cartucho a agregar</param>
        public void agregarCartucho(BolsaCargaBanco bolsa)
        {
            _bolsas.Add(bolsa); 

            switch (bolsa.Denominacion.Moneda)
            {
                case Monedas.Colones:

                    _cantidad_asignada_colones += bolsa.Cantidad_asignada;
                    _monto_asignado_colones += bolsa.Monto_asignado;
                    _monto_carga_colones += bolsa.Monto_carga;
                    break;
                case Monedas.Dolares:
                    _cantidad_asignada_dolares += bolsa.Cantidad_asignada;
                    _monto_asignado_dolares += bolsa.Monto_asignado;
                    _monto_carga_dolares += bolsa.Monto_carga;
                    break;
                case Monedas.Euros:
                    _cantidad_asignada_euros += bolsa.Cantidad_asignada;
                    _monto_asignado_euros += bolsa.Monto_asignado;
                    _monto_carga_euros += bolsa.Monto_carga;
                    break;
            }

            this.asignaCartuchoDenominacion(bolsa);
        }

        /// <summary>
        /// Quitar un cartucho de la carga.
        /// </summary>
        /// <param name="bolsa">Cartucho a quitar</param>
        public void quitarCartucho(BolsaCargaBanco bolsa)
        {
            _bolsas.Remove(bolsa);

            switch (bolsa.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _bolsas_colones.Remove(bolsa);
                    _cantidad_asignada_colones -= bolsa.Cantidad_asignada;
                    _monto_asignado_colones -= bolsa.Monto_asignado;
                    _monto_carga_colones -= bolsa.Monto_carga;
                    break;
                case Monedas.Dolares:
                    _bolsas_dolares.Remove(bolsa);
                    _monto_asignado_dolares -= bolsa.Monto_asignado;
                    _cantidad_asignada_dolares -= bolsa.Cantidad_asignada;
                    _monto_carga_dolares -= bolsa.Monto_carga;
                    break;
                case Monedas.Euros:
                    _bolsas_euros.Remove(bolsa);
                    _monto_asignado_euros -= bolsa.Monto_asignado;
                    _cantidad_asignada_euros -= bolsa.Cantidad_asignada;
                    _monto_carga_euros -= bolsa.Monto_carga;
                    break;
            }

            _bolsa_denominaciones[bolsa.Denominacion].Remove(bolsa);
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

            _cantidad_asignada_euros = 0;
            _monto_asignado_euros = 0;
            _monto_carga_euros = 0;

            foreach (BolsaCargaBanco cartucho in _bolsas)
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
                    case Monedas.Euros:
                        _cantidad_asignada_euros += cartucho.Cantidad_asignada;
                        _monto_asignado_euros += cartucho.Monto_asignado;
                        _monto_carga_euros += cartucho.Monto_carga;
                        break;
                }

            }

        }


        /// <summary>
        /// Agrega un manifiesto al pedido
        /// </summary>
        /// <param name="man">Objeto ManifiestoPedidoBanco con los datos del Manfiesto</param>
        public void agregarManifiesto(ManifiestoPedidoBanco man)
        {
            this.Manifiesto.Add(man);
        }


        /// <summary>
        /// Quita un manifiesto de la lista de manifiestos
        /// </summary>
        /// <param name="man">Objeto ManifiestoPedidoBanco con los datos del manifiesto</param>
        public void quitarManifiesto(ManifiestoPedidoBanco man)
        {
            this.Manifiesto.Remove(man);
        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Validar si una carga está lista.
        /// </summary>
        private bool estaLista()
        {

            foreach (BolsaCargaBanco bolsa in _bolsas)
                if (bolsa.estaPendiente()) return false;

            return true;
        }

        /// <summary>
        /// Validar si una carga fue modificada.
        /// </summary>
        private bool fueModificada()
        {

            foreach (BolsaCargaBanco cartucho in _bolsas)
                if (cartucho.Cantidad_asignada != cartucho.Cantidad_carga)
                    return true;

            return false;
        }

        /// <summary>
        /// Agregar un cartucho a las lista de cartuchos de su misma denominacion.
        /// </summary>
        /// <param name="bolsa">Cartucho que se agregará</param>
        private void asignaCartuchoDenominacion(BolsaCargaBanco bolsa)
        {
            Denominacion denominacion = bolsa.Denominacion;

            if (_bolsa_denominaciones.ContainsKey(denominacion))
            {
                _bolsa_denominaciones[denominacion].Add(bolsa);
            }
            else
            {
                List<BolsaCargaBanco> bolsas = new List<BolsaCargaBanco>();

                bolsas.Add(bolsa);

                _bolsa_denominaciones.Add(denominacion, bolsas);
            }

        }

        #endregion Métodos Privados

        #region Overrides

        public override string ToString()
        {
            if (_canal == null)
                return "E" + _emergencia;
            else
                return _canal.Id.ToString();
        }

        #endregion Overrides
    }
}
