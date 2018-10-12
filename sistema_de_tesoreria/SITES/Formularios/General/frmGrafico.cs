//
//  @ Project : 
//  @ File Name : frmGrafico.cs
//  @ Date : 06/05/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using CommonObjects.Graficos;

namespace GUILayer
{

    public partial class frmGrafico : Form
    {

        #region Atributos

        private Grafico _grafico = null;

        private bool _valor_grafico_pie = false;
        private bool _porcentaje_grafico_pie = false;

        #endregion Atributos

        #region Constructor

        public frmGrafico(DataTable dat_datos, Grafico grafico)
        {
            InitializeComponent();

            // Cargar la lista de colores

            cboColores.Items.Add(ChartColorPalette.Grayscale);
            cboColores.Items.Add(ChartColorPalette.EarthTones);
            cboColores.Items.Add(ChartColorPalette.Excel);
            cboColores.Items.Add(ChartColorPalette.Fire);
            cboColores.SelectedIndex = 0;

            // Contruir el gráfico dependiendo de su tipo

            _grafico = grafico;

            if (grafico is GraficoBoxPlot)
                this.crearGraficoBoxPlot((GraficoBoxPlot)grafico, dat_datos);
            else if (grafico is GraficoHistograma)
                this.crearGraficoHistograma((GraficoHistograma)grafico, dat_datos);
            else if (grafico is GraficoPie)
                this.crearGraficoPie((GraficoPie)grafico, dat_datos);
            else if (grafico is GraficoBarra)
                this.crearGraficoBarras((GraficoBarra)grafico, dat_datos);
            else if (grafico is GraficoBarraLinea)
                this.crearGraficoBarrasLineas((GraficoBarraLinea)grafico, dat_datos);

        }

        /// <summary>
        /// Crear un gráfico de tipo BoxPlot.
        /// </summary>
        private void crearGraficoBoxPlot(GraficoBoxPlot grafico, DataTable dat_datos)
        {
            // Mostrar las opciones del gráfico BoxPlot

            gbOpcionesBoxPlot.Visible = true;

            // Crear la serie BoxPlot

            Series serie_box_plot = new Series();
            string nombre_serie_box_plot = grafico.Nombre_serie;

            serie_box_plot.Name = nombre_serie_box_plot;
            serie_box_plot.ChartType = SeriesChartType.BoxPlot;

            crtGrafico.Series.Add(serie_box_plot);

            // Agregar las series de datos a la serie boxplot

            string series = string.Empty;

            crtGrafico.DataBindCrossTable(dat_datos.Select(), grafico.Campo_x, grafico.Campo_x, grafico.Campo_y, string.Empty);

            for (int contador = 1; contador < crtGrafico.Series.Count; contador++)
            {
                Series serie = crtGrafico.Series[contador];

                serie.Enabled = false;
                series += serie.Name + ";";
            }

            series = series.Remove(series.Length - 1);
            crtGrafico.Series[nombre_serie_box_plot]["BoxPlotSeries"] = series;


            for (int i = 1; i < crtGrafico.Series.Count; i++)
                crtGrafico.ChartAreas[0].AxisX.CustomLabels.Add(i - 0.5, i + 0.5, crtGrafico.Series[i].Name);

            // Dar formato al gráfico

            Title titulo = new Title(grafico.Nombre);

            crtGrafico.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            crtGrafico.ChartAreas[0].AxisY.MajorGrid.Interval = 10;
            crtGrafico.Titles.Add(titulo);
        }

