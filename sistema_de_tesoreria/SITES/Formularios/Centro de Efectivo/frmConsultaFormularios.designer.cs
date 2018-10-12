namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmConsultaFormularios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaFormularios));
            this.cboFormularios = new System.Windows.Forms.ComboBox();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dgvFormularios = new System.Windows.Forms.DataGridView();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.tipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formulario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormularios)).BeginInit();
            this.gbConsulta.SuspendLayout();
            this.gbResultado.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboFormularios
            // 
            this.cboFormularios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormularios.FormattingEnabled = true;
            this.cboFormularios.Items.AddRange(new object[] {
            "Todos los Formularios",
            "F-BAC-CONTROL DIARIO CIERRES CAJEROS",
            "F-BAC-DETALLE DE INCONSISTENCIAS TESORERÍA",
            "F-BAC-CONTROL DIARIO CIERRES CAJERO NIQUEL",
            "F-BAC-BOLETA DE NIQUEL-ENTREGA A CAJERO NIQUEL",
            "F-BAC-BOLETA DE NIQUEL-ENTREGA COLA",
            "F-BAC-INCONSISTENCIAS DE CLIENTES EN MANIFIESTO O PLANILLA DE CONDUCCIÓN",
            "F-BAC-Detalle RECAP BPS"});
            this.cboFormularios.Location = new System.Drawing.Point(107, 31);
            this.cboFormularios.Name = "cboFormularios";
            this.cboFormularios.Size = new System.Drawing.Size(474, 26);
            this.cboFormularios.TabIndex = 31;
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Location = new System.Drawing.Point(17, 34);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(84, 18);
            this.lblFormulario.TabIndex = 30;
            this.lblFormulario.Text = "Formulario:";
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(17, 72);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(56, 18);
            this.lblCajero.TabIndex = 32;
            this.lblCajero.Text = "Cajero:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(107, 105);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(112, 24);
            this.dtpDesde.TabIndex = 35;
            this.dtpDesde.UseWaitCursor = true;
            // 
            // dgvFormularios
            // 
            this.dgvFormularios.AllowUserToAddRows = false;
            this.dgvFormularios.AllowUserToDeleteRows = false;
            this.dgvFormularios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFormularios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFormularios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFormularios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormularios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoDoc,
            this.Id,
            this.Fecha,
            this.Hora,
            this.Cajero,
            this.Cliente,
            this.Formulario,
            this.Descripcion});
            this.dgvFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFormularios.EnableHeadersVisualStyles = false;
            this.dgvFormularios.Location = new System.Drawing.Point(3, 20);
            this.dgvFormularios.MultiSelect = false;
            this.dgvFormularios.Name = "dgvFormularios";
            this.dgvFormularios.ReadOnly = true;
            this.dgvFormularios.RowHeadersVisible = false;
            this.dgvFormularios.RowHeadersWidth = 18;
            this.dgvFormularios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormularios.Size = new System.Drawing.Size(933, 297);
            this.dgvFormularios.TabIndex = 36;
            // 
            // gbConsulta
            // 
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.label2);
            this.gbConsulta.Controls.Add(this.dtpHasta);
            this.gbConsulta.Controls.Add(this.label1);
            this.gbConsulta.Controls.Add(this.btnSalir);
            this.gbConsulta.Controls.Add(this.btnBuscar);
            this.gbConsulta.Controls.Add(this.cboFormularios);
            this.gbConsulta.Controls.Add(this.dtpDesde);
            this.gbConsulta.Controls.Add(this.lblFormulario);
            this.gbConsulta.Controls.Add(this.lblCajero);
            this.gbConsulta.Controls.Add(this.cboCajero);
            this.gbConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConsulta.Location = new System.Drawing.Point(42, 82);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(939, 159);
            this.gbConsulta.TabIndex = 40;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Consulta y Búsqueda";
            this.gbConsulta.Enter += new System.EventHandler(this.gbConsulta_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 46;
            this.label2.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(467, 105);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(112, 24);
            this.dtpHasta.TabIndex = 45;
            this.dtpHasta.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 44;
            this.label1.Text = "Desde:";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(817, 31);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(101, 47);
            this.btnSalir.TabIndex = 40;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(694, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 47);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(107, 69);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(474, 26);
            this.cboCajero.TabIndex = 33;
            // 
            // gbResultado
            // 
            this.gbResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultado.Controls.Add(this.dgvFormularios);
            this.gbResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultado.Location = new System.Drawing.Point(42, 263);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(939, 320);
            this.gbResultado.TabIndex = 42;
            this.gbResultado.TabStop = false;
            this.gbResultado.Text = "Lista de Formularios";
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pictureBox1);
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1029, 60);
            this.pnlFondo.TabIndex = 43;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(425, 57);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = global::GUILayer.Properties.Resources.excel2;
            this.btnGenerar.Location = new System.Drawing.Point(880, 589);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(101, 47);
            this.btnGenerar.TabIndex = 41;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // tipoDoc
            // 
            this.tipoDoc.DataPropertyName = "tipoDoc";
            this.tipoDoc.HeaderText = "tipoDoc";
            this.tipoDoc.Name = "tipoDoc";
            this.tipoDoc.ReadOnly = true;
            this.tipoDoc.Visible = false;
            this.tipoDoc.Width = 65;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 24;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 73;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 65;
            // 
            // Cajero
            // 
            this.Cajero.DataPropertyName = "Cajero";
            this.Cajero.HeaderText = "Cajero";
            this.Cajero.MinimumWidth = 34;
            this.Cajero.Name = "Cajero";
            this.Cajero.ReadOnly = true;
            this.Cajero.Width = 76;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MinimumWidth = 70;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 77;
            // 
            // Formulario
            // 
            this.Formulario.DataPropertyName = "Formulario";
            this.Formulario.HeaderText = "Formulario";
            this.Formulario.MinimumWidth = 300;
            this.Formulario.Name = "Formulario";
            this.Formulario.ReadOnly = true;
            this.Formulario.Width = 300;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 800;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 800;
            // 
            // frmConsultaFormularios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1027, 653);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.gbResultado);
            this.Name = "frmConsultaFormularios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Consulta y reimpresión de formularios";
            this.Load += new System.EventHandler(this.frmConsultaFormularios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormularios)).EndInit();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            this.gbResultado.ResumeLayout(false);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFormularios;
        private System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label lblCajero;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DataGridView dgvFormularios;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formulario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
    }
}