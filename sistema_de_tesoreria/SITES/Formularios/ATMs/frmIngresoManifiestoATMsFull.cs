//
//  @ Project : 
//  @ File Name : frmIngresoManifiestoATMsFull.cs
//  @ Date : 06/03/2013
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

    public partial class frmIngresoManifiestoATMsFull : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private EsquemaManifiesto _esquema = null;
        private ManifiestoATMFull _manifiesto_full = null;

        private DateTime _fecha;
        private bool _ena = false;

        #endregion Atributos

        #region Constructor

        public frmIngresoManifiestoATMsFull(ManifiestoATMFull manifiesto, bool ena, DateTime fecha)
        {
            InitializeComponent();

            _manifiesto_full = manifiesto;
            _fecha = fecha;
            _ena = ena;

            try
            {
                dgvManifiestos.AutoGenerateColumns = false;

                BindingList<ManifiestoATMFull> manifiestos = new BindingList<ManifiestoATMFull>();

                dgvManifiestos.DataSource = manifiestos;

                if (_manifiesto_full != null)
                    manifiestos.Add(_manifiesto_full);

                pnlENA.Enabled = _ena;

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
        /// Clic en el botón de guardar un  manifiesto de full.
        /// </summary>
        private void btnGuardarManifiesto_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan especificado los datos del manifiesto

            if (txtCodigoManifiesto.Text.Equals(string.Empty) || txtCodigoManifiesto.Text.Length < 4 ||
                txtMarchamo.Text.Equals(string.Empty) || (_ena && (txtMarchamoAdicionalENA.Text.Equals(string.Empty) ||
                txtMarchamoENAA.Text.Equals(string.Empty) || txtMarchamoENAB.Text.Equals(string.Empty))))
            {
                Excepcion.mostrarMensaje("ErrorManifiestoATMFullDatosRegistro");
                return;
            }

            try
            {
                string codigo = txtCodigoManifiesto.Text;
                string marchamo = txtMarchamo.Text;

                string marchamo_adicional_ena = null;
                string marchamo_ena_a = null;
                string marchamo_ena_b = null;

                string bolsa_rechazo = chkBolsaRechazoFull.Checked ?
                    txtBolsaRechazoFull.Text : null;

                if (_ena)
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
                        ManifiestoATMFull nuevo = new ManifiestoATMFull(codigo, marchamo, _fecha, marchamo_adicional_ena, marchamo_ena_a,
                                                                        marchamo_ena_b, bolsa_rechazo);

                        _atencion.agregarManifiestoATMFull(ref nuevo);

                        // Agregar el manifiesto a la lista de manifiestos

                        BindingList<ManifiestoATMFull> manifiestos = (BindingList<ManifiestoATMFull>)dgvManifiestos.DataSource;

                        manifiestos.Add(nuevo);

                        Mensaje.mostrarMensaje("MensajeManifiestoATMFullConfirmacionRegistro");

                        btnCancelarManifiesto.Enabled = false;
                        btnAceptar.Enabled = true;
                    }

                }
                else
                {
                    ManifiestoATMFull copia = new ManifiestoATMFull(codigo, marchamo, _fecha, marchamo_adicional_ena, marchamo_ena_a,
                                                                    marchamo_ena_b, bolsa_rechazo, id: _manifiesto_full.ID);

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
        /// Clic en el botón de Buscar un manifiesto full.
        /// </summary>
        private void btnBuscarManifiesto_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoManifiestoBuscado.Text;

                if (codigo == string.Empty && codigo.Length < 4)
                    return;

                dgvManifiestos.DataSource = _atencion.listarManifiestosATMsFullPorCodigo(codigo);

                txtCodigoManifiestoBuscado.Text = string.Empty;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar un manifiesto full.
        /// </summary>
        private void btnNuevoManifiesto_Click(object sender, EventArgs e)
        {
            _manifiesto_full = null;

            pnlDatosManifiesto.Enabled = true;
            txtMarchamo.Select();

            this.limpiarDatosManifiesto();
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmModificacionCargaEmergenciaFull padre = (frmModificacionCargaEmergenciaFull)this.Owner;
            ManifiestoATMFull manifiesto = (ManifiestoATMFull)dgvManifiestos.SelectedRows[0].DataBoundItem;

            padre.seleccionarManifiesto(manifiesto);

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

                pdManifiesto.Print();
            }

        }

        /// <summary>
        /// Clic en el botón de cancelar el registro de un manifiesto full.
        /// </summary>
        private void btnCancelarManifiesto_Click(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                _manifiesto_full = (ManifiestoATMFull)dgvManifiestos.SelectedRows[0].DataBoundItem;

                this.mostrarDatosmanifiestoFull();
            }
            else
            {
                pnlDatosManifiesto.Enabled = false;

                this.limpiarDatosManifiesto();
            }

        }

        /// <summary>
        /// Se escribe en el texto de búsqueda de los manifiestos full.
        /// </summary>
        private void txtCodigoManifiestoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscarManifiesto.Enabled = txtCodigoManifiestoBuscado.Text.Length >= 4;
        }

        /// <summary>
        /// Se selecciona el control del texto de búsqueda de los manifiestos full.
        /// </summary>
        private void txtCodigoManifiestoBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscarManifiesto;
        }

        /// <summary>
        /// Se selecciona el control del texto del manifiesto de la carga.
        /// </summary
        private void txtCodigoManifiesto_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnGuardarManifiesto;
        }

        /// <summary>
        /// Se selecciona otro manifiesto full de la lista de manifiestos full.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                _manifiesto_full = (ManifiestoATMFull)dgvManifiestos.SelectedRows[0].DataBoundItem;

                pnlDatosManifiesto.Enabled = true;

                this.mostrarDatosmanifiestoFull();
            }
            else
            {
                pnlDatosManifiesto.Enabled = false;

                this.limpiarDatosManifiesto();
            }

        }
        
        /// <summary>
        /// Se imprime el manifiesto.
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
        private void txtCodigoManifiesto_KeyDown(object sender, KeyEventArgs e)
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

            // Imprimir los datos fijos

            e.Graphics.DrawString("Cargas ATM's", _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); // Origen de los fondos
            e.Graphics.DrawString("BAC San José", _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); // Recibo de
            e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0)); // Dirección
            e.Graphics.DrawString("Curridabat", _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0)); // Ciudad
            e.Graphics.DrawString("San josé", _fuente, Brushes.Black, _esquema.obtenerPunto(7, 0)); // Provincia

            e.Graphics.DrawString("T", _fuente, Brushes.Black, _esquema.obtenerPunto(15, 0)); // BT
            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(16, 0)); // Bultos
            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(19, 0)); // Total de Bultos
            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(21, 0)); // Manifiestos

            e.Graphics.DrawString("0", _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Tipo de Cambio
            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Depositos

            e.Graphics.DrawString(txtMarchamo.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(14, 0)); // Marchamo
            e.Graphics.DrawString("N/A", _fuente, Brushes.Black, _esquema.obtenerPunto(17, 0)); // Monto
            e.Graphics.DrawString("N/A", _fuente, Brushes.Black, _esquema.obtenerPunto(20, 0)); // Total Monto
        }

        /// <summary>
        /// Limpiar los datos mostrados del manifiesto de full.
        /// </summary>
        private void limpiarDatosManifiesto()
        {
            btnCancelarManifiesto.Enabled = true;
            btnGuardarManifiesto.Enabled = true;
            btnAceptar.Enabled = false;

            txtCodigoManifiesto.Text = string.Empty;
            txtMarchamo.Text = string.Empty;
            txtMarchamoAdicionalENA.Text = string.Empty;
            txtMarchamoENAA.Text = string.Empty;
            txtMarchamoENAB.Text = string.Empty;
        }

        /// <summary>
        /// Mostrar los datos del manifiesto full seleccionado.
        /// </summary>
        private void mostrarDatosmanifiestoFull()
        {
            btnCancelarManifiesto.Enabled = false;
            btnGuardarManifiesto.Enabled = true;
            btnAceptar.Enabled = true;

            txtCodigoManifiesto.Text = _manifiesto_full.Codigo;
            txtMarchamo.Text = _manifiesto_full.Marchamo;

            if (_ena)
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

        #endregion Métodos Privados

    }

}
