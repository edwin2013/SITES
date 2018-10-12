namespace GUILayer.Formularios.Blindados
{
    partial class frmModificacionPedidoHojaDeRuta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificacionPedidoHojaDeRuta));
            this.dtpHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraLlegada = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicioPunto = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraFinalPunto = new System.Windows.Forms.DateTimePicker();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.lblHoraLLegada = new System.Windows.Forms.Label();
            this.lblHoraPuntoInicial = new System.Windows.Forms.Label();
            this.lblHoraFinalPunto = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.rbHandHeld = new System.Windows.Forms.RadioButton();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.lblTipoLectura = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpHoraSalida
            // 
            this.dtpHoraSalida.Checked = false;
            this.dtpHoraSalida.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraSalida.Location = new System.Drawing.Point(100, 56);
            this.dtpHoraSalida.Name = "dtpHoraSalida";
            this.dtpHoraSalida.ShowUpDown = true;
            this.dtpHoraSalida.Size = new System.Drawing.Size(76, 20);
            this.dtpHoraSalida.TabIndex = 0;
            this.dtpHoraSalida.Value = new System.DateTime(2014, 4, 28, 16, 24, 29, 0);
            // 
            // dtpHoraLlegada
            // 
            this.dtpHoraLlegada.Checked = false;
            this.dtpHoraLlegada.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpHoraLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraLlegada.Location = new System.Drawing.Point(100, 19);
            this.dtpHoraLlegada.Name = "dtpHoraLlegada";
            this.dtpHoraLlegada.ShowUpDown = true;
            this.dtpHoraLlegada.Size = new System.Drawing.Size(74, 20);
            this.dtpHoraLlegada.TabIndex = 1;
            this.dtpHoraLlegada.Value = new System.DateTime(2014, 4, 28, 16, 24, 29, 0);
            // 
            // dtpHoraInicioPunto
            // 
            this.dtpHoraInicioPunto.Checked = false;
            this.dtpHoraInicioPunto.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpHoraInicioPunto.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicioPunto.Location = new System.Drawing.Point(256, 19);
            this.dtpHoraInicioPunto.Name = "dtpHoraInicioPunto";
            this.dtpHoraInicioPunto.ShowUpDown = true;
            this.dtpHoraInicioPunto.Size = new System.Drawing.Size(69, 20);
            this.dtpHoraInicioPunto.TabIndex = 2;
            this.dtpHoraInicioPunto.Value = new System.DateTime(2014, 4, 28, 16, 24, 29, 0);
            // 
            // dtpHoraFinalPunto
            // 
            this.dtpHoraFinalPunto.Checked = false;
            this.dtpHoraFinalPunto.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpHoraFinalPunto.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFinalPunto.Location = new System.Drawing.Point(256, 58);
            this.dtpHoraFinalPunto.Name = "dtpHoraFinalPunto";
            this.dtpHoraFinalPunto.ShowUpDown = true;
            this.dtpHoraFinalPunto.Size = new System.Drawing.Size(69, 20);
            this.dtpHoraFinalPunto.TabIndex = 3;
            this.dtpHoraFinalPunto.Value = new System.DateTime(2014, 4, 28, 16, 24, 29, 0);
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.AutoSize = true;
            this.lblHoraEntrada.Location = new System.Drawing.Point(4, 63);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(36, 13);
            this.lblHoraEntrada.TabIndex = 4;
            this.lblHoraEntrada.Text = "Salida";
            // 
            // lblHoraLLegada
            // 
            this.lblHoraLLegada.AutoSize = true;
            this.lblHoraLLegada.Location = new System.Drawing.Point(4, 26);
            this.lblHoraLLegada.Name = "lblHoraLLegada";
            this.lblHoraLLegada.Size = new System.Drawing.Size(34, 13);
            this.lblHoraLLegada.TabIndex = 5;
            this.lblHoraLLegada.Text = "Arribo";
            // 
            // lblHoraPuntoInicial
            // 
            this.lblHoraPuntoInicial.AutoSize = true;
            this.lblHoraPuntoInicial.Location = new System.Drawing.Point(210, 25);
            this.lblHoraPuntoInicial.Name = "lblHoraPuntoInicial";
            this.lblHoraPuntoInicial.Size = new System.Drawing.Size(32, 13);
            this.lblHoraPuntoInicial.TabIndex = 6;
            this.lblHoraPuntoInicial.Text = "Inicio";
            // 
            // lblHoraFinalPunto
            // 
            this.lblHoraFinalPunto.AutoSize = true;
            this.lblHoraFinalPunto.Location = new System.Drawing.Point(210, 63);
            this.lblHoraFinalPunto.Name = "lblHoraFinalPunto";
            this.lblHoraFinalPunto.Size = new System.Drawing.Size(21, 13);
            this.lblHoraFinalPunto.TabIndex = 7;
            this.lblHoraFinalPunto.Text = "Fin";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(34, 218);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(366, 90);
            this.txtObservaciones.TabIndex = 8;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(-1, -6);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(3, 3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(485, 53);
            this.pnlFondo.TabIndex = 29;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(31, 188);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(81, 13);
            this.lblObservaciones.TabIndex = 30;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackColor = System.Drawing.SystemColors.Window;
            this.btnModificar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(214, 361);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 35;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.Window;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(310, 361);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 34;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.Color.Transparent;
            this.gbDatos.Controls.Add(this.dtpHoraLlegada);
            this.gbDatos.Controls.Add(this.dtpHoraSalida);
            this.gbDatos.Controls.Add(this.dtpHoraInicioPunto);
            this.gbDatos.Controls.Add(this.dtpHoraFinalPunto);
            this.gbDatos.Controls.Add(this.lblHoraEntrada);
            this.gbDatos.Controls.Add(this.lblHoraLLegada);
            this.gbDatos.Controls.Add(this.lblHoraFinalPunto);
            this.gbDatos.Controls.Add(this.lblHoraPuntoInicial);
            this.gbDatos.Location = new System.Drawing.Point(27, 81);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(381, 97);
            this.gbDatos.TabIndex = 36;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // rbHandHeld
            // 
            this.rbHandHeld.AutoSize = true;
            this.rbHandHeld.Location = new System.Drawing.Point(128, 329);
            this.rbHandHeld.Name = "rbHandHeld";
            this.rbHandHeld.Size = new System.Drawing.Size(76, 17);
            this.rbHandHeld.TabIndex = 37;
            this.rbHandHeld.TabStop = true;
            this.rbHandHeld.Text = "Hand Held";
            this.rbHandHeld.UseVisualStyleBackColor = true;
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Location = new System.Drawing.Point(253, 329);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(60, 17);
            this.rbManual.TabIndex = 38;
            this.rbManual.TabStop = true;
            this.rbManual.Text = "Manual";
            this.rbManual.UseVisualStyleBackColor = true;
            // 
            // lblTipoLectura
            // 
            this.lblTipoLectura.AutoSize = true;
            this.lblTipoLectura.Location = new System.Drawing.Point(32, 331);
            this.lblTipoLectura.Name = "lblTipoLectura";
            this.lblTipoLectura.Size = new System.Drawing.Size(46, 13);
            this.lblTipoLectura.TabIndex = 39;
            this.lblTipoLectura.Text = "Lectura:";
            // 
            // frmModificacionPedidoHojaDeRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 413);
            this.Controls.Add(this.lblTipoLectura);
            this.Controls.Add(this.rbManual);
            this.Controls.Add(this.rbHandHeld);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.txtObservaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificacionPedidoHojaDeRuta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación Solicitud Hoja de Ruta";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpHoraSalida;
        private System.Windows.Forms.DateTimePicker dtpHoraLlegada;
        private System.Windows.Forms.DateTimePicker dtpHoraInicioPunto;
        private System.Windows.Forms.DateTimePicker dtpHoraFinalPunto;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.Label lblHoraLLegada;
        private System.Windows.Forms.Label lblHoraPuntoInicial;
        private System.Windows.Forms.Label lblHoraFinalPunto;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.RadioButton rbHandHeld;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.Label lblTipoLectura;
    }
}