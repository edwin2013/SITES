namespace GUILayer
{
    partial class frmListadoTulasNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoTulasNiquel));
            this.tcTulasImpresion = new System.Windows.Forms.TabControl();
            this.tpTulasCaja = new System.Windows.Forms.TabPage();
            this.gbTulasCaja = new System.Windows.Forms.GroupBox();
            this.lblTotalTulas = new System.Windows.Forms.Label();
            this.lblTotalManifiestos = new System.Windows.Forms.Label();
            this.txtTotalManifiestos = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtTotalTulas = new System.Windows.Forms.TextBox();
            this.dgvTulasImpresion = new System.Windows.Forms.DataGridView();
            this.gbOpcionesImpresion = new System.Windows.Forms.GroupBox();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pdDocumento = new System.Drawing.Printing.PrintDocument();
            this.gbOpcionesListado = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.cboGrupo = new GUILayer.ComboBoxBusqueda();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ManifiestoImpresionCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManifiestoImpresion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TulaImpresion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHoraIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcTulasImpresion.SuspendLayout();
            this.tpTulasCaja.SuspendLayout();
            this.gbTulasCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasImpresion)).BeginInit();
            this.gbOpcionesImpresion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbOpcionesListado.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTulasImpresion
            // 
            this.tcTulasImpresion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTulasImpresion.Controls.Add(this.tpTulasCaja);
            this.tcTulasImpresion.Location = new System.Drawing.Point(3, 131);
            this.tcTulasImpresion.Name = "tcTulasImpresion";
            this.tcTulasImpresion.SelectedIndex = 0;
            this.tcTulasImpresion.Size = new System.Drawing.Size(651, 385);
            this.tcTulasImpresion.TabIndex = 6;
            // 
            // tpTulasCaja
            // 
            this.tpTulasCaja.Controls.Add(this.gbTulasCaja);
            this.tpTulasCaja.Controls.Add(this.gbOpcionesImpresion);
            this.tpTulasCaja.Location = new System.Drawing.Point(4, 22);
            this.tpTulasCaja.Name = "tpTulasCaja";
            this.tpTulasCaja.Padding = new System.Windows.Forms.Padding(3);
            this.tpTulasCaja.Size = new System.Drawing.Size(643, 359);
            this.tpTulasCaja.TabIndex = 0;
            this.tpTulasCaja.Text = "Tulas en la Caja";
            this.tpTulasCaja.UseVisualStyleBackColor = true;
            // 
            // gbTulasCaja
            // 
            this.gbTulasCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTulasCaja.Controls.Add(this.lblTotalTulas);
            this.gbTulasCaja.Controls.Add(this.lblTotalManifiestos);
            this.gbTulasCaja.Controls.Add(this.txtTotalManifiestos);
            this.gbTulasCaja.Controls.Add(this.btnImprimir);
            this.gbTulasCaja.Controls.Add(this.txtTotalTulas);
            this.gbTulasCaja.Controls.Add(this.dgvTulasImpresion);
            this.gbTulasCaja.Location = new System.Drawing.Point(3, 58);
            this.gbTulasCaja.Name = "gbTulasCaja";
            this.gbTulasCaja.Size = new System.Drawing.Size(634, 295);
            this.gbTulasCaja.TabIndex = 1;
            this.gbTulasCaja.TabStop = false;
            this.gbTulasCaja.Text = "Lista de Tulas en la Caja";
            // 
            // lblTotalTulas
            // 
            this.lblTotalTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTulas.AutoSize = true;
            this.lblTotalTulas.Location = new System.Drawing.Point(444, 273);
            this.lblTotalTulas.Name = "lblTotalTulas";
            this.lblTotalTulas.Size = new System.Drawing.Size(78, 13);
            this.lblTotalTulas.TabIndex = 5;
            this.lblTotalTulas.Text = "Total de Tulas:";
            // 
            // lblTotalManifiestos
            // 
            this.lblTotalManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalManifiestos.AutoSize = true;
            this.lblTotalManifiestos.Location = new System.Drawing.Point(417, 247);
            this.lblTotalManifiestos.Name = "lblTotalManifiestos";
            this.lblTotalManifiestos.Size = new System.Drawing.Size(105, 13);
            this.lblTotalManifiestos.TabIndex = 3;
            this.lblTotalManifiestos.Text = "Total de Manifiestos:";
            // 
            // txtTotalManifiestos
            // 
            this.txtTotalManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalManifiestos.Location = new System.Drawing.Point(528, 243);
            this.txtTotalManifiestos.Name = "txtTotalManifiestos";
            this.txtTotalManifiestos.ReadOnly = true;
            this.txtTotalManifiestos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalManifiestos.TabIndex = 4;
            this.txtTotalManifiestos.Text = "0";
            this.txtTotalManifiestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = global::GUILayer.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(9, 249);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 40);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtTotalTulas
            // 
            this.txtTotalTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalTulas.Location = new System.Drawing.Point(528, 269);
            this.txtTotalTulas.Name = "txtTotalTulas";
            this.txtTotalTulas.ReadOnly = true;
            this.txtTotalTulas.Size = new System.Drawing.Size(100, 20);
            this.txtTotalTulas.TabIndex = 6;
            this.txtTotalTulas.Text = "0";
            this.txtTotalTulas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvTulasImpresion
            // 
            this.dgvTulasImpresion.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTulasImpresion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTulasImpresion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTulasImpresion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTulasImpresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulasImpresion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ManifiestoImpresionCodigo,
            this.ManifiestoImpresion,
            this.TulaImpresion,
            this.FechaHoraIngreso,
            this.Cliente,
            this.Receptor,
            this.Transportadora});
            this.dgvTulasImpresion.EnableHeadersVisualStyles = false;
            this.dgvTulasImpresion.Location = new System.Drawing.Point(6, 19);
            this.dgvTulasImpresion.MultiSelect = false;
            this.dgvTulasImpresion.Name = "dgvTulasImpresion";
            this.dgvTulasImpresion.RowHeadersVisible = false;
            this.dgvTulasImpresion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulasImpresion.Size = new System.Drawing.Size(622, 218);
            this.dgvTulasImpresion.TabIndex = 0;
            this.dgvTulasImpresion.SelectionChanged += new System.EventHandler(this.dgvTulasImpresion_SelectionChanged);
            // 
            // gbOpcionesImpresion
            // 
            this.gbOpcionesImpresion.Controls.Add(this.cboTransportadora);
            this.gbOpcionesImpresion.Controls.Add(this.lblTransportadora);
            this.gbOpcionesImpresion.Location = new System.Drawing.Point(3, 6);
            this.gbOpcionesImpresion.Name = "gbOpcionesImpresion";
            this.gbOpcionesImpresion.Size = new System.Drawing.Size(634, 46);
            this.gbOpcionesImpresion.TabIndex = 0;
            this.gbOpcionesImpresion.TabStop = false;
            this.gbOpcionesImpresion.Text = "Opciones de Impresión";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(93, 19);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(251, 21);
            this.cboTransportadora.TabIndex = 11;
            this.cboTransportadora.SelectedIndexChanged += new System.EventHandler(this.cboTransportadora_SelectedIndexChanged);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(5, 23);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 10;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(216, 0);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 0;
            this.lblGrupo.Text = "Grupo:";
            this.lblGrupo.Visible = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-12, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(698, 50);
            this.pnlFondo.TabIndex = 4;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(390, 44);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pdDocumento
            // 
            this.pdDocumento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdDocumento_PrintPage);
            // 
            // gbOpcionesListado
            // 
            this.gbOpcionesListado.Controls.Add(this.btnActualizar);
            this.gbOpcionesListado.Controls.Add(this.dtpFechaFinal);
            this.gbOpcionesListado.Controls.Add(this.cboGrupo);
            this.gbOpcionesListado.Controls.Add(this.lblGrupo);
            this.gbOpcionesListado.Controls.Add(this.lblFechaInicio);
            this.gbOpcionesListado.Controls.Add(this.dtpFechaInicio);
            this.gbOpcionesListado.Controls.Add(this.lblFechaFinal);
            this.gbOpcionesListado.Location = new System.Drawing.Point(3, 60);
            this.gbOpcionesListado.Name = "gbOpcionesListado";
            this.gbOpcionesListado.Size = new System.Drawing.Size(651, 65);
            this.gbOpcionesListado.TabIndex = 5;
            this.gbOpcionesListado.TabStop = false;
            this.gbOpcionesListado.Text = "Opciones de Listado";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(552, 19);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CustomFormat = "dd/MM/yy hh:mm tt";
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinal.Location = new System.Drawing.Point(357, 29);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(189, 20);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // cboGrupo
            // 
            this.cboGrupo.Busqueda = false;
            this.cboGrupo.ListaMostrada = null;
            this.cboGrupo.Location = new System.Drawing.Point(261, -4);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(213, 21);
            this.cboGrupo.TabIndex = 1;
            this.cboGrupo.Visible = false;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(6, 33);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(82, 13);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha de inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yy hh:mm tt";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(94, 29);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(189, 20);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Location = new System.Drawing.Point(289, 33);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(62, 13);
            this.lblFechaFinal.TabIndex = 2;
            this.lblFechaFinal.Text = "Fecha final:";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(554, 522);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // ManifiestoImpresionCodigo
            // 
            this.ManifiestoImpresionCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ManifiestoImpresionCodigo.HeaderText = "Manifiesto";
            this.ManifiestoImpresionCodigo.Name = "ManifiestoImpresionCodigo";
            this.ManifiestoImpresionCodigo.Visible = false;
            this.ManifiestoImpresionCodigo.Width = 60;
            // 
            // ManifiestoImpresion
            // 
            this.ManifiestoImpresion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ManifiestoImpresion.DataPropertyName = "Manifiesto";
            this.ManifiestoImpresion.HeaderText = "Manifiesto";
            this.ManifiestoImpresion.Name = "ManifiestoImpresion";
            this.ManifiestoImpresion.Width = 79;
            // 
            // TulaImpresion
            // 
            this.TulaImpresion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TulaImpresion.DataPropertyName = "Codigo";
            this.TulaImpresion.HeaderText = "Tula";
            this.TulaImpresion.Name = "TulaImpresion";
            this.TulaImpresion.ReadOnly = true;
            this.TulaImpresion.Width = 52;
            // 
            // FechaHoraIngreso
            // 
            this.FechaHoraIngreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaHoraIngreso.DataPropertyName = "Fecha_ingreso";
            this.FechaHoraIngreso.HeaderText = "Fecha y Hora de Entrega";
            this.FechaHoraIngreso.MinimumWidth = 150;
            this.FechaHoraIngreso.Name = "FechaHoraIngreso";
            this.FechaHoraIngreso.ReadOnly = true;
            this.FechaHoraIngreso.Width = 150;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Receptor
            // 
            this.Receptor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Receptor.DataPropertyName = "Receptor";
            this.Receptor.HeaderText = "Receptor";
            this.Receptor.Name = "Receptor";
            this.Receptor.ReadOnly = true;
            this.Receptor.Width = 75;
            // 
            // Transportadora
            // 
            this.Transportadora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Transportadora.DataPropertyName = "Empresa";
            this.Transportadora.HeaderText = "Transportadora";
            this.Transportadora.Name = "Transportadora";
            this.Transportadora.ReadOnly = true;
            this.Transportadora.Width = 103;
            // 
            // frmListadoTulasNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 567);
            this.Controls.Add(this.tcTulasImpresion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbOpcionesListado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListadoTulasNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Tulas";
            this.tcTulasImpresion.ResumeLayout(false);
            this.tpTulasCaja.ResumeLayout(false);
            this.gbTulasCaja.ResumeLayout(false);
            this.gbTulasCaja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasImpresion)).EndInit();
            this.gbOpcionesImpresion.ResumeLayout(false);
            this.gbOpcionesImpresion.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbOpcionesListado.ResumeLayout(false);
            this.gbOpcionesListado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcTulasImpresion;
        private System.Windows.Forms.TabPage tpTulasCaja;
        private System.Windows.Forms.GroupBox gbTulasCaja;
        private System.Windows.Forms.Label lblTotalTulas;
        private System.Windows.Forms.Label lblTotalManifiestos;
        private System.Windows.Forms.TextBox txtTotalManifiestos;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtTotalTulas;
        private System.Windows.Forms.DataGridView dgvTulasImpresion;
        private System.Windows.Forms.GroupBox gbOpcionesImpresion;
        private ComboBoxBusqueda cboGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Drawing.Printing.PrintDocument pdDocumento;
        private System.Windows.Forms.GroupBox gbOpcionesListado;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFinal;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManifiestoImpresionCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManifiestoImpresion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TulaImpresion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaHoraIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transportadora;
    }
}