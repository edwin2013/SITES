namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmLimiteEfectivo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLimiteEfectivo));
            this.dgvcajeros = new System.Windows.Forms.DataGridView();
            this.NombreCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteAltaDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteBajaDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteDol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteEUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLimiteAltaDen = new System.Windows.Forms.Label();
            this.lblLimiteBajaDen = new System.Windows.Forms.Label();
            this.lblLimiteDol = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.nudlimiteBD = new System.Windows.Forms.NumericUpDown();
            this.nudlimiteDOL = new System.Windows.Forms.NumericUpDown();
            this.gbParametrosLimiteEfectivo = new System.Windows.Forms.GroupBox();
            this.nudlimiteCOL = new System.Windows.Forms.NumericUpDown();
            this.lbllimitecolones = new System.Windows.Forms.Label();
            this.nudlimiteEUR = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCajeroDatos = new GUILayer.ComboBoxBusqueda();
            this.lblCajeroDatos = new System.Windows.Forms.Label();
            this.gblistacajeros = new System.Windows.Forms.GroupBox();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblcajero = new System.Windows.Forms.Label();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcajeros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudlimiteBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudlimiteDOL)).BeginInit();
            this.gbParametrosLimiteEfectivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudlimiteCOL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudlimiteEUR)).BeginInit();
            this.gblistacajeros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvcajeros
            // 
            this.dgvcajeros.AllowUserToAddRows = false;
            this.dgvcajeros.AllowUserToDeleteRows = false;
            this.dgvcajeros.AllowUserToOrderColumns = true;
            this.dgvcajeros.AllowUserToResizeColumns = false;
            this.dgvcajeros.AllowUserToResizeRows = false;
            this.dgvcajeros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcajeros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcajeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcajeros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCajero,
            this.LimiteAltaDen,
            this.LimiteBajaDen,
            this.LimiteColones,
            this.LimiteDol,
            this.LimiteEUR});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcajeros.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcajeros.EnableHeadersVisualStyles = false;
            this.dgvcajeros.Location = new System.Drawing.Point(8, 58);
            this.dgvcajeros.MultiSelect = false;
            this.dgvcajeros.Name = "dgvcajeros";
            this.dgvcajeros.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcajeros.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcajeros.RowHeadersVisible = false;
            this.dgvcajeros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcajeros.Size = new System.Drawing.Size(880, 301);
            this.dgvcajeros.TabIndex = 2;
            this.dgvcajeros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcajeros_CellClick);
            this.dgvcajeros.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvcajeros_MouseClick);
            // 
            // NombreCajero
            // 
            this.NombreCajero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreCajero.DataPropertyName = "Cajero";
            this.NombreCajero.HeaderText = "Nombre";
            this.NombreCajero.Name = "NombreCajero";
            this.NombreCajero.ReadOnly = true;
            // 
            // LimiteAltaDen
            // 
            this.LimiteAltaDen.DataPropertyName = "LimiteAD";
            this.LimiteAltaDen.HeaderText = "Límite Alta Denominación";
            this.LimiteAltaDen.Name = "LimiteAltaDen";
            this.LimiteAltaDen.ReadOnly = true;
            this.LimiteAltaDen.Width = 150;
            // 
            // LimiteBajaDen
            // 
            this.LimiteBajaDen.DataPropertyName = "LimiteBD";
            this.LimiteBajaDen.HeaderText = "Límite Baja Denominación";
            this.LimiteBajaDen.Name = "LimiteBajaDen";
            this.LimiteBajaDen.ReadOnly = true;
            this.LimiteBajaDen.Width = 150;
            // 
            // LimiteColones
            // 
            this.LimiteColones.DataPropertyName = "LimiteCOL";
            this.LimiteColones.HeaderText = "Limite Colones";
            this.LimiteColones.Name = "LimiteColones";
            this.LimiteColones.ReadOnly = true;
            // 
            // LimiteDol
            // 
            this.LimiteDol.DataPropertyName = "LimiteDOL";
            this.LimiteDol.HeaderText = "Límite Dólares";
            this.LimiteDol.Name = "LimiteDol";
            this.LimiteDol.ReadOnly = true;
            this.LimiteDol.Width = 150;
            // 
            // LimiteEUR
            // 
            this.LimiteEUR.DataPropertyName = "LimiteEUR";
            this.LimiteEUR.HeaderText = "Límite Euros";
            this.LimiteEUR.Name = "LimiteEUR";
            this.LimiteEUR.ReadOnly = true;
            this.LimiteEUR.Width = 150;
            // 
            // lblLimiteAltaDen
            // 
            this.lblLimiteAltaDen.AutoSize = true;
            this.lblLimiteAltaDen.Location = new System.Drawing.Point(107, 51);
            this.lblLimiteAltaDen.Name = "lblLimiteAltaDen";
            this.lblLimiteAltaDen.Size = new System.Drawing.Size(131, 13);
            this.lblLimiteAltaDen.TabIndex = 24;
            this.lblLimiteAltaDen.Text = "Límite Alta Denominación:";
            // 
            // lblLimiteBajaDen
            // 
            this.lblLimiteBajaDen.AutoSize = true;
            this.lblLimiteBajaDen.Location = new System.Drawing.Point(107, 78);
            this.lblLimiteBajaDen.Name = "lblLimiteBajaDen";
            this.lblLimiteBajaDen.Size = new System.Drawing.Size(134, 13);
            this.lblLimiteBajaDen.TabIndex = 26;
            this.lblLimiteBajaDen.Text = "Límite Baja Denominación:";
            // 
            // lblLimiteDol
            // 
            this.lblLimiteDol.AutoSize = true;
            this.lblLimiteDol.Location = new System.Drawing.Point(160, 137);
            this.lblLimiteDol.Name = "lblLimiteDol";
            this.lblLimiteDol.Size = new System.Drawing.Size(78, 13);
            this.lblLimiteDol.TabIndex = 28;
            this.lblLimiteDol.Text = "Límite Dólares:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(439, 191);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.FlatAppearance.BorderSize = 2;
            this.btnAplicar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnAplicar.Location = new System.Drawing.Point(321, 191);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(90, 38);
            this.btnAplicar.TabIndex = 6;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // nudMonto
            // 
            this.nudMonto.Location = new System.Drawing.Point(255, 49);
            this.nudMonto.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(454, 20);
            this.nudMonto.TabIndex = 1;
            // 
            // nudlimiteBD
            // 
            this.nudlimiteBD.Location = new System.Drawing.Point(255, 76);
            this.nudlimiteBD.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudlimiteBD.Name = "nudlimiteBD";
            this.nudlimiteBD.Size = new System.Drawing.Size(454, 20);
            this.nudlimiteBD.TabIndex = 2;
            // 
            // nudlimiteDOL
            // 
            this.nudlimiteDOL.Location = new System.Drawing.Point(255, 135);
            this.nudlimiteDOL.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudlimiteDOL.Name = "nudlimiteDOL";
            this.nudlimiteDOL.Size = new System.Drawing.Size(454, 20);
            this.nudlimiteDOL.TabIndex = 4;
            // 
            // gbParametrosLimiteEfectivo
            // 
            this.gbParametrosLimiteEfectivo.Controls.Add(this.nudlimiteCOL);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.lbllimitecolones);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.nudlimiteEUR);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.label1);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.cboCajeroDatos);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.lblCajeroDatos);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.btnSalir);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.lblLimiteAltaDen);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.nudlimiteDOL);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.lblLimiteBajaDen);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.nudlimiteBD);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.lblLimiteDol);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.nudMonto);
            this.gbParametrosLimiteEfectivo.Controls.Add(this.btnAplicar);
            this.gbParametrosLimiteEfectivo.Location = new System.Drawing.Point(5, 68);
            this.gbParametrosLimiteEfectivo.Name = "gbParametrosLimiteEfectivo";
            this.gbParametrosLimiteEfectivo.Size = new System.Drawing.Size(895, 237);
            this.gbParametrosLimiteEfectivo.TabIndex = 0;
            this.gbParametrosLimiteEfectivo.TabStop = false;
            this.gbParametrosLimiteEfectivo.Text = "Parámetros Límite de Efectivo";
            // 
            // nudlimiteCOL
            // 
            this.nudlimiteCOL.Location = new System.Drawing.Point(254, 106);
            this.nudlimiteCOL.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudlimiteCOL.Name = "nudlimiteCOL";
            this.nudlimiteCOL.Size = new System.Drawing.Size(454, 20);
            this.nudlimiteCOL.TabIndex = 3;
            // 
            // lbllimitecolones
            // 
            this.lbllimitecolones.AutoSize = true;
            this.lbllimitecolones.Location = new System.Drawing.Point(159, 108);
            this.lbllimitecolones.Name = "lbllimitecolones";
            this.lbllimitecolones.Size = new System.Drawing.Size(80, 13);
            this.lbllimitecolones.TabIndex = 40;
            this.lbllimitecolones.Text = "Límite Colones:";
            // 
            // nudlimiteEUR
            // 
            this.nudlimiteEUR.Location = new System.Drawing.Point(255, 161);
            this.nudlimiteEUR.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudlimiteEUR.Name = "nudlimiteEUR";
            this.nudlimiteEUR.Size = new System.Drawing.Size(454, 20);
            this.nudlimiteEUR.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Límite Euros:";
            // 
            // cboCajeroDatos
            // 
            this.cboCajeroDatos.Busqueda = true;
            this.cboCajeroDatos.FormattingEnabled = true;
            this.cboCajeroDatos.ListaMostrada = null;
            this.cboCajeroDatos.Location = new System.Drawing.Point(255, 19);
            this.cboCajeroDatos.Name = "cboCajeroDatos";
            this.cboCajeroDatos.Size = new System.Drawing.Size(454, 21);
            this.cboCajeroDatos.TabIndex = 0;
            this.cboCajeroDatos.SelectedIndexChanged += new System.EventHandler(this.cboCajeroDatos_SelectedIndexChanged);
            // 
            // lblCajeroDatos
            // 
            this.lblCajeroDatos.AutoSize = true;
            this.lblCajeroDatos.Location = new System.Drawing.Point(198, 22);
            this.lblCajeroDatos.Name = "lblCajeroDatos";
            this.lblCajeroDatos.Size = new System.Drawing.Size(40, 13);
            this.lblCajeroDatos.TabIndex = 36;
            this.lblCajeroDatos.Text = "Cajero:";
            // 
            // gblistacajeros
            // 
            this.gblistacajeros.Controls.Add(this.cboCajero);
            this.gblistacajeros.Controls.Add(this.btnBuscar);
            this.gblistacajeros.Controls.Add(this.lblcajero);
            this.gblistacajeros.Controls.Add(this.dgvcajeros);
            this.gblistacajeros.Location = new System.Drawing.Point(5, 311);
            this.gblistacajeros.Name = "gblistacajeros";
            this.gblistacajeros.Size = new System.Drawing.Size(895, 364);
            this.gblistacajeros.TabIndex = 1;
            this.gblistacajeros.TabStop = false;
            this.gblistacajeros.Text = "Lista de Cajeros y límites de efectivo";
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = true;
            this.cboCajero.FormattingEnabled = true;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(67, 24);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(339, 21);
            this.cboCajero.TabIndex = 0;
            this.cboCajero.SelectedIndexChanged += new System.EventHandler(this.cboCajero_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(427, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 38);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblcajero
            // 
            this.lblcajero.AutoSize = true;
            this.lblcajero.Location = new System.Drawing.Point(21, 27);
            this.lblcajero.Name = "lblcajero";
            this.lblcajero.Size = new System.Drawing.Size(40, 13);
            this.lblcajero.TabIndex = 29;
            this.lblcajero.Text = "Cajero:";
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(3, 3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(897, 60);
            this.pnlFondo.TabIndex = 39;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmLimiteEfectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 677);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gblistacajeros);
            this.Controls.Add(this.gbParametrosLimiteEfectivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLimiteEfectivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Límite de Efectivo";
            this.Load += new System.EventHandler(this.frmLimiteEfectivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcajeros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudlimiteBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudlimiteDOL)).EndInit();
            this.gbParametrosLimiteEfectivo.ResumeLayout(false);
            this.gbParametrosLimiteEfectivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudlimiteCOL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudlimiteEUR)).EndInit();
            this.gblistacajeros.ResumeLayout(false);
            this.gblistacajeros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvcajeros;
        private System.Windows.Forms.Label lblLimiteAltaDen;
        private System.Windows.Forms.Label lblLimiteBajaDen;
        private System.Windows.Forms.Label lblLimiteDol;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.NumericUpDown nudlimiteBD;
        private System.Windows.Forms.NumericUpDown nudlimiteDOL;
        private System.Windows.Forms.GroupBox gbParametrosLimiteEfectivo;
        private System.Windows.Forms.GroupBox gblistacajeros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblcajero;
        private ComboBoxBusqueda cboCajeroDatos;
        private System.Windows.Forms.Label lblCajeroDatos;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.NumericUpDown nudlimiteEUR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteAltaDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteBajaDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteDol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteEUR;
        private System.Windows.Forms.NumericUpDown nudlimiteCOL;
        private System.Windows.Forms.Label lbllimitecolones;
    }
}