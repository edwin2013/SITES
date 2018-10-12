using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class FacturacionTransportadora : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        protected EmpresaTransporte _empresa_encargada;

        public EmpresaTransporte Empresa_encargada
        {
            get { return _empresa_encargada; }
            set { _empresa_encargada = value; }
        }

        protected PuntoVenta _punto_venta;

        public PuntoVenta PuntoVenta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }

       
        

        protected DateTime _fecha;
        public DateTime  Fecha
        {
            set { _fecha = value; }
            get { return _fecha; }
        }


        protected DateTime _fecha_fin;
        public DateTime FechaFin
        {
            set { _fecha_fin = value; }
            get { return _fecha_fin; }
        }

        protected string _observaciones;
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }


        protected Colaborador _colaborador_registro;

        public Colaborador ColaboradoRegistro
        {
            get { return _colaborador_registro; }
            set { _colaborador_registro = value; }
        }


        protected BindingList<CategoriaFacturacionTransportadora> _lista_categoria = new BindingList<CategoriaFacturacionTransportadora>();
        public BindingList<CategoriaFacturacionTransportadora> ListaCategoria
        {
            get { return _lista_categoria; }
            set { _lista_categoria = value; }
        }

        
        #endregion Atributos Privados

        #region Constructor de Clase

        public FacturacionTransportadora(int id = 0,
                   Cliente cliente = null, 
                   PuntoVenta punto = null,
                   DateTime ? fecha = null,
                   DateTime? fecha_fin = null,
                   EmpresaTransporte transportadora = null,
                   string observaciones = "")
        {
            this.DB_ID = id;

            _cliente = cliente;
            _punto_venta = punto;
            _empresa_encargada = transportadora;
            _observaciones = observaciones;
            _fecha = fecha ?? DateTime.Now;
            _fecha_fin = fecha_fin ?? DateTime.Now;
            
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agrega una categoria a la lista de datos por facturar
        /// </summary>
        /// <param name="categoria">Objeto CategoriaFacturacionTransportadora con los datos d ela categoria a agregar</param>
        public void agregarCategoria(CategoriaFacturacionTransportadora categoria)
        {
            this._lista_categoria.Add(categoria);
        }


        public void quitarCategoria(CategoriaFacturacionTransportadora categoria)
        {
            this._lista_categoria.Remove(categoria);
        }

        #endregion Métodos Públicos

        #region Overrides

        //public override string ToString()
        //{
            
        //    //if (_codigo == null || _codigo.Equals(string.Empty))
        //    //    return "#" + _cliente.ToString();
        //    //else
        //    //    return "#" + _cliente.ToString() + " - " + _codigo;

        //}

        #endregion Overrides
    }
}
