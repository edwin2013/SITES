namespace Lector_Datos_Cummins
{
    partial class frmLectorDatosCummins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLectorDatosCummins));
            this.spPuerto = new System.IO.Ports.SerialPort(this.components);
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboNombre = new System.Windows.Forms.ComboBox();
            this.cboBitsDatos = new System.Windows.Forms.ComboBox();
            this.lblParidad = new System.Windows.Forms.Label();
            this.lblBitsParada = new System.Windows.Forms.Label();
            this.lblBitsDatos = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cboBaudrate = new System.Windows.Forms.ComboBox();
            this.cboBitsParada = new System.Windows.Forms.ComboBox();
            this.cboParidad = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLeer = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.I = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // spPuerto
            // 
            this.spPuerto.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.spPuerto_ErrorReceived);
            this.spPuerto.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spPuerto_DataReceived);
            // 
            // txtDatos
            // 
            this.txtDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDatos.Location = new System.Drawing.Point(245, 12);
            this.txtDatos.Multiline = true;
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.Size = new System.Drawing.Size(296, 420);
            this.txtDatos.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboNombre);
            this.groupBox1.Controls.Add(this.cboBitsDatos);
            this.groupBox1.Controls.Add(this.lblParidad);
            this.groupBox1.Controls.Add(this.lblBitsParada);
            this.groupBox1.Controls.Add(this.lblBitsDatos);
            this.groupBox1.Controls.Add(this.lblBaudRate);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.cboBaudrate);
            this.groupBox1.Controls.Add(this.cboBitsParada);
            this.groupBox1.Controls.Add(this.cboParidad);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 156);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones de Conexión a la Báscula";
            // 
            // cboNombre
            // 
            this.cboNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNombre.FormattingEnabled = true;
            this.cboNombre.Location = new System.Drawing.Point(109, 19);
            this.cboNombre.Name = "cboNombre";
            this.cboNombre.Size = new System.Drawing.Size(111, 21);
            this.cboNombre.TabIndex = 1;
            // 
            // cboBitsDatos
            // 
            this.cboBitsDatos.FormattingEnabled = true;
            this.cboBitsDatos.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cboBitsDatos.Location = new System.Drawing.Point(109, 46);
            this.cboBitsDatos.Name = "cboBitsDatos";
            this.cboBitsDatos.Size = new System.Drawing.Size(111, 21);
            this.cboBitsDatos.TabIndex = 5;
            // 
            // lblParidad
            // 
            this.lblParidad.AutoSize = true;
            this.lblParidad.Location = new System.Drawing.Point(57, 130);
            this.lblParidad.Name = "lblParidad";
            this.lblParidad.Size = new System.Drawing.Size(46, 13);
            this.lblParidad.TabIndex = 6;
            this.lblParidad.Text = "Paridad:";
            // 
            // lblBitsParada
            // 
            this.lblBitsParada.AutoSize = true;
            this.lblBitsParada.Location = new System.Drawing.Point(24, 76);
            this.lblBitsParada.Name = "lblBitsParada";
            this.lblBitsParada.Size = new System.Drawing.Size(79, 13);
            this.lblBitsParada.TabIndex = 8;
            this.lblBitsParada.Text = "Bits de Parada:";
            // 
            // lblBitsDatos
            // 
            this.lblBitsDatos.AutoSize = true;
            this.lblBitsDatos.Location = new System.Drawing.Point(76, 49);
            this.lblBitsDatos.Name = "lblBitsDatos";
            this.lblBitsDatos.Size = new System.Drawing.Size(27, 13);
            this.lblBitsDatos.TabIndex = 4;
            this.lblBitsDatos.Text = "Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(42, 103);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(61, 13);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(97, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre del puerto:";
            // 
            // cboBaudrate
            // 
            this.cboBaudrate.FormattingEnabled = true;
            this.cboBaudrate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboBaudrate.Location = new System.Drawing.Point(109, 100);
            this.cboBaudrate.Name = "cboBaudrate";
            this.cboBaudrate.Size = new System.Drawing.Size(111, 21);
            this.cboBaudrate.TabIndex = 3;
            // 
            // cboBitsParada
            // 
            this.cboBitsParada.FormattingEnabled = true;
            this.cboBitsParada.Location = new System.Drawing.Point(109, 73);
            this.cboBitsParada.Name = "cboBitsParada";
            this.cboBitsParada.Size = new System.Drawing.Size(111, 21);
            this.cboBitsParada.TabIndex = 9;
            // 
            // cboParidad
            // 
            this.cboParidad.FormattingEnabled = true;
            this.cboParidad.Location = new System.Drawing.Point(109, 127);
            this.cboParidad.Name = "cboParidad";
            this.cboParidad.Size = new System.Drawing.Size(111, 21);
            this.cboParidad.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(149, 392);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLeer
            // 
            this.btnLeer.Location = new System.Drawing.Point(149, 346);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(90, 40);
            this.btnLeer.TabIndex = 5;
            this.btnLeer.Text = "Leer";
            this.btnLeer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLeer.UseVisualStyleBackColor = false;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B,
            this.C,
            this.D,
            this.E,
            this.F,
            this.G,
            this.H,
            this.I,
            this.J,
            this.K,
            this.L,
            this.M,
            this.N,
            this.O,
            this.P,
            this.Q,
            this.R,
            this.S,
            this.T,
            this.U,
            this.V,
            this.W,
            this.X,
            this.Y,
            this.Z});
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.Location = new System.Drawing.Point(548, 12);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDatos.Size = new System.Drawing.Size(386, 420);
            this.dgvDatos.TabIndex = 6;
            // 
            // A
            // 
            this.A.HeaderText = "A";
            this.A.Name = "A";
            this.A.Visible = false;
            // 
            // B
            // 
            this.B.HeaderText = "B";
            this.B.Name = "B";
            // 
            // C
            // 
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.Visible = false;
            // 
            // D
            // 
            this.D.HeaderText = "D";
            this.D.Name = "D";
            this.D.Visible = false;
            // 
            // E
            // 
            this.E.HeaderText = "E";
            this.E.Name = "E";
            this.E.Visible = false;
            // 
            // F
            // 
            this.F.HeaderText = "F";
            this.F.Name = "F";
            this.F.Visible = false;
            // 
            // G
            // 
            this.G.HeaderText = "G";
            this.G.Name = "G";
            this.G.Visible = false;
            // 
            // H
            // 
            this.H.HeaderText = "H";
            this.H.Name = "H";
            this.H.Visible = false;
            // 
            // I
            // 
            this.I.HeaderText = "Cantidad de Billetes";
            this.I.Name = "I";
            // 
            // J
            // 
            this.J.HeaderText = "Monto";
            this.J.Name = "J";
            // 
            // K
            // 
            this.K.HeaderText = "K";
            this.K.Name = "K";
            // 
            // L
            // 
            this.L.HeaderText = "L";
            this.L.Name = "L";
            // 
            // M
            // 
            this.M.HeaderText = "M";
            this.M.Name = "M";
            // 
            // N
            // 
            this.N.HeaderText = "N";
            this.N.Name = "N";
            // 
            // O
            // 
            this.O.HeaderText = "O";
            this.O.Name = "O";
            // 
            // P
            // 
            this.P.HeaderText = "P";
            this.P.Name = "P";
            // 
            // Q
            // 
            this.Q.HeaderText = "Q";
            this.Q.Name = "Q";
            // 
            // R
            // 
            this.R.HeaderText = "R";
            this.R.Name = "R";
            // 
            // S
            // 
            this.S.HeaderText = "S";
            this.S.Name = "S";
            // 
            // T
            // 
            this.T.HeaderText = "T";
            this.T.Name = "T";
            // 
            // U
            // 
            this.U.HeaderText = "U";
            this.U.Name = "U";
            // 
            // V
            // 
            this.V.HeaderText = "V";
            this.V.Name = "V";
            // 
            // W
            // 
            this.W.HeaderText = "W";
            this.W.Name = "W";
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            // 
            // frmLectorDatosCummins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 444);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnLeer);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLectorDatosCummins";
            this.Text = "Lector de Datos de las Máquinas Cummins";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort spPuerto;
        private System.Windows.Forms.TextBox txtDatos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboNombre;
        private System.Windows.Forms.ComboBox cboBitsDatos;
        private System.Windows.Forms.Label lblParidad;
        private System.Windows.Forms.Label lblBitsParada;
        private System.Windows.Forms.Label lblBitsDatos;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cboBaudrate;
        private System.Windows.Forms.ComboBox cboBitsParada;
        private System.Windows.Forms.ComboBox cboParidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLeer;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
        private System.Windows.Forms.DataGridViewTextBoxColumn G;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewTextBoxColumn I;
        private System.Windows.Forms.DataGridViewTextBoxColumn J;
        private System.Windows.Forms.DataGridViewTextBoxColumn K;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn O;
        private System.Windows.Forms.DataGridViewTextBoxColumn P;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn U;
        private System.Windows.Forms.DataGridViewTextBoxColumn V;
        private System.Windows.Forms.DataGridViewTextBoxColumn W;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
    }
}

