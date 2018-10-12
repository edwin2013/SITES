using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ProcesamientoBajoVolumenManifiesto : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }        

        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }        

        protected string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }        

        protected EmpresaTransporte _empresa;

        public EmpresaTransporte Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }       

        protected DateTime _fecha_ingreso;

        public DateTime Fecha_ingreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }

        protected DateTime _fecha_procesamiento;

        public DateTime Fecha_Procesamiento
        {
            get { return _fecha_procesamiento; }
            set { _fecha_procesamiento = value; }
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

        protected Camara _camara;

        public Camara Camara
        {
            get { return _camara; }
            set { _camara = value; }
        }        

        protected decimal _monto_colones;

        public decimal Monto_Colones
        {
            get { return _monto_colones; }
            set { _monto_colones = value; }
        }

        protected decimal _monto_dolares;

        public decimal Monto_Dolares
        {
            get { return _monto_dolares; }
            set { _monto_dolares = value; }
        }

        protected decimal _monto_euros;

        public decimal Monto_Euros
        {
            get { return _monto_euros; }
            set { _monto_euros = value; }
        }

        protected decimal _monto_contado_colones;

        public decimal Monto_Contado_Colones
        {
            get { return _monto_contado_colones; }
            set { _monto_contado_colones = value; }
        }

        protected decimal _monto_contado_dolares;

        public decimal Monto_Contado_Dolares
        {
            get { return _monto_contado_dolares; }
            set { _monto_contado_dolares = value; }
        }

        protected decimal _monto_contado_euros;

        public decimal Monto_Contado_Euros
        {
            get { return _monto_contado_euros; }
            set { _monto_contado_euros = value; }
        }

        protected decimal _monto_diferencia_colones;

        public decimal Monto_Diferencia_Colones
        {
            get { return _monto_diferencia_colones; }
            set { _monto_diferencia_colones = value; }
        }

        protected decimal _monto_diferencia_dolares;

        public decimal Monto_Diferencia_Dolares
        {
            get { return _monto_diferencia_dolares; }
            set { _monto_diferencia_dolares = value; }
        }

        protected decimal _monto_diferencia_euros;

        public decimal Monto_Diferencia_Euros
        {
            get { return _monto_diferencia_euros; }
            set { _monto_diferencia_euros = value; }
        }

        protected BindingList<Tula> _tulas;

        public BindingList<Tula> Tulas
        {
            get { return _tulas; }
            set { _tulas = value; }
        }

        protected BindingList<ProcesamientoBajoVolumenDeposito> _depositos;

        public BindingList<ProcesamientoBajoVolumenDeposito> Depositos
        {
            get { return _depositos; }
            set { _depositos = value; }
        }

        protected int _idmanifiesto;

        public int IDManifiesto
        {
            get { return _idmanifiesto; }
            set { _idmanifiesto = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ProcesamientoBajoVolumenManifiesto(string codigo,
            int id = 0,            
            EmpresaTransporte empresa = null,            
            DateTime? fecha_ingreso = null,
            DateTime? fecha_procesamiento = null,            
            Colaborador cajero_receptor = null, PuntoVenta p = null, decimal montocolones = 0, decimal montodolares = 0, decimal montoeuros = 0, Camara cam = null)
        {
            this.DB_ID = id;

            _codigo = codigo;           
            _empresa = empresa;            
            _fecha_ingreso = fecha_ingreso ?? DateTime.MinValue;
            _fecha_procesamiento = fecha_procesamiento ?? DateTime.MinValue;            
            _cajero = cajero_receptor;
            _punto_venta = p;
            _camara = cam;            
            _monto_colones = montocolones;
            _monto_dolares = montodolares;
            _monto_euros = montoeuros;
            _tulas =new BindingList<Tula>();
            _depositos = new BindingList<ProcesamientoBajoVolumenDeposito>();

        }


        public ProcesamientoBajoVolumenManifiesto(string codigo,
            int id = 0,
            Cliente cliente = null,
            EmpresaTransporte empresa = null,
            DateTime? fecha_ingreso = null,
            DateTime? fecha_procesamiento = null,
            Colaborador cajero_receptor = null, Monedas mon = Monedas.Colones, decimal montocolones = 0, decimal montodolares = 0, decimal montoeuros = 0, Camara cam = null, PuntoVenta p = null)
        {
            this.DB_ID = id;

            _codigo = codigo;
            _cliente = cliente;
            _empresa = empresa;
            _fecha_ingreso = fecha_ingreso ?? DateTime.MinValue;
            _fecha_procesamiento = fecha_procesamiento ?? DateTime.MinValue;             
            _cajero = cajero_receptor;
            _camara = cam;            
            _monto_colones = montocolones;
            _monto_dolares = montodolares;
            _monto_euros = montoeuros;
            _tulas = new BindingList<Tula>();
            _depositos = new BindingList<ProcesamientoBajoVolumenDeposito>();
            _punto_venta = p;
        }

        public ProcesamientoBajoVolumenManifiesto() { }               

        #endregion Constructor de Clase

        #region Métodos Públicos

        public void agregarTula(Tula tula)
        {
            _tulas.Add(tula);
        }        

        public void quitarTula(Tula tula)
        {
            _tulas.Remove(tula);
        }

        public void agregarDeposito(ProcesamientoBajoVolumenDeposito deposito)
        {
            if (_depositos == null) _depositos = new BindingList<ProcesamientoBajoVolumenDeposito>();
            _depositos.Add(deposito);
        }

        public void quitarDeposito(ProcesamientoBajoVolumenDeposito deposito)
        {
            _depositos.Remove(deposito);
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
