using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ProcesamientoAltoVolumen : ObjetoIndexado
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

        protected Manifiesto _manifiesto;

        public Manifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
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

        protected decimal _monto;

        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        protected byte _tipo;

        public byte Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        protected Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }       

        protected BindingList<ProcesamientoAltoVolumenDetalle> _detalle;

        public BindingList<ProcesamientoAltoVolumenDetalle> Detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }        

        #endregion Atributos Privados

        #region Constructor de Clase

        public ProcesamientoAltoVolumen(string codigo,
            int id = 0,            
            Manifiesto manifiesto = null,                        
            DateTime? fecha_procesamiento = null,            
            Colaborador cajero_receptor = null, PuntoVenta p = null, Monedas moneda = Monedas.Colones, decimal monto = 0, Camara cam = null, byte tipo = 0)
        {
            this.DB_ID = id;
            _tipo = tipo;
            _manifiesto = manifiesto;
            _fecha_procesamiento = fecha_procesamiento ?? DateTime.MinValue;
            _cajero = cajero_receptor;
            _punto_venta = p;            
            _camara = cam;
            _moneda = moneda;
            _monto = monto;                        
            _detalle = new BindingList<ProcesamientoAltoVolumenDetalle>();

        }
        
        public ProcesamientoAltoVolumen() { }               

        #endregion Constructor de Clase

        #region Métodos Públicos

        public void agregarDetalle(ProcesamientoAltoVolumenDetalle detalle)
        {
            _detalle.Add(detalle);
        }

        public void quitarDetalle(ProcesamientoAltoVolumenDetalle detalle)
        {
            _detalle.Remove(detalle);
        }       

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return ID.ToString();
        }

        #endregion Overrides

    }
}
