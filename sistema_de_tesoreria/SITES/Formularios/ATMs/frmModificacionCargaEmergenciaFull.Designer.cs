namespace GUILayer
{
    partial class frmModificacionCargaEmergenciaFull
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificacionCargaEmergenciaFull));
            this.lblMarchamo = new System.Windows.Forms.Label();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.btnSeleccionarManifiestosCarga = new System.Windows.Forms.Button();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.txtMarchamo = new System.Windows.Forms.TextBox();
            this.gbDatosEnvio = new System.Windows.Forms.GroupBox();
            this.chkCargado = new System.Windows.Forms.CheckBox();
            this.chkENA = new System.Windows.Forms.CheckBox();
            this.dtpFechaEnvio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEnvio = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatosCarga = new System.Windows.Forms.GroupBox();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.dtpFechaCarga = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCarga = new System.Windows.Forms.Label();
            this.lblATM = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatosEnvio.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatosCarga.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMarchamo
            // 
            this.lblMarchamo.AutoSize = true;
            this.lblMarchamo.Location = new System.Drawing.Point(200, 49);
            this.lblMarchamo.Name = "lblMarchamo";
            this.lblMarchamo.Size = new System.Drawing.Size(60, 13);
            this.lblMarchamo.TabIndex = 4;
            this.lblMarchamo.Text = "Marchamo:";
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(14, 49);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManifiesto.TabIndex = 2;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // btnSeleccionarManifiestosCarga
            // 
            this.btnSeleccionarManifiestosCarga.Location = new System.Drawing.Point(364, 45);
            this.btnSeleccionarManifiestosCarga.Name = "btnSeleccionarManifiestosCarga";
            this.btnSeleccionarManifiestosCarga.Size = new System.Drawing.Size(34, 20);
            this.btnSeleccionarManifiestosCarga.TabIndex = 6;
            this.btnSeleccionarManifiestosCarga.Text = "...";
            this.btnSeleccionarManifiestosCarga.UseVisualStyleBackColor = true;
            this.btnSeleccionarManifiestosCarga.Click += new System.EventHandler(this.btnSeleccionarManifiestosCarga_Click);
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.Location = new System.Drawing.Point(78, 45);
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.ReadOnly = true;
            this.txtManifiesto.Size = new System.Drawing.Size(116, 20);
            this.txtManifiesto.TabIndex = 3;
            // 
            // txtMarchamo
            // 
            this.txtMarchamo.Location = new System.Drawing.Point(266, 45);
            this.txtMarchamo.Name = "txtMarchamo";
            this.txtMarchamo.ReadOnly = true;
            this.txtMarchamo.Size = new System.Drawing.Size(92, 20);
            this.txtMarchamo.TabIndex = 5;
            // 
            // gbDatosEnvio
            // 
            this.gbDatosEnvio.Controls.Add(this.chkCargado);
            this.gbDatosEnvio.Controls.Add(this.chkENA);
            this.gbDatosEnvio.Controls.Add(this.dtpFechaEnvio);
            this.gbDatosEnvio.Controls.Add(this.lblMarchamo);
            this.gbDatosEnvio.Controls.Add(this.lblFechaEnvio);
            this.gbDatosEnvio.Controls.Add(this.lblManifiesto);
            this.gbDatosEnvio.Controls.Add(this.txtMarchamo);
            this.gbDatosEnvio.Controls.Add(this.btnSeleccionarManifiestosCarga);
            this.gbDatosEnvio.Controls.Add(this.txtManifiesto);
            this.gbDatosEnvio.Location = new System.Drawing.Point(12, 66);
            this.gbDatosEnvio.Name = "gbDatosEnvio";
            this.gbDatosEnvio.Size = new System.Drawing.Size(404, 94);
            this.gbDatosEnvio.TabIndex = 1;
            this.gbDatosEnvio.TabStop = false;
            this.gbDatosEnvio.Text = "Datos de Envío";
            // 
            // chkCargado
            // 
            this.chkCargado.AutoSize = true;
            this.chkCargado.Location = new System.Drawing.Point(278, 71);
            this.chkCargado.Name = "chkCargado";
            this.chkCargado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCargado.Size = new System.Drawing.Size(66, 17);
            this.chkCargado.TabIndex = 7;
            this.chkCargado.Text = "Cargado";
            this.chkCargado.UseVisualStyleBackColor = true;
            this.chkCargado.CheckedChanged += new System.EventHandler(this.chkCargado_CheckedChanged);
            // 
            // chkENA
            // 
            this.chkENA.AutoSize = true;
            this.chkENA.Location = new System.Drawing.Point(350, 71);
            this.chkENA.Name = "chkENA";
            this.chkENA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkENA.Size = new System.Drawing.Size(48, 17);
            this.chkENA.TabIndex = 8;
            this.chkENA.Text = "ENA";
            this.chkENA.UseVisualStyleBackColor = true;
            // 
            // dtpFechaEnvio
            // 
            this.dtpFechaEnvio.Location = new System.Drawing.Point(78, 19);
            this.dtpFechaEnvio.Name = "dtpFechaEnvio";
            this.dtpFechaEnvio.Size = new System.Drawing.Size(320, 20);
            this.dtpFechaEnvio.TabIndex = 1;
            // 
            // lblFechaEnvio
            // 
            this.lblFechaEnvio.AutoSize = true;
            this.lblFechaEnvio.Location = new System.Drawing.Point(6, 23);
            this.lblFechaEnvio.Name = "lblFechaEnvio";
            this.lblFechaEnvio.Size = new System.Drawing.Size(66, 13);
            this.lblFechaEnvio.TabIndex = 0;
            this.lblFechaEnvio.Text = "F. de Envío:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(428, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatosCarga
            // 
            this.gbDatosCarga.Controls.Add(this.cboATM);
            this.gbDatosCarga.Controls.Add(this.dtpFechaCarga);
            this.gbDatosCarga.Controls.Add(this.lblFechaCarga);
            this.gbDatosCarga.Controls.Add(this.lblATM);
            this.gbDatosCarga.Enabled = false;
            this.gbDatosCarga.Location = new System.Drawing.Point(12, 166);
            this.gbDatosCarga.Name = "gbDatosCarga";
            this.gbDatosCarga.Size = new System.Drawing.Size(404, 74);
            this.gbDatosCarga.TabIndex = 2;
            this.gbDatosCarga.TabStop = false;
            this.gbDatosCarga.Text = "Datos de Carga";
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = false;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(78, 45);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(320, 21);
            this.cboATM.TabIndex = 3;
            // 
            // dtpFechaCarga
            // 
            this.dtpFechaCarga.Location = new System.Drawing.Point(78, 19);
            this.dtpFechaCarga.Name = "dtpFechaCarga";
            this.dtpFechaCarga.Size = new System.Drawing.Size(320, 20);
            this.dtpFechaCarga.TabIndex = 1;
            // 
            // lblFechaCarga
            // 
            this.lblFechaCarga.AutoSize = true;
            this.lblFechaCarga.Location = new System.Drawing.Point(7, 23);
            this.lblFechaCarga.Name = "lblFechaCarga";
            this.lblFechaCarga.Size = new System.Drawing.Size(65, 13);
            this.lblFechaCarga.TabIndex = 0;
            this.lblFechaCarga.Text = "F. de Carga:";
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(39, 49);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(33, 13);
            this.lblATM.TabIndex = 2;
            this.lblATM.Text = "ATM:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(230, 246);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(326, 246);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmModificacionCargaEmergenciaFull
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(428, 298);
            this.Controls.Add(this.gbDatosCarga);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbDatosEnvio);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificacionCargaEmergenciaFull";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación de Cargas de Emergencia de ATM\'s Full";
            this.gbDatosEnvio.ResumeLayout(false);
            this.gbDatosEnvio.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatosCarga.ResumeLayout(false);
            this.gbDatosCarga.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMarchamo;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.Button btnSeleccionarManifiestosCarga;
        private System.Windows.Forms.TextBox txtManifiesto;
        private System.Windows.Forms.TextBox txtMarchamo;
        private System.Windows.Forms.GroupBox gbDatosEnvio;
        private System.Windows.Forms.CheckBox chkENA;
        private System.Windows.Forms.DateTimePicker dtpFechaEnvio;
        private System.Windows.Forms.Label lblFechaEnvio;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbDatosCarga;
        private System.Windows.Forms.DateTimePicker dtpFechaCarga;
        private System.Windows.Forms.Label lblFechaCarga;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.CheckBox chkCargado;
        private ComboBoxBusqueda cboATM;
    }
}