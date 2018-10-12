//
//  @ Project : 
//  @ File Name : ManifiestoBoveda.cs
//  @ Date : 29/03/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;

namespace CommonObjects
{

    public class ManifiestoBoveda : Manifiesto
    {

        #region Atributos Privados
        
        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        protected PuntoVenta _punto_venta;

        public PuntoVenta Punto_venta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }

        protected Sucursal _sucursal;

        public Sucursal Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
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

        protected DateTime _fecha_procesamiento;

        public DateTime Fecha_procesamiento
        {
            get { return _fecha_procesamiento; }
            set { _fecha_procesamiento = value; }
        }

        protected BindingList<RecapExterno> _recaps = new BindingList<RecapExterno>();

        public BindingList<RecapExterno> Recaps
        {
            get { return _recaps; }
            set { _recaps = value; }
        }

        #endregion Atributos Privados
        
        #region Constructor de Clase

        public ManifiestoBoveda(string codigo,
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

        public ManifiestoBoveda(int id,
                                string codigo = "",
                                Colaborador cajero = null,
                                PuntoVenta punto_venta = null,
                                Sucursal sucursal = null,
                                decimal monto_colones = 0,
                                decimal monto_dolares = 0,
                                DateTime? fecha_procesamiento = null)
        {
            this.DB_ID = id;
            this.Codigo = codigo;
            this.Cajero = cajero;
            this.Punto_venta = punto_venta;
            this.Sucursal = sucursal;
            this.Monto_colones = monto_colones;
            this.Monto_dolares = monto_dolares;
            this.Fecha_procesamiento = fecha_procesamiento ?? DateTime.MinValue;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Ligar un recap al manifiesto.
        /// </summary>
        /// <param name="recap">Recap a agregar</param>
        public void agregarRecap(RecapExterno recap)
        {
            _recaps.Add(recap);
        }

        /// <summary>
        /// Desligar un recap de un manifiesto.
        /// </summary>
        /// <param name="recap">Recap a desligar</param>
        public void quitarRecap(RecapExterno recap)
        {
            _recaps.Remove(recap);
        }

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
