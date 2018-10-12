using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace DataLayer
{
    public class InconsistenciaPlanillaDL
    {
        #region Atributos
        /// Instancia única del manejador.
        private static InconsistenciaPlanillaDL _instancia;
        private ManejadorBD _manejador = ManejadorBD.Instancia;
        ColaboradoresDL _col = ColaboradoresDL.Instancia;
        EmpresasTransporteDL _emp = EmpresasTransporteDL.Instancia;
        PlanillasEmpresasDL _gru = PlanillasEmpresasDL.Instancia; 
        
        /// Obtener la instancia única del manejador.
        public static InconsistenciaPlanillaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new InconsistenciaPlanillaDL();
                return _instancia;
            }
        }
        #endregion Atributos

        #region Constructor

        public InconsistenciaPlanillaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void insertaInconsistencia(ref InconsistenciaPlanilla s, ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInconsistenciaPlanilla");

            _manejador.agregarParametro(comando, "@tula", s.Tula, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@manifiesto", s.manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", s.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", s.Comentario, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@estado", s.Estado, SqlDbType.TinyInt);  
            _manejador.agregarParametro(comando, "@fecharesolucion", s.FechaResolucion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@tipo", s.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@origen", s.Origen, SqlDbType.TinyInt);
           
            

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }

        }



        public void insertaInconsistenciaProcesamiento(ref InconsistenciaPlanilla s, ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInconsistenciaPlanillaProcesamiento");

            _manejador.agregarParametro(comando, "@tula", s.Tula, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@manifiesto", s.manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", s.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", s.Comentario, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@estado", s.Estado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecharesolucion", s.FechaResolucion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@tipo", s.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@origen", s.Origen, SqlDbType.TinyInt);



            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }

        }

        public BindingList<InconsistenciaPlanilla> Listar(ref DateTime fecha, ref EmpresaTransporte c, ref Colaborador col)
        {
            BindingList<InconsistenciaPlanilla> incon = new BindingList<InconsistenciaPlanilla>();
            SqlCommand comando = _manejador.obtenerProcedimiento("ListarInconsistenciasSites");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@empresa", c, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", col, SqlDbType.TinyInt);
            
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                DataTable grupos = new DataTable();
                grupos.Load(datareader);
                comando.Connection.Close();
                foreach (DataRow row in grupos.Rows)
                {
                    InconsistenciaPlanilla dato = new InconsistenciaPlanilla();

                    Colaborador nuevo = new Colaborador();
                    EmpresaTransporte empresa = new EmpresaTransporte();
                    PlanillasEmpresasDL grupo = new PlanillasEmpresasDL();

                    int cod = 0;
                    nuevo.ID = (int)row["fk_ID_Colaborador"];
                    empresa.ID = (byte)row["fk_ID_Transportadora"];
                    cod = (byte)row["fk_ID_Grupo"];

                    //_col.obtenerDatosColaborador(ref nuevo);
                    empresa = _emp.obtenerDatosEmpresa(ref empresa);

                    dato.Colaborador = nuevo;
                    dato.Comentario = (string)row["Comentario"];
                    dato.Empresa = empresa;
                    dato.Tipo = (Tipo)row["TipoInconsistencia"];
                    dato.Estado = (Estado)row["Estado"];
                    dato.Fecha = (DateTime)row["Fecha_Transaccion"];
                    dato.FechaResolucion = (DateTime)row["FechaResolucion"];
                    dato.Grupo = grupo.SeleccionarGrupo(ref cod);
                    dato.manifiesto = (string)row["Codigo"];
                    dato.Tula = (string)row["Tula"];
                    dato.TulaPl = (string)row["TulaPl"];

                    incon.Add(dato);
                    
                }
                //comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }
            return incon;
        }










        public BindingList<InconsistenciaPlanilla> ListarProcesamiento(ref DateTime fecha, ref EmpresaTransporte c, ref Colaborador col)
        {
            BindingList<InconsistenciaPlanilla> incon = new BindingList<InconsistenciaPlanilla>();
            SqlCommand comando = _manejador.obtenerProcedimiento("ListarInconsistenciasProcesamientoSites");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@empresa", c, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", col, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                DataTable grupos = new DataTable();
                grupos.Load(datareader);
                comando.Connection.Close();
                foreach (DataRow row in grupos.Rows)
                {
                    InconsistenciaPlanilla dato = new InconsistenciaPlanilla();

                    Colaborador nuevo = new Colaborador();
                    EmpresaTransporte empresa = new EmpresaTransporte();
                    PlanillasEmpresasDL grupo = new PlanillasEmpresasDL();

                    int cod = 0;
                    nuevo.ID = (int)row["fk_ID_Colaborador"];
                    empresa.ID = (byte)row["fk_ID_Transportadora"];
                    cod = (byte)row["fk_ID_Grupo"];

                    //_col.obtenerDatosColaborador(ref nuevo);
                    empresa = _emp.obtenerDatosEmpresa(ref empresa);

                    dato.Colaborador = nuevo;
                    dato.Comentario = (string)row["Comentario"];
                    dato.Empresa = empresa;
                    dato.Tipo = (Tipo)row["TipoInconsistencia"];
                    dato.Estado = (Estado)row["Estado"];
                    dato.Fecha = (DateTime)row["Fecha_Transaccion"];
                    dato.FechaResolucion = (DateTime)row["FechaResolucion"];
                    dato.Grupo = grupo.SeleccionarGrupo(ref cod);
                    dato.manifiesto = (string)row["Codigo"];
                    dato.Tula = (string)row["Tula"];
                    dato.TulaPl = (string)row["TulaPl"];

                    incon.Add(dato);

                }
                //comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }
            return incon;
        }

        public BindingList<InconsistenciaPlanilla> Exportar(Estado estado, DateTime fecha, EmpresaTransporte emp)
        {
            BindingList<InconsistenciaPlanilla> incon = new BindingList<InconsistenciaPlanilla>();
            SqlCommand comando = _manejador.obtenerProcedimiento("ExportarInconsistencias");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@empresa", emp, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estado", estado, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                DataTable grupos = new DataTable();
                grupos.Load(datareader);
                comando.Connection.Close();
                foreach (DataRow row in grupos.Rows)
                {
                    InconsistenciaPlanilla dato = new InconsistenciaPlanilla();

                    Colaborador nuevo = new Colaborador();
                    EmpresaTransporte empresa = new EmpresaTransporte();
                    PlanillasEmpresasDL grupo = new PlanillasEmpresasDL();

                    int cod = 0;
                    nuevo.ID = (int)row["fk_ID_Colaborador"];
                    empresa.ID = (byte)row["fk_ID_Transportadora"];
                    cod = (byte)row["fk_ID_Grupo"];

                    //_col.obtenerDatosColaborador(ref nuevo);
                    empresa = _emp.obtenerDatosEmpresa(ref empresa);

                    dato.ID = (int)row["pk_ID"];
                    dato.Colaborador = nuevo;
                    dato.Comentario = (string)row["Comentario"];
                    dato.Empresa = empresa;
                    dato.Tipo = (Tipo)row["TipoInconsistencia"];
                    dato.Estado = (Estado)row["Estado"];
                    dato.Fecha = (DateTime)row["Fecha_Transaccion"];
                    dato.FechaResolucion = (DateTime)row["FechaResolucion"];
                    dato.Grupo = grupo.SeleccionarGrupo(ref cod);
                    dato.manifiesto = (string)row["Codigo"];
                    dato.Tula = (string)row["Tula"];
                    dato.TulaPl = (string)row["TulaPl"];
                    dato.Origen = (Origen)row["Origen"];
                    if(row["Tula_Original"]!=DBNull.Value )
                        dato.TulaOriginal = (string)row["Tula_Original"];
                   
                    dato.Estado = estado;
                                        
                    incon.Add(dato);

                }
                //comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }
            return incon;
        }



        public BindingList<InconsistenciaPlanilla> ExportarProcesamiento(Estado estado, DateTime fecha, EmpresaTransporte emp)
        {
            BindingList<InconsistenciaPlanilla> incon = new BindingList<InconsistenciaPlanilla>();
            SqlCommand comando = _manejador.obtenerProcedimiento("ExportarInconsistenciasProcesamiento");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@empresa", emp, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estado", estado, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                DataTable grupos = new DataTable();
                grupos.Load(datareader);
                comando.Connection.Close();
                foreach (DataRow row in grupos.Rows)
                {
                    InconsistenciaPlanilla dato = new InconsistenciaPlanilla();

                    Colaborador nuevo = new Colaborador();
                    EmpresaTransporte empresa = new EmpresaTransporte();
                    PlanillasEmpresasDL grupo = new PlanillasEmpresasDL();

                    int cod = 0;
                    nuevo.ID = (int)row["fk_ID_Colaborador"];
                    empresa.ID = (byte)row["fk_ID_Transportadora"];
                    cod = (byte)row["fk_ID_Grupo"];

                    //_col.obtenerDatosColaborador(ref nuevo);
                    empresa = _emp.obtenerDatosEmpresa(ref empresa);

                    dato.ID = (int)row["pk_ID"];
                    dato.Colaborador = nuevo;
                    dato.Comentario = (string)row["Comentario"];
                    dato.Empresa = empresa;
                    dato.Tipo = (Tipo)row["TipoInconsistencia"];
                    dato.Estado = (Estado)row["Estado"];
                    dato.Fecha = (DateTime)row["Fecha_Transaccion"];
                    dato.FechaResolucion = (DateTime)row["FechaResolucion"];
                    dato.Grupo = grupo.SeleccionarGrupo(ref cod);
                    dato.manifiesto = (string)row["Codigo"];
                    dato.Tula = (string)row["Codigo"];
                    dato.TulaPl = (string)row["Tula"];
                    dato.Origen = (Origen)row["Origen"];
                    dato.Estado = estado;

                    incon.Add(dato);

                }
                //comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }
            return incon;
        }



        public BindingList<InconsistenciaPlanilla> Reporte(DateTime fecha, EmpresaTransporte emp, DateTime ff)
        {
            BindingList<InconsistenciaPlanilla> incon = new BindingList<InconsistenciaPlanilla>();
            SqlCommand comando = _manejador.obtenerProcedimiento("ReporteInconsistenciasPlanilla");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@empresa", emp, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha_fin", ff, SqlDbType.Date);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                DataTable grupos = new DataTable();
                grupos.Load(datareader);
                comando.Connection.Close();
                foreach (DataRow row in grupos.Rows)
                {
                    InconsistenciaPlanilla dato = new InconsistenciaPlanilla();

                    Colaborador nuevo = new Colaborador();
                    EmpresaTransporte empresa = new EmpresaTransporte();
                    PlanillasEmpresasDL grupo = new PlanillasEmpresasDL();

                    int cod = 0;
                    if (row["Colaborador_ID"] != DBNull.Value)
                    {
                        nuevo.ID = (int)row["Colaborador_ID"];
                        nuevo.Nombre = (string)row["Colaborador_Nombre"];
                        nuevo.Primer_apellido = (string)row["Colaborador_Primer_Apellido"];
                        nuevo.Segundo_apellido = (string)row["Colaborador_Segundo_Apellido"];
                    }
                    if (row["Transportadora_ID"] != DBNull.Value)
                    {
                        int variable = (int)row["Transportadora_ID"];

                        empresa.ID = (byte)variable;
                        empresa.Nombre = (string)row["Transportadora_Nombre"];
                    }

                    if (row["Grupo_ID"] != DBNull.Value)
                    {
                        int variable_grupo = (int)row["Grupo_ID"];
                        cod = (byte)variable_grupo;
                    }
                    
                    
                   

                    //_col.obtenerDatosColaborador(ref nuevo);
                    empresa = _emp.obtenerDatosEmpresa(ref empresa);

                    dato.ID = (int)row["pk_ID"];
                    dato.Colaborador = nuevo;
                    dato.Comentario = (string)row["Comentario"];
                    dato.Empresa = empresa;
                    dato.Tipo = (Tipo)row["TipoInconsistencia"];
                    dato.Estado = (Estado)row["Estado"];
                    dato.Fecha = (DateTime)row["Fecha_Registro"];
                    dato.Grupo = grupo.SeleccionarGrupo(ref cod);
                    dato.manifiesto = (string)row["Manifiesto"];
                    dato.Tula = (string)row["Tula_SITES"];
                    dato.TulaPl = (string)row["Tula_Archivo"];
                    dato.Origen = (Origen)row["Origen"];
   
                    incon.Add(dato);

                }
                //comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }
            return incon;
        }







        public BindingList<InconsistenciaPlanilla> ReporteProcesamiento(DateTime fecha, EmpresaTransporte emp, DateTime ff)
        {
            BindingList<InconsistenciaPlanilla> incon = new BindingList<InconsistenciaPlanilla>();
            SqlCommand comando = _manejador.obtenerProcedimiento("ReporteInconsistenciasPlanillaProcesamiento");
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@empresa", emp, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha_fin", ff, SqlDbType.Date);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                DataTable grupos = new DataTable();
                grupos.Load(datareader);
                comando.Connection.Close();
                foreach (DataRow row in grupos.Rows)
                {
                    InconsistenciaPlanilla dato = new InconsistenciaPlanilla();

                    Colaborador nuevo = new Colaborador();
                    EmpresaTransporte empresa = new EmpresaTransporte();
                    PlanillasEmpresasDL grupo = new PlanillasEmpresasDL();

                    int cod = 0;
                    if (row["Colaborador_ID"] != DBNull.Value)
                    {
                        nuevo.ID = (int)row["Colaborador_ID"];
                        nuevo.Nombre = (string)row["Colaborador_Nombre"];
                        nuevo.Primer_apellido = (string)row["Colaborador_Primer_Apellido"];
                        nuevo.Segundo_apellido = (string)row["Colaborador_Segundo_Apellido"];
                    }
                    if (row["Transportadora_ID"] != DBNull.Value)
                    {
                        int variable = (int)row["Transportadora_ID"];

                        empresa.ID = (byte)variable;
                        empresa.Nombre = (string)row["Transportadora_Nombre"];
                    }

                    if (row["Grupo_ID"] != DBNull.Value)
                    {
                        int variable_grupo = (int)row["Grupo_ID"];
                        cod = (byte)variable_grupo;
                    }




                    //_col.obtenerDatosColaborador(ref nuevo);
                    empresa = _emp.obtenerDatosEmpresa(ref empresa);

                    dato.ID = (int)row["pk_ID"];
                    dato.Colaborador = nuevo;
                    dato.Comentario = (string)row["Comentario"];
                    dato.Empresa = empresa;
                    dato.Tipo = (Tipo)row["TipoInconsistencia"];
                    dato.Estado = (Estado)row["Estado"];
                    dato.Fecha = (DateTime)row["Fecha_Registro"];
                    dato.Grupo = grupo.SeleccionarGrupo(ref cod);
                    dato.manifiesto = (string)row["Manifiesto"];
                    dato.Tula = (string)row["Tula_SITES"];
                    dato.TulaPl = (string)row["Tula_Archivo"];
                    dato.Origen = (Origen)row["Origen"];

                    incon.Add(dato);

                }
                //comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }
            return incon;
        }



        /// <summary>
        /// Actualiza las inconsistencias
        /// </summary>
        /// <param name="incon">Objeto InconsistenciaPlanilla con los datos de la inconsistencia</param>
        /// <param name="c">Objeto colaborador con los datos del colaborador de registro</param>
        public void actualizarInconsistencia(InconsistenciaPlanilla incon, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInconsistencia");

            _manejador.agregarParametro(comando, "@ID", incon.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tula", incon.Tula, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tulaPl", incon.TulaPl, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@manifiesto", incon.manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@fecha", incon.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", incon.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@comentario", incon.Comentario, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@origen", incon.Origen, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@tipo", incon.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                Mensaje.mostrarMensaje("MensajeActualizacionInconsistencias");
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorActualizacionInconsistencia");
                comando.Connection.Close();
            }
        }






        /// <summary>
        /// Actualiza las inconsistencias
        /// </summary>
        /// <param name="incon">Objeto InconsistenciaPlanilla con los datos de la inconsistencia</param>
        /// <param name="c">Objeto colaborador con los datos del colaborador de registro</param>
        public void actualizarInconsistenciaProcesamiento(InconsistenciaPlanilla incon, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInconsistenciaProcesamiento");

            _manejador.agregarParametro(comando, "@ID", incon.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tula", incon.Tula, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tulaPl", incon.TulaPl, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@manifiesto", incon.manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@fecha", incon.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", incon.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@comentario", incon.Comentario, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@origen", incon.Origen, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@tipo", incon.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                Mensaje.mostrarMensaje("MensajeActualizacionInconsistencias");
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorActualizacionInconsistencia");
                comando.Connection.Close();
            }
        }


        #endregion Métodos Públicos
    }
}
