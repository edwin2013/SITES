using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class CargaTransportadora : MovimientoTransportadora
    {
        #region Atributos Privados


        protected int _id;

        public int ID
        {
            get { return _id; }
            set {_id = value; }
        }


        protected String _nombre;

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        protected String _dato;

        public String Dato
        {
            set { _dato = value; }
            get { return _dato; }
        }


        protected Sucursal _sucursal;

        public Sucursal Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }

        protected byte? _emergencia;

        public byte? Emergencia
        {
            get { return _emergencia; }
            set { _emergencia = value; }
        }


        protected Tripulacion _tripulacion;
        public Tripulacion Tripulacion
        {
            get { return _tripulacion; }
            set { _tripulacion = value; }
        }

        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        protected BindingList<ManfiestoTransportadoraCarga> _manifiesto;

        public BindingList<ManfiestoTransportadoraCarga> Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }


        protected EstadoAprobacionCargas _estado_aprobadas;

        public EstadoAprobacionCargas EstadoAprobadas
        {
            get { return _estado_aprobadas; }
            set { _estado_aprobadas = value; }
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

             
        protected Colaborador _colaborador_verificador;

        public Colaborador Colaborador_verificador
        {
            get { return _colaborador_verificador; }
            set { _colaborador_verificador = value; }
        }


        protected Colaborador _colaborador_verificador_transportadora;

        public Colaborador ColaboradorVerificadorTransportadora
        {
            get { return _colaborador_verificador_transportadora; }
            set { _colaborador_verificador_transportadora = value; }
        }

        protected int _id_bolsa;
        public int IdBolsa
        {
            get { return _id_bolsa; }
            set { _id_bolsa = value; }
        }

        protected Colaborador _colaborador_registro;

        public Colaborador Colaborador_Registro
        {
            get { return _colaborador_registro; }
            set { _colaborador_registro = value; }
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
            get { return _colaborador_verificador != null; }
        }

        public bool Tiene_atm
        {
            get { return _sucursal != null; }
        }

        public bool Es_Emergencia
        {
            get { return _sucursal == null; }
        }

        public string Codigo
        {
            get { return _sucursal == null ? "E" + _emergencia : _sucursal.Nombre; }
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
        private Dictionary<Denominacion, List<CartuchoCargaTransportadora>> _cartuchos_denominaciones =
            new Dictionary<Denominacion, List<CartuchoCargaTransportadora>>();


        protected string _numero_cuenta;
        public string Numero_Cuenta
        {
            set { _numero_cuenta = value; }
            get { return _numero_cuenta; }
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



        protected String _comentario_rechazo;

        public String Comentacio_Rechazo
        {
            get { return _comentario_rechazo; }
            set { _comentario_rechazo = value; }
        }


        protected EntregaRecibo _entregabovedasucursal;
        public EntregaRecibo EntregaBovedaSucursal
        {
            get { return _entregabovedasucursal; }
            set { _entregabovedasucursal = value; }
        }

        protected String _comentario_eliminacion;

        public String Comentario_Eliminacion
        {
            get { return _comentario_eliminacion; }
            set { _comentario_eliminacion = value; }
        }

        public String Unico
        {
            get { return "S" + ID.ToString(); }
        }

        public String NombreTransportadora
        {
            get { return _transportadora.ToString(); }
        }
        
        protected bool _mutilado;
        private float distancia;
        private DateTime hora_programada;
        private int tiempoviaje;
        private byte ruta;
        private byte orden_ruta;
        private CommonObjects.TipoEntregas estado;
        private int ena;
        public bool Mutilado
        {
            get { return _mutilado; }
            set { _mutilado = value; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public CargaTransportadora(
                        byte? emergencia = null,
                        int id = 0,
                        Colaborador cajero = null,
                        Colaborador verificador = null,
                        Colaborador registrador = null,
                        BindingList<ManfiestoTransportadoraCarga> manifiesto = null,
                        EmpresaTransporte transportadora = null,
                        CierreCargaTransportadora cierre = null,
                        DateTime? fecha_asignada = null,
                        DateTime? hora_inicio = null,
                        DateTime? hora_finalizacion = null,
                        DateTime? hora_programada = null,
                        DateTime? hora_entrada = null,
                        DateTime? hora_salida = null,
                        DateTime? hora_roadnet = null,
                        double distancia = 0,
                        int tiempoviaje = 0,
                        int tipocarga = 2,
                        byte? ruta =null,
                        byte? orden_ruta = null,
                        bool cartucho_rechazo = false,
                        bool ena = false,
                        string observaciones = "",
                        string numero_cuenta = "",
                        decimal monto_pedido_colones = 0,
                        decimal monto_pedido_dolares = 0,
                        decimal monto_pedido_euros =0,
                        EstadosCargasSucursales estado = 0,
                        string dato = "",
                        string nombre =""
                        )
        {
            this.DB_ID = id;
            this.ID = id;
            this.Cajero = cajero;
            this.Colaborador_Registro = registrador;
            this.Colaborador_verificador = verificador;
            this.Hora_inicio = hora_inicio ?? DateTime.Now;
            this.Hora_finalizacion = hora_finalizacion ?? DateTime.Now;
            this.Observaciones = observaciones;
            this.Numero_Cuenta = _numero_cuenta;
            this.Cierre = cierre;
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

            _hora_programada_roadnet = hora_roadnet ?? DateTime.Now;
            _distancia = distancia;
            _tiempo_viaje = tiempoviaje;
            _hora_entrada = hora_entrada ?? DateTime.Now;
            _hora_salida = hora_salida ?? DateTime.Now;
            _tipocarga = tipocarga;
            _dato = dato;
            _nombre = nombre;
        }

        public CargaTransportadora(CommonObjects.Sucursal sucursal, byte? emergencia, int id, EmpresaTransporte transportadora, byte? ruta, byte? orden_ruta, float distancia, DateTime hora_programada, int tiempoviaje, bool mutilado)
        {
            // TODO: Complete member initialization
            this.Sucursal = sucursal;
            this.Emergencia = emergencia;
            this.ID = id;
            this.Transportadora = transportadora;
            this.Ruta = ruta;
            this.Orden_ruta = orden_ruta;
            this.distancia = distancia;
            this.hora_programada = hora_programada;
            this.tiempoviaje = tiempoviaje;
            this.Mutilado = mutilado;
            this.DB_ID = id;
            
        }

        public CargaTransportadora(int id, Colaborador cajero, byte ruta, byte orden_ruta, DateTime fecha_verificacion, EstadosCargasSucursales estado, string nombre, string dato)
        {
            // TODO: Complete member initialization
            this.ID = id;
            this.Cajero = cajero;
            this.ruta = ruta;
            this.orden_ruta = orden_ruta;
            this.Fecha_verificacion = fecha_verificacion;
            this.Estado = estado;
            this.Nombre = nombre;
            this.Dato = dato;
        }




  

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un cartucho a la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a agregar</param>
        public void agregarCartucho(CartuchoCargaTransportadora cartucho)
        {
            _cartuchos.Add(cartucho); 

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

            this.asignaCartuchoDenominacion(cartucho);
        }

        /// <summary>
        /// Quitar un cartucho de la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a quitar</param>
        public void quitarCartucho(CartuchoCargaTransportadora cartucho)
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
                case Monedas.Euros:
                    _cartuchos_euros.Remove(cartucho);
                    _monto_asignado_euros -= cartucho.Monto_asignado;
                    _cantidad_asignada_euros -= cartucho.Cantidad_asignada;
                    _monto_carga_euros -= cartucho.Monto_carga;
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

            _cantidad_asignada_euros = 0;
            _monto_asignado_euros = 0;
            _monto_carga_euros = 0;

            foreach (CartuchoCargaTransportadora cartucho in _cartuchos)
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
        /// Agrega un manifiesto a la lista de manifiestos
        /// </summary>
        /// <param name="m">Objeto ManfiestoTransportadoraCarga con los datos del manifiesto</param>
        public void agregarManifiesto(ManfiestoTransportadoraCarga m)
        {
            _manifiesto.Add(m);
        }

        /// <summary>
        /// Quita un manifiesto de la lista de manifiestos
        /// </summary>
        /// <param name="m">Objeto ManfiestoTransportadoraCarga con los datos del manifiesto a remover</param>
        public void quitarManifiesto(ManfiestoTransportadoraCarga m)
        {
            _manifiesto.Remove(m);
        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Validar si una carga está lista.
        /// </summary>
        private bool estaLista()
        {

            foreach (CartuchoCargaTransportadora cartucho in _cartuchos)
                if (cartucho.estaPendiente()) return false;

            return true;
        }

        /// <summary>
        /// Validar si una carga fue modificada.
        /// </summary>
        private bool fueModificada()
        {

            foreach (CartuchoCargaTransportadora cartucho in _cartuchos)
                if (cartucho.Cantidad_asignada != cartucho.Cantidad_carga)
                    return true;

            return false;
        }




        /// <summary>
        /// Agregar un cartucho a las lista de cartuchos de su misma denominacion.
        /// </summary>
        /// <param name="cartucho">Cartucho que se agregará</param>
        private void asignaCartuchoDenominacion(CartuchoCargaTransportadora cartucho)
        {
            Denominacion denominacion = cartucho.Denominacion;

            if (_cartuchos_denominaciones.ContainsKey(denominacion))
            {
                _cartuchos_denominaciones[denominacion].Add(cartucho);
            }
            else
            {
                List<CartuchoCargaTransportadora> cartuchos = new List<CartuchoCargaTransportadora>();

                cartuchos.Add(cartucho);

                _cartuchos_denominaciones.Add(denominacion, cartuchos);
            }

        }

        #endregion Métodos Privados

        #region Overrides

        public override string ToString()
        {
            if (_sucursal == null)
                return "E" + _emergencia;
            else
                return _sucursal.ID.ToString();
        }

        #endregion Overrides
    }
}
