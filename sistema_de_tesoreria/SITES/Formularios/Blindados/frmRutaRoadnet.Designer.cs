namespace GUILayer.Formularios.Blindados
{
    partial class frmRutaRoadnet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRutaRoadnet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlOpcionesCoordinacion = new System.Windows.Forms.Panel();
            this.btnOrdenRutas = new System.Windows.Forms.Button();
            this.btnMontos = new System.Windows.Forms.Button();
            this.chkRuta = new System.Windows.Forms.CheckBox();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.lblCustodio = new System.Windows.Forms.Label();
            this.lblChofer = new System.Windows.Forms.Label();
            this.lblPortavalor = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.nudRuta = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.gbCargas = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.Ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orden_Ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Canal_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Carga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_Programada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoraPuntoInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoraFinalPunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emergencia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Carga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Canal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLecturaHandHeld = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmLecturaManual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gbTotal = new System.Windows.Forms.GroupBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.btnArriba = new System.Windows.Forms.Button();
            this.btnAbajo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.pnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlOpcionesCoordinacion.SuspendLayout();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).BeginInit();
            this.gbCargas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.gbTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.White;
            this.pnlFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFondo.Controls.Add(this.pbLogo);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(1155, 66);
            this.pnlFondo.TabIndex = 7;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(425, 64);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlOpcionesCoordinacion
            // 
            this.pnlOpcionesCoordinacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnOrdenRutas);
            this.pnlOpcionesCoordinacion.Controls.Add(this.btnMontos);
            this.pnlOpcionesCoordinacion.Location = new System.Drawing.Point(282, 745);
            this.pnlOpcionesCoordinacion.Name = "pnlOpcionesCoordinacion";
            this.pnlOpcionesCoordinacion.Size = new System.Drawing.Size(208, 40);
            this.pnlOpcionesCoordinacion.TabIndex = 10;
            // 
            // btnOrdenRutas
            // 
            this.btnOrdenRutas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOrdenRutas.FlatAppearance.BorderSize = 2;
            this.btnOrdenRutas.Image = global::GUILayer.Properties.Resources.ordenar_ruta;
            this.btnOrdenRutas.Location = new System.Drawing.Point(110, 0);
            this.btnOrdenRutas.Name = "btnOrdenRutas";
            this.btnOrdenRutas.Size = new System.Drawing.Size(90, 40);
            this.btnOrdenRutas.TabIndex = 5;
            this.btnOrdenRutas.Text = "Ordenar";
            this.btnOrdenRutas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrdenRutas.UseVisualStyleBackColor = false;
            this.btnOrdenRutas.Visible = false;
            this.btnOrdenRutas.Click += new System.EventHandler(this.btnOrdenRutas_Click);
            // 
            // btnMontos
            // 
            this.btnMontos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMontos.FlatAppearance.BorderSize = 2;
            this.btnMontos.Image = global::GUILayer.Properties.Resources.montos;
            this.btnMontos.Location = new System.Drawing.Point(14, 0);
            this.btnMontos.Name = "btnMontos";
            this.btnMontos.Size = new System.Drawing.Size(90, 40);
            this.btnMontos.TabIndex = 4;
            this.btnMontos.Text = "Montos";
            this.btnMontos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMontos.UseVisualStyleBackColor = false;
            this.btnMontos.Visible = false;
            this.btnMontos.Click += new System.EventHandler(this.btnMontos_Click);
            // 
            // chkRuta
            // 
            this.chkRuta.AutoSize = true;
            this.chkRuta.Location = new System.Drawing.Point(175, 37);
            this.chkRuta.Name = "chkRuta";
            this.chkRuta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRuta.Size = new System.Drawing.Size(52, 17);
            this.chkRuta.TabIndex = 4;
            this.chkRuta.Text = "Ruta:";
            this.chkRuta.UseVisualStyleBackColor = true;
            this.chkRuta.CheckedChanged += new System.EventHandler(this.chkRuta_CheckedChanged);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltro.Controls.Add(this.lblVehiculo);
            this.gbFiltro.Controls.Add(this.lblCustodio);
            this.gbFiltro.Controls.Add(this.lblChofer);
            this.gbFiltro.Controls.Add(this.lblPortavalor);
            this.gbFiltro.Controls.Add(this.chkRuta);
            this.gbFiltro.Controls.Add(this.btnActualizar);
            this.gbFiltro.Controls.Add(this.nudRuta);
            this.gbFiltro.Controls.Add(this.dtpFecha);
            this.gbFiltro.Controls.Add(this.lblFechaInicio);
            this.gbFiltro.Location = new System.Drawing.Point(12, 72);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(1075, 85);
            this.gbFiltro.TabIndex = 8;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtrar Datos";
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Location = new System.Drawing.Point(786, 50);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(0, 13);
            this.lblVehiculo.TabIndex = 12;
            // 
            // lblCustodio
            // 
            this.lblCustodio.AutoSize = true;
            this.lblCustodio.Location = new System.Drawing.Point(786, 23);
            this.lblCustodio.Name = "lblCustodio";
            this.lblCustodio.Size = new System.Drawing.Size(0, 13);
            this.lblCustodio.TabIndex = 11;
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(523, 44);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(0, 13);
            this.lblChofer.TabIndex = 10;
            // 
            // lblPortavalor
            // 
            this.lblPortavalor.AutoSize = true;
            this.lblPortavalor.Location = new System.Drawing.Point(523, 17);
            this.lblPortavalor.Name = "lblPortavalor";
            this.lblPortavalor.Size = new System.Drawing.Size(0, 13);
            this.lblPortavalor.TabIndex = 9;
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.Image = global::GUILayer.Properties.Resources.actualizar;
            this.btnActualizar.Location = new System.Drawing.Point(340, 23);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // nudRuta
            // 
            this.nudRuta.Enabled = false;
            this.nudRuta.Location = new System.Drawing.Point(233, 35);
            this.nudRuta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRuta.Name = "nudRuta";
            this.nudRuta.Size = new System.Drawing.Size(77, 20);
            this.nudRuta.TabIndex = 5;
            this.nudRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRuta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(65, 35);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(104, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(19, 39);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(40, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha:";
            // 
            // gbCargas
            // 
            this.gbCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargas.Controls.Add(this.dgvCargas);
            this.gbCargas.Location = new System.Drawing.Point(12, 163);
            this.gbCargas.Name = "gbCargas";
            this.gbCargas.Size = new System.Drawing.Size(1075, 511);
            this.gbCargas.TabIndex = 14;
            this.gbCargas.TabStop = false;
            this.gbCargas.Text = "Lista de Cargas";
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCargas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCargas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ruta,
            this.clmEstado,
            this.Orden_Ruta,
            this.clmNumero,
            this.Canal_Nombre,
            this.Tipo_Carga,
            this.Hora_Programada,
            this.Hora_Entrada,
            this.clmHoraPuntoInicio,
            this.clmHoraFinalPunto,
            this.Hora_Salida,
            this.Emergencia,
            this.Observaciones,
            this.ID_Carga,
            this.ID_Canal,
            this.clmLecturaHandHeld,
            this.clmLecturaManual});
            this.dgvCargas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCargas.EnableHeadersVisualStyles = false;
            this.dgvCargas.Location = new System.Drawing.Point(6, 19);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.RowHeadersVisible = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(1063, 483);
            this.dgvCargas.TabIndex = 1;
            this.dgvCargas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCargas_RowsAdded_1);
            this.dgvCargas.SelectionChanged += new System.EventHandler(this.dgvCargas_SelectionChanged_1);
            // 
            // Ruta
            // 
            this.Ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ruta.DataPropertyName = "Ruta";
            this.Ruta.HeaderText = "Ruta";
            this.Ruta.Name = "Ruta";
            this.Ruta.ReadOnly = true;
            this.Ruta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ruta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ruta.Width = 35;
            // 
            // clmEstado
            // 
            this.clmEstado.DataPropertyName = "Estado de la Ruta";
            this.clmEstado.HeaderText = "Estado";
            this.clmEstado.Name = "clmEstado";
            this.clmEstado.ReadOnly = true;
            this.clmEstado.Width = 64;
            // 
            // Orden_Ruta
            // 
            this.Orden_Ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Orden_Ruta.DataPropertyName = "Orden_Ruta";
            this.Orden_Ruta.HeaderText = "Secuencia";
            this.Orden_Ruta.Name = "Orden_Ruta";
            this.Orden_Ruta.ReadOnly = true;
            this.Orden_Ruta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Orden_Ruta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Orden_Ruta.Width = 63;
            // 
            // clmNumero
            // 
            this.clmNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmNumero.DataPropertyName = "NumeroPunto";
            this.clmNumero.HeaderText = "N° Punto";
            this.clmNumero.Name = "clmNumero";
            this.clmNumero.ReadOnly = true;
            this.clmNumero.Width = 74;
            // 
            // Canal_Nombre
            // 
            this.Canal_Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Canal_Nombre.DataPropertyName = "Nombre";
            this.Canal_Nombre.HeaderText = "Nombre";
            this.Canal_Nombre.Name = "Canal_Nombre";
            this.Canal_Nombre.ReadOnly = true;
            this.Canal_Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Canal_Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Canal_Nombre.Width = 49;
            // 
            // Tipo_Carga
            // 
            this.Tipo_Carga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tipo_Carga.DataPropertyName = "TipoCargas";
            this.Tipo_Carga.HeaderText = "Tipo de Carga";
            this.Tipo_Carga.Name = "Tipo_Carga";
            this.Tipo_Carga.ReadOnly = true;
            this.Tipo_Carga.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tipo_Carga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tipo_Carga.Width = 79;
            // 
            // Hora_Programada
            // 
            this.Hora_Programada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Hora_Programada.DataPropertyName = "HoraProgramada";
            dataGridViewCellStyle8.Format = "T";
            dataGridViewCellStyle8.NullValue = null;
            this.Hora_Programada.DefaultCellStyle = dataGridViewCellStyle8;
            this.Hora_Programada.HeaderText = "Hora Programada";
            this.Hora_Programada.Name = "Hora_Programada";
            this.Hora_Programada.ReadOnly = true;
            this.Hora_Programada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hora_Programada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Hora_Programada.Width = 95;
            // 
            // Hora_Entrada
            // 
            this.Hora_Entrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Hora_Entrada.DataPropertyName = "HoraEntregaBoveda";
            dataGridViewCellStyle9.Format = "T";
            dataGridViewCellStyle9.NullValue = null;
            this.Hora_Entrada.DefaultCellStyle = dataGridViewCellStyle9;
            this.Hora_Entrada.HeaderText = "Arribo";
            this.Hora_Entrada.Name = "Hora_Entrada";
            this.Hora_Entrada.ReadOnly = true;
            this.Hora_Entrada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hora_Entrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Hora_Entrada.Width = 39;
            // 
            // clmHoraPuntoInicio
            // 
            this.clmHoraPuntoInicio.DataPropertyName = "HoraInicioAtencionPunto";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "T";
            dataGridViewCellStyle10.NullValue = null;
            this.clmHoraPuntoInicio.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmHoraPuntoInicio.HeaderText = "Inicio";
            this.clmHoraPuntoInicio.Name = "clmHoraPuntoInicio";
            this.clmHoraPuntoInicio.ReadOnly = true;
            this.clmHoraPuntoInicio.Width = 56;
            // 
            // clmHoraFinalPunto
            // 
            this.clmHoraFinalPunto.DataPropertyName = "HoraFinalAtencionPunto";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "T";
            this.clmHoraFinalPunto.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmHoraFinalPunto.HeaderText = "Fin";
            this.clmHoraFinalPunto.Name = "clmHoraFinalPunto";
            this.clmHoraFinalPunto.ReadOnly = true;
            this.clmHoraFinalPunto.Width = 45;
            // 
            // Hora_Salida
            // 
            this.Hora_Salida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Hora_Salida.DataPropertyName = "HoraRecibidoBoveda";
            dataGridViewCellStyle12.Format = "T";
            dataGridViewCellStyle12.NullValue = null;
            this.Hora_Salida.DefaultCellStyle = dataGridViewCellStyle12;
            this.Hora_Salida.HeaderText = "Salida";
            this.Hora_Salida.Name = "Hora_Salida";
            this.Hora_Salida.ReadOnly = true;
            this.Hora_Salida.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hora_Salida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Hora_Salida.Width = 41;
            // 
            // Emergencia
            // 
            this.Emergencia.DataPropertyName = "Emergencia";
            this.Emergencia.HeaderText = "Emergencia";
            this.Emergencia.Name = "Emergencia";
            this.Emergencia.ReadOnly = true;
            this.Emergencia.Width = 68;
            // 
            // Observaciones
            // 
            this.Observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Observaciones.Width = 83;
            // 
            // ID_Carga
            // 
            this.ID_Carga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID_Carga.DataPropertyName = "ID";
            this.ID_Carga.HeaderText = "ID";
            this.ID_Carga.Name = "ID_Carga";
            this.ID_Carga.ReadOnly = true;
            this.ID_Carga.Width = 42;
            // 
            // ID_Canal
            // 
            this.ID_Canal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID_Canal.DataPropertyName = "ID_Canal";
            this.ID_Canal.HeaderText = "ID Punto";
            this.ID_Canal.Name = "ID_Canal";
            this.ID_Canal.ReadOnly = true;
            this.ID_Canal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID_Canal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID_Canal.Visible = false;
            // 
            // clmLecturaHandHeld
            // 
            this.clmLecturaHandHeld.HeaderText = "Lectura Hand Held";
            this.clmLecturaHandHeld.Name = "clmLecturaHandHeld";
            this.clmLecturaHandHeld.ReadOnly = true;
            this.clmLecturaHandHeld.Width = 102;
            // 
            // clmLecturaManual
            // 
            this.clmLecturaManual.HeaderText = "Lectura Manual";
            this.clmLecturaManual.Name = "clmLecturaManual";
            this.clmLecturaManual.ReadOnly = true;
            this.clmLecturaManual.Width = 86;
            // 
            // gbTotal
            // 
            this.gbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTotal.Controls.Add(this.lblMontoTotal);
            this.gbTotal.Location = new System.Drawing.Point(18, 684);
            this.gbTotal.Name = "gbTotal";
            this.gbTotal.Size = new System.Drawing.Size(250, 54);
            this.gbTotal.TabIndex = 15;
            this.gbTotal.TabStop = false;
            this.gbTotal.Text = "Monto Total";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(36, 23);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(81, 18);
            this.lblMontoTotal.TabIndex = 0;
            this.lblMontoTotal.Tag = "";
            this.lblMontoTotal.Text = "CRC 0,00";
            // 
            // btnArriba
            // 
            this.btnArriba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArriba.Enabled = false;
            this.btnArriba.Image = global::GUILayer.Properties.Resources.arriba;
            this.btnArriba.Location = new System.Drawing.Point(1103, 429);
            this.btnArriba.Name = "btnArriba";
            this.btnArriba.Size = new System.Drawing.Size(40, 90);
            this.btnArriba.TabIndex = 28;
            this.btnArriba.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArriba.UseVisualStyleBackColor = true;
            this.btnArriba.Visible = false;
            this.btnArriba.Click += new System.EventHandler(this.btnArriba_Click);
            // 
            // btnAbajo
            // 
            this.btnAbajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbajo.Enabled = false;
            this.btnAbajo.Image = global::GUILayer.Properties.Resources.abajo;
            this.btnAbajo.Location = new System.Drawing.Point(1103, 525);
            this.btnAbajo.Name = "btnAbajo";
            this.btnAbajo.Size = new System.Drawing.Size(40, 90);
            this.btnAbajo.TabIndex = 29;
            this.btnAbajo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbajo.UseVisualStyleBackColor = true;
            this.btnAbajo.Visible = false;
            this.btnAbajo.Click += new System.EventHandler(this.btnAbajo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(1047, 745);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 40);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRevisar
            // 
            this.btnRevisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRevisar.Enabled = false;
            this.btnRevisar.FlatAppearance.BorderSize = 2;
            this.btnRevisar.Image = global::GUILayer.Properties.Resources.modificar1;
            this.btnRevisar.Location = new System.Drawing.Point(951, 745);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(90, 40);
            this.btnRevisar.TabIndex = 11;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderSize = 2;
            this.btnExportar.Image = global::GUILayer.Properties.Resources.excel;
            this.btnExportar.Location = new System.Drawing.Point(855, 745);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(90, 40);
            this.btnExportar.TabIndex = 30;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmRutaRoadnet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 791);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnArriba);
            this.Controls.Add(this.btnAbajo);
            this.Controls.Add(this.gbTotal);
            this.Controls.Add(this.gbCargas);
            this.Controls.Add(this.pnlFondo);
            this.Controls.Add(this.pnlOpcionesCoordinacion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnRevisar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRutaRoadnet";
            this.Text = "Asignar Ruta Roadnet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlOpcionesCoordinacion.ResumeLayout(false);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRuta)).EndInit();
            this.gbCargas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.gbTotal.ResumeLayout(false);
            this.gbTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnOrdenRutas;
        private System.Windows.Forms.Panel pnlOpcionesCoordinacion;
        private System.Windows.Forms.Button btnMontos;
        private System.Windows.Forms.CheckBox chkRuta;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.NumericUpDown nudRuta;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.GroupBox gbCargas;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.GroupBox gbTotal;
        private System.Windows.Forms.Button btnArriba;
        private System.Windows.Forms.Button btnAbajo;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden_Ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Canal_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Carga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_Programada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_Entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoraPuntoInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoraFinalPunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_Salida;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Emergencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Carga;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Canal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmLecturaHandHeld;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmLecturaManual;
        private System.Windows.Forms.Label lblCustodio;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.Label lblPortavalor;
        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.Button btnExportar;
    }
}