//
//  @ Project : 
//  @ File Name : Planilla.cs
//  @ Date : 17/12/2013
//  @ Author : Yolanda Mora
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibreriaAccesoDatos;
using System.Collections.Generic;
using CommonObjects.Clases;

namespace CommonObjects
{
    public class Planilla: ObjetoIndexado
    {
        #region Atributos Privados

        protected string _manifiesto;
        public string manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected string _tula;

        public string Tula
        {
            get { return _tula; }
            set { _tula = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected EmpresaTransporte _empresa;

        public EmpresaTransporte Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        protected Grupo _grupo;

        public Grupo Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }


        protected PuntoAtencion _punto_atencion;
        public PuntoAtencion PuntoAtencion
        {
            get { return _punto_atencion; }
            set { _punto_atencion = value; }
        }

        protected int _id_punto_venta;
        public int IDPuntoVenta
        {
            get { return _id_punto_venta; }
            set { _id_punto_venta = value; }
        }

        protected decimal _monto_tula;
        public decimal MontoTula
        {
            get { return _monto_tula; }
            set { _monto_tula = value; }
        }

        protected decimal _tarifa;
        public decimal Tarifa
        {
            get { return _tarifa; }
            set { _tarifa = value; }
        }

        protected decimal _recargo;
        public decimal Recargo
        {
            get { return _recargo; }
            set { _recargo = value; }
        }

        protected decimal _total;
        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        protected decimal _monto_planilla;
        private EmpresaTransporte transporte;
        private DateTime Fecha_2;
        private string manifiesto_2;
        private decimal Monto_Planilla;
        private decimal Monto_Tula;
        private int id_Pdv;
        private short PA;
        public decimal MontoPlanilla
        {
            get { return _monto_planilla; }
            set { _monto_planilla = value; }
        }
       
        #endregion Atributos Privados


         #region Constructor de Clase

        public Planilla(string tula = "",
                        string manifiesto = "",
                        EmpresaTransporte transporte = null,
                        DateTime? Fecha = null,
                        //Grupo Grupo = null,
                        PuntoAtencion PA = null,
                        decimal Monto_Tula = 0,
                        decimal Monto_Planilla =0,
                        decimal Tarifa=0,
                        decimal Recargo=0,
                        decimal Total=0,
                        int id_Pdv=0
                        
            )
        {
            _manifiesto = manifiesto;
            _tula = tula;
            _empresa = transporte;
            _fecha = Fecha ?? DateTime.MinValue;
            //_grupo = Grupo;
            _punto_atencion = PA;
            _monto_tula=Monto_Tula;
            _monto_planilla=Monto_Planilla;
            _tarifa = Tarifa;
            _recargo = Recargo;
            _total = Total;
            _id_punto_venta = id_Pdv;

         }

        public Planilla()//(short id)
        {
            // TODO: Complete member initialization
           // this.DB_ID = id;
        }

          #endregion Constructor de Clase
    }
}
