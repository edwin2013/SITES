//
//  @ Project : 
//  @ File Name : CargaEmergenciaATMFull.cs
//  @ Date : 20/02/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class CargaEmergenciaATMFull : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected ATM _atm;

        public ATM ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }

        protected DateTime _fecha_envio;

        public DateTime Fecha_envio
        {
            get { return _fecha_envio; }
            set { _fecha_envio = value; }
        }

        protected DateTime? _fecha_carga;

        public DateTime? Fecha_carga
        {
            get { return _fecha_carga; }
            set { _fecha_carga = value; }
        }

        protected ManifiestoATMFull _manifiesto;

        public ManifiestoATMFull Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected bool _ena;

        public bool ENA
        {
            get { return _ena; }
            set { _ena = value; }
        }

        protected bool _descargada;

        public bool Descargada
        {
            get { return _descargada; }
            set { _descargada = value; }
        }

        public string Codigo_manifiesto
        {
            get { return _manifiesto.Codigo; }
        }

        public string Codigo_marchamo
        {
            get { return _manifiesto.Marchamo; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public CargaEmergenciaATMFull(DateTime fecha_envio,
                                      ManifiestoATMFull manifiesto,
                                      bool ena,
                                      int id = 0,
                                      DateTime? fecha_carga = null,
                                      ATM atm = null,
                                      bool descargada = false)
        {
            this.DB_ID = id;

            _atm = atm;
            _manifiesto = manifiesto;
            _fecha_envio = fecha_envio;
            _fecha_carga = fecha_carga;
            _ena = ena;
            _descargada = descargada;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        
        #endregion Métodos Públicos

        #region Métodos Privados

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides

    }

}
