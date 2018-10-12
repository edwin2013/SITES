using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class CorteCheque : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected BindingList<Cheque> _cheques = new BindingList<Cheque>();
        public BindingList<Cheque> Cheques
        {
            set { _cheques = value; }
            get { return _cheques; }
        }


        protected int _numero_corte;
        public int NumeroCorte
        {
            set { _numero_corte = value; }
            get { return _numero_corte; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public CorteCheque(int id = 0, int numero = 0)
        {
            this.DB_ID = id;
            this._numero_corte = numero; 
            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agrega un cheque a la lista de cheques.
        /// </summary>
        /// <param name="c">Objeto Cheque con los datos del cheque.</param>
        public void agregarDatos(Cheque c)
        {
            this._cheques.Add(c);
        }


        /// <summary>
        /// Elimina un cheque de la lista de cheques. 
        /// </summary>
        /// <param name="c">objeto cheque con los datos del cheque</param>
        public void quitarDatos(Cheque c)
        {
            this._cheques.Remove(c);
        }
 
        #endregion Métodos Públicos

        #region Overrides

        //public override string ToString()
        //{
        //    return _usuario_entrega.ToString();
        //}

        #endregion Overrides
    }
}
