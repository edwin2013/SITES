namespace GUILayer
{
    partial class frmImportacionTrialesDescargas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportacionTrialesDescargas));
            this.gbTriales = new System.Windows.Forms.GroupBox();
            this.dgvTriales = new System.Windows.Forms.DataGridView();
            this.ATM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Full = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ofdArchivoTriales = new System.Windows.Forms.OpenFileDialog();
            this.chkFull = new System.Windows.Forms.CheckBox();
            this.gbTriales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTriales)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbArchivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTriales
            // 
            this.gbTriales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTriales.Controls.Add(this.dgvTriales);
            this.gbTriales.Location = new System.Drawing.Point(12, 117);
            this.gbTriales.Name = "gbTriales";
            this.gbTriales.Size = new System.Drawing.Size(768, 391);
            this.gbTriales.TabIndex = 2;
            this.gbTriales.TabStop = false;
            this.gbTriales.Text = "Lista de Cargas";
            // 
            // dgvTriales
            // 
            this.dgvTriales.AllowUserToAddRows = false;
            this.dgvTriales.AllowUserToDeleteRows = false;
            this.dgvTriales.AllowUserToOrderColumns = true;
            this.dgvTriales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTriales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTriales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATM,
            this.Fecha,
            this.MontoColones,
            this.MontoDolares,
            this.Full});
            this.dgvTriales.EnableHeadersVisualStyles = false;
            this.dgvTriales.GridColor = System.Drawing.Color.Black;
            this.dgvTriales.Location = new System.Drawing.Point(6, 19);
            this.dgvTriales.MultiSelect = false;
            this.dgvTriales.Name = "dgvTriales";
            this.dgvTriales.ReadOnly = true;
            this.dgvTriales.RowHeadersVisible = false;
            this.dgvTriales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTriales.Size = new System.Drawing.Size(756, 366);
            this.dgvTriales.StandardTab = true;
            this.dgvTriales.TabIndex = 0;
            // 
            // ATM
            // 
            this.ATM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATM.DataPropertyName = "ATM";
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
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "M";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 61;
            // 
            // MontoColones
            // 
            this.MontoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColones.DataPropertyName = "Monto_colones";
            dataGridViewCellStyle3.Format = "N2";
            this.MontoColones.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoColones.HeaderText = "M. en Colones";
            this.MontoColones.Name = "MontoColones";
            this.MontoColones.ReadOnly = true;
            this.MontoColones.Width = 99;
            // 
            // MontoDolares
            // 
            this.MontoDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolares.DataPropertyName = "Monto_dolares";
            dataGridViewCellStyle4.Format = "N2";
            this.MontoDolares.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoDolares.HeaderText = "M. en Dólares";
            this.MontoDolares.Name = "MontoDolares";
            this.MontoDolares.ReadOnly = true;
            this.MontoDolares.Width = 97;
            // 
            // Full
            // 
            this.Full.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Full.DataPropertyName = "Full";
            this.Full.HeaderText = "Full";
            this.Full.Name = "Full";
            this.Full.ReadOnly = true;
            this.Full.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Full.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Full.Width = 47;
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
            this.gbArchivo.Controls.Add(this.chkFull);
            this.gbArchivo.Controls.Add(this.lblArchivo);
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(12, 66);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(468, 45);
            this.gbArchivo.TabIndex = 1;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(6, 23);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(46, 13);
            this.lblArchivo.TabIndex = 0;
            this.lblArchivo.Text = "Archivo:";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(417, 19);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(45, 20);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "...";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(58, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(305, 20);
            this.txtArchivo.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(588, 514);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 3;
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
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ofdArchivoTriales
            // 
            this.ofdArchivoTriales.Filter = "Archivos dexto|*.txt";
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.Location = new System.Drawing.Point(369, 21);
            this.chkFull.Name = "chkFull";
            this.chkFull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFull.Size = new System.Drawing.Size(42, 17);
            this.chkFull.TabIndex = 2;
            this.chkFull.Text = "Full";
            this.chkFull.UseVisualStyleBackColor = true;
            // 
            // frmImportacionTrialesDescargas
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbTriales);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbArchivo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmImportacionTrialesDescargas";
            this.Text = "Importación de Triales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbTriales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTriales)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTriales;
        private System.Windows.Forms.DataGridView dgvTriales;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.OpenFileDialog ofdArchivoTriales;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolares;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Full;
        private System.Windows.Forms.CheckBox chkFull;
    }
}