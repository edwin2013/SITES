namespace GUILayer
{
    partial class frmReporteCierreCoordinador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteCierreCoordinador));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.rbImpresionDigitador = new System.Windows.Forms.RadioButton();
            this.rbImpresionCajero = new System.Windows.Forms.RadioButton();
            this.cboCoordinador = new GUILayer.ComboBoxBusqueda();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCoordinador = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(355, 43);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(807, 48);
            this.pnlFondo.TabIndex = 0;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.rbImpresionDigitador);
            this.gbDatos.Controls.Add(this.rbImpresionCajero);
            this.gbDatos.Controls.Add(this.cboCoordinador);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.lblCoordinador);
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Location = new System.Drawing.Point(12, 51);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(342, 95);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del cierre";
            // 
            // rbImpresionDigitador
            // 
            this.rbImpresionDigitador.AutoSize = true;
            this.rbImpresionDigitador.Checked = true;
            this.rbImpresionDigitador.Location = new System.Drawing.Point(170, 72);
            this.rbImpresionDigitador.Name = "rbImpresionDigitador";
            this.rbImpresionDigitador.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbImpresionDigitador.Size = new System.Drawing.Size(86, 17);
            this.rbImpresionDigitador.TabIndex = 4;
            this.rbImpresionDigitador.TabStop = true;
            this.rbImpresionDigitador.Text = "Por Digitador";
            this.rbImpresionDigitador.UseVisualStyleBackColor = true;
            // 
            // rbImpresionCajero
            // 
            this.rbImpresionCajero.AutoSize = true;
            this.rbImpresionCajero.Location = new System.Drawing.Point(262, 72);
            this.rbImpresionCajero.Name = "rbImpresionCajero";
            this.rbImpresionCajero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbImpresionCajero.Size = new System.Drawing.Size(74, 17);
            this.rbImpresionCajero.TabIndex = 5;
            this.rbImpresionCajero.Text = "Por Cajero";
            this.rbImpresionCajero.UseVisualStyleBackColor = true;
            // 
            // cboCoordinador
            // 
            this.cboCoordinador.Busqueda = false;
            this.cboCoordinador.ListaMostrada = null;
            this.cboCoordinador.Location = new System.Drawing.Point(79, 19);
            this.cboCoordinador.Name = "cboCoordinador";
            this.cboCoordinador.Size = new System.Drawing.Size(257, 21);
            this.cboCoordinador.TabIndex = 1;
            this.cboCoordinador.SelectedIndexChanged += new System.EventHandler(this.cboCoordinador_SelectedIndexChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(79, 46);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(257, 20);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.AutoSize = true;
            this.lblCoordinador.Location = new System.Drawing.Point(6, 23);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(67, 13);
            this.lblCoordinador.TabIndex = 0;
            this.lblCoordinador.Text = "Coordinador:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(33, 50);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Enabled = false;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(162, 152);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(90, 40);
            this.btnExportarExcel.TabIndex = 2;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(258, 152);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmReporteCierreCoordinador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(367, 204);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteCierreCoordinador";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Cierres por Cajero";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbDatos;
        private ComboBoxBusqueda cboCoordinador;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblCoordinador;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.RadioButton rbImpresionDigitador;
        private System.Windows.Forms.RadioButton rbImpresionCajero;
    }
}