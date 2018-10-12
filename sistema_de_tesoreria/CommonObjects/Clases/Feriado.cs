using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class Feriado: ObjetoIndexado
    {

        #region Atributos Privados

        protected int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        protected string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private DateTime _fecha_inicio;

        public DateTime Fecha_inicio
        {
            get { return _fecha_inicio; }
            set { _fecha_inicio = value; }
        }

        private DateTime _fecha_finalizacion;

        public DateTime Fecha_finalizacion
        {
            get { return _fecha_finalizacion; }
            set { _fecha_finalizacion = value; }
        }

       

        #endregion Atributos Privados

        #region Constructor de Clase

        public Feriado(int id, string descripcion, DateTime fecha_inicio, DateTime fecha_finalizacion)
        {
            _id = id;
            _descripcion = descripcion;
            _fecha_inicio = fecha_inicio;
            _fecha_finalizacion = fecha_finalizacion;
        }

        public Feriado(string descripcion, DateTime fecha_inicio, DateTime fecha_finalizacion)
        {
            _descripcion = descripcion;
            _fecha_inicio = fecha_inicio;
            _fecha_finalizacion = fecha_finalizacion;
        }

        public Feriado(int id)
        {
            _id = id;
        }

        public Feriado() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        

        #endregion Métodos Públicos
    }
}
