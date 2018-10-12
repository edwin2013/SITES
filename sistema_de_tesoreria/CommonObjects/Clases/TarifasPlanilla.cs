using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{

    public enum EstadoFacturacion : int
    {
        Aprobado = 1,
        Inconsistencia = 2,
        Descartado = 3, 
        Eliminado = 4
        
    }

    public class TarifasPlanilla : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       private DateTime _fecha_ingreso;

        public DateTime Fecha_ingreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }
      
        private PuntoAtencion _punto_atencion;
        
        public PuntoAtencion PuntoDeAtencion
        {
            get { return _punto_atencion; }
            set { _punto_atencion = value; }
        }

        private Colaborador _colaborador;
        
        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }


        private string _manifiesto;
        public string Manifiesto
        {
            get{return _manifiesto;}
            set{_manifiesto = value;}
        }
        

        private Decimal _monto_manifiesto_transportadora;
        public Decimal MontoManifiestoTransportadora
        {
            set { _monto_manifiesto_transportadora = value; }
            get { return _monto_manifiesto_transportadora; }
        }

        private Decimal _monto_facturar_transportadora;
        public Decimal MontoFacturarTransportadora
        {
            get { return _monto_facturar_transportadora; }
            set { _monto_facturar_transportadora = value; }
        }

        private Decimal _monto_recargo_transportadora;
        public Decimal MontoRecargoTransportadora
        {
            get { return _monto_recargo_transportadora; }
            set { _monto_recargo_transportadora = value; }
        }


        private Decimal _monto_manifiesto_boveda;
        public Decimal MontoManifiestoBoveda
        {
            set { _monto_manifiesto_boveda = value; }
            get { return _monto_manifiesto_boveda; }
        }

        private Decimal _monto_facturar_boveda;
        public Decimal MontoFacturarBoveda
        {
            get { return _monto_facturar_boveda; }
            set { _monto_facturar_boveda = value; }
        }

        private Decimal _monto_recargo_boveda;
        public Decimal MontoRecargoBoveda
        {
            get { return _monto_recargo_boveda; }
            set { _monto_recargo_boveda = value; }
        }



        private InconsistenciaFacturacion _inconsistencia;
        public InconsistenciaFacturacion Inconsistencia
        {
            get { return _inconsistencia; }
            set { _inconsistencia = value; }
        }

        protected EstadoFacturacion _estado;
        public EstadoFacturacion Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public TarifasPlanilla(int id=0,  PuntoAtencion p = null, string manifiesto = "", decimal monto_facturar_transportadora = 0, decimal monto_recargo_transportadora = 0, decimal monto_manifiesto_transportadora = 0,
            decimal monto_facturar_boveda = 0, decimal monto_recargo_boveda = 0, decimal monto_manifiesto_boveda = 0,
            DateTime ? nueva = null, EstadoFacturacion est = 0, InconsistenciaFacturacion incon = null)  
        {
            this.DB_ID = id;

            _punto_atencion = p;
            _manifiesto = manifiesto;
            _monto_facturar_transportadora = monto_facturar_transportadora;
            _monto_recargo_transportadora = monto_recargo_transportadora;
            _monto_manifiesto_transportadora = monto_manifiesto_transportadora;
            _monto_manifiesto_boveda = monto_manifiesto_boveda;
            _monto_recargo_boveda = monto_recargo_boveda;
            _monto_facturar_boveda= monto_facturar_boveda;
            _fecha_ingreso = nueva ?? DateTime.Now;
            _estado = est;
            _inconsistencia = incon;


        }

      
 

        

        #endregion Constructor de Clase

        #region Métodos Públicos

       

      

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return Manifiesto.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Bolsa bolsa = (Bolsa)obj;

            if ( ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides

    }
}
