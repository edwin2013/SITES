using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{

    public enum TipoCheque : int
    {
        Cheques_Locales = 0, 
        Cheques_BAC = 1,
        Cheques_Exterior = 2,
        Cupones = 3, 
        Americheck = 4,
        Otros = 5
    }

    public class Cheque: ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }


        protected DateTime _hora_registro;
        public DateTime HoraRegistro
        {
            set { _hora_registro = value; }
            get { return _hora_registro; }
        }

        protected Colaborador _usuario_entrega;
        public Colaborador UsuarioEntrega
        {
            set { _usuario_entrega = value; }
            get { return _usuario_entrega; }
        }


        protected TipoCheque _tipo_cheque;
        public TipoCheque TipoCheque
        {
            set { _tipo_cheque = value; }
            get { return _tipo_cheque; }
        }


        protected int _cantidad;
        public int Cantidad
        {
            set { _cantidad = value; }
            get { return _cantidad; }
        }


        protected bool _rechazo;
        public bool Rechazo
        {
            set { _rechazo = value; }
            get { return _rechazo; }
        }


        protected decimal _monto; 

        public decimal Monto
        {
            set { _monto = value; }
            get { return _monto; }
        }

        protected Monedas _moneda;
        public Monedas Moneda
        {
            set { _moneda = value; }
            get { return _moneda; }
        }


        #endregion Atributos Privados

        #region Constructor de Clase

        public Cheque(int id = 0, Colaborador usuario_entrega = null, int cantidad = 0, DateTime ? fecha = null, TipoCheque tipoc = Clases.TipoCheque.Cheques_BAC, bool rechazo = false, decimal monto = 0, Monedas moneda = Monedas.Colones)
        {
            this.DB_ID = id;
            this._cantidad = cantidad;
            this._tipo_cheque = tipoc;
            this._usuario_entrega = usuario_entrega;
            this._hora_registro = fecha ?? DateTime.Now;
            this._rechazo = rechazo;
            this._monto = monto;
            this._moneda = moneda;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _usuario_entrega.ToString();
        }

        #endregion Overrides
    }
}
