namespace GUILayer
{
    partial class frmMantenimientoTiposGestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoTiposGestion));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.nudTiempoEsperado = new System.Windows.Forms.NumericUpDown();
            this.nudTiempoAviso = new System.Windows.Forms.NumericUpDown();
            this.lblTiempoAviso = new System.Windows.Forms.Label();
            this.lblTiempoEsperado = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiempoEsperado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiempoAviso)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(313, 140);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.pnlFondo.Size = new System.Drawing.Size(539, 60);
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
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.nudTiempoEsperado);
            this.gbDatos.Controls.Add(this.nudTiempoAviso);
            this.gbDatos.Controls.Add(this.lblTiempoAviso);
            this.gbDatos.Controls.Add(this.lblTiempoEsperado);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(493, 71);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Tipo de Gestión";
            // 
            // nudTiempoEsperado
            // 
            this.nudTiempoEsperado.Location = new System.Drawing.Point(120, 45);
            this.nudTiempoEsperado.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTiempoEsperado.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTiempoEsperado.Name = "nudTiempoEsperado";
            this.nudTiempoEsperado.Size = new System.Drawing.Size(115, 20);
            this.nudTiempoEsperado.TabIndex = 3;
            this.nudTiempoEsperado.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTiempoAviso
            // 
            this.nudTiempoAviso.Location = new System.Drawing.Point(372, 45);
            this.nudTiempoAviso.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTiempoAviso.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTiempoAviso.Name = "nudTiempoAviso";
            this.nudTiempoAviso.Size = new System.Drawing.Size(115, 20);
            this.nudTiempoAviso.TabIndex = 5;
            this.nudTiempoAviso.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTiempoAviso
            // 
            this.lblTiempoAviso.AutoSize = true;
            this.lblTiempoAviso.Location = new System.Drawing.Point(262, 49);
            this.lblTiempoAviso.Name = "lblTiempoAviso";
            this.lblTiempoAviso.Size = new System.Drawing.Size(104, 13);
            this.lblTiempoAviso.TabIndex = 4;
            this.lblTiempoAviso.Text = "Tiempo de Aviso (h):";
            // 
            // lblTiempoEsperado
            // 
            this.lblTiempoEsperado.AutoSize = true;
            this.lblTiempoEsperado.Location = new System.Drawing.Point(6, 49);
            this.lblTiempoEsperado.Name = "lblTiempoEsperado";
            this.lblTiempoEsperado.Size = new System.Drawing.Size(108, 13);
            this.lblTiempoEsperado.TabIndex = 2;
            this.lblTiempoEsperado.Text = "Tiempo Esperado (h):";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 19);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(367, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(67, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(409, 140);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmMantenimientoTiposGestion
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(517, 192);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoTiposGestion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Tipos de Gestiones";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiempoEsperado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiempoAviso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.NumericUpDown nudTiempoEsperado;
        private System.Windows.Forms.NumericUpDown nudTiempoAviso;
        private System.Windows.Forms.Label lblTiempoAviso;
        private System.Windows.Forms.Label lblTiempoEsperado;
    }
}