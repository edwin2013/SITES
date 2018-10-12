namespace GUILayer
{
    partial class frmTerminacionGestiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerminacionGestiones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCoordinador = new System.Windows.Forms.Label();
            this.lblDigitador = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblCausa = new System.Windows.Forms.Label();
            this.lblCausante = new System.Windows.Forms.Label();
            this.cboCausante = new System.Windows.Forms.ComboBox();
            this.gbDatosGestion = new System.Windows.Forms.GroupBox();
            this.lblComentarioCausa = new System.Windows.Forms.Label();
            this.txtComentarioCausa = new System.Windows.Forms.TextBox();
            this.lblDetalleCliente = new System.Windows.Forms.Label();
            this.txtDetalleCliente = new System.Windows.Forms.TextBox();
            this.lblReceptor = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtPuntoVenta = new System.Windows.Forms.TextBox();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtGestion = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblGestion = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tcOpciones = new System.Windows.Forms.TabControl();
            this.tpDetalles = new System.Windows.Forms.TabPage();
            this.tpTulas = new System.Windows.Forms.TabPage();
            this.gbTulas = new System.Windows.Forms.GroupBox();
            this.lblTula = new System.Windows.Forms.Label();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpDepositos = new System.Windows.Forms.TabPage();
            this.gbDepositos = new System.Windows.Forms.GroupBox();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.dgvDepositos = new System.Windows.Forms.DataGridView();
            this.Deposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpManifiestos = new System.Windows.Forms.TabPage();
            this.gbManifiestos = new System.Windows.Forms.GroupBox();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.cboCoordinador = new GUILayer.ComboBoxBusqueda();
            this.cboEmpresa = new GUILayer.ComboBoxBusqueda();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.cboDigitador = new GUILayer.ComboBoxBusqueda();
            this.cboReceptor = new GUILayer.ComboBoxBusqueda();
            this.cboCausa = new GUILayer.ComboBoxBusqueda();
            this.cboClasificacion = new System.Windows.Forms.ComboBox();
            this.gbDatosGestion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.tcOpciones.SuspendLayout();
            this.tpDetalles.SuspendLayout();
            this.tpTulas.SuspendLayout();
            this.gbTulas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.tpDepositos.SuspendLayout();
            this.gbDepositos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).BeginInit();
            this.tpManifiestos.SuspendLayout();
            this.gbManifiestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.AutoSize = true;
            this.lblCoordinador.Location = new System.Drawing.Point(21, 77);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(67, 13);
            this.lblCoordinador.TabIndex = 4;
            this.lblCoordinador.Text = "Coordinador:";
            // 
            // lblDigitador
            // 
            this.lblDigitador.AutoSize = true;
            this.lblDigitador.Location = new System.Drawing.Point(36, 77);
            this.lblDigitador.Name = "lblDigitador";
            this.lblDigitador.Size = new System.Drawing.Size(52, 13);
            this.lblDigitador.TabIndex = 4;
            this.lblDigitador.Text = "Digitador:";
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(48, 77);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 4;
            this.lblCajero.Text = "Cajero:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(6, 77);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(82, 13);
            this.lblEmpresa.TabIndex = 4;
            this.lblEmpresa.Text = "Transportadora:";
            // 
            // lblCausa
            // 
            this.lblCausa.AutoSize = true;
            this.lblCausa.Location = new System.Drawing.Point(48, 50);
            this.lblCausa.Name = "lblCausa";
            this.lblCausa.Size = new System.Drawing.Size(40, 13);
            this.lblCausa.TabIndex = 2;
            this.lblCausa.Text = "Causa:";
            // 
            // lblCausante
            // 
            this.lblCausante.AutoSize = true;
            this.lblCausante.Location = new System.Drawing.Point(33, 23);
            this.lblCausante.Name = "lblCausante";
            this.lblCausante.Size = new System.Drawing.Size(55, 13);
            this.lblCausante.TabIndex = 0;
            this.lblCausante.Text = "Causante:";
            // 
            // cboCausante
            // 
            this.cboCausante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCausante.FormattingEnabled = true;
            this.cboCausante.Items.AddRange(new object[] {
            "Cliente",
            "Transportadora",
            "Cajero",
            "Digitador",
            "Coordinador",
            "Receptor",
            "Otro"});
            this.cboCausante.Location = new System.Drawing.Point(94, 19);
            this.cboCausante.Name = "cboCausante";
            this.cboCausante.Size = new System.Drawing.Size(294, 21);
            this.cboCausante.TabIndex = 1;
            this.cboCausante.SelectedIndexChanged += new System.EventHandler(this.cboCausante_SelectedIndexChanged);
            // 
            // gbDatosGestion
            // 
            this.gbDatosGestion.Controls.Add(this.cboClasificacion);
            this.gbDatosGestion.Controls.Add(this.lblClasificacion);
            this.gbDatosGestion.Controls.Add(this.lblComentarioCausa);
            this.gbDatosGestion.Controls.Add(this.txtComentarioCausa);
            this.gbDatosGestion.Controls.Add(this.lblDetalleCliente);
            this.gbDatosGestion.Controls.Add(this.txtDetalleCliente);
            this.gbDatosGestion.Controls.Add(this.lblReceptor);
            this.gbDatosGestion.Controls.Add(this.lblCoordinador);
            this.gbDatosGestion.Controls.Add(this.cboCausante);
            this.gbDatosGestion.Controls.Add(this.cboCoordinador);
            this.gbDatosGestion.Controls.Add(this.cboEmpresa);
            this.gbDatosGestion.Controls.Add(this.lblDigitador);
            this.gbDatosGestion.Controls.Add(this.cboCajero);
            this.gbDatosGestion.Controls.Add(this.lblEmpresa);
            this.gbDatosGestion.Controls.Add(this.cboDigitador);
            this.gbDatosGestion.Controls.Add(this.cboReceptor);
            this.gbDatosGestion.Controls.Add(this.lblCausante);
            this.gbDatosGestion.Controls.Add(this.cboCausa);
            this.gbDatosGestion.Controls.Add(this.lblCausa);
            this.gbDatosGestion.Controls.Add(this.lblCajero);
            this.gbDatosGestion.Location = new System.Drawing.Point(12, 303);
            this.gbDatosGestion.Name = "gbDatosGestion";
            this.gbDatosGestion.Size = new System.Drawing.Size(394, 189);
            this.gbDatosGestion.TabIndex = 2;
            this.gbDatosGestion.TabStop = false;
            this.gbDatosGestion.Text = "Datos del Cierre de la Gestión";
            // 
            // lblComentarioCausa
            // 
            this.lblComentarioCausa.AutoSize = true;
            this.lblComentarioCausa.Location = new System.Drawing.Point(25, 100);
            this.lblComentarioCausa.Name = "lblComentarioCausa";
            this.lblComentarioCausa.Size = new System.Drawing.Size(63, 13);
            this.lblComentarioCausa.TabIndex = 6;
            this.lblComentarioCausa.Text = "Comentario:";
            // 
            // txtComentarioCausa
            // 
            this.txtComentarioCausa.Location = new System.Drawing.Point(94, 100);
            this.txtComentarioCausa.MaxLength = 400;
            this.txtComentarioCausa.Multiline = true;
            this.txtComentarioCausa.Name = "txtComentarioCausa";
            this.txtComentarioCausa.Size = new System.Drawing.Size(294, 56);
            this.txtComentarioCausa.TabIndex = 7;
            // 
            // lblDetalleCliente
            // 
            this.lblDetalleCliente.AutoSize = true;
            this.lblDetalleCliente.Location = new System.Drawing.Point(46, 77);
            this.lblDetalleCliente.Name = "lblDetalleCliente";
            this.lblDetalleCliente.Size = new System.Drawing.Size(42, 13);
            this.lblDetalleCliente.TabIndex = 4;
            this.lblDetalleCliente.Text = "Cliente:";
            // 
            // txtDetalleCliente
            // 
            this.txtDetalleCliente.Location = new System.Drawing.Point(94, 73);
            this.txtDetalleCliente.Name = "txtDetalleCliente";
            this.txtDetalleCliente.ReadOnly = true;
            this.txtDetalleCliente.Size = new System.Drawing.Size(294, 20);
            this.txtDetalleCliente.TabIndex = 5;
            // 
            // lblReceptor
            // 
            this.lblReceptor.AutoSize = true;
            this.lblReceptor.Location = new System.Drawing.Point(34, 77);
            this.lblReceptor.Name = "lblReceptor";
            this.lblReceptor.Size = new System.Drawing.Size(54, 13);
            this.lblReceptor.TabIndex = 4;
            this.lblReceptor.Text = "Receptor:";
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
            this.pnlFondo.Size = new System.Drawing.Size(442, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(214, 498);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 3;
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
            this.btnSalir.Location = new System.Drawing.Point(310, 498);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.txtPuntoVenta);
            this.gbDatos.Controls.Add(this.lblPuntoVenta);
            this.gbDatos.Controls.Add(this.txtMonto);
            this.gbDatos.Controls.Add(this.lblMonto);
            this.gbDatos.Controls.Add(this.txtCliente);
            this.gbDatos.Controls.Add(this.txtGestion);
            this.gbDatos.Controls.Add(this.lblComentario);
            this.gbDatos.Controls.Add(this.txtComentario);
            this.gbDatos.Controls.Add(this.lblGestion);
            this.gbDatos.Controls.Add(this.lblCliente);
            this.gbDatos.Location = new System.Drawing.Point(3, 6);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(377, 197);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Gestión";
            // 
            // txtPuntoVenta
            // 
            this.txtPuntoVenta.Location = new System.Drawing.Point(87, 45);
            this.txtPuntoVenta.Name = "txtPuntoVenta";
            this.txtPuntoVenta.ReadOnly = true;
            this.txtPuntoVenta.Size = new System.Drawing.Size(284, 20);
            this.txtPuntoVenta.TabIndex = 3;
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(15, 49);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(66, 13);
            this.lblPuntoVenta.TabIndex = 2;
            this.lblPuntoVenta.Text = "P. de Venta:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(87, 171);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(284, 20);
            this.txtMonto.TabIndex = 9;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(41, 175);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 8;
            this.lblMonto.Text = "Monto:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(87, 19);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(284, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // txtGestion
            // 
            this.txtGestion.Location = new System.Drawing.Point(87, 71);
            this.txtGestion.Name = "txtGestion";
            this.txtGestion.ReadOnly = true;
            this.txtGestion.Size = new System.Drawing.Size(284, 20);
            this.txtGestion.TabIndex = 5;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(18, 97);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(63, 13);
            this.lblComentario.TabIndex = 6;
            this.lblComentario.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(87, 97);
            this.txtComentario.MaxLength = 400;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ReadOnly = true;
            this.txtComentario.Size = new System.Drawing.Size(284, 68);
            this.txtComentario.TabIndex = 7;
            // 
            // lblGestion
            // 
            this.lblGestion.AutoSize = true;
            this.lblGestion.Location = new System.Drawing.Point(35, 75);
            this.lblGestion.Name = "lblGestion";
            this.lblGestion.Size = new System.Drawing.Size(46, 13);
            this.lblGestion.TabIndex = 4;
            this.lblGestion.Text = "Gestión:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(39, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // tcOpciones
            // 
            this.tcOpciones.Controls.Add(this.tpDetalles);
            this.tcOpciones.Controls.Add(this.tpTulas);
            this.tcOpciones.Controls.Add(this.tpDepositos);
            this.tcOpciones.Controls.Add(this.tpManifiestos);
            this.tcOpciones.Location = new System.Drawing.Point(12, 62);
            this.tcOpciones.Name = "tcOpciones";
            this.tcOpciones.SelectedIndex = 0;
            this.tcOpciones.Size = new System.Drawing.Size(394, 235);
            this.tcOpciones.TabIndex = 1;
            // 
            // tpDetalles
            // 
            this.tpDetalles.Controls.Add(this.gbDatos);
            this.tpDetalles.Location = new System.Drawing.Point(4, 22);
            this.tpDetalles.Name = "tpDetalles";
            this.tpDetalles.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetalles.Size = new System.Drawing.Size(386, 209);
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
            this.tpTulas.Size = new System.Drawing.Size(386, 209);
            this.tpTulas.TabIndex = 1;
            this.tpTulas.Text = "Tulas";
            this.tpTulas.UseVisualStyleBackColor = true;
            // 
            // gbTulas
            // 
            this.gbTulas.Controls.Add(this.lblTula);
            this.gbTulas.Controls.Add(this.dgvTulas);
            this.gbTulas.Location = new System.Drawing.Point(3, 6);
            this.gbTulas.Name = "gbTulas";
            this.gbTulas.Size = new System.Drawing.Size(377, 197);
            this.gbTulas.TabIndex = 0;
            this.gbTulas.TabStop = false;
            this.gbTulas.Text = "Tulas";
            // 
            // lblTula
            // 
            this.lblTula.AutoSize = true;
            this.lblTula.Location = new System.Drawing.Point(42, 19);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTulas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTulas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTulas.EnableHeadersVisualStyles = false;
            this.dgvTulas.Location = new System.Drawing.Point(79, 19);
            this.dgvTulas.MultiSelect = false;
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.ReadOnly = true;
            this.dgvTulas.RowHeadersVisible = false;
            this.dgvTulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulas.Size = new System.Drawing.Size(292, 172);
            this.dgvTulas.TabIndex = 1;
            // 
            // Tula
            // 
            this.Tula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tula.DataPropertyName = "Codigo";
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            // 
            // tpDepositos
            // 
            this.tpDepositos.Controls.Add(this.gbDepositos);
            this.tpDepositos.Location = new System.Drawing.Point(4, 22);
            this.tpDepositos.Name = "tpDepositos";
            this.tpDepositos.Size = new System.Drawing.Size(386, 209);
            this.tpDepositos.TabIndex = 2;
            this.tpDepositos.Text = "Depositos";
            this.tpDepositos.UseVisualStyleBackColor = true;
            // 
            // gbDepositos
            // 
            this.gbDepositos.Controls.Add(this.lblDeposito);
            this.gbDepositos.Controls.Add(this.dgvDepositos);
            this.gbDepositos.Location = new System.Drawing.Point(3, 6);
            this.gbDepositos.Name = "gbDepositos";
            this.gbDepositos.Size = new System.Drawing.Size(377, 197);
            this.gbDepositos.TabIndex = 0;
            this.gbDepositos.TabStop = false;
            this.gbDepositos.Text = "Depositos";
            // 
            // lblDeposito
            // 
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Location = new System.Drawing.Point(21, 19);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepositos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepositos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Deposito});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepositos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDepositos.EnableHeadersVisualStyles = false;
            this.dgvDepositos.Location = new System.Drawing.Point(79, 19);
            this.dgvDepositos.MultiSelect = false;
            this.dgvDepositos.Name = "dgvDepositos";
            this.dgvDepositos.ReadOnly = true;
            this.dgvDepositos.RowHeadersVisible = false;
            this.dgvDepositos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepositos.Size = new System.Drawing.Size(292, 172);
            this.dgvDepositos.TabIndex = 1;
            // 
            // Deposito
            // 
            this.Deposito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Deposito.DataPropertyName = "Referencia";
            this.Deposito.HeaderText = "Deposito";
            this.Deposito.Name = "Deposito";
            this.Deposito.ReadOnly = true;
            // 
            // tpManifiestos
            // 
            this.tpManifiestos.Controls.Add(this.gbManifiestos);
            this.tpManifiestos.Location = new System.Drawing.Point(4, 22);
            this.tpManifiestos.Name = "tpManifiestos";
            this.tpManifiestos.Size = new System.Drawing.Size(386, 209);
            this.tpManifiestos.TabIndex = 3;
            this.tpManifiestos.Text = "Manifiestos";
            this.tpManifiestos.UseVisualStyleBackColor = true;
            // 
            // gbManifiestos
            // 
            this.gbManifiestos.Controls.Add(this.lblManifiesto);
            this.gbManifiestos.Controls.Add(this.dgvManifiestos);
            this.gbManifiestos.Location = new System.Drawing.Point(3, 6);
            this.gbManifiestos.Name = "gbManifiestos";
            this.gbManifiestos.Size = new System.Drawing.Size(377, 197);
            this.gbManifiestos.TabIndex = 0;
            this.gbManifiestos.TabStop = false;
            this.gbManifiestos.Text = "Manifiestos";
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(15, 19);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manifiesto});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(79, 19);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(292, 172);
            this.dgvManifiestos.TabIndex = 1;
            // 
            // Manifiesto
            // 
            this.Manifiesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Manifiesto.DataPropertyName = "COdigo";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.ReadOnly = true;
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.Location = new System.Drawing.Point(19, 166);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(69, 13);
            this.lblClasificacion.TabIndex = 8;
            this.lblClasificacion.Text = "Clasificación:";
            // 
            // cboCoordinador
            // 
            this.cboCoordinador.Busqueda = false;
            this.cboCoordinador.ListaMostrada = null;
            this.cboCoordinador.Location = new System.Drawing.Point(94, 73);
            this.cboCoordinador.Name = "cboCoordinador";
            this.cboCoordinador.Size = new System.Drawing.Size(294, 21);
            this.cboCoordinador.TabIndex = 5;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Busqueda = false;
            this.cboEmpresa.ListaMostrada = null;
            this.cboEmpresa.Location = new System.Drawing.Point(94, 73);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(294, 21);
            this.cboEmpresa.TabIndex = 5;
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(94, 73);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(294, 21);
            this.cboCajero.TabIndex = 5;
            // 
            // cboDigitador
            // 
            this.cboDigitador.Busqueda = false;
            this.cboDigitador.ListaMostrada = null;
            this.cboDigitador.Location = new System.Drawing.Point(94, 73);
            this.cboDigitador.Name = "cboDigitador";
            this.cboDigitador.Size = new System.Drawing.Size(294, 21);
            this.cboDigitador.TabIndex = 5;
            // 
            // cboReceptor
            // 
            this.cboReceptor.Busqueda = false;
            this.cboReceptor.ListaMostrada = null;
            this.cboReceptor.Location = new System.Drawing.Point(94, 73);
            this.cboReceptor.Name = "cboReceptor";
            this.cboReceptor.Size = new System.Drawing.Size(294, 21);
            this.cboReceptor.TabIndex = 5;
            // 
            // cboCausa
            // 
            this.cboCausa.Busqueda = false;
            this.cboCausa.ListaMostrada = null;
            this.cboCausa.Location = new System.Drawing.Point(94, 46);
            this.cboCausa.Name = "cboCausa";
            this.cboCausa.Size = new System.Drawing.Size(294, 21);
            this.cboCausa.TabIndex = 3;
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.FormattingEnabled = true;
            this.cboClasificacion.Items.AddRange(new object[] {
            "Consulta",
            "Reclamo"});
            this.cboClasificacion.Location = new System.Drawing.Point(94, 162);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Size = new System.Drawing.Size(294, 21);
            this.cboClasificacion.TabIndex = 9;
            // 
            // frmTerminacionGestiones
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(418, 550);
            this.Controls.Add(this.tcOpciones);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosGestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTerminacionGestiones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminar Gestión";
            this.gbDatosGestion.ResumeLayout(false);
            this.gbDatosGestion.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.tcOpciones.ResumeLayout(false);
            this.tpDetalles.ResumeLayout(false);
            this.tpTulas.ResumeLayout(false);
            this.gbTulas.ResumeLayout(false);
            this.gbTulas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.tpDepositos.ResumeLayout(false);
            this.gbDepositos.ResumeLayout(false);
            this.gbDepositos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).EndInit();
            this.tpManifiestos.ResumeLayout(false);
            this.gbManifiestos.ResumeLayout(false);
            this.gbManifiestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCoordinador;
        private ComboBoxBusqueda cboCoordinador;
        private System.Windows.Forms.Label lblDigitador;
        private ComboBoxBusqueda cboDigitador;
        private System.Windows.Forms.Label lblCajero;
        private ComboBoxBusqueda cboCajero;
        private ComboBoxBusqueda cboEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblCausa;
        private ComboBoxBusqueda cboCausa;
        private System.Windows.Forms.Label lblCausante;
        private System.Windows.Forms.ComboBox cboCausante;
        private System.Windows.Forms.GroupBox gbDatosGestion;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblGestion;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtGestion;
        private System.Windows.Forms.Label lblReceptor;
        private ComboBoxBusqueda cboReceptor;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TabControl tcOpciones;
        private System.Windows.Forms.TabPage tpDetalles;
        private System.Windows.Forms.TabPage tpTulas;
        private System.Windows.Forms.GroupBox gbTulas;
        private System.Windows.Forms.Label lblTula;
        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.TabPage tpDepositos;
        private System.Windows.Forms.GroupBox gbDepositos;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.DataGridView dgvDepositos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deposito;
        private System.Windows.Forms.TabPage tpManifiestos;
        private System.Windows.Forms.GroupBox gbManifiestos;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.Label lblDetalleCliente;
        private System.Windows.Forms.TextBox txtDetalleCliente;
        private System.Windows.Forms.TextBox txtPuntoVenta;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.Label lblComentarioCausa;
        private System.Windows.Forms.TextBox txtComentarioCausa;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.ComboBox cboClasificacion;
    }
}