using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ProcesamientoBajoVolumen : ObjetoIndexado
    {

        #region Atributos Privados

        protected Decimal _montoCOL; //Cambio GZH 11092017 inicia

        public Decimal MontoCOL
        {
            get { return _montoCOL; }
            set { _montoCOL = value; }
        } //Cambio GZH 11092017 finaliza

        protected Boolean _excedelimiteCOL; //Cambio GZH 11092017 inicia

        public Boolean ExcedelimiteCOL
        {
            get { return _excedelimiteCOL; }
            set { _excedelimiteCOL = value; }
        } //Cambio GZH 11092017 finaliza

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }        

        protected Decimal _montoDOL;

        public Decimal MontoDOL
        {
            get { return _montoDOL; }
            set { _montoDOL = value; }
        }

        protected Decimal _montoBD;

        public Decimal MontoBD
        {
            get { return _montoBD; }
            set { _montoBD = value; }
        }


        protected Decimal _montoAD;

        public Decimal MontoAD
        {
            get { return _montoAD; }
            set { _montoAD = value; }
        }

        protected Decimal _montoEUR; //cambio GZH 16082017

        public Decimal MontoEUR //cambio GZH 16082017
        {
            get { return _montoEUR; }
            set { _montoEUR = value; }
        }

        protected Colaborador _colaborador_asociado;

        public Colaborador ColaboradorAsociado
        {
            get { return _colaborador_asociado; }
            set { _colaborador_asociado = value; }
        }

        protected DateTime _fecha_procesamiento;
        public DateTime Fecha_Procesamiento
        {
            set { _fecha_procesamiento = value; }
            get { return _fecha_procesamiento; }
        }

        protected ProcesamientoBajoVolumenManifiesto _manifiesto;

        public ProcesamientoBajoVolumenManifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }        

        protected Camara _camara;

        public Camara Camara
        {
            get { return _camara; }
            set { _camara = value; }
        }

        protected BindingList<ProcesamientoBajoVolumenManifiesto> _lista_manifiestos;
        public BindingList<ProcesamientoBajoVolumenManifiesto> ListaManifiestos
        {
            get { return _lista_manifiestos; }
            set { _lista_manifiestos = value; }
        }

        protected Boolean _excedelimite;

        public Boolean Excedelimite
        {
            get { return _excedelimite; }
            set { _excedelimite = value; }
        }

        protected Boolean _excedelimiteBD;

        public Boolean ExcedelimiteBD
        {
            get { return _excedelimiteBD; }
            set { _excedelimiteBD = value; }
        }

        protected Boolean _excedelimiteAD;

        public Boolean ExcedelimiteAD
        {
            get { return _excedelimiteAD; }
            set { _excedelimiteAD = value; }
        }

        protected Boolean _excedelimiteDOL;

        public Boolean ExcedelimiteDOL
        {
            get { return _excedelimiteDOL; }
            set { _excedelimiteDOL = value; }
        }

        protected Boolean _excedelimiteEUR; //cambio GZH 16082017

        public Boolean ExcedelimiteEUR //cambio GZH 16082017
        {
            get { return _excedelimiteEUR; }
            set { _excedelimiteEUR = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ProcesamientoBajoVolumen(int ID = 0, Colaborador cajero = null, BindingList<ProcesamientoBajoVolumenManifiesto> manifiestos = null, Camara camara = null,
            DateTime? fecha_procesamiento = null, Decimal montoBD = 0, Decimal montoDOL = 0, Decimal montoAD = 0, bool excedelimite = false, bool excedelimiteAD = false, bool excedelimiteBD = false,
            bool excedelimiteDOL = false, Decimal montoEUR = 0, bool excedelimiteEUR = false, Decimal montoCOL = 0, bool excedelimiteCOL = false) //Cambio GZH 11092017
        {
            this.DB_ID = ID;
            _colaborador_asociado = cajero;
            _montoAD = montoAD;
            _montoBD = montoBD;
            _montoDOL = montoDOL;
            _montoCOL = montoCOL; //Cambio GZH 11092017
            _excedelimiteAD = excedelimiteAD;
            _excedelimiteBD = excedelimiteBD;
            _excedelimiteCOL = excedelimiteCOL; //Cambio GZH 11092017
            _excedelimiteDOL = excedelimiteDOL;
            _excedelimite = excedelimite;
            _lista_manifiestos = manifiestos;
            _camara = camara;
            _fecha_procesamiento = fecha_procesamiento ?? DateTime.Now;
            _montoEUR = montoEUR; //cambio GZH 16082017
            _excedelimiteEUR = excedelimiteEUR;             //cambio GZH 16082017

        }



        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        /*public override string ToString()
        {
            return _numero_cuenta.ToString();
        }*/

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            ProcesamientoBajoVolumen procesamientobajovolumen = (ProcesamientoBajoVolumen)obj;

            if (ID != procesamientobajovolumen.DB_ID) return false;

            return true;
        }

        #endregion Overrides

        
    }
}
