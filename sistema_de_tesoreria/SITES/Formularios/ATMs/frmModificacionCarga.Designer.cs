﻿namespace GUILayer
{
    partial class frmModificacionCarga
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificacionCarga));
            this.gbDatosCarga = new System.Windows.Forms.GroupBox();
            this.dgvMontosCarga = new System.Windows.Forms.DataGridView();
            this.DenominacionCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadAsignadaCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarchamoCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbDatosCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosCarga)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosCarga
            // 
            this.gbDatosCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosCarga.Controls.Add(this.dgvMontosCarga);
            this.gbDatosCarga.Location = new System.Drawing.Point(12, 115);
            this.gbDatosCarga.Name = "gbDatosCarga";
            this.gbDatosCarga.Size = new System.Drawing.Size(618, 333);
            this.gbDatosCarga.TabIndex = 1;
            this.gbDatosCarga.TabStop = false;
            this.gbDatosCarga.Text = "Datos de la Carga";
            // 
            // dgvMontosCarga
            // 
            this.dgvMontosCarga.AllowUserToAddRows = false;
            this.dgvMontosCarga.AllowUserToDeleteRows = false;
            this.dgvMontosCarga.AllowUserToOrderColumns = true;
            this.dgvMontosCarga.AllowUserToResizeColumns = false;
            this.dgvMontosCarga.AllowUserToResizeRows = false;
            this.dgvMontosCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMontosCarga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontosCarga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMontosCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMontosCarga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DenominacionCartuchoCarga,
            this.MontoAsignadoCartuchoCarga,
            this.CantidadAsignadaCartuchoCarga,
            this.MontoCartuchoCarga,
            this.CantidadCartuchoCarga,
            this.MarchamoCartuchoCarga,
            this.Anular});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMontosCarga.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMontosCarga.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMontosCarga.EnableHeadersVisualStyles = false;
            this.dgvMontosCarga.Location = new System.Drawing.Point(6, 19);
            this.dgvMontosCarga.Name = "dgvMontosCarga";
            this.dgvMontosCarga.RowHeadersVisible = false;
            this.dgvMontosCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMontosCarga.Size = new System.Drawing.Size(606, 308);
            this.dgvMontosCarga.StandardTab = true;
            this.dgvMontosCarga.TabIndex = 0;
            this.dgvMontosCarga.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMontosCarga_CellContentClick);
            this.dgvMontosCarga.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvMontosCarga_CellParsing);
            this.dgvMontosCarga.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMontosCarga_CellValueChanged);
            // 
            // DenominacionCartuchoCarga
            // 
            this.DenominacionCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DenominacionCartuchoCarga.DataPropertyName = "Denominacion";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Format = "N2";
            this.DenominacionCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle2;
            this.DenominacionCartuchoCarga.HeaderText = "Denominación";
            this.DenominacionCartuchoCarga.Name = "DenominacionCartuchoCarga";
            this.DenominacionCartuchoCarga.ReadOnly = true;
            this.DenominacionCartuchoCarga.Width = 99;
            // 
            // MontoAsignadoCartuchoCarga
            // 
            this.MontoAsignadoCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoAsignadoCartuchoCarga.DataPropertyName = "Monto_asignado";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Format = "N2";
            this.MontoAsignadoCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoAsignadoCartuchoCarga.HeaderText = "M. Asignado";
            this.MontoAsignadoCartuchoCarga.Name = "MontoAsignadoCartuchoCarga";
            this.MontoAsignadoCartuchoCarga.ReadOnly = true;
            this.MontoAsignadoCartuchoCarga.Visible = false;
            // 
            // CantidadAsignadaCartuchoCarga
            // 
            this.CantidadAsignadaCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadAsignadaCartuchoCarga.DataPropertyName = "Cantidad_asignada";
            dataGridViewCellStyle4.Format = "N0";
            this.CantidadAsignadaCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle4;
            this.CantidadAsignadaCartuchoCarga.HeaderText = "N. Formulas";
            this.CantidadAsignadaCartuchoCarga.Name = "CantidadAsignadaCartuchoCarga";
            this.CantidadAsignadaCartuchoCarga.ReadOnly = true;
            this.CantidadAsignadaCartuchoCarga.Visible = false;
            // 
            // MontoCartuchoCarga
            // 
            this.MontoCartuchoCarga.DataPropertyName = "Monto_carga";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Format = "N2";
            this.MontoCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle5;
            this.MontoCartuchoCarga.HeaderText = "Monto";
            this.MontoCartuchoCarga.Name = "MontoCartuchoCarga";
            this.MontoCartuchoCarga.ReadOnly = true;
            this.MontoCartuchoCarga.Visible = false;
            // 
            // CantidadCartuchoCarga
            // 
            this.CantidadCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadCartuchoCarga.DataPropertyName = "Cantidad_carga";
            dataGridViewCellStyle6.Format = "N0";
            this.CantidadCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle6;
            this.CantidadCartuchoCarga.HeaderText = "Formulas";
            this.CantidadCartuchoCarga.Name = "CantidadCartuchoCarga";
            this.CantidadCartuchoCarga.ReadOnly = true;
            this.CantidadCartuchoCarga.Visible = false;
            // 
            // MarchamoCartuchoCarga
            // 
            this.MarchamoCartuchoCarga.DataPropertyName = "Marchamo";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MarchamoCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle7;
            this.MarchamoCartuchoCarga.HeaderText = "Marchamo";
            this.MarchamoCartuchoCarga.Name = "MarchamoCartuchoCarga";
            this.MarchamoCartuchoCarga.ReadOnly = true;
            this.MarchamoCartuchoCarga.Visible = false;
            // 
            // Anular
            // 
            this.Anular.DataPropertyName = "Anulado";
            this.Anular.HeaderText = "Anular";
            this.Anular.Name = "Anular";
            this.Anular.ReadOnly = true;
            this.Anular.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Anular.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-1, -1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(655, 60);
            this.pnlFondo.TabIndex = 0;
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
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(534, 454);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(262, 78);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(63, 25);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "label1";
            this.lblNombre.Visible = false;
            // 
            // frmModificacionCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(642, 506);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosCarga);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModificacionCarga";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Carga";
            this.gbDatosCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosCarga)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosCarga;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvMontosCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenominacionCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadAsignadaCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarchamoCartuchoCarga;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Anular;
        private System.Windows.Forms.Label lblNombre;
    }
}