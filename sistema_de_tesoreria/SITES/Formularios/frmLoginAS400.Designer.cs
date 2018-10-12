namespace GUILayer
{
    partial class frmLoginAS400
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginAS400));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbDatosIngreso = new System.Windows.Forms.GroupBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblContasena = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            this.gbDatosIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(351, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // gbDatosIngreso
            // 
            this.gbDatosIngreso.Controls.Add(this.lblServidor);
            this.gbDatosIngreso.Controls.Add(this.txtContrasena);
            this.gbDatosIngreso.Controls.Add(this.txtServidor);
            this.gbDatosIngreso.Controls.Add(this.lblNombreUsuario);
            this.gbDatosIngreso.Controls.Add(this.txtNombreUsuario);
            this.gbDatosIngreso.Controls.Add(this.lblContasena);
            this.gbDatosIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbDatosIngreso.Location = new System.Drawing.Point(12, 66);
            this.gbDatosIngreso.Name = "gbDatosIngreso";
            this.gbDatosIngreso.Size = new System.Drawing.Size(327, 97);
            this.gbDatosIngreso.TabIndex = 1;
            this.gbDatosIngreso.TabStop = false;
            this.gbDatosIngreso.Text = "Datos de ingreso al sistema";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(56, 75);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(49, 13);
            this.lblServidor.TabIndex = 4;
            this.lblServidor.Text = "Servidor:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.White;
            this.txtContrasena.Location = new System.Drawing.Point(111, 45);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(210, 20);
            this.txtContrasena.TabIndex = 3;
            // 
            // txtServidor
            // 
            this.txtServidor.BackColor = System.Drawing.Color.White;
            this.txtServidor.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "ServidorAS400", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtServidor.Location = new System.Drawing.Point(111, 71);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(210, 20);
            this.txtServidor.TabIndex = 5;
            this.txtServidor.Text = global::GUILayer.Properties.Settings.Default.ServidorAS400;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(6, 23);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(99, 13);
            this.lblNombreUsuario.TabIndex = 0;
            this.lblNombreUsuario.Text = "Nombre de usuario:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.BackColor = System.Drawing.Color.White;
            this.txtNombreUsuario.Location = new System.Drawing.Point(111, 20);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(210, 20);
            this.txtNombreUsuario.TabIndex = 1;
            // 
            // lblContasena
            // 
            this.lblContasena.AutoSize = true;
            this.lblContasena.Location = new System.Drawing.Point(41, 49);
            this.lblContasena.Name = "lblContasena";
            this.lblContasena.Size = new System.Drawing.Size(64, 13);
            this.lblContasena.TabIndex = 2;
            this.lblContasena.Text = "Contraseña:";
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(349, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(150, 169);
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
            this.btnSalir.Location = new System.Drawing.Point(247, 169);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(86, 41);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmLoginAS400
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(351, 222);
            this.ControlBox = false;
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosIngreso);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoginAS400";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexión con AS400";
            this.pnlFondo.ResumeLayout(false);
            this.gbDatosIngreso.ResumeLayout(false);
            this.gbDatosIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatosIngreso;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblContasena;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
    }
}