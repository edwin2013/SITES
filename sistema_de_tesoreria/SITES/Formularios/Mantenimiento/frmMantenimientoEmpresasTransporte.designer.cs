namespace GUILayer
{
    partial class frmMantenimientoEmpresasTransporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoEmpresasTransporte));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbTarifas = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPrecioPieza = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioMilColones = new System.Windows.Forms.Label();
            this.nudPrecioMilDolares = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioMilDolares = new System.Windows.Forms.Label();
            this.nudPrecioMilColones = new System.Windows.Forms.NumericUpDown();
            this.gbDatos.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbTarifas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioPieza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioMilDolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioMilColones)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(470, 66);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Empresa";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(112, 28);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(302, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(57, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
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
            this.pnlFondo.Size = new System.Drawing.Size(519, 60);
            this.pnlFondo.TabIndex = 0;
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
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(293, 332);
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
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(389, 332);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbTarifas
            // 
            this.gbTarifas.Controls.Add(this.label1);
            this.gbTarifas.Controls.Add(this.nudPrecioPieza);
            this.gbTarifas.Controls.Add(this.lblPrecioMilColones);
            this.gbTarifas.Controls.Add(this.nudPrecioMilDolares);
            this.gbTarifas.Controls.Add(this.lblPrecioMilDolares);
            this.gbTarifas.Controls.Add(this.nudPrecioMilColones);
            this.gbTarifas.Location = new System.Drawing.Point(12, 148);
            this.gbTarifas.Name = "gbTarifas";
            this.gbTarifas.Size = new System.Drawing.Size(467, 166);
            this.gbTarifas.TabIndex = 4;
            this.gbTarifas.TabStop = false;
            this.gbTarifas.Text = "Tarifas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Precio Unitario por Pieza:";
            // 
            // nudPrecioPieza
            // 
            this.nudPrecioPieza.DecimalPlaces = 3;
            this.nudPrecioPieza.Location = new System.Drawing.Point(223, 34);
            this.nudPrecioPieza.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudPrecioPieza.Name = "nudPrecioPieza";
            this.nudPrecioPieza.Size = new System.Drawing.Size(120, 20);
            this.nudPrecioPieza.TabIndex = 9;
            // 
            // lblPrecioMilColones
            // 
            this.lblPrecioMilColones.AutoSize = true;
            this.lblPrecioMilColones.Location = new System.Drawing.Point(9, 121);
            this.lblPrecioMilColones.Name = "lblPrecioMilColones";
            this.lblPrecioMilColones.Size = new System.Drawing.Size(99, 13);
            this.lblPrecioMilColones.TabIndex = 8;
            this.lblPrecioMilColones.Text = "Precio Mil colones: ";
            // 
            // nudPrecioMilDolares
            // 
            this.nudPrecioMilDolares.DecimalPlaces = 3;
            this.nudPrecioMilDolares.Location = new System.Drawing.Point(349, 119);
            this.nudPrecioMilDolares.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudPrecioMilDolares.Name = "nudPrecioMilDolares";
            this.nudPrecioMilDolares.Size = new System.Drawing.Size(120, 20);
            this.nudPrecioMilDolares.TabIndex = 5;
            // 
            // lblPrecioMilDolares
            // 
            this.lblPrecioMilDolares.AutoSize = true;
            this.lblPrecioMilDolares.Location = new System.Drawing.Point(247, 121);
            this.lblPrecioMilDolares.Name = "lblPrecioMilDolares";
            this.lblPrecioMilDolares.Size = new System.Drawing.Size(96, 13);
            this.lblPrecioMilDolares.TabIndex = 7;
            this.lblPrecioMilDolares.Text = "Precio Mil dólares: ";
            // 
            // nudPrecioMilColones
            // 
            this.nudPrecioMilColones.DecimalPlaces = 3;
            this.nudPrecioMilColones.Location = new System.Drawing.Point(121, 119);
            this.nudPrecioMilColones.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudPrecioMilColones.Name = "nudPrecioMilColones";
            this.nudPrecioMilColones.Size = new System.Drawing.Size(120, 20);
            this.nudPrecioMilColones.TabIndex = 6;
            // 
            // frmMantenimientoEmpresasTransporte
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(494, 387);
            this.Controls.Add(this.gbTarifas);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoEmpresasTransporte";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Empresas de Transporte";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbTarifas.ResumeLayout(false);
            this.gbTarifas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioPieza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioMilDolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioMilColones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbTarifas;
        private System.Windows.Forms.NumericUpDown nudPrecioMilDolares;
        private System.Windows.Forms.NumericUpDown nudPrecioMilColones;
        private System.Windows.Forms.Label lblPrecioMilDolares;
        private System.Windows.Forms.Label lblPrecioMilColones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPrecioPieza;

    }
}