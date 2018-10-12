using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class BoletaCajeroNiquel: ObjetoIndexado
    {
               
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       private DateTime _fecha_generacion;

        public DateTime Fecha_Generacion
        {
            get { return _fecha_generacion; }
            set { _fecha_generacion = value; }
        }
      
        private int _cajero;
        
        public int Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        private int _manifiesto;
        
        public int Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        private int _tula;       

        public int Tula
        {
            get { return _tula; }
            set { _tula = value; }
        }


        private int _cliente;

        public int Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private int _procesobajovolumendeposito;

        public int Procesobajovolumendeposito
        {
            get { return _procesobajovolumendeposito; }
            set { _procesobajovolumendeposito = value; }
        }

        private String _numero_deposito;

        public String Numero_Deposito
        {
            get { return _numero_deposito; }
            set { _numero_deposito = value; }
        }

        private String _cuenta;

        public String Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }


        private Decimal _monto_niquel;
        public Decimal MontoNiquel
        {
            set { _monto_niquel = value; }
            get { return _monto_niquel; }
        }
        

        private Decimal _monto_deposito;
        public Decimal MontoDeposito
        {
            set { _monto_deposito = value; }
            get { return _monto_deposito; }
        }

        private Decimal _sobrante;
        public Decimal Sobrante
        {
            get { return _sobrante; }
            set { _sobrante = value; }
        }

        private Decimal _faltante;
        public Decimal Faltante
        {
            get { return _faltante; }
            set { _faltante = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public BoletaCajeroNiquel(int id=0,  int cajero=0, DateTime? fecha_generacion = null, int manifiesto=0, int tula= 0, string cuenta="",
                     int cliente = 0, string numerodeposito = "", Decimal montoniquel = 0, Decimal montodeposito = 0, Decimal montosobrante = 0, Decimal montofaltante = 0, 
            int procesobajovolumendeposito = 0)  
        {
            this.DB_ID = id;

            _fecha_generacion = fecha_generacion ?? DateTime.Now;
            _cajero = cajero;
            _manifiesto = manifiesto;
            _tula = tula;
            _cuenta = cuenta;
            _cliente = cliente;
            _numero_deposito = numerodeposito;
            _monto_niquel = montoniquel;
            _monto_deposito = montodeposito;
            _sobrante = montosobrante;
            _faltante = montofaltante;
            _procesobajovolumendeposito = procesobajovolumendeposito;
        }
              

        #endregion Constructor de Clase

        #region Métodos Públicos
       
        #endregion Métodos Públicos

        #region Overrides        

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
