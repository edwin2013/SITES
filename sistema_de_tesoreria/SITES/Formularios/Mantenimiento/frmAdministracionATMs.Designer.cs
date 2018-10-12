namespace GUILayer
{
    partial class frmAdministracionATMs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionATMs));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbATMs = new System.Windows.Forms.GroupBox();
            this.dgvATMs = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cartuchos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Full = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ENA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CartuchoRechazo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VIP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbATMs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvATMs)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(792, 60);
            this.pnlFondo.TabIndex = 0;
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
            // gbATMs
            // 
            this.gbATMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbATMs.Controls.Add(this.dgvATMs);
            this.gbATMs.Location = new System.Drawing.Point(12, 66);
            this.gbATMs.Name = "gbATMs";
            this.gbATMs.Size = new System.Drawing.Size(769, 442);
            this.gbATMs.TabIndex = 1;
            this.gbATMs.TabStop = false;
            this.gbATMs.Text = "Lista de ATM\'s";
            // 
            // dgvATMs
            // 
            this.dgvATMs.AllowUserToAddRows = false;
            this.dgvATMs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvATMs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvATMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvATMs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvATMs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvATMs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvATMs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvATMs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Transportadora,
            this.Codigo,
            this.Ubicacion,
            this.Tipo,
            this.Cartuchos,
            this.Full,
            this.ENA,
            this.CartuchoRechazo,
            this.VIP});
            this.dgvATMs.EnableHeadersVisualStyles = false;
            this.dgvATMs.Location = new System.Drawing.Point(6, 19);
            this.dgvATMs.MultiSelect = false;
            this.dgvATMs.Name = "dgvATMs";
            this.dgvATMs.ReadOnly = true;
            this.dgvATMs.RowHeadersVisible = false;
            this.dgvATMs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvATMs.Size = new System.Drawing.Size(757, 417);
            this.dgvATMs.StandardTab = true;
            this.dgvATMs.TabIndex = 0;
            this.dgvATMs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvATMs_CellDoubleClick);
            this.dgvATMs.SelectionChanged += new System.EventHandler(this.dgvATMs_SelectionChanged);
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 68;
            // 
            // Transportadora
            // 
            this.Transportadora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Transportadora.DataPropertyName = "Empresa_encargada";
            this.Transportadora.HeaderText = "Transportadora";
            this.Transportadora.Name = "Transportadora";
            this.Transportadora.ReadOnly = true;
            this.Transportadora.Width = 103;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 64;
            // 
            // Ubicacion
            // 
            this.Ubicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ubicacion.DataPropertyName = "Nombre_ubicacion";
            this.Ubicacion.HeaderText = "Ubicación";
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
            this.Ubicacion.Width = 79;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 52;
            // 
            // Cartuchos
            // 
            this.Cartuchos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cartuchos.DataPropertyName = "Cartuchos";
            this.Cartuchos.HeaderText = "Cartuchos";
            this.Cartuchos.Name = "Cartuchos";
            this.Cartuchos.ReadOnly = true;
            this.Cartuchos.Width = 79;
            // 
            // Full
            // 
            this.Full.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Full.DataPropertyName = "Full";
            this.Full.HeaderText = "Full";
            this.Full.Name = "Full";
            this.Full.ReadOnly = true;
            this.Full.Width = 28;
            // 
            // ENA
            // 
            this.ENA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ENA.DataPropertyName = "ENA";
            this.ENA.HeaderText = "ENA";
            this.ENA.Name = "ENA";
            this.ENA.ReadOnly = true;
            this.ENA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ENA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ENA.Width = 53;
            // 
            // CartuchoRechazo
            // 
            this.CartuchoRechazo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CartuchoRechazo.DataPropertyName = "Cartucho_rechazo";
            this.CartuchoRechazo.HeaderText = "C.  Rechazo";
            this.CartuchoRechazo.Name = "CartuchoRechazo";
            this.CartuchoRechazo.ReadOnly = true;
            this.CartuchoRechazo.Width = 71;
            // 
            // VIP
            // 
            this.VIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VIP.DataPropertyName = "VIP";
            this.VIP.HeaderText = "VIP";
            this.VIP.Name = "VIP";
            this.VIP.ReadOnly = true;
            this.VIP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VIP.Width = 48;
            // 
            // btnNueva
            // 
            this.btnNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNueva.FlatAppearance.BorderSize = 2;
            this.btnNueva.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNueva.Location = new System.Drawing.Point(396, 514);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(90, 40);
            this.btnNueva.TabIndex = 3;
            this.btnNueva.Text = "Agregar";
            this.btnNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNueva.UseVisualStyleBackColor = false;
            this.btnNueva.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(684, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(492, 514);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(588, 514);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(295, 514);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(95, 40);
            this.btnExportarExcel.TabIndex = 11;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // frmAdministracionATMs
            // 
            this.AcceptButton = this.btnNueva;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbATMs);
            this.Controls.Add(this.btnEliminar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionATMs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de ATM\'s";
            this.Load += new System.EventHandler(this.frmAdministracionATMs_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbATMs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvATMs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbATMs;
        private System.Windows.Forms.DataGridView dgvATMs;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cartuchos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Full;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ENA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CartuchoRechazo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VIP;
        private System.Windows.Forms.Button btnExportarExcel;
    }
}