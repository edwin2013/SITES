namespace GUILayer.Formularios.ATMs
{
    partial class frmCargaMasivaFallas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaMasivaFallas));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.lblTerceraCelda = new System.Windows.Forms.Label();
            this.mtbCeldaCartucho = new System.Windows.Forms.MaskedTextBox();
            this.lblPrimeraCelda = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.mtbCeldaFalla = new System.Windows.Forms.MaskedTextBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.clfalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCartucho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.gbIncorrectas = new System.Windows.Forms.GroupBox();
            this.lbInconrrectas = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbArchivo.SuspendLayout();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbIncorrectas.SuspendLayout();
            this.SuspendLayout();
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
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(628, 60);
            this.pnlFondo.TabIndex = 1;
            // 
            // gbArchivo
            // 
            this.gbArchivo.Controls.Add(this.lblTerceraCelda);
            this.gbArchivo.Controls.Add(this.mtbCeldaCartucho);
            this.gbArchivo.Controls.Add(this.lblPrimeraCelda);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbCeldaFalla);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(13, 80);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(411, 80);
            this.gbArchivo.TabIndex = 2;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // lblTerceraCelda
            // 
            this.lblTerceraCelda.AutoSize = true;
            this.lblTerceraCelda.Location = new System.Drawing.Point(147, 49);
            this.lblTerceraCelda.Name = "lblTerceraCelda";
            this.lblTerceraCelda.Size = new System.Drawing.Size(83, 13);
            this.lblTerceraCelda.TabIndex = 8;
            this.lblTerceraCelda.Text = "Celda Cartucho:";
            // 
            // mtbCeldaCartucho
            // 
            this.mtbCeldaCartucho.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaCartucho", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaCartucho.Location = new System.Drawing.Point(230, 45);
            this.mtbCeldaCartucho.Mask = "aa99";
            this.mtbCeldaCartucho.Name = "mtbCeldaCartucho";
            this.mtbCeldaCartucho.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaCartucho.TabIndex = 9;
            // 
            // lblPrimeraCelda
            // 
            this.lblPrimeraCelda.AutoSize = true;
            this.lblPrimeraCelda.Location = new System.Drawing.Point(14, 49);
            this.lblPrimeraCelda.Name = "lblPrimeraCelda";
            this.lblPrimeraCelda.Size = new System.Drawing.Size(62, 13);
            this.lblPrimeraCelda.TabIndex = 2;
            this.lblPrimeraCelda.Text = "Celda Falla:";
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
            // mtbCeldaFalla
            // 
            this.mtbCeldaFalla.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "CeldaFalla", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbCeldaFalla.Location = new System.Drawing.Point(95, 45);
            this.mtbCeldaFalla.Mask = "aa99";
            this.mtbCeldaFalla.Name = "mtbCeldaFalla";
            this.mtbCeldaFalla.Size = new System.Drawing.Size(45, 20);
            this.mtbCeldaFalla.TabIndex = 3;
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
            this.gbCargas.Location = new System.Drawing.Point(13, 166);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(602, 197);
            this.gbCargas.TabIndex = 4;
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
            this.dgvCargas.Size = new System.Drawing.Size(590, 172);
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
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(429, 371);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 6;
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
            this.btnSalir.Location = new System.Drawing.Point(525, 371);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // ofdMontosCargas
            // 
            this.ofdMontosCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
            // 
            // gbIncorrectas
            // 
            this.gbIncorrectas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbIncorrectas.Controls.Add(this.lbInconrrectas);
            this.gbIncorrectas.Location = new System.Drawing.Point(434, 80);
            this.gbIncorrectas.Name = "gbIncorrectas";
            this.gbIncorrectas.Size = new System.Drawing.Size(181, 80);
            this.gbIncorrectas.TabIndex = 5;
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
            // frmCargaMasivaFallas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 423);
            this.Controls.Add(this.gbIncorrectas);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargaMasivaFallas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga Masiva de Fallas de Cartuchos";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbIncorrectas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.Label lblTerceraCelda;
        private System.Windows.Forms.MaskedTextBox mtbCeldaCartucho;
        private System.Windows.Forms.Label lblPrimeraCelda;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.MaskedTextBox mtbCeldaFalla;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
        private System.Windows.Forms.DataGridViewTextBoxColumn clfalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCartucho;
        private System.Windows.Forms.GroupBox gbIncorrectas;
        private System.Windows.Forms.ListBox lbInconrrectas;
    }
}