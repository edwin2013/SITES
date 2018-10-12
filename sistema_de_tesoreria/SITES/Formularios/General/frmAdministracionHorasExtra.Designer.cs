namespace GUILayer
{
    partial class frmAdministracionHorasExtra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionHorasExtra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.cboColaborador = new GUILayer.ComboBoxBusqueda();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFinalizacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinalizacion = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gbInconsistenciasDigitadores = new System.Windows.Forms.GroupBox();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colaborador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Encargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alimentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorasExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorasDobles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorasExtraDobles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aprobado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rechazado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ComentarioMotivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComentarioGastos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.gbOcultarDatos = new System.Windows.Forms.GroupBox();
            this.chkHoras = new System.Windows.Forms.CheckBox();
            this.chkComentarios = new System.Windows.Forms.CheckBox();
            this.chkMontos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlFondo.SuspendLayout();
            this.gbFiltro.SuspendLayout();
            this.gbInconsistenciasDigitadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.gbOcultarDatos.SuspendLayout();
            this.SuspendLayout();
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
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.Image = global::GUILayer.Properties.Resources.agregar;
            this.btnNuevo.Location = new System.Drawing.Point(401, 514);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 40);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.Image = global::GUILayer.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(593, 514);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 40);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pnlFondo
            // 
            this.pnlFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Location = new System.Drawing.Point(-4, -3);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(799, 60);
            this.pnlFondo.TabIndex = 0;
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.Image = global::GUILayer.Properties.Resources.modificar;
            this.btnModificar.Location = new System.Drawing.Point(497, 514);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = global::GUILayer.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(689, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.cboColaborador);
            this.gbFiltro.Controls.Add(this.lblColaborador);
            this.gbFiltro.Controls.Add(this.dtpInicio);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Controls.Add(this.dtpFinalizacion);
            this.gbFiltro.Controls.Add(this.lblFechaFinalizacion);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Location = new System.Drawing.Point(12, 63);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(551, 72);
            this.gbFiltro.TabIndex = 1;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Horas Extra";
            // 
            // cboColaborador
            // 
            this.cboColaborador.Busqueda = true;
            this.cboColaborador.ListaMostrada = null;
            this.cboColaborador.Location = new System.Drawing.Point(95, 45);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(351, 21);
            this.cboColaborador.TabIndex = 5;
            // 
            // lblColaborador
            // 
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Location = new System.Drawing.Point(22, 49);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(67, 13);
            this.lblColaborador.TabIndex = 4;
            this.lblColaborador.Text = "Colaborador:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(95, 19);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(113, 20);
            this.dtpInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(6, 23);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(83, 13);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha de Inicio:";
            // 
            // dtpFinalizacion
            // 
            this.dtpFinalizacion.CustomFormat = "";
            this.dtpFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinalizacion.Location = new System.Drawing.Point(333, 19);
            this.dtpFinalizacion.Name = "dtpFinalizacion";
            this.dtpFinalizacion.Size = new System.Drawing.Size(113, 20);
            this.dtpFinalizacion.TabIndex = 3;
            // 
            // lblFechaFinalizacion
            // 
            this.lblFechaFinalizacion.AutoSize = true;
            this.lblFechaFinalizacion.Location = new System.Drawing.Point(214, 23);
            this.lblFechaFinalizacion.Name = "lblFechaFinalizacion";
            this.lblFechaFinalizacion.Size = new System.Drawing.Size(113, 13);
            this.lblFechaFinalizacion.TabIndex = 2;
            this.lblFechaFinalizacion.Text = "Fecha de Finalización:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(452, 22);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // gbInconsistenciasDigitadores
            // 
            this.gbInconsistenciasDigitadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInconsistenciasDigitadores.Controls.Add(this.dgvRegistros);
            this.gbInconsistenciasDigitadores.Location = new System.Drawing.Point(12, 141);
            this.gbInconsistenciasDigitadores.Name = "gbInconsistenciasDigitadores";
            this.gbInconsistenciasDigitadores.Size = new System.Drawing.Size(768, 367);
            this.gbInconsistenciasDigitadores.TabIndex = 3;
            this.gbInconsistenciasDigitadores.TabStop = false;
            this.gbInconsistenciasDigitadores.Text = "Lista de Registro de Horas Extra";
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRegistros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRegistros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRegistros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRegistros.ColumnHeadersHeight = 17;
            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.FechaRegistro,
            this.Colaborador,
            this.Encargado,
            this.HoraIngreso,
            this.HoraSalida,
            this.Diferencia,
            this.Alimentacion,
            this.Transporte,
            this.HorasExtra,
            this.HorasDobles,
            this.HorasExtraDobles,
            this.Aprobado,
            this.Rechazado,
            this.ComentarioMotivos,
            this.ComentarioGastos});
            this.dgvRegistros.EnableHeadersVisualStyles = false;
            this.dgvRegistros.Location = new System.Drawing.Point(6, 19);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros.Size = new System.Drawing.Size(756, 342);
            this.dgvRegistros.StandardTab = true;
            this.dgvRegistros.TabIndex = 0;
            this.dgvRegistros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistros_CellDoubleClick);
            this.dgvRegistros.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvRegistros_RowsAdded);
            this.dgvRegistros.SelectionChanged += new System.EventHandler(this.dgvRegistros_SelectionChanged);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "Hora_ingreso";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 61;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "Fecha_registro";
            dataGridViewCellStyle3.Format = "d";
            this.FechaRegistro.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaRegistro.HeaderText = "Fecha de Registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Width = 118;
            // 
            // Colaborador
            // 
            this.Colaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Colaborador.DataPropertyName = "Colaborador";
            this.Colaborador.HeaderText = "Colaborador";
            this.Colaborador.Name = "Colaborador";
            this.Colaborador.ReadOnly = true;
            this.Colaborador.Width = 88;
            // 
            // Encargado
            // 
            this.Encargado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Encargado.DataPropertyName = "Coordinador";
            this.Encargado.HeaderText = "Encargado";
            this.Encargado.Name = "Encargado";
            this.Encargado.ReadOnly = true;
            this.Encargado.Width = 83;
            // 
            // HoraIngreso
            // 
            this.HoraIngreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HoraIngreso.DataPropertyName = "Hora_ingreso";
            dataGridViewCellStyle4.Format = "t";
            dataGridViewCellStyle4.NullValue = null;
            this.HoraIngreso.DefaultCellStyle = dataGridViewCellStyle4;
            this.HoraIngreso.HeaderText = "H. Ingreso";
            this.HoraIngreso.Name = "HoraIngreso";
            this.HoraIngreso.ReadOnly = true;
            this.HoraIngreso.Width = 80;
            // 
            // HoraSalida
            // 
            this.HoraSalida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HoraSalida.DataPropertyName = "Hora_salida";
            dataGridViewCellStyle5.Format = "t";
            dataGridViewCellStyle5.NullValue = null;
            this.HoraSalida.DefaultCellStyle = dataGridViewCellStyle5;
            this.HoraSalida.HeaderText = "H. Salida";
            this.HoraSalida.Name = "HoraSalida";
            this.HoraSalida.ReadOnly = true;
            this.HoraSalida.Width = 74;
            // 
            // Diferencia
            // 
            this.Diferencia.HeaderText = "Diferencia";
            this.Diferencia.Name = "Diferencia";
            this.Diferencia.ReadOnly = true;
            this.Diferencia.Width = 79;
            // 
            // Alimentacion
            // 
            this.Alimentacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Alimentacion.DataPropertyName = "Alimentacion";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Alimentacion.DefaultCellStyle = dataGridViewCellStyle6;
            this.Alimentacion.HeaderText = "Alimentación";
            this.Alimentacion.Name = "Alimentacion";
            this.Alimentacion.ReadOnly = true;
            this.Alimentacion.Width = 91;
            // 
            // Transporte
            // 
            this.Transporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Transporte.DataPropertyName = "Transporte";
            dataGridViewCellStyle7.Format = "N2";
            this.Transporte.DefaultCellStyle = dataGridViewCellStyle7;
            this.Transporte.HeaderText = "Transporte";
            this.Transporte.Name = "Transporte";
            this.Transporte.ReadOnly = true;
            this.Transporte.Width = 82;
            // 
            // HorasExtra
            // 
            this.HorasExtra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HorasExtra.DataPropertyName = "Horas_extra";
            this.HorasExtra.HeaderText = "H. Extra";
            this.HorasExtra.Name = "HorasExtra";
            this.HorasExtra.ReadOnly = true;
            this.HorasExtra.Width = 69;
            // 
            // HorasDobles
            // 
            this.HorasDobles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HorasDobles.DataPropertyName = "Horas_dobles";
            this.HorasDobles.HeaderText = "H. Dobles";
            this.HorasDobles.Name = "HorasDobles";
            this.HorasDobles.ReadOnly = true;
            this.HorasDobles.Width = 78;
            // 
            // HorasExtraDobles
            // 
            this.HorasExtraDobles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HorasExtraDobles.DataPropertyName = "Horas_dobles_extra";
            this.HorasExtraDobles.HeaderText = "H. Extra Dobles";
            this.HorasExtraDobles.Name = "HorasExtraDobles";
            this.HorasExtraDobles.ReadOnly = true;
            this.HorasExtraDobles.Width = 105;
            // 
            // Aprobado
            // 
            this.Aprobado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Aprobado.DataPropertyName = "Aprobado";
            this.Aprobado.HeaderText = "Aprobado";
            this.Aprobado.Name = "Aprobado";
            this.Aprobado.ReadOnly = true;
            this.Aprobado.Width = 58;
            // 
            // Rechazado
            // 
            this.Rechazado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Rechazado.HeaderText = "Rechazado";
            this.Rechazado.Name = "Rechazado";
            this.Rechazado.ReadOnly = true;
            this.Rechazado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rechazado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Rechazado.Width = 86;
            // 
            // ComentarioMotivos
            // 
            this.ComentarioMotivos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ComentarioMotivos.DataPropertyName = "Observaciones_conceptos";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ComentarioMotivos.DefaultCellStyle = dataGridViewCellStyle8;
            this.ComentarioMotivos.HeaderText = "Comentario de los Motivos";
            this.ComentarioMotivos.Name = "ComentarioMotivos";
            this.ComentarioMotivos.ReadOnly = true;
            this.ComentarioMotivos.Width = 155;
            // 
            // ComentarioGastos
            // 
            this.ComentarioGastos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ComentarioGastos.DataPropertyName = "Observaciones_gastos";
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ComentarioGastos.DefaultCellStyle = dataGridViewCellStyle9;
            this.ComentarioGastos.HeaderText = "Comentario de los Gastos";
            this.ComentarioGastos.Name = "ComentarioGastos";
            this.ComentarioGastos.ReadOnly = true;
            this.ComentarioGastos.Width = 151;
            // 
            // btnAprobar
            // 
            this.btnAprobar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprobar.Enabled = false;
            this.btnAprobar.FlatAppearance.BorderSize = 2;
            this.btnAprobar.Image = global::GUILayer.Properties.Resources.aceptar;
            this.btnAprobar.Location = new System.Drawing.Point(185, 514);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(102, 40);
            this.btnAprobar.TabIndex = 4;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRechazar.Enabled = false;
            this.btnRechazar.FlatAppearance.BorderSize = 2;
            this.btnRechazar.Image = global::GUILayer.Properties.Resources.cancelar;
            this.btnRechazar.Location = new System.Drawing.Point(293, 514);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(102, 40);
            this.btnRechazar.TabIndex = 5;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // gbOcultarDatos
            // 
            this.gbOcultarDatos.Controls.Add(this.chkHoras);
            this.gbOcultarDatos.Controls.Add(this.chkComentarios);
            this.gbOcultarDatos.Controls.Add(this.chkMontos);
            this.gbOcultarDatos.Location = new System.Drawing.Point(569, 70);
            this.gbOcultarDatos.Name = "gbOcultarDatos";
            this.gbOcultarDatos.Size = new System.Drawing.Size(169, 65);
            this.gbOcultarDatos.TabIndex = 2;
            this.gbOcultarDatos.TabStop = false;
            this.gbOcultarDatos.Text = "Ocultar Datos";
            // 
            // chkHoras
            // 
            this.chkHoras.AutoSize = true;
            this.chkHoras.Checked = true;
            this.chkHoras.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHoras.Location = new System.Drawing.Point(13, 42);
            this.chkHoras.Name = "chkHoras";
            this.chkHoras.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkHoras.Size = new System.Drawing.Size(57, 17);
            this.chkHoras.TabIndex = 2;
            this.chkHoras.Text = "Horas:";
            this.chkHoras.UseVisualStyleBackColor = true;
            this.chkHoras.CheckedChanged += new System.EventHandler(this.chkHoras_CheckedChanged);
            // 
            // chkComentarios
            // 
            this.chkComentarios.AutoSize = true;
            this.chkComentarios.Checked = true;
            this.chkComentarios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkComentarios.Location = new System.Drawing.Point(76, 19);
            this.chkComentarios.Name = "chkComentarios";
            this.chkComentarios.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkComentarios.Size = new System.Drawing.Size(87, 17);
            this.chkComentarios.TabIndex = 1;
            this.chkComentarios.Text = "Comentarios:";
            this.chkComentarios.UseVisualStyleBackColor = true;
            this.chkComentarios.CheckedChanged += new System.EventHandler(this.chkComentarios_CheckedChanged);
            // 
            // chkMontos
            // 
            this.chkMontos.AutoSize = true;
            this.chkMontos.Checked = true;
            this.chkMontos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMontos.Location = new System.Drawing.Point(6, 19);
            this.chkMontos.Name = "chkMontos";
            this.chkMontos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMontos.Size = new System.Drawing.Size(64, 17);
            this.chkMontos.TabIndex = 0;
            this.chkMontos.Text = "Montos:";
            this.chkMontos.UseVisualStyleBackColor = true;
            this.chkMontos.CheckedChanged += new System.EventHandler(this.chkMontos_CheckedChanged);
            // 
            // frmAdministracionHorasExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.gbOcultarDatos);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.gbInconsistenciasDigitadores);
            this.Controls.Add(this.btnRechazar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmAdministracionHorasExtra";
            this.ShowInTaskbar = false;
            this.Text = "Administración de Horas Extra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAdministracionHorasExtra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlFondo.ResumeLayout(false);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbInconsistenciasDigitadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.gbOcultarDatos.ResumeLayout(false);
            this.gbOcultarDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFinalizacion;
        private System.Windows.Forms.Label lblFechaFinalizacion;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gbInconsistenciasDigitadores;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.Button btnAprobar;
        private ComboBoxBusqueda cboColaborador;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.GroupBox gbOcultarDatos;
        private System.Windows.Forms.CheckBox chkHoras;
        private System.Windows.Forms.CheckBox chkComentarios;
        private System.Windows.Forms.CheckBox chkMontos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colaborador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Encargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alimentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorasExtra;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorasDobles;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorasExtraDobles;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aprobado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Rechazado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComentarioMotivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComentarioGastos;

    }
}