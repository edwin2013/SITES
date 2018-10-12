namespace GUILayer
{
    partial class frmImportacionCargas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportacionCargas));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.lblCeldaTipoATM = new System.Windows.Forms.Label();
            this.lblCeldaATM = new System.Windows.Forms.Label();
            this.mtbCeldaTipoATM = new System.Windows.Forms.MaskedTextBox();
            this.lblCeldaFecha = new System.Windows.Forms.Label();
            this.mtbCeldaATM = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaFecha = new System.Windows.Forms.MaskedTextBox();
            this.lblSegundaCelda = new System.Windows.Forms.Label();
            this.lblPrimeraCelda = new System.Windows.Forms.Label();
            this.mtbSegundaCelda = new System.Windows.Forms.MaskedTextBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.mtbPrimeraCelda = new System.Windows.Forms.MaskedTextBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.ATM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadCartuchos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofdArchivoCargas = new System.Windows.Forms.OpenFileDialog();
            this.gbEstados = new System.Windows.Forms.GroupBox();
            this.lblErrorCantidadCartuchos = new System.Windows.Forms.Label();
            this.pbErrorCantidadCartuchos = new System.Windows.Forms.PictureBox();
            this.lblErrorDenominacionCarga = new System.Windows.Forms.Label();
            this.pbErrorDenominacionCarga = new System.Windows.Forms.PictureBox();
            this.lblErrorCantidadCarga = new System.Windows.Forms.Label();
            this.pbErrorCantidadCarga = new System.Windows.Forms.PictureBox();
            this.lblTipoCargaErronea = new System.Windows.Forms.Label();
            this.pbTipoCargaErronea = new System.Windows.Forms.PictureBox();
            this.lblATMDesconocido = new System.Windows.Forms.Label();
            this.pbATMDesconocido = new System.Windows.Forms.PictureBox();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbArchivo.SuspendLayout();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbEstados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadCartuchos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorDenominacionCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTipoCargaErronea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbATMDesconocido)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(792, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbArchivo
            // 
            this.gbArchivo.Controls.Add(this.lblCeldaTipoATM);
            this.gbArchivo.Controls.Add(this.lblCeldaATM);
            this.gbArchivo.Controls.Add(this.mtbCeldaTipoATM);
            this.gbArchivo.Controls.Add(this.lblCeldaFecha);
            this.gbArchivo.Controls.Add(this.mtbCeldaATM);
            this.gbArchivo.Controls.Add(this.mtbCeldaFecha);
            this.gbArchivo.Controls.Add(this.lblSegundaCelda);
            this.gbArchivo.Controls.Add(this.lblPrimeraCelda);
            this.gbArchivo.Controls.Add(this.mtbSegundaCelda);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbPrimeraCelda);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(12, 65);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(368, 97);
            this.gbArchivo.TabIndex = 1;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // lblCeldaTipoATM
            // 
            this.lblCeldaTipoATM.AutoSize = true;
            this.lblCeldaTipoATM.Location = new System.Drawing.Point(280, 49);
            this.lblCeldaTipoATM.Name = "lblCeldaTipoATM";
            this.lblCeldaTipoATM.Size = new System.Drawing.Size(31, 13);
            this.lblCeldaTipoATM.TabIndex = 10;
            this.lblCeldaTipoATM.Text = "Tipo:";
            // 
            // lblCeldaATM
            // 
            this.lblCeldaATM.AutoSize = true;
            this.lblCeldaATM.Location = new System.Drawing.Point(160, 75);
            this.lblCeldaATM.Name = "lblCeldaATM";
            this.lblCeldaATM.Size = new System.Drawing.Size(63, 13);
            this.lblCeldaATM.TabIndex = 8;
            this.lblCeldaATM.Text = "Celda ATM:";
            // 
            // mtbCeldaTipoATM
            // 
            this.mtbCeldaTipoATM.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTiposATMsImportacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaTipoATM.Location = new System.Drawing.Point(317, 45);
            this.mtbCeldaTipoATM.Mask = "aa99";
            this.mtbCeldaTipoATM.Name = "mtbCeldaTipoATM";
            this.mtbCeldaTipoATM.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaTipoATM.TabIndex = 11;
            this.mtbCeldaTipoATM.Text = global::GUILayer.Properties.Settings.Default.CeldaTiposATMsImportacion;
            // 
            // lblCeldaFecha
            // 
            this.lblCeldaFecha.AutoSize = true;
            this.lblCeldaFecha.Location = new System.Drawing.Point(153, 49);
            this.lblCeldaFecha.Name = "lblCeldaFecha";
            this.lblCeldaFecha.Size = new System.Drawing.Size(70, 13);
            this.lblCeldaFecha.TabIndex = 6;
            this.lblCeldaFecha.Text = "Celda Fecha:";
            // 
            // mtbCeldaATM
            // 
            this.mtbCeldaATM.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaATMsImportacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaATM.Location = new System.Drawing.Point(229, 71);
            this.mtbCeldaATM.Mask = "aa99";
            this.mtbCeldaATM.Name = "mtbCeldaATM";
            this.mtbCeldaATM.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaATM.TabIndex = 9;
            this.mtbCeldaATM.Text = global::GUILayer.Properties.Settings.Default.CeldaATMsImportacion;
            // 
            // mtbCeldaFecha
            // 
            this.mtbCeldaFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaFechaImportacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaFecha.Location = new System.Drawing.Point(229, 45);
            this.mtbCeldaFecha.Mask = "aa99";
            this.mtbCeldaFecha.Name = "mtbCeldaFecha";
            this.mtbCeldaFecha.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaFecha.TabIndex = 7;
            this.mtbCeldaFecha.Text = global::GUILayer.Properties.Settings.Default.CeldaFechaImportacion;
            // 
            // lblSegundaCelda
            // 
            this.lblSegundaCelda.AutoSize = true;
            this.lblSegundaCelda.Location = new System.Drawing.Point(6, 75);
            this.lblSegundaCelda.Name = "lblSegundaCelda";
            this.lblSegundaCelda.Size = new System.Drawing.Size(83, 13);
            this.lblSegundaCelda.TabIndex = 4;
            this.lblSegundaCelda.Text = "Segunda Celda:";
            // 
            // lblPrimeraCelda
            // 
            this.lblPrimeraCelda.AutoSize = true;
            this.lblPrimeraCelda.Location = new System.Drawing.Point(14, 49);
            this.lblPrimeraCelda.Name = "lblPrimeraCelda";
            this.lblPrimeraCelda.Size = new System.Drawing.Size(75, 13);
            this.lblPrimeraCelda.TabIndex = 2;
            this.lblPrimeraCelda.Text = "Primera Celda:";
            // 
            // mtbSegundaCelda
            // 
            this.mtbSegundaCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaBDenominacionesImportacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbSegundaCelda.Location = new System.Drawing.Point(95, 71);
            this.mtbSegundaCelda.Mask = "aa99";
            this.mtbSegundaCelda.Name = "mtbSegundaCelda";
            this.mtbSegundaCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbSegundaCelda.TabIndex = 5;
            this.mtbSegundaCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaBDenominacionesImportacion;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(317, 19);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(45, 20);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "...";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // mtbPrimeraCelda
            // 
            this.mtbPrimeraCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaADenominacionesImportacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbPrimeraCelda.Location = new System.Drawing.Point(95, 45);
            this.mtbPrimeraCelda.Mask = "aa99";
            this.mtbPrimeraCelda.Name = "mtbPrimeraCelda";
            this.mtbPrimeraCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbPrimeraCelda.TabIndex = 3;
            this.mtbPrimeraCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaADenominacionesImportacion;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(6, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(305, 20);
            this.txtArchivo.TabIndex = 0;
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 168);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(768, 340);
            this.gbCargas.TabIndex = 2;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Cargas";
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.AllowUserToOrderColumns = true;
            this.dgvCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATM,
            this.Fecha,
            this.CantidadColones,
            this.CantidadDolares,
            this.MontoColones,
            this.MontoDolares,
            this.Tipo,
            this.CantidadCartuchos});
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.MultiSelect = false;
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCargas.Size = new System.Drawing.Size(756, 315);
            this.dgvCargas.StandardTab = true;
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // ATM
            // 
            this.ATM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ATM.DefaultCellStyle = dataGridViewCellStyle1;
            this.ATM.HeaderText = "ATM";
            this.ATM.Name = "ATM";
            this.ATM.ReadOnly = true;
            this.ATM.Width = 54;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "Fecha_asignada";
            dataGridViewCellStyle2.Format = "M";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 61;
            // 
            // CantidadColones
            // 
            this.CantidadColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadColones.DataPropertyName = "Cantidad_asignada_colones";
            dataGridViewCellStyle3.Format = "N0";
            this.CantidadColones.DefaultCellStyle = dataGridViewCellStyle3;
            this.CantidadColones.HeaderText = "C. en Colones";
            this.CantidadColones.Name = "CantidadColones";
            this.CantidadColones.ReadOnly = true;
            this.CantidadColones.Width = 97;
            // 
            // CantidadDolares
            // 
            this.CantidadDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadDolares.DataPropertyName = "Cantidad_asignada_dolares";
            dataGridViewCellStyle4.Format = "N0";
            this.CantidadDolares.DefaultCellStyle = dataGridViewCellStyle4;
            this.CantidadDolares.HeaderText = "C. en Dólares";
            this.CantidadDolares.Name = "CantidadDolares";
            this.CantidadDolares.ReadOnly = true;
            this.CantidadDolares.Width = 95;
            // 
            // MontoColones
            // 
            this.MontoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColones.DataPropertyName = "Monto_asignado_colones";
            dataGridViewCellStyle5.Format = "N2";
            this.MontoColones.DefaultCellStyle = dataGridViewCellStyle5;
            this.MontoColones.HeaderText = "M. en Colones";
            this.MontoColones.Name = "MontoColones";
            this.MontoColones.ReadOnly = true;
            this.MontoColones.Width = 99;
            // 
            // MontoDolares
            // 
            this.MontoDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolares.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle6.Format = "N2";
            this.MontoDolares.DefaultCellStyle = dataGridViewCellStyle6;
            this.MontoDolares.HeaderText = "M. en Dólares";
            this.MontoDolares.Name = "MontoDolares";
            this.MontoDolares.ReadOnly = true;
            this.MontoDolares.Width = 97;
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 52;
            // 
            // CantidadCartuchos
            // 
            this.CantidadCartuchos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadCartuchos.HeaderText = "Cartuchos";
            this.CantidadCartuchos.Name = "CantidadCartuchos";
            this.CantidadCartuchos.ReadOnly = true;
            this.CantidadCartuchos.Width = 79;
            // 
            // ofdArchivoCargas
            // 
            this.ofdArchivoCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
            // 
            // gbEstados
            // 
            this.gbEstados.Controls.Add(this.lblErrorCantidadCartuchos);
            this.gbEstados.Controls.Add(this.pbErrorCantidadCartuchos);
            this.gbEstados.Controls.Add(this.lblErrorDenominacionCarga);
            this.gbEstados.Controls.Add(this.pbErrorDenominacionCarga);
            this.gbEstados.Controls.Add(this.lblErrorCantidadCarga);
            this.gbEstados.Controls.Add(this.pbErrorCantidadCarga);
            this.gbEstados.Controls.Add(this.lblTipoCargaErronea);
            this.gbEstados.Controls.Add(this.pbTipoCargaErronea);
            this.gbEstados.Controls.Add(this.lblATMDesconocido);
            this.gbEstados.Controls.Add(this.pbATMDesconocido);
            this.gbEstados.Location = new System.Drawing.Point(386, 77);
            this.gbEstados.Name = "gbEstados";
            this.gbEstados.Size = new System.Drawing.Size(383, 85);
            this.gbEstados.TabIndex = 5;
            this.gbEstados.TabStop = false;
            this.gbEstados.Text = "Estados";
            // 
            // lblErrorCantidadCartuchos
            // 
            this.lblErrorCantidadCartuchos.AutoSize = true;
            this.lblErrorCantidadCartuchos.Location = new System.Drawing.Point(216, 43);
            this.lblErrorCantidadCartuchos.Name = "lblErrorCantidadCartuchos";
            this.lblErrorCantidadCartuchos.Size = new System.Drawing.Size(161, 13);
            this.lblErrorCantidadCartuchos.TabIndex = 5;
            this.lblErrorCantidadCartuchos.Text = "Número Incorrecto de Cartuchos";
            // 
            // pbErrorCantidadCartuchos
            // 
            this.pbErrorCantidadCartuchos.BackColor = global::GUILayer.Properties.Settings.Default.ErrorImportacionCargasNumeroCartuchos;
            this.pbErrorCantidadCartuchos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbErrorCantidadCartuchos.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorImportacionCargasNumeroCartuchos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbErrorCantidadCartuchos.Location = new System.Drawing.Point(194, 41);
            this.pbErrorCantidadCartuchos.Name = "pbErrorCantidadCartuchos";
            this.pbErrorCantidadCartuchos.Size = new System.Drawing.Size(16, 16);
            this.pbErrorCantidadCartuchos.TabIndex = 10;
            this.pbErrorCantidadCartuchos.TabStop = false;
            // 
            // lblErrorDenominacionCarga
            // 
            this.lblErrorDenominacionCarga.AutoSize = true;
            this.lblErrorDenominacionCarga.Location = new System.Drawing.Point(213, 21);
            this.lblErrorDenominacionCarga.Name = "lblErrorDenominacionCarga";
            this.lblErrorDenominacionCarga.Size = new System.Drawing.Size(141, 13);
            this.lblErrorDenominacionCarga.TabIndex = 4;
            this.lblErrorDenominacionCarga.Text = "Denominación Desconocida";
            // 
            // pbErrorDenominacionCarga
            // 
            this.pbErrorDenominacionCarga.BackColor = global::GUILayer.Properties.Settings.Default.ErrorImportacionCargasDenominacionCarga;
            this.pbErrorDenominacionCarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbErrorDenominacionCarga.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorImportacionCargasDenominacionCarga", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbErrorDenominacionCarga.Location = new System.Drawing.Point(194, 19);
            this.pbErrorDenominacionCarga.Name = "pbErrorDenominacionCarga";
            this.pbErrorDenominacionCarga.Size = new System.Drawing.Size(16, 16);
            this.pbErrorDenominacionCarga.TabIndex = 8;
            this.pbErrorDenominacionCarga.TabStop = false;
            this.pbErrorDenominacionCarga.DoubleClick += new System.EventHandler(this.pbErrorDenominacionCarga_DoubleClick);
            // 
            // lblErrorCantidadCarga
            // 
            this.lblErrorCantidadCarga.AutoSize = true;
            this.lblErrorCantidadCarga.Location = new System.Drawing.Point(28, 65);
            this.lblErrorCantidadCarga.Name = "lblErrorCantidadCarga";
            this.lblErrorCantidadCarga.Size = new System.Drawing.Size(160, 13);
            this.lblErrorCantidadCarga.TabIndex = 3;
            this.lblErrorCantidadCarga.Text = "Cantidad de Fórmulas Incorrecta";
            // 
            // pbErrorCantidadCarga
            // 
            this.pbErrorCantidadCarga.BackColor = global::GUILayer.Properties.Settings.Default.ErrorImportacionCargasCantidadCarga;
            this.pbErrorCantidadCarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbErrorCantidadCarga.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorImportacionCargasCantidadCarga", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbErrorCantidadCarga.Location = new System.Drawing.Point(6, 63);
            this.pbErrorCantidadCarga.Name = "pbErrorCantidadCarga";
            this.pbErrorCantidadCarga.Size = new System.Drawing.Size(16, 16);
            this.pbErrorCantidadCarga.TabIndex = 6;
            this.pbErrorCantidadCarga.TabStop = false;
            this.pbErrorCantidadCarga.DoubleClick += new System.EventHandler(this.pbErrorCantidadCarga_DoubleClick);
            // 
            // lblTipoCargaErronea
            // 
            this.lblTipoCargaErronea.AutoSize = true;
            this.lblTipoCargaErronea.Location = new System.Drawing.Point(28, 43);
            this.lblTipoCargaErronea.Name = "lblTipoCargaErronea";
            this.lblTipoCargaErronea.Size = new System.Drawing.Size(129, 13);
            this.lblTipoCargaErronea.TabIndex = 2;
            this.lblTipoCargaErronea.Text = "Tipo de Cartucho Erróneo";
            // 
            // pbTipoCargaErronea
            // 
            this.pbTipoCargaErronea.BackColor = global::GUILayer.Properties.Settings.Default.ErrorImportacionCargasTipoCargaErronea;
            this.pbTipoCargaErronea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTipoCargaErronea.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorImportacionCargasTipoCargaErronea", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbTipoCargaErronea.Location = new System.Drawing.Point(6, 41);
            this.pbTipoCargaErronea.Name = "pbTipoCargaErronea";
            this.pbTipoCargaErronea.Size = new System.Drawing.Size(16, 16);
            this.pbTipoCargaErronea.TabIndex = 4;
            this.pbTipoCargaErronea.TabStop = false;
            this.pbTipoCargaErronea.DoubleClick += new System.EventHandler(this.pbTipoCargaErronea_DoubleClick);
            // 
            // lblATMDesconocido
            // 
            this.lblATMDesconocido.AutoSize = true;
            this.lblATMDesconocido.Location = new System.Drawing.Point(28, 21);
            this.lblATMDesconocido.Name = "lblATMDesconocido";
            this.lblATMDesconocido.Size = new System.Drawing.Size(99, 13);
            this.lblATMDesconocido.TabIndex = 0;
            this.lblATMDesconocido.Text = "ATM no Registrado";
            // 
            // pbATMDesconocido
            // 
            this.pbATMDesconocido.BackColor = global::GUILayer.Properties.Settings.Default.ErrorImportacionCargasATMDesconocido;
            this.pbATMDesconocido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbATMDesconocido.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::GUILayer.Properties.Settings.Default, "ErrorImportacionCargasATMDesconocido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbATMDesconocido.Location = new System.Drawing.Point(6, 19);
            this.pbATMDesconocido.Name = "pbATMDesconocido";
            this.pbATMDesconocido.Size = new System.Drawing.Size(16, 16);
            this.pbATMDesconocido.TabIndex = 0;
            this.pbATMDesconocido.TabStop = false;
            this.pbATMDesconocido.DoubleClick += new System.EventHandler(this.pbATMDesconocido_DoubleClick);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(588, 514);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(684, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(489, 514);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(93, 40);
            this.btnRevisar.TabIndex = 3;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // frmImportacionCargas
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnRevisar);
            this.Controls.Add(this.gbEstados);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmImportacionCargas";
            this.Text = "Importar Cargas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbEstados.ResumeLayout(false);
            this.gbEstados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadCartuchos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorDenominacionCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorCantidadCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTipoCargaErronea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbATMDesconocido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.OpenFileDialog ofdArchivoCargas;
        private System.Windows.Forms.Label lblSegundaCelda;
        private System.Windows.Forms.Label lblPrimeraCelda;
        private System.Windows.Forms.MaskedTextBox mtbSegundaCelda;
        private System.Windows.Forms.MaskedTextBox mtbPrimeraCelda;
        private System.Windows.Forms.Label lblCeldaATM;
        private System.Windows.Forms.MaskedTextBox mtbCeldaATM;
        private System.Windows.Forms.Label lblCeldaFecha;
        private System.Windows.Forms.MaskedTextBox mtbCeldaFecha;
        private System.Windows.Forms.Label lblCeldaTipoATM;
        private System.Windows.Forms.MaskedTextBox mtbCeldaTipoATM;
        private System.Windows.Forms.GroupBox gbEstados;
        private System.Windows.Forms.Label lblATMDesconocido;
        private System.Windows.Forms.PictureBox pbATMDesconocido;
        private System.Windows.Forms.Label lblErrorCantidadCarga;
        private System.Windows.Forms.PictureBox pbErrorCantidadCarga;
        private System.Windows.Forms.Label lblTipoCargaErronea;
        private System.Windows.Forms.PictureBox pbTipoCargaErronea;
        private System.Windows.Forms.Label lblErrorDenominacionCarga;
        private System.Windows.Forms.PictureBox pbErrorDenominacionCarga;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.Label lblErrorCantidadCartuchos;
        private System.Windows.Forms.PictureBox pbErrorCantidadCartuchos;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadCartuchos;
    }
}