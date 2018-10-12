namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmCargaInformacionTransportadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaInformacionTransportadora));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnAceptarInconsistencias = new System.Windows.Forms.Button();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvDepositos = new System.Windows.Forms.DataGridView();
            this.gbArchivo = new System.Windows.Forms.GroupBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvInconsistencias = new System.Windows.Forms.DataGridView();
            this.btnAgregarDepositos = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ofdDepositos = new System.Windows.Forms.OpenFileDialog();
            this.ofdInconsistencias = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).BeginInit();
            this.gbArchivo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInconsistencias)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(0, -1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1009, 60);
            this.pnlFondo.TabIndex = 1;
            // 
            // btnAceptarInconsistencias
            // 
            this.btnAceptarInconsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarInconsistencias.Enabled = false;
            this.btnAceptarInconsistencias.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptarInconsistencias.Location = new System.Drawing.Point(896, 541);
            this.btnAceptarInconsistencias.Name = "btnAceptarInconsistencias";
            this.btnAceptarInconsistencias.Size = new System.Drawing.Size(90, 40);
            this.btnAceptarInconsistencias.TabIndex = 10;
            this.btnAceptarInconsistencias.Text = "Aceptar";
            this.btnAceptarInconsistencias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptarInconsistencias.UseVisualStyleBackColor = true;
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvDepositos);
            this.gbCargas.Location = new System.Drawing.Point(17, 116);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(975, 173);
            this.gbCargas.TabIndex = 8;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Depósitos";
            // 
            // dgvDepositos
            // 
            this.dgvDepositos.AllowUserToAddRows = false;
            this.dgvDepositos.AllowUserToDeleteRows = false;
            this.dgvDepositos.AllowUserToOrderColumns = true;
            this.dgvDepositos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDepositos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepositos.EnableHeadersVisualStyles = false;
            this.dgvDepositos.GridColor = System.Drawing.Color.Black;
            this.dgvDepositos.Location = new System.Drawing.Point(6, 19);
            this.dgvDepositos.MultiSelect = false;
            this.dgvDepositos.Name = "dgvDepositos";
            this.dgvDepositos.ReadOnly = true;
            this.dgvDepositos.RowHeadersVisible = false;
            this.dgvDepositos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDepositos.Size = new System.Drawing.Size(963, 148);
            this.dgvDepositos.StandardTab = true;
            this.dgvDepositos.TabIndex = 0;
            // 
            // gbArchivo
            // 
            this.gbArchivo.Controls.Add(this.btnAbrir);
            this.gbArchivo.Controls.Add(this.txtArchivo);
            this.gbArchivo.Location = new System.Drawing.Point(18, 63);
            this.gbArchivo.Name = "gbArchivo";
            this.gbArchivo.Size = new System.Drawing.Size(435, 46);
            this.gbArchivo.TabIndex = 6;
            this.gbArchivo.TabStop = false;
            this.gbArchivo.Text = "Archivo Depósitos";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(360, 19);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(45, 20);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "...";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(6, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(348, 20);
            this.txtArchivo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvInconsistencias);
            this.groupBox1.Location = new System.Drawing.Point(17, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(975, 178);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Inconsistencias";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvInconsistencias
            // 
            this.dgvInconsistencias.AllowUserToAddRows = false;
            this.dgvInconsistencias.AllowUserToDeleteRows = false;
            this.dgvInconsistencias.AllowUserToOrderColumns = true;
            this.dgvInconsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInconsistencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInconsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInconsistencias.EnableHeadersVisualStyles = false;
            this.dgvInconsistencias.GridColor = System.Drawing.Color.Black;
            this.dgvInconsistencias.Location = new System.Drawing.Point(6, 19);
            this.dgvInconsistencias.MultiSelect = false;
            this.dgvInconsistencias.Name = "dgvInconsistencias";
            this.dgvInconsistencias.ReadOnly = true;
            this.dgvInconsistencias.RowHeadersVisible = false;
            this.dgvInconsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInconsistencias.Size = new System.Drawing.Size(963, 153);
            this.dgvInconsistencias.StandardTab = true;
            this.dgvInconsistencias.TabIndex = 0;
            // 
            // btnAgregarDepositos
            // 
            this.btnAgregarDepositos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarDepositos.Enabled = false;
            this.btnAgregarDepositos.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAgregarDepositos.Location = new System.Drawing.Point(897, 298);
            this.btnAgregarDepositos.Name = "btnAgregarDepositos";
            this.btnAgregarDepositos.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarDepositos.TabIndex = 13;
            this.btnAgregarDepositos.Text = "Aceptar";
            this.btnAgregarDepositos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarDepositos.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(348, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(18, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 46);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archivo Inconsistencias";
            // 
            // ofdInconsistencias
            // 
            this.ofdInconsistencias.FileName = "openFileDialog1";
            // 
            // frmCargaInformacionTransportadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 586);
            this.Controls.Add(this.btnAgregarDepositos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAceptarInconsistencias);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.gbArchivo);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargaInformacionTransportadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga de Información Transportadora";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).EndInit();
            this.gbArchivo.ResumeLayout(false);
            this.gbArchivo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInconsistencias)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnAceptarInconsistencias;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvDepositos;
        private System.Windows.Forms.GroupBox gbArchivo;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvInconsistencias;
        private System.Windows.Forms.Button btnAgregarDepositos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog ofdDepositos;
        private System.Windows.Forms.OpenFileDialog ofdInconsistencias;
    }
}