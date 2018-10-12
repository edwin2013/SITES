namespace GUILayer.Formularios.Facturacion
{
    partial class frmValidacionTarifasEnvios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidacionTarifasEnvios));
            this.lblVisitaNocturna = new System.Windows.Forms.Label();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.lblTipoCambio = new System.Windows.Forms.Label();
            this.lblMontoExcedente = new System.Windows.Forms.Label();
            this.lblMontoPlanilla = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.clmFech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPuntoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmManifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoExcedente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTarifaRegular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVisitaCompartida = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmVisitaNocturna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRecargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.lblCeldaATMA = new System.Windows.Forms.Label();
            this.lblTipoPunto = new System.Windows.Forms.Label();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.lblIDBac = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.lblCeldaTransportadora = new System.Windows.Forms.Label();
            this.mtbTransportadora = new System.Windows.Forms.MaskedTextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.mtbTotal = new System.Windows.Forms.MaskedTextBox();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.mtbRecargo = new System.Windows.Forms.MaskedTextBox();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbTipoCliente = new System.Windows.Forms.MaskedTextBox();
            this.mtbTipoServicio = new System.Windows.Forms.MaskedTextBox();
            this.lblIDPedido = new System.Windows.Forms.Label();
            this.mtbIDPedido = new System.Windows.Forms.MaskedTextBox();
            this.mtbVisitaNocturna = new System.Windows.Forms.MaskedTextBox();
            this.mtbTarifa = new System.Windows.Forms.MaskedTextBox();
            this.mtbTipoCambio = new System.Windows.Forms.MaskedTextBox();
            this.mtbMontoExcedente = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaMontoPlanilla = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaFecha = new System.Windows.Forms.MaskedTextBox();
            this.mtbManifiesto = new System.Windows.Forms.MaskedTextBox();
            this.mtbVisitaCompartida = new System.Windows.Forms.MaskedTextBox();
            this.mtbIDBac = new System.Windows.Forms.MaskedTextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbExportar = new System.Windows.Forms.GroupBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbCargas.SuspendLayout();
            this.gbArchivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbExportar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVisitaNocturna
            // 
            this.lblVisitaNocturna.AutoSize = true;
            this.lblVisitaNocturna.Location = new System.Drawing.Point(479, 68);
            this.lblVisitaNocturna.Name = "lblVisitaNocturna";
            this.lblVisitaNocturna.Size = new System.Drawing.Size(82, 13);
            this.lblVisitaNocturna.TabIndex = 22;
            this.lblVisitaNocturna.Text = "Visita Nocturna:";
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(502, 43);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(37, 13);
            this.lblTransportadora.TabIndex = 20;
            this.lblTransportadora.Text = "Tarifa:";
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.AutoSize = true;
            this.lblTipoCambio.Location = new System.Drawing.Point(314, 100);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(84, 13);
            this.lblTipoCambio.TabIndex = 18;
            this.lblTipoCambio.Text = "Tipo de Cambio:";
            // 
            // lblMontoExcedente
            // 
            this.lblMontoExcedente.AutoSize = true;
            this.lblMontoExcedente.Location = new System.Drawing.Point(314, 73);
            this.lblMontoExcedente.Name = "lblMontoExcedente";
            this.lblMontoExcedente.Size = new System.Drawing.Size(94, 13);
            this.lblMontoExcedente.TabIndex = 16;
            this.lblMontoExcedente.Text = "Monto Excedente:";
            // 
            // lblMontoPlanilla
            // 
            this.lblMontoPlanilla.AutoSize = true;
            this.lblMontoPlanilla.Location = new System.Drawing.Point(314, 48);
            this.lblMontoPlanilla.Name = "lblMontoPlanilla";
            this.lblMontoPlanilla.Size = new System.Drawing.Size(76, 13);
            this.lblMontoPlanilla.TabIndex = 14;
            this.lblMontoPlanilla.Text = "Monto Planilla:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(22, 48);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "Fecha:";
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
            this.clmTipoServicio,
            this.clmMontoPlanilla,
            this.clmMontoExcedente,
            this.clmTipoCambio,
            this.clmTarifaRegular,
            this.clmVisitaCompartida,
            this.clmVisitaNocturna,
            this.clmRecargo,
            this.clmTotal});
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.MultiSelect = false;
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCargas.Size = new System.Drawing.Size(1004, 263);
            this.dgvCargas.StandardTab = true;
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellDoubleClick);
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
            // clmTipoServicio
            // 
            this.clmTipoServicio.DataPropertyName = "EntregaRecibo";
            this.clmTipoServicio.HeaderText = "Tipo de Servicio";
            this.clmTipoServicio.Name = "clmTipoServicio";
            this.clmTipoServicio.ReadOnly = true;
            // 
            // clmMontoPlanilla
            // 
            this.clmMontoPlanilla.DataPropertyName = "MontoPlanilla";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.clmMontoPlanilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmMontoPlanilla.HeaderText = "Monto de Planilla";
            this.clmMontoPlanilla.Name = "clmMontoPlanilla";
            this.clmMontoPlanilla.ReadOnly = true;
            // 
            // clmMontoExcedente
            // 
            this.clmMontoExcedente.DataPropertyName = "MontoExcedente";
            this.clmMontoExcedente.HeaderText = "Monto Excedente";
            this.clmMontoExcedente.Name = "clmMontoExcedente";
            this.clmMontoExcedente.ReadOnly = true;
            // 
            // clmTipoCambio
            // 
            this.clmTipoCambio.DataPropertyName = "TipoCambio";
            this.clmTipoCambio.HeaderText = "Tipo de Cambio";
            this.clmTipoCambio.Name = "clmTipoCambio";
            this.clmTipoCambio.ReadOnly = true;
            // 
            // clmTarifaRegular
            // 
            this.clmTarifaRegular.DataPropertyName = "TarifaRegular";
            this.clmTarifaRegular.HeaderText = "Tarifa";
            this.clmTarifaRegular.Name = "clmTarifaRegular";
            this.clmTarifaRegular.ReadOnly = true;
            // 
            // clmVisitaCompartida
            // 
            this.clmVisitaCompartida.DataPropertyName = "VisitaCompartida";
            this.clmVisitaCompartida.HeaderText = "Visita Compartida";
            this.clmVisitaCompartida.Name = "clmVisitaCompartida";
            this.clmVisitaCompartida.ReadOnly = true;
            // 
            // clmVisitaNocturna
            // 
            this.clmVisitaNocturna.DataPropertyName = "VisitaNocturna";
            this.clmVisitaNocturna.HeaderText = "Visita Nocturna";
            this.clmVisitaNocturna.Name = "clmVisitaNocturna";
            this.clmVisitaNocturna.ReadOnly = true;
            this.clmVisitaNocturna.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmVisitaNocturna.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmRecargo
            // 
            this.clmRecargo.DataPropertyName = "Recargo";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.clmRecargo.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmRecargo.HeaderText = "Recargo";
            this.clmRecargo.Name = "clmRecargo";
            this.clmRecargo.ReadOnly = true;
            // 
            // clmTotal
            // 
            this.clmTotal.DataPropertyName = "TotalCobrar";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.clmTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(932, 585);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 17;
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
            this.gbCargas.Location = new System.Drawing.Point(12, 291);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(1016, 288);
            this.gbCargas.TabIndex = 15;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Puntos";
            // 
            // lblCeldaATMA
            // 
            this.lblCeldaATMA.AutoSize = true;
            this.lblCeldaATMA.Location = new System.Drawing.Point(163, 101);
            this.lblCeldaATMA.Name = "lblCeldaATMA";
            this.lblCeldaATMA.Size = new System.Drawing.Size(58, 13);
            this.lblCeldaATMA.TabIndex = 6;
            this.lblCeldaATMA.Text = "Manifiesto:";
            // 
            // lblTipoPunto
            // 
            this.lblTipoPunto.AutoSize = true;
            this.lblTipoPunto.Location = new System.Drawing.Point(479, 96);
            this.lblTipoPunto.Name = "lblTipoPunto";
            this.lblTipoPunto.Size = new System.Drawing.Size(94, 13);
            this.lblTipoPunto.TabIndex = 4;
            this.lblTipoPunto.Text = "Visita Compartida: ";
            // 
            // ofdMontosCargas
            // 
            this.ofdMontosCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
            // 
            // lblIDBac
            // 
            this.lblIDBac.AutoSize = true;
            this.lblIDBac.Location = new System.Drawing.Point(10, 74);
            this.lblIDBac.Name = "lblIDBac";
            this.lblIDBac.Size = new System.Drawing.Size(45, 13);
            this.lblIDBac.TabIndex = 2;
            this.lblIDBac.Text = "ID BAC:";
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
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(6, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(348, 20);
            this.txtArchivo.TabIndex = 0;
            // 
            // gbArchivo
            // 
            this.gbArchivo.Controls.Add(this.lblCeldaTransportadora);
            this.gbArchivo.Controls.Add(this.mtbTransportadora);
            this.gbArchivo.Controls.Add(this.lblTotal);
            this.gbArchivo.Controls.Add(this.mtbTotal);
            this.gbArchivo.Controls.Add(this.lblRecargo);
            this.gbArchivo.Controls.Add(this.mtbRecargo);
            this.gbArchivo.Controls.Add(this.lblTipoCliente);
            this.gbArchivo.Controls.Add(this.label3);
            this.gbArchivo.Controls.Add(this.mtbTipoCliente);
            this.gbArchivo.Controls.Add(this.mtbTipoServicio);
            this.gbArchivo.Controls.Add(this.lblIDPedido);
            this.gbArchivo.Controls.Add(this.mtbIDPedido);
            this.gbArchivo.Controls.Add(this.lblVisitaNocturna);
            this.gbArchivo.Controls.Add(this.mtbVisitaNocturna);
            this.gbArchivo.Controls.Add(this.lblTransportadora);
            this.gbArchivo.Controls.Add(this.mtbTarifa);
            this.gbArchivo.Controls.Add(this.lblTipoCambio);
            this.gbArchivo.Controls.Add(this.mtbTipoCambio);
            this.gbArchivo.Controls.Add(this.lblMontoExcedente);
            this.gbArchivo.Controls.Add(this.mtbMontoExcedente);
            this.gbArchivo.Controls.Add(this.lblMontoPlanilla);
            this.gbArchivo.Controls.Add(this.mtbCeldaMontoPlanilla);
            this.gbArchivo.Controls.Add(this.lblFecha);
            this.gbArchivo.Controls.Add(this.mtbCeldaFecha);
            this.gbArchivo.Controls.Add(this.lblCeldaATMA);
            this.gbArchivo.Controls.Add(this.mtbManifiesto);
            this.gbArchivo.Controls.Add(this.lblTipoPunto);
            this.gbArchivo.Controls.Add(this.lblIDBac);
            this.gbArchivo.Controls.Add(this.mtbVisitaCompartida);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbIDBac);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(18, 162);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(837, 123);
            this.gbArchivo.TabIndex = 14;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // lblCeldaTransportadora
            // 
            this.lblCeldaTransportadora.AutoSize = true;
            this.lblCeldaTransportadora.Location = new System.Drawing.Point(647, 96);
            this.lblCeldaTransportadora.Name = "lblCeldaTransportadora";
            this.lblCeldaTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblCeldaTransportadora.TabIndex = 36;
            this.lblCeldaTransportadora.Text = "Transportadora:";
            // 
            // mtbTransportadora
            // 
            this.mtbTransportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTransportadoraEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTransportadora.Location = new System.Drawing.Point(747, 95);
            this.mtbTransportadora.Mask = "aa99";
            this.mtbTransportadora.Name = "mtbTransportadora";
            this.mtbTransportadora.Size = new System.Drawing.Size(45, 20);
            this.mtbTransportadora.TabIndex = 37;
            this.mtbTransportadora.Text = global::GUILayer.Properties.Settings.Default.CeldaTransportadoraEnvio;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(664, 67);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 34;
            this.lblTotal.Text = "Total:";
            // 
            // mtbTotal
            // 
            this.mtbTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTotalEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTotal.Location = new System.Drawing.Point(747, 67);
            this.mtbTotal.Mask = "aa99";
            this.mtbTotal.Name = "mtbTotal";
            this.mtbTotal.Size = new System.Drawing.Size(45, 20);
            this.mtbTotal.TabIndex = 35;
            this.mtbTotal.Text = global::GUILayer.Properties.Settings.Default.CeldaTotalEnvio;
            // 
            // lblRecargo
            // 
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Location = new System.Drawing.Point(664, 45);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(51, 13);
            this.lblRecargo.TabIndex = 32;
            this.lblRecargo.Text = "Recargo:";
            // 
            // mtbRecargo
            // 
            this.mtbRecargo.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaRecargoEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbRecargo.Location = new System.Drawing.Point(747, 42);
            this.mtbRecargo.Mask = "aa99";
            this.mtbRecargo.Name = "mtbRecargo";
            this.mtbRecargo.Size = new System.Drawing.Size(45, 20);
            this.mtbRecargo.TabIndex = 33;
            this.mtbRecargo.Text = global::GUILayer.Properties.Settings.Default.CeldaRecargoEnvio;
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.Location = new System.Drawing.Point(157, 47);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(81, 13);
            this.lblTipoCliente.TabIndex = 28;
            this.lblTipoCliente.Text = "Tipo de Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tipo de Servicio:  ";
            // 
            // mtbTipoCliente
            // 
            this.mtbTipoCliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTipoClienteEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTipoCliente.Location = new System.Drawing.Point(244, 45);
            this.mtbTipoCliente.Mask = "aa99";
            this.mtbTipoCliente.Name = "mtbTipoCliente";
            this.mtbTipoCliente.Size = new System.Drawing.Size(45, 20);
            this.mtbTipoCliente.TabIndex = 29;
            this.mtbTipoCliente.Text = global::GUILayer.Properties.Settings.Default.CeldaTipoClienteEnvio;
            // 
            // mtbTipoServicio
            // 
            this.mtbTipoServicio.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTipoServicioEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTipoServicio.Location = new System.Drawing.Point(244, 71);
            this.mtbTipoServicio.Mask = "aa99";
            this.mtbTipoServicio.Name = "mtbTipoServicio";
            this.mtbTipoServicio.Size = new System.Drawing.Size(45, 20);
            this.mtbTipoServicio.TabIndex = 31;
            this.mtbTipoServicio.Text = global::GUILayer.Properties.Settings.Default.CeldaTipoServicioEnvio;
            // 
            // lblIDPedido
            // 
            this.lblIDPedido.AutoSize = true;
            this.lblIDPedido.Location = new System.Drawing.Point(3, 101);
            this.lblIDPedido.Name = "lblIDPedido";
            this.lblIDPedido.Size = new System.Drawing.Size(57, 13);
            this.lblIDPedido.TabIndex = 24;
            this.lblIDPedido.Text = "ID Pedido:";
            // 
            // mtbIDPedido
            // 
            this.mtbIDPedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaIDPedidoEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbIDPedido.Location = new System.Drawing.Point(92, 97);
            this.mtbIDPedido.Mask = "aa99";
            this.mtbIDPedido.Name = "mtbIDPedido";
            this.mtbIDPedido.Size = new System.Drawing.Size(45, 20);
            this.mtbIDPedido.TabIndex = 25;
            this.mtbIDPedido.Text = global::GUILayer.Properties.Settings.Default.CeldaIDPedidoEnvio;
            // 
            // mtbVisitaNocturna
            // 
            this.mtbVisitaNocturna.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaVisitaNocturnaEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbVisitaNocturna.Location = new System.Drawing.Point(579, 67);
            this.mtbVisitaNocturna.Mask = "aa99";
            this.mtbVisitaNocturna.Name = "mtbVisitaNocturna";
            this.mtbVisitaNocturna.Size = new System.Drawing.Size(45, 20);
            this.mtbVisitaNocturna.TabIndex = 23;
            this.mtbVisitaNocturna.Text = global::GUILayer.Properties.Settings.Default.CeldaVisitaNocturnaEnvio;
            // 
            // mtbTarifa
            // 
            this.mtbTarifa.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTarifaNiquelEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTarifa.Location = new System.Drawing.Point(579, 42);
            this.mtbTarifa.Mask = "aa99";
            this.mtbTarifa.Name = "mtbTarifa";
            this.mtbTarifa.Size = new System.Drawing.Size(45, 20);
            this.mtbTarifa.TabIndex = 21;
            this.mtbTarifa.Text = global::GUILayer.Properties.Settings.Default.CeldaTarifaNiquelEnvio;
            // 
            // mtbTipoCambio
            // 
            this.mtbTipoCambio.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTipoCambioEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTipoCambio.Location = new System.Drawing.Point(414, 96);
            this.mtbTipoCambio.Mask = "aa99";
            this.mtbTipoCambio.Name = "mtbTipoCambio";
            this.mtbTipoCambio.Size = new System.Drawing.Size(45, 20);
            this.mtbTipoCambio.TabIndex = 19;
            this.mtbTipoCambio.Text = global::GUILayer.Properties.Settings.Default.CeldaTipoCambioEnvio;
            // 
            // mtbMontoExcedente
            // 
            this.mtbMontoExcedente.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaMontoExcedenteEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbMontoExcedente.Location = new System.Drawing.Point(414, 70);
            this.mtbMontoExcedente.Mask = "aa99";
            this.mtbMontoExcedente.Name = "mtbMontoExcedente";
            this.mtbMontoExcedente.Size = new System.Drawing.Size(45, 20);
            this.mtbMontoExcedente.TabIndex = 17;
            this.mtbMontoExcedente.Text = global::GUILayer.Properties.Settings.Default.CeldaMontoExcedenteEnvio;
            // 
            // mtbCeldaMontoPlanilla
            // 
            this.mtbCeldaMontoPlanilla.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaMontoEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaMontoPlanilla.Location = new System.Drawing.Point(414, 43);
            this.mtbCeldaMontoPlanilla.Mask = "aa99";
            this.mtbCeldaMontoPlanilla.Name = "mtbCeldaMontoPlanilla";
            this.mtbCeldaMontoPlanilla.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaMontoPlanilla.TabIndex = 15;
            this.mtbCeldaMontoPlanilla.Text = global::GUILayer.Properties.Settings.Default.CeldaMontoEnvio;
            // 
            // mtbCeldaFecha
            // 
            this.mtbCeldaFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaFechaTarifaEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaFecha.Location = new System.Drawing.Point(91, 44);
            this.mtbCeldaFecha.Mask = "aa99";
            this.mtbCeldaFecha.Name = "mtbCeldaFecha";
            this.mtbCeldaFecha.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaFecha.TabIndex = 13;
            this.mtbCeldaFecha.Text = global::GUILayer.Properties.Settings.Default.CeldaFechaTarifaEnvio;
            // 
            // mtbManifiesto
            // 
            this.mtbManifiesto.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaPlanillaEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbManifiesto.Location = new System.Drawing.Point(244, 97);
            this.mtbManifiesto.Mask = "aa99";
            this.mtbManifiesto.Name = "mtbManifiesto";
            this.mtbManifiesto.Size = new System.Drawing.Size(45, 20);
            this.mtbManifiesto.TabIndex = 7;
            this.mtbManifiesto.Text = global::GUILayer.Properties.Settings.Default.CeldaPlanillaEnvio;
            // 
            // mtbVisitaCompartida
            // 
            this.mtbVisitaCompartida.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaVisitaCompartidaEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbVisitaCompartida.Location = new System.Drawing.Point(579, 93);
            this.mtbVisitaCompartida.Mask = "aa99";
            this.mtbVisitaCompartida.Name = "mtbVisitaCompartida";
            this.mtbVisitaCompartida.Size = new System.Drawing.Size(45, 20);
            this.mtbVisitaCompartida.TabIndex = 5;
            this.mtbVisitaCompartida.Text = global::GUILayer.Properties.Settings.Default.CeldaVisitaCompartidaEnvio;
            // 
            // mtbIDBac
            // 
            this.mtbIDBac.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaIDBACEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbIDBac.Location = new System.Drawing.Point(91, 70);
            this.mtbIDBac.Mask = "aa99";
            this.mtbIDBac.Name = "mtbIDBac";
            this.mtbIDBac.Size = new System.Drawing.Size(45, 20);
            this.mtbIDBac.TabIndex = 3;
            this.mtbIDBac.Text = global::GUILayer.Properties.Settings.Default.CeldaIDBACEnvio;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(821, 585);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1040, 60);
            this.pnlFondo.TabIndex = 13;
            // 
            // gbExportar
            // 
            this.gbExportar.Controls.Add(this.cboTipo);
            this.gbExportar.Controls.Add(this.lblTipo);
            this.gbExportar.Controls.Add(this.label1);
            this.gbExportar.Controls.Add(this.cboTransportadora);
            this.gbExportar.Controls.Add(this.btnExportar);
            this.gbExportar.Controls.Add(this.lblFechaFin);
            this.gbExportar.Controls.Add(this.lblFechaInicio);
            this.gbExportar.Controls.Add(this.dtpFechaFin);
            this.gbExportar.Controls.Add(this.dtpFechaInicio);
            this.gbExportar.Location = new System.Drawing.Point(16, 66);
            this.gbExportar.Name = "gbExportar";
            this.gbExportar.Size = new System.Drawing.Size(950, 90);
            this.gbExportar.TabIndex = 18;
            this.gbExportar.TabStop = false;
            this.gbExportar.Text = "Exportar";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Ambos",
            "Cliente",
            "Sucursal"});
            this.cboTipo.Location = new System.Drawing.Point(429, 57);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(174, 21);
            this.cboTipo.TabIndex = 22;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(392, 61);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 21;
            this.lblTipo.Text = "Tipo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Transportadora:";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.FormattingEnabled = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(124, 63);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(232, 21);
            this.cboTransportadora.TabIndex = 18;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Location = new System.Drawing.Point(805, 23);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(90, 40);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(328, 37);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(54, 13);
            this.lblFechaFin.TabIndex = 3;
            this.lblFechaFin.Text = "Fecha Fin";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(17, 37);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(403, 31);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(93, 31);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 0;
            // 
            // frmValidacionTarifasEnvios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 637);
            this.Controls.Add(this.gbExportar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmValidacionTarifasEnvios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación Envíos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbCargas.ResumeLayout(false);
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbExportar.ResumeLayout(false);
            this.gbExportar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblVisitaNocturna;
        private System.Windows.Forms.MaskedTextBox mtbVisitaNocturna;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.MaskedTextBox mtbTarifa;
        private System.Windows.Forms.Label lblTipoCambio;
        private System.Windows.Forms.MaskedTextBox mtbTipoCambio;
        private System.Windows.Forms.Label lblMontoExcedente;
        private System.Windows.Forms.Label lblMontoPlanilla;
        private System.Windows.Forms.MaskedTextBox mtbCeldaMontoPlanilla;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.MaskedTextBox mtbMontoExcedente;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.MaskedTextBox mtbCeldaFecha;
        private System.Windows.Forms.MaskedTextBox mtbManifiesto;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.Label lblCeldaATMA;
        private System.Windows.Forms.Label lblTipoPunto;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
        private System.Windows.Forms.Label lblIDBac;
        private System.Windows.Forms.MaskedTextBox mtbVisitaCompartida;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.MaskedTextBox mtbIDBac;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbExportar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label1;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblIDPedido;
        private System.Windows.Forms.MaskedTextBox mtbIDPedido;
        private System.Windows.Forms.Label lblTipoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbTipoCliente;
        private System.Windows.Forms.MaskedTextBox mtbTipoServicio;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MaskedTextBox mtbTotal;
        private System.Windows.Forms.Label lblRecargo;
        private System.Windows.Forms.MaskedTextBox mtbRecargo;
        private System.Windows.Forms.Label lblCeldaTransportadora;
        private System.Windows.Forms.MaskedTextBox mtbTransportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFech;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPuntoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmManifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoExcedente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTarifaRegular;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmVisitaCompartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVisitaNocturna;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRecargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblTipo;
    }
}