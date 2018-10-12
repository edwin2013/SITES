namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmValidacionCajeroNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidacionCajeroNiquel));
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoProcesamiento = new System.Windows.Forms.ComboBox();
            this.gbEntregaNiquel = new System.Windows.Forms.GroupBox();
            this.nudTotalDeposito = new System.Windows.Forms.NumericUpDown();
            this.nudTotalNiquelCaj = new System.Windows.Forms.NumericUpDown();
            this.lblTotalNiquel = new System.Windows.Forms.Label();
            this.lblTotalDeposito = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.lblTula = new System.Windows.Forms.Label();
            this.txtCodigoTula = new System.Windows.Forms.TextBox();
            this.txtNumDeposito = new System.Windows.Forms.TextBox();
            this.lblNumDeposito = new System.Windows.Forms.Label();
            this.gbMontosContados = new System.Windows.Forms.GroupBox();
            this.nudCinco = new System.Windows.Forms.NumericUpDown();
            this.nudDiez = new System.Windows.Forms.NumericUpDown();
            this.nudVeintiCinco = new System.Windows.Forms.NumericUpDown();
            this.nudCincuenta = new System.Windows.Forms.NumericUpDown();
            this.nudCien = new System.Windows.Forms.NumericUpDown();
            this.nudQuinientos = new System.Windows.Forms.NumericUpDown();
            this.lblQuinientos = new System.Windows.Forms.Label();
            this.lblDiez = new System.Windows.Forms.Label();
            this.lblCincuenta = new System.Windows.Forms.Label();
            this.lblCinco = new System.Windows.Forms.Label();
            this.lblCien = new System.Windows.Forms.Label();
            this.lblVentiCinco = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.txtMontoContado = new System.Windows.Forms.TextBox();
            this.lblMontoContado = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbEnMesa = new System.Windows.Forms.GroupBox();
            this.nudTotalNiquel = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblTotalNiquelEM = new System.Windows.Forms.Label();
            this.txtCajero = new System.Windows.Forms.TextBox();
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbProcesamientoExterno = new System.Windows.Forms.GroupBox();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.lbltransportadora = new System.Windows.Forms.Label();
            this.nudTotNiquelPE = new System.Windows.Forms.NumericUpDown();
            this.lblTotalNiquelPE = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.gbEntregaNiquel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalDeposito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalNiquelCaj)).BeginInit();
            this.gbMontosContados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCinco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiez)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVeintiCinco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCincuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuinientos)).BeginInit();
            this.gbEnMesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalNiquel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.gbProcesamientoExterno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotNiquelPE)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(121, 108);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(255, 20);
            this.txtIdentificador.TabIndex = 29;
            this.txtIdentificador.TextChanged += new System.EventHandler(this.txtIdentificador_TextChanged);
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Location = new System.Drawing.Point(47, 111);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(68, 13);
            this.lblIdentificador.TabIndex = 2;
            this.lblIdentificador.Text = "Identificador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo Procesamiento:";
            // 
            // cboTipoProcesamiento
            // 
            this.cboTipoProcesamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProcesamiento.FormattingEnabled = true;
            this.cboTipoProcesamiento.Items.AddRange(new object[] {
            "Mesa Niquel",
            "Cajero Niquel",
            "Procesamiento Externo"});
            this.cboTipoProcesamiento.Location = new System.Drawing.Point(121, 71);
            this.cboTipoProcesamiento.Name = "cboTipoProcesamiento";
            this.cboTipoProcesamiento.Size = new System.Drawing.Size(255, 21);
            this.cboTipoProcesamiento.TabIndex = 28;
            this.cboTipoProcesamiento.SelectedIndexChanged += new System.EventHandler(this.cboTipoProcesamiento_SelectedIndexChanged);
            // 
            // gbEntregaNiquel
            // 
            this.gbEntregaNiquel.Controls.Add(this.nudTotalDeposito);
            this.gbEntregaNiquel.Controls.Add(this.nudTotalNiquelCaj);
            this.gbEntregaNiquel.Controls.Add(this.lblTotalNiquel);
            this.gbEntregaNiquel.Controls.Add(this.lblTotalDeposito);
            this.gbEntregaNiquel.Controls.Add(this.txtCliente);
            this.gbEntregaNiquel.Controls.Add(this.lblCliente);
            this.gbEntregaNiquel.Controls.Add(this.lblCuenta);
            this.gbEntregaNiquel.Controls.Add(this.txtCuenta);
            this.gbEntregaNiquel.Controls.Add(this.txtCodigoManifiesto);
            this.gbEntregaNiquel.Controls.Add(this.lblManifiesto);
            this.gbEntregaNiquel.Controls.Add(this.lblTula);
            this.gbEntregaNiquel.Controls.Add(this.txtCodigoTula);
            this.gbEntregaNiquel.Controls.Add(this.txtNumDeposito);
            this.gbEntregaNiquel.Controls.Add(this.lblNumDeposito);
            this.gbEntregaNiquel.Enabled = false;
            this.gbEntregaNiquel.Location = new System.Drawing.Point(13, 146);
            this.gbEntregaNiquel.Name = "gbEntregaNiquel";
            this.gbEntregaNiquel.Size = new System.Drawing.Size(654, 151);
            this.gbEntregaNiquel.TabIndex = 2;
            this.gbEntregaNiquel.TabStop = false;
            this.gbEntregaNiquel.Text = "Entrega Cajero Niquel";
            // 
            // nudTotalDeposito
            // 
            this.nudTotalDeposito.BackColor = System.Drawing.Color.PapayaWhip;
            this.nudTotalDeposito.Location = new System.Drawing.Point(75, 84);
            this.nudTotalDeposito.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudTotalDeposito.Name = "nudTotalDeposito";
            this.nudTotalDeposito.ReadOnly = true;
            this.nudTotalDeposito.Size = new System.Drawing.Size(210, 20);
            this.nudTotalDeposito.TabIndex = 50;
            this.nudTotalDeposito.ValueChanged += new System.EventHandler(this.nudTotalDeposito_ValueChanged);
            // 
            // nudTotalNiquelCaj
            // 
            this.nudTotalNiquelCaj.BackColor = System.Drawing.Color.PapayaWhip;
            this.nudTotalNiquelCaj.Location = new System.Drawing.Point(75, 118);
            this.nudTotalNiquelCaj.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudTotalNiquelCaj.Name = "nudTotalNiquelCaj";
            this.nudTotalNiquelCaj.ReadOnly = true;
            this.nudTotalNiquelCaj.Size = new System.Drawing.Size(210, 20);
            this.nudTotalNiquelCaj.TabIndex = 49;
            this.nudTotalNiquelCaj.ValueChanged += new System.EventHandler(this.nudTotalNiquelCaj_ValueChanged);
            this.nudTotalNiquelCaj.Leave += new System.EventHandler(this.nudTotalNiquelCaj_Leave);
            // 
            // lblTotalNiquel
            // 
            this.lblTotalNiquel.Location = new System.Drawing.Point(27, 106);
            this.lblTotalNiquel.Name = "lblTotalNiquel";
            this.lblTotalNiquel.Size = new System.Drawing.Size(42, 32);
            this.lblTotalNiquel.TabIndex = 34;
            this.lblTotalNiquel.Text = "Total Niquel:";
            // 
            // lblTotalDeposito
            // 
            this.lblTotalDeposito.Location = new System.Drawing.Point(16, 74);
            this.lblTotalDeposito.Name = "lblTotalDeposito";
            this.lblTotalDeposito.Size = new System.Drawing.Size(58, 36);
            this.lblTotalDeposito.TabIndex = 32;
            this.lblTotalDeposito.Text = "Total Depósito:";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCliente.Location = new System.Drawing.Point(75, 52);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(210, 20);
            this.txtCliente.TabIndex = 29;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(27, 55);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 28;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(356, 59);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(44, 13);
            this.lblCuenta.TabIndex = 30;
            this.lblCuenta.Text = "Cuenta:";
            // 
            // txtCuenta
            // 
            this.txtCuenta.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCuenta.Location = new System.Drawing.Point(403, 55);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.ReadOnly = true;
            this.txtCuenta.Size = new System.Drawing.Size(244, 20);
            this.txtCuenta.TabIndex = 31;
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(75, 19);
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.ReadOnly = true;
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(210, 20);
            this.txtCodigoManifiesto.TabIndex = 25;
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(11, 22);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManifiesto.TabIndex = 24;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // lblTula
            // 
            this.lblTula.AutoSize = true;
            this.lblTula.Location = new System.Drawing.Point(369, 26);
            this.lblTula.Name = "lblTula";
            this.lblTula.Size = new System.Drawing.Size(31, 13);
            this.lblTula.TabIndex = 26;
            this.lblTula.Text = "Tula:";
            // 
            // txtCodigoTula
            // 
            this.txtCodigoTula.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCodigoTula.Location = new System.Drawing.Point(403, 22);
            this.txtCodigoTula.Name = "txtCodigoTula";
            this.txtCodigoTula.ReadOnly = true;
            this.txtCodigoTula.Size = new System.Drawing.Size(244, 20);
            this.txtCodigoTula.TabIndex = 27;
            // 
            // txtNumDeposito
            // 
            this.txtNumDeposito.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtNumDeposito.Location = new System.Drawing.Point(404, 86);
            this.txtNumDeposito.Name = "txtNumDeposito";
            this.txtNumDeposito.ReadOnly = true;
            this.txtNumDeposito.Size = new System.Drawing.Size(244, 20);
            this.txtNumDeposito.TabIndex = 3;
            // 
            // lblNumDeposito
            // 
            this.lblNumDeposito.AutoSize = true;
            this.lblNumDeposito.Location = new System.Drawing.Point(321, 89);
            this.lblNumDeposito.Name = "lblNumDeposito";
            this.lblNumDeposito.Size = new System.Drawing.Size(80, 13);
            this.lblNumDeposito.TabIndex = 2;
            this.lblNumDeposito.Text = "Núm. Depósito:";
            // 
            // gbMontosContados
            // 
            this.gbMontosContados.Controls.Add(this.nudCinco);
            this.gbMontosContados.Controls.Add(this.nudDiez);
            this.gbMontosContados.Controls.Add(this.nudVeintiCinco);
            this.gbMontosContados.Controls.Add(this.nudCincuenta);
            this.gbMontosContados.Controls.Add(this.nudCien);
            this.gbMontosContados.Controls.Add(this.nudQuinientos);
            this.gbMontosContados.Controls.Add(this.lblQuinientos);
            this.gbMontosContados.Controls.Add(this.lblDiez);
            this.gbMontosContados.Controls.Add(this.lblCincuenta);
            this.gbMontosContados.Controls.Add(this.lblCinco);
            this.gbMontosContados.Controls.Add(this.lblCien);
            this.gbMontosContados.Controls.Add(this.lblVentiCinco);
            this.gbMontosContados.Enabled = false;
            this.gbMontosContados.Location = new System.Drawing.Point(14, 304);
            this.gbMontosContados.Name = "gbMontosContados";
            this.gbMontosContados.Size = new System.Drawing.Size(653, 120);
            this.gbMontosContados.TabIndex = 30;
            this.gbMontosContados.TabStop = false;
            this.gbMontosContados.Text = "Montos Contados";
            // 
            // nudCinco
            // 
            this.nudCinco.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudCinco.Location = new System.Drawing.Point(393, 86);
            this.nudCinco.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudCinco.Name = "nudCinco";
            this.nudCinco.Size = new System.Drawing.Size(252, 20);
            this.nudCinco.TabIndex = 50;
            this.nudCinco.ValueChanged += new System.EventHandler(this.nudCinco_ValueChanged);
            this.nudCinco.Click += new System.EventHandler(this.nudCinco_Click);
            this.nudCinco.Enter += new System.EventHandler(this.nudCinco_Enter);
            this.nudCinco.Leave += new System.EventHandler(this.nudCinco_Leave);
            // 
            // nudDiez
            // 
            this.nudDiez.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDiez.Location = new System.Drawing.Point(392, 59);
            this.nudDiez.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudDiez.Name = "nudDiez";
            this.nudDiez.Size = new System.Drawing.Size(253, 20);
            this.nudDiez.TabIndex = 49;
            this.nudDiez.ValueChanged += new System.EventHandler(this.nudDiez_ValueChanged);
            this.nudDiez.Click += new System.EventHandler(this.nudDiez_Click);
            this.nudDiez.Enter += new System.EventHandler(this.nudDiez_Enter);
            this.nudDiez.Leave += new System.EventHandler(this.nudDiez_Leave);
            // 
            // nudVeintiCinco
            // 
            this.nudVeintiCinco.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudVeintiCinco.Location = new System.Drawing.Point(393, 33);
            this.nudVeintiCinco.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudVeintiCinco.Name = "nudVeintiCinco";
            this.nudVeintiCinco.Size = new System.Drawing.Size(252, 20);
            this.nudVeintiCinco.TabIndex = 48;
            this.nudVeintiCinco.ValueChanged += new System.EventHandler(this.nudVeintiCinco_ValueChanged);
            this.nudVeintiCinco.Click += new System.EventHandler(this.nudVeintiCinco_Click);
            this.nudVeintiCinco.Enter += new System.EventHandler(this.nudVeintiCinco_Enter);
            this.nudVeintiCinco.Leave += new System.EventHandler(this.nudVeintiCinco_Leave);
            // 
            // nudCincuenta
            // 
            this.nudCincuenta.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudCincuenta.Location = new System.Drawing.Point(62, 86);
            this.nudCincuenta.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudCincuenta.Name = "nudCincuenta";
            this.nudCincuenta.Size = new System.Drawing.Size(254, 20);
            this.nudCincuenta.TabIndex = 47;
            this.nudCincuenta.ValueChanged += new System.EventHandler(this.nudCincuenta_ValueChanged);
            this.nudCincuenta.Click += new System.EventHandler(this.nudCincuenta_Click);
            this.nudCincuenta.Enter += new System.EventHandler(this.nudCincuenta_Enter);
            this.nudCincuenta.Leave += new System.EventHandler(this.nudCincuenta_Leave);
            // 
            // nudCien
            // 
            this.nudCien.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudCien.Location = new System.Drawing.Point(62, 59);
            this.nudCien.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudCien.Name = "nudCien";
            this.nudCien.Size = new System.Drawing.Size(254, 20);
            this.nudCien.TabIndex = 46;
            this.nudCien.ValueChanged += new System.EventHandler(this.nudCien_ValueChanged);
            this.nudCien.Click += new System.EventHandler(this.nudCien_Click);
            this.nudCien.Enter += new System.EventHandler(this.nudCien_Enter);
            this.nudCien.Leave += new System.EventHandler(this.nudCien_Leave);
            // 
            // nudQuinientos
            // 
            this.nudQuinientos.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudQuinientos.Location = new System.Drawing.Point(62, 34);
            this.nudQuinientos.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudQuinientos.Name = "nudQuinientos";
            this.nudQuinientos.Size = new System.Drawing.Size(254, 20);
            this.nudQuinientos.TabIndex = 45;
            this.nudQuinientos.ValueChanged += new System.EventHandler(this.nudQuinientos_ValueChanged);
            this.nudQuinientos.Click += new System.EventHandler(this.nudQuinientos_Click);
            this.nudQuinientos.Enter += new System.EventHandler(this.nudQuinientos_Enter);
            this.nudQuinientos.Leave += new System.EventHandler(this.nudQuinientos_Leave);
            // 
            // lblQuinientos
            // 
            this.lblQuinientos.AutoSize = true;
            this.lblQuinientos.Location = new System.Drawing.Point(8, 36);
            this.lblQuinientos.Name = "lblQuinientos";
            this.lblQuinientos.Size = new System.Drawing.Size(36, 13);
            this.lblQuinientos.TabIndex = 35;
            this.lblQuinientos.Text = "₡500:";
            // 
            // lblDiez
            // 
            this.lblDiez.AutoSize = true;
            this.lblDiez.Location = new System.Drawing.Point(356, 61);
            this.lblDiez.Name = "lblDiez";
            this.lblDiez.Size = new System.Drawing.Size(30, 13);
            this.lblDiez.TabIndex = 40;
            this.lblDiez.Text = "₡10:";
            // 
            // lblCincuenta
            // 
            this.lblCincuenta.AutoSize = true;
            this.lblCincuenta.Location = new System.Drawing.Point(8, 88);
            this.lblCincuenta.Name = "lblCincuenta";
            this.lblCincuenta.Size = new System.Drawing.Size(30, 13);
            this.lblCincuenta.TabIndex = 36;
            this.lblCincuenta.Text = "₡50:";
            // 
            // lblCinco
            // 
            this.lblCinco.AutoSize = true;
            this.lblCinco.Location = new System.Drawing.Point(356, 87);
            this.lblCinco.Name = "lblCinco";
            this.lblCinco.Size = new System.Drawing.Size(24, 13);
            this.lblCinco.TabIndex = 39;
            this.lblCinco.Text = "₡5:";
            // 
            // lblCien
            // 
            this.lblCien.AutoSize = true;
            this.lblCien.Location = new System.Drawing.Point(8, 62);
            this.lblCien.Name = "lblCien";
            this.lblCien.Size = new System.Drawing.Size(36, 13);
            this.lblCien.TabIndex = 37;
            this.lblCien.Text = "₡100:";
            // 
            // lblVentiCinco
            // 
            this.lblVentiCinco.AutoSize = true;
            this.lblVentiCinco.Location = new System.Drawing.Point(356, 35);
            this.lblVentiCinco.Name = "lblVentiCinco";
            this.lblVentiCinco.Size = new System.Drawing.Size(30, 13);
            this.lblVentiCinco.TabIndex = 38;
            this.lblVentiCinco.Text = "₡25:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Image = global::GUILayer.Properties.Resources.registro1;
            this.btnProcesar.Location = new System.Drawing.Point(237, 464);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(90, 40);
            this.btnProcesar.TabIndex = 51;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(337, 464);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.BackColor = System.Drawing.Color.AliceBlue;
            this.txtDiferencia.Enabled = false;
            this.txtDiferencia.Location = new System.Drawing.Point(449, 430);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.ReadOnly = true;
            this.txtDiferencia.Size = new System.Drawing.Size(210, 20);
            this.txtDiferencia.TabIndex = 36;
            this.txtDiferencia.TextChanged += new System.EventHandler(this.txtDiferencia_TextChanged);
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Location = new System.Drawing.Point(382, 433);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(58, 13);
            this.lblDiferencia.TabIndex = 35;
            this.lblDiferencia.Text = "Diferencia:";
            // 
            // txtMontoContado
            // 
            this.txtMontoContado.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMontoContado.Enabled = false;
            this.txtMontoContado.Location = new System.Drawing.Point(88, 430);
            this.txtMontoContado.Name = "txtMontoContado";
            this.txtMontoContado.ReadOnly = true;
            this.txtMontoContado.Size = new System.Drawing.Size(210, 20);
            this.txtMontoContado.TabIndex = 34;
            this.txtMontoContado.TextChanged += new System.EventHandler(this.txtMontoContado_TextChanged);
            // 
            // lblMontoContado
            // 
            this.lblMontoContado.AutoSize = true;
            this.lblMontoContado.Location = new System.Drawing.Point(4, 433);
            this.lblMontoContado.Name = "lblMontoContado";
            this.lblMontoContado.Size = new System.Drawing.Size(83, 13);
            this.lblMontoContado.TabIndex = 33;
            this.lblMontoContado.Text = "Monto Contado:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(417, 86);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 38);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbEnMesa
            // 
            this.gbEnMesa.Controls.Add(this.nudTotalNiquel);
            this.gbEnMesa.Controls.Add(this.dtpFecha);
            this.gbEnMesa.Controls.Add(this.lblTotalNiquelEM);
            this.gbEnMesa.Controls.Add(this.txtCajero);
            this.gbEnMesa.Controls.Add(this.lblCajero);
            this.gbEnMesa.Controls.Add(this.lblFecha);
            this.gbEnMesa.Enabled = false;
            this.gbEnMesa.Location = new System.Drawing.Point(13, 146);
            this.gbEnMesa.Name = "gbEnMesa";
            this.gbEnMesa.Size = new System.Drawing.Size(654, 152);
            this.gbEnMesa.TabIndex = 1;
            this.gbEnMesa.TabStop = false;
            this.gbEnMesa.Text = "En Mesa";
            // 
            // nudTotalNiquel
            // 
            this.nudTotalNiquel.BackColor = System.Drawing.Color.PapayaWhip;
            this.nudTotalNiquel.Enabled = false;
            this.nudTotalNiquel.Location = new System.Drawing.Point(90, 102);
            this.nudTotalNiquel.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudTotalNiquel.Name = "nudTotalNiquel";
            this.nudTotalNiquel.ReadOnly = true;
            this.nudTotalNiquel.Size = new System.Drawing.Size(254, 20);
            this.nudTotalNiquel.TabIndex = 46;
            this.nudTotalNiquel.ValueChanged += new System.EventHandler(this.nudTotalNiquel_ValueChanged);
            this.nudTotalNiquel.Leave += new System.EventHandler(this.nudTotalNiquel_Leave);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(90, 38);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(253, 20);
            this.dtpFecha.TabIndex = 32;
            // 
            // lblTotalNiquelEM
            // 
            this.lblTotalNiquelEM.Location = new System.Drawing.Point(14, 104);
            this.lblTotalNiquelEM.Name = "lblTotalNiquelEM";
            this.lblTotalNiquelEM.Size = new System.Drawing.Size(70, 14);
            this.lblTotalNiquelEM.TabIndex = 42;
            this.lblTotalNiquelEM.Text = "Total Niquel:";
            // 
            // txtCajero
            // 
            this.txtCajero.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCajero.Location = new System.Drawing.Point(91, 70);
            this.txtCajero.Name = "txtCajero";
            this.txtCajero.ReadOnly = true;
            this.txtCajero.Size = new System.Drawing.Size(253, 20);
            this.txtCajero.TabIndex = 39;
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(44, 74);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 38;
            this.lblCajero.Text = "Cajero:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(44, 44);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 36;
            this.lblFecha.Text = "Fecha:";
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // gbProcesamientoExterno
            // 
            this.gbProcesamientoExterno.Controls.Add(this.cboTransportadora);
            this.gbProcesamientoExterno.Controls.Add(this.lbltransportadora);
            this.gbProcesamientoExterno.Controls.Add(this.nudTotNiquelPE);
            this.gbProcesamientoExterno.Controls.Add(this.lblTotalNiquelPE);
            this.gbProcesamientoExterno.Enabled = false;
            this.gbProcesamientoExterno.Location = new System.Drawing.Point(13, 146);
            this.gbProcesamientoExterno.Name = "gbProcesamientoExterno";
            this.gbProcesamientoExterno.Size = new System.Drawing.Size(654, 151);
            this.gbProcesamientoExterno.TabIndex = 3;
            this.gbProcesamientoExterno.TabStop = false;
            this.gbProcesamientoExterno.Text = "Procesamiento Externo";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = false;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(100, 32);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(255, 21);
            this.cboTransportadora.TabIndex = 33;
            // 
            // lbltransportadora
            // 
            this.lbltransportadora.Location = new System.Drawing.Point(13, 35);
            this.lbltransportadora.Name = "lbltransportadora";
            this.lbltransportadora.Size = new System.Drawing.Size(90, 14);
            this.lbltransportadora.TabIndex = 49;
            this.lbltransportadora.Text = "Transportadora:";
            // 
            // nudTotNiquelPE
            // 
            this.nudTotNiquelPE.Location = new System.Drawing.Point(100, 66);
            this.nudTotNiquelPE.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudTotNiquelPE.Name = "nudTotNiquelPE";
            this.nudTotNiquelPE.Size = new System.Drawing.Size(254, 20);
            this.nudTotNiquelPE.TabIndex = 34;
            this.nudTotNiquelPE.ValueChanged += new System.EventHandler(this.nudTotNiquelPE_ValueChanged);
            this.nudTotNiquelPE.Leave += new System.EventHandler(this.nudTotNiquelPE_Leave);
            // 
            // lblTotalNiquelPE
            // 
            this.lblTotalNiquelPE.Location = new System.Drawing.Point(23, 67);
            this.lblTotalNiquelPE.Name = "lblTotalNiquelPE";
            this.lblTotalNiquelPE.Size = new System.Drawing.Size(70, 14);
            this.lblTotalNiquelPE.TabIndex = 47;
            this.lblTotalNiquelPE.Text = "Total Niquel:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 6);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(676, 60);
            this.pnlFondo.TabIndex = 40;
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
            // btnlimpiar
            // 
            this.btnlimpiar.FlatAppearance.BorderSize = 2;
            this.btnlimpiar.Image = global::GUILayer.Properties.Resources.borrar;
            this.btnlimpiar.Location = new System.Drawing.Point(528, 86);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(90, 38);
            this.btnlimpiar.TabIndex = 31;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // frmValidacionCajeroNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 513);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDiferencia);
            this.Controls.Add(this.lblDiferencia);
            this.Controls.Add(this.txtMontoContado);
            this.Controls.Add(this.lblMontoContado);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbMontosContados);
            this.Controls.Add(this.cboTipoProcesamiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdentificador);
            this.Controls.Add(this.lblIdentificador);
            this.Controls.Add(this.gbEnMesa);
            this.Controls.Add(this.gbEntregaNiquel);
            this.Controls.Add(this.gbProcesamientoExterno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmValidacionCajeroNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Validacion Cajero Niquel";
            this.Load += new System.EventHandler(this.frmValidacionCajeroNiquel_Load);
            this.gbEntregaNiquel.ResumeLayout(false);
            this.gbEntregaNiquel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalDeposito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalNiquelCaj)).EndInit();
            this.gbMontosContados.ResumeLayout(false);
            this.gbMontosContados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCinco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiez)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVeintiCinco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCincuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuinientos)).EndInit();
            this.gbEnMesa.ResumeLayout(false);
            this.gbEnMesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalNiquel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.gbProcesamientoExterno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTotNiquelPE)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoProcesamiento;
        private System.Windows.Forms.GroupBox gbEntregaNiquel;
        private System.Windows.Forms.TextBox txtNumDeposito;
        private System.Windows.Forms.Label lblNumDeposito;
        private System.Windows.Forms.Label lblTotalNiquel;
        private System.Windows.Forms.Label lblTotalDeposito;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.Label lblTula;
        private System.Windows.Forms.TextBox txtCodigoTula;
        private System.Windows.Forms.GroupBox gbMontosContados;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown nudCinco;
        private System.Windows.Forms.NumericUpDown nudDiez;
        private System.Windows.Forms.NumericUpDown nudVeintiCinco;
        private System.Windows.Forms.NumericUpDown nudCincuenta;
        private System.Windows.Forms.NumericUpDown nudCien;
        private System.Windows.Forms.NumericUpDown nudQuinientos;
        private System.Windows.Forms.Label lblQuinientos;
        private System.Windows.Forms.Label lblDiez;
        private System.Windows.Forms.Label lblCincuenta;
        private System.Windows.Forms.Label lblCinco;
        private System.Windows.Forms.Label lblCien;
        private System.Windows.Forms.Label lblVentiCinco;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.TextBox txtMontoContado;
        private System.Windows.Forms.Label lblMontoContado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbEnMesa;
        private System.Windows.Forms.Label lblTotalNiquelEM;
        private System.Windows.Forms.TextBox txtCajero;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.NumericUpDown nudTotalNiquel;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.GroupBox gbProcesamientoExterno;
        private System.Windows.Forms.Label lbltransportadora;
        private System.Windows.Forms.NumericUpDown nudTotNiquelPE;
        private System.Windows.Forms.Label lblTotalNiquelPE;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.NumericUpDown nudTotalDeposito;
        private System.Windows.Forms.NumericUpDown nudTotalNiquelCaj;
        private System.Windows.Forms.Button btnlimpiar;
    }
}