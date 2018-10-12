namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmManifiestosFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManifiestosFacturacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.lbFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lbTransportadora = new System.Windows.Forms.Label();
            this.gbManifiestosProcesados = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos_Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto_Colones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto_Dolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.gbManifiestosProcesados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-7, 1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(806, 60);
            this.pnlFondo.TabIndex = 6;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.White;
            this.btnExportarExcel.Enabled = false;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(588, 514);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(90, 40);
            this.btnExportarExcel.TabIndex = 10;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(539, 98);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(26, 46);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 13;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(26, 16);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(78, 13);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha inicio:";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(684, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.cboTransportadora);
            this.gbFiltro.Controls.Add(this.lbFechaInicio);
            this.gbFiltro.Controls.Add(this.dtpFechaInicio);
            this.gbFiltro.Controls.Add(this.lbTransportadora);
            this.gbFiltro.Location = new System.Drawing.Point(12, 70);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(521, 68);
            this.gbFiltro.TabIndex = 12;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // lbFechaInicio
            // 
            this.lbFechaInicio.AutoSize = true;
            this.lbFechaInicio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaInicio.Location = new System.Drawing.Point(26, 16);
            this.lbFechaInicio.Name = "lbFechaInicio";
            this.lbFechaInicio.Size = new System.Drawing.Size(78, 13);
            this.lbFechaInicio.TabIndex = 16;
            this.lbFechaInicio.Text = "Fecha inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(110, 12);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(405, 21);
            this.dtpFechaInicio.TabIndex = 15;
            // 
            // lbTransportadora
            // 
            this.lbTransportadora.AutoSize = true;
            this.lbTransportadora.Location = new System.Drawing.Point(22, 43);
            this.lbTransportadora.Name = "lbTransportadora";
            this.lbTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lbTransportadora.TabIndex = 13;
            this.lbTransportadora.Text = "Transportadora:";
            // 
            // gbManifiestosProcesados
            // 
            this.gbManifiestosProcesados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbManifiestosProcesados.Controls.Add(this.dgvManifiestos);
            this.gbManifiestosProcesados.Location = new System.Drawing.Point(12, 145);
            this.gbManifiestosProcesados.Name = "gbManifiestosProcesados";
            this.gbManifiestosProcesados.Size = new System.Drawing.Size(768, 363);
            this.gbManifiestosProcesados.TabIndex = 14;
            this.gbManifiestosProcesados.TabStop = false;
            this.gbManifiestosProcesados.Text = "Manifiestos Procesados";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManifiestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manifiesto,
            this.FechaIngreso,
            this.Transportadora,
            this.T,
            this.Clientes,
            this.Puntos_Venta,
            this.Monto_Colones,
            this.Monto_Dolares});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 19);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(756, 338);
            this.dgvManifiestos.StandardTab = true;
            this.dgvManifiestos.TabIndex = 1;
            this.dgvManifiestos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManifiestos_CellContentClick);
            // 
            // Manifiesto
            // 
            this.Manifiesto.DataPropertyName = "codigomanifiesto";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.ReadOnly = true;
            this.Manifiesto.Width = 79;
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.DataPropertyName = "Fecha_Recepcion";
            this.FechaIngreso.HeaderText = "Fecha de Ingreso";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.ReadOnly = true;
            this.FechaIngreso.Width = 114;
            // 
            // Transportadora
            // 
            this.Transportadora.DataPropertyName = "Transportadora";
            this.Transportadora.HeaderText = "Transportadora";
            this.Transportadora.Name = "Transportadora";
            this.Transportadora.ReadOnly = true;
            this.Transportadora.Width = 103;
            // 
            // T
            // 
            this.T.DataPropertyName = "T";
            this.T.HeaderText = "T";
            this.T.Name = "T";
            this.T.ReadOnly = true;
            this.T.Width = 38;
            // 
            // Clientes
            // 
            this.Clientes.DataPropertyName = "Cliente";
            this.Clientes.HeaderText = "Cliente";
            this.Clientes.Name = "Clientes";
            this.Clientes.ReadOnly = true;
            this.Clientes.Width = 63;
            // 
            // Puntos_Venta
            // 
            this.Puntos_Venta.DataPropertyName = "Punto Venta";
            this.Puntos_Venta.HeaderText = "Punto Venta";
            this.Puntos_Venta.Name = "Puntos_Venta";
            this.Puntos_Venta.ReadOnly = true;
            this.Puntos_Venta.Width = 90;
            // 
            // Monto_Colones
            // 
            this.Monto_Colones.DataPropertyName = "M. Colones";
            this.Monto_Colones.HeaderText = "M. Colones";
            this.Monto_Colones.Name = "Monto_Colones";
            this.Monto_Colones.ReadOnly = true;
            this.Monto_Colones.Width = 84;
            // 
            // Monto_Dolares
            // 
            this.Monto_Dolares.DataPropertyName = "M. Dólares";
            this.Monto_Dolares.HeaderText = "M. Dolares";
            this.Monto_Dolares.Name = "Monto_Dolares";
            this.Monto_Dolares.ReadOnly = true;
            this.Monto_Dolares.Width = 82;
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(110, 39);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(405, 21);
            this.cboTransportadora.TabIndex = 15;
            this.cboTransportadora.SelectedIndexChanged += new System.EventHandler(this.cboTransportadora_SelectedIndexChanged);
            // 
            // frmManifiestosFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.gbManifiestosProcesados);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmManifiestosFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manifiestos Facturación";
            this.Load += new System.EventHandler(this.frmManifiestosFacturacion_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbManifiestosProcesados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnActualizar;
        internal System.Windows.Forms.Label lblFechaInicio;
      

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTransportadora;
   

        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.GroupBox gbManifiestosProcesados;
        private System.Windows.Forms.Label lbTransportadora;

        internal System.Windows.Forms.DateTimePicker dtpFechaInicio;
        internal System.Windows.Forms.Label lbFechaInicio;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntos_Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto_Colones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto_Dolares;

  
    }
}