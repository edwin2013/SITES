namespace GUILayer.Formularios.Níquel
{
    partial class frmListaPedidosNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPedidosNiquel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.pnlOpcionesCoordinacion = new System.Windows.Forms.Panel();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.clmPunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.gbEstados = new System.Windows.Forms.GroupBox();
            this.lblErrorCantidadCartuchos = new System.Windows.Forms.Label();
            this.pbErrorCantidadCartuchos = new System.Windows.Forms.PictureBox();
            this.lblErrorCantidadDenominaciones = new System.Windows.Forms.Label();
            this.pbErrorCantidadDenominaciones = new System.Windows.Forms.PictureBox();
            this.lblATMDesconocido = new System.Windows.Forms.Label();
            this.pbATMDesconocido = new System.Windows.Forms.PictureBox();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.pnlOpcionesCoordinacion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.gbEstados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadCartuchos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadDenominaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbATMDesconocido)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(795, 682);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(90, 40);
            this.btnRevisar.TabIndex = 11;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(891, 682);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(203, 0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(110, 0);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // pnlOpcionesCoordinacion
            // 
            this.pnlOpcionesCoordinacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnEliminar);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnModificar);
            this.pnlOpcionesCoordinacion.Location = new System.Drawing.Point(378, 682);
            this.pnlOpcionesCoordinacion.Name = "pnlOpcionesCoordinacion";
            this.pnlOpcionesCoordinacion.Size = new System.Drawing.Size(296, 40);
            this.pnlOpcionesCoordinacion.TabIndex = 10;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(999, 60);
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
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 200);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(975, 476);
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
            this.clmPunto,
            this.Asignada,
            this.MontoAsignadoColonesCarga,
            this.MontoColonesCarga,
            this.MontoAsignadoDolaresCarga,
            this.MontoDolaresCarga});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(963, 451);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellDoubleClick);
            this.dgvCargas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCargas_RowsAdded);
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // clmPunto
            // 
            this.clmPunto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmPunto.DataPropertyName = "Punto";
            this.clmPunto.HeaderText = "Punto";
            this.clmPunto.Name = "clmPunto";
            this.clmPunto.ReadOnly = true;
            this.clmPunto.Width = 59;
            // 
            // Asignada
            // 
            this.Asignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Asignada.DataPropertyName = "Cajero";
            this.Asignada.HeaderText = "Asignada";
            this.Asignada.Name = "Asignada";
            this.Asignada.ReadOnly = true;
            this.Asignada.Width = 75;
            // 
            // MontoAsignadoColonesCarga
            // 
            this.MontoAsignadoColonesCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoAsignadoColonesCarga.DataPropertyName = "Monto_asignado_colones";
            dataGridViewCellStyle2.Format = "N2";
            this.MontoAsignadoColonesCarga.DefaultCellStyle = dataGridViewCellStyle2;
            this.MontoAsignadoColonesCarga.HeaderText = "A. en Colones";
            this.MontoAsignadoColonesCarga.Name = "MontoAsignadoColonesCarga";
            this.MontoAsignadoColonesCarga.ReadOnly = true;
            this.MontoAsignadoColonesCarga.Width = 97;
            // 
            // MontoColonesCarga
            // 
            this.MontoColonesCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColonesCarga.DataPropertyName = "Monto_carga_colones";
            dataGridViewCellStyle3.Format = "N2";
            this.MontoColonesCarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoColonesCarga.HeaderText = "M. en Colones";
            this.MontoColonesCarga.Name = "MontoColonesCarga";
            this.MontoColonesCarga.ReadOnly = true;
            this.MontoColonesCarga.Width = 99;
            // 
            // MontoAsignadoDolaresCarga
            // 
            this.MontoAsignadoDolaresCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoAsignadoDolaresCarga.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle4.Format = "N2";
            this.MontoAsignadoDolaresCarga.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoAsignadoDolaresCarga.HeaderText = "A. en Dólares";
            this.MontoAsignadoDolaresCarga.Name = "MontoAsignadoDolaresCarga";
            this.MontoAsignadoDolaresCarga.ReadOnly = true;
            this.MontoAsignadoDolaresCarga.Width = 95;
            // 
            // MontoDolaresCarga
            // 
            this.MontoDolaresCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolaresCarga.DataPropertyName = "Monto_carga_dolares";
            dataGridViewCellStyle5.Format = "N2";
            this.MontoDolaresCarga.DefaultCellStyle = dataGridViewCellStyle5;
            this.MontoDolaresCarga.HeaderText = "M. en Dólares";
            this.MontoDolaresCarga.Name = "MontoDolaresCarga";
            this.MontoDolaresCarga.ReadOnly = true;
            this.MontoDolaresCarga.Width = 97;
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(523, 53);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = true;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(64, 20);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(245, 21);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(16, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
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
            this.gbFiltro.Controls.Add(this.gbEstados);
            this.gbFiltro.Controls.Add(this.cboPuntoVenta);
            this.gbFiltro.Controls.Add(this.lblPuntoVenta);
            this.gbFiltro.Controls.Add(this.lblTransportadora);
            this.gbFiltro.Controls.Add(this.cboTransportadora);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.cboCliente);
            this.gbFiltro.Controls.Add(this.lblCliente);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Location = new System.Drawing.Point(12, 72);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(969, 122);
            this.gbFiltro.TabIndex = 8;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Cargas";
            // 
            // gbEstados
            // 
            this.gbEstados.Controls.Add(this.lblErrorCantidadCartuchos);
            this.gbEstados.Controls.Add(this.pbErrorCantidadCartuchos);
            this.gbEstados.Controls.Add(this.lblErrorCantidadDenominaciones);
            this.gbEstados.Controls.Add(this.pbErrorCantidadDenominaciones);
            this.gbEstados.Controls.Add(this.lblATMDesconocido);
            this.gbEstados.Controls.Add(this.pbATMDesconocido);
            this.gbEstados.Location = new System.Drawing.Point(769, 9);
            this.gbEstados.Name = "gbEstados";
            this.gbEstados.Size = new System.Drawing.Size(194, 107);
            this.gbEstados.TabIndex = 14;
            this.gbEstados.TabStop = false;
            this.gbEstados.Text = "Estados";
            // 
            // lblErrorCantidadCartuchos
            // 
            this.lblErrorCantidadCartuchos.AutoSize = true;
            this.lblErrorCantidadCartuchos.Location = new System.Drawing.Point(28, 43);
            this.lblErrorCantidadCartuchos.Name = "lblErrorCantidadCartuchos";
            this.lblErrorCantidadCartuchos.Size = new System.Drawing.Size(61, 13);
            this.lblErrorCantidadCartuchos.TabIndex = 4;
            this.lblErrorCantidadCartuchos.Text = "En proceso";
            // 
            // pbErrorCantidadCartuchos
            // 
            this.pbErrorCantidadCartuchos.BackColor = global::GUILayer.Properties.Settings.Default.ErrorGeneracionCargasCantidadCartuchos;
            this.pbErrorCantidadCartuchos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbErrorCantidadCartuchos.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorGeneracionCargasCantidadCartuchos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbErrorCantidadCartuchos.Location = new System.Drawing.Point(6, 41);
            this.pbErrorCantidadCartuchos.Name = "pbErrorCantidadCartuchos";
            this.pbErrorCantidadCartuchos.Size = new System.Drawing.Size(16, 16);
            this.pbErrorCantidadCartuchos.TabIndex = 12;
            this.pbErrorCantidadCartuchos.TabStop = false;
            // 
            // lblErrorCantidadDenominaciones
            // 
            this.lblErrorCantidadDenominaciones.AutoSize = true;
            this.lblErrorCantidadDenominaciones.Location = new System.Drawing.Point(28, 65);
            this.lblErrorCantidadDenominaciones.Name = "lblErrorCantidadDenominaciones";
            this.lblErrorCantidadDenominaciones.Size = new System.Drawing.Size(152, 13);
            this.lblErrorCantidadDenominaciones.TabIndex = 2;
            this.lblErrorCantidadDenominaciones.Text = "Pendiente de Asignar al Cajero";
            // 
            // pbErrorCantidadDenominaciones
            // 
            this.pbErrorCantidadDenominaciones.BackColor = global::GUILayer.Properties.Settings.Default.ErrorGeneracionCargasCantidadDenominaciones;
            this.pbErrorCantidadDenominaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbErrorCantidadDenominaciones.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorGeneracionCargasCantidadDenominaciones", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbErrorCantidadDenominaciones.Location = new System.Drawing.Point(6, 63);
            this.pbErrorCantidadDenominaciones.Name = "pbErrorCantidadDenominaciones";
            this.pbErrorCantidadDenominaciones.Size = new System.Drawing.Size(16, 16);
            this.pbErrorCantidadDenominaciones.TabIndex = 10;
            this.pbErrorCantidadDenominaciones.TabStop = false;
            // 
            // lblATMDesconocido
            // 
            this.lblATMDesconocido.AutoSize = true;
            this.lblATMDesconocido.Location = new System.Drawing.Point(28, 21);
            this.lblATMDesconocido.Name = "lblATMDesconocido";
            this.lblATMDesconocido.Size = new System.Drawing.Size(90, 13);
            this.lblATMDesconocido.TabIndex = 0;
            this.lblATMDesconocido.Text = "Pedido Finalizado";
            this.lblATMDesconocido.Click += new System.EventHandler(this.lblATMDesconocido_Click);
            // 
            // pbATMDesconocido
            // 
            this.pbATMDesconocido.BackColor = global::GUILayer.Properties.Settings.Default.ErrorGeneracionCargasATMDesconocido;
            this.pbATMDesconocido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbATMDesconocido.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorGeneracionCargasATMDesconocido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbATMDesconocido.Location = new System.Drawing.Point(6, 19);
            this.pbATMDesconocido.Name = "pbATMDesconocido";
            this.pbATMDesconocido.Size = new System.Drawing.Size(16, 16);
            this.pbATMDesconocido.TabIndex = 0;
            this.pbATMDesconocido.TabStop = false;
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = true;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(371, 19);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(245, 21);
            this.cboPuntoVenta.TabIndex = 13;
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(332, 23);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(38, 13);
            this.lblPuntoVenta.TabIndex = 12;
            this.lblPuntoVenta.Text = "Punto:";
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(11, 75);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 11;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(99, 71);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(251, 21);
            this.cboTransportadora.TabIndex = 10;
            // 
            // frmListaPedidosNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 728);
            this.Controls.Add(this.btnRevisar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlOpcionesCoordinacion);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaPedidosNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Pedidos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlOpcionesCoordinacion.ResumeLayout(false);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbEstados.ResumeLayout(false);
            this.gbEstados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadCartuchos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadDenominaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbATMDesconocido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Panel pnlOpcionesCoordinacion;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnActualizar;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label lblTransportadora;
        private ComboBoxBusqueda cboTransportadora;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoDolaresCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresCarga;
        private System.Windows.Forms.GroupBox gbEstados;
        private System.Windows.Forms.Label lblErrorCantidadCartuchos;
        private System.Windows.Forms.PictureBox pbErrorCantidadCartuchos;
        private System.Windows.Forms.Label lblErrorCantidadDenominaciones;
        private System.Windows.Forms.PictureBox pbErrorCantidadDenominaciones;
        private System.Windows.Forms.Label lblATMDesconocido;
        private System.Windows.Forms.PictureBox pbATMDesconocido;
    }
}