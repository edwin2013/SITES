namespace GUILayer
{
    partial class frmGeneracionLibroMayor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneracionLibroMayor));
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.gbTotalDescargas = new System.Windows.Forms.GroupBox();
            this.dgvTotalDescargas = new System.Windows.Forms.DataGridView();
            this.gbTotalCargas = new System.Windows.Forms.GroupBox();
            this.dgvTotalCargas = new System.Windows.Forms.DataGridView();
            this.gbDescargas = new System.Windows.Forms.GroupBox();
            this.dgvDescargas = new System.Windows.Forms.DataGridView();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.tlpDatos.SuspendLayout();
            this.gbTotalDescargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalDescargas)).BeginInit();
            this.gbTotalCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalCargas)).BeginInit();
            this.gbDescargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescargas)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(753, 663);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(43, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(94, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(251, 21);
            this.dtpFecha.TabIndex = 1;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(959, 60);
            this.pnlFondo.TabIndex = 6;
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
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.lblFecha);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Location = new System.Drawing.Point(12, 85);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(929, 58);
            this.gbFiltro.TabIndex = 7;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(854, 663);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tlpDatos
            // 
            this.tlpDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDatos.ColumnCount = 2;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.Controls.Add(this.gbTotalDescargas, 1, 1);
            this.tlpDatos.Controls.Add(this.gbTotalCargas, 0, 1);
            this.tlpDatos.Controls.Add(this.gbDescargas, 1, 0);
            this.tlpDatos.Controls.Add(this.gbCargas, 0, 0);
            this.tlpDatos.Location = new System.Drawing.Point(12, 159);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 2;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.69478F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.30522F));
            this.tlpDatos.Size = new System.Drawing.Size(935, 498);
            this.tlpDatos.TabIndex = 12;
            // 
            // gbTotalDescargas
            // 
            this.gbTotalDescargas.Controls.Add(this.dgvTotalDescargas);
            this.gbTotalDescargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTotalDescargas.Location = new System.Drawing.Point(467, 366);
            this.gbTotalDescargas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbTotalDescargas.Name = "gbTotalDescargas";
            this.gbTotalDescargas.Size = new System.Drawing.Size(468, 129);
            this.gbTotalDescargas.TabIndex = 5;
            this.gbTotalDescargas.TabStop = false;
            this.gbTotalDescargas.Text = "Total Descargas";
            // 
            // dgvTotalDescargas
            // 
            this.dgvTotalDescargas.AllowUserToAddRows = false;
            this.dgvTotalDescargas.AllowUserToDeleteRows = false;
            this.dgvTotalDescargas.AllowUserToOrderColumns = true;
            this.dgvTotalDescargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTotalDescargas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTotalDescargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotalDescargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTotalDescargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalDescargas.EnableHeadersVisualStyles = false;
            this.dgvTotalDescargas.GridColor = System.Drawing.Color.Black;
            this.dgvTotalDescargas.Location = new System.Drawing.Point(6, 19);
            this.dgvTotalDescargas.Name = "dgvTotalDescargas";
            this.dgvTotalDescargas.ReadOnly = true;
            this.dgvTotalDescargas.RowHeadersVisible = false;
            this.dgvTotalDescargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTotalDescargas.Size = new System.Drawing.Size(456, 104);
            this.dgvTotalDescargas.StandardTab = true;
            this.dgvTotalDescargas.TabIndex = 0;
            // 
            // gbTotalCargas
            // 
            this.gbTotalCargas.Controls.Add(this.dgvTotalCargas);
            this.gbTotalCargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTotalCargas.Location = new System.Drawing.Point(0, 366);
            this.gbTotalCargas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbTotalCargas.Name = "gbTotalCargas";
            this.gbTotalCargas.Size = new System.Drawing.Size(467, 129);
            this.gbTotalCargas.TabIndex = 4;
            this.gbTotalCargas.TabStop = false;
            this.gbTotalCargas.Text = "Total Cargas";
            // 
            // dgvTotalCargas
            // 
            this.dgvTotalCargas.AllowUserToAddRows = false;
            this.dgvTotalCargas.AllowUserToDeleteRows = false;
            this.dgvTotalCargas.AllowUserToOrderColumns = true;
            this.dgvTotalCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTotalCargas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTotalCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotalCargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTotalCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalCargas.EnableHeadersVisualStyles = false;
            this.dgvTotalCargas.GridColor = System.Drawing.Color.Black;
            this.dgvTotalCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvTotalCargas.Name = "dgvTotalCargas";
            this.dgvTotalCargas.ReadOnly = true;
            this.dgvTotalCargas.RowHeadersVisible = false;
            this.dgvTotalCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTotalCargas.Size = new System.Drawing.Size(455, 104);
            this.dgvTotalCargas.StandardTab = true;
            this.dgvTotalCargas.TabIndex = 0;
            // 
            // gbDescargas
            // 
            this.gbDescargas.Controls.Add(this.dgvDescargas);
            this.gbDescargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDescargas.Location = new System.Drawing.Point(467, 0);
            this.gbDescargas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbDescargas.Name = "gbDescargas";
            this.gbDescargas.Size = new System.Drawing.Size(468, 363);
            this.gbDescargas.TabIndex = 3;
            this.gbDescargas.TabStop = false;
            this.gbDescargas.Text = "Descargas";
            // 
            // dgvDescargas
            // 
            this.dgvDescargas.AllowUserToAddRows = false;
            this.dgvDescargas.AllowUserToDeleteRows = false;
            this.dgvDescargas.AllowUserToOrderColumns = true;
            this.dgvDescargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDescargas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDescargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDescargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDescargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescargas.EnableHeadersVisualStyles = false;
            this.dgvDescargas.GridColor = System.Drawing.Color.Black;
            this.dgvDescargas.Location = new System.Drawing.Point(6, 19);
            this.dgvDescargas.Name = "dgvDescargas";
            this.dgvDescargas.ReadOnly = true;
            this.dgvDescargas.RowHeadersVisible = false;
            this.dgvDescargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDescargas.Size = new System.Drawing.Size(456, 338);
            this.dgvDescargas.StandardTab = true;
            this.dgvDescargas.TabIndex = 0;
            // 
            // gbCargas
            // 
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCargas.Location = new System.Drawing.Point(0, 0);
            this.gbCargas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(467, 363);
            this.gbCargas.TabIndex = 0;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Cargas";
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.AllowUserToOrderColumns = true;
            this.dgvCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCargas.Size = new System.Drawing.Size(455, 338);
            this.dgvCargas.StandardTab = true;
            this.dgvCargas.TabIndex = 0;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(657, 663);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(90, 40);
            this.btnExportarExcel.TabIndex = 13;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // frmGeneracionLibroMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 723);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.tlpDatos);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGeneracionLibroMayor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación Libro Mayor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.tlpDatos.ResumeLayout(false);
            this.gbTotalDescargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalDescargas)).EndInit();
            this.gbTotalCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalCargas)).EndInit();
            this.gbDescargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescargas)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        internal System.Windows.Forms.Label lblFecha;
        internal System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.GroupBox gbTotalDescargas;
        private System.Windows.Forms.DataGridView dgvTotalDescargas;
        private System.Windows.Forms.GroupBox gbTotalCargas;
        private System.Windows.Forms.DataGridView dgvTotalCargas;
        private System.Windows.Forms.GroupBox gbDescargas;
        private System.Windows.Forms.DataGridView dgvDescargas;
        private System.Windows.Forms.Button btnExportarExcel;

    }
}