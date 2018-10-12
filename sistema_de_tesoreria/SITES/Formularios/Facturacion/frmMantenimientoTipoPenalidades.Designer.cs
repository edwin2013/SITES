namespace GUILayer.Formularios.Facturacion
{
    partial class frmMantenimientoTipoPenalidades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoTipoPenalidades));
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.dgvNiveles = new System.Windows.Forms.DataGridView();
            this.btnQuitarNivel = new System.Windows.Forms.Button();
            this.btnAgregarNivel = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.PosicionX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicionY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesplazamientoVertical = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesplazamientoHorizontal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNiveles)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(190, 82);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(352, 20);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(-1, -1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(454, 60);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(1, -1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(656, 58);
            this.pnlFondo.TabIndex = 13;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.dgvNiveles);
            this.gbDatos.Controls.Add(this.btnQuitarNivel);
            this.gbDatos.Controls.Add(this.btnAgregarNivel);
            this.gbDatos.Location = new System.Drawing.Point(12, 130);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(631, 317);
            this.gbDatos.TabIndex = 14;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Nivel de Servicio";
            // 
            // dgvNiveles
            // 
            this.dgvNiveles.AllowUserToAddRows = false;
            this.dgvNiveles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvNiveles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNiveles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNiveles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNiveles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvNiveles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNiveles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PosicionX,
            this.PosicionY,
            this.DesplazamientoVertical,
            this.DesplazamientoHorizontal});
            this.dgvNiveles.EnableHeadersVisualStyles = false;
            this.dgvNiveles.Location = new System.Drawing.Point(106, 30);
            this.dgvNiveles.MultiSelect = false;
            this.dgvNiveles.Name = "dgvNiveles";
            this.dgvNiveles.RowHeadersVisible = false;
            this.dgvNiveles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNiveles.Size = new System.Drawing.Size(505, 266);
            this.dgvNiveles.StandardTab = true;
            this.dgvNiveles.TabIndex = 17;
            this.dgvNiveles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosiciones_CellValueChanged);
            this.dgvNiveles.SelectionChanged += new System.EventHandler(this.dgvPosiciones_SelectionChanged);
            // 
            // btnQuitarNivel
            // 
            this.btnQuitarNivel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQuitarNivel.Enabled = false;
            this.btnQuitarNivel.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnQuitarNivel.Location = new System.Drawing.Point(10, 162);
            this.btnQuitarNivel.Name = "btnQuitarNivel";
            this.btnQuitarNivel.Size = new System.Drawing.Size(90, 40);
            this.btnQuitarNivel.TabIndex = 16;
            this.btnQuitarNivel.Text = "Quitar";
            this.btnQuitarNivel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarNivel.UseVisualStyleBackColor = false;
            this.btnQuitarNivel.Click += new System.EventHandler(this.btnQuitarPosicion_Click);
            // 
            // btnAgregarNivel
            // 
            this.btnAgregarNivel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregarNivel.Enabled = false;
            this.btnAgregarNivel.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarNivel.Location = new System.Drawing.Point(10, 116);
            this.btnAgregarNivel.Name = "btnAgregarNivel";
            this.btnAgregarNivel.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarNivel.TabIndex = 15;
            this.btnAgregarNivel.Text = "Agregar";
            this.btnAgregarNivel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarNivel.UseVisualStyleBackColor = false;
            this.btnAgregarNivel.Click += new System.EventHandler(this.btnAgregarPosicion_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(100, 82);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(457, 453);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(553, 453);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // PosicionX
            // 
            this.PosicionX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PosicionX.DataPropertyName = "CantidadValorVisita";
            dataGridViewCellStyle2.Format = "N2";
            this.PosicionX.DefaultCellStyle = dataGridViewCellStyle2;
            this.PosicionX.HeaderText = "Cantidad Valor Visita";
            this.PosicionX.Name = "PosicionX";
            this.PosicionX.Width = 95;
            // 
            // PosicionY
            // 
            this.PosicionY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PosicionY.DataPropertyName = "PorcentajeMinimo";
            dataGridViewCellStyle3.Format = "N2";
            this.PosicionY.DefaultCellStyle = dataGridViewCellStyle3;
            this.PosicionY.HeaderText = "Porcentaje Mínimo";
            this.PosicionY.Name = "PosicionY";
            this.PosicionY.Width = 110;
            // 
            // DesplazamientoVertical
            // 
            this.DesplazamientoVertical.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DesplazamientoVertical.DataPropertyName = "PorcentajeMaximo";
            dataGridViewCellStyle4.Format = "N2";
            this.DesplazamientoVertical.DefaultCellStyle = dataGridViewCellStyle4;
            this.DesplazamientoVertical.HeaderText = "Porcentaje Máximo";
            this.DesplazamientoVertical.Name = "DesplazamientoVertical";
            this.DesplazamientoVertical.Width = 111;
            // 
            // DesplazamientoHorizontal
            // 
            this.DesplazamientoHorizontal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DesplazamientoHorizontal.DataPropertyName = "PorcentajeValorTarifa";
            dataGridViewCellStyle5.Format = "N2";
            this.DesplazamientoHorizontal.DefaultCellStyle = dataGridViewCellStyle5;
            this.DesplazamientoHorizontal.HeaderText = "Porcentaje Valor Tarifa";
            this.DesplazamientoHorizontal.Name = "DesplazamientoHorizontal";
            this.DesplazamientoHorizontal.Width = 103;
            // 
            // frmMantenimientoTipoPenalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 502);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.txtDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMantenimientoTipoPenalidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Tipos de Penalidades";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNiveles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnQuitarNivel;
        private System.Windows.Forms.Button btnAgregarNivel;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvNiveles;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionX;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesplazamientoVertical;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesplazamientoHorizontal;
    }
}