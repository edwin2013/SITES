using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data.SqlClient;
using LibreriaMensajes;
using System.Data;
using System.ComponentModel;
using CommonObjects;

namespace DataLayer.Clases
{
    public class EquipoTesoreriaDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static EquipoTesoreriaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static EquipoTesoreriaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EquipoTesoreriaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public EquipoTesoreriaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void agregarEquipoTesoreria(ref EquipoTesoreria d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertEquipoTesoreria");

            _manejador.agregarParametro(comando, "@nombre", d.Nombre, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@numactivo", d.NumActivo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@serie", d.Serie, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@proveedor", d.Proveedor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@area", d.Area, SqlDbType.TinyInt);
            
            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoRegistro");
            }

        }

        public void actualizarEquipoTesoreria(EquipoTesoreria d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEquipoTesoreria");

            _manejador.agregarParametro(comando, "@nombre", d.Nombre, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@numactivo", d.NumActivo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@serie", d.Serie, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@proveedor", d.Proveedor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@equipo", d, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@area", d.Area, SqlDbType.TinyInt);
            
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoActualizacion");
            }

        }

        public void eliminarEquipoTesoreria(EquipoTesoreria d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteEquipoTesoreria");

            _manejador.agregarParametro(comando, "@equipo", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoEliminacion");
            }

        }

        public bool verificarEquipoTesoreria(EquipoTesoreria d)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteEquipoTesoreria");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@serie", d.Serie, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@numactivo", d.NumActivo, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != d.ID;

                    d.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarEquipo");
            }

            return existe;
        }

        public BindingList<EquipoTesoreria> listarEquiposTesoreria(string r)
        {
            BindingList<EquipoTesoreria> equipos = new BindingList<EquipoTesoreria>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEquiposTesoreria");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@serie", r, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string serie = (string)datareader["Serie"];
                    string numactivo = (string)datareader["NumActivo"];
                    string nombre = (string)datareader["Nombre"];
                    Areas area = (Areas)datareader["Area"];
                    
                    ProveedorEquipo p = new ProveedorEquipo();

                    if (datareader["fk_ID_Proveedor"] != DBNull.Value)
                    {
                        p.Nombre = (string)datareader["NombreProveedor"];
                        p.ID = (int)datareader["fk_ID_Proveedor"];
                    }

                    EquipoTesoreria equipo = new EquipoTesoreria(id: id, serie: serie, nom: nombre, activonum: numactivo, provedor: p, area:area);

                    equipos.Add(equipo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return equipos;
        }

        #endregion Métodos Públicos
    }

}
