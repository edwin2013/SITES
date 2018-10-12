namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmTipoEntregaAV
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoEntregaAV));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbotipoentregaAV = new GUILayer.ComboBoxBusqueda();
            this.gbDatosEntrega = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtHeadercard = new System.Windows.Forms.TextBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColaborador = new System.Windows.Forms.TextBox();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cboCamara = new GUILayer.ComboBoxBusqueda();
            this.lblCamara = new System.Windows.Forms.Label();
            this.cboTipoEntrega = new System.Windows.Forms.ComboBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatosEntrega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(3, 5);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(709, 60);
            this.pnlFondo.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione tipo de entrega AV:";
            // 
            // cbotipoentregaAV
            // 
            this.cbotipoentregaAV.Busqueda = true;
            this.cbotipoentregaAV.FormattingEnabled = true;
            this.cbotipoentregaAV.Items.AddRange(new object[] {
            "Entrega Alta Denominación",
            "Entrega Baja Denominación",
            "Entrega Dólares",
            "Entrega Colones Ambas Denominaciones",
            "Entrega Euros"});
            this.cbotipoentregaAV.ListaMostrada = null;
            this.cbotipoentregaAV.Location = new System.Drawing.Point(242, 86);
            this.cbotipoentregaAV.Name = "cbotipoentregaAV";
            this.cbotipoentregaAV.Size = new System.Drawing.Size(470, 21);
            this.cbotipoentregaAV.TabIndex = 3;
            this.cbotipoentregaAV.SelectedIndexChanged += new System.EventHandler(this.cbotipoentregaAV_SelectedIndexChanged);
            // 
            // gbDatosEntrega
            // 
            this.gbDatosEntrega.Controls.Add(this.dtpFecha);
            this.gbDatosEntrega.Controls.Add(this.lblFecha);
            this.gbDatosEntrega.Controls.Add(this.txtHeadercard);
            this.gbDatosEntrega.Controls.Add(this.btnProcesar);
            this.gbDatosEntrega.Controls.Add(this.label2);
            this.gbDatosEntrega.Controls.Add(this.txtColaborador);
            this.gbDatosEntrega.Controls.Add(this.lblColaborador);
            this.gbDatosEntrega.Controls.Add(this.btnCancelar);
            this.gbDatosEntrega.Controls.Add(this.cboCamara);
            this.gbDatosEntrega.Controls.Add(this.lblCamara);
            this.gbDatosEntrega.Controls.Add(this.cboTipoEntrega);
            this.gbDatosEntrega.Controls.Add(this.nudMonto);
            this.gbDatosEntrega.Controls.Add(this.lblMonto);
            this.gbDatosEntrega.Controls.Add(this.lblMoneda);
            this.gbDatosEntrega.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosEntrega.Location = new System.Drawing.Point(88, 117);
            this.gbDatosEntrega.Name = "gbDatosEntrega";
            this.gbDatosEntrega.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosEntrega.Size = new System.Drawing.Size(565, 295);
            this.gbDatosEntrega.TabIndex = 24;
            this.gbDatosEntrega.TabStop = false;
            this.gbDatosEntrega.Text = "Datos de la Entrega";
            this.gbDatosEntrega.Visible = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(139, 128);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(414, 23);
            this.dtpFecha.TabIndex = 28;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(57, 134);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 16);
            this.lblFecha.TabIndex = 27;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtHeadercard
            // 
            this.txtHeadercard.Location = new System.Drawing.Point(140, 198);
            this.txtHeadercard.Name = "txtHeadercard";
            this.txtHeadercard.Size = new System.Drawing.Size(414, 23);
            this.txtHeadercard.TabIndex = 24;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnProcesar.Location = new System.Drawing.Point(195, 239);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(115, 50);
            this.btnProcesar.TabIndex = 26;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "HeaderCard:";
            // 
            // txtColaborador
            // 
            this.txtColaborador.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtColaborador.Location = new System.Drawing.Point(139, 55);
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.ReadOnly = true;
            this.txtColaborador.Size = new System.Drawing.Size(414, 23);
            this.txtColaborador.TabIndex = 22;
            // 
            // lblColaborador
            // 
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Location = new System.Drawing.Point(30, 57);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(92, 16);
            this.lblColaborador.TabIndex = 21;
            this.lblColaborador.Text = "Colaborador:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(323, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 50);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // cboCamara
            // 
            this.cboCamara.Busqueda = true;
            this.cboCamara.Enabled = false;
            this.cboCamara.FormattingEnabled = true;
            this.cboCamara.ListaMostrada = null;
            this.cboCamara.Location = new System.Drawing.Point(139, 22);
            this.cboCamara.Name = "cboCamara";
            this.cboCamara.Size = new System.Drawing.Size(412, 24);
            this.cboCamara.TabIndex = 17;
            this.cboCamara.SelectedIndexChanged += new System.EventHandler(this.cboCamara_SelectedIndexChanged);
            // 
            // lblCamara
            // 
            this.lblCamara.AutoSize = true;
            this.lblCamara.Location = new System.Drawing.Point(51, 30);
            this.lblCamara.Name = "lblCamara";
            this.lblCamara.Size = new System.Drawing.Size(63, 16);
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
            "Entrega Colones Ambas Denominaciones",
            "Entrega Euros"});
            this.cboTipoEntrega.Location = new System.Drawing.Point(139, 91);
            this.cboTipoEntrega.Name = "cboTipoEntrega";
            this.cboTipoEntrega.Size = new System.Drawing.Size(415, 24);
            this.cboTipoEntrega.TabIndex = 15;
            // 
            // nudMonto
            // 
            this.nudMonto.BackColor = System.Drawing.Color.PapayaWhip;
            this.nudMonto.Enabled = false;
            this.nudMonto.Location = new System.Drawing.Point(140, 165);
            this.nudMonto.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.ReadOnly = true;
            this.nudMonto.Size = new System.Drawing.Size(413, 23);
            this.nudMonto.TabIndex = 14;
            this.nudMonto.ValueChanged += new System.EventHandler(this.nudMonto_ValueChanged);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(8, 167);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(129, 16);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto a entregar:";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(26, 94);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(98, 16);
            this.lblMoneda.TabIndex = 4;
            this.lblMoneda.Text = "Tipo Entrega:";
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // frmTipoEntregaAV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 418);
            this.ControlBox = false;
            this.Controls.Add(this.gbDatosEntrega);
            this.Controls.Add(this.cbotipoentregaAV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlFondo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoEntregaAV";
            this.Text = "Entrega de Cajero de Bajo a Alto Volumen";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatosEntrega.ResumeLayout(false);
            this.gbDatosEntrega.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label label1;
        private ComboBoxBusqueda cbotipoentregaAV;
        private System.Windows.Forms.GroupBox gbDatosEntrega;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtHeadercard;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColaborador;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.Button btnCancelar;
        private ComboBoxBusqueda cboCamara;
        private System.Windows.Forms.Label lblCamara;
        private System.Windows.Forms.ComboBox cboTipoEntrega;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.ErrorProvider epError;
    }
}