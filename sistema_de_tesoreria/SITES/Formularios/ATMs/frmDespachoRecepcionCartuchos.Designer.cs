namespace GUILayer
{
    partial class frmDespachoRecepcionCartuchos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDespachoRecepcionCartuchos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbListaCartuchos = new System.Windows.Forms.GroupBox();
            this.btnQuitarFalla = new System.Windows.Forms.Button();
            this.btnAgregarFalla = new System.Windows.Forms.Button();
            this.dgvCartuchos = new System.Windows.Forms.DataGridView();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clbFallas = new System.Windows.Forms.CheckedListBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFalla = new System.Windows.Forms.Label();
            this.gbSeleccionCartuchos = new System.Windows.Forms.GroupBox();
            this.mtbCodigo = new System.Windows.Forms.MaskedTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCodigoCartucho = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbListaCartuchos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartuchos)).BeginInit();
            this.gbSeleccionCartuchos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(634, 60);
            this.pnlFondo.TabIndex = 0;
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
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(296, 525);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(392, 525);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbListaCartuchos
            // 
            this.gbListaCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListaCartuchos.Controls.Add(this.cboEstado);
            this.gbListaCartuchos.Controls.Add(this.btnQuitarFalla);
            this.gbListaCartuchos.Controls.Add(this.btnAgregarFalla);
            this.gbListaCartuchos.Controls.Add(this.dgvCartuchos);
            this.gbListaCartuchos.Controls.Add(this.clbFallas);
            this.gbListaCartuchos.Controls.Add(this.lblEstado);
            this.gbListaCartuchos.Controls.Add(this.lblFalla);
            this.gbListaCartuchos.Location = new System.Drawing.Point(12, 205);
            this.gbListaCartuchos.Name = "gbListaCartuchos";
            this.gbListaCartuchos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbListaCartuchos.Size = new System.Drawing.Size(588, 315);
            this.gbListaCartuchos.TabIndex = 2;
            this.gbListaCartuchos.TabStop = false;
            this.gbListaCartuchos.Text = "Lista de Cartuchos";
            // 
            // btnQuitarFalla
            // 
            this.btnQuitarFalla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitarFalla.Enabled = false;
            this.btnQuitarFalla.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnQuitarFalla.Location = new System.Drawing.Point(428, 90);
            this.btnQuitarFalla.Name = "btnQuitarFalla";
            this.btnQuitarFalla.Size = new System.Drawing.Size(90, 40);
            this.btnQuitarFalla.TabIndex = 8;
            this.btnQuitarFalla.Text = "Quitar";
            this.btnQuitarFalla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarFalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarFalla.UseVisualStyleBackColor = false;
            this.btnQuitarFalla.Click += new System.EventHandler(this.btnQuitarFalla_Click);
            // 
            // btnAgregarFalla
            // 
            this.btnAgregarFalla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregarFalla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregarFalla.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarFalla.Location = new System.Drawing.Point(324, 90);
            this.btnAgregarFalla.Name = "btnAgregarFalla";
            this.btnAgregarFalla.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarFalla.TabIndex = 7;
            this.btnAgregarFalla.Text = "Agregar";
            this.btnAgregarFalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarFalla.UseVisualStyleBackColor = false;
            this.btnAgregarFalla.Click += new System.EventHandler(this.btnAgregarFalla_Click);
            // 
            // dgvCartuchos
            // 
            this.dgvCartuchos.AllowUserToAddRows = false;
            this.dgvCartuchos.AllowUserToDeleteRows = false;
            this.dgvCartuchos.AllowUserToResizeColumns = false;
            this.dgvCartuchos.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCartuchos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCartuchos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCartuchos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCartuchos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCartuchos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartuchos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clID,
            this.clFalla,
            this.clUsuario,
            this.clFecha});
            this.dgvCartuchos.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCartuchos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCartuchos.EnableHeadersVisualStyles = false;
            this.dgvCartuchos.GridColor = System.Drawing.Color.Black;
            this.dgvCartuchos.Location = new System.Drawing.Point(64, 136);
            this.dgvCartuchos.MultiSelect = false;
            this.dgvCartuchos.Name = "dgvCartuchos";
            this.dgvCartuchos.ReadOnly = true;
            this.dgvCartuchos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvCartuchos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCartuchos.RowHeadersVisible = false;
            this.dgvCartuchos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCartuchos.Size = new System.Drawing.Size(454, 173);
            this.dgvCartuchos.TabIndex = 0;
            this.dgvCartuchos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCartuchos_RowsAdded);
            this.dgvCartuchos.SelectionChanged += new System.EventHandler(this.dgvCartuchos_SelectionChanged);
            // 
            // clID
            // 
            this.clID.DataPropertyName = "ID";
            this.clID.HeaderText = "ID";
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            // 
            // clFalla
            // 
            this.clFalla.DataPropertyName = "Nombre";
            this.clFalla.HeaderText = "Falla";
            this.clFalla.Name = "clFalla";
            this.clFalla.ReadOnly = true;
            this.clFalla.Width = 150;
            // 
            // clUsuario
            // 
            this.clUsuario.DataPropertyName = "Usuario";
            this.clUsuario.HeaderText = "Usuario";
            this.clUsuario.Name = "clUsuario";
            this.clUsuario.ReadOnly = true;
            // 
            // clFecha
            // 
            this.clFecha.DataPropertyName = "Fecha";
            this.clFecha.HeaderText = "Fecha";
            this.clFecha.Name = "clFecha";
            this.clFecha.ReadOnly = true;
            // 
            // clbFallas
            // 
            this.clbFallas.FormattingEnabled = true;
            this.clbFallas.Location = new System.Drawing.Point(64, 19);
            this.clbFallas.Name = "clbFallas";
            this.clbFallas.Size = new System.Drawing.Size(156, 94);
            this.clbFallas.TabIndex = 6;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(281, 22);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado:";
            // 
            // lblFalla
            // 
            this.lblFalla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFalla.AutoSize = true;
            this.lblFalla.Location = new System.Drawing.Point(20, 21);
            this.lblFalla.Name = "lblFalla";
            this.lblFalla.Size = new System.Drawing.Size(37, 13);
            this.lblFalla.TabIndex = 4;
            this.lblFalla.Text = "Fallas:";
            // 
            // gbSeleccionCartuchos
            // 
            this.gbSeleccionCartuchos.Controls.Add(this.mtbCodigo);
            this.gbSeleccionCartuchos.Controls.Add(this.btnBuscar);
            this.gbSeleccionCartuchos.Controls.Add(this.lblCodigoCartucho);
            this.gbSeleccionCartuchos.Location = new System.Drawing.Point(12, 66);
            this.gbSeleccionCartuchos.Name = "gbSeleccionCartuchos";
            this.gbSeleccionCartuchos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbSeleccionCartuchos.Size = new System.Drawing.Size(316, 98);
            this.gbSeleccionCartuchos.TabIndex = 1;
            this.gbSeleccionCartuchos.TabStop = false;
            this.gbSeleccionCartuchos.Text = "Selección de Cartuchos";
            // 
            // mtbCodigo
            // 
            this.mtbCodigo.Location = new System.Drawing.Point(55, 29);
            this.mtbCodigo.Name = "mtbCodigo";
            this.mtbCodigo.Size = new System.Drawing.Size(154, 20);
            this.mtbCodigo.TabIndex = 1;
            this.mtbCodigo.Enter += new System.EventHandler(this.mtbCodigo_Enter);
            this.mtbCodigo.Leave += new System.EventHandler(this.mtbCodigo_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(215, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblCodigoCartucho
            // 
            this.lblCodigoCartucho.AutoSize = true;
            this.lblCodigoCartucho.Location = new System.Drawing.Point(6, 33);
            this.lblCodigoCartucho.Name = "lblCodigoCartucho";
            this.lblCodigoCartucho.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoCartucho.TabIndex = 0;
            this.lblCodigoCartucho.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Transportadora:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTransportadora);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(348, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 119);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cartucho:";
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Enabled = false;
            this.txtTransportadora.Location = new System.Drawing.Point(100, 81);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.Size = new System.Drawing.Size(100, 20);
            this.txtTransportadora.TabIndex = 8;
            // 
            // txtTipo
            // 
            this.txtTipo.Enabled = false;
            this.txtTipo.Location = new System.Drawing.Point(100, 53);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(100, 20);
            this.txtTipo.TabIndex = 7;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(100, 24);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 6;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Enabled = false;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Bueno",
            "Malo en Tesorería",
            "Malo en Taller",
            "No Recuperable"});
            this.cboEstado.Location = new System.Drawing.Point(349, 19);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(163, 21);
            this.cboEstado.TabIndex = 9;
            // 
            // frmDespachoRecepcionCartuchos
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 577);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbListaCartuchos);
            this.Controls.Add(this.gbSeleccionCartuchos);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDespachoRecepcionCartuchos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despacho y Recepción de Cartuchos";
            this.Load += new System.EventHandler(this.frmDespachoRecepcionCartuchos_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbListaCartuchos.ResumeLayout(false);
            this.gbListaCartuchos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartuchos)).EndInit();
            this.gbSeleccionCartuchos.ResumeLayout(false);
            this.gbSeleccionCartuchos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbListaCartuchos;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridView dgvCartuchos;
        private System.Windows.Forms.GroupBox gbSeleccionCartuchos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCodigoCartucho;
        private System.Windows.Forms.MaskedTextBox mtbCodigo;
        private System.Windows.Forms.Label lblFalla;
        private System.Windows.Forms.CheckedListBox clbFallas;
        private System.Windows.Forms.Button btnQuitarFalla;
        private System.Windows.Forms.Button btnAgregarFalla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFecha;
        private System.Windows.Forms.ComboBox cboEstado;
    }
}