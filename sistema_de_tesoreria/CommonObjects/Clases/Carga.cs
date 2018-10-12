using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public enum TipoCargas
    {
        ATM = 1,
        Sucursal = 2,
        Banco = 3
    }

    public class Carga: ObjetoIndexado 
    {
        #region Atributos Privados

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

      
        protected int _ruta;

        public int Ruta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }

        protected int _orden_ruta;

        public int Orden_ruta
        {
            get { return _orden_ruta; }
            set { _orden_ruta = value; }
        }

        protected int _id_canal;
        public int ID_Canal
        {
            get { return _id_canal; }
            set { _id_canal = value; }
        }
       
        protected DateTime ? _hora_recibido_boveda;
        public DateTime ? HoraRecibidoBoveda
        {
            set { _hora_recibido_boveda = value; }
            get { return _hora_recibido_boveda; }
        }

        protected DateTime ? _hora_entrega_boveda;
        public DateTime ? HoraEntregaBoveda
        {
            set { _hora_entrega_boveda = value; }
            get { return _hora_entrega_boveda; }
        }


        protected Colaborador _colaborador_recibido_boveda;
        public Colaborador ColaboradorRecibidoBoveda
        {
            set { _colaborador_recibido_boveda = value; }
            get { return _colaborador_recibido_boveda; }
        }


        protected Colaborador _colaborador_entregado_boveda;
        public Colaborador ColaboradorEntregadoBoveda
        {
            set { _colaborador_entregado_boveda = value; }
            get { return _colaborador_entregado_boveda; }
        }


        protected TipoEntregas _tipo_entrega;
        public TipoEntregas TipoEntregas
        {
            set { _tipo_entrega = value; }
            get { return _tipo_entrega; }
        }

        protected TipoCargas _tipo_cargas;
        public TipoCargas TipoCargas
        {
            set { _tipo_cargas = value; }
            get { return _tipo_cargas; }
        }

        protected String _dato;
        public String Dato
        {
            set { _dato = value; }
            get { return _dato; }
        }
        
        protected String _nombre;
        public String Nombre
        {
            set{ _nombre = value; }
            get{ return _nombre; }
        }


        protected bool _emergencia;
        public bool Emergencia
        {
            get { return _emergencia; }
            set { _emergencia = value; }
        }


        protected Decimal _monto_colones;
        public Decimal MontoColones
        {
            get { return _monto_colones; }
            set { _monto_colones = value; }
        }


        protected int _numero_punto;
        public int NumeroPunto
        {
            set { _numero_punto = value; }
            get { return _numero_punto; }
        }

        protected DateTime _hora_programada;
        public DateTime HoraProgramada
        {
            set { _hora_programada = value; }
            get { return _hora_programada; }
        }

        protected DateTime ? _hora_inicio_atencion_punto;
        public DateTime ? HoraInicioAtencionPunto
        {
            get { return _hora_inicio_atencion_punto; }
            set { _hora_inicio_atencion_punto = value; }
        }


        protected DateTime ? _hora_final_atencion_punto;
        public DateTime ? HoraFinalAtencionPunto
        {
            get { return _hora_final_atencion_punto; }
            set { _hora_final_atencion_punto = value; }
        }

        protected String _observaciones;
        public String Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        protected int _id_bolsa;
        public int IDBolsa
        {
            get { return _id_bolsa; }
            set { _id_bolsa = value; }
        }


        protected bool _tipo_pedido;
        public bool TipoPedido
        {
            get { return _tipo_pedido; }
            set { _tipo_pedido = value; }
        }

        protected bool _hand_held;
        public bool HandHeld
        {
            set { _hand_held = value; }
            get { return _hand_held; }
        }


        protected bool _manual;
        public bool Manual
        {
            set { _manual = value; }
            get { return _manual; }
        }



        #endregion Atributos Privados

        #region Constructor de Clase

        public Carga(   int id = 0,
                        Colaborador cajero = null,
                        int ruta =0,
                        int orden_ruta = 0,
                        string observaciones = "",
                        DateTime ? hora_rec_boveda  = null,
                        DateTime ? hora_ent_boveda  = null,
                        DateTime? hora_programada = null,
                        DateTime? hora_inicio_punto = null,
                        DateTime? hora_final_punto = null,
                        Colaborador recibo = null,
                        Colaborador entrega = null,
                        TipoEntregas tipoen = TipoEntregas.Recibido,
                        TipoCargas tipoc = TipoCargas.ATM,
                        string nombre = "",
                        string dato = "",
                        bool emergencia = false,
                        int idcanal = 0,
                        decimal monto = 0,
                        int numero_punto = 0,
                        int id_bolsa = 0,
                        bool tipo_ped = false, 
                        bool hand_held = false,
                        bool manual = false
                        )
        {
            this.DB_ID = id;
           
            this.Cajero = cajero;
          
            _ruta = ruta;
            _orden_ruta = orden_ruta;
            _hora_recibido_boveda = hora_rec_boveda;
            _hora_entrega_boveda = hora_ent_boveda;
            _colaborador_recibido_boveda = recibo;
            _colaborador_entregado_boveda = entrega;
            _tipo_entrega = tipoen;
            _tipo_cargas = tipoc;
            _nombre = nombre;
            _dato = dato;
            _emergencia = emergencia;
            _orden_ruta = orden_ruta;
            _id_canal = idcanal;
            _monto_colones = monto;
            _hora_programada = hora_programada ?? DateTime.Now;
            _hora_inicio_atencion_punto = hora_inicio_punto ;
            _hora_final_atencion_punto = hora_final_punto;
            _observaciones = observaciones;
            _numero_punto = numero_punto;
            _id_bolsa = id_bolsa;
            _tipo_pedido = tipo_ped;
            _hand_held = hand_held;
            _manual = manual;
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
