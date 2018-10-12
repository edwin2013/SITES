using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using CommonObjects;
using System.Data.SqlClient;
using CommonObjects.Clases;
using System.Data;
using System.ComponentModel;

namespace DataLayer.Clases
{
    public class CierreCajeroPROA_DL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CierreCajeroPROA_DL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CierreCajeroPROA_DL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CierreCajeroPROA_DL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CierreCajeroPROA_DL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un cierre de Niquel para PROA del CEF en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCajeroPROA con los datos del cierre</param>
        public void agregarCierreNiquel(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProaCierreCajeroNiquel");

            _manejador.agregarParametro(comando, "@fk_ID_Cajero", c.Cajero.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@Manifiestos_Procesados", c.Manifiestos, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@Corte_EfectivoCOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_EfectivoDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_EfectivoEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesCOL", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesDOL", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesEUR", c.Cheques_locales_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACCOL", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACDOL", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACEUR", c.Cheques_bac_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorCOL", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorDOL", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorEUR", c.Cheques_exterior_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_Clientes_DirectosCOL", c.Total_clientes_Directos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Clientes_DirectosDOL", c.Total_clientes_Directos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Clientes_DirectosEUR", c.Total_clientes_Directos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Niquel_ColaCajerosCOL", c.Niquel_cola_Cajeros_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_ColaCajerosDOL", c.Niquel_cola_Cajeros_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_ColaCajerosEUR", c.Niquel_cola_Cajeros_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Niquel_EntregaCajerosCOL", c.Niquel_entrega_Cajeros_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_EntregaCajerosDOL", c.Niquel_entrega_Cajeros_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_EntregaCajerosEUR", c.Niquel_entrega_Cajeros_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Niquel_ProcesamientoCajerosCOL", c.Niquel_procesamiento_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_ProcesamientoCajerosDOL", c.Niquel_procesamiento_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_ProcesamientoCajerosEUR", c.Niquel_procesamiento_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Niquel_EnMesaCajerosCOL", c.Niquel_enmesa_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_EnMesaCajerosDOL", c.Niquel_enmesa_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_EnMesaCajerosEUR", c.Niquel_enmesa_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_EntregasNiquelCOL", c.Total_Entregas_Niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregasNiquelDOL", c.Total_Entregas_Niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregasNiquelEUR", c.Total_Entregas_Niquel_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_NiquelCajerosCOL", c.Niquel_Total_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_NiquelCajerosDOL", c.Niquel_Total_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_NiquelCajerosEUR", c.Niquel_Total_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_EntregaBilleteCOL", c.Total_Entregas_billetes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregaBilleteDOL", c.Total_Entregas_billetes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregaBilleteEUR", c.Total_Entregas_billetes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesLocalesCOL", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesLocalesDOL", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesLocalesEUR", c.Cheques_locales_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesExteriorCOL", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesExteriorDOL", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesExteriorEUR", c.Cheques_exterior_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesBACCOL", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesBACDOL", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesBACEUR", c.Cheques_bac_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@FaltantesClientesCOL", c.Faltante_clientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@FaltantesClientesDOL", c.Faltante_clientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@FaltantesClientesEUR", c.Faltante_clientes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SobrantesClientesCOL", c.Sobrante_clientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SobrantesClientesDOL", c.Sobrante_clientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SobrantesClientesEUR", c.Sobrante_clientes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Faltantes500ClientesCOL", c.Faltante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltantes500ClientesDOL", c.Faltante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltantes500ClientesEUR", c.Faltante_quinientos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Sobrantes500ClientesCOL", c.Sobrante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrantes500ClientesDOL", c.Sobrante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrantes500ClientesEUR", c.Sobrante_quinientos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SaldoFinalCOL", c.Saldo_final_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoFinalDOL", c.Saldo_final_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoFinalEUR", c.Saldo_final_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SaldoInicialCOL", c.Saldo_inicial_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoInicialDOL", c.Saldo_inicial_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoInicialEUR", c.Saldo_inicial_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@ComprasDolaresCOL", c.Compra_dolares_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasDolaresDOL", c.Compra_dolares_dol, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasDolaresEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@VentasDolaresCOL", c.Venta_dolares_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasDolaresDOL", c.Venta_dolares_dol, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasDolaresEUR", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@fk_ID_Digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Comentarios", c.Comentarios, SqlDbType.VarChar);

            _manejador.agregarParametro(comando, "@Depositos", c.Depositos, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Tulas", c.Tulas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cheques", c.Cheques, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@ComprasEurosCOL", c.Compra_euros_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasEurosDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasEurosEUR", c.Compra_euros_eur, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@VentasEurosCOL", c.Venta_euros_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasEurosDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasEurosEUR", c.Venta_euros_eur, SqlDbType.Money);

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


        public void agregarCierreNiquel2(ref CierreCajeroPROA c, int idcoordinador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProaCierreCajeroNiquel2");
            
            _manejador.agregarParametro(comando, "@Manifiestos_Procesados", c.Manifiestos, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@Corte_EfectivoCOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_EfectivoDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_EfectivoEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesCOL", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesDOL", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesEUR", c.Cheques_locales_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACCOL", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACDOL", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACEUR", c.Cheques_bac_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorCOL", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorDOL", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorEUR", c.Cheques_exterior_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_Clientes_DirectosCOL", c.Total_clientes_Directos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Clientes_DirectosDOL", c.Total_clientes_Directos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Clientes_DirectosEUR", c.Total_clientes_Directos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Niquel_ColaCajerosCOL", c.Niquel_cola_Cajeros_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_ColaCajerosDOL", c.Niquel_cola_Cajeros_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_ColaCajerosEUR", c.Niquel_cola_Cajeros_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Niquel_EntregaCajerosCOL", c.Niquel_entrega_Cajeros_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_EntregaCajerosDOL", c.Niquel_entrega_Cajeros_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_EntregaCajerosEUR", c.Niquel_entrega_Cajeros_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Niquel_ProcesamientoCajerosCOL", c.Niquel_procesamiento_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_ProcesamientoCajerosDOL", c.Niquel_procesamiento_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_ProcesamientoCajerosEUR", c.Niquel_procesamiento_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Niquel_EnMesaCajerosCOL", c.Niquel_enmesa_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_EnMesaCajerosDOL", c.Niquel_enmesa_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Niquel_EnMesaCajerosEUR", c.Niquel_enmesa_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_EntregasNiquelCOL", c.Total_Entregas_Niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregasNiquelDOL", c.Total_Entregas_Niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregasNiquelEUR", c.Total_Entregas_Niquel_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_NiquelCajerosCOL", c.Niquel_Total_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_NiquelCajerosDOL", c.Niquel_Total_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_NiquelCajerosEUR", c.Niquel_Total_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_EntregaBilleteCOL", c.Total_Entregas_billetes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregaBilleteDOL", c.Total_Entregas_billetes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregaBilleteEUR", c.Total_Entregas_billetes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesLocalesCOL", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesLocalesDOL", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesLocalesEUR", c.Cheques_locales_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesExteriorCOL", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesExteriorDOL", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesExteriorEUR", c.Cheques_exterior_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesBACCOL", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesBACDOL", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesBACEUR", c.Cheques_bac_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@FaltantesClientesCOL", c.Faltante_clientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@FaltantesClientesDOL", c.Faltante_clientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@FaltantesClientesEUR", c.Faltante_clientes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SobrantesClientesCOL", c.Sobrante_clientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SobrantesClientesDOL", c.Sobrante_clientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SobrantesClientesEUR", c.Sobrante_clientes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Faltantes500ClientesCOL", c.Faltante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltantes500ClientesDOL", c.Faltante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltantes500ClientesEUR", c.Faltante_quinientos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Sobrantes500ClientesCOL", c.Sobrante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrantes500ClientesDOL", c.Sobrante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrantes500ClientesEUR", c.Sobrante_quinientos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SaldoFinalCOL", c.Saldo_final_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoFinalDOL", c.Saldo_final_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoFinalEUR", c.Saldo_final_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SaldoInicialCOL", c.Saldo_inicial_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoInicialDOL", c.Saldo_inicial_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoInicialEUR", c.Saldo_inicial_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@fk_ID_Digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Comentarios", c.Comentarios, SqlDbType.VarChar);

            _manejador.agregarParametro(comando, "@Depositos", c.Depositos, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Tulas", c.Tulas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cheques", c.Cheques, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@ID", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreRegistro");
            }

        }

        /// <summary>
        /// Registrar un cierre Normal para PROA del CEF en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCajeroPROA con los datos del cierre</param>
        public void agregarCierre(ref CierreCajeroPROA c) //Cambios GZH 18/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProaCierreCajero");

            _manejador.agregarParametro(comando, "@fk_ID_Cajero", c.Cajero.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@Manifiestos_Procesados", c.Manifiestos, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@Corte_EfectivoCOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_EfectivoDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_EfectivoEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesCOL", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesDOL", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesEUR", c.Cheques_locales_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACCOL", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACDOL", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACEUR", c.Cheques_bac_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorCOL", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorDOL", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorEUR", c.Cheques_exterior_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_Suma_ManifiestosCOL", c.Total_Suma_Manifiestos_Colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Suma_ManifiestosDOL", c.Total_Suma_Manifiestos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Suma_ManifiestosEUR", c.Total_Suma_Manifiestos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesLocalesCOL", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesLocalesDOL", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesLocalesEUR", c.Cheques_locales_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesExteriorCOL", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesExteriorDOL", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesExteriorEUR", c.Cheques_exterior_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesBACCOL", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesBACDOL", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesBACEUR", c.Cheques_bac_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@NiquelMesaCOL", c.Niquel_enmesa_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@NiquelMesaDOL", c.Niquel_enmesa_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@NiquelMesaEUR", c.Niquel_enmesa_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@EntregasNiquelCOL", c.Total_Entregas_Niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EntregasNiquelDOL", c.Total_Entregas_Niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EntregasNiquelEUR", c.Total_Entregas_Niquel_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@NiquelTotalCOL", c.Niquel_Total_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@NiquelTotalDOL", c.Niquel_Total_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@NiquelTotalEUR", c.Niquel_Total_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_EntregasCOL", c.Total_Entregas_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregasDOL", c.Total_Entregas_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregasEUR", c.Total_Entregas_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@ComprasDolaresCOL", c.Compra_dolares_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasDolaresDOL", c.Compra_dolares_dol, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasDolaresEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@VentasDolaresCOL", c.Venta_dolares_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasDolaresDOL", c.Venta_dolares_dol, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasDolaresEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@FaltantesClientesCOL", c.Faltante_clientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@FaltantesClientesDOL", c.Faltante_clientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@FaltantesClientesEUR", c.Faltante_clientes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SobrantesClientesCOL", c.Sobrante_clientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SobrantesClientesDOL", c.Sobrante_clientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SobrantesClientesEUR", c.Sobrante_clientes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Faltantes500ClientesCOL", c.Faltante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltantes500ClientesDOL", c.Faltante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltantes500ClientesEUR", c.Faltante_quinientos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Sobrantes500ClientesCOL", c.Sobrante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrantes500ClientesDOL", c.Sobrante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrantes500ClientesEUR", c.Sobrante_quinientos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SaldoFinalCOL", c.Saldo_final_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoFinalDOL", c.Saldo_final_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoFinalEUR", c.Saldo_final_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SaldoInicialCOL", c.Saldo_inicial_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoInicialDOL", c.Saldo_inicial_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoInicialEUR", c.Saldo_inicial_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@fk_ID_Digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Comentarios", c.Comentarios, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Depositos", c.Depositos, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Tulas", c.Tulas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cheques", c.Cheques, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@ComprasEurosCOL", c.Compra_euros_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasEurosDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasEurosEUR", c.Compra_euros_eur, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@VentasEurosCOL", c.Venta_euros_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasEurosDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasEurosEUR", c.Venta_euros_eur, SqlDbType.Money);

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

        public void agregarCierre2(ref CierreCajeroPROA c, int idcoordinador) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProaCierreCajero2");

            _manejador.agregarParametro(comando, "@Manifiestos_Procesados", c.Manifiestos, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@Corte_EfectivoCOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_EfectivoDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_EfectivoEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesCOL", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesDOL", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesLocalesEUR", c.Cheques_locales_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACCOL", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACDOL", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesBACEUR", c.Cheques_bac_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorCOL", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorDOL", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Corte_ChequesExteriorEUR", c.Cheques_exterior_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_Suma_ManifiestosCOL", c.Total_Suma_Manifiestos_Colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Suma_ManifiestosDOL", c.Total_Suma_Manifiestos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Suma_ManifiestosEUR", c.Total_Suma_Manifiestos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesLocalesCOL", c.Cheques_locales_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesLocalesDOL", c.Cheques_locales_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesLocalesEUR", c.Cheques_locales_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesExteriorCOL", c.Cheques_exterior_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesExteriorDOL", c.Cheques_exterior_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesExteriorEUR", c.Cheques_exterior_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_ChequesBACCOL", c.Cheques_bac_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesBACDOL", c.Cheques_bac_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_ChequesBACEUR", c.Cheques_bac_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@NiquelMesaCOL", c.Niquel_enmesa_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@NiquelMesaDOL", c.Niquel_enmesa_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@NiquelMesaEUR", c.Niquel_enmesa_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@EntregasNiquelCOL", c.Total_Entregas_Niquel_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EntregasNiquelDOL", c.Total_Entregas_Niquel_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@EntregasNiquelEUR", c.Total_Entregas_Niquel_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@NiquelTotalCOL", c.Niquel_Total_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@NiquelTotalDOL", c.Niquel_Total_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@NiquelTotalEUR", c.Niquel_Total_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Total_EntregasCOL", c.Total_Entregas_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregasDOL", c.Total_Entregas_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_EntregasEUR", c.Total_Entregas_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@ComprasDolaresCOL", c.Compra_dolares_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasDolaresDOL", c.Compra_dolares_dol, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasDolaresEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@VentasDolaresCOL", c.Venta_dolares_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasDolaresDOL", c.Venta_dolares_dol, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasDolaresEUR", 0, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@FaltantesClientesCOL", c.Faltante_clientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@FaltantesClientesDOL", c.Faltante_clientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@FaltantesClientesEUR", c.Faltante_clientes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SobrantesClientesCOL", c.Sobrante_clientes_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SobrantesClientesDOL", c.Sobrante_clientes_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SobrantesClientesEUR", c.Sobrante_clientes_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Faltantes500ClientesCOL", c.Faltante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltantes500ClientesDOL", c.Faltante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltantes500ClientesEUR", c.Faltante_quinientos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@Sobrantes500ClientesCOL", c.Sobrante_quinientos_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrantes500ClientesDOL", c.Sobrante_quinientos_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrantes500ClientesEUR", c.Sobrante_quinientos_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SaldoFinalCOL", c.Saldo_final_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoFinalDOL", c.Saldo_final_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoFinalEUR", c.Saldo_final_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@SaldoInicialCOL", c.Saldo_inicial_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoInicialDOL", c.Saldo_inicial_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@SaldoInicialEUR", c.Saldo_inicial_euros, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@fk_ID_Digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Comentarios", c.Comentarios, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Depositos", c.Depositos, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Tulas", c.Tulas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cheques", c.Cheques, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@ID", c.ID, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@ComprasEurosCOL", c.Compra_euros_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasEurosDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@ComprasEurosEUR", c.Compra_euros_eur, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@VentasEurosCOL", c.Venta_euros_col, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasEurosDOL", 0, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@VentasEurosEUR", c.Venta_euros_eur, SqlDbType.Money);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreRegistro");
            }

        }

