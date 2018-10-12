namespace GUILayer.Formularios.Bancos
{
    partial class frmVerificacionPedidoBancos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerificacionPedidoBancos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imlConfiguracionDiebold = new System.Windows.Forms.ImageList(this.components);
            this.Revisado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Marchamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cartucho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatosColaborador = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.dgvCartuchos = new System.Windows.Forms.DataGridView();
            this.gbDenominacionesCartuchos = new System.Windows.Forms.GroupBox();
            this.imlConfiguracionOpteva = new System.Windows.Forms.ImageList(this.components);
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.imlBilletes = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatosColaborador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartuchos)).BeginInit();
            this.gbDenominacionesCartuchos.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
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
            // Revisado
            // 
            this.Revisado.HeaderText = "Revisado";
            this.Revisado.Name = "Revisado";
            // 
            // Marchamo
            // 
            this.Marchamo.DataPropertyName = "Cantidad_asignada";
            this.Marchamo.HeaderText = "Cantidad";
            this.Marchamo.Name = "Marchamo";
            this.Marchamo.ReadOnly = true;
            // 
            // Cartucho
            // 
            this.Cartucho.DataPropertyName = "Monto_asignado";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Cartucho.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cartucho.HeaderText = "M. Cargado";
            this.Cartucho.Name = "Cartucho";
            this.Cartucho.ReadOnly = true;
            // 
            // Denominacion
            // 
            this.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Denominacion.DataPropertyName = "Denominacion";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Denominacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Denominacion.HeaderText = "Denominación";
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.ReadOnly = true;
            this.Denominacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Denominacion.Width = 99;
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
            this.gbDatosColaborador.Location = new System.Drawing.Point(0, 70);
            this.gbDatosColaborador.Name = "gbDatosColaborador";
            this.gbDatosColaborador.Size = new System.Drawing.Size(660, 71);
            this.gbDatosColaborador.TabIndex = 11;
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
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(344, 23);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(64, 13);
            this.lblContrasena.TabIndex = 2;
            this.lblContrasena.Text = "Contraseña:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(414, 19);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(144, 20);
            this.txtContrasena.TabIndex = 3;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCartuchos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCartuchos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartuchos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Denominacion,
            this.Cartucho,
            this.Marchamo,
            this.Revisado});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCartuchos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCartuchos.EnableHeadersVisualStyles = false;
            this.dgvCartuchos.GridColor = System.Drawing.Color.Black;
            this.dgvCartuchos.Location = new System.Drawing.Point(6, 16);
            this.dgvCartuchos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvCartuchos.Name = "dgvCartuchos";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCartuchos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCartuchos.RowHeadersVisible = false;
            this.dgvCartuchos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCartuchos.Size = new System.Drawing.Size(708, 342);
            this.dgvCartuchos.StandardTab = true;
            this.dgvCartuchos.TabIndex = 0;
            this.dgvCartuchos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCartuchos_CellValueChanged);
            this.dgvCartuchos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCartuchos_CurrentCellDirtyStateChanged);
            this.dgvCartuchos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCartuchos_RowsAdded);
            // 
            // gbDenominacionesCartuchos
            // 
            this.gbDenominacionesCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDenominacionesCartuchos.Controls.Add(this.dgvCartuchos);
            this.gbDenominacionesCartuchos.Location = new System.Drawing.Point(0, 147);
            this.gbDenominacionesCartuchos.Name = "gbDenominacionesCartuchos";
            this.gbDenominacionesCartuchos.Size = new System.Drawing.Size(720, 387);
            this.gbDenominacionesCartuchos.TabIndex = 12;
            this.gbDenominacionesCartuchos.TabStop = false;
            this.gbDenominacionesCartuchos.Text = "Denominaciones de los Cartuchos";
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
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-15, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(775, 60);
            this.pnlFondo.TabIndex = 10;
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
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(624, 540);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 14;
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
            this.btnAceptar.Location = new System.Drawing.Point(528, 540);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
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
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(14, -1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmVerificacionPedidoBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 585);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbDatosColaborador);
            this.Controls.Add(this.gbDenominacionesCartuchos);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVerificacionPedidoBancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificar Pedido";
            this.gbDatosColaborador.ResumeLayout(false);
            this.gbDatosColaborador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartuchos)).EndInit();
            this.gbDenominacionesCartuchos.ResumeLayout(false);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ImageList imlConfiguracionDiebold;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Revisado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marchamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cartucho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion;
        private System.Windows.Forms.GroupBox gbDatosColaborador;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.DataGridView dgvCartuchos;
        private System.Windows.Forms.GroupBox gbDenominacionesCartuchos;
        private System.Windows.Forms.ImageList imlConfiguracionOpteva;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.ImageList imlBilletes;
    }
}