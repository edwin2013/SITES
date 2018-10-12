namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmAdministracionFichaTecnicaEquipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionFichaTecnicaEquipos));
            this.dgvFichasTecnicas = new System.Windows.Forms.DataGridView();
            this.clEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPeriodicidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBoleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPreventivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gbCartuchos = new System.Windows.Forms.GroupBox();
            this.cboEquipo = new GUILayer.ComboBoxBusqueda();
            this.cboProveedor = new GUILayer.ComboBoxBusqueda();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichasTecnicas)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCartuchos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFichasTecnicas
            // 
            this.dgvFichasTecnicas.AllowUserToAddRows = false;
            this.dgvFichasTecnicas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvFichasTecnicas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFichasTecnicas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFichasTecnicas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFichasTecnicas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFichasTecnicas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFichasTecnicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFichasTecnicas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clEquipo,
            this.clPeriodicidad,
            this.clFecha,
            this.clEstatus,
            this.clBoleta,
            this.clPreventivo,
            this.clObservaciones,
            this.clCosto});
            this.dgvFichasTecnicas.EnableHeadersVisualStyles = false;
            this.dgvFichasTecnicas.Location = new System.Drawing.Point(6, 89);
            this.dgvFichasTecnicas.MultiSelect = false;
            this.dgvFichasTecnicas.Name = "dgvFichasTecnicas";
            this.dgvFichasTecnicas.ReadOnly = true;
            this.dgvFichasTecnicas.RowHeadersVisible = false;
            this.dgvFichasTecnicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFichasTecnicas.Size = new System.Drawing.Size(709, 308);
            this.dgvFichasTecnicas.StandardTab = true;
            this.dgvFichasTecnicas.TabIndex = 0;
            this.dgvFichasTecnicas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvFichasTecnicas_RowsAdded);
            this.dgvFichasTecnicas.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvFichasTecnicas_RowsRemoved);
            // 
            // clEquipo
            // 
            this.clEquipo.DataPropertyName = "Equipo";
            this.clEquipo.HeaderText = "Equipo";
            this.clEquipo.Name = "clEquipo";
            this.clEquipo.ReadOnly = true;
            this.clEquipo.Width = 64;
            // 
            // clPeriodicidad
            // 
            this.clPeriodicidad.DataPropertyName = "Periodicidad";
            this.clPeriodicidad.HeaderText = "Periodicidad";
            this.clPeriodicidad.Name = "clPeriodicidad";
            this.clPeriodicidad.ReadOnly = true;
            this.clPeriodicidad.Width = 89;
            // 
            // clFecha
            // 
            this.clFecha.DataPropertyName = "Fecha";
            this.clFecha.HeaderText = "Fecha";
            this.clFecha.Name = "clFecha";
            this.clFecha.ReadOnly = true;
            this.clFecha.Width = 61;
            // 
            // clEstatus
            // 
            this.clEstatus.DataPropertyName = "Estatus";
            this.clEstatus.HeaderText = "Estatus";
            this.clEstatus.Name = "clEstatus";
            this.clEstatus.ReadOnly = true;
            this.clEstatus.Width = 66;
            // 
            // clBoleta
            // 
            this.clBoleta.DataPropertyName = "Boleta";
            this.clBoleta.HeaderText = "Boleta";
            this.clBoleta.Name = "clBoleta";
            this.clBoleta.ReadOnly = true;
            this.clBoleta.Width = 61;
            // 
            // clPreventivo
            // 
            this.clPreventivo.DataPropertyName = "Mantenimiento";
            this.clPreventivo.HeaderText = "Mantenimiento";
            this.clPreventivo.Name = "clPreventivo";
            this.clPreventivo.ReadOnly = true;
            // 
            // clObservaciones
            // 
            this.clObservaciones.DataPropertyName = "Observaciones";
            this.clObservaciones.HeaderText = "Observaciones";
            this.clObservaciones.Name = "clObservaciones";
            this.clObservaciones.ReadOnly = true;
            this.clObservaciones.Width = 102;
            // 
            // clCosto
            // 
            this.clCosto.DataPropertyName = "Costo";
            this.clCosto.HeaderText = "Costo";
            this.clCosto.Name = "clCosto";
            this.clCosto.ReadOnly = true;
            this.clCosto.Width = 58;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(625, 403);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(433, 403);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNuevo.Location = new System.Drawing.Point(337, 403);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 40);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, -4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(748, 58);
            this.pnlFondo.TabIndex = 6;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(-1, -4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(529, 403);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gbCartuchos
            // 
            this.gbCartuchos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCartuchos.Controls.Add(this.cboEquipo);
            this.gbCartuchos.Controls.Add(this.cboProveedor);
            this.gbCartuchos.Controls.Add(this.btnActualizar);
            this.gbCartuchos.Controls.Add(this.dtpInicio);
            this.gbCartuchos.Controls.Add(this.dtpFin);
            this.gbCartuchos.Controls.Add(this.label4);
            this.gbCartuchos.Controls.Add(this.label3);
            this.gbCartuchos.Controls.Add(this.label2);
            this.gbCartuchos.Controls.Add(this.label1);
            this.gbCartuchos.Controls.Add(this.btnSalir);
            this.gbCartuchos.Controls.Add(this.dgvFichasTecnicas);
            this.gbCartuchos.Controls.Add(this.btnModificar);
            this.gbCartuchos.Controls.Add(this.btnEliminar);
            this.gbCartuchos.Controls.Add(this.btnNuevo);
            this.gbCartuchos.Location = new System.Drawing.Point(12, 60);
            this.gbCartuchos.Name = "gbCartuchos";
            this.gbCartuchos.Size = new System.Drawing.Size(721, 452);
            this.gbCartuchos.TabIndex = 7;
            this.gbCartuchos.TabStop = false;
            this.gbCartuchos.Text = "Ficha Técinica de Equipos";
            // 
            // cboEquipo
            // 
            this.cboEquipo.Busqueda = true;
            this.cboEquipo.FormattingEnabled = true;
            this.cboEquipo.ListaMostrada = null;
            this.cboEquipo.Location = new System.Drawing.Point(364, 50);
            this.cboEquipo.Name = "cboEquipo";
            this.cboEquipo.Size = new System.Drawing.Size(159, 21);
            this.cboEquipo.TabIndex = 22;
            // 
            // cboProveedor
            // 
            this.cboProveedor.Busqueda = true;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.ListaMostrada = null;
            this.cboProveedor.Location = new System.Drawing.Point(364, 21);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(159, 21);
            this.cboProveedor.TabIndex = 21;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Location = new System.Drawing.Point(555, 26);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 40);
            this.btnActualizar.TabIndex = 20;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(72, 21);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(198, 20);
            this.dtpInicio.TabIndex = 17;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(72, 53);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFin.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Equipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Fecha Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha Inicio";
            // 
            // frmAdministracionFichaTecnicaEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 515);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCartuchos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionFichaTecnicaEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración Ficha Técnica Equipos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichasTecnicas)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCartuchos.ResumeLayout(false);
            this.gbCartuchos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFichasTecnicas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gbCartuchos;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private ComboBoxBusqueda cboEquipo;
        private ComboBoxBusqueda cboProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPeriodicidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBoleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPreventivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCosto;
    }
}