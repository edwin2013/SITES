namespace GUILayer
{
    partial class frmIngresoManualManifiesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoManualManifiesto));
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.nudCaja = new System.Windows.Forms.NumericUpDown();
            this.cboEmpresa = new GUILayer.ComboBoxBusqueda();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            this.cboGrupo = new GUILayer.ComboBoxBusqueda();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cboReceptor = new GUILayer.ComboBoxBusqueda();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblReceptor = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiesto = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosManifiesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaja)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(282, 261);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.nudCaja);
            this.gbDatosManifiesto.Controls.Add(this.cboEmpresa);
            this.gbDatosManifiesto.Controls.Add(this.lblFecha);
            this.gbDatosManifiesto.Controls.Add(this.lblCaja);
            this.gbDatosManifiesto.Controls.Add(this.cboGrupo);
            this.gbDatosManifiesto.Controls.Add(this.lblGrupo);
            this.gbDatosManifiesto.Controls.Add(this.cboReceptor);
            this.gbDatosManifiesto.Controls.Add(this.lblEmpresa);
            this.gbDatosManifiesto.Controls.Add(this.lblReceptor);
            this.gbDatosManifiesto.Controls.Add(this.dtpFecha);
            this.gbDatosManifiesto.Controls.Add(this.txtCodigo);
            this.gbDatosManifiesto.Controls.Add(this.lblCodigoManifiesto);
            this.gbDatosManifiesto.Location = new System.Drawing.Point(12, 62);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(360, 193);
            this.gbDatosManifiesto.TabIndex = 1;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos del Manifiesto";
            // 
            // nudCaja
            // 
            this.nudCaja.Location = new System.Drawing.Point(89, 162);
            this.nudCaja.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudCaja.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCaja.Name = "nudCaja";
            this.nudCaja.Size = new System.Drawing.Size(120, 20);
            this.nudCaja.TabIndex = 11;
            this.nudCaja.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Busqueda = false;
            this.cboEmpresa.ListaMostrada = null;
            this.cboEmpresa.Location = new System.Drawing.Point(89, 82);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(255, 21);
            this.cboEmpresa.TabIndex = 5;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(43, 115);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(52, 164);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(31, 13);
            this.lblCaja.TabIndex = 10;
            this.lblCaja.Text = "Caja:";
            // 
            // cboGrupo
            // 
            this.cboGrupo.Busqueda = false;
            this.cboGrupo.ListaMostrada = null;
            this.cboGrupo.Location = new System.Drawing.Point(89, 135);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(255, 21);
            this.cboGrupo.TabIndex = 9;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(44, 138);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 8;
            this.lblGrupo.Text = "Grupo:";
            // 
            // cboReceptor
            // 
            this.cboReceptor.Busqueda = false;
            this.cboReceptor.ListaMostrada = null;
            this.cboReceptor.Location = new System.Drawing.Point(89, 55);
            this.cboReceptor.Name = "cboReceptor";
            this.cboReceptor.Size = new System.Drawing.Size(255, 21);
            this.cboReceptor.TabIndex = 3;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(32, 85);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 4;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // lblReceptor
            // 
            this.lblReceptor.AutoSize = true;
            this.lblReceptor.Location = new System.Drawing.Point(29, 58);
            this.lblReceptor.Name = "lblReceptor";
            this.lblReceptor.Size = new System.Drawing.Size(54, 13);
            this.lblReceptor.TabIndex = 2;
            this.lblReceptor.Text = "Receptor:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(89, 109);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(255, 20);
            this.dtpFecha.TabIndex = 7;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(89, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(255, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCodigoManifiesto
            // 
            this.lblCodigoManifiesto.AutoSize = true;
            this.lblCodigoManifiesto.Location = new System.Drawing.Point(40, 32);
            this.lblCodigoManifiesto.Name = "lblCodigoManifiesto";
            this.lblCodigoManifiesto.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiesto.TabIndex = 0;
            this.lblCodigoManifiesto.Text = "Código:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(404, 59);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(373, 43);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(186, 261);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmIngresoManualManifiesto
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(384, 310);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbDatosManifiesto);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngresoManualManifiesto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso Manual de Manifiestos";
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaja)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.NumericUpDown nudCaja;
        private ComboBoxBusqueda cboEmpresa;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCaja;
        private ComboBoxBusqueda cboGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private ComboBoxBusqueda cboReceptor;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblReceptor;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigoManifiesto;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnGuardar;
    }
}