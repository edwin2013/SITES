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
    public class TipoPenalidadDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TipoPenalidadDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TipoPenalidadDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TipoPenalidadDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TipoPenalidadDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una TipoPenalidad
        /// </summary>
        /// <param name="f">Objeto TipoPenalidad con los datos de la tipopenalidad</param>
        public void agregarTipoPenalidad(ref TipoPenalidad f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTipoPenalidad");

            _manejador.agregarParametro(comando, "@descripcion", f.Nombre, SqlDbType.VarChar);


            try
            {
                int id_nuevo = (int)_manejador.ejecutarEscalar(comando);
                f.Id = (short)id_nuevo;
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoPenalidadRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una TipoPenalidad en el sistema.
        /// </summary>
        /// <param name="f">Objeto TipoPenalidad con los datos de la TipoPenalidad</param>
        public void actualizarTipoPenalidad(ref TipoPenalidad f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTipoPenalidad");

            _manejador.agregarParametro(comando, "@descripcion", f.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipopenalidad", f, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoPenalidadActualizacion");
            }

        }
        
        /// <summary>
        /// Eliminar los datos de una TipoPenalidad
        /// </summary>
        /// <param name="f">Objeto TipoPenalidad con los datos de la tipopenalidad a eliminar</param>
        public void eliminarTipoPenalidad(TipoPenalidad f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTipoPenalidad");

            _manejador.agregarParametro(comando, "@tipopenalidad", f.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTipoPenalidadEliminacion");
            }

        }

        /// <summary>
        /// Listar las TipoPenalidads registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las TipoPenalidads registrados en el sistema</returns>
        public BindingList<TipoPenalidad> listarTipoPenalidads(string b)
        {
            BindingList<TipoPenalidad> tipopenalidads = new BindingList<TipoPenalidad>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTipoPenalidades");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre", b, SqlDbType.VarChar);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_tipopenalidad = (int)datareader["ID_TipoPenalidad"];
                    string descripcion = (string)datareader["Descripcion"];
                    short nuevo_id = (short)id_tipopenalidad;
                    TipoPenalidad tipopenalidad = new TipoPenalidad(id:nuevo_id,nombre:descripcion);

                    tipopenalidads.Add(tipopenalidad);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tipopenalidads;
        }


        /// <summary>
        /// Verificar si existe una tipopenalidad.
        /// </summary>
        /// <param name="f">Objeto TipoPenalidad con los datos de la TipoPenalidad a verificar</param>
        /// <returns>Valor que indica si la TipoPenalidad existe</returns>
        public bool verificarTipoPenalidad(ref TipoPenalidad f)
        {
            bool existe = false;

            //SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTipoPenalidad");
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
            //    throw new Excepcion("ErrorVerificarTipoPenalidadDuplicada");
            //}

            return existe;
        }

        /// <summary>
        /// Obtener los datos de una TipoPenalidad.
        /// </summary>
        /// <param name="f">TipoPenalidad para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si la TipoPenalidad existe</returns>
        public bool obtenerDatosTipoPenalidad(ref TipoPenalidad f)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTipoPenalidadDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@id", f, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id_tipopenalidad = (short)datareader["ID_TipoPenalidad"];
                    string descripcion = (string)datareader["Descripcion"];
     
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
