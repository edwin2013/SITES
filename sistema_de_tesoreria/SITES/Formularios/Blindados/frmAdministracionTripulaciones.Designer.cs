namespace GUILayer
{
    partial class frmAdministracionTripulaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionTripulaciones));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbEmpresas = new System.Windows.Forms.GroupBox();
            this.dgvTripulaciones = new System.Windows.Forms.DataGridView();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.grpIngresarDatos = new System.Windows.Forms.GroupBox();
            this.cboDispositivo = new GUILayer.ComboBoxBusqueda();
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.cboVehiculo = new GUILayer.ComboBoxBusqueda();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblRuta = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnAgregarSucursal = new System.Windows.Forms.Button();
            this.cboPortavalor = new GUILayer.ComboBoxBusqueda();
            this.lblPortavalor = new System.Windows.Forms.Label();
            this.cboCustodio = new GUILayer.ComboBoxBusqueda();
            this.lblCustodio = new System.Windows.Forms.Label();
            this.cboChofer = new GUILayer.ComboBoxBusqueda();
            this.lblChofer = new System.Windows.Forms.Label();
            this.numRuta2 = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnQuitarTripulacion = new System.Windows.Forms.Button();
            this.btnArriba = new System.Windows.Forms.Button();
            this.btnAbajo = new System.Windows.Forms.Button();
            this.btnEliminarTodos = new System.Windows.Forms.Button();
            this.btnReinicioValores = new System.Windows.Forms.Button();
            this.Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Invalido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID_Valido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Custodio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbEmpresas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripulaciones)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbFiltro.SuspendLayout();
            this.grpIngresarDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRuta2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(881, 515);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // gbEmpresas
            // 
            this.gbEmpresas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEmpresas.Controls.Add(this.dgvTripulaciones);
            this.gbEmpresas.Location = new System.Drawing.Point(12, 288);
            this.gbEmpresas.Name = "gbEmpresas";
            this.gbEmpresas.Size = new System.Drawing.Size(872, 221);
            this.gbEmpresas.TabIndex = 16;
            this.gbEmpresas.TabStop = false;
            this.gbEmpresas.Text = "Lista de Tripulaciones";
            // 
            // dgvTripulaciones
            // 
            this.dgvTripulaciones.AllowUserToAddRows = false;
            this.dgvTripulaciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvTripulaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTripulaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTripulaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTripulaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTripulaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTripulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTripulaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Placa,
            this.ID_Invalido,
            this.ID_Valido,
            this.ID,
            this.DB_ID,
            this.Descripcion,
            this.Chofer,
            this.Custodio,
            this.PortaValor,
            this.ColumnUsuario,
            this.ColumnObservaciones});
            this.dgvTripulaciones.EnableHeadersVisualStyles = false;
            this.dgvTripulaciones.Location = new System.Drawing.Point(12, 19);
            this.dgvTripulaciones.MultiSelect = false;
            this.dgvTripulaciones.Name = "dgvTripulaciones";
            this.dgvTripulaciones.ReadOnly = true;
            this.dgvTripulaciones.RowHeadersVisible = false;
            this.dgvTripulaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTripulaciones.Size = new System.Drawing.Size(845, 196);
            this.dgvTripulaciones.StandardTab = true;
            this.dgvTripulaciones.TabIndex = 0;
            this.dgvTripulaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTripulaciones_CellClick);
            this.dgvTripulaciones.SelectionChanged += new System.EventHandler(this.dgvTripulaciones_SelectionChanged);
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-2, 1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(988, 60);
            this.pnlFondo.TabIndex = 14;
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(618, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.btnAsignar);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Controls.Add(this.txtBuscar);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblBuscar);
            this.gbFiltro.Location = new System.Drawing.Point(20, 67);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(945, 65);
            this.gbFiltro.TabIndex = 15;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Tripulaciones";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignar.FlatAppearance.BorderSize = 2;
            this.btnAsignar.Image = global::GUILayer.Properties.Resources.asignacion;
            this.btnAsignar.Location = new System.Drawing.Point(813, 15);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(95, 40);
            this.btnAsignar.TabIndex = 8;
            this.btnAsignar.Text = "Auto Asignar";
            this.btnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(451, 32);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(40, 13);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(55, 30);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(365, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(497, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 7;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(6, 33);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // grpIngresarDatos
            // 
            this.grpIngresarDatos.Controls.Add(this.cboDispositivo);
            this.grpIngresarDatos.Controls.Add(this.lblDispositivo);
            this.grpIngresarDatos.Controls.Add(this.cboVehiculo);
            this.grpIngresarDatos.Controls.Add(this.label1);
            this.grpIngresarDatos.Controls.Add(this.btnModificar);
            this.grpIngresarDatos.Controls.Add(this.lblRuta);
            this.grpIngresarDatos.Controls.Add(this.btnAgregarSucursal);
            this.grpIngresarDatos.Controls.Add(this.cboPortavalor);
            this.grpIngresarDatos.Controls.Add(this.lblPortavalor);
            this.grpIngresarDatos.Controls.Add(this.cboCustodio);
            this.grpIngresarDatos.Controls.Add(this.lblCustodio);
            this.grpIngresarDatos.Controls.Add(this.cboChofer);
            this.grpIngresarDatos.Controls.Add(this.lblChofer);
            this.grpIngresarDatos.Controls.Add(this.numRuta2);
            this.grpIngresarDatos.Location = new System.Drawing.Point(20, 138);
            this.grpIngresarDatos.Name = "grpIngresarDatos";
            this.grpIngresarDatos.Size = new System.Drawing.Size(945, 144);
            this.grpIngresarDatos.TabIndex = 21;
            this.grpIngresarDatos.TabStop = false;
            this.grpIngresarDatos.Text = "Ingresar Datos";
            // 
            // cboDispositivo
            // 
            this.cboDispositivo.Busqueda = false;
            this.cboDispositivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDispositivo.ListaMostrada = null;
            this.cboDispositivo.Location = new System.Drawing.Point(81, 80);
            this.cboDispositivo.Name = "cboDispositivo";
            this.cboDispositivo.Size = new System.Drawing.Size(364, 21);
            this.cboDispositivo.TabIndex = 24;
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.AutoSize = true;
            this.lblDispositivo.Location = new System.Drawing.Point(22, 83);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(61, 13);
            this.lblDispositivo.TabIndex = 23;
            this.lblDispositivo.Text = "Dispositivo:";
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.Busqueda = false;
            this.cboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehiculo.ListaMostrada = null;
            this.cboVehiculo.Location = new System.Drawing.Point(525, 114);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(225, 21);
            this.cboVehiculo.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Vehículo:";
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(813, 59);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(20, 30);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(33, 13);
            this.lblRuta.TabIndex = 19;
            this.lblRuta.Text = "Ruta:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(291, 526);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(365, 20);
            this.txtNombre.TabIndex = 18;
            this.txtNombre.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(242, 529);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(47, 13);
            this.lblDescripcion.TabIndex = 17;
            this.lblDescripcion.Text = "Nombre:";
            this.lblDescripcion.Visible = false;
            // 
            // btnAgregarSucursal
            // 
            this.btnAgregarSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarSucursal.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarSucursal.Location = new System.Drawing.Point(813, 13);
            this.btnAgregarSucursal.Name = "btnAgregarSucursal";
            this.btnAgregarSucursal.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarSucursal.TabIndex = 16;
            this.btnAgregarSucursal.Text = "Agregar";
            this.btnAgregarSucursal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarSucursal.UseVisualStyleBackColor = false;
            this.btnAgregarSucursal.Click += new System.EventHandler(this.btnAgregarTripulacion_Click);
            // 
            // cboPortavalor
            // 
            this.cboPortavalor.Busqueda = false;
            this.cboPortavalor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortavalor.ListaMostrada = null;
            this.cboPortavalor.Location = new System.Drawing.Point(525, 77);
            this.cboPortavalor.Name = "cboPortavalor";
            this.cboPortavalor.Size = new System.Drawing.Size(225, 21);
            this.cboPortavalor.TabIndex = 15;
            // 
            // lblPortavalor
            // 
            this.lblPortavalor.AutoSize = true;
            this.lblPortavalor.Location = new System.Drawing.Point(461, 80);
            this.lblPortavalor.Name = "lblPortavalor";
            this.lblPortavalor.Size = new System.Drawing.Size(58, 13);
            this.lblPortavalor.TabIndex = 14;
            this.lblPortavalor.Text = "Portavalor:";
            // 
            // cboCustodio
            // 
            this.cboCustodio.Busqueda = false;
            this.cboCustodio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustodio.ListaMostrada = null;
            this.cboCustodio.Location = new System.Drawing.Point(525, 37);
            this.cboCustodio.Name = "cboCustodio";
            this.cboCustodio.Size = new System.Drawing.Size(225, 21);
            this.cboCustodio.TabIndex = 13;
            // 
            // lblCustodio
            // 
            this.lblCustodio.AutoSize = true;
            this.lblCustodio.Location = new System.Drawing.Point(478, 40);
            this.lblCustodio.Name = "lblCustodio";
            this.lblCustodio.Size = new System.Drawing.Size(51, 13);
            this.lblCustodio.TabIndex = 12;
            this.lblCustodio.Text = "Custodio:";
            // 
            // cboChofer
            // 
            this.cboChofer.Busqueda = false;
            this.cboChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChofer.ListaMostrada = null;
            this.cboChofer.Location = new System.Drawing.Point(220, 32);
            this.cboChofer.Name = "cboChofer";
            this.cboChofer.Size = new System.Drawing.Size(225, 21);
            this.cboChofer.TabIndex = 11;
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(173, 35);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(41, 13);
            this.lblChofer.TabIndex = 10;
            this.lblChofer.Text = "Chofer:";
            // 
            // numRuta2
            // 
            this.numRuta2.Location = new System.Drawing.Point(69, 28);
            this.numRuta2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRuta2.Name = "numRuta2";
            this.numRuta2.Size = new System.Drawing.Size(77, 20);
            this.numRuta2.TabIndex = 9;
            this.numRuta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRuta2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(689, 515);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnQuitarTripulacion
            // 
            this.btnQuitarTripulacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarTripulacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitarTripulacion.Enabled = false;
            this.btnQuitarTripulacion.FlatAppearance.BorderSize = 2;
            this.btnQuitarTripulacion.Image = global::GUILayer.Properties.Resources.eliminar1;
            this.btnQuitarTripulacion.Location = new System.Drawing.Point(785, 515);
            this.btnQuitarTripulacion.Name = "btnQuitarTripulacion";
            this.btnQuitarTripulacion.Size = new System.Drawing.Size(90, 40);
            this.btnQuitarTripulacion.TabIndex = 25;
            this.btnQuitarTripulacion.Text = "Quitar";
            this.btnQuitarTripulacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarTripulacion.UseVisualStyleBackColor = false;
            this.btnQuitarTripulacion.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnArriba
            // 
            this.btnArriba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArriba.Enabled = false;
            this.btnArriba.Image = global::GUILayer.Properties.Resources.arriba;
            this.btnArriba.Location = new System.Drawing.Point(906, 307);
            this.btnArriba.Name = "btnArriba";
            this.btnArriba.Size = new System.Drawing.Size(40, 90);
            this.btnArriba.TabIndex = 26;
            this.btnArriba.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArriba.UseVisualStyleBackColor = true;
            this.btnArriba.Click += new System.EventHandler(this.btnArriba_Click);
            // 
            // btnAbajo
            // 
            this.btnAbajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbajo.Enabled = false;
            this.btnAbajo.Image = global::GUILayer.Properties.Resources.abajo;
            this.btnAbajo.Location = new System.Drawing.Point(906, 403);
            this.btnAbajo.Name = "btnAbajo";
            this.btnAbajo.Size = new System.Drawing.Size(40, 90);
            this.btnAbajo.TabIndex = 27;
            this.btnAbajo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbajo.UseVisualStyleBackColor = true;
            this.btnAbajo.Click += new System.EventHandler(this.btnAbajo_Click);
            // 
            // btnEliminarTodos
            // 
            this.btnEliminarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarTodos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminarTodos.Enabled = false;
            this.btnEliminarTodos.FlatAppearance.BorderSize = 2;
            this.btnEliminarTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarTodos.Image")));
            this.btnEliminarTodos.Location = new System.Drawing.Point(20, 515);
            this.btnEliminarTodos.Name = "btnEliminarTodos";
            this.btnEliminarTodos.Size = new System.Drawing.Size(90, 40);
            this.btnEliminarTodos.TabIndex = 28;
            this.btnEliminarTodos.Text = "Elminar Todo";
            this.btnEliminarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarTodos.UseVisualStyleBackColor = false;
            this.btnEliminarTodos.Click += new System.EventHandler(this.btnEliminarTodos_Click);
            // 
            // btnReinicioValores
            // 
            this.btnReinicioValores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReinicioValores.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReinicioValores.Enabled = false;
            this.btnReinicioValores.FlatAppearance.BorderSize = 2;
            this.btnReinicioValores.Image = global::GUILayer.Properties.Resources.reiniciar;
            this.btnReinicioValores.Location = new System.Drawing.Point(116, 515);
            this.btnReinicioValores.Name = "btnReinicioValores";
            this.btnReinicioValores.Size = new System.Drawing.Size(98, 40);
            this.btnReinicioValores.TabIndex = 29;
            this.btnReinicioValores.Text = "Reiniciar Datos HH";
            this.btnReinicioValores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReinicioValores.UseVisualStyleBackColor = false;
            this.btnReinicioValores.Click += new System.EventHandler(this.btnReinicioValores_Click);
            // 
            // Placa
            // 
            this.Placa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Placa.DataPropertyName = "Ruta";
            this.Placa.HeaderText = "Ruta";
            this.Placa.Name = "Placa";
            this.Placa.ReadOnly = true;
            this.Placa.Width = 54;
            // 
            // ID_Invalido
            // 
            this.ID_Invalido.DataPropertyName = "ID_Invalido";
            this.ID_Invalido.HeaderText = "ID_Invalido";
            this.ID_Invalido.Name = "ID_Invalido";
            this.ID_Invalido.ReadOnly = true;
            this.ID_Invalido.Visible = false;
            this.ID_Invalido.Width = 66;
            // 
            // ID_Valido
            // 
            this.ID_Valido.DataPropertyName = "ID_Valido";
            this.ID_Valido.HeaderText = "ID_Valido";
            this.ID_Valido.Name = "ID_Valido";
            this.ID_Valido.ReadOnly = true;
            this.ID_Valido.Visible = false;
            this.ID_Valido.Width = 58;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // DB_ID
            // 
            this.DB_ID.DataPropertyName = "DB_ID";
            this.DB_ID.HeaderText = "DB_ID";
            this.DB_ID.Name = "DB_ID";
            this.DB_ID.ReadOnly = true;
            this.DB_ID.Visible = false;
            this.DB_ID.Width = 63;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Visible = false;
            this.Descripcion.Width = 87;
            // 
            // Chofer
            // 
            this.Chofer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Chofer.DataPropertyName = "Chofer";
            this.Chofer.HeaderText = "Chofer";
            this.Chofer.MinimumWidth = 120;
            this.Chofer.Name = "Chofer";
            this.Chofer.ReadOnly = true;
            this.Chofer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chofer.Width = 120;
            // 
            // Custodio
            // 
            this.Custodio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Custodio.DataPropertyName = "Custodio";
            this.Custodio.HeaderText = "Custodio";
            this.Custodio.Name = "Custodio";
            this.Custodio.ReadOnly = true;
            this.Custodio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Custodio.Width = 72;
            // 
            // PortaValor
            // 
            this.PortaValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PortaValor.DataPropertyName = "Portavalor";
            this.PortaValor.HeaderText = "PortaValor";
            this.PortaValor.Name = "PortaValor";
            this.PortaValor.ReadOnly = true;
            this.PortaValor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PortaValor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PortaValor.Width = 61;
            // 
            // ColumnUsuario
            // 
            this.ColumnUsuario.DataPropertyName = "Usuario";
            this.ColumnUsuario.HeaderText = "Registrado por:";
            this.ColumnUsuario.Name = "ColumnUsuario";
            this.ColumnUsuario.ReadOnly = true;
            this.ColumnUsuario.Visible = false;
            this.ColumnUsuario.Width = 103;
            // 
            // ColumnObservaciones
            // 
            this.ColumnObservaciones.DataPropertyName = "Observaciones";
            this.ColumnObservaciones.HeaderText = "Observaciones";
            this.ColumnObservaciones.Name = "ColumnObservaciones";
            this.ColumnObservaciones.ReadOnly = true;
            this.ColumnObservaciones.Visible = false;
            this.ColumnObservaciones.Width = 102;
            // 
            // frmAdministracionTripulaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 567);
            this.Controls.Add(this.btnReinicioValores);
            this.Controls.Add(this.btnEliminarTodos);
            this.Controls.Add(this.btnArriba);
            this.Controls.Add(this.btnAbajo);
            this.Controls.Add(this.btnQuitarTripulacion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.grpIngresarDatos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbEmpresas);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionTripulaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Tripulaciones";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbEmpresas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripulaciones)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.grpIngresarDatos.ResumeLayout(false);
            this.grpIngresarDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRuta2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbEmpresas;
        private System.Windows.Forms.DataGridView dgvTripulaciones;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.GroupBox grpIngresarDatos;
        private System.Windows.Forms.NumericUpDown numRuta2;
        private ComboBoxBusqueda cboPortavalor;
        private System.Windows.Forms.Label lblPortavalor;
        private ComboBoxBusqueda cboCustodio;
        private System.Windows.Forms.Label lblCustodio;
        private ComboBoxBusqueda cboChofer;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.Button btnAgregarSucursal;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnQuitarTripulacion;
        private System.Windows.Forms.Button btnAsignar;
        private ComboBoxBusqueda cboVehiculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnArriba;
        private System.Windows.Forms.Button btnAbajo;
        private ComboBoxBusqueda cboDispositivo;
        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.Button btnEliminarTodos;
        private System.Windows.Forms.Button btnReinicioValores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ID_Invalido;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ID_Valido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Custodio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnObservaciones;
    }
}