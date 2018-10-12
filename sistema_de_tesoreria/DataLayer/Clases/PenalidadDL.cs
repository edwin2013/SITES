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
    public class PenalidadDL : ObjetoIndexado
    {
         #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PenalidadDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PenalidadDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PenalidadDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PenalidadDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva penalidad.
        /// </summary>
        /// <param name="c">Objeto Penalidad con los datos de la nueva penalidad</param>
        public void agregarPenalidad(ref Penalidad c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPenalidad");

            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoPenalidad.Id, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPenalidadRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una penalidad.
        /// </summary>
        /// <param name="c">Objeto Penalidad con los datos de la penalidad a actualizar</param>
        public void actualizarPenalidad(Penalidad c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePenalidad");

            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoPenalidad.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@penalidad", c.ID, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPenalidadActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una penalidad.
        /// </summary>
        /// <param name="c">Objeto Penalidad con los datos de la penalidad a eliminar</param>
        public void eliminarPenalidad(Penalidad c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePenalidad");

            _manejador.agregarParametro(comando, "@penalidad", c, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPenalidadEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las penalidads registradas.
        /// </summary>
        /// <returns>Lista de penalidads registradas en el sistema</returns>
        public BindingList<Penalidad> listarPenalidads()
        {
            BindingList<Penalidad> Penalidads = new BindingList<Penalidad>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPenalidades");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string identificador = (string)datareader["Descripcion"];

                    int id_tipo_penalidad = (int)datareader["ID_Tipo"];
                    string descripcion_tipo = (string)datareader["Descripcion_Tipo"];

                    TipoPenalidad tip = new TipoPenalidad(id: (short)id_tipo_penalidad, nombre: descripcion_tipo);

                    Penalidad Penalidad = new Penalidad(id: id, tipopenalidad: tip, descripcion: identificador);

                    Penalidads.Add(Penalidad);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return Penalidads;
        }

        /// <summary>
        /// Listar todas las penalidads registradas en una Penalidad específica.
        /// </summary>
        /// <param name="a">Penalidad para la cual se genera la lista</param>
        /// <returns>Lista de penalidads registradas en el sistema que pertenecen al Penalidad especificada</returns>
        public BindingList<Penalidad> listarPenalidadsPorArea(string b)
        {
            BindingList<Penalidad> Penalidads = new BindingList<Penalidad>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPenalidadsArea");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@descripcion", b, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string identificador = (string)datareader["Descripcion"];


                    int id_tipo_penalidad = (int)datareader["ID_Tipo"];
                    string descripcion_tipo = (string)datareader["Descripcion_Tipo"];

                    TipoPenalidad tip = new TipoPenalidad(id: (short)id_tipo_penalidad, nombre: descripcion_tipo);

                    Penalidad Penalidad = new Penalidad(id:id, descripcion : identificador, tipopenalidad: tip);

                    Penalidads.Add(Penalidad);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return Penalidads;
        }
       
        #endregion Métodos Públicos
    }
}
