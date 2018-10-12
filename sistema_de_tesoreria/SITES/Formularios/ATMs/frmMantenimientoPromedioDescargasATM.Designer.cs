namespace GUILayer.Formularios.Mantenimiento
{
    partial class frmMantenimientoPromedioDescargasATM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoPromedioDescargasATM));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.lblMonto = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.lblATM = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.ofdMontosCargas = new System.Windows.Forms.OpenFileDialog();
            this.btnImportar = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cboATM = new GUILayer.ComboBoxBusqueda();
            this.pnlFondo.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-16, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(613, 60);
            this.pnlFondo.TabIndex = 4;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(145, 49);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 0;
            this.lblMonto.Text = "Monto:";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.nudMonto);
            this.gbDatos.Controls.Add(this.cboATM);
            this.gbDatos.Controls.Add(this.lblATM);
            this.gbDatos.Controls.Add(this.lblMonto);
            this.gbDatos.Location = new System.Drawing.Point(12, 70);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(553, 85);
            this.gbDatos.TabIndex = 5;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de los Promedios";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Location = new System.Drawing.Point(199, 46);
            this.nudMonto.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(227, 20);
            this.nudMonto.TabIndex = 4;
            // 
            // lblATM
            // 
            this.lblATM.AutoSize = true;
            this.lblATM.Location = new System.Drawing.Point(145, 22);
            this.lblATM.Name = "lblATM";
            this.lblATM.Size = new System.Drawing.Size(33, 13);
            this.lblATM.TabIndex = 2;
            this.lblATM.Text = "ATM:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImportar);
            this.groupBox2.Controls.Add(this.lblArchivo);
            this.groupBox2.Controls.Add(this.btnAbrir);
            this.groupBox2.Controls.Add(this.txtArchivo);
            this.groupBox2.Location = new System.Drawing.Point(12, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 76);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Importar";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(21, 38);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(46, 13);
            this.lblArchivo.TabIndex = 23;
            this.lblArchivo.Text = "Archivo:";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(368, 35);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(45, 20);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "...";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(73, 35);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(289, 20);
            this.txtArchivo.TabIndex = 2;
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportar.Image = global::GUILayer.Properties.Resources.importar_triales;
            this.btnImportar.Location = new System.Drawing.Point(441, 22);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(90, 40);
            this.btnImportar.TabIndex = 24;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(401, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.Image = global::GUILayer.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(379, 243);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(475, 243);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cboATM
            // 
            this.cboATM.Busqueda = true;
            this.cboATM.FormattingEnabled = true;
            this.cboATM.ListaMostrada = null;
            this.cboATM.Location = new System.Drawing.Point(199, 19);
            this.cboATM.Name = "cboATM";
            this.cboATM.Size = new System.Drawing.Size(227, 21);
            this.cboATM.TabIndex = 3;
            // 
            // frmMantenimientoPromedioDescargasATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 292);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMantenimientoPromedioDescargasATM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de Promedio de Descargas";
            this.pnlFondo.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblATM;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private ComboBoxBusqueda cboATM;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.OpenFileDialog ofdMontosCargas;
    }
}