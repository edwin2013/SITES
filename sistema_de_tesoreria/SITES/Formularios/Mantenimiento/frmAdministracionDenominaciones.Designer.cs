namespace GUILayer
{
    partial class frmAdministracionDenominaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionDenominaciones));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDenominaciones = new System.Windows.Forms.GroupBox();
            this.dgvDenominaciones = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfiguracionOpteva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfiguracionDiebold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimoFormulas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaximoFormulas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargaATM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDenominaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDenominaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-4, -4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(808, 60);
            this.pnlFondo.TabIndex = 7;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDenominaciones
            // 
            this.gbDenominaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDenominaciones.Controls.Add(this.dgvDenominaciones);
            this.gbDenominaciones.Location = new System.Drawing.Point(11, 62);
            this.gbDenominaciones.Name = "gbDenominaciones";
            this.gbDenominaciones.Size = new System.Drawing.Size(769, 446);
            this.gbDenominaciones.TabIndex = 8;
            this.gbDenominaciones.TabStop = false;
            this.gbDenominaciones.Text = "Lista de Denominaciones";
            // 
            // dgvDenominaciones
            // 
            this.dgvDenominaciones.AllowUserToAddRows = false;
            this.dgvDenominaciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvDenominaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDenominaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDenominaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDenominaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDenominaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDenominaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDenominaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Moneda,
            this.Valor,
            this.Codigo,
            this.ConfiguracionOpteva,
            this.ConfiguracionDiebold,
            this.MinimoFormulas,
            this.MaximoFormulas,
            this.CargaATM});
            this.dgvDenominaciones.EnableHeadersVisualStyles = false;
            this.dgvDenominaciones.Location = new System.Drawing.Point(6, 19);
            this.dgvDenominaciones.MultiSelect = false;
            this.dgvDenominaciones.Name = "dgvDenominaciones";
            this.dgvDenominaciones.ReadOnly = true;
            this.dgvDenominaciones.RowHeadersVisible = false;
            this.dgvDenominaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDenominaciones.Size = new System.Drawing.Size(757, 421);
            this.dgvDenominaciones.StandardTab = true;
            this.dgvDenominaciones.TabIndex = 0;
            this.dgvDenominaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDenominaciones_CellDoubleClick);
            this.dgvDenominaciones.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDenominaciones_RowsAdded);
            this.dgvDenominaciones.SelectionChanged += new System.EventHandler(this.dgvDenominaciones_SelectionChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(684, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(492, 514);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNueva.FlatAppearance.BorderSize = 2;
            this.btnNueva.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNueva.Location = new System.Drawing.Point(396, 514);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(90, 40);
            this.btnNueva.TabIndex = 10;
            this.btnNueva.Text = "Agregar";
            this.btnNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNueva.UseVisualStyleBackColor = false;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(588, 514);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Moneda
            // 
            this.Moneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            this.Moneda.Width = 70;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle2.Format = "N0";
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 55;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 64;
            // 
            // ConfiguracionOpteva
            // 
            this.ConfiguracionOpteva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ConfiguracionOpteva.DataPropertyName = "Configuracion_opteva";
            this.ConfiguracionOpteva.HeaderText = "C. Opteva";
            this.ConfiguracionOpteva.Name = "ConfiguracionOpteva";
            this.ConfiguracionOpteva.ReadOnly = true;
            this.ConfiguracionOpteva.Width = 79;
            // 
            // ConfiguracionDiebold
            // 
            this.ConfiguracionDiebold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ConfiguracionDiebold.DataPropertyName = "Configuracion_diebold";
            this.ConfiguracionDiebold.HeaderText = "C. Diebold";
            this.ConfiguracionDiebold.Name = "ConfiguracionDiebold";
            this.ConfiguracionDiebold.ReadOnly = true;
            this.ConfiguracionDiebold.Width = 80;
            // 
            // MinimoFormulas
            // 
            this.MinimoFormulas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MinimoFormulas.DataPropertyName = "Formulas_minimas";
            dataGridViewCellStyle3.Format = "N0";
            this.MinimoFormulas.DefaultCellStyle = dataGridViewCellStyle3;
            this.MinimoFormulas.HeaderText = "F. Mínimas";
            this.MinimoFormulas.Name = "MinimoFormulas";
            this.MinimoFormulas.ReadOnly = true;
            this.MinimoFormulas.Width = 83;
            // 
            // MaximoFormulas
            // 
            this.MaximoFormulas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaximoFormulas.DataPropertyName = "Formulas_maximas";
            dataGridViewCellStyle4.Format = "N0";
            this.MaximoFormulas.DefaultCellStyle = dataGridViewCellStyle4;
            this.MaximoFormulas.HeaderText = "F. Máximas";
            this.MaximoFormulas.Name = "MaximoFormulas";
            this.MaximoFormulas.ReadOnly = true;
            this.MaximoFormulas.Width = 84;
            // 
            // CargaATM
            // 
            this.CargaATM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CargaATM.DataPropertyName = "Carga_atm";
            this.CargaATM.HeaderText = "Carga";
            this.CargaATM.Name = "CargaATM";
            this.CargaATM.ReadOnly = true;
            this.CargaATM.Width = 40;
            // 
            // frmAdministracionDenominaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDenominaciones);
            this.Controls.Add(this.btnEliminar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionDenominaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Denominaciones";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDenominaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDenominaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDenominaciones;
        private System.Windows.Forms.DataGridView dgvDenominaciones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfiguracionOpteva;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfiguracionDiebold;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinimoFormulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaximoFormulas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CargaATM;
    }
}