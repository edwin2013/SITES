namespace GUILayer
{
    partial class frmListaCargas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaCargas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnActualizarEspecial = new System.Windows.Forms.Button();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.chkRuta = new System.Windows.Forms.CheckBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.nudRuta = new System.Windows.Forms.NumericUpDown();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.lblATM = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.pnlOpcionesCoordinacion = new System.Windows.Forms.Panel();
            this.btnOrdenRutas = new System.Windows.Forms.Button();
            this.btnCartuchos = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMontos = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAsignarRuta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.btnAlarmasPapel = new System.Windows.Forms.Button();
            this.ATMCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Full = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmCarga = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmDescarga = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmPapel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).BeginInit();
            this.pnlOpcionesCoordinacion.SuspendLayout();
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
            this.pnlFondo.TabIndex = 0;
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
            this.gbCargas.Location = new System.Drawing.Point(12, 171);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(980, 357);
            this.gbCargas.TabIndex = 2;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATMCarga,
            this.Tipo,
            this.Ruta,
            this.Asignada,
            this.MontoAsignadoColonesCarga,
            this.MontoColonesCarga,
            this.MontoAsignadoDolaresCarga,
            this.MontoDolaresCarga,
            this.Full,
            this.clmCarga,
            this.clmDescarga,
            this.clmPapel});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(968, 332);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellDoubleClick);
            this.dgvCargas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCargas_RowsAdded);
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.btnAlarmasPapel);
            this.gbFiltro.Controls.Add(this.btnActualizarEspecial);
            this.gbFiltro.Controls.Add(this.lblTransportadora);
            this.gbFiltro.Controls.Add(this.cboTransportadora);
            this.gbFiltro.Controls.Add(this.chkRuta);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.nudRuta);
            this.gbFiltro.Controls.Add(this.cboATM);
            this.gbFiltro.Controls.Add(this.lblATM);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.cboCajero);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Controls.Add(this.lblCajero);
            this.gbFiltro.Location = new System.Drawing.Point(12, 66);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(980, 99);
            this.gbFiltro.TabIndex = 1;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Cargas";
            // 
            // btnActualizarEspecial
            // 
            this.btnActualizarEspecial.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizarEspecial.Enabled = false;
            this.btnActualizarEspecial.FlatAppearance.BorderSize = 2;
            this.btnActualizarEspecial.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizarEspecial.Location = new System.Drawing.Point(507, 50);
            this.btnActualizarEspecial.Name = "btnActualizarEspecial";
            this.btnActualizarEspecial.Size = new System.Drawing.Size(93, 40);
            this.btnActualizarEspecial.TabIndex = 12;
            this.btnActualizarEspecial.Text = "Actualizar";
            this.btnActualizarEspecial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarEspecial.UseVisualStyleBackColor = false;
            this.btnActualizarEspecial.Click += new System.EventHandler(this.btnActualizarEspecial_Click);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(504, 23);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 11;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.Enabled = false;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(592, 19);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(251, 21);
            this.cboTransportadora.TabIndex = 10;
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
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(315, 53);
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
            // cboATM
            // 
            this.cboATM.Busqueda = true;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(64, 19);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(245, 21);
            this.cboATM.TabIndex = 1;
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
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(64, 46);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = true;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(64, 72);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(245, 21);
            this.cboCajero.TabIndex = 7;
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
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(18, 76);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 6;
            this.lblCajero.Text = "Cajero:";
            // 
            // pnlOpcionesCoordinacion
            // 
            this.pnlOpcionesCoordinacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnOrdenRutas);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnCartuchos);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnEliminar);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnMontos);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnModificar);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnAsignarRuta);
            this.pnlOpcionesCoordinacion.Location = new System.Drawing.Point(76, 534);
            this.pnlOpcionesCoordinacion.Name = "pnlOpcionesCoordinacion";
            this.pnlOpcionesCoordinacion.Size = new System.Drawing.Size(603, 40);
            this.pnlOpcionesCoordinacion.TabIndex = 3;
            // 
            // btnOrdenRutas
            // 
            this.btnOrdenRutas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOrdenRutas.FlatAppearance.BorderSize = 2;
            this.btnOrdenRutas.Image = global::GUILayer.Properties.Resources.ordenar_ruta;
            this.btnOrdenRutas.Location = new System.Drawing.Point(510, 0);
            this.btnOrdenRutas.Name = "btnOrdenRutas";
            this.btnOrdenRutas.Size = new System.Drawing.Size(90, 40);
            this.btnOrdenRutas.TabIndex = 5;
            this.btnOrdenRutas.Text = "Ordenar";
            this.btnOrdenRutas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrdenRutas.UseVisualStyleBackColor = false;
            this.btnOrdenRutas.Click += new System.EventHandler(this.btnOrdenRutas_Click);
            // 
            // btnCartuchos
            // 
            this.btnCartuchos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCartuchos.Enabled = false;
            this.btnCartuchos.FlatAppearance.BorderSize = 2;
            this.btnCartuchos.Image = global::GUILayer.Properties.Resources.cartucho;
            this.btnCartuchos.Location = new System.Drawing.Point(313, 0);
            this.btnCartuchos.Name = "btnCartuchos";
            this.btnCartuchos.Size = new System.Drawing.Size(95, 40);
            this.btnCartuchos.TabIndex = 3;
            this.btnCartuchos.Text = "Cartuchos";
            this.btnCartuchos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCartuchos.UseVisualStyleBackColor = false;
            this.btnCartuchos.Click += new System.EventHandler(this.btnCartuchos_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(14, 0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMontos
            // 
            this.btnMontos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMontos.Enabled = false;
            this.btnMontos.FlatAppearance.BorderSize = 2;
            this.btnMontos.Image = global::GUILayer.Properties.Resources.montos;
            this.btnMontos.Location = new System.Drawing.Point(414, 0);
            this.btnMontos.Name = "btnMontos";
            this.btnMontos.Size = new System.Drawing.Size(90, 40);
            this.btnMontos.TabIndex = 4;
            this.btnMontos.Text = "Montos";
            this.btnMontos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMontos.UseVisualStyleBackColor = false;
            this.btnMontos.Click += new System.EventHandler(this.btnMontos_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
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
            // btnAsignarRuta
            // 
            this.btnAsignarRuta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAsignarRuta.FlatAppearance.BorderSize = 2;
            this.btnAsignarRuta.Image = global::GUILayer.Properties.Resources.rutas;
            this.btnAsignarRuta.Location = new System.Drawing.Point(207, 0);
            this.btnAsignarRuta.Name = "btnAsignarRuta";
            this.btnAsignarRuta.Size = new System.Drawing.Size(100, 40);
            this.btnAsignarRuta.TabIndex = 2;
            this.btnAsignarRuta.Text = "Asig. Ruta";
            this.btnAsignarRuta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignarRuta.UseVisualStyleBackColor = false;
            this.btnAsignarRuta.Click += new System.EventHandler(this.btnAsignarRuta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(896, 534);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatAppearance.BorderSize = 2;
            this.btnImprimir.Image = global::GUILayer.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(800, 534);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 40);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(704, 534);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(90, 40);
            this.btnRevisar.TabIndex = 4;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // btnAlarmasPapel
            // 
            this.btnAlarmasPapel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAlarmasPapel.FlatAppearance.BorderSize = 2;
            this.btnAlarmasPapel.Image = global::GUILayer.Properties.Resources.cambio_manifiesto;
            this.btnAlarmasPapel.Location = new System.Drawing.Point(869, 48);
            this.btnAlarmasPapel.Name = "btnAlarmasPapel";
            this.btnAlarmasPapel.Size = new System.Drawing.Size(93, 40);
            this.btnAlarmasPapel.TabIndex = 13;
            this.btnAlarmasPapel.Text = "Actualizar Papel";
            this.btnAlarmasPapel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlarmasPapel.UseVisualStyleBackColor = false;
            this.btnAlarmasPapel.Click += new System.EventHandler(this.btnAlarmasPapel_Click);
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
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Ruta
            // 
            this.Ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ruta.DataPropertyName = "Ruta";
            this.Ruta.HeaderText = "Ruta";
            this.Ruta.Name = "Ruta";
            this.Ruta.ReadOnly = true;
            this.Ruta.Width = 54;
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
            dataGridViewCellStyle9.Format = "N2";
            this.MontoAsignadoColonesCarga.DefaultCellStyle = dataGridViewCellStyle9;
            this.MontoAsignadoColonesCarga.HeaderText = "A. en Colones";
            this.MontoAsignadoColonesCarga.Name = "MontoAsignadoColonesCarga";
            this.MontoAsignadoColonesCarga.ReadOnly = true;
            this.MontoAsignadoColonesCarga.Width = 97;
            // 
            // MontoColonesCarga
            // 
            this.MontoColonesCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColonesCarga.DataPropertyName = "Monto_carga_colones";
            dataGridViewCellStyle10.Format = "N2";
            this.MontoColonesCarga.DefaultCellStyle = dataGridViewCellStyle10;
            this.MontoColonesCarga.HeaderText = "M. en Colones";
            this.MontoColonesCarga.Name = "MontoColonesCarga";
            this.MontoColonesCarga.ReadOnly = true;
            this.MontoColonesCarga.Width = 99;
            // 
            // MontoAsignadoDolaresCarga
            // 
            this.MontoAsignadoDolaresCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoAsignadoDolaresCarga.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle11.Format = "N2";
            this.MontoAsignadoDolaresCarga.DefaultCellStyle = dataGridViewCellStyle11;
            this.MontoAsignadoDolaresCarga.HeaderText = "A. en Dólares";
            this.MontoAsignadoDolaresCarga.Name = "MontoAsignadoDolaresCarga";
            this.MontoAsignadoDolaresCarga.ReadOnly = true;
            this.MontoAsignadoDolaresCarga.Width = 95;
            // 
            // MontoDolaresCarga
            // 
            this.MontoDolaresCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolaresCarga.DataPropertyName = "Monto_carga_dolares";
            dataGridViewCellStyle12.Format = "N2";
            this.MontoDolaresCarga.DefaultCellStyle = dataGridViewCellStyle12;
            this.MontoDolaresCarga.HeaderText = "M. en Dólares";
            this.MontoDolaresCarga.Name = "MontoDolaresCarga";
            this.MontoDolaresCarga.ReadOnly = true;
            this.MontoDolaresCarga.Width = 97;
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
            // clmCarga
            // 
            this.clmCarga.HeaderText = "Carga";
            this.clmCarga.Name = "clmCarga";
            this.clmCarga.ReadOnly = true;
            // 
            // clmDescarga
            // 
            this.clmDescarga.HeaderText = "Descarga";
            this.clmDescarga.Name = "clmDescarga";
            this.clmDescarga.ReadOnly = true;
            // 
            // clmPapel
            // 
            this.clmPapel.HeaderText = "Papel";
            this.clmPapel.Name = "clmPapel";
            this.clmPapel.ReadOnly = true;
            // 
            // frmListaCargas
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1004, 586);
            this.Controls.Add(this.pnlOpcionesCoordinacion);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.btnRevisar);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(920, 620);
            this.Name = "frmListaCargas";
            this.ShowInTaskbar = false;
            this.Text = "Lista de Cargas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).EndInit();
            this.pnlOpcionesCoordinacion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbFiltro;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAsignarRuta;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.CheckBox chkRuta;
        private System.Windows.Forms.NumericUpDown nudRuta;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnMontos;
        private System.Windows.Forms.Button btnCartuchos;
        private System.Windows.Forms.Panel pnlOpcionesCoordinacion;
        private System.Windows.Forms.Button btnOrdenRutas;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.Button btnActualizarEspecial;
        private System.Windows.Forms.Button btnAlarmasPapel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATMCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoDolaresCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresCarga;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Full;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCarga;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmDescarga;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmPapel;
    }
}