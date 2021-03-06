﻿//
//  @ Project : 
//  @ File Name : CartuchoCargaATM.cs
//  @ Date : 09/05/2012
//  @ Author : Erick Chavarría 
//

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public enum TiposCartucho : byte
    {
        Opteva = 0,
        Diebold = 1,
        Dispensador = 2,
        ENA = 3,
        Rechazo = 4,
        Indefinido = 5
    }

    public class CartuchoCargaATM : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _marchamo;

        public string Marchamo
        {
            get { return _marchamo; }
            set { _marchamo = value; }
        }

        protected MovimientoATM _movimiento;

        public MovimientoATM Movimiento
        {
            get { return _movimiento; }
            set { _movimiento = value; }
        }

        protected short _cantidad_asignada;

        public short Cantidad_asignada
        {
            get { return _cantidad_asignada; }
            set { _cantidad_asignada = value; }
        }

        protected short _cantidad_carga;

        public short Cantidad_carga
        {
            get { return _cantidad_carga; }
            set { _cantidad_carga = value; }
        }

        protected short _cantidad_descarga;

        public short Cantidad_descarga
        {
            get { return _cantidad_descarga; }
            set { _cantidad_descarga = value; }
        }

        protected bool _anulado;

        public bool Anulado
        {
            get { return _anulado; }
            set { _anulado = value; }
        }

        public decimal Monto_asignado
        {
            get { return _cantidad_asignada * _denominacion.Valor; }
        }

        public decimal Monto_carga
        {
            get { return _cantidad_carga * _denominacion.Valor; }
        }

        public decimal Monto_descarga
        {
            get { return _cantidad_descarga * _denominacion.Valor; }
        }

        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        protected Cartucho _cartucho;

        public Cartucho Cartucho
        {
            get { return _cartucho; }
            set { _cartucho = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public CartuchoCargaATM(Denominacion denominacion = null,
                                int id = 0,
                                MovimientoATM movimiento = null,
                                Cartucho cartucho = null,
                                string marchamo = "",
                                short cantidad_carga = 0,
                                short cantidad_asignada = 0,
                                short cantidad_descarga = 0,
                                bool anulado = false)
        {
            this.DB_ID = id;

            _marchamo = marchamo;
            _movimiento = movimiento;
            _cantidad_carga = cantidad_carga;
            _cantidad_asignada = cantidad_asignada;
            _cantidad_descarga = cantidad_descarga;
            _denominacion = denominacion;
            _cartucho = cartucho;
            _anulado = anulado;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        public bool estaPendiente()
        {
            return _marchamo == null || _cartucho == null;
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _marchamo.ToString();
        }

        #endregion Overrides

    }

}
