namespace GUILayer.Formularios.Blindados
{
    partial class frmCargaTripulacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaTripulacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbDatosCarga = new System.Windows.Forms.GroupBox();
            this.dgvTripulaciones = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Chofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Custodio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatosCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripulaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-6, 6);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(491, 60);
            this.pnlFondo.TabIndex = 6;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbDatosCarga
            // 
            this.gbDatosCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosCarga.Controls.Add(this.dgvTripulaciones);
            this.gbDatosCarga.Location = new System.Drawing.Point(7, 72);
            this.gbDatosCarga.Name = "gbDatosCarga";
            this.gbDatosCarga.Size = new System.Drawing.Size(454, 189);
            this.gbDatosCarga.TabIndex = 7;
            this.gbDatosCarga.TabStop = false;
            this.gbDatosCarga.Text = "Datos de laTripulación";
            // 
            // dgvTripulaciones
            // 
            this.dgvTripulaciones.AllowUserToAddRows = false;
            this.dgvTripulaciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvTripulaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTripulaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTripulaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTripulaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTripulaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTripulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTripulaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chofer,
            this.Custodio,
            this.PortaValor,
            this.Vehiculo});
            this.dgvTripulaciones.EnableHeadersVisualStyles = false;
            this.dgvTripulaciones.Location = new System.Drawing.Point(6, 31);
            this.dgvTripulaciones.MultiSelect = false;
            this.dgvTripulaciones.Name = "dgvTripulaciones";
            this.dgvTripulaciones.ReadOnly = true;
            this.dgvTripulaciones.RowHeadersVisible = false;
            this.dgvTripulaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTripulaciones.Size = new System.Drawing.Size(442, 152);
            this.dgvTripulaciones.StandardTab = true;
            this.dgvTripulaciones.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(365, 267);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Chofer
            // 
            this.Chofer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Chofer.DataPropertyName = "Chofer";
            this.Chofer.HeaderText = "Chofer";
            this.Chofer.MinimumWidth = 120;
            this.Chofer.Name = "Chofer";
            this.Chofer.ReadOnly = true;
            this.Chofer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chofer.Width = 120;
            // 
            // Custodio
            // 
            this.Custodio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Custodio.DataPropertyName = "Custodio";
            this.Custodio.HeaderText = "Custodio";
            this.Custodio.Name = "Custodio";
            this.Custodio.ReadOnly = true;
            this.Custodio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Custodio.Width = 72;
            // 
            // PortaValor
            // 
            this.PortaValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PortaValor.DataPropertyName = "Portavalor";
            this.PortaValor.HeaderText = "PortaValor";
            this.PortaValor.Name = "PortaValor";
            this.PortaValor.ReadOnly = true;
            this.PortaValor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PortaValor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PortaValor.Width = 61;
            // 
            // Vehiculo
            // 
            this.Vehiculo.DataPropertyName = "Vehiculo";
            this.Vehiculo.HeaderText = "Vehículo";
            this.Vehiculo.Name = "Vehiculo";
            this.Vehiculo.ReadOnly = true;
            this.Vehiculo.Width = 74;
            // 
            // frmCargaTripulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 312);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosCarga);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargaTripulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tripulación Asignada";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatosCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripulaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbDatosCarga;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvTripulaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Custodio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehiculo;
    }
}