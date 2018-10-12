//
//  @ Project : 
//  @ File Name : RegistrosHorasExtraDL.cs
//  @ Date : 08/08/2011
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
    /// Clase de la capa de datos que maneja los registros de horas extra.
    /// </summary>
    public class RegistrosHorasExtraDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RegistrosHorasExtraDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RegistrosHorasExtraDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RegistrosHorasExtraDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RegistrosHorasExtraDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Agregar un registro de horas extra en la base de datos.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro</param>
        public void agregarRegistroHorasExtra(ref RegistroHorasExtra r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRegistroHorasExtra");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", r.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", r.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora_ingreso", r.Hora_ingreso, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_salida", r.Hora_salida, SqlDbType.DateTime);

            _manejador.agregarParametro(comando, "@horas_dobles", r.Horas_dobles, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@horas_extra", r.Horas_extra, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@horas_dobles_extra", r.Horas_dobles_extra, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@alimentacion", r.Alimentacion, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@transporte", r.Transporte, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@observaciones_conceptos", r.Observaciones_conceptos, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@observaciones_gastos", r.Observaciones_gastos, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["ID"];
                    DateTime fecha_registro = (DateTime)datareader["Fecha_Registro"];

                    r.Id = id;
                    r.Fecha_registro = fecha_registro;
                }



                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un registro de horas extra.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro a actualizar</param>
        public void actualizarRegistroHorasExtra(RegistroHorasExtra r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRegistroHorasExtra");

            _manejador.agregarParametro(comando, "@colaborador", r.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora_ingreso", r.Hora_ingreso, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_salida", r.Hora_salida, SqlDbType.DateTime);

            _manejador.agregarParametro(comando, "@horas_dobles", r.Horas_dobles, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@horas_extra", r.Horas_extra, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@horas_dobles_extra", r.Horas_dobles_extra, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@alimentacion", r.Alimentacion, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@transporte", r.Transporte, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@observaciones_conceptos", r.Observaciones_conceptos, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@observaciones_gastos", r.Observaciones_gastos, SqlDbType.VarChar);

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraActualizacion");
            }

        }

        /// <summary>
        /// Actualizar un registro de horas extra marcándolo como aprobado.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro a actualizar</param>
        public void actualizarRegistroHorasExtraAprobar(RegistroHorasExtra r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRegistroHorasExtraAprobar");

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraActualizacion");
            }

        }

        /// <summary>
        /// Actualizar un registro de horas extra marcándolo como rechazado.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro a actualizar</param>
        /// <param name="s">Objeto Supervisor con los datos del supervisor que rechaza el registro</param>
        /// <param name="c">Comentario relacionado con el rechazo</param>
        public void actualizarRegistroHorasExtraRechazar(RegistroHorasExtra r, Colaborador s, string c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRegistroHorasExtraRechazar");

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@supervisor", s, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c, SqlDbType.VarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un registro de horas extra.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro a eliminar</param>
        public void eliminarRegistroHorasExtra(RegistroHorasExtra r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRegistroHorasExtra");

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraEliminacion");
            }

        }

        /// <summary>
        /// Verificar si existe un registro de horas extra para un usuario dado en una fecha dada.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro a verificar</param>
        /// <returns>Valor que indica si el registro existe</returns>
        public bool verificarRegistroHorasExtra(RegistroHorasExtra r)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteRegistroHorasExtra");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", r.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora_ingreso", r.Hora_ingreso, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@hora_salida", r.Hora_salida, SqlDbType.DateTime);

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
                throw new Excepcion("ErrorVerificarRegistroHorasExtraDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Listar todos los registros de horas extra para todos los colaboradores de un area determinada en un periodo de tiempo determinado.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de registros de horas extra incluidos en el sistema</returns>
        public BindingList<RegistroHorasExtra> listarRegistrosHorasExtra(Areas a, DateTime i, DateTime f)
        {
            BindingList<RegistroHorasExtra> registros = new BindingList<RegistroHorasExtra>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRegistrosHorasExtra");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@inicio", i, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fin", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@area", a, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_registro = (int)datareader["ID_Registro"];
                    DateTime fecha_registro = (DateTime)datareader["Fecha_Registro"];
                    DateTime hora_ingreso = (DateTime)datareader["Hora_Ingreso"];
                    DateTime hora_salida = (DateTime)datareader["Hora_Salida"];
                    Estados estado = (Estados)datareader["Estado"];

                    decimal horas_dobles = (decimal)datareader["Horas_Dobles"];
                    decimal horas_extra = (decimal)datareader["Horas_Extra"];
                    decimal horas_dobles_extra = (decimal)datareader["Horas_Dobles_Extra"];
                    decimal alimentacion = (decimal)datareader["Alimentacion"];
                    decimal transporte = (decimal)datareader["Transporte"];

                    string observaciones_conceptos = (string)datareader["Observaciones_Conceptos"];
                    string observaciones_gastos = (string)datareader["Observaciones_Gastos"];

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

                    RegistroHorasExtra registro = new RegistroHorasExtra(id: id_registro, colaborador: colaborador, coordinador: coordinador,
                                                                         fecha_registro: fecha_registro, hora_ingreso: hora_ingreso,
                                                                         hora_salida: hora_salida, horas_extra: horas_extra,
                                                                         horas_dobles: horas_dobles, horas_dobles_extra: horas_dobles_extra,
                                                                         alimentacion: alimentacion, transporte: transporte, estado: estado,
                                                                         observaciones_conceptos: observaciones_conceptos,
                                                                         observaciones_gastos: observaciones_gastos);

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
        /// Listar todos los registros de horas extra para un colaborador específico en un periodo de tiempo determinado.
        /// </summary>
        /// <param name="c">Colaborador para el cual se genera la lista</param>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de registros de horas extra incluidos en el sistema</returns>
        public BindingList<RegistroHorasExtra> listarRegistrosHorasExtraColaborador(Colaborador c, DateTime i, DateTime f)
        {
            BindingList<RegistroHorasExtra> registros = new BindingList<RegistroHorasExtra>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRegistrosHorasExtra");
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
                    DateTime fecha_registro = (DateTime)datareader["Fecha_Registro"];
                    DateTime hora_ingreso = (DateTime)datareader["Hora_Ingreso"];
                    DateTime hora_salida = (DateTime)datareader["Hora_Salida"];
                    Estados estado = (Estados)datareader["Estado"];

                    decimal horas_dobles = (decimal)datareader["Horas_Dobles"];
                    decimal horas_extra = (decimal)datareader["Horas_Extra"];
                    decimal horas_dobles_extra = (decimal)datareader["Horas_Dobles_Extra"];
                    decimal alimentacion = (decimal)datareader["Alimentacion"];
                    decimal transporte = (decimal)datareader["Transporte"];

                    string observaciones_conceptos = (string)datareader["Observaciones_Conceptos"];
                    string observaciones_gastos = (string)datareader["Observaciones_Gastos"];

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

                    RegistroHorasExtra registro = new RegistroHorasExtra(id: id_registro, colaborador: colaborador, coordinador: coordinador,
                                                                         fecha_registro: fecha_registro, hora_ingreso: hora_ingreso,
                                                                         hora_salida: hora_salida, horas_extra: horas_extra,
                                                                         horas_dobles: horas_dobles, horas_dobles_extra: horas_dobles_extra,
                                                                         alimentacion: alimentacion, transporte: transporte, estado: estado,
                                                                         observaciones_conceptos: observaciones_conceptos,
                                                                         observaciones_gastos: observaciones_gastos);

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
        /// Ligar un motivo con un registro de horas extra.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro</param>
        /// <param name="m">Motivo a ligar con el registro</param>
        public void agregarMotivoRegistroHorasExtra(RegistroHorasExtra r, Motivos m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRegistroHorasExtraMotivo");

            _manejador.agregarParametro(comando, "@motivo", m, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraActualizacion");
            }

        }

        /// <summary>
        /// Desligar un motivo de un registro de horas extra.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro</param>
        /// <param name="m">Motivo a desligar del registro</param>
        public void eliminarMotivoRegistroHorasExtra(RegistroHorasExtra r, Motivos m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRegistroHorasExtraMotivo");

            _manejador.agregarParametro(comando, "@motivo", m, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraActualizacion");
            }

        }

        /// <summary>
        /// Obtener los motivos para un registro de horas extra.
        /// </summary>
        /// <param name="r">Registro para el cual se obtienen los motivos</param>
        public void obtenerMotivosRegistroHorasExtra(ref RegistroHorasExtra r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRegistroHorasExtraMotivos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    Motivos motivo = (Motivos)datareader["Motivo"];

                    r.agregarMotivo(motivo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Ligar un puesto con un registro de horas extra.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro</param>
        /// <param name="p">Puesto a ligar con el registro</param>
        public void agregarPuestoRegistroHorasExtra(RegistroHorasExtra r, Puestos p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRegistroHorasExtraPuesto");

            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraActualizacion");
            }

        }

        /// <summary>
        /// Desligar un puesto de un registro de horas extra.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro</param>
        /// <param name="p">Puesto a desligar del registro</param>
        public void eliminarPuestoRegistroHorasExtra(RegistroHorasExtra r, Puestos p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRegistroHorasExtraPuesto");

            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroHorasExtraActualizacion");
            }

        }

        /// <summary>
        /// Obtener los puestos para un registro de horas extra.
        /// </summary>
        /// <param name="r">Registro para el cual se obtienen los puestos</param>
        public void obtenerPuestosRegistroHorasExtra(ref RegistroHorasExtra r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRegistroHorasExtraPuestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    Puestos puesto = (Puestos)datareader["Puesto"];

                    r.agregarPuesto(puesto);
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
