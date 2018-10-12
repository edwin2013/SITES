using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public enum Evaluacion : int
    {
        Malo = 0,
        Regular = 1,
        Bueno = 2,
        Excelente = 3, 
        Pendiente = 4
    }

    public enum EstadoRequerimiento : int
    {
        Solicitado = 0,
        Procesado = 1,
        Evaluado = 2
    }

    public class RequerimientoMantenimiento : ObjetoIndexado
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

        private Colaborador _solicitante;

        public Colaborador Solicitante
        {
            get { return _solicitante; }
            set { _solicitante = value; }
        }

        private DateTime _fechaSolicitud;

        public DateTime FechaSolicitud
        {
            get { return _fechaSolicitud; }
            set { _fechaSolicitud = value; }
        }

        public Areas _area;
        
        public Areas Area
        {
            get { return _area; }
            set { _area = value; }
        }

        private TipoMantenimiento _mantenimiento;

        public TipoMantenimiento Mantenimiento
        {
            get { return _mantenimiento; }
            set { _mantenimiento = value; }
        }

        private string _descripcionSolicitud;

        public string DescripcionSolicitud
        {
            get { return _descripcionSolicitud; }
            set { _descripcionSolicitud = value; }
        }
        
        private Evaluacion _evaluacion;

        public Evaluacion Evaluacion
        {
            get { return _evaluacion; }
            set { _evaluacion = value; }
        }

        private DateTime _fechaProveedor;

        public DateTime FechaProveedor
        {
            get { return _fechaProveedor; }
            set { _fechaProveedor = value; }
        }
        
        private DateTime _fechaServicio;

        public DateTime FechaServicio
        {
            get { return _fechaServicio; }
            set { _fechaServicio = value; }
        }

        private string _descripcionServicio;

        public string DescripcionServicio
        {
            get { return _descripcionServicio; }
            set { _descripcionServicio = value; }
        }

        private string _SAP;

        public string SAP
        {
            get { return _SAP; }
            set { _SAP = value; }
        }

        private EstadoRequerimiento _estado;

        public EstadoRequerimiento Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

               
        #endregion Atributos Privados

        #region Constructor de Clase

        public RequerimientoMantenimiento() { }
        public RequerimientoMantenimiento(
                        Colaborador solicitante = null,
                        int id = 0,
                        EquipoTesoreria equipo = null,
                        DateTime? fechasolicitud = null,
                        Areas area = Areas.Tesoreria,
                        TipoMantenimiento mantenimiento = TipoMantenimiento.Correctivo,
                        string descripcionsolicitud = "",
                        Evaluacion evaluacion = Evaluacion.Bueno,
                        DateTime? fechaproveedor = null,
                        DateTime? fechaservicio = null,
                        string descripcionservicio = "",
                        string sap = "",
                        EstadoRequerimiento estado = EstadoRequerimiento.Solicitado)
        {
            this.DB_ID = id;
            _solicitante = solicitante;
            _equipo = equipo;
            _fechaSolicitud = fechasolicitud ?? DateTime.Now;
            _area = area;
            _mantenimiento = mantenimiento;
            _descripcionSolicitud = descripcionsolicitud;
            _evaluacion = evaluacion;
            _fechaProveedor = fechaproveedor ?? DateTime.Now;
            _fechaServicio = fechaservicio ?? DateTime.Now;
            _descripcionServicio = descripcionservicio;
            _SAP = sap;
            _estado = estado;
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
