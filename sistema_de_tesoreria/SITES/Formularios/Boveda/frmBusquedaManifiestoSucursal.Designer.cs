namespace GUILayer.Formularios.Boveda
{
    partial class frmBusquedaManifiestoSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaManifiestoSucursal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbTulas = new System.Windows.Forms.GroupBox();
            this.dgvTulasManifiesto = new System.Windows.Forms.DataGridView();
            this.Bolsa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbTulas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasManifiesto)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCajero);
            this.groupBox1.Controls.Add(this.lblCajero);
            this.groupBox1.Controls.Add(this.lblFechaInicio);
            this.groupBox1.Controls.Add(this.dtpFechaCierre);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(10, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.Enabled = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(65, 16);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(260, 21);
            this.cboCajero.TabIndex = 5;
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(19, 20);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 4;
            this.lblCajero.Text = "Cajero:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(19, 47);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(40, 13);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha:";
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCierre.Location = new System.Drawing.Point(65, 43);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(260, 20);
            this.dtpFechaCierre.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(380, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(693, 400);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, -2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(865, 59);
            this.pnlFondo.TabIndex = 11;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(387, 50);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbTulas
            // 
            this.gbTulas.Controls.Add(this.dgvTulasManifiesto);
            this.gbTulas.Location = new System.Drawing.Point(403, 135);
            this.gbTulas.Name = "gbTulas";
            this.gbTulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbTulas.Size = new System.Drawing.Size(380, 261);
            this.gbTulas.TabIndex = 13;
            this.gbTulas.TabStop = false;
            this.gbTulas.Text = "Lista de Tulas";
            // 
            // dgvTulasManifiesto
            // 
            this.dgvTulasManifiesto.AllowUserToAddRows = false;
            this.dgvTulasManifiesto.AllowUserToDeleteRows = false;
            this.dgvTulasManifiesto.AllowUserToResizeColumns = false;
            this.dgvTulasManifiesto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTulasManifiesto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTulasManifiesto.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvTulasManifiesto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTulasManifiesto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTulasManifiesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulasManifiesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bolsa});
            this.dgvTulasManifiesto.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTulasManifiesto.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTulasManifiesto.EnableHeadersVisualStyles = false;
            this.dgvTulasManifiesto.Location = new System.Drawing.Point(7, 17);
            this.dgvTulasManifiesto.MultiSelect = false;
            this.dgvTulasManifiesto.Name = "dgvTulasManifiesto";
            this.dgvTulasManifiesto.ReadOnly = true;
            this.dgvTulasManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvTulasManifiesto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTulasManifiesto.RowHeadersVisible = false;
            this.dgvTulasManifiesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulasManifiesto.Size = new System.Drawing.Size(366, 229);
            this.dgvTulasManifiesto.TabIndex = 0;
            this.dgvTulasManifiesto.TabStop = false;
            // 
            // Bolsa
            // 
            this.Bolsa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Bolsa.DataPropertyName = "SerieBolsa";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Bolsa.DefaultCellStyle = dataGridViewCellStyle3;
            this.Bolsa.HeaderText = "Código de Tula";
            this.Bolsa.Name = "Bolsa";
            this.Bolsa.ReadOnly = true;
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dgvManifiestos);
            this.gbBusqueda.Location = new System.Drawing.Point(13, 135);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbBusqueda.Size = new System.Drawing.Size(375, 261);
            this.gbBusqueda.TabIndex = 12;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Lista Manifiestos";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToOrderColumns = true;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manifiesto});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 17);
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(363, 232);
            this.dgvManifiestos.TabIndex = 4;
            // 
            // Manifiesto
            // 
            this.Manifiesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Manifiesto.DataPropertyName = "ID";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.ReadOnly = true;
            // 
            // frmBusquedaManifiestoSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbTulas);
            this.Controls.Add(this.gbBusqueda);
            this.Name = "frmBusquedaManifiestoSucursal";
            this.Text = "frmBusquedaManifiestoSucursal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbTulas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasManifiesto)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbTulas;
        private System.Windows.Forms.DataGridView dgvTulasManifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bolsa;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;

    }
}