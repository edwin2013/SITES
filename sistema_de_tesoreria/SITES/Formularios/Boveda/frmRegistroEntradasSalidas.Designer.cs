namespace GUILayer
{
    partial class frmRegistroEntradasSalidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroEntradasSalidas));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblCanal = new System.Windows.Forms.Label();
            this.cboCanal = new GUILayer.ComboBoxBusqueda();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMovimiento = new System.Windows.Forms.Label();
            this.cboMovimiento = new GUILayer.ComboBoxBusqueda();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gbMontos = new System.Windows.Forms.GroupBox();
            this.dgvCierre = new System.Windows.Forms.DataGridView();
            this.Denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.gbMontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierre)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblCanal);
            this.gbDatos.Controls.Add(this.cboCanal);
            this.gbDatos.Controls.Add(this.cboCliente);
            this.gbDatos.Controls.Add(this.lblCliente);
            this.gbDatos.Controls.Add(this.lblMovimiento);
            this.gbDatos.Controls.Add(this.cboMovimiento);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(374, 138);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del cierre";
            // 
            // lblCanal
            // 
            this.lblCanal.AutoSize = true;
            this.lblCanal.Location = new System.Drawing.Point(34, 76);
            this.lblCanal.Name = "lblCanal";
            this.lblCanal.Size = new System.Drawing.Size(37, 13);
            this.lblCanal.TabIndex = 4;
            this.lblCanal.Text = "Canal:";
            // 
            // cboCanal
            // 
            this.cboCanal.Busqueda = false;
            this.cboCanal.ListaMostrada = null;
            this.cboCanal.Location = new System.Drawing.Point(77, 73);
            this.cboCanal.Name = "cboCanal";
            this.cboCanal.Size = new System.Drawing.Size(285, 21);
            this.cboCanal.TabIndex = 5;
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(77, 46);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(285, 21);
            this.cboCliente.TabIndex = 3;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(29, 49);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblMovimiento
            // 
            this.lblMovimiento.AutoSize = true;
            this.lblMovimiento.Location = new System.Drawing.Point(7, 22);
            this.lblMovimiento.Name = "lblMovimiento";
            this.lblMovimiento.Size = new System.Drawing.Size(64, 13);
            this.lblMovimiento.TabIndex = 0;
            this.lblMovimiento.Text = "Movimiento:";
            // 
            // cboMovimiento
            // 
            this.cboMovimiento.Busqueda = false;
            this.cboMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMovimiento.ListaMostrada = null;
            this.cboMovimiento.Location = new System.Drawing.Point(77, 19);
            this.cboMovimiento.Name = "cboMovimiento";
            this.cboMovimiento.Size = new System.Drawing.Size(174, 21);
            this.cboMovimiento.TabIndex = 1;
            this.cboMovimiento.SelectedIndexChanged += new System.EventHandler(this.cboMovimiento_SelectedIndexChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(77, 100);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(285, 20);
            this.dtpFecha.TabIndex = 7;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(31, 106);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            // 
            // gbMontos
            // 
            this.gbMontos.Controls.Add(this.dgvCierre);
            this.gbMontos.Location = new System.Drawing.Point(12, 207);
            this.gbMontos.Name = "gbMontos";
            this.gbMontos.Size = new System.Drawing.Size(542, 407);
            this.gbMontos.TabIndex = 2;
            this.gbMontos.TabStop = false;
            this.gbMontos.Text = "Montos";
            // 
            // dgvCierre
            // 
            this.dgvCierre.AllowUserToAddRows = false;
            this.dgvCierre.AllowUserToDeleteRows = false;
            this.dgvCierre.AllowUserToOrderColumns = true;
            this.dgvCierre.AllowUserToResizeColumns = false;
            this.dgvCierre.AllowUserToResizeRows = false;
            this.dgvCierre.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCierre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Denominacion,
            this.Monto});
            this.dgvCierre.EnableHeadersVisualStyles = false;
            this.dgvCierre.Location = new System.Drawing.Point(6, 19);
            this.dgvCierre.Name = "dgvCierre";
            this.dgvCierre.RowHeadersVisible = false;
            this.dgvCierre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCierre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCierre.Size = new System.Drawing.Size(530, 382);
            this.dgvCierre.StandardTab = true;
            this.dgvCierre.TabIndex = 0;
            // 
            // Denominacion
            // 
            this.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Denominacion.DefaultCellStyle = dataGridViewCellStyle5;
            this.Denominacion.FillWeight = 28.48244F;
            this.Denominacion.Frozen = true;
            this.Denominacion.HeaderText = "Denominación";
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.ReadOnly = true;
            this.Denominacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Denominacion.Width = 287;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Monto.DefaultCellStyle = dataGridViewCellStyle6;
            this.Monto.FillWeight = 182.7411F;
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 240;
            this.Monto.Name = "Monto";
            this.Monto.Width = 240;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(602, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(368, 620);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 3;
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
            this.btnSalir.Location = new System.Drawing.Point(464, 620);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmRegistroEntradasSalidas
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(566, 672);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.gbMontos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistroEntradasSalidas";
            this.ShowInTaskbar = false;
            this.Text = "Registro de Entradas y Salidas de Bóveda de Níquel";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbMontos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierre)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblCliente;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox gbMontos;
        private System.Windows.Forms.DataGridView dgvCierre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblMovimiento;
        private ComboBoxBusqueda cboMovimiento;
        private System.Windows.Forms.Label lblCanal;
        private ComboBoxBusqueda cboCanal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
    }
}