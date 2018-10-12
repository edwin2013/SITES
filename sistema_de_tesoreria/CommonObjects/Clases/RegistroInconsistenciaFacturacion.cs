using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{

    public enum EstadosInconsistencias : int
    {
        Verificada = 0,
        Descartada = 1
    }
    public class RegistroInconsistenciaFacturacion : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        
        protected Colaborador _colaborador_registro;

        public Colaborador ColaboradorRegistro
        {
            get { return _colaborador_registro; }
            set { _colaborador_registro = value; }
        }

        
        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

       
        protected InconsistenciaFacturacion _inconsistencia_facturacion;
        
        public InconsistenciaFacturacion InconsistenciaFacturacion
        {
            get{return _inconsistencia_facturacion;}
            set{ _inconsistencia_facturacion = value;}
        }

        protected EstadosInconsistencias _estado;
        public EstadosInconsistencias Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        protected PuntoAtencion _punto;

        public PuntoAtencion Punto
        {
            get { return _punto; }
            set { _punto = value; }
        }

        protected string _observaciones;
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RegistroInconsistenciaFacturacion(
                          int id = 0,
                          Colaborador usuarioregistro = null,
                          DateTime? fecha = null, 
                          InconsistenciaFacturacion inc = null,
                          EstadosInconsistencias est = 0,
                          string observaciones = "",
                          PuntoAtencion p = null)
        {
            this.DB_ID = id;

    
            _colaborador_registro = usuarioregistro;
  
            _fecha = fecha ?? DateTime.Now;
            _inconsistencia_facturacion = inc;
            _estado = est;
            _observaciones = observaciones;
            _punto = p;
      
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
