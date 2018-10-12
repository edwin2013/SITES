//
//  @ Project : 
//  @ File Name : ManifiestoATMFull.cs
//  @ Date : 25/02/2012
//  @ Author : Erick Chavarría 
//

using System;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class ManifiestoATMFull : ManifiestoATM
    {

        #region Atributos Privados

        protected string _marchamo_adicional_ena;

        public string Marchamo_adicional_ena
        {
            get { return _marchamo_adicional_ena; }
            set { _marchamo_adicional_ena = value; }
        }

        protected string _marchamo_ena_a;

        public string Marchamo_ena_a
        {
            get { return _marchamo_ena_a; }
            set { _marchamo_ena_a = value; }
        }

        protected string _marchamo_ena_b;

        public string Marchamo_ena_b
        {
            get { return _marchamo_ena_b; }
            set { _marchamo_ena_b = value; }
        }


        private string _bolsa_rechazo;

        public string Bolsa_rechazo
        {
            get { return _bolsa_rechazo; }
            set { _bolsa_rechazo = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ManifiestoATMFull(string codigo,
                                 string marchamo,
                                 DateTime fecha,
                                 string marchamo_adicional_ena,
                                 string marchamo_ena_a,
                                 string marchamo_ena_b,
                                 string bolsa_rechazo,
                                 int id = 0)
        {
            this.DB_ID = id;

            this.Codigo = codigo;
            this.Marchamo = marchamo;
            this.Fecha = fecha;

            _marchamo_adicional_ena = marchamo_adicional_ena;
            _marchamo_ena_a = marchamo_ena_a;
            _marchamo_ena_b = marchamo_ena_b;
            _bolsa_rechazo = bolsa_rechazo;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Overrides

        #endregion Overrides

    }

}
