namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmEntregaBajoAltoVolumen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaBajoAltoVolumen));
            this.btnProcesar = new System.Windows.Forms.Button();
            this.gbDatosEntrega = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtHeadercard = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtColaborador = new System.Windows.Forms.TextBox();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cboCamara = new GUILayer.ComboBoxBusqueda();
            this.lblCamara = new System.Windows.Forms.Label();
            this.cboTipoEntrega = new System.Windows.Forms.ComboBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDatosEntrega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnProcesar.Location = new System.Drawing.Point(82, 239);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(90, 40);
            this.btnProcesar.TabIndex = 26;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // gbDatosEntrega
            // 
            this.gbDatosEntrega.Controls.Add(this.dtpFecha);
            this.gbDatosEntrega.Controls.Add(this.lblFecha);
            this.gbDatosEntrega.Controls.Add(this.txtHeadercard);
            this.gbDatosEntrega.Controls.Add(this.btnProcesar);
            this.gbDatosEntrega.Controls.Add(this.label1);
            this.gbDatosEntrega.Controls.Add(this.txtColaborador);
            this.gbDatosEntrega.Controls.Add(this.lblColaborador);
            this.gbDatosEntrega.Controls.Add(this.btnCancelar);
            this.gbDatosEntrega.Controls.Add(this.cboCamara);
            this.gbDatosEntrega.Controls.Add(this.lblCamara);
            this.gbDatosEntrega.Controls.Add(this.cboTipoEntrega);
            this.gbDatosEntrega.Controls.Add(this.nudMonto);
            this.gbDatosEntrega.Controls.Add(this.lblMonto);
            this.gbDatosEntrega.Controls.Add(this.lblMoneda);
            this.gbDatosEntrega.Location = new System.Drawing.Point(23, 68);
            this.gbDatosEntrega.Name = "gbDatosEntrega";
            this.gbDatosEntrega.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosEntrega.Size = new System.Drawing.Size(398, 295);
            this.gbDatosEntrega.TabIndex = 23;
            this.gbDatosEntrega.TabStop = false;
            this.gbDatosEntrega.Text = "Datos de la Entrega";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(116, 128);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(241, 20);
            this.dtpFecha.TabIndex = 28;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(57, 134);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 27;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtHeadercard
            // 
            this.txtHeadercard.Location = new System.Drawing.Point(117, 198);
            this.txtHeadercard.Name = "txtHeadercard";
            this.txtHeadercard.Size = new System.Drawing.Size(255, 20);
            this.txtHeadercard.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "HeaderCard:";
            // 
            // txtColaborador
            // 
            this.txtColaborador.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtColaborador.Location = new System.Drawing.Point(116, 55);
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.ReadOnly = true;
            this.txtColaborador.Size = new System.Drawing.Size(255, 20);
            this.txtColaborador.TabIndex = 22;
            // 
            // lblColaborador
            // 
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Location = new System.Drawing.Point(30, 57);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(67, 13);
            this.lblColaborador.TabIndex = 21;
            this.lblColaborador.Text = "Colaborador:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(210, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboCamara
            // 
            this.cboCamara.Busqueda = true;
            this.cboCamara.Enabled = false;
            this.cboCamara.FormattingEnabled = true;
            this.cboCamara.ListaMostrada = null;
            this.cboCamara.Location = new System.Drawing.Point(116, 22);
            this.cboCamara.Name = "cboCamara";
            this.cboCamara.Size = new System.Drawing.Size(253, 21);
            this.cboCamara.TabIndex = 17;
            // 
            // lblCamara
            // 
            this.lblCamara.AutoSize = true;
            this.lblCamara.Location = new System.Drawing.Point(51, 30);
            this.lblCamara.Name = "lblCamara";
            this.lblCamara.Size = new System.Drawing.Size(46, 13);
            this.lblCamara.TabIndex = 16;
            this.lblCamara.Text = "Cámara:";
            // 
            // cboTipoEntrega
            // 
            this.cboTipoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEntrega.Enabled = false;
            this.cboTipoEntrega.FormattingEnabled = true;
            this.cboTipoEntrega.Items.AddRange(new object[] {
            "Entrega Alta Denominación",
            "Entrega Baja Denominación",
            "Entrega Dólares",
            "Entrega Total Colones",
            "Entrega Euros"});
            this.cboTipoEntrega.Location = new System.Drawing.Point(116, 91);
            this.cboTipoEntrega.Name = "cboTipoEntrega";
            this.cboTipoEntrega.Size = new System.Drawing.Size(252, 21);
            this.cboTipoEntrega.TabIndex = 15;
            // 
            // nudMonto
            // 
            this.nudMonto.BackColor = System.Drawing.Color.PapayaWhip;
            this.nudMonto.Enabled = false;
            this.nudMonto.Location = new System.Drawing.Point(117, 165);
            this.nudMonto.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.ReadOnly = true;
            this.nudMonto.Size = new System.Drawing.Size(254, 20);
            this.nudMonto.TabIndex = 14;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(8, 167);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(91, 13);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto a entregar:";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(26, 94);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(71, 13);
            this.lblMoneda.TabIndex = 4;
            this.lblMoneda.Text = "Tipo Entrega:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(1, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(436, 60);
            this.pnlFondo.TabIndex = 24;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // frmEntregaBajoAltoVolumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 370);
            this.ControlBox = false;
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosEntrega);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEntregaBajoAltoVolumen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Entrega de Bajo a Alto Volumen";
            this.Load += new System.EventHandler(this.frmEntregaBajoAltoVolumen_Load);
            this.gbDatosEntrega.ResumeLayout(false);
            this.gbDatosEntrega.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.GroupBox gbDatosEntrega;
        private System.Windows.Forms.TextBox txtColaborador;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.Button btnCancelar;
        private ComboBoxBusqueda cboCamara;
        private System.Windows.Forms.Label lblCamara;
        private System.Windows.Forms.ComboBox cboTipoEntrega;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.TextBox txtHeadercard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ErrorProvider epError;
    }
}