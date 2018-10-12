using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using CommonObjects.Clases;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects;

namespace DataLayer.Clases
{
    public class RequerimientoMantenimientoDL: ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RequerimientoMantenimientoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RequerimientoMantenimientoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RequerimientoMantenimientoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RequerimientoMantenimientoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void agregarRequerimientoMantenimiento(ref RequerimientoMantenimiento d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRequerimientoMantenimiento");

            _manejador.agregarParametro(comando, "@Fk_ID_Colaborador", d.Solicitante, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Fk_ID_Equipo", d.Equipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@FechaSolicitud", d.FechaSolicitud, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@Area", d.Area, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Mantenimiento", d.Mantenimiento, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@DescripcionSolicitud", d.DescripcionSolicitud, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@Evaluacion", d.Evaluacion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@FechaProveedor", d.FechaProveedor, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@FechaServicio", d.FechaServicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@DescripcionServicio", d.DescripcionServicio, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@NumeroSAP", d.SAP, SqlDbType.NVarChar);


            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoRegistro");
            }

        }

        public void actualizarRequerimientoMantenimiento(RequerimientoMantenimiento d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRequerimientoMantenimiento");

            _manejador.agregarParametro(comando, "@Fk_ID_Colaborador", d.Solicitante, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Fk_ID_Equipo", d.Equipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@FechaSolicitud", d.FechaSolicitud, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@Area", d.Area, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Mantenimiento", d.Mantenimiento, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@DescripcionSolicitud", d.DescripcionSolicitud, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@Evaluacion", d.Evaluacion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@FechaProveedor", d.FechaProveedor, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@FechaServicio", d.FechaServicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@DescripcionServicio", d.DescripcionServicio, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@NumeroSAP", d.SAP, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@requerimiento", d, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", d.Estado, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoActualizacion");
            }

        }

        public void eliminarRequerimientoMantenimiento(RequerimientoMantenimiento d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRequerimientoMantenimiento");

            _manejador.agregarParametro(comando, "@requerimiento", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoEliminacion");
            }

        }

        public bool verificarRequerimientoMantenimiento(RequerimientoMantenimiento d)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteRequerimientoMantenimiento");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@requerimiento", d, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != d.ID;

                    d.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarEquipo");
            }

            return existe;
        }

        public BindingList<RequerimientoMantenimiento> listarRequerimientosMantenimiento(RequerimientoMantenimiento r, DateTime? inicio=null, DateTime? fin=null)
        {
            BindingList<RequerimientoMantenimiento> requerimientos = new BindingList<RequerimientoMantenimiento>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRequerimientoMantenimiento");
            SqlDataReader datareader = null;

            if (inicio != null)
            {
                _manejador.agregarParametro(comando, "@inicio", inicio, SqlDbType.DateTime);
                _manejador.agregarParametro(comando, "@fin", fin, SqlDbType.DateTime);
            }

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    Colaborador solicitante = new Colaborador();
                    if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    {
                        solicitante.ID = (int)datareader["fk_ID_Colaborador"];
                        solicitante.Nombre = (string)datareader["NombreColaborador"];
                    }
                    DateTime fechasolicitud =  (DateTime)datareader["FechaSolicitud"];
                    Areas area = (Areas)((int)datareader["Area"]);
                    TipoMantenimiento mantenimiento = (TipoMantenimiento)((int)datareader["Mantenimiento"]);
                    string descripcionsolicitud = (string)datareader["DescripcionSolicitud"];                    
                    Evaluacion evaluacion = (Evaluacion)((int)datareader["Evaluacion"]);

                    EstadoRequerimiento estado = EstadoRequerimiento.Solicitado;
                    if (datareader["Estado"] != DBNull.Value)
                    {
                        estado = (EstadoRequerimiento)((int)datareader["Estado"]);
                    }
                    DateTime fechaproveedor = (DateTime)datareader["FechaProveedor"];
                    DateTime fechaservicio = (DateTime)datareader["FechaServicio"];
                    string descripcionservicio = (string)datareader["DescripcionServicio"];
                    string sap = (string)datareader["NumeroSAP"];
                    
                    EquipoTesoreria equipo = new EquipoTesoreria();

                    if (datareader["fk_ID_Equipo"] != DBNull.Value)
                    {
                        equipo.ID = (int)datareader["fk_ID_Equipo"];
                        equipo.Nombre = (string)datareader["NombreEquipo"];

                        ProveedorEquipo prov = new ProveedorEquipo();
                        prov.ID = (int)datareader["ID_Proveedor"];
                        prov.Nombre = (string)datareader["NombreProveedor"];

                        equipo.Serie = (string)datareader["Serie"];
                        equipo.NumActivo = (string)datareader["NumActivo"];

                        equipo.Proveedor = prov;
                    }

                    RequerimientoMantenimiento req = new RequerimientoMantenimiento(id:id,equipo:equipo, solicitante:solicitante,fechasolicitud:fechasolicitud,
                        area:area, mantenimiento:mantenimiento, descripcionsolicitud:descripcionsolicitud, evaluacion:evaluacion,
                        fechaproveedor:fechaproveedor, fechaservicio:fechaservicio, descripcionservicio:descripcionservicio, sap:sap, estado:estado);

                    requerimientos.Add(req);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return requerimientos;
        }

        #endregion Métodos Públicos
    }
}
