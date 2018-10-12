namespace GUILayer.Formularios.Cajeros_Automaticos
{
    partial class frmListaCargasATMCajerosAutomaticos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaCargasATMCajerosAutomaticos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.chkRuta = new System.Windows.Forms.CheckBox();
            this.nudRuta = new System.Windows.Forms.NumericUpDown();
            this.lblATM = new System.Windows.Forms.Label();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.ATMCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCodigoATM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Full = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmCodigoApertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCodigoColaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tmrActualizarCargas = new System.Windows.Forms.Timer(this.components);
            this.gbEstados = new System.Windows.Forms.GroupBox();
            this.lblErrorPendientes = new System.Windows.Forms.Label();
            this.pbErrorMínimoFormulas = new System.Windows.Forms.PictureBox();
            this.lblEsperaCodigoCierre = new System.Windows.Forms.Label();
            this.pbErrorCantidadCartuchos = new System.Windows.Forms.PictureBox();
            this.lblListoPorFinalizar = new System.Windows.Forms.Label();
            this.pbErrorCantidadDenominaciones = new System.Windows.Forms.PictureBox();
            this.lblSolicitudCodigo = new System.Windows.Forms.Label();
            this.pbATMDesconocido = new System.Windows.Forms.PictureBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.gbEstados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorMínimoFormulas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadCartuchos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadDenominaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbATMDesconocido)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1004, 60);
            this.pnlFondo.TabIndex = 7;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // chkRuta
            // 
            this.chkRuta.AutoSize = true;
            this.chkRuta.Location = new System.Drawing.Point(174, 48);
            this.chkRuta.Name = "chkRuta";
            this.chkRuta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRuta.Size = new System.Drawing.Size(52, 17);
            this.chkRuta.TabIndex = 4;
            this.chkRuta.Text = "Ruta:";
            this.chkRuta.UseVisualStyleBackColor = true;
            this.chkRuta.CheckedChanged += new System.EventHandler(this.chkRuta_CheckedChanged);
            // 
            // nudRuta
            // 
            this.nudRuta.Enabled = false;
            this.nudRuta.Location = new System.Drawing.Point(232, 46);
            this.nudRuta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRuta.Name = "nudRuta";
            this.nudRuta.Size = new System.Drawing.Size(77, 20);
            this.nudRuta.TabIndex = 5;
            this.nudRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRuta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(25, 23);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(33, 13);
            this.lblATM.TabIndex = 0;
            this.lblATM.Text = "ATM:";
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 160);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(980, 374);
            this.gbCargas.TabIndex = 9;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Cargas";
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.AllowUserToOrderColumns = true;
            this.dgvCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATMCarga,
            this.clmCodigoATM,
            this.Tipo,
            this.Full,
            this.clmCodigoApertura,
            this.clmCierre,
            this.clmCodigoColaborador});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.MultiSelect = false;
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(968, 349);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCargas_RowsAdded);
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // ATMCarga
            // 
            this.ATMCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATMCarga.DataPropertyName = "Numero";
            this.ATMCarga.HeaderText = "ATM";
            this.ATMCarga.Name = "ATMCarga";
            this.ATMCarga.ReadOnly = true;
            this.ATMCarga.Width = 54;
            // 
            // clmCodigoATM
            // 
            this.clmCodigoATM.DataPropertyName = "ATM";
            this.clmCodigoATM.HeaderText = "Nombre";
            this.clmCodigoATM.Name = "clmCodigoATM";
            this.clmCodigoATM.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Full
            // 
            this.Full.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Full.DataPropertyName = "ATM_full";
            this.Full.HeaderText = "Full";
            this.Full.Name = "Full";
            this.Full.ReadOnly = true;
            this.Full.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Full.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Full.Width = 47;
            // 
            // clmCodigoApertura
            // 
            this.clmCodigoApertura.DataPropertyName = "CodigoApertura";
            this.clmCodigoApertura.HeaderText = "Código de Apertura";
            this.clmCodigoApertura.Name = "clmCodigoApertura";
            this.clmCodigoApertura.ReadOnly = true;
            // 
            // clmCierre
            // 
            this.clmCierre.DataPropertyName = "CodigoCierre";
            this.clmCierre.HeaderText = "Código de Cierre";
            this.clmCierre.Name = "clmCierre";
            this.clmCierre.ReadOnly = true;
            // 
            // clmCodigoColaborador
            // 
            this.clmCodigoColaborador.DataPropertyName = "NumeroLlave";
            this.clmCodigoColaborador.HeaderText = "Número de Llave";
            this.clmCodigoColaborador.Name = "clmCodigoColaborador";
            this.clmCodigoColaborador.ReadOnly = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(64, 46);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(18, 50);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(40, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha:";
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.chkRuta);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.nudRuta);
            this.gbFiltro.Controls.Add(this.cboATM);
            this.gbFiltro.Controls.Add(this.lblATM);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Location = new System.Drawing.Point(12, 72);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(483, 82);
            this.gbFiltro.TabIndex = 8;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Cargas";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(360, 23);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = true;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(64, 19);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(245, 21);
            this.cboATM.TabIndex = 1;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.Enabled = false;
            this.btnFinalizar.FlatAppearance.BorderSize = 2;
            this.btnFinalizar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnFinalizar.Location = new System.Drawing.Point(12, 540);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(90, 40);
            this.btnFinalizar.TabIndex = 14;
            this.btnFinalizar.Text = "Terminar";
            this.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(800, 540);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(896, 540);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tmrActualizarCargas
            // 
            this.tmrActualizarCargas.Interval = 15000;
            this.tmrActualizarCargas.Tick += new System.EventHandler(this.btnActualizar_Click);
            // 
            // gbEstados
            // 
            this.gbEstados.Controls.Add(this.lblErrorPendientes);
            this.gbEstados.Controls.Add(this.pbErrorMínimoFormulas);
            this.gbEstados.Controls.Add(this.lblEsperaCodigoCierre);
            this.gbEstados.Controls.Add(this.pbErrorCantidadCartuchos);
            this.gbEstados.Controls.Add(this.lblListoPorFinalizar);
            this.gbEstados.Controls.Add(this.pbErrorCantidadDenominaciones);
            this.gbEstados.Controls.Add(this.lblSolicitudCodigo);
            this.gbEstados.Controls.Add(this.pbATMDesconocido);
            this.gbEstados.Location = new System.Drawing.Point(525, 72);
            this.gbEstados.Name = "gbEstados";
            this.gbEstados.Size = new System.Drawing.Size(319, 92);
            this.gbEstados.TabIndex = 15;
            this.gbEstados.TabStop = false;
            this.gbEstados.Text = "Estados";
            // 
            // lblErrorPendientes
            // 
            this.lblErrorPendientes.AutoSize = true;
            this.lblErrorPendientes.Location = new System.Drawing.Point(243, 21);
            this.lblErrorPendientes.Name = "lblErrorPendientes";
            this.lblErrorPendientes.Size = new System.Drawing.Size(60, 13);
            this.lblErrorPendientes.TabIndex = 17;
            this.lblErrorPendientes.Text = "Pendientes";
            // 
            // pbErrorMínimoFormulas
            // 
            this.pbErrorMínimoFormulas.BackColor = System.Drawing.Color.Silver;
            this.pbErrorMínimoFormulas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbErrorMínimoFormulas.Location = new System.Drawing.Point(221, 19);
            this.pbErrorMínimoFormulas.Name = "pbErrorMínimoFormulas";
            this.pbErrorMínimoFormulas.Size = new System.Drawing.Size(16, 16);
            this.pbErrorMínimoFormulas.TabIndex = 18;
            this.pbErrorMínimoFormulas.TabStop = false;
            // 
            // lblEsperaCodigoCierre
            // 
            this.lblEsperaCodigoCierre.AutoSize = true;
            this.lblEsperaCodigoCierre.Location = new System.Drawing.Point(28, 43);
            this.lblEsperaCodigoCierre.Name = "lblEsperaCodigoCierre";
            this.lblEsperaCodigoCierre.Size = new System.Drawing.Size(130, 13);
            this.lblEsperaCodigoCierre.TabIndex = 4;
            this.lblEsperaCodigoCierre.Text = "Espera al código de cierre";
            // 
            // pbErrorCantidadCartuchos
            // 
            this.pbErrorCantidadCartuchos.BackColor = global::GUILayer.Properties.Settings.Default.EsperaCodigoCierre;
            this.pbErrorCantidadCartuchos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbErrorCantidadCartuchos.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "EsperaCodigoCierre", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbErrorCantidadCartuchos.Location = new System.Drawing.Point(6, 41);
            this.pbErrorCantidadCartuchos.Name = "pbErrorCantidadCartuchos";
            this.pbErrorCantidadCartuchos.Size = new System.Drawing.Size(16, 16);
            this.pbErrorCantidadCartuchos.TabIndex = 12;
            this.pbErrorCantidadCartuchos.TabStop = false;
            // 
            // lblListoPorFinalizar
            // 
            this.lblListoPorFinalizar.AutoSize = true;
            this.lblListoPorFinalizar.Location = new System.Drawing.Point(28, 65);
            this.lblListoPorFinalizar.Name = "lblListoPorFinalizar";
            this.lblListoPorFinalizar.Size = new System.Drawing.Size(88, 13);
            this.lblListoPorFinalizar.TabIndex = 2;
            this.lblListoPorFinalizar.Text = "Listo por Finalizar";
            // 
            // pbErrorCantidadDenominaciones
            // 
            this.pbErrorCantidadDenominaciones.BackColor = global::GUILayer.Properties.Settings.Default.CodigoCierreRecibido;
            this.pbErrorCantidadDenominaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbErrorCantidadDenominaciones.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "CodigoCierreRecibido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbErrorCantidadDenominaciones.Location = new System.Drawing.Point(6, 63);
            this.pbErrorCantidadDenominaciones.Name = "pbErrorCantidadDenominaciones";
            this.pbErrorCantidadDenominaciones.Size = new System.Drawing.Size(16, 16);
            this.pbErrorCantidadDenominaciones.TabIndex = 10;
            this.pbErrorCantidadDenominaciones.TabStop = false;
            // 
            // lblSolicitudCodigo
            // 
            this.lblSolicitudCodigo.AutoSize = true;
            this.lblSolicitudCodigo.Location = new System.Drawing.Point(28, 21);
            this.lblSolicitudCodigo.Name = "lblSolicitudCodigo";
            this.lblSolicitudCodigo.Size = new System.Drawing.Size(141, 13);
            this.lblSolicitudCodigo.TabIndex = 0;
            this.lblSolicitudCodigo.Text = "Solicitud Código de Apertura";
            // 
            // pbATMDesconocido
            // 
            this.pbATMDesconocido.BackColor = global::GUILayer.Properties.Settings.Default.SolicitudCodigoApertura;
            this.pbATMDesconocido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbATMDesconocido.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "SolicitudCodigoApertura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbATMDesconocido.Location = new System.Drawing.Point(6, 19);
            this.pbATMDesconocido.Name = "pbATMDesconocido";
            this.pbATMDesconocido.Size = new System.Drawing.Size(16, 16);
            this.pbATMDesconocido.TabIndex = 0;
            this.pbATMDesconocido.TabStop = false;
            // 
            // frmListaCargasATMCajerosAutomaticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 586);
            this.Controls.Add(this.gbEstados);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaCargasATMCajerosAutomaticos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de ATM\'s";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbEstados.ResumeLayout(false);
            this.gbEstados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorMínimoFormulas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadCartuchos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadDenominaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbATMDesconocido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.CheckBox chkRuta;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.NumericUpDown nudRuta;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Timer tmrActualizarCargas;
        private System.Windows.Forms.GroupBox gbEstados;
        private System.Windows.Forms.Label lblErrorPendientes;
        private System.Windows.Forms.PictureBox pbErrorMínimoFormulas;
        private System.Windows.Forms.Label lblEsperaCodigoCierre;
        private System.Windows.Forms.PictureBox pbErrorCantidadCartuchos;
        private System.Windows.Forms.Label lblListoPorFinalizar;
        private System.Windows.Forms.PictureBox pbErrorCantidadDenominaciones;
        private System.Windows.Forms.Label lblSolicitudCodigo;
        private System.Windows.Forms.PictureBox pbATMDesconocido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATMCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoATM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Full;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoApertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoColaborador;
    }
}