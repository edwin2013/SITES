namespace GUILayer
{
    partial class frmRegistroTulas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroTulas));
            this.txtFuncion = new System.Windows.Forms.TextBox();
            this.lblFuncion = new System.Windows.Forms.Label();
            this.lblMenos = new System.Windows.Forms.Label();
            this.lblPor = new System.Windows.Forms.Label();
            this.lblMas = new System.Windows.Forms.Label();
            this.lblDiv = new System.Windows.Forms.Label();
            this.lblPunto = new System.Windows.Forms.Label();
            this.txtUltimaTula = new System.Windows.Forms.TextBox();
            this.lblUltimaTula = new System.Windows.Forms.Label();
            this.txtTula = new System.Windows.Forms.TextBox();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.lblTula = new System.Windows.Forms.Label();
            this.lblManifiesto = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtReceptor = new System.Windows.Forms.TextBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblReceptor = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblTotalManifiestos = new System.Windows.Forms.Label();
            this.dgvDistribucion = new System.Windows.Forms.DataGridView();
            this.Etiqueta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlComandos = new System.Windows.Forms.Panel();
            this.cboDenominaciones = new GUILayer.ComboBoxBusqueda();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.nudCantidadBolsas = new System.Windows.Forms.NumericUpDown();
            this.lblCantidadBolsas = new System.Windows.Forms.Label();
            this.btnAgregarTulaNiquel = new System.Windows.Forms.Button();
            this.btnQuitarTulaNiquel = new System.Windows.Forms.Button();
            this.dgvTulasNiquel = new System.Windows.Forms.DataGridView();
            this.clmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDenominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarMonedas = new System.Windows.Forms.Button();
            this.gbMonedas = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribucion)).BeginInit();
            this.pnlComandos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadBolsas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasNiquel)).BeginInit();
            this.gbMonedas.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFuncion
            // 
            this.txtFuncion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFuncion.BackColor = System.Drawing.Color.Aqua;
            this.txtFuncion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFuncion.Location = new System.Drawing.Point(927, 394);
            this.txtFuncion.Name = "txtFuncion";
            this.txtFuncion.ReadOnly = true;
            this.txtFuncion.Size = new System.Drawing.Size(277, 20);
            this.txtFuncion.TabIndex = 4;
            this.txtFuncion.TabStop = false;
            this.txtFuncion.Text = "Cambio de Grupo";
            this.txtFuncion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFuncion
            // 
            this.lblFuncion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFuncion.AutoSize = true;
            this.lblFuncion.Location = new System.Drawing.Point(759, 397);
            this.lblFuncion.Name = "lblFuncion";
            this.lblFuncion.Size = new System.Drawing.Size(162, 13);
            this.lblFuncion.TabIndex = 3;
            this.lblFuncion.Text = "Funcion de la Teclas Numéricas:";
            // 
            // lblMenos
            // 
            this.lblMenos.Location = new System.Drawing.Point(15, 41);
            this.lblMenos.Name = "lblMenos";
            this.lblMenos.Size = new System.Drawing.Size(258, 23);
            this.lblMenos.TabIndex = 1;
            this.lblMenos.Text = "Menos(-) = Eliminar la última tula registrada";
            // 
            // lblPor
            // 
            this.lblPor.Location = new System.Drawing.Point(15, 110);
            this.lblPor.Name = "lblPor";
            this.lblPor.Size = new System.Drawing.Size(258, 23);
            this.lblPor.TabIndex = 4;
            this.lblPor.Text = "Multiplicar(*) = Cerrar esta ventana";
            // 
            // lblMas
            // 
            this.lblMas.Location = new System.Drawing.Point(15, 18);
            this.lblMas.Name = "lblMas";
            this.lblMas.Size = new System.Drawing.Size(258, 23);
            this.lblMas.TabIndex = 0;
            this.lblMas.Text = "Más(+) = Reiniciar la lectura de la tula y el manifiesto";
            // 
            // lblDiv
            // 
            this.lblDiv.Location = new System.Drawing.Point(16, 87);
            this.lblDiv.Name = "lblDiv";
            this.lblDiv.Size = new System.Drawing.Size(258, 23);
            this.lblDiv.TabIndex = 3;
            this.lblDiv.Text = "Dividir(/) = Reutilizar el código del último manifiesto";
            // 
            // lblPunto
            // 
            this.lblPunto.Location = new System.Drawing.Point(15, 64);
            this.lblPunto.Name = "lblPunto";
            this.lblPunto.Size = new System.Drawing.Size(258, 23);
            this.lblPunto.TabIndex = 2;
            this.lblPunto.Text = "Punto(.) = Cambiar la función de las teclas numéricas";
            // 
            // txtUltimaTula
            // 
            this.txtUltimaTula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUltimaTula.BackColor = System.Drawing.Color.White;
            this.txtUltimaTula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUltimaTula.Location = new System.Drawing.Point(927, 535);
            this.txtUltimaTula.Name = "txtUltimaTula";
            this.txtUltimaTula.ReadOnly = true;
            this.txtUltimaTula.Size = new System.Drawing.Size(277, 20);
            this.txtUltimaTula.TabIndex = 14;
            this.txtUltimaTula.TabStop = false;
            this.txtUltimaTula.Text = "Ninguna";
            this.txtUltimaTula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUltimaTula
            // 
            this.lblUltimaTula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimaTula.AutoSize = true;
            this.lblUltimaTula.Location = new System.Drawing.Point(804, 538);
            this.lblUltimaTula.Name = "lblUltimaTula";
            this.lblUltimaTula.Size = new System.Drawing.Size(117, 13);
            this.lblUltimaTula.TabIndex = 13;
            this.lblUltimaTula.Text = "Última Tula Registrada:";
            // 
            // txtTula
            // 
            this.txtTula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTula.BackColor = System.Drawing.Color.White;
            this.txtTula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTula.Location = new System.Drawing.Point(927, 498);
            this.txtTula.Name = "txtTula";
            this.txtTula.ReadOnly = true;
            this.txtTula.Size = new System.Drawing.Size(277, 20);
            this.txtTula.TabIndex = 12;
            this.txtTula.TabStop = false;
            this.txtTula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManifiesto.BackColor = System.Drawing.Color.LightBlue;
            this.txtManifiesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManifiesto.Location = new System.Drawing.Point(927, 472);
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.ReadOnly = true;
            this.txtManifiesto.Size = new System.Drawing.Size(277, 20);
            this.txtManifiesto.TabIndex = 10;
            this.txtManifiesto.TabStop = false;
            this.txtManifiesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTula
            // 
            this.lblTula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTula.AutoSize = true;
            this.lblTula.Location = new System.Drawing.Point(890, 501);
            this.lblTula.Name = "lblTula";
            this.lblTula.Size = new System.Drawing.Size(31, 13);
            this.lblTula.TabIndex = 11;
            this.lblTula.Text = "Tula:";
            // 
            // lblManifiesto
            // 
            this.lblManifiesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManifiesto.AutoSize = true;
            this.lblManifiesto.Location = new System.Drawing.Point(863, 475);
            this.lblManifiesto.Name = "lblManifiesto";
            this.lblManifiesto.Size = new System.Drawing.Size(58, 13);
            this.lblManifiesto.TabIndex = 9;
            this.lblManifiesto.Text = "Manifiesto:";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(871, 566);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(50, 13);
            this.lblMensaje.TabIndex = 15;
            this.lblMensaje.Text = "Mensaje:";
            // 
            // txtReceptor
            // 
            this.txtReceptor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceptor.BackColor = System.Drawing.Color.White;
            this.txtReceptor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceptor.Location = new System.Drawing.Point(927, 420);
            this.txtReceptor.Name = "txtReceptor";
            this.txtReceptor.ReadOnly = true;
            this.txtReceptor.Size = new System.Drawing.Size(277, 20);
            this.txtReceptor.TabIndex = 6;
            this.txtReceptor.TabStop = false;
            this.txtReceptor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.BackColor = System.Drawing.Color.White;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensaje.Location = new System.Drawing.Point(927, 563);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(277, 20);
            this.txtMensaje.TabIndex = 16;
            this.txtMensaje.TabStop = false;
            this.txtMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpresa.BackColor = System.Drawing.Color.White;
            this.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpresa.Location = new System.Drawing.Point(927, 446);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(277, 20);
            this.txtEmpresa.TabIndex = 8;
            this.txtEmpresa.TabStop = false;
            this.txtEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReceptor
            // 
            this.lblReceptor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceptor.AutoSize = true;
            this.lblReceptor.Location = new System.Drawing.Point(867, 423);
            this.lblReceptor.Name = "lblReceptor";
            this.lblReceptor.Size = new System.Drawing.Size(54, 13);
            this.lblReceptor.TabIndex = 5;
            this.lblReceptor.Text = "Receptor:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(801, 449);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(120, 13);
            this.lblEmpresa.TabIndex = 7;
            this.lblEmpresa.Text = "Empresa de Transporte:";
            // 
            // lblTotalManifiestos
            // 
            this.lblTotalManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalManifiestos.AutoSize = true;
            this.lblTotalManifiestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalManifiestos.Location = new System.Drawing.Point(951, 9);
            this.lblTotalManifiestos.Name = "lblTotalManifiestos";
            this.lblTotalManifiestos.Size = new System.Drawing.Size(253, 25);
            this.lblTotalManifiestos.TabIndex = 0;
            this.lblTotalManifiestos.Text = "Total de Manifiestos: 0";
            // 
            // dgvDistribucion
            // 
            this.dgvDistribucion.AllowUserToAddRows = false;
            this.dgvDistribucion.AllowUserToDeleteRows = false;
            this.dgvDistribucion.AllowUserToResizeColumns = false;
            this.dgvDistribucion.AllowUserToResizeRows = false;
            this.dgvDistribucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDistribucion.BackgroundColor = System.Drawing.Color.White;
            this.dgvDistribucion.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvDistribucion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDistribucion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDistribucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistribucion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Etiqueta});
            this.dgvDistribucion.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDistribucion.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDistribucion.Enabled = false;
            this.dgvDistribucion.EnableHeadersVisualStyles = false;
            this.dgvDistribucion.GridColor = System.Drawing.Color.Black;
            this.dgvDistribucion.Location = new System.Drawing.Point(12, 37);
            this.dgvDistribucion.MultiSelect = false;
            this.dgvDistribucion.Name = "dgvDistribucion";
            this.dgvDistribucion.ReadOnly = true;
            this.dgvDistribucion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDistribucion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDistribucion.RowHeadersVisible = false;
            this.dgvDistribucion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDistribucion.Size = new System.Drawing.Size(1192, 324);
            this.dgvDistribucion.TabIndex = 1;
            this.dgvDistribucion.TabStop = false;
            // 
            // Etiqueta
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Etiqueta.DefaultCellStyle = dataGridViewCellStyle2;
            this.Etiqueta.HeaderText = "";
            this.Etiqueta.MinimumWidth = 140;
            this.Etiqueta.Name = "Etiqueta";
            this.Etiqueta.ReadOnly = true;
            this.Etiqueta.Width = 170;
            // 
            // pnlComandos
            // 
            this.pnlComandos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlComandos.BackColor = System.Drawing.Color.Transparent;
            this.pnlComandos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComandos.Controls.Add(this.lblMenos);
            this.pnlComandos.Controls.Add(this.lblMas);
            this.pnlComandos.Controls.Add(this.lblPor);
            this.pnlComandos.Controls.Add(this.lblPunto);
            this.pnlComandos.Controls.Add(this.lblDiv);
            this.pnlComandos.Location = new System.Drawing.Point(12, 377);
            this.pnlComandos.Name = "pnlComandos";
            this.pnlComandos.Size = new System.Drawing.Size(290, 152);
            this.pnlComandos.TabIndex = 2;
            // 
            // cboDenominaciones
            // 
            this.cboDenominaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDenominaciones.Busqueda = true;
            this.cboDenominaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDenominaciones.FormattingEnabled = true;
            this.cboDenominaciones.ListaMostrada = null;
            this.cboDenominaciones.Location = new System.Drawing.Point(342, 67);
            this.cboDenominaciones.Name = "cboDenominaciones";
            this.cboDenominaciones.Size = new System.Drawing.Size(121, 21);
            this.cboDenominaciones.TabIndex = 17;
            // 
            // lblMoneda
            // 
            this.lblMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(272, 70);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 18;
            this.lblMoneda.Text = "Moneda";
            // 
            // nudCantidadBolsas
            // 
            this.nudCantidadBolsas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCantidadBolsas.Location = new System.Drawing.Point(405, 108);
            this.nudCantidadBolsas.Name = "nudCantidadBolsas";
            this.nudCantidadBolsas.Size = new System.Drawing.Size(58, 20);
            this.nudCantidadBolsas.TabIndex = 19;
            // 
            // lblCantidadBolsas
            // 
            this.lblCantidadBolsas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadBolsas.AutoSize = true;
            this.lblCantidadBolsas.Location = new System.Drawing.Point(301, 110);
            this.lblCantidadBolsas.Name = "lblCantidadBolsas";
            this.lblCantidadBolsas.Size = new System.Drawing.Size(98, 13);
            this.lblCantidadBolsas.TabIndex = 20;
            this.lblCantidadBolsas.Text = "Cantidad de Bolsas";
            // 
            // btnAgregarTulaNiquel
            // 
            this.btnAgregarTulaNiquel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTulaNiquel.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnAgregarTulaNiquel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTulaNiquel.Location = new System.Drawing.Point(221, 58);
            this.btnAgregarTulaNiquel.Name = "btnAgregarTulaNiquel";
            this.btnAgregarTulaNiquel.Size = new System.Drawing.Size(30, 30);
            this.btnAgregarTulaNiquel.TabIndex = 23;
            this.btnAgregarTulaNiquel.Text = "+";
            this.btnAgregarTulaNiquel.UseVisualStyleBackColor = false;
            this.btnAgregarTulaNiquel.Click += new System.EventHandler(this.btnAgregarTulaNiquel_Click);
            // 
            // btnQuitarTulaNiquel
            // 
            this.btnQuitarTulaNiquel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarTulaNiquel.BackColor = System.Drawing.Color.Tomato;
            this.btnQuitarTulaNiquel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarTulaNiquel.Location = new System.Drawing.Point(221, 98);
            this.btnQuitarTulaNiquel.Name = "btnQuitarTulaNiquel";
            this.btnQuitarTulaNiquel.Size = new System.Drawing.Size(30, 30);
            this.btnQuitarTulaNiquel.TabIndex = 25;
            this.btnQuitarTulaNiquel.Text = "-";
            this.btnQuitarTulaNiquel.UseVisualStyleBackColor = false;
            this.btnQuitarTulaNiquel.Click += new System.EventHandler(this.btnQuitarTulaNiquel_Click);
            // 
            // dgvTulasNiquel
            // 
            this.dgvTulasNiquel.AllowUserToAddRows = false;
            this.dgvTulasNiquel.AllowUserToDeleteRows = false;
            this.dgvTulasNiquel.AllowUserToOrderColumns = true;
            this.dgvTulasNiquel.AllowUserToResizeColumns = false;
            this.dgvTulasNiquel.AllowUserToResizeRows = false;
            this.dgvTulasNiquel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTulasNiquel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTulasNiquel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTulasNiquel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulasNiquel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCantidad,
            this.clmDenominacion});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTulasNiquel.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTulasNiquel.EnableHeadersVisualStyles = false;
            this.dgvTulasNiquel.Location = new System.Drawing.Point(15, 39);
            this.dgvTulasNiquel.MultiSelect = false;
            this.dgvTulasNiquel.Name = "dgvTulasNiquel";
            this.dgvTulasNiquel.ReadOnly = true;
            this.dgvTulasNiquel.RowHeadersVisible = false;
            this.dgvTulasNiquel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTulasNiquel.Size = new System.Drawing.Size(184, 86);
            this.dgvTulasNiquel.TabIndex = 24;
            this.dgvTulasNiquel.SelectionChanged += new System.EventHandler(this.dgvTulasNiquel_SelectionChanged);
            // 
            // clmCantidad
            // 
            this.clmCantidad.DataPropertyName = "CantidadBolsa";
            this.clmCantidad.HeaderText = "Cantidad";
            this.clmCantidad.Name = "clmCantidad";
            this.clmCantidad.ReadOnly = true;
            // 
            // clmDenominacion
            // 
            this.clmDenominacion.DataPropertyName = "Denominacion";
            this.clmDenominacion.HeaderText = "Denominación";
            this.clmDenominacion.Name = "clmDenominacion";
            this.clmDenominacion.ReadOnly = true;
            // 
            // btnAgregarMonedas
            // 
            this.btnAgregarMonedas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregarMonedas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregarMonedas.FlatAppearance.BorderSize = 2;
            this.btnAgregarMonedas.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarMonedas.Location = new System.Drawing.Point(68, 146);
            this.btnAgregarMonedas.Name = "btnAgregarMonedas";
            this.btnAgregarMonedas.Size = new System.Drawing.Size(93, 40);
            this.btnAgregarMonedas.TabIndex = 26;
            this.btnAgregarMonedas.Text = "Agregar Monedas";
            this.btnAgregarMonedas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarMonedas.UseVisualStyleBackColor = false;
            this.btnAgregarMonedas.Click += new System.EventHandler(this.btnAgregarMonedas_Click);
            // 
            // gbMonedas
            // 
            this.gbMonedas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMonedas.Controls.Add(this.btnAgregarMonedas);
            this.gbMonedas.Controls.Add(this.btnAgregarTulaNiquel);
            this.gbMonedas.Controls.Add(this.dgvTulasNiquel);
            this.gbMonedas.Controls.Add(this.btnQuitarTulaNiquel);
            this.gbMonedas.Controls.Add(this.cboDenominaciones);
            this.gbMonedas.Controls.Add(this.lblCantidadBolsas);
            this.gbMonedas.Controls.Add(this.lblMoneda);
            this.gbMonedas.Controls.Add(this.nudCantidadBolsas);
            this.gbMonedas.Location = new System.Drawing.Point(12, 538);
            this.gbMonedas.Name = "gbMonedas";
            this.gbMonedas.Size = new System.Drawing.Size(501, 190);
            this.gbMonedas.TabIndex = 27;
            this.gbMonedas.TabStop = false;
            this.gbMonedas.Text = "Monedas";
            // 
            // frmRegistroTulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1216, 737);
            this.Controls.Add(this.gbMonedas);
            this.Controls.Add(this.lblTotalManifiestos);
            this.Controls.Add(this.pnlComandos);
            this.Controls.Add(this.txtFuncion);
            this.Controls.Add(this.lblFuncion);
            this.Controls.Add(this.txtUltimaTula);
            this.Controls.Add(this.dgvDistribucion);
            this.Controls.Add(this.lblUltimaTula);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.txtTula);
            this.Controls.Add(this.lblReceptor);
            this.Controls.Add(this.txtManifiesto);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.lblTula);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.lblManifiesto);
            this.Controls.Add(this.txtReceptor);
            this.Controls.Add(this.lblMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmRegistroTulas";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Registro de tulas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistroTulas_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegistroTulas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribucion)).EndInit();
            this.pnlComandos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadBolsas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulasNiquel)).EndInit();
            this.gbMonedas.ResumeLayout(false);
            this.gbMonedas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReceptor;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtReceptor;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.TextBox txtTula;
        private System.Windows.Forms.TextBox txtManifiesto;
        private System.Windows.Forms.Label lblTula;
        private System.Windows.Forms.Label lblManifiesto;
        private System.Windows.Forms.TextBox txtUltimaTula;
        private System.Windows.Forms.Label lblUltimaTula;
        private System.Windows.Forms.Label lblMas;
        private System.Windows.Forms.Label lblMenos;
        private System.Windows.Forms.Label lblPor;
        private System.Windows.Forms.Label lblDiv;
        private System.Windows.Forms.Label lblPunto;
        private System.Windows.Forms.TextBox txtFuncion;
        private System.Windows.Forms.Label lblFuncion;
        private System.Windows.Forms.Label lblTotalManifiestos;
        private System.Windows.Forms.DataGridView dgvDistribucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etiqueta;
        private System.Windows.Forms.Panel pnlComandos;
        private ComboBoxBusqueda cboDenominaciones;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.NumericUpDown nudCantidadBolsas;
        private System.Windows.Forms.Label lblCantidadBolsas;
        private System.Windows.Forms.Button btnAgregarTulaNiquel;
        private System.Windows.Forms.Button btnQuitarTulaNiquel;
        private System.Windows.Forms.DataGridView dgvTulasNiquel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDenominacion;
        private System.Windows.Forms.Button btnAgregarMonedas;
        private System.Windows.Forms.GroupBox gbMonedas;
    }
}

