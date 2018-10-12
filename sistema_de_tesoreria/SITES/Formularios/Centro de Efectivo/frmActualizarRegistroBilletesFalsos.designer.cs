namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmActualizarRegistroBilletesFalsos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizarRegistroBilletesFalsos));
            this.dgvbilletes = new System.Windows.Forms.DataGridView();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbregistroBilleteFalso = new System.Windows.Forms.GroupBox();
            this.cboDenominacion = new GUILayer.ComboBoxBusqueda();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblSerieBilleteFalso = new System.Windows.Forms.Label();
            this.lblDenominacion = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnQuitarBillete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbilletes)).BeginInit();
            this.gbregistroBilleteFalso.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvbilletes
            // 
            this.dgvbilletes.AllowUserToAddRows = false;
            this.dgvbilletes.AllowUserToDeleteRows = false;
            this.dgvbilletes.AllowUserToOrderColumns = true;
            this.dgvbilletes.AllowUserToResizeColumns = false;
            this.dgvbilletes.AllowUserToResizeRows = false;
            this.dgvbilletes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbilletes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvbilletes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbilletes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Moneda,
            this.Denominacion,
            this.Serie,
            this.ID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvbilletes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvbilletes.EnableHeadersVisualStyles = false;
            this.dgvbilletes.Location = new System.Drawing.Point(20, 219);
            this.dgvbilletes.MultiSelect = false;
            this.dgvbilletes.Name = "dgvbilletes";
            this.dgvbilletes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbilletes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvbilletes.RowHeadersVisible = false;
            this.dgvbilletes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbilletes.Size = new System.Drawing.Size(615, 174);
            this.dgvbilletes.TabIndex = 23;
            this.dgvbilletes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbilletes_CellClick);
            this.dgvbilletes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvbilletes_MouseClick);
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "moneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            // 
            // Denominacion
            // 
            this.Denominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Denominacion.DataPropertyName = "denominacion";
            this.Denominacion.HeaderText = "Denominacion";
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.ReadOnly = true;
            // 
            // Serie
            // 
            this.Serie.DataPropertyName = "SerieBillete";
            this.Serie.HeaderText = "Serie";
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // gbregistroBilleteFalso
            // 
            this.gbregistroBilleteFalso.Controls.Add(this.cboDenominacion);
            this.gbregistroBilleteFalso.Controls.Add(this.txtCodigo);
            this.gbregistroBilleteFalso.Controls.Add(this.btnAgregar);
            this.gbregistroBilleteFalso.Controls.Add(this.cboMoneda);
            this.gbregistroBilleteFalso.Controls.Add(this.lblMoneda);
            this.gbregistroBilleteFalso.Controls.Add(this.lblSerieBilleteFalso);
            this.gbregistroBilleteFalso.Controls.Add(this.lblDenominacion);
            this.gbregistroBilleteFalso.Location = new System.Drawing.Point(12, 69);
            this.gbregistroBilleteFalso.Name = "gbregistroBilleteFalso";
            this.gbregistroBilleteFalso.Size = new System.Drawing.Size(614, 133);
            this.gbregistroBilleteFalso.TabIndex = 22;
            this.gbregistroBilleteFalso.TabStop = false;
            this.gbregistroBilleteFalso.Text = "Registro Billetes Falsos";
            // 
            // cboDenominacion
            // 
            this.cboDenominacion.Busqueda = true;
            this.cboDenominacion.FormattingEnabled = true;
            this.cboDenominacion.ListaMostrada = null;
            this.cboDenominacion.Location = new System.Drawing.Point(96, 60);
            this.cboDenominacion.Name = "cboDenominacion";
            this.cboDenominacion.Size = new System.Drawing.Size(339, 21);
            this.cboDenominacion.TabIndex = 24;
            this.cboDenominacion.SelectedIndexChanged += new System.EventHandler(this.cboDenominacion_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(96, 91);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(339, 20);
            this.txtCodigo.TabIndex = 23;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnAgregar.Location = new System.Drawing.Point(451, 49);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(106, 40);
            this.btnAgregar.TabIndex = 22;
            this.btnAgregar.Text = "Agregar / Actualizar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares"});
            this.cboMoneda.Location = new System.Drawing.Point(96, 25);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(339, 21);
            this.cboMoneda.TabIndex = 21;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(41, 28);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 20;
            this.lblMoneda.Text = "Moneda:";
            // 
            // lblSerieBilleteFalso
            // 
            this.lblSerieBilleteFalso.AutoSize = true;
            this.lblSerieBilleteFalso.Location = new System.Drawing.Point(56, 94);
            this.lblSerieBilleteFalso.Name = "lblSerieBilleteFalso";
            this.lblSerieBilleteFalso.Size = new System.Drawing.Size(34, 13);
            this.lblSerieBilleteFalso.TabIndex = 16;
            this.lblSerieBilleteFalso.Text = "Serie:";
            // 
            // lblDenominacion
            // 
            this.lblDenominacion.AutoSize = true;
            this.lblDenominacion.Location = new System.Drawing.Point(12, 63);
            this.lblDenominacion.Name = "lblDenominacion";
            this.lblDenominacion.Size = new System.Drawing.Size(78, 13);
            this.lblDenominacion.TabIndex = 18;
            this.lblDenominacion.Text = "Denominación:";
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.Image = global::GUILayer.Properties.Resources.salir;
            this.btnVolver.Location = new System.Drawing.Point(386, 408);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 38);
            this.btnVolver.TabIndex = 25;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatAppearance.BorderSize = 2;
            this.btnConfirmar.Image = global::GUILayer.Properties.Resources.continuar;
            this.btnConfirmar.Location = new System.Drawing.Point(268, 408);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 38);
            this.btnConfirmar.TabIndex = 25;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pictureBox1);
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(1, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(634, 60);
            this.pnlFondo.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 58);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // btnQuitarBillete
            // 
            this.btnQuitarBillete.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarBillete.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnQuitarBillete.Location = new System.Drawing.Point(157, 408);
            this.btnQuitarBillete.Name = "btnQuitarBillete";
            this.btnQuitarBillete.Size = new System.Drawing.Size(90, 38);
            this.btnQuitarBillete.TabIndex = 27;
            this.btnQuitarBillete.Text = "Quitar";
            this.btnQuitarBillete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarBillete.UseVisualStyleBackColor = false;
            this.btnQuitarBillete.Click += new System.EventHandler(this.btnQuitarBillete_Click);
            // 
            // frmActualizarRegistroBilletesFalsos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 470);
            this.Controls.Add(this.btnQuitarBillete);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvbilletes);
            this.Controls.Add(this.gbregistroBilleteFalso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmActualizarRegistroBilletesFalsos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesamiento de Bajo Volumen - Ingreso de Billetes Falsos";
            this.Load += new System.EventHandler(this.frmRegistroBilletesFalsos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbilletes)).EndInit();
            this.gbregistroBilleteFalso.ResumeLayout(false);
            this.gbregistroBilleteFalso.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvbilletes;
        private System.Windows.Forms.GroupBox gbregistroBilleteFalso;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblSerieBilleteFalso;
        private System.Windows.Forms.Label lblDenominacion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnConfirmar;
        private ComboBoxBusqueda cboDenominacion;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.Button btnQuitarBillete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}