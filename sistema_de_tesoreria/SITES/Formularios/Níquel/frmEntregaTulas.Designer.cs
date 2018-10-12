namespace GUILayer
{
    partial class frmEntregaTulas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaTulas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEmpresaTransporte = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbGrupos = new System.Windows.Forms.GroupBox();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCajas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CajaActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manifiestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CajaUnica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Disponible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboEmpresa = new GUILayer.ComboBoxBusqueda();
            this.groupBox1.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbGrupos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEmpresaTransporte);
            this.groupBox1.Controls.Add(this.cboEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(11, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 46);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Recepción";
            // 
            // lblEmpresaTransporte
            // 
            this.lblEmpresaTransporte.AutoSize = true;
            this.lblEmpresaTransporte.Location = new System.Drawing.Point(6, 23);
            this.lblEmpresaTransporte.Name = "lblEmpresaTransporte";
            this.lblEmpresaTransporte.Size = new System.Drawing.Size(120, 13);
            this.lblEmpresaTransporte.TabIndex = 0;
            this.lblEmpresaTransporte.Text = "Empresa de Transporte:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(713, 60);
            this.pnlFondo.TabIndex = 6;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(429, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Enabled = false;
            this.btnReiniciar.Image = global::GUILayer.Properties.Resources.reiniciar;
            this.btnReiniciar.Location = new System.Drawing.Point(407, 471);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(90, 40);
            this.btnReiniciar.TabIndex = 9;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(609, 471);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbGrupos
            // 
            this.gbGrupos.Controls.Add(this.dgvGrupos);
            this.gbGrupos.Location = new System.Drawing.Point(11, 120);
            this.gbGrupos.Name = "gbGrupos";
            this.gbGrupos.Size = new System.Drawing.Size(688, 345);
            this.gbGrupos.TabIndex = 8;
            this.gbGrupos.TabStop = false;
            this.gbGrupos.Text = "Lista de Grupos de Cajas";
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.Silver;
            this.dgvGrupos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGrupos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGrupos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Area,
            this.NumeroCajas,
            this.CajaActual,
            this.Manifiestos,
            this.CajaUnica,
            this.Disponible});
            this.dgvGrupos.EnableHeadersVisualStyles = false;
            this.dgvGrupos.Location = new System.Drawing.Point(5, 19);
            this.dgvGrupos.MultiSelect = false;
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.RowHeadersVisible = false;
            this.dgvGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupos.Size = new System.Drawing.Size(677, 320);
            this.dgvGrupos.StandardTab = true;
            this.dgvGrupos.TabIndex = 0;
            this.dgvGrupos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGrupos_CurrentCellDirtyStateChanged);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Enabled = false;
            this.btnContinuar.Image = global::GUILayer.Properties.Resources.continuar;
            this.btnContinuar.Location = new System.Drawing.Point(503, 471);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(100, 40);
            this.btnContinuar.TabIndex = 10;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 68;
            // 
            // Area
            // 
            this.Area.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Area.HeaderText = "Area";
            this.Area.Name = "Area";
            this.Area.Width = 53;
            // 
            // NumeroCajas
            // 
            this.NumeroCajas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumeroCajas.DataPropertyName = "Numero_cajas";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NumeroCajas.DefaultCellStyle = dataGridViewCellStyle26;
            this.NumeroCajas.HeaderText = "Número de Cajas";
            this.NumeroCajas.MinimumWidth = 115;
            this.NumeroCajas.Name = "NumeroCajas";
            this.NumeroCajas.Visible = false;
            this.NumeroCajas.Width = 115;
            // 
            // CajaActual
            // 
            this.CajaActual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CajaActual.DataPropertyName = "Caja_actual";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CajaActual.DefaultCellStyle = dataGridViewCellStyle27;
            this.CajaActual.HeaderText = "Caja Actual";
            this.CajaActual.MinimumWidth = 85;
            this.CajaActual.Name = "CajaActual";
            this.CajaActual.ReadOnly = true;
            this.CajaActual.Visible = false;
            this.CajaActual.Width = 85;
            // 
            // Manifiestos
            // 
            this.Manifiestos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Manifiestos.DataPropertyName = "Total_manifiestos";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Manifiestos.DefaultCellStyle = dataGridViewCellStyle28;
            this.Manifiestos.HeaderText = "Manifiestos";
            this.Manifiestos.Name = "Manifiestos";
            this.Manifiestos.Visible = false;
            this.Manifiestos.Width = 84;
            // 
            // CajaUnica
            // 
            this.CajaUnica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CajaUnica.DataPropertyName = "Caja_unica";
            this.CajaUnica.HeaderText = "Caja Única";
            this.CajaUnica.MinimumWidth = 85;
            this.CajaUnica.Name = "CajaUnica";
            this.CajaUnica.ReadOnly = true;
            this.CajaUnica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CajaUnica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CajaUnica.Visible = false;
            this.CajaUnica.Width = 85;
            // 
            // Disponible
            // 
            this.Disponible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Disponible.HeaderText = "Disponible";
            this.Disponible.Name = "Disponible";
            this.Disponible.Width = 61;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Busqueda = false;
            this.cboEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "UltimaEmpresaTransporte", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboEmpresa.ListaMostrada = null;
            this.cboEmpresa.Location = new System.Drawing.Point(132, 19);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(299, 21);
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.Text = global::GUILayer.Properties.Settings.Default.UltimaEmpresaTransporte;
            // 
            // frmEntregaTulas
            // 
            this.AcceptButton = this.btnContinuar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(714, 513);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbGrupos);
            this.Controls.Add(this.btnContinuar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEntregaTulas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrega de Tulas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbGrupos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEmpresaTransporte;
        private ComboBoxBusqueda cboEmpresa;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbGrupos;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CajaActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiestos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CajaUnica;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Disponible;
    }
}