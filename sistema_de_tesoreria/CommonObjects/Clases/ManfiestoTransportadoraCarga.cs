using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class ManfiestoTransportadoraCarga : ManifiestoTransportadora
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

        private BindingList<BolsaTransportadora> _lista_bolsas;
        public BindingList<BolsaTransportadora> ListaBolsas
        {
            get { return _lista_bolsas; }
            set { _lista_bolsas = value; }
        }

        private string _manifiesto;
        private int id;
        private BindingList<BolsaTransportadora> bolsas;
        
        public string _Manifiesto
        {
            get { return _manifiesto; }
            set { _serie_tula = value; }
        }


        private CargaSucursal _pedido;
        public CargaSucursal Pedido
        {
            get { return _pedido; }
            set { _pedido = value; }
        }
        
        #endregion Atributos Privados

        #region Constructor de Clase

        public ManfiestoTransportadoraCarga(
                                  DateTime fecha,
                                  BindingList<BolsaTransportadora> bolsas,
                                  Colaborador colaborador,
                                  string marchamo = "",
                                  int id = 0)
        {
            this.DB_ID = id;

            this.Colaborador = colaborador;
            this.Codigo = "";
            this.Marchamo = marchamo;
            this.Fecha = fecha;
            _lista_bolsas = bolsas;
               
        }

        public ManfiestoTransportadoraCarga(DateTime fecha)
        {
            // TODO: Complete member initialization
            this.Fecha = fecha;
        }

        public ManfiestoTransportadoraCarga(DateTime fecha, int id)
        {
            // TODO: Complete member initialization
            this.Fecha = fecha;
            this.id = id;
            this.DB_ID = id;
        }

       public ManfiestoTransportadoraCarga(DateTime fecha, int id, Colaborador colaborador)
       {
         // TODO: Complete member initialization
            this.Fecha = fecha;
            this.Colaborador = colaborador;
            this.id = id;
            this.DB_ID = id;
       }
    public ManfiestoTransportadoraCarga(BindingList<BolsaTransportadora> bolsas)
        {
            // TODO: Complete member initialization
            this.bolsas = bolsas;
        }

        public ManfiestoTransportadoraCarga()
        {
            // TODO: Complete member initialization
        }

        public ManfiestoTransportadoraCarga(int id)
        {
            // TODO: Complete member initialization
            this.ID = id;
        }

        public ManfiestoTransportadoraCarga(int id, string codigo)
        {
            // TODO: Complete member initialization
            this.DB_ID = id;
            this.Codigo = codigo;
        }


        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agrega una nueva BolsaTransportadora a la lista de BolsaTransportadora
        /// </summary>
        /// <param name="BolsaTransportadora">Objeto BolsaTransportadora con los datos de las BolsaTransportadora</param>
        public void agregarBolsa(BolsaTransportadora BolsaTransportadora)
        {
            _lista_bolsas.Add(BolsaTransportadora);
        }

        /// <summary>
        /// Quita una BolsaTransportadora de la lista de bolsas de sucursales
        /// </summary>
        /// <param name="BolsaTransportadora">Objeto BolsaTransportadora con los datos de las bolsas</param>
        public void quitarBolsa(BolsaTransportadora BolsaTransportadora)
        {
            _lista_bolsas.Remove(BolsaTransportadora);
        }

        #endregion Métodos Públicos

        #region Overrides
        public override string ToString()
        {
            return ID.ToString();
        }
        #endregion Overrides
    }
}
