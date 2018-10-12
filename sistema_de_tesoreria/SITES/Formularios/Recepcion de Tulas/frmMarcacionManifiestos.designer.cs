namespace GUILayer
{
    partial class frmMarcacionManifiestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarcacionManifiestos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbListaManifiestos = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRecoleccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMarcacion = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbListaManifiestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.gbMarcacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(504, 74);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbListaManifiestos
            // 
            this.gbListaManifiestos.Controls.Add(this.dgvManifiestos);
            this.gbListaManifiestos.Location = new System.Drawing.Point(12, 154);
            this.gbListaManifiestos.Name = "gbListaManifiestos";
            this.gbListaManifiestos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbListaManifiestos.Size = new System.Drawing.Size(463, 355);
            this.gbListaManifiestos.TabIndex = 2;
            this.gbListaManifiestos.TabStop = false;
            this.gbListaManifiestos.Text = "Lista de Manifiestos";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvManifiestos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManifiestos.BackgroundColor = System.Drawing.Color.White;
            this.dgvManifiestos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula,
            this.FechaRecoleccion,
            this.FechaIngreso});
            this.dgvManifiestos.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 19);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvManifiestos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(451, 330);
            this.dgvManifiestos.TabIndex = 0;
            this.dgvManifiestos.SelectionChanged += new System.EventHandler(this.dgvManifiestos_SelectionChanged);
            // 
            // Tula
            // 
            this.Tula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tula.DataPropertyName = "Codigo";
            this.Tula.HeaderText = "Código de Manifiesto";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            // 
            // FechaRecoleccion
            // 
            this.FechaRecoleccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FechaRecoleccion.DataPropertyName = "Fecha_recoleccion";
            this.FechaRecoleccion.HeaderText = "Fecha de Recolección";
            this.FechaRecoleccion.Name = "FechaRecoleccion";
            this.FechaRecoleccion.ReadOnly = true;
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FechaIngreso.DataPropertyName = "Fecha_recepcion";
            this.FechaIngreso.HeaderText = "Fecha de ingreso";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.ReadOnly = true;
            // 
            // gbMarcacion
            // 
            this.gbMarcacion.Controls.Add(this.dtpFecha);
            this.gbMarcacion.Controls.Add(this.lblFecha);
            this.gbMarcacion.Controls.Add(this.btnBuscar);
            this.gbMarcacion.Controls.Add(this.txtCodigoManifiesto);
            this.gbMarcacion.Controls.Add(this.lblManifiesto);
            this.gbMarcacion.Location = new System.Drawing.Point(10, 77);
            this.gbMarcacion.Name = "gbMarcacion";
            this.gbMarcacion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbMarcacion.Size = new System.Drawing.Size(446, 71);
            this.gbMarcacion.TabIndex = 1;
            this.gbMarcacion.TabStop = false;
            this.gbMarcacion.Text = "Marcación de Manifiestos";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Location = new System.Drawing.Point(70, 45);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(274, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(24, 49);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(350, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(70, 19);
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(274, 20);
            this.txtCodigoManifiesto.TabIndex = 1;
            this.txtCodigoManifiesto.TabStop = false;
            this.txtCodigoManifiesto.TextChanged += new System.EventHandler(this.txtCodigoManifiesto_TextChanged);
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(6, 23);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManifiesto.TabIndex = 0;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(379, 515);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Enabled = false;
            this.btnDesmarcar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnDesmarcar.Location = new System.Drawing.Point(275, 515);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(98, 40);
            this.btnDesmarcar.TabIndex = 3;
            this.btnDesmarcar.TabStop = false;
            this.btnDesmarcar.Text = "Desmarcar";
            this.btnDesmarcar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesmarcar.UseVisualStyleBackColor = false;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // btnMarcar
            // 
            this.btnMarcar.Enabled = false;
            this.btnMarcar.Image = ((System.Drawing.Image)(resources.GetObject("btnMarcar.Image")));
            this.btnMarcar.Location = new System.Drawing.Point(275, 515);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(98, 40);
            this.btnMarcar.TabIndex = 4;
            this.btnMarcar.TabStop = false;
            this.btnMarcar.Text = "Marcar";
            this.btnMarcar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMarcar.UseVisualStyleBackColor = false;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // frmMarcacionManifiestos
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(487, 567);
            this.Controls.Add(this.btnMarcar);
            this.Controls.Add(this.btnDesmarcar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbListaManifiestos);
            this.Controls.Add(this.gbMarcacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMarcacionManifiestos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcación de Manifiestos con T Mayor a 1 por Transportadora ";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbListaManifiestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.gbMarcacion.ResumeLayout(false);
            this.gbMarcacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbListaManifiestos;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbMarcacion;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.Button btnMarcar;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRecoleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;

    }
}