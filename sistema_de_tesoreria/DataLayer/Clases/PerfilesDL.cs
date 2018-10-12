//
//  @ Project : 
//  @ File Name : PerfilesDL.cs
//  @ Date : 14/09/2012
//  @ Author : Erick Chavarría 

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los perfiles de usuario.
    /// </summary>
    public class PerfilesDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PerfilesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PerfilesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PerfilesDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PerfilesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo perfil en el sistema.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del nuevo perfil</param>
        public void agregarPerfil(ref Perfil p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPerfil");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);

            try
            {
                p.ID = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPerfilRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un perfil en el sistema.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del perfil</param>
        public void actualizarPerfil(Perfil p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePerfil");

            _manejador.agregarParametro(comando, "@nombre", p.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@perfil", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPerfilActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un perfil.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del perfil a eliminar</param>
        public void eliminarPerfil(Perfil p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePerfil");

            _manejador.agregarParametro(comando, "@perfil", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPerfilEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los perfiles registrados.
        /// </summary>
        /// <returns>Lista de perfiles registrados en el sistema</returns>
        public BindingList<Perfil> listarPerfiles()
        {
            BindingList<Perfil> perfiles = new BindingList<Perfil>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPerfiles");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    Perfil perfil = new Perfil(id, nombre);

                    perfiles.Add(perfil);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return perfiles;
        }

        public BindingList<Perfil> listarPerfilesPuesto(PuestoColaborador puesto)
        {
            BindingList<Perfil> perfiles = new BindingList<Perfil>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPerfilesPorPuesto");

            _manejador.agregarParametro(comando, "@puesto", puesto.ID, SqlDbType.TinyInt);

            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    Perfil perfil = new Perfil(id, nombre);

                    perfiles.Add(perfil);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return perfiles;
        }

        /// <summary>
        /// Verificar si existe un perfil registrado.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del perfil</param>
        /// <returns>Valor que indica si el perfil existe</returns>
        public bool verificarPerfil(Perfil p)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistePerfil");
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
                throw new Excepcion("ErrorVerificarPerfilDuplicado");
            }

            return existe;
        }

        #region Opciones

        /// <summary>
        /// Registrar las opciones de un perfil.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del perfil</param>
        /// <param name="o">Objeto Opcion con los datos de la opción</param>
        public void agregarOpcionPerfil(Perfil p, Opcion o)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPerfilOpcion");

            _manejador.agregarParametro(comando, "@perfil", p, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@opcion", o, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorOpcionPerfilActualizacion");
            }

        }

        /// <summary>
        /// Eliminar una opción asignada a un perfil.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del perfil</param>
        /// <param name="o">Objeto Opcion con los datos de la opción</param>
        public void eliminarOpcionPerfil(Perfil p, Opcion o)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePerfilOpcion");

            _manejador.agregarParametro(comando, "@perfil", p, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@opcion", o, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorOpcionPerfilActualizacion");
            }

        }

        /// <summary>
        /// Obtener las opciones de un perfil.
        /// </summary>
        /// <param name="p">Perfilol para el cual se obtienen las opciones</param>
        public void obtenerOpcionesPerfil(ref Perfil p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectOpcionesPorPerfil");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@perfil", p, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string boton = (string)datareader["Boton"];

                    Opcion opcion = new Opcion(id, nombre, boton);

                    p.agregarOpcion(opcion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Listar las opciones del sistema.
        /// </summary>
        /// <returns>Lista de las opciones del sistema</returns>
        public BindingList<Opcion> listarOpciones()
        {
            BindingList<Opcion> opciones = new BindingList<Opcion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectOpciones");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string boton = (string)datareader["Boton"];

                    Opcion opcion = new Opcion(id, nombre, boton);

                    opciones.Add(opcion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return opciones;
        }

        #endregion Opciones

        #endregion Métodos Públicos

    }

}
