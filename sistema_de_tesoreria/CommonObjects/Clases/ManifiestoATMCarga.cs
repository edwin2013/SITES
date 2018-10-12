//
//  @ Project : 
//  @ File Name : ManifiestoATMCarga.cs
//  @ Date : 09/05/2012
//  @ Author : Erick Chavarría 
//

using System;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class ManifiestoATMCarga : ManifiestoATM
    {

        #region Atributos Privados

        private string _bolsa_rechazo;

        public string Bolsa_rechazo
        {
            get { return _bolsa_rechazo; }
            set { _bolsa_rechazo = value; }
        }

        private string _marchamo_adicional;

        public string Marchamo_adicional
        {
            get { return _marchamo_adicional; }
            set { _marchamo_adicional = value; }
        }
        
        #endregion Atributos Privados

        #region Constructor de Clase

        public ManifiestoATMCarga(string codigo,
                                  string marchamo,
                                  DateTime fecha,
                                  string bolsa_rechazo,
                                  string marchamo_adicional,
                                  int id = 0)
        {
            this.DB_ID = id;

            this.Codigo = codigo;
            this.Marchamo = marchamo;
            this.Fecha = fecha;

            _bolsa_rechazo = bolsa_rechazo;
            _marchamo_adicional = marchamo_adicional;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
