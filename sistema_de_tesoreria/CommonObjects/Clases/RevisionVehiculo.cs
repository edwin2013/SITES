using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class RevisionVehiculo:ObjetoIndexado
    {

        #region Atributos Privados

       public short ID
       {
           get { return (short)this.DB_ID; }
           set { this.DB_ID = value; }
       }

        private DateTime _fecha;
        
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }


        protected int _ruta;

        public int Ruta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }

        protected int _id_tripulacion;
        public int IDTripulacion
        {
            get{return _id_tripulacion;}
            set{_id_tripulacion = value;}
        }


        private string _ruta_imagen;
        public string RutaImagen
        {
            get { return _ruta_imagen; }
            set { _ruta_imagen = value; }
        }

        private Vehiculo _vehiculo;
        public Vehiculo Vehiculo
        {
            get { return _vehiculo; }
            set { _vehiculo = value; }
        }


        private Colaborador _chofer;
        public Colaborador Chofer
        {
            get { return _chofer; }
            set { _chofer = value; }
        }

        

        #endregion Atributos Privados

        #region Constructor de Clase

        public RevisionVehiculo( DateTime? fecha = null, int ruta = 0, Vehiculo v = null, Colaborador chofer = null, int idtrip = 0,
                                string imagen = "",
                                 int id = 0)
        {
            this.DB_ID = id;
            _fecha = fecha??DateTime.Now;
            _ruta = ruta;
            _vehiculo = v;
            _chofer = chofer;
            _id_tripulacion = idtrip;
            _ruta_imagen = imagen;
        }


       
        public RevisionVehiculo()
        {
           
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _vehiculo.ToString();
        }

        #endregion Overrides
    }
}
