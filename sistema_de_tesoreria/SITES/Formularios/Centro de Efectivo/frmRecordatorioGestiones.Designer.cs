namespace GUILayer
{
    partial class frmRecordatorioGestiones
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecordatorioGestiones));
            this.gbGestiones = new System.Windows.Forms.GroupBox();
            this.dgvGestiones = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depositos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manifiestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tulas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.tmrCronometro = new System.Windows.Forms.Timer(this.components);
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gbGestiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestiones)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbGestiones
            // 
            this.gbGestiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGestiones.Controls.Add(this.dgvGestiones);
            this.gbGestiones.Location = new System.Drawing.Point(12, 63);
            this.gbGestiones.Name = "gbGestiones";
            this.gbGestiones.Size = new System.Drawing.Size(760, 441);
            this.gbGestiones.TabIndex = 1;
            this.gbGestiones.TabStop = false;
            this.gbGestiones.Text = "Lista de Gestiones";
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
            this.dgvGestiones.ColumnHeadersHeight = 17;
            this.dgvGestiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Fecha,
            this.FechaVencimiento,
            this.Tipo,
            this.Cliente,
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
            this.dgvGestiones.Size = new System.Drawing.Size(748, 416);
            this.dgvGestiones.StandardTab = true;
            this.dgvGestiones.TabIndex = 0;
            this.dgvGestiones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGestiones_CellFormatting);
            this.dgvGestiones.SelectionChanged += new System.EventHandler(this.dgvGestiones_SelectionChanged);
            // 
            // ID
            // 
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
            // FechaVencimiento
            // 
            this.FechaVencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaVencimiento.HeaderText = "Fecha de Vencimiento";
            this.FechaVencimiento.MinimumWidth = 140;
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.ReadOnly = true;
            this.FechaVencimiento.Width = 140;
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
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(806, 60);
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
            this.btnSalir.Location = new System.Drawing.Point(676, 510);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminar.Enabled = false;
            this.btnTerminar.FlatAppearance.BorderSize = 2;
            this.btnTerminar.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminar.Image")));
            this.btnTerminar.Location = new System.Drawing.Point(580, 510);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(90, 40);
            this.btnTerminar.TabIndex = 3;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // tmrCronometro
            // 
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Interval = 120000;
            this.tmrCronometro.Tick += new System.EventHandler(this.tmrCronometro_Tick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Enabled = false;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(480, 510);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(94, 40);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // frmRecordatorioGestiones
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbGestiones);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmRecordatorioGestiones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestiones Pendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRecordatorioGestiones_FormClosing);
            this.gbGestiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestiones)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGestiones;
        private System.Windows.Forms.DataGridView dgvGestiones;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Timer tmrCronometro;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depositos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tulas;
    }
}