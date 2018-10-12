//
//  @ Project : 
//  @ File Name : EmpresaTransporte.cs
//  @ Date : 10/06/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class EmpresaTransporte : ObjetoIndexado
    {

        #region Atributos Privados

        public byte ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private string _nombre;
        private int id;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        private decimal _tarifa_regular;
        public decimal TarifaRegular
        {
            get { return _tarifa_regular; }
            set { _tarifa_regular = value; }
        }

        private decimal _tarifa_feriados;
        public decimal TarifaFeriados
        {
            get { return _tarifa_feriados; }
            set { _tarifa_feriados = value; }
        }

        private decimal _tope;
        public decimal Tope
        {
            get { return _tope; }
            set { _tope = value; }
        }

        private decimal _recargo;
        public decimal Recargo
        {
            get { return _recargo; }
            set { _recargo = value; }
        }

        private decimal _entrega_niquel;
        public decimal EntregaNiquel
        {
            get { return _entrega_niquel; }
            set { _entrega_niquel = value; }
        }


        private string _centrocostos;
        public string CentroCostos
        {
            get { return _centrocostos; }
            set { _centrocostos = value; }
        }


        private decimal _precio_unitario_mil_colones;
        public decimal PrecioUnitarioMilColones
        {
            set { _precio_unitario_mil_colones = value; }
            get { return _precio_unitario_mil_colones; }
        }

        private decimal _precio_unitario_mil_dolares;
        public decimal PrecioUnitarioMilDolares
        {
            get { return _precio_unitario_mil_dolares; }
            set { _precio_unitario_mil_dolares = value; }
        }

        private decimal _precio_unitario_pieza;
        
        public decimal PrecioUnitarioPieza
        {
            get { return _precio_unitario_pieza; }
            set { _precio_unitario_pieza = value; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public EmpresaTransporte(string nombre = "", byte id = 0)
        {
            this.DB_ID = id;

            _nombre = nombre;
            
        }

        public EmpresaTransporte(byte id = 0)
        {
            this.DB_ID = id;
        }



        public EmpresaTransporte()
        {
           
        }

      
        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        #endregion Overrides

    }

}
