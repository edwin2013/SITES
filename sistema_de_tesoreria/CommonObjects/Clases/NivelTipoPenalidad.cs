using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class NivelTipoPenalidad : ObjetoIndexado
    {
        #region Atributos Privados

        private short _id;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _cantidad_valor_visita;

        public int CantidadValorVisita
        {
            get { return _cantidad_valor_visita; }
            set { _cantidad_valor_visita = value; }
        }

        private double _porcentaje_minimo;

        public double PorcentajeMinimo
        {
            get { return _porcentaje_minimo; }
            set { _porcentaje_minimo = value; }
        }

        private double _porcentaje_maximo;

        public double PorcentajeMaximo
        {
            get { return _porcentaje_maximo; }
            set { _porcentaje_maximo = value; }
        }

        private double _porcentaje_valor_tarifa;

        public double PorcentajeValorTarifa
        {
            get { return _porcentaje_valor_tarifa; }
            set { _porcentaje_valor_tarifa = value; }
        }

        protected TipoPenalidad _tipo_penalidad;

        public TipoPenalidad TipoPenalidad
        {
            get { return _tipo_penalidad; }
            set { _tipo_penalidad = value; }
        }
       


        #endregion Atributos Privados

        #region Constructor de Clase

        public NivelTipoPenalidad(short id = 0, int cantidadvalorvisita = 0, double valor_minimo = 0, double valor_maximo = 0, double porcentaje_tarifa = 0)
        {
            _id = id;
            this.Id = id;
            this._cantidad_valor_visita = cantidadvalorvisita;
            this._porcentaje_minimo = valor_minimo;
            this._porcentaje_maximo = valor_maximo;
            this._porcentaje_valor_tarifa = porcentaje_tarifa;
            
        }

        

        
        #endregion Constructor de Clase

        #region Métodos Públicos

       

        #endregion Métodos Públicos

        #region Overrides

        

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            NivelTipoPenalidad punto = (NivelTipoPenalidad)obj;

            if (_id != punto.Id) return false;

            return true;
        }

        #endregion Overrides
    }
}
