namespace GUILayer
{
    partial class frmAsignarTripulacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarTripulacion));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.nudRutas = new System.Windows.Forms.NumericUpDown();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.gbColaboradores = new System.Windows.Forms.GroupBox();
            this.gbCustodio = new System.Windows.Forms.GroupBox();
            this.clbCustodios = new System.Windows.Forms.CheckedListBox();
            this.gbPortavalor = new System.Windows.Forms.GroupBox();
            this.clbPortavalores = new System.Windows.Forms.CheckedListBox();
            this.gbChofer = new System.Windows.Forms.GroupBox();
            this.clbChoferes = new System.Windows.Forms.CheckedListBox();
            this.gbSeleccion = new System.Windows.Forms.GroupBox();
            this.lblPortavalor = new System.Windows.Forms.Label();
            this.lblCustodio = new System.Windows.Forms.Label();
            this.lblChofer = new System.Windows.Forms.Label();
            this.txtPortavalor = new System.Windows.Forms.TextBox();
            this.txtCustodio = new System.Windows.Forms.TextBox();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRutas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbColaboradores.SuspendLayout();
            this.gbCustodio.SuspendLayout();
            this.gbPortavalor.SuspendLayout();
            this.gbChofer.SuspendLayout();
            this.gbSeleccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblRuta);
            this.gbDatos.Controls.Add(this.nudRutas);
            this.gbDatos.Location = new System.Drawing.Point(22, 66);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(343, 107);
            this.gbDatos.TabIndex = 10;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Tripulación";
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(24, 45);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(83, 13);
            this.lblRuta.TabIndex = 3;
            this.lblRuta.Text = "Cantidad Rutas:";
            // 
            // nudRutas
            // 
            this.nudRutas.Location = new System.Drawing.Point(120, 38);
            this.nudRutas.Name = "nudRutas";
            this.nudRutas.Size = new System.Drawing.Size(120, 20);
            this.nudRutas.TabIndex = 2;
            this.nudRutas.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(683, 617);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(1, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(792, 60);
            this.pnlFondo.TabIndex = 9;
            // 
            // btnGenerar
            // 
            this.btnGenerar.FlatAppearance.BorderSize = 2;
            this.btnGenerar.Image = global::GUILayer.Properties.Resources.asignacion;
            this.btnGenerar.Location = new System.Drawing.Point(587, 617);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(90, 40);
            this.btnGenerar.TabIndex = 15;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbColaboradores
            // 
            this.gbColaboradores.Controls.Add(this.gbCustodio);
            this.gbColaboradores.Controls.Add(this.gbPortavalor);
            this.gbColaboradores.Controls.Add(this.gbChofer);
            this.gbColaboradores.Location = new System.Drawing.Point(22, 179);
            this.gbColaboradores.Name = "gbColaboradores";
            this.gbColaboradores.Size = new System.Drawing.Size(751, 431);
            this.gbColaboradores.TabIndex = 18;
            this.gbColaboradores.TabStop = false;
            this.gbColaboradores.Text = "Colaboradores";
            // 
            // gbCustodio
            // 
            this.gbCustodio.Controls.Add(this.clbCustodios);
            this.gbCustodio.Location = new System.Drawing.Point(219, 229);
            this.gbCustodio.Name = "gbCustodio";
            this.gbCustodio.Size = new System.Drawing.Size(340, 196);
            this.gbCustodio.TabIndex = 2;
            this.gbCustodio.TabStop = false;
            this.gbCustodio.Text = "Custodio:";
            // 
            // clbCustodios
            // 
            this.clbCustodios.CheckOnClick = true;
            this.clbCustodios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbCustodios.FormattingEnabled = true;
            this.clbCustodios.Location = new System.Drawing.Point(3, 16);
            this.clbCustodios.Name = "clbCustodios";
            this.clbCustodios.Size = new System.Drawing.Size(334, 177);
            this.clbCustodios.TabIndex = 0;
            this.clbCustodios.SelectedIndexChanged += new System.EventHandler(this.clbCustodios_SelectedIndexChanged);
            // 
            // gbPortavalor
            // 
            this.gbPortavalor.Controls.Add(this.clbPortavalores);
            this.gbPortavalor.Location = new System.Drawing.Point(384, 32);
            this.gbPortavalor.Name = "gbPortavalor";
            this.gbPortavalor.Size = new System.Drawing.Size(352, 191);
            this.gbPortavalor.TabIndex = 1;
            this.gbPortavalor.TabStop = false;
            this.gbPortavalor.Text = "Portavalor";
            // 
            // clbPortavalores
            // 
            this.clbPortavalores.CheckOnClick = true;
            this.clbPortavalores.FormattingEnabled = true;
            this.clbPortavalores.Location = new System.Drawing.Point(16, 19);
            this.clbPortavalores.Name = "clbPortavalores";
            this.clbPortavalores.Size = new System.Drawing.Size(315, 169);
            this.clbPortavalores.TabIndex = 0;
            this.clbPortavalores.SelectedIndexChanged += new System.EventHandler(this.clbPortavalores_SelectedIndexChanged);
            // 
            // gbChofer
            // 
            this.gbChofer.Controls.Add(this.clbChoferes);
            this.gbChofer.Location = new System.Drawing.Point(9, 32);
            this.gbChofer.Name = "gbChofer";
            this.gbChofer.Size = new System.Drawing.Size(356, 191);
            this.gbChofer.TabIndex = 0;
            this.gbChofer.TabStop = false;
            this.gbChofer.Text = "Chofer";
            // 
            // clbChoferes
            // 
            this.clbChoferes.FormattingEnabled = true;
            this.clbChoferes.Location = new System.Drawing.Point(6, 19);
            this.clbChoferes.Name = "clbChoferes";
            this.clbChoferes.Size = new System.Drawing.Size(344, 169);
            this.clbChoferes.TabIndex = 0;
            this.clbChoferes.ThreeDCheckBoxes = true;
            this.clbChoferes.SelectedIndexChanged += new System.EventHandler(this.clbChoferes_SelectedIndexChanged);
            // 
            // gbSeleccion
            // 
            this.gbSeleccion.Controls.Add(this.lblPortavalor);
            this.gbSeleccion.Controls.Add(this.lblCustodio);
            this.gbSeleccion.Controls.Add(this.lblChofer);
            this.gbSeleccion.Controls.Add(this.txtPortavalor);
            this.gbSeleccion.Controls.Add(this.txtCustodio);
            this.gbSeleccion.Controls.Add(this.txtChofer);
            this.gbSeleccion.Location = new System.Drawing.Point(388, 66);
            this.gbSeleccion.Name = "gbSeleccion";
            this.gbSeleccion.Size = new System.Drawing.Size(401, 107);
            this.gbSeleccion.TabIndex = 23;
            this.gbSeleccion.TabStop = false;
            this.gbSeleccion.Text = "Tripulación Asignada";
            this.gbSeleccion.Visible = false;
            // 
            // lblPortavalor
            // 
            this.lblPortavalor.AutoSize = true;
            this.lblPortavalor.Location = new System.Drawing.Point(31, 81);
            this.lblPortavalor.Name = "lblPortavalor";
            this.lblPortavalor.Size = new System.Drawing.Size(58, 13);
            this.lblPortavalor.TabIndex = 27;
            this.lblPortavalor.Text = "Portavalor:";
            // 
            // lblCustodio
            // 
            this.lblCustodio.AutoSize = true;
            this.lblCustodio.Location = new System.Drawing.Point(31, 55);
            this.lblCustodio.Name = "lblCustodio";
            this.lblCustodio.Size = new System.Drawing.Size(51, 13);
            this.lblCustodio.TabIndex = 26;
            this.lblCustodio.Text = "Custodio:";
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(31, 29);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(41, 13);
            this.lblChofer.TabIndex = 25;
            this.lblChofer.Text = "Chofer:";
            // 
            // txtPortavalor
            // 
            this.txtPortavalor.Enabled = false;
            this.txtPortavalor.Location = new System.Drawing.Point(152, 74);
            this.txtPortavalor.Name = "txtPortavalor";
            this.txtPortavalor.Size = new System.Drawing.Size(218, 20);
            this.txtPortavalor.TabIndex = 24;
            // 
            // txtCustodio
            // 
            this.txtCustodio.Enabled = false;
            this.txtCustodio.Location = new System.Drawing.Point(152, 48);
            this.txtCustodio.Name = "txtCustodio";
            this.txtCustodio.Size = new System.Drawing.Size(218, 20);
            this.txtCustodio.TabIndex = 23;
            // 
            // txtChofer
            // 
            this.txtChofer.Enabled = false;
            this.txtChofer.Location = new System.Drawing.Point(151, 22);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.Size = new System.Drawing.Size(218, 20);
            this.txtChofer.TabIndex = 22;
            // 
            // frmAsignarTripulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 669);
            this.Controls.Add(this.gbSeleccion);
            this.Controls.Add(this.gbColaboradores);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAsignarTripulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Tripulación";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRutas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbColaboradores.ResumeLayout(false);
            this.gbCustodio.ResumeLayout(false);
            this.gbPortavalor.ResumeLayout(false);
            this.gbChofer.ResumeLayout(false);
            this.gbSeleccion.ResumeLayout(false);
            this.gbSeleccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox gbColaboradores;
        private System.Windows.Forms.GroupBox gbCustodio;
        private System.Windows.Forms.CheckedListBox clbCustodios;
        private System.Windows.Forms.GroupBox gbPortavalor;
        private System.Windows.Forms.CheckedListBox clbPortavalores;
        private System.Windows.Forms.GroupBox gbChofer;
        private System.Windows.Forms.CheckedListBox clbChoferes;
        private System.Windows.Forms.GroupBox gbSeleccion;
        private System.Windows.Forms.Label lblPortavalor;
        private System.Windows.Forms.Label lblCustodio;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.TextBox txtPortavalor;
        private System.Windows.Forms.TextBox txtCustodio;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.NumericUpDown nudRutas;
    }
}