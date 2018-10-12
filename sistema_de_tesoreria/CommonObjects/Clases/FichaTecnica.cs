using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public enum TipoMantenimiento : int
    {
        Preventivo = 0,
        Correctivo = 1
    }

    public enum EstadoEquipo : int
    {
        Pendiente = 0,
        Finalizado = 1
    }

    public class FichaTecnica : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private int id;

        private EquipoTesoreria _equipo;

        public EquipoTesoreria Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }

        private string _boleta;

        public string Boleta
        {
            get { return _boleta; }
            set { _boleta = value; }
        }

        private DateTime _periodicidad;

        public DateTime Periodicidad
        {
            get { return _periodicidad; }
            set { _periodicidad = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        private decimal _costo;

        public decimal Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        private EstadoEquipo _estatus;

        public EstadoEquipo Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        private TipoMantenimiento _mantenimiento;

        public TipoMantenimiento Mantenimiento
        {
            get { return _mantenimiento; }
            set { _mantenimiento = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public FichaTecnica() { }
        public FichaTecnica(string boleta,
                        int id = 0,
                        EquipoTesoreria equipo = null,
                        DateTime? periodicidad = null,
                        DateTime? fecha = null,
                        string observaciones = null,
                        decimal costo = 0,
                        EstadoEquipo estado = EstadoEquipo.Pendiente,
                        TipoMantenimiento mantenimiento = TipoMantenimiento.Preventivo)
        {
            this.DB_ID = id;

            _boleta = boleta;
            _estatus = estado;
            _equipo = equipo;
            _periodicidad = periodicidad ?? DateTime.Now;
            _fecha = fecha ?? DateTime.Now;
            _observaciones = observaciones;
            _costo = costo;
            _mantenimiento = mantenimiento;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Metodos Privados
        

        #endregion Metodos Privados

        #region Overrides

              

        #endregion Overrides
    }
}
