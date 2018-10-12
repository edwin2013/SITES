//
//  @ Project : 
//  @ File Name : SegregadoCEF.cs
//  @ Date : 09/11/2011
//  @ Author : Erick Chavarría 
//

using System;

namespace CommonObjects
{

    public class SegregadoCEF : PlanillaCEF
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        private Colaborador _digitador;

        public Colaborador Digitador
        {
            get { return _digitador; }
            set { _digitador = value; }
        }

        private Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }

        private PuntoVenta _punto_venta;

        public PuntoVenta Punto_venta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }

        private decimal _monto_colones;

        public decimal Monto_colones
        {
            get { return _monto_colones; }
            set { _monto_colones = value; }
        }

        private decimal _monto_dolares;

        public decimal Monto_dolares
        {
            get { return _monto_dolares; }
            set { _monto_dolares = value; }
        }


        private decimal _monto_euros;

        public decimal Monto_Euros
        {
            get { return _monto_euros; }
            set { _monto_euros = value; }
        }

        private short _depositos;

        public short Depositos
        {
            get { return _depositos; }
            set { _depositos = value; }
        }

        private DateTime _fecha_procesamiento;

        public DateTime Fecha_procesamiento
        {
            get { return _fecha_procesamiento; }
            set { _fecha_procesamiento = value; }
        }

        private Manifiesto _manifiesto;

        public Manifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public SegregadoCEF(int id, Colaborador cajero, Colaborador digitador, Colaborador coordinador, PuntoVenta punto_venta,
                            decimal monto_colones, decimal monto_dolares, decimal monto_euros, short depositos, DateTime fecha_procesamiento)
        {
            this.Id = id;
            this.Cajero = cajero;
            this.Digitador = digitador;
            this.Coordinador = coordinador;
            this.Punto_venta = punto_venta;
            this.Monto_colones = monto_colones;
            this.Monto_dolares = monto_dolares;
            this.Depositos = depositos;
            this.Monto_Euros = monto_euros;
            this.Fecha_procesamiento = fecha_procesamiento;
        }

        public SegregadoCEF(int id, Colaborador cajero, Colaborador digitador, Colaborador coordinador, PuntoVenta punto_venta)
        {
            this.Id = id;
            this.Cajero = cajero;
            this.Digitador = digitador;
            this.Coordinador = coordinador;
            this.Punto_venta = punto_venta;
        }

        public SegregadoCEF(int id, Manifiesto manifiesto, decimal monto_colones, decimal monto_dolares,decimal monto_euros, short depositos)
        {
            this.Id = id;
            this.Manifiesto = manifiesto;
            this.Monto_colones = monto_colones;
            this.Monto_dolares = monto_dolares;
            this.Depositos = depositos;
            this.Monto_Euros = monto_euros;
        }

        public SegregadoCEF(Manifiesto manifiesto)
        {
            _manifiesto = manifiesto;
        }

        public SegregadoCEF() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _manifiesto.Codigo;
        }

        #endregion Overrides

    }

}
