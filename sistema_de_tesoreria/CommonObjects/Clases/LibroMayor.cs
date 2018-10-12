using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public enum TipoClaseLibroMayorEntregas :int
    {
        Sucursales = 1,
        ATM_Descargas = 2,
        BNA_Proval = 3,
        Entregas_CEF = 4,
        Cambio_Denominacion = 5,
        Diferencias = 6,
        BPS = 7,
        BPS_Validacion = 8,
        Entrega_Niquel = 9,
        Bancos = 10,
        CAN = 11,
        Total = 12 ,
     
         //NIQUEL
        CEF1 = 13,
        CEF2 = 14, 
        CEF3 = 15, 
        CEF4 = 16,
        CEF5 = 17,
        BANCO1 = 18,
        BANCO2 = 19,
        BANCO3 = 20,
        BANCO4 = 21,
        BANCO5 = 22,
        BANCO6 = 23,
        BANCO7 = 24,
        BANCO8 = 25,
        Pedido_Boveda = 26,
        Pedidos_Varios = 27,
        Cambio_Denominacion1 = 28,
        Cambio_Denominacion2 = 29,
        Cambio_Denominacion3 = 30,
        ColaCEF = 31,
        SucursalesManual = 32

    }


    public enum TipoClaseLibroMayorPedidos :int
    {
        ATM_Proval = 1,
        ATM_G4S= 2,
        Niquel = 3, 
        Cambio_Denominacion = 4, 
        Digitacion =5,
        Validacion = 6,
        Otros = 7,
        Exportacion =8,
        Bancos = 9,
        CAN = 10,
        ATM_Banco = 11, 
        Sucursales = 12,
        ATM_Banco_Adicional = 13,
        ATM_Dunbar = 14,
        FaltanteGeneral = 15,
        FaltanteCEF = 16,
        PedidosVarios = 17,
        PedidosClientes = 18,
        cambio_denominacion1 = 19,
        cambio_denominacion2 = 20, 
        SucursalesManual = 21
        
    }
    public class LibroMayor: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }


        protected decimal _50000_colones;
        public decimal Monto50000Colones
        {
            get { return _50000_colones; }
            set { _50000_colones = value; }
        }

        protected decimal _20000_colones;
        public decimal Monto20000Colones 
        {
            get { return _20000_colones; }
            set { _20000_colones = value; }
        }

        protected decimal _10000_colones;
        public decimal Monto10000Colones
        {
            get { return _10000_colones; }
            set { _10000_colones = value; }
        }

        protected decimal _5000_colones;
        public decimal Monto5000Colones
        {
            get { return _5000_colones; }
            set { _5000_colones = value; }
        }

        protected decimal _2000_colones;
        public decimal Monto2000Colones
        {
            get { return _2000_colones; }
            set { _2000_colones = value; }
        }

        protected decimal _1000_colones;
        public decimal Monto1000Colones
        {
            get { return _1000_colones; }
            set { _1000_colones = value; }
        }

        protected decimal _500_colones;
        public decimal Monto500Colones
        {
            get { return _500_colones; }
            set { _500_colones = value; }
        }

        protected decimal _100_colones;
        public decimal Monto100Colones
        {
            get { return _100_colones; }
            set { _100_colones = value; }
        }

        protected decimal _50_colones;
        public decimal Monto50Colones
        {
            get { return _50_colones; }
            set { _50_colones = value; }
        }


        protected decimal _25_colones;
        public decimal Monto25Colones
        {
            get { return _25_colones; }
            set { _25_colones = value; }
        }

        protected decimal _10_colones;
        public decimal Monto10Colones
        {
            get { return _10_colones; }
            set { _10_colones = value; }
        }

        protected decimal _5_colones;
        public decimal Monto5Colones
        {
            get { return _5_colones; }
            set { _5_colones = value; }
        }




        protected decimal _100_dolares;
        public decimal Monto100Dolares
        {
            get { return _100_dolares; }
            set { _100_dolares = value; }
        }


        protected decimal _50_dolares;
        public decimal Monto50Dolares
        {
            get { return _50_dolares; }
            set { _50_dolares = value; }
        }


        protected decimal _20_dolares;
        public decimal Monto20Dolares
        {
            get { return _20_dolares; }
            set { _20_dolares = value; }
        }


        protected decimal _10_dolares;
        public decimal Monto10Dolares
        {
            get { return _10_dolares; }
            set { _10_dolares = value; }
        }


        protected decimal _5_dolares;
        public decimal Monto5Dolares
        {
            get { return _5_dolares; }
            set { _5_dolares = value; }
        }



        protected decimal _2_dolares;
        public decimal Monto2Dolares
        {
            get { return _2_dolares; }
            set { _2_dolares = value; }
        }


        protected decimal _1_dolares;
        public decimal Monto1Dolares
        {
            get { return _1_dolares; }
            set { _1_dolares = value; }
        }




        protected decimal _500_euros;
        public decimal Monto500Euros
        {
            get { return _500_euros; }
            set { _500_euros = value; }
        }

        protected decimal _200_euros;
        public decimal Monto200Euros
        {
            get { return _200_euros; }
            set { _200_euros = value; }
        }

        protected decimal _100_euros;
        public decimal Monto100Euros
        {
            get { return _100_euros; }
            set { _100_euros = value; }
        }


        protected decimal _50_euros;
        public decimal Monto50Euros
        {
            get { return _50_euros; }
            set { _50_euros = value; }
        }

        protected decimal _20_euros;
        public decimal Monto20Euros
        {
            get { return _20_euros; }
            set { _20_euros = value; }
        }


        protected decimal _10_euros;
        public decimal Monto10Euros
        {
            get { return _10_euros; }
            set { _10_euros = value; }
        }



        protected decimal _5_euros;
        public decimal Monto5Euros
        {
            get { return _5_euros; }
            set { _5_euros = value; }
        }

       

        protected Colaborador _colaborador_registro;

        public Colaborador ColaboradoRegistro
        {
            get { return _colaborador_registro; }
            set { _colaborador_registro = value; }
        }


        protected string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }



        protected TipoClaseLibroMayorEntregas _tipo_libro_entregas;
        public TipoClaseLibroMayorEntregas TipoLibroEntregas
        {
            set { _tipo_libro_entregas = value; }
            get { return _tipo_libro_entregas; }
        }



        protected TipoClaseLibroMayorPedidos _tipo_libro_pedido;
        public TipoClaseLibroMayorPedidos TipoLibroPedido
        {
            set { _tipo_libro_pedido = value; }
            get { return _tipo_libro_pedido; }
        }

        protected Decimal _mutilado;
        public Decimal Mutilado
        {
            set { _mutilado = value; }
            get { return _mutilado; }
        }

        protected Decimal _cola;
        public Decimal Cola
        {
            set { _cola = value; }
            get { return _cola;  }
        }


        protected string _codigo;
        public string Codigo
        {
            set { _codigo = value; }
            get { return _codigo; }
        }



        protected Decimal _mutilado_dolares;
        public Decimal MutiladoDolares
        {
            set { _mutilado_dolares = value; }
            get { return _mutilado_dolares; }
        }

        protected Decimal _cola_dolares;
        public Decimal ColaDolares
        {
            set { _cola_dolares = value; }
            get { return _cola_dolares; }
        }



        protected Decimal _mutilado_euros;
        public Decimal MutiladoEuros
        {
            set { _mutilado_euros = value; }
            get { return _mutilado_euros; }
        }

        protected Decimal _cola_euros;
        public Decimal ColaEuros
        {
            set { _cola_euros = value; }
            get { return _cola_euros; }
        }

        
        public Decimal TotalColones
        {
           get { 
               return _10_colones + _100_colones + _1000_colones +_10000_colones +_25_colones +_2000_colones +_20000_colones +_5_colones + _50_colones + _500_colones +_5000_colones + _50000_colones + _cola + _mutilado;
           }
        }

        public Decimal TotalDolares
        {
            get
            {
                return _1_dolares + _10_dolares + _100_dolares + _2_dolares + _20_dolares + _5_dolares + _50_dolares + _cola_dolares + _mutilado_dolares;
            }
        }

        public Decimal TotalEuros
        {
            get
            {
                return _10_euros + _100_euros + _20_euros + _200_euros + _5_euros + _50_euros + _500_euros + _cola_euros + _mutilado_euros;
            }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public LibroMayor(int id = 0,decimal monto50000colones = 0, decimal monto20000colones = 0, decimal monto10000colones = 0, decimal monto5000colones = 0, decimal monto2000colones = 0, 
            decimal monto1000colones = 0, decimal monto500colones = 0, decimal monto100colones = 0, decimal monto50colones = 0, decimal monto25colones = 0,
            decimal monto10colones = 0, decimal monto5colones = 0, decimal monto100dolares = 0, decimal monto50dolares = 0, decimal monto20dolares = 0, decimal monto10dolares = 0,
            decimal monto5dolares = 0, decimal monto2dolares = 0, decimal monto1dolares = 0,
            decimal monto500euros = 0, decimal monto200euros = 0, decimal monto100euros = 0, decimal monto50euros = 0, decimal monto20euros = 0, decimal monto10euros = 0, decimal monto5euros = 0
            , DateTime? fecha_asignada = null, Colaborador colaborador = null, string observaciones = "", TipoClaseLibroMayorPedidos tipopedido = 0, TipoClaseLibroMayorEntregas tipoentrega = 0, string codigo = "",
            decimal mutilado=0, decimal cola = 0, decimal mutiladodolares = 0, decimal coladolares = 0, decimal mutiladoeuros = 0, decimal colaeuros = 0)
        {

            _fecha = fecha_asignada ?? DateTime.Now;
            _colaborador_registro = colaborador;
            _observaciones = observaciones;

            _mutilado = mutilado;
            _cola = cola;

            _mutilado_dolares = mutiladodolares;
            _cola_dolares = mutiladodolares;

            _mutilado_euros = mutiladoeuros;
            _cola_euros = colaeuros;

            this.DB_ID = id;

            this._50000_colones = monto50000colones;
            this._20000_colones = monto20000colones;
            this._10000_colones = monto10000colones;
            this._5000_colones = monto5000colones;
            this._2000_colones = monto2000colones;
            this._1000_colones = monto1000colones;
            this._500_colones = monto500colones;
            this._100_colones = monto100colones;
            this._50_colones = monto50colones;
            this._25_colones = monto25colones;
            this._10_colones = monto10colones;
            this._5_colones = monto5colones;


            this._100_dolares = monto100dolares;
            this._50_dolares = monto50dolares;
            this._20_dolares = monto20dolares;
            this._10_dolares = monto10dolares;
            this._5_dolares = monto5dolares;
            this._2_dolares = monto2dolares;
            this._1_dolares = monto1dolares;

            this._500_euros = monto500euros;
            this._200_euros = monto200euros;
            this._100_euros = monto100euros;
            this._50_euros = monto50euros;
            this._20_euros = monto20euros;
            this._10_euros = monto10euros;
            this._5_euros = monto5euros;


            this._tipo_libro_entregas = tipoentrega;
            this._tipo_libro_pedido = tipopedido;

            this._codigo = codigo;
           
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        
        #endregion Métodos Públicos

        #region Overrides

       

        #endregion Overrides
    }
}
