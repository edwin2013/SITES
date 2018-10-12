using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;

namespace DataLayer.Clases
{
    public class DispositivoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static DispositivoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static DispositivoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new DispositivoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public DispositivoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo dispositivo.
        /// </summary>
        /// <param name="c">Objeto Dispositivo con los datos del nuevo dispositivo</param>
        public void agregarDispositivo(ref Dispositivo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDispositivo");

            _manejador.agregarParametro(comando, "@serial", c.Serial, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.VarChar);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDispositivoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un dispositivo.
        /// </summary>
        /// <param name="c">Objeto Dispositivo con los datos del dispositivo a actualizar</param>
        public void actualizarDispositivo(Dispositivo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDispositivo");

            _manejador.agregarParametro(comando, "@serial", c.Serial, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@dispositivo", c.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.VarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDispositivoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un dispositivo.
        /// </summary>
        /// <param name="c">Objeto Dispositivo con los datos del dispositivo a eliminar</param>
        public void eliminarDispositivo(Dispositivo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteDispositivo");

            _manejador.agregarParametro(comando, "@dispositivo", c.ID, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDispositivoEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los dispositivoes registrados.
        /// </summary>
        /// <returns>Lista de dispositivoes registrados en el sistema</returns>
        public BindingList<Dispositivo> listarDispositivoes()
        {
            BindingList<Dispositivo> dispositivoes = new BindingList<Dispositivo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDispositivos");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Serial"];

                    string descripcion = "";
                    if (datareader["Descripcion"] != DBNull.Value)
                    {
                        descripcion = (string)datareader["Descripcion"]; 
                    }
                        

                    Dispositivo dispositivo = new Dispositivo(nombre,descripcion:descripcion,id:id);
                    dispositivoes.Add(dispositivo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return dispositivoes;
        }
       
        #endregion Métodos Públicos
    }
}
