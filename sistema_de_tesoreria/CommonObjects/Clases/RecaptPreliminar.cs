using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public enum EstadoRecapt : int
    {
        Por_Aprobar = 0,
        Aprobado = 1,
        Rechazado = 2
    }

    public enum TipoRecapt : int
    {
        Pedido_Colones = 0,
        Pedido_Dolares = 1,
        Envio_Colones = 2,
        Envio_Dolares = 3
    }
    public class RecaptPreliminar : ObjetoIndexado
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
      
       

        private Colaborador _colaborador;
        
        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }


        private EstadoRecapt _estado;

        public EstadoRecapt Estado
        {
            set { _estado = value; }
            get { return _estado; }
        }


        private int id;

        private string colaborador;

      
        

        private Decimal _monto_colones;
        public Decimal MontoColones
        {
            set { _monto_colones = value; }
            get { return _monto_colones; }
        }

        protected BindingList<MontosRecaptPreliminar> _cartuchos = new BindingList<MontosRecaptPreliminar>();

        public BindingList<MontosRecaptPreliminar> Cartuchos
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



        private Dictionary<Denominacion, List<MontosRecaptPreliminar>> _bolsas_denominaciones =
           new Dictionary<Denominacion, List<MontosRecaptPreliminar>>();



        protected BindingList<MontosRecaptPreliminar> _cartuchos_colones = new BindingList<MontosRecaptPreliminar>();

        public BindingList<MontosRecaptPreliminar> Cartuchos_Colones
        {
            get { return _cartuchos_colones; }
        }

        protected BindingList<MontosRecaptPreliminar> _cartuchos_dolares = new BindingList<MontosRecaptPreliminar>();

        public BindingList<MontosRecaptPreliminar> Cartuchos_Dolares
        {
            get { return _cartuchos_dolares; }
        }


        protected BindingList<MontosRecaptPreliminar> _cartuchos_euros = new BindingList<MontosRecaptPreliminar>();

        public BindingList<MontosRecaptPreliminar> Cartuchos_Euros
        {
            get { return _cartuchos_euros; }
        }


        protected TipoRecapt _tipo_recap;
        public TipoRecapt TipoRecap
        {
            set { _tipo_recap = value; }
            get { return _tipo_recap;}
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RecaptPreliminar(int id=0, DateTime? fecha_ingreso = null, EstadoRecapt est = EstadoRecapt.Por_Aprobar, 
                    Colaborador colaborador=null, Decimal montocoloes = 0, Decimal montodolares=0, Decimal montoeuros =0)  
        {
            this.DB_ID = id;

            _estado = est;
            _fecha_ingreso = fecha_ingreso ?? DateTime.Now;
            _colaborador = colaborador;
            _monto_colones = montocoloes;
            _monto_dolares = montodolares;
            _monto_euros = montoeuros;
        }

        public RecaptPreliminar(int id, string serie, DateTime fecha_ingreso, string colaborador)
        {
           
            this.id = id;
            this.Fecha_ingreso = fecha_ingreso;
            this.colaborador = colaborador;
        }

        public RecaptPreliminar()
        {
            // TODO: Complete member initialization
        }

        public RecaptPreliminar(int id, string serie, DateTime fecha_ingreso)
        {
            // TODO: Complete member initialization
            this.id = id;
            this.Fecha_ingreso = fecha_ingreso;
            DB_ID = id;
        }

 

        

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un cartucho a la carga.
        /// </summary>
        /// <param name="cartucho">Cartucho a agregar</param>
        public void agregarCartucho(MontosRecaptPreliminar cartucho)
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
        public void quitarCartucho(MontosRecaptPreliminar cartucho)
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


            foreach (MontosRecaptPreliminar cartucho in _cartuchos)
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
        private void asignaCartuchoDenominacion(MontosRecaptPreliminar cartucho)
        {
            Denominacion denominacion = cartucho.Denominacion;

            if (_bolsas_denominaciones.ContainsKey(denominacion))
            {
                _bolsas_denominaciones[denominacion].Add(cartucho);
            }
            else
            {
                List<MontosRecaptPreliminar> cartuchos = new List<MontosRecaptPreliminar>();

                cartuchos.Add(cartucho);

                _bolsas_denominaciones.Add(denominacion, cartuchos);
            }

        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return ID.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            RecaptPreliminar bolsa = (RecaptPreliminar)obj;

            if ( ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides
    }
}
