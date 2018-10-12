namespace GUILayer.Formularios.Níquel
{
    partial class frmMantenimientoBolsasNiquel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoBolsasNiquel));
            this.btnAgregarBolsa = new System.Windows.Forms.Button();
            this.btnQuitarBolsa = new System.Windows.Forms.Button();
            this.lblDenominacion = new System.Windows.Forms.Label();
            this.dgvBolsas = new System.Windows.Forms.DataGridView();
            this.gbFallas = new System.Windows.Forms.GroupBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cboDenominacion = new GUILayer.ComboBoxBusqueda();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.clmDenominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBolsas)).BeginInit();
            this.gbFallas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarBolsa
            // 
            this.btnAgregarBolsa.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarBolsa.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarBolsa.Location = new System.Drawing.Point(259, 337);
            this.btnAgregarBolsa.Name = "btnAgregarBolsa";
            this.btnAgregarBolsa.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarBolsa.TabIndex = 2;
            this.btnAgregarBolsa.Text = "Agregar";
            this.btnAgregarBolsa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarBolsa.UseVisualStyleBackColor = false;
            this.btnAgregarBolsa.Click += new System.EventHandler(this.btnAgregarBolsa_Click);
            // 
            // btnQuitarBolsa
            // 
            this.btnQuitarBolsa.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarBolsa.Enabled = false;
            this.btnQuitarBolsa.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnQuitarBolsa.Location = new System.Drawing.Point(355, 337);
            this.btnQuitarBolsa.Name = "btnQuitarBolsa";
            this.btnQuitarBolsa.Size = new System.Drawing.Size(90, 40);
            this.btnQuitarBolsa.TabIndex = 4;
            this.btnQuitarBolsa.Text = "Quitar";
            this.btnQuitarBolsa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarBolsa.UseVisualStyleBackColor = false;
            this.btnQuitarBolsa.Click += new System.EventHandler(this.btnQuitarBolsa_Click);
            // 
            // lblDenominacion
            // 
            this.lblDenominacion.AutoSize = true;
            this.lblDenominacion.Location = new System.Drawing.Point(15, 35);
            this.lblDenominacion.Name = "lblDenominacion";
            this.lblDenominacion.Size = new System.Drawing.Size(78, 13);
            this.lblDenominacion.TabIndex = 0;
            this.lblDenominacion.Text = "Denominación:";
            // 
            // dgvBolsas
            // 
            this.dgvBolsas.AllowUserToAddRows = false;
            this.dgvBolsas.AllowUserToDeleteRows = false;
            this.dgvBolsas.AllowUserToOrderColumns = true;
            this.dgvBolsas.AllowUserToResizeColumns = false;
            this.dgvBolsas.AllowUserToResizeRows = false;
            this.dgvBolsas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBolsas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBolsas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBolsas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDenominacion,
            this.clmCantidad,
            this.clmMonto});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBolsas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBolsas.EnableHeadersVisualStyles = false;
            this.dgvBolsas.Location = new System.Drawing.Point(30, 90);
            this.dgvBolsas.Name = "dgvBolsas";
            this.dgvBolsas.RowHeadersVisible = false;
            this.dgvBolsas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBolsas.Size = new System.Drawing.Size(415, 241);
            this.dgvBolsas.TabIndex = 3;
            this.dgvBolsas.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvBolsas_CellParsing);
            this.dgvBolsas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBolsas_CellValueChanged);
            this.dgvBolsas.SelectionChanged += new System.EventHandler(this.dgvBolsas_SelectionChanged);
            // 
            // gbFallas
            // 
            this.gbFallas.Controls.Add(this.nudCantidad);
            this.gbFallas.Controls.Add(this.lblCantidad);
            this.gbFallas.Controls.Add(this.cboDenominacion);
            this.gbFallas.Controls.Add(this.lblDenominacion);
            this.gbFallas.Controls.Add(this.dgvBolsas);
            this.gbFallas.Controls.Add(this.btnAgregarBolsa);
            this.gbFallas.Controls.Add(this.btnQuitarBolsa);
            this.gbFallas.Location = new System.Drawing.Point(12, 76);
            this.gbFallas.Name = "gbFallas";
            this.gbFallas.Size = new System.Drawing.Size(477, 392);
            this.gbFallas.TabIndex = 1;
            this.gbFallas.TabStop = false;
            this.gbFallas.Text = "Datos";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(337, 33);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 20);
            this.nudCantidad.TabIndex = 7;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(279, 35);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // cboDenominacion
            // 
            this.cboDenominacion.Busqueda = true;
            this.cboDenominacion.FormattingEnabled = true;
            this.cboDenominacion.ListaMostrada = null;
            this.cboDenominacion.Location = new System.Drawing.Point(99, 32);
            this.cboDenominacion.Name = "cboDenominacion";
            this.cboDenominacion.Size = new System.Drawing.Size(173, 21);
            this.cboDenominacion.TabIndex = 5;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(2, 1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(569, 60);
            this.pnlFondo.TabIndex = 32;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(394, 500);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 34;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(298, 500);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 33;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // clmDenominacion
            // 
            this.clmDenominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDenominacion.DataPropertyName = "Denominacion";
            this.clmDenominacion.HeaderText = "Denominación";
            this.clmDenominacion.Name = "clmDenominacion";
            this.clmDenominacion.ReadOnly = true;
            // 
            // clmCantidad
            // 
            this.clmCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCantidad.DataPropertyName = "CantidadPiezas";
            this.clmCantidad.HeaderText = "Cantidad";
            this.clmCantidad.Name = "clmCantidad";
            // 
            // clmMonto
            // 
            this.clmMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMonto.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.clmMonto.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmMonto.HeaderText = "Monto";
            this.clmMonto.Name = "clmMonto";
            this.clmMonto.ReadOnly = true;
            // 
            // frmMantenimientoBolsasNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 562);
            this.Controls.Add(this.gbFallas);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMantenimientoBolsasNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Bolsas";
            this.Load += new System.EventHandler(this.frmMantenimientoBolsasNiquel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBolsas)).EndInit();
            this.gbFallas.ResumeLayout(false);
            this.gbFallas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarBolsa;
        private System.Windows.Forms.Button btnQuitarBolsa;
        private System.Windows.Forms.Label lblDenominacion;
        private System.Windows.Forms.DataGridView dgvBolsas;
        private System.Windows.Forms.GroupBox gbFallas;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private ComboBoxBusqueda cboDenominacion;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDenominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMonto;
    }
}