namespace GUILayer.Formularios.ATMs
{
    partial class frmReporteRecepcionCartuchos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteRecepcionCartuchos));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvRecepcion = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.gbResumen = new System.Windows.Forms.GroupBox();
            this.dgvResumen = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cboProveedor = new GUILayer.ComboBoxBusqueda();
            this.cboResponsableRegistro = new GUILayer.ComboBoxBusqueda();
            this.cboResponsableEntrega = new GUILayer.ComboBoxBusqueda();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecepcion)).BeginInit();
            this.gbResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(997, 60);
            this.pnlFondo.TabIndex = 2;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo1;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(457, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Todos",
            "Pendiente Por entregar a taller",
            "Por recibir de taller",
            "No recuperables"});
            this.cboEstado.Location = new System.Drawing.Point(107, 69);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(164, 21);
            this.cboEstado.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Proveedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Responsable de Entrega:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Responsable de Registro:";
            // 
            // dgvRecepcion
            // 
            this.dgvRecepcion.AllowUserToAddRows = false;
            this.dgvRecepcion.AllowUserToDeleteRows = false;
            this.dgvRecepcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecepcion.Location = new System.Drawing.Point(27, 136);
            this.dgvRecepcion.Name = "dgvRecepcion";
            this.dgvRecepcion.ReadOnly = true;
            this.dgvRecepcion.Size = new System.Drawing.Size(586, 306);
            this.dgvRecepcion.TabIndex = 11;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderSize = 2;
            this.btnExportar.Image = global::GUILayer.Properties.Resources.excel;
            this.btnExportar.Location = new System.Drawing.Point(793, 402);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(90, 40);
            this.btnExportar.TabIndex = 56;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // gbResumen
            // 
            this.gbResumen.Controls.Add(this.dgvResumen);
            this.gbResumen.Location = new System.Drawing.Point(619, 129);
            this.gbResumen.Name = "gbResumen";
            this.gbResumen.Size = new System.Drawing.Size(366, 186);
            this.gbResumen.TabIndex = 57;
            this.gbResumen.TabStop = false;
            this.gbResumen.Text = "Resumen";
            // 
            // dgvResumen
            // 
            this.dgvResumen.AllowUserToAddRows = false;
            this.dgvResumen.AllowUserToDeleteRows = false;
            this.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumen.Location = new System.Drawing.Point(6, 19);
            this.dgvResumen.Name = "dgvResumen";
            this.dgvResumen.Size = new System.Drawing.Size(354, 150);
            this.dgvResumen.TabIndex = 58;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(692, 401);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 58;
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
            this.btnSalir.Location = new System.Drawing.Point(889, 401);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 59;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // cboProveedor
            // 
            this.cboProveedor.Busqueda = true;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.ListaMostrada = null;
            this.cboProveedor.Location = new System.Drawing.Point(107, 96);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(164, 21);
            this.cboProveedor.TabIndex = 5;
            // 
            // cboResponsableRegistro
            // 
            this.cboResponsableRegistro.Busqueda = true;
            this.cboResponsableRegistro.FormattingEnabled = true;
            this.cboResponsableRegistro.ListaMostrada = null;
            this.cboResponsableRegistro.Location = new System.Drawing.Point(431, 96);
            this.cboResponsableRegistro.Name = "cboResponsableRegistro";
            this.cboResponsableRegistro.Size = new System.Drawing.Size(182, 21);
            this.cboResponsableRegistro.TabIndex = 4;
            // 
            // cboResponsableEntrega
            // 
            this.cboResponsableEntrega.Busqueda = true;
            this.cboResponsableEntrega.FormattingEnabled = true;
            this.cboResponsableEntrega.ListaMostrada = null;
            this.cboResponsableEntrega.Location = new System.Drawing.Point(431, 69);
            this.cboResponsableEntrega.Name = "cboResponsableEntrega";
            this.cboResponsableEntrega.Size = new System.Drawing.Size(182, 21);
            this.cboResponsableEntrega.TabIndex = 3;
            // 
            // frmReporteRecepcionCartuchos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 453);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.gbResumen);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvRecepcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.cboResponsableRegistro);
            this.Controls.Add(this.cboResponsableEntrega);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteRecepcionCartuchos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Recepción de Cartuchos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecepcion)).EndInit();
            this.gbResumen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private ComboBoxBusqueda cboResponsableEntrega;
        private ComboBoxBusqueda cboResponsableRegistro;
        private ComboBoxBusqueda cboProveedor;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvRecepcion;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox gbResumen;
        private System.Windows.Forms.DataGridView dgvResumen;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}