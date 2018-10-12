using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Collections.Generic;

namespace CommonObjects.Clases
{
    public class InconsistenciaDepositoBajoVolumen : ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected byte _es_numdeposito;
        public byte Es_numdeposito
        {
            get { return _es_numdeposito; }
            set { _es_numdeposito = value; }
        }

        protected byte _es_cuenta;
        public byte Es_cuenta
        {
            get { return _es_cuenta; }
            set { _es_cuenta = value; }
        }

        protected byte _es_cedula;
        public byte Es_cedula
        {
            get { return _es_cedula; }
            set { _es_cedula = value; }
        }

        protected byte _es_codigoVD;
        public byte Es_codigoVD
        {
            get { return _es_codigoVD; }
            set { _es_codigoVD = value; }
        }

        protected byte _es_codigotransaccion;
        public byte Es_codigotransaccion
        {
            get { return _es_codigotransaccion; }
            set { _es_codigotransaccion = value; }
        }

        protected byte _es_moneda;
        public byte Es_moneda
        {
            get { return _es_moneda; }
            set { _es_moneda = value; }
        }

        protected byte _estado;
        public byte Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }        

        protected DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected ProcesamientoBajoVolumenDeposito _procesamiento;
        public ProcesamientoBajoVolumenDeposito procesamiento
        {
            get { return _procesamiento; }
            set { _procesamiento = value; }
        }

        protected Manifiesto _manifiesto;
        public Manifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected Tula _tula;
        public Tula Tula
        {
            get { return _tula; }
            set { _tula = value; }
        }

        protected Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        protected Colaborador _cajero;
        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        protected PuntoVenta _puntoventa;
        public PuntoVenta PuntoVenta
        {
            get { return _puntoventa; }
            set { _puntoventa = value; }
        }

        protected Camara _camara;
        public Camara Camara
        {
            get { return _camara; }
            set { _camara = value; }
        }
   

        #endregion Atributos Privados

        #region Constructor de Clase


        public InconsistenciaDepositoBajoVolumen(short id = 0, DateTime? fecha_procesamiento = null, byte esdeposito = 0, byte esmoneda = 0, byte escuenta = 0, byte escodigotransaccion = 0, 
            byte escedula = 0, byte escodigoVD= 0, byte estado = 0, ProcesamientoBajoVolumenDeposito proceso = null, Manifiesto manifiesto = null, Tula tula = null, PuntoVenta puntoventa = null,
            Colaborador cajero = null, Camara cam = null)//()
        {            
           this.DB_ID = id;
           this.Fecha = (DateTime)fecha_procesamiento;
           this.Es_cedula = escedula;
           this.Es_codigotransaccion = escodigotransaccion;
           this.Es_codigoVD = escodigoVD;
           this.Es_cuenta = escuenta;
           this.Es_moneda = esmoneda;
           this.Es_numdeposito = esdeposito;
           this.Estado = estado;
           this.ID = id;
           this.Manifiesto = manifiesto;
           this.procesamiento = proceso;
           this.Tula = tula;
           this.PuntoVenta = puntoventa;
           this.Cajero = cajero;
           this.Camara = cam;
        }

        public InconsistenciaDepositoBajoVolumen() { }

        #endregion Constructor de Clase
    }
}
