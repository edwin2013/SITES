namespace GUILayer
{
    partial class frmCambioAreaManifiesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioAreaManifiesto));
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.txtCajeroAsignado = new System.Windows.Forms.TextBox();
            this.lblCajeroAsignado = new System.Windows.Forms.Label();
            this.cboCajeros = new GUILayer.ComboBoxBusqueda();
            this.txtCajeroReceptor = new System.Windows.Forms.TextBox();
            this.lblCajeroReasingado = new System.Windows.Forms.Label();
            this.lblCajeroRecepcion = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.cboAreas = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiesto = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblReceptor = new System.Windows.Forms.Label();
            this.txtReceptor = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigoBuscado = new System.Windows.Forms.TextBox();
            this.lblManifiestoBuscado = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatosManifiesto.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.txtCajeroAsignado);
            this.gbDatosManifiesto.Controls.Add(this.lblCajeroAsignado);
            this.gbDatosManifiesto.Controls.Add(this.cboCajeros);
            this.gbDatosManifiesto.Controls.Add(this.txtCajeroReceptor);
            this.gbDatosManifiesto.Controls.Add(this.lblCajeroReasingado);
            this.gbDatosManifiesto.Controls.Add(this.lblCajeroRecepcion);
            this.gbDatosManifiesto.Controls.Add(this.lblArea);
            this.gbDatosManifiesto.Controls.Add(this.cboAreas);
            this.gbDatosManifiesto.Controls.Add(this.btnGuardar);
            this.gbDatosManifiesto.Controls.Add(this.txtCodigoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.lblCodigoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.lblEmpresa);
            this.gbDatosManifiesto.Controls.Add(this.txtEmpresa);
            this.gbDatosManifiesto.Controls.Add(this.lblReceptor);
            this.gbDatosManifiesto.Controls.Add(this.txtReceptor);
            this.gbDatosManifiesto.Controls.Add(this.txtGrupo);
            this.gbDatosManifiesto.Controls.Add(this.txtCaja);
            this.gbDatosManifiesto.Controls.Add(this.lblCaja);
            this.gbDatosManifiesto.Controls.Add(this.lblGrupo);
            this.gbDatosManifiesto.Enabled = false;
            this.gbDatosManifiesto.Location = new System.Drawing.Point(12, 281);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(429, 252);
            this.gbDatosManifiesto.TabIndex = 2;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos del Manifiesto";
            // 
            // txtCajeroAsignado
            // 
            this.txtCajeroAsignado.Location = new System.Drawing.Point(118, 152);
            this.txtCajeroAsignado.Name = "txtCajeroAsignado";
            this.txtCajeroAsignado.ReadOnly = true;
            this.txtCajeroAsignado.Size = new System.Drawing.Size(292, 20);
            this.txtCajeroAsignado.TabIndex = 18;
            this.txtCajeroAsignado.TabStop = false;
            // 
            // lblCajeroAsignado
            // 
            this.lblCajeroAsignado.AutoSize = true;
            this.lblCajeroAsignado.Location = new System.Drawing.Point(12, 152);
            this.lblCajeroAsignado.Name = "lblCajeroAsignado";
            this.lblCajeroAsignado.Size = new System.Drawing.Size(90, 13);
            this.lblCajeroAsignado.TabIndex = 17;
            this.lblCajeroAsignado.Text = "Cajero  Asignado:";
            // 
            // cboCajeros
            // 
            this.cboCajeros.Busqueda = true;
            this.cboCajeros.ListaMostrada = null;
            this.cboCajeros.Location = new System.Drawing.Point(118, 178);
            this.cboCajeros.Name = "cboCajeros";
            this.cboCajeros.Size = new System.Drawing.Size(292, 21);
            this.cboCajeros.TabIndex = 16;
            // 
            // txtCajeroReceptor
            // 
            this.txtCajeroReceptor.Location = new System.Drawing.Point(178, 125);
            this.txtCajeroReceptor.Name = "txtCajeroReceptor";
            this.txtCajeroReceptor.ReadOnly = true;
            this.txtCajeroReceptor.Size = new System.Drawing.Size(232, 20);
            this.txtCajeroReceptor.TabIndex = 15;
            this.txtCajeroReceptor.TabStop = false;
            // 
            // lblCajeroReasingado
            // 
            this.lblCajeroReasingado.AutoSize = true;
            this.lblCajeroReasingado.Location = new System.Drawing.Point(12, 181);
            this.lblCajeroReasingado.Name = "lblCajeroReasingado";
            this.lblCajeroReasingado.Size = new System.Drawing.Size(100, 13);
            this.lblCajeroReasingado.TabIndex = 14;
            this.lblCajeroReasingado.Text = "Cajero Reasignado:";
            // 
            // lblCajeroRecepcion
            // 
            this.lblCajeroRecepcion.AutoSize = true;
            this.lblCajeroRecepcion.Location = new System.Drawing.Point(11, 127);
            this.lblCajeroRecepcion.Name = "lblCajeroRecepcion";
            this.lblCajeroRecepcion.Size = new System.Drawing.Size(163, 13);
            this.lblCajeroRecepcion.TabIndex = 13;
            this.lblCajeroRecepcion.Text = "Cajero / Coordinador Recepcion:";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(74, 213);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 10;
            this.lblArea.Text = "Área:";
            // 
            // cboAreas
            // 
            this.cboAreas.Location = new System.Drawing.Point(118, 208);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Size = new System.Drawing.Size(185, 21);
            this.cboAreas.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(321, 205);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(66, 19);
            this.txtCodigoManifiesto.MaxLength = 50;
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.ReadOnly = true;
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(349, 20);
            this.txtCodigoManifiesto.TabIndex = 1;
            // 
            // lblCodigoManifiesto
            // 
            this.lblCodigoManifiesto.AutoSize = true;
            this.lblCodigoManifiesto.Location = new System.Drawing.Point(12, 22);
            this.lblCodigoManifiesto.Name = "lblCodigoManifiesto";
            this.lblCodigoManifiesto.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiesto.TabIndex = 0;
            this.lblCodigoManifiesto.Text = "Código:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(12, 75);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 4;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(66, 71);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(347, 20);
            this.txtEmpresa.TabIndex = 5;
            this.txtEmpresa.TabStop = false;
            // 
            // lblReceptor
            // 
            this.lblReceptor.AutoSize = true;
            this.lblReceptor.Location = new System.Drawing.Point(12, 49);
            this.lblReceptor.Name = "lblReceptor";
            this.lblReceptor.Size = new System.Drawing.Size(54, 13);
            this.lblReceptor.TabIndex = 2;
            this.lblReceptor.Text = "Receptor:";
            // 
            // txtReceptor
            // 
            this.txtReceptor.Location = new System.Drawing.Point(66, 45);
            this.txtReceptor.Name = "txtReceptor";
            this.txtReceptor.ReadOnly = true;
            this.txtReceptor.Size = new System.Drawing.Size(348, 20);
            this.txtReceptor.TabIndex = 3;
            this.txtReceptor.TabStop = false;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(202, 97);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(209, 20);
            this.txtGrupo.TabIndex = 7;
            this.txtGrupo.TabStop = false;
            // 
            // txtCaja
            // 
            this.txtCaja.Location = new System.Drawing.Point(66, 97);
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.ReadOnly = true;
            this.txtCaja.Size = new System.Drawing.Size(92, 20);
            this.txtCaja.TabIndex = 9;
            this.txtCaja.TabStop = false;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(12, 100);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(31, 13);
            this.lblCaja.TabIndex = 8;
            this.lblCaja.Text = "Caja:";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(162, 100);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 6;
            this.lblGrupo.Text = "Grupo:";
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dgvManifiestos);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Controls.Add(this.txtCodigoBuscado);
            this.gbBusqueda.Controls.Add(this.lblManifiestoBuscado);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 62);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbBusqueda.Size = new System.Drawing.Size(432, 212);
            this.gbBusqueda.TabIndex = 1;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda de Manifiestos";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToOrderColumns = true;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manifiesto});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(24, 65);
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(386, 135);
            this.dgvManifiestos.TabIndex = 3;
            this.dgvManifiestos.SelectionChanged += new System.EventHandler(this.dgvManifiestos_SelectionChanged);
            // 
            // Manifiesto
            // 
            this.Manifiesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Manifiesto.DataPropertyName = "Codigo";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.ReadOnly = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(322, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigoBuscado
            // 
            this.txtCodigoBuscado.Location = new System.Drawing.Point(55, 29);
            this.txtCodigoBuscado.Name = "txtCodigoBuscado";
            this.txtCodigoBuscado.Size = new System.Drawing.Size(248, 20);
            this.txtCodigoBuscado.TabIndex = 1;
            this.txtCodigoBuscado.TextChanged += new System.EventHandler(this.txtCodigoBuscado_TextChanged);
            // 
            // lblManifiestoBuscado
            // 
            this.lblManifiestoBuscado.AutoSize = true;
            this.lblManifiestoBuscado.Location = new System.Drawing.Point(6, 33);
            this.lblManifiestoBuscado.Name = "lblManifiestoBuscado";
            this.lblManifiestoBuscado.Size = new System.Drawing.Size(43, 13);
            this.lblManifiestoBuscado.TabIndex = 0;
            this.lblManifiestoBuscado.Text = "Código:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(865, 59);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(387, 50);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(354, 542);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // frmCambioAreaManifiesto
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(456, 591);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.gbDatosManifiesto);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioAreaManifiesto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de Área o Asignacion de Cajero para los Manifiestos";
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblCodigoManifiesto;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblReceptor;
        private System.Windows.Forms.TextBox txtReceptor;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cboAreas;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCodigoBuscado;
        private System.Windows.Forms.Label lblManifiestoBuscado;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TextBox txtCajeroReceptor;
        private System.Windows.Forms.Label lblCajeroReasingado;
        private System.Windows.Forms.Label lblCajeroRecepcion;
        private ComboBoxBusqueda cboCajeros;
        private System.Windows.Forms.TextBox txtCajeroAsignado;
        private System.Windows.Forms.Label lblCajeroAsignado;
       
    }
}