//
//  @ Project : 
//  @ File Name : PuntoVenta.cs
//  @ Date : 02/09/2011
//  @ Author : Erick Chavarría 
//

using CommonObjects.Clases;
using System.ComponentModel;
namespace CommonObjects
{

    public class PuntoVenta : PuntoAtencion
    {

        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }


        private bool _procesado;

        public bool Procesado
        {
            get { return _procesado; }
            set { _procesado = value; }
        }

        protected BindingList<TarifaPuntoVentaTransportadora> _tarifas = new BindingList<TarifaPuntoVentaTransportadora>();

        public BindingList<TarifaPuntoVentaTransportadora> Tarifas
        {
            get { return _tarifas; }
            set { _tarifas = value; }
        }


        protected BindingList<Cuenta> _cuentas = new BindingList<Cuenta>();
        public BindingList<Cuenta> Cuentas
        {
            get { return _cuentas; }
            set { _cuentas = value; }
        }



        protected BindingList<Denominacion> _denominacion_ensobrado = new BindingList<Denominacion>();

        public BindingList<Denominacion> DenominacionEnsobrado
        {
            get { return _denominacion_ensobrado; }
            set { _denominacion_ensobrado = value; }
        }



        protected BindingList<Denominacion> _denominacion_chorreado = new BindingList<Denominacion>();

        public BindingList<Denominacion> DenominacionChorreado
        {
            get { return _denominacion_chorreado; }
            set { _denominacion_chorreado = value; }
        }

        protected decimal _comision;

        public decimal MComision
        {
            get { return _comision; }
            set { _comision = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public PuntoVenta(short id = 0, string nombre = "", Cliente cliente = null, bool procesado = false)
        {
            _id = id;
            this.Id = id;
            this.IDSites = id;
            this._procesado = procesado;
            _nombre = nombre;
            _cliente = cliente;
        }

        public PuntoVenta(string nombre, Cliente cliente)
        {
            _nombre = nombre;
            _cliente = cliente;
        }

        public PuntoVenta(string nombre)
        {
            _nombre = nombre;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Permite agregar una  tarifa a la lista de tarifas de transportadora
        /// </summary>
        /// <param name="tarifa">Objeto TarifaPuntoVentaTransportadora</param>
        public void agregarTarifa(TarifaPuntoVentaTransportadora tarifa)
        {
            this._tarifas.Add(tarifa);
        }

        /// <summary>
        /// Permite quitar una tarifa de la lista de tarifas de tranportadoras
        /// </summary>
        /// <param name="tarifa">Objeto TarifaPuntoVentaTransportadora</param>
        public void quitarTarifa(TarifaPuntoVentaTransportadora tarifa)
        {
            this._tarifas.Remove(tarifa);
        }




        /// <summary>
        /// Permite agregar una  cuenta a la lista de cuentas del punto
        /// </summary>
        /// <param name="cuenta">Objeto Cuenta con los datos de la cuenta</param>
        public void agregarCuenta(Cuenta cuenta)
        {
            this._cuentas.Add(cuenta);
        }

        /// <summary>
        /// Permite quitar una cuenta de la lista de cuentas del punto de venta
        /// </summary>
        /// <param name="tarifa">Objeto Cuentas</param>
        public void quitarCuenta(Cuenta cuenta)
        {
            this._cuentas.Remove(cuenta);
        }


        /// <summary>
        /// Agregar denominación a la lista de ensobrados
        /// </summary>
        /// <param name="d">Objeto denominación con los datos de la denominación</param>
        public void agregarDenominacionPaqueteEnsobrado(Denominacion d)
        {
            this._denominacion_ensobrado.Add(d);
        }

        /// <summary>
        /// Quitar una denominación de la lista de ensobrados
        /// </summary>
        /// <param name="d">Objeto denominación con los datos de la denominación</param>
        public void quitarDenominacionPaqueteEnsobrado(Denominacion d)
        {
            this._denominacion_ensobrado.Remove(d);
        }




        /// <summary>
        /// Agregar denominación a la lista de ensobrados
        /// </summary>
        /// <param name="d">Objeto denominación con los datos de la denominación</param>
        public void agregarDenominacionPaqueteChorreado(Denominacion d)
        {
            this._denominacion_chorreado.Add(d);
        }

        /// <summary>
        /// Quitar una denominación de la lista de ensobrados
        /// </summary>
        /// <param name="d">Objeto denominación con los datos de la denominación</param>
        public void quitarDenominacionPaqueteChorreado(Denominacion d)
        {
            this._denominacion_chorreado.Remove(d);
        }
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            //return Cliente.Nombre +" "+ _nombre.ToString();

            return _nombre.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            PuntoVenta punto = (PuntoVenta)obj;

            if (_id != punto.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
