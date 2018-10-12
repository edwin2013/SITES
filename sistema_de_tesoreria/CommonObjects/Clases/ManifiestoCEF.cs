//
//  @ Project : 
//  @ File Name : ManifiestoCEF.cs
//  @ Date : 28/04/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;

namespace CommonObjects
{

    public class ManifiestoCEF : Manifiesto, PlanillaCEF
    {

        #region Atributos Privados

        protected Colaborador _cajero_receptor;

        public Colaborador Cajero_Receptor
        {
            get { return _cajero_receptor; }
            set { _cajero_receptor = value; }
        }




        //protected Colaborador _cajero_reasignado;

        //public Colaborador Cajero_Reasignado
        //{
        //    get { return _cajero_receptor; }
        //    set { _cajero_receptor = value; }
        //}
        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        protected Colaborador _digitador;

        public Colaborador Digitador
        {
            get { return _digitador; }
            set { _digitador = value; }
        }

        protected Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }

        protected PuntoVenta _punto_venta;

        public PuntoVenta Punto_venta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }

        protected decimal _monto_colones;

        public decimal Monto_colones
        {
            get { return _monto_colones; }
            set { _monto_colones = value; }
        }

        protected decimal _monto_dolares;

        public decimal Monto_dolares
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
        protected short _depositos;

        public short Depositos
        {
            get { return _depositos; }
            set { _depositos = value; }
        }

        protected DateTime _fecha_procesamiento;

        public DateTime Fecha_procesamiento
        {
            get { return _fecha_procesamiento; }
            set { _fecha_procesamiento = value; }
        }

        protected BindingList<SegregadoCEF> _segregados = new BindingList<SegregadoCEF>();
        private int id;
        private Colaborador cajero_receptor;

        public BindingList<SegregadoCEF> Segregados
        {
            get { return _segregados; }
            set { _segregados = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ManifiestoCEF(string codigo,
                             int id = 0,
                             byte caja = 0,
                             Grupo grupo = null,
                             EmpresaTransporte empresa = null,
                             Colaborador receptor = null,
                             DateTime? fecha_recepcion = null,
                             DateTime? fecha_recoleccion = null,
                             bool retraso = false) :
        base(codigo, id: id, grupo: grupo, caja: caja, empresa: empresa, receptor: receptor, 
             fecha_recepcion: fecha_recepcion, fecha_recoleccion: fecha_recoleccion,
             retraso: retraso) { }

        public ManifiestoCEF(int id,
                             string codigo = "",
                             Colaborador cajero = null,
                             Colaborador digitador = null,
                             Colaborador coordinador = null,
                             Colaborador cajero_receptor = null,
                             PuntoVenta punto_venta = null,
                             decimal monto_colones = 0,
                             decimal monto_dolares = 0,
                             decimal monto_euros = 0,
                             short depositos = 0,
                             DateTime? fecha_procesamiento = null)
        {
            this.DB_ID = id;
            this.Codigo = codigo;
            this.Cajero = cajero;
            this.Digitador = digitador;
            this.Coordinador = coordinador;
            this.Punto_venta = punto_venta;
            this.Monto_colones = monto_colones;
            this.Monto_dolares = monto_dolares;
            this.Depositos = depositos;
            this.Fecha_procesamiento = fecha_procesamiento ?? DateTime.MinValue;
            this.Cajero_Receptor = cajero_receptor;
            this.Monto_Euros = monto_euros;
        }

        public ManifiestoCEF(string codigo, int id, EmpresaTransporte empresa, DateTime fecha_recepcion, Colaborador cajero_receptor)
        {
            // TODO: Complete member initialization
            this.Codigo = codigo;
            this.id = id;
            this.ID = id;
            this.DB_ID = id;
            this.Empresa = empresa;
            this.Fecha_recepcion = fecha_recepcion;
            this.cajero_receptor = cajero_receptor;
        }
        
        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un manifiesto segregado.
        /// </summary>
        /// <param name="segregado">Manifiesto segregado a agregar</param>
        public void agregarSegregado(SegregadoCEF segregado)
        {
            _segregados.Add(segregado);
        }

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
