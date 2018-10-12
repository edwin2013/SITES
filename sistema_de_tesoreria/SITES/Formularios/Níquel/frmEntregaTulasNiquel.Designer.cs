namespace GUILayer.Formularios.Níquel
{
    partial class frmEntregaTulasNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaTulasNiquel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.TulaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnActualizarEntrega = new System.Windows.Forms.Button();
            this.lblTulaEntrega = new System.Windows.Forms.Label();
            this.txtMarchamoTulaEntrega = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.dgvBolsasCompletas = new System.Windows.Forms.DataGridView();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBolsasCompletas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(81, 71);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 17;
            this.lblFecha.Text = "Fecha:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(3, 3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1185, 50);
            this.pnlFondo.TabIndex = 14;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(390, 44);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(1060, 721);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 45);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvTulas
            // 
            this.dgvTulas.AllowUserToAddRows = false;
            this.dgvTulas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTulas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTulas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTulas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TulaEntrega,
            this.NombreEntrega});
            this.dgvTulas.EnableHeadersVisualStyles = false;
            this.dgvTulas.Location = new System.Drawing.Point(45, 179);
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.ReadOnly = true;
            this.dgvTulas.RowHeadersVisible = false;
            this.dgvTulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulas.Size = new System.Drawing.Size(1105, 245);
            this.dgvTulas.TabIndex = 5;
            // 
            // TulaEntrega
            // 
            this.TulaEntrega.DataPropertyName = "SerieBolsa";
            this.TulaEntrega.HeaderText = "Tula";
            this.TulaEntrega.Name = "TulaEntrega";
            this.TulaEntrega.ReadOnly = true;
            this.TulaEntrega.Width = 52;
            // 
            // NombreEntrega
            // 
            this.NombreEntrega.DataPropertyName = "PuntoVenta";
            this.NombreEntrega.HeaderText = "Punto de Venta";
            this.NombreEntrega.Name = "NombreEntrega";
            this.NombreEntrega.ReadOnly = true;
            this.NombreEntrega.Width = 105;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(127, 65);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 16;
            // 
            // btnActualizarEntrega
            // 
            this.btnActualizarEntrega.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizarEntrega.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizarEntrega.FlatAppearance.BorderSize = 2;
            this.btnActualizarEntrega.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizarEntrega.Location = new System.Drawing.Point(917, 105);
            this.btnActualizarEntrega.Name = "btnActualizarEntrega";
            this.btnActualizarEntrega.Size = new System.Drawing.Size(93, 40);
            this.btnActualizarEntrega.TabIndex = 4;
            this.btnActualizarEntrega.Text = "Actualizar";
            this.btnActualizarEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarEntrega.UseVisualStyleBackColor = false;
            this.btnActualizarEntrega.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblTulaEntrega
            // 
            this.lblTulaEntrega.AutoSize = true;
            this.lblTulaEntrega.Location = new System.Drawing.Point(5, 26);
            this.lblTulaEntrega.Name = "lblTulaEntrega";
            this.lblTulaEntrega.Size = new System.Drawing.Size(34, 13);
            this.lblTulaEntrega.TabIndex = 3;
            this.lblTulaEntrega.Text = "Tula: ";
            // 
            // txtMarchamoTulaEntrega
            // 
            this.txtMarchamoTulaEntrega.Location = new System.Drawing.Point(100, 23);
            this.txtMarchamoTulaEntrega.Name = "txtMarchamoTulaEntrega";
            this.txtMarchamoTulaEntrega.Size = new System.Drawing.Size(291, 20);
            this.txtMarchamoTulaEntrega.TabIndex = 1;
            this.txtMarchamoTulaEntrega.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMarchamoTulaEntrega_KeyUp_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTulaEntrega);
            this.panel1.Controls.Add(this.txtMarchamoTulaEntrega);
            this.panel1.Location = new System.Drawing.Point(290, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 69);
            this.panel1.TabIndex = 6;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(401, 72);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 19;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // dgvBolsasCompletas
            // 
            this.dgvBolsasCompletas.AllowUserToAddRows = false;
            this.dgvBolsasCompletas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBolsasCompletas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBolsasCompletas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBolsasCompletas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBolsasCompletas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBolsasCompletas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.clmSeleccionar});
            this.dgvBolsasCompletas.EnableHeadersVisualStyles = false;
            this.dgvBolsasCompletas.Location = new System.Drawing.Point(45, 451);
            this.dgvBolsasCompletas.Name = "dgvBolsasCompletas";
            this.dgvBolsasCompletas.RowHeadersVisible = false;
            this.dgvBolsasCompletas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBolsasCompletas.Size = new System.Drawing.Size(1105, 245);
            this.dgvBolsasCompletas.TabIndex = 20;
            this.dgvBolsasCompletas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBolsasCompletas_CellValueChanged);
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.FormattingEnabled = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(489, 68);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(187, 21);
            this.cboTransportadora.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CantidadBolsas";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cantidad de Bolsas";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 122;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Denominacion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Denominación";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 99;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PuntoVenta";
            this.dataGridViewTextBoxColumn3.HeaderText = "Punto de Entrega";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 114;
            // 
            // clmSeleccionar
            // 
            this.clmSeleccionar.HeaderText = "Seleccionar";
            this.clmSeleccionar.Name = "clmSeleccionar";
            this.clmSeleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmSeleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmSeleccionar.Width = 87;
            // 
            // frmEntregaTulasNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 778);
            this.Controls.Add(this.dgvBolsasCompletas);
            this.Controls.Add(this.dgvTulas);
            this.Controls.Add(this.btnActualizarEntrega);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTransportadora);
            this.Controls.Add(this.cboTransportadora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtpFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEntregaTulasNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrega de Tulas";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBolsasCompletas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnActualizarEntrega;
        private System.Windows.Forms.Label lblTulaEntrega;
        private System.Windows.Forms.TextBox txtMarchamoTulaEntrega;
        private System.Windows.Forms.Panel panel1;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.DataGridView dgvBolsasCompletas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TulaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSeleccionar;
    }
}