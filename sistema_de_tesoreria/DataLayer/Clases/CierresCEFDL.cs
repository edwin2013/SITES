//
//  @ Project : 
//  @ File Name : CierresDL.cs
//  @ Date : 27/07/2011
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

    public class CierresCEFDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CierresCEFDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CierresCEFDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CierresCEFDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CierresCEFDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un cierre del CEF en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre</param>
        public void agregarCierre(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCierreCEFRespaldoErick");

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.VarChar);
            

            _manejador.agregarParametro(comando, "@cheques", c.Cheques, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@sobres", c.Sobres, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@disconformidades", c.Disconformidades, SqlDbType.SmallInt);

            _manejador.agregarParametro(comando, "@reporte_cajero_colones", c.Reporte_cajero_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_dia_anterior_colones", c.Saldo_dia_anterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_ingresos_colones", c.Otros_ingresos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_egresos_colones", c.Otros_egresos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_locales_colones", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_exterior_colones", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_bac_colones", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@salidas_niquel_colones", c.Salidas_niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_colones", c.Niquel_pendiente_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_dia_anterior_colones", c.Niquel_pendiente_dia_anterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_cliente_niquel_colones", c.Faltante_cliente_niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_cliente_niquel_colones", c.Sobrante_cliente_niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_boveda_colones", c.Entregas_boveda_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_pendiente_colones", c.Entregas_pendientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_quinientos_colones", c.Faltante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_quinientos_colones", c.Sobrante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@efectivo_cajero_colones", c.Efectivo_cajero_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_cierre_colones", c.Saldo_cierre_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@compra_dolares", c.Compra_dolares, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@reporte_cajero_dolares", c.Reporte_cajero_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_dia_anterior_dolares", c.Saldo_dia_anterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_ingresos_dolares", c.Otros_ingresos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_egresos_dolares", c.Otros_egresos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_locales_dolares", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_exterior_dolares", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_bac_dolares", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@salidas_niquel_dolares", c.Salidas_niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_dolares", c.Niquel_pendiente_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_dia_anterior_dolares", c.Niquel_pendiente_dia_anterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_cliente_niquel_dolares", c.Faltante_cliente_niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_cliente_niquel_dolares", c.Sobrante_cliente_niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_boveda_dolares", c.Entregas_boveda_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_pendiente_dolares", c.Entregas_pendientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_quinientos_dolares", c.Faltante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_quinientos_dolares", c.Sobrante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@efectivo_cajero_dolares", c.Efectivo_cajero_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_cierre_dolares", c.Saldo_cierre_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@venta_dolares", c.Venta_dolares, SqlDbType.Money);



            _manejador.agregarParametro(comando, "@reporte_cajero_euros", c.Reporte_cajero_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_dia_anterior_euros", c.Saldo_dia_anterior_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_ingresos_euros", c.Otros_ingresos_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_egresos_euros", c.Otros_egresos_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_locales_euros", c.Cheques_locales_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_exterior_euros", c.Cheques_exterior_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_bac_euros", c.Cheques_bac_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@salidas_niquel_euros", c.Salidas_niquel_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_euros", c.Niquel_pendiente_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_dia_anterior_euros", c.Niquel_pendiente_dia_anterior_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_cliente_niquel_euros", c.Faltante_cliente_niquel_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_cliente_niquel_euros", c.Sobrante_cliente_niquel_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_boveda_euros", c.Entregas_boveda_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_pendiente_euros", c.Entregas_pendientes_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_quinientos_euros", c.Faltante_quinientos_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_quinientos_euros", c.Sobrante_quinientos_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@efectivo_cajero_euros", c.Efectivo_cajero_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_cierre_euros", c.Saldo_cierre_euros, SqlDbType.Money);
 


            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre</param>
        public void actualizarCierre(CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCierreCEFRespaldoErick");

            _manejador.agregarParametro(comando, "@cheques", c.Cheques, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@sobres", c.Sobres, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@disconformidades", c.Disconformidades, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.VarChar);

            _manejador.agregarParametro(comando, "@reporte_cajero_colones", c.Reporte_cajero_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_dia_anterior_colones", c.Saldo_dia_anterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_ingresos_colones", c.Otros_ingresos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_egresos_colones", c.Otros_egresos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_locales_colones", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_exterior_colones", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_bac_colones", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@salidas_niquel_colones", c.Salidas_niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_colones", c.Niquel_pendiente_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_dia_anterior_colones", c.Niquel_pendiente_dia_anterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_cliente_niquel_colones", c.Faltante_cliente_niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_cliente_niquel_colones", c.Sobrante_cliente_niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_boveda_colones", c.Entregas_boveda_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_pendiente_colones", c.Entregas_pendientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_quinientos_colones", c.Faltante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_quinientos_colones", c.Sobrante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@efectivo_cajero_colones", c.Efectivo_cajero_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_cierre_colones", c.Saldo_cierre_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@compra_dolares", c.Compra_dolares, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@reporte_cajero_dolares", c.Reporte_cajero_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_dia_anterior_dolares", c.Saldo_dia_anterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_ingresos_dolares", c.Otros_ingresos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_egresos_dolares", c.Otros_egresos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_locales_dolares", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_exterior_dolares", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_bac_dolares", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@salidas_niquel_dolares", c.Salidas_niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_dolares", c.Niquel_pendiente_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_dia_anterior_dolares", c.Niquel_pendiente_dia_anterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_cliente_niquel_dolares", c.Faltante_cliente_niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_cliente_niquel_dolares", c.Sobrante_cliente_niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_boveda_dolares", c.Entregas_boveda_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_pendiente_dolares", c.Entregas_pendientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_quinientos_dolares", c.Faltante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_quinientos_dolares", c.Sobrante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@efectivo_cajero_dolares", c.Efectivo_cajero_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_cierre_dolares", c.Saldo_cierre_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@venta_dolares", c.Venta_dolares, SqlDbType.Money);




            _manejador.agregarParametro(comando, "@reporte_cajero_euros", c.Reporte_cajero_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_dia_anterior_euros", c.Saldo_dia_anterior_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_ingresos_euros", c.Otros_ingresos_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@otros_egresos_euros", c.Otros_egresos_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_locales_euros", c.Cheques_locales_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_exterior_euros", c.Cheques_exterior_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cheques_bac_euros", c.Cheques_bac_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@salidas_niquel_euros", c.Salidas_niquel_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_euros", c.Niquel_pendiente_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@niquel_pendiente_dia_anterior_euros", c.Niquel_pendiente_dia_anterior_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_cliente_niquel_euros", c.Faltante_cliente_niquel_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_cliente_niquel_euros", c.Sobrante_cliente_niquel_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_boveda_euros", c.Entregas_boveda_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@entregas_pendiente_euros", c.Entregas_pendientes_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@faltante_quinientos_euros", c.Faltante_quinientos_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@sobrante_quinientos_euros", c.Sobrante_quinientos_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@efectivo_cajero_euros", c.Efectivo_cajero_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@saldo_cierre_euros", c.Saldo_cierre_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreActualizacion");
            }

        }
        /// <summary>
        /// Eliminar los datos de un cierre del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre a eliminar</param>
        public void eliminarCierre(CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCierreCEF");

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreEliminacion");
            }

        }

        /// <summary>
        /// Obtener los datos de un determinado cierre para un cajero y un digitador, del CEF, en una determinada fecha.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre</param>
        public void obtenerDatosCierre(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEF2");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Observaciones = (string)datareader["Observaciones"];

                    c.Cheques = (short)datareader["Cheques"];
                    c.Disconformidades = (short)datareader["Disconformidades"];
                    c.Sobres = (short)datareader["Sobres"];

                    c.Reporte_cajero_colones = (decimal)datareader["Reporte_Cajero_Colones"];
                    c.Saldo_dia_anterior_colones = (decimal)datareader["Saldo_Dia_Anterior_Colones"];
                    c.Otros_ingresos_colones = (decimal)datareader["Otros_Ingresos_Colones"];
                    c.Otros_egresos_colones = (decimal)datareader["Otros_Egresos_Colones"];
                    c.Cheques_locales_colones = (decimal)datareader["Cheques_Locales_Colones"];
                    c.Cheques_exterior_colones = (decimal)datareader["Cheques_Exterior_Colones"];
                    c.Cheques_bac_colones = (decimal)datareader["Cheques_BAC_Colones"];
                    c.Salidas_niquel_colones = (decimal)datareader["Salidas_Niquel_Colones"];
                    c.Niquel_pendiente_colones = (decimal)datareader["Niquel_Pendiente_Colones"];
                    c.Niquel_pendiente_dia_anterior_colones = (decimal)datareader["Niquel_Pendiente_Dia_Anterior_Colones"];
                    c.Faltante_cliente_niquel_colones = (decimal)datareader["Faltante_Cliente_Niquel_Colones"];
                    c.Sobrante_cliente_niquel_colones = (decimal)datareader["Sobrante_Cliente_Niquel_Colones"];
                    c.Entregas_boveda_colones = (decimal)datareader["Entregas_Boveda_Colones"];
                    c.Entregas_pendientes_colones = (decimal)datareader["Entregas_Pendiente_Colones"];
                    c.Faltante_quinientos_colones = (decimal)datareader["Faltante_Quinientos_Colones"];
                    c.Sobrante_quinientos_colones = (decimal)datareader["Sobrante_Quinientos_Colones"];
                    c.Efectivo_cajero_colones = (decimal)datareader["Efectivo_Cajero_Colones"];
                    c.Saldo_cierre_colones = (decimal)datareader["Saldo_Cierre_Colones"];
                    c.Compra_dolares = (decimal)datareader["Compra_Dolares"];

                    c.Reporte_cajero_dolares = (decimal)datareader["Reporte_Cajero_Dolares"];
                    c.Saldo_dia_anterior_dolares = (decimal)datareader["Saldo_Dia_Anterior_Dolares"];
                    c.Otros_ingresos_dolares = (decimal)datareader["Otros_Ingresos_Dolares"];
                    c.Otros_egresos_dolares = (decimal)datareader["Otros_Egresos_Dolares"];
                    c.Cheques_locales_dolares = (decimal)datareader["Cheques_Locales_Dolares"];
                    c.Cheques_exterior_dolares = (decimal)datareader["Cheques_Exterior_Dolares"];
                    c.Cheques_bac_dolares = (decimal)datareader["Cheques_BAC_Dolares"];
                    c.Salidas_niquel_dolares = (decimal)datareader["Salidas_Niquel_Dolares"];
                    c.Niquel_pendiente_dolares = (decimal)datareader["Niquel_Pendiente_Dolares"];
                    c.Niquel_pendiente_dia_anterior_dolares = (decimal)datareader["Niquel_Pendiente_Dia_Anterior_Dolares"];
                    c.Faltante_cliente_niquel_dolares = (decimal)datareader["Faltante_Cliente_Niquel_Dolares"];
                    c.Sobrante_cliente_niquel_dolares = (decimal)datareader["Sobrante_Cliente_Niquel_Dolares"];
                    c.Entregas_boveda_dolares = (decimal)datareader["Entregas_Boveda_Dolares"];
                    c.Entregas_pendientes_dolares = (decimal)datareader["Entregas_Pendiente_Dolares"];
                    c.Faltante_quinientos_dolares = (decimal)datareader["Faltante_Quinientos_Dolares"];
                    c.Sobrante_quinientos_dolares = (decimal)datareader["Sobrante_Quinientos_Dolares"];
                    c.Efectivo_cajero_dolares = (decimal)datareader["Efectivo_Cajero_Dolares"];
                    c.Saldo_cierre_dolares = (decimal)datareader["Saldo_Cierre_Dolares"];
                    c.Venta_dolares = (decimal)datareader["Venta_Dolares"];

                    c.Reporte_cajero_euros =  (decimal)datareader["Reporte_Cajero_Euros"];
		            c.Saldo_dia_anterior_euros = (decimal)datareader["Saldo_Dia_Anterior_Euros"];
		            c.Otros_ingresos_euros =(decimal)datareader["Otros_Ingresos_Euros"];
		            c.Otros_egresos_euros = (decimal)datareader["Otros_Egresos_Euros"];
		            c.Cheques_locales_euros = (decimal)datareader["Cheques_Locales_Euros"];
		            c.Cheques_exterior_euros = (decimal)datareader["Cheques_Exterior_Euros"];
		            c.Cheques_bac_euros = (decimal)datareader["Cheques_BAC_Euros"];
		            c.Salidas_niquel_euros = (decimal)datareader["Salidas_Niquel_Euros"];
		            c.Niquel_pendiente_euros = (decimal)datareader["Niquel_Pendiente_Euros"];		
		            c.Entregas_boveda_euros = (decimal)datareader["Entregas_Boveda_Euros"];
                    c.Entregas_pendientes_euros = (decimal)datareader["Entregas_Pendiente_Euros"];
                    c.Efectivo_cajero_euros = (decimal)datareader["Efectivo_Cajero_Euros"];
                    c.Saldo_cierre_euros = (decimal)datareader["Saldo_Cierre_Euros"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador,
                                                              primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);

                    c.Coordinador = coordinador;
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
        /// Obtener los datos del total de manifiesto, montos y depositos del cierre de un cajero y un digitador del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen los datos</param>
        public void obtenerTotalesManifiestoCierre(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFTotalesManifiestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                datareader.Read();

                c.Ingreso_clientes_colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                c.Ingreso_clientes_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                c.Ingreso_clientes_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                c.Depositos = (short)datareader["Depositos"];
                c.Manifiestos = (short)datareader["Manifiestos"];

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener el total de tulas para del cierre de un cajero y un digitador del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen los datos</param>
        public void obtenerTotalesTulasCierre(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFTotalesTulas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                    c.Tulas = (short)datareader["Tulas"];

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener las inconsistencias ligadas al cierre de un cajero y un digitador del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen las inconsistencias</param>
        public BindingList<InconsistenciaDeposito> obtenerInconsistenciasCierre(CierreCEF c)
        {
            BindingList<InconsistenciaDeposito> inconsistencias = new BindingList<InconsistenciaDeposito>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFInconsistencias");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    decimal diferencia_colones = (decimal)datareader["Diferencia_Colones"];
                    decimal diferencia_dolares = (decimal)datareader["Diferencia_Dolares"];
                    decimal diferencia_euros = 0;

                    if (datareader["Diferencia_Euros"] != DBNull.Value)
                        diferencia_euros = (decimal)datareader["Diferencia_Euros"];
                    InconsistenciaDeposito inconsistencia =
                        new InconsistenciaDeposito(id, diferencia_colones, diferencia_dolares, diferencia_euros);

                    inconsistencias.Add(inconsistencia);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        /// <summary>
        /// Verificar si existe un cierre para un cajero y un digitador del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre a verificar</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public bool verificarCierre(ref CierreCEF c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteCierreCEF");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != c.ID;

                    c.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarCierreDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los cierres registrados en determinada fecha en el área de CEF.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cierres registrados en la fecha dada</returns>
        public BindingList<CierreCEF> listarCierres(DateTime f)
        {
            BindingList<CierreCEF> cierres = new BindingList<CierreCEF>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresCEF");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero,
                                                         primer_apellido_cajero,
                                                         segundo_apellido_cajero);
                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador,
                                                            primer_apellido_digitador,
                                                            segundo_apellido_digitador);
                    CierreCEF cierre = new CierreCEF(fecha: f, cajero: cajero, digitador: digitador);

                    cierres.Add(cierre);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cierres;
        }

        /// <summary>
        /// Obtener una lista de los cajeros con un cierre registrado por un coordinador del CEF.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <returns>Lista de cajeros con un cierre registrado en la fecha dada por el coordinador</returns>
        public BindingList<CierreCEF> listarCierresCajerosCoordinador(DateTime f, Colaborador c)
        {
            BindingList<CierreCEF> cierres = new BindingList<CierreCEF>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresCEFCajerosCoordinador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];
                    int id_cierre = (int)datareader["ID_Cierre"];

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero,
                                                         primer_apellido_cajero,
                                                         segundo_apellido_cajero);

                    CierreCEF cierre = new CierreCEF(id:id_cierre,fecha:f, cajero: cajero, coordinador: c);

                    cierres.Add(cierre);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cierres;
        }

        /// <summary>
        /// Obtener los datos de un determinado cierre para un cajero  del CEF en una determinada fecha.
        /// </summary>
        /// <param name="c">Objeto Cierre con los datos del cierre</param>
        public void obtenerDatosCierreCajero(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFCajero");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Cheques = (short)datareader["Cheques"];
                    c.Disconformidades = (short)datareader["Disconformidades"];
                    c.Sobres = (short)datareader["Sobres"];

                    c.Reporte_cajero_colones = (decimal)datareader["Reporte_Cajero_Colones"];
                    c.Saldo_dia_anterior_colones = (decimal)datareader["Saldo_Dia_Anterior_Colones"];
                    c.Otros_ingresos_colones = (decimal)datareader["Otros_Ingresos_Colones"];
                    c.Otros_egresos_colones = (decimal)datareader["Otros_Egresos_Colones"];
                    c.Cheques_locales_colones = (decimal)datareader["Cheques_Locales_Colones"];
                    c.Cheques_exterior_colones = (decimal)datareader["Cheques_Exterior_Colones"];
                    c.Cheques_bac_colones = (decimal)datareader["Cheques_BAC_Colones"];
                    c.Salidas_niquel_colones = (decimal)datareader["Salidas_Niquel_Colones"];
                    c.Niquel_pendiente_colones = (decimal)datareader["Niquel_Pendiente_Colones"];
                    c.Entregas_boveda_colones = (decimal)datareader["Entregas_Boveda_Colones"];
                    c.Entregas_pendientes_colones = (decimal)datareader["Entregas_Pendiente_Colones"];
                    c.Faltante_quinientos_colones = (decimal)datareader["Faltante_Quinientos_Colones"];
                    c.Sobrante_quinientos_colones = (decimal)datareader["Sobrante_Quinientos_Colones"];
                    c.Efectivo_cajero_colones = (decimal)datareader["Efectivo_Cajero_Colones"];
                    c.Saldo_cierre_colones = (decimal)datareader["Saldo_Cierre_Colones"];
                    c.Compra_dolares = (decimal)datareader["Compra_Dolares"];

                    c.Reporte_cajero_dolares = (decimal)datareader["Reporte_Cajero_Dolares"];
                    c.Saldo_dia_anterior_dolares = (decimal)datareader["Saldo_Dia_Anterior_Dolares"];
                    c.Otros_ingresos_dolares = (decimal)datareader["Otros_Ingresos_Dolares"];
                    c.Otros_egresos_dolares = (decimal)datareader["Otros_Egresos_Dolares"];
                    c.Cheques_locales_dolares = (decimal)datareader["Cheques_Locales_Dolares"];
                    c.Cheques_exterior_dolares = (decimal)datareader["Cheques_Exterior_Dolares"];
                    c.Cheques_bac_dolares = (decimal)datareader["Cheques_BAC_Dolares"];
                    c.Salidas_niquel_dolares = (decimal)datareader["Salidas_Niquel_Dolares"];
                    c.Niquel_pendiente_dolares = (decimal)datareader["Niquel_Pendiente_Dolares"];
                    c.Entregas_boveda_dolares = (decimal)datareader["Entregas_Boveda_Dolares"];
                    c.Entregas_pendientes_dolares = (decimal)datareader["Entregas_Pendiente_Dolares"];
                    c.Faltante_quinientos_dolares = (decimal)datareader["Faltante_Quinientos_Dolares"];
                    c.Sobrante_quinientos_dolares = (decimal)datareader["Sobrante_Quinientos_Dolares"];
                    c.Efectivo_cajero_dolares = (decimal)datareader["Efectivo_Cajero_Dolares"];
                    c.Saldo_cierre_dolares = (decimal)datareader["Saldo_Cierre_Dolares"];
                    c.Venta_dolares = (decimal)datareader["Venta_Dolares"];
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
        /// Obtener los datos del total de manifiesto, montos y depositos del cierre de un cajero del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen los datos</param>
        public void obtenerTotalesManifiestoCierreCajero(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFCajeroTotalesManifiestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                datareader.Read();

                c.Ingreso_clientes_colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                c.Ingreso_clientes_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                c.Depositos = (short)datareader["Depositos"];
                c.Manifiestos = (short)datareader["Manifiestos"];

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener el total de tulas para del cierre de un cajero del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen los datos</param>
        public void obtenerTotalesTulasCierreCajero(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFCajeroTotalesTulas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                    c.Tulas = (short)datareader["Tulas"];

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener las inconsistencias ligadas a un cierre de un cajero del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen las inconsistencias</param>
        public BindingList<InconsistenciaDeposito> obtenerInconsistenciasCierreCajero(CierreCEF c)
        {
            BindingList<InconsistenciaDeposito> inconsistencias = new BindingList<InconsistenciaDeposito>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFCajeroInconsistencias");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    decimal diferencia_colones = (decimal)datareader["Diferencia_Colones"];
                    decimal diferencia_dolares = (decimal)datareader["Diferencia_Dolares"];
                    decimal diferencia_euros = 0;

                    if (datareader["Diferencia_Euros"] != DBNull.Value)
                        diferencia_euros = (decimal)datareader["Diferencia_Euros"];

                    InconsistenciaDeposito inconsistencia =
                        new InconsistenciaDeposito(id, diferencia_colones, diferencia_dolares, diferencia_euros);

                    inconsistencias.Add(inconsistencia);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        /// <summary>
        /// Obtener una lista de los digitadores con un cierre registrado por un coordinador del CEF.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <returns>Lista de digitadores con un cierre  registrado en la fecha dada por el coordinador</returns>
        public BindingList<CierreCEF> listarCierresDigitadoresCoordinador(DateTime f, Colaborador c)
        {
            BindingList<CierreCEF> cierres = new BindingList<CierreCEF>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresCEFDigitadoresCoordinador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador,
                                                            primer_apellido_digitador,
                                                            segundo_apellido_digitador);

                    CierreCEF cierre = new CierreCEF(fecha: f, digitador: digitador, coordinador: c);

                    cierres.Add(cierre);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cierres;
        }

        /// <summary>
        /// Obtener los datos de un determinado cierre para un digitador  del CEF en una determinada fecha.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre</param>
        public void obtenerDatosCierreDigitador(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFDigitador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Cheques = (short)datareader["Cheques"];
                    c.Disconformidades = (short)datareader["Disconformidades"];
                    c.Sobres = (short)datareader["Sobres"];

                    c.Reporte_cajero_colones = (decimal)datareader["Reporte_Cajero_Colones"];
                    c.Saldo_dia_anterior_colones = (decimal)datareader["Saldo_Dia_Anterior_Colones"];
                    c.Otros_ingresos_colones = (decimal)datareader["Otros_Ingresos_Colones"];
                    c.Otros_egresos_colones = (decimal)datareader["Otros_Egresos_Colones"];
                    c.Cheques_locales_colones = (decimal)datareader["Cheques_Locales_Colones"];
                    c.Cheques_exterior_colones = (decimal)datareader["Cheques_Exterior_Colones"];
                    c.Cheques_bac_colones = (decimal)datareader["Cheques_BAC_Colones"];
                    c.Salidas_niquel_colones = (decimal)datareader["Salidas_Niquel_Colones"];
                    c.Niquel_pendiente_colones = (decimal)datareader["Niquel_Pendiente_Colones"];
                    c.Entregas_boveda_colones = (decimal)datareader["Entregas_Boveda_Colones"];
                    c.Entregas_pendientes_colones = (decimal)datareader["Entregas_Pendiente_Colones"];
                    c.Faltante_quinientos_colones = (decimal)datareader["Faltante_Quinientos_Colones"];
                    c.Sobrante_quinientos_colones = (decimal)datareader["Sobrante_Quinientos_Colones"];
                    c.Efectivo_cajero_colones = (decimal)datareader["Efectivo_Cajero_Colones"];
                    c.Saldo_cierre_colones = (decimal)datareader["Saldo_Cierre_Colones"];
                    c.Compra_dolares = (decimal)datareader["Compra_Dolares"];

                    c.Reporte_cajero_dolares = (decimal)datareader["Reporte_Cajero_Dolares"];
                    c.Saldo_dia_anterior_dolares = (decimal)datareader["Saldo_Dia_Anterior_Dolares"];
                    c.Otros_ingresos_dolares = (decimal)datareader["Otros_Ingresos_Dolares"];
                    c.Otros_egresos_dolares = (decimal)datareader["Otros_Egresos_Dolares"];
                    c.Cheques_locales_dolares = (decimal)datareader["Cheques_Locales_Dolares"];
                    c.Cheques_exterior_dolares = (decimal)datareader["Cheques_Exterior_Dolares"];
                    c.Cheques_bac_dolares = (decimal)datareader["Cheques_BAC_Dolares"];
                    c.Salidas_niquel_dolares = (decimal)datareader["Salidas_Niquel_Dolares"];
                    c.Niquel_pendiente_dolares = (decimal)datareader["Niquel_Pendiente_Dolares"];
                    c.Entregas_boveda_dolares = (decimal)datareader["Entregas_Boveda_Dolares"];
                    c.Entregas_pendientes_dolares = (decimal)datareader["Entregas_Pendiente_Dolares"];
                    c.Faltante_quinientos_dolares = (decimal)datareader["Faltante_Quinientos_Dolares"];
                    c.Sobrante_quinientos_dolares = (decimal)datareader["Sobrante_Quinientos_Dolares"];
                    c.Efectivo_cajero_dolares = (decimal)datareader["Efectivo_Cajero_Dolares"];
                    c.Saldo_cierre_dolares = (decimal)datareader["Saldo_Cierre_Dolares"];
                    c.Venta_dolares = (decimal)datareader["Venta_Dolares"];
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
        /// Obtener los datos del total de manifiesto, montos y depositos del cierre de un digitador del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen los datos</param>
        public void obtenerTotalesManifiestoCierreDigitador(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFDigitadorTotalesManifiestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                datareader.Read();

                c.Ingreso_clientes_colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                c.Ingreso_clientes_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                c.Depositos = (short)datareader["Depositos"];
                c.Manifiestos = (short)datareader["Manifiestos"];

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener el total de tulas para del cierre de un digitador del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen los datos</param>
        public void obtenerTotalesTulasCierreDigitador(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFDigitadorTotalesTulas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                    c.Tulas = (short)datareader["Tulas"];

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener las inconsistencias ligadas a un cierre de un digitador del CEF.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre para el cual se obtienen las inconsistencias</param>
        public BindingList<InconsistenciaDeposito> obtenerInconsistenciasCierreDigitador(CierreCEF c)
        {
            BindingList<InconsistenciaDeposito> inconsistencias = new BindingList<InconsistenciaDeposito>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFDigitadorInconsistencias");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    decimal diferencia_colones = (decimal)datareader["Diferencia_Colones"];
                    decimal diferencia_dolares = (decimal)datareader["Diferencia_Dolares"];
                    decimal diferencia_euros = 0;

                    if (datareader["Diferencia_Euros"] != DBNull.Value)
                        diferencia_euros = (decimal)datareader["Diferencia_Euros"];

                    InconsistenciaDeposito inconsistencia =
                        new InconsistenciaDeposito(id, diferencia_colones, diferencia_dolares, diferencia_euros);

                    inconsistencias.Add(inconsistencia);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        /// <summary>
        /// Obtener los manifiestos actualizados por un coordinador del CEF.
        /// </summary>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de manifiestos del coordinador</returns>
        public DataTable listarManifiestosCoordinador(Colaborador c, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFManifiestosCoordinador");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        /// <summary>
        /// Obtener los manifiestos tramitados por un digitador del CEF.
        /// </summary>
        /// <param name="d">Digitador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de manifiestos del digitador</returns>
        public DataTable listarManifiestosDigitador(Colaborador d, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFManifiestosDigitador");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", d, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de un coordinador del CEF.
        /// </summary>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesCoordinadorCierre(Colaborador c, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFMontosClientesCoordinador");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }



        /// <summary>
        /// Obtener los montos por cliente para el cierre de un supervisor del CEF.
        /// </summary>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesSupervisorCierre(DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFMontosSupervisorCierre");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

    
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        /// <summary>
        /// Obtener los montos por cliente procesados por un cajero para un coordinador del CEF dado.
        /// </summary>
        /// <param name="c">Cajero para el cual se genera la lista</param>
        /// /// <param name="co">Coordinador que genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesCajeroCoordinadorCierre(Colaborador c, Colaborador co, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFMontosClientesCajeroCoordinador");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", co, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }


        /// <summary>
        /// Obtener los montos por cliente procesados por un cajero para un coordinador del CEF dado.
        /// </summary>
        /// <param name="c">Cajero para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesCajeroSupervisorCierre(Colaborador c,DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFMontosClientesCajeroSupervisor");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        /// <summary>
        /// Obtener los montos por cliente tramitados por un digitador para un coordinador del CEF dado.
        /// </summary>
        /// <param name="d">Digitador para el cual se genera la lista</param>
        /// <param name="co">Coordinador que genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesDigitadorCoordinadorCierre(Colaborador d, Colaborador co, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFMontosClientesDigitadorCoordinador");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", co, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", d, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }


        /// <summary>
        /// Obtener los montos por cliente tramitados por un digitador para un coordinador del CEF dado.
        /// </summary>
        /// <param name="d">Digitador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesDigitadorSupervisorCierre(Colaborador d, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFMontosClientesDigitadorSupervisor");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;


            _manejador.agregarParametro(comando, "@digitador", d, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de un digitador del CEF.
        /// </summary>
        /// <param name="d">Digitador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesDigitadorCierre(Colaborador d, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreCEFMontosClientesDigitador");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", d, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }



        /// <summary>
        /// Obtener los datos de un determinado cierre para un cajero  del CEF en una determinada fecha.
        /// </summary>
        /// <param name="c">Objeto Cierre con los datos del cierre</param>
        public void obtenerDatoDigitador(ref CierreCEF c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresCEFDigitadoresCoordinadorCierre");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@Identificacion", c.ID, SqlDbType.Int);
            c.Digitador = new Colaborador();


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {


                    c.Digitador.ID = (int)datareader["ID_Digitador"];
                    c.Digitador.Nombre = (string)datareader["Nombre_Digitador"];
                    c.Digitador.Primer_apellido = (string)datareader["Primer_Apellido_Digitador"];
                    c.Digitador.Segundo_apellido = (string)datareader["Segundo_Apellido_Digitador"];
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
