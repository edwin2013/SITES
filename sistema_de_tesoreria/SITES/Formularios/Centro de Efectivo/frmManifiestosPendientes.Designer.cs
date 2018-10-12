namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmManifiestosPendientes
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
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Euros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudColones = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.gbListaManifiestos = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.gbAsignacionMonto = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.nudEuro = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDolar = new System.Windows.Forms.NumericUpDown();
            this.btnAsignarTula = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColones)).BeginInit();
            this.gbListaManifiestos.SuspendLayout();
            this.gbAsignacionMonto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEuro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDolar)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(99, 29);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(119, 21);
            this.dtpFechaInicio.TabIndex = 13;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(17, 29);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(76, 15);
            this.lblFechaInicio.TabIndex = 12;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fecha Final:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(350, 29);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(119, 21);
            this.dtpFechaFinal.TabIndex = 15;
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToOrderColumns = true;
            this.dgvManifiestos.AllowUserToResizeColumns = false;
            this.dgvManifiestos.AllowUserToResizeRows = false;
            this.dgvManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManifiestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManifiestos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManifiestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manifiesto,
            this.Id,
            this.Colones,
            this.Dolares,
            this.Euros,
            this.Fecha});
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(19, 81);
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(643, 155);
            this.dgvManifiestos.StandardTab = true;
            this.dgvManifiestos.TabIndex = 17;
            this.dgvManifiestos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManifiestos_CellClick);
            this.dgvManifiestos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManifiestos_CellContentClick);
            // 
            // Manifiesto
            // 
            this.Manifiesto.DataPropertyName = "Manifiesto";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Colones
            // 
            this.Colones.DataPropertyName = "Colones";
            this.Colones.HeaderText = "Colones";
            this.Colones.Name = "Colones";
            this.Colones.ReadOnly = true;
            // 
            // Dolares
            // 
            this.Dolares.DataPropertyName = "Dolares";
            this.Dolares.HeaderText = "Dolares";
            this.Dolares.Name = "Dolares";
            this.Dolares.ReadOnly = true;
            // 
            // Euros
            // 
            this.Euros.DataPropertyName = "Euros";
            this.Euros.HeaderText = "Euros";
            this.Euros.Name = "Euros";
            this.Euros.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha de Recepcion";
            this.Fecha.HeaderText = "Fecha de Recepcion";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // nudColones
            // 
            this.nudColones.DecimalPlaces = 2;
            this.nudColones.Location = new System.Drawing.Point(130, 33);
            this.nudColones.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudColones.Name = "nudColones";
            this.nudColones.Size = new System.Drawing.Size(190, 21);
            this.nudColones.TabIndex = 27;
            this.nudColones.ThousandsSeparator = true;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(59, 35);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(55, 15);
            this.lblMonto.TabIndex = 25;
            this.lblMonto.Text = "Colones:";
            // 
            // gbListaManifiestos
            // 
            this.gbListaManifiestos.Controls.Add(this.txtCantidad);
            this.gbListaManifiestos.Controls.Add(this.lblCantidad);
            this.gbListaManifiestos.Controls.Add(this.dgvManifiestos);
            this.gbListaManifiestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListaManifiestos.Location = new System.Drawing.Point(26, 174);
            this.gbListaManifiestos.Name = "gbListaManifiestos";
            this.gbListaManifiestos.Size = new System.Drawing.Size(688, 264);
            this.gbListaManifiestos.TabIndex = 29;
            this.gbListaManifiestos.TabStop = false;
            this.gbListaManifiestos.Text = "Lista de Manifiestos";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.Location = new System.Drawing.Point(166, 32);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(168, 21);
            this.txtCantidad.TabIndex = 42;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(17, 35);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(143, 15);
            this.lblCantidad.TabIndex = 41;
            this.lblCantidad.Text = "Cantidad no procesados:";
            // 
            // gbAsignacionMonto
            // 
            this.gbAsignacionMonto.Controls.Add(this.panel3);
            this.gbAsignacionMonto.Controls.Add(this.panel2);
            this.gbAsignacionMonto.Controls.Add(this.panel1);
            this.gbAsignacionMonto.Controls.Add(this.label3);
            this.gbAsignacionMonto.Controls.Add(this.nudEuro);
            this.gbAsignacionMonto.Controls.Add(this.label2);
            this.gbAsignacionMonto.Controls.Add(this.nudDolar);
            this.gbAsignacionMonto.Controls.Add(this.btnAsignarTula);
            this.gbAsignacionMonto.Controls.Add(this.lblMonto);
            this.gbAsignacionMonto.Controls.Add(this.nudColones);
            this.gbAsignacionMonto.Enabled = false;
            this.gbAsignacionMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAsignacionMonto.Location = new System.Drawing.Point(26, 452);
            this.gbAsignacionMonto.Name = "gbAsignacionMonto";
            this.gbAsignacionMonto.Size = new System.Drawing.Size(688, 123);
            this.gbAsignacionMonto.TabIndex = 40;
            this.gbAsignacionMonto.TabStop = false;
            this.gbAsignacionMonto.Text = "Monto Declarado ";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(305, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(15, 21);
            this.panel3.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(305, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 21);
            this.panel2.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(305, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 21);
            this.panel1.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Euros:";
            // 
            // nudEuro
            // 
            this.nudEuro.DecimalPlaces = 2;
            this.nudEuro.Location = new System.Drawing.Point(130, 95);
            this.nudEuro.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudEuro.Name = "nudEuro";
            this.nudEuro.Size = new System.Drawing.Size(190, 21);
            this.nudEuro.TabIndex = 33;
            this.nudEuro.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Dólares:";
            // 
            // nudDolar
            // 
            this.nudDolar.DecimalPlaces = 2;
            this.nudDolar.Location = new System.Drawing.Point(130, 64);
            this.nudDolar.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudDolar.Name = "nudDolar";
            this.nudDolar.Size = new System.Drawing.Size(190, 21);
            this.nudDolar.TabIndex = 31;
            this.nudDolar.ThousandsSeparator = true;
            // 
            // btnAsignarTula
            // 
            this.btnAsignarTula.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAsignarTula.Image = global::GUILayer.Properties.Resources.edit1;
            this.btnAsignarTula.Location = new System.Drawing.Point(493, 43);
            this.btnAsignarTula.Name = "btnAsignarTula";
            this.btnAsignarTula.Size = new System.Drawing.Size(108, 42);
            this.btnAsignarTula.TabIndex = 29;
            this.btnAsignarTula.Text = "Asignar";
            this.btnAsignarTula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignarTula.UseVisualStyleBackColor = false;
            this.btnAsignarTula.Click += new System.EventHandler(this.btnAsignarTula_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(2, 2);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(767, 60);
            this.pnlFondo.TabIndex = 41;
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImage = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(398, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFechaInicio);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnVer);
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 77);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda ";
            // 
            // btnVer
            // 
            this.btnVer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnVer.Location = new System.Drawing.Point(554, 20);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(108, 42);
            this.btnVer.TabIndex = 39;
            this.btnVer.Text = "Ver";
            this.btnVer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = global::GUILayer.Properties.Resources.salir;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(380, 592);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.SystemColors.Control;
            this.btnTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnTerminar.Location = new System.Drawing.Point(251, 592);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(109, 42);
            this.btnTerminar.TabIndex = 23;
            this.btnTerminar.Text = "Guardar";
            this.btnTerminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // frmManifiestosPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(744, 646);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbAsignacionMonto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbListaManifiestos);
            this.Controls.Add(this.btnTerminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmManifiestosPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Manifiestos no Procesados";
            this.Load += new System.EventHandler(this.frmManifiestosPendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColones)).EndInit();
            this.gbListaManifiestos.ResumeLayout(false);
            this.gbListaManifiestos.PerformLayout();
            this.gbAsignacionMonto.ResumeLayout(false);
            this.gbAsignacionMonto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEuro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDolar)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.NumericUpDown nudColones;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.GroupBox gbListaManifiestos;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.GroupBox gbAsignacionMonto;
        private System.Windows.Forms.Button btnAsignarTula;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudEuro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn Euros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}