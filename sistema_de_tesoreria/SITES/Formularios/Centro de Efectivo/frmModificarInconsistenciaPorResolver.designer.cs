namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmModificarInconsistenciaPorResolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarInconsistenciaPorResolver));
            this.lblCliente = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtNumDeposito = new System.Windows.Forms.TextBox();
            this.lblNumDeposito = new System.Windows.Forms.Label();
            this.txtCtaReferencia = new System.Windows.Forms.TextBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.lblMontoDeposito = new System.Windows.Forms.Label();
            this.nudMontoDeclarado = new System.Windows.Forms.NumericUpDown();
            this.lblCajero = new System.Windows.Forms.Label();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.txtTula = new System.Windows.Forms.TextBox();
            this.lblTula = new System.Windows.Forms.Label();
            this.lblcamara = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtcajero = new System.Windows.Forms.TextBox();
            this.lblpuntoventa = new System.Windows.Forms.Label();
            this.txtcedula = new System.Windows.Forms.TextBox();
            this.lblcedula = new System.Windows.Forms.Label();
            this.cboMonedaDeclarada = new System.Windows.Forms.ComboBox();
            this.lblMonedaDeclarada = new System.Windows.Forms.Label();
            this.txtCodigoTransaccion = new System.Windows.Forms.TextBox();
            this.lblCodigoTransaccion = new System.Windows.Forms.Label();
            this.txtcodigoVD = new System.Windows.Forms.TextBox();
            this.lblcodigoVD = new System.Windows.Forms.Label();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.cboCamara = new GUILayer.ComboBoxBusqueda();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDeclarado)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(72, 241);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 16;
            this.lblCliente.Text = "Cliente:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(120, 70);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(253, 20);
            this.dtpFecha.TabIndex = 46;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(74, 76);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 45;
            this.lblFecha.Text = "Fecha:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(120, 101);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(253, 20);
            this.dateTimePicker1.TabIndex = 48;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(74, 107);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(33, 13);
            this.lblHora.TabIndex = 47;
            this.lblHora.Text = "Hora:";
            // 
            // txtNumDeposito
            // 
            this.txtNumDeposito.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtNumDeposito.Location = new System.Drawing.Point(120, 353);
            this.txtNumDeposito.Name = "txtNumDeposito";
            this.txtNumDeposito.ReadOnly = true;
            this.txtNumDeposito.Size = new System.Drawing.Size(253, 20);
            this.txtNumDeposito.TabIndex = 50;
            this.txtNumDeposito.TextChanged += new System.EventHandler(this.txtNumDeposito_TextChanged);
            // 
            // lblNumDeposito
            // 
            this.lblNumDeposito.AutoSize = true;
            this.lblNumDeposito.Location = new System.Drawing.Point(37, 356);
            this.lblNumDeposito.Name = "lblNumDeposito";
            this.lblNumDeposito.Size = new System.Drawing.Size(80, 13);
            this.lblNumDeposito.TabIndex = 49;
            this.lblNumDeposito.Text = "Núm. Depósito:";
            // 
            // txtCtaReferencia
            // 
            this.txtCtaReferencia.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCtaReferencia.Location = new System.Drawing.Point(120, 379);
            this.txtCtaReferencia.Name = "txtCtaReferencia";
            this.txtCtaReferencia.ReadOnly = true;
            this.txtCtaReferencia.Size = new System.Drawing.Size(253, 20);
            this.txtCtaReferencia.TabIndex = 52;
            this.txtCtaReferencia.TextChanged += new System.EventHandler(this.txtCtaReferencia_TextChanged);
            this.txtCtaReferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCtaReferencia_KeyPress);
            this.txtCtaReferencia.Leave += new System.EventHandler(this.txtCtaReferencia_Leave);
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(70, 382);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(44, 13);
            this.lblCuenta.TabIndex = 51;
            this.lblCuenta.Text = "Cuenta:";
            // 
            // lblMontoDeposito
            // 
            this.lblMontoDeposito.AutoSize = true;
            this.lblMontoDeposito.Location = new System.Drawing.Point(11, 462);
            this.lblMontoDeposito.Name = "lblMontoDeposito";
            this.lblMontoDeposito.Size = new System.Drawing.Size(102, 13);
            this.lblMontoDeposito.TabIndex = 54;
            this.lblMontoDeposito.Text = "Monto del Depósito:";
            // 
            // nudMontoDeclarado
            // 
            this.nudMontoDeclarado.Enabled = false;
            this.nudMontoDeclarado.Location = new System.Drawing.Point(119, 460);
            this.nudMontoDeclarado.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMontoDeclarado.Name = "nudMontoDeclarado";
            this.nudMontoDeclarado.Size = new System.Drawing.Size(253, 20);
            this.nudMontoDeclarado.TabIndex = 53;
            this.nudMontoDeclarado.ValueChanged += new System.EventHandler(this.nudMontoDeclarado_ValueChanged);
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(69, 135);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 55;
            this.lblCajero.Text = "Cajero:";
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtManifiesto.Enabled = false;
            this.txtManifiesto.Location = new System.Drawing.Point(118, 159);
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.ReadOnly = true;
            this.txtManifiesto.Size = new System.Drawing.Size(255, 20);
            this.txtManifiesto.TabIndex = 58;
            this.txtManifiesto.TextChanged += new System.EventHandler(this.txtManifiesto_TextChanged);
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(56, 162);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManifiesto.TabIndex = 57;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // txtTula
            // 
            this.txtTula.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTula.Enabled = false;
            this.txtTula.Location = new System.Drawing.Point(120, 185);
            this.txtTula.Name = "txtTula";
            this.txtTula.ReadOnly = true;
            this.txtTula.Size = new System.Drawing.Size(253, 20);
            this.txtTula.TabIndex = 60;
            this.txtTula.TextChanged += new System.EventHandler(this.txtTula_TextChanged);
            // 
            // lblTula
            // 
            this.lblTula.AutoSize = true;
            this.lblTula.Location = new System.Drawing.Point(78, 188);
            this.lblTula.Name = "lblTula";
            this.lblTula.Size = new System.Drawing.Size(31, 13);
            this.lblTula.TabIndex = 59;
            this.lblTula.Text = "Tula:";
            // 
            // lblcamara
            // 
            this.lblcamara.AutoSize = true;
            this.lblcamara.Location = new System.Drawing.Point(68, 214);
            this.lblcamara.Name = "lblcamara";
            this.lblcamara.Size = new System.Drawing.Size(46, 13);
            this.lblcamara.TabIndex = 61;
            this.lblcamara.Text = "Cámara:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::GUILayer.Properties.Resources.registro1;
            this.btnProcesar.Location = new System.Drawing.Point(143, 492);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(90, 40);
            this.btnProcesar.TabIndex = 64;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(243, 492);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 63;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 5);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(547, 60);
            this.pnlFondo.TabIndex = 65;
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
            // txtcajero
            // 
            this.txtcajero.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtcajero.Enabled = false;
            this.txtcajero.Location = new System.Drawing.Point(120, 132);
            this.txtcajero.Name = "txtcajero";
            this.txtcajero.ReadOnly = true;
            this.txtcajero.Size = new System.Drawing.Size(430, 20);
            this.txtcajero.TabIndex = 66;
            // 
            // lblpuntoventa
            // 
            this.lblpuntoventa.AutoSize = true;
            this.lblpuntoventa.Location = new System.Drawing.Point(30, 271);
            this.lblpuntoventa.Name = "lblpuntoventa";
            this.lblpuntoventa.Size = new System.Drawing.Size(84, 13);
            this.lblpuntoventa.TabIndex = 67;
            this.lblpuntoventa.Text = "Punto de Venta:";
            // 
            // txtcedula
            // 
            this.txtcedula.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtcedula.Location = new System.Drawing.Point(120, 327);
            this.txtcedula.Name = "txtcedula";
            this.txtcedula.ReadOnly = true;
            this.txtcedula.Size = new System.Drawing.Size(253, 20);
            this.txtcedula.TabIndex = 70;
            // 
            // lblcedula
            // 
            this.lblcedula.AutoSize = true;
            this.lblcedula.Location = new System.Drawing.Point(71, 330);
            this.lblcedula.Name = "lblcedula";
            this.lblcedula.Size = new System.Drawing.Size(43, 13);
            this.lblcedula.TabIndex = 69;
            this.lblcedula.Text = "Cédula:";
            // 
            // cboMonedaDeclarada
            // 
            this.cboMonedaDeclarada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaDeclarada.Enabled = false;
            this.cboMonedaDeclarada.FormattingEnabled = true;
            this.cboMonedaDeclarada.Items.AddRange(new object[] {
            "Colones",
            "Dólares",
            "Euros"});
            this.cboMonedaDeclarada.Location = new System.Drawing.Point(122, 407);
            this.cboMonedaDeclarada.Name = "cboMonedaDeclarada";
            this.cboMonedaDeclarada.Size = new System.Drawing.Size(250, 21);
            this.cboMonedaDeclarada.TabIndex = 71;
            this.cboMonedaDeclarada.SelectedIndexChanged += new System.EventHandler(this.cboMonedaDeclarada_SelectedIndexChanged);
            // 
            // lblMonedaDeclarada
            // 
            this.lblMonedaDeclarada.AutoSize = true;
            this.lblMonedaDeclarada.Location = new System.Drawing.Point(15, 408);
            this.lblMonedaDeclarada.Name = "lblMonedaDeclarada";
            this.lblMonedaDeclarada.Size = new System.Drawing.Size(101, 13);
            this.lblMonedaDeclarada.TabIndex = 74;
            this.lblMonedaDeclarada.Text = "Moneda Declarada:";
            // 
            // txtCodigoTransaccion
            // 
            this.txtCodigoTransaccion.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCodigoTransaccion.Location = new System.Drawing.Point(122, 434);
            this.txtCodigoTransaccion.Name = "txtCodigoTransaccion";
            this.txtCodigoTransaccion.ReadOnly = true;
            this.txtCodigoTransaccion.Size = new System.Drawing.Size(253, 20);
            this.txtCodigoTransaccion.TabIndex = 72;
            // 
            // lblCodigoTransaccion
            // 
            this.lblCodigoTransaccion.AutoSize = true;
            this.lblCodigoTransaccion.Location = new System.Drawing.Point(9, 437);
            this.lblCodigoTransaccion.Name = "lblCodigoTransaccion";
            this.lblCodigoTransaccion.Size = new System.Drawing.Size(105, 13);
            this.lblCodigoTransaccion.TabIndex = 73;
            this.lblCodigoTransaccion.Text = "Código Transacción:";
            // 
            // txtcodigoVD
            // 
            this.txtcodigoVD.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtcodigoVD.Location = new System.Drawing.Point(119, 298);
            this.txtcodigoVD.Name = "txtcodigoVD";
            this.txtcodigoVD.ReadOnly = true;
            this.txtcodigoVD.Size = new System.Drawing.Size(253, 20);
            this.txtcodigoVD.TabIndex = 76;
            // 
            // lblcodigoVD
            // 
            this.lblcodigoVD.AutoSize = true;
            this.lblcodigoVD.Location = new System.Drawing.Point(48, 301);
            this.lblcodigoVD.Name = "lblcodigoVD";
            this.lblcodigoVD.Size = new System.Drawing.Size(61, 13);
            this.lblcodigoVD.TabIndex = 75;
            this.lblcodigoVD.Text = "Codigo VD:";
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = false;
            this.cboPuntoVenta.Enabled = false;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(119, 268);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(253, 21);
            this.cboPuntoVenta.TabIndex = 68;
            this.cboPuntoVenta.SelectedIndexChanged += new System.EventHandler(this.dboPuntoVenta_SelectedIndexChanged);
            // 
            // cboCamara
            // 
            this.cboCamara.Busqueda = true;
            this.cboCamara.Enabled = false;
            this.cboCamara.FormattingEnabled = true;
            this.cboCamara.ListaMostrada = null;
            this.cboCamara.Location = new System.Drawing.Point(120, 211);
            this.cboCamara.Name = "cboCamara";
            this.cboCamara.Size = new System.Drawing.Size(253, 21);
            this.cboCamara.TabIndex = 62;
            this.cboCamara.SelectedIndexChanged += new System.EventHandler(this.cboCamara_SelectedIndexChanged);
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.Enabled = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(120, 238);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(253, 21);
            this.cboCliente.TabIndex = 17;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // frmModificarInconsistenciaPorResolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 554);
            this.Controls.Add(this.txtcodigoVD);
            this.Controls.Add(this.lblcodigoVD);
            this.Controls.Add(this.cboMonedaDeclarada);
            this.Controls.Add(this.lblMonedaDeclarada);
            this.Controls.Add(this.txtCodigoTransaccion);
            this.Controls.Add(this.lblCodigoTransaccion);
            this.Controls.Add(this.txtcedula);
            this.Controls.Add(this.lblcedula);
            this.Controls.Add(this.lblpuntoventa);
            this.Controls.Add(this.cboPuntoVenta);
            this.Controls.Add(this.txtcajero);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cboCamara);
            this.Controls.Add(this.lblcamara);
            this.Controls.Add(this.txtTula);
            this.Controls.Add(this.lblTula);
            this.Controls.Add(this.txtManifiesto);
            this.Controls.Add(this.lblManifiesto);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.lblMontoDeposito);
            this.Controls.Add(this.nudMontoDeclarado);
            this.Controls.Add(this.txtCtaReferencia);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.txtNumDeposito);
            this.Controls.Add(this.lblNumDeposito);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmModificarInconsistenciaPorResolver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Modificar Inconsistencia Por Resolver";
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDeclarado)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtNumDeposito;
        private System.Windows.Forms.Label lblNumDeposito;
        private System.Windows.Forms.TextBox txtCtaReferencia;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Label lblMontoDeposito;
        private System.Windows.Forms.NumericUpDown nudMontoDeclarado;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.TextBox txtManifiesto;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.TextBox txtTula;
        private System.Windows.Forms.Label lblTula;
        private ComboBoxBusqueda cboCamara;
        private System.Windows.Forms.Label lblcamara;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.TextBox txtcedula;
        private System.Windows.Forms.Label lblcedula;
        private System.Windows.Forms.Label lblpuntoventa;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.TextBox txtcajero;
        private System.Windows.Forms.ComboBox cboMonedaDeclarada;
        private System.Windows.Forms.Label lblMonedaDeclarada;
        private System.Windows.Forms.TextBox txtCodigoTransaccion;
        private System.Windows.Forms.Label lblCodigoTransaccion;
        private System.Windows.Forms.TextBox txtcodigoVD;
        private System.Windows.Forms.Label lblcodigoVD;
    }
}