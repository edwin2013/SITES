namespace GUILayer
{
    partial class frmRegistroTulasNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroTulasNiquel));
            this.pnlComandos = new System.Windows.Forms.Panel();
            this.lblMenos = new System.Windows.Forms.Label();
            this.lblMas = new System.Windows.Forms.Label();
            this.lblPor = new System.Windows.Forms.Label();
            this.lblPunto = new System.Windows.Forms.Label();
            this.lblDiv = new System.Windows.Forms.Label();
            this.txtFuncion = new System.Windows.Forms.TextBox();
            this.lblFuncion = new System.Windows.Forms.Label();
            this.txtUltimaTula = new System.Windows.Forms.TextBox();
            this.lblUltimaTula = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtTula = new System.Windows.Forms.TextBox();
            this.lblReceptor = new System.Windows.Forms.Label();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblTula = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.txtReceptor = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTotalManifiestos = new System.Windows.Forms.Label();
            this.pnlComandos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlComandos
            // 
            this.pnlComandos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlComandos.BackColor = System.Drawing.Color.Transparent;
            this.pnlComandos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComandos.Controls.Add(this.lblMenos);
            this.pnlComandos.Controls.Add(this.lblMas);
            this.pnlComandos.Controls.Add(this.lblPor);
            this.pnlComandos.Controls.Add(this.lblPunto);
            this.pnlComandos.Controls.Add(this.lblDiv);
            this.pnlComandos.Location = new System.Drawing.Point(12, 51);
            this.pnlComandos.Name = "pnlComandos";
            this.pnlComandos.Size = new System.Drawing.Size(290, 152);
            this.pnlComandos.TabIndex = 17;
            // 
            // lblMenos
            // 
            this.lblMenos.Location = new System.Drawing.Point(15, 41);
            this.lblMenos.Name = "lblMenos";
            this.lblMenos.Size = new System.Drawing.Size(258, 23);
            this.lblMenos.TabIndex = 1;
            this.lblMenos.Text = "Menos(-) = Eliminar la última tula registrada";
            // 
            // lblMas
            // 
            this.lblMas.Location = new System.Drawing.Point(15, 18);
            this.lblMas.Name = "lblMas";
            this.lblMas.Size = new System.Drawing.Size(258, 23);
            this.lblMas.TabIndex = 0;
            this.lblMas.Text = "Más(+) = Reiniciar la lectura de la tula y el manifiesto";
            // 
            // lblPor
            // 
            this.lblPor.Location = new System.Drawing.Point(15, 110);
            this.lblPor.Name = "lblPor";
            this.lblPor.Size = new System.Drawing.Size(258, 23);
            this.lblPor.TabIndex = 4;
            this.lblPor.Text = "Multiplicar(*) = Cerrar esta ventana";
            // 
            // lblPunto
            // 
            this.lblPunto.Location = new System.Drawing.Point(15, 64);
            this.lblPunto.Name = "lblPunto";
            this.lblPunto.Size = new System.Drawing.Size(258, 23);
            this.lblPunto.TabIndex = 2;
            this.lblPunto.Text = "Punto(.) = Cambiar la función de las teclas numéricas";
            // 
            // lblDiv
            // 
            this.lblDiv.Location = new System.Drawing.Point(16, 87);
            this.lblDiv.Name = "lblDiv";
            this.lblDiv.Size = new System.Drawing.Size(258, 23);
            this.lblDiv.TabIndex = 3;
            this.lblDiv.Text = "Dividir(/) = Reutilizar el código del último manifiesto";
            // 
            // txtFuncion
            // 
            this.txtFuncion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFuncion.BackColor = System.Drawing.Color.Aqua;
            this.txtFuncion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFuncion.Location = new System.Drawing.Point(503, 25);
            this.txtFuncion.Name = "txtFuncion";
            this.txtFuncion.ReadOnly = true;
            this.txtFuncion.Size = new System.Drawing.Size(277, 20);
            this.txtFuncion.TabIndex = 19;
            this.txtFuncion.TabStop = false;
            this.txtFuncion.Text = "Cambio de Grupo";
            this.txtFuncion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFuncion
            // 
            this.lblFuncion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFuncion.AutoSize = true;
            this.lblFuncion.Location = new System.Drawing.Point(335, 28);
            this.lblFuncion.Name = "lblFuncion";
            this.lblFuncion.Size = new System.Drawing.Size(162, 13);
            this.lblFuncion.TabIndex = 18;
            this.lblFuncion.Text = "Funcion de la Teclas Numéricas:";
            // 
            // txtUltimaTula
            // 
            this.txtUltimaTula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUltimaTula.BackColor = System.Drawing.Color.White;
            this.txtUltimaTula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUltimaTula.Location = new System.Drawing.Point(503, 155);
            this.txtUltimaTula.Name = "txtUltimaTula";
            this.txtUltimaTula.ReadOnly = true;
            this.txtUltimaTula.Size = new System.Drawing.Size(277, 20);
            this.txtUltimaTula.TabIndex = 29;
            this.txtUltimaTula.TabStop = false;
            this.txtUltimaTula.Text = "Ninguna";
            this.txtUltimaTula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUltimaTula
            // 
            this.lblUltimaTula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimaTula.AutoSize = true;
            this.lblUltimaTula.Location = new System.Drawing.Point(380, 158);
            this.lblUltimaTula.Name = "lblUltimaTula";
            this.lblUltimaTula.Size = new System.Drawing.Size(117, 13);
            this.lblUltimaTula.TabIndex = 28;
            this.lblUltimaTula.Text = "Última Tula Registrada:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(377, 80);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(120, 13);
            this.lblEmpresa.TabIndex = 22;
            this.lblEmpresa.Text = "Empresa de Transporte:";
            // 
            // txtTula
            // 
            this.txtTula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTula.BackColor = System.Drawing.Color.White;
            this.txtTula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTula.Location = new System.Drawing.Point(503, 129);
            this.txtTula.Name = "txtTula";
            this.txtTula.ReadOnly = true;
            this.txtTula.Size = new System.Drawing.Size(277, 20);
            this.txtTula.TabIndex = 27;
            this.txtTula.TabStop = false;
            this.txtTula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReceptor
            // 
            this.lblReceptor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceptor.AutoSize = true;
            this.lblReceptor.Location = new System.Drawing.Point(443, 54);
            this.lblReceptor.Name = "lblReceptor";
            this.lblReceptor.Size = new System.Drawing.Size(54, 13);
            this.lblReceptor.TabIndex = 20;
            this.lblReceptor.Text = "Receptor:";
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManifiesto.BackColor = System.Drawing.Color.LightBlue;
            this.txtManifiesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManifiesto.Location = new System.Drawing.Point(503, 103);
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.ReadOnly = true;
            this.txtManifiesto.Size = new System.Drawing.Size(277, 20);
            this.txtManifiesto.TabIndex = 10;
            this.txtManifiesto.TabStop = false;
            this.txtManifiesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpresa.BackColor = System.Drawing.Color.White;
            this.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpresa.Location = new System.Drawing.Point(503, 77);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(277, 20);
            this.txtEmpresa.TabIndex = 23;
            this.txtEmpresa.TabStop = false;
            this.txtEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTula
            // 
            this.lblTula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTula.AutoSize = true;
            this.lblTula.Location = new System.Drawing.Point(466, 132);
            this.lblTula.Name = "lblTula";
            this.lblTula.Size = new System.Drawing.Size(31, 13);
            this.lblTula.TabIndex = 26;
            this.lblTula.Text = "Tula:";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.BackColor = System.Drawing.Color.White;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensaje.Location = new System.Drawing.Point(503, 183);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(277, 20);
            this.txtMensaje.TabIndex = 31;
            this.txtMensaje.TabStop = false;
            this.txtMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(439, 106);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManifiesto.TabIndex = 24;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // txtReceptor
            // 
            this.txtReceptor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceptor.BackColor = System.Drawing.Color.White;
            this.txtReceptor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceptor.Location = new System.Drawing.Point(503, 51);
            this.txtReceptor.Name = "txtReceptor";
            this.txtReceptor.ReadOnly = true;
            this.txtReceptor.Size = new System.Drawing.Size(277, 20);
            this.txtReceptor.TabIndex = 21;
            this.txtReceptor.TabStop = false;
            this.txtReceptor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(447, 186);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(50, 13);
            this.lblMensaje.TabIndex = 30;
            this.lblMensaje.Text = "Mensaje:";
            // 
            // lblTotalManifiestos
            // 
            this.lblTotalManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalManifiestos.AutoSize = true;
            this.lblTotalManifiestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalManifiestos.Location = new System.Drawing.Point(27, 16);
            this.lblTotalManifiestos.Name = "lblTotalManifiestos";
            this.lblTotalManifiestos.Size = new System.Drawing.Size(253, 25);
            this.lblTotalManifiestos.TabIndex = 32;
            this.lblTotalManifiestos.Text = "Total de Manifiestos: 0";
            // 
            // frmRegistroTulasNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(796, 215);
            this.Controls.Add(this.lblTotalManifiestos);
            this.Controls.Add(this.pnlComandos);
            this.Controls.Add(this.txtFuncion);
            this.Controls.Add(this.lblFuncion);
            this.Controls.Add(this.txtUltimaTula);
            this.Controls.Add(this.lblUltimaTula);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.txtTula);
            this.Controls.Add(this.lblReceptor);
            this.Controls.Add(this.txtManifiesto);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.lblTula);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.lblManifiesto);
            this.Controls.Add(this.txtReceptor);
            this.Controls.Add(this.lblMensaje);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistroTulasNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Tulas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistroTulas_FormClosing);
            this.Load += new System.EventHandler(this.frmRegistroTulasNiquel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegistroTulas_KeyDown);
            this.pnlComandos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlComandos;
        private System.Windows.Forms.Label lblMenos;
        private System.Windows.Forms.Label lblMas;
        private System.Windows.Forms.Label lblPor;
        private System.Windows.Forms.Label lblPunto;
        private System.Windows.Forms.Label lblDiv;
        private System.Windows.Forms.TextBox txtFuncion;
        private System.Windows.Forms.Label lblFuncion;
        private System.Windows.Forms.TextBox txtUltimaTula;
        private System.Windows.Forms.Label lblUltimaTula;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtTula;
        private System.Windows.Forms.Label lblReceptor;
        private System.Windows.Forms.TextBox txtManifiesto;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblTula;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.TextBox txtReceptor;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTotalManifiestos;

    }
}