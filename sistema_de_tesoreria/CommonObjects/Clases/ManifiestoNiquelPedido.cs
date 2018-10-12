using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class ManifiestoNiquelPedido : ManifiestoNiquel
    {
        #region Atributos Privados

        private string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

       
        private string _serie_tula;

        public string Serie_Tula
        {
            get { return _serie_tula; }
            set { _serie_tula = value; }
        }

        private Colaborador _colaborador;

        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        private BindingList<BolsaNiquel> _lista_bolsas;
        public BindingList<BolsaNiquel> ListaBolsas
        {
            get { return _lista_bolsas; }
            set { _lista_bolsas = value; }
        }

        private string _manifiesto;
        private int id;
        private BindingList<BolsaNiquel> bolsas;
        
        public string _Manifiesto
        {
            get { return _manifiesto; }
            set { _serie_tula = value; }
        }


        private BindingList<BolsaCompletaNiquel> _bolsas_completas;
        public BindingList<BolsaCompletaNiquel> BolsasCompletas
        {
            get { return _bolsas_completas; }
            set { _bolsas_completas = value; }
        }

        private PedidoNiquel _pedido;
        public PedidoNiquel Pedido
        {
            get { return _pedido; }
            set { _pedido = value; }
        }
        
        #endregion Atributos Privados

        #region Constructor de Clase

        public ManifiestoNiquelPedido(
                                  DateTime fecha,
                                  BindingList<BolsaNiquel> bolsas,
                                  Colaborador colaborador,
                                  string codigo = "",
                                  int id = 0)
        {
            this.DB_ID = id;

            this.Colaborador = colaborador;
            this.Codigo = codigo;
            this.Fecha = fecha;
            _lista_bolsas = bolsas;
               
        }

        public ManifiestoNiquelPedido(DateTime fecha)
        {
            // TODO: Complete member initialization
            this.Fecha = fecha;
        }

        public ManifiestoNiquelPedido(DateTime fecha, int id, string codigo)
        {
            // TODO: Complete member initialization
            this.Fecha = fecha;
            this.id = id;
            this.DB_ID = id;
            this.Codigo = codigo;
        }

       public ManifiestoNiquelPedido(DateTime fecha, int id, Colaborador colaborador, string codigo)
       {
         // TODO: Complete member initialization
            this.Fecha = fecha;
            this.Colaborador = colaborador;
            this.id = id;
            this.DB_ID = id;
            this.Codigo = codigo;
       }
    public ManifiestoNiquelPedido(BindingList<BolsaNiquel> bolsas)
        {
            // TODO: Complete member initialization
            this.bolsas = bolsas;
        }

        public ManifiestoNiquelPedido()
        {
            // TODO: Complete member initialization
        }

        public ManifiestoNiquelPedido(int id)
        {
            // TODO: Complete member initialization
            this.ID = id;
        }

        public ManifiestoNiquelPedido(int id, string codigo)
        {
            // TODO: Complete member initialization
            this.DB_ID = id;
            this.Codigo = codigo;
        }


        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agrega una nueva bolsa a la lista de bolsa
        /// </summary>
        /// <param name="bolsa">Objeto BolsaNiquel con los datos de las bolsa</param>
        public void agregarBolsa(BolsaNiquel bolsa)
        {
            _lista_bolsas.Add(bolsa);
        }

        /// <summary>
        /// Quita una bolsa de la lista de bolsas de sucursales
        /// </summary>
        /// <param name="bolsa">Objeto BolsaNiquel con los datos de las bolsas</param>
        public void quitarBolsa(BolsaNiquel bolsa)
        {
            _lista_bolsas.Remove(bolsa);
        }


        /// <summary>
        /// Agrega una bolsa 
        /// </summary>
        /// <param name="bolsa"></param>
        public void agregarBolsaCompleta(BolsaCompletaNiquel bolsa)
        {
            _bolsas_completas.Add(bolsa);
        }
        #endregion Métodos Públicos

        #region Overrides
        public override string ToString()
        {
            return Codigo.ToString();
        }
        #endregion Overrides
    }
}
