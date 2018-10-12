namespace GUILayer
{
    partial class frmInclusionPuntosVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInclusionPuntosVenta));
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.dgvPuntosVenta = new System.Windows.Forms.DataGridView();
            this.PuntoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarSucursal = new System.Windows.Forms.Button();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbPuntosVenta = new System.Windows.Forms.GroupBox();
            this.lblPuntosVenta = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntosVenta)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbPuntosVenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(17, 49);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(84, 13);
            this.lblPuntoVenta.TabIndex = 2;
            this.lblPuntoVenta.Text = "Punto de Venta:";
            // 
            // dgvPuntosVenta
            // 
            this.dgvPuntosVenta.AllowUserToAddRows = false;
            this.dgvPuntosVenta.AllowUserToDeleteRows = false;
            this.dgvPuntosVenta.AllowUserToOrderColumns = true;
            this.dgvPuntosVenta.AllowUserToResizeColumns = false;
            this.dgvPuntosVenta.AllowUserToResizeRows = false;
            this.dgvPuntosVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPuntosVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPuntosVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPuntosVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PuntoVenta});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPuntosVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPuntosVenta.EnableHeadersVisualStyles = false;
            this.dgvPuntosVenta.Location = new System.Drawing.Point(101, 117);
            this.dgvPuntosVenta.Name = "dgvPuntosVenta";
            this.dgvPuntosVenta.ReadOnly = true;
            this.dgvPuntosVenta.RowHeadersVisible = false;
            this.dgvPuntosVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPuntosVenta.Size = new System.Drawing.Size(251, 177);
            this.dgvPuntosVenta.TabIndex = 6;
            // 
            // PuntoVenta
            // 
            this.PuntoVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PuntoVenta.DataPropertyName = "Nombre";
            this.PuntoVenta.HeaderText = "Punto de Venta";
            this.PuntoVenta.Name = "PuntoVenta";
            this.PuntoVenta.ReadOnly = true;
            // 
            // btnAgregarSucursal
            // 
            this.btnAgregarSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarSucursal.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarSucursal.Location = new System.Drawing.Point(262, 71);
            this.btnAgregarSucursal.Name = "btnAgregarSucursal";
            this.btnAgregarSucursal.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarSucursal.TabIndex = 4;
            this.btnAgregarSucursal.Text = "Agregar";
            this.btnAgregarSucursal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarSucursal.UseVisualStyleBackColor = false;
            this.btnAgregarSucursal.Click += new System.EventHandler(this.btnAgregarSucursal_Click);
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(101, 45);
            this.txtSucursal.MaxLength = 100;
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(251, 20);
            this.txtSucursal.TabIndex = 3;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(412, 43);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(319, 39);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(274, 352);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbPuntosVenta
            // 
            this.gbPuntosVenta.Controls.Add(this.lblPuntosVenta);
            this.gbPuntosVenta.Controls.Add(this.txtSucursal);
            this.gbPuntosVenta.Controls.Add(this.lblPuntoVenta);
            this.gbPuntosVenta.Controls.Add(this.txtCliente);
            this.gbPuntosVenta.Controls.Add(this.btnAgregarSucursal);
            this.gbPuntosVenta.Controls.Add(this.dgvPuntosVenta);
            this.gbPuntosVenta.Controls.Add(this.lblCliente);
            this.gbPuntosVenta.Location = new System.Drawing.Point(12, 46);
            this.gbPuntosVenta.Name = "gbPuntosVenta";
            this.gbPuntosVenta.Size = new System.Drawing.Size(358, 300);
            this.gbPuntosVenta.TabIndex = 1;
            this.gbPuntosVenta.TabStop = false;
            this.gbPuntosVenta.Text = "Puntos de Venta del Cliente";
            // 
            // lblPuntosVenta
            // 
            this.lblPuntosVenta.AutoSize = true;
            this.lblPuntosVenta.Location = new System.Drawing.Point(6, 117);
            this.lblPuntosVenta.Name = "lblPuntosVenta";
            this.lblPuntosVenta.Size = new System.Drawing.Size(89, 13);
            this.lblPuntosVenta.TabIndex = 5;
            this.lblPuntosVenta.Text = "Puntos de Venta:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(101, 19);
            this.txtCliente.MaxLength = 15;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(251, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(53, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // frmInclusionPuntosVenta
            // 
            this.AcceptButton = this.btnAgregarSucursal;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(382, 404);
            this.Controls.Add(this.gbPuntosVenta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInclusionPuntosVenta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Punto de Venta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntosVenta)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbPuntosVenta.ResumeLayout(false);
            this.gbPuntosVenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.DataGridView dgvPuntosVenta;
        private System.Windows.Forms.Button btnAgregarSucursal;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbPuntosVenta;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPuntosVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntoVenta;
    }
}