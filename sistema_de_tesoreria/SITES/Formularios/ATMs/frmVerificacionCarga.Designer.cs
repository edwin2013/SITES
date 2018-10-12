﻿namespace GUILayer
{
    partial class frmVerificacionCarga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerificacionCarga));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDenominacionesCartuchos = new System.Windows.Forms.GroupBox();
            this.chkCartuchoRechazo = new System.Windows.Forms.CheckBox();
            this.dgvCartuchos = new System.Windows.Forms.DataGridView();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.gbDatosColaborador = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.imlConfiguracionOpteva = new System.Windows.Forms.ImageList(this.components);
            this.imlBilletes = new System.Windows.Forms.ImageList(this.components);
            this.imlConfiguracionDiebold = new System.Windows.Forms.ImageList(this.components);
            this.Denominacion = new System.Windows.Forms.DataGridViewImageColumn();
            this.Configuracion = new System.Windows.Forms.DataGridViewImageColumn();
            this.Revisado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cartucho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marchamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDenominacionesCartuchos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartuchos)).BeginInit();
            this.gbDatosColaborador.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(775, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDenominacionesCartuchos
            // 
            this.gbDenominacionesCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDenominacionesCartuchos.Controls.Add(this.chkCartuchoRechazo);
            this.gbDenominacionesCartuchos.Controls.Add(this.dgvCartuchos);
            this.gbDenominacionesCartuchos.Location = new System.Drawing.Point(12, 140);
            this.gbDenominacionesCartuchos.Name = "gbDenominacionesCartuchos";
            this.gbDenominacionesCartuchos.Size = new System.Drawing.Size(720, 387);
            this.gbDenominacionesCartuchos.TabIndex = 2;
            this.gbDenominacionesCartuchos.TabStop = false;
            this.gbDenominacionesCartuchos.Text = "Denominaciones de los Cartuchos";
            // 
            // chkCartuchoRechazo
            // 
            this.chkCartuchoRechazo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCartuchoRechazo.AutoSize = true;
            this.chkCartuchoRechazo.Location = new System.Drawing.Point(584, 364);
            this.chkCartuchoRechazo.Name = "chkCartuchoRechazo";
            this.chkCartuchoRechazo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCartuchoRechazo.Size = new System.Drawing.Size(130, 17);
            this.chkCartuchoRechazo.TabIndex = 1;
            this.chkCartuchoRechazo.Text = "Cartucho de Rechazo";
            this.chkCartuchoRechazo.UseVisualStyleBackColor = true;
            this.chkCartuchoRechazo.CheckedChanged += new System.EventHandler(this.chkCartuchoRechazo_CheckedChanged);
            // 
            // dgvCartuchos
            // 
            this.dgvCartuchos.AllowUserToAddRows = false;
            this.dgvCartuchos.AllowUserToDeleteRows = false;
            this.dgvCartuchos.AllowUserToOrderColumns = true;
            this.dgvCartuchos.AllowUserToResizeColumns = false;
            this.dgvCartuchos.AllowUserToResizeRows = false;
            this.dgvCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCartuchos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCartuchos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCartuchos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCartuchos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartuchos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Denominacion,
            this.Configuracion,
            this.Revisado,
            this.Cartucho,
            this.Marchamo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCartuchos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCartuchos.EnableHeadersVisualStyles = false;
            this.dgvCartuchos.GridColor = System.Drawing.Color.Black;
            this.dgvCartuchos.Location = new System.Drawing.Point(6, 16);
            this.dgvCartuchos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvCartuchos.Name = "dgvCartuchos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCartuchos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCartuchos.RowHeadersVisible = false;
            this.dgvCartuchos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCartuchos.Size = new System.Drawing.Size(708, 342);
            this.dgvCartuchos.StandardTab = true;
            this.dgvCartuchos.TabIndex = 0;
            this.dgvCartuchos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCartuchos_CellValueChanged);
            this.dgvCartuchos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCartuchos_CurrentCellDirtyStateChanged);
            this.dgvCartuchos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCartuchos_RowsAdded);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(414, 19);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(144, 20);
            this.txtContrasena.TabIndex = 3;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(344, 23);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(64, 13);
            this.lblContrasena.TabIndex = 2;
            this.lblContrasena.Text = "Contraseña:";
            // 
            // gbDatosColaborador
            // 
            this.gbDatosColaborador.Controls.Add(this.lblCodigo);
            this.gbDatosColaborador.Controls.Add(this.btnVerificar);
            this.gbDatosColaborador.Controls.Add(this.txtCodigo);
            this.gbDatosColaborador.Controls.Add(this.txtIdentificacion);
            this.gbDatosColaborador.Controls.Add(this.lblIdentificacion);
            this.gbDatosColaborador.Controls.Add(this.txtNombre);
            this.gbDatosColaborador.Controls.Add(this.label1);
            this.gbDatosColaborador.Controls.Add(this.lblContrasena);
            this.gbDatosColaborador.Controls.Add(this.txtContrasena);
            this.gbDatosColaborador.Location = new System.Drawing.Point(12, 63);
            this.gbDatosColaborador.Name = "gbDatosColaborador";
            this.gbDatosColaborador.Size = new System.Drawing.Size(660, 71);
            this.gbDatosColaborador.TabIndex = 1;
            this.gbDatosColaborador.TabStop = false;
            this.gbDatosColaborador.Text = "Datos de la Persona que Realiza la Verificación";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(10, 23);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // btnVerificar
            // 
            this.btnVerificar.FlatAppearance.BorderSize = 2;
            this.btnVerificar.Image = global::GUILayer.Properties.Resources.usuarios;
            this.btnVerificar.Location = new System.Drawing.Point(564, 25);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(90, 40);
            this.btnVerificar.TabIndex = 8;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(59, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PasswordChar = '*';
            this.txtCodigo.Size = new System.Drawing.Size(270, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(414, 45);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.ReadOnly = true;
            this.txtIdentificacion.Size = new System.Drawing.Size(144, 20);
            this.txtIdentificacion.TabIndex = 7;
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(335, 49);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(73, 13);
            this.lblIdentificacion.TabIndex = 6;
            this.lblIdentificacion.Text = "Identificación:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(59, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(270, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(636, 533);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(540, 533);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // imlConfiguracionOpteva
            // 
            this.imlConfiguracionOpteva.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlConfiguracionOpteva.ImageStream")));
            this.imlConfiguracionOpteva.TransparentColor = System.Drawing.Color.Transparent;
            this.imlConfiguracionOpteva.Images.SetKeyName(0, "opteva 1000.jpg");
            this.imlConfiguracionOpteva.Images.SetKeyName(1, "opteva 2000.jpg");
            this.imlConfiguracionOpteva.Images.SetKeyName(2, "opteva 5000.jpg");
            this.imlConfiguracionOpteva.Images.SetKeyName(3, "opteva 10000.jpg");
            this.imlConfiguracionOpteva.Images.SetKeyName(4, "opteva 20000.jpg");
            this.imlConfiguracionOpteva.Images.SetKeyName(5, "opteva 50000.jpg");
            this.imlConfiguracionOpteva.Images.SetKeyName(6, "opteva 20.jpg");
            // 
            // imlBilletes
            // 
            this.imlBilletes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBilletes.ImageStream")));
            this.imlBilletes.TransparentColor = System.Drawing.Color.Transparent;
            this.imlBilletes.Images.SetKeyName(0, "1000.jpg");
            this.imlBilletes.Images.SetKeyName(1, "2000.jpg");
            this.imlBilletes.Images.SetKeyName(2, "5000.jpg");
            this.imlBilletes.Images.SetKeyName(3, "10000.jpg");
            this.imlBilletes.Images.SetKeyName(4, "20000.jpg");
            this.imlBilletes.Images.SetKeyName(5, "50000.jpg");
            this.imlBilletes.Images.SetKeyName(6, "us 20.jpg");
            // 
            // imlConfiguracionDiebold
            // 
            this.imlConfiguracionDiebold.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlConfiguracionDiebold.ImageStream")));
            this.imlConfiguracionDiebold.TransparentColor = System.Drawing.Color.Transparent;
            this.imlConfiguracionDiebold.Images.SetKeyName(0, "diebold 1000.jpg");
            this.imlConfiguracionDiebold.Images.SetKeyName(1, "diebold 2000.jpg");
            this.imlConfiguracionDiebold.Images.SetKeyName(2, "diebold 5000.jpg");
            this.imlConfiguracionDiebold.Images.SetKeyName(3, "diebold 10000.jpg");
            this.imlConfiguracionDiebold.Images.SetKeyName(4, "diebold 20000.jpg");
            this.imlConfiguracionDiebold.Images.SetKeyName(5, "diebold 50000.jpg");
            this.imlConfiguracionDiebold.Images.SetKeyName(6, "diebold 20.jpg");
            // 
            // Denominacion
            // 
            this.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Denominacion.HeaderText = "Denominación";
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.ReadOnly = true;
            this.Denominacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Denominacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Denominacion.Width = 99;
            // 
            // Configuracion
            // 
            this.Configuracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Configuracion.HeaderText = "Configuración";
            this.Configuracion.Name = "Configuracion";
            this.Configuracion.ReadOnly = true;
            this.Configuracion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Configuracion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Configuracion.Width = 96;
            // 
            // Revisado
            // 
            this.Revisado.HeaderText = "Revisado";
            this.Revisado.Name = "Revisado";
            // 
            // Cartucho
            // 
            this.Cartucho.DataPropertyName = "Cartucho";
            this.Cartucho.HeaderText = "Cartucho";
            this.Cartucho.Name = "Cartucho";
            this.Cartucho.ReadOnly = true;
            // 
            // Marchamo
            // 
            this.Marchamo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Marchamo.DataPropertyName = "Marchamo";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Marchamo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Marchamo.HeaderText = "Marchamo";
            this.Marchamo.Name = "Marchamo";
            this.Marchamo.ReadOnly = true;
            this.Marchamo.Width = 81;
            // 
            // frmVerificacionCarga
            // 
            this.AcceptButton = this.btnVerificar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(744, 585);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbDatosColaborador);
            this.Controls.Add(this.gbDenominacionesCartuchos);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVerificacionCarga";
            this.Text = "Verificación de la Carga";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDenominacionesCartuchos.ResumeLayout(false);
            this.gbDenominacionesCartuchos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartuchos)).EndInit();
            this.gbDatosColaborador.ResumeLayout(false);
            this.gbDatosColaborador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDenominacionesCartuchos;
        private System.Windows.Forms.DataGridView dgvCartuchos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.GroupBox gbDatosColaborador;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ImageList imlConfiguracionOpteva;
        private System.Windows.Forms.ImageList imlBilletes;
        private System.Windows.Forms.ImageList imlConfiguracionDiebold;
        private System.Windows.Forms.CheckBox chkCartuchoRechazo;
        private System.Windows.Forms.DataGridViewImageColumn Denominacion;
        private System.Windows.Forms.DataGridViewImageColumn Configuracion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Revisado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cartucho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marchamo;
    }
}