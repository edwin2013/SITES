//
//  @ Project : 
//  @ File Name : CiudadesDL.cs
//  @ Date : 06/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja las ciudades.
    /// </summary>
    public class CiudadesDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CiudadesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CiudadesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CiudadesDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CiudadesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nueva ciudad en el sistema.
        /// </summary>
        /// <param name="c">Objeto Ciudad con los datos de la nueva ciudad</param>
        public void agregarCiudad(ref Ciudad c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCiudad");

            _manejador.agregarParametro(comando, "@nombre", c.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@provincia", c.Provincia, SqlDbType.TinyInt);

            try
            {
                c.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCiudadRegistro");
            }

        }

        /// <summary>
        /// Listar todos las ciudades registradas en el sistema.
        /// </summary>
        /// <returns>Lista de ciudades registradas en el sistema</returns>
        public BindingList<Ciudad> listarCiudades()
        {
            BindingList<Ciudad> ciudades = new BindingList<Ciudad>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCiudades");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    Provincias provincia = (Provincias)datareader["Provincia"];

                    Ciudad ciudad = new Ciudad(id, nombre, provincia);
                    ciudades.Add(ciudad);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return ciudades;
        }
       
        #endregion Métodos Públicos

    }

}
