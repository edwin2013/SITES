namespace GUILayer
{
    partial class frmCambioGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioGrupo));
            this.cboGrupo = new GUILayer.ComboBoxBusqueda();
            this.nudCaja = new System.Windows.Forms.NumericUpDown();
            this.lblCaja = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.gbGrupo = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaja)).BeginInit();
            this.gbGrupo.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboGrupo
            // 
            this.cboGrupo.Busqueda = false;
            this.cboGrupo.ListaMostrada = null;
            this.cboGrupo.Location = new System.Drawing.Point(65, 24);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(199, 21);
            this.cboGrupo.TabIndex = 1;
            this.cboGrupo.SelectedIndexChanged += new System.EventHandler(this.cboGrupo_SelectedIndexChanged);
            // 
            // nudCaja
            // 
            this.nudCaja.Location = new System.Drawing.Point(312, 27);
            this.nudCaja.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudCaja.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCaja.Name = "nudCaja";
            this.nudCaja.Size = new System.Drawing.Size(57, 20);
            this.nudCaja.TabIndex = 3;
            this.nudCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCaja.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(275, 29);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(31, 13);
            this.lblCaja.TabIndex = 2;
            this.lblCaja.Text = "Caja:";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(20, 29);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 0;
            this.lblGrupo.Text = "Grupo:";
            // 
            // gbGrupo
            // 
            this.gbGrupo.Controls.Add(this.cboGrupo);
            this.gbGrupo.Controls.Add(this.nudCaja);
            this.gbGrupo.Controls.Add(this.lblCaja);
            this.gbGrupo.Controls.Add(this.lblGrupo);
            this.gbGrupo.Location = new System.Drawing.Point(6, 62);
            this.gbGrupo.Name = "gbGrupo";
            this.gbGrupo.Size = new System.Drawing.Size(380, 60);
            this.gbGrupo.TabIndex = 1;
            this.gbGrupo.TabStop = false;
            this.gbGrupo.Text = "Nuevo Grupo";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(285, 128);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(189, 128);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(411, 59);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(387, 50);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmCambioGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 176);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbGrupo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioGrupo";
            this.ShowInTaskbar = false;
            this.Text = "Cambiar Grupo de Manifiesto";
            ((System.ComponentModel.ISupportInitialize)(this.nudCaja)).EndInit();
            this.gbGrupo.ResumeLayout(false);
            this.gbGrupo.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxBusqueda cboGrupo;
        private System.Windows.Forms.NumericUpDown nudCaja;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.GroupBox gbGrupo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}