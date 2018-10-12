using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class DepositoAcreditacion : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       private string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
      
        private String _cuenta;
        
        public String Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        private Decimal _monto;
        
        public Decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }



        private String _referencia;

        public String Referencia
        {
            get { return _referencia; }
            set { _referencia = value; }
        }



        private String _punto_venta;

        public String PuntoVenta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }


        private String _identificacion;

        public String Identificacion
        {
            get { return _identificacion; }
            set { _identificacion = value; }
        }



        private String _deposito;

        public String Deposito
        {
            get { return _deposito; }
            set { _deposito = value; }
        }




        private String _manifiesto;

        public String Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }



        private String _cliente;

        public String Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }




       

        #endregion Atributos Privados

        #region Constructor de Clase

        public DepositoAcreditacion(int id=0, string codigo = "", string cuenta = "", string referencia = "", string puntoventa = "",
            string identificacion = "", string deposito = "", string manifiesto = "", string cliente = "", Decimal monto = 0)  
        {
            this.DB_ID = id;

            this._codigo = codigo;
            _cuenta = cuenta;
            _referencia = referencia;
            _punto_venta = puntoventa;
            _identificacion = identificacion;
            _deposito = deposito;
            _cliente = cliente;
            _manifiesto = manifiesto;
            _monto = monto;
        }

       
        

        #endregion Constructor de Clase

        #region Métodos Públicos

       

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return Cuenta.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            DepositoAcreditacion bolsa = (DepositoAcreditacion)obj;

            if ( ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides
    }
}
