//
//  @ Project : 
//  @ File Name : frmMonitoreoManifiestos.cs
//  @ Date : 24/01/2012
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

    public partial class frmMonitoreoManifiestos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<Grupo> _grupos = null;
        private List<Color> _colores = new List<Color>();

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmMonitoreoManifiestos(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                // Mostrar los grupos

                _grupos = _mantenimiento.listarGrupos();

                foreach (Grupo grupo in _grupos)
                    cblGrupos.Items.Add(grupo, true);

                // Ordenar las columnas

                dgvManifiestos.AutoGenerateColumns = false;

                Manifiesto.DisplayIndex = 0;
                FechaIngreso.DisplayIndex = 1;
                Grupo.DisplayIndex = 2;
                T.DisplayIndex = 3;
                Estado.DisplayIndex = 4;

                // Asignar los colores

                _colores.Add(Color.Green);
                _colores.Add(Color.LightGreen);
                _colores.Add(Color.Yellow);
                _colores.Add(Color.Red);

                _coordinacion.agregarRegistroBitacoraMonitoreo(_coordinador);
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
            try
            {
                string comentario = txtComentario.Text;

                _coordinacion.actualizarRegistroBitacoraMonitoreo(_coordinador, comentario);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

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

        /// <summary>
        /// Se marca o desmarca un grupo.
        /// </summary>
        private void cblGrupos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnActualizar.Enabled = cblGrupos.CheckedItems.Count > 0 || e.NewValue == CheckState.Checked;
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
                        documento.formatoCelda(color_fondo: fila_datos.DefaultCellStyle.BackColor);

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
                List<Grupo> grupos = new List<Grupo>();

                foreach (int grupo in cblGrupos.CheckedIndices)
                    grupos.Add(_grupos[grupo]);

                // Determinar si se filtra el reporte por área

                dgvManifiestos.DataSource = _coordinacion.obtenerDatosMonitoreoManifiestos(inicio, grupos);

                foreach (DataGridViewRow fila in dgvManifiestos.Rows)
                {
                    int t = Math.Min((int)fila.Cells[T.Name].Value, 3);
                    Color color = _colores[t];

                    fila.DefaultCellStyle.BackColor = color;
                    fila.Cells[Estado.Index].Style.SelectionBackColor = color;
                }

                // Habilitar los botones de exportar a excel y graficar el monitor tiene datos

                btnExportarExcel.Enabled = dgvManifiestos.RowCount > 0;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

    }

}
