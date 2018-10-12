namespace GUILayer
{
    partial class frmCambioManifiestoTula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioManifiestoTula));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbManifiesto = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Menifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarManifiesto = new System.Windows.Forms.Button();
            this.txtCodigoManifiestoBuscado = new System.Windows.Forms.TextBox();
            this.lblManifiestoBuscado = new System.Windows.Forms.Label();
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblReceptor = new System.Windows.Forms.Label();
            this.txtReceptor = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblCodigoManifiesto = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbTula = new System.Windows.Forms.GroupBox();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodigoTulaBuscada = new System.Windows.Forms.TextBox();
            this.lblTulaBuscada = new System.Windows.Forms.Label();
            this.btnBuscarTula = new System.Windows.Forms.Button();
            this.gbDatosManifiestoNuevo = new System.Windows.Forms.GroupBox();
            this.lblFechaNueva = new System.Windows.Forms.Label();
            this.lblEmpresaNueva = new System.Windows.Forms.Label();
            this.txtFechaNueva = new System.Windows.Forms.TextBox();
            this.txtEmpresaNueva = new System.Windows.Forms.TextBox();
            this.lblReceptorNuevo = new System.Windows.Forms.Label();
            this.txtReceptorNuevo = new System.Windows.Forms.TextBox();
            this.txtGrupoNuevo = new System.Windows.Forms.TextBox();
            this.txtCajaNueva = new System.Windows.Forms.TextBox();
            this.lblCajaNueva = new System.Windows.Forms.Label();
            this.txtCodigoManifiestoNuevo = new System.Windows.Forms.TextBox();
            this.lblGrupoNuevo = new System.Windows.Forms.Label();
            this.lblCodigoManifiestoNuevo = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbManifiesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.gbDatosManifiesto.SuspendLayout();
            this.gbTula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.gbDatosManifiestoNuevo.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(663, 502);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbManifiesto
            // 
            this.gbManifiesto.Controls.Add(this.dgvManifiestos);
            this.gbManifiesto.Controls.Add(this.btnBuscarManifiesto);
            this.gbManifiesto.Controls.Add(this.txtCodigoManifiestoBuscado);
            this.gbManifiesto.Controls.Add(this.lblManifiestoBuscado);
            this.gbManifiesto.Location = new System.Drawing.Point(13, 282);
            this.gbManifiesto.Name = "gbManifiesto";
            this.gbManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbManifiesto.Size = new System.Drawing.Size(373, 214);
            this.gbManifiesto.TabIndex = 3;
            this.gbManifiesto.TabStop = false;
            this.gbManifiesto.Text = "Manifiesto";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvManifiestos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.Menifiesto});
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
            this.dgvManifiestos.Location = new System.Drawing.Point(66, 65);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvManifiestos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(300, 143);
            this.dgvManifiestos.TabIndex = 3;
            this.dgvManifiestos.TabStop = false;
            this.dgvManifiestos.SelectionChanged += new System.EventHandler(this.dgvManifiestos_SelectionChanged);
            // 
            // Menifiesto
            // 
            this.Menifiesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Menifiesto.DataPropertyName = "Codigo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Menifiesto.DefaultCellStyle = dataGridViewCellStyle3;
            this.Menifiesto.HeaderText = "Código de Manifiesto";
            this.Menifiesto.Name = "Menifiesto";
            this.Menifiesto.ReadOnly = true;
            // 
            // btnBuscarManifiesto
            // 
            this.btnBuscarManifiesto.Enabled = false;
            this.btnBuscarManifiesto.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscarManifiesto.Location = new System.Drawing.Point(276, 19);
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
            this.txtCodigoManifiestoBuscado.Location = new System.Drawing.Point(66, 30);
            this.txtCodigoManifiestoBuscado.Name = "txtCodigoManifiestoBuscado";
            this.txtCodigoManifiestoBuscado.Size = new System.Drawing.Size(204, 20);
            this.txtCodigoManifiestoBuscado.TabIndex = 1;
            this.txtCodigoManifiestoBuscado.TextChanged += new System.EventHandler(this.txtCodigoManifiestoBuscado_TextChanged);
            // 
            // lblManifiestoBuscado
            // 
            this.lblManifiestoBuscado.AutoSize = true;
            this.lblManifiestoBuscado.Location = new System.Drawing.Point(17, 33);
            this.lblManifiestoBuscado.Name = "lblManifiestoBuscado";
            this.lblManifiestoBuscado.Size = new System.Drawing.Size(43, 13);
            this.lblManifiestoBuscado.TabIndex = 0;
            this.lblManifiestoBuscado.Text = "Código:";
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.lblFecha);
            this.gbDatosManifiesto.Controls.Add(this.txtFecha);
            this.gbDatosManifiesto.Controls.Add(this.lblEmpresa);
            this.gbDatosManifiesto.Controls.Add(this.txtEmpresa);
            this.gbDatosManifiesto.Controls.Add(this.lblReceptor);
            this.gbDatosManifiesto.Controls.Add(this.txtReceptor);
            this.gbDatosManifiesto.Controls.Add(this.txtGrupo);
            this.gbDatosManifiesto.Controls.Add(this.txtCaja);
            this.gbDatosManifiesto.Controls.Add(this.lblCaja);
            this.gbDatosManifiesto.Controls.Add(this.txtCodigoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.lblGrupo);
            this.gbDatosManifiesto.Controls.Add(this.lblCodigoManifiesto);
            this.gbDatosManifiesto.Location = new System.Drawing.Point(391, 62);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(373, 214);
            this.gbDatosManifiesto.TabIndex = 2;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos del Manifiesto Actual";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(69, 114);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(115, 111);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(247, 20);
            this.txtFecha.TabIndex = 10;
            this.txtFecha.TabStop = false;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(58, 88);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 4;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(115, 85);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(247, 20);
            this.txtEmpresa.TabIndex = 5;
            this.txtEmpresa.TabStop = false;
            // 
            // lblReceptor
            // 
            this.lblReceptor.AutoSize = true;
            this.lblReceptor.Location = new System.Drawing.Point(54, 62);
            this.lblReceptor.Name = "lblReceptor";
            this.lblReceptor.Size = new System.Drawing.Size(54, 13);
            this.lblReceptor.TabIndex = 2;
            this.lblReceptor.Text = "Receptor:";
            // 
            // txtReceptor
            // 
            this.txtReceptor.Location = new System.Drawing.Point(115, 59);
            this.txtReceptor.Name = "txtReceptor";
            this.txtReceptor.ReadOnly = true;
            this.txtReceptor.Size = new System.Drawing.Size(247, 20);
            this.txtReceptor.TabIndex = 3;
            this.txtReceptor.TabStop = false;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(115, 137);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(247, 20);
            this.txtGrupo.TabIndex = 8;
            this.txtGrupo.TabStop = false;
            // 
            // txtCaja
            // 
            this.txtCaja.Location = new System.Drawing.Point(115, 163);
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.ReadOnly = true;
            this.txtCaja.Size = new System.Drawing.Size(88, 20);
            this.txtCaja.TabIndex = 10;
            this.txtCaja.TabStop = false;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(78, 166);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(31, 13);
            this.lblCaja.TabIndex = 9;
            this.lblCaja.Text = "Caja:";
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(115, 33);
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.ReadOnly = true;
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(247, 20);
            this.txtCodigoManifiesto.TabIndex = 1;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(70, 140);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 7;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblCodigoManifiesto
            // 
            this.lblCodigoManifiesto.AutoSize = true;
            this.lblCodigoManifiesto.Location = new System.Drawing.Point(66, 36);
            this.lblCodigoManifiesto.Name = "lblCodigoManifiesto";
            this.lblCodigoManifiesto.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiesto.TabIndex = 0;
            this.lblCodigoManifiesto.Text = "Código:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(567, 502);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbTula
            // 
            this.gbTula.Controls.Add(this.dgvTulas);
            this.gbTula.Controls.Add(this.txtCodigoTulaBuscada);
            this.gbTula.Controls.Add(this.lblTulaBuscada);
            this.gbTula.Controls.Add(this.btnBuscarTula);
            this.gbTula.Location = new System.Drawing.Point(12, 62);
            this.gbTula.Name = "gbTula";
            this.gbTula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbTula.Size = new System.Drawing.Size(373, 214);
            this.gbTula.TabIndex = 1;
            this.gbTula.TabStop = false;
            this.gbTula.Text = "Tula";
            // 
            // dgvTulas
            // 
            this.dgvTulas.AllowUserToAddRows = false;
            this.dgvTulas.AllowUserToDeleteRows = false;
            this.dgvTulas.AllowUserToOrderColumns = true;
            this.dgvTulas.AllowUserToResizeColumns = false;
            this.dgvTulas.AllowUserToResizeRows = false;
            this.dgvTulas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTulas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTulas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTulas.EnableHeadersVisualStyles = false;
            this.dgvTulas.Location = new System.Drawing.Point(66, 65);
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.ReadOnly = true;
            this.dgvTulas.RowHeadersVisible = false;
            this.dgvTulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulas.Size = new System.Drawing.Size(300, 143);
            this.dgvTulas.TabIndex = 3;
            this.dgvTulas.SelectionChanged += new System.EventHandler(this.dgvTulas_SelectionChanged);
            // 
            // Tula
            // 
            this.Tula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tula.DataPropertyName = "Codigo";
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            // 
            // txtCodigoTulaBuscada
            // 
            this.txtCodigoTulaBuscada.Location = new System.Drawing.Point(66, 30);
            this.txtCodigoTulaBuscada.Name = "txtCodigoTulaBuscada";
            this.txtCodigoTulaBuscada.Size = new System.Drawing.Size(204, 20);
            this.txtCodigoTulaBuscada.TabIndex = 1;
            this.txtCodigoTulaBuscada.TextChanged += new System.EventHandler(this.txtCodigoTulaBuscada_TextChanged);
            // 
            // lblTulaBuscada
            // 
            this.lblTulaBuscada.AutoSize = true;
            this.lblTulaBuscada.Location = new System.Drawing.Point(17, 33);
            this.lblTulaBuscada.Name = "lblTulaBuscada";
            this.lblTulaBuscada.Size = new System.Drawing.Size(43, 13);
            this.lblTulaBuscada.TabIndex = 0;
            this.lblTulaBuscada.Text = "Código:";
            // 
            // btnBuscarTula
            // 
            this.btnBuscarTula.Enabled = false;
            this.btnBuscarTula.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscarTula.Location = new System.Drawing.Point(276, 19);
            this.btnBuscarTula.Name = "btnBuscarTula";
            this.btnBuscarTula.Size = new System.Drawing.Size(90, 40);
            this.btnBuscarTula.TabIndex = 2;
            this.btnBuscarTula.Text = "Buscar";
            this.btnBuscarTula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarTula.UseVisualStyleBackColor = false;
            this.btnBuscarTula.Click += new System.EventHandler(this.btnBuscarTula_Click);
            // 
            // gbDatosManifiestoNuevo
            // 
            this.gbDatosManifiestoNuevo.Controls.Add(this.lblFechaNueva);
            this.gbDatosManifiestoNuevo.Controls.Add(this.lblEmpresaNueva);
            this.gbDatosManifiestoNuevo.Controls.Add(this.txtFechaNueva);
            this.gbDatosManifiestoNuevo.Controls.Add(this.txtEmpresaNueva);
            this.gbDatosManifiestoNuevo.Controls.Add(this.lblReceptorNuevo);
            this.gbDatosManifiestoNuevo.Controls.Add(this.txtReceptorNuevo);
            this.gbDatosManifiestoNuevo.Controls.Add(this.txtGrupoNuevo);
            this.gbDatosManifiestoNuevo.Controls.Add(this.txtCajaNueva);
            this.gbDatosManifiestoNuevo.Controls.Add(this.lblCajaNueva);
            this.gbDatosManifiestoNuevo.Controls.Add(this.txtCodigoManifiestoNuevo);
            this.gbDatosManifiestoNuevo.Controls.Add(this.lblGrupoNuevo);
            this.gbDatosManifiestoNuevo.Controls.Add(this.lblCodigoManifiestoNuevo);
            this.gbDatosManifiestoNuevo.Location = new System.Drawing.Point(391, 282);
            this.gbDatosManifiestoNuevo.Name = "gbDatosManifiestoNuevo";
            this.gbDatosManifiestoNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiestoNuevo.Size = new System.Drawing.Size(373, 214);
            this.gbDatosManifiestoNuevo.TabIndex = 4;
            this.gbDatosManifiestoNuevo.TabStop = false;
            this.gbDatosManifiestoNuevo.Text = "Datos del Nuevo Manifiesto";
            // 
            // lblFechaNueva
            // 
            this.lblFechaNueva.AutoSize = true;
            this.lblFechaNueva.Location = new System.Drawing.Point(69, 114);
            this.lblFechaNueva.Name = "lblFechaNueva";
            this.lblFechaNueva.Size = new System.Drawing.Size(40, 13);
            this.lblFechaNueva.TabIndex = 6;
            this.lblFechaNueva.Text = "Fecha:";
            // 
            // lblEmpresaNueva
            // 
            this.lblEmpresaNueva.AutoSize = true;
            this.lblEmpresaNueva.Location = new System.Drawing.Point(58, 88);
            this.lblEmpresaNueva.Name = "lblEmpresaNueva";
            this.lblEmpresaNueva.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresaNueva.TabIndex = 4;
            this.lblEmpresaNueva.Text = "Empresa:";
            // 
            // txtFechaNueva
            // 
            this.txtFechaNueva.Location = new System.Drawing.Point(115, 111);
            this.txtFechaNueva.Name = "txtFechaNueva";
            this.txtFechaNueva.ReadOnly = true;
            this.txtFechaNueva.Size = new System.Drawing.Size(247, 20);
            this.txtFechaNueva.TabIndex = 7;
            this.txtFechaNueva.TabStop = false;
            // 
            // txtEmpresaNueva
            // 
            this.txtEmpresaNueva.Location = new System.Drawing.Point(115, 85);
            this.txtEmpresaNueva.Name = "txtEmpresaNueva";
            this.txtEmpresaNueva.ReadOnly = true;
            this.txtEmpresaNueva.Size = new System.Drawing.Size(247, 20);
            this.txtEmpresaNueva.TabIndex = 5;
            this.txtEmpresaNueva.TabStop = false;
            // 
            // lblReceptorNuevo
            // 
            this.lblReceptorNuevo.AutoSize = true;
            this.lblReceptorNuevo.Location = new System.Drawing.Point(55, 62);
            this.lblReceptorNuevo.Name = "lblReceptorNuevo";
            this.lblReceptorNuevo.Size = new System.Drawing.Size(54, 13);
            this.lblReceptorNuevo.TabIndex = 2;
            this.lblReceptorNuevo.Text = "Receptor:";
            // 
            // txtReceptorNuevo
            // 
            this.txtReceptorNuevo.Location = new System.Drawing.Point(115, 59);
            this.txtReceptorNuevo.Name = "txtReceptorNuevo";
            this.txtReceptorNuevo.ReadOnly = true;
            this.txtReceptorNuevo.Size = new System.Drawing.Size(247, 20);
            this.txtReceptorNuevo.TabIndex = 3;
            this.txtReceptorNuevo.TabStop = false;
            // 
            // txtGrupoNuevo
            // 
            this.txtGrupoNuevo.Location = new System.Drawing.Point(115, 137);
            this.txtGrupoNuevo.Name = "txtGrupoNuevo";
            this.txtGrupoNuevo.ReadOnly = true;
            this.txtGrupoNuevo.Size = new System.Drawing.Size(247, 20);
            this.txtGrupoNuevo.TabIndex = 9;
            this.txtGrupoNuevo.TabStop = false;
            // 
            // txtCajaNueva
            // 
            this.txtCajaNueva.Location = new System.Drawing.Point(115, 163);
            this.txtCajaNueva.Name = "txtCajaNueva";
            this.txtCajaNueva.ReadOnly = true;
            this.txtCajaNueva.Size = new System.Drawing.Size(88, 20);
            this.txtCajaNueva.TabIndex = 11;
            this.txtCajaNueva.TabStop = false;
            // 
            // lblCajaNueva
            // 
            this.lblCajaNueva.AutoSize = true;
            this.lblCajaNueva.Location = new System.Drawing.Point(78, 166);
            this.lblCajaNueva.Name = "lblCajaNueva";
            this.lblCajaNueva.Size = new System.Drawing.Size(31, 13);
            this.lblCajaNueva.TabIndex = 10;
            this.lblCajaNueva.Text = "Caja:";
            // 
            // txtCodigoManifiestoNuevo
            // 
            this.txtCodigoManifiestoNuevo.Location = new System.Drawing.Point(115, 33);
            this.txtCodigoManifiestoNuevo.Name = "txtCodigoManifiestoNuevo";
            this.txtCodigoManifiestoNuevo.ReadOnly = true;
            this.txtCodigoManifiestoNuevo.Size = new System.Drawing.Size(247, 20);
            this.txtCodigoManifiestoNuevo.TabIndex = 1;
            // 
            // lblGrupoNuevo
            // 
            this.lblGrupoNuevo.AutoSize = true;
            this.lblGrupoNuevo.Location = new System.Drawing.Point(70, 140);
            this.lblGrupoNuevo.Name = "lblGrupoNuevo";
            this.lblGrupoNuevo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupoNuevo.TabIndex = 8;
            this.lblGrupoNuevo.Text = "Grupo:";
            // 
            // lblCodigoManifiestoNuevo
            // 
            this.lblCodigoManifiestoNuevo.AutoSize = true;
            this.lblCodigoManifiestoNuevo.Location = new System.Drawing.Point(66, 36);
            this.lblCodigoManifiestoNuevo.Name = "lblCodigoManifiestoNuevo";
            this.lblCodigoManifiestoNuevo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiestoNuevo.TabIndex = 0;
            this.lblCodigoManifiestoNuevo.Text = "Código:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(814, 59);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(387, 50);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmCambioManifiestoTula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 554);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosManifiestoNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDatosManifiesto);
            this.Controls.Add(this.gbTula);
            this.Controls.Add(this.gbManifiesto);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioManifiestoTula";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio del Manifiesto de una Tula";
            this.gbManifiesto.ResumeLayout(false);
            this.gbManifiesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            this.gbTula.ResumeLayout(false);
            this.gbTula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.gbDatosManifiestoNuevo.ResumeLayout(false);
            this.gbDatosManifiestoNuevo.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbManifiesto;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menifiesto;
        private System.Windows.Forms.Button btnBuscarManifiesto;
        private System.Windows.Forms.TextBox txtCodigoManifiestoBuscado;
        private System.Windows.Forms.Label lblManifiestoBuscado;
        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblReceptor;
        private System.Windows.Forms.TextBox txtReceptor;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblCodigoManifiesto;
        private System.Windows.Forms.GroupBox gbTula;
        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.TextBox txtCodigoTulaBuscada;
        internal System.Windows.Forms.Label lblTulaBuscada;
        private System.Windows.Forms.Button btnBuscarTula;
        private System.Windows.Forms.GroupBox gbDatosManifiestoNuevo;
        private System.Windows.Forms.Label lblEmpresaNueva;
        private System.Windows.Forms.TextBox txtEmpresaNueva;
        private System.Windows.Forms.Label lblReceptorNuevo;
        private System.Windows.Forms.TextBox txtReceptorNuevo;
        private System.Windows.Forms.TextBox txtGrupoNuevo;
        private System.Windows.Forms.TextBox txtCajaNueva;
        private System.Windows.Forms.Label lblCajaNueva;
        private System.Windows.Forms.TextBox txtCodigoManifiestoNuevo;
        private System.Windows.Forms.Label lblGrupoNuevo;
        private System.Windows.Forms.Label lblCodigoManifiestoNuevo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFechaNueva;
        private System.Windows.Forms.TextBox txtFechaNueva;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;

    }
}