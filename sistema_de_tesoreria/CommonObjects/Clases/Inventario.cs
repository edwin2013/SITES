using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
   public class Inventario : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private int _inicial;

        public int Inicial
        {
            get { return _inicial; }
            set { _inicial = value; }
        }

       
        private int _ingreso;

        public int Ingreso
        {
            get { return _ingreso; }
            set { _ingreso = value; }
        }

        private int _total;

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private int _pedido;

        public int Pedido
        {
            get { return _pedido; }
            set { _pedido = value; }
        }

        private int _reorden;

        public int Reorden
        {
            get { return _reorden; }
            set { _reorden = value; }
        }

        private int _stock;

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        private int _cantATM;

        public int CantATM
        {
            get { return _cantATM; }
            set { _cantATM = value; }
        }

        private int _cantCartuchos;

        public int CantCartuchos
        {
            get { return _cantCartuchos; }
            set { _cantCartuchos = value; }
        }

        private int _periodoMaximo;

        public int PeriodoMaximo
        {
            get { return _periodoMaximo; }
            set { _periodoMaximo = value; }
        }

        private int _periodoEntrega;

        public int PeriodoEntrega
        {
            get { return _periodoEntrega; }
            set { _periodoEntrega = value; }
        }

        private int _demanda;

        public int Demanda
        {
            get { return _demanda; }
            set { _demanda = value; }
        }

        private TiposCartucho _tipo;

        public TiposCartucho Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public Inventario() { }

       //constructor de Inventario
        public Inventario(int id = 0, 
            int inicial = 0,
            int ingreso = 0,
            int total = 0,
            int pedido = 0,
            int reorden = 0, 
            int stock = 0,
            int cantATMs = 0,
            int cantcart = 0,
            int permaximo = 0,
            int perentrega= 0,
            int demanda = 0,
            TiposCartucho tipo = TiposCartucho.ENA)
        {
            this.DB_ID = id;
            _inicial = inicial;
            _ingreso = ingreso;
            _total = total;
            _pedido = pedido;
            _reorden = reorden;
            _stock = stock;
            _cantATM = cantATMs;
            _cantCartuchos = cantcart;
            _periodoMaximo = permaximo;
            _periodoEntrega = perentrega;
            _demanda = demanda;
            _tipo = tipo;
            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides
    }
}
