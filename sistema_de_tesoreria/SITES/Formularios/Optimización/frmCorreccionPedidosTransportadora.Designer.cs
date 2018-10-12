namespace GUILayer.Formularios.Optimización
{
    partial class frmCorreccionPedidosTransportadora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorreccionPedidosTransportadora));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.pnlOpcionesCoordinacion = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.Columna_Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignada_Colones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignada_Dolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignada_Euros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlOpcionesCoordinacion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 180);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(980, 363);
            this.gbCargas.TabIndex = 34;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Cargas";
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.AllowUserToOrderColumns = true;
            this.dgvCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columna_Banco,
            this.Asignada_Colones,
            this.Asignada_Dolares,
            this.Asignada_Euros,
            this.clmComentario});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 26);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(968, 331);
            this.dgvCargas.TabIndex = 1;
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.cboTransportadora);
            this.gbFiltro.Controls.Add(this.lblTransportadora);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Location = new System.Drawing.Point(12, 81);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(878, 99);
            this.gbFiltro.TabIndex = 33;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Pedidos";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.FormattingEnabled = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(284, 47);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(172, 21);
            this.cboTransportadora.TabIndex = 10;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(196, 50);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 9;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(571, 36);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(64, 46);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(18, 50);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(40, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha:";
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
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(122, 0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(99, 40);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Rechazar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(510, 0);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // pnlOpcionesCoordinacion
            // 
            this.pnlOpcionesCoordinacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnAgregar);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnEliminar);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnModificar);
            this.pnlOpcionesCoordinacion.Enabled = false;
            this.pnlOpcionesCoordinacion.Location = new System.Drawing.Point(191, 543);
            this.pnlOpcionesCoordinacion.Name = "pnlOpcionesCoordinacion";
            this.pnlOpcionesCoordinacion.Size = new System.Drawing.Size(603, 40);
            this.pnlOpcionesCoordinacion.TabIndex = 35;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.FlatAppearance.BorderSize = 2;
            this.btnAgregar.Image = global::GUILayer.Properties.Resources.aceptar1;
            this.btnAgregar.Location = new System.Drawing.Point(414, 0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 40);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Finalizar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(896, 543);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 37;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1004, 60);
            this.pnlFondo.TabIndex = 32;
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.busqueda;
            this.btnRevisar.Location = new System.Drawing.Point(800, 543);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(90, 40);
            this.btnRevisar.TabIndex = 36;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // Columna_Banco
            // 
            this.Columna_Banco.DataPropertyName = "Transportadora";
            this.Columna_Banco.HeaderText = "Transportadora";
            this.Columna_Banco.Name = "Columna_Banco";
            this.Columna_Banco.ReadOnly = true;
            // 
            // Asignada_Colones
            // 
            this.Asignada_Colones.DataPropertyName = "Monto_asignado_colones";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Asignada_Colones.DefaultCellStyle = dataGridViewCellStyle2;
            this.Asignada_Colones.HeaderText = "A.Colones";
            this.Asignada_Colones.Name = "Asignada_Colones";
            this.Asignada_Colones.ReadOnly = true;
            // 
            // Asignada_Dolares
            // 
            this.Asignada_Dolares.DataPropertyName = "Monto_asignado_dolares";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Asignada_Dolares.DefaultCellStyle = dataGridViewCellStyle3;
            this.Asignada_Dolares.HeaderText = "A.Dólares";
            this.Asignada_Dolares.Name = "Asignada_Dolares";
            this.Asignada_Dolares.ReadOnly = true;
            // 
            // Asignada_Euros
            // 
            this.Asignada_Euros.DataPropertyName = "Monto_asignado_euros";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Asignada_Euros.DefaultCellStyle = dataGridViewCellStyle4;
            this.Asignada_Euros.HeaderText = "A.Euros";
            this.Asignada_Euros.Name = "Asignada_Euros";
            this.Asignada_Euros.ReadOnly = true;
            // 
            // clmComentario
            // 
            this.clmComentario.DataPropertyName = "Comentacio_Rechazo";
            this.clmComentario.HeaderText = "Comentario";
            this.clmComentario.Name = "clmComentario";
            this.clmComentario.ReadOnly = true;
            // 
            // frmCorreccionPedidosTransportadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 586);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.pnlOpcionesCoordinacion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnRevisar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCorreccionPedidosTransportadora";
            this.Text = "Corrección de Pedidos de Transportadora";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlOpcionesCoordinacion.ResumeLayout(false);
            this.pnlFondo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Panel pnlOpcionesCoordinacion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnRevisar;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignada_Colones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignada_Dolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignada_Euros;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmComentario;
    }
}