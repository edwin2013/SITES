namespace GUILayer.Formularios.Facturacion
{
    partial class frmFacturacionProcesamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacionProcesamiento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoNiquel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalNiquel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(207, 61);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 11;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(270, 58);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaFin.TabIndex = 12;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(727, 621);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(835, 60);
            this.pnlFondo.TabIndex = 16;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 153);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(811, 462);
            this.gbCargas.TabIndex = 18;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Clientes";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmFecha,
            this.clmCliente,
            this.clmMontoColones,
            this.clmMontoDolares,
            this.clmMontoNiquel,
            this.clmTotalColones,
            this.clmTotalDolares,
            this.clmTotalNiquel});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(799, 437);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // clmFecha
            // 
            this.clmFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.clmFecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmFecha.HeaderText = "Fecha";
            this.clmFecha.Name = "clmFecha";
            this.clmFecha.ReadOnly = true;
            this.clmFecha.Width = 61;
            // 
            // clmCliente
            // 
            this.clmCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmCliente.DataPropertyName = "Cliente";
            this.clmCliente.HeaderText = "Cliente";
            this.clmCliente.Name = "clmCliente";
            this.clmCliente.ReadOnly = true;
            this.clmCliente.Width = 63;
            // 
            // clmMontoColones
            // 
            this.clmMontoColones.DataPropertyName = "MontoTotalColones";
            dataGridViewCellStyle3.Format = "N2";
            this.clmMontoColones.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmMontoColones.HeaderText = "Monto Colones";
            this.clmMontoColones.Name = "clmMontoColones";
            this.clmMontoColones.ReadOnly = true;
            // 
            // clmMontoDolares
            // 
            this.clmMontoDolares.DataPropertyName = "MontoTotalDolares";
            dataGridViewCellStyle4.Format = "N2";
            this.clmMontoDolares.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmMontoDolares.HeaderText = "Monto Dólares";
            this.clmMontoDolares.Name = "clmMontoDolares";
            this.clmMontoDolares.ReadOnly = true;
            // 
            // clmMontoNiquel
            // 
            this.clmMontoNiquel.DataPropertyName = "MontoTotalNiquel";
            dataGridViewCellStyle5.Format = "N2";
            this.clmMontoNiquel.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmMontoNiquel.HeaderText = "Monto Níquel";
            this.clmMontoNiquel.Name = "clmMontoNiquel";
            this.clmMontoNiquel.ReadOnly = true;
            // 
            // clmTotalColones
            // 
            this.clmTotalColones.DataPropertyName = "TarifaColones";
            dataGridViewCellStyle6.Format = "N2";
            this.clmTotalColones.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmTotalColones.HeaderText = "Total a Pagar Colones";
            this.clmTotalColones.Name = "clmTotalColones";
            this.clmTotalColones.ReadOnly = true;
            // 
            // clmTotalDolares
            // 
            this.clmTotalDolares.DataPropertyName = "TarifaDolares";
            dataGridViewCellStyle7.Format = "N2";
            this.clmTotalDolares.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmTotalDolares.HeaderText = "Total a pagar dólares";
            this.clmTotalDolares.Name = "clmTotalDolares";
            this.clmTotalDolares.ReadOnly = true;
            // 
            // clmTotalNiquel
            // 
            this.clmTotalNiquel.DataPropertyName = "TarifaNiquel";
            dataGridViewCellStyle8.Format = "N2";
            this.clmTotalNiquel.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmTotalNiquel.HeaderText = "Total a Pagar Níquel ";
            this.clmTotalNiquel.Name = "clmTotalNiquel";
            this.clmTotalNiquel.ReadOnly = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(689, 38);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(25, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(89, 59);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(15, 62);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.dtpFechaFin);
            this.gbFiltro.Controls.Add(this.lblFechaFin);
            this.gbFiltro.Controls.Add(this.cboTransportadora);
            this.gbFiltro.Controls.Add(this.lblTransportadora);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.cboCliente);
            this.gbFiltro.Controls.Add(this.lblCliente);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Location = new System.Drawing.Point(12, 48);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(810, 99);
            this.gbFiltro.TabIndex = 17;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Cargas";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(410, 21);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(245, 21);
            this.cboTransportadora.TabIndex = 10;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(322, 24);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 9;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = true;
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(71, 20);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(245, 21);
            this.cboCliente.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatAppearance.BorderSize = 2;
            this.btnImprimir.Image = global::GUILayer.Properties.Resources.excel1;
            this.btnImprimir.Location = new System.Drawing.Point(631, 621);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 40);
            this.btnImprimir.TabIndex = 22;
            this.btnImprimir.Text = "Exportar";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmFacturacionProcesamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 673);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFacturacionProcesamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación de Procesamiento";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label lblTransportadora;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoNiquel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalNiquel;
        private System.Windows.Forms.Button btnImprimir;
    }
}