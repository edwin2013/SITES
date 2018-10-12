namespace GUILayer.Formularios.Facturacion
{
    partial class frmIngresoRegistroPenalidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoRegistroPenalidades));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.chkProntoAviso = new System.Windows.Forms.CheckBox();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboEmpresaTransporte = new GUILayer.ComboBoxBusqueda();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.cboTipoPenalidad = new GUILayer.ComboBoxBusqueda();
            this.lblTipoPenalidad = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(2, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(458, 53);
            this.pnlFondo.TabIndex = 8;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo1;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(401, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.chkProntoAviso);
            this.gbDatos.Controls.Add(this.cboPuntoVenta);
            this.gbDatos.Controls.Add(this.lblPuntoVenta);
            this.gbDatos.Controls.Add(this.cboCliente);
            this.gbDatos.Controls.Add(this.lblCliente);
            this.gbDatos.Controls.Add(this.cboEmpresaTransporte);
            this.gbDatos.Controls.Add(this.lblTransportadora);
            this.gbDatos.Controls.Add(this.cboTipoPenalidad);
            this.gbDatos.Controls.Add(this.lblTipoPenalidad);
            this.gbDatos.Location = new System.Drawing.Point(12, 64);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(436, 196);
            this.gbDatos.TabIndex = 9;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Penalidad";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(172, 154);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(213, 149);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 11;
            // 
            // chkProntoAviso
            // 
            this.chkProntoAviso.AutoSize = true;
            this.chkProntoAviso.Location = new System.Drawing.Point(12, 154);
            this.chkProntoAviso.Name = "chkProntoAviso";
            this.chkProntoAviso.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkProntoAviso.Size = new System.Drawing.Size(86, 17);
            this.chkProntoAviso.TabIndex = 10;
            this.chkProntoAviso.Text = "Pronto Aviso";
            this.chkProntoAviso.UseVisualStyleBackColor = true;
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = true;
            this.cboPuntoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntoVenta.FormattingEnabled = true;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(111, 113);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(302, 21);
            this.cboPuntoVenta.TabIndex = 9;
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(9, 116);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(84, 13);
            this.lblPuntoVenta.TabIndex = 8;
            this.lblPuntoVenta.Text = "Punto de Venta:";
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = true;
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(111, 86);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(302, 21);
            this.cboCliente.TabIndex = 7;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(9, 89);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboEmpresaTransporte
            // 
            this.cboEmpresaTransporte.Busqueda = true;
            this.cboEmpresaTransporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresaTransporte.FormattingEnabled = true;
            this.cboEmpresaTransporte.ListaMostrada = null;
            this.cboEmpresaTransporte.Location = new System.Drawing.Point(111, 59);
            this.cboEmpresaTransporte.Name = "cboEmpresaTransporte";
            this.cboEmpresaTransporte.Size = new System.Drawing.Size(302, 21);
            this.cboEmpresaTransporte.TabIndex = 5;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(9, 62);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 4;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // cboTipoPenalidad
            // 
            this.cboTipoPenalidad.Busqueda = true;
            this.cboTipoPenalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPenalidad.FormattingEnabled = true;
            this.cboTipoPenalidad.ListaMostrada = null;
            this.cboTipoPenalidad.Location = new System.Drawing.Point(111, 32);
            this.cboTipoPenalidad.Name = "cboTipoPenalidad";
            this.cboTipoPenalidad.Size = new System.Drawing.Size(302, 21);
            this.cboTipoPenalidad.TabIndex = 3;
            // 
            // lblTipoPenalidad
            // 
            this.lblTipoPenalidad.AutoSize = true;
            this.lblTipoPenalidad.Location = new System.Drawing.Point(9, 35);
            this.lblTipoPenalidad.Name = "lblTipoPenalidad";
            this.lblTipoPenalidad.Size = new System.Drawing.Size(57, 13);
            this.lblTipoPenalidad.TabIndex = 2;
            this.lblTipoPenalidad.Text = "Penalidad:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(262, 273);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(358, 273);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // frmIngresoRegistroPenalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 325);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmIngresoRegistroPenalidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Penalidades";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatos;
        private ComboBoxBusqueda cboTipoPenalidad;
        private System.Windows.Forms.Label lblTipoPenalidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private ComboBoxBusqueda cboEmpresaTransporte;
        private System.Windows.Forms.Label lblTransportadora;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.CheckBox chkProntoAviso;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}