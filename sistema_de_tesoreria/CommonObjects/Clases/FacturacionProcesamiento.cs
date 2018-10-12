using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class FacturacionProcesamiento : ObjetoIndexado
    {

         #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        protected EmpresaTransporte _empresa_encargada;

        public EmpresaTransporte Empresa_encargada
        {
            get { return _empresa_encargada; }
            set { _empresa_encargada = value; }
        }

        

        protected Decimal _monto_total_colones;

        public Decimal MontoTotalColones
        {
            get { return _monto_total_colones; }
            set { _monto_total_colones = value; }
        }


        protected Decimal _monto_total_dolares;

        public Decimal MontoTotalDolares
        {
            get { return _monto_total_dolares; }
            set { _monto_total_dolares = value; }
        }


        protected Decimal _monto_total_niquel;

        public Decimal MontoTotalNiquel
        {
            get { return _monto_total_niquel; }
            set { _monto_total_niquel = value; }
        }


        protected Decimal _tarifa_colones;

        public Decimal TarifaColones
        {
            get { return _tarifa_colones; }
            set { _tarifa_colones = value; }
        }

        protected Decimal _tarifa_dolares;

        public Decimal TarifaDolares
        {
            get { return _tarifa_dolares; }
            set { _tarifa_dolares = value; }
        }


        protected Decimal _tarifa_niquel;

        public Decimal TarifaNiquel
        {
            get { return _tarifa_niquel; }
            set { _tarifa_niquel = value; }
        }


        protected DateTime _fecha;
        public DateTime  Fecha
        {
            set { _fecha = value; }
            get { return _fecha; }
        }

      
        
        #endregion Atributos Privados

        #region Constructor de Clase

        public FacturacionProcesamiento(int id = 0,
                   Cliente cliente = null, 
                   EmpresaTransporte transportadora = null,
                   Decimal monto_colones = 0,
                   Decimal monto_dolares = 0,
                   Decimal monto_niquel = 0,
                   Decimal tarifa_colones = 0,
                   Decimal tarifa_dolares = 0,
                   Decimal tarifa_niquel = 0,
                   DateTime ? fecha = null)
        {
            this.DB_ID = id;

            _cliente = cliente;
            _empresa_encargada = transportadora;
            _monto_total_colones = monto_colones;
            _monto_total_dolares = monto_dolares;
            _monto_total_niquel = monto_niquel;
            _tarifa_colones = tarifa_colones;
            _tarifa_dolares = tarifa_dolares;
            _tarifa_niquel = tarifa_niquel;
            _fecha = fecha ?? DateTime.Now;
            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

      

        #endregion Métodos Públicos

        #region Overrides

        //public override string ToString()
        //{
            
        //    //if (_codigo == null || _codigo.Equals(string.Empty))
        //    //    return "#" + _cliente.ToString();
        //    //else
        //    //    return "#" + _cliente.ToString() + " - " + _codigo;

        //}

        #endregion Overrides
    }
}
