//
//  @ Project : 
//  @ File Name : frmRegistroCierreCEF.cs
//  @ Date : 27/07/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;


using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmRegistroCierreCEF : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CierreCEF _cierre = null;
        private Colaborador _coordinador = null;
        private TipoCambio _tipo_cambio;
        private TipoCambio _tipo_cambio_impresion;

        private DateTime _fecha;


        private DocumentoExcel documento = null;

        private bool seleccionarcajero = false; 

        private decimal _ingreso_clientes_colones = 0;
        private decimal _saldo_dia_anterior_colones = 0;
        private decimal _reporte_cajero_colones = 0;
        private decimal _otros_ingresos_colones = 0;
        private decimal _otros_egresos_colones = 0;
        private decimal _cheques_locales_colones = 0;
        private decimal _cheques_exterior_colones = 0;
        private decimal _cheques_bac_colones = 0;
        private decimal _salidas_niquel_colones = 0;
        private decimal _niquel_pendiente_colones = 0;
        private decimal _niquel_pendiente_dia_anterior_colones = 0;
        private decimal _faltante_cliente_niquel_colones = 0;
        private decimal _sobrante_cliente_niquel_colones = 0;
        private decimal _entregas_boveda_colones = 0;
        private decimal _entregas_pendientes_colones = 0;
        private decimal _faltante_clientes_colones = 0;
        private decimal _sobrante_clientes_colones = 0;
        private decimal _faltante_quinientos_colones = 0;
        private decimal _sobrante_quinientos_colones = 0;
        private decimal _efectivo_cajero_colones = 0;
        private decimal _saldo_cierre_colones = 0;

        private decimal _ingreso_clientes_dolares = 0;
        private decimal _saldo_dia_anterior_dolares = 0;
        private decimal _reporte_cajero_dolares = 0;
        private decimal _otros_ingresos_dolares = 0;
        private decimal _otros_egresos_dolares = 0;
        private decimal _cheques_locales_dolares = 0;
        private decimal _cheques_exterior_dolares = 0;
        private decimal _cheques_bac_dolares = 0;
        private decimal _salidas_niquel_dolares = 0;
        private decimal _niquel_pendiente_dolares = 0;
        private decimal _niquel_pendiente_dia_anterior_dolares = 0;
        private decimal _faltante_cliente_niquel_dolares = 0;
        private decimal _sobrante_cliente_niquel_dolares = 0;
        private decimal _entregas_boveda_dolares = 0;
        private decimal _entregas_pendientes_dolares = 0;
        private decimal _faltante_clientes_dolares = 0;
        private decimal _sobrante_clientes_dolares = 0;
        private decimal _faltante_quinientos_dolares = 0;
        private decimal _sobrante_quinientos_dolares = 0;
        private decimal _efectivo_cajero_dolares = 0;
        private decimal _saldo_cierre_dolares = 0;

        private decimal _compra_dolares = 0;
        private decimal _venta_dolares = 0;

        private bool _seleccion_fecha_cierre = false;
        private bool _seleccion_fecha_impresion = false;
        private bool _fecha_valida  = false;
        private bool _coordinador_valido = false;
        private bool _supervisor = false;
        private bool _nuevo = false;



        private decimal _ingreso_clientes_euros = 0;
        private decimal _saldo_dia_anterior_euros = 0;
        private decimal _reporte_cajero_euros = 0;
        private decimal _otros_ingresos_euros = 0;
        private decimal _otros_egresos_euros = 0;
        private decimal _cheques_locales_euros = 0;
        private decimal _cheques_exterior_euros = 0;
        private decimal _cheques_bac_euros = 0;
        private decimal _salidas_niquel_euros = 0;
        private decimal _niquel_pendiente_euros = 0;
        private decimal _niquel_pendiente_dia_anterior_euros = 0;
        private decimal _faltante_cliente_niquel_euros = 0;
        private decimal _sobrante_cliente_niquel_euros = 0;
        private decimal _entregas_boveda_euros = 0;
        private decimal _entregas_pendientes_euros = 0;
        private decimal _faltante_clientes_euros = 0;
        private decimal _sobrante_clientes_euros = 0;
        private decimal _faltante_quinientos_euros = 0;
        private decimal _sobrante_quinientos_euros = 0;
        private decimal _efectivo_cajero_euros = 0;
        private decimal _saldo_cierre_euros = 0;

        #endregion Atributos

        #region Constructor

        public frmRegistroCierreCEF(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            if (_coordinador.Puestos.Contains(Puestos.Supervisor))
                btnMontosCierreTotalSupervision.Enabled = true;
            else
                btnMontosCierreTotalSupervision.Enabled = false;


            try
            {
                this.actualizarListaCierres();
                this.actualizarListaSaldos();
                this.actualizarListaManifiestos();

                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);
                cboCajeroMontos.ListaMostrada = cboCajero.ListaMostrada;
                cboImpresionCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);

                cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
                cboDigitadorMontos.ListaMostrada = cboDigitador.ListaMostrada;
                cboImpresionDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);

                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);

                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

            this.crearTabla(dgvCierre);
            this.crearTabla(dgvConsolidado);

            // Dar fomato a las filas



            // Cargar los datos

            this.obtenerTipoCambio();
            this.obtenerTipoCambioImpresion();

            // Validar si el usuario puede cambiar la fecha del cierre

            _supervisor = coordinador.Puestos.Contains(Puestos.Supervisor);
        }

        /// <summary>
        /// Crear las filas de los DataGridView's.
        /// </summary>
        private void crearTabla(DataGridView tabla)
        {
            tabla.Rows.Add("Manifiestos", 0, string.Empty, string.Empty);
            tabla.Rows.Add("Tulas", 0, string.Empty, string.Empty);
            tabla.Rows.Add("Depositos", 0, string.Empty, string.Empty);
            tabla.Rows.Add("Cheques", 0, string.Empty, string.Empty);
            tabla.Rows.Add("Sobres", 0, string.Empty, string.Empty);
            tabla.Rows.Add("Disconformidades", 0, string.Empty, string.Empty);
            tabla.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty);
            tabla.Rows.Add("Ingreso Clientes", 0, 0, 0);
            tabla.Rows.Add("Reporte Cajero", 0, 0, 0);
            tabla.Rows.Add("Diferencia", 0, 0, 0);
            tabla.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty);
            tabla.Rows.Add("Saldo Día Anterior", 0, 0, 0);
            tabla.Rows.Add("Otros Ingresos", 0, 0, 0);
            tabla.Rows.Add("Otros Egresos", 0, 0, 0);
            tabla.Rows.Add("Cheques Locales", 0, 0, 0);
            tabla.Rows.Add("Cheques del Exterior", 0, 0, 0);
            tabla.Rows.Add("Cheques del BAC", 0, 0, 0);
            tabla.Rows.Add("Salidas de Niquel", 0, 0, 0);
            tabla.Rows.Add("Níquel Pendiente", 0, 0, 0);
            tabla.Rows.Add("Níquel Pendientes del Día Anterior", 0, 0, 0);
            tabla.Rows.Add("Faltantes Clientes Níquel", 0, 0, 0);
            tabla.Rows.Add("Sobrantes Clientes Níquel", 0, 0, 0);
            tabla.Rows.Add("Entregas de Boveda", 0, 0, 0);
            tabla.Rows.Add("Entregas Pendientes", 0, 0, 0);
            tabla.Rows.Add("Faltante Clientes", 0, 0, 0);
            tabla.Rows.Add("Sobrante Clientes", 0, 0, 0);
            tabla.Rows.Add("Faltante Menores 500", 0, 0, 0);
            tabla.Rows.Add("Sobrante Menores 500", 0, 0, 0);
            tabla.Rows.Add("Efectivo Cajero", 0, 0, 0);
            tabla.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty);
            tabla.Rows.Add("Compra de Dolares", 0, 0, 0);
            tabla.Rows.Add("Venta de Dolares", 0, 0, 0);
            tabla.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty);
            tabla.Rows.Add("Saldo Cierre", 0, 0, 0);
            tabla.Rows.Add("Faltante Sobrante", 0, 0, 0);
            

            this.protegerCeldas(tabla);
        }

        /// <summary>
        /// Proteger las celdas para evitar su edición.
        /// </summary>
        private void protegerCeldas(DataGridView tabla)
        {
            this.formatoCeldaSoloLectura(tabla, 7, 9, 24, 25, 33, 34);
            this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 3, 4, 5);
            this.formatoCeldaSoloLectura(tabla, 0, 1, 2);

            this.formatoCeldaSeparador(tabla, 6, 10, 29, 32);

            this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 30);
            this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 31);

            this.formatoCeldaFormato(tabla, MontoColones.Index, "N0", 0, 1, 2, 3, 4, 5);
        }

        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLectura(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = Concepto.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato  de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLecturaColumna(DataGridView tabla, int columna, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla[columna, fila].ReadOnly = true;
                tabla[columna, fila].Style.BackColor = Concepto.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato a las celdas que lo requieran.
        /// </summary>
        private void formatoCeldaFormato(DataGridView tabla, int columna, string formato, params int[] filas)
        {

            foreach (int fila in filas) tabla[columna, fila].Style.Format = "N0";
 
        }

        /// <summary>
        /// Dar formato a las celdas que son separadoras.
        /// </summary>
        private void formatoCeldaSeparador(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = tabla.GridColor;
            }

        }

    

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar el consolidado.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                this.actualizarConsolidado();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de listar los cierres.
        /// </summary>
        private void btnListar_Click(object sender, EventArgs e)
        {

            try
            {
                this.actualizarListaCierres();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboCajero.SelectedItem == null || cboDigitador.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorCierreDatosRegistro");
                return;
            }

            try
            {
                Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;

                string observaciones = txtObservaciones.Text;

                short cheques = Convert.ToInt16(dgvCierre[MontoColones.Index, 3].Value);
                short sobres = Convert.ToInt16(dgvCierre[MontoColones.Index, 4].Value);
                short disconformidades = Convert.ToInt16(dgvCierre[MontoColones.Index, 5].Value);

                _cierre.Digitador = digitador;

                _cierre.Observaciones = observaciones;

                _cierre.Cheques = cheques;
                _cierre.Sobres = sobres;
                _cierre.Disconformidades = disconformidades;

                _cierre.Reporte_cajero_colones = _reporte_cajero_colones;
                _cierre.Saldo_dia_anterior_colones = _saldo_dia_anterior_colones;
                _cierre.Otros_ingresos_colones = _otros_ingresos_colones;
                _cierre.Otros_egresos_colones = _otros_egresos_colones;
                _cierre.Cheques_locales_colones = _cheques_locales_colones;
                _cierre.Cheques_exterior_colones = _cheques_exterior_colones;
                _cierre.Cheques_bac_colones = _cheques_bac_colones;
                _cierre.Salidas_niquel_colones = _salidas_niquel_colones;
                _cierre.Niquel_pendiente_colones = _niquel_pendiente_colones;
                _cierre.Niquel_pendiente_dia_anterior_colones = _niquel_pendiente_dia_anterior_colones;
                _cierre.Faltante_cliente_niquel_colones = _faltante_cliente_niquel_colones;
                _cierre.Sobrante_cliente_niquel_colones = _sobrante_cliente_niquel_colones;
                _cierre.Entregas_boveda_colones = _entregas_boveda_colones;
                _cierre.Entregas_pendientes_colones = _entregas_pendientes_colones;
                _cierre.Faltante_quinientos_colones = _faltante_quinientos_colones;
                _cierre.Sobrante_quinientos_colones = _sobrante_quinientos_colones;
                _cierre.Efectivo_cajero_colones = _efectivo_cajero_colones;
                _cierre.Saldo_cierre_colones = _saldo_cierre_colones;
                _cierre.Compra_dolares = _compra_dolares;

                _cierre.Reporte_cajero_dolares = _reporte_cajero_dolares;
                _cierre.Saldo_dia_anterior_dolares = _saldo_dia_anterior_dolares;
                _cierre.Otros_ingresos_dolares = _otros_ingresos_dolares;
                _cierre.Otros_egresos_dolares = _otros_egresos_dolares;
                _cierre.Cheques_locales_dolares = _cheques_locales_dolares;
                _cierre.Cheques_exterior_dolares = _cheques_exterior_dolares;
                _cierre.Cheques_bac_dolares = _cheques_bac_dolares;
                _cierre.Salidas_niquel_dolares = _salidas_niquel_dolares;
                _cierre.Niquel_pendiente_dolares = _niquel_pendiente_dolares;
                _cierre.Niquel_pendiente_dia_anterior_dolares = _niquel_pendiente_dia_anterior_dolares;
                _cierre.Faltante_cliente_niquel_dolares = _faltante_cliente_niquel_dolares;
                _cierre.Sobrante_cliente_niquel_dolares = _sobrante_cliente_niquel_dolares;
                _cierre.Entregas_boveda_dolares = _entregas_boveda_dolares;
                _cierre.Entregas_pendientes_dolares = _entregas_pendientes_dolares;
                _cierre.Faltante_quinientos_dolares = _faltante_quinientos_dolares;
                _cierre.Sobrante_quinientos_dolares = _sobrante_quinientos_dolares;
                _cierre.Efectivo_cajero_dolares = _efectivo_cajero_dolares;
                _cierre.Saldo_cierre_dolares = _saldo_cierre_dolares;
                _cierre.Venta_dolares = _venta_dolares;




                // Euros


                _cierre.Reporte_cajero_euros = _reporte_cajero_euros;
                _cierre.Saldo_dia_anterior_euros = _saldo_dia_anterior_euros;
                _cierre.Otros_ingresos_euros = _otros_ingresos_euros;
                _cierre.Otros_egresos_euros = _otros_egresos_euros;
                _cierre.Cheques_locales_euros = _cheques_locales_euros;
                _cierre.Cheques_exterior_euros = _cheques_exterior_euros;
                _cierre.Cheques_bac_euros = _cheques_bac_euros;
                _cierre.Salidas_niquel_euros = _salidas_niquel_euros;
                _cierre.Niquel_pendiente_euros = _niquel_pendiente_euros;
                _cierre.Niquel_pendiente_dia_anterior_euros = _niquel_pendiente_dia_anterior_euros;
                _cierre.Faltante_cliente_niquel_euros = _faltante_cliente_niquel_euros;
                _cierre.Sobrante_cliente_niquel_euros = _sobrante_cliente_niquel_euros;
                _cierre.Entregas_boveda_euros = _entregas_boveda_euros;
                _cierre.Entregas_pendientes_euros = _entregas_pendientes_euros;
                _cierre.Faltante_quinientos_euros = _faltante_quinientos_euros;
                _cierre.Sobrante_quinientos_euros = _sobrante_quinientos_euros;
                _cierre.Efectivo_cajero_euros = _efectivo_cajero_euros;
                _cierre.Saldo_cierre_euros = _saldo_cierre_euros;
                
                // Verificar si el cierre se registra por primera vez

                if (_nuevo)
                {
                    // Agregar el cierre

                    _coordinacion.agregarCierre(ref _cierre);

                    _nuevo = false;

                    btnEliminar.Enabled = _coordinador_valido;

                    Mensaje.mostrarMensaje("MensajeCierreConfirmacionRegistro");
                }
                else
                {
                    // Actualizar los datos del cierre

                    _coordinacion.actualizarCierre(_cierre);

                    Mensaje.mostrarMensaje("MensajeCierreConfirmacionActualizacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCierreEliminacion") == DialogResult.Yes)
                {
                    _coordinacion.eliminarCierre(_cierre);

                    Mensaje.mostrarMensaje("MensajeCierreConfirmacionEliminacion");

                    btnEliminar.Enabled = false;

                    // Reiniciar el cierre

                    Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                    Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;
                   

                    CierreCEF nuevo = new CierreCEF(fecha: _fecha, cajero: cajero, digitador: digitador, coordinador: _coordinador);

                    nuevo.Ingreso_clientes_colones = _cierre.Ingreso_clientes_colones;
                    nuevo.Ingreso_clientes_dolares = _cierre.Ingreso_clientes_dolares;

                    nuevo.Manifiestos = _cierre.Manifiestos;
                    nuevo.Depositos = _cierre.Depositos;
                    nuevo.Tulas = _cierre.Tulas;

                    _cierre = nuevo;
                    _nuevo = true;

                    this.mostrarDatos();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de actualizar la lista de saldos.
        /// </summary>
        private void btnActualizarSaldos_Click(object sender, EventArgs e)
        {
            this.actualizarListaSaldos();
        }

        /// <summary>
        /// Clic en el botón de actualizar la lista de manifiestos.
        /// </summary>
        private void btnActualizarManifiesto_Click(object sender, EventArgs e)
        {
            this.actualizarListaManifiestos();
        }

        /// <summary>
        /// Click en el botón de exportar a Excel.
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

            try
            {
                
                this.exportar();
                
            }
            catch (Excepcion ex)
            {
                this.documento.cerrar();
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                this.documento.cerrar();
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Clic en el botón de actualizar la lista de montos por cliente.
        /// </summary>
        private void btnActualizarMontosClientes_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFechaMontos.Value;

                if (!chkFiltrar.Checked)
                {
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesCoordinadorCierre(_coordinador, fecha);
                }
                else if (rbMontosCajero.Checked && cboCajeroMontos.SelectedItem != null)
                {
                    Colaborador cajero = (Colaborador)cboCajeroMontos.SelectedItem;
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesCajeroCoordinadorCierre(cajero, _coordinador, fecha);
                }
                else if (rbMontosDigitador.Checked && cboDigitadorMontos.SelectedItem != null)
                {
                    Colaborador digitador = (Colaborador)cboDigitadorMontos.SelectedItem;
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesDigitadorCoordinadorCierre(digitador, _coordinador, fecha);
                }
                else
                {
                    dgvMontosClientes.DataSource = null;
                }

                dgvMontosClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvMontosClientes.AutoResizeColumns();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Clic en el boton de Actualizar datos por Supervisor
        /// </summary>
        private void btnMontosCierreTotalSupervision_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFechaMontos.Value;

                if (!chkFiltrar.Checked)
                {
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesSupervisorCierre(fecha);
                }
                else if (rbMontosCajero.Checked && cboCajeroMontos.SelectedItem != null)
                {
                    Colaborador cajero = (Colaborador)cboCajeroMontos.SelectedItem;
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesCajeroSupervisorCierre(cajero, fecha);
                }
                else if (rbMontosDigitador.Checked && cboDigitadorMontos.SelectedItem != null)
                {
                    Colaborador digitador = (Colaborador)cboDigitadorMontos.SelectedItem;
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesDigitadorSupervisorCierre(digitador, fecha);
                }
                else
                {
                    dgvMontosClientes.DataSource = null;
                }

                dgvMontosClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvMontosClientes.AutoResizeColumns();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validar las celdas de montos.
        /// </summary>
        private void dgvCierre_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == Concepto.Index) return;

            DataGridViewCell celda = dgvCierre[e.ColumnIndex, e.RowIndex];

            if (e.RowIndex > 6)
            {
                decimal valor = 0;

                if (!decimal.TryParse(celda.Value.ToString(), out valor))
                    celda.Value = valor;
            }
            else
            {
                int valor = 0;

                if (!int.TryParse(celda.Value.ToString(), out valor))
                    celda.Value = valor;
            }

        }

        /// <summary>
        /// Se selecciona otra fecha para el cierre.
        /// </summary>
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (_seleccion_fecha_cierre) return;

            this.obtenerTipoCambio();
        }

        /// <summary>
        /// Se muestra el dropdownlist para seleccionar una fecha para el cierre.
        /// </summary>
        private void dtpFecha_DropDown(object sender, EventArgs e)
        {
            _seleccion_fecha_cierre = true;
        }

        /// <summary>
        /// Se oculta el dropdownlist al seleccionar una fecha para el cierre.
        /// </summary>
        private void dtpFecha_CloseUp(object sender, EventArgs e)
        {
            _seleccion_fecha_cierre = false;

            this.obtenerTipoCambio();
        }

        /// <summary>
        /// Se selecciona otra fecha para la impresión del cierre.
        /// </summary>
        private void dtpFechaImpresion_ValueChanged(object sender, EventArgs e)
        {
            if (_seleccion_fecha_impresion) return;

            this.obtenerTipoCambioImpresion();
        }

        /// <summary>
        /// Se muestra el dropdownlist para seleccionar una fecha para la impresión del cierre.
        /// </summary>
        private void dtpFechaImpresion_DropDown(object sender, EventArgs e)
        {
            _seleccion_fecha_impresion = true;
        }

        /// <summary>
        /// Se oculta el dropdownlist al seleccionar una fecha para la impresión del cierre.
        /// </summary>
        private void dtpFechaImpresion_CloseUp(object sender, EventArgs e)
        {
            _seleccion_fecha_impresion = false;

            this.obtenerTipoCambioImpresion();
        }

        /// <summary>
        /// Se cambia un valor en el cierre.
        /// </summary>
        private void dgvCierre_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCierre.RowCount > 0)
            {
                DataGridViewCell celda = dgvCierre[e.ColumnIndex, e.RowIndex];

                if (_tipo_cambio == null) return;

                _ingreso_clientes_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 7].Value);
                _reporte_cajero_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 8].Value);
                _saldo_dia_anterior_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 11].Value);
                _otros_ingresos_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 12].Value);
                _otros_egresos_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 13].Value);
                _cheques_locales_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 14].Value);
                _cheques_exterior_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 15].Value);
                _cheques_bac_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 16].Value);
                _salidas_niquel_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 17].Value);
                _niquel_pendiente_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 18].Value);
                _niquel_pendiente_dia_anterior_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 19].Value);
                _faltante_cliente_niquel_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 20].Value);
                _sobrante_cliente_niquel_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 21].Value);
                _entregas_boveda_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 22].Value);
                _entregas_pendientes_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 23].Value);
                _faltante_clientes_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 24].Value);
                _sobrante_clientes_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 25].Value);
                _faltante_quinientos_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 26].Value);
                _sobrante_quinientos_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 27].Value);
                _efectivo_cajero_colones = Convert.ToDecimal(dgvCierre[MontoColones.Index, 28].Value);

                _ingreso_clientes_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 7].Value);
                _reporte_cajero_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 8].Value);
                _saldo_dia_anterior_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 11].Value);
                _otros_ingresos_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 12].Value);
                _otros_egresos_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 13].Value);
                _cheques_locales_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 14].Value);
                _cheques_exterior_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 15].Value);
                _cheques_bac_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 16].Value);
                _salidas_niquel_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 17].Value);
                _niquel_pendiente_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 18].Value);
                _niquel_pendiente_dia_anterior_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 19].Value);
                _faltante_cliente_niquel_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 20].Value);
                _sobrante_cliente_niquel_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 21].Value);
                _entregas_boveda_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 22].Value);
                _entregas_pendientes_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 23].Value);
                _faltante_clientes_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 24].Value);
                _sobrante_clientes_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 25].Value);
                _faltante_quinientos_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 26].Value);
                _sobrante_quinientos_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 27].Value);
                _efectivo_cajero_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 28].Value);




                _compra_dolares = Convert.ToDecimal(dgvCierre[MontoDolares.Index, 30].Value);
                _venta_dolares = Convert.ToDecimal(dgvCierre[MontoColones.Index, 31].Value);

                decimal compra_dolares_colones = _compra_dolares * _tipo_cambio.Compra;
                decimal venta_dolares_dolares =  Math.Round(_venta_dolares / _tipo_cambio.Venta, 2);





                _ingreso_clientes_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 7].Value);
                _reporte_cajero_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 8].Value);
                _saldo_dia_anterior_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 11].Value);
                _otros_ingresos_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 12].Value);
                _otros_egresos_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 13].Value);
                _cheques_locales_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 14].Value);
                _cheques_exterior_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 15].Value);
                _cheques_bac_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 16].Value);
                _salidas_niquel_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 17].Value);
                _niquel_pendiente_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 18].Value);
                _niquel_pendiente_dia_anterior_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 19].Value);
                _faltante_cliente_niquel_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 20].Value);
                _sobrante_cliente_niquel_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 21].Value);
                _entregas_boveda_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 22].Value);
                _entregas_pendientes_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 23].Value);
                _faltante_clientes_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 24].Value);
                _sobrante_clientes_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 25].Value);
                _faltante_quinientos_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 26].Value);
                _sobrante_quinientos_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 27].Value);
                _efectivo_cajero_euros = Convert.ToDecimal(dgvCierre[clmMonedaEuros.Index, 28].Value);

                // Calculo de los montos en colones

                decimal diferencia_colones = _ingreso_clientes_colones - _reporte_cajero_colones;

                _saldo_cierre_colones = _ingreso_clientes_colones + _saldo_dia_anterior_colones + _otros_ingresos_colones -
                                        _otros_egresos_colones - _cheques_locales_colones - _cheques_exterior_colones -
                                        _cheques_bac_colones - _salidas_niquel_colones - _niquel_pendiente_colones -
                                        _entregas_boveda_colones - _entregas_pendientes_colones - compra_dolares_colones +
                                        _venta_dolares - _faltante_clientes_colones + _sobrante_clientes_colones -
                                        _faltante_quinientos_colones + _sobrante_quinientos_colones - _faltante_cliente_niquel_colones + _sobrante_cliente_niquel_colones
                                        + _niquel_pendiente_dia_anterior_colones;

                decimal faltante_sobrante_colones = _saldo_cierre_colones - _efectivo_cajero_colones;

                dgvCierre[MontoColones.Index, 9].Value = diferencia_colones;
                dgvCierre[MontoColones.Index, 30].Value = compra_dolares_colones;
                dgvCierre[MontoColones.Index, 33].Value = _saldo_cierre_colones;
                dgvCierre[MontoColones.Index, 34].Value = faltante_sobrante_colones;

                // Calculo de los montos en dolares

                decimal diferencia_dolares = _ingreso_clientes_dolares - _reporte_cajero_dolares;

                _saldo_cierre_dolares = _ingreso_clientes_dolares + _saldo_dia_anterior_dolares + _otros_ingresos_dolares -
                                        _otros_egresos_dolares - _cheques_locales_dolares - _cheques_exterior_dolares -
                                        _cheques_bac_dolares - _salidas_niquel_dolares - _niquel_pendiente_dolares -
                                        _entregas_boveda_dolares - _entregas_pendientes_dolares + _compra_dolares -
                                        venta_dolares_dolares - _faltante_clientes_dolares + _sobrante_clientes_dolares -
                                        _faltante_quinientos_dolares + _sobrante_quinientos_dolares
                                        - _faltante_cliente_niquel_dolares + _sobrante_cliente_niquel_dolares
                                        + _niquel_pendiente_dia_anterior_dolares;
                ;

                decimal faltante_sobrante_dolares =_saldo_cierre_dolares - _efectivo_cajero_dolares;

                dgvCierre[MontoDolares.Index, 9].Value = diferencia_dolares;
                dgvCierre[MontoDolares.Index, 31].Value = venta_dolares_dolares;
                dgvCierre[MontoDolares.Index, 33].Value = _saldo_cierre_dolares;
                dgvCierre[MontoDolares.Index, 34].Value = faltante_sobrante_dolares;





                // Calculo de los montos en euros

                decimal diferencia_euros = _ingreso_clientes_euros - _reporte_cajero_euros;

                _saldo_cierre_euros = _ingreso_clientes_euros + _saldo_dia_anterior_euros + _otros_ingresos_euros -
                                        _otros_egresos_euros - _cheques_locales_euros - _cheques_exterior_euros -
                                        _cheques_bac_euros - _salidas_niquel_euros - _niquel_pendiente_euros -
                                        _entregas_boveda_euros - _entregas_pendientes_euros - _faltante_clientes_euros + _sobrante_clientes_euros -
                                        -_faltante_cliente_niquel_euros + _sobrante_cliente_niquel_euros
                                        + _niquel_pendiente_dia_anterior_euros;
                ;

                decimal faltante_sobrante_euros = _saldo_cierre_euros - _efectivo_cajero_euros;

                dgvCierre[clmMonedaEuros.Index, 9].Value = diferencia_euros;
                //dgvCierre[clmMonedaEuros.Index, 31].Value = venta_dolares_euros;
                dgvCierre[clmMonedaEuros.Index, 33].Value = _saldo_cierre_euros;
                dgvCierre[clmMonedaEuros.Index, 34].Value = faltante_sobrante_euros;
            }

        }

        /// <summary>
        /// Se selecciona otro cajero.
        /// </summary>
        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarDatos();
        }

        /// <summary>
        /// Se selecciona otro digitador.
        /// </summary>
        private void cboDigitador_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarDatos();
        }

        /// <summary>
        /// Se selecciona la opción de aplicar un filtro por cajero a la lista de montos por cliente.
        /// </summary>
        private void rbMontosCajero_CheckedChanged(object sender, EventArgs e)
        {
            cboCajeroMontos.Enabled = true;
            cboDigitadorMontos.Enabled = false;
        }

        /// <summary>
        /// Se selecciona la opción de aplicar un filtro por digitador a la lista de montos por cliente.
        /// </summary>
        private void rbMontosDigitador_CheckedChanged(object sender, EventArgs e)
        {
            cboCajeroMontos.Enabled = false;
            cboDigitadorMontos.Enabled = true;
        }

        /// <summary>
        /// Se selecciona la opción de aplicar un filtro a la lista de montos por cliente.
        /// </summary>
        private void chkFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltro.Enabled = chkFiltrar.Checked;
        }

        /// <summary>
        /// Se selecciona la opción registrar un cierre para un cajero.
        /// </summary>
        private void rbCajero_CheckedChanged(object sender, EventArgs e)
        {
            this.validarTipoCierre();
        }

        /// <summary>
        /// Se selecciona la opción registrar un cierre para una transportadora.
        /// </summary>
        private void rbTransportadora_CheckedChanged(object sender, EventArgs e)
        {
            this.validarTipoCierre();
        }

        /// <summary>
        /// Se selecciona la opción imprimir un cierre para un digitador.
        /// </summary>
        private void rbImpresionDigitador_CheckedChanged(object sender, EventArgs e)
        {
                        
            cboImpresionCajero.Items.Add("");
            cboImpresionCajero.SelectedItem = "";
            cboImpresionCajero.Items.Clear();
            cboImpresionCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);
            cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
            cboCoordinador.Enabled = true;
            cboImpresionDigitador.Enabled = true;
            cboImpresionCajero.Enabled = false;
            
        }

        /// <summary>
        /// Se selecciona la opción imprimir un cierre para un cajero.
        /// </summary>
        
        private void rbImpresionCajero_CheckedChanged(object sender, EventArgs e)
        {
            
            cboCoordinador.Items.Add("");
            cboCoordinador.SelectedItem = "";
            cboCoordinador.Items.Clear();
            cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
            cboImpresionDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
            cboCoordinador.Enabled = false;
            cboImpresionDigitador.Enabled = true;
            cboImpresionCajero.Enabled = true;
            
        }

        /// <summary>
        /// Activa el filtro para realizar la impresion.
        /// </summary>
        private void ckbFiltroImpresion_CheckedChanged(object sender, EventArgs e)
        {
            cboImpresionDigitador.Enabled = true;
            cboCoordinador.Enabled = true;
            rbImpresionCajero.Enabled = true;
            rbImpresionDigitador.Enabled = true;
            rbImpresionCoordinador.Enabled = true;
            btnExportarExcel.Enabled = true;

        }


        /// <summary>
        /// Se selecciona la opción imprimir un cierre para un coordinador.
        /// </summary>
        private void rbImpresionCoordinador_CheckedChanged(object sender, EventArgs e)
        {
            cboImpresionDigitador.Items.Add("");
            cboImpresionDigitador.SelectedItem = "";
            cboImpresionDigitador.Items.Clear();
            cboImpresionDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
            cboImpresionCajero.Items.Add("");
            cboImpresionCajero.SelectedItem = "";
            cboImpresionCajero.Items.Clear();
            cboImpresionCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);
            cboCoordinador.Enabled = true;
            cboImpresionDigitador.Enabled = false;
            cboImpresionCajero.Enabled = false;
        }

        #endregion Eventos




        #region Métodos Privados
        
        
        
        /// <summary>
        /// Exportar los datos de los cierres.
        /// </summary>
        /// 
        private void exportar()
        { 
            
            documento = new DocumentoExcel();
        
            try
            {
                DateTime fecha = dtpFechaImpresion.Value;
                    
                Colaborador cajero = (Colaborador)cboImpresionCajero.SelectedItem;
                Colaborador digitador = (Colaborador)cboImpresionDigitador.SelectedItem;
                Colaborador coordinador = (Colaborador)cboCoordinador.SelectedItem;
                BindingList<CierreCEF> cierres = new BindingList<CierreCEF>();
                BindingList<CierreCEF> cierresdigitadores = new BindingList<CierreCEF>();
                
                documento.seleccionarHoja(1);
                
                //Lista los cierres
               cierres = _coordinacion.listarCierresCajerosCoordinador(fecha, coordinador);
               cierresdigitadores = _coordinacion.listarCierresDigitadoresCoordinador(fecha,coordinador);

               int hojacierre = 1;
               
                //Crea el nuevo cierre
               CierreCEF cierrecajero = new CierreCEF(fecha:fecha,cajero:cajero,digitador:digitador,coordinador: coordinador);
               
               
                if (rbImpresionCajero.Checked)
               {
                     seleccionarcajero = true;
                   
                    _coordinacion.obtenerDatosCierre(ref cierrecajero);
                   
                    _cierre = cierrecajero;

                    this.llenarhoja(documento, _cierre, hojacierre);
                   
               }
               else
              {
                  if (rbImpresionDigitador.Checked)
                  {
                      seleccionarcajero = false;

                      _coordinacion.obtenerDatosCierreDigitador(ref cierrecajero);
                      
                      _cierre = cierrecajero;

                      this.llenarhoja(documento, _cierre, hojacierre);

                  }
                  else
                  {
                      if (rbImpresionCoordinador.Checked)
                      {
                           
                          int hojas = hojacierre;
                          _coordinacion.obtenerDatosCierreDigitador(ref cierrecajero);


                          //Crea las hojas del documento
                          foreach (CierreCEF numerocierredigitador in cierresdigitadores)
                            {
                                if (hojas >= 4)
                                {
                                    documento.agregarHoja("Hoja" + hojas.ToString());
                                }
                                hojas++;
                               
                            }
 
                          foreach (CierreCEF numerocierre in cierres)
                          {
                              
                              if (hojas >= 4)
                              {
                                  documento.agregarHoja("Hoja" + hojas.ToString());

                              }
                              hojas++;

                          }

                          //Crea cada nuevo cierre
                          foreach (CierreCEF cierredigitador in cierresdigitadores)
                          {
                              seleccionarcajero = false;
                              documento.seleccionarHoja(hojacierre);
                              digitador = cierredigitador.Digitador;
                              
                              CierreCEF nuevo = new CierreCEF(fecha: fecha, digitador: digitador, coordinador: coordinador);

                              _coordinacion.obtenerDatosCierreDigitador(ref nuevo);

                              _cierre = nuevo;

                              this.llenarhoja(documento, _cierre, hojacierre);


                              hojacierre++;
                          }

                         
                          foreach (CierreCEF cierre in cierres)
                          {
                              
                              documento.seleccionarHoja(hojacierre);

                              seleccionarcajero = true;

                              CierreCEF nuevodigitador = cierre;

                              _coordinacion.obtenerDatoDigitador(ref nuevodigitador);
                              _cierre.Digitador = nuevodigitador.Digitador;

                              digitador = _cierre.Digitador;
                              cajero = nuevodigitador.Cajero;

                              CierreCEF nuevo = new CierreCEF(fecha: fecha, cajero: cajero, digitador: digitador, coordinador: coordinador);

                              _coordinacion.obtenerDatosCierre(ref nuevo);
                              _cierre = nuevo;

                                this.llenarhoja(documento, _cierre, hojacierre);


                              hojacierre++;
                          } 
                      }
                  }
                          
                   hojacierre = 1;

                  }
             }
                
            catch (Exception ex)
            {
                documento.cerrar();
                throw ex;                
            }

            if (documento != null)
            {
                documento.mostrar();
             }
            
            documento.cerrar();
        }



        private void llenarhoja(DocumentoExcel documento, CierreCEF _cierre, int hojacierre)
        {
            documento.seleccionarHoja(hojacierre);
                  
            // Escribir los encabezados
            int posicion = 3;

            documento.seleccionarCelda("B7");
            documento.actualizarValorCelda("Manifiestos");

            documento.seleccionarCelda("B8");
            documento.actualizarValorCelda("Tulas");

            documento.seleccionarCelda("B9");
            documento.actualizarValorCelda("Depositos");

            documento.seleccionarCelda("B10");
            documento.actualizarValorCelda("Cheques");

            documento.seleccionarCelda("B11");
            documento.actualizarValorCelda("Sobres");

            documento.seleccionarCelda("B12");
            documento.actualizarValorCelda("Disconformidades");

            documento.seleccionarCelda("B13");
            documento.actualizarValorCelda("Ingreso Clientes");

            documento.seleccionarCelda("B14");
            documento.actualizarValorCelda("Reporte Cajero");

            documento.seleccionarCelda("B15");
            documento.actualizarValorCelda("Diferencia");

            documento.seleccionarCelda("B16");
            documento.actualizarValorCelda("Saldo Día Anterior");

            documento.seleccionarCelda("B17");
            documento.actualizarValorCelda("Otros Ingresos");

            documento.seleccionarCelda("B18");
            documento.actualizarValorCelda("Otros Egresos");

            documento.seleccionarCelda("B19");
            documento.actualizarValorCelda("Cheques Locales");

            documento.seleccionarCelda("B20");
            documento.actualizarValorCelda("Cheques del Exterior");

            documento.seleccionarCelda("B21");
            documento.actualizarValorCelda("Cheques del BAC");


            //Escribe los sobrantes y faltantes de clientes en niquel
            
            int niquel = 0;

            if (_cierre.Faltante_cliente_niquel_colones > 0 || _cierre.Sobrante_cliente_niquel_colones > 0)
            {
                
                documento.seleccionarCelda(22, posicion);
                documento.actualizarValorCelda(_cierre.Faltante_cliente_niquel_colones.ToString("N2"));

                documento.seleccionarCelda(23, posicion);
                documento.actualizarValorCelda(_cierre.Sobrante_cliente_niquel_colones.ToString("N2"));

                documento.seleccionarCelda(22, posicion + 1);
                documento.actualizarValorCelda(_cierre.Faltante_cliente_niquel_dolares.ToString("N2"));

                documento.seleccionarCelda(23, posicion + 1);
                documento.actualizarValorCelda(_cierre.Sobrante_cliente_niquel_dolares.ToString("N2"));

                documento.seleccionarCelda("B22");
                documento.actualizarValorCelda("Faltante Cliente Niquel:");

                documento.seleccionarCelda("B23");
                documento.actualizarValorCelda("Sobrante Cliente Niquel");
                niquel = 2;
            }
            
            documento.seleccionarCelda("B"+ (22+ niquel).ToString());
            documento.actualizarValorCelda("Salidas de Niquel");

            documento.seleccionarCelda("B" + (23+ niquel).ToString());
            documento.actualizarValorCelda("Niquel Pendiente");

            documento.seleccionarCelda("B" + (24 + niquel).ToString());
            documento.actualizarValorCelda("Entregas de Boveda");

            documento.seleccionarCelda("B" + (25 + niquel).ToString());
            documento.actualizarValorCelda("Entregas Pendiente");

            documento.seleccionarCelda("B" + (26 + niquel).ToString());
            documento.actualizarValorCelda("Faltante Clientes");
            
            documento.seleccionarCelda("B" + (27 + niquel).ToString());
            documento.actualizarValorCelda("Sobrante Clientes");

            documento.seleccionarCelda("B" + (28+ niquel).ToString());
            documento.actualizarValorCelda("Faltante Menores 500");

            documento.seleccionarCelda("B" + (29+ niquel).ToString());
            documento.actualizarValorCelda("Sobrante Menores 500");

            documento.seleccionarCelda("B" + (30 + niquel).ToString());
            documento.actualizarValorCelda("Efectivo Cajero");

            documento.seleccionarCelda("B" + (31+ niquel).ToString());
            documento.actualizarValorCelda("Compra de Dolares");

            documento.seleccionarCelda("B" + (32+ niquel).ToString());
            documento.actualizarValorCelda("Venta de Dolares");

            documento.seleccionarCelda("B" + (33+ niquel).ToString());
            documento.actualizarValorCelda("Saldo Cierre");

            documento.seleccionarCelda("B" + (34+ niquel).ToString());
            documento.actualizarValorCelda("Faltante Sobrante");
                    
            this.escribirCierre(documento,_cierre,posicion,hojacierre);

            // Dar formato a la hoja

            documento.seleccionarCelda("B4");
            documento.actualizarValorCelda("Digitador:");
            documento.seleccionarSegundaCelda("B6");
            documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
            documento.cambiarTamanoColumna(22);
            
            documento.seleccionarCelda(4, posicion);
            documento.actualizarValorCelda(_cierre.Digitador.ToString());
            documento.formatoCelda(negrita: true);
            documento.seleccionarSegundaCelda(4, posicion + 1);
            documento.ajustarCeldas(AlineacionHorizontal.Centro);
            documento.formatoTabla(false);

            documento.seleccionarCelda(5, posicion);
            documento.formatoCelda(negrita: true);
            documento.seleccionarSegundaCelda(5, posicion + 1);
            documento.ajustarCeldas(AlineacionHorizontal.Centro);
            documento.formatoTabla(false);
                        
            if (seleccionarcajero == true)
            {
                documento.seleccionarCelda("B5");
                documento.actualizarValorCelda("Cajero:");
                documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                documento.cambiarTamanoColumna(23);
                documento.formatoTabla(false);

                documento.seleccionarCelda(5, posicion);
                documento.actualizarValorCelda(_cierre.Cajero.ToString());
                documento.formatoCelda(negrita: true);
                documento.seleccionarSegundaCelda(5, posicion + 1);
                documento.ajustarCeldas(AlineacionHorizontal.Centro);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B" + (35 + niquel).ToString());
                documento.actualizarValorCelda("Observaciones:");
                documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                documento.seleccionarSegundaCelda("B" + (36+ niquel).ToString());
                documento.ajustarCeldas(AlineacionHorizontal.Centro);
                documento.formatoTabla(false);

                documento.seleccionarCelda("C"+ (35+ niquel).ToString());
                documento.actualizarValorCelda(_cierre.Observaciones);
                documento.formatoCelda(negrita: true);
                documento.cambiarTamanoFila(30);
                documento.seleccionarSegundaCelda("D" + (36 + niquel).ToString());
                documento.ajustarCeldas(AlineacionHorizontal.Centro);
                documento.formatoTabla(false);
                           
            }

           
            documento.seleccionarHoja(hojacierre);
            
            documento.seleccionarCelda(6, posicion);
            documento.seleccionarSegundaCelda(34 + niquel, posicion + 1);
            documento.formatoTabla(false);

            documento.seleccionarCelda(6, posicion);
            documento.actualizarValorCelda("Colones");
            documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
            documento.ajustarCeldas(AlineacionHorizontal.Centro);
            documento.cambiarTamanoColumna(22);
            
            documento.seleccionarCelda(6, posicion + 1);
            documento.actualizarValorCelda("Dolares");
            documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
            documento.ajustarCeldas(AlineacionHorizontal.Centro);
            documento.cambiarTamanoColumna(22);

            // Escribir los valores en el excel

            documento.seleccionarCelda(7 , posicion);
            documento.actualizarValorCelda(_cierre.Manifiestos.ToString("N0"));

            documento.seleccionarCelda(8, posicion);
            documento.actualizarValorCelda(_cierre.Tulas.ToString("N0"));

            documento.seleccionarCelda(9, posicion);
            documento.actualizarValorCelda(_cierre.Depositos.ToString("N0"));

            documento.seleccionarCelda(10, posicion);
            documento.actualizarValorCelda(_cierre.Cheques.ToString("N0"));

            documento.seleccionarCelda(11, posicion);
            documento.actualizarValorCelda(_cierre.Sobres.ToString("N0"));

            documento.seleccionarCelda(12, posicion);
            documento.actualizarValorCelda(_cierre.Disconformidades.ToString("N0"));

            // Colones

            documento.seleccionarCelda(13, posicion);
            documento.actualizarValorCelda(_cierre.Ingreso_clientes_colones.ToString("N2"));

            documento.seleccionarCelda(14, posicion);
            documento.actualizarValorCelda(_cierre.Reporte_cajero_colones.ToString("N2"));

            documento.seleccionarCelda(16, posicion);
            documento.actualizarValorCelda(_cierre.Saldo_dia_anterior_colones.ToString("N2"));

            documento.seleccionarCelda(17, posicion);
            documento.actualizarValorCelda(_cierre.Otros_ingresos_colones.ToString("N2"));

            documento.seleccionarCelda(18, posicion);
            documento.actualizarValorCelda(_cierre.Otros_egresos_colones.ToString("N2"));

            documento.seleccionarCelda(19, posicion);
            documento.actualizarValorCelda(_cierre.Cheques_locales_colones.ToString("N2"));

            documento.seleccionarCelda(20, posicion);
            documento.actualizarValorCelda(_cierre.Cheques_exterior_colones.ToString("N2"));

            documento.seleccionarCelda(21, posicion);
            documento.actualizarValorCelda(_cierre.Cheques_bac_colones.ToString("N2"));


            documento.seleccionarCelda(22 + niquel , posicion);
            documento.actualizarValorCelda(_cierre.Salidas_niquel_colones.ToString("N2"));

            documento.seleccionarCelda(23 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Niquel_pendiente_colones.ToString("N2"));

            documento.seleccionarCelda(24 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Entregas_boveda_colones.ToString("N2"));

            documento.seleccionarCelda(25 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Entregas_pendientes_colones.ToString("N2"));

            documento.seleccionarCelda(26 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Faltante_clientes_colones.ToString("N2"));

            documento.seleccionarCelda(27 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Sobrante_clientes_colones.ToString("N2"));

            documento.seleccionarCelda(28 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Faltante_quinientos_colones.ToString("N2"));

            documento.seleccionarCelda(29 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Sobrante_quinientos_colones.ToString("N2"));

            documento.seleccionarCelda(30 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Efectivo_cajero_colones.ToString("N2"));

            documento.seleccionarCelda(32 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Venta_dolares.ToString("N2"));

            documento.seleccionarCelda(35 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Observaciones);

            

            // Dolares

            documento.seleccionarCelda(13, posicion + 1);
            documento.actualizarValorCelda(_cierre.Ingreso_clientes_dolares.ToString("N2"));

            documento.seleccionarCelda(14, posicion + 1);
            documento.actualizarValorCelda(_cierre.Reporte_cajero_dolares.ToString("N2"));

            documento.seleccionarCelda(16, posicion + 1);
            documento.actualizarValorCelda(_cierre.Saldo_dia_anterior_dolares.ToString("N2"));

            documento.seleccionarCelda(17, posicion + 1);
            documento.actualizarValorCelda(_cierre.Otros_ingresos_dolares.ToString("N2"));

            documento.seleccionarCelda(18, posicion + 1);
            documento.actualizarValorCelda(_cierre.Otros_egresos_dolares.ToString("N2"));

            documento.seleccionarCelda(19, posicion + 1);
            documento.actualizarValorCelda(_cierre.Cheques_locales_dolares.ToString("N2"));

            documento.seleccionarCelda(20, posicion + 1);
            documento.actualizarValorCelda(_cierre.Cheques_exterior_dolares.ToString("N2"));

            documento.seleccionarCelda(21, posicion + 1);
            documento.actualizarValorCelda(_cierre.Cheques_bac_dolares.ToString("N2"));

            documento.seleccionarCelda(22 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Salidas_niquel_dolares.ToString("N2"));

            documento.seleccionarCelda(23 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Niquel_pendiente_dolares.ToString("N2"));

            documento.seleccionarCelda(24 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Entregas_boveda_dolares.ToString("N2"));

            documento.seleccionarCelda(25 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Entregas_pendientes_dolares.ToString("N2"));

            documento.seleccionarCelda(26 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Faltante_clientes_dolares.ToString("N2"));

            documento.seleccionarCelda(27 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Sobrante_clientes_dolares.ToString("N2"));

            documento.seleccionarCelda(28 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Faltante_quinientos_dolares.ToString("N2"));

            documento.seleccionarCelda(29 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Sobrante_quinientos_dolares.ToString("N2"));

            documento.seleccionarCelda(30 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Efectivo_cajero_dolares.ToString("N2"));

            documento.seleccionarCelda(31 + niquel, posicion + 1);
            documento.actualizarValorCelda(_cierre.Compra_dolares.ToString("N2"));

            // Escribir el consolidado y dar formato a la tabla

            posicion++;

            documento.seleccionarCelda("B2");
            documento.actualizarValorCelda("Coordinador: " + _cierre.Coordinador);
            documento.seleccionarSegundaCelda("D2");
            documento.ajustarCeldas(AlineacionHorizontal.Centro);

            documento.seleccionarCelda("B3");
            documento.actualizarValorCelda("Fecha: " + _cierre.Fecha.ToShortDateString());
            documento.seleccionarSegundaCelda("D3");
            documento.ajustarCeldas(AlineacionHorizontal.Centro);

            documento.seleccionarCelda("B2");
            documento.seleccionarSegundaCelda("D3");
            documento.formatoCelda(color_fondo: Color.LightGray);
            documento.formatoTabla(false);

            documento.seleccionarCelda("B1");
            documento.cambiarTamanoColumna(20);

            documento.seleccionarCelda("B7");
            documento.seleccionarSegundaCelda("B" + (34 + niquel).ToString());
            documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
            documento.formatoTabla(false);

            documento.seleccionarCelda("B7");
            documento.seleccionarSegundaCelda(12, posicion);
            documento.formatoTabla(false);

            documento.seleccionarCelda("B13");
            documento.seleccionarSegundaCelda(15, posicion);
            documento.formatoTabla(false);

            documento.seleccionarCelda("B16");
            documento.seleccionarSegundaCelda(30 + niquel, posicion);
            documento.formatoTabla(false);

            documento.seleccionarCelda("B"+ (31 + niquel).ToString());
            documento.seleccionarSegundaCelda(32+ niquel , posicion);
            documento.formatoTabla(false);


        }

                
                /// <summary>
        /// Escribir un cierre en el reporte de cierres.
        /// </summary>
        private void escribirCierre(DocumentoExcel documento,CierreCEF _cierre, int posicion,int hojacierre)
        {
            
            decimal compra_dolares_colones = _cierre.Compra_dolares * _tipo_cambio_impresion.Compra;
            decimal venta_dolares_dolares = Math.Round(_cierre.Venta_dolares / _tipo_cambio_impresion.Venta, 2);

            // Calculo de los montos en colones

            decimal diferencia_colones = _cierre.Ingreso_clientes_colones - _cierre.Reporte_cajero_colones;

            decimal saldo_cierre_colones = _cierre.Ingreso_clientes_colones + _cierre.Saldo_dia_anterior_colones + _cierre.Otros_ingresos_colones -
                                        _cierre.Otros_egresos_colones - _cierre.Cheques_locales_colones - _cierre.Cheques_exterior_colones -
                                        _cierre.Cheques_bac_colones - _cierre.Salidas_niquel_colones - _cierre.Niquel_pendiente_colones -
                                        _cierre.Entregas_boveda_colones - _cierre.Entregas_pendientes_colones - compra_dolares_colones +
                                        _cierre.Venta_dolares - _cierre.Faltante_clientes_colones + _cierre.Sobrante_clientes_colones -
                                        _cierre.Faltante_quinientos_colones + _cierre.Sobrante_quinientos_colones;
                                       
            decimal faltante_sobrante_colones = saldo_cierre_colones - _cierre.Efectivo_cajero_colones;

            // Calculo de los montos en dolares

            decimal diferencia_dolares = _cierre.Ingreso_clientes_dolares - _cierre.Reporte_cajero_dolares;

            decimal saldo_cierre_dolares = _cierre.Ingreso_clientes_dolares + _cierre.Saldo_dia_anterior_dolares + _cierre.Otros_ingresos_dolares -
                                    _cierre.Otros_egresos_dolares - _cierre.Cheques_locales_dolares - _cierre.Cheques_exterior_dolares -
                                    _cierre.Cheques_bac_dolares - _cierre.Salidas_niquel_dolares - _cierre.Niquel_pendiente_dolares -
                                    _cierre.Entregas_boveda_dolares - _cierre.Entregas_pendientes_dolares + _cierre.Compra_dolares -
                                    venta_dolares_dolares - _cierre.Faltante_clientes_dolares + _cierre.Sobrante_clientes_dolares -
                                    _cierre.Faltante_quinientos_dolares + _cierre.Sobrante_quinientos_dolares;

            decimal faltante_sobrante_dolares = saldo_cierre_dolares - _cierre.Efectivo_cajero_dolares;
            
            documento.seleccionarHoja(hojacierre);

            int niquel = 0;
            
            if (_cierre.Faltante_cliente_niquel_colones > 0 || _cierre.Sobrante_cliente_niquel_colones > 0)
            {
                niquel = 2;
            }
                

            documento.seleccionarCelda(15, posicion);
            documento.actualizarValorCelda(diferencia_colones.ToString("N2"));

            documento.seleccionarCelda(31 + niquel, posicion);
            documento.actualizarValorCelda(compra_dolares_colones.ToString("N2"));

            documento.seleccionarCelda(32 + niquel, posicion);
            documento.actualizarValorCelda(_cierre.Venta_dolares.ToString("N2"));

            documento.seleccionarCelda(33 + niquel, posicion);
            documento.actualizarValorCelda(saldo_cierre_colones.ToString("N2"));

            documento.seleccionarCelda(34 + niquel, posicion);
            documento.actualizarValorCelda(faltante_sobrante_colones.ToString("N2"));

            // Dolares

            documento.seleccionarCelda(15, posicion + 1);
            documento.actualizarValorCelda(diferencia_dolares.ToString("N2"));

            
            documento.seleccionarCelda(31, posicion + 1);
            documento.actualizarValorCelda(_cierre.Compra_dolares.ToString("N2"));

            documento.seleccionarCelda(32 + niquel, posicion + 1);
            documento.actualizarValorCelda(venta_dolares_dolares.ToString("N2"));

            documento.seleccionarCelda(33 + niquel, posicion + 1);
            documento.actualizarValorCelda(saldo_cierre_dolares.ToString("N2"));

            documento.seleccionarCelda(34 + niquel, posicion + 1);
            documento.actualizarValorCelda(faltante_sobrante_dolares.ToString("N2"));
        }


        /// <summary>
        /// Obtener los datos del cierre de los colaboradores.
        /// </summary>
        private void cargarDatos()
        
        {

            try
            {
                this.borrarDatos(dgvCierre);

                if (cboCajero.SelectedItem != null && cboDigitador.SelectedItem != null)
                {
                    Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                    Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;

                    _cierre = new CierreCEF(fecha: _fecha, cajero: cajero, digitador: digitador, coordinador: _coordinador);

                    _coordinacion.obtenerDatosCierre(ref _cierre);

                    _coordinador_valido = _cierre.Coordinador.Equals(_coordinador);
                    _nuevo = _cierre.ID == 0;

                    txtCoordinador.Text = _cierre.Coordinador.ToString();
                    cboDigitador.Text = _cierre.Digitador.ToString();

                    this.mostrarDatos();
                    this.validarOpciones();
                }
                else
                {
                    txtObservaciones.Enabled = false;
                    txtObservaciones.Text = string.Empty;

                    dgvCierre.ReadOnly = true;

                    btnGuardar.Enabled = false;
                    btnCorte.Enabled = false;
                    btnEliminar.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Obtener el tipo de cambio para la fecha seleccionada.
        /// </summary>
        private void obtenerTipoCambio()
        {

            try
            {
                DateTime fecha_actual = _coordinacion.obtenerFechaHora();

                _fecha = dtpFecha.Value;
                _tipo_cambio = _mantenimiento.obtenerTipoCambio(_fecha);

                this.borrarDatos(dgvCierre);
                this.borrarDatos(dgvConsolidado);
                this.actualizarListaCierres();

                if (_tipo_cambio == null)
                {
                    Excepcion.mostrarMensaje("ErrorTipoCambioNoRegistrado");

                    cboCajero.Enabled = false;
                    cboDigitador.Enabled = false;
                    dgvConsolidado.Enabled = false;
                    clbCajeros.Enabled = false;

                    txtCompra.Text = string.Empty;
                    txtVenta.Text = string.Empty;

                    _fecha_valida = false;

                    this.validarOpciones();
                }
                else
                {
                    cboCajero.Enabled = true;
                    cboDigitador.Enabled = true;
                    dgvConsolidado.Enabled = true;
                    clbCajeros.Enabled = true;

                    txtCompra.Text = _tipo_cambio.Compra.ToString("N2");
                    txtVenta.Text = _tipo_cambio.Venta.ToString("N2");

                    _fecha_valida = _fecha.Date == fecha_actual.Date;

                    this.cargarDatos();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Obtener el tipo de cambio de la fecha seleccionada para la impresión de cierres.
        /// </summary>
        private void obtenerTipoCambioImpresion()
        {

            try
            {
                DateTime fecha = dtpFechaImpresion.Value;

                _tipo_cambio_impresion = _mantenimiento.obtenerTipoCambio(_fecha);

                bool estado = _tipo_cambio_impresion != null;

                btnExportarExcel.Enabled = estado;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Mostrar los datos de un cierre.
        /// </summary>
        private void mostrarDatos()
        {
            txtObservaciones.Text = _cierre.Observaciones;

            dgvCierre[MontoColones.Index, 0].Value = _cierre.Manifiestos;
            dgvCierre[MontoColones.Index, 1].Value = _cierre.Tulas;
            dgvCierre[MontoColones.Index, 2].Value = _cierre.Depositos;

            dgvCierre[MontoColones.Index, 3].Value = _cierre.Cheques;
            dgvCierre[MontoColones.Index, 4].Value = _cierre.Sobres;
            dgvCierre[MontoColones.Index, 5].Value = _cierre.Disconformidades;

            dgvCierre[MontoColones.Index, 7].Value = _cierre.Ingreso_clientes_colones;
            dgvCierre[MontoColones.Index, 8].Value = _cierre.Reporte_cajero_colones;
            dgvCierre[MontoColones.Index, 11].Value = _cierre.Saldo_dia_anterior_colones;
            dgvCierre[MontoColones.Index, 12].Value = _cierre.Otros_ingresos_colones;
            dgvCierre[MontoColones.Index, 13].Value = _cierre.Otros_egresos_colones;
            dgvCierre[MontoColones.Index, 14].Value = _cierre.Cheques_locales_colones;
            dgvCierre[MontoColones.Index, 15].Value = _cierre.Cheques_exterior_colones;
            dgvCierre[MontoColones.Index, 16].Value = _cierre.Cheques_bac_colones;
            dgvCierre[MontoColones.Index, 17].Value = _cierre.Salidas_niquel_colones;
            dgvCierre[MontoColones.Index, 18].Value = _cierre.Niquel_pendiente_colones;
            dgvCierre[MontoColones.Index, 19].Value = _cierre.Niquel_pendiente_dia_anterior_colones;
            dgvCierre[MontoColones.Index, 20].Value = _cierre.Faltante_cliente_niquel_colones;
            dgvCierre[MontoColones.Index, 21].Value = _cierre.Sobrante_cliente_niquel_colones;
            dgvCierre[MontoColones.Index, 22].Value = _cierre.Entregas_boveda_colones;
            dgvCierre[MontoColones.Index, 23].Value = _cierre.Entregas_pendientes_colones;
            dgvCierre[MontoColones.Index, 24].Value = _cierre.Faltante_clientes_colones;
            dgvCierre[MontoColones.Index, 25].Value = _cierre.Sobrante_clientes_colones;
            dgvCierre[MontoColones.Index, 26].Value = _cierre.Faltante_quinientos_colones;
            dgvCierre[MontoColones.Index, 27].Value = _cierre.Sobrante_quinientos_colones;
            dgvCierre[MontoColones.Index, 28].Value = _cierre.Efectivo_cajero_colones;

            dgvCierre[MontoDolares.Index, 7].Value = _cierre.Ingreso_clientes_dolares;
            dgvCierre[MontoDolares.Index, 8].Value = _cierre.Reporte_cajero_dolares;
            dgvCierre[MontoDolares.Index, 11].Value = _cierre.Saldo_dia_anterior_dolares;
            dgvCierre[MontoDolares.Index, 12].Value = _cierre.Otros_ingresos_dolares;
            dgvCierre[MontoDolares.Index, 13].Value = _cierre.Otros_egresos_dolares;
            dgvCierre[MontoDolares.Index, 14].Value = _cierre.Cheques_locales_dolares;
            dgvCierre[MontoDolares.Index, 15].Value = _cierre.Cheques_exterior_dolares;
            dgvCierre[MontoDolares.Index, 16].Value = _cierre.Cheques_bac_dolares;
            dgvCierre[MontoDolares.Index, 17].Value = _cierre.Salidas_niquel_dolares;
            dgvCierre[MontoDolares.Index, 18].Value = _cierre.Niquel_pendiente_dolares;
            dgvCierre[MontoDolares.Index, 19].Value = _cierre.Niquel_pendiente_dia_anterior_dolares;
            dgvCierre[MontoDolares.Index, 20].Value = _cierre.Faltante_cliente_niquel_dolares;
            dgvCierre[MontoDolares.Index, 21].Value = _cierre.Sobrante_cliente_niquel_dolares;
            dgvCierre[MontoDolares.Index, 22].Value = _cierre.Entregas_boveda_dolares;
            dgvCierre[MontoDolares.Index, 23].Value = _cierre.Entregas_pendientes_dolares;
            dgvCierre[MontoDolares.Index, 24].Value = _cierre.Faltante_clientes_dolares;
            dgvCierre[MontoDolares.Index, 25].Value = _cierre.Sobrante_clientes_dolares;
            dgvCierre[MontoDolares.Index, 26].Value = _cierre.Faltante_quinientos_dolares;
            dgvCierre[MontoDolares.Index, 27].Value = _cierre.Sobrante_quinientos_dolares;
            dgvCierre[MontoDolares.Index, 28].Value = _cierre.Efectivo_cajero_dolares;
            
            dgvCierre[MontoDolares.Index, 30].Value = _cierre.Compra_dolares;
            dgvCierre[MontoColones.Index, 31].Value = _cierre.Venta_dolares;

            dgvCierre[clmMonedaEuros.Index, 7].Value = _cierre.Ingreso_clientes_euros;
            dgvCierre[clmMonedaEuros.Index, 8].Value = _cierre.Reporte_cajero_euros;
            dgvCierre[clmMonedaEuros.Index, 11].Value = _cierre.Saldo_dia_anterior_euros;
            dgvCierre[clmMonedaEuros.Index, 12].Value = _cierre.Otros_ingresos_euros;
            dgvCierre[clmMonedaEuros.Index, 13].Value = _cierre.Otros_egresos_euros;
            dgvCierre[clmMonedaEuros.Index, 14].Value = _cierre.Cheques_locales_euros;
            dgvCierre[clmMonedaEuros.Index, 15].Value = _cierre.Cheques_exterior_euros;
            dgvCierre[clmMonedaEuros.Index, 16].Value = _cierre.Cheques_bac_euros;
            dgvCierre[clmMonedaEuros.Index, 17].Value = _cierre.Salidas_niquel_euros;
            dgvCierre[clmMonedaEuros.Index, 18].Value = _cierre.Niquel_pendiente_euros;
            dgvCierre[clmMonedaEuros.Index, 19].Value = _cierre.Niquel_pendiente_dia_anterior_euros;
            dgvCierre[clmMonedaEuros.Index, 20].Value = _cierre.Faltante_cliente_niquel_euros;
            dgvCierre[clmMonedaEuros.Index, 21].Value = _cierre.Sobrante_cliente_niquel_euros;
            dgvCierre[clmMonedaEuros.Index, 22].Value = _cierre.Entregas_boveda_euros;
            dgvCierre[clmMonedaEuros.Index, 23].Value = _cierre.Entregas_pendientes_euros;
            dgvCierre[clmMonedaEuros.Index, 24].Value = _cierre.Faltante_clientes_euros;
            dgvCierre[clmMonedaEuros.Index, 25].Value = _cierre.Sobrante_clientes_euros;
            dgvCierre[clmMonedaEuros.Index, 26].Value = _cierre.Faltante_quinientos_euros;
            dgvCierre[clmMonedaEuros.Index, 27].Value = _cierre.Sobrante_quinientos_euros;
            dgvCierre[clmMonedaEuros.Index, 28].Value = _cierre.Efectivo_cajero_euros;


            //dgvConsolidado[clmMonedaEuros.Index, 9].Value = diferencia_euros;
            ////dgvConsolidado[clmMonedaEuros.Index, 31].Value = venta_dolares_euros;
            //dgvConsolidado[clmMonedaEuros.Index, 33].Value = saldo_cierre_euros;
            //dgvConsolidado[clmMonedaEuros.Index, 34].Value = faltante_sobrante_euros;

        }

        /// <summary>
        /// Habilitar o desabilitar la edición de los datos.
        /// </summary>
        private void validarOpciones()
        {
            bool acceso = (_fecha_valida && _coordinador_valido) ||
                           (_tipo_cambio != null && _supervisor);

            btnGuardar.Enabled = acceso;
            btnCorte.Enabled = acceso;
            btnEliminar.Enabled = acceso && !_nuevo;

            if (acceso)
            {
                dgvCierre.ReadOnly = false;
                txtObservaciones.Enabled = true;
                this.protegerCeldas(dgvCierre);
            }
            else
            {
                dgvCierre.ReadOnly = true;
                txtObservaciones.Enabled = false;
            }

        }

        /// <summary>
        /// Borrar los datos del DataGrid.
        /// </summary>
        private void borrarDatos(DataGridView tabla)
        {
            tabla[MontoColones.Index, 0].Value = 0;
            tabla[MontoColones.Index, 1].Value = 0;
            tabla[MontoColones.Index, 2].Value = 0;
            tabla[MontoColones.Index, 3].Value = 0;
            tabla[MontoColones.Index, 4].Value = 0;
            tabla[MontoColones.Index, 5].Value = 0;

            tabla[MontoColones.Index, 8].Value = 0;
            tabla[MontoColones.Index, 9].Value = 0;
            tabla[MontoDolares.Index, 11].Value = 0;
            tabla[MontoColones.Index, 12].Value = 0;
            tabla[MontoColones.Index, 13].Value = 0;
            tabla[MontoColones.Index, 14].Value = 0;
            tabla[MontoColones.Index, 15].Value = 0;
            tabla[MontoColones.Index, 16].Value = 0;
            tabla[MontoColones.Index, 17].Value = 0;
            tabla[MontoColones.Index, 18].Value = 0;
            tabla[MontoColones.Index, 19].Value = 0;
            tabla[MontoColones.Index, 20].Value = 0;
            tabla[MontoColones.Index, 21].Value = 0;
            tabla[MontoColones.Index, 22].Value = 0;
            tabla[MontoColones.Index, 24].Value = 0;
            tabla[MontoColones.Index, 25].Value = 0;
            tabla[MontoColones.Index, 27].Value = 0;
            tabla[MontoColones.Index, 29].Value = 0;
            tabla[MontoColones.Index, 31].Value = 0;
            tabla[MontoColones.Index, 33].Value = 0;

            tabla[MontoDolares.Index, 8].Value = 0;
            tabla[MontoDolares.Index, 11].Value = 0;
            tabla[MontoDolares.Index, 12].Value = 0;
            tabla[MontoDolares.Index, 13].Value = 0;
            tabla[MontoDolares.Index, 14].Value = 0;
            tabla[MontoDolares.Index, 15].Value = 0;
            tabla[MontoDolares.Index, 16].Value = 0;
            tabla[MontoDolares.Index, 17].Value = 0;
            tabla[MontoDolares.Index, 18].Value = 0;
            tabla[MontoDolares.Index, 19].Value = 0;
            tabla[MontoDolares.Index, 20].Value = 0;
            tabla[MontoDolares.Index, 21].Value = 0;
            tabla[MontoDolares.Index, 22].Value = 0;
            tabla[MontoDolares.Index, 25].Value = 0;
            tabla[MontoDolares.Index, 26].Value = 0;
            tabla[MontoDolares.Index, 27].Value = 0;
            tabla[MontoDolares.Index, 30].Value = 0;
            tabla[MontoDolares.Index, 32].Value = 0;
            tabla[MontoDolares.Index, 33].Value = 0;



            tabla[clmMonedaEuros.Index, 8].Value = 0;
            tabla[clmMonedaEuros.Index, 11].Value = 0;
            tabla[clmMonedaEuros.Index, 12].Value = 0;
            tabla[clmMonedaEuros.Index, 13].Value = 0;
            tabla[clmMonedaEuros.Index, 14].Value = 0;
            tabla[clmMonedaEuros.Index, 15].Value = 0;
            tabla[clmMonedaEuros.Index, 16].Value = 0;
            tabla[clmMonedaEuros.Index, 17].Value = 0;
            tabla[clmMonedaEuros.Index, 18].Value = 0;
            tabla[clmMonedaEuros.Index, 19].Value = 0;
            tabla[clmMonedaEuros.Index, 20].Value = 0;
            tabla[clmMonedaEuros.Index, 21].Value = 0;
            tabla[clmMonedaEuros.Index, 22].Value = 0;
            tabla[clmMonedaEuros.Index, 25].Value = 0;
            tabla[clmMonedaEuros.Index, 26].Value = 0;
            tabla[clmMonedaEuros.Index, 27].Value = 0;
            tabla[clmMonedaEuros.Index, 30].Value = 0;
            tabla[clmMonedaEuros.Index, 32].Value = 0;
            tabla[clmMonedaEuros.Index, 33].Value = 0;
        }

        /// <summary>
        /// Actualizar el consolidado.
        /// </summary>
        private void actualizarConsolidado()
        {
            decimal manifiestos = 0;
            decimal tulas = 0;
            decimal depositos = 0;

            decimal cheques = 0;
            decimal sobres = 0;
            decimal disconformidades = 0;

            decimal ingreso_clientes_colones = 0;
            decimal reporte_cajero_colones = 0;
            decimal saldo_dia_anterior_colones = 0;
            decimal otros_ingresos_colones = 0;
            decimal otros_egresos_colones = 0;
            decimal cheques_locales_colones = 0;
            decimal cheques_exterior_colones = 0;
            decimal cheques_bac_colones = 0;
            decimal salidas_niquel_colones = 0;
            decimal niquel_pendiente_colones = 0;
            decimal niquel_pendiente_dia_anterior_colones = 0;
            decimal faltante_cliente_niquel_colones = 0;
            decimal sobrante_cliente_niquel_colones = 0;
            decimal entregas_boveda_colones = 0;
            decimal entregas_pendientes_colones = 0;
            decimal faltante_clientes_colones = 0;
            decimal sobrante_clientes_colones = 0;
            decimal faltante_quinientos_colones = 0;
            decimal sobrante_quinientos_colones = 0;
            decimal efectivo_cajero_colones = 0;

            decimal ingreso_clientes_dolares = 0;
            decimal reporte_cajero_dolares = 0;
            decimal saldo_dia_anterior_dolares = 0;
            decimal otros_ingresos_dolares = 0;
            decimal otros_egresos_dolares = 0;
            decimal cheques_locales_dolares = 0;
            decimal cheques_exterior_dolares = 0;
            decimal cheques_bac_dolares = 0;
            decimal salidas_niquel_dolares = 0;
            decimal niquel_pendiente_dolares = 0;
            decimal niquel_pendiente_dia_anterior_dolares = 0;
            decimal faltante_cliente_niquel_dolares = 0;
            decimal sobrante_cliente_niquel_dolares = 0;
            decimal entregas_boveda_dolares = 0;
            decimal entregas_pendientes_dolares = 0;
            decimal faltante_clientes_dolares = 0;
            decimal sobrante_clientes_dolares = 0;
            decimal faltante_quinientos_dolares = 0;
            decimal sobrante_quinientos_dolares = 0;
            decimal efectivo_cajero_dolares = 0;




            decimal ingreso_clientes_euros = 0;
            decimal reporte_cajero_euros = 0;
            decimal saldo_dia_anterior_euros = 0;
            decimal otros_ingresos_euros = 0;
            decimal otros_egresos_euros = 0;
            decimal cheques_locales_euros = 0;
            decimal cheques_exterior_euros = 0;
            decimal cheques_bac_euros = 0;
            decimal salidas_niquel_euros = 0;
            decimal niquel_pendiente_euros = 0;
            decimal niquel_pendiente_dia_anterior_euros = 0;
            decimal faltante_cliente_niquel_euros = 0;
            decimal sobrante_cliente_niquel_euros = 0;
            decimal entregas_boveda_euros = 0;
            decimal entregas_pendientes_euros = 0;
            decimal faltante_clientes_euros = 0;
            decimal sobrante_clientes_euros = 0;
            decimal faltante_quinientos_euros = 0;
            decimal sobrante_quinientos_euros = 0;
            decimal efectivo_cajero_euros = 0;

            decimal compra_dolares = 0;
            decimal venta_dolares = 0;

            decimal compra_dolares_colones = 0;
            decimal venta_dolares_dolares = 0;

            decimal diferencia_colones = 0;
            decimal saldo_cierre_colones = 0;
            decimal faltante_sobrante_colones = 0;

            decimal diferencia_dolares = 0;
            decimal saldo_cierre_dolares = 0;
            decimal faltante_sobrante_dolares = 0;

            decimal diferencia_euros = 0;
            decimal saldo_cierre_euros = 0;
            decimal faltante_sobrante_euros = 0;

            foreach (CierreCEF cierre in clbCajeros.CheckedItems)
            {
                CierreCEF copia = new CierreCEF(fecha: cierre.Fecha, cajero: cierre.Cajero, digitador: cierre.Digitador);

                _coordinacion.obtenerDatosCierre(ref copia);

                manifiestos += copia.Manifiestos;
                tulas += copia.Tulas;
                depositos += copia.Depositos;

                cheques += copia.Cheques;
                sobres += copia.Sobres;
                disconformidades += copia.Disconformidades;

                ingreso_clientes_colones += copia.Ingreso_clientes_colones;
                reporte_cajero_colones += copia.Reporte_cajero_colones;
                saldo_dia_anterior_colones += copia.Saldo_dia_anterior_colones;
                otros_ingresos_colones += copia.Otros_ingresos_colones;
                otros_egresos_colones += copia.Otros_egresos_colones;
                cheques_locales_colones += copia.Cheques_locales_colones;
                cheques_exterior_colones += copia.Cheques_exterior_colones;
                cheques_bac_colones += copia.Cheques_bac_colones;
                salidas_niquel_colones += copia.Salidas_niquel_colones;
                niquel_pendiente_colones += copia.Niquel_pendiente_colones;
                niquel_pendiente_dia_anterior_colones += copia.Niquel_pendiente_dia_anterior_colones;
                faltante_cliente_niquel_colones += copia.Faltante_cliente_niquel_colones;
                sobrante_cliente_niquel_colones += copia.Sobrante_cliente_niquel_colones;
                entregas_boveda_colones += copia.Entregas_boveda_colones;
                entregas_pendientes_colones += copia.Entregas_pendientes_colones;
                faltante_clientes_colones += copia.Faltante_clientes_colones;
                sobrante_clientes_colones += copia.Sobrante_clientes_colones;
                faltante_quinientos_colones += copia.Faltante_quinientos_colones;
                sobrante_quinientos_colones += copia.Sobrante_quinientos_colones;
                efectivo_cajero_colones += copia.Efectivo_cajero_colones;

                ingreso_clientes_dolares += copia.Ingreso_clientes_dolares;
                reporte_cajero_dolares += copia.Reporte_cajero_dolares;
                saldo_dia_anterior_dolares += copia.Saldo_dia_anterior_dolares;
                otros_ingresos_dolares += copia.Otros_ingresos_dolares;
                otros_egresos_dolares += copia.Otros_egresos_dolares;
                cheques_locales_dolares += copia.Cheques_locales_dolares;
                cheques_exterior_dolares += copia.Cheques_exterior_dolares;
                cheques_bac_dolares += copia.Cheques_bac_dolares;
                salidas_niquel_dolares += copia.Salidas_niquel_dolares;
                niquel_pendiente_dolares += copia.Niquel_pendiente_dolares;
                niquel_pendiente_dia_anterior_dolares += copia.Niquel_pendiente_dia_anterior_dolares;
                faltante_cliente_niquel_dolares += copia.Faltante_cliente_niquel_dolares;
                sobrante_cliente_niquel_dolares += copia.Sobrante_cliente_niquel_dolares;
                entregas_boveda_dolares += copia.Entregas_boveda_dolares;
                entregas_pendientes_dolares += copia.Entregas_pendientes_dolares;
                faltante_clientes_dolares += copia.Faltante_clientes_dolares;
                sobrante_clientes_dolares += copia.Sobrante_clientes_dolares;
                faltante_quinientos_dolares += copia.Faltante_quinientos_dolares;
                sobrante_quinientos_dolares += copia.Sobrante_quinientos_dolares;
                efectivo_cajero_dolares += copia.Efectivo_cajero_dolares;


                ingreso_clientes_euros += copia.Ingreso_clientes_euros;
                reporte_cajero_euros += copia.Reporte_cajero_euros;
                saldo_dia_anterior_euros += copia.Saldo_dia_anterior_euros;
                otros_ingresos_euros += copia.Otros_ingresos_euros;
                otros_egresos_euros += copia.Otros_egresos_euros;
                cheques_locales_euros += copia.Cheques_locales_euros;
                cheques_exterior_euros += copia.Cheques_exterior_euros;
                cheques_bac_euros += copia.Cheques_bac_euros;
                salidas_niquel_euros += copia.Salidas_niquel_euros;
                niquel_pendiente_euros += copia.Niquel_pendiente_euros;
                niquel_pendiente_dia_anterior_euros += copia.Niquel_pendiente_dia_anterior_euros;
                faltante_cliente_niquel_euros += copia.Faltante_cliente_niquel_euros;
                sobrante_cliente_niquel_euros += copia.Sobrante_cliente_niquel_euros;
                entregas_boveda_euros += copia.Entregas_boveda_euros;
                entregas_pendientes_euros += copia.Entregas_pendientes_euros;
                faltante_clientes_euros += copia.Faltante_clientes_euros;
                sobrante_clientes_euros += copia.Sobrante_clientes_euros;
                faltante_quinientos_euros += copia.Faltante_quinientos_euros;
                sobrante_quinientos_euros += copia.Sobrante_quinientos_euros;
                efectivo_cajero_euros += copia.Efectivo_cajero_euros;



                compra_dolares += copia.Compra_dolares;
                venta_dolares += copia.Venta_dolares;
            }

            compra_dolares_colones = compra_dolares * _tipo_cambio.Compra;
            venta_dolares_dolares = Math.Round(venta_dolares / _tipo_cambio.Venta, 2);

            // Calculo de los montos en colones

            diferencia_colones = ingreso_clientes_colones - reporte_cajero_colones;

            saldo_cierre_colones = ingreso_clientes_colones + saldo_dia_anterior_colones + otros_ingresos_colones -
                                        otros_egresos_colones - cheques_locales_colones - cheques_exterior_colones -
                                        cheques_bac_colones - salidas_niquel_colones - niquel_pendiente_colones -
                                        entregas_boveda_colones - entregas_pendientes_colones - compra_dolares_colones +
                                        venta_dolares - faltante_clientes_colones + sobrante_clientes_colones -
                                        faltante_quinientos_colones + sobrante_quinientos_colones - faltante_cliente_niquel_colones + sobrante_cliente_niquel_colones
                                        + niquel_pendiente_dia_anterior_colones;

            faltante_sobrante_colones = saldo_cierre_colones - efectivo_cajero_colones;

            // Calculo de los montos en dolares

            diferencia_dolares = ingreso_clientes_dolares - reporte_cajero_dolares;

            saldo_cierre_dolares = ingreso_clientes_dolares + saldo_dia_anterior_dolares + otros_ingresos_dolares -
                                        otros_egresos_dolares - cheques_locales_dolares - cheques_exterior_dolares -
                                        cheques_bac_dolares - salidas_niquel_dolares - niquel_pendiente_dolares -
                                        entregas_boveda_dolares - entregas_pendientes_dolares + compra_dolares -
                                        venta_dolares_dolares - faltante_clientes_dolares + sobrante_clientes_dolares -
                                        faltante_quinientos_dolares + sobrante_quinientos_dolares - faltante_cliente_niquel_dolares + sobrante_cliente_niquel_dolares
                                        +niquel_pendiente_dolares;


            

            faltante_sobrante_dolares = saldo_cierre_dolares - efectivo_cajero_dolares;




            // Calculo de los montos en euros

            diferencia_euros = ingreso_clientes_euros - reporte_cajero_euros;

            saldo_cierre_euros = ingreso_clientes_euros + saldo_dia_anterior_euros + otros_ingresos_euros -
                                        otros_egresos_euros - cheques_locales_euros - cheques_exterior_euros -
                                        cheques_bac_euros - salidas_niquel_euros - niquel_pendiente_euros -
                                        entregas_boveda_euros - entregas_pendientes_euros  - faltante_clientes_euros + sobrante_clientes_euros -
                                        faltante_quinientos_euros + sobrante_quinientos_euros - faltante_cliente_niquel_euros + sobrante_cliente_niquel_euros
                                        + niquel_pendiente_euros;




            faltante_sobrante_euros = saldo_cierre_euros - efectivo_cajero_euros;

            // Mostrar los  valores

            dgvConsolidado[MontoColones.Index, 0].Value = manifiestos;
            dgvConsolidado[MontoColones.Index, 1].Value = tulas;
            dgvConsolidado[MontoColones.Index, 2].Value = depositos;

            dgvConsolidado[MontoColones.Index, 3].Value = cheques;
            dgvConsolidado[MontoColones.Index, 4].Value = sobres;
            dgvConsolidado[MontoColones.Index, 5].Value = disconformidades;

            dgvConsolidado[MontoColones.Index, 7].Value = ingreso_clientes_colones;
            dgvConsolidado[MontoColones.Index, 8].Value = reporte_cajero_colones;
            dgvConsolidado[MontoColones.Index, 11].Value = saldo_dia_anterior_colones;
            dgvConsolidado[MontoColones.Index, 12].Value = otros_ingresos_colones;
            dgvConsolidado[MontoColones.Index, 13].Value = otros_egresos_colones;
            dgvConsolidado[MontoColones.Index, 14].Value = cheques_locales_colones;
            dgvConsolidado[MontoColones.Index, 15].Value = cheques_exterior_colones;
            dgvConsolidado[MontoColones.Index, 16].Value = cheques_bac_colones;
            dgvConsolidado[MontoColones.Index, 17].Value = salidas_niquel_colones;
            dgvConsolidado[MontoColones.Index, 18].Value = niquel_pendiente_colones;
            dgvConsolidado[MontoColones.Index, 19].Value = niquel_pendiente_dia_anterior_colones;
            dgvConsolidado[MontoColones.Index, 20].Value = faltante_cliente_niquel_colones;
            dgvConsolidado[MontoColones.Index, 21].Value = sobrante_cliente_niquel_colones;
            dgvConsolidado[MontoColones.Index, 22].Value = entregas_boveda_colones;
            dgvConsolidado[MontoColones.Index, 23].Value = entregas_pendientes_colones;
            dgvConsolidado[MontoColones.Index, 24].Value = faltante_clientes_colones;
            dgvConsolidado[MontoColones.Index, 25].Value = sobrante_clientes_colones;
            dgvConsolidado[MontoColones.Index, 26].Value = faltante_quinientos_colones;
            dgvConsolidado[MontoColones.Index, 27].Value = sobrante_quinientos_colones;
            dgvConsolidado[MontoColones.Index, 28].Value = efectivo_cajero_colones;

            dgvConsolidado[MontoDolares.Index, 7].Value = ingreso_clientes_dolares;
            dgvConsolidado[MontoDolares.Index, 8].Value = reporte_cajero_dolares;
            dgvConsolidado[MontoDolares.Index, 11].Value = saldo_dia_anterior_dolares;
            dgvConsolidado[MontoDolares.Index, 12].Value = otros_ingresos_dolares;
            dgvConsolidado[MontoDolares.Index, 13].Value = otros_egresos_dolares;
            dgvConsolidado[MontoDolares.Index, 14].Value = cheques_locales_dolares;
            dgvConsolidado[MontoDolares.Index, 15].Value = cheques_exterior_dolares;
            dgvConsolidado[MontoDolares.Index, 16].Value = cheques_bac_dolares;
            dgvConsolidado[MontoDolares.Index, 17].Value = salidas_niquel_dolares;
            dgvConsolidado[MontoDolares.Index, 18].Value = niquel_pendiente_dolares;
            dgvConsolidado[MontoDolares.Index, 19].Value = niquel_pendiente_dia_anterior_dolares;
            dgvConsolidado[MontoDolares.Index, 20].Value = faltante_cliente_niquel_dolares;
            dgvConsolidado[MontoDolares.Index, 21].Value = sobrante_cliente_niquel_dolares;
            dgvConsolidado[MontoDolares.Index, 22].Value = entregas_boveda_dolares;
            dgvConsolidado[MontoDolares.Index, 23].Value = entregas_pendientes_dolares;
            dgvConsolidado[MontoDolares.Index, 24].Value = faltante_clientes_dolares;
            dgvConsolidado[MontoDolares.Index, 25].Value = sobrante_clientes_dolares;
            dgvConsolidado[MontoDolares.Index, 26].Value = faltante_quinientos_dolares;
            dgvConsolidado[MontoDolares.Index, 27].Value = sobrante_quinientos_dolares;
            dgvConsolidado[MontoDolares.Index, 28].Value = efectivo_cajero_dolares;



            dgvConsolidado[clmMonedaEuros.Index, 7].Value = ingreso_clientes_euros;
            dgvConsolidado[clmMonedaEuros.Index, 8].Value = reporte_cajero_euros;
            dgvConsolidado[clmMonedaEuros.Index, 11].Value = saldo_dia_anterior_euros;
            dgvConsolidado[clmMonedaEuros.Index, 12].Value = otros_ingresos_euros;
            dgvConsolidado[clmMonedaEuros.Index, 13].Value = otros_egresos_euros;
            dgvConsolidado[clmMonedaEuros.Index, 14].Value = cheques_locales_euros;
            dgvConsolidado[clmMonedaEuros.Index, 15].Value = cheques_exterior_euros;
            dgvConsolidado[clmMonedaEuros.Index, 16].Value = cheques_bac_euros;
            dgvConsolidado[clmMonedaEuros.Index, 17].Value = salidas_niquel_euros;
            dgvConsolidado[clmMonedaEuros.Index, 18].Value = niquel_pendiente_euros;
            dgvConsolidado[clmMonedaEuros.Index, 19].Value = niquel_pendiente_dia_anterior_euros;
            dgvConsolidado[clmMonedaEuros.Index, 20].Value = faltante_cliente_niquel_euros;
            dgvConsolidado[clmMonedaEuros.Index, 21].Value = sobrante_cliente_niquel_euros;
            dgvConsolidado[clmMonedaEuros.Index, 22].Value = entregas_boveda_euros;
            dgvConsolidado[clmMonedaEuros.Index, 23].Value = entregas_pendientes_euros;
            dgvConsolidado[clmMonedaEuros.Index, 24].Value = faltante_clientes_euros;
            dgvConsolidado[clmMonedaEuros.Index, 25].Value = sobrante_clientes_euros;
            dgvConsolidado[clmMonedaEuros.Index, 26].Value = faltante_quinientos_euros;
            dgvConsolidado[clmMonedaEuros.Index, 27].Value = sobrante_quinientos_euros;
            dgvConsolidado[clmMonedaEuros.Index, 28].Value = efectivo_cajero_euros;



            dgvConsolidado[MontoDolares.Index, 30].Value = compra_dolares;
            dgvConsolidado[MontoColones.Index, 31].Value = venta_dolares;

            dgvConsolidado[MontoColones.Index, 9].Value = diferencia_colones;
            dgvConsolidado[MontoColones.Index, 30].Value = compra_dolares_colones;
            dgvConsolidado[MontoColones.Index, 33].Value = saldo_cierre_colones;
            dgvConsolidado[MontoColones.Index, 34].Value = faltante_sobrante_colones;

            dgvConsolidado[MontoDolares.Index, 9].Value = diferencia_dolares;
            dgvConsolidado[MontoDolares.Index, 31].Value = venta_dolares_dolares;
            dgvConsolidado[MontoDolares.Index, 33].Value = saldo_cierre_dolares;
            dgvConsolidado[MontoDolares.Index, 34].Value = faltante_sobrante_dolares;



            dgvConsolidado[clmMonedaEuros.Index, 9].Value = diferencia_euros;
            //dgvConsolidado[clmMonedaEuros.Index, 31].Value = venta_dolares_euros;
            dgvConsolidado[clmMonedaEuros.Index, 33].Value = saldo_cierre_euros;
            dgvConsolidado[clmMonedaEuros.Index, 34].Value = faltante_sobrante_euros;
        }

        /// <summary>
        /// Actualizar la lista de saldos.
        /// </summary>
        private void actualizarListaManifiestos()
        {
        
            try
            {
                DateTime fecha = dtpFechaManifiestos.Value;

                dgvManifiestos.DataSource = _coordinacion.listarManifiestosCoordinador(_coordinador, fecha);
                dgvManifiestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvManifiestos.AutoResizeColumns();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Actualizar la lista de saldos.
        /// </summary>
        private void actualizarListaSaldos() {
        
            try
            {
                DateTime fecha = dtpFechaSaldos.Value;

                dgvSaldos.DataSource = _coordinacion.listarSaldosCierre(fecha);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Actualizar la lista de cierres para el consolidado.
        /// </summary>
        private void actualizarListaCierres()
        {
            try
            {
                DateTime fecha = dtpFecha.Value;
                BindingList<CierreCEF> cierres = _coordinacion.listarCierres(fecha);

                clbCajeros.Items.Clear();

                foreach (CierreCEF cierre in cierres)
                    clbCajeros.Items.Add(cierre);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Validar las opciones dependiendo de los tipos de cierres.
        /// </summary>
        private void validarTipoCierre()
        {

            if (rbCajero.Checked)
            {
                cboCajero.Enabled = true;
                chkCierreNiquel.Enabled = true;
                cboTransportadora.Enabled = false;
            }
            else
            {
                cboCajero.Enabled = false;
                chkCierreNiquel.Enabled = false;
                cboTransportadora.Enabled = true;

                chkCierreNiquel.Checked = false;
            }

        }
      

        #endregion Métodos Privados
        
        private void frmRegistroCierreCEF_Load(object sender, EventArgs e)
        {

        }

        
        

    }

}
