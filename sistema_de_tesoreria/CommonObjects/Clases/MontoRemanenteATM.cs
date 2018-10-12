//
//  @ Project : 
//  @ File Name : MontoRemanenteATM.cs
//  @ Date : 24/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;

using LibreriaAccesoDatos;

namespace CommonObjects
{
    
    public class MontoRemanenteATM : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        private ATM _atm;

        public ATM ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }

        protected short _cantidad;

        public short Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        protected byte _posicion;

        public byte Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }
        public decimal Monto
        {
            get {

                if (_cantidad == null || _denominacion.Valor == null)
                    return 0;
                else
                    return _cantidad * _denominacion.Valor;
            }
        }

        
        private DateTime _fechaactual;
        public DateTime FechaActual
        {
            get { return _fechaactual; }
            set { _fechaactual = value; }
        }

        private DateTime _fechaultimatransaccion;
        public DateTime FechaUltimaTransaccion
        {
            get { return _fechaultimatransaccion; }
            set { _fechaultimatransaccion = value; }
        }

      

        private String _localizacion;
        public String Localizacion
        {
            get { return _localizacion; }
            set { _localizacion = value; }
        }

        private Decimal _montog1;
        public Decimal Montog1
        {
            get { return _montog1; }
            set { _montog1 = value; }
        }
        
        private Decimal _montog2;
        public Decimal Montog2
        {
            get { return _montog2; }
            set { _montog2 = value; }
        }

        private Decimal _montog3;
        public Decimal Montog3
        {
            get { return _montog3; }
            set { _montog3 = value; }
        }

        private Decimal _montog4;
        public Decimal Montog4
        {
            get { return _montog4; }
            set { _montog4 = value; }
        }





        //private Decimal _montog1original;
        //public Decimal Montog1Original
        //{
        //    get { return _montog1; }
        //    set { _montog1 = value; }
        //}

        //private Decimal _montog2;
        //public Decimal Montog2
        //{
        //    get { return _montog2; }
        //    set { _montog2 = value; }
        //}

        //private Decimal _montog3;
        //public Decimal Montog3
        //{
        //    get { return _montog3; }
        //    set { _montog3 = value; }
        //}

        //private Decimal _montog4;
        //public Decimal Montog4
        //{
        //    get { return _montog4; }
        //    set { _montog4 = value; }
        //}

        private Decimal _denominacion1;
        public Decimal Denominacion1
        {
            get { return _denominacion1; }
            set { _denominacion1 = value; }
        }

        private Decimal _denominacion2;
        public Decimal Denominacion2
        {
            get { return _denominacion2; }
            set { _denominacion2 = value; }
        }


        private Decimal _denominacion3;
        public Decimal Denominacion3
        {
            get { return _denominacion3; }
            set { _denominacion3 = value; }
        }

        private Decimal _denominacion4;
        public Decimal Denominacion4
        {
            get { return _denominacion4; }
            set { _denominacion4 = value; }
        }

        private Decimal _montototalcolones;
        public Decimal MontoTotalColones
        {
            get { return _montototalcolones; }
            set { _montototalcolones = value; }
        }


        private Decimal _montototaldolares;
        public Decimal MontoTotalDolares
        {
            get { return _montototaldolares; }
            set { _montototaldolares = value; }
        }

        private String _cargaemergencia;
        public String CargaEmergencia
        {
            get { return _cargaemergencia; }
            set { _cargaemergencia = value; }
        }


        private Decimal _diasinventariorequerido;
        public Decimal DiasInventarioRequerido
        {
            get { return _diasinventariorequerido; }
            set { _diasinventariorequerido = value; }
        }



        private Decimal _diasinventario;
        public Decimal DiasInventario
        {
            get { return _diasinventario; }
            set { _diasinventario = value; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public MontoRemanenteATM(Denominacion denominacion,
                                 short cantidad,
                                 byte posicion,
                                 int id = 0)
        {
            this.DB_ID = id;

            _denominacion = denominacion;
            _cantidad = cantidad;
            _posicion = posicion;
        }

        public MontoRemanenteATM()
        {
            ATM = new ATM();
        }


        public MontoRemanenteATM(int id = 0,
                                     ATM atm = null,
                                     DateTime? fecha = null)
        {
            this.DB_ID = id;

            _atm = atm;
            _fechaactual = fecha ?? DateTime.Now;
        }
        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
