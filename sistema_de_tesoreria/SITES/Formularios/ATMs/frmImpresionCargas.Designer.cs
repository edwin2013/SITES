namespace GUILayer
{
    partial class frmImpresionCargas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpresionCargas));
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.gbImpresion = new System.Windows.Forms.GroupBox();
            this.lblTipoReporte = new System.Windows.Forms.Label();
            this.pnlFiltroRuta = new System.Windows.Forms.Panel();
            this.nudRuta = new System.Windows.Forms.NumericUpDown();
            this.lblRuta = new System.Windows.Forms.Label();
            this.pnlFiltroCajero = new System.Windows.Forms.Panel();
            this.lblCajero = new System.Windows.Forms.Label();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.cboTipoReporte = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaImpresion = new System.Windows.Forms.Label();
            this.pnlFiltroTransportadora = new System.Windows.Forms.Panel();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbImpresion.SuspendLayout();
            this.pnlFiltroRuta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).BeginInit();
            this.pnlFiltroCajero.SuspendLayout();
            this.pnlFiltroTransportadora.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarExcel.FlatAppearance.BorderSize = 2;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(172, 171);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(90, 40);
            this.btnExportarExcel.TabIndex = 2;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // gbImpresion
            // 
            this.gbImpresion.Controls.Add(this.lblTipoReporte);
            this.gbImpresion.Controls.Add(this.pnlFiltroRuta);
            this.gbImpresion.Controls.Add(this.pnlFiltroCajero);
            this.gbImpresion.Controls.Add(this.cboTipoReporte);
            this.gbImpresion.Controls.Add(this.dtpFecha);
            this.gbImpresion.Controls.Add(this.lblFechaImpresion);
            this.gbImpresion.Controls.Add(this.pnlFiltroTransportadora);
            this.gbImpresion.Location = new System.Drawing.Point(12, 66);
            this.gbImpresion.Name = "gbImpresion";
            this.gbImpresion.Size = new System.Drawing.Size(346, 99);
            this.gbImpresion.TabIndex = 1;
            this.gbImpresion.TabStop = false;
            this.gbImpresion.Text = "Impresion de Cargas";
            // 
            // lblTipoReporte
            // 
            this.lblTipoReporte.AutoSize = true;
            this.lblTipoReporte.Location = new System.Drawing.Point(6, 49);
            this.lblTipoReporte.Name = "lblTipoReporte";
            this.lblTipoReporte.Size = new System.Drawing.Size(87, 13);
            this.lblTipoReporte.TabIndex = 2;
            this.lblTipoReporte.Text = "Tipo de Reporte:";
            // 
            // pnlFiltroRuta
            // 
            this.pnlFiltroRuta.Controls.Add(this.nudRuta);
            this.pnlFiltroRuta.Controls.Add(this.lblRuta);
            this.pnlFiltroRuta.Location = new System.Drawing.Point(0, 72);
            this.pnlFiltroRuta.Name = "pnlFiltroRuta";
            this.pnlFiltroRuta.Size = new System.Drawing.Size(346, 20);
            this.pnlFiltroRuta.TabIndex = 4;
            this.pnlFiltroRuta.Visible = false;
            // 
            // nudRuta
            // 
            this.nudRuta.Location = new System.Drawing.Point(99, 0);
            this.nudRuta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRuta.Name = "nudRuta";
            this.nudRuta.Size = new System.Drawing.Size(120, 20);
            this.nudRuta.TabIndex = 1;
            this.nudRuta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(60, 4);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(33, 13);
            this.lblRuta.TabIndex = 0;
            this.lblRuta.Text = "Ruta:";
            // 
            // pnlFiltroCajero
            // 
            this.pnlFiltroCajero.Controls.Add(this.lblCajero);
            this.pnlFiltroCajero.Controls.Add(this.cboCajero);
            this.pnlFiltroCajero.Location = new System.Drawing.Point(0, 72);
            this.pnlFiltroCajero.Name = "pnlFiltroCajero";
            this.pnlFiltroCajero.Size = new System.Drawing.Size(346, 21);
            this.pnlFiltroCajero.TabIndex = 5;
            this.pnlFiltroCajero.Visible = false;
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(53, 4);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(40, 13);
            this.lblCajero.TabIndex = 0;
            this.lblCajero.Text = "Cajero:";
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = false;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(99, 0);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(241, 21);
            this.cboCajero.TabIndex = 1;
            this.cboCajero.SelectedIndexChanged += new System.EventHandler(this.cboCajero_SelectedIndexChanged);
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoReporte.FormattingEnabled = true;
            this.cboTipoReporte.Items.AddRange(new object[] {
            "Consolidado General",
            "Consolidado por Cajero",
            "Consolidado por Ruta",
            "Por Denominación General",
            "Por Denominación por Cajero",
            "Por Denominación por Ruta",
            "Cargas Generadas o Importadas"});
            this.cboTipoReporte.Location = new System.Drawing.Point(99, 45);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.Size = new System.Drawing.Size(241, 21);
            this.cboTipoReporte.TabIndex = 3;
            this.cboTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cboTipoReporte_SelectedIndexChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(99, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(241, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblFechaImpresion
            // 
            this.lblFechaImpresion.AutoSize = true;
            this.lblFechaImpresion.Location = new System.Drawing.Point(53, 23);
            this.lblFechaImpresion.Name = "lblFechaImpresion";
            this.lblFechaImpresion.Size = new System.Drawing.Size(40, 13);
            this.lblFechaImpresion.TabIndex = 0;
            this.lblFechaImpresion.Text = "Fecha:";
            // 
            // pnlFiltroTransportadora
            // 
            this.pnlFiltroTransportadora.Controls.Add(this.lblTransportadora);
            this.pnlFiltroTransportadora.Controls.Add(this.cboTransportadora);
            this.pnlFiltroTransportadora.Location = new System.Drawing.Point(0, 72);
            this.pnlFiltroTransportadora.Name = "pnlFiltroTransportadora";
            this.pnlFiltroTransportadora.Size = new System.Drawing.Size(346, 21);
            this.pnlFiltroTransportadora.TabIndex = 6;
            this.pnlFiltroTransportadora.Visible = false;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(11, 4);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 0;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = false;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(99, 0);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(241, 21);
            this.cboTransportadora.TabIndex = 1;
            this.cboTransportadora.SelectedIndexChanged += new System.EventHandler(this.cboTransportadora_SelectedIndexChanged);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(370, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(346, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(268, 171);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmImpresionCargas
            // 
            this.AcceptButton = this.btnExportarExcel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(370, 223);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.gbImpresion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImpresionCargas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresión de Cargas";
            this.gbImpresion.ResumeLayout(false);
            this.gbImpresion.PerformLayout();
            this.pnlFiltroRuta.ResumeLayout(false);
            this.pnlFiltroRuta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).EndInit();
            this.pnlFiltroCajero.ResumeLayout(false);
            this.pnlFiltroCajero.PerformLayout();
            this.pnlFiltroTransportadora.ResumeLayout(false);
            this.pnlFiltroTransportadora.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.GroupBox gbImpresion;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaImpresion;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFiltroCajero;
        private System.Windows.Forms.NumericUpDown nudRuta;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFiltroRuta;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Label lblTipoReporte;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.ComboBox cboTipoReporte;
        private System.Windows.Forms.Panel pnlFiltroTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private ComboBoxBusqueda cboTransportadora;
    }
}