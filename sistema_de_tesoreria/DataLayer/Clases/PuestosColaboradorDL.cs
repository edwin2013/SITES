using CommonObjects;
using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class PuestosColaboradorDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PuestosColaboradorDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PuestosColaboradorDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PuestosColaboradorDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PuestosColaboradorDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo puesto en el sistema.
        /// </summary>
        /// <param name="p">Objeto puesto con los datos del nuevo puesto</param>
        public void agregarPuesto(ref PuestoColaborador p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPuesto");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);

            try
            {
                p.ID = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuestoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un puesto en el sistema.
        /// </summary>
        /// <param name="p">Objeto puesto con los datos del puesto</param>
        public void actualizarpuesto(PuestoColaborador p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePuesto");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorpuestoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un puesto.
        /// </summary>
        /// <param name="p">Objeto puesto con los datos del puesto a eliminar</param>
        public void eliminarPuesto(PuestoColaborador p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePuesto");

            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuestoEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los puestos registrados.
        /// </summary>
        /// <returns>Lista de puestos registrados en el sistema</returns>
        public BindingList<PuestoColaborador> listarPuestos()
        {
            BindingList<PuestoColaborador> puestos = new BindingList<PuestoColaborador>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPuestos");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    PuestoColaborador puesto = new PuestoColaborador(id, nombre);

                    puestos.Add(puesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return puestos;
        }

        /// <summary>
        /// Verificar si existe un puesto registrado.
        /// </summary>
        /// <param name="p">Objeto puesto con los datos del puesto</param>
        /// <returns>Valor que indica si el puesto existe</returns>
        public bool verificarpuesto(PuestoColaborador p)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistePuesto");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    existe = id_encontrado != p.ID;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarPuestoDuplicado");
            }

            return existe;
        }


        #region Perfiles
        public void agregarPerfilPuesto(PuestoColaborador p, Perfil perfil)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPerfilPuesto");

            _manejador.agregarParametro(comando, "@puesto", p.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@perfil", perfil.ID, SqlDbType.Int);

            try
            {
               // p.ID = (byte)
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuestoRegistro");
            }

        }


        public void eliminarPerfilPuesto(PuestoColaborador p, Perfil perfil)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePerfilPuesto");

            _manejador.agregarParametro(comando, "@puesto", p.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@perfil", perfil.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuestoEliminacion");
            }

        }
        #endregion Perfiles


        #endregion Métodos Públicos

    }
}
