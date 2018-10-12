namespace GUILayer.Formularios.Blindados
{
    partial class frmRevisionVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRevisionVehiculo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.chkRuta = new System.Windows.Forms.CheckBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmidtripulacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.nudRuta = new System.Windows.Forms.NumericUpDown();
            this.cboChofer = new GUILayer.ComboBoxBusqueda();
            this.lblChofer = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboVehiculo = new GUILayer.ComboBoxBusqueda();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.gbEstados = new System.Windows.Forms.GroupBox();
            this.lblChocado = new System.Windows.Forms.Label();
            this.pbChocado = new System.Windows.Forms.PictureBox();
            this.lblRayado = new System.Windows.Forms.Label();
            this.pbRayado = new System.Windows.Forms.PictureBox();
            this.lblQuebrado = new System.Windows.Forms.Label();
            this.pbQuebrado = new System.Windows.Forms.PictureBox();
            this.lblCamanance = new System.Windows.Forms.Label();
            this.pbCamanance = new System.Windows.Forms.PictureBox();
            this.lblSucio = new System.Windows.Forms.Label();
            this.pbSucio = new System.Windows.Forms.PictureBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.gbEstados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChocado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRayado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuebrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamanance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSucio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(596, 508);
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
            this.btnSalir.Location = new System.Drawing.Point(788, 508);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderSize = 2;
            this.btnExportar.Image = global::GUILayer.Properties.Resources.excel;
            this.btnExportar.Location = new System.Drawing.Point(692, 508);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(90, 40);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // chkRuta
            // 
            this.chkRuta.AutoSize = true;
            this.chkRuta.Location = new System.Drawing.Point(380, 33);
            this.chkRuta.Name = "chkRuta";
            this.chkRuta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRuta.Size = new System.Drawing.Size(52, 17);
            this.chkRuta.TabIndex = 4;
            this.chkRuta.Text = "Ruta:";
            this.chkRuta.UseVisualStyleBackColor = true;
            this.chkRuta.CheckedChanged += new System.EventHandler(this.chkRuta_CheckedChanged);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(896, 60);
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
            this.gbCargas.Location = new System.Drawing.Point(12, 201);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(872, 301);
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
            this.clmFecha,
            this.clmRuta,
            this.clmidtripulacion,
            this.clmChofer,
            this.clmVehiculo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
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
            this.dgvCargas.Size = new System.Drawing.Size(860, 276);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // clmFecha
            // 
            this.clmFecha.DataPropertyName = "Fecha";
            this.clmFecha.HeaderText = "Fecha";
            this.clmFecha.Name = "clmFecha";
            this.clmFecha.ReadOnly = true;
            // 
            // clmRuta
            // 
            this.clmRuta.DataPropertyName = "Ruta";
            this.clmRuta.HeaderText = "Ruta";
            this.clmRuta.Name = "clmRuta";
            this.clmRuta.ReadOnly = true;
            // 
            // clmidtripulacion
            // 
            this.clmidtripulacion.DataPropertyName = "IDTripulacion";
            this.clmidtripulacion.HeaderText = "ID Ruta";
            this.clmidtripulacion.Name = "clmidtripulacion";
            this.clmidtripulacion.ReadOnly = true;
            // 
            // clmChofer
            // 
            this.clmChofer.DataPropertyName = "Chofer";
            this.clmChofer.HeaderText = "Chofer";
            this.clmChofer.Name = "clmChofer";
            this.clmChofer.ReadOnly = true;
            // 
            // clmVehiculo
            // 
            this.clmVehiculo.DataPropertyName = "Vehiculo";
            this.clmVehiculo.HeaderText = "Vehiculo";
            this.clmVehiculo.Name = "clmVehiculo";
            this.clmVehiculo.ReadOnly = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(542, 48);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // nudRuta
            // 
            this.nudRuta.Enabled = false;
            this.nudRuta.Location = new System.Drawing.Point(438, 31);
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
            // cboChofer
            // 
            this.cboChofer.Busqueda = true;
            this.cboChofer.ListaMostrada = null;
            this.cboChofer.Location = new System.Drawing.Point(50, 71);
            this.cboChofer.Name = "cboChofer";
            this.cboChofer.Size = new System.Drawing.Size(245, 21);
            this.cboChofer.TabIndex = 1;
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(11, 75);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(41, 13);
            this.lblChofer.TabIndex = 0;
            this.lblChofer.Text = "Chofer:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(61, 34);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.Busqueda = true;
            this.cboVehiculo.ListaMostrada = null;
            this.cboVehiculo.Location = new System.Drawing.Point(348, 72);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(167, 21);
            this.cboVehiculo.TabIndex = 7;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(15, 38);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(40, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha:";
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Location = new System.Drawing.Point(314, 75);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(25, 13);
            this.lblVehiculo.TabIndex = 6;
            this.lblVehiculo.Text = "UB:";
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.gbEstados);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.dtpFechaFin);
            this.gbFiltro.Controls.Add(this.lblFechaFin);
            this.gbFiltro.Controls.Add(this.chkRuta);
            this.gbFiltro.Controls.Add(this.nudRuta);
            this.gbFiltro.Controls.Add(this.cboChofer);
            this.gbFiltro.Controls.Add(this.lblChofer);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.cboVehiculo);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Controls.Add(this.lblVehiculo);
            this.gbFiltro.Location = new System.Drawing.Point(12, 66);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(870, 129);
            this.gbFiltro.TabIndex = 8;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Cargas";
            // 
            // gbEstados
            // 
            this.gbEstados.Controls.Add(this.lblChocado);
            this.gbEstados.Controls.Add(this.pbChocado);
            this.gbEstados.Controls.Add(this.lblRayado);
            this.gbEstados.Controls.Add(this.pbRayado);
            this.gbEstados.Controls.Add(this.lblQuebrado);
            this.gbEstados.Controls.Add(this.pbQuebrado);
            this.gbEstados.Controls.Add(this.lblCamanance);
            this.gbEstados.Controls.Add(this.pbCamanance);
            this.gbEstados.Controls.Add(this.lblSucio);
            this.gbEstados.Controls.Add(this.pbSucio);
            this.gbEstados.Location = new System.Drawing.Point(641, 16);
            this.gbEstados.Name = "gbEstados";
            this.gbEstados.Size = new System.Drawing.Size(209, 107);
            this.gbEstados.TabIndex = 11;
            this.gbEstados.TabStop = false;
            this.gbEstados.Text = "Estados";
            // 
            // lblChocado
            // 
            this.lblChocado.AutoSize = true;
            this.lblChocado.Location = new System.Drawing.Point(121, 21);
            this.lblChocado.Name = "lblChocado";
            this.lblChocado.Size = new System.Drawing.Size(50, 13);
            this.lblChocado.TabIndex = 17;
            this.lblChocado.Text = "Chocado";
            // 
            // pbChocado
            // 
            this.pbChocado.BackColor = System.Drawing.Color.MediumOrchid;
            this.pbChocado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbChocado.Location = new System.Drawing.Point(99, 19);
            this.pbChocado.Name = "pbChocado";
            this.pbChocado.Size = new System.Drawing.Size(16, 16);
            this.pbChocado.TabIndex = 18;
            this.pbChocado.TabStop = false;
            // 
            // lblRayado
            // 
            this.lblRayado.AutoSize = true;
            this.lblRayado.Location = new System.Drawing.Point(28, 43);
            this.lblRayado.Name = "lblRayado";
            this.lblRayado.Size = new System.Drawing.Size(44, 13);
            this.lblRayado.TabIndex = 4;
            this.lblRayado.Text = "Rayado";
            // 
            // pbRayado
            // 
            this.pbRayado.BackColor = global::GUILayer.Properties.Settings.Default.ErrorGeneracionCargasCantidadCartuchos;
            this.pbRayado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRayado.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorGeneracionCargasCantidadCartuchos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbRayado.Location = new System.Drawing.Point(6, 41);
            this.pbRayado.Name = "pbRayado";
            this.pbRayado.Size = new System.Drawing.Size(16, 16);
            this.pbRayado.TabIndex = 12;
            this.pbRayado.TabStop = false;
            // 
            // lblQuebrado
            // 
            this.lblQuebrado.AutoSize = true;
            this.lblQuebrado.Location = new System.Drawing.Point(28, 65);
            this.lblQuebrado.Name = "lblQuebrado";
            this.lblQuebrado.Size = new System.Drawing.Size(54, 13);
            this.lblQuebrado.TabIndex = 2;
            this.lblQuebrado.Text = "Quebrado";
            // 
            // pbQuebrado
            // 
            this.pbQuebrado.BackColor = global::GUILayer.Properties.Settings.Default.ErrorGeneracionCargasCantidadDenominaciones;
            this.pbQuebrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbQuebrado.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorGeneracionCargasCantidadDenominaciones", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbQuebrado.Location = new System.Drawing.Point(6, 63);
            this.pbQuebrado.Name = "pbQuebrado";
            this.pbQuebrado.Size = new System.Drawing.Size(16, 16);
            this.pbQuebrado.TabIndex = 10;
            this.pbQuebrado.TabStop = false;
            // 
            // lblCamanance
            // 
            this.lblCamanance.AutoSize = true;
            this.lblCamanance.Location = new System.Drawing.Point(121, 46);
            this.lblCamanance.Name = "lblCamanance";
            this.lblCamanance.Size = new System.Drawing.Size(64, 13);
            this.lblCamanance.TabIndex = 3;
            this.lblCamanance.Text = "Camanance";
            // 
            // pbCamanance
            // 
            this.pbCamanance.BackColor = global::GUILayer.Properties.Settings.Default.ErrorGeneracionCargasDenominaciones;
            this.pbCamanance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCamanance.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorGeneracionCargasDenominaciones", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbCamanance.Location = new System.Drawing.Point(99, 43);
            this.pbCamanance.Name = "pbCamanance";
            this.pbCamanance.Size = new System.Drawing.Size(16, 16);
            this.pbCamanance.TabIndex = 8;
            this.pbCamanance.TabStop = false;
            // 
            // lblSucio
            // 
            this.lblSucio.AutoSize = true;
            this.lblSucio.Location = new System.Drawing.Point(28, 21);
            this.lblSucio.Name = "lblSucio";
            this.lblSucio.Size = new System.Drawing.Size(34, 13);
            this.lblSucio.TabIndex = 0;
            this.lblSucio.Text = "Sucio";
            // 
            // pbSucio
            // 
            this.pbSucio.BackColor = global::GUILayer.Properties.Settings.Default.ErrorGeneracionCargasATMDesconocido;
            this.pbSucio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSucio.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorGeneracionCargasATMDesconocido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbSucio.Location = new System.Drawing.Point(6, 19);
            this.pbSucio.Name = "pbSucio";
            this.pbSucio.Size = new System.Drawing.Size(16, 16);
            this.pbSucio.TabIndex = 0;
            this.pbSucio.TabStop = false;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(254, 34);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(104, 20);
            this.dtpFechaFin.TabIndex = 10;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(208, 38);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(40, 13);
            this.lblFechaFin.TabIndex = 9;
            this.lblFechaFin.Text = "Fecha:";
            // 
            // frmRevisionVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 570);
            this.Controls.Add(this.btnRevisar);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCargas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRevisionVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revisión Vehículo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbEstados.ResumeLayout(false);
            this.gbEstados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChocado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRayado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuebrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamanance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSucio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.CheckBox chkRuta;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.NumericUpDown nudRuta;
        private ComboBoxBusqueda cboChofer;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ComboBoxBusqueda cboVehiculo;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.GroupBox gbEstados;
        private System.Windows.Forms.Label lblChocado;
        private System.Windows.Forms.PictureBox pbChocado;
        private System.Windows.Forms.Label lblRayado;
        private System.Windows.Forms.PictureBox pbRayado;
        private System.Windows.Forms.Label lblQuebrado;
        private System.Windows.Forms.PictureBox pbQuebrado;
        private System.Windows.Forms.Label lblCamanance;
        private System.Windows.Forms.PictureBox pbCamanance;
        private System.Windows.Forms.Label lblSucio;
        private System.Windows.Forms.PictureBox pbSucio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmidtripulacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVehiculo;
    }
}