using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class RevisionFinalPortavalor : ObjetoIndexado
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

        private string _descripcion_ruta;
        public string DescripcionRuta
        {
            set { _descripcion_ruta = value; }
            get { return _descripcion_ruta; }
        }

        private string _ruta_imagen;
        public string RutaImagen
        {
            get { return _ruta_imagen; }
            set { _ruta_imagen = value; }
        }

        private Equipo _equipo;
        public Equipo Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }


        private Colaborador _colaborador;
        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        private bool _revision;
        public bool Revision
        {
            get { return true; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RevisionFinalPortavalor( DateTime? fecha = null, int ruta = 0, Equipo v = null, Colaborador chofer = null, int idtrip = 0,
                                string imagen = "", string descripciontrip = "",
                                 int id = 0)
        {
            this.DB_ID = id;
            _fecha = fecha??DateTime.Now;
            _ruta = ruta;
            _equipo = v;
            _colaborador = chofer;
            _descripcion_ruta = descripciontrip;
            _id_tripulacion = idtrip;
            _ruta_imagen = imagen;
        }



        public RevisionFinalPortavalor()
        {
           
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _equipo.ToString();
        }

        #endregion Overrides
    }
}
