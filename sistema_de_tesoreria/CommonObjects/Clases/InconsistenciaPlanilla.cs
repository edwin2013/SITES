using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibreriaAccesoDatos;
using System.Collections.Generic;

namespace CommonObjects
{
    public enum Origen : byte
    {
        Sites = 0,
        Transportadora = 1
    }
    public enum Tipo : byte
    {
        Error_de_digitación_por_parte_de_la_transportadora = 0,
        Error_de_digitación_por_parte_del_receptor_BAC = 1,
        No_se_recibio_tula_reportada_por_la_transportadora= 2,
        Se_recibio_tula_no_reportada_por_la_transportadora=3
    }
    public enum Estado : byte
    {
        Pendiente = 0,
        Resuelta = 1
    }
    public class InconsistenciaPlanilla : ObjetoIndexado
    {
        #region Atributos Privados

        protected Decimal _tarifa;
        public Decimal Tarifa
        {
            get { return _tarifa; }
            set { _tarifa = value; }
        }

        protected Decimal _recargo;
        public Decimal Recargo
        {
            get { return _recargo; }
            set { _recargo = value; }
        }

        protected Decimal _total;
        public Decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
        protected Decimal _montoTula;
        public Decimal MontoTula
        {
            get { return _montoTula; }
            set { _montoTula = value; }
        }

        protected Decimal _montoPlanilla;
        public Decimal MontoPlanilla
        {
            get { return _montoPlanilla; }
            set { _montoPlanilla = value; }
        }

        protected int _id_pdv;
        public int id_pdv
        {
            get { return _id_pdv; }
            set { _id_pdv = value; }
        }

        protected short _pdv;
        public short pdv
        {
            get { return _pdv; }
            set { _pdv = value; }
        }

        public int ID
        {
            get { return (int)this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _manifiesto;
        public string manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        protected string _tula;

        public string Tula
        {
            get { return _tula; }
            set { _tula = value; }
        }
        protected string _tulapl;

        public string TulaPl
        {
            get { return _tulapl; }
            set { _tulapl = value; }
        }

        protected DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        protected EmpresaTransporte _empresa;

        public EmpresaTransporte Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        protected string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        protected DateTime _fechaResolucion;

        public DateTime FechaResolucion
        {
            get { return _fechaResolucion; }
            set { _fechaResolucion = value; }
        }
        protected Colaborador _colaborador;

        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        protected Tipo _tipo;

        public Tipo Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

       protected Estado _estado;

        public Estado Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        protected Grupo _grupo;

        public Grupo Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }
        protected Origen _origen;

        public Origen Origen
        {
            get { return _origen; }
            set { _origen = value; }
        }

        protected string _codigo_manifiesto_SITES;
        public string ManifiestoSITES
        {
            get { return _codigo_manifiesto_SITES; }
            set { _codigo_manifiesto_SITES = value; }
        }

        protected int _id_manifiesto_sites;
        public int IDManifiestoSITES
        {
            get { return _id_manifiesto_sites; }
            set { _id_manifiesto_sites = value; }
        }


        protected string _id_manifiesto_original;
        public string ManifiestoOriginal
        {
            get { return _id_manifiesto_original; }
            set { _id_manifiesto_original = value; }
            
        }


        protected string _tula_original;
        public string TulaOriginal
        {
            get { return _tula_original; }
            set { _tula_original = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public InconsistenciaPlanilla(string tula = "",
                        string Tulapl = "",
                        string manifiesto = "",
                        EmpresaTransporte Empresa = null,
                        Colaborador colaborador = null,
                        Grupo grupo =null,
                        DateTime? Fecha = null,
                        String Comentario = "",
                        //Estado Estado = Estado.Pendiente,
                        //Encargado EncargadoResolucion = Encargado,
                        DateTime? FechaResolucion = null
                        //Origen? Origen = Origen.
            )
        {
            _manifiesto = manifiesto;
            _tulapl = TulaPl;
            _tula = tula;
            _empresa = Empresa;
            _grupo = Grupo;
            _colaborador = colaborador;
            _fecha = Fecha ?? DateTime.MinValue;
            _fechaResolucion = FechaResolucion ?? DateTime.MinValue;
            //_encargadoRes = EncargadoResolucion;
            //_estado = Estado;
            _comentario = Comentario;
            //_origen = Origen;
         }

        public InconsistenciaPlanilla()//(short id)
        {
            // TODO: Complete member initialization
           // this.DB_ID = id;
        }

        #endregion Constructor de Clase
    }
    
}
