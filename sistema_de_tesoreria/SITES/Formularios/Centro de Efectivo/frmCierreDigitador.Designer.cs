namespace GUILayer
{
    partial class frmCierreDigitador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreDigitador));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.chkCajero = new System.Windows.Forms.CheckBox();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.cboCoordinador = new GUILayer.ComboBoxBusqueda();
            this.lblCoordinador = new System.Windows.Forms.Label();
            this.txtDigitador = new System.Windows.Forms.TextBox();
            this.lblDigitador = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gbCierre = new System.Windows.Forms.GroupBox();
            this.dgvCierre = new System.Windows.Forms.DataGridView();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tcDatos = new System.Windows.Forms.TabControl();
            this.tpCierre = new System.Windows.Forms.TabPage();
            this.tpMontosClientes = new System.Windows.Forms.TabPage();
            this.gbMontosClientes = new System.Windows.Forms.GroupBox();
            this.dgvMontosClientes = new System.Windows.Forms.DataGridView();
            this.tpManifiestos = new System.Windows.Forms.TabPage();
            this.gbManifiestos = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoEuros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatos.SuspendLayout();
            this.gbCierre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierre)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.tcDatos.SuspendLayout();
            this.tpCierre.SuspendLayout();
            this.tpMontosClientes.SuspendLayout();
            this.gbMontosClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosClientes)).BeginInit();
            this.tpManifiestos.SuspendLayout();
            this.gbManifiestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.chkCajero);
            this.gbDatos.Controls.Add(this.cboCajero);
            this.gbDatos.Controls.Add(this.cboCoordinador);
            this.gbDatos.Controls.Add(this.lblCoordinador);
            this.gbDatos.Controls.Add(this.txtDigitador);
            this.gbDatos.Controls.Add(this.lblDigitador);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(334, 126);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del cierre";
            // 
            // chkCajero
            // 
            this.chkCajero.AutoSize = true;
            this.chkCajero.Location = new System.Drawing.Point(22, 48);
            this.chkCajero.Name = "chkCajero";
            this.chkCajero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCajero.Size = new System.Drawing.Size(59, 17);
            this.chkCajero.TabIndex = 2;
            this.chkCajero.Text = "Cajero:";
            this.chkCajero.UseVisualStyleBackColor = true;
            this.chkCajero.CheckedChanged += new System.EventHandler(this.chkCajero_CheckedChanged);
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.Enabled = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(87, 46);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(241, 21);
            this.cboCajero.TabIndex = 3;
            this.cboCajero.SelectedIndexChanged += new System.EventHandler(this.cboCajero_SelectedIndexChanged);
            // 
            // cboCoordinador
            // 
            this.cboCoordinador.Busqueda = false;
            this.cboCoordinador.ListaMostrada = null;
            this.cboCoordinador.Location = new System.Drawing.Point(87, 19);
            this.cboCoordinador.Name = "cboCoordinador";
            this.cboCoordinador.Size = new System.Drawing.Size(241, 21);
            this.cboCoordinador.TabIndex = 1;
            this.cboCoordinador.SelectedIndexChanged += new System.EventHandler(this.cboCoordinador_SelectedIndexChanged);
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.AutoSize = true;
            this.lblCoordinador.Location = new System.Drawing.Point(14, 22);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(67, 13);
            this.lblCoordinador.TabIndex = 0;
            this.lblCoordinador.Text = "Coordinador:";
            // 
            // txtDigitador
            // 
            this.txtDigitador.Location = new System.Drawing.Point(87, 73);
            this.txtDigitador.Name = "txtDigitador";
            this.txtDigitador.ReadOnly = true;
            this.txtDigitador.Size = new System.Drawing.Size(241, 20);
            this.txtDigitador.TabIndex = 5;
            // 
            // lblDigitador
            // 
            this.lblDigitador.AutoSize = true;
            this.lblDigitador.Location = new System.Drawing.Point(29, 76);
            this.lblDigitador.Name = "lblDigitador";
            this.lblDigitador.Size = new System.Drawing.Size(52, 13);
            this.lblDigitador.TabIndex = 4;
            this.lblDigitador.Text = "Digitador:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(87, 99);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(241, 20);
            this.dtpFecha.TabIndex = 7;
            this.dtpFecha.CloseUp += new System.EventHandler(this.dtpFecha_CloseUp);
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            this.dtpFecha.DropDown += new System.EventHandler(this.dtpFecha_DropDown);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(41, 103);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            // 
            // gbCierre
            // 
            this.gbCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCierre.Controls.Add(this.dgvCierre);
            this.gbCierre.Location = new System.Drawing.Point(3, 6);
            this.gbCierre.Name = "gbCierre";
            this.gbCierre.Size = new System.Drawing.Size(429, 381);
            this.gbCierre.TabIndex = 0;
            this.gbCierre.TabStop = false;
            this.gbCierre.Text = "Montos del Cierre";
            // 
            // dgvCierre
            // 
            this.dgvCierre.AllowUserToAddRows = false;
            this.dgvCierre.AllowUserToDeleteRows = false;
            this.dgvCierre.AllowUserToOrderColumns = true;
            this.dgvCierre.AllowUserToResizeColumns = false;
            this.dgvCierre.AllowUserToResizeRows = false;
            this.dgvCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCierre.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCierre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Concepto,
            this.MontoColones,
            this.MontoDolares,
            this.clmMontoEuros});
            this.dgvCierre.EnableHeadersVisualStyles = false;
            this.dgvCierre.Location = new System.Drawing.Point(6, 19);
            this.dgvCierre.Name = "dgvCierre";
            this.dgvCierre.RowHeadersVisible = false;
            this.dgvCierre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCierre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCierre.Size = new System.Drawing.Size(417, 356);
            this.dgvCierre.StandardTab = true;
            this.dgvCierre.TabIndex = 0;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(536, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(358, 620);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tcDatos
            // 
            this.tcDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcDatos.Controls.Add(this.tpCierre);
            this.tcDatos.Controls.Add(this.tpMontosClientes);
            this.tcDatos.Controls.Add(this.tpManifiestos);
            this.tcDatos.Location = new System.Drawing.Point(12, 195);
            this.tcDatos.Name = "tcDatos";
            this.tcDatos.SelectedIndex = 0;
            this.tcDatos.Size = new System.Drawing.Size(446, 419);
            this.tcDatos.TabIndex = 2;
            // 
            // tpCierre
            // 
            this.tpCierre.Controls.Add(this.gbCierre);
            this.tpCierre.Location = new System.Drawing.Point(4, 22);
            this.tpCierre.Name = "tpCierre";
            this.tpCierre.Padding = new System.Windows.Forms.Padding(3);
            this.tpCierre.Size = new System.Drawing.Size(438, 393);
            this.tpCierre.TabIndex = 0;
            this.tpCierre.Text = "Cierre";
            this.tpCierre.UseVisualStyleBackColor = true;
            // 
            // tpMontosClientes
            // 
            this.tpMontosClientes.Controls.Add(this.gbMontosClientes);
            this.tpMontosClientes.Location = new System.Drawing.Point(4, 22);
            this.tpMontosClientes.Name = "tpMontosClientes";
            this.tpMontosClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tpMontosClientes.Size = new System.Drawing.Size(438, 393);
            this.tpMontosClientes.TabIndex = 1;
            this.tpMontosClientes.Text = "Montos por Cliente";
            this.tpMontosClientes.UseVisualStyleBackColor = true;
            // 
            // gbMontosClientes
            // 
            this.gbMontosClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMontosClientes.Controls.Add(this.dgvMontosClientes);
            this.gbMontosClientes.Location = new System.Drawing.Point(3, 6);
            this.gbMontosClientes.Name = "gbMontosClientes";
            this.gbMontosClientes.Size = new System.Drawing.Size(429, 381);
            this.gbMontosClientes.TabIndex = 0;
            this.gbMontosClientes.TabStop = false;
            this.gbMontosClientes.Text = "Montos por Cliente";
            // 
            // dgvMontosClientes
            // 
            this.dgvMontosClientes.AllowUserToAddRows = false;
            this.dgvMontosClientes.AllowUserToDeleteRows = false;
            this.dgvMontosClientes.AllowUserToOrderColumns = true;
            this.dgvMontosClientes.AllowUserToResizeColumns = false;
            this.dgvMontosClientes.AllowUserToResizeRows = false;
            this.dgvMontosClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMontosClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMontosClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMontosClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontosClientes.EnableHeadersVisualStyles = false;
            this.dgvMontosClientes.Location = new System.Drawing.Point(6, 19);
            this.dgvMontosClientes.Name = "dgvMontosClientes";
            this.dgvMontosClientes.RowHeadersVisible = false;
            this.dgvMontosClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMontosClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontosClientes.Size = new System.Drawing.Size(417, 356);
            this.dgvMontosClientes.StandardTab = true;
            this.dgvMontosClientes.TabIndex = 0;
            // 
            // tpManifiestos
            // 
            this.tpManifiestos.Controls.Add(this.gbManifiestos);
            this.tpManifiestos.Location = new System.Drawing.Point(4, 22);
            this.tpManifiestos.Name = "tpManifiestos";
            this.tpManifiestos.Size = new System.Drawing.Size(438, 393);
            this.tpManifiestos.TabIndex = 2;
            this.tpManifiestos.Text = "Manifiestos";
            this.tpManifiestos.UseVisualStyleBackColor = true;
            // 
            // gbManifiestos
            // 
            this.gbManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbManifiestos.Controls.Add(this.dgvManifiestos);
            this.gbManifiestos.Location = new System.Drawing.Point(3, 6);
            this.gbManifiestos.Name = "gbManifiestos";
            this.gbManifiestos.Size = new System.Drawing.Size(429, 381);
            this.gbManifiestos.TabIndex = 0;
            this.gbManifiestos.TabStop = false;
            this.gbManifiestos.Text = "Manifiestos";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToOrderColumns = true;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            this.dgvManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManifiestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 19);
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(417, 356);
            this.dgvManifiestos.StandardTab = true;
            this.dgvManifiestos.TabIndex = 0;
            // 
            // Concepto
            // 
            this.Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Concepto.DefaultCellStyle = dataGridViewCellStyle1;
            this.Concepto.FillWeight = 28.48244F;
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            this.Concepto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MontoColones
            // 
            this.MontoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            this.MontoColones.DefaultCellStyle = dataGridViewCellStyle2;
            this.MontoColones.FillWeight = 88.77644F;
            this.MontoColones.HeaderText = "Monto Colones";
            this.MontoColones.MinimumWidth = 120;
            this.MontoColones.Name = "MontoColones";
            this.MontoColones.Width = 120;
            // 
            // MontoDolares
            // 
            this.MontoDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            this.MontoDolares.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoDolares.FillWeight = 182.7411F;
            this.MontoDolares.HeaderText = "Monto Dolares";
            this.MontoDolares.MinimumWidth = 120;
            this.MontoDolares.Name = "MontoDolares";
            this.MontoDolares.Width = 120;
            // 
            // clmMontoEuros
            // 
            this.clmMontoEuros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.clmMontoEuros.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmMontoEuros.HeaderText = "Monto Euros";
            this.clmMontoEuros.Name = "clmMontoEuros";
            // 
            // frmCierreDigitador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 671);
            this.Controls.Add(this.tcDatos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCierreDigitador";
            this.ShowInTaskbar = false;
            this.Text = "Cierre";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbCierre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierre)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.tcDatos.ResumeLayout(false);
            this.tpCierre.ResumeLayout(false);
            this.tpMontosClientes.ResumeLayout(false);
            this.gbMontosClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosClientes)).EndInit();
            this.tpManifiestos.ResumeLayout(false);
            this.gbManifiestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblDigitador;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox gbCierre;
        private System.Windows.Forms.DataGridView dgvCierre;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtDigitador;
        private System.Windows.Forms.CheckBox chkCajero;
        private ComboBoxBusqueda cboCajero;
        private ComboBoxBusqueda cboCoordinador;
        private System.Windows.Forms.Label lblCoordinador;
        private System.Windows.Forms.TabControl tcDatos;
        private System.Windows.Forms.TabPage tpCierre;
        private System.Windows.Forms.TabPage tpMontosClientes;
        private System.Windows.Forms.TabPage tpManifiestos;
        private System.Windows.Forms.GroupBox gbMontosClientes;
        private System.Windows.Forms.DataGridView dgvMontosClientes;
        private System.Windows.Forms.GroupBox gbManifiestos;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoEuros;
    }
}