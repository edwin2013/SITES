using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ProcesamientoNiquel : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private int _cajero;

        public int Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        private ProcesamientoBajoVolumenManifiesto _manifiesto;

        public ProcesamientoBajoVolumenManifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        ConteoNiquel _conteoNiquel;

        public ConteoNiquel conteoNiquel
        {
            get { return _conteoNiquel; }
            set { _conteoNiquel = value; }
        }

        private int _tipoprocesamiento; //-1 sin definir, 0 Mesa Niquel, 1 Cajero Niquel, 2 Procesamiento Externo, 3 Entrega Niquel

        public int TipoProcesamiento
        {
            get { return _tipoprocesamiento; }
            set { _tipoprocesamiento = value; }
        }

        private string _identificador;

        public string Identificador
        {
            get { return _identificador; }
            set { _identificador = value; }
        }

        private ProcesamientoBajoVolumenDeposito _deposito;

        public ProcesamientoBajoVolumenDeposito Deposito
        {
            get { return _deposito; }
            set { _deposito = value; }
        }

        private EmpresaTransporte _transportadora;

        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }

        private decimal _totalNiquel;

        public decimal TotalNiquel
        {
            get { return _totalNiquel; }
            set { _totalNiquel = value; }
        }

        private decimal _montoContado;

        public decimal MontoContado
        {
            get { return _montoContado; }
            set { _montoContado = value; }
        }

        private decimal _diferencia;

        public decimal Diferencia
        {
            get { return _diferencia; }
            set { _diferencia = value; }
        }

        #endregion Atributos Privados
    }
}
