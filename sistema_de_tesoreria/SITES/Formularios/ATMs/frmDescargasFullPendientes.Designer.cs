namespace GUILayer
{
    partial class frmDescargasFullPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescargasFullPendientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.txtMarchamoBusqueda = new System.Windows.Forms.TextBox();
            this.lblMarchamoBusqueda = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarTodas = new System.Windows.Forms.Button();
            this.gbDescargasFull = new System.Windows.Forms.GroupBox();
            this.dgvDescargasFullPendientes = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ATM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marchamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emergencia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            this.gbDescargasFull.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescargasFullPendientes)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(942, 60);
            this.pnlFondo.TabIndex = 0;
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
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.txtMarchamoBusqueda);
            this.gbBusqueda.Controls.Add(this.lblMarchamoBusqueda);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Controls.Add(this.btnMostrarTodas);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 66);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(466, 65);
            this.gbBusqueda.TabIndex = 1;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Datos de Búsqueda";
            // 
            // txtMarchamoBusqueda
            // 
            this.txtMarchamoBusqueda.Location = new System.Drawing.Point(72, 29);
            this.txtMarchamoBusqueda.Name = "txtMarchamoBusqueda";
            this.txtMarchamoBusqueda.Size = new System.Drawing.Size(196, 20);
            this.txtMarchamoBusqueda.TabIndex = 1;
            this.txtMarchamoBusqueda.TextChanged += new System.EventHandler(this.txtMarchamoBusqueda_TextChanged);
            // 
            // lblMarchamoBusqueda
            // 
            this.lblMarchamoBusqueda.AutoSize = true;
            this.lblMarchamoBusqueda.Location = new System.Drawing.Point(6, 33);
            this.lblMarchamoBusqueda.Name = "lblMarchamoBusqueda";
            this.lblMarchamoBusqueda.Size = new System.Drawing.Size(60, 13);
            this.lblMarchamoBusqueda.TabIndex = 0;
            this.lblMarchamoBusqueda.Text = "Marchamo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(274, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMostrarTodas
            // 
            this.btnMostrarTodas.FlatAppearance.BorderSize = 2;
            this.btnMostrarTodas.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnMostrarTodas.Location = new System.Drawing.Point(370, 19);
            this.btnMostrarTodas.Name = "btnMostrarTodas";
            this.btnMostrarTodas.Size = new System.Drawing.Size(90, 40);
            this.btnMostrarTodas.TabIndex = 3;
            this.btnMostrarTodas.Text = "Todas";
            this.btnMostrarTodas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMostrarTodas.UseVisualStyleBackColor = false;
            this.btnMostrarTodas.Click += new System.EventHandler(this.btnMostrarTodas_Click);
            // 
            // gbDescargasFull
            // 
            this.gbDescargasFull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDescargasFull.Controls.Add(this.dgvDescargasFullPendientes);
            this.gbDescargasFull.Location = new System.Drawing.Point(12, 137);
            this.gbDescargasFull.Name = "gbDescargasFull";
            this.gbDescargasFull.Size = new System.Drawing.Size(918, 351);
            this.gbDescargasFull.TabIndex = 2;
            this.gbDescargasFull.TabStop = false;
            this.gbDescargasFull.Text = "Descargas Pendientes";
            // 
            // dgvDescargasFullPendientes
            // 
            this.dgvDescargasFullPendientes.AllowUserToAddRows = false;
            this.dgvDescargasFullPendientes.AllowUserToDeleteRows = false;
            this.dgvDescargasFullPendientes.AllowUserToOrderColumns = true;
            this.dgvDescargasFullPendientes.AllowUserToResizeColumns = false;
            this.dgvDescargasFullPendientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDescargasFullPendientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDescargasFullPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDescargasFullPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDescargasFullPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescargasFullPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATM,
            this.Marchamo,
            this.Fecha,
            this.Emergencia});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDescargasFullPendientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDescargasFullPendientes.EnableHeadersVisualStyles = false;
            this.dgvDescargasFullPendientes.Location = new System.Drawing.Point(6, 19);
            this.dgvDescargasFullPendientes.MultiSelect = false;
            this.dgvDescargasFullPendientes.Name = "dgvDescargasFullPendientes";
            this.dgvDescargasFullPendientes.ReadOnly = true;
            this.dgvDescargasFullPendientes.RowHeadersVisible = false;
            this.dgvDescargasFullPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDescargasFullPendientes.Size = new System.Drawing.Size(906, 326);
            this.dgvDescargasFullPendientes.StandardTab = true;
            this.dgvDescargasFullPendientes.TabIndex = 0;
            this.dgvDescargasFullPendientes.SelectionChanged += new System.EventHandler(this.dgvDescargasFullPendientes_SelectionChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(733, 494);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(95, 40);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(834, 494);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ATM
            // 
            this.ATM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATM.DataPropertyName = "ATM";
            this.ATM.HeaderText = "ATM";
            this.ATM.Name = "ATM";
            this.ATM.ReadOnly = true;
            this.ATM.Width = 54;
            // 
            // Marchamo
            // 
            this.Marchamo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Marchamo.DataPropertyName = "Codigo_marchamo";
            this.Marchamo.HeaderText = "Marchamo";
            this.Marchamo.Name = "Marchamo";
            this.Marchamo.ReadOnly = true;
            this.Marchamo.Width = 81;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "Fecha_carga";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha de Carga";
            this.Fecha.MinimumWidth = 110;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 110;
            // 
            // Emergencia
            // 
            this.Emergencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Emergencia.DataPropertyName = "Emergencia";
            this.Emergencia.HeaderText = "Emergencia";
            this.Emergencia.Name = "Emergencia";
            this.Emergencia.ReadOnly = true;
            this.Emergencia.Width = 68;
            // 
            // frmDescargasFullPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 546);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbDescargasFull);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbBusqueda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 580);
            this.Name = "frmDescargasFullPendientes";
            this.Text = "Descargas Full Pendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbDescargasFull.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescargasFullPendientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.TextBox txtMarchamoBusqueda;
        private System.Windows.Forms.Label lblMarchamoBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodas;
        private System.Windows.Forms.GroupBox gbDescargasFull;
        private System.Windows.Forms.DataGridView dgvDescargasFullPendientes;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marchamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Emergencia;
    }
}