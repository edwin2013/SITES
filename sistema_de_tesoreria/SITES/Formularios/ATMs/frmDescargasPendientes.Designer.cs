namespace GUILayer
{
    partial class frmDescargasPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescargasPendientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.txtMarchamoBusqueda = new System.Windows.Forms.TextBox();
            this.lblMarchamoBusqueda = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarTodas = new System.Windows.Forms.Button();
            this.gbCargasEmergencia = new System.Windows.Forms.GroupBox();
            this.dgvMontosCarga = new System.Windows.Forms.DataGridView();
            this.Denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoCartucho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroMarchamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpCargas = new System.Windows.Forms.TableLayoutPanel();
            this.gbDescargas = new System.Windows.Forms.GroupBox();
            this.dgvDescargasPendientes = new System.Windows.Forms.DataGridView();
            this.ATM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marchamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emergencia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            this.gbCargasEmergencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosCarga)).BeginInit();
            this.tlpCargas.SuspendLayout();
            this.gbDescargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescargasPendientes)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(942, 60);
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
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.txtMarchamoBusqueda);
            this.gbBusqueda.Controls.Add(this.lblMarchamoBusqueda);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Controls.Add(this.btnMostrarTodas);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 65);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(466, 65);
            this.gbBusqueda.TabIndex = 1;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Datos de Búsqueda";
            this.gbBusqueda.Enter += new System.EventHandler(this.gbBusqueda_Enter);
            // 
            // txtMarchamoBusqueda
            // 
            this.txtMarchamoBusqueda.Location = new System.Drawing.Point(72, 29);
            this.txtMarchamoBusqueda.Name = "txtMarchamoBusqueda";
            this.txtMarchamoBusqueda.Size = new System.Drawing.Size(196, 20);
            this.txtMarchamoBusqueda.TabIndex = 1;
            this.txtMarchamoBusqueda.TextChanged += new System.EventHandler(this.txtMarchamoBusqueda_TextChanged);
            // 
            // lblMarchamoBusqueda
            // 
            this.lblMarchamoBusqueda.AutoSize = true;
            this.lblMarchamoBusqueda.Location = new System.Drawing.Point(6, 33);
            this.lblMarchamoBusqueda.Name = "lblMarchamoBusqueda";
            this.lblMarchamoBusqueda.Size = new System.Drawing.Size(60, 13);
            this.lblMarchamoBusqueda.TabIndex = 0;
            this.lblMarchamoBusqueda.Text = "Marchamo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(274, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMostrarTodas
            // 
            this.btnMostrarTodas.FlatAppearance.BorderSize = 2;
            this.btnMostrarTodas.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnMostrarTodas.Location = new System.Drawing.Point(370, 19);
            this.btnMostrarTodas.Name = "btnMostrarTodas";
            this.btnMostrarTodas.Size = new System.Drawing.Size(90, 40);
            this.btnMostrarTodas.TabIndex = 3;
            this.btnMostrarTodas.Text = "Todas";
            this.btnMostrarTodas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMostrarTodas.UseVisualStyleBackColor = false;
            this.btnMostrarTodas.Click += new System.EventHandler(this.btnMostrarTodas_Click);
            // 
            // gbCargasEmergencia
            // 
            this.gbCargasEmergencia.Controls.Add(this.dgvMontosCarga);
            this.gbCargasEmergencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCargasEmergencia.Location = new System.Drawing.Point(553, 0);
            this.gbCargasEmergencia.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.gbCargasEmergencia.Name = "gbCargasEmergencia";
            this.gbCargasEmergencia.Size = new System.Drawing.Size(365, 352);
            this.gbCargasEmergencia.TabIndex = 1;
            this.gbCargasEmergencia.TabStop = false;
            this.gbCargasEmergencia.Text = "Cartuchos";
            // 
            // dgvMontosCarga
            // 
            this.dgvMontosCarga.AllowUserToAddRows = false;
            this.dgvMontosCarga.AllowUserToDeleteRows = false;
            this.dgvMontosCarga.AllowUserToOrderColumns = true;
            this.dgvMontosCarga.AllowUserToResizeColumns = false;
            this.dgvMontosCarga.AllowUserToResizeRows = false;
            this.dgvMontosCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMontosCarga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvMontosCarga.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMontosCarga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontosCarga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMontosCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontosCarga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Denominacion,
            this.MontoCartucho,
            this.Cantidad,
            this.NumeroMarchamo});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMontosCarga.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMontosCarga.EnableHeadersVisualStyles = false;
            this.dgvMontosCarga.GridColor = System.Drawing.Color.Black;
            this.dgvMontosCarga.Location = new System.Drawing.Point(6, 19);
            this.dgvMontosCarga.MultiSelect = false;
            this.dgvMontosCarga.Name = "dgvMontosCarga";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontosCarga.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMontosCarga.RowHeadersVisible = false;
            this.dgvMontosCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontosCarga.Size = new System.Drawing.Size(353, 327);
            this.dgvMontosCarga.TabIndex = 2;
            // 
            // Denominacion
            // 
            this.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Denominacion.DataPropertyName = "Denominacion";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Format = "N2";
            this.Denominacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Denominacion.HeaderText = "Denominación";
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.ReadOnly = true;
            this.Denominacion.Width = 99;
            // 
            // MontoCartucho
            // 
            this.MontoCartucho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoCartucho.DataPropertyName = "Monto_carga";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Format = "N2";
            this.MontoCartucho.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoCartucho.HeaderText = "Monto";
            this.MontoCartucho.Name = "MontoCartucho";
            this.MontoCartucho.ReadOnly = true;
            this.MontoCartucho.Width = 61;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantidad.DataPropertyName = "Cantidad_carga";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Format = "N0";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 73;
            // 
            // NumeroMarchamo
            // 
            this.NumeroMarchamo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumeroMarchamo.DataPropertyName = "Marchamo";
            this.NumeroMarchamo.HeaderText = "N. Marchamo";
            this.NumeroMarchamo.Name = "NumeroMarchamo";
            this.NumeroMarchamo.Width = 95;
            // 
            // tlpCargas
            // 
            this.tlpCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCargas.ColumnCount = 2;
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpCargas.Controls.Add(this.gbDescargas, 0, 0);
            this.tlpCargas.Controls.Add(this.gbCargasEmergencia, 1, 0);
            this.tlpCargas.Location = new System.Drawing.Point(12, 136);
            this.tlpCargas.Name = "tlpCargas";
            this.tlpCargas.RowCount = 1;
            this.tlpCargas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCargas.Size = new System.Drawing.Size(918, 352);
            this.tlpCargas.TabIndex = 2;
            // 
            // gbDescargas
            // 
            this.gbDescargas.Controls.Add(this.dgvDescargasPendientes);
            this.gbDescargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDescargas.Location = new System.Drawing.Point(0, 0);
            this.gbDescargas.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.gbDescargas.Name = "gbDescargas";
            this.gbDescargas.Size = new System.Drawing.Size(547, 352);
            this.gbDescargas.TabIndex = 0;
            this.gbDescargas.TabStop = false;
            this.gbDescargas.Text = "Descargas Pendientes";
            // 
            // dgvDescargasPendientes
            // 
            this.dgvDescargasPendientes.AllowUserToAddRows = false;
            this.dgvDescargasPendientes.AllowUserToDeleteRows = false;
            this.dgvDescargasPendientes.AllowUserToOrderColumns = true;
            this.dgvDescargasPendientes.AllowUserToResizeColumns = false;
            this.dgvDescargasPendientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDescargasPendientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDescargasPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDescargasPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDescargasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescargasPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATM,
            this.Manifiesto,
            this.Marchamo,
            this.Fecha,
            this.MontoColones,
            this.MontoDolares,
            this.Emergencia});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDescargasPendientes.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDescargasPendientes.EnableHeadersVisualStyles = false;
            this.dgvDescargasPendientes.Location = new System.Drawing.Point(6, 19);
            this.dgvDescargasPendientes.MultiSelect = false;
            this.dgvDescargasPendientes.Name = "dgvDescargasPendientes";
            this.dgvDescargasPendientes.ReadOnly = true;
            this.dgvDescargasPendientes.RowHeadersVisible = false;
            this.dgvDescargasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDescargasPendientes.Size = new System.Drawing.Size(535, 327);
            this.dgvDescargasPendientes.StandardTab = true;
            this.dgvDescargasPendientes.TabIndex = 0;
            this.dgvDescargasPendientes.SelectionChanged += new System.EventHandler(this.dgvDescargasPendientes_SelectionChanged);
            // 
            // ATM
            // 
            this.ATM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATM.DataPropertyName = "ATM";
            this.ATM.HeaderText = "ATM";
            this.ATM.Name = "ATM";
            this.ATM.ReadOnly = true;
            this.ATM.Width = 54;
            // 
            // Manifiesto
            // 
            this.Manifiesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Manifiesto.DataPropertyName = "Codigo_manifiesto";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.ReadOnly = true;
            this.Manifiesto.Width = 79;
            // 
            // Marchamo
            // 
            this.Marchamo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Marchamo.DataPropertyName = "Codigo_marchamo";
            this.Marchamo.HeaderText = "Marchamo";
            this.Marchamo.Name = "Marchamo";
            this.Marchamo.ReadOnly = true;
            this.Marchamo.Width = 81;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "Fecha_carga";
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle8;
            this.Fecha.HeaderText = "Fecha de Carga";
            this.Fecha.MinimumWidth = 110;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 110;
            // 
            // MontoColones
            // 
            this.MontoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColones.DataPropertyName = "Monto_carga_colones";
            dataGridViewCellStyle9.Format = "N2";
            this.MontoColones.DefaultCellStyle = dataGridViewCellStyle9;
            this.MontoColones.HeaderText = "C. en Colones";
            this.MontoColones.MinimumWidth = 100;
            this.MontoColones.Name = "MontoColones";
            this.MontoColones.ReadOnly = true;
            // 
            // MontoDolares
            // 
            this.MontoDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolares.DataPropertyName = "Monto_carga_dolares";
            dataGridViewCellStyle10.Format = "N2";
            this.MontoDolares.DefaultCellStyle = dataGridViewCellStyle10;
            this.MontoDolares.HeaderText = "C. en Dólares";
            this.MontoDolares.MinimumWidth = 100;
            this.MontoDolares.Name = "MontoDolares";
            this.MontoDolares.ReadOnly = true;
            // 
            // Emergencia
            // 
            this.Emergencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Emergencia.DataPropertyName = "Emergencia";
            this.Emergencia.HeaderText = "Emergencia";
            this.Emergencia.Name = "Emergencia";
            this.Emergencia.ReadOnly = true;
            this.Emergencia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Emergencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Emergencia.Width = 87;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(834, 494);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(733, 494);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(95, 40);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmDescargasPendientes
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(942, 546);
            this.Controls.Add(this.tlpCargas);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbBusqueda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 580);
            this.Name = "frmDescargasPendientes";
            this.Text = "Descargas Pendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbCargasEmergencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosCarga)).EndInit();
            this.tlpCargas.ResumeLayout(false);
            this.gbDescargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescargasPendientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMostrarTodas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtMarchamoBusqueda;
        private System.Windows.Forms.Label lblMarchamoBusqueda;
        private System.Windows.Forms.GroupBox gbCargasEmergencia;
        private System.Windows.Forms.TableLayoutPanel tlpCargas;
        private System.Windows.Forms.GroupBox gbDescargas;
        private System.Windows.Forms.DataGridView dgvDescargasPendientes;
        private System.Windows.Forms.DataGridView dgvMontosCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoCartucho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroMarchamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marchamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolares;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Emergencia;
    }
}