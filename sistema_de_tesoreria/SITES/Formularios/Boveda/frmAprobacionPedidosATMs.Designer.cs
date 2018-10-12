namespace GUILayer.Formularios.Boveda
{
    partial class frmAprobacionPedidosATMs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacionPedidosATMs));
            this.btnAprobar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.gbRecapPreliminar = new System.Windows.Forms.GroupBox();
            this.dgvPedidoColones = new System.Windows.Forms.DataGridView();
            this.gbRecapAdicional = new System.Windows.Forms.GroupBox();
            this.dgvPedidoDolares = new System.Windows.Forms.DataGridView();
            this.clmIDRecapFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaRecapAdicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.btnValidarMontos = new System.Windows.Forms.Button();
            this.clmIDPreliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCoordinador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMontoDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbRecapPreliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoColones)).BeginInit();
            this.gbRecapAdicional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoDolares)).BeginInit();
            this.tlpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAprobar
            // 
            this.btnAprobar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprobar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAprobar.FlatAppearance.BorderSize = 2;
            this.btnAprobar.Image = global::GUILayer.Properties.Resources.aceptar1;
            this.btnAprobar.Location = new System.Drawing.Point(539, 697);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(103, 40);
            this.btnAprobar.TabIndex = 28;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAprobar.UseVisualStyleBackColor = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(958, 57);
            this.pnlFondo.TabIndex = 22;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 55);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(850, 697);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRechazar.BackColor = System.Drawing.Color.White;
            this.btnRechazar.Image = global::GUILayer.Properties.Resources.terminar;
            this.btnRechazar.Location = new System.Drawing.Point(648, 697);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(95, 40);
            this.btnRechazar.TabIndex = 27;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRechazar.UseVisualStyleBackColor = false;
            // 
            // gbRecapPreliminar
            // 
            this.gbRecapPreliminar.Controls.Add(this.dgvPedidoColones);
            this.gbRecapPreliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRecapPreliminar.Location = new System.Drawing.Point(0, 0);
            this.gbRecapPreliminar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbRecapPreliminar.Name = "gbRecapPreliminar";
            this.gbRecapPreliminar.Size = new System.Drawing.Size(468, 625);
            this.gbRecapPreliminar.TabIndex = 0;
            this.gbRecapPreliminar.TabStop = false;
            this.gbRecapPreliminar.Text = "Recap Preliminar";
            // 
            // dgvPedidoColones
            // 
            this.dgvPedidoColones.AllowUserToAddRows = false;
            this.dgvPedidoColones.AllowUserToDeleteRows = false;
            this.dgvPedidoColones.AllowUserToOrderColumns = true;
            this.dgvPedidoColones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidoColones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPedidoColones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidoColones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedidoColones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoColones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIDPreliminar,
            this.clmFecha,
            this.clmCoordinador,
            this.clmMontoColones,
            this.clmMontoDolares,
            this.clmEstado});
            this.dgvPedidoColones.EnableHeadersVisualStyles = false;
            this.dgvPedidoColones.GridColor = System.Drawing.Color.Black;
            this.dgvPedidoColones.Location = new System.Drawing.Point(12, 19);
            this.dgvPedidoColones.MultiSelect = false;
            this.dgvPedidoColones.Name = "dgvPedidoColones";
            this.dgvPedidoColones.ReadOnly = true;
            this.dgvPedidoColones.RowHeadersVisible = false;
            this.dgvPedidoColones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoColones.Size = new System.Drawing.Size(450, 600);
            this.dgvPedidoColones.StandardTab = true;
            this.dgvPedidoColones.TabIndex = 0;
            this.dgvPedidoColones.Click += new System.EventHandler(this.dgvCargas_SelectionChanged);
            // 
            // gbRecapAdicional
            // 
            this.gbRecapAdicional.Controls.Add(this.dgvPedidoDolares);
            this.gbRecapAdicional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRecapAdicional.Location = new System.Drawing.Point(468, 0);
            this.gbRecapAdicional.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbRecapAdicional.Name = "gbRecapAdicional";
            this.gbRecapAdicional.Size = new System.Drawing.Size(469, 625);
            this.gbRecapAdicional.TabIndex = 3;
            this.gbRecapAdicional.TabStop = false;
            this.gbRecapAdicional.Text = "Recap Adicional";
            // 
            // dgvPedidoDolares
            // 
            this.dgvPedidoDolares.AllowUserToAddRows = false;
            this.dgvPedidoDolares.AllowUserToDeleteRows = false;
            this.dgvPedidoDolares.AllowUserToOrderColumns = true;
            this.dgvPedidoDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidoDolares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPedidoDolares.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidoDolares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPedidoDolares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoDolares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIDRecapFinal,
            this.clmFechaRecapAdicional});
            this.dgvPedidoDolares.EnableHeadersVisualStyles = false;
            this.dgvPedidoDolares.GridColor = System.Drawing.Color.Black;
            this.dgvPedidoDolares.Location = new System.Drawing.Point(6, 19);
            this.dgvPedidoDolares.Name = "dgvPedidoDolares";
            this.dgvPedidoDolares.ReadOnly = true;
            this.dgvPedidoDolares.RowHeadersVisible = false;
            this.dgvPedidoDolares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPedidoDolares.Size = new System.Drawing.Size(457, 600);
            this.dgvPedidoDolares.StandardTab = true;
            this.dgvPedidoDolares.TabIndex = 0;
            // 
            // clmIDRecapFinal
            // 
            this.clmIDRecapFinal.DataPropertyName = "ID";
            this.clmIDRecapFinal.HeaderText = "ID";
            this.clmIDRecapFinal.Name = "clmIDRecapFinal";
            this.clmIDRecapFinal.ReadOnly = true;
            this.clmIDRecapFinal.Width = 42;
            // 
            // clmFechaRecapAdicional
            // 
            this.clmFechaRecapAdicional.DataPropertyName = "Fecha_Ingreso";
            this.clmFechaRecapAdicional.HeaderText = "Fecha";
            this.clmFechaRecapAdicional.Name = "clmFechaRecapAdicional";
            this.clmFechaRecapAdicional.ReadOnly = true;
            this.clmFechaRecapAdicional.Width = 61;
            // 
            // tlpDatos
            // 
            this.tlpDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDatos.ColumnCount = 2;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.Controls.Add(this.gbRecapAdicional, 1, 0);
            this.tlpDatos.Controls.Add(this.gbRecapPreliminar, 0, 0);
            this.tlpDatos.Location = new System.Drawing.Point(9, 63);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 1;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDatos.Size = new System.Drawing.Size(937, 628);
            this.tlpDatos.TabIndex = 25;
            // 
            // btnValidarMontos
            // 
            this.btnValidarMontos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidarMontos.BackColor = System.Drawing.Color.White;
            this.btnValidarMontos.Image = global::GUILayer.Properties.Resources.revisionportavalor;
            this.btnValidarMontos.Location = new System.Drawing.Point(749, 697);
            this.btnValidarMontos.Name = "btnValidarMontos";
            this.btnValidarMontos.Size = new System.Drawing.Size(95, 40);
            this.btnValidarMontos.TabIndex = 23;
            this.btnValidarMontos.Text = "Validar Montos";
            this.btnValidarMontos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnValidarMontos.UseVisualStyleBackColor = false;
            this.btnValidarMontos.Click += new System.EventHandler(this.btnValidarMontos_Click);
            // 
            // clmIDPreliminar
            // 
            this.clmIDPreliminar.DataPropertyName = "ID";
            this.clmIDPreliminar.HeaderText = "ID";
            this.clmIDPreliminar.Name = "clmIDPreliminar";
            this.clmIDPreliminar.ReadOnly = true;
            this.clmIDPreliminar.Width = 42;
            // 
            // clmFecha
            // 
            this.clmFecha.DataPropertyName = "Fecha_Ingreso";
            this.clmFecha.HeaderText = "Fecha";
            this.clmFecha.Name = "clmFecha";
            this.clmFecha.ReadOnly = true;
            this.clmFecha.Width = 61;
            // 
            // clmCoordinador
            // 
            this.clmCoordinador.HeaderText = "Coordinador";
            this.clmCoordinador.Name = "clmCoordinador";
            this.clmCoordinador.ReadOnly = true;
            this.clmCoordinador.Width = 88;
            // 
            // clmMontoColones
            // 
            this.clmMontoColones.HeaderText = "Monto Colones";
            this.clmMontoColones.Name = "clmMontoColones";
            this.clmMontoColones.ReadOnly = true;
            this.clmMontoColones.Width = 102;
            // 
            // clmMontoDolares
            // 
            this.clmMontoDolares.HeaderText = "Monto Dólares";
            this.clmMontoDolares.Name = "clmMontoDolares";
            this.clmMontoDolares.ReadOnly = true;
            // 
            // clmEstado
            // 
            this.clmEstado.DataPropertyName = "Estado";
            this.clmEstado.HeaderText = "Estado";
            this.clmEstado.Name = "clmEstado";
            this.clmEstado.ReadOnly = true;
            this.clmEstado.Width = 64;
            // 
            // frmAprobacionPedidosATMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 749);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnValidarMontos);
            this.Controls.Add(this.tlpDatos);
            this.Controls.Add(this.btnRechazar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAprobacionPedidosATMs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aprobación de Pedidos ATMs";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbRecapPreliminar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoColones)).EndInit();
            this.gbRecapAdicional.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoDolares)).EndInit();
            this.tlpDatos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.GroupBox gbRecapPreliminar;
        private System.Windows.Forms.DataGridView dgvPedidoColones;
        private System.Windows.Forms.GroupBox gbRecapAdicional;
        private System.Windows.Forms.DataGridView dgvPedidoDolares;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.Button btnValidarMontos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDRecapFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaRecapAdicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDPreliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCoordinador;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMontoDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEstado;
    }
}