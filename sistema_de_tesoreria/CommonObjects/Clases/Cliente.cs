//
//  @ Project : 
//  @ File Name : Cliente.cs
//  @ Date : 01/06/2011
//  @ Author : Erick Chavarría 

using CommonObjects.Clases;
using System;
using System.ComponentModel;
using System.Text;

namespace CommonObjects
{

    public enum Empaques : byte
    {
        Chorreado = 0,
        Embolsado = 1,
        Ninguno = 2
    }

    public enum Contratos_Transporte : byte
    {
        Ninguno = 0,
        Subcontratado = 1,
        PagoCosto = 2,
        BancaEmpresas = 3
    }
    
    public class Cliente
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

        private string _contacto;

        public string Contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }

        private Contratos_Transporte _contrato_transporte;

        public Contratos_Transporte Contrato_transporte
        {
            get { return _contrato_transporte; }
            set { _contrato_transporte = value; }
        }

        private bool _solicitud_remesas;

        public bool Solicitud_remesas
        {
            get { return _solicitud_remesas; }
            set { _solicitud_remesas = value; }
        }

        private BindingList<NombreJuridico> _nombres_juridicos = new BindingList<NombreJuridico>();

        public BindingList<NombreJuridico> Nombres_juridicos
        {
            get { return _nombres_juridicos; }
            set { _nombres_juridicos = value; }
        }

        private BindingList<PuntoVenta> _puntos_venta = new BindingList<PuntoVenta>();

        public BindingList<PuntoVenta> Puntos_venta
        {
            get { return _puntos_venta; }
            set { _puntos_venta = value; }
        }

        private BindingList<Telefono> _telefonos = new BindingList<Telefono>();

        public BindingList<Telefono> Telefonos
        {
            get { return _telefonos; }
            set { _telefonos = value; }
        }



        private BindingList<PuntoVenta> _puntos_cuentas = new BindingList<PuntoVenta>();

        public BindingList<PuntoVenta> puntos_cuentas
        {
            get { return _puntos_cuentas; }
            set { _puntos_cuentas = value; }
        }
        private BindingList<Correo> _correos = new BindingList<Correo>();

        public BindingList<Correo> Correos
        {
            get { return _correos; }
            set { _correos = value; }
        }


        private BindingList<TarifaPuntoVentaTransportadora> _tarifas_transportadoras = new BindingList<TarifaPuntoVentaTransportadora>();

        public BindingList<TarifaPuntoVentaTransportadora> Tarifas_Transportadoras
        {
            get { return _tarifas_transportadoras; }
            set { _tarifas_transportadoras = value; }
        }


        private BindingList<Comision> _comisiones = new BindingList<Comision>();

        public BindingList<Comision> Comisiones
        {
            get { return _comisiones; }
            set { _comisiones = value; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public Cliente(short id, string nombre, Contratos_Transporte contrato_transporte,
                       bool solicitud_remesas, string contacto)
        {
            _id = id;
            _nombre = nombre;
            _contrato_transporte = contrato_transporte;
            _solicitud_remesas = solicitud_remesas;
            _contacto = contacto;
        }

        public Cliente(string nombre, Contratos_Transporte contrato_transporte,
                       bool solicitud_remesas, string contacto)
        {
            _nombre = nombre;
            _contrato_transporte = contrato_transporte;
            _solicitud_remesas = solicitud_remesas;
            _contacto = contacto;
        }

        public Cliente(short id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        public Cliente(short id)
        {
            _id = id;
        }

        public Cliente() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un punto de venta al cliente.
        /// </summary>
        /// <param name="punto">Nuevo punto de venta a agregar</param>
        public void agregarNombreJuridico(NombreJuridico nombre)
        {
            _nombres_juridicos.Add(nombre);
        }

        /// <summary>
        /// Quitar un punto de venta del cliente.
        /// </summary>
        /// <param name="punto">Sucursal a quitar</param>
        public void quitarNombreJuridico(NombreJuridico nombre)
        {
            _nombres_juridicos.Remove(nombre);
        }

        /// <summary>
        /// Agregar un punto de venta al cliente.
        /// </summary>
        /// <param name="punto">Nuevo punto de venta a agregar</param>
        public void agregarPuntoVenta(PuntoVenta punto)
        {
            _puntos_venta.Add(punto);
        }

        /// <summary>
        /// Quitar un punto de venta del cliente.
        /// </summary>
        /// <param name="punto">Sucursal a quitar</param>
        public void quitarPuntoVenta(PuntoVenta punto)
        {
            _puntos_venta.Remove(punto);
        }

        /// <summary>
        /// Agregar un teléfono al cliente.
        /// </summary>
        /// <param name="telefono">Nueva telefono a agregar</param>
        public void agregarTelefono(Telefono telefono)
        {
            _telefonos.Add(telefono);
        }

        /// <summary>
        /// Quitar un teléfono del cliente.
        /// </summary>
        /// <param name="telefono">Telefono a quitar</param>
        public void quitarTelefono(Telefono telefono)
        {
            _telefonos.Remove(telefono);
        }

        /// <summary>
        /// Agregar un correo al cliente.
        /// </summary>
        /// <param name="correo">Nuevo correo a agregar</param>
        public void agregarCorreo(Correo correo)
        {
            _correos.Add(correo);
        }

        /// <summary>
        /// Quitar un correo del cliente.
        /// </summary>
        /// <param name="correo">Correo a quitar</param>
        public void quitarCorreo(Correo correo)
        {
            _correos.Remove(correo);
        }



        /// <summary>
        /// Agregar una tarifa a un cliente
        /// </summary>
        /// <param name="punto">Nueva tarifa a agregar</param>
        public void agregarTarifaTransportadora(TarifaPuntoVentaTransportadora tarifa)
        {
            _tarifas_transportadoras.Add(tarifa);
        }

        /// <summary>
        /// Quitar una tarifa del cliente.
        /// </summary>
        /// <param name="punto">Tarifa a quitar</param>
        public void quitarTarifaTransportadora(TarifaPuntoVentaTransportadora tarifa)
        {
            _tarifas_transportadoras.Remove(tarifa);
        }


        /// <summary>
        /// Permite agregar una comisión al cliente
        /// </summary>
        /// <param name="comision">Objeto Comision con la lista de comisiones</param>
        public void agregarComision(Comision comision)
        {
            _comisiones.Add(comision);
        }

        /// <summary>
        /// Permite remover una comision al cliente
        /// </summary>
        /// <param name="comision">Objeto comisión con la lista de comisiones</param>
        public void quitarComision(Comision comision)
        {
            _comisiones.Remove(comision);
        }
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Cliente cliente = (Cliente)obj;

            if (_id != cliente.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
