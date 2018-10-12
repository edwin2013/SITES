namespace GUILayer
{
    partial class frmSeleccionManifiestoDescargaATMFull
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionManifiestoDescargaATMFull));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Menifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigoBuscado = new System.Windows.Forms.TextBox();
            this.lblManifiestoBuscado = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatosManifiesto = new System.Windows.Forms.GroupBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlENA = new System.Windows.Forms.Panel();
            this.lblMarchamoENAB = new System.Windows.Forms.Label();
            this.txtMarchamoAdicionalENA = new System.Windows.Forms.TextBox();
            this.lblMarchamoAdicionalENA = new System.Windows.Forms.Label();
            this.txtMarchamoENAB = new System.Windows.Forms.TextBox();
            this.lblMarchamoENAA = new System.Windows.Forms.Label();
            this.txtMarchamoENAA = new System.Windows.Forms.TextBox();
            this.lblMarchamo = new System.Windows.Forms.Label();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiesto = new System.Windows.Forms.Label();
            this.txtMarchamo = new System.Windows.Forms.TextBox();
            this.txtManifiestoAnteriorENA = new System.Windows.Forms.TextBox();
            this.lblManifiestoAnteriorENA = new System.Windows.Forms.Label();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatosManifiesto.SuspendLayout();
            this.pnlENA.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(458, 292);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dgvManifiestos);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Controls.Add(this.txtCodigoBuscado);
            this.gbBusqueda.Controls.Add(this.lblManifiestoBuscado);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 56);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbBusqueda.Size = new System.Drawing.Size(314, 276);
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
            this.dgvManifiestos.GridColor = System.Drawing.Color.Black;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 65);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvManifiestos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(302, 205);
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
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(218, 19);
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
            this.txtCodigoBuscado.Location = new System.Drawing.Point(51, 29);
            this.txtCodigoBuscado.Name = "txtCodigoBuscado";
            this.txtCodigoBuscado.Size = new System.Drawing.Size(161, 20);
            this.txtCodigoBuscado.TabIndex = 1;
            this.txtCodigoBuscado.TextChanged += new System.EventHandler(this.txtCodigoBuscado_TextChanged);
            this.txtCodigoBuscado.Enter += new System.EventHandler(this.txtCodigoBuscado_Enter);
            this.txtCodigoBuscado.Leave += new System.EventHandler(this.txtCodigoBuscado_Leave);
            // 
            // lblManifiestoBuscado
            // 
            this.lblManifiestoBuscado.AutoSize = true;
            this.lblManifiestoBuscado.Location = new System.Drawing.Point(6, 33);
            this.lblManifiestoBuscado.Name = "lblManifiestoBuscado";
            this.lblManifiestoBuscado.Size = new System.Drawing.Size(43, 13);
            this.lblManifiestoBuscado.TabIndex = 0;
            this.lblManifiestoBuscado.Text = "Código:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(662, 50);
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
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(554, 292);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbDatosManifiesto
            // 
            this.gbDatosManifiesto.Controls.Add(this.txtManifiestoAnteriorENA);
            this.gbDatosManifiesto.Controls.Add(this.lblManifiestoAnteriorENA);
            this.gbDatosManifiesto.Controls.Add(this.txtFecha);
            this.gbDatosManifiesto.Controls.Add(this.lblFecha);
            this.gbDatosManifiesto.Controls.Add(this.pnlENA);
            this.gbDatosManifiesto.Controls.Add(this.lblMarchamo);
            this.gbDatosManifiesto.Controls.Add(this.txtCodigoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.lblCodigoManifiesto);
            this.gbDatosManifiesto.Controls.Add(this.txtMarchamo);
            this.gbDatosManifiesto.Enabled = false;
            this.gbDatosManifiesto.Location = new System.Drawing.Point(332, 56);
            this.gbDatosManifiesto.Name = "gbDatosManifiesto";
            this.gbDatosManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbDatosManifiesto.Size = new System.Drawing.Size(318, 214);
            this.gbDatosManifiesto.TabIndex = 2;
            this.gbDatosManifiesto.TabStop = false;
            this.gbDatosManifiesto.Text = "Datos del Manifiesto";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(143, 19);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(169, 20);
            this.txtFecha.TabIndex = 1;
            this.txtFecha.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(97, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
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
            this.pnlENA.Location = new System.Drawing.Point(0, 71);
            this.pnlENA.Name = "pnlENA";
            this.pnlENA.Size = new System.Drawing.Size(318, 72);
            this.pnlENA.TabIndex = 4;
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
            this.txtMarchamoAdicionalENA.Size = new System.Drawing.Size(169, 20);
            this.txtMarchamoAdicionalENA.TabIndex = 1;
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
            this.txtMarchamoENAB.Size = new System.Drawing.Size(169, 20);
            this.txtMarchamoENAB.TabIndex = 5;
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
            this.txtMarchamoENAA.Size = new System.Drawing.Size(169, 20);
            this.txtMarchamoENAA.TabIndex = 3;
            // 
            // lblMarchamo
            // 
            this.lblMarchamo.AutoSize = true;
            this.lblMarchamo.Location = new System.Drawing.Point(25, 49);
            this.lblMarchamo.Name = "lblMarchamo";
            this.lblMarchamo.Size = new System.Drawing.Size(112, 13);
            this.lblMarchamo.TabIndex = 2;
            this.lblMarchamo.Text = "Marchamo BNA/ENA:";
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.BackColor = System.Drawing.Color.PeachPuff;
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(143, 149);
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(169, 20);
            this.txtCodigoManifiesto.TabIndex = 6;
            // 
            // lblCodigoManifiesto
            // 
            this.lblCodigoManifiesto.AutoSize = true;
            this.lblCodigoManifiesto.Location = new System.Drawing.Point(27, 153);
            this.lblCodigoManifiesto.Name = "lblCodigoManifiesto";
            this.lblCodigoManifiesto.Size = new System.Drawing.Size(110, 13);
            this.lblCodigoManifiesto.TabIndex = 5;
            this.lblCodigoManifiesto.Text = "Manifiesto BNA/ENA:";
            // 
            // txtMarchamo
            // 
            this.txtMarchamo.BackColor = System.Drawing.Color.PeachPuff;
            this.txtMarchamo.Location = new System.Drawing.Point(143, 45);
            this.txtMarchamo.Name = "txtMarchamo";
            this.txtMarchamo.Size = new System.Drawing.Size(169, 20);
            this.txtMarchamo.TabIndex = 3;
            // 
            // txtManifiestoAnteriorENA
            // 
            this.txtManifiestoAnteriorENA.BackColor = System.Drawing.Color.LightBlue;
            this.txtManifiestoAnteriorENA.Location = new System.Drawing.Point(143, 178);
            this.txtManifiestoAnteriorENA.Name = "txtManifiestoAnteriorENA";
            this.txtManifiestoAnteriorENA.Size = new System.Drawing.Size(169, 20);
            this.txtManifiestoAnteriorENA.TabIndex = 8;
            // 
            // lblManifiestoAnteriorENA
            // 
            this.lblManifiestoAnteriorENA.AutoSize = true;
            this.lblManifiestoAnteriorENA.Location = new System.Drawing.Point(0, 181);
            this.lblManifiestoAnteriorENA.Name = "lblManifiestoAnteriorENA";
            this.lblManifiestoAnteriorENA.Size = new System.Drawing.Size(148, 13);
            this.lblManifiestoAnteriorENA.TabIndex = 7;
            this.lblManifiestoAnteriorENA.Text = "Manifiesto BNA/ENA anterior:";
            // 
            // frmSeleccionManifiestoDescargaATMFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 344);
            this.ControlBox = false;
            this.Controls.Add(this.gbDatosManifiesto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSeleccionManifiestoDescargaATMFull";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de Manifiesto Full";
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatosManifiesto.ResumeLayout(false);
            this.gbDatosManifiesto.PerformLayout();
            this.pnlENA.ResumeLayout(false);
            this.pnlENA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menifiesto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCodigoBuscado;
        private System.Windows.Forms.Label lblManifiestoBuscado;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbDatosManifiesto;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlENA;
        private System.Windows.Forms.Label lblMarchamoENAB;
        private System.Windows.Forms.TextBox txtMarchamoAdicionalENA;
        private System.Windows.Forms.Label lblMarchamoAdicionalENA;
        private System.Windows.Forms.TextBox txtMarchamoENAB;
        private System.Windows.Forms.Label lblMarchamoENAA;
        private System.Windows.Forms.TextBox txtMarchamoENAA;
        private System.Windows.Forms.Label lblMarchamo;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblCodigoManifiesto;
        private System.Windows.Forms.TextBox txtMarchamo;
        private System.Windows.Forms.TextBox txtManifiestoAnteriorENA;
        private System.Windows.Forms.Label lblManifiestoAnteriorENA;
    }
}