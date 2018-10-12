using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class SaldoLibroNiquel: ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected Colaborador _colaborador; 

        public Colaborador Colaborador
        {
            set { _colaborador = value; }
            get { return _colaborador; }
        }


        protected Denominacion _denominacion;
        public Denominacion Denominacion
        {
            set { _denominacion = value; }
            get { return _denominacion; }
        }

        protected Decimal _monto_colones; 
        public Decimal MontoColones
        {
            set { _monto_colones = value; }
            get { return _monto_colones; }
        }

        protected Decimal _monto_dolares;
        public Decimal MontoDolares
        {
            set { _monto_dolares = value; }
            get { return _monto_dolares; }
        }

        protected Decimal _monto_euros; 
        public Decimal MontoEuros
        { 
            set { _monto_euros = value; }
            get { return _monto_euros; }
        }


        protected Decimal _custodia_auxiliar; 
        public Decimal CustodiaAuxiliar
        {
            get { return _custodia_auxiliar; }
            set { _custodia_auxiliar = value; }
        }



        protected Decimal _cola_colones;
        public Decimal ColaColones
        {
            get { return _cola_colones; }
            set { _cola_colones = value; }
        }



        protected Decimal _cola_dolares;
        public Decimal ColaDolares
        {
            get { return _cola_dolares; }
            set { _cola_dolares = value; }
        }



        protected Decimal _cola_euros;
        public Decimal ColaEuros
        {
            get { return _cola_euros; }
            set { _cola_euros = value; }
        }


        protected Decimal _mutilado_colones;
        public Decimal MutiladoColones
        {
            get { return _mutilado_colones; }
            set { _mutilado_colones = value; }
        }



        protected Decimal _mutilado_dolares;
        public Decimal MutiladoDolares
        {
            get { return _mutilado_dolares; }
            set { _mutilado_dolares = value; }
        }



        protected Decimal _mutilado_euros;
        public Decimal MutiladoEuros
        {
            get { return _mutilado_euros; }
            set { _mutilado_euros = value; }
        }

        protected Colaborador _colaborador_registro;

        public Colaborador ColaboradoRegistro
        {
            get { return _colaborador_registro; }
            set { _colaborador_registro = value; }
        }



        #endregion Atributos Privados

        #region Constructor de Clase

        public SaldoLibroNiquel(int id = 0, DateTime? fecha_asignada = null, Colaborador colaborador = null, Decimal monto_colones = 0, Decimal monto_dolares = 0, Decimal monto_euros = 0, Denominacion d = null, decimal custodia_auxiliar = 0, decimal cola_colones = 0,
            decimal cola_dolares = 0, decimal cola_euros = 0, decimal mutilado_colones = 0, decimal mutilado_dolares = 0, decimal mutilado_euros = 0)
        {

            _fecha = fecha_asignada ?? DateTime.Now;
            _colaborador_registro = colaborador;
            _monto_colones = monto_colones;
            _monto_euros = monto_euros;
            _monto_dolares = monto_dolares;
            _denominacion = d;
            _cola_colones = cola_colones;
            _cola_dolares = cola_dolares;
            _cola_euros = cola_euros;
            _mutilado_colones = mutilado_colones;
            _mutilado_dolares = mutilado_dolares;
            _mutilado_euros = mutilado_euros;
            _custodia_auxiliar = custodia_auxiliar;
       
          
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        
        #endregion Métodos Públicos

        #region Overrides

       

        #endregion Overrides
    }
}
