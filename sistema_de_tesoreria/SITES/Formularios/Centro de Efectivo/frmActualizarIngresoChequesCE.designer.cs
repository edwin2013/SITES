namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmActualizarIngresoChequesCE
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizarIngresoChequesCE));
            this.cboTipoCheque = new System.Windows.Forms.ComboBox();
            this.lblTipoCheque = new System.Windows.Forms.Label();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.gbregistrocheque = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.dgvcheques = new System.Windows.Forms.DataGridView();
            this.TipoCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTotalesCheques = new System.Windows.Forms.GroupBox();
            this.txtChequesUSD = new System.Windows.Forms.TextBox();
            this.txtChequeExtranjeroUSD = new System.Windows.Forms.TextBox();
            this.txtChequeLocalUSD = new System.Windows.Forms.TextBox();
            this.txtChequeCompensadoUSD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEtiquetaColones = new System.Windows.Forms.Label();
            this.txtChequesCRC = new System.Windows.Forms.TextBox();
            this.lblTotalCheques = new System.Windows.Forms.Label();
            this.txtChequeExtranjeroCRC = new System.Windows.Forms.TextBox();
            this.lblTotalChequeExtranjero = new System.Windows.Forms.Label();
            this.txtChequeLocalCRC = new System.Windows.Forms.TextBox();
            this.lblTotalChequeLocal = new System.Windows.Forms.Label();
            this.txtChequeCompensadoCRC = new System.Windows.Forms.TextBox();
            this.lblTotalChequeCompensado = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnQuitarCheque = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.gbregistrocheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcheques)).BeginInit();
            this.gbTotalesCheques.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoCheque
            // 
            this.cboTipoCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCheque.FormattingEnabled = true;
            this.cboTipoCheque.Items.AddRange(new object[] {
            "Cheque Local",
            "Cheque Compensado",
            "Cheque Extranjero"});
            this.cboTipoCheque.Location = new System.Drawing.Point(112, 19);
            this.cboTipoCheque.Name = "cboTipoCheque";
            this.cboTipoCheque.Size = new System.Drawing.Size(339, 21);
            this.cboTipoCheque.TabIndex = 17;
            // 
            // lblTipoCheque
            // 
            this.lblTipoCheque.AutoSize = true;
            this.lblTipoCheque.Location = new System.Drawing.Point(35, 22);
            this.lblTipoCheque.Name = "lblTipoCheque";
            this.lblTipoCheque.Size = new System.Drawing.Size(71, 13);
            this.lblTipoCheque.TabIndex = 16;
            this.lblTipoCheque.Text = "Tipo Cheque:";
            // 
            // nudMonto
            // 
            this.nudMonto.Location = new System.Drawing.Point(112, 73);
            this.nudMonto.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(339, 20);
            this.nudMonto.TabIndex = 19;
            this.nudMonto.ValueChanged += new System.EventHandler(this.nudMonto_ValueChanged);
            this.nudMonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudMonto_KeyDown);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(66, 79);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 18;
            this.lblMonto.Text = "Monto:";
            // 
            // gbregistrocheque
            // 
            this.gbregistrocheque.Controls.Add(this.btnGuardar);
            this.gbregistrocheque.Controls.Add(this.cboMoneda);
            this.gbregistrocheque.Controls.Add(this.lblMoneda);
            this.gbregistrocheque.Controls.Add(this.cboTipoCheque);
            this.gbregistrocheque.Controls.Add(this.nudMonto);
            this.gbregistrocheque.Controls.Add(this.lblTipoCheque);
            this.gbregistrocheque.Controls.Add(this.lblMonto);
            this.gbregistrocheque.Location = new System.Drawing.Point(21, 86);
            this.gbregistrocheque.Name = "gbregistrocheque";
            this.gbregistrocheque.Size = new System.Drawing.Size(607, 105);
            this.gbregistrocheque.TabIndex = 20;
            this.gbregistrocheque.TabStop = false;
            this.gbregistrocheque.Text = "Registro Cheques";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(494, 35);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares"});
            this.cboMoneda.Location = new System.Drawing.Point(112, 46);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(339, 21);
            this.cboMoneda.TabIndex = 21;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(57, 49);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 20;
            this.lblMoneda.Text = "Moneda:";
            // 
            // dgvcheques
            // 
            this.dgvcheques.AllowUserToAddRows = false;
            this.dgvcheques.AllowUserToDeleteRows = false;
            this.dgvcheques.AllowUserToOrderColumns = true;
            this.dgvcheques.AllowUserToResizeColumns = false;
            this.dgvcheques.AllowUserToResizeRows = false;
            this.dgvcheques.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoCheque,
            this.Moneda,
            this.Monto,
            this.ID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcheques.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcheques.EnableHeadersVisualStyles = false;
            this.dgvcheques.Location = new System.Drawing.Point(21, 197);
            this.dgvcheques.MultiSelect = false;
            this.dgvcheques.Name = "dgvcheques";
            this.dgvcheques.ReadOnly = true;
            this.dgvcheques.RowHeadersVisible = false;
            this.dgvcheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcheques.Size = new System.Drawing.Size(607, 174);
            this.dgvcheques.TabIndex = 21;
            this.dgvcheques.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcheques_CellClick);
            this.dgvcheques.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvcheques_MouseClick);
            // 
            // TipoCheque
            // 
            this.TipoCheque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipoCheque.DataPropertyName = "TipoCheque";
            this.TipoCheque.HeaderText = "Tipo Cheque";
            this.TipoCheque.Name = "TipoCheque";
            this.TipoCheque.ReadOnly = true;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "Moneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // gbTotalesCheques
            // 
            this.gbTotalesCheques.Controls.Add(this.txtChequesUSD);
            this.gbTotalesCheques.Controls.Add(this.txtChequeExtranjeroUSD);
            this.gbTotalesCheques.Controls.Add(this.txtChequeLocalUSD);
            this.gbTotalesCheques.Controls.Add(this.txtChequeCompensadoUSD);
            this.gbTotalesCheques.Controls.Add(this.label5);
            this.gbTotalesCheques.Controls.Add(this.lblEtiquetaColones);
            this.gbTotalesCheques.Controls.Add(this.txtChequesCRC);
            this.gbTotalesCheques.Controls.Add(this.lblTotalCheques);
            this.gbTotalesCheques.Controls.Add(this.txtChequeExtranjeroCRC);
            this.gbTotalesCheques.Controls.Add(this.lblTotalChequeExtranjero);
            this.gbTotalesCheques.Controls.Add(this.txtChequeLocalCRC);
            this.gbTotalesCheques.Controls.Add(this.lblTotalChequeLocal);
            this.gbTotalesCheques.Controls.Add(this.txtChequeCompensadoCRC);
            this.gbTotalesCheques.Controls.Add(this.lblTotalChequeCompensado);
            this.gbTotalesCheques.Location = new System.Drawing.Point(12, 420);
            this.gbTotalesCheques.Name = "gbTotalesCheques";
            this.gbTotalesCheques.Size = new System.Drawing.Size(629, 152);
            this.gbTotalesCheques.TabIndex = 22;
            this.gbTotalesCheques.TabStop = false;
            this.gbTotalesCheques.Text = "Resumen Totales Cheques";
            // 
            // txtChequesUSD
            // 
            this.txtChequesUSD.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtChequesUSD.Location = new System.Drawing.Point(387, 127);
            this.txtChequesUSD.Name = "txtChequesUSD";
            this.txtChequesUSD.ReadOnly = true;
            this.txtChequesUSD.Size = new System.Drawing.Size(199, 20);
            this.txtChequesUSD.TabIndex = 15;
            // 
            // txtChequeExtranjeroUSD
            // 
            this.txtChequeExtranjeroUSD.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtChequeExtranjeroUSD.Location = new System.Drawing.Point(387, 101);
            this.txtChequeExtranjeroUSD.Name = "txtChequeExtranjeroUSD";
            this.txtChequeExtranjeroUSD.ReadOnly = true;
            this.txtChequeExtranjeroUSD.Size = new System.Drawing.Size(199, 20);
            this.txtChequeExtranjeroUSD.TabIndex = 14;
            // 
            // txtChequeLocalUSD
            // 
            this.txtChequeLocalUSD.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtChequeLocalUSD.Location = new System.Drawing.Point(387, 75);
            this.txtChequeLocalUSD.Name = "txtChequeLocalUSD";
            this.txtChequeLocalUSD.ReadOnly = true;
            this.txtChequeLocalUSD.Size = new System.Drawing.Size(199, 20);
            this.txtChequeLocalUSD.TabIndex = 13;
            // 
            // txtChequeCompensadoUSD
            // 
            this.txtChequeCompensadoUSD.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtChequeCompensadoUSD.Location = new System.Drawing.Point(387, 46);
            this.txtChequeCompensadoUSD.Name = "txtChequeCompensadoUSD";
            this.txtChequeCompensadoUSD.ReadOnly = true;
            this.txtChequeCompensadoUSD.Size = new System.Drawing.Size(199, 20);
            this.txtChequeCompensadoUSD.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dólares";
            // 
            // lblEtiquetaColones
            // 
            this.lblEtiquetaColones.AutoSize = true;
            this.lblEtiquetaColones.Location = new System.Drawing.Point(224, 15);
            this.lblEtiquetaColones.Name = "lblEtiquetaColones";
            this.lblEtiquetaColones.Size = new System.Drawing.Size(45, 13);
            this.lblEtiquetaColones.TabIndex = 10;
            this.lblEtiquetaColones.Text = "Colones";
            // 
            // txtChequesCRC
            // 
            this.txtChequesCRC.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtChequesCRC.Location = new System.Drawing.Point(151, 127);
            this.txtChequesCRC.Name = "txtChequesCRC";
            this.txtChequesCRC.ReadOnly = true;
            this.txtChequesCRC.Size = new System.Drawing.Size(199, 20);
            this.txtChequesCRC.TabIndex = 9;
            // 
            // lblTotalCheques
            // 
            this.lblTotalCheques.AutoSize = true;
            this.lblTotalCheques.Location = new System.Drawing.Point(66, 130);
            this.lblTotalCheques.Name = "lblTotalCheques";
            this.lblTotalCheques.Size = new System.Drawing.Size(79, 13);
            this.lblTotalCheques.TabIndex = 8;
            this.lblTotalCheques.Text = "Total Cheques:";
            // 
            // txtChequeExtranjeroCRC
            // 
            this.txtChequeExtranjeroCRC.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtChequeExtranjeroCRC.Location = new System.Drawing.Point(151, 101);
            this.txtChequeExtranjeroCRC.Name = "txtChequeExtranjeroCRC";
            this.txtChequeExtranjeroCRC.ReadOnly = true;
            this.txtChequeExtranjeroCRC.Size = new System.Drawing.Size(199, 20);
            this.txtChequeExtranjeroCRC.TabIndex = 7;
            // 
            // lblTotalChequeExtranjero
            // 
            this.lblTotalChequeExtranjero.AutoSize = true;
            this.lblTotalChequeExtranjero.Location = new System.Drawing.Point(21, 101);
            this.lblTotalChequeExtranjero.Name = "lblTotalChequeExtranjero";
            this.lblTotalChequeExtranjero.Size = new System.Drawing.Size(124, 13);
            this.lblTotalChequeExtranjero.TabIndex = 6;
            this.lblTotalChequeExtranjero.Text = "Total Cheque Extranjero:";
            // 
            // txtChequeLocalCRC
            // 
            this.txtChequeLocalCRC.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtChequeLocalCRC.Location = new System.Drawing.Point(151, 75);
            this.txtChequeLocalCRC.Name = "txtChequeLocalCRC";
            this.txtChequeLocalCRC.ReadOnly = true;
            this.txtChequeLocalCRC.Size = new System.Drawing.Size(199, 20);
            this.txtChequeLocalCRC.TabIndex = 5;
            // 
            // lblTotalChequeLocal
            // 
            this.lblTotalChequeLocal.AutoSize = true;
            this.lblTotalChequeLocal.Location = new System.Drawing.Point(42, 75);
            this.lblTotalChequeLocal.Name = "lblTotalChequeLocal";
            this.lblTotalChequeLocal.Size = new System.Drawing.Size(103, 13);
            this.lblTotalChequeLocal.TabIndex = 4;
            this.lblTotalChequeLocal.Text = "Total Cheque Local:";
            // 
            // txtChequeCompensadoCRC
            // 
            this.txtChequeCompensadoCRC.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtChequeCompensadoCRC.Location = new System.Drawing.Point(151, 46);
            this.txtChequeCompensadoCRC.Name = "txtChequeCompensadoCRC";
            this.txtChequeCompensadoCRC.ReadOnly = true;
            this.txtChequeCompensadoCRC.Size = new System.Drawing.Size(199, 20);
            this.txtChequeCompensadoCRC.TabIndex = 3;
            // 
            // lblTotalChequeCompensado
            // 
            this.lblTotalChequeCompensado.AutoSize = true;
            this.lblTotalChequeCompensado.Location = new System.Drawing.Point(6, 49);
            this.lblTotalChequeCompensado.Name = "lblTotalChequeCompensado";
            this.lblTotalChequeCompensado.Size = new System.Drawing.Size(139, 13);
            this.lblTotalChequeCompensado.TabIndex = 2;
            this.lblTotalChequeCompensado.Text = "Total Cheque Compensado:";
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.Image = global::GUILayer.Properties.Resources.salir;
            this.btnVolver.Location = new System.Drawing.Point(375, 581);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(90, 40);
            this.btnVolver.TabIndex = 24;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.FlatAppearance.BorderSize = 2;
            this.btnIncluir.Location = new System.Drawing.Point(214, 583);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(90, 38);
            this.btnIncluir.TabIndex = 23;
            this.btnIncluir.Text = "Incluir cheques";
            this.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIncluir.UseVisualStyleBackColor = false;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pictureBox1);
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(2, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(790, 60);
            this.pnlFondo.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(425, 58);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // btnQuitarCheque
            // 
            this.btnQuitarCheque.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarCheque.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnQuitarCheque.Location = new System.Drawing.Point(272, 377);
            this.btnQuitarCheque.Name = "btnQuitarCheque";
            this.btnQuitarCheque.Size = new System.Drawing.Size(90, 40);
            this.btnQuitarCheque.TabIndex = 26;
            this.btnQuitarCheque.Text = "Quitar";
            this.btnQuitarCheque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarCheque.UseVisualStyleBackColor = false;
            this.btnQuitarCheque.Click += new System.EventHandler(this.btnQuitarCheque_Click);
            // 
            // frmActualizarIngresoChequesCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 633);
            this.Controls.Add(this.btnQuitarCheque);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.gbTotalesCheques);
            this.Controls.Add(this.dgvcheques);
            this.Controls.Add(this.gbregistrocheque);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmActualizarIngresoChequesCE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesamiento Bajo Volumen - Ingreso de Cheques";
            this.Load += new System.EventHandler(this.frmIngresoChequesCE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.gbregistrocheque.ResumeLayout(false);
            this.gbregistrocheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcheques)).EndInit();
            this.gbTotalesCheques.ResumeLayout(false);
            this.gbTotalesCheques.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipoCheque;
        private System.Windows.Forms.Label lblTipoCheque;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.GroupBox gbregistrocheque;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvcheques;
        private System.Windows.Forms.GroupBox gbTotalesCheques;
        private System.Windows.Forms.TextBox txtChequesUSD;
        private System.Windows.Forms.TextBox txtChequeExtranjeroUSD;
        private System.Windows.Forms.TextBox txtChequeLocalUSD;
        private System.Windows.Forms.TextBox txtChequeCompensadoUSD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEtiquetaColones;
        private System.Windows.Forms.TextBox txtChequesCRC;
        private System.Windows.Forms.Label lblTotalCheques;
        private System.Windows.Forms.TextBox txtChequeExtranjeroCRC;
        private System.Windows.Forms.Label lblTotalChequeExtranjero;
        private System.Windows.Forms.TextBox txtChequeLocalCRC;
        private System.Windows.Forms.Label lblTotalChequeLocal;
        private System.Windows.Forms.TextBox txtChequeCompensadoCRC;
        private System.Windows.Forms.Label lblTotalChequeCompensado;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.Button btnQuitarCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}