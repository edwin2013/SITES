using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class CierreCargasATMs : ObjetoIndexado
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


        protected decimal _libros_colones;
        public decimal LibrosColones
        {
            get { return _libros_colones; }
            set { _libros_colones = value; }
        }


        protected decimal _libros_dolares;
        public decimal LibrosDolares
        {
            get { return _libros_dolares; }
            set { _libros_dolares = value; }
        }
       
        protected decimal _saldo_anterior_colones;

        public decimal Saldo_AnteriorColones
        {
            get { return _saldo_anterior_colones; }
            set { _saldo_anterior_colones = value; }
        }




        protected decimal _saldo_anterior_dolares;

        public decimal Saldo_AnteriorDolares
        {
            get { return _saldo_anterior_dolares; }
            set { _saldo_anterior_dolares = value; }
        }

        protected decimal _pedido_boveda_colones;

        public decimal PedidoBovedaColones
        {
            get { return _pedido_boveda_colones; }
            set { _pedido_boveda_colones = value; }
        }


        protected decimal _pedido_boveda_dolares;

        public decimal PedidoBovedaDolares
        {
            get { return _pedido_boveda_dolares; }
            set { _pedido_boveda_dolares = value; }
        }

        protected decimal _descarga_atms_colones;

        public decimal DescargaATMsColones
        {
            get { return _descarga_atms_colones; }
            set { _descarga_atms_colones = value; }
        }


        protected decimal _descarga_atms_dolares;

        public decimal DescargaATMsDolares
        {
            get { return _descarga_atms_dolares; }
            set { _descarga_atms_dolares = value; }
        }




        protected decimal _pedido_boveda_adicional_colones;

        public decimal PedidoBovedaAdicionalColones
        {
            get { return _pedido_boveda_adicional_colones; }
            set { _pedido_boveda_adicional_colones = value; }
        }



        protected decimal _pedido_boveda_adicional_dolares;

        public decimal PedidoBovedaAdicionalDolares
        {
            get { return _pedido_boveda_adicional_dolares; }
            set { _pedido_boveda_adicional_dolares = value; }
        }


        protected decimal _descarga_completa_colones;

        public decimal DescargaCompletaColones
        {
            get { return _descarga_completa_colones; }
            set { _descarga_completa_colones = value; }
        }



        protected decimal _descarga_completa_dolares;

        public decimal DescargaCompletaDolares
        {
            get { return _descarga_completa_dolares; }
            set { _descarga_completa_dolares = value; }
        }


        protected decimal _devolucion_atms_colones;

        public decimal DevolucionATMsColones
        {
            get { return _devolucion_atms_colones; }
            set { _devolucion_atms_colones = value; }
        }



        protected decimal _devolucion_atms_dolares;

        public decimal DevolucionATMsDolares
        {
            get { return _devolucion_atms_dolares; }
            set { _devolucion_atms_dolares = value; }
        }

        protected decimal _devolucion_emergencias_colones;

        public decimal DevolucionEmergenciasColones
        {
            get { return _devolucion_emergencias_colones; }
            set { _devolucion_emergencias_colones = value; }
        }


        protected decimal _devolucion_emergencias_dolares;

        public decimal DevolucionEmergenciasDolares
        {
            get { return _devolucion_emergencias_dolares; }
            set { _devolucion_emergencias_dolares = value; }
        }

        protected decimal _entrega_boveda_colones;

        public decimal EntregaBovedaColones
        {
            get { return _entrega_boveda_colones; }
            set { _entrega_boveda_colones = value; }
        }



        protected decimal _entrega_boveda_dolares;

        public decimal EntregaBovedaDolares
        {
            get { return _entrega_boveda_dolares; }
            set { _entrega_boveda_dolares = value; }
        }



        protected decimal _cargas_emergencia_colones;

        public decimal CargasEmergenciaColones
        {
            get { return _cargas_emergencia_colones; }
            set { _cargas_emergencia_colones = value; }
        }



        protected decimal _cargas_emergencia_dolares;

        public decimal CargasEmergenciaDolares
        {
            get { return _cargas_emergencia_dolares; }
            set { _cargas_emergencia_dolares = value; }
        }



        protected decimal _cargas_atms_colones;

        public decimal CargasATMsColones
        {
            get { return _cargas_atms_colones; }
            set { _cargas_atms_colones = value; }
        }


        protected decimal _cargas_atms_dolares;

        public decimal CargasATMsDolares
        {
            get { return _cargas_atms_dolares; }
            set { _cargas_atms_dolares = value; }
        }

        protected decimal _saldo_cola_20000;

        public decimal SaldoCola20000
        {
            get { return _saldo_cola_20000; }
            set { _saldo_cola_20000 = value; }
        }


        protected decimal _saldo_cola_10000;

        public decimal SaldoCola10000
        {
            get { return _saldo_cola_10000; }
            set { _saldo_cola_10000 = value; }
        }



        protected decimal _saldo_cola_5000;

        public decimal SaldoCola5000
        {
            get { return _saldo_cola_5000; }
            set { _saldo_cola_5000 = value; }
        }



        protected decimal _saldo_cola_2000;

        public decimal SaldoCola2000
        {
            get { return _saldo_cola_2000; }
            set { _saldo_cola_2000 = value; }
        }



        protected decimal _saldo_cola_1000;

        public decimal SaldoCola1000
        {
            get { return _saldo_cola_1000; }
            set { _saldo_cola_1000 = value; }
        }


        protected decimal _saldo_cola_100;

        public decimal SaldoCola100
        {
            get { return _saldo_cola_100; }
            set { _saldo_cola_100 = value; }
        }


        protected decimal _saldo_cola_50;

        public decimal SaldoCola50
        {
            get { return _saldo_cola_50; }
            set { _saldo_cola_50 = value; }
        }



        protected decimal _saldo_cola_20;

        public decimal SaldoCola20
        {
            get { return _saldo_cola_20; }
            set { _saldo_cola_20 = value; }
        }



        protected decimal _saldo_cola_10;

        public decimal SaldoCola10
        {
            get { return _saldo_cola_10; }
            set { _saldo_cola_10 = value; }
        }



        protected decimal _saldo_cola_5;

        public decimal SaldoCola5
        {
            get { return _saldo_cola_5; }
            set { _saldo_cola_5 = value; }
        }



        protected decimal _saldo_cola_1;

        public decimal SaldoCola1
        {
            get { return _saldo_cola_1; }
            set { _saldo_cola_1 = value; }
        }



        protected decimal _saldo_libros_colones;
        public decimal SaldoLibroColones
        {
            get { return (_saldo_anterior_colones + _pedido_boveda_colones + _descarga_atms_colones + _pedido_boveda_adicional_colones + _descarga_completa_colones + _devolucion_atms_colones + _devolucion_emergencias_colones - _entrega_boveda_colones - _cargas_emergencia_colones - _cargas_atms_colones); }

        }

        protected decimal _saldo_libros_dolares;
        public decimal SaldoLibroDolares
        {

            get { return (_saldo_anterior_dolares + _pedido_boveda_dolares + _descarga_atms_dolares + _pedido_boveda_adicional_dolares + _descarga_completa_dolares + _devolucion_atms_dolares + _devolucion_emergencias_dolares - _entrega_boveda_dolares - _cargas_emergencia_dolares - _cargas_atms_dolares); }

        }



        protected decimal _saldo_cartuchos_colones;
        public decimal SaldoCartuchosColones
        {
            get { return _saldo_cartuchos_colones; }
            set { _saldo_cartuchos_colones = value; }
        }


        protected decimal _saldo_cartuchos_dolares;
        public decimal SaldoCartuchosDolares
        {
            get { return _saldo_cartuchos_dolares; }
            set { _saldo_cartuchos_dolares = value; }
        }



        protected decimal _saldo_efectivo_colones;
        public decimal SaldoEfectivoColones
        {
            get { return (_saldo_cola_colones + _saldo_cartuchos_colones + _saldo_cola_20000 + _saldo_cola_10000 + _saldo_cola_5000 + _saldo_cola_2000 + _saldo_cola_1000); }
        }


        protected decimal _saldo_efectivo_dolares;
        public decimal SaldoEfectivoDolares
        {
            get { return (_saldo_cola_dolares + _saldo_cartuchos_dolares + _saldo_cola_100 + _saldo_cola_50 + _saldo_cola_20 + _saldo_cola_10 + _saldo_cola_5 + _saldo_cola_1); }
        }


        protected decimal _diferencia_dolares;
        public decimal DiferenciaDolares
        {
            get { return _saldo_libros_dolares - _saldo_efectivo_dolares; }
        }


        protected decimal _diferencia_colones;
        public decimal DiferenciaColones
        {
            get { return _saldo_libros_colones - _saldo_efectivo_colones; }
        }


        protected decimal _saldo_cola_colones;
        public decimal SaldoColaColones
        {
            get { return _saldo_cola_colones; }
            set { _saldo_cola_colones = value; }
        }



        protected decimal _saldo_cola_dolares;
        public decimal SaldoColaDolares
        {
            get { return _saldo_cola_dolares; }
            set { _saldo_cola_dolares = value; }
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

        #endregion Atributos Privados

        #region Constructor de Clase

        public CierreCargasATMs(int id = 0, decimal libros_colones = 0, decimal libros_dolares = 0,
                   decimal saldo_anterior_colones = 0, decimal saldo_anterior_dolares = 0, decimal pedido_boveda_colones = 0, decimal pedido_boveda_dolares = 0, decimal descarga_atm_colones = 0, decimal descarga_atm_dolares = 0,
            decimal pedido_boveda_adicional_colones = 0, decimal pedido_boveda_adicional_dolares = 0, decimal descarga_completa_colones = 0, decimal descarga_completa_dolares = 0,
            decimal devolucion_atm_colones = 0, decimal devolucion_atm_dolares = 0, decimal devolucion_emergencia_colones = 0, decimal devolucion_emergencia_dolares = 0, decimal entrega_boveda_colones = 0, decimal entrega_boveda_dolares = 0,
            decimal cargas_emergencia_colones = 0, decimal cargas_emergencia_dolares = 0, decimal cargas_atm_colones = 0, decimal cargas_atm_dolares = 0, decimal saldo_cola20000 = 0,
            decimal saldo_cola10000 = 0, decimal saldo_cola5000 = 0, decimal saldo_cola2000 = 0, decimal saldo_cola1000 = 0, decimal saldo_libros_colones = 0, decimal saldo_libros_dolares = 0, decimal saldo_cartucho_colones = 0, decimal saldo_cartucho_dolares = 0,
            decimal saldo_cola100 = 0, decimal saldo_cola50 = 0, decimal saldo_cola20 = 0, decimal saldo_cola10 =0, decimal saldo_cola5 = 0, decimal saldo_cola1 = 0, decimal saldo_efectivo_colones = 0, decimal saldo_efectivo_dolares = 0, decimal diferencia_colones = 0, decimal diferencia_dolares = 0, decimal saldo_cola_dolares = 0, 
            decimal saldo_cola_colones = 0, DateTime? fecha_asignada = null, Colaborador colaborador = null, string observaciones = "")
        {

            _fecha = fecha_asignada ?? DateTime.Now;
            _colaborador_registro = colaborador;
            _observaciones = observaciones;

            this.DB_ID = id;
            _libros_colones = libros_colones;
            _saldo_anterior_colones = saldo_anterior_colones;
            _pedido_boveda_colones = pedido_boveda_colones;
            _descarga_atms_colones = descarga_atm_colones;
            _pedido_boveda_adicional_colones = pedido_boveda_adicional_colones;
            _descarga_completa_colones = descarga_completa_colones;
            _devolucion_atms_colones = devolucion_atm_colones;
            _devolucion_emergencias_colones = devolucion_emergencia_colones;
            _entrega_boveda_colones = entrega_boveda_colones;
            _cargas_emergencia_colones = cargas_emergencia_colones;
            _cargas_atms_colones = cargas_atm_colones;
            _saldo_libros_colones = saldo_libros_colones;
            _saldo_cartuchos_colones = saldo_cartucho_colones;
            _saldo_cola_20000 = saldo_cola20000;
            _saldo_cola_10000 = saldo_cola10000;
            _saldo_cola_5000 = saldo_cola5000;
            _saldo_cola_2000 = saldo_cola2000;
            _saldo_cola_1000 = saldo_cola1000;
            _saldo_efectivo_colones = saldo_efectivo_colones;
            _diferencia_colones = diferencia_colones;
            _saldo_cola_colones = saldo_cola_colones;


            _libros_dolares = libros_dolares;
            _saldo_anterior_dolares = saldo_anterior_dolares;
            _pedido_boveda_dolares = pedido_boveda_dolares;
            _descarga_atms_dolares = descarga_atm_dolares;
            _pedido_boveda_adicional_dolares = pedido_boveda_adicional_dolares;
            _descarga_completa_dolares = descarga_completa_dolares;
            _devolucion_atms_dolares = devolucion_atm_dolares;
            _devolucion_emergencias_dolares = devolucion_emergencia_dolares;
            _entrega_boveda_dolares = entrega_boveda_dolares;
            _cargas_emergencia_dolares = cargas_emergencia_dolares;
            _cargas_atms_dolares = cargas_atm_dolares;
            _saldo_libros_dolares = saldo_libros_dolares;
            _saldo_cartuchos_dolares = saldo_cartucho_dolares;
            _saldo_cola_100 = saldo_cola100;
            _saldo_cola_50 = saldo_cola50;
            _saldo_cola_20 = saldo_cola20;
            _saldo_cola_10 = saldo_cola10;
            _saldo_cola_5 = saldo_cola5;
            _saldo_cola_1 = saldo_cola1;
            _saldo_efectivo_dolares = saldo_efectivo_dolares;
            _diferencia_dolares = diferencia_dolares;
            _saldo_cola_dolares = saldo_cola_dolares;



           
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        
        #endregion Métodos Públicos

        #region Overrides

       

        #endregion Overrides

    }
}
