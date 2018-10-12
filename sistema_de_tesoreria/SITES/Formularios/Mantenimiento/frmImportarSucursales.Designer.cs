namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmImportarSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarSucursales));
            this.lblTerceraCelda = new System.Windows.Forms.Label();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbEntidad = new System.Windows.Forms.MaskedTextBox();
            this.lblTipoSucursal = new System.Windows.Forms.Label();
            this.mtbceldaTipSucursal = new System.Windows.Forms.MaskedTextBox();
            this.mtbTransportadoraCelda = new System.Windows.Forms.MaskedTextBox();
            this.lblCeldaATMA = new System.Windows.Forms.Label();
            this.mtbCiudadCelda = new System.Windows.Forms.MaskedTextBox();
            this.lblSegundaCelda = new System.Windows.Forms.Label();
            this.lblPrimeraCelda = new System.Windows.Forms.Label();
            this.mtbProvinciaCelda = new System.Windows.Forms.MaskedTextBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.mtbSucursalCelda = new System.Windows.Forms.MaskedTextBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.ClmSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTransportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbArchivo.SuspendLayout();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTerceraCelda
            // 
            this.lblTerceraCelda.AutoSize = true;
            this.lblTerceraCelda.Location = new System.Drawing.Point(147, 49);
            this.lblTerceraCelda.Name = "lblTerceraCelda";
            this.lblTerceraCelda.Size = new System.Drawing.Size(112, 13);
            this.lblTerceraCelda.TabIndex = 8;
            this.lblTerceraCelda.Text = "Celda Transportadora:";
            // 
            // gbArchivo
            // 
            this.gbArchivo.Controls.Add(this.label1);
            this.gbArchivo.Controls.Add(this.mtbEntidad);
            this.gbArchivo.Controls.Add(this.lblTipoSucursal);
            this.gbArchivo.Controls.Add(this.mtbceldaTipSucursal);
            this.gbArchivo.Controls.Add(this.lblTerceraCelda);
            this.gbArchivo.Controls.Add(this.mtbTransportadoraCelda);
            this.gbArchivo.Controls.Add(this.lblCeldaATMA);
            this.gbArchivo.Controls.Add(this.mtbCiudadCelda);
            this.gbArchivo.Controls.Add(this.lblSegundaCelda);
            this.gbArchivo.Controls.Add(this.lblPrimeraCelda);
            this.gbArchivo.Controls.Add(this.mtbProvinciaCelda);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbSucursalCelda);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(12, 77);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(411, 123);
            this.gbArchivo.TabIndex = 21;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Celda Entidad:";
            // 
            // mtbEntidad
            // 
            this.mtbEntidad.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalEntidad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbEntidad.Location = new System.Drawing.Point(264, 97);
            this.mtbEntidad.Mask = "aa999";
            this.mtbEntidad.Name = "mtbEntidad";
            this.mtbEntidad.Size = new System.Drawing.Size(45, 20);
            this.mtbEntidad.TabIndex = 13;
            this.mtbEntidad.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalEntidad;
            // 
            // lblTipoSucursal
            // 
            this.lblTipoSucursal.AutoSize = true;
            this.lblTipoSucursal.Location = new System.Drawing.Point(147, 75);
            this.lblTipoSucursal.Name = "lblTipoSucursal";
            this.lblTipoSucursal.Size = new System.Drawing.Size(61, 13);
            this.lblTipoSucursal.TabIndex = 10;
            this.lblTipoSucursal.Text = "Celda Tipo:";
            // 
            // mtbceldaTipSucursal
            // 
            this.mtbceldaTipSucursal.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalTipo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbceldaTipSucursal.Location = new System.Drawing.Point(265, 72);
            this.mtbceldaTipSucursal.Mask = "aa999";
            this.mtbceldaTipSucursal.Name = "mtbceldaTipSucursal";
            this.mtbceldaTipSucursal.Size = new System.Drawing.Size(45, 20);
            this.mtbceldaTipSucursal.TabIndex = 11;
            this.mtbceldaTipSucursal.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalTipo;
            // 
            // mtbTransportadoraCelda
            // 
            this.mtbTransportadoraCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalTransportadora", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbTransportadoraCelda.Location = new System.Drawing.Point(265, 46);
            this.mtbTransportadoraCelda.Mask = "aa999";
            this.mtbTransportadoraCelda.Name = "mtbTransportadoraCelda";
            this.mtbTransportadoraCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbTransportadoraCelda.TabIndex = 9;
            this.mtbTransportadoraCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalTransportadora;
            // 
            // lblCeldaATMA
            // 
            this.lblCeldaATMA.AutoSize = true;
            this.lblCeldaATMA.Location = new System.Drawing.Point(17, 100);
            this.lblCeldaATMA.Name = "lblCeldaATMA";
            this.lblCeldaATMA.Size = new System.Drawing.Size(73, 13);
            this.lblCeldaATMA.TabIndex = 6;
            this.lblCeldaATMA.Text = "Celda Ciudad:";
            // 
            // mtbCiudadCelda
            // 
            this.mtbCiudadCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalDireccion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCiudadCelda.Location = new System.Drawing.Point(95, 97);
            this.mtbCiudadCelda.Mask = "aa999";
            this.mtbCiudadCelda.Name = "mtbCiudadCelda";
            this.mtbCiudadCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbCiudadCelda.TabIndex = 7;
            this.mtbCiudadCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalDireccion;
            // 
            // lblSegundaCelda
            // 
            this.lblSegundaCelda.AutoSize = true;
            this.lblSegundaCelda.Location = new System.Drawing.Point(6, 75);
            this.lblSegundaCelda.Name = "lblSegundaCelda";
            this.lblSegundaCelda.Size = new System.Drawing.Size(84, 13);
            this.lblSegundaCelda.TabIndex = 4;
            this.lblSegundaCelda.Text = "Celda Provincia:";
            // 
            // lblPrimeraCelda
            // 
            this.lblPrimeraCelda.AutoSize = true;
            this.lblPrimeraCelda.Location = new System.Drawing.Point(14, 49);
            this.lblPrimeraCelda.Name = "lblPrimeraCelda";
            this.lblPrimeraCelda.Size = new System.Drawing.Size(81, 13);
            this.lblPrimeraCelda.TabIndex = 2;
            this.lblPrimeraCelda.Text = "Celda Sucursal:";
            // 
            // mtbProvinciaCelda
            // 
            this.mtbProvinciaCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaSucursalProvincia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbProvinciaCelda.Location = new System.Drawing.Point(95, 71);
            this.mtbProvinciaCelda.Mask = "aa999";
            this.mtbProvinciaCelda.Name = "mtbProvinciaCelda";
            this.mtbProvinciaCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbProvinciaCelda.TabIndex = 5;
            this.mtbProvinciaCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaSucursalProvincia;
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
            // mtbSucursalCelda
            // 
            this.mtbSucursalCelda.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaImportacionSucursal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbSucursalCelda.Location = new System.Drawing.Point(95, 45);
            this.mtbSucursalCelda.Mask = "aa999";
            this.mtbSucursalCelda.Name = "mtbSucursalCelda";
            this.mtbSucursalCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbSucursalCelda.TabIndex = 3;
            this.mtbSucursalCelda.Text = global::GUILayer.Properties.Settings.Default.CeldaImportacionSucursal;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(6, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(348, 20);
            this.txtArchivo.TabIndex = 0;
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 206);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(768, 313);
            this.gbCargas.TabIndex = 23;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmSucursal,
            this.clmNombre,
            this.clmProvincia,
            this.clmDireccion,
            this.clmTransportadora,
            this.clmTipo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle2;
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
            // 
            // ClmSucursal
            // 
            this.ClmSucursal.DataPropertyName = "Codigo";
            this.ClmSucursal.HeaderText = "Sucursal";
            this.ClmSucursal.Name = "ClmSucursal";
            this.ClmSucursal.ReadOnly = true;
            // 
            // clmNombre
            // 
            this.clmNombre.DataPropertyName = "Nombre";
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            // 
            // clmProvincia
            // 
            this.clmProvincia.DataPropertyName = "Provincia";
            this.clmProvincia.HeaderText = "Provincia";
            this.clmProvincia.Name = "clmProvincia";
            this.clmProvincia.ReadOnly = true;
            // 
            // clmDireccion
            // 
            this.clmDireccion.DataPropertyName = "Direccion";
            this.clmDireccion.HeaderText = "Ciudad";
            this.clmDireccion.Name = "clmDireccion";
            this.clmDireccion.ReadOnly = true;
            // 
            // clmTransportadora
            // 
            this.clmTransportadora.DataPropertyName = "Empresa";
            this.clmTransportadora.HeaderText = "Empresa de Transporte";
            this.clmTransportadora.Name = "clmTransportadora";
            this.clmTransportadora.ReadOnly = true;
            // 
            // clmTipo
            // 
            this.clmTipo.DataPropertyName = "TipoSucursal";
            this.clmTipo.HeaderText = "Tipo";
            this.clmTipo.Name = "clmTipo";
            this.clmTipo.ReadOnly = true;
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
            this.pnlFondo.TabIndex = 20;
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
            // ofdMontosCargas
            // 
            this.ofdMontosCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(588, 525);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 24;
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
            this.btnSalir.Location = new System.Drawing.Point(684, 525);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // frmImportarSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportarSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Sucursales";
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTerceraCelda;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.MaskedTextBox mtbTransportadoraCelda;
        private System.Windows.Forms.Label lblCeldaATMA;
        private System.Windows.Forms.MaskedTextBox mtbCiudadCelda;
        private System.Windows.Forms.Label lblSegundaCelda;
        private System.Windows.Forms.Label lblPrimeraCelda;
        private System.Windows.Forms.MaskedTextBox mtbProvinciaCelda;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.MaskedTextBox mtbSucursalCelda;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTipoSucursal;
        private System.Windows.Forms.MaskedTextBox mtbceldaTipSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTransportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipo;
    }
}