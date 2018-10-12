namespace GUILayer
{
    partial class frmRegistroModificacionRecap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroModificacionRecap));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbMontos = new System.Windows.Forms.GroupBox();
            this.dgvMontos = new System.Windows.Forms.DataGridView();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.mtbReferencia = new System.Windows.Forms.MaskedTextBox();
            this.mtbCuenta = new System.Windows.Forms.MaskedTextBox();
            this.chkATM = new System.Windows.Forms.CheckBox();
            this.chkMatriz = new System.Windows.Forms.CheckBox();
            this.chkCuenta = new System.Windows.Forms.CheckBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMontos
            // 
            this.gbMontos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMontos.Controls.Add(this.dgvMontos);
            this.gbMontos.Location = new System.Drawing.Point(12, 178);
            this.gbMontos.Name = "gbMontos";
            this.gbMontos.Size = new System.Drawing.Size(489, 411);
            this.gbMontos.TabIndex = 1;
            this.gbMontos.TabStop = false;
            this.gbMontos.Text = "Montos";
            // 
            // dgvMontos
            // 
            this.dgvMontos.AllowUserToAddRows = false;
            this.dgvMontos.AllowUserToDeleteRows = false;
            this.dgvMontos.AllowUserToOrderColumns = true;
            this.dgvMontos.AllowUserToResizeColumns = false;
            this.dgvMontos.AllowUserToResizeRows = false;
            this.dgvMontos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Denominacion,
            this.Monto,
            this.Cantidad});
            this.dgvMontos.EnableHeadersVisualStyles = false;
            this.dgvMontos.Location = new System.Drawing.Point(6, 19);
            this.dgvMontos.Name = "dgvMontos";
            this.dgvMontos.RowHeadersVisible = false;
            this.dgvMontos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMontos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontos.Size = new System.Drawing.Size(477, 386);
            this.dgvMontos.StandardTab = true;
            this.dgvMontos.TabIndex = 0;
            this.dgvMontos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMontos_CellEndEdit);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(827, 48);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(379, 46);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.mtbReferencia);
            this.gbDatos.Controls.Add(this.mtbCuenta);
            this.gbDatos.Controls.Add(this.chkATM);
            this.gbDatos.Controls.Add(this.chkMatriz);
            this.gbDatos.Controls.Add(this.chkCuenta);
            this.gbDatos.Controls.Add(this.cboMoneda);
            this.gbDatos.Controls.Add(this.lblMoneda);
            this.gbDatos.Controls.Add(this.lblReferencia);
            this.gbDatos.Location = new System.Drawing.Point(12, 51);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(328, 121);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Recap";
            // 
            // mtbReferencia
            // 
            this.mtbReferencia.Location = new System.Drawing.Point(74, 46);
            this.mtbReferencia.Mask = "9999999999";
            this.mtbReferencia.Name = "mtbReferencia";
            this.mtbReferencia.Size = new System.Drawing.Size(248, 20);
            this.mtbReferencia.TabIndex = 3;
            // 
            // mtbCuenta
            // 
            this.mtbCuenta.Enabled = false;
            this.mtbCuenta.Location = new System.Drawing.Point(74, 72);
            this.mtbCuenta.Mask = "9999999999";
            this.mtbCuenta.Name = "mtbCuenta";
            this.mtbCuenta.Size = new System.Drawing.Size(248, 20);
            this.mtbCuenta.TabIndex = 5;
            // 
            // chkATM
            // 
            this.chkATM.AutoSize = true;
            this.chkATM.Location = new System.Drawing.Point(213, 98);
            this.chkATM.Name = "chkATM";
            this.chkATM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkATM.Size = new System.Drawing.Size(49, 17);
            this.chkATM.TabIndex = 6;
            this.chkATM.Text = "ATM";
            this.chkATM.UseVisualStyleBackColor = true;
            // 
            // chkMatriz
            // 
            this.chkMatriz.AutoSize = true;
            this.chkMatriz.Location = new System.Drawing.Point(268, 98);
            this.chkMatriz.Name = "chkMatriz";
            this.chkMatriz.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMatriz.Size = new System.Drawing.Size(54, 17);
            this.chkMatriz.TabIndex = 7;
            this.chkMatriz.Text = "Matriz";
            this.chkMatriz.UseVisualStyleBackColor = true;
            // 
            // chkCuenta
            // 
            this.chkCuenta.AutoSize = true;
            this.chkCuenta.Location = new System.Drawing.Point(8, 74);
            this.chkCuenta.Name = "chkCuenta";
            this.chkCuenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCuenta.Size = new System.Drawing.Size(60, 17);
            this.chkCuenta.TabIndex = 4;
            this.chkCuenta.Text = "Cuenta";
            this.chkCuenta.UseVisualStyleBackColor = true;
            this.chkCuenta.CheckedChanged += new System.EventHandler(this.chkCuenta_CheckedChanged);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares",
            "Euros"});
            this.cboMoneda.Location = new System.Drawing.Point(74, 19);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(248, 21);
            this.cboMoneda.TabIndex = 1;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(19, 23);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 0;
            this.lblMoneda.Text = "Moneda:";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(6, 50);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(62, 13);
            this.lblReferencia.TabIndex = 2;
            this.lblReferencia.Text = "Referencia:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(309, 595);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(405, 595);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Denominacion
            // 
            this.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Denominacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.Denominacion.FillWeight = 28.48244F;
            this.Denominacion.HeaderText = "Denominación";
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.ReadOnly = true;
            this.Denominacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N2";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle5;
            this.Monto.FillWeight = 88.77644F;
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 120;
            this.Monto.Name = "Monto";
            this.Monto.Width = 120;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle6;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // frmRegistroModificacionRecap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 647);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbMontos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistroModificacionRecap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Recaps";
            this.gbMontos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMontos;
        private System.Windows.Forms.DataGridView dgvMontos;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.CheckBox chkATM;
        private System.Windows.Forms.CheckBox chkMatriz;
        private System.Windows.Forms.CheckBox chkCuenta;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.MaskedTextBox mtbCuenta;
        private System.Windows.Forms.MaskedTextBox mtbReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}