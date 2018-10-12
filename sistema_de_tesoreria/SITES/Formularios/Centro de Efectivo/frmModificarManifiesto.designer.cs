namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmModificarManifiesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarManifiesto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.gbManifiestos = new System.Windows.Forms.GroupBox();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.gbCambioCodigoManifiesto = new System.Windows.Forms.GroupBox();
            this.txtCodigoManifiestoNuevo = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiestoNuevo = new System.Windows.Forms.Label();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            this.gbManifiestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.gbCambioCodigoManifiesto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-6, 1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(450, 60);
            this.pnlFondo.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(3, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(400, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(128, 535);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(224, 535);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.btnActualizar);
            this.gbBusqueda.Controls.Add(this.lblFecha);
            this.gbBusqueda.Controls.Add(this.dtpFecha);
            this.gbBusqueda.Location = new System.Drawing.Point(-2, 65);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(446, 60);
            this.gbBusqueda.TabIndex = 7;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Filtrar Búsqueda";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(342, 11);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(16, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(76, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha del día:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(98, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // gbManifiestos
            // 
            this.gbManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbManifiestos.Controls.Add(this.dgvManifiestos);
            this.gbManifiestos.Location = new System.Drawing.Point(8, 131);
            this.gbManifiestos.Name = "gbManifiestos";
            this.gbManifiestos.Size = new System.Drawing.Size(436, 318);
            this.gbManifiestos.TabIndex = 8;
            this.gbManifiestos.TabStop = false;
            this.gbManifiestos.Text = "Manifiestos";
            // 
            // dgvManifiestos
            // 
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            this.dgvManifiestos.AllowUserToOrderColumns = true;
            this.dgvManifiestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManifiestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManifiestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.Location = new System.Drawing.Point(6, 19);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersVisible = false;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(424, 293);
            this.dgvManifiestos.StandardTab = true;
            this.dgvManifiestos.TabIndex = 0;
            this.dgvManifiestos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManifiestos_CellContentClick);
            // 
            // gbCambioCodigoManifiesto
            // 
            this.gbCambioCodigoManifiesto.Controls.Add(this.txtCodigoManifiestoNuevo);
            this.gbCambioCodigoManifiesto.Controls.Add(this.lblCodigoManifiestoNuevo);
            this.gbCambioCodigoManifiesto.Enabled = false;
            this.gbCambioCodigoManifiesto.Location = new System.Drawing.Point(12, 455);
            this.gbCambioCodigoManifiesto.Name = "gbCambioCodigoManifiesto";
            this.gbCambioCodigoManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbCambioCodigoManifiesto.Size = new System.Drawing.Size(430, 65);
            this.gbCambioCodigoManifiesto.TabIndex = 15;
            this.gbCambioCodigoManifiesto.TabStop = false;
            this.gbCambioCodigoManifiesto.Text = "Cambio del código de Manifiesto";
            // 
            // txtCodigoManifiestoNuevo
            // 
            this.txtCodigoManifiestoNuevo.BackColor = System.Drawing.Color.White;
            this.txtCodigoManifiestoNuevo.Location = new System.Drawing.Point(77, 27);
            this.txtCodigoManifiestoNuevo.Name = "txtCodigoManifiestoNuevo";
            this.txtCodigoManifiestoNuevo.Size = new System.Drawing.Size(324, 20);
            this.txtCodigoManifiestoNuevo.TabIndex = 1;
            // 
            // lblCodigoManifiestoNuevo
            // 
            this.lblCodigoManifiestoNuevo.AutoSize = true;
            this.lblCodigoManifiestoNuevo.Location = new System.Drawing.Point(28, 30);
            this.lblCodigoManifiestoNuevo.Name = "lblCodigoManifiestoNuevo";
            this.lblCodigoManifiestoNuevo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoManifiestoNuevo.TabIndex = 0;
            this.lblCodigoManifiestoNuevo.Text = "Código:";
            // 
            // frmModificarManifiesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 587);
            this.Controls.Add(this.gbCambioCodigoManifiesto);
            this.Controls.Add(this.gbManifiestos);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmModificarManifiesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SITES - Modificar Manifiesto";
            this.Load += new System.EventHandler(this.frmModificarManifiesto_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbManifiestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.gbCambioCodigoManifiesto.ResumeLayout(false);
            this.gbCambioCodigoManifiesto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbManifiestos;
        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.GroupBox gbCambioCodigoManifiesto;
        private System.Windows.Forms.TextBox txtCodigoManifiestoNuevo;
        private System.Windows.Forms.Label lblCodigoManifiestoNuevo;
    }
}