namespace GUILayer.Formularios.Control_Interno
{
    partial class frmAdministracionArqueos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionArqueos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArqueos = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gbArqueos = new System.Windows.Forms.GroupBox();
            this.dgvArqueos = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ofdArchivo = new System.Windows.Forms.OpenFileDialog();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnSubir = new System.Windows.Forms.Button();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.gbArqueos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArqueos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-1, -1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(616, 60);
            this.pnlFondo.TabIndex = 2;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, -1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.dtpFin);
            this.gbFiltro.Controls.Add(this.dtpInicio);
            this.gbFiltro.Controls.Add(this.label1);
            this.gbFiltro.Controls.Add(this.lblArqueos);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Location = new System.Drawing.Point(12, 65);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(493, 72);
            this.gbFiltro.TabIndex = 3;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Arqueos";
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(97, 40);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFin.TabIndex = 8;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(97, 13);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpInicio.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha de Fin:";
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
            this.btnActualizar.Location = new System.Drawing.Point(345, 19);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // gbArqueos
            // 
            this.gbArqueos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbArqueos.Controls.Add(this.dgvArqueos);
            this.gbArqueos.Location = new System.Drawing.Point(12, 143);
            this.gbArqueos.Name = "gbArqueos";
            this.gbArqueos.Size = new System.Drawing.Size(586, 283);
            this.gbArqueos.TabIndex = 13;
            this.gbArqueos.TabStop = false;
            this.gbArqueos.Text = "Lista de Arqueos";
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
            this.dgvArqueos.Size = new System.Drawing.Size(564, 246);
            this.dgvArqueos.StandardTab = true;
            this.dgvArqueos.TabIndex = 0;
            this.dgvArqueos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArqueos_CellContentClick);
            this.dgvArqueos.SelectionChanged += new System.EventHandler(this.dgvArqueos_SelectionChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(415, 432);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 15;
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
            this.btnNuevo.Location = new System.Drawing.Point(125, 432);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 40);
            this.btnNuevo.TabIndex = 14;
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
            this.btnSalir.Location = new System.Drawing.Point(511, 432);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // ofdArchivo
            // 
            this.ofdArchivo.FileName = "openFileDialog1";
            // 
            // btnVer
            // 
            this.btnVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVer.Enabled = false;
            this.btnVer.FlatAppearance.BorderSize = 2;
            this.btnVer.Image = global::GUILayer.Properties.Resources.acrobat;
            this.btnVer.Location = new System.Drawing.Point(319, 432);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(90, 40);
            this.btnVer.TabIndex = 18;
            this.btnVer.Text = "Ver PDF";
            this.btnVer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnSubir
            // 
            this.btnSubir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubir.Enabled = false;
            this.btnSubir.FlatAppearance.BorderSize = 2;
            this.btnSubir.Image = global::GUILayer.Properties.Resources.acrobat;
            this.btnSubir.Location = new System.Drawing.Point(223, 432);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(90, 40);
            this.btnSubir.TabIndex = 19;
            this.btnSubir.Text = "Subir PDF";
            this.btnSubir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubir.UseVisualStyleBackColor = false;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
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
            // frmAdministracionArqueos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 480);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbArqueos);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionArqueos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Arqueos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbArqueos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArqueos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label lblArqueos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbArqueos;
        private System.Windows.Forms.DataGridView dgvArqueos;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.OpenFileDialog ofdArchivo;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResponsable;
    }
}