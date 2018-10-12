namespace GUILayer.Formularios.Facturacion
{
    partial class frmAsignacionInconsistenciasFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignacionInconsistenciasFacturacion));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.txtPuntoVenta = new System.Windows.Forms.TextBox();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.cboInconsistencia = new GUILayer.ComboBoxBusqueda();
            this.lblInconsistencia = new System.Windows.Forms.Label();
            this.btnDescartar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblPuntoVenta);
            this.gbDatos.Controls.Add(this.lblTransportadora);
            this.gbDatos.Controls.Add(this.txtPuntoVenta);
            this.gbDatos.Controls.Add(this.txtTransportadora);
            this.gbDatos.Controls.Add(this.txtObservaciones);
            this.gbDatos.Controls.Add(this.lblObservaciones);
            this.gbDatos.Controls.Add(this.cboInconsistencia);
            this.gbDatos.Controls.Add(this.lblInconsistencia);
            this.gbDatos.Location = new System.Drawing.Point(53, 77);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(489, 269);
            this.gbDatos.TabIndex = 6;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Inconsistencia";
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(23, 101);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(81, 13);
            this.lblPuntoVenta.TabIndex = 9;
            this.lblPuntoVenta.Text = "Punto de Venta";
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(23, 54);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 8;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // txtPuntoVenta
            // 
            this.txtPuntoVenta.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtPuntoVenta.Location = new System.Drawing.Point(125, 94);
            this.txtPuntoVenta.Name = "txtPuntoVenta";
            this.txtPuntoVenta.ReadOnly = true;
            this.txtPuntoVenta.Size = new System.Drawing.Size(302, 20);
            this.txtPuntoVenta.TabIndex = 7;
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtTransportadora.Location = new System.Drawing.Point(125, 51);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(302, 20);
            this.txtTransportadora.TabIndex = 6;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(125, 179);
            this.txtObservaciones.MaxLength = 40;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(302, 56);
            this.txtObservaciones.TabIndex = 5;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(23, 182);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(81, 13);
            this.lblObservaciones.TabIndex = 4;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // cboInconsistencia
            // 
            this.cboInconsistencia.Busqueda = true;
            this.cboInconsistencia.FormattingEnabled = true;
            this.cboInconsistencia.ListaMostrada = null;
            this.cboInconsistencia.Location = new System.Drawing.Point(125, 137);
            this.cboInconsistencia.Name = "cboInconsistencia";
            this.cboInconsistencia.Size = new System.Drawing.Size(302, 21);
            this.cboInconsistencia.TabIndex = 3;
            // 
            // lblInconsistencia
            // 
            this.lblInconsistencia.AutoSize = true;
            this.lblInconsistencia.Location = new System.Drawing.Point(23, 140);
            this.lblInconsistencia.Name = "lblInconsistencia";
            this.lblInconsistencia.Size = new System.Drawing.Size(78, 13);
            this.lblInconsistencia.TabIndex = 2;
            this.lblInconsistencia.Text = "Inconsistencia:";
            // 
            // btnDescartar
            // 
            this.btnDescartar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDescartar.FlatAppearance.BorderSize = 2;
            this.btnDescartar.Image = global::GUILayer.Properties.Resources.cancelar1;
            this.btnDescartar.Location = new System.Drawing.Point(380, 365);
            this.btnDescartar.Name = "btnDescartar";
            this.btnDescartar.Size = new System.Drawing.Size(100, 40);
            this.btnDescartar.TabIndex = 8;
            this.btnDescartar.Text = "Descartar";
            this.btnDescartar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescartar.UseVisualStyleBackColor = false;
            this.btnDescartar.Click += new System.EventHandler(this.btnDescartar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(486, 365);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnValidar.FlatAppearance.BorderSize = 2;
            this.btnValidar.Image = global::GUILayer.Properties.Resources.aceptar1;
            this.btnValidar.Location = new System.Drawing.Point(284, 365);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(90, 40);
            this.btnValidar.TabIndex = 10;
            this.btnValidar.Text = "Validar";
            this.btnValidar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(588, 60);
            this.pnlFondo.TabIndex = 11;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmAsignacionInconsistenciasFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 417);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnDescartar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAsignacionInconsistenciasFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Inconsistencias";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private ComboBoxBusqueda cboInconsistencia;
        private System.Windows.Forms.Label lblInconsistencia;
        private System.Windows.Forms.Button btnDescartar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtPuntoVenta;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}