//
//  @ Project : 
//  @ File Name : RegistroHorasExtra.cs
//  @ Date : 08/08/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public enum Motivos : byte
    {
        FaltaPersonal = 0,
        DiasFestivos = 1,
        FallaOperativa = 2,
        IncrementoVolumen = 3,
        Capacitacion = 4
    }

    public enum Estados : byte
    {
        NoRevisado = 0,
        Aprobado = 1,
        Rechazado = 2
    }

    public class RegistroHorasExtra
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Colaborador _colaborador;

        public Colaborador Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }

        private Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }

        private DateTime _hora_ingreso;

        public DateTime Hora_ingreso
        {
            get { return _hora_ingreso; }
            set { _hora_ingreso = value; }
        }

        private DateTime _hora_salida;

        public DateTime Hora_salida
        {
            get { return _hora_salida; }
            set { _hora_salida = value; }
        }

        private decimal _horas_jornada;

        public decimal Horas_jornada
        {
            get { return _horas_jornada; }
            set { _horas_jornada = value; }
        }

        private bool _dia_libre;

        public bool Dia_libre
        {
            get { return _dia_libre; }
            set { _dia_libre = value; }
        }

        private DateTime _fecha_registro;

        public DateTime Fecha_registro
        {
            get { return _fecha_registro; }
            set { _fecha_registro = value; }
        }

        private decimal _horas_extra;

        public decimal Horas_extra
        {
            get { return _horas_extra; }
            set { _horas_extra = value; }
        }

        private decimal _horas_dobles;

        public decimal Horas_dobles
        {
            get { return _horas_dobles; }
            set { _horas_dobles = value; }
        }

        private decimal _horas_dobles_extra;

        public decimal Horas_dobles_extra
        {
            get { return _horas_dobles_extra; }
            set { _horas_dobles_extra = value; }
        }

        private decimal _alimentacion;

        public decimal Alimentacion
        {
            get { return _alimentacion; }
            set { _alimentacion = value; }
        }

        private decimal _transporte;

        public decimal Transporte
        {
            get { return _transporte; }
            set { _transporte = value; }
        }

        private List<Motivos> _motivos = new List<Motivos>();

        public List<Motivos> Motivos
        {
            get { return _motivos; }
            set { _motivos = value; }
        }

        private List<Puestos> _puestos = new List<Puestos>();

        public List<Puestos> Puestos
        {
            get { return _puestos; }
            set { _puestos = value; }
        }

        private Estados _estado;

        public Estados Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _observaciones_conceptos;

        public string Observaciones_conceptos
        {
            get { return _observaciones_conceptos; }
            set { _observaciones_conceptos = value; }
        }

        private string _observaciones_gastos;

        public string Observaciones_gastos
        {
            get { return _observaciones_gastos; }
            set { _observaciones_gastos = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RegistroHorasExtra(int id = 0,
                                  Colaborador colaborador = null,
                                  Colaborador coordinador = null,
                                  DateTime? fecha_registro = null,
                                  DateTime? hora_ingreso = null,
                                  DateTime? hora_salida = null,
                                  decimal horas_jornada = 0,
                                  bool dia_libre = false,
                                  decimal horas_extra = 0,
                                  decimal horas_dobles = 0,
                                  decimal horas_dobles_extra = 0,
                                  decimal alimentacion = 0,
                                  decimal transporte = 0,
                                  Estados estado = Estados.NoRevisado,
                                  string observaciones_conceptos = "",
                                  string observaciones_gastos = "")
        {
            _id = id;
            _colaborador = colaborador;
            _coordinador = coordinador;
            _fecha_registro = fecha_registro ?? DateTime.MinValue;
            _hora_ingreso = hora_ingreso ?? DateTime.MinValue;
            _hora_salida = hora_salida ?? DateTime.MinValue;
            _horas_jornada = horas_jornada;
            _dia_libre = dia_libre;
            _horas_extra = horas_extra;
            _horas_dobles = horas_dobles;
            _horas_dobles_extra = horas_dobles_extra;
            _alimentacion = alimentacion;
            _transporte = transporte;
            _observaciones_conceptos = observaciones_conceptos;
            _observaciones_gastos = observaciones_gastos;
            _estado = estado;
        }

        public RegistroHorasExtra() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un motivo para el registro.
        /// </summary>
        /// <param name="motivo">Motivo a agregar</param>
        public void agregarMotivo(Motivos motivo)
        {
            _motivos.Add(motivo);
        }

        /// <summary>
        /// Quitar un motivo del registro.
        /// </summary>
        /// <param name="motivo">Motivo a quitar</param>
        public void quitarMotivo(Motivos motivo)
        {
            _motivos.Remove(motivo);
        }

        /// <summary>
        /// Agregar un puesto al registro.
        /// </summary>
        /// <param name="puesto">Nuevo puesto a agregar</param>
        public void agregarPuesto(Puestos puesto)
        {
            _puestos.Add(puesto);
        }

        /// <summary>
        /// Quitar un puesto del registro.
        /// </summary>
        /// <param name="puesto">Puesto a quitar</param>
        public void quitarPuesto(Puestos puesto)
        {
            _puestos.Remove(puesto);
        }

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _colaborador.Nombre + " " + _colaborador.Primer_apellido;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            RegistroHorasExtra registro = (RegistroHorasExtra)obj;

            if (_id != registro.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
