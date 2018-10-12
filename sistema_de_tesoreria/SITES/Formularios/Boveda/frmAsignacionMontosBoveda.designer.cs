namespace GUILayer
{
    partial class frmAsignacionMontosBoveda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignacionMontosBoveda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCajero = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gbDatosAsignacion = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCajero = new System.Windows.Forms.Label();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.txtCodigoBuscado = new System.Windows.Forms.TextBox();
            this.Transportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblManifiestoBuscado = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Menifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.txtFechaProcesamiento = new System.Windows.Forms.TextBox();
            this.lblFechaProcesamiento = new System.Windows.Forms.Label();
            this.txtPuntoVenta = new System.Windows.Forms.TextBox();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.lblPuntoVentaManifiesto = new System.Windows.Forms.Label();
            this.lblSucursalManifiesto = new System.Windows.Forms.Label();
            this.nudMontoDolares = new System.Windows.Forms.NumericUpDown();
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.lblMontoDolares = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCajeroManifiesto = new System.Windows.Forms.Label();
            this.lblClienteManifiesto = new System.Windows.Forms.Label();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiesto = new System.Windows.Forms.Label();
            this.nudMontoColones = new System.Windows.Forms.NumericUpDown();
            this.lblMontoColones = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.gbRecaps = new System.Windows.Forms.GroupBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvRecaps = new System.Windows.Forms.DataGridView();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBillete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtbCodigoCliente = new System.Windows.Forms.MaskedTextBox();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.mtbCodigoSucursal = new System.Windows.Forms.MaskedTextBox();
            this.lblCodigoSucursal = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.gbSucursal = new System.Windows.Forms.GroupBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.cboSucursal = new GUILayer.ComboBoxBusqueda();
            this.rbSucursal = new System.Windows.Forms.RadioButton();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.gbDatosAsignacion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolares)).BeginInit();
            this.gbDatosManifiesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoColones)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            this.gbRecaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecaps)).BeginInit();
            this.gbCliente.SuspendLayout();
            this.gbSucursal.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCajero
            // 
            this.txtCajero.Location = new System.Drawing.Point(119, 45);
            this.txtCajero.Name = "txtCajero";
            this.txtCajero.ReadOnly = true;
            this.txtCajero.Size = new System.Drawing.Size(232, 20);
            this.txtCajero.TabIndex = 3;
            this.txtCajero.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(281, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(73, 50);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // gbDatosAsignacion
            // 
            this.gbDatosAsignacion.Controls.Add(this.lblFecha);
            this.gbDatosAsignacion.Controls.Add(this.dtpFecha);
            this.gbDatosAsignacion.Controls.Add(this.lblCajero);
            this.gbDatosAsignacion.Controls.Add(this.cboCajero);
            this.gbDatosAsignacion.Location = new System.Drawing.Point(395, 51);
            this.gbDatosAsignacion.Name = "gbDatosAsignacion";
            this.gbDatosAsignacion.Size = new System.Drawing.Size(357, 72);
            this.gbDatosAsignacion.TabIndex = 3;
            this.gbDatosAsignacion.TabStop = false;
            this.gbDatosAsignacion.Text = "Datos a Asignar";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(119, 46);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(232, 20);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.TabStop = false;
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(73, 23);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 0;
            this.lblCajero.Text = "Cajero:";
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(119, 19);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(232, 21);
            this.cboCajero.TabIndex = 1;
            this.cboCajero.TabStop = false;
            this.cboCajero.SelectedIndexChanged += new System.EventHandler(this.cboCajero_SelectedIndexChanged);
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(29, 76);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(84, 13);
            this.lblPuntoVenta.TabIndex = 4;
            this.lblPuntoVenta.Text = "Punto de Venta:";
            // 
            // txtCodigoBuscado
            // 
            this.txtCodigoBuscado.Location = new System.Drawing.Point(55, 29);
            this.txtCodigoBuscado.Name = "txtCodigoBuscado";
            this.txtCodigoBuscado.Size = new System.Drawing.Size(220, 20);
            this.txtCodigoBuscado.TabIndex = 1;
            this.txtCodigoBuscado.TextChanged += new System.EventHandler(this.txtCodigoBuscado_TextChanged);
            this.txtCodigoBuscado.Enter += new System.EventHandler(this.txtCodigoBuscado_Enter);
            // 
            // Transportadora
            // 
            this.Transportadora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Transportadora.DataPropertyName = "Empresa";
            this.Transportadora.HeaderText = "Transportadora";
            this.Transportadora.Name = "Transportadora";
            this.Transportadora.ReadOnly = true;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(769, 48);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(379, 46);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
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
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(656, 545);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(560, 545);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Menifiesto
            // 
            this.Menifiesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Menifiesto.DataPropertyName = "Codigo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Menifiesto.DefaultCellStyle = dataGridViewCellStyle8;
            this.Menifiesto.HeaderText = "Código de Manifiesto";
            this.Menifiesto.Name = "Menifiesto";
            this.Menifiesto.ReadOnly = true;
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvManifiestos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvManifiestos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Menifiesto,
            this.Transportadora});
            this.dgvManifiestos.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 65);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvManifiestos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(365, 192);
            this.dgvManifiestos.TabIndex = 3;
            this.dgvManifiestos.TabStop = false;
            this.dgvManifiestos.SelectionChanged += new System.EventHandler(this.dgvManifiestos_SelectionChanged);
            // 
            // txtFechaProcesamiento
            // 
            this.txtFechaProcesamiento.Location = new System.Drawing.Point(119, 149);
            this.txtFechaProcesamiento.Name = "txtFechaProcesamiento";
            this.txtFechaProcesamiento.ReadOnly = true;
            this.txtFechaProcesamiento.Size = new System.Drawing.Size(232, 20);
            this.txtFechaProcesamiento.TabIndex = 11;
            this.txtFechaProcesamiento.TabStop = false;
            // 
            // lblFechaProcesamiento
            // 
            this.lblFechaProcesamiento.AutoSize = true;
            this.lblFechaProcesamiento.Location = new System.Drawing.Point(6, 153);
            this.lblFechaProcesamiento.Name = "lblFechaProcesamiento";
            this.lblFechaProcesamiento.Size = new System.Drawing.Size(107, 13);
            this.lblFechaProcesamiento.TabIndex = 10;
            this.lblFechaProcesamiento.Text = "F. de Procesamiento:";
            // 
            // txtPuntoVenta
            // 
            this.txtPuntoVenta.Location = new System.Drawing.Point(119, 97);
            this.txtPuntoVenta.Name = "txtPuntoVenta";
            this.txtPuntoVenta.ReadOnly = true;
            this.txtPuntoVenta.Size = new System.Drawing.Size(232, 20);
            this.txtPuntoVenta.TabIndex = 7;
            this.txtPuntoVenta.TabStop = false;
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(119, 123);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.ReadOnly = true;
            this.txtSucursal.Size = new System.Drawing.Size(232, 20);
            this.txtSucursal.TabIndex = 9;
            this.txtSucursal.TabStop = false;
            // 
            // lblPuntoVentaManifiesto
            // 
            this.lblPuntoVentaManifiesto.AutoSize = true;
            this.lblPuntoVentaManifiesto.Location = new System.Drawing.Point(29, 100);
            this.lblPuntoVentaManifiesto.Name = "lblPuntoVentaManifiesto";
            this.lblPuntoVentaManifiesto.Size = new System.Drawing.Size(84, 13);
            this.lblPuntoVentaManifiesto.TabIndex = 6;
            this.lblPuntoVentaManifiesto.Text = "Punto de Venta:";
            // 
            // lblSucursalManifiesto
            // 
            this.lblSucursalManifiesto.AutoSize = true;
            this.lblSucursalManifiesto.Location = new System.Drawing.Point(62, 127);
            this.lblSucursalManifiesto.Name = "lblSucursalManifiesto";
            this.lblSucursalManifiesto.Size = new System.Drawing.Size(51, 13);
            this.lblSucursalManifiesto.TabIndex = 8;
            this.lblSucursalManifiesto.Text = "Sucursal:";
            // 
            // nudMontoDolares
            // 
            this.nudMontoDolares.DecimalPlaces = 2;
            this.nudMontoDolares.Location = new System.Drawing.Point(119, 201);
            this.nudMontoDolares.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoDolares.Name = "nudMontoDolares";
            this.nudMontoDolares.Size = new System.Drawing.Size(232, 20);
            this.nudMontoDolares.TabIndex = 15;
            this.nudMontoDolares.ThousandsSeparator = true;
            this.nudMontoDolares.Enter += new System.EventHandler(this.nudMontoDolares_Enter);
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.txtFechaProcesamiento);
            this.gbDatosManifiesto.Controls.Add(this.lblFechaProcesamiento);
            this.gbDatosManifiesto.Controls.Add(this.txtPuntoVenta);
            this.gbDatosManifiesto.Controls.Add(this.lblPuntoVentaManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.txtSucursal);
            this.gbDatosManifiesto.Controls.Add(this.lblSucursalManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.nudMontoDolares);
            this.gbDatosManifiesto.Controls.Add(this.lblMontoDolares);
            this.gbDatosManifiesto.Controls.Add(this.txtCliente);
            this.gbDatosManifiesto.Controls.Add(this.txtCajero);
            this.gbDatosManifiesto.Controls.Add(this.lblCajeroManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.lblClienteManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.txtCodigoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.lblCodigoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.nudMontoColones);
            this.gbDatosManifiesto.Controls.Add(this.lblMontoColones);
            this.gbDatosManifiesto.Enabled = false;
            this.gbDatosManifiesto.Location = new System.Drawing.Point(395, 312);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(357, 227);
            this.gbDatosManifiesto.TabIndex = 8;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos Actuales del Manifiesto";
            // 
            // lblMontoDolares
            // 
            this.lblMontoDolares.AutoSize = true;
            this.lblMontoDolares.Location = new System.Drawing.Point(19, 205);
            this.lblMontoDolares.Name = "lblMontoDolares";
            this.lblMontoDolares.Size = new System.Drawing.Size(94, 13);
            this.lblMontoDolares.TabIndex = 14;
            this.lblMontoDolares.Text = "Monto en Dolares:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(119, 71);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(232, 20);
            this.txtCliente.TabIndex = 5;
            this.txtCliente.TabStop = false;
            // 
            // lblCajeroManifiesto
            // 
            this.lblCajeroManifiesto.AutoSize = true;
            this.lblCajeroManifiesto.Location = new System.Drawing.Point(73, 49);
            this.lblCajeroManifiesto.Name = "lblCajeroManifiesto";
            this.lblCajeroManifiesto.Size = new System.Drawing.Size(40, 13);
            this.lblCajeroManifiesto.TabIndex = 2;
            this.lblCajeroManifiesto.Text = "Cajero:";
            // 
            // lblClienteManifiesto
            // 
            this.lblClienteManifiesto.AutoSize = true;
            this.lblClienteManifiesto.Location = new System.Drawing.Point(71, 75);
            this.lblClienteManifiesto.Name = "lblClienteManifiesto";
            this.lblClienteManifiesto.Size = new System.Drawing.Size(42, 13);
            this.lblClienteManifiesto.TabIndex = 4;
            this.lblClienteManifiesto.Text = "Cliente:";
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(119, 19);
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.ReadOnly = true;
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(232, 20);
            this.txtCodigoManifiesto.TabIndex = 1;
            this.txtCodigoManifiesto.TabStop = false;
            // 
            // lblCodigoManifiesto
            // 
            this.lblCodigoManifiesto.AutoSize = true;
            this.lblCodigoManifiesto.Location = new System.Drawing.Point(70, 23);
            this.lblCodigoManifiesto.Name = "lblCodigoManifiesto";
            this.lblCodigoManifiesto.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiesto.TabIndex = 0;
            this.lblCodigoManifiesto.Text = "Código:";
            // 
            // nudMontoColones
            // 
            this.nudMontoColones.DecimalPlaces = 2;
            this.nudMontoColones.Location = new System.Drawing.Point(119, 175);
            this.nudMontoColones.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoColones.Name = "nudMontoColones";
            this.nudMontoColones.Size = new System.Drawing.Size(232, 20);
            this.nudMontoColones.TabIndex = 13;
            this.nudMontoColones.ThousandsSeparator = true;
            this.nudMontoColones.Enter += new System.EventHandler(this.nudMontoColones_Enter);
            // 
            // lblMontoColones
            // 
            this.lblMontoColones.AutoSize = true;
            this.lblMontoColones.Location = new System.Drawing.Point(17, 179);
            this.lblMontoColones.Name = "lblMontoColones";
            this.lblMontoColones.Size = new System.Drawing.Size(96, 13);
            this.lblMontoColones.TabIndex = 12;
            this.lblMontoColones.Text = "Monto en Colones:";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Enabled = false;
            this.btnReiniciar.Image = global::GUILayer.Properties.Resources.reiniciar;
            this.btnReiniciar.Location = new System.Drawing.Point(464, 545);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(90, 40);
            this.btnReiniciar.TabIndex = 9;
            this.btnReiniciar.TabStop = false;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dgvManifiestos);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Controls.Add(this.txtCodigoBuscado);
            this.gbBusqueda.Controls.Add(this.lblManifiestoBuscado);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 51);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbBusqueda.Size = new System.Drawing.Size(377, 263);
            this.gbBusqueda.TabIndex = 1;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda de Manifiestos";
            // 
            // gbRecaps
            // 
            this.gbRecaps.Controls.Add(this.btnQuitar);
            this.gbRecaps.Controls.Add(this.btnAgregar);
            this.gbRecaps.Controls.Add(this.dgvRecaps);
            this.gbRecaps.Enabled = false;
            this.gbRecaps.Location = new System.Drawing.Point(12, 320);
            this.gbRecaps.Name = "gbRecaps";
            this.gbRecaps.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbRecaps.Size = new System.Drawing.Size(377, 219);
            this.gbRecaps.TabIndex = 2;
            this.gbRecaps.TabStop = false;
            this.gbRecaps.Text = "Recaps";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnQuitar.Location = new System.Drawing.Point(281, 173);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(90, 40);
            this.btnQuitar.TabIndex = 2;
            this.btnQuitar.TabStop = false;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregar.Location = new System.Drawing.Point(185, 173);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 40);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvRecaps
            // 
            this.dgvRecaps.AllowUserToAddRows = false;
            this.dgvRecaps.AllowUserToDeleteRows = false;
            this.dgvRecaps.AllowUserToResizeColumns = false;
            this.dgvRecaps.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRecaps.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvRecaps.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvRecaps.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecaps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvRecaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Moneda,
            this.TotalBillete,
            this.TotalMoneda});
            this.dgvRecaps.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecaps.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvRecaps.EnableHeadersVisualStyles = false;
            this.dgvRecaps.Location = new System.Drawing.Point(6, 19);
            this.dgvRecaps.MultiSelect = false;
            this.dgvRecaps.Name = "dgvRecaps";
            this.dgvRecaps.ReadOnly = true;
            this.dgvRecaps.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvRecaps.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRecaps.RowHeadersVisible = false;
            this.dgvRecaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecaps.Size = new System.Drawing.Size(365, 148);
            this.dgvRecaps.TabIndex = 0;
            this.dgvRecaps.TabStop = false;
            this.dgvRecaps.SelectionChanged += new System.EventHandler(this.dgvRecaps_SelectionChanged);
            // 
            // Moneda
            // 
            this.Moneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            // 
            // TotalBillete
            // 
            this.TotalBillete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalBillete.HeaderText = "Total Billete";
            this.TotalBillete.Name = "TotalBillete";
            this.TotalBillete.ReadOnly = true;
            // 
            // TotalMoneda
            // 
            this.TotalMoneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalMoneda.HeaderText = "Total Moneda";
            this.TotalMoneda.Name = "TotalMoneda";
            this.TotalMoneda.ReadOnly = true;
            // 
            // mtbCodigoCliente
            // 
            this.mtbCodigoCliente.Location = new System.Drawing.Point(119, 19);
            this.mtbCodigoCliente.Mask = "999999";
            this.mtbCodigoCliente.Name = "mtbCodigoCliente";
            this.mtbCodigoCliente.Size = new System.Drawing.Size(232, 20);
            this.mtbCodigoCliente.TabIndex = 1;
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Location = new System.Drawing.Point(20, 23);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(93, 13);
            this.lblCodigoCliente.TabIndex = 0;
            this.lblCodigoCliente.Text = "Código de Cliente:";
            // 
            // mtbCodigoSucursal
            // 
            this.mtbCodigoSucursal.Location = new System.Drawing.Point(119, 19);
            this.mtbCodigoSucursal.Mask = "999999";
            this.mtbCodigoSucursal.Name = "mtbCodigoSucursal";
            this.mtbCodigoSucursal.Size = new System.Drawing.Size(232, 20);
            this.mtbCodigoSucursal.TabIndex = 1;
            // 
            // lblCodigoSucursal
            // 
            this.lblCodigoSucursal.AutoSize = true;
            this.lblCodigoSucursal.Location = new System.Drawing.Point(11, 23);
            this.lblCodigoSucursal.Name = "lblCodigoSucursal";
            this.lblCodigoSucursal.Size = new System.Drawing.Size(102, 13);
            this.lblCodigoSucursal.TabIndex = 0;
            this.lblCodigoSucursal.Text = "Código de Sucursal:";
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.lblCliente);
            this.gbCliente.Controls.Add(this.cboCliente);
            this.gbCliente.Controls.Add(this.lblCodigoCliente);
            this.gbCliente.Controls.Add(this.cboPuntoVenta);
            this.gbCliente.Controls.Add(this.mtbCodigoCliente);
            this.gbCliente.Controls.Add(this.lblPuntoVenta);
            this.gbCliente.Enabled = false;
            this.gbCliente.Location = new System.Drawing.Point(395, 207);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(357, 99);
            this.gbCliente.TabIndex = 7;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Cliente";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(71, 49);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(119, 45);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(232, 21);
            this.cboCliente.TabIndex = 3;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            this.cboCliente.Enter += new System.EventHandler(this.cboCliente_Enter);
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = false;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(119, 72);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(232, 21);
            this.cboPuntoVenta.TabIndex = 5;
            this.cboPuntoVenta.SelectedIndexChanged += new System.EventHandler(this.cboPuntoVenta_SelectedIndexChanged);
            // 
            // gbSucursal
            // 
            this.gbSucursal.Controls.Add(this.lblSucursal);
            this.gbSucursal.Controls.Add(this.mtbCodigoSucursal);
            this.gbSucursal.Controls.Add(this.lblCodigoSucursal);
            this.gbSucursal.Controls.Add(this.cboSucursal);
            this.gbSucursal.Location = new System.Drawing.Point(395, 129);
            this.gbSucursal.Name = "gbSucursal";
            this.gbSucursal.Size = new System.Drawing.Size(357, 72);
            this.gbSucursal.TabIndex = 5;
            this.gbSucursal.TabStop = false;
            this.gbSucursal.Text = "Sucursal";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(62, 49);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(51, 13);
            this.lblSucursal.TabIndex = 2;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // cboSucursal
            // 
            this.cboSucursal.Busqueda = false;
            this.cboSucursal.ListaMostrada = null;
            this.cboSucursal.Location = new System.Drawing.Point(119, 45);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(232, 21);
            this.cboSucursal.TabIndex = 3;
            this.cboSucursal.TabStop = false;
            this.cboSucursal.SelectedIndexChanged += new System.EventHandler(this.cboSucursal_SelectedIndexChanged);
            this.cboSucursal.Enter += new System.EventHandler(this.cboSucursal_Enter);
            // 
            // rbSucursal
            // 
            this.rbSucursal.AutoSize = true;
            this.rbSucursal.Checked = true;
            this.rbSucursal.Location = new System.Drawing.Point(404, 129);
            this.rbSucursal.Name = "rbSucursal";
            this.rbSucursal.Size = new System.Drawing.Size(66, 17);
            this.rbSucursal.TabIndex = 4;
            this.rbSucursal.TabStop = true;
            this.rbSucursal.Text = "Sucursal";
            this.rbSucursal.UseVisualStyleBackColor = true;
            this.rbSucursal.CheckedChanged += new System.EventHandler(this.rbSucursal_CheckedChanged);
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Location = new System.Drawing.Point(404, 207);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(57, 17);
            this.rbCliente.TabIndex = 6;
            this.rbCliente.Text = "Cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            this.rbCliente.CheckedChanged += new System.EventHandler(this.rbCliente_CheckedChanged);
            // 
            // frmAsignacionMontosBoveda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 597);
            this.Controls.Add(this.rbCliente);
            this.Controls.Add(this.rbSucursal);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbRecaps);
            this.Controls.Add(this.gbDatosAsignacion);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDatosManifiesto);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.gbSucursal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignacionMontosBoveda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Montos a los Manfiestos de Bóveda General";
            this.gbDatosAsignacion.ResumeLayout(false);
            this.gbDatosAsignacion.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolares)).EndInit();
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoColones)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbRecaps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecaps)).EndInit();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.gbSucursal.ResumeLayout(false);
            this.gbSucursal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCajero;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox gbDatosAsignacion;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ComboBoxBusqueda cboSucursal;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblCajero;
        private ComboBoxBusqueda cboCajero;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.TextBox txtCodigoBuscado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transportadora;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblManifiestoBuscado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menifiesto;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.TextBox txtFechaProcesamiento;
        private System.Windows.Forms.Label lblFechaProcesamiento;
        private System.Windows.Forms.TextBox txtPuntoVenta;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.Label lblPuntoVentaManifiesto;
        private System.Windows.Forms.Label lblSucursalManifiesto;
        private System.Windows.Forms.NumericUpDown nudMontoDolares;
        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.Label lblMontoDolares;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCajeroManifiesto;
        private System.Windows.Forms.Label lblClienteManifiesto;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblCodigoManifiesto;
        private System.Windows.Forms.NumericUpDown nudMontoColones;
        private System.Windows.Forms.Label lblMontoColones;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.GroupBox gbRecaps;
        private System.Windows.Forms.DataGridView dgvRecaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBillete;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoneda;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.MaskedTextBox mtbCodigoCliente;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.MaskedTextBox mtbCodigoSucursal;
        private System.Windows.Forms.Label lblCodigoSucursal;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.GroupBox gbSucursal;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.RadioButton rbSucursal;
        private System.Windows.Forms.RadioButton rbCliente;

    }
}