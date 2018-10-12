//
//  @ Project : 
//  @ File Name : frmReportes.cs
//  @ Date : 21/01/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CommonObjects;
using CommonObjects.Graficos;
using BussinessLayer;
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmReportes : Form
    {

        #region Atributos

        private SupervisionBL _supervision = SupervisionBL.Instancia;

        private List<Control> _controles = new List<Control>();

        private Reporte _reporte = null;
        private Colaborador _colaborador = null;

        private DateTime _desde;
        private DateTime _hasta;

        #endregion Atributos

        #region Constructor

        public frmReportes(Reporte reporte, Colaborador colaborador)
        {
            InitializeComponent();

            _reporte = reporte;
            _colaborador = colaborador;

            try
            {
                this.Text = reporte.Nombre;

                // Agregar un control en el formulario para elegir cada parámetro

                int contador_tab = 3;
                int alto_filtros = tlpPanelFiltros.Height;
                int ancho_filtros = tlpPanelFiltros.Width;
                int opcion = 0;

                foreach (Parametro parametro in _reporte.Parametros)
                {
                    Label etiqueta = new Label();
                    Panel panel = new Panel();
                    ComboBox lista = new ComboBox();

                    lista.SetBounds(99, 1, 223, 21);
                    lista.DisplayMember = parametro.Columna_texto;
                    lista.ValueMember = parametro.Columna_valor;
                    lista.TabIndex = contador_tab;
                    lista.DropDown += new EventHandler(this.ajustarLista);

                    etiqueta.Text = parametro.Nombre;
                    etiqueta.SetBounds(15, 5, 78, 13);

                    panel.Size = new Size(325, 35);
                    panel.TabIndex = contador_tab;

                    panel.Controls.Add(etiqueta);
                    panel.Controls.Add(lista);

                    _controles.Add(lista);

                    tlpPanelFiltros.Controls.Add(panel);
                    contador_tab++;
                }

                // Asignar los valores a las listas

                this.actualizarListas();

                // Asignar los valores a las fechas

                DateTime ahora = DateTime.Now;

                DateTime inicio = new DateTime(ahora.Year, ahora.Month, ahora.Day, 0, 0, 0);
                DateTime fin = new DateTime(ahora.Year, ahora.Month, ahora.Day, 23, 59, 59);

                dtpFechaInicio.Value = inicio;
                dtpFechaFin.Value = fin;

                if (!_reporte.Filtro_fechas)
                {
                    pnlFechaInicio.Visible = false;
                    pnlFechaFin.Visible = false;

                    if (_reporte.Parametros.Count == 0)
                        gbFiltros.Visible = false;
                }


                // Desplazar los controles hacia abajo

                int desplazamiento = tlpPanelFiltros.Height - alto_filtros;

                gbFiltros.Height += desplazamiento;






                //

                // Habilitar la opción de generar graficos si el reporte tiene gráficos asociados

                btnGraficar.Visible = _reporte.Graficos.Count > 0;
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
            this.actualizarReporte();
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
        /// Clic en el boton de graficar.
        /// </summary>
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            frmSeleccionGrafico formulario = new frmSeleccionGrafico(_reporte);

            if (formulario.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    Grafico grafico = formulario.Grafico;

                    DateTime inicio = dtpFechaInicio.Value;
                    DateTime fin = dtpFechaFin.Value;
                    Areas area = _colaborador.Area;

                    DataTable datos = _supervision.obtenerDatosGrafico(inicio, fin, area, grafico, _reporte);

                    frmGrafico formulario_grafico = new frmGrafico(datos, grafico);
                    formulario_grafico.ShowDialog();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

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

                if (dgvDatos.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();
                    DataTable datos = (DataTable)dgvDatos.DataSource;
                    documento.seleccionarHoja(1);

                    int fila = 8;

                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B2");
                    documento.actualizarValorCelda(_reporte.Nombre);
                    documento.formatoCelda(subrayado: true, negrita: true, color_fuente: Color.Red);
                    documento.seleccionarSegundaCelda("F2");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B3");
                    documento.actualizarValorCelda(_reporte.Descripcion);
                    documento.seleccionarSegundaCelda("F3");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);
                    documento.cambiarAjusteLinea(true);
                    documento.cambiarTamanoFila(50);
                    documento.cambiarAlineacionTexto(AlineacionVertical.Centro, AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B4");
                    documento.actualizarValorCelda("Desde:");
                    documento.formatoCelda(negrita: true);
                    documento.seleccionarSegundaCelda("F4");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B5");
                    documento.actualizarValorCelda( _desde.ToString());
                    documento.seleccionarSegundaCelda("F5");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B6");
                    documento.actualizarValorCelda("Hasta:");
                    documento.formatoCelda(negrita: true);
                    documento.seleccionarSegundaCelda("F6");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B7");
                    documento.actualizarValorCelda(_hasta.ToString());
                    documento.seleccionarSegundaCelda("F7");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    foreach (Parametro parametro in _reporte.Parametros)
                    {
                        string etiqueta = parametro.Nombre;

                        documento.seleccionarCelda(fila, 2);
                        documento.actualizarValorCelda(etiqueta);
                        documento.formatoCelda(negrita: true);
                        documento.seleccionarCelda(fila, 6);
                        documento.ajustarCeldas(AlineacionHorizontal.Centro);

                        fila += 2;
                    }

                    fila = 9;

                    foreach (ComboBox lista in _controles)
                    {
                        string valor = lista.Text;

                        documento.seleccionarCelda(fila, 2);
                        documento.actualizarValorCelda(valor);
                        documento.seleccionarCelda(fila, 6);
                        documento.ajustarCeldas(AlineacionHorizontal.Centro);
                        
                        fila += 2;
                    }

                    documento.seleccionarCelda("B2");
                    documento.seleccionarSegundaCelda(fila - 2, 6);
                    documento.formatoTabla(false);

                    // Copiar los valores

                    int filas = dgvDatos.Rows.Count;

                    foreach (DataGridViewColumn columna in dgvDatos.Columns)
                    {
                        int numero_columna = columna.Index + 2;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.HeaderText);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filas, numero_columna);
                        documento.autoajustarTamanoColumnas();
                    }

                    documento.seleccionarCelda(fila + 1, 2);
                    documento.actualizarValoresTabla(datos);

                    documento.seleccionarCelda(fila, 2);
                    documento.seleccionarSegundaCelda(fila + filas, dgvDatos.Columns.Count + 1);
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

        /// <summary>
        /// Actualizar los parámetros.
        /// </summary>
        private void actualizarListas()
        {

            try
            {

                for (int contador = 0; contador < _reporte.Parametros.Count; contador++)
                {
                    Parametro parametro = _reporte.Parametros[contador];
                    ComboBox lista = (ComboBox)_controles[contador];

                    lista.DisplayMember = parametro.Columna_texto;
                    lista.ValueMember = parametro.Columna_valor;

                    lista.DataSource = _supervision.obtenerListaParametro(parametro);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Actualizar el reporte.
        /// </summary>
        private void actualizarReporte()
        {

            try
            {
                dgvDatos.DataSource = null;

                for (int contador = 0; contador < _reporte.Parametros.Count; contador++)
                {
                    Parametro parametro = _reporte.Parametros[contador];
                    ComboBox lista = (ComboBox)_controles[contador];

                    if (lista.SelectedIndex == 0 || lista.SelectedItem == null)
                    {
                        parametro.Valor = null;
                    }
                    else
                    {
                        DataRowView fila = (DataRowView)lista.SelectedItem;
                        object valor = fila[parametro.Columna_valor];

                        parametro.Valor = valor;
                    }

                }

                DateTime inicio = dtpFechaInicio.Value;
                DateTime fin = dtpFechaFin.Value;
                Areas area = _colaborador.Area;

                // Mostrar los datos del reporte

                dgvDatos.DataSource = _supervision.obtenerDatosReporte(inicio, fin, area, _reporte);

                foreach (DataGridViewColumn columna in dgvDatos.Columns)
                {
                    if (columna.ValueType == typeof(decimal))
                        columna.DefaultCellStyle.Format = "N2";

                    if (columna.ValueType == typeof(DateTime))
                        columna.DefaultCellStyle.Format = "F";
                }


               
                   

                // Habilitar los botones de exportar a excel y graficar el reporte si el mismo tiene datos

                if (dgvDatos.RowCount > 0)
                {
                    btnExportarExcel.Enabled = true;
                    btnGraficar.Enabled = true;
                }
                else
                {
                    btnExportarExcel.Enabled = false;
                    btnGraficar.Enabled = false;
                }

                _desde = inicio;
                _hasta = fin;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Ajustar el ancho de la lista.
        /// </summary>
        private void ajustarLista(object sender, System.EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            int ancho = combo.DropDownWidth;
            Graphics manejador = combo.CreateGraphics();
            Font fuente = combo.Font;

            int vertScrollBarWidth =
                (combo.Items.Count > combo.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

            int nuevo_ancho;
             
            foreach (DataRowView item in combo.Items)
            {
                string cadena = (string)item[combo.DisplayMember];
                nuevo_ancho = (int)manejador.MeasureString(cadena, fuente).Width + vertScrollBarWidth;
                ancho = (ancho < nuevo_ancho) ? nuevo_ancho : ancho;
            }

            combo.DropDownWidth = ancho;
        }

        #endregion Métodos Privados

        private void tlpDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        

    }

}
