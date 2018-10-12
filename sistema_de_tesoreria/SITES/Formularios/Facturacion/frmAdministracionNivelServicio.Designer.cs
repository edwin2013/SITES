namespace GUILayer.Formularios.Facturacion
{
    partial class frmAdministracionNivelServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionNivelServicio));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbInconsistencias = new System.Windows.Forms.GroupBox();
            this.dgvNivelServicio = new System.Windows.Forms.DataGridView();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.gbRangos = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPorcentajeEfectividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPorcentajeCumplimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbInconsistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNivelServicio)).BeginInit();
            this.gbRangos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-11, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(586, 60);
            this.pnlFondo.TabIndex = 18;
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
            this.gbInconsistencias.Controls.Add(this.dgvNivelServicio);
            this.gbInconsistencias.Location = new System.Drawing.Point(12, 164);
            this.gbInconsistencias.Name = "gbInconsistencias";
            this.gbInconsistencias.Size = new System.Drawing.Size(563, 319);
            this.gbInconsistencias.TabIndex = 19;
            this.gbInconsistencias.TabStop = false;
            this.gbInconsistencias.Text = "Lista de Niveles de Servicio";
            // 
            // dgvNivelServicio
            // 
            this.dgvNivelServicio.AllowUserToAddRows = false;
            this.dgvNivelServicio.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvNivelServicio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNivelServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNivelServicio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNivelServicio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvNivelServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNivelServicio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Identificador,
            this.clmPorcentajeEfectividad,
            this.clmPorcentajeCumplimiento,
            this.clmFechaInicio,
            this.clmFechaFin});
            this.dgvNivelServicio.EnableHeadersVisualStyles = false;
            this.dgvNivelServicio.Location = new System.Drawing.Point(6, 19);
            this.dgvNivelServicio.MultiSelect = false;
            this.dgvNivelServicio.Name = "dgvNivelServicio";
            this.dgvNivelServicio.ReadOnly = true;
            this.dgvNivelServicio.RowHeadersVisible = false;
            this.dgvNivelServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNivelServicio.Size = new System.Drawing.Size(551, 294);
            this.dgvNivelServicio.StandardTab = true;
            this.dgvNivelServicio.TabIndex = 0;
            this.dgvNivelServicio.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvInconsistenciaFacturacions_RowsAdded);
            this.dgvNivelServicio.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvInconsistenciaFacturacions_RowsRemoved);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(80, 25);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 24;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(80, 56);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 25;
            // 
            // gbRangos
            // 
            this.gbRangos.Controls.Add(this.btnActualizar);
            this.gbRangos.Controls.Add(this.label2);
            this.gbRangos.Controls.Add(this.lblFechaInicio);
            this.gbRangos.Controls.Add(this.dtpFechaInicio);
            this.gbRangos.Controls.Add(this.dtpFechaFin);
            this.gbRangos.Location = new System.Drawing.Point(12, 70);
            this.gbRangos.Name = "gbRangos";
            this.gbRangos.Size = new System.Drawing.Size(563, 88);
            this.gbRangos.TabIndex = 26;
            this.gbRangos.TabStop = false;
            this.gbRangos.Text = "Rangos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Fecha Fin:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(6, 31);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 26;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(293, 489);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 21;
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
            this.btnNueva.Location = new System.Drawing.Point(197, 489);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(90, 40);
            this.btnNueva.TabIndex = 20;
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
            this.btnSalir.Location = new System.Drawing.Point(485, 489);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 23;
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
            this.btnEliminar.Location = new System.Drawing.Point(389, 489);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(347, 25);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 39);
            this.btnActualizar.TabIndex = 28;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            this.Identificador.DataPropertyName = "Cliente";
            this.Identificador.HeaderText = "Cliente";
            this.Identificador.Name = "Identificador";
            this.Identificador.ReadOnly = true;
            // 
            // clmPorcentajeEfectividad
            // 
            this.clmPorcentajeEfectividad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmPorcentajeEfectividad.DataPropertyName = "PorcentajeNivelEfectividad";
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.clmPorcentajeEfectividad.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmPorcentajeEfectividad.HeaderText = "% de Efectividad";
            this.clmPorcentajeEfectividad.Name = "clmPorcentajeEfectividad";
            this.clmPorcentajeEfectividad.ReadOnly = true;
            this.clmPorcentajeEfectividad.Width = 101;
            // 
            // clmPorcentajeCumplimiento
            // 
            this.clmPorcentajeCumplimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmPorcentajeCumplimiento.DataPropertyName = "PorcentajeNivelCumplimiento";
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.clmPorcentajeCumplimiento.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmPorcentajeCumplimiento.HeaderText = "% de Cumplimiento";
            this.clmPorcentajeCumplimiento.Name = "clmPorcentajeCumplimiento";
            this.clmPorcentajeCumplimiento.ReadOnly = true;
            this.clmPorcentajeCumplimiento.Width = 109;
            // 
            // clmFechaInicio
            // 
            this.clmFechaInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmFechaInicio.DataPropertyName = "FechaInicio";
            dataGridViewCellStyle4.Format = "d";
            this.clmFechaInicio.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmFechaInicio.HeaderText = "Fecha de Inicio";
            this.clmFechaInicio.Name = "clmFechaInicio";
            this.clmFechaInicio.ReadOnly = true;
            this.clmFechaInicio.Width = 73;
            // 
            // clmFechaFin
            // 
            this.clmFechaFin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmFechaFin.DataPropertyName = "FechaFin";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.clmFechaFin.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmFechaFin.HeaderText = "Fecha Final";
            this.clmFechaFin.Name = "clmFechaFin";
            this.clmFechaFin.ReadOnly = true;
            this.clmFechaFin.Width = 79;
            // 
            // frmAdministracionNivelServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 538);
            this.Controls.Add(this.gbRangos);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbInconsistencias);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionNivelServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Niveles de Servicio";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbInconsistencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNivelServicio)).EndInit();
            this.gbRangos.ResumeLayout(false);
            this.gbRangos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbInconsistencias;
        private System.Windows.Forms.DataGridView dgvNivelServicio;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.GroupBox gbRangos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPorcentajeEfectividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPorcentajeCumplimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaFin;
    }
}