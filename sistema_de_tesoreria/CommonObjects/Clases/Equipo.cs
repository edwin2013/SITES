using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class Equipo : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (byte)this.DB_ID; }
            set { this.DB_ID = value; }
        }


        private int id;

        private string _serie;

        public string Serie
        {
            get { return _serie; }
            set { _serie = value; }
        }

        private TipoEquipo _tipo_equipo;

        public TipoEquipo TipoEquipo
        {
            get { return _tipo_equipo; }
            set { _tipo_equipo = value; }
        }


        private string _id_asignacion;

        public string IdAsignacion
        {
            get { return _id_asignacion; }
            set { _id_asignacion = value; }
        }


        private string _codigo_barras;

        public string CodigoBarras
        {
            get { return _codigo_barras; }
            set { _codigo_barras = value; }
        }



        private ATM _atm;

        public ATM ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }


        private Colaborador _colaborador;

        public Colaborador Asginado
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }



        private Manojo _manojo;

        public Manojo Manojo
        {
            get { return _manojo; }
            set { _manojo = value; }
        }


        private Colaborador _colaborador_registro;

        public Colaborador ColaboradorRegistro
        {
            set { _colaborador_registro = value; }
            get { return _colaborador_registro; }
        }


        private Puestos _puesto;
        public Puestos Puestos
        {
            set { _puesto = value; }
            get { return _puesto; }
        }

        protected int _id_asignacion_equipo;

        public int IDAsignacionEquipo
        {
            get { return _id_asignacion_equipo; }
            set { _id_asignacion_equipo = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Equipo(int id = 0, string serie = "",TipoEquipo tipoequipo = null, string idasignacion = "",string codigobarras = "",
            ATM atm = null, Colaborador col = null, Manojo man = null, int idasignacionequipo = 0, Puestos p = 0)
        {
            this.DB_ID = id;
            
            _serie = serie;
            _tipo_equipo = tipoequipo;
            _id_asignacion = idasignacion;
            _codigo_barras = codigobarras;
            _atm = atm;
            _colaborador = col;
            _manojo = man;
            _id_asignacion_equipo = idasignacionequipo;
            _puesto = p;
        }

        public Equipo(byte id = 0)
        {
            this.DB_ID = id;
        }


        public Equipo()
        {
           
        }

      
        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _tipo_equipo.Descripcion + "-" + _serie;
        }

        #endregion Overrides
    }
}
