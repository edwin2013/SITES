//
//  @ Project : 
//  @ File Name : CierreBoveda.cs
//  @ Date : 26/03/2012
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class CierreBovedaCajero : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        protected Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected DateTime _hora_inicio;

        public DateTime Hora_inicio
        {
            get { return _hora_inicio; }
            set { _hora_inicio = value; }
        }

        protected DateTime _hora_cierre;

        public DateTime Hora_cierre
        {
            get { return _hora_cierre; }
            set { _hora_cierre = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public CierreBovedaCajero(int id,
                                  Colaborador cajero,
                                  Colaborador digitador,
                                  Colaborador coordinador,
                                  DateTime fecha,
                                  DateTime hora_inicio,
                                  DateTime hora_cierre)
        {
            this.DB_ID = id;

            _cajero = cajero;
            _coordinador = coordinador;
            _fecha = fecha;
            _hora_inicio = hora_inicio;
            _hora_cierre = hora_cierre;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _cajero.ToString();
        }

        #endregion Overrides

    }

}
