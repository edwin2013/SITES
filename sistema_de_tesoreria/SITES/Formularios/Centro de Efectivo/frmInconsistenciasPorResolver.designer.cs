namespace GUILayer.Formularios.Centro_de_Efectivo
{
    partial class frmInconsistenciasPorResolver
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInconsistenciasPorResolver));
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboEstadoInconsistencia = new System.Windows.Forms.ComboBox();
            this.lblEstadoInconsistencia = new System.Windows.Forms.Label();
            this.gbfiltro = new System.Windows.Forms.GroupBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.dgvInconsistencias = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manifiesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Camara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoInconsistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnResolver = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpleyenda = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pcbinfo = new System.Windows.Forms.PictureBox();
            this.pcbdiferencia = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblinfodiferencia = new System.Windows.Forms.Label();
            this.cboCliente = new GUILayer.ComboBoxBusqueda();
            this.gbfiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInconsistencias)).BeginInit();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.grpleyenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbdiferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(20, 24);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 14;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboEstadoInconsistencia
            // 
            this.cboEstadoInconsistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoInconsistencia.FormattingEnabled = true;
            this.cboEstadoInconsistencia.Items.AddRange(new object[] {
            "Pendiente",
            "Resuelta"});
            this.cboEstadoInconsistencia.Location = new System.Drawing.Point(481, 19);
            this.cboEstadoInconsistencia.Name = "cboEstadoInconsistencia";
            this.cboEstadoInconsistencia.Size = new System.Drawing.Size(280, 21);
            this.cboEstadoInconsistencia.TabIndex = 29;
            this.cboEstadoInconsistencia.SelectedIndexChanged += new System.EventHandler(this.cboEstadoInconsistencia_SelectedIndexChanged);
            // 
            // lblEstadoInconsistencia
            // 
            this.lblEstadoInconsistencia.AutoSize = true;
            this.lblEstadoInconsistencia.Location = new System.Drawing.Point(356, 20);
            this.lblEstadoInconsistencia.Name = "lblEstadoInconsistencia";
            this.lblEstadoInconsistencia.Size = new System.Drawing.Size(119, 13);
            this.lblEstadoInconsistencia.TabIndex = 28;
            this.lblEstadoInconsistencia.Text = "Estado Inconsistencias:";
            // 
            // gbfiltro
            // 
            this.gbfiltro.Controls.Add(this.btnVer);
            this.gbfiltro.Controls.Add(this.cboEstadoInconsistencia);
            this.gbfiltro.Controls.Add(this.lblCliente);
            this.gbfiltro.Controls.Add(this.lblEstadoInconsistencia);
            this.gbfiltro.Controls.Add(this.cboCliente);
            this.gbfiltro.Location = new System.Drawing.Point(3, 69);
            this.gbfiltro.Name = "gbfiltro";
            this.gbfiltro.Size = new System.Drawing.Size(897, 61);
            this.gbfiltro.TabIndex = 30;
            this.gbfiltro.TabStop = false;
            this.gbfiltro.Text = "Búsqueda y filtro";
            // 
            // btnVer
            // 
            this.btnVer.Image = global::GUILayer.Properties.Resources.buscar;
            this.btnVer.Location = new System.Drawing.Point(790, 8);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(101, 47);
            this.btnVer.TabIndex = 38;
            this.btnVer.Text = "Ver";
            this.btnVer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // dgvInconsistencias
            // 
            this.dgvInconsistencias.AllowUserToAddRows = false;
            this.dgvInconsistencias.AllowUserToDeleteRows = false;
            this.dgvInconsistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInconsistencias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInconsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInconsistencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Fecha,
            this.Hora,
            this.Cajero,
            this.Cliente,
            this.Manifiesto,
            this.Tula,
            this.NumeroDeposito,
            this.Cuenta,
            this.Camara,
            this.MontoDeposito,
            this.TipoInconsistencia});
            this.dgvInconsistencias.EnableHeadersVisualStyles = false;
            this.dgvInconsistencias.Location = new System.Drawing.Point(12, 185);
            this.dgvInconsistencias.MultiSelect = false;
            this.dgvInconsistencias.Name = "dgvInconsistencias";
            this.dgvInconsistencias.ReadOnly = true;
            this.dgvInconsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInconsistencias.Size = new System.Drawing.Size(896, 441);
            this.dgvInconsistencias.TabIndex = 31;
            this.dgvInconsistencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInconsistencias_CellContentClick);
            this.dgvInconsistencias.SelectionChanged += new System.EventHandler(this.dgvInconsistencias_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 43;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 62;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 55;
            // 
            // Cajero
            // 
            this.Cajero.DataPropertyName = "Cajero";
            this.Cajero.HeaderText = "Cajero";
            this.Cajero.Name = "Cajero";
            this.Cajero.ReadOnly = true;
            this.Cajero.Width = 62;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 64;
            // 
            // Manifiesto
            // 
            this.Manifiesto.DataPropertyName = "Manifiesto";
            this.Manifiesto.HeaderText = "Manifiesto";
            this.Manifiesto.Name = "Manifiesto";
            this.Manifiesto.ReadOnly = true;
            this.Manifiesto.Width = 80;
            // 
            // Tula
            // 
            this.Tula.DataPropertyName = "Tula";
            this.Tula.HeaderText = "Tula";
            this.Tula.Name = "Tula";
            this.Tula.ReadOnly = true;
            this.Tula.Width = 53;
            // 
            // NumeroDeposito
            // 
            this.NumeroDeposito.DataPropertyName = "Numero_Deposito";
            this.NumeroDeposito.HeaderText = "Número de Depósito";
            this.NumeroDeposito.Name = "NumeroDeposito";
            this.NumeroDeposito.ReadOnly = true;
            this.NumeroDeposito.Width = 118;
            // 
            // Cuenta
            // 
            this.Cuenta.DataPropertyName = "Cuenta";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.ReadOnly = true;
            this.Cuenta.Width = 66;
            // 
            // Camara
            // 
            this.Camara.DataPropertyName = "Camara";
            this.Camara.HeaderText = "Cámara";
            this.Camara.Name = "Camara";
            this.Camara.ReadOnly = true;
            this.Camara.Width = 68;
            // 
            // MontoDeposito
            // 
            this.MontoDeposito.DataPropertyName = "Monto";
            this.MontoDeposito.HeaderText = "Monto del Depósito";
            this.MontoDeposito.Name = "MontoDeposito";
            this.MontoDeposito.ReadOnly = true;
            this.MontoDeposito.Width = 114;
            // 
            // TipoInconsistencia
            // 
            this.TipoInconsistencia.DataPropertyName = "TipoInconsistencia";
            this.TipoInconsistencia.HeaderText = "TipoInconsistencia";
            this.TipoInconsistencia.Name = "TipoInconsistencia";
            this.TipoInconsistencia.ReadOnly = true;
            this.TipoInconsistencia.Visible = false;
            this.TipoInconsistencia.Width = 121;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(756, 633);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 32;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::GUILayer.Properties.Resources.registro1;
            this.btnModificar.Location = new System.Drawing.Point(649, 633);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 34;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnResolver
            // 
            this.btnResolver.Image = global::GUILayer.Properties.Resources.revision;
            this.btnResolver.Location = new System.Drawing.Point(546, 633);
            this.btnResolver.Name = "btnResolver";
            this.btnResolver.Size = new System.Drawing.Size(90, 40);
            this.btnResolver.TabIndex = 33;
            this.btnResolver.Text = "Resolver";
            this.btnResolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResolver.UseVisualStyleBackColor = false;
            this.btnResolver.Click += new System.EventHandler(this.btnResolver_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(1, 4);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(917, 60);
            this.pnlFondo.TabIndex = 35;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // grpleyenda
            // 
            this.grpleyenda.Controls.Add(this.pictureBox1);
            this.grpleyenda.Controls.Add(this.label2);
            this.grpleyenda.Controls.Add(this.pcbinfo);
            this.grpleyenda.Controls.Add(this.pcbdiferencia);
            this.grpleyenda.Controls.Add(this.label1);
            this.grpleyenda.Controls.Add(this.lblinfodiferencia);
            this.grpleyenda.Location = new System.Drawing.Point(4, 137);
            this.grpleyenda.Name = "grpleyenda";
            this.grpleyenda.Size = new System.Drawing.Size(904, 42);
            this.grpleyenda.TabIndex = 36;
            this.grpleyenda.TabStop = false;
            this.grpleyenda.Text = "Leyenda tipos de inconsistencia";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightYellow;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(665, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 22);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Información Incompleta y Diferencia Montos";
            // 
            // pcbinfo
            // 
            this.pcbinfo.BackColor = System.Drawing.Color.LightCoral;
            this.pcbinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbinfo.Location = new System.Drawing.Point(350, 15);
            this.pcbinfo.Name = "pcbinfo";
            this.pcbinfo.Size = new System.Drawing.Size(51, 22);
            this.pcbinfo.TabIndex = 3;
            this.pcbinfo.TabStop = false;
            // 
            // pcbdiferencia
            // 
            this.pcbdiferencia.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pcbdiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbdiferencia.Location = new System.Drawing.Point(119, 15);
            this.pcbdiferencia.Name = "pcbdiferencia";
            this.pcbdiferencia.Size = new System.Drawing.Size(51, 22);
            this.pcbdiferencia.TabIndex = 2;
            this.pcbdiferencia.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Información Incompleta";
            // 
            // lblinfodiferencia
            // 
            this.lblinfodiferencia.AutoSize = true;
            this.lblinfodiferencia.Location = new System.Drawing.Point(19, 20);
            this.lblinfodiferencia.Name = "lblinfodiferencia";
            this.lblinfodiferencia.Size = new System.Drawing.Size(93, 13);
            this.lblinfodiferencia.TabIndex = 0;
            this.lblinfodiferencia.Text = "Diferencia Montos";
            // 
            // cboCliente
            // 
            this.cboCliente.Busqueda = false;
            this.cboCliente.ListaMostrada = null;
            this.cboCliente.Location = new System.Drawing.Point(66, 19);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(255, 21);
            this.cboCliente.TabIndex = 15;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // frmInconsistenciasPorResolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 680);
            this.Controls.Add(this.grpleyenda);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnResolver);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvInconsistencias);
            this.Controls.Add(this.gbfiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInconsistenciasPorResolver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inconsistencias por Resolver";
            this.gbfiltro.ResumeLayout(false);
            this.gbfiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInconsistencias)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.grpleyenda.ResumeLayout(false);
            this.grpleyenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbdiferencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxBusqueda cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboEstadoInconsistencia;
        private System.Windows.Forms.Label lblEstadoInconsistencia;
        private System.Windows.Forms.GroupBox gbfiltro;
        private System.Windows.Forms.DataGridView dgvInconsistencias;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manifiesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDeposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Camara;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDeposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoInconsistencia;
        private System.Windows.Forms.GroupBox grpleyenda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pcbinfo;
        private System.Windows.Forms.PictureBox pcbdiferencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblinfodiferencia;
    }
}