using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{

    public enum TipoPuntoAtencion : short
    {
        ATM = 1,
        Sucursal = 2,
        Banco = 3,
        Cliente = 4,

    }

    public class PuntoAtencion : ObjetoIndexado
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        private TipoPuntoAtencion _punto_atencion;
        private short id;

        public TipoPuntoAtencion TipoPuntodeAtencion
        {
            get { return _punto_atencion; }
            set { _punto_atencion = value; }
        }


        private EmpresaTransporte _transportadora;
        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }



        protected decimal _tarifa_regular;
        public decimal TarifaRegular
        {
            get { return _tarifa_regular; }
            set { _tarifa_regular = value; }
        }



        protected decimal _tarifa_feriado;
        public decimal TarifaFeriado
        {
            get { return _tarifa_feriado; }
            set { _tarifa_feriado = value; }
        }

        protected decimal _recargo;
        public decimal Recargo
        {
            get { return _recargo; }
            set { _recargo = value; }
        }


        protected decimal _tope;
        public decimal Tope
        {
            get { return _tope; }
            set { _tope = value; }
        }


        protected decimal _monto_planilla;
        public decimal MontoPlanilla
        {
            get { return _monto_planilla; }
            set { _monto_planilla = value; }
        }


        protected decimal _total_cobrar;
        public decimal TotalCobrar
        {
            get { return _total_cobrar; }
            set { _total_cobrar = value; }
        }


        protected decimal _entrega_niquel;
        public decimal EntregaNiquel
        {
            get { return _entrega_niquel; }
            set { _entrega_niquel = value; }
        }


        protected decimal _tarifa_reporte;
        public decimal Tarifa_Reporte
        {
            get { return _tarifa_reporte; }
            set { _tarifa_reporte = value; }
        }

        protected string _centro_costos;
        public string CentroCostos
        {
            get { return _centro_costos; }
            set { _centro_costos = value; }
        }

        protected Monedas _moneda_tarifa_regular;
        public Monedas MonedaTarifaRegular
        {
            get { return _moneda_tarifa_regular; }
            set { _moneda_tarifa_regular = value; }
        }
        protected Monedas _moneda_tarifa_feriados;
        public Monedas MonedaTarifaFeriados
        {
            get { return _moneda_tarifa_feriados; }
            set { _moneda_tarifa_feriados = value; }
        }


        protected Monedas _moneda_tope;
        public Monedas MonedaTope
        {
            get { return _moneda_tope; }
            set { _moneda_tope = value; }
        }


        protected Monedas _moneda_entrega_niquel;
        public Monedas MonedaEntregaNiquel
        {
            get { return _moneda_entrega_niquel; }
            set { _moneda_entrega_niquel = value; }
        }

        protected Monedas _moneda_recargo;
        public Monedas MonedaRecargo
        {
            get { return _moneda_recargo; }
            set { _moneda_recargo = value; }
        }


        protected DateTime _fecha_planilla;
        public DateTime FechaPlanilla
        {
            get { return _fecha_planilla; }
            set { _fecha_planilla = value; }
        }


        protected string _manifiesto;

        public string Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }



        protected string _tula;

        public string Tula
        {
            get { return _tula; }
            set { _tula = value; }
        }

        protected int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }


        protected int _id_sites;
        public int IDSites
        {
            get { return _id_sites; }
            set { _id_sites = value; }
        }


        protected int _id_pedido;
        public int IDPedido
        {
            get { return _id_pedido; }
            set { _id_pedido = value; }
        }

        protected int _id_punto;
        public int IDPunto
        {
            get { return _id_punto; }
            set { _id_punto = value; }
        }

        protected EntregaRecibo _entrega_recibo;
        public EntregaRecibo EntregaRecibo
        {
            get { return _entrega_recibo; }
            set { _entrega_recibo = value; }
        }

        protected bool _visita_compartida;
        public bool VisitaCompartida
        {
            get { return _visita_compartida; }
            set { _visita_compartida = value; }
        }

        public int _visita_noctura;
        public int VisitaNocturna
        {
            get { return _visita_noctura; }
            set { _visita_noctura = value; }
        }


        protected Decimal _monto_excedente;
        public Decimal MontoExcedente
        {
            get { return _monto_excedente; }
            set { _monto_excedente = value; }
        }


        protected Decimal _tipo_cuenta;
        public Decimal TipoCambio
        {
            get { return _tipo_cuenta; }
            set { _tipo_cuenta = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public PuntoAtencion(int id, string nombre, TipoPuntoAtencion tipo = 0)
        {
            _id = id;
            _nombre = nombre;
            _punto_atencion = tipo;
        }

        public PuntoAtencion(string nombre)
        {
            _nombre = nombre;
        }

        public PuntoAtencion() { }

        public PuntoAtencion(short id, string nombre)
        {
            // TODO: Complete member initialization
            _id = id;
            this.Nombre = nombre;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            PuntoAtencion canal = (PuntoAtencion)obj;

            if (_id != canal.Id) return false;

            return true;
        }

        #endregion Overrides

    }
}
