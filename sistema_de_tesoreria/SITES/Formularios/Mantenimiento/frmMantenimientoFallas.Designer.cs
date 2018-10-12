namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmMantenimientoFallas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoFallas));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tbFallas = new System.Windows.Forms.TabControl();
            this.tpCategoria = new System.Windows.Forms.TabPage();
            this.tp = new System.Windows.Forms.TabPage();
            this.gbFallas = new System.Windows.Forms.GroupBox();
            this.lblDetalleFalla = new System.Windows.Forms.Label();
            this.dgvDetalleFallas = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoFalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Invalido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDValido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarFalla = new System.Windows.Forms.Button();
            this.txtDetalleFalla = new System.Windows.Forms.TextBox();
            this.btnQuitarFalla = new System.Windows.Forms.Button();
            this.cboTipo = new GUILayer.ComboBoxBusqueda();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.tbFallas.SuspendLayout();
            this.tpCategoria.SuspendLayout();
            this.tp.SuspendLayout();
            this.gbFallas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFallas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(303, 495);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(125, 45);
            this.txtDescripcion.MaxLength = 400;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(279, 57);
            this.txtDescripcion.TabIndex = 3;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.cboTipo);
            this.gbDatos.Controls.Add(this.txtDescripcion);
            this.gbDatos.Controls.Add(this.lblDescripcion);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Location = new System.Drawing.Point(15, 26);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(425, 113);
            this.gbDatos.TabIndex = 5;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de las fallas";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(53, 48);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(72, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(31, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Tipo:";
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
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, 3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(505, 60);
            this.pnlFondo.TabIndex = 4;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(399, 495);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tbFallas
            // 
            this.tbFallas.Controls.Add(this.tpCategoria);
            this.tbFallas.Controls.Add(this.tp);
            this.tbFallas.Location = new System.Drawing.Point(12, 78);
            this.tbFallas.Name = "tbFallas";
            this.tbFallas.SelectedIndex = 0;
            this.tbFallas.Size = new System.Drawing.Size(481, 411);
            this.tbFallas.TabIndex = 31;
            // 
            // tpCategoria
            // 
            this.tpCategoria.Controls.Add(this.gbDatos);
            this.tpCategoria.Location = new System.Drawing.Point(4, 22);
            this.tpCategoria.Name = "tpCategoria";
            this.tpCategoria.Padding = new System.Windows.Forms.Padding(3);
            this.tpCategoria.Size = new System.Drawing.Size(473, 385);
            this.tpCategoria.TabIndex = 0;
            this.tpCategoria.Text = "Categorías";
            this.tpCategoria.UseVisualStyleBackColor = true;
            // 
            // tp
            // 
            this.tp.Controls.Add(this.gbFallas);
            this.tp.Location = new System.Drawing.Point(4, 22);
            this.tp.Name = "tp";
            this.tp.Padding = new System.Windows.Forms.Padding(3);
            this.tp.Size = new System.Drawing.Size(473, 385);
            this.tp.TabIndex = 1;
            this.tp.Text = "Detalle";
            this.tp.UseVisualStyleBackColor = true;
            // 
            // gbFallas
            // 
            this.gbFallas.Controls.Add(this.lblDetalleFalla);
            this.gbFallas.Controls.Add(this.dgvDetalleFallas);
            this.gbFallas.Controls.Add(this.btnAgregarFalla);
            this.gbFallas.Controls.Add(this.txtDetalleFalla);
            this.gbFallas.Controls.Add(this.btnQuitarFalla);
            this.gbFallas.Location = new System.Drawing.Point(19, 21);
            this.gbFallas.Name = "gbFallas";
            this.gbFallas.Size = new System.Drawing.Size(427, 358);
            this.gbFallas.TabIndex = 1;
            this.gbFallas.TabStop = false;
            this.gbFallas.Text = "Fallas";
            // 
            // lblDetalleFalla
            // 
            this.lblDetalleFalla.AutoSize = true;
            this.lblDetalleFalla.Location = new System.Drawing.Point(27, 33);
            this.lblDetalleFalla.Name = "lblDetalleFalla";
            this.lblDetalleFalla.Size = new System.Drawing.Size(43, 13);
            this.lblDetalleFalla.TabIndex = 0;
            this.lblDetalleFalla.Text = "Detalle:";
            // 
            // dgvDetalleFallas
            // 
            this.dgvDetalleFallas.AllowUserToAddRows = false;
            this.dgvDetalleFallas.AllowUserToDeleteRows = false;
            this.dgvDetalleFallas.AllowUserToOrderColumns = true;
            this.dgvDetalleFallas.AllowUserToResizeColumns = false;
            this.dgvDetalleFallas.AllowUserToResizeRows = false;
            this.dgvDetalleFallas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleFallas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleFallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleFallas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Descripcion,
            this.TipoFalla,
            this.DB_ID,
            this.ID_Invalido,
            this.IDValido});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleFallas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleFallas.EnableHeadersVisualStyles = false;
            this.dgvDetalleFallas.Location = new System.Drawing.Point(6, 65);
            this.dgvDetalleFallas.Name = "dgvDetalleFallas";
            this.dgvDetalleFallas.RowHeadersVisible = false;
            this.dgvDetalleFallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleFallas.Size = new System.Drawing.Size(415, 241);
            this.dgvDetalleFallas.TabIndex = 3;
            this.dgvDetalleFallas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleFallas_CellEndEdit);
            this.dgvDetalleFallas.SelectionChanged += new System.EventHandler(this.dgvDetalleFallas_SelectionChanged);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descripcion.DataPropertyName = "Nombre";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 87;
            // 
            // TipoFalla
            // 
            this.TipoFalla.DataPropertyName = "Falla";
            this.TipoFalla.HeaderText = "Tipo de Falla";
            this.TipoFalla.Name = "TipoFalla";
            this.TipoFalla.Visible = false;
            // 
            // DB_ID
            // 
            this.DB_ID.DataPropertyName = "DB_ID";
            this.DB_ID.HeaderText = "DB_ID";
            this.DB_ID.Name = "DB_ID";
            this.DB_ID.Visible = false;
            // 
            // ID_Invalido
            // 
            this.ID_Invalido.DataPropertyName = "ID_Invalido";
            this.ID_Invalido.HeaderText = "ID invalido";
            this.ID_Invalido.Name = "ID_Invalido";
            this.ID_Invalido.Visible = false;
            // 
            // IDValido
            // 
            this.IDValido.DataPropertyName = "ID_Valido";
            this.IDValido.HeaderText = "ID Valido";
            this.IDValido.Name = "IDValido";
            this.IDValido.Visible = false;
            // 
            // btnAgregarFalla
            // 
            this.btnAgregarFalla.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarFalla.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarFalla.Location = new System.Drawing.Point(331, 19);
            this.btnAgregarFalla.Name = "btnAgregarFalla";
            this.btnAgregarFalla.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarFalla.TabIndex = 2;
            this.btnAgregarFalla.Text = "Agregar";
            this.btnAgregarFalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarFalla.UseVisualStyleBackColor = false;
            this.btnAgregarFalla.Click += new System.EventHandler(this.btnAgregarPuntoVenta_Click);
            // 
            // txtDetalleFalla
            // 
            this.txtDetalleFalla.Location = new System.Drawing.Point(96, 29);
            this.txtDetalleFalla.MaxLength = 100;
            this.txtDetalleFalla.Name = "txtDetalleFalla";
            this.txtDetalleFalla.Size = new System.Drawing.Size(229, 20);
            this.txtDetalleFalla.TabIndex = 1;
            // 
            // btnQuitarFalla
            // 
            this.btnQuitarFalla.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarFalla.Enabled = false;
            this.btnQuitarFalla.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnQuitarFalla.Location = new System.Drawing.Point(331, 312);
            this.btnQuitarFalla.Name = "btnQuitarFalla";
            this.btnQuitarFalla.Size = new System.Drawing.Size(90, 40);
            this.btnQuitarFalla.TabIndex = 4;
            this.btnQuitarFalla.Text = "Quitar";
            this.btnQuitarFalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarFalla.UseVisualStyleBackColor = false;
            this.btnQuitarFalla.Click += new System.EventHandler(this.btnQuitarPuntoVenta_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.Busqueda = true;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.ListaMostrada = null;
            this.cboTipo.Location = new System.Drawing.Point(125, 13);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(121, 21);
            this.cboTipo.TabIndex = 4;
            // 
            // frmMantenimientoFallas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 547);
            this.Controls.Add(this.tbFallas);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoFallas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Fallas";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.tbFallas.ResumeLayout(false);
            this.tpCategoria.ResumeLayout(false);
            this.tp.ResumeLayout(false);
            this.gbFallas.ResumeLayout(false);
            this.gbFallas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFallas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TabControl tbFallas;
        private System.Windows.Forms.TabPage tpCategoria;
        private System.Windows.Forms.TabPage tp;
        private System.Windows.Forms.GroupBox gbFallas;
        private System.Windows.Forms.Label lblDetalleFalla;
        private System.Windows.Forms.DataGridView dgvDetalleFallas;
        private System.Windows.Forms.Button btnAgregarFalla;
        private System.Windows.Forms.TextBox txtDetalleFalla;
        private System.Windows.Forms.Button btnQuitarFalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoFalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Invalido;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDValido;
        private ComboBoxBusqueda cboTipo;
    }
}