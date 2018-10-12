namespace GUILayer
{
    partial class frmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.tlpPanelFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFechaInicio = new System.Windows.Forms.Panel();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.pnlFechaFin = new System.Windows.Forms.Panel();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbFiltros.SuspendLayout();
            this.tlpPanelFiltros.SuspendLayout();
            this.pnlFechaInicio.SuspendLayout();
            this.pnlFechaFin.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tlpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(843, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 58);
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltros.AutoSize = true;
            this.gbFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbFiltros.Controls.Add(this.tlpPanelFiltros);
            this.gbFiltros.Location = new System.Drawing.Point(0, 0);
            this.gbFiltros.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(819, 69);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtro";
            // 
            // tlpPanelFiltros
            // 
            this.tlpPanelFiltros.AutoSize = true;
            this.tlpPanelFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpPanelFiltros.ColumnCount = 2;
            this.tlpPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPanelFiltros.Controls.Add(this.pnlFechaInicio, 0, 0);
            this.tlpPanelFiltros.Controls.Add(this.pnlFechaFin, 1, 0);
            this.tlpPanelFiltros.Location = new System.Drawing.Point(6, 19);
            this.tlpPanelFiltros.Name = "tlpPanelFiltros";
            this.tlpPanelFiltros.RowCount = 3;
            this.tlpPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPanelFiltros.Size = new System.Drawing.Size(662, 31);
            this.tlpPanelFiltros.TabIndex = 0;
            // 
            // pnlFechaInicio
            // 
            this.pnlFechaInicio.Controls.Add(this.lblFechaInicio);
            this.pnlFechaInicio.Controls.Add(this.dtpFechaInicio);
            this.pnlFechaInicio.Location = new System.Drawing.Point(3, 3);
            this.pnlFechaInicio.Name = "pnlFechaInicio";
            this.pnlFechaInicio.Size = new System.Drawing.Size(325, 25);
            this.pnlFechaInicio.TabIndex = 0;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(15, 5);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(78, 13);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(99, 1);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(223, 21);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // pnlFechaFin
            // 
            this.pnlFechaFin.Controls.Add(this.lblFechaFinal);
            this.pnlFechaFin.Controls.Add(this.dtpFechaFin);
            this.pnlFechaFin.Location = new System.Drawing.Point(334, 3);
            this.pnlFechaFin.Name = "pnlFechaFin";
            this.pnlFechaFin.Size = new System.Drawing.Size(325, 25);
            this.pnlFechaFin.TabIndex = 1;
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinal.Location = new System.Drawing.Point(15, 5);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(63, 13);
            this.lblFechaFinal.TabIndex = 0;
            this.lblFechaFinal.Text = "Fecha fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpFechaFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpFechaFin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(99, 1);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(223, 21);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(640, 514);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(741, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGraficar
            // 
            this.btnGraficar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraficar.Enabled = false;
            this.btnGraficar.FlatAppearance.BorderSize = 2;
            this.btnGraficar.Image = global::GUILayer.Properties.Resources.graficar;
            this.btnGraficar.Location = new System.Drawing.Point(448, 514);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(90, 40);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGraficar.UseVisualStyleBackColor = false;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.Enabled = false;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(544, 514);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(90, 40);
            this.btnExportarExcel.TabIndex = 3;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.dgvDatos);
            this.gbDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDatos.Location = new System.Drawing.Point(0, 75);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(819, 368);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.Location = new System.Drawing.Point(6, 17);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(807, 345);
            this.dgvDatos.TabIndex = 0;
            // 
            // tlpDatos
            // 
            this.tlpDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDatos.ColumnCount = 1;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.Controls.Add(this.gbDatos, 0, 1);
            this.tlpDatos.Controls.Add(this.gbFiltros, 0, 0);
            this.tlpDatos.Location = new System.Drawing.Point(12, 65);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 2;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.Size = new System.Drawing.Size(819, 443);
            this.tlpDatos.TabIndex = 1;
            // 
            // frmReportes
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(843, 566);
            this.Controls.Add(this.tlpDatos);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmReportes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.tlpPanelFiltros.ResumeLayout(false);
            this.pnlFechaInicio.ResumeLayout(false);
            this.pnlFechaInicio.PerformLayout();
            this.pnlFechaFin.ResumeLayout(false);
            this.pnlFechaFin.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tlpDatos.ResumeLayout(false);
            this.tlpDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.TableLayoutPanel tlpPanelFiltros;
        private System.Windows.Forms.Panel pnlFechaInicio;
        internal System.Windows.Forms.Label lblFechaInicio;
        internal System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Panel pnlFechaFin;
        internal System.Windows.Forms.Label lblFechaFinal;
        internal System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
    }
}