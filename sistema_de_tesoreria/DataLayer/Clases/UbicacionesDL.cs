//
//  @ Project : 
//  @ File Name : UbicacionesDL.cs
//  @ Date : 08/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja las ubicaciones de los ATM's.
    /// </summary>
    public class UbicacionesDL
    {
        
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static UbicacionesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static UbicacionesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new UbicacionesDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public UbicacionesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una ubicación de un ATM.
        /// </summary>
        /// <param name="u">Objeto Ubicacion con los datos de la ubicación</param>
        public void agregarUbicacion(ref Ubicacion u)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertUbicacion");

            _manejador.agregarParametro(comando, "@oficina", u.Oficina, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@direccion", u.Direccion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@direccion_exacta", u.Direccion_exacta, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@provincia", u.Provincia, SqlDbType.TinyInt);

            try
            {
                u.ID = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorUbicacionRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de la ubicación de un ATM en el sistema.
        /// </summary>
        /// <param name="u">Objeto Ubicacion con los datos de la ubicación</param>
        public void actualizarUbicacion(Ubicacion u)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateUbicacion");

            _manejador.agregarParametro(comando, "@oficina", u.Oficina, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@direccion", u.Direccion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@direccion_exacta", u.Direccion_exacta, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@provincia", u.Provincia, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@ubicacion", u, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorUbicacionActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de la ubicación de un ATM.
        /// </summary>
        /// <param name="u">Objeto Ubicacion con los datos de la ubicación a eliminar</param>
        public void eliminarUbicacion(Ubicacion u)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteUbicacion");

            _manejador.agregarParametro(comando, "@ubicacion", u, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorUbicacionEliminacion");
            }

        }

        /// <summary>
        /// Listar las ubicaciones del sistema.
        /// </summary>
        /// <returns>Lista de las ubicaciones registradas en el sistema</returns>
        public BindingList<Ubicacion> listarUbicaciones()
        {
            BindingList<Ubicacion> ubicaciones = new BindingList<Ubicacion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectUbicaciones");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string oficina = (string)datareader["Oficina"];
                    string direccion = (string)datareader["Direccion"];
                    string direccion_exacta = (string)datareader["Direccion_Exacta"];
                    Provincias provincia = (Provincias)datareader["Provincia"];

                    Ubicacion ubicacion = new Ubicacion(oficina, direccion, id: id, direccion_exacta: direccion_exacta, provincia: provincia);

                    ubicaciones.Add(ubicacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return ubicaciones;
        }

        /// <summary>
        /// Verificar si existe una ubicación.
        /// </summary>
        /// <param name="u">Objeto Ubicacion con los datos de la ubicación a verificar</param>
        /// <returns>Valor que indica si la sucursal existe</returns>
        public bool verificarUbicacion(ref Ubicacion u)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteUbicacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@oficina", u.Oficina, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@direccion", u.Direccion, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id != u.ID;

                    u.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarUbicacionDuplicada");
            }

            return existe;
        }
    
        #endregion Métodos Públicos
        
    }

}
