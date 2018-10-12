namespace GUILayer.Formularios.Facturacion
{
    partial class frmValidacionFacturacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidacionFacturacion));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.lblVisitaNocturna = new System.Windows.Forms.Label();
            this.mtbVisitaNocturna = new System.Windows.Forms.MaskedTextBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.mtbTransportadora = new System.Windows.Forms.MaskedTextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.mtbTotal = new System.Windows.Forms.MaskedTextBox();
            this.lblTula = new System.Windows.Forms.Label();
            this.mtbCeldaTula = new System.Windows.Forms.MaskedTextBox();
            this.lblMontoPlanilla = new System.Windows.Forms.Label();
            this.mtbCeldaMontoPlanilla = new System.Windows.Forms.MaskedTextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.mtbCeldaFecha = new System.Windows.Forms.MaskedTextBox();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.mtbCeldaTarifa = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaRecargo = new System.Windows.Forms.MaskedTextBox();
            this.lblCeldaATMA = new System.Windows.Forms.Label();
            this.mtbManifiesto = new System.Windows.Forms.MaskedTextBox();
            this.lblTipoPunto = new System.Windows.Forms.Label();
            this.lblIDBac = new System.Windows.Forms.Label();
            this.mtbTipoPunto = new System.Windows.Forms.MaskedTextBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.mtbIDBac = new System.Windows.Forms.MaskedTextBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.clmFech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPuntoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmManifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTarifaRegular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRecargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbArchivo.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(588, 520);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
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
            this.gbArchivo.Controls.Add(this.lblVisitaNocturna);
            this.gbArchivo.Controls.Add(this.mtbVisitaNocturna);
            this.gbArchivo.Controls.Add(this.lblTransportadora);
            this.gbArchivo.Controls.Add(this.mtbTransportadora);
            this.gbArchivo.Controls.Add(this.lblTotal);
            this.gbArchivo.Controls.Add(this.mtbTotal);
            this.gbArchivo.Controls.Add(this.lblTula);
            this.gbArchivo.Controls.Add(this.mtbCeldaTula);
            this.gbArchivo.Controls.Add(this.lblMontoPlanilla);
            this.gbArchivo.Controls.Add(this.mtbCeldaMontoPlanilla);
            this.gbArchivo.Controls.Add(this.lblFecha);
            this.gbArchivo.Controls.Add(this.mtbCeldaFecha);
            this.gbArchivo.Controls.Add(this.lblTarifa);
            this.gbArchivo.Controls.Add(this.lblRecargo);
            this.gbArchivo.Controls.Add(this.mtbCeldaTarifa);
            this.gbArchivo.Controls.Add(this.mtbCeldaRecargo);
            this.gbArchivo.Controls.Add(this.lblCeldaATMA);
            this.gbArchivo.Controls.Add(this.mtbManifiesto);
            this.gbArchivo.Controls.Add(this.lblTipoPunto);
            this.gbArchivo.Controls.Add(this.lblIDBac);
            this.gbArchivo.Controls.Add(this.mtbTipoPunto);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbIDBac);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(12, 72);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(768, 123);
            this.gbArchivo.TabIndex = 7;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // lblVisitaNocturna
            // 
            this.lblVisitaNocturna.AutoSize = true;
            this.lblVisitaNocturna.Location = new System.Drawing.Point(430, 77);
            this.lblVisitaNocturna.Name = "lblVisitaNocturna";
            this.lblVisitaNocturna.Size = new System.Drawing.Size(82, 13);
            this.lblVisitaNocturna.TabIndex = 22;
            this.lblVisitaNocturna.Text = "Visita Nocturna:";
            // 
            // mtbVisitaNocturna
            // 
            this.mtbVisitaNocturna.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTrasnportadoraPlanillas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbVisitaNocturna.Location = new System.Drawing.Point(518, 75);
            this.mtbVisitaNocturna.Mask = "aa99";
            this.mtbVisitaNocturna.Name = "mtbVisitaNocturna";
            this.mtbVisitaNocturna.Size = new System.Drawing.Size(45, 20);
            this.mtbVisitaNocturna.TabIndex = 23;
            this.mtbVisitaNocturna.Text = global::GUILayer.Properties.Settings.Default.CeldaTrasnportadoraPlanillas;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(430, 48);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 20;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // mtbTransportadora
            // 
            this.mtbTransportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTrasnportadoraPlanillas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTransportadora.Location = new System.Drawing.Point(518, 46);
            this.mtbTransportadora.Mask = "aa99";
            this.mtbTransportadora.Name = "mtbTransportadora";
            this.mtbTransportadora.Size = new System.Drawing.Size(45, 20);
            this.mtbTransportadora.TabIndex = 21;
            this.mtbTransportadora.Text = global::GUILayer.Properties.Settings.Default.CeldaTrasnportadoraPlanillas;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(293, 100);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 18;
            this.lblTotal.Text = "Total:";
            // 
            // mtbTotal
            // 
            this.mtbTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTotal.Location = new System.Drawing.Point(368, 98);
            this.mtbTotal.Mask = "aa99";
            this.mtbTotal.Name = "mtbTotal";
            this.mtbTotal.Size = new System.Drawing.Size(45, 20);
            this.mtbTotal.TabIndex = 19;
            this.mtbTotal.Text = global::GUILayer.Properties.Settings.Default.CeldaTotal;
            // 
            // lblTula
            // 
            this.lblTula.AutoSize = true;
            this.lblTula.Location = new System.Drawing.Point(293, 75);
            this.lblTula.Name = "lblTula";
            this.lblTula.Size = new System.Drawing.Size(31, 13);
            this.lblTula.TabIndex = 16;
            this.lblTula.Text = "Tula:";
            // 
            // mtbCeldaTula
            // 
            this.mtbCeldaTula.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTulaFacturacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaTula.Location = new System.Drawing.Point(368, 72);
            this.mtbCeldaTula.Mask = "aa99";
            this.mtbCeldaTula.Name = "mtbCeldaTula";
            this.mtbCeldaTula.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaTula.TabIndex = 17;
            this.mtbCeldaTula.Text = global::GUILayer.Properties.Settings.Default.CeldaTulaFacturacion;
            // 
            // lblMontoPlanilla
            // 
            this.lblMontoPlanilla.AutoSize = true;
            this.lblMontoPlanilla.Location = new System.Drawing.Point(293, 49);
            this.lblMontoPlanilla.Name = "lblMontoPlanilla";
            this.lblMontoPlanilla.Size = new System.Drawing.Size(76, 13);
            this.lblMontoPlanilla.TabIndex = 14;
            this.lblMontoPlanilla.Text = "Monto Planilla:";
            // 
            // mtbCeldaMontoPlanilla
            // 
            this.mtbCeldaMontoPlanilla.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaMontoPlanillas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaMontoPlanilla.Location = new System.Drawing.Point(368, 46);
            this.mtbCeldaMontoPlanilla.Mask = "aa99";
            this.mtbCeldaMontoPlanilla.Name = "mtbCeldaMontoPlanilla";
            this.mtbCeldaMontoPlanilla.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaMontoPlanilla.TabIndex = 15;
            this.mtbCeldaMontoPlanilla.Text = global::GUILayer.Properties.Settings.Default.CeldaMontoPlanillas;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(161, 101);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "Fecha:";
            // 
            // mtbCeldaFecha
            // 
            this.mtbCeldaFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaFechaFacturacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaFecha.Location = new System.Drawing.Point(230, 97);
            this.mtbCeldaFecha.Mask = "aa99";
            this.mtbCeldaFecha.Name = "mtbCeldaFecha";
            this.mtbCeldaFecha.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaFecha.TabIndex = 13;
            this.mtbCeldaFecha.Text = global::GUILayer.Properties.Settings.Default.CeldaFechaFacturacion;
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Location = new System.Drawing.Point(161, 48);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(37, 13);
            this.lblTarifa.TabIndex = 8;
            this.lblTarifa.Text = "Tarifa:";
            // 
            // lblRecargo
            // 
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Location = new System.Drawing.Point(161, 75);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(51, 13);
            this.lblRecargo.TabIndex = 10;
            this.lblRecargo.Text = "Recargo:";
            // 
            // mtbCeldaTarifa
            // 
            this.mtbCeldaTarifa.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTarifa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaTarifa.Location = new System.Drawing.Point(230, 45);
            this.mtbCeldaTarifa.Mask = "aa99";
            this.mtbCeldaTarifa.Name = "mtbCeldaTarifa";
            this.mtbCeldaTarifa.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaTarifa.TabIndex = 9;
            this.mtbCeldaTarifa.Text = global::GUILayer.Properties.Settings.Default.CeldaTarifa;
            // 
            // mtbCeldaRecargo
            // 
            this.mtbCeldaRecargo.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaRecargo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaRecargo.Location = new System.Drawing.Point(230, 71);
            this.mtbCeldaRecargo.Mask = "aa99";
            this.mtbCeldaRecargo.Name = "mtbCeldaRecargo";
            this.mtbCeldaRecargo.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaRecargo.TabIndex = 11;
            this.mtbCeldaRecargo.Text = global::GUILayer.Properties.Settings.Default.CeldaRecargo;
            // 
            // lblCeldaATMA
            // 
            this.lblCeldaATMA.AutoSize = true;
            this.lblCeldaATMA.Location = new System.Drawing.Point(14, 101);
            this.lblCeldaATMA.Name = "lblCeldaATMA";
            this.lblCeldaATMA.Size = new System.Drawing.Size(58, 13);
            this.lblCeldaATMA.TabIndex = 6;
            this.lblCeldaATMA.Text = "Manifiesto:";
            // 
            // mtbManifiesto
            // 
            this.mtbManifiesto.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaManifiesto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbManifiesto.Location = new System.Drawing.Point(95, 97);
            this.mtbManifiesto.Mask = "aa99";
            this.mtbManifiesto.Name = "mtbManifiesto";
            this.mtbManifiesto.Size = new System.Drawing.Size(45, 20);
            this.mtbManifiesto.TabIndex = 7;
            this.mtbManifiesto.Text = global::GUILayer.Properties.Settings.Default.CeldaManifiesto;
            // 
            // lblTipoPunto
            // 
            this.lblTipoPunto.AutoSize = true;
            this.lblTipoPunto.Location = new System.Drawing.Point(6, 75);
            this.lblTipoPunto.Name = "lblTipoPunto";
            this.lblTipoPunto.Size = new System.Drawing.Size(77, 13);
            this.lblTipoPunto.TabIndex = 4;
            this.lblTipoPunto.Text = "Tipo de Punto:";
            // 
            // lblIDBac
            // 
            this.lblIDBac.AutoSize = true;
            this.lblIDBac.Location = new System.Drawing.Point(14, 49);
            this.lblIDBac.Name = "lblIDBac";
            this.lblIDBac.Size = new System.Drawing.Size(45, 13);
            this.lblIDBac.TabIndex = 2;
            this.lblIDBac.Text = "ID BAC:";
            // 
            // mtbTipoPunto
            // 
            this.mtbTipoPunto.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTipoPunto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTipoPunto.Location = new System.Drawing.Point(95, 71);
            this.mtbTipoPunto.Mask = "aa99";
            this.mtbTipoPunto.Name = "mtbTipoPunto";
            this.mtbTipoPunto.Size = new System.Drawing.Size(45, 20);
            this.mtbTipoPunto.TabIndex = 5;
            this.mtbTipoPunto.Text = global::GUILayer.Properties.Settings.Default.CeldaTipoPunto;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(360, 19);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(45, 20);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "...";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // mtbIDBac
            // 
            this.mtbIDBac.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaIDBAC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbIDBac.Location = new System.Drawing.Point(95, 45);
            this.mtbIDBac.Mask = "aa99";
            this.mtbIDBac.Name = "mtbIDBac";
            this.mtbIDBac.Size = new System.Drawing.Size(45, 20);
            this.mtbIDBac.TabIndex = 3;
            this.mtbIDBac.Text = global::GUILayer.Properties.Settings.Default.CeldaIDBAC;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(6, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(348, 20);
            this.txtArchivo.TabIndex = 0;
            // 
            // ofdMontosCargas
            // 
            this.ofdMontosCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
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
            this.pnlFondo.TabIndex = 6;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(684, 520);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 201);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(768, 313);
            this.gbCargas.TabIndex = 9;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Puntos";
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
            this.clmFech,
            this.clmID,
            this.clmPuntoVenta,
            this.clmNombre,
            this.clmManifiesto,
            this.clmTula,
            this.clmTarifaRegular,
            this.clmRecargo,
            this.clmMontoPlanilla,
            this.clmTotal});
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.MultiSelect = false;
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCargas.Size = new System.Drawing.Size(756, 288);
            this.dgvCargas.StandardTab = true;
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // clmFech
            // 
            this.clmFech.DataPropertyName = "FechaPlanilla";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.clmFech.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmFech.HeaderText = "Fecha";
            this.clmFech.Name = "clmFech";
            this.clmFech.ReadOnly = true;
            // 
            // clmID
            // 
            this.clmID.DataPropertyName = "IDSites";
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            // 
            // clmPuntoVenta
            // 
            this.clmPuntoVenta.DataPropertyName = "TipoPuntodeAtencion";
            this.clmPuntoVenta.HeaderText = "PDV";
            this.clmPuntoVenta.Name = "clmPuntoVenta";
            this.clmPuntoVenta.ReadOnly = true;
            // 
            // clmNombre
            // 
            this.clmNombre.DataPropertyName = "Nombre";
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            // 
            // clmManifiesto
            // 
            this.clmManifiesto.DataPropertyName = "Manifiesto";
            this.clmManifiesto.HeaderText = "Planilla";
            this.clmManifiesto.Name = "clmManifiesto";
            this.clmManifiesto.ReadOnly = true;
            // 
            // clmTula
            // 
            this.clmTula.DataPropertyName = "Tula";
            this.clmTula.HeaderText = "Tula";
            this.clmTula.Name = "clmTula";
            this.clmTula.ReadOnly = true;
            // 
            // clmTarifaRegular
            // 
            this.clmTarifaRegular.DataPropertyName = "TarifaRegular";
            this.clmTarifaRegular.HeaderText = "Tarifa";
            this.clmTarifaRegular.Name = "clmTarifaRegular";
            this.clmTarifaRegular.ReadOnly = true;
            // 
            // clmRecargo
            // 
            this.clmRecargo.DataPropertyName = "Recargo";
            this.clmRecargo.HeaderText = "Recargo";
            this.clmRecargo.Name = "clmRecargo";
            this.clmRecargo.ReadOnly = true;
            // 
            // clmMontoPlanilla
            // 
            this.clmMontoPlanilla.DataPropertyName = "MontoPlanilla";
            this.clmMontoPlanilla.HeaderText = "Monto de Planilla";
            this.clmMontoPlanilla.Name = "clmMontoPlanilla";
            this.clmMontoPlanilla.ReadOnly = true;
            // 
            // clmTotal
            // 
            this.clmTotal.DataPropertyName = "TotalCobrar";
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            // 
            // frmValidacionFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbCargas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmValidacionFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validación de Facturación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblRecargo;
        private System.Windows.Forms.MaskedTextBox mtbCeldaTarifa;
        private System.Windows.Forms.MaskedTextBox mtbCeldaRecargo;
        private System.Windows.Forms.Label lblCeldaATMA;
        private System.Windows.Forms.MaskedTextBox mtbManifiesto;
        private System.Windows.Forms.Label lblTipoPunto;
        private System.Windows.Forms.Label lblIDBac;
        private System.Windows.Forms.MaskedTextBox mtbTipoPunto;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.MaskedTextBox mtbIDBac;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.MaskedTextBox mtbCeldaFecha;
        private System.Windows.Forms.Label lblTula;
        private System.Windows.Forms.MaskedTextBox mtbCeldaTula;
        private System.Windows.Forms.Label lblMontoPlanilla;
        private System.Windows.Forms.MaskedTextBox mtbCeldaMontoPlanilla;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MaskedTextBox mtbTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFech;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPuntoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmManifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTula;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTarifaRegular;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRecargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.MaskedTextBox mtbTransportadora;
        private System.Windows.Forms.Label lblVisitaNocturna;
        private System.Windows.Forms.MaskedTextBox mtbVisitaNocturna;

    }
}