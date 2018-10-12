namespace GUILayer.Formularios.ATMs
{
    partial class frmAdministracionPromedioRemanenteATM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionPromedioRemanenteATM));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.nudMontoQuincena = new System.Windows.Forms.NumericUpDown();
            this.lblMontoQuincena = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.nudMontoDolaresQuincena = new System.Windows.Forms.NumericUpDown();
            this.lblMontoDolaresQuincena = new System.Windows.Forms.Label();
            this.nudMontoDolares = new System.Windows.Forms.NumericUpDown();
            this.lblMontoDolares = new System.Windows.Forms.Label();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoQuincena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolaresQuincena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolares)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.nudMontoDolaresQuincena);
            this.gbDatos.Controls.Add(this.lblMontoDolaresQuincena);
            this.gbDatos.Controls.Add(this.nudMontoDolares);
            this.gbDatos.Controls.Add(this.lblMontoDolares);
            this.gbDatos.Controls.Add(this.nudMontoQuincena);
            this.gbDatos.Controls.Add(this.lblMontoQuincena);
            this.gbDatos.Controls.Add(this.nudMonto);
            this.gbDatos.Controls.Add(this.lblMonto);
            this.gbDatos.Location = new System.Drawing.Point(3, 67);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(452, 168);
            this.gbDatos.TabIndex = 7;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de los Promedios";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Location = new System.Drawing.Point(161, 32);
            this.nudMonto.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(227, 20);
            this.nudMonto.TabIndex = 4;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(77, 34);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 0;
            this.lblMonto.Text = "Monto:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(524, 60);
            this.pnlFondo.TabIndex = 6;
            // 
            // nudMontoQuincena
            // 
            this.nudMontoQuincena.DecimalPlaces = 2;
            this.nudMontoQuincena.Location = new System.Drawing.Point(161, 64);
            this.nudMontoQuincena.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoQuincena.Name = "nudMontoQuincena";
            this.nudMontoQuincena.Size = new System.Drawing.Size(227, 20);
            this.nudMontoQuincena.TabIndex = 6;
            // 
            // lblMontoQuincena
            // 
            this.lblMontoQuincena.AutoSize = true;
            this.lblMontoQuincena.Location = new System.Drawing.Point(56, 71);
            this.lblMontoQuincena.Name = "lblMontoQuincena";
            this.lblMontoQuincena.Size = new System.Drawing.Size(91, 13);
            this.lblMontoQuincena.TabIndex = 5;
            this.lblMontoQuincena.Text = "Monto Quincenal:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(269, 241);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(365, 241);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(401, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // nudMontoDolaresQuincena
            // 
            this.nudMontoDolaresQuincena.DecimalPlaces = 2;
            this.nudMontoDolaresQuincena.Location = new System.Drawing.Point(161, 129);
            this.nudMontoDolaresQuincena.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoDolaresQuincena.Name = "nudMontoDolaresQuincena";
            this.nudMontoDolaresQuincena.Size = new System.Drawing.Size(227, 20);
            this.nudMontoDolaresQuincena.TabIndex = 10;
            // 
            // lblMontoDolaresQuincena
            // 
            this.lblMontoDolaresQuincena.AutoSize = true;
            this.lblMontoDolaresQuincena.Location = new System.Drawing.Point(25, 131);
            this.lblMontoDolaresQuincena.Name = "lblMontoDolaresQuincena";
            this.lblMontoDolaresQuincena.Size = new System.Drawing.Size(130, 13);
            this.lblMontoDolaresQuincena.TabIndex = 9;
            this.lblMontoDolaresQuincena.Text = "Monto Quincenal Dólares:";
            // 
            // nudMontoDolares
            // 
            this.nudMontoDolares.DecimalPlaces = 2;
            this.nudMontoDolares.Location = new System.Drawing.Point(161, 97);
            this.nudMontoDolares.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoDolares.Name = "nudMontoDolares";
            this.nudMontoDolares.Size = new System.Drawing.Size(227, 20);
            this.nudMontoDolares.TabIndex = 8;
            // 
            // lblMontoDolares
            // 
            this.lblMontoDolares.AutoSize = true;
            this.lblMontoDolares.Location = new System.Drawing.Point(56, 104);
            this.lblMontoDolares.Name = "lblMontoDolares";
            this.lblMontoDolares.Size = new System.Drawing.Size(79, 13);
            this.lblMontoDolares.TabIndex = 7;
            this.lblMontoDolares.Text = "Monto Dólares:";
            // 
            // frmAdministracionPromedioRemanenteATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 314);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAdministracionPromedioRemanenteATM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Promedios";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoQuincena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolaresQuincena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDolares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.NumericUpDown nudMontoQuincena;
        private System.Windows.Forms.Label lblMontoQuincena;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.NumericUpDown nudMontoDolaresQuincena;
        private System.Windows.Forms.Label lblMontoDolaresQuincena;
        private System.Windows.Forms.NumericUpDown nudMontoDolares;
        private System.Windows.Forms.Label lblMontoDolares;

    }
}