//
//  @ Project : 
//  @ File Name : frmReporteCierreCoordinador.cs
//  @ Date : 16/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmReporteCierreCoordinador : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private TipoCambio _tipo_cambio;

        private DateTime _fecha;
        private bool _fecha_valida = false;
        private bool _coordinador_valido = false;

        #endregion Atributos

        #region Constructor

        public frmReporteCierreCoordinador()
        {
            InitializeComponent();

            try
            {
                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de exportar a Excel.
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

            try
            {
                this.exportar();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
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
        /// Se selecciona otra fecha para el cierre.
        /// </summary>
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            this.obtenerTipoCambio();
        }

        /// <summary>
        /// Se selecciona otro coordinador.
        /// </summary>
        private void cboCoordinador_SelectedIndexChanged(object sender, EventArgs e)
        {
            _coordinador_valido = cboCoordinador.SelectedItem != null;

            this.validarOpciones();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Obtener el tipo de cambio para la fecha seleccionada.
        /// </summary>
        private void obtenerTipoCambio()
        {

            try
            {
                _fecha = dtpFecha.Value;
                _tipo_cambio = _mantenimiento.obtenerTipoCambio(_fecha);

                if (_tipo_cambio == null)
                {
                    Excepcion.mostrarMensaje("ErrorTipoCambioNoRegistrado");

                    _fecha_valida = false;
                }
                else
                {
                    _fecha_valida = true;
                }

                this.validarOpciones();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Validar las opciones.
        /// </summary>
        private void validarOpciones()
        {
            bool estado = _coordinador_valido && _fecha_valida;

            btnExportarExcel.Enabled = estado;
        }

        /// <summary>
        /// Exportar los datos.
        /// </summary>
        private void exportar()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel();
                Colaborador coordinador = (Colaborador)cboCoordinador.SelectedItem;

                documento.seleccionarHoja(1);

                BindingList<CierreCEF> cierres = rbImpresionCajero.Checked ?
                    cierres = _coordinacion.listarCierresCajerosCoordinador(_fecha, coordinador) :
                    cierres = _coordinacion.listarCierresDigitadoresCoordinador(_fecha, coordinador);

                if (cierres.Count == 0) return;

                CierreCEF consolidado = new CierreCEF();

                // Escribir los encabezados

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

                documento.seleccionarCelda("B22");
                documento.actualizarValorCelda("Salidas de Niquel");

                documento.seleccionarCelda("B23");
                documento.actualizarValorCelda("Niquel Pendiente");

                documento.seleccionarCelda("B24");
                documento.actualizarValorCelda("Entregas de Boveda");

                documento.seleccionarCelda("B25");
                documento.actualizarValorCelda("Entregas Pendiente");

                documento.seleccionarCelda("B26");
                documento.actualizarValorCelda("Faltante Clientes");

                documento.seleccionarCelda("B27");
                documento.actualizarValorCelda("Sobrante Clientes");

                documento.seleccionarCelda("B28");
                documento.actualizarValorCelda("Faltante Menores 500");

                documento.seleccionarCelda("B29");
                documento.actualizarValorCelda("Sobrante Menores 500");

                documento.seleccionarCelda("B30");
                documento.actualizarValorCelda("Efectivo Cajero");

                documento.seleccionarCelda("B31");
                documento.actualizarValorCelda("Compra de Dolares");

                documento.seleccionarCelda("B32");
                documento.actualizarValorCelda("Venta de Dolares");

                documento.seleccionarCelda("B33");
                documento.actualizarValorCelda("Saldo Cierre");

                documento.seleccionarCelda("B34");
                documento.actualizarValorCelda("Faltante Sobrante");

                int posicion = 3;

                foreach (CierreCEF cierre in cierres)
                {
                    CierreCEF copia = cierre;

                    if (rbImpresionCajero.Checked)
                    {
                        _coordinacion.obtenerDatosCierreCajero(ref copia);
                        this.escribirCierre(cierre, documento, posicion, cierre.Cajero.ToString());
                    }
                    else
                    {
                        _coordinacion.obtenerDatosCierreDigitador(ref copia);
                        this.escribirCierre(cierre, documento, posicion, cierre.Digitador.ToString());
                    }

                    posicion += 2;

                    consolidado.Manifiestos += cierre.Manifiestos;
                    consolidado.Tulas += cierre.Tulas;
                    consolidado.Depositos += cierre.Depositos;

                    consolidado.Cheques += cierre.Cheques;
                    consolidado.Sobres += cierre.Sobres;
                    consolidado.Disconformidades += cierre.Cheques;

                    consolidado.Ingreso_clientes_colones += cierre.Ingreso_clientes_colones;
                    consolidado.Reporte_cajero_colones += cierre.Reporte_cajero_colones;
                    consolidado.Saldo_dia_anterior_colones += cierre.Saldo_dia_anterior_colones;
                    consolidado.Otros_ingresos_colones += cierre.Otros_ingresos_colones;
                    consolidado.Otros_egresos_colones += cierre.Otros_egresos_colones;
                    consolidado.Cheques_locales_colones += cierre.Cheques_locales_colones;
                    consolidado.Cheques_exterior_colones += cierre.Cheques_exterior_colones;
                    consolidado.Cheques_bac_colones += cierre.Cheques_bac_colones;
                    consolidado.Salidas_niquel_colones += cierre.Salidas_niquel_colones;
                    consolidado.Niquel_pendiente_colones += cierre.Niquel_pendiente_colones;
                    consolidado.Entregas_boveda_colones += cierre.Entregas_boveda_colones;
                    consolidado.Entregas_pendientes_colones += cierre.Entregas_pendientes_colones;
                    consolidado.Faltante_clientes_colones += cierre.Faltante_clientes_colones;
                    consolidado.Sobrante_clientes_colones += cierre.Sobrante_clientes_colones;
                    consolidado.Faltante_quinientos_colones += cierre.Faltante_quinientos_colones;
                    consolidado.Sobrante_quinientos_colones += cierre.Sobrante_quinientos_colones;
                    consolidado.Efectivo_cajero_colones += cierre.Efectivo_cajero_colones;

                    consolidado.Ingreso_clientes_dolares += cierre.Ingreso_clientes_dolares;
                    consolidado.Reporte_cajero_dolares += cierre.Reporte_cajero_dolares;
                    consolidado.Saldo_dia_anterior_dolares += cierre.Saldo_dia_anterior_dolares;
                    consolidado.Otros_ingresos_dolares += cierre.Otros_ingresos_dolares;
                    consolidado.Otros_egresos_dolares += cierre.Otros_egresos_dolares;
                    consolidado.Cheques_locales_dolares += cierre.Cheques_locales_dolares;
                    consolidado.Cheques_exterior_dolares += cierre.Cheques_exterior_dolares;
                    consolidado.Cheques_bac_dolares += cierre.Cheques_bac_dolares;
                    consolidado.Salidas_niquel_dolares += cierre.Salidas_niquel_dolares;
                    consolidado.Niquel_pendiente_dolares += cierre.Niquel_pendiente_dolares;
                    consolidado.Entregas_boveda_dolares += cierre.Entregas_boveda_dolares;
                    consolidado.Entregas_pendientes_dolares += cierre.Entregas_pendientes_dolares;
                    consolidado.Faltante_clientes_dolares += cierre.Faltante_clientes_dolares;
                    consolidado.Sobrante_clientes_dolares += cierre.Sobrante_clientes_dolares;
                    consolidado.Faltante_quinientos_dolares += cierre.Faltante_quinientos_dolares;
                    consolidado.Sobrante_quinientos_dolares += cierre.Sobrante_quinientos_dolares;
                    consolidado.Efectivo_cajero_dolares += cierre.Efectivo_cajero_dolares;

                    consolidado.Compra_dolares += cierre.Compra_dolares;
                    consolidado.Venta_dolares += cierre.Venta_dolares;
                }

                // Escribir el consolidado y dar formato a la tabla

                this.escribirCierre(consolidado, documento, posicion, "Consolidado");
                
                posicion++;

                documento.seleccionarCelda("B2");
                documento.actualizarValorCelda("Coordinador: " + coordinador.ToString());
                documento.seleccionarSegundaCelda("D2");
                documento.ajustarCeldas(AlineacionHorizontal.Centro);

                documento.seleccionarCelda("B3");
                documento.actualizarValorCelda("Fecha: " + _fecha.ToShortDateString());
                documento.seleccionarSegundaCelda("D3");
                documento.ajustarCeldas(AlineacionHorizontal.Centro);

                documento.seleccionarCelda("B2");
                documento.seleccionarSegundaCelda("D3");
                documento.formatoCelda(color_fondo: Color.LightGray);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B1");
                documento.cambiarTamanoColumna(20);

                documento.seleccionarCelda("B7");
                documento.seleccionarSegundaCelda("B34");
                documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B7");
                documento.seleccionarSegundaCelda(12, posicion);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B13");
                documento.seleccionarSegundaCelda(15, posicion);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B16");
                documento.seleccionarSegundaCelda(30, posicion);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B31");
                documento.seleccionarSegundaCelda(32, posicion);
                documento.formatoTabla(false);

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Escribir un cierre en el reporte de cierres.
        /// </summary>
        private void escribirCierre(CierreCEF cierre, Documento documento, int posicion, string colaborador)
        {
            decimal compra_dolares_colones = cierre.Compra_dolares * _tipo_cambio.Compra;
            decimal venta_dolares_dolares = Math.Round(cierre.Venta_dolares / _tipo_cambio.Venta, 2);

            // Calculo de los montos en colones

            decimal diferencia_colones = cierre.Ingreso_clientes_colones - cierre.Reporte_cajero_colones;

            decimal saldo_cierre_colones = cierre.Ingreso_clientes_colones + cierre.Saldo_dia_anterior_colones + cierre.Otros_ingresos_colones -
                                        cierre.Otros_egresos_colones - cierre.Cheques_locales_colones - cierre.Cheques_exterior_colones -
                                        cierre.Cheques_bac_colones - cierre.Salidas_niquel_colones - cierre.Niquel_pendiente_colones -
                                        cierre.Entregas_boveda_colones - cierre.Entregas_pendientes_colones - compra_dolares_colones +
                                        cierre.Venta_dolares - cierre.Faltante_clientes_colones + cierre.Sobrante_clientes_colones -
                                        cierre.Faltante_quinientos_colones + cierre.Sobrante_quinientos_colones;

            decimal faltante_sobrante_colones = saldo_cierre_colones - cierre.Efectivo_cajero_colones;

            // Calculo de los montos en dolares

            decimal diferencia_dolares = cierre.Ingreso_clientes_dolares - cierre.Reporte_cajero_dolares;

            decimal saldo_cierre_dolares = cierre.Ingreso_clientes_dolares + cierre.Saldo_dia_anterior_dolares + cierre.Otros_ingresos_dolares -
                                    cierre.Otros_egresos_dolares - cierre.Cheques_locales_dolares - cierre.Cheques_exterior_dolares -
                                    cierre.Cheques_bac_dolares - cierre.Salidas_niquel_dolares - cierre.Niquel_pendiente_dolares -
                                    cierre.Entregas_boveda_dolares - cierre.Entregas_pendientes_dolares + cierre.Compra_dolares -
                                    venta_dolares_dolares - cierre.Faltante_clientes_dolares + cierre.Sobrante_clientes_dolares -
                                    cierre.Faltante_quinientos_dolares + cierre.Sobrante_quinientos_dolares;

            decimal faltante_sobrante_dolares = saldo_cierre_dolares - cierre.Efectivo_cajero_dolares;

            // Dar formato a la hoja

            documento.seleccionarCelda(5, posicion);
            documento.actualizarValorCelda(colaborador);
            documento.formatoCelda(negrita: true, color_fuente: Color.Red, color_fondo: Color.LightGray);
            documento.seleccionarSegundaCelda(5, posicion + 1);
            documento.ajustarCeldas(AlineacionHorizontal.Centro);
            documento.formatoTabla(false);

            documento.seleccionarCelda(6, posicion);
            documento.seleccionarSegundaCelda(34, posicion + 1);
            documento.formatoTabla(false);

            documento.seleccionarCelda(6, posicion);
            documento.actualizarValorCelda("Colones");
            documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
            documento.cambiarTamanoColumna(20);

            documento.seleccionarCelda(6, posicion + 1);
            documento.actualizarValorCelda("Dolares");
            documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
            documento.cambiarTamanoColumna(20);

            // Escribir los valores en el excel

            documento.seleccionarCelda(7, posicion);
            documento.actualizarValorCelda(cierre.Manifiestos.ToString("N0"));

            documento.seleccionarCelda(8, posicion);
            documento.actualizarValorCelda(cierre.Tulas.ToString("N0"));

            documento.seleccionarCelda(9, posicion);
            documento.actualizarValorCelda(cierre.Depositos.ToString("N0"));

            documento.seleccionarCelda(10, posicion);
            documento.actualizarValorCelda(cierre.Cheques.ToString("N0"));

            documento.seleccionarCelda(11, posicion);
            documento.actualizarValorCelda(cierre.Sobres.ToString("N0"));

            documento.seleccionarCelda(12, posicion);
            documento.actualizarValorCelda(cierre.Disconformidades.ToString("N0"));

            // Colones

            documento.seleccionarCelda(13, posicion);
            documento.actualizarValorCelda(cierre.Ingreso_clientes_colones.ToString("N2"));

            documento.seleccionarCelda(14, posicion);
            documento.actualizarValorCelda(cierre.Reporte_cajero_colones.ToString("N2"));

            documento.seleccionarCelda(15, posicion);
            documento.actualizarValorCelda(diferencia_colones.ToString("N2"));

            documento.seleccionarCelda(16, posicion);
            documento.actualizarValorCelda(cierre.Saldo_dia_anterior_colones.ToString("N2"));

            documento.seleccionarCelda(17, posicion);
            documento.actualizarValorCelda(cierre.Otros_ingresos_colones.ToString("N2"));

            documento.seleccionarCelda(18, posicion);
            documento.actualizarValorCelda(cierre.Otros_egresos_colones.ToString("N2"));

            documento.seleccionarCelda(19, posicion);
            documento.actualizarValorCelda(cierre.Cheques_locales_colones.ToString("N2"));

            documento.seleccionarCelda(20, posicion);
            documento.actualizarValorCelda(cierre.Cheques_exterior_colones.ToString("N2"));

            documento.seleccionarCelda(21, posicion);
            documento.actualizarValorCelda(cierre.Cheques_bac_colones.ToString("N2"));

            documento.seleccionarCelda(22, posicion);
            documento.actualizarValorCelda(cierre.Salidas_niquel_colones.ToString("N2"));

            documento.seleccionarCelda(23, posicion);
            documento.actualizarValorCelda(cierre.Niquel_pendiente_colones.ToString("N2"));

            documento.seleccionarCelda(24, posicion);
            documento.actualizarValorCelda(cierre.Entregas_boveda_colones.ToString("N2"));

            documento.seleccionarCelda(25, posicion);
            documento.actualizarValorCelda(cierre.Entregas_pendientes_colones.ToString("N2"));

            documento.seleccionarCelda(26, posicion);
            documento.actualizarValorCelda(cierre.Faltante_clientes_colones.ToString("N2"));

            documento.seleccionarCelda(27, posicion);
            documento.actualizarValorCelda(cierre.Sobrante_clientes_colones.ToString("N2"));

            documento.seleccionarCelda(28, posicion);
            documento.actualizarValorCelda(cierre.Faltante_quinientos_colones.ToString("N2"));

            documento.seleccionarCelda(29, posicion);
            documento.actualizarValorCelda(cierre.Sobrante_quinientos_colones.ToString("N2"));

            documento.seleccionarCelda(30, posicion);
            documento.actualizarValorCelda(cierre.Efectivo_cajero_colones.ToString("N2"));

            documento.seleccionarCelda(31, posicion);
            documento.actualizarValorCelda(compra_dolares_colones.ToString("N2"));

            documento.seleccionarCelda(32, posicion);
            documento.actualizarValorCelda(cierre.Venta_dolares.ToString("N2"));

            documento.seleccionarCelda(33, posicion);
            documento.actualizarValorCelda(saldo_cierre_colones.ToString("N2"));

            documento.seleccionarCelda(34, posicion);
            documento.actualizarValorCelda(faltante_sobrante_colones.ToString("N2"));

            // Dolares

            documento.seleccionarCelda(13, posicion + 1);
            documento.actualizarValorCelda(cierre.Ingreso_clientes_dolares.ToString("N2"));

            documento.seleccionarCelda(14, posicion + 1);
            documento.actualizarValorCelda(cierre.Reporte_cajero_dolares.ToString("N2"));

            documento.seleccionarCelda(15, posicion + 1);
            documento.actualizarValorCelda(diferencia_dolares.ToString("N2"));


            documento.seleccionarCelda(16, posicion + 1);
            documento.actualizarValorCelda(cierre.Saldo_dia_anterior_dolares.ToString("N2"));

            documento.seleccionarCelda(17, posicion + 1);
            documento.actualizarValorCelda(cierre.Otros_ingresos_dolares.ToString("N2"));

            documento.seleccionarCelda(18, posicion + 1);
            documento.actualizarValorCelda(cierre.Otros_egresos_dolares.ToString("N2"));

            documento.seleccionarCelda(19, posicion + 1);
            documento.actualizarValorCelda(cierre.Cheques_locales_dolares.ToString("N2"));

            documento.seleccionarCelda(20, posicion + 1);
            documento.actualizarValorCelda(cierre.Cheques_exterior_dolares.ToString("N2"));

            documento.seleccionarCelda(21, posicion + 1);
            documento.actualizarValorCelda(cierre.Cheques_bac_dolares.ToString("N2"));

            documento.seleccionarCelda(22, posicion + 1);
            documento.actualizarValorCelda(cierre.Salidas_niquel_dolares.ToString("N2"));

            documento.seleccionarCelda(23, posicion + 1);
            documento.actualizarValorCelda(cierre.Niquel_pendiente_dolares.ToString("N2"));

            documento.seleccionarCelda(24, posicion + 1);
            documento.actualizarValorCelda(cierre.Entregas_boveda_dolares.ToString("N2"));

            documento.seleccionarCelda(25, posicion + 1);
            documento.actualizarValorCelda(cierre.Entregas_pendientes_dolares.ToString("N2"));

            documento.seleccionarCelda(26, posicion + 1);
            documento.actualizarValorCelda(cierre.Faltante_clientes_dolares.ToString("N2"));

            documento.seleccionarCelda(27, posicion + 1);
            documento.actualizarValorCelda(cierre.Sobrante_clientes_dolares.ToString("N2"));

            documento.seleccionarCelda(28, posicion + 1);
            documento.actualizarValorCelda(cierre.Faltante_quinientos_dolares.ToString("N2"));

            documento.seleccionarCelda(29, posicion + 1);
            documento.actualizarValorCelda(cierre.Sobrante_quinientos_dolares.ToString("N2"));

            documento.seleccionarCelda(30, posicion + 1);
            documento.actualizarValorCelda(cierre.Efectivo_cajero_dolares.ToString("N2"));

            documento.seleccionarCelda(31, posicion + 1);
            documento.actualizarValorCelda(cierre.Compra_dolares.ToString("N2"));

            documento.seleccionarCelda(32, posicion + 1);
            documento.actualizarValorCelda(venta_dolares_dolares.ToString("N2"));

            documento.seleccionarCelda(33, posicion + 1);
            documento.actualizarValorCelda(saldo_cierre_dolares.ToString("N2"));

            documento.seleccionarCelda(34, posicion + 1);
            documento.actualizarValorCelda(faltante_sobrante_dolares.ToString("N2"));
        }

        #endregion Métodos Privados

    }

}
