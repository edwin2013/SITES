﻿namespace GUILayer.Formularios.Facturacion
{
    partial class frmAdministracionInconsistenciaFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionInconsistenciaFacturacion));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbInconsistencias = new System.Windows.Forms.GroupBox();
            this.dgvInconsistencias = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbInconsistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInconsistencias)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(469, 60);
            this.pnlFondo.TabIndex = 6;
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
            // gbInconsistencias
            // 
            this.gbInconsistencias.Controls.Add(this.dgvInconsistencias);
            this.gbInconsistencias.Location = new System.Drawing.Point(15, 67);
            this.gbInconsistencias.Name = "gbInconsistencias";
            this.gbInconsistencias.Size = new System.Drawing.Size(422, 308);
            this.gbInconsistencias.TabIndex = 7;
            this.gbInconsistencias.TabStop = false;
            this.gbInconsistencias.Text = "Lista de Inconsistencias";
            // 
            // dgvInconsistencias
            // 
            this.dgvInconsistencias.AllowUserToAddRows = false;
            this.dgvInconsistencias.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvInconsistencias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInconsistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInconsistencias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInconsistencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInconsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInconsistencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Identificador});
            this.dgvInconsistencias.EnableHeadersVisualStyles = false;
            this.dgvInconsistencias.Location = new System.Drawing.Point(6, 19);
            this.dgvInconsistencias.MultiSelect = false;
            this.dgvInconsistencias.Name = "dgvInconsistencias";
            this.dgvInconsistencias.ReadOnly = true;
            this.dgvInconsistencias.RowHeadersVisible = false;
            this.dgvInconsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInconsistencias.Size = new System.Drawing.Size(410, 283);
            this.dgvInconsistencias.StandardTab = true;
            this.dgvInconsistencias.TabIndex = 0;
            this.dgvInconsistencias.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvInconsistenciaFacturacions_RowsAdded);
            this.dgvInconsistencias.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvInconsistenciaFacturacions_RowsRemoved);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // Identificador
            // 
            this.Identificador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Identificador.DataPropertyName = "Identificador";
            this.Identificador.HeaderText = "Identificador";
            this.Identificador.Name = "Identificador";
            this.Identificador.ReadOnly = true;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(149, 381);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNueva.FlatAppearance.BorderSize = 2;
            this.btnNueva.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNueva.Location = new System.Drawing.Point(53, 381);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(90, 40);
            this.btnNueva.TabIndex = 8;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNueva.UseVisualStyleBackColor = false;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(341, 381);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(245, 381);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmAdministracionInconsistenciaFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 429);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbInconsistencias);
            this.Controls.Add(this.btnEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionInconsistenciaFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Inconsistencias";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbInconsistencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInconsistencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbInconsistencias;
        private System.Windows.Forms.DataGridView dgvInconsistencias;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
    }
}