namespace GUILayer
{
    partial class frmMantenimientoATMs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoATMs));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblOficinas = new System.Windows.Forms.Label();
            this.txtOficinas = new System.Windows.Forms.TextBox();
            this.chkVIP = new System.Windows.Forms.CheckBox();
            this.chkExterno = new System.Windows.Forms.CheckBox();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.chkENA = new System.Windows.Forms.CheckBox();
            this.lblCartuchos = new System.Windows.Forms.Label();
            this.nudCartuchos = new System.Windows.Forms.NumericUpDown();
            this.pnlSucursal = new System.Windows.Forms.Panel();
            this.cboSucursal = new GUILayer.ComboBoxBusqueda();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.chkCartuchoRechazo = new System.Windows.Forms.CheckBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.mtbNumero = new System.Windows.Forms.MaskedTextBox();
            this.pnlUbicacion = new System.Windows.Forms.Panel();
            this.cboUbicacion = new GUILayer.ComboBoxBusqueda();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cboTipoUbicacion = new System.Windows.Forms.ComboBox();
            this.lblTipoUbicacion = new System.Windows.Forms.Label();
            this.chkFull = new System.Windows.Forms.CheckBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDiasCarga = new System.Windows.Forms.GroupBox();
            this.lblPeriodoCarga = new System.Windows.Forms.Label();
            this.nudPeriodoCarga = new System.Windows.Forms.NumericUpDown();
            this.clbDiasCarga = new System.Windows.Forms.CheckedListBox();
            this.rbCargaDiasFijos = new System.Windows.Forms.RadioButton();
            this.rbCargaPeriodica = new System.Windows.Forms.RadioButton();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCartuchos)).BeginInit();
            this.pnlSucursal.SuspendLayout();
            this.pnlUbicacion.SuspendLayout();
            this.gbDiasCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(171, 446);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(375, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(358, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblOficinas);
            this.gbDatos.Controls.Add(this.txtOficinas);
            this.gbDatos.Controls.Add(this.chkVIP);
            this.gbDatos.Controls.Add(this.chkExterno);
            this.gbDatos.Controls.Add(this.cboTransportadora);
            this.gbDatos.Controls.Add(this.lblTransportadora);
            this.gbDatos.Controls.Add(this.chkENA);
            this.gbDatos.Controls.Add(this.lblCartuchos);
            this.gbDatos.Controls.Add(this.nudCartuchos);
            this.gbDatos.Controls.Add(this.pnlSucursal);
            this.gbDatos.Controls.Add(this.chkCartuchoRechazo);
            this.gbDatos.Controls.Add(this.cboTipo);
            this.gbDatos.Controls.Add(this.mtbNumero);
            this.gbDatos.Controls.Add(this.pnlUbicacion);
            this.gbDatos.Controls.Add(this.lblCodigo);
            this.gbDatos.Controls.Add(this.txtCodigo);
            this.gbDatos.Controls.Add(this.cboTipoUbicacion);
            this.gbDatos.Controls.Add(this.lblTipoUbicacion);
            this.gbDatos.Controls.Add(this.chkFull);
            this.gbDatos.Controls.Add(this.lblTipo);
            this.gbDatos.Controls.Add(this.lblNumero);
            this.gbDatos.Location = new System.Drawing.Point(12, 66);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(351, 231);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del ATM";
            // 
            // lblOficinas
            // 
            this.lblOficinas.AutoSize = true;
            this.lblOficinas.Location = new System.Drawing.Point(55, 129);
            this.lblOficinas.Name = "lblOficinas";
            this.lblOficinas.Size = new System.Drawing.Size(48, 13);
            this.lblOficinas.TabIndex = 9;
            this.lblOficinas.Text = "Oficinas:";
            // 
            // txtOficinas
            // 
            this.txtOficinas.Location = new System.Drawing.Point(109, 125);
            this.txtOficinas.MaxLength = 13;
            this.txtOficinas.Name = "txtOficinas";
            this.txtOficinas.Size = new System.Drawing.Size(236, 20);
            this.txtOficinas.TabIndex = 10;
            // 
            // chkVIP
            // 
            this.chkVIP.AutoSize = true;
            this.chkVIP.Location = new System.Drawing.Point(54, 208);
            this.chkVIP.Name = "chkVIP";
            this.chkVIP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVIP.Size = new System.Drawing.Size(43, 17);
            this.chkVIP.TabIndex = 17;
            this.chkVIP.Text = "VIP";
            this.chkVIP.UseVisualStyleBackColor = true;
            // 
            // chkExterno
            // 
            this.chkExterno.AutoSize = true;
            this.chkExterno.Location = new System.Drawing.Point(283, 75);
            this.chkExterno.Name = "chkExterno";
            this.chkExterno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkExterno.Size = new System.Drawing.Size(62, 17);
            this.chkExterno.TabIndex = 6;
            this.chkExterno.Text = "Externo";
            this.chkExterno.UseVisualStyleBackColor = true;
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = false;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(109, 73);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(168, 21);
            this.cboTransportadora.TabIndex = 5;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(21, 77);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 4;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // chkENA
            // 
            this.chkENA.AutoSize = true;
            this.chkENA.Location = new System.Drawing.Point(297, 208);
            this.chkENA.Name = "chkENA";
            this.chkENA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkENA.Size = new System.Drawing.Size(48, 17);
            this.chkENA.TabIndex = 20;
            this.chkENA.Text = "ENA";
            this.chkENA.UseVisualStyleBackColor = true;
            // 
            // lblCartuchos
            // 
            this.lblCartuchos.AutoSize = true;
            this.lblCartuchos.Location = new System.Drawing.Point(45, 181);
            this.lblCartuchos.Name = "lblCartuchos";
            this.lblCartuchos.Size = new System.Drawing.Size(58, 13);
            this.lblCartuchos.TabIndex = 15;
            this.lblCartuchos.Text = "Cartuchos:";
            // 
            // nudCartuchos
            // 
            this.nudCartuchos.Location = new System.Drawing.Point(109, 177);
            this.nudCartuchos.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudCartuchos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCartuchos.Name = "nudCartuchos";
            this.nudCartuchos.Size = new System.Drawing.Size(90, 20);
            this.nudCartuchos.TabIndex = 16;
            this.nudCartuchos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlSucursal
            // 
            this.pnlSucursal.Controls.Add(this.cboSucursal);
            this.pnlSucursal.Controls.Add(this.lblSucursal);
            this.pnlSucursal.Location = new System.Drawing.Point(0, 46);
            this.pnlSucursal.Name = "pnlSucursal";
            this.pnlSucursal.Size = new System.Drawing.Size(351, 21);
            this.pnlSucursal.TabIndex = 2;
            // 
            // cboSucursal
            // 
            this.cboSucursal.Busqueda = false;
            this.cboSucursal.ListaMostrada = null;
            this.cboSucursal.Location = new System.Drawing.Point(109, 0);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(236, 21);
            this.cboSucursal.TabIndex = 1;
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(52, 4);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(51, 13);
            this.lblSucursal.TabIndex = 0;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // chkCartuchoRechazo
            // 
            this.chkCartuchoRechazo.AutoSize = true;
            this.chkCartuchoRechazo.Location = new System.Drawing.Point(108, 208);
            this.chkCartuchoRechazo.Name = "chkCartuchoRechazo";
            this.chkCartuchoRechazo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCartuchoRechazo.Size = new System.Drawing.Size(109, 17);
            this.chkCartuchoRechazo.TabIndex = 18;
            this.chkCartuchoRechazo.Text = "Cart. de Rechazo";
            this.chkCartuchoRechazo.UseVisualStyleBackColor = true;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Opteva",
            "Diebold"});
            this.cboTipo.Location = new System.Drawing.Point(242, 151);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(103, 21);
            this.cboTipo.TabIndex = 14;
            // 
            // mtbNumero
            // 
            this.mtbNumero.Location = new System.Drawing.Point(109, 151);
            this.mtbNumero.Mask = "9999";
            this.mtbNumero.Name = "mtbNumero";
            this.mtbNumero.Size = new System.Drawing.Size(90, 20);
            this.mtbNumero.TabIndex = 12;
            // 
            // pnlUbicacion
            // 
            this.pnlUbicacion.Controls.Add(this.cboUbicacion);
            this.pnlUbicacion.Controls.Add(this.lblUbicacion);
            this.pnlUbicacion.Location = new System.Drawing.Point(0, 46);
            this.pnlUbicacion.Name = "pnlUbicacion";
            this.pnlUbicacion.Size = new System.Drawing.Size(351, 21);
            this.pnlUbicacion.TabIndex = 3;
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.Busqueda = false;
            this.cboUbicacion.ListaMostrada = null;
            this.cboUbicacion.Location = new System.Drawing.Point(109, 0);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(236, 21);
            this.cboUbicacion.TabIndex = 1;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(45, 4);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(58, 13);
            this.lblUbicacion.TabIndex = 0;
            this.lblUbicacion.Text = "Ubicación:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(60, 104);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 7;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(109, 100);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(236, 20);
            this.txtCodigo.TabIndex = 8;
            // 
            // cboTipoUbicacion
            // 
            this.cboTipoUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoUbicacion.FormattingEnabled = true;
            this.cboTipoUbicacion.Items.AddRange(new object[] {
            "Sucursal",
            "Ubicación Independiente"});
            this.cboTipoUbicacion.Location = new System.Drawing.Point(109, 19);
            this.cboTipoUbicacion.Name = "cboTipoUbicacion";
            this.cboTipoUbicacion.Size = new System.Drawing.Size(236, 21);
            this.cboTipoUbicacion.TabIndex = 1;
            this.cboTipoUbicacion.SelectedIndexChanged += new System.EventHandler(this.cboTipoUbicacion_SelectedIndexChanged);
            // 
            // lblTipoUbicacion
            // 
            this.lblTipoUbicacion.AutoSize = true;
            this.lblTipoUbicacion.Location = new System.Drawing.Point(6, 23);
            this.lblTipoUbicacion.Name = "lblTipoUbicacion";
            this.lblTipoUbicacion.Size = new System.Drawing.Size(97, 13);
            this.lblTipoUbicacion.TabIndex = 0;
            this.lblTipoUbicacion.Text = "Tipo de Ubicación:";
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.Location = new System.Drawing.Point(223, 208);
            this.chkFull.Name = "chkFull";
            this.chkFull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFull.Size = new System.Drawing.Size(68, 17);
            this.chkFull.TabIndex = 19;
            this.chkFull.Text = "ATM Full";
            this.chkFull.UseVisualStyleBackColor = true;
            this.chkFull.CheckedChanged += new System.EventHandler(this.chkFull_CheckedChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(205, 155);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 13;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(56, 155);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 11;
            this.lblNumero.Text = "Número:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(267, 446);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbDiasCarga
            // 
            this.gbDiasCarga.Controls.Add(this.lblPeriodoCarga);
            this.gbDiasCarga.Controls.Add(this.nudPeriodoCarga);
            this.gbDiasCarga.Controls.Add(this.clbDiasCarga);
            this.gbDiasCarga.Controls.Add(this.rbCargaDiasFijos);
            this.gbDiasCarga.Controls.Add(this.rbCargaPeriodica);
            this.gbDiasCarga.Location = new System.Drawing.Point(12, 303);
            this.gbDiasCarga.Name = "gbDiasCarga";
            this.gbDiasCarga.Size = new System.Drawing.Size(351, 137);
            this.gbDiasCarga.TabIndex = 2;
            this.gbDiasCarga.TabStop = false;
            this.gbDiasCarga.Text = "Días de Carga";
            // 
            // lblPeriodoCarga
            // 
            this.lblPeriodoCarga.AutoSize = true;
            this.lblPeriodoCarga.Location = new System.Drawing.Point(172, 23);
            this.lblPeriodoCarga.Name = "lblPeriodoCarga";
            this.lblPeriodoCarga.Size = new System.Drawing.Size(30, 13);
            this.lblPeriodoCarga.TabIndex = 2;
            this.lblPeriodoCarga.Text = "Días";
            // 
            // nudPeriodoCarga
            // 
            this.nudPeriodoCarga.Enabled = false;
            this.nudPeriodoCarga.Location = new System.Drawing.Point(110, 19);
            this.nudPeriodoCarga.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudPeriodoCarga.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPeriodoCarga.Name = "nudPeriodoCarga";
            this.nudPeriodoCarga.Size = new System.Drawing.Size(56, 20);
            this.nudPeriodoCarga.TabIndex = 1;
            this.nudPeriodoCarga.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // clbDiasCarga
            // 
            this.clbDiasCarga.FormattingEnabled = true;
            this.clbDiasCarga.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.clbDiasCarga.Location = new System.Drawing.Point(6, 67);
            this.clbDiasCarga.MultiColumn = true;
            this.clbDiasCarga.Name = "clbDiasCarga";
            this.clbDiasCarga.Size = new System.Drawing.Size(339, 64);
            this.clbDiasCarga.TabIndex = 4;
            // 
            // rbCargaDiasFijos
            // 
            this.rbCargaDiasFijos.AutoSize = true;
            this.rbCargaDiasFijos.Checked = true;
            this.rbCargaDiasFijos.Location = new System.Drawing.Point(6, 44);
            this.rbCargaDiasFijos.Name = "rbCargaDiasFijos";
            this.rbCargaDiasFijos.Size = new System.Drawing.Size(88, 17);
            this.rbCargaDiasFijos.TabIndex = 3;
            this.rbCargaDiasFijos.TabStop = true;
            this.rbCargaDiasFijos.Text = "En Días Fijos";
            this.rbCargaDiasFijos.UseVisualStyleBackColor = true;
            this.rbCargaDiasFijos.CheckedChanged += new System.EventHandler(this.rbCargaDiasFijos_CheckedChanged);
            // 
            // rbCargaPeriodica
            // 
            this.rbCargaPeriodica.AutoSize = true;
            this.rbCargaPeriodica.Location = new System.Drawing.Point(6, 21);
            this.rbCargaPeriodica.Name = "rbCargaPeriodica";
            this.rbCargaPeriodica.Size = new System.Drawing.Size(98, 17);
            this.rbCargaPeriodica.TabIndex = 0;
            this.rbCargaPeriodica.Text = "Periódicamente";
            this.rbCargaPeriodica.UseVisualStyleBackColor = true;
            this.rbCargaPeriodica.CheckedChanged += new System.EventHandler(this.rbCargaPeriodica_CheckedChanged);
            // 
            // frmMantenimientoATMs
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(375, 498);
            this.Controls.Add(this.gbDiasCarga);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoATMs";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de ATM\'s";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCartuchos)).EndInit();
            this.pnlSucursal.ResumeLayout(false);
            this.pnlSucursal.PerformLayout();
            this.pnlUbicacion.ResumeLayout(false);
            this.pnlUbicacion.PerformLayout();
            this.gbDiasCarga.ResumeLayout(false);
            this.gbDiasCarga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoCarga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox chkFull;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblNumero;
        private ComboBoxBusqueda cboUbicacion;
        private ComboBoxBusqueda cboSucursal;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.ComboBox cboTipoUbicacion;
        private System.Windows.Forms.Label lblTipoUbicacion;
        private System.Windows.Forms.Panel pnlUbicacion;
        private System.Windows.Forms.Panel pnlSucursal;
        private System.Windows.Forms.MaskedTextBox mtbNumero;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.CheckBox chkCartuchoRechazo;
        private System.Windows.Forms.Label lblCartuchos;
        private System.Windows.Forms.NumericUpDown nudCartuchos;
        private System.Windows.Forms.CheckBox chkENA;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.CheckBox chkExterno;
        private System.Windows.Forms.GroupBox gbDiasCarga;
        private System.Windows.Forms.RadioButton rbCargaDiasFijos;
        private System.Windows.Forms.RadioButton rbCargaPeriodica;
        private System.Windows.Forms.Label lblPeriodoCarga;
        private System.Windows.Forms.NumericUpDown nudPeriodoCarga;
        private System.Windows.Forms.CheckedListBox clbDiasCarga;
        private System.Windows.Forms.CheckBox chkVIP;
        private System.Windows.Forms.Label lblOficinas;
        private System.Windows.Forms.TextBox txtOficinas;

    }
}