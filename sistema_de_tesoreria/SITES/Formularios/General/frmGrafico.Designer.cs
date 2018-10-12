namespace GUILayer
{
    partial class frmGrafico
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrafico));
            this.cboColores = new System.Windows.Forms.ComboBox();
            this.lblPaleta = new System.Windows.Forms.Label();
            this.cbMostrar3D = new System.Windows.Forms.CheckBox();
            this.gbOpcionesGrafico = new System.Windows.Forms.GroupBox();
            this.nudZoom = new System.Windows.Forms.NumericUpDown();
            this.lblZoom = new System.Windows.Forms.Label();
            this.gnGrafico = new System.Windows.Forms.GroupBox();
            this.hsbBarra = new System.Windows.Forms.HScrollBar();
            this.vsbBarra = new System.Windows.Forms.VScrollBar();
            this.pnlGrafico = new System.Windows.Forms.Panel();
            this.crtGrafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.sfdGuardar = new System.Windows.Forms.SaveFileDialog();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbOpcionesBoxPlot = new System.Windows.Forms.GroupBox();
            this.chkPromedio = new System.Windows.Forms.CheckBox();
            this.chkMedia = new System.Windows.Forms.CheckBox();
            this.chkValoresInusuales = new System.Windows.Forms.CheckBox();
            this.gbOpcionesHistograma = new System.Windows.Forms.GroupBox();
            this.cboValor = new System.Windows.Forms.ComboBox();
            this.lblValorMostrado = new System.Windows.Forms.Label();
            this.chkLineas = new System.Windows.Forms.CheckBox();
            this.gbOpcionesBarrasLineas = new System.Windows.Forms.GroupBox();
            this.chkValoresLineas = new System.Windows.Forms.CheckBox();
            this.chkValoresBarras = new System.Windows.Forms.CheckBox();
            this.gbOpcionesBarras = new System.Windows.Forms.GroupBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.chkValorBarras = new System.Windows.Forms.CheckBox();
            this.gbOpcionesPie = new System.Windows.Forms.GroupBox();
            this.chkPorcentaje = new System.Windows.Forms.CheckBox();
            this.chkValorPie = new System.Windows.Forms.CheckBox();
            this.gbOpcionesGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).BeginInit();
            this.gnGrafico.SuspendLayout();
            this.pnlGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtGrafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbOpcionesBoxPlot.SuspendLayout();
            this.gbOpcionesHistograma.SuspendLayout();
            this.gbOpcionesBarrasLineas.SuspendLayout();
            this.gbOpcionesBarras.SuspendLayout();
            this.gbOpcionesPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboColores
            // 
            this.cboColores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColores.FormattingEnabled = true;
            this.cboColores.Location = new System.Drawing.Point(124, 19);
            this.cboColores.Name = "cboColores";
            this.cboColores.Size = new System.Drawing.Size(191, 21);
            this.cboColores.TabIndex = 1;
            this.cboColores.SelectedIndexChanged += new System.EventHandler(this.cboColores_SelectedIndexChanged);
            // 
            // lblPaleta
            // 
            this.lblPaleta.AutoSize = true;
            this.lblPaleta.Location = new System.Drawing.Point(13, 22);
            this.lblPaleta.Name = "lblPaleta";
            this.lblPaleta.Size = new System.Drawing.Size(93, 13);
            this.lblPaleta.TabIndex = 0;
            this.lblPaleta.Text = "Paleta de Colores:";
            // 
            // cbMostrar3D
            // 
            this.cbMostrar3D.AutoSize = true;
            this.cbMostrar3D.Location = new System.Drawing.Point(428, 21);
            this.cbMostrar3D.Name = "cbMostrar3D";
            this.cbMostrar3D.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbMostrar3D.Size = new System.Drawing.Size(130, 17);
            this.cbMostrar3D.TabIndex = 4;
            this.cbMostrar3D.Text = "Mostrar Gráfico en 3D";
            this.cbMostrar3D.UseVisualStyleBackColor = true;
            this.cbMostrar3D.CheckedChanged += new System.EventHandler(this.cbMostrar3D_CheckedChanged);
            // 
            // gbOpcionesGrafico
            // 
            this.gbOpcionesGrafico.Controls.Add(this.cbMostrar3D);
            this.gbOpcionesGrafico.Controls.Add(this.nudZoom);
            this.gbOpcionesGrafico.Controls.Add(this.cboColores);
            this.gbOpcionesGrafico.Controls.Add(this.lblZoom);
            this.gbOpcionesGrafico.Controls.Add(this.lblPaleta);
            this.gbOpcionesGrafico.Location = new System.Drawing.Point(7, 63);
            this.gbOpcionesGrafico.Name = "gbOpcionesGrafico";
            this.gbOpcionesGrafico.Size = new System.Drawing.Size(570, 48);
            this.gbOpcionesGrafico.TabIndex = 1;
            this.gbOpcionesGrafico.TabStop = false;
            this.gbOpcionesGrafico.Text = "Opciones del Gráfico";
            // 
            // nudZoom
            // 
            this.nudZoom.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudZoom.Location = new System.Drawing.Point(364, 20);
            this.nudZoom.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudZoom.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudZoom.Name = "nudZoom";
            this.nudZoom.Size = new System.Drawing.Size(49, 20);
            this.nudZoom.TabIndex = 3;
            this.nudZoom.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudZoom.ValueChanged += new System.EventHandler(this.nudZoom_ValueChanged);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(321, 22);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(37, 13);
            this.lblZoom.TabIndex = 2;
            this.lblZoom.Text = "Zoom:";
            // 
            // gnGrafico
            // 
            this.gnGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gnGrafico.Controls.Add(this.hsbBarra);
            this.gnGrafico.Controls.Add(this.vsbBarra);
            this.gnGrafico.Controls.Add(this.pnlGrafico);
            this.gnGrafico.Location = new System.Drawing.Point(7, 117);
            this.gnGrafico.Name = "gnGrafico";
            this.gnGrafico.Size = new System.Drawing.Size(777, 391);
            this.gnGrafico.TabIndex = 2;
            this.gnGrafico.TabStop = false;
            this.gnGrafico.Text = "Gráfico";
            // 
            // hsbBarra
            // 
            this.hsbBarra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbBarra.Enabled = false;
            this.hsbBarra.Location = new System.Drawing.Point(6, 359);
            this.hsbBarra.Name = "hsbBarra";
            this.hsbBarra.Size = new System.Drawing.Size(748, 17);
            this.hsbBarra.TabIndex = 1;
            this.hsbBarra.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbBarra_Scroll);
            // 
            // vsbBarra
            // 
            this.vsbBarra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vsbBarra.Enabled = false;
            this.vsbBarra.Location = new System.Drawing.Point(754, 19);
            this.vsbBarra.Name = "vsbBarra";
            this.vsbBarra.Size = new System.Drawing.Size(17, 340);
            this.vsbBarra.TabIndex = 0;
            this.vsbBarra.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbBarra_Scroll);
            // 
            // pnlGrafico
            // 
            this.pnlGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrafico.Controls.Add(this.crtGrafico);
            this.pnlGrafico.Location = new System.Drawing.Point(6, 20);
            this.pnlGrafico.Name = "pnlGrafico";
            this.pnlGrafico.Size = new System.Drawing.Size(748, 339);
            this.pnlGrafico.TabIndex = 1;
            this.pnlGrafico.Resize += new System.EventHandler(this.pnlGrafico_Resize);
            // 
            // crtGrafico
            // 
            this.crtGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crtGrafico.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorGrid.Interval = 1D;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated90;
            chartArea1.CursorX.Interval = 2D;
            chartArea1.Name = "ChartArea1";
            this.crtGrafico.ChartAreas.Add(chartArea1);
            this.crtGrafico.ImeMode = System.Windows.Forms.ImeMode.On;
            legend1.Name = "Legend1";
            this.crtGrafico.Legends.Add(legend1);
            this.crtGrafico.Location = new System.Drawing.Point(0, 0);
            this.crtGrafico.Name = "crtGrafico";
            this.crtGrafico.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.crtGrafico.Size = new System.Drawing.Size(748, 339);
            this.crtGrafico.TabIndex = 0;
            this.crtGrafico.Text = "Gráfico";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.FlatAppearance.BorderSize = 2;
            this.btnExportar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnExportar.Location = new System.Drawing.Point(592, 514);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(90, 40);
            this.btnExportar.TabIndex = 8;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(688, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // sfdGuardar
            // 
            this.sfdGuardar.Filter = "Archivo JPG|*.jpg|Archivo BMP|*.bmp|Archivo PNG|*.png";
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.White;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(421, 57);
            this.pbLogo.TabIndex = 8;
            this.pbLogo.TabStop = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(806, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // gbOpcionesBoxPlot
            // 
            this.gbOpcionesBoxPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOpcionesBoxPlot.Controls.Add(this.chkPromedio);
            this.gbOpcionesBoxPlot.Controls.Add(this.chkMedia);
            this.gbOpcionesBoxPlot.Controls.Add(this.chkValoresInusuales);
            this.gbOpcionesBoxPlot.Location = new System.Drawing.Point(7, 514);
            this.gbOpcionesBoxPlot.Name = "gbOpcionesBoxPlot";
            this.gbOpcionesBoxPlot.Size = new System.Drawing.Size(413, 45);
            this.gbOpcionesBoxPlot.TabIndex = 5;
            this.gbOpcionesBoxPlot.TabStop = false;
            this.gbOpcionesBoxPlot.Text = "Opciones del Gráfico";
            this.gbOpcionesBoxPlot.Visible = false;
            // 
            // chkPromedio
            // 
            this.chkPromedio.AutoSize = true;
            this.chkPromedio.Checked = true;
            this.chkPromedio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPromedio.Location = new System.Drawing.Point(288, 19);
            this.chkPromedio.Name = "chkPromedio";
            this.chkPromedio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPromedio.Size = new System.Drawing.Size(108, 17);
            this.chkPromedio.TabIndex = 2;
            this.chkPromedio.Text = "Mostrar Promedio";
            this.chkPromedio.UseVisualStyleBackColor = true;
            this.chkPromedio.CheckedChanged += new System.EventHandler(this.chkPromedio_CheckedChanged);
            // 
            // chkMedia
            // 
            this.chkMedia.AutoSize = true;
            this.chkMedia.Checked = true;
            this.chkMedia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMedia.Location = new System.Drawing.Point(179, 19);
            this.chkMedia.Name = "chkMedia";
            this.chkMedia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMedia.Size = new System.Drawing.Size(93, 17);
            this.chkMedia.TabIndex = 1;
            this.chkMedia.Text = "Mostrar Media";
            this.chkMedia.UseVisualStyleBackColor = true;
            this.chkMedia.CheckedChanged += new System.EventHandler(this.chkMedia_CheckedChanged);
            // 
            // chkValoresInusuales
            // 
            this.chkValoresInusuales.AutoSize = true;
            this.chkValoresInusuales.Location = new System.Drawing.Point(16, 19);
            this.chkValoresInusuales.Name = "chkValoresInusuales";
            this.chkValoresInusuales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkValoresInusuales.Size = new System.Drawing.Size(147, 17);
            this.chkValoresInusuales.TabIndex = 0;
            this.chkValoresInusuales.Text = "Mostrar Valores Inusuales";
            this.chkValoresInusuales.UseVisualStyleBackColor = true;
            this.chkValoresInusuales.CheckedChanged += new System.EventHandler(this.chkValoresInusuales_CheckedChanged);
            // 
            // gbOpcionesHistograma
            // 
            this.gbOpcionesHistograma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOpcionesHistograma.Controls.Add(this.cboValor);
            this.gbOpcionesHistograma.Controls.Add(this.lblValorMostrado);
            this.gbOpcionesHistograma.Controls.Add(this.chkLineas);
            this.gbOpcionesHistograma.Location = new System.Drawing.Point(7, 514);
            this.gbOpcionesHistograma.Name = "gbOpcionesHistograma";
            this.gbOpcionesHistograma.Size = new System.Drawing.Size(413, 45);
            this.gbOpcionesHistograma.TabIndex = 6;
            this.gbOpcionesHistograma.TabStop = false;
            this.gbOpcionesHistograma.Text = "Opciones del Gráfico";
            this.gbOpcionesHistograma.Visible = false;
            // 
            // cboValor
            // 
            this.cboValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboValor.FormattingEnabled = true;
            this.cboValor.Items.AddRange(new object[] {
            "Porcentaje",
            "Cantidad"});
            this.cboValor.Location = new System.Drawing.Point(256, 17);
            this.cboValor.Name = "cboValor";
            this.cboValor.Size = new System.Drawing.Size(151, 21);
            this.cboValor.TabIndex = 2;
            this.cboValor.SelectedIndexChanged += new System.EventHandler(this.cboValor_SelectedIndexChanged);
            // 
            // lblValorMostrado
            // 
            this.lblValorMostrado.AutoSize = true;
            this.lblValorMostrado.Location = new System.Drawing.Point(169, 20);
            this.lblValorMostrado.Name = "lblValorMostrado";
            this.lblValorMostrado.Size = new System.Drawing.Size(81, 13);
            this.lblValorMostrado.TabIndex = 1;
            this.lblValorMostrado.Text = "Valor Mostrado:";
            // 
            // chkLineas
            // 
            this.chkLineas.AutoSize = true;
            this.chkLineas.Checked = true;
            this.chkLineas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLineas.Location = new System.Drawing.Point(16, 19);
            this.chkLineas.Name = "chkLineas";
            this.chkLineas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLineas.Size = new System.Drawing.Size(141, 17);
            this.chkLineas.TabIndex = 0;
            this.chkLineas.Text = "Mostrar líneas verticales";
            this.chkLineas.UseVisualStyleBackColor = true;
            this.chkLineas.CheckedChanged += new System.EventHandler(this.chkLineas_CheckedChanged);
            // 
            // gbOpcionesBarrasLineas
            // 
            this.gbOpcionesBarrasLineas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOpcionesBarrasLineas.Controls.Add(this.chkValoresLineas);
            this.gbOpcionesBarrasLineas.Controls.Add(this.chkValoresBarras);
            this.gbOpcionesBarrasLineas.Location = new System.Drawing.Point(7, 514);
            this.gbOpcionesBarrasLineas.Name = "gbOpcionesBarrasLineas";
            this.gbOpcionesBarrasLineas.Size = new System.Drawing.Size(413, 45);
            this.gbOpcionesBarrasLineas.TabIndex = 4;
            this.gbOpcionesBarrasLineas.TabStop = false;
            this.gbOpcionesBarrasLineas.Text = "Opciones del Gráfico";
            this.gbOpcionesBarrasLineas.Visible = false;
            // 
            // chkValoresLineas
            // 
            this.chkValoresLineas.AutoSize = true;
            this.chkValoresLineas.Location = new System.Drawing.Point(176, 19);
            this.chkValoresLineas.Name = "chkValoresLineas";
            this.chkValoresLineas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkValoresLineas.Size = new System.Drawing.Size(152, 17);
            this.chkValoresLineas.TabIndex = 1;
            this.chkValoresLineas.Text = "Mostrar valores (G. Lineas)";
            this.chkValoresLineas.UseVisualStyleBackColor = true;
            this.chkValoresLineas.CheckedChanged += new System.EventHandler(this.chkValoresLineas_CheckedChanged);
            // 
            // chkValoresBarras
            // 
            this.chkValoresBarras.AutoSize = true;
            this.chkValoresBarras.Location = new System.Drawing.Point(16, 19);
            this.chkValoresBarras.Name = "chkValoresBarras";
            this.chkValoresBarras.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkValoresBarras.Size = new System.Drawing.Size(151, 17);
            this.chkValoresBarras.TabIndex = 0;
            this.chkValoresBarras.Text = "Mostrar valores (G. Barras)";
            this.chkValoresBarras.UseVisualStyleBackColor = true;
            this.chkValoresBarras.CheckedChanged += new System.EventHandler(this.chkValoresBarras_CheckedChanged);
            // 
            // gbOpcionesBarras
            // 
            this.gbOpcionesBarras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOpcionesBarras.Controls.Add(this.lblTipo);
            this.gbOpcionesBarras.Controls.Add(this.cboTipo);
            this.gbOpcionesBarras.Controls.Add(this.chkValorBarras);
            this.gbOpcionesBarras.Location = new System.Drawing.Point(7, 514);
            this.gbOpcionesBarras.Name = "gbOpcionesBarras";
            this.gbOpcionesBarras.Size = new System.Drawing.Size(333, 45);
            this.gbOpcionesBarras.TabIndex = 3;
            this.gbOpcionesBarras.TabStop = false;
            this.gbOpcionesBarras.Text = "Opciones del Gráfico";
            this.gbOpcionesBarras.Visible = false;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(130, 20);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 9;
            this.lblTipo.Text = "Tipo:";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Columnas",
            "Barras",
            "Lineas"});
            this.cboTipo.Location = new System.Drawing.Point(169, 17);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(151, 21);
            this.cboTipo.TabIndex = 3;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // chkValorBarras
            // 
            this.chkValorBarras.AutoSize = true;
            this.chkValorBarras.Location = new System.Drawing.Point(16, 19);
            this.chkValorBarras.Name = "chkValorBarras";
            this.chkValorBarras.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkValorBarras.Size = new System.Drawing.Size(98, 17);
            this.chkValorBarras.TabIndex = 0;
            this.chkValorBarras.Text = "Mostrar valores";
            this.chkValorBarras.UseVisualStyleBackColor = true;
            this.chkValorBarras.CheckedChanged += new System.EventHandler(this.chkValorBarras_CheckedChanged);
            // 
            // gbOpcionesPie
            // 
            this.gbOpcionesPie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOpcionesPie.Controls.Add(this.chkPorcentaje);
            this.gbOpcionesPie.Controls.Add(this.chkValorPie);
            this.gbOpcionesPie.Location = new System.Drawing.Point(7, 514);
            this.gbOpcionesPie.Name = "gbOpcionesPie";
            this.gbOpcionesPie.Size = new System.Drawing.Size(413, 45);
            this.gbOpcionesPie.TabIndex = 7;
            this.gbOpcionesPie.TabStop = false;
            this.gbOpcionesPie.Text = "Opciones del Gráfico";
            this.gbOpcionesPie.Visible = false;
            // 
            // chkPorcentaje
            // 
            this.chkPorcentaje.AutoSize = true;
            this.chkPorcentaje.Location = new System.Drawing.Point(120, 19);
            this.chkPorcentaje.Name = "chkPorcentaje";
            this.chkPorcentaje.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPorcentaje.Size = new System.Drawing.Size(119, 17);
            this.chkPorcentaje.TabIndex = 1;
            this.chkPorcentaje.Text = "Mostrar porcentajes";
            this.chkPorcentaje.UseVisualStyleBackColor = true;
            this.chkPorcentaje.CheckedChanged += new System.EventHandler(this.chkPorcentaje_CheckedChanged);
            // 
            // chkValorPie
            // 
            this.chkValorPie.AutoSize = true;
            this.chkValorPie.Location = new System.Drawing.Point(16, 19);
            this.chkValorPie.Name = "chkValorPie";
            this.chkValorPie.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkValorPie.Size = new System.Drawing.Size(98, 17);
            this.chkValorPie.TabIndex = 0;
            this.chkValorPie.Text = "Mostrar valores";
            this.chkValorPie.UseVisualStyleBackColor = true;
            this.chkValorPie.CheckedChanged += new System.EventHandler(this.chkValorPie_CheckedChanged);
            // 
            // frmGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.gbOpcionesPie);
            this.Controls.Add(this.gbOpcionesBarrasLineas);
            this.Controls.Add(this.gbOpcionesBarras);
            this.Controls.Add(this.gbOpcionesHistograma);
            this.Controls.Add(this.gbOpcionesBoxPlot);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gnGrafico);
            this.Controls.Add(this.gbOpcionesGrafico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGrafico";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráficación de Reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbOpcionesGrafico.ResumeLayout(false);
            this.gbOpcionesGrafico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).EndInit();
            this.gnGrafico.ResumeLayout(false);
            this.pnlGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtGrafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbOpcionesBoxPlot.ResumeLayout(false);
            this.gbOpcionesBoxPlot.PerformLayout();
            this.gbOpcionesHistograma.ResumeLayout(false);
            this.gbOpcionesHistograma.PerformLayout();
            this.gbOpcionesBarrasLineas.ResumeLayout(false);
            this.gbOpcionesBarrasLineas.PerformLayout();
            this.gbOpcionesBarras.ResumeLayout(false);
            this.gbOpcionesBarras.PerformLayout();
            this.gbOpcionesPie.ResumeLayout(false);
            this.gbOpcionesPie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboColores;
        private System.Windows.Forms.Label lblPaleta;
        private System.Windows.Forms.CheckBox cbMostrar3D;
        private System.Windows.Forms.GroupBox gbOpcionesGrafico;
        private System.Windows.Forms.GroupBox gnGrafico;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.SaveFileDialog sfdGuardar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtGrafico;
        private System.Windows.Forms.Panel pnlGrafico;
        private System.Windows.Forms.HScrollBar hsbBarra;
        private System.Windows.Forms.VScrollBar vsbBarra;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.NumericUpDown nudZoom;
        private System.Windows.Forms.CheckBox chkPromedio;
        private System.Windows.Forms.GroupBox gbOpcionesBoxPlot;
        private System.Windows.Forms.CheckBox chkValoresInusuales;
        private System.Windows.Forms.CheckBox chkMedia;
        private System.Windows.Forms.GroupBox gbOpcionesHistograma;
        private System.Windows.Forms.CheckBox chkLineas;
        private System.Windows.Forms.ComboBox cboValor;
        private System.Windows.Forms.Label lblValorMostrado;
        private System.Windows.Forms.GroupBox gbOpcionesBarrasLineas;
        private System.Windows.Forms.CheckBox chkValoresLineas;
        private System.Windows.Forms.CheckBox chkValoresBarras;
        private System.Windows.Forms.GroupBox gbOpcionesBarras;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.CheckBox chkValorBarras;
        private System.Windows.Forms.GroupBox gbOpcionesPie;
        private System.Windows.Forms.CheckBox chkPorcentaje;
        private System.Windows.Forms.CheckBox chkValorPie;

    }
}