namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmMantenimientoEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoEquipo));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDiasCarga = new System.Windows.Forms.GroupBox();
            this.cboManojo = new GUILayer.ComboBoxBusqueda();
            this.cboColaborador = new GUILayer.ComboBoxBusqueda();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.rbtnManojo = new System.Windows.Forms.RadioButton();
            this.rbtnColaborador = new System.Windows.Forms.RadioButton();
            this.rbtnATM = new System.Windows.Forms.RadioButton();
            this.lblTipo = new System.Windows.Forms.Label();
            this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.cboTipoEquipo = new GUILayer.ComboBoxBusqueda();
            this.lblCodigoBarras = new System.Windows.Forms.Label();
            this.txtIDAsignacion = new System.Windows.Forms.TextBox();
            this.lblIDAsignacion = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.cboPuesto = new System.Windows.Forms.ComboBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDiasCarga.SuspendLayout();
            this.gbDatosGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(2, 1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(562, 60);
            this.pnlFondo.TabIndex = 6;
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
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(243, 416);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbDiasCarga
            // 
            this.gbDiasCarga.Controls.Add(this.cboManojo);
            this.gbDiasCarga.Controls.Add(this.cboColaborador);
            this.gbDiasCarga.Controls.Add(this.cboATM);
            this.gbDiasCarga.Controls.Add(this.rbtnManojo);
            this.gbDiasCarga.Controls.Add(this.rbtnColaborador);
            this.gbDiasCarga.Controls.Add(this.rbtnATM);
            this.gbDiasCarga.Location = new System.Drawing.Point(6, 248);
            this.gbDiasCarga.Name = "gbDiasCarga";
            this.gbDiasCarga.Size = new System.Drawing.Size(422, 162);
            this.gbDiasCarga.TabIndex = 10;
            this.gbDiasCarga.TabStop = false;
            this.gbDiasCarga.Text = "Datos de la Asignación";
            // 
            // cboManojo
            // 
            this.cboManojo.Busqueda = false;
            this.cboManojo.Enabled = false;
            this.cboManojo.ListaMostrada = null;
            this.cboManojo.Location = new System.Drawing.Point(104, 116);
            this.cboManojo.Name = "cboManojo";
            this.cboManojo.Size = new System.Drawing.Size(307, 21);
            this.cboManojo.TabIndex = 21;
            // 
            // cboColaborador
            // 
            this.cboColaborador.Busqueda = false;
            this.cboColaborador.Enabled = false;
            this.cboColaborador.ListaMostrada = null;
            this.cboColaborador.Location = new System.Drawing.Point(104, 72);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(307, 21);
            this.cboColaborador.TabIndex = 20;
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = false;
            this.cboATM.Enabled = false;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(104, 32);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(307, 21);
            this.cboATM.TabIndex = 19;
            // 
            // rbtnManojo
            // 
            this.rbtnManojo.AutoSize = true;
            this.rbtnManojo.Location = new System.Drawing.Point(13, 117);
            this.rbtnManojo.Name = "rbtnManojo";
            this.rbtnManojo.Size = new System.Drawing.Size(60, 17);
            this.rbtnManojo.TabIndex = 2;
            this.rbtnManojo.TabStop = true;
            this.rbtnManojo.Text = "Manojo";
            this.rbtnManojo.UseVisualStyleBackColor = true;
            this.rbtnManojo.CheckedChanged += new System.EventHandler(this.rbtnManojo_CheckedChanged);
            // 
            // rbtnColaborador
            // 
            this.rbtnColaborador.AutoSize = true;
            this.rbtnColaborador.Location = new System.Drawing.Point(13, 73);
            this.rbtnColaborador.Name = "rbtnColaborador";
            this.rbtnColaborador.Size = new System.Drawing.Size(82, 17);
            this.rbtnColaborador.TabIndex = 1;
            this.rbtnColaborador.TabStop = true;
            this.rbtnColaborador.Text = "Colaborador";
            this.rbtnColaborador.UseVisualStyleBackColor = true;
            this.rbtnColaborador.CheckedChanged += new System.EventHandler(this.rbtnColaborador_CheckedChanged);
            // 
            // rbtnATM
            // 
            this.rbtnATM.AutoSize = true;
            this.rbtnATM.Location = new System.Drawing.Point(13, 33);
            this.rbtnATM.Name = "rbtnATM";
            this.rbtnATM.Size = new System.Drawing.Size(48, 17);
            this.rbtnATM.TabIndex = 0;
            this.rbtnATM.TabStop = true;
            this.rbtnATM.Text = "ATM";
            this.rbtnATM.UseVisualStyleBackColor = true;
            this.rbtnATM.CheckedChanged += new System.EventHandler(this.rbtnATM_CheckedChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 116);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 26;
            this.lblTipo.Text = "Tipo:";
            // 
            // gbDatosGenerales
            // 
            this.gbDatosGenerales.Controls.Add(this.cboPuesto);
            this.gbDatosGenerales.Controls.Add(this.lblPuesto);
            this.gbDatosGenerales.Controls.Add(this.txtCodigoBarras);
            this.gbDatosGenerales.Controls.Add(this.cboTipoEquipo);
            this.gbDatosGenerales.Controls.Add(this.lblTipo);
            this.gbDatosGenerales.Controls.Add(this.lblCodigoBarras);
            this.gbDatosGenerales.Controls.Add(this.txtIDAsignacion);
            this.gbDatosGenerales.Controls.Add(this.lblIDAsignacion);
            this.gbDatosGenerales.Controls.Add(this.txtSerie);
            this.gbDatosGenerales.Controls.Add(this.lblSerie);
            this.gbDatosGenerales.Location = new System.Drawing.Point(4, 67);
            this.gbDatosGenerales.Name = "gbDatosGenerales";
            this.gbDatosGenerales.Size = new System.Drawing.Size(424, 175);
            this.gbDatosGenerales.TabIndex = 7;
            this.gbDatosGenerales.TabStop = false;
            this.gbDatosGenerales.Text = "Datos Generales";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(104, 55);
            this.txtCodigoBarras.MaxLength = 100;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(307, 20);
            this.txtCodigoBarras.TabIndex = 28;
            // 
            // cboTipoEquipo
            // 
            this.cboTipoEquipo.Busqueda = false;
            this.cboTipoEquipo.ListaMostrada = null;
            this.cboTipoEquipo.Location = new System.Drawing.Point(104, 108);
            this.cboTipoEquipo.Name = "cboTipoEquipo";
            this.cboTipoEquipo.Size = new System.Drawing.Size(307, 21);
            this.cboTipoEquipo.TabIndex = 18;
            // 
            // lblCodigoBarras
            // 
            this.lblCodigoBarras.AutoSize = true;
            this.lblCodigoBarras.Location = new System.Drawing.Point(7, 58);
            this.lblCodigoBarras.Name = "lblCodigoBarras";
            this.lblCodigoBarras.Size = new System.Drawing.Size(91, 13);
            this.lblCodigoBarras.TabIndex = 2;
            this.lblCodigoBarras.Text = "Código de Barras:";
            // 
            // txtIDAsignacion
            // 
            this.txtIDAsignacion.Location = new System.Drawing.Point(104, 81);
            this.txtIDAsignacion.MaxLength = 250;
            this.txtIDAsignacion.Name = "txtIDAsignacion";
            this.txtIDAsignacion.Size = new System.Drawing.Size(307, 20);
            this.txtIDAsignacion.TabIndex = 5;
            // 
            // lblIDAsignacion
            // 
            this.lblIDAsignacion.AutoSize = true;
            this.lblIDAsignacion.Location = new System.Drawing.Point(6, 81);
            this.lblIDAsignacion.Name = "lblIDAsignacion";
            this.lblIDAsignacion.Size = new System.Drawing.Size(76, 13);
            this.lblIDAsignacion.TabIndex = 4;
            this.lblIDAsignacion.Text = "ID Asignación:";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(104, 28);
            this.txtSerie.MaxLength = 100;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(307, 20);
            this.txtSerie.TabIndex = 1;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(7, 31);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(34, 13);
            this.lblSerie.TabIndex = 0;
            this.lblSerie.Text = "Serie:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(339, 416);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Location = new System.Drawing.Point(12, 151);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(43, 13);
            this.lblPuesto.TabIndex = 30;
            this.lblPuesto.Text = "Puesto:";
            // 
            // cboPuesto
            // 
            this.cboPuesto.FormattingEnabled = true;
            this.cboPuesto.Items.AddRange(new object[] {
            "Chofer",
            "Custodio",
            "Portavalor"});
            this.cboPuesto.Location = new System.Drawing.Point(104, 140);
            this.cboPuesto.Name = "cboPuesto";
            this.cboPuesto.Size = new System.Drawing.Size(307, 21);
            this.cboPuesto.TabIndex = 31;
            // 
            // frmMantenimientoEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 468);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDiasCarga);
            this.Controls.Add(this.gbDatosGenerales);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Equipos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDiasCarga.ResumeLayout(false);
            this.gbDiasCarga.PerformLayout();
            this.gbDatosGenerales.ResumeLayout(false);
            this.gbDatosGenerales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private ComboBoxBusqueda cboTipoEquipo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbDiasCarga;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.GroupBox gbDatosGenerales;
        private System.Windows.Forms.Label lblCodigoBarras;
        private System.Windows.Forms.TextBox txtIDAsignacion;
        private System.Windows.Forms.Label lblIDAsignacion;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private ComboBoxBusqueda cboManojo;
        private ComboBoxBusqueda cboColaborador;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.RadioButton rbtnManojo;
        private System.Windows.Forms.RadioButton rbtnColaborador;
        private System.Windows.Forms.RadioButton rbtnATM;
        private System.Windows.Forms.ComboBox cboPuesto;
        private System.Windows.Forms.Label lblPuesto;
    }
}