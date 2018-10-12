using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmManifiestosFacturacion : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private List<Color> _colores = new List<Color>();

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmManifiestosFacturacion(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
        
            try
            {
               // Ordenar las columnas

                dgvManifiestos.AutoGenerateColumns = false;

                Manifiesto.DisplayIndex = 0;
                FechaIngreso.DisplayIndex = 1;
                Transportadora.DisplayIndex = 2;
                T.DisplayIndex = 3;
                           
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
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.actualizarMonitor();
        }

        /// <summary>
        /// Clic en el boton de exportar a Excel.
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

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {
            try
            {
                if (dgvManifiestos.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();

                    // Copiar los valores
                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("A1");
                    documento.actualizarValoresTabla((DataTable)dgvManifiestos.DataSource);
                    
                    documento.seleccionarCelda("A1");
                    documento.seleccionarCelda(dgvManifiestos.Rows.Count, 4);
                    documento.formatoTabla(false);
                    

                    int fila = 1;

                    foreach (DataGridViewRow fila_datos in dgvManifiestos.Rows)
                    {
                        documento.seleccionarCelda(fila, 1);
                        documento.seleccionarSegundaCelda(fila, 4);

                        documento.seleccionarCelda("B1");
                        documento.seleccionarCelda(fila,2);
                        documento.formatoCeldaTipoDatos("dd/mm/aaaa hh:mm:ss am/pm");
                        fila++;
                    }
                    
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

        /// <summary>
        /// Actualizar el monitor.
        /// </summary>
        private void actualizarMonitor()
        {

            try
            {
                dgvManifiestos.DataSource = null;

                DateTime inicio = dtpFechaInicio.Value;
                EmpresaTransporte transportadora = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;
                 
                dgvManifiestos.DataSource = _coordinacion.obtenerDatosManifiestosFacturacion(inicio, transportadora);

                // Habilitar los botones de exportar a excel y graficar el monitor tiene datos

                btnExportarExcel.Enabled = dgvManifiestos.RowCount > 0;
            }
            catch (Excepcion  ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        private void frmManifiestosFacturacion_Load(object sender, EventArgs e)
        {

        }

        private void cboTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvManifiestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
