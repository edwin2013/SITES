namespace GUILayer
{
    partial class frmBusquedaManifiestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaManifiestos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCodigoBuscado = new System.Windows.Forms.TextBox();
            this.lblManifiestoBuscado = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbTulas = new System.Windows.Forms.GroupBox();
            this.dgvTulasManifiesto = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRecepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
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
            this.txtCajeroAsignado = new System.Windows.Forms.TextBox();
            this.lblCajeroAsignado = new System.Windows.Forms.Label();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbTulas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasManifiesto)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.gbDatosManifiesto.SuspendLayout();
            this.SuspendLayout();
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
            this.gbTulas.Location = new System.Drawing.Point(393, 237);
            this.gbTulas.Name = "gbTulas";
            this.gbTulas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbTulas.Size = new System.Drawing.Size(395, 163);
            this.gbTulas.TabIndex = 3;
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
            this.Tula,
            this.FechaRecepcion});
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
            this.dgvTulasManifiesto.Location = new System.Drawing.Point(6, 19);
            this.dgvTulasManifiesto.MultiSelect = false;
            this.dgvTulasManifiesto.Name = "dgvTulasManifiesto";
            this.dgvTulasManifiesto.ReadOnly = true;
            this.dgvTulasManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvTulasManifiesto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTulasManifiesto.RowHeadersVisible = false;
            this.dgvTulasManifiesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulasManifiesto.Size = new System.Drawing.Size(383, 138);
            this.dgvTulasManifiesto.TabIndex = 0;
            this.dgvTulasManifiesto.TabStop = false;
            // 
            // Tula
            // 
            this.Tula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tula.DataPropertyName = "Codigo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tula.DefaultCellStyle = dataGridViewCellStyle3;
            this.Tula.HeaderText = "Código de Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            // 
            // FechaRecepcion
            // 
            this.FechaRecepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FechaRecepcion.DataPropertyName = "fecha_ingreso";
            this.FechaRecepcion.HeaderText = "Fecha de Recepción";
            this.FechaRecepcion.Name = "FechaRecepcion";
            this.FechaRecepcion.ReadOnly = true;
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
            this.gbBusqueda.Size = new System.Drawing.Size(375, 338);
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
            this.dgvManifiestos.Location = new System.Drawing.Point(55, 65);
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(314, 267);
            this.dgvManifiestos.TabIndex = 4;
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
            this.btnBuscar.Location = new System.Drawing.Point(279, 19);
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
            this.btnSalir.Location = new System.Drawing.Point(692, 406);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.TabStop = false;
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
            this.gbDatosManifiesto.Location = new System.Drawing.Point(393, 62);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(395, 169);
            this.gbDatosManifiesto.TabIndex = 2;
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
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(66, 19);
            this.txtCodigoManifiesto.MaxLength = 50;
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(173, 20);
            this.txtCodigoManifiesto.TabIndex = 1;
            this.txtCodigoManifiesto.Enter += new System.EventHandler(this.txtCodigoManifiesto_Enter);
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
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(21, 101);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 8;
            this.lblGrupo.Text = "Grupo:";
            // 
            // txtCajeroAsignado
            // 
            this.txtCajeroAsignado.Location = new System.Drawing.Point(92, 124);
            this.txtCajeroAsignado.Name = "txtCajeroAsignado";
            this.txtCajeroAsignado.ReadOnly = true;
            this.txtCajeroAsignado.Size = new System.Drawing.Size(191, 20);
            this.txtCajeroAsignado.TabIndex = 13;
            this.txtCajeroAsignado.TabStop = false;
            // 
            // lblCajeroAsignado
            // 
            this.lblCajeroAsignado.AutoSize = true;
            this.lblCajeroAsignado.Location = new System.Drawing.Point(2, 127);
            this.lblCajeroAsignado.Name = "lblCajeroAsignado";
            this.lblCajeroAsignado.Size = new System.Drawing.Size(87, 13);
            this.lblCajeroAsignado.TabIndex = 14;
            this.lblCajeroAsignado.Text = "Cajero Asignado:";
            // 
            // frmBusquedaManifiestos
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.gbDatosManifiesto);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbTulas);
            this.Controls.Add(this.gbBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusquedaManifiestos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Manifiestos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbTulas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasManifiesto)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtCodigoBuscado;
        private System.Windows.Forms.Label lblManifiestoBuscado;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbTulas;
        private System.Windows.Forms.DataGridView dgvTulasManifiesto;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblReceptor;
        private System.Windows.Forms.TextBox txtReceptor;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRecepcion;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblCodigoManifiesto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtCajeroAsignado;
        private System.Windows.Forms.Label lblCajeroAsignado;
    }
}