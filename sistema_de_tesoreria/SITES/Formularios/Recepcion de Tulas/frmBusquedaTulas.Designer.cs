namespace GUILayer
{
    partial class frmBusquedaTulas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaTulas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTulaBuscada = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodigoBuscado = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblReceptor = new System.Windows.Forms.Label();
            this.txtReceptor = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblCodigoManifiesto = new System.Windows.Forms.Label();
            this.gbDatosTula = new System.Windows.Forms.GroupBox();
            this.lblCajeroAsignado = new System.Windows.Forms.Label();
            this.txtCajeroAsignado = new System.Windows.Forms.TextBox();
            this.txtCodigoTula = new System.Windows.Forms.TextBox();
            this.lblCodigoTula = new System.Windows.Forms.Label();
            this.txtFechaIngreso = new System.Windows.Forms.TextBox();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.gbDatosManifiesto.SuspendLayout();
            this.gbDatosTula.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTulaBuscada
            // 
            this.lblTulaBuscada.AutoSize = true;
            this.lblTulaBuscada.Location = new System.Drawing.Point(6, 33);
            this.lblTulaBuscada.Name = "lblTulaBuscada";
            this.lblTulaBuscada.Size = new System.Drawing.Size(43, 13);
            this.lblTulaBuscada.TabIndex = 0;
            this.lblTulaBuscada.Text = "Código:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(820, 59);
            this.pnlFondo.TabIndex = 0;
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
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dgvTulas);
            this.gbBusqueda.Controls.Add(this.txtCodigoBuscado);
            this.gbBusqueda.Controls.Add(this.lblTulaBuscada);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 62);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbBusqueda.Size = new System.Drawing.Size(375, 260);
            this.gbBusqueda.TabIndex = 1;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda de Tulas";
            // 
            // dgvTulas
            // 
            this.dgvTulas.AllowUserToAddRows = false;
            this.dgvTulas.AllowUserToDeleteRows = false;
            this.dgvTulas.AllowUserToOrderColumns = true;
            this.dgvTulas.AllowUserToResizeColumns = false;
            this.dgvTulas.AllowUserToResizeRows = false;
            this.dgvTulas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTulas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTulas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTulas.EnableHeadersVisualStyles = false;
            this.dgvTulas.Location = new System.Drawing.Point(55, 65);
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.ReadOnly = true;
            this.dgvTulas.RowHeadersVisible = false;
            this.dgvTulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulas.Size = new System.Drawing.Size(314, 189);
            this.dgvTulas.TabIndex = 7;
            this.dgvTulas.SelectionChanged += new System.EventHandler(this.dgvTulas_SelectionChanged);
            // 
            // Tula
            // 
            this.Tula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tula.DataPropertyName = "Codigo";
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            // 
            // txtCodigoBuscado
            // 
            this.txtCodigoBuscado.Location = new System.Drawing.Point(55, 29);
            this.txtCodigoBuscado.Name = "txtCodigoBuscado";
            this.txtCodigoBuscado.Size = new System.Drawing.Size(218, 20);
            this.txtCodigoBuscado.TabIndex = 1;
            this.txtCodigoBuscado.TextChanged += new System.EventHandler(this.txtCodigoBuscado_TextChanged);
            this.txtCodigoBuscado.Enter += new System.EventHandler(this.txtCodigoBuscado_Enter);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(279, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCaja
            // 
            this.txtCaja.Location = new System.Drawing.Point(283, 97);
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.ReadOnly = true;
            this.txtCaja.Size = new System.Drawing.Size(106, 20);
            this.txtCaja.TabIndex = 11;
            this.txtCaja.TabStop = false;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(246, 101);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(31, 13);
            this.lblCaja.TabIndex = 10;
            this.lblCaja.Text = "Caja:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(692, 332);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.txtCajeroAsignado);
            this.gbDatosManifiesto.Controls.Add(this.lblCajeroAsignado);
            this.gbDatosManifiesto.Controls.Add(this.txtArea);
            this.gbDatosManifiesto.Controls.Add(this.lblArea);
            this.gbDatosManifiesto.Controls.Add(this.btnGuardar);
            this.gbDatosManifiesto.Controls.Add(this.lblEmpresa);
            this.gbDatosManifiesto.Controls.Add(this.txtEmpresa);
            this.gbDatosManifiesto.Controls.Add(this.lblReceptor);
            this.gbDatosManifiesto.Controls.Add(this.txtReceptor);
            this.gbDatosManifiesto.Controls.Add(this.txtGrupo);
            this.gbDatosManifiesto.Controls.Add(this.txtCaja);
            this.gbDatosManifiesto.Controls.Add(this.lblCaja);
            this.gbDatosManifiesto.Controls.Add(this.txtCodigoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.lblGrupo);
            this.gbDatosManifiesto.Controls.Add(this.lblCodigoManifiesto);
            this.gbDatosManifiesto.Enabled = false;
            this.gbDatosManifiesto.Location = new System.Drawing.Point(393, 145);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(395, 177);
            this.gbDatosManifiesto.TabIndex = 3;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos del Manifiesto";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(283, 19);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(106, 20);
            this.txtArea.TabIndex = 3;
            this.txtArea.TabStop = false;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(245, 23);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Área:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(299, 123);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(9, 75);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 6;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(66, 71);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(323, 20);
            this.txtEmpresa.TabIndex = 7;
            this.txtEmpresa.TabStop = false;
            // 
            // lblReceptor
            // 
            this.lblReceptor.AutoSize = true;
            this.lblReceptor.Location = new System.Drawing.Point(6, 49);
            this.lblReceptor.Name = "lblReceptor";
            this.lblReceptor.Size = new System.Drawing.Size(54, 13);
            this.lblReceptor.TabIndex = 4;
            this.lblReceptor.Text = "Receptor:";
            // 
            // txtReceptor
            // 
            this.txtReceptor.Location = new System.Drawing.Point(66, 45);
            this.txtReceptor.Name = "txtReceptor";
            this.txtReceptor.ReadOnly = true;
            this.txtReceptor.Size = new System.Drawing.Size(323, 20);
            this.txtReceptor.TabIndex = 5;
            this.txtReceptor.TabStop = false;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(66, 97);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(173, 20);
            this.txtGrupo.TabIndex = 9;
            this.txtGrupo.TabStop = false;
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(66, 19);
            this.txtCodigoManifiesto.MaxLength = 50;
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(173, 20);
            this.txtCodigoManifiesto.TabIndex = 1;
            this.txtCodigoManifiesto.Enter += new System.EventHandler(this.txtCodigoManifiesto_Enter);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(21, 101);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 8;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblCodigoManifiesto
            // 
            this.lblCodigoManifiesto.AutoSize = true;
            this.lblCodigoManifiesto.Location = new System.Drawing.Point(17, 23);
            this.lblCodigoManifiesto.Name = "lblCodigoManifiesto";
            this.lblCodigoManifiesto.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiesto.TabIndex = 0;
            this.lblCodigoManifiesto.Text = "Código:";
            // 
            // gbDatosTula
            // 
            this.gbDatosTula.Controls.Add(this.txtCodigoTula);
            this.gbDatosTula.Controls.Add(this.lblCodigoTula);
            this.gbDatosTula.Controls.Add(this.txtFechaIngreso);
            this.gbDatosTula.Controls.Add(this.lblFechaIngreso);
            this.gbDatosTula.Enabled = false;
            this.gbDatosTula.Location = new System.Drawing.Point(391, 65);
            this.gbDatosTula.Name = "gbDatosTula";
            this.gbDatosTula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosTula.Size = new System.Drawing.Size(373, 76);
            this.gbDatosTula.TabIndex = 2;
            this.gbDatosTula.TabStop = false;
            this.gbDatosTula.Text = "Datos de la Tula";
            // 
            // lblCajeroAsignado
            // 
            this.lblCajeroAsignado.AutoSize = true;
            this.lblCajeroAsignado.Location = new System.Drawing.Point(9, 128);
            this.lblCajeroAsignado.Name = "lblCajeroAsignado";
            this.lblCajeroAsignado.Size = new System.Drawing.Size(87, 13);
            this.lblCajeroAsignado.TabIndex = 5;
            this.lblCajeroAsignado.Text = "Cajero Asignado:";
            // 
            // txtCajeroAsignado
            // 
            this.txtCajeroAsignado.Location = new System.Drawing.Point(97, 124);
            this.txtCajeroAsignado.Name = "txtCajeroAsignado";
            this.txtCajeroAsignado.ReadOnly = true;
            this.txtCajeroAsignado.Size = new System.Drawing.Size(183, 20);
            this.txtCajeroAsignado.TabIndex = 4;
            this.txtCajeroAsignado.TabStop = false;
            // 
            // txtCodigoTula
            // 
            this.txtCodigoTula.Location = new System.Drawing.Point(113, 16);
            this.txtCodigoTula.Name = "txtCodigoTula";
            this.txtCodigoTula.ReadOnly = true;
            this.txtCodigoTula.Size = new System.Drawing.Size(247, 20);
            this.txtCodigoTula.TabIndex = 1;
            this.txtCodigoTula.TabStop = false;
            // 
            // lblCodigoTula
            // 
            this.lblCodigoTula.AutoSize = true;
            this.lblCodigoTula.Location = new System.Drawing.Point(64, 17);
            this.lblCodigoTula.Name = "lblCodigoTula";
            this.lblCodigoTula.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoTula.TabIndex = 0;
            this.lblCodigoTula.Text = "Código:";
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Location = new System.Drawing.Point(113, 41);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.ReadOnly = true;
            this.txtFechaIngreso.Size = new System.Drawing.Size(247, 20);
            this.txtFechaIngreso.TabIndex = 3;
            this.txtFechaIngreso.TabStop = false;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Location = new System.Drawing.Point(14, 42);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(93, 13);
            this.lblFechaIngreso.TabIndex = 2;
            this.lblFechaIngreso.Text = "Fecha de Ingreso:";
            this.lblFechaIngreso.Click += new System.EventHandler(this.lblFechaIngreso_Click);
            // 
            // frmBusquedaTulas
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.gbDatosTula);
            this.Controls.Add(this.gbDatosManifiesto);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusquedaTulas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Tulas";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            this.gbDatosTula.ResumeLayout(false);
            this.gbDatosTula.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblTulaBuscada;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.TextBox txtCodigoBuscado;
        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblCodigoManifiesto;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblReceptor;
        private System.Windows.Forms.TextBox txtReceptor;
        private System.Windows.Forms.GroupBox gbDatosTula;
        private System.Windows.Forms.TextBox txtFechaIngreso;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.TextBox txtCodigoTula;
        private System.Windows.Forms.Label lblCodigoTula;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtCajeroAsignado;
        private System.Windows.Forms.Label lblCajeroAsignado;
    }
}