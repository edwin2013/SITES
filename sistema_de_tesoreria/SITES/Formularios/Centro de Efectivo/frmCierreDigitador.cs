//
//  @ Project : 
//  @ File Name : frmCierreDigitador.cs
//  @ Date : 20/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmCierreDigitador : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _digitador = null;

        private bool _seleccion_fecha_cierre = false;

        #endregion Atributos

        #region Constructor

        public frmCierreDigitador(Colaborador digitador)
        {
            InitializeComponent();

            _digitador = digitador;

            txtDigitador.Text = _digitador.ToString();

            // Cargar la lista de Coordinadores

            try
            {
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);
                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Crear las filas

            dgvCierre.Rows.Add("Manifiestos", 0, string.Empty);
            dgvCierre.Rows.Add("Tulas", 0, string.Empty);
            dgvCierre.Rows.Add("Depositos", 0, string.Empty);
            dgvCierre.Rows.Add("Cheques", 0, string.Empty);
            dgvCierre.Rows.Add("Sobres", 0, string.Empty);
            dgvCierre.Rows.Add("Disconformidades", 0, string.Empty);
            dgvCierre.Rows.Add(string.Empty, string.Empty, string.Empty);
            dgvCierre.Rows.Add("Ingreso Clientes", 0, 0);
            dgvCierre.Rows.Add("Reporte Cajero", 0, 0);
            dgvCierre.Rows.Add("Diferencia", 0, 0);
            dgvCierre.Rows.Add(string.Empty, string.Empty, string.Empty);
            dgvCierre.Rows.Add("Saldo Día Anterior", 0, 0);
            dgvCierre.Rows.Add("Otros Ingresos", 0, 0);
            dgvCierre.Rows.Add("Otros Egresos", 0, 0);
            dgvCierre.Rows.Add("Cheques Locales", 0, 0);
            dgvCierre.Rows.Add("Cheques del Exterior", 0, 0);
            dgvCierre.Rows.Add("Cheques del BAC", 0, 0);
            dgvCierre.Rows.Add("Salidas de Niquel", 0, 0);
            dgvCierre.Rows.Add("Niquel Pendiente", 0, 0);
            dgvCierre.Rows.Add("Entregas de Boveda", 0, 0);
            dgvCierre.Rows.Add("Entregas Pendiente", 0, 0);
            dgvCierre.Rows.Add("Faltante Clientes", 0, 0);
            dgvCierre.Rows.Add("Sobrante Clientes", 0, 0);
            dgvCierre.Rows.Add("Faltante Menores 500", 0, 0);
            dgvCierre.Rows.Add("Sobrante Menores 500", 0, 0);
            dgvCierre.Rows.Add("Efectivo Cajero", 0, 0);
            dgvCierre.Rows.Add(string.Empty, string.Empty, string.Empty);
            dgvCierre.Rows.Add("Compra de Dolares", 0, 0);
            dgvCierre.Rows.Add("Venta de Dolares", 0, 0);
            dgvCierre.Rows.Add(string.Empty, string.Empty, string.Empty);
            dgvCierre.Rows.Add("Saldo Cierre", 0, 0);
            dgvCierre.Rows.Add("Faltante Sobrante", 0, 0);

            // Dar fomato a las filas

            this.formatoCeldaSeparador(dgvCierre, 6, 10, 26, 29);

            this.formatoCeldaSoloLecturaColumna(dgvCierre, MontoColones.Index, 27);
            this.formatoCeldaSoloLecturaColumna(dgvCierre, MontoDolares.Index, 3, 4, 5);
            this.formatoCeldaSoloLecturaColumna(dgvCierre, MontoDolares.Index, 28);

            this.formatoCeldaSoloLectura(dgvCierre, 0, 1, 2);
            this.formatoCeldaSoloLectura(dgvCierre, 7, 9, 21, 22, 30, 31);

            this.formatoCeldaFormato(dgvCierre, MontoColones.Index, "N0", 0, 1, 2, 3, 4, 5);

            // Establecer el separador de decimales

            CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo nueva = (CultureInfo)anterior.Clone();

            nueva.NumberFormat.NumberDecimalSeparator = ".";
            nueva.NumberFormat.NumberGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

            CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;

            // Mostrar el cierre

            this.actualizarCierre();
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

            foreach (int fila in filas)
                tabla[columna, fila].Style.Format = "N0";

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
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otro coordinador.
        /// </summary>
        private void cboCoordinador_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.actualizarCierre();
        }

        /// <summary>
        /// Se selecciona otro cajero
        /// </summary>
        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.actualizarCierre();
        }

        /// <summary>
        /// Se marca la opción de visualizar el cierre por cajero.
        /// </summary>
        private void chkCajero_CheckedChanged(object sender, EventArgs e)
        {
            cboCajero.Enabled = chkCajero.Checked;
            this.actualizarCierre();
        }

        /// <summary>
        /// Se selecciona otra fecha para el cierre.
        /// </summary>
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (_seleccion_fecha_cierre) return;

            this.actualizarCierre();
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

            this.actualizarCierre();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar los datos del cierre.
        /// </summary>
        private void actualizarCierre()
        {

            try
            {
                DateTime fecha = dtpFecha.Value;
                TipoCambio tipo_cambio = _mantenimiento.obtenerTipoCambio(fecha);
                CierreCEF cierre = new CierreCEF();

                if (tipo_cambio != null && cboCoordinador.SelectedItem != null &&
                    (!chkCajero.Checked || cboCajero.SelectedItem != null))
                {
                    Colaborador coordinador = (Colaborador)cboCoordinador.SelectedItem;
                    Colaborador cajero = chkCajero.Checked ? (Colaborador)cboCajero.SelectedItem : null;

                    cierre = new CierreCEF(fecha: fecha, cajero: cajero, digitador: _digitador, coordinador: coordinador);

                    if (chkCajero.Checked)
                        _coordinacion.obtenerDatosCierre(ref cierre);
                    else
                        _coordinacion.obtenerDatosCierreDigitador(ref cierre);

                    // Mostrar los manifiestos y los montos por clientes

                    dgvManifiestos.DataSource = _coordinacion.listarManifiestosDigitador(_digitador, fecha);
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesDigitadorCierre(_digitador, fecha);

                    dgvCierre[MontoColones.Index, 0].Value = cierre.Manifiestos;
                    dgvCierre[MontoColones.Index, 1].Value = cierre.Tulas;
                    dgvCierre[MontoColones.Index, 2].Value = cierre.Depositos;

                    dgvCierre[MontoColones.Index, 3].Value = cierre.Cheques;
                    dgvCierre[MontoColones.Index, 4].Value = cierre.Sobres;
                    dgvCierre[MontoColones.Index, 5].Value = cierre.Disconformidades;

                    dgvCierre[MontoColones.Index, 7].Value = cierre.Ingreso_clientes_colones;
                    dgvCierre[MontoColones.Index, 8].Value = cierre.Reporte_cajero_colones;
                    dgvCierre[MontoColones.Index, 11].Value = cierre.Saldo_dia_anterior_colones;
                    dgvCierre[MontoColones.Index, 12].Value = cierre.Otros_ingresos_colones;
                    dgvCierre[MontoColones.Index, 13].Value = cierre.Otros_egresos_colones;
                    dgvCierre[MontoColones.Index, 14].Value = cierre.Cheques_locales_colones;
                    dgvCierre[MontoColones.Index, 15].Value = cierre.Cheques_exterior_colones;
                    dgvCierre[MontoColones.Index, 16].Value = cierre.Cheques_bac_colones;
                    dgvCierre[MontoColones.Index, 17].Value = cierre.Salidas_niquel_colones;
                    dgvCierre[MontoColones.Index, 18].Value = cierre.Niquel_pendiente_colones;
                    dgvCierre[MontoColones.Index, 19].Value = cierre.Entregas_boveda_colones;
                    dgvCierre[MontoColones.Index, 20].Value = cierre.Entregas_pendientes_colones;
                    dgvCierre[MontoColones.Index, 21].Value = cierre.Faltante_clientes_colones;
                    dgvCierre[MontoColones.Index, 22].Value = cierre.Sobrante_clientes_colones;
                    dgvCierre[MontoColones.Index, 23].Value = cierre.Faltante_quinientos_colones;
                    dgvCierre[MontoColones.Index, 24].Value = cierre.Sobrante_quinientos_colones;
                    dgvCierre[MontoColones.Index, 25].Value = cierre.Efectivo_cajero_colones;

                    dgvCierre[MontoDolares.Index, 7].Value = cierre.Ingreso_clientes_dolares;
                    dgvCierre[MontoDolares.Index, 8].Value = cierre.Reporte_cajero_dolares;
                    dgvCierre[MontoDolares.Index, 11].Value = cierre.Saldo_dia_anterior_dolares;
                    dgvCierre[MontoDolares.Index, 12].Value = cierre.Otros_ingresos_dolares;
                    dgvCierre[MontoDolares.Index, 13].Value = cierre.Otros_egresos_dolares;
                    dgvCierre[MontoDolares.Index, 14].Value = cierre.Cheques_locales_dolares;
                    dgvCierre[MontoDolares.Index, 15].Value = cierre.Cheques_exterior_dolares;
                    dgvCierre[MontoDolares.Index, 16].Value = cierre.Cheques_bac_dolares;
                    dgvCierre[MontoDolares.Index, 17].Value = cierre.Salidas_niquel_dolares;
                    dgvCierre[MontoDolares.Index, 18].Value = cierre.Niquel_pendiente_dolares;
                    dgvCierre[MontoDolares.Index, 19].Value = cierre.Entregas_boveda_dolares;
                    dgvCierre[MontoDolares.Index, 20].Value = cierre.Entregas_pendientes_dolares;
                    dgvCierre[MontoDolares.Index, 21].Value = cierre.Faltante_clientes_dolares;
                    dgvCierre[MontoDolares.Index, 22].Value = cierre.Sobrante_clientes_dolares;
                    dgvCierre[MontoDolares.Index, 23].Value = cierre.Faltante_quinientos_dolares;
                    dgvCierre[MontoDolares.Index, 24].Value = cierre.Sobrante_quinientos_dolares;
                    dgvCierre[MontoDolares.Index, 25].Value = cierre.Efectivo_cajero_dolares;






                    dgvCierre[clmMontoEuros.Index, 7].Value = cierre.Ingreso_clientes_euros;
                    dgvCierre[clmMontoEuros.Index, 8].Value = cierre.Reporte_cajero_euros;
                    dgvCierre[clmMontoEuros.Index, 11].Value = cierre.Saldo_dia_anterior_euros;
                    dgvCierre[clmMontoEuros.Index, 12].Value = cierre.Otros_ingresos_euros;
                    dgvCierre[clmMontoEuros.Index, 13].Value = cierre.Otros_egresos_euros;
                    dgvCierre[clmMontoEuros.Index, 14].Value = cierre.Cheques_locales_euros;
                    dgvCierre[clmMontoEuros.Index, 15].Value = cierre.Cheques_exterior_euros;
                    dgvCierre[clmMontoEuros.Index, 16].Value = cierre.Cheques_bac_euros;
                    dgvCierre[clmMontoEuros.Index, 17].Value = cierre.Salidas_niquel_euros;
                    dgvCierre[clmMontoEuros.Index, 18].Value = cierre.Niquel_pendiente_euros;
                    dgvCierre[clmMontoEuros.Index, 19].Value = cierre.Entregas_boveda_euros;
                    dgvCierre[clmMontoEuros.Index, 20].Value = cierre.Entregas_pendientes_euros;
                    dgvCierre[clmMontoEuros.Index, 21].Value = cierre.Faltante_clientes_euros;
                    dgvCierre[clmMontoEuros.Index, 22].Value = cierre.Sobrante_clientes_euros;
                    dgvCierre[clmMontoEuros.Index, 23].Value = cierre.Faltante_quinientos_euros;
                    dgvCierre[clmMontoEuros.Index, 24].Value = cierre.Sobrante_quinientos_euros;
                    dgvCierre[clmMontoEuros.Index, 25].Value = cierre.Efectivo_cajero_euros;




                    dgvCierre[MontoDolares.Index, 27].Value = cierre.Compra_dolares;
                    dgvCierre[MontoColones.Index, 28].Value = cierre.Venta_dolares;


                    dgvCierre[clmMontoEuros.Index, 27].Value = cierre.Compra_euros;
                    dgvCierre[clmMontoEuros.Index, 28].Value = cierre.Venta_euros;

                    decimal compra_dolares_colones = cierre.Compra_dolares * tipo_cambio.CompraEuros;
                    decimal venta_dolares_dolares = Math.Round(cierre.Venta_dolares / tipo_cambio.VentaEuros, 2);

                    // Calculo de los montos en colones

                    decimal diferencia_colones = cierre.Ingreso_clientes_colones - cierre.Reporte_cajero_colones;

                    decimal saldo_cierre_colones = cierre.Ingreso_clientes_colones + cierre.Saldo_dia_anterior_colones + cierre.Otros_ingresos_colones -
                                            cierre.Otros_egresos_colones - cierre.Cheques_locales_colones - cierre.Cheques_exterior_colones -
                                            cierre.Cheques_bac_colones - cierre.Salidas_niquel_colones - cierre.Niquel_pendiente_colones -
                                            cierre.Entregas_boveda_colones - cierre.Entregas_pendientes_colones - compra_dolares_colones +
                                            cierre.Venta_dolares - cierre.Faltante_clientes_colones + cierre.Sobrante_clientes_colones -
                                            cierre.Faltante_quinientos_colones + cierre.Sobrante_quinientos_colones;

                    decimal faltante_sobrante_colones = saldo_cierre_colones - cierre.Efectivo_cajero_colones;

                    dgvCierre[MontoColones.Index, 9].Value = diferencia_colones;
                    dgvCierre[MontoColones.Index, 27].Value = compra_dolares_colones;
                    dgvCierre[MontoColones.Index, 30].Value = saldo_cierre_colones;
                    dgvCierre[MontoColones.Index, 31].Value = faltante_sobrante_colones;

                    // Calculo de los montos en dolares

                    decimal diferencia_dolares = cierre.Ingreso_clientes_dolares - cierre.Reporte_cajero_dolares;

                    decimal saldo_cierre_dolares = cierre.Ingreso_clientes_dolares + cierre.Saldo_dia_anterior_dolares + cierre.Otros_ingresos_dolares -
                                            cierre.Otros_egresos_dolares - cierre.Cheques_locales_dolares - cierre.Cheques_exterior_dolares -
                                            cierre.Cheques_bac_dolares - cierre.Salidas_niquel_dolares - cierre.Niquel_pendiente_dolares -
                                            cierre.Entregas_boveda_dolares - cierre.Entregas_pendientes_dolares + cierre.Compra_dolares -
                                            venta_dolares_dolares - cierre.Faltante_clientes_dolares + cierre.Sobrante_clientes_dolares -
                                            cierre.Faltante_quinientos_dolares + cierre.Sobrante_quinientos_dolares;

                    decimal faltante_sobrante_dolares = saldo_cierre_dolares - cierre.Efectivo_cajero_dolares;

                    dgvCierre[MontoDolares.Index, 9].Value = diferencia_dolares;
                    dgvCierre[MontoDolares.Index, 28].Value = venta_dolares_dolares;
                    dgvCierre[MontoDolares.Index, 30].Value = saldo_cierre_dolares;
                    dgvCierre[MontoDolares.Index, 31].Value = faltante_sobrante_dolares;





                    // Calculo de los montos en euros

                    decimal diferencia_euros = cierre.Ingreso_clientes_euros - cierre.Reporte_cajero_euros;

                    decimal saldo_cierre_euros = cierre.Ingreso_clientes_euros + cierre.Saldo_dia_anterior_euros + cierre.Otros_ingresos_euros -
                                            cierre.Otros_egresos_euros - cierre.Cheques_locales_euros - cierre.Cheques_exterior_euros -
                                            cierre.Cheques_bac_euros - cierre.Salidas_niquel_euros - cierre.Niquel_pendiente_euros -
                                            cierre.Entregas_boveda_euros - cierre.Entregas_pendientes_euros + cierre.Compra_euros -
                                            cierre.Venta_euros - cierre.Faltante_clientes_euros + cierre.Sobrante_clientes_euros -
                                            cierre.Faltante_quinientos_euros + cierre.Sobrante_quinientos_euros;

                    decimal faltante_sobrante_euros = saldo_cierre_euros - cierre.Efectivo_cajero_euros;

                    dgvCierre[clmMontoEuros.Index, 9].Value = diferencia_euros;
                    //dgvCierre[clmMontoEuros.Index, 28].Value = venta_euros_euros;
                    dgvCierre[clmMontoEuros.Index, 30].Value = saldo_cierre_euros;
                    dgvCierre[clmMontoEuros.Index, 31].Value = faltante_sobrante_euros;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

    }

}
