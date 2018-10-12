namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmBajoVolumenIngresoManifiesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBajoVolumenIngresoManifiesto));
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.nudMontoEUR = new System.Windows.Forms.NumericUpDown();
            this.lblMontoEuros = new System.Windows.Forms.Label();
            this.nudMontoUSD = new System.Windows.Forms.NumericUpDown();
            this.lblMontoDolares = new System.Windows.Forms.Label();
            this.cboCamara = new GUILayer.ComboBoxBusqueda();
            this.lblcamara = new System.Windows.Forms.Label();
            this.nudMontoCOL = new System.Windows.Forms.NumericUpDown();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.lblMontoCOL = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.lblPuntodeVenta = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNumeroManifiesto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnEntregaAV = new System.Windows.Forms.Button();
            this.gbDatosManifiesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoEUR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoUSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCOL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.nudMontoEUR);
            this.gbDatosManifiesto.Controls.Add(this.lblMontoEuros);
            this.gbDatosManifiesto.Controls.Add(this.nudMontoUSD);
            this.gbDatosManifiesto.Controls.Add(this.lblMontoDolares);
            this.gbDatosManifiesto.Controls.Add(this.cboCamara);
            this.gbDatosManifiesto.Controls.Add(this.lblcamara);
            this.gbDatosManifiesto.Controls.Add(this.nudMontoCOL);
            this.gbDatosManifiesto.Controls.Add(this.cboCliente);
            this.gbDatosManifiesto.Controls.Add(this.lblMontoCOL);
            this.gbDatosManifiesto.Controls.Add(this.lblCliente);
            this.gbDatosManifiesto.Controls.Add(this.cboPuntoVenta);
            this.gbDatosManifiesto.Controls.Add(this.lblPuntodeVenta);
            this.gbDatosManifiesto.Controls.Add(this.txtNumero);
            this.gbDatosManifiesto.Controls.Add(this.lblNumeroManifiesto);
            this.gbDatosManifiesto.Location = new System.Drawing.Point(12, 66);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(414, 245);
            this.gbDatosManifiesto.TabIndex = 2;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos del Manifiesto";
            // 
            // nudMontoEUR
            // 
            this.nudMontoEUR.Enabled = false;
            this.nudMontoEUR.Location = new System.Drawing.Point(124, 149);
            this.nudMontoEUR.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMontoEUR.Name = "nudMontoEUR";
            this.nudMontoEUR.Size = new System.Drawing.Size(254, 20);
            this.nudMontoEUR.TabIndex = 4;
            this.nudMontoEUR.ValueChanged += new System.EventHandler(this.nudMontoEUR_ValueChanged);
            // 
            // lblMontoEuros
            // 
            this.lblMontoEuros.AutoSize = true;
            this.lblMontoEuros.Location = new System.Drawing.Point(23, 156);
            this.lblMontoEuros.Name = "lblMontoEuros";
            this.lblMontoEuros.Size = new System.Drawing.Size(70, 13);
            this.lblMontoEuros.TabIndex = 19;
            this.lblMontoEuros.Text = "Monto Euros:";
            // 
            // nudMontoUSD
            // 
            this.nudMontoUSD.Enabled = false;
            this.nudMontoUSD.Location = new System.Drawing.Point(123, 117);
            this.nudMontoUSD.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMontoUSD.Name = "nudMontoUSD";
            this.nudMontoUSD.Size = new System.Drawing.Size(254, 20);
            this.nudMontoUSD.TabIndex = 3;
            this.nudMontoUSD.ValueChanged += new System.EventHandler(this.nudMontoUSD_ValueChanged);
            // 
            // lblMontoDolares
            // 
            this.lblMontoDolares.AutoSize = true;
            this.lblMontoDolares.Location = new System.Drawing.Point(22, 124);
            this.lblMontoDolares.Name = "lblMontoDolares";
            this.lblMontoDolares.Size = new System.Drawing.Size(79, 13);
            this.lblMontoDolares.TabIndex = 17;
            this.lblMontoDolares.Text = "Monto Dólares:";
            // 
            // cboCamara
            // 
            this.cboCamara.Busqueda = true;
            this.cboCamara.FormattingEnabled = true;
            this.cboCamara.ListaMostrada = null;
            this.cboCamara.Location = new System.Drawing.Point(124, 21);
            this.cboCamara.Name = "cboCamara";
            this.cboCamara.Size = new System.Drawing.Size(253, 21);
            this.cboCamara.TabIndex = 0;
            this.cboCamara.SelectedIndexChanged += new System.EventHandler(this.cboCamara_SelectedIndexChanged);
            // 
            // lblcamara
            // 
            this.lblcamara.AutoSize = true;
            this.lblcamara.Location = new System.Drawing.Point(37, 30);
            this.lblcamara.Name = "lblcamara";
            this.lblcamara.Size = new System.Drawing.Size(46, 13);
            this.lblcamara.TabIndex = 16;
            this.lblcamara.Text = "Cámara:";
            // 
            // nudMontoCOL
            // 
            this.nudMontoCOL.Location = new System.Drawing.Point(123, 86);
            this.nudMontoCOL.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMontoCOL.Name = "nudMontoCOL";
            this.nudMontoCOL.Size = new System.Drawing.Size(254, 20);
            this.nudMontoCOL.TabIndex = 2;
            this.nudMontoCOL.ValueChanged += new System.EventHandler(this.nudMonto_ValueChanged);
            this.nudMontoCOL.Click += new System.EventHandler(this.nudMontoCOL_Click);
            this.nudMontoCOL.Enter += new System.EventHandler(this.nudMontoCOL_Enter);
            this.nudMontoCOL.Leave += new System.EventHandler(this.nudMonto_Leave);
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(122, 182);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(255, 21);
            this.cboCliente.TabIndex = 5;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblMontoCOL
            // 
            this.lblMontoCOL.AutoSize = true;
            this.lblMontoCOL.Location = new System.Drawing.Point(22, 93);
            this.lblMontoCOL.Name = "lblMontoCOL";
            this.lblMontoCOL.Size = new System.Drawing.Size(81, 13);
            this.lblMontoCOL.TabIndex = 2;
            this.lblMontoCOL.Text = "Monto Colones:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(43, 187);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = false;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(122, 209);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(255, 21);
            this.cboPuntoVenta.TabIndex = 6;
            this.cboPuntoVenta.SelectedIndexChanged += new System.EventHandler(this.cboPuntoVenta_SelectedIndexChanged);
            // 
            // lblPuntodeVenta
            // 
            this.lblPuntodeVenta.AutoSize = true;
            this.lblPuntodeVenta.Location = new System.Drawing.Point(2, 212);
            this.lblPuntodeVenta.Name = "lblPuntodeVenta";
            this.lblPuntodeVenta.Size = new System.Drawing.Size(84, 13);
            this.lblPuntodeVenta.TabIndex = 8;
            this.lblPuntodeVenta.Text = "Punto de Venta:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(122, 55);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(255, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // lblNumeroManifiesto
            // 
            this.lblNumeroManifiesto.AutoSize = true;
            this.lblNumeroManifiesto.Location = new System.Drawing.Point(38, 58);
            this.lblNumeroManifiesto.Name = "lblNumeroManifiesto";
            this.lblNumeroManifiesto.Size = new System.Drawing.Size(43, 13);
            this.lblNumeroManifiesto.TabIndex = 0;
            this.lblNumeroManifiesto.Text = "Código:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(125, 327);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::GUILayer.Properties.Resources.registro;
            this.btnProcesar.Location = new System.Drawing.Point(15, 327);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(90, 40);
            this.btnProcesar.TabIndex = 7;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
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
            this.pnlFondo.Size = new System.Drawing.Size(435, 60);
            this.pnlFondo.TabIndex = 10;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(4, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(426, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnEntregaAV
            // 
            this.btnEntregaAV.Image = global::GUILayer.Properties.Resources.tulas;
            this.btnEntregaAV.Location = new System.Drawing.Point(236, 327);
            this.btnEntregaAV.Name = "btnEntregaAV";
            this.btnEntregaAV.Size = new System.Drawing.Size(107, 40);
            this.btnEntregaAV.TabIndex = 47;
            this.btnEntregaAV.Text = "Entrega Alto Volumen";
            this.btnEntregaAV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEntregaAV.UseVisualStyleBackColor = false;
            this.btnEntregaAV.Click += new System.EventHandler(this.btnEntregaAV_Click);
            // 
            // frmBajoVolumenIngresoManifiesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 387);
            this.Controls.Add(this.btnEntregaAV);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.gbDatosManifiesto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBajoVolumenIngresoManifiesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesamiento Bajo Volumen - Ingreso Manifiesto";
            this.Load += new System.EventHandler(this.frmBajoVolumenIngresoManifiesto_Load);
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoEUR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoUSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCOL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.Label lblMontoCOL;
        private System.Windows.Forms.Label lblCliente;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblPuntodeVenta;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNumeroManifiesto;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.NumericUpDown nudMontoCOL;
        private System.Windows.Forms.Label lblcamara;
        private ComboBoxBusqueda cboCamara;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.NumericUpDown nudMontoEUR;
        private System.Windows.Forms.Label lblMontoEuros;
        private System.Windows.Forms.NumericUpDown nudMontoUSD;
        private System.Windows.Forms.Label lblMontoDolares;
        private System.Windows.Forms.Button btnEntregaAV;
    }
}