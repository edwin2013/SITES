//
//  @ Project : 
//  @ File Name : ATM.cs
//  @ Date : 30/04/2012
//  @ Author : Erick Chavarría 
//

using System.Collections.Generic;
using System.ComponentModel;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public enum Dias : byte
    {
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        Sabado = 6,
        Domingo = 7,
    }

    public class ATM : ObjetoIndexado
    {

        #region Atributos Privados

        public short ID
        {
            get { return (short)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected short _numero;

        public short Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        protected EmpresaTransporte _empresa_encargada;

        public EmpresaTransporte Empresa_encargada
        {
            get { return _empresa_encargada; }
            set { _empresa_encargada = value; }
        }

        protected TiposCartucho _tipo;

        public TiposCartucho Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        protected byte _cartuchos;

        public byte Cartuchos
        {
            get { return _cartuchos; }
            set { _cartuchos = value; }
        }

        protected bool _externo;

        public bool Externo
        {
            get { return _externo; }
            set { _externo = value; }
        }

        protected bool _full;

        public bool Full
        {
            get { return _full; }
            set { _full = value; }
        }

        protected bool _ena;

        public bool ENA
        {
            get { return _ena; }
            set { _ena = value; }
        }

        protected bool _vip;

        public bool VIP
        {
            get { return _vip; }
            set { _vip = value; }
        }

        protected bool _cartucho_rechazo;

        public bool Cartucho_rechazo
        {
            get { return _cartucho_rechazo; }
            set { _cartucho_rechazo = value; }
        }

        protected string _oficinas;

        public string Oficinas
        {
            get { return _oficinas; }
            set { _oficinas = value; }
        }

        protected string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        protected Sucursal _sucursal;

        public Sucursal Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }

        protected Ubicacion _ubicacion;

        public Ubicacion Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }

        protected byte? _periodo_carga;

        public byte? Periodo_carga
        {
            get { return _periodo_carga; }
            set { _periodo_carga = value; }
        }

        protected List<Dias> _dias_carga = new List<Dias>();

        public List<Dias> Dias_carga
        {
            get { return _dias_carga; }
            set { _dias_carga = value; }
        }

        protected BindingList<MontosRetirosATM> _montos_retiros = new BindingList<MontosRetirosATM>();

        public BindingList<MontosRetirosATM> Montos_retiros
        {
            get { return _montos_retiros; }
            set { _montos_retiros = value; }
        }

        public string Nombre_ubicacion
        {
            get
            {
                return _ubicacion == null ?
                _sucursal.ToString() : _ubicacion.ToString();
            }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ATM(short id = 0,
                   short numero = 0,
                   EmpresaTransporte empresa_encargada = null,
                   TiposCartucho tipo = TiposCartucho.Indefinido,
                   byte cartuchos = 0,
                   bool externo = false,
                   bool full = false,
                   bool ena = false,
                   bool vip = false,
                   bool cartucho_rechazo = false,
                   string codigo = "",
                   string oficinas = "",
                   byte? periodo_carga = null,
                   Sucursal sucursal = null,
                   Ubicacion ubicacion = null)
        {
            this.DB_ID = id;

            _numero = numero;
            _empresa_encargada = empresa_encargada;
            _tipo = tipo;
            _externo = externo;
            _full = full;
            _ena = ena;
            _vip = vip;
            _cartucho_rechazo = cartucho_rechazo;
            _cartuchos = cartuchos;
            _codigo = codigo;
            _oficinas = oficinas;
            _periodo_carga = periodo_carga;
            _sucursal = sucursal;
            _ubicacion = ubicacion;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un día de carga para el ATM.
        /// </summary>
        /// <param name="dia">Nuevo día a agregar</param>
        public void agregarDiaCarga(Dias dia)
        {
            _dias_carga.Add(dia);
        }

        /// <summary>
        /// Quitar un día de carga del ATM.
        /// </summary>
        /// <param name="dia">Día a quitar</param>
        public void quitarDiaCarga(Dias dia)
        {
            _dias_carga.Remove(dia);
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            
            if (_codigo == null || _codigo.Equals(string.Empty))
                return "#" + _numero.ToString();
            else
                return "#" + _numero.ToString() + " - " + _codigo;

        }

        #endregion Overrides

    }

}
