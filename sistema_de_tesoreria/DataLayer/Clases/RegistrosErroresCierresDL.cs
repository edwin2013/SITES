//
//  @ Project : 
//  @ File Name : RegistrosErroresCierresDL.cs
//  @ Date : 05/03/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los registros de los errores en los cierres.
    /// </summary>
    public class RegistrosErroresCierresDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RegistrosErroresCierresDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RegistrosErroresCierresDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RegistrosErroresCierresDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RegistrosErroresCierresDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Agregar un registro de errores de cierre en la base de datos.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierreCajero con los datos del registro</param>
        public void agregarRegistroErroresCierre(ref RegistroErroresCierre r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRegistroErroresCierre");

            _manejador.agregarParametro(comando, "@colaborador", r.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", r.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", r.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@sin_errores", r.Sin_errores, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@otros_errores", r.Otros_errores, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@observaciones", r.Observaciones, SqlDbType.VarChar);

            try
            {
                r.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroErroresCierreRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un registro de errores para un cierre.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierre con los datos del registro a actualizar</param>
        public void actualizarRegistroErroresCierre(RegistroErroresCierre r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRegistroErroresCierre");

            _manejador.agregarParametro(comando, "@colaborador", r.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", r.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@sin_errores", r.Sin_errores, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@otros_errores", r.Otros_errores, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@observaciones", r.Observaciones, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroErroresCierreActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un registro de errores de un cierre.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierre con los datos del registro a eliminar</param>
        public void eliminarRegistroErroresCierre(RegistroErroresCierre r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRegistroErroresCierre");

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroErroresCierreEliminacion");
            }

        }

        /// <summary>
        /// Verificar si existe un registro de errores para un cierre en una fecha dada.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierre con los datos del registro a verificar</param>
        /// <returns>Valor que indica si el registro existe</returns>
        public bool verificarRegistroErroresCierre(RegistroErroresCierre r)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteRegistroErroresCierre");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", r.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", r.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado =  (int)datareader["pk_ID"];

                    existe = r.Id > 0 ? id_encontrado != r.Id : true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarRegistroErroresCierreDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Listar todos los registros de errores en un periodo de tiempo determinado.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de registros de errores incluidos en el sistema</returns>
        public BindingList<RegistroErroresCierre> listarRegistrosErroresCierres(DateTime i, DateTime f)
        {
            BindingList<RegistroErroresCierre> registros = new BindingList<RegistroErroresCierre>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRegistrosErroresCierres");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@inicio", i, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fin", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_registro = (int)datareader["ID_Registro"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    bool sin_errores = (bool)datareader["Sin_Errores"];
                    string otros_errores = (string)datareader["Otros_Errores"];
                    string observaciones = (string)datareader["Observaciones"];

                    int id_colaborador = (int)datareader["ID_Colaborador"];
                    string nombre_colaborador = (string)datareader["Nombre_Colaborador"];
                    string primer_apellido_colaborador = (string)datareader["Primer_Apellido_Colaborador"];
                    string segundo_apellido_colaborador = (string)datareader["Segundo_Apellido_Colaborador"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    Colaborador colaborador = new Colaborador(id_colaborador, nombre_colaborador, primer_apellido_colaborador,
                                                              segundo_apellido_colaborador);
                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador, primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);
                    RegistroErroresCierre registro = new RegistroErroresCierre(id_registro, colaborador, coordinador,
                                                                               fecha, sin_errores, otros_errores, observaciones);

                    registros.Add(registro);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return registros;
        }

        /// <summary>
        /// Listar todos los registros de errores de cierres para un colaborador específico en un periodo de tiempo determinado.
        /// </summary>
        /// <param name="c">Cajero para el cual se genera la lista</param>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de registros de errores de cajeros incluidos en el sistema</returns>
        public BindingList<RegistroErroresCierre> listarRegistrosErroresCierresColaborador(Colaborador c, DateTime i, DateTime f)
        {
            BindingList<RegistroErroresCierre> registros = new BindingList<RegistroErroresCierre>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRegistrosErroresCierresColaborador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@inicio", i, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fin", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_registro = (int)datareader["ID_Registro"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    bool sin_errores = (bool)datareader["Sin_Errores"];
                    string otros_errores = (string)datareader["Otros_Errores"];
                    string observaciones = (string)datareader["Observaciones"];

                    int id_colaborador = (int)datareader["ID_Colaborador"];
                    string nombre_colaborador = (string)datareader["Nombre_Colaborador"];
                    string primer_apellido_colaborador = (string)datareader["Primer_Apellido_Colaborador"];
                    string segundo_apellido_colaborador = (string)datareader["Segundo_Apellido_Colaborador"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    Colaborador colaborador = new Colaborador(id_colaborador, nombre_colaborador, primer_apellido_colaborador,
                                                              segundo_apellido_colaborador);
                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador, primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);
                    RegistroErroresCierre registro = new RegistroErroresCierre(id_registro, colaborador, coordinador,
                                                                               fecha, sin_errores, otros_errores, observaciones);

                    registros.Add(registro);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return registros;
        }

        /// <summary>
        /// Ligar un tipo de error con un registro errores.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierre con los datos del registro</param>
        /// <param name="t">Tipo de error a ligar con el registro</param>
        public void agregarErrorRegistroErroresCierre(RegistroErroresCierre r, TipoErrorCierre t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRegistroErroresCierreTipoErrorCierre");

            _manejador.agregarParametro(comando, "@tipo_error", t.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroErroresCierreActualizacion");
            }

        }

        /// <summary>
        /// Desligar un tipo de error de un registro de errores.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierre con los datos del registro</param>
        /// <param name="t">Tipo de error a desligar del registro</param>
        public void eliminarErrorRegistroErroresCierre(RegistroErroresCierre r, TipoErrorCierre t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRegistroErroresCierreTipoErrorCierre");

            _manejador.agregarParametro(comando, "@tipo_error", t.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroErroresCierreActualizacion");
            }

        }

        /// <summary>
        /// Obtener los tipos de errores para un registro de errores de un cierre.
        /// </summary>
        /// <param name="r">Registro para el cual se obtienen los tipos de errores</param>
        public void obtenerErroresRegistroErroresCierre(ref RegistroErroresCierre r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRegistroErroresCierreTiposErrores");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    TipoErrorCierre error = new TipoErrorCierre(id, nombre);

                    r.agregarError(error);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }
        
        #endregion Métodos Públicos

    }

}
