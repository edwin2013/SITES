namespace GUILayer
{
    partial class frmListaTulas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaTulas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdDocumento = new System.Drawing.Printing.PrintDocument();
            this.gbTulas = new System.Windows.Forms.GroupBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.gbOpcionesListado = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbCajasImpresion = new System.Windows.Forms.GroupBox();
            this.dgvCajasImpresion = new System.Windows.Forms.DataGridView();
            this.tcTulasImpresion = new System.Windows.Forms.TabControl();
            this.tpTulas = new System.Windows.Forms.TabPage();
            this.tpTulasCaja = new System.Windows.Forms.TabPage();
            this.gbOpcionesImpresion = new System.Windows.Forms.GroupBox();
            this.nudCaja = new System.Windows.Forms.NumericUpDown();
            this.lblCaja = new System.Windows.Forms.Label();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.cboGrupo = new GUILayer.ComboBoxBusqueda();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.gbTulasCaja = new System.Windows.Forms.GroupBox();
            this.lblTotalTulas = new System.Windows.Forms.Label();
            this.lblTotalManifiestos = new System.Windows.Forms.Label();
            this.btnCambioGrupo = new System.Windows.Forms.Button();
            this.txtTotalManifiestos = new System.Windows.Forms.TextBox();
            this.txtTotalTulas = new System.Windows.Forms.TextBox();
            this.dgvTulasImpresion = new System.Windows.Forms.DataGridView();
            this.ManifiestoImpresionCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManifiestoImpresion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TulaImpresion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHoraIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpCajasImpresion = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.gbTulas.SuspendLayout();
            this.gbOpcionesListado.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCajasImpresion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajasImpresion)).BeginInit();
            this.tcTulasImpresion.SuspendLayout();
            this.tpTulas.SuspendLayout();
            this.tpTulasCaja.SuspendLayout();
            this.gbOpcionesImpresion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaja)).BeginInit();
            this.gbTulasCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasImpresion)).BeginInit();
            this.tpCajasImpresion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTulas
            // 
            this.dgvTulas.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTulas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTulas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grupo,
            this.Cajero,
            this.Caja,
            this.Tula,
            this.Manifiesto});
            this.dgvTulas.EnableHeadersVisualStyles = false;
            this.dgvTulas.Location = new System.Drawing.Point(6, 19);
            this.dgvTulas.MultiSelect = false;
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.RowHeadersVisible = false;
            this.dgvTulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulas.Size = new System.Drawing.Size(622, 322);
            this.dgvTulas.TabIndex = 0;
            this.dgvTulas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTulas_RowsAdded);
            // 
            // Grupo
            // 
            this.Grupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.Width = 60;
            // 
            // Cajero
            // 
            this.Cajero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cajero.DataPropertyName = "Cajero_Receptor";
            this.Cajero.HeaderText = "Cajero";
            this.Cajero.Name = "Cajero";
            this.Cajero.Width = 61;
            // 
            // Caja
            // 
            this.Caja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Caja.HeaderText = "Caja";
            this.Caja.Name = "Caja";
            this.Caja.Width = 52;
            // 
            // Tula
            // 
            this.Tula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tula.DataPropertyName = "Codigo";
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.Width = 52;
            // 
            // Manifiesto
            // 
            this.Manifiesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Manifiesto.DataPropertyName = "Manifiesto";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.Width = 79;
            // 
            // pdDocumento
            // 
            this.pdDocumento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdDocumento_PrintPage);
            // 
            // gbTulas
            // 
            this.gbTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTulas.Controls.Add(this.dgvTulas);
            this.gbTulas.Location = new System.Drawing.Point(3, 6);
            this.gbTulas.Name = "gbTulas";
            this.gbTulas.Size = new System.Drawing.Size(634, 347);
            this.gbTulas.TabIndex = 0;
            this.gbTulas.TabStop = false;
            this.gbTulas.Text = "Lista de Tulas";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(6, 33);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(82, 13);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha de inicio:";
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Location = new System.Drawing.Point(289, 33);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(62, 13);
            this.lblFechaFinal.TabIndex = 2;
            this.lblFechaFinal.Text = "Fecha final:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yy hh:mm tt";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(94, 26);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(189, 20);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CustomFormat = "dd/MM/yy hh:mm tt";
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinal.Location = new System.Drawing.Point(357, 29);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(189, 20);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // gbOpcionesListado
            // 
            this.gbOpcionesListado.Controls.Add(this.btnActualizar);
            this.gbOpcionesListado.Controls.Add(this.dtpFechaFinal);
            this.gbOpcionesListado.Controls.Add(this.lblFechaInicio);
            this.gbOpcionesListado.Controls.Add(this.dtpFechaInicio);
            this.gbOpcionesListado.Controls.Add(this.lblFechaFinal);
            this.gbOpcionesListado.Location = new System.Drawing.Point(12, 53);
            this.gbOpcionesListado.Name = "gbOpcionesListado";
            this.gbOpcionesListado.Size = new System.Drawing.Size(651, 65);
            this.gbOpcionesListado.TabIndex = 1;
            this.gbOpcionesListado.TabStop = false;
            this.gbOpcionesListado.Text = "Opciones de Listado";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(552, 19);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(698, 50);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(390, 44);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(563, 515);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = global::GUILayer.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(102, 249);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 40);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // gbCajasImpresion
            // 
            this.gbCajasImpresion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCajasImpresion.Controls.Add(this.dgvCajasImpresion);
            this.gbCajasImpresion.Location = new System.Drawing.Point(3, 6);
            this.gbCajasImpresion.Name = "gbCajasImpresion";
            this.gbCajasImpresion.Size = new System.Drawing.Size(634, 347);
            this.gbCajasImpresion.TabIndex = 0;
            this.gbCajasImpresion.TabStop = false;
            this.gbCajasImpresion.Text = "Lista de Cajas a Imprimir";
            // 
            // dgvCajasImpresion
            // 
            this.dgvCajasImpresion.AllowUserToAddRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCajasImpresion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCajasImpresion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCajasImpresion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCajasImpresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajasImpresion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCajasImpresion.EnableHeadersVisualStyles = false;
            this.dgvCajasImpresion.Location = new System.Drawing.Point(6, 19);
            this.dgvCajasImpresion.MultiSelect = false;
            this.dgvCajasImpresion.Name = "dgvCajasImpresion";
            this.dgvCajasImpresion.RowHeadersVisible = false;
            this.dgvCajasImpresion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajasImpresion.Size = new System.Drawing.Size(622, 322);
            this.dgvCajasImpresion.TabIndex = 0;
            // 
            // tcTulasImpresion
            // 
            this.tcTulasImpresion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTulasImpresion.Controls.Add(this.tpTulas);
            this.tcTulasImpresion.Controls.Add(this.tpTulasCaja);
            this.tcTulasImpresion.Controls.Add(this.tpCajasImpresion);
            this.tcTulasImpresion.Location = new System.Drawing.Point(12, 124);
            this.tcTulasImpresion.Name = "tcTulasImpresion";
            this.tcTulasImpresion.SelectedIndex = 0;
            this.tcTulasImpresion.Size = new System.Drawing.Size(651, 385);
            this.tcTulasImpresion.TabIndex = 2;
            // 
            // tpTulas
            // 
            this.tpTulas.Controls.Add(this.gbTulas);
            this.tpTulas.Location = new System.Drawing.Point(4, 22);
            this.tpTulas.Name = "tpTulas";
            this.tpTulas.Size = new System.Drawing.Size(643, 359);
            this.tpTulas.TabIndex = 2;
            this.tpTulas.Text = "Lista de Tulas";
            this.tpTulas.UseVisualStyleBackColor = true;
            // 
            // tpTulasCaja
            // 
            this.tpTulasCaja.Controls.Add(this.gbOpcionesImpresion);
            this.tpTulasCaja.Controls.Add(this.gbTulasCaja);
            this.tpTulasCaja.Location = new System.Drawing.Point(4, 22);
            this.tpTulasCaja.Name = "tpTulasCaja";
            this.tpTulasCaja.Padding = new System.Windows.Forms.Padding(3);
            this.tpTulasCaja.Size = new System.Drawing.Size(643, 359);
            this.tpTulasCaja.TabIndex = 0;
            this.tpTulasCaja.Text = "Tulas en la Caja";
            this.tpTulasCaja.UseVisualStyleBackColor = true;
            // 
            // gbOpcionesImpresion
            // 
            this.gbOpcionesImpresion.Controls.Add(this.nudCaja);
            this.gbOpcionesImpresion.Controls.Add(this.lblCaja);
            this.gbOpcionesImpresion.Controls.Add(this.lblColaborador);
            this.gbOpcionesImpresion.Controls.Add(this.cboCajero);
            this.gbOpcionesImpresion.Controls.Add(this.cboGrupo);
            this.gbOpcionesImpresion.Controls.Add(this.lblGrupo);
            this.gbOpcionesImpresion.Location = new System.Drawing.Point(6, 6);
            this.gbOpcionesImpresion.Name = "gbOpcionesImpresion";
            this.gbOpcionesImpresion.Size = new System.Drawing.Size(628, 46);
            this.gbOpcionesImpresion.TabIndex = 7;
            this.gbOpcionesImpresion.TabStop = false;
            this.gbOpcionesImpresion.Text = "Opciones de Impresión";
            // 
            // nudCaja
            // 
            this.nudCaja.Location = new System.Drawing.Point(289, 17);
            this.nudCaja.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCaja.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCaja.Name = "nudCaja";
            this.nudCaja.Size = new System.Drawing.Size(48, 20);
            this.nudCaja.TabIndex = 11;
            this.nudCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCaja.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCaja.ValueChanged += new System.EventHandler(this.nudCaja_ValueChanged);
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(259, 20);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(31, 13);
            this.lblCaja.TabIndex = 10;
            this.lblCaja.Text = "Caja:";
            // 
            // lblColaborador
            // 
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Location = new System.Drawing.Point(357, 20);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(67, 13);
            this.lblColaborador.TabIndex = 7;
            this.lblColaborador.Text = "Colaborador:";
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(429, 16);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(189, 21);
            this.cboCajero.TabIndex = 6;
            this.cboCajero.SelectedIndexChanged += new System.EventHandler(this.cboCajero_SelectedIndexChanged);
            // 
            // cboGrupo
            // 
            this.cboGrupo.Busqueda = false;
            this.cboGrupo.ListaMostrada = null;
            this.cboGrupo.Location = new System.Drawing.Point(51, 16);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(185, 21);
            this.cboGrupo.TabIndex = 1;
            this.cboGrupo.SelectedIndexChanged += new System.EventHandler(this.cboGrupo_SelectedIndexChanged);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(6, 19);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 0;
            this.lblGrupo.Text = "Grupo:";
            // 
            // gbTulasCaja
            // 
            this.gbTulasCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTulasCaja.Controls.Add(this.lblTotalTulas);
            this.gbTulasCaja.Controls.Add(this.lblTotalManifiestos);
            this.gbTulasCaja.Controls.Add(this.btnCambioGrupo);
            this.gbTulasCaja.Controls.Add(this.txtTotalManifiestos);
            this.gbTulasCaja.Controls.Add(this.btnImprimir);
            this.gbTulasCaja.Controls.Add(this.txtTotalTulas);
            this.gbTulasCaja.Controls.Add(this.dgvTulasImpresion);
            this.gbTulasCaja.Location = new System.Drawing.Point(3, 58);
            this.gbTulasCaja.Name = "gbTulasCaja";
            this.gbTulasCaja.Size = new System.Drawing.Size(634, 295);
            this.gbTulasCaja.TabIndex = 1;
            this.gbTulasCaja.TabStop = false;
            this.gbTulasCaja.Text = "Lista de Tulas en la Caja";
            // 
            // lblTotalTulas
            // 
            this.lblTotalTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTulas.AutoSize = true;
            this.lblTotalTulas.Location = new System.Drawing.Point(444, 273);
            this.lblTotalTulas.Name = "lblTotalTulas";
            this.lblTotalTulas.Size = new System.Drawing.Size(78, 13);
            this.lblTotalTulas.TabIndex = 5;
            this.lblTotalTulas.Text = "Total de Tulas:";
            // 
            // lblTotalManifiestos
            // 
            this.lblTotalManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalManifiestos.AutoSize = true;
            this.lblTotalManifiestos.Location = new System.Drawing.Point(417, 247);
            this.lblTotalManifiestos.Name = "lblTotalManifiestos";
            this.lblTotalManifiestos.Size = new System.Drawing.Size(105, 13);
            this.lblTotalManifiestos.TabIndex = 3;
            this.lblTotalManifiestos.Text = "Total de Manifiestos:";
            // 
            // btnCambioGrupo
            // 
            this.btnCambioGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCambioGrupo.FlatAppearance.BorderSize = 2;
            this.btnCambioGrupo.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnCambioGrupo.Location = new System.Drawing.Point(6, 249);
            this.btnCambioGrupo.Name = "btnCambioGrupo";
            this.btnCambioGrupo.Size = new System.Drawing.Size(90, 40);
            this.btnCambioGrupo.TabIndex = 1;
            this.btnCambioGrupo.Text = "C. Grupo";
            this.btnCambioGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambioGrupo.UseVisualStyleBackColor = false;
            this.btnCambioGrupo.Click += new System.EventHandler(this.btnCambioGrupo_Click);
            // 
            // txtTotalManifiestos
            // 
            this.txtTotalManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalManifiestos.Location = new System.Drawing.Point(528, 243);
            this.txtTotalManifiestos.Name = "txtTotalManifiestos";
            this.txtTotalManifiestos.ReadOnly = true;
            this.txtTotalManifiestos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalManifiestos.TabIndex = 4;
            this.txtTotalManifiestos.Text = "0";
            this.txtTotalManifiestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalTulas
            // 
            this.txtTotalTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalTulas.Location = new System.Drawing.Point(528, 269);
            this.txtTotalTulas.Name = "txtTotalTulas";
            this.txtTotalTulas.ReadOnly = true;
            this.txtTotalTulas.Size = new System.Drawing.Size(100, 20);
            this.txtTotalTulas.TabIndex = 6;
            this.txtTotalTulas.Text = "0";
            this.txtTotalTulas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvTulasImpresion
            // 
            this.dgvTulasImpresion.AllowUserToAddRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTulasImpresion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTulasImpresion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTulasImpresion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTulasImpresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulasImpresion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ManifiestoImpresionCodigo,
            this.ManifiestoImpresion,
            this.TulaImpresion,
            this.dataGridViewTextBoxColumn1,
            this.FechaHoraIngreso,
            this.Receptor,
            this.Transportadora});
            this.dgvTulasImpresion.EnableHeadersVisualStyles = false;
            this.dgvTulasImpresion.Location = new System.Drawing.Point(6, 19);
            this.dgvTulasImpresion.MultiSelect = false;
            this.dgvTulasImpresion.Name = "dgvTulasImpresion";
            this.dgvTulasImpresion.RowHeadersVisible = false;
            this.dgvTulasImpresion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulasImpresion.Size = new System.Drawing.Size(622, 218);
            this.dgvTulasImpresion.TabIndex = 0;
            this.dgvTulasImpresion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTulasImpresion_CellEndEdit);
            this.dgvTulasImpresion.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTulasImpresion_RowsAdded);
            this.dgvTulasImpresion.SelectionChanged += new System.EventHandler(this.dgvTulasImpresion_SelectionChanged);
            // 
            // ManifiestoImpresionCodigo
            // 
            this.ManifiestoImpresionCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ManifiestoImpresionCodigo.HeaderText = "Manifiesto";
            this.ManifiestoImpresionCodigo.Name = "ManifiestoImpresionCodigo";
            this.ManifiestoImpresionCodigo.Width = 79;
            // 
            // ManifiestoImpresion
            // 
            this.ManifiestoImpresion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ManifiestoImpresion.DataPropertyName = "Manifiesto";
            this.ManifiestoImpresion.HeaderText = "Manifiesto";
            this.ManifiestoImpresion.Name = "ManifiestoImpresion";
            this.ManifiestoImpresion.Visible = false;
            // 
            // TulaImpresion
            // 
            this.TulaImpresion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TulaImpresion.DataPropertyName = "Codigo";
            this.TulaImpresion.HeaderText = "Tula";
            this.TulaImpresion.Name = "TulaImpresion";
            this.TulaImpresion.ReadOnly = true;
            this.TulaImpresion.Width = 52;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cajero_Receptor";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cajero";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 61;
            // 
            // FechaHoraIngreso
            // 
            this.FechaHoraIngreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaHoraIngreso.DataPropertyName = "Fecha_ingreso";
            this.FechaHoraIngreso.HeaderText = "Fecha y Hora de Ingreso";
            this.FechaHoraIngreso.MinimumWidth = 150;
            this.FechaHoraIngreso.Name = "FechaHoraIngreso";
            this.FechaHoraIngreso.ReadOnly = true;
            this.FechaHoraIngreso.Width = 150;
            // 
            // Receptor
            // 
            this.Receptor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Receptor.HeaderText = "Receptor";
            this.Receptor.Name = "Receptor";
            this.Receptor.ReadOnly = true;
            this.Receptor.Width = 75;
            // 
            // Transportadora
            // 
            this.Transportadora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Transportadora.HeaderText = "Transportadora";
            this.Transportadora.Name = "Transportadora";
            this.Transportadora.ReadOnly = true;
            this.Transportadora.Width = 103;
            // 
            // tpCajasImpresion
            // 
            this.tpCajasImpresion.Controls.Add(this.gbCajasImpresion);
            this.tpCajasImpresion.Location = new System.Drawing.Point(4, 22);
            this.tpCajasImpresion.Name = "tpCajasImpresion";
            this.tpCajasImpresion.Padding = new System.Windows.Forms.Padding(3);
            this.tpCajasImpresion.Size = new System.Drawing.Size(643, 359);
            this.tpCajasImpresion.TabIndex = 1;
            this.tpCajasImpresion.Text = "Cajas a Imprimir";
            this.tpCajasImpresion.UseVisualStyleBackColor = true;
            // 
            // frmListaTulas
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(675, 567);
            this.Controls.Add(this.tcTulasImpresion);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbOpcionesListado);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaTulas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Tulas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.gbTulas.ResumeLayout(false);
            this.gbOpcionesListado.ResumeLayout(false);
            this.gbOpcionesListado.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCajasImpresion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajasImpresion)).EndInit();
            this.tcTulasImpresion.ResumeLayout(false);
            this.tpTulas.ResumeLayout(false);
            this.tpTulasCaja.ResumeLayout(false);
            this.gbOpcionesImpresion.ResumeLayout(false);
            this.gbOpcionesImpresion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaja)).EndInit();
            this.gbTulasCaja.ResumeLayout(false);
            this.gbTulasCaja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasImpresion)).EndInit();
            this.tpCajasImpresion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Drawing.Printing.PrintDocument pdDocumento;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbTulas;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbOpcionesListado;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCajasImpresion;
        private System.Windows.Forms.DataGridView dgvCajasImpresion;
        private System.Windows.Forms.TabControl tcTulasImpresion;
        private System.Windows.Forms.TabPage tpTulasCaja;
        private System.Windows.Forms.TabPage tpCajasImpresion;
        private System.Windows.Forms.GroupBox gbTulasCaja;
        private System.Windows.Forms.Label lblTotalTulas;
        private System.Windows.Forms.Label lblTotalManifiestos;
        private System.Windows.Forms.Button btnCambioGrupo;
        private System.Windows.Forms.TextBox txtTotalManifiestos;
        private System.Windows.Forms.TextBox txtTotalTulas;
        private System.Windows.Forms.DataGridView dgvTulasImpresion;
        private System.Windows.Forms.TabPage tpTulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManifiestoImpresionCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManifiestoImpresion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TulaImpresion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaHoraIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transportadora;
        private System.Windows.Forms.GroupBox gbOpcionesImpresion;
        private System.Windows.Forms.NumericUpDown nudCaja;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblColaborador;
        private ComboBoxBusqueda cboCajero;
        private ComboBoxBusqueda cboGrupo;
        private System.Windows.Forms.Label lblGrupo;
    }
}