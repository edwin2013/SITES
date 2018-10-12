
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

using LibreriaAccesoDatos;


namespace CommonObjects
{
   public class Vehiculo:ObjetoIndexado
    {

        
        #region Atributos Privados

       public short ID
       {
           get { return (short)this.DB_ID; }
           set { this.DB_ID = value; }
       }

        private string _placa;

        public string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }


        private double _kilometrajeinicial;
        public double Kilometrajeinicial
        {
            get { return _kilometrajeinicial; }
            set { _kilometrajeinicial = value; }
        }


        private double _kilometrajefinal;
        public double KilometrajeFinal
        {
            get { return _kilometrajefinal; }
            set { _kilometrajefinal = value; }
        }

        private string _modelo;
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        private Int32 _numeroasociado;
        public Int32 NumeroAsociado
        {
            get { return _numeroasociado; }
            set { _numeroasociado = value; }
        }

        private double _cantidadgalonesdiesel;
        public double CantidadGalonesDiesel
        {
            get { return _cantidadgalonesdiesel; }
            set { _cantidadgalonesdiesel = value; }
        }

        private double _cantidadcuartosaceite;
        public double CantidadCuartosAceite
        {
            get { return _cantidadcuartosaceite; }
            set { _cantidadcuartosaceite = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Vehiculo(string placa,string modelo, double kilometrajeinicial, double kilometrajefinal, double cantidadg, double cantidada,
                                 int id = 0)
        {
            this.DB_ID = id;
            _placa = placa;
            _modelo = modelo;
            _kilometrajeinicial = kilometrajeinicial;
            _kilometrajefinal = kilometrajefinal;
            _cantidadgalonesdiesel = cantidadg;
            _cantidadcuartosaceite = cantidada;
        }


        public Vehiculo(string placa, string modelo, int numeroasociado,
                                 int id = 0)
        {
            this.DB_ID = id;
            _placa = placa;
            _modelo = modelo;
            _numeroasociado = numeroasociado;
        }

        public Vehiculo()
        {
           
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _placa;
        }

        #endregion Overrides
    }
}
