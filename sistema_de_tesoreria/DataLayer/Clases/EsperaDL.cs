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
    public class EsperaDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static EsperaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static EsperaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EsperaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public EsperaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto Espera con los datos de la nueva cámara</param>
        public void agregarEspera(ref Espera c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertEspera");

            _manejador.agregarParametro(comando, "@codigo", c.Identificador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.NVarChar);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEsperaRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto Espera con los datos de la cámara a actualizar</param>
        public void actualizarEspera(Espera c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEspera");

            _manejador.agregarParametro(comando, "@codigo", c.Identificador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@descipcion", c.Descripcion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@espera", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEsperaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto Espera con los datos de la cámara a eliminar</param>
        public void eliminarEspera(Espera c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteEspera");

            _manejador.agregarParametro(comando, "@Espera", c, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEsperaEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las cámaras registradas.
        /// </summary>
        /// <returns>Lista de cámaras registradas en el sistema</returns>
        public BindingList<Espera> listarEsperas()
        {
            BindingList<Espera> Esperas = new BindingList<Espera>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEsperas");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];


                    string identificador = "";
                    
                    if(datareader["Codigo"]!= DBNull.Value)
                        identificador = (string)datareader["Codigo"];


                    string descripcion = "";
                    
                    if(datareader["Nombre"]!=DBNull.Value)
                       descripcion = (string)datareader["Nombre"];

                    Espera Espera = new Espera(identificador, id: id, descripcion: descripcion);

                    Esperas.Add(Espera);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return Esperas;
        }

       
       
        #endregion Métodos Públicos
    }
}
