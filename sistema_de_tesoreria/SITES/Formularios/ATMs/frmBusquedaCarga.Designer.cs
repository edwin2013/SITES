namespace GUILayer
{
    partial class frmBusquedaCarga
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaCarga));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpCargas = new System.Windows.Forms.TableLayoutPanel();
            this.gbDatosCarga = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtHoraFinalizacion = new System.Windows.Forms.TextBox();
            this.txtHoraInicio = new System.Windows.Forms.TextBox();
            this.txtCamara = new System.Windows.Forms.TextBox();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.lblMarchamo = new System.Windows.Forms.Label();
            this.lblRuta = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.lblCamara = new System.Windows.Forms.Label();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.txtMarchamo = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblHoraFinalizacion = new System.Windows.Forms.Label();
            this.dgvMontosCarga = new System.Windows.Forms.DataGridView();
            this.DenominacionCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroMarchamoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCargasAsignadas = new System.Windows.Forms.GroupBox();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.ATMCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColonesCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDolaresCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullCarga = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CartuchoRechazoCarga = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtMarchamoBusqueda = new System.Windows.Forms.TextBox();
            this.lblMarchamoBusqueda = new System.Windows.Forms.Label();
            this.lblATM = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.lblTamanoFuente = new System.Windows.Forms.Label();
            this.tbTamanoFuente = new System.Windows.Forms.TrackBar();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.tlpCargas.SuspendLayout();
            this.gbDatosCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosCarga)).BeginInit();
            this.gbCargasAsignadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTamanoFuente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCargas
            // 
            this.tlpCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCargas.ColumnCount = 2;
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCargas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCargas.Controls.Add(this.gbDatosCarga, 0, 0);
            this.tlpCargas.Controls.Add(this.gbCargasAsignadas, 0, 0);
            this.tlpCargas.Location = new System.Drawing.Point(12, 65);
            this.tlpCargas.Name = "tlpCargas";
            this.tlpCargas.RowCount = 1;
            this.tlpCargas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCargas.Size = new System.Drawing.Size(958, 563);
            this.tlpCargas.TabIndex = 1;
            // 
            // gbDatosCarga
            // 
            this.gbDatosCarga.Controls.Add(this.btnImprimir);
            this.gbDatosCarga.Controls.Add(this.txtHoraFinalizacion);
            this.gbDatosCarga.Controls.Add(this.txtHoraInicio);
            this.gbDatosCarga.Controls.Add(this.txtCamara);
            this.gbDatosCarga.Controls.Add(this.lblHoraInicio);
            this.gbDatosCarga.Controls.Add(this.txtRuta);
            this.gbDatosCarga.Controls.Add(this.lblMarchamo);
            this.gbDatosCarga.Controls.Add(this.lblRuta);
            this.gbDatosCarga.Controls.Add(this.txtObservaciones);
            this.gbDatosCarga.Controls.Add(this.lblManifiesto);
            this.gbDatosCarga.Controls.Add(this.lblCamara);
            this.gbDatosCarga.Controls.Add(this.txtManifiesto);
            this.gbDatosCarga.Controls.Add(this.txtMarchamo);
            this.gbDatosCarga.Controls.Add(this.lblObservaciones);
            this.gbDatosCarga.Controls.Add(this.lblHoraFinalizacion);
            this.gbDatosCarga.Controls.Add(this.dgvMontosCarga);
            this.gbDatosCarga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDatosCarga.Location = new System.Drawing.Point(482, 3);
            this.gbDatosCarga.Name = "gbDatosCarga";
            this.gbDatosCarga.Size = new System.Drawing.Size(473, 557);
            this.gbDatosCarga.TabIndex = 1;
            this.gbDatosCarga.TabStop = false;
            this.gbDatosCarga.Text = "Datos de la Carga";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatAppearance.BorderSize = 2;
            this.btnImprimir.Image = global::GUILayer.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(377, 511);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 40);
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtHoraFinalizacion
            // 
            this.txtHoraFinalizacion.Location = new System.Drawing.Point(93, 45);
            this.txtHoraFinalizacion.Name = "txtHoraFinalizacion";
            this.txtHoraFinalizacion.ReadOnly = true;
            this.txtHoraFinalizacion.Size = new System.Drawing.Size(156, 20);
            this.txtHoraFinalizacion.TabIndex = 5;
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(93, 19);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.ReadOnly = true;
            this.txtHoraInicio.Size = new System.Drawing.Size(156, 20);
            this.txtHoraInicio.TabIndex = 1;
            // 
            // txtCamara
            // 
            this.txtCamara.Location = new System.Drawing.Point(321, 19);
            this.txtCamara.Name = "txtCamara";
            this.txtCamara.ReadOnly = true;
            this.txtCamara.Size = new System.Drawing.Size(146, 20);
            this.txtCamara.TabIndex = 3;
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(38, 23);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(49, 13);
            this.lblHoraInicio.TabIndex = 0;
            this.lblHoraInicio.Text = "H. Inicio:";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(321, 45);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(146, 20);
            this.txtRuta.TabIndex = 7;
            // 
            // lblMarchamo
            // 
            this.lblMarchamo.AutoSize = true;
            this.lblMarchamo.Location = new System.Drawing.Point(255, 75);
            this.lblMarchamo.Name = "lblMarchamo";
            this.lblMarchamo.Size = new System.Drawing.Size(60, 13);
            this.lblMarchamo.TabIndex = 10;
            this.lblMarchamo.Text = "Marchamo:";
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(282, 49);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(33, 13);
            this.lblRuta.TabIndex = 6;
            this.lblRuta.Text = "Ruta:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(93, 97);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(374, 44);
            this.txtObservaciones.TabIndex = 13;
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(29, 75);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManifiesto.TabIndex = 8;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // lblCamara
            // 
            this.lblCamara.AutoSize = true;
            this.lblCamara.Location = new System.Drawing.Point(269, 23);
            this.lblCamara.Name = "lblCamara";
            this.lblCamara.Size = new System.Drawing.Size(46, 13);
            this.lblCamara.TabIndex = 2;
            this.lblCamara.Text = "Cámara:";
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.Location = new System.Drawing.Point(93, 71);
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.ReadOnly = true;
            this.txtManifiesto.Size = new System.Drawing.Size(156, 20);
            this.txtManifiesto.TabIndex = 9;
            // 
            // txtMarchamo
            // 
            this.txtMarchamo.Location = new System.Drawing.Point(321, 71);
            this.txtMarchamo.Name = "txtMarchamo";
            this.txtMarchamo.ReadOnly = true;
            this.txtMarchamo.Size = new System.Drawing.Size(146, 20);
            this.txtMarchamo.TabIndex = 11;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(6, 97);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(81, 13);
            this.lblObservaciones.TabIndex = 12;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // lblHoraFinalizacion
            // 
            this.lblHoraFinalizacion.AutoSize = true;
            this.lblHoraFinalizacion.Location = new System.Drawing.Point(8, 49);
            this.lblHoraFinalizacion.Name = "lblHoraFinalizacion";
            this.lblHoraFinalizacion.Size = new System.Drawing.Size(79, 13);
            this.lblHoraFinalizacion.TabIndex = 4;
            this.lblHoraFinalizacion.Text = "H. Finalización:";
            // 
            // dgvMontosCarga
            // 
            this.dgvMontosCarga.AllowUserToAddRows = false;
            this.dgvMontosCarga.AllowUserToDeleteRows = false;
            this.dgvMontosCarga.AllowUserToOrderColumns = true;
            this.dgvMontosCarga.AllowUserToResizeColumns = false;
            this.dgvMontosCarga.AllowUserToResizeRows = false;
            this.dgvMontosCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMontosCarga.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMontosCarga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontosCarga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMontosCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontosCarga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DenominacionCartuchoCarga,
            this.MontoCartuchoCarga,
            this.CantidadCartuchoCarga,
            this.NumeroCartuchoCarga,
            this.NumeroMarchamoCarga});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMontosCarga.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMontosCarga.EnableHeadersVisualStyles = false;
            this.dgvMontosCarga.GridColor = System.Drawing.Color.Black;
            this.dgvMontosCarga.Location = new System.Drawing.Point(6, 147);
            this.dgvMontosCarga.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMontosCarga.MultiSelect = false;
            this.dgvMontosCarga.Name = "dgvMontosCarga";
            this.dgvMontosCarga.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontosCarga.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMontosCarga.RowHeadersVisible = false;
            this.dgvMontosCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontosCarga.Size = new System.Drawing.Size(461, 358);
            this.dgvMontosCarga.TabIndex = 14;
            // 
            // DenominacionCartuchoCarga
            // 
            this.DenominacionCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DenominacionCartuchoCarga.DataPropertyName = "Denominacion";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Format = "N2";
            this.DenominacionCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle2;
            this.DenominacionCartuchoCarga.HeaderText = "Denominación";
            this.DenominacionCartuchoCarga.Name = "DenominacionCartuchoCarga";
            this.DenominacionCartuchoCarga.ReadOnly = true;
            this.DenominacionCartuchoCarga.Width = 99;
            // 
            // MontoCartuchoCarga
            // 
            this.MontoCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoCartuchoCarga.DataPropertyName = "Monto_carga";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Format = "N2";
            this.MontoCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoCartuchoCarga.HeaderText = "Monto";
            this.MontoCartuchoCarga.Name = "MontoCartuchoCarga";
            this.MontoCartuchoCarga.ReadOnly = true;
            this.MontoCartuchoCarga.Width = 61;
            // 
            // CantidadCartuchoCarga
            // 
            this.CantidadCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadCartuchoCarga.DataPropertyName = "Cantidad_carga";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Format = "N0";
            this.CantidadCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle4;
            this.CantidadCartuchoCarga.HeaderText = "Cantidad";
            this.CantidadCartuchoCarga.Name = "CantidadCartuchoCarga";
            this.CantidadCartuchoCarga.ReadOnly = true;
            this.CantidadCartuchoCarga.Width = 73;
            // 
            // NumeroCartuchoCarga
            // 
            this.NumeroCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumeroCartuchoCarga.DataPropertyName = "Cartucho";
            this.NumeroCartuchoCarga.HeaderText = "N. Cartucho";
            this.NumeroCartuchoCarga.Name = "NumeroCartuchoCarga";
            this.NumeroCartuchoCarga.ReadOnly = true;
            this.NumeroCartuchoCarga.Width = 88;
            // 
            // NumeroMarchamoCarga
            // 
            this.NumeroMarchamoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumeroMarchamoCarga.DataPropertyName = "Marchamo";
            this.NumeroMarchamoCarga.HeaderText = "N. Marchamo";
            this.NumeroMarchamoCarga.Name = "NumeroMarchamoCarga";
            this.NumeroMarchamoCarga.ReadOnly = true;
            this.NumeroMarchamoCarga.Width = 95;
            // 
            // gbCargasAsignadas
            // 
            this.gbCargasAsignadas.Controls.Add(this.cboATM);
            this.gbCargasAsignadas.Controls.Add(this.btnActualizar);
            this.gbCargasAsignadas.Controls.Add(this.dgvCargas);
            this.gbCargasAsignadas.Controls.Add(this.txtMarchamoBusqueda);
            this.gbCargasAsignadas.Controls.Add(this.lblMarchamoBusqueda);
            this.gbCargasAsignadas.Controls.Add(this.lblATM);
            this.gbCargasAsignadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCargasAsignadas.Location = new System.Drawing.Point(3, 3);
            this.gbCargasAsignadas.Name = "gbCargasAsignadas";
            this.gbCargasAsignadas.Size = new System.Drawing.Size(473, 557);
            this.gbCargasAsignadas.TabIndex = 0;
            this.gbCargasAsignadas.TabStop = false;
            this.gbCargasAsignadas.Text = "Búsqueda de Cargas";
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = true;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(72, 19);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(196, 21);
            this.cboATM.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(274, 26);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.AllowUserToOrderColumns = true;
            this.dgvCargas.AllowUserToResizeColumns = false;
            this.dgvCargas.AllowUserToResizeRows = false;
            this.dgvCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATMCarga,
            this.FechaCarga,
            this.MontoColonesCarga,
            this.MontoDolaresCarga,
            this.Tipo,
            this.FullCarga,
            this.CartuchoRechazoCarga});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargas.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.GridColor = System.Drawing.Color.Black;
            this.dgvCargas.Location = new System.Drawing.Point(6, 72);
            this.dgvCargas.MultiSelect = false;
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargas.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(461, 479);
            this.dgvCargas.TabIndex = 5;
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // ATMCarga
            // 
            this.ATMCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ATMCarga.DataPropertyName = "ATM";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            this.ATMCarga.DefaultCellStyle = dataGridViewCellStyle8;
            this.ATMCarga.HeaderText = "ATM";
            this.ATMCarga.Name = "ATMCarga";
            this.ATMCarga.ReadOnly = true;
            this.ATMCarga.Width = 54;
            // 
            // FechaCarga
            // 
            this.FechaCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaCarga.DataPropertyName = "Fecha_asignada";
            this.FechaCarga.HeaderText = "Fecha";
            this.FechaCarga.Name = "FechaCarga";
            this.FechaCarga.ReadOnly = true;
            this.FechaCarga.Width = 61;
            // 
            // MontoColonesCarga
            // 
            this.MontoColonesCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColonesCarga.DataPropertyName = "Monto_carga_colones";
            dataGridViewCellStyle9.Format = "N2";
            this.MontoColonesCarga.DefaultCellStyle = dataGridViewCellStyle9;
            this.MontoColonesCarga.HeaderText = "Colones";
            this.MontoColonesCarga.Name = "MontoColonesCarga";
            this.MontoColonesCarga.ReadOnly = true;
            this.MontoColonesCarga.Width = 69;
            // 
            // MontoDolaresCarga
            // 
            this.MontoDolaresCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoDolaresCarga.DataPropertyName = "Monto_carga_dolares";
            dataGridViewCellStyle10.Format = "N2";
            this.MontoDolaresCarga.DefaultCellStyle = dataGridViewCellStyle10;
            this.MontoDolaresCarga.HeaderText = "Dólares";
            this.MontoDolaresCarga.Name = "MontoDolaresCarga";
            this.MontoDolaresCarga.ReadOnly = true;
            this.MontoDolaresCarga.Width = 67;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // FullCarga
            // 
            this.FullCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FullCarga.DataPropertyName = "ATM_full";
            this.FullCarga.HeaderText = "Full";
            this.FullCarga.Name = "FullCarga";
            this.FullCarga.ReadOnly = true;
            this.FullCarga.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FullCarga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FullCarga.Width = 47;
            // 
            // CartuchoRechazoCarga
            // 
            this.CartuchoRechazoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CartuchoRechazoCarga.DataPropertyName = "Cartucho_rechazo";
            this.CartuchoRechazoCarga.HeaderText = "C. Rechazo";
            this.CartuchoRechazoCarga.Name = "CartuchoRechazoCarga";
            this.CartuchoRechazoCarga.ReadOnly = true;
            this.CartuchoRechazoCarga.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CartuchoRechazoCarga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CartuchoRechazoCarga.Width = 87;
            // 
            // txtMarchamoBusqueda
            // 
            this.txtMarchamoBusqueda.Location = new System.Drawing.Point(72, 46);
            this.txtMarchamoBusqueda.Name = "txtMarchamoBusqueda";
            this.txtMarchamoBusqueda.Size = new System.Drawing.Size(196, 20);
            this.txtMarchamoBusqueda.TabIndex = 3;
            // 
            // lblMarchamoBusqueda
            // 
            this.lblMarchamoBusqueda.AutoSize = true;
            this.lblMarchamoBusqueda.Location = new System.Drawing.Point(6, 50);
            this.lblMarchamoBusqueda.Name = "lblMarchamoBusqueda";
            this.lblMarchamoBusqueda.Size = new System.Drawing.Size(60, 13);
            this.lblMarchamoBusqueda.TabIndex = 2;
            this.lblMarchamoBusqueda.Text = "Marchamo:";
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(33, 23);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(33, 13);
            this.lblATM.TabIndex = 0;
            this.lblATM.Text = "ATM:";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(871, 634);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.lblTamanoFuente);
            this.pnlFondo.Controls.Add(this.tbTamanoFuente);
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(982, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // lblTamanoFuente
            // 
            this.lblTamanoFuente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTamanoFuente.AutoSize = true;
            this.lblTamanoFuente.Location = new System.Drawing.Point(762, 23);
            this.lblTamanoFuente.Name = "lblTamanoFuente";
            this.lblTamanoFuente.Size = new System.Drawing.Size(97, 13);
            this.lblTamanoFuente.TabIndex = 2;
            this.lblTamanoFuente.Text = "Tamaño de Fuente";
            this.lblTamanoFuente.Click += new System.EventHandler(this.lblTamanoFuente_Click);
            // 
            // tbTamanoFuente
            // 
            this.tbTamanoFuente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTamanoFuente.LargeChange = 1;
            this.tbTamanoFuente.Location = new System.Drawing.Point(865, 7);
            this.tbTamanoFuente.Maximum = 4;
            this.tbTamanoFuente.Minimum = 1;
            this.tbTamanoFuente.Name = "tbTamanoFuente";
            this.tbTamanoFuente.Size = new System.Drawing.Size(104, 45);
            this.tbTamanoFuente.TabIndex = 1;
            this.tbTamanoFuente.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbTamanoFuente.Value = 1;
            this.tbTamanoFuente.Scroll += new System.EventHandler(this.tbTamanoFuente_Scroll);
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
            // frmBusquedaCarga
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(982, 686);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tlpCargas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(990, 720);
            this.Name = "frmBusquedaCarga";
            this.ShowInTaskbar = false;
            this.Text = "Buscar Carga";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpCargas.ResumeLayout(false);
            this.gbDatosCarga.ResumeLayout(false);
            this.gbDatosCarga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosCarga)).EndInit();
            this.gbCargasAsignadas.ResumeLayout(false);
            this.gbCargasAsignadas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.pnlFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTamanoFuente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCargas;
        private System.Windows.Forms.GroupBox gbDatosCarga;
        private System.Windows.Forms.DataGridView dgvMontosCarga;
        private System.Windows.Forms.GroupBox gbCargasAsignadas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TextBox txtHoraFinalizacion;
        private System.Windows.Forms.TextBox txtHoraInicio;
        private System.Windows.Forms.TextBox txtCamara;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label lblMarchamo;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.Label lblCamara;
        private System.Windows.Forms.TextBox txtManifiesto;
        private System.Windows.Forms.TextBox txtMarchamo;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Label lblHoraFinalizacion;
        private System.Windows.Forms.Label lblMarchamoBusqueda;
        private System.Windows.Forms.TextBox txtMarchamoBusqueda;
        private System.Windows.Forms.Button btnActualizar;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATMCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColonesCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDolaresCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FullCarga;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CartuchoRechazoCarga;
        private System.Windows.Forms.TrackBar tbTamanoFuente;
        private System.Windows.Forms.Label lblTamanoFuente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenominacionCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroMarchamoCarga;

    }
}