namespace GUILayer
{
    partial class frmAdministracionInconsistenciasDigitadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionInconsistenciasDigitadores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFinalizacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinalizacion = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gbInconsistencias = new System.Windows.Forms.GroupBox();
            this.dgvInconsistencias = new System.Windows.Forms.DataGridView();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDigitador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Digitador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoordinadorDigitador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositoDigitador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenciaErronea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoErroneo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaErronea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonedaErronea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFiltro.SuspendLayout();
            this.gbInconsistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInconsistencias)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNueva
            // 
            this.btnNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNueva.FlatAppearance.BorderSize = 2;
            this.btnNueva.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNueva.Location = new System.Drawing.Point(408, 514);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(90, 40);
            this.btnNueva.TabIndex = 3;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNueva.UseVisualStyleBackColor = false;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(600, 514);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(504, 514);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.dtpInicio);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Controls.Add(this.dtpFinalizacion);
            this.gbFiltro.Controls.Add(this.lblFechaFinalizacion);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Location = new System.Drawing.Point(7, 63);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(623, 72);
            this.gbFiltro.TabIndex = 1;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Inconsistencias";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(106, 29);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(142, 20);
            this.dtpInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(17, 33);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(83, 13);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha de Inicio:";
            // 
            // dtpFinalizacion
            // 
            this.dtpFinalizacion.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dtpFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinalizacion.Location = new System.Drawing.Point(373, 29);
            this.dtpFinalizacion.Name = "dtpFinalizacion";
            this.dtpFinalizacion.Size = new System.Drawing.Size(142, 20);
            this.dtpFinalizacion.TabIndex = 3;
            // 
            // lblFechaFinalizacion
            // 
            this.lblFechaFinalizacion.AutoSize = true;
            this.lblFechaFinalizacion.Location = new System.Drawing.Point(254, 33);
            this.lblFechaFinalizacion.Name = "lblFechaFinalizacion";
            this.lblFechaFinalizacion.Size = new System.Drawing.Size(113, 13);
            this.lblFechaFinalizacion.TabIndex = 2;
            this.lblFechaFinalizacion.Text = "Fecha de Finalización:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(521, 19);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // gbInconsistencias
            // 
            this.gbInconsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInconsistencias.Controls.Add(this.dgvInconsistencias);
            this.gbInconsistencias.Location = new System.Drawing.Point(7, 141);
            this.gbInconsistencias.Name = "gbInconsistencias";
            this.gbInconsistencias.Size = new System.Drawing.Size(779, 367);
            this.gbInconsistencias.TabIndex = 2;
            this.gbInconsistencias.TabStop = false;
            this.gbInconsistencias.Text = "Lista de Inconsistencias de Digitadores";
            // 
            // dgvInconsistencias
            // 
            this.dgvInconsistencias.AllowUserToAddRows = false;
            this.dgvInconsistencias.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvInconsistencias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInconsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInconsistencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInconsistencias.ColumnHeadersHeight = 17;
            this.dgvInconsistencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cliente,
            this.Sucursal,
            this.FechaDigitador,
            this.Digitador,
            this.T,
            this.CoordinadorDigitador,
            this.DepositoDigitador,
            this.ReferenciaErronea,
            this.MontoErroneo,
            this.CuentaErronea,
            this.MonedaErronea,
            this.ROE});
            this.dgvInconsistencias.EnableHeadersVisualStyles = false;
            this.dgvInconsistencias.Location = new System.Drawing.Point(6, 19);
            this.dgvInconsistencias.MultiSelect = false;
            this.dgvInconsistencias.Name = "dgvInconsistencias";
            this.dgvInconsistencias.ReadOnly = true;
            this.dgvInconsistencias.RowHeadersVisible = false;
            this.dgvInconsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInconsistencias.Size = new System.Drawing.Size(767, 342);
            this.dgvInconsistencias.StandardTab = true;
            this.dgvInconsistencias.TabIndex = 0;
            this.dgvInconsistencias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInconsistencias_CellDoubleClick);
            this.dgvInconsistencias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInconsistencias_CellFormatting);
            this.dgvInconsistencias.SelectionChanged += new System.EventHandler(this.dgvInconsistencias_SelectionChanged);
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-4, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(807, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
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
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(696, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Sucursal
            // 
            this.Sucursal.DataPropertyName = "Sucursal";
            this.Sucursal.HeaderText = "Sucursal";
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.ReadOnly = true;
            // 
            // FechaDigitador
            // 
            this.FechaDigitador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaDigitador.DataPropertyName = "Fecha";
            this.FechaDigitador.HeaderText = "Fecha";
            this.FechaDigitador.Name = "FechaDigitador";
            this.FechaDigitador.ReadOnly = true;
            this.FechaDigitador.Width = 61;
            // 
            // Digitador
            // 
            this.Digitador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Digitador.DataPropertyName = "Digitador";
            this.Digitador.HeaderText = "Digitador";
            this.Digitador.Name = "Digitador";
            this.Digitador.ReadOnly = true;
            this.Digitador.Width = 73;
            // 
            // T
            // 
            this.T.DataPropertyName = "T";
            this.T.HeaderText = "T";
            this.T.Name = "T";
            this.T.ReadOnly = true;
            // 
            // CoordinadorDigitador
            // 
            this.CoordinadorDigitador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CoordinadorDigitador.DataPropertyName = "Coordinador";
            this.CoordinadorDigitador.HeaderText = "Coordinador";
            this.CoordinadorDigitador.Name = "CoordinadorDigitador";
            this.CoordinadorDigitador.ReadOnly = true;
            this.CoordinadorDigitador.Width = 88;
            // 
            // DepositoDigitador
            // 
            this.DepositoDigitador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DepositoDigitador.DataPropertyName = "Deposito";
            this.DepositoDigitador.HeaderText = "Deposito";
            this.DepositoDigitador.Name = "DepositoDigitador";
            this.DepositoDigitador.ReadOnly = true;
            this.DepositoDigitador.Width = 73;
            // 
            // ReferenciaErronea
            // 
            this.ReferenciaErronea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ReferenciaErronea.DataPropertyName = "Referencia_erronea";
            this.ReferenciaErronea.HeaderText = "Referencia Errónea";
            this.ReferenciaErronea.Name = "ReferenciaErronea";
            this.ReferenciaErronea.ReadOnly = true;
            this.ReferenciaErronea.Width = 123;
            // 
            // MontoErroneo
            // 
            this.MontoErroneo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoErroneo.DataPropertyName = "Monto_erroneo";
            dataGridViewCellStyle2.Format = "N2";
            this.MontoErroneo.DefaultCellStyle = dataGridViewCellStyle2;
            this.MontoErroneo.HeaderText = "Monto Erróneo";
            this.MontoErroneo.Name = "MontoErroneo";
            this.MontoErroneo.ReadOnly = true;
            this.MontoErroneo.Width = 101;
            // 
            // CuentaErronea
            // 
            this.CuentaErronea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CuentaErronea.DataPropertyName = "Cuenta_erronea";
            this.CuentaErronea.HeaderText = "Cuenta Errónea";
            this.CuentaErronea.Name = "CuentaErronea";
            this.CuentaErronea.ReadOnly = true;
            this.CuentaErronea.Width = 105;
            // 
            // MonedaErronea
            // 
            this.MonedaErronea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MonedaErronea.HeaderText = "Moneda Errónea";
            this.MonedaErronea.Name = "MonedaErronea";
            this.MonedaErronea.ReadOnly = true;
            this.MonedaErronea.Width = 110;
            // 
            // ROE
            // 
            this.ROE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ROE.HeaderText = "ROE";
            this.ROE.Name = "ROE";
            this.ROE.ReadOnly = true;
            this.ROE.Width = 54;
            // 
            // frmAdministracionInconsistenciasDigitadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.gbInconsistencias);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionInconsistenciasDigitadores";
            this.ShowInTaskbar = false;
            this.Text = "Adminisración de Inconsistencias de Digitadores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbInconsistencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInconsistencias)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFinalizacion;
        private System.Windows.Forms.Label lblFechaFinalizacion;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbInconsistencias;
        private System.Windows.Forms.DataGridView dgvInconsistencias;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDigitador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Digitador;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoordinadorDigitador;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositoDigitador;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenciaErronea;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoErroneo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaErronea;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonedaErronea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROE;
    }
}