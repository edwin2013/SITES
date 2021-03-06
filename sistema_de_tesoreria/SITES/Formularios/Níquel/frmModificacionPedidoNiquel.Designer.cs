﻿namespace GUILayer.Formularios.Facturacion
{
    partial class frmModificacionPedidoNiquel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificacionPedidoNiquel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.CantidadCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarchamoCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MontoCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadAsignadaCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatosCarga = new System.Windows.Forms.GroupBox();
            this.dgvMontosCarga = new System.Windows.Forms.DataGridView();
            this.DenominacionCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAsignadoCartuchoCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbDatosCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(3, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(655, 60);
            this.pnlFondo.TabIndex = 11;
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
            // CantidadCartuchoCarga
            // 
            this.CantidadCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CantidadCartuchoCarga.DataPropertyName = "Cantidad_carga";
            dataGridViewCellStyle1.Format = "N0";
            this.CantidadCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle1;
            this.CantidadCartuchoCarga.HeaderText = "Formulas";
            this.CantidadCartuchoCarga.Name = "CantidadCartuchoCarga";
            this.CantidadCartuchoCarga.ReadOnly = true;
            this.CantidadCartuchoCarga.Visible = false;
            // 
            // MarchamoCartuchoCarga
            // 
            this.MarchamoCartuchoCarga.DataPropertyName = "Marchamo";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MarchamoCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle2;
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
            // MontoCartuchoCarga
            // 
            this.MontoCartuchoCarga.DataPropertyName = "Monto_carga";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Format = "N2";
            this.MontoCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoCartuchoCarga.HeaderText = "Monto";
            this.MontoCartuchoCarga.Name = "MontoCartuchoCarga";
            this.MontoCartuchoCarga.ReadOnly = true;
            this.MontoCartuchoCarga.Visible = false;
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
            // gbDatosCarga
            // 
            this.gbDatosCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosCarga.Controls.Add(this.dgvMontosCarga);
            this.gbDatosCarga.Location = new System.Drawing.Point(12, 106);
            this.gbDatosCarga.Name = "gbDatosCarga";
            this.gbDatosCarga.Size = new System.Drawing.Size(618, 330);
            this.gbDatosCarga.TabIndex = 12;
            this.gbDatosCarga.TabStop = false;
            this.gbDatosCarga.Text = "Datos del Pedido";
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMontosCarga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
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
            this.dgvMontosCarga.Size = new System.Drawing.Size(606, 305);
            this.dgvMontosCarga.StandardTab = true;
            this.dgvMontosCarga.TabIndex = 1;
            this.dgvMontosCarga.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvMontosCarga_CellParsing);
            this.dgvMontosCarga.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMontosCarga_CellValueChanged);
            // 
            // DenominacionCartuchoCarga
            // 
            this.DenominacionCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DenominacionCartuchoCarga.DataPropertyName = "Denominacion";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.Format = "N2";
            this.DenominacionCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle6;
            this.DenominacionCartuchoCarga.HeaderText = "Denominación";
            this.DenominacionCartuchoCarga.Name = "DenominacionCartuchoCarga";
            this.DenominacionCartuchoCarga.ReadOnly = true;
            this.DenominacionCartuchoCarga.Width = 99;
            // 
            // MontoAsignadoCartuchoCarga
            // 
            this.MontoAsignadoCartuchoCarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MontoAsignadoCartuchoCarga.DataPropertyName = "Monto_asignado";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.Format = "N2";
            this.MontoAsignadoCartuchoCarga.DefaultCellStyle = dataGridViewCellStyle7;
            this.MontoAsignadoCartuchoCarga.HeaderText = "M. Asignado";
            this.MontoAsignadoCartuchoCarga.Name = "MontoAsignadoCartuchoCarga";
            this.MontoAsignadoCartuchoCarga.ReadOnly = true;
            this.MontoAsignadoCartuchoCarga.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.FlatAppearance.BorderSize = 2;
            this.btnAgregar.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregar.Location = new System.Drawing.Point(428, 442);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(95, 40);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.Text = "Agregar Monto";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(289, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(63, 25);
            this.lblNombre.TabIndex = 14;
            this.lblNombre.Text = "label1";
            this.lblNombre.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(534, 442);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmModificacionPedidoNiquel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 490);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatosCarga);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmModificacionPedidoNiquel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación Pedido Níquel";
            this.Click += new System.EventHandler(this.btnAgregar_Click);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbDatosCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMontosCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarchamoCartuchoCarga;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Anular;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadAsignadaCartuchoCarga;
        private System.Windows.Forms.GroupBox gbDatosCarga;
        private System.Windows.Forms.DataGridView dgvMontosCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenominacionCartuchoCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAsignadoCartuchoCarga;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSalir;

    }
}