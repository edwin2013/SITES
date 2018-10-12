
//
//  @ Project : 
//  @ File Name : ManifiestoColaborador.cs
//  @ Date : 26/02/2014
//  @ Author : Karla Vasquez J
//

using System;

using LibreriaAccesoDatos;


namespace CommonObjects
{
    public class ManifiestoColaborador : ObjetoIndexado
    {

        #region Atributos Privados

        protected Colaborador _cajero_receptor;

        public Colaborador Cajero_Receptor
        {
            get { return _cajero_receptor; }
            set { _cajero_receptor = value; }
        }

        protected Colaborador _cajero_reasignado;

        public Colaborador Cajero_Reasignado
        {
            get { return _cajero_reasignado; }
            set { _cajero_reasignado = value; }
        }

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Grupo _grupo;

        public Grupo Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        protected int _posicion;

        public int Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        protected Manifiesto _manifiesto;
        private byte posicion;
        private Colaborador cajero_receptor;
        private Manifiesto manifiesto;
   

        public Manifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        
        #endregion Atributos Privados

        #region Constructor de Clase

        public ManifiestoColaborador(int id = 0,
                             int posicion = 0,
                             Grupo grupo = null,
                             Manifiesto manifiesto = null,
                             Colaborador cajero_receptor = null,
                             Colaborador cajero_reasignado = null) 
        {
            this.DB_ID = id;
            this.Posicion = posicion;
            this.Manifiesto = manifiesto;
            this.Grupo = grupo;
            this.Cajero_Receptor = cajero_receptor;
            this.Cajero_Reasignado = cajero_reasignado;
        }

        public ManifiestoColaborador(int posicion = 0,Grupo grupo = null,Manifiesto manifiesto = null,Colaborador cajero_receptor = null)
        {
            this.Posicion = posicion;
            this.Manifiesto = manifiesto;
            this.Grupo = grupo;
            this.Cajero_Receptor = cajero_receptor;
        }



        public ManifiestoColaborador(int posicion = 0, Manifiesto manifiesto = null, Colaborador cajero_receptor = null)
        {
            this.Posicion = posicion;
            this.Manifiesto = manifiesto;
            this.Cajero_Receptor = cajero_receptor;
        }

        public ManifiestoColaborador(byte posicion, CommonObjects.Manifiesto manifiesto, Colaborador cajero_receptor)
        {
            // TODO: Complete member initialization
            this.posicion = posicion;
            this.manifiesto = manifiesto;
            this.cajero_receptor = cajero_receptor;
        }


        public ManifiestoColaborador(int posicion = 0, Grupo grupo = null, Manifiesto manifiesto = null, Colaborador cajero_receptor = null, Colaborador cajero_reasignado = null)
        {
            this.Posicion = posicion;
            this.Manifiesto = manifiesto;
            this.Grupo = grupo;
            this.Cajero_Receptor = cajero_receptor;
            this.Cajero_Reasignado = cajero_reasignado;
        }
        

        #endregion Constructor de Clase


        #region Métodos Públicos

        #endregion Métodos Públicos


        #region Overrides

        #endregion Overrides

    }
}