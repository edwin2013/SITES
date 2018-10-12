namespace GUILayer.Formularios.Cajeros_Automaticos
{
    partial class frmSolicitudCodigoCargasATM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudCodigoCargasATM));
            this.gbCodigoApertura = new System.Windows.Forms.GroupBox();
            this.txtCodigoApertura = new System.Windows.Forms.TextBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCodigoCierre = new System.Windows.Forms.GroupBox();
            this.txtCodigoCiere = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblATM = new System.Windows.Forms.Label();
            this.gbCodigoApertura.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCodigoCierre.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCodigoApertura
            // 
            this.gbCodigoApertura.BackColor = System.Drawing.Color.White;
            this.gbCodigoApertura.Controls.Add(this.txtCodigoApertura);
            this.gbCodigoApertura.Location = new System.Drawing.Point(12, 107);
            this.gbCodigoApertura.Name = "gbCodigoApertura";
            this.gbCodigoApertura.Size = new System.Drawing.Size(308, 88);
            this.gbCodigoApertura.TabIndex = 0;
            this.gbCodigoApertura.TabStop = false;
            this.gbCodigoApertura.Text = "Código de Apertura";
            // 
            // txtCodigoApertura
            // 
            this.txtCodigoApertura.BackColor = System.Drawing.Color.LightGreen;
            this.txtCodigoApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoApertura.Location = new System.Drawing.Point(37, 32);
            this.txtCodigoApertura.MaxLength = 6;
            this.txtCodigoApertura.Name = "txtCodigoApertura";
            this.txtCodigoApertura.Size = new System.Drawing.Size(235, 29);
            this.txtCodigoApertura.TabIndex = 0;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(1, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(395, 60);
            this.pnlFondo.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(358, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbCodigoCierre
            // 
            this.gbCodigoCierre.BackColor = System.Drawing.Color.White;
            this.gbCodigoCierre.Controls.Add(this.txtCodigoCiere);
            this.gbCodigoCierre.Location = new System.Drawing.Point(12, 201);
            this.gbCodigoCierre.Name = "gbCodigoCierre";
            this.gbCodigoCierre.Size = new System.Drawing.Size(308, 90);
            this.gbCodigoCierre.TabIndex = 2;
            this.gbCodigoCierre.TabStop = false;
            this.gbCodigoCierre.Text = "Código de Cierre";
            // 
            // txtCodigoCiere
            // 
            this.txtCodigoCiere.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtCodigoCiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoCiere.Location = new System.Drawing.Point(37, 42);
            this.txtCodigoCiere.MaxLength = 4;
            this.txtCodigoCiere.Name = "txtCodigoCiere";
            this.txtCodigoCiere.Size = new System.Drawing.Size(235, 29);
            this.txtCodigoCiere.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(134, 307);
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
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(230, 307);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(25, 77);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(13, 13);
            this.lblATM.TabIndex = 10;
            this.lblATM.Text = "a";
            // 
            // frmSolicitudCodigoCargasATM
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(330, 352);
            this.Controls.Add(this.lblATM);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbCodigoCierre);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCodigoApertura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSolicitudCodigoCargasATM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud de Códigos";
            this.gbCodigoApertura.ResumeLayout(false);
            this.gbCodigoApertura.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCodigoCierre.ResumeLayout(false);
            this.gbCodigoCierre.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCodigoApertura;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbCodigoCierre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtCodigoApertura;
        private System.Windows.Forms.TextBox txtCodigoCiere;
        private System.Windows.Forms.Label lblATM;
    }
}