        /// <summary>
        /// Crear un gráfico de tipo Histograma.
        /// </summary>
        private void crearGraficoHistograma(GraficoHistograma grafico, DataTable dat_datos)
        {
            // Mostrar las opciones del gráfico BoxPlot

            gbOpcionesHistograma.Visible = true;

            // Calcular los valores del gráfico

            int total = dat_datos.Rows.Count;

            double minimo = Convert.ToDouble(dat_datos.Compute("Min(Efectividad)", string.Empty));
            double maximo = Convert.ToDouble(dat_datos.Compute("Max(Efectividad)", string.Empty));
            double rango = maximo - minimo;
            double intervalo = Math.Round(rango / Math.Sqrt(total), 2);

            // Definir los rangos

            List<double> limites = new List<double>();

            do
            {
                limites.Add(minimo);
                minimo = Math.Min(minimo + intervalo, maximo);
            }
            while (minimo < maximo);

            // Clasificar los valores

            List<double> porcentajes = new List<double>();
            List<double> cantidades = new List<double>();

            foreach (double limite in limites)
            {
                string expresion = ("Efectividad >= " + limite).Replace(',','.');

                double cantidad = Convert.ToDouble(dat_datos.Compute("COUNT(Efectividad)", expresion));
                double porcentaje = (cantidad / total) * 100;

                cantidades.Add(cantidad);
                porcentajes.Add(Math.Round(porcentaje, 2));
            }

            for (int contador = 0; contador < porcentajes.Count - 1; contador++)
            {
                porcentajes[contador] -= porcentajes[contador + 1];
                cantidades[contador] -= cantidades[contador + 1];
            }

            // Agregar la serie que muestra los porcentajes

            Series serie_porcentajes = new Series();

            serie_porcentajes.Name = grafico.Nombre_serie + "(Porcentaje)";
            serie_porcentajes.ChartType = SeriesChartType.Column;
            serie_porcentajes.Points.DataBindY(porcentajes);
            serie_porcentajes.IsValueShownAsLabel = true;

            crtGrafico.Series.Add(serie_porcentajes);

            // Agregar la serie que muestra las cantidades

            Series serie_cantidades = new Series();

            serie_cantidades.Name = grafico.Nombre_serie + "(Cantidad)";
            serie_cantidades.ChartType = SeriesChartType.Column;
            serie_cantidades.Points.DataBindY(cantidades);
            serie_cantidades.IsValueShownAsLabel = true;

            crtGrafico.Series.Add(serie_cantidades);

            // Agregar las etiquetas del eje x

            int posicion = 0;

            for (posicion = 0; posicion < porcentajes.Count; posicion++)
            {
                double limite = Math.Round(limites[posicion], 2);

                crtGrafico.ChartAreas[0].AxisX.CustomLabels.Add(posicion, posicion + 1, limite.ToString());
            }

            maximo = Math.Round(maximo, 2);
            crtGrafico.ChartAreas[0].AxisX.CustomLabels.Add(posicion, posicion + 1, maximo.ToString());

            // Dar formato al gráfico

            Title titulo = new Title(grafico.Nombre);

            crtGrafico.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            crtGrafico.Titles.Add(titulo);

            cboValor.SelectedIndex = 0;
        }

        /// <summary>
        /// Crear un gráfico de tipo Pie.
        /// </summary>
        private void crearGraficoPie(GraficoPie grafico, DataTable datos)
        {
            // Mostrar las opciones del gráfico Pie

            gbOpcionesPie.Visible = true;

            // Agregar los datos al gráfico

            Series serie_pie = new Series();

            serie_pie.Name = grafico.Nombre_serie;
            serie_pie.ChartType = SeriesChartType.Pie;

            crtGrafico.Series.Add(serie_pie);

            crtGrafico.DataSource = datos;
            crtGrafico.Series[grafico.Nombre_serie].XValueMember = grafico.Campo_x;
            crtGrafico.Series[grafico.Nombre_serie].YValueMembers = grafico.Campo_y;
            crtGrafico.DataBind();

            // Dar formato al gráfico

            Title titulo = new Title(grafico.Nombre);

            crtGrafico.Titles.Add(titulo);
        }

        /// <summary>
        /// Crear un gráfico de Barras.
        /// </summary>
        private void crearGraficoBarras(GraficoBarra grafico, DataTable datos)
        {
            // Mostrar las opciones del gráfico de Barras

            gbOpcionesBarras.Visible = true;

            // Agregar los datos al gráfico

            Series serie_barras = new Series();

            serie_barras.Name = grafico.Nombre_serie;
            serie_barras.ChartType = SeriesChartType.Column;

            crtGrafico.Series.Add(serie_barras);

            crtGrafico.DataSource = datos;

            serie_barras.XValueMember = grafico.Campo_x;
            serie_barras.YValueMembers = grafico.Campo_y;

            crtGrafico.DataBind();

            // Dar formato al gráfico

            Title titulo = new Title(grafico.Nombre);

            double maximo = Convert.ToDouble(datos.Compute("Max(" + grafico.Campo_y + ")", string.Empty));

            crtGrafico.ChartAreas[0].AxisY.Maximum = maximo;
            crtGrafico.Titles.Add(titulo);
            crtGrafico.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            cboTipo.SelectedIndex = 0;
        }

