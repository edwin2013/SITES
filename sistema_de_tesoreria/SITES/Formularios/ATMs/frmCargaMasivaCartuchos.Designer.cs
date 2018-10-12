namespace GUILayer.Formularios.ATMs
{
    partial class frmCargaMasivaCartuchos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaMasivaCartuchos));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.clfalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCartucho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTerceraCelda = new System.Windows.Forms.Label();
            this.lblPrimeraCelda = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.gbIncorrectas = new System.Windows.Forms.GroupBox();
            this.lbInconrrectas = new System.Windows.Forms.ListBox();
            this.gbCartuchos = new System.Windows.Forms.GroupBox();
            this.dgvCartuchos = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbCeldaProveedor = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaEstado = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaTransportadora = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaCartucho = new System.Windows.Forms.MaskedTextBox();
            this.mtbCeldaTipo = new System.Windows.Forms.MaskedTextBox();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTransportador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbArchivo.SuspendLayout();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbIncorrectas.SuspendLayout();
            this.gbCartuchos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartuchos)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(779, 60);
            this.pnlFondo.TabIndex = 2;
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
            this.gbArchivo.Controls.Add(this.mtbCeldaProveedor);
            this.gbArchivo.Controls.Add(this.label3);
            this.gbArchivo.Controls.Add(this.label1);
            this.gbArchivo.Controls.Add(this.mtbCeldaEstado);
            this.gbArchivo.Controls.Add(this.label2);
            this.gbArchivo.Controls.Add(this.mtbCeldaTransportadora);
            this.gbArchivo.Controls.Add(this.gbCargas);
            this.gbArchivo.Controls.Add(this.lblTerceraCelda);
            this.gbArchivo.Controls.Add(this.mtbCeldaCartucho);
            this.gbArchivo.Controls.Add(this.lblPrimeraCelda);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbCeldaTipo);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(12, 66);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(544, 104);
            this.gbArchivo.TabIndex = 3;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Celda Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Celda Transportadora:";
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(0, 302);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(735, 10);
            this.gbCargas.TabIndex = 7;
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
            this.clfalla,
            this.clCartucho});
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.MultiSelect = false;
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCargas.Size = new System.Drawing.Size(723, 0);
            this.dgvCargas.StandardTab = true;
            this.dgvCargas.TabIndex = 0;
            // 
            // clfalla
            // 
            this.clfalla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clfalla.DefaultCellStyle = dataGridViewCellStyle1;
            this.clfalla.HeaderText = "Falla";
            this.clfalla.Name = "clfalla";
            this.clfalla.ReadOnly = true;
            this.clfalla.Width = 200;
            // 
            // clCartucho
            // 
            this.clCartucho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clCartucho.HeaderText = "Cartucho";
            this.clCartucho.Name = "clCartucho";
            this.clCartucho.ReadOnly = true;
            this.clCartucho.Width = 200;
            // 
            // lblTerceraCelda
            // 
            this.lblTerceraCelda.AutoSize = true;
            this.lblTerceraCelda.Location = new System.Drawing.Point(6, 42);
            this.lblTerceraCelda.Name = "lblTerceraCelda";
            this.lblTerceraCelda.Size = new System.Drawing.Size(83, 13);
            this.lblTerceraCelda.TabIndex = 8;
            this.lblTerceraCelda.Text = "Celda Cartucho:";
            // 
            // lblPrimeraCelda
            // 
            this.lblPrimeraCelda.AutoSize = true;
            this.lblPrimeraCelda.Location = new System.Drawing.Point(6, 70);
            this.lblPrimeraCelda.Name = "lblPrimeraCelda";
            this.lblPrimeraCelda.Size = new System.Drawing.Size(61, 13);
            this.lblPrimeraCelda.TabIndex = 2;
            this.lblPrimeraCelda.Text = "Celda Tipo:";
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
            // gbIncorrectas
            // 
            this.gbIncorrectas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbIncorrectas.Controls.Add(this.lbInconrrectas);
            this.gbIncorrectas.Location = new System.Drawing.Point(562, 66);
            this.gbIncorrectas.Name = "gbIncorrectas";
            this.gbIncorrectas.Size = new System.Drawing.Size(205, 85);
            this.gbIncorrectas.TabIndex = 6;
            this.gbIncorrectas.TabStop = false;
            this.gbIncorrectas.Text = "Lista de Filas Incorrectas";
            // 
            // lbInconrrectas
            // 
            this.lbInconrrectas.FormattingEnabled = true;
            this.lbInconrrectas.Location = new System.Drawing.Point(27, 22);
            this.lbInconrrectas.Name = "lbInconrrectas";
            this.lbInconrrectas.Size = new System.Drawing.Size(120, 43);
            this.lbInconrrectas.TabIndex = 0;
            // 
            // gbCartuchos
            // 
            this.gbCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCartuchos.Controls.Add(this.dgvCartuchos);
            this.gbCartuchos.Location = new System.Drawing.Point(12, 176);
            this.gbCartuchos.Name = "gbCartuchos";
            this.gbCartuchos.Size = new System.Drawing.Size(753, 205);
            this.gbCartuchos.TabIndex = 7;
            this.gbCartuchos.TabStop = false;
            this.gbCartuchos.Text = "Lista de Cargas";
            // 
            // dgvCartuchos
            // 
            this.dgvCartuchos.AllowUserToAddRows = false;
            this.dgvCartuchos.AllowUserToDeleteRows = false;
            this.dgvCartuchos.AllowUserToOrderColumns = true;
            this.dgvCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCartuchos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCartuchos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartuchos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.clTipo,
            this.clEstado,
            this.clTransportador,
            this.clProveedor});
            this.dgvCartuchos.EnableHeadersVisualStyles = false;
            this.dgvCartuchos.GridColor = System.Drawing.Color.Black;
            this.dgvCartuchos.Location = new System.Drawing.Point(6, 19);
            this.dgvCartuchos.MultiSelect = false;
            this.dgvCartuchos.Name = "dgvCartuchos";
            this.dgvCartuchos.ReadOnly = true;
            this.dgvCartuchos.RowHeadersVisible = false;
            this.dgvCartuchos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCartuchos.Size = new System.Drawing.Size(741, 180);
            this.dgvCartuchos.StandardTab = true;
            this.dgvCartuchos.TabIndex = 0;
            this.dgvCartuchos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCartuchos_RowsAdded);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(669, 386);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // ofdMontosCargas
            // 
            this.ofdMontosCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(573, 386);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 36;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Celda Proveedor:";
            // 
            // mtbCeldaProveedor
            // 
            this.mtbCeldaProveedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaProveedorM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaProveedor.Location = new System.Drawing.Point(440, 39);
            this.mtbCeldaProveedor.Mask = "aa99";
            this.mtbCeldaProveedor.Name = "mtbCeldaProveedor";
            this.mtbCeldaProveedor.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaProveedor.TabIndex = 38;
            this.mtbCeldaProveedor.Text = global::GUILayer.Properties.Settings.Default.CeldaProveedorM;
            // 
            // mtbCeldaEstado
            // 
            this.mtbCeldaEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaEstadoM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaEstado.Location = new System.Drawing.Point(273, 41);
            this.mtbCeldaEstado.Mask = "aa99";
            this.mtbCeldaEstado.Name = "mtbCeldaEstado";
            this.mtbCeldaEstado.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaEstado.TabIndex = 13;
            this.mtbCeldaEstado.Text = global::GUILayer.Properties.Settings.Default.CeldaEstadoM;
            // 
            // mtbCeldaTransportadora
            // 
            this.mtbCeldaTransportadora.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTransportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaTransportadora.Location = new System.Drawing.Point(273, 67);
            this.mtbCeldaTransportadora.Mask = "aa99";
            this.mtbCeldaTransportadora.Name = "mtbCeldaTransportadora";
            this.mtbCeldaTransportadora.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaTransportadora.TabIndex = 11;
            this.mtbCeldaTransportadora.Text = global::GUILayer.Properties.Settings.Default.CeldaTransportadoraM;
            // 
            // mtbCeldaCartucho
            // 
            this.mtbCeldaCartucho.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaCartuchoM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaCartucho.Location = new System.Drawing.Point(89, 41);
            this.mtbCeldaCartucho.Mask = "aa99";
            this.mtbCeldaCartucho.Name = "mtbCeldaCartucho";
            this.mtbCeldaCartucho.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaCartucho.TabIndex = 9;
            this.mtbCeldaCartucho.Text = global::GUILayer.Properties.Settings.Default.CeldaCartuchoM;
            // 
            // mtbCeldaTipo
            // 
            this.mtbCeldaTipo.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaTipoM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaTipo.Location = new System.Drawing.Point(89, 67);
            this.mtbCeldaTipo.Mask = "aa99";
            this.mtbCeldaTipo.Name = "mtbCeldaTipo";
            this.mtbCeldaTipo.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaTipo.TabIndex = 3;
            this.mtbCeldaTipo.Text = global::GUILayer.Properties.Settings.Default.CeldaTipoM;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Numero";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cartucho";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // clTipo
            // 
            this.clTipo.DataPropertyName = "Tipo";
            this.clTipo.HeaderText = "Tipo";
            this.clTipo.Name = "clTipo";
            this.clTipo.ReadOnly = true;
            // 
            // clEstado
            // 
            this.clEstado.DataPropertyName = "estadocartucho";
            this.clEstado.HeaderText = "Estado";
            this.clEstado.Name = "clEstado";
            this.clEstado.ReadOnly = true;
            // 
            // clTransportador
            // 
            this.clTransportador.DataPropertyName = "Transportadora";
            this.clTransportador.HeaderText = "Transportadora";
            this.clTransportador.Name = "clTransportador";
            this.clTransportador.ReadOnly = true;
            // 
            // clProveedor
            // 
            this.clProveedor.DataPropertyName = "Proveedor";
            this.clProveedor.HeaderText = "Proveedor";
            this.clProveedor.Name = "clProveedor";
            this.clProveedor.ReadOnly = true;
            // 
            // frmCargaMasivaCartuchos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 428);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbCartuchos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbIncorrectas);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargaMasivaCartuchos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga Masiva de Cartuchos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbIncorrectas.ResumeLayout(false);
            this.gbCartuchos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartuchos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.Label lblTerceraCelda;
        private System.Windows.Forms.MaskedTextBox mtbCeldaCartucho;
        private System.Windows.Forms.Label lblPrimeraCelda;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.MaskedTextBox mtbCeldaTipo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.GroupBox gbIncorrectas;
        private System.Windows.Forms.ListBox lbInconrrectas;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.DataGridViewTextBoxColumn clfalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCartucho;
        private System.Windows.Forms.GroupBox gbCartuchos;
        private System.Windows.Forms.DataGridView dgvCartuchos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbCeldaEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbCeldaTransportadora;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.MaskedTextBox mtbCeldaProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTransportador;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProveedor;
    }
}