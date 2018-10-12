namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmConsultaInfoManifiesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaInfoManifiesto));
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.gbTulas = new System.Windows.Forms.GroupBox();
            this.btnQuitarCorte = new System.Windows.Forms.Button();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuntoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarTulaCodigo = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEditarManifiesto = new System.Windows.Forms.Button();
            this.numDolares = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numColones = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numEuros = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminarDeposito = new System.Windows.Forms.Button();
            this.btnModificarDeposito = new System.Windows.Forms.Button();
            this.gbDepositos = new System.Windows.Forms.GroupBox();
            this.dgvDepositos = new System.Windows.Forms.DataGridView();
            this.id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Niquel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Declarado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlManifiesto = new System.Windows.Forms.Panel();
            this.cboPuntoVenta = new System.Windows.Forms.ComboBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.gbTulas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEuros)).BeginInit();
            this.gbDepositos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlManifiesto.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(60, 18);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 16);
            this.lblCliente.TabIndex = 14;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(10, 49);
            this.lblPuntoVenta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(102, 16);
            this.lblPuntoVenta.TabIndex = 13;
            this.lblPuntoVenta.Text = "Punto de Venta:";
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManifiesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManifiesto.Location = new System.Drawing.Point(143, 69);
            this.txtManifiesto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtManifiesto.MaxLength = 30;
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.Size = new System.Drawing.Size(183, 22);
            this.txtManifiesto.TabIndex = 18;
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(61, 71);
            this.lblManifiesto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(72, 16);
            this.lblManifiesto.TabIndex = 17;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // gbTulas
            // 
            this.gbTulas.Controls.Add(this.btnQuitarCorte);
            this.gbTulas.Controls.Add(this.dgvTulas);
            this.gbTulas.Controls.Add(this.btnEditarTulaCodigo);
            this.gbTulas.Location = new System.Drawing.Point(64, 266);
            this.gbTulas.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbTulas.Name = "gbTulas";
            this.gbTulas.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbTulas.Size = new System.Drawing.Size(535, 180);
            this.gbTulas.TabIndex = 17;
            this.gbTulas.TabStop = false;
            this.gbTulas.Text = "Tulas";
            // 
            // btnQuitarCorte
            // 
            this.btnQuitarCorte.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarCorte.Image = global::GUILayer.Properties.Resources.erase;
            this.btnQuitarCorte.Location = new System.Drawing.Point(314, 134);
            this.btnQuitarCorte.Name = "btnQuitarCorte";
            this.btnQuitarCorte.Size = new System.Drawing.Size(90, 40);
            this.btnQuitarCorte.TabIndex = 38;
            this.btnQuitarCorte.Text = "Quitar";
            this.btnQuitarCorte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarCorte.UseVisualStyleBackColor = false;
            this.btnQuitarCorte.Click += new System.EventHandler(this.btnQuitarCorte_Click);
            // 
            // dgvTulas
            // 
            this.dgvTulas.AllowUserToAddRows = false;
            this.dgvTulas.AllowUserToDeleteRows = false;
            this.dgvTulas.AllowUserToOrderColumns = true;
            this.dgvTulas.AllowUserToResizeColumns = false;
            this.dgvTulas.AllowUserToResizeRows = false;
            this.dgvTulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTulas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTulas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Tula,
            this.Fecha,
            this.Cliente,
            this.PuntoVenta});
            this.dgvTulas.EnableHeadersVisualStyles = false;
            this.dgvTulas.Location = new System.Drawing.Point(16, 23);
            this.dgvTulas.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvTulas.MultiSelect = false;
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.ReadOnly = true;
            this.dgvTulas.RowHeadersVisible = false;
            this.dgvTulas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulas.Size = new System.Drawing.Size(484, 96);
            this.dgvTulas.StandardTab = true;
            this.dgvTulas.TabIndex = 2;
            this.dgvTulas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTulas_CellClick);
            this.dgvTulas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTulas_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Tula
            // 
            this.Tula.DataPropertyName = "Codigo";
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Visible = false;
            // 
            // PuntoVenta
            // 
            this.PuntoVenta.DataPropertyName = "Punto de Venta";
            this.PuntoVenta.HeaderText = "PuntoVenta";
            this.PuntoVenta.Name = "PuntoVenta";
            this.PuntoVenta.ReadOnly = true;
            this.PuntoVenta.Visible = false;
            // 
            // btnEditarTulaCodigo
            // 
            this.btnEditarTulaCodigo.Image = global::GUILayer.Properties.Resources.edit1;
            this.btnEditarTulaCodigo.Location = new System.Drawing.Point(412, 133);
            this.btnEditarTulaCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEditarTulaCodigo.Name = "btnEditarTulaCodigo";
            this.btnEditarTulaCodigo.Size = new System.Drawing.Size(88, 41);
            this.btnEditarTulaCodigo.TabIndex = 36;
            this.btnEditarTulaCodigo.Text = "Editar";
            this.btnEditarTulaCodigo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarTulaCodigo.UseVisualStyleBackColor = false;
            this.btnEditarTulaCodigo.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pictureBox1);
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(664, 51);
            this.pnlFondo.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(465, 57);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(464, 49);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 6;
            this.pbLogo.TabStop = false;
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.Image = global::GUILayer.Properties.Resources.squareexit;
            this.btnVolver.Location = new System.Drawing.Point(557, 57);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(88, 44);
            this.btnVolver.TabIndex = 33;
            this.btnVolver.Text = "Salir";
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(348, 58);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 43);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEditarManifiesto
            // 
            this.btnEditarManifiesto.Image = global::GUILayer.Properties.Resources.edit1;
            this.btnEditarManifiesto.Location = new System.Drawing.Point(412, 106);
            this.btnEditarManifiesto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEditarManifiesto.Name = "btnEditarManifiesto";
            this.btnEditarManifiesto.Size = new System.Drawing.Size(100, 41);
            this.btnEditarManifiesto.TabIndex = 37;
            this.btnEditarManifiesto.Text = "Actualizar";
            this.btnEditarManifiesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarManifiesto.UseVisualStyleBackColor = false;
            this.btnEditarManifiesto.Click += new System.EventHandler(this.btnEditarManifiesto_Click);
            // 
            // numDolares
            // 
            this.numDolares.Location = new System.Drawing.Point(3, 91);
            this.numDolares.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numDolares.Name = "numDolares";
            this.numDolares.Size = new System.Drawing.Size(268, 22);
            this.numDolares.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 48;
            this.label2.Text = "Dolares:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(256, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 21);
            this.panel1.TabIndex = 47;
            // 
            // numColones
            // 
            this.numColones.Location = new System.Drawing.Point(3, 63);
            this.numColones.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numColones.Name = "numColones";
            this.numColones.Size = new System.Drawing.Size(268, 22);
            this.numColones.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Colones:";
            // 
            // numEuros
            // 
            this.numEuros.Location = new System.Drawing.Point(3, 117);
            this.numEuros.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numEuros.Name = "numEuros";
            this.numEuros.Size = new System.Drawing.Size(268, 22);
            this.numEuros.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 51;
            this.label3.Text = "Euros:";
            // 
            // btnEliminarDeposito
            // 
            this.btnEliminarDeposito.Image = global::GUILayer.Properties.Resources.erase;
            this.btnEliminarDeposito.Location = new System.Drawing.Point(314, 129);
            this.btnEliminarDeposito.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEliminarDeposito.Name = "btnEliminarDeposito";
            this.btnEliminarDeposito.Size = new System.Drawing.Size(90, 41);
            this.btnEliminarDeposito.TabIndex = 35;
            this.btnEliminarDeposito.Text = "Quitar";
            this.btnEliminarDeposito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarDeposito.UseVisualStyleBackColor = false;
            this.btnEliminarDeposito.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificarDeposito
            // 
            this.btnModificarDeposito.Image = global::GUILayer.Properties.Resources.edit1;
            this.btnModificarDeposito.Location = new System.Drawing.Point(412, 129);
            this.btnModificarDeposito.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnModificarDeposito.Name = "btnModificarDeposito";
            this.btnModificarDeposito.Size = new System.Drawing.Size(88, 41);
            this.btnModificarDeposito.TabIndex = 34;
            this.btnModificarDeposito.Text = "Editar";
            this.btnModificarDeposito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificarDeposito.UseVisualStyleBackColor = false;
            this.btnModificarDeposito.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // gbDepositos
            // 
            this.gbDepositos.Controls.Add(this.dgvDepositos);
            this.gbDepositos.Controls.Add(this.btnModificarDeposito);
            this.gbDepositos.Controls.Add(this.btnEliminarDeposito);
            this.gbDepositos.Location = new System.Drawing.Point(64, 454);
            this.gbDepositos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbDepositos.Name = "gbDepositos";
            this.gbDepositos.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbDepositos.Size = new System.Drawing.Size(535, 178);
            this.gbDepositos.TabIndex = 18;
            this.gbDepositos.TabStop = false;
            this.gbDepositos.Text = "Depósitos";
            this.gbDepositos.Enter += new System.EventHandler(this.gbDepositos_Enter);
            // 
            // dgvDepositos
            // 
            this.dgvDepositos.AllowUserToAddRows = false;
            this.dgvDepositos.AllowUserToDeleteRows = false;
            this.dgvDepositos.AllowUserToOrderColumns = true;
            this.dgvDepositos.AllowUserToResizeColumns = false;
            this.dgvDepositos.AllowUserToResizeRows = false;
            this.dgvDepositos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDepositos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepositos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepositos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id2,
            this.Codigo,
            this.Niquel,
            this.Contado,
            this.Declarado});
            this.dgvDepositos.EnableHeadersVisualStyles = false;
            this.dgvDepositos.Location = new System.Drawing.Point(16, 25);
            this.dgvDepositos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvDepositos.MultiSelect = false;
            this.dgvDepositos.Name = "dgvDepositos";
            this.dgvDepositos.ReadOnly = true;
            this.dgvDepositos.RowHeadersVisible = false;
            this.dgvDepositos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDepositos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepositos.Size = new System.Drawing.Size(484, 96);
            this.dgvDepositos.StandardTab = true;
            this.dgvDepositos.TabIndex = 39;
            // 
            // id2
            // 
            this.id2.DataPropertyName = "Id";
            this.id2.HeaderText = "Id";
            this.id2.Name = "id2";
            this.id2.ReadOnly = true;
            this.id2.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Niquel
            // 
            this.Niquel.DataPropertyName = "Niquel";
            this.Niquel.HeaderText = "Niquel";
            this.Niquel.Name = "Niquel";
            this.Niquel.ReadOnly = true;
            // 
            // Contado
            // 
            this.Contado.DataPropertyName = "Contado";
            this.Contado.HeaderText = "Contado";
            this.Contado.Name = "Contado";
            this.Contado.ReadOnly = true;
            // 
            // Declarado
            // 
            this.Declarado.DataPropertyName = "Declarado";
            this.Declarado.HeaderText = "Declarado";
            this.Declarado.Name = "Declarado";
            this.Declarado.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlManifiesto);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.lblPuntoVenta);
            this.groupBox1.Controls.Add(this.btnEditarManifiesto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(64, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 151);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manifiesto";
            // 
            // pnlManifiesto
            // 
            this.pnlManifiesto.Controls.Add(this.cboPuntoVenta);
            this.pnlManifiesto.Controls.Add(this.cboCliente);
            this.pnlManifiesto.Controls.Add(this.panel4);
            this.pnlManifiesto.Controls.Add(this.panel1);
            this.pnlManifiesto.Controls.Add(this.numColones);
            this.pnlManifiesto.Controls.Add(this.numEuros);
            this.pnlManifiesto.Controls.Add(this.numDolares);
            this.pnlManifiesto.Location = new System.Drawing.Point(130, 12);
            this.pnlManifiesto.Name = "pnlManifiesto";
            this.pnlManifiesto.Size = new System.Drawing.Size(260, 139);
            this.pnlManifiesto.TabIndex = 57;
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPuntoVenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPuntoVenta.FormattingEnabled = true;
            this.cboPuntoVenta.Location = new System.Drawing.Point(3, 33);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(254, 24);
            this.cboPuntoVenta.TabIndex = 56;
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(3, 3);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(254, 24);
            this.cboCliente.TabIndex = 55;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(256, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 76);
            this.panel4.TabIndex = 54;
            // 
            // btnBorrar
            // 
            this.btnBorrar.FlatAppearance.BorderSize = 2;
            this.btnBorrar.Image = global::GUILayer.Properties.Resources.borrar;
            this.btnBorrar.Location = new System.Drawing.Point(448, 58);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(99, 43);
            this.btnBorrar.TabIndex = 55;
            this.btnBorrar.Text = "Limpiar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmConsultaInfoManifiesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(664, 645);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDepositos);
            this.Controls.Add(this.gbTulas);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtManifiesto);
            this.Controls.Add(this.lblManifiesto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "frmConsultaInfoManifiesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Consulta de Información de Manifiestos";
            this.Load += new System.EventHandler(this.frmConsultaInfoManifiesto_Load);
            this.gbTulas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEuros)).EndInit();
            this.gbDepositos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlManifiesto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.TextBox txtManifiesto;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbTulas;
        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnEditarTulaCodigo;
        private System.Windows.Forms.Button btnQuitarCorte;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEditarManifiesto;
        private System.Windows.Forms.NumericUpDown numDolares;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numColones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numEuros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminarDeposito;
        private System.Windows.Forms.Button btnModificarDeposito;
        private System.Windows.Forms.GroupBox gbDepositos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboPuntoVenta;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntoVenta;
        private System.Windows.Forms.DataGridView dgvDepositos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Niquel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Declarado;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Panel pnlManifiesto;
    }
}