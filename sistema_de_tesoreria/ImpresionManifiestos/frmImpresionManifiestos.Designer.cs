namespace ImpresionManifiestos
{
    partial class frmImpresionManifiestos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpresionManifiestos));
            this.dgvMontos = new System.Windows.Forms.DataGridView();
            this.NumeroMarchamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bultos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.pdManifiesto = new System.Drawing.Printing.PrintDocument();
            this.gbMontos = new System.Windows.Forms.GroupBox();
            this.lblTotalBultos = new System.Windows.Forms.Label();
            this.txtTotalBultos = new System.Windows.Forms.TextBox();
            this.lblTotalMonto = new System.Windows.Forms.Label();
            this.txtTotalMonto = new System.Windows.Forms.TextBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.cboProvincias = new System.Windows.Forms.ComboBox();
            this.btnAgregarCiudad = new System.Windows.Forms.Button();
            this.btnAgregarSucursal = new System.Windows.Forms.Button();
            this.nudDepositos = new System.Windows.Forms.NumericUpDown();
            this.nudTipoCambio = new System.Windows.Forms.NumericUpDown();
            this.lblDepositos = new System.Windows.Forms.Label();
            this.lblTipoCambio = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).BeginInit();
            this.gbMontos.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepositos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTipoCambio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMontos
            // 
            this.dgvMontos.AllowUserToDeleteRows = false;
            this.dgvMontos.AllowUserToOrderColumns = true;
            this.dgvMontos.AllowUserToResizeColumns = false;
            this.dgvMontos.AllowUserToResizeRows = false;
            this.dgvMontos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroMarchamo,
            this.BT,
            this.Bultos,
            this.Monto,
            this.Cent});
            this.dgvMontos.EnableHeadersVisualStyles = false;
            this.dgvMontos.Location = new System.Drawing.Point(6, 18);
            this.dgvMontos.Name = "dgvMontos";
            this.dgvMontos.RowHeadersVisible = false;
            this.dgvMontos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMontos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontos.Size = new System.Drawing.Size(444, 287);
            this.dgvMontos.StandardTab = true;
            this.dgvMontos.TabIndex = 0;
            this.dgvMontos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMontos_CellEndEdit);
            // 
            // NumeroMarchamo
            // 
            dataGridViewCellStyle1.NullValue = "0";
            this.NumeroMarchamo.DefaultCellStyle = dataGridViewCellStyle1;
            this.NumeroMarchamo.HeaderText = "Numero de Marchamo o Bolsa";
            this.NumeroMarchamo.MinimumWidth = 180;
            this.NumeroMarchamo.Name = "NumeroMarchamo";
            this.NumeroMarchamo.Width = 180;
            // 
            // BT
            // 
            this.BT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.BT.DefaultCellStyle = dataGridViewCellStyle2;
            this.BT.HeaderText = "B/T";
            this.BT.Name = "BT";
            // 
            // Bultos
            // 
            this.Bultos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.Bultos.DefaultCellStyle = dataGridViewCellStyle3;
            this.Bultos.HeaderText = "Bultos";
            this.Bultos.Name = "Bultos";
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0,00";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle4;
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 100;
            this.Monto.Name = "Monto";
            // 
            // Cent
            // 
            this.Cent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.Cent.DefaultCellStyle = dataGridViewCellStyle5;
            this.Cent.HeaderText = "Cent";
            this.Cent.Name = "Cent";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(52, 74);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(51, 201);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(43, 13);
            this.lblCiudad.TabIndex = 11;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(43, 101);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(51, 13);
            this.lblSucursal.TabIndex = 6;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(40, 174);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(54, 13);
            this.lblProvincia.TabIndex = 9;
            this.lblProvincia.Text = "Provincia:";
            // 
            // pdManifiesto
            // 
            this.pdManifiesto.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdManifiesto_PrintPage);
            // 
            // gbMontos
            // 
            this.gbMontos.Controls.Add(this.lblTotalBultos);
            this.gbMontos.Controls.Add(this.txtTotalBultos);
            this.gbMontos.Controls.Add(this.lblTotalMonto);
            this.gbMontos.Controls.Add(this.txtTotalMonto);
            this.gbMontos.Controls.Add(this.dgvMontos);
            this.gbMontos.Location = new System.Drawing.Point(381, 12);
            this.gbMontos.Name = "gbMontos";
            this.gbMontos.Size = new System.Drawing.Size(456, 366);
            this.gbMontos.TabIndex = 1;
            this.gbMontos.TabStop = false;
            this.gbMontos.Text = "Montos";
            // 
            // lblTotalBultos
            // 
            this.lblTotalBultos.AutoSize = true;
            this.lblTotalBultos.Location = new System.Drawing.Point(232, 315);
            this.lblTotalBultos.Name = "lblTotalBultos";
            this.lblTotalBultos.Size = new System.Drawing.Size(81, 13);
            this.lblTotalBultos.TabIndex = 1;
            this.lblTotalBultos.Text = "Total de Bultos:";
            // 
            // txtTotalBultos
            // 
            this.txtTotalBultos.Location = new System.Drawing.Point(319, 312);
            this.txtTotalBultos.Name = "txtTotalBultos";
            this.txtTotalBultos.ReadOnly = true;
            this.txtTotalBultos.Size = new System.Drawing.Size(131, 20);
            this.txtTotalBultos.TabIndex = 2;
            this.txtTotalBultos.Text = "0";
            // 
            // lblTotalMonto
            // 
            this.lblTotalMonto.AutoSize = true;
            this.lblTotalMonto.Location = new System.Drawing.Point(246, 341);
            this.lblTotalMonto.Name = "lblTotalMonto";
            this.lblTotalMonto.Size = new System.Drawing.Size(67, 13);
            this.lblTotalMonto.TabIndex = 3;
            this.lblTotalMonto.Text = "Monto Total:";
            // 
            // txtTotalMonto
            // 
            this.txtTotalMonto.Location = new System.Drawing.Point(319, 338);
            this.txtTotalMonto.Name = "txtTotalMonto";
            this.txtTotalMonto.ReadOnly = true;
            this.txtTotalMonto.Size = new System.Drawing.Size(131, 20);
            this.txtTotalMonto.TabIndex = 4;
            this.txtTotalMonto.Text = "0.00";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.cboProvincias);
            this.gbDatos.Controls.Add(this.btnAgregarCiudad);
            this.gbDatos.Controls.Add(this.btnAgregarSucursal);
            this.gbDatos.Controls.Add(this.nudDepositos);
            this.gbDatos.Controls.Add(this.nudTipoCambio);
            this.gbDatos.Controls.Add(this.lblDepositos);
            this.gbDatos.Controls.Add(this.lblTipoCambio);
            this.gbDatos.Controls.Add(this.lblCliente);
            this.gbDatos.Controls.Add(this.lblCiudad);
            this.gbDatos.Controls.Add(this.lblSucursal);
            this.gbDatos.Controls.Add(this.lblProvincia);
            this.gbDatos.Location = new System.Drawing.Point(12, 12);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(363, 366);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Cliente";
            // 
            // cboProvincias
            // 
            this.cboProvincias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincias.FormattingEnabled = true;
            this.cboProvincias.Items.AddRange(new object[] {
            "Alajuela",
            "Cartago",
            "Guanacaste",
            "Heredia",
            "Limón",
            "Puntarenas",
            "San José"});
            this.cboProvincias.Location = new System.Drawing.Point(100, 171);
            this.cboProvincias.Name = "cboProvincias";
            this.cboProvincias.Size = new System.Drawing.Size(257, 21);
            this.cboProvincias.TabIndex = 10;
            this.cboProvincias.SelectedIndexChanged += new System.EventHandler(this.cboProvincias_SelectedIndexChanged);
            // 
            // btnAgregarCiudad
            // 
            this.btnAgregarCiudad.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarCiudad.FlatAppearance.BorderSize = 2;
            this.btnAgregarCiudad.Image = global::ImpresionManifiestos.Properties.Resources.agregar;
            this.btnAgregarCiudad.Location = new System.Drawing.Point(267, 225);
            this.btnAgregarCiudad.Name = "btnAgregarCiudad";
            this.btnAgregarCiudad.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarCiudad.TabIndex = 13;
            this.btnAgregarCiudad.Text = "Agregar";
            this.btnAgregarCiudad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarCiudad.UseVisualStyleBackColor = true;
            this.btnAgregarCiudad.Click += new System.EventHandler(this.btnAgregarCiudad_Click);
            // 
            // btnAgregarSucursal
            // 
            this.btnAgregarSucursal.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarSucursal.Enabled = false;
            this.btnAgregarSucursal.FlatAppearance.BorderSize = 2;
            this.btnAgregarSucursal.Image = global::ImpresionManifiestos.Properties.Resources.agregar;
            this.btnAgregarSucursal.Location = new System.Drawing.Point(267, 125);
            this.btnAgregarSucursal.Name = "btnAgregarSucursal";
            this.btnAgregarSucursal.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarSucursal.TabIndex = 8;
            this.btnAgregarSucursal.Text = "Agregar";
            this.btnAgregarSucursal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarSucursal.UseVisualStyleBackColor = true;
            this.btnAgregarSucursal.Click += new System.EventHandler(this.btnAgregarSucursal_Click);
            // 
            // nudDepositos
            // 
            this.nudDepositos.Location = new System.Drawing.Point(100, 45);
            this.nudDepositos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDepositos.Name = "nudDepositos";
            this.nudDepositos.Size = new System.Drawing.Size(120, 20);
            this.nudDepositos.TabIndex = 3;
            // 
            // nudTipoCambio
            // 
            this.nudTipoCambio.DecimalPlaces = 2;
            this.nudTipoCambio.Location = new System.Drawing.Point(100, 19);
            this.nudTipoCambio.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTipoCambio.Name = "nudTipoCambio";
            this.nudTipoCambio.Size = new System.Drawing.Size(120, 20);
            this.nudTipoCambio.TabIndex = 1;
            // 
            // lblDepositos
            // 
            this.lblDepositos.AutoSize = true;
            this.lblDepositos.Location = new System.Drawing.Point(37, 45);
            this.lblDepositos.Name = "lblDepositos";
            this.lblDepositos.Size = new System.Drawing.Size(57, 13);
            this.lblDepositos.TabIndex = 2;
            this.lblDepositos.Text = "Depositos:";
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.AutoSize = true;
            this.lblTipoCambio.Location = new System.Drawing.Point(10, 21);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(84, 13);
            this.lblTipoCambio.TabIndex = 0;
            this.lblTipoCambio.Text = "Tipo de Cambio:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::ImpresionManifiestos.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(741, 384);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::ImpresionManifiestos.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(645, 384);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 40);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmImpresionManifiestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 436);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.gbMontos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmImpresionManifiestos";
            this.Text = "Impresión de Manifiesto";
            this.Load += new System.EventHandler(this.frmImpresionManifiestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).EndInit();
            this.gbMontos.ResumeLayout(false);
            this.gbMontos.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepositos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTipoCambio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMontos;
        private System.Windows.Forms.Label lblCliente;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Drawing.Printing.PrintDocument pdManifiesto;
        private System.Windows.Forms.GroupBox gbMontos;
        private System.Windows.Forms.Label lblTotalBultos;
        private System.Windows.Forms.TextBox txtTotalBultos;
        private System.Windows.Forms.Label lblTotalMonto;
        private System.Windows.Forms.TextBox txtTotalMonto;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.NumericUpDown nudDepositos;
        private System.Windows.Forms.NumericUpDown nudTipoCambio;
        private System.Windows.Forms.Label lblDepositos;
        private System.Windows.Forms.Label lblTipoCambio;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroMarchamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bultos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cent;
        private System.Windows.Forms.Button btnAgregarSucursal;
        private ComboBoxBusqueda cboSucursal;
        private System.Windows.Forms.Button btnAgregarCiudad;
        private ComboBoxBusqueda cboCiudad;
        private System.Windows.Forms.ComboBox cboProvincias;
    }
}