        public void VerificaCierreCajeroNiquel(ref CierreCajeroPROA c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProaVerificaCierreCajeroNiquel");
            int existencia = 0;

            _manejador.agregarParametro(comando, "@fk_ID_Cajero", c.Cajero.ID, SqlDbType.Int);            
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

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

        public void VerificaCierreCajero(ref CierreCajeroPROA c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProaVerificaCierreCajero");            

            _manejador.agregarParametro(comando, "@fk_ID_Cajero", c.Cajero.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

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

        public DataTable ObtenerInformacionDatosCierreCajero(int idcajero, string fechaini, string fechafin)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPROADatosCierreCajero");
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();
            _manejador.agregarParametro(comando, "@cajero", idcajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fechaini", fechaini, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fechafin", fechafin, SqlDbType.VarChar);

            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                //comando.Connection.Close();
                datos.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("SelectPROADatosCierreCajero");
            }
            return datos;
        }

        public DataTable ObtenerInformacionDatosFormularioMoneda(int idcajero, string fechaini, string fechafin)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPROACalculoFormularioMoneda");
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();
            _manejador.agregarParametro(comando, "@cajero", idcajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fechaini", fechaini, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fechafin", fechafin, SqlDbType.VarChar);

            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                //comando.Connection.Close();
                datos.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("SelectPROADatosCierreCajero");
            }
            return datos;
        }

        public DataTable ObtenerInformacionDatosCierreCajeroNiquel(int idcajero, string fechaini, string fechafin)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPROADatosCierreCajeroNiquel");
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();
            _manejador.agregarParametro(comando, "@cajero", idcajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fechaini", fechaini, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fechafin", fechafin, SqlDbType.VarChar);

            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                //comando.Connection.Close();
                datos.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("SelectPROADatosCierreCajeroNiquel");
            }
            return datos;
        }

        public BindingList<CierreCajeroPROA> listarCierres(DateTime f)
        {
            BindingList<CierreCajeroPROA> cierres = new BindingList<CierreCajeroPROA>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresPROA");
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
                    byte tipocierre = Convert.ToByte(datareader["tipocierre"]);
                    CierreCajeroPROA cierre = new CierreCajeroPROA(fecha: f, cajero: cajero, digitador: digitador, tipocierre:tipocierre);

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

        public DataTable listarManifiestosCoordinador(Colaborador c, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROAManifiestosCoordinador");
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

        public DataTable listarMontosClientesDigitadorCoordinadorCierrePROA(Colaborador d, int co, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROAMontosClientesDigitadorCoordinador");
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

        public DataTable listarMontosClientesCajeroCoordinadorCierrePROA(Colaborador c, int co, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROAMontosClientesCajeroCoordinador");
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

        public DataTable listarMontosClientesCoordinadorCierrePROA(int c, DateTime f)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROAMontosClientesCoordinador");
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

        public bool verificarCierrePROA(ref CierreCajeroPROA c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteCierrePROA");
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

        public bool verificarCierreCajeroPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteCierreCajeroPROA");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != c.ID;

                    c.ID = id;
                    c.TipoCierre = Convert.ToByte(datareader["TipoCierre"]);
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarCierreDuplicado");
            }

            return existe;
        }


        public void obtenerDatosCierrePROA(ref CierreCajeroPROA c) //Cambio GZH 21/12/2017
        {
            SqlCommand comando;
            if (c.TipoCierre == 0)
                comando = _manejador.obtenerProcedimiento("SelectCierrePROA");
            else
            {
                comando = _manejador.obtenerProcedimiento("SelectCierrePROA2");
            }
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Comentarios = (string)datareader["Comentarios"];
                    c.ID = (int)datareader["pk_ID"];
                    c.Depositos = Convert.ToInt16(datareader["Depositos"]);
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);
                    c.Manifiestos = Convert.ToInt16(datareader["Manifiestos_Procesados"]);
                    c.TipoCierre = Convert.ToByte(datareader["tipocierre"]);

                    c.Compra_dolares_col = Convert.ToDecimal(datareader["ComprasDolaresCOL"]);
                    c.Compra_dolares_dol = Convert.ToDecimal(datareader["ComprasDolaresDOL"]);
                    c.Compra_euros_col = Convert.ToDecimal(datareader["CompraEurosCOL"]);
                    c.Compra_euros_eur = Convert.ToDecimal(datareader["CompraEurosEUR"]);
                    c.Cheques = Convert.ToInt16(datareader["Cheques"]);
                    c.Cheques_bac_colones = Convert.ToDecimal(datareader["Total_ChequesBACCOL"]);
                    c.Cheques_exterior_colones = Convert.ToDecimal(datareader["Total_ChequesExteriorCOL"]);
                    c.Cheques_locales_colones = Convert.ToDecimal(datareader["Total_ChequesLocalesCOL"]);
                    c.Faltante_clientes_colones = Convert.ToDecimal(datareader["FaltantesClientesCOL"]);
                    c.Faltante_quinientos_colones = Convert.ToDecimal(datareader["Faltantes500ClientesCOL"]);
                    c.Niquel_cola_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_ColaCajerosCOL"]);
                    if (c.TipoCierre == 0)
                        c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["NiquelMesaCOL"]);
                    else
                        c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosCOL"]);
                    c.Niquel_entrega_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_EntregaCajerosCOL"]);
                    c.Niquel_procesamiento_colones = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosCOL"]);
                    c.Niquel_Total_colones = Convert.ToDecimal(datareader["NiquelTotalCOL"]);
                    c.Saldo_final_colones = Convert.ToDecimal(datareader["SaldoFinalCOL"]);
                    c.Saldo_inicial_colones = Convert.ToDecimal(datareader["SaldoInicialCOL"]);
                    c.Sobrante_clientes_colones = Convert.ToDecimal(datareader["SobrantesClientesCOL"]);
                    c.Sobrante_quinientos_colones = Convert.ToDecimal(datareader["Sobrantes500ClientesCOL"]);
                    c.Total_clientes_Directos_colones = Convert.ToDecimal(datareader["Total_Clientes_DirectosCOL"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]);
                    else
                        c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregaBilleteCOL"]);
                    c.Total_Entregas_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]);
                    c.Total_Entregas_Niquel_colones = Convert.ToDecimal(datareader["Total_EntregasNiquelCOL"]);
                    c.Total_Suma_Manifiestos_Colones = Convert.ToDecimal(datareader["Total_Suma_ManifiestosCOL"]);

                    c.Venta_dolares_dol = Convert.ToDecimal(datareader["VentasDolaresDOL"]);
                    c.Venta_dolares_col = Convert.ToDecimal(datareader["VentasDolaresCOL"]);
                    c.Venta_euros_eur = Convert.ToDecimal(datareader["VentaEurosEUR"]);
                    c.Venta_euros_col = Convert.ToDecimal(datareader["VentaEurosCOL"]);
                    c.Cheques_bac_dolares = Convert.ToDecimal(datareader["Total_ChequesBACDOL"]);
                    c.Cheques_exterior_dolares = Convert.ToDecimal(datareader["Total_ChequesExteriorDOL"]);
                    c.Cheques_locales_dolares = Convert.ToDecimal(datareader["Total_ChequesLocalesDOL"]);
                    c.Faltante_clientes_dolares = Convert.ToDecimal(datareader["FaltantesClientesDOL"]);
                    c.Faltante_quinientos_dolares = Convert.ToDecimal(datareader["Faltantes500ClientesDOL"]);
                    c.Niquel_cola_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_ColaCajerosDOL"]);
                    if (c.TipoCierre == 0)
                        c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["NiquelMesaDOL"]);
                    else
                        c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosDOL"]);
                    c.Niquel_entrega_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_EntregaCajerosDOL"]);
                    c.Niquel_procesamiento_dolares = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosDOL"]);
                    c.Niquel_Total_dolares = Convert.ToDecimal(datareader["NiquelTotalDOL"]);
                    c.Saldo_final_dolares = Convert.ToDecimal(datareader["SaldoFinalDOL"]);
                    c.Saldo_inicial_dolares = Convert.ToDecimal(datareader["SaldoInicialDOL"]);
                    c.Sobrante_clientes_dolares = Convert.ToDecimal(datareader["SobrantesClientesDOL"]);
                    c.Sobrante_quinientos_dolares = Convert.ToDecimal(datareader["Sobrantes500ClientesDOL"]);
                    c.Total_clientes_Directos_dolares = Convert.ToDecimal(datareader["Total_Clientes_DirectosDOL"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]);
                    else
                        c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregaBilleteDOL"]);
                    c.Total_Entregas_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]);
                    c.Total_Entregas_Niquel_dolares = Convert.ToDecimal(datareader["Total_EntregasNiquelDOL"]);
                    c.Total_Suma_Manifiestos_dolares = Convert.ToDecimal(datareader["Total_Suma_ManifiestosDOL"]);

                    c.Cheques_bac_euros = Convert.ToDecimal(datareader["Total_ChequesBACEUR"]);
                    c.Cheques_exterior_euros = Convert.ToDecimal(datareader["Total_ChequesExteriorEUR"]);
                    c.Cheques_locales_euros = Convert.ToDecimal(datareader["Total_ChequesLocalesEUR"]);
                    c.Faltante_clientes_euros = Convert.ToDecimal(datareader["FaltantesClientesEUR"]);
                    c.Faltante_quinientos_euros = Convert.ToDecimal(datareader["Faltantes500ClientesEUR"]);
                    c.Niquel_cola_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_ColaCajerosEUR"]);
                    if (c.TipoCierre == 0)
                        c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["NiquelMesaEUR"]);
                    else
                        c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosEUR"]);
                    c.Niquel_entrega_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_EntregaCajerosEUR"]);
                    c.Niquel_procesamiento_euros = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosEUR"]);
                    c.Niquel_Total_euros = Convert.ToDecimal(datareader["NiquelTotalEUR"]);
                    c.Saldo_final_euros = Convert.ToDecimal(datareader["SaldoFinalEUR"]);
                    c.Saldo_inicial_euros = Convert.ToDecimal(datareader["SaldoInicialEUR"]);
                    c.Sobrante_clientes_euros = Convert.ToDecimal(datareader["SobrantesClientesEUR"]);
                    c.Sobrante_quinientos_euros = Convert.ToDecimal(datareader["Sobrantes500ClientesEUR"]);
                    c.Total_clientes_Directos_euros = Convert.ToDecimal(datareader["Total_Clientes_DirectosEUR"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]);
                    else
                        c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregaBilleteEUR"]);
                    c.Total_Entregas_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]);
                    c.Total_Entregas_Niquel_euros = Convert.ToDecimal(datareader["Total_EntregasNiquelEUR"]);
                    c.Total_Suma_Manifiestos_euros = Convert.ToDecimal(datareader["Total_Suma_ManifiestosEUR"]);

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
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        public void obtenerDatosCierreCajeroPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando;
            if (c.TipoCierre == 0)
                comando = _manejador.obtenerProcedimiento("SelectCierreCajeroPROA");
            else
            {
                comando = _manejador.obtenerProcedimiento("SelectCierreCajeroPROA2");
            }
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Comentarios = (string)datareader["Comentarios"];
                    c.ID = (int)datareader["pk_ID"];
                    c.Depositos = Convert.ToInt16(datareader["Depositos"]);
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);
                    c.Manifiestos = Convert.ToInt16(datareader["Manifiestos_Procesados"]);
                    c.TipoCierre = Convert.ToByte(datareader["tipocierre"]);

                    c.Compra_dolares_col = Convert.ToDecimal(datareader["ComprasDolaresCOL"]);
                    c.Compra_dolares_dol = Convert.ToDecimal(datareader["ComprasDolaresDOL"]);
                    c.Compra_euros_col = Convert.ToDecimal(datareader["CompraEurosCOL"]);
                    c.Compra_euros_eur = Convert.ToDecimal(datareader["CompraEurosEUR"]);
                    c.Cheques = Convert.ToInt16(datareader["Cheques"]);
                    c.Cheques_bac_colones = Convert.ToDecimal(datareader["Total_ChequesBACCOL"]);
                    c.Cheques_exterior_colones = Convert.ToDecimal(datareader["Total_ChequesExteriorCOL"]);
                    c.Cheques_locales_colones = Convert.ToDecimal(datareader["Total_ChequesLocalesCOL"]);
                    c.Faltante_clientes_colones = Convert.ToDecimal(datareader["FaltantesClientesCOL"]);
                    c.Faltante_quinientos_colones = Convert.ToDecimal(datareader["Faltantes500ClientesCOL"]);
                    c.Niquel_cola_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_ColaCajerosCOL"]);
                    if (c.TipoCierre == 0)
                        c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["NiquelMesaCOL"]);
                    else
                        c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosCOL"]);
                    c.Niquel_entrega_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_EntregaCajerosCOL"]);
                    c.Niquel_procesamiento_colones = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosCOL"]);
                    c.Niquel_Total_colones = Convert.ToDecimal(datareader["NiquelTotalCOL"]);
                    c.Saldo_final_colones = Convert.ToDecimal(datareader["SaldoFinalCOL"]);
                    c.Saldo_inicial_colones = Convert.ToDecimal(datareader["SaldoInicialCOL"]);
                    c.Sobrante_clientes_colones = Convert.ToDecimal(datareader["SobrantesClientesCOL"]);
                    c.Sobrante_quinientos_colones = Convert.ToDecimal(datareader["Sobrantes500ClientesCOL"]);
                    c.Total_clientes_Directos_colones = Convert.ToDecimal(datareader["Total_Clientes_DirectosCOL"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]);
                    else
                        c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregaBilleteCOL"]);
                    c.Total_Entregas_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_Niquel_colones = Convert.ToDecimal(datareader["EntregasNiquelCOL"]);
                    else
                        c.Total_Entregas_Niquel_colones = Convert.ToDecimal(datareader["Total_EntregasNiquelCOL"]);
                    c.Total_Suma_Manifiestos_Colones = Convert.ToDecimal(datareader["Total_Suma_ManifiestosCOL"]);

                    c.Venta_dolares_dol = Convert.ToDecimal(datareader["VentasDolaresDOL"]);
                    c.Venta_dolares_col = Convert.ToDecimal(datareader["VentasDolaresCOL"]);
                    c.Venta_euros_eur = Convert.ToDecimal(datareader["VentaEurosEUR"]);
                    c.Venta_euros_col = Convert.ToDecimal(datareader["VentaEurosCOL"]);
                    c.Cheques_bac_dolares = Convert.ToDecimal(datareader["Total_ChequesBACDOL"]);
                    c.Cheques_exterior_dolares = Convert.ToDecimal(datareader["Total_ChequesExteriorDOL"]);
                    c.Cheques_locales_dolares = Convert.ToDecimal(datareader["Total_ChequesLocalesDOL"]);
                    c.Faltante_clientes_dolares = Convert.ToDecimal(datareader["FaltantesClientesDOL"]);
                    c.Faltante_quinientos_dolares = Convert.ToDecimal(datareader["Faltantes500ClientesDOL"]);
                    c.Niquel_cola_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_ColaCajerosDOL"]);
                    if (c.TipoCierre == 0)
                        c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["NiquelMesaDOL"]);
                    else
                        c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosDOL"]);
                    c.Niquel_entrega_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_EntregaCajerosDOL"]);
                    c.Niquel_procesamiento_dolares = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosDOL"]);
                    c.Niquel_Total_dolares = Convert.ToDecimal(datareader["NiquelTotalDOL"]);
                    c.Saldo_final_dolares = Convert.ToDecimal(datareader["SaldoFinalDOL"]);
                    c.Saldo_inicial_dolares = Convert.ToDecimal(datareader["SaldoInicialDOL"]);
                    c.Sobrante_clientes_dolares = Convert.ToDecimal(datareader["SobrantesClientesDOL"]);
                    c.Sobrante_quinientos_dolares = Convert.ToDecimal(datareader["Sobrantes500ClientesDOL"]);
                    c.Total_clientes_Directos_dolares = Convert.ToDecimal(datareader["Total_Clientes_DirectosDOL"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]);
                    else
                        c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregaBilleteDOL"]);
                    c.Total_Entregas_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_Niquel_dolares = Convert.ToDecimal(datareader["EntregasNiquelDOL"]);
                    else
                        c.Total_Entregas_Niquel_dolares = Convert.ToDecimal(datareader["Total_EntregasNiquelDOL"]);
                    c.Total_Suma_Manifiestos_dolares = Convert.ToDecimal(datareader["Total_Suma_ManifiestosDOL"]);
                    c.Cheques_bac_euros = Convert.ToDecimal(datareader["Total_ChequesBACEUR"]);
                    c.Cheques_exterior_euros = Convert.ToDecimal(datareader["Total_ChequesExteriorEUR"]);
                    c.Cheques_locales_euros = Convert.ToDecimal(datareader["Total_ChequesLocalesEUR"]);
                    c.Faltante_clientes_euros = Convert.ToDecimal(datareader["FaltantesClientesEUR"]);
                    c.Faltante_quinientos_euros = Convert.ToDecimal(datareader["Faltantes500ClientesEUR"]);
                    c.Niquel_cola_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_ColaCajerosEUR"]);
                    if (c.TipoCierre == 0)
                        c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["NiquelMesaEUR"]);
                    else
                        c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosEUR"]);
                    c.Niquel_entrega_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_EntregaCajerosEUR"]);
                    c.Niquel_procesamiento_euros = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosEUR"]);
                    c.Niquel_Total_euros = Convert.ToDecimal(datareader["NiquelTotalEUR"]);
                    c.Saldo_final_euros = Convert.ToDecimal(datareader["SaldoFinalEUR"]);
                    c.Saldo_inicial_euros = Convert.ToDecimal(datareader["SaldoInicialEUR"]);
                    c.Sobrante_clientes_euros = Convert.ToDecimal(datareader["SobrantesClientesEUR"]);
                    c.Sobrante_quinientos_euros = Convert.ToDecimal(datareader["Sobrantes500ClientesEUR"]);
                    c.Total_clientes_Directos_euros = Convert.ToDecimal(datareader["Total_Clientes_DirectosEUR"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]);
                    else
                        c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregaBilleteEUR"]);
                    c.Total_Entregas_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]);
                    if (c.TipoCierre == 0)
                        c.Total_Entregas_Niquel_euros = Convert.ToDecimal(datareader["EntregasNiquelEUR"]);
                    else
                        c.Total_Entregas_Niquel_euros = Convert.ToDecimal(datareader["Total_EntregasNiquelEUR"]);
                    c.Total_Suma_Manifiestos_euros = Convert.ToDecimal(datareader["Total_Suma_ManifiestosEUR"]);

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador,
                                                              primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);

                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador, primer_apellido_digitador, segundo_apellido_digitador);

                    c.Coordinador = coordinador;
                    c.Digitador = digitador;
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        public BindingList<CierreCajeroPROA> listarCierresCajerosCoordinadorPROA(DateTime f, Colaborador c)
        {
            BindingList<CierreCajeroPROA> cierres = new BindingList<CierreCajeroPROA>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresPROACajerosCoordinador");
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
                    byte tipocierre = Convert.ToByte(datareader["tipocierre"]);

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero,
                                                         primer_apellido_cajero,
                                                         segundo_apellido_cajero);

                    CierreCajeroPROA cierre = new CierreCajeroPROA(id: id_cierre, fecha: f, cajero: cajero, coordinador: c, tipocierre: tipocierre);

                    cierres.Add(cierre);
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cierres;
        }

        public BindingList<CierreCajeroPROA> listarCierresDigitadoresCoordinadorPROA(DateTime f, Colaborador c)
        {
            BindingList<CierreCajeroPROA> cierres = new BindingList<CierreCajeroPROA>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresPROADigitadoresCoordinador");
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
                    byte tipocierre = Convert.ToByte(datareader["tipocierre"]);

                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador,
                                                            primer_apellido_digitador,
                                                            segundo_apellido_digitador);

                    CierreCajeroPROA cierre = new CierreCajeroPROA(fecha: f, digitador: digitador, coordinador: c, tipocierre: tipocierre);

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

        public BindingList<CierreCajeroPROA> listarCierresCajerosDigitadorPROA(DateTime f, Colaborador c)
        {
            BindingList<CierreCajeroPROA> cierres = new BindingList<CierreCajeroPROA>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresPROACajerosDigitador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c, SqlDbType.Int);
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
                    byte tipocierre = Convert.ToByte(datareader["tipocierre"]);

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero,
                                                            primer_apellido_cajero,
                                                            segundo_apellido_cajero);

                    CierreCajeroPROA cierre = new CierreCajeroPROA(fecha: f, cajero: cajero,digitador: c, tipocierre: tipocierre);

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

        public void obtenerDatosCierreCoordinadorPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROACoordinador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Depositos = Convert.ToInt16(datareader["Depositos"]);
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);
                    c.Manifiestos = Convert.ToInt16(datareader["Manifiestos_Procesados"]);
                    //c.TipoCierre = Convert.ToByte(datareader["tipocierre"]);

                    c.Compra_dolares_col = Convert.ToDecimal(datareader["ComprasDolaresCOL"]);
                    c.Compra_dolares_dol = Convert.ToDecimal(datareader["ComprasDolaresDOL"]);
                    c.Compra_euros_col = Convert.ToDecimal(datareader["CompraEurosCOL"]);
                    c.Compra_euros_eur = Convert.ToDecimal(datareader["CompraEurosEUR"]);
                    c.Cheques = Convert.ToInt16(datareader["Cheques"]);
                    c.Cheques_bac_colones = Convert.ToDecimal(datareader["Total_ChequesBACCOL"]);
                    c.Cheques_exterior_colones = Convert.ToDecimal(datareader["Total_ChequesExteriorCOL"]);
                    c.Cheques_locales_colones = Convert.ToDecimal(datareader["Total_ChequesLocalesCOL"]);
                    c.Faltante_clientes_colones = Convert.ToDecimal(datareader["FaltantesClientesCOL"]);
                    c.Faltante_quinientos_colones = Convert.ToDecimal(datareader["Faltantes500ClientesCOL"]);
                    c.Niquel_cola_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_ColaCajerosCOL"]);
                    c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["NiquelMesaCOL"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosCOL"]);
                    c.Niquel_entrega_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_EntregaCajerosCOL"]);
                    c.Niquel_procesamiento_colones = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosCOL"]);
                    c.Niquel_Total_colones = Convert.ToDecimal(datareader["NiquelTotalCOL"]);
                    c.Saldo_final_colones = Convert.ToDecimal(datareader["SaldoFinalCOL"]);
                    c.Saldo_inicial_colones = Convert.ToDecimal(datareader["SaldoInicialCOL"]);
                    c.Sobrante_clientes_colones = Convert.ToDecimal(datareader["SobrantesClientesCOL"]);
                    c.Sobrante_quinientos_colones = Convert.ToDecimal(datareader["Sobrantes500ClientesCOL"]);
                    c.Total_clientes_Directos_colones = Convert.ToDecimal(datareader["Total_Clientes_DirectosCOL"]);
                    c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteCOL"]);

                    c.Total_Entregas_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]);
                    c.Total_Entregas_Niquel_colones = Convert.ToDecimal(datareader["Total_EntregasNiquelCOL"]);
                    c.Total_Suma_Manifiestos_Colones = Convert.ToDecimal(datareader["Total_Suma_ManifiestosCOL"]);

                    c.Venta_dolares_dol = Convert.ToDecimal(datareader["VentasDolaresDOL"]);
                    c.Venta_dolares_col = Convert.ToDecimal(datareader["VentasDolaresCOL"]);
                    c.Venta_euros_eur = Convert.ToDecimal(datareader["VentaEurosEUR"]);
                    c.Venta_euros_col = Convert.ToDecimal(datareader["VentaEurosCOL"]);
                    c.Cheques_bac_dolares = Convert.ToDecimal(datareader["Total_ChequesBACDOL"]);
                    c.Cheques_exterior_dolares = Convert.ToDecimal(datareader["Total_ChequesExteriorDOL"]);
                    c.Cheques_locales_dolares = Convert.ToDecimal(datareader["Total_ChequesLocalesDOL"]);
                    c.Faltante_clientes_dolares = Convert.ToDecimal(datareader["FaltantesClientesDOL"]);
                    c.Faltante_quinientos_dolares = Convert.ToDecimal(datareader["Faltantes500ClientesDOL"]);
                    c.Niquel_cola_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_ColaCajerosDOL"]);
                    c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["NiquelMesaDOL"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosDOL"]);

                    c.Niquel_entrega_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_EntregaCajerosDOL"]);
                    c.Niquel_procesamiento_dolares = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosDOL"]);
                    c.Niquel_Total_dolares = Convert.ToDecimal(datareader["NiquelTotalDOL"]);
                    c.Saldo_final_dolares = Convert.ToDecimal(datareader["SaldoFinalDOL"]);
                    c.Saldo_inicial_dolares = Convert.ToDecimal(datareader["SaldoInicialDOL"]);
                    c.Sobrante_clientes_dolares = Convert.ToDecimal(datareader["SobrantesClientesDOL"]);
                    c.Sobrante_quinientos_dolares = Convert.ToDecimal(datareader["Sobrantes500ClientesDOL"]);
                    c.Total_clientes_Directos_dolares = Convert.ToDecimal(datareader["Total_Clientes_DirectosDOL"]);
                    c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteDOL"]);

                    c.Total_Entregas_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]);
                    c.Total_Entregas_Niquel_dolares = Convert.ToDecimal(datareader["Total_EntregasNiquelDOL"]);
                    c.Total_Suma_Manifiestos_dolares = Convert.ToDecimal(datareader["Total_Suma_ManifiestosDOL"]);

                    c.Cheques_bac_euros = Convert.ToDecimal(datareader["Total_ChequesBACEUR"]);
                    c.Cheques_exterior_euros = Convert.ToDecimal(datareader["Total_ChequesExteriorEUR"]);
                    c.Cheques_locales_euros = Convert.ToDecimal(datareader["Total_ChequesLocalesEUR"]);
                    c.Faltante_clientes_euros = Convert.ToDecimal(datareader["FaltantesClientesEUR"]);
                    c.Faltante_quinientos_euros = Convert.ToDecimal(datareader["Faltantes500ClientesEUR"]);
                    c.Niquel_cola_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_ColaCajerosEUR"]);
                    c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["NiquelMesaEUR"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosEUR"]);

                    c.Niquel_entrega_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_EntregaCajerosEUR"]);
                    c.Niquel_procesamiento_euros = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosEUR"]);
                    c.Niquel_Total_euros = Convert.ToDecimal(datareader["NiquelTotalEUR"]);
                    c.Saldo_final_euros = Convert.ToDecimal(datareader["SaldoFinalEUR"]);
                    c.Saldo_inicial_euros = Convert.ToDecimal(datareader["SaldoInicialEUR"]);
                    c.Sobrante_clientes_euros = Convert.ToDecimal(datareader["SobrantesClientesEUR"]);
                    c.Sobrante_quinientos_euros = Convert.ToDecimal(datareader["Sobrantes500ClientesEUR"]);
                    c.Total_clientes_Directos_euros = Convert.ToDecimal(datareader["Total_Clientes_DirectosEUR"]);
                    c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteEUR"]);

                    c.Total_Entregas_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]);
                    c.Total_Entregas_Niquel_euros = Convert.ToDecimal(datareader["Total_EntregasNiquelEUR"]);
                    c.Total_Suma_Manifiestos_euros = Convert.ToDecimal(datareader["Total_Suma_ManifiestosEUR"]);

                    /*int id_digitador = (int)datareader["ID_Digitador"];

                    Colaborador digitador = new Colaborador(id_digitador);
                    c.Digitador = digitador;
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];*/

                    /*int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador,
                                                              primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);                    

                    c.Coordinador = coordinador;
                    c.Digitador = digitador;*/


                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        public void obtenerDatosCierreSoloDigitadorPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROASoloDigitador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Depositos = Convert.ToInt16(datareader["Depositos"]);
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);
                    c.Manifiestos = Convert.ToInt16(datareader["Manifiestos_Procesados"]);
                    //c.TipoCierre = Convert.ToByte(datareader["tipocierre"]);

                    c.Compra_dolares_col = Convert.ToDecimal(datareader["ComprasDolaresCOL"]);
                    c.Compra_dolares_dol = Convert.ToDecimal(datareader["ComprasDolaresDOL"]);
                    c.Compra_euros_eur = Convert.ToDecimal(datareader["CompraEurosCOL"]);
                    c.Compra_euros_eur = Convert.ToDecimal(datareader["CompraEurosEUR"]);
                    c.Cheques = Convert.ToInt16(datareader["Cheques"]);
                    c.Cheques_bac_colones = Convert.ToDecimal(datareader["Total_ChequesBACCOL"]);
                    c.Cheques_exterior_colones = Convert.ToDecimal(datareader["Total_ChequesExteriorCOL"]);
                    c.Cheques_locales_colones = Convert.ToDecimal(datareader["Total_ChequesLocalesCOL"]);
                    c.Faltante_clientes_colones = Convert.ToDecimal(datareader["FaltantesClientesCOL"]);
                    c.Faltante_quinientos_colones = Convert.ToDecimal(datareader["Faltantes500ClientesCOL"]);
                    c.Niquel_cola_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_ColaCajerosCOL"]);
                    c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["NiquelMesaCOL"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosCOL"]);
                    c.Niquel_entrega_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_EntregaCajerosCOL"]);
                    c.Niquel_procesamiento_colones = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosCOL"]);
                    c.Niquel_Total_colones = Convert.ToDecimal(datareader["NiquelTotalCOL"]);
                    c.Saldo_final_colones = Convert.ToDecimal(datareader["SaldoFinalCOL"]);
                    c.Saldo_inicial_colones = Convert.ToDecimal(datareader["SaldoInicialCOL"]);
                    c.Sobrante_clientes_colones = Convert.ToDecimal(datareader["SobrantesClientesCOL"]);
                    c.Sobrante_quinientos_colones = Convert.ToDecimal(datareader["Sobrantes500ClientesCOL"]);
                    c.Total_clientes_Directos_colones = Convert.ToDecimal(datareader["Total_Clientes_DirectosCOL"]);
                    c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteCOL"]);
                    c.Total_Entregas_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]);
                    c.Total_Entregas_Niquel_colones = Convert.ToDecimal(datareader["Total_EntregasNiquelCOL"]);
                    c.Total_Suma_Manifiestos_Colones = Convert.ToDecimal(datareader["Total_Suma_ManifiestosCOL"]);

                    c.Venta_dolares_dol = Convert.ToDecimal(datareader["VentasDolaresDOL"]);
                    c.Venta_dolares_col = Convert.ToDecimal(datareader["VentasDolaresCOL"]);
                    c.Venta_euros_eur = Convert.ToDecimal(datareader["VentaEurosEUR"]);
                    c.Venta_euros_col = Convert.ToDecimal(datareader["VentaEurosCOL"]);
                    c.Cheques_bac_dolares = Convert.ToDecimal(datareader["Total_ChequesBACDOL"]);
                    c.Cheques_exterior_dolares = Convert.ToDecimal(datareader["Total_ChequesExteriorDOL"]);
                    c.Cheques_locales_dolares = Convert.ToDecimal(datareader["Total_ChequesLocalesDOL"]);
                    c.Faltante_clientes_dolares = Convert.ToDecimal(datareader["FaltantesClientesDOL"]);
                    c.Faltante_quinientos_dolares = Convert.ToDecimal(datareader["Faltantes500ClientesDOL"]);
                    c.Niquel_cola_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_ColaCajerosDOL"]);
                    c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["NiquelMesaDOL"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosDOL"]);
                    c.Niquel_entrega_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_EntregaCajerosDOL"]);
                    c.Niquel_procesamiento_dolares = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosDOL"]);
                    c.Niquel_Total_dolares = Convert.ToDecimal(datareader["NiquelTotalDOL"]);
                    c.Saldo_final_dolares = Convert.ToDecimal(datareader["SaldoFinalDOL"]);
                    c.Saldo_inicial_dolares = Convert.ToDecimal(datareader["SaldoInicialDOL"]);
                    c.Sobrante_clientes_dolares = Convert.ToDecimal(datareader["SobrantesClientesDOL"]);
                    c.Sobrante_quinientos_dolares = Convert.ToDecimal(datareader["Sobrantes500ClientesDOL"]);
                    c.Total_clientes_Directos_dolares = Convert.ToDecimal(datareader["Total_Clientes_DirectosDOL"]);
                    c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteDOL"]);
                    c.Total_Entregas_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]);
                    c.Total_Entregas_Niquel_dolares = Convert.ToDecimal(datareader["Total_EntregasNiquelDOL"]);
                    c.Total_Suma_Manifiestos_dolares = Convert.ToDecimal(datareader["Total_Suma_ManifiestosDOL"]);

                    c.Cheques_bac_euros = Convert.ToDecimal(datareader["Total_ChequesBACEUR"]);
                    c.Cheques_exterior_euros = Convert.ToDecimal(datareader["Total_ChequesExteriorEUR"]);
                    c.Cheques_locales_euros = Convert.ToDecimal(datareader["Total_ChequesLocalesEUR"]);
                    c.Faltante_clientes_euros = Convert.ToDecimal(datareader["FaltantesClientesEUR"]);
                    c.Faltante_quinientos_euros = Convert.ToDecimal(datareader["Faltantes500ClientesEUR"]);
                    c.Niquel_cola_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_ColaCajerosEUR"]);
                    c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["NiquelMesaEUR"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosEUR"]);
                    c.Niquel_entrega_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_EntregaCajerosEUR"]);
                    c.Niquel_procesamiento_euros = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosEUR"]);
                    c.Niquel_Total_euros = Convert.ToDecimal(datareader["NiquelTotalEUR"]);
                    c.Saldo_final_euros = Convert.ToDecimal(datareader["SaldoFinalEUR"]);
                    c.Saldo_inicial_euros = Convert.ToDecimal(datareader["SaldoInicialEUR"]);
                    c.Sobrante_clientes_euros = Convert.ToDecimal(datareader["SobrantesClientesEUR"]);
                    c.Sobrante_quinientos_euros = Convert.ToDecimal(datareader["Sobrantes500ClientesEUR"]);
                    c.Total_clientes_Directos_euros = Convert.ToDecimal(datareader["Total_Clientes_DirectosEUR"]);
                    c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteEUR"]);
                    c.Total_Entregas_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]);
                    c.Total_Entregas_Niquel_euros = Convert.ToDecimal(datareader["Total_EntregasNiquelEUR"]);
                    c.Total_Suma_Manifiestos_euros = Convert.ToDecimal(datareader["Total_Suma_ManifiestosEUR"]);

                    /*int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador,
                                                              primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);

                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador,
                                                              primer_apellido_digitador,
                                                              segundo_apellido_digitador);*/

                    //c.Coordinador = coordinador;
                    //c.Digitador = digitador;


                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        public void obtenerDatosCierreDigitadorPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROADigitador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Depositos = Convert.ToInt16(datareader["Depositos"]);
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);
                    c.Manifiestos = Convert.ToInt16(datareader["Manifiestos_Procesados"]);
                    //c.TipoCierre = Convert.ToByte(datareader["tipocierre"]);

                    c.Compra_dolares_col = Convert.ToDecimal(datareader["ComprasDolaresCOL"]);
                    c.Compra_dolares_dol = Convert.ToDecimal(datareader["ComprasDolaresDOL"]);
                    c.Compra_euros_col = Convert.ToDecimal(datareader["CompraEurosCOL"]);
                    c.Compra_euros_eur = Convert.ToDecimal(datareader["CompraEurosEUR"]);
                    c.Cheques = Convert.ToInt16(datareader["Cheques"]);
                    c.Cheques_bac_colones = Convert.ToDecimal(datareader["Total_ChequesBACCOL"]);
                    c.Cheques_exterior_colones = Convert.ToDecimal(datareader["Total_ChequesExteriorCOL"]);
                    c.Cheques_locales_colones = Convert.ToDecimal(datareader["Total_ChequesLocalesCOL"]);
                    c.Faltante_clientes_colones = Convert.ToDecimal(datareader["FaltantesClientesCOL"]);
                    c.Faltante_quinientos_colones = Convert.ToDecimal(datareader["Faltantes500ClientesCOL"]);
                    c.Niquel_cola_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_ColaCajerosCOL"]);
                    c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["NiquelMesaCOL"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosCOL"]);
                    /*if (c.TipoCierre == 0)
                        c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["NiquelMesaCOL"]);
                    else
                        c.Niquel_enmesa_colones = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosCOL"]);*/
                    c.Niquel_entrega_Cajeros_colones = Convert.ToDecimal(datareader["Niquel_EntregaCajerosCOL"]);
                    c.Niquel_procesamiento_colones = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosCOL"]);
                    c.Niquel_Total_colones = Convert.ToDecimal(datareader["NiquelTotalCOL"]);
                    c.Saldo_final_colones = Convert.ToDecimal(datareader["SaldoFinalCOL"]);
                    c.Saldo_inicial_colones = Convert.ToDecimal(datareader["SaldoInicialCOL"]);
                    c.Sobrante_clientes_colones = Convert.ToDecimal(datareader["SobrantesClientesCOL"]);
                    c.Sobrante_quinientos_colones = Convert.ToDecimal(datareader["Sobrantes500ClientesCOL"]);
                    c.Total_clientes_Directos_colones = Convert.ToDecimal(datareader["Total_Clientes_DirectosCOL"]);
                    c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteCOL"]);
                    /*if (c.TipoCierre == 0)
                        c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]);
                    else
                        c.Total_Entregas_billetes_colones = Convert.ToDecimal(datareader["Total_EntregaBilleteCOL"]);*/
                    c.Total_Entregas_colones = Convert.ToDecimal(datareader["Total_EntregasCOL"]);
                    c.Total_Entregas_Niquel_colones = Convert.ToDecimal(datareader["Total_EntregasNiquelCOL"]);
                    c.Total_Suma_Manifiestos_Colones = Convert.ToDecimal(datareader["Total_Suma_ManifiestosCOL"]);

                    c.Venta_dolares_dol = Convert.ToDecimal(datareader["VentasDolaresDOL"]);
                    c.Venta_dolares_col = Convert.ToDecimal(datareader["VentasDolaresCOL"]);
                    c.Venta_euros_eur = Convert.ToDecimal(datareader["VentaEurosEUR"]);
                    c.Venta_euros_col = Convert.ToDecimal(datareader["VentaEurosCOL"]);
                    c.Cheques_bac_dolares = Convert.ToDecimal(datareader["Total_ChequesBACDOL"]);
                    c.Cheques_exterior_dolares = Convert.ToDecimal(datareader["Total_ChequesExteriorDOL"]);
                    c.Cheques_locales_dolares = Convert.ToDecimal(datareader["Total_ChequesLocalesDOL"]);
                    c.Faltante_clientes_dolares = Convert.ToDecimal(datareader["FaltantesClientesDOL"]);
                    c.Faltante_quinientos_dolares = Convert.ToDecimal(datareader["Faltantes500ClientesDOL"]);
                    c.Niquel_cola_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_ColaCajerosDOL"]);
                    c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["NiquelMesaDOL"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosDOL"]);
                    /*if (c.TipoCierre == 0)
                        c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["NiquelMesaDOL"]);
                    else
                        c.Niquel_enmesa_dolares = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosDOL"]);*/
                    c.Niquel_entrega_Cajeros_dolares = Convert.ToDecimal(datareader["Niquel_EntregaCajerosDOL"]);
                    c.Niquel_procesamiento_dolares = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosDOL"]);
                    c.Niquel_Total_dolares = Convert.ToDecimal(datareader["NiquelTotalDOL"]);
                    c.Saldo_final_dolares = Convert.ToDecimal(datareader["SaldoFinalDOL"]);
                    c.Saldo_inicial_dolares = Convert.ToDecimal(datareader["SaldoInicialDOL"]);
                    c.Sobrante_clientes_dolares = Convert.ToDecimal(datareader["SobrantesClientesDOL"]);
                    c.Sobrante_quinientos_dolares = Convert.ToDecimal(datareader["Sobrantes500ClientesDOL"]);
                    c.Total_clientes_Directos_dolares = Convert.ToDecimal(datareader["Total_Clientes_DirectosDOL"]);
                    c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteDOL"]);
                    /*if (c.TipoCierre == 0)
                        c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]);
                    else
                        c.Total_Entregas_billetes_dolares = Convert.ToDecimal(datareader["Total_EntregaBilleteDOL"]);*/
                    c.Total_Entregas_dolares = Convert.ToDecimal(datareader["Total_EntregasDOL"]);
                    c.Total_Entregas_Niquel_dolares = Convert.ToDecimal(datareader["Total_EntregasNiquelDOL"]);
                    c.Total_Suma_Manifiestos_dolares = Convert.ToDecimal(datareader["Total_Suma_ManifiestosDOL"]);

                    c.Cheques_bac_euros = Convert.ToDecimal(datareader["Total_ChequesBACEUR"]);
                    c.Cheques_exterior_euros = Convert.ToDecimal(datareader["Total_ChequesExteriorEUR"]);
                    c.Cheques_locales_euros = Convert.ToDecimal(datareader["Total_ChequesLocalesEUR"]);
                    c.Faltante_clientes_euros = Convert.ToDecimal(datareader["FaltantesClientesEUR"]);
                    c.Faltante_quinientos_euros = Convert.ToDecimal(datareader["Faltantes500ClientesEUR"]);
                    c.Niquel_cola_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_ColaCajerosEUR"]);
                    c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["NiquelMesaEUR"]) + Convert.ToDecimal(datareader["Niquel_EnMesaCajerosEUR"]);
                    /*if (c.TipoCierre == 0)
                        c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["NiquelMesaEUR"]);
                    else
                        c.Niquel_enmesa_euros = Convert.ToDecimal(datareader["Niquel_EnMesaCajerosEUR"]);*/
                    c.Niquel_entrega_Cajeros_euros = Convert.ToDecimal(datareader["Niquel_EntregaCajerosEUR"]);
                    c.Niquel_procesamiento_euros = Convert.ToDecimal(datareader["Niquel_ProcesamientoCajerosEUR"]);
                    c.Niquel_Total_euros = Convert.ToDecimal(datareader["NiquelTotalEUR"]);
                    c.Saldo_final_euros = Convert.ToDecimal(datareader["SaldoFinalEUR"]);
                    c.Saldo_inicial_euros = Convert.ToDecimal(datareader["SaldoInicialEUR"]);
                    c.Sobrante_clientes_euros = Convert.ToDecimal(datareader["SobrantesClientesEUR"]);
                    c.Sobrante_quinientos_euros = Convert.ToDecimal(datareader["Sobrantes500ClientesEUR"]);
                    c.Total_clientes_Directos_euros = Convert.ToDecimal(datareader["Total_Clientes_DirectosEUR"]);
                    c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]) + Convert.ToDecimal(datareader["Total_EntregaBilleteEUR"]);
                    /*                    if (c.TipoCierre == 0)
                                            c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]);
                                        else
                                            c.Total_Entregas_billetes_euros = Convert.ToDecimal(datareader["Total_EntregaBilleteEUR"]);*/
                    c.Total_Entregas_euros = Convert.ToDecimal(datareader["Total_EntregasEUR"]);
                    c.Total_Entregas_Niquel_euros = Convert.ToDecimal(datareader["Total_EntregasNiquelEUR"]);
                    c.Total_Suma_Manifiestos_euros = Convert.ToDecimal(datareader["Total_Suma_ManifiestosEUR"]);

                    /*int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador,
                                                              primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);

                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador,
                                                              primer_apellido_digitador,
                                                              segundo_apellido_digitador);

                    c.Coordinador = coordinador;
                    c.Digitador = digitador;*/


                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
        }

        public void obtenerTotalesManifiestoCierreSoloDigitadorPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROASoloDigitadorTotalesManifiestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                datareader.Read();
                if (c.TipoCierre == 1)
                {
                    c.Total_clientes_Directos_colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                    c.Total_clientes_Directos_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                    c.Total_clientes_Directos_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                }
                else
                {
                    c.Total_Suma_Manifiestos_Colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                    c.Total_Suma_Manifiestos_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                    c.Total_Suma_Manifiestos_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                }
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

        public void obtenerTotalesManifiestoCierreDigitadorPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROADigitadorTotalesManifiestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                datareader.Read();
                if (c.TipoCierre == 1)
                {
                    c.Total_clientes_Directos_colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                    c.Total_clientes_Directos_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                    c.Total_clientes_Directos_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                }
                else
                {
                    c.Total_Suma_Manifiestos_Colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                    c.Total_Suma_Manifiestos_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                    c.Total_Suma_Manifiestos_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                }
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

        public void obtenerTotalesTulasCierreDigitadorPROA(ref CierreCajeroPROA c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROADigitadorTotalesTulas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        public void obtenerTotalesTulasCierreSoloDigitadorPROA(ref CierreCajeroPROA c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROADigitadorSoloTotalesTulas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);            
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        public DataTable obtenerInconsistenciasCierreDigitadorPROA(CierreCajeroPROA c)
        {
            DataTable inconsistencias = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROADigitadorInconsistencias");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                /*while (datareader.Read())
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
                }*/
                inconsistencias.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        public DataTable obtenerInconsistenciasCierreCajeroPROA(CierreCajeroPROA c)
        {
            DataTable inconsistencias = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROACajeroInconsistencias");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);            
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
         
                inconsistencias.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        public DataTable obtenerInconsistenciasCierrePROA(CierreCajeroPROA c)
        {
            DataTable inconsistencias = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROAInconsistencias");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);            
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                /*while (datareader.Read())
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
                }*/
                inconsistencias.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        public DataTable obtenerInconsistenciasDigitadorCierrePROA(CierreCajeroPROA c)
        {
            DataTable inconsistencias = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROAInconsistenciasDigitador");
            SqlDataReader datareader = null;
            
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                /*while (datareader.Read())
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
                }*/
                inconsistencias.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        public DataTable obtenerInconsistenciasCoordinadorCierrePROA(CierreCajeroPROA c)
        {
            DataTable inconsistencias = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROAInconsistenciasCoordinador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
               
                inconsistencias.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        public void obtenerDatoDigitadorPROA(ref CierreCajeroPROA c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierresPROADigitadoresCoordinadorCierre");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@Identificacion", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipocierre", c.TipoCierre, SqlDbType.Int);
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

        public void obtenerTotalesManifiestoCierrePROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROATotalesManifiestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                datareader.Read();

                if (c.TipoCierre == 1)
                {
                    c.Total_clientes_Directos_colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                    c.Total_clientes_Directos_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                    c.Total_clientes_Directos_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                }
                else
                {
                    c.Total_Suma_Manifiestos_Colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                    c.Total_Suma_Manifiestos_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                    c.Total_Suma_Manifiestos_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                }
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

        public void obtenerTotalesManifiestoCajeroCierrePROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROATotalesManifiestosCajero");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                datareader.Read();

                if (c.TipoCierre == 1)
                {
                    c.Total_clientes_Directos_colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                    c.Total_clientes_Directos_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                    c.Total_clientes_Directos_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                }
                else
                {
                    c.Total_Suma_Manifiestos_Colones = (decimal)datareader["Ingreso_Clientes_Colones"];
                    c.Total_Suma_Manifiestos_dolares = (decimal)datareader["Ingreso_Clientes_Dolares"];
                    c.Total_Suma_Manifiestos_euros = (decimal)datareader["Ingreso_Clientes_Euros"];
                }
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

        public void obtenerTotalesTulasCierrePROA(ref CierreCajeroPROA c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROATotalesTulas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", c.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        public void obtenerTotalesTulasCajeroCierrePROA(ref CierreCajeroPROA c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierrePROATotalesTulasCajero");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);            
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                    c.Tulas = Convert.ToInt16(datareader["Tulas"]);

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Métodos Públicos
    }
}
