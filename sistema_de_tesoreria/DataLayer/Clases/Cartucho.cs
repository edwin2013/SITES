//
//  @ Project : 
//  @ File Name : Cartucho.cs
//  @ Date : 30/07/2012
//  @ Author : César Mendoza
//

using LibreriaAccesoDatos;
using System.ComponentModel;
using CommonObjects.Clases;

namespace CommonObjects
{

    public enum EstadosCartuchos : byte
    {
        Bueno = 0,
        Malo = 1,
        EntregadoTaller = 2,
        NoRecuperable = 3
    }

    public class Cartucho : ObjetoIndexado
    {  

        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        protected TiposCartucho _tipo;

        public TiposCartucho Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }

        protected ProveedorCartucho _proveedor;

        public ProveedorCartucho Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        protected EmpresaTransporte _transportadora;

        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }

        protected EstadosCartuchos _estado;

        public EstadosCartuchos Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private BindingList<FallaCartucho> _fallas = new BindingList<FallaCartucho>();

        public BindingList<FallaCartucho> Fallas
        {
            get { return _fallas; }
            set { _fallas = value; }
        }


        public string empresa
        {
            get { return Transportadora.ToString(); }
        }

        public string proveedorCartucho
        {
            get { return Proveedor.ToString(); }
        }

        public string estadocartucho
        {
            get {
               // return Estado.ToString();
                switch (Estado)
                {
                    case EstadosCartuchos.Malo:
                        return "Malo en Tesorería";
                    case EstadosCartuchos.Bueno:
                        return "Bueno";
                    case EstadosCartuchos.EntregadoTaller:
                        return "Malo en Taller";
                    case EstadosCartuchos.NoRecuperable:
                        return "No Recuperable";
                default:
                return "Bueno";
                
                }
            
            }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Cartucho() { }
        public Cartucho(string numero,
                        int id = 0,
                        TiposCartucho tipo = TiposCartucho.Indefinido,
                        Denominacion denominacion = null,
                        EmpresaTransporte transportadora = null,
                        ProveedorCartucho provedor = null,
                        EstadosCartuchos estado = EstadosCartuchos.Bueno)
        {
            this.DB_ID = id;

            _numero = numero;
            _tipo = tipo;
            _denominacion = denominacion;
            _proveedor = provedor;
            _transportadora = transportadora;
            _estado = estado;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
        public void agregarFalla(FallaCartucho falla)
        {
            _fallas.Add(falla);
        }

        public void quitarFalla(FallaCartucho nombre)
        {
            _fallas.Remove(nombre);
        }
        #endregion Métodos Públicos

        #region Metodos Privados
        

        #endregion Metodos Privados

        #region Overrides

        public override string ToString()
        {
            return _numero.ToString();
        }

        

        #endregion Overrides

    }

}
