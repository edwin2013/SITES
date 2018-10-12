namespace GUILayer.Formularios.Sucursales
{
    partial class frmRecepcionCargasSucursales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionCargasSucursales));
            this.tbRecepcion = new System.Windows.Forms.TabControl();
            this.tpPedidoBoveda = new System.Windows.Forms.TabPage();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroMarchamoTula = new System.Windows.Forms.TextBox();
            this.dgvManifiestoRecepcion = new System.Windows.Forms.DataGridView();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Punto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpEntregaBoveda = new System.Windows.Forms.TabPage();
            this.dgvCargasEntrega = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizarEntrega = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMarchamoTulados = new System.Windows.Forms.TextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.tbRecepcion.SuspendLayout();
            this.tpPedidoBoveda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestoRecepcion)).BeginInit();
            this.tpEntregaBoveda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRecepcion
            // 
            this.tbRecepcion.Controls.Add(this.tpPedidoBoveda);
            this.tbRecepcion.Controls.Add(this.tpEntregaBoveda);
            this.tbRecepcion.Location = new System.Drawing.Point(12, 75);
            this.tbRecepcion.Name = "tbRecepcion";
            this.tbRecepcion.SelectedIndex = 0;
            this.tbRecepcion.Size = new System.Drawing.Size(873, 444);
            this.tbRecepcion.TabIndex = 9;
            // 
            // tpPedidoBoveda
            // 
            this.tpPedidoBoveda.Controls.Add(this.btnActualizar);
            this.tpPedidoBoveda.Controls.Add(this.label2);
            this.tpPedidoBoveda.Controls.Add(this.txtNumeroMarchamoTula);
            this.tpPedidoBoveda.Controls.Add(this.dgvManifiestoRecepcion);
            this.tpPedidoBoveda.Location = new System.Drawing.Point(4, 22);
            this.tpPedidoBoveda.Name = "tpPedidoBoveda";
            this.tpPedidoBoveda.Padding = new System.Windows.Forms.Padding(3);
            this.tpPedidoBoveda.Size = new System.Drawing.Size(865, 418);
            this.tpPedidoBoveda.TabIndex = 0;
            this.tpPedidoBoveda.Text = "Pedido de Bóveda";
            this.tpPedidoBoveda.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(512, 37);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tula/Márchamo Adicional:";
            // 
            // txtNumeroMarchamoTula
            // 
            this.txtNumeroMarchamoTula.Location = new System.Drawing.Point(180, 48);
            this.txtNumeroMarchamoTula.Name = "txtNumeroMarchamoTula";
            this.txtNumeroMarchamoTula.Size = new System.Drawing.Size(291, 20);
            this.txtNumeroMarchamoTula.TabIndex = 4;
            // 
            // dgvManifiestoRecepcion
            // 
            this.dgvManifiestoRecepcion.AllowUserToAddRows = false;
            this.dgvManifiestoRecepcion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvManifiestoRecepcion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManifiestoRecepcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManifiestoRecepcion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManifiestoRecepcion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvManifiestoRecepcion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tula,
            this.Tipo,
            this.Punto,
            this.Hora,
            this.Colaborador});
            this.dgvManifiestoRecepcion.EnableHeadersVisualStyles = false;
            this.dgvManifiestoRecepcion.Location = new System.Drawing.Point(21, 103);
            this.dgvManifiestoRecepcion.Name = "dgvManifiestoRecepcion";
            this.dgvManifiestoRecepcion.ReadOnly = true;
            this.dgvManifiestoRecepcion.RowHeadersVisible = false;
            this.dgvManifiestoRecepcion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestoRecepcion.Size = new System.Drawing.Size(824, 292);
            this.dgvManifiestoRecepcion.TabIndex = 3;
            // 
            // Tula
            // 
            this.Tula.DataPropertyName = "Dato";
            this.Tula.HeaderText = "Tula o Márchamo";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            this.Tula.Width = 114;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "TipoCargas";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 52;
            // 
            // Punto
            // 
            this.Punto.DataPropertyName = "Nombre";
            this.Punto.HeaderText = "Punto de Entrega";
            this.Punto.Name = "Punto";
            this.Punto.ReadOnly = true;
            this.Punto.Width = 114;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "HoraRecibidoBoveda";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle2;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 54;
            // 
            // Colaborador
            // 
            this.Colaborador.DataPropertyName = "ColaboradorRecibidoBoveda";
            this.Colaborador.HeaderText = "Registrado";
            this.Colaborador.Name = "Colaborador";
            this.Colaborador.ReadOnly = true;
            this.Colaborador.Visible = false;
            this.Colaborador.Width = 82;
            // 
            // tpEntregaBoveda
            // 
            this.tpEntregaBoveda.Controls.Add(this.dgvCargasEntrega);
            this.tpEntregaBoveda.Controls.Add(this.btnActualizarEntrega);
            this.tpEntregaBoveda.Controls.Add(this.label1);
            this.tpEntregaBoveda.Controls.Add(this.txtMarchamoTulados);
            this.tpEntregaBoveda.Location = new System.Drawing.Point(4, 22);
            this.tpEntregaBoveda.Name = "tpEntregaBoveda";
            this.tpEntregaBoveda.Padding = new System.Windows.Forms.Padding(3);
            this.tpEntregaBoveda.Size = new System.Drawing.Size(865, 418);
            this.tpEntregaBoveda.TabIndex = 1;
            this.tpEntregaBoveda.Text = "Entrega a Bóveda";
            this.tpEntregaBoveda.UseVisualStyleBackColor = true;
            // 
            // dgvCargasEntrega
            // 
            this.dgvCargasEntrega.AllowUserToAddRows = false;
            this.dgvCargasEntrega.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCargasEntrega.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCargasEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargasEntrega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCargasEntrega.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargasEntrega.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvCargasEntrega.EnableHeadersVisualStyles = false;
            this.dgvCargasEntrega.Location = new System.Drawing.Point(21, 102);
            this.dgvCargasEntrega.Name = "dgvCargasEntrega";
            this.dgvCargasEntrega.ReadOnly = true;
            this.dgvCargasEntrega.RowHeadersVisible = false;
            this.dgvCargasEntrega.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargasEntrega.Size = new System.Drawing.Size(824, 292);
            this.dgvCargasEntrega.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Dato";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tula o Márchamo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 114;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TipoCargas";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 52;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn3.HeaderText = "Punto de Entrega";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 114;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "HoraRecibidoBoveda";
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "Hora";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 54;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ColaboradorRecibidoBoveda";
            this.dataGridViewTextBoxColumn5.HeaderText = "Registrado";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 82;
            // 
            // btnActualizarEntrega
            // 
            this.btnActualizarEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarEntrega.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizarEntrega.Enabled = false;
            this.btnActualizarEntrega.FlatAppearance.BorderSize = 2;
            this.btnActualizarEntrega.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizarEntrega.Location = new System.Drawing.Point(520, 37);
            this.btnActualizarEntrega.Name = "btnActualizarEntrega";
            this.btnActualizarEntrega.Size = new System.Drawing.Size(93, 40);
            this.btnActualizarEntrega.TabIndex = 4;
            this.btnActualizarEntrega.Text = "Actualizar";
            this.btnActualizarEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarEntrega.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tula/Márchamo Adicional:";
            // 
            // txtMarchamoTulados
            // 
            this.txtMarchamoTulados.Location = new System.Drawing.Point(165, 48);
            this.txtMarchamoTulados.Name = "txtMarchamoTulados";
            this.txtMarchamoTulados.Size = new System.Drawing.Size(291, 20);
            this.txtMarchamoTulados.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(390, 44);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(791, 539);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 45);
            this.btnSalir.TabIndex = 10;
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
            this.pnlFondo.Location = new System.Drawing.Point(0, 7);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(896, 50);
            this.pnlFondo.TabIndex = 11;
            // 
            // frmRecepcionCargasSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 591);
            this.Controls.Add(this.tbRecepcion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecepcionCargasSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepcicón Cargas Sucursales";
            this.tbRecepcion.ResumeLayout(false);
            this.tpPedidoBoveda.ResumeLayout(false);
            this.tpPedidoBoveda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestoRecepcion)).EndInit();
            this.tpEntregaBoveda.ResumeLayout(false);
            this.tpEntregaBoveda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargasEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbRecepcion;
        private System.Windows.Forms.TabPage tpPedidoBoveda;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroMarchamoTula;
        private System.Windows.Forms.DataGridView dgvManifiestoRecepcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Punto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colaborador;
        private System.Windows.Forms.TabPage tpEntregaBoveda;
        private System.Windows.Forms.DataGridView dgvCargasEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnActualizarEntrega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarchamoTulados;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlFondo;
    }
}