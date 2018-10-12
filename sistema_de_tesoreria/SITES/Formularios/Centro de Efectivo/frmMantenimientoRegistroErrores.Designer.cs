namespace GUILayer
{
    partial class frmMantenimientoRegistroErrores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoRegistroErrores));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblOtrosErrores = new System.Windows.Forms.Label();
            this.txtOtrosErrores = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.clbErrores = new System.Windows.Forms.CheckedListBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCoordinador = new System.Windows.Forms.Label();
            this.txtCoordinador = new System.Windows.Forms.TextBox();
            this.cboColaborador = new GUILayer.ComboBoxBusqueda();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.chkSinErrores = new System.Windows.Forms.CheckBox();
            this.lblErrores = new System.Windows.Forms.Label();
            this.pnlErrores = new System.Windows.Forms.Panel();
            this.gbDatos.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlErrores.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.pnlErrores);
            this.gbDatos.Controls.Add(this.chkSinErrores);
            this.gbDatos.Controls.Add(this.lblObservaciones);
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Controls.Add(this.txtObservaciones);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.lblCoordinador);
            this.gbDatos.Controls.Add(this.txtCoordinador);
            this.gbDatos.Controls.Add(this.cboColaborador);
            this.gbDatos.Controls.Add(this.lblColaborador);
            this.gbDatos.Location = new System.Drawing.Point(12, 63);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(412, 411);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // lblOtrosErrores
            // 
            this.lblOtrosErrores.AutoSize = true;
            this.lblOtrosErrores.Location = new System.Drawing.Point(72, 104);
            this.lblOtrosErrores.Name = "lblOtrosErrores";
            this.lblOtrosErrores.Size = new System.Drawing.Size(35, 13);
            this.lblOtrosErrores.TabIndex = 2;
            this.lblOtrosErrores.Text = "Otros:";
            // 
            // txtOtrosErrores
            // 
            this.txtOtrosErrores.Location = new System.Drawing.Point(113, 101);
            this.txtOtrosErrores.MaxLength = 400;
            this.txtOtrosErrores.Multiline = true;
            this.txtOtrosErrores.Name = "txtOtrosErrores";
            this.txtOtrosErrores.Size = new System.Drawing.Size(287, 95);
            this.txtOtrosErrores.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(32, 325);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(81, 13);
            this.lblObservaciones.TabIndex = 8;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(119, 322);
            this.txtObservaciones.MaxLength = 400;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(287, 83);
            this.txtObservaciones.TabIndex = 9;
            // 
            // clbErrores
            // 
            this.clbErrores.FormattingEnabled = true;
            this.clbErrores.Location = new System.Drawing.Point(113, 1);
            this.clbErrores.Name = "clbErrores";
            this.clbErrores.Size = new System.Drawing.Size(287, 94);
            this.clbErrores.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(73, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(119, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.AutoSize = true;
            this.lblCoordinador.Location = new System.Drawing.Point(46, 48);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(67, 13);
            this.lblCoordinador.TabIndex = 2;
            this.lblCoordinador.Text = "Coordinador:";
            // 
            // txtCoordinador
            // 
            this.txtCoordinador.Location = new System.Drawing.Point(119, 45);
            this.txtCoordinador.Name = "txtCoordinador";
            this.txtCoordinador.ReadOnly = true;
            this.txtCoordinador.Size = new System.Drawing.Size(287, 20);
            this.txtCoordinador.TabIndex = 3;
            // 
            // cboColaborador
            // 
            this.cboColaborador.Busqueda = false;
            this.cboColaborador.ListaMostrada = null;
            this.cboColaborador.Location = new System.Drawing.Point(119, 71);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(287, 21);
            this.cboColaborador.TabIndex = 5;
            // 
            // lblColaborador
            // 
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Location = new System.Drawing.Point(46, 74);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(67, 13);
            this.lblColaborador.TabIndex = 4;
            this.lblColaborador.Text = "Colaborador:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(232, 480);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(328, 480);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(450, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(400, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // chkSinErrores
            // 
            this.chkSinErrores.AutoSize = true;
            this.chkSinErrores.Location = new System.Drawing.Point(329, 98);
            this.chkSinErrores.Name = "chkSinErrores";
            this.chkSinErrores.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSinErrores.Size = new System.Drawing.Size(77, 17);
            this.chkSinErrores.TabIndex = 6;
            this.chkSinErrores.Text = "Sin Errores";
            this.chkSinErrores.UseVisualStyleBackColor = true;
            this.chkSinErrores.CheckedChanged += new System.EventHandler(this.chkSinErrores_CheckedChanged);
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Location = new System.Drawing.Point(64, 1);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(43, 13);
            this.lblErrores.TabIndex = 0;
            this.lblErrores.Text = "Errores:";
            // 
            // pnlErrores
            // 
            this.pnlErrores.Controls.Add(this.clbErrores);
            this.pnlErrores.Controls.Add(this.lblErrores);
            this.pnlErrores.Controls.Add(this.lblOtrosErrores);
            this.pnlErrores.Controls.Add(this.txtOtrosErrores);
            this.pnlErrores.Location = new System.Drawing.Point(6, 120);
            this.pnlErrores.Name = "pnlErrores";
            this.pnlErrores.Size = new System.Drawing.Size(400, 196);
            this.pnlErrores.TabIndex = 7;
            // 
            // frmMantenimientoRegistroErrores
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(436, 532);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoRegistroErrores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Registro de Errores para Cajeros";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlErrores.ResumeLayout(false);
            this.pnlErrores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblCoordinador;
        private System.Windows.Forms.TextBox txtCoordinador;
        private ComboBoxBusqueda cboColaborador;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblOtrosErrores;
        private System.Windows.Forms.TextBox txtOtrosErrores;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.CheckedListBox clbErrores;
        private System.Windows.Forms.Panel pnlErrores;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.CheckBox chkSinErrores;
    }
}