namespace GUILayer.Formularios.Sucursales
{
    partial class frmRecepcionEntregaTulasSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionEntregaTulasSucursales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tbRecepcion = new System.Windows.Forms.TabControl();
            this.tpPedidoSucursal = new System.Windows.Forms.TabPage();
            this.txtNumeroMarchamoTula = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvManifiestoRecepcion = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Punto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpEntregaBoveda = new System.Windows.Forms.TabPage();
            this.dgvCargasEntrega = new System.Windows.Forms.DataGridView();
            this.TulaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgtcSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcColaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMarchamoTula = new System.Windows.Forms.TextBox();
            this.btnActualizarEntrega = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.chkRuta = new System.Windows.Forms.CheckBox();
            this.nudRuta = new System.Windows.Forms.NumericUpDown();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.tbRecepcion.SuspendLayout();
            this.tpPedidoSucursal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestoRecepcion)).BeginInit();
            this.tpEntregaBoveda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-2, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(888, 50);
            this.pnlFondo.TabIndex = 11;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(2, -1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(392, 49);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(791, 547);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 45);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tbRecepcion
            // 
            this.tbRecepcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecepcion.Controls.Add(this.tpPedidoSucursal);
            this.tbRecepcion.Controls.Add(this.tpEntregaBoveda);
            this.tbRecepcion.Location = new System.Drawing.Point(12, 101);
            this.tbRecepcion.Name = "tbRecepcion";
            this.tbRecepcion.SelectedIndex = 0;
            this.tbRecepcion.Size = new System.Drawing.Size(873, 444);
            this.tbRecepcion.TabIndex = 9;
            // 
            // tpPedidoSucursal
            // 
            this.tpPedidoSucursal.Controls.Add(this.txtNumeroMarchamoTula);
            this.tpPedidoSucursal.Controls.Add(this.btnActualizar);
            this.tpPedidoSucursal.Controls.Add(this.label2);
            this.tpPedidoSucursal.Controls.Add(this.dgvManifiestoRecepcion);
            this.tpPedidoSucursal.Location = new System.Drawing.Point(4, 22);
            this.tpPedidoSucursal.Name = "tpPedidoSucursal";
            this.tpPedidoSucursal.Padding = new System.Windows.Forms.Padding(3);
            this.tpPedidoSucursal.Size = new System.Drawing.Size(865, 418);
            this.tpPedidoSucursal.TabIndex = 0;
            this.tpPedidoSucursal.Text = "Pedido de Sucursal";
            this.tpPedidoSucursal.UseVisualStyleBackColor = true;
            // 
            // txtNumeroMarchamoTula
            // 
            this.txtNumeroMarchamoTula.Location = new System.Drawing.Point(181, 48);
            this.txtNumeroMarchamoTula.Name = "txtNumeroMarchamoTula";
            this.txtNumeroMarchamoTula.Size = new System.Drawing.Size(291, 20);
            this.txtNumeroMarchamoTula.TabIndex = 7;
            this.txtNumeroMarchamoTula.Enter += new System.EventHandler(this.txtNumeroMarchamoTula_Enter);
            this.txtNumeroMarchamoTula.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroMarchamoTula_KeyUp);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(509, 37);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número Tula/Márchamo:";
            // 
            // dgvManifiestoRecepcion
            // 
            this.dgvManifiestoRecepcion.AllowUserToAddRows = false;
            this.dgvManifiestoRecepcion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvManifiestoRecepcion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvManifiestoRecepcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManifiestoRecepcion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManifiestoRecepcion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestoRecepcion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula,
            this.Punto,
            this.Hora,
            this.Colaborador});
            this.dgvManifiestoRecepcion.EnableHeadersVisualStyles = false;
            this.dgvManifiestoRecepcion.Location = new System.Drawing.Point(21, 103);
            this.dgvManifiestoRecepcion.Name = "dgvManifiestoRecepcion";
            this.dgvManifiestoRecepcion.ReadOnly = true;
            this.dgvManifiestoRecepcion.RowHeadersVisible = false;
            this.dgvManifiestoRecepcion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestoRecepcion.Size = new System.Drawing.Size(824, 292);
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
            this.Hora.DataPropertyName = "Fecha_Verificacion";
            dataGridViewCellStyle28.Format = "G";
            dataGridViewCellStyle28.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle28;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 54;
            // 
            // Colaborador
            // 
            this.Colaborador.DataPropertyName = "Cajero";
            this.Colaborador.HeaderText = "Cajero";
            this.Colaborador.Name = "Colaborador";
            this.Colaborador.ReadOnly = true;
            this.Colaborador.Width = 61;
            // 
            // tpEntregaBoveda
            // 
            this.tpEntregaBoveda.Controls.Add(this.dgvCargasEntrega);
            this.tpEntregaBoveda.Controls.Add(this.label1);
            this.tpEntregaBoveda.Controls.Add(this.txtMarchamoTula);
            this.tpEntregaBoveda.Controls.Add(this.btnActualizarEntrega);
            this.tpEntregaBoveda.Location = new System.Drawing.Point(4, 22);
            this.tpEntregaBoveda.Name = "tpEntregaBoveda";
            this.tpEntregaBoveda.Size = new System.Drawing.Size(865, 418);
            this.tpEntregaBoveda.TabIndex = 2;
            this.tpEntregaBoveda.Text = "Entrega a  Bóveda";
            this.tpEntregaBoveda.UseVisualStyleBackColor = true;
            // 
            // dgvCargasEntrega
            // 
            this.dgvCargasEntrega.AllowUserToAddRows = false;
            this.dgvCargasEntrega.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCargasEntrega.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvCargasEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargasEntrega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCargasEntrega.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargasEntrega.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TulaEntrega,
            this.dgtcSucursal,
            this.dgvtcHora,
            this.dgvtcColaborador});
            this.dgvCargasEntrega.EnableHeadersVisualStyles = false;
            this.dgvCargasEntrega.Location = new System.Drawing.Point(20, 106);
            this.dgvCargasEntrega.Name = "dgvCargasEntrega";
            this.dgvCargasEntrega.ReadOnly = true;
            this.dgvCargasEntrega.RowHeadersVisible = false;
            this.dgvCargasEntrega.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargasEntrega.Size = new System.Drawing.Size(824, 292);
            this.dgvCargasEntrega.TabIndex = 9;
            // 
            // TulaEntrega
            // 
            this.TulaEntrega.DataPropertyName = "Dato";
            this.TulaEntrega.HeaderText = "Tula o Márchamo";
            this.TulaEntrega.Name = "TulaEntrega";
            this.TulaEntrega.ReadOnly = true;
            this.TulaEntrega.Width = 114;
            // 
            // dgtcSucursal
            // 
            this.dgtcSucursal.DataPropertyName = "Nombre";
            this.dgtcSucursal.HeaderText = "Punto de Entrega";
            this.dgtcSucursal.Name = "dgtcSucursal";
            this.dgtcSucursal.ReadOnly = true;
            this.dgtcSucursal.Width = 114;
            // 
            // dgvtcHora
            // 
            this.dgvtcHora.DataPropertyName = "Fecha_Verificacion";
            dataGridViewCellStyle26.Format = "G";
            dataGridViewCellStyle26.NullValue = null;
            this.dgvtcHora.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvtcHora.HeaderText = "Hora";
            this.dgvtcHora.Name = "dgvtcHora";
            this.dgvtcHora.ReadOnly = true;
            this.dgvtcHora.Width = 54;
            // 
            // dgvtcColaborador
            // 
            this.dgvtcColaborador.DataPropertyName = "Cajero";
            this.dgvtcColaborador.HeaderText = "Cajero";
            this.dgvtcColaborador.Name = "dgvtcColaborador";
            this.dgvtcColaborador.ReadOnly = true;
            this.dgvtcColaborador.Width = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Número Tula/Márchamo:";
            // 
            // txtMarchamoTula
            // 
            this.txtMarchamoTula.Location = new System.Drawing.Point(172, 51);
            this.txtMarchamoTula.Name = "txtMarchamoTula";
            this.txtMarchamoTula.Size = new System.Drawing.Size(291, 20);
            this.txtMarchamoTula.TabIndex = 6;
            this.txtMarchamoTula.Enter += new System.EventHandler(this.txtMarchamoTula_Enter);
            this.txtMarchamoTula.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMarchamoTula_KeyUp);
            // 
            // btnActualizarEntrega
            // 
            this.btnActualizarEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarEntrega.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizarEntrega.FlatAppearance.BorderSize = 2;
            this.btnActualizarEntrega.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizarEntrega.Location = new System.Drawing.Point(508, 40);
            this.btnActualizarEntrega.Name = "btnActualizarEntrega";
            this.btnActualizarEntrega.Size = new System.Drawing.Size(93, 40);
            this.btnActualizarEntrega.TabIndex = 8;
            this.btnActualizarEntrega.Text = "Actualizar";
            this.btnActualizarEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarEntrega.UseVisualStyleBackColor = false;
            this.btnActualizarEntrega.Click += new System.EventHandler(this.btnActualizarEntrega_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(101, 72);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(177, 65);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 14;
            // 
            // chkRuta
            // 
            this.chkRuta.AutoSize = true;
            this.chkRuta.Location = new System.Drawing.Point(439, 68);
            this.chkRuta.Name = "chkRuta";
            this.chkRuta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRuta.Size = new System.Drawing.Size(52, 17);
            this.chkRuta.TabIndex = 12;
            this.chkRuta.Text = "Ruta:";
            this.chkRuta.UseVisualStyleBackColor = true;
            this.chkRuta.CheckedChanged += new System.EventHandler(this.chkRuta_CheckedChanged);
            // 
            // nudRuta
            // 
            this.nudRuta.Enabled = false;
            this.nudRuta.Location = new System.Drawing.Point(497, 65);
            this.nudRuta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRuta.Name = "nudRuta";
            this.nudRuta.Size = new System.Drawing.Size(77, 20);
            this.nudRuta.TabIndex = 13;
            this.nudRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRuta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmRecepcionEntregaTulasSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.chkRuta);
            this.Controls.Add(this.nudRuta);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tbRecepcion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecepcionEntregaTulasSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepcion y Entrega de Tulas de Sucursal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.tbRecepcion.ResumeLayout(false);
            this.tpPedidoSucursal.ResumeLayout(false);
            this.tpPedidoSucursal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestoRecepcion)).EndInit();
            this.tpEntregaBoveda.ResumeLayout(false);
            this.tpEntregaBoveda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TabControl tbRecepcion;
        private System.Windows.Forms.TabPage tpPedidoSucursal;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvManifiestoRecepcion;
        private System.Windows.Forms.TextBox txtNumeroMarchamoTula;
        private System.Windows.Forms.TabPage tpEntregaBoveda;
        private System.Windows.Forms.DataGridView dgvCargasEntrega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarchamoTula;
        private System.Windows.Forms.Button btnActualizarEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn TulaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgtcSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcColaborador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Punto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colaborador;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox chkRuta;
        private System.Windows.Forms.NumericUpDown nudRuta;

    }
}