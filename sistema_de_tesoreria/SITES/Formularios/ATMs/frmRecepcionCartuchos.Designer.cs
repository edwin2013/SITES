namespace GUILayer.Formularios.ATMs
{
    partial class frmRecepcionCartuchos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionCartuchos));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.tcRecepcionEntrega = new System.Windows.Forms.TabControl();
            this.tpEntregaTaller = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnActualizarTesoreria = new System.Windows.Forms.Button();
            this.cboCartuchoMalo = new GUILayer.ComboBoxBusqueda();
            this.cbTodosEntTaller = new System.Windows.Forms.CheckBox();
            this.btnExportarMalosTesoreria = new System.Windows.Forms.Button();
            this.dgvEntregar = new System.Windows.Forms.DataGridView();
            this.clSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTipoFalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpRecibirTaller = new System.Windows.Forms.TabPage();
            this.btnEliminarRecibidos = new System.Windows.Forms.Button();
            this.gbRecibir = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCartucho = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizarTaller = new System.Windows.Forms.Button();
            this.cbTodosRecibir = new System.Windows.Forms.CheckBox();
            this.btnExportarMalosTaller = new System.Windows.Forms.Button();
            this.dgvRecibir = new System.Windows.Forms.DataGridView();
            this.clcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTipoMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProveedorMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFallaMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFechaMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsuarioMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboMalosTaller = new GUILayer.ComboBoxBusqueda();
            this.tpNoRecuperables = new System.Windows.Forms.TabPage();
            this.lblCartucho = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cbTodosRecuperables = new System.Windows.Forms.CheckBox();
            this.btnExportarNoRecuperables = new System.Windows.Forms.Button();
            this.dgvNoRecuperable = new System.Windows.Forms.DataGridView();
            this.clchecNR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clCartucho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTipoNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTransportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFechaNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsuarioNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboCartucho = new GUILayer.ComboBoxBusqueda();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.tcRecepcionEntrega.SuspendLayout();
            this.tpEntregaTaller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregar)).BeginInit();
            this.tpRecibirTaller.SuspendLayout();
            this.gbRecibir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibir)).BeginInit();
            this.tpNoRecuperables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoRecuperable)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo1;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(779, 60);
            this.pnlFondo.TabIndex = 1;
            // 
            // tcRecepcionEntrega
            // 
            this.tcRecepcionEntrega.Controls.Add(this.tpEntregaTaller);
            this.tcRecepcionEntrega.Controls.Add(this.tpRecibirTaller);
            this.tcRecepcionEntrega.Controls.Add(this.tpNoRecuperables);
            this.tcRecepcionEntrega.HotTrack = true;
            this.tcRecepcionEntrega.Location = new System.Drawing.Point(12, 91);
            this.tcRecepcionEntrega.Multiline = true;
            this.tcRecepcionEntrega.Name = "tcRecepcionEntrega";
            this.tcRecepcionEntrega.SelectedIndex = 0;
            this.tcRecepcionEntrega.Size = new System.Drawing.Size(755, 419);
            this.tcRecepcionEntrega.TabIndex = 2;
            // 
            // tpEntregaTaller
            // 
            this.tpEntregaTaller.Controls.Add(this.label2);
            this.tpEntregaTaller.Controls.Add(this.btnActualizarTesoreria);
            this.tpEntregaTaller.Controls.Add(this.cboCartuchoMalo);
            this.tpEntregaTaller.Controls.Add(this.cbTodosEntTaller);
            this.tpEntregaTaller.Controls.Add(this.btnExportarMalosTesoreria);
            this.tpEntregaTaller.Controls.Add(this.dgvEntregar);
            this.tpEntregaTaller.Location = new System.Drawing.Point(4, 22);
            this.tpEntregaTaller.Name = "tpEntregaTaller";
            this.tpEntregaTaller.Padding = new System.Windows.Forms.Padding(3);
            this.tpEntregaTaller.Size = new System.Drawing.Size(747, 393);
            this.tpEntregaTaller.TabIndex = 20;
            this.tpEntregaTaller.Text = "Por Entregar a Taller";
            this.tpEntregaTaller.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Cartucho:";
            // 
            // btnActualizarTesoreria
            // 
            this.btnActualizarTesoreria.FlatAppearance.BorderSize = 2;
            this.btnActualizarTesoreria.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizarTesoreria.Location = new System.Drawing.Point(324, 6);
            this.btnActualizarTesoreria.Name = "btnActualizarTesoreria";
            this.btnActualizarTesoreria.Size = new System.Drawing.Size(93, 40);
            this.btnActualizarTesoreria.TabIndex = 54;
            this.btnActualizarTesoreria.Text = "Actualizar";
            this.btnActualizarTesoreria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarTesoreria.UseVisualStyleBackColor = false;
            this.btnActualizarTesoreria.Click += new System.EventHandler(this.btnActualizarTesoreria_Click);
            // 
            // cboCartuchoMalo
            // 
            this.cboCartuchoMalo.Busqueda = false;
            this.cboCartuchoMalo.ListaMostrada = null;
            this.cboCartuchoMalo.Location = new System.Drawing.Point(70, 15);
            this.cboCartuchoMalo.Name = "cboCartuchoMalo";
            this.cboCartuchoMalo.Size = new System.Drawing.Size(200, 21);
            this.cboCartuchoMalo.TabIndex = 53;
            // 
            // cbTodosEntTaller
            // 
            this.cbTodosEntTaller.AutoSize = true;
            this.cbTodosEntTaller.Location = new System.Drawing.Point(476, 20);
            this.cbTodosEntTaller.Name = "cbTodosEntTaller";
            this.cbTodosEntTaller.Size = new System.Drawing.Size(92, 17);
            this.cbTodosEntTaller.TabIndex = 56;
            this.cbTodosEntTaller.Text = "Marcar Todos";
            this.cbTodosEntTaller.UseVisualStyleBackColor = true;
            this.cbTodosEntTaller.CheckedChanged += new System.EventHandler(this.cbTodosEntTaller_CheckedChanged);
            // 
            // btnExportarMalosTesoreria
            // 
            this.btnExportarMalosTesoreria.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarMalosTesoreria.FlatAppearance.BorderSize = 2;
            this.btnExportarMalosTesoreria.Image = global::GUILayer.Properties.Resources.excel;
            this.btnExportarMalosTesoreria.Location = new System.Drawing.Point(642, 347);
            this.btnExportarMalosTesoreria.Name = "btnExportarMalosTesoreria";
            this.btnExportarMalosTesoreria.Size = new System.Drawing.Size(90, 40);
            this.btnExportarMalosTesoreria.TabIndex = 55;
            this.btnExportarMalosTesoreria.Text = "Exportar";
            this.btnExportarMalosTesoreria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarMalosTesoreria.UseVisualStyleBackColor = false;
            this.btnExportarMalosTesoreria.Click += new System.EventHandler(this.btnExportarMalosTesoreria_Click);
            // 
            // dgvEntregar
            // 
            this.dgvEntregar.AllowUserToAddRows = false;
            this.dgvEntregar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvEntregar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEntregar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntregar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEntregar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEntregar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEntregar.ColumnHeadersHeight = 17;
            this.dgvEntregar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSeleccionar,
            this.dataGridViewTextBoxColumn4,
            this.clTipo,
            this.clProveedor,
            this.clTipoFalla,
            this.clFecha,
            this.clUsuario});
            this.dgvEntregar.EnableHeadersVisualStyles = false;
            this.dgvEntregar.Location = new System.Drawing.Point(6, 59);
            this.dgvEntregar.Name = "dgvEntregar";
            this.dgvEntregar.RowHeadersVisible = false;
            this.dgvEntregar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntregar.Size = new System.Drawing.Size(735, 282);
            this.dgvEntregar.StandardTab = true;
            this.dgvEntregar.TabIndex = 1;
            // 
            // clSeleccionar
            // 
            this.clSeleccionar.HeaderText = "";
            this.clSeleccionar.Name = "clSeleccionar";
            this.clSeleccionar.Width = 5;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NombreCart";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cartucho";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 74;
            // 
            // clTipo
            // 
            this.clTipo.DataPropertyName = "Tipo";
            this.clTipo.HeaderText = "Tipo";
            this.clTipo.Name = "clTipo";
            this.clTipo.ReadOnly = true;
            this.clTipo.Width = 52;
            // 
            // clProveedor
            // 
            this.clProveedor.DataPropertyName = "empresa";
            this.clProveedor.HeaderText = "Proveedor";
            this.clProveedor.Name = "clProveedor";
            this.clProveedor.ReadOnly = true;
            this.clProveedor.Width = 80;
            // 
            // clTipoFalla
            // 
            this.clTipoFalla.DataPropertyName = "NombreFalla";
            this.clTipoFalla.HeaderText = "Falla Registrada";
            this.clTipoFalla.Name = "clTipoFalla";
            this.clTipoFalla.ReadOnly = true;
            this.clTipoFalla.Width = 107;
            // 
            // clFecha
            // 
            this.clFecha.DataPropertyName = "Fecha";
            this.clFecha.HeaderText = "Fecha de Registro";
            this.clFecha.Name = "clFecha";
            this.clFecha.ReadOnly = true;
            this.clFecha.Width = 118;
            // 
            // clUsuario
            // 
            this.clUsuario.DataPropertyName = "Usuario";
            this.clUsuario.HeaderText = "Usuario que Registra";
            this.clUsuario.Name = "clUsuario";
            this.clUsuario.ReadOnly = true;
            this.clUsuario.Width = 130;
            // 
            // tpRecibirTaller
            // 
            this.tpRecibirTaller.Controls.Add(this.btnEliminarRecibidos);
            this.tpRecibirTaller.Controls.Add(this.gbRecibir);
            this.tpRecibirTaller.Controls.Add(this.label1);
            this.tpRecibirTaller.Controls.Add(this.btnActualizarTaller);
            this.tpRecibirTaller.Controls.Add(this.cbTodosRecibir);
            this.tpRecibirTaller.Controls.Add(this.btnExportarMalosTaller);
            this.tpRecibirTaller.Controls.Add(this.dgvRecibir);
            this.tpRecibirTaller.Controls.Add(this.cboMalosTaller);
            this.tpRecibirTaller.Location = new System.Drawing.Point(4, 22);
            this.tpRecibirTaller.Name = "tpRecibirTaller";
            this.tpRecibirTaller.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecibirTaller.Size = new System.Drawing.Size(747, 393);
            this.tpRecibirTaller.TabIndex = 21;
            this.tpRecibirTaller.Text = "Por Recibir de Taller";
            this.tpRecibirTaller.UseVisualStyleBackColor = true;
            // 
            // btnEliminarRecibidos
            // 
            this.btnEliminarRecibidos.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarRecibidos.FlatAppearance.BorderSize = 2;
            this.btnEliminarRecibidos.Image = global::GUILayer.Properties.Resources.actualizar1;
            this.btnEliminarRecibidos.Location = new System.Drawing.Point(499, 347);
            this.btnEliminarRecibidos.Name = "btnEliminarRecibidos";
            this.btnEliminarRecibidos.Size = new System.Drawing.Size(116, 40);
            this.btnEliminarRecibidos.TabIndex = 53;
            this.btnEliminarRecibidos.Text = "Eliminar Recibidos";
            this.btnEliminarRecibidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarRecibidos.UseVisualStyleBackColor = false;
            this.btnEliminarRecibidos.Click += new System.EventHandler(this.btnEliminarRecibidos_Click);
            // 
            // gbRecibir
            // 
            this.gbRecibir.Controls.Add(this.label3);
            this.gbRecibir.Controls.Add(this.txtCartucho);
            this.gbRecibir.Location = new System.Drawing.Point(499, 6);
            this.gbRecibir.Name = "gbRecibir";
            this.gbRecibir.Size = new System.Drawing.Size(233, 53);
            this.gbRecibir.TabIndex = 52;
            this.gbRecibir.TabStop = false;
            this.gbRecibir.Text = "Recibir Cartucho";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Código:";
            // 
            // txtCartucho
            // 
            this.txtCartucho.Location = new System.Drawing.Point(55, 21);
            this.txtCartucho.Name = "txtCartucho";
            this.txtCartucho.Size = new System.Drawing.Size(162, 20);
            this.txtCartucho.TabIndex = 53;
            this.txtCartucho.Enter += new System.EventHandler(this.txtCartucho_Enter);
            this.txtCartucho.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCartucho_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Cartucho:";
            // 
            // btnActualizarTaller
            // 
            this.btnActualizarTaller.FlatAppearance.BorderSize = 2;
            this.btnActualizarTaller.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizarTaller.Location = new System.Drawing.Point(286, 5);
            this.btnActualizarTaller.Name = "btnActualizarTaller";
            this.btnActualizarTaller.Size = new System.Drawing.Size(93, 40);
            this.btnActualizarTaller.TabIndex = 49;
            this.btnActualizarTaller.Text = "Actualizar";
            this.btnActualizarTaller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarTaller.UseVisualStyleBackColor = false;
            this.btnActualizarTaller.Click += new System.EventHandler(this.btnActualizarTaller_Click);
            // 
            // cbTodosRecibir
            // 
            this.cbTodosRecibir.AutoSize = true;
            this.cbTodosRecibir.Location = new System.Drawing.Point(401, 20);
            this.cbTodosRecibir.Name = "cbTodosRecibir";
            this.cbTodosRecibir.Size = new System.Drawing.Size(92, 17);
            this.cbTodosRecibir.TabIndex = 51;
            this.cbTodosRecibir.Text = "Marcar Todos";
            this.cbTodosRecibir.UseVisualStyleBackColor = true;
            this.cbTodosRecibir.CheckedChanged += new System.EventHandler(this.cbTodosRecibir_CheckedChanged);
            // 
            // btnExportarMalosTaller
            // 
            this.btnExportarMalosTaller.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarMalosTaller.FlatAppearance.BorderSize = 2;
            this.btnExportarMalosTaller.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnExportarMalosTaller.Location = new System.Drawing.Point(628, 347);
            this.btnExportarMalosTaller.Name = "btnExportarMalosTaller";
            this.btnExportarMalosTaller.Size = new System.Drawing.Size(116, 40);
            this.btnExportarMalosTaller.TabIndex = 50;
            this.btnExportarMalosTaller.Text = "No Recuperable";
            this.btnExportarMalosTaller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarMalosTaller.UseVisualStyleBackColor = false;
            this.btnExportarMalosTaller.Click += new System.EventHandler(this.btnExportarMalosTaller_Click);
            // 
            // dgvRecibir
            // 
            this.dgvRecibir.AllowUserToAddRows = false;
            this.dgvRecibir.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRecibir.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecibir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecibir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRecibir.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRecibir.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRecibir.ColumnHeadersHeight = 17;
            this.dgvRecibir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clcheck,
            this.clCart,
            this.clTipoMT,
            this.clProveedorMT,
            this.clFallaMT,
            this.clFechaMT,
            this.clUsuarioMT,
            this.clDias});
            this.dgvRecibir.EnableHeadersVisualStyles = false;
            this.dgvRecibir.Location = new System.Drawing.Point(7, 65);
            this.dgvRecibir.Name = "dgvRecibir";
            this.dgvRecibir.RowHeadersVisible = false;
            this.dgvRecibir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecibir.Size = new System.Drawing.Size(735, 276);
            this.dgvRecibir.StandardTab = true;
            this.dgvRecibir.TabIndex = 1;
            // 
            // clcheck
            // 
            this.clcheck.HeaderText = "";
            this.clcheck.Name = "clcheck";
            this.clcheck.Width = 5;
            // 
            // clCart
            // 
            this.clCart.DataPropertyName = "NombreCart";
            this.clCart.HeaderText = "Cartucho";
            this.clCart.Name = "clCart";
            this.clCart.ReadOnly = true;
            this.clCart.Width = 74;
            // 
            // clTipoMT
            // 
            this.clTipoMT.DataPropertyName = "Tipo";
            this.clTipoMT.HeaderText = "Tipo";
            this.clTipoMT.Name = "clTipoMT";
            this.clTipoMT.ReadOnly = true;
            this.clTipoMT.Width = 52;
            // 
            // clProveedorMT
            // 
            this.clProveedorMT.DataPropertyName = "empresa";
            this.clProveedorMT.HeaderText = "Proveedor";
            this.clProveedorMT.Name = "clProveedorMT";
            this.clProveedorMT.ReadOnly = true;
            this.clProveedorMT.Width = 80;
            // 
            // clFallaMT
            // 
            this.clFallaMT.DataPropertyName = "NombreFalla";
            this.clFallaMT.HeaderText = "Falla Registrada";
            this.clFallaMT.Name = "clFallaMT";
            this.clFallaMT.ReadOnly = true;
            this.clFallaMT.Width = 107;
            // 
            // clFechaMT
            // 
            this.clFechaMT.DataPropertyName = "Fecha";
            this.clFechaMT.HeaderText = "Fecha de Registro";
            this.clFechaMT.Name = "clFechaMT";
            this.clFechaMT.ReadOnly = true;
            this.clFechaMT.Width = 118;
            // 
            // clUsuarioMT
            // 
            this.clUsuarioMT.DataPropertyName = "Usuario";
            this.clUsuarioMT.HeaderText = "Usuario que registra";
            this.clUsuarioMT.Name = "clUsuarioMT";
            this.clUsuarioMT.ReadOnly = true;
            this.clUsuarioMT.Width = 125;
            // 
            // clDias
            // 
            this.clDias.DataPropertyName = "dias";
            this.clDias.HeaderText = "Días en Taller";
            this.clDias.Name = "clDias";
            this.clDias.ReadOnly = true;
            this.clDias.Width = 98;
            // 
            // cboMalosTaller
            // 
            this.cboMalosTaller.Busqueda = false;
            this.cboMalosTaller.ListaMostrada = null;
            this.cboMalosTaller.Location = new System.Drawing.Point(70, 15);
            this.cboMalosTaller.Name = "cboMalosTaller";
            this.cboMalosTaller.Size = new System.Drawing.Size(200, 21);
            this.cboMalosTaller.TabIndex = 48;
            // 
            // tpNoRecuperables
            // 
            this.tpNoRecuperables.Controls.Add(this.lblCartucho);
            this.tpNoRecuperables.Controls.Add(this.btnActualizar);
            this.tpNoRecuperables.Controls.Add(this.cbTodosRecuperables);
            this.tpNoRecuperables.Controls.Add(this.btnExportarNoRecuperables);
            this.tpNoRecuperables.Controls.Add(this.dgvNoRecuperable);
            this.tpNoRecuperables.Controls.Add(this.cboCartucho);
            this.tpNoRecuperables.Location = new System.Drawing.Point(4, 22);
            this.tpNoRecuperables.Name = "tpNoRecuperables";
            this.tpNoRecuperables.Padding = new System.Windows.Forms.Padding(3);
            this.tpNoRecuperables.Size = new System.Drawing.Size(747, 393);
            this.tpNoRecuperables.TabIndex = 22;
            this.tpNoRecuperables.Text = "No Recuperables";
            this.tpNoRecuperables.UseVisualStyleBackColor = true;
            // 
            // lblCartucho
            // 
            this.lblCartucho.AutoSize = true;
            this.lblCartucho.Location = new System.Drawing.Point(6, 20);
            this.lblCartucho.Name = "lblCartucho";
            this.lblCartucho.Size = new System.Drawing.Size(53, 13);
            this.lblCartucho.TabIndex = 40;
            this.lblCartucho.Text = "Cartucho:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(324, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 42;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cbTodosRecuperables
            // 
            this.cbTodosRecuperables.AutoSize = true;
            this.cbTodosRecuperables.Location = new System.Drawing.Point(450, 19);
            this.cbTodosRecuperables.Name = "cbTodosRecuperables";
            this.cbTodosRecuperables.Size = new System.Drawing.Size(92, 17);
            this.cbTodosRecuperables.TabIndex = 46;
            this.cbTodosRecuperables.Text = "Marcar Todos";
            this.cbTodosRecuperables.UseVisualStyleBackColor = true;
            this.cbTodosRecuperables.CheckedChanged += new System.EventHandler(this.cbTodosRecuperables_CheckedChanged);
            // 
            // btnExportarNoRecuperables
            // 
            this.btnExportarNoRecuperables.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarNoRecuperables.FlatAppearance.BorderSize = 2;
            this.btnExportarNoRecuperables.Image = global::GUILayer.Properties.Resources.excel;
            this.btnExportarNoRecuperables.Location = new System.Drawing.Point(651, 347);
            this.btnExportarNoRecuperables.Name = "btnExportarNoRecuperables";
            this.btnExportarNoRecuperables.Size = new System.Drawing.Size(90, 40);
            this.btnExportarNoRecuperables.TabIndex = 45;
            this.btnExportarNoRecuperables.Text = "Exportar";
            this.btnExportarNoRecuperables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarNoRecuperables.UseVisualStyleBackColor = false;
            this.btnExportarNoRecuperables.Click += new System.EventHandler(this.btnExportarNoRecuperables_Click);
            // 
            // dgvNoRecuperable
            // 
            this.dgvNoRecuperable.AllowUserToAddRows = false;
            this.dgvNoRecuperable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvNoRecuperable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNoRecuperable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNoRecuperable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNoRecuperable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNoRecuperable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvNoRecuperable.ColumnHeadersHeight = 17;
            this.dgvNoRecuperable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clchecNR,
            this.clCartucho,
            this.clTipoNR,
            this.clTransportadora,
            this.clFalla,
            this.clFechaNR,
            this.clUsuarioNR});
            this.dgvNoRecuperable.EnableHeadersVisualStyles = false;
            this.dgvNoRecuperable.Location = new System.Drawing.Point(6, 52);
            this.dgvNoRecuperable.Name = "dgvNoRecuperable";
            this.dgvNoRecuperable.RowHeadersVisible = false;
            this.dgvNoRecuperable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNoRecuperable.Size = new System.Drawing.Size(735, 289);
            this.dgvNoRecuperable.StandardTab = true;
            this.dgvNoRecuperable.TabIndex = 2;
            // 
            // clchecNR
            // 
            this.clchecNR.HeaderText = "";
            this.clchecNR.Name = "clchecNR";
            this.clchecNR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clchecNR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clchecNR.Width = 18;
            // 
            // clCartucho
            // 
            this.clCartucho.DataPropertyName = "NombreCart";
            this.clCartucho.HeaderText = "Cartucho";
            this.clCartucho.Name = "clCartucho";
            this.clCartucho.ReadOnly = true;
            this.clCartucho.Width = 74;
            // 
            // clTipoNR
            // 
            this.clTipoNR.DataPropertyName = "Tipo";
            this.clTipoNR.HeaderText = "Tipo Cartucho";
            this.clTipoNR.Name = "clTipoNR";
            this.clTipoNR.ReadOnly = true;
            this.clTipoNR.Width = 98;
            // 
            // clTransportadora
            // 
            this.clTransportadora.DataPropertyName = "empresa";
            this.clTransportadora.HeaderText = "Proveedor";
            this.clTransportadora.Name = "clTransportadora";
            this.clTransportadora.ReadOnly = true;
            this.clTransportadora.Width = 80;
            // 
            // clFalla
            // 
            this.clFalla.DataPropertyName = "NombreFalla";
            this.clFalla.HeaderText = "Falla Registrada";
            this.clFalla.Name = "clFalla";
            this.clFalla.ReadOnly = true;
            this.clFalla.Width = 107;
            // 
            // clFechaNR
            // 
            this.clFechaNR.DataPropertyName = "Fecha";
            this.clFechaNR.HeaderText = "Fecha de registro";
            this.clFechaNR.Name = "clFechaNR";
            this.clFechaNR.ReadOnly = true;
            this.clFechaNR.Width = 113;
            // 
            // clUsuarioNR
            // 
            this.clUsuarioNR.DataPropertyName = "Usuario";
            this.clUsuarioNR.HeaderText = "Usuario que registra";
            this.clUsuarioNR.Name = "clUsuarioNR";
            this.clUsuarioNR.ReadOnly = true;
            this.clUsuarioNR.Width = 125;
            // 
            // cboCartucho
            // 
            this.cboCartucho.Busqueda = false;
            this.cboCartucho.ListaMostrada = null;
            this.cboCartucho.Location = new System.Drawing.Point(70, 15);
            this.cboCartucho.Name = "cboCartucho";
            this.cboCartucho.Size = new System.Drawing.Size(200, 21);
            this.cboCartucho.TabIndex = 41;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(30, 69);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(92, 65);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 4;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(658, 512);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // frmRecepcionCartuchos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 558);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.tcRecepcionEntrega);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecepcionCartuchos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepción de Cartuchos";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.tcRecepcionEntrega.ResumeLayout(false);
            this.tpEntregaTaller.ResumeLayout(false);
            this.tpEntregaTaller.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregar)).EndInit();
            this.tpRecibirTaller.ResumeLayout(false);
            this.tpRecibirTaller.PerformLayout();
            this.gbRecibir.ResumeLayout(false);
            this.gbRecibir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibir)).EndInit();
            this.tpNoRecuperables.ResumeLayout(false);
            this.tpNoRecuperables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoRecuperable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.TabControl tcRecepcionEntrega;
        private System.Windows.Forms.TabPage tpEntregaTaller;
        private System.Windows.Forms.TabPage tpRecibirTaller;
        private System.Windows.Forms.TabPage tpNoRecuperables;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvEntregar;
        private System.Windows.Forms.DataGridView dgvRecibir;
        private System.Windows.Forms.DataGridView dgvNoRecuperable;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblCartucho;
        private ComboBoxBusqueda cboCartucho;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnActualizarTesoreria;
        private ComboBoxBusqueda cboCartuchoMalo;
        private System.Windows.Forms.CheckBox cbTodosEntTaller;
        private System.Windows.Forms.Button btnExportarMalosTesoreria;
        private System.Windows.Forms.GroupBox gbRecibir;
        private System.Windows.Forms.TextBox txtCartucho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizarTaller;
        private ComboBoxBusqueda cboMalosTaller;
        private System.Windows.Forms.CheckBox cbTodosRecibir;
        private System.Windows.Forms.Button btnExportarMalosTaller;
        private System.Windows.Forms.CheckBox cbTodosRecuperables;
        private System.Windows.Forms.Button btnExportarNoRecuperables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTipoFalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clchecNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCartucho;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTipoNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTransportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFechaNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsuarioNR;
        private System.Windows.Forms.Button btnEliminarRecibidos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTipoMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProveedorMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFallaMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFechaMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsuarioMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDias;
    }
}