namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmIngresoCompraVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoCompraVenta));
            this.txtTipoCambioVenta = new System.Windows.Forms.TextBox();
            this.lblTipoCambioVenta = new System.Windows.Forms.Label();
            this.txtTipoCambioCompra = new System.Windows.Forms.TextBox();
            this.lblTipoCambioCompra = new System.Windows.Forms.Label();
            this.lblTipoCambio = new System.Windows.Forms.Label();
            this.rdbCompra = new System.Windows.Forms.RadioButton();
            this.rdbVenta = new System.Windows.Forms.RadioButton();
            this.lblMontoTipoCambio = new System.Windows.Forms.Label();
            this.nudMontoBillete = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontoCambio = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.nudMontoNiquel = new System.Windows.Forms.NumericUpDown();
            this.lblmontoniquel = new System.Windows.Forms.Label();
            this.lblMontoTransaccion = new System.Windows.Forms.Label();
            this.txtMontoTransaccion = new System.Windows.Forms.TextBox();
            this.rdbcompraeur = new System.Windows.Forms.RadioButton();
            this.rdbventaeur = new System.Windows.Forms.RadioButton();
            this.txtTipoCambioVentaEur = new System.Windows.Forms.TextBox();
            this.lblTipoCambioVentaEur = new System.Windows.Forms.Label();
            this.txtTipoCambioCompraEur = new System.Windows.Forms.TextBox();
            this.lblTipoCambioCompraEur = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoBillete)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoNiquel)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTipoCambioVenta
            // 
            this.txtTipoCambioVenta.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTipoCambioVenta.Location = new System.Drawing.Point(416, 74);
            this.txtTipoCambioVenta.Name = "txtTipoCambioVenta";
            this.txtTipoCambioVenta.ReadOnly = true;
            this.txtTipoCambioVenta.Size = new System.Drawing.Size(130, 20);
            this.txtTipoCambioVenta.TabIndex = 9;
            // 
            // lblTipoCambioVenta
            // 
            this.lblTipoCambioVenta.AutoSize = true;
            this.lblTipoCambioVenta.Location = new System.Drawing.Point(287, 77);
            this.lblTipoCambioVenta.Name = "lblTipoCambioVenta";
            this.lblTipoCambioVenta.Size = new System.Drawing.Size(130, 13);
            this.lblTipoCambioVenta.TabIndex = 8;
            this.lblTipoCambioVenta.Text = "Tipo de Cambio Venta ($):";
            // 
            // txtTipoCambioCompra
            // 
            this.txtTipoCambioCompra.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTipoCambioCompra.Location = new System.Drawing.Point(145, 74);
            this.txtTipoCambioCompra.Name = "txtTipoCambioCompra";
            this.txtTipoCambioCompra.ReadOnly = true;
            this.txtTipoCambioCompra.Size = new System.Drawing.Size(130, 20);
            this.txtTipoCambioCompra.TabIndex = 7;
            // 
            // lblTipoCambioCompra
            // 
            this.lblTipoCambioCompra.AutoSize = true;
            this.lblTipoCambioCompra.Location = new System.Drawing.Point(6, 77);
            this.lblTipoCambioCompra.Name = "lblTipoCambioCompra";
            this.lblTipoCambioCompra.Size = new System.Drawing.Size(138, 13);
            this.lblTipoCambioCompra.TabIndex = 6;
            this.lblTipoCambioCompra.Text = "Tipo de Cambio Compra ($):";
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.AutoSize = true;
            this.lblTipoCambio.Location = new System.Drawing.Point(10, 135);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(129, 13);
            this.lblTipoCambio.TabIndex = 10;
            this.lblTipoCambio.Text = "Tipo de Cambio a realizar:";
            // 
            // rdbCompra
            // 
            this.rdbCompra.AutoSize = true;
            this.rdbCompra.Checked = true;
            this.rdbCompra.Location = new System.Drawing.Point(169, 135);
            this.rdbCompra.Name = "rdbCompra";
            this.rdbCompra.Size = new System.Drawing.Size(70, 17);
            this.rdbCompra.TabIndex = 11;
            this.rdbCompra.TabStop = true;
            this.rdbCompra.Text = "Compra $";
            this.rdbCompra.UseVisualStyleBackColor = true;
            this.rdbCompra.CheckedChanged += new System.EventHandler(this.rdbCompra_CheckedChanged);
            // 
            // rdbVenta
            // 
            this.rdbVenta.AutoSize = true;
            this.rdbVenta.Location = new System.Drawing.Point(256, 135);
            this.rdbVenta.Name = "rdbVenta";
            this.rdbVenta.Size = new System.Drawing.Size(62, 17);
            this.rdbVenta.TabIndex = 12;
            this.rdbVenta.Text = "Venta $";
            this.rdbVenta.UseVisualStyleBackColor = true;
            this.rdbVenta.CheckedChanged += new System.EventHandler(this.rdbVenta_CheckedChanged);
            // 
            // lblMontoTipoCambio
            // 
            this.lblMontoTipoCambio.AutoSize = true;
            this.lblMontoTipoCambio.Location = new System.Drawing.Point(58, 165);
            this.lblMontoTipoCambio.Name = "lblMontoTipoCambio";
            this.lblMontoTipoCambio.Size = new System.Drawing.Size(143, 13);
            this.lblMontoTipoCambio.TabIndex = 13;
            this.lblMontoTipoCambio.Text = "Monto transacción en billete:";
            // 
            // nudMontoBillete
            // 
            this.nudMontoBillete.Location = new System.Drawing.Point(207, 163);
            this.nudMontoBillete.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMontoBillete.Name = "nudMontoBillete";
            this.nudMontoBillete.Size = new System.Drawing.Size(339, 20);
            this.nudMontoBillete.TabIndex = 20;
            this.nudMontoBillete.ValueChanged += new System.EventHandler(this.nudMonto_ValueChanged);
            this.nudMontoBillete.Click += new System.EventHandler(this.nudMontoBillete_Click);
            this.nudMontoBillete.Enter += new System.EventHandler(this.nudMontoBillete_Enter);
            this.nudMontoBillete.Leave += new System.EventHandler(this.nudMontoBillete_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Monto en moneda tipo de cambio:";
            // 
            // txtMontoCambio
            // 
            this.txtMontoCambio.BackColor = System.Drawing.Color.Honeydew;
            this.txtMontoCambio.Location = new System.Drawing.Point(207, 239);
            this.txtMontoCambio.Name = "txtMontoCambio";
            this.txtMontoCambio.ReadOnly = true;
            this.txtMontoCambio.Size = new System.Drawing.Size(339, 20);
            this.txtMontoCambio.TabIndex = 22;
            this.txtMontoCambio.TextChanged += new System.EventHandler(this.txtMontoCambio_TextChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(290, 272);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(91, 40);
            this.btnVolver.TabIndex = 26;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatAppearance.BorderSize = 2;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.Location = new System.Drawing.Point(175, 272);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(91, 38);
            this.btnConfirmar.TabIndex = 25;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(3, 5);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(554, 60);
            this.pnlFondo.TabIndex = 27;
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
            // nudMontoNiquel
            // 
            this.nudMontoNiquel.Enabled = false;
            this.nudMontoNiquel.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMontoNiquel.Location = new System.Drawing.Point(207, 189);
            this.nudMontoNiquel.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMontoNiquel.Name = "nudMontoNiquel";
            this.nudMontoNiquel.Size = new System.Drawing.Size(339, 20);
            this.nudMontoNiquel.TabIndex = 29;
            this.nudMontoNiquel.ValueChanged += new System.EventHandler(this.nudMontoNiquel_ValueChanged);
            this.nudMontoNiquel.Click += new System.EventHandler(this.nudMontoNiquel_Click);
            this.nudMontoNiquel.Enter += new System.EventHandler(this.nudMontoNiquel_Enter);
            // 
            // lblmontoniquel
            // 
            this.lblmontoniquel.AutoSize = true;
            this.lblmontoniquel.Location = new System.Drawing.Point(58, 191);
            this.lblmontoniquel.Name = "lblmontoniquel";
            this.lblmontoniquel.Size = new System.Drawing.Size(144, 13);
            this.lblmontoniquel.TabIndex = 28;
            this.lblmontoniquel.Text = "Monto transacción en niquel:";
            // 
            // lblMontoTransaccion
            // 
            this.lblMontoTransaccion.AutoSize = true;
            this.lblMontoTransaccion.Location = new System.Drawing.Point(80, 216);
            this.lblMontoTransaccion.Name = "lblMontoTransaccion";
            this.lblMontoTransaccion.Size = new System.Drawing.Size(121, 13);
            this.lblMontoTransaccion.TabIndex = 30;
            this.lblMontoTransaccion.Text = "Monto transacción total:";
            // 
            // txtMontoTransaccion
            // 
            this.txtMontoTransaccion.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtMontoTransaccion.Location = new System.Drawing.Point(207, 213);
            this.txtMontoTransaccion.Name = "txtMontoTransaccion";
            this.txtMontoTransaccion.ReadOnly = true;
            this.txtMontoTransaccion.Size = new System.Drawing.Size(339, 20);
            this.txtMontoTransaccion.TabIndex = 31;
            this.txtMontoTransaccion.TextChanged += new System.EventHandler(this.txtMontoTransaccion_TextChanged);
            // 
            // rdbcompraeur
            // 
            this.rdbcompraeur.AutoSize = true;
            this.rdbcompraeur.Location = new System.Drawing.Point(341, 135);
            this.rdbcompraeur.Name = "rdbcompraeur";
            this.rdbcompraeur.Size = new System.Drawing.Size(70, 17);
            this.rdbcompraeur.TabIndex = 32;
            this.rdbcompraeur.Text = "Compra €";
            this.rdbcompraeur.UseVisualStyleBackColor = true;
            this.rdbcompraeur.CheckedChanged += new System.EventHandler(this.rdbcompraeur_CheckedChanged);
            // 
            // rdbventaeur
            // 
            this.rdbventaeur.AutoSize = true;
            this.rdbventaeur.Location = new System.Drawing.Point(437, 135);
            this.rdbventaeur.Name = "rdbventaeur";
            this.rdbventaeur.Size = new System.Drawing.Size(62, 17);
            this.rdbventaeur.TabIndex = 33;
            this.rdbventaeur.Text = "Venta €";
            this.rdbventaeur.UseVisualStyleBackColor = true;
            this.rdbventaeur.CheckedChanged += new System.EventHandler(this.rdbventaeur_CheckedChanged);
            // 
            // txtTipoCambioVentaEur
            // 
            this.txtTipoCambioVentaEur.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTipoCambioVentaEur.Location = new System.Drawing.Point(416, 100);
            this.txtTipoCambioVentaEur.Name = "txtTipoCambioVentaEur";
            this.txtTipoCambioVentaEur.ReadOnly = true;
            this.txtTipoCambioVentaEur.Size = new System.Drawing.Size(130, 20);
            this.txtTipoCambioVentaEur.TabIndex = 37;
            // 
            // lblTipoCambioVentaEur
            // 
            this.lblTipoCambioVentaEur.AutoSize = true;
            this.lblTipoCambioVentaEur.Location = new System.Drawing.Point(287, 103);
            this.lblTipoCambioVentaEur.Name = "lblTipoCambioVentaEur";
            this.lblTipoCambioVentaEur.Size = new System.Drawing.Size(130, 13);
            this.lblTipoCambioVentaEur.TabIndex = 36;
            this.lblTipoCambioVentaEur.Text = "Tipo de Cambio Venta (€):";
            // 
            // txtTipoCambioCompraEur
            // 
            this.txtTipoCambioCompraEur.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTipoCambioCompraEur.Location = new System.Drawing.Point(145, 100);
            this.txtTipoCambioCompraEur.Name = "txtTipoCambioCompraEur";
            this.txtTipoCambioCompraEur.ReadOnly = true;
            this.txtTipoCambioCompraEur.Size = new System.Drawing.Size(130, 20);
            this.txtTipoCambioCompraEur.TabIndex = 35;
            // 
            // lblTipoCambioCompraEur
            // 
            this.lblTipoCambioCompraEur.AutoSize = true;
            this.lblTipoCambioCompraEur.Location = new System.Drawing.Point(6, 103);
            this.lblTipoCambioCompraEur.Name = "lblTipoCambioCompraEur";
            this.lblTipoCambioCompraEur.Size = new System.Drawing.Size(138, 13);
            this.lblTipoCambioCompraEur.TabIndex = 34;
            this.lblTipoCambioCompraEur.Text = "Tipo de Cambio Compra (€):";
            // 
            // frmIngresoCompraVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 317);
            this.Controls.Add(this.txtTipoCambioVentaEur);
            this.Controls.Add(this.lblTipoCambioVentaEur);
            this.Controls.Add(this.txtTipoCambioCompraEur);
            this.Controls.Add(this.lblTipoCambioCompraEur);
            this.Controls.Add(this.rdbventaeur);
            this.Controls.Add(this.rdbcompraeur);
            this.Controls.Add(this.txtMontoTransaccion);
            this.Controls.Add(this.lblMontoTransaccion);
            this.Controls.Add(this.nudMontoNiquel);
            this.Controls.Add(this.lblmontoniquel);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtMontoCambio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMontoBillete);
            this.Controls.Add(this.lblMontoTipoCambio);
            this.Controls.Add(this.rdbVenta);
            this.Controls.Add(this.rdbCompra);
            this.Controls.Add(this.lblTipoCambio);
            this.Controls.Add(this.txtTipoCambioVenta);
            this.Controls.Add(this.lblTipoCambioVenta);
            this.Controls.Add(this.txtTipoCambioCompra);
            this.Controls.Add(this.lblTipoCambioCompra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmIngresoCompraVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesamiento de Bajo Volumen - Ingreso de Compra/Venta";
            this.Load += new System.EventHandler(this.frmIngresoCompraVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoBillete)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoNiquel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTipoCambioVenta;
        private System.Windows.Forms.Label lblTipoCambioVenta;
        private System.Windows.Forms.TextBox txtTipoCambioCompra;
        private System.Windows.Forms.Label lblTipoCambioCompra;
        private System.Windows.Forms.Label lblTipoCambio;
        private System.Windows.Forms.RadioButton rdbCompra;
        private System.Windows.Forms.RadioButton rdbVenta;
        private System.Windows.Forms.Label lblMontoTipoCambio;
        private System.Windows.Forms.NumericUpDown nudMontoBillete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMontoCambio;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.NumericUpDown nudMontoNiquel;
        private System.Windows.Forms.Label lblmontoniquel;
        private System.Windows.Forms.TextBox txtMontoTransaccion;
        private System.Windows.Forms.Label lblMontoTransaccion;
        private System.Windows.Forms.RadioButton rdbventaeur;
        private System.Windows.Forms.RadioButton rdbcompraeur;
        private System.Windows.Forms.TextBox txtTipoCambioVentaEur;
        private System.Windows.Forms.Label lblTipoCambioVentaEur;
        private System.Windows.Forms.TextBox txtTipoCambioCompraEur;
        private System.Windows.Forms.Label lblTipoCambioCompraEur;
    }
}