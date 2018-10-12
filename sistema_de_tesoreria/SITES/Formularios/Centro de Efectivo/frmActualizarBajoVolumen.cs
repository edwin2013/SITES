using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects;
using BussinessLayer;
using CommonObjects.Clases;
using System.Diagnostics;
using System.IO.Ports;
using System.Collections;
using Org.BouncyCastle.Utilities;
using LibreriaReportesOffice;
using CommonObjects.Clases.Reportes;
using System.Globalization;
namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmActualizarBajoVolumen : Form
    {
        private int idDeposito;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private ConteoBillete conteoBillete;
        BindingList<BilleteFalso> listabilletefalso;
        BindingList<BilleteFalso> listabilletefalsoAnterior;
        BindingList<ChequeDeposito> listachequedeposito;
        BindingList<ChequeDeposito> listachequedepositoAnterior;
        CompraVenta compraVenta = new CompraVenta();
        Deposito _deposito;
        Deposito _depositoNuevo;
        Colaborador _colaborador = null;
        Boolean depositoActualzado = false;
        private byte cancelact = 0;
        private Boolean VerificaMonto = true;
        private int nuderror = 0;
        private int nuderror2 = 0;
        private bool Error = false;
        private int chkcierremanifiesto = 0;
        private byte origendiferenciadeposito = 0;
        private int conteoerrores = 0;
        private ConteoNiquel conteoNiquel = null;
        private ConteoNiquel conteoNanterior = null;
        private int conteotabs = 0;
        private int chktime = 0;
        private Stopwatch sw;
        private int chktab = 0;
        private String numdeposito = "";
        long tiempo = 0;
        private ProcesamientoBajoVolumenManifiesto _manifiesto;
        private Boolean datosCargados = false;
        ConteoBillete conteoNuevo = null;
        private Tula _tulaActual;
        private Boolean readOnly;

        public frmActualizarBajoVolumen(int codigoDeposito, Colaborador _coordinador, ProcesamientoBajoVolumenManifiesto ma, Tula tulaActual, Boolean readOnly)
        {
            InitializeComponent();
            this.idDeposito = codigoDeposito;
            this._colaborador = _coordinador;
            this._manifiesto = ma;
            this._tulaActual = tulaActual;
            this.readOnly = readOnly;
            setReadOnly(readOnly);
        }

        private void setReadOnly(bool readOnly)
        {
            this.btnModificar.Enabled = readOnly;
            txtCedula.ReadOnly = !readOnly;
            txtCodigoTransaccion.ReadOnly = !readOnly;
            txtCodigoVD.ReadOnly = !readOnly;
            txtCtaReferencia.ReadOnly = !readOnly;
            txtNumDeposito.ReadOnly = !readOnly;
            nudMontoDeclarado.ReadOnly = !readOnly;
            nudMontoNiquel.ReadOnly = !readOnly;
            gbcolones.Enabled = readOnly;
            gbdolares.Enabled = readOnly;
            gbeuros.Enabled = readOnly;
            cboMoneda.Enabled = readOnly;
            cboMonedaDeclarada.Enabled = readOnly;
            cboTipoMesaNiquel.Enabled = readOnly;
        }

        private void frmActualizarBajoVolumen_Load(object sender, EventArgs e)
        {
            try
            {
                nud20USD.Tag = nud20USD.Value;
                nud20000CRC.Tag = nud20000CRC.Value;
                nud20EUR.Tag = nud20EUR.Value;
                nud1USD.Tag = nud1USD.Value;
                nud500EUR.Tag = nud500EUR.Value;
                nud1000CRC.Tag = nud1000CRC.Value;
                nud2000CRC.Tag = nud2000CRC.Value;
                nud200EUR.Tag = nud200EUR.Value;
                nud10USD.Tag = nud10USD.Value;
                nud10000CRC.Tag = nud10000CRC.Value;
                nud10EUR.Tag = nud10EUR.Value;
                nud50USD.Tag = nud50USD.Value;
                nud50000CRC.Tag = nud50000CRC.Value;
                nud50EUR.Tag = nud50EUR.Value;
                nud5USD.Tag = nud5USD.Value;
                nud5000CRC.Tag = nud5000CRC.Value;
                nud5EUR.Tag = nud5EUR.Value;
                nud100USD.Tag = nud100USD.Value;
                nud100EUR.Tag = nud100EUR.Value;
                cboTipoMesaNiquel.Items.Clear();

                _deposito = _mantenimiento.obtieneDeposito(idDeposito);
                cboTipoMesaNiquel.Items.Clear();
                cboTipoMesaNiquel.ValueMember = "pk_ID";
                cboTipoMesaNiquel.DisplayMember = "Nombre";
                if (_deposito.TipomesaNiquel == 1)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Nombre");
                    dt.Columns.Add("pk_ID");
                    dt.Rows.Add("Mesa Níquel", 0);
                    cboTipoMesaNiquel.DataSource = dt;
                    cboTipoMesaNiquel.SelectedIndex = 0;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Nombre");
                    dt.Columns.Add("pk_ID");
                    dt.Rows.Add("En Mesa", 0);
                    dt.Rows.Add("Cajero Níquel", 2);
                    cboTipoMesaNiquel.DataSource = dt;
                    cboTipoMesaNiquel.SelectedIndex = (_deposito.TipomesaNiquel == 0) ? 0 : 1;
                }
                conteoBillete = _mantenimiento.selectConteoBillete(idDeposito);
                listabilletefalso = _mantenimiento.selectBilletesFalsos(idDeposito);
                listabilletefalsoAnterior = _mantenimiento.selectBilletesFalsos(idDeposito);
                listachequedeposito = _mantenimiento.SelectChequesDeposito(idDeposito);
                listachequedepositoAnterior = _mantenimiento.SelectChequesDeposito(idDeposito);
                compraVenta = _mantenimiento.selectIngresoCompraVenta(idDeposito);
                if (compraVenta != null)
                {
                    TipoCambio t = _mantenimiento.obtenerTipoCambio(_manifiesto.Fecha_Procesamiento);
                    compraVenta.TipoCambio = t;
                    _deposito.CompraVenta = compraVenta;
                }
                _deposito.ChequeDeposito = listachequedepositoAnterior;
                _deposito.BilletesFalsos = listabilletefalsoAnterior;
                cargarFrame();
                datosCargados = true;
            }


            catch
            {
                MessageBox.Show("Error al cargar los datos", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void cargarFrame()
        {
            txtCodigoVD.Text = _deposito.CodigoVD;
            txtNumDeposito.Text = _deposito.NumeroDeposito;
            txtCtaReferencia.Text = _deposito.CuentaReferencia;
            cboMonedaDeclarada.SelectedIndex = (int)_deposito.Moneda;
            if (_deposito.TipomesaNiquel == 2)
            {
                cboTipoMesaNiquel.SelectedIndex = 1;
            }
            else
            {
                cboTipoMesaNiquel.SelectedIndex = 0;
            }

            txtCedula.Text = _deposito.Cedula;
            nudMontoDeclarado.Value = _deposito.MontoDeclarado;
            nudMontoNiquel.Value = _deposito.MontoNiquel;
            txtCodigoTransaccion.Text = _deposito.CodigoTransaccion;
            txtMontoContado.Text = _deposito.Monto.ToString();
            txtDiferencia.Text = _deposito.MontoDiferencia.ToString();
            if (_deposito.TipomesaNiquel == 1)
            {
                conteoNiquel = _mantenimiento.selectConteoNiquel(_deposito.ID);
                conteoNanterior = _mantenimiento.selectConteoNiquel(_deposito.ID);
            }
            int moneda = (int)conteoBillete.Moneda;
            cboMoneda.SelectedIndex = moneda;
            if (moneda == 0)
            {
                nud1000CRC.Value = conteoBillete.CRC1000;
                nud2000CRC.Value = conteoBillete.CRC2000;
                nud5000CRC.Value = conteoBillete.CRC5000;
                nud10000CRC.Value = conteoBillete.CRC10000;
                nud20000CRC.Value = conteoBillete.CRC20000;
                nud50000CRC.Value = conteoBillete.CRC50000;
                gbcolones.BringToFront();
            }
            else if (moneda == 1)
            {
                nud1USD.Value = conteoBillete.USD1;
                nud5USD.Value = conteoBillete.USD5;
                nud10USD.Value = conteoBillete.USD10;
                nud20USD.Value = conteoBillete.USD20;
                nud50USD.Value = conteoBillete.USD50;
                nud100USD.Value = conteoBillete.USD100;
                gbdolares.BringToFront();
            }
            else
            {
                nud5EUR.Value = conteoBillete.EUR5;
                nud10EUR.Value = conteoBillete.EUR10;
                nud20EUR.Value = conteoBillete.EUR20;
                nud50EUR.Value = conteoBillete.EUR50;
                nud100EUR.Value = conteoBillete.EUR100;
                nud200EUR.Value = conteoBillete.EUR200;
                nud500EUR.Value = conteoBillete.EUR500;
                gbeuros.BringToFront();
            }
            datosCargados = true;

        }

        private void btnIngresoCheques_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Monedas _monedadeposito = (Monedas)cboMonedaDeclarada.SelectedIndex;
            Colaborador c = new Colaborador();
            frmActualizarIngresoChequesCE formulario = new frmActualizarIngresoChequesCE(ref listachequedeposito, ref c, ref _monedadeposito, readOnly);
            formulario.ShowDialog(this);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (montosCorrectos() && validaNumeric())
                {
                    modificarDeposito();
                    verificaCambioNiquel();
                    _mantenimiento.actualizarCierreCajero(_manifiesto);
                    MessageBox.Show("Datos Actualizados Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dt = _mantenimiento.procesamientoBVPendiente(_manifiesto.ID);
                    if (dt.Rows.Count == 0)
                    {
                        _mantenimiento.updateProaInconsistenciasManifiesto(_manifiesto, _colaborador);
                    }
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hay datos incorrectos, verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }
        }


        private bool txtBueno(TextBox txt)
        {
            Int64 number;
            bool bueno = Int64.TryParse(txt.Text, out number) || txt.Text=="";
            epError.SetError(txt, (bueno)?"":"Este campo solo acepta datos numéricos");
            return bueno;
        }



        private bool validaNumeric(){
            return txtBueno(txtCodigoTransaccion) && txtBueno(txtCedula) && txtBueno(txtNumDeposito) && txtBueno(txtCtaReferencia);
        }

        private void verificaCambioNiquel()
        {
            if (_deposito.TipomesaNiquel != _depositoNuevo.TipomesaNiquel)
            {
                if (_deposito.TipomesaNiquel == 0)
                {
                    _mantenimiento.updateMontoMesa(_deposito.MontoNiquel, _manifiesto.Cajero);
                    procesacajeroniquel();
                }
                else
                {
                    _mantenimiento.updateMontoMesa(-_depositoNuevo.MontoNiquel, _manifiesto.Cajero);//SUMAR EL NUEVO MONTO NIQUEL
                    _mantenimiento.eliminaInfoFormularioBoletaNiquelEntregaCajeroNiquel(_depositoNuevo.ID);

                }
            }
            else if ((_deposito.TipomesaNiquel == _depositoNuevo.TipomesaNiquel) && _deposito.TipomesaNiquel == 0)
            {
                _mantenimiento.updateMontoMesa(-(_depositoNuevo.MontoNiquel - _deposito.MontoNiquel), _manifiesto.Cajero);//SUMAR EL NUEVO MONTO NIQUEL
            }
        }

        private void procesacajeroniquel()
        {
            try
            {
                BoletaCajeroNiquel boleta = new BoletaCajeroNiquel(cajero: _manifiesto.Cajero.ID, fecha_generacion: new DateTime(), manifiesto: _manifiesto.IDManifiesto, tula: _tulaActual.ID, cuenta: txtCtaReferencia.Text,
                    numerodeposito: _depositoNuevo.NumeroDeposito, montoniquel: _depositoNuevo.MontoNiquel, montodeposito: _depositoNuevo.Monto, procesobajovolumendeposito: _deposito.ID, cliente: _manifiesto.Cliente.Id);
                _mantenimiento.agregarBoletaCajeroNiquel(ref boleta);
                imprimirBoletaCajeroNiquel(_manifiesto.Cliente, _manifiesto, _manifiesto.Cajero, _tulaActual, _depositoNuevo, boleta.ID);

            }
            catch (Excepcion ex)
            {
                MessageBox.Show("procesacajeroniquel error: " + ex.Message);
            }
        }


        private void imprimirBoletaCajeroNiquel(Cliente c, ProcesamientoBajoVolumenManifiesto m, Colaborador co, Tula t, Deposito d, int id)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla boleta_niquel_cajero_niquel.xlsx", false);

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("D2");
                documento.actualizarValorCelda("BOLETA DE EFECTIVO No. " + Convert.ToString(id));

                documento.seleccionarCelda("C4");
                if (c != null)
                {
                    documento.actualizarValorCelda(c.Nombre);
                }

                documento.seleccionarCelda("C6");
                documento.actualizarValorCelda(co.Nombre + " " + co.Primer_apellido + " " + co.Segundo_apellido);

                documento.seleccionarCelda("C8");
                documento.actualizarValorCelda(d.CuentaReferencia);

                documento.seleccionarCelda("C10");
                documento.actualizarValorCelda(d.Monto);

                documento.seleccionarCelda("C12");
                documento.actualizarValorCelda(d.MontoNiquel);

                documento.seleccionarCelda("F8");
                documento.actualizarValorCelda(m.Codigo);

                documento.seleccionarCelda("F10");
                documento.actualizarValorCelda(t.Codigo);

                documento.seleccionarCelda("F12");
                documento.actualizarValorCelda(d.NumeroDeposito);

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imprimeboletacajeroniquel error: " + ex.Message);
                //Excepcion.mostrarMensaje("ErrorExcel");
            }

        }


        private bool montosCorrectos()
        {
            if (cboMoneda.SelectedIndex == 0)
            {
                return montoCorrecto(50000, nud50000CRC) && montoCorrecto(20000, nud20000CRC) && montoCorrecto(10000, nud10000CRC) && montoCorrecto(5000, nud5000CRC) && montoCorrecto(2000, nud2000CRC) && montoCorrecto(1000, nud1000CRC);
            }
            else if (cboMoneda.SelectedIndex == 1)
            {
                return montoCorrecto(20, nud20USD) && montoCorrecto(50, nud50USD) && montoCorrecto(10, nud10USD) && montoCorrecto(100, nud100USD);

            }
            else
                return montoCorrecto(5, nud5EUR) && montoCorrecto(100, nud100EUR) && montoCorrecto(10, nud10EUR) && montoCorrecto(200, nud200EUR) && montoCorrecto(20, nud20EUR) && montoCorrecto(500, nud500EUR) && montoCorrecto(50, nud50EUR);
        }

        public void actualizarbilletesfalsos(BindingList<BilleteFalso> listabilletefalso)
        {

            _deposito.BilletesFalsos = listabilletefalso;
            origendiferenciadeposito = 2;
            sumarTotales();
        }


        private void modificarDeposito()
        {
            cargarNuevoDeposito();//cargar _depositoNuevo
            cargarDetalleBillete();//cargar conteoNuevo    
            updateConteoNiquel();
            _mantenimiento.UpdateBilletesFalsos(_deposito.ID, listabilletefalso, listabilletefalsoAnterior, _colaborador.ID);
            _mantenimiento.UpdateCheques(_deposito.ID, listachequedeposito, listachequedepositoAnterior, _colaborador.ID);
            _mantenimiento.InsertBitacoraDeposito(_colaborador, _deposito, _depositoNuevo);
            _mantenimiento.actualizarDeposito(_depositoNuevo, _colaborador);
            _mantenimiento.updateDepositoMonto(_colaborador.ID, conteoBillete, conteoNuevo);//DETALLE DE BILLETES
            DateTime fprocesobajovolumendeposito = _mantenimiento.obtenerProcesamientoBajoVolumenDeposito(_depositoNuevo.ID);
            _mantenimiento.UpdateInconsistencias(_deposito, _depositoNuevo, _manifiesto, _tulaActual, origendiferenciadeposito, fprocesobajovolumendeposito, _colaborador);
        }

        private void cargarDetalleBillete()
        {
            decimal CRC1000 = 0, CRC2000 = 0, CRC5000 = 0, CRC10000 = 0;
            decimal CRC20000 = 0, CRC50000 = 0, USD1 = 0, USD5 = 0;
            decimal USD10 = 0, USD20 = 0, USD50 = 0, USD100 = 0, EUR5 = 0;
            decimal EUR10 = 0, EUR20 = 0, EUR50 = 0, EUR100 = 0, EUR200 = 0, EUR500 = 0;
            if (_depositoNuevo.Moneda == Monedas.Colones)
            {
                CRC1000 = nud1000CRC.Value;
                CRC2000 = nud2000CRC.Value;
                CRC5000 = nud5000CRC.Value;
                CRC10000 = nud10000CRC.Value;
                CRC20000 = nud20000CRC.Value;
                CRC50000 = nud50000CRC.Value;
            }
            else if (_depositoNuevo.Moneda == Monedas.Dolares)
            {
                USD1 = nud1USD.Value;
                USD5 = nud5USD.Value;
                USD10 = nud10USD.Value;
                USD20 = nud20USD.Value;
                USD50 = nud50USD.Value;
                USD100 = nud100USD.Value;

            }
            else
            {
                EUR5 = nud5EUR.Value; ;
                EUR10 = nud10EUR.Value;
                EUR20 = nud20EUR.Value;
                EUR50 = nud50EUR.Value;
                EUR100 = nud100EUR.Value;
                EUR200 = nud200EUR.Value;
                EUR500 = nud500EUR.Value;
            }
            conteoNuevo = new ConteoBillete(id: 0, c50000: CRC50000, c20000: CRC20000, c10000: CRC10000, c5000: CRC5000, c2000: CRC2000, c1000: CRC1000, u100: USD100, u50: USD50, u20: USD20, u10: USD10, u5: USD5, u1: USD1, e500: EUR500, e200: EUR200, e100: EUR100, e50: EUR50, e20: EUR20, e10: EUR10, e5: EUR5, moneda: _depositoNuevo.Moneda, idpbv: conteoBillete.id_PBV);
        }

        private void cargarNuevoDeposito()
        {
            _depositoNuevo = new Deposito(0);
            _depositoNuevo.ID = _deposito.ID;
            _depositoNuevo.BilletesFalsos = listabilletefalso;
            _depositoNuevo.Moneda = (Monedas)cboMonedaDeclarada.SelectedIndex;
            _depositoNuevo.MontoDeclarado = nudMontoDeclarado.Value;
            _depositoNuevo.Monto = Convert.ToDecimal(txtMontoContado.Text);
            _depositoNuevo.CuentaReferencia = txtCtaReferencia.Text;
            _depositoNuevo.NumeroDeposito = txtNumDeposito.Text;
            _depositoNuevo.MontoDiferencia = Convert.ToDecimal(txtDiferencia.Text);
            _depositoNuevo.CodigoTransaccion = txtCodigoTransaccion.Text;
            _depositoNuevo.TipomesaNiquel = Convert.ToInt32(cboTipoMesaNiquel.SelectedValue);
            _depositoNuevo.Cedula = txtCedula.Text;
            _depositoNuevo.MontoNiquel = nudMontoNiquel.Value;
        }

        private void updateConteoNiquel()
        {
            if (_deposito.TipomesaNiquel == 1)
            {
                _mantenimiento.updateConteoNiquel(conteoNiquel, conteoNanterior, idDeposito, _colaborador.ID);
            }
        }

        private void llenaBitacoras()
        {
            if (depositoActualzado)
            {
                txtCodigoVD.Text = _deposito.CodigoVD;
                txtNumDeposito.Text = _deposito.NumeroDeposito;
                txtCtaReferencia.Text = _deposito.CuentaReferencia;
                cboMonedaDeclarada.SelectedIndex = (int)_deposito.Moneda;
                //cboTipoMesaNiquel.SelectedIndex = Int32.Parse(dt.Rows[0][4].ToString());
                txtCedula.Text = _deposito.Cedula;
                nudMontoDeclarado.Value = _deposito.MontoDeclarado;
                nudMontoNiquel.Value = _deposito.MontoNiquel;
                txtCodigoTransaccion.Text = _deposito.CodigoTransaccion;
                int moneda = (int)_deposito.Moneda;
                cboMoneda.SelectedIndex = moneda;
            }

        }

        private void btnbilletesfalsos_Click(object sender, EventArgs e)
        {
            try
            {

                Monedas _monedadeposito = (Monedas)cboMonedaDeclarada.SelectedIndex;
                Colaborador c = new Colaborador();
                frmActualizarRegistroBilletesFalsos formulario = new frmActualizarRegistroBilletesFalsos(ref listabilletefalso, ref c, ref _monedadeposito, readOnly);
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void sumarTotales()
        {
            try
            {
                decimal totalDiferencia;
                decimal totalcheques = 0;
                decimal totalcompraventa = 0;
                decimal totalniquel = 0;
                decimal totalcontado = 0;
                if (_deposito != null)
                {
                    if (_deposito.ChequeDeposito != null)
                    {
                        if (_deposito.ChequeDeposito.Count > 0)
                        {
                            foreach (ChequeDeposito chequedeposito in _deposito.ChequeDeposito)
                            {
                                totalcheques += chequedeposito.Monto;
                            }
                        }
                    }
                    if (_deposito.CompraVenta != null)
                    {
                        if (_deposito.CompraVenta != null)
                        {
                            totalcompraventa += _deposito.CompraVenta.MontoCambio;
                        }
                    }
                    totalniquel = System.Convert.ToInt32(nudMontoNiquel.Value);

                }
                switch (cboMoneda.Text)
                {
                    case "Colones":

                        decimal totalbilletes = nud5000CRC.Value + nud50000CRC.Value + nud10000CRC.Value + nud2000CRC.Value +
                        nud1000CRC.Value + nud20000CRC.Value;
                        totalcontado = totalbilletes + totalcheques + totalcompraventa + totalniquel;
                        totalDiferencia = totalcontado - nudMontoDeclarado.Value;
                        txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtMontoContado.Text = System.Convert.ToString(totalcontado);
                        break;
                    case "Dólares":

                        decimal totalDolares = nud100USD.Value + nud5USD.Value + nud50USD.Value +
                            nud10USD.Value + nud1USD.Value + nud20USD.Value;
                        totalcontado = totalDolares + totalcheques + totalcompraventa + totalniquel;
                        totalDiferencia = totalcontado - nudMontoDeclarado.Value;
                        txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtMontoContado.Text = System.Convert.ToString(totalcontado);

                        break;
                    case "Euros":

                        decimal totalEuros = nud100EUR.Value + nud5EUR.Value + nud50EUR.Value + nud10EUR.Value +
                        nud200EUR.Value + nud500EUR.Value + nud20EUR.Value;
                        totalcontado = totalEuros + totalcheques + totalcompraventa + totalniquel;
                        totalDiferencia = totalcontado - nudMontoDeclarado.Value;
                        txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtMontoContado.Text = System.Convert.ToString(totalcontado);

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("sumartotales error: " + ex.Message);
            }
        }


        private bool montoCorrecto(Decimal denominacion, NumericUpDown t)
        {
            if ((t.Value % denominacion) != 0)
            {
                epError.SetError(t, "Monto incorrecto, debe ser múltiplo de " + denominacion);
                return false;
            }
            else
            {
                epError.SetError(t, "");
                return true;
            }
        }

        private bool ValidarMontos(Decimal monto, Decimal denominacion, NumericUpDown t)
        {
            bool bStatus = true;
            if ((monto % denominacion) != 0)
            {
                if (epError.GetError(t).Contains("No se puede ingresar ese monto") == false)
                    nuderror2 += 1;
                epError.SetError(t, "No se puede ingresar ese monto, tiene que ser en montos de acuerdo a la denominación asociada");
                bStatus = false;
                sumarTotales();
            }
            else
            {
                if (Error != true)
                {
                    if (epError.GetError(t).Contains("el valor permitido es igual o mayor a") == false)
                    {
                        if (epError.GetError(t).Equals("") == false)
                            nuderror2 -= 1;
                        epError.SetError(t, "");
                    }
                    else
                    {
                        if (epError.GetError(t).Equals("") == false)
                            nuderror2 -= 1;
                    }
                }
            }

            return bStatus;

        }

        private void revisarprocesovacio()
        {
            try
            {
                if ((txtNumDeposito.Text.Equals("")) && (txtCedula.Text.Equals("")) && (txtCodigoTransaccion.Text.Equals("")) && (txtCtaReferencia.Text.Equals("")) &&
                    (nudMontoDeclarado.Value == 0) && (nudMontoNiquel.Value == 0) && (cboMonedaDeclarada.SelectedIndex == 0) && (Decimal.Compare(Convert.ToDecimal(txtMontoContado.Text), 0) == 0))
                {
                    chkcierremanifiesto = 1;
                }
                else chkcierremanifiesto = 0;
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error revisarprocesovacío: " + ex.Message);
            }
        }

        private void nud1USD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud1USD.Tag;
                    if (mValuePre > nud1USD.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud1USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud1USD.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud1USD.Value, 1, nud1USD))
                        {
                            Error = false;
                            if (epError.GetError(nud1USD).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud1USD, "");
                            nud1USD.Tag = nud1USD.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudunusd_valuechanged error: " + ex.Message);
            }
        }

        private void nud1USD_Click(object sender, EventArgs e)
        {
            nud1USD.Select(0, nud1USD.Text.Length);
        }

        private void nud1USD_Enter(object sender, EventArgs e)
        {
            nud1USD.Select(0, nud1USD.Text.Length);
        }

        private void nudMontoDeclarado_Click(object sender, EventArgs e)
        {
            nudMontoDeclarado.Select(0, nudMontoDeclarado.Text.Length);
        }

        private void nudMontoDeclarado_Leave(object sender, EventArgs e)
        {
            revisarprocesovacio();
        }

        private void nudMontoDeclarado_ValueChanged(object sender, EventArgs e)
        {
            epError.SetError(nudMontoDeclarado, "");
            sumarTotales();
            conteoerrores = 0;
        }

        private void nudMontoDeclarado_Enter(object sender, EventArgs e)
        {
            nudMontoDeclarado.Select(0, nudMontoDeclarado.Text.Length);
        }


        #region leave cololes

        private void nud50000CRC_Leave(object sender, EventArgs e)
        {
            montoCorrecto(50000, nud50000CRC);
            revisarprocesovacio();
        }

        private void nud20000CRC_Leave(object sender, EventArgs e)
        {
            montoCorrecto(20000, nud20000CRC);
            revisarprocesovacio();
        }

        private void nud10000CRC_Leave(object sender, EventArgs e)
        {
            montoCorrecto(10000, nud10000CRC);
            revisarprocesovacio();
        }

        private void nud5000CRC_Leave(object sender, EventArgs e)
        {
            montoCorrecto(5000, nud5000CRC);
            revisarprocesovacio();
        }

        private void nud2000CRC_Leave(object sender, EventArgs e)
        {
            montoCorrecto(2000, nud2000CRC);
            revisarprocesovacio();
        }

        private void nud1000CRC_Leave(object sender, EventArgs e)
        {
            montoCorrecto(1000, nud1000CRC);
            revisarprocesovacio();
        }

        #endregion
        #region leave euros

        private void nudcincoeur_Leave(object sender, EventArgs e)
        {
            montoCorrecto(5, nud5EUR);
            revisarprocesovacio();
        }

        private void nudcieneur_Leave(object sender, EventArgs e)
        {
            montoCorrecto(100, nud100EUR);
            revisarprocesovacio();
        }

        private void nuddiezeur_Leave(object sender, EventArgs e)
        {
            montoCorrecto(10, nud10EUR);
            revisarprocesovacio();
        }

        private void nuddoscientoseur_Leave(object sender, EventArgs e)
        {
            montoCorrecto(200, nud200EUR);
            revisarprocesovacio();
        }

        private void nudveinteeur_Leave(object sender, EventArgs e)
        {
            montoCorrecto(20, nud20EUR);
            revisarprocesovacio();
        }

        private void nudquinientoseur_Leave(object sender, EventArgs e)
        {
            montoCorrecto(500, nud500EUR);
            revisarprocesovacio();
        }

        private void nudcincuentaeur_Leave(object sender, EventArgs e)
        {
            montoCorrecto(50, nud50EUR);
            revisarprocesovacio();
        }


        #endregion
        #region leave dolares
        private void nudunusd_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud1USD.Value, 1, nud1USD);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudunusd_leave error: " + ex.Message);
            }
        }

        private void nudveinteusd_Leave(object sender, EventArgs e)
        {
            montoCorrecto(20, nud20USD);
            revisarprocesovacio();
        }

        private void nudcincousd_Leave(object sender, EventArgs e)
        {
            montoCorrecto(5, nud5USD);
            revisarprocesovacio();
        }

        private void nudcincuentausd_Leave(object sender, EventArgs e)
        {
            montoCorrecto(50, nud50USD);
            revisarprocesovacio();
        }

        private void nuddiezusd_Leave(object sender, EventArgs e)
        {
            montoCorrecto(10, nud10USD);
            revisarprocesovacio();
        }

        private void nudcienusd_Leave(object sender, EventArgs e)
        {
            montoCorrecto(100, nud100USD);
            revisarprocesovacio();
        }
        #endregion
        #region click enter event


        private void nud20USD_Enter(object sender, EventArgs e)
        {
            nud20USD.Select(0, nud20USD.Text.Length);
        }

        private void nud5USD_Enter(object sender, EventArgs e)
        {
            nud5USD.Select(0, nud5USD.Text.Length);
        }

        private void nud10USD_Enter(object sender, EventArgs e)
        {
            nud10USD.Select(0, nud10USD.Text.Length);
        }

        private void nud100USD_Enter(object sender, EventArgs e)
        {
            nud100USD.Select(0, nud100USD.Text.Length);
        }

        private void nud50USD_Enter(object sender, EventArgs e)
        {
            nud50USD.Select(0, nud50USD.Text.Length);
        }

        private void nud50000CRC_Enter(object sender, EventArgs e)
        {
            nud50000CRC.Select(0, nud50000CRC.Text.Length);
        }

        private void nud20000CRC_Enter(object sender, EventArgs e)
        {
            nud20000CRC.Select(0, nud20000CRC.Text.Length);
        }

        private void nud10000CRC_Enter(object sender, EventArgs e)
        {
            nud10000CRC.Select(0, nud10000CRC.Text.Length);
        }

        private void nud5000CRC_Enter(object sender, EventArgs e)
        {
            nud5000CRC.Select(0, nud5000CRC.Text.Length);
        }

        private void nud2000CRC_Enter(object sender, EventArgs e)
        {
            nud2000CRC.Select(0, nud2000CRC.Text.Length);
        }

        private void nud1000CRC_Enter(object sender, EventArgs e)
        {
            nud1000CRC.Select(0, nud1000CRC.Text.Length);
        }

        private void nud5EUR_Enter(object sender, EventArgs e)
        {
            nud5EUR.Select(0, nud5EUR.Text.Length);
        }

        private void nud100EUR_Enter(object sender, EventArgs e)
        {
            nud100EUR.Select(0, nud100EUR.Text.Length);
        }

        private void nud10EUR_Enter(object sender, EventArgs e)
        {
            nud10EUR.Select(0, nud10EUR.Text.Length);
        }

        private void nud200EUR_Enter(object sender, EventArgs e)
        {
            nud200EUR.Select(0, nud200EUR.Text.Length);
        }

        private void nud20EUR_Enter(object sender, EventArgs e)
        {
            nud20EUR.Select(0, nud20EUR.Text.Length);
        }

        private void nud500EUR_Enter(object sender, EventArgs e)
        {
            nud500EUR.Select(0, nud500EUR.Text.Length);
        }

        private void nud50EUR_Enter(object sender, EventArgs e)
        {
            nud50EUR.Select(0, nud50EUR.Text.Length);
        }

        private void nudMontoNiquel_Enter(object sender, EventArgs e)
        {
            nudMontoNiquel.Select(0, nudMontoNiquel.Text.Length);
        }

        private void nud5EUR_Click(object sender, EventArgs e)
        {
            nud5EUR.Select(0, nud5EUR.Text.Length);
        }

        private void nud5000CRC_Click(object sender, EventArgs e)
        {
            nud5000CRC.Select(0, nud5000CRC.Text.Length);
        }

        private void nud50000CRC_Click(object sender, EventArgs e)
        {
            nud50000CRC.Select(0, nud50000CRC.Text.Length);
        }

        private void nud20000CRC_Click(object sender, EventArgs e)
        {
            nud20000CRC.Select(0, nud20000CRC.Text.Length);
        }

        private void nud10000CRC_Click(object sender, EventArgs e)
        {
            nud10000CRC.Select(0, nud10000CRC.Text.Length);
        }

        private void nud1000CRC_Click(object sender, EventArgs e)
        {
            nud1000CRC.Select(0, nud1000CRC.Text.Length);
        }


        private void nudMontoNiquel_Click(object sender, EventArgs e)
        {
            nudMontoNiquel.Select(0, nudMontoNiquel.Text.Length);
        }

        private void nud2000CRC_Click(object sender, EventArgs e)
        {
            nud2000CRC.Select(0, nud2000CRC.Text.Length);
        }

        private void nud10EUR_Click(object sender, EventArgs e)
        {
            nud10EUR.Select(0, nud10EUR.Text.Length);
        }

        private void nud200EUR_Click(object sender, EventArgs e)
        {
            nud200EUR.Select(0, nud200EUR.Text.Length);
        }

        private void nud100EUR_Click(object sender, EventArgs e)
        {
            nud100EUR.Select(0, nud100EUR.Text.Length);
        }

        private void nud500EUR_Click(object sender, EventArgs e)
        {
            nud500EUR.Select(0, nud500EUR.Text.Length);
        }

        private void nud20EUR_Click(object sender, EventArgs e)
        {
            nud20EUR.Select(0, nud20EUR.Text.Length);
        }

        private void nud50EUR_Click(object sender, EventArgs e)
        {
            nud50EUR.Select(0, nud50EUR.Text.Length);
        }


        private void nud20USD_Click(object sender, EventArgs e)
        {
            nud20USD.Select(0, nud20USD.Text.Length);
        }

        private void nud5USD_Click(object sender, EventArgs e)
        {
            nud5USD.Select(0, nud5USD.Text.Length);
        }

        private void nud50USD_Click(object sender, EventArgs e)
        {
            nud50USD.Select(0, nud50USD.Text.Length);
        }

        private void nud10USD_Click(object sender, EventArgs e)
        {
            nud10USD.Select(0, nud10USD.Text.Length);
        }

        private void nud100USD_Click(object sender, EventArgs e)
        {
            nud100USD.Select(0, nud100USD.Text.Length);
        }
        #endregion

        #region valuechanged


        private void nudcincoeur_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {

                    decimal mValuePre = (decimal)nud5EUR.Tag;
                    if (mValuePre > nud5EUR.Value)
                    {
                        epError.SetError(nud5EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud5EUR.Tag);
                        Error = true;
                        nuderror += 1;
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud5EUR.Value, 5, nud5EUR))
                        {
                            Error = false;
                            if (epError.GetError(nud5EUR).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud5EUR, "");
                            nud5EUR.Tag = nud5EUR.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincoeur_valuechanged error: " + ex.Message);
            }
        }

        private void nudcieneur_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud100EUR.Tag;
                    if (mValuePre > nud100EUR.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud100EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud100EUR.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud100EUR.Value, 100, nud100EUR))
                        {
                            Error = false;
                            if (epError.GetError(nud100EUR).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud100EUR, "");
                            nud100EUR.Tag = nud100EUR.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcieneur_valuechanged error: " + ex.Message);
            }
        }

        private void nuddiezeur_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud10EUR.Tag;
                    if (mValuePre > nud10EUR.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud10EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud10EUR.Tag);
                        sumarTotales();
                        nud10EUR.Focus();
                    }
                    else
                    {
                        if (ValidarMontos(nud10EUR.Value, 10, nud10EUR))
                        {
                            Error = false;
                            if (epError.GetError(nud10EUR).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud10EUR, "");
                            nud10EUR.Tag = nud10EUR.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nuddiezeur_valuechanged error: " + ex.Message);
            }
        }

        private void nuddoscientoseur_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud200EUR.Tag;
                    if (mValuePre > nud200EUR.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud200EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud200EUR.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud200EUR.Value, 200, nud200EUR))
                        {
                            nud200EUR.Tag = nud200EUR.Value;
                            if (epError.GetError(nud200EUR).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud200EUR, "");
                            origendiferenciadeposito = 0;
                            sumarTotales();
                            Error = false;
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nuddoscientoseur_valuechanged error: " + ex.Message);
            }
        }

        private void nudveinteeur_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud20EUR.Tag;
                    if (mValuePre > nud20EUR.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud20EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud20EUR.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud20EUR.Value, 20, nud20EUR))
                        {
                            if (epError.GetError(nud20EUR).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud20EUR, "");
                            nud20EUR.Tag = nud20EUR.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                            Error = false;
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudveinteeur_valuechanged error: " + ex.Message);
            }
        }

        private void nudquinientoseur_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud500EUR.Tag;
                    if (mValuePre > nud500EUR.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud500EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud500EUR.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud500EUR.Value, 500, nud500EUR))
                        {
                            Error = false;
                            if (epError.GetError(nud500EUR).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud500EUR, "");
                            nud500EUR.Tag = nud500EUR.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudquinientoseur_valuechanged error: " + ex.Message);
            }
        }

        private void nudcincuentaeur_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud50EUR.Tag;
                    if (mValuePre > nud50EUR.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud50EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud50EUR.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud50EUR.Value, 50, nud50EUR))
                        {
                            Error = false;
                            if (epError.GetError(nud50EUR).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud50EUR, "");
                            nud50EUR.Tag = nud50EUR.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincuentaeur_valuechanged error: " + ex.Message);
            }
        }

        private void nudunusd_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {
                decimal mValuePre = (decimal)nud1USD.Tag;
                if (mValuePre > nud1USD.Value)
                {
                    Error = true;
                    nuderror += 1;
                    epError.SetError(nud1USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud1USD.Tag);
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud1USD.Value, 1, nud1USD))
                    {
                        Error = false;
                        if (epError.GetError(nud1USD).Equals("") == false) nuderror -= 1;
                        epError.SetError(nud1USD, "");
                        nud1USD.Tag = nud1USD.Value;
                        origendiferenciadeposito = 0;
                        sumarTotales();
                    }
                }
                epError.SetError(txtDiferencia, "");
            }
        }

        private void nudveinteusd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud20USD.Tag;
                    if (mValuePre > nud20USD.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud20USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud20USD.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud20USD.Value, 20, nud20USD))
                        {
                            Error = false;
                            if (epError.GetError(nud20USD).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud20USD, "");
                            nud20USD.Tag = nud20USD.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudveinteusd_valuechanged error: " + ex.Message);
            }
        }

        private void nudcincousd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud5USD.Tag;
                    if (mValuePre > nud5USD.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud5USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud5USD.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud5USD.Value, 5, nud5USD))
                        {
                            Error = false;
                            if (epError.GetError(nud5USD).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud5USD, "");
                            nud5USD.Tag = nud5USD.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincousd_valuechanged error: " + ex.Message);
            }
        }

        private void nudcincuentausd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud50USD.Tag;
                    if (mValuePre > nud50USD.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud50USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud50USD.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud50USD.Value, 50, nud50USD))
                        {
                            Error = false;
                            if (epError.GetError(nud50USD).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud50USD, "");
                            nud50USD.Tag = nud50USD.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincuentausd_valuechanged error: " + ex.Message);
            }
        }

        private void nuddiezusd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud10USD.Tag;
                    if (mValuePre > nud10USD.Value)
                    {
                        Error = true;
                        nuderror += 1;
                        epError.SetError(nud10USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud10USD.Tag);
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud10USD.Value, 10, nud10USD))
                        {
                            Error = false;
                            if (epError.GetError(nud10USD).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud10USD, "");
                            nud10USD.Tag = nud10USD.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nuddiezusd_valuechanged error: " + ex.Message);
            }
        }

        private void nudcienusd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud100USD.Tag;
                    if (mValuePre > nud100USD.Value)
                    {
                        Error = true;
                        epError.SetError(nud100USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud100USD.Tag);
                        nuderror += 1;
                        sumarTotales();
                    }
                    else
                    {
                        if (ValidarMontos(nud100USD.Value, 100, nud100USD))
                        {
                            Error = false;
                            if (epError.GetError(nud100USD).Equals("") == false) nuderror -= 1;
                            epError.SetError(nud100USD, "");
                            nud100USD.Tag = nud100USD.Value;
                            origendiferenciadeposito = 0;
                            sumarTotales();
                        }
                    }
                    epError.SetError(txtDiferencia, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcienusd_valuechanged error: " + ex.Message);
            }
        }

        private void nudCincuentamil_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {
                decimal mValuePre = (decimal)nud50000CRC.Tag;
                if (mValuePre > nud50000CRC.Value)
                {
                    Error = true;
                    epError.SetError(nud50000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud50000CRC.Tag);
                    nuderror += 1;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud50000CRC.Value, 50000, nud50000CRC))
                    {
                        Error = false;
                        if (epError.GetError(nud50000CRC).Equals("") == false) nuderror -= 1;
                        epError.SetError(nud50000CRC, "");
                        nud50000CRC.Tag = nud50000CRC.Value;
                        origendiferenciadeposito = 0;
                        sumarTotales();
                    }
                }
                epError.SetError(txtDiferencia, "");
            }
        }

        private void nudCincomil_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {
                decimal mValuePre = (decimal)nud5000CRC.Tag;
                if (mValuePre > nud5000CRC.Value)
                {
                    Error = true;
                    epError.SetError(nud5000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud5000CRC.Tag);
                    nuderror += 1;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud5000CRC.Value, 5000, nud5000CRC))
                    {
                        Error = false;
                        if (epError.GetError(nud5000CRC).Equals("") == false) nuderror -= 1;
                        epError.SetError(nud5000CRC, "");
                        nud5000CRC.Tag = nud5000CRC.Value;
                        origendiferenciadeposito = 0;
                        sumarTotales();
                    }
                }
                epError.SetError(txtDiferencia, "");
            }
        }

        private void nudVeintemil_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {
                decimal mValuePre = (decimal)nud20000CRC.Value;
                if (mValuePre > nud20000CRC.Value)
                {
                    Error = true;
                    epError.SetError(nud20000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud20000CRC.Tag);
                    nuderror += 1;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud20000CRC.Value, 20000, nud20000CRC))
                    {
                        Error = false;
                        if (epError.GetError(nud20000CRC).Equals("") == false) nuderror -= 1;
                        epError.SetError(nud20000CRC, "");
                        nud20000CRC.Tag = nud20000CRC.Value;
                        origendiferenciadeposito = 0;
                        sumarTotales();
                    }
                }
                epError.SetError(txtDiferencia, "");
            }
        }

        private void nudDosmil_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {
                decimal mValuePre = (decimal)nud2000CRC.Tag;
                if (mValuePre > nud2000CRC.Value)
                {
                    Error = true;
                    nuderror += 1;
                    epError.SetError(nud2000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud2000CRC.Tag);
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud2000CRC.Value, 2000, nud2000CRC))
                    {
                        Error = false;
                        if (epError.GetError(nud2000CRC).Equals("") == false) nuderror -= 1;
                        epError.SetError(nud2000CRC, "");
                        nud2000CRC.Tag = nud2000CRC.Value;
                        origendiferenciadeposito = 0;
                        sumarTotales();
                    }
                }
                epError.SetError(txtDiferencia, "");
            }
        }

        private void nudDiezmil_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {
                decimal mValuePre = (decimal)nud10000CRC.Tag;
                if (mValuePre > nud10000CRC.Value)
                {
                    Error = true;
                    nuderror += 1;
                    epError.SetError(nud10000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud10000CRC.Tag);
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud10000CRC.Value, 10000, nud10000CRC))
                    {
                        Error = false;
                        if (epError.GetError(nud10000CRC).Equals("") == false) nuderror -= 1;
                        epError.SetError(nud10000CRC, "");
                        nud10000CRC.Tag = nud10000CRC.Value;
                        origendiferenciadeposito = 0;
                        sumarTotales();
                    }
                }
                epError.SetError(txtDiferencia, "");
            }
        }

        private void nudMil_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {
                decimal mValuePre = (decimal)nud1000CRC.Tag;
                if (mValuePre > nud1000CRC.Value)
                {
                    Error = true;
                    nuderror += 1;
                    epError.SetError(nud1000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud1000CRC.Tag);
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud1000CRC.Value, 1000, nud1000CRC))
                    {
                        Error = false;
                        if (epError.GetError(nud1000CRC).Equals("") == false) nuderror -= 1;
                        epError.SetError(nud1000CRC, "");
                        nud1000CRC.Tag = nud1000CRC.Value;
                        origendiferenciadeposito = 0;
                        sumarTotales();
                    }
                }
                epError.SetError(txtDiferencia, "");
            }
        }

        #endregion

        private void txtNumDeposito_Leave(object sender, EventArgs e)
        {
            txtCodigoVD.Text = txtCodigoVD.Text.Replace("\t", "");
            revisarprocesovacio();
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            revisarprocesovacio();
        }

        private void cboMonedaDeclarada_Leave(object sender, EventArgs e)
        {
            revisarprocesovacio();
        }

        private void cboTipoMesaNiquel_Leave(object sender, EventArgs e)
        {
            revisarprocesovacio();
        }

        private void nudMontoNiquel_Leave(object sender, EventArgs e)
        {
            revisarprocesovacio();
        }

        private void txtCodigoTransaccion_Leave(object sender, EventArgs e)
        {
            revisarprocesovacio();
        }

        private void txtNumDeposito_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCodigoVD.Text = txtCodigoVD.Text.Replace("\t", "");
                chktime = 0;
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error txtnumdeposito enter: " + ex.Message);
            }
        }

        private void txtCodigoVD_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCodigoVD.Text = txtCodigoVD.Text.Replace("\t", "");
                chktab = 0;
                chktime = 0;
                /*if ((!txtCodigoVD.Text.Equals("")) && (sw.IsRunning == false))
                    FirstCharacterEntered();*/
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error CODIGOVD enter: " + ex.Message);
            }
        }


        private void txtCodigoVD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Tab)
                    conteotabs += 1;
                if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back) || (e.Modifiers == Keys.Shift) || (e.Modifiers == Keys.ControlKey))
                {
                    if (sw != null)
                    {
                        if (sw.IsRunning == true)
                        {
                            sw.Stop();
                            sw.Reset();
                            chktime = 0;
                            conteotabs = 0;
                        }
                    }
                    if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Tab)
                    {
                        if (sw != null)
                        {
                            if (sw.IsRunning == true)
                            {
                                sw.Stop();
                                sw.Reset();
                                chktime = 0;
                                conteotabs = 0;
                            }
                        }
                        nudMontoDeclarado.Focus();
                    }
                    return;
                }
                if ((txtCodigoVD.Text.Length == 0) && (e.KeyValue == 9) && (e.Modifiers != Keys.Shift))
                {
                    nudMontoDeclarado.Focus();
                    return;
                }
                if (chktime == 0)
                {
                    FirstCharacterEntered();
                }
                if ((txtCodigoVD.Text.Length > 0) && (txtCodigoVD.Text.Length < 48) && (e.KeyValue == 9) && (sw.ElapsedMilliseconds / txtCodigoVD.Text.Length > 250))
                {
                    nudMontoDeclarado.Focus();
                }
                if (((txtCodigoVD.Text.Length == 48) && (e.KeyValue == 9)) || ((txtCodigoVD.Text.Length > 60) && (e.KeyValue == 9)))
                {
                    if (sw != null)
                    {
                        if (sw.IsRunning == true)
                        {
                            chktab = 1;
                            sw.Stop();
                            tiempo = sw.ElapsedMilliseconds;
                            txtCodigoVD.Text = txtCodigoVD.Text.Replace("\t", "");
                            chktime = 0;
                            nudMontoDeclarado.Focus();
                        }
                    }
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error keydown: " + ex.Message);
            }
        }

        private void txtCodigoVD_Leave(object sender, EventArgs e)
        {
            /*try
            {
                if (sw.IsRunning == true)
                {
                    sw.Stop();
                    tiempo = sw.ElapsedMilliseconds;
                    //txtCodigoVD.Text = txtCodigoVD.Text.Replace("\t", "");                
                    chktab = 0;
                    chktime = 0;
                    conteotabs = 0;
                    nudMontoDeclarado.Focus();
                }
                revisarprocesovacio();
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error txtcodigo leave: " + ex.Message);
            }*/
        }

        private void txtCodigoVD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // if (txtNumDeposito.Text.Length == 4)
                if (chktab == 1)
                {
                    chktab = 0;
                    if ((tiempo < 4500) && (txtCodigoVD.Text.Length > 10))
                    {
                        txtNumDeposito.Text = "";
                        numdeposito = txtCodigoVD.Text.Substring(22, 9);
                        String codigotrans = txtCodigoVD.Text.Substring(0, 4);
                        String ctaref = txtCodigoVD.Text.Substring(4, 9);
                        String cedula = txtCodigoVD.Text.Substring(txtCodigoVD.Text.Length - 9, 9);
                        txtCodigoTransaccion.Text = codigotrans;
                        txtCtaReferencia.Text = ctaref;
                        txtCedula.Text = cedula;
                        txtNumDeposito.Text = numdeposito;
                        txtCodigoVD.Text = "";
                        tiempo = 0;
                        nudMontoDeclarado.Focus();
                        //chktab = 2;                                   
                        //MessageBox.Show(numdeposito);
                    }
                }
                epError.SetError(txtNumDeposito, "");
                conteoerrores = 0;
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error txtNumDeposito text changed: " + ex.Message);
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                // btnVerificar_Click(sender, e);
            }
        }


        private void FirstCharacterEntered()
        {
            try
            {
                sw = new Stopwatch();
                sw.Start();
                chktime = 1;
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error firstcharacterEntered: " + ex.Message);
            }
        }


        private void cboTipoMesaNiquel_SelectedIndexChanged(object sender, EventArgs e)
        {
            epError.SetError(cboTipoMesaNiquel, "");
            conteoerrores = 0;
            if (_deposito.TipomesaNiquel == 1)
            {
                nudMontoNiquel.ReadOnly = true;
            }
            else
            {
                nudMontoNiquel.ReadOnly = false;
            }


        }


        private void nudMontoNiquel_ValueChanged(object sender, EventArgs e)
        {
            epError.SetError(nudMontoNiquel, "");
            origendiferenciadeposito = 1;
            sumarTotales();
        }

        private void txtCtaReferencia_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtCtaReferencia, "");
            conteoerrores = 0;
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtCedula, "");
            conteoerrores = 0;
        }

        private void cboMonedaDeclarada_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCtaReferencia.Text.Equals(""))
                {
                    if (_mantenimiento.VerificaCuentaReferenciaDeposito(txtCtaReferencia.Text, (Monedas)cboMonedaDeclarada.SelectedIndex, _manifiesto) == 0)
                    {
                        epError.SetError(txtCtaReferencia, "La cuenta referencia no corresponde a la moneda seleccionada o al Cliente y Punto de Venta asociado");
                        //txtCtaReferencia.Focus();
                    }
                    else
                    {
                        epError.SetError(txtCtaReferencia, "");
                    }
                }
                if (cboMonedaDeclarada.SelectedIndex != cboMoneda.SelectedIndex && datosCargados)
                {
                    epError.SetError(cboMoneda, "La moneda declarada es diferente a la moneda seleccionada");
                }
                else
                {
                    epError.SetError(cboMoneda, "");
                    conteoerrores = 0;
                }
                if (cboMonedaDeclarada.SelectedIndex == 0)
                {
                    nudMontoNiquel.Enabled = true;
                }
                else
                {
                    nudMontoNiquel.Value = 0;
                    nudMontoNiquel.Enabled = false;
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error cbomonedadeclarada: " + ex.Message);
            }
        }



        private void txtMontoContado_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtMontoContado, "");
            conteoerrores = 0;
        }

        private void txtCodigoTransaccion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                epError.SetError(txtCodigoTransaccion, "");
                conteoerrores = 0;
                switch (txtCodigoTransaccion.Text)
                {
                    case "5311":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "5313":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "5302":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "5303":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "5801":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "5603":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "2401":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "2502":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    //case "8003":
                    //    cboMoneda.SelectedIndex = 0;
                    //    cboMonedaDeclarada.SelectedIndex = 0;
                    //    break;
                    case "8004":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "2001":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "2700":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "2500":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "5800":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "2703":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "7610":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "7612":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "7614":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "7616":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
                    case "3002":
                        cboMoneda.SelectedIndex = 1;
                        cboMonedaDeclarada.SelectedIndex = 1;
                        break;
                    case "3005":
                        cboMoneda.SelectedIndex = 1;
                        cboMonedaDeclarada.SelectedIndex = 1;
                        break;
                    case "2400":
                        cboMoneda.SelectedIndex = 1;
                        cboMonedaDeclarada.SelectedIndex = 1;
                        break;
                    case "5312":
                        cboMoneda.SelectedIndex = 1;
                        cboMonedaDeclarada.SelectedIndex = 1;
                        break;
                    case "5314":
                        cboMoneda.SelectedIndex = 1;
                        cboMonedaDeclarada.SelectedIndex = 1;
                        break;
                    case "5316":
                        cboMoneda.SelectedIndex = 1;
                        cboMonedaDeclarada.SelectedIndex = 1;
                        break;
                    case "7613":
                        cboMoneda.SelectedIndex = 1;
                        cboMonedaDeclarada.SelectedIndex = 1;
                        break;
                    case "7617":
                        cboMoneda.SelectedIndex = 1;
                        cboMonedaDeclarada.SelectedIndex = 1;
                        break;
                    case "5317":
                        cboMoneda.SelectedIndex = 2;
                        cboMonedaDeclarada.SelectedIndex = 2;
                        break;
                    case "3008":
                        cboMoneda.SelectedIndex = 2;
                        cboMonedaDeclarada.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("txtcodigotransaccion_textchanged error: " + ex.Message);
            }
        }
        private void nudMontoNiquel_MouseClick(object sender, MouseEventArgs e)
        {
            frmActualizarRegistroDenominacionesNiquel formulario = null;
            if (_deposito.TipomesaNiquel == 1)
            {
                formulario = new frmActualizarRegistroDenominacionesNiquel(conteoNiquel, readOnly);
                formulario.ShowDialog(this);
            }
        }
        private void txtDiferencia_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtDiferencia, "");
            conteoerrores = 0;
        }

        private void txtNumDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error txtnumdeposito keypress: " + ex.Message);
            }
        }

        private void txtCtaReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        private void txtCodigoTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }


        private void txtCtaReferencia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!txtCtaReferencia.Text.Equals(""))
                {
                    if (_mantenimiento.VerificaCuentaReferenciaDeposito(txtCtaReferencia.Text, (Monedas)cboMoneda.SelectedIndex, _manifiesto) == 0)
                    {
                        epError.SetError(txtCtaReferencia, "La cuenta referencia no pertenece al Cliente y Punto de Venta asociado");
                        //txtCtaReferencia.Focus();
                    }
                    else
                    {
                        epError.SetError(txtCtaReferencia, "");
                    }
                }
                else
                {
                    revisarprocesovacio();
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error txtctareferencia leave: " + ex.Message);
            }
        }

        private void txtNumDeposito_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtNumDeposito, "");
            /*try
            {
                // if (txtNumDeposito.Text.Length == 4)
                if (chktab == 1)
                {
                    chktab = 0;
                    if ((tiempo < 3500) && (txtNumDeposito.Text.Length > 10))
                    {
                        numdeposito = txtNumDeposito.Text.Substring(27, 9);
                        String codigotrans = txtNumDeposito.Text.Substring(0, 4);
                        String ctaref = txtNumDeposito.Text.Substring(5, 9);
                        String cedula = txtNumDeposito.Text.Substring(39, 9);                        
                        txtCodigoTransaccion.Text = codigotrans;
                        txtCtaReferencia.Text = ctaref;
                        txtCedula.Text = cedula;
                        txtNumDeposito.Text = numdeposito;
                        txtNumDeposito.Text.Remove(0, 5);
                        txtNumDeposito_Leave(sender, e);
                        //chktab = 2;                                   
                        //MessageBox.Show(numdeposito);
                    }                    
                }
                epError.SetError(txtNumDeposito, "");
                conteoerrores = 0;
            }            
            catch (Excepcion ex)
            {
                MessageBox.Show("Error txtNumDeposito text changed: " + ex.Message);
            }*/
        }


        private void txtNumDeposito_KeyDown(object sender, KeyEventArgs e)
        {
            /*try
            {
                if (txtNumDeposito.Text.Length == 0)
                    FirstCharacterEntered();
                if ((txtNumDeposito.Text.Length == 0) && (e.KeyValue == 9))
                    txtCodigoVD.Focus();                
                if (txtNumDeposito.Text.Length == 4)
                {
                    MessageBox.Show(e.KeyValue.ToString());
                }
                if ((((txtNumDeposito.Text.Length == 10) || (txtNumDeposito.Text.Length == 9)) && (e.KeyValue == 9)) || ((txtNumDeposito.Text.Length == 48) && (e.KeyValue == 9)))
                {
                    //txtCodigoVD.Focus();
                    if (sw.IsRunning == true)
                    {
                        chktab = 1;
                        sw.Stop();
                        tiempo = sw.ElapsedMilliseconds;
                        txtnumdeposito2.Text = txtNumDeposito.Text.Replace("\t", "");                                                
                    }
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedIndex == cboMonedaDeclarada.SelectedIndex)
            {
                if (cboMoneda.SelectedIndex == 0)
                {
                    gbcolones.BringToFront();
                }
                else if (cboMoneda.SelectedIndex == 1)
                {
                    gbdolares.BringToFront();
                }
                else
                {
                    gbeuros.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("La moneda declarada y del depósito deben ser la misma", "Infomración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void actualizarlistachequesDeposito(BindingList<ChequeDeposito> listachequesdeposito)
        {
            _deposito.ChequeDeposito = listachequesdeposito;
            origendiferenciadeposito = 3;
            sumarTotales();
        }

        public void actualizarmontoNiquel(Decimal monto)
        {
            nudMontoNiquel.Value = monto;
        }

        public void actualizarconteoNiquel(ConteoNiquel cNiquel)
        {
            conteoNiquel = cNiquel;
        }

        private void gbcolones_Enter(object sender, EventArgs e)
        {

        }

        private void nud10USD_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void nud500EUR_Validating(object sender, CancelEventArgs e)
        {

        }

        private void gbDatosDeposito_Enter(object sender, EventArgs e)
        {

        }

        private void gbdolares_Enter(object sender, EventArgs e)
        {

        }

        private void pnlFondo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbDatosDeposito_Enter_1(object sender, EventArgs e)
        {

        }
    }



}
