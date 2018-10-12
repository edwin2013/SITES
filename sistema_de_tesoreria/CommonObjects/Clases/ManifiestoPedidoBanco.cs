using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class ManifiestoPedidoBanco:ManifiestoBanco
    {
        #region Atributos Privados


        private BindingList<BolsaBanco> _serie_tula = new BindingList<BolsaBanco>();

        public BindingList<BolsaBanco> Serie_Tula
        {
            get { return _serie_tula; }
            set { _serie_tula = value; }
        }

        private PedidoBancos _pedido = new PedidoBancos();
        public PedidoBancos Pedido
        {
            set { _pedido = value; }
            get { return _pedido; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ManifiestoPedidoBanco(DateTime? fecha = null,
                                  BindingList<BolsaBanco> bolsas = null,
                                  string marchamo = "",
                                  int id = 0)
        {
            this.DB_ID = id;

            this.Fecha = fecha ?? DateTime.Now;
            _serie_tula = bolsas;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agrega una bolsa al manifiesto
        /// </summary>
        /// <param name="bolsa">Objeto BolsaBanco con los datos de la bolsa a ligar</param>
        public void agregarBolsa(BolsaBanco bolsa)
        {
            _serie_tula.Add(bolsa);
        }


        /// <summary>
        /// Quitar una bolsa del manifiesto
        /// </summary>
        /// <param name="bolsa"></param>
        public void quitarBolsa(BolsaBanco bolsa)
        {
            _serie_tula.Remove(bolsa);
        }

        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides
    }
}
