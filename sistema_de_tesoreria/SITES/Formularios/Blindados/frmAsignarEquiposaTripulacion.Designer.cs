namespace GUILayer.Formularios.Blindados
{
    partial class frmAsignarEquiposaTripulacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarEquiposaTripulacion));
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAsignar = new System.Windows.Forms.Button();
            this.numRuta2 = new System.Windows.Forms.NumericUpDown();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbEmpresas = new System.Windows.Forms.GroupBox();
            this.chkListEquipo = new System.Windows.Forms.CheckedListBox();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.grpColaboradores = new System.Windows.Forms.GroupBox();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.txtPortavalor = new System.Windows.Forms.TextBox();
            this.txtCustodio = new System.Windows.Forms.TextBox();
            this.rbtnPortavalor = new System.Windows.Forms.RadioButton();
            this.rbtnChofer = new System.Windows.Forms.RadioButton();
            this.rbtnCustodio = new System.Windows.Forms.RadioButton();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.cboTripulacion = new GUILayer.ComboBoxBusqueda();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuta2)).BeginInit();
            this.gbEmpresas.SuspendLayout();
            this.gbFiltro.SuspendLayout();
            this.grpColaboradores.SuspendLayout();
            this.pnlFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(642, 29);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(436, 20);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(33, 13);
            this.lblRuta.TabIndex = 19;
            this.lblRuta.Text = "Ruta:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(439, 68);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(40, 13);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha:";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::GUILayer.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(1, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(424, 57);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(485, 63);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 7;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignar.FlatAppearance.BorderSize = 2;
            this.btnAsignar.Image = global::GUILayer.Properties.Resources.asignacion;
            this.btnAsignar.Location = new System.Drawing.Point(645, 520);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(90, 40);
            this.btnAsignar.TabIndex = 33;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click_1);
            // 
            // numRuta2
            // 
            this.numRuta2.Location = new System.Drawing.Point(485, 18);
            this.numRuta2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRuta2.Name = "numRuta2";
            this.numRuta2.Size = new System.Drawing.Size(77, 20);
            this.numRuta2.TabIndex = 9;
            this.numRuta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRuta2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(741, 520);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // gbEmpresas
            // 
            this.gbEmpresas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEmpresas.Controls.Add(this.chkListEquipo);
            this.gbEmpresas.Location = new System.Drawing.Point(12, 337);
            this.gbEmpresas.Name = "gbEmpresas";
            this.gbEmpresas.Size = new System.Drawing.Size(829, 177);
            this.gbEmpresas.TabIndex = 30;
            this.gbEmpresas.TabStop = false;
            this.gbEmpresas.Text = "Lista de Tripulaciones";
            // 
            // chkListEquipo
            // 
            this.chkListEquipo.CheckOnClick = true;
            this.chkListEquipo.ColumnWidth = 250;
            this.chkListEquipo.FormattingEnabled = true;
            this.chkListEquipo.HorizontalExtent = 1;
            this.chkListEquipo.HorizontalScrollbar = true;
            this.chkListEquipo.Location = new System.Drawing.Point(16, 19);
            this.chkListEquipo.MultiColumn = true;
            this.chkListEquipo.Name = "chkListEquipo";
            this.chkListEquipo.Size = new System.Drawing.Size(803, 154);
            this.chkListEquipo.TabIndex = 1;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblBuscar);
            this.gbFiltro.Controls.Add(this.cboTripulacion);
            this.gbFiltro.Controls.Add(this.lblRuta);
            this.gbFiltro.Controls.Add(this.numRuta2);
            this.gbFiltro.Location = new System.Drawing.Point(19, 72);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(822, 100);
            this.gbFiltro.TabIndex = 29;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Tripulaciones";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(6, 33);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // grpColaboradores
            // 
            this.grpColaboradores.Controls.Add(this.txtChofer);
            this.grpColaboradores.Controls.Add(this.txtPortavalor);
            this.grpColaboradores.Controls.Add(this.txtCustodio);
            this.grpColaboradores.Controls.Add(this.rbtnPortavalor);
            this.grpColaboradores.Controls.Add(this.rbtnChofer);
            this.grpColaboradores.Controls.Add(this.rbtnCustodio);
            this.grpColaboradores.Location = new System.Drawing.Point(19, 178);
            this.grpColaboradores.Name = "grpColaboradores";
            this.grpColaboradores.Size = new System.Drawing.Size(822, 144);
            this.grpColaboradores.TabIndex = 32;
            this.grpColaboradores.TabStop = false;
            this.grpColaboradores.Text = "Colaboradores";
            // 
            // txtChofer
            // 
            this.txtChofer.BackColor = System.Drawing.Color.PowderBlue;
            this.txtChofer.Location = new System.Drawing.Point(347, 102);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.ReadOnly = true;
            this.txtChofer.Size = new System.Drawing.Size(326, 20);
            this.txtChofer.TabIndex = 26;
            // 
            // txtPortavalor
            // 
            this.txtPortavalor.BackColor = System.Drawing.Color.PowderBlue;
            this.txtPortavalor.Location = new System.Drawing.Point(474, 49);
            this.txtPortavalor.Name = "txtPortavalor";
            this.txtPortavalor.ReadOnly = true;
            this.txtPortavalor.Size = new System.Drawing.Size(338, 20);
            this.txtPortavalor.TabIndex = 25;
            // 
            // txtCustodio
            // 
            this.txtCustodio.BackColor = System.Drawing.Color.PowderBlue;
            this.txtCustodio.Location = new System.Drawing.Point(84, 49);
            this.txtCustodio.Name = "txtCustodio";
            this.txtCustodio.ReadOnly = true;
            this.txtCustodio.Size = new System.Drawing.Size(296, 20);
            this.txtCustodio.TabIndex = 24;
            // 
            // rbtnPortavalor
            // 
            this.rbtnPortavalor.AutoSize = true;
            this.rbtnPortavalor.Location = new System.Drawing.Point(392, 49);
            this.rbtnPortavalor.Name = "rbtnPortavalor";
            this.rbtnPortavalor.Size = new System.Drawing.Size(76, 17);
            this.rbtnPortavalor.TabIndex = 23;
            this.rbtnPortavalor.TabStop = true;
            this.rbtnPortavalor.Text = "Portavalor:";
            this.rbtnPortavalor.UseVisualStyleBackColor = true;
            this.rbtnPortavalor.CheckedChanged += new System.EventHandler(this.rbtnPortavalor_CheckedChanged);
            // 
            // rbtnChofer
            // 
            this.rbtnChofer.AutoSize = true;
            this.rbtnChofer.Location = new System.Drawing.Point(256, 102);
            this.rbtnChofer.Name = "rbtnChofer";
            this.rbtnChofer.Size = new System.Drawing.Size(59, 17);
            this.rbtnChofer.TabIndex = 22;
            this.rbtnChofer.TabStop = true;
            this.rbtnChofer.Text = "Chofer:";
            this.rbtnChofer.UseVisualStyleBackColor = true;
            this.rbtnChofer.CheckedChanged += new System.EventHandler(this.rbtnChofer_CheckedChanged);
            // 
            // rbtnCustodio
            // 
            this.rbtnCustodio.AutoSize = true;
            this.rbtnCustodio.Location = new System.Drawing.Point(18, 49);
            this.rbtnCustodio.Name = "rbtnCustodio";
            this.rbtnCustodio.Size = new System.Drawing.Size(69, 17);
            this.rbtnCustodio.TabIndex = 21;
            this.rbtnCustodio.TabStop = true;
            this.rbtnCustodio.Text = "Custodio:";
            this.rbtnCustodio.UseVisualStyleBackColor = true;
            this.rbtnCustodio.CheckedChanged += new System.EventHandler(this.rbtnCustodio_CheckedChanged);
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-3, 6);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(859, 60);
            this.pnlFondo.TabIndex = 28;
            // 
            // cboTripulacion
            // 
            this.cboTripulacion.Busqueda = false;
            this.cboTripulacion.ListaMostrada = null;
            this.cboTripulacion.Location = new System.Drawing.Point(55, 29);
            this.cboTripulacion.Name = "cboTripulacion";
            this.cboTripulacion.Size = new System.Drawing.Size(349, 21);
            this.cboTripulacion.TabIndex = 11;
            this.cboTripulacion.SelectedIndexChanged += new System.EventHandler(this.cboTripulacion_SelectedIndexChanged);
            // 
            // frmAsignarEquiposaTripulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 567);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbEmpresas);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.grpColaboradores);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignarEquiposaTripulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Equipos";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuta2)).EndInit();
            this.gbEmpresas.ResumeLayout(false);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.grpColaboradores.ResumeLayout(false);
            this.grpColaboradores.PerformLayout();
            this.pnlFondo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbEmpresas;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label lblBuscar;
        private ComboBoxBusqueda cboTripulacion;
        private System.Windows.Forms.NumericUpDown numRuta2;
        private System.Windows.Forms.GroupBox grpColaboradores;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.TextBox txtPortavalor;
        private System.Windows.Forms.TextBox txtCustodio;
        private System.Windows.Forms.RadioButton rbtnPortavalor;
        private System.Windows.Forms.RadioButton rbtnChofer;
        private System.Windows.Forms.RadioButton rbtnCustodio;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.CheckedListBox chkListEquipo;
    }
}