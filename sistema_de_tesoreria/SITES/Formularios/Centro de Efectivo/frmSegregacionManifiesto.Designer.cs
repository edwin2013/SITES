namespace GUILayer
{
    partial class frmSegregacionManifiesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSegregacionManifiesto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nudCajeros = new System.Windows.Forms.NumericUpDown();
            this.lblNumeroCajeros = new System.Windows.Forms.Label();
            this.gbSegregacion = new System.Windows.Forms.GroupBox();
            this.btnSegregar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Menifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigoBuscado = new System.Windows.Forms.TextBox();
            this.lblManifiestoBuscado = new System.Windows.Forms.Label();
            this.gbManifiestosSegregados = new System.Windows.Forms.GroupBox();
            this.dgvManifiestosSegregados = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajeros)).BeginInit();
            this.gbSegregacion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.gbManifiestosSegregados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestosSegregados)).BeginInit();
            this.SuspendLayout();
            // 
            // nudCajeros
            // 
            this.nudCajeros.Location = new System.Drawing.Point(133, 23);
            this.nudCajeros.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudCajeros.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCajeros.Name = "nudCajeros";
            this.nudCajeros.Size = new System.Drawing.Size(85, 20);
            this.nudCajeros.TabIndex = 1;
            this.nudCajeros.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCajeros.Enter += new System.EventHandler(this.nudCajeros_Enter);
            // 
            // lblNumeroCajeros
            // 
            this.lblNumeroCajeros.AutoSize = true;
            this.lblNumeroCajeros.Location = new System.Drawing.Point(27, 25);
            this.lblNumeroCajeros.Name = "lblNumeroCajeros";
            this.lblNumeroCajeros.Size = new System.Drawing.Size(100, 13);
            this.lblNumeroCajeros.TabIndex = 0;
            this.lblNumeroCajeros.Text = "Número de Cajeros:";
            // 
            // gbSegregacion
            // 
            this.gbSegregacion.Controls.Add(this.lblNumeroCajeros);
            this.gbSegregacion.Controls.Add(this.nudCajeros);
            this.gbSegregacion.Controls.Add(this.btnSegregar);
            this.gbSegregacion.Enabled = false;
            this.gbSegregacion.Location = new System.Drawing.Point(374, 61);
            this.gbSegregacion.Name = "gbSegregacion";
            this.gbSegregacion.Size = new System.Drawing.Size(320, 59);
            this.gbSegregacion.TabIndex = 2;
            this.gbSegregacion.TabStop = false;
            this.gbSegregacion.Text = "Segregación";
            // 
            // btnSegregar
            // 
            this.btnSegregar.FlatAppearance.BorderSize = 2;
            this.btnSegregar.Image = global::GUILayer.Properties.Resources.segregacion;
            this.btnSegregar.Location = new System.Drawing.Point(224, 13);
            this.btnSegregar.Name = "btnSegregar";
            this.btnSegregar.Size = new System.Drawing.Size(90, 40);
            this.btnSegregar.TabIndex = 2;
            this.btnSegregar.Text = "Segregar";
            this.btnSegregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSegregar.UseVisualStyleBackColor = false;
            this.btnSegregar.Click += new System.EventHandler(this.btnSegregar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(752, 58);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(379, 50);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dgvManifiestos);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Controls.Add(this.txtCodigoBuscado);
            this.gbBusqueda.Controls.Add(this.lblManifiestoBuscado);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 61);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbBusqueda.Size = new System.Drawing.Size(356, 402);
            this.gbBusqueda.TabIndex = 1;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda de Manifiestos";
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
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 68);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvManifiestos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(344, 328);
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
            // btnBuscar
            // 
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(260, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigoBuscado
            // 
            this.txtCodigoBuscado.Location = new System.Drawing.Point(80, 30);
            this.txtCodigoBuscado.Name = "txtCodigoBuscado";
            this.txtCodigoBuscado.Size = new System.Drawing.Size(174, 20);
            this.txtCodigoBuscado.TabIndex = 1;
            this.txtCodigoBuscado.Enter += new System.EventHandler(this.txtCodigoBuscado_Enter);
            // 
            // lblManifiestoBuscado
            // 
            this.lblManifiestoBuscado.AutoSize = true;
            this.lblManifiestoBuscado.Location = new System.Drawing.Point(31, 33);
            this.lblManifiestoBuscado.Name = "lblManifiestoBuscado";
            this.lblManifiestoBuscado.Size = new System.Drawing.Size(43, 13);
            this.lblManifiestoBuscado.TabIndex = 0;
            this.lblManifiestoBuscado.Text = "Código:";
            // 
            // gbManifiestosSegregados
            // 
            this.gbManifiestosSegregados.Controls.Add(this.dgvManifiestosSegregados);
            this.gbManifiestosSegregados.Enabled = false;
            this.gbManifiestosSegregados.Location = new System.Drawing.Point(374, 126);
            this.gbManifiestosSegregados.Name = "gbManifiestosSegregados";
            this.gbManifiestosSegregados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbManifiestosSegregados.Size = new System.Drawing.Size(356, 337);
            this.gbManifiestosSegregados.TabIndex = 3;
            this.gbManifiestosSegregados.TabStop = false;
            this.gbManifiestosSegregados.Text = "Manifiestos Segregados";
            // 
            // dgvManifiestosSegregados
            // 
            this.dgvManifiestosSegregados.AllowUserToAddRows = false;
            this.dgvManifiestosSegregados.AllowUserToDeleteRows = false;
            this.dgvManifiestosSegregados.AllowUserToResizeColumns = false;
            this.dgvManifiestosSegregados.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvManifiestosSegregados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvManifiestosSegregados.BackgroundColor = System.Drawing.Color.White;
            this.dgvManifiestosSegregados.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvManifiestosSegregados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestosSegregados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvManifiestosSegregados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestosSegregados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ID});
            this.dgvManifiestosSegregados.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestosSegregados.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvManifiestosSegregados.EnableHeadersVisualStyles = false;
            this.dgvManifiestosSegregados.Location = new System.Drawing.Point(6, 23);
            this.dgvManifiestosSegregados.MultiSelect = false;
            this.dgvManifiestosSegregados.Name = "dgvManifiestosSegregados";
            this.dgvManifiestosSegregados.ReadOnly = true;
            this.dgvManifiestosSegregados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvManifiestosSegregados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestosSegregados.RowHeadersVisible = false;
            this.dgvManifiestosSegregados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestosSegregados.Size = new System.Drawing.Size(344, 308);
            this.dgvManifiestosSegregados.TabIndex = 0;
            this.dgvManifiestosSegregados.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Manifiesto";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.HeaderText = "Código de Manifiesto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(634, 469);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(538, 469);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmSegregacionManifiesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(743, 521);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.gbManifiestosSegregados);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbSegregacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSegregacionManifiesto";
            this.ShowInTaskbar = false;
            this.Text = "Segregar Manifiesto";
            ((System.ComponentModel.ISupportInitialize)(this.nudCajeros)).EndInit();
            this.gbSegregacion.ResumeLayout(false);
            this.gbSegregacion.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.gbManifiestosSegregados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestosSegregados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCajeros;
        private System.Windows.Forms.Label lblNumeroCajeros;
        private System.Windows.Forms.GroupBox gbSegregacion;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnSegregar;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menifiesto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCodigoBuscado;
        private System.Windows.Forms.Label lblManifiestoBuscado;
        private System.Windows.Forms.GroupBox gbManifiestosSegregados;
        private System.Windows.Forms.DataGridView dgvManifiestosSegregados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Button btnEliminar;
    }
}