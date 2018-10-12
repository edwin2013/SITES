//
//  @ Project : 
//  @ File Name : Manifiesto.cs
//  @ Date : 28/04/2011
//  @ Author : Erick Chavarría 
//

using System;

using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects
{

    public class Manifiesto : ObjetoIndexado
    {

        #region Atributos Privados

        protected Colaborador _cajero_receptor;

        public Colaborador Cajero_Receptor
        {
            get { return _cajero_receptor; }
            set { _cajero_receptor = value; }
        }


        protected Colaborador _cajero_reasignado;

        public Colaborador Cajero_Reasignado
        {
            get { return _cajero_reasignado; }
            set { _cajero_reasignado = value; }
        }



        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected AreasManifiestos _area;

        public AreasManifiestos Area
        {
            get { return _area; }
            set { _area = value; }
        }

        protected string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        protected byte _caja;

        public byte Caja
        {
            get { return _caja; }
            set { _caja = value; }
        }

        protected Grupo _grupo;

        public Grupo Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        protected EmpresaTransporte _empresa;

        public EmpresaTransporte Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        protected Colaborador _receptor;

        public Colaborador Receptor
        {
            get { return _receptor; }
            set { _receptor = value; }
        }

        protected DateTime _fecha_recepcion;

        public DateTime Fecha_recepcion
        {
            get { return _fecha_recepcion; }
            set { _fecha_recepcion = value; }
        }

        protected DateTime _fecha_recoleccion;

        public DateTime Fecha_recoleccion
        {
            get { return _fecha_recoleccion; }
            set { _fecha_recoleccion = value; }
        }

        protected bool _retraso;

        public bool Retraso
        {
            get { return _retraso; }
            set { _retraso = value; }
        }

        protected Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }


        protected PuntoVenta _punto_venta;

        public PuntoVenta PuntoVenta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }

        protected BindingList<Tula> _tulas = new BindingList<Tula>();

        public BindingList<Tula> Tulas
        {
            get { return _tulas; }
            set { _tulas = value;}
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public Manifiesto(string codigo,int id = 0,byte caja = 0,AreasManifiestos area = AreasManifiestos.CentroEfectivo,Grupo grupo = null,EmpresaTransporte empresa = null,
            Colaborador receptor = null, DateTime? fecha_recepcion = null, DateTime? fecha_recoleccion = null, bool retraso = false,  Colaborador cajero_receptor = null, PuntoVenta p = null)
        {
            this.DB_ID = id;

            _codigo = codigo;
            _grupo = grupo;
            _caja = caja;
            _empresa = empresa;
            _receptor = receptor;
            _fecha_recepcion = fecha_recepcion ?? DateTime.MinValue;
            _fecha_recoleccion = fecha_recoleccion ?? DateTime.MinValue;
            _retraso = retraso;
            _cajero_receptor = cajero_receptor;
            _punto_venta = p;
        }

        public Manifiesto(string codigo,int id = 0, Cliente cliente = null,EmpresaTransporte empresa = null, Colaborador receptor = null,DateTime? fecha_recepcion = null,DateTime? fecha_recoleccion = null,bool retraso = false,Colaborador cajero_receptor = null)
        {
            this.DB_ID = id;

            _codigo = codigo;
            _cliente = cliente;
            _empresa = empresa;
            _receptor = receptor;
            _fecha_recepcion = fecha_recepcion ?? DateTime.MinValue;
            _fecha_recoleccion = fecha_recoleccion ?? DateTime.MinValue;
            _retraso = retraso;
            _cajero_receptor = cajero_receptor;
        }

        public Manifiesto() { }

        public Manifiesto(string codigo, EmpresaTransporte transportadora, Colaborador receptor)
        {
            _codigo = codigo;
            _empresa = transportadora;
            _receptor = receptor;
        }

        public Manifiesto(string codigo, byte caja)
        {
            this.Caja = caja;
            this.Codigo = codigo;

        }

        public Manifiesto(int id, byte caja, string codigo)
        {
            // TODO: Complete member initialization
            this.ID = id;
            this.DB_ID = id;
            this.Caja = caja;
            this.Codigo = codigo;
        }

        public Manifiesto(string codigo, CommonObjects.Grupo grupo, byte caja, EmpresaTransporte empresa, Colaborador receptor, Colaborador cajero_receptor, AreasManifiestos area)
        {
            // TODO: Complete member initialization
            this.Codigo = codigo;
            this.Grupo = grupo;
            this.Caja = caja;
            this.Empresa = empresa;
            this.Receptor = receptor;
            this.Cajero_Receptor = cajero_receptor;
            this.Area = area;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        public void AgregarTula(Tula t)
        {
            _tulas.Add(t);
        }

        public void EliminarTula(Tula t)
        {
            _tulas.Remove(t);
        }
        
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _codigo;
        }

        #endregion Overrides

    }

}
