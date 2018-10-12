//
//  @ Project : 
//  @ File Name : frmIngresoManifiestoATMs.cs
//  @ Date : 06/06/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmIngresoManifiestoATMs : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CargaATM _carga = null;
        private EsquemaManifiesto _esquema = null;

        private ManifiestoATMCarga _manifiesto = null;
        private ManifiestoATMFull _manifiesto_full = null;

        private decimal _monto = 0;

        private bool _siguiente_full = false;
        private bool _impresion_full = false;
        private bool _impresion_carga = false;

        #endregion Atributos

        #region Constructor

        public frmIngresoManifiestoATMs(CargaATM carga)
        {
            InitializeComponent();

            _carga = carga;
            _manifiesto = carga.Manifiesto;
            _manifiesto_full = carga.Manifiesto_full;

            try
            {
                txtFecha.Text = carga.Fecha_asignada.ToShortDateString();

                dgvManifiestos.AutoGenerateColumns = false;
                dgvManifiestosFull.AutoGenerateColumns = false;

                BindingList<ManifiestoATMCarga> manifiestos = new BindingList<ManifiestoATMCarga>();
                BindingList<ManifiestoATMFull> manifiestos_full = new BindingList<ManifiestoATMFull>();

                dgvManifiestos.DataSource = manifiestos;
                dgvManifiestosFull.DataSource = manifiestos_full;

                if (_manifiesto != null)
                    manifiestos.Add(_manifiesto);

                if (_manifiesto_full != null)
                    manifiestos_full.Add(_manifiesto_full);

                if (_carga.ATM_full)
                {
                    gbBusquedaManifiestosFull.Enabled = true;
                    gbDatosManifiestoFull.Enabled = true;

                    pnlENA.Enabled = true;
                    pnlENA.Enabled = true;
                    //pnlENA.Enabled = _carga.ENA;

                }

                chkBolsaRechazo.Enabled = true;
                chkBolsaRechazoFull.Enabled = true;
               // chkBolsaRechazo.Enabled = _carga.Bolsa_Rechazo;

                _impresion_carga = true;
                _impresion_full = _carga.ATM_full;

                _monto = _carga.Monto_carga_colones + _carga.Monto_carga_dolares * nudTipoCambio.Value;

                // Cargar los esquemas

                cboEsquema.DataSource = _mantenimiento.listarEsquemasManifiestos();

            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar un  manifiesto de carga.
        /// </summary>
        private void btnGuardarManifiesto_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan especificado los datos del manifiesto

            if (
                txtMarchamo.Text.Equals(string.Empty) || txtMarchamoAdicional.Text.Equals(string.Empty) ||
                (chkBolsaRechazo.Checked && txtBolsaAdicionalRechazo.Text.Equals(string.Empty)))
            {
                Excepcion.mostrarMensaje("ErrorManifiestoATMCargaDatosRegistro");
                return;
            }

            try
            {
                string codigo = txtCodigoManifiesto.Text;
                string marchamo = txtMarchamo.Text;
                string bolsa_rechazo = chkBolsaRechazo.Checked ?
                    txtBolsaAdicionalRechazo.Text : null;
                string marchamo_adicional = txtMarchamoAdicional.Text;
                DateTime fecha = _carga.Fecha_asignada;

                // Verificar si el manifiesto es nuevo

                if (_manifiesto == null)
                {

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeManifiestoATMCargaRegistro") == DialogResult.Yes)
                    {
                        ManifiestoATMCarga nuevo = new ManifiestoATMCarga(codigo, marchamo, fecha, bolsa_rechazo, marchamo_adicional);

                        _atencion.agregarManifiestoATMCarga(ref nuevo);

                        txtCodigoManifiesto.Text = nuevo.Codigo;
                        // Agregar el manifiesto a la lista de manifiestos

                        BindingList<ManifiestoATMCarga> manifiestos = (BindingList<ManifiestoATMCarga>)dgvManifiestos.DataSource;

                        manifiestos.Add(nuevo);

                        Mensaje.mostrarMensaje("MensajeManifiestoATMCargaConfirmacionRegistro");

                        btnCancelarManifiesto.Enabled = false;
                        btnAceptar.Enabled = true;
                    }

                }
                else
                {
                    ManifiestoATMCarga copia = new ManifiestoATMCarga(codigo, marchamo, fecha, bolsa_rechazo, marchamo_adicional,
                                                                      id: _manifiesto.ID);

                    _atencion.actualizarManifiestoATMCarga(copia);

                    _manifiesto.Codigo = codigo;
                    _manifiesto.Marchamo = marchamo;
                    _manifiesto.Bolsa_rechazo = bolsa_rechazo;
                    

              
                    Mensaje.mostrarMensaje("MensajeManifiestoATMCargaConfirmacionActualizacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de guardar un  manifiesto de full.
        /// </summary>
        private void btnGuardarManifiestoFull_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan especificado los datos del manifiesto

            if (txtMarchamoFull.Text.Equals(string.Empty) || (_carga.ENA && (txtMarchamoAdicionalENA.Text.Equals(string.Empty) ||
                txtMarchamoENAA.Text.Equals(string.Empty) || txtMarchamoENAB.Text.Equals(string.Empty))))
            {
                Excepcion.mostrarMensaje("ErrorManifiestoATMFullDatosRegistro");
                return;
            }

            try
            {
                string codigo = txtCodigoManifiestoFull.Text;
                string marchamo = txtMarchamoFull.Text;
                DateTime fecha = _carga.Fecha_asignada;

                string marchamo_adicional_ena = null;
                string marchamo_ena_a = null;
                string marchamo_ena_b = null;


                string bolsa_rechazo = chkBolsaRechazoFull.Checked ?
                    txtBolsaRechazoFull.Text : null;

                if (_carga.ENA)
                {
                    marchamo_adicional_ena = txtMarchamoAdicionalENA.Text;
                    marchamo_ena_a = txtMarchamoENAA.Text;
                    marchamo_ena_b = txtMarchamoENAB.Text;
                }

                // Verificar si el manifiesto es nuevo

                if (_manifiesto_full == null)
                {

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeManifiestoATMFullRegistro") == DialogResult.Yes)
                    {
                        ManifiestoATMFull nuevo = new ManifiestoATMFull(codigo, marchamo, fecha, marchamo_adicional_ena, marchamo_ena_a,
                                                                        marchamo_ena_b,bolsa_rechazo);

                        _atencion.agregarManifiestoATMFull(ref nuevo);

                        txtCodigoManifiestoFull.Text = nuevo.Codigo;

                        // Agregar el manifiesto a la lista de manifiestos

                        BindingList<ManifiestoATMFull> manifiestos = (BindingList<ManifiestoATMFull>)dgvManifiestosFull.DataSource;

                        manifiestos.Add(nuevo);

                        Mensaje.mostrarMensaje("MensajeManifiestoATMFullConfirmacionRegistro");

                        btnCancelarManifiesto.Enabled = false;
                        btnAceptar.Enabled = true;
                    }

                }
                else
                {
                    ManifiestoATMFull copia = new ManifiestoATMFull(codigo, marchamo, fecha, marchamo_adicional_ena, marchamo_ena_a,
                                                                    marchamo_ena_b,bolsa_rechazo, id: _manifiesto_full.ID);

                    _atencion.actualizarManifiestoATMFull(copia);

                    _manifiesto_full.Codigo = codigo;
                    _manifiesto_full.Marchamo = marchamo;
                    _manifiesto_full.Marchamo_adicional_ena = marchamo_adicional_ena;
                    _manifiesto_full.Marchamo_ena_a = marchamo_ena_a;
                    _manifiesto_full.Marchamo_ena_b = marchamo_ena_b;

                    Mensaje.mostrarMensaje("MensajeManifiestoATMFullConfirmacionActualizacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el botón de Buscar un manifiesto de carga.
        /// </summary>
        private void btnBuscarManifiesto_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoManifiestoBuscado.Text;

                if (codigo == string.Empty && codigo.Length < 4) return;

                dgvManifiestos.DataSource = _atencion.listarManifiestosATMsCargasPorCodigo(codigo);

                txtCodigoManifiestoBuscado.Text = string.Empty;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de Buscar un manifiesto full.
        /// </summary>
        private void btnBuscarManifiestoFull_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoManifiestoFullBuscado.Text;

                if (codigo == string.Empty && codigo.Length < 4)
                    return;

                dgvManifiestosFull.DataSource = _atencion.listarManifiestosATMsFullPorCodigo(codigo);

                txtCodigoManifiestoFullBuscado.Text = string.Empty;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar un manifiesto de carga.
        /// </summary>
        private void btnNuevoManifiesto_Click(object sender, EventArgs e)
        {
            _manifiesto = null;

            pnlDatosManifiesto.Enabled = true;
            txtMarchamo.Select();

            this.limpiarDatosManifiesto();
        }

        /// <summary>
        /// Clic en el botón de agregar un manifiesto full.
        /// </summary>
        private void btnNuevoManifiestoFull_Click(object sender, EventArgs e)
        {
            _manifiesto_full = null;

            pnlDatosManifiestoFull.Enabled = true;
            txtMarchamoFull.Select();

            this.limpiarDatosManifiestoFull();
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmRegistroCierreATMs padre = (frmRegistroCierreATMs)this.Owner;
            ManifiestoATMCarga manifiesto = dgvManifiestos.Rows.Count > 0 ?  (ManifiestoATMCarga)dgvManifiestos.SelectedRows[0].DataBoundItem : null;
            
            ManifiestoATMFull manifiesto_full = _carga.ATM_full ? (ManifiestoATMFull)dgvManifiestosFull.SelectedRows[0].DataBoundItem : null;

            padre.seleccionarManifiestosCarga(manifiesto, manifiesto_full);

            this.Close();
        }

        /// <summary>
        /// Clic en el botón de imprimir.
        /// </summary
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            pdOpcionesImpresion.PrinterSettings.PrinterName = Properties.Settings.Default.ImpresoraManifiestos;

            if (pdOpcionesImpresion.ShowDialog() == DialogResult.OK)
            {
                string nombre_impresora = pdOpcionesImpresion.PrinterSettings.PrinterName;

                Properties.Settings.Default.ImpresoraManifiestos = nombre_impresora;
                Properties.Settings.Default.Save();

                if (cboEsquema.SelectedItem == null)
                    return;
                else
                    _esquema = (EsquemaManifiesto)cboEsquema.SelectedItem;

                PrinterSettings configuracion = new PrinterSettings();

                configuracion.PrinterName = nombre_impresora;

                pdManifiesto.PrinterSettings = configuracion;

                PaperSize tamano = new System.Drawing.Printing.PaperSize();

                tamano.RawKind = (int)(int)System.Drawing.Printing.PaperKind.Custom;
                tamano.Height = (int)(_esquema.Alto * 100 / (decimal)2.54);
                tamano.Width = (int)(_esquema.Ancho * 100 / (decimal)2.54);

                PageSettings configuracion_pagina = new PageSettings(configuracion);

                configuracion_pagina.Margins.Left = 0;
                configuracion_pagina.Margins.Top = 0;
                configuracion_pagina.Margins.Right = 0;
                configuracion_pagina.Margins.Bottom = 0;
                configuracion_pagina.PaperSize = tamano;

                pdManifiesto.DefaultPageSettings = configuracion_pagina;

                if (_impresion_carga && chkImprimirManifiesto.Checked &&
                    !txtMarchamo.Text.Equals(string.Empty))
                    pdManifiesto.Print();

                if (_impresion_full && chkImprimirManifiestoFull.Checked &&
                    !txtMarchamoFull.Text.Equals(string.Empty))
                {
                    _siguiente_full = true;
                    pdManifiesto.Print();
                }

            }
            
        }

        /// <summary>
        /// Clic en el botón de cancelar el registro de un manifiesto de carga.
        /// </summary>
        private void btnCancelarManifiesto_Click(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                _manifiesto = (ManifiestoATMCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;

                this.mostrarDatosManifiesto();
            }
            else
            {
                pnlDatosManifiesto.Enabled = false;

                this.limpiarDatosManifiesto();
            }

        }

        /// <summary>
        /// Clic en el botón de cancelar el registro de un manifiesto full.
        /// </summary>
        private void btnCancelarManifiestoFull_Click(object sender, EventArgs e)
        {

            if (dgvManifiestosFull.SelectedRows.Count > 0)
            {
                _manifiesto_full = (ManifiestoATMFull)dgvManifiestosFull.SelectedRows[0].DataBoundItem;

                this.mostrarDatosmanifiestoFull();
            }
            else
            {
                pnlDatosManifiesto.Enabled = false;

                this.limpiarDatosManifiestoFull();
            }

        }

        /// <summary>
        /// Se escribe en el texto de búsqueda de los manifiestos de carga.
        /// </summary>
        private void txtCodigoManifiestoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscarManifiesto.Enabled = txtCodigoManifiestoBuscado.Text.Length >= 4;
        }

        /// <summary>
        /// Se escribe en el texto de búsqueda de los manifiestos full.
        /// </summary>
        private void txtCodigoManifiestoFullBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscarManifiestoFull.Enabled = txtCodigoManifiestoFullBuscado.Text.Length >= 4;
        }

        /// <summary>
        /// Se selecciona el control del texto de búsqueda de los manifiestos de carga.
        /// </summary>
        private void txtCodigoManifiestoBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscarManifiesto;
        }

        /// <summary>
        /// Se selecciona el control del texto de búsqueda de los manifiestos full.
        /// </summary>
        private void txtCodigoManifiestoFullBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscarManifiestoFull;
        }

        /// <summary>
        /// Se selecciona el control del texto del manifiesto de la carga.
        /// </summary
        private void txtCodigoManifiesto_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnGuardarManifiesto;
        }

        /// <summary>
        /// Se selecciona otro manifiesto de la lista de manifiestos.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                _manifiesto = (ManifiestoATMCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;

                pnlDatosManifiesto.Enabled = true;

                this.mostrarDatosManifiesto();
            }
            else
            {
                pnlDatosManifiesto.Enabled = false;

                this.limpiarDatosManifiesto();
            }

        }

        /// <summary>
        /// Se selecciona otro manifiesto full de la lista de manifiestos full.
        /// </summary>
        private void dgvManifiestosFull_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestosFull.SelectedRows.Count > 0)
            {
                _manifiesto_full = (ManifiestoATMFull)dgvManifiestosFull.SelectedRows[0].DataBoundItem;

                pnlDatosManifiestoFull.Enabled = true;

                this.mostrarDatosmanifiestoFull();
            }
            else
            {
                pnlDatosManifiestoFull.Enabled = false;

                this.limpiarDatosManifiestoFull();
            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de asignar una bolsa de rechazo.
        /// </summary>
        private void chkBolsaRechazo_CheckedChanged(object sender, EventArgs e)
        {

            if (chkBolsaRechazo.Checked)
            {
                txtBolsaAdicionalRechazo.Enabled = true;
                txtBolsaAdicionalRechazo.BackColor = Color.PaleGreen;
            }
            else
            {
                txtBolsaAdicionalRechazo.Enabled = false;
                txtBolsaAdicionalRechazo.BackColor = SystemColors.Control;
            }

        }

        /// <summary>
        /// Se imprime los manifiestos.
        /// </summary>
        private void pdManifiesto_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.imprimir(e);
        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del marchamo.
        /// </summary>
        private void txtMarchamo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del código del manifiesto.
        /// </summary>
        private void txtMarchamoAdicional_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del número de la bolsa de rechazo.
        /// </summary>
        private void txtBolsaAdicionalRechazo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del código del manifiesto.
        /// </summary>
        private void txtCodigoManifiesto_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del marchamo del atm full.
        /// </summary>
        private void txtMarchamoFull_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del marchamo adicional del ENA.
        /// </summary>
        private void txtMarchamoAdicionalENA_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del primer marchamo del ENA.
        /// </summary>
        private void txtMarchamoENAA_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del segundo marchamo del ENA.
        /// </summary>
        private void txtMarchamoENAB_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        /// <summary>
        /// Se presiona la tecla de enter en el campo del código del manifiesto del atm full.
        /// </summary>
        private void txtCodigoManifiestoFull_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }




        /// <summary>
        /// Marca el check de manifiesto full
        /// </summary>
        private void chkBolsaRechazoFull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBolsaRechazoFull.Checked)
            {
                txtBolsaRechazoFull.Enabled = true;
                txtBolsaRechazoFull.BackColor = Color.PaleGreen;
            }
            else
            {
                txtBolsaRechazoFull.Enabled = false;
                txtBolsaRechazoFull.BackColor = SystemColors.Control;
            }
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Imprimir los datos de un manifiesto.
        /// </summary>
        private void imprimir(PrintPageEventArgs e)
        {
            Font _fuente = new Font("Arial", 10);
            Font _fuente_pequena = new Font("Arial", 7);
            Font _fuente_grande = new Font("Arial", 14);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            ATM atm = _carga.ATM;

            TipoCambio _tipocambio = _mantenimiento.obtenerTipoCambio(_carga.Fecha_asignada);

            // Imprimir los datos fijos

            e.Graphics.DrawString("Cargas ATM's", _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); // Origen de los fondos
            e.Graphics.DrawString("BAC San José", _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); // Recibo de
            e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0)); // Dirección
            e.Graphics.DrawString("Curridabat", _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0)); // Ciudad
            e.Graphics.DrawString("San josé", _fuente, Brushes.Black, _esquema.obtenerPunto(7, 0)); // Provincia
            e.Graphics.DrawString(_carga.Cierre.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(22, 0)); // Encargado
            e.Graphics.DrawString(_carga.Fecha_asignada.ToString("dd/MM/yy"), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); // Fecha

            int venta = 1;
            if (_tipocambio != null) { }
            else
                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));

            string GranTotal = "CRC " + (_carga.Monto_carga_colones + (_carga.Monto_carga_dolares * (_tipocambio.Venta))).ToString("N2");

            string montototal = "";

            montototal = Convert.ToInt32((_carga.Monto_carga_colones + (_carga.Monto_carga_dolares * (_tipocambio.Venta)))).ToString();

            //Conviete el gran total en letras.
            string GranTotalLetras = _coordinacion.convertirMontoaLetras(montototal) + "COLONES";
           


            if (atm == null)
            {
                string destino = _carga.ToString() + " R " + _carga.Ruta;

                e.Graphics.DrawString(destino, _fuente_grande, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Cliente
            }
            else
            {
                string posicion = _carga.Orden_ruta == null ? " - N/A" : " - " + _carga.Orden_ruta + 1;
                string destino = "ATM # " + atm.Numero + " R " + _carga.Ruta + posicion;

                e.Graphics.DrawString(destino, _fuente_grande, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Cliente
                e.Graphics.DrawString(atm.Oficinas, _fuente_pequena, Brushes.Black, _esquema.obtenerPunto(10, 0)); // Oficinas

                string direccion;
                Provincias provincia;

                if (atm.Ubicacion != null)
                {
                    direccion = atm.Ubicacion.ToString();
                    provincia = atm.Ubicacion.Provincia;
                }
                else
                {
                    direccion = atm.Sucursal.Nombre;
                    provincia = atm.Sucursal.Provincia;
                }

                string nombre_provincia;

                switch (provincia)
                {
                    case Provincias.Limon:
                        nombre_provincia = "Limón";
                        break;
                    case Provincias.SanJose:
                        nombre_provincia = "San José";
                        break;
                    default:
                        nombre_provincia = Enum.GetName(typeof(Provincias), provincia);
                        break;
                }

                e.Graphics.DrawString(direccion, _fuente, Brushes.Black, _esquema.obtenerPunto(11, 0)); // Dirección
                e.Graphics.DrawString(nombre_provincia, _fuente, Brushes.Black, _esquema.obtenerPunto(12, 0)); // Ciudad
                e.Graphics.DrawString(nombre_provincia, _fuente, Brushes.Black, _esquema.obtenerPunto(13, 0)); // Provincia
            }

            e.Graphics.DrawString("T", _fuente, Brushes.Black, _esquema.obtenerPunto(15, 0)); // BT
            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(16, 0)); // Bultos
            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(19, 0)); // Total de Bultos

            int depositos = _carga.Cartuchos.Count + (_carga.Cartucho_rechazo ? 1 : 0);

            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(21, 0)); // Manifiestos

            if (_siguiente_full)
            {
                e.Graphics.DrawString("0", _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Tipo de Cambio
                e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Depositos

                e.Graphics.DrawString(txtMarchamoFull.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(14, 0)); // Marchamo
                e.Graphics.DrawString("N/A", _fuente, Brushes.Black, _esquema.obtenerPunto(17, 0)); // Monto
                e.Graphics.DrawString("N/A", _fuente, Brushes.Black, _esquema.obtenerPunto(20, 0)); // Total Monto
            }
            else
            {
                PointF posicion_monto_colones = _esquema.obtenerPunto(17, 0);
                PointF posicion_monto_dolares = _esquema.obtenerPunto(17, 1);

                TipoCambio tip = _mantenimiento.obtenerTipoCambio(_carga.Fecha_asignada);

                e.Graphics.DrawString (_tipocambio.Venta.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Tipo de Cambio
                e.Graphics.DrawString(depositos.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Depositos

                e.Graphics.DrawString(txtMarchamo.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(14, 0)); // Marchamo
                e.Graphics.DrawString("C " + _carga.Monto_carga_colones.ToString("N2"), _fuente, Brushes.Black, posicion_monto_colones); // Monto en Colones
                e.Graphics.DrawString("$ " + _carga.Monto_carga_dolares.ToString("N2"), _fuente, Brushes.Black, posicion_monto_dolares); // Monto en Dólares
                e.Graphics.DrawString(GranTotal, _fuente, Brushes.Black, _esquema.obtenerPunto(20, 0)); // Total Monto
                e.Graphics.DrawString(GranTotalLetras, _fuente_pequena, Brushes.Black, _esquema.obtenerPunto(23, 0)); // Total Monto en Letras
            }

        }

        /// <summary>
        /// Limpiar los datos mostrados del manifiesto de carga.
        /// </summary>
        private void limpiarDatosManifiesto()
        {
            btnCancelarManifiesto.Enabled = true;
            btnGuardarManifiesto.Enabled = true;

            txtCodigoManifiesto.Text = string.Empty;
            txtMarchamo.Text = string.Empty;
            txtMarchamoAdicional.Text = string.Empty;
            txtBolsaAdicionalRechazo.Text = string.Empty;

            this.validarSeleccionManifiestos();
        }

        /// <summary>
        /// Limpiar los datos mostrados del manifiesto de full.
        /// </summary>
        private void limpiarDatosManifiestoFull()
        {
            btnCancelarManifiestoFull.Enabled = true;
            btnGuardarManifiestoFull.Enabled = true;

            txtCodigoManifiestoFull.Text = string.Empty;
            txtMarchamoFull.Text = string.Empty;
            txtMarchamoAdicionalENA.Text = string.Empty;
            txtMarchamoENAA.Text = string.Empty;
            txtMarchamoENAB.Text = string.Empty;
            txtBolsaRechazoFull.Text = string.Empty;
            
            this.validarSeleccionManifiestos();
        }

        /// <summary>
        /// Mostrar los datos del manifiesto de carga seleccionado.
        /// </summary>
        private void mostrarDatosManifiesto()
        {
            btnCancelarManifiesto.Enabled = false;
            btnGuardarManifiesto.Enabled = true;

            txtCodigoManifiesto.Text = _manifiesto.Codigo;
            txtMarchamo.Text = _manifiesto.Marchamo;
            txtMarchamoAdicional.Text = _manifiesto.Marchamo_adicional;

            if (_manifiesto.Bolsa_rechazo == null)
            {
                chkBolsaRechazo.Checked = false;

                txtBolsaAdicionalRechazo.Text = string.Empty;
                txtBolsaAdicionalRechazo.BackColor = SystemColors.Control;
            }
            else
            {
                chkBolsaRechazo.Checked = true;

                txtBolsaAdicionalRechazo.Text = _manifiesto.Bolsa_rechazo;
                txtBolsaAdicionalRechazo.BackColor = Color.PaleGreen;
            }

            this.validarSeleccionManifiestos();
        }

        /// <summary>
        /// Mostrar los datos del manifiesto full seleccionado.
        /// </summary>
        private void mostrarDatosmanifiestoFull()
        {
            btnCancelarManifiestoFull.Enabled = false;
            btnGuardarManifiestoFull.Enabled = true;

            txtCodigoManifiestoFull.Text = _manifiesto_full.Codigo;
            txtMarchamoFull.Text = _manifiesto_full.Marchamo;
            txtBolsaRechazoFull.Text = _manifiesto_full.Bolsa_rechazo;

            if (_carga.ENA)
            {
                txtMarchamoAdicionalENA.Text = _manifiesto_full.Marchamo_adicional_ena;
                txtMarchamoENAA.Text = _manifiesto_full.Marchamo_ena_a;
                txtMarchamoENAB.Text = _manifiesto_full.Marchamo_ena_b;

                txtMarchamoAdicionalENA.BackColor = Color.PeachPuff;
                txtMarchamoENAA.BackColor = Color.PeachPuff;
                txtMarchamoENAB.BackColor = Color.PeachPuff;
            }
            else
            {
                if(_carga.Emergencia > 0)
                {
                    txtMarchamoAdicionalENA.Text = _manifiesto_full.Marchamo_adicional_ena;
                    txtMarchamoENAA.Text = _manifiesto_full.Marchamo_ena_a;
                    txtMarchamoENAB.Text = _manifiesto_full.Marchamo_ena_b;

                    txtMarchamoAdicionalENA.BackColor = Color.PeachPuff;
                    txtMarchamoENAA.BackColor = Color.PeachPuff;
                    txtMarchamoENAB.BackColor = Color.PeachPuff;
                }
                else
                {
                    txtMarchamoAdicionalENA.Text = string.Empty;
                    txtMarchamoENAA.Text = string.Empty;
                    txtMarchamoENAB.Text = string.Empty;

                    txtMarchamoAdicionalENA.BackColor = SystemColors.Control;
                    txtMarchamoENAA.BackColor = SystemColors.Control;
                    txtMarchamoENAB.BackColor = SystemColors.Control;
                }
                
            }

            this.validarSeleccionManifiestos();
        }

        /// <summary>
        /// Validar la selección de los manifiestos.
        /// </summary>
        private void validarSeleccionManifiestos()
        {

            if (_carga != null)
                btnAceptar.Enabled = (!_carga.ATM_full || _manifiesto_full != null) || _manifiesto != null;

        }

        #endregion Métodos Privados

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }


        

    }

}
