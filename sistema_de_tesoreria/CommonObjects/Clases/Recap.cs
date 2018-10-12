using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class Recap: ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       private DateTime _fecha_ingreso;

        public DateTime Fecha_ingreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }
      
       

        private Colaborador _colaborador;
        
        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }


        private EstadoRecapt _estado;

        public EstadoRecapt Estado
        {
            set { _estado = value; }
            get { return _estado; }
        }


        private int id;

        private string colaborador;

      
        

        protected BindingList<RecaptPreliminar> _recap_preliminar = new BindingList<RecaptPreliminar>();

        public BindingList<RecaptPreliminar> RecapPreliminar
        {
            get { return _recap_preliminar; }
            set { _recap_preliminar = value; }
        }

       

      


        protected BindingList<RecaptFinal> _recap_final = new BindingList<RecaptFinal>();

        public BindingList<RecaptFinal> RecapFinal
        {
            get { return _recap_final; }
            set{_recap_final = value;}
        }

      

        #endregion Atributos Privados

        #region Constructor de Clase

        public Recap(int id=0, DateTime? fecha_ingreso = null, EstadoRecapt est = EstadoRecapt.Por_Aprobar, 
                    Colaborador colaborador=null)  
        {
            this.DB_ID = id;

            _estado = est;
            _fecha_ingreso = fecha_ingreso ?? DateTime.Now;
            _colaborador = colaborador;
            
        }

        public Recap(int id, string serie, DateTime fecha_ingreso, string colaborador)
        {
           
            this.id = id;
            this.Fecha_ingreso = fecha_ingreso;
            this.colaborador = colaborador;
        }

 

        

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Permite añadir un Recapt Preliminar
        /// </summary>
        /// <param name="r">Objeto RecaptPreliminar con los datos del Recap</param>
        public void agregarRecapPreliminar(RecaptPreliminar r)
        {
            _recap_preliminar.Add(r);
        }
      
        /// <summary>
        /// Permite remover un Recapt Preliminar
        /// </summary>
        /// <param name="r">Objeto Recapt Preliminar</param>
        public void quitarRecapPreliminar(RecaptPreliminar r)
        {
            _recap_preliminar.Remove(r);
        }




        /// <summary>
        /// Permite añadir un Recapt Final
        /// </summary>
        /// <param name="r">Objeto Recap Final con los datos del Recap</param>
        public void agregarRecapFinal(RecaptFinal r)
        {
            _recap_final.Add(r);
        }

        /// <summary>
        /// Permite remover un Recapt Final
        /// </summary>
        /// <param name="r">Objeto Recapt Final</param>
        public void quitarRecapFinal(RecaptFinal r)
        {
            _recap_final.Remove(r);
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return ID.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Recap bolsa = (Recap)obj;

            if ( ID != bolsa.DB_ID) return false;

            return true;
        }

        #endregion Overrides
    }
}
