//
//  @ Project : 
//  @ File Name : Grupo.cs
//  @ Date : 30/05/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CommonObjects
{

    public enum AreasManifiestos : byte
    {
        CentroEfectivo = 0,
        Boveda = 1,
        ProcesoExterno = 255
    }


    public class Grupo
    {

        #region Atributos Privados
        
        private byte _id;

        public byte Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _colaborador;

        public string Colaborador
        {
            get { return _colaborador; }
            set { _colaborador = value; }
        }
        
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private byte _numero_cajas = 1;

        public byte Numero_cajas
        {
            get { return _numero_cajas; }
            set { _numero_cajas = value; }
        }

        private byte _caja_actual;

        public byte Caja_actual
        {
            get { return _caja_actual; }
            set { _caja_actual = value; }
        }

        private short _total_manifiestos;

        public short Total_manifiestos
        {
            get { return _total_manifiestos; }
            set { _total_manifiestos = value; }
        }

        private bool _caja_unica;

        public bool Caja_unica
        {
            get { return _caja_unica; }
            set { _caja_unica = value; }
        }

        private bool _semaforo;

        public bool Semaforo
        {
            get { return _semaforo; }
            set { _semaforo = value; }
        }

        private int id;
        private CommonObjects.Colaborador cajero;
        private CommonObjects.Colaborador usuario;

        private AreasManifiestos _area;
        
        public AreasManifiestos Area
        {
            get { return _area; }
            set { _area = value; }
        }


        private BindingList<ManifiestoColaborador> _relaciones;

        public BindingList<ManifiestoColaborador> Relaciones
        {
            get { return _relaciones; }
            set { _relaciones = value; }
        }


        private BindingList<Colaborador> _grupo_colaboradores;

        public BindingList<Colaborador> Grupo_Colaboradores
        {
            get { return _grupo_colaboradores; }
            set { _grupo_colaboradores = value; }
        }
        


        #endregion Atributos Privados

        #region Constructor de Clase

        public Grupo(byte id, string nombre, string descripcion, byte numero_cajas, byte caja_actual,
                     short total_manifiestos, bool caja_unica, AreasManifiestos area, bool semaforo)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _numero_cajas = numero_cajas;
            _caja_actual = caja_actual;
            _total_manifiestos = total_manifiestos;
            _caja_unica = caja_unica;
            _area = area;
            _semaforo = semaforo;
        }


        public Grupo(byte id, string nombre, string descripcion, bool caja_unica, AreasManifiestos area, bool semaforo)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _caja_unica = caja_unica;
            _area = area;
            _semaforo = semaforo;
        }

        public Grupo(string nombre, string descripcion, bool caja_unica, AreasManifiestos area, bool semaforo)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _caja_unica = caja_unica;
            _area = area;
            _semaforo = semaforo;
        }

        public Grupo(byte id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
            
        public Grupo() { }

        public Grupo(int id, string nombre)
        {
            // TODO: Complete member initialization
            this.id = id;
            this.Nombre = nombre;
        }

        public Grupo(CommonObjects.Colaborador cajero, CommonObjects.Colaborador usuario)
        {
            // TODO: Complete member initialization
            this.cajero = cajero;
            this.usuario = usuario;
        }

        public Grupo(CommonObjects.Colaborador cajero)
        {
            // TODO: Complete member initialization
            this.cajero = cajero;
        }

        public Grupo(byte id, string nombre, byte numero_cajas, byte caja_actual, short total_manifiestos, bool caja_unica, AreasManifiestos area)
        {
            // TODO: Complete member initialization
            this.Id = id;
            this.Nombre = nombre;
            this.Numero_cajas = numero_cajas;
            this.Caja_actual = caja_actual;
            this.Total_manifiestos = total_manifiestos;
            this.Caja_unica = caja_unica;
            this.Area = area;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _nombre;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Grupo grupo = (Grupo)obj;

            if (_id != grupo.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
