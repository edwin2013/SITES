using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{
    public enum TipoEntrega : byte
    {
        RecibidoBlindado = 1,
        EntregaBlindado = 2,
    }
    
    public abstract class RecepcionEntregaCargas : ObjetoIndexado
    {
         #region Atributos Privados

        public virtual int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

       
        protected DateTime _hora_registro;

        public virtual DateTime Hora_Registro
        {
            get { return _hora_registro; }
            set { _hora_registro = value; }
        }

        
        protected string _observaciones;

        public virtual string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }



        protected Colaborador _colabaroador_registro;

        public virtual Colaborador ColabaoradorRegistro
        {
            set { _colabaroador_registro = value; }
            get { return _colabaroador_registro; }
        }

        protected TipoEntrega _tipo;
        public virtual TipoEntrega TipoEntrega
        {
            set { _tipo = value; }
            get { return _tipo; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase


        public RecepcionEntregaCargas(TipoEntrega tipo, Colaborador usuarioverificacion = null, string observaciones = "", DateTime? Fecha = null, int id = 0)
        {
            this.DB_ID = id;
            Hora_Registro = Fecha ?? DateTime.Now;
            ColabaoradorRegistro = usuarioverificacion;
            TipoEntrega = tipo;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Métodos Privados

        #endregion Métodos Privados

        #region Overrides

        #endregion Overrides
    }
}
