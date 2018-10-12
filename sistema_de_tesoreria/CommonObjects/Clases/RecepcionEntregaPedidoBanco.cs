using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.ComponentModel;

namespace CommonObjects.Clases
{

    public class RecepcionEntregaPedidoBanco : RecepcionEntregaCargas
    {
        #region Atributos Privados

      
        protected BindingList<PedidoBancos> _cargas = new BindingList<PedidoBancos>();

        public BindingList<PedidoBancos> Cargas
        {
            get { return _cargas; }
            set { _cargas = value; }
        }


        #endregion Atributos Privados

        #region Constructor de Clase


        public RecepcionEntregaPedidoBanco(TipoEntrega tipo, Colaborador usuarioverificacion = null, BindingList<PedidoBancos> listacargas = null, string observaciones = "", DateTime? Fecha = null, int id = 0): base(tipo,usuarioverificacion, observaciones,Fecha,id)
        {
            this.DB_ID = id;
            Hora_Registro = Fecha ?? DateTime.Now;
            ColabaoradorRegistro = usuarioverificacion;
            Cargas = listacargas;
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
