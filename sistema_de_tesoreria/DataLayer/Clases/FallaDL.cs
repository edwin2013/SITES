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

namespace DataLayer.Clases
{
    public class FallaDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static FallaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static FallaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new FallaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public FallaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una Falla
        /// </summary>
        /// <param name="f">Objeto Falla con los datos de la falla</param>
        public void agregarFalla(ref Falla f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertFalla");

            _manejador.agregarParametro(comando, "@descripcion", f.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipofalla", f.Tipo_Falla, SqlDbType.TinyInt);

            try
            {
                f.ID = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFallaRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una Falla en el sistema.
        /// </summary>
        /// <param name="f">Objeto Falla con los datos de la Falla</param>
        public void actualizarFalla(ref Falla f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFalla");

            _manejador.agregarParametro(comando, "@descripcion", f.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipo", f.Tipo_Falla, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@falla", f, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFallaActualizacion");
            }

        }
        
        /// <summary>
        /// Eliminar los datos de una Falla
        /// </summary>
        /// <param name="f">Objeto Falla con los datos de la falla a eliminar</param>
        public void eliminarFalla(Falla f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteFalla");

            _manejador.agregarParametro(comando, "@falla", f, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFallaEliminacion");
            }

        }

        /// <summary>
        /// Listar las Fallas registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las Fallas registrados en el sistema</returns>
        public BindingList<Falla> listarFallas(string b, TipoFallasBlindados t)
        {
            BindingList<Falla> fallas = new BindingList<Falla>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectFallas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre", b, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipo", t, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_falla = (short)datareader["ID_Falla"];
                    string descripcion_falla = (string)datareader["Descripcion"];
                    TipoFallasBlindados tipofalla = new TipoFallasBlindados(); 


                    if(datareader["Tipo"]!=DBNull.Value)
                    {
                        int id_tipofalla = (int)datareader["Tipo"];
                        string descripcion_tipo_fallas = (string)datareader["Descripcion_tipo"];

                        tipofalla = new TipoFallasBlindados(id: id_tipofalla, descripcion: descripcion_tipo_fallas);
                    }
                    
                
                    Falla vehiculo = new Falla(id:id_falla,descripcion:descripcion_falla,tipo:tipofalla);

                    fallas.Add(vehiculo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return fallas;
        }


        /// <summary>
        /// Verificar si existe una falla.
        /// </summary>
        /// <param name="f">Objeto Falla con los datos de la Falla a verificar</param>
        /// <returns>Valor que indica si la Falla existe</returns>
        public bool verificarFalla(ref Falla f)
        {
            bool existe = false;

            //SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteFalla");
            //SqlDataReader datareader = null;

            //_manejador.agregarParametro(comando, "@descripcon", f.Descripcion, SqlDbType.NChar);

            //try
            //{
            //    datareader = _manejador.ejecutarConsultaDatos(comando);

            //    if (datareader.Read())
            //    {
            //        short id = (short)datareader["pk_ID"];

            //        existe = id != f.ID;

            //        f.ID = id;
            //    }

            //    comando.Connection.Close();
            //}
            //catch (Exception)
            //{
            //    comando.Connection.Close();
            //    throw new Excepcion("ErrorVerificarFallaDuplicada");
            //}

            return existe;
        }

        /// <summary>
        /// Obtener los datos de una Falla.
        /// </summary>
        /// <param name="f">Falla para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si la Falla existe</returns>
        public bool obtenerDatosFalla(ref Falla f)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectFallaDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@id", f, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id_falla = (short)datareader["ID_Falla"];
                    string descripcion = (string)datareader["Descripcion"];
                    TipoFalla tipo = (TipoFalla)datareader["Tipo"];
                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return existe;
        }


        #endregion Métodos Públicos
    }
}
