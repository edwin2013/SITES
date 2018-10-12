namespace GUILayer
{
    partial class frmMantenimientoInconsistenciasManifiestosCEF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoInconsistenciasManifiestosCEF));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblCamara = new System.Windows.Forms.Label();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cboCamara = new GUILayer.ComboBoxBusqueda();
            this.lblCoordinador = new System.Windows.Forms.Label();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.gbManifiestos = new System.Windows.Forms.GroupBox();
            this.btnBuscarManifiesto = new System.Windows.Forms.Button();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblManfiesto = new System.Windows.Forms.Label();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.pnlDetallesManifiesto = new System.Windows.Forms.Panel();
            this.btnAgregarPuntoVenta = new System.Windows.Forms.Button();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.mtbCodigoCliente = new System.Windows.Forms.MaskedTextBox();
            this.cboCoordinador = new GUILayer.ComboBoxBusqueda();
            this.dtpFechaManifiesto = new System.Windows.Forms.DateTimePicker();
            this.lblFechaManifiesto = new System.Windows.Forms.Label();
            this.lblMontoTotalReal = new System.Windows.Forms.Label();
            this.nudMontoTotalReal = new System.Windows.Forms.NumericUpDown();
            this.cboDigitador = new GUILayer.ComboBoxBusqueda();
            this.lblDigitador = new System.Windows.Forms.Label();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.nudMontoColonesReal = new System.Windows.Forms.NumericUpDown();
            this.nudDepositosReales = new System.Windows.Forms.NumericUpDown();
            this.lblDepositosReales = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.nudMontoDolaresReal = new System.Windows.Forms.NumericUpDown();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.lblMontoDolaresReal = new System.Windows.Forms.Label();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.lblMontoColonesReal = new System.Windows.Forms.Label();
            this.gbDatosReportados = new System.Windows.Forms.GroupBox();
            this.nudMontoDolaresReportado = new System.Windows.Forms.NumericUpDown();
            this.lblMontoDolaresReportado = new System.Windows.Forms.Label();
            this.nudMontoTotalReportado = new System.Windows.Forms.NumericUpDown();
            this.nudMontoColonesReportado = new System.Windows.Forms.NumericUpDown();
            this.lblMontoTotalReportado = new System.Windows.Forms.Label();
            this.lblMontoColonesReportado = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.nudMontoEurosReportado = new System.Windows.Forms.NumericUpDown();
            this.lblMontoEurosReportado = new System.Windows.Forms.Label();
            this.nudMontoEurosReal = new System.Windows.Forms.NumericUpDown();
            this.lblMontoEurosReal = new System.Windows.Forms.Label();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDetalle.SuspendLayout();
            this.gbManifiestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.pnlDetallesManifiesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoTotalReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoColonesReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepositosReales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolaresReal)).BeginInit();
            this.gbDatosReportados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolaresReportado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoTotalReportado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoColonesReportado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoEurosReportado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoEurosReal)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(506, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblCamara
            // 
            this.lblCamara.AutoSize = true;
            this.lblCamara.Location = new System.Drawing.Point(264, 23);
            this.lblCamara.Name = "lblCamara";
            this.lblCamara.Size = new System.Drawing.Size(46, 13);
            this.lblCamara.TabIndex = 2;
            this.lblCamara.Text = "Camara:";
            // 
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.lblComentario);
            this.gbDetalle.Controls.Add(this.txtComentario);
            this.gbDetalle.Controls.Add(this.dtpFecha);
            this.gbDetalle.Controls.Add(this.lblFecha);
            this.gbDetalle.Controls.Add(this.cboCamara);
            this.gbDetalle.Controls.Add(this.lblCamara);
            this.gbDetalle.Location = new System.Drawing.Point(12, 63);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(458, 100);
            this.gbDetalle.TabIndex = 1;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle de la Inconsistencia";
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(22, 46);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(63, 13);
            this.lblComentario.TabIndex = 4;
            this.lblComentario.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(91, 46);
            this.txtComentario.MaxLength = 400;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(361, 48);
            this.txtComentario.TabIndex = 5;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(91, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(148, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(6, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(79, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "F. de Inclusión:";
            // 
            // cboCamara
            // 
            this.cboCamara.Busqueda = false;
            this.cboCamara.ListaMostrada = null;
            this.cboCamara.Location = new System.Drawing.Point(316, 19);
            this.cboCamara.Name = "cboCamara";
            this.cboCamara.Size = new System.Drawing.Size(136, 21);
            this.cboCamara.TabIndex = 3;
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.AutoSize = true;
            this.lblCoordinador.Location = new System.Drawing.Point(18, 30);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(67, 13);
            this.lblCoordinador.TabIndex = 2;
            this.lblCoordinador.Text = "Coordinador:";
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(19, 164);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(66, 13);
            this.lblPuntoVenta.TabIndex = 12;
            this.lblPuntoVenta.Text = "P. de Venta:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(43, 137);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 10;
            this.lblCliente.Text = "Cliente:";
            // 
            // gbManifiestos
            // 
            this.gbManifiestos.Controls.Add(this.btnBuscarManifiesto);
            this.gbManifiestos.Controls.Add(this.dgvManifiestos);
            this.gbManifiestos.Controls.Add(this.lblManfiesto);
            this.gbManifiestos.Controls.Add(this.txtManifiesto);
            this.gbManifiestos.Location = new System.Drawing.Point(12, 169);
            this.gbManifiestos.Name = "gbManifiestos";
            this.gbManifiestos.Size = new System.Drawing.Size(458, 446);
            this.gbManifiestos.TabIndex = 2;
            this.gbManifiestos.TabStop = false;
            this.gbManifiestos.Text = "Manifiesto";
            // 
            // btnBuscarManifiesto
            // 
            this.btnBuscarManifiesto.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscarManifiesto.Location = new System.Drawing.Point(362, 19);
            this.btnBuscarManifiesto.Name = "btnBuscarManifiesto";
            this.btnBuscarManifiesto.Size = new System.Drawing.Size(90, 40);
            this.btnBuscarManifiesto.TabIndex = 2;
            this.btnBuscarManifiesto.Text = "Buscar";
            this.btnBuscarManifiesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarManifiesto.UseVisualStyleBackColor = false;
            this.btnBuscarManifiesto.Click += new System.EventHandler(this.btnBuscarManifiesto_Click);
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
            this.dgvManifiestos.Location = new System.Drawing.Point(91, 65);
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(361, 107);
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
            // lblManfiesto
            // 
            this.lblManfiesto.AutoSize = true;
            this.lblManfiesto.Location = new System.Drawing.Point(27, 33);
            this.lblManfiesto.Name = "lblManfiesto";
            this.lblManfiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManfiesto.TabIndex = 0;
            this.lblManfiesto.Text = "Manifiesto:";
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.Location = new System.Drawing.Point(91, 29);
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.Size = new System.Drawing.Size(265, 20);
            this.txtManifiesto.TabIndex = 1;
            this.txtManifiesto.Enter += new System.EventHandler(this.txtManifiesto_Enter);
            this.txtManifiesto.Leave += new System.EventHandler(this.txtManifiesto_Leave);
            // 
            // pnlDetallesManifiesto
            // 
            this.pnlDetallesManifiesto.Controls.Add(this.nudMontoEurosReal);
            this.pnlDetallesManifiesto.Controls.Add(this.lblMontoEurosReal);
            this.pnlDetallesManifiesto.Controls.Add(this.btnAgregarPuntoVenta);
            this.pnlDetallesManifiesto.Controls.Add(this.lblCodigoCliente);
            this.pnlDetallesManifiesto.Controls.Add(this.mtbCodigoCliente);
            this.pnlDetallesManifiesto.Controls.Add(this.cboCoordinador);
            this.pnlDetallesManifiesto.Controls.Add(this.dtpFechaManifiesto);
            this.pnlDetallesManifiesto.Controls.Add(this.lblFechaManifiesto);
            this.pnlDetallesManifiesto.Controls.Add(this.lblMontoTotalReal);
            this.pnlDetallesManifiesto.Controls.Add(this.nudMontoTotalReal);
            this.pnlDetallesManifiesto.Controls.Add(this.cboDigitador);
            this.pnlDetallesManifiesto.Controls.Add(this.lblDigitador);
            this.pnlDetallesManifiesto.Controls.Add(this.lblCoordinador);
            this.pnlDetallesManifiesto.Controls.Add(this.cboCajero);
            this.pnlDetallesManifiesto.Controls.Add(this.nudMontoColonesReal);
            this.pnlDetallesManifiesto.Controls.Add(this.nudDepositosReales);
            this.pnlDetallesManifiesto.Controls.Add(this.lblDepositosReales);
            this.pnlDetallesManifiesto.Controls.Add(this.lblCajero);
            this.pnlDetallesManifiesto.Controls.Add(this.lblPuntoVenta);
            this.pnlDetallesManifiesto.Controls.Add(this.nudMontoDolaresReal);
            this.pnlDetallesManifiesto.Controls.Add(this.cboPuntoVenta);
            this.pnlDetallesManifiesto.Controls.Add(this.lblMontoDolaresReal);
            this.pnlDetallesManifiesto.Controls.Add(this.lblCliente);
            this.pnlDetallesManifiesto.Controls.Add(this.cboCliente);
            this.pnlDetallesManifiesto.Controls.Add(this.lblMontoColonesReal);
            this.pnlDetallesManifiesto.Enabled = false;
            this.pnlDetallesManifiesto.Location = new System.Drawing.Point(12, 347);
            this.pnlDetallesManifiesto.Name = "pnlDetallesManifiesto";
            this.pnlDetallesManifiesto.Size = new System.Drawing.Size(458, 262);
            this.pnlDetallesManifiesto.TabIndex = 4;
            // 
            // btnAgregarPuntoVenta
            // 
            this.btnAgregarPuntoVenta.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarPuntoVenta.Enabled = false;
            this.btnAgregarPuntoVenta.FlatAppearance.BorderSize = 2;
            this.btnAgregarPuntoVenta.Location = new System.Drawing.Point(412, 160);
            this.btnAgregarPuntoVenta.Name = "btnAgregarPuntoVenta";
            this.btnAgregarPuntoVenta.Size = new System.Drawing.Size(40, 21);
            this.btnAgregarPuntoVenta.TabIndex = 14;
            this.btnAgregarPuntoVenta.Text = "+";
            this.btnAgregarPuntoVenta.UseVisualStyleBackColor = false;
            this.btnAgregarPuntoVenta.Click += new System.EventHandler(this.btnAgregarPuntoVenta_Click);
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Location = new System.Drawing.Point(15, 111);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(70, 13);
            this.lblCodigoCliente.TabIndex = 8;
            this.lblCodigoCliente.Text = "C. de Cliente:";
            // 
            // mtbCodigoCliente
            // 
            this.mtbCodigoCliente.Location = new System.Drawing.Point(91, 107);
            this.mtbCodigoCliente.Mask = "999999";
            this.mtbCodigoCliente.Name = "mtbCodigoCliente";
            this.mtbCodigoCliente.Size = new System.Drawing.Size(361, 20);
            this.mtbCodigoCliente.TabIndex = 9;
            this.mtbCodigoCliente.Leave += new System.EventHandler(this.mtbCodigoCliente_Leave);
            // 
            // cboCoordinador
            // 
            this.cboCoordinador.Busqueda = false;
            this.cboCoordinador.Enabled = false;
            this.cboCoordinador.ListaMostrada = null;
            this.cboCoordinador.Location = new System.Drawing.Point(91, 26);
            this.cboCoordinador.Name = "cboCoordinador";
            this.cboCoordinador.Size = new System.Drawing.Size(361, 21);
            this.cboCoordinador.TabIndex = 3;
            this.cboCoordinador.TabStop = false;
            // 
            // dtpFechaManifiesto
            // 
            this.dtpFechaManifiesto.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy";
            this.dtpFechaManifiesto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaManifiesto.Location = new System.Drawing.Point(91, 0);
            this.dtpFechaManifiesto.Name = "dtpFechaManifiesto";
            this.dtpFechaManifiesto.Size = new System.Drawing.Size(361, 20);
            this.dtpFechaManifiesto.TabIndex = 1;
            this.dtpFechaManifiesto.ValueChanged += new System.EventHandler(this.dtpFechaManifiesto_ValueChanged);
            // 
            // lblFechaManifiesto
            // 
            this.lblFechaManifiesto.AutoSize = true;
            this.lblFechaManifiesto.Location = new System.Drawing.Point(45, 4);
            this.lblFechaManifiesto.Name = "lblFechaManifiesto";
            this.lblFechaManifiesto.Size = new System.Drawing.Size(40, 13);
            this.lblFechaManifiesto.TabIndex = 0;
            this.lblFechaManifiesto.Text = "Fecha:";
            // 
            // lblMontoTotalReal
            // 
            this.lblMontoTotalReal.AutoSize = true;
            this.lblMontoTotalReal.Location = new System.Drawing.Point(51, 243);
            this.lblMontoTotalReal.Name = "lblMontoTotalReal";
            this.lblMontoTotalReal.Size = new System.Drawing.Size(34, 13);
            this.lblMontoTotalReal.TabIndex = 21;
            this.lblMontoTotalReal.Text = "Total:";
            // 
            // nudMontoTotalReal
            // 
            this.nudMontoTotalReal.DecimalPlaces = 2;
            this.nudMontoTotalReal.Location = new System.Drawing.Point(91, 239);
            this.nudMontoTotalReal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoTotalReal.Name = "nudMontoTotalReal";
            this.nudMontoTotalReal.Size = new System.Drawing.Size(148, 20);
            this.nudMontoTotalReal.TabIndex = 22;
            this.nudMontoTotalReal.ThousandsSeparator = true;
            // 
            // cboDigitador
            // 
            this.cboDigitador.Busqueda = false;
            this.cboDigitador.ListaMostrada = null;
            this.cboDigitador.Location = new System.Drawing.Point(91, 80);
            this.cboDigitador.Name = "cboDigitador";
            this.cboDigitador.Size = new System.Drawing.Size(361, 21);
            this.cboDigitador.TabIndex = 7;
            // 
            // lblDigitador
            // 
            this.lblDigitador.AutoSize = true;
            this.lblDigitador.Location = new System.Drawing.Point(33, 84);
            this.lblDigitador.Name = "lblDigitador";
            this.lblDigitador.Size = new System.Drawing.Size(52, 13);
            this.lblDigitador.TabIndex = 6;
            this.lblDigitador.Text = "Digitador:";
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(91, 53);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(361, 21);
            this.cboCajero.TabIndex = 5;
            // 
            // nudMontoColonesReal
            // 
            this.nudMontoColonesReal.DecimalPlaces = 2;
            this.nudMontoColonesReal.Location = new System.Drawing.Point(91, 187);
            this.nudMontoColonesReal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoColonesReal.Name = "nudMontoColonesReal";
            this.nudMontoColonesReal.Size = new System.Drawing.Size(148, 20);
            this.nudMontoColonesReal.TabIndex = 16;
            this.nudMontoColonesReal.ThousandsSeparator = true;
            // 
            // nudDepositosReales
            // 
            this.nudDepositosReales.Location = new System.Drawing.Point(91, 213);
            this.nudDepositosReales.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDepositosReales.Name = "nudDepositosReales";
            this.nudDepositosReales.Size = new System.Drawing.Size(148, 20);
            this.nudDepositosReales.TabIndex = 20;
            this.nudDepositosReales.ThousandsSeparator = true;
            // 
            // lblDepositosReales
            // 
            this.lblDepositosReales.AutoSize = true;
            this.lblDepositosReales.Location = new System.Drawing.Point(28, 217);
            this.lblDepositosReales.Name = "lblDepositosReales";
            this.lblDepositosReales.Size = new System.Drawing.Size(57, 13);
            this.lblDepositosReales.TabIndex = 19;
            this.lblDepositosReales.Text = "Depositos:";
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(45, 57);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 4;
            this.lblCajero.Text = "Cajero:";
            // 
            // nudMontoDolaresReal
            // 
            this.nudMontoDolaresReal.DecimalPlaces = 2;
            this.nudMontoDolaresReal.Location = new System.Drawing.Point(316, 187);
            this.nudMontoDolaresReal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoDolaresReal.Name = "nudMontoDolaresReal";
            this.nudMontoDolaresReal.Size = new System.Drawing.Size(136, 20);
            this.nudMontoDolaresReal.TabIndex = 18;
            this.nudMontoDolaresReal.ThousandsSeparator = true;
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = false;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(91, 160);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(315, 21);
            this.cboPuntoVenta.TabIndex = 13;
            // 
            // lblMontoDolaresReal
            // 
            this.lblMontoDolaresReal.AutoSize = true;
            this.lblMontoDolaresReal.Location = new System.Drawing.Point(264, 191);
            this.lblMontoDolaresReal.Name = "lblMontoDolaresReal";
            this.lblMontoDolaresReal.Size = new System.Drawing.Size(46, 13);
            this.lblMontoDolaresReal.TabIndex = 17;
            this.lblMontoDolaresReal.Text = "Dólares:";
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(91, 133);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(361, 21);
            this.cboCliente.TabIndex = 11;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblMontoColonesReal
            // 
            this.lblMontoColonesReal.AutoSize = true;
            this.lblMontoColonesReal.Location = new System.Drawing.Point(37, 191);
            this.lblMontoColonesReal.Name = "lblMontoColonesReal";
            this.lblMontoColonesReal.Size = new System.Drawing.Size(48, 13);
            this.lblMontoColonesReal.TabIndex = 15;
            this.lblMontoColonesReal.Text = "Colones:";
            // 
            // gbDatosReportados
            // 
            this.gbDatosReportados.Controls.Add(this.nudMontoEurosReportado);
            this.gbDatosReportados.Controls.Add(this.lblMontoEurosReportado);
            this.gbDatosReportados.Controls.Add(this.nudMontoDolaresReportado);
            this.gbDatosReportados.Controls.Add(this.lblMontoDolaresReportado);
            this.gbDatosReportados.Controls.Add(this.nudMontoTotalReportado);
            this.gbDatosReportados.Controls.Add(this.nudMontoColonesReportado);
            this.gbDatosReportados.Controls.Add(this.lblMontoTotalReportado);
            this.gbDatosReportados.Controls.Add(this.lblMontoColonesReportado);
            this.gbDatosReportados.Location = new System.Drawing.Point(12, 621);
            this.gbDatosReportados.Name = "gbDatosReportados";
            this.gbDatosReportados.Size = new System.Drawing.Size(458, 71);
            this.gbDatosReportados.TabIndex = 3;
            this.gbDatosReportados.TabStop = false;
            this.gbDatosReportados.Text = "Datos Reportados";
            // 
            // nudMontoDolaresReportado
            // 
            this.nudMontoDolaresReportado.DecimalPlaces = 2;
            this.nudMontoDolaresReportado.Location = new System.Drawing.Point(316, 19);
            this.nudMontoDolaresReportado.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoDolaresReportado.Name = "nudMontoDolaresReportado";
            this.nudMontoDolaresReportado.Size = new System.Drawing.Size(136, 20);
            this.nudMontoDolaresReportado.TabIndex = 3;
            this.nudMontoDolaresReportado.ThousandsSeparator = true;
            // 
            // lblMontoDolaresReportado
            // 
            this.lblMontoDolaresReportado.AutoSize = true;
            this.lblMontoDolaresReportado.Location = new System.Drawing.Point(264, 23);
            this.lblMontoDolaresReportado.Name = "lblMontoDolaresReportado";
            this.lblMontoDolaresReportado.Size = new System.Drawing.Size(46, 13);
            this.lblMontoDolaresReportado.TabIndex = 2;
            this.lblMontoDolaresReportado.Text = "Dólares:";
            // 
            // nudMontoTotalReportado
            // 
            this.nudMontoTotalReportado.DecimalPlaces = 2;
            this.nudMontoTotalReportado.Location = new System.Drawing.Point(316, 45);
            this.nudMontoTotalReportado.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoTotalReportado.Name = "nudMontoTotalReportado";
            this.nudMontoTotalReportado.Size = new System.Drawing.Size(136, 20);
            this.nudMontoTotalReportado.TabIndex = 5;
            this.nudMontoTotalReportado.ThousandsSeparator = true;
            // 
            // nudMontoColonesReportado
            // 
            this.nudMontoColonesReportado.DecimalPlaces = 2;
            this.nudMontoColonesReportado.Location = new System.Drawing.Point(91, 19);
            this.nudMontoColonesReportado.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoColonesReportado.Name = "nudMontoColonesReportado";
            this.nudMontoColonesReportado.Size = new System.Drawing.Size(148, 20);
            this.nudMontoColonesReportado.TabIndex = 1;
            this.nudMontoColonesReportado.ThousandsSeparator = true;
            // 
            // lblMontoTotalReportado
            // 
            this.lblMontoTotalReportado.AutoSize = true;
            this.lblMontoTotalReportado.Location = new System.Drawing.Point(264, 49);
            this.lblMontoTotalReportado.Name = "lblMontoTotalReportado";
            this.lblMontoTotalReportado.Size = new System.Drawing.Size(34, 13);
            this.lblMontoTotalReportado.TabIndex = 4;
            this.lblMontoTotalReportado.Text = "Total:";
            // 
            // lblMontoColonesReportado
            // 
            this.lblMontoColonesReportado.AutoSize = true;
            this.lblMontoColonesReportado.Location = new System.Drawing.Point(37, 23);
            this.lblMontoColonesReportado.Name = "lblMontoColonesReportado";
            this.lblMontoColonesReportado.Size = new System.Drawing.Size(48, 13);
            this.lblMontoColonesReportado.TabIndex = 0;
            this.lblMontoColonesReportado.Text = "Colones:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(278, 698);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 4;
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
            this.btnSalir.Location = new System.Drawing.Point(374, 698);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // nudMontoEurosReportado
            // 
            this.nudMontoEurosReportado.DecimalPlaces = 2;
            this.nudMontoEurosReportado.Location = new System.Drawing.Point(91, 45);
            this.nudMontoEurosReportado.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoEurosReportado.Name = "nudMontoEurosReportado";
            this.nudMontoEurosReportado.Size = new System.Drawing.Size(148, 20);
            this.nudMontoEurosReportado.TabIndex = 7;
            this.nudMontoEurosReportado.ThousandsSeparator = true;
            // 
            // lblMontoEurosReportado
            // 
            this.lblMontoEurosReportado.AutoSize = true;
            this.lblMontoEurosReportado.Location = new System.Drawing.Point(37, 49);
            this.lblMontoEurosReportado.Name = "lblMontoEurosReportado";
            this.lblMontoEurosReportado.Size = new System.Drawing.Size(37, 13);
            this.lblMontoEurosReportado.TabIndex = 6;
            this.lblMontoEurosReportado.Text = "Euros:";
            // 
            // nudMontoEurosReal
            // 
            this.nudMontoEurosReal.DecimalPlaces = 2;
            this.nudMontoEurosReal.Location = new System.Drawing.Point(316, 213);
            this.nudMontoEurosReal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoEurosReal.Name = "nudMontoEurosReal";
            this.nudMontoEurosReal.Size = new System.Drawing.Size(136, 20);
            this.nudMontoEurosReal.TabIndex = 24;
            this.nudMontoEurosReal.ThousandsSeparator = true;
            // 
            // lblMontoEurosReal
            // 
            this.lblMontoEurosReal.AutoSize = true;
            this.lblMontoEurosReal.Location = new System.Drawing.Point(262, 217);
            this.lblMontoEurosReal.Name = "lblMontoEurosReal";
            this.lblMontoEurosReal.Size = new System.Drawing.Size(37, 13);
            this.lblMontoEurosReal.TabIndex = 23;
            this.lblMontoEurosReal.Text = "Euros:";
            // 
            // frmMantenimientoInconsistenciasManifiestosCEF
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(479, 750);
            this.Controls.Add(this.pnlDetallesManifiesto);
            this.Controls.Add(this.gbDatosReportados);
            this.Controls.Add(this.gbManifiestos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoInconsistenciasManifiestosCEF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Inconsistencias en Manifiestos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            this.gbManifiestos.ResumeLayout(false);
            this.gbManifiestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.pnlDetallesManifiesto.ResumeLayout(false);
            this.pnlDetallesManifiesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoTotalReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoColonesReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepositosReales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolaresReal)).EndInit();
            this.gbDatosReportados.ResumeLayout(false);
            this.gbDatosReportados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolaresReportado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoTotalReportado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoColonesReportado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoEurosReportado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoEurosReal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private ComboBoxBusqueda cboCamara;
        private System.Windows.Forms.Label lblCamara;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.Label lblCoordinador;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox gbDatosReportados;
        private System.Windows.Forms.NumericUpDown nudMontoColonesReal;
        private System.Windows.Forms.NumericUpDown nudDepositosReales;
        private System.Windows.Forms.Label lblMontoColonesReal;
        private System.Windows.Forms.Label lblDepositosReales;
        private System.Windows.Forms.NumericUpDown nudMontoColonesReportado;
        private System.Windows.Forms.Label lblMontoColonesReportado;
        private System.Windows.Forms.NumericUpDown nudMontoTotalReportado;
        private System.Windows.Forms.Label lblMontoTotalReportado;
        private System.Windows.Forms.NumericUpDown nudMontoDolaresReal;
        private System.Windows.Forms.Label lblMontoDolaresReal;
        private System.Windows.Forms.GroupBox gbManifiestos;
        private System.Windows.Forms.Button btnBuscarManifiesto;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblManfiesto;
        private System.Windows.Forms.TextBox txtManifiesto;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.Panel pnlDetallesManifiesto;
        private ComboBoxBusqueda cboDigitador;
        private System.Windows.Forms.Label lblDigitador;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.NumericUpDown nudMontoTotalReal;
        private System.Windows.Forms.Label lblMontoTotalReal;
        private System.Windows.Forms.NumericUpDown nudMontoDolaresReportado;
        private System.Windows.Forms.Label lblMontoDolaresReportado;
        private System.Windows.Forms.Label lblFechaManifiesto;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.DateTimePicker dtpFechaManifiesto;
        private ComboBoxBusqueda cboCoordinador;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.MaskedTextBox mtbCodigoCliente;
        private System.Windows.Forms.Button btnAgregarPuntoVenta;
        private System.Windows.Forms.NumericUpDown nudMontoEurosReal;
        private System.Windows.Forms.Label lblMontoEurosReal;
        private System.Windows.Forms.NumericUpDown nudMontoEurosReportado;
        private System.Windows.Forms.Label lblMontoEurosReportado;
    }
}