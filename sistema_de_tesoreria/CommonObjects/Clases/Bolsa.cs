//
//  @ Project : 
//  @ File Name : Bolsa.cs
//  @ Date : 20/02/2013
//  @ Author : Erick Chavarría
//

using System;
using System.Collections.Generic;
using System.Text;

using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.ComponentModel;

namespace CommonObjects
{

    public class Bolsa : ObjetoIndexado
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
      
        private String _serie_bolsa;
        
        public String SerieBolsa
        {
            get { return _serie_bolsa; }
            set { _serie_bolsa = value; }
        }

        private Colaborador _colaborador;
        
        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        private ManifiestoSucursalCarga _manfiesto;
        private int id;
        private string serie;
        private string colaborador;

        public ManifiestoSucursalCarga Manifiesto
        {
            get { return _manfiesto; }
            set { _manfiesto = value; }
        }


        private int _id_carga_sucursal;

        public int IDCargaSucursal
        {
            get { return _id_carga_sucursal; }
            set { _id_carga_sucursal = value; }
        }


        private Sucursal _sucursal;

        public Sucursal Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }

        private EmpresaTransporte _transportadora;

        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }


        private Decimal _monto_colones;
        public Decimal MontoColones
        {
            set { _monto_colones = value; }
            get { return _monto_colones; }
        }

        protected BindingList<BolsaMontosSucursales> _cartuchos = new BindingList<BolsaMontosSucursales>();

        public BindingList<BolsaMontosSucursales> Cartuchos
        {
            get { return _cartuchos; }
            set { _cartuchos = value; }
        }

        private Decimal _monto_dolares;
        public Decimal MontoDolares
        {
            set { _monto_dolares = value; }
            get { return _monto_dolares; }
        }

        private Decimal _monto_euros;
        public Decimal MontoEuros
        {
            get { return _monto_euros; }
            set { _monto_euros = value; }
        }


        private Dictionary<Denominacion, List<BolsaMontosSucursales>> _bolsas_denominaciones =
           new Dictionary<Denominacion, List<BolsaMontosSucursales>>();



        protected BindingList<BolsaMontosSucursales> _cartuchos_colones = new BindingList<BolsaMontosSucursales>();

        public BindingList<BolsaMontosSucursales> Cartuchos_Colones
        {
            get { return _cartuchos_colones; }
        }

        protected BindingList<BolsaMontosSucursales> _cartuchos_dolares = new BindingList<BolsaMontosSucursales>();

        public BindingList<BolsaMontosSucursales> Cartuchos_Dolares
        {
            get { return _cartuchos_dolares; }
        }


        protected BindingList<BolsaMontosSucursales> _cartuchos_euros = new BindingList<BolsaMontosSucursales>();

        public BindingList<BolsaMontosSucursales> Cartuchos_Euros
        {
            get { return _cartuchos_euros; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Bolsa(int id=0,  string serie="", DateTime? fecha_ingreso = null, 
                     ManifiestoSucursalCarga manifiesto = null, 
                     Colaborador colaborador=null, Decimal montocoloes = 0, Decimal montodolares=0, Decimal montoeuros =0)  
        {
            this.DB_ID = id;

            _fecha_ingreso = fecha_ingreso ?? DateTime.Now;
            _serie_bolsa = serie;
            _manfiesto = manifiesto;
            _colaborador = colaborador;
            _monto_colones = montocoloes;
            _monto_dolares = montodolares;
            _monto_euros = montoeuros;
        }

        public Bolsa(int id, string serie, DateTime fecha_ingreso, string colaborador)
        {
           
            this.id = id;
            this.serie = serie;
            this.Fecha_ingreso = fecha_ingreso;
            this.colaborador = colaborador;
        }

        public Bolsa()
        {
            // TODO: Complete member initialization
        }

        public Bolsa(int id, string serie, DateTime fecha_ingreso)
        {
            // TODO: Complete member initialization
            this.id = id;
            this.serie = serie;
            this.Fecha_ingreso = fecha_ingreso;
            DB_ID = id;
        }

 

        

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un cartucho a la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a agregar</param>
        public void agregarCartucho(BolsaMontosSucursales cartucho)
        {
            _cartuchos.Add(cartucho);

            switch (cartucho.Denominacion.Moneda)
            {
                case Monedas.Colones:

                    _monto_colones += cartucho.Cantidad_asignada;

                    break;
                case Monedas.Dolares:
                    _monto_dolares += cartucho.Cantidad_asignada;

                    break;
                case Monedas.Euros:
                    _monto_euros += cartucho.Cantidad_asignada;

                    break;
            }

            this.asignaCartuchoDenominacion(cartucho);
        }

        /// <summary>
        /// Quitar un cartucho de la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a quitar</param>
        public void quitarCartucho(BolsaMontosSucursales cartucho)
        {
            _cartuchos.Remove(cartucho);

            switch (cartucho.Denominacion.Moneda)
            {
                case Monedas.Colones:
                    _cartuchos_colones.Remove(cartucho);
                    _monto_colones -= cartucho.Cantidad_asignada;
  
                    break;
                case Monedas.Dolares:
                    _cartuchos_dolares.Remove(cartucho);
                    _monto_dolares -= cartucho.Monto_asignado;
                    break;
                case Monedas.Euros:
                    _cartuchos_euros.Remove(cartucho);
                    _monto_euros -= cartucho.Monto_asignado;
                    break;
            }

            _bolsas_denominaciones[cartucho.Denominacion].Remove(cartucho);
        }

        /// <summary>
        /// Recalcular los montos de una carga.
        /// </summary>
        public void recalcularMontosCarga()
        {
            _monto_colones = 0;
            _monto_dolares = 0;
            _monto_euros = 0;


            foreach (BolsaMontosSucursales cartucho in _cartuchos)
            {

                switch (cartucho.Denominacion.Moneda)
                {
                    case Monedas.Colones:
                        _monto_colones += cartucho.Cantidad_asignada;
                        break;
                    case Monedas.Dolares:
                        _monto_dolares += cartucho.Cantidad_asignada;
                        break;
                    case Monedas.Euros:
                        _monto_euros += cartucho.Cantidad_asignada;
                        break;
                }

            }

        }

        /// <summary>
        /// Agregar un cartucho a las lista de cartuchos de su misma denominacion.
        /// </summary>
        /// <param name="cartucho">Cartucho que se agregará</param>
        private void asignaCartuchoDenominacion(BolsaMontosSucursales cartucho)
        {
            Denominacion denominacion = cartucho.Denominacion;

            if (_bolsas_denominaciones.ContainsKey(denominacion))
            {
                _bolsas_denominaciones[denominacion].Add(cartucho);
            }
            else
            {
                List<BolsaMontosSucursales> cartuchos = new List<BolsaMontosSucursales>();

                cartuchos.Add(cartucho);

                _bolsas_denominaciones.Add(denominacion, cartuchos);
            }

        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return SerieBolsa.ToString();
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
