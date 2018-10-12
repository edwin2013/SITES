//
//  @ Project : 
//  @ File Name : Gestion.cs
//  @ Date : 18/08/2011
//  @ Author : Erick Chavarría 

using System;
using System.ComponentModel;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public enum ClasificacionesGestion : byte
    {
        Consulta = 0,
        Reclamo = 1
    }

    public class Gestion : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private CausaGestion _causa;

        public CausaGestion Causa
        {
            get { return _causa; }
            set { _causa = value; }
        }

        private TipoGestion _tipo;

        public TipoGestion Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private ClasificacionesGestion _clasificacion;

        public ClasificacionesGestion Clasificacion
        {
            get { return _clasificacion; }
            set { _clasificacion = value; }
        }

        private PuntoVenta _punto_venta;

        public PuntoVenta Punto_venta
        {
            get { return _punto_venta; }
            set { _punto_venta = value; }
        }

        private decimal _monto;

        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private DateTime _fecha_finalizacion;

        public DateTime Fecha_finalizacion
        {
            get { return _fecha_finalizacion; }
            set { _fecha_finalizacion = value; }
        }

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        private string _comentario_causa;

        public string Comentario_causa
        {
            get { return _comentario_causa; }
            set { _comentario_causa = value; }
        }

        private BindingList<ManifiestoCEF> _manifiestos = new BindingList<ManifiestoCEF>();

        public BindingList<ManifiestoCEF> Manifiestos
        {
            get { return _manifiestos; }
            set { _manifiestos = value; }
        }

        private BindingList<Tula> _tulas = new BindingList<Tula>();

        public BindingList<Tula> Tulas
        {
            get { return _tulas; }
            set { _tulas = value; }
        }

        private BindingList<Deposito> _depositos = new BindingList<Deposito>();

        public BindingList<Deposito> Depositos
        {
            get { return _depositos; }
            set { _depositos = value; }
        }

        private EmpresaTransporte _transportadora;

        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value; }
        }

        private Colaborador _colaborador;

        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public Gestion(int id = 0,
                       PuntoVenta punto_venta = null,
                       TipoGestion tipo = null,
                       CausaGestion causa = null,
                       decimal monto = 0,
                       string comentario = "",
                       string comentario_causa = "",
                       DateTime? fecha = null,
                       DateTime? fecha_finalizacion = null,
                       ClasificacionesGestion clasificacion = ClasificacionesGestion.Consulta)
        {
            this.DB_ID = id;

            _punto_venta = punto_venta;
            _tipo = tipo;
            _causa = causa;
            _monto = monto;
            _comentario = comentario;
            _comentario_causa = comentario_causa;
            _fecha = fecha ?? DateTime.Now;
            _fecha_finalizacion = fecha_finalizacion ?? DateTime.Now;
            _clasificacion = clasificacion;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un manifiesto a la gestión.
        /// </summary>
        /// <param name="manifiesto">Nuevo manifiesto a agregar</param>
        public void agregarManifiesto(ManifiestoCEF manifiesto)
        {
            _manifiestos.Add(manifiesto);
        }

        /// <summary>
        /// Quitar un manifiesto de la gestión.
        /// </summary>
        /// <param name="manifiesto">Manifiesto a quitar</param>
        public void quitarManifiesto(ManifiestoCEF manifiesto)
        {
            _manifiestos.Remove(manifiesto);
        }

        /// <summary>
        /// Agregar una tula a la gestión.
        /// </summary>
        /// <param name="tula">Nuevo tula a agregar</param>
        public void agregarTula(Tula tula)
        {
            _tulas.Add(tula);
        }

        /// <summary>
        /// Quitar una tula de la gestión.
        /// </summary>
        /// <param name="tula">Tula a quitar</param>
        public void quitarTula(Tula tula)
        {
            _tulas.Remove(tula);
        }

        /// <summary>
        /// Agregar un deposito a la gestión.
        /// </summary>
        /// <param name="deposito">Nuevo deposito a agregar</param>
        public void agregarDeposito(Deposito deposito)
        {
            _depositos.Add(deposito);
        }

        /// <summary>
        /// Quitar un deposito de la gestión.
        /// </summary>
        /// <param name="deposito">Deposito a quitar</param>
        public void quitarDeposito(Deposito deposito)
        {
            _depositos.Remove(deposito);
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _causa.Descripcion;
        }

        #endregion Overrides

    }

}
