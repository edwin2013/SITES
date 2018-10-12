namespace GUILayer.Formularios.Níquel
{
    partial class frmCargasPendientesNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargasPendientesNiquel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCargasAsignadas = new System.Windows.Forms.GroupBox();
            this.dgvCargasAsignadas = new System.Windows.Forms.DataGridView();
            this.btnSeleccionarTodo = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.SucursalCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEuros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRevisado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargasAsignadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasAsignadas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-5, 6);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(803, 60);
            this.pnlFondo.TabIndex = 16;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbCargasAsignadas
            // 
            this.gbCargasAsignadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargasAsignadas.Controls.Add(this.dgvCargasAsignadas);
            this.gbCargasAsignadas.Location = new System.Drawing.Point(8, 72);
            this.gbCargasAsignadas.Name = "gbCargasAsignadas";
            this.gbCargasAsignadas.Size = new System.Drawing.Size(768, 423);
            this.gbCargasAsignadas.TabIndex = 17;
            this.gbCargasAsignadas.TabStop = false;
            this.gbCargasAsignadas.Text = "Cargas Asignadas al Cajero";
            // 
            // dgvCargasAsignadas
            // 
            this.dgvCargasAsignadas.AllowUserToAddRows = false;
            this.dgvCargasAsignadas.AllowUserToDeleteRows = false;
            this.dgvCargasAsignadas.AllowUserToOrderColumns = true;
            this.dgvCargasAsignadas.AllowUserToResizeColumns = false;
            this.dgvCargasAsignadas.AllowUserToResizeRows = false;
            this.dgvCargasAsignadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargasAsignadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargasAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargasAsignadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SucursalCarga,
            this.FechaCargaAsignada,
            this.MontoColones,
            this.MontoDolares,
            this.MEuros,
            this.clmRevisado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargasAsignadas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCargasAsignadas.EnableHeadersVisualStyles = false;
            this.dgvCargasAsignadas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargasAsignadas.MultiSelect = false;
            this.dgvCargasAsignadas.Name = "dgvCargasAsignadas";
            this.dgvCargasAsignadas.RowHeadersVisible = false;
            this.dgvCargasAsignadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargasAsignadas.Size = new System.Drawing.Size(756, 398);
            this.dgvCargasAsignadas.StandardTab = true;
            this.dgvCargasAsignadas.TabIndex = 0;
            this.dgvCargasAsignadas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCargasAsignadas_RowsAdded);
            this.dgvCargasAsignadas.SelectionChanged += new System.EventHandler(this.dgvCargasAsignadas_SelectionChanged);
            // 
            // btnSeleccionarTodo
            // 
            this.btnSeleccionarTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarTodo.Enabled = false;
            this.btnSeleccionarTodo.FlatAppearance.BorderSize = 2;
            this.btnSeleccionarTodo.Image = global::GUILayer.Properties.Resources.triales;
            this.btnSeleccionarTodo.Location = new System.Drawing.Point(365, 501);
            this.btnSeleccionarTodo.Name = "btnSeleccionarTodo";
            this.btnSeleccionarTodo.Size = new System.Drawing.Size(107, 40);
            this.btnSeleccionarTodo.TabIndex = 19;
            this.btnSeleccionarTodo.Text = "Seleccionar Todo";
            this.btnSeleccionarTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeleccionarTodo.UseVisualStyleBackColor = false;
            this.btnSeleccionarTodo.Click += new System.EventHandler(this.btnMontos_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(478, 501);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 20;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(579, 501);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(95, 40);
            this.btnAceptar.TabIndex = 22;
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
            this.btnCancelar.Location = new System.Drawing.Point(680, 501);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(177, 501);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(93, 40);
            this.btnRevisar.TabIndex = 18;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Visible = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // SucursalCarga
            // 
            this.SucursalCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SucursalCarga.DataPropertyName = "Punto";
            this.SucursalCarga.HeaderText = "Punto";
            this.SucursalCarga.Name = "SucursalCarga";
            this.SucursalCarga.ReadOnly = true;
            this.SucursalCarga.Width = 59;
            // 
            // FechaCargaAsignada
            // 
            this.FechaCargaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaCargaAsignada.DataPropertyName = "Fecha_asignada";
            this.FechaCargaAsignada.HeaderText = "Fecha";
            this.FechaCargaAsignada.Name = "FechaCargaAsignada";
            this.FechaCargaAsignada.ReadOnly = true;
            this.FechaCargaAsignada.Width = 61;
            // 
            // MontoColones
            // 
            this.MontoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColones.DataPropertyName = "Monto_asignado_colones";
            dataGridViewCellStyle1.Format = "N2";
            this.MontoColones.DefaultCellStyle = dataGridViewCellStyle1;
            this.MontoColones.HeaderText = "M. en Colones";
            this.MontoColones.Name = "MontoColones";
            this.MontoColones.ReadOnly = true;
            this.MontoColones.Width = 99;
            // 
            // MontoDolares
            // 
            this.MontoDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolares.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle2.Format = "N2";
            this.MontoDolares.DefaultCellStyle = dataGridViewCellStyle2;
            this.MontoDolares.HeaderText = "M. en Dólares";
            this.MontoDolares.Name = "MontoDolares";
            this.MontoDolares.ReadOnly = true;
            this.MontoDolares.Width = 97;
            // 
            // MEuros
            // 
            this.MEuros.DataPropertyName = "Monto_asignado_euros";
            this.MEuros.HeaderText = "M. en Euros";
            this.MEuros.Name = "MEuros";
            this.MEuros.ReadOnly = true;
            // 
            // clmRevisado
            // 
            this.clmRevisado.HeaderText = "Seleccionar";
            this.clmRevisado.Name = "clmRevisado";
            // 
            // frmCargasPendientesNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 546);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCargasAsignadas);
            this.Controls.Add(this.btnSeleccionarTodo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRevisar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargasPendientesNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargas Pendientes Níquel";
            this.Load += new System.EventHandler(this.frmCargasPendientes_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargasAsignadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasAsignadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCargasAsignadas;
        private System.Windows.Forms.DataGridView dgvCargasAsignadas;
        private System.Windows.Forms.Button btnSeleccionarTodo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.DataGridViewTextBoxColumn SucursalCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEuros;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmRevisado;
    }
}