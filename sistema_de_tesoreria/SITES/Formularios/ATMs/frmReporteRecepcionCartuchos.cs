using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using BussinessLayer;
using DataLayer;
using LibreriaMensajes;
using CommonObjects.Clases;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmReporteRecepcionCartuchos : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        //private CartuchosDL _cartuchos = new CartuchosDL();

        #endregion Atributos

        #region Constructor

        public frmReporteRecepcionCartuchos()
        {
            InitializeComponent();
            cboResponsableEntrega.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.ATMs, Puestos.Receptor, Puestos.Coordinador, Puestos.Supervisor, Puestos.CajeroA);
            cboResponsableRegistro.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.ATMs, Puestos.Receptor, Puestos.Coordinador, Puestos.Supervisor, Puestos.CajeroA);
            cboProveedor.ListaMostrada = _mantenimiento.listarProveedorCartucho(string.Empty);      

        }

        #endregion Constructor

        #region Eventos
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRecepcion.DataSource = null;
                // Mostrar los datos del reporte


                Colaborador entrega = null;
                if (cboResponsableEntrega.Text != "Todos")
                {
                    entrega = (Colaborador)cboResponsableEntrega.SelectedItem;
                }
                Colaborador registra = null;
                if (cboResponsableRegistro.Text != "Todos")
                {
                    registra = (Colaborador)cboResponsableRegistro.SelectedItem;
                }
                ProveedorCartucho prov = null;
                if (cboProveedor.Text != "Todos")
                {
                    prov = (ProveedorCartucho)cboProveedor.SelectedItem;
                }
                EstadosCartuchos est = EstadosCartuchos.Indefinido;
                if (cboEstado.SelectedIndex > 0)
                {
                    est = (EstadosCartuchos)cboEstado.SelectedIndex;
                }


                dgvRecepcion.DataSource = _mantenimiento.ObtieneDatosRecepcion(entrega, registra, prov, est);
                dgvResumen.DataSource = _mantenimiento.ObtieneDatosResumenRecepcion();

                foreach (DataGridViewColumn columna in dgvRecepcion.Columns)
                {
                    if (columna.ValueType == typeof(decimal))
                        columna.DefaultCellStyle.Format = "N2";

                    if (columna.ValueType == typeof(DateTime))
                        columna.DefaultCellStyle.Format = "dd'/'MM'/'yyyy hh:mm:ss tt";
                }

                // Habilitar los botones de exportar a excel y graficar el reporte si el mismo tiene datos

                if (dgvRecepcion.RowCount > 0)
                {
                    btnExportar.Enabled = true;
                }
                else
                {
                    btnExportar.Enabled = false;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportar();
        }

        #endregion Eventos

        #region Metodos Privados
        /// <summary>
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {

            try
            {

                if (dgvRecepcion.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();
                    DataTable datos = (DataTable)dgvRecepcion.DataSource;
                    DataTable datosR = (DataTable)dgvResumen.DataSource;
                    documento.seleccionarHoja(1);

                    int fila = 9;

                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B2");
                    documento.actualizarValorCelda("Reporte de Recepción de Cartuchos");
                    documento.formatoCelda(subrayado: true, negrita: true, color_fuente: Color.Red);
                    documento.seleccionarSegundaCelda("H2");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    //Encabezado del Resumen
                    documento.seleccionarCelda("J8");
                    documento.actualizarValorCelda("Resumen de Reporte de Recepción de Cartuchos");
                    documento.formatoCelda(subrayado: true, negrita: true, color_fuente: Color.Red);
                    documento.seleccionarSegundaCelda("M8");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B3");
                    documento.actualizarValorCelda("Muestra una lista de los cartuchos enviados y/o recibidos de taller así como los no recuperables");
                    documento.seleccionarSegundaCelda("H3");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);
                    documento.cambiarAjusteLinea(true);
                    documento.cambiarTamanoFila(50);
                    documento.cambiarAlineacionTexto(AlineacionVertical.Centro, AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B4");
                    documento.actualizarValorCelda("Estado: " + cboEstado.Text);
                    documento.formatoCelda(negrita: false);
                    documento.seleccionarSegundaCelda("H4");
                    documento.ajustarCeldas(AlineacionHorizontal.Izquierda);

                    documento.seleccionarCelda("B5");
                    documento.actualizarValorCelda("Proveedor: " + cboProveedor.Text);
                    documento.seleccionarSegundaCelda("H5");
                    documento.ajustarCeldas(AlineacionHorizontal.Izquierda);

                    documento.seleccionarCelda("B6");
                    documento.actualizarValorCelda("Responsable Entrega: " + cboResponsableEntrega.Text);
                    documento.formatoCelda(negrita: false);
                    documento.seleccionarSegundaCelda("H6");
                    documento.ajustarCeldas(AlineacionHorizontal.Izquierda);

                    documento.seleccionarCelda("B7");
                    documento.actualizarValorCelda("Responsable Recibir: " + cboResponsableRegistro.Text);
                    documento.seleccionarSegundaCelda("H7");
                    documento.ajustarCeldas(AlineacionHorizontal.Izquierda);

                 
                    documento.seleccionarCelda("B2");
                    documento.seleccionarSegundaCelda(fila - 2, 8);
                    documento.formatoTabla(false);

                    // Copiar los valores

                    int filas = dgvRecepcion.Rows.Count;

                    foreach (DataGridViewColumn columna in dgvRecepcion.Columns)
                    {
                        int numero_columna = columna.Index + 2;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.HeaderText);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filas, numero_columna);
                        documento.autoajustarTamanoColumnas();

                        if (columna.Index == 1 || columna.Index == 2)
                            documento.formatoCeldaTipoDatos("dd/mm/yyyy hh:mm");//

                    }

                    documento.seleccionarCelda(fila + 1, 2);
                    documento.actualizarValoresTabla(datos);

                    documento.seleccionarCelda(fila, 2);
                    documento.seleccionarSegundaCelda(fila + filas, dgvRecepcion.Columns.Count + 1);
                    documento.formatoTabla(false);


                    //para el resumen
                    int filasR = dgvResumen.Rows.Count;

                    foreach (DataGridViewColumn columna in dgvResumen.Columns)
                    {
                        int numero_columna = columna.Index + 10;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.HeaderText);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filasR, numero_columna);
                        documento.autoajustarTamanoColumnas();

                    }

                    documento.seleccionarCelda(fila + 1, 10);
                    documento.actualizarValoresTabla(datosR);

                    documento.seleccionarCelda(fila, 10);
                    documento.seleccionarSegundaCelda(fila + filasR, dgvResumen.Columns.Count + 1);
                    documento.formatoTabla(false);

                    // Mostrar el libro y cerrarlo

                    documento.mostrar();
                    documento.cerrar();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Metodos Privados

    }
}
