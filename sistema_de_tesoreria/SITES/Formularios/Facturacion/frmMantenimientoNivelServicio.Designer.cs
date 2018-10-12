namespace GUILayer.Formularios.Facturacion
{
    partial class frmMantenimientoNivelServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoNivelServicio));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblPorcentajeEfectividad = new System.Windows.Forms.Label();
            this.lblPorcentajeCumplimiento = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.nudPorcentajeEfectividad = new System.Windows.Forms.NumericUpDown();
            this.nudPorcenajeCumplimiento = new System.Windows.Forms.NumericUpDown();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajeEfectividad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcenajeCumplimiento)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(1, 1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(577, 60);
            this.pnlFondo.TabIndex = 8;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(400, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblTransportadora);
            this.gbDatos.Controls.Add(this.cboTransportadora);
            this.gbDatos.Controls.Add(this.groupBox1);
            this.gbDatos.Controls.Add(this.lblPorcentajeEfectividad);
            this.gbDatos.Controls.Add(this.lblPorcentajeCumplimiento);
            this.gbDatos.Controls.Add(this.lblCliente);
            this.gbDatos.Controls.Add(this.nudPorcentajeEfectividad);
            this.gbDatos.Controls.Add(this.nudPorcenajeCumplimiento);
            this.gbDatos.Controls.Add(this.cboCliente);
            this.gbDatos.Location = new System.Drawing.Point(16, 67);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(549, 233);
            this.gbDatos.TabIndex = 9;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Penalidad";
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(16, 70);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 8;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.FormattingEnabled = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(128, 62);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(297, 21);
            this.cboTransportadora.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Location = new System.Drawing.Point(281, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 116);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Período de Válidez";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "De:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(100, 60);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(100, 33);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaInicio.TabIndex = 0;
            // 
            // lblPorcentajeEfectividad
            // 
            this.lblPorcentajeEfectividad.AutoSize = true;
            this.lblPorcentajeEfectividad.Location = new System.Drawing.Point(16, 151);
            this.lblPorcentajeEfectividad.Name = "lblPorcentajeEfectividad";
            this.lblPorcentajeEfectividad.Size = new System.Drawing.Size(98, 13);
            this.lblPorcentajeEfectividad.TabIndex = 5;
            this.lblPorcentajeEfectividad.Text = "% Nivel Efectividad";
            // 
            // lblPorcentajeCumplimiento
            // 
            this.lblPorcentajeCumplimiento.AutoSize = true;
            this.lblPorcentajeCumplimiento.Location = new System.Drawing.Point(16, 101);
            this.lblPorcentajeCumplimiento.Name = "lblPorcentajeCumplimiento";
            this.lblPorcentajeCumplimiento.Size = new System.Drawing.Size(100, 13);
            this.lblPorcentajeCumplimiento.TabIndex = 4;
            this.lblPorcentajeCumplimiento.Text = "% Nivel Cumpliento:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(16, 27);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente:";
            // 
            // nudPorcentajeEfectividad
            // 
            this.nudPorcentajeEfectividad.Location = new System.Drawing.Point(128, 144);
            this.nudPorcentajeEfectividad.Name = "nudPorcentajeEfectividad";
            this.nudPorcentajeEfectividad.Size = new System.Drawing.Size(90, 20);
            this.nudPorcentajeEfectividad.TabIndex = 2;
            // 
            // nudPorcenajeCumplimiento
            // 
            this.nudPorcenajeCumplimiento.Location = new System.Drawing.Point(128, 99);
            this.nudPorcenajeCumplimiento.Name = "nudPorcenajeCumplimiento";
            this.nudPorcenajeCumplimiento.Size = new System.Drawing.Size(90, 20);
            this.nudPorcenajeCumplimiento.TabIndex = 1;
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = true;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(128, 19);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(297, 21);
            this.cboCliente.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(379, 388);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(475, 388);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImportar);
            this.groupBox2.Controls.Add(this.lblArchivo);
            this.groupBox2.Controls.Add(this.btnAbrir);
            this.groupBox2.Controls.Add(this.txtArchivo);
            this.groupBox2.Location = new System.Drawing.Point(12, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 76);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Importar";
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportar.Image = global::GUILayer.Properties.Resources.importar_triales;
            this.btnImportar.Location = new System.Drawing.Point(441, 22);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(90, 40);
            this.btnImportar.TabIndex = 24;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(21, 38);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(46, 13);
            this.lblArchivo.TabIndex = 23;
            this.lblArchivo.Text = "Archivo:";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(368, 35);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(45, 20);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "...";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(73, 35);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(289, 20);
            this.txtArchivo.TabIndex = 2;
            // 
            // frmMantenimientoNivelServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 427);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMantenimientoNivelServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Nivel de Servicio";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajeEfectividad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcenajeCumplimiento)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblPorcentajeEfectividad;
        private System.Windows.Forms.Label lblPorcentajeCumplimiento;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.NumericUpDown nudPorcentajeEfectividad;
        private System.Windows.Forms.NumericUpDown nudPorcenajeCumplimiento;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblTransportadora;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
    }
}