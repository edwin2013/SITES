namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmCierreCajero
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreCajero));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDatosCierre = new System.Windows.Forms.GroupBox();
            this.lblDigitador = new System.Windows.Forms.Label();
            this.cboDigitador = new GUILayer.ComboBoxBusqueda();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.cboCoordinador = new GUILayer.ComboBoxBusqueda();
            this.gbSaldoInicial = new System.Windows.Forms.GroupBox();
            this.nudNiquel = new System.Windows.Forms.NumericUpDown();
            this.lblMonto2 = new System.Windows.Forms.Label();
            this.btnAñadirSI = new System.Windows.Forms.Button();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.btnSaldoInicial = new System.Windows.Forms.Button();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.chkNiquel = new System.Windows.Forms.CheckBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblCoordinador = new System.Windows.Forms.Label();
            this.gbMontosCierre = new System.Windows.Forms.GroupBox();
            this.lblNumManifiestos = new System.Windows.Forms.Label();
            this.lblManifiestos = new System.Windows.Forms.Label();
            this.dgvCierre = new System.Windows.Forms.DataGridView();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoEuros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcOpciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbCajeros = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.clbCajeros = new System.Windows.Forms.CheckedListBox();
            this.gbConsolidado = new System.Windows.Forms.GroupBox();
            this.dgvConsolidado = new System.Windows.Forms.DataGridView();
            this.ConceptoConsolidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesConsolidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresConsolidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoEurosCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpManifiestos = new System.Windows.Forms.TabPage();
            this.gbFechaManifiestos = new System.Windows.Forms.GroupBox();
            this.btnActualizarManifiesto = new System.Windows.Forms.Button();
            this.dtpFechaManifiestos = new System.Windows.Forms.DateTimePicker();
            this.lblFechaManifiestos = new System.Windows.Forms.Label();
            this.gbManifiestos = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.tpMontosClientes = new System.Windows.Forms.TabPage();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.chkFiltrar = new System.Windows.Forms.CheckBox();
            this.dtpFechaMontos = new System.Windows.Forms.DateTimePicker();
            this.lblFechaMontos = new System.Windows.Forms.Label();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.cboCajeroMontos = new GUILayer.ComboBoxBusqueda();
            this.cboDigitadorMontos = new GUILayer.ComboBoxBusqueda();
            this.rbMontosDigitador = new System.Windows.Forms.RadioButton();
            this.rbMontosCajero = new System.Windows.Forms.RadioButton();
            this.btnActualizarMontosClientes = new System.Windows.Forms.Button();
            this.gbMontosClientes = new System.Windows.Forms.GroupBox();
            this.dgvMontosClientes = new System.Windows.Forms.DataGridView();
            this.tpImpresion = new System.Windows.Forms.TabPage();
            this.gbImpresion = new System.Windows.Forms.GroupBox();
            this.rbImpresionCoordinador = new System.Windows.Forms.RadioButton();
            this.cboCoordinadorImpresion = new GUILayer.ComboBoxBusqueda();
            this.cboImpresionCajero = new GUILayer.ComboBoxBusqueda();
            this.cboImpresionDigitador = new GUILayer.ComboBoxBusqueda();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.rbImpresionDigitador = new System.Windows.Forms.RadioButton();
            this.rbImpresionCajero = new System.Windows.Forms.RadioButton();
            this.dtpFechaImpresion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaImpresion = new System.Windows.Forms.Label();
            this.gbDatosCierre.SuspendLayout();
            this.gbSaldoInicial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNiquel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.gbMontosCierre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierre)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.tcOpciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbCajeros.SuspendLayout();
            this.gbConsolidado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsolidado)).BeginInit();
            this.tpManifiestos.SuspendLayout();
            this.gbFechaManifiestos.SuspendLayout();
            this.gbManifiestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.tpMontosClientes.SuspendLayout();
            this.gbFiltro.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.gbMontosClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosClientes)).BeginInit();
            this.tpImpresion.SuspendLayout();
            this.gbImpresion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosCierre
            // 
            this.gbDatosCierre.Controls.Add(this.lblDigitador);
            this.gbDatosCierre.Controls.Add(this.cboDigitador);
            this.gbDatosCierre.Controls.Add(this.cboCajero);
            this.gbDatosCierre.Controls.Add(this.cboCoordinador);
            this.gbDatosCierre.Controls.Add(this.gbSaldoInicial);
            this.gbDatosCierre.Controls.Add(this.chkNiquel);
            this.gbDatosCierre.Controls.Add(this.dtpFecha);
            this.gbDatosCierre.Controls.Add(this.lblFecha);
            this.gbDatosCierre.Controls.Add(this.lblCajero);
            this.gbDatosCierre.Controls.Add(this.lblCoordinador);
            this.gbDatosCierre.Location = new System.Drawing.Point(7, 64);
            this.gbDatosCierre.Name = "gbDatosCierre";
            this.gbDatosCierre.Size = new System.Drawing.Size(700, 171);
            this.gbDatosCierre.TabIndex = 0;
            this.gbDatosCierre.TabStop = false;
            this.gbDatosCierre.Text = "Datos del Cierre";
            // 
            // lblDigitador
            // 
            this.lblDigitador.AutoSize = true;
            this.lblDigitador.Location = new System.Drawing.Point(26, 56);
            this.lblDigitador.Name = "lblDigitador";
            this.lblDigitador.Size = new System.Drawing.Size(52, 13);
            this.lblDigitador.TabIndex = 46;
            this.lblDigitador.Text = "Digitador:";
            // 
            // cboDigitador
            // 
            this.cboDigitador.Busqueda = false;
            this.cboDigitador.ListaMostrada = null;
            this.cboDigitador.Location = new System.Drawing.Point(84, 52);
            this.cboDigitador.Name = "cboDigitador";
            this.cboDigitador.Size = new System.Drawing.Size(241, 21);
            this.cboDigitador.TabIndex = 47;
            this.cboDigitador.SelectedIndexChanged += new System.EventHandler(this.cboDigitador_SelectedIndexChanged);
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(85, 25);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(241, 21);
            this.cboCajero.TabIndex = 45;
            this.cboCajero.SelectedIndexChanged += new System.EventHandler(this.cboCajero_SelectedIndexChanged);
            // 
            // cboCoordinador
            // 
            this.cboCoordinador.Busqueda = false;
            this.cboCoordinador.ListaMostrada = null;
            this.cboCoordinador.Location = new System.Drawing.Point(84, 107);
            this.cboCoordinador.Name = "cboCoordinador";
            this.cboCoordinador.Size = new System.Drawing.Size(241, 21);
            this.cboCoordinador.TabIndex = 44;
            this.cboCoordinador.SelectedIndexChanged += new System.EventHandler(this.cboCoordinador_SelectedIndexChanged);
            // 
            // gbSaldoInicial
            // 
            this.gbSaldoInicial.Controls.Add(this.nudNiquel);
            this.gbSaldoInicial.Controls.Add(this.lblMonto2);
            this.gbSaldoInicial.Controls.Add(this.btnAñadirSI);
            this.gbSaldoInicial.Controls.Add(this.cboMoneda);
            this.gbSaldoInicial.Controls.Add(this.btnSaldoInicial);
            this.gbSaldoInicial.Controls.Add(this.nudMonto);
            this.gbSaldoInicial.Controls.Add(this.lblMoneda);
            this.gbSaldoInicial.Controls.Add(this.lblMonto);
            this.gbSaldoInicial.Location = new System.Drawing.Point(332, 8);
            this.gbSaldoInicial.Name = "gbSaldoInicial";
            this.gbSaldoInicial.Size = new System.Drawing.Size(360, 157);
            this.gbSaldoInicial.TabIndex = 43;
            this.gbSaldoInicial.TabStop = false;
            this.gbSaldoInicial.Text = "Saldo Inicial";
            // 
            // nudNiquel
            // 
            this.nudNiquel.Location = new System.Drawing.Point(95, 123);
            this.nudNiquel.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudNiquel.Name = "nudNiquel";
            this.nudNiquel.Size = new System.Drawing.Size(254, 20);
            this.nudNiquel.TabIndex = 46;
            // 
            // lblMonto2
            // 
            this.lblMonto2.AutoSize = true;
            this.lblMonto2.Location = new System.Drawing.Point(16, 125);
            this.lblMonto2.Name = "lblMonto2";
            this.lblMonto2.Size = new System.Drawing.Size(73, 13);
            this.lblMonto2.TabIndex = 45;
            this.lblMonto2.Text = "Monto Niquel:";
            // 
            // btnAñadirSI
            // 
            this.btnAñadirSI.Image = global::GUILayer.Properties.Resources.agregar1;
            this.btnAñadirSI.Location = new System.Drawing.Point(246, 17);
            this.btnAñadirSI.Name = "btnAñadirSI";
            this.btnAñadirSI.Size = new System.Drawing.Size(101, 47);
            this.btnAñadirSI.TabIndex = 44;
            this.btnAñadirSI.Text = "Añadir";
            this.btnAñadirSI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAñadirSI.UseVisualStyleBackColor = false;
            this.btnAñadirSI.Click += new System.EventHandler(this.btnAñadirSI_Click);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares",
            "Euros"});
            this.cboMoneda.Location = new System.Drawing.Point(95, 68);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(252, 21);
            this.cboMoneda.TabIndex = 43;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // btnSaldoInicial
            // 
            this.btnSaldoInicial.Enabled = false;
            this.btnSaldoInicial.Image = global::GUILayer.Properties.Resources.saldos;
            this.btnSaldoInicial.Location = new System.Drawing.Point(122, 17);
            this.btnSaldoInicial.Name = "btnSaldoInicial";
            this.btnSaldoInicial.Size = new System.Drawing.Size(101, 47);
            this.btnSaldoInicial.TabIndex = 39;
            this.btnSaldoInicial.Text = "Saldo Inicial";
            this.btnSaldoInicial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaldoInicial.UseVisualStyleBackColor = false;
            this.btnSaldoInicial.Click += new System.EventHandler(this.btnSaldoInicial_Click);
            // 
            // nudMonto
            // 
            this.nudMonto.Location = new System.Drawing.Point(95, 97);
            this.nudMonto.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(254, 20);
            this.nudMonto.TabIndex = 42;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(37, 71);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 41;
            this.lblMoneda.Text = "Moneda:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(15, 99);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(71, 13);
            this.lblMonto.TabIndex = 40;
            this.lblMonto.Text = "Monto Billete:";
            // 
            // chkNiquel
            // 
            this.chkNiquel.AutoSize = true;
            this.chkNiquel.Enabled = false;
            this.chkNiquel.Location = new System.Drawing.Point(103, 145);
            this.chkNiquel.Name = "chkNiquel";
            this.chkNiquel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkNiquel.Size = new System.Drawing.Size(101, 17);
            this.chkNiquel.TabIndex = 13;
            this.chkNiquel.Text = "Cierre de Niquel";
            this.chkNiquel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkNiquel.UseVisualStyleBackColor = true;
            this.chkNiquel.CheckedChanged += new System.EventHandler(this.chkNiquel_CheckedChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(84, 81);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(241, 20);
            this.dtpFecha.TabIndex = 11;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(38, 85);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(39, 28);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 8;
            this.lblCajero.Text = "Cajero:";
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.AutoSize = true;
            this.lblCoordinador.Location = new System.Drawing.Point(11, 111);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(67, 13);
            this.lblCoordinador.TabIndex = 4;
            this.lblCoordinador.Text = "Coordinador:";
            // 
            // gbMontosCierre
            // 
            this.gbMontosCierre.Controls.Add(this.lblNumManifiestos);
            this.gbMontosCierre.Controls.Add(this.lblManifiestos);
            this.gbMontosCierre.Controls.Add(this.dgvCierre);
            this.gbMontosCierre.Location = new System.Drawing.Point(6, 260);
            this.gbMontosCierre.Name = "gbMontosCierre";
            this.gbMontosCierre.Size = new System.Drawing.Size(701, 343);
            this.gbMontosCierre.TabIndex = 1;
            this.gbMontosCierre.TabStop = false;
            this.gbMontosCierre.Text = "Montos de Cierre";
            // 
            // lblNumManifiestos
            // 
            this.lblNumManifiestos.AutoSize = true;
            this.lblNumManifiestos.Location = new System.Drawing.Point(135, 25);
            this.lblNumManifiestos.Name = "lblNumManifiestos";
            this.lblNumManifiestos.Size = new System.Drawing.Size(0, 13);
            this.lblNumManifiestos.TabIndex = 10;
            // 
            // lblManifiestos
            // 
            this.lblManifiestos.AutoSize = true;
            this.lblManifiestos.Location = new System.Drawing.Point(10, 25);
            this.lblManifiestos.Name = "lblManifiestos";
            this.lblManifiestos.Size = new System.Drawing.Size(122, 13);
            this.lblManifiestos.TabIndex = 9;
            this.lblManifiestos.Text = "Manifiestos Procesados:";
            // 
            // dgvCierre
            // 
            this.dgvCierre.AllowUserToAddRows = false;
            this.dgvCierre.AllowUserToDeleteRows = false;
            this.dgvCierre.AllowUserToResizeColumns = false;
            this.dgvCierre.AllowUserToResizeRows = false;
            this.dgvCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCierre.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCierre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Concepto,
            this.MontoColones,
            this.MontoDolares,
            this.clmMontoEuros});
            this.dgvCierre.EnableHeadersVisualStyles = false;
            this.dgvCierre.Location = new System.Drawing.Point(6, 51);
            this.dgvCierre.Name = "dgvCierre";
            this.dgvCierre.ReadOnly = true;
            this.dgvCierre.RowHeadersVisible = false;
            this.dgvCierre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCierre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCierre.Size = new System.Drawing.Size(689, 281);
            this.dgvCierre.StandardTab = true;
            this.dgvCierre.TabIndex = 1;
            // 
            // Concepto
            // 
            this.Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Concepto.DefaultCellStyle = dataGridViewCellStyle1;
            this.Concepto.FillWeight = 28.48244F;
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            this.Concepto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Concepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Concepto.Width = 300;
            // 
            // MontoColones
            // 
            this.MontoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            this.MontoColones.DefaultCellStyle = dataGridViewCellStyle2;
            this.MontoColones.FillWeight = 88.77644F;
            this.MontoColones.HeaderText = "Monto Colones";
            this.MontoColones.MinimumWidth = 120;
            this.MontoColones.Name = "MontoColones";
            this.MontoColones.ReadOnly = true;
            this.MontoColones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MontoColones.Width = 120;
            // 
            // MontoDolares
            // 
            this.MontoDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            this.MontoDolares.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoDolares.FillWeight = 182.7411F;
            this.MontoDolares.HeaderText = "Monto Dolares";
            this.MontoDolares.MinimumWidth = 120;
            this.MontoDolares.Name = "MontoDolares";
            this.MontoDolares.ReadOnly = true;
            this.MontoDolares.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MontoDolares.Width = 120;
            // 
            // clmMontoEuros
            // 
            this.clmMontoEuros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.clmMontoEuros.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmMontoEuros.HeaderText = "Monto Euros";
            this.clmMontoEuros.Name = "clmMontoEuros";
            this.clmMontoEuros.ReadOnly = true;
            this.clmMontoEuros.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmMontoEuros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar1;
            this.btnGuardar.Location = new System.Drawing.Point(163, 676);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 47);
            this.btnGuardar.TabIndex = 40;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::GUILayer.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(270, 675);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(101, 47);
            this.btnImprimir.TabIndex = 41;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(390, 677);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 45);
            this.btnSalir.TabIndex = 42;
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
            this.pnlFondo.Location = new System.Drawing.Point(1, 3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1319, 60);
            this.pnlFondo.TabIndex = 43;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(11, 603);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(81, 13);
            this.lblObservaciones.TabIndex = 44;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Location = new System.Drawing.Point(12, 619);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(788, 58);
            this.txtObservaciones.TabIndex = 45;
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // tcOpciones
            // 
            this.tcOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcOpciones.Controls.Add(this.tabPage1);
            this.tcOpciones.Controls.Add(this.tpManifiestos);
            this.tcOpciones.Controls.Add(this.tpMontosClientes);
            this.tcOpciones.Controls.Add(this.tpImpresion);
            this.tcOpciones.Location = new System.Drawing.Point(713, 73);
            this.tcOpciones.Name = "tcOpciones";
            this.tcOpciones.SelectedIndex = 0;
            this.tcOpciones.Size = new System.Drawing.Size(654, 660);
            this.tcOpciones.TabIndex = 46;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbCajeros);
            this.tabPage1.Controls.Add(this.gbConsolidado);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(646, 634);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consolidado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbCajeros
            // 
            this.gbCajeros.Controls.Add(this.btnListar);
            this.gbCajeros.Controls.Add(this.btnActualizar);
            this.gbCajeros.Controls.Add(this.clbCajeros);
            this.gbCajeros.Location = new System.Drawing.Point(3, 6);
            this.gbCajeros.Name = "gbCajeros";
            this.gbCajeros.Size = new System.Drawing.Size(637, 128);
            this.gbCajeros.TabIndex = 0;
            this.gbCajeros.TabStop = false;
            this.gbCajeros.Text = "Cajeros y Digitadores";
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.SystemColors.Control;
            this.btnListar.FlatAppearance.BorderSize = 2;
            this.btnListar.Image = global::GUILayer.Properties.Resources.reiniciar;
            this.btnListar.Location = new System.Drawing.Point(515, 30);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(103, 40);
            this.btnListar.TabIndex = 1;
            this.btnListar.Text = "Listar";
            this.btnListar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(515, 78);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(103, 40);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // clbCajeros
            // 
            this.clbCajeros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbCajeros.FormattingEnabled = true;
            this.clbCajeros.Location = new System.Drawing.Point(6, 30);
            this.clbCajeros.Name = "clbCajeros";
            this.clbCajeros.Size = new System.Drawing.Size(503, 92);
            this.clbCajeros.TabIndex = 0;
            // 
            // gbConsolidado
            // 
            this.gbConsolidado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsolidado.Controls.Add(this.dgvConsolidado);
            this.gbConsolidado.Location = new System.Drawing.Point(3, 140);
            this.gbConsolidado.Name = "gbConsolidado";
            this.gbConsolidado.Size = new System.Drawing.Size(637, 488);
            this.gbConsolidado.TabIndex = 1;
            this.gbConsolidado.TabStop = false;
            this.gbConsolidado.Text = "Consolidado";
            // 
            // dgvConsolidado
            // 
            this.dgvConsolidado.AllowUserToAddRows = false;
            this.dgvConsolidado.AllowUserToDeleteRows = false;
            this.dgvConsolidado.AllowUserToOrderColumns = true;
            this.dgvConsolidado.AllowUserToResizeColumns = false;
            this.dgvConsolidado.AllowUserToResizeRows = false;
            this.dgvConsolidado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConsolidado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvConsolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsolidado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConceptoConsolidado,
            this.MontoColonesConsolidado,
            this.MontoDolaresConsolidado,
            this.clmMontoEurosCierre});
            this.dgvConsolidado.EnableHeadersVisualStyles = false;
            this.dgvConsolidado.Location = new System.Drawing.Point(6, 19);
            this.dgvConsolidado.Name = "dgvConsolidado";
            this.dgvConsolidado.ReadOnly = true;
            this.dgvConsolidado.RowHeadersVisible = false;
            this.dgvConsolidado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvConsolidado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvConsolidado.Size = new System.Drawing.Size(625, 463);
            this.dgvConsolidado.StandardTab = true;
            this.dgvConsolidado.TabIndex = 0;
            // 
            // ConceptoConsolidado
            // 
            this.ConceptoConsolidado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.ConceptoConsolidado.DefaultCellStyle = dataGridViewCellStyle5;
            this.ConceptoConsolidado.FillWeight = 28.48244F;
            this.ConceptoConsolidado.HeaderText = "Concepto";
            this.ConceptoConsolidado.Name = "ConceptoConsolidado";
            this.ConceptoConsolidado.ReadOnly = true;
            this.ConceptoConsolidado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ConceptoConsolidado.Width = 250;
            // 
            // MontoColonesConsolidado
            // 
            this.MontoColonesConsolidado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.MontoColonesConsolidado.DefaultCellStyle = dataGridViewCellStyle6;
            this.MontoColonesConsolidado.FillWeight = 88.77644F;
            this.MontoColonesConsolidado.HeaderText = "Monto Colones";
            this.MontoColonesConsolidado.MinimumWidth = 120;
            this.MontoColonesConsolidado.Name = "MontoColonesConsolidado";
            this.MontoColonesConsolidado.ReadOnly = true;
            this.MontoColonesConsolidado.Width = 120;
            // 
            // MontoDolaresConsolidado
            // 
            this.MontoDolaresConsolidado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            this.MontoDolaresConsolidado.DefaultCellStyle = dataGridViewCellStyle7;
            this.MontoDolaresConsolidado.FillWeight = 182.7411F;
            this.MontoDolaresConsolidado.HeaderText = "Monto Dolares";
            this.MontoDolaresConsolidado.MinimumWidth = 120;
            this.MontoDolaresConsolidado.Name = "MontoDolaresConsolidado";
            this.MontoDolaresConsolidado.ReadOnly = true;
            this.MontoDolaresConsolidado.Width = 120;
            // 
            // clmMontoEurosCierre
            // 
            this.clmMontoEurosCierre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.clmMontoEurosCierre.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmMontoEurosCierre.HeaderText = "Monto Euros";
            this.clmMontoEurosCierre.MinimumWidth = 120;
            this.clmMontoEurosCierre.Name = "clmMontoEurosCierre";
            this.clmMontoEurosCierre.ReadOnly = true;
            this.clmMontoEurosCierre.Width = 120;
            // 
            // tpManifiestos
            // 
            this.tpManifiestos.Controls.Add(this.gbFechaManifiestos);
            this.tpManifiestos.Controls.Add(this.gbManifiestos);
            this.tpManifiestos.Location = new System.Drawing.Point(4, 22);
            this.tpManifiestos.Name = "tpManifiestos";
            this.tpManifiestos.Padding = new System.Windows.Forms.Padding(3);
            this.tpManifiestos.Size = new System.Drawing.Size(646, 634);
            this.tpManifiestos.TabIndex = 2;
            this.tpManifiestos.Text = "Manifiestos";
            this.tpManifiestos.UseVisualStyleBackColor = true;
            // 
            // gbFechaManifiestos
            // 
            this.gbFechaManifiestos.Controls.Add(this.btnActualizarManifiesto);
            this.gbFechaManifiestos.Controls.Add(this.dtpFechaManifiestos);
            this.gbFechaManifiestos.Controls.Add(this.lblFechaManifiestos);
            this.gbFechaManifiestos.Location = new System.Drawing.Point(3, 6);
            this.gbFechaManifiestos.Name = "gbFechaManifiestos";
            this.gbFechaManifiestos.Size = new System.Drawing.Size(411, 65);
            this.gbFechaManifiestos.TabIndex = 0;
            this.gbFechaManifiestos.TabStop = false;
            this.gbFechaManifiestos.Text = "Fecha";
            // 
            // btnActualizarManifiesto
            // 
            this.btnActualizarManifiesto.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizarManifiesto.FlatAppearance.BorderSize = 2;
            this.btnActualizarManifiesto.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarManifiesto.Image")));
            this.btnActualizarManifiesto.Location = new System.Drawing.Point(302, 19);
            this.btnActualizarManifiesto.Name = "btnActualizarManifiesto";
            this.btnActualizarManifiesto.Size = new System.Drawing.Size(103, 40);
            this.btnActualizarManifiesto.TabIndex = 2;
            this.btnActualizarManifiesto.Text = "Actualizar";
            this.btnActualizarManifiesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarManifiesto.UseVisualStyleBackColor = false;
            this.btnActualizarManifiesto.Click += new System.EventHandler(this.btnActualizarManifiesto_Click);
            // 
            // dtpFechaManifiestos
            // 
            this.dtpFechaManifiestos.Location = new System.Drawing.Point(52, 29);
            this.dtpFechaManifiestos.Name = "dtpFechaManifiestos";
            this.dtpFechaManifiestos.Size = new System.Drawing.Size(244, 20);
            this.dtpFechaManifiestos.TabIndex = 1;
            // 
            // lblFechaManifiestos
            // 
            this.lblFechaManifiestos.AutoSize = true;
            this.lblFechaManifiestos.Location = new System.Drawing.Point(6, 33);
            this.lblFechaManifiestos.Name = "lblFechaManifiestos";
            this.lblFechaManifiestos.Size = new System.Drawing.Size(40, 13);
            this.lblFechaManifiestos.TabIndex = 0;
            this.lblFechaManifiestos.Text = "Fecha:";
            // 
            // gbManifiestos
            // 
            this.gbManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbManifiestos.Controls.Add(this.dgvManifiestos);
            this.gbManifiestos.Location = new System.Drawing.Point(3, 77);
            this.gbManifiestos.Name = "gbManifiestos";
            this.gbManifiestos.Size = new System.Drawing.Size(570, 442);
            this.gbManifiestos.TabIndex = 1;
            this.gbManifiestos.TabStop = false;
            this.gbManifiestos.Text = "Manifiestos";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToOrderColumns = true;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            this.dgvManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManifiestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManifiestos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 19);
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(558, 417);
            this.dgvManifiestos.StandardTab = true;
            this.dgvManifiestos.TabIndex = 0;
            // 
            // tpMontosClientes
            // 
            this.tpMontosClientes.Controls.Add(this.gbFiltro);
            this.tpMontosClientes.Controls.Add(this.gbMontosClientes);
            this.tpMontosClientes.Location = new System.Drawing.Point(4, 22);
            this.tpMontosClientes.Name = "tpMontosClientes";
            this.tpMontosClientes.Size = new System.Drawing.Size(646, 634);
            this.tpMontosClientes.TabIndex = 3;
            this.tpMontosClientes.Text = "Montos por Cliente";
            this.tpMontosClientes.UseVisualStyleBackColor = true;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.chkFiltrar);
            this.gbFiltro.Controls.Add(this.dtpFechaMontos);
            this.gbFiltro.Controls.Add(this.lblFechaMontos);
            this.gbFiltro.Controls.Add(this.pnlFiltro);
            this.gbFiltro.Controls.Add(this.btnActualizarMontosClientes);
            this.gbFiltro.Location = new System.Drawing.Point(3, 6);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(471, 122);
            this.gbFiltro.TabIndex = 0;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar";
            // 
            // chkFiltrar
            // 
            this.chkFiltrar.AutoSize = true;
            this.chkFiltrar.Location = new System.Drawing.Point(145, 105);
            this.chkFiltrar.Name = "chkFiltrar";
            this.chkFiltrar.Size = new System.Drawing.Size(153, 17);
            this.chkFiltrar.TabIndex = 5;
            this.chkFiltrar.Text = "Filtro por Cajero o Digitador";
            this.chkFiltrar.UseVisualStyleBackColor = true;
            this.chkFiltrar.CheckedChanged += new System.EventHandler(this.chkFiltrar_CheckedChanged_1);
            // 
            // dtpFechaMontos
            // 
            this.dtpFechaMontos.Location = new System.Drawing.Point(101, 19);
            this.dtpFechaMontos.Name = "dtpFechaMontos";
            this.dtpFechaMontos.Size = new System.Drawing.Size(255, 20);
            this.dtpFechaMontos.TabIndex = 1;
            // 
            // lblFechaMontos
            // 
            this.lblFechaMontos.AutoSize = true;
            this.lblFechaMontos.Location = new System.Drawing.Point(55, 23);
            this.lblFechaMontos.Name = "lblFechaMontos";
            this.lblFechaMontos.Size = new System.Drawing.Size(40, 13);
            this.lblFechaMontos.TabIndex = 0;
            this.lblFechaMontos.Text = "Fecha:";
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.cboCajeroMontos);
            this.pnlFiltro.Controls.Add(this.cboDigitadorMontos);
            this.pnlFiltro.Controls.Add(this.rbMontosDigitador);
            this.pnlFiltro.Controls.Add(this.rbMontosCajero);
            this.pnlFiltro.Enabled = false;
            this.pnlFiltro.Location = new System.Drawing.Point(0, 45);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(356, 48);
            this.pnlFiltro.TabIndex = 2;
            // 
            // cboCajeroMontos
            // 
            this.cboCajeroMontos.Busqueda = false;
            this.cboCajeroMontos.ListaMostrada = null;
            this.cboCajeroMontos.Location = new System.Drawing.Point(101, 0);
            this.cboCajeroMontos.Name = "cboCajeroMontos";
            this.cboCajeroMontos.Size = new System.Drawing.Size(255, 21);
            this.cboCajeroMontos.TabIndex = 1;
            this.cboCajeroMontos.SelectedIndexChanged += new System.EventHandler(this.cboCajeroMontos_SelectedIndexChanged);
            // 
            // cboDigitadorMontos
            // 
            this.cboDigitadorMontos.Busqueda = false;
            this.cboDigitadorMontos.Enabled = false;
            this.cboDigitadorMontos.ListaMostrada = null;
            this.cboDigitadorMontos.Location = new System.Drawing.Point(101, 27);
            this.cboDigitadorMontos.Name = "cboDigitadorMontos";
            this.cboDigitadorMontos.Size = new System.Drawing.Size(255, 21);
            this.cboDigitadorMontos.TabIndex = 3;
            // 
            // rbMontosDigitador
            // 
            this.rbMontosDigitador.AutoSize = true;
            this.rbMontosDigitador.Location = new System.Drawing.Point(6, 29);
            this.rbMontosDigitador.Name = "rbMontosDigitador";
            this.rbMontosDigitador.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbMontosDigitador.Size = new System.Drawing.Size(89, 17);
            this.rbMontosDigitador.TabIndex = 2;
            this.rbMontosDigitador.Text = "Por Digitador:";
            this.rbMontosDigitador.UseVisualStyleBackColor = true;
            this.rbMontosDigitador.CheckedChanged += new System.EventHandler(this.rbMontosDigitador_CheckedChanged);
            // 
            // rbMontosCajero
            // 
            this.rbMontosCajero.AutoSize = true;
            this.rbMontosCajero.Checked = true;
            this.rbMontosCajero.Location = new System.Drawing.Point(18, 2);
            this.rbMontosCajero.Name = "rbMontosCajero";
            this.rbMontosCajero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbMontosCajero.Size = new System.Drawing.Size(77, 17);
            this.rbMontosCajero.TabIndex = 0;
            this.rbMontosCajero.TabStop = true;
            this.rbMontosCajero.Text = "Por Cajero:";
            this.rbMontosCajero.UseVisualStyleBackColor = true;
            this.rbMontosCajero.CheckedChanged += new System.EventHandler(this.rbMontosCajero_CheckedChanged);
            // 
            // btnActualizarMontosClientes
            // 
            this.btnActualizarMontosClientes.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizarMontosClientes.FlatAppearance.BorderSize = 2;
            this.btnActualizarMontosClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarMontosClientes.Image")));
            this.btnActualizarMontosClientes.Location = new System.Drawing.Point(362, 76);
            this.btnActualizarMontosClientes.Name = "btnActualizarMontosClientes";
            this.btnActualizarMontosClientes.Size = new System.Drawing.Size(103, 40);
            this.btnActualizarMontosClientes.TabIndex = 4;
            this.btnActualizarMontosClientes.Text = "Actualizar";
            this.btnActualizarMontosClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarMontosClientes.UseVisualStyleBackColor = false;
            this.btnActualizarMontosClientes.Click += new System.EventHandler(this.btnActualizarMontosClientes_Click);
            // 
            // gbMontosClientes
            // 
            this.gbMontosClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMontosClientes.Controls.Add(this.dgvMontosClientes);
            this.gbMontosClientes.Location = new System.Drawing.Point(3, 134);
            this.gbMontosClientes.Name = "gbMontosClientes";
            this.gbMontosClientes.Size = new System.Drawing.Size(637, 497);
            this.gbMontosClientes.TabIndex = 1;
            this.gbMontosClientes.TabStop = false;
            this.gbMontosClientes.Text = "Montos";
            // 
            // dgvMontosClientes
            // 
            this.dgvMontosClientes.AllowUserToAddRows = false;
            this.dgvMontosClientes.AllowUserToDeleteRows = false;
            this.dgvMontosClientes.AllowUserToOrderColumns = true;
            this.dgvMontosClientes.AllowUserToResizeColumns = false;
            this.dgvMontosClientes.AllowUserToResizeRows = false;
            this.dgvMontosClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMontosClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMontosClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvMontosClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMontosClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvMontosClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontosClientes.EnableHeadersVisualStyles = false;
            this.dgvMontosClientes.Location = new System.Drawing.Point(6, 19);
            this.dgvMontosClientes.Name = "dgvMontosClientes";
            this.dgvMontosClientes.ReadOnly = true;
            this.dgvMontosClientes.RowHeadersVisible = false;
            this.dgvMontosClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontosClientes.Size = new System.Drawing.Size(625, 472);
            this.dgvMontosClientes.StandardTab = true;
            this.dgvMontosClientes.TabIndex = 0;
            // 
            // tpImpresion
            // 
            this.tpImpresion.Controls.Add(this.gbImpresion);
            this.tpImpresion.Location = new System.Drawing.Point(4, 22);
            this.tpImpresion.Name = "tpImpresion";
            this.tpImpresion.Size = new System.Drawing.Size(646, 634);
            this.tpImpresion.TabIndex = 4;
            this.tpImpresion.Text = "Impresión";
            this.tpImpresion.UseVisualStyleBackColor = true;
            // 
            // gbImpresion
            // 
            this.gbImpresion.Controls.Add(this.rbImpresionCoordinador);
            this.gbImpresion.Controls.Add(this.cboCoordinadorImpresion);
            this.gbImpresion.Controls.Add(this.cboImpresionCajero);
            this.gbImpresion.Controls.Add(this.cboImpresionDigitador);
            this.gbImpresion.Controls.Add(this.btnExportarExcel);
            this.gbImpresion.Controls.Add(this.rbImpresionDigitador);
            this.gbImpresion.Controls.Add(this.rbImpresionCajero);
            this.gbImpresion.Controls.Add(this.dtpFechaImpresion);
            this.gbImpresion.Controls.Add(this.lblFechaImpresion);
            this.gbImpresion.Location = new System.Drawing.Point(3, 6);
            this.gbImpresion.Name = "gbImpresion";
            this.gbImpresion.Size = new System.Drawing.Size(471, 162);
            this.gbImpresion.TabIndex = 0;
            this.gbImpresion.TabStop = false;
            this.gbImpresion.Text = "Impresion de Cierres";
            // 
            // rbImpresionCoordinador
            // 
            this.rbImpresionCoordinador.AutoSize = true;
            this.rbImpresionCoordinador.Location = new System.Drawing.Point(1, 50);
            this.rbImpresionCoordinador.Name = "rbImpresionCoordinador";
            this.rbImpresionCoordinador.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbImpresionCoordinador.Size = new System.Drawing.Size(101, 17);
            this.rbImpresionCoordinador.TabIndex = 8;
            this.rbImpresionCoordinador.Text = "Por Coordinador";
            this.rbImpresionCoordinador.UseVisualStyleBackColor = true;
            this.rbImpresionCoordinador.CheckedChanged += new System.EventHandler(this.rbImpresionCoordinador_CheckedChanged);
            // 
            // cboCoordinadorImpresion
            // 
            this.cboCoordinadorImpresion.Busqueda = false;
            this.cboCoordinadorImpresion.Enabled = false;
            this.cboCoordinadorImpresion.ListaMostrada = null;
            this.cboCoordinadorImpresion.Location = new System.Drawing.Point(113, 49);
            this.cboCoordinadorImpresion.Name = "cboCoordinadorImpresion";
            this.cboCoordinadorImpresion.Size = new System.Drawing.Size(256, 21);
            this.cboCoordinadorImpresion.TabIndex = 7;
            // 
            // cboImpresionCajero
            // 
            this.cboImpresionCajero.Busqueda = false;
            this.cboImpresionCajero.Enabled = false;
            this.cboImpresionCajero.ListaMostrada = null;
            this.cboImpresionCajero.Location = new System.Drawing.Point(113, 103);
            this.cboImpresionCajero.Name = "cboImpresionCajero";
            this.cboImpresionCajero.Size = new System.Drawing.Size(256, 21);
            this.cboImpresionCajero.TabIndex = 4;
            // 
            // cboImpresionDigitador
            // 
            this.cboImpresionDigitador.Busqueda = false;
            this.cboImpresionDigitador.ListaMostrada = null;
            this.cboImpresionDigitador.Location = new System.Drawing.Point(113, 76);
            this.cboImpresionDigitador.Name = "cboImpresionDigitador";
            this.cboImpresionDigitador.Size = new System.Drawing.Size(256, 21);
            this.cboImpresionDigitador.TabIndex = 5;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(375, 43);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(90, 40);
            this.btnExportarExcel.TabIndex = 1;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // rbImpresionDigitador
            // 
            this.rbImpresionDigitador.AutoSize = true;
            this.rbImpresionDigitador.Checked = true;
            this.rbImpresionDigitador.Location = new System.Drawing.Point(16, 78);
            this.rbImpresionDigitador.Name = "rbImpresionDigitador";
            this.rbImpresionDigitador.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbImpresionDigitador.Size = new System.Drawing.Size(86, 17);
            this.rbImpresionDigitador.TabIndex = 2;
            this.rbImpresionDigitador.TabStop = true;
            this.rbImpresionDigitador.Text = "Por Digitador";
            this.rbImpresionDigitador.UseVisualStyleBackColor = true;
            this.rbImpresionDigitador.CheckedChanged += new System.EventHandler(this.rbImpresionDigitador_CheckedChanged);
            // 
            // rbImpresionCajero
            // 
            this.rbImpresionCajero.AutoSize = true;
            this.rbImpresionCajero.Location = new System.Drawing.Point(28, 105);
            this.rbImpresionCajero.Name = "rbImpresionCajero";
            this.rbImpresionCajero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbImpresionCajero.Size = new System.Drawing.Size(74, 17);
            this.rbImpresionCajero.TabIndex = 3;
            this.rbImpresionCajero.Text = "Por Cajero";
            this.rbImpresionCajero.UseVisualStyleBackColor = true;
            this.rbImpresionCajero.CheckedChanged += new System.EventHandler(this.rbImpresionCajero_CheckedChanged);
            // 
            // dtpFechaImpresion
            // 
            this.dtpFechaImpresion.Location = new System.Drawing.Point(113, 23);
            this.dtpFechaImpresion.Name = "dtpFechaImpresion";
            this.dtpFechaImpresion.Size = new System.Drawing.Size(256, 20);
            this.dtpFechaImpresion.TabIndex = 1;
            this.dtpFechaImpresion.ValueChanged += new System.EventHandler(this.dtpFechaImpresion_ValueChanged);
            // 
            // lblFechaImpresion
            // 
            this.lblFechaImpresion.AutoSize = true;
            this.lblFechaImpresion.Location = new System.Drawing.Point(37, 30);
            this.lblFechaImpresion.Name = "lblFechaImpresion";
            this.lblFechaImpresion.Size = new System.Drawing.Size(40, 13);
            this.lblFechaImpresion.TabIndex = 0;
            this.lblFechaImpresion.Text = "Fecha:";
            // 
            // frmCierreCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 736);
            this.Controls.Add(this.tcOpciones);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbMontosCierre);
            this.Controls.Add(this.gbDatosCierre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCierreCajero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Cierre de Cajero";
            this.Load += new System.EventHandler(this.frmCierreCajero_Load);
            this.gbDatosCierre.ResumeLayout(false);
            this.gbDatosCierre.PerformLayout();
            this.gbSaldoInicial.ResumeLayout(false);
            this.gbSaldoInicial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNiquel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.gbMontosCierre.ResumeLayout(false);
            this.gbMontosCierre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierre)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.tcOpciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbCajeros.ResumeLayout(false);
            this.gbConsolidado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsolidado)).EndInit();
            this.tpManifiestos.ResumeLayout(false);
            this.gbFechaManifiestos.ResumeLayout(false);
            this.gbFechaManifiestos.PerformLayout();
            this.gbManifiestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.tpMontosClientes.ResumeLayout(false);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.gbMontosClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosClientes)).EndInit();
            this.tpImpresion.ResumeLayout(false);
            this.gbImpresion.ResumeLayout(false);
            this.gbImpresion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosCierre;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblCoordinador;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.CheckBox chkNiquel;
        private System.Windows.Forms.Button btnSaldoInicial;
        private System.Windows.Forms.GroupBox gbMontosCierre;
        private System.Windows.Forms.DataGridView dgvCierre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.GroupBox gbSaldoInicial;
        private System.Windows.Forms.Button btnAñadirSI;
        private ComboBoxBusqueda cboCajero;
        private ComboBoxBusqueda cboCoordinador;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblManifiestos;
        private System.Windows.Forms.Label lblNumManifiestos;
        private System.Windows.Forms.NumericUpDown nudNiquel;
        private System.Windows.Forms.Label lblMonto2;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblDigitador;
        private ComboBoxBusqueda cboDigitador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoEuros;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.TabControl tcOpciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbCajeros;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.CheckedListBox clbCajeros;
        private System.Windows.Forms.GroupBox gbConsolidado;
        private System.Windows.Forms.DataGridView dgvConsolidado;
        private System.Windows.Forms.TabPage tpManifiestos;
        private System.Windows.Forms.GroupBox gbFechaManifiestos;
        private System.Windows.Forms.Button btnActualizarManifiesto;
        private System.Windows.Forms.DateTimePicker dtpFechaManifiestos;
        private System.Windows.Forms.Label lblFechaManifiestos;
        private System.Windows.Forms.GroupBox gbManifiestos;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.TabPage tpMontosClientes;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.DateTimePicker dtpFechaMontos;
        private System.Windows.Forms.Label lblFechaMontos;
        private System.Windows.Forms.Panel pnlFiltro;
        private ComboBoxBusqueda cboCajeroMontos;
        private ComboBoxBusqueda cboDigitadorMontos;
        private System.Windows.Forms.RadioButton rbMontosDigitador;
        private System.Windows.Forms.RadioButton rbMontosCajero;
        private System.Windows.Forms.Button btnActualizarMontosClientes;
        private System.Windows.Forms.GroupBox gbMontosClientes;
        private System.Windows.Forms.DataGridView dgvMontosClientes;
        private System.Windows.Forms.TabPage tpImpresion;
        private System.Windows.Forms.GroupBox gbImpresion;
        private System.Windows.Forms.RadioButton rbImpresionCoordinador;
        private ComboBoxBusqueda cboCoordinadorImpresion;
        private ComboBoxBusqueda cboImpresionCajero;
        private ComboBoxBusqueda cboImpresionDigitador;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.RadioButton rbImpresionDigitador;
        private System.Windows.Forms.RadioButton rbImpresionCajero;
        private System.Windows.Forms.DateTimePicker dtpFechaImpresion;
        private System.Windows.Forms.Label lblFechaImpresion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoConsolidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesConsolidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresConsolidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoEurosCierre;
        private System.Windows.Forms.CheckBox chkFiltrar;
    }
}