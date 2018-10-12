namespace GUILayer
{
    partial class frmOpcionesGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionesGrupo));
            this.lblCajas = new System.Windows.Forms.Label();
            this.nudNumeroCajas = new System.Windows.Forms.NumericUpDown();
            this.gbOpciones = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroCajas)).BeginInit();
            this.gbOpciones.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCajas
            // 
            this.lblCajas.AutoSize = true;
            this.lblCajas.Location = new System.Drawing.Point(21, 25);
            this.lblCajas.Name = "lblCajas";
            this.lblCajas.Size = new System.Drawing.Size(91, 13);
            this.lblCajas.TabIndex = 0;
            this.lblCajas.Text = "Número de Cajas:";
            // 
            // nudNumeroCajas
            // 
            this.nudNumeroCajas.Location = new System.Drawing.Point(178, 25);
            this.nudNumeroCajas.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudNumeroCajas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroCajas.Name = "nudNumeroCajas";
            this.nudNumeroCajas.Size = new System.Drawing.Size(92, 20);
            this.nudNumeroCajas.TabIndex = 1;
            this.nudNumeroCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumeroCajas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gbOpciones
            // 
            this.gbOpciones.Controls.Add(this.lblCajas);
            this.gbOpciones.Controls.Add(this.nudNumeroCajas);
            this.gbOpciones.Location = new System.Drawing.Point(12, 46);
            this.gbOpciones.Name = "gbOpciones";
            this.gbOpciones.Size = new System.Drawing.Size(284, 60);
            this.gbOpciones.TabIndex = 0;
            this.gbOpciones.TabStop = false;
            this.gbOpciones.Text = "Opciones del Grupo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(96, 112);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(192, 112);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 2;
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
            this.pnlFondo.Size = new System.Drawing.Size(323, 43);
            this.pnlFondo.TabIndex = 3;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(297, 37);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmOpcionesGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 160);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbOpciones);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpcionesGrupo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones del Grupo de Cajas";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroCajas)).EndInit();
            this.gbOpciones.ResumeLayout(false);
            this.gbOpciones.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCajas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.NumericUpDown nudNumeroCajas;
        private System.Windows.Forms.GroupBox gbOpciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}