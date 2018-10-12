using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class NivelServicio
    {
        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private double _porcentaje_nivel_cumplimiento;

        public double PorcentajeNivelCumplimiento
        {
            get { return _porcentaje_nivel_cumplimiento; }
            set { _porcentaje_nivel_cumplimiento = value; }
        }

        private double _porcentaje_nivel_efectividad;

        public double PorcentajeNivelEfectividad
        {
            get { return _porcentaje_nivel_efectividad; }
            set { _porcentaje_nivel_efectividad = value; }
        }

        private DateTime _fecha_inicio;
        public DateTime FechaInicio
        {
            get { return _fecha_inicio; }
            set { _fecha_inicio = value; }
        }


        private DateTime _fecha_fin;
        public DateTime FechaFin
        {
            get { return _fecha_fin; }
            set { _fecha_fin = value; }
        }

        private EmpresaTransporte _transportadora;
        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public NivelServicio(int id = 0, Cliente cliente = null, double porcentaje_cumplimiento = 0, double porcentaje_efectividad = 0, 
            DateTime? fechainicio = null, DateTime? fechafin = null, EmpresaTransporte transp = null)
        {
            _id = id;
            this.Id = id;
            this._cliente = cliente;
            this._porcentaje_nivel_cumplimiento = porcentaje_cumplimiento;
            this._porcentaje_nivel_efectividad = porcentaje_efectividad;
            this._fecha_inicio = fechainicio ?? DateTime.Now;
            this._fecha_fin = fechafin ?? DateTime.Now;
            this._transportadora = transp;
            
        }

        

        
        #endregion Constructor de Clase

        #region Métodos Públicos

       

        #endregion Métodos Públicos

        #region Overrides

        

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            NivelServicio punto = (NivelServicio)obj;

            if (_id != punto.Id) return false;

            return true;
        }

        #endregion Overrides
    }
}
