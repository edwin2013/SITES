namespace GUILayer
{
    partial class frmRevisionRemanentesATMs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRevisionRemanentesATMs));
            this.gbMontosRemanentes = new System.Windows.Forms.GroupBox();
            this.dgvRemanentes = new System.Windows.Forms.DataGridView();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.lblVariacion = new System.Windows.Forms.Label();
            this.nudVariacion = new System.Windows.Forms.NumericUpDown();
            this.chkProgramados = new System.Windows.Forms.CheckBox();
            this.chkCargados = new System.Windows.Forms.CheckBox();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.lblATM = new System.Windows.Forms.Label();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.gbMontosEsperados = new System.Windows.Forms.GroupBox();
            this.dgvEsperados = new System.Windows.Forms.DataGridView();
            this.gbMontosTotales = new System.Windows.Forms.GroupBox();
            this.dgvTotales = new System.Windows.Forms.DataGridView();
            this.gbVariacion = new System.Windows.Forms.GroupBox();
            this.lblVariacionDolares = new System.Windows.Forms.Label();
            this.txtVariacionDolares = new System.Windows.Forms.TextBox();
            this.lblVariacionColones = new System.Windows.Forms.Label();
            this.txtVariacionColones = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.chkQuincena = new System.Windows.Forms.CheckBox();
            this.lblAviso = new System.Windows.Forms.Label();
            this.gbMontosRemanentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemanentes)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVariacion)).BeginInit();
            this.tlpDatos.SuspendLayout();
            this.gbMontosEsperados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsperados)).BeginInit();
            this.gbMontosTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).BeginInit();
            this.gbVariacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMontosRemanentes
            // 
            this.gbMontosRemanentes.Controls.Add(this.dgvRemanentes);
            this.gbMontosRemanentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMontosRemanentes.Location = new System.Drawing.Point(0, 0);
            this.gbMontosRemanentes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbMontosRemanentes.Name = "gbMontosRemanentes";
            this.gbMontosRemanentes.Size = new System.Drawing.Size(894, 178);
            this.gbMontosRemanentes.TabIndex = 0;
            this.gbMontosRemanentes.TabStop = false;
            this.gbMontosRemanentes.Text = "Montos Remanentes";
            // 
            // dgvRemanentes
            // 
            this.dgvRemanentes.AllowUserToAddRows = false;
            this.dgvRemanentes.AllowUserToDeleteRows = false;
            this.dgvRemanentes.AllowUserToOrderColumns = true;
            this.dgvRemanentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemanentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRemanentes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRemanentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRemanentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemanentes.EnableHeadersVisualStyles = false;
            this.dgvRemanentes.GridColor = System.Drawing.Color.Black;
            this.dgvRemanentes.Location = new System.Drawing.Point(6, 19);
            this.dgvRemanentes.Name = "dgvRemanentes";
            this.dgvRemanentes.ReadOnly = true;
            this.dgvRemanentes.RowHeadersVisible = false;
            this.dgvRemanentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRemanentes.Size = new System.Drawing.Size(882, 153);
            this.dgvRemanentes.StandardTab = true;
            this.dgvRemanentes.TabIndex = 0;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(43, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(94, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(251, 21);
            this.dtpFecha.TabIndex = 1;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(918, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.chkQuincena);
            this.gbFiltro.Controls.Add(this.cboTransportadora);
            this.gbFiltro.Controls.Add(this.lblTransportadora);
            this.gbFiltro.Controls.Add(this.lblVariacion);
            this.gbFiltro.Controls.Add(this.nudVariacion);
            this.gbFiltro.Controls.Add(this.chkProgramados);
            this.gbFiltro.Controls.Add(this.chkCargados);
            this.gbFiltro.Controls.Add(this.cboATM);
            this.gbFiltro.Controls.Add(this.lblATM);
            this.gbFiltro.Controls.Add(this.lblFecha);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Location = new System.Drawing.Point(12, 66);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(768, 73);
            this.gbFiltro.TabIndex = 1;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(94, 46);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(251, 21);
            this.cboTransportadora.TabIndex = 5;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(6, 50);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(82, 13);
            this.lblTransportadora.TabIndex = 4;
            this.lblTransportadora.Text = "Transportadora:";
            // 
            // lblVariacion
            // 
            this.lblVariacion.AutoSize = true;
            this.lblVariacion.Location = new System.Drawing.Point(351, 50);
            this.lblVariacion.Name = "lblVariacion";
            this.lblVariacion.Size = new System.Drawing.Size(54, 13);
            this.lblVariacion.TabIndex = 6;
            this.lblVariacion.Text = "Variación:";
            // 
            // nudVariacion
            // 
            this.nudVariacion.Location = new System.Drawing.Point(411, 46);
            this.nudVariacion.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudVariacion.Name = "nudVariacion";
            this.nudVariacion.Size = new System.Drawing.Size(68, 20);
            this.nudVariacion.TabIndex = 7;
            this.nudVariacion.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // chkProgramados
            // 
            this.chkProgramados.AutoSize = true;
            this.chkProgramados.Checked = true;
            this.chkProgramados.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProgramados.Location = new System.Drawing.Point(500, 50);
            this.chkProgramados.Name = "chkProgramados";
            this.chkProgramados.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkProgramados.Size = new System.Drawing.Size(88, 17);
            this.chkProgramados.TabIndex = 8;
            this.chkProgramados.Text = "Programados";
            this.chkProgramados.UseVisualStyleBackColor = true;
            this.chkProgramados.CheckedChanged += new System.EventHandler(this.chkProgramados_CheckedChanged);
            // 
            // chkCargados
            // 
            this.chkCargados.AutoSize = true;
            this.chkCargados.Location = new System.Drawing.Point(594, 50);
            this.chkCargados.Name = "chkCargados";
            this.chkCargados.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCargados.Size = new System.Drawing.Size(71, 17);
            this.chkCargados.TabIndex = 9;
            this.chkCargados.Text = "Cargados";
            this.chkCargados.UseVisualStyleBackColor = true;
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = true;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(411, 19);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(254, 21);
            this.cboATM.TabIndex = 3;
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(372, 23);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(33, 13);
            this.lblATM.TabIndex = 2;
            this.lblATM.Text = "ATM:";
            // 
            // tlpDatos
            // 
            this.tlpDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDatos.ColumnCount = 1;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDatos.Controls.Add(this.gbMontosEsperados, 0, 2);
            this.tlpDatos.Controls.Add(this.gbMontosTotales, 0, 1);
            this.tlpDatos.Controls.Add(this.gbMontosRemanentes, 0, 0);
            this.tlpDatos.Location = new System.Drawing.Point(12, 145);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 3;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDatos.Size = new System.Drawing.Size(894, 363);
            this.tlpDatos.TabIndex = 3;
            // 
            // gbMontosEsperados
            // 
            this.gbMontosEsperados.Controls.Add(this.dgvEsperados);
            this.gbMontosEsperados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMontosEsperados.Location = new System.Drawing.Point(0, 271);
            this.gbMontosEsperados.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbMontosEsperados.Name = "gbMontosEsperados";
            this.gbMontosEsperados.Size = new System.Drawing.Size(894, 89);
            this.gbMontosEsperados.TabIndex = 2;
            this.gbMontosEsperados.TabStop = false;
            this.gbMontosEsperados.Text = "Montos Esperados";
            // 
            // dgvEsperados
            // 
            this.dgvEsperados.AllowUserToAddRows = false;
            this.dgvEsperados.AllowUserToDeleteRows = false;
            this.dgvEsperados.AllowUserToOrderColumns = true;
            this.dgvEsperados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEsperados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEsperados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEsperados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEsperados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEsperados.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEsperados.EnableHeadersVisualStyles = false;
            this.dgvEsperados.GridColor = System.Drawing.Color.Black;
            this.dgvEsperados.Location = new System.Drawing.Point(6, 19);
            this.dgvEsperados.Name = "dgvEsperados";
            this.dgvEsperados.ReadOnly = true;
            this.dgvEsperados.RowHeadersVisible = false;
            this.dgvEsperados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEsperados.Size = new System.Drawing.Size(882, 64);
            this.dgvEsperados.StandardTab = true;
            this.dgvEsperados.TabIndex = 0;
            // 
            // gbMontosTotales
            // 
            this.gbMontosTotales.Controls.Add(this.dgvTotales);
            this.gbMontosTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMontosTotales.Location = new System.Drawing.Point(0, 181);
            this.gbMontosTotales.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbMontosTotales.Name = "gbMontosTotales";
            this.gbMontosTotales.Size = new System.Drawing.Size(894, 87);
            this.gbMontosTotales.TabIndex = 1;
            this.gbMontosTotales.TabStop = false;
            this.gbMontosTotales.Text = "Montos Totales";
            // 
            // dgvTotales
            // 
            this.dgvTotales.AllowUserToAddRows = false;
            this.dgvTotales.AllowUserToDeleteRows = false;
            this.dgvTotales.AllowUserToOrderColumns = true;
            this.dgvTotales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTotales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTotales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotales.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTotales.EnableHeadersVisualStyles = false;
            this.dgvTotales.GridColor = System.Drawing.Color.Black;
            this.dgvTotales.Location = new System.Drawing.Point(6, 19);
            this.dgvTotales.Name = "dgvTotales";
            this.dgvTotales.ReadOnly = true;
            this.dgvTotales.RowHeadersVisible = false;
            this.dgvTotales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTotales.Size = new System.Drawing.Size(882, 62);
            this.dgvTotales.StandardTab = true;
            this.dgvTotales.TabIndex = 0;
            // 
            // gbVariacion
            // 
            this.gbVariacion.Controls.Add(this.lblVariacionDolares);
            this.gbVariacion.Controls.Add(this.txtVariacionDolares);
            this.gbVariacion.Controls.Add(this.lblVariacionColones);
            this.gbVariacion.Controls.Add(this.txtVariacionColones);
            this.gbVariacion.Location = new System.Drawing.Point(786, 68);
            this.gbVariacion.Name = "gbVariacion";
            this.gbVariacion.Size = new System.Drawing.Size(120, 71);
            this.gbVariacion.TabIndex = 2;
            this.gbVariacion.TabStop = false;
            this.gbVariacion.Text = "Variación";
            // 
            // lblVariacionDolares
            // 
            this.lblVariacionDolares.AutoSize = true;
            this.lblVariacionDolares.Location = new System.Drawing.Point(6, 49);
            this.lblVariacionDolares.Name = "lblVariacionDolares";
            this.lblVariacionDolares.Size = new System.Drawing.Size(33, 13);
            this.lblVariacionDolares.TabIndex = 3;
            this.lblVariacionDolares.Text = "USD:";
            // 
            // txtVariacionDolares
            // 
            this.txtVariacionDolares.Location = new System.Drawing.Point(45, 45);
            this.txtVariacionDolares.Name = "txtVariacionDolares";
            this.txtVariacionDolares.ReadOnly = true;
            this.txtVariacionDolares.Size = new System.Drawing.Size(69, 20);
            this.txtVariacionDolares.TabIndex = 2;
            // 
            // lblVariacionColones
            // 
            this.lblVariacionColones.AutoSize = true;
            this.lblVariacionColones.Location = new System.Drawing.Point(7, 23);
            this.lblVariacionColones.Name = "lblVariacionColones";
            this.lblVariacionColones.Size = new System.Drawing.Size(32, 13);
            this.lblVariacionColones.TabIndex = 1;
            this.lblVariacionColones.Text = "CRC:";
            // 
            // txtVariacionColones
            // 
            this.txtVariacionColones.Location = new System.Drawing.Point(45, 19);
            this.txtVariacionColones.Name = "txtVariacionColones";
            this.txtVariacionColones.ReadOnly = true;
            this.txtVariacionColones.Size = new System.Drawing.Size(69, 20);
            this.txtVariacionColones.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(709, 514);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(810, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // chkQuincena
            // 
            this.chkQuincena.AutoSize = true;
            this.chkQuincena.Location = new System.Drawing.Point(671, 50);
            this.chkQuincena.Name = "chkQuincena";
            this.chkQuincena.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkQuincena.Size = new System.Drawing.Size(72, 17);
            this.chkQuincena.TabIndex = 10;
            this.chkQuincena.Text = "Quincena";
            this.chkQuincena.UseVisualStyleBackColor = true;
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(68, 520);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(571, 24);
            this.lblAviso.TabIndex = 6;
            this.lblAviso.Text = "Existe una Inconsistencia! Favor realizar el proceso Manual.";
            this.lblAviso.Visible = false;
            // 
            // frmRevisionRemanentesATMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 566);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.gbVariacion);
            this.Controls.Add(this.tlpDatos);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRevisionRemanentesATMs";
            this.Text = "Revisión de Remanentes de ATM\'s";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRevisionRemanentesATMs_Load);
            this.gbMontosRemanentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemanentes)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVariacion)).EndInit();
            this.tlpDatos.ResumeLayout(false);
            this.gbMontosEsperados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsperados)).EndInit();
            this.gbMontosTotales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).EndInit();
            this.gbVariacion.ResumeLayout(false);
            this.gbVariacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMontosRemanentes;
        private System.Windows.Forms.DataGridView dgvRemanentes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Label lblFecha;
        internal System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox gbFiltro;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.CheckBox chkCargados;
        private System.Windows.Forms.CheckBox chkProgramados;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.GroupBox gbMontosEsperados;
        private System.Windows.Forms.DataGridView dgvEsperados;
        private System.Windows.Forms.GroupBox gbMontosTotales;
        private System.Windows.Forms.DataGridView dgvTotales;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.Label lblVariacion;
        private System.Windows.Forms.NumericUpDown nudVariacion;
        private System.Windows.Forms.GroupBox gbVariacion;
        private System.Windows.Forms.TextBox txtVariacionColones;
        private System.Windows.Forms.Label lblVariacionDolares;
        private System.Windows.Forms.TextBox txtVariacionDolares;
        private System.Windows.Forms.Label lblVariacionColones;
        private System.Windows.Forms.CheckBox chkQuincena;
        private System.Windows.Forms.Label lblAviso;
    }
}