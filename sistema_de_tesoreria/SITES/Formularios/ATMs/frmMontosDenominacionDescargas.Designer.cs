namespace GUILayer
{
    partial class frmMontosDenominacionDescargas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMontosDenominacionDescargas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbMontos = new System.Windows.Forms.GroupBox();
            this.dgvMontos = new System.Windows.Forms.DataGridView();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formulas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontosMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadCola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontosCola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMontos
            // 
            this.gbMontos.Controls.Add(this.dgvMontos);
            this.gbMontos.Location = new System.Drawing.Point(12, 66);
            this.gbMontos.Name = "gbMontos";
            this.gbMontos.Size = new System.Drawing.Size(770, 292);
            this.gbMontos.TabIndex = 4;
            this.gbMontos.TabStop = false;
            this.gbMontos.Text = "Cantidad de Cartuchos por Denominación y Tipo";
            // 
            // dgvMontos
            // 
            this.dgvMontos.AllowUserToAddRows = false;
            this.dgvMontos.AllowUserToDeleteRows = false;
            this.dgvMontos.AllowUserToOrderColumns = true;
            this.dgvMontos.AllowUserToResizeColumns = false;
            this.dgvMontos.AllowUserToResizeRows = false;
            this.dgvMontos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Denominacion,
            this.Monto,
            this.Formulas,
            this.CantidadMesa,
            this.MontosMesa,
            this.CantidadCola,
            this.MontosCola});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMontos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMontos.EnableHeadersVisualStyles = false;
            this.dgvMontos.Location = new System.Drawing.Point(6, 16);
            this.dgvMontos.Name = "dgvMontos";
            this.dgvMontos.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMontos.RowHeadersVisible = false;
            this.dgvMontos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMontos.Size = new System.Drawing.Size(758, 270);
            this.dgvMontos.StandardTab = true;
            this.dgvMontos.TabIndex = 0;
            this.dgvMontos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvMontos_RowsAdded);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(794, 60);
            this.pnlFondo.TabIndex = 3;
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
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(686, 364);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Denominacion
            // 
            this.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Denominacion.HeaderText = "Denominación";
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.ReadOnly = true;
            this.Denominacion.Width = 99;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "N0";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 61;
            // 
            // Formulas
            // 
            this.Formulas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Formulas.HeaderText = "Fórmulas";
            this.Formulas.Name = "Formulas";
            this.Formulas.ReadOnly = true;
            this.Formulas.Width = 73;
            // 
            // CantidadMesa
            // 
            this.CantidadMesa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "N0";
            this.CantidadMesa.DefaultCellStyle = dataGridViewCellStyle3;
            this.CantidadMesa.HeaderText = "C. en Mesa";
            this.CantidadMesa.Name = "CantidadMesa";
            this.CantidadMesa.ReadOnly = true;
            this.CantidadMesa.Width = 85;
            // 
            // MontosMesa
            // 
            this.MontosMesa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "N2";
            this.MontosMesa.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontosMesa.HeaderText = "M. en Mesa";
            this.MontosMesa.Name = "MontosMesa";
            this.MontosMesa.ReadOnly = true;
            this.MontosMesa.Width = 87;
            // 
            // CantidadCola
            // 
            this.CantidadCola.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.NullValue = "N0";
            this.CantidadCola.DefaultCellStyle = dataGridViewCellStyle5;
            this.CantidadCola.HeaderText = "C. en Cola";
            this.CantidadCola.Name = "CantidadCola";
            this.CantidadCola.ReadOnly = true;
            this.CantidadCola.Width = 80;
            // 
            // MontosCola
            // 
            this.MontosCola.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Format = "N2";
            this.MontosCola.DefaultCellStyle = dataGridViewCellStyle6;
            this.MontosCola.HeaderText = "M. en Cola";
            this.MontosCola.Name = "MontosCola";
            this.MontosCola.ReadOnly = true;
            this.MontosCola.Width = 82;
            // 
            // frmMontosDenominacionDescargas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 416);
            this.Controls.Add(this.gbMontos);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMontosDenominacionDescargas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Montos Descargados por Denominación";
            this.gbMontos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontos)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMontos;
        private System.Windows.Forms.DataGridView dgvMontos;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontosMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadCola;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontosCola;
    }
}