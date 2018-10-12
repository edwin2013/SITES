namespace GUILayer
{
    partial class frmIngresoManifiestoATMsFull
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoManifiestoATMsFull));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.cboEsquema = new GUILayer.ComboBoxBusqueda();
            this.lblEsquema = new System.Windows.Forms.Label();
            this.pnlDatosManifiesto = new System.Windows.Forms.Panel();
            this.txtMarchamo = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiesto = new System.Windows.Forms.Label();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.pnlENA = new System.Windows.Forms.Panel();
            this.lblMarchamoENAB = new System.Windows.Forms.Label();
            this.txtMarchamoAdicionalENA = new System.Windows.Forms.TextBox();
            this.lblMarchamoAdicionalENA = new System.Windows.Forms.Label();
            this.txtMarchamoENAB = new System.Windows.Forms.TextBox();
            this.lblMarchamoENAA = new System.Windows.Forms.Label();
            this.txtMarchamoENAA = new System.Windows.Forms.TextBox();
            this.lblMarchamo = new System.Windows.Forms.Label();
            this.btnNuevoManifiesto = new System.Windows.Forms.Button();
            this.btnGuardarManifiesto = new System.Windows.Forms.Button();
            this.btnCancelarManifiesto = new System.Windows.Forms.Button();
            this.gbBusquedaManifiestosFull = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarManifiesto = new System.Windows.Forms.Button();
            this.txtCodigoManifiestoBuscado = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiestoFullBuscado = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pdManifiesto = new System.Drawing.Printing.PrintDocument();
            this.pdOpcionesImpresion = new System.Windows.Forms.PrintDialog();
            this.chkBolsaRechazoFull = new System.Windows.Forms.CheckBox();
            this.txtBolsaRechazoFull = new System.Windows.Forms.TextBox();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatosManifiesto.SuspendLayout();
            this.pnlDatosManifiesto.SuspendLayout();
            this.pnlENA.SuspendLayout();
            this.gbBusquedaManifiestosFull.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(700, 50);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(373, 48);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.cboEsquema);
            this.gbDatosManifiesto.Controls.Add(this.lblEsquema);
            this.gbDatosManifiesto.Controls.Add(this.pnlDatosManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.btnNuevoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.btnGuardarManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.btnCancelarManifiesto);
            this.gbDatosManifiesto.Location = new System.Drawing.Point(332, 56);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(356, 222);
            this.gbDatosManifiesto.TabIndex = 2;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos del Manifiesto Full";
            // 
            // cboEsquema
            // 
            this.cboEsquema.Busqueda = false;
            this.cboEsquema.ListaMostrada = null;
            this.cboEsquema.Location = new System.Drawing.Point(143, 149);
            this.cboEsquema.Name = "cboEsquema";
            this.cboEsquema.Size = new System.Drawing.Size(207, 21);
            this.cboEsquema.TabIndex = 2;
            this.cboEsquema.TabStop = false;
            // 
            // lblEsquema
            // 
            this.lblEsquema.AutoSize = true;
            this.lblEsquema.Location = new System.Drawing.Point(83, 153);
            this.lblEsquema.Name = "lblEsquema";
            this.lblEsquema.Size = new System.Drawing.Size(54, 13);
            this.lblEsquema.TabIndex = 1;
            this.lblEsquema.Text = "Esquema:";
            // 
            // pnlDatosManifiesto
            // 
            this.pnlDatosManifiesto.Controls.Add(this.txtMarchamo);
            this.pnlDatosManifiesto.Controls.Add(this.lblCodigoManifiesto);
            this.pnlDatosManifiesto.Controls.Add(this.txtCodigoManifiesto);
            this.pnlDatosManifiesto.Controls.Add(this.pnlENA);
            this.pnlDatosManifiesto.Controls.Add(this.lblMarchamo);
            this.pnlDatosManifiesto.Enabled = false;
            this.pnlDatosManifiesto.Location = new System.Drawing.Point(0, 19);
            this.pnlDatosManifiesto.Name = "pnlDatosManifiesto";
            this.pnlDatosManifiesto.Size = new System.Drawing.Size(356, 124);
            this.pnlDatosManifiesto.TabIndex = 0;
            // 
            // txtMarchamo
            // 
            this.txtMarchamo.BackColor = System.Drawing.Color.PeachPuff;
            this.txtMarchamo.Location = new System.Drawing.Point(143, 0);
            this.txtMarchamo.Name = "txtMarchamo";
            this.txtMarchamo.Size = new System.Drawing.Size(207, 20);
            this.txtMarchamo.TabIndex = 1;
            this.txtMarchamo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarchamo_KeyDown);
            // 
            // lblCodigoManifiesto
            // 
            this.lblCodigoManifiesto.AutoSize = true;
            this.lblCodigoManifiesto.Location = new System.Drawing.Point(27, 108);
            this.lblCodigoManifiesto.Name = "lblCodigoManifiesto";
            this.lblCodigoManifiesto.Size = new System.Drawing.Size(110, 13);
            this.lblCodigoManifiesto.TabIndex = 3;
            this.lblCodigoManifiesto.Text = "Manifiesto BNA/ENA:";
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(143, 104);
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(207, 20);
            this.txtCodigoManifiesto.TabIndex = 4;
            this.txtCodigoManifiesto.Enter += new System.EventHandler(this.txtCodigoManifiesto_Enter);
            this.txtCodigoManifiesto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoManifiesto_KeyDown);
            // 
            // pnlENA
            // 
            this.pnlENA.Controls.Add(this.lblMarchamoENAB);
            this.pnlENA.Controls.Add(this.txtMarchamoAdicionalENA);
            this.pnlENA.Controls.Add(this.lblMarchamoAdicionalENA);
            this.pnlENA.Controls.Add(this.txtMarchamoENAB);
            this.pnlENA.Controls.Add(this.lblMarchamoENAA);
            this.pnlENA.Controls.Add(this.txtMarchamoENAA);
            this.pnlENA.Enabled = false;
            this.pnlENA.Location = new System.Drawing.Point(0, 26);
            this.pnlENA.Name = "pnlENA";
            this.pnlENA.Size = new System.Drawing.Size(356, 72);
            this.pnlENA.TabIndex = 2;
            // 
            // lblMarchamoENAB
            // 
            this.lblMarchamoENAB.AutoSize = true;
            this.lblMarchamoENAB.Location = new System.Drawing.Point(43, 56);
            this.lblMarchamoENAB.Name = "lblMarchamoENAB";
            this.lblMarchamoENAB.Size = new System.Drawing.Size(94, 13);
            this.lblMarchamoENAB.TabIndex = 4;
            this.lblMarchamoENAB.Text = "Marchamo ENA 2:";
            // 
            // txtMarchamoAdicionalENA
            // 
            this.txtMarchamoAdicionalENA.BackColor = System.Drawing.Color.PeachPuff;
            this.txtMarchamoAdicionalENA.Location = new System.Drawing.Point(143, 0);
            this.txtMarchamoAdicionalENA.Name = "txtMarchamoAdicionalENA";
            this.txtMarchamoAdicionalENA.Size = new System.Drawing.Size(207, 20);
            this.txtMarchamoAdicionalENA.TabIndex = 1;
            this.txtMarchamoAdicionalENA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarchamoAdicionalENA_KeyDown);
            // 
            // lblMarchamoAdicionalENA
            // 
            this.lblMarchamoAdicionalENA.AutoSize = true;
            this.lblMarchamoAdicionalENA.Location = new System.Drawing.Point(6, 4);
            this.lblMarchamoAdicionalENA.Name = "lblMarchamoAdicionalENA";
            this.lblMarchamoAdicionalENA.Size = new System.Drawing.Size(131, 13);
            this.lblMarchamoAdicionalENA.TabIndex = 0;
            this.lblMarchamoAdicionalENA.Text = "Marchamo Adicional ENA:";
            // 
            // txtMarchamoENAB
            // 
            this.txtMarchamoENAB.BackColor = System.Drawing.Color.PeachPuff;
            this.txtMarchamoENAB.Location = new System.Drawing.Point(143, 52);
            this.txtMarchamoENAB.Name = "txtMarchamoENAB";
            this.txtMarchamoENAB.Size = new System.Drawing.Size(207, 20);
            this.txtMarchamoENAB.TabIndex = 5;
            this.txtMarchamoENAB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarchamoENAB_KeyDown);
            // 
            // lblMarchamoENAA
            // 
            this.lblMarchamoENAA.AutoSize = true;
            this.lblMarchamoENAA.Location = new System.Drawing.Point(43, 30);
            this.lblMarchamoENAA.Name = "lblMarchamoENAA";
            this.lblMarchamoENAA.Size = new System.Drawing.Size(94, 13);
            this.lblMarchamoENAA.TabIndex = 2;
            this.lblMarchamoENAA.Text = "Marchamo ENA 1:";
            // 
            // txtMarchamoENAA
            // 
            this.txtMarchamoENAA.BackColor = System.Drawing.Color.PeachPuff;
            this.txtMarchamoENAA.Location = new System.Drawing.Point(143, 26);
            this.txtMarchamoENAA.Name = "txtMarchamoENAA";
            this.txtMarchamoENAA.Size = new System.Drawing.Size(207, 20);
            this.txtMarchamoENAA.TabIndex = 3;
            this.txtMarchamoENAA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarchamoENAA_KeyDown);
            // 
            // lblMarchamo
            // 
            this.lblMarchamo.AutoSize = true;
            this.lblMarchamo.Location = new System.Drawing.Point(25, 4);
            this.lblMarchamo.Name = "lblMarchamo";
            this.lblMarchamo.Size = new System.Drawing.Size(112, 13);
            this.lblMarchamo.TabIndex = 0;
            this.lblMarchamo.Text = "Marchamo BNA/ENA:";
            // 
            // btnNuevoManifiesto
            // 
            this.btnNuevoManifiesto.FlatAppearance.BorderSize = 2;
            this.btnNuevoManifiesto.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNuevoManifiesto.Location = new System.Drawing.Point(68, 176);
            this.btnNuevoManifiesto.Name = "btnNuevoManifiesto";
            this.btnNuevoManifiesto.Size = new System.Drawing.Size(90, 40);
            this.btnNuevoManifiesto.TabIndex = 3;
            this.btnNuevoManifiesto.Text = "Nuevo";
            this.btnNuevoManifiesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevoManifiesto.UseVisualStyleBackColor = false;
            this.btnNuevoManifiesto.Click += new System.EventHandler(this.btnNuevoManifiesto_Click);
            // 
            // btnGuardarManifiesto
            // 
            this.btnGuardarManifiesto.Enabled = false;
            this.btnGuardarManifiesto.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardarManifiesto.Location = new System.Drawing.Point(260, 176);
            this.btnGuardarManifiesto.Name = "btnGuardarManifiesto";
            this.btnGuardarManifiesto.Size = new System.Drawing.Size(90, 40);
            this.btnGuardarManifiesto.TabIndex = 5;
            this.btnGuardarManifiesto.Text = "Guardar";
            this.btnGuardarManifiesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarManifiesto.UseVisualStyleBackColor = false;
            this.btnGuardarManifiesto.Click += new System.EventHandler(this.btnGuardarManifiesto_Click);
            // 
            // btnCancelarManifiesto
            // 
            this.btnCancelarManifiesto.Enabled = false;
            this.btnCancelarManifiesto.FlatAppearance.BorderSize = 2;
            this.btnCancelarManifiesto.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelarManifiesto.Location = new System.Drawing.Point(164, 176);
            this.btnCancelarManifiesto.Name = "btnCancelarManifiesto";
            this.btnCancelarManifiesto.Size = new System.Drawing.Size(90, 40);
            this.btnCancelarManifiesto.TabIndex = 4;
            this.btnCancelarManifiesto.TabStop = false;
            this.btnCancelarManifiesto.Text = "Cancelar";
            this.btnCancelarManifiesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarManifiesto.UseVisualStyleBackColor = false;
            this.btnCancelarManifiesto.Click += new System.EventHandler(this.btnCancelarManifiesto_Click);
            // 
            // gbBusquedaManifiestosFull
            // 
            this.gbBusquedaManifiestosFull.Controls.Add(this.dgvManifiestos);
            this.gbBusquedaManifiestosFull.Controls.Add(this.btnBuscarManifiesto);
            this.gbBusquedaManifiestosFull.Controls.Add(this.txtCodigoManifiestoBuscado);
            this.gbBusquedaManifiestosFull.Controls.Add(this.lblCodigoManifiestoFullBuscado);
            this.gbBusquedaManifiestosFull.Location = new System.Drawing.Point(12, 56);
            this.gbBusquedaManifiestosFull.Name = "gbBusquedaManifiestosFull";
            this.gbBusquedaManifiestosFull.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbBusquedaManifiestosFull.Size = new System.Drawing.Size(314, 222);
            this.gbBusquedaManifiestosFull.TabIndex = 1;
            this.gbBusquedaManifiestosFull.TabStop = false;
            this.gbBusquedaManifiestosFull.Text = "Búsqueda de Manifiestos Full";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvManifiestos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManifiestos.BackgroundColor = System.Drawing.Color.White;
            this.dgvManifiestos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvManifiestos.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.GridColor = System.Drawing.Color.Black;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 65);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvManifiestos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(302, 151);
            this.dgvManifiestos.TabIndex = 3;
            this.dgvManifiestos.TabStop = false;
            this.dgvManifiestos.SelectionChanged += new System.EventHandler(this.dgvManifiestos_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Código de Manifiesto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // btnBuscarManifiesto
            // 
            this.btnBuscarManifiesto.Enabled = false;
            this.btnBuscarManifiesto.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscarManifiesto.Location = new System.Drawing.Point(218, 19);
            this.btnBuscarManifiesto.Name = "btnBuscarManifiesto";
            this.btnBuscarManifiesto.Size = new System.Drawing.Size(90, 40);
            this.btnBuscarManifiesto.TabIndex = 2;
            this.btnBuscarManifiesto.TabStop = false;
            this.btnBuscarManifiesto.Text = "Buscar";
            this.btnBuscarManifiesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarManifiesto.UseVisualStyleBackColor = false;
            this.btnBuscarManifiesto.Click += new System.EventHandler(this.btnBuscarManifiesto_Click);
            // 
            // txtCodigoManifiestoBuscado
            // 
            this.txtCodigoManifiestoBuscado.Location = new System.Drawing.Point(51, 29);
            this.txtCodigoManifiestoBuscado.Name = "txtCodigoManifiestoBuscado";
            this.txtCodigoManifiestoBuscado.Size = new System.Drawing.Size(161, 20);
            this.txtCodigoManifiestoBuscado.TabIndex = 1;
            this.txtCodigoManifiestoBuscado.TextChanged += new System.EventHandler(this.txtCodigoManifiestoBuscado_TextChanged);
            this.txtCodigoManifiestoBuscado.Enter += new System.EventHandler(this.txtCodigoManifiestoBuscado_Enter);
            // 
            // lblCodigoManifiestoFullBuscado
            // 
            this.lblCodigoManifiestoFullBuscado.AutoSize = true;
            this.lblCodigoManifiestoFullBuscado.Location = new System.Drawing.Point(6, 33);
            this.lblCodigoManifiestoFullBuscado.Name = "lblCodigoManifiestoFullBuscado";
            this.lblCodigoManifiestoFullBuscado.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiestoFullBuscado.TabIndex = 0;
            this.lblCodigoManifiestoFullBuscado.Text = "Código:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::GUILayer.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(400, 284);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 40);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(496, 284);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(592, 284);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // pdOpcionesImpresion
            // 
            this.pdOpcionesImpresion.UseEXDialog = true;
            // 
            // chkBolsaRechazoFull
            // 
            this.chkBolsaRechazoFull.AutoSize = true;
            this.chkBolsaRechazoFull.Location = new System.Drawing.Point(21, 297);
            this.chkBolsaRechazoFull.Name = "chkBolsaRechazoFull";
            this.chkBolsaRechazoFull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBolsaRechazoFull.Size = new System.Drawing.Size(116, 17);
            this.chkBolsaRechazoFull.TabIndex = 8;
            this.chkBolsaRechazoFull.Text = "Bolsa de Rechazo:";
            this.chkBolsaRechazoFull.UseVisualStyleBackColor = true;
            // 
            // txtBolsaRechazoFull
            // 
            this.txtBolsaRechazoFull.BackColor = System.Drawing.Color.PaleGreen;
            this.txtBolsaRechazoFull.Enabled = false;
            this.txtBolsaRechazoFull.Location = new System.Drawing.Point(143, 295);
            this.txtBolsaRechazoFull.Name = "txtBolsaRechazoFull";
            this.txtBolsaRechazoFull.Size = new System.Drawing.Size(207, 20);
            this.txtBolsaRechazoFull.TabIndex = 9;
            // 
            // frmIngresoManifiestoATMsFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(700, 336);
            this.ControlBox = false;
            this.Controls.Add(this.chkBolsaRechazoFull);
            this.Controls.Add(this.txtBolsaRechazoFull);
            this.Controls.Add(this.gbDatosManifiesto);
            this.Controls.Add(this.gbBusquedaManifiestosFull);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIngresoManifiestoATMsFull";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de Manifiestos de ATM\'s Full";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            this.pnlDatosManifiesto.ResumeLayout(false);
            this.pnlDatosManifiesto.PerformLayout();
            this.pnlENA.ResumeLayout(false);
            this.pnlENA.PerformLayout();
            this.gbBusquedaManifiestosFull.ResumeLayout(false);
            this.gbBusquedaManifiestosFull.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.Panel pnlDatosManifiesto;
        private System.Windows.Forms.TextBox txtMarchamo;
        private System.Windows.Forms.Label lblCodigoManifiesto;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Panel pnlENA;
        private System.Windows.Forms.Label lblMarchamoENAB;
        private System.Windows.Forms.TextBox txtMarchamoAdicionalENA;
        private System.Windows.Forms.Label lblMarchamoAdicionalENA;
        private System.Windows.Forms.TextBox txtMarchamoENAB;
        private System.Windows.Forms.Label lblMarchamoENAA;
        private System.Windows.Forms.TextBox txtMarchamoENAA;
        private System.Windows.Forms.Label lblMarchamo;
        private System.Windows.Forms.Button btnNuevoManifiesto;
        private System.Windows.Forms.Button btnGuardarManifiesto;
        private System.Windows.Forms.Button btnCancelarManifiesto;
        private System.Windows.Forms.GroupBox gbBusquedaManifiestosFull;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnBuscarManifiesto;
        private System.Windows.Forms.TextBox txtCodigoManifiestoBuscado;
        private System.Windows.Forms.Label lblCodigoManifiestoFullBuscado;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private ComboBoxBusqueda cboEsquema;
        private System.Windows.Forms.Label lblEsquema;
        private System.Drawing.Printing.PrintDocument pdManifiesto;
        private System.Windows.Forms.PrintDialog pdOpcionesImpresion;
        private System.Windows.Forms.CheckBox chkBolsaRechazoFull;
        private System.Windows.Forms.TextBox txtBolsaRechazoFull;
    }
}