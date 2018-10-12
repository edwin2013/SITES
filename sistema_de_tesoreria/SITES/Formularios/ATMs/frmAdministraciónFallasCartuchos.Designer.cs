namespace GUILayer.Formularios.Níquel
{
    partial class frmAdministracionFallasCartuchos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionFallasCartuchos));
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbFallasCartuchos = new System.Windows.Forms.GroupBox();
            this.dgvFallasCartuchos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNoRecuperable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbFallasCartuchos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFallasCartuchos)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNuevo.Location = new System.Drawing.Point(49, 351);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 40);
            this.btnNuevo.TabIndex = 20;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(241, 351);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(145, 351);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 21;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(337, 351);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // gbFallasCartuchos
            // 
            this.gbFallasCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFallasCartuchos.Controls.Add(this.dgvFallasCartuchos);
            this.gbFallasCartuchos.Location = new System.Drawing.Point(12, 66);
            this.gbFallasCartuchos.Name = "gbFallasCartuchos";
            this.gbFallasCartuchos.Size = new System.Drawing.Size(415, 279);
            this.gbFallasCartuchos.TabIndex = 24;
            this.gbFallasCartuchos.TabStop = false;
            this.gbFallasCartuchos.Text = "Lista de Tipos de Fallas de Cartuchos";
            this.gbFallasCartuchos.Enter += new System.EventHandler(this.gbFallasCartuchos_Enter);
            // 
            // dgvFallasCartuchos
            // 
            this.dgvFallasCartuchos.AllowUserToAddRows = false;
            this.dgvFallasCartuchos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvFallasCartuchos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFallasCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFallasCartuchos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFallasCartuchos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFallasCartuchos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFallasCartuchos.ColumnHeadersHeight = 17;
            this.dgvFallasCartuchos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Colaborador,
            this.clCantidad,
            this.clNoRecuperable});
            this.dgvFallasCartuchos.EnableHeadersVisualStyles = false;
            this.dgvFallasCartuchos.Location = new System.Drawing.Point(6, 19);
            this.dgvFallasCartuchos.Name = "dgvFallasCartuchos";
            this.dgvFallasCartuchos.ReadOnly = true;
            this.dgvFallasCartuchos.RowHeadersVisible = false;
            this.dgvFallasCartuchos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFallasCartuchos.Size = new System.Drawing.Size(403, 254);
            this.dgvFallasCartuchos.StandardTab = true;
            this.dgvFallasCartuchos.TabIndex = 0;
            this.dgvFallasCartuchos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFallasCartuchos_CellDoubleClick);
            this.dgvFallasCartuchos.SelectionChanged += new System.EventHandler(this.dgvFallasCartuchos_SelectionChanged);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "ID";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "ID";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 42;
            // 
            // Colaborador
            // 
            this.Colaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Colaborador.DataPropertyName = "Nombre";
            this.Colaborador.HeaderText = "Tipo de Falla";
            this.Colaborador.Name = "Colaborador";
            this.Colaborador.ReadOnly = true;
            this.Colaborador.Width = 92;
            // 
            // clCantidad
            // 
            this.clCantidad.DataPropertyName = "Cantidad";
            this.clCantidad.HeaderText = "Cantidad Permitida";
            this.clCantidad.Name = "clCantidad";
            this.clCantidad.ReadOnly = true;
            this.clCantidad.Width = 119;
            // 
            // clNoRecuperable
            // 
            this.clNoRecuperable.DataPropertyName = "NoRecuperable";
            this.clNoRecuperable.HeaderText = "No Recuperable";
            this.clNoRecuperable.Name = "clNoRecuperable";
            this.clNoRecuperable.ReadOnly = true;
            this.clNoRecuperable.Width = 90;
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
            this.pnlFondo.TabIndex = 25;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo1;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmAdministracionFallasCartuchos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 403);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbFallasCartuchos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionFallasCartuchos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fallas de Cartuchos";
            this.gbFallasCartuchos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFallasCartuchos)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbFallasCartuchos;
        private System.Windows.Forms.DataGridView dgvFallasCartuchos;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colaborador;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCantidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNoRecuperable;
    }
}