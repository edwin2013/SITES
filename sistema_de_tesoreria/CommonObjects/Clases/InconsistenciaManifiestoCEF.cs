//
//  @ Project : 
//  @ File Name : InconsistenciaManifiestoCEF.cs
//  @ Date : 18/10/2011
//  @ Author : Erick Chavarría 

using System;
using System.ComponentModel;

using System.Text;

namespace CommonObjects
{

    public class InconsistenciaManifiestoCEF
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private ManifiestoCEF _manifiesto;

        public ManifiestoCEF Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        private Camara _camara;

        public Camara Camara
        {
            get { return _camara; }
            set { _camara = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private decimal _monto_colones_reportado;

        public decimal Monto_colones_reportado
        {
            get { return _monto_colones_reportado; }
            set { _monto_colones_reportado = value; }
        }

        private decimal _monto_dolares_reportado;

        public decimal Monto_dolares_reportado
        {
            get { return _monto_dolares_reportado; }
            set { _monto_dolares_reportado = value; }
        }


        private decimal _monto_euros_reportado;

        public decimal Monto_euros_reportado
        {
            get { return _monto_euros_reportado; }
            set { _monto_euros_reportado = value; }
        }

        private decimal _monto_total_reportado;

        public decimal Monto_total_reportado
        {
            get { return _monto_total_reportado; }
            set { _monto_total_reportado = value; }
        }

        private decimal _monto_total_real;

        public decimal Monto_total_real
        {
            get { return _monto_total_real; }
            set { _monto_total_real = value; }
        }

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public InconsistenciaManifiestoCEF(int id, ManifiestoCEF manifiesto, Camara camara, DateTime fecha,
                                           decimal monto_colones_reportado, decimal monto_dolares_reportado,
                                           decimal monto_total_reportado, decimal monto_total_real, string comentario, decimal monto_euros_reportado)
        {
            _id = id;
            _manifiesto = manifiesto;
            _camara = camara;
            _fecha = fecha;
            _monto_colones_reportado = monto_colones_reportado;
            _monto_dolares_reportado = monto_dolares_reportado;
            _monto_total_reportado = monto_total_reportado;
            _monto_total_real = monto_total_real;
            _comentario = comentario;
            _monto_euros_reportado = monto_euros_reportado;
        }


        public InconsistenciaManifiestoCEF(ManifiestoCEF manifiesto, Camara camara, DateTime fecha, decimal monto_colones_reportado, 
                                           decimal monto_dolares_reportado, decimal monto_total_reportado, decimal monto_total_real,
                                           string comentario, decimal monto_euros_reportado)
        {
            _manifiesto = manifiesto;
            _camara = camara;
            _fecha = fecha;
            _monto_colones_reportado = monto_colones_reportado;
            _monto_dolares_reportado = monto_dolares_reportado;
            _monto_euros_reportado = monto_euros_reportado;
            _monto_total_reportado = monto_total_reportado;
            _monto_total_real = monto_total_real;
            _comentario = comentario;
        }

        public InconsistenciaManifiestoCEF(int id)
        {
            _id = id;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _manifiesto.Codigo;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            InconsistenciaManifiestoCEF inconsistencia = (InconsistenciaManifiestoCEF)obj;

            if (_id != inconsistencia.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
