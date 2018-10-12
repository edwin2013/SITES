namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmMonitoreoLimiteEfectivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitoreoLimiteEfectivo));
            this.gblistacajeros = new System.Windows.Forms.GroupBox();
            this.btnLimpiarMontos = new System.Windows.Forms.Button();
            this.btnmantenimiento = new System.Windows.Forms.Button();
            this.cboCajero = new GUILayer.ComboBoxBusqueda();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblcajero = new System.Windows.Forms.Label();
            this.dgvcajeros = new System.Windows.Forms.DataGridView();
            this.NombreCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteAltaDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteBajaDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteDol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Limite_EUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoActualAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoActualBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoActualUSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoActualEUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pk_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gblistacajeros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcajeros)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gblistacajeros
            // 
            this.gblistacajeros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gblistacajeros.Controls.Add(this.btnLimpiarMontos);
            this.gblistacajeros.Controls.Add(this.btnmantenimiento);
            this.gblistacajeros.Controls.Add(this.cboCajero);
            this.gblistacajeros.Controls.Add(this.btnBuscar);
            this.gblistacajeros.Controls.Add(this.lblcajero);
            this.gblistacajeros.Controls.Add(this.dgvcajeros);
            this.gblistacajeros.Location = new System.Drawing.Point(2, 66);
            this.gblistacajeros.Name = "gblistacajeros";
            this.gblistacajeros.Size = new System.Drawing.Size(1116, 494);
            this.gblistacajeros.TabIndex = 39;
            this.gblistacajeros.TabStop = false;
            this.gblistacajeros.Text = "Lista de Cajeros y límites de efectivo";
            // 
            // btnLimpiarMontos
            // 
            this.btnLimpiarMontos.FlatAppearance.BorderSize = 2;
            this.btnLimpiarMontos.Location = new System.Drawing.Point(640, 26);
            this.btnLimpiarMontos.Name = "btnLimpiarMontos";
            this.btnLimpiarMontos.Size = new System.Drawing.Size(100, 38);
            this.btnLimpiarMontos.TabIndex = 40;
            this.btnLimpiarMontos.Text = "Limpiar denominaciones";
            this.btnLimpiarMontos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiarMontos.UseVisualStyleBackColor = false;
            this.btnLimpiarMontos.Click += new System.EventHandler(this.btnLimpiarMontos_Click);
            // 
            // btnmantenimiento
            // 
            this.btnmantenimiento.FlatAppearance.BorderSize = 2;
            this.btnmantenimiento.Location = new System.Drawing.Point(533, 26);
            this.btnmantenimiento.Name = "btnmantenimiento";
            this.btnmantenimiento.Size = new System.Drawing.Size(90, 38);
            this.btnmantenimiento.TabIndex = 39;
            this.btnmantenimiento.Text = "Mantenimiento";
            this.btnmantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmantenimiento.UseVisualStyleBackColor = false;
            this.btnmantenimiento.Click += new System.EventHandler(this.btnmantenimiento_Click);
            // 
            // cboCajero
            // 
            this.cboCajero.Busqueda = true;
            this.cboCajero.FormattingEnabled = true;
            this.cboCajero.ListaMostrada = null;
            this.cboCajero.Location = new System.Drawing.Point(66, 36);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(339, 21);
            this.cboCajero.TabIndex = 38;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.Location = new System.Drawing.Point(426, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 38);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Actualizar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblcajero
            // 
            this.lblcajero.AutoSize = true;
            this.lblcajero.Location = new System.Drawing.Point(20, 39);
            this.lblcajero.Name = "lblcajero";
            this.lblcajero.Size = new System.Drawing.Size(40, 13);
            this.lblcajero.TabIndex = 29;
            this.lblcajero.Text = "Cajero:";
            // 
            // dgvcajeros
            // 
            this.dgvcajeros.AllowUserToAddRows = false;
            this.dgvcajeros.AllowUserToDeleteRows = false;
            this.dgvcajeros.AllowUserToOrderColumns = true;
            this.dgvcajeros.AllowUserToResizeColumns = false;
            this.dgvcajeros.AllowUserToResizeRows = false;
            this.dgvcajeros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvcajeros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvcajeros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.ApellidoCajero,
            this.LimiteAltaDen,
            this.LimiteBajaDen,
            this.LimiteColones,
            this.LimiteDol,
            this.Limite_EUR,
            this.MontoActualAD,
            this.MontoActualBD,
            this.MontoColones,
            this.MontoActualUSD,
            this.MontoActualEUR,
            this.pk_ID});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcajeros.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvcajeros.EnableHeadersVisualStyles = false;
            this.dgvcajeros.Location = new System.Drawing.Point(8, 87);
            this.dgvcajeros.MultiSelect = false;
            this.dgvcajeros.Name = "dgvcajeros";
            this.dgvcajeros.ReadOnly = true;
            this.dgvcajeros.RowHeadersVisible = false;
            this.dgvcajeros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcajeros.Size = new System.Drawing.Size(1100, 399);
            this.dgvcajeros.TabIndex = 22;
            // 
            // NombreCajero
            // 
            this.NombreCajero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NombreCajero.DataPropertyName = "NombreCajero";
            this.NombreCajero.HeaderText = "Nombre";
            this.NombreCajero.Name = "NombreCajero";
            this.NombreCajero.ReadOnly = true;
            this.NombreCajero.Width = 68;
            // 
            // ApellidoCajero
            // 
            this.ApellidoCajero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ApellidoCajero.DataPropertyName = "ApellidoCajero";
            this.ApellidoCajero.HeaderText = "Apellido";
            this.ApellidoCajero.Name = "ApellidoCajero";
            this.ApellidoCajero.ReadOnly = true;
            this.ApellidoCajero.Width = 68;
            // 
            // LimiteAltaDen
            // 
            this.LimiteAltaDen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LimiteAltaDen.DataPropertyName = "Limite_AD";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.LimiteAltaDen.DefaultCellStyle = dataGridViewCellStyle2;
            this.LimiteAltaDen.HeaderText = "Límite Alta Denominación";
            this.LimiteAltaDen.Name = "LimiteAltaDen";
            this.LimiteAltaDen.ReadOnly = true;
            this.LimiteAltaDen.Width = 139;
            // 
            // LimiteBajaDen
            // 
            this.LimiteBajaDen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LimiteBajaDen.DataPropertyName = "Limite_BD";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.LimiteBajaDen.DefaultCellStyle = dataGridViewCellStyle3;
            this.LimiteBajaDen.HeaderText = "Límite Baja Denominación";
            this.LimiteBajaDen.Name = "LimiteBajaDen";
            this.LimiteBajaDen.ReadOnly = true;
            this.LimiteBajaDen.Width = 141;
            // 
            // LimiteColones
            // 
            this.LimiteColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LimiteColones.DataPropertyName = "Limite_COL";
            dataGridViewCellStyle4.Format = "N2";
            this.LimiteColones.DefaultCellStyle = dataGridViewCellStyle4;
            this.LimiteColones.HeaderText = "Limite Total Colones";
            this.LimiteColones.Name = "LimiteColones";
            this.LimiteColones.ReadOnly = true;
            this.LimiteColones.Width = 115;
            // 
            // LimiteDol
            // 
            this.LimiteDol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LimiteDol.DataPropertyName = "Limite_DOL";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.LimiteDol.DefaultCellStyle = dataGridViewCellStyle5;
            this.LimiteDol.HeaderText = "Límite Dólares";
            this.LimiteDol.Name = "LimiteDol";
            this.LimiteDol.ReadOnly = true;
            this.LimiteDol.Width = 91;
            // 
            // Limite_EUR
            // 
            this.Limite_EUR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Limite_EUR.DataPropertyName = "Limite_EUR";
            dataGridViewCellStyle6.Format = "N2";
            this.Limite_EUR.DefaultCellStyle = dataGridViewCellStyle6;
            this.Limite_EUR.HeaderText = "Límite Euros";
            this.Limite_EUR.Name = "Limite_EUR";
            this.Limite_EUR.ReadOnly = true;
            this.Limite_EUR.Width = 83;
            // 
            // MontoActualAD
            // 
            this.MontoActualAD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoActualAD.DataPropertyName = "MontoAD";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.MontoActualAD.DefaultCellStyle = dataGridViewCellStyle7;
            this.MontoActualAD.HeaderText = "Monto Actual Alta Denominación";
            this.MontoActualAD.Name = "MontoActualAD";
            this.MontoActualAD.ReadOnly = true;
            this.MontoActualAD.Width = 169;
            // 
            // MontoActualBD
            // 
            this.MontoActualBD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoActualBD.DataPropertyName = "MontoBD";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.MontoActualBD.DefaultCellStyle = dataGridViewCellStyle8;
            this.MontoActualBD.HeaderText = "Monto Actual Baja Denominación";
            this.MontoActualBD.Name = "MontoActualBD";
            this.MontoActualBD.ReadOnly = true;
            this.MontoActualBD.Width = 172;
            // 
            // MontoColones
            // 
            this.MontoColones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoColones.DataPropertyName = "MontoCOL";
            dataGridViewCellStyle9.Format = "N2";
            this.MontoColones.DefaultCellStyle = dataGridViewCellStyle9;
            this.MontoColones.HeaderText = "Monto Actual Colones";
            this.MontoColones.Name = "MontoColones";
            this.MontoColones.ReadOnly = true;
            this.MontoColones.Width = 123;
            // 
            // MontoActualUSD
            // 
            this.MontoActualUSD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoActualUSD.DataPropertyName = "MontoDOL";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.MontoActualUSD.DefaultCellStyle = dataGridViewCellStyle10;
            this.MontoActualUSD.HeaderText = "Monto Actual Dólares";
            this.MontoActualUSD.Name = "MontoActualUSD";
            this.MontoActualUSD.ReadOnly = true;
            this.MontoActualUSD.Width = 122;
            // 
            // MontoActualEUR
            // 
            this.MontoActualEUR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoActualEUR.DataPropertyName = "MontoEUR";
            dataGridViewCellStyle11.Format = "N2";
            this.MontoActualEUR.DefaultCellStyle = dataGridViewCellStyle11;
            this.MontoActualEUR.HeaderText = "Monto Actual Euros";
            this.MontoActualEUR.Name = "MontoActualEUR";
            this.MontoActualEUR.ReadOnly = true;
            this.MontoActualEUR.Width = 113;
            // 
            // pk_ID
            // 
            this.pk_ID.DataPropertyName = "pk_ID";
            this.pk_ID.HeaderText = "pk_ID";
            this.pk_ID.Name = "pk_ID";
            this.pk_ID.ReadOnly = true;
            this.pk_ID.Visible = false;
            this.pk_ID.Width = 60;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-10, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1130, 60);
            this.pnlFondo.TabIndex = 40;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(11, -1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(435, 58);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmMonitoreoLimiteEfectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1122, 563);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gblistacajeros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(788, 540);
            this.Name = "frmMonitoreoLimiteEfectivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Monitoreo de Limite de Efectivo";
            this.Load += new System.EventHandler(this.frmMonitoreoLimiteEfectivo_Load);
            this.gblistacajeros.ResumeLayout(false);
            this.gblistacajeros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcajeros)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gblistacajeros;
        private ComboBoxBusqueda cboCajero;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblcajero;
        private System.Windows.Forms.DataGridView dgvcajeros;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnmantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteAltaDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteBajaDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteDol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Limite_EUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoActualAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoActualBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoActualUSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoActualEUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn pk_ID;
        private System.Windows.Forms.Button btnLimpiarMontos;
    }
}