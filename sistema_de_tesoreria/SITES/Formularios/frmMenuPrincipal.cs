//
//  @ Project : 
//  @ File Name : frmMenuPrincipal.cs
//  @ Date : 28/04/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonObjects;
using LibreriaMensajes;
using GUILayer.Formularios.Blindados;
using GUILayer.Formularios.Mantenimiento;
using BussinessLayer;
using GUILayer.Formularios.Boveda;
using GUILayer.Formularios.Centro_de_Efectivo;
using GUILayer.Formularios.Cajeros_Automaticos;
using GUILayer.Formularios.Sucursales;
using GUILayer.Formularios.ATMs;
using GUILayer.Formularios.Facturacion;
using GUILayer.Formularios.Níquel;
using System.Reflection;
using GUILayer.Formularios.Optimización;
using GUILayer.Formularios.Control_Interno;
using GUILayer.Formularios.Recepcion_de_Tulas;
using System.Data;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmMenuPrincipal : Form
    {

        #region Constantes

        private const string TITULO = "SiTes - Sesion iniciada por {0} {1}";

        #endregion Constantes

        #region Atributos

        frmRecordatorioGestiones _recordatorio_gestiones = null;

        Dictionary<string, Button> _botones = new Dictionary<string, Button>();

        Colaborador _usuario = null;
        CoordinacionBL _coordinacion = new CoordinacionBL();
        MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        #endregion Atributos

        #region Constructor

        public frmMenuPrincipal()
        {
            InitializeComponent();

            lblVersion.Text = String.Format("Versión {0}",  Assembly.GetExecutingAssembly().GetName().Version.ToString());

            foreach (TabPage pestana in tcOpciones.TabPages)
            {

                foreach (Control control in pestana.Controls)
                    if (control is Button) _botones.Add(control.Name, (Button)control);

            }

            
        }

        #endregion Constructor

        #region Eventos

        #region Mantenimiento

        private void btnPuestos_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionPuestos formulario = new frmAdministracionPuestos();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnPerfilesRoles_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoPerfilesRoles formulario = new frmMantenimientoPerfilesRoles();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el botón de mantenimiento de colaboradores.
        /// </summary>
        private void btnColaboradores_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionColaboradores formulario = new frmAdministracionColaboradores(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de mantenimiento de clientes.
        /// </summary>
        private void btnClientes_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionClientes formulario = new frmAdministracionClientes();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de mantenimiento de denominaciones.
        /// </summary>
        private void btnDenominaciones_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionDenominaciones formulario = new frmAdministracionDenominaciones();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de mantenimiento de empresas.
        /// </summary>
        private void btnEmpresas_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionEmpresasTransporte formulario = new frmAdministracionEmpresasTransporte();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de mantenimiento de camaras.
        /// </summary>
        private void btnCamaras_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionCamaras formulario = new frmAdministracionCamaras();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de mantenimiento de canales.
        /// </summary>
        private void btnCanales_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionCanales formulario = new frmAdministracionCanales();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar los ATM's.
        /// </summary>
        private void btnATMs_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionATMs formulario = new frmAdministracionATMs();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar las sucursales.
        /// </summary>
        private void btnSucursales_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionSucursales formulario = new frmAdministracionSucursales();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar los cartuchos.
        /// </summary>
        private void btnCartuchos_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionCartuchos formulario = new frmAdministracionCartuchos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar las ubicaciones.
        /// </summary>
        private void btnUbicaciones_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionUbicaciones formulario = new frmAdministracionUbicaciones();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar los esquemas de los manifiestos.
        /// </summary>
        private void btnEsquemasManifiestos_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionEsquemasManifiestos formulario = new frmAdministracionEsquemasManifiestos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar el tipo de cambio.
        /// </summary>
        private void btnTipoCambio_Click(object sender, EventArgs e)
        {

            try
            {
                frmRegistroTipoDeCambio formulario = new frmRegistroTipoDeCambio();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar los tipos de error para los cierres.
        /// </summary>
        private void btnTiposError_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionTiposErroresCierre formulario = new frmAdministracionTiposErroresCierre();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar los tipos de gestión.
        /// </summary>
        private void btnTiposGestion_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionTiposGestion formulario = new frmAdministracionTiposGestion();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar las causas de gestión.
        /// </summary>
        private void btnCausasGestion_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionCausasGestion formulario = new frmAdministracionCausasGestion();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar los perfiles de acceso.
        /// </summary>
        private void btnPerfiles_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionPerfiles formulario = new frmAdministracionPerfiles();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Clic en el boton de importacion de de los datos de proveedores para ATM's
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnImportarDatosProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                frmActualizacionProveedoresATMS formulario = new frmActualizacionProveedoresATMS();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el boton de Mantenimiento de Vehiculos
        /// </summary>
        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionVehiculos formulario = new frmAdministracionVehiculos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el boton de Mantenimiento de Falllas
        /// </summary>
        private void btnFallas_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionFallas formulario = new frmAdministracionFallas();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de mantenimientos de sucursales
        /// </summary>
        private void btnColaboradoresSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoColaboradorSucursal formulario = new frmMantenimientoColaboradorSucursal(_usuario);
                formulario.ShowDialog();
            }
            catch(Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Clic en el boton de Mantenimiento de Feriados
        /// </summary>
        private void btnFeriados_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionFeriados formulario = new frmAdministracionFeriados(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

                
        /// <summary>
        /// Finalizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalidadBilletes_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionCalidadBilletes formulario = new frmAdministracionCalidadBilletes();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }
        
        #endregion Mantenimiento

        #region General

        /// <summary>
        /// Clic en el botón de administrar horas extra en la pestaña general.
        /// </summary>
        private void btnHorasExtra_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionHorasExtra formulario = new frmAdministracionHorasExtra(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de generar reportes en la pestaña general.
        /// </summary>
        private void btnReportes_Click(object sender, EventArgs e)
        {

            try
            {
                frmSeleccionReporte formulario = new frmSeleccionReporte(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion General

        #region Centro de Efectivo

        /// <summary>
        /// Clic en el botón de registro de cierres en la pestaña del CEF.
        /// </summary>
        private void btnCierresCEF_Click(object sender, EventArgs e)
        {

            try
            {
                frmRegistroCierreCEF formulario = new frmRegistroCierreCEF(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de registro de inconsistencias en la pestaña del CEF.
        /// </summary>
        private void btnInconsistenciasCEF_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionInconsistenciasCEF formulario = new frmAdministracionInconsistenciasCEF(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Clic en el boton de Validacion de Planillas
        /// </summary>
        private void btnValidacionPlanilla_Click(object sender, EventArgs e)
        {
            try
            {
                frmPlanillasEmpresas formulario = new frmPlanillasEmpresas(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de registro de los montos de los manifiestos en la pestaña de CEF. 
        /// </summary>
        private void btnMontosManifiestosCEF_Click(object sender, EventArgs e)
        {

            try
            {
                frmAsignacionMontosCEF formulario = new frmAsignacionMontosCEF(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de registro de montos por denominación en la pestaña del CEF.
        /// </summary>
        private void btnMontosDenominacion_Click(object sender, EventArgs e)
        {

            try
            {
                frmRegistroDenominacionesCajeros formulario = new frmRegistroDenominacionesCajeros(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de segregación de manifiestos en la pestaña del CEF.
        /// </summary>
        private void btnSegregacionManifiestos_Click(object sender, EventArgs e)
        {
            frmSegregacionManifiesto formulario = new frmSegregacionManifiesto(_usuario);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de administrar los registros de errores de cierres del CEF.
        /// </summary>
        private void btnErroresCierre_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionRegistroErrores formulario = new frmAdministracionRegistroErrores(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de administrar las inconsistencias de los digitadores  para el coordinador operativo.
        /// </summary>
        private void btnInconsistenciasDigitadores_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionInconsistenciasDigitadores formulario = new frmAdministracionInconsistenciasDigitadores(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de revisar las gestiones.
        /// </summary>
        private void btnGestiones_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionGestiones formulario = new frmAdministracionGestiones(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de mostrar gestiones pendientes.
        /// </summary>
        private void btnGestionesPendientes_Click(object sender, EventArgs e)
        {
            this.mostrarRecordatorioGestiones();
        }

        /// <summary>
        /// Clic en el botón de revisar las gestiones terminadas.
        /// </summary>
        private void btnGestionesTerminadas_Click(object sender, EventArgs e)
        {

            try
            {
                frmGestionesTeminadas formulario = new frmGestionesTeminadas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }
        
        /// <summary>
        /// Clic en el botón de revisar cierres para un digitador.
        /// </summary>
        private void btnRevisionCierreDigitador_Click(object sender, EventArgs e)
        {

            try
            {
                frmCierreDigitador formulario = new frmCierreDigitador(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de monitoreo de manifiestos no procesados en la pestaña del CEF.
        /// </summary>
        private void btnMonitoreoManifiestos_Click(object sender, EventArgs e)
        {

            try
            {
                frmMonitoreoManifiestos formulario = new frmMonitoreoManifiestos(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el boton de facturacion
        /// </summary>
        private void btnMantenimientoFacturacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmManifiestosFacturacion formulario = new frmManifiestosFacturacion(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
            }
        }


        /// <summary>
        /// Clic en el botón de conversor de archivos para acreditación
        /// </summary>
        private void btnConversorArchivos_Click(object sender, EventArgs e)
        {
            try
            {
                frmConversionArchivoAcreditacion formulario = new frmConversionArchivoAcreditacion(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
            }
        }



        /// <summary>
        /// Clic en el boton de cheques procesados 
        /// </summary>
        private void btnChequesProcesados_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionChequesProcesados formulario = new frmAdministracionChequesProcesados(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
            }
        }

        private void btnRevisionCierres_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteCierreCoordinador formulario = new frmReporteCierreCoordinador();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }      
            


        #endregion Centro de Efectivo

        #region Registro de tulas

        /// <summary>
        /// Clic en el botón de registrar tulas.
        /// </summary>
        private void btnRecepcionTulas_Click(object sender, EventArgs e)
        {

            try
            {
                frmOpcionesRegistro formulario = new frmOpcionesRegistro(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de listar tulas.
        /// </summary>
        private void btnListadoTulas_Click(object sender, EventArgs e)
        {

            try
            {
                frmListaTulas formulario = new frmListaTulas(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de corregir el registro de una tula.
        /// </summary
        private void btnCorrecionRegistro_Click(object sender, EventArgs e)
        {

            try
            {
                frmCorreccionRegistro formulario = new frmCorreccionRegistro();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de buscar manifiestos.
        /// </summary
        private void btnBusquedaManifiestos_Click(object sender, EventArgs e)
        {

            try
            {
                frmBusquedaManifiestos formulario = new frmBusquedaManifiestos(_usuario, true);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de buscar tulas.
        /// </summary
        private void btnBusquedaTulas_Click(object sender, EventArgs e)
        {

            try
            {
                frmBusquedaTulas formulario = new frmBusquedaTulas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de marcar manifiestos de la pestaña de recepción de tulas.
        /// </summary>
        private void btnMarcacionManifiestos_Click(object sender, EventArgs e)
        {

            try
            {
                frmMarcacionManifiestos formulario = new frmMarcacionManifiestos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de ingresar manifiesto.
        /// </summary>
        private void btnIngresoManifiesto_Click(object sender, EventArgs e)
        {

            try
            {
                frmIngresoManualManifiesto formulario = new frmIngresoManualManifiesto(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de ingresar tula.
        /// </summary>
        private void btnIngresoTula_Click(object sender, EventArgs e)
        {
            frmIngresoManualTula formulario = new frmIngresoManualTula(_usuario);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de cambiar el manifiesto de una tula.
        /// </summary>
        private void btnCambioManifiesto_Click(object sender, EventArgs e)
        {
            frmCambioManifiestoTula formulario = new frmCambioManifiestoTula(_usuario);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de cambiar el área de los manifiestos.
        /// </summary>
        private void btnCambioAreaManifiesto_Click(object sender, EventArgs e)
        {
            frmCambioAreaManifiesto formulario = new frmCambioAreaManifiesto(_usuario);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de mantenimiento de grupos.
        /// </summary>
        private void btnGrupos_Click(object sender, EventArgs e)
        {

            try
            {
                frmAdministracionGrupos formulario = new frmAdministracionGrupos();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Registro de tulas

        #region Boveda

        /// <summary>
        /// Clic en el botón de registro de cierres en la pestaña de bóveda.
        /// </summary>
        private void btnCierresBoveda_Click(object sender, EventArgs e)
        {

            try
            {
                frmRegistroCierreBoveda formulario = new frmRegistroCierreBoveda(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de registro de inconsistencias en la pestaña de bóveda.
        /// </summary>
        private void btnInconsistenciasBoveda_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Clic en el botón de registro de los montos de los manifiestos en la pestaña de bóveda. 
        /// </summary>
        private void btnMontosManifiestosBoveda_Click(object sender, EventArgs e)
        {

            try
            {
                frmAsignacionMontosBoveda formulario = new frmAsignacionMontosBoveda(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de imprimir los manifiestos de bóveda. 
        /// </summary>
        private void btnImpresionManifiestosBoveda_Click(object sender, EventArgs e)
        {

            try
            {
                frmImpresionManifiestos formulario = new frmImpresionManifiestos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el boton de asignacion de cargas de sucursales y bancos
        /// </summary>
        private void btnAsignacionCargasSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                frmAsignacionCargasSucursales formulario = new frmAsignacionCargasSucursales(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el boton de revision de cargas
        /// </summary>
        private void btnRevisionCargas_Click(object sender, EventArgs e)
        {
            try
            {
                frmRevisionCierreSucursales formulario = new frmRevisionCierreSucursales(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de recepcion de tulas en boveda
        /// </summary>
        private void btnRecepcionTulasBoveda_Click(object sender, EventArgs e)
        {
            try
            {
                frmRecepcionEntregaTulas formulario = new frmRecepcionEntregaTulas(_usuario,1);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de manifiesto general
        /// </summary>
        private void btnManifiestoGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                frmVisualizarManifiestos formulario = new frmVisualizarManifiestos(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de mantenimiento de formulas
        /// </summary>
        private void btnFormulas_Click(object sender, EventArgs e)
        {
            try
            {
                frmFormulas formulario = new frmFormulas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el botón de aprobación de Recaps
        /// </summary>
        private void btnAprobacionPedidosATMs_Click(object sender, EventArgs e)
        {
            try
            {
                frmAprobacionPedidosATMs formulario = new frmAprobacionPedidosATMs(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el libro mayor de bóveda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLibroMayorBoveda_Click(object sender, EventArgs e)
        {
            try
            {
                frmLibroMayorBoveda formulario = new frmLibroMayorBoveda(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }





        /// <summary>
        /// Clic en el botón de Libro pedidos de bóveda
        /// </summary>
        private void btnLibroMayorPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                frmLibroMayorBovedaPedido formulario = new frmLibroMayorBovedaPedido(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Saldos de bóveda
        /// </summary>
        private void btnSaldosBoveda_Click(object sender, EventArgs e)
        {
            try
            {
                frmSaldosLibroInicial formulario = new frmSaldosLibroInicial(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Arqueos de bóveda
        /// </summary>
        private void btnArqueosBoveda_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoArqueoBoveda formulario = new frmMantenimientoArqueoBoveda(_usuario);
               // frmAdministracionArqueoBoveda formulario = new frmAdministracionArqueoBoveda(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        
        /// <summary>
        /// Libros Entrega Níquel
        /// </summary>
        private void btnLibroMayorEntregaNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                frmLibroMayorNiquelEntrega formulario = new frmLibroMayorNiquelEntrega(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Libros Pedidos Níquel
        /// </summary>
        private void btnLibroMayorPedidosNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                frmLibroMayorNiquelPedido formulario = new frmLibroMayorNiquelPedido(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaldosNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                frmSaldoLibroNiquel formulario = new frmSaldoLibroNiquel(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en los arqueos de níquel
        /// </summary>
        private void btnArqueosNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoArqueoNiquel formulario = new frmMantenimientoArqueoNiquel(_usuario);
                // frmAdministracionArqueoBoveda formulario = new frmAdministracionArqueoBoveda(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        


        #endregion Boveda
        
        #region ATM's

        /// <summary>
        /// Clic en el botón de registro de cierres en la pestaña de ATM's.
        /// </summary>
        private void btnCierresCajasATMs_Click(object sender, EventArgs e)
        {

            try
            {
                frmRegistroCierreATMs formulario = new frmRegistroCierreATMs(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de registro de las cargas de emergencia de los ATM's Full.
        /// </summary>
        private void btnCargasEmergenciaATMsFull_Click(object sender, EventArgs e)
        {
            frmListaCargasEmergenciaFull formulario = new frmListaCargasEmergenciaFull();

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de importar cargas.
        /// </summary>
        private void btnImportacionCargas_Click(object sender, EventArgs e)
        {

            try
            {
                frmImportacionCargas formulario = new frmImportacionCargas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de asignación de cargas.
        /// </summary>
        private void btnAsignacionCargas_Click(object sender, EventArgs e)
        {

            try
            {
                frmAsignacionCargas formulario = new frmAsignacionCargas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de listar cargas.
        /// </summary>
        private void btnListadoCargas_Click(object sender, EventArgs e)
        {

            try
            {
                frmListaCargas formulario = new frmListaCargas(_usuario);

                formulario.Show(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de listar descargas.
        /// </summary>
        private void btnListadoDescargas_Click(object sender, EventArgs e)
        {

            try
            {
                frmListaDescargas formulario = new frmListaDescargas();

                formulario.Show(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de listar descargas full.
        /// </summary>
        private void btnListadoDescargasFull_Click(object sender, EventArgs e)
        {

            try
            {
                frmListaDescargasFull formulario = new frmListaDescargasFull();

                formulario.Show(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de impresión de cargas.
        /// </summary>
        private void btnImpresionCargas_Click(object sender, EventArgs e)
        {

            try
            {
                frmImpresionCargas formulario = new frmImpresionCargas();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de buscar cargas.
        /// </summary>
        private void btnBusquedaCargas_Click(object sender, EventArgs e)
        {
            frmBusquedaCarga formulario = new frmBusquedaCarga();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de generar cargas.
        /// </summary>
        private void btnGeneracionCargas_Click(object sender, EventArgs e)
        {

            try
            {
                frmGeneracionCargas formulario = new frmGeneracionCargas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de recepción y despacho de cartuchos.
        /// </summary>
        private void btnRecepcionSalidaCartuchos_Click(object sender, EventArgs e)
        {
            frmDespachoRecepcionCartuchos formulario = new frmDespachoRecepcionCartuchos(_usuario);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de importar triales.
        /// </summary>
        private void btnImportarTriales_Click(object sender, EventArgs e)
        {
            frmImportacionTrialesDescargas formulario = new frmImportacionTrialesDescargas();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de listar triales.
        /// </summary>
        private void btnTriales_Click(object sender, EventArgs e)
        {
            frmListaTriales formulario = new frmListaTriales();

            formulario.ShowDialog();
        }



        /// <summary>
        /// Clic en el boton de Mantenimiento de Promedios de Descargas
        /// </summary>
        private void btnPromedioDescarga_Click(object sender, EventArgs e)
        {
            try
            {
                frmPromedioDescargasATM formulario = new frmPromedioDescargasATM(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el botón de Remanentes de ATM
        /// </summary>
        private void btnPromedioRemanenteATM_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionPromedioRemanenteATM formulario = new frmAdministracionPromedioRemanenteATM();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el botón de Generar Recapt Preliminar
        /// </summary>
        private void btnGenerarRecaptPreliminar_Click(object sender, EventArgs e)
        {
            try
            {
                frmGenerarRecaptPreliminar formulario = new frmGenerarRecaptPreliminar(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en Generar Recap Final 
        /// </summary>
        private void btnGenerarRecaptFinal_Click(object sender, EventArgs e)
        {
            try
            {
                frmGenerarRecaptFinal formulario = new frmGenerarRecaptFinal(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de cierre de cargas
        /// </summary>
        private void btnCierreCargas_Click(object sender, EventArgs e)
        {
            try
            {
                frmCierreCargas formulario = new frmCierreCargas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de cierre de descargas
        /// </summary>
        private void btnCierreDescargas_Click(object sender, EventArgs e)
        {
            try
            {
                frmCierreDescargas formulario = new frmCierreDescargas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic e el botón de inventario de cartuchos
        /// </summary>
        private void btnInventarioCartuchos_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoInventarios formulario = new frmMantenimientoInventarios(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el botón de administración de fallas de cartuchos
        /// </summary>
        private void btnFallasCartuchos_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionFallasCartuchos formulario = new frmAdministracionFallasCartuchos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el botón de administración de proveedores de cartuchos
        /// </summary>
        private void btnProveedoresCartuchos_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionProveedoresCartuchos formulario = new frmAdministracionProveedoresCartuchos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de garantía de cartuchos
        /// </summary>
        private void btnGarantiaCartuchos_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministraciónGarantiaCartuchos formulario = new frmAdministraciónGarantiaCartuchos(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de cargas masivas de fallas
        /// </summary>
        private void btnCargaMasivaFallas_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargaMasivaFallas formulario = new frmCargaMasivaFallas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el módulo de recepción de cartuchos
        /// </summary>
        private void btnRecepcionCartuchos_Click(object sender, EventArgs e)
        {
            try
            {
                frmRecepcionCartuchos formulario = new frmRecepcionCartuchos(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de cargas masivas de cartuchos
        /// </summary>
        private void btnCargaMasivaCartuchos_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargaMasivaCartuchos formulario = new frmCargaMasivaCartuchos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de reporte de recepción de cartuchos
        /// </summary>
        private void btnReporteRecepcion_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteRecepcionCartuchos formulario = new frmReporteRecepcionCartuchos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de reporte de fallas de cartuchos
        /// </summary>
        private void btnReporteFallasCartuchos_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteFallasEstadosCartuchos formulario = new frmReporteFallasEstadosCartuchos();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void btnLibroMayor_Click(object sender, EventArgs e)
        {
            try
            {
                frmGeneracionLibroMayor formulario = new frmGeneracionLibroMayor();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

         

        #endregion ATM's

        #region Administración
        
        /// <summary>
        /// Clic en el botón de generar el libro mayor de ATM's.
        /// </summary>
        private void btnGeneracionLibroMayorATMs_Click(object sender, EventArgs e)
        {
            frmGeneracionLibroMayorATMs formulario = new frmGeneracionLibroMayorATMs();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de revisar las cargas y descargas por día.
        /// </summary>
        private void btnRevisionCargasDescargas_Click(object sender, EventArgs e)
        {
            frmMonitoreoCargasDescargas formulario = new frmMonitoreoCargasDescargas();

            formulario.ShowDialog();
        }

        #endregion Administración

        #region Blindados

        /// <summary>
        /// Clic en el botón de modificar las cargas de emergencia.
        /// </summary>
        private void btnCargasEmergencia_Click(object sender, EventArgs e)
        {

            try
            {
                frmListaCargasEmergencia formulario = new frmListaCargasEmergencia(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el boton de Asignar una tripulacion
        /// </summary>
        private void btnAsignarTripulacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionTripulaciones formulario = new frmAdministracionTripulaciones(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de asignacion de rutas
        /// </summary>
        private void btnRutaRoadnet_Click(object sender, EventArgs e)
        {
            try
            {
               // frmListaCargasRoadnet formulario = new frmListaCargasRoadnet(_usuario);
                frmRutaRoadnet formulario = new frmRutaRoadnet(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de exportar cargas
        /// </summary>
        private void btnExportarCargasRoadnet_Click(object sender, EventArgs e)
        {
            try
            {
                 frmListaCargasRoadnet formulario = new frmListaCargasRoadnet(_usuario);
                //frmRutaRoadnet formulario = new frmRutaRoadnet(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// clic en el boton de mantenimiento de dispositivos
        /// </summary>
        private void btnDispositivo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionDispositivos formulario = new frmAdministracionDispositivos();
                //frmRutaRoadnet formulario = new frmRutaRoadnet(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de mantenimiento de tipos de equipo
        /// </summary>
        private void btnTipoEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionTipoEquipo formulario = new frmAdministracionTipoEquipo();
                
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de mantenimiento de manojos
        /// </summary>
        private void btnManojos_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionManojos formulario = new frmAdministracionManojos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de mantenimiento de implementos
        /// </summary>
        private void btnEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionEquipo formulario = new frmAdministracionEquipo(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de asignar equipo a tripulaciones
        /// </summary>
        private void btnAsignacionEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAsignarEquiposaTripulacion formulario = new frmAsignarEquiposaTripulacion(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de revision de vehiculo.
        /// </summary>
        private void btnRevisionVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                frmRevisionVehiculo formulario = new frmRevisionVehiculo(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Reporte de Revision Final de Portavalor
        /// </summary>
        private void btnRevisionPortavalor_Click(object sender, EventArgs e)
        {
            try
            {
                frmRevisionPortavalor formulario = new frmRevisionPortavalor(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el mantenimiento de esperas
        /// </summary>
        private void btnEsperas_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionEsperas formulario = new frmAdministracionEsperas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el botón de tipo de fallas
        /// </summary>
        private void btnTipoFallas_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionTipoFallas formulario = new frmAdministracionTipoFallas(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }





        /// <summary>
        /// Clic en la Hoja de ruta controlada
        /// </summary>
        private void btnHojaRutaControlada_Click(object sender, EventArgs e)
        {
            try
            {
                frmHojaControlRuta formulario = new frmHojaControlRuta(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        #endregion Blindados

        #region Análisis

        /// <summary>
        /// Clic en el botón de importar los remanentes de los ATM's desde AS400.
        /// </summary>
        private void btnImportacionRemanentesATMs_Click(object sender, EventArgs e)
        {
            frmImportacionRemanentesATMs formulario = new frmImportacionRemanentesATMs();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de revisar los remanentes de los ATM's.
        /// </summary>
        private void btnRevisionRemanentesATMs_Click(object sender, EventArgs e)
        {
            frmRevisionRemanentesATMs formulario = new frmRevisionRemanentesATMs();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de asignar los montos esperados retirados de los ATM's.
        /// </summary>
        private void btnMontosRetirosATMs_Click(object sender, EventArgs e)
        {

            try
            {
                frmMontosRetiros formulario = new frmMontosRetiros();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de iniciar el servicio automatizado.
        /// </summary>
        private void btnServicioAutomatizado_Click(object sender, EventArgs e)
        {
            frmControlServidorAutomatizado formulario = new frmControlServidorAutomatizado();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de monitorear ATM's.
        /// </summary>
        private void btnMonitoreoATMs_Click(object sender, EventArgs e)
        {
            frmMonitoreoATMs formulario = new frmMonitoreoATMs();

            formulario.ShowDialog();
        }


        private void btn_CargasdeEmergencia_Click(object sender, EventArgs e)
        {
            frmCargasEmergencia formulario = new frmCargasEmergencia(_usuario);

            formulario.ShowDialog();
        }

        /// <summary>
        /// Importación datos totales Remanentes ATM's desde AS400
        /// </summary>
       
        private void btnImportacionRemantenesCompleto_Click(object sender, EventArgs e)
        {
            frmImportaciónRemanentesATMsCompletos formulario = new frmImportaciónRemanentesATMsCompletos();
            formulario.ShowDialog();
        }


        private void btn_Cargas_Emergencia_Click(object sender, EventArgs e)
        {

        }
        #endregion Análisis

        #region Otros

        /// <summary>
        /// Clic en el botón de iniciar sesión.
        /// </summary>
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            frmLogin formulario = new frmLogin(this);

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de crear una conexión con AS400.
        /// </summary>
        private void btnConexionAS400_Click(object sender, EventArgs e)
        {
            frmLoginAS400 formulario = new frmLoginAS400();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de cerrar sesión.
        /// </summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _usuario = null;

            tmrRecordatorioGestiones.Stop();
            tmrAvisoCargaEmergencia.Stop();

            ntfSolicitudCodigos.Visible = false;
            ntfCargaEmergencia.Visible = false;

            this.Text = "Sistema de Tesorería";

            foreach(Button boton in _botones.Values)
                boton.Enabled = false;

            btnIniciarSesion.Enabled = true;
            btnCambiarContrasena.Enabled = false;
            btnCerrarSesion.Enabled = false;
            btnConexionAS400.Enabled = false;

            if (_recordatorio_gestiones != null)
                _recordatorio_gestiones.Close();

        }

        /// <summary>
        /// Clic en el botón de cambiar password.
        /// </summary>
        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            frmCambioContrasena formulario = new frmCambioContrasena(_usuario);

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de acerca de...
        /// </summary>
        private void btnAcerca_Click(object sender, EventArgs e)
        {
            frmAcerca formulario = new frmAcerca();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Otros

        #region Niquel

        private void btnConsolidadoNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsolidadoNiquel formulario = new frmConsolidadoNiquel(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de registro de entrega de tulas
        /// </summary>
        private void btnEntregaTulas_Click(object sender, EventArgs e)
        {
            //frmEntregaTulas formulario = new frmEntregaTulas(_usuario);

            frmEntregaTulasNiquel formulario = new frmEntregaTulasNiquel(_usuario);

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el listado de tulas
        /// </summary>
        private void btnListadoTulaNiquel_Click(object sender, EventArgs e)
        {
            frmListadoTulasNiquel formulario = new frmListadoTulasNiquel(_usuario);

            formulario.ShowDialog();
        }


        /// <summary>
        /// Clic en el boton de Generación de Pedidos de Níquel
        /// </summary>
        private void btnImportarPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                frmGenerarPedidosNiquel formulario = new frmGenerarPedidosNiquel(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Lista de Pedidos de Niquel
        /// </summary>

        private void btnListaPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaPedidosNiquel formulario = new frmListaPedidosNiquel(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el Boton de Asignacion de Pedidos Para Níquel
        /// </summary>
        private void btnAsignarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                frmAsignacionPedidos formulario = new frmAsignacionPedidos (_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el botón de Registro de Cierre de Níquel
        /// </summary>
        private void btnRegistroCierreNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistroCierreNiquel formulario = new frmRegistroCierreNiquel(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de cantidad de piezas por denominación
        /// </summary>
        private void btnCantidadMonedasBolsaNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoBolsasNiquel formulario = new frmMantenimientoBolsasNiquel();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el botón de máximas cantidades de tulas y bolsas por maniifestos
        /// </summary>
        private void btnCantidadesMaximasManifiesto_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionCantidadTulas formulario = new frmAdministracionCantidadTulas();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        #endregion Niquel

        #region Optimizacion

        


        /// <summary>
        /// Clic en el boton de Generacion de Cargas para Bancos
        /// </summary>
        private void btnGeneracionCargasBanco_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaPedidoBanco formulario = new frmListaPedidoBanco(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el boton de generacion de cargas de emergencia para sucursales
        /// </summary>
        private void btnEmergenciaSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                frmGeneracionCargasEmergenciaSucursal formulario = new frmGeneracionCargasEmergenciaSucursal(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de lista de cargas de emergencia de sucursales
        /// </summary>
        private void btnListaCargaEmergenciaSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaCargasEmergenciaSucursales formulario = new frmListaCargasEmergenciaSucursales(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de aprobacion de pedidos para sucursales
        /// </summary>
        private void btnAprobacionPedidosSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                frmSucursalesPorAprobar formulario = new frmSucursalesPorAprobar(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de correccion de cargas de sucursales
        /// </summary>
        private void btnCorreccionCargasSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                frmCorreccionCargasSucursalesGerente formulario = new frmCorreccionCargasSucursalesGerente(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en los pedidos de mutilados
        /// </summary>
        private void btnPedidoMutilados_Click(object sender, EventArgs e)
        {
            try
            {
                frmMutilado formulario = new frmMutilado(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }




        /// <summary>
        /// Clic en el boton de validar la facturación
        /// </summary>
        private void btnValidarFacturacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmValidacionFacturacion formulario = new frmValidacionFacturacion(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de mantenimiento de inconsistencias de facturacoin
        /// </summary>
        private void btnMantenimientoInconsistenciasFacturacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionInconsistenciaFacturacion formulario = new frmAdministracionInconsistenciaFacturacion();
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de la lista de inconsistencias de facturacion
        /// </summary>
        private void btnInconsistenciasFacturacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmBandejaInconsistenciasFacturacion formulario = new frmBandejaInconsistenciasFacturacion(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }




        /// <summary>
        /// Clic en el boton de Tipos de Penalidades
        /// </summary>
        private void btnTipoPenalidades_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionTipoPenalidad formulario = new frmAdministracionTipoPenalidad();
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de Mantenimiento de Penalidades
        /// </summary>
        private void btnPenalidades_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionPenalidades formulario = new frmAdministracionPenalidades();
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el boton de Registro de Penalidades
        /// </summary>
        private void btnRegistroPenalidades_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionRegistroPenalidades formulario = new frmAdministracionRegistroPenalidades(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el nivel de servicio
        /// </summary>
        private void btnNivelServicio_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionNivelServicio formulario = new frmAdministracionNivelServicio(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el boton de pago de tarifa a transportadora
        /// </summary>
        private void btnResumenPagoTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                frmResumenFacturacionTransportadora formulario = new frmResumenFacturacionTransportadora(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de Resumen de la Facturación de los Clientes
        /// </summary>
        private void btnFacturacionCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmResumenFacturacion formulario = new frmResumenFacturacion(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el botón de descargas ENA
        /// </summary>
        private void btnDescargaENA_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteDescargaENA formulario = new frmReporteDescargaENA();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de Facturación de envios
        /// </summary>
        private void btnFacturacionEnvios_Click(object sender, EventArgs e)
        {
            try
            {
                frmValidacionTarifasEnvios formulario = new frmValidacionTarifasEnvios(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }





        /// <summary>
        /// Clic en el botón de facturación de procesamiento
        /// </summary>
        private void btnFacturacionProcesamiento_Click(object sender, EventArgs e)
        {
            try
            {
                frmFacturacionProcesamiento formulario = new frmFacturacionProcesamiento(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPedidoTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionPedidosTransportadoras formulario = new frmAdministracionPedidosTransportadoras(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de aprobar pedidos de transportadora
        /// </summary>
        private void btnAprobarPedidosTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                frmPedidosTransportadoraAprobar formulario = new frmPedidosTransportadoraAprobar(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el botón de corregir pedidos de transportadora
        /// </summary>
        private void btnCorregirPedidosTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                frmCorreccionPedidosTransportadora formulario = new frmCorreccionPedidosTransportadora(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


       
        


        #endregion Optimizacion

        #region Sucursales
        /// <summary>
        /// Clic en el boton de Mostrar Manifiesto de Sucursal
        /// </summary>
        private void btnManifiestoSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                frmManifiestoSucursal formulario = new frmManifiestoSucursal(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el boton de Pedidos para Sucursales
        /// </summary>
        private void btnGeneracionCargasSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaCargaSucursales formulario = new frmListaCargaSucursales(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de recepcion de tulas para sucursales
        /// </summary>
        private void btnRecepcionTulasSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                frmRecepcionEntregaTulasSucursales formulario = new frmRecepcionEntregaTulasSucursales(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el boton de envio y pedidos de sucursales
        /// </summary>
        private void btnEnvioPedidoRemesas_Click(object sender, EventArgs e)
        {
            try
            {
                frmEnvioPedidoRemesas formulario = new frmEnvioPedidoRemesas(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        #endregion Sucursales

        #region Cajeros Automaticos

        /// <summary>
        /// Clic en el boton de solicitud de codigos de cajeros automaticos
        /// </summary>
        private void btnSolicitudCodigoCajeros_Click(object sender, EventArgs e)
        {

            try
            {
                frmListaCargasATMCajerosAutomaticos formulario = new frmListaCargasATMCajerosAutomaticos(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Cajeros Automaticos

        #region Control Interno
        /// <summary>
        /// Clic en el botón de arqueos de control interno
        /// </summary>
        private void btnArqueoControlInterno_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionArqueos formulario = new frmAdministracionArqueos(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }




        private void btnControlCajas_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionControlCajas formulario = new frmAdministracionControlCajas(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        private void btnLibroMayorCI_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaDescargas formulario = new frmListaDescargas();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnLibroMayorFull_Click(object sender, EventArgs e)
        {
            try
            {
                frmGeneracionLibroMayorFull formulario = new frmGeneracionLibroMayorFull();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        private void btnListadoDescargasCI_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaDescargas formulario = new frmListaDescargas();

                formulario.Show(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnListadoDescargasFullCI_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaDescargasFull formulario = new frmListaDescargasFull();

                formulario.Show(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        private void btnCargasCI_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaCargas formulario = new frmListaCargas(_usuario);

                formulario.Show(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        #endregion Control Interno

        #region Mantenimiento Equipos

        private void btnMantenimientoEquipos_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionEquipos formulario = new frmAdministracionEquipos();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnFichaTecnica_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionFichaTecnicaEquipos formulario = new frmAdministracionFichaTecnicaEquipos();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnSolicitudMantenimientoEquipos_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionSolicitudRequerimientos formulario = new frmAdministracionSolicitudRequerimientos(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnCoordinacionProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionCoordinacionProveedor formulario = new frmAdministracionCoordinacionProveedor();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdministracionProveedoresEquipos formulario = new frmAdministracionProveedoresEquipos();

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Mantenimiento Equipos

        #region Recepcion

        private void btnRecepcionDocs_Click(object sender, EventArgs e)
        {
            try
            {
                frmRecepcionDocumentos formulario = new frmRecepcionDocumentos(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Recepcion

        /// <summary>
        /// Timer de la ventana del recordatorio de las gestions que etán a punto de vencer.
        /// </summary>
        private void tmrRecordatorioGestiones_Tick(object sender, EventArgs e)
        {
            this.mostrarRecordatorioGestiones();
        }

        /// <summary>
        /// clic en el boton del Robot de AS400, que carga las 
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            frmRobotAS400 formulario = new frmRobotAS400(_usuario);

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de cuarde de depósitos
        /// </summary>
        private void btnCuadreDepositos_Click(object sender, EventArgs e)
        {
            try
            {
                frmCuadreDepositos formulario = new frmCuadreDepositos(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnProcesamientoBajoVolumen_Click(object sender, EventArgs e)
        {
            try
            {
                frmBajoVolumenIngresoManifiesto formulario = new frmBajoVolumenIngresoManifiesto(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnConsolidadoBoveda_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsolidadoBoveda formulario = new frmConsolidadoBoveda(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarRecapt_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaRecapPreliminar formulario = new frmListaRecapPreliminar(_usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        #endregion Eventos

        #region Métodos Privados

        private void GenerarExcelAcreditacion(DataTable datos)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\AcreditacionIBS.xlsx", false);
                documento.seleccionarHoja(1);

                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    documento.seleccionarCelda("A" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Codigo"]);

                    documento.seleccionarCelda("B" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Cuenta"]);

                    documento.seleccionarCelda("C" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Verificar_Cuenta"]);

                    documento.seleccionarCelda("E" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Monto"]);

                    documento.seleccionarCelda("F" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Referencia"]);

                    documento.seleccionarCelda("G" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Punto_Venta"]);

                    documento.seleccionarCelda("I" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Identificacion"]);

                    documento.seleccionarCelda("K" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Deposito"]);

                    documento.seleccionarCelda("L" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Manifiesto"]);

                    documento.seleccionarCelda("M" + Convert.ToString(i + 2));
                    documento.actualizarValorCelda(datos.Rows[i]["Cliente"]);
                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Mostrar la ventana de recordatorio de gestiones pendientes.
        /// </summary>
        private void mostrarRecordatorioGestiones()
        {

            try
            {

                if (_recordatorio_gestiones != null) return;

                _recordatorio_gestiones = new frmRecordatorioGestiones();
                _recordatorio_gestiones.Show(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Actualiza la lista de cargas de emergencia
        /// </summary>
        private void tmrAvisoCargaEmergencia_Tick(object sender, EventArgs e)
        {
            if (BuscarPendientes())
            {
                MostrarNotificacion();
            }
            if (BuscarPendientesSolicitudApertura())
                MostrarNotificacionSolicitudCodigosApertura();
            if (BuscarPendientesSolicitudCierre())
                MostrarNotificacionSolicitudCodigosCierre();
        }


        /// <summary>
        /// Busca si existen cargas de emergencia pendientes
        /// </summary>
        private bool BuscarPendientes()
        {
            bool auxiliar = true;

            if (_coordinacion.listarCargasEmergenciaSucursales(DateTime.Today) == null)
                auxiliar = false;

            return auxiliar;
        }



        /// <summary>
        /// Busca si existen cargas solicitudes de códigos de apertura pendientes pendientes
        /// </summary>
        private bool BuscarPendientesSolicitudApertura()
        {
            return _coordinacion.listarNotificacionApertura(DateTime.Today);

        }

        /// <summary>
        /// Busca si existen cargas solicitudes de códigos de cierre pendientes por enviar
        /// </summary>
        private bool BuscarPendientesSolicitudCierre()
        {
            return _coordinacion.listarNotificacionCierre(DateTime.Today);

        }


        /// <summary>
        /// Muestra las notificaciones de cargas de emergencia pendientes
        /// </summary>
        private void MostrarNotificacion()
        {
            ntfCargaEmergencia.Visible = true;
            ntfCargaEmergencia.BalloonTipText = "Hay cargas pendientes, favor revisar";
            ntfCargaEmergencia.BalloonTipTitle = "Cargas de Emergencia Pendientes";
            ntfCargaEmergencia.BalloonTipIcon = ToolTipIcon.Info;
            ntfCargaEmergencia.Visible = false;
            ntfCargaEmergencia.ShowBalloonTip(10000);
        }


        /// <summary>
        /// Muestra si existe una solicitud de códigos de cajeros automáticos
        /// </summary>
        private void MostrarNotificacionSolicitudCodigosApertura()
        {
            ntfSolicitudCodigos.Visible = true;
            ntfSolicitudCodigos.BalloonTipText = "Existen Códigos de Apertura por Enviar";
            ntfSolicitudCodigos.BalloonTipTitle = "Solicitud de Códigos de Apertura";
            ntfSolicitudCodigos.BalloonTipIcon = ToolTipIcon.Warning;
            ntfSolicitudCodigos.ShowBalloonTip(10000);
       
        }


        /// <summary>
        /// Muestra si existe una solicitud de códigos de cierre de cajeros automáticos
        /// </summary>
        private void MostrarNotificacionSolicitudCodigosCierre()
        {
            ntfSolicitudCodigos.Visible = true;
            ntfSolicitudCodigos.BalloonTipText = "Existen Códigos de Cierre Por Finalizar";
            ntfSolicitudCodigos.BalloonTipTitle = "Envío de Códigos de Cierre";
            ntfSolicitudCodigos.BalloonTipIcon = ToolTipIcon.Info;
            ntfSolicitudCodigos.ShowBalloonTip(10000);

        }
        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Habilitar las opciones del sistema según los permisos del usuario.
        /// </summary>
        public void iniciarSesion(Colaborador usuario)
        {
            _usuario = usuario;

            this.Text = String.Format(TITULO, _usuario.Nombre, _usuario.Primer_apellido);

            if (_usuario.Administrador_general)
            {

                foreach (Button boton in _botones.Values)
                    boton.Enabled = true;

            }
            else
            {

                foreach (Perfil perfil in _usuario.Perfiles)
                {

                    foreach (Opcion opcion in perfil.Opciones)
                    {
                        string boton = opcion.Boton;

                        if (_botones.ContainsKey(opcion.Boton))
                            _botones[boton].Enabled = true;

                    }
                }

            }

            if (_usuario.Puestos.Contains(Puestos.Operador_Monitoreo) && _usuario.Area == Areas.ATMs)
            {
                tmrAvisoCargaEmergencia.Start();
            }

            //MostrarNotificacionSolicitudCodigosApertura();
            btnIniciarSesion.Enabled = false;
            btnCambiarContrasena.Enabled = true;
            btnCerrarSesion.Enabled = true;
            btnConexionAS400.Enabled = true;
        }

        /// <summary>
        /// Cerra la ventana de gestiones pendientes.
        /// </summary>
        public void cerrarRecordatorioGestiones()
        {
            _recordatorio_gestiones = null;
        }








        #endregion Métodos Públicos

        #region PROA
        private void btnProcesamientoAltoVolumen_Click(object sender, EventArgs e)
        {
            try
            {
                frmProcesamientoAltoVolumen formulario = new frmProcesamientoAltoVolumen(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnProcesamientoBajoVolumen_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmBajoVolumenIngresoManifiesto formulario = new frmBajoVolumenIngresoManifiesto(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnInconsistenciasResolver_Click(object sender, EventArgs e)
        {
            try
            {
                frmInconsistenciasPorResolver formulario = new frmInconsistenciasPorResolver(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnConsultaFormularios_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaFormularios formulario = new frmConsultaFormularios();
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnCierreCajero_Click(object sender, EventArgs e)
        {
            try
            {
                frmCierreCajero formulario = new frmCierreCajero(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaInfoManifiesto formulario = new frmConsultaInfoManifiesto(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnManifiestosPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                frmManifiestosPendientes formulario = new frmManifiestosPendientes(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnValidacionNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                frmValidacionCajeroNiquel formulario = new frmValidacionCajeroNiquel(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnMontosProcesosExternos_Click(object sender, EventArgs e)
        {
            try
            {
                frmMontosProcesosExternos formulario = new frmMontosProcesosExternos(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnValidacionBPS_Click(object sender, EventArgs e)
        {
            try
            {
                frmValidacionAltoVolumen formulario = new frmValidacionAltoVolumen(1, ref _usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnValidacionMGR_Click(object sender, EventArgs e)
        {
            try
            {
                frmValidacionAltoVolumen formulario = new frmValidacionAltoVolumen(0, ref _usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnMonitoreoLE_Click(object sender, EventArgs e)
        {
            try
            {
                frmMonitoreoLimiteEfectivo formulario = new frmMonitoreoLimiteEfectivo(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnEntregaNiquel_Click(object sender, EventArgs e)
        {
            frmEntregaNiquelMesa formulario = new frmEntregaNiquelMesa(_usuario);
            formulario.ShowDialog();
        }

        private void btnImpresionInconManifiesto_Click(object sender, EventArgs e)
        {
            frmInconsistenciasManifiesto formulario = new frmInconsistenciasManifiesto(_usuario);
            formulario.ShowDialog();
        }

        private void btnAcreditacionPROA_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea ejecutar la macro de acreditación IBS?", "Confirmación de ejecución de macro de Acreditación IBS",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    GenerarExcelAcreditacion(_mantenimiento.ObtenerInformacionCorteAcreditacionIBS(_usuario));
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }
        private void btnCargaInfoTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                frmProaCargaMasiva formulario = new frmProaCargaMasiva(_usuario);
                formulario.ShowDialog();
                //frmCargaInformacionTransportadora formulario = new frmCargaInformacionTransportadora(_usuario);
                //formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnAjustesManifiestoBVPROA_Click(object sender, EventArgs e)
        {
            try
            {
                frmReaperturarManifiestos formulario = new frmReaperturarManifiestos(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultaAltoVolumen_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaAltoVolumen formulario = new frmConsultaAltoVolumen(_usuario);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion PROA


    }

}
