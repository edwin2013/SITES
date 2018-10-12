using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class MaximasCantidades : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected int _tulas;

        public int Tulas
        {
            get { return _tulas; }
            set { _tulas = value; }
        }


        protected int _bolsas_completas;

        public int BolsasCompletas
        {
            get { return _bolsas_completas; }
            set { _bolsas_completas = value; }
        }


        protected EmpresaTransporte _empresa;
        public EmpresaTransporte EmpresaTransportadora
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
      
        #endregion Atributos Privados

        #region Constructor de Clase

        public MaximasCantidades(int id = 0, int tulas = 0, int bolsas = 0, EmpresaTransporte emp = null)
        {
            this.DB_ID = id;

            _tulas = tulas;
            _bolsas_completas = bolsas;
            _empresa = emp;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

     
        #endregion Overrides
    }
}
