namespace GUILayer
{
    partial class frmMantenimientoDenominaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoDenominaciones));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.nudValor = new System.Windows.Forms.NumericUpDown();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.chkCargaATM = new System.Windows.Forms.CheckBox();
            this.pnlDatosCargaATM = new System.Windows.Forms.Panel();
            this.lblFormulasMinimas = new System.Windows.Forms.Label();
            this.nudFormulasMinimas = new System.Windows.Forms.NumericUpDown();
            this.lblFormulasMaximas = new System.Windows.Forms.Label();
            this.nudFormulasMaximas = new System.Windows.Forms.NumericUpDown();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtConfiguracionOpteva = new System.Windows.Forms.TextBox();
            this.lblIDImagen = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.nudIDImagen = new System.Windows.Forms.NumericUpDown();
            this.lblConfiguracionOpteva = new System.Windows.Forms.Label();
            this.lblConfiguracionDiebold = new System.Windows.Forms.Label();
            this.txtConfiguracionDiebold = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.chkMoneda = new System.Windows.Forms.CheckBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
            this.pnlDatosCargaATM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFormulasMinimas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFormulasMaximas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIDImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(395, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(358, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.chkMoneda);
            this.gbDatos.Controls.Add(this.lblValor);
            this.gbDatos.Controls.Add(this.nudValor);
            this.gbDatos.Controls.Add(this.cboMoneda);
            this.gbDatos.Controls.Add(this.lblMoneda);
            this.gbDatos.Controls.Add(this.chkCargaATM);
            this.gbDatos.Controls.Add(this.pnlDatosCargaATM);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(351, 176);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Denominación";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(13, 53);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor:";
            // 
            // nudValor
            // 
            this.nudValor.Location = new System.Drawing.Point(53, 49);
            this.nudValor.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudValor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudValor.Name = "nudValor";
            this.nudValor.Size = new System.Drawing.Size(88, 20);
            this.nudValor.TabIndex = 3;
            this.nudValor.ThousandsSeparator = true;
            this.nudValor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares",
            "Euros"});
            this.cboMoneda.Location = new System.Drawing.Point(94, 19);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(251, 21);
            this.cboMoneda.TabIndex = 1;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(39, 23);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 0;
            this.lblMoneda.Text = "Moneda:";
            // 
            // chkCargaATM
            // 
            this.chkCargaATM.AutoSize = true;
            this.chkCargaATM.Location = new System.Drawing.Point(265, 49);
            this.chkCargaATM.Name = "chkCargaATM";
            this.chkCargaATM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCargaATM.Size = new System.Drawing.Size(80, 17);
            this.chkCargaATM.TabIndex = 4;
            this.chkCargaATM.Text = "Carga ATM";
            this.chkCargaATM.UseVisualStyleBackColor = true;
            this.chkCargaATM.CheckedChanged += new System.EventHandler(this.chkCargaATM_CheckedChanged);
            // 
            // pnlDatosCargaATM
            // 
            this.pnlDatosCargaATM.BackColor = System.Drawing.Color.Transparent;
            this.pnlDatosCargaATM.Controls.Add(this.lblFormulasMinimas);
            this.pnlDatosCargaATM.Controls.Add(this.nudFormulasMinimas);
            this.pnlDatosCargaATM.Controls.Add(this.lblFormulasMaximas);
            this.pnlDatosCargaATM.Controls.Add(this.nudFormulasMaximas);
            this.pnlDatosCargaATM.Controls.Add(this.txtCodigo);
            this.pnlDatosCargaATM.Controls.Add(this.txtConfiguracionOpteva);
            this.pnlDatosCargaATM.Controls.Add(this.lblIDImagen);
            this.pnlDatosCargaATM.Controls.Add(this.lblCodigo);
            this.pnlDatosCargaATM.Controls.Add(this.nudIDImagen);
            this.pnlDatosCargaATM.Controls.Add(this.lblConfiguracionOpteva);
            this.pnlDatosCargaATM.Controls.Add(this.lblConfiguracionDiebold);
            this.pnlDatosCargaATM.Controls.Add(this.txtConfiguracionDiebold);
            this.pnlDatosCargaATM.Enabled = false;
            this.pnlDatosCargaATM.Location = new System.Drawing.Point(0, 72);
            this.pnlDatosCargaATM.Name = "pnlDatosCargaATM";
            this.pnlDatosCargaATM.Size = new System.Drawing.Size(351, 98);
            this.pnlDatosCargaATM.TabIndex = 5;
            // 
            // lblFormulasMinimas
            // 
            this.lblFormulasMinimas.AutoSize = true;
            this.lblFormulasMinimas.Location = new System.Drawing.Point(188, 82);
            this.lblFormulasMinimas.Name = "lblFormulasMinimas";
            this.lblFormulasMinimas.Size = new System.Drawing.Size(62, 13);
            this.lblFormulasMinimas.TabIndex = 10;
            this.lblFormulasMinimas.Text = "F. Mínimas:";
            // 
            // nudFormulasMinimas
            // 
            this.nudFormulasMinimas.Location = new System.Drawing.Point(256, 78);
            this.nudFormulasMinimas.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudFormulasMinimas.Name = "nudFormulasMinimas";
            this.nudFormulasMinimas.Size = new System.Drawing.Size(89, 20);
            this.nudFormulasMinimas.TabIndex = 11;
            this.nudFormulasMinimas.ThousandsSeparator = true;
            this.nudFormulasMinimas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFormulasMaximas
            // 
            this.lblFormulasMaximas.AutoSize = true;
            this.lblFormulasMaximas.Location = new System.Drawing.Point(25, 82);
            this.lblFormulasMaximas.Name = "lblFormulasMaximas";
            this.lblFormulasMaximas.Size = new System.Drawing.Size(63, 13);
            this.lblFormulasMaximas.TabIndex = 8;
            this.lblFormulasMaximas.Text = "F. Máximas:";
            // 
            // nudFormulasMaximas
            // 
            this.nudFormulasMaximas.Location = new System.Drawing.Point(94, 78);
            this.nudFormulasMaximas.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudFormulasMaximas.Name = "nudFormulasMaximas";
            this.nudFormulasMaximas.Size = new System.Drawing.Size(88, 20);
            this.nudFormulasMaximas.TabIndex = 9;
            this.nudFormulasMaximas.ThousandsSeparator = true;
            this.nudFormulasMaximas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(256, 52);
            this.txtCodigo.MaxLength = 1;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(89, 20);
            this.txtCodigo.TabIndex = 7;
            // 
            // txtConfiguracionOpteva
            // 
            this.txtConfiguracionOpteva.Location = new System.Drawing.Point(94, 0);
            this.txtConfiguracionOpteva.MaxLength = 50;
            this.txtConfiguracionOpteva.Name = "txtConfiguracionOpteva";
            this.txtConfiguracionOpteva.Size = new System.Drawing.Size(251, 20);
            this.txtConfiguracionOpteva.TabIndex = 1;
            // 
            // lblIDImagen
            // 
            this.lblIDImagen.AutoSize = true;
            this.lblIDImagen.Location = new System.Drawing.Point(14, 56);
            this.lblIDImagen.Name = "lblIDImagen";
            this.lblIDImagen.Size = new System.Drawing.Size(74, 13);
            this.lblIDImagen.TabIndex = 4;
            this.lblIDImagen.Text = "ID de Imagen:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(207, 56);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "Código:";
            // 
            // nudIDImagen
            // 
            this.nudIDImagen.Location = new System.Drawing.Point(94, 52);
            this.nudIDImagen.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudIDImagen.Name = "nudIDImagen";
            this.nudIDImagen.Size = new System.Drawing.Size(88, 20);
            this.nudIDImagen.TabIndex = 5;
            this.nudIDImagen.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblConfiguracionOpteva
            // 
            this.lblConfiguracionOpteva.AutoSize = true;
            this.lblConfiguracionOpteva.Location = new System.Drawing.Point(7, 4);
            this.lblConfiguracionOpteva.Name = "lblConfiguracionOpteva";
            this.lblConfiguracionOpteva.Size = new System.Drawing.Size(81, 13);
            this.lblConfiguracionOpteva.TabIndex = 0;
            this.lblConfiguracionOpteva.Text = "Config. Opteva:";
            // 
            // lblConfiguracionDiebold
            // 
            this.lblConfiguracionDiebold.AutoSize = true;
            this.lblConfiguracionDiebold.Location = new System.Drawing.Point(6, 30);
            this.lblConfiguracionDiebold.Name = "lblConfiguracionDiebold";
            this.lblConfiguracionDiebold.Size = new System.Drawing.Size(82, 13);
            this.lblConfiguracionDiebold.TabIndex = 2;
            this.lblConfiguracionDiebold.Text = "Config. Diebold:";
            // 
            // txtConfiguracionDiebold
            // 
            this.txtConfiguracionDiebold.Location = new System.Drawing.Point(94, 26);
            this.txtConfiguracionDiebold.MaxLength = 50;
            this.txtConfiguracionDiebold.Name = "txtConfiguracionDiebold";
            this.txtConfiguracionDiebold.Size = new System.Drawing.Size(251, 20);
            this.txtConfiguracionDiebold.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(177, 245);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 6;
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
            this.btnSalir.Location = new System.Drawing.Point(273, 245);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // chkMoneda
            // 
            this.chkMoneda.AutoSize = true;
            this.chkMoneda.Location = new System.Drawing.Point(165, 49);
            this.chkMoneda.Name = "chkMoneda";
            this.chkMoneda.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMoneda.Size = new System.Drawing.Size(65, 17);
            this.chkMoneda.TabIndex = 6;
            this.chkMoneda.Text = "Moneda";
            this.chkMoneda.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoDenominaciones
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(375, 297);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoDenominaciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Denominaciones";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
            this.pnlDatosCargaATM.ResumeLayout(false);
            this.pnlDatosCargaATM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFormulasMinimas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFormulasMaximas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIDImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.NumericUpDown nudValor;
        private System.Windows.Forms.Label lblConfiguracionOpteva;
        private System.Windows.Forms.TextBox txtConfiguracionOpteva;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.CheckBox chkCargaATM;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblConfiguracionDiebold;
        private System.Windows.Forms.TextBox txtConfiguracionDiebold;
        private System.Windows.Forms.Label lblIDImagen;
        private System.Windows.Forms.NumericUpDown nudIDImagen;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Panel pnlDatosCargaATM;
        private System.Windows.Forms.Label lblFormulasMinimas;
        private System.Windows.Forms.NumericUpDown nudFormulasMinimas;
        private System.Windows.Forms.Label lblFormulasMaximas;
        private System.Windows.Forms.NumericUpDown nudFormulasMaximas;
        private System.Windows.Forms.CheckBox chkMoneda;
    }
}