using CommonObjects;
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
    public class FeriadosDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static FeriadosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static FeriadosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new FeriadosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public FeriadosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un feriado en el sistema.
        /// </summary>
        /// <param name="f">Objeto Feriado con los datos del nuevo feriado</param>
        public void agregarFeriado(ref Feriado f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertFeriado");

            _manejador.agregarParametro(comando, "@descripcion", f.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha_inicio", f.Fecha_inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_finalizacion", f.Fecha_finalizacion, SqlDbType.DateTime);

            try
            {
                f.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFeriadoRegistro");
            }

        }

       

        /// <summary>
        /// Actualizar los datos de un feriado en el sistema.
        /// </summary>
        /// <param name="f">Objeto Feriado con los datos del feriado</param>
        public void actualizarFeriado(Feriado f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFeriado");

            _manejador.agregarParametro(comando, "@descripcion", f.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha_inicio", f.Fecha_inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_finalizacion", f.Fecha_finalizacion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@feriado", f.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFeriadoActualizacion");
            }

        }

        /// <summary>
        /// Marcar un feriado como terminado.
        /// </summary>
        /// <param name="f">Objeto Feriado con los datos del feriado a terminar</param>
        public void terminarFeriado(Feriado f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFeriadoTerminar");

            _manejador.agregarParametro(comando, "@feriado", f.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFeriadoTerminacion");
            }

        }

       

        /// <summary>
        /// Eliminar un feriado del sistema.
        /// </summary>
        /// <param name="f">Objeto Feriado con los datos del feriado a eliminar</param>
        public void eliminarFeriado(Feriado f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteFeriado");

            _manejador.agregarParametro(comando, "@feriado", f.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFeriadoEliminacion");
            }

        }

        /// <summary>
        /// Listar los feriados registradas en el sistema en las áreas de un usuario.
        /// </summary>
        /// <param name="u">Usuario para el cual se genera la lista</param>
        /// <returns>Lista de los feriados registrados en el sistema</returns>
        public BindingList<Feriado> listarFeriados(Colaborador u)
        {
            BindingList<Feriado> feriados = new BindingList<Feriado>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectFeriados");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@usuario", u.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string descripcion = (string)datareader["Descripcion"];
                    DateTime fecha_inicio = (DateTime)datareader["Fecha_Inicio"];
                    DateTime fecha_finalizacion = (DateTime)datareader["Fecha_Finalizacion"];

                    Feriado feriado = new Feriado(id, descripcion, fecha_inicio, fecha_finalizacion);

                    feriados.Add(feriado);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return feriados;
        }

      

        #endregion Métodos Públicos
    }
}
