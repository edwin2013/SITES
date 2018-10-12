namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmMantenimientoFichaTecnicaEquipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoFichaTecnicaEquipos));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.cboEquipo = new GUILayer.ComboBoxBusqueda();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudCosto = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodicidad = new System.Windows.Forms.DateTimePicker();
            this.gbTipoMantenimiento = new System.Windows.Forms.GroupBox();
            this.rbtnPreventivo = new System.Windows.Forms.RadioButton();
            this.rbtnCorrectivo = new System.Windows.Forms.RadioButton();
            this.cboEstatus = new System.Windows.Forms.ComboBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.txtBoleta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCosto)).BeginInit();
            this.gbTipoMantenimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(630, 58);
            this.pnlFondo.TabIndex = 7;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(-1, -4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // cboEquipo
            // 
            this.cboEquipo.Busqueda = true;
            this.cboEquipo.FormattingEnabled = true;
            this.cboEquipo.ListaMostrada = null;
            this.cboEquipo.Location = new System.Drawing.Point(89, 26);
            this.cboEquipo.Name = "cboEquipo";
            this.cboEquipo.Size = new System.Drawing.Size(188, 21);
            this.cboEquipo.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Equipo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudCosto);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.dtpPeriodicidad);
            this.groupBox1.Controls.Add(this.gbTipoMantenimiento);
            this.groupBox1.Controls.Add(this.cboEstatus);
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.txtBoleta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboEquipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 243);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Ficha Técnica";
            // 
            // nudCosto
            // 
            this.nudCosto.Location = new System.Drawing.Point(378, 27);
            this.nudCosto.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.nudCosto.Name = "nudCosto";
            this.nudCosto.Size = new System.Drawing.Size(188, 20);
            this.nudCosto.TabIndex = 40;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(378, 61);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(188, 20);
            this.dtpFecha.TabIndex = 38;
            // 
            // dtpPeriodicidad
            // 
            this.dtpPeriodicidad.Location = new System.Drawing.Point(89, 134);
            this.dtpPeriodicidad.Name = "dtpPeriodicidad";
            this.dtpPeriodicidad.Size = new System.Drawing.Size(188, 20);
            this.dtpPeriodicidad.TabIndex = 37;
            // 
            // gbTipoMantenimiento
            // 
            this.gbTipoMantenimiento.Controls.Add(this.rbtnPreventivo);
            this.gbTipoMantenimiento.Controls.Add(this.rbtnCorrectivo);
            this.gbTipoMantenimiento.Location = new System.Drawing.Point(18, 168);
            this.gbTipoMantenimiento.Name = "gbTipoMantenimiento";
            this.gbTipoMantenimiento.Size = new System.Drawing.Size(202, 55);
            this.gbTipoMantenimiento.TabIndex = 36;
            this.gbTipoMantenimiento.TabStop = false;
            this.gbTipoMantenimiento.Text = "Mantenimiento";
            // 
            // rbtnPreventivo
            // 
            this.rbtnPreventivo.AutoSize = true;
            this.rbtnPreventivo.Location = new System.Drawing.Point(107, 24);
            this.rbtnPreventivo.Name = "rbtnPreventivo";
            this.rbtnPreventivo.Size = new System.Drawing.Size(76, 17);
            this.rbtnPreventivo.TabIndex = 1;
            this.rbtnPreventivo.TabStop = true;
            this.rbtnPreventivo.Text = "Preventivo";
            this.rbtnPreventivo.UseVisualStyleBackColor = true;
            // 
            // rbtnCorrectivo
            // 
            this.rbtnCorrectivo.AutoSize = true;
            this.rbtnCorrectivo.Location = new System.Drawing.Point(4, 24);
            this.rbtnCorrectivo.Name = "rbtnCorrectivo";
            this.rbtnCorrectivo.Size = new System.Drawing.Size(73, 17);
            this.rbtnCorrectivo.TabIndex = 0;
            this.rbtnCorrectivo.TabStop = true;
            this.rbtnCorrectivo.Text = "Correctivo";
            this.rbtnCorrectivo.UseVisualStyleBackColor = true;
            // 
            // cboEstatus
            // 
            this.cboEstatus.FormattingEnabled = true;
            this.cboEstatus.Items.AddRange(new object[] {
            "Pendiente",
            "Finalizado"});
            this.cboEstatus.Location = new System.Drawing.Point(125, 96);
            this.cboEstatus.Name = "cboEstatus";
            this.cboEstatus.Size = new System.Drawing.Size(152, 21);
            this.cboEstatus.TabIndex = 35;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(329, 121);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(237, 102);
            this.txtObservacion.TabIndex = 34;
            // 
            // txtBoleta
            // 
            this.txtBoleta.Location = new System.Drawing.Point(125, 61);
            this.txtBoleta.Name = "txtBoleta";
            this.txtBoleta.Size = new System.Drawing.Size(152, 20);
            this.txtBoleta.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Costo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Observaciones:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Estatus:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Periodicidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Número de boleta:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(525, 313);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(429, 313);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmMantenimientoFichaTecnicaEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 359);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoFichaTecnicaEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Ficha Técnica de Equipos";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCosto)).EndInit();
            this.gbTipoMantenimiento.ResumeLayout(false);
            this.gbTipoMantenimiento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private ComboBoxBusqueda cboEquipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbTipoMantenimiento;
        private System.Windows.Forms.RadioButton rbtnPreventivo;
        private System.Windows.Forms.RadioButton rbtnCorrectivo;
        private System.Windows.Forms.ComboBox cboEstatus;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.TextBox txtBoleta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.NumericUpDown nudCosto;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpPeriodicidad;
    }
}