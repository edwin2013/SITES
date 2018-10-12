namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmActualizarRegistroDenominacionesNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizarRegistroDenominacionesNiquel));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbMontosContados = new System.Windows.Forms.GroupBox();
            this.txtMontoContado = new System.Windows.Forms.TextBox();
            this.lblMontoContado = new System.Windows.Forms.Label();
            this.nud5 = new System.Windows.Forms.NumericUpDown();
            this.nud10 = new System.Windows.Forms.NumericUpDown();
            this.nud25 = new System.Windows.Forms.NumericUpDown();
            this.nud50 = new System.Windows.Forms.NumericUpDown();
            this.nud100 = new System.Windows.Forms.NumericUpDown();
            this.nud500 = new System.Windows.Forms.NumericUpDown();
            this.lblQuinientos = new System.Windows.Forms.Label();
            this.lblDiez = new System.Windows.Forms.Label();
            this.lblCincuenta = new System.Windows.Forms.Label();
            this.lblCinco = new System.Windows.Forms.Label();
            this.lblCien = new System.Windows.Forms.Label();
            this.lblVentiCinco = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbMontosContados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud500)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(9, 7);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(774, 60);
            this.pnlFondo.TabIndex = 41;
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
            // gbMontosContados
            // 
            this.gbMontosContados.Controls.Add(this.txtMontoContado);
            this.gbMontosContados.Controls.Add(this.lblMontoContado);
            this.gbMontosContados.Controls.Add(this.nud5);
            this.gbMontosContados.Controls.Add(this.nud10);
            this.gbMontosContados.Controls.Add(this.nud25);
            this.gbMontosContados.Controls.Add(this.nud50);
            this.gbMontosContados.Controls.Add(this.nud100);
            this.gbMontosContados.Controls.Add(this.nud500);
            this.gbMontosContados.Controls.Add(this.lblQuinientos);
            this.gbMontosContados.Controls.Add(this.lblDiez);
            this.gbMontosContados.Controls.Add(this.lblCincuenta);
            this.gbMontosContados.Controls.Add(this.lblCinco);
            this.gbMontosContados.Controls.Add(this.lblCien);
            this.gbMontosContados.Controls.Add(this.lblVentiCinco);
            this.gbMontosContados.Location = new System.Drawing.Point(77, 73);
            this.gbMontosContados.Name = "gbMontosContados";
            this.gbMontosContados.Size = new System.Drawing.Size(653, 156);
            this.gbMontosContados.TabIndex = 42;
            this.gbMontosContados.TabStop = false;
            this.gbMontosContados.Text = "Monto Contado";
            // 
            // txtMontoContado
            // 
            this.txtMontoContado.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMontoContado.Enabled = false;
            this.txtMontoContado.Location = new System.Drawing.Point(297, 123);
            this.txtMontoContado.Name = "txtMontoContado";
            this.txtMontoContado.ReadOnly = true;
            this.txtMontoContado.Size = new System.Drawing.Size(210, 20);
            this.txtMontoContado.TabIndex = 48;
            // 
            // lblMontoContado
            // 
            this.lblMontoContado.AutoSize = true;
            this.lblMontoContado.Location = new System.Drawing.Point(213, 126);
            this.lblMontoContado.Name = "lblMontoContado";
            this.lblMontoContado.Size = new System.Drawing.Size(83, 13);
            this.lblMontoContado.TabIndex = 47;
            this.lblMontoContado.Text = "Monto Contado:";
            // 
            // nud5
            // 
            this.nud5.Location = new System.Drawing.Point(393, 86);
            this.nud5.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nud5.Name = "nud5";
            this.nud5.Size = new System.Drawing.Size(252, 20);
            this.nud5.TabIndex = 41;
            this.nud5.Leave += new System.EventHandler(this.nud5_Leave);
            // 
            // nud10
            // 
            this.nud10.Location = new System.Drawing.Point(392, 59);
            this.nud10.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nud10.Name = "nud10";
            this.nud10.Size = new System.Drawing.Size(253, 20);
            this.nud10.TabIndex = 43;
            this.nud10.Leave += new System.EventHandler(this.nud10_Leave);
            // 
            // nud25
            // 
            this.nud25.Location = new System.Drawing.Point(393, 33);
            this.nud25.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nud25.Name = "nud25";
            this.nud25.Size = new System.Drawing.Size(252, 20);
            this.nud25.TabIndex = 42;
            this.nud25.Leave += new System.EventHandler(this.nud25_Leave);
            // 
            // nud50
            // 
            this.nud50.Location = new System.Drawing.Point(62, 86);
            this.nud50.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nud50.Name = "nud50";
            this.nud50.Size = new System.Drawing.Size(254, 20);
            this.nud50.TabIndex = 44;
            this.nud50.Leave += new System.EventHandler(this.nud50_Leave);
            // 
            // nud100
            // 
            this.nud100.Location = new System.Drawing.Point(62, 59);
            this.nud100.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nud100.Name = "nud100";
            this.nud100.Size = new System.Drawing.Size(254, 20);
            this.nud100.TabIndex = 46;
            this.nud100.Leave += new System.EventHandler(this.nud100_Leave);
            // 
            // nud500
            // 
            this.nud500.Location = new System.Drawing.Point(62, 34);
            this.nud500.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nud500.Name = "nud500";
            this.nud500.Size = new System.Drawing.Size(254, 20);
            this.nud500.TabIndex = 45;
            this.nud500.Leave += new System.EventHandler(this.nud500_Leave);
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
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(450, 235);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 44;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::GUILayer.Properties.Resources.registro;
            this.btnProcesar.Location = new System.Drawing.Point(247, 235);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(90, 40);
            this.btnProcesar.TabIndex = 43;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // frmActualizarRegistroDenominacionesNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 287);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbMontosContados);
            this.MaximizeBox = false;
            this.Name = "frmActualizarRegistroDenominacionesNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Registro de Denominaciones de Niquel";
            this.Load += new System.EventHandler(this.frmActualizarRegistroDenominacionesNiquel_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbMontosContados.ResumeLayout(false);
            this.gbMontosContados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud500)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbMontosContados;
        private System.Windows.Forms.NumericUpDown nud5;
        private System.Windows.Forms.NumericUpDown nud10;
        private System.Windows.Forms.NumericUpDown nud25;
        private System.Windows.Forms.NumericUpDown nud50;
        private System.Windows.Forms.NumericUpDown nud100;
        private System.Windows.Forms.NumericUpDown nud500;
        private System.Windows.Forms.Label lblQuinientos;
        private System.Windows.Forms.Label lblDiez;
        private System.Windows.Forms.Label lblCincuenta;
        private System.Windows.Forms.Label lblCinco;
        private System.Windows.Forms.Label lblCien;
        private System.Windows.Forms.Label lblVentiCinco;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.TextBox txtMontoContado;
        private System.Windows.Forms.Label lblMontoContado;
    }
}