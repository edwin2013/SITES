namespace GUILayer.Formularios.Boveda
{
    partial class frmRecepcionEntregaTulas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionEntregaTulas));
            this.tbRecepcion = new System.Windows.Forms.TabControl();
            this.tpPedidoBoveda = new System.Windows.Forms.TabPage();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblTulaPedido = new System.Windows.Forms.Label();
            this.txtNumeroMarchamoTula = new System.Windows.Forms.TextBox();
            this.dgvManifiestoRecepcion = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Punto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpEntregaBoveda = new System.Windows.Forms.TabPage();
            this.dgvCargasEntrega = new System.Windows.Forms.DataGridView();
            this.TulaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Encargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizarEntrega = new System.Windows.Forms.Button();
            this.lblTulaEntrega = new System.Windows.Forms.Label();
            this.txtMarchamoTulaEntrega = new System.Windows.Forms.TextBox();
            this.chkRuta = new System.Windows.Forms.CheckBox();
            this.nudRuta = new System.Windows.Forms.NumericUpDown();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbRecepcion.SuspendLayout();
            this.tpPedidoBoveda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestoRecepcion)).BeginInit();
            this.tpEntregaBoveda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRecepcion
            // 
            this.tbRecepcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecepcion.Controls.Add(this.tpPedidoBoveda);
            this.tbRecepcion.Controls.Add(this.tpEntregaBoveda);
            this.tbRecepcion.Location = new System.Drawing.Point(12, 98);
            this.tbRecepcion.Name = "tbRecepcion";
            this.tbRecepcion.SelectedIndex = 0;
            this.tbRecepcion.Size = new System.Drawing.Size(873, 416);
            this.tbRecepcion.TabIndex = 0;
            // 
            // tpPedidoBoveda
            // 
            this.tpPedidoBoveda.Controls.Add(this.btnActualizar);
            this.tpPedidoBoveda.Controls.Add(this.lblTulaPedido);
            this.tpPedidoBoveda.Controls.Add(this.txtNumeroMarchamoTula);
            this.tpPedidoBoveda.Controls.Add(this.dgvManifiestoRecepcion);
            this.tpPedidoBoveda.Location = new System.Drawing.Point(4, 22);
            this.tpPedidoBoveda.Name = "tpPedidoBoveda";
            this.tpPedidoBoveda.Padding = new System.Windows.Forms.Padding(3);
            this.tpPedidoBoveda.Size = new System.Drawing.Size(865, 390);
            this.tpPedidoBoveda.TabIndex = 0;
            this.tpPedidoBoveda.Text = "Recepción de Ruta";
            this.tpPedidoBoveda.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(490, 37);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblTulaPedido
            // 
            this.lblTulaPedido.AutoSize = true;
            this.lblTulaPedido.Location = new System.Drawing.Point(31, 51);
            this.lblTulaPedido.Name = "lblTulaPedido";
            this.lblTulaPedido.Size = new System.Drawing.Size(132, 13);
            this.lblTulaPedido.TabIndex = 5;
            this.lblTulaPedido.Text = "Tula/Márchamo Adicional:";
            // 
            // txtNumeroMarchamoTula
            // 
            this.txtNumeroMarchamoTula.Location = new System.Drawing.Point(180, 48);
            this.txtNumeroMarchamoTula.Name = "txtNumeroMarchamoTula";
            this.txtNumeroMarchamoTula.Size = new System.Drawing.Size(291, 20);
            this.txtNumeroMarchamoTula.TabIndex = 4;
            this.txtNumeroMarchamoTula.Enter += new System.EventHandler(this.txtNumeroMarchamoTula_Enter);
            this.txtNumeroMarchamoTula.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroMarchamoTula_KeyUp);
            // 
            // dgvManifiestoRecepcion
            // 
            this.dgvManifiestoRecepcion.AllowUserToAddRows = false;
            this.dgvManifiestoRecepcion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvManifiestoRecepcion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvManifiestoRecepcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManifiestoRecepcion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManifiestoRecepcion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestoRecepcion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula,
            this.Tipo,
            this.Punto,
            this.Hora,
            this.Colaborador});
            this.dgvManifiestoRecepcion.EnableHeadersVisualStyles = false;
            this.dgvManifiestoRecepcion.Location = new System.Drawing.Point(21, 103);
            this.dgvManifiestoRecepcion.Name = "dgvManifiestoRecepcion";
            this.dgvManifiestoRecepcion.ReadOnly = true;
            this.dgvManifiestoRecepcion.RowHeadersVisible = false;
            this.dgvManifiestoRecepcion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestoRecepcion.Size = new System.Drawing.Size(824, 264);
            this.dgvManifiestoRecepcion.TabIndex = 3;
            // 
            // Tula
            // 
            this.Tula.DataPropertyName = "Dato";
            this.Tula.HeaderText = "Tula o Márchamo";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            this.Tula.Width = 114;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "TipoCargas";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 52;
            // 
            // Punto
            // 
            this.Punto.DataPropertyName = "Nombre";
            this.Punto.HeaderText = "Punto de Entrega";
            this.Punto.Name = "Punto";
            this.Punto.ReadOnly = true;
            this.Punto.Width = 114;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "HoraRecibidoBoveda";
            dataGridViewCellStyle26.Format = "G";
            dataGridViewCellStyle26.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle26;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 54;
            // 
            // Colaborador
            // 
            this.Colaborador.DataPropertyName = "Cajero";
            this.Colaborador.HeaderText = "Encargado";
            this.Colaborador.Name = "Colaborador";
            this.Colaborador.ReadOnly = true;
            this.Colaborador.Width = 83;
            // 
            // tpEntregaBoveda
            // 
            this.tpEntregaBoveda.Controls.Add(this.panel1);
            this.tpEntregaBoveda.Controls.Add(this.dgvCargasEntrega);
            this.tpEntregaBoveda.Location = new System.Drawing.Point(4, 22);
            this.tpEntregaBoveda.Name = "tpEntregaBoveda";
            this.tpEntregaBoveda.Padding = new System.Windows.Forms.Padding(3);
            this.tpEntregaBoveda.Size = new System.Drawing.Size(865, 390);
            this.tpEntregaBoveda.TabIndex = 1;
            this.tpEntregaBoveda.Text = "Entrega a Ruta";
            this.tpEntregaBoveda.UseVisualStyleBackColor = true;
            this.tpEntregaBoveda.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvCargasEntrega
            // 
            this.dgvCargasEntrega.AllowUserToAddRows = false;
            this.dgvCargasEntrega.AllowUserToDeleteRows = false;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCargasEntrega.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvCargasEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargasEntrega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCargasEntrega.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargasEntrega.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TulaEntrega,
            this.TipoEntrega,
            this.NombreEntrega,
            this.HoraEntrega,
            this.Encargado});
            this.dgvCargasEntrega.EnableHeadersVisualStyles = false;
            this.dgvCargasEntrega.Location = new System.Drawing.Point(21, 102);
            this.dgvCargasEntrega.Name = "dgvCargasEntrega";
            this.dgvCargasEntrega.ReadOnly = true;
            this.dgvCargasEntrega.RowHeadersVisible = false;
            this.dgvCargasEntrega.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargasEntrega.Size = new System.Drawing.Size(824, 264);
            this.dgvCargasEntrega.TabIndex = 5;
            // 
            // TulaEntrega
            // 
            this.TulaEntrega.DataPropertyName = "Dato";
            this.TulaEntrega.HeaderText = "Tula o Márchamo";
            this.TulaEntrega.Name = "TulaEntrega";
            this.TulaEntrega.ReadOnly = true;
            this.TulaEntrega.Width = 114;
            // 
            // TipoEntrega
            // 
            this.TipoEntrega.DataPropertyName = "TipoCargas";
            this.TipoEntrega.HeaderText = "Tipo";
            this.TipoEntrega.Name = "TipoEntrega";
            this.TipoEntrega.ReadOnly = true;
            this.TipoEntrega.Width = 52;
            // 
            // NombreEntrega
            // 
            this.NombreEntrega.DataPropertyName = "Nombre";
            this.NombreEntrega.HeaderText = "Punto de Entrega";
            this.NombreEntrega.Name = "NombreEntrega";
            this.NombreEntrega.ReadOnly = true;
            this.NombreEntrega.Width = 114;
            // 
            // HoraEntrega
            // 
            this.HoraEntrega.DataPropertyName = "HoraRecibidoBoveda";
            dataGridViewCellStyle28.Format = "G";
            dataGridViewCellStyle28.NullValue = null;
            this.HoraEntrega.DefaultCellStyle = dataGridViewCellStyle28;
            this.HoraEntrega.HeaderText = "Hora";
            this.HoraEntrega.Name = "HoraEntrega";
            this.HoraEntrega.ReadOnly = true;
            this.HoraEntrega.Width = 54;
            // 
            // Encargado
            // 
            this.Encargado.DataPropertyName = "Cajero";
            this.Encargado.HeaderText = "Encargado";
            this.Encargado.Name = "Encargado";
            this.Encargado.ReadOnly = true;
            this.Encargado.Width = 83;
            // 
            // btnActualizarEntrega
            // 
            this.btnActualizarEntrega.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizarEntrega.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizarEntrega.Enabled = false;
            this.btnActualizarEntrega.FlatAppearance.BorderSize = 2;
            this.btnActualizarEntrega.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizarEntrega.Location = new System.Drawing.Point(410, 12);
            this.btnActualizarEntrega.Name = "btnActualizarEntrega";
            this.btnActualizarEntrega.Size = new System.Drawing.Size(93, 40);
            this.btnActualizarEntrega.TabIndex = 4;
            this.btnActualizarEntrega.Text = "Actualizar";
            this.btnActualizarEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarEntrega.UseVisualStyleBackColor = false;
            this.btnActualizarEntrega.Click += new System.EventHandler(this.btnActualizarEntrega_Click);
            // 
            // lblTulaEntrega
            // 
            this.lblTulaEntrega.AutoSize = true;
            this.lblTulaEntrega.Location = new System.Drawing.Point(5, 26);
            this.lblTulaEntrega.Name = "lblTulaEntrega";
            this.lblTulaEntrega.Size = new System.Drawing.Size(89, 13);
            this.lblTulaEntrega.TabIndex = 3;
            this.lblTulaEntrega.Text = "Tula/Márchamo: ";
            // 
            // txtMarchamoTulaEntrega
            // 
            this.txtMarchamoTulaEntrega.Location = new System.Drawing.Point(100, 23);
            this.txtMarchamoTulaEntrega.Name = "txtMarchamoTulaEntrega";
            this.txtMarchamoTulaEntrega.Size = new System.Drawing.Size(291, 20);
            this.txtMarchamoTulaEntrega.TabIndex = 1;
            this.txtMarchamoTulaEntrega.Enter += new System.EventHandler(this.txtMarchamoTulaEntrega_Enter);
            this.txtMarchamoTulaEntrega.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMarchamoTulaEntrega_KeyUp);
            // 
            // chkRuta
            // 
            this.chkRuta.AutoSize = true;
            this.chkRuta.Location = new System.Drawing.Point(418, 61);
            this.chkRuta.Name = "chkRuta";
            this.chkRuta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRuta.Size = new System.Drawing.Size(52, 17);
            this.chkRuta.TabIndex = 7;
            this.chkRuta.Text = "Ruta:";
            this.chkRuta.UseVisualStyleBackColor = true;
            this.chkRuta.CheckedChanged += new System.EventHandler(this.chkRuta_CheckedChanged);
            // 
            // nudRuta
            // 
            this.nudRuta.Enabled = false;
            this.nudRuta.Location = new System.Drawing.Point(476, 58);
            this.nudRuta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRuta.Name = "nudRuta";
            this.nudRuta.Size = new System.Drawing.Size(77, 20);
            this.nudRuta.TabIndex = 8;
            this.nudRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRuta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(791, 534);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 45);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(390, 44);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(898, 50);
            this.pnlFondo.TabIndex = 8;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(156, 58);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 9;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(80, 65);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnActualizarEntrega);
            this.panel1.Controls.Add(this.lblTulaEntrega);
            this.panel1.Controls.Add(this.txtMarchamoTulaEntrega);
            this.panel1.Location = new System.Drawing.Point(21, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 69);
            this.panel1.TabIndex = 6;
            // 
            // frmRecepcionEntregaTulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(899, 584);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.chkRuta);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.nudRuta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tbRecepcion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecepcionEntregaTulas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepción y Entrega de Tulas";
            this.tbRecepcion.ResumeLayout(false);
            this.tpPedidoBoveda.ResumeLayout(false);
            this.tpPedidoBoveda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestoRecepcion)).EndInit();
            this.tpEntregaBoveda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbRecepcion;
        private System.Windows.Forms.TabPage tpPedidoBoveda;
        private System.Windows.Forms.TabPage tpEntregaBoveda;
        private System.Windows.Forms.Label lblTulaPedido;
        private System.Windows.Forms.Label lblTulaEntrega;
        private System.Windows.Forms.TextBox txtMarchamoTulaEntrega;
        private System.Windows.Forms.DataGridView dgvManifiestoRecepcion;
        private System.Windows.Forms.TextBox txtNumeroMarchamoTula;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizarEntrega;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.DataGridView dgvCargasEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Punto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colaborador;
        private System.Windows.Forms.DataGridViewTextBoxColumn TulaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Encargado;
        private System.Windows.Forms.CheckBox chkRuta;
        private System.Windows.Forms.NumericUpDown nudRuta;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panel1;

    }
}