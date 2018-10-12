namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmMantenimientoVehiculo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoVehiculo));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblNumeroAsociado = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.txtNumeroA = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(271, 168);
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
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(467, 60);
            this.pnlFondo.TabIndex = 4;
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
            this.gbDatos.Controls.Add(this.txtModelo);
            this.gbDatos.Controls.Add(this.lblNumeroAsociado);
            this.gbDatos.Controls.Add(this.lblPlaca);
            this.gbDatos.Controls.Add(this.txtNumeroA);
            this.gbDatos.Controls.Add(this.txtPlaca);
            this.gbDatos.Controls.Add(this.lblModelo);
            this.gbDatos.Location = new System.Drawing.Point(2, 66);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(455, 96);
            this.gbDatos.TabIndex = 5;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Vehículo";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(124, 70);
            this.txtModelo.MaxLength = 15;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(300, 20);
            this.txtModelo.TabIndex = 6;
            // 
            // lblNumeroAsociado
            // 
            this.lblNumeroAsociado.AutoSize = true;
            this.lblNumeroAsociado.Location = new System.Drawing.Point(24, 47);
            this.lblNumeroAsociado.Name = "lblNumeroAsociado";
            this.lblNumeroAsociado.Size = new System.Drawing.Size(94, 13);
            this.lblNumeroAsociado.TabIndex = 5;
            this.lblNumeroAsociado.Text = "Número Asociado:";
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Location = new System.Drawing.Point(52, 22);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(37, 13);
            this.lblPlaca.TabIndex = 4;
            this.lblPlaca.Text = "Placa:";
            // 
            // txtNumeroA
            // 
            this.txtNumeroA.Location = new System.Drawing.Point(124, 44);
            this.txtNumeroA.MaxLength = 2;
            this.txtNumeroA.Name = "txtNumeroA";
            this.txtNumeroA.Size = new System.Drawing.Size(300, 20);
            this.txtNumeroA.TabIndex = 3;
            this.txtNumeroA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroA_KeyPress);
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(124, 19);
            this.txtPlaca.MaxLength = 10;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(300, 20);
            this.txtPlaca.TabIndex = 2;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(24, 73);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(91, 13);
            this.lblModelo.TabIndex = 0;
            this.lblModelo.Text = "Código de Barras:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(367, 168);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmMantenimientoVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 222);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(481, 260);
            this.MinimumSize = new System.Drawing.Size(481, 260);
            this.Name = "frmMantenimientoVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mantenimiento de Vehículos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblNumeroAsociado;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtNumeroA;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtModelo;
    }
}