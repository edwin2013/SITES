﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects;
using GUILayer.Formularios.Blindados;
using System.Globalization;
using System.Drawing.Printing;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmIngresoManifiestoSucursal : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _usuario = null;
        private CargaSucursal _carga = null;

        private BindingList<Bolsa> _bolsas = null;

        private BindingList<ManifiestoSucursalCarga> _manifiesto = null;
        private ManifiestoSucursalCarga _manifiesto_unico = null;
        private ManifiestoSucursalCarga _nuevo_manifiesto = new ManifiestoSucursalCarga();
        private ManifiestoSucursalCarga _nuevo_manifiesto2 = new ManifiestoSucursalCarga();
        private frmPedidoSucursales _padre = null;
        private DataGridViewRow _fila = null;
        private BindingList<Denominacion> _denominaciones = new BindingList<Denominacion>();
        private Bolsa _bolsa_anterio = new Bolsa();
        Decimal valor_50000colones = 0;
        Decimal valor_20000colones = 0;
        Decimal valor_10000colones = 0;
        Decimal valor_5000colones = 0;
        Decimal valor_2000colones = 0;
        Decimal valor_1000colones = 0;
        Decimal valor_500colones = 0;
        Decimal valor_100colones = 0;
        Decimal valor_50colones = 0;
        Decimal valor_25colones = 0;
        Decimal valor_10colones = 0;
        Decimal valor_5colones = 0;
        Decimal valor_100dolares = 0;
        Decimal valor_50dolares = 0;
        Decimal valor_20dolares = 0;
        Decimal valor_10dolares = 0;
        Decimal valor_5dolares = 0;
        Decimal valor_1dolares = 0;
        Decimal valor_500euros = 0;
        Decimal valor_200euros = 0;
        Decimal valor_100euros = 0;
        Decimal valor_50euros = 0;
        Decimal valor_20euros = 0;
        Decimal valor_10euros = 0;
        Decimal valor_5euros = 0;
        Decimal _total_valor_colones = 0;
        Decimal _total_valor_dolares = 0;
        Decimal _total_valores_euros = 0;
        int _auxiliar = 0;

        private decimal _monto = 0;

        private bool _impresion_carga = false;

        private EsquemaManifiesto _esquema = null;
        int series = 0;

        #endregion Atributos

        #region Constructor

        public frmIngresoManifiestoSucursal(ref CargaSucursal carga)
        {
            InitializeComponent();

            _carga = carga;


            try
            {


                this.crearTabla(dgvMontos);

                // Dar fomato a las filas

                this.formatoCeldaSoloLectura(dgvMontos, 13, 21, 30);

                this.formatoCeldaSeparador(dgvMontos, 0, 14, 22);



            if(carga.Transportadora != null)
                txtTransportadora.Text = carga.Transportadora.ToString();

            _denominaciones = _mantenimiento.listarDenominaciones();
            _esquema = _mantenimiento.listarEsquemasManifiestoTransportadora(_carga.Transportadora);

            _manifiesto = carga.Manifiesto;
            if (_manifiesto == null)
            {
                _manifiesto = new BindingList<ManifiestoSucursalCarga>();
                carga.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
            }
            btnGuardarManifiesto.Enabled = true;
            btnGuardarTula.Enabled = true;
            btnBuscar.Enabled = false;


                // Establecer el separador de decimales

                CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
                CultureInfo nueva = (CultureInfo)anterior.Clone();

                nueva.NumberFormat.NumberDecimalSeparator = ".";
                nueva.NumberFormat.NumberGroupSeparator = ",";
                System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

                CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;


                txtFecha.Text = carga.Fecha_verificacion.ToShortDateString();

                BindingList<ManifiestoSucursalCarga> manifiestos = new BindingList<ManifiestoSucursalCarga>();

                BindingList<Bolsa> bolsas = new BindingList<Bolsa>();


                dgvBolsas.AutoGenerateColumns = false;
                dgvBolsas.DataSource = bolsas;

                dgvManifiestos.AutoGenerateColumns = false;

                dgvManifiestos.DataSource = manifiestos;

                dgvManifiestosAsignados.AutoGenerateColumns = false;
                dgvManifiestosAsignados.DataSource = manifiestos;

                dgvBolsas.AutoGenerateColumns = false;

                Decimal monto_col = 0;
                Decimal monto_dol = 0;
                Decimal monto_eur = 0;

                if (_manifiesto.Count > 0)
                {
                    foreach (ManifiestoSucursalCarga manifies in _manifiesto)
                    {

                        ManifiestoSucursalCarga man = manifies;
                        foreach (Bolsa b in man.ListaBolsas)
                        {
                            monto_col = monto_col + b.MontoColones;
                            monto_dol = monto_dol + b.MontoDolares;
                            monto_eur = monto_eur + b.MontoEuros;
                        }

                    }
                }




                btnGuardarManifiesto.Enabled = true;
                btnAceptar.Enabled = false;
                pnlDatosManifiesto.Enabled = false;

                if (_carga.ID != 0)
                {

                    if (_carga.Monto_asignado_colones == 0)
                        clMontoColones.ReadOnly = true;
                    if (_carga.Monto_asignado_dolares == 0)
                        clmMontoDolares.ReadOnly = true;
                    if (_carga.Monto_asignado_euros == 0)
                        clmMontoEuros.ReadOnly = true;
                }


                lblCantidadColones.Text = (_carga.Monto_asignado_colones - monto_col).ToString("N0");
                lblCantidadDolares.Text = (_carga.Monto_asignado_dolares - monto_dol).ToString("N0");
                lblCantidadEuros.Text = (_carga.Monto_asignado_euros - monto_eur).ToString("N0");

                if (_manifiesto.Count > 0)
                    btnCancelarManifiesto.Enabled = true;

                _monto = _carga.Monto_carga_colones + _carga.Monto_carga_dolares + _carga.Monto_carga_euros;


                if (carga.Manifiesto.Count > 0)
                    this.llenarCampos(carga);


                this.validarDenominacionesaMostrar(carga);


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

            try
            {
                DateTime fecha = _carga.Fecha_asignada;

                // Verificar si el manifiesto es nuevo
                dgvManifiestos.DataSource = _manifiesto;
                dgvBolsas.DataSource = _bolsas;
                lblNumeroManifiesto.Text = string.Empty;
                txtCodigoManifiestoBuscado.Text = string.Empty;
                txtFecha.Text = fecha.ToShortDateString();

                //if (_manifiesto == null)
                //{

                if (Mensaje.mostrarMensajeConfirmacion("MensajeManifiestoSucursalCargaRegistro") == DialogResult.Yes)
                {
                    ManifiestoSucursalCarga nuevo = new ManifiestoSucursalCarga();

                    // nuevo. = _carga.Cajero;

                    _atencion.agregarManifiestoSucursalCarga(ref nuevo);

                    // Agregar el manifiesto a la lista de manifiestos

                    BindingList<ManifiestoSucursalCarga> manifiestos = new BindingList<ManifiestoSucursalCarga>();
                    manifiestos.Add(nuevo);

                    dgvManifiestos.DataSource = _atencion.listarManifiestosSucursalCargasPorCodigo(nuevo.ToString());
                    dgvManifiestos.DataSource = manifiestos;
                    _manifiesto_unico = nuevo;

                    lblNumeroManifiesto.Text = nuevo.ToString();

                    txtCodigoManifiestoBuscado.Text = nuevo.ToString();

                    btnCancelarManifiesto.Enabled = true;
                    btnGuardarManifiesto.Enabled = false;
                    pnlDatosManifiesto.Enabled = true;

                    Mensaje.mostrarMensaje("MensajeManifiestoSucursalCargaConfirmacionRegistro");

                }

                //}
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Cambio en el texto de los datos
        /// </summary>
        private void lblCantidadColones_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal montocolones = Convert.ToDecimal(lblCantidadColones.Text);
                Decimal montodolares = Convert.ToDecimal(lblCantidadDolares.Text);
                Decimal montoeuros = Convert.ToDecimal(lblCantidadEuros.Text);

                if (montocolones == 0 && montodolares == 0 && montoeuros == 0)
                {
                    btnAceptar.Enabled = true;
                }
                else
                    btnAceptar.Enabled = false;

            }
            catch (Excepcion ex)
            {

            }
        }



        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            BindingList<ManifiestoSucursalCarga> manifiesto = (BindingList<ManifiestoSucursalCarga>)dgvManifiestosAsignados.DataSource;



            _carga.Manifiesto = manifiesto;

            if (_carga.ID != 0)
                _atencion.actualizarManifiestoSucursalCarga(ref _carga);
            else
            {
                frmPedidoSucursales padre = (frmPedidoSucursales)this.Owner;
                padre.actualizarManifiestos(manifiesto);
            }


            //foreach(ManifiestoSucursalCarga m in manifiesto)
            //{
            //    ManifiestoSucursalCarga copia = m;
            //    _atencion.listarBolsasBancoPorManifiesto(ref copia);
            //}

            // _atencion.agregarBolsacarga


            //padre.seleccionarManifiestosCargaBancos(manifiesto,bolsas);

            limpiarDatosManifiesto();

            this.Close();
        }


        /// <summary>
        /// Clic en el botón de cancelar el registro de un manifiesto de carga.
        /// </summary>
        private void btnCancelarManifiesto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el Manifiesto", "ConfimaEliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;

                _atencion.eliminarManifiestoSucursalCarga(manifiesto);

                Bolsa nuevabolsa = new Bolsa();
                limpiarDatosManifiesto();
                dgvManifiestos.SelectAll();
                dgvManifiestos.ClearSelection();
                _manifiesto = null;
                dgvManifiestos.DataSource = _manifiesto;

                dgvBolsas.SelectAll();
                dgvBolsas.ClearSelection();
                _bolsas = null;
                dgvBolsas.DataSource = _bolsas;


                MessageBox.Show(" Manifiesto Eliminado! ");
                mostrarDatosManifiesto();


            }

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;


                this.mostrarDatosManifiesto();
            }
            else
            {
                this.limpiarDatosManifiesto();
            }

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
                ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;

                //pnlDatosManifiesto.Enabled = true;
                btnAsignarManifiesto.Enabled = true;
                btnCancelarManifiesto.Enabled = true;
                //this.mostrarDatosManifiesto();
            }
            else
            {
                //pnlDatosManifiesto.Enabled = false;
                btnAsignarManifiesto.Enabled = false;
                btnCancelarManifiesto.Enabled = false;
                this.limpiarDatosManifiesto();
            }

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
        /// Se escribe en el texto de búsqueda de los manifiestos de carga.
        /// </summary>
        private void txtCodigoManifiestoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtCodigoManifiestoBuscado.Text.Length >= 2;
        }




        /// <summary>
        /// Elimina una tula seleccionada
        /// </summary>
        private void btnElimarTula_Click(object sender, EventArgs e)
        {
            if (dgvBolsas.SelectedRows == null)
            {
                MessageBox.Show("Seleccione la tula a eliminar.");


            }
            else
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeTulaEliminacion") == DialogResult.Yes)
                {

                    DataGridViewRow fila = dgvBolsas.Rows[dgvBolsas.SelectedCells[0].RowIndex];

                    Bolsa bolsita = (Bolsa)fila.DataBoundItem;

                    _atencion.eliminarBolsaSucursal(bolsita);

                    lblCantidadColones.Text = (Convert.ToDecimal(lblCantidadColones.Text) + bolsita.MontoColones).ToString("N0");
                    lblCantidadDolares.Text = (Convert.ToDecimal(lblCantidadDolares.Text) + bolsita.MontoDolares).ToString("N0");
                    lblCantidadEuros.Text = (Convert.ToDecimal(lblCantidadEuros.Text) + bolsita.MontoEuros).ToString("N0");

                    dgvBolsas.Rows.Remove(fila);

                    dgvBolsas.Refresh();
                }




            }

        }


        /// <summary>
        /// Clic en el boton de Salir
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gbBusquedaManifiestos_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Clic en el boton de buqueda de manifiestos por codigo
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigoManifiestoBuscado.Text;

                _atencion.listarManifiestosSucursalCargasPorCodigo(codigo);



                if (_atencion.listarManifiestosSucursalCargasPorCodigo(codigo).Count == 0)
                {
                    MessageBox.Show(" No se encontro manifiesto ");
                    dgvManifiestos.DataSource = _manifiesto;
                    dgvBolsas.DataSource = _bolsas;
                    lblNumeroManifiesto.Text = string.Empty;
                    _manifiesto = null;
                    btnGuardarManifiesto.Enabled = true;
                }
                else
                {
                    dgvManifiestos.DataSource = _atencion.listarManifiestosSucursalCargasPorCodigo(codigo);

                    _manifiesto_unico = (ManifiestoSucursalCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;

                    lblNumeroManifiesto.Text = codigo;
                    dgvBolsas.Enabled = true;

                    Bolsa nuevabolsa = new Bolsa();
                    _manifiesto_unico.ListaBolsas = _atencion.listarBolsasSucursalPorManifiesto(_manifiesto_unico);
                    //nuevalista.Add(nuevabolsa);
                    // dgvBolsas.DataSource = _manifiesto_unico.Serie_Tula;

                    txtCodigoManifiestoBuscado.Text = string.Empty;
                    btnCancelarManifiesto.Enabled = true;
                    btnElimarTula.Enabled = true;
                    _manifiesto = null;

                }


            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Guarda la tula 
        /// </summary>
        private void btnGuardarTula_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSerieTula.Text == "")
                {
                    MessageBox.Show("Digite el numero de Tula");
                }
                else
                {
                    //_manifiesto_unico.Serie_Tula = (BindingList<Bolsa>)dgvBolsas.DataSource;

                    BindingList<Bolsa> bolsitas = (BindingList<Bolsa>)dgvBolsas.DataSource;

                    Bolsa bolsa_banco = new Bolsa();
                    bolsa_banco.SerieBolsa = txtSerieTula.Text;

                    //if (_manifiesto_unico.Serie_Tula == null)
                    //    _manifiesto_unico.Serie_Tula = new BindingList<Bolsa>();

                    bolsitas.Add(bolsa_banco);

                    dgvBolsas.DataSource = bolsitas;

                    this.txtSerieTula.Text = string.Empty;
                    this.txtSerieTula.Focus();

                    this.limpiarDatosTabla(dgvMontos, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 15, 16, 17, 18, 19, 20, 23, 24, 25, 26, 27, 28, 29);

                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }


        }




        /// <summary>
        /// Se selecciona otro manifiesto de la lista de manifiestos por asignar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvManifiestosAsignados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManifiestosAsignados.SelectedRows.Count > 0)
            {
                gbDatosManifiesto.Enabled = true;

                btnDesAsignarManifiesto.Enabled = true;
                pnlDatosManifiesto.Enabled = true;
                btnImprimir.Enabled = true;
                btnImprimirRecap.Enabled = true; 
                //btnAsignarManifiesto.Enabled = true;



                if (dgvManifiestosAsignados.Rows.Count > 0)
                {
                    _nuevo_manifiesto = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;
                }
                BindingList<ManifiestoSucursalCarga> manifiestos = new BindingList<ManifiestoSucursalCarga>();
                manifiestos = (BindingList<ManifiestoSucursalCarga>)dgvManifiestosAsignados.DataSource;
                bool lleno = false;


                foreach (ManifiestoSucursalCarga man in manifiestos)
                {
                    if (man.ListaBolsas == null)
                        man.ListaBolsas = new BindingList<Bolsa>();
                    if (man.ListaBolsas.Count > 0)
                        lleno = true;
                    else
                        lleno = false;
                }


                dgvBolsas.DataSource = _nuevo_manifiesto.ListaBolsas;

                if (lleno && Convert.ToDecimal(lblCantidadColones.Text) == 0 && Convert.ToDecimal(lblCantidadDolares.Text) == 0 && Convert.ToDecimal(lblCantidadEuros.Text) == 0)
                    btnAceptar.Enabled = lleno;

                this.mostrarDatosManifiesto();
            }
            else
            {
                pnlDatosManifiesto.Enabled = false;
                btnAsignarManifiesto.Enabled = false;
                gbDatosManifiesto.Enabled = false;
                btnDesAsignarManifiesto.Enabled = false;
                btnImprimir.Enabled = false;
                btnImprimirRecap.Enabled = false;
                this.limpiarDatosManifiesto();
            }
        }

        /// <summary>
        /// Clic en el boton de asignar un manifiesto
        /// </summary>
        private void btnAsignarManifiesto_Click(object sender, EventArgs e)
        {
            this.asignarManifiesto(dgvManifiestos.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en desasignar un manifiesto
        /// </summary>
        private void btnDesAsignarManifiesto_Click(object sender, EventArgs e)
        {
            this.desasignar(dgvManifiestosAsignados.SelectedRows[0]);
        }



        /// <summary>
        /// Modificacion del valor de la celda
        /// </summary>
        private void dgvBolsas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBolsas.RowCount > 0)
            {
                DataGridViewRow fila = dgvBolsas.Rows[e.RowIndex];

                if (this.actualizarMontos(fila))
                {
                    this.actualizarListas();
                    this.actualizarDatos(fila);
                }
                else
                    Excepcion.mostrarMensaje("ErrorCantidadDigitos");

                dgvBolsas.Refresh();
            }
        }


        /// <summary>
        /// Verifica si los datos son numericos
        /// </summary>
        private void dgvBolsas_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == clMontoColones.Index ||
                e.ColumnIndex == clMontoColones.Index)
                this.validarFormatoNumericoCelda(e);


            if (e.ColumnIndex == clmMontoDolares.Index ||
                e.ColumnIndex == clmMontoDolares.Index)
                this.validarFormatoNumericoCelda(e);


            if (e.ColumnIndex == clmMontoEuros.Index ||
                e.ColumnIndex == clmMontoEuros.Index)
                this.validarFormatoNumericoCelda(e);
        }



        /// <summary>
        /// Dar formato a las celdas
        /// </summary>
        private void dgvBolsas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == clMontoColones.Index ||
            //    e.ColumnIndex == clMontoColones.Index)
            //    e.ToString("")
        }




        /// <summary>
        /// Habilita o inhabilita el boton de eliminar tulas
        /// </summary>
        private void dgvBolsas_SelectionChanged(object sender, EventArgs e)
        {
            this.limpiarDatosTabla(dgvMontos, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 15, 16, 17, 18, 19, 20, 23, 24, 25, 26, 27, 28, 29);

            btnElimarTula.Enabled = dgvBolsas.Rows.Count > 0;

            if (dgvBolsas.SelectedRows.Count > 0)
            {
                gbMontosBolsa.Enabled = dgvBolsas.Rows.Count > 0;

                Bolsa b = (Bolsa)dgvBolsas.SelectedRows[0].DataBoundItem;

                
                if (b.Cartuchos.Count > 0)
                {

                    mostrarDatosMontosBolsas(b);
                }
            }


        }


        /// <summary>
        /// Validar celdas de montos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMontos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // if (e.ColumnIndex == Concepto.Index) return;

            DataGridViewCell celda = dgvMontos[e.ColumnIndex, e.RowIndex];

            if (e.RowIndex > 6)
            {
                decimal valor = 0;

                if (celda.Value.ToString() == null)
                {
                    celda.Value = valor;
                }
                else
                {
                    if (!decimal.TryParse(celda.Value.ToString(), out valor))
                        celda.Value = valor;
                }
                
            }
            else
            {
                decimal valor = 0;

                if (celda.Value == null)
                    celda.Value = valor;
                else
                {

                    if (!decimal.TryParse(celda.Value.ToString(), out valor))
                        celda.Value = valor;
                }
            }

            dgvBolsas.Refresh();


        }


        /// <summary>
        /// Actualiza los montos correspondientes
        /// </summary>
        private void dgvMontos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            BindingList<BolsaMontosSucursales> montos = new BindingList<BolsaMontosSucursales>();
            if (_auxiliar == 1)
            {
                if (dgvBolsas.SelectedRows.Count > 0)
                {

                    try
                    {
                        Bolsa b = (Bolsa)dgvBolsas.SelectedRows[0].DataBoundItem;
                        //b.Cartuchos.Clear();
                        BolsaMontosSucursales bol = new BolsaMontosSucursales();

                        foreach (CartuchoCargaSucursal d in _carga.Cartuchos)
                        {
                            if (d.Denominacion.Moneda == Monedas.Colones)
                            {
                                if (d.Denominacion.Valor == 50000)
                                {
                                    valor_50000colones = Convert.ToDecimal(dgvMontos[Total.Index, 1].Value);
                                    if (valor_50000colones > 0)
                                    {
                                        //bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50000colones);


                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                {
                                                    existe = true;
                                                    c.Cantidad_asignada = valor_50000colones;
                                                }
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50000colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50000colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 20000)
                                {
                                    valor_20000colones = Convert.ToDecimal(dgvMontos[Total.Index, 2].Value);
                                    if (valor_20000colones > 0)
                                    {

                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                {
                                                    existe = true;
                                                    c.Cantidad_asignada = valor_20000colones;
                                                }
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_20000colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_20000colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }

                                }
                                if (d.Denominacion.Valor == 10000)
                                {
                                    valor_10000colones = Convert.ToDecimal(dgvMontos[Total.Index, 3].Value);

                                    if (valor_10000colones > 0)
                                    {

                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                {
                                                    existe = true;

                                                    c.Cantidad_asignada = valor_10000colones;
                                                }
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_10000colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_10000colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }

                                }
                                if (d.Denominacion.Valor == 5000)
                                {
                                    valor_5000colones = Convert.ToDecimal(dgvMontos[Total.Index, 4].Value);
                                    if (valor_5000colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                {
                                                    existe = true;
                                                    c.Cantidad_asignada = valor_5000colones;
                                                }
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_5000colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_5000colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }

                                }
                                if (d.Denominacion.Valor == 2000)
                                {
                                    valor_2000colones = Convert.ToDecimal(dgvMontos[Total.Index, 5].Value);
                                    if (valor_2000colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_2000colones);
                                                b.Cartuchos.Add(bol);
                                            }

                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_2000colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 1000)
                                {
                                    valor_1000colones = Convert.ToDecimal(dgvMontos[Total.Index, 6].Value);
                                    if (valor_1000colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_1000colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_1000colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 500)
                                {
                                    valor_500colones = Convert.ToDecimal(dgvMontos[Total.Index, 7].Value);
                                    if (valor_500colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_500colones);
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_500colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 100)
                                {
                                    valor_100colones = Convert.ToDecimal(dgvMontos[Total.Index, 8].Value);
                                    if (valor_100colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_100colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_100colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 50)
                                {
                                    valor_50colones = Convert.ToDecimal(dgvMontos[Total.Index, 9].Value);
                                    if (valor_50colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 25)
                                {
                                    valor_25colones = Convert.ToDecimal(dgvMontos[Total.Index, 10].Value);
                                    if (valor_25colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_25colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_25colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 10)
                                {
                                    valor_10colones = Convert.ToDecimal(dgvMontos[Total.Index, 11].Value);
                                    if (valor_10colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_10colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_10colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 5)
                                {
                                    valor_5colones = Convert.ToDecimal(dgvMontos[Total.Index, 12].Value);
                                    if (valor_5colones > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_5colones);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_5colones);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                            }

                            if (d.Denominacion.Moneda == Monedas.Dolares)
                            {
                                if (d.Denominacion.Valor == 100)
                                {
                                    valor_100dolares = Convert.ToDecimal(dgvMontos[Total.Index, 15].Value);
                                    if (valor_100dolares > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_100dolares);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_100dolares);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 50)
                                {
                                    valor_50dolares = Convert.ToDecimal(dgvMontos[Total.Index, 16].Value);
                                    if (valor_50dolares > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50dolares);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50dolares);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 20)
                                {
                                    valor_20dolares = Convert.ToDecimal(dgvMontos[Total.Index, 17].Value);
                                    if (valor_20dolares > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_20dolares);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_20dolares);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 10)
                                {
                                    valor_10dolares = Convert.ToDecimal(dgvMontos[Total.Index, 18].Value);
                                    if (valor_10dolares > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_10dolares);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_10dolares);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 5)
                                {
                                    valor_5dolares = Convert.ToDecimal(dgvMontos[Total.Index, 19].Value);
                                    if (valor_5dolares > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_5dolares);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_5dolares);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 1)
                                {
                                    valor_1dolares = Convert.ToDecimal(dgvMontos[Total.Index, 20].Value);
                                    if (valor_1dolares > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_1dolares);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_1dolares);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                            }

                            if (d.Denominacion.Moneda == Monedas.Euros)
                            {
                                if (d.Denominacion.Valor == 500)
                                {
                                    valor_500euros = Convert.ToDecimal(dgvMontos[Total.Index, 23].Value);
                                    if (valor_500euros > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_500euros);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_500euros);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 200)
                                {
                                    valor_200euros = Convert.ToDecimal(dgvMontos[Total.Index, 24].Value);
                                    if (valor_200euros > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_200euros);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_200euros);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 100)
                                {
                                    valor_100euros = Convert.ToDecimal(dgvMontos[Total.Index, 25].Value);
                                    if (valor_100euros > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_100euros);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_100euros);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 50)
                                {
                                    valor_50euros = Convert.ToDecimal(dgvMontos[Total.Index, 26].Value);
                                    if (valor_50euros > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50euros);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_50euros);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 20)
                                {
                                    valor_20euros = Convert.ToDecimal(dgvMontos[Total.Index, 27].Value);
                                    if (valor_20euros > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_20euros);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_20euros);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 10)
                                {
                                    valor_10euros = Convert.ToDecimal(dgvMontos[Total.Index, 28].Value);
                                    if (valor_10euros > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_10euros);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_10euros);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                                if (d.Denominacion.Valor == 5)
                                {
                                    valor_5euros = Convert.ToDecimal(dgvMontos[Total.Index, 29].Value);
                                    if (valor_5euros > 0)
                                    {
                                        if (b.Cartuchos.Count > 0)
                                        {
                                            bool existe = false;

                                            foreach (BolsaMontosSucursales c in b.Cartuchos)
                                            {
                                                if (c.Denominacion.Id == d.Denominacion.Id && c.Cantidad_asignada > 0)
                                                    existe = true;
                                            }

                                            if (!existe)
                                            {
                                                bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_5euros);
                                                b.Cartuchos.Add(bol);
                                            }
                                        }
                                        else
                                        {
                                            bol = new BolsaMontosSucursales(denominacion: d.Denominacion, cantidad_asignada: valor_5euros);
                                            b.Cartuchos.Add(bol);
                                        }
                                    }
                                }
                            }





                            _total_valor_colones = valor_50000colones + valor_20000colones + valor_10000colones + valor_5000colones + valor_2000colones + valor_1000colones
                                + valor_500colones + valor_100colones + valor_50colones + valor_25colones + valor_10colones + valor_5colones;

                            //dgvMontos[Total.Index, 13].Value = _total_valor_colones;


                            _total_valor_dolares = valor_100dolares + valor_50dolares + valor_20dolares + valor_10dolares + valor_5dolares + valor_1dolares;

                            //dgvMontos[Total.Index, 21].Value = _total_valor_dolares;



                            _total_valores_euros = valor_500euros + valor_200euros + valor_100euros + valor_50euros + valor_20euros + valor_10euros + valor_5euros;
                            //dgvMontos[Total.Index, 30].Value = _total_valores_euros;


                            //montos.Add(bol);
                            //b.Cartuchos.Add(bol);
                            b.MontoColones = _total_valor_colones;
                            b.MontoDolares = _total_valor_dolares;
                            b.MontoEuros = _total_valores_euros;



                            foreach (BolsaMontosSucursales mont in b.Cartuchos)
                            {
                                if (mont.ID != 0 && mont.Cantidad_asignada > 0)
                                {
                                    _atencion.actualizarMontoTulasSucursales(mont);
                                }

                            }
                            //b.Cartuchos = montos;
                            //mostrarDatosMontosBolsas(b);
                            DataGridViewRow fila = dgvBolsas.SelectedRows[0];

                            if (this.actualizarMontos(fila))
                            {
                                this.actualizarListas();
                                //this.actualizarDatos(fila);




                                // Actualiza los montos de la bolsa ya existentes.

                            }
                        }
                    }
                    catch (Excepcion ex)
                    {

                    }

                }

            }


        }





        /// <summary>
        /// Cambio en los datos del manifiesto
        /// </summary>
        private void dgvManifiestosAsignados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvManifiestosAsignados.RowCount > 0)
            {
                DataGridViewRow fila = dgvManifiestosAsignados.Rows[e.RowIndex];

                this.actualizarManifiesto(fila);

                dgvManifiestosAsignados.Refresh();
            }
        }






        /// <summary>
        /// Clic en el botón de imprimir
        /// </summary>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            pdOpcionesImpresion.PrinterSettings.PrinterName = Properties.Settings.Default.ImpresoraManifiestos;

            if (pdOpcionesImpresion.ShowDialog() == DialogResult.OK)
            {
                string nombre_impresora = pdOpcionesImpresion.PrinterSettings.PrinterName;

                Properties.Settings.Default.ImpresoraManifiestos = nombre_impresora;
                Properties.Settings.Default.Save();

                if (_esquema == null)
                    return;


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
        /// Selecciona cual manifiesto imprimir
        /// </summary>
        private void pdManifiesto_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_carga.Transportadora.ID == 2)
            {
                this.imprimirProval(e);
            }
            if (_carga.Transportadora.ID == 3)
            {
                this.imprimirG4S(e);
            }
            if (_carga.Transportadora.ID == 1)
            {
                this.imprimirVMA(e);
            }
            if (_carga.Transportadora.ID == 6)
            {
                this.imprimirSincorp(e);
            }
            if (_carga.Transportadora.ID == 10)
            {
                this.imprimirDunbar(e);
            }
            if (_carga.Transportadora.ID == 5)
            {
                this.imprimirBAC(e);
            }
        }
       


        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Limpiar los datos mostrados del manifiesto de carga.
        /// </summary>
        public void limpiarDatosManifiesto()
        {

            btnElimarTula.Enabled = false;
            txtSerieTula.Text = string.Empty;
            txtCodigoManifiestoBuscado.Text = string.Empty;
            dgvBolsas.SelectAll();
            dgvBolsas.ClearSelection();
            dgvManifiestos.SelectAll();
            dgvManifiestos.ClearSelection();
            lblNumeroManifiesto.Text = string.Empty;
            txtFecha.Text = string.Empty;
            // btnBuscar.Enabled = true;

            Bolsa bolsa = new Bolsa();
            this.validarSeleccionManifiestos();
        }



        /// <summary>
        /// Crear las filas de los DataGridView's.
        /// </summary>
        private void crearTabla(DataGridView tabla)
        {
            tabla.Rows.Add("Colones", string.Empty);
            tabla.Rows.Add("50.000", 0);
            tabla.Rows.Add("20.000", 0);
            tabla.Rows.Add("10.000", 0);
            tabla.Rows.Add("5.000", 0);
            tabla.Rows.Add("2.000", 0);
            tabla.Rows.Add("1.000", 0);
            tabla.Rows.Add("500", 0);
            tabla.Rows.Add("100", 0);
            tabla.Rows.Add("50", 0);
            tabla.Rows.Add("25", 0);
            tabla.Rows.Add("10", 0);
            tabla.Rows.Add("5", 0);
            tabla.Rows.Add("Total", 0);
            tabla.Rows.Add("Dólares", string.Empty);
            tabla.Rows.Add("100", 0);
            tabla.Rows.Add("50", 0);
            tabla.Rows.Add("20", 0);
            tabla.Rows.Add("10", 0);
            tabla.Rows.Add("5", 0);
            tabla.Rows.Add("1", 0);
            tabla.Rows.Add("Total", 0);
            tabla.Rows.Add("Euros", string.Empty);
            tabla.Rows.Add("500", 0);
            tabla.Rows.Add("200", 0);
            tabla.Rows.Add("100", 0);
            tabla.Rows.Add("50", 0);
            tabla.Rows.Add("20", 0);
            tabla.Rows.Add("10", 0);
            tabla.Rows.Add("5", 0);
            tabla.Rows.Add("Total", 0);
        }

        /// <summary>
        /// Muestra las denominaciones que se pueden editar
        /// </summary>
        private void validarDenominacionesaMostrar(CargaSucursal carga)
        {
            foreach (CartuchoCargaSucursal c in carga.Cartuchos)
            {

                if (c.Denominacion.Moneda == Monedas.Colones)
                {
                    if (c.Denominacion.Valor == 50000)
                    {

                        dgvMontos[1, 1].ReadOnly = false;
                        dgvMontos[1, 1].Style.BackColor = Color.White;

                    }
                    if (c.Denominacion.Valor == 20000)
                    {
                        dgvMontos[1, 2].ReadOnly = false;
                        dgvMontos[1, 2].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 10000)
                    {
                        dgvMontos[1, 3].ReadOnly = false;
                        dgvMontos[1, 3].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 5000)
                    {
                        dgvMontos[1, 4].ReadOnly = false;
                        dgvMontos[1, 4].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 2000)
                    {
                        dgvMontos[1, 5].ReadOnly = false;
                        dgvMontos[1, 5].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 1000)
                    {
                        dgvMontos[1, 6].ReadOnly = false;
                        dgvMontos[1, 6].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 500)
                    {
                        dgvMontos[1, 7].ReadOnly = false;
                        dgvMontos[1, 7].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 100)
                    {
                        dgvMontos[1, 8].ReadOnly = false;
                        dgvMontos[1, 8].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 50)
                    {
                        dgvMontos[1, 9].ReadOnly = false;
                        dgvMontos[1, 9].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 25)
                    {
                        dgvMontos[1, 10].ReadOnly = false;
                        dgvMontos[1, 10].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 10)
                    {
                        dgvMontos[1, 11].ReadOnly = false;
                        dgvMontos[1, 11].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 5)
                    {
                        dgvMontos[1, 12].ReadOnly = false;
                        dgvMontos[1, 12].Style.BackColor = Color.White;
                    }
                }
                if (c.Denominacion.Moneda == Monedas.Dolares)
                {
                    if (c.Denominacion.Valor == 100)
                    {
                        dgvMontos[1, 15].ReadOnly = false;
                        dgvMontos[1, 15].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 50)
                    {
                        dgvMontos[1, 16].ReadOnly = false;
                        dgvMontos[1, 16].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 20)
                    {
                        dgvMontos[1, 17].ReadOnly = false;
                        dgvMontos[1, 17].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 10)
                    {
                        dgvMontos[1, 18].ReadOnly = false;
                        dgvMontos[1, 18].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 5)
                    {
                        dgvMontos[1, 19].ReadOnly = false;
                        dgvMontos[1, 19].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 1)
                    {
                        dgvMontos[1, 20].ReadOnly = false;
                        dgvMontos[1, 20].Style.BackColor = Color.White;
                    }
                }
                if (c.Denominacion.Moneda == Monedas.Euros)
                {
                    if (c.Denominacion.Valor == 500)
                    {
                        dgvMontos[1, 23].ReadOnly = false;
                        dgvMontos[1, 23].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 200)
                    {
                        dgvMontos[1, 24].ReadOnly = false;
                        dgvMontos[1, 24].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 100)
                    {
                        dgvMontos[1, 25].ReadOnly = false;
                        dgvMontos[1, 25].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 50)
                    {
                        dgvMontos[1, 26].ReadOnly = false;
                        dgvMontos[1, 26].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 20)
                    {
                        dgvMontos[1, 27].ReadOnly = false;
                        dgvMontos[1, 27].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 10)
                    {
                        dgvMontos[1, 28].ReadOnly = false;
                        dgvMontos[1, 28].Style.BackColor = Color.White;
                    }
                    if (c.Denominacion.Valor == 5)
                    {
                        dgvMontos[1, 29].ReadOnly = false;
                        dgvMontos[1, 29].Style.BackColor = Color.White;
                    }


                }
            }
        }


        /// <summary>
        /// Muestra el desglose de denominaciones por bolsa
        /// </summary>
        void mostrarDatosMontosBolsas(Bolsa bolsa)
        {
            foreach (BolsaMontosSucursales c in bolsa.Cartuchos)
            {

                if (c.Denominacion.Moneda == Monedas.Colones)
                {
                    if (c.Denominacion.Valor == 50000)
                    {
                        dgvMontos[1, 1].Value = c.Cantidad_asignada;

                    }
                    if (c.Denominacion.Valor == 20000)
                    {
                        dgvMontos[1, 2].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 10000)
                    {
                        dgvMontos[1, 3].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 5000)
                    {
                        dgvMontos[1, 4].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 2000)
                    {
                        dgvMontos[1, 5].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 1000)
                    {
                        dgvMontos[1, 6].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 500)
                    {
                        dgvMontos[1, 7].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 100)
                    {
                        dgvMontos[1, 8].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 50)
                    {
                        dgvMontos[1, 9].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 25)
                    {
                        dgvMontos[1, 10].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 10)
                    {
                        dgvMontos[1, 11].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 5)
                    {
                        dgvMontos[1, 12].Value = c.Cantidad_asignada;
                    }
                }
                if (c.Denominacion.Moneda == Monedas.Dolares)
                {
                    if (c.Denominacion.Valor == 100)
                    {
                        dgvMontos[1, 15].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 50)
                    {
                        dgvMontos[1, 16].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 20)
                    {
                        dgvMontos[1, 17].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 10)
                    {
                        dgvMontos[1, 18].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 5)
                    {
                        dgvMontos[1, 19].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 1)
                    {
                        dgvMontos[1, 20].Value = c.Cantidad_asignada;
                    }
                }
                if (c.Denominacion.Moneda == Monedas.Euros)
                {
                    if (c.Denominacion.Valor == 500)
                    {
                        dgvMontos[1, 23].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 200)
                    {
                        dgvMontos[1, 24].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 100)
                    {
                        dgvMontos[1, 25].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 50)
                    {
                        dgvMontos[1, 26].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 20)
                    {
                        dgvMontos[1, 27].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 10)
                    {
                        dgvMontos[1, 28].Value = c.Cantidad_asignada;
                    }
                    if (c.Denominacion.Valor == 5)
                    {
                        dgvMontos[1, 29].Value = c.Cantidad_asignada;
                    }


                }
            }
        }

        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLectura(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = Denominacion.DefaultCellStyle.BackColor;
            }

        }


        /// <summary>
        /// Limpia los datos de la tabla para dejarlos en 0 
        /// </summary>
        private void limpiarDatosTabla(DataGridView tabla, params int[] filas)
        {
            _auxiliar = 0;
            foreach (int fila in filas)
            {
                int copia_fila = fila;
                dgvMontos[Total.Index, fila].Value = 0;

                if (copia_fila == filas[filas.Length - 1])
                {
                    _auxiliar = 1;
                }
            }

        }

        /// <summary>
        /// Dar formato a las celdas que son separadoras.
        /// </summary>
        private void formatoCeldaSeparador(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = tabla.GridColor;
            }

        }

        /// <summary>
        /// Mostrar los datos del manifiesto de carga seleccionado.
        /// </summary>
        private void mostrarDatosManifiesto()
        {
            btnCancelarManifiesto.Enabled = false;
            btnGuardarManifiesto.Enabled = true;

            // txtSerieTula.Text = _manifiesto.Serie_Tula;

            this.validarSeleccionManifiestos();
        }

        /// <summary>
        /// Validar la selección de los manifiestos.
        /// </summary>
        private void validarSeleccionManifiestos()
        {

            //if (_carga != null)
            //    btnAceptar.Enabled = _carga.Manifiesto != null;

        }


        /// <summary>
        /// Muestra las tulas obtenidas en un manifiesto
        /// </summary>
        /// <param name="manifiesto">Objeto Manifiesto con el listado de tulas a mostrar</param>
        private void mostrarTulas(ref ManifiestoSucursalCarga manifiesto)
        {
            try
            {
                dgvBolsas.DataSource = manifiesto.Serie_Tula;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Desasigna un manifiesto
        /// </summary>
        /// <param name="fila">Fila con el objeto manifiesto a desligar</param>
        private void desasignar(DataGridViewRow fila)
        {
            BindingList<ManifiestoSucursalCarga> cargas_pendientes = (BindingList<ManifiestoSucursalCarga>)dgvManifiestos.DataSource;
            BindingList<ManifiestoSucursalCarga> cargas_asignadas = (BindingList<ManifiestoSucursalCarga>)dgvManifiestosAsignados.DataSource;

            ManifiestoSucursalCarga carga = (ManifiestoSucursalCarga)fila.DataBoundItem;



            cargas_asignadas.Remove(carga);
            cargas_pendientes.Add(carga);
        }


        /// <summary>
        /// asigna un manifiesto
        /// </summary>
        /// <param name="fila">Fila con el objeto manifiesto a desligar</param>
        private void asignarManifiesto(DataGridViewRow fila)
        {
            BindingList<ManifiestoSucursalCarga> cargas_pendientes = (BindingList<ManifiestoSucursalCarga>)dgvManifiestos.DataSource;
            BindingList<ManifiestoSucursalCarga> cargas_asignadas = (BindingList<ManifiestoSucursalCarga>)dgvManifiestosAsignados.DataSource;

            ManifiestoSucursalCarga carga = (ManifiestoSucursalCarga)fila.DataBoundItem;



            cargas_asignadas.Add(carga);
            cargas_pendientes.Remove(carga);
        }

        private void dgvBolsas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }



        private void llenarCampos(CargaSucursal p)
        {
            try
            {
                dgvManifiestosAsignados.DataSource = p.Manifiesto;
            }
            catch (Excepcion ex)
            {
                throw ex; 
            }
        }

        /// <summary>
        /// Actualizar los datos de un cartucho.
        /// </summary
        private bool actualizarMontos(DataGridViewRow fila)
        {
            bool variable = true;
            try
            {
                Bolsa bolsa = (Bolsa)fila.DataBoundItem;


                if (bolsa.MontoColones % 100 == 0)
                {



                    dgvBolsas.Rows[fila.Index].Cells[0].ErrorText = "";
                    //_coordinacion.actualizarCartuchoCargaSucursalCantidad(cartucho);
                }
                else
                {
                    dgvBolsas.Rows[fila.Index].Cells[0].ErrorText = "Dato Incorrecto";
                }


                if (bolsa.MontoDolares % 100 == 0)
                    dgvBolsas.Rows[fila.Index].Cells[1].ErrorText = "";
                else
                    dgvBolsas.Rows[fila.Index].Cells[1].ErrorText = "Dato Incorrecto";

                if (bolsa.MontoEuros % 100 == 0)
                    dgvBolsas.Rows[fila.Index].Cells[2].ErrorText = "";
                else
                    dgvBolsas.Rows[fila.Index].Cells[2].ErrorText = "Dato Incorrecto";

                Decimal montocolonesnuevo = 0;
                Decimal montodolaroes = 0;
                Decimal montoeuros = 0;

                BindingList<ManifiestoSucursalCarga> manifiestos = (BindingList<ManifiestoSucursalCarga>)dgvManifiestosAsignados.DataSource;

                foreach (ManifiestoSucursalCarga man in manifiestos)
                {
                    foreach (Bolsa b in man.ListaBolsas)
                    {
                        montocolonesnuevo = montocolonesnuevo + b.MontoColones;
                        montodolaroes = montodolaroes + b.MontoDolares;
                        montoeuros = montoeuros + b.MontoEuros;
                    }
                }



                Decimal montocolones = _carga.Monto_asignado_colones - montocolonesnuevo;
                Decimal montodolares = _carga.Monto_asignado_dolares - montodolaroes;
                Decimal montoeurosn = _carga.Monto_asignado_euros - montoeuros;

                bool lleno = false;



                lblCantidadColones.Text = montocolones.ToString("N0");
                lblCantidadDolares.Text = montodolares.ToString("N0");
                lblCantidadEuros.Text = montoeurosn.ToString("N0");



                foreach (ManifiestoSucursalCarga man in manifiestos)
                {
                    if (man.ListaBolsas == null)
                        man.ListaBolsas = new BindingList<Bolsa>();
                    if (man.ListaBolsas.Count > 0)
                        lleno = true;
                    else
                        lleno = false;
                }



                if (lleno && Convert.ToDecimal(lblCantidadColones.Text) == 0 && Convert.ToDecimal(lblCantidadDolares.Text) == 0 && Convert.ToDecimal(lblCantidadEuros.Text) == 0)
                    variable = true;

                else
                    variable = false;


            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

            return variable;
        }



        /// <summary>
        /// Actualiza los montos en la base de datos
        /// </summary>
        /// <param name="fila">Fila de la tabla que contiene la bolsa</param>
        private void actualizarDatos(DataGridViewRow fila)
        {
            try
            {
                Bolsa bolsa = (Bolsa)fila.DataBoundItem;


                if (bolsa.ID != 0)
                {

                    _atencion.actualizarbolsasucursal(ref bolsa);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Validar el formato númerico de la celda de la cantidad de fórmulas de un cartucho.
        /// </summary
        private void validarFormatoNumericoCelda(DataGridViewCellParsingEventArgs e)
        {

            if (e.Value != null)
            {
                short valor;

                short.TryParse(e.Value.ToString().Replace(",", ""), out valor);

                e.Value = valor;
                e.ParsingApplied = true;
            }

        }



        /// <summary>
        /// Actualiza la lista de manifiestos con respecto a las tulas ingresadas
        /// </summary>
        private void actualizarListas()
        {
            BindingList<ManifiestoSucursalCarga> manifiestos = (BindingList<ManifiestoSucursalCarga>)dgvManifiestosAsignados.DataSource;

            _manifiesto_unico = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;
            ManifiestoSucursalCarga manifiesto_usar = _manifiesto_unico;

            //if (manifiestos.Contains(_manifiesto_unico))
            //{
            //    manifiestos.Remove(_manifiesto_unico);
            //}

            //manifiesto_usar.Serie_Tula = (BindingList<Bolsa>)dgvBolsas.DataSource;

            //manifiestos.Add(manifiesto_usar);


            BindingList<ManifiestoSucursalCarga> manifiestos_nuevos = (BindingList<ManifiestoSucursalCarga>)dgvManifiestosAsignados.DataSource;
            foreach (ManifiestoSucursalCarga m in manifiestos_nuevos)
            {
                ManifiestoSucursalCarga copia_man = m;
                if (copia_man.ID == manifiesto_usar.ID)
                    copia_man = manifiesto_usar;

            }


            dgvManifiestosAsignados.DataSource = manifiestos_nuevos;
            //dgvManifiestosAsignados.DataSource = manifiestos;


        }













        //////////////////////////////////////IMPRESION DE MANIFIESTOS //////////////////////////////////////////////////////

        /// <summary>
        /// Imprimir los datos de un manifiesto.
        /// </summary>
        private void imprimirProval(PrintPageEventArgs e)
        {
            Font _fuente = new Font("Arial", 10);
            Font _fuente_pequena = new Font("Arial", 7);
            Font _fuente_grande = new Font("Arial", 14);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;



            TipoCambio _tipocambio = _mantenimiento.obtenerTipoCambio(_carga.Fecha_asignada);

            // Imprimir los datos fijos

            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Cliente
            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); //Lugar de Entrega
            e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Lugar de Recibo
            if(_carga.Cierre != null)
                e.Graphics.DrawString(_carga.Cierre.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Encargado
            else
                e.Graphics.DrawString(_carga.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Encargado
            e.Graphics.DrawString(_carga.Fecha_asignada.ToString("dd/MM/yy"), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); // Fecha


            if (_tipocambio != null) { }
            else
                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));




            ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;


            PointF posicion = _esquema.obtenerPunto(4, 0);
            PointF posicion_tulas = _esquema.obtenerPunto(5, 0);
            PosicionEsquema pos = _esquema.Posiciones[3];
            PosicionEsquema pos_monto = _esquema.Posiciones[4];

            decimal sumar = pos.Desplazamiento_horizontal;
            decimal sumar_monto = pos.Desplazamiento_horizontal;

            int contador = 0;


            PointF nuevo = posicion;


            Decimal monto = 0;
            foreach (Bolsa b in manifiesto.ListaBolsas)
            {

                decimal monto_portula = 0;
                posicion.X = posicion.X + (float)(sumar * contador);
                posicion_tulas.X = posicion_tulas.X + (float)(sumar_monto * contador);

                monto = monto + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);

                monto_portula = monto_portula + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);
                e.Graphics.DrawString(b.SerieBolsa, _fuente, Brushes.Black, posicion);
                e.Graphics.DrawString(monto_portula.ToString("N0"), _fuente, Brushes.Black, posicion_tulas);

                contador++;

               
            }



            //PointF posicion_bolsas = _esquema.obtenerPunto(7, 0);
            //PosicionEsquema pos_bolsas = _esquema.Posiciones[6];
            //decimal sumar_bolsas = pos_bolsas.Desplazamiento_vertical;
            //Decimal monto_bolsa = 0;
            //int contador_bolsas = 0;
            //foreach (BolsaCompletaNiquel bolsa in manifiesto.BolsasCompletas)
            //{
            //    if (bolsa.CantidadBolsas > 0)
            //    {
            //        posicion_bolsas.Y = posicion_bolsas.Y + (float)(sumar_bolsas);
            //        monto_bolsa = monto_bolsa + bolsa.Monto_asignado;

            //        e.Graphics.DrawString(bolsa.CantidadBolsas.ToString() + "B" + bolsa.Denominacion.Valor.ToString("N0") + "=" + bolsa.Monto_asignado.ToString("N0"), _fuente, Brushes.Black, posicion_bolsas);

            //        contador_bolsas++;

            //    }

            //}

            

            e.Graphics.DrawString(monto.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0)); // Monto Global






        }








        /// <summary>
        /// Imprimir los datos de un manifiesto.
        /// </summary>
        private void imprimirG4S(PrintPageEventArgs e)
        {
            Font _fuente = new Font("Arial", 10);
            Font _fuente_pequena = new Font("Arial", 7);
            Font _fuente_grande = new Font("Arial", 14);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;



            TipoCambio _tipocambio = _mantenimiento.obtenerTipoCambio(_carga.Fecha_asignada);

            // Imprimir los datos fijos

            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Cliente
            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); //Lugar de Entrega
            e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Lugar de Recibo
            if (_carga.Cierre != null)
                e.Graphics.DrawString(_carga.Cierre.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Encargado
            else
                e.Graphics.DrawString(_carga.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Encargado
            e.Graphics.DrawString(_carga.Fecha_asignada.ToString("dd/MM/yy"), _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); // Fecha


            if (_tipocambio != null) { }
            else
                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));




            ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;


            PointF posicion = _esquema.obtenerPunto(5, 0);
            PointF posicion_tulas = _esquema.obtenerPunto(6, 0);
            PosicionEsquema pos = _esquema.Posiciones[4];
            PosicionEsquema pos_monto = _esquema.Posiciones[5];

            decimal sumar = pos.Desplazamiento_vertical;
            decimal sumar_monto = pos.Desplazamiento_vertical;

            int contador = 0;


            PointF nuevo = posicion;


            Decimal monto = 0;
            foreach (Bolsa b in manifiesto.ListaBolsas)
            {
                decimal monto_portula = 0;
                posicion.Y = posicion.Y + (float)(sumar);
                posicion_tulas.Y = posicion_tulas.Y + (float)(sumar_monto);

                monto = monto + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);

                monto_portula = monto_portula + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);
                e.Graphics.DrawString(b.SerieBolsa, _fuente, Brushes.Black, posicion);
                e.Graphics.DrawString(monto_portula.ToString("N0"), _fuente, Brushes.Black, posicion_tulas);

                contador++;
            }




            //monto = monto + monto_bolsa;
            int montito = Convert.ToInt32(monto);

            e.Graphics.DrawString(monto.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); // Monto Global

            string monto_letras = _coordinacion.convertirMontoaLetras(montito.ToString());

            e.Graphics.DrawString(monto_letras + " " + "COLONES", _fuente, Brushes.Black, _esquema.obtenerPunto(7, 0)); // Monto en Letras


        }



        /// <summary>
        /// Imprimir los datos de un manifiesto.
        /// </summary>
        private void imprimirDunbar(PrintPageEventArgs e)
        {
            Font _fuente = new Font("Arial", 10);
            Font _fuente_pequena = new Font("Arial", 7);
            Font _fuente_grande = new Font("Arial", 14);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;



            TipoCambio _tipocambio = _mantenimiento.obtenerTipoCambio(_carga.Fecha_asignada);

            // Imprimir los datos fijos

            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Cliente
            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); //Lugar de Entrega
            e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Lugar de Recibo
            e.Graphics.DrawString(_carga.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(13, 0)); // Encargado
            e.Graphics.DrawString(_carga.Fecha_asignada.Day.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); // Día
            e.Graphics.DrawString(_carga.Fecha_asignada.Month.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0)); // Mes
            e.Graphics.DrawString(_carga.Fecha_asignada.Year.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0)); // Año


            if (_tipocambio != null) { }
            else
                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));




            ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;


            PointF posicion = _esquema.obtenerPunto(11, 0);
            PointF posicion_tulas = _esquema.obtenerPunto(12, 0);
            PosicionEsquema pos = _esquema.Posiciones[10];
            PosicionEsquema pos_monto = _esquema.Posiciones[11];

            decimal sumar = pos.Desplazamiento_vertical;
            decimal sumar_monto = pos.Desplazamiento_vertical;

            int contador = 0;


            PointF nuevo = posicion;


            Decimal monto = 0;
            Decimal monto_colones = 0;
            Decimal monto_dolares = 0;
            foreach (Bolsa b in manifiesto.ListaBolsas)
            {
                decimal monto_portula = 0;
                posicion.Y = posicion.Y + (float)(sumar);
                posicion_tulas.Y = posicion_tulas.Y + (float)(sumar_monto);

                monto = monto + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);
                monto_colones = monto_colones + b.MontoColones;
                monto_dolares = monto_dolares + b.MontoDolares;
                monto_portula = monto_portula + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);
                e.Graphics.DrawString(b.SerieBolsa, _fuente, Brushes.Black, posicion);
                e.Graphics.DrawString(monto_portula.ToString("N0"), _fuente, Brushes.Black, posicion_tulas);

                contador++;
            }





            Decimal monto_bolsa = 0;
            Decimal monto_colones_total = monto_colones;
            int contador_bolsas = 0;

            
            //foreach (Bolsa bolsa in manifiesto.BolsasCompletas)
            //{
            //    if (bolsa.CantidadBolsas > 0)
            //    {
            //        posicion.Y = posicion.Y + (float)(sumar);
            //        posicion_tulas.Y = posicion_tulas.Y + (float)(sumar_monto);
            //        monto_bolsa = monto_bolsa + bolsa.Monto_asignado;

            //        e.Graphics.DrawString(bolsa.CantidadBolsas.ToString() + "B" + bolsa.Denominacion.Valor.ToString("N0"), _fuente, Brushes.Black, posicion);
            //        e.Graphics.DrawString(bolsa.Monto_asignado.ToString("N0"), _fuente, Brushes.Black, posicion_tulas);

            //        contador_bolsas++;

            //    }

            //}


            monto = monto + monto_bolsa;
            int montito = Convert.ToInt32(monto);
            e.Graphics.DrawString(monto_colones_total.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(7, 0)); // Monto en Colones
            e.Graphics.DrawString(monto_dolares.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); // Monto en Dólares
            e.Graphics.DrawString(monto.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Monto Global

            string monto_letras = _coordinacion.convertirMontoaLetras(montito.ToString());


            e.Graphics.DrawString(monto_letras, _fuente, Brushes.Black, _esquema.obtenerPunto(10, 0)); // Monto en letras



        }




        /// <summary>
        /// Imprimir los datos de un manifiesto.
        /// </summary>
        private void imprimirVMA(PrintPageEventArgs e)
        {
            Font _fuente = new Font("Arial", 10);
            Font _fuente_pequena = new Font("Arial", 7);
            Font _fuente_grande = new Font("Arial", 14);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;



            TipoCambio _tipocambio = _mantenimiento.obtenerTipoCambio(_carga.Fecha_asignada);

            // Imprimir los datos fijos

            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Cliente
            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); //Lugar de Entrega
            e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Lugar de Recibo
            if(_carga.Cierre != null)
                e.Graphics.DrawString(_carga.Cierre.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Encargado
            else
                e.Graphics.DrawString(_carga.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Encargado
            e.Graphics.DrawString(_carga.Fecha_asignada.ToString("dd/MM/yy"), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); // Fecha



            if (_tipocambio != null) { }
            else
                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));




            ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;


            PointF posicion = _esquema.obtenerPunto(4, 0);
            PointF posicion_tulas = _esquema.obtenerPunto(5, 0);
            PosicionEsquema pos = _esquema.Posiciones[3];
            PosicionEsquema pos_monto = _esquema.Posiciones[4];

            decimal sumar = pos.Desplazamiento_horizontal;
            decimal sumar_monto = pos.Desplazamiento_horizontal;

            int contador = 0;


            PointF nuevo = posicion;


            Decimal monto = 0;
            foreach (Bolsa b in manifiesto.ListaBolsas)
            {
                decimal monto_portula = 0;
                posicion.X = posicion.X + (float)(sumar * contador);
                posicion_tulas.X = posicion_tulas.X + (float)(sumar_monto * contador);

                monto = monto + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);

                monto_portula = monto_portula + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);
                e.Graphics.DrawString(b.SerieBolsa, _fuente, Brushes.Black, posicion);
                e.Graphics.DrawString(monto_portula.ToString("N0"), _fuente, Brushes.Black, posicion_tulas);

                contador++;
            }



            Decimal monto_bolsa = 0;
   
           

            monto = monto + monto_bolsa;

            e.Graphics.DrawString(monto.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0)); // Monto Global


        }








        /// <summary>
        /// Imprimir los datos de un manifiesto.
        /// </summary>
        private void imprimirSincorp(PrintPageEventArgs e)
        {
            Font _fuente = new Font("Arial", 10);
            Font _fuente_pequena = new Font("Arial", 7);
            Font _fuente_grande = new Font("Arial", 14);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;



            TipoCambio _tipocambio = _mantenimiento.obtenerTipoCambio(_carga.Fecha_asignada);

            // Imprimir los datos fijos


            if(_carga.Cierre != null)
                e.Graphics.DrawString(_carga.Cierre.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Encargado
            else
                e.Graphics.DrawString(_carga.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Encargado
            e.Graphics.DrawString(_carga.Fecha_asignada.ToString("dd/MM/yy"), _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Fecha
            e.Graphics.DrawString("BAC SAN JOSE", _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); // Hemos Recibido de
            e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); // Lugar de Recibo
            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0)); // Cliente
            e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0)); //Lugar de Entrega
            e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yy"), _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Fecha de Recepción
            e.Graphics.DrawString(_carga.Fecha_asignada.ToString("dd/MM/yy"), _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Fecha de Entrega

            if (_tipocambio != null) { }
            else
                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));




            ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;


            PointF posicion = _esquema.obtenerPunto(13, 0);

            PosicionEsquema pos = _esquema.Posiciones[12];


            decimal sumar = pos.Desplazamiento_vertical;
            decimal sumar_monto = pos.Desplazamiento_vertical;

            int contador = 0;


            PointF nuevo = posicion;


            Decimal monto = 0;
            Decimal monto_colones = 0;
            Decimal monto_dolares = 0;
            foreach (Bolsa b in manifiesto.ListaBolsas)
            {
                decimal monto_portula = 0;
                posicion.Y = posicion.Y + (float)(sumar);

                monto = monto + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);
                monto_colones = monto_colones + b.MontoColones;
                monto_dolares = monto_dolares + b.MontoDolares;
                monto_portula = monto_portula + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);
                e.Graphics.DrawString(b.SerieBolsa + "=" + monto_portula.ToString("N0"), _fuente, Brushes.Black, posicion);

                contador++;
            }





            Decimal monto_bolsa = 0;
            Decimal monto_colones_total = 0;
            int contador_bolsas = 0;
           

            monto = monto + monto_bolsa;

            e.Graphics.DrawString(monto_colones_total.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Monto en Colones
            e.Graphics.DrawString(monto_dolares.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(10, 0)); // Monto en Dólares
            e.Graphics.DrawString(monto.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(11, 0)); // Monto Global


            int montito = Convert.ToInt32(monto);
            string monto_letras = _coordinacion.convertirMontoaLetras(montito.ToString());


            e.Graphics.DrawString(monto_letras, _fuente, Brushes.Black, _esquema.obtenerPunto(12, 0)); // Monto en letras





        }



        /// <summary>
        /// Imprimir los datos de un manifiesto.
        /// </summary>
        private void imprimirBAC(PrintPageEventArgs e)
        {
            Font _fuente = new Font("Arial", 10);
            Font _fuente_pequena = new Font("Arial", 7);
            Font _fuente_grande = new Font("Arial", 14);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

     

            TipoCambio _tipocambio = _mantenimiento.obtenerTipoCambio(_carga.Fecha_asignada);

            // Imprimir los datos fijos


            if (_carga.EntregaBovedaSucursal == EntregaRecibo.Entregas)
            {
                e.Graphics.DrawString(_carga.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(22, 0)); // Encargado
                e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); // Lugar de Recibo
                e.Graphics.DrawString(_carga.Sucursal.Direccion, _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0)); // Cliente
                e.Graphics.DrawString("BAC SAN JOSE", _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); //Lugar de Entrega
                e.Graphics.DrawString("CURRIDABAT", _fuente, Brushes.Black, _esquema.obtenerPunto(10, 0)); //Lugar de Entrega
                e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(11, 0)); //Lugar de Entrega
                e.Graphics.DrawString("CURRIDABAT", _fuente, Brushes.Black, _esquema.obtenerPunto(12, 0)); //Lugar de Entrega
            }
            else
            {
                e.Graphics.DrawString(_carga.Cierre.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(22, 0)); // Encargado
                e.Graphics.DrawString("BAC SAN JOSE", _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); // Lugar de Recibo
                e.Graphics.DrawString("Cipreses de Curridabat", _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0)); // Cliente
                e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); //Lugar de Entrega
                e.Graphics.DrawString(_carga.Sucursal.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(10, 0)); //Lugar de Entrega
            }
            
            e.Graphics.DrawString(_carga.Fecha_asignada.ToString("dd/MM/yy"), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); // Fecha
            e.Graphics.DrawString("SERVICIO BANCARIO", _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); // Hemos Recibido de

            e.Graphics.DrawString("SAN JOSE", _fuente, Brushes.Black, _esquema.obtenerPunto(13, 0)); // Hemos Recibido de
            
            
            e.Graphics.DrawString(_carga.Sucursal.Provincia.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0)); //Lugar de Entrega
            e.Graphics.DrawString(_carga.Sucursal.Provincia.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(7, 0)); //Lugar de Entrega
            
          
           

            if (_tipocambio != null) { }
            else
                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));




            ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;


            PointF posicion_bolsa = _esquema.obtenerPunto(14, 0);
            PointF posicion_b_t = _esquema.obtenerPunto(15, 0);
            PointF posicion_cantidad = _esquema.obtenerPunto(16, 0);
            PointF posicion_monto = _esquema.obtenerPunto(17, 0);

            PosicionEsquema pos = _esquema.Posiciones[12];



            decimal sumar = pos.Desplazamiento_vertical;
            decimal sumar_monto = pos.Desplazamiento_vertical;

            int contador = 0;


            PointF nuevo_bolsa = posicion_bolsa;
            PointF nuevo_b_t = posicion_b_t;
            PointF nuevo_cantidad = posicion_cantidad;
            PointF nuevo_monto = posicion_monto;


            Decimal monto = 0;
            Decimal monto_colones = 0;
            Decimal monto_dolares = 0;
            foreach (Bolsa b in manifiesto.ListaBolsas)
            {
                decimal monto_portula = 0;

                posicion_bolsa.Y = posicion_bolsa.Y + (float)(sumar);
                posicion_b_t.Y = posicion_b_t.Y + (float)(sumar);
                posicion_cantidad.Y = posicion_cantidad.Y + (float)(sumar);
                posicion_monto.Y = posicion_monto.Y + (float)(sumar);

                monto = monto + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);
                monto_colones = monto_colones + b.MontoColones;
                monto_dolares = monto_dolares + b.MontoDolares;
                monto_portula = monto_portula + b.MontoColones + (b.MontoDolares * _tipocambio.Venta) + (b.MontoEuros * _tipocambio.VentaEuros);

                e.Graphics.DrawString(monto_portula.ToString("N0"), _fuente, Brushes.Black, posicion_monto);
                e.Graphics.DrawString(b.SerieBolsa, _fuente, Brushes.Black, posicion_bolsa);
                e.Graphics.DrawString("B", _fuente, Brushes.Black, posicion_b_t);
                e.Graphics.DrawString("1", _fuente, Brushes.Black, posicion_cantidad);

                contador++;
            }





            Decimal monto_bolsa = 0;
            Decimal monto_colones_total = 0;
           
            monto = monto + monto_bolsa;

            //e.Graphics.DrawString(monto_colones_total.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Monto en Colones
            //e.Graphics.DrawString(monto_dolares.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(10, 0)); // Monto en Dólares
            e.Graphics.DrawString(monto.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(20, 0)); // Monto Global


            int montito = Convert.ToInt32(monto);
            string monto_letras = _coordinacion.convertirMontoaLetras(montito.ToString());


            e.Graphics.DrawString(monto_letras, _fuente, Brushes.Black, _esquema.obtenerPunto(23, 0)); // Monto en letras



        }


        /// <summary>
        /// Actualiza la cantidad de piezas de una bolsa específica
        /// </summary>
        /// <param name="fila">Fila seleccionada donde reside la bolsa</param>
        private void actualizarManifiesto(DataGridViewRow fila)
        {
            try
            {
                ManifiestoSucursal cartucho = (ManifiestoSucursal)fila.DataBoundItem;

                _atencion.actualizarManifiestoSucursalCarga(ref _carga);


            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimirRecap_Click(object sender, EventArgs e)
        {
            ManifiestoSucursalCarga manifiesto = (ManifiestoSucursalCarga)dgvManifiestosAsignados.SelectedRows[0].DataBoundItem;
            imprimirRecap(manifiesto);

            
        }



        /// <summary>
        /// Imprime el Recap seleccionado
        /// </summary>
        private void imprimirRecap(ManifiestoSucursalCarga manifiesto)
        {
            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla remesas efectivo.xltx", true);

                int hoja = 1;

                foreach (Bolsa bol in manifiesto.ListaBolsas)
                {

                    documento.seleccionarHoja(hoja);

                    documento.seleccionarCelda("D5");
                    documento.actualizarValorCelda(_carga.Sucursal.ToString());

                    documento.seleccionarCelda("D6");
                    documento.actualizarValorCelda(_carga.Sucursal.Codigo.ToString());


                    documento.seleccionarCelda("C62");
                    documento.actualizarValorCelda(manifiesto.Codigo);

                    // Escribir los datos

                    foreach (BolsaMontosSucursales b in bol.Cartuchos)
                    {

                        if (b.Denominacion.Valor == 50000)
                        {
                            documento.seleccionarCelda("B18");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 5000000);
                        }
                        if (b.Denominacion.Valor == 20000)
                        {
                            documento.seleccionarCelda("B19");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 2000000);
                        }
                        if (b.Denominacion.Valor == 10000)
                        {
                            documento.seleccionarCelda("B20");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 1000000);
                        }
                        if (b.Denominacion.Valor == 5000)
                        {
                            documento.seleccionarCelda("B21");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 500000);
                        }
                        if (b.Denominacion.Valor == 2000)
                        {
                            documento.seleccionarCelda("B22");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 200000);
                        }
                        if (b.Denominacion.Valor == 1000)
                        {
                            documento.seleccionarCelda("B23");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 100000);
                        }
                        if (b.Denominacion.Valor == 100 && b.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("B24");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 10000);
                        }
                        if (b.Denominacion.Valor == 50 && b.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("B25");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 5000);
                        }
                        if (b.Denominacion.Valor == 20 && b.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("B26");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 2000);
                        }
                        if (b.Denominacion.Valor == 10 && b.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("B27");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 1000);
                        }
                        if (b.Denominacion.Valor == 5 && b.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("B28");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 500);
                        }

                        if (b.Denominacion.Valor == 1 && b.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("B29");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 100);
                        }


                        if (b.Denominacion.Valor == 500 && b.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("B30");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 50000);
                        }

                        if (b.Denominacion.Valor == 200 && b.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("B31");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 20000);
                        }

                        if (b.Denominacion.Valor == 100 && b.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("B32");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 10000);
                        }

                        if (b.Denominacion.Valor == 50 && b.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("B33");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 5000);
                        }

                        if (b.Denominacion.Valor == 20 && b.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("B34");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 2000);
                        }

                        if (b.Denominacion.Valor == 10 && b.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("B35");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 1000);
                        }

                        if (b.Denominacion.Valor == 5 && b.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("B36");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 500);
                        }




                        if (b.Denominacion.Valor == 500 && b.Denominacion.Moneda == Monedas.Colones)
                        {
                            documento.seleccionarCelda("B43");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 500000);
                        }

                        if (b.Denominacion.Valor == 100 && b.Denominacion.Moneda == Monedas.Colones)
                        {
                            documento.seleccionarCelda("B44");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 100000);
                        }

                        if (b.Denominacion.Valor == 50 && b.Denominacion.Moneda == Monedas.Colones)
                        {
                            documento.seleccionarCelda("B45");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 50000);
                        }

                        if (b.Denominacion.Valor == 25 && b.Denominacion.Moneda == Monedas.Colones)
                        {
                            documento.seleccionarCelda("B46");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 25000);
                        }

                        if (b.Denominacion.Valor == 10 && b.Denominacion.Moneda == Monedas.Colones)
                        {
                            documento.seleccionarCelda("B47");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 10000);
                        }

                        if (b.Denominacion.Valor == 5 && b.Denominacion.Moneda == Monedas.Colones)
                        {
                            documento.seleccionarCelda("B48");
                            documento.actualizarValorCelda(b.Cantidad_asignada / 5000);
                        }


                    }

                    hoja++;

                }


                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }


        /// <summary>
        /// Recalcula los montos de los manifiestos. 
        /// </summary>

        #endregion Métodos Privados


       

    }
}
