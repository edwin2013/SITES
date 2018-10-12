//
//  @ Project : 
//  @ File Name : frmImpresionCargas.cs
//  @ Date : 27/06/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmImpresionCargas : Form
    {

        private enum TiposReportes : byte
        {
            ConsolidadoGeneral = 0,
            ConsolidadoCajero = 1,
            ConsolidadoRuta = 2,
            DenominaciónGeneral = 3,
            DenominaciónCajero = 4,
            DenominaciónRuta = 5,
            CargarGeneradas = 6
        }

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmImpresionCargas()
        {
            InitializeComponent();

            try
            {
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.ATMs, Puestos.CajeroA, Puestos.CajeroB);
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
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
        /// Clic en el botón de exportar.
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                TiposReportes tipo = (TiposReportes)cboTipoReporte.SelectedIndex;

                switch (tipo)
                {
                    case TiposReportes.ConsolidadoCajero:
                    case TiposReportes.ConsolidadoGeneral:
                    case TiposReportes.ConsolidadoRuta:
                        this.exportarReporte(tipo);
                        break;
                    case TiposReportes.DenominaciónCajero:
                    case TiposReportes.DenominaciónGeneral:
                    case TiposReportes.DenominaciónRuta:
                        this.exportarHojaCargas(tipo);
                        break;
                    case TiposReportes.CargarGeneradas:
                        this.exportarCargasGeneradasImportadas();
                        break;
                }

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
        /// Se selecciona otro cajero de la lista de cajeros.
        /// </summary>
        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExportarExcel.Enabled = cboCajero.SelectedItem != null;
        }

        /// <summary>
        /// Se selecciona otra transportadora de la lista de transportadoras.
        /// </summary>
        private void cboTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExportarExcel.Enabled = cboTransportadora.SelectedItem != null;
        }

        /// <summary>
        /// Se selecciona otro tipo de reporte.
        /// </summary>
        private void cboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiposReportes tipo = (TiposReportes)cboTipoReporte.SelectedIndex;

            switch (tipo)
            {
                case TiposReportes.ConsolidadoGeneral:
                case TiposReportes.DenominaciónGeneral:
                    pnlFiltroCajero.Visible = false;
                    pnlFiltroRuta.Visible = false;
                    pnlFiltroTransportadora.Visible = false;

                    btnExportarExcel.Enabled = true;
                    break;
                case TiposReportes.ConsolidadoCajero:
                case TiposReportes.DenominaciónCajero:
                    pnlFiltroCajero.Visible = true;
                    pnlFiltroRuta.Visible = false;
                    pnlFiltroTransportadora.Visible = false;

                    btnExportarExcel.Enabled = cboCajero.SelectedItem != null;
                    break;
                case TiposReportes.ConsolidadoRuta:
                case TiposReportes.DenominaciónRuta:
                    pnlFiltroCajero.Visible = false;
                    pnlFiltroRuta.Visible = true;
                    pnlFiltroTransportadora.Visible = false;

                    btnExportarExcel.Enabled = true;
                    break;
                case TiposReportes.CargarGeneradas:
                    pnlFiltroCajero.Visible = false;
                    pnlFiltroRuta.Visible = false;
                    pnlFiltroTransportadora.Visible = true;

                    btnExportarExcel.Enabled = cboTransportadora.SelectedItem != null;
                    break;

            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Exportar los datos de los reportes.
        /// </summary>
        private void exportarReporte(TiposReportes tipo)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel();
                DateTime fecha = dtpFecha.Value;
                DataTable datos = null;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                byte ruta = (byte)nudRuta.Value;

                documento.seleccionarHoja(1);

                switch (tipo)
                {
                    case TiposReportes.ConsolidadoGeneral:
                        datos = _coordinacion.listarCargasATMsImpresionConsolidado(null, null, fecha);
                        break;
                    case TiposReportes.ConsolidadoCajero:
                        datos = _coordinacion.listarCargasATMsImpresionConsolidado(cajero, null, fecha);
                        break;
                    case TiposReportes.ConsolidadoRuta:
                        datos = _coordinacion.listarCargasATMsImpresionConsolidado(null, ruta, fecha);
                        break;
                }

                documento.seleccionarCelda("B6");
                documento.actualizarValoresTabla(datos);
                documento.seleccionarCelda("B5");
                documento.seleccionarSegundaCelda(datos.Rows.Count + 6, datos.Columns.Count + 1);
                documento.cambiarAlineacionTexto(AlineacionVertical.Centro, AlineacionHorizontal.Centro);
                documento.cambiarTamanoFila(50);
                documento.formatoTabla(true);

                documento.seleccionarCelda("K6");
                documento.seleccionarSegundaCelda(datos.Rows.Count + 5, datos.Columns.Count + 1);
                documento.formatoCelda(negrita: true, tamano: 14);
                documento.formatoCeldaTipoDatos("#.##0");

                // Dar formato al reporte

                this.mostrarParametro(documento, "Fecha: " + fecha.ToShortDateString(), "B2", "F2");

                switch (tipo)
                {
                    case TiposReportes.ConsolidadoCajero:
                    case TiposReportes.DenominaciónCajero:
                        this.mostrarParametro(documento, "Cajero: " + cajero.ToString(), "B3", "F3");
                        break;
                    case TiposReportes.ConsolidadoRuta:
                    case TiposReportes.DenominaciónRuta:
                        this.mostrarParametro(documento, "Ruta: " + ruta, "B3", "F3");
                        break;
                }

                for (int contador = 0; contador < datos.Columns.Count; contador++)
                {
                    DataColumn columna = datos.Columns[contador];

                    documento.seleccionarCelda(5, contador + 2);
                    documento.actualizarValorCelda(columna.ColumnName);
                    documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);

                    documento.seleccionarColumna();
                    documento.autoajustarTamanoColumnas();
                }

                for (int contador = 0; contador < datos.Columns.Count; contador++)
                {
                    documento.seleccionarCelda(5, contador + 11);
                    documento.formatoCelda(negrita: true, tamano: 16);

                    documento.seleccionarCelda(datos.Rows.Count + 6, contador + 11);
                    documento.formatoCelda(negrita: true, tamano: 16);

                    documento.seleccionarColumna();
                    documento.autoajustarTamanoColumnas();
                }

                documento.definirOpcionesimpresionImpresion(Orientacion.Horizontal, true);

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Exportar la hoja de cargas.
        /// </summary>
        private void exportarHojaCargas(TiposReportes tipo)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla hoja de cargas.xlt", true);
                DateTime fecha = dtpFecha.Value;
                DataTable datos = null;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                byte ruta = (byte)nudRuta.Value;

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("K1");
                documento.actualizarValorCelda(fecha.ToShortDateString());
                
                // Agregar Ruta 

             

                switch (tipo)
                {
                    case TiposReportes.DenominaciónGeneral:
                        datos = _coordinacion.listarCargasATMsImpresionDetallado(null, null, fecha);
                        break;
                    case TiposReportes.DenominaciónCajero:
                        datos = _coordinacion.listarCargasATMsImpresionDetallado(cajero, null, fecha);
                        
                        documento.seleccionarCelda("J2");
                        documento.actualizarValorCelda("Cajero:");
                        documento.seleccionarCelda("K2");
                        documento.actualizarValorCelda(cajero.ToString());
                        break;
                    case TiposReportes.DenominaciónRuta:
                        datos = _coordinacion.listarCargasATMsImpresionDetallado(null, ruta, fecha);

                        documento.seleccionarCelda("J2");
                        documento.actualizarValorCelda("Ruta:");
                        documento.seleccionarCelda("K2");
                        documento.actualizarValorCelda(ruta.ToString());
                        break;
                }

                documento.seleccionarCelda("A4");
                documento.actualizarValoresTabla(datos);

                documento.seleccionarCelda("A3");
                documento.seleccionarSegundaCelda(27, datos.Columns.Count);
                documento.formatoTabla(true);

                for (int contador = 0; contador < datos.Columns.Count; contador++)
                {
                    DataColumn columna = datos.Columns[contador];

                    documento.seleccionarCelda(3, contador + 1);
                    documento.actualizarValorCelda(columna.ColumnName);
                }

                for (int contador = 11; contador < datos.Columns.Count; contador++)
                {
                    documento.seleccionarCelda(3, contador + 1);
                    documento.seleccionarColumna();
                    documento.autoajustarTamanoColumnas();
                }

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        /// <summary>
        /// Exportar los datos de la hoja de cargas importadas y generadas.
        /// </summary>
        private void exportarCargasGeneradasImportadas()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla cargas generadas o importadas.xlt", true);
                DateTime fecha = dtpFecha.Value;
                EmpresaTransporte transportadora = (EmpresaTransporte)cboTransportadora.SelectedItem;

                DataTable datos = _coordinacion.listarCargasATMsImpresionGeneradasImportadas(fecha, transportadora);

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("G4");
                documento.actualizarValorCelda(fecha.ToShortDateString());

                for (int contador = 3, numero_columa = 5; contador < datos.Columns.Count; contador++, numero_columa++)
                {
                    DataColumn columna = datos.Columns[contador];
                    string nombre_columna = columna.ColumnName;

                    documento.seleccionarCelda(7, numero_columa);

                    nombre_columna = nombre_columna.Remove(nombre_columna.Length - 2);

                    documento.actualizarValorCelda(nombre_columna);
                }

                documento.seleccionarCelda("B8");
                documento.actualizarValoresTabla(datos);

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Mostrar un parámetro del reporte.
        /// </summary>
        private void mostrarParametro(DocumentoExcel documento, string parametro, string celda_a, string celda_b)
        {
            documento.seleccionarCelda(celda_a);
            documento.actualizarValorCelda(parametro);
            documento.seleccionarSegundaCelda(celda_b);
            documento.formatoTabla(false);
            documento.ajustarCeldas(AlineacionHorizontal.Centro);
        }

        #endregion Métodos Privados

    }

}
