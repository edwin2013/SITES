namespace GUILayer
{
    partial class frmMontosRetiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMontosRetiros));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbMontos = new System.Windows.Forms.GroupBox();
            this.cboMonedaLista = new System.Windows.Forms.ComboBox();
            this.lblMonedaLista = new System.Windows.Forms.Label();
            this.dgvMontos = new System.Windows.Forms.DataGridView();
            this.ATMCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.lblATM = new System.Windows.Forms.Label();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbAgregarATM = new System.Windows.Forms.GroupBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbMontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).BeginInit();
            this.gbAgregarATM.SuspendLayout();
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
            this.pnlFondo.Size = new System.Drawing.Size(912, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbMontos
            // 
            this.gbMontos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMontos.Controls.Add(this.cboMonedaLista);
            this.gbMontos.Controls.Add(this.lblMonedaLista);
            this.gbMontos.Controls.Add(this.dgvMontos);
            this.gbMontos.Location = new System.Drawing.Point(12, 145);
            this.gbMontos.Name = "gbMontos";
            this.gbMontos.Size = new System.Drawing.Size(888, 383);
            this.gbMontos.TabIndex = 2;
            this.gbMontos.TabStop = false;
            this.gbMontos.Text = "Montos Esperados de Retiros";
            // 
            // cboMonedaLista
            // 
            this.cboMonedaLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaLista.FormattingEnabled = true;
            this.cboMonedaLista.Items.AddRange(new object[] {
            "Colones",
            "Dólares"});
            this.cboMonedaLista.Location = new System.Drawing.Point(61, 19);
            this.cboMonedaLista.Name = "cboMonedaLista";
            this.cboMonedaLista.Size = new System.Drawing.Size(236, 21);
            this.cboMonedaLista.TabIndex = 1;
            this.cboMonedaLista.SelectedIndexChanged += new System.EventHandler(this.cboMonedaLista_SelectedIndexChanged);
            // 
            // lblMonedaLista
            // 
            this.lblMonedaLista.AutoSize = true;
            this.lblMonedaLista.Location = new System.Drawing.Point(6, 23);
            this.lblMonedaLista.Name = "lblMonedaLista";
            this.lblMonedaLista.Size = new System.Drawing.Size(49, 13);
            this.lblMonedaLista.TabIndex = 0;
            this.lblMonedaLista.Text = "Moneda:";
            // 
            // dgvMontos
            // 
            this.dgvMontos.AllowUserToAddRows = false;
            this.dgvMontos.AllowUserToDeleteRows = false;
            this.dgvMontos.AllowUserToOrderColumns = true;
            this.dgvMontos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMontos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATMCarga,
            this.L,
            this.K,
            this.M,
            this.J,
            this.V,
            this.S,
            this.D,
            this.LQ,
            this.KQ,
            this.MQ,
            this.JQ,
            this.VQ,
            this.SQ,
            this.DQ});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMontos.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvMontos.EnableHeadersVisualStyles = false;
            this.dgvMontos.GridColor = System.Drawing.Color.Black;
            this.dgvMontos.Location = new System.Drawing.Point(6, 46);
            this.dgvMontos.Name = "dgvMontos";
            this.dgvMontos.RowHeadersVisible = false;
            this.dgvMontos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontos.Size = new System.Drawing.Size(876, 331);
            this.dgvMontos.TabIndex = 2;
            this.dgvMontos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMontos_CellEndEdit);
            this.dgvMontos.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvMontos_CellParsing);
            // 
            // ATMCarga
            // 
            this.ATMCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATMCarga.DataPropertyName = "ATM";
            this.ATMCarga.HeaderText = "ATM";
            this.ATMCarga.Name = "ATMCarga";
            this.ATMCarga.ReadOnly = true;
            this.ATMCarga.Width = 54;
            // 
            // L
            // 
            this.L.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.L.DataPropertyName = "Retiro_lunes";
            dataGridViewCellStyle2.Format = "N2";
            this.L.DefaultCellStyle = dataGridViewCellStyle2;
            this.L.HeaderText = "L";
            this.L.Name = "L";
            this.L.Width = 37;
            // 
            // K
            // 
            this.K.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.K.DataPropertyName = "Retiro_martes";
            dataGridViewCellStyle3.Format = "N2";
            this.K.DefaultCellStyle = dataGridViewCellStyle3;
            this.K.HeaderText = "K";
            this.K.Name = "K";
            this.K.Width = 38;
            // 
            // M
            // 
            this.M.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.M.DataPropertyName = "Retiro_miercoles";
            dataGridViewCellStyle4.Format = "N2";
            this.M.DefaultCellStyle = dataGridViewCellStyle4;
            this.M.HeaderText = "M";
            this.M.Name = "M";
            this.M.Width = 40;
            // 
            // J
            // 
            this.J.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.J.DataPropertyName = "Retiro_jueves";
            dataGridViewCellStyle5.Format = "N2";
            this.J.DefaultCellStyle = dataGridViewCellStyle5;
            this.J.HeaderText = "J";
            this.J.Name = "J";
            this.J.Width = 36;
            // 
            // V
            // 
            this.V.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.V.DataPropertyName = "Retiro_viernes";
            dataGridViewCellStyle6.Format = "N2";
            this.V.DefaultCellStyle = dataGridViewCellStyle6;
            this.V.HeaderText = "V";
            this.V.Name = "V";
            this.V.Width = 38;
            // 
            // S
            // 
            this.S.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.S.DataPropertyName = "Retiro_sabado";
            dataGridViewCellStyle7.Format = "N2";
            this.S.DefaultCellStyle = dataGridViewCellStyle7;
            this.S.HeaderText = "S";
            this.S.Name = "S";
            this.S.Width = 38;
            // 
            // D
            // 
            this.D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.D.DataPropertyName = "Retiro_domingo";
            dataGridViewCellStyle8.Format = "N2";
            this.D.DefaultCellStyle = dataGridViewCellStyle8;
            this.D.HeaderText = "D";
            this.D.Name = "D";
            this.D.Width = 39;
            // 
            // LQ
            // 
            this.LQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LQ.DataPropertyName = "Retiro_lunes_quincena";
            dataGridViewCellStyle9.Format = "N2";
            this.LQ.DefaultCellStyle = dataGridViewCellStyle9;
            this.LQ.HeaderText = "LQ";
            this.LQ.Name = "LQ";
            this.LQ.Width = 45;
            // 
            // KQ
            // 
            this.KQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KQ.DataPropertyName = "Retiro_martes_quincena";
            dataGridViewCellStyle10.Format = "N2";
            this.KQ.DefaultCellStyle = dataGridViewCellStyle10;
            this.KQ.HeaderText = "KQ";
            this.KQ.Name = "KQ";
            this.KQ.Width = 46;
            // 
            // MQ
            // 
            this.MQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MQ.DataPropertyName = "Retiro_miercoles_quincena";
            dataGridViewCellStyle11.Format = "N2";
            this.MQ.DefaultCellStyle = dataGridViewCellStyle11;
            this.MQ.HeaderText = "MQ";
            this.MQ.Name = "MQ";
            this.MQ.Width = 48;
            // 
            // JQ
            // 
            this.JQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JQ.DataPropertyName = "Retiro_jueves_quincena";
            dataGridViewCellStyle12.Format = "N2";
            this.JQ.DefaultCellStyle = dataGridViewCellStyle12;
            this.JQ.HeaderText = "JQ";
            this.JQ.Name = "JQ";
            this.JQ.Width = 44;
            // 
            // VQ
            // 
            this.VQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VQ.DataPropertyName = "Retiro_viernes_quincena";
            dataGridViewCellStyle13.Format = "N2";
            this.VQ.DefaultCellStyle = dataGridViewCellStyle13;
            this.VQ.HeaderText = "VQ";
            this.VQ.Name = "VQ";
            this.VQ.Width = 46;
            // 
            // SQ
            // 
            this.SQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SQ.DataPropertyName = "Retiro_sabado_quincena";
            dataGridViewCellStyle14.Format = "N2";
            this.SQ.DefaultCellStyle = dataGridViewCellStyle14;
            this.SQ.HeaderText = "SQ";
            this.SQ.Name = "SQ";
            this.SQ.Width = 46;
            // 
            // DQ
            // 
            this.DQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DQ.DataPropertyName = "Retiro_domingo_quincena";
            dataGridViewCellStyle15.Format = "N2";
            this.DQ.DefaultCellStyle = dataGridViewCellStyle15;
            this.DQ.HeaderText = "DQ";
            this.DQ.Name = "DQ";
            this.DQ.Width = 47;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(804, 534);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.FlatAppearance.BorderSize = 2;
            this.btnImportar.Image = global::GUILayer.Properties.Resources.importacion;
            this.btnImportar.Location = new System.Drawing.Point(708, 534);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(90, 40);
            this.btnImportar.TabIndex = 3;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(25, 23);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(33, 13);
            this.lblATM.TabIndex = 0;
            this.lblATM.Text = "ATM:";
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = false;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(64, 19);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(236, 21);
            this.cboATM.TabIndex = 1;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(9, 50);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 2;
            this.lblMoneda.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares"});
            this.cboMoneda.Location = new System.Drawing.Point(64, 46);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(236, 21);
            this.cboMoneda.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderSize = 2;
            this.btnAgregar.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregar.Location = new System.Drawing.Point(306, 27);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 40);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbAgregarATM
            // 
            this.gbAgregarATM.Controls.Add(this.btnAgregar);
            this.gbAgregarATM.Controls.Add(this.cboMoneda);
            this.gbAgregarATM.Controls.Add(this.lblMoneda);
            this.gbAgregarATM.Controls.Add(this.cboATM);
            this.gbAgregarATM.Controls.Add(this.lblATM);
            this.gbAgregarATM.Location = new System.Drawing.Point(12, 66);
            this.gbAgregarATM.Name = "gbAgregarATM";
            this.gbAgregarATM.Size = new System.Drawing.Size(402, 73);
            this.gbAgregarATM.TabIndex = 1;
            this.gbAgregarATM.TabStop = false;
            this.gbAgregarATM.Text = "Agregar ATM";
            // 
            // frmMontosRetiros
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(912, 586);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbMontos);
            this.Controls.Add(this.gbAgregarATM);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(920, 620);
            this.Name = "frmMontosRetiros";
            this.Text = "Montos Esperados de Retiros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMontosRetiros_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbMontos.ResumeLayout(false);
            this.gbMontos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).EndInit();
            this.gbAgregarATM.ResumeLayout(false);
            this.gbAgregarATM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbMontos;
        private System.Windows.Forms.DataGridView dgvMontos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblMonedaLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATMCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewTextBoxColumn K;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.DataGridViewTextBoxColumn J;
        private System.Windows.Forms.DataGridViewTextBoxColumn V;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.DataGridViewTextBoxColumn LQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn KQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn JQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn VQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DQ;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.ComboBox cboMonedaLista;
        private System.Windows.Forms.Label lblATM;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbAgregarATM;
    }
}