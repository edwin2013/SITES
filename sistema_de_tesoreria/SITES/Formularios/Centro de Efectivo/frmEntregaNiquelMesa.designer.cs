namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmEntregaNiquelMesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaNiquelMesa));
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lbldFecha = new System.Windows.Forms.Label();
            this.lbldHora = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lbldCode = new System.Windows.Forms.Label();
            this.lbldCajero = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldNiquel = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
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
            this.pnlFondo.Location = new System.Drawing.Point(3, 5);
            this.pnlFondo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1195, 73);
            this.pnlFondo.TabIndex = 41;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(3, 1);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(638, 70);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(72, 140);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(55, 16);
            this.lblFecha.TabIndex = 42;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(462, 138);
            this.lblHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(46, 16);
            this.lblHora.TabIndex = 43;
            this.lblHora.Text = "Hora:";
            // 
            // lbldFecha
            // 
            this.lbldFecha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldFecha.Location = new System.Drawing.Point(143, 140);
            this.lbldFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldFecha.Name = "lbldFecha";
            this.lbldFecha.Size = new System.Drawing.Size(310, 28);
            this.lbldFecha.TabIndex = 44;
            // 
            // lbldHora
            // 
            this.lbldHora.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldHora.Location = new System.Drawing.Point(521, 137);
            this.lbldHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldHora.Name = "lbldHora";
            this.lbldHora.Size = new System.Drawing.Size(310, 28);
            this.lbldHora.TabIndex = 45;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(9, 93);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(120, 16);
            this.lblCode.TabIndex = 46;
            this.lblCode.Text = "Código Entrega:";
            // 
            // lbldCode
            // 
            this.lbldCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldCode.Location = new System.Drawing.Point(143, 92);
            this.lbldCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldCode.Name = "lbldCode";
            this.lbldCode.Size = new System.Drawing.Size(688, 28);
            this.lbldCode.TabIndex = 47;
            // 
            // lbldCajero
            // 
            this.lbldCajero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldCajero.Location = new System.Drawing.Point(143, 199);
            this.lbldCajero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldCajero.Name = "lbldCajero";
            this.lbldCajero.Size = new System.Drawing.Size(688, 28);
            this.lbldCajero.TabIndex = 48;
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajero.Location = new System.Drawing.Point(72, 200);
            this.lblCajero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(58, 16);
            this.lblCajero.TabIndex = 49;
            this.lblCajero.Text = "Cajero:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 258);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Total Niquel:";
            // 
            // lbldNiquel
            // 
            this.lbldNiquel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldNiquel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldNiquel.Location = new System.Drawing.Point(143, 258);
            this.lbldNiquel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldNiquel.Name = "lbldNiquel";
            this.lbldNiquel.Size = new System.Drawing.Size(688, 28);
            this.lbldNiquel.TabIndex = 51;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(352, 314);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(101, 47);
            this.btnAceptar.TabIndex = 52;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(507, 314);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 47);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmEntregaNiquelMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 376);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lbldNiquel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.lbldCajero);
            this.Controls.Add(this.lbldCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lbldHora);
            this.Controls.Add(this.lbldFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.pnlFondo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmEntregaNiquelMesa";
            this.Text = "SITES - Entrega de Niquel En Mesa";
            this.Load += new System.EventHandler(this.frmEntregaNiquelMesa_Load);
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lbldFecha;
        private System.Windows.Forms.Label lbldHora;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lbldCode;
        private System.Windows.Forms.Label lbldCajero;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldNiquel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}