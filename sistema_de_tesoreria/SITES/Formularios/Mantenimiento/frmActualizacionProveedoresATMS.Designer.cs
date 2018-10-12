namespace GUILayer
{
    partial class frmActualizacionProveedoresATMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizacionProveedoresATMS));
            this.ENA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gbATMs = new System.Windows.Forms.GroupBox();
            this.dgvATMs = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cartuchos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Full = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CartuchoRechazo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VIP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbSegundaCelda = new System.Windows.Forms.MaskedTextBox();
            this.lblPrimeraCelda = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.mtbPrimeraCelda = new System.Windows.Forms.MaskedTextBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.ofdArchivoCargas = new System.Windows.Forms.OpenFileDialog();
            this.gbATMs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvATMs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbArchivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ENA
            // 
            this.ENA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ENA.DataPropertyName = "ENA";
            this.ENA.HeaderText = "ENA";
            this.ENA.Name = "ENA";
            this.ENA.ReadOnly = true;
            this.ENA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ENA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ENA.Width = 53;
            // 
            // gbATMs
            // 
            this.gbATMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbATMs.Controls.Add(this.dgvATMs);
            this.gbATMs.Location = new System.Drawing.Point(12, 136);
            this.gbATMs.Name = "gbATMs";
            this.gbATMs.Size = new System.Drawing.Size(660, 343);
            this.gbATMs.TabIndex = 8;
            this.gbATMs.TabStop = false;
            this.gbATMs.Text = "Lista de ATM\'s";
            // 
            // dgvATMs
            // 
            this.dgvATMs.AllowUserToAddRows = false;
            this.dgvATMs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvATMs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvATMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvATMs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvATMs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvATMs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvATMs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvATMs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Transportadora,
            this.Codigo,
            this.Ubicacion,
            this.Tipo,
            this.Cartuchos,
            this.Full,
            this.ENA,
            this.CartuchoRechazo,
            this.VIP});
            this.dgvATMs.EnableHeadersVisualStyles = false;
            this.dgvATMs.Location = new System.Drawing.Point(6, 19);
            this.dgvATMs.MultiSelect = false;
            this.dgvATMs.Name = "dgvATMs";
            this.dgvATMs.ReadOnly = true;
            this.dgvATMs.RowHeadersVisible = false;
            this.dgvATMs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvATMs.Size = new System.Drawing.Size(648, 318);
            this.dgvATMs.StandardTab = true;
            this.dgvATMs.TabIndex = 0;
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 68;
            // 
            // Transportadora
            // 
            this.Transportadora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Transportadora.DataPropertyName = "Empresa_encargada";
            this.Transportadora.HeaderText = "Transportadora";
            this.Transportadora.Name = "Transportadora";
            this.Transportadora.ReadOnly = true;
            this.Transportadora.Width = 103;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 64;
            // 
            // Ubicacion
            // 
            this.Ubicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ubicacion.DataPropertyName = "Nombre_ubicacion";
            this.Ubicacion.HeaderText = "Ubicación";
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
            this.Ubicacion.Width = 79;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 52;
            // 
            // Cartuchos
            // 
            this.Cartuchos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cartuchos.DataPropertyName = "Cartuchos";
            this.Cartuchos.HeaderText = "Cartuchos";
            this.Cartuchos.Name = "Cartuchos";
            this.Cartuchos.ReadOnly = true;
            this.Cartuchos.Width = 79;
            // 
            // Full
            // 
            this.Full.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Full.DataPropertyName = "Full";
            this.Full.HeaderText = "Full";
            this.Full.Name = "Full";
            this.Full.ReadOnly = true;
            this.Full.Width = 28;
            // 
            // CartuchoRechazo
            // 
            this.CartuchoRechazo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CartuchoRechazo.DataPropertyName = "Cartucho_rechazo";
            this.CartuchoRechazo.HeaderText = "C.  Rechazo";
            this.CartuchoRechazo.Name = "CartuchoRechazo";
            this.CartuchoRechazo.ReadOnly = true;
            this.CartuchoRechazo.Width = 71;
            // 
            // VIP
            // 
            this.VIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VIP.DataPropertyName = "VIP";
            this.VIP.HeaderText = "VIP";
            this.VIP.Name = "VIP";
            this.VIP.ReadOnly = true;
            this.VIP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VIP.Width = 48;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(576, 496);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.pnlFondo.Size = new System.Drawing.Size(684, 60);
            this.pnlFondo.TabIndex = 7;
            // 
            // gbArchivo
            // 
            this.gbArchivo.Controls.Add(this.label1);
            this.gbArchivo.Controls.Add(this.mtbSegundaCelda);
            this.gbArchivo.Controls.Add(this.lblPrimeraCelda);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.mtbPrimeraCelda);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(18, 65);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(654, 55);
            this.gbArchivo.TabIndex = 13;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Segunda Celda:";
            // 
            // mtbSegundaCelda
            // 
            this.mtbSegundaCelda.Location = new System.Drawing.Point(603, 22);
            this.mtbSegundaCelda.Mask = "aa99";
            this.mtbSegundaCelda.Name = "mtbSegundaCelda";
            this.mtbSegundaCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbSegundaCelda.TabIndex = 5;
            this.mtbSegundaCelda.Text = "C2";
            // 
            // lblPrimeraCelda
            // 
            this.lblPrimeraCelda.AutoSize = true;
            this.lblPrimeraCelda.Location = new System.Drawing.Point(377, 26);
            this.lblPrimeraCelda.Name = "lblPrimeraCelda";
            this.lblPrimeraCelda.Size = new System.Drawing.Size(75, 13);
            this.lblPrimeraCelda.TabIndex = 2;
            this.lblPrimeraCelda.Text = "Primera Celda:";
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
            this.mtbPrimeraCelda.Location = new System.Drawing.Point(458, 22);
            this.mtbPrimeraCelda.Mask = "aa99";
            this.mtbPrimeraCelda.Name = "mtbPrimeraCelda";
            this.mtbPrimeraCelda.Size = new System.Drawing.Size(45, 20);
            this.mtbPrimeraCelda.TabIndex = 3;
            this.mtbPrimeraCelda.Text = "A2";
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(6, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(305, 20);
            this.txtArchivo.TabIndex = 0;
            // 
            // ofdArchivoCargas
            // 
            this.ofdArchivoCargas.Filter = "Archivos de Excel|*.xls;*.xlsx";
            // 
            // frmActualizacionProveedoresATMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 548);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.gbATMs);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmActualizacionProveedoresATMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualización de Proveedores para los ATM\'s";
            this.Load += new System.EventHandler(this.frmActualizacionProveedoresATMS_Load);
            this.gbATMs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvATMs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewCheckBoxColumn ENA;
        private System.Windows.Forms.GroupBox gbATMs;
        private System.Windows.Forms.DataGridView dgvATMs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cartuchos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Full;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CartuchoRechazo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VIP;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.Label lblPrimeraCelda;
        private System.Windows.Forms.MaskedTextBox mtbPrimeraCelda;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.OpenFileDialog ofdArchivoCargas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbSegundaCelda;
        private System.Windows.Forms.Button btnAbrir;
    }
}