using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class RegistroPenalidad
    {
        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Colaborador _colaborador;

        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        
        private DateTime _fecha_registro;

        public DateTime Fecha_Registro
        {
            get { return _fecha_registro; }
            set { _fecha_registro = value; }
        }

        

        private bool _pronto_aviso;

        public bool Pronto_Aviso
        {
            get { return _pronto_aviso; }
            set { _pronto_aviso = value; }
        }

        
        private PuntoVenta _punto_venta;

        public PuntoVenta Punto_Venta
        {
            get{return _punto_venta;}
            set{ _punto_venta = value;}
        }

        private EmpresaTransporte _transportadora;
        public EmpresaTransporte Transportadora
        {
            get{ return _transportadora; }
            set{ _transportadora = value; }
        }


        private Penalidad _penalidad;

        public Penalidad Penalidad
        {
            get{return _penalidad;}
            set{_penalidad = value;}
        }

        public Cliente Cliente
        {
            get { return _punto_venta.Cliente; }
        }

        public TipoPenalidad TipoPenalidad
        {
            get { return _penalidad.TipoPenalidad; }
        }


        protected Decimal _tarifa;
        public Decimal Tarifa
        {
            get { return _tarifa; }
            set { _tarifa = value; }
        }

        protected double _nivel_servicio;
        public double NivelS
        {
            get { return _nivel_servicio; }
            set { _nivel_servicio = value; }
        }

        
      

        #endregion Atributos Privados

        #region Constructor de Clase

        public RegistroPenalidad(int id = 0,
                                  Colaborador colaborador = null,
                                  DateTime? fecha_registro = null,
                                  bool pronto_aviso = false,
                                  PuntoVenta punto = null,
                                  Penalidad penalidad = null,
                                  EmpresaTransporte transportadora = null,
                                  Decimal tarifa = 0,
                                  double nivel_s = 0)
        {
            _id = id;
            _colaborador = colaborador;

            _fecha_registro = fecha_registro ?? DateTime.MinValue;
            _transportadora = transportadora;
            _penalidad = penalidad;
            _punto_venta = punto;
            _pronto_aviso = pronto_aviso;
            _nivel_servicio = nivel_s;
        }

        public RegistroPenalidad() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

      

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _penalidad.Descripcion + "-" + _transportadora.Nombre;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            RegistroPenalidad registro = (RegistroPenalidad)obj;

            if (_id != registro.Id) return false;

            return true;
        }

        #endregion Overrides
    }
}
