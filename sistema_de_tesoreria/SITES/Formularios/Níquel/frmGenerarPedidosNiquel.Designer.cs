namespace GUILayer.Formularios.Níquel
{
    partial class frmGenerarPedidosNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarPedidosNiquel));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.lblCeldaTransportadora = new System.Windows.Forms.Label();
            this.mtbCeldaTransportadora = new System.Windows.Forms.MaskedTextBox();
            this.lblCeldaDenDolaresA = new System.Windows.Forms.Label();
            this.lblDenDolaresB = new System.Windows.Forms.Label();
            this.mtbPrimeraDenDolaresA = new System.Windows.Forms.MaskedTextBox();
            this.mtbSegundaDenDolares = new System.Windows.Forms.MaskedTextBox();
            this.lblCeldaClienteA = new System.Windows.Forms.Label();
            this.lblCeldaFecha = new System.Windows.Forms.Label();
            this.mtbCeldaClienteA = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaFecha = new System.Windows.Forms.MaskedTextBox();
            this.lblSegundaCelda = new System.Windows.Forms.Label();
            this.lblDenominacionColones = new System.Windows.Forms.Label();
            this.mtbSegundaDenColones = new System.Windows.Forms.MaskedTextBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.mtbPrimeraDenColones = new System.Windows.Forms.MaskedTextBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.ATM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoPedidoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoPedidoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denominaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gbArchivo.Controls.Add(this.lblCeldaTransportadora);
            this.gbArchivo.Controls.Add(this.mtbCeldaTransportadora);
            this.gbArchivo.Controls.Add(this.lblCeldaDenDolaresA);
            this.gbArchivo.Controls.Add(this.lblDenDolaresB);
            this.gbArchivo.Controls.Add(this.mtbPrimeraDenDolaresA);
            this.gbArchivo.Controls.Add(this.mtbSegundaDenDolares);
            this.gbArchivo.Controls.Add(this.lblCeldaClienteA);
            this.gbArchivo.Controls.Add(this.lblCeldaFecha);
            this.gbArchivo.Controls.Add(this.mtbCeldaClienteA);
            this.gbArchivo.Controls.Add(this.mtbCeldaFecha);
            this.gbArchivo.Controls.Add(this.lblSegundaCelda);
            this.gbArchivo.Controls.Add(this.lblDenominacionColones);
            this.gbArchivo.Controls.Add(this.mtbSegundaDenColones);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbPrimeraDenColones);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(12, 72);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(584, 123);
            this.gbArchivo.TabIndex = 7;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // lblCeldaTransportadora
            // 
            this.lblCeldaTransportadora.AutoSize = true;
            this.lblCeldaTransportadora.Location = new System.Drawing.Point(147, 100);
            this.lblCeldaTransportadora.Name = "lblCeldaTransportadora";
            this.lblCeldaTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblCeldaTransportadora.TabIndex = 18;
            this.lblCeldaTransportadora.Text = "Transportadora:";
            // 
            // mtbCeldaTransportadora
            // 
            this.mtbCeldaTransportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTransportadoraNiquel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaTransportadora.Location = new System.Drawing.Point(230, 96);
            this.mtbCeldaTransportadora.Mask = "aa99";
            this.mtbCeldaTransportadora.Name = "mtbCeldaTransportadora";
            this.mtbCeldaTransportadora.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaTransportadora.TabIndex = 19;
            this.mtbCeldaTransportadora.Text = global::GUILayer.Properties.Settings.Default.CeldaTransportadoraNiquel;
            // 
            // lblCeldaDenDolaresA
            // 
            this.lblCeldaDenDolaresA.AutoSize = true;
            this.lblCeldaDenDolaresA.Location = new System.Drawing.Point(147, 49);
            this.lblCeldaDenDolaresA.Name = "lblCeldaDenDolaresA";
            this.lblCeldaDenDolaresA.Size = new System.Drawing.Size(82, 13);
            this.lblCeldaDenDolaresA.TabIndex = 8;
            this.lblCeldaDenDolaresA.Text = "Den. Dolares A:";
            // 
            // lblDenDolaresB
            // 
            this.lblDenDolaresB.AutoSize = true;
            this.lblDenDolaresB.Location = new System.Drawing.Point(147, 75);
            this.lblDenDolaresB.Name = "lblDenDolaresB";
            this.lblDenDolaresB.Size = new System.Drawing.Size(82, 13);
            this.lblDenDolaresB.TabIndex = 10;
            this.lblDenDolaresB.Text = "Den. Dolares B:";
            // 
            // mtbPrimeraDenDolaresA
            // 
            this.mtbPrimeraDenDolaresA.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaPrimeraDenominacionDolaresNiquel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbPrimeraDenDolaresA.Location = new System.Drawing.Point(230, 45);
            this.mtbPrimeraDenDolaresA.Mask = "aa99";
            this.mtbPrimeraDenDolaresA.Name = "mtbPrimeraDenDolaresA";
            this.mtbPrimeraDenDolaresA.Size = new System.Drawing.Size(45, 20);
            this.mtbPrimeraDenDolaresA.TabIndex = 9;
            this.mtbPrimeraDenDolaresA.Text = global::GUILayer.Properties.Settings.Default.CeldaPrimeraDenominacionDolaresNiquel;
            // 
            // mtbSegundaDenDolares
            // 
            this.mtbSegundaDenDolares.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSegundaDenominacionDolaresNiquel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbSegundaDenDolares.Location = new System.Drawing.Point(230, 71);
            this.mtbSegundaDenDolares.Mask = "aa99";
            this.mtbSegundaDenDolares.Name = "mtbSegundaDenDolares";
            this.mtbSegundaDenDolares.Size = new System.Drawing.Size(45, 20);
            this.mtbSegundaDenDolares.TabIndex = 11;
            this.mtbSegundaDenDolares.Text = global::GUILayer.Properties.Settings.Default.CeldaSegundaDenominacionDolaresNiquel;
            // 
            // lblCeldaClienteA
            // 
            this.lblCeldaClienteA.AutoSize = true;
            this.lblCeldaClienteA.Location = new System.Drawing.Point(6, 102);
            this.lblCeldaClienteA.Name = "lblCeldaClienteA";
            this.lblCeldaClienteA.Size = new System.Drawing.Size(72, 13);
            this.lblCeldaClienteA.TabIndex = 6;
            this.lblCeldaClienteA.Text = "Celda Cliente:";
            // 
            // lblCeldaFecha
            // 
            this.lblCeldaFecha.AutoSize = true;
            this.lblCeldaFecha.Location = new System.Drawing.Point(306, 50);
            this.lblCeldaFecha.Name = "lblCeldaFecha";
            this.lblCeldaFecha.Size = new System.Drawing.Size(70, 13);
            this.lblCeldaFecha.TabIndex = 14;
            this.lblCeldaFecha.Text = "Celda Fecha:";
            // 
            // mtbCeldaClienteA
            // 
            this.mtbCeldaClienteA.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaClienteNiquel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaClienteA.Location = new System.Drawing.Point(95, 97);
            this.mtbCeldaClienteA.Mask = "aa99";
            this.mtbCeldaClienteA.Name = "mtbCeldaClienteA";
            this.mtbCeldaClienteA.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaClienteA.TabIndex = 7;
            this.mtbCeldaClienteA.Text = global::GUILayer.Properties.Settings.Default.CeldaClienteNiquel;
            // 
            // mtbCeldaFecha
            // 
            this.mtbCeldaFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaFechaNiquel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaFecha.Location = new System.Drawing.Point(382, 46);
            this.mtbCeldaFecha.Mask = "aa99";
            this.mtbCeldaFecha.Name = "mtbCeldaFecha";
            this.mtbCeldaFecha.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaFecha.TabIndex = 15;
            this.mtbCeldaFecha.Text = global::GUILayer.Properties.Settings.Default.CeldaFechaNiquel;
            // 
            // lblSegundaCelda
            // 
            this.lblSegundaCelda.AutoSize = true;
            this.lblSegundaCelda.Location = new System.Drawing.Point(6, 75);
            this.lblSegundaCelda.Name = "lblSegundaCelda";
            this.lblSegundaCelda.Size = new System.Drawing.Size(81, 13);
            this.lblSegundaCelda.TabIndex = 4;
            this.lblSegundaCelda.Text = "Den Colones B:";
            // 
            // lblDenominacionColones
            // 
            this.lblDenominacionColones.AutoSize = true;
            this.lblDenominacionColones.Location = new System.Drawing.Point(6, 48);
            this.lblDenominacionColones.Name = "lblDenominacionColones";
            this.lblDenominacionColones.Size = new System.Drawing.Size(84, 13);
            this.lblDenominacionColones.TabIndex = 2;
            this.lblDenominacionColones.Text = "Den. Colones A:";
            // 
            // mtbSegundaDenColones
            // 
            this.mtbSegundaDenColones.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSegundaDenominacionColonesNiquel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbSegundaDenColones.Location = new System.Drawing.Point(95, 71);
            this.mtbSegundaDenColones.Mask = "aa99";
            this.mtbSegundaDenColones.Name = "mtbSegundaDenColones";
            this.mtbSegundaDenColones.Size = new System.Drawing.Size(45, 20);
            this.mtbSegundaDenColones.TabIndex = 5;
            this.mtbSegundaDenColones.Text = global::GUILayer.Properties.Settings.Default.CeldaSegundaDenominacionColonesNiquel;
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
            // mtbPrimeraDenColones
            // 
            this.mtbPrimeraDenColones.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaPrimeraDenominacionColonesNiquel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbPrimeraDenColones.Location = new System.Drawing.Point(95, 45);
            this.mtbPrimeraDenColones.Mask = "aa99";
            this.mtbPrimeraDenColones.Name = "mtbPrimeraDenColones";
            this.mtbPrimeraDenColones.Size = new System.Drawing.Size(45, 20);
            this.mtbPrimeraDenColones.TabIndex = 3;
            this.mtbPrimeraDenColones.Text = global::GUILayer.Properties.Settings.Default.CeldaPrimeraDenominacionColonesNiquel;
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
            this.ofdMontosCargas.Filter = "Archivos de Excel|*.xls;*.xlsx;*.xlsm";
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(489, 520);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(93, 40);
            this.btnRevisar.TabIndex = 11;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
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
            this.Monto,
            this.MontoPedidoColones,
            this.MontoPedidoDolares,
            this.Tipo,
            this.Denominaciones});
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
            this.dgvCargas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellDoubleClick);
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // ATM
            // 
            this.ATM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATM.DataPropertyName = "Punto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ATM.DefaultCellStyle = dataGridViewCellStyle1;
            this.ATM.HeaderText = "Punto de Venta";
            this.ATM.Name = "ATM";
            this.ATM.ReadOnly = true;
            this.ATM.Width = 96;
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
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Visible = false;
            // 
            // MontoPedidoColones
            // 
            this.MontoPedidoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoPedidoColones.DataPropertyName = "Monto_pedido_colones";
            dataGridViewCellStyle3.Format = "N2";
            this.MontoPedidoColones.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoPedidoColones.HeaderText = "P. en Colones";
            this.MontoPedidoColones.Name = "MontoPedidoColones";
            this.MontoPedidoColones.ReadOnly = true;
            this.MontoPedidoColones.Width = 89;
            // 
            // MontoPedidoDolares
            // 
            this.MontoPedidoDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoPedidoDolares.DataPropertyName = "Monto_pedido_dolares";
            dataGridViewCellStyle4.Format = "N2";
            this.MontoPedidoDolares.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoPedidoDolares.HeaderText = "P. en Dólares";
            this.MontoPedidoDolares.Name = "MontoPedidoDolares";
            this.MontoPedidoDolares.ReadOnly = true;
            this.MontoPedidoDolares.Width = 87;
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 52;
            // 
            // Denominaciones
            // 
            this.Denominaciones.DataPropertyName = "Cantidad_denominaciones";
            this.Denominaciones.HeaderText = "Denominaciones";
            this.Denominaciones.Name = "Denominaciones";
            this.Denominaciones.ReadOnly = true;
            // 
            // frmGenerarPedidosNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.btnRevisar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbCargas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenerarPedidosNiquel";
            this.Text = "Generar Pedidos";
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
        private System.Windows.Forms.Label lblCeldaDenDolaresA;
        private System.Windows.Forms.Label lblDenDolaresB;
        private System.Windows.Forms.MaskedTextBox mtbPrimeraDenDolaresA;
        private System.Windows.Forms.MaskedTextBox mtbSegundaDenDolares;
        private System.Windows.Forms.Label lblCeldaClienteA;
        private System.Windows.Forms.Label lblCeldaFecha;
        private System.Windows.Forms.MaskedTextBox mtbCeldaClienteA;
        private System.Windows.Forms.MaskedTextBox mtbCeldaFecha;
        private System.Windows.Forms.Label lblSegundaCelda;
        private System.Windows.Forms.Label lblDenominacionColones;
        private System.Windows.Forms.MaskedTextBox mtbSegundaDenColones;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.MaskedTextBox mtbPrimeraDenColones;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Label lblCeldaTransportadora;
        private System.Windows.Forms.MaskedTextBox mtbCeldaTransportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoPedidoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoPedidoDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominaciones;
    }
}