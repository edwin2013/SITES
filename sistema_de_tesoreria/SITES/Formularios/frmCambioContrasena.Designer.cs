namespace GUILayer
{
    partial class frmCambioContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioContrasena));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatosIngreso = new System.Windows.Forms.GroupBox();
            this.lblRepetirNuevaContrasena = new System.Windows.Forms.Label();
            this.txtNuevaContrasena = new System.Windows.Forms.TextBox();
            this.txtRepetirNuevaContrasena = new System.Windows.Forms.TextBox();
            this.lblContrasenaAnterior = new System.Windows.Forms.Label();
            this.txtContrasenaAnterior = new System.Windows.Forms.TextBox();
            this.lblNuevaContasena = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatosIngreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(451, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(398, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatosIngreso
            // 
            this.gbDatosIngreso.Controls.Add(this.lblRepetirNuevaContrasena);
            this.gbDatosIngreso.Controls.Add(this.txtNuevaContrasena);
            this.gbDatosIngreso.Controls.Add(this.txtRepetirNuevaContrasena);
            this.gbDatosIngreso.Controls.Add(this.lblContrasenaAnterior);
            this.gbDatosIngreso.Controls.Add(this.txtContrasenaAnterior);
            this.gbDatosIngreso.Controls.Add(this.lblNuevaContasena);
            this.gbDatosIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbDatosIngreso.Location = new System.Drawing.Point(12, 65);
            this.gbDatosIngreso.Name = "gbDatosIngreso";
            this.gbDatosIngreso.Size = new System.Drawing.Size(385, 97);
            this.gbDatosIngreso.TabIndex = 1;
            this.gbDatosIngreso.TabStop = false;
            this.gbDatosIngreso.Text = "Datos de ingreso al sistema";
            // 
            // lblRepetirNuevaContrasena
            // 
            this.lblRepetirNuevaContrasena.AutoSize = true;
            this.lblRepetirNuevaContrasena.Location = new System.Drawing.Point(6, 74);
            this.lblRepetirNuevaContrasena.Name = "lblRepetirNuevaContrasena";
            this.lblRepetirNuevaContrasena.Size = new System.Drawing.Size(136, 13);
            this.lblRepetirNuevaContrasena.TabIndex = 4;
            this.lblRepetirNuevaContrasena.Text = "Repetir Nueva Contraseña:";
            // 
            // txtNuevaContrasena
            // 
            this.txtNuevaContrasena.BackColor = System.Drawing.Color.White;
            this.txtNuevaContrasena.Location = new System.Drawing.Point(148, 45);
            this.txtNuevaContrasena.MaxLength = 20;
            this.txtNuevaContrasena.Name = "txtNuevaContrasena";
            this.txtNuevaContrasena.PasswordChar = '*';
            this.txtNuevaContrasena.Size = new System.Drawing.Size(231, 20);
            this.txtNuevaContrasena.TabIndex = 3;
            this.txtNuevaContrasena.TextChanged += new System.EventHandler(this.txtContrasenaAnterior_TextChanged);
            // 
            // txtRepetirNuevaContrasena
            // 
            this.txtRepetirNuevaContrasena.BackColor = System.Drawing.Color.White;
            this.txtRepetirNuevaContrasena.Location = new System.Drawing.Point(148, 71);
            this.txtRepetirNuevaContrasena.MaxLength = 20;
            this.txtRepetirNuevaContrasena.Name = "txtRepetirNuevaContrasena";
            this.txtRepetirNuevaContrasena.PasswordChar = '*';
            this.txtRepetirNuevaContrasena.Size = new System.Drawing.Size(231, 20);
            this.txtRepetirNuevaContrasena.TabIndex = 5;
            this.txtRepetirNuevaContrasena.TextChanged += new System.EventHandler(this.txtContrasenaAnterior_TextChanged);
            // 
            // lblContrasenaAnterior
            // 
            this.lblContrasenaAnterior.AutoSize = true;
            this.lblContrasenaAnterior.Location = new System.Drawing.Point(39, 22);
            this.lblContrasenaAnterior.Name = "lblContrasenaAnterior";
            this.lblContrasenaAnterior.Size = new System.Drawing.Size(103, 13);
            this.lblContrasenaAnterior.TabIndex = 0;
            this.lblContrasenaAnterior.Text = "Contraseña Anterior:";
            // 
            // txtContrasenaAnterior
            // 
            this.txtContrasenaAnterior.BackColor = System.Drawing.Color.White;
            this.txtContrasenaAnterior.Location = new System.Drawing.Point(148, 19);
            this.txtContrasenaAnterior.MaxLength = 20;
            this.txtContrasenaAnterior.Name = "txtContrasenaAnterior";
            this.txtContrasenaAnterior.PasswordChar = '*';
            this.txtContrasenaAnterior.Size = new System.Drawing.Size(231, 20);
            this.txtContrasenaAnterior.TabIndex = 1;
            this.txtContrasenaAnterior.TextChanged += new System.EventHandler(this.txtContrasenaAnterior_TextChanged);
            // 
            // lblNuevaContasena
            // 
            this.lblNuevaContasena.AutoSize = true;
            this.lblNuevaContasena.Location = new System.Drawing.Point(43, 48);
            this.lblNuevaContasena.Name = "lblNuevaContasena";
            this.lblNuevaContasena.Size = new System.Drawing.Size(99, 13);
            this.lblNuevaContasena.TabIndex = 2;
            this.lblNuevaContasena.Text = "Nueva Contraseña:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(208, 168);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(91, 41);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(305, 168);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(86, 41);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmCambioContrasena
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(412, 221);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosIngreso);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioContrasena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de Contraseña";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatosIngreso.ResumeLayout(false);
            this.gbDatosIngreso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatosIngreso;
        private System.Windows.Forms.Label lblRepetirNuevaContrasena;
        private System.Windows.Forms.TextBox txtNuevaContrasena;
        private System.Windows.Forms.TextBox txtRepetirNuevaContrasena;
        private System.Windows.Forms.Label lblContrasenaAnterior;
        private System.Windows.Forms.TextBox txtContrasenaAnterior;
        private System.Windows.Forms.Label lblNuevaContasena;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
    }
}