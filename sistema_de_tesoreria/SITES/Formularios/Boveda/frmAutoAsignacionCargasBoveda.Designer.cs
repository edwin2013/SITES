namespace GUILayer.Formularios.Boveda
{
    partial class frmAutoAsignacionCargasBoveda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoAsignacionCargasBoveda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbCargasPendientes = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.clbCajeros = new System.Windows.Forms.CheckedListBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gbCargasAsignadas = new System.Windows.Forms.GroupBox();
            this.dgvCargasAsignadas = new System.Windows.Forms.DataGridView();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.lblCajero = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tlpCargas = new System.Windows.Forms.TableLayoutPanel();
            this.CargaAsignadaFull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MontoDolaresCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoDolaresCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoColonesCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RutaCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATMCargaAsignada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Full = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RutaCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATMCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargasPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbCargasAsignadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasAsignadas)).BeginInit();
            this.tlpCargas.SuspendLayout();
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
            this.pnlFondo.TabIndex = 4;
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
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(685, 520);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(781, 520);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbCargasPendientes
            // 
            this.gbCargasPendientes.Controls.Add(this.dtpFecha);
            this.gbCargasPendientes.Controls.Add(this.lblFecha);
            this.gbCargasPendientes.Controls.Add(this.btnAsignar);
            this.gbCargasPendientes.Controls.Add(this.clbCajeros);
            this.gbCargasPendientes.Controls.Add(this.dgvCargas);
            this.gbCargasPendientes.Controls.Add(this.btnActualizar);
            this.gbCargasPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCargasPendientes.Location = new System.Drawing.Point(0, 0);
            this.gbCargasPendientes.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.gbCargasPendientes.Name = "gbCargasPendientes";
            this.gbCargasPendientes.Size = new System.Drawing.Size(430, 442);
            this.gbCargasPendientes.TabIndex = 0;
            this.gbCargasPendientes.TabStop = false;
            this.gbCargasPendientes.Text = "Cargas Pendientes";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(329, 396);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            this.dgvCargas.Size = new System.Drawing.Size(418, 229);
            this.dgvCargas.StandardTab = true;
            this.dgvCargas.TabIndex = 2;
            // 
            // clbCajeros
            // 
            this.clbCajeros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCajeros.ColumnWidth = 180;
            this.clbCajeros.FormattingEnabled = true;
            this.clbCajeros.HorizontalScrollbar = true;
            this.clbCajeros.Location = new System.Drawing.Point(6, 281);
            this.clbCajeros.MultiColumn = true;
            this.clbCajeros.Name = "clbCajeros";
            this.clbCajeros.Size = new System.Drawing.Size(418, 109);
            this.clbCajeros.TabIndex = 3;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignar.FlatAppearance.BorderSize = 2;
            this.btnAsignar.Image = global::GUILayer.Properties.Resources.asignacion;
            this.btnAsignar.Location = new System.Drawing.Point(228, 396);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(95, 40);
            this.btnAsignar.TabIndex = 4;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(6, 24);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // gbCargasAsignadas
            // 
            this.gbCargasAsignadas.Controls.Add(this.lblCajero);
            this.gbCargasAsignadas.Controls.Add(this.cboCajero);
            this.gbCargasAsignadas.Controls.Add(this.dgvCargasAsignadas);
            this.gbCargasAsignadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCargasAsignadas.Location = new System.Drawing.Point(436, 0);
            this.gbCargasAsignadas.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.gbCargasAsignadas.Name = "gbCargasAsignadas";
            this.gbCargasAsignadas.Size = new System.Drawing.Size(432, 442);
            this.gbCargasAsignadas.TabIndex = 1;
            this.gbCargasAsignadas.TabStop = false;
            this.gbCargasAsignadas.Text = "Cargas Asignadas";
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
            this.dgvCargasAsignadas.Size = new System.Drawing.Size(420, 390);
            this.dgvCargasAsignadas.StandardTab = true;
            this.dgvCargasAsignadas.TabIndex = 2;
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(52, 19);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(232, 21);
            this.cboCajero.TabIndex = 1;
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
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(52, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(222, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // tlpCargas
            // 
            this.tlpCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCargas.ColumnCount = 2;
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCargas.Controls.Add(this.gbCargasPendientes, 0, 0);
            this.tlpCargas.Controls.Add(this.gbCargasAsignadas, 1, 0);
            this.tlpCargas.Location = new System.Drawing.Point(12, 72);
            this.tlpCargas.Name = "tlpCargas";
            this.tlpCargas.RowCount = 1;
            this.tlpCargas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCargas.Size = new System.Drawing.Size(868, 442);
            this.tlpCargas.TabIndex = 5;
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
            // RutaCargaAsignada
            // 
            this.RutaCargaAsignada.DataPropertyName = "Ruta";
            this.RutaCargaAsignada.HeaderText = "Ruta";
            this.RutaCargaAsignada.Name = "RutaCargaAsignada";
            this.RutaCargaAsignada.ReadOnly = true;
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
            // ATMCargaAsignada
            // 
            this.ATMCargaAsignada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATMCargaAsignada.HeaderText = "ATM";
            this.ATMCargaAsignada.Name = "ATMCargaAsignada";
            this.ATMCargaAsignada.ReadOnly = true;
            this.ATMCargaAsignada.Width = 54;
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
            // RutaCarga
            // 
            this.RutaCarga.DataPropertyName = "Ruta";
            this.RutaCarga.HeaderText = "Ruta";
            this.RutaCarga.Name = "RutaCarga";
            this.RutaCarga.ReadOnly = true;
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
            // FechaCarga
            // 
            this.FechaCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaCarga.DataPropertyName = "Fecha_asignada";
            this.FechaCarga.HeaderText = "Fecha";
            this.FechaCarga.Name = "FechaCarga";
            this.FechaCarga.ReadOnly = true;
            this.FechaCarga.Width = 61;
            // 
            // ATMCarga
            // 
            this.ATMCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATMCarga.HeaderText = "ATM";
            this.ATMCarga.Name = "ATMCarga";
            this.ATMCarga.ReadOnly = true;
            this.ATMCarga.Width = 54;
            // 
            // frmAutoAsignacionCargasBoveda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 566);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tlpCargas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAutoAsignacionCargasBoveda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Asignación de Cargas";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargasPendientes.ResumeLayout(false);
            this.gbCargasPendientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbCargasAsignadas.ResumeLayout(false);
            this.gbCargasAsignadas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasAsignadas)).EndInit();
            this.tlpCargas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TableLayoutPanel tlpCargas;
        private System.Windows.Forms.GroupBox gbCargasPendientes;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.CheckedListBox clbCajeros;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbCargasAsignadas;
        private System.Windows.Forms.Label lblCajero;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.DataGridView dgvCargasAsignadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATMCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoDolaresCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutaCarga;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Full;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATMCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutaCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoColonesCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoDolaresCargaAsignada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresCargaAsignada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CargaAsignadaFull;
    }
}