using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaMensajes;
using CommonObjects.Clases;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using LibreriaAccesoDatos;

namespace DataLayer.Clases
{
    public class ProveedorEquipoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ProveedorEquipoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ProveedorEquipoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ProveedorEquipoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ProveedorEquipoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo proveedor.
        /// </summary>
        /// <param name="g">Objeto ProveedorCartucho con los datos del nuevo proveedor</param>
        public void agregarProveedorEquipo(ref ProveedorEquipo g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProvedorEquipos");

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
        public void actualizarProveedorEquipo(ref ProveedorEquipo g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProvedoresEquipos");

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
        public void eliminarProveedorEquipo(ProveedorEquipo g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteProvedorEquipos");

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
        public BindingList<ProveedorEquipo> listarProveedorEquipos(string nombre)
        {
            BindingList<ProveedorEquipo> proveedorEquipos = new BindingList<ProveedorEquipo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProvedoresEquipos");

            _manejador.agregarParametro(comando,"@nombre", nombre, SqlDbType.NVarChar);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_proveedorEquipo = (int)datareader["pk_ID"];
                    string nom = (string)datareader["Nombre"];

                    ProveedorEquipo proveedorEquipo = new ProveedorEquipo(id: id_proveedorEquipo, nombre: nom);

                    proveedorEquipos.Add(proveedorEquipo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return proveedorEquipos;
        }

        public ProveedorEquipo obtenerDatosProveedor(ref ProveedorEquipo e)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProveedorEquipoDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@proveedor", e, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_proveedor = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    ProveedorEquipo prov = new ProveedorEquipo(nombre:nombre, id:id_proveedor);

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
