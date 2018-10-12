namespace GUILayer
{
    partial class frmImportaciónRemanentesATMsCompletos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportaciónRemanentesATMsCompletos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbMontos = new System.Windows.Forms.GroupBox();
            this.dgvMontos = new System.Windows.Forms.DataGridView();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaUltimaTransaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montog1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montog2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montog3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montog4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denominacion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denominacion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denominacion3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denominacion4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotalColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotalDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMontos
            // 
            this.gbMontos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMontos.Controls.Add(this.dgvMontos);
            this.gbMontos.Location = new System.Drawing.Point(12, 80);
            this.gbMontos.Name = "gbMontos";
            this.gbMontos.Size = new System.Drawing.Size(712, 442);
            this.gbMontos.TabIndex = 6;
            this.gbMontos.TabStop = false;
            this.gbMontos.Text = "Montos Remanentes";
            // 
            // dgvMontos
            // 
            this.dgvMontos.AllowUserToAddRows = false;
            this.dgvMontos.AllowUserToDeleteRows = false;
            this.dgvMontos.AllowUserToOrderColumns = true;
            this.dgvMontos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMontos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Fecha,
            this.FechaUltimaTransaccion,
            this.Localizacion,
            this.montog1,
            this.montog2,
            this.montog3,
            this.montog4,
            this.Denominacion1,
            this.Denominacion2,
            this.Denominacion3,
            this.Denominacion4,
            this.MontoTotalColones,
            this.MontoTotalDolares});
            this.dgvMontos.EnableHeadersVisualStyles = false;
            this.dgvMontos.GridColor = System.Drawing.Color.Black;
            this.dgvMontos.Location = new System.Drawing.Point(6, 19);
            this.dgvMontos.Name = "dgvMontos";
            this.dgvMontos.ReadOnly = true;
            this.dgvMontos.RowHeadersVisible = false;
            this.dgvMontos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontos.Size = new System.Drawing.Size(700, 417);
            this.dgvMontos.StandardTab = true;
            this.dgvMontos.TabIndex = 0;
            this.dgvMontos.SelectionChanged += new System.EventHandler(this.dgvMontos_SelectionChanged_1);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(736, 60);
            this.pnlFondo.TabIndex = 5;
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
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(533, 528);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(634, 528);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(432, 528);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 40);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(330, 528);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(95, 40);
            this.btnExportarExcel.TabIndex = 12;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ATM";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 54;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "FechaActual";
            dataGridViewCellStyle1.Format = "g";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 61;
            // 
            // FechaUltimaTransaccion
            // 
            this.FechaUltimaTransaccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaUltimaTransaccion.DataPropertyName = "FechaUltimaTransaccion";
            this.FechaUltimaTransaccion.HeaderText = "Fecha Ult. Trans";
            this.FechaUltimaTransaccion.Name = "FechaUltimaTransaccion";
            this.FechaUltimaTransaccion.ReadOnly = true;
            this.FechaUltimaTransaccion.Width = 77;
            // 
            // Localizacion
            // 
            this.Localizacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Localizacion.DataPropertyName = "Localizacion";
            this.Localizacion.HeaderText = "Localización";
            this.Localizacion.Name = "Localizacion";
            this.Localizacion.ReadOnly = true;
            this.Localizacion.Width = 90;
            // 
            // montog1
            // 
            this.montog1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.montog1.DataPropertyName = "Montog1";
            this.montog1.HeaderText = "Monto Gaveta 1";
            this.montog1.Name = "montog1";
            this.montog1.ReadOnly = true;
            this.montog1.Width = 91;
            // 
            // montog2
            // 
            this.montog2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.montog2.DataPropertyName = "Montog2";
            this.montog2.HeaderText = "Monto Gaveta 2";
            this.montog2.Name = "montog2";
            this.montog2.ReadOnly = true;
            this.montog2.Width = 91;
            // 
            // montog3
            // 
            this.montog3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.montog3.DataPropertyName = "Montog3";
            this.montog3.HeaderText = "Monto Gaveta 3";
            this.montog3.Name = "montog3";
            this.montog3.ReadOnly = true;
            this.montog3.Width = 91;
            // 
            // montog4
            // 
            this.montog4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.montog4.DataPropertyName = "Montog4";
            this.montog4.HeaderText = "Monto Gaveta 4";
            this.montog4.Name = "montog4";
            this.montog4.ReadOnly = true;
            this.montog4.Width = 91;
            // 
            // Denominacion1
            // 
            this.Denominacion1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Denominacion1.DataPropertyName = "Denominacion1";
            this.Denominacion1.HeaderText = "Den. Gav. 1";
            this.Denominacion1.Name = "Denominacion1";
            this.Denominacion1.ReadOnly = true;
            this.Denominacion1.Width = 74;
            // 
            // Denominacion2
            // 
            this.Denominacion2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Denominacion2.DataPropertyName = "Denominacion2";
            this.Denominacion2.HeaderText = "Den. Gav. 2";
            this.Denominacion2.Name = "Denominacion2";
            this.Denominacion2.ReadOnly = true;
            this.Denominacion2.Width = 74;
            // 
            // Denominacion3
            // 
            this.Denominacion3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Denominacion3.DataPropertyName = "Denominacion3";
            this.Denominacion3.HeaderText = "Den. Gav. 3";
            this.Denominacion3.Name = "Denominacion3";
            this.Denominacion3.ReadOnly = true;
            this.Denominacion3.Width = 74;
            // 
            // Denominacion4
            // 
            this.Denominacion4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Denominacion4.DataPropertyName = "Denominacion4";
            this.Denominacion4.HeaderText = "Den. Gav. 4";
            this.Denominacion4.Name = "Denominacion4";
            this.Denominacion4.ReadOnly = true;
            this.Denominacion4.Width = 74;
            // 
            // MontoTotalColones
            // 
            this.MontoTotalColones.DataPropertyName = "MontoTotalColones";
            this.MontoTotalColones.HeaderText = "Monto Total Colones";
            this.MontoTotalColones.Name = "MontoTotalColones";
            this.MontoTotalColones.ReadOnly = true;
            // 
            // MontoTotalDolares
            // 
            this.MontoTotalDolares.DataPropertyName = "MontoTotalDolares";
            this.MontoTotalDolares.HeaderText = "Monto Total Dolares";
            this.MontoTotalDolares.Name = "MontoTotalDolares";
            this.MontoTotalDolares.ReadOnly = true;
            // 
            // frmImportaciónRemanentesATMsCompletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 583);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.gbMontos);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportaciónRemanentesATMsCompletos";
            this.Text = "Importación Remanentes Completos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImportaciónRemanentesATMsCompletos_Load);
            this.gbMontos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbMontos;
        private System.Windows.Forms.DataGridView dgvMontos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaUltimaTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn montog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn montog2;
        private System.Windows.Forms.DataGridViewTextBoxColumn montog3;
        private System.Windows.Forms.DataGridViewTextBoxColumn montog4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotalColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotalDolares;
    }
}