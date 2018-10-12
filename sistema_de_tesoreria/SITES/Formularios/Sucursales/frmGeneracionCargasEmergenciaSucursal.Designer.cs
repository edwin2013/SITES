namespace GUILayer.Formularios.Blindados
{
    partial class frmGeneracionCargasEmergenciaSucursal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneracionCargasEmergenciaSucursal));
            this.lblCeldaATMB = new System.Windows.Forms.Label();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.lblTerceraCelda = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.lblCuartaCelda = new System.Windows.Forms.Label();
            this.lblCeldaATMA = new System.Windows.Forms.Label();
            this.lblCeldaFecha = new System.Windows.Forms.Label();
            this.lblSegundaCelda = new System.Windows.Forms.Label();
            this.lblPrimeraCelda = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRuta = new System.Windows.Forms.Label();
            this.mtbCeldaRuta = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaATMB = new System.Windows.Forms.MaskedTextBox();
            this.mtbTerceraCelda = new System.Windows.Forms.MaskedTextBox();
            this.mtbCuartaCelda = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaATMA = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaFecha = new System.Windows.Forms.MaskedTextBox();
            this.mtbSegundaCelda = new System.Windows.Forms.MaskedTextBox();
            this.mtbPrimeraCelda = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbArchivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbCargas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCeldaATMB
            // 
            this.lblCeldaATMB.AutoSize = true;
            this.lblCeldaATMB.Location = new System.Drawing.Point(161, 101);
            this.lblCeldaATMB.Name = "lblCeldaATMB";
            this.lblCeldaATMB.Size = new System.Drawing.Size(66, 13);
            this.lblCeldaATMB.TabIndex = 12;
            this.lblCeldaATMB.Text = "Emergencia:";
            // 
            // ofdMontosCargas
            // 
            this.ofdMontosCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(489, 520);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(93, 40);
            this.btnRevisar.TabIndex = 10;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // lblTerceraCelda
            // 
            this.lblTerceraCelda.AutoSize = true;
            this.lblTerceraCelda.Location = new System.Drawing.Point(147, 49);
            this.lblTerceraCelda.Name = "lblTerceraCelda";
            this.lblTerceraCelda.Size = new System.Drawing.Size(77, 13);
            this.lblTerceraCelda.TabIndex = 8;
            this.lblTerceraCelda.Text = "Tercera Celda:";
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(588, 520);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(792, 60);
            this.pnlFondo.TabIndex = 6;
            // 
            // gbArchivo
            // 
            this.gbArchivo.Controls.Add(this.lblRuta);
            this.gbArchivo.Controls.Add(this.mtbCeldaRuta);
            this.gbArchivo.Controls.Add(this.lblCeldaATMB);
            this.gbArchivo.Controls.Add(this.mtbCeldaATMB);
            this.gbArchivo.Controls.Add(this.lblTerceraCelda);
            this.gbArchivo.Controls.Add(this.lblCuartaCelda);
            this.gbArchivo.Controls.Add(this.mtbTerceraCelda);
            this.gbArchivo.Controls.Add(this.mtbCuartaCelda);
            this.gbArchivo.Controls.Add(this.lblCeldaATMA);
            this.gbArchivo.Controls.Add(this.lblCeldaFecha);
            this.gbArchivo.Controls.Add(this.mtbCeldaATMA);
            this.gbArchivo.Controls.Add(this.mtbCeldaFecha);
            this.gbArchivo.Controls.Add(this.lblSegundaCelda);
            this.gbArchivo.Controls.Add(this.lblPrimeraCelda);
            this.gbArchivo.Controls.Add(this.mtbSegundaCelda);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbPrimeraCelda);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(12, 72);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(729, 123);
            this.gbArchivo.TabIndex = 7;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // lblCuartaCelda
            // 
            this.lblCuartaCelda.AutoSize = true;
            this.lblCuartaCelda.Location = new System.Drawing.Point(153, 75);
            this.lblCuartaCelda.Name = "lblCuartaCelda";
            this.lblCuartaCelda.Size = new System.Drawing.Size(71, 13);
            this.lblCuartaCelda.TabIndex = 10;
            this.lblCuartaCelda.Text = "Cuarta Celda:";
            // 
            // lblCeldaATMA
            // 
            this.lblCeldaATMA.AutoSize = true;
            this.lblCeldaATMA.Location = new System.Drawing.Point(26, 101);
            this.lblCeldaATMA.Name = "lblCeldaATMA";
            this.lblCeldaATMA.Size = new System.Drawing.Size(66, 13);
            this.lblCeldaATMA.TabIndex = 6;
            this.lblCeldaATMA.Text = "Emergencia:";
            // 
            // lblCeldaFecha
            // 
            this.lblCeldaFecha.AutoSize = true;
            this.lblCeldaFecha.Location = new System.Drawing.Point(284, 49);
            this.lblCeldaFecha.Name = "lblCeldaFecha";
            this.lblCeldaFecha.Size = new System.Drawing.Size(70, 13);
            this.lblCeldaFecha.TabIndex = 14;
            this.lblCeldaFecha.Text = "Celda Fecha:";
            // 
            // lblSegundaCelda
            // 
            this.lblSegundaCelda.AutoSize = true;
            this.lblSegundaCelda.Location = new System.Drawing.Point(6, 75);
            this.lblSegundaCelda.Name = "lblSegundaCelda";
            this.lblSegundaCelda.Size = new System.Drawing.Size(83, 13);
            this.lblSegundaCelda.TabIndex = 4;
            this.lblSegundaCelda.Text = "Segunda Celda:";
            // 
            // lblPrimeraCelda
            // 
            this.lblPrimeraCelda.AutoSize = true;
            this.lblPrimeraCelda.Location = new System.Drawing.Point(14, 49);
            this.lblPrimeraCelda.Name = "lblPrimeraCelda";
            this.lblPrimeraCelda.Size = new System.Drawing.Size(75, 13);
            this.lblPrimeraCelda.TabIndex = 2;
            this.lblPrimeraCelda.Text = "Primera Celda:";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(360, 19);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(45, 20);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "...";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(6, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(348, 20);
            this.txtArchivo.TabIndex = 0;
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.AllowUserToOrderColumns = true;
            this.dgvCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Monto,
            this.CantidadColones,
            this.CantidadDolares,
            this.MontoColones,
            this.MontoDolares});
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.MultiSelect = false;
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCargas.Size = new System.Drawing.Size(756, 288);
            this.dgvCargas.StandardTab = true;
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellDoubleClick);
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 201);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(768, 313);
            this.gbCargas.TabIndex = 9;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Cargas";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(684, 520);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "Fecha_asignada";
            dataGridViewCellStyle1.Format = "M";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 61;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Visible = false;
            // 
            // CantidadColones
            // 
            this.CantidadColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadColones.DataPropertyName = "Cantidad_asignada_colones";
            dataGridViewCellStyle2.Format = "N0";
            this.CantidadColones.DefaultCellStyle = dataGridViewCellStyle2;
            this.CantidadColones.HeaderText = "C. en Colones";
            this.CantidadColones.Name = "CantidadColones";
            this.CantidadColones.ReadOnly = true;
            this.CantidadColones.Width = 97;
            // 
            // CantidadDolares
            // 
            this.CantidadDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadDolares.DataPropertyName = "Cantidad_asignada_dolares";
            dataGridViewCellStyle3.Format = "N0";
            this.CantidadDolares.DefaultCellStyle = dataGridViewCellStyle3;
            this.CantidadDolares.HeaderText = "C. en Dólares";
            this.CantidadDolares.Name = "CantidadDolares";
            this.CantidadDolares.ReadOnly = true;
            this.CantidadDolares.Width = 95;
            // 
            // MontoColones
            // 
            this.MontoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColones.DataPropertyName = "Monto_asignado_colones";
            dataGridViewCellStyle4.Format = "N2";
            this.MontoColones.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoColones.HeaderText = "M. en Colones";
            this.MontoColones.Name = "MontoColones";
            this.MontoColones.ReadOnly = true;
            this.MontoColones.Width = 99;
            // 
            // MontoDolares
            // 
            this.MontoDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolares.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle5.Format = "N2";
            this.MontoDolares.DefaultCellStyle = dataGridViewCellStyle5;
            this.MontoDolares.HeaderText = "M. en Dólares";
            this.MontoDolares.Name = "MontoDolares";
            this.MontoDolares.ReadOnly = true;
            this.MontoDolares.Width = 97;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(284, 78);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(63, 13);
            this.lblRuta.TabIndex = 16;
            this.lblRuta.Text = "Celda Ruta:";
            // 
            // mtbCeldaRuta
            // 
            this.mtbCeldaRuta.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalEmergenciaRuta", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaRuta.Location = new System.Drawing.Point(360, 74);
            this.mtbCeldaRuta.Mask = "aa99";
            this.mtbCeldaRuta.Name = "mtbCeldaRuta";
            this.mtbCeldaRuta.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaRuta.TabIndex = 17;
            this.mtbCeldaRuta.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalEmergenciaRuta;
            // 
            // mtbCeldaATMB
            // 
            this.mtbCeldaATMB.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalEmergenciaATMDolares", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaATMB.Location = new System.Drawing.Point(230, 97);
            this.mtbCeldaATMB.Mask = "aa99";
            this.mtbCeldaATMB.Name = "mtbCeldaATMB";
            this.mtbCeldaATMB.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaATMB.TabIndex = 13;
            this.mtbCeldaATMB.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalEmergenciaATMDolares;
            // 
            // mtbTerceraCelda
            // 
            this.mtbTerceraCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CedlaSucursalEmergenciaCeldaTDenominacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTerceraCelda.Location = new System.Drawing.Point(230, 45);
            this.mtbTerceraCelda.Mask = "aa99";
            this.mtbTerceraCelda.Name = "mtbTerceraCelda";
            this.mtbTerceraCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbTerceraCelda.TabIndex = 9;
            this.mtbTerceraCelda.Text = global::GUILayer.Properties.Settings.Default.CedlaSucursalEmergenciaCeldaTDenominacion;
            // 
            // mtbCuartaCelda
            // 
            this.mtbCuartaCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalEmergenciaCeldaCDenominacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCuartaCelda.Location = new System.Drawing.Point(230, 71);
            this.mtbCuartaCelda.Mask = "aa99";
            this.mtbCuartaCelda.Name = "mtbCuartaCelda";
            this.mtbCuartaCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbCuartaCelda.TabIndex = 11;
            this.mtbCuartaCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalEmergenciaCeldaCDenominacion;
            // 
            // mtbCeldaATMA
            // 
            this.mtbCeldaATMA.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalEmergenciaColones", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaATMA.Location = new System.Drawing.Point(95, 97);
            this.mtbCeldaATMA.Mask = "aa99";
            this.mtbCeldaATMA.Name = "mtbCeldaATMA";
            this.mtbCeldaATMA.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaATMA.TabIndex = 7;
            this.mtbCeldaATMA.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalEmergenciaColones;
            // 
            // mtbCeldaFecha
            // 
            this.mtbCeldaFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaFechaGeneracion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaFecha.Location = new System.Drawing.Point(360, 45);
            this.mtbCeldaFecha.Mask = "aa99";
            this.mtbCeldaFecha.Name = "mtbCeldaFecha";
            this.mtbCeldaFecha.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaFecha.TabIndex = 15;
            this.mtbCeldaFecha.Text = global::GUILayer.Properties.Settings.Default.CeldaFechaGeneracion;
            // 
            // mtbSegundaCelda
            // 
            this.mtbSegundaCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucucursalEmergenciaCeldaSDenominacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbSegundaCelda.Location = new System.Drawing.Point(95, 71);
            this.mtbSegundaCelda.Mask = "aa99";
            this.mtbSegundaCelda.Name = "mtbSegundaCelda";
            this.mtbSegundaCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbSegundaCelda.TabIndex = 5;
            this.mtbSegundaCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaSucucursalEmergenciaCeldaSDenominacion;
            // 
            // mtbPrimeraCelda
            // 
            this.mtbPrimeraCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucucursalEmergenciaCeldaPDenominacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbPrimeraCelda.Location = new System.Drawing.Point(95, 45);
            this.mtbPrimeraCelda.Mask = "aa99";
            this.mtbPrimeraCelda.Name = "mtbPrimeraCelda";
            this.mtbPrimeraCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbPrimeraCelda.TabIndex = 3;
            this.mtbPrimeraCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaSucucursalEmergenciaCeldaPDenominacion;
            // 
            // frmGeneracionCargasEmergenciaSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnRevisar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGeneracionCargasEmergenciaSucursal";
            this.Text = "Generación de Pedidos Emergencia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbCargas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCeldaATMB;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.MaskedTextBox mtbCeldaATMB;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.Label lblTerceraCelda;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.Label lblCuartaCelda;
        private System.Windows.Forms.MaskedTextBox mtbTerceraCelda;
        private System.Windows.Forms.MaskedTextBox mtbCuartaCelda;
        private System.Windows.Forms.Label lblCeldaATMA;
        private System.Windows.Forms.Label lblCeldaFecha;
        private System.Windows.Forms.MaskedTextBox mtbCeldaATMA;
        private System.Windows.Forms.MaskedTextBox mtbCeldaFecha;
        private System.Windows.Forms.Label lblSegundaCelda;
        private System.Windows.Forms.Label lblPrimeraCelda;
        private System.Windows.Forms.MaskedTextBox mtbSegundaCelda;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.MaskedTextBox mtbPrimeraCelda;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolares;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.MaskedTextBox mtbCeldaRuta;
    }
}