//
//  @ Project : 
//  @ File Name : EmpresasTransporteDL.cs
//  @ Date : 10/06/2011
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
    /// Clase de la capa de datos que maneja las empresas de transporte.
    /// </summary>
    public class EmpresasTransporteDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static EmpresasTransporteDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static EmpresasTransporteDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EmpresasTransporteDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public EmpresasTransporteDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva empresa de transporte.
        /// </summary>
        /// <param name="e">Objeto EmpresaTransporte con los datos de la nueva empresa</param>
        public void agregarEmpresaTransporte(ref EmpresaTransporte e)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertEmpresaTransporte");

            _manejador.agregarParametro(comando, "@nombre", e.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@centrocostos", e.CentroCostos, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tarifa_regular", e.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_feriado", e.TarifaFeriados, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tope", e.Tope, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", e.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entreganiquel", e.EntregaNiquel, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@precio_pieza", e.PrecioUnitarioPieza, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@precio_mil_colones", e.PrecioUnitarioMilColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@precio_mil_dolares", e.PrecioUnitarioMilDolares, SqlDbType.Decimal);

            try
            {
                e.ID = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEmpresaTransporteRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una empresa de transporte.
        /// </summary>
        /// <param name="e">Objeto EmpresaTransporte con los datos de la empresa a actualizar</param>
        public void actualizarEmpresaTransporte(EmpresaTransporte e)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEmpresaTransporte");

            _manejador.agregarParametro(comando, "@nombre", e.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@centrocostos", e.CentroCostos, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tarifa_regular", e.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_feriado", e.TarifaFeriados, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tope", e.Tope, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", e.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@entreganiquel", e.EntregaNiquel, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@precio_pieza", e.PrecioUnitarioPieza, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@precio_mil_colones", e.PrecioUnitarioMilColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@precio_mil_dolares", e.PrecioUnitarioMilDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@empresa", e, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEmpresaTransporteActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una empresa de transporte.
        /// </summary>
        /// <param name="e">Objeto EmpresaTransporte con los datos de la empresa a eliminar</param>
        public void eliminarEmpresaTransporte(EmpresaTransporte e)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteEmpresaTransporte");

            _manejador.agregarParametro(comando, "@empresa", e, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEmpresaTransporteEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los encargados registrados.
        /// </summary>
        /// <param name="n">Parte del nombre del encargado para el cual se genera la lista</param>
        /// <returns>Lista de encargados registrados en el sistema</returns>
        public BindingList<EmpresaTransporte> listarEmpresasTransporte()
        {
            BindingList<EmpresaTransporte> empresas = new BindingList<EmpresaTransporte>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEmpresasTransporte");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    string centrocostos = "";
                    
                    if(datareader["CentroCostos"] != DBNull.Value)
                        centrocostos = (string)datareader["CentroCostos"];

                    decimal tarifaregular = 0;

                    if (datareader["TarifaRegular"] != DBNull.Value) 
                        tarifaregular = (decimal)datareader["TarifaRegular"];

                    decimal tarifaferiado = 0;
                    if (datareader["TarifaFeriado"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["TarifaFeriado"];

                    decimal tope = 0;
                    if (datareader["Tope"] != DBNull.Value) 
                        tope = (decimal)datareader["Tope"];

                    decimal recargo = 0;
                    if (datareader["Recargo"] != DBNull.Value) 
                         recargo = (decimal)datareader["Tope"];

                    decimal entreganiquel = 0;
                    if (datareader["EntregaNiquel"] != DBNull.Value)
                        entreganiquel = (decimal)datareader["EntregaNiquel"];



                    decimal precio_unitario = 0;
                    if (datareader["PrecioUnitarioMoneda"] != DBNull.Value)
                        precio_unitario = (decimal)datareader["PrecioUnitarioMoneda"];


                    decimal precio_mil_colones = 0;
                    if (datareader["PrecioMilColones"] != DBNull.Value)
                        precio_mil_colones = (decimal)datareader["PrecioMilColones"];



                    decimal precio_mil_dolares = 0;
                    if (datareader["PrecioMilDolares"] != DBNull.Value)
                        precio_mil_dolares = (decimal)datareader["PrecioMilDolares"];

                    EmpresaTransporte empresa = new EmpresaTransporte(nombre, id: id);

                    empresa.PrecioUnitarioMilColones = precio_mil_colones;
                    empresa.PrecioUnitarioMilDolares = precio_mil_dolares;
                    empresa.PrecioUnitarioPieza = precio_unitario;
 
                    empresas.Add(empresa);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return empresas;
        }



        /// <summary>
        /// Obtener los datos de una Empresa.
        /// </summary>
        /// <param name="e">Empresa para el cual se obtienen los datos</param>
        /// <returns>Objeto Empresa con los datos de la empresa</returns>
        public EmpresaTransporte obtenerDatosEmpresa(ref EmpresaTransporte e)
        {
        
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEmpresasTransporteDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@transportadora", e, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    byte id_empresa_encargada = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];


                    string centrocostos = "";

                    if (datareader["CentroCostos"] != DBNull.Value)
                        centrocostos = (string)datareader["CentroCostos"];

                    decimal tarifaregular = 0;

                    if (datareader["TarifaRegular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["TarifaRegular"];

                    decimal tarifaferiado = 0;
                    if (datareader["TarifaFeriado"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["TarifaFeriado"];

                    decimal tope = 0;
                    if (datareader["Tope"] != DBNull.Value)
                        tope = (decimal)datareader["Tope"];

                    decimal recargo = 0;
                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Tope"];

                    decimal entreganiquel = 0;
                    if (datareader["EntregaNiquel"] != DBNull.Value)
                        entreganiquel = (decimal)datareader["EntregaNiquel"];

                    EmpresaTransporte empresa = new EmpresaTransporte(nombre, id: id_empresa_encargada);
 
                    e = empresa;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return e;
        }


        public BindingList<EmpresaTransporte> listarEmpresasTransporteBanco()
        {
            BindingList<EmpresaTransporte> empresas = new BindingList<EmpresaTransporte>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEmpresasTransporteBanco");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    string centrocostos = "";

                    if (datareader["CentroCostos"] != DBNull.Value)
                        centrocostos = (string)datareader["CentroCostos"];

                    decimal tarifaregular = 0;

                    if (datareader["TarifaRegular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["TarifaRegular"];

                    decimal tarifaferiado = 0;
                    if (datareader["TarifaFeriado"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["TarifaFeriado"];

                    decimal tope = 0;
                    if (datareader["Tope"] != DBNull.Value)
                        tope = (decimal)datareader["Tope"];

                    decimal recargo = 0;
                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Tope"];

                    decimal entreganiquel = 0;
                    if (datareader["EntregaNiquel"] != DBNull.Value)
                        entreganiquel = (decimal)datareader["EntregaNiquel"];

                    EmpresaTransporte empresa = new EmpresaTransporte(nombre, id: id);

                    empresas.Add(empresa);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return empresas;
        }

        #endregion Métodos Públicos


        
    }

}
