namespace GUILayer.Formularios.Sucursales
{
    partial class frmEnvioPedidoRemesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioPedidoRemesas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblATM = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.cboTipoRemesa = new System.Windows.Forms.ComboBox();
            this.lblPortavalor = new System.Windows.Forms.Label();
            this.lblColaboradorAprueba = new System.Windows.Forms.Label();
            this.lblColaboradoAlistaRemesa = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.cboPortavalor = new GUILayer.ComboBoxBusqueda();
            this.cboColaboradorApruebaRemesa = new GUILayer.ComboBoxBusqueda();
            this.cboColaboradorAlistaRemesa = new GUILayer.ComboBoxBusqueda();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(7, 60);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(88, 13);
            this.lblATM.TabIndex = 0;
            this.lblATM.Text = "Tipo de Remesa:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(9, 23);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(83, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha de Inicio:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1048, 60);
            this.pnlFondo.TabIndex = 21;
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
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(98, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 182);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(1024, 357);
            this.gbCargas.TabIndex = 23;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Cargas";
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(1012, 332);
            this.dgvCargas.TabIndex = 0;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.cboTipoRemesa);
            this.gbFiltro.Controls.Add(this.cboPortavalor);
            this.gbFiltro.Controls.Add(this.lblPortavalor);
            this.gbFiltro.Controls.Add(this.cboColaboradorApruebaRemesa);
            this.gbFiltro.Controls.Add(this.lblColaboradorAprueba);
            this.gbFiltro.Controls.Add(this.cboColaboradorAlistaRemesa);
            this.gbFiltro.Controls.Add(this.lblColaboradoAlistaRemesa);
            this.gbFiltro.Controls.Add(this.dtpFechaFin);
            this.gbFiltro.Controls.Add(this.label1);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.lblATM);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Location = new System.Drawing.Point(12, 77);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(1024, 99);
            this.gbFiltro.TabIndex = 22;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Pedidos";
            // 
            // cboTipoRemesa
            // 
            this.cboTipoRemesa.FormattingEnabled = true;
            this.cboTipoRemesa.Items.AddRange(new object[] {
            "Todos",
            "Envío a Bóveda",
            "Pedido a Bóveda"});
            this.cboTipoRemesa.Location = new System.Drawing.Point(98, 57);
            this.cboTipoRemesa.Name = "cboTipoRemesa";
            this.cboTipoRemesa.Size = new System.Drawing.Size(169, 21);
            this.cboTipoRemesa.TabIndex = 17;
            // 
            // lblPortavalor
            // 
            this.lblPortavalor.AutoSize = true;
            this.lblPortavalor.Location = new System.Drawing.Point(517, 18);
            this.lblPortavalor.Name = "lblPortavalor";
            this.lblPortavalor.Size = new System.Drawing.Size(58, 13);
            this.lblPortavalor.TabIndex = 15;
            this.lblPortavalor.Text = "Portavalor:";
            this.lblPortavalor.Visible = false;
            // 
            // lblColaboradorAprueba
            // 
            this.lblColaboradorAprueba.Location = new System.Drawing.Point(571, 53);
            this.lblColaboradorAprueba.Name = "lblColaboradorAprueba";
            this.lblColaboradorAprueba.Size = new System.Drawing.Size(76, 33);
            this.lblColaboradorAprueba.TabIndex = 13;
            this.lblColaboradorAprueba.Text = "Colaborador que aprueba la remesa:";
            // 
            // lblColaboradoAlistaRemesa
            // 
            this.lblColaboradoAlistaRemesa.Location = new System.Drawing.Point(273, 53);
            this.lblColaboradoAlistaRemesa.Name = "lblColaboradoAlistaRemesa";
            this.lblColaboradoAlistaRemesa.Size = new System.Drawing.Size(80, 46);
            this.lblColaboradoAlistaRemesa.TabIndex = 11;
            this.lblColaboradoAlistaRemesa.Text = "Colaborador que alista la remesa:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(345, 19);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(104, 20);
            this.dtpFechaFin.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fecha de Finalización:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(916, 33);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
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
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(940, 545);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 25;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.Enabled = false;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(844, 545);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(90, 40);
            this.btnExportarExcel.TabIndex = 4;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // cboPortavalor
            // 
            this.cboPortavalor.Busqueda = true;
            this.cboPortavalor.ListaMostrada = null;
            this.cboPortavalor.Location = new System.Drawing.Point(574, 15);
            this.cboPortavalor.Name = "cboPortavalor";
            this.cboPortavalor.Size = new System.Drawing.Size(185, 21);
            this.cboPortavalor.TabIndex = 16;
            this.cboPortavalor.Visible = false;
            // 
            // cboColaboradorApruebaRemesa
            // 
            this.cboColaboradorApruebaRemesa.Busqueda = true;
            this.cboColaboradorApruebaRemesa.ListaMostrada = null;
            this.cboColaboradorApruebaRemesa.Location = new System.Drawing.Point(653, 60);
            this.cboColaboradorApruebaRemesa.Name = "cboColaboradorApruebaRemesa";
            this.cboColaboradorApruebaRemesa.Size = new System.Drawing.Size(223, 21);
            this.cboColaboradorApruebaRemesa.TabIndex = 14;
            // 
            // cboColaboradorAlistaRemesa
            // 
            this.cboColaboradorAlistaRemesa.Busqueda = true;
            this.cboColaboradorAlistaRemesa.ListaMostrada = null;
            this.cboColaboradorAlistaRemesa.Location = new System.Drawing.Point(345, 60);
            this.cboColaboradorAlistaRemesa.Name = "cboColaboradorAlistaRemesa";
            this.cboColaboradorAlistaRemesa.Size = new System.Drawing.Size(200, 21);
            this.cboColaboradorAlistaRemesa.TabIndex = 12;
            // 
            // frmEnvioPedidoRemesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 586);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEnvioPedidoRemesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envío y Pedido de Remesas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.GroupBox gbFiltro;
        private ComboBoxBusqueda cboPortavalor;
        private System.Windows.Forms.Label lblPortavalor;
        private ComboBoxBusqueda cboColaboradorApruebaRemesa;
        private System.Windows.Forms.Label lblColaboradorAprueba;
        private ComboBoxBusqueda cboColaboradorAlistaRemesa;
        private System.Windows.Forms.Label lblColaboradoAlistaRemesa;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.ComboBox cboTipoRemesa;
    }
}