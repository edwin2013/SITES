using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class LimiteEfectivo : ObjetoIndexado
    {

        #region Atributos Privados

        private Decimal _limiteCOL; //Cambios GZH 11092017 Inicia

        public Decimal LimiteCOL
        {
            get { return _limiteCOL; }
            set { _limiteCOL = value; }
        } //Cambios GZH 11092017 Finaliza

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       private DateTime _fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }

        private DateTime _fecha_ult_modificacion;

        public DateTime Fecha_ult_modificacion
        {
            get { return _fecha_ult_modificacion; }
            set { _fecha_ult_modificacion = value; }
        }
      
        private Decimal _limiteAD;
        
        public Decimal LimiteAD
        {
            get { return _limiteAD; }
            set { _limiteAD = value; }
        }

        private Decimal _limiteBD;
        
        public Decimal LimiteBD
        {
            get { return _limiteBD; }
            set { _limiteBD = value; }
        }

        private Decimal _limiteDOL;
        
        public Decimal LimiteDOL
        {
            get { return _limiteDOL; }
            set { _limiteDOL = value; }
        }

        private Decimal _limiteEUR; //Cambios GZH 23/08/2017

        public Decimal LimiteEUR //Cambios GZH 23/08/2017
        {
            get { return _limiteEUR; }
            set { _limiteEUR = value; }
        }

        private Colaborador _cajero;
        
        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        private Colaborador _usuario_creacion;

        public Colaborador Usuario_creacion
        {
            get { return _usuario_creacion; }
            set { _usuario_creacion = value; }
        }

        private Colaborador _usuario_modificacion;

        public Colaborador Usuario_modificacion
        {
            get { return _usuario_modificacion; }
            set { _usuario_modificacion = value; }
        }

        private int id;

        #endregion Atributos Privados

        #region Constructor de Clase

        public LimiteEfectivo(int id = 0, Colaborador cajero = null, DateTime? fecha_creacion = null, DateTime? fecha_ult_modificacion = null, Colaborador usuario_creacion = null,
                     Colaborador usuario_ult_modificacion = null, Decimal limiteAD = 0, Decimal limiteBD = 0, Decimal limiteDOL = 0, Decimal limiteEUR = 0, Decimal limiteCOL = 0)  //limiteEUR Cambio GZH 23/08/2017, Cambio COL GZH 11092017
        {
            this.DB_ID = id;

            _fecha_creacion = fecha_creacion ?? DateTime.Now; //importante revisar a profundidad asignacion si es nulo.
            _fecha_ult_modificacion = fecha_ult_modificacion ?? DateTime.Now;
            _cajero = cajero;
            _limiteAD = limiteAD;
            _limiteBD = limiteBD;
            _limiteCOL = limiteCOL; //Cambios GZH 11092017
            _limiteDOL = limiteDOL;
            _limiteEUR = limiteEUR; //Cambios GZH 23/08/2017
            _usuario_creacion = usuario_creacion;
            _usuario_modificacion = usuario_ult_modificacion;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos




        #endregion Métodos Públicos

        #region Overrides

        /*public override string ToString()
        {
            return SerieBolsa.ToString();
        }*/

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            LimiteEfectivo limiteefectivo = (LimiteEfectivo)obj;

            if ( ID != limiteefectivo.DB_ID) return false;

            return true;
        }

        #endregion Overrides

    }
}
