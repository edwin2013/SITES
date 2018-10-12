namespace GUILayer.Formularios.Blindados
{
    partial class frmManifiestoSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManifiestoSucursal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkRuta = new System.Windows.Forms.CheckBox();
            this.cboCanal = new GUILayer.ComboBoxBusqueda();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.nudRuta = new System.Windows.Forms.NumericUpDown();
            this.lblATM = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.btnManifiesto = new System.Windows.Forms.Button();
            this.Columna_Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignada_Colones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignada_Dolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignada_Euros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipoRemesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbCargas.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRuta
            // 
            this.chkRuta.AutoSize = true;
            this.chkRuta.Location = new System.Drawing.Point(174, 47);
            this.chkRuta.Name = "chkRuta";
            this.chkRuta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRuta.Size = new System.Drawing.Size(52, 17);
            this.chkRuta.TabIndex = 4;
            this.chkRuta.Text = "Ruta:";
            this.chkRuta.UseVisualStyleBackColor = true;
            this.chkRuta.Visible = false;
            // 
            // cboCanal
            // 
            this.cboCanal.Busqueda = true;
            this.cboCanal.ListaMostrada = null;
            this.cboCanal.Location = new System.Drawing.Point(64, 19);
            this.cboCanal.Name = "cboCanal";
            this.cboCanal.Size = new System.Drawing.Size(245, 21);
            this.cboCanal.TabIndex = 1;
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
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.chkRuta);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.nudRuta);
            this.gbFiltro.Controls.Add(this.cboCanal);
            this.gbFiltro.Controls.Add(this.lblATM);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Location = new System.Drawing.Point(12, 66);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(878, 99);
            this.gbFiltro.TabIndex = 21;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Pedidos";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(342, 38);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // nudRuta
            // 
            this.nudRuta.Enabled = false;
            this.nudRuta.Location = new System.Drawing.Point(232, 46);
            this.nudRuta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRuta.Name = "nudRuta";
            this.nudRuta.Size = new System.Drawing.Size(77, 20);
            this.nudRuta.TabIndex = 5;
            this.nudRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRuta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRuta.Visible = false;
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(7, 22);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(51, 13);
            this.lblATM.TabIndex = 0;
            this.lblATM.Text = "Sucursal:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(64, 46);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(18, 50);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(40, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha:";
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
            this.Columna_Banco,
            this.Columna_Ruta,
            this.Asignada_Colones,
            this.Asignada_Dolares,
            this.Asignada_Euros,
            this.clmTipoRemesa});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(968, 350);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(896, 552);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 25;
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
            this.pnlFondo.Size = new System.Drawing.Size(1004, 60);
            this.pnlFondo.TabIndex = 20;
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 171);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(980, 375);
            this.gbCargas.TabIndex = 22;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Cargas";
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(800, 552);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(90, 40);
            this.btnRevisar.TabIndex = 24;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // btnManifiesto
            // 
            this.btnManifiesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManifiesto.Enabled = false;
            this.btnManifiesto.FlatAppearance.BorderSize = 2;
            this.btnManifiesto.Image = global::GUILayer.Properties.Resources.reportes;
            this.btnManifiesto.Location = new System.Drawing.Point(22, 552);
            this.btnManifiesto.Name = "btnManifiesto";
            this.btnManifiesto.Size = new System.Drawing.Size(98, 40);
            this.btnManifiesto.TabIndex = 26;
            this.btnManifiesto.Text = "Manifiesto";
            this.btnManifiesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManifiesto.UseVisualStyleBackColor = false;
            this.btnManifiesto.Click += new System.EventHandler(this.btnManifiesto_Click);
            // 
            // Columna_Banco
            // 
            this.Columna_Banco.DataPropertyName = "Sucursal";
            this.Columna_Banco.HeaderText = "Sucursal";
            this.Columna_Banco.Name = "Columna_Banco";
            this.Columna_Banco.ReadOnly = true;
            // 
            // Columna_Ruta
            // 
            this.Columna_Ruta.DataPropertyName = "Ruta";
            this.Columna_Ruta.HeaderText = "Ruta";
            this.Columna_Ruta.Name = "Columna_Ruta";
            this.Columna_Ruta.ReadOnly = true;
            // 
            // Asignada_Colones
            // 
            this.Asignada_Colones.DataPropertyName = "Monto_asignado_colones";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Asignada_Colones.DefaultCellStyle = dataGridViewCellStyle2;
            this.Asignada_Colones.HeaderText = "A.Colones";
            this.Asignada_Colones.Name = "Asignada_Colones";
            this.Asignada_Colones.ReadOnly = true;
            // 
            // Asignada_Dolares
            // 
            this.Asignada_Dolares.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Asignada_Dolares.DefaultCellStyle = dataGridViewCellStyle3;
            this.Asignada_Dolares.HeaderText = "A.Dólares";
            this.Asignada_Dolares.Name = "Asignada_Dolares";
            this.Asignada_Dolares.ReadOnly = true;
            // 
            // Asignada_Euros
            // 
            this.Asignada_Euros.DataPropertyName = "Monto_asignado_euros";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Asignada_Euros.DefaultCellStyle = dataGridViewCellStyle4;
            this.Asignada_Euros.HeaderText = "A.Euros";
            this.Asignada_Euros.Name = "Asignada_Euros";
            this.Asignada_Euros.ReadOnly = true;
            // 
            // clmTipoRemesa
            // 
            this.clmTipoRemesa.DataPropertyName = "EntregaBovedaSucursal";
            this.clmTipoRemesa.HeaderText = "Tipo de Remesa";
            this.clmTipoRemesa.Name = "clmTipoRemesa";
            this.clmTipoRemesa.ReadOnly = true;
            // 
            // frmManifiestoSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 604);
            this.Controls.Add(this.btnManifiesto);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.btnRevisar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmManifiestoSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manifiesto Sucursal";
            this.Load += new System.EventHandler(this.frmManifiestoSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbCargas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRuta;
        private ComboBoxBusqueda cboCanal;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.NumericUpDown nudRuta;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.Button btnManifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignada_Colones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignada_Dolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignada_Euros;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipoRemesa;
    }
}