        /// <summary>
        /// Crear un gráfico de Barrasy Líneas.
        /// </summary>
        private void crearGraficoBarrasLineas(GraficoBarraLinea grafico, DataTable datos)
        {
            // Mostrar las opciones del gráfico

            gbOpcionesBarrasLineas.Visible = true;

            // Agregar los datos al gráfico

            Series serie_barras = new Series();
            Series serie_lineas = new Series();

            serie_barras.Name = grafico.Nombre_serie;
            serie_barras.ChartType = SeriesChartType.Column;

            serie_lineas.Name = grafico.Serie_linea;
            serie_lineas.ChartType = SeriesChartType.Line;

            crtGrafico.Series.Add(serie_barras);
            crtGrafico.Series.Add(serie_lineas);

            crtGrafico.DataSource = datos;

            crtGrafico.Series[grafico.Nombre_serie].XValueMember = grafico.Campo_x;
            crtGrafico.Series[grafico.Nombre_serie].YValueMembers = grafico.Campo_y_barra;

            crtGrafico.Series[grafico.Serie_linea].XValueMember = grafico.Campo_x;
            crtGrafico.Series[grafico.Serie_linea].YValueMembers = grafico.Campo_y_linea;

            crtGrafico.DataBind();

            // Dar formato al gráfico

            Title titulo = new Title(grafico.Nombre);

            double maximo_lineas = Convert.ToDouble(datos.Compute("Max(" + grafico.Campo_y_linea + ")", string.Empty));
            double maximo_barras = Convert.ToDouble(datos.Compute("Max(" + grafico.Campo_y_barra + ")", string.Empty));

            crtGrafico.ChartAreas[0].AxisY.Maximum = Math.Max(maximo_lineas, maximo_barras);
            crtGrafico.Titles.Add(titulo);
            crtGrafico.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
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
        /// Clic en el botón de exportar.
        /// </summary>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ChartImageFormat[] formatos = { ChartImageFormat.Jpeg, ChartImageFormat.Bmp, ChartImageFormat.Png };

            if (sfdGuardar.ShowDialog() == DialogResult.OK)
                crtGrafico.SaveImage(sfdGuardar.FileName, formatos[sfdGuardar.FilterIndex - 1]);

        }

        /// <summary>.
        /// Se marca o desmarca la opción de mostrar el gráfico en 3D.
        /// </summary
        private void cbMostrar3D_CheckedChanged(object sender, EventArgs e)
        {
            crtGrafico.ChartAreas[0].Area3DStyle.Enable3D = cbMostrar3D.Checked;
        }

        /// <summary>
        /// Se selecciona otra paleta de colores.
        /// </summary
        private void cboColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartColorPalette paleta = (ChartColorPalette)cboColores.SelectedItem;
            crtGrafico.Palette = paleta;
        }

        /// <summary>
        /// Se mueve la barra vertical.
        /// </summary>
        private void vsbBarra_Scroll(object sender, ScrollEventArgs e)
        {
            crtGrafico.Top = -vsbBarra.Value;
        }

        /// <summary>
        /// Se mueve la barra horizontal.
        /// </summary>
        private void hsbBarra_Scroll(object sender, ScrollEventArgs e)
        {
            crtGrafico.Left = -hsbBarra.Value;
        }

        /// <summary>
        /// Se cambia el valor del zoom.
        /// </summary>
        private void nudZoom_ValueChanged(object sender, EventArgs e)
        {
            this.redimensionarGrafico();
        }

        /// <summary>
        /// Se cambia el valor del zoom.
        /// </summary>
        private void pnlGrafico_Resize(object sender, EventArgs e)
        {
            this.redimensionarGrafico();
        }

        /// <summary>
        /// Mostrar los valores inusuales en un gráfico boxplot.
        /// </summary>
        private void chkValoresInusuales_CheckedChanged(object sender, EventArgs e)
        {
            string nombre_serie = _grafico.Nombre_serie;

            crtGrafico.Series[nombre_serie]["BoxPlotShowUnusualValues"] = chkValoresInusuales.Checked.ToString();
        }

        /// <summary>
        /// Mostrar la media en un gráfico boxplot.
        /// </summary>
        private void chkMedia_CheckedChanged(object sender, EventArgs e)
        {
            string nombre_serie = _grafico.Nombre_serie;

            crtGrafico.Series[nombre_serie]["BoxPlotShowMedian"] = chkMedia.Checked.ToString();
        }

        /// <summary>
        /// Mostrar  el promedio en un gráfico boxplot.
        /// </summary>
        private void chkPromedio_CheckedChanged(object sender, EventArgs e)
        {
            string nombre_serie = _grafico.Nombre_serie;

            crtGrafico.Series[nombre_serie]["BoxPlotShowAverage"] = chkPromedio.Checked.ToString();
        }

