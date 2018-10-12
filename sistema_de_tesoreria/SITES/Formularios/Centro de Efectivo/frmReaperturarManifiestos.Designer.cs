namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmReaperturarManifiestos
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
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCambioCodigoManifiesto = new System.Windows.Forms.GroupBox();
            this.txtCodigoManifiesto = new System.Windows.Forms.TextBox();
            this.lblCodigoManifiestoNuevo = new System.Windows.Forms.Label();
            this.gpopciones = new System.Windows.Forms.GroupBox();
            this.rdbEliminarManifiestoProecsado = new System.Windows.Forms.RadioButton();
            this.rdbReaperturarManifiesto = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbCambioCodigoManifiesto.SuspendLayout();
            this.gpopciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(5, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(437, 62);
            this.pnlFondo.TabIndex = 2;
            // 
            // pbLogo
            // 
            this.pbLogo.ErrorImage = null;
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo1;
            this.pbLogo.Location = new System.Drawing.Point(3, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(400, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gbCambioCodigoManifiesto
            // 
            this.gbCambioCodigoManifiesto.Controls.Add(this.txtCodigoManifiesto);
            this.gbCambioCodigoManifiesto.Controls.Add(this.lblCodigoManifiestoNuevo);
            this.gbCambioCodigoManifiesto.Location = new System.Drawing.Point(9, 142);
            this.gbCambioCodigoManifiesto.Name = "gbCambioCodigoManifiesto";
            this.gbCambioCodigoManifiesto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbCambioCodigoManifiesto.Size = new System.Drawing.Size(430, 65);
            this.gbCambioCodigoManifiesto.TabIndex = 16;
            this.gbCambioCodigoManifiesto.TabStop = false;
            this.gbCambioCodigoManifiesto.Text = "Digite el código de Manifiesto";
            // 
            // txtCodigoManifiesto
            // 
            this.txtCodigoManifiesto.BackColor = System.Drawing.Color.White;
            this.txtCodigoManifiesto.Location = new System.Drawing.Point(77, 27);
            this.txtCodigoManifiesto.Name = "txtCodigoManifiesto";
            this.txtCodigoManifiesto.Size = new System.Drawing.Size(324, 20);
            this.txtCodigoManifiesto.TabIndex = 1;
            this.txtCodigoManifiesto.TextChanged += new System.EventHandler(this.txtCodigoManifiesto_TextChanged);
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
            // gpopciones
            // 
            this.gpopciones.Controls.Add(this.rdbEliminarManifiestoProecsado);
            this.gpopciones.Controls.Add(this.rdbReaperturarManifiesto);
            this.gpopciones.Location = new System.Drawing.Point(9, 68);
            this.gpopciones.Name = "gpopciones";
            this.gpopciones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpopciones.Size = new System.Drawing.Size(430, 65);
            this.gpopciones.TabIndex = 17;
            this.gpopciones.TabStop = false;
            this.gpopciones.Text = "Seleccione la acción a ejecutar sobre el Manifiesto";
            // 
            // rdbEliminarManifiestoProecsado
            // 
            this.rdbEliminarManifiestoProecsado.AutoSize = true;
            this.rdbEliminarManifiestoProecsado.Location = new System.Drawing.Point(235, 31);
            this.rdbEliminarManifiestoProecsado.Name = "rdbEliminarManifiestoProecsado";
            this.rdbEliminarManifiestoProecsado.Size = new System.Drawing.Size(164, 17);
            this.rdbEliminarManifiestoProecsado.TabIndex = 1;
            this.rdbEliminarManifiestoProecsado.Text = "Eliminar manifiesto procesado";
            this.rdbEliminarManifiestoProecsado.UseVisualStyleBackColor = true;
            // 
            // rdbReaperturarManifiesto
            // 
            this.rdbReaperturarManifiesto.AutoSize = true;
            this.rdbReaperturarManifiesto.Checked = true;
            this.rdbReaperturarManifiesto.Location = new System.Drawing.Point(31, 31);
            this.rdbReaperturarManifiesto.Name = "rdbReaperturarManifiesto";
            this.rdbReaperturarManifiesto.Size = new System.Drawing.Size(185, 17);
            this.rdbReaperturarManifiesto.TabIndex = 0;
            this.rdbReaperturarManifiesto.TabStop = true;
            this.rdbReaperturarManifiesto.Text = "Reaperturar Manifiesto procesado";
            this.rdbReaperturarManifiesto.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(135, 213);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 18;
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
            this.btnCancelar.Location = new System.Drawing.Point(231, 213);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // frmReaperturarManifiestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 254);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gpopciones);
            this.Controls.Add(this.gbCambioCodigoManifiesto);
            this.Controls.Add(this.pnlFondo);
            this.Name = "frmReaperturarManifiestos";
            this.Text = "SITES - Reaperturar Manifiestos Procesados";
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbCambioCodigoManifiesto.ResumeLayout(false);
            this.gbCambioCodigoManifiesto.PerformLayout();
            this.gpopciones.ResumeLayout(false);
            this.gpopciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox gbCambioCodigoManifiesto;
        private System.Windows.Forms.TextBox txtCodigoManifiesto;
        private System.Windows.Forms.Label lblCodigoManifiestoNuevo;
        private System.Windows.Forms.GroupBox gpopciones;
        private System.Windows.Forms.RadioButton rdbEliminarManifiestoProecsado;
        private System.Windows.Forms.RadioButton rdbReaperturarManifiesto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider epError;
    }
}