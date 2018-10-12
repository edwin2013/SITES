//
//  @ Project : 
//  @ File Name : CamarasDL.cs
//  @ Date : 28/07/2011
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
    /// Clase de la capa de datos que maneja las cámaras.
    /// </summary>
    public class CamarasDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CamarasDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CamarasDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CamarasDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CamarasDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la nueva cámara</param>
        public void agregarCamara(ref Camara c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCamara");

            _manejador.agregarParametro(comando, "@identificador", c.Identificador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@area", c.Area, SqlDbType.TinyInt);

            try
            {
                c.ID = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCamaraRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la cámara a actualizar</param>
        public void actualizarCamara(Camara c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCamara");

            _manejador.agregarParametro(comando, "@identificador", c.Identificador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@area", c.Area, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@camara", c, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCamaraActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la cámara a eliminar</param>
        public void eliminarCamara(Camara c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCamara");

            _manejador.agregarParametro(comando, "@camara", c, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCamaraEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las cámaras registradas.
        /// </summary>
        /// <returns>Lista de cámaras registradas en el sistema</returns>
        public BindingList<Camara> listarCamaras()
        {
            BindingList<Camara> camaras = new BindingList<Camara>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCamaras");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string identificador = (string)datareader["Identificador"];
                    Areas area = (Areas)datareader["Area"];

                    Camara camara = new Camara(identificador, id: id, area: area);

                    camaras.Add(camara);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return camaras;
        }

        /// <summary>
        /// Listar todas las cámaras registradas en una área específica.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <returns>Lista de cámaras registradas en el sistema que pertenecen al área especificada</returns>
        public BindingList<Camara> listarCamarasPorArea(Areas a)
        {
            BindingList<Camara> camaras = new BindingList<Camara>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCamarasArea");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@area", a, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string identificador = (string)datareader["Identificador"];

                    Camara camara = new Camara(identificador, id: id);

                    camaras.Add(camara);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return camaras;
        }
       
        #endregion Métodos Públicos

    }

}
