namespace GUILayer
{
    partial class frmMantenimientoSobres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoSobres));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.nudMontoReportadoSobre = new System.Windows.Forms.NumericUpDown();
            this.lblMontoReportadoSobre = new System.Windows.Forms.Label();
            this.lblNumeroSobre = new System.Windows.Forms.Label();
            this.nudNumeroSobre = new System.Windows.Forms.NumericUpDown();
            this.lblMontoRealSobre = new System.Windows.Forms.Label();
            this.nudMontoRealSobre = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoReportadoSobre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroSobre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoRealSobre)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlFondo.Size = new System.Drawing.Size(466, 43);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(319, 39);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(229, 21);
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
            "Dólares",
            "Euros"});
            this.cboMoneda.Location = new System.Drawing.Point(284, 18);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(132, 21);
            this.cboMoneda.TabIndex = 3;
            // 
            // nudMontoReportadoSobre
            // 
            this.nudMontoReportadoSobre.DecimalPlaces = 2;
            this.nudMontoReportadoSobre.Location = new System.Drawing.Point(284, 45);
            this.nudMontoReportadoSobre.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoReportadoSobre.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.nudMontoReportadoSobre.Name = "nudMontoReportadoSobre";
            this.nudMontoReportadoSobre.Size = new System.Drawing.Size(132, 20);
            this.nudMontoReportadoSobre.TabIndex = 7;
            this.nudMontoReportadoSobre.ThousandsSeparator = true;
            // 
            // lblMontoReportadoSobre
            // 
            this.lblMontoReportadoSobre.AutoSize = true;
            this.lblMontoReportadoSobre.Location = new System.Drawing.Point(206, 47);
            this.lblMontoReportadoSobre.Name = "lblMontoReportadoSobre";
            this.lblMontoReportadoSobre.Size = new System.Drawing.Size(75, 13);
            this.lblMontoReportadoSobre.TabIndex = 6;
            this.lblMontoReportadoSobre.Text = "M. Reportado:";
            // 
            // lblNumeroSobre
            // 
            this.lblNumeroSobre.AutoSize = true;
            this.lblNumeroSobre.Location = new System.Drawing.Point(15, 21);
            this.lblNumeroSobre.Name = "lblNumeroSobre";
            this.lblNumeroSobre.Size = new System.Drawing.Size(47, 13);
            this.lblNumeroSobre.TabIndex = 0;
            this.lblNumeroSobre.Text = "Número:";
            // 
            // nudNumeroSobre
            // 
            this.nudNumeroSobre.Location = new System.Drawing.Point(68, 19);
            this.nudNumeroSobre.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumeroSobre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroSobre.Name = "nudNumeroSobre";
            this.nudNumeroSobre.Size = new System.Drawing.Size(132, 20);
            this.nudNumeroSobre.TabIndex = 1;
            this.nudNumeroSobre.ThousandsSeparator = true;
            this.nudNumeroSobre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMontoRealSobre
            // 
            this.lblMontoRealSobre.AutoSize = true;
            this.lblMontoRealSobre.Location = new System.Drawing.Point(15, 47);
            this.lblMontoRealSobre.Name = "lblMontoRealSobre";
            this.lblMontoRealSobre.Size = new System.Drawing.Size(47, 13);
            this.lblMontoRealSobre.TabIndex = 4;
            this.lblMontoRealSobre.Text = "M. Real:";
            // 
            // nudMontoRealSobre
            // 
            this.nudMontoRealSobre.DecimalPlaces = 2;
            this.nudMontoRealSobre.Location = new System.Drawing.Point(68, 45);
            this.nudMontoRealSobre.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoRealSobre.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.nudMontoRealSobre.Name = "nudMontoRealSobre";
            this.nudMontoRealSobre.Size = new System.Drawing.Size(132, 20);
            this.nudMontoRealSobre.TabIndex = 5;
            this.nudMontoRealSobre.ThousandsSeparator = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(242, 129);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(338, 129);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.nudNumeroSobre);
            this.gbDatos.Controls.Add(this.nudMontoRealSobre);
            this.gbDatos.Controls.Add(this.lblMontoRealSobre);
            this.gbDatos.Controls.Add(this.lblMoneda);
            this.gbDatos.Controls.Add(this.lblNumeroSobre);
            this.gbDatos.Controls.Add(this.cboMoneda);
            this.gbDatos.Controls.Add(this.lblMontoReportadoSobre);
            this.gbDatos.Controls.Add(this.nudMontoReportadoSobre);
            this.gbDatos.Location = new System.Drawing.Point(12, 46);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(428, 77);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Sobre";
            // 
            // frmMantenimientoSobres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 180);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoSobres";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Sobre";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoReportadoSobre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroSobre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoRealSobre)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.NumericUpDown nudMontoReportadoSobre;
        private System.Windows.Forms.Label lblMontoReportadoSobre;
        private System.Windows.Forms.Label lblNumeroSobre;
        private System.Windows.Forms.NumericUpDown nudNumeroSobre;
        private System.Windows.Forms.Label lblMontoRealSobre;
        private System.Windows.Forms.NumericUpDown nudMontoRealSobre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbDatos;
    }
}