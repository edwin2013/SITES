namespace GUILayer
{
    partial class frmControlServidorAutomatizado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlServidorAutomatizado));
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.gbDatosConexion = new System.Windows.Forms.GroupBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblContasena = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.mtbPuerto = new System.Windows.Forms.MaskedTextBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEstado = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatosConexion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(50, 23);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(20, 13);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP:";
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(254, 23);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(41, 13);
            this.lblPuerto.TabIndex = 2;
            this.lblPuerto.Text = "Puerto:";
            // 
            // gbDatosConexion
            // 
            this.gbDatosConexion.Controls.Add(this.lblServidor);
            this.gbDatosConexion.Controls.Add(this.txtContrasena);
            this.gbDatosConexion.Controls.Add(this.txtServidor);
            this.gbDatosConexion.Controls.Add(this.lblNombreUsuario);
            this.gbDatosConexion.Controls.Add(this.txtNombreUsuario);
            this.gbDatosConexion.Controls.Add(this.lblContasena);
            this.gbDatosConexion.Controls.Add(this.txtIP);
            this.gbDatosConexion.Controls.Add(this.lblIP);
            this.gbDatosConexion.Controls.Add(this.lblPuerto);
            this.gbDatosConexion.Controls.Add(this.mtbPuerto);
            this.gbDatosConexion.Location = new System.Drawing.Point(12, 66);
            this.gbDatosConexion.Name = "gbDatosConexion";
            this.gbDatosConexion.Size = new System.Drawing.Size(378, 123);
            this.gbDatosConexion.TabIndex = 1;
            this.gbDatosConexion.TabStop = false;
            this.gbDatosConexion.Text = "Datos de Conexión con el Servidor";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(21, 101);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(49, 13);
            this.lblServidor.TabIndex = 8;
            this.lblServidor.Text = "Servidor:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.White;
            this.txtContrasena.Location = new System.Drawing.Point(76, 71);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(296, 20);
            this.txtContrasena.TabIndex = 7;
            // 
            // txtServidor
            // 
            this.txtServidor.BackColor = System.Drawing.Color.White;
            this.txtServidor.Location = new System.Drawing.Point(76, 97);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(296, 20);
            this.txtServidor.TabIndex = 9;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(24, 49);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblNombreUsuario.TabIndex = 4;
            this.lblNombreUsuario.Text = "Usuario:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.BackColor = System.Drawing.Color.White;
            this.txtNombreUsuario.Location = new System.Drawing.Point(76, 45);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(296, 20);
            this.txtNombreUsuario.TabIndex = 5;
            // 
            // lblContasena
            // 
            this.lblContasena.AutoSize = true;
            this.lblContasena.Location = new System.Drawing.Point(6, 75);
            this.lblContasena.Name = "lblContasena";
            this.lblContasena.Size = new System.Drawing.Size(64, 13);
            this.lblContasena.TabIndex = 6;
            this.lblContasena.Text = "Contraseña:";
            // 
            // txtIP
            // 
            this.txtIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "IPServidorAutomatizado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtIP.Location = new System.Drawing.Point(76, 19);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(172, 20);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = global::GUILayer.Properties.Settings.Default.IPServidorAutomatizado;
            // 
            // mtbPuerto
            // 
            this.mtbPuerto.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GUILayer.Properties.Settings.Default, "PuertoServidorAutomatizado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mtbPuerto.Location = new System.Drawing.Point(301, 19);
            this.mtbPuerto.Mask = "9999";
            this.mtbPuerto.Name = "mtbPuerto";
            this.mtbPuerto.Size = new System.Drawing.Size(71, 20);
            this.mtbPuerto.TabIndex = 3;
            this.mtbPuerto.Text = global::GUILayer.Properties.Settings.Default.PuertoServidorAutomatizado;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(402, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Image = global::GUILayer.Properties.Resources.iniciar;
            this.btnIniciar.Location = new System.Drawing.Point(108, 195);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(90, 40);
            this.btnIniciar.TabIndex = 3;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(300, 195);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEstado
            // 
            this.btnEstado.Image = global::GUILayer.Properties.Resources.estado;
            this.btnEstado.Location = new System.Drawing.Point(12, 195);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(90, 40);
            this.btnEstado.TabIndex = 2;
            this.btnEstado.Text = "Estado";
            this.btnEstado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Image = global::GUILayer.Properties.Resources.terminar;
            this.btnTerminar.Location = new System.Drawing.Point(204, 195);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(90, 40);
            this.btnTerminar.TabIndex = 4;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(400, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmControlServidorAutomatizado
            // 
            this.AcceptButton = this.btnIniciar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(402, 247);
            this.ControlBox = false;
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosConexion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnIniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmControlServidorAutomatizado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control del Servidor";
            this.gbDatosConexion.ResumeLayout(false);
            this.gbDatosConexion.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.MaskedTextBox mtbPuerto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.GroupBox gbDatosConexion;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblContasena;
        private System.Windows.Forms.Button btnEstado;
    }
}