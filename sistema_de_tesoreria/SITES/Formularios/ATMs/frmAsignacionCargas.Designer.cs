namespace GUILayer
{
    partial class frmAsignacionCargas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignacionCargas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCargasPendientes = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.ATMCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RutaCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Full = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.gbCargasAsignadas = new System.Windows.Forms.GroupBox();
            this.btnCartuchos = new System.Windows.Forms.Button();
            this.btnMontos = new System.Windows.Forms.Button();
            this.btnModificarCargaAsignada = new System.Windows.Forms.Button();
            this.txtMontoDolares = new System.Windows.Forms.TextBox();
            this.lblMontoDolares = new System.Windows.Forms.Label();
            this.lblMontoColones = new System.Windows.Forms.Label();
            this.txtMontoColones = new System.Windows.Forms.TextBox();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.lblCajero = new System.Windows.Forms.Label();
            this.dgvCargasAsignadas = new System.Windows.Forms.DataGridView();
            this.ATMCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RutaCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoColonesCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoDolaresCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargaAsignadaFull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.tlpCargas = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnDesasignarTodas = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAutoAsignacion = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargasPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbCargasAsignadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasAsignadas)).BeginInit();
            this.tlpCargas.SuspendLayout();
            this.pnlBotones.SuspendLayout();
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
            this.pnlFondo.Size = new System.Drawing.Size(892, 60);
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
            // gbCargasPendientes
            // 
            this.gbCargasPendientes.Controls.Add(this.dtpFecha);
            this.gbCargasPendientes.Controls.Add(this.lblFecha);
            this.gbCargasPendientes.Controls.Add(this.dgvCargas);
            this.gbCargasPendientes.Controls.Add(this.btnModificar);
            this.gbCargasPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCargasPendientes.Location = new System.Drawing.Point(0, 0);
            this.gbCargasPendientes.Margin = new System.Windows.Forms.Padding(0);
            this.gbCargasPendientes.Name = "gbCargasPendientes";
            this.gbCargasPendientes.Size = new System.Drawing.Size(402, 442);
            this.gbCargasPendientes.TabIndex = 0;
            this.gbCargasPendientes.TabStop = false;
            this.gbCargasPendientes.Text = "Cargas Pendientes";
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.AllowUserToOrderColumns = true;
            this.dgvCargas.AllowUserToResizeColumns = false;
            this.dgvCargas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCargas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATMCarga,
            this.FechaCarga,
            this.MontoAsignadoColonesCarga,
            this.MontoColonesCarga,
            this.MontoAsignadoDolaresCarga,
            this.MontoDolaresCarga,
            this.RutaCarga,
            this.Full});
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 46);
            this.dgvCargas.MultiSelect = false;
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(390, 344);
            this.dgvCargas.StandardTab = true;
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellDoubleClick);
            this.dgvCargas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCargas_RowsAdded);
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // ATMCarga
            // 
            this.ATMCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATMCarga.HeaderText = "ATM";
            this.ATMCarga.Name = "ATMCarga";
            this.ATMCarga.ReadOnly = true;
            this.ATMCarga.Width = 54;
            // 
            // FechaCarga
            // 
            this.FechaCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaCarga.DataPropertyName = "Fecha_asignada";
            this.FechaCarga.HeaderText = "Fecha";
            this.FechaCarga.Name = "FechaCarga";
            this.FechaCarga.ReadOnly = true;
            this.FechaCarga.Width = 61;
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
            // RutaCarga
            // 
            this.RutaCarga.DataPropertyName = "Ruta";
            this.RutaCarga.HeaderText = "Ruta";
            this.RutaCarga.Name = "RutaCarga";
            this.RutaCarga.ReadOnly = true;
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
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Location = new System.Drawing.Point(306, 396);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Enabled = false;
            this.btnAsignar.FlatAppearance.BorderSize = 2;
            this.btnAsignar.Location = new System.Drawing.Point(0, 140);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(50, 40);
            this.btnAsignar.TabIndex = 2;
            this.btnAsignar.Text = ">";
            this.btnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // gbCargasAsignadas
            // 
            this.gbCargasAsignadas.Controls.Add(this.btnCartuchos);
            this.gbCargasAsignadas.Controls.Add(this.btnMontos);
            this.gbCargasAsignadas.Controls.Add(this.btnModificarCargaAsignada);
            this.gbCargasAsignadas.Controls.Add(this.txtMontoDolares);
            this.gbCargasAsignadas.Controls.Add(this.lblMontoDolares);
            this.gbCargasAsignadas.Controls.Add(this.lblMontoColones);
            this.gbCargasAsignadas.Controls.Add(this.txtMontoColones);
            this.gbCargasAsignadas.Controls.Add(this.cboCajero);
            this.gbCargasAsignadas.Controls.Add(this.lblCajero);
            this.gbCargasAsignadas.Controls.Add(this.dgvCargasAsignadas);
            this.gbCargasAsignadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCargasAsignadas.Location = new System.Drawing.Point(464, 0);
            this.gbCargasAsignadas.Margin = new System.Windows.Forms.Padding(0);
            this.gbCargasAsignadas.Name = "gbCargasAsignadas";
            this.gbCargasAsignadas.Size = new System.Drawing.Size(404, 442);
            this.gbCargasAsignadas.TabIndex = 2;
            this.gbCargasAsignadas.TabStop = false;
            this.gbCargasAsignadas.Text = "Cargas Asignadas al Cajero";
            // 
            // btnCartuchos
            // 
            this.btnCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCartuchos.Enabled = false;
            this.btnCartuchos.FlatAppearance.BorderSize = 2;
            this.btnCartuchos.Image = ((System.Drawing.Image)(resources.GetObject("btnCartuchos.Image")));
            this.btnCartuchos.Location = new System.Drawing.Point(106, 396);
            this.btnCartuchos.Name = "btnCartuchos";
            this.btnCartuchos.Size = new System.Drawing.Size(95, 40);
            this.btnCartuchos.TabIndex = 7;
            this.btnCartuchos.Text = "Cartuchos";
            this.btnCartuchos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCartuchos.UseVisualStyleBackColor = false;
            this.btnCartuchos.Click += new System.EventHandler(this.btnCartuchos_Click);
            // 
            // btnMontos
            // 
            this.btnMontos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMontos.Enabled = false;
            this.btnMontos.FlatAppearance.BorderSize = 2;
            this.btnMontos.Image = ((System.Drawing.Image)(resources.GetObject("btnMontos.Image")));
            this.btnMontos.Location = new System.Drawing.Point(207, 396);
            this.btnMontos.Name = "btnMontos";
            this.btnMontos.Size = new System.Drawing.Size(95, 40);
            this.btnMontos.TabIndex = 8;
            this.btnMontos.Text = "Montos";
            this.btnMontos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMontos.UseVisualStyleBackColor = false;
            this.btnMontos.Click += new System.EventHandler(this.btnMontos_Click);
            // 
            // btnModificarCargaAsignada
            // 
            this.btnModificarCargaAsignada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarCargaAsignada.Enabled = false;
            this.btnModificarCargaAsignada.FlatAppearance.BorderSize = 2;
            this.btnModificarCargaAsignada.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarCargaAsignada.Image")));
            this.btnModificarCargaAsignada.Location = new System.Drawing.Point(308, 396);
            this.btnModificarCargaAsignada.Name = "btnModificarCargaAsignada";
            this.btnModificarCargaAsignada.Size = new System.Drawing.Size(90, 40);
            this.btnModificarCargaAsignada.TabIndex = 9;
            this.btnModificarCargaAsignada.Text = "Modificar";
            this.btnModificarCargaAsignada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificarCargaAsignada.UseVisualStyleBackColor = false;
            this.btnModificarCargaAsignada.Click += new System.EventHandler(this.btnModificarCargaAsignada_Click);
            // 
            // txtMontoDolares
            // 
            this.txtMontoDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoDolares.Location = new System.Drawing.Point(308, 370);
            this.txtMontoDolares.Name = "txtMontoDolares";
            this.txtMontoDolares.ReadOnly = true;
            this.txtMontoDolares.Size = new System.Drawing.Size(90, 20);
            this.txtMontoDolares.TabIndex = 6;
            // 
            // lblMontoDolares
            // 
            this.lblMontoDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoDolares.AutoSize = true;
            this.lblMontoDolares.Location = new System.Drawing.Point(226, 374);
            this.lblMontoDolares.Name = "lblMontoDolares";
            this.lblMontoDolares.Size = new System.Drawing.Size(76, 13);
            this.lblMontoDolares.TabIndex = 5;
            this.lblMontoDolares.Text = "M. en Dólares:";
            // 
            // lblMontoColones
            // 
            this.lblMontoColones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoColones.AutoSize = true;
            this.lblMontoColones.Location = new System.Drawing.Point(22, 374);
            this.lblMontoColones.Name = "lblMontoColones";
            this.lblMontoColones.Size = new System.Drawing.Size(78, 13);
            this.lblMontoColones.TabIndex = 3;
            this.lblMontoColones.Text = "M. en Colones:";
            // 
            // txtMontoColones
            // 
            this.txtMontoColones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoColones.Location = new System.Drawing.Point(106, 370);
            this.txtMontoColones.Name = "txtMontoColones";
            this.txtMontoColones.ReadOnly = true;
            this.txtMontoColones.Size = new System.Drawing.Size(95, 20);
            this.txtMontoColones.TabIndex = 4;
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(52, 19);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(232, 21);
            this.cboCajero.TabIndex = 1;
            this.cboCajero.SelectedIndexChanged += new System.EventHandler(this.cboCajero_SelectedIndexChanged);
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(6, 23);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 0;
            this.lblCajero.Text = "Cajero:";
            // 
            // dgvCargasAsignadas
            // 
            this.dgvCargasAsignadas.AllowUserToAddRows = false;
            this.dgvCargasAsignadas.AllowUserToDeleteRows = false;
            this.dgvCargasAsignadas.AllowUserToOrderColumns = true;
            this.dgvCargasAsignadas.AllowUserToResizeColumns = false;
            this.dgvCargasAsignadas.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCargasAsignadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCargasAsignadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargasAsignadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargasAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargasAsignadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATMCargaAsignada,
            this.FechaCargaAsignada,
            this.RutaCargaAsignada,
            this.MontoAsignadoColonesCargaAsignada,
            this.MontoColonesCargaAsignada,
            this.MontoAsignadoDolaresCargaAsignada,
            this.MontoDolaresCargaAsignada,
            this.CargaAsignadaFull});
            this.dgvCargasAsignadas.EnableHeadersVisualStyles = false;
            this.dgvCargasAsignadas.GridColor = System.Drawing.Color.Black;
            this.dgvCargasAsignadas.Location = new System.Drawing.Point(6, 46);
            this.dgvCargasAsignadas.MultiSelect = false;
            this.dgvCargasAsignadas.Name = "dgvCargasAsignadas";
            this.dgvCargasAsignadas.ReadOnly = true;
            this.dgvCargasAsignadas.RowHeadersVisible = false;
            this.dgvCargasAsignadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargasAsignadas.Size = new System.Drawing.Size(392, 318);
            this.dgvCargasAsignadas.StandardTab = true;
            this.dgvCargasAsignadas.TabIndex = 2;
            this.dgvCargasAsignadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargasAsignadas_CellDoubleClick);
            this.dgvCargasAsignadas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCargasAsignadas_RowsAdded);
            this.dgvCargasAsignadas.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCargasAsignadas_RowsRemoved);
            this.dgvCargasAsignadas.SelectionChanged += new System.EventHandler(this.dgvCargasAsignadas_SelectionChanged);
            // 
            // ATMCargaAsignada
            // 
            this.ATMCargaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATMCargaAsignada.HeaderText = "ATM";
            this.ATMCargaAsignada.Name = "ATMCargaAsignada";
            this.ATMCargaAsignada.ReadOnly = true;
            this.ATMCargaAsignada.Width = 54;
            // 
            // FechaCargaAsignada
            // 
            this.FechaCargaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaCargaAsignada.DataPropertyName = "Fecha_asignada";
            this.FechaCargaAsignada.HeaderText = "Fecha";
            this.FechaCargaAsignada.Name = "FechaCargaAsignada";
            this.FechaCargaAsignada.ReadOnly = true;
            this.FechaCargaAsignada.Width = 61;
            // 
            // RutaCargaAsignada
            // 
            this.RutaCargaAsignada.DataPropertyName = "Ruta";
            this.RutaCargaAsignada.HeaderText = "Ruta";
            this.RutaCargaAsignada.Name = "RutaCargaAsignada";
            this.RutaCargaAsignada.ReadOnly = true;
            // 
            // MontoAsignadoColonesCargaAsignada
            // 
            this.MontoAsignadoColonesCargaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoAsignadoColonesCargaAsignada.DataPropertyName = "Monto_asignado_colones";
            dataGridViewCellStyle7.Format = "N2";
            this.MontoAsignadoColonesCargaAsignada.DefaultCellStyle = dataGridViewCellStyle7;
            this.MontoAsignadoColonesCargaAsignada.HeaderText = "A. en Colones";
            this.MontoAsignadoColonesCargaAsignada.Name = "MontoAsignadoColonesCargaAsignada";
            this.MontoAsignadoColonesCargaAsignada.ReadOnly = true;
            this.MontoAsignadoColonesCargaAsignada.Width = 97;
            // 
            // MontoColonesCargaAsignada
            // 
            this.MontoColonesCargaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColonesCargaAsignada.DataPropertyName = "Monto_carga_colones";
            dataGridViewCellStyle8.Format = "N2";
            this.MontoColonesCargaAsignada.DefaultCellStyle = dataGridViewCellStyle8;
            this.MontoColonesCargaAsignada.HeaderText = "M. en Colones";
            this.MontoColonesCargaAsignada.Name = "MontoColonesCargaAsignada";
            this.MontoColonesCargaAsignada.ReadOnly = true;
            this.MontoColonesCargaAsignada.Width = 99;
            // 
            // MontoAsignadoDolaresCargaAsignada
            // 
            this.MontoAsignadoDolaresCargaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoAsignadoDolaresCargaAsignada.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle9.Format = "N2";
            this.MontoAsignadoDolaresCargaAsignada.DefaultCellStyle = dataGridViewCellStyle9;
            this.MontoAsignadoDolaresCargaAsignada.HeaderText = "A. en Dolares";
            this.MontoAsignadoDolaresCargaAsignada.Name = "MontoAsignadoDolaresCargaAsignada";
            this.MontoAsignadoDolaresCargaAsignada.ReadOnly = true;
            this.MontoAsignadoDolaresCargaAsignada.Width = 95;
            // 
            // MontoDolaresCargaAsignada
            // 
            this.MontoDolaresCargaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolaresCargaAsignada.DataPropertyName = "Monto_carga_dolares";
            dataGridViewCellStyle10.Format = "N2";
            this.MontoDolaresCargaAsignada.DefaultCellStyle = dataGridViewCellStyle10;
            this.MontoDolaresCargaAsignada.HeaderText = "M. en Dólares";
            this.MontoDolaresCargaAsignada.Name = "MontoDolaresCargaAsignada";
            this.MontoDolaresCargaAsignada.ReadOnly = true;
            this.MontoDolaresCargaAsignada.Width = 97;
            // 
            // CargaAsignadaFull
            // 
            this.CargaAsignadaFull.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CargaAsignadaFull.DataPropertyName = "ATM_full";
            this.CargaAsignadaFull.HeaderText = "Full";
            this.CargaAsignadaFull.Name = "CargaAsignadaFull";
            this.CargaAsignadaFull.ReadOnly = true;
            this.CargaAsignadaFull.Width = 28;
            // 
            // btnDesasignar
            // 
            this.btnDesasignar.Enabled = false;
            this.btnDesasignar.FlatAppearance.BorderSize = 2;
            this.btnDesasignar.Location = new System.Drawing.Point(0, 94);
            this.btnDesasignar.Name = "btnDesasignar";
            this.btnDesasignar.Size = new System.Drawing.Size(50, 40);
            this.btnDesasignar.TabIndex = 1;
            this.btnDesasignar.Text = "<";
            this.btnDesasignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesasignar.UseVisualStyleBackColor = false;
            this.btnDesasignar.Click += new System.EventHandler(this.btnDesasignar_Click);
            // 
            // tlpCargas
            // 
            this.tlpCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCargas.ColumnCount = 3;
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tlpCargas.Controls.Add(this.gbCargasPendientes, 0, 0);
            this.tlpCargas.Controls.Add(this.gbCargasAsignadas, 2, 0);
            this.tlpCargas.Controls.Add(this.pnlBotones, 1, 0);
            this.tlpCargas.Location = new System.Drawing.Point(12, 66);
            this.tlpCargas.Name = "tlpCargas";
            this.tlpCargas.RowCount = 1;
            this.tlpCargas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCargas.Size = new System.Drawing.Size(868, 442);
            this.tlpCargas.TabIndex = 1;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnDesasignarTodas);
            this.pnlBotones.Controls.Add(this.btnAsignar);
            this.pnlBotones.Controls.Add(this.btnDesasignar);
            this.pnlBotones.Enabled = false;
            this.pnlBotones.Location = new System.Drawing.Point(408, 0);
            this.pnlBotones.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(50, 180);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnDesasignarTodas
            // 
            this.btnDesasignarTodas.Enabled = false;
            this.btnDesasignarTodas.FlatAppearance.BorderSize = 2;
            this.btnDesasignarTodas.Location = new System.Drawing.Point(0, 48);
            this.btnDesasignarTodas.Name = "btnDesasignarTodas";
            this.btnDesasignarTodas.Size = new System.Drawing.Size(50, 40);
            this.btnDesasignarTodas.TabIndex = 0;
            this.btnDesasignarTodas.Text = "<<";
            this.btnDesasignarTodas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesasignarTodas.UseVisualStyleBackColor = false;
            this.btnDesasignarTodas.Click += new System.EventHandler(this.btnDesasignarTodas_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(683, 514);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(784, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAutoAsignacion
            // 
            this.btnAutoAsignacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoAsignacion.FlatAppearance.BorderSize = 2;
            this.btnAutoAsignacion.Image = global::GUILayer.Properties.Resources.asignacion;
            this.btnAutoAsignacion.Location = new System.Drawing.Point(582, 514);
            this.btnAutoAsignacion.Name = "btnAutoAsignacion";
            this.btnAutoAsignacion.Size = new System.Drawing.Size(95, 40);
            this.btnAutoAsignacion.TabIndex = 2;
            this.btnAutoAsignacion.Text = "Autoasig.";
            this.btnAutoAsignacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAutoAsignacion.UseVisualStyleBackColor = false;
            this.btnAutoAsignacion.Click += new System.EventHandler(this.btnAutoAsignacion_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(52, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(222, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(6, 24);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // frmAsignacionCargas
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(892, 566);
            this.Controls.Add(this.btnAutoAsignacion);
            this.Controls.Add(this.tlpCargas);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAsignacionCargas";
            this.Text = "Asignación de Cargas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargasPendientes.ResumeLayout(false);
            this.gbCargasPendientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbCargasAsignadas.ResumeLayout(false);
            this.gbCargasAsignadas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasAsignadas)).EndInit();
            this.tlpCargas.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCargasPendientes;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbCargasAsignadas;
        private System.Windows.Forms.DataGridView dgvCargasAsignadas;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.TableLayoutPanel tlpCargas;
        private System.Windows.Forms.Panel pnlBotones;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.TextBox txtMontoDolares;
        private System.Windows.Forms.Label lblMontoDolares;
        private System.Windows.Forms.Label lblMontoColones;
        private System.Windows.Forms.TextBox txtMontoColones;
        private System.Windows.Forms.Button btnModificarCargaAsignada;
        private System.Windows.Forms.Button btnMontos;
        private System.Windows.Forms.Button btnCartuchos;
        private System.Windows.Forms.Button btnAutoAsignacion;
        private System.Windows.Forms.Button btnDesasignarTodas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATMCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutaCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoColonesCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoDolaresCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresCargaAsignada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CargaAsignadaFull;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATMCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoDolaresCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutaCarga;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Full;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
    }
}