        /// <summary>
        /// Mostrar  las líneas verticales de un histograma.
        /// </summary>
        private void chkLineas_CheckedChanged(object sender, EventArgs e)
        {
            crtGrafico.ChartAreas[0].AxisX.MajorGrid.Enabled = chkLineas.Checked;
        }

        /// <summary>
        /// Seleccionar que valor se mostrara en un histograma.
        /// </summary>
        private void cboValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            crtGrafico.Series[0].Enabled = cboValor.SelectedIndex == 0;
            crtGrafico.Series[1].Enabled = cboValor.SelectedIndex == 1;

            crtGrafico.ChartAreas[0].AxisY.Maximum = crtGrafico.Series[cboValor.SelectedIndex].Points.FindMaxByValue().YValues[0];
        }

        /// <summary>
        /// Mostrar los porcentajes en un gráfico pie.
        /// </summary>
        private void chkPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            _porcentaje_grafico_pie = chkPorcentaje.Checked;
            this.mostrarDatosPie();
        }

        /// <summary>
        /// Mostrar los valores en un gráfico pie.
        /// </summary>
        private void chkValorPie_CheckedChanged(object sender, EventArgs e)
        {
            _valor_grafico_pie = chkValorPie.Checked;
            this.mostrarDatosPie();
        }

        /// <summary>
        /// Mostrar los datos en un gráfico pie
        /// </summary>
        private void mostrarDatosPie()
        {
            string etiqueta = string.Empty;

            if (_valor_grafico_pie && _porcentaje_grafico_pie)
                etiqueta = "(#VAL - #PERCENT)";
            else if (_valor_grafico_pie)
                etiqueta = "(#VAL)";
            else if (_porcentaje_grafico_pie)
                etiqueta = "(#PERCENT)";

            foreach (DataPoint punto in crtGrafico.Series[0].Points)
                punto.Label = punto.AxisLabel + etiqueta;

        }

        /// <summary>
        /// Mostrar los valores en un gráfico de barras.
        /// </summary>
        private void chkValorBarras_CheckedChanged(object sender, EventArgs e)
        {
            crtGrafico.Series[0].IsValueShownAsLabel = chkValorBarras.Checked;
        }

        /// <summary>
        /// Se selecciona otro tipo de gráfico de barras.
        /// </summary>
        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cboTipo.SelectedIndex)
            {
                case 0:
                    crtGrafico.Series[0].ChartType = SeriesChartType.Column;
                    crtGrafico.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                    break;
                case 1:
                    crtGrafico.Series[0].ChartType = SeriesChartType.Bar;
                    crtGrafico.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
                    break;

                case 2:
                    crtGrafico.Series[0].ChartType = SeriesChartType.Line;
                    crtGrafico.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                    break;
            }

        }

        /// <summary>
        /// Mostrar los valores del gráfico de líneas.
        /// </summary>
        private void chkValoresLineas_CheckedChanged(object sender, EventArgs e)
        {
            crtGrafico.Series[1].IsValueShownAsLabel = chkValoresLineas.Checked;
        }

        /// <summary>
        /// Mostrar los valores del gráfico de barras
        /// </summary>
        private void chkValoresBarras_CheckedChanged(object sender, EventArgs e)
        {
            crtGrafico.Series[0].IsValueShownAsLabel = chkValoresBarras.Checked;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Redimensionar el gráfico y los barras de desplazamiento.
        /// </summary>
        private void redimensionarGrafico()
        {
            crtGrafico.Height = (int)(pnlGrafico.Height * (nudZoom.Value / 100));
            crtGrafico.Width = (int)(pnlGrafico.Width * (nudZoom.Value / 100));

            //Ajustar las barras de scroll

            crtGrafico.Location = new Point(0, 0);
            vsbBarra.Value = 0;
            hsbBarra.Value = 0;

            if (crtGrafico.Height <= pnlGrafico.Height)
            {
                vsbBarra.Enabled = false;
            }
            else
            {
                vsbBarra.Maximum = crtGrafico.Height - pnlGrafico.Height;
                vsbBarra.Enabled = true;
            }

            if (crtGrafico.Width <= pnlGrafico.Width)
            {
                hsbBarra.Enabled = false;
            }
            else
            {
                hsbBarra.Maximum = crtGrafico.Width - pnlGrafico.Width;
                hsbBarra.Enabled = true;
            }

        }

        #endregion Métodos Privados

    }

}
