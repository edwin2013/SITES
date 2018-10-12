namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmProcesamientoAltoVolumen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesamientoAltoVolumen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.lblPuntodeVenta = new System.Windows.Forms.Label();
            this.txtColaborador = new System.Windows.Forms.TextBox();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.btnCancelarTula = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.cboCamara = new GUILayer.ComboBoxBusqueda();
            this.lblCamara = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNumeroManifiesto = new System.Windows.Forms.Label();
            this.gbDatosTula = new System.Windows.Forms.GroupBox();
            this.cboMonedaTula = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMontoTula = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsignarTula = new System.Windows.Forms.Button();
            this.chkTulaMixta = new System.Windows.Forms.CheckBox();
            this.txtHeaderCard = new System.Windows.Forms.TextBox();
            this.lblHeadercard = new System.Windows.Forms.Label();
            this.txtTula = new System.Windows.Forms.TextBox();
            this.lblCodigoTula = new System.Windows.Forms.Label();
            this.dgvDetalleAltoVolumen = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDatosManifiesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.gbDatosTula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoTula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAltoVolumen)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.cboPuntoVenta);
            this.gbDatosManifiesto.Controls.Add(this.lblPuntodeVenta);
            this.gbDatosManifiesto.Controls.Add(this.txtColaborador);
            this.gbDatosManifiesto.Controls.Add(this.lblColaborador);
            this.gbDatosManifiesto.Controls.Add(this.btnCancelarTula);
            this.gbDatosManifiesto.Controls.Add(this.btnVerificar);
            this.gbDatosManifiesto.Controls.Add(this.cboCamara);
            this.gbDatosManifiesto.Controls.Add(this.lblCamara);
            this.gbDatosManifiesto.Controls.Add(this.cboMoneda);
            this.gbDatosManifiesto.Controls.Add(this.nudMonto);
            this.gbDatosManifiesto.Controls.Add(this.cboCliente);
            this.gbDatosManifiesto.Controls.Add(this.lblMonto);
            this.gbDatosManifiesto.Controls.Add(this.lblCliente);
            this.gbDatosManifiesto.Controls.Add(this.lblMoneda);
            this.gbDatosManifiesto.Controls.Add(this.txtNumero);
            this.gbDatosManifiesto.Controls.Add(this.lblNumeroManifiesto);
            this.gbDatosManifiesto.Location = new System.Drawing.Point(8, 71);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(669, 180);
            this.gbDatosManifiesto.TabIndex = 0;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos del Manifiesto";
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = false;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(69, 99);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(251, 21);
            this.cboPuntoVenta.TabIndex = 3;
            this.cboPuntoVenta.SelectedIndexChanged += new System.EventHandler(this.cboPuntoVenta_SelectedIndexChanged);
            // 
            // lblPuntodeVenta
            // 
            this.lblPuntodeVenta.Location = new System.Drawing.Point(9, 99);
            this.lblPuntodeVenta.Name = "lblPuntodeVenta";
            this.lblPuntodeVenta.Size = new System.Drawing.Size(50, 33);
            this.lblPuntodeVenta.TabIndex = 8;
            this.lblPuntodeVenta.Text = "Punto de Venta:";
            // 
            // txtColaborador
            // 
            this.txtColaborador.Location = new System.Drawing.Point(408, 21);
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.ReadOnly = true;
            this.txtColaborador.Size = new System.Drawing.Size(251, 20);
            this.txtColaborador.TabIndex = 4;
            this.txtColaborador.TabStop = false;
            // 
            // lblColaborador
            // 
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Location = new System.Drawing.Point(334, 24);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(67, 13);
            this.lblColaborador.TabIndex = 21;
            this.lblColaborador.Text = "Colaborador:";
            // 
            // btnCancelarTula
            // 
            this.btnCancelarTula.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarTula.Image")));
            this.btnCancelarTula.Location = new System.Drawing.Point(355, 131);
            this.btnCancelarTula.Name = "btnCancelarTula";
            this.btnCancelarTula.Size = new System.Drawing.Size(90, 40);
            this.btnCancelarTula.TabIndex = 9;
            this.btnCancelarTula.Text = "Cancelar";
            this.btnCancelarTula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarTula.UseVisualStyleBackColor = false;
            this.btnCancelarTula.Click += new System.EventHandler(this.btnCancelarTula_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.Image = global::GUILayer.Properties.Resources.revision;
            this.btnVerificar.Location = new System.Drawing.Point(252, 132);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(90, 40);
            this.btnVerificar.TabIndex = 7;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // cboCamara
            // 
            this.cboCamara.Busqueda = true;
            this.cboCamara.FormattingEnabled = true;
            this.cboCamara.ListaMostrada = null;
            this.cboCamara.Location = new System.Drawing.Point(69, 19);
            this.cboCamara.Name = "cboCamara";
            this.cboCamara.Size = new System.Drawing.Size(250, 21);
            this.cboCamara.TabIndex = 0;
            this.cboCamara.SelectedIndexChanged += new System.EventHandler(this.cboCamara_SelectedIndexChanged);
            // 
            // lblCamara
            // 
            this.lblCamara.AutoSize = true;
            this.lblCamara.Location = new System.Drawing.Point(15, 28);
            this.lblCamara.Name = "lblCamara";
            this.lblCamara.Size = new System.Drawing.Size(46, 13);
            this.lblCamara.TabIndex = 16;
            this.lblCamara.Text = "Cámara:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares"});
            this.cboMoneda.Location = new System.Drawing.Point(408, 49);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(251, 21);
            this.cboMoneda.TabIndex = 5;
            // 
            // nudMonto
            // 
            this.nudMonto.Location = new System.Drawing.Point(408, 76);
            this.nudMonto.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(251, 20);
            this.nudMonto.TabIndex = 6;
            this.nudMonto.ValueChanged += new System.EventHandler(this.nudMonto_ValueChanged);
            this.nudMonto.Click += new System.EventHandler(this.nudMonto_Click);
            this.nudMonto.Enter += new System.EventHandler(this.nudMonto_Enter);
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(69, 72);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(250, 21);
            this.cboCliente.TabIndex = 2;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(359, 79);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(20, 75);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(352, 52);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 4;
            this.lblMoneda.Text = "Moneda:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(69, 46);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(250, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // lblNumeroManifiesto
            // 
            this.lblNumeroManifiesto.AutoSize = true;
            this.lblNumeroManifiesto.Location = new System.Drawing.Point(16, 49);
            this.lblNumeroManifiesto.Name = "lblNumeroManifiesto";
            this.lblNumeroManifiesto.Size = new System.Drawing.Size(43, 13);
            this.lblNumeroManifiesto.TabIndex = 0;
            this.lblNumeroManifiesto.Text = "Código:";
            // 
            // gbDatosTula
            // 
            this.gbDatosTula.Controls.Add(this.cboMonedaTula);
            this.gbDatosTula.Controls.Add(this.label2);
            this.gbDatosTula.Controls.Add(this.nudMontoTula);
            this.gbDatosTula.Controls.Add(this.label1);
            this.gbDatosTula.Controls.Add(this.btnAsignarTula);
            this.gbDatosTula.Controls.Add(this.chkTulaMixta);
            this.gbDatosTula.Controls.Add(this.txtHeaderCard);
            this.gbDatosTula.Controls.Add(this.lblHeadercard);
            this.gbDatosTula.Controls.Add(this.txtTula);
            this.gbDatosTula.Controls.Add(this.lblCodigoTula);
            this.gbDatosTula.Enabled = false;
            this.gbDatosTula.Location = new System.Drawing.Point(9, 256);
            this.gbDatosTula.Name = "gbDatosTula";
            this.gbDatosTula.Size = new System.Drawing.Size(669, 166);
            this.gbDatosTula.TabIndex = 1;
            this.gbDatosTula.TabStop = false;
            this.gbDatosTula.Text = "Datos de Tula";
            // 
            // cboMonedaTula
            // 
            this.cboMonedaTula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaTula.FormattingEnabled = true;
            this.cboMonedaTula.Items.AddRange(new object[] {
            "Colones",
            "Dólares"});
            this.cboMonedaTula.Location = new System.Drawing.Point(407, 29);
            this.cboMonedaTula.Name = "cboMonedaTula";
            this.cboMonedaTula.Size = new System.Drawing.Size(252, 21);
            this.cboMonedaTula.TabIndex = 2;
            this.cboMonedaTula.SelectedIndexChanged += new System.EventHandler(this.cboMonedaTula_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Moneda:";
            // 
            // nudMontoTula
            // 
            this.nudMontoTula.Location = new System.Drawing.Point(407, 55);
            this.nudMontoTula.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMontoTula.Name = "nudMontoTula";
            this.nudMontoTula.Size = new System.Drawing.Size(254, 20);
            this.nudMontoTula.TabIndex = 3;
            this.nudMontoTula.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.nudMontoTula.Click += new System.EventHandler(this.nudMontoTula_Click);
            this.nudMontoTula.Enter += new System.EventHandler(this.nudMontoTula_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(361, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Monto:";
            // 
            // btnAsignarTula
            // 
            this.btnAsignarTula.Image = global::GUILayer.Properties.Resources.revision;
            this.btnAsignarTula.Location = new System.Drawing.Point(288, 116);
            this.btnAsignarTula.Name = "btnAsignarTula";
            this.btnAsignarTula.Size = new System.Drawing.Size(104, 40);
            this.btnAsignarTula.TabIndex = 5;
            this.btnAsignarTula.Text = "Asignar";
            this.btnAsignarTula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignarTula.UseVisualStyleBackColor = false;
            this.btnAsignarTula.Click += new System.EventHandler(this.btnAsignarTula_Click);
            // 
            // chkTulaMixta
            // 
            this.chkTulaMixta.AutoSize = true;
            this.chkTulaMixta.Location = new System.Drawing.Point(288, 83);
            this.chkTulaMixta.Name = "chkTulaMixta";
            this.chkTulaMixta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTulaMixta.Size = new System.Drawing.Size(75, 17);
            this.chkTulaMixta.TabIndex = 4;
            this.chkTulaMixta.Text = "Tula Mixta";
            this.chkTulaMixta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTulaMixta.UseVisualStyleBackColor = true;
            // 
            // txtHeaderCard
            // 
            this.txtHeaderCard.Location = new System.Drawing.Point(86, 56);
            this.txtHeaderCard.Name = "txtHeaderCard";
            this.txtHeaderCard.Size = new System.Drawing.Size(255, 20);
            this.txtHeaderCard.TabIndex = 1;
            this.txtHeaderCard.TextChanged += new System.EventHandler(this.txtHeaderCard_TextChanged);
            // 
            // lblHeadercard
            // 
            this.lblHeadercard.AutoSize = true;
            this.lblHeadercard.Location = new System.Drawing.Point(11, 59);
            this.lblHeadercard.Name = "lblHeadercard";
            this.lblHeadercard.Size = new System.Drawing.Size(67, 13);
            this.lblHeadercard.TabIndex = 4;
            this.lblHeadercard.Text = "HeaderCard:";
            // 
            // txtTula
            // 
            this.txtTula.Location = new System.Drawing.Point(86, 30);
            this.txtTula.Name = "txtTula";
            this.txtTula.Size = new System.Drawing.Size(255, 20);
            this.txtTula.TabIndex = 0;
            this.txtTula.TextChanged += new System.EventHandler(this.txtTula_TextChanged);
            this.txtTula.Leave += new System.EventHandler(this.txtTula_Leave);
            // 
            // lblCodigoTula
            // 
            this.lblCodigoTula.AutoSize = true;
            this.lblCodigoTula.Location = new System.Drawing.Point(35, 33);
            this.lblCodigoTula.Name = "lblCodigoTula";
            this.lblCodigoTula.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoTula.TabIndex = 2;
            this.lblCodigoTula.Text = "Código:";
            // 
            // dgvDetalleAltoVolumen
            // 
            this.dgvDetalleAltoVolumen.AllowUserToAddRows = false;
            this.dgvDetalleAltoVolumen.AllowUserToDeleteRows = false;
            this.dgvDetalleAltoVolumen.AllowUserToResizeColumns = false;
            this.dgvDetalleAltoVolumen.AllowUserToResizeRows = false;
            this.dgvDetalleAltoVolumen.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetalleAltoVolumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleAltoVolumen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula,
            this.HeaderCard,
            this.Moneda,
            this.Monto});
            this.dgvDetalleAltoVolumen.EnableHeadersVisualStyles = false;
            this.dgvDetalleAltoVolumen.Location = new System.Drawing.Point(9, 428);
            this.dgvDetalleAltoVolumen.MultiSelect = false;
            this.dgvDetalleAltoVolumen.Name = "dgvDetalleAltoVolumen";
            this.dgvDetalleAltoVolumen.ReadOnly = true;
            this.dgvDetalleAltoVolumen.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvDetalleAltoVolumen.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleAltoVolumen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalleAltoVolumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleAltoVolumen.Size = new System.Drawing.Size(669, 137);
            this.dgvDetalleAltoVolumen.StandardTab = true;
            this.dgvDetalleAltoVolumen.TabIndex = 2;
            this.dgvDetalleAltoVolumen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleAltoVolumen_CellClick);
            this.dgvDetalleAltoVolumen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleAltoVolumen_CellContentClick);
            this.dgvDetalleAltoVolumen.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTulas_CellEndEdit);
            this.dgvDetalleAltoVolumen.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetalleAltoVolumen_CellMouseClick);
            this.dgvDetalleAltoVolumen.SelectionChanged += new System.EventHandler(this.dgvDetalleAltoVolumen_SelectionChanged);
            this.dgvDetalleAltoVolumen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDetalleAltoVolumen_MouseDown);
            // 
            // Tula
            // 
            this.Tula.DataPropertyName = "Tula";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Tula.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            this.Tula.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tula.Width = 150;
            // 
            // HeaderCard
            // 
            this.HeaderCard.DataPropertyName = "HeaderCard";
            this.HeaderCard.HeaderText = "HeaderCard";
            this.HeaderCard.Name = "HeaderCard";
            this.HeaderCard.ReadOnly = true;
            this.HeaderCard.Width = 150;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "Moneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            this.Moneda.Width = 150;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 200;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(340, 571);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Enabled = false;
            this.btnTerminar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnTerminar.Location = new System.Drawing.Point(237, 571);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(90, 40);
            this.btnTerminar.TabIndex = 3;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(2, 5);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(439, 60);
            this.pnlFondo.TabIndex = 23;
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
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // frmProcesamientoAltoVolumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 615);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.dgvDetalleAltoVolumen);
            this.Controls.Add(this.gbDatosTula);
            this.Controls.Add(this.gbDatosManifiesto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmProcesamientoAltoVolumen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Procesamiento Alto Volumen";
            this.Load += new System.EventHandler(this.frmProcesamientoAltoVolumen_Load);
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.gbDatosTula.ResumeLayout(false);
            this.gbDatosTula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoTula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAltoVolumen)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private ComboBoxBusqueda cboCamara;
        private System.Windows.Forms.Label lblCamara;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNumeroManifiesto;
        private System.Windows.Forms.Button btnCancelarTula;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.GroupBox gbDatosTula;
        private System.Windows.Forms.TextBox txtHeaderCard;
        private System.Windows.Forms.Label lblHeadercard;
        private System.Windows.Forms.TextBox txtTula;
        private System.Windows.Forms.Label lblCodigoTula;
        private System.Windows.Forms.Button btnAsignarTula;
        private System.Windows.Forms.CheckBox chkTulaMixta;
        private System.Windows.Forms.DataGridView dgvDetalleAltoVolumen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.TextBox txtColaborador;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblPuntodeVenta;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.ComboBox cboMonedaTula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMontoTula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
    }
}