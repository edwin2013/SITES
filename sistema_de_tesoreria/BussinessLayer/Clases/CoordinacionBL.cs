//
//  @ Project : 
//  @ File Name : CoordinacionBL.cs
//  @ Date : 06/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;

using CommonObjects;
using DataLayer;
using LibreriaMensajes;
using System.Collections;
using CommonObjects.Clases;
using BussinessLayer;
using DataLayer.Clases;
using DataLayer.Clases.Reportes;
using LibreriaAccesoDatos;
using BussinessLayer.Clases;

namespace BussinessLayer
{
    public class CoordinacionBL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CoordinacionBL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CoordinacionBL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CoordinacionBL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        CierresCEFDL _cierres = CierresCEFDL.Instancia;
        CierresATMsDL _cierres_atms = CierresATMsDL.Instancia;
        MontosCierreATMsDL _montos_cierres_arms = MontosCierreATMsDL.Instancia;
        RegistrosDenominacionesCierreDL _denominaciones_cierres = RegistrosDenominacionesCierreDL.Instancia;
        ColasCierreDL _colas = ColasCierreDL.Instancia;
        InconsistenciasDepositosDL _inconsistencias_depositos = InconsistenciasDepositosDL.Instancia;
        InconsistenciasManifiestosCEFDL _inconsistencias_manifiestos_cef = InconsistenciasManifiestosCEFDL.Instancia;
        InconsistenciasDigitadoresDL _inconsistencias_digitador = InconsistenciasDigitadoresDL.Instancia;
        ValoresDL _valores = ValoresDL.Instancia;
        SobresDL _sobres = SobresDL.Instancia;
        GestionesDL _gestiones = GestionesDL.Instancia;
        ManifiestosCEFDL _manifiestos_cef = ManifiestosCEFDL.Instancia;
        ManifiestosBovedaDL _manifiestos_boveda = ManifiestosBovedaDL.Instancia;
        SegregadosDL _segregados = SegregadosDL.Instancia;
        DepositosDL _depositos = DepositosDL.Instancia;
        CoordinacionDL _coordinacion = CoordinacionDL.Instancia;
        RegistrosErroresCierresDL _errores = RegistrosErroresCierresDL.Instancia;
        DescargasATMsDL _descargas = DescargasATMsDL.Instancia;
        RechazosDescargasATMsDL _rechazos = RechazosDescargasATMsDL.Instancia;
        ContadoresDescargasATMsDL _contadores = ContadoresDescargasATMsDL.Instancia;
        DescargasATMsFullDL _descargas_full = DescargasATMsFullDL.Instancia;
        MontosDescargasATMsFullDL _montos_descargas_full = MontosDescargasATMsFullDL.Instancia;
        ContadoresDescargasATMsFullDL _contadores_full = ContadoresDescargasATMsFullDL.Instancia;
        CargasATMsDL _cargas = CargasATMsDL.Instancia;
        CargasEmergenciaATMsDL _cargas_emergencia = CargasEmergenciaATMsDL.Instancia;
        CargasEmergenciaATMsFullDL _cargas_emergencia_full = CargasEmergenciaATMsFullDL.Instancia;
        CartuchosCargasATMsDL _cartuchos_cargas = CartuchosCargasATMsDL.Instancia;
        RegistrosRemanentesATMsDL _registros_remanentes_atms = RegistrosRemanentesATMsDL.Instancia;
        MontoRemanentesATMsDL _registros_rementes_atms_completos = MontoRemanentesATMsDL.Instancia;
        MontosRetirosATMsDL _montos_retiros = MontosRetirosATMsDL.Instancia;
        TrialesDescargasATMsDL _triales = TrialesDescargasATMsDL.Instancia;
        CartuchosDL _cartuchos = CartuchosDL.Instancia;
        DenominacionesDL _denominaciones = DenominacionesDL.Instancia;
        SucursalesDL _sucursales = SucursalesDL.Instancia;
        PlanillasEmpresasDL _planilla = PlanillasEmpresasDL.Instancia;
        InconsistenciaPlanillaDL _inconsistencia = InconsistenciaPlanillaDL.Instancia;
        CargasSucursalesDL _carga_sucursales = CargasSucursalesDL.Instancia;
        CartuchosCargaSucursalesDL _cartuchos_cargas_sucursales = CartuchosCargaSucursalesDL.Instancia;
        PedidoBancoDL _pedido_bancos = PedidoBancoDL.Instancia;
        BolsaPedidoBancoDL _bolsa_pedido_banco = BolsaPedidoBancoDL.Instancia;
        CargasEmergenciaSucursalesDL _cargas_emergencia_sucursales = CargasEmergenciaSucursalesDL.Instancia;
        CierreSucursalDL _cierre_sucursal = CierreSucursalDL.Instancia;
        TulasDL _bolsa = TulasDL.Instancia;
        MutiladoDL _mutilado = MutiladoDL.Instancia;
        CartuchoMutiladoDL _cartucho_efectivo_mutilado = CartuchoMutiladoDL.Instancia;
        ManejadorArchivosTexto _manejador_texto = ManejadorArchivosTexto.Instancia;
        CierreBancoDL _cierre_bancos = CierreBancoDL.Instancia;
        MontosBolsaSucursalesDL _montos_bolsas_sucursales = MontosBolsaSucursalesDL.Instancia;
        MontosBolsasPedidoBancoDL _montos_bolsas_bancos = MontosBolsasPedidoBancoDL.Instancia;
        VehiculoDL _vehiculos = VehiculoDL.Instancia;
        EquipoDL _equipos = EquipoDL.Instancia;
        PedidoNiquelDL _pedido_niquel = PedidoNiquelDL.Instancia;
        CartuchosNiquelDL _cartuchos_niquel = CartuchosNiquelDL.Instancia;
        CierrePedidoNiquelDL _cierre_niquel = CierrePedidoNiquelDL.Instancia;
        MontoBolsaNiquelDL _montos_bolsas_niquel = MontoBolsaNiquelDL.Instancia;
        RegistroPenalidadDL _registro_penalidad = RegistroPenalidadDL.Instancia;
        PenalidadDL _penalidad = PenalidadDL.Instancia;
        TipoPenalidadDL _tipo_penalidad = TipoPenalidadDL.Instancia;
        NivelTipoPenalidadDL _nivel_tipo_penalidad = NivelTipoPenalidadDL.Instancia;
        ResumenFacturacionClientesDL _resumen_facturacion_cliente = ResumenFacturacionClientesDL.Instancia;
        PuntoAtencionDL _punto_atencion = PuntoAtencionDL.Instancia;
        ResumenFacturacionTransportadoraDL _resumen_facturacion_transportadora = ResumenFacturacionTransportadoraDL.Instancia;
        TulasDL _tulas = TulasDL.Instancia;
        RecaptPreliminarDL _recapt_preliminar = RecaptPreliminarDL.Instancia;
        MontosRecaptPreliminarDL _montos_recapt_preliminar = MontosRecaptPreliminarDL.Instancia;
        RecaptFinalDL _recapt_final = RecaptFinalDL.Instancia;
        MontoRecaptFinalDL _montos_recapt_final = MontoRecaptFinalDL.Instancia;
        BolsaCompletaNiquelDL _bolsa_completa = BolsaCompletaNiquelDL.Instancia;
        CierreCargasATMsDL _cierre_cargas_atms = CierreCargasATMsDL.Instancia;
        EstadoCartuchoDL _estados = EstadoCartuchoDL.Instancia;
        FallaCartuchoDL _fallas = FallaCartuchoDL.Instancia;
        GarantiaCartuchoDL _garantias = GarantiaCartuchoDL.Instancia;
        ProveedorCartuchoDL _proveedores = ProveedorCartuchoDL.Instancia;
        CargaTransportadoraDL _carga_transportadora = CargaTransportadoraDL.Instancia;
        CartuchosCargaTransportadoraDL _cartucho_transportadora = CartuchosCargaTransportadoraDL.Instancia;
        MontosBolsaTransportadoraDL _montos_bolsa_transportadora = MontosBolsaTransportadoraDL.Instancia;
        LibroMayorBovedaDL _libros_mayor_boveda = LibroMayorBovedaDL.Instancia;
        SaldoLibroBovedaDL _saldo_boveda = SaldoLibroBovedaDL.Instancia;
        SaldoLibroNiquelDL _saldo_niquel = SaldoLibroNiquelDL.Instancia;
        CierreCajeroPROA_DL _cierresPROA = CierreCajeroPROA_DL.Instancia;
        

        #endregion Atributos

        #region Constructor

        public CoordinacionBL() { }

        #endregion Constructor

        #region Métodos Públicos

        #region Cierres del CEF

        /// <summary>
        /// Obtener los datos de los manifiestos procesados.
        /// </summary>
        /// <param name="i">Fecha incial para la cual se desea delimitar la consulta</param>
        /// <param name="t">Lista de Empresa transporte para la que se desea obtener los manifiestos procesados</param>
        /// <returns>Tabla con la lista de los manifiestos procesados</returns>
        public DataTable obtenerDatosManifiestosFacturacion(DateTime i, EmpresaTransporte t)
        {
            try
            {
                return _coordinacion.obtenerDatosManifiestosFacturacion(i, t);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Registrar un cierre en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre</param>
        public void agregarCierre(ref CierreCEF c)
        {

            try
            {
                BindingList<Denominacion> denominaciones_descarga = _denominaciones.listarDenominacionesCargasATMs();

                _cierres.agregarCierre(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de caja.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre</param>
        public void actualizarCierre(CierreCEF c)
        {

            try
            {
                _cierres.actualizarCierre(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un cierre.
        /// </summary>
        /// <param name="c">Objeto CierreCEF con los datos del cierre a eliminar</param>
        public void eliminarCierre(CierreCEF c)
        {

            try
            {
                _cierres.eliminarCierre(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de un determinado cierre en una determinada fecha.
        /// </summary>
        /// <param name="c">Objeto Cierre con los datos del cierre</param>
        public void obtenerDatosCierre(ref CierreCEF c)
        {

            try
            {
                if (_cierres.verificarCierre(ref c))
                    _cierres.obtenerDatosCierre(ref c);

                _cierres.obtenerTotalesManifiestoCierre(ref c);
                _cierres.obtenerTotalesTulasCierre(ref c);

                BindingList<InconsistenciaDeposito> inconsistencias = 
                    _cierres.obtenerInconsistenciasCierre(c);

                foreach (InconsistenciaDeposito inconsistencia in inconsistencias)
                {
                    InconsistenciaDeposito copia = inconsistencia;

                    _sobres.obtenerSobresInconsistencia(ref copia);

                    if (inconsistencia.Diferencia_colones > 0)
                        c.Sobrante_clientes_colones += inconsistencia.Diferencia_colones;
                    else
                        c.Faltante_clientes_colones += Math.Abs(inconsistencia.Diferencia_colones);

                    if (inconsistencia.Diferencia_dolares > 0)
                        c.Sobrante_clientes_dolares += inconsistencia.Diferencia_dolares;
                    else
                        c.Faltante_clientes_dolares += Math.Abs(inconsistencia.Diferencia_dolares);

                    if (inconsistencia.Diferencia_euros > 0)
                        c.Sobrante_clientes_euros += inconsistencia.Diferencia_euros;
                    else
                        c.Faltante_clientes_euros += Math.Abs(inconsistencia.Diferencia_euros);

                    foreach (Sobre sobre in inconsistencia.Sobres)
                    {

                        switch (sobre.Moneda)
                        {
                            case Monedas.Colones:

                                if (sobre.Monto_real > sobre.Monto_reportado)
                                    c.Sobrante_clientes_colones += sobre.Monto_real - sobre.Monto_reportado;
                                else
                                    c.Faltante_clientes_colones += Math.Abs(sobre.Monto_real - sobre.Monto_reportado);

                                break;
                            case Monedas.Dolares:

                                if (sobre.Monto_real > sobre.Monto_reportado)
                                    c.Sobrante_clientes_dolares += sobre.Monto_real - sobre.Monto_reportado;
                                else
                                    c.Faltante_clientes_dolares += Math.Abs(sobre.Monto_real - sobre.Monto_reportado);

                                break;
                            case Monedas.Euros:

                                if (sobre.Monto_real > sobre.Monto_reportado)
                                    c.Sobrante_clientes_euros += sobre.Monto_real - sobre.Monto_reportado;
                                else
                                    c.Faltante_clientes_euros += Math.Abs(sobre.Monto_real - sobre.Monto_reportado);

                                break;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los cierres registrados en determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cierres registrados en la fecha dada</returns>
        public BindingList<CierreCEF> listarCierres(DateTime f)
        {

            try
            {
                return _cierres.listarCierres(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los cajeros con un cierre registrado por un coordinador.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <returns>Lista de cajeros con un cierre registrado en la fecha dada por el coordinador</returns>
        public BindingList<CierreCEF> listarCierresCajerosCoordinador(DateTime f, Colaborador c)
        {

            try
            {
                return _cierres.listarCierresCajerosCoordinador(f, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los digitadores con un cierre registrado por un coordinador.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <returns>Lista de digitadores con un cierre  registrado en la fecha dada por el coordinador</returns>
        public BindingList<CierreCEF> listarCierresDigitadoresCoordinador(DateTime f, Colaborador c)
        {

            try
            {
                return _cierres.listarCierresDigitadoresCoordinador(f, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de un determinado cierre para un cajero en una determinada fecha.
        /// </summary>
        /// <param name="c">Objeto Cierre con los datos del cierre</param>
        public void obtenerDatosCierreCajero(ref CierreCEF c)
        {

            try
            {
                _cierres.obtenerDatosCierreCajero(ref c);
                _cierres.obtenerTotalesManifiestoCierreCajero(ref c);
                _cierres.obtenerTotalesTulasCierreCajero(ref c);

                BindingList<InconsistenciaDeposito> inconsistencias =
                    _cierres.obtenerInconsistenciasCierreCajero(c);

                foreach (InconsistenciaDeposito inconsistencia in inconsistencias)
                {
                    InconsistenciaDeposito copia = inconsistencia;

                    _sobres.obtenerSobresInconsistencia(ref copia);

                    if (inconsistencia.Diferencia_colones > 0)
                        c.Sobrante_clientes_colones += inconsistencia.Diferencia_colones;
                    else
                        c.Faltante_clientes_colones += Math.Abs(inconsistencia.Diferencia_colones);

                    if (inconsistencia.Diferencia_dolares > 0)
                        c.Sobrante_clientes_dolares += inconsistencia.Diferencia_dolares;
                    else
                        c.Faltante_clientes_dolares += Math.Abs(inconsistencia.Diferencia_dolares);

                    foreach (Sobre sobre in inconsistencia.Sobres)
                    {

                        switch (sobre.Moneda)
                        {
                            case Monedas.Colones:

                                if (sobre.Monto_real > sobre.Monto_reportado)
                                    c.Sobrante_clientes_colones += sobre.Monto_real - sobre.Monto_reportado;
                                else
                                    c.Faltante_clientes_colones += Math.Abs(sobre.Monto_real - sobre.Monto_reportado);

                                break;
                            case Monedas.Dolares:

                                if (sobre.Monto_real > sobre.Monto_reportado)
                                    c.Sobrante_clientes_dolares += sobre.Monto_real - sobre.Monto_reportado;
                                else
                                    c.Faltante_clientes_dolares += Math.Abs(sobre.Monto_real - sobre.Monto_reportado);

                                break;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de un determinado cierre para un digitador en una determinada fecha.
        /// </summary>
        /// <param name="c">Objeto Cierre con los datos del cierre</param>
        public void obtenerDatosCierreDigitador(ref CierreCEF c)
        {

            try
            {
                _cierres.obtenerDatosCierreDigitador(ref c);
                _cierres.obtenerTotalesManifiestoCierreDigitador(ref c);
                _cierres.obtenerTotalesTulasCierreDigitador(ref c);

                BindingList<InconsistenciaDeposito> inconsistencias =
                    _cierres.obtenerInconsistenciasCierreDigitador(c);

                foreach (InconsistenciaDeposito inconsistencia in inconsistencias)
                {
                    InconsistenciaDeposito copia = inconsistencia;

                    _sobres.obtenerSobresInconsistencia(ref copia);

                    if (inconsistencia.Diferencia_colones > 0)
                        c.Sobrante_clientes_colones += inconsistencia.Diferencia_colones;
                    else
                        c.Faltante_clientes_colones += Math.Abs(inconsistencia.Diferencia_colones);

                    if (inconsistencia.Diferencia_dolares > 0)
                        c.Sobrante_clientes_dolares += inconsistencia.Diferencia_dolares;
                    else
                        c.Faltante_clientes_dolares += Math.Abs(inconsistencia.Diferencia_dolares);

                    foreach (Sobre sobre in inconsistencia.Sobres)
                    {

                        switch (sobre.Moneda)
                        {
                            case Monedas.Colones:

                                if (sobre.Monto_real > sobre.Monto_reportado)
                                    c.Sobrante_clientes_colones += sobre.Monto_real - sobre.Monto_reportado;
                                else
                                    c.Faltante_clientes_colones += Math.Abs(sobre.Monto_real - sobre.Monto_reportado);

                                break;
                            case Monedas.Dolares:

                                if (sobre.Monto_real > sobre.Monto_reportado)
                                    c.Sobrante_clientes_dolares += sobre.Monto_real - sobre.Monto_reportado;
                                else
                                    c.Faltante_clientes_dolares += Math.Abs(sobre.Monto_real - sobre.Monto_reportado);

                                break;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los manifiestos actualizados por un coordinador en una fecha específica.
        /// </summary>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de manifiestos del coordinador</returns>
        public DataTable listarManifiestosCoordinador(Colaborador c, DateTime f)
        {

            try
            {
                return _cierres.listarManifiestosCoordinador(c, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los manifiestos tramitados por un digitador.
        /// </summary>
        /// <param name="d">Digitador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de manifiestos del digitador</returns>
        public DataTable listarManifiestosDigitador(Colaborador d, DateTime f)
        {

            try
            {
                return _cierres.listarManifiestosDigitador(d, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de un coordinador.
        /// </summary>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesCoordinadorCierre(Colaborador c, DateTime f)
        {

            try
            {
                return _cierres.listarMontosClientesCoordinadorCierre(c, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de para los supervisores.
        /// </summary>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesSupervisorCierre(DateTime f)
        {

            try
            {
                return _cierres.listarMontosClientesSupervisorCierre(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de un cajero.
        /// </summary>
        /// <param name="c">Cajero para el cual se genera la lista</param>
        /// /// <param name="co">Coordinador que genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesCajeroCoordinadorCierre(Colaborador c, Colaborador co, DateTime f)
        {

            try
            {
                return _cierres.listarMontosClientesCajeroCoordinadorCierre(c, co, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de un cajero.
        /// </summary>
        /// <param name="c">Cajero para el cual se genera la lista</param>
        /// /// <param name="co">Coordinador que genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesCajeroSupervisorCierre(Colaborador c,DateTime f)
        {

            try
            {
                return _cierres.listarMontosClientesCajeroSupervisorCierre(c, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de un digitador.
        /// </summary>
        /// <param name="d">Digitador para el cual se genera la lista</param>
        /// <param name="co">Coordinador que genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesDigitadorCoordinadorCierre(Colaborador d, Colaborador co, DateTime f)
        {

            try
            {
                return _cierres.listarMontosClientesDigitadorCoordinadorCierre(d, co, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de un digitador.
        /// </summary>
        /// <param name="d">Digitador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesDigitadorSupervisorCierre(Colaborador d, DateTime f)
        {

            try
            {
                return _cierres.listarMontosClientesDigitadorSupervisorCierre(d, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los montos por cliente para el cierre de un digitador.
        /// </summary>
        /// <param name="d">Digitador para el cual se genera la lista</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de montos por clientes</returns>
        public DataTable listarMontosClientesDigitadorCierre(Colaborador d, DateTime f)
        {

            try
            {
                return _cierres.listarMontosClientesDigitadorCierre(d, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de un determinado cierre para un digitador.
        /// </summary>
        /// <param name="c">Objeto Cierre con los datos del cierre</param>
        public void obtenerDatoDigitador(ref CierreCEF c)
        {
            try
            {
                _cierres.obtenerDatoDigitador(ref c);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        #endregion Cierres del CEF

        #region PROA

        public BindingList<CierreCajeroPROA> listarCierresPROA(DateTime f)
        {

            try
            {
                return _cierresPROA.listarCierres(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<CierreCajeroPROA> listarCierresCajerosDigitadorPROA(DateTime f, Colaborador c)
        {

            try
            {
                return _cierresPROA.listarCierresCajerosDigitadorPROA(f, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable listarManifiestosCoordinadorPROA(Colaborador c, DateTime f)
        {

            try
            {
                return _cierresPROA.listarManifiestosCoordinador(c, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listarMontosClientesCoordinadorCierrePROA(int c, DateTime f)
        {

            try
            {
                return _cierresPROA.listarMontosClientesCoordinadorCierrePROA(c, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listarMontosClientesCajeroCoordinadorCierrePROA(Colaborador c, int co, DateTime f)
        {

            try
            {
                return _cierresPROA.listarMontosClientesCajeroCoordinadorCierrePROA(c, co, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listarMontosClientesDigitadorCoordinadorCierrePROA(Colaborador d, int co, DateTime f)
        {

            try
            {
                return _cierresPROA.listarMontosClientesDigitadorCoordinadorCierrePROA(d, co, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /*public void obtenerDatosCierrePROA(ref CierreCajeroPROA c)
        {

            try
            {
                if (_cierresPROA.verificarCierrePROA(ref c))                                          
                    _cierresPROA.obtenerDatosCierrePROA(ref c);                                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }*/

        public BindingList<CierreCajeroPROA> listarCierresCajerosCoordinadorPROA(DateTime f, Colaborador c)
        {

            try
            {
                return _cierresPROA.listarCierresCajerosCoordinadorPROA(f, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los digitadores con un cierre registrado por un coordinador.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <param name="c">Coordinador para el cual se genera la lista</param>
        /// <returns>Lista de digitadores con un cierre  registrado en la fecha dada por el coordinador</returns>
        public BindingList<CierreCajeroPROA> listarCierresDigitadoresCoordinadorPROA(DateTime f, Colaborador c)
        {

            try
            {
                return _cierresPROA.listarCierresDigitadoresCoordinadorPROA(f, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void obtenerDatosCierreDigitadorPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {

            try
            {
                DataTable inconsistencias;
                if (c.Coordinador != null)
                {
                    _cierresPROA.obtenerDatosCierreDigitadorPROA(ref c);
                    /*_cierresPROA.obtenerTotalesManifiestoCierreDigitadorPROA(ref c);
                    _cierresPROA.obtenerTotalesTulasCierreDigitadorPROA(ref c);*/

                    inconsistencias = _cierresPROA.obtenerInconsistenciasCierrePROA(c);
                }
                else
                {
                    _cierresPROA.obtenerDatosCierreSoloDigitadorPROA(ref c);
                    /*_cierresPROA.obtenerTotalesManifiestoCierreSoloDigitadorPROA(ref c);
                    _cierresPROA.obtenerTotalesTulasCierreSoloDigitadorPROA(ref c);*/

                    inconsistencias = _cierresPROA.obtenerInconsistenciasDigitadorCierrePROA(c);
                }

                /*if (inconsistencias.Rows.Count > 0)
                {
                    for (int i = 0; i < inconsistencias.Rows.Count; i++)
                    {
                        string tipomoneda = inconsistencias.Rows[i]["Moneda"].ToString();
                        switch (tipomoneda)
                        {
                            case "COLONES":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_colones = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_colones = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                            case "DOLARES":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_dolares = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_dolares = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                            case "EUROS":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_euros = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_euros = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                        }
                    }
                }*/

                /*foreach (InconsistenciaDeposito inconsistencia in inconsistencias)
                {
                    InconsistenciaDeposito copia = inconsistencia;

                    _sobres.obtenerSobresInconsistencia(ref copia);

                    if (inconsistencia.Diferencia_colones > 0)
                        c.Sobrante_clientes_colones += inconsistencia.Diferencia_colones;
                    else
                        c.Faltante_clientes_colones += Math.Abs(inconsistencia.Diferencia_colones);

                    if (inconsistencia.Diferencia_dolares > 0)
                        c.Sobrante_clientes_dolares += inconsistencia.Diferencia_dolares;
                    else
                        c.Faltante_clientes_dolares += Math.Abs(inconsistencia.Diferencia_dolares);                    

                }*/

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void obtenerDatosCierreCoordinadorPROA(ref CierreCajeroPROA c) //Cambios GZH 21/12/2017
        {

            try
            {
                DataTable inconsistencias;
                _cierresPROA.obtenerDatosCierreCoordinadorPROA(ref c);
                /*_cierresPROA.obtenerTotalesManifiestoCierreSoloDigitadorPROA(ref c);
                _cierresPROA.obtenerTotalesTulasCierreSoloDigitadorPROA(ref c);*/

                inconsistencias = _cierresPROA.obtenerInconsistenciasCoordinadorCierrePROA(c);

                /*if (inconsistencias.Rows.Count > 0)
                {
                    for (int i = 0; i < inconsistencias.Rows.Count; i++)
                    {
                        string tipomoneda = inconsistencias.Rows[i]["Moneda"].ToString();
                        switch (tipomoneda)
                        {
                            case "COLONES":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_colones = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_colones = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                            case "DOLARES":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_dolares = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_dolares = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                            case "EUROS":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_euros = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_euros = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                        }
                    }
                }*/

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public void obtenerDatosCierreDigitadorPROA(ref CierreCajeroPROA c)
        //{

        //    try
        //    {
        //        _cierresPROA.obtenerDatosCierreDigitadorPROA(ref c);
        //        _cierresPROA.obtenerTotalesManifiestoCierreDigitadorPROA(ref c);
        //        _cierresPROA.obtenerTotalesTulasCierreDigitadorPROA(ref c);

        //        DataTable inconsistencias =
        //            _cierresPROA.obtenerInconsistenciasCierrePROA(c);

        //        if (inconsistencias.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < inconsistencias.Rows.Count; i++)
        //            {
        //                string tipomoneda = inconsistencias.Rows[i]["Moneda"].ToString();
        //                switch (tipomoneda)
        //                {
        //                    case "COLONES":
        //                        if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
        //                        {
        //                            c.Faltante_clientes_colones = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
        //                        }
        //                        else
        //                        {
        //                            c.Sobrante_clientes_colones = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
        //                        }
        //                        break;
        //                    case "DOLARES":
        //                        if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
        //                        {
        //                            c.Faltante_clientes_dolares = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
        //                        }
        //                        else
        //                        {
        //                            c.Sobrante_clientes_dolares = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
        //                        }
        //                        break;
        //                    case "EUROS":
        //                        if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
        //                        {
        //                            c.Faltante_clientes_euros = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
        //                        }
        //                        else
        //                        {
        //                            c.Sobrante_clientes_euros = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
        //                        }
        //                        break;
        //                }
        //            }
        //        }

        //        /*foreach (InconsistenciaDeposito inconsistencia in inconsistencias)
        //        {
        //            InconsistenciaDeposito copia = inconsistencia;

        //            _sobres.obtenerSobresInconsistencia(ref copia);

        //            if (inconsistencia.Diferencia_colones > 0)
        //                c.Sobrante_clientes_colones += inconsistencia.Diferencia_colones;
        //            else
        //                c.Faltante_clientes_colones += Math.Abs(inconsistencia.Diferencia_colones);

        //            if (inconsistencia.Diferencia_dolares > 0)
        //                c.Sobrante_clientes_dolares += inconsistencia.Diferencia_dolares;
        //            else
        //                c.Faltante_clientes_dolares += Math.Abs(inconsistencia.Diferencia_dolares);                    

        //        }*/

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public void obtenerDatosCierrePROA(ref CierreCajeroPROA c)
        {

            try
            {
                DataTable inconsistencias;
                if (c.Digitador == null)
                {
                    if (_cierresPROA.verificarCierreCajeroPROA(ref c))
                        _cierresPROA.obtenerDatosCierreCajeroPROA(ref c);

                    _cierresPROA.obtenerTotalesManifiestoCajeroCierrePROA(ref c);
                    _cierresPROA.obtenerTotalesTulasCajeroCierrePROA(ref c);

                    inconsistencias = _cierresPROA.obtenerInconsistenciasCierreCajeroPROA(c);
                }
                else
                {
                    if (_cierresPROA.verificarCierrePROA(ref c))
                        _cierresPROA.obtenerDatosCierrePROA(ref c);

                    _cierresPROA.obtenerTotalesManifiestoCierrePROA(ref c);
                    _cierresPROA.obtenerTotalesTulasCierrePROA(ref c);

                    inconsistencias = _cierresPROA.obtenerInconsistenciasCierreDigitadorPROA(c);
                }

                /*if (inconsistencias.Rows.Count > 0)
                {
                    for (int i = 0; i < inconsistencias.Rows.Count; i++)
                    {
                        string tipomoneda = inconsistencias.Rows[i]["Moneda"].ToString();
                        switch (tipomoneda)
                        {
                            case "COLONES":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_colones = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_colones = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                            case "DOLARES":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_dolares = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_dolares = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                            case "EUROS":
                                if (inconsistencias.Rows[i]["Tipo_Diferencia"].ToString().Equals("FALTANTE"))
                                {
                                    c.Faltante_clientes_euros = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                else
                                {
                                    c.Sobrante_clientes_euros = Convert.ToDecimal(inconsistencias.Rows[i]["Diferencia"]);
                                }
                                break;
                        }
                    }
                }*/

                /*BindingList<InconsistenciaDeposito> inconsistencias =
                    _cierres.obtenerInconsistenciasCierre(c);

                foreach (InconsistenciaDeposito inconsistencia in inconsistencias)
                {
                    InconsistenciaDeposito copia = inconsistencia;

                    _sobres.obtenerSobresInconsistencia(ref copia);

                    if (inconsistencia.Diferencia_colones > 0)
                        c.Sobrante_clientes_colones += inconsistencia.Diferencia_colones;
                    else
                        c.Faltante_clientes_colones += Math.Abs(inconsistencia.Diferencia_colones);

                    if (inconsistencia.Diferencia_dolares > 0)
                        c.Sobrante_clientes_dolares += inconsistencia.Diferencia_dolares;
                    else
                        c.Faltante_clientes_dolares += Math.Abs(inconsistencia.Diferencia_dolares);

                    if (inconsistencia.Diferencia_euros > 0)
                        c.Sobrante_clientes_euros += inconsistencia.Diferencia_euros;
                    else
                        c.Faltante_clientes_euros += Math.Abs(inconsistencia.Diferencia_euros);                    

                }*/

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void obtenerDatoDigitadorPROA(ref CierreCajeroPROA c)
        {
            try
            {
                _cierresPROA.obtenerDatoDigitadorPROA(ref c);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion PROA

        #region Cierres de ATM's


        /// <summary>
        /// Obtener datos de portavalor asignado a una carga ATM
        /// </summary>
        /// <param name="c">Carga asignada al portavalor</param>
        /// <returns>Datos del portavalor</returns>
        public void listarPortavalorPorCargaATM(ref CargaATM c)
        {

            try
            {
                _cargas.listarPotavalorPorCargaATM(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Registrar un cierre de ATM's en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        public void agregarCierreATMs(ref CierreATMs c)
        {

            try
            {
                BindingList<Denominacion> denominaciones_cargas = _denominaciones.listarDenominacionesCargasATMs();
                BindingList<Denominacion> denominaciones_full = _denominaciones.listarDenominaciones();

              

                _cierres_atms.agregarCierreATMs(ref c);

                c.crearMontosDescargas(denominaciones_cargas);
                c.crearMontosDescargasFull(denominaciones_full);

                foreach (MontoCierreATMs monto in c.Montos_descargas)
                {
                    MontoCierreATMs copia = monto;

                    _montos_cierres_arms.agregarMontoCierreATMs(ref copia, c);
                }

                foreach (MontoCierreATMs monto in c.Montos_descargas_full)
                {
                    MontoCierreATMs copia = monto;

                    _montos_cierres_arms.agregarMontoCierreATMs(ref copia, c);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        public void actualizarCierreATMs(CierreATMs c)
        {

            try
            {
                _cierres_atms.actualizarCierreATMs(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar como terminado un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        public void actualizarCierreATMsTerminar(CierreATMs c)
        {

            try
            {
                _cierres_atms.actualizarCierreATMsTerminar(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public bool verificarCierreATMs(ref CierreATMs c)
        {

            try
            {
                bool existe = _cierres_atms.verificarCierreATMs(ref c);

                if (existe)
                {
                    _cargas.obtenerCargasATMsCierreATMs(ref c);
                    _descargas.obtenerDescargasATMsCierreATMs(ref c);
                    _descargas_full.obtenerDescargasATMsFullCierreATMs(ref c);
                    _montos_cierres_arms.obtenerMontosCierreATMs(ref c); 

                    foreach (CargaATM carga in c.Cargas)
                    {
                        CargaATM copia = carga;

                        _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, false);
                        _cargas.obtenerDatosCargaATM(ref copia);
                        _cargas.obtenerDatosVerificacionCarga(ref copia);
                    }

                    foreach (DescargaATM descarga in c.Descargas)
                    {
                        DescargaATM copia_descarga = descarga;
                        CargaATM copia_carga = copia_descarga.Carga;
                        CargaEmergenciaATM copia_carga_emergencia = copia_descarga.Carga_emergencia;
 
                        if (copia_carga != null)
                        {
                            _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_carga, false);

                            descarga.reasignarCarga();
                        }

                        if (copia_carga_emergencia != null)
                        {
                            _cargas_emergencia.obtenerEmergenciasCargaEmergenciaATM(ref copia_carga_emergencia);

                            foreach (CargaATM emergencia in copia_carga_emergencia.Emergencias)
                            {
                                CargaATM copia_emergencia = emergencia;

                                _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_emergencia, false);

                                copia_emergencia.recalcularMontosCarga();
                            }

                            copia_carga_emergencia.reasignarEmergencias();
                            descarga.reasignarCargaEmergencia();
                        }

                        _rechazos.obtenerRechazosDescargaATM(ref copia_descarga);
                        _contadores.obtenerContadoresDescargaATM(ref copia_descarga);
                        _descargas.obtenerDatosDescargaATM(ref copia_descarga);

                        descarga.recalcularMontosDescarga();
                        descarga.recalcularDetalles();
                    }

                    foreach (DescargaATMFull descarga in c.Descargas_full)
                    {
                        DescargaATMFull copia_descarga = descarga;
                        CargaATM copia_carga = copia_descarga.Carga;

                        _montos_descargas_full.obtenerMontosDescargaATMFull(ref copia_descarga);
                        _contadores_full.obtenerContadoresDescargaATMFull(ref copia_descarga);
                        _descargas_full.obtenerDatosDescargaATMFull(ref copia_descarga);

                        descarga.recalcularMontosDescarga();
                        descarga.recalcularDetalles();
                    }

                }

                return existe;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si un cajero tiene un cierre pendiente de finalizar.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cajero</param>
        /// <returns>Valor que indica si el cajero tiene un cierre pendiente</returns>
        public bool verificarCierreATMsPendiente(ref CierreATMs c)
        {

            try
            {
                return _cierres_atms.verificarCierreATMsPendiente(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista los montos de un recapt de una fecha específica
        /// </summary>
        /// <param name="fecha">Fecha del Recapt</param>
        /// <returns>La lista de denominaciones del Recapt</returns>
        public BindingList<MontosRecaptPreliminar> listarRecaptPreliminar(DateTime fecha)
        {
            return _recapt_preliminar.listarRecaptPreliminar(fecha);
        }



        /// <summary>
        /// Lista los montos de un recapt de una fecha específica
        /// </summary>
        /// <param name="fecha">Fecha del Recapt</param>
        /// <returns>La lista de denominaciones del Recapt</returns>
        public BindingList<MontosRecaptFinal> listarRecaptFinal(DateTime fecha)
        {
            return _recapt_final.listarRecaptFinal(fecha);
        }





        /// <summary>
        /// Lista los montos de un recapt de una fecha específica
        /// </summary>
        /// <param name="fecha">Fecha del Recapt</param>
        /// <returns>La lista de denominaciones del Recapt</returns>
        public BindingList<Recap> listarRecapts(DateTime fecha)
        {
            return _recapt_preliminar.listarRecap(fecha);
        }




        /// <summary>
        /// Lista los montos de un recapt de una fecha específica
        /// </summary>
        /// <param name="fecha">Fecha del Recapt</param>
        /// <returns>La lista de denominaciones del Recapt</returns>
        public BindingList<RecaptPreliminar> listarRecaptsporAprobar(EstadoRecapt est)
        {
            BindingList<RecaptPreliminar> lista = _recapt_preliminar.listarRecapPreliminarPorEstado(est);

            foreach (RecaptPreliminar r in lista)
            {
                RecaptPreliminar copia = r;
                _montos_recapt_preliminar.obtenerMontosRecapPreliminar(ref copia);
            }

            return lista;
        }


        #endregion Cierres de ATM's

        #region Cierre Cargas ATMs

        /// <summary>
        /// Actualizar los datos de un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        public void actualizarCierreCargaATMs(CierreCargasATMs c)
        {

            try
            {
                _cierre_cargas_atms.actualizarCierreCargasATMs(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar los datos de un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        public void agregarCierreCargaATMs(ref CierreCargasATMs c)
        {

            try
            {
                _cierre_cargas_atms.agregarCierreCargasATMs(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Obtiene un cierre de cargas de ATMs 
        /// </summary>
        /// <param name="fecha">Fecha del cierre</param>
        /// <returns>Un objeto datos del cierre</returns>
        public CierreCargasATMs obtenerCierreCargaATM(DateTime fecha)
        {

            if (_cierre_cargas_atms.obtenerCierreCargasATMs(fecha) == null)
                return null;
            else
                return _cierre_cargas_atms.obtenerCierreCargasATMs(fecha);
        }




        /// <summary>
        /// Obtiene un cierre de cargas de ATMs 
        /// </summary>
        /// <param name="fecha">Fecha del cierre</param>
        /// <returns>Un objeto datos del cierre</returns>
        public void obtenerCierreCargaATMDatos(DateTime fecha, ref CierreCargasATMs cierre)
        {
                _cierre_cargas_atms.obtenerCierreCargasATMsDatos(fecha, ref cierre);
        }


        #endregion Cierre Cargas ATMs

        #region Cierre Descargas ATMs

        /// <summary>
        /// Actualizar los datos de un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        public void actualizarCierreDescargaATMs(CierreCargasATMs c)
        {

            try
            {
                _cierre_cargas_atms.actualizarCierreDescargasATMs(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar los datos de un cierre de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre</param>
        public void agregarCierreDescargaATMs(ref CierreCargasATMs c)
        {

            try
            {
                _cierre_cargas_atms.agregarCierreDescargasATMs(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Obtiene un cierre de cargas de ATMs 
        /// </summary>
        /// <param name="fecha">Fecha del cierre</param>
        /// <returns>Un objeto datos del cierre</returns>
        public CierreCargasATMs obtenerCierreDescargaATM(DateTime fecha)
        {

            if (_cierre_cargas_atms.obtenerCierreDescargasATMs(fecha) == null)
                return null;
            else
                return _cierre_cargas_atms.obtenerCierreDescargasATMs(fecha);
        }




        /// <summary>
        /// Obtiene un cierre de cargas de ATMs 
        /// </summary>
        /// <param name="fecha">Fecha del cierre</param>
        /// <returns>Un objeto datos del cierre</returns>
        public void obtenerCierreDescargaATMDatos(DateTime fecha, ref CierreCargasATMs cierre)
        {
           _cierre_cargas_atms.obtenerCierreDescargasATMsDatos(fecha, ref cierre);
        }


        #endregion Cierre Descargas ATMs

        #region Montos de Cierres de ATM's

        /// <summary>
        /// Actualizar la cantidad de fórmulas de un monto por denominación de un cierre.
        /// </summary>
        /// <param name="m">Objeto MontoCierreATMs con los datos del monto por denominacion</param>
        public void actualizarMontoCierreATMs(MontoCierreATMs m)
        {

            try
            {
                _montos_cierres_arms.actualizarMontoCierreATMs(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Montos de Cierres de ATM's

        #region Cargas de ATM's

        /// <summary>
        /// Actualizar los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATM(CargaATM c)
        {

            try
            {
                _cargas.actualizarCargaATM(c);

                foreach (CartuchoCargaATM cartucho in c.Cartuchos)
                {
                    CartuchoCargaATM copia_cartucho = cartucho;

                    _cartuchos_cargas.actualizarCartuchoCargaATM(copia_cartucho);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Actualizar los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarFinalizarCodigoCargaATM(CargaATM c)
        {

            try
            {
                _cargas.actualizarFinalizarCodigoCargaATM(c);

              

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Actualizar los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCodigosCajerosCargaATM(CargaATM c)
        {

            try
            {
                _cargas.actualizarCodigosCajerosCargaATM(c);

                //foreach (CartuchoCargaATM cartucho in c.Cartuchos)
                //{
                //    CartuchoCargaATM copia_cartucho = cartucho;

                //    _cartuchos_cargas.actualizarCartuchoCargaATM(copia_cartucho);
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualiza la lista de las cargas del roadnet
        /// </summary>
        /// <param name="f">Fecha de la carga</param>
        public void ActualizarCargasATMRoadnet(DateTime f)
        {

            try
            {

                _cargas.actualizarCargaATMDatosRoadnet(f);


            }
            catch (Exception ex)
            {
                this.guardarArchivo(ex.Message, f);

            }

        }





        /// <summary>
        /// Actualiza la lista de las cargas del compass
        /// </summary>
        /// <param name="f">Fecha de la recepción</param>
        public void ActualizarDatosCompass(DateTime f)
        {

            try
            {

                _tulas.actualizarDatosCompass(f);


            }
            catch (Exception ex)
            {
                this.guardarArchivo(ex.Message, f);

            }

        }





        /// <summary>
        /// Actualiza la lista de las cargas del compass
        /// </summary>
        /// <param name="f">Fecha de la recepción</param>
        public void ActualizarAlarmasPapel(DateTime f)
        {

            try
            {

                _tulas.actualizarAlarmasPapel(f);


            }
            catch (Exception ex)
            {
                this.guardarArchivoAlarmasPapel(ex.Message, f);

            }

        }



        /// <summary>
        /// Guarda una bitácora con las fechas del robot. 
        /// </summary>
        private void guardarArchivo(string text, DateTime fecha)
        {
            string fechita = fecha.Day.ToString("00") + fecha.Month.ToString("00") + fecha.Year.ToString("0000");
            string fic = @"\\10.120.131.100\\Proyectos\\Bitácoras Robot Compass\\" + fechita + ".txt";
            string texto = text +","+ DateTime.Now;

            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
            sw.WriteLine(texto);
            sw.Close();
        }




        /// <summary>
        /// Guarda una bitácora con las fechas del robot. 
        /// </summary>
        private void guardarArchivoAlarmasPapel(string text, DateTime fecha)
        {
            string fechita = fecha.Day.ToString("00") + fecha.Month.ToString("00") + fecha.Year.ToString("0000");
            string fic = @"\\10.120.131.100\\Proyectos\\Bitácoras Alarmas Papel\\" + fechita + ".txt";
            string texto = text + "," + DateTime.Now;

            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
            sw.WriteLine(texto);
            sw.Close();
        }



        /// <summary>
        /// Actualiza la lista de las cargas del roadnet
        /// </summary>
        /// <param name="f">Fecha de la carga</param>
        public void ActualizarHorasHH(DateTime f)
        {

            try
            {

                _cargas.actualizarCargaATMDatosRoadnet(f);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Ligar o desligar la carga de un ATM del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMCierreATMs(CargaATM c)
        {

            try
            {
                _cargas.actualizarCargaATMCierreATMs(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Asignar la carga de un ATM a un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMCajero(CargaATM c)
        {

            try
            {
                _cargas.actualizarCargaATMCajero(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Asignar la ruta a la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMRuta(CargaATM c)
        {

            try
            {
                _cargas.actualizarCargaATMRuta(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



      


        /// <summary>
        /// Asignar la ruta y la hora de llegada a la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMRutaHora(CargaATM c)
        {

            try
            {
                _cargas.actualizarCargaATMRutaHora(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar el orden de las cargas de ATM's de una ruta específica.
        /// </summary>
        /// <param name="c">Lista de cargas de una ruta específica</param>
        public void actualizarCargasATMsOrdenRuta(BindingList<CargaATM> c)
        {

            try
            {
                foreach (CargaATM carga in c)
                    _cargas.actualizarCargaATMOrdenRuta(carga);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaATMDatosVerificacion(CargaATM c)
        {

            try
            {
                _cargas.actualizarCargaATMDatosVerificacion(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void eliminarCargaATM(CargaATM c, Colaborador col)
        {

            try
            {
                _cargas.eliminarCargaATM(c, col);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Importar una lista de Cargas.
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarCargasATMs(BindingList<CargaATM> c)
        {
           

            try
            {

                foreach (CargaATM carga in c)
                {
                    CargaATM copia_carga = carga;

                    _cargas.agregarCargaATM(ref copia_carga);

                    foreach (CartuchoCargaATM cartucho in copia_carga.Cartuchos)
                    {
                        CartuchoCargaATM copia_cartucho = cartucho;

                        _cartuchos_cargas.agregarCartuchoCargaATM(ref copia_cartucho);
                    }

                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }



        /// <summary>
        /// Actualiza Ruta y horas programadas de las cargas
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarRutasCargasATMs(BindingList<CargaATM> c)
        {

            try
            {

                foreach (CargaATM carga in c)
                {
                    CargaATM copia_carga = carga;

                    _cargas.actualizarCargaATMRutaHoraImportacion(ref copia_carga);

                    
                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }

        /// <summary>
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaATM> listarCargasATMs(Colaborador c, ATM a, DateTime f, byte? r)
        {

            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCargasATMs(c, a, f, r);

                foreach (CargaATM carga in cargas)
                {
                    CargaATM copia = carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                    _cargas.obtenerDatosCargaATM(ref copia);
                    _cargas.obtenerDatosVerificacionCarga(ref copia);
                    
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaATM> listarCargasATMsCodigosCajeroAutomaticos(Colaborador c, ATM a, DateTime f, byte? r)
        {

            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCodigosCajeroCargasATMs(c, a, f, r);

                foreach (CargaATM carga in cargas)
                {
                    CargaATM copia = carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                    _cargas.obtenerDatosCargaATM(ref copia);
                    _cargas.obtenerDatosVerificacionCarga(ref copia);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Busca Solicitudes de Código de Apertura Pendientes
        /// </summary>
        /// <param name="f">Fecha de las Cargas de los ATM's</param>
        /// <returns></returns>
        public bool listarNotificacionApertura(DateTime f )
        {

            try
            {
                BindingList<int> cargas = _cargas.listarCodigosSolicitudApertura(f);

                if (cargas.Count > 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Busca Solicitudes de Código de Apertura Pendientes
        /// </summary>
        /// <param name="f">Fecha de las Cargas de los ATM's</param>
        /// <returns></returns>
        public bool listarNotificacionCierre(DateTime f)
        {

            try
            {
                BindingList<int> cargas = _cargas.listarCodigosSolicitudCierre(f);

                if (cargas.Count > 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Listar las Cargas registrados en el sistema para exportar en Excel.
        /// </summary>
        /// <returns>Lista de las cargas registrados en el sistema para exportar en Excel.</returns>
        public DataTable listarCargasATMsExportar(DateTime f)
        {

            try
            {
                DataTable atms = _cargas.listarCargasATMsExportacion(f);


                return atms;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        /// <param name="e">Empresa de Transporte a filtrar</param>
        public BindingList<CargaATM> listarCargasATMsEspeciales(Colaborador c, ATM a, DateTime f, byte? r, EmpresaTransporte e)
        {

            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCargasATMsEspeciales(c, a, f, r,e);

                foreach (CargaATM carga in cargas)
                {
                    CargaATM copia = carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                    _cargas.obtenerDatosCargaATM(ref copia);
                    _cargas.obtenerDatosVerificacionCarga(ref copia);
                } 

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        /// <param name="e">Empresa de Transporte a filtrar</param>
        public BindingList<CargaATM> listarCargasATMsEspecialesRoadnetExportacion(Colaborador c, ATM a, DateTime f, byte? r, EmpresaTransporte e)
        {

            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCargasATMsEspecialesExportacionRoadnet(c, a, f, r, e);

                foreach (CargaATM carga in cargas)
                {
                    CargaATM copia = carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                    _cargas.obtenerDatosCargaATM(ref copia);
                    _cargas.obtenerDatosVerificacionCarga(ref copia);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        /// <summary>
        /// Obtener una lista de las cargas de ATM's no asignadas en una fecha dada.
        /// </summary>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas no asignadas</returns>
        public BindingList<CargaATM> listarCargasATMs(DateTime f)
        {

            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCargasATMs(f);

                foreach (CargaATM carga in cargas)
                {
                    CargaATM copia = carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener las cargas asignadas un cajero de ATM's.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's</param>
        public BindingList<CargaATM> listarCargasATMsPorCajero(Colaborador c, bool a)
        {

            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCargasATMsPorCajero(c);

                foreach (CargaATM carga in cargas)
                {
                    CargaATM copia = carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, a);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas de un determinado ATM con determinados marchamos.
        /// </summary>
        /// <param name="a">ATM para el cual se genera la lista</param>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista de cargas que cumplen con los parámetros</returns>
        public BindingList<CargaATM> listarCargasATMsPorATMMarchamo(ATM a, string m)
        {

            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCargasATMsPorATMMarchamo(a, m);

                foreach (CargaATM carga in cargas)
                {
                    CargaATM copia = carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, false);
                    _cargas.obtenerDatosCargaATM(ref copia);
                    _cargas.obtenerDatosVerificacionCarga(ref copia);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas asignadas a una ruta en una fecha determinada.
        /// </summary>
        /// <param name="r">Número de ruta</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cargas que cumplen con los parámetros</returns>
        public BindingList<CargaATM> listarCargasATMsPorRuta(byte r, DateTime f)
        {

            try
            {
                return _cargas.listarCargasATMsPorRuta(r, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas del cierre de un cajero de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre del cajero de ATM's</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasATMsPorCierreATMs(CierreATMs c)
        {

            try
            {
                return _cargas.listarCargasATMsPorCierreATMs(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Lista todas las cargas de ATMs con un marchamo adicional igual
        /// </summary>
        /// <param name="marchamo_adicional">marchamo adicional para buscar la carga respectiva</param>
        /// <returns>una lista de cargas de ATM</returns>
        public BindingList<CargaATM> listarCargasATMsPorMarchamoAdicional(string marchamo_adicional, Colaborador registro, TipoEntregas tipo)
        {
            
            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCargasATMporMarchamoAdicional(marchamo_adicional);

                foreach (CargaATM carga in cargas)
                {
                   
                    CargaATM copia = carga;
                    copia.TipoEntregas = tipo;
                    copia.ColaboradorRecibidoBoveda = registro;
                    copia.HoraRecibidoBoveda = DateTime.Now;
                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                    _cargas.obtenerDatosCargaATM(ref copia);
                    _cargas.obtenerDatosVerificacionCarga(ref copia);
                    _cargas.agregarRecepcionTulaCargaATM(ref copia);

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista las cargas Totales de los ATMs
        /// </summary>
        /// <param name="a">ATM a buscar</param>
        /// <param name="fecha">Fecha a buscar</param>
        /// <param name="ruta">Ruta Especifica a buscar</param>
        /// <returns>Retorna un datatable con los datos de las cargas</returns>
          public BindingList<Carga> listarCargasTotales(ATM a, DateTime fecha, byte? ruta)
          {
              try
              {
                  return _cargas.listarCargasTotales(a, fecha, ruta);
              }
              catch (Excepcion ex)
              {
                  throw ex;
              }
          }




          /// <summary>
          /// Lista las cargas Totales de los ATMs
          /// </summary>
          /// <param name="a">ATM a buscar</param>
          /// <param name="fecha">Fecha a buscar</param>
          /// <param name="ruta">Ruta Especifica a buscar</param>
          /// <returns>Retorna un datatable con los datos de las cargas</returns>
          public BindingList<Carga> listarCargasTotalesControlHoja(ATM a, DateTime fecha, byte? ruta)
          {
              try
              {
                  return _cargas.listarCargasTotales(a, fecha, ruta);
              }
              catch (Excepcion ex)
              {
                  throw ex;
              }
          }


         
            


        /// <summary>
        /// Obtener una lista de las cargas con montos consolidados para su impresión.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="r">Número de ruta de las cargas que se listarán</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasATMsImpresionConsolidado(Colaborador c, byte? r, DateTime f)
        {

            try
            {
                return _cargas.listarCargasATMsImpresionConsolidado(c, r, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas con montos por denominación para su impresión.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="r">Número de ruta de las cargas que se listarán</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasATMsImpresionDetallado(Colaborador c, byte? r, DateTime f)
        {

            try
            {
                return _cargas.listarCargasATMsImpresionDetallado(c, r, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas con los datos de la hoja de ruta.
        /// </summary>
        /// <param name="r">Número de ruta de las cargas que se listarán</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasATMsImpresionHojaRuta(byte r, DateTime f)
        {

            try
            {
                return _cargas.listarCargasATMsImpresionHojaRuta(r, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas generadas o importadas en una fecha.
        /// </summary>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="e">Transportadora encargada de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasATMsImpresionGeneradasImportadas(DateTime f, EmpresaTransporte e)
        {

            try
            {
                return _cargas.listarCargasATMsImpresionGeneradasImportadas(f, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas de emergencia no utilizadas en una fecha específica.
        /// </summary>
        /// <param name="fecha">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cargas de emergencia no utilizadas</returns>
        public BindingList<CargaATM> listarCargasATMsEmergenciasNoUtilizadas(DateTime f)
        {

            try
            {
                BindingList<CargaATM> cargas = _cargas.listarCargasATMsEmergenciasNoUtilizadas(f);

                foreach (CargaATM carga in cargas)
                {
                    CargaATM copia = carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, false);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas para el libro mayor de una determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasATMsLibroMayor(DateTime f)
        {

            try
            {
                return _cargas.listarCargasATMsLibroMayor(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaSucursal> listarCargasSucursalesPorAprobar(Colaborador c, Sucursal s, DateTime f, byte? r)
        {

            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursalesPorAprobar(s, f, r);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;

                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, true);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Obtener una lista de las cargas para el libro mayor de una determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasATMsLibroMayorReporte(DateTime f)
        {

            try
            {
                return _cargas.listarCargasATMsLibroMayorReporte(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Obtener una lista de las descargas para el libro mayor de una determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Tabla con la lista de descargas</returns>
        public DataTable listarDescargasATMsLibroMayorReporte(DateTime f)
        {

            try
            {
                return _cargas.listarDescargasATMsLibroMayorReporte(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Autoasignar las cargas tomando en cuenta las rutas y los cajeros full.
        /// </summary>
        /// <param name="caj">Lista de cajeror a los cuales se asignarán la cargas</param>
        /// <param name="car">Lista de cargas que se asignarán</param>
        /// <returns>Lista de cajeros y sus respectivas cargas</returns>
        public Dictionary<Colaborador, List<CargaATM>> autoAsignarCargas(List<Colaborador> caj, BindingList<CargaATM> car)
        {
            Dictionary<Colaborador, List<CargaATM>> cargas_cajeros = new Dictionary<Colaborador, List<CargaATM>>();

            int[] fulls_cajeros = new int[caj.Count];

            int numero_cajero = 0;
            int numero_fulls_minimo = 0;

            foreach (Colaborador cajero in caj)
                cargas_cajeros.Add(cajero, new List<CargaATM>());

            while (car.Count > 0)
            {
                CargaATM carga = car[0];
                Colaborador cajero = caj[numero_cajero];
                List<CargaATM> cargas_cajero = cargas_cajeros[cajero];

                numero_fulls_minimo = fulls_cajeros[0];

                foreach (int numero_fulls in fulls_cajeros)
                    numero_fulls_minimo = Math.Min(numero_fulls_minimo, numero_fulls); 

                if (carga.ATM.Full)
                {
                    int fulls_cajero = fulls_cajeros[numero_cajero];

                    foreach (int numero_fulls in fulls_cajeros)
                        numero_fulls_minimo = Math.Min(numero_fulls_minimo, numero_fulls); 

                    if (fulls_cajero < numero_fulls_minimo + 1)
                    {
                        cargas_cajero.Add(carga);
                        car.RemoveAt(0);

                        fulls_cajeros[numero_cajero]++;
                    }
                    else
                    {
                        CargaATM carga_no_full = null;

                        foreach (CargaATM carga_libre in car)
                        {

                            if (!carga_libre.ATM.Full)
                            {
                                carga_no_full = carga_libre;
                                break;
                            }

                        }

                        if (carga_no_full != null)
                        {
                            cargas_cajero.Add(carga_no_full);
                            car.Remove(carga_no_full);
                        }

                    }

                }
                else
                {
                    cargas_cajero.Add(carga);
                    car.RemoveAt(0);
                }

                numero_cajero++;

                // Validar si se llego al último cajero

                if (numero_cajero == caj.Count) numero_cajero = 0;
            }

            return cargas_cajeros;
        }

        
        /// <summary>
        /// Actualiza la recepcion de tulas de una de las cargas de ATM
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Colaborador que registra la recepcion de la tula</param>
        /// <param name="fecha">Fecha que se da la recepcion</param>
        /// <param name="tipo">Tipo de Recibo o Entrega</param>
        public void actualizarDatosRecepcionCargaATM(Carga carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaATM copia = new CargaATM();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _cargas.agregarRecepcionTulaCargaATM(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Actualiza la recepcion de tulas de una de las cargas de ATM
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Colaborador que registra la recepcion de la tula</param>
        /// <param name="fecha">Fecha que se da la recepcion</param>
        /// <param name="tipo">Tipo de Recibo o Entrega</param>
        public void actualizarDatosEntregaCargaATM(Carga carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaATM copia = new CargaATM();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _cargas.agregarEntregaTulaCargaATM(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        
        /// <summary>
        /// Guarda los datos de las cargas ATM
        /// </summary>
        /// <param name="cargas">Lista de Cargas a exportar</param>
        public void guardarDatosATMINFO(BindingList<CargaATM> cargas, String tipo)
        {
            try
            {
                CargaATM carga = new CargaATM();
                carga = cargas[0];
                String archivo = @"\\10.120.131.100\Archivos ATM Info\" + carga.Fecha_asignada.Day.ToString("00") + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Year.ToString("0000") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".txt";
                String archivobackup = @"\\10.120.131.100\Archivos ATM Info\Backup\" + carga.Fecha_asignada.Day.ToString("00") + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Year.ToString("0000") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".txt";

                foreach (CargaATM c in cargas)
                {

                    if (c.ATM != null)
                    {



                        List<String> l = new List<string>();

                        foreach (CartuchoCargaATM car in c.Cartuchos)
                        {
                            l = new List<string>();

                            l.Add(c.ID.ToString());
                            if (c.ATM == null)
                            {
                                l.Add("");
                                l.Add("");
                            }
                            else
                            {
                                l.Add(c.ATM.Numero.ToString());
                                l.Add(c.ATM.Codigo);
                            }

                            int valor = Convert.ToInt32(car.Denominacion.Valor);
                            string monto = car.Denominacion.Valor.ToString("N0");
                            // monto.Replace(",", ".");
                            monto = monto.Replace(",", "");
                            monto = monto.Replace(".", "");
                            l.Add(car.Cantidad_carga.ToString());
                            l.Add(monto);
                            l.Add(car.Denominacion.Moneda.ToString());
                            l.Add(tipo);
                            l.Add(c.Transportadora.Nombre);

                            _manejador_texto.escribirArchivo(archivo, ',', l);
                            _manejador_texto.escribirArchivo(archivobackup, ',', l);

                        }
                    }

                }
            }
            catch (Excepcion ex)
            { 
            }
        }


        /// <summary>
        /// Actualiza los datos de una carga de la hoja de ruta
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la Carga</param>
        public void actualizarHorasHojaRuta(Carga carga)
        {
            try
            {
                _cargas.actualizarCargaATMHorasHojaRuta(carga);
            }
            catch (Excepcion ex)
            {
 
            }
        }


        /// <summary>
        /// Actualiza los datos de las descargas y el papel 
        /// </summary>
        /// <param name="parametro">Cantidad de fórmulas máximas a filtrar</param>
        public void actualizarCargasDescargasPapel(int parametro)
        {
            _cargas.actualizarVisitasDescargaPapel(parametro);
        }

        #endregion Cargas de ATM's

        #region Cargas de Emergencia de ATM's

        /// <summary>
        /// Registrar en el sistema la carga de emergencia de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga de emergencia</param>
        public void agregarCargaEmergenciaATM(ref CargaEmergenciaATM c)
        {

            try
            {
                _cargas_emergencia.agregarCargaEmergenciaATM(ref c);

                foreach (CargaATM emergencia in c.Emergencias)
                    _cargas.actualizarCargaATMCargaEmergenciaATM(emergencia, c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Acutalizar en el sistema la carga de emergencia de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga de emergencia</param>
        public void actualizarCargaEmergenciaATM(CargaEmergenciaATM c)
        {

            try
            {
                // Desligar las emergencias anteriores de la carga y registrar las nuevas

                CargaEmergenciaATM anterior = new CargaEmergenciaATM(id: c.ID);

                _cargas_emergencia.obtenerEmergenciasCargaEmergenciaATM(ref anterior);

                foreach (CargaATM emergencia in c.Emergencias)
                {

                    if (anterior.Emergencias.Contains(emergencia))
                        anterior.quitarEmergencia(emergencia);
                    else
                        _cargas.actualizarCargaATMCargaEmergenciaATM(emergencia, c);

                }

                foreach (CargaATM emergencia in anterior.Emergencias)
                    _cargas.actualizarCargaATMCargaEmergenciaATM(emergencia, null);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de emergencia de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga</param>
        public void eliminarCargaEmergenciaATM(CargaEmergenciaATM c)
        {

            try
            {
                _cargas_emergencia.eliminarCargaEmergenciaATM(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las cargas de emergencia por fecha.
        /// </summary>
        /// <param name="f">Fecha de las cargas que se listarán</param>
        public BindingList<CargaEmergenciaATM> listarCargasEmergenciaATMs(DateTime f)
        {

            try
            {
                BindingList<CargaEmergenciaATM> cargas = _cargas_emergencia.listarCargasEmergenciaATMs(f);

                foreach (CargaEmergenciaATM carga in cargas)
                {
                    CargaEmergenciaATM copia_carga = carga;

                    _cargas_emergencia.obtenerEmergenciasCargaEmergenciaATM(ref copia_carga);

                    foreach (CargaATM emergencia in copia_carga.Emergencias)
                    {
                        CargaATM copia_emegencia = emergencia;

                        _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_emegencia, false);

                        copia_emegencia.recalcularMontosCarga();
                    }

                    copia_carga.reasignarEmergencias();
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cargas de Emergencia de ATM's

        #region Cargas de Emerencias de ATM's Full

        /// <summary>
        /// Registrar en el sistema la carga de emergencia de un ATM Full.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATMFull con los datos de la carga de emergencia</param>
        public void agregarCargaEmergenciaATMFull(ref CargaEmergenciaATMFull c)
        {

            try
            {
                _cargas_emergencia_full.agregarCargaEmergenciaATMFull(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar en el sistema la carga de emergencia de un ATM Full.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATMFull con los datos de la carga de emergencia</param>
        public void actualizarCargaEmergenciaATMFull(CargaEmergenciaATMFull c)
        {

            try
            {
                _cargas_emergencia_full.actualizarCargaEmergenciaATMFull(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las cargas de emergencia  de ATM's Full por fecha.
        /// </summary>
        /// <param name="f">Fecha de las cargas que se listarán</param>
        public BindingList<CargaEmergenciaATMFull> listarCargasEmergenciaATMsFull(DateTime f)
        {

            try
            {
                return _cargas_emergencia_full.listarCargasEmergenciaATMsFull(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cargas de Emerencias de ATM's Full

        #region Cartuchos de Cargas de ATM's

        /// <summary>
        /// Actualizar los datos del cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void actualizarCartuchoCargaATM(CartuchoCargaATM c, Colaborador usuario)
        {

            try
            {
                _cartuchos_cargas.actualizarCartuchoCargaATM(c);

                if (c.Cartucho != null)
                {
                    if (c.Cartucho.Estado == EstadosCartuchos.Bueno)
                    {
                        Cartucho cartucho = c.Cartucho;

                        if (cartucho.ID_Invalido)
                        {
                            _cartuchos.agregarCartucho(ref cartucho);
                        }
                        else
                        {
                            _cartuchos.actualizarCartucho(cartucho);
                            _cartuchos.actualizarCartuchoEstado(cartucho, usuario);
                        }

                        _cartuchos_cargas.actualizarCartuchoCargaATMCartucho(c);
                    }
                    else
                    {
                        Mensaje.mostrarMensaje("MensajeCartuchoMaloCierreATM");
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar la cantidad de fórmulas descargadas de un cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void actualizarCartuchoCargaATMCantidadDescarga(CartuchoCargaATM c)
        {

            try
            {
                _cartuchos_cargas.actualizarCartuchoCargaATMCantidadDescarga(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar la cantidad de formulas cargadas del cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void actualizarCartuchoCargaATMCantidad(CartuchoCargaATM c)
        {

            try
            {
                _cartuchos_cargas.actualizarCartuchoCargaATMCantidad(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cartuchos de Cargas de ATM's

        #region Descargas

        /// <summary>
        /// Registrar en el sistema la descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos de la carga/param>
        public void agregarDescargaATM(ref DescargaATM d)
        {

            try
            {
                BindingList<Denominacion> denominaciones = _denominaciones.listarDenominacionesCargasATMs();

                _descargas.agregarDescargaATM(ref d);

                d.crearContadores(denominaciones);
                d.crearRechazos(denominaciones);

                foreach (RechazoDescargaATM rechazo in d.Rechazos)
                {
                    RechazoDescargaATM copia = rechazo;                  

                    bool bolsa = true;
                    _rechazos.agregarRechazoDescargaATM(ref copia, d, bolsa);

                    bolsa = false;

                    _rechazos.agregarRechazoDescargaATM(ref copia, d, bolsa);
                }

                //_rechazos.obtenerRechazosDescargaATM(ref d);

                foreach (ContadorDescargaATM contador in d.Contadores)
                {

                    /// Generar método de consulta de Web Service.... Vas a preguntar. por fecha, ATM, y denominación. 
                    /// Agregar a los atributos de contador. 

                    ContadorDescargaATM copia = contador;
                   

                    _contadores.agregarContadorDescargaATM(ref copia, d);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de la descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos de la carga</param>
        public void actualizarDescargaATM(DescargaATM d)
        {

            try
            {
                _descargas.actualizarDescargaATM(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una descarga de un ATM.
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos de la descarga</param>
        public void eliminarDescargaATM(DescargaATM d)
        {

            try
            {
                _descargas.eliminarDescargaATM(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las descargas por fecha, cajero, ruta y ATM.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="r">Ruta de las descargas que se listarán</param>
        /// <param name="f">Fecha de procesamiento de las descargas que se listarán</param>
        /// <returns>Lista de descargas que cumplen con los parámetros</returns>
        public BindingList<DescargaATM> listarDescargasATMs(Colaborador c, ATM a, DateTime f, byte? r)
        {

            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMs(c, a, f, r);

                foreach (DescargaATM descarga in descargas)
                {
                    DescargaATM copia_descarga = descarga;
                    CargaATM copia_carga = copia_descarga.Carga;
                    CargaEmergenciaATM copia_carga_emergencia = copia_descarga.Carga_emergencia;

                    if (copia_carga != null)
                    {
                        _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_carga, false);
                        _cargas.obtenerDatosCargaATM(ref copia_carga);
                        descarga.reasignarCarga();
                    }

                    if (copia_carga_emergencia != null)
                    {
                        _cargas_emergencia.obtenerEmergenciasCargaEmergenciaATM(ref copia_carga_emergencia);

                        foreach (CargaATM emergencia in copia_carga_emergencia.Emergencias)
                        {
                            CargaATM copia_emergencia = emergencia;

                            _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_emergencia, false);

                            copia_emergencia.recalcularMontosCarga();
                        }

                        copia_carga_emergencia.reasignarEmergencias();
                        descarga.reasignarCargaEmergencia();
                    }

                    _rechazos.obtenerRechazosDescargaATM(ref copia_descarga);
                    _contadores.obtenerContadoresDescargaATM(ref copia_descarga);
                    _descargas.obtenerDatosDescargaATM(ref copia_descarga);

                    descarga.recalcularMontosDescarga();
                    descarga.recalcularDetalles();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas pendientes.
        /// </summary>
        /// <returns>Lista de descargas no descargadas</returns>
        public BindingList<DescargaATM> listarDescargasATMsPendientes()
        {

            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMsPendientes();

                foreach (DescargaATM descarga in descargas)
                {
                    CargaATM carga = descarga.Carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref carga, false);

                    descarga.reasignarCarga();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas pendientes con determinado marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsPendientesPorMarchamo(string m)
        {

            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMsPendientesPorMarchamo(m);

                foreach (DescargaATM descarga in descargas)
                {
                    CargaATM carga = descarga.Carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref carga, false);

                    descarga.reasignarCarga();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas emergencia pendientes.
        /// </summary>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsEmergenciaPendientes()
        {

            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMsEmergenciaPendientes();

                foreach (DescargaATM descarga in descargas)
                {
                    CargaEmergenciaATM carga = descarga.Carga_emergencia;

                    _cargas_emergencia.obtenerEmergenciasCargaEmergenciaATM(ref carga);

                    foreach (CargaATM emergencia in carga.Emergencias)
                    {
                        CargaATM copia_emegencia = emergencia;

                        _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_emegencia, false);

                        copia_emegencia.recalcularMontosCarga();
                    }

                    carga.reasignarEmergencias();
                    descarga.reasignarCargaEmergencia();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas de emergencia pendientes.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsEmergenciaPendientesPorMarchamo(string m)
        {
            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMsEmergenciaPendientesPorMarchamo(m);

                foreach (DescargaATM descarga in descargas)
                {
                    CargaEmergenciaATM carga = descarga.Carga_emergencia;

                    _cargas_emergencia.obtenerEmergenciasCargaEmergenciaATM(ref carga);

                    foreach (CargaATM emergencia in carga.Emergencias)
                    {
                        CargaATM copia_emegencia = emergencia;

                        _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_emegencia, false);

                        copia_emegencia.recalcularMontosCarga();
                    }

                    carga.reasignarEmergencias();
                    descarga.reasignarCargaEmergencia();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        ///////////////////////////////////////////////////DESCARGAS COMPLETAS ////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Obtener una lista de las descargas pendientes.
        /// </summary>
        /// <returns>Lista de descargas no descargadas</returns>
        public BindingList<DescargaATM> listarDescargasATMsPendientesCompletas()
        {

            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMsPendientesCompletas();

                foreach (DescargaATM descarga in descargas)
                {
                    CargaATM carga = descarga.Carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref carga, false);

                    descarga.reasignarCarga();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas pendientes con determinado marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsPendientesPorMarchamoCompletas(string m)
        {

            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMsPendientesPorMarchamoCompletas(m);

                foreach (DescargaATM descarga in descargas)
                {
                    CargaATM carga = descarga.Carga;

                    _cartuchos_cargas.obtenerCartuchosCargaATM(ref carga, false);

                    descarga.reasignarCarga();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas emergencia pendientes.
        /// </summary>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsEmergenciaPendientesCompletas()
        {

            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMsEmergenciaPendientesCompletas();

                foreach (DescargaATM descarga in descargas)
                {
                    CargaEmergenciaATM carga = descarga.Carga_emergencia;

                    _cargas_emergencia.obtenerEmergenciasCargaEmergenciaATM(ref carga);

                    foreach (CargaATM emergencia in carga.Emergencias)
                    {
                        CargaATM copia_emegencia = emergencia;

                        _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_emegencia, false);

                        copia_emegencia.recalcularMontosCarga();
                    }

                    carga.reasignarEmergencias();
                    descarga.reasignarCargaEmergencia();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas de emergencia pendientes.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista descargas pendientes</returns>
        public BindingList<DescargaATM> listarDescargasATMsEmergenciaPendientesPorMarchamoCompletas(string m)
        {
            try
            {
                BindingList<DescargaATM> descargas = _descargas.listarDescargasATMsEmergenciaPendientesPorMarchamoCompletas(m);

                foreach (DescargaATM descarga in descargas)
                {
                    CargaEmergenciaATM carga = descarga.Carga_emergencia;

                    _cargas_emergencia.obtenerEmergenciasCargaEmergenciaATM(ref carga);

                    foreach (CargaATM emergencia in carga.Emergencias)
                    {
                        CargaATM copia_emegencia = emergencia;

                        _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia_emegencia, false);

                        copia_emegencia.recalcularMontosCarga();
                    }

                    carga.reasignarEmergencias();
                    descarga.reasignarCargaEmergencia();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /////////////////////////////////////////////////////////////////////////////DEVOLUCIONES/////////////////////////////////////////////////////////////

        /// <summary>
        /// Devuelve una carga de ATM
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos del ATM</param>
        public void actualizarCargaDevolucion (DescargaATM d)
        {
            try
            {
                _descargas.actualizarDevoluciones(ref d);
            }
            catch(Excepcion ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Devuelve una carga de ATM
        /// </summary>
        /// <param name="d">Objeto DescargaATM con los datos del ATM</param>
        private void actualizarCargaFullDevolucion(DescargaATM d)
        {
            try
            {
                _descargas.actualizarDevoluciones(ref d);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }


        /////////////////////////////////////////////////////////////////////////////CIERRES////////////////////////////////////////////////////////////////





        /// <summary>
        /// Obtener una lista de las descargas del cierre de un cajero de ATM's.
        /// </summary>
        /// <param name="c">Objeto CierreATMs con los datos del cierre del cajero de ATM's</param>
        /// <returns>Tabla con la lista de descargas</returns>
        public DataTable listarDescargasATMsPorCierreATMs(CierreATMs c)
        {

            try
            {
                return _descargas.listarDescargasATMsPorCierreATMs(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas para el libro mayor de una determinada fecha.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Tabla con la lista de descargas</returns>
        public DataTable listarDescargasATMsLibroMayor(DateTime f)
        {

            try
            {
                return _descargas.listarDescargasATMsLibroMayor(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Descargas

        #region Rechazos de Descargas de ATM's

        /// <summary>
        /// Actualizar la cantidad de fórmulas descargadas de un rechazo de una descarga.
        /// </summary>
        /// <param name="r">Objeto RechazoDescargaATM con los datos del rechazo</param>
        public void actualizarRechazoDescargaATM(RechazoDescargaATM r)
        {

            try
            {
                _rechazos.actualizarRechazoDescargaATM(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Rechazos de Descargas de ATM's

        #region Contadores de Descargas de ATM's

        /// <summary>
        /// Actualizar la cantidad de fórmulas dipensadas y remanentes de un contador de una descarga.
        /// </summary>
        /// <param name="c">Objeto RechazoDescargaATM con los datos del rechazo</param>
        public void actualizarContadorDescargaATM(ContadorDescargaATM c)
        {

            try
            {
                _contadores.actualizarContadorDescargaATM(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Contadores de Descargas de ATM's

        #region Descargas Full

        /// <summary>
        /// Registrar en el sistema la descarga de un ATM Full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull con los datos de la descarga</param>
        public void agregarDescargaATMFull(ref DescargaATMFull d)
        {

            try
            {
                BindingList<Denominacion> denominaciones = _denominaciones.listarDenominaciones();

                _descargas_full.agregarDescargaATMFull(ref d);

                d.crearMontos(denominaciones);
                d.crearContadores(denominaciones);

                foreach (MontoDescargaATMFull monto in d.Montos)
                {
                    MontoDescargaATMFull copia = monto;

                    _montos_descargas_full.agregarMontoDescargaATMFull(ref copia, d);
                }

                foreach (ContadorDescargaATMFull contador in d.Contadores)
                {
                    ContadorDescargaATMFull copia = contador;

                    _contadores_full.agregarContadorDescargaATMFull(ref copia, d);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de la descarga de un ATM Full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull con los datos de la descarga</param>
        public void actualizarDescargaATMFull(DescargaATMFull d)
        {

            try
            {
                _descargas_full.actualizarDescargaATMFull(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una descarga de un ATM Full.
        /// </summary>
        /// <param name="d">Objeto DescargaATMFull con los datos de la descarga</param>
        public void eliminarDescargaATMFull(DescargaATMFull d)
        {

            try
            {
                _descargas_full.eliminarDescargaATMFull(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las descargas full por fecha, cajero y ATM.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de procesamiento de las descargas que se listarán</param>
        /// <returns>Lista de descargas full que cumplen con los parámetros</returns>
        public BindingList<DescargaATMFull> listarDescargasATMsFull(Colaborador c, ATM a, DateTime f)
        {

            try
            {
                BindingList<DescargaATMFull> descargas = _descargas_full.listarDescargasATMsFull(c, a, f);

                foreach (DescargaATMFull descarga in descargas)
                {
                    DescargaATMFull copia_descarga = descarga;

                    _montos_descargas_full.obtenerMontosDescargaATMFull(ref copia_descarga);
                    _contadores_full.obtenerContadoresDescargaATMFull(ref copia_descarga);
                    _descargas_full.obtenerDatosDescargaATMFull(ref copia_descarga);

                    descarga.recalcularMontosDescarga();
                    descarga.recalcularDetalles();
                }

                return descargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas full pendientes.
        /// </summary>
        /// <returns>Lista de descargas full no descargadas</returns>
        public BindingList<DescargaATMFull> listarDescargasATMsFullPendientes()
        {

            try
            {
                return _descargas_full.listarDescargasATMsFullPendientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas full pendientes con determinado marchamo.
        /// </summary>
        /// <param name="m">Número de marchamo buscado</param>
        /// <returns>Lista de descargas full pendientes</returns>
        public BindingList<DescargaATMFull> listarDescargasATMsFullPendientesPorMarchamo(string m)
        {

            try
            {
                return _descargas_full.listarDescargasATMsFullPendientesPorMarchamo(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las descargas de cargas de emergencia de ATM's Full pendientes.
        /// </summary>
        /// <returns>Lista de descargas pendientes</returns>
        public BindingList<DescargaATMFull> listarDescargasATMsFullEmergenciaPendientes()
        {

            try
            {
                return _descargas_full.listarDescargasATMsFullEmergenciaPendientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Descargas Full

        #region Montos de Descargas de ATM's Full

        /// <summary>
        /// Actualizar la cantidad de fórmulas de un monto de una descarga full.
        /// </summary>
        /// <param name="m">Objeto MontoDescargaATMFull con los datos del monto</param>
        public void actualizarMontoDescargaATMFull(MontoDescargaATMFull m)
        {

            try
            {
                _montos_descargas_full.actualizarMontoDescargaATMFull(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Montos de Descargas de ATM's Full

        #region Contadores de Descargas de ATM's Full

        /// <summary>
        /// Actualizar la cantidad de fórmulas depositadas de un contador de una descarga full.
        /// </summary>
        /// <param name="c">Objeto ContadorDescargaATMFull con los datos del contador</param>
        public void actualizarContadorDescargaATMFull(ContadorDescargaATMFull c)
        {

            try
            {
                _contadores_full.actualizarContadorDescargaATMFull(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Contadores de Descargas de ATM's Full

        #region Montos Remanentes de ATM's

        /// <summary>
        /// Obtener una lista de los montos remanentes por denominacion de uno o varios ATM's en una fecha.
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los remanentes</param>
        /// <param name="f">Fecha para la generación de la lista</param>
        /// <param name="t">Transportadora encargada de los ATM's</param>
        /// <param name="c">Valor que indica si solo se listarán los ATM's que tienen una carga programada</param>
        /// <param name="c">Valor que indica si solo se listarán los ATM's que ya fueron cargados</param>
        /// <returns>Lista con los montos remanentes por denominación de los ATM's en las fecha especificada</returns>
        public DataTable listarRegistrosRemanentesATMsPorDenominacion(ATM a, DateTime f, EmpresaTransporte t, bool p, bool c)
        {

            try
            {
                return _registros_remanentes_atms.listarRegistrosRemanentesATMsPorDenominacion(a, f, t, p, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Obtener una remota
        /// </summary>
        /// <param name="monto"></param>
        public void ImportarDatosRegistroCargasEmergencia(ArrayList r, DateTime f)
        {
            try
            {

                foreach (MontoRemanenteATM registro in r)
                {
                    MontoRemanenteATM copia = registro;

                    if (!_registros_rementes_atms_completos.verificarRegistroCargasEmergencia(ref copia,f))
                    {


                        MontoRemanenteATM anterior = new MontoRemanenteATM(id: copia.ID);



                        _registros_rementes_atms_completos.agregarRegistroCargasdeEmergencia(ref copia);


                    }
                    else
                    {
                        _registros_rementes_atms_completos.actualizarRegistroCargasEmergencia(copia);

                    }

                }

            }
            catch (Excepcion ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorRegistrosMontosRemanentesImportacion");
            }
        }

        #region Cargas Emergencia ATM's

        /// <summary>
        /// Obtener una lista de los ATM que requieren una carga de emergencia 
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los remanentes</param>
        /// <param name="f">Fecha para la generación de la lista</param>
        /// <param name="t">Transportadora con la cual se obtiene la lista</param>
        /// <returns>Lista con las cargas de emergencia de los ATM's en las fecha especificada</returns>
        public DataTable listarCargasEmergencia(ATM a, DateTime f, EmpresaTransporte t)
        {

            try
            {
                return _registros_remanentes_atms.listarCargasEmergencia(a, f,t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Obtener una lista de los registros de los  ATM que requieren una carga de emergencia 
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los remanentes</param>
        /// <param name="f">Fecha para la generación de la lista</param>
        /// <param name="t">Transportadora para la generacion de la lista</param>
        /// <param name="m">Monto maximo a filtrar las cargas</param>
        /// <returns>Lista con los montos remanentes por denominación de los ATM's en las fecha especificada</returns>
        public DataTable listarRegistrosCargasEmergenciaCompleto(ATM a, DateTime f, EmpresaTransporte t, Decimal m)
        {

            try
            {
                return _registros_remanentes_atms.listarRegistroCargasEmergenciaCompleto(a, f, t,m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Obtener una lista de los registros de los  ATM que requieren una carga de emergencia 
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los remanentes</param>
        /// <param name="f">Fecha para la generación de la lista</param>
        /// <param name="t">Transportadora para la generacion de la lista</param>
        /// <param name="m">Monto maximo a filtrar las cargas</param>
        /// <returns>Lista con los montos remanentes por denominación de los ATM's en las fecha especificada</returns>
        public DataTable listarRegistrosCargasEmergencia(ATM a, DateTime f, EmpresaTransporte t, Decimal m, Boolean v)
        {

            try
            {
                return _registros_remanentes_atms.listarRegistroCargasEmergencia(a, f, t, m,v);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Cargas Emergencia ATM's

        /// <summary>
        /// Obtener una lista de los montos remanentes de uno o varios ATM's entre dos fechas.
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los remanentes</param>
        /// <param name="i">Fecha inicial para la generación de la lista</param>
        /// <param name="f">Fecha final para la generación de la lista</param>
        /// <returns>Lista con los montos remanentes de los ATM's entre las fechas especificadas</returns>
        public DataTable listarRegistrosRemanentesATMs(ATM a, DateTime i, DateTime f)
        {

            try
            {
                return _registros_remanentes_atms.listarRegistrosRemanentesATMs(a, i, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de los montos remanentes desde el AS400.
        /// </summary>
        /// <returns>Tabla con la lista de montos remanentes</returns>
        public DataTable listarRemanentesAS400()
        {

            try
            {
                return _registros_remanentes_atms.listarRemanentesAS400();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable listarRemanentesATMsCompletos()
        {

            try
            {
                return _registros_remanentes_atms.listarRegistrosRemanentesATMsCompletos();

               // return _registros_rementes_atms_completos.listarRegistrosRemanentesATMsCompletos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Importar los registros de montos remanentes de los ATM's.
        /// </summary>
        /// <param name="r">Lista de registros de montos remanentes a importar</param>
        public void importarRegistrosRemanentesATMs(BindingList<RegistroRemanentesATM> r)
        {

            try
            {

                foreach (RegistroRemanentesATM registro in r)
                {
                    RegistroRemanentesATM copia = registro;

                    if (_registros_remanentes_atms.verificarRegistroRemanentesATM(ref copia))
                    {
                        if (copia.Cargado) continue;

                        RegistroRemanentesATM anterior = new RegistroRemanentesATM(id: copia.ID);

                        _registros_remanentes_atms.obtenerMontosRegistroRemanentesATM(ref anterior);

                        if (copia.Monto_remanente_colones > anterior.Monto_remanente_colones ||
                            copia.Monto_remanente_dolares > anterior.Monto_remanente_dolares)
                        {
                            copia.Cargado = true;

                            _registros_remanentes_atms.actualizarRegistroRemanentesATM(copia);
                        }
                        else
                        {

                            foreach (MontoRemanenteATM monto in copia.Montos)
                            {
                                byte posicion = monto.Posicion;

                                MontoRemanenteATM monto_anterior = anterior.obtenerMontoPosicion(posicion);

                                if (monto_anterior == null || monto.Cantidad > monto_anterior.Cantidad)
                                {
                                    copia.Cargado = true;

                                    _registros_remanentes_atms.actualizarRegistroRemanentesATM(copia);
                                }
                                else 
                                {
                                    _registros_remanentes_atms.actualizarMontoRemanenteATM(monto);
                                }

                            }

                        }

                    }
                    else
                    {
                        _registros_remanentes_atms.agregarRegistroRemanentesATM(ref copia);

                        foreach (MontoRemanenteATM monto in registro.Montos)
                            _registros_remanentes_atms.agregarMontoRemanenteATM(monto, registro);

                    }

                }

            }
            catch (Excepcion ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorRegistrosMontosRemanentesImportacion");
            }

        }



        /// <summary>
        /// Importar los registros de montos remanentes de los ATM's necesarios para calcular las cargas de emergencia.
        /// </summary>
        /// <param name="r">Lista de montos remanentes a importar</param>
        public void importarRegistrosRemanentesATMsCompletos(BindingList<MontoRemanenteATM> r)
        {

            try
            {

                foreach (MontoRemanenteATM registro in r)
                {
                    MontoRemanenteATM copia = registro;

                    if (!_registros_rementes_atms_completos.verificarRegistroRemanentesATMCompletos(ref copia))
                    {


                        MontoRemanenteATM anterior = new MontoRemanenteATM(id: copia.ID);

                     

                            _registros_rementes_atms_completos.agregarRegistroRemanentesATMCompletos(ref copia);
                       

                    }
                    else
                    {
                        _registros_rementes_atms_completos.actualizarRegistroRemanentesATMCompleto(copia);

                    }

                }

            }
            catch (Excepcion ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorRegistrosMontosRemanentesImportacion");
            }
        }

        #endregion Montos Remanentes de ATM's

        #region Triales de Descargas de ATM's

        /// <summary>
        /// Importar los triales de descargas de los ATM's.
        /// </summary>
        /// <param name="t">Lista de triales a importar</param>
        public void importarTrialesDescargasATMs(BindingList<TrialDescargaATM> t)
        {

            try
            {

                foreach (TrialDescargaATM trial in t)
                {
                    TrialDescargaATM copia = trial;

                    if (_triales.verificarTrialDescargaATM(ref copia))
                        _triales.actualizarTrialDescargaATM(copia);
                    else
                        _triales.agregarTrialDescargaATM(ref copia);

                }

            }
            catch (Excepcion ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorTrialesImportacion");
            }

        }

        /// <summary>
        /// Obtener una lista de los triales de descargas para una fecha específica.
        /// </summary>
        /// <param name="fe">Fecha para la cual se genera la lista</param>
        /// <param name="fu">Valor que indica si se listarán los triales de las descargas full</param>
        /// <returns>Lista de triales de la fecha especificada</returns>
        public BindingList<TrialDescargaATM> listarTrialesDescargasATMs(DateTime fe, bool fu)
        {

            try
            {
                return _triales.listarTrialesDescargasATMs(fe, fu);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Triales de Descargas de ATM's

        #region Montos Esperados Retirados

        /// <summary>
        /// Registrar los montos esperados en retiros de un ATM en el sistema.
        /// </summary>
        /// <param name="m">Objeto MontosRetirosATM con los montos esperados</param>
        public void agregarMontosRetirosATM(ref MontosRetirosATM m)
        {

            try
            {
                if (_montos_retiros.verificarMontosRetirosATM(ref m))
                    throw new Excepcion("ErrorMontosRetirosATMDuplicados");

                _montos_retiros.agregarMontosRetirosATM(ref m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los montos esperados en retiros de un ATM en el sistema.
        /// </summary>
        /// <param name="m">Objeto MontosRetirosATM con los montos esperados</param>
        public void actualizarMontosRetirosATM(MontosRetirosATM m)
        {

            try
            {
                _montos_retiros.actualizarMontosRetirosATM(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Importar los monto de retiros de los ATM's.
        /// </summary>
        /// <param name="m">Lista de montos esperados de retiros a importar</param>
        public void importarMontosEsperadosRetiros(BindingList<MontosRetirosATM> m)
        {

            try
            {

                foreach (MontosRetirosATM monto in m)
                {
                    MontosRetirosATM copia = monto;

                    if (_montos_retiros.verificarMontosRetirosATM(ref copia))
                        _montos_retiros.actualizarMontosRetirosATM(copia);
                    else
                        _montos_retiros.agregarMontosRetirosATM(ref copia);

                }

            }
            catch (Excepcion ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorMontosRetirosImportacion");
            }

        }

        /// <summary>
        /// Obtener una lista de todos los ATM's con sus respectivos montos esperados de retiros para una moneda específica.
        /// </summary>
        /// <param name="m">Moneda para la cual se genera la lista</param>
        /// <returns>Lista de los ATM's y sus respectivos montos</returns>
        public BindingList<MontosRetirosATM> listarMontosRetirosATMs(Monedas m)
        {

            try
            {
                return _montos_retiros.listarMontosRetirosATMs(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Montos Esperados Retirados

        #region Denominaciones Cierres

        /// <summary>
        /// Agregar un registro de los montos por denominación del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los montos por denominacion</param>
        public void agregarRegistroDenominacionesCierre(ref RegistroDenominacionesCierre c)
        {

            try
            {
                _denominaciones_cierres.agregarRegistroDenominacionesCierre(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Agregar un corte de los montos por denominación del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los montos por denominacion</param>
        public void agregarCorteRegistroDenominacionesCierre(RegistroDenominacionesCierre r)
        {

            try
            {
                _denominaciones_cierres.agregarCorteRegistroDenominacionesCierre(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los gastos del registro de los montos por denominación del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los montos a actualizar</param>
        public void actualizarRegistroDenominacionesCierre(RegistroDenominacionesCierre r)
        {

            try
            {
                _denominaciones_cierres.actualizarRegistroDenominacionesCierre(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un registro de montos por denominación del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los datos del registro a eliminar</param>
        public void eliminarRegistroDenominacionesCierre(RegistroDenominacionesCierre r)
        {

            try
            {
                _denominaciones_cierres.eliminarRegistroDenominacionesCierre(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Obtener los montos de las denominaciones del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los datos del cierre</param>
        public void obtenerDatosRegistroDenominacionesCierre(ref RegistroDenominacionesCierre r)
        {

            try
            {
                _denominaciones_cierres.obtenerDatosRegistroDenominacionesCierre(ref r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Denominaciones Cierres

        #region Colas de Cierre

        /// <summary>
        /// Obtener los saldos de los cierres en una fecha específica.
        /// </summary>
        /// <param name="f">Fecha para la cual se obtendrán los saldos</param>
        /// <returns>Lista de saldos(colas)</returns>
        public BindingList<ColaCierre> listarSaldosCierre(DateTime f)
        {

            try
            {
                return _colas.listarSaldosCierre(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Colas de Cierre

        #region Inconsistencias en Manifiestos del CEF

        /// <summary>
        /// Registrar una inconsistencia de un manifiesto del CEF en el sistema.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaManifiestoCEF con los datos de la inconsistencia</param>
        public void agregarInconsistenciaManifiestoCEF(ref InconsistenciaManifiestoCEF i)
        {

            try
            {
                Colaborador coordinador = i.Manifiesto.Coordinador;

                _inconsistencias_manifiestos_cef.agregarInconsistencia(ref i);

                _manifiestos_cef.actualizarManifiestoCEF(i.Manifiesto, coordinador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una inconsistencia de un manifiesto del CEF.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaManifiestoCEF con los datos de la inconsistencia</param>
        public void actualizarInconsistenciaManifiestoCEF(InconsistenciaManifiestoCEF i)
        {

            try
            {
                Colaborador coordinador = i.Manifiesto.Coordinador;

                _inconsistencias_manifiestos_cef.actualizarInconsistencia(i);

                _manifiestos_cef.actualizarManifiestoCEF(i.Manifiesto, coordinador);
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una inconsistencia de un manifiesto del CEF.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaManifiestoCEF con los datos de la inconsistencia</param>
        public void eliminarInconsistenciaManifiestoCEF(InconsistenciaManifiestoCEF i)
        {

            try
            {
                _inconsistencias_manifiestos_cef.eliminarInconsistencia(i);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Listar las inconsistencias de manifiestos del CEF.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de las inconsistencias registrados en el periodo de tiempo indicado</returns>
        public BindingList<InconsistenciaManifiestoCEF> listarInconsistenciasManifiestosCEF(DateTime i, DateTime f)
        {

            try
            {
                BindingList<InconsistenciaManifiestoCEF> inconsistencias =
                    _inconsistencias_manifiestos_cef.listarInconsistencias(i, f);

                foreach (InconsistenciaManifiestoCEF inconsistencia in inconsistencias)
                {
                    InconsistenciaManifiestoCEF copia = inconsistencia;
                    ManifiestoCEF manifiesto = inconsistencia.Manifiesto;

                    _manifiestos_cef.obtenerDatosManifiestoCEF(ref manifiesto);
                }

                return inconsistencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Inconsistencias en Manifiestosdel CEF

        #region Inconsistencias en Depositos Causadas por Clientes

        /// <summary>
        /// Registrar una inconsistencia en un deposito.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDeposito con los datos de la inconsistencia</param>
        public void agregarInconsistenciaDeposito(ref InconsistenciaDeposito i)
        {

            try
            {
                _inconsistencias_depositos.agregarInconsistencia(ref i);
                
                //Agregar el manifiesto segregado

                if (i.Segregado != null)
                {
                    _inconsistencias_depositos.agregarSegregadoInconsistencia(i);
                    _segregados.actualizarSegregadoDatos(i.Segregado);
                }
                else
                {
                    _manifiestos_cef.actualizarManifiestoCEFDatos(i.Manifiesto);
                }

                //Registrar los valores ligados a la inconsistencia

                foreach (Valor valor in i.Valores)
                {
                    Valor copia = valor;

                    _valores.agregarValor(ref copia, i);
                }

                //Registrar los sobres ligados a la inconsistencia

                foreach (Sobre sobre in i.Sobres)
                {
                    Sobre copia = sobre;

                    _sobres.agregarSobre(ref copia, i);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una inconsistencia en un deposito.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDeposito con los datos de la inconsistencia</param>
        public void actualizarInconsistenciaDeposito(InconsistenciaDeposito i)
        {

            try
            {
                _inconsistencias_depositos.actualizarInconsistencia(i);

                //Actualizar el manifiesto segregado

                if (i.Segregado != null)
                {
                    _inconsistencias_depositos.agregarSegregadoInconsistencia(i);
                    _segregados.actualizarSegregadoDatos(i.Segregado);
                }
                else
                {
                    _inconsistencias_depositos.eliminarManifiestoSegregadoInconsistencia(i);
                    _manifiestos_cef.actualizarManifiestoCEFDatos(i.Manifiesto);
                }

                // Actualizar los valores ligados a la inconsistencia

                InconsistenciaDeposito anterior = new InconsistenciaDeposito(i.Id);

                _valores.obtenerValoresInconsistencia(ref anterior);

                foreach (Valor valor in i.Valores)
                {
                    Valor copia = valor;

                    if (anterior.Valores.Contains(valor))
                        anterior.quitarValor(valor);
                    else
                        _valores.agregarValor(ref copia, i);

                }

                foreach (Valor valor in anterior.Valores)
                    _valores.eliminaValor(valor);

                // Actualizar los sobres ligados a la inconsistencia

                _sobres.obtenerSobresInconsistencia(ref anterior);

                foreach (Sobre sobre in i.Sobres)
                {
                    Sobre copia = sobre;

                    if (anterior.Sobres.Contains(sobre))
                        anterior.quitarSobre(sobre);
                    else
                        _sobres.agregarSobre(ref copia, i);

                }

                foreach (Sobre sobre in anterior.Sobres)
                    _sobres.eliminaSobre(sobre);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una inconsistencia en un deposito.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDeposito con los datos de la inconsistencia</param>
        public void eliminarInconsistenciaDeposito(InconsistenciaDeposito i)
        {

            try
            {
                _inconsistencias_depositos.eliminarInconsistencia(i);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las inconsistencias en depositos registradas durante un periodo de tiempo.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de las inconsistencias registrados en el periodo de tiempo indicado</returns>
        public BindingList<InconsistenciaDeposito> listarInconsistenciasDepositos(DateTime i, DateTime f)
        {

            try
            {
                BindingList<InconsistenciaDeposito> inconsistencias = _inconsistencias_depositos.listarInconsistencias(i, f);

                foreach (InconsistenciaDeposito inconsistencia in inconsistencias)
                {
                    InconsistenciaDeposito copia = inconsistencia;
                    ManifiestoCEF manifiesto = inconsistencia.Manifiesto;

                    _valores.obtenerValoresInconsistencia(ref copia);
                    _sobres.obtenerSobresInconsistencia(ref copia);

                    _inconsistencias_depositos.obtenerSegregadoInconsistencia(ref copia);

                    SegregadoCEF segregado = copia.Segregado;

                    if (segregado != null)
                        _segregados.obtenerDatosSegregado(ref segregado);
                    else
                        _manifiestos_cef.obtenerDatosManifiestoCEF(ref manifiesto);
                }

                return inconsistencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Inconsistencias en Depositos Causadas por Clientes

        #region Inconsistencias Causadas por Digitadores

        /// <summary>
        /// Registrar una inconsistencia para un digitador en el sistema.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDigitador con los datos de la inconsistencia</param>
        public void agregarInconsistenciaDigitador(ref InconsistenciaDigitador i)
        {

            try
            {
                _inconsistencias_digitador.agregarInconsistencia(ref i);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una inconsistencia para un digitador.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDigitador con los datos de la inconsistencia</param>
        public void actualizarInconsistenciaDigitador(InconsistenciaDigitador i)
        {

            try
            {
                _inconsistencias_digitador.actualizarInconsistencia(i);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una inconsistencia para un digitador.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDigitador con los datos de la inconsistencia</param>
        public void eliminarInconsistenciaDigitador(InconsistenciaDigitador i)
        {

            try
            {
                _inconsistencias_digitador.eliminarInconsistencia(i);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Listar las inconsistencias para digitadores registradas durante un periodo de tiempo.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de las inconsistencias registrados en el periodo de tiempo indicado</returns>
        public BindingList<InconsistenciaDigitador> listarInconsistenciasDigitadores(DateTime i, DateTime f)
        {

            try
            {
                return _inconsistencias_digitador.listarInconsistencias(i, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Inconsistencias Causadas por Digitadores

        #region Gestiones

        /// <summary>
        /// Registrar una nueva gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la nueva gestión</param>
        public void agregarGestion(ref Gestion g)
        {

            try
            {
                _gestiones.agregarGestion(ref g);

                // Agregar los depositos, tulas y manifiestos

                foreach (Deposito deposito in g.Depositos)
                {
                    Deposito copia = deposito;

                    _gestiones.agregarDepositoGestion(ref copia, g);
                }

                foreach (Tula tula in g.Tulas)
                {
                    Tula copia = tula;

                    _gestiones.agregarTulaGestion(ref copia, g);
                }

                foreach (ManifiestoCEF manifiesto in g.Manifiestos)
                {
                    ManifiestoCEF copia = manifiesto;

                    _gestiones.agregarManifiestoGestion(ref copia, g);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestión a actualizar</param>
        public void actualizarGestion(Gestion g)
        {

            try
            {
                _gestiones.actualizarGestion(g);

                // Desligar los depositos anteriores de la gestión y registrar los nuevos

                Gestion anterior = new Gestion(id: g.ID);

                _gestiones.obtenerDepositosGestion(ref anterior);

                foreach (Deposito deposito in g.Depositos)
                {

                    if (anterior.Depositos.Contains(deposito))
                    {
                        anterior.quitarDeposito(deposito);
                    }
                    else
                    {
                        Deposito copia = deposito;
                        _gestiones.agregarDepositoGestion(ref copia, g);
                    }

                }

                foreach (Deposito deposito in anterior.Depositos)
                    _gestiones.eliminarDepositoGestion(deposito);

                // Desligar los manifiestos anteriores de la gestión y registrar los nuevos

                _gestiones.obtenerManifiestosGestion(ref anterior);

                foreach (ManifiestoCEF manifiesto in g.Manifiestos)
                {

                    if (anterior.Manifiestos.Contains(manifiesto))
                    {
                        anterior.quitarManifiesto(manifiesto);
                    }
                    else
                    {
                        ManifiestoCEF copia = manifiesto;

                        _gestiones.agregarManifiestoGestion(ref copia, g);
                    }

                }

                foreach (Manifiesto manifiesto in anterior.Manifiestos)
                    _gestiones.eliminarManifiestoGestion(manifiesto);

                // Desligar las tulas anteriores de la gestión y registrar los nuevas

                _gestiones.obtenerTulasGestion(ref anterior);

                foreach (Tula tula in g.Tulas)
                {

                    if (anterior.Tulas.Contains(tula))
                    {
                        anterior.quitarTula(tula);
                    }
                    else
                    {
                        Tula copia = tula;

                        _gestiones.agregarTulaGestion(ref copia, g);
                    }

                }

                foreach (Tula tula in anterior.Tulas)
                    _gestiones.eliminarTulaGestion(tula);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una gestión y terminarla.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos del tipo de gestión a actualizar</param>
        public void actualizarGestionTerminar(Gestion g)
        {

            try
            {
                _gestiones.actualizarGestionTerminar(g);

                if (g.Causa.Causante == Causantes.Transportadora)
                    _gestiones.agregarTransportadoraGestion(g);
                else if (g.Causa.Causante != Causantes.Cliente &&
                         g.Causa.Causante != Causantes.Otro)
                    _gestiones.agregarColaboradorGestion(g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una gestión.
        /// </summary>
        /// <param name="t">Objeto Gestion con los datos de la gestión a eliminar</param>
        public void eliminarGestion(Gestion g)
        {

            try
            {
                _gestiones.eliminarGestion(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las gestiones registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las gestiones registradas en el sistema</returns>
        public BindingList<Gestion> listarGestiones()
        {

            try
            {
                BindingList<Gestion> gestiones = _gestiones.listarGestiones();

                foreach (Gestion gestion in gestiones)
                {
                    Gestion copia = gestion;

                    _gestiones.obtenerDepositosGestion(ref copia);
                    _gestiones.obtenerTulasGestion(ref copia);
                    _gestiones.obtenerManifiestosGestion(ref copia);
                }

                return gestiones;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las gestiones terminadas registradas en el sistema en un periodo de tiempo.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="i">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de las gestiones registradas en el sistema</returns>
        public BindingList<Gestion> listarGestionesTerminadas(DateTime i, DateTime f)
        {
            try
            {
                BindingList<Gestion> gestiones = _gestiones.listarGestionesTerminadas(i, f);

                foreach (Gestion gestion in gestiones)
                {
                    Gestion copia = gestion;

                    _gestiones.obtenerColaboradorGestion(ref copia);
                    _gestiones.obtenerTransportadoraGestion(ref copia);
                    _gestiones.obtenerDepositosGestion(ref copia);
                    _gestiones.obtenerTulasGestion(ref copia);
                    _gestiones.obtenerManifiestosGestion(ref copia);
                }

                return gestiones;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las gestiones que están a punto de vencer.
        /// </summary>
        /// <returns>Lista de los tipos de gestión registrados en el sistema</returns>
        public BindingList<Gestion> listarGestionesPendientes()
        {

            try
            {
                BindingList<Gestion> gestiones = _gestiones.listarGestionesPendientes();

                foreach (Gestion gestion in gestiones)
                {
                    Gestion copia = gestion;

                    _gestiones.obtenerDepositosGestion(ref copia);
                    _gestiones.obtenerTulasGestion(ref copia);
                    _gestiones.obtenerManifiestosGestion(ref copia);
                }

                return gestiones;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Gestiones

        #region Errores en lo Cierres de los Cajeros

        /// <summary>
        /// Agregar un registro de errores de cierre en la base de datos.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierre con los datos del registro</param>
        public void agregarRegistroErroresCierre(ref RegistroErroresCierre r)
        {

            try
            {
                if (_errores.verificarRegistroErroresCierre(r))
                    throw new Excepcion("ErrorRegistroErroresCierreDuplicado");

                _errores.agregarRegistroErroresCierre(ref r);

                foreach (TipoErrorCierre error in r.Errores)
                    _errores.agregarErrorRegistroErroresCierre(r, error);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un registro de errores para un cierre.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierre con los datos del registro a actualizar</param>
        public void actualizarRegistroErroresCierre(RegistroErroresCierre r)
        {

            try
            {
                if (_errores.verificarRegistroErroresCierre(r))
                    throw new Excepcion("ErrorRegistroErroresCierreDuplicado");

                _errores.actualizarRegistroErroresCierre(r);

                // Desligar los tipos de error anteriores del registro y agregar los nuevos

                RegistroErroresCierre anterior = new RegistroErroresCierre(r.Id);

                _errores.obtenerErroresRegistroErroresCierre(ref anterior);

                foreach (TipoErrorCierre error in r.Errores)
                {

                    if (anterior.Errores.Contains(error))
                        anterior.quitarError(error);
                    else
                        _errores.agregarErrorRegistroErroresCierre(r, error);

                }

                foreach (TipoErrorCierre error in anterior.Errores)
                    _errores.eliminarErrorRegistroErroresCierre(r, error);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un registro de errores para un cierre.
        /// </summary>
        /// <param name="r">Objeto RegistroErroresCierre con los datos del registro a eliminar</param>
        public void eliminarRegistroErroresCierre(RegistroErroresCierre r)
        {

            try
            {
                _errores.eliminarRegistroErroresCierre(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        /// <summary>
        /// Listar todos los registros de errores de cierres en un periodo de tiempo determinado.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de registros de errores incluidos en el sistema</returns>
        public BindingList<RegistroErroresCierre> listarRegistrosErroresCierres(DateTime i, DateTime f)
        {

            try
            {
                BindingList<RegistroErroresCierre> registros = _errores.listarRegistrosErroresCierres(i, f);

                foreach (RegistroErroresCierre registro in registros)
                {
                    RegistroErroresCierre copia = registro;

                    _errores.obtenerErroresRegistroErroresCierre(ref copia);
                }

                return registros;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los registros de errores de cierres para un colaborador específico en un periodo de tiempo determinado.
        /// </summary>
        /// <param name="c">Colaborador para el cual se genera la lista</param>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de registros de errores incluidos en el sistema</returns>
        public BindingList<RegistroErroresCierre> listarRegistrosErroresCierresCajero(Colaborador c, DateTime i, DateTime f)
        {

            try
            {
                BindingList<RegistroErroresCierre> registros = _errores.listarRegistrosErroresCierresColaborador(c, i, f);

                foreach (RegistroErroresCierre registro in registros)
                {
                    RegistroErroresCierre copia = registro;

                    _errores.obtenerErroresRegistroErroresCierre(ref copia);
                }

                return registros;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        #endregion Errores en lo Cierres de los Cajeros

        #region Libro Mayor




        #endregion Libro Mayor

        #region Inconsistencias Planillas Empresas

        /// <summary>
        /// Lista las inconsistencias de las planillas
        /// </summary>
        /// <param name="s">Lista de Planillas</param>
        /// <param name="cordinador">Objeto Colaborador con los datos del colaborador</param>
        /// <returns>Una lista con las inconsistencias de las planillas</returns>
        public BindingList<InconsistenciaPlanilla> ListarInconsistencias(BindingList<Planilla> s, Colaborador cordinador)
        {
            DateTime fecha = s[0].Fecha;
            EmpresaTransporte empresa = s[0].Empresa;
            BindingList<InconsistenciaPlanilla> inconsistencias = new BindingList<InconsistenciaPlanilla>();
            inconsistencias.Clear();
            try
            {
                try
                {
                    inconsistencias = _inconsistencia.Listar(ref fecha, ref empresa, ref cordinador);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return inconsistencias;
        }






        /// <summary>
        /// Lista las inconsistencias de las planillas
        /// </summary>
        /// <param name="s">Lista de Planillas</param>
        /// <param name="cordinador">Objeto Colaborador con los datos del colaborador</param>
        /// <returns>Una lista con las inconsistencias de las planillas</returns>
        public BindingList<InconsistenciaPlanilla> ListarInconsistenciasProcesamiento(BindingList<Planilla> s, Colaborador cordinador)
        {
            DateTime fecha = s[0].Fecha;
            EmpresaTransporte empresa = s[0].Empresa;
            BindingList<InconsistenciaPlanilla> inconsistencias = new BindingList<InconsistenciaPlanilla>();
            inconsistencias.Clear();
            try
            {
                try
                {
                    inconsistencias = _inconsistencia.ListarProcesamiento(ref fecha, ref empresa, ref cordinador);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return inconsistencias;
        }

        /// <summary>
        /// Obtiene una lista de las inconsistencias a Exportar
        /// </summary>
        /// <param name="estado">Estado de la Planilla</param>
        /// <param name="fecha">Fecha del Trámite</param>
        /// <param name="emp">Objeto EmpresaTransporte con los datos de la empresa transportadora</param>
        /// <returns>Una lista de planillas a exportar</returns>
        public BindingList<InconsistenciaPlanilla> ExportarInconsistencias(Estado estado, DateTime fecha, EmpresaTransporte emp)
        {
            BindingList<InconsistenciaPlanilla> inconsistencias = new BindingList<InconsistenciaPlanilla>();
            try
            {
                inconsistencias = _inconsistencia.Exportar(estado, fecha, emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return inconsistencias;
        }




        /// <summary>
        /// Obtiene una lista de las inconsistencias a Exportar
        /// </summary>
        /// <param name="estado">Estado de la Planilla</param>
        /// <param name="fecha">Fecha del Trámite</param>
        /// <param name="emp">Objeto EmpresaTransporte con los datos de la empresa transportadora</param>
        /// <returns>Una lista de planillas a exportar</returns>
        public BindingList<InconsistenciaPlanilla> ExportarInconsistenciasProcesamiento(Estado estado, DateTime fecha, EmpresaTransporte emp)
        {
            BindingList<InconsistenciaPlanilla> inconsistencias = new BindingList<InconsistenciaPlanilla>();
            try
            {
                inconsistencias = _inconsistencia.ExportarProcesamiento(estado, fecha, emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return inconsistencias;
        }


        #endregion Inconsistencias Planillas Empresas

        #region Planillas Empresas

        /// <summary>
        /// Importar una lista de Planillas 
        /// </summary>
        /// <param name="s">Lista de planillas a importar</param>
        public void importarPlanillas(BindingList<Planilla> s, Colaborador cordinador)
        {

            try
            {

                foreach (Planilla planilla in s)
                {
                    Planilla copia_planilla = planilla;

                    try
                    {
                        _planilla.agregarPlanillaEmpresa(ref copia_planilla, ref cordinador);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }


        /// <summary>
        /// Importar una lista de Planillas 
        /// </summary>
        /// <param name="s">Lista de planillas a importar</param>
        public void importarPlanillasProcesadas(BindingList<Planilla> s, Colaborador cordinador)
        {

            try
            {

                foreach (Planilla planilla in s)
                {
                    Planilla copia_planilla = planilla;

                    try
                    {
                        _planilla.agregarPlanillaEmpresaProcesadas(ref copia_planilla, ref cordinador);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }

        /// <summary>
        /// Valida una lista de planillas contra la base de datos
        /// </summary>
        /// <param name="s">Lista de Planillas a validar</param>
        /// <param name="cordinador">Persona que realiza el proceso</param>
        /// <returns>Una lista de planillas con los datos de las planillas validadas</returns>
        public BindingList<Planilla> ValidarPlanillas(BindingList<Planilla> s, Colaborador cordinador)
        {
            // Leer las planillas
            BindingList<Planilla> buenas = new BindingList<Planilla>();
            BindingList<InconsistenciaPlanilla> incorrectas = new BindingList<InconsistenciaPlanilla>();

            incorrectas.Clear();
            buenas.Clear();
            Planilla copia_planilla = new Planilla();

            foreach (Planilla planilla in s)
            {
                copia_planilla = planilla;
                InconsistenciaPlanilla inconsistencia = new InconsistenciaPlanilla();

                try
                {
                    int existe = _planilla.verificarPlanilla(ref copia_planilla);
                    if (existe == 0)
                    {
                        inconsistencia.Comentario = "";
                        inconsistencia.Empresa = copia_planilla.Empresa;
                        inconsistencia.Tipo = (Tipo)Tipo.Error_de_digitación_por_parte_del_receptor_BAC;
                        inconsistencia.Estado = Estado.Pendiente;
                        inconsistencia.Fecha = copia_planilla.Fecha;
                        inconsistencia.FechaResolucion = copia_planilla.Fecha;
                        inconsistencia.manifiesto = copia_planilla.manifiesto;
                        inconsistencia.Tula = copia_planilla.Tula;
                        inconsistencia.Origen = Origen.Transportadora;
                        inconsistencia.MontoTula = copia_planilla.MontoTula;
                        inconsistencia.MontoPlanilla = copia_planilla.MontoPlanilla;
                        inconsistencia.id_pdv = copia_planilla.IDPuntoVenta;
                        inconsistencia.pdv = (short)copia_planilla.PuntoAtencion.TipoPuntodeAtencion;
                        inconsistencia.Tarifa = copia_planilla.Tarifa;
                        inconsistencia.Recargo = copia_planilla.Recargo;
                        inconsistencia.Total = copia_planilla.Total;

                        incorrectas.Add(inconsistencia);
                        _inconsistencia.insertaInconsistencia(ref inconsistencia, ref cordinador);
                    }
                    else
                    {
                        //para excluir algunos de los grupos 
                        if (existe != 12 & existe != 32 & existe != 14 & existe != 6 & existe != 26)
                        {
                            // Obtiene el Grupo y Actualiza las planillas
                            copia_planilla.Grupo = _planilla.SeleccionarGrupo(ref existe);
                            buenas.Add(copia_planilla);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

            InconsistenciaPlanilla incon = new InconsistenciaPlanilla();
            if (buenas.Count > 0)
            {
                foreach (InconsistenciaPlanilla inc in incorrectas)
                {
                    incon = inc;
                    _inconsistencia.insertaInconsistencia(ref incon, ref cordinador);
                }

            }
            return buenas;
        }



        /// <summary>
        /// Valida una lista de planillas contra la base de datos
        /// </summary>
        /// <param name="s">Lista de Planillas a validar</param>
        /// <param name="cordinador">Persona que realiza el proceso</param>
        /// <returns>Una lista de planillas con los datos de las planillas validadas</returns>
        public BindingList<Planilla> ValidarPlanillasProcesamiento(BindingList<Planilla> s, Colaborador cordinador)
        {
            // Leer las planillas
            BindingList<Planilla> buenas = new BindingList<Planilla>();
            BindingList<InconsistenciaPlanilla> incorrectas = new BindingList<InconsistenciaPlanilla>();

            incorrectas.Clear();
            buenas.Clear();
            Planilla copia_planilla = new Planilla();

            foreach (Planilla planilla in s)
            {
                copia_planilla = planilla;
                InconsistenciaPlanilla inconsistencia = new InconsistenciaPlanilla();

                try
                {
                    int existe = _planilla.verificarPlanillaProcesamiento(ref copia_planilla);
                    if (existe == 0)
                    {
                        inconsistencia.Comentario = "";
                        inconsistencia.Empresa = copia_planilla.Empresa;
                        inconsistencia.Tipo = (Tipo)Tipo.Error_de_digitación_por_parte_del_receptor_BAC;
                        inconsistencia.Estado = Estado.Pendiente;
                        inconsistencia.Fecha = copia_planilla.Fecha;
                        inconsistencia.FechaResolucion = copia_planilla.Fecha;
                        inconsistencia.manifiesto = copia_planilla.manifiesto;
                        inconsistencia.Tula = copia_planilla.Tula;
                        inconsistencia.Origen = Origen.Transportadora;
                        inconsistencia.MontoTula = copia_planilla.MontoTula;
                        inconsistencia.MontoPlanilla = copia_planilla.MontoPlanilla;
                        inconsistencia.id_pdv = copia_planilla.IDPuntoVenta;
                        inconsistencia.pdv = (short)copia_planilla.PuntoAtencion.TipoPuntodeAtencion;
                        inconsistencia.Tarifa = copia_planilla.Tarifa;
                        inconsistencia.Recargo = copia_planilla.Recargo;
                        inconsistencia.Total = copia_planilla.Total;

                        incorrectas.Add(inconsistencia);
                        _inconsistencia.insertaInconsistenciaProcesamiento(ref inconsistencia, ref cordinador);
                    }
                    else
                    {
                       
                            buenas.Add(copia_planilla);
                        
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

            InconsistenciaPlanilla incon = new InconsistenciaPlanilla();
            //if (buenas.Count > 0)
            //{
            //    foreach (InconsistenciaPlanilla inc in incorrectas)
            //    {
            //        incon = inc;
            //        _inconsistencia.insertaInconsistenciaProcesamiento(ref incon, ref cordinador);
            //    }

            //}
            return buenas;
        }



        #endregion Planillas Empresas

        #region Sucursales

        /// <summary>
        /// Importar una lista de Sucursales.
        /// </summary>
        /// <param name="s">Lista de sucursales a importar</param>
        public void importarSucursales(BindingList<Sucursal> s)
        {

            try
            {

                foreach (Sucursal sucursal in s)
                {
                    Sucursal copia_sucursal = sucursal;

                    try
                    {
                        if (_sucursales.verificarSucursalCodigo(ref copia_sucursal)==false)
                            _sucursales.actualizarSucursal(copia_sucursal);
                        else
                            _sucursales.agregarSucursal(ref copia_sucursal);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }


        /// <summary>
        /// Listar las sucursales registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las sucursales registradas en el sistema que se deben cargar un determinado dia</returns>
        public BindingList<Sucursal> listarSucursalesaCargar(DateTime fecha)
        {

            try
            {
                BindingList<Sucursal> sucursales = _sucursales.listarSucursalesaCargar(fecha);

                foreach (Sucursal sucursal in sucursales)
                {
                    Sucursal copia = sucursal;

                    _sucursales.obtenerDiasCargaSucursal(ref copia);
                }

                return sucursales;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Sucursales

        #region Asignacion Tripulaciones



       /// <summary>
       /// Auto asigna una lista de tripulaciones aleatoriamente
       /// </summary>
       /// <param name="chof">Lista de choferes</param>
       /// <param name="port">Lista de Portavalores</param>
       /// <param name="cust">Lista de custodios</param>
       /// <param name="rutas">Cantidad de rutas para asignar</param>
       /// <param name="usuario">Usuario quien realiza el registro</param>
       /// <returns>Devuelve una lista con las tripulaciones ya combinadas</returns>
        public List<Tripulacion> autoAsignarTripulaciones(List<Colaborador> chof, List<Colaborador> port, List<Colaborador> cust, int rutas,Colaborador usuario)
        {
            List<Tripulacion> tripulaciones = new List<Tripulacion>();

            Random random_chofer = new Random();
            Random random_custodio = new Random();
            Random random_portavalor = new Random();



            int cantidad = rutas;
            int[] numeros_chofer = new int[cantidad];
            int[] numeros_custodio = new int[cantidad];
            int[] numeros_portavalor = new int[cantidad];

            //numeros_chofer = this.CalcularNumeros(numeros_chofer, cantidad, chof.Count);
            //numeros_custodio = this.CalcularNumeros(numeros_custodio, cantidad, cust.Count);
            //numeros_portavalor = this.CalcularNumeros(numeros_portavalor, cantidad, port.Count);

            for (int i = 0; i < cantidad; i++)
            {
                numeros_chofer[i] = random_chofer.Next(0, (chof.Count - 1));
                numeros_custodio[i] = random_custodio.Next(0, (cust.Count - 1));
                numeros_portavalor[i] = random_portavalor.Next(0, (port.Count - 1));

                if (i > 0)    // a partir del segundo numero que genera empezara a comparar que no se repita
                {
                    for (int x = 0; x < 100; x++)  //comprobara que no se repita por 2 veces
                    {

                        for (int j = 0; j < i; j++)
                        {
                            if (numeros_chofer[i] == numeros_chofer[j])
                            {
                                numeros_chofer[i] = random_chofer.Next(0, (chof.Count - 1));
                            }
                            if (numeros_custodio[i] == numeros_custodio[j])
                            {
                                numeros_custodio[i] = random_custodio.Next(0, (cust.Count - 1));
                            }
                            if (numeros_portavalor[i] == numeros_portavalor[j])
                            {
                                numeros_portavalor[i] = random_portavalor.Next(0, (port.Count - 1));
                            }
                        }
                    }
                }

            }

            for (int i = 0; i < cantidad; i++)
            {

                Colaborador chofer = chof[numeros_chofer[i]];
                Colaborador custodio = cust[numeros_custodio[i]];
                Colaborador portavalor = port[numeros_portavalor[i]];

                Tripulacion trip = new Tripulacion(nombre: "", ruta: i + 1, chofer: chofer, custodio: custodio, portavalor: portavalor, usuario: usuario);
                tripulaciones.Add(trip);
            }


            return tripulaciones;
        }




          /// <summary>
        /// funcion para obtener un numero aleatorio unico (sin repetir), 
        /// para ello los numeros son contenidos en un array, del cual se van eliminando.        
        /// </summary>
        /// <returns>numero aleatorio sin repetir, si no hay mas numeros retorna -1</returns>
        public List<Tripulacion> getRandom(List<Colaborador> chof, List<Colaborador> port, List<Colaborador> cust, int rutas, Colaborador usuario)
        {
            List<Tripulacion> tripulaciones = new List<Tripulacion>();

            MersenneTwister randG = new MersenneTwister();

            Random random_chofer = new Random();
            Random random_custodio = new Random();
            Random random_portavalor = new Random();

            int cantidad = rutas;
            List<int> numeros_chofer = new List<int>(cantidad);
            List<int> numeros_custodio = new List<int>(cantidad);
            List<int> numeros_portavalor = new List<int>(cantidad);
            int j = 0;
            int k = 0;
            int m = 0;

            for (int i = 0; i < cantidad; i++)
            {
                if (i >= chof.Count && chof.Count < cantidad)
                {

                    numeros_chofer.Add(j);
                    j++;
                }
                else
                    numeros_chofer.Add(i);

                if (i >= cust.Count && cust.Count < cantidad)
                {

                    numeros_custodio.Add(k);
                    k++;
                }
                else
                    numeros_custodio.Add(i);

                if (i >= port.Count && port.Count < cantidad)
                {

                    numeros_portavalor.Add(m);
                    m++;
                }
                else
                    numeros_portavalor.Add(i);
          
            }

            for (int i = 0; i < cantidad; i++)
            {

                // si no existen mas numeros en el array, se sale con -1.
                if (numeros_chofer.Count - 1 < 0) numeros_chofer = new List<int>(cantidad);
                if (numeros_custodio.Count - 1 < 0) numeros_custodio = new List<int>(cantidad);
                if (numeros_portavalor.Count - 1 < 0) numeros_portavalor = new List<int>(cantidad);

                // inicializar el objeto para manejar numeros aleatorios
                Random random = new Random(DateTime.Now.Millisecond);
                // obtener un numero aleatorio entre los existentes en el array
                int randchof = randG.Next(numeros_chofer.Count - 1);//random.Next(0,numeros_chofer.Count-1);
                int randcus = randG.Next(numeros_custodio.Count - 1);//random.Next(0,numeros_custodio.Count - 1);
                int randport = randG.Next(numeros_portavalor.Count - 1);//random.Next(0,numeros_portavalor.Count - 1);

                // obtener el numero real que contiene esa posicion del array


                Colaborador chofer = chof[numeros_chofer[randchof]];
                Colaborador custodio = cust[numeros_custodio[randcus]];
                Colaborador portavalor = port[numeros_portavalor[randport]];

                Tripulacion trip = new Tripulacion(nombre: "", ruta: i + 1, chofer: chofer, custodio: custodio, portavalor: portavalor, usuario: usuario);
                tripulaciones.Add(trip);

                // borrar el numero del array para que no se vuelva a obtener
                numeros_chofer.RemoveAt(randchof);
                numeros_custodio.RemoveAt(randcus);
                numeros_portavalor.RemoveAt(randport);

            }
            // retornar el numero obtenido
            return tripulaciones;
        }

    

        /// <summary>
        /// Calcula los numeros aleatorios sin repetir
        /// </summary>
        /// <param name="valores"></param>
        /// <param name="rutas"></param>
        /// <param name="limite"></param>
        /// <returns></returns>
        //private int[] CalcularNumeros(int[] valores, int rutas, int limite)
        //{
        //    int[] numeros = valores;
        //    Random r = new Random();

        //    int auxiliar = 0;
        //    int contador = 0;

        //    for (int i = 0; i < rutas; i++)
        //    {
        //        auxiliar = r.Next(1, limite);
        //        bool continuar = false;

        //        while (!continuar)
        //        {
        //            for (int j = 0; j <= contador; j++)
        //            {
        //                if (auxiliar == numeros[j])
        //                {
        //                    continuar = true;
        //                    j = contador;
        //                }
        //            }

        //            if (continuar)
        //            {
        //                auxiliar = r.Next(1, limite);
        //                continuar = false;
        //            }
        //            else
        //            {
        //                continuar = true;
        //                numeros[contador] = auxiliar;
        //                contador++;
        //            }
        //        }
        //    }

        //    return numeros;
        //}


        

        #endregion Asignacion Tripulaciones

        #region Otros


        /// <summary>
        /// Agregar un registro a la bitácora de monitoreo de manifiestos.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del coordinador que realizó el monitoreo</param>
        public void agregarRegistroBitacoraMonitoreo(Colaborador c)
        {

            try
            {
                _coordinacion.agregarRegistroBitacoraMonitoreo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar el comentario de un registro de la bitácora de monitoreo de manifiestos.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del coordinador que realizó el monitoreo</param>
        /// <param name="co">Comentario que se asignará al registro</param>
        public void actualizarRegistroBitacoraMonitoreo(Colaborador c, string co)
        {

            try
            {
                _coordinacion.actualizarRegistroBitacoraMonitoreo(c, co);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos del monitoreo de manifiestos no procesados.
        /// </summary>
        /// <param name="i">Fecha incial para la cual se desea delimitar la consulta</param>
        /// <param name="g">Lista de grupos  para los cuales se desean obtener los manifiestos pendientes de procesar</param>
        /// <returns>Tabla con la lista de los manifiestos pendientes de procesar</returns>
        public DataTable obtenerDatosMonitoreoManifiestos(DateTime i, List<Grupo> g)
        {

            try
            {
                DataTable primera = _coordinacion.obtenerDatosMonitoreoManifiestos(i, g[0]);

                for (int contador = 1; contador < g.Count; contador++) {
                    DataTable tabla = _coordinacion.obtenerDatosMonitoreoManifiestos(i, g[contador]);

                    primera.Merge(tabla);
                }

                return primera;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos del monitoreo de ATM's.
        /// </summary>
        /// <returns>Tabla con los datos del monitoreo de ATM's</returns>
        public DataTable obtenerDatosMonitoreoATMs()
        {

            try
            {
                return _coordinacion.obtenerDatosMonitoreoATMs();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos del monitoreo de cargas y descargas ATM's para una fecha específica.
        /// </summary>
        /// <param name="f">Fecha para la cual se genera la consulta</param>
        /// <returns>Tabla con los datos del monitoreo de las cargas y descargas</returns>
        public DataTable obtenerDatosMonitoreoCargasDescargas(DateTime f)
        {

            try
            {
                return _coordinacion.obtenerDatosMonitoreoCargasDescargas(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener la fecha del servidor.
        /// </summary>
        /// <returns>Hora y Fecha actual del servidor</returns>
        public DateTime obtenerFechaHora()
        {

            try
            {
                return _coordinacion.obtenerFechaHora();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Otros

        #region Cargas de Sucursales

        
        /// <summary>
        /// Obtener datos de portavalor asignado a una carga de sucursal
        /// </summary>
        /// <param name="c">Carga asignada al portavalor</param>
        /// <returns>Datos del portavalor</returns>
        public void listarPortavalorPorCargaSucursal(ref CargaSucursal c)
        {

            try
            {
                _carga_sucursales.listarPotavalorPorCargaSucursal(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar los datos de la carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void actualizarCargaSucursal(CargaSucursal c)
        {

            try
            {
                _carga_sucursales.actualizarCargaSucursal(c);

                foreach (CartuchoCargaSucursal cartucho in c.Cartuchos)
                {
                    CartuchoCargaSucursal copia_cartucho = cartucho;
                    try
                    {
                        if(copia_cartucho.ID > 0 )
                            _cartuchos_cargas_sucursales.actualizarCartuchoCargaSucursal(ref copia_cartucho);   
                        else
                            _cartuchos_cargas_sucursales.agregarCartuchoCargaSucursales(ref copia_cartucho);
                        
                    }
                    catch
                    {
                        
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        

        /// <summary>
        /// Asignar la carga de una Sucursal a un Colaborador
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void actualizarCargaSucursalColaborador(CargaSucursal c)
        {

            try
            {
                _carga_sucursales.actualizarCargaSucursalColaborador(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Asignar la ruta a la carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaATM con los datos de la carga</param>
        public void actualizarCargaSucursalRuta(CargaSucursal c)
        {

            //try
            //{
            //    _cargas.actualizarCargaATMRuta(c);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }



        /// <summary>
        /// Asignar la ruta y la hora de llegada a la carga de una Sucursal
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void actualizarCargaSucursalRutaHora(CargaSucursal c)
        {

            //try
            //{
            //    _cargas.actualizarCargaATMRutaHora(ref c);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }

        /// <summary>
        /// Actualizar el orden de las cargas de Sucursales de una ruta específica.
        /// </summary>
        /// <param name="c">Lista de cargas de una ruta específica</param>
        public void actualizarCargasSucursalesOrdenRuta(BindingList<CargaSucursal> c)
        {

            try
            {
                foreach (CargaSucursal carga in c) { }
                   // _cargas.actualizarCargaATMOrdenRuta(carga);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void actualizarCargaSucursalDatosVerificacion(CargaSucursal c)
        {

            try
            {
                _carga_sucursales.actualizarCargaSucursalDatosVerificacion(c);

               

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void eliminarCargaSucursal(CargaSucursal c)
        {

            try
            {
                _carga_sucursales.eliminarCargaSucursal(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Importar una lista de Cargas.
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarCargasSucursales(ref CargaSucursal c, Colaborador col)
        {

            try
            {
                    CargaSucursal copia_carga = c;
                    
                     _carga_sucursales.agregarCargaSucursal(ref copia_carga, col);

                    foreach (CartuchoCargaSucursal cartucho in copia_carga.Cartuchos)
                    {
                        CartuchoCargaSucursal copia_cartucho = cartucho;

                        copia_cartucho.Movimiento.ID = copia_carga.ID;

                        _cartuchos_cargas_sucursales.agregarCartuchoCargaSucursales(ref copia_cartucho);
                    }

               

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }



        /// <summary>
        /// Actualiza Ruta y horas programadas de las cargas
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarRutasCargasSucursal(BindingList<CargaSucursal> c)
        {

            try
            {

                foreach (CargaSucursal carga in c)
                {
                    CargaSucursal copia_carga = carga;

                    //_cargas.actualizarCargaATMRutaHoraImportacion(ref copia_carga);


                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }

        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaSucursal> listarCargasSucursales(Colaborador c,Sucursal s, DateTime f, byte? r, EstadoAprobacionCargas  est)
        {

            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursales(c,s, f, r,est);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;
                    copia.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, true);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);
                    _carga_sucursales.obtenerManifiestosCargaSucursal(ref copia);


                    if (copia.Manifiesto != null)
                    {

                        foreach (ManifiestoSucursalCarga m in copia.Manifiesto)
                        {
                            ManifiestoSucursalCarga copia_manifiesto = m;

                            copia_manifiesto.ListaBolsas = new BindingList<Bolsa>();
                            copia_manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(ref copia_manifiesto);


                            foreach (Bolsa b in copia_manifiesto.ListaBolsas)
                            {
                                Bolsa copia_bolsa = b;
                                _montos_bolsas_sucursales.obtenerBolsaMontoSucursales(ref copia_bolsa);
                            }
                        }
                    }
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }






        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaSucursal> listarCargasSucursalesRoadnet(Colaborador c, Sucursal s, DateTime f, byte? r, EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursalesRoadnet(c, s, f, r, est);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;
                    copia.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, true);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);
                    _carga_sucursales.obtenerManifiestosCargaSucursal(ref copia);


                    if (copia.Manifiesto != null)
                    {

                        foreach (ManifiestoSucursalCarga m in copia.Manifiesto)
                        {
                            ManifiestoSucursalCarga copia_manifiesto = m;

                            copia_manifiesto.ListaBolsas = new BindingList<Bolsa>();
                            copia_manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(ref copia_manifiesto);


                            foreach (Bolsa b in copia_manifiesto.ListaBolsas)
                            {
                                Bolsa copia_bolsa = b;
                                _montos_bolsas_sucursales.obtenerBolsaMontoSucursales(ref copia_bolsa);
                            }
                        }
                    }
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



       /// <summary>
       /// Lista un reporte de la lista de las sucursales atendidas
       /// </summary>
       /// <param name="fechai">Fecha Inicio del Pedido</param>
       /// <param name="fechaf">Fecha Inicio del Pedido</param>
       /// <param name="s">Sucursal a la que pertenece el colaborador</param>
       /// <param name="asignador">Colaborador que asigna la remesa</param>
       /// <param name="aprobador">Colaborador que aprobo el pedido</param>
       /// <param name="portavalor">Portavalor que recibio la remesa</param>
       /// <returns>Una lista con los datos obtenidos</returns>
        public DataTable listarPedidoEnvioRemesas(DateTime fechai, DateTime fechaf, Sucursal s, Colaborador asignador, Colaborador aprobador, int tipocarga)
        {

            try
            {

                return _carga_sucursales.listarEnvioRemesasSucursales(fechai, fechaf, s, asignador, aprobador, tipocarga);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaSucursal> listarCargasSucursalesAprobar(Colaborador c, Sucursal s, DateTime f, byte? r, EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursalesPorAprobar(c, s, f, r, est);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;
                    copia.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, true);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);
                    _carga_sucursales.obtenerManifiestosCargaSucursal(ref copia);

                    if (copia.Manifiesto != null)
                    {

                        foreach (ManifiestoSucursalCarga m in copia.Manifiesto)
                        {
                            ManifiestoSucursalCarga copia_manifiesto = m;

                            copia_manifiesto.ListaBolsas = new BindingList<Bolsa>();
                            copia_manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(ref copia_manifiesto);

                            foreach (Bolsa b in copia_manifiesto.ListaBolsas)
                            {
                                Bolsa copia_bolsa = b;
                                _montos_bolsas_sucursales.obtenerBolsaMontoSucursales(ref copia_bolsa);
                            }
                        }
                    }

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaSucursal> listarCajasEmpresarialesAprobar(Colaborador c, Sucursal s, DateTime f, byte? r, EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCajasEmpresarialesPorAprobar(c, s, f, r, est);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;
                    copia.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, true);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);
                    _carga_sucursales.obtenerManifiestosCargaSucursal(ref copia);


                    if (copia.Manifiesto != null)
                    {

                        foreach (ManifiestoSucursalCarga m in copia.Manifiesto)
                        {
                            ManifiestoSucursalCarga copia_manifiesto = m;

                            copia_manifiesto.ListaBolsas = new BindingList<Bolsa>();
                            copia_manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(ref copia_manifiesto);

                            foreach (Bolsa b in copia_manifiesto.ListaBolsas)
                            {
                                Bolsa copia_bolsa = b;
                                _montos_bolsas_sucursales.obtenerBolsaMontoSucursales(ref copia_bolsa);
                            }
                        }
                    }



                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaSucursal> listarCargasSucursalesPorAprobarCorregir(Colaborador c, Sucursal s, DateTime f, byte? r, EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursalesAprobacionCorreccion(c, s, f, r, est);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;
                    copia.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, true);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);
                    _carga_sucursales.obtenerManifiestosCargaSucursal(ref copia);


                    if (copia.Manifiesto != null)
                    {

                        foreach (ManifiestoSucursalCarga m in copia.Manifiesto)
                        {
                            ManifiestoSucursalCarga copia_manifiesto = m;

                            copia_manifiesto.ListaBolsas = new BindingList<Bolsa>();
                            copia_manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(ref copia_manifiesto);

                            foreach (Bolsa b in copia_manifiesto.ListaBolsas)
                            {
                                Bolsa copia_bolsa = b;
                                _montos_bolsas_sucursales.obtenerBolsaMontoSucursales(ref copia_bolsa);
                            }
                        }
                    }

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaSucursal> listarCargasSucursalesManifiesto(Colaborador c, Sucursal s, DateTime f, byte? r, EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursalesManifiesto(c, s, f, r, est);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;
                    copia.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, true);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);
                    _carga_sucursales.obtenerColaboradoresCargaSucursal(ref copia);
                    _carga_sucursales.obtenerManifiestosCargaSucursal(ref copia);


                    if (copia.Manifiesto != null)
                    {

                        foreach (ManifiestoSucursalCarga m in copia.Manifiesto)
                        {
                            ManifiestoSucursalCarga copia_manifiesto = m;

                            copia_manifiesto.ListaBolsas = new BindingList<Bolsa>();
                            copia_manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(ref copia_manifiesto);

                            foreach (Bolsa b in copia_manifiesto.ListaBolsas)
                            {
                                Bolsa copia_bolsa = b;
                                _montos_bolsas_sucursales.obtenerBolsaMontoSucursales(ref copia_bolsa);
                            }
                        }
                    }
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Verificar si una Carga ya está aprobado por gerente y verificada.
        /// </summary>
        /// <param name="c">Objeto Carga con los datos del carga</param>
        /// <returns>Valor que indica si el carga existe</returns>
        public bool verificarExisteCargaVerificada(CargaSucursal c)
        {

            try
            {
                return _carga_sucursales.verificarExisteCargaVerificada(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Lista las cargas que se van a recibir para enviar a boveda
        /// </summary>
        /// <param name="marchamo">numero de marchamo a buscar</param>
        /// <returns></returns>
        public BindingList<CargaSucursal> listarCargasSucursal(String marchamo, EstadosCargasSucursales estado, Colaborador coordinador, EntregaRecibo entrega, DateTime fecha, byte? ruta)
        {
            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursal(marchamo, estado, coordinador, entrega, fecha, ruta);

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Actualiza los datos de una carga Sucursal en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosRecepcionCargaSucursales(CargaSucursal carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaSucursal copia = new CargaSucursal();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;

                _carga_sucursales.agregarRecepcionTulaCargaSucursal(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }






        /// Actualiza los datos de una carga Sucursal en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosEntregaCargaSucursales(CargaSucursal carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaSucursal copia = new CargaSucursal();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _carga_sucursales.agregarRecepcionTulaCargaSucursal(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaSucursal> listarCargasSucursalesSinAsignarCajero(Colaborador c, Sucursal s, DateTime f, byte? r)
        {

            try
            {

                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursalesSinAsignarCajero(s, f, r);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;

                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, true);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public void ActualizarCargasSucursalesRoadnet(DateTime f)
        {

            try
            {

                 _carga_sucursales.actualizarCargaSucursalDatosRoadnet(f);

             
            }
            catch (Exception ex)
            {
                guardarArchivo(ex.Message, f);
            }

        }



        /// <summary>
        /// Obtener una lista de las cargas de Sucursales no asignadas en una fecha dada.
        /// </summary>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas no asignadas</returns>
        public BindingList<CargaSucursal> listarCargasSucursalesNoAsignadas(DateTime f)
        {

            try
            {
                BindingList<CargaSucursal> cargas = null;
                //BindingList<CargaSucursal> cargas = _cargas.listarCargasATMs(f);

                //foreach (CargaSucursal carga in cargas)
                //{
                //    CargaSucursal copia = carga;

                //    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                //}

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener las cargas asignadas un cajero de Sucursales.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales</param>
        public BindingList<CargaSucursal> listarCargasSucursalesPorColaborador(Colaborador c, bool a)
        {

            try
            {
                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursalesPorCajero(c);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;

                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, a);
                    _carga_sucursales.obtenerDatosCargaSucursal(ref copia);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



       
        /// <summary>
        /// Obtener una lista de las cargas asignadas a una ruta en una fecha determinada.
        /// </summary>
        /// <param name="r">Número de ruta</param>
        /// <param name="f">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cargas que cumplen con los parámetros</returns>
        public BindingList<CargaSucursal> listarCargasSucursalesPorRuta(byte r, DateTime f)
        {

            try
            {
                BindingList<CargaSucursal> auxiliar = null;
                return auxiliar;
                //return _cargas.listarCargasATMsPorRuta(r, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        


        /// <summary>
        /// Obtener una lista de las cargas con los datos de la hoja de ruta.
        /// </summary>
        /// <param name="r">Número de ruta de las cargas que se listarán</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas que cumplen con los parámetros especificados</returns>
        public DataTable listarCargasSucursalesImpresionHojaRuta(byte r, DateTime f)
        {

            try
            {
                return _cargas.listarCargasATMsImpresionHojaRuta(r, f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        /// <summary>
        /// Obtener una lista de las cargas de emergencia no utilizadas en una fecha específica.
        /// </summary>
        /// <param name="fecha">Fecha para la cual se genera la lista</param>
        /// <returns>Lista de cargas de emergencia no utilizadas</returns>
        public BindingList<CargaSucursal> listarCargasSucursalesEmergenciasNoUtilizadas(DateTime f)
        {

            try
            {
                BindingList<CargaSucursal> cargas = _carga_sucursales.listarCargasSucursalesEmergenciasNoUtilizadas(f);

                foreach (CargaSucursal carga in cargas)
                {
                    CargaSucursal copia = carga;

                    _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, false);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Autoasignar las cargas tomando en cuenta las rutas y los cajeros full.
        /// </summary>
        /// <param name="caj">Lista de cajeror a los cuales se asignarán la cargas</param>
        /// <param name="car">Lista de cargas que se asignarán</param>
        /// <returns>Lista de cajeros y sus respectivas cargas</returns>
        public Dictionary<Colaborador, List<CargaSucursal>> autoAsignarCargasSucursal(List<Colaborador> caj, BindingList<CargaSucursal> car)
        {
            Dictionary<Colaborador, List<CargaSucursal>> cargas_cajeros = new Dictionary<Colaborador, List<CargaSucursal>>();


            int numero_cajero = 0;
        

            foreach (Colaborador cajero in caj)
                cargas_cajeros.Add(cajero, new List<CargaSucursal>());

            while (car.Count > 0)
            {
                CargaSucursal carga = car[0];
                Colaborador cajero = caj[numero_cajero];
                List<CargaSucursal> cargas_cajero = cargas_cajeros[cajero];


 
                    cargas_cajero.Add(carga);
                    car.RemoveAt(0);


                numero_cajero++;

                // Validar si se llego al último cajero

                if (numero_cajero == caj.Count) numero_cajero = 0;
            }

            return cargas_cajeros;
        }



        /// <summary>
        /// Ligar o desligar la carga de un Sucursal del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void actualizarCargaSucursalCierreSucursal(CargaSucursal c)
        {

            try
            {
                _carga_sucursales.actualizarCargaSucursalCierreSucursal(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas del cierre de un cajero de Sucursales.
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cierre del cajero de Sucursales</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasSucursalesPorCierreSucursales(CierreCargaSucursal c)
        {

            try
            {
                return _carga_sucursales.listarCargasSucursalesPorCierreSucursales(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Actualiza los datos de una carga Sucursal en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosRecepcionCargaSucursal(Carga carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaSucursal copia = new CargaSucursal();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.IdBolsa = carga.IDBolsa;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _carga_sucursales.agregarRecepcionTulaCargaSucursal(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Actualiza los datos de una carga Sucursal en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosEntregaCargaSucursal(Carga carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaSucursal copia = new CargaSucursal();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.IdBolsa = carga.IDBolsa;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _carga_sucursales.agregarRecepcionTulaCargaSucursal(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Actualizar los datos de la carga en una aprobacion
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void actualizarCargaSucursalAprobacionGerente(CargaSucursal c, EstadoAprobacionCargas est)
        {

            try
            {
                _carga_sucursales.actualizarCargaSucursalAprobacoinGerente(c, est);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cargas de Sucursales

        #region Cargas de Transportadoras



        /// <summary>
        /// Actualizar los datos de la carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadora(CargaTransportadora c)
        {

            try
            {
                _carga_transportadora.actualizarCargaTransportadora(c);

                foreach (CartuchoCargaTransportadora cartucho in c.Cartuchos)
                {
                    CartuchoCargaTransportadora copia_cartucho = cartucho;
                    try
                    {
                        if (copia_cartucho.ID > 0)
                            _cartucho_transportadora.actualizarCartuchoCargaTransportadora(ref copia_cartucho);
                        else
                            _cartucho_transportadora.agregarCartuchoCargaTransportadoraes(ref copia_cartucho);

                    }
                    catch
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Asignar la carga de una Sucursal a un Colaborador
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraColaborador(CargaTransportadora c)
        {

            try
            {
                _carga_transportadora.actualizarCargaTransportadoraColaborador(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraDatosVerificacion(CargaTransportadora c)
        {

            try
            {
                _carga_transportadora.actualizarCargaTransportadoraDatosVerificacion(c);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void eliminarCargaTransportadora(CargaTransportadora c)
        {

            try
            {
                _carga_transportadora.eliminarCargaTransportadora(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Importar una lista de Cargas.
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarCargasTransportadora(ref CargaTransportadora c, Colaborador col)
        {

            try
            {
                CargaTransportadora copia_carga = c;

                _carga_transportadora.agregarCargaTransportadora(ref copia_carga, col);

                foreach (CartuchoCargaTransportadora cartucho in copia_carga.Cartuchos)
                {
                    CartuchoCargaTransportadora copia_cartucho = cartucho;

                    copia_cartucho.Movimiento.ID = copia_carga.ID;

                    _cartucho_transportadora.agregarCartuchoCargaTransportadoraes(ref copia_cartucho);
                }



            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }



        

        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaTransportadora> listarCargasTransportadora(Colaborador c, EmpresaTransporte s, DateTime f, EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaTransportadora> cargas = _carga_transportadora.listarCargasTransportadoras(c, s, f, est);

                foreach (CargaTransportadora carga in cargas)
                {
                    CargaTransportadora copia = carga;
                    copia.Manifiesto = new BindingList<ManfiestoTransportadoraCarga>();
                    _cartucho_transportadora.obtenerCartuchosCargaTransportadora(ref copia, true);
                    //_carga_transportadora.obtenerDatosCargaTransportadora(ref copia);
                    //_carga_transportadora.obtenerManifiestosCargaTransportadora(ref copia);


                    //if (copia.Manifiesto != null)
                    //{

                    //    foreach (ManfiestoTransportadoraCarga m in copia.Manifiesto)
                    //    {
                    //        ManfiestoTransportadoraCarga copia_manifiesto = m;

                    //        copia_manifiesto.ListaBolsas = new BindingList<BolsaTransportadora>();
                    //        copia_manifiesto.ListaBolsas = _bolsa.listarBolsasTransportadoraPorManifiesto(ref copia_manifiesto);


                    //        foreach (BolsaTransportadora b in copia_manifiesto.ListaBolsas)
                    //        {
                    //            BolsaTransportadora copia_bolsa = b;
                    //            _montos_bolsa_transportadora.obtenerBolsaMontoSucursales(ref copia_bolsa);
                    //        }
                    //    }
                    //}
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }








        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaTransportadora> listarCargasTransportadoraAprobar(Colaborador c, EmpresaTransporte s, DateTime f, EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaTransportadora> cargas = _carga_transportadora.listarCargasTransportadorasPorAprobar(c, s, f, est);

                foreach (CargaTransportadora carga in cargas)
                {
                    CargaTransportadora copia = carga;
                    _cartucho_transportadora.obtenerCartuchosCargaTransportadora(ref copia, true);
 

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



      

        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaTransportadora> listarCargasTransportadoraPorAprobarCorregir(Colaborador c, EmpresaTransporte s, DateTime f,  EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaTransportadora> cargas = _carga_transportadora.listarCargasTransportadorasAprobacionCorreccion(c, s, f, est);

                foreach (CargaTransportadora carga in cargas)
                {
                    CargaTransportadora copia = carga;
                    _cartucho_transportadora.obtenerCartuchosCargaTransportadora(ref copia, true);

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaTransportadora> listarCargasTransportadoraManifiesto(Colaborador c, EmpresaTransporte s, DateTime f, EstadoAprobacionCargas est)
        {

            try
            {

                BindingList<CargaTransportadora> cargas = _carga_transportadora.listarCargasTransportadorasManifiesto(c, s, f, est);

                foreach (CargaTransportadora carga in cargas)
                {
                    CargaTransportadora copia = carga;
                    copia.Manifiesto = new BindingList<ManfiestoTransportadoraCarga>();
                    _cartucho_transportadora.obtenerCartuchosCargaTransportadora(ref copia, true);
                    _carga_transportadora.obtenerDatosCargaTransportadora(ref copia);
                    _carga_transportadora.obtenerColaboradoresCargaTransportadora(ref copia);
                    _carga_transportadora.obtenerManifiestosCargaTransportadora(ref copia);


                    if (copia.Manifiesto != null)
                    {

                        foreach (ManfiestoTransportadoraCarga m in copia.Manifiesto)
                        {
                            ManfiestoTransportadoraCarga copia_manifiesto = m;

                            copia_manifiesto.ListaBolsas = new BindingList<BolsaTransportadora>();
                            copia_manifiesto.ListaBolsas = _bolsa.listarBolsasTransportadoraPorManifiesto(ref copia_manifiesto);

                            foreach (BolsaTransportadora b in copia_manifiesto.ListaBolsas)
                            {
                                BolsaTransportadora copia_bolsa = b;
                                _montos_bolsa_transportadora.obtenerBolsaMontoSucursales(ref copia_bolsa);
                            }
                        }
                    }
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Verificar si una Carga ya está aprobado por gerente y verificada.
        /// </summary>
        /// <param name="c">Objeto Carga con los datos del carga</param>
        /// <returns>Valor que indica si el carga existe</returns>
        public bool verificarExisteCargaVerificada(CargaTransportadora c)
        {

            try
            {
                return _carga_transportadora.verificarExisteCargaVerificada(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Lista las cargas que se van a recibir para enviar a boveda
        /// </summary>
        /// <param name="marchamo">numero de marchamo a buscar</param>
        /// <returns></returns>
        public BindingList<CargaTransportadora> listarCargasTransportadora(String marchamo, EstadosCargasSucursales estado, Colaborador coordinador, EntregaRecibo entrega, DateTime fecha, byte? ruta)
        {
            try
            {

                BindingList<CargaTransportadora> cargas = _carga_transportadora.listarCargasSucursal(marchamo, estado, coordinador, entrega, fecha, ruta);

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Actualiza los datos de una carga Sucursal en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosRecepcionCargaTransportadoraes(CargaTransportadora carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaTransportadora copia = new CargaTransportadora();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;

                _carga_transportadora.agregarRecepcionTulaCargaTransportadora(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }






        /// Actualiza los datos de una carga Sucursal en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosEntregaCargaTransportadoras(CargaTransportadora carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaTransportadora copia = new CargaTransportadora();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _carga_transportadora.agregarRecepcionTulaCargaTransportadora(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<CargaTransportadora> listarCargasTransportadoraSinAsignarCajero(Colaborador c, EmpresaTransporte s, DateTime f)
        {

            try
            {

                BindingList<CargaTransportadora> cargas = _carga_transportadora.listarCargasTransportadorasSinAsignarCajero(s, f);

                foreach (CargaTransportadora carga in cargas)
                {
                    CargaTransportadora copia = carga;

                    _cartucho_transportadora.obtenerCartuchosCargaTransportadora(ref copia, true);
                    _carga_transportadora.obtenerDatosCargaTransportadora(ref copia);

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Obtener las cargas asignadas un cajero de Sucursales.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales</param>
        public BindingList<CargaTransportadora> listarCargasTransportadoraPorColaborador(Colaborador c, bool a)
        {

            try
            {
                BindingList<CargaTransportadora> cargas = _carga_transportadora.listarCargasTransportadorasPorCajero(c);

                foreach (CargaTransportadora carga in cargas)
                {
                    CargaTransportadora copia = carga;

                    _cartucho_transportadora.obtenerCartuchosCargaTransportadora(ref copia, a);
                    _carga_transportadora.obtenerDatosCargaTransportadora(ref copia);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        



        /// <summary>
        /// Autoasignar las cargas tomando en cuenta las rutas y los cajeros full.
        /// </summary>
        /// <param name="caj">Lista de cajeror a los cuales se asignarán la cargas</param>
        /// <param name="car">Lista de cargas que se asignarán</param>
        /// <returns>Lista de cajeros y sus respectivas cargas</returns>
        public Dictionary<Colaborador, List<CargaTransportadora>> autoAsignarCargasTransportadora(List<Colaborador> caj, BindingList<CargaTransportadora> car)
        {
            Dictionary<Colaborador, List<CargaTransportadora>> cargas_cajeros = new Dictionary<Colaborador, List<CargaTransportadora>>();


            int numero_cajero = 0;


            foreach (Colaborador cajero in caj)
                cargas_cajeros.Add(cajero, new List<CargaTransportadora>());

            while (car.Count > 0)
            {
                CargaTransportadora carga = car[0];
                Colaborador cajero = caj[numero_cajero];
                List<CargaTransportadora> cargas_cajero = cargas_cajeros[cajero];



                cargas_cajero.Add(carga);
                car.RemoveAt(0);


                numero_cajero++;

                // Validar si se llego al último cajero

                if (numero_cajero == caj.Count) numero_cajero = 0;
            }

            return cargas_cajeros;
        }



        /// <summary>
        /// Ligar o desligar la carga de un Sucursal del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraCierreTransportadora(CargaTransportadora c)
        {

            try
            {
                _carga_transportadora.actualizarCargaTransportadoraCierreSucursal(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener una lista de las cargas del cierre de un cajero de Sucursales.
        /// </summary>
        /// <param name="c">Objeto CierreCargaTransportadora con los datos del cierre del cajero de Sucursales</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasTransportadoraPorCierreTransportadora(CierreCargaTransportadora c)
        {

            try
            {
                return _carga_transportadora.listarCargasTransportadorasPorCierreTransportadoras(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        
        /// <summary>
        /// Actualiza los datos de una carga Sucursal en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosEntregaCargaTransportadora(Carga carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                CargaTransportadora copia = new CargaTransportadora();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.IdBolsa = carga.IDBolsa;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _carga_transportadora.agregarRecepcionTulaCargaTransportadora(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Actualizar los datos de la carga en una aprobacion
        /// </summary>
        /// <param name="c">Objeto CargaTransportadora con los datos de la carga</param>
        public void actualizarCargaTransportadoraAprobacionGerente(CargaTransportadora c, EstadoAprobacionCargas est)
        {

            try
            {
                _carga_transportadora.actualizarCargaTransportadoraAprobacoinGerente(c, est);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cargas Transportadora

        #region Cartucho Carga Transportadora

        /// <summary>
        /// Actualizar los datos del cartucho de un pedido de un Banco
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos del cartucho</param>
        public void actualizarCartuchoCargaTransportadora(CartuchoCargaTransportadora c)
        {

            try
            {
                _cartucho_transportadora.actualizarCartuchoCargaTransportadora(ref c);


                _cartucho_transportadora.actualizarCartuchoCargaTransportadoraCartucho(c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas descargadas de un cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos del pedido</param>
        public void actualizarCartuchoCargaTransportadoraCantidad(CartuchoCargaTransportadora c)
        {

            try
            {
                _cartucho_transportadora.actualizarCartuchoCargaTransportadoraCantidad(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Cartucho Carga Transportadora

        #region Cargas de Emergencia de Sucursales

        /// <summary>
        /// Registrar en el sistema la carga de emergencia de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga de emergencia</param>
        public void agregarCargaEmergenciaSucursal(ref CargaEmergenciaSucursal c)
        {

            try
            {
                _cargas_emergencia_sucursales.agregarCargaEmergenciaSucursal(ref c);

                foreach (CargaSucursal emergencia in c.Emergencias)
                    _carga_sucursales.actualizarCargaSucursalCargaEmergenciaSucursal(emergencia, c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Acutalizar en el sistema la carga de emergencia de un ATM.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga de emergencia</param>
        public void actualizarCargaEmergenciaSucursal(CargaEmergenciaSucursal c)
        {

            try
            {
                // Desligar las emergencias anteriores de la carga y registrar las nuevas

                CargaEmergenciaSucursal anterior = new CargaEmergenciaSucursal(id: c.ID);

                _cargas_emergencia_sucursales.obtenerEmergenciasCargaEmergenciaSucursal(ref anterior);

                foreach (CargaSucursal emergencia in c.Emergencias)
                {

                    if (anterior.Emergencias.Contains(emergencia))
                        anterior.quitarEmergencia(emergencia);
                    else
                        _carga_sucursales.actualizarCargaSucursalCargaEmergenciaSucursal(emergencia, c);

                }

                foreach (CargaSucursal emergencia in anterior.Emergencias)
                    _carga_sucursales.actualizarCargaSucursalCargaEmergenciaSucursal(emergencia, null);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de emergencia de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaEmergenciaATM con los datos de la carga</param>
        public void eliminarCargaEmergenciaSucursal(CargaEmergenciaSucursal c)
        {

            try
            {
                _cargas_emergencia_sucursales.eliminarCargaEmergenciaSucursal(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las cargas de emergencia por fecha.
        /// </summary>
        /// <param name="f">Fecha de las cargas que se listarán</param>
        public BindingList<CargaEmergenciaSucursal> listarCargasEmergenciaSucursales(DateTime f)
        {

            try
            {
                BindingList<CargaEmergenciaSucursal> cargas = _cargas_emergencia_sucursales.listarCargasEmergenciaSucursales(f);
               
                foreach (CargaEmergenciaSucursal carga in cargas)
                {
                    CargaEmergenciaSucursal copia_carga = carga;

                    _cargas_emergencia_sucursales.obtenerEmergenciasCargaEmergenciaSucursal(ref copia_carga);

                    foreach (CargaSucursal emergencia in copia_carga.Emergencias)
                    {
                        CargaSucursal copia_emegencia = emergencia;

                        _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia_emegencia, false);

    
                        copia_emegencia.recalcularMontosCarga();
                    }

                    copia_carga.reasignarEmergencias();
                    
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cargas de Emergencia de Sucursales

        #region Pedidos de Bancos



        /// <summary>
        /// Obtener datos de portavalor asignado a un pedido de banco
        /// </summary>
        /// <param name="c">Carga asignada al portavalor</param>
        /// <returns>Datos del portavalor</returns>
        public void listarPortavalorPorPedidoBanco(ref PedidoBancos p)
        {
            try
            {
                _pedido_bancos.listarPotavalorPedidoBanco(ref p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar los datos de la carga de un Banco
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBanco(PedidoBancos c)
        {

            try
            {
                _pedido_bancos.actualizarPedidoBanco(c);

                foreach (BolsaCargaBanco cartucho in c.Bolsas)
                {
                    BolsaCargaBanco copia_cartucho = cartucho;
                    try
                    {
                        if (copia_cartucho.ID > 0)
                            _bolsa_pedido_banco.actualizarBolsaPedidoBancos(ref copia_cartucho);
                        else
                            _bolsa_pedido_banco.agregarBolsaCargaBancos(ref copia_cartucho);

                    }
                    catch
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Asignar la carga de un Banco a un Colaborador
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBancoColaborador(PedidoBancos c)
        {

            try
            {
                _pedido_bancos.actualizarPedidoBancoscajero(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<PedidoBancos> listarPedidosBancoSinAsignarCajero(Colaborador c, Canal s, DateTime f, byte? r)
        {

            try
            {

                BindingList<PedidoBancos> cargas = _pedido_bancos.listarPedidosBancosSinAsignarCajero(s, f, r);

                foreach (PedidoBancos carga in cargas)
                {
                    PedidoBancos copia = carga;

                    _bolsa_pedido_banco.obtenerBolsaPedidoBanco(ref copia, true);
                    _pedido_bancos.obtenerDatosPedidoBanco(ref copia);

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Asignar la ruta a la carga de un Banco.
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBancoRuta(PedidoBancos c)
        {

            //try
            //{
            //    _cargas.actualizarCargaATMRuta(c);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }



        /// <summary>
        /// Asignar la ruta y la hora de llegada a la carga de un Banco
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBancoRutaHora(PedidoBancos c)
        {

            //try
            //{
            //    _cargas.actualizarCargaATMRutaHora(ref c);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }

        /// <summary>
        /// Actualizar el orden de las cargas de Bancos de una ruta específica.
        /// </summary>
        /// <param name="p">Lista de cargas de una ruta específica</param>
        public void actualizarPedidoBancoOrdenRuta(BindingList<PedidoBancos> p)
        {

            try
            {
                foreach (PedidoBancos pedido in p)
                {
                    _pedido_bancos.actualizarPedidoBancoOrdenRuta(pedido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="p">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBancosDatosVerificacion(PedidoBancos p)
        {

            try
            {
                _pedido_bancos.actualizarPedidoBancoDatosVerificacion(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un pedido de un Banco.
        /// </summary>
        /// <param name="p">Objeto PedidoBanco con los datos de un pedido</param>
        public void eliminarPedidoBanco(PedidoBancos p)
        {

            try
            {
                 _pedido_bancos.eliminarPedidoBanco(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Importar una lista de Cargas.
        /// </summary>
        /// <param name="p">Lista de cargas a importar</param>
        public void importarPedidosBanco(BindingList<PedidoBancos> p)
        {

            try
            {

                foreach (PedidoBancos pedido in p)
                {
                    PedidoBancos copia_bolsa = pedido;

                    _pedido_bancos.agregarPedidoBanco(ref copia_bolsa);

                    foreach (BolsaCargaBanco cartucho in copia_bolsa.Bolsas)
                    {
                        BolsaCargaBanco copia_cartucho = cartucho;

                        _bolsa_pedido_banco.agregarBolsaCargaBancos(ref copia_cartucho);
                    }

                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }



        /// <summary>
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="t">Objeto Colaborador con los datos de la tripulacion para el cual se genera la lista</param>
        /// <param name="c">Objeto Canal con el los datos del Canal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<PedidoBancos> listarPedidosBancos(Tripulacion t, Canal c, DateTime f, byte? r)
        {

            try
            {
                BindingList<PedidoBancos> pedidos = _pedido_bancos.listarPedidoBancoss(t, c, f, r);

                foreach (PedidoBancos pedido in pedidos)
                {
                    PedidoBancos copia = pedido;
                    copia.Manifiesto = new BindingList<ManifiestoPedidoBanco>();
                    _bolsa_pedido_banco.obtenerBolsaPedidoBanco(ref copia, true);
                    _pedido_bancos.obtenerDatosPedidoBanco(ref copia);



                    _pedido_bancos.obtenerManifiestosPedidoBanco(ref copia);



                    foreach (ManifiestoPedidoBanco m in copia.Manifiesto)
                    {
                        ManifiestoPedidoBanco copia_manifiesto = m;
                        BindingList<BolsaBanco> _bolsas_banco = new BindingList<BolsaBanco>();
                        _bolsa.listarBolsasBancoPorManifiesto(ref copia_manifiesto);

                        foreach (BolsaBanco b in copia_manifiesto.Serie_Tula)
                        {
                            BolsaBanco copia_bolsa = b;

                            _montos_bolsas_bancos.obtenerBolsaMontoBancos(ref copia_bolsa);
                        }
                    }


                    //Cambiar a muchos manifiestos
                    //Foreach manifiesto en copia.Manifiestos{
                    // copia.Manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(copia.Manifiesto);
                    //}

                    //if (c.Cargas_listas == false)
                    //{
                        _pedido_bancos.obtenerDatosVerificacionCarga(ref copia);
                    //}
                 
                }

                return pedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="t">Objeto Colaborador con los datos de la tripulacion para el cual se genera la lista</param>
        /// <param name="c">Objeto Canal con el los datos del Canal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<PedidoBancos> listarPedidosBancosRoadnet(Tripulacion t, Canal c, DateTime f, byte? r)
        {

            try
            {
                BindingList<PedidoBancos> pedidos = _pedido_bancos.listarPedidoBancossRoadnet(t, c, f, r);

                foreach (PedidoBancos pedido in pedidos)
                {
                    PedidoBancos copia = pedido;

                    _bolsa_pedido_banco.obtenerBolsaPedidoBanco(ref copia, true);
                    _pedido_bancos.obtenerDatosPedidoBanco(ref copia);

                }

                return pedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las Cargas registrados en el sistema para exportar en Excel.
        /// </summary>
        /// <returns>Lista de las cargas registrados en el sistema para exportar en Excel.</returns>
        public DataTable listarCargasBancoExportar(DateTime f)
        {

            try
            {
                DataTable atms = _pedido_bancos.listarCargasBancosExportacion(f);


                return atms;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Actualiza Ruta y horas programadas de las cargas
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarRutasPedidoBanco(BindingList<CargaSucursal> c)
        {

            try
            {

                foreach (CargaSucursal carga in c)
                {
                    CargaSucursal copia_carga = carga;

                    //_cargas.actualizarCargaATMRutaHoraImportacion(ref copia_carga);


                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }

        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<PedidoBancos> listarPedidosBanco(Colaborador c, Canal s, DateTime f, byte? r)
        {

            try
            {
                BindingList<PedidoBancos> cargas = null;
                //BindingList<CargaATM> cargas = _cargas.listarCargas(c, s, f, r);

                //foreach (CargaATM carga in cargas)
                //{
                //    CargaATM copia = carga;

                //    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                //    _cargas.obtenerDatosCargaATM(ref copia);
                //    _cargas.obtenerDatosVerificacionCarga(ref copia);
                //}

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        

       
        /// <summary>
        /// Obtener una lista de las cargas de Bancos no asignadas en una fecha dada.
        /// </summary>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <returns>Lista de cargas no asignadas</returns>
        public BindingList<PedidoBancos> listarPedidosBancosNoAsignados(DateTime f)
        {

            try
            {
                BindingList<PedidoBancos> cargas = null;
                //BindingList<CargaSucursal> cargas = _cargas.listarCargasATMs(f);

                //foreach (CargaSucursal carga in cargas)
                //{
                //    CargaSucursal copia = carga;

                //    _cartuchos_cargas.obtenerCartuchosCargaATM(ref copia, true);
                //}

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener las cargas asignadas un Banco.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Banco</param>
        public BindingList<PedidoBancos> listarPedidoBancoPorColaborador(Colaborador c, bool a)
        {

            try
            {
                 

          
                BindingList<PedidoBancos> cargas = _pedido_bancos.listarPedidosBancoPorCajero(c);

                foreach (PedidoBancos carga in cargas)
                {
                    PedidoBancos copia = carga;

                    _bolsa_pedido_banco.obtenerBolsaPedidoBanco(ref copia, a);
                    _pedido_bancos.obtenerDatosPedidoBanco(ref copia);
                }

             


                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


       

        /// <summary>
        /// Listar las Cargas registrados en el sistema para exportar en Excel.
        /// </summary>
        /// <returns>Lista de las cargas registrados en el sistema para exportar en Excel.</returns>
        public DataTable listarCargasSucursalesExportar(DateTime f)
        {

            try
            {
                DataTable atms = _carga_sucursales.listarCargasSucursalesExportacion(f);


                return atms;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualiza la lista de las cargas del roadnet
        /// </summary>
        /// <param name="f">Fecha de la carga</param>
        public void ActualizarCargasBancosRoadnet(DateTime f)
        {

            try
            {

                _pedido_bancos.actualizarCargaBancoDatosRoadnet(f);


            }
            catch (Exception ex)
            {
                guardarArchivo(ex.Message, f);
            }

        }



        /// <summary>
        /// Actualiza los datos de una carga de Banco en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosRecepcionPedidoBanco(Carga carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                PedidoBancos copia = new PedidoBancos();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _pedido_bancos.agregarRecepcionTulaPedidoBanco(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Actualiza los datos de una carga de Banco en su recibido de un blindado por parte de boveda
        /// </summary>
        /// <param name="carga">Objeto Carga con los datos de la carga</param>
        /// <param name="registro">Objeto colaborador con los datos del colaborador que realizo la recepcion</param>
        /// <param name="fecha">Fecha que se da el registro de recibido</param>
        /// <param name="tipo">Tipo de entrega o recibo</param>
        public void actualizarDatosEntregaPedidoBanco(Carga carga, Colaborador registro, DateTime fecha, TipoEntregas tipo)
        {
            try
            {
                PedidoBancos copia = new PedidoBancos();
                copia.ID = carga.ID;
                copia.TipoEntregas = tipo;
                copia.ColaboradorRecibidoBoveda = registro;
                copia.HoraRecibidoBoveda = DateTime.Now;
                _pedido_bancos.agregarRecepcionTulaPedidoBanco(ref copia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Ligar o desligar la carga de un Banco del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto PedidoBancos con los datos de la carga</param>
        public void actualizarPedidoBancoCierreBanco(PedidoBancos c)
        {

            try
            {
                _pedido_bancos.actualizarPedidoBancoCierreBanco(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Obtener una lista de las cargas del cierre de un cajero de Bancos.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre del cajero de Sucursales</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarCargasBancosPorCierreBancoss(CierreCargaBanco c)
        {

            try
            {
                return _pedido_bancos.listarCargasBancosPorCierreBancos(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion Pedido Bancos

        #region Bolsa Pedido Banco

        /// <summary>
        /// Actualizar los datos del cartucho de un pedido de un Banco
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos del cartucho</param>
        public void actualizarBolsaCargaBanco(BolsaCargaBanco c)
        {

            try
            {
                _bolsa_pedido_banco.actualizarBolsaPedidoBancos(ref c);

              
                    _bolsa_pedido_banco.actualizarBolsaPedidoBancosCartucho(c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas descargadas de un cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos del pedido</param>
        public void actualizarBolsaPedidoBancoCantidad(BolsaCargaBanco c)
        {

            try
            {
                _bolsa_pedido_banco.actualizarBolsaPedidoBancosCantidad(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar la cantidad de formulas cargadas del cartucho de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto CartuchoCargaATM con los datos del cartucho</param>
        public void actualizarBolsapedidoCantidad(CartuchoCargaATM c)
        {

            try
            {
                _cartuchos_cargas.actualizarCartuchoCargaATMCantidad(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Bolsa Pedido Banco

        #region Cartucho Carga Sucursal



        /// <summary>
        /// Actualizar los datos del cartucho de un pedido de un Banco
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos del cartucho</param>
        public void actualizarCartuchoCargaSucursal(CartuchoCargaSucursal c)
        {

            try
            {
                _cartuchos_cargas_sucursales.actualizarCartuchoCargaSucursal(ref c);

              
                    _cartuchos_cargas_sucursales.actualizarCartuchoCargaSucursalCartucho(c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas descargadas de un cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos del pedido</param>
        public void actualizarCartuchoCargaSucursalCantidad(CartuchoCargaSucursal c)
        {

            try
            {
                _cartuchos_cargas_sucursales.actualizarCartuchoCargaSucursalCantidad(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        #endregion Cartucho Carga Sucursal

        #region Cierres de Sucursales

        /// <summary>
        /// Registrar un cierre de Sucursales en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cierre</param>
        public void agregarCierreSucursal(ref CierreCargaSucursal c)
        {

            try
            {
                BindingList<Denominacion> denominaciones_cargas = _denominaciones.listarDenominacionesCargasSucursales();
              
                _cierre_sucursal.agregarCierreSucursal(ref c);


               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de Sucursales.
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cierre</param>
        public void actualizarCierreSucursal(CierreCargaSucursal c)
        {

            try
            {
                _cierre_sucursal.actualizarCierreSucursal(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar como terminado un cierre de Sucursales
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cierre</param>
        public void actualizarCierreSucursalTerminar(CierreCargaSucursal c)
        {

            try
            {
                _cierre_sucursal.actualizarCierreSucursalTerminar(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public bool verificarCierreSucursal(ref CierreCargaSucursal c)
        {

            try
            {
                bool existe = _cierre_sucursal.verificarCierreSucursal(ref c);

                if (existe)
                {
                    _carga_sucursales.obtenerCargasSucursalCierreSucursal(ref c);
                    
                    foreach (CargaSucursal carga in c.Cargas)
                    {
                        CargaSucursal copia = carga;
                        copia.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
                        _cartuchos_cargas_sucursales.obtenerCartuchosCargaSucursal(ref copia, false);
                        _carga_sucursales.obtenerDatosCargaSucursal(ref copia);

                        _carga_sucursales.obtenerManifiestosCargaSucursal(ref copia);

                        if (copia.Manifiesto != null)
                        {

                            foreach (ManifiestoSucursalCarga m in copia.Manifiesto)
                            {
                                ManifiestoSucursalCarga copia_manifiesto = m;

                                copia_manifiesto.ListaBolsas = new BindingList<Bolsa>();
                                copia_manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(ref copia_manifiesto);

                                foreach (Bolsa b in copia_manifiesto.ListaBolsas)
                                {
                                    Bolsa copia_bolsa = b;
                                    _montos_bolsas_sucursales.obtenerBolsaMontoSucursales(ref copia_bolsa);
                                }
                            }
                        }

                       
                        

                        //copia.Manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(copia.Manifiesto);
                         if (c.Cargas_listas == false)
                        {
                            _carga_sucursales.obtenerDatosVerificacionCarga(ref copia);
                        }

                       //copia.Cajero.Nombre = null;
                    }

                }

                return existe;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si un cajero tiene un cierre pendiente de finalizar.
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cajero</param>
        /// <returns>Valor que indica si el cajero tiene un cierre pendiente</returns>
        public bool verificarCierreSucursalPendiente(ref CierreCargaSucursal c)
        {

            try
            {
                return _cierre_sucursal.verificarCierreSucursalPendiente(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cierres de Sucursales

        #region Cargas Genericas


        ///// <summary>
        ///// Actualizar el orden de las cargas de ATM's de una ruta específica.
        ///// </summary>
        ///// <param name="c">Lista de cargas de una ruta específica</param>
        //public void actualizarCargasOrdenRuta(BindingList<Carga> c)
        //{

        //    try
        //    {
        //        //foreach (Carga carga in c)
        //            //_cargas.actualizarCargaATMOrdenRuta(carga);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        /// <summary>
        /// Lista las cargas totales para recepcion de Tulas 
        /// </summary>
        /// <param name="marchamo">Numero de marchamo adicional o tula para obtener una carga respectiva</param>
        /// <returns></returns>
        public BindingList<Carga> listarCargasTotales(string marchamo, EstadosPedidoBanco estadobanco, EntregaRecibo estadosucursal,
                                                        EstadoDescargadaATM estadoAtm, byte? ruta, DateTime fecha, int estado)
        {

            try
            {
                BindingList<Carga> cargas = _cargas.listarCargas(marchamo, estadobanco, estadosucursal, estadoAtm, ruta, fecha, estado);

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        /// <summary>
        /// Lista las cargas totales para recepcion de Tulas 
        /// </summary>
        /// <param name="marchamo">Numero de marchamo adicional o tula para obtener una carga respectiva</param>
        /// <returns></returns>
        public BindingList<Carga> listarDescargasTotales(string marchamo, EstadosPedidoBanco estadobanco, EntregaRecibo estadosucursal,
                                                        EstadoDescargadaATM estadoAtm, byte? ruta, DateTime fecha, int estado)
        {

            try
            {
                BindingList<Carga> cargas = _cargas.listarDescargas(marchamo, estadobanco, estadosucursal, estadoAtm, ruta, fecha, estado);

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Cargas Genericas

        #region Covertir Numeros a Letras
       
        public void Convertir()
        {
        } 
          string[] NumeroBase ={
                                 "",
                                 "UNO",
                                 "DOS",
                                 "TRES",
                                 "CUATRO",
                                 "CINCO",
                                 "SEIS",
                                 "SIETE",
                                 "OCHO",
                                 "NUEVE",
                                 "DIEZ",
                                 "ONCE",
                                 "DOCE",
                                 "TRECE",
                                 "CATORCE",
                                 "QUINCE",
                                 "DIECISEIS",
                                 "DIECISIETE",
                                 "DIECIOCHO",
                                 "DIECINUEVE",
                            };
        string[] NumeroBase2 = {
                                   "",
                                   "",
                                   "VEINTE",
                                   "TREINTA",
                                   "CUARENTA",
                                   "CINCUENTA",
                                   "SESENTA",
                                   "SETENTA",
                                   "OCHENTA",
                                   "NOVENTA"
                               };

        public string convertirMontoaLetras(string numero)
        {
            string Resultado = "";
            int Tama_Cadena = numero.Length;
            if (Tama_Cadena < 4)//3
                Resultado = trio(Tama_Cadena, numero);
            else if (Tama_Cadena < 7)//6
            {
                int millares = Tama_Cadena - 3;
                if (numero.Substring(0, 1) == "1" && Tama_Cadena == 4)
                    Resultado = "MIL " + trio(3, numero.Substring(millares, 3));
                else
                    Resultado = trio(millares, numero.Substring(0, millares)) + " MIL " + trio(3, numero.Substring(millares, 3));
            }
            else if (Tama_Cadena < 10)//9
            {

                int millares = Tama_Cadena - 3;
                int millon = Tama_Cadena - 6;
                if (numero.Substring(0, 1) == "1" && Tama_Cadena == 7)
                {
                    if (trio(3, numero.Substring(millon, 3)) == "")
                        Resultado = "UN MILLON " + trio(3, numero.Substring(millares, 3));
                    else
                        Resultado = "MILLON " + trio(3, numero.Substring(millon, 3)) + " MIL " + trio(3, numero.Substring(millares, 3));
                }
                else
                {
                    if (trio(3, numero.Substring(millon, 3)) == "")
                        Resultado = trio(millon, numero.Substring(0, millon)) + " MILLONES " + trio(3, numero.Substring(millon, 3)) + " " + trio(3, numero.Substring(millares, 3));
                    else
                        Resultado = trio(millon, numero.Substring(0, millon)) + " MILLONES " + trio(3, numero.Substring(millon, 3)) + " MIL " + trio(3, numero.Substring(millares, 3));
                }
            }
            else if (Tama_Cadena < 13)
            {
                if (Tama_Cadena == 11)
                    numero = "0" + numero;
                if (Tama_Cadena == 10)
                    numero = "00" + numero;
                Resultado = trio(3, numero.Substring(0, 3)) + " MIL " + trio(3, numero.Substring(3, 3)) + " MILLONES " + trio(3, numero.Substring(6, 3)) + " MIL " + trio(3, numero.Substring(9, 3));
            }
            else if (Tama_Cadena < 16)
                Resultado = trio(3, numero.Substring(0, 3)) + " BILLONES " + trio(3, numero.Substring(4, 3)) + " MIL " + trio(3, numero.Substring(7, 3)) + " MILLONES " + trio(3, numero.Substring(10, 3)) + " MIL " + trio(3, numero.Substring(13, 3));
            else if (Tama_Cadena < 19)
                Resultado = trio(3, numero.Substring(0, 3)) + " MIL " + trio(3, numero.Substring(4, 3)) + " BILLONES " + trio(3, numero.Substring(7, 3)) + " MIL " + trio(3, numero.Substring(10, 3)) + " MILLONES " + trio(3, numero.Substring(13, 3)) + " MIL " + trio(3, numero.Substring(13, 3));
            else if (Tama_Cadena < 21)
                Resultado = "";
            else if (Tama_Cadena < 24)
                Resultado = "";

            return Resultado;

        }

        string Unidades(string numx)
        {
            return NumeroBase[Convert.ToInt32(numx)];
        }
        string Decenas(string numx)
        {
            string Pre = "";
            int Num = Convert.ToInt32(numx);
            if (Num < 20)
            {
                Pre = NumeroBase[Num];
            }
            else
            {
                if (numx.Substring(0, 1) == "2")
                    Pre = NumeroBase2[2] + Unidades(numx.Substring(1, 1));
                else
                {
                    if (numx.Substring(1, 1) == "0")
                        Pre = NumeroBase2[Convert.ToInt32(numx.Substring(0, 1))];
                    else
                        Pre = NumeroBase2[Convert.ToInt32(numx.Substring(0, 1))] + " Y " + Unidades(numx.Substring(1, 1));
                }
            }
            return Pre;
        }
        string Centenas(string numx)
        {
            string Pre = "";
            if (numx.Substring(0, 1) == "1")
            {
                if (numx.Substring(1, 1) == "0" && numx.Substring(2, 1) == "0")
                    Pre = "CIEN ";
                else
                    Pre = "CIENTO " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "0")
            {
                Pre = "" + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "5")
            {
                Pre = "QUINIENTOS " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "7")
            {
                Pre = "SETECIENTOS " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "9")
            {
                Pre = "NOVECIENTOS " + Decenas(numx.Substring(1, 2));
            }
            else
            {
                Pre = NumeroBase[Convert.ToInt32(numx.Substring(0, 1))] + "CIENTOS " + Decenas(numx.Substring(1, 2));
            }
            return Pre;
        }
        string trio(int cant, string Val)
        {
            string CadenaFinal = "";
            switch (cant)
            {
                case 1: CadenaFinal = Unidades(Val);
                    break;
                case 2: CadenaFinal = Decenas(Val);
                    break;
                case 3: CadenaFinal = Centenas(Val);
                    break;
            }
            return CadenaFinal;

        }
        

        #endregion

        #region Mutilados

        /// <summary>
        /// Obtener una lista bolsas de las cargas de Sucursales.
        /// </summary>
        /// <param name="c">Objeto CierreCargaSucursal con los datos del cierre del cajero de Sucursales</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public BindingList<Bolsa> listarTulasSucursales()
        {

            try
            {
                return _bolsa.listarBolsasSucursales();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


         /// <summary>
        /// Importar una lista de Cargas.
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarEfectivoMutilado(BindingList<Mutilado> m)
        {

            try
            {

                foreach (Mutilado mutilado in m)
                {
                    Mutilado copia_mutilado = mutilado;

                    _mutilado.agregarEfectivoMutilado(ref copia_mutilado);

                    foreach (CartuchoMutilado cartucho in copia_mutilado.Cartuchos)
                    {
                        CartuchoMutilado copia_cartucho = cartucho;
                        _cartucho_efectivo_mutilado.agregarCartuchoEfectivoMutilado(ref copia_cartucho);
                    }

                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }

         /// <summary>
        /// actualiza un registro de Efectivo Mutilado.
        /// </summary>
        /// <param name="m">Objeto Mutilado con los datos del registro de efectivo mutilado</param>
        public void actualizarEfectivoMutilado(Mutilado m)
        {

            try
            {
                _mutilado.actualizarEfectivoMutilado(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Mutilados

        #region Cartuchos Mutilados

        /// <summary>
        /// Registrar un nuevo cartucho de efectivo mutilado.
        /// </summary>
        /// <param name="m">Objeto CatuchoMutilado con los datos del nuevo cartucho</param>
        public void agregarCatuchoEfectivoMutilado(ref CartuchoMutilado c)
        {

            try
            {
                _cartucho_efectivo_mutilado.agregarCartuchoEfectivoMutilado(ref c);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


         /// <summary>
        /// Actualizar los datos del cartucho de un pedido de un Banco
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos del cartucho</param>
        public void actualizarCartuchoEfectivoMutilado(CartuchoMutilado c)
        {

            try
            {
               _cartucho_efectivo_mutilado.actualizarCartuchoEfectivoMutilado(c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


         #endregion Cartuchos Mutilados

        #region Asignacion Grupos CEF

        /// <summary>
        /// funcion para obtener un numero aleatorio unico (sin repetir), 
        /// para ello los numeros son contenidos en un array, del cual se van eliminando.        
        /// </summary>
        /// <returns>numero aleatorio sin repetir, si no hay mas numeros retorna -1</returns>
        public BindingList<Colaborador> getRandomCajerosCEF(List<Colaborador> cajeros, int numero_cajas)
        {
            BindingList<Colaborador> _cajas_cajeros = new BindingList<Colaborador>();

            Random random_cajeros = new Random();

            int cantidad = numero_cajas;

            List<int> numeros_cajas = new List<int>(cantidad);
            int j = 0;

            for (int i = 1; i <= cantidad; i++)
            {
                if (i >= cajeros.Count && cajeros.Count < cantidad)
                {
                    numeros_cajas.Add(j);
                    j++;
                }
                else
                    numeros_cajas.Add(i);

            }

            for (int i = 1; i <= cantidad; i++)
            {
                // si no existen mas numeros en el array, se sale con -1.
                if (numeros_cajas.Count < 0) numeros_cajas = new List<int>(cantidad);

                // inicializar el objeto para manejar numeros aleatorios
                Random random = new Random();

                // obtener un numero aleatorio entre los existentes en el array
                int randcaja = random.Next(numeros_cajas.Count);

                // obtener el numero real que contiene esa posicion del array
                //Colaborador cajero = cajeros[randcaja];

                Colaborador cajero = cajeros[i-1];

               // cajero.Caja = randcaja + 1;
                cajero.Caja = i;

                _cajas_cajeros.Add(cajero);

                // borrar el numero del array para que no se vuelva a obtener
                numeros_cajas.RemoveAt(randcaja);
                //cajeros.Remove(cajero);

            }
            // retornar el numero obtenido
            return _cajas_cajeros;


        }


        #endregion Asignacion Grupos CEF

        #region Cargas Totales

        /// <summary>
        /// Actualiza el orden de la hoja de ruta
        /// </summary>
        /// <param name="c">Objeto Carga con los datos de la carga</param>
        public void actualizarCargasTotalesOrdenRuta(BindingList<Carga> c)
        {

            try
            {
                foreach (Carga carga in c)
                    _cargas.actualizarCargasTotalesOrdenRuta(carga);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cargas Totales

        #region Cierres de Bancos

        /// <summary>
        /// Registrar un cierre de bancos en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre</param>
        public void agregarCierreBanco(ref CierreCargaBanco c)
        {

            try
            {
                BindingList<Denominacion> denominaciones_cargas = _denominaciones.listarDenominacionesCargasSucursales();

                _cierre_bancos.agregarCierreBanco(ref c);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de Bancos.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBancos con los datos del cierre</param>
        public void actualizarCierreBancos(CierreCargaBanco c)
        {

            try
            {
                _cierre_bancos.actualizarCierreBanco(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar como terminado un cierre de Bancos
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre</param>
        public void actualizarCierreBancoTerminar(CierreCargaBanco c)
        {

            try
            {
                _cierre_bancos.actualizarCierreBancoTerminar(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public bool verificarCierreBanco(ref CierreCargaBanco c)
        {

            try
            {
                bool existe = _cierre_bancos.verificarCierreBanco(ref c);

                if (existe)
                {
                    _pedido_bancos.obtenerCargasBancoCierreBanco(ref c);

                    foreach (PedidoBancos carga in c.Cargas)
                    {
                        PedidoBancos copia = carga;
                        copia.Manifiesto = new BindingList<ManifiestoPedidoBanco>();
                        _bolsa_pedido_banco.obtenerBolsaPedidoBanco(ref copia, false);
                        _pedido_bancos.obtenerDatosPedidoBanco(ref copia);
                        _pedido_bancos.obtenerManifiestosPedidoBanco(ref copia);



                        foreach (ManifiestoPedidoBanco m in copia.Manifiesto)
                        {
                            ManifiestoPedidoBanco copia_manifiesto = m;
                            BindingList<BolsaBanco> _bolsas_banco = new BindingList<BolsaBanco>();
                           _bolsa.listarBolsasBancoPorManifiesto(ref copia_manifiesto);

                           foreach (BolsaBanco b in copia_manifiesto.Serie_Tula)
                           {
                               BolsaBanco copia_bolsa = b;

                               _montos_bolsas_bancos.obtenerBolsaMontoBancos(ref copia_bolsa);
                           }
                        }


                        //Cambiar a muchos manifiestos
                        //Foreach manifiesto en copia.Manifiestos{
                        // copia.Manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(copia.Manifiesto);
                    //}

                        if (c.Cargas_listas == false)
                        {
                            _pedido_bancos.obtenerDatosVerificacionCarga(ref copia);
                        }

                        //copia.Cajero.Nombre = null;
                    }

                }

                return existe;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si un cajero tiene un cierre pendiente de finalizar.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cajero</param>
        /// <returns>Valor que indica si el cajero tiene un cierre pendiente</returns>
        public bool verificarCierreBancoPendiente(ref CierreCargaBanco c)
        {

            try
            {

                bool existe = _cierre_bancos.verificarCierreBancoPendiente(ref c);

                if (existe)
                {
                    _pedido_bancos.obtenerCargasBancoCierreBanco(ref c);

                    foreach (PedidoBancos carga in c.Cargas)
                    {
                        PedidoBancos copia = carga;

                        copia.Manifiesto = new BindingList<ManifiestoPedidoBanco>();

                        _bolsa_pedido_banco.obtenerBolsaPedidoBanco(ref copia, false);
                        _pedido_bancos.obtenerDatosPedidoBanco(ref copia);

                        _pedido_bancos.obtenerManifiestosPedidoBanco(ref copia);



                        foreach (ManifiestoPedidoBanco m in copia.Manifiesto)
                        {
                            ManifiestoPedidoBanco copia_manifiesto = m;

                            copia_manifiesto.Serie_Tula = new BindingList<BolsaBanco>();
                            _bolsa.listarBolsasBancoPorManifiesto(ref copia_manifiesto);

                            foreach (BolsaBanco b in copia_manifiesto.Serie_Tula)
                            {
                                BolsaBanco copia_bolsa = b;

                                _montos_bolsas_bancos.obtenerBolsaMontoBancos(ref copia_bolsa);
                            }
                        }

                        //Cambiar a muchos manifiestos
                        //Foreach manifiesto en copia.Manifiestos{
                        // copia.Manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(copia.Manifiesto);
                        //}

                        if (c.Cargas_listas == false)
                        {
                            _pedido_bancos.obtenerDatosVerificacionCarga(ref copia);
                        }

                        //copia.Cajero.Nombre = null;
                    }

                }

                return existe;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Cierres de Bancos

        #region Reporte Revision Vehiculo

        /// <summary>
        /// Obtener el reporte 
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre</param>
        public BindingList<RevisionVehiculo> obtenerReporteRevisionVehiculo(DateTime fi, DateTime ff, Colaborador chof, Vehiculo v, int ru)
        {

            try
            {
                return _vehiculos.listarRevisionVehiculos(fi, ff, v, chof, ru);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Reporte Revision Vehiculo

        #region Reporte Revision Portavalor

        /// <summary>
        /// Obtiene un reporte de las revisiones del portavalor
        /// </summary>
        /// <param name="fi">Fecha Inicio</param>
        /// <param name="ff">Fecha Fin</param>
        /// <param name="chof">Colaborador a Buscar</param>
        /// <param name="ru">Ruta</param>
        /// <returns>Una lista de Revisiones</returns>
        public BindingList<RevisionFinalPortavalor> obtenerReporteRevisionPortavalor(DateTime fi, DateTime ff, Colaborador chof, int ru)
        {

            try
            {
                return _equipos.listarRevisionPortavalor(fi, ff, chof, ru);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Reporte Revision Portavalor

        #region Validacion Puntos Atencion

        /// <summary>
        /// Importar una lista de Puntos de Atencion con Tarifas a Comparar.
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarPuntosAtencionFacturacion(BindingList<PuntoAtencion> c)
        {
            try
            {
                foreach (PuntoAtencion carga in c)
                {
                    PuntoAtencion copia_carga = carga;

                    if (!_punto_atencion.validarPuntosAtencionCliente(ref copia_carga))
                    {
                        _punto_atencion.agregarPuntoAtencion(ref copia_carga);
                    }
                    else
                    {
                        _punto_atencion.actualizarPuntoAtencion(ref copia_carga);
                    }
                }
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }
        }






        /// <summary>
        /// Importar una lista de Puntos de Atencion con Tarifas a Comparar.
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarPuntosAtencionFacturacionPedidos(BindingList<PuntoAtencion> c)
        {


            try
            {

                foreach (PuntoAtencion carga in c)
                {
                    PuntoAtencion copia_carga = carga;

                    if (!_punto_atencion.validarPuntosAtencionClientePedio(ref copia_carga))
                    {
                        _punto_atencion.agregarPuntoAtencionPedido(ref copia_carga);
                    }
                    else
                    {
                        _punto_atencion.actualizarPuntoAtencionPedido(ref copia_carga);
                    }



                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }

        /// <summary>
        /// Lista las Inconsistencias obtenidas en la validación de planillas
        /// </summary>
        /// <param name="f">Fecha que se dio la validación</param>
        /// <param name="c">Cliente especifico para buscar inconsistencia de este</param>
        /// <param name="inc">Tipo de Inconsistencia a buscar</param>
        /// <returns>Lista de PuntoAtencion que tienen una inconsistencia</returns>
        public BindingList<PuntoAtencion> obtenerPuntoAtencionInconsistencia(DateTime f, DateTime fin, EmpresaTransporte c, InconsistenciaFacturacion inc)
        {
            return _punto_atencion.listarPuntosAtencionInconsistencias(f, fin, c, inc);
        }


        /// <summary>
        /// Obtiene una lista de los puntos a exportar
        /// </summary>
        /// <param name="f">Fecha de Inicio</param>
        /// <param name="ff">Fecha Fin</param>
        /// <param name="e">Transportadora</param>
        /// <returns>Una lista de Puntos de Atencion</returns>
        public DataTable listarPuntoAtencionPedidos(DateTime f, DateTime ff, EmpresaTransporte e, int tipo)
        {

            try
            {
                return _punto_atencion.listarPuntosFacturacionPedidosExportacion(f,ff, e, tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion Validacion Puntos Atencion

        #region Pedidos Niquel

        /// <summary>
        /// Actualizar los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void actualizarPedidoNiquel(PedidoNiquel c)
        {

            try
            {
                _pedido_niquel.actualizarPedidoNiquel(c);

                foreach (CartuchosNiquel cartucho in c.Cartuchos)
                {
                    CartuchosNiquel copia_cartucho = cartucho;
                    try
                    {
                        if (copia_cartucho.ID > 0)
                            _cartuchos_niquel.actualizarCartuchosNiquel(ref copia_cartucho);
                        else
                            _cartuchos_niquel.agregarCartuchosNiqueles(ref copia_cartucho);

                    }
                    catch
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }






        /// <summary>
        /// Ligar o desligar la carga de un ATM del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void actualizarCierrePedidoNiquel(PedidoNiquel c)
        {

            try
            {
                _pedido_niquel.actualizarPedidoNiquelCierreNiquel(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Asignar la carga de un ATM a un cajero.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void actualizarPedidoNiquelCajero(PedidoNiquel c)
        {

            try
            {
                _pedido_niquel.actualizarPedidoNiquelColaborador(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

      




       


        /// <summary>
        /// Actualizar los datos de verificación de una carga.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con losno, datos de la carga</param>
        public void actualizarPedidoNiquelDatosVerificacion(PedidoNiquel c)
        {

            try
            {
                _pedido_niquel.actualizarPedidoNiquelDatosVerificacion(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto PedidoNiquel con los datos de la carga</param>
        public void eliminarPedidoNiquel(PedidoNiquel c, Colaborador col)
        {

            try
            {
                _pedido_niquel.eliminarPedidoNiquel(c, col);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
     


     

        /// <summary>
        /// Listar las cargas por fecha, cajero, ATM y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's para el cual se genera la lista</param>
        /// <param name="a">Objeto ATM con los datos del ATM para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<PedidoNiquel> listarPedidosNiquel(PuntoVenta a, DateTime f, Cliente cl, EmpresaTransporte emp)
        {

            try
            {
                BindingList<PedidoNiquel> cargas = _pedido_niquel.listarPedidosNiquel(a, f, cl, emp);

                foreach (PedidoNiquel carga in cargas)
                {
                    PedidoNiquel copia = carga;

                    _cartuchos_niquel.obtenerCartuchosPedidoNiquel(ref copia, true);
                    _pedido_niquel.obtenerDatosPedidoNiquel(ref copia);
                    _pedido_niquel.obtenerDatosVerificacionCarga(ref copia);

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



      



        
        /// <summary>
        /// Obtener las cargas asignadas un cajero de ATM's.
        /// </summary>
        /// <param name="a">Parámetro que indica si se mostrarán los cartuchos anulados</param>
        /// <param name="c">Objeto Colaborador con los datos del cajero de ATM's</param>
        public BindingList<PedidoNiquel> listarPedidosNiquelPorCajero(Colaborador c, bool a)
        {

            try
            {
                BindingList<PedidoNiquel> cargas = _pedido_niquel.listarPedidosNiquelPorCajero(c);

                foreach (PedidoNiquel carga in cargas)
                {
                    PedidoNiquel copia = carga;

                    _cartuchos_niquel.obtenerCartuchosPedidoNiquel(ref copia, a);
                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       
       

        /// <summary>
        /// Obtener una lista de las cargas del cierre de un cajero de Niquel
        /// </summary>
        /// <param name="c">Objeto CierreNiquel con los datos del cierre del cajero de Niquel</param>
        /// <returns>Tabla con la lista de cargas</returns>
        public DataTable listarPedidosNiquelPorCierreNiquel(CierreNiquel c)
        {

            try
            {
                return _pedido_niquel.listarPedidoNiquelPorCierreNiquel(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    
       




        /// <summary>
        /// Autoasignar las cargas tomando en cuenta las rutas y los cajeros full.
        /// </summary>
        /// <param name="caj">Lista de cajeror a los cuales se asignarán la cargas</param>
        /// <param name="car">Lista de cargas que se asignarán</param>
        /// <returns>Lista de cajeros y sus respectivas cargas</returns>
        public Dictionary<Colaborador, List<PedidoNiquel>> autoAsignarCargasNiquel(List<Colaborador> caj, BindingList<PedidoNiquel> car)
        {
            Dictionary<Colaborador, List<PedidoNiquel>> cargas_cajeros = new Dictionary<Colaborador, List<PedidoNiquel>>();

            int[] fulls_cajeros = new int[caj.Count];

            int numero_cajero = 0;
            int numero_fulls_minimo = 0;

            foreach (Colaborador cajero in caj)
                cargas_cajeros.Add(cajero, new List<PedidoNiquel>());

            while (car.Count > 0)
            {
                PedidoNiquel carga = car[0];
                Colaborador cajero = caj[numero_cajero];
                List<PedidoNiquel> cargas_cajero = cargas_cajeros[cajero];

                numero_fulls_minimo = fulls_cajeros[0];

                     

                    cargas_cajero.Add(carga);
                    car.RemoveAt(0);


                numero_cajero++;

                // Validar si se llego al último cajero

                if (numero_cajero == caj.Count) numero_cajero = 0;
            }

            return cargas_cajeros;
        }




        /// <summary>
        /// Importar una lista de Cargas.
        /// </summary>
        /// <param name="c">Lista de cargas a importar</param>
        public void importarPedidoNiquel(BindingList<PedidoNiquel> c)
        {


            try
            {

                foreach (PedidoNiquel carga in c)
                {
                    PedidoNiquel copia_carga = carga;

                    _pedido_niquel.agregarPedidoNiquel(ref copia_carga);

                    foreach (CartuchosNiquel cartucho in copia_carga.Cartuchos)
                    {
                        CartuchosNiquel copia_cartucho = cartucho;
                        copia_cartucho.Movimiento.ID = copia_carga.ID;
                        _cartuchos_niquel.agregarCartuchosNiqueles(ref copia_cartucho);
                    }

                }

            }
            catch (Exception)
            {
                throw new Excepcion("ErrorCargasImportacion");
            }

        }



        /// <summary>
        /// Listar las cargas por fecha, cajero, Sucursal y ruta.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del cajero de Sucursales para el cual se genera la lista</param>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal para el cual se genera la lista</param>
        /// <param name="f">Fecha de asignación de las cargas que se listarán</param>
        /// <param name="r">Ruta para la cual se genera la lista</param>
        public BindingList<PedidoNiquel> listarPedidoNiquelSinAsignarCajero(Colaborador c, PuntoVenta s, DateTime f)
        {

            try
            {

                BindingList<PedidoNiquel> cargas = _pedido_niquel.listarPedidosNiquelSinAsignarCajero(s, f);

                foreach (PedidoNiquel carga in cargas)
                {
                    PedidoNiquel copia = carga;

                    _cartuchos_niquel.obtenerCartuchosPedidoNiquel(ref copia, true);
                    _pedido_niquel.obtenerDatosPedidoNiquel(ref copia);

                }

                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Autoasignar las cargas tomando en cuenta las rutas y los cajeros full.
        /// </summary>
        /// <param name="caj">Lista de cajeror a los cuales se asignarán la cargas</param>
        /// <param name="car">Lista de cargas que se asignarán</param>
        /// <returns>Lista de cajeros y sus respectivas cargas</returns>
        public Dictionary<Colaborador, List<PedidoNiquel>> autoAsignarPedidosNiquel(List<Colaborador> caj, BindingList<PedidoNiquel> car)
        {
            Dictionary<Colaborador, List<PedidoNiquel>> cargas_cajeros = new Dictionary<Colaborador, List<PedidoNiquel>>();

            Decimal monto = 0;
            
            foreach (PedidoNiquel p in car)
            {
                monto = monto + p.Monto_asignado_colones;
            }


            Decimal promedio = (monto / caj.Count);
            int numero_cajero = 0;


            foreach (Colaborador cajero in caj)
                cargas_cajeros.Add(cajero, new List<PedidoNiquel>());

            int cantidad_cajeros = caj.Count;
            Decimal monto_cajero = 0;

            //foreach (PedidoNiquel p in car)
            //{
              
            //    monto_cajero = monto_cajero + p.Monto_asignado_colones;
            //    if (monto_cajero <= promedio)
            //    {
                    
            //        Colaborador cajero = caj[numero_cajero];
            //        List<PedidoNiquel> cargas_cajero = cargas_cajeros[cajero];
            //        cargas_cajero.Add(p);
            //    }
            //    else
                
            //    {
            //        promedio
            //        Colaborador cajero = caj[numero_cajero];
            //        List<PedidoNiquel> cargas_cajero = cargas_cajeros[cajero];
            //        cargas_cajero.Add(p);
            //        monto_cajero = 0;
            //        numero_cajero++;
            //    }
            //}



            while (car.Count > 0)
            {
                PedidoNiquel carga = car[0];
                Colaborador cajero = caj[numero_cajero];
                List<PedidoNiquel> cargas_cajero = cargas_cajeros[cajero];



                cargas_cajero.Add(carga);
                car.RemoveAt(0);


                numero_cajero++;

                // Validar si se llego al último cajero

                if (numero_cajero == caj.Count) numero_cajero = 0;
            }

            return cargas_cajeros;
        }


        /// <summary>
        /// Lista todas las bolsas completas de un determinado día
        /// </summary>
        /// <param name="fecha">Fecha de la entrega de tulas</param>
        /// <param name="empresa">Empresa a la que se entregarán las bolsas</param>
        /// <returns>Una lista de las</returns>
        public BindingList<BolsaCompletaNiquel> listarBolsasCompletasNiquelEntrega(DateTime fecha, EmpresaTransporte empresa)
        {
            return _bolsa_completa.listarBolsasCompletasNiquelEntrega(fecha, empresa);
        }


        /// <summary>
        /// Lista todas las bolsas de un determinado día
        /// </summary>
        /// <param name="fecha">Fecha de la entrega de tulas</param>
        /// <param name="empresa">Empresa a la que se entregarán las bolsas</param>
        /// <returns>Una lista de las</returns>
        public BindingList<BolsaNiquel> listarBolsasNiquelEntrega(DateTime fecha, EmpresaTransporte empresa)
        {
            return _bolsa_completa.listaBolsasNiquelEntrega(fecha, empresa);
        }



        /// <summary>
        /// Actualiza los datos de entrega de una bolsa de níquel
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de bolsa</param>
        public void actualizarEntregaTulasPedidoNiquel(BolsaNiquel b)
        {
            _bolsa_completa.actualizarBolsaNiquelEntregas(b);
        }


        /// <summary>
        /// Actualiza los datos de entrega de una bolsa completa de níquel
        /// </summary>
        /// <param name="b">Bolsa completa con los datos de la bolsa</param>
        public void actualizarEntregaBolsasCompletasPedidoNiquel(BolsaCompletaNiquel b)
        {
            _bolsa_completa.actualizarBolsasCompletasNiquelEntrega(b);
        }

        #endregion Pedidos Niquel

        #region Cartucho Pedido Níquel

        /// <summary>
        /// Actualizar los datos del cartucho de un pedido de un Cliente
        /// </summary>
        /// <param name="c">Objeto CartuchosNiquel con los datos del cartucho</param>
        public void actualizarCartuchoPedidoNiquel(CartuchosNiquel c)
        {

            try
            {
                _cartuchos_niquel.actualizarCartuchosNiquel(ref c);


                //_cartuchos_cargas_sucursales.actualizarCartuchoCargaTransportadoraCartucho(c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar la cantidad de fórmulas descargadas de un cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto BolsaCargaBanco con los datos del pedido</param>
        public void actualizarCartuchoPedidoNiquelCantidad(CartuchosNiquel c)
        {

            try
            {
                _cartuchos_niquel.actualizarCartuchosNiquelCantidad(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Cartucho Pedido Níquel
        
        #region Cierres de Niquel

        /// <summary>
        /// Registrar un cierre de Niquel en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreNiquel con los datos del cierre</param>
        public void agregarCierreNiquel(ref CierreNiquel c)
        {

            try
            {
                //BindingList<Denominacion> denominaciones_cargas = _denominaciones.listarDenominacionesCargasSucursales();

                _cierre_niquel.agregarCierreNiquel(ref c);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de Sucursales.
        /// </summary>
        /// <param name="c">Objeto CierreNiquel con los datos del cierre</param>
        public void actualizarCierrePedidoNiquel(CierreNiquel c)
        {

            try
            {
                _cierre_niquel.actualizarCierreNiquel(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Ligar o desligar la carga de un Sucursal del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void actualizarPedidoNiquelCierreNiquel(PedidoNiquel c)
        {

            try
            {
                _pedido_niquel.actualizarPedidoNiquelCierreNiquel(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar como terminado un cierre de Sucursales
        /// </summary>
        /// <param name="c">Objeto CierreNiquel con los datos del cierre</param>
        public void actualizarCierrePedidoNiquelTerminar(CierreNiquel c)
        {

            try
            {
                _cierre_niquel.actualizarCierreNiquelTerminar(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreNiquel con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public bool verificarCierreNiquel(ref CierreNiquel c)
        {

            try
            {
                bool existe = _cierre_niquel.verificarCierreNiquel(ref c);

                if (existe)
                {
                    _pedido_niquel.obtenerPedidoNiquelCierreNiquel(ref c);

                    foreach (PedidoNiquel carga in c.Cargas)
                    {
                        PedidoNiquel copia = carga;
                        copia.Cierre = c;
                        copia.Manifiesto = new BindingList<ManifiestoNiquelPedido>();
                        _cartuchos_niquel.obtenerCartuchosPedidoNiquel(ref copia, false);
                        _pedido_niquel.obtenerDatosPedidoNiquel(ref copia);

                        _pedido_niquel.obtenerManifiestosPedidoNiquel(ref copia);

                        if (copia.Manifiesto != null)
                        {

                            foreach (ManifiestoNiquelPedido m in copia.Manifiesto)
                            {
                                ManifiestoNiquelPedido copia_manifiesto = m;

                                copia_manifiesto.ListaBolsas = new BindingList<BolsaNiquel>();
                                copia_manifiesto.ListaBolsas = _bolsa.listarBolsasNiquelPorManifiesto(ref copia_manifiesto);
                                copia_manifiesto.BolsasCompletas = new BindingList<BolsaCompletaNiquel>();
                                _bolsa_completa.obtenerBolsaMontoNiquel(ref copia_manifiesto);
                                foreach (BolsaNiquel b in copia_manifiesto.ListaBolsas)
                                {
                                    BolsaNiquel copia_bolsa = b;
                                    _montos_bolsas_niquel.obtenerBolsaMontoNiquel(ref copia_bolsa);
                                }
                            }
                        }




                        //copia.Manifiesto.ListaBolsas = _bolsa.listarBolsasSucursalPorManifiesto(copia.Manifiesto);
                        if (c.Cargas_listas == false)
                        {
                            _pedido_niquel.obtenerDatosVerificacionCarga(ref copia);
                        }

                        //copia.Cajero.Nombre = null;
                    }

                }

                return existe;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si un cajero tiene un cierre pendiente de finalizar.
        /// </summary>
        /// <param name="c">Objeto CierreNiquel con los datos del cajero</param>
        /// <returns>Valor que indica si el cajero tiene un cierre pendiente</returns>
        public bool verificarCierreNiquelPendiente(ref CierreNiquel c)
        {

            try
            {
                return _cierre_niquel.verificarCierreNiquelPendiente(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Obtiene los datos de una bolsa completa
        /// </summary>
        /// <param name="b">Objeto BolsaCompletaNiquel con los datos de la bolsa</param>
        public void obtenerDatosBolsaCompleta(ref BolsaCompletaNiquel b)
        {
            _pedido_niquel.obtenerDatosBolsasCompletas(ref b);
        }



        #endregion Cierres de Sucursales

        #region Registro Penalidades

        /// <summary>
        /// Registrar un nuevo registro de penalidad.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos del nuevo Registro de Penalidad</param>
        public void agregarRegistroPenalidad(ref RegistroPenalidad g)
        {

            try
            {
                _registro_penalidad.agregarRegistroPenalidad(ref g);

                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un registro de penalidad.
        /// </summary>
        /// <param name="g">Objeto RegistroPenalidad con los datos del registro de penalidad a actualizar</param>
        public void actualizarRegistroPenalidad(RegistroPenalidad g)
        {

            try
            {
                _registro_penalidad.actualizarRegistroPenalidad(g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        /// <summary>
        /// Eliminar los datos de una gestión.
        /// </summary>
        /// <param name="t">Objeto RegistroPenalidad con los datos del registro de penalidad a eliminar</param>
        public void eliminarRegistroPenalidad(RegistroPenalidad g)
        {

            try
            {
                _registro_penalidad.eliminarRegistroPenalidad(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los registros de penalidad registrados en el sistema.
        /// </summary>
        /// <returns>Lista de las registro penalidad registrados en el sistema</returns>
        public BindingList<RegistroPenalidad> listarRegistroPenalidades(DateTime fecha,DateTime fechafin, PuntoVenta punto, EmpresaTransporte empresa)
        {

            try
            {
                BindingList<RegistroPenalidad> registros = _registro_penalidad.listarRegistroPenalidades(fecha, fechafin, punto, empresa);

                foreach (RegistroPenalidad registro in registros)
                {
                    TipoPenalidad copia = registro.Penalidad.TipoPenalidad;

                    _nivel_tipo_penalidad.obtenerNivelTipoPenalidadFalla(ref copia);
                }

                return registros;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       


        #endregion Registro Penalidades

        #region Resumen Facturacion Clientes


        /// <summary>
        /// Lista el resumen de facturacion
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente</param>
        /// <param name="empresa">Objeto EmpresaTransporte con los datos de la transportadora</param>
        /// <param name="fechai">Fecha de Arranque de la Facturación</param>
        /// <param name="fechaf">Fecha Fin de la Facturación</param>
        /// <returns></returns>
        public BindingList<ResumenFacturacionCliente> listarResumenFacturacion(Cliente c, EmpresaTransporte empresa, DateTime fechai, DateTime fechaf)
        {

            try
            {
                BindingList<ResumenFacturacionCliente> cargas = _resumen_facturacion_cliente.listarResumenFacturacionCliente(c, empresa, fechai, fechaf);

               
                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Lista el resumen de facturacion
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente</param>
        /// <param name="empresa">Objeto EmpresaTransporte con los datos de la transportadora</param>
        /// <param name="fechai">Fecha de Arranque de la Facturación</param>
        /// <param name="fechaf">Fecha Fin de la Facturación</param>
        /// <returns></returns>
        public BindingList<ResumenFacturacionCliente> listarResumenFacturacionEnvios(Cliente c, EmpresaTransporte empresa, DateTime fechai, DateTime fechaf)
        {

            try
            {
                BindingList<ResumenFacturacionCliente> cargas = _resumen_facturacion_cliente.listarResumenFacturacionClienteEnvios(c, empresa, fechai, fechaf);


                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Resumen Facturacion  Clientes

        #region Resumen Facturacion Transportadoras

        /// <summary>
        /// Registrar una nueva facturacion de transportadora
        /// </summary>
        /// <param name="g">Objeto FacturacionTransportadora con los datos de la Facturacion</param>
        public void agregarFacturacionTransportadora(ref FacturacionTransportadora g)
        {

            try
            {
                _resumen_facturacion_transportadora.agregarFacturacionTransportadora(ref g);

                foreach (CategoriaFacturacionTransportadora nombre in g.ListaCategoria)
                {
                    CategoriaFacturacionTransportadora copia_nombre = nombre;

                    _resumen_facturacion_transportadora.agregarCategoriaFacturacionTransportadora(ref copia_nombre, g);

                   
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un registro de penalidad.
        /// </summary>
        /// <param name="g">Objeto RegistroPenalidad con los datos del registro de penalidad a actualizar</param>
        public void actualizarFacturacionTransportadora(FacturacionTransportadora g)
        {

            try
            {
                _resumen_facturacion_transportadora.actualizarFacturacionTransportadora(ref g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Selecciona el resumen de facturacion a obtener
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos Cliente</param>
        /// <param name="empresa">Objeto EmpresaTransporte con los datos de la Transportadora</param>
        /// <param name="fecha">Fecha Inicios</param>
        /// <param name="fechaf">Fecha Fin</param>
        /// <returns>El resumen de la facturacion de la transportadora</returns>
        public FacturacionTransportadora obtenerResumenTransportadora(Cliente c, EmpresaTransporte empresa, DateTime fecha, DateTime fechaf)
        {
            try
            {
                FacturacionTransportadora facturacion = _resumen_facturacion_transportadora.listarFacturacionTransportadora(c, empresa, fecha, fechaf);
                
                if(facturacion != null)
                     _resumen_facturacion_transportadora.obtenerCategoriaResumenFacturacion(ref facturacion);

                return facturacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Calcula el resumen total de los creditos
        /// </summary>
        /// <param name="c">Cliente que corresponde al calculo de la facturacion</param>
        /// <param name="empresa">Empresa Transportadora a facturar</param>
        /// <param name="fecha">Fecha en la que se inicio la factuacion</param>
        /// <param name="fechaf">Fecha en la que finaliza la facturacion</param>
        /// <returns>El calculo de la facturacion con los parametros iniciales</returns>
        public Decimal calcularResumenFacturacion(Cliente c, EmpresaTransporte empresa, DateTime fecha, DateTime fechaf)
        {
            try
            {
                Decimal facturacion = _resumen_facturacion_transportadora.listarCalculoFacturacion(c, empresa, fecha, fechaf);

                return facturacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        /// <summary>
        /// Calcula el resumen total de los creditos
        /// </summary>
        /// <param name="c">Cliente que corresponde al calculo de la facturacion</param>
        /// <param name="empresa">Empresa Transportadora a facturar</param>
        /// <param name="fecha">Fecha en la que se inicio la factuacion</param>
        /// <param name="fechaf">Fecha en la que finaliza la facturacion</param>
        /// <returns>El calculo de la facturacion con los parametros iniciales</returns>
        public Decimal calcularResumenFacturacionSalientes(Cliente c, EmpresaTransporte empresa, DateTime fecha, DateTime fechaf)
        {
            try
            {
                Decimal facturacion = _resumen_facturacion_transportadora.listarCalculoFacturacionSalientes(c, empresa, fecha, fechaf);

                return facturacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Calcula el resumen total de los creditos
        /// </summary>
        /// <param name="c">Cliente que corresponde al calculo de la facturacion</param>
        /// <param name="empresa">Empresa Transportadora a facturar</param>
        /// <param name="fecha">Fecha en la que se inicio la factuacion</param>
        /// <param name="fechaf">Fecha en la que finaliza la facturacion</param>
        /// <returns>El calculo de la facturacion con los parametros iniciales</returns>
        public Decimal calcularResumenFacturacionSucursales(Cliente c, EmpresaTransporte empresa, DateTime fecha, DateTime fechaf)
        {
            try
            {
                Decimal facturacion = _resumen_facturacion_transportadora.listarCalculoFacturacionSucursales(c, empresa, fecha, fechaf);

                return facturacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Calcula el resumen total de los creditos
        /// </summary>
        /// <param name="c">Cliente que corresponde al calculo de la facturacion</param>
        /// <param name="empresa">Empresa Transportadora a facturar</param>
        /// <param name="fecha">Fecha en la que se inicio la factuacion</param>
        /// <param name="fechaf">Fecha en la que finaliza la facturacion</param>
        /// <returns>El calculo de la facturacion con los parametros iniciales</returns>
        public Decimal calcularResumenFacturacionProcesamiento(Cliente c, EmpresaTransporte empresa, DateTime fecha, DateTime fechaf)
        {
            try
            {
                Decimal facturacion = _resumen_facturacion_transportadora.listarCalculoFacturacionProcesamiento(c, empresa, fecha, fechaf);

                return facturacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Calcula el total de creditos para las transportadoras
        /// </summary>
        /// <param name="c">Cliente que corresponde al calculo de la facturacion</param>
        /// <param name="empresa">Empresa Transportadora a facturar</param>
        /// <param name="fecha">Fecha en la que se inicio la factuacion</param>
        /// <param name="fechaf">Fecha en la que finaliza la facturacion</param>
        /// <returns>El calculo de la facturacion con los parametros iniciales</returns>
        public Decimal calcularCreditosFacturacionTransportadora(Cliente c, EmpresaTransporte empresa, DateTime fecha, DateTime fechaf)
        {
            try
            {
                Decimal facturacion = _resumen_facturacion_transportadora.listarCreditosFacturacionClientes(c, empresa, fecha, fechaf);

                return facturacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Resumen Facturacion Transportadoras

        #region Facturacion Procesamiento

        /// <summary>
        /// Lista el resumen de facturacion de procesamiento
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente</param>
        /// <param name="empresa">Objeto EmpresaTransporte con los datos de la transportadora</param>
        /// <param name="fechai">Fecha de Arranque de la Facturación</param>
        /// <param name="fechaf">Fecha Fin de la Facturación</param>
        /// <returns>Una lista con el resumen de la facturación </returns>
        public BindingList<FacturacionProcesamiento> listarResumenFacturacionProcesamiento(Cliente c, EmpresaTransporte empresa, DateTime fechai, DateTime fechaf)
        {

            try
            {
                BindingList<FacturacionProcesamiento> cargas = _resumen_facturacion_cliente.listarResumenFacturacionClienteProcesamiento(c, empresa, fechai, fechaf);


                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Facturacion Procesamiento

        #region Registro Inconsistencia Facturacion

        #endregion Registro Inconsistencia Facturacion

        #region Inconsistencias Planillas

        public BindingList<InconsistenciaPlanilla> reportePlanillas(DateTime f, EmpresaTransporte emp, DateTime ff)
        {
            return _inconsistencia.Reporte(f, emp, ff);
        }



        public BindingList<InconsistenciaPlanilla> reportePlanillasProcesamiento(DateTime f, EmpresaTransporte emp, DateTime ff)
        {
            return _inconsistencia.ReporteProcesamiento(f, emp, ff);
        }


        #endregion Inconsistencias Planillas

        #region Cuadre de Depósitos

        /// <summary>
        /// Permite obtener el cuadre de depósitos para un cliente y punto d eventa específico 
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente</param>
        /// <param name="a">Objeto PuntoVenta con los datos del punto de venta</param>
        /// <param name="f">Fecha del Cuadre</param>
        /// <returns>Una lista con los depósitos del cuadre</returns>
        public BindingList<CuadreDeposito> listarCuadreDepositos(Cliente c, PuntoVenta a, DateTime f)
        {

            try
            {
                BindingList<CuadreDeposito> cargas = _depositos.listarCuadreDepositos(c, a, f);

                
                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Permite obtener el cuadre de depósitos para un cliente y punto d eventa específico 
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente</param>
        /// <param name="a">Objeto PuntoVenta con los datos del punto de venta</param>
        /// <param name="f">Fecha del Cuadre</param>
        /// <returns>Una lista con los depósitos del cuadre</returns>
        public BindingList<CuadreDeposito> listarCuadreDepositosBD(Cliente c, PuntoVenta a, DateTime f)
        {

            try
            {
                BindingList<CuadreDeposito> cargas = _depositos.listarCuadreDepositosBD(c, a, f);


                return cargas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Ingresa o actualza un cuadro de depósito
        /// </summary>
        /// <param name="c">Objeto Cuadro de depósito con los datos </param>
        public void agregarCuadrDeposito(ref CuadreDeposito c, Colaborador col)
        {
            try
            {
                _depositos.agregarCuadreDeposito(ref c, col);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }


        #endregion Cuarde de Depositos

        #region Recapt Preliminar

        /// <summary>
        /// Agregar los datos de un nuevo recapt preliminar.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del recapt</param>
        public void agregarRecaptPreliminar(RecaptPreliminar c)
        {

            try
            {
                _recapt_preliminar.agregarRecaptPreliminar(ref c);

                foreach (MontosRecaptPreliminar cartucho in c.Cartuchos)
                {
                    MontosRecaptPreliminar copia_cartucho = cartucho;
                    copia_cartucho.Recapt = c;
                    _montos_recapt_preliminar.agregarMontosRecaptPreliminar(ref copia_cartucho);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Agregar los datos de un nuevo recapt preliminar.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del recapt</param>
        public void actualizarRecaptPreliminar(RecaptPreliminar c)
        {

            try
            {
                _recapt_preliminar.actualizarRecaptPreliminar(c);

                foreach (MontosRecaptPreliminar cartucho in c.Cartuchos)
                {
                    MontosRecaptPreliminar copia_cartucho = cartucho;

                    _montos_recapt_preliminar.actualizarMontosRecaptPreliminar(copia_cartucho);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista los Recaps del día
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public BindingList<Recap> listarRecap(DateTime fecha)
        {
            return  _recapt_preliminar.listarRecap(fecha);
        }


        /// <summary>
        /// Agregar los datos de un nuevo recapt preliminar.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del recapt</param>
        public void actualizarEstadoRecapPreliminar(DateTime fecha, EstadoRecapt estado)
        {

            try
            {
                //_recapt_final.actualiza(fecha, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Recapt Preliminar

        #region Recapt Final

        /// <summary>
        /// Agregar los datos de un nuevo recapt preliminar.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del recapt</param>
        public void agregarRecaptFinal(RecaptFinal c)
        {

            try
            {
                _recapt_final.agregarRecaptFinal(ref c);

                foreach (MontosRecaptFinal cartucho in c.Cartuchos)
                {
                    MontosRecaptFinal copia_cartucho = cartucho;
                    copia_cartucho.Recapt = c;
                    _montos_recapt_final.agregarMontosRecaptFinal(ref copia_cartucho);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



      




        /// <summary>
        /// Lista los Recaps del día
        /// </summary>
        /// <param name="fecha">Objeto DateTime con los datos de la fecha</param>
        /// <returns></returns>
        public BindingList<Recap> listarRecapFinal(DateTime fecha)
        {
            return _recapt_preliminar.listarRecap(fecha);
        }

        #endregion Recapt Final

        #region Descargas ENA y Visitas Papel

        /// <summary>
        /// Actualiza los datos de las visitas sólo descargas y papel.
        /// </summary>
        /// <param name="cantidad_formulas">Cantidad de fórmulas máximas para descargar un ENA.</param>
        public void descargasENA(int cantidad_formulas)
        {
            try
            {
                _cargas.actualizarVisitasDescargaPapel(cantidad_formulas);
            }
            catch (Excepcion ex)
            {
                throw ex; 
            }
        
        }


        #endregion Descargas ENA y Visitas Papel 

        #region Estado Cartuchos

       


        //public void actualizarCartuchoCargaATM(CartuchoCargaATM c, Colaborador usuario)
        //{

        //    try
        //    {
        //        _cartuchos_cargas.actualizarCartuchoCargaATM(c);

        //        if (c.Cartucho != null)
        //        {
        //            if (c.Cartucho.Estado == EstadosCartuchos.Bueno)
        //            {
        //                Cartucho cartucho = c.Cartucho;

        //                if (cartucho.ID_Invalido)
        //                {
        //                    _cartuchos.agregarCartucho(ref cartucho);
        //                }
        //                else
        //                {
        //                    _cartuchos.actualizarCartucho(cartucho);
        //                    _cartuchos.actualizarCartuchoEstado(cartucho, usuario);
        //                }

        //                _cartuchos_cargas.actualizarCartuchoCargaATMCartucho(c);
        //            }
        //            else
        //            {
        //                Mensaje.mostrarMensaje("MensajeCartuchoMaloCierreATM");
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        #endregion Estado Cartuchos

        #region Libro Mayor Bóveda

        /// <summary>
        /// Obtiene la cantidad de cajeros de Centro efectivo para el cierre de libros 
        /// </summary>
        /// <param name="fecha">Fecha de la generación del libro</param>
        /// <returns>Entero con la cantidad de cajeros</returns>
        public int cantidadCajerosCEF(DateTime fecha)
        {
            return _libros_mayor_boveda.cantidadCAjeros(fecha);
        }

        /// <summary>
        /// Actualiza un libro mayor
        /// </summary>
        /// <param name="libro">Objeto libro mayor con los datos del libro</param>
        public void agregarLibroMayor(ref LibroMayor libro, Colaborador usuario, DateTime Fecha)
        {
            _libros_mayor_boveda.agregarLibroMayor(ref libro, usuario, Fecha);
        }
        
        /// <summary>
        /// Actualiza los datos de un libro mayor
        /// </summary>
        /// <param name="libro"></param>
        public void actualizarLibroMayor(LibroMayor libro)
        {
            _libros_mayor_boveda.actualizarLibroMayor(libro);
        }

        public void actualizarLibroMayorSITES(DateTime fecha)
        {
            _libros_mayor_boveda.actualizarLibroMayorSites(fecha);
        }

        //public void actualizarLibroMayorBovedaEntrega(DateTime fecha)
        //{
        //    _libros_mayor_boveda.actualizarLibroMayorBovedaEntrega(fecha);
        //}
        
        /// <summary>
        /// Listar Libros Mayores
        /// </summary>
        /// <param name="fecha">Fecha</param>
        /// <returns></returns>
        public BindingList<LibroMayor> listarLibroMayor(DateTime fecha)
        {
            return _libros_mayor_boveda.listarLibroMayors(fecha);
        }

        #endregion Libro Mayor Bóveda

        #region Libro Mayor Bóveda Pedido

        /// <summary>
        /// Obtiene la cantidad de cajeros de Centro efectivo para el cierre de libros 
        /// </summary>
        /// <param name="fecha">Fecha de la generación del libro</param>
        /// <returns>Entero con la cantidad de cajeros</returns>
        public int cantidadCajerosCEFPedido(DateTime fecha)
        {
            return _libros_mayor_boveda.cantidadCAjerosPedido(fecha);
        }

        /// <summary>
        /// Actualiza un libro mayor
        /// </summary>
        /// <param name="libro">Objeto libro mayor con los datos del libro</param>
        public void agregarLibroMayorPedido(ref LibroMayor libro, Colaborador usuario, DateTime fecha)
        {
            _libros_mayor_boveda.agregarLibroMayorPedido(ref libro, usuario, fecha);
        }


        /// <summary>
        /// Actualiza los datos de un libro mayor
        /// </summary>
        /// <param name="libro"></param>
        public void actualizarLibroMayorPedido(LibroMayor libro)
        {
            _libros_mayor_boveda.actualizarLibroMayorPedido(libro);
        }

        public void actualizarLibroMayorPedidoSITES(DateTime fecha)
        {
            _libros_mayor_boveda.actualizarLibroMayorPedidoSITES(fecha);
        }


        /// <summary>
        /// Listar Libros Mayores
        /// </summary>
        /// <param name="fecha">Fecha</param>
        /// <returns></returns>
        public BindingList<LibroMayor> listarLibroMayorPedido(DateTime fecha)
        {
            return _libros_mayor_boveda.listarLibroMayorPedido(fecha);
        }

        public SaldoLibroBoveda listarSaldosBoveda(DateTime fecha)
        {
            return _saldo_boveda.listarSaldoBoveda(fecha);
        }

        #endregion Libro Mayor Bóveda Pedido

        #region Libro Mayor Níquel Entrega

        /// <summary>
        /// Obtiene la cantidad de cajeros de Centro efectivo para el cierre de libros 
        /// </summary>
        /// <param name="fecha">Fecha de la generación del libro</param>
        /// <returns>Entero con la cantidad de cajeros</returns>
        public int cantidadCajerosCEFNiquelEntrega(DateTime fecha)
        {
            return _libros_mayor_boveda.cantidadCAjerosNiquelEntrega(fecha);
        }

        /// <summary>
        /// Actualiza un libro mayor
        /// </summary>
        /// <param name="libro">Objeto libro mayor con los datos del libro</param>
        public void agregarLibroMayorNiquelEntrega(ref LibroMayor libro, Colaborador usuario, DateTime fecha)
        {
            _libros_mayor_boveda.agregarLibroMayorNiquelEntrega(ref libro, usuario, fecha);
        }


        /// <summary>
        /// Actualiza los datos de un libro mayor
        /// </summary>
        /// <param name="libro"></param>
        public void actualizarLibroMayorNiquelEntrega(LibroMayor libro)
        {
            _libros_mayor_boveda.actualizarLibroMayorNiquelEntrega(libro);
        }

        public void actualizarLibroMayorNiquelEntregaSITES(DateTime fecha)
        {
            _libros_mayor_boveda.actualizarLibroMayorNiquelEntregaSITES(fecha);
        }


        /// <summary>
        /// Listar Libros Mayores
        /// </summary>
        /// <param name="fecha">Fecha</param>
        /// <returns></returns>
        public BindingList<LibroMayor> listarLibroMayorNiquelEntrega(DateTime fecha)
        {
            return _libros_mayor_boveda.listarLibroMayorNiquelEntrega(fecha);
        }

        #endregion Libro Mayor Níquel Entrega

        #region Libro Mayor Niquel Pedido

        public SaldoLibroNiquel listarSaldosNiquel(DateTime fecha)
        {
            return _saldo_niquel.listarSaldoNiquel(fecha);
        }
        /// <summary>
        /// Actualiza un libro mayor
        /// </summary>
        /// <param name="libro">Objeto libro mayor con los datos del libro</param>
        public void agregarLibroMayorNiquelPedido(ref LibroMayor libro, Colaborador usuario, DateTime fecha)
        {
            _libros_mayor_boveda.agregarLibroMayorNiquelPedido(ref libro, usuario, fecha);
        }



        /// <summary>
        /// Actualiza los datos de un libro mayor
        /// </summary>
        /// <param name="libro"></param>
        public void actualizarLibroMayorNiquelPedido(LibroMayor libro)
        {
            _libros_mayor_boveda.actualizarLibroMayorNiquelPedido(libro);
        }

        public void actualizarLibroMayorNiquelPedidoSITES(DateTime fecha)
        {
            _libros_mayor_boveda.actualizarLibroMayorNiquelPedidoSites(fecha);
        }

        /// <summary>
        /// Listar Libros Mayores
        /// </summary>
        /// <param name="fecha">Fecha</param>
        /// <returns></returns>
        public BindingList<LibroMayor> listarLibroMayorNiquelPedido(DateTime fecha)
        {
            return _libros_mayor_boveda.listarLibroMayorNiquelPedido(fecha);
        }

        #endregion Libro Mayor Niquel Pedido

        #region Datos Cierre ATMs


        public DataTable listarDatosCierreCargas(DateTime f)
        {

            try
            {
                return _cargas.listarDatosCierreCargas(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listarDatosCierreDescargas(DateTime f)
        {

            try
            {
                return _cargas.listarDatosCierreDescargas(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        #endregion Datos Cierre ATMs       
        
        #region Libro Mayor ATM Full

        public DataTable listarDescargasATMsFullLibroMayorReporte(DateTime f)
        {

            try
            {
                return _cargas.listarDescargasATMsFullLibroMayorReporte(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Libro Mayor ATM Full

        /// <summary>
        /// Registrar una nueva facturacion de transportadora
        /// </summary>
        /// <param name="g">Objeto FacturacionTransportadora con los datos de la Facturacion</param>
        public void agregarRegistroInconsistenciaFacturacion(ref RegistroInconsistenciaFacturacion g)
        {

            try
            {
                _punto_atencion.agregarRegistroInconsistenciaFacturacion(ref g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      
        #endregion Métodos Públicos

    }
}