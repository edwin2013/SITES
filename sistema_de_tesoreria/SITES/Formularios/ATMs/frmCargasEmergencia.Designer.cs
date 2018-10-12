namespace GUILayer
{
    partial class frmCargasEmergencia
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargasEmergencia));
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontoDisminucion = new System.Windows.Forms.TextBox();
            this.btnRevisarTablaTotal = new System.Windows.Forms.Button();
            this.checkCarga = new System.Windows.Forms.CheckBox();
            this.cboMontos = new System.Windows.Forms.ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.lblATM = new System.Windows.Forms.Label();
            this.gbMontos = new System.Windows.Forms.GroupBox();
            this.dgvRemanentes = new System.Windows.Forms.DataGridView();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.gbMontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemanentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(711, 559);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
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
            this.pnlFondo.Size = new System.Drawing.Size(935, 60);
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
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(812, 559);
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
            this.gbFiltro.Controls.Add(this.label1);
            this.gbFiltro.Controls.Add(this.txtMontoDisminucion);
            this.gbFiltro.Controls.Add(this.btnRevisarTablaTotal);
            this.gbFiltro.Controls.Add(this.checkCarga);
            this.gbFiltro.Controls.Add(this.cboMontos);
            this.gbFiltro.Controls.Add(this.lblMonto);
            this.gbFiltro.Controls.Add(this.cboTransportadora);
            this.gbFiltro.Controls.Add(this.lblTransportadora);
            this.gbFiltro.Controls.Add(this.cboATM);
            this.gbFiltro.Controls.Add(this.lblATM);
            this.gbFiltro.Controls.Add(this.lblFecha);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Location = new System.Drawing.Point(12, 58);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(919, 118);
            this.gbFiltro.TabIndex = 7;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mínimo Operacional:";
            // 
            // txtMontoDisminucion
            // 
            this.txtMontoDisminucion.Location = new System.Drawing.Point(463, 85);
            this.txtMontoDisminucion.Name = "txtMontoDisminucion";
            this.txtMontoDisminucion.Size = new System.Drawing.Size(193, 20);
            this.txtMontoDisminucion.TabIndex = 15;
            this.txtMontoDisminucion.Text = "3000000";
            this.txtMontoDisminucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoDisminucion_KeyPress);
            // 
            // btnRevisarTablaTotal
            // 
            this.btnRevisarTablaTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisarTablaTotal.Enabled = false;
            this.btnRevisarTablaTotal.FlatAppearance.BorderSize = 2;
            this.btnRevisarTablaTotal.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisarTablaTotal.Location = new System.Drawing.Point(818, 32);
            this.btnRevisarTablaTotal.Name = "btnRevisarTablaTotal";
            this.btnRevisarTablaTotal.Size = new System.Drawing.Size(93, 51);
            this.btnRevisarTablaTotal.TabIndex = 14;
            this.btnRevisarTablaTotal.Text = "Revisar Tabla Total";
            this.btnRevisarTablaTotal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisarTablaTotal.UseVisualStyleBackColor = false;
            this.btnRevisarTablaTotal.Click += new System.EventHandler(this.btnRevisarTablaTotal_Click);
            // 
            // checkCarga
            // 
            this.checkCarga.AutoSize = true;
            this.checkCarga.Checked = true;
            this.checkCarga.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCarga.Location = new System.Drawing.Point(678, 34);
            this.checkCarga.Name = "checkCarga";
            this.checkCarga.Size = new System.Drawing.Size(119, 17);
            this.checkCarga.TabIndex = 13;
            this.checkCarga.Text = "Carga Emergencia?";
            this.checkCarga.UseVisualStyleBackColor = true;
            // 
            // cboMontos
            // 
            this.cboMontos.AutoCompleteCustomSource.AddRange(new string[] {
            "5.000.000",
            "10.000.000",
            "15.000.000",
            "20.000.000"});
            this.cboMontos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMontos.FormattingEnabled = true;
            this.cboMontos.Items.AddRange(new object[] {
            "5.000.000",
            "10.000.000",
            "15.000.000",
            "20.000.000"});
            this.cboMontos.Location = new System.Drawing.Point(402, 51);
            this.cboMontos.Name = "cboMontos";
            this.cboMontos.Size = new System.Drawing.Size(254, 21);
            this.cboMontos.TabIndex = 12;
            this.cboMontos.Text = "10.000.000";
            this.cboMontos.ValueMember = "10.000.000";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(361, 54);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 11;
            this.lblMonto.Text = "Monto:";
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(6, 52);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 8;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(363, 21);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(33, 13);
            this.lblATM.TabIndex = 6;
            this.lblATM.Text = "ATM:";
            // 
            // gbMontos
            // 
            this.gbMontos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMontos.Controls.Add(this.dgvRemanentes);
            this.gbMontos.Location = new System.Drawing.Point(12, 182);
            this.gbMontos.Name = "gbMontos";
            this.gbMontos.Size = new System.Drawing.Size(893, 344);
            this.gbMontos.TabIndex = 12;
            this.gbMontos.TabStop = false;
            this.gbMontos.Text = "Montos Remanentes";
            // 
            // dgvRemanentes
            // 
            this.dgvRemanentes.AllowUserToAddRows = false;
            this.dgvRemanentes.AllowUserToDeleteRows = false;
            this.dgvRemanentes.AllowUserToOrderColumns = true;
            this.dgvRemanentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemanentes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRemanentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemanentes.EnableHeadersVisualStyles = false;
            this.dgvRemanentes.GridColor = System.Drawing.Color.Black;
            this.dgvRemanentes.Location = new System.Drawing.Point(6, 19);
            this.dgvRemanentes.Name = "dgvRemanentes";
            this.dgvRemanentes.ReadOnly = true;
            this.dgvRemanentes.RowHeadersVisible = false;
            this.dgvRemanentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRemanentes.Size = new System.Drawing.Size(881, 319);
            this.dgvRemanentes.StandardTab = true;
            this.dgvRemanentes.TabIndex = 0;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(615, 559);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(95, 40);
            this.btnExportarExcel.TabIndex = 10;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(94, 48);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(251, 21);
            this.cboTransportadora.TabIndex = 9;
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = true;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(402, 17);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(254, 21);
            this.cboATM.TabIndex = 7;
            // 
            // frmCargasEmergencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 611);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.gbMontos);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargasEmergencia";
            this.Text = "Cargas de Emergencia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCargasEmergencia_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbMontos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemanentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        internal System.Windows.Forms.Label lblFecha;
        internal System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.GroupBox gbMontos;
        private System.Windows.Forms.DataGridView dgvRemanentes;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.ComboBox cboMontos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkCarga;
        private System.Windows.Forms.Button btnRevisarTablaTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMontoDisminucion;


    }
}