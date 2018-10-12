namespace GUILayer
{
    partial class frmRegistroDenominacionesCajeros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroDenominacionesCajeros));
            this.dgvMontos = new System.Windows.Forms.DataGridView();
            this.Denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCoordinador = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCajero = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.chkProcesamientoExterno = new System.Windows.Forms.CheckBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnCorte = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.cboCoordinador = new GUILayer.ComboBoxBusqueda();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMontos
            // 
            this.dgvMontos.AllowUserToAddRows = false;
            this.dgvMontos.AllowUserToDeleteRows = false;
            this.dgvMontos.AllowUserToOrderColumns = true;
            this.dgvMontos.AllowUserToResizeColumns = false;
            this.dgvMontos.AllowUserToResizeRows = false;
            this.dgvMontos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvMontos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Denominacion,
            this.Monto});
            this.dgvMontos.Enabled = false;
            this.dgvMontos.EnableHeadersVisualStyles = false;
            this.dgvMontos.Location = new System.Drawing.Point(12, 188);
            this.dgvMontos.Name = "dgvMontos";
            this.dgvMontos.RowHeadersVisible = false;
            this.dgvMontos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontos.Size = new System.Drawing.Size(713, 444);
            this.dgvMontos.StandardTab = true;
            this.dgvMontos.TabIndex = 0;
            this.dgvMontos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMontos_CellEndEdit);
            this.dgvMontos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMontos_CellValueChanged);
            // 
            // Denominacion
            // 
            this.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Denominacion.DefaultCellStyle = dataGridViewCellStyle3;
            this.Denominacion.FillWeight = 28.48244F;
            this.Denominacion.HeaderText = "Denominación";
            this.Denominacion.MinimumWidth = 90;
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.ReadOnly = true;
            this.Denominacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle4;
            this.Monto.FillWeight = 182.7411F;
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 120;
            this.Monto.Name = "Monto";
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.AutoSize = true;
            this.lblCoordinador.Location = new System.Drawing.Point(9, 77);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(67, 13);
            this.lblCoordinador.TabIndex = 4;
            this.lblCoordinador.Text = "Coordinador:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(82, 48);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(241, 20);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.CloseUp += new System.EventHandler(this.dtpFecha_CloseUp);
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            this.dtpFecha.DropDown += new System.EventHandler(this.dtpFecha_DropDown);
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(36, 24);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 0;
            this.lblCajero.Text = "Cajero:";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.chkProcesamientoExterno);
            this.gbDatos.Controls.Add(this.lblCliente);
            this.gbDatos.Controls.Add(this.cboCliente);
            this.gbDatos.Controls.Add(this.lblTransportadora);
            this.gbDatos.Controls.Add(this.cboTransportadora);
            this.gbDatos.Controls.Add(this.cboCoordinador);
            this.gbDatos.Controls.Add(this.lblCoordinador);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.lblCajero);
            this.gbDatos.Controls.Add(this.cboCajero);
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(703, 105);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del cierre";
            // 
            // chkProcesamientoExterno
            // 
            this.chkProcesamientoExterno.AutoSize = true;
            this.chkProcesamientoExterno.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkProcesamientoExterno.Location = new System.Drawing.Point(347, 77);
            this.chkProcesamientoExterno.Name = "chkProcesamientoExterno";
            this.chkProcesamientoExterno.Size = new System.Drawing.Size(135, 17);
            this.chkProcesamientoExterno.TabIndex = 10;
            this.chkProcesamientoExterno.Text = "Procesamiento Externo";
            this.chkProcesamientoExterno.UseVisualStyleBackColor = true;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(344, 50);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 8;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(344, 22);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 6;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(36, 52);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1290, 60);
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
            // btnCorte
            // 
            this.btnCorte.Enabled = false;
            this.btnCorte.FlatAppearance.BorderSize = 2;
            this.btnCorte.Image = global::GUILayer.Properties.Resources.corte;
            this.btnCorte.Location = new System.Drawing.Point(337, 649);
            this.btnCorte.Name = "btnCorte";
            this.btnCorte.Size = new System.Drawing.Size(90, 40);
            this.btnCorte.TabIndex = 3;
            this.btnCorte.Text = "Corte";
            this.btnCorte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCorte.UseVisualStyleBackColor = false;
            this.btnCorte.Click += new System.EventHandler(this.btnCorte_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(433, 649);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(529, 649);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 5;
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
            this.btnSalir.Location = new System.Drawing.Point(625, 649);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(432, 47);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(241, 21);
            this.cboCliente.TabIndex = 9;
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = false;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(432, 19);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(241, 21);
            this.cboTransportadora.TabIndex = 7;
            // 
            // cboCoordinador
            // 
            this.cboCoordinador.Busqueda = false;
            this.cboCoordinador.Enabled = false;
            this.cboCoordinador.ListaMostrada = null;
            this.cboCoordinador.Location = new System.Drawing.Point(81, 74);
            this.cboCoordinador.Name = "cboCoordinador";
            this.cboCoordinador.Size = new System.Drawing.Size(242, 21);
            this.cboCoordinador.TabIndex = 5;
            this.cboCoordinador.TabStop = false;
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(82, 21);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(241, 21);
            this.cboCajero.TabIndex = 1;
            this.cboCajero.SelectedIndexChanged += new System.EventHandler(this.cboCajero_SelectedIndexChanged);
            // 
            // frmRegistroDenominacionesCajeros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 692);
            this.Controls.Add(this.dgvMontos);
            this.Controls.Add(this.btnCorte);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistroDenominacionesCajeros";
            this.ShowInTaskbar = false;
            this.Text = "Montos por Denominación";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMontos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblCoordinador;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblCajero;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCorte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private ComboBoxBusqueda cboCoordinador;
        private System.Windows.Forms.Label lblCliente;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblTransportadora;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.CheckBox chkProcesamientoExterno;
    }
}