using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public enum CategoriasFacturacion : int
    {
        Cuenta_Corriente_Entrantes = 1,
        Cuenta_Corriente_Salientes = 2,
        Material_Operativo = 3,
        Procesamiento = 4,
        Sucursales = 5,
        Servicios_Especiales = 6,
        Eticket = 7,
    }
    public class CategoriaFacturacionTransportadora : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }



    

        protected Decimal _monto;

        public Decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }


        protected Decimal _monto_credito_debito;

        public Decimal MontoCreditoDebito
        {
            get { return _monto_credito_debito; }
            set { _monto_credito_debito = value; }
        }


        protected string _centro_costos;

        public string CentroCostos
        {
            get { return _centro_costos; }
            set { _centro_costos = value; }
        }


        protected string _factura;

        public string Factura
        {
            get { return _factura; }
            set { _factura = value; }
        }


        protected string _modelo;
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        protected CategoriasFacturacion _categorias;

        public CategoriasFacturacion Categoria
        {
            get { return _categorias; }
            set { _categorias = value; }
        }


      

        
        #endregion Atributos Privados

        #region Constructor de Clase

        public CategoriaFacturacionTransportadora(int id = 0,
                   Decimal monto = 0,
                   Decimal creditosdebitos = 0,
                   string centro_costos = "",
                   string factura = "",
                   string modelo = "",  
                   CategoriasFacturacion categoria = 0)
        {
            this.DB_ID = id;

            this._centro_costos = centro_costos;
            this._factura = factura;
            this._monto_credito_debito = creditosdebitos;
            this._monto = monto;
            this._categorias = categoria;
            this._modelo = modelo;
            
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
