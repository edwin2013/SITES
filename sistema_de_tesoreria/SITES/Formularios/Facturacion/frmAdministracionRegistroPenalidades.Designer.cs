namespace GUILayer.Formularios.Facturacion
{
    partial class frmAdministracionRegistroPenalidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionRegistroPenalidades));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPuntoVenta = new GUILayer.ComboBoxBusqueda();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmpresaTransporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPuntoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipoPenalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCaso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProntoAviso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmNivelServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(896, 540);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(701, 540);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(800, 540);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
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
            this.pnlFondo.TabIndex = 7;
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
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 177);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(980, 357);
            this.gbCargas.TabIndex = 9;
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
            this.clmFecha,
            this.clmEmpresaTransporte,
            this.clmCliente,
            this.clmPuntoVenta,
            this.clmTipoPenalidad,
            this.clmCaso,
            this.clmProntoAviso,
            this.clmNivelServicio,
            this.clmTarifa,
            this.clmMonto});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(968, 332);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCargas_RowsAdded);
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(715, 26);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(25, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(92, 51);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(18, 55);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.dtpFechaFin);
            this.gbFiltro.Controls.Add(this.label1);
            this.gbFiltro.Controls.Add(this.cboPuntoVenta);
            this.gbFiltro.Controls.Add(this.lblPuntoVenta);
            this.gbFiltro.Controls.Add(this.lblTransportadora);
            this.gbFiltro.Controls.Add(this.cboTransportadora);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.cboCliente);
            this.gbFiltro.Controls.Add(this.lblCliente);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Location = new System.Drawing.Point(12, 72);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(878, 99);
            this.gbFiltro.TabIndex = 8;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Cargas";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(260, 50);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(104, 20);
            this.dtpFechaFin.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fecha Fin:";
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.Busqueda = true;
            this.cboPuntoVenta.ListaMostrada = null;
            this.cboPuntoVenta.Location = new System.Drawing.Point(473, 15);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(204, 21);
            this.cboPuntoVenta.TabIndex = 13;
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(398, 22);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(69, 13);
            this.lblPuntoVenta.TabIndex = 12;
            this.lblPuntoVenta.Text = "Punto Venta:";
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(385, 55);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 11;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(473, 50);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(210, 21);
            this.cboTransportadora.TabIndex = 10;
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = true;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(64, 19);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(245, 21);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.FlatAppearance.BorderSize = 2;
            this.btnAgregar.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregar.Location = new System.Drawing.Point(605, 540);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 40);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // clmFecha
            // 
            this.clmFecha.DataPropertyName = "Fecha_Registro";
            this.clmFecha.HeaderText = "Fecha";
            this.clmFecha.Name = "clmFecha";
            this.clmFecha.ReadOnly = true;
            // 
            // clmEmpresaTransporte
            // 
            this.clmEmpresaTransporte.DataPropertyName = "Transportadora";
            this.clmEmpresaTransporte.HeaderText = "Empresa de Transporte";
            this.clmEmpresaTransporte.Name = "clmEmpresaTransporte";
            this.clmEmpresaTransporte.ReadOnly = true;
            // 
            // clmCliente
            // 
            this.clmCliente.DataPropertyName = "Cliente";
            this.clmCliente.HeaderText = "Cliente";
            this.clmCliente.Name = "clmCliente";
            this.clmCliente.ReadOnly = true;
            // 
            // clmPuntoVenta
            // 
            this.clmPuntoVenta.DataPropertyName = "Punto_Venta";
            this.clmPuntoVenta.HeaderText = "Punto de Venta";
            this.clmPuntoVenta.Name = "clmPuntoVenta";
            this.clmPuntoVenta.ReadOnly = true;
            // 
            // clmTipoPenalidad
            // 
            this.clmTipoPenalidad.DataPropertyName = "TipoPenalidad";
            this.clmTipoPenalidad.HeaderText = "Tipo de Penalidad";
            this.clmTipoPenalidad.Name = "clmTipoPenalidad";
            this.clmTipoPenalidad.ReadOnly = true;
            // 
            // clmCaso
            // 
            this.clmCaso.DataPropertyName = "Penalidad";
            this.clmCaso.HeaderText = "Caso";
            this.clmCaso.Name = "clmCaso";
            this.clmCaso.ReadOnly = true;
            // 
            // clmProntoAviso
            // 
            this.clmProntoAviso.DataPropertyName = "Pronto_Aviso";
            this.clmProntoAviso.HeaderText = "Pronto Aviso";
            this.clmProntoAviso.Name = "clmProntoAviso";
            this.clmProntoAviso.ReadOnly = true;
            // 
            // clmNivelServicio
            // 
            this.clmNivelServicio.DataPropertyName = "NivelS";
            this.clmNivelServicio.HeaderText = "Nivel de Servicio";
            this.clmNivelServicio.Name = "clmNivelServicio";
            this.clmNivelServicio.ReadOnly = true;
            this.clmNivelServicio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmNivelServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmTarifa
            // 
            this.clmTarifa.DataPropertyName = "Tarifa";
            this.clmTarifa.HeaderText = "Tarifa";
            this.clmTarifa.Name = "clmTarifa";
            this.clmTarifa.ReadOnly = true;
            this.clmTarifa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmTarifa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmMonto
            // 
            this.clmMonto.HeaderText = "Monto";
            this.clmMonto.Name = "clmMonto";
            this.clmMonto.ReadOnly = true;
            this.clmMonto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmAdministracionRegistroPenalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 586);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionRegistroPenalidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Registro de Penalidades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnActualizar;
        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label lblTransportadora;
        private ComboBoxBusqueda cboTransportadora;
        private ComboBoxBusqueda cboPuntoVenta;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmpresaTransporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPuntoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipoPenalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCaso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmProntoAviso;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNivelServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMonto;
    }
}