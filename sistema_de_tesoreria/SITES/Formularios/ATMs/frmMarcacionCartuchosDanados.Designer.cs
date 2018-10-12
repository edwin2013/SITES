namespace GUILayer
{
    partial class frmMarcacionCartuchosDanados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarcacionCartuchosDanados));
            this.gbCartucho = new System.Windows.Forms.GroupBox();
            this.cboEstado = new GUILayer.ComboBoxBusqueda();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clbFallas = new System.Windows.Forms.CheckedListBox();
            this.txtNumeroCartucho = new System.Windows.Forms.TextBox();
            this.txtEstadoActual = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbCartucho.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCartucho
            // 
            this.gbCartucho.Controls.Add(this.cboEstado);
            this.gbCartucho.Controls.Add(this.label2);
            this.gbCartucho.Controls.Add(this.label1);
            this.gbCartucho.Controls.Add(this.clbFallas);
            this.gbCartucho.Controls.Add(this.txtNumeroCartucho);
            this.gbCartucho.Controls.Add(this.txtEstadoActual);
            this.gbCartucho.Controls.Add(this.txtTipo);
            this.gbCartucho.Controls.Add(this.lblEstadoActual);
            this.gbCartucho.Controls.Add(this.lblTipo);
            this.gbCartucho.Controls.Add(this.btnBuscar);
            this.gbCartucho.Controls.Add(this.lblCodigo);
            this.gbCartucho.Location = new System.Drawing.Point(12, 53);
            this.gbCartucho.Name = "gbCartucho";
            this.gbCartucho.Size = new System.Drawing.Size(357, 178);
            this.gbCartucho.TabIndex = 1;
            this.gbCartucho.TabStop = false;
            this.gbCartucho.Text = "Datos del Cartucho";
            // 
            // cboEstado
            // 
            this.cboEstado.Busqueda = true;
            this.cboEstado.Enabled = false;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.ListaMostrada = null;
            this.cboEstado.Location = new System.Drawing.Point(59, 140);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(97, 21);
            this.cboEstado.TabIndex = 11;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nuevo Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fallas:";
            // 
            // clbFallas
            // 
            this.clbFallas.CheckOnClick = true;
            this.clbFallas.FormattingEnabled = true;
            this.clbFallas.Location = new System.Drawing.Point(193, 108);
            this.clbFallas.Name = "clbFallas";
            this.clbFallas.Size = new System.Drawing.Size(119, 64);
            this.clbFallas.TabIndex = 8;
            this.clbFallas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFallas_ItemCheck);
            this.clbFallas.SelectedIndexChanged += new System.EventHandler(this.clbFallas_SelectedIndexChanged);
            // 
            // txtNumeroCartucho
            // 
            this.txtNumeroCartucho.Location = new System.Drawing.Point(59, 20);
            this.txtNumeroCartucho.Name = "txtNumeroCartucho";
            this.txtNumeroCartucho.Size = new System.Drawing.Size(128, 20);
            this.txtNumeroCartucho.TabIndex = 7;
            // 
            // txtEstadoActual
            // 
            this.txtEstadoActual.Location = new System.Drawing.Point(59, 101);
            this.txtEstadoActual.Name = "txtEstadoActual";
            this.txtEstadoActual.ReadOnly = true;
            this.txtEstadoActual.Size = new System.Drawing.Size(97, 20);
            this.txtEstadoActual.TabIndex = 6;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(59, 46);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(97, 20);
            this.txtTipo.TabIndex = 4;
            // 
            // lblEstadoActual
            // 
            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.Location = new System.Drawing.Point(6, 85);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(76, 13);
            this.lblEstadoActual.TabIndex = 5;
            this.lblEstadoActual.Text = "Estado Actual:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(6, 53);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(193, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 23);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(47, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Número:";
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-1, -1);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(388, 48);
            this.pnlFondo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(300, 42);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(183, 240);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 40);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(279, 240);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 40);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmMarcacionCartuchosDanados
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(381, 292);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.gbCartucho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMarcacionCartuchosDanados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcación de Cartuchos Dañados";
            this.gbCartucho.ResumeLayout(false);
            this.gbCartucho.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCartucho;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtEstadoActual;
        private System.Windows.Forms.Label lblEstadoActual;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNumeroCartucho;
        private System.Windows.Forms.CheckedListBox clbFallas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTipo;
        private ComboBoxBusqueda cboEstado;
        private System.Windows.Forms.Label label2;
    }
}