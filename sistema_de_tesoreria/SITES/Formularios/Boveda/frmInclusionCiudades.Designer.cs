namespace GUILayer
{
    partial class frmInclusionCiudades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInclusionCiudades));
            this.gbCiudades = new System.Windows.Forms.GroupBox();
            this.cboProvincias = new System.Windows.Forms.ComboBox();
            this.lblCiudades = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAgregarCiudad = new System.Windows.Forms.Button();
            this.dgvCiudades = new System.Windows.Forms.DataGridView();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCiudades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudades)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCiudades
            // 
            this.gbCiudades.Controls.Add(this.cboProvincias);
            this.gbCiudades.Controls.Add(this.lblCiudades);
            this.gbCiudades.Controls.Add(this.lblProvincia);
            this.gbCiudades.Controls.Add(this.txtNombre);
            this.gbCiudades.Controls.Add(this.btnAgregarCiudad);
            this.gbCiudades.Controls.Add(this.dgvCiudades);
            this.gbCiudades.Controls.Add(this.lblNombre);
            this.gbCiudades.Location = new System.Drawing.Point(12, 46);
            this.gbCiudades.Name = "gbCiudades";
            this.gbCiudades.Size = new System.Drawing.Size(317, 303);
            this.gbCiudades.TabIndex = 1;
            this.gbCiudades.TabStop = false;
            this.gbCiudades.Text = "Ciudades";

            // 
            // cboProvincias
            // 
            this.cboProvincias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincias.FormattingEnabled = true;
            this.cboProvincias.Items.AddRange(new object[] {
            "Alajuela",
            "Cartago",
            "Guanacaste",
            "Heredia",
            "Limón",
            "Puntarenas",
            "San José"});
            this.cboProvincias.Location = new System.Drawing.Point(66, 45);
            this.cboProvincias.Name = "cboProvincias";
            this.cboProvincias.Size = new System.Drawing.Size(245, 21);
            this.cboProvincias.TabIndex = 3;
            this.cboProvincias.SelectedIndexChanged += new System.EventHandler(this.cboProvincias_SelectedIndexChanged);
            // 
            // lblCiudades
            // 
            this.lblCiudades.AutoSize = true;
            this.lblCiudades.Location = new System.Drawing.Point(6, 118);
            this.lblCiudades.Name = "lblCiudades";
            this.lblCiudades.Size = new System.Drawing.Size(54, 13);
            this.lblCiudades.TabIndex = 5;
            this.lblCiudades.Text = "Ciudades:";

            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(6, 49);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(54, 13);
            this.lblProvincia.TabIndex = 2;
            this.lblProvincia.Text = "Provincia:";
   
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(66, 19);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(245, 20);
            this.txtNombre.TabIndex = 1;

            // 
            // btnAgregarCiudad
            // 
            this.btnAgregarCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCiudad.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarCiudad.Location = new System.Drawing.Point(221, 72);
            this.btnAgregarCiudad.Name = "btnAgregarCiudad";
            this.btnAgregarCiudad.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarCiudad.TabIndex = 4;
            this.btnAgregarCiudad.Text = "Agregar";
            this.btnAgregarCiudad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarCiudad.UseVisualStyleBackColor = true;
            this.btnAgregarCiudad.Click += new System.EventHandler(this.btnAgregarCiudad_Click);
            // 
            // dgvCiudades
            // 
            this.dgvCiudades.AllowUserToAddRows = false;
            this.dgvCiudades.AllowUserToDeleteRows = false;
            this.dgvCiudades.AllowUserToOrderColumns = true;
            this.dgvCiudades.AllowUserToResizeColumns = false;
            this.dgvCiudades.AllowUserToResizeRows = false;
            this.dgvCiudades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCiudades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiudades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ciudad});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCiudades.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCiudades.EnableHeadersVisualStyles = false;
            this.dgvCiudades.Location = new System.Drawing.Point(66, 118);
            this.dgvCiudades.Name = "dgvCiudades";
            this.dgvCiudades.ReadOnly = true;
            this.dgvCiudades.RowHeadersVisible = false;
            this.dgvCiudades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCiudades.Size = new System.Drawing.Size(245, 179);
            this.dgvCiudades.TabIndex = 6;

            // 
            // Ciudad
            // 
            this.Ciudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ciudad.DataPropertyName = "Nombre";
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(13, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";

            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(233, 355);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(359, 43);
            this.pnlFondo.TabIndex = 0;

            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(319, 39);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;

            // 
            // frmInclusionCiudades
            // 
            this.AcceptButton = this.btnAgregarCiudad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(341, 407);
            this.Controls.Add(this.gbCiudades);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInclusionCiudades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Ciudad";
            this.gbCiudades.ResumeLayout(false);
            this.gbCiudades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudades)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCiudades;
        private System.Windows.Forms.Label lblCiudades;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAgregarCiudad;
        private System.Windows.Forms.DataGridView dgvCiudades;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ComboBox cboProvincias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
    }
}