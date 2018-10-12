namespace GUILayer
{
    partial class frmMantenimientoColaboradores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoColaboradores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtClaveCEF = new System.Windows.Forms.TextBox();
            this.chkAdministradorGeneral = new System.Windows.Forms.CheckBox();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.cboAreas = new System.Windows.Forms.ComboBox();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.gbPuestos = new System.Windows.Forms.GroupBox();
            this.clbPuestos = new System.Windows.Forms.CheckedListBox();
            this.gbContacto = new System.Windows.Forms.GroupBox();
            this.btnAgregarTelefono = new System.Windows.Forms.Button();
            this.btnQuitarTelefono = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblTelefonos = new System.Windows.Forms.Label();
            this.dgvTelefonos = new System.Windows.Forms.DataGridView();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPerfiles = new System.Windows.Forms.GroupBox();
            this.clbPerfiles = new System.Windows.Forms.CheckedListBox();
            this.pdOpcionesImpresion = new System.Windows.Forms.PrintDialog();
            this.pdCodigo = new System.Drawing.Printing.PrintDocument();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAsignarCodigo = new System.Windows.Forms.Button();
            this.gbEmail = new System.Windows.Forms.GroupBox();
            this.txtServidorCorreo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBaseCorreo = new System.Windows.Forms.TextBox();
            this.lblBaseDatos = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbPuestosColaborador = new System.Windows.Forms.CheckedListBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.gbPuestos.SuspendLayout();
            this.gbContacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonos)).BeginInit();
            this.gbPerfiles.SuspendLayout();
            this.gbEmail.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlFondo.Size = new System.Drawing.Size(1066, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(429, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(52, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(105, 19);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(247, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(31, 101);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(73, 13);
            this.lblIdentificacion.TabIndex = 6;
            this.lblIdentificacion.Text = "Identificación:";
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(105, 97);
            this.txtIdentificador.MaxLength = 15;
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(247, 20);
            this.txtIdentificador.TabIndex = 7;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblCorreo);
            this.gbDatos.Controls.Add(this.txtClaveCEF);
            this.gbDatos.Controls.Add(this.chkAdministradorGeneral);
            this.gbDatos.Controls.Add(this.dtpFechaIngreso);
            this.gbDatos.Controls.Add(this.lblFechaIngreso);
            this.gbDatos.Controls.Add(this.lblCuenta);
            this.gbDatos.Controls.Add(this.lblArea);
            this.gbDatos.Controls.Add(this.cboAreas);
            this.gbDatos.Controls.Add(this.txtIdentificador);
            this.gbDatos.Controls.Add(this.txtCuenta);
            this.gbDatos.Controls.Add(this.txtSegundoApellido);
            this.gbDatos.Controls.Add(this.lblIdentificacion);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.txtPrimerApellido);
            this.gbDatos.Controls.Add(this.lblSegundoApellido);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Controls.Add(this.lblPrimerApellido);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(358, 271);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Colaborador";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(42, 152);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(57, 13);
            this.lblCorreo.TabIndex = 15;
            this.lblCorreo.Text = "Clave CEF";
            // 
            // txtClaveCEF
            // 
            this.txtClaveCEF.Location = new System.Drawing.Point(105, 149);
            this.txtClaveCEF.Name = "txtClaveCEF";
            this.txtClaveCEF.Size = new System.Drawing.Size(247, 20);
            this.txtClaveCEF.TabIndex = 16;
            // 
            // chkAdministradorGeneral
            // 
            this.chkAdministradorGeneral.AutoSize = true;
            this.chkAdministradorGeneral.Location = new System.Drawing.Point(223, 228);
            this.chkAdministradorGeneral.Name = "chkAdministradorGeneral";
            this.chkAdministradorGeneral.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAdministradorGeneral.Size = new System.Drawing.Size(129, 17);
            this.chkAdministradorGeneral.TabIndex = 14;
            this.chkAdministradorGeneral.Text = "Administrador General";
            this.chkAdministradorGeneral.UseVisualStyleBackColor = true;
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Location = new System.Drawing.Point(105, 202);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(247, 20);
            this.dtpFechaIngreso.TabIndex = 13;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Location = new System.Drawing.Point(6, 206);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(93, 13);
            this.lblFechaIngreso.TabIndex = 12;
            this.lblFechaIngreso.Text = "Fecha de Ingreso:";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(52, 126);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(44, 13);
            this.lblCuenta.TabIndex = 8;
            this.lblCuenta.Text = "Cuenta:";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(67, 179);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 10;
            this.lblArea.Text = "Área:";
            // 
            // cboAreas
            // 
            this.cboAreas.Items.AddRange(new object[] {
            "Centro de Efectivo",
            "Boveda",
            "ATM\'s",
            "Tesorería",
            "Blindados",
            "Sucursal",
            "Caja Empresarial"});
            this.cboAreas.Location = new System.Drawing.Point(105, 175);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Size = new System.Drawing.Size(247, 21);
            this.cboAreas.TabIndex = 11;
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(105, 123);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(247, 20);
            this.txtCuenta.TabIndex = 9;
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.Location = new System.Drawing.Point(105, 71);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(247, 20);
            this.txtSegundoApellido.TabIndex = 5;
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Location = new System.Drawing.Point(105, 45);
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(247, 20);
            this.txtPrimerApellido.TabIndex = 3;
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Location = new System.Drawing.Point(6, 75);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(93, 13);
            this.lblSegundoApellido.TabIndex = 4;
            this.lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // lblPrimerApellido
            // 
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Location = new System.Drawing.Point(20, 49);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(79, 13);
            this.lblPrimerApellido.TabIndex = 2;
            this.lblPrimerApellido.Text = "Primer Apellido:";
            // 
            // gbPuestos
            // 
            this.gbPuestos.Controls.Add(this.clbPuestos);
            this.gbPuestos.Location = new System.Drawing.Point(854, 63);
            this.gbPuestos.Name = "gbPuestos";
            this.gbPuestos.Size = new System.Drawing.Size(171, 209);
            this.gbPuestos.TabIndex = 3;
            this.gbPuestos.TabStop = false;
            this.gbPuestos.Text = "Roles del Colaborador";
            this.gbPuestos.Visible = false;
            // 
            // clbPuestos
            // 
            this.clbPuestos.ColumnWidth = 150;
            this.clbPuestos.FormattingEnabled = true;
            this.clbPuestos.Items.AddRange(new object[] {
            "Cajero 1",
            "Cajero 2",
            "Coordinador",
            "Receptor",
            "Separador",
            "Digitador",
            "Supervisor",
            "Oficial de Cámara",
            "Administrador",
            "Coordinador Operativo",
            "Control Interno",
            "Analista",
            "Oficial de Transporte de Valores",
            "Custodio",
            "Portavalor",
            "Programador",
            "Chofer",
            "Ingeniero",
            "Backup de Blindados",
            "Patio de Maniobras",
            "Asistente",
            "Tesorero",
            "Gerente",
            "Coordinador Sucursal",
            "Cajero 3",
            "Operador de Monitoreo"});
            this.clbPuestos.Location = new System.Drawing.Point(6, 19);
            this.clbPuestos.MultiColumn = true;
            this.clbPuestos.Name = "clbPuestos";
            this.clbPuestos.Size = new System.Drawing.Size(159, 184);
            this.clbPuestos.TabIndex = 0;
            this.clbPuestos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbPuestos_ItemCheck);
            // 
            // gbContacto
            // 
            this.gbContacto.Controls.Add(this.btnAgregarTelefono);
            this.gbContacto.Controls.Add(this.btnQuitarTelefono);
            this.gbContacto.Controls.Add(this.txtNumero);
            this.gbContacto.Controls.Add(this.lblTelefonos);
            this.gbContacto.Controls.Add(this.dgvTelefonos);
            this.gbContacto.Location = new System.Drawing.Point(12, 352);
            this.gbContacto.Name = "gbContacto";
            this.gbContacto.Size = new System.Drawing.Size(358, 134);
            this.gbContacto.TabIndex = 2;
            this.gbContacto.TabStop = false;
            this.gbContacto.Text = "Contacto";
            this.gbContacto.Enter += new System.EventHandler(this.gbContacto_Enter);
            // 
            // btnAgregarTelefono
            // 
            this.btnAgregarTelefono.Enabled = false;
            this.btnAgregarTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTelefono.Location = new System.Drawing.Point(322, 19);
            this.btnAgregarTelefono.Name = "btnAgregarTelefono";
            this.btnAgregarTelefono.Size = new System.Drawing.Size(30, 30);
            this.btnAgregarTelefono.TabIndex = 2;
            this.btnAgregarTelefono.Text = "+";
            this.btnAgregarTelefono.UseVisualStyleBackColor = false;
            this.btnAgregarTelefono.Click += new System.EventHandler(this.btnAgregarTelefono_Click);
            // 
            // btnQuitarTelefono
            // 
            this.btnQuitarTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarTelefono.Location = new System.Drawing.Point(322, 55);
            this.btnQuitarTelefono.Name = "btnQuitarTelefono";
            this.btnQuitarTelefono.Size = new System.Drawing.Size(30, 30);
            this.btnQuitarTelefono.TabIndex = 4;
            this.btnQuitarTelefono.Text = "-";
            this.btnQuitarTelefono.UseVisualStyleBackColor = false;
            this.btnQuitarTelefono.Click += new System.EventHandler(this.btnQuitarTelefono_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(105, 24);
            this.txtNumero.MaxLength = 15;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(211, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // lblTelefonos
            // 
            this.lblTelefonos.AutoSize = true;
            this.lblTelefonos.Location = new System.Drawing.Point(42, 28);
            this.lblTelefonos.Name = "lblTelefonos";
            this.lblTelefonos.Size = new System.Drawing.Size(57, 13);
            this.lblTelefonos.TabIndex = 0;
            this.lblTelefonos.Text = "Telefonos:";
            // 
            // dgvTelefonos
            // 
            this.dgvTelefonos.AllowUserToAddRows = false;
            this.dgvTelefonos.AllowUserToDeleteRows = false;
            this.dgvTelefonos.AllowUserToOrderColumns = true;
            this.dgvTelefonos.AllowUserToResizeColumns = false;
            this.dgvTelefonos.AllowUserToResizeRows = false;
            this.dgvTelefonos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTelefonos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelefonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Telefono});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTelefonos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTelefonos.EnableHeadersVisualStyles = false;
            this.dgvTelefonos.Location = new System.Drawing.Point(105, 55);
            this.dgvTelefonos.MultiSelect = false;
            this.dgvTelefonos.Name = "dgvTelefonos";
            this.dgvTelefonos.ReadOnly = true;
            this.dgvTelefonos.RowHeadersVisible = false;
            this.dgvTelefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTelefonos.Size = new System.Drawing.Size(211, 73);
            this.dgvTelefonos.TabIndex = 3;
            this.dgvTelefonos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTelefonos_RowsAdded);
            this.dgvTelefonos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTelefonos_RowsRemoved);
            // 
            // Telefono
            // 
            this.Telefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Telefono.DataPropertyName = "Numero";
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // gbPerfiles
            // 
            this.gbPerfiles.Controls.Add(this.clbPerfiles);
            this.gbPerfiles.Location = new System.Drawing.Point(988, 291);
            this.gbPerfiles.Name = "gbPerfiles";
            this.gbPerfiles.Size = new System.Drawing.Size(98, 209);
            this.gbPerfiles.TabIndex = 4;
            this.gbPerfiles.TabStop = false;
            this.gbPerfiles.Text = "Perfiles de Acceso";
            this.gbPerfiles.Visible = false;
            // 
            // clbPerfiles
            // 
            this.clbPerfiles.FormattingEnabled = true;
            this.clbPerfiles.Location = new System.Drawing.Point(6, 19);
            this.clbPerfiles.Name = "clbPerfiles";
            this.clbPerfiles.Size = new System.Drawing.Size(86, 184);
            this.clbPerfiles.TabIndex = 0;
            // 
            // pdOpcionesImpresion
            // 
            this.pdOpcionesImpresion.UseEXDialog = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(854, 366);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 5;
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
            this.btnSalir.Location = new System.Drawing.Point(854, 421);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAsignarCodigo
            // 
            this.btnAsignarCodigo.Image = global::GUILayer.Properties.Resources.imprimir;
            this.btnAsignarCodigo.Location = new System.Drawing.Point(845, 310);
            this.btnAsignarCodigo.Name = "btnAsignarCodigo";
            this.btnAsignarCodigo.Size = new System.Drawing.Size(122, 40);
            this.btnAsignarCodigo.TabIndex = 8;
            this.btnAsignarCodigo.Text = "Asignar Código";
            this.btnAsignarCodigo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignarCodigo.UseVisualStyleBackColor = false;
            this.btnAsignarCodigo.Click += new System.EventHandler(this.btnAsignarCodigo_Click);
            // 
            // gbEmail
            // 
            this.gbEmail.Controls.Add(this.txtServidorCorreo);
            this.gbEmail.Controls.Add(this.label2);
            this.gbEmail.Controls.Add(this.txtBaseCorreo);
            this.gbEmail.Controls.Add(this.lblBaseDatos);
            this.gbEmail.Controls.Add(this.txtEmail);
            this.gbEmail.Controls.Add(this.lblEmail);
            this.gbEmail.Location = new System.Drawing.Point(382, 291);
            this.gbEmail.Name = "gbEmail";
            this.gbEmail.Size = new System.Drawing.Size(446, 189);
            this.gbEmail.TabIndex = 9;
            this.gbEmail.TabStop = false;
            this.gbEmail.Text = "Email";
            // 
            // txtServidorCorreo
            // 
            this.txtServidorCorreo.Location = new System.Drawing.Point(111, 123);
            this.txtServidorCorreo.MaxLength = 15;
            this.txtServidorCorreo.Name = "txtServidorCorreo";
            this.txtServidorCorreo.Size = new System.Drawing.Size(285, 20);
            this.txtServidorCorreo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Servidor:";
            // 
            // txtBaseCorreo
            // 
            this.txtBaseCorreo.Location = new System.Drawing.Point(111, 86);
            this.txtBaseCorreo.MaxLength = 15;
            this.txtBaseCorreo.Name = "txtBaseCorreo";
            this.txtBaseCorreo.Size = new System.Drawing.Size(285, 20);
            this.txtBaseCorreo.TabIndex = 3;
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.AutoSize = true;
            this.lblBaseDatos.Location = new System.Drawing.Point(27, 89);
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(78, 13);
            this.lblBaseDatos.TabIndex = 2;
            this.lblBaseDatos.Text = "Base de datos:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(111, 50);
            this.txtEmail.MaxLength = 15;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(47, 53);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbPuestosColaborador);
            this.groupBox1.Location = new System.Drawing.Point(382, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 209);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puesto del Colaborador";
            // 
            // clbPuestosColaborador
            // 
            this.clbPuestosColaborador.ColumnWidth = 150;
            this.clbPuestosColaborador.FormattingEnabled = true;
            this.clbPuestosColaborador.Location = new System.Drawing.Point(6, 19);
            this.clbPuestosColaborador.MultiColumn = true;
            this.clbPuestosColaborador.Name = "clbPuestosColaborador";
            this.clbPuestosColaborador.Size = new System.Drawing.Size(440, 184);
            this.clbPuestosColaborador.TabIndex = 0;
            this.clbPuestosColaborador.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbPuestosColaborador_ItemCheck);
            // 
            // frmMantenimientoColaboradores
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1047, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbEmail);
            this.Controls.Add(this.btnAsignarCodigo);
            this.Controls.Add(this.gbPerfiles);
            this.Controls.Add(this.gbContacto);
            this.Controls.Add(this.gbPuestos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoColaboradores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Colaboradores";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbPuestos.ResumeLayout(false);
            this.gbContacto.ResumeLayout(false);
            this.gbContacto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonos)).EndInit();
            this.gbPerfiles.ResumeLayout(false);
            this.gbEmail.ResumeLayout(false);
            this.gbEmail.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.Label lblPrimerApellido;
        private System.Windows.Forms.GroupBox gbPuestos;
        private System.Windows.Forms.CheckedListBox clbPuestos;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cboAreas;
        private System.Windows.Forms.GroupBox gbContacto;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblTelefonos;
        private System.Windows.Forms.DataGridView dgvTelefonos;
        private System.Windows.Forms.Button btnAgregarTelefono;
        private System.Windows.Forms.Button btnQuitarTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.CheckBox chkAdministradorGeneral;
        private System.Windows.Forms.GroupBox gbPerfiles;
        private System.Windows.Forms.CheckedListBox clbPerfiles;
        private System.Windows.Forms.PrintDialog pdOpcionesImpresion;
        private System.Drawing.Printing.PrintDocument pdCodigo;
        private System.Windows.Forms.Button btnAsignarCodigo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtClaveCEF;
        private System.Windows.Forms.GroupBox gbEmail;
        private System.Windows.Forms.TextBox txtServidorCorreo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBaseCorreo;
        private System.Windows.Forms.Label lblBaseDatos;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbPuestosColaborador;
    }
}