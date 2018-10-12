namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmMantenimientoEquipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoEquipos));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.txtActivo = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosEquipo = new System.Windows.Forms.GroupBox();
            this.cboProveedor = new GUILayer.ComboBoxBusqueda();
            this.lblArea = new System.Windows.Forms.Label();
            this.cboAreas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbDatosEquipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(429, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-2, -2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(469, 60);
            this.pnlFondo.TabIndex = 1;
            // 
            // txtActivo
            // 
            this.txtActivo.Location = new System.Drawing.Point(112, 114);
            this.txtActivo.MaxLength = 15;
            this.txtActivo.Name = "txtActivo";
            this.txtActivo.Size = new System.Drawing.Size(200, 20);
            this.txtActivo.TabIndex = 15;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(112, 88);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(200, 20);
            this.txtSerie.TabIndex = 13;
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(35, 117);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(40, 13);
            this.lblIdentificacion.TabIndex = 14;
            this.lblIdentificacion.Text = "Activo:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(112, 35);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 9;
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Location = new System.Drawing.Point(35, 91);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(34, 13);
            this.lblSegundoApellido.TabIndex = 12;
            this.lblSegundoApellido.Text = "Serie:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(35, 38);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblPrimerApellido
            // 
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Location = new System.Drawing.Point(35, 64);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(59, 13);
            this.lblPrimerApellido.TabIndex = 10;
            this.lblPrimerApellido.Text = "Proveedor:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Location = new System.Drawing.Point(307, 263);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Location = new System.Drawing.Point(211, 263);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbDatosEquipo
            // 
            this.gbDatosEquipo.Controls.Add(this.lblArea);
            this.gbDatosEquipo.Controls.Add(this.cboAreas);
            this.gbDatosEquipo.Controls.Add(this.cboProveedor);
            this.gbDatosEquipo.Controls.Add(this.txtActivo);
            this.gbDatosEquipo.Controls.Add(this.lblPrimerApellido);
            this.gbDatosEquipo.Controls.Add(this.lblNombre);
            this.gbDatosEquipo.Controls.Add(this.lblSegundoApellido);
            this.gbDatosEquipo.Controls.Add(this.txtSerie);
            this.gbDatosEquipo.Controls.Add(this.lblIdentificacion);
            this.gbDatosEquipo.Controls.Add(this.txtNombre);
            this.gbDatosEquipo.Location = new System.Drawing.Point(45, 79);
            this.gbDatosEquipo.Name = "gbDatosEquipo";
            this.gbDatosEquipo.Size = new System.Drawing.Size(352, 178);
            this.gbDatosEquipo.TabIndex = 18;
            this.gbDatosEquipo.TabStop = false;
            this.gbDatosEquipo.Text = "Datos del Equipo";
            // 
            // cboProveedor
            // 
            this.cboProveedor.Busqueda = true;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.ListaMostrada = null;
            this.cboProveedor.Location = new System.Drawing.Point(112, 61);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(200, 21);
            this.cboProveedor.TabIndex = 16;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(35, 143);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 17;
            this.lblArea.Text = "Área:";
            // 
            // cboAreas
            // 
            this.cboAreas.Items.AddRange(new object[] {
            "Centro de Efectivo",
            "Boveda",
            "ATM\'s",
            "Tesorería",
            "Blindados",
            "Sucursal",
            "Caja Empresarial"});
            this.cboAreas.Location = new System.Drawing.Point(112, 140);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Size = new System.Drawing.Size(200, 21);
            this.cboAreas.TabIndex = 18;
            // 
            // frmMantenimientoEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 314);
            this.Controls.Add(this.gbDatosEquipo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Equipos";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbDatosEquipo.ResumeLayout(false);
            this.gbDatosEquipo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.TextBox txtActivo;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrimerApellido;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbDatosEquipo;
        private ComboBoxBusqueda cboProveedor;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cboAreas;
    }
}