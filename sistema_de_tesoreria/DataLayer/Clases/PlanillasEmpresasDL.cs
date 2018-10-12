//
//  @ Project : 
//  @ File Name : PlanillasEmpresasDL.cs
//  @ Date : 17/12/2013
//  @ Author : Yolanda Mora 
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
    public class PlanillasEmpresasDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PlanillasEmpresasDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PlanillasEmpresasDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PlanillasEmpresasDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PlanillasEmpresasDL() { }

        #endregion Constructor


        #region Métodos Públicos

        /// <summary>
        /// Registrar una planilla.
        /// </summary>
        /// <param name="s">Objeto planilla con los datos de la planilla</param>
        
        public byte verificarPlanilla(ref Planilla s)
        {
            byte existe = 0;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistePlanilla");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tula", s.Tula, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@manifiesto", s.manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", s.Empresa, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    byte id = (byte)datareader["fk_ID_Grupo"];
                    //short numero = (short)datareader["Numero"];

                    //existe = numero != s.Codigo;
                    existe = id;

                    //s.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                //throw new Excepcion("ErrorVerificarSucursalDuplicada");
            }

            return existe;
        }



        /// <summary>
        /// Registrar una planilla.
        /// </summary>
        /// <param name="s">Objeto planilla con los datos de la planilla</param>

        public int verificarPlanillaProcesamiento(ref Planilla s)
        {
            int existe = 0;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistePlanillaProcesamiento");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", s.manifiesto, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", s.Empresa, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    //string numero = (string)datareader["Codigo"];

                    //existe = numero != s.Codigo;
                    existe = id;

                   

                   
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                //throw new Excepcion("ErrorVerificarSucursalDuplicada");
            }

            return existe;
        }
        public void agregarPlanillaEmpresa(ref Planilla s, ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPlanilla");

            _manejador.agregarParametro(comando, "@tula", s.Tula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", s.manifiesto, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", s.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_tula", s.MontoTula, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_planilla", s.MontoPlanilla, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@ID_PDV", s.IDPuntoVenta, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@PDV", s.PuntoAtencion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tarifa", s.Tarifa, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", s.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@total", s.Total, SqlDbType.Decimal);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                //throw new Excepcion("ErrorSucursalRegistro");
            }

        }




        public void agregarPlanillaEmpresaProcesadas(ref Planilla s, ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPlanillaProcesamiento");

            _manejador.agregarParametro(comando, "@tula", s.Tula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", s.manifiesto, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@transportadora", s.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_tula", s.MontoTula, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_planilla", s.MontoPlanilla, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@ID_PDV", s.IDPuntoVenta, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@PDV", s.PuntoAtencion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tarifa", s.Tarifa, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", s.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@total", s.Total, SqlDbType.Decimal);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                //throw new Excepcion("ErrorSucursalRegistro");
            }

        }
        public Grupo SeleccionarGrupo(ref int s)
        {
            Grupo g = new Grupo();
            string existe = "";

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGrupoID");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@ID", s, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    //g = datareader.Read();
                    g.Id = (byte)datareader["pk_ID"];
                    g.Nombre = (string)datareader["Nombre"];
                    g.Numero_cajas = (byte)datareader["Numero_Cajas"];
                    g.Total_manifiestos = (short)datareader["Total_manifiestos"];
                    g.Descripcion = (string)datareader["Descripcion"];
                    g.Caja_actual = (byte)datareader["Caja_Actual"];
                    g.Caja_unica = (bool)datareader["Caja_Unica"];
                    g.Area = (short)Areas.CentroEfectivo;
                    
                    //short numero = (short)datareader["Numero"];

                    //existe = numero != s.Codigo;
                    //existe = nombre;

                    //s.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                //throw new Excepcion("ErrorVerificarSucursalDuplicada");
            }

            return g;
        }
        public void Actualizar(ref Planilla s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePlanillas");
            SqlDataReader datareader = null;
         
            _manejador.agregarParametro(comando, "@ID", s.Grupo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@empresa", s.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@Codigo", s.manifiesto, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                //if (datareader.Read())
                //{
                //    string nombre = (string)datareader["Nombre"];
                //    //short numero = (short)datareader["Numero"];

                //    //existe = numero != s.Codigo;
                //    existe = nombre;

                //    //s.ID = id;
                //}

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                //throw new Excepcion("ErrorVerificarSucursalDuplicada");
            }
        }


        /// <summary>
        /// Lista los datos de la compracion
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        //public DataTable listarDatos(DateTime fecha)
        //{
        //    try
        //    {
        //        return this.obtenerDatosConsulta(i, f, a, r, null);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Excepcion("ErrorGeneracionReporte");
        //    }
        //}

        //private DataTable obtenerDatosConsulta(DateTime i)
        //{
        //    DataTable salida = new DataTable();
        //    SqlDataReader datareader = null;
        //    SqlCommand comando = _manejador.obtenerProcedimiento("SelectCompracin");

        //    _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);

        //    //Ejecutar la consulta

        //    try
        //    {
        //        datareader = _manejador.ejecutarConsultaDatos(comando);
        //        salida.Load(datareader);
        //        comando.Connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        comando.Connection.Close();
        //        throw ex;
        //    }

        //    return salida;
        //}
        #endregion Métodos Públicos
    }
}
