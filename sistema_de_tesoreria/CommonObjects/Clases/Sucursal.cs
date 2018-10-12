//
//  @ Project : 
//  @ File Name : Sucursal.cs
//  @ Date : 30/04/2012
//  @ Author : Erick Chavarría 
//

using CommonObjects.Clases;
using LibreriaAccesoDatos;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommonObjects
{

    public enum TipoSucursal : byte
    {
        Sucursal = 0,
        RapiBanco = 1,
        Caja_Empresarial = 2
    }



    public class Sucursal : ObjetoIndexado
    {

        #region Atributos Privados

        public short ID
        {
            get { return (short)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        protected short _codigo;

        public short Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        protected string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        protected Provincias _provincia;

        public Provincias Provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }


        protected TipoSucursal _tipo_sucursal;

        public TipoSucursal TipoSucursal
        {
            get { return _tipo_sucursal; }
            set { _tipo_sucursal = value; }
        }


        protected bool _externo;

        public bool Externo
        {
            get { return _externo; }
            set { _externo = value; }
        }

        protected EmpresaTransporte _empresa;

        public EmpresaTransporte Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }


        protected List<Dias> _dias_carga = new List<Dias>();
        private short id;
private   CommonObjects.TipoSucursal tipo;

        public List<Dias> Dias_carga
        {
            get { return _dias_carga; }
            set { _dias_carga = value; }
        }


        protected bool _caja_empresarial;
        public bool CajaEmpresarial
        {
            set { _caja_empresarial = value; }
            get { return _caja_empresarial; }
        }

        protected BindingList<TarifaPuntoVentaTransportadora> _tarifas;
        public BindingList<TarifaPuntoVentaTransportadora> Tarifas
        {
            get { return _tarifas; }
            set { _tarifas = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Sucursal(string nombre = "",
                        short id = 0,
                        string direccion = "",
                        Provincias provincia = Provincias.Alajuela,
                        TipoSucursal sucursal = TipoSucursal.Sucursal,
                        EmpresaTransporte transporte = null,
                        bool externo = false,
                        short codigo =0,
                        bool caja = false
            )
        {
            this.DB_ID = id;

            _externo = externo;
            _nombre = nombre;
            _direccion = direccion;
            _provincia = provincia;
            _tipo_sucursal = sucursal;
            _empresa = transporte;
            _codigo = codigo;
            _caja_empresarial = caja;

            _tarifas = new BindingList<TarifaPuntoVentaTransportadora>();
        }

        public Sucursal(short id)
        {
            // TODO: Complete member initialization
            this.DB_ID = id;

            _tarifas = new BindingList<TarifaPuntoVentaTransportadora>();
        }

public    Sucursal(short id,string nombre,CommonObjects.TipoSucursal tipo)
    {
        // TODO: Complete member initialization
this.DB_ID = id;
this.Nombre = nombre;
this.tipo = tipo;

_tarifas = new BindingList<TarifaPuntoVentaTransportadora>();
    }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un día de carga para la Sucursal.
        /// </summary>
        /// <param name="dia">Nuevo día a agregar</param>
        public void agregarDiaCarga(Dias dia)
        {
            _dias_carga.Add(dia);
        }

        /// <summary>
        /// Quitar un día de carga de la Sucursal
        /// </summary>
        /// <param name="dia">Día a quitar</param>
        public void quitarDiaCarga(Dias dia)
        {
            _dias_carga.Remove(dia);
        }

        /// <summary>
        /// Agrega una tarifa a la sucursal
        /// </summary>
        /// <param name="t">Objeto TarifaPuntoVentaTransportadora</param>
        public void agregarTarifa(TarifaPuntoVentaTransportadora t)
        {
            _tarifas.Add(t);
        }

        /// <summary>
        /// Elimina una tarifa de la sucursal 
        /// </summary>
        /// <param name="t">Objeto TarifaPuntoVentaTransportadora con los datos de la tarifa</param>
        public void quitarTarifa(TarifaPuntoVentaTransportadora t)
        {
            _tarifas.Remove(t);
        }
        #endregion Métodos Públicos
      
        #region Overrides

        public override string ToString()
        {
            return  _nombre.ToString();
        }

        #endregion Overrides

    }

}
