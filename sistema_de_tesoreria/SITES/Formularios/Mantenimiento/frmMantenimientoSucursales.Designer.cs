namespace GUILayer
{
    partial class frmMantenimientoSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoSucursales));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.chkCajaEmpresarial = new System.Windows.Forms.CheckBox();
            this.chkExterno = new System.Windows.Forms.CheckBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.mtbNumero = new System.Windows.Forms.MaskedTextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.cboProvincias = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbDiasCarga = new System.Windows.Forms.GroupBox();
            this.clbDiasCarga = new System.Windows.Forms.CheckedListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tcSucursales = new System.Windows.Forms.TabControl();
            this.tpDatos = new System.Windows.Forms.TabPage();
            this.tpTarifas = new System.Windows.Forms.TabPage();
            this.gbImportarTarifasTransportadora = new System.Windows.Forms.GroupBox();
            this.btnImportarTarifaTransportadora = new System.Windows.Forms.Button();
            this.lblArchivoTransportadoras = new System.Windows.Forms.Label();
            this.btnAbrirTransportadora = new System.Windows.Forms.Button();
            this.txtArchivoTransportadora = new System.Windows.Forms.TextBox();
            this.gbTarifasTransportadora = new System.Windows.Forms.GroupBox();
            this.lblTransportadoraTarifa = new System.Windows.Forms.Label();
            this.lblTarifaRegularTransportadora = new System.Windows.Forms.Label();
            this.nudTarifaFeriadosTransportadora = new System.Windows.Forms.NumericUpDown();
            this.lblMonedaRecargoTransportadora = new System.Windows.Forms.Label();
            this.nudTarifaRegularTransportadora = new System.Windows.Forms.NumericUpDown();
            this.nudTopeTransportadora = new System.Windows.Forms.NumericUpDown();
            this.cboMonedaRecargoTransportadora = new System.Windows.Forms.ComboBox();
            this.nudRecargoTransportadora = new System.Windows.Forms.NumericUpDown();
            this.lblMonedaTopeTransportadora = new System.Windows.Forms.Label();
            this.cboMonedaTopeTransportadora = new System.Windows.Forms.ComboBox();
            this.lblTopeTransportadora = new System.Windows.Forms.Label();
            this.lblRecargoTransportadora = new System.Windows.Forms.Label();
            this.btnAgregarTarifaTransportadora = new System.Windows.Forms.Button();
            this.lblMonedaTarifaFeriadoTransportadora = new System.Windows.Forms.Label();
            this.cboMonedaFeriadoTransportadora = new System.Windows.Forms.ComboBox();
            this.dgvTarifasTransportadora = new System.Windows.Forms.DataGridView();
            this.lblMonedaTarifaRegularTransportadora = new System.Windows.Forms.Label();
            this.lblTarifaFeriadoTransportadora = new System.Windows.Forms.Label();
            this.cboMonedaTarifaRegularTransportadora = new System.Windows.Forms.ComboBox();
            this.btnQuitarTarifaTransportadora = new System.Windows.Forms.Button();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.cboTransportadoraTarifa = new GUILayer.ComboBoxBusqueda();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTarifaRegular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTarifaFeriado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRecargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.gbDiasCarga.SuspendLayout();
            this.tcSucursales.SuspendLayout();
            this.tpDatos.SuspendLayout();
            this.tpTarifas.SuspendLayout();
            this.gbImportarTarifasTransportadora.SuspendLayout();
            this.gbTarifasTransportadora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarifaFeriadosTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarifaRegularTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopeTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargoTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasTransportadora)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(710, 60);
            this.pnlFondo.TabIndex = 0;
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
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.chkCajaEmpresarial);
            this.gbDatos.Controls.Add(this.chkExterno);
            this.gbDatos.Controls.Add(this.cboTransportadora);
            this.gbDatos.Controls.Add(this.lblTransportadora);
            this.gbDatos.Controls.Add(this.cboTipo);
            this.gbDatos.Controls.Add(this.mtbNumero);
            this.gbDatos.Controls.Add(this.lblTipo);
            this.gbDatos.Controls.Add(this.lblNumero);
            this.gbDatos.Controls.Add(this.cboProvincias);
            this.gbDatos.Controls.Add(this.lblProvincia);
            this.gbDatos.Controls.Add(this.txtDireccion);
            this.gbDatos.Controls.Add(this.lblDireccion);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Location = new System.Drawing.Point(71, 22);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(411, 212);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Sucursal";
            // 
            // chkCajaEmpresarial
            // 
            this.chkCajaEmpresarial.AutoSize = true;
            this.chkCajaEmpresarial.Location = new System.Drawing.Point(301, 174);
            this.chkCajaEmpresarial.Name = "chkCajaEmpresarial";
            this.chkCajaEmpresarial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCajaEmpresarial.Size = new System.Drawing.Size(104, 17);
            this.chkCajaEmpresarial.TabIndex = 28;
            this.chkCajaEmpresarial.Text = "Caja Empresarial";
            this.chkCajaEmpresarial.UseVisualStyleBackColor = true;
            // 
            // chkExterno
            // 
            this.chkExterno.AutoSize = true;
            this.chkExterno.Location = new System.Drawing.Point(236, 173);
            this.chkExterno.Name = "chkExterno";
            this.chkExterno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkExterno.Size = new System.Drawing.Size(62, 17);
            this.chkExterno.TabIndex = 19;
            this.chkExterno.Text = "Externo";
            this.chkExterno.UseVisualStyleBackColor = true;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(5, 175);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 17;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Sucursal",
            "RapiBanco",
            "Caja Empresarial"});
            this.cboTipo.Location = new System.Drawing.Point(199, 125);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(103, 21);
            this.cboTipo.TabIndex = 27;
            // 
            // mtbNumero
            // 
            this.mtbNumero.Location = new System.Drawing.Point(66, 125);
            this.mtbNumero.Mask = "9999";
            this.mtbNumero.Name = "mtbNumero";
            this.mtbNumero.Size = new System.Drawing.Size(90, 20);
            this.mtbNumero.TabIndex = 25;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(162, 129);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 26;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(7, 129);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 24;
            this.lblNumero.Text = "Número:";
            // 
            // cboProvincias
            // 
            this.cboProvincias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincias.FormattingEnabled = true;
            this.cboProvincias.Items.AddRange(new object[] {
            "Alajuela",
            "Cartago",
            "Guanacaste",
            "Heredia",
            "Limón",
            "Puntarenas",
            "San José"});
            this.cboProvincias.Location = new System.Drawing.Point(67, 54);
            this.cboProvincias.Name = "cboProvincias";
            this.cboProvincias.Size = new System.Drawing.Size(344, 21);
            this.cboProvincias.TabIndex = 3;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(7, 58);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(54, 13);
            this.lblProvincia.TabIndex = 2;
            this.lblProvincia.Text = "Provincia:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(67, 81);
            this.txtDireccion.MaxLength = 250;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(344, 33);
            this.txtDireccion.TabIndex = 5;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(6, 81);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(67, 28);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(344, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // gbDiasCarga
            // 
            this.gbDiasCarga.Controls.Add(this.clbDiasCarga);
            this.gbDiasCarga.Location = new System.Drawing.Point(71, 240);
            this.gbDiasCarga.Name = "gbDiasCarga";
            this.gbDiasCarga.Size = new System.Drawing.Size(411, 101);
            this.gbDiasCarga.TabIndex = 5;
            this.gbDiasCarga.TabStop = false;
            this.gbDiasCarga.Text = "Días de Carga";
            // 
            // clbDiasCarga
            // 
            this.clbDiasCarga.FormattingEnabled = true;
            this.clbDiasCarga.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.clbDiasCarga.Location = new System.Drawing.Point(49, 19);
            this.clbDiasCarga.MultiColumn = true;
            this.clbDiasCarga.Name = "clbDiasCarga";
            this.clbDiasCarga.Size = new System.Drawing.Size(339, 64);
            this.clbDiasCarga.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(404, 474);
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
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(500, 474);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tcSucursales
            // 
            this.tcSucursales.Controls.Add(this.tpDatos);
            this.tcSucursales.Controls.Add(this.tpTarifas);
            this.tcSucursales.Location = new System.Drawing.Point(12, 62);
            this.tcSucursales.Name = "tcSucursales";
            this.tcSucursales.SelectedIndex = 0;
            this.tcSucursales.Size = new System.Drawing.Size(582, 406);
            this.tcSucursales.TabIndex = 6;
            // 
            // tpDatos
            // 
            this.tpDatos.Controls.Add(this.gbDatos);
            this.tpDatos.Controls.Add(this.gbDiasCarga);
            this.tpDatos.Location = new System.Drawing.Point(4, 22);
            this.tpDatos.Name = "tpDatos";
            this.tpDatos.Padding = new System.Windows.Forms.Padding(3);
            this.tpDatos.Size = new System.Drawing.Size(574, 380);
            this.tpDatos.TabIndex = 0;
            this.tpDatos.Text = "Datos";
            this.tpDatos.UseVisualStyleBackColor = true;
            // 
            // tpTarifas
            // 
            this.tpTarifas.Controls.Add(this.gbImportarTarifasTransportadora);
            this.tpTarifas.Controls.Add(this.gbTarifasTransportadora);
            this.tpTarifas.Location = new System.Drawing.Point(4, 22);
            this.tpTarifas.Name = "tpTarifas";
            this.tpTarifas.Padding = new System.Windows.Forms.Padding(3);
            this.tpTarifas.Size = new System.Drawing.Size(574, 380);
            this.tpTarifas.TabIndex = 1;
            this.tpTarifas.Text = "Tarifas";
            this.tpTarifas.UseVisualStyleBackColor = true;
            // 
            // gbImportarTarifasTransportadora
            // 
            this.gbImportarTarifasTransportadora.Controls.Add(this.btnImportarTarifaTransportadora);
            this.gbImportarTarifasTransportadora.Controls.Add(this.lblArchivoTransportadoras);
            this.gbImportarTarifasTransportadora.Controls.Add(this.btnAbrirTransportadora);
            this.gbImportarTarifasTransportadora.Controls.Add(this.txtArchivoTransportadora);
            this.gbImportarTarifasTransportadora.Location = new System.Drawing.Point(16, 295);
            this.gbImportarTarifasTransportadora.Name = "gbImportarTarifasTransportadora";
            this.gbImportarTarifasTransportadora.Size = new System.Drawing.Size(542, 79);
            this.gbImportarTarifasTransportadora.TabIndex = 36;
            this.gbImportarTarifasTransportadora.TabStop = false;
            this.gbImportarTarifasTransportadora.Text = "Importar";
            // 
            // btnImportarTarifaTransportadora
            // 
            this.btnImportarTarifaTransportadora.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportarTarifaTransportadora.Image = global::GUILayer.Properties.Resources.importar_triales;
            this.btnImportarTarifaTransportadora.Location = new System.Drawing.Point(431, 24);
            this.btnImportarTarifaTransportadora.Name = "btnImportarTarifaTransportadora";
            this.btnImportarTarifaTransportadora.Size = new System.Drawing.Size(90, 40);
            this.btnImportarTarifaTransportadora.TabIndex = 24;
            this.btnImportarTarifaTransportadora.Text = "Importar";
            this.btnImportarTarifaTransportadora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportarTarifaTransportadora.UseVisualStyleBackColor = false;
            this.btnImportarTarifaTransportadora.Click += new System.EventHandler(this.btnImportarTarifaTransportadora_Click);
            // 
            // lblArchivoTransportadoras
            // 
            this.lblArchivoTransportadoras.AutoSize = true;
            this.lblArchivoTransportadoras.Location = new System.Drawing.Point(21, 38);
            this.lblArchivoTransportadoras.Name = "lblArchivoTransportadoras";
            this.lblArchivoTransportadoras.Size = new System.Drawing.Size(46, 13);
            this.lblArchivoTransportadoras.TabIndex = 23;
            this.lblArchivoTransportadoras.Text = "Archivo:";
            // 
            // btnAbrirTransportadora
            // 
            this.btnAbrirTransportadora.Location = new System.Drawing.Point(371, 35);
            this.btnAbrirTransportadora.Name = "btnAbrirTransportadora";
            this.btnAbrirTransportadora.Size = new System.Drawing.Size(45, 20);
            this.btnAbrirTransportadora.TabIndex = 3;
            this.btnAbrirTransportadora.Text = "...";
            this.btnAbrirTransportadora.UseVisualStyleBackColor = true;
            this.btnAbrirTransportadora.Click += new System.EventHandler(this.btnAbrirTransportadora_Click);
            // 
            // txtArchivoTransportadora
            // 
            this.txtArchivoTransportadora.Location = new System.Drawing.Point(95, 35);
            this.txtArchivoTransportadora.Name = "txtArchivoTransportadora";
            this.txtArchivoTransportadora.ReadOnly = true;
            this.txtArchivoTransportadora.Size = new System.Drawing.Size(270, 20);
            this.txtArchivoTransportadora.TabIndex = 2;
            // 
            // gbTarifasTransportadora
            // 
            this.gbTarifasTransportadora.Controls.Add(this.lblTransportadoraTarifa);
            this.gbTarifasTransportadora.Controls.Add(this.cboTransportadoraTarifa);
            this.gbTarifasTransportadora.Controls.Add(this.lblTarifaRegularTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.nudTarifaFeriadosTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.lblMonedaRecargoTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.nudTarifaRegularTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.nudTopeTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.cboMonedaRecargoTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.nudRecargoTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.lblMonedaTopeTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.cboMonedaTopeTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.lblTopeTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.lblRecargoTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.btnAgregarTarifaTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.lblMonedaTarifaFeriadoTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.cboMonedaFeriadoTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.dgvTarifasTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.lblMonedaTarifaRegularTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.lblTarifaFeriadoTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.cboMonedaTarifaRegularTransportadora);
            this.gbTarifasTransportadora.Controls.Add(this.btnQuitarTarifaTransportadora);
            this.gbTarifasTransportadora.Location = new System.Drawing.Point(8, 17);
            this.gbTarifasTransportadora.Name = "gbTarifasTransportadora";
            this.gbTarifasTransportadora.Size = new System.Drawing.Size(549, 272);
            this.gbTarifasTransportadora.TabIndex = 35;
            this.gbTarifasTransportadora.TabStop = false;
            this.gbTarifasTransportadora.Text = "Tarifas";
            // 
            // lblTransportadoraTarifa
            // 
            this.lblTransportadoraTarifa.AutoSize = true;
            this.lblTransportadoraTarifa.Location = new System.Drawing.Point(170, 131);
            this.lblTransportadoraTarifa.Name = "lblTransportadoraTarifa";
            this.lblTransportadoraTarifa.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadoraTarifa.TabIndex = 34;
            this.lblTransportadoraTarifa.Text = "Transportadora:";
            // 
            // lblTarifaRegularTransportadora
            // 
            this.lblTarifaRegularTransportadora.AutoSize = true;
            this.lblTarifaRegularTransportadora.Location = new System.Drawing.Point(122, 18);
            this.lblTarifaRegularTransportadora.Name = "lblTarifaRegularTransportadora";
            this.lblTarifaRegularTransportadora.Size = new System.Drawing.Size(44, 13);
            this.lblTarifaRegularTransportadora.TabIndex = 17;
            this.lblTarifaRegularTransportadora.Text = "Regular";
            // 
            // nudTarifaFeriadosTransportadora
            // 
            this.nudTarifaFeriadosTransportadora.DecimalPlaces = 2;
            this.nudTarifaFeriadosTransportadora.Location = new System.Drawing.Point(221, 39);
            this.nudTarifaFeriadosTransportadora.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudTarifaFeriadosTransportadora.Name = "nudTarifaFeriadosTransportadora";
            this.nudTarifaFeriadosTransportadora.Size = new System.Drawing.Size(94, 20);
            this.nudTarifaFeriadosTransportadora.TabIndex = 5;
            // 
            // lblMonedaRecargoTransportadora
            // 
            this.lblMonedaRecargoTransportadora.AutoSize = true;
            this.lblMonedaRecargoTransportadora.Location = new System.Drawing.Point(325, 96);
            this.lblMonedaRecargoTransportadora.Name = "lblMonedaRecargoTransportadora";
            this.lblMonedaRecargoTransportadora.Size = new System.Drawing.Size(49, 13);
            this.lblMonedaRecargoTransportadora.TabIndex = 31;
            this.lblMonedaRecargoTransportadora.Text = "Moneda:";
            // 
            // nudTarifaRegularTransportadora
            // 
            this.nudTarifaRegularTransportadora.DecimalPlaces = 2;
            this.nudTarifaRegularTransportadora.Location = new System.Drawing.Point(221, 11);
            this.nudTarifaRegularTransportadora.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudTarifaRegularTransportadora.Name = "nudTarifaRegularTransportadora";
            this.nudTarifaRegularTransportadora.Size = new System.Drawing.Size(94, 20);
            this.nudTarifaRegularTransportadora.TabIndex = 8;
            // 
            // nudTopeTransportadora
            // 
            this.nudTopeTransportadora.DecimalPlaces = 2;
            this.nudTopeTransportadora.Location = new System.Drawing.Point(221, 67);
            this.nudTopeTransportadora.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudTopeTransportadora.Name = "nudTopeTransportadora";
            this.nudTopeTransportadora.Size = new System.Drawing.Size(94, 20);
            this.nudTopeTransportadora.TabIndex = 9;
            // 
            // cboMonedaRecargoTransportadora
            // 
            this.cboMonedaRecargoTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaRecargoTransportadora.FormattingEnabled = true;
            this.cboMonedaRecargoTransportadora.Items.AddRange(new object[] {
            "Colones",
            "Dólares",
            "Euros"});
            this.cboMonedaRecargoTransportadora.Location = new System.Drawing.Point(380, 93);
            this.cboMonedaRecargoTransportadora.Name = "cboMonedaRecargoTransportadora";
            this.cboMonedaRecargoTransportadora.Size = new System.Drawing.Size(87, 21);
            this.cboMonedaRecargoTransportadora.TabIndex = 32;
            // 
            // nudRecargoTransportadora
            // 
            this.nudRecargoTransportadora.DecimalPlaces = 2;
            this.nudRecargoTransportadora.Location = new System.Drawing.Point(221, 93);
            this.nudRecargoTransportadora.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudRecargoTransportadora.Name = "nudRecargoTransportadora";
            this.nudRecargoTransportadora.Size = new System.Drawing.Size(94, 20);
            this.nudRecargoTransportadora.TabIndex = 12;
            // 
            // lblMonedaTopeTransportadora
            // 
            this.lblMonedaTopeTransportadora.AutoSize = true;
            this.lblMonedaTopeTransportadora.Location = new System.Drawing.Point(325, 73);
            this.lblMonedaTopeTransportadora.Name = "lblMonedaTopeTransportadora";
            this.lblMonedaTopeTransportadora.Size = new System.Drawing.Size(49, 13);
            this.lblMonedaTopeTransportadora.TabIndex = 29;
            this.lblMonedaTopeTransportadora.Text = "Moneda:";
            // 
            // cboMonedaTopeTransportadora
            // 
            this.cboMonedaTopeTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaTopeTransportadora.FormattingEnabled = true;
            this.cboMonedaTopeTransportadora.Items.AddRange(new object[] {
            "Colones",
            "Dólares",
            "Euros"});
            this.cboMonedaTopeTransportadora.Location = new System.Drawing.Point(380, 65);
            this.cboMonedaTopeTransportadora.Name = "cboMonedaTopeTransportadora";
            this.cboMonedaTopeTransportadora.Size = new System.Drawing.Size(87, 21);
            this.cboMonedaTopeTransportadora.TabIndex = 30;
            // 
            // lblTopeTransportadora
            // 
            this.lblTopeTransportadora.AutoSize = true;
            this.lblTopeTransportadora.Location = new System.Drawing.Point(124, 69);
            this.lblTopeTransportadora.Name = "lblTopeTransportadora";
            this.lblTopeTransportadora.Size = new System.Drawing.Size(32, 13);
            this.lblTopeTransportadora.TabIndex = 19;
            this.lblTopeTransportadora.Text = "Tope";
            // 
            // lblRecargoTransportadora
            // 
            this.lblRecargoTransportadora.AutoSize = true;
            this.lblRecargoTransportadora.Location = new System.Drawing.Point(124, 95);
            this.lblRecargoTransportadora.Name = "lblRecargoTransportadora";
            this.lblRecargoTransportadora.Size = new System.Drawing.Size(48, 13);
            this.lblRecargoTransportadora.TabIndex = 20;
            this.lblRecargoTransportadora.Text = "Recargo";
            // 
            // btnAgregarTarifaTransportadora
            // 
            this.btnAgregarTarifaTransportadora.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregarTarifaTransportadora.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarTarifaTransportadora.Location = new System.Drawing.Point(4, 180);
            this.btnAgregarTarifaTransportadora.Name = "btnAgregarTarifaTransportadora";
            this.btnAgregarTarifaTransportadora.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarTarifaTransportadora.TabIndex = 9;
            this.btnAgregarTarifaTransportadora.Text = "Agregar";
            this.btnAgregarTarifaTransportadora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarTarifaTransportadora.UseVisualStyleBackColor = false;
            this.btnAgregarTarifaTransportadora.Click += new System.EventHandler(this.btnAgregarTarifaTransportadora_Click);
            // 
            // lblMonedaTarifaFeriadoTransportadora
            // 
            this.lblMonedaTarifaFeriadoTransportadora.AutoSize = true;
            this.lblMonedaTarifaFeriadoTransportadora.Location = new System.Drawing.Point(325, 42);
            this.lblMonedaTarifaFeriadoTransportadora.Name = "lblMonedaTarifaFeriadoTransportadora";
            this.lblMonedaTarifaFeriadoTransportadora.Size = new System.Drawing.Size(49, 13);
            this.lblMonedaTarifaFeriadoTransportadora.TabIndex = 25;
            this.lblMonedaTarifaFeriadoTransportadora.Text = "Moneda:";
            // 
            // cboMonedaFeriadoTransportadora
            // 
            this.cboMonedaFeriadoTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaFeriadoTransportadora.FormattingEnabled = true;
            this.cboMonedaFeriadoTransportadora.Items.AddRange(new object[] {
            "Colones",
            "Dólares",
            "Euros"});
            this.cboMonedaFeriadoTransportadora.Location = new System.Drawing.Point(380, 38);
            this.cboMonedaFeriadoTransportadora.Name = "cboMonedaFeriadoTransportadora";
            this.cboMonedaFeriadoTransportadora.Size = new System.Drawing.Size(87, 21);
            this.cboMonedaFeriadoTransportadora.TabIndex = 26;
            // 
            // dgvTarifasTransportadora
            // 
            this.dgvTarifasTransportadora.AllowUserToAddRows = false;
            this.dgvTarifasTransportadora.AllowUserToDeleteRows = false;
            this.dgvTarifasTransportadora.AllowUserToOrderColumns = true;
            this.dgvTarifasTransportadora.AllowUserToResizeColumns = false;
            this.dgvTarifasTransportadora.AllowUserToResizeRows = false;
            this.dgvTarifasTransportadora.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTarifasTransportadora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTarifasTransportadora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarifasTransportadora.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.clmTarifaRegular,
            this.clmTarifaFeriado,
            this.clmTope,
            this.clmRecargo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTarifasTransportadora.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTarifasTransportadora.EnableHeadersVisualStyles = false;
            this.dgvTarifasTransportadora.Location = new System.Drawing.Point(111, 160);
            this.dgvTarifasTransportadora.Name = "dgvTarifasTransportadora";
            this.dgvTarifasTransportadora.ReadOnly = true;
            this.dgvTarifasTransportadora.RowHeadersVisible = false;
            this.dgvTarifasTransportadora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTarifasTransportadora.Size = new System.Drawing.Size(413, 106);
            this.dgvTarifasTransportadora.TabIndex = 12;
            this.dgvTarifasTransportadora.SelectionChanged += new System.EventHandler(this.dgvTarifasTransportadora_SelectionChanged);
            // 
            // lblMonedaTarifaRegularTransportadora
            // 
            this.lblMonedaTarifaRegularTransportadora.AutoSize = true;
            this.lblMonedaTarifaRegularTransportadora.Location = new System.Drawing.Point(325, 14);
            this.lblMonedaTarifaRegularTransportadora.Name = "lblMonedaTarifaRegularTransportadora";
            this.lblMonedaTarifaRegularTransportadora.Size = new System.Drawing.Size(49, 13);
            this.lblMonedaTarifaRegularTransportadora.TabIndex = 23;
            this.lblMonedaTarifaRegularTransportadora.Text = "Moneda:";
            // 
            // lblTarifaFeriadoTransportadora
            // 
            this.lblTarifaFeriadoTransportadora.AutoSize = true;
            this.lblTarifaFeriadoTransportadora.Location = new System.Drawing.Point(108, 45);
            this.lblTarifaFeriadoTransportadora.Name = "lblTarifaFeriadoTransportadora";
            this.lblTarifaFeriadoTransportadora.Size = new System.Drawing.Size(105, 13);
            this.lblTarifaFeriadoTransportadora.TabIndex = 18;
            this.lblTarifaFeriadoTransportadora.Text = "Feriados y Domingos";
            // 
            // cboMonedaTarifaRegularTransportadora
            // 
            this.cboMonedaTarifaRegularTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaTarifaRegularTransportadora.FormattingEnabled = true;
            this.cboMonedaTarifaRegularTransportadora.Items.AddRange(new object[] {
            "Colones",
            "Dólares",
            "Euros"});
            this.cboMonedaTarifaRegularTransportadora.Location = new System.Drawing.Point(380, 10);
            this.cboMonedaTarifaRegularTransportadora.Name = "cboMonedaTarifaRegularTransportadora";
            this.cboMonedaTarifaRegularTransportadora.Size = new System.Drawing.Size(87, 21);
            this.cboMonedaTarifaRegularTransportadora.TabIndex = 24;
            // 
            // btnQuitarTarifaTransportadora
            // 
            this.btnQuitarTarifaTransportadora.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitarTarifaTransportadora.Enabled = false;
            this.btnQuitarTarifaTransportadora.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnQuitarTarifaTransportadora.Location = new System.Drawing.Point(4, 226);
            this.btnQuitarTarifaTransportadora.Name = "btnQuitarTarifaTransportadora";
            this.btnQuitarTarifaTransportadora.Size = new System.Drawing.Size(90, 40);
            this.btnQuitarTarifaTransportadora.TabIndex = 13;
            this.btnQuitarTarifaTransportadora.Text = "Quitar";
            this.btnQuitarTarifaTransportadora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarTarifaTransportadora.UseVisualStyleBackColor = false;
            this.btnQuitarTarifaTransportadora.Click += new System.EventHandler(this.btnQuitarTarifaTransportadora_Click);
            // 
            // ofdMontosCargas
            // 
            this.ofdMontosCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = false;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(93, 171);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(137, 21);
            this.cboTransportadora.TabIndex = 18;
            // 
            // cboTransportadoraTarifa
            // 
            this.cboTransportadoraTarifa.Busqueda = true;
            this.cboTransportadoraTarifa.FormattingEnabled = true;
            this.cboTransportadoraTarifa.ListaMostrada = null;
            this.cboTransportadoraTarifa.Location = new System.Drawing.Point(268, 128);
            this.cboTransportadoraTarifa.Name = "cboTransportadoraTarifa";
            this.cboTransportadoraTarifa.Size = new System.Drawing.Size(153, 21);
            this.cboTransportadoraTarifa.TabIndex = 33;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Sucursal";
            this.dataGridViewTextBoxColumn1.HeaderText = "Sucursal";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 72;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "EmpresaTransporte";
            this.dataGridViewTextBoxColumn2.HeaderText = "Transportadora";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // clmTarifaRegular
            // 
            this.clmTarifaRegular.DataPropertyName = "TarifaRegular";
            this.clmTarifaRegular.HeaderText = "Tarifa Regular";
            this.clmTarifaRegular.Name = "clmTarifaRegular";
            this.clmTarifaRegular.ReadOnly = true;
            // 
            // clmTarifaFeriado
            // 
            this.clmTarifaFeriado.DataPropertyName = "TarifaFeriados";
            this.clmTarifaFeriado.HeaderText = "Tarifa Feriado";
            this.clmTarifaFeriado.Name = "clmTarifaFeriado";
            this.clmTarifaFeriado.ReadOnly = true;
            // 
            // clmTope
            // 
            this.clmTope.DataPropertyName = "Tope";
            this.clmTope.HeaderText = "Tope";
            this.clmTope.Name = "clmTope";
            this.clmTope.ReadOnly = true;
            // 
            // clmRecargo
            // 
            this.clmRecargo.DataPropertyName = "Recargo";
            this.clmRecargo.HeaderText = "Recargo";
            this.clmRecargo.Name = "clmRecargo";
            this.clmRecargo.ReadOnly = true;
            // 
            // frmMantenimientoSucursales
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(600, 518);
            this.Controls.Add(this.tcSucursales);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoSucursales";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Sucursales";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbDiasCarga.ResumeLayout(false);
            this.tcSucursales.ResumeLayout(false);
            this.tpDatos.ResumeLayout(false);
            this.tpTarifas.ResumeLayout(false);
            this.gbImportarTarifasTransportadora.ResumeLayout(false);
            this.gbImportarTarifasTransportadora.PerformLayout();
            this.gbTarifasTransportadora.ResumeLayout(false);
            this.gbTarifasTransportadora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarifaFeriadosTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarifaRegularTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopeTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargoTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasTransportadora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cboProvincias;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.CheckBox chkExterno;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.MaskedTextBox mtbNumero;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.GroupBox gbDiasCarga;
        private System.Windows.Forms.CheckedListBox clbDiasCarga;
        private System.Windows.Forms.CheckBox chkCajaEmpresarial;
        private System.Windows.Forms.TabControl tcSucursales;
        private System.Windows.Forms.TabPage tpDatos;
        private System.Windows.Forms.TabPage tpTarifas;
        private System.Windows.Forms.GroupBox gbImportarTarifasTransportadora;
        private System.Windows.Forms.Button btnImportarTarifaTransportadora;
        private System.Windows.Forms.Label lblArchivoTransportadoras;
        private System.Windows.Forms.Button btnAbrirTransportadora;
        private System.Windows.Forms.TextBox txtArchivoTransportadora;
        private System.Windows.Forms.GroupBox gbTarifasTransportadora;
        private System.Windows.Forms.Label lblTarifaRegularTransportadora;
        private System.Windows.Forms.NumericUpDown nudTarifaFeriadosTransportadora;
        private System.Windows.Forms.Label lblMonedaRecargoTransportadora;
        private System.Windows.Forms.NumericUpDown nudTarifaRegularTransportadora;
        private System.Windows.Forms.NumericUpDown nudTopeTransportadora;
        private System.Windows.Forms.ComboBox cboMonedaRecargoTransportadora;
        private System.Windows.Forms.NumericUpDown nudRecargoTransportadora;
        private System.Windows.Forms.Label lblMonedaTopeTransportadora;
        private System.Windows.Forms.ComboBox cboMonedaTopeTransportadora;
        private System.Windows.Forms.Label lblTopeTransportadora;
        private System.Windows.Forms.Label lblRecargoTransportadora;
        private System.Windows.Forms.Button btnAgregarTarifaTransportadora;
        private System.Windows.Forms.Label lblMonedaTarifaFeriadoTransportadora;
        private System.Windows.Forms.ComboBox cboMonedaFeriadoTransportadora;
        private System.Windows.Forms.DataGridView dgvTarifasTransportadora;
        private System.Windows.Forms.Label lblMonedaTarifaRegularTransportadora;
        private System.Windows.Forms.Label lblTarifaFeriadoTransportadora;
        private System.Windows.Forms.ComboBox cboMonedaTarifaRegularTransportadora;
        private System.Windows.Forms.Button btnQuitarTarifaTransportadora;
        private System.Windows.Forms.Label lblTransportadoraTarifa;
        private ComboBoxBusqueda cboTransportadoraTarifa;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTarifaRegular;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTarifaFeriado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTope;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRecargo;
    }
}