using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

using CommonObjects;
using LibreriaMensajes;
using System.Data.SqlClient;
using System.Data;
using CommonObjects.Clases;
using System.ComponentModel;

namespace DataLayer.Clases
{
    /// <summary>
    /// Clase de la capa de datos que maneja los Proveedores.
    /// </summary>
    public class ProveedorCartuchoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ProveedorCartuchoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ProveedorCartuchoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ProveedorCartuchoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ProveedorCartuchoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo proveedor.
        /// </summary>
        /// <param name="g">Objeto ProveedorCartucho con los datos del nuevo proveedor</param>
        public void agregarProveedorCartucho(ref ProveedorCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProvedorCartucho");

            //_manejador.agregarParametro(comando, "@tipo", g.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.NVarChar);
            try
            {
                g.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorproveedorCartuchoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un proveedor.
        /// </summary>
        /// <param name="g">Objeto proveedorCartucho con los datos de la proveedor a actualizar</param>
        public void actualizarProveedorCartucho(ref ProveedorCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProvedoresCartucho");

            _manejador.agregarParametro(comando, "@provedor", g.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.NVarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorProveedorCartuchoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un proveedor.
        /// </summary>
        /// <param name="t">Objeto proveedorCartucho con los datos de la proveedor a eliminar</param>
        public void eliminarProveedorCartucho(ProveedorCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteProvedorCartucho");

            _manejador.agregarParametro(comando, "@provedor", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErroroProveedorCartuchoEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las proveedorCartuchoes registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las proveedorCartuchoes registradas en el sistema</returns>
        public BindingList<ProveedorCartucho> listarProveedorCartuchos(string nombre)
        {
            BindingList<ProveedorCartucho> proveedorCartuchos = new BindingList<ProveedorCartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProvedoresCartuchos");

            _manejador.agregarParametro(comando,"@nombre", nombre, SqlDbType.NVarChar);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_proveedorCartucho = (int)datareader["pk_ID"];
                    string nom = (string)datareader["Nombre"];

                    ProveedorCartucho proveedorCartucho = new ProveedorCartucho(id: id_proveedorCartucho, nombre: nom);

                    proveedorCartuchos.Add(proveedorCartucho);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return proveedorCartuchos;
        }


        /// <summary>
        /// Obtiene los datos del proveedor
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>

        public ProveedorCartucho obtenerDatosProveedor(ref ProveedorCartucho e)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProveedorDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@proveedor", e, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_proveedor = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    ProveedorCartucho prov = new ProveedorCartucho(nombre: nombre, id: id_proveedor);

                    e = prov;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return e;
        }


        #endregion Métodos Públicos
    }
}
