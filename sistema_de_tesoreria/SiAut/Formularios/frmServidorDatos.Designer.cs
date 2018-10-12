namespace SiAut
{
    partial class frmServidorDatos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServidorDatos));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.tmrCronometro = new System.Windows.Forms.Timer(this.components);
            this.gbConfiguracion = new System.Windows.Forms.GroupBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblContasena = new System.Windows.Forms.Label();
            this.lblHoraFinalizacion = new System.Windows.Forms.Label();
            this.dtpHoraFinalizacion = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbConfiguracion.SuspendLayout();
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
            this.pnlFondo.Size = new System.Drawing.Size(380, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = global::SiAut.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(378, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // tmrCronometro
            // 
            this.tmrCronometro.Interval = 900000;
            this.tmrCronometro.Tick += new System.EventHandler(this.tmrCronometro_Tick);
            // 
            // gbConfiguracion
            // 
            this.gbConfiguracion.Controls.Add(this.lblEstado);
            this.gbConfiguracion.Controls.Add(this.txtEstado);
            this.gbConfiguracion.Controls.Add(this.lblServidor);
            this.gbConfiguracion.Controls.Add(this.txtContrasena);
            this.gbConfiguracion.Controls.Add(this.txtServidor);
            this.gbConfiguracion.Controls.Add(this.lblNombreUsuario);
            this.gbConfiguracion.Controls.Add(this.txtNombreUsuario);
            this.gbConfiguracion.Controls.Add(this.lblContasena);
            this.gbConfiguracion.Controls.Add(this.lblHoraFinalizacion);
            this.gbConfiguracion.Controls.Add(this.dtpHoraFinalizacion);
            this.gbConfiguracion.Controls.Add(this.dtpHoraInicio);
            this.gbConfiguracion.Controls.Add(this.lblHoraInicio);
            this.gbConfiguracion.Location = new System.Drawing.Point(12, 66);
            this.gbConfiguracion.Name = "gbConfiguracion";
            this.gbConfiguracion.Size = new System.Drawing.Size(356, 190);
            this.gbConfiguracion.TabIndex = 1;
            this.gbConfiguracion.TabStop = false;
            this.gbConfiguracion.Text = "Configuración del Servidor";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(27, 123);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.White;
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(76, 123);
            this.txtEstado.Multiline = true;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEstado.Size = new System.Drawing.Size(274, 61);
            this.txtEstado.TabIndex = 11;
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
            this.txtContrasena.Size = new System.Drawing.Size(274, 20);
            this.txtContrasena.TabIndex = 7;
            // 
            // txtServidor
            // 
            this.txtServidor.BackColor = System.Drawing.Color.White;
            this.txtServidor.Location = new System.Drawing.Point(76, 97);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(274, 20);
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
            this.txtNombreUsuario.Size = new System.Drawing.Size(274, 20);
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
            // lblHoraFinalizacion
            // 
            this.lblHoraFinalizacion.AutoSize = true;
            this.lblHoraFinalizacion.Location = new System.Drawing.Point(185, 23);
            this.lblHoraFinalizacion.Name = "lblHoraFinalizacion";
            this.lblHoraFinalizacion.Size = new System.Drawing.Size(56, 13);
            this.lblHoraFinalizacion.TabIndex = 2;
            this.lblHoraFinalizacion.Text = "H. de Fin.:";
            // 
            // dtpHoraFinalizacion
            // 
            this.dtpHoraFinalizacion.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::SiAut.Properties.Settings.Default, "HoraFinalizacion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpHoraFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFinalizacion.Location = new System.Drawing.Point(247, 19);
            this.dtpHoraFinalizacion.Name = "dtpHoraFinalizacion";
            this.dtpHoraFinalizacion.Size = new System.Drawing.Size(103, 20);
            this.dtpHoraFinalizacion.TabIndex = 3;
            this.dtpHoraFinalizacion.Value = global::SiAut.Properties.Settings.Default.HoraFinalizacion;
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::SiAut.Properties.Settings.Default, "HoraInicio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(76, 19);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.Size = new System.Drawing.Size(103, 20);
            this.dtpHoraInicio.TabIndex = 1;
            this.dtpHoraInicio.Value = global::SiAut.Properties.Settings.Default.HoraInicio;
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(6, 23);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(64, 13);
            this.lblHoraInicio.TabIndex = 0;
            this.lblHoraInicio.Text = "H. de Inicio:";
            // 
            // btnTerminar
            // 
            this.btnTerminar.Enabled = false;
            this.btnTerminar.Image = global::SiAut.Properties.Resources.terminar;
            this.btnTerminar.Location = new System.Drawing.Point(176, 262);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(90, 40);
            this.btnTerminar.TabIndex = 3;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::SiAut.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(272, 262);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Image = global::SiAut.Properties.Resources.iniciar;
            this.btnIniciar.Location = new System.Drawing.Point(80, 262);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(90, 40);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // frmServidorDatos
            // 
            this.AcceptButton = this.btnIniciar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(380, 314);
            this.ControlBox = false;
            this.Controls.Add(this.gbConfiguracion);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServidorDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servidor Automatizado de Actualización de Datos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbConfiguracion.ResumeLayout(false);
            this.gbConfiguracion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Timer tmrCronometro;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.GroupBox gbConfiguracion;
        private System.Windows.Forms.Label lblHoraFinalizacion;
        private System.Windows.Forms.DateTimePicker dtpHoraFinalizacion;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblContasena;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstado;
    }
}

