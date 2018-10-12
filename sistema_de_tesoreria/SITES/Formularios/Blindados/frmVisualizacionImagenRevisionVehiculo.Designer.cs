namespace GUILayer.Formularios.Blindados
{
    partial class frmVisualizacionImagenRevisionVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizacionImagenRevisionVehiculo));
            this.pbFotoVehiculo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoVehiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFotoVehiculo
            // 
            this.pbFotoVehiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFotoVehiculo.Location = new System.Drawing.Point(12, 12);
            this.pbFotoVehiculo.Name = "pbFotoVehiculo";
            this.pbFotoVehiculo.Size = new System.Drawing.Size(497, 490);
            this.pbFotoVehiculo.TabIndex = 0;
            this.pbFotoVehiculo.TabStop = false;
            this.pbFotoVehiculo.Click += new System.EventHandler(this.pbFotoVehiculo_Click);
            // 
            // frmVisualizacionImagenRevisionVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 514);
            this.Controls.Add(this.pbFotoVehiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisualizacionImagenRevisionVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar Imagen ";
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoVehiculo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFotoVehiculo;
    }
}