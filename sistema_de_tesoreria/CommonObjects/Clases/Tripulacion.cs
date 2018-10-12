using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LibreriaAccesoDatos;
using CommonObjects.Clases;

namespace CommonObjects
{
    public class Tripulacion:ObjetoIndexado
    {

        
        #region Atributos Privados

        private short _id;

        public short ID
        {
            get { return (short)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }


        private int _ruta;
        public int Ruta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }

        private Colaborador _chofer;
        public Colaborador Chofer
        {
            get { return _chofer; }
            set { _chofer = value; }
        }

        private Colaborador _custodio;
        public Colaborador Custodio
        {
            get { return _custodio; }
            set { _custodio = value; }
        }

        private Colaborador _portavalor;
        private string nombre;
        private int id;
        public Colaborador Portavalor
        {
            get { return _portavalor; }
            set { _portavalor = value; }
        }


        protected Colaborador _usuario;
        public Colaborador Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        protected String _observaciones;
        public String Observaciones
        {
            set { _observaciones = value; }
            get { return _observaciones; }
        }


        protected Vehiculo _vehiculo;
        public Vehiculo Vehiculo
        {
            set { _vehiculo = value; }
            get { return _vehiculo; }
        }

        protected int _orden_salida;
        public int OrdenSalida
        {
            set { _orden_salida = value; }
            get { return _orden_salida; }
        }

        protected Dispositivo _dispositivo;
        public Dispositivo Dispostivo
        {
            get { return _dispositivo; }
            set { _dispositivo = value; }
        }

        protected AsignacionEquipo _asignaciones;
        public AsignacionEquipo Asignaciones
        {
            get { return _asignaciones; }
            set { _asignaciones = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Tripulacion(short id = 0, string descripcion = "", int ruta = 0, Colaborador chofer = null, Colaborador portavalor= null, Colaborador custodio=null, int ordenSalida = 0, Dispositivo disp = null)
        {
            _id = id;
            _descripcion = descripcion;
            _ruta = ruta;
            _chofer = chofer;
            _portavalor = portavalor;
            _custodio = custodio;
            _orden_salida = ordenSalida;
            _dispositivo = disp;
        }

       

        public Tripulacion(short id, string nombre)
        {
            _id = id;
            _descripcion = nombre;
        }


        public Tripulacion(string nombre = "", int ruta=0, Colaborador chofer= null, Colaborador custodio=null, Colaborador portavalor=null, Colaborador usuario=null, short id = 0, string observaciones = "", Vehiculo v = null, int ordenSalida = 0, Dispositivo disp = null)
        {
             this.DB_ID = id;
            _descripcion = nombre;
            _chofer = chofer;
            _custodio = custodio;
            _portavalor = portavalor;
            _ruta = ruta;
            _usuario = usuario;
            _observaciones = observaciones;
            _vehiculo = v;
            _orden_salida = ordenSalida;
            _dispositivo = disp;
        }

        public Tripulacion(short id)
        {
            _id = id;
        }

        public Tripulacion() 
        {
            this.Chofer = new Colaborador();
            this.Custodio = new Colaborador();
            this.Portavalor = new Colaborador();
            this.Usuario = new Colaborador();
            this.Observaciones = string.Empty;
        }

        public Tripulacion(string nombre, int ruta, Colaborador chofer, Colaborador custodio, Colaborador portavalor, int id)
        {
            // TODO: Complete member initialization
            this.nombre = nombre;
            this.Ruta = ruta;
            this.Chofer = chofer;
            this.Custodio = custodio;
            this.Portavalor = portavalor;
            this.id = id;
        }

        public Tripulacion(string nombre, int ruta, Colaborador chofer, Colaborador custodio, Colaborador portavalor, int id, Colaborador usuario, string observaciones)
        {
            // TODO: Complete member initialization
            this.nombre = nombre;
            this.Ruta = ruta;
            this.Chofer = chofer;
            this.Custodio = custodio;
            this.Portavalor = portavalor;
            this.id = id;
            this.Usuario = usuario;
            this.Observaciones = observaciones;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

       
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _ruta.ToString() +_descripcion;
        }

      #endregion Overrides
    }
}
