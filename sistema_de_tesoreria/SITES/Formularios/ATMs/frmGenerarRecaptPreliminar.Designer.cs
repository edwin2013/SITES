namespace GUILayer.Formularios.ATMs
{
    partial class frmGenerarRecaptPreliminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarRecaptPreliminar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.dgvPedidoDolares = new System.Windows.Forms.DataGridView();
            this.clmDenominacionPedidoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoPedidoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEnvioColones = new System.Windows.Forms.DataGridView();
            this.clmDenominacionEnvioColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoEnvioColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEnvioDolares = new System.Windows.Forms.DataGridView();
            this.clmDenominacionEnvioDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoEnvioDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPedidoColones = new System.Windows.Forms.DataGridView();
            this.clmDenominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.gbTotalDescargas = new System.Windows.Forms.GroupBox();
            this.gbEnvioColones = new System.Windows.Forms.GroupBox();
            this.gbPedidosDolares = new System.Windows.Forms.GroupBox();
            this.gbPedidosColones = new System.Windows.Forms.GroupBox();
            this.btnGenear = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoDolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnvioColones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnvioDolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoColones)).BeginInit();
            this.tlpDatos.SuspendLayout();
            this.gbTotalDescargas.SuspendLayout();
            this.gbEnvioColones.SuspendLayout();
            this.gbPedidosDolares.SuspendLayout();
            this.gbPedidosColones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(556, 673);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(90, 40);
            this.btnExportarExcel.TabIndex = 19;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // dgvPedidoDolares
            // 
            this.dgvPedidoDolares.AllowUserToAddRows = false;
            this.dgvPedidoDolares.AllowUserToDeleteRows = false;
            this.dgvPedidoDolares.AllowUserToOrderColumns = true;
            this.dgvPedidoDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidoDolares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPedidoDolares.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidoDolares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedidoDolares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoDolares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDenominacionPedidoDolares,
            this.clmMontoPedidoDolares});
            this.dgvPedidoDolares.EnableHeadersVisualStyles = false;
            this.dgvPedidoDolares.GridColor = System.Drawing.Color.Black;
            this.dgvPedidoDolares.Location = new System.Drawing.Point(6, 19);
            this.dgvPedidoDolares.Name = "dgvPedidoDolares";
            this.dgvPedidoDolares.RowHeadersVisible = false;
            this.dgvPedidoDolares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPedidoDolares.Size = new System.Drawing.Size(456, 272);
            this.dgvPedidoDolares.StandardTab = true;
            this.dgvPedidoDolares.TabIndex = 0;
            this.dgvPedidoDolares.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidoDolares_CellContentClick);
            // 
            // clmDenominacionPedidoDolares
            // 
            this.clmDenominacionPedidoDolares.DataPropertyName = "Denominacion";
            this.clmDenominacionPedidoDolares.HeaderText = "Denominación";
            this.clmDenominacionPedidoDolares.Name = "clmDenominacionPedidoDolares";
            this.clmDenominacionPedidoDolares.ReadOnly = true;
            this.clmDenominacionPedidoDolares.Width = 99;
            // 
            // clmMontoPedidoDolares
            // 
            this.clmMontoPedidoDolares.DataPropertyName = "Cantidad_asignada";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.clmMontoPedidoDolares.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmMontoPedidoDolares.HeaderText = "Monto";
            this.clmMontoPedidoDolares.Name = "clmMontoPedidoDolares";
            this.clmMontoPedidoDolares.Width = 61;
            // 
            // dgvEnvioColones
            // 
            this.dgvEnvioColones.AllowUserToAddRows = false;
            this.dgvEnvioColones.AllowUserToDeleteRows = false;
            this.dgvEnvioColones.AllowUserToOrderColumns = true;
            this.dgvEnvioColones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEnvioColones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEnvioColones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEnvioColones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEnvioColones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnvioColones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDenominacionEnvioColones,
            this.clmMontoEnvioColones});
            this.dgvEnvioColones.EnableHeadersVisualStyles = false;
            this.dgvEnvioColones.GridColor = System.Drawing.Color.Black;
            this.dgvEnvioColones.Location = new System.Drawing.Point(6, 19);
            this.dgvEnvioColones.Name = "dgvEnvioColones";
            this.dgvEnvioColones.RowHeadersVisible = false;
            this.dgvEnvioColones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEnvioColones.Size = new System.Drawing.Size(455, 273);
            this.dgvEnvioColones.StandardTab = true;
            this.dgvEnvioColones.TabIndex = 0;
            // 
            // clmDenominacionEnvioColones
            // 
            this.clmDenominacionEnvioColones.DataPropertyName = "Denominacion";
            this.clmDenominacionEnvioColones.HeaderText = "Denominación";
            this.clmDenominacionEnvioColones.Name = "clmDenominacionEnvioColones";
            this.clmDenominacionEnvioColones.ReadOnly = true;
            this.clmDenominacionEnvioColones.Width = 99;
            // 
            // clmMontoEnvioColones
            // 
            this.clmMontoEnvioColones.DataPropertyName = "Cantidad_asignada";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.clmMontoEnvioColones.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmMontoEnvioColones.HeaderText = "Monto";
            this.clmMontoEnvioColones.Name = "clmMontoEnvioColones";
            this.clmMontoEnvioColones.Width = 61;
            // 
            // dgvEnvioDolares
            // 
            this.dgvEnvioDolares.AllowUserToAddRows = false;
            this.dgvEnvioDolares.AllowUserToDeleteRows = false;
            this.dgvEnvioDolares.AllowUserToOrderColumns = true;
            this.dgvEnvioDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEnvioDolares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEnvioDolares.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEnvioDolares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEnvioDolares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnvioDolares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDenominacionEnvioDolares,
            this.clmMontoEnvioDolares});
            this.dgvEnvioDolares.EnableHeadersVisualStyles = false;
            this.dgvEnvioDolares.GridColor = System.Drawing.Color.Black;
            this.dgvEnvioDolares.Location = new System.Drawing.Point(6, 19);
            this.dgvEnvioDolares.Name = "dgvEnvioDolares";
            this.dgvEnvioDolares.RowHeadersVisible = false;
            this.dgvEnvioDolares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEnvioDolares.Size = new System.Drawing.Size(456, 273);
            this.dgvEnvioDolares.StandardTab = true;
            this.dgvEnvioDolares.TabIndex = 0;
            // 
            // clmDenominacionEnvioDolares
            // 
            this.clmDenominacionEnvioDolares.DataPropertyName = "Denominacion";
            this.clmDenominacionEnvioDolares.HeaderText = "Denominación";
            this.clmDenominacionEnvioDolares.Name = "clmDenominacionEnvioDolares";
            this.clmDenominacionEnvioDolares.ReadOnly = true;
            this.clmDenominacionEnvioDolares.Width = 99;
            // 
            // clmMontoEnvioDolares
            // 
            this.clmMontoEnvioDolares.DataPropertyName = "Cantidad_asignada";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.clmMontoEnvioDolares.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmMontoEnvioDolares.HeaderText = "Monto";
            this.clmMontoEnvioDolares.Name = "clmMontoEnvioDolares";
            this.clmMontoEnvioDolares.Width = 61;
            // 
            // dgvPedidoColones
            // 
            this.dgvPedidoColones.AllowUserToAddRows = false;
            this.dgvPedidoColones.AllowUserToDeleteRows = false;
            this.dgvPedidoColones.AllowUserToOrderColumns = true;
            this.dgvPedidoColones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidoColones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPedidoColones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidoColones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPedidoColones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoColones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDenominacion,
            this.clmMonto});
            this.dgvPedidoColones.EnableHeadersVisualStyles = false;
            this.dgvPedidoColones.GridColor = System.Drawing.Color.Black;
            this.dgvPedidoColones.Location = new System.Drawing.Point(6, 19);
            this.dgvPedidoColones.Name = "dgvPedidoColones";
            this.dgvPedidoColones.RowHeadersVisible = false;
            this.dgvPedidoColones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPedidoColones.Size = new System.Drawing.Size(455, 272);
            this.dgvPedidoColones.StandardTab = true;
            this.dgvPedidoColones.TabIndex = 0;
            // 
            // clmDenominacion
            // 
            this.clmDenominacion.DataPropertyName = "Denominacion";
            this.clmDenominacion.HeaderText = "Denominación";
            this.clmDenominacion.Name = "clmDenominacion";
            this.clmDenominacion.ReadOnly = true;
            this.clmDenominacion.Width = 99;
            // 
            // clmMonto
            // 
            this.clmMonto.DataPropertyName = "Cantidad_asignada";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.clmMonto.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmMonto.HeaderText = "Monto";
            this.clmMonto.Name = "clmMonto";
            this.clmMonto.Width = 61;
            // 
            // tlpDatos
            // 
            this.tlpDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDatos.ColumnCount = 2;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.Controls.Add(this.gbTotalDescargas, 1, 1);
            this.tlpDatos.Controls.Add(this.gbEnvioColones, 0, 1);
            this.tlpDatos.Controls.Add(this.gbPedidosDolares, 1, 0);
            this.tlpDatos.Controls.Add(this.gbPedidosColones, 0, 0);
            this.tlpDatos.Location = new System.Drawing.Point(9, 66);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 2;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.Size = new System.Drawing.Size(935, 601);
            this.tlpDatos.TabIndex = 18;
            // 
            // gbTotalDescargas
            // 
            this.gbTotalDescargas.Controls.Add(this.dgvEnvioDolares);
            this.gbTotalDescargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTotalDescargas.Location = new System.Drawing.Point(467, 300);
            this.gbTotalDescargas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbTotalDescargas.Name = "gbTotalDescargas";
            this.gbTotalDescargas.Size = new System.Drawing.Size(468, 298);
            this.gbTotalDescargas.TabIndex = 5;
            this.gbTotalDescargas.TabStop = false;
            this.gbTotalDescargas.Text = "Entrega Dólares";
            // 
            // gbEnvioColones
            // 
            this.gbEnvioColones.Controls.Add(this.dgvEnvioColones);
            this.gbEnvioColones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEnvioColones.Location = new System.Drawing.Point(0, 300);
            this.gbEnvioColones.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbEnvioColones.Name = "gbEnvioColones";
            this.gbEnvioColones.Size = new System.Drawing.Size(467, 298);
            this.gbEnvioColones.TabIndex = 4;
            this.gbEnvioColones.TabStop = false;
            this.gbEnvioColones.Text = "Entrega Colones";
            // 
            // gbPedidosDolares
            // 
            this.gbPedidosDolares.Controls.Add(this.dgvPedidoDolares);
            this.gbPedidosDolares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPedidosDolares.Location = new System.Drawing.Point(467, 0);
            this.gbPedidosDolares.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbPedidosDolares.Name = "gbPedidosDolares";
            this.gbPedidosDolares.Size = new System.Drawing.Size(468, 297);
            this.gbPedidosDolares.TabIndex = 3;
            this.gbPedidosDolares.TabStop = false;
            this.gbPedidosDolares.Text = "Pedidos Dólares";
            // 
            // gbPedidosColones
            // 
            this.gbPedidosColones.Controls.Add(this.dgvPedidoColones);
            this.gbPedidosColones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPedidosColones.Location = new System.Drawing.Point(0, 0);
            this.gbPedidosColones.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbPedidosColones.Name = "gbPedidosColones";
            this.gbPedidosColones.Size = new System.Drawing.Size(467, 297);
            this.gbPedidosColones.TabIndex = 0;
            this.gbPedidosColones.TabStop = false;
            this.gbPedidosColones.Text = "Pedidos Colones";
            // 
            // btnGenear
            // 
            this.btnGenear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenear.BackColor = System.Drawing.Color.White;
            this.btnGenear.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnGenear.Location = new System.Drawing.Point(753, 673);
            this.btnGenear.Name = "btnGenear";
            this.btnGenear.Size = new System.Drawing.Size(95, 40);
            this.btnGenear.TabIndex = 16;
            this.btnGenear.Text = "Generar Recapt";
            this.btnGenear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenear.UseVisualStyleBackColor = false;
            this.btnGenear.Click += new System.EventHandler(this.btnGenear_Click);
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
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(959, 60);
            this.pnlFondo.TabIndex = 14;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(854, 673);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(652, 673);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 40);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmGenerarRecaptPreliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 723);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.tlpDatos);
            this.Controls.Add(this.btnGenear);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenerarRecaptPreliminar";
            this.Text = "Generar Recapt Preliminar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoDolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnvioColones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnvioDolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoColones)).EndInit();
            this.tlpDatos.ResumeLayout(false);
            this.gbTotalDescargas.ResumeLayout(false);
            this.gbEnvioColones.ResumeLayout(false);
            this.gbPedidosDolares.ResumeLayout(false);
            this.gbPedidosColones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.DataGridView dgvPedidoDolares;
        private System.Windows.Forms.DataGridView dgvEnvioColones;
        private System.Windows.Forms.DataGridView dgvEnvioDolares;
        private System.Windows.Forms.DataGridView dgvPedidoColones;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.GroupBox gbTotalDescargas;
        private System.Windows.Forms.GroupBox gbEnvioColones;
        private System.Windows.Forms.GroupBox gbPedidosDolares;
        private System.Windows.Forms.GroupBox gbPedidosColones;
        private System.Windows.Forms.Button btnGenear;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDenominacionEnvioColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoEnvioColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDenominacionEnvioDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoEnvioDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDenominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDenominacionPedidoDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoPedidoDolares;



    }
}