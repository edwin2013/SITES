using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonObjects.Clases
{
    public class BolsaCompletaNiquel : ObjetoIndexado
    {
        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Decimal _cantidad_asignada;

        public Decimal Cantidad_asignada
        {
            get { return _cantidad_asignada; }
            set { _cantidad_asignada = value; }
        }

        private int _id_bolsa;
        public int ID_Bolsa
        {
            set { _id_bolsa = value; }
            get { return _id_bolsa; }
        }

       
        public decimal Monto_asignado
        {
            get { return (_cantidad_piezas_bolsa) * _cantidad_bolsas; }
        }


        public decimal Monto_bolsa
        {
            get { return (_cantidad_piezas_bolsa); }
        }

        protected Denominacion _denominacion;

        public Denominacion Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }


        protected String _comentario;

        public String Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        protected int _cantidad_piezas_bolsa;
        public int CantidadPiezasBolsa
        {
            get { return _cantidad_piezas_bolsa; }
            set { _cantidad_piezas_bolsa = value; }
        }


        public decimal TotalPiezas
        {
            get { return _cantidad_piezas_bolsa; }
        }


        protected int _tipo_bolsa;
        public int TipoBolsa
        {
            get { return _tipo_bolsa; }
            set { _tipo_bolsa = value; }
        }

        public string TipoDeBolsas
        {
            get
            {
                if (_tipo_bolsa == 1)
                    return "Ensobrado";
                else
                    return "Chorreado";
            }
        }


        protected int _cantidad_bolsas;
        public int CantidadBolsas
        {
            get { return _cantidad_bolsas; }
            set { _cantidad_bolsas = value; }
        }
        protected PuntoVenta _punto_venta;
        public PuntoVenta PuntoVenta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }


        protected ManifiestoNiquelPedido _manifiesto;
        public ManifiestoNiquelPedido Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected DateTime _fecha_entrega;

        public DateTime FechaEntrega
        {
            get { return _fecha_entrega; }
            set { _fecha_entrega = value; }
        }

        protected Colaborador _receptor;
        public Colaborador Receptor
        {
            get { return _receptor; }
            set { _receptor = value; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public BolsaCompletaNiquel(Denominacion denominacion = null,
                                int id = 0,
                                Decimal cantidad_asignada = 0, int cantidad_piezas = 0, int tipo_bolsa = 0,int cantidad_bolsas = 0)
        {
            this.DB_ID = id;

            

            _cantidad_asignada = cantidad_asignada;
            _cantidad_piezas_bolsa = cantidad_piezas;
            _tipo_bolsa = tipo_bolsa;
            _denominacion = denominacion;
            _cantidad_bolsas = cantidad_bolsas;

        }

        #endregion Constructor de Clase

        #region Métodos Públicos


        #endregion Métodos Públicos

        #region Overrides

  

        #endregion Overrides

    }
}
