namespace GUILayer
{
    partial class frmMantenimientoEsquemasManifiestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoEsquemasManifiestos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.nudAlto = new System.Windows.Forms.NumericUpDown();
            this.lblAlto = new System.Windows.Forms.Label();
            this.nudAncho = new System.Windows.Forms.NumericUpDown();
            this.lblAncho = new System.Windows.Forms.Label();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbPosiciones = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnAgregarPosicion = new System.Windows.Forms.Button();
            this.btnQuitarPosicion = new System.Windows.Forms.Button();
            this.dgvPosiciones = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicionX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicionY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesplazamientoVertical = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesplazamientoHorizontal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ancho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAncho)).BeginInit();
            this.gbPosiciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(530, 516);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(654, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(358, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.nudAlto);
            this.gbDatos.Controls.Add(this.lblAlto);
            this.gbDatos.Controls.Add(this.nudAncho);
            this.gbDatos.Controls.Add(this.lblAncho);
            this.gbDatos.Controls.Add(this.cboTransportadora);
            this.gbDatos.Controls.Add(this.lblTransportadora);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(512, 72);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Esquema";
            // 
            // nudAlto
            // 
            this.nudAlto.DecimalPlaces = 2;
            this.nudAlto.Location = new System.Drawing.Point(254, 46);
            this.nudAlto.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudAlto.Name = "nudAlto";
            this.nudAlto.Size = new System.Drawing.Size(120, 20);
            this.nudAlto.TabIndex = 5;
            // 
            // lblAlto
            // 
            this.lblAlto.AutoSize = true;
            this.lblAlto.Location = new System.Drawing.Point(220, 50);
            this.lblAlto.Name = "lblAlto";
            this.lblAlto.Size = new System.Drawing.Size(28, 13);
            this.lblAlto.TabIndex = 4;
            this.lblAlto.Text = "Alto:";
            // 
            // nudAncho
            // 
            this.nudAncho.DecimalPlaces = 2;
            this.nudAncho.Location = new System.Drawing.Point(94, 46);
            this.nudAncho.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudAncho.Name = "nudAncho";
            this.nudAncho.Size = new System.Drawing.Size(120, 20);
            this.nudAncho.TabIndex = 3;
            // 
            // lblAncho
            // 
            this.lblAncho.AutoSize = true;
            this.lblAncho.Location = new System.Drawing.Point(47, 50);
            this.lblAncho.Name = "lblAncho";
            this.lblAncho.Size = new System.Drawing.Size(41, 13);
            this.lblAncho.TabIndex = 2;
            this.lblAncho.Text = "Ancho:";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = false;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(94, 19);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(280, 21);
            this.cboTransportadora.TabIndex = 1;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(6, 23);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 0;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(434, 516);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbPosiciones
            // 
            this.gbPosiciones.Controls.Add(this.txtDescripcion);
            this.gbPosiciones.Controls.Add(this.lblDescripcion);
            this.gbPosiciones.Controls.Add(this.btnAgregarPosicion);
            this.gbPosiciones.Controls.Add(this.btnQuitarPosicion);
            this.gbPosiciones.Controls.Add(this.dgvPosiciones);
            this.gbPosiciones.Location = new System.Drawing.Point(12, 141);
            this.gbPosiciones.Name = "gbPosiciones";
            this.gbPosiciones.Size = new System.Drawing.Size(614, 369);
            this.gbPosiciones.TabIndex = 2;
            this.gbPosiciones.TabStop = false;
            this.gbPosiciones.Text = "Posiciones del Esquema";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(94, 24);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(277, 20);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(22, 28);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // btnAgregarPosicion
            // 
            this.btnAgregarPosicion.Enabled = false;
            this.btnAgregarPosicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPosicion.Location = new System.Drawing.Point(377, 19);
            this.btnAgregarPosicion.Name = "btnAgregarPosicion";
            this.btnAgregarPosicion.Size = new System.Drawing.Size(30, 30);
            this.btnAgregarPosicion.TabIndex = 2;
            this.btnAgregarPosicion.Text = "+";
            this.btnAgregarPosicion.UseVisualStyleBackColor = false;
            this.btnAgregarPosicion.Click += new System.EventHandler(this.btnAgregarPosicion_Click);
            // 
            // btnQuitarPosicion
            // 
            this.btnQuitarPosicion.Enabled = false;
            this.btnQuitarPosicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarPosicion.Location = new System.Drawing.Point(413, 18);
            this.btnQuitarPosicion.Name = "btnQuitarPosicion";
            this.btnQuitarPosicion.Size = new System.Drawing.Size(30, 30);
            this.btnQuitarPosicion.TabIndex = 3;
            this.btnQuitarPosicion.Text = "-";
            this.btnQuitarPosicion.UseVisualStyleBackColor = false;
            this.btnQuitarPosicion.Click += new System.EventHandler(this.btnQuitarPosicion_Click);
            // 
            // dgvPosiciones
            // 
            this.dgvPosiciones.AllowUserToAddRows = false;
            this.dgvPosiciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvPosiciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPosiciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPosiciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPosiciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPosiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.PosicionX,
            this.PosicionY,
            this.DesplazamientoVertical,
            this.DesplazamientoHorizontal,
            this.Ancho,
            this.Alto,
            this.ID});
            this.dgvPosiciones.EnableHeadersVisualStyles = false;
            this.dgvPosiciones.Location = new System.Drawing.Point(6, 55);
            this.dgvPosiciones.MultiSelect = false;
            this.dgvPosiciones.Name = "dgvPosiciones";
            this.dgvPosiciones.RowHeadersVisible = false;
            this.dgvPosiciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPosiciones.Size = new System.Drawing.Size(602, 308);
            this.dgvPosiciones.StandardTab = true;
            this.dgvPosiciones.TabIndex = 4;
            this.dgvPosiciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosiciones_CellValueChanged);
            this.dgvPosiciones.SelectionChanged += new System.EventHandler(this.dgvPosiciones_SelectionChanged);
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 87;
            // 
            // PosicionX
            // 
            this.PosicionX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PosicionX.DataPropertyName = "Posicion_x";
            dataGridViewCellStyle3.Format = "N2";
            this.PosicionX.DefaultCellStyle = dataGridViewCellStyle3;
            this.PosicionX.HeaderText = "Posición X";
            this.PosicionX.Name = "PosicionX";
            this.PosicionX.Width = 81;
            // 
            // PosicionY
            // 
            this.PosicionY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PosicionY.DataPropertyName = "Posicion_y";
            dataGridViewCellStyle4.Format = "N2";
            this.PosicionY.DefaultCellStyle = dataGridViewCellStyle4;
            this.PosicionY.HeaderText = "Posición Y";
            this.PosicionY.Name = "PosicionY";
            this.PosicionY.Width = 81;
            // 
            // DesplazamientoVertical
            // 
            this.DesplazamientoVertical.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DesplazamientoVertical.DataPropertyName = "Desplazamiento_vertical";
            dataGridViewCellStyle5.Format = "N2";
            this.DesplazamientoVertical.DefaultCellStyle = dataGridViewCellStyle5;
            this.DesplazamientoVertical.HeaderText = "D. Vertical";
            this.DesplazamientoVertical.Name = "DesplazamientoVertical";
            this.DesplazamientoVertical.Width = 80;
            // 
            // DesplazamientoHorizontal
            // 
            this.DesplazamientoHorizontal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DesplazamientoHorizontal.DataPropertyName = "Desplazamiento_horizontal";
            dataGridViewCellStyle6.Format = "N2";
            this.DesplazamientoHorizontal.DefaultCellStyle = dataGridViewCellStyle6;
            this.DesplazamientoHorizontal.HeaderText = "D. Horizontal";
            this.DesplazamientoHorizontal.Name = "DesplazamientoHorizontal";
            this.DesplazamientoHorizontal.Width = 92;
            // 
            // Ancho
            // 
            this.Ancho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ancho.DataPropertyName = "Ancho";
            dataGridViewCellStyle7.Format = "N2";
            this.Ancho.DefaultCellStyle = dataGridViewCellStyle7;
            this.Ancho.HeaderText = "Ancho";
            this.Ancho.Name = "Ancho";
            this.Ancho.Width = 62;
            // 
            // Alto
            // 
            this.Alto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Alto.DataPropertyName = "Alto";
            dataGridViewCellStyle8.Format = "N2";
            this.Alto.DefaultCellStyle = dataGridViewCellStyle8;
            this.Alto.HeaderText = "Alto";
            this.Alto.Name = "Alto";
            this.Alto.Width = 49;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "Id_impresion";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 42;
            // 
            // frmMantenimientoEsquemasManifiestos
            // 
            this.AcceptButton = this.btnSalir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnGuardar;
            this.ClientSize = new System.Drawing.Size(649, 568);
            this.Controls.Add(this.gbPosiciones);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoEsquemasManifiestos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mantenimiento de Esquemas de Manifiestos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAncho)).EndInit();
            this.gbPosiciones.ResumeLayout(false);
            this.gbPosiciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosiciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbPosiciones;
        private System.Windows.Forms.DataGridView dgvPosiciones;
        private System.Windows.Forms.Button btnAgregarPosicion;
        private System.Windows.Forms.Button btnQuitarPosicion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.NumericUpDown nudAlto;
        private System.Windows.Forms.Label lblAlto;
        private System.Windows.Forms.NumericUpDown nudAncho;
        private System.Windows.Forms.Label lblAncho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionX;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesplazamientoVertical;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesplazamientoHorizontal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ancho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}