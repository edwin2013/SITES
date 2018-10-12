namespace GUILayer
{
    partial class frmGestionesTeminadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionesTeminadas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFinalizacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinalizacion = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.dgvGestiones = new System.Windows.Forms.DataGridView();
            this.gbGestiones = new System.Windows.Forms.GroupBox();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFinalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depositos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manifiestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tulas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFiltro.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestiones)).BeginInit();
            this.gbGestiones.SuspendLayout();
            this.SuspendLayout();
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
            this.gbFiltro.Size = new System.Drawing.Size(539, 75);
            this.gbFiltro.TabIndex = 1;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Gestiones";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(84, 29);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(144, 20);
            this.dtpInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(16, 33);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(62, 13);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "F. de Inicio:";
            // 
            // dtpFinalizacion
            // 
            this.dtpFinalizacion.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dtpFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinalizacion.Location = new System.Drawing.Point(284, 29);
            this.dtpFinalizacion.Name = "dtpFinalizacion";
            this.dtpFinalizacion.Size = new System.Drawing.Size(144, 20);
            this.dtpFinalizacion.TabIndex = 3;
            // 
            // lblFechaFinalizacion
            // 
            this.lblFechaFinalizacion.AutoSize = true;
            this.lblFechaFinalizacion.Location = new System.Drawing.Point(234, 33);
            this.lblFechaFinalizacion.Name = "lblFechaFinalizacion";
            this.lblFechaFinalizacion.Size = new System.Drawing.Size(44, 13);
            this.lblFechaFinalizacion.TabIndex = 2;
            this.lblFechaFinalizacion.Text = "F. Final:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(434, 19);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            this.pnlFondo.Size = new System.Drawing.Size(799, 60);
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
            // dgvGestiones
            // 
            this.dgvGestiones.AllowUserToAddRows = false;
            this.dgvGestiones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvGestiones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGestiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGestiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGestiones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGestiones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvGestiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGestiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Fecha,
            this.FechaFinalizacion,
            this.Tipo,
            this.Cliente,
            this.Clasificacion,
            this.Monto,
            this.Depositos,
            this.Manifiestos,
            this.Tulas});
            this.dgvGestiones.EnableHeadersVisualStyles = false;
            this.dgvGestiones.Location = new System.Drawing.Point(6, 19);
            this.dgvGestiones.MultiSelect = false;
            this.dgvGestiones.Name = "dgvGestiones";
            this.dgvGestiones.ReadOnly = true;
            this.dgvGestiones.RowHeadersVisible = false;
            this.dgvGestiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGestiones.Size = new System.Drawing.Size(766, 339);
            this.dgvGestiones.StandardTab = true;
            this.dgvGestiones.TabIndex = 0;
            this.dgvGestiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGestiones_CellDoubleClick);
            this.dgvGestiones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGestiones_CellFormatting);
            this.dgvGestiones.SelectionChanged += new System.EventHandler(this.dgvGestiones_SelectionChanged);
            // 
            // gbGestiones
            // 
            this.gbGestiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGestiones.Controls.Add(this.dgvGestiones);
            this.gbGestiones.Location = new System.Drawing.Point(7, 144);
            this.gbGestiones.Name = "gbGestiones";
            this.gbGestiones.Size = new System.Drawing.Size(778, 364);
            this.gbGestiones.TabIndex = 2;
            this.gbGestiones.TabStop = false;
            this.gbGestiones.Text = "Lista de Gestiones";
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.revision;
            this.btnRevisar.Location = new System.Drawing.Point(593, 514);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(90, 40);
            this.btnRevisar.TabIndex = 3;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(689, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 61;
            // 
            // FechaFinalizacion
            // 
            this.FechaFinalizacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaFinalizacion.HeaderText = "F. de Finalización";
            this.FechaFinalizacion.MinimumWidth = 124;
            this.FechaFinalizacion.Name = "FechaFinalizacion";
            this.FechaFinalizacion.ReadOnly = true;
            this.FechaFinalizacion.Width = 124;
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 52;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 63;
            // 
            // Clasificacion
            // 
            this.Clasificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Clasificacion.DataPropertyName = "Clasificacion";
            this.Clasificacion.HeaderText = "Clasificación";
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.ReadOnly = true;
            this.Clasificacion.Width = 90;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Format = "N2";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 61;
            // 
            // Depositos
            // 
            this.Depositos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Depositos.DefaultCellStyle = dataGridViewCellStyle3;
            this.Depositos.HeaderText = "Depositos";
            this.Depositos.Name = "Depositos";
            this.Depositos.ReadOnly = true;
            this.Depositos.Width = 78;
            // 
            // Manifiestos
            // 
            this.Manifiestos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Manifiestos.DefaultCellStyle = dataGridViewCellStyle4;
            this.Manifiestos.HeaderText = "Manifiestos";
            this.Manifiestos.Name = "Manifiestos";
            this.Manifiestos.ReadOnly = true;
            this.Manifiestos.Width = 84;
            // 
            // Tulas
            // 
            this.Tulas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Tulas.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tulas.HeaderText = "Tulas";
            this.Tulas.Name = "Tulas";
            this.Tulas.ReadOnly = true;
            this.Tulas.Width = 57;
            // 
            // frmGestionesTeminadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnRevisar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbGestiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGestionesTeminadas";
            this.ShowInTaskbar = false;
            this.Text = "Gestiones Terminadas";
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestiones)).EndInit();
            this.gbGestiones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFinalizacion;
        private System.Windows.Forms.Label lblFechaFinalizacion;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvGestiones;
        private System.Windows.Forms.GroupBox gbGestiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFinalizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depositos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tulas;

    }
}