namespace GUILayer.Formularios.Níquel
{
    partial class frmAdministraciónGarantiaCartuchos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministraciónGarantiaCartuchos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbFallasCartuchos = new System.Windows.Forms.GroupBox();
            this.dgvGarantíaCartuchos = new System.Windows.Forms.DataGridView();
            this.clUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbFallasCartuchos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGarantíaCartuchos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNuevo.Location = new System.Drawing.Point(235, 351);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 40);
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(331, 351);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 33;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(439, 60);
            this.pnlFondo.TabIndex = 34;
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
            // gbFallasCartuchos
            // 
            this.gbFallasCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFallasCartuchos.Controls.Add(this.dgvGarantíaCartuchos);
            this.gbFallasCartuchos.Location = new System.Drawing.Point(12, 62);
            this.gbFallasCartuchos.Name = "gbFallasCartuchos";
            this.gbFallasCartuchos.Size = new System.Drawing.Size(415, 279);
            this.gbFallasCartuchos.TabIndex = 35;
            this.gbFallasCartuchos.TabStop = false;
            this.gbFallasCartuchos.Text = "Lista de Garantía de Cartuchos";
            // 
            // dgvGarantíaCartuchos
            // 
            this.dgvGarantíaCartuchos.AllowUserToAddRows = false;
            this.dgvGarantíaCartuchos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvGarantíaCartuchos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGarantíaCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGarantíaCartuchos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGarantíaCartuchos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGarantíaCartuchos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvGarantíaCartuchos.ColumnHeadersHeight = 17;
            this.dgvGarantíaCartuchos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clUsuario,
            this.clFecha,
            this.Colaborador});
            this.dgvGarantíaCartuchos.EnableHeadersVisualStyles = false;
            this.dgvGarantíaCartuchos.Location = new System.Drawing.Point(6, 19);
            this.dgvGarantíaCartuchos.Name = "dgvGarantíaCartuchos";
            this.dgvGarantíaCartuchos.ReadOnly = true;
            this.dgvGarantíaCartuchos.RowHeadersVisible = false;
            this.dgvGarantíaCartuchos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGarantíaCartuchos.Size = new System.Drawing.Size(403, 254);
            this.dgvGarantíaCartuchos.StandardTab = true;
            this.dgvGarantíaCartuchos.TabIndex = 0;
            // 
            // clUsuario
            // 
            this.clUsuario.DataPropertyName = "usuario";
            this.clUsuario.HeaderText = "Usuario";
            this.clUsuario.Name = "clUsuario";
            this.clUsuario.ReadOnly = true;
            this.clUsuario.Width = 67;
            // 
            // clFecha
            // 
            this.clFecha.DataPropertyName = "fecha";
            this.clFecha.HeaderText = "Fecha de Cambio";
            this.clFecha.Name = "clFecha";
            this.clFecha.ReadOnly = true;
            this.clFecha.Width = 114;
            // 
            // Colaborador
            // 
            this.Colaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Colaborador.DataPropertyName = "dias";
            this.Colaborador.HeaderText = "Días Naturales de Garantía";
            this.Colaborador.Name = "Colaborador";
            this.Colaborador.ReadOnly = true;
            this.Colaborador.Width = 162;
            // 
            // frmAdministraciónGarantiaCartuchos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 403);
            this.Controls.Add(this.gbFallasCartuchos);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministraciónGarantiaCartuchos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garantía de Cartuchos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbFallasCartuchos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGarantíaCartuchos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbFallasCartuchos;
        private System.Windows.Forms.DataGridView dgvGarantíaCartuchos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colaborador;
    }
}