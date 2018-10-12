namespace GUILayer.Formularios.Optimización
{
    partial class frmAgregarCartuchoCargaTransportadora
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarCartuchoCargaTransportadora));
            this.gbDeonominacion = new System.Windows.Forms.GroupBox();
            this.cboDenominacion = new GUILayer.ComboBoxBusqueda();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAgregarCartucho = new System.Windows.Forms.Button();
            this.gbDeonominacion.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDeonominacion
            // 
            this.gbDeonominacion.Controls.Add(this.cboDenominacion);
            this.gbDeonominacion.Controls.Add(this.lblProvincia);
            this.gbDeonominacion.Controls.Add(this.txtNombre);
            this.gbDeonominacion.Controls.Add(this.lblNombre);
            this.gbDeonominacion.Location = new System.Drawing.Point(0, 55);
            this.gbDeonominacion.Name = "gbDeonominacion";
            this.gbDeonominacion.Size = new System.Drawing.Size(317, 93);
            this.gbDeonominacion.TabIndex = 11;
            this.gbDeonominacion.TabStop = false;
            this.gbDeonominacion.Text = "Montos";
            // 
            // cboDenominacion
            // 
            this.cboDenominacion.Busqueda = true;
            this.cboDenominacion.ListaMostrada = null;
            this.cboDenominacion.Location = new System.Drawing.Point(90, 45);
            this.cboDenominacion.Name = "cboDenominacion";
            this.cboDenominacion.Size = new System.Drawing.Size(221, 21);
            this.cboDenominacion.TabIndex = 3;
            this.cboDenominacion.SelectedIndexChanged += new System.EventHandler(this.cboDenominacion_SelectedIndexChanged);
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(6, 49);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(78, 13);
            this.lblProvincia.TabIndex = 2;
            this.lblProvincia.Text = "Denominación:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(90, 19);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(221, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(13, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(40, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Monto:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-15, 6);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(359, 43);
            this.pnlFondo.TabIndex = 10;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(319, 39);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(227, 163);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregarCartucho
            // 
            this.btnAgregarCartucho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCartucho.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnAgregarCartucho.Location = new System.Drawing.Point(130, 163);
            this.btnAgregarCartucho.Name = "btnAgregarCartucho";
            this.btnAgregarCartucho.Size = new System.Drawing.Size(90, 40);
            this.btnAgregarCartucho.TabIndex = 9;
            this.btnAgregarCartucho.Text = "Agregar";
            this.btnAgregarCartucho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarCartucho.UseVisualStyleBackColor = true;
            this.btnAgregarCartucho.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmAgregarCartuchoCargaTransportadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 208);
            this.Controls.Add(this.gbDeonominacion);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregarCartucho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgregarCartuchoCargaTransportadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Monto Transportadora";
            this.gbDeonominacion.ResumeLayout(false);
            this.gbDeonominacion.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDeonominacion;
        private ComboBoxBusqueda cboDenominacion;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregarCartucho;
    }
}