namespace GUILayer
{
    partial class frmMantenimientoInconsistenciasDigitadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoInconsistenciasDigitadores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDetallesDeposito = new System.Windows.Forms.GroupBox();
            this.dgvDepositos = new System.Windows.Forms.DataGridView();
            this.Deposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificarDeposito = new System.Windows.Forms.Button();
            this.btnAgregarDeposito = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtDeposito = new System.Windows.Forms.TextBox();
            this.chkMonto = new System.Windows.Forms.CheckBox();
            this.chkReferencia = new System.Windows.Forms.CheckBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCoordinador = new System.Windows.Forms.Label();
            this.txtCoordinador = new System.Windows.Forms.TextBox();
            this.chkCuenta = new System.Windows.Forms.CheckBox();
            this.chkMoneda = new System.Windows.Forms.CheckBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.mtbReferencia = new System.Windows.Forms.MaskedTextBox();
            this.mtbCuenta = new System.Windows.Forms.MaskedTextBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.gbDatosErroneos = new System.Windows.Forms.GroupBox();
            this.gbDetalles = new System.Windows.Forms.GroupBox();
            this.btnAgregarPuntoVenta = new System.Windows.Forms.Button();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.lblT = new System.Windows.Forms.Label();
            this.cboDigitador = new GUILayer.ComboBoxBusqueda();
            this.nudT = new System.Windows.Forms.NumericUpDown();
            this.lblDigitador = new System.Windows.Forms.Label();
            this.gbInconsistenciaROE = new System.Windows.Forms.GroupBox();
            this.chkROECedulaIncorrecta = new System.Windows.Forms.CheckBox();
            this.chkROEOrigenIncorrecto = new System.Windows.Forms.CheckBox();
            this.chkROECuentaIncorrecta = new System.Windows.Forms.CheckBox();
            this.chkROEReimpresion = new System.Windows.Forms.CheckBox();
            this.chkROEFirma = new System.Windows.Forms.CheckBox();
            this.chkROESello = new System.Windows.Forms.CheckBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDetallesDeposito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.gbDatosErroneos.SuspendLayout();
            this.gbDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudT)).BeginInit();
            this.gbInconsistenciaROE.SuspendLayout();
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
            this.pnlFondo.Size = new System.Drawing.Size(484, 48);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(384, 45);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(264, 617);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(360, 616);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbDetallesDeposito
            // 
            this.gbDetallesDeposito.Controls.Add(this.dgvDepositos);
            this.gbDetallesDeposito.Controls.Add(this.btnModificarDeposito);
            this.gbDetallesDeposito.Controls.Add(this.btnAgregarDeposito);
            this.gbDetallesDeposito.Controls.Add(this.btnBuscar);
            this.gbDetallesDeposito.Controls.Add(this.lblReferencia);
            this.gbDetallesDeposito.Controls.Add(this.txtDeposito);
            this.gbDetallesDeposito.Location = new System.Drawing.Point(12, 227);
            this.gbDetallesDeposito.Name = "gbDetallesDeposito";
            this.gbDetallesDeposito.Size = new System.Drawing.Size(444, 212);
            this.gbDetallesDeposito.TabIndex = 2;
            this.gbDetallesDeposito.TabStop = false;
            this.gbDetallesDeposito.Text = "Detalles del Deposito";
            // 
            // dgvDepositos
            // 
            this.dgvDepositos.AllowUserToAddRows = false;
            this.dgvDepositos.AllowUserToDeleteRows = false;
            this.dgvDepositos.AllowUserToOrderColumns = true;
            this.dgvDepositos.AllowUserToResizeColumns = false;
            this.dgvDepositos.AllowUserToResizeRows = false;
            this.dgvDepositos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepositos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepositos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Deposito,
            this.Cuenta,
            this.Moneda,
            this.Monto});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepositos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDepositos.EnableHeadersVisualStyles = false;
            this.dgvDepositos.Location = new System.Drawing.Point(90, 65);
            this.dgvDepositos.MultiSelect = false;
            this.dgvDepositos.Name = "dgvDepositos";
            this.dgvDepositos.ReadOnly = true;
            this.dgvDepositos.RowHeadersVisible = false;
            this.dgvDepositos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepositos.Size = new System.Drawing.Size(348, 95);
            this.dgvDepositos.TabIndex = 3;
            this.dgvDepositos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDepositos_CellFormatting);
            this.dgvDepositos.SelectionChanged += new System.EventHandler(this.dgvDepositos_SelectionChanged);
            // 
            // Deposito
            // 
            this.Deposito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Deposito.DataPropertyName = "Referencia";
            this.Deposito.HeaderText = "Referencia";
            this.Deposito.Name = "Deposito";
            this.Deposito.ReadOnly = true;
            this.Deposito.Width = 83;
            // 
            // Cuenta
            // 
            this.Cuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cuenta.DataPropertyName = "Cuenta";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.ReadOnly = true;
            this.Cuenta.Width = 65;
            // 
            // Moneda
            // 
            this.Moneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Format = "N2";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // btnModificarDeposito
            // 
            this.btnModificarDeposito.Enabled = false;
            this.btnModificarDeposito.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificarDeposito.Location = new System.Drawing.Point(252, 166);
            this.btnModificarDeposito.Name = "btnModificarDeposito";
            this.btnModificarDeposito.Size = new System.Drawing.Size(90, 40);
            this.btnModificarDeposito.TabIndex = 4;
            this.btnModificarDeposito.Text = "Modificar";
            this.btnModificarDeposito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificarDeposito.UseVisualStyleBackColor = false;
            this.btnModificarDeposito.Click += new System.EventHandler(this.btnModificarDeposito_Click);
            // 
            // btnAgregarDeposito
            // 
            this.btnAgregarDeposito.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarDeposito.Location = new System.Drawing.Point(348, 166);
            this.btnAgregarDeposito.Name = "btnAgregarDeposito";
            this.btnAgregarDeposito.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarDeposito.TabIndex = 5;
            this.btnAgregarDeposito.Text = "Agregar";
            this.btnAgregarDeposito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarDeposito.UseVisualStyleBackColor = false;
            this.btnAgregarDeposito.Click += new System.EventHandler(this.btnAgregarDeposito_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(348, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(22, 33);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(62, 13);
            this.lblReferencia.TabIndex = 0;
            this.lblReferencia.Text = "Referencia:";
            // 
            // txtDeposito
            // 
            this.txtDeposito.Location = new System.Drawing.Point(90, 29);
            this.txtDeposito.Name = "txtDeposito";
            this.txtDeposito.Size = new System.Drawing.Size(252, 20);
            this.txtDeposito.TabIndex = 1;
            // 
            // chkMonto
            // 
            this.chkMonto.AutoSize = true;
            this.chkMonto.Location = new System.Drawing.Point(28, 47);
            this.chkMonto.Name = "chkMonto";
            this.chkMonto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMonto.Size = new System.Drawing.Size(56, 17);
            this.chkMonto.TabIndex = 4;
            this.chkMonto.Text = "Monto";
            this.chkMonto.UseVisualStyleBackColor = true;
            this.chkMonto.CheckedChanged += new System.EventHandler(this.chkMonto_CheckedChanged);
            // 
            // chkReferencia
            // 
            this.chkReferencia.AutoSize = true;
            this.chkReferencia.Location = new System.Drawing.Point(6, 21);
            this.chkReferencia.Name = "chkReferencia";
            this.chkReferencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkReferencia.Size = new System.Drawing.Size(78, 17);
            this.chkReferencia.TabIndex = 0;
            this.chkReferencia.Text = "Referencia";
            this.chkReferencia.UseVisualStyleBackColor = true;
            this.chkReferencia.CheckedChanged += new System.EventHandler(this.chkReferencia_CheckedChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(43, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(89, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.AutoSize = true;
            this.lblCoordinador.Location = new System.Drawing.Point(17, 49);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(67, 13);
            this.lblCoordinador.TabIndex = 4;
            this.lblCoordinador.Text = "Coordinador:";
            // 
            // txtCoordinador
            // 
            this.txtCoordinador.Location = new System.Drawing.Point(90, 45);
            this.txtCoordinador.Name = "txtCoordinador";
            this.txtCoordinador.ReadOnly = true;
            this.txtCoordinador.Size = new System.Drawing.Size(348, 20);
            this.txtCoordinador.TabIndex = 5;
            // 
            // chkCuenta
            // 
            this.chkCuenta.AutoSize = true;
            this.chkCuenta.Location = new System.Drawing.Point(240, 21);
            this.chkCuenta.Name = "chkCuenta";
            this.chkCuenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCuenta.Size = new System.Drawing.Size(60, 17);
            this.chkCuenta.TabIndex = 2;
            this.chkCuenta.Text = "Cuenta";
            this.chkCuenta.UseVisualStyleBackColor = true;
            this.chkCuenta.CheckedChanged += new System.EventHandler(this.chkCuenta_CheckedChanged);
            // 
            // chkMoneda
            // 
            this.chkMoneda.AutoSize = true;
            this.chkMoneda.Location = new System.Drawing.Point(235, 47);
            this.chkMoneda.Name = "chkMoneda";
            this.chkMoneda.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMoneda.Size = new System.Drawing.Size(65, 17);
            this.chkMoneda.TabIndex = 6;
            this.chkMoneda.Text = "Moneda";
            this.chkMoneda.UseVisualStyleBackColor = true;
            this.chkMoneda.CheckedChanged += new System.EventHandler(this.chkMoneda_CheckedChanged);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares"});
            this.cboMoneda.Location = new System.Drawing.Point(306, 45);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(132, 21);
            this.cboMoneda.TabIndex = 7;
            // 
            // mtbReferencia
            // 
            this.mtbReferencia.Enabled = false;
            this.mtbReferencia.Location = new System.Drawing.Point(90, 19);
            this.mtbReferencia.Mask = "9999999999";
            this.mtbReferencia.Name = "mtbReferencia";
            this.mtbReferencia.Size = new System.Drawing.Size(139, 20);
            this.mtbReferencia.TabIndex = 1;
            // 
            // mtbCuenta
            // 
            this.mtbCuenta.Enabled = false;
            this.mtbCuenta.Location = new System.Drawing.Point(306, 19);
            this.mtbCuenta.Mask = "9999999999";
            this.mtbCuenta.Name = "mtbCuenta";
            this.mtbCuenta.Size = new System.Drawing.Size(132, 20);
            this.mtbCuenta.TabIndex = 3;
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Enabled = false;
            this.nudMonto.Location = new System.Drawing.Point(90, 45);
            this.nudMonto.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(139, 20);
            this.nudMonto.TabIndex = 5;
            this.nudMonto.ThousandsSeparator = true;
            // 
            // gbDatosErroneos
            // 
            this.gbDatosErroneos.Controls.Add(this.cboMoneda);
            this.gbDatosErroneos.Controls.Add(this.mtbReferencia);
            this.gbDatosErroneos.Controls.Add(this.chkMoneda);
            this.gbDatosErroneos.Controls.Add(this.mtbCuenta);
            this.gbDatosErroneos.Controls.Add(this.chkCuenta);
            this.gbDatosErroneos.Controls.Add(this.nudMonto);
            this.gbDatosErroneos.Controls.Add(this.chkReferencia);
            this.gbDatosErroneos.Controls.Add(this.chkMonto);
            this.gbDatosErroneos.Location = new System.Drawing.Point(12, 445);
            this.gbDatosErroneos.Name = "gbDatosErroneos";
            this.gbDatosErroneos.Size = new System.Drawing.Size(444, 72);
            this.gbDatosErroneos.TabIndex = 3;
            this.gbDatosErroneos.TabStop = false;
            this.gbDatosErroneos.Text = "Datos Erroneos";
            // 
            // gbDetalles
            // 
            this.gbDetalles.Controls.Add(this.btnAgregarPuntoVenta);
            this.gbDetalles.Controls.Add(this.lblPuntoVenta);
            this.gbDetalles.Controls.Add(this.cboPuntoVenta);
            this.gbDetalles.Controls.Add(this.lblCliente);
            this.gbDetalles.Controls.Add(this.cboCliente);
            this.gbDetalles.Controls.Add(this.lblT);
            this.gbDetalles.Controls.Add(this.cboDigitador);
            this.gbDetalles.Controls.Add(this.nudT);
            this.gbDetalles.Controls.Add(this.dtpFecha);
            this.gbDetalles.Controls.Add(this.lblDigitador);
            this.gbDetalles.Controls.Add(this.txtCoordinador);
            this.gbDetalles.Controls.Add(this.lblCoordinador);
            this.gbDetalles.Controls.Add(this.lblFecha);
            this.gbDetalles.Location = new System.Drawing.Point(12, 50);
            this.gbDetalles.Name = "gbDetalles";
            this.gbDetalles.Size = new System.Drawing.Size(444, 171);
            this.gbDetalles.TabIndex = 1;
            this.gbDetalles.TabStop = false;
            this.gbDetalles.Text = "Detalles";
            // 
            // btnAgregarPuntoVenta
            // 
            this.btnAgregarPuntoVenta.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarPuntoVenta.Enabled = false;
            this.btnAgregarPuntoVenta.FlatAppearance.BorderSize = 2;
            this.btnAgregarPuntoVenta.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarPuntoVenta.Location = new System.Drawing.Point(348, 125);
            this.btnAgregarPuntoVenta.Name = "btnAgregarPuntoVenta";
            this.btnAgregarPuntoVenta.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarPuntoVenta.TabIndex = 12;
            this.btnAgregarPuntoVenta.Text = "Agregar";
            this.btnAgregarPuntoVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarPuntoVenta.UseVisualStyleBackColor = false;
            this.btnAgregarPuntoVenta.Click += new System.EventHandler(this.btnAgregarPuntoVenta_Click);
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(18, 129);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(66, 13);
            this.lblPuntoVenta.TabIndex = 10;
            this.lblPuntoVenta.Text = "P. de Venta:";
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = false;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(90, 125);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(252, 21);
            this.cboPuntoVenta.TabIndex = 11;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(42, 102);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 8;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(90, 98);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(348, 21);
            this.cboCliente.TabIndex = 9;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(295, 23);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(17, 13);
            this.lblT.TabIndex = 2;
            this.lblT.Text = "T:";
            // 
            // cboDigitador
            // 
            this.cboDigitador.Busqueda = false;
            this.cboDigitador.ListaMostrada = null;
            this.cboDigitador.Location = new System.Drawing.Point(90, 71);
            this.cboDigitador.Name = "cboDigitador";
            this.cboDigitador.Size = new System.Drawing.Size(348, 21);
            this.cboDigitador.TabIndex = 7;
            // 
            // nudT
            // 
            this.nudT.Location = new System.Drawing.Point(318, 19);
            this.nudT.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudT.Name = "nudT";
            this.nudT.Size = new System.Drawing.Size(120, 20);
            this.nudT.TabIndex = 3;
            // 
            // lblDigitador
            // 
            this.lblDigitador.AutoSize = true;
            this.lblDigitador.Location = new System.Drawing.Point(31, 75);
            this.lblDigitador.Name = "lblDigitador";
            this.lblDigitador.Size = new System.Drawing.Size(52, 13);
            this.lblDigitador.TabIndex = 6;
            this.lblDigitador.Text = "Digitador:";
            // 
            // gbInconsistenciaROE
            // 
            this.gbInconsistenciaROE.Controls.Add(this.chkROESello);
            this.gbInconsistenciaROE.Controls.Add(this.chkROEFirma);
            this.gbInconsistenciaROE.Controls.Add(this.chkROEReimpresion);
            this.gbInconsistenciaROE.Controls.Add(this.chkROECuentaIncorrecta);
            this.gbInconsistenciaROE.Controls.Add(this.chkROEOrigenIncorrecto);
            this.gbInconsistenciaROE.Controls.Add(this.chkROECedulaIncorrecta);
            this.gbInconsistenciaROE.Location = new System.Drawing.Point(12, 523);
            this.gbInconsistenciaROE.Name = "gbInconsistenciaROE";
            this.gbInconsistenciaROE.Size = new System.Drawing.Size(443, 65);
            this.gbInconsistenciaROE.TabIndex = 4;
            this.gbInconsistenciaROE.TabStop = false;
            this.gbInconsistenciaROE.Text = "Inconsistencia en ROE";
            // 
            // chkROECedulaIncorrecta
            // 
            this.chkROECedulaIncorrecta.AutoSize = true;
            this.chkROECedulaIncorrecta.Location = new System.Drawing.Point(6, 19);
            this.chkROECedulaIncorrecta.Name = "chkROECedulaIncorrecta";
            this.chkROECedulaIncorrecta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkROECedulaIncorrecta.Size = new System.Drawing.Size(110, 17);
            this.chkROECedulaIncorrecta.TabIndex = 0;
            this.chkROECedulaIncorrecta.Text = "Cédula Incorrecta";
            this.chkROECedulaIncorrecta.UseVisualStyleBackColor = true;
            // 
            // chkROEOrigenIncorrecto
            // 
            this.chkROEOrigenIncorrecto.AutoSize = true;
            this.chkROEOrigenIncorrecto.Location = new System.Drawing.Point(239, 19);
            this.chkROEOrigenIncorrecto.Name = "chkROEOrigenIncorrecto";
            this.chkROEOrigenIncorrecto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkROEOrigenIncorrecto.Size = new System.Drawing.Size(108, 17);
            this.chkROEOrigenIncorrecto.TabIndex = 2;
            this.chkROEOrigenIncorrecto.Text = "Origen Incorrecto";
            this.chkROEOrigenIncorrecto.UseVisualStyleBackColor = true;
            // 
            // chkROECuentaIncorrecta
            // 
            this.chkROECuentaIncorrecta.AutoSize = true;
            this.chkROECuentaIncorrecta.Location = new System.Drawing.Point(122, 19);
            this.chkROECuentaIncorrecta.Name = "chkROECuentaIncorrecta";
            this.chkROECuentaIncorrecta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkROECuentaIncorrecta.Size = new System.Drawing.Size(111, 17);
            this.chkROECuentaIncorrecta.TabIndex = 1;
            this.chkROECuentaIncorrecta.Text = "Cuenta Incorrecta";
            this.chkROECuentaIncorrecta.UseVisualStyleBackColor = true;
            // 
            // chkROEReimpresion
            // 
            this.chkROEReimpresion.AutoSize = true;
            this.chkROEReimpresion.Location = new System.Drawing.Point(353, 19);
            this.chkROEReimpresion.Name = "chkROEReimpresion";
            this.chkROEReimpresion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkROEReimpresion.Size = new System.Drawing.Size(84, 17);
            this.chkROEReimpresion.TabIndex = 3;
            this.chkROEReimpresion.Text = "Reimpresion";
            this.chkROEReimpresion.UseVisualStyleBackColor = true;
            // 
            // chkROEFirma
            // 
            this.chkROEFirma.AutoSize = true;
            this.chkROEFirma.Location = new System.Drawing.Point(65, 42);
            this.chkROEFirma.Name = "chkROEFirma";
            this.chkROEFirma.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkROEFirma.Size = new System.Drawing.Size(51, 17);
            this.chkROEFirma.TabIndex = 4;
            this.chkROEFirma.Text = "Firma";
            this.chkROEFirma.UseVisualStyleBackColor = true;
            // 
            // chkROESello
            // 
            this.chkROESello.AutoSize = true;
            this.chkROESello.Location = new System.Drawing.Point(184, 42);
            this.chkROESello.Name = "chkROESello";
            this.chkROESello.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkROESello.Size = new System.Drawing.Size(49, 17);
            this.chkROESello.TabIndex = 5;
            this.chkROESello.Text = "Sello";
            this.chkROESello.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoInconsistenciasDigitadores
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(468, 668);
            this.Controls.Add(this.gbInconsistenciaROE);
            this.Controls.Add(this.gbDetalles);
            this.Controls.Add(this.gbDatosErroneos);
            this.Controls.Add(this.gbDetallesDeposito);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoInconsistenciasDigitadores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Inconsistencias de Digitadores";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDetallesDeposito.ResumeLayout(false);
            this.gbDetallesDeposito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.gbDatosErroneos.ResumeLayout(false);
            this.gbDatosErroneos.PerformLayout();
            this.gbDetalles.ResumeLayout(false);
            this.gbDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudT)).EndInit();
            this.gbInconsistenciaROE.ResumeLayout(false);
            this.gbInconsistenciaROE.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbDetallesDeposito;
        private System.Windows.Forms.CheckBox chkMonto;
        private System.Windows.Forms.CheckBox chkReferencia;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblCoordinador;
        private System.Windows.Forms.TextBox txtCoordinador;
        private System.Windows.Forms.CheckBox chkCuenta;
        private System.Windows.Forms.CheckBox chkMoneda;
        private System.Windows.Forms.DataGridView dgvDepositos;
        private System.Windows.Forms.Button btnModificarDeposito;
        private System.Windows.Forms.Button btnAgregarDeposito;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtDeposito;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.MaskedTextBox mtbReferencia;
        private System.Windows.Forms.MaskedTextBox mtbCuenta;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.GroupBox gbDatosErroneos;
        private System.Windows.Forms.GroupBox gbDetalles;
        private ComboBoxBusqueda cboDigitador;
        private System.Windows.Forms.Label lblDigitador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.NumericUpDown nudT;
        private System.Windows.Forms.Label lblPuntoVenta;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblCliente;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Button btnAgregarPuntoVenta;
        private System.Windows.Forms.GroupBox gbInconsistenciaROE;
        private System.Windows.Forms.CheckBox chkROESello;
        private System.Windows.Forms.CheckBox chkROEFirma;
        private System.Windows.Forms.CheckBox chkROEReimpresion;
        private System.Windows.Forms.CheckBox chkROECuentaIncorrecta;
        private System.Windows.Forms.CheckBox chkROEOrigenIncorrecto;
        private System.Windows.Forms.CheckBox chkROECedulaIncorrecta;
    }
}