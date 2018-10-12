namespace GUILayer
{
    partial class frmInclusionGestiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInclusionGestiones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCliente = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.btnAgregarSucursal = new System.Windows.Forms.Button();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.cboGestion = new GUILayer.ComboBoxBusqueda();
            this.lblGestion = new System.Windows.Forms.Label();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbManifiestos = new System.Windows.Forms.GroupBox();
            this.btnAgregarManifiesto = new System.Windows.Forms.Button();
            this.btnQuitarManifiesto = new System.Windows.Forms.Button();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTulas = new System.Windows.Forms.GroupBox();
            this.btnAgregarTula = new System.Windows.Forms.Button();
            this.btnQuitarTula = new System.Windows.Forms.Button();
            this.txtTula = new System.Windows.Forms.TextBox();
            this.lblTula = new System.Windows.Forms.Label();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDepositos = new System.Windows.Forms.GroupBox();
            this.mtbDeposito = new System.Windows.Forms.MaskedTextBox();
            this.btnAgregarDeposito = new System.Windows.Forms.Button();
            this.btnQuitarDeposito = new System.Windows.Forms.Button();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.dgvDepositos = new System.Windows.Forms.DataGridView();
            this.Deposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcOpciones = new System.Windows.Forms.TabControl();
            this.tpDetalles = new System.Windows.Forms.TabPage();
            this.tpTulas = new System.Windows.Forms.TabPage();
            this.tpDepositos = new System.Windows.Forms.TabPage();
            this.tpManifiestos = new System.Windows.Forms.TabPage();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbManifiestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.gbTulas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.gbDepositos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).BeginInit();
            this.tcOpciones.SuspendLayout();
            this.tpDetalles.SuspendLayout();
            this.tpTulas.SuspendLayout();
            this.tpDepositos.SuspendLayout();
            this.tpManifiestos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(45, 22);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.btnAgregarSucursal);
            this.gbDatos.Controls.Add(this.cboPuntoVenta);
            this.gbDatos.Controls.Add(this.lblPuntoVenta);
            this.gbDatos.Controls.Add(this.nudMonto);
            this.gbDatos.Controls.Add(this.lblMonto);
            this.gbDatos.Controls.Add(this.lblComentario);
            this.gbDatos.Controls.Add(this.txtComentario);
            this.gbDatos.Controls.Add(this.cboGestion);
            this.gbDatos.Controls.Add(this.lblGestion);
            this.gbDatos.Controls.Add(this.cboCliente);
            this.gbDatos.Controls.Add(this.lblCliente);
            this.gbDatos.Location = new System.Drawing.Point(3, 6);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(439, 235);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Gestión";
            // 
            // btnAgregarSucursal
            // 
            this.btnAgregarSucursal.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarSucursal.Enabled = false;
            this.btnAgregarSucursal.FlatAppearance.BorderSize = 2;
            this.btnAgregarSucursal.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarSucursal.Location = new System.Drawing.Point(343, 46);
            this.btnAgregarSucursal.Name = "btnAgregarSucursal";
            this.btnAgregarSucursal.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarSucursal.TabIndex = 4;
            this.btnAgregarSucursal.Text = "Agregar";
            this.btnAgregarSucursal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarSucursal.UseVisualStyleBackColor = false;
            this.btnAgregarSucursal.Click += new System.EventHandler(this.btnAgregarSucursal_Click);
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = false;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(93, 56);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(244, 21);
            this.cboPuntoVenta.TabIndex = 3;
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(3, 60);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(84, 13);
            this.lblPuntoVenta.TabIndex = 2;
            this.lblPuntoVenta.Text = "Punto de Venta:";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Location = new System.Drawing.Point(93, 209);
            this.nudMonto.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(81, 20);
            this.nudMonto.TabIndex = 10;
            this.nudMonto.ThousandsSeparator = true;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(47, 213);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "Monto:";
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(24, 119);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(63, 13);
            this.lblComentario.TabIndex = 7;
            this.lblComentario.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(93, 119);
            this.txtComentario.MaxLength = 400;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(340, 84);
            this.txtComentario.TabIndex = 8;
            // 
            // cboGestion
            // 
            this.cboGestion.Busqueda = false;
            this.cboGestion.ListaMostrada = null;
            this.cboGestion.Location = new System.Drawing.Point(93, 92);
            this.cboGestion.Name = "cboGestion";
            this.cboGestion.Size = new System.Drawing.Size(340, 21);
            this.cboGestion.TabIndex = 6;
            // 
            // lblGestion
            // 
            this.lblGestion.AutoSize = true;
            this.lblGestion.Location = new System.Drawing.Point(41, 96);
            this.lblGestion.Name = "lblGestion";
            this.lblGestion.Size = new System.Drawing.Size(46, 13);
            this.lblGestion.TabIndex = 5;
            this.lblGestion.Text = "Gestión:";
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(93, 19);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(340, 21);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
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
            this.pnlFondo.Size = new System.Drawing.Size(510, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(388, 45);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbManifiestos
            // 
            this.gbManifiestos.Controls.Add(this.btnAgregarManifiesto);
            this.gbManifiestos.Controls.Add(this.btnQuitarManifiesto);
            this.gbManifiestos.Controls.Add(this.txtManifiesto);
            this.gbManifiestos.Controls.Add(this.lblManifiesto);
            this.gbManifiestos.Controls.Add(this.dgvManifiestos);
            this.gbManifiestos.Location = new System.Drawing.Point(3, 6);
            this.gbManifiestos.Name = "gbManifiestos";
            this.gbManifiestos.Size = new System.Drawing.Size(439, 235);
            this.gbManifiestos.TabIndex = 0;
            this.gbManifiestos.TabStop = false;
            this.gbManifiestos.Text = "Manifiestos";
            // 
            // btnAgregarManifiesto
            // 
            this.btnAgregarManifiesto.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarManifiesto.Enabled = false;
            this.btnAgregarManifiesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarManifiesto.Location = new System.Drawing.Point(403, 19);
            this.btnAgregarManifiesto.Name = "btnAgregarManifiesto";
            this.btnAgregarManifiesto.Size = new System.Drawing.Size(30, 30);
            this.btnAgregarManifiesto.TabIndex = 2;
            this.btnAgregarManifiesto.Text = "+";
            this.btnAgregarManifiesto.UseVisualStyleBackColor = false;
            this.btnAgregarManifiesto.Click += new System.EventHandler(this.btnAgregarManifiesto_Click);
            // 
            // btnQuitarManifiesto
            // 
            this.btnQuitarManifiesto.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarManifiesto.Enabled = false;
            this.btnQuitarManifiesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarManifiesto.Location = new System.Drawing.Point(403, 55);
            this.btnQuitarManifiesto.Name = "btnQuitarManifiesto";
            this.btnQuitarManifiesto.Size = new System.Drawing.Size(30, 30);
            this.btnQuitarManifiesto.TabIndex = 4;
            this.btnQuitarManifiesto.Text = "-";
            this.btnQuitarManifiesto.UseVisualStyleBackColor = false;
            this.btnQuitarManifiesto.Click += new System.EventHandler(this.btnQuitarManifiesto_Click);
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.Location = new System.Drawing.Point(75, 24);
            this.txtManifiesto.MaxLength = 15;
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.Size = new System.Drawing.Size(322, 20);
            this.txtManifiesto.TabIndex = 1;
            this.txtManifiesto.TextChanged += new System.EventHandler(this.txtManifiesto_TextChanged);
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(11, 28);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManifiesto.TabIndex = 0;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToOrderColumns = true;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manifiesto});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(75, 55);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(322, 174);
            this.dgvManifiestos.TabIndex = 3;
            this.dgvManifiestos.SelectionChanged += new System.EventHandler(this.dgvManifiestos_SelectionChanged);
            // 
            // Manifiesto
            // 
            this.Manifiesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Manifiesto.DataPropertyName = "COdigo";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.ReadOnly = true;
            // 
            // gbTulas
            // 
            this.gbTulas.Controls.Add(this.btnAgregarTula);
            this.gbTulas.Controls.Add(this.btnQuitarTula);
            this.gbTulas.Controls.Add(this.txtTula);
            this.gbTulas.Controls.Add(this.lblTula);
            this.gbTulas.Controls.Add(this.dgvTulas);
            this.gbTulas.Location = new System.Drawing.Point(3, 6);
            this.gbTulas.Name = "gbTulas";
            this.gbTulas.Size = new System.Drawing.Size(439, 235);
            this.gbTulas.TabIndex = 0;
            this.gbTulas.TabStop = false;
            this.gbTulas.Text = "Tulas";
            // 
            // btnAgregarTula
            // 
            this.btnAgregarTula.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarTula.Enabled = false;
            this.btnAgregarTula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTula.Location = new System.Drawing.Point(403, 19);
            this.btnAgregarTula.Name = "btnAgregarTula";
            this.btnAgregarTula.Size = new System.Drawing.Size(30, 30);
            this.btnAgregarTula.TabIndex = 2;
            this.btnAgregarTula.Text = "+";
            this.btnAgregarTula.UseVisualStyleBackColor = false;
            this.btnAgregarTula.Click += new System.EventHandler(this.btnAgregarTula_Click);
            // 
            // btnQuitarTula
            // 
            this.btnQuitarTula.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarTula.Enabled = false;
            this.btnQuitarTula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarTula.Location = new System.Drawing.Point(403, 55);
            this.btnQuitarTula.Name = "btnQuitarTula";
            this.btnQuitarTula.Size = new System.Drawing.Size(30, 30);
            this.btnQuitarTula.TabIndex = 4;
            this.btnQuitarTula.Text = "-";
            this.btnQuitarTula.UseVisualStyleBackColor = false;
            this.btnQuitarTula.Click += new System.EventHandler(this.btnQuitarTula_Click);
            // 
            // txtTula
            // 
            this.txtTula.Location = new System.Drawing.Point(75, 24);
            this.txtTula.MaxLength = 15;
            this.txtTula.Name = "txtTula";
            this.txtTula.Size = new System.Drawing.Size(322, 20);
            this.txtTula.TabIndex = 1;
            this.txtTula.TextChanged += new System.EventHandler(this.txtTula_TextChanged);
            // 
            // lblTula
            // 
            this.lblTula.AutoSize = true;
            this.lblTula.Location = new System.Drawing.Point(38, 28);
            this.lblTula.Name = "lblTula";
            this.lblTula.Size = new System.Drawing.Size(31, 13);
            this.lblTula.TabIndex = 0;
            this.lblTula.Text = "Tula:";
            // 
            // dgvTulas
            // 
            this.dgvTulas.AllowUserToAddRows = false;
            this.dgvTulas.AllowUserToDeleteRows = false;
            this.dgvTulas.AllowUserToOrderColumns = true;
            this.dgvTulas.AllowUserToResizeColumns = false;
            this.dgvTulas.AllowUserToResizeRows = false;
            this.dgvTulas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTulas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTulas.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvTulas.EnableHeadersVisualStyles = false;
            this.dgvTulas.Location = new System.Drawing.Point(75, 55);
            this.dgvTulas.MultiSelect = false;
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.ReadOnly = true;
            this.dgvTulas.RowHeadersVisible = false;
            this.dgvTulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulas.Size = new System.Drawing.Size(322, 174);
            this.dgvTulas.TabIndex = 3;
            this.dgvTulas.SelectionChanged += new System.EventHandler(this.dgvTulas_SelectionChanged);
            // 
            // Tula
            // 
            this.Tula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tula.DataPropertyName = "Codigo";
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            // 
            // gbDepositos
            // 
            this.gbDepositos.Controls.Add(this.mtbDeposito);
            this.gbDepositos.Controls.Add(this.btnAgregarDeposito);
            this.gbDepositos.Controls.Add(this.btnQuitarDeposito);
            this.gbDepositos.Controls.Add(this.lblDeposito);
            this.gbDepositos.Controls.Add(this.dgvDepositos);
            this.gbDepositos.Location = new System.Drawing.Point(3, 6);
            this.gbDepositos.Name = "gbDepositos";
            this.gbDepositos.Size = new System.Drawing.Size(439, 235);
            this.gbDepositos.TabIndex = 0;
            this.gbDepositos.TabStop = false;
            this.gbDepositos.Text = "Depositos";
            // 
            // mtbDeposito
            // 
            this.mtbDeposito.Location = new System.Drawing.Point(75, 24);
            this.mtbDeposito.Mask = "9999999999";
            this.mtbDeposito.Name = "mtbDeposito";
            this.mtbDeposito.Size = new System.Drawing.Size(322, 20);
            this.mtbDeposito.TabIndex = 5;
            this.mtbDeposito.TextChanged += new System.EventHandler(this.mtbDeposito_TextChanged);
            // 
            // btnAgregarDeposito
            // 
            this.btnAgregarDeposito.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarDeposito.Enabled = false;
            this.btnAgregarDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDeposito.Location = new System.Drawing.Point(403, 19);
            this.btnAgregarDeposito.Name = "btnAgregarDeposito";
            this.btnAgregarDeposito.Size = new System.Drawing.Size(30, 30);
            this.btnAgregarDeposito.TabIndex = 2;
            this.btnAgregarDeposito.Text = "+";
            this.btnAgregarDeposito.UseVisualStyleBackColor = false;
            this.btnAgregarDeposito.Click += new System.EventHandler(this.btnAgregarDeposito_Click);
            // 
            // btnQuitarDeposito
            // 
            this.btnQuitarDeposito.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarDeposito.Enabled = false;
            this.btnQuitarDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarDeposito.Location = new System.Drawing.Point(403, 55);
            this.btnQuitarDeposito.Name = "btnQuitarDeposito";
            this.btnQuitarDeposito.Size = new System.Drawing.Size(30, 30);
            this.btnQuitarDeposito.TabIndex = 4;
            this.btnQuitarDeposito.Text = "-";
            this.btnQuitarDeposito.UseVisualStyleBackColor = false;
            this.btnQuitarDeposito.Click += new System.EventHandler(this.btnQuitarDeposito_Click);
            // 
            // lblDeposito
            // 
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Location = new System.Drawing.Point(17, 28);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(52, 13);
            this.lblDeposito.TabIndex = 0;
            this.lblDeposito.Text = "Deposito:";
            // 
            // dgvDepositos
            // 
            this.dgvDepositos.AllowUserToAddRows = false;
            this.dgvDepositos.AllowUserToDeleteRows = false;
            this.dgvDepositos.AllowUserToOrderColumns = true;
            this.dgvDepositos.AllowUserToResizeColumns = false;
            this.dgvDepositos.AllowUserToResizeRows = false;
            this.dgvDepositos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepositos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepositos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Deposito});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepositos.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDepositos.EnableHeadersVisualStyles = false;
            this.dgvDepositos.Location = new System.Drawing.Point(75, 55);
            this.dgvDepositos.MultiSelect = false;
            this.dgvDepositos.Name = "dgvDepositos";
            this.dgvDepositos.ReadOnly = true;
            this.dgvDepositos.RowHeadersVisible = false;
            this.dgvDepositos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepositos.Size = new System.Drawing.Size(322, 174);
            this.dgvDepositos.TabIndex = 3;
            this.dgvDepositos.SelectionChanged += new System.EventHandler(this.dgvDepositos_SelectionChanged);
            // 
            // Deposito
            // 
            this.Deposito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Deposito.DataPropertyName = "Referencia";
            this.Deposito.HeaderText = "Deposito";
            this.Deposito.Name = "Deposito";
            this.Deposito.ReadOnly = true;
            // 
            // tcOpciones
            // 
            this.tcOpciones.Controls.Add(this.tpDetalles);
            this.tcOpciones.Controls.Add(this.tpTulas);
            this.tcOpciones.Controls.Add(this.tpDepositos);
            this.tcOpciones.Controls.Add(this.tpManifiestos);
            this.tcOpciones.Location = new System.Drawing.Point(12, 63);
            this.tcOpciones.Name = "tcOpciones";
            this.tcOpciones.SelectedIndex = 0;
            this.tcOpciones.Size = new System.Drawing.Size(456, 270);
            this.tcOpciones.TabIndex = 1;
            // 
            // tpDetalles
            // 
            this.tpDetalles.Controls.Add(this.gbDatos);
            this.tpDetalles.Location = new System.Drawing.Point(4, 22);
            this.tpDetalles.Name = "tpDetalles";
            this.tpDetalles.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetalles.Size = new System.Drawing.Size(448, 244);
            this.tpDetalles.TabIndex = 0;
            this.tpDetalles.Text = "Detalles";
            this.tpDetalles.UseVisualStyleBackColor = true;
            // 
            // tpTulas
            // 
            this.tpTulas.Controls.Add(this.gbTulas);
            this.tpTulas.Location = new System.Drawing.Point(4, 22);
            this.tpTulas.Name = "tpTulas";
            this.tpTulas.Padding = new System.Windows.Forms.Padding(3);
            this.tpTulas.Size = new System.Drawing.Size(448, 244);
            this.tpTulas.TabIndex = 1;
            this.tpTulas.Text = "Tulas";
            this.tpTulas.UseVisualStyleBackColor = true;
            // 
            // tpDepositos
            // 
            this.tpDepositos.Controls.Add(this.gbDepositos);
            this.tpDepositos.Location = new System.Drawing.Point(4, 22);
            this.tpDepositos.Name = "tpDepositos";
            this.tpDepositos.Size = new System.Drawing.Size(448, 244);
            this.tpDepositos.TabIndex = 2;
            this.tpDepositos.Text = "Depositos";
            this.tpDepositos.UseVisualStyleBackColor = true;
            // 
            // tpManifiestos
            // 
            this.tpManifiestos.Controls.Add(this.gbManifiestos);
            this.tpManifiestos.Location = new System.Drawing.Point(4, 22);
            this.tpManifiestos.Name = "tpManifiestos";
            this.tpManifiestos.Size = new System.Drawing.Size(448, 244);
            this.tpManifiestos.TabIndex = 3;
            this.tpManifiestos.Text = "Manifiestos";
            this.tpManifiestos.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(272, 339);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(368, 339);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmInclusionGestiones
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(480, 391);
            this.Controls.Add(this.tcOpciones);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInclusionGestiones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Gestiones";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbManifiestos.ResumeLayout(false);
            this.gbManifiestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.gbTulas.ResumeLayout(false);
            this.gbTulas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.gbDepositos.ResumeLayout(false);
            this.gbDepositos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).EndInit();
            this.tcOpciones.ResumeLayout(false);
            this.tpDetalles.ResumeLayout(false);
            this.tpTulas.ResumeLayout(false);
            this.tpDepositos.ResumeLayout(false);
            this.tpManifiestos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private ComboBoxBusqueda cboGestion;
        private System.Windows.Forms.Label lblGestion;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.GroupBox gbManifiestos;
        private System.Windows.Forms.Button btnAgregarManifiesto;
        private System.Windows.Forms.Button btnQuitarManifiesto;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.GroupBox gbTulas;
        private System.Windows.Forms.Button btnAgregarTula;
        private System.Windows.Forms.Button btnQuitarTula;
        private System.Windows.Forms.TextBox txtTula;
        private System.Windows.Forms.Label lblTula;
        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Windows.Forms.GroupBox gbDepositos;
        private System.Windows.Forms.Button btnAgregarDeposito;
        private System.Windows.Forms.Button btnQuitarDeposito;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.DataGridView dgvDepositos;
        private System.Windows.Forms.TabControl tcOpciones;
        private System.Windows.Forms.TabPage tpDetalles;
        private System.Windows.Forms.TabPage tpTulas;
        private System.Windows.Forms.TabPage tpDepositos;
        private System.Windows.Forms.TabPage tpManifiestos;
        private System.Windows.Forms.TextBox txtManifiesto;
        private System.Windows.Forms.MaskedTextBox mtbDeposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deposito;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.Button btnAgregarSucursal;
    }
}