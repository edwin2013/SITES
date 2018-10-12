//
//  @ Project : 
//  @ File Name : Colaborador.cs
//  @ Date : 28/04/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

using LibreriaAccesoDatos;
using CommonObjects.Clases;

namespace CommonObjects
{

    public enum Areas : byte
    {
        CentroEfectivo = 0,
        Boveda = 1,
        ATMs = 2,
        Tesoreria = 3,
        Blindados = 4,
        Sucursal = 5,
        Caja_Empresarial = 6
    }

    public enum Puestos : byte
    {
        CajeroA = 0,
        CajeroB = 1,
        Coordinador = 2,
        Receptor = 3,
        Separador = 4,
        Digitador = 5,
        Supervisor = 6,
        Oficial = 7,
        Administrador = 8,
        CoordinadorOperativo = 9,
        ControlInterno = 10,
        Analista = 11,
        OficialTransporteValores = 12,
        Custodio = 13,
        Portavalor = 14,
        Programador = 15,
        Chofer = 16,
        Ingeniero = 17,
        Backup_Blindados = 18,
        Patio_Maniobras = 19,
        Asistente = 20,
        Tesorero = 21,
        Gerente = 22,
        Coordinador_Sucursal = 23,
        CajeroC = 24,
        Operador_Monitoreo = 25,
        CajeroD = 60,
        //CajeroE = 61,
        CajeroE = 68, //Cambiar por 61
        CajeroF = 67 //Quitar para produccion

    }

    public class Colaborador : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        protected string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        protected string _primer_apellido;

        public string Primer_apellido
        {
            get { return _primer_apellido; }
            set { _primer_apellido = value; }
        }

        protected string _segundo_apellido;

        public string Segundo_apellido
        {
            get { return _segundo_apellido; }
            set { _segundo_apellido = value; }
        }

        protected string _identificacion;

        public string Identificacion
        {
            get { return _identificacion; }
            set { _identificacion = value; }
        }

        protected DateTime _fecha_ingreso;

        public DateTime Fecha_ingreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }

        protected string _cuenta;

        public string Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        protected Areas _area;

        public Areas Area
        {
            get { return _area; }
            set { _area = value; }
        }

        protected List<Puestos> _puestos = new List<Puestos>();

        public List<Puestos> Puestos
        {
            get { return _puestos; }
            set { _puestos = value; }
        }

        protected List<PuestoColaborador> _puestosColaborador = new List<PuestoColaborador>();

        public List<PuestoColaborador> PuestosColaborador
        {
            get { return _puestosColaborador; }
            set { _puestosColaborador = value; }
        }

        protected BindingList<Telefono> _telefonos = new BindingList<Telefono>();

        public BindingList<Telefono> Telefonos
        {
            get { return _telefonos; }
            set { _telefonos = value; }
        }

        protected BindingList<Perfil> _perfiles = new BindingList<Perfil>();

        public BindingList<Perfil> Perfiles
        {
            get { return _perfiles; }
            set { _perfiles = value; }
        }

        protected bool _administrador_general;

        public bool Administrador_general
        {
            get { return _administrador_general; }
            set { _administrador_general = value; }
        }

        protected Sucursal _sucursal;
        public Sucursal Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }

        protected BindingList<Equipo> _equipos;
        public BindingList<Equipo> Equipos
        {
            get { return _equipos; }
            set { _equipos = value; }
        }


        protected int _caja;

        public int Caja
        {
            get { return _caja; }
            set { _caja = value; }
        }


        protected string _correo;

        public string Correo
        {
            set { _correo = value; }
            get { return _correo; }
        }



        protected string _base_datos_correo;
        public string BaseDatosCorreo
        {
            set { _base_datos_correo = value; }
            get { return _base_datos_correo; }
        }



        protected string _servidor_correo;
        public string ServidorCorreo
        {
            set { _servidor_correo = value; }
            get { return _servidor_correo; }
        }



        protected string _clave_cef;
        public string ClaveCEF
        {
            set { _clave_cef = value; }
            get { return _clave_cef; }
        }



        #endregion Atributos Privados

        #region Constructor de Clase

        public Colaborador(int id = 0,
                           string nombre = "",
                           string primer_apellido = "",
                           string segundo_apellido = "",
                           string identificacion = "",
                           string cuenta = "",
                           DateTime? fecha_ingreso = null,
                           Areas area = Areas.Tesoreria,
                           bool administrador_general = false,
                           string correo = "",
                           string clave_cef = "",
                           string basedatoscorreo = "",
                           string servidorcorreo = "")
        {
            this.DB_ID = id;

            _nombre = nombre;
            _identificacion = identificacion;
            _fecha_ingreso = fecha_ingreso ?? DateTime.MinValue;
            _primer_apellido = primer_apellido;
            _segundo_apellido = segundo_apellido;
            _cuenta = cuenta;
            _area = area;
            _administrador_general = administrador_general;
            _correo = correo;
            _clave_cef = clave_cef;
            _base_datos_correo = basedatoscorreo;
            _servidor_correo = servidorcorreo;
        }

        public Colaborador(CommonObjects.Sucursal sucursal)
        {
            // TODO: Complete member initialization
            this.Sucursal = sucursal;
        }
        
        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Agregar un puesto para el colaborador.
        /// </summary>
        /// <param name="puesto">Nuevo puesto a agregar</param>
        public void agregarPuesto(Puestos puesto)
        {
            _puestos.Add(puesto);
        }

        /// <summary>
        /// Quitar un puesto del colaborador.
        /// </summary>
        /// <param name="puesto">Puesto a quitar</param>
        public void quitarPuesto(Puestos puesto)
        {
            _puestos.Remove(puesto);
        }

        /// <summary>
        /// Agregar un teléfono al colaborador.
        /// </summary>
        /// <param name="telefono">Nuevo teléfono a agregar</param>
        public void agregarTelefono(Telefono telefono)
        {
            _telefonos.Add(telefono);
        }

        /// <summary>
        /// Quitar un teléfono del colaborador.
        /// </summary>
        /// <param name="telefono">Teléfono a quitar</param>
        public void quitarTelefono(Telefono telefono)
        {
            _telefonos.Remove(telefono);
        }

        /// <summary>
        /// Agregar un perfil al colaborador.
        /// </summary>
        /// <param name="perfil">Nuevo perfil a agregar</param>
        public void agregarPerfil(Perfil perfil)
        {
            _perfiles.Add(perfil);
        }

        /// <summary>
        /// Quitar un perfil del colaborador.
        /// </summary>
        /// <param name="perfil">Perfil a quitar</param>
        public void quitarPerfil(Perfil perfil)
        {
            _perfiles.Remove(perfil);
        }


        /// <summary>
        /// Agregar una equipo al cierre.
        /// </summary>
        /// <param name="equipo">Equipo a agregar</param>
        public void agregarEquipo(Equipo equipo)
        {
            _equipos.Add(equipo);
        }

        /// <summary>
        /// Quitar una equipo del cierre.
        /// </summary>
        /// <param name="equipo">Equipo a quitar</param>
        public void quitarEquipo(Equipo equipo)
        {
            _equipos.Remove(equipo);
        }


        /// <summary>
        /// Agregar el puesto del colaborador de acuerdo al perfil Cambio Abril 2017 Nota Auditoria
        /// </summary>
        /// <param name="puesto"></param>
        public void agregarPuestoColaborador(PuestoColaborador puesto)
        {
            _puestosColaborador.Add(puesto);
        }

        /// <summary>
        /// Quitar un puesto del colaborador.
        /// </summary>
        /// <param name="puesto">Puesto a quitar</param>
        public void quitarPuestoColaborador(PuestoColaborador puesto)
        {
            _puestosColaborador.Remove(puesto);
        }
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre + " " + _primer_apellido + " " + _segundo_apellido;
        }

        #endregion Overrides

    }

}
