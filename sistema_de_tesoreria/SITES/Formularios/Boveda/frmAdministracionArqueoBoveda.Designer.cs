namespace GUILayer.Formularios.Boveda
{
    partial class frmAdministracionArqueoBoveda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionArqueoBoveda));
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvArqueos = new System.Windows.Forms.DataGridView();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblArqueos = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbArqueos = new System.Windows.Forms.GroupBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArqueos)).BeginInit();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbArqueos.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(417, 477);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 22;
            this.btnModificar.Text = "Ver";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNuevo.Location = new System.Drawing.Point(321, 477);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 40);
            this.btnNuevo.TabIndex = 21;
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
            this.btnSalir.Location = new System.Drawing.Point(513, 477);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(14, 477);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            // 
            // dgvArqueos
            // 
            this.dgvArqueos.AllowUserToAddRows = false;
            this.dgvArqueos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvArqueos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArqueos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArqueos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvArqueos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvArqueos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvArqueos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArqueos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clID,
            this.clFecha,
            this.clTipo,
            this.clResponsable});
            this.dgvArqueos.EnableHeadersVisualStyles = false;
            this.dgvArqueos.Location = new System.Drawing.Point(16, 19);
            this.dgvArqueos.MultiSelect = false;
            this.dgvArqueos.Name = "dgvArqueos";
            this.dgvArqueos.ReadOnly = true;
            this.dgvArqueos.RowHeadersVisible = false;
            this.dgvArqueos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArqueos.Size = new System.Drawing.Size(567, 288);
            this.dgvArqueos.StandardTab = true;
            this.dgvArqueos.TabIndex = 0;
            this.dgvArqueos.SelectionChanged += new System.EventHandler(this.dgvArqueos_SelectionChanged);
            // 
            // clID
            // 
            this.clID.DataPropertyName = "ID";
            this.clID.HeaderText = "ID";
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            this.clID.Width = 42;
            // 
            // clFecha
            // 
            this.clFecha.DataPropertyName = "Fecha";
            this.clFecha.HeaderText = "Fecha";
            this.clFecha.Name = "clFecha";
            this.clFecha.ReadOnly = true;
            this.clFecha.Width = 61;
            // 
            // clTipo
            // 
            this.clTipo.DataPropertyName = "Tipo";
            this.clTipo.HeaderText = "Tipo";
            this.clTipo.Name = "clTipo";
            this.clTipo.ReadOnly = true;
            this.clTipo.Width = 52;
            // 
            // clResponsable
            // 
            this.clResponsable.DataPropertyName = "Usuario";
            this.clResponsable.HeaderText = "Responsable";
            this.clResponsable.Name = "clResponsable";
            this.clResponsable.ReadOnly = true;
            this.clResponsable.Width = 93;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(97, 13);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpInicio.TabIndex = 7;
            // 
            // lblArqueos
            // 
            this.lblArqueos.AutoSize = true;
            this.lblArqueos.Location = new System.Drawing.Point(8, 19);
            this.lblArqueos.Name = "lblArqueos";
            this.lblArqueos.Size = new System.Drawing.Size(83, 13);
            this.lblArqueos.TabIndex = 5;
            this.lblArqueos.Text = "Fecha de Inicio:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(345, 13);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 53);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.dtpInicio);
            this.gbFiltro.Controls.Add(this.lblArqueos);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Location = new System.Drawing.Point(14, 68);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(493, 72);
            this.gbFiltro.TabIndex = 19;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Arqueos";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, -1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbArqueos
            // 
            this.gbArqueos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbArqueos.Controls.Add(this.dgvArqueos);
            this.gbArqueos.Location = new System.Drawing.Point(14, 146);
            this.gbArqueos.Name = "gbArqueos";
            this.gbArqueos.Size = new System.Drawing.Size(589, 325);
            this.gbArqueos.TabIndex = 20;
            this.gbArqueos.TabStop = false;
            this.gbArqueos.Text = "Lista de Arqueos";
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(1, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(617, 60);
            this.pnlFondo.TabIndex = 18;
            // 
            // frmAdministracionArqueoBoveda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 529);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.gbArqueos);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionArqueoBoveda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Arqueos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArqueos)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbArqueos.ResumeLayout(false);
            this.pnlFondo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvArqueos;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblArqueos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbArqueos;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResponsable;
    }
}