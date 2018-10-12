//
//  @ Project : 
//  @ File Name : Tula.cs
//  @ Date : 28/04/2011
//  @ Author : Erick Chavarría 
//

using System;

using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.ComponentModel;

namespace CommonObjects
{

    public class Tula : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        protected DateTime _fecha_ingreso;

        public DateTime Fecha_ingreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }

        protected Manifiesto _manifiesto;

        public Manifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected Colaborador _receptor;

        public Colaborador Receptor
        {
            get { return _manifiesto.Receptor; }
        }

        protected EmpresaTransporte _empresa;

        public EmpresaTransporte Empresa
        {
            get { return _manifiesto.Empresa; }
        }

        protected Grupo _grupo;
        public Grupo Grupo
        {
            get { return _manifiesto.Grupo; }
        }


        protected Cliente _cliente;
        public Cliente Cliente
        {
            get { return _manifiesto.Cliente; }
        }

       protected Colaborador _cajero_receptor;
        public Colaborador Cajero_Receptor
        {
            get { return _manifiesto.Cajero_Receptor; }
        }


        protected byte _caja;
        public byte Caja
        {
            get { return _manifiesto.Caja; }
        }

        private string _colaborador;

        public string Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }


        private string _header_card;

        public string HeaderCard
        {
            get { return _header_card; }
            set { _header_card = value; }
        }

        private BindingList<TulaNiquel> _tula_niquel;
        public BindingList<TulaNiquel> Niquel
        {
            get { return _tula_niquel; }
            set { _tula_niquel = value; }
        }
       
private int id;
private CommonObjects.Colaborador cajero;

        //PROA
        private BindingList<Deposito> _deposito;
        public BindingList<Deposito> Deposito
        {
            get { return _deposito; }
            set { _deposito = value; }
        }



        #endregion Atributos Privados

        #region Constructor de Clase

        public Tula(string codigo,
                    int id = 0,
                    Manifiesto manifiesto = null,
                    DateTime? fecha_ingreso = null, string headercard = "",
                    Colaborador receptor = null,
                    Cliente cliente = null
                    )
        {
            this.DB_ID = id;

            _codigo = codigo;
            _fecha_ingreso = fecha_ingreso ?? DateTime.Now;
            _manifiesto = manifiesto;
            _header_card = headercard;
            _receptor = receptor;
            _cliente = cliente;
            _deposito = new BindingList<Deposito>(); //Añadido por GZH 03022017
        }

        //public Tula(string codigo,
        //            int id = 0,
        //            Manifiesto manifiesto = null,
        //            DateTime? fecha_ingreso = null, string headercard = "",
        //            Colaborador receptor = null,
        //            Cliente cliente = null
        //            )
        //{
        //    this.DB_ID = id;

        //    _codigo = codigo;
        //    _fecha_ingreso = fecha_ingreso ?? DateTime.Now;
        //    _manifiesto = manifiesto;
        //    _header_card = headercard;
        //    _receptor = receptor;
        //    _cliente = cliente;
        //}

        public Tula() { }
        #endregion Constructor de Clase

        #region Métodos Públicos



        public void agregarDeposito(Deposito deposito)
        {
            _deposito.Add(deposito);
        }

        public void quitarDeposito(Deposito deposito)
        {
            _deposito.Remove(deposito);
        }


        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _codigo;
        }

        #endregion Overrides

    }

}
