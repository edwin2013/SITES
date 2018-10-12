namespace GUILayer.Formularios.Recepcion_de_Tulas
{
    partial class frmRecepcionDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionDocumentos));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReceptor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtManifiesto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.clManifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTulas = new System.Windows.Forms.DataGridView();
            this.clTula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTula = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardarManifiestos = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGuardarTula = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cboTransportadora = new GUILayer.ComboBoxBusqueda();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(390, 44);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-2, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(640, 54);
            this.pnlFondo.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTransportadora);
            this.groupBox1.Controls.Add(this.txtReceptor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Recepción";
            // 
            // txtReceptor
            // 
            this.txtReceptor.Enabled = false;
            this.txtReceptor.Location = new System.Drawing.Point(72, 77);
            this.txtReceptor.Name = "txtReceptor";
            this.txtReceptor.Size = new System.Drawing.Size(272, 20);
            this.txtReceptor.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Receptor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Empresa de Transporte:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 26);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(58, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(286, 20);
            this.dtpFecha.TabIndex = 11;
            // 
            // txtManifiesto
            // 
            this.txtManifiesto.Location = new System.Drawing.Point(60, 33);
            this.txtManifiesto.Name = "txtManifiesto";
            this.txtManifiesto.Size = new System.Drawing.Size(178, 20);
            this.txtManifiesto.TabIndex = 12;
            this.txtManifiesto.TextChanged += new System.EventHandler(this.txtManifiesto_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nuevo:";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clManifiesto});
            this.dgvManifiestos.Location = new System.Drawing.Point(9, 88);
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.Size = new System.Drawing.Size(244, 221);
            this.dgvManifiestos.TabIndex = 17;
            this.dgvManifiestos.SelectionChanged += new System.EventHandler(this.dgvManifiestos_SelectionChanged);
            // 
            // clManifiesto
            // 
            this.clManifiesto.DataPropertyName = "Codigo";
            this.clManifiesto.HeaderText = "Manifiestos";
            this.clManifiesto.Name = "clManifiesto";
            this.clManifiesto.Width = 200;
            // 
            // dgvTulas
            // 
            this.dgvTulas.AllowUserToAddRows = false;
            this.dgvTulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clTula});
            this.dgvTulas.Location = new System.Drawing.Point(20, 88);
            this.dgvTulas.Name = "dgvTulas";
            this.dgvTulas.Size = new System.Drawing.Size(244, 221);
            this.dgvTulas.TabIndex = 20;
            // 
            // clTula
            // 
            this.clTula.DataPropertyName = "Codigo";
            this.clTula.HeaderText = "Tulas";
            this.clTula.Name = "clTula";
            this.clTula.Width = 200;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nueva:";
            // 
            // txtTula
            // 
            this.txtTula.Enabled = false;
            this.txtTula.Location = new System.Drawing.Point(77, 33);
            this.txtTula.Name = "txtTula";
            this.txtTula.Size = new System.Drawing.Size(178, 20);
            this.txtTula.TabIndex = 18;
            this.txtTula.TextChanged += new System.EventHandler(this.txtTula_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardarManifiestos);
            this.groupBox2.Controls.Add(this.dgvManifiestos);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtManifiesto);
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 324);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manifiestos";
            // 
            // btnGuardarManifiestos
            // 
            this.btnGuardarManifiestos.Enabled = false;
            this.btnGuardarManifiestos.Location = new System.Drawing.Point(92, 59);
            this.btnGuardarManifiestos.Name = "btnGuardarManifiestos";
            this.btnGuardarManifiestos.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarManifiestos.TabIndex = 21;
            this.btnGuardarManifiestos.Text = "Guardar";
            this.btnGuardarManifiestos.UseVisualStyleBackColor = true;
            this.btnGuardarManifiestos.Click += new System.EventHandler(this.btnGuardarManifiestos_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGuardarTula);
            this.groupBox3.Controls.Add(this.txtTula);
            this.groupBox3.Controls.Add(this.dgvTulas);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(332, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 324);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tulas";
            // 
            // btnGuardarTula
            // 
            this.btnGuardarTula.Enabled = false;
            this.btnGuardarTula.Location = new System.Drawing.Point(109, 59);
            this.btnGuardarTula.Name = "btnGuardarTula";
            this.btnGuardarTula.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarTula.TabIndex = 22;
            this.btnGuardarTula.Text = "Guardar";
            this.btnGuardarTula.UseVisualStyleBackColor = true;
            this.btnGuardarTula.Click += new System.EventHandler(this.btnGuardarTula_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnModificar.Location = new System.Drawing.Point(329, 532);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 22;
            this.btnModificar.TabStop = false;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(521, 532);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(425, 532);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 24;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cboTransportadora
            // 
            this.cboTransportadora.Busqueda = true;
            this.cboTransportadora.FormattingEnabled = true;
            this.cboTransportadora.ListaMostrada = null;
            this.cboTransportadora.Location = new System.Drawing.Point(138, 49);
            this.cboTransportadora.Name = "cboTransportadora";
            this.cboTransportadora.Size = new System.Drawing.Size(206, 21);
            this.cboTransportadora.TabIndex = 15;
            // 
            // frmRecepcionDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 584);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecepcionDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepción de Documentos";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTulas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ComboBoxBusqueda cboTransportadora;
        private System.Windows.Forms.TextBox txtReceptor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManifiesto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.DataGridView dgvTulas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTula;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardarManifiestos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGuardarTula;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTula;
    }
}