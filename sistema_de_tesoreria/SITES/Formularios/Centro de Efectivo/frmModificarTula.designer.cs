namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmModificarTula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarTula));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbTulas = new System.Windows.Forms.GroupBox();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCambioCodigoTula = new System.Windows.Forms.GroupBox();
            this.txtCodigoTulaNuevo = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiestoNuevo = new System.Windows.Forms.Label();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTulas.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCambioCodigoTula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTulas
            // 
            this.gbTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTulas.Controls.Add(this.dgvTulas);
            this.gbTulas.Location = new System.Drawing.Point(18, 134);
            this.gbTulas.Name = "gbTulas";
            this.gbTulas.Size = new System.Drawing.Size(436, 231);
            this.gbTulas.TabIndex = 13;
            this.gbTulas.TabStop = false;
            this.gbTulas.Text = "Tulas";
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.btnActualizar);
            this.gbBusqueda.Controls.Add(this.lblFecha);
            this.gbBusqueda.Controls.Add(this.dtpFecha);
            this.gbBusqueda.Location = new System.Drawing.Point(8, 68);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(446, 60);
            this.gbBusqueda.TabIndex = 12;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Filtrar Búsqueda";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(342, 11);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(16, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(76, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha del día:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(98, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(111, 442);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(290, 442);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(4, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(450, 60);
            this.pnlFondo.TabIndex = 9;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(3, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(400, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbCambioCodigoTula
            // 
            this.gbCambioCodigoTula.Controls.Add(this.txtCodigoTulaNuevo);
            this.gbCambioCodigoTula.Controls.Add(this.lblCodigoManifiestoNuevo);
            this.gbCambioCodigoTula.Enabled = false;
            this.gbCambioCodigoTula.Location = new System.Drawing.Point(18, 371);
            this.gbCambioCodigoTula.Name = "gbCambioCodigoTula";
            this.gbCambioCodigoTula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbCambioCodigoTula.Size = new System.Drawing.Size(430, 65);
            this.gbCambioCodigoTula.TabIndex = 14;
            this.gbCambioCodigoTula.TabStop = false;
            this.gbCambioCodigoTula.Text = "Cambio del código de Tula";
            // 
            // txtCodigoTulaNuevo
            // 
            this.txtCodigoTulaNuevo.BackColor = System.Drawing.Color.White;
            this.txtCodigoTulaNuevo.Location = new System.Drawing.Point(77, 27);
            this.txtCodigoTulaNuevo.Name = "txtCodigoTulaNuevo";
            this.txtCodigoTulaNuevo.Size = new System.Drawing.Size(324, 20);
            this.txtCodigoTulaNuevo.TabIndex = 1;
            // 
            // lblCodigoManifiestoNuevo
            // 
            this.lblCodigoManifiestoNuevo.AutoSize = true;
            this.lblCodigoManifiestoNuevo.Location = new System.Drawing.Point(28, 30);
            this.lblCodigoManifiestoNuevo.Name = "lblCodigoManifiestoNuevo";
            this.lblCodigoManifiestoNuevo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiestoNuevo.TabIndex = 0;
            this.lblCodigoManifiestoNuevo.Text = "Código:";
            // 
            // dgvTulas
            // 
            this.dgvTulas.AllowUserToAddRows = false;
            this.dgvTulas.AllowUserToDeleteRows = false;
            this.dgvTulas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTulas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTulas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Tula});
            this.dgvTulas.EnableHeadersVisualStyles = false;
            this.dgvTulas.Location = new System.Drawing.Point(9, 19);
            this.dgvTulas.MultiSelect = false;
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.ReadOnly = true;
            this.dgvTulas.RowHeadersVisible = false;
            this.dgvTulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulas.Size = new System.Drawing.Size(413, 198);
            this.dgvTulas.TabIndex = 1;
            this.dgvTulas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTulas_CellContentClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // Tula
            // 
            this.Tula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tula.DataPropertyName = "Codigo";
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            this.Tula.Width = 52;
            // 
            // frmModificarTula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 496);
            this.Controls.Add(this.gbCambioCodigoTula);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbTulas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmModificarTula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Modificar Tula";
            this.Load += new System.EventHandler(this.frmModificarTula_Load);
            this.gbTulas.ResumeLayout(false);
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCambioCodigoTula.ResumeLayout(false);
            this.gbCambioCodigoTula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTulas;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCambioCodigoTula;
        private System.Windows.Forms.TextBox txtCodigoTulaNuevo;
        private System.Windows.Forms.Label lblCodigoManifiestoNuevo;
        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
    }
}