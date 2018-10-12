namespace GUILayer.Formularios.Boveda
{
    partial class frmFormulas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormulas));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblBolsa = new System.Windows.Forms.Label();
            this.lblPaqueton = new System.Windows.Forms.Label();
            this.nudBolsa = new System.Windows.Forms.NumericUpDown();
            this.nudPaqueton = new System.Windows.Forms.NumericUpDown();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBolsa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaqueton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblBolsa);
            this.gbDatos.Controls.Add(this.lblPaqueton);
            this.gbDatos.Controls.Add(this.nudBolsa);
            this.gbDatos.Controls.Add(this.nudPaqueton);
            this.gbDatos.Location = new System.Drawing.Point(4, 68);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(270, 122);
            this.gbDatos.TabIndex = 5;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Cantidad De Fórmulas Por:";
            // 
            // lblBolsa
            // 
            this.lblBolsa.AutoSize = true;
            this.lblBolsa.Location = new System.Drawing.Point(13, 75);
            this.lblBolsa.Name = "lblBolsa";
            this.lblBolsa.Size = new System.Drawing.Size(36, 13);
            this.lblBolsa.TabIndex = 4;
            this.lblBolsa.Text = "Bolsa:";
            // 
            // lblPaqueton
            // 
            this.lblPaqueton.AutoSize = true;
            this.lblPaqueton.Location = new System.Drawing.Point(13, 31);
            this.lblPaqueton.Name = "lblPaqueton";
            this.lblPaqueton.Size = new System.Drawing.Size(56, 13);
            this.lblPaqueton.TabIndex = 2;
            this.lblPaqueton.Text = "Paquetón:";
            // 
            // nudBolsa
            // 
            this.nudBolsa.Location = new System.Drawing.Point(102, 73);
            this.nudBolsa.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudBolsa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBolsa.Name = "nudBolsa";
            this.nudBolsa.Size = new System.Drawing.Size(141, 20);
            this.nudBolsa.TabIndex = 5;
            this.nudBolsa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPaqueton
            // 
            this.nudPaqueton.Location = new System.Drawing.Point(102, 29);
            this.nudPaqueton.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPaqueton.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPaqueton.Name = "nudPaqueton";
            this.nudPaqueton.Size = new System.Drawing.Size(141, 20);
            this.nudPaqueton.TabIndex = 3;
            this.nudPaqueton.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(184, 196);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 7;
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
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(88, 196);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 6;
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
            this.pnlFondo.Location = new System.Drawing.Point(1, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(305, 60);
            this.pnlFondo.TabIndex = 4;
            // 
            // frmFormulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 241);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormulas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cantidad de Fórmulas";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBolsa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaqueton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblBolsa;
        private System.Windows.Forms.Label lblPaqueton;
        private System.Windows.Forms.NumericUpDown nudBolsa;
        private System.Windows.Forms.NumericUpDown nudPaqueton;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
    }
}