namespace GUILayer
{
    partial class frmModificacionCargaEmergencia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificacionCargaEmergencia));
            this.dtpFechaEmergenciasPendientes = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEmergenciasPendientes = new System.Windows.Forms.Label();
            this.dgvEmergenciasPendientes = new System.Windows.Forms.DataGridView();
            this.NumeroEmergenciaPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmergenciaPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesEmergenciaPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresEmergenciaPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.tlpCargasEmergencia = new System.Windows.Forms.TableLayoutPanel();
            this.gbCargasPendientes = new System.Windows.Forms.GroupBox();
            this.gbEmergenciasAsignadas = new System.Windows.Forms.GroupBox();
            this.dgvEmergenciasAsignadas = new System.Windows.Forms.DataGridView();
            this.NumeroEmergenciaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmergenciaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesEmergenciaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresEmergenciaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnDesasignarTodas = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.dtpFechaCarga = new System.Windows.Forms.DateTimePicker();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.lblATM = new System.Windows.Forms.Label();
            this.lblFechaCarga = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergenciasPendientes)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.tlpCargasEmergencia.SuspendLayout();
            this.gbCargasPendientes.SuspendLayout();
            this.gbEmergenciasAsignadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergenciasAsignadas)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaEmergenciasPendientes
            // 
            this.dtpFechaEmergenciasPendientes.Location = new System.Drawing.Point(52, 29);
            this.dtpFechaEmergenciasPendientes.Name = "dtpFechaEmergenciasPendientes";
            this.dtpFechaEmergenciasPendientes.Size = new System.Drawing.Size(243, 20);
            this.dtpFechaEmergenciasPendientes.TabIndex = 1;
            // 
            // lblFechaEmergenciasPendientes
            // 
            this.lblFechaEmergenciasPendientes.AutoSize = true;
            this.lblFechaEmergenciasPendientes.Location = new System.Drawing.Point(6, 33);
            this.lblFechaEmergenciasPendientes.Name = "lblFechaEmergenciasPendientes";
            this.lblFechaEmergenciasPendientes.Size = new System.Drawing.Size(40, 13);
            this.lblFechaEmergenciasPendientes.TabIndex = 0;
            this.lblFechaEmergenciasPendientes.Text = "Fecha:";
            // 
            // dgvEmergenciasPendientes
            // 
            this.dgvEmergenciasPendientes.AllowUserToAddRows = false;
            this.dgvEmergenciasPendientes.AllowUserToDeleteRows = false;
            this.dgvEmergenciasPendientes.AllowUserToOrderColumns = true;
            this.dgvEmergenciasPendientes.AllowUserToResizeColumns = false;
            this.dgvEmergenciasPendientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvEmergenciasPendientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmergenciasPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmergenciasPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEmergenciasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmergenciasPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroEmergenciaPendiente,
            this.FechaEmergenciaPendiente,
            this.MontoColonesEmergenciaPendiente,
            this.MontoDolaresEmergenciaPendiente});
            this.dgvEmergenciasPendientes.EnableHeadersVisualStyles = false;
            this.dgvEmergenciasPendientes.GridColor = System.Drawing.Color.Black;
            this.dgvEmergenciasPendientes.Location = new System.Drawing.Point(6, 65);
            this.dgvEmergenciasPendientes.MultiSelect = false;
            this.dgvEmergenciasPendientes.Name = "dgvEmergenciasPendientes";
            this.dgvEmergenciasPendientes.ReadOnly = true;
            this.dgvEmergenciasPendientes.RowHeadersVisible = false;
            this.dgvEmergenciasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmergenciasPendientes.Size = new System.Drawing.Size(390, 320);
            this.dgvEmergenciasPendientes.StandardTab = true;
            this.dgvEmergenciasPendientes.TabIndex = 3;
            this.dgvEmergenciasPendientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmergenciasPendientes_CellDoubleClick);
            this.dgvEmergenciasPendientes.SelectionChanged += new System.EventHandler(this.dgvEmergenciasPendientes_SelectionChanged);
            // 
            // NumeroEmergenciaPendiente
            // 
            this.NumeroEmergenciaPendiente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumeroEmergenciaPendiente.DataPropertyName = "Emergencia";
            this.NumeroEmergenciaPendiente.HeaderText = "Emergencia";
            this.NumeroEmergenciaPendiente.Name = "NumeroEmergenciaPendiente";
            this.NumeroEmergenciaPendiente.ReadOnly = true;
            this.NumeroEmergenciaPendiente.Width = 87;
            // 
            // FechaEmergenciaPendiente
            // 
            this.FechaEmergenciaPendiente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaEmergenciaPendiente.DataPropertyName = "Fecha_asignada";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaEmergenciaPendiente.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaEmergenciaPendiente.HeaderText = "Fecha";
            this.FechaEmergenciaPendiente.Name = "FechaEmergenciaPendiente";
            this.FechaEmergenciaPendiente.ReadOnly = true;
            this.FechaEmergenciaPendiente.Width = 61;
            // 
            // MontoColonesEmergenciaPendiente
            // 
            this.MontoColonesEmergenciaPendiente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColonesEmergenciaPendiente.DataPropertyName = "Monto_asignado_colones";
            dataGridViewCellStyle3.Format = "N2";
            this.MontoColonesEmergenciaPendiente.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoColonesEmergenciaPendiente.HeaderText = "M. en Colones";
            this.MontoColonesEmergenciaPendiente.Name = "MontoColonesEmergenciaPendiente";
            this.MontoColonesEmergenciaPendiente.ReadOnly = true;
            this.MontoColonesEmergenciaPendiente.Width = 99;
            // 
            // MontoDolaresEmergenciaPendiente
            // 
            this.MontoDolaresEmergenciaPendiente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolaresEmergenciaPendiente.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle4.Format = "N2";
            this.MontoDolaresEmergenciaPendiente.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoDolaresEmergenciaPendiente.HeaderText = "M. en Dólares";
            this.MontoDolaresEmergenciaPendiente.Name = "MontoDolaresEmergenciaPendiente";
            this.MontoDolaresEmergenciaPendiente.ReadOnly = true;
            this.MontoDolaresEmergenciaPendiente.Width = 97;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(301, 19);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 2;
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
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(784, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
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
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(892, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // tlpCargasEmergencia
            // 
            this.tlpCargasEmergencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCargasEmergencia.ColumnCount = 3;
            this.tlpCargasEmergencia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tlpCargasEmergencia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCargasEmergencia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tlpCargasEmergencia.Controls.Add(this.gbCargasPendientes, 0, 0);
            this.tlpCargasEmergencia.Controls.Add(this.gbEmergenciasAsignadas, 2, 0);
            this.tlpCargasEmergencia.Controls.Add(this.pnlBotones, 1, 0);
            this.tlpCargasEmergencia.Location = new System.Drawing.Point(12, 117);
            this.tlpCargasEmergencia.Name = "tlpCargasEmergencia";
            this.tlpCargasEmergencia.RowCount = 1;
            this.tlpCargasEmergencia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCargasEmergencia.Size = new System.Drawing.Size(868, 391);
            this.tlpCargasEmergencia.TabIndex = 2;
            // 
            // gbCargasPendientes
            // 
            this.gbCargasPendientes.Controls.Add(this.dgvEmergenciasPendientes);
            this.gbCargasPendientes.Controls.Add(this.dtpFechaEmergenciasPendientes);
            this.gbCargasPendientes.Controls.Add(this.btnActualizar);
            this.gbCargasPendientes.Controls.Add(this.lblFechaEmergenciasPendientes);
            this.gbCargasPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCargasPendientes.Location = new System.Drawing.Point(0, 0);
            this.gbCargasPendientes.Margin = new System.Windows.Forms.Padding(0);
            this.gbCargasPendientes.Name = "gbCargasPendientes";
            this.gbCargasPendientes.Size = new System.Drawing.Size(402, 391);
            this.gbCargasPendientes.TabIndex = 0;
            this.gbCargasPendientes.TabStop = false;
            this.gbCargasPendientes.Text = "Emergencias Pendientes";
            // 
            // gbEmergenciasAsignadas
            // 
            this.gbEmergenciasAsignadas.Controls.Add(this.dgvEmergenciasAsignadas);
            this.gbEmergenciasAsignadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEmergenciasAsignadas.Location = new System.Drawing.Point(464, 0);
            this.gbEmergenciasAsignadas.Margin = new System.Windows.Forms.Padding(0);
            this.gbEmergenciasAsignadas.Name = "gbEmergenciasAsignadas";
            this.gbEmergenciasAsignadas.Size = new System.Drawing.Size(404, 391);
            this.gbEmergenciasAsignadas.TabIndex = 2;
            this.gbEmergenciasAsignadas.TabStop = false;
            this.gbEmergenciasAsignadas.Text = "Emergencias Asignadas a la Carga de Emergencia";
            // 
            // dgvEmergenciasAsignadas
            // 
            this.dgvEmergenciasAsignadas.AllowUserToAddRows = false;
            this.dgvEmergenciasAsignadas.AllowUserToDeleteRows = false;
            this.dgvEmergenciasAsignadas.AllowUserToOrderColumns = true;
            this.dgvEmergenciasAsignadas.AllowUserToResizeColumns = false;
            this.dgvEmergenciasAsignadas.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvEmergenciasAsignadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEmergenciasAsignadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmergenciasAsignadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEmergenciasAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmergenciasAsignadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroEmergenciaAsignada,
            this.FechaEmergenciaAsignada,
            this.MontoColonesEmergenciaAsignada,
            this.MontoDolaresEmergenciaAsignada});
            this.dgvEmergenciasAsignadas.EnableHeadersVisualStyles = false;
            this.dgvEmergenciasAsignadas.GridColor = System.Drawing.Color.Black;
            this.dgvEmergenciasAsignadas.Location = new System.Drawing.Point(6, 23);
            this.dgvEmergenciasAsignadas.MultiSelect = false;
            this.dgvEmergenciasAsignadas.Name = "dgvEmergenciasAsignadas";
            this.dgvEmergenciasAsignadas.ReadOnly = true;
            this.dgvEmergenciasAsignadas.RowHeadersVisible = false;
            this.dgvEmergenciasAsignadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmergenciasAsignadas.Size = new System.Drawing.Size(392, 362);
            this.dgvEmergenciasAsignadas.StandardTab = true;
            this.dgvEmergenciasAsignadas.TabIndex = 0;
            this.dgvEmergenciasAsignadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmergenciasAsignadas_CellDoubleClick);
            this.dgvEmergenciasAsignadas.SelectionChanged += new System.EventHandler(this.dgvEmergenciasAsignadas_SelectionChanged);
            // 
            // NumeroEmergenciaAsignada
            // 
            this.NumeroEmergenciaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumeroEmergenciaAsignada.DataPropertyName = "Emergencia";
            this.NumeroEmergenciaAsignada.HeaderText = "Emergencia";
            this.NumeroEmergenciaAsignada.Name = "NumeroEmergenciaAsignada";
            this.NumeroEmergenciaAsignada.ReadOnly = true;
            this.NumeroEmergenciaAsignada.Width = 87;
            // 
            // FechaEmergenciaAsignada
            // 
            this.FechaEmergenciaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaEmergenciaAsignada.DataPropertyName = "Fecha_asignada";
            dataGridViewCellStyle6.Format = "d";
            this.FechaEmergenciaAsignada.DefaultCellStyle = dataGridViewCellStyle6;
            this.FechaEmergenciaAsignada.HeaderText = "Fecha";
            this.FechaEmergenciaAsignada.Name = "FechaEmergenciaAsignada";
            this.FechaEmergenciaAsignada.ReadOnly = true;
            this.FechaEmergenciaAsignada.Width = 61;
            // 
            // MontoColonesEmergenciaAsignada
            // 
            this.MontoColonesEmergenciaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColonesEmergenciaAsignada.DataPropertyName = "Monto_carga_colones";
            dataGridViewCellStyle7.Format = "N2";
            this.MontoColonesEmergenciaAsignada.DefaultCellStyle = dataGridViewCellStyle7;
            this.MontoColonesEmergenciaAsignada.HeaderText = "M. en Colones";
            this.MontoColonesEmergenciaAsignada.Name = "MontoColonesEmergenciaAsignada";
            this.MontoColonesEmergenciaAsignada.ReadOnly = true;
            this.MontoColonesEmergenciaAsignada.Width = 99;
            // 
            // MontoDolaresEmergenciaAsignada
            // 
            this.MontoDolaresEmergenciaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolaresEmergenciaAsignada.DataPropertyName = "Monto_carga_dolares";
            dataGridViewCellStyle8.Format = "N2";
            this.MontoDolaresEmergenciaAsignada.DefaultCellStyle = dataGridViewCellStyle8;
            this.MontoDolaresEmergenciaAsignada.HeaderText = "M. en Dólares";
            this.MontoDolaresEmergenciaAsignada.Name = "MontoDolaresEmergenciaAsignada";
            this.MontoDolaresEmergenciaAsignada.ReadOnly = true;
            this.MontoDolaresEmergenciaAsignada.Width = 97;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnDesasignarTodas);
            this.pnlBotones.Controls.Add(this.btnAsignar);
            this.pnlBotones.Controls.Add(this.btnDesasignar);
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
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.dtpFechaCarga);
            this.gbDatos.Controls.Add(this.cboATM);
            this.gbDatos.Controls.Add(this.lblATM);
            this.gbDatos.Controls.Add(this.lblFechaCarga);
            this.gbDatos.Location = new System.Drawing.Point(12, 65);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(570, 46);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Carga de Emergencia";
            // 
            // dtpFechaCarga
            // 
            this.dtpFechaCarga.Location = new System.Drawing.Point(52, 19);
            this.dtpFechaCarga.Name = "dtpFechaCarga";
            this.dtpFechaCarga.Size = new System.Drawing.Size(228, 20);
            this.dtpFechaCarga.TabIndex = 1;
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = false;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(325, 19);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(234, 21);
            this.cboATM.TabIndex = 3;
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(286, 23);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(33, 13);
            this.lblATM.TabIndex = 2;
            this.lblATM.Text = "ATM:";
            // 
            // lblFechaCarga
            // 
            this.lblFechaCarga.AutoSize = true;
            this.lblFechaCarga.Location = new System.Drawing.Point(6, 23);
            this.lblFechaCarga.Name = "lblFechaCarga";
            this.lblFechaCarga.Size = new System.Drawing.Size(40, 13);
            this.lblFechaCarga.TabIndex = 0;
            this.lblFechaCarga.Text = "Fecha:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(688, 514);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmModificacionCargaEmergencia
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(892, 566);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.tlpCargasEmergencia);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModificacionCargaEmergencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación de Cargas de Emergencia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergenciasPendientes)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.tlpCargasEmergencia.ResumeLayout(false);
            this.gbCargasPendientes.ResumeLayout(false);
            this.gbCargasPendientes.PerformLayout();
            this.gbEmergenciasAsignadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergenciasAsignadas)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaEmergenciasPendientes;
        private System.Windows.Forms.Label lblFechaEmergenciasPendientes;
        private System.Windows.Forms.DataGridView dgvEmergenciasPendientes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TableLayoutPanel tlpCargasEmergencia;
        private System.Windows.Forms.GroupBox gbCargasPendientes;
        private System.Windows.Forms.GroupBox gbEmergenciasAsignadas;
        private System.Windows.Forms.DataGridView dgvEmergenciasAsignadas;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnDesasignarTodas;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblFechaCarga;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.DateTimePicker dtpFechaCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroEmergenciaPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmergenciaPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesEmergenciaPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresEmergenciaPendiente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroEmergenciaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmergenciaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesEmergenciaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresEmergenciaAsignada;
    }
}