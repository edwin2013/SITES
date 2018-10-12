namespace GUILayer
{
    partial class frmRegistroTipoDeCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroTipoDeCambio));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblVenta = new System.Windows.Forms.Label();
            this.lblCompra = new System.Windows.Forms.Label();
            this.nudVenta = new System.Windows.Forms.NumericUpDown();
            this.nudCompra = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosDolares = new System.Windows.Forms.GroupBox();
            this.gbDatosEuros = new System.Windows.Forms.GroupBox();
            this.lblVentaEuros = new System.Windows.Forms.Label();
            this.nudCompraEuros = new System.Windows.Forms.NumericUpDown();
            this.lblCompraEuros = new System.Windows.Forms.Label();
            this.nudVentaEuros = new System.Windows.Forms.NumericUpDown();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbDatosDolares.SuspendLayout();
            this.gbDatosEuros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompraEuros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVentaEuros)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.gbDatosEuros);
            this.gbDatos.Controls.Add(this.gbDatosDolares);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.lblFechaInicio);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(258, 231);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Montos de Compra y Venta de Dolares";
            // 
            // lblVenta
            // 
            this.lblVenta.AutoSize = true;
            this.lblVenta.Location = new System.Drawing.Point(5, 47);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(38, 13);
            this.lblVenta.TabIndex = 4;
            this.lblVenta.Text = "Venta:";
            // 
            // lblCompra
            // 
            this.lblCompra.AutoSize = true;
            this.lblCompra.Location = new System.Drawing.Point(5, 21);
            this.lblCompra.Name = "lblCompra";
            this.lblCompra.Size = new System.Drawing.Size(46, 13);
            this.lblCompra.TabIndex = 2;
            this.lblCompra.Text = "Compra:";
            // 
            // nudVenta
            // 
            this.nudVenta.Location = new System.Drawing.Point(94, 45);
            this.nudVenta.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudVenta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVenta.Name = "nudVenta";
            this.nudVenta.Size = new System.Drawing.Size(141, 20);
            this.nudVenta.TabIndex = 5;
            this.nudVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudCompra
            // 
            this.nudCompra.Location = new System.Drawing.Point(94, 19);
            this.nudCompra.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCompra.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCompra.Name = "nudCompra";
            this.nudCompra.Size = new System.Drawing.Size(141, 20);
            this.nudCompra.TabIndex = 3;
            this.nudCompra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(105, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(141, 20);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(16, 23);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(83, 13);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha de Inicio:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(180, 310);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
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
            this.pbLogo.Size = new System.Drawing.Size(271, 44);
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
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(308, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(84, 310);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbDatosDolares
            // 
            this.gbDatosDolares.Controls.Add(this.lblVenta);
            this.gbDatosDolares.Controls.Add(this.nudCompra);
            this.gbDatosDolares.Controls.Add(this.lblCompra);
            this.gbDatosDolares.Controls.Add(this.nudVenta);
            this.gbDatosDolares.Location = new System.Drawing.Point(11, 45);
            this.gbDatosDolares.Name = "gbDatosDolares";
            this.gbDatosDolares.Size = new System.Drawing.Size(241, 83);
            this.gbDatosDolares.TabIndex = 4;
            this.gbDatosDolares.TabStop = false;
            this.gbDatosDolares.Text = "Dolares";
            // 
            // gbDatosEuros
            // 
            this.gbDatosEuros.Controls.Add(this.lblVentaEuros);
            this.gbDatosEuros.Controls.Add(this.nudCompraEuros);
            this.gbDatosEuros.Controls.Add(this.lblCompraEuros);
            this.gbDatosEuros.Controls.Add(this.nudVentaEuros);
            this.gbDatosEuros.Location = new System.Drawing.Point(6, 134);
            this.gbDatosEuros.Name = "gbDatosEuros";
            this.gbDatosEuros.Size = new System.Drawing.Size(241, 83);
            this.gbDatosEuros.TabIndex = 5;
            this.gbDatosEuros.TabStop = false;
            this.gbDatosEuros.Text = "Euros";
            // 
            // lblVentaEuros
            // 
            this.lblVentaEuros.AutoSize = true;
            this.lblVentaEuros.Location = new System.Drawing.Point(5, 47);
            this.lblVentaEuros.Name = "lblVentaEuros";
            this.lblVentaEuros.Size = new System.Drawing.Size(38, 13);
            this.lblVentaEuros.TabIndex = 4;
            this.lblVentaEuros.Text = "Venta:";
            // 
            // nudCompraEuros
            // 
            this.nudCompraEuros.Location = new System.Drawing.Point(94, 19);
            this.nudCompraEuros.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCompraEuros.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCompraEuros.Name = "nudCompraEuros";
            this.nudCompraEuros.Size = new System.Drawing.Size(141, 20);
            this.nudCompraEuros.TabIndex = 3;
            this.nudCompraEuros.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCompraEuros
            // 
            this.lblCompraEuros.AutoSize = true;
            this.lblCompraEuros.Location = new System.Drawing.Point(5, 21);
            this.lblCompraEuros.Name = "lblCompraEuros";
            this.lblCompraEuros.Size = new System.Drawing.Size(46, 13);
            this.lblCompraEuros.TabIndex = 2;
            this.lblCompraEuros.Text = "Compra:";
            // 
            // nudVentaEuros
            // 
            this.nudVentaEuros.Location = new System.Drawing.Point(94, 45);
            this.nudVentaEuros.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudVentaEuros.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVentaEuros.Name = "nudVentaEuros";
            this.nudVentaEuros.Size = new System.Drawing.Size(141, 20);
            this.nudVentaEuros.TabIndex = 5;
            this.nudVentaEuros.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmRegistroTipoDeCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(286, 362);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistroTipoDeCambio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro del Tipo de Cambio";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbDatosDolares.ResumeLayout(false);
            this.gbDatosDolares.PerformLayout();
            this.gbDatosEuros.ResumeLayout(false);
            this.gbDatosEuros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompraEuros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVentaEuros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblVenta;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.NumericUpDown nudVenta;
        private System.Windows.Forms.NumericUpDown nudCompra;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbDatosEuros;
        private System.Windows.Forms.Label lblVentaEuros;
        private System.Windows.Forms.NumericUpDown nudCompraEuros;
        private System.Windows.Forms.Label lblCompraEuros;
        private System.Windows.Forms.NumericUpDown nudVentaEuros;
        private System.Windows.Forms.GroupBox gbDatosDolares;

    }
}