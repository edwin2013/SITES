namespace GUILayer
{
    partial class frmSeleccionReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionReporte));
            this.tcCategorias = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.gbListaReportes = new System.Windows.Forms.GroupBox();
            this.lstReportes = new System.Windows.Forms.ListView();
            this.gbDescripcion = new System.Windows.Forms.GroupBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tcCategorias.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.pnlLista.SuspendLayout();
            this.gbListaReportes.SuspendLayout();
            this.gbDescripcion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tcCategorias
            // 
            this.tcCategorias.Controls.Add(this.tpGeneral);
            this.tcCategorias.Location = new System.Drawing.Point(12, 63);
            this.tcCategorias.Name = "tcCategorias";
            this.tcCategorias.RightToLeftLayout = true;
            this.tcCategorias.SelectedIndex = 0;
            this.tcCategorias.Size = new System.Drawing.Size(591, 367);
            this.tcCategorias.TabIndex = 1;
            this.tcCategorias.SelectedIndexChanged += new System.EventHandler(this.tcCategorias_SelectedIndexChanged);
            // 
            // tpGeneral
            // 
            this.tpGeneral.BackColor = System.Drawing.Color.White;
            this.tpGeneral.Controls.Add(this.pnlLista);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(583, 341);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "No Existen Reportes Registrados";
            // 
            // pnlLista
            // 
            this.pnlLista.Controls.Add(this.gbListaReportes);
            this.pnlLista.Controls.Add(this.gbDescripcion);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(3, 3);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(577, 335);
            this.pnlLista.TabIndex = 0;
            // 
            // gbListaReportes
            // 
            this.gbListaReportes.Controls.Add(this.lstReportes);
            this.gbListaReportes.Location = new System.Drawing.Point(3, 0);
            this.gbListaReportes.Name = "gbListaReportes";
            this.gbListaReportes.Size = new System.Drawing.Size(302, 332);
            this.gbListaReportes.TabIndex = 0;
            this.gbListaReportes.TabStop = false;
            this.gbListaReportes.Text = "Lista de Reportes";
            // 
            // lstReportes
            // 
            this.lstReportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstReportes.HideSelection = false;
            this.lstReportes.Location = new System.Drawing.Point(6, 19);
            this.lstReportes.MultiSelect = false;
            this.lstReportes.Name = "lstReportes";
            this.lstReportes.Size = new System.Drawing.Size(290, 307);
            this.lstReportes.TabIndex = 0;
            this.lstReportes.UseCompatibleStateImageBehavior = false;
            this.lstReportes.View = System.Windows.Forms.View.List;
            this.lstReportes.SelectedIndexChanged += new System.EventHandler(this.lstReportes_SelectedIndexChanged);
            this.lstReportes.DoubleClick += new System.EventHandler(this.lstReportes_DoubleClick);
            // 
            // gbDescripcion
            // 
            this.gbDescripcion.Controls.Add(this.lblDescripcion);
            this.gbDescripcion.Location = new System.Drawing.Point(311, 0);
            this.gbDescripcion.Name = "gbDescripcion";
            this.gbDescripcion.Size = new System.Drawing.Size(263, 148);
            this.gbDescripcion.TabIndex = 1;
            this.gbDescripcion.TabStop = false;
            this.gbDescripcion.Text = "Descripción";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(6, 17);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(251, 125);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "No hay reportes registrados en el sistema";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(637, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.BackColor = System.Drawing.Color.White;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 8;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(502, 432);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(406, 432);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmSeleccionReporte
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(611, 482);
            this.Controls.Add(this.tcCategorias);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeleccionReporte";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección del Reporte";
            this.Load += new System.EventHandler(this.frmSeleccionReporte_Load);
            this.tcCategorias.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.pnlLista.ResumeLayout(false);
            this.gbListaReportes.ResumeLayout(false);
            this.gbDescripcion.ResumeLayout(false);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcCategorias;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.GroupBox gbListaReportes;
        private System.Windows.Forms.ListView lstReportes;
        private System.Windows.Forms.GroupBox gbDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}