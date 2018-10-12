using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace CommonObjects.Clases
{
    public class ManifiestoSucursalCarga: ManifiestoSucursal
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

        private BindingList<Bolsa> _lista_bolsas;
        public BindingList<Bolsa> ListaBolsas
        {
            get { return _lista_bolsas; }
            set { _lista_bolsas = value; }
        }

        private string _manifiesto;
        private int id;
        private BindingList<Bolsa> bolsas;
        
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

        public ManifiestoSucursalCarga(
                                  DateTime fecha,
                                  BindingList<Bolsa> bolsas,
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

        public ManifiestoSucursalCarga(DateTime fecha)
        {
            // TODO: Complete member initialization
            this.Fecha = fecha;
        }

        public ManifiestoSucursalCarga(DateTime fecha, int id)
        {
            // TODO: Complete member initialization
            this.Fecha = fecha;
            this.id = id;
            this.DB_ID = id;
        }

       public ManifiestoSucursalCarga(DateTime fecha, int id, Colaborador colaborador)
       {
         // TODO: Complete member initialization
            this.Fecha = fecha;
            this.Colaborador = colaborador;
            this.id = id;
            this.DB_ID = id;
       }
    public ManifiestoSucursalCarga(BindingList<Bolsa> bolsas)
        {
            // TODO: Complete member initialization
            this.bolsas = bolsas;
        }

        public ManifiestoSucursalCarga()
        {
            // TODO: Complete member initialization
        }

        public ManifiestoSucursalCarga(int id)
        {
            // TODO: Complete member initialization
            this.ID = id;
        }

        public ManifiestoSucursalCarga(int id, string codigo)
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
        /// <param name="bolsa">Objeto Bolsa con los datos de las bolsa</param>
        public void agregarBolsa(Bolsa bolsa)
        {
            _lista_bolsas.Add(bolsa);
        }

        /// <summary>
        /// Quita una bolsa de la lista de bolsas de sucursales
        /// </summary>
        /// <param name="bolsa">Objeto Bolsa con los datos de las bolsas</param>
        public void quitarBolsa(Bolsa bolsa)
        {
            _lista_bolsas.Remove(bolsa);
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
