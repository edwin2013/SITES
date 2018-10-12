namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmSolicitudRequerimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudRequerimientos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gboMantenimiento = new System.Windows.Forms.GroupBox();
            this.rbtnCorrectivo = new System.Windows.Forms.RadioButton();
            this.rbtnPreventivo = new System.Windows.Forms.RadioButton();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtActivo = new System.Windows.Forms.TextBox();
            this.gbDatosEquipo = new System.Windows.Forms.GroupBox();
            this.txtDescRequerimiento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gboEvaluacion = new System.Windows.Forms.GroupBox();
            this.rbtnExcelente = new System.Windows.Forms.RadioButton();
            this.rbtnBueno = new System.Windows.Forms.RadioButton();
            this.rbtnRegular = new System.Windows.Forms.RadioButton();
            this.rbtnMalo = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescServicio = new System.Windows.Forms.TextBox();
            this.gbProceso = new System.Windows.Forms.GroupBox();
            this.dtpFechaEjecucion = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaProveedor = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSAP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFechaSolicitud = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbSolicitud = new System.Windows.Forms.GroupBox();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.cboColaborador = new GUILayer.ComboBoxBusqueda();
            this.cboEquipo = new GUILayer.ComboBoxBusqueda();
            this.gboMantenimiento.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatosEquipo.SuspendLayout();
            this.gboEvaluacion.SuspendLayout();
            this.gbProceso.SuspendLayout();
            this.gbSolicitud.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Solicitante:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de Solicitud:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Área:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Proveedor:";
            // 
            // gboMantenimiento
            // 
            this.gboMantenimiento.Controls.Add(this.rbtnCorrectivo);
            this.gboMantenimiento.Controls.Add(this.rbtnPreventivo);
            this.gboMantenimiento.Location = new System.Drawing.Point(9, 126);
            this.gboMantenimiento.Name = "gboMantenimiento";
            this.gboMantenimiento.Size = new System.Drawing.Size(304, 50);
            this.gboMantenimiento.TabIndex = 4;
            this.gboMantenimiento.TabStop = false;
            this.gboMantenimiento.Text = "Mantenimiento";
            // 
            // rbtnCorrectivo
            // 
            this.rbtnCorrectivo.AutoSize = true;
            this.rbtnCorrectivo.Location = new System.Drawing.Point(152, 19);
            this.rbtnCorrectivo.Name = "rbtnCorrectivo";
            this.rbtnCorrectivo.Size = new System.Drawing.Size(73, 17);
            this.rbtnCorrectivo.TabIndex = 23;
            this.rbtnCorrectivo.TabStop = true;
            this.rbtnCorrectivo.Text = "Correctivo";
            this.rbtnCorrectivo.UseVisualStyleBackColor = true;
            // 
            // rbtnPreventivo
            // 
            this.rbtnPreventivo.AutoSize = true;
            this.rbtnPreventivo.Location = new System.Drawing.Point(19, 19);
            this.rbtnPreventivo.Name = "rbtnPreventivo";
            this.rbtnPreventivo.Size = new System.Drawing.Size(76, 17);
            this.rbtnPreventivo.TabIndex = 22;
            this.rbtnPreventivo.TabStop = true;
            this.rbtnPreventivo.Text = "Preventivo";
            this.rbtnPreventivo.UseVisualStyleBackColor = true;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(649, 58);
            this.pnlFondo.TabIndex = 8;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(-1, -1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Equipo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Serie:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Activo:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Location = new System.Drawing.Point(101, 19);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(130, 20);
            this.txtProveedor.TabIndex = 12;
            // 
            // txtSerie
            // 
            this.txtSerie.Enabled = false;
            this.txtSerie.Location = new System.Drawing.Point(101, 52);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(130, 20);
            this.txtSerie.TabIndex = 13;
            // 
            // txtActivo
            // 
            this.txtActivo.Enabled = false;
            this.txtActivo.Location = new System.Drawing.Point(101, 84);
            this.txtActivo.Name = "txtActivo";
            this.txtActivo.Size = new System.Drawing.Size(130, 20);
            this.txtActivo.TabIndex = 14;
            // 
            // gbDatosEquipo
            // 
            this.gbDatosEquipo.Controls.Add(this.label4);
            this.gbDatosEquipo.Controls.Add(this.txtActivo);
            this.gbDatosEquipo.Controls.Add(this.label6);
            this.gbDatosEquipo.Controls.Add(this.txtSerie);
            this.gbDatosEquipo.Controls.Add(this.label7);
            this.gbDatosEquipo.Controls.Add(this.txtProveedor);
            this.gbDatosEquipo.Location = new System.Drawing.Point(332, 55);
            this.gbDatosEquipo.Name = "gbDatosEquipo";
            this.gbDatosEquipo.Size = new System.Drawing.Size(253, 121);
            this.gbDatosEquipo.TabIndex = 15;
            this.gbDatosEquipo.TabStop = false;
            this.gbDatosEquipo.Text = "Datos del Equipo";
            // 
            // txtDescRequerimiento
            // 
            this.txtDescRequerimiento.Location = new System.Drawing.Point(9, 192);
            this.txtDescRequerimiento.Multiline = true;
            this.txtDescRequerimiento.Name = "txtDescRequerimiento";
            this.txtDescRequerimiento.Size = new System.Drawing.Size(576, 61);
            this.txtDescRequerimiento.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Descripción del requerimiento:";
            // 
            // gboEvaluacion
            // 
            this.gboEvaluacion.Controls.Add(this.rbtnExcelente);
            this.gboEvaluacion.Controls.Add(this.rbtnBueno);
            this.gboEvaluacion.Controls.Add(this.rbtnRegular);
            this.gboEvaluacion.Controls.Add(this.rbtnMalo);
            this.gboEvaluacion.Enabled = false;
            this.gboEvaluacion.Location = new System.Drawing.Point(25, 329);
            this.gboEvaluacion.Name = "gboEvaluacion";
            this.gboEvaluacion.Size = new System.Drawing.Size(605, 50);
            this.gboEvaluacion.TabIndex = 5;
            this.gboEvaluacion.TabStop = false;
            this.gboEvaluacion.Text = "Evaluación:";
            // 
            // rbtnExcelente
            // 
            this.rbtnExcelente.AutoSize = true;
            this.rbtnExcelente.BackColor = System.Drawing.Color.Blue;
            this.rbtnExcelente.Location = new System.Drawing.Point(477, 19);
            this.rbtnExcelente.Name = "rbtnExcelente";
            this.rbtnExcelente.Size = new System.Drawing.Size(72, 17);
            this.rbtnExcelente.TabIndex = 3;
            this.rbtnExcelente.TabStop = true;
            this.rbtnExcelente.Text = "Excelente";
            this.rbtnExcelente.UseVisualStyleBackColor = false;
            // 
            // rbtnBueno
            // 
            this.rbtnBueno.AutoSize = true;
            this.rbtnBueno.BackColor = System.Drawing.Color.Green;
            this.rbtnBueno.Location = new System.Drawing.Point(316, 19);
            this.rbtnBueno.Name = "rbtnBueno";
            this.rbtnBueno.Size = new System.Drawing.Size(56, 17);
            this.rbtnBueno.TabIndex = 2;
            this.rbtnBueno.TabStop = true;
            this.rbtnBueno.Text = "Bueno";
            this.rbtnBueno.UseVisualStyleBackColor = false;
            // 
            // rbtnRegular
            // 
            this.rbtnRegular.AutoSize = true;
            this.rbtnRegular.BackColor = System.Drawing.Color.Yellow;
            this.rbtnRegular.Location = new System.Drawing.Point(161, 19);
            this.rbtnRegular.Name = "rbtnRegular";
            this.rbtnRegular.Size = new System.Drawing.Size(62, 17);
            this.rbtnRegular.TabIndex = 1;
            this.rbtnRegular.TabStop = true;
            this.rbtnRegular.Text = "Regular";
            this.rbtnRegular.UseVisualStyleBackColor = false;
            // 
            // rbtnMalo
            // 
            this.rbtnMalo.AutoSize = true;
            this.rbtnMalo.BackColor = System.Drawing.Color.Red;
            this.rbtnMalo.Location = new System.Drawing.Point(28, 19);
            this.rbtnMalo.Name = "rbtnMalo";
            this.rbtnMalo.Size = new System.Drawing.Size(48, 17);
            this.rbtnMalo.TabIndex = 0;
            this.rbtnMalo.TabStop = true;
            this.rbtnMalo.Text = "Malo";
            this.rbtnMalo.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Descripción del servicio:";
            // 
            // txtDescServicio
            // 
            this.txtDescServicio.Location = new System.Drawing.Point(6, 78);
            this.txtDescServicio.Multiline = true;
            this.txtDescServicio.Name = "txtDescServicio";
            this.txtDescServicio.Size = new System.Drawing.Size(579, 52);
            this.txtDescServicio.TabIndex = 19;
            // 
            // gbProceso
            // 
            this.gbProceso.Controls.Add(this.dtpFechaEjecucion);
            this.gbProceso.Controls.Add(this.dtpFechaProveedor);
            this.gbProceso.Controls.Add(this.label12);
            this.gbProceso.Controls.Add(this.label11);
            this.gbProceso.Controls.Add(this.txtSAP);
            this.gbProceso.Controls.Add(this.label10);
            this.gbProceso.Controls.Add(this.label9);
            this.gbProceso.Controls.Add(this.txtDescServicio);
            this.gbProceso.Enabled = false;
            this.gbProceso.Location = new System.Drawing.Point(25, 385);
            this.gbProceso.Name = "gbProceso";
            this.gbProceso.Size = new System.Drawing.Size(605, 139);
            this.gbProceso.TabIndex = 6;
            this.gbProceso.TabStop = false;
            this.gbProceso.Text = "Espacio exclusivo para coordinación con el proveedor:";
            // 
            // dtpFechaEjecucion
            // 
            this.dtpFechaEjecucion.Location = new System.Drawing.Point(385, 49);
            this.dtpFechaEjecucion.Name = "dtpFechaEjecucion";
            this.dtpFechaEjecucion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaEjecucion.TabIndex = 23;
            // 
            // dtpFechaProveedor
            // 
            this.dtpFechaProveedor.Location = new System.Drawing.Point(385, 23);
            this.dtpFechaProveedor.Name = "dtpFechaProveedor";
            this.dtpFechaProveedor.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaProveedor.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(267, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Fecha de Ejecución:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Fecha:";
            // 
            // txtSAP
            // 
            this.txtSAP.Location = new System.Drawing.Point(98, 23);
            this.txtSAP.Name = "txtSAP";
            this.txtSAP.Size = new System.Drawing.Size(155, 20);
            this.txtSAP.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Número de SAP:";
            // 
            // dtpFechaSolicitud
            // 
            this.dtpFechaSolicitud.Enabled = false;
            this.dtpFechaSolicitud.Location = new System.Drawing.Point(113, 55);
            this.dtpFechaSolicitud.Name = "dtpFechaSolicitud";
            this.dtpFechaSolicitud.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaSolicitud.TabIndex = 20;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(435, 530);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Location = new System.Drawing.Point(540, 530);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // gbSolicitud
            // 
            this.gbSolicitud.Controls.Add(this.cboArea);
            this.gbSolicitud.Controls.Add(this.cboColaborador);
            this.gbSolicitud.Controls.Add(this.label1);
            this.gbSolicitud.Controls.Add(this.label2);
            this.gbSolicitud.Controls.Add(this.label3);
            this.gbSolicitud.Controls.Add(this.gboMantenimiento);
            this.gbSolicitud.Controls.Add(this.cboEquipo);
            this.gbSolicitud.Controls.Add(this.label8);
            this.gbSolicitud.Controls.Add(this.label5);
            this.gbSolicitud.Controls.Add(this.gbDatosEquipo);
            this.gbSolicitud.Controls.Add(this.dtpFechaSolicitud);
            this.gbSolicitud.Controls.Add(this.txtDescRequerimiento);
            this.gbSolicitud.Location = new System.Drawing.Point(25, 64);
            this.gbSolicitud.Name = "gbSolicitud";
            this.gbSolicitud.Size = new System.Drawing.Size(605, 259);
            this.gbSolicitud.TabIndex = 25;
            this.gbSolicitud.TabStop = false;
            this.gbSolicitud.Text = "Datos del Requerimiento:";
            // 
            // cboArea
            // 
            this.cboArea.Items.AddRange(new object[] {
            "Centro de Efectivo",
            "Boveda",
            "ATM\'s",
            "Tesorería",
            "Blindados",
            "Sucursal",
            "Caja Empresarial"});
            this.cboArea.Location = new System.Drawing.Point(113, 90);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(200, 21);
            this.cboArea.TabIndex = 23;
            this.cboArea.SelectedIndexChanged += new System.EventHandler(this.cboArea_SelectedIndexChanged);
            // 
            // cboColaborador
            // 
            this.cboColaborador.Busqueda = true;
            this.cboColaborador.Enabled = false;
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.ListaMostrada = null;
            this.cboColaborador.Location = new System.Drawing.Point(138, 23);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(175, 21);
            this.cboColaborador.TabIndex = 22;
            // 
            // cboEquipo
            // 
            this.cboEquipo.Busqueda = true;
            this.cboEquipo.FormattingEnabled = true;
            this.cboEquipo.ListaMostrada = null;
            this.cboEquipo.Location = new System.Drawing.Point(410, 23);
            this.cboEquipo.Name = "cboEquipo";
            this.cboEquipo.Size = new System.Drawing.Size(175, 21);
            this.cboEquipo.TabIndex = 16;
            this.cboEquipo.SelectedIndexChanged += new System.EventHandler(this.cboEquipo_SelectedIndexChanged);
            // 
            // frmSolicitudRequerimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 578);
            this.Controls.Add(this.gbSolicitud);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbProceso);
            this.Controls.Add(this.gboEvaluacion);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSolicitudRequerimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud de Requerimientos";
            this.gboMantenimiento.ResumeLayout(false);
            this.gboMantenimiento.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatosEquipo.ResumeLayout(false);
            this.gbDatosEquipo.PerformLayout();
            this.gboEvaluacion.ResumeLayout(false);
            this.gboEvaluacion.PerformLayout();
            this.gbProceso.ResumeLayout(false);
            this.gbProceso.PerformLayout();
            this.gbSolicitud.ResumeLayout(false);
            this.gbSolicitud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gboMantenimiento;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtActivo;
        private System.Windows.Forms.GroupBox gbDatosEquipo;
        private ComboBoxBusqueda cboEquipo;
        private System.Windows.Forms.TextBox txtDescRequerimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gboEvaluacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescServicio;
        private System.Windows.Forms.GroupBox gbProceso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSAP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFechaSolicitud;
        private System.Windows.Forms.RadioButton rbtnExcelente;
        private System.Windows.Forms.RadioButton rbtnBueno;
        private System.Windows.Forms.RadioButton rbtnRegular;
        private System.Windows.Forms.RadioButton rbtnMalo;
        private System.Windows.Forms.DateTimePicker dtpFechaEjecucion;
        private System.Windows.Forms.DateTimePicker dtpFechaProveedor;
        private System.Windows.Forms.RadioButton rbtnCorrectivo;
        private System.Windows.Forms.RadioButton rbtnPreventivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbSolicitud;
        private ComboBoxBusqueda cboColaborador;
        private System.Windows.Forms.ComboBox cboArea;
    }
}