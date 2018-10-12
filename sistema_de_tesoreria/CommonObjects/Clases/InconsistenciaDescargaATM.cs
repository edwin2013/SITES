//
//  @ Project : 
//  @ File Name : InconsistenciaDescargaATM.cs
//  @ Date : 22/06/2012
//  @ Author : Erick Chavarría 

using System;
using System.ComponentModel;

using System.Text;

namespace CommonObjects
{

    public class InconsistenciaDescargaATM
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private TiposInconsistenciasDepositos _tipo;

        public TiposInconsistenciasDepositos Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private ManifiestoCEF _manifiesto;

        public ManifiestoCEF Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        private SegregadoCEF _segregado;

        public SegregadoCEF Segregado
        {
            get { return _segregado; }
            set { _segregado = value; }
        }

        private short _bolso;

        public short Bolso
        {
            get { return _bolso; }
            set { _bolso = value; }
        }

        private Tula _tula;

        public Tula Tula
        {
            get { return _tula; }
            set { _tula = value; }
        }

        private Deposito _deposito;

        public Deposito Deposito
        {
            get { return _deposito; }
            set { _deposito = value; }
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

        private decimal _diferencia_colones;

        public decimal Diferencia_colones
        {
            get { return _diferencia_colones; }
            set { _diferencia_colones = value; }
        }

        private decimal _diferencia_dolares;

        public decimal Diferencia_dolares
        {
            get { return _diferencia_dolares; }
            set { _diferencia_dolares = value; }
        }

        private BindingList<Valor> _valores = new BindingList<Valor>();

        public BindingList<Valor> Valores
        {
            get { return _valores; }
            set { _valores = value; }
        }

        private BindingList<Sobre> _sobres = new BindingList<Sobre>();

        public BindingList<Sobre> Sobres
        {
            get { return _sobres; }
            set { _sobres = value; }
        }

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public InconsistenciaDescargaATM(int id, ManifiestoCEF manifiesto, Tula tula, Deposito deposito,
                                      Camara camara, DateTime fecha, decimal diferencia_colones,
                                      decimal diferencia_dolares, string comentario)
        {
            _id = id;
            _manifiesto = manifiesto;
            _tula = tula;
            _deposito = deposito;
            _camara = camara;
            _fecha = fecha;
            _diferencia_colones = diferencia_colones;
            _diferencia_dolares = diferencia_dolares;
            _comentario = comentario;
        }

        public InconsistenciaDescargaATM(ManifiestoCEF manifiesto, Tula tula, Deposito deposito,
                                      Camara camara, DateTime fecha, decimal diferencia_colones,
                                      decimal diferencia_dolares, string comentario)
        {
            _manifiesto = manifiesto;
            _tula = tula;
            _deposito = deposito;
            _camara = camara;
            _fecha = fecha;
            _diferencia_colones = diferencia_colones;
            _diferencia_dolares = diferencia_dolares;
            _comentario = comentario;
        }

        public InconsistenciaDescargaATM(int id, ManifiestoCEF manifiesto, SegregadoCEF segregado, short bolso,
                                      Tula tula, Deposito deposito, Camara camara, DateTime fecha,
                                      decimal diferencia_colones, decimal diferencia_dolares, string comentario)
        {
            _id = id;
            _manifiesto = manifiesto;
            _segregado = segregado;
            _bolso = bolso;
            _tula = tula;
            _deposito = deposito;
            _camara = camara;
            _fecha = fecha;
            _diferencia_colones = diferencia_colones;
            _diferencia_dolares = diferencia_dolares;
            _comentario = comentario;
        }

        public InconsistenciaDescargaATM(ManifiestoCEF manifiesto, SegregadoCEF segregado, short bolso,
                                      Tula tula, Deposito deposito, Camara camara, DateTime fecha,
                                      decimal diferencia_colones, decimal diferencia_dolares,
                                      string comentario)
        {
            _manifiesto = manifiesto;
            _segregado = segregado;
            _bolso = bolso;
            _tula = tula;
            _deposito = deposito;
            _camara = camara;
            _fecha = fecha;
            _diferencia_colones = diferencia_colones;
            _diferencia_dolares = diferencia_dolares;
            _comentario = comentario;
        }

        public InconsistenciaDescargaATM(int id, decimal diferencia_colones, decimal diferencia_dolares)
        {
            _id = id;
            _diferencia_colones = diferencia_colones;
            _diferencia_dolares = diferencia_dolares;
        }

        public InconsistenciaDescargaATM(int id)
        {
            _id = id;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Ligar un valor a la inconsistencia.
        /// </summary>
        /// <param name="valor">Valor a agregar</param>
        public void agregarValor(Valor valor)
        {
            _valores.Add(valor);
        }

        /// <summary>
        /// Desligar un valor de la inconsistencia.
        /// </summary>
        /// <param name="valor">Valor a quitar</param>
        public void quitarValor(Valor valor)
        {
            _valores.Remove(valor);
        }

        /// <summary>
        /// Ligar un sobre a la inconsistencia.
        /// </summary>
        /// <param name="sobre">Sobre a agregar</param>
        public void agregarSobre(Sobre sobre)
        {
            _sobres.Add(sobre);
        }

        /// <summary>
        /// Desligar un sobre de la inconsistencia.
        /// </summary>
        /// <param name="sobre">Sobre a quitar</param>
        public void quitarSobre(Sobre sobre)
        {
            _sobres.Remove(sobre);
        }

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

            InconsistenciaDeposito inconsistencia = (InconsistenciaDeposito)obj;

            if (_id != inconsistencia